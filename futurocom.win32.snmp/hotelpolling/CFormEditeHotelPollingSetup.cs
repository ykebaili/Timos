using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using futurocom.snmp.polling;
using futurocom.snmp.entitesnmp;
using sc2i.common.DonneeCumulee;
using sc2i.common;
using sc2i.win32.common;
using futurocom.snmp.HotelPolling;

namespace futurocom.win32.snmp.hotelpolling
{
    public partial class CFormEditeHotelPollingSetup : Form
    {
        public CFormEditeHotelPollingSetup()
        {
            InitializeComponent();
            CWin32Traducteur.Translate(this);
        }

        public static bool EditeSetup(CSnmpHotelPollingSetup setup,
            CAgentSnmpPourSupervision agent)
        {
            using (CFormEditeHotelPollingSetup frm = new CFormEditeHotelPollingSetup())
            {
                frm.m_panelSetup.Init(
                    setup,
                    agent);
                if (frm.ShowDialog() == DialogResult.OK)
                    return true;
                return false;
            }
        }

        private void m_btnOk_Click(object sender, EventArgs e)
        {
            CResultAErreur result = m_panelSetup.MajChamps();
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
            

    }
}
