using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using futurocom.snmp.entitesnmp;

namespace futurocom.win32.snmp.entitesnmp
{
    public partial class CPanelEditeEntiteDeAgent : UserControl
    {
        private CEntiteSnmpPourSupervision m_entite = null;
        public CPanelEditeEntiteDeAgent()
        {
            InitializeComponent();
        }

        public void Init(CEntiteSnmpPourSupervision entite)
        {
        }
    }
}
