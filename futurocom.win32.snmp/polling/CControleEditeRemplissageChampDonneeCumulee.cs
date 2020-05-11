using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common;
using sc2i.win32.common.customizableList;
using sc2i.common;
using futurocom.snmp.polling;
using sc2i.common.DonneeCumulee;
using futurocom.snmp.entitesnmp;
using sc2i.expression;

namespace futurocom.win32.snmp.polling
{
    public partial class CControleEditeRemplissageChampDonneeCumulee : CCustomizableListControl
    {
        private ITypeDonneeCumulee m_typeDonneeCumulee = null;
        private CAgentSnmpPourSupervision m_agent = null;

        //-------------------------------------------------------
        public CControleEditeRemplissageChampDonneeCumulee()
        {
            InitializeComponent();
        }

        //-------------------------------------------------------
        public void InitControle ( CAgentSnmpPourSupervision agent,
            ITypeDonneeCumulee typeDonneeCumulee )
        {
            m_agent =  agent;
            m_typeDonneeCumulee = typeDonneeCumulee;
            m_txtFormule.Init ( new CFournisseurGeneriqueProprietesDynamiques(), new CObjetPourSousProprietes(m_agent) );
        }

        //-------------------------------------------------------
        protected override CResultAErreur MyInitChamps(CCustomizableListItem item)
        {
            CResultAErreur result = base.MyInitChamps(item);
            if (!result)
                return result;
            CParametreFillChampDonneeCumulee p = item != null ? item.Tag as CParametreFillChampDonneeCumulee : null;
            if (p != null)
            {
                string strNom = "";
                if (m_typeDonneeCumulee != null)
                    strNom = m_typeDonneeCumulee.GetNomChamp(p.Champ);
                else
                    strNom = p.Champ.TypeChamp.ToString() + p.Champ.NumeroChamp;
                m_lblChamp.Text = strNom;
                if (IsCreatingImage)
                {
                    m_lblFormule.Text = p.FormuleSource != null ?
                        p.FormuleSource.GetString() :
                        "";
                    m_txtFormule.Visible = false;
                    m_lblFormule.Visible = true;
                    m_lblFormule.Dock = DockStyle.Fill;
                }
                else
                {
                    m_txtFormule.Formule = p.FormuleSource;
                    m_txtFormule.Visible = true;
                    m_lblFormule.Visible = false;
                    m_txtFormule.Dock = DockStyle.Fill;
                }
            }
            return result;

        }

        //--------------------------------------------------
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

        //--------------------------------------------------
        public override bool IsFixedSize
        {
            get
            {
                return true;
            }
        }

        //--------------------------------------------------
        public override bool AspectDifferentEnInactif
        {
            get
            {
                return true;
            }
        }

        //--------------------------------------------------
        protected override CResultAErreur MyMajChamps()
        {
            CResultAErreur result = base.MyMajChamps();
            if (result)
            {
                CParametreFillChampDonneeCumulee p = CurrentItem != null ?
                    CurrentItem.Tag as CParametreFillChampDonneeCumulee
                    : null;
                if (p != null)
                {
                    p.FormuleSource = m_txtFormule.Formule;
                    if (m_txtFormule.Formule == null &&
                        !m_txtFormule.ResultAnalyse)
                        result.EmpileErreur(m_txtFormule.ResultAnalyse.Erreur);
                }
            }
            return result;
        }
    }
}
