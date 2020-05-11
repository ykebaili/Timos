using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.common.DonneeCumulee;
using futurocom.snmp.entitesnmp;
using futurocom.snmp.polling;
using sc2i.win32.common.customizableList;
using futurocom.win32.snmp.polling;
using sc2i.common;
using sc2i.common.unites.standard;
using sc2i.common.unites;
using futurocom.snmp.HotelPolling;

namespace futurocom.win32.snmp.hotelpolling
{
    public partial class CPanelHotelPoolingSetup : UserControl
    {
        private CAgentSnmpPourSupervision m_agent = null;
        private CSnmpHotelPollingSetup m_setup = null;

        private CControleEditeHotelPolledData m_controleItem = new CControleEditeHotelPolledData();

        public CPanelHotelPoolingSetup()
        {
            InitializeComponent();
            m_wndListeChamps.ItemControl = m_controleItem;
            m_controleItem.LockEdition = false;
            m_txtFrequence.DefaultFormat = CClasseUniteTemps.c_idMIN;
        }

        //--------------------------------------------------
        public void Init(CSnmpHotelPollingSetup pollingSetup,
            CAgentSnmpPourSupervision agent)
        {
            m_agent = agent;
            m_setup = pollingSetup;
            m_txtLibelle.Text = pollingSetup.Libelle;
            m_txtFrequence.UnitValue = new CValeurUnite(m_setup.FrequenceMinutes, CClasseUniteTemps.c_idMIN);
            m_txtIP.Text = pollingSetup.HotelIp;
            m_txtNumPort.IntValue = pollingSetup.HotelPort;
            m_extModeEdition.ModeEdition = !pollingSetup.Id.StartsWith(CSnmpHotelPollingSetup.c_IdPollingSystem);
            m_controleItem.LockEdition = !m_extModeEdition.ModeEdition;
            FillListeChamps();
        }

        //--------------------------------------------------
        private void FillListeChamps()
        {
            List<CCustomizableListItem> lstItems = new List<CCustomizableListItem>();
            m_controleItem.InitControle(m_agent);
            foreach (CSnmpHotelPolledData polledData in m_setup.PolledDatas)
            {
                CCustomizableListItem item = new CCustomizableListItem();
                item.Tag = polledData;
                lstItems.Add(item);
            }

            m_wndListeChamps.Items = lstItems.ToArray();
        }

        
        //--------------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_txtLibelle.Text.Length == 0)
            {
                result.EmpileErreur(I.T("Enter a label for this polling setup|20127"));
                return result;
            }
            result = m_wndListeChamps.MajChamps();
            if (!result)
                return result;
            CListeSnmpHotelPolledData lstData = new CListeSnmpHotelPolledData();
            foreach (CCustomizableListItem item in m_wndListeChamps.Items)
            {
                CSnmpHotelPolledData data = item.Tag as CSnmpHotelPolledData;
                if (data.Formule != null)
                    lstData.Add(data);
            }
            m_setup.HotelIp = m_txtIP.Text;
            m_setup.HotelPort = m_txtNumPort.IntValue.Value;
            m_setup.Libelle = m_txtLibelle.Text;
            m_setup.PolledDatas = lstData;
            if (m_txtFrequence.UnitValue == null)
                m_setup.FrequenceMinutes = 0;
            else
                m_setup.FrequenceMinutes = m_txtFrequence.UnitValue.ConvertTo(CClasseUniteTemps.c_idMIN).Valeur;
            return result;
        }

        //---------------------------------------------------------------------
        private void m_btnAddData_LinkClicked(object sender, EventArgs e)
        {
            CSnmpHotelPolledData data = new CSnmpHotelPolledData();
            CCustomizableListItem item = new CCustomizableListItem();
            item.Tag = data;
            m_wndListeChamps.AddItem(item, true);
            m_wndListeChamps.CurrentItemIndex = item.Index;
        }


        //---------------------------------------------------------------------
        private void m_btnRemoveData_LinkClicked(object sender, EventArgs e)
        {
            if ( m_wndListeChamps.CurrentItemIndex != null )
            {
                CCustomizableListItem item = m_wndListeChamps.Items[m_wndListeChamps.CurrentItemIndex.Value];
                m_wndListeChamps.RemoveItem(item, true);
            }
        }
    }
}
