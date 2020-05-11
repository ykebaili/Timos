using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using sc2i.common;
using sc2i.expression;
using sc2i.data.dynamic;
using sc2i.win32.common;

using timos.data;
using timos.data.projet.gantt;
using timos.data.projet.gantt.icones;
using timos.data.projet.Contraintes;
using futurocom.snmp.Proxy;
using futurocom.snmp;

namespace timos.snmp
{
    public partial class CControlEditionPlageIP : UserControl, IControlALockEdition
    {
        private CPlageIP m_plageIP;

        public CControlEditionPlageIP()
        {
            InitializeComponent();
        }

        public CPlageIP PlageIP
        {
            get
            {
                return m_plageIP;
            }
        }

        //-------------------------------------------------------------------------
        public void Init(CPlageIP plage)
        {
            m_plageIP = plage;

            if (m_plageIP != null)
            {
                m_txtModeleIP.Text = m_plageIP.ModeleIpString;
                m_numMask.IntValue = m_plageIP.Mask;
            }
        }

        //-------------------------------------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;

            if (m_plageIP != null)
            {
                if (IP.IsValidIP(m_txtModeleIP.Text))
                {
                    m_plageIP.Mask = m_numMask.IntValue;
                    m_plageIP.ModeleIpString = m_txtModeleIP.Text;
                }
                else
                {
                    result.EmpileErreur(I.T("Invalid IP Address format: @1|10204", m_txtModeleIP.Text));
                }
            }
            return result;
        }
        

        #region IControlALockEdition Membres

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

        public event EventHandler OnChangeLockEdition;

        #endregion

        //---------------------------------------------------------------------
        public event EventHandler DeletePlageEventHandler;
        private void m_lnkDelete_LinkClicked(object sender, EventArgs e)
        {
            if (DeletePlageEventHandler != null)
                DeletePlageEventHandler(this, new EventArgs());
        }

        private void m_txtModeleIP_TextChanged(object sender, EventArgs e)
        {
            C2iTextBox txtBox = sender as C2iTextBox;
            if (txtBox != null)
            {
                if (IP.IsValidIP(txtBox.Text))
                    m_errorProvider.SetError(txtBox, "");
                else
                    m_errorProvider.SetError(txtBox, I.T("Invalid IP Address format: @1|10204", txtBox.Text));
            }

        }
    }
}
