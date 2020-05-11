using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using futurocom.snmp.alarme;
using futurocom.snmp;
using sc2i.common;
using sc2i.expression;
using futurocom.supervision;
using futurocom.snmp.dynamic;
using sc2i.win32.common;
using sc2i.common.memorydb;
using futurocom.snmp.entitesnmp;

namespace futurocom.win32.snmp.alarmes
{
    public partial class CPanelEditAgentFinder : UserControl, IControlALockEdition
    {
        private CAgentFinderFromKey m_originalAgentFinder = null;
        private CAgentFinderFromKey m_agentFinder = null;
        private IBaseTypesAlarmes m_baseTypesAlarmes = null;

        public CPanelEditAgentFinder()
        {
            InitializeComponent();
        }

        public void Init(
            CAgentFinderFromKey agentFinder,
            IBaseTypesAlarmes baseAlarmes,
            IDefinition rootDefinition)
        {
            m_originalAgentFinder = agentFinder;
            CMemoryDb dbEdition = new CMemoryDb();
            m_agentFinder = dbEdition.ImporteObjet(agentFinder, true, true) as CAgentFinderFromKey;
            m_agentFinder.TypeAgent = agentFinder.TypeAgent;
            m_baseTypesAlarmes = baseAlarmes;
            InitChamps();
        }

        public CResultAErreur MajChamps()
        {
            CResultAErreur result = m_linkField.FillObjetFromDialog(m_agentFinder);
            if (result)
            {
                m_agentFinder.FormuleDeclenchement = m_txtFormuleCondition.Formule;
                m_agentFinder.GenericRequestedValue = m_cmbGenericCode.SelectedItem as GenericCode?;
            }
            m_agentFinder.AutoUpdateIpOnMediationServices = m_chkUpdateIPOnMediation.Checked;
            m_agentFinder.AutoUpdateIpOnTimosDatabase = m_chkUpdateIpInTimos.Checked;
            m_agentFinder.FormuleCleSpecifique = m_txtFormuleCleSpecifiqueAgent.Formule;
            if (result)
                result = m_agentFinder.VerifieDonnees();
            if (result)
            {

                m_originalAgentFinder.Database.Merge(m_agentFinder.Database, false);// ImporteObjet(m_handler, true, true);
                //CCloner2iSerializable.CopieTo(m_handler, m_originalHandler);
            }

            return result;
        }

        private void InitChamps()
        {
            m_linkField.FillDialogFromObjet(m_agentFinder);
            m_cmbGenericCode.Items.Clear();
            m_cmbGenericCode.Items.Add(I.T("Any|20059"));

            foreach (GenericCode code in Enum.GetValues(typeof(GenericCode)))
                m_cmbGenericCode.Items.Add(code);
            if (m_agentFinder.GenericRequestedValue == null)
                m_cmbGenericCode.SelectedIndex = 0;
            else
                m_cmbGenericCode.SelectedItem = m_agentFinder.GenericRequestedValue.Value;
            m_txtFormuleCondition.Init(m_agentFinder, typeof(CTrapInstance));
            m_txtFormuleCondition.Formule = m_agentFinder.FormuleDeclenchement;

            m_txtFormuleCleSpecifiqueAgent.Init(m_agentFinder, typeof(CTrapInstance));
            m_txtFormuleCleSpecifiqueAgent.Formule = m_agentFinder.FormuleCleSpecifique;

            m_chkUpdateIpInTimos.Checked = m_agentFinder.AutoUpdateIpOnTimosDatabase;
            m_chkUpdateIPOnMediation.Checked = m_agentFinder.AutoUpdateIpOnMediationServices;

            FillListeTrapFields();
            FillListeFieldsSupplementaires();



        }

        //---------------------------------------------------------
        private void FillListeTrapFields()
        {
            m_wndListeChamps.ListeSource = m_agentFinder.FieldsFromTrap.ToArray();
            m_wndListeChamps.Refresh();
        }

