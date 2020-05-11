using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using futurocom.snmp;
using futurocom.snmp.Mib;
using sc2i.win32.common;
using sc2i.common;
using System.Net;

namespace futurocom.win32.snmp
{
    public partial class CFormSendTrap : Form
    {

        private IObjectTree m_objectTree = null;
        private IDefinition m_definition = null;
        private TrapType m_trap = null;
        private NotificationType m_notification = null;

        //---------------------------------------------------
        public CFormSendTrap()
        {
            InitializeComponent();
            CWin32Traducteur.Translate(this);
        }

        //---------------------------------------------------
        public static void SendTrap(IDefinition definition, IObjectTree objectTree)
        {
            CFormSendTrap frm = new CFormSendTrap();
            frm.m_objectTree = objectTree;
            frm.m_definition = definition;
            frm.ShowDialog();
            frm.Dispose();
        }

        //---------------------------------------------------
        private void InitComboVersions()
        {
            m_cmbTrapVersion.Items.Clear();
            foreach (VersionCode code in Enum.GetValues(typeof(VersionCode)))
            {
                m_cmbTrapVersion.Items.Add(code.ToString());
            }
        }

        //---------------------------------------------------
        private void InitComboGenericCode()
        {
            m_cmbGenericCode.Items.Clear();
            foreach (GenericCode code in Enum.GetValues(typeof(GenericCode)))
            {
                m_cmbGenericCode.Items.Add(code.ToString());
            }
        }

        //---------------------------------------------------
        public void InitDialog(IDefinition definition, IObjectTree mibTree )
        {
            m_definition = definition;
            m_trap = m_definition.Entity as TrapType;
            m_notification = m_definition.Entity as NotificationType;


            InitComboVersions();
            InitComboGenericCode();

            m_cmbGenericCode.Text = GenericCode.EnterpriseSpecific.ToString();
            m_cmbTrapVersion.Text = VersionCode.V1.ToString();

            string strOID = ObjectIdentifier.Convert(m_definition.GetNumericalForm());
            if (strOID.IndexOf('.') >= 0)
            {
                string strGeneric = strOID.Substring(strOID.LastIndexOf('.') + 1);
                strOID = strOID.Substring(0, strOID.LastIndexOf('.'));
                m_txtSpecificCode.Text = strGeneric;
            }
            m_txtEntreprise.Text = strOID;
            m_txtCommunity.Text = "public";

            m_panelVariables.SuspendDrawing();
            m_panelVariables.ClearAndDisposeControls();
            List<string> lstVariables = new List<string>();
            if (m_trap != null)
                lstVariables.AddRange(m_trap.Variables);
            else if (m_notification != null)
                lstVariables.AddRange(m_notification.Objects);
            foreach (string strVariable in lstVariables)
            {
                IDefinition defVar = mibTree.Find(strVariable);
                if (defVar != null)
                {
                    CControlTrapVariable ctrl = new CControlTrapVariable();
                    m_panelVariables.Controls.Add(ctrl);
                    ctrl.Dock = DockStyle.Top;
                    ctrl.BringToFront();
                    ctrl.Init(defVar);
                }
            }
            m_panelVariables.ResumeDrawing();
        }

        //----------------------------------------------------------------
        private void CFormSendTrap_Load(object sender, EventArgs e)
        {
            if (m_definition != null && m_objectTree != null)
            {
                InitDialog(m_definition, m_objectTree);
            }
        }

        //----------------------------------------------------------------
        private CResultAErreurType<CSnmpTrap> CreateTrap()
        {
            CResultAErreurType<CSnmpTrap> result = new CResultAErreurType<CSnmpTrap>();
            CSnmpTrap trap = new CSnmpTrap();
            trap.AgentIpString = m_txtIP.Text;
            trap.Communaute = m_txtCommunity.Text;

            try
            {
                GenericCode code = (GenericCode)Enum.Parse(typeof(GenericCode), m_cmbGenericCode.Text);
                trap.GenericCode = code;
            }
            catch
            {
                result.EmpileErreur(I.T("Invalid generic code|20115"));
            }
            try
            {
                VersionCode code = (VersionCode)Enum.Parse(typeof(VersionCode), m_cmbTrapVersion.Text);
                trap.VersionCode = code;
            }
            catch
            {
                result.EmpileErreur(I.T("Invalide version code|20116"));
            }
            if (trap.GenericCode == GenericCode.EnterpriseSpecific)
            {
                try
                {
                    trap.EntrepriseOID = new ObjectIdentifier(m_txtEntreprise.Text);
                }
                catch
                {
                    result.EmpileErreur(I.T("Invalid entreprise value|20117"));
                }
                if (m_txtSpecificCode.IntValue == null)
                {
                    result.EmpileErreur(I.T("Invalide specific code[20118"));
                }
                else
                    trap.SpecificCode = m_txtSpecificCode.IntValue.Value;
            }
            trap.TrapDateTime = DateTime.Now;
            foreach (Control ctrl in m_panelVariables.Controls)
            {
                CControlTrapVariable trapV = ctrl as CControlTrapVariable;
                if (trapV != null)
                {
                    CResultAErreurType<ISnmpData> resData = trapV.GetValue();
                    if (!resData)
                    {
                        result.EmpileErreur(resData.Erreur);
                    }
                    else if (resData.DataType != null)
                    {
                        IDefinition def = trapV.Definition;
                        trap.SetVariableValue(ObjectIdentifier.Convert(def.GetNumericalForm()), resData.DataType);
                    }
                }
            }
            if (result)
                result.DataType = trap;
            return result;
        }


        private void m_txtPortDest_TextChanged(object sender, EventArgs e)
        {

        }


        //-----------------------------------------------------------
        private void m_btnOk_Click(object sender, EventArgs e)
        {
            CResultAErreurType<CSnmpTrap> resTrap = CreateTrap();
            CResultAErreur result = CResultAErreur.True;
            if ( !resTrap )
                result.EmpileErreur ( resTrap.Erreur );
            if (result)
            {
                try
                {
                    IPAddress add = IPAddress.Parse(m_txtIpDest.Text);
                }
                catch
                {
                    result.EmpileErreur(I.T("Invalid receiver IP|20119"));
                }
                if (m_txtPortDest.IntValue == null)
                {
                    result.EmpileErreur(I.T("Invalid receiver port|20120"));
                }
            }
            if (result)
            {
                try
                {
                    resTrap.DataType.SendTrapUnsafe(m_txtIpDest.Text, m_txtPortDest.IntValue.Value);
                }
                catch (Exception ex)
                {
                    result.EmpileErreur(new CErreurException(ex));

                }
            }

            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
                return;
            }
            else
                CFormAlerte.Afficher(I.T("Trap sent|20121"));
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CResultAErreurType<CSnmpTrap> resTrap = CreateTrap();
            if (!resTrap)
            {
                CFormAlerte.Afficher(resTrap.Erreur);
            }
            else
            {
                string strVal = resTrap.DataType.GetStringFormuleCreation();
                if (strVal != null && strVal.Length > 0)
                {
                    Clipboard.SetText(strVal);
                    CFormAlerte.Afficher(I.T("Creation formula has been copied to clipboard|20123"));
                }
            }
        }
    }
}
