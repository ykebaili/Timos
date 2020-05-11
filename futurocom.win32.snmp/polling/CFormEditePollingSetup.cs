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

namespace futurocom.win32.snmp.polling
{
    public partial class CFormEditePollingSetup : Form
    {
        public CFormEditePollingSetup()
        {
            InitializeComponent();
            CWin32Traducteur.Translate(this);
        }

        public static bool EditeSetup(CSnmpPollingSetup setup,
            CAgentSnmpPourSupervision agent,
            IEnumerable<ITypeDonneeCumulee> lstTypesDonnees)
        {
            using (CFormEditePollingSetup frm = new CFormEditePollingSetup())
            {
                frm.m_panelSetup.Init(setup,
                    agent,
                    lstTypesDonnees);
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
