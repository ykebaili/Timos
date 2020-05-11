using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common;

namespace futurocom.win32.snmp.entitesnmp
{
    public partial class CPanelEditeEntitesDeAgent : UserControl, IControlALockEdition
    {
        public CPanelEditeEntitesDeAgent()
        {
            InitializeComponent();
        }

        //---------------------------------------------------
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

        //---------------------------------------------------
        public event EventHandler OnChangeLockEdition;
    }
}
