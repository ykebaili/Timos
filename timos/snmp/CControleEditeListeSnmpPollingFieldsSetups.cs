using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using timos.data.snmp.polling;
using timos.data.snmp;
using sc2i.win32.common.customizableList;
using timos.snmp.polling;
using sc2i.common;
using sc2i.win32.common;

namespace timos.snmp
{
    public partial class CControleEditeListeSnmpPollingFieldsSetups : UserControl, IControlALockEdition
    {
        private CListeSnmpPollingFields m_listeFields = new CListeSnmpPollingFields();
        private CTypeEntiteSnmp m_typeEntite = null;


        //--------------------------------------------------------------
        public CControleEditeListeSnmpPollingFieldsSetups()
        {
            InitializeComponent();
            m_wndListeSetups.ItemControl = new CControleEditeSnmpPollingFieldSetup();
            m_wndListeSetups.ItemControl.LockEdition = false;
        }

        //--------------------------------------------------------------
        public void Init ( CTypeEntiteSnmp typeEntite )
        {
            m_typeEntite = typeEntite;
            m_listeFields = typeEntite.PollingFields;
            ((CControleEditeSnmpPollingFieldSetup)m_wndListeSetups.ItemControl).TypeEntiteSnmp = typeEntite;
            FillFields();
        }

        //--------------------------------------------------------------
        public void FillFields()
        {
            List<CCustomizableListItem> lst = new List<CCustomizableListItem>();
            foreach ( CSnmpPollingFieldSetup setup in m_listeFields.Fields )
            {
                CCustomizableListItem item = new CCustomizableListItem();
                item.Tag = setup;
                lst.Add(item);
            }
            m_wndListeSetups.Items = lst.ToArray();
            m_wndListeSetups.Refill();
        }

        //--------------------------------------------------------------
        private void m_btnAddSetup_LinkClicked(object sender, EventArgs e)
        {
            CSnmpPollingFieldSetup setup = new CSnmpPollingFieldSetup();
            CCustomizableListItem item = new CCustomizableListItem();
            item.Tag = setup;
            m_wndListeSetups.AddItem(item, true);
        }

        //--------------------------------------------------------------
        private void m_btnDelete_LinkClicked(object sender, EventArgs e)
        {
            if ( m_wndListeSetups.CurrentItemIndex != null )
            {
                CCustomizableListItem item = m_wndListeSetups.Items[m_wndListeSetups.CurrentItemIndex.Value];
                CSnmpPollingFieldSetup setup = item.Tag as CSnmpPollingFieldSetup;
                if ( setup != null )
                {
                    string strInfo = m_wndListeSetups.CurrentItemIndex.Value.ToString();
                    CSnmpPollingField field = new CSnmpPollingField(m_typeEntite.ContexteDonnee);
                    if (field.ReadIfExistsUniversalId(setup.PollingFieldUID))
                        strInfo = field.Nom;
                    if (MessageBox.Show(I.T("Remove setup for field @1 ?|20892", strInfo),
                        "",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        m_wndListeSetups.RemoveItem(m_wndListeSetups.CurrentItemIndex.Value, true);
                    }
                }
            }
        }

        //--------------------------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_wndListeSetups.CurrentItemIndex != null)
                m_wndListeSetups.MajChamps();
            CListeSnmpPollingFields lst = new CListeSnmpPollingFields();
            foreach (CCustomizableListItem item in m_wndListeSetups.Items)
            {
                CSnmpPollingFieldSetup setup = item.Tag as CSnmpPollingFieldSetup;
                //Vérifie que le champ est correct
                CSnmpPollingField field = new CSnmpPollingField(m_typeEntite.ContexteDonnee);
                if (!field.ReadIfExistsUniversalId(setup.PollingFieldUID))
                {
                    result.EmpileErreur(I.T("The Snmp Field is not selected on line @1|20893", item.Index.ToString()));
                    return result;
                }
                if (setup.FormulePolling == null)
                {
                    result.EmpileErreur(I.T("Incorrect formula for polling field @1|20894", field.Nom));
                    return result;
                }
                lst.AddField(setup);
            }
            if (result)
                m_typeEntite.PollingFields = lst;
            return result;
        }

        //-----------------------------------------------------
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
                    OnChangeLockEdition(this, null);
            }
        }

        //-----------------------------------------------------
        public event EventHandler OnChangeLockEdition;
    }
}
