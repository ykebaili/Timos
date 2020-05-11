using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimosInventory
{
    public partial class CControlPresence : UserControl
    {
        private bool? m_bValue = null;
        public CControlPresence()
        {
            InitializeComponent();
        }


        private bool m_bIsSettingValue = false;
        public bool? Value
        {
            get
            {
                return m_bValue;
            }
            set
            {
                m_bValue = value;
                m_bIsSettingValue = true;
                m_chkPresent.Checked = value == true;
                m_chkAbsent.Checked = value == false;
                m_bIsSettingValue = false;
            }
        }

        //-----------------------------------------------------------------------
        public event EventHandler ValueChanged;

        //-----------------------------------------------------------------------
        private void m_chkPresent_CheckedChanged(object sender, EventArgs e)
        {
            if (!m_bIsSettingValue)
            {
                if (m_chkAbsent.Checked)
                    Value = false;
                else
                {
                    if (m_chkPresent.Checked)
                        Value = true;
                    else
                        Value = null;
                    if (ValueChanged != null)
                        ValueChanged(this, null);
                }
            }
        }

        //-----------------------------------------------------------------------
        private void m_chkAbsent_CheckedChanged(object sender, EventArgs e)
        {
            if (!m_bIsSettingValue)
            {
                if (m_chkPresent.Checked)
                    Value = true;
                else
                {
                    if (m_chkAbsent.Checked)
                        Value = false;
                    else
                        Value = null;
                    if (ValueChanged != null)
                        ValueChanged(this, null);
                }
            }
        }
    }
}