        //---------------------------------------------------------
        private void FillListeFieldsSupplementaires()
        {
            m_wndListeChampsSupplementaires.ListeSource = m_agentFinder.FieldsSupplementaires.ToArray();
            m_wndListeChampsSupplementaires.Refresh();
        }

        //---------------------------------------------------------
        private void m_lnkRemoveChamp_LinkClicked(object sender, EventArgs e)
        {
            if (m_wndListeChamps.SelectedItems.Count == 1)
            {
                CTrapField field = m_wndListeChamps.SelectedItems[0] as CTrapField;
                if (field != null)
                {
                    m_agentFinder.RemoveFieldFromTrap(field);
                    FillListeTrapFields();
                }
            }
        }

        //---------------------------------------------------------
        private void m_lnkAddChamp_LinkClicked(object sender, EventArgs e)
        {
            CTrapField field = new CTrapField();
            if (CFormEditTrapField.EditeField(field))
            {
                m_agentFinder.AddFieldFromTrap(field);
                FillListeTrapFields();
            }
        }

        //---------------------------------------------------------
        private void m_wndListeChamps_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!m_extModeEdition.ModeEdition)
                return;
            EditeChampTrap();
        }

        private void EditeChampTrap()
        {
            if (m_wndListeChamps.SelectedItems.Count == 1)
            {
                CTrapField field = m_wndListeChamps.SelectedItems[0] as CTrapField;
                if (field != null)
                {
                    if (CFormEditTrapField.EditeField(field))
                    {
                        FillListeTrapFields();
                    }
                }
            }
        }

        //---------------------------------------------------------
        private void m_lnkRemoveChampSupplementaire_LinkClicked(object sender, EventArgs e)
        {
            if (m_wndListeChampsSupplementaires.SelectedItems.Count == 1)
            {
                CTrapFieldSupplementaire field = m_wndListeChampsSupplementaires.SelectedItems[0] as CTrapFieldSupplementaire;
                if (field != null)
                {
                    m_agentFinder.RemoveFieldSupplementaire(field);
                    FillListeFieldsSupplementaires();
                }
            }
        }

        //---------------------------------------------------------
        private void m_lnkAddChampSupplementaires_LinkClicked(object sender, EventArgs e)
        {
            CTrapFieldSupplementaire field = new CTrapFieldSupplementaire();
            if (CFormEditTrapFieldSupplementaire.EditeField(field))
            {
                m_agentFinder.AddFieldSupplementaire(field);
                FillListeFieldsSupplementaires();
            }
        }

        //---------------------------------------------------------
        private void m_wndListeChampsSupplementaires_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!m_extModeEdition.ModeEdition)
                return;
            EditeChampSupp();
        }

        private void EditeChampSupp()
        {
            if (m_wndListeChampsSupplementaires.SelectedItems.Count == 1)
            {
                CTrapFieldSupplementaire field = m_wndListeChampsSupplementaires.SelectedItems[0] as CTrapFieldSupplementaire;
                if (field != null)
                {
                    if (CFormEditTrapFieldSupplementaire.EditeField(field))
                    {
                        FillListeFieldsSupplementaires();
                    }
                }
            }
        }


        //-------------------------------------------
        public bool LockEdition
        {
            get
            {
                return !m_extModeEdition.ModeEdition;
            }
            set
            {
                m_extModeEdition.ModeEdition = !value;
                if (OnChangeLockEdition != null)
                    OnChangeLockEdition(this, new EventArgs());
            }
        }

        //-------------------------------------------------------------
        public event EventHandler OnChangeLockEdition;

        private void m_lnkDetailChampTrap_LinkClicked(object sender, EventArgs e)
        {
            EditeChampTrap();
        }

        private void m_lnkEditChampSupp_LinkClicked(object sender, EventArgs e)
        {
            EditeChampSupp();
        }


        private void m_tabControl_SelectionChanged(object sender, EventArgs e)
        {

        }

    }

}

