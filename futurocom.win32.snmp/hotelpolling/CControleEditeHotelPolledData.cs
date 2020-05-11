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
using futurocom.snmp.HotelPolling;

namespace futurocom.win32.snmp.hotelpolling
{
    public partial class CControleEditeHotelPolledData : CCustomizableListControl
    {
        private CAgentSnmpPourSupervision m_agent = null;

        //-------------------------------------------------------
        public CControleEditeHotelPolledData()
        {
            InitializeComponent();
        }

        //-------------------------------------------------------
        public void InitControle ( CAgentSnmpPourSupervision agent)
        {
            m_agent =  agent;
            m_txtFormule.Init ( new CFournisseurGeneriqueProprietesDynamiques(), new CObjetPourSousProprietes(m_agent) );
        }

        //-------------------------------------------------------
        protected override CResultAErreur MyInitChamps(CCustomizableListItem item)
        {
            CResultAErreur result = base.MyInitChamps(item);
            if (!result)
                return result;
            CSnmpHotelPolledData p = item != null ? item.Tag as CSnmpHotelPolledData : null;
            if (p != null)
            {
                m_txtHotelTable.Text = p.HotelTable;
                m_txtHotelField.Text = p.HotelField;
                m_txtEntityId.Text = p.EntityId;
                if (IsCreatingImage)
                {
                    m_lblFormule.Text = p.Formule != null ?
                        p.Formule.GetString() :
                        "";
                    m_txtFormule.Visible = false;
                    m_lblFormule.Visible = true;
                    m_lblFormule.Dock = DockStyle.Fill;
                }
                else
                {
                    m_txtFormule.Formule = p.Formule;
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
                CSnmpHotelPolledData p = CurrentItem != null ?
                    CurrentItem.Tag as CSnmpHotelPolledData
                    : null;
                if (p != null)
                {
                    p.Formule = m_txtFormule.Formule;
                    if (m_txtFormule.Formule == null &&
                        !m_txtFormule.ResultAnalyse)
                        result.EmpileErreur(m_txtFormule.ResultAnalyse.Erreur);
                    p.HotelField = m_txtHotelField.Text;
                    p.HotelTable = m_txtHotelTable.Text;
                    p.EntityId = m_txtEntityId.Text;
                }
            }
            return result;
        }
    }
}
