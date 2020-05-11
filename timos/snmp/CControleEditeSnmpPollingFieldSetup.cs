using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sc2i.win32.common.customizableList;
using timos.data.snmp;
using timos.snmp.polling;
using sc2i.common;
using timos.data.snmp.polling;
using sc2i.expression;

namespace timos.snmp
{
    public partial class CControleEditeSnmpPollingFieldSetup : CCustomizableListControl
    {
        private CTypeEntiteSnmp m_typeEntiteSnmp = null;

        //--------------------------------------------------------------------
        public CControleEditeSnmpPollingFieldSetup()
        {
            InitializeComponent();
        }

        //--------------------------------------------------------------------
        public override bool AspectDifferentEnInactif
        {
            get
            {
                return true;
            }
        }

        //--------------------------------------------------------------------
        public CTypeEntiteSnmp TypeEntiteSnmp
        {
            get
            {
                return m_typeEntiteSnmp;
            }
            set
            {
                m_typeEntiteSnmp = value;
                m_selectField.Init(typeof(CSnmpPollingField), "Nom", true);
                m_txtFormulePoll.Init(new CFournisseurProprietesDynamiquesForPolling(value), typeof(CEntiteSnmp));
                m_txtFormuleEntite.Init(new CFournisseurGeneriqueProprietesDynamiques(), typeof(CEntiteSnmp));
            }
        }
        
        //--------------------------------------------------------------------
        protected override CResultAErreur MyInitChamps(CCustomizableListItem item)
        {
            CResultAErreur result = base.MyInitChamps(item);
            if (!result)
                return result;
            CSnmpPollingFieldSetup setup = item != null?item.Tag as CSnmpPollingFieldSetup:null;
            if (setup != null)
            {
                CSnmpPollingField field = new CSnmpPollingField(m_typeEntiteSnmp.ContexteDonnee);
                if (field.ReadIfExistsUniversalId(setup.PollingFieldUID))
                    m_selectField.ElementSelectionne = field;
                else
                    m_selectField.ElementSelectionne = null;
                if (IsCreatingImage)
                {
                    m_txtFormulePoll.Visible = false;
                    m_lblFormulePoll.Text = setup.FormulePolling != null ?
                        setup.FormulePolling.GetString() : "";
                    m_lblFormulePoll.Dock = DockStyle.Fill;
                    m_lblFormulePoll.Visible = true;

                    m_txtFormuleEntite.Visible = false;
                    m_lblFormuleEntite.Text = setup.FormuleIdEntite != null ?
                        setup.FormuleIdEntite.GetString() : "";
                    m_lblFormuleEntite.Dock = DockStyle.Fill;
                    m_lblFormuleEntite.Visible = true;
                }
                else
                {
                    m_lblFormulePoll.Visible = false;
                    m_txtFormulePoll.Formule = setup.FormulePolling;
                    m_txtFormulePoll.Visible = true;

                    m_lblFormuleEntite.Visible = false;
                    m_txtFormuleEntite.Formule = setup.FormuleIdEntite;
                    m_txtFormuleEntite.Visible = true;
                }
            }
            HasChange = false;
            return result;
        }

        //--------------------------------------------------------------------
        public override bool HasChange
        {
            get
            {
                return true;
            }
            set
            {
                base.HasChange = value;
            }
        }

        //--------------------------------------------------------------------
        public override bool IsFixedSize
        {
            get
            {
                return true;
            }
        }

        //--------------------------------------------------------------------
        protected override CResultAErreur MyMajChamps()
        {
            CResultAErreur result = base.MyMajChamps();
            if (result && CurrentItem != null)
            {
                CSnmpPollingFieldSetup setup = CurrentItem.Tag as CSnmpPollingFieldSetup;
                if (setup != null)
                {
                    if (m_selectField.ElementSelectionne is CSnmpPollingField)
                        setup.PollingFieldUID = m_selectField.ElementSelectionne.IdUniversel;
                    else
                        setup.PollingFieldUID = null;
                    if (m_txtFormulePoll.Formule == null && !m_txtFormulePoll.ResultAnalyse)
                        return m_txtFormulePoll.ResultAnalyse;
                    else
                        setup.FormulePolling = m_txtFormulePoll.Formule;

                    if (m_txtFormuleEntite.Formule == null && !m_txtFormuleEntite.ResultAnalyse)
                        return m_txtFormuleEntite.ResultAnalyse;
                    else
                        setup.FormuleIdEntite= m_txtFormuleEntite.Formule;
                }
            }
            return result;
        }
        


    }
}
