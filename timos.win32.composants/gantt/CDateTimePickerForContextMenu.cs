using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.common;
using timos.win32.composants.Properties;
using sc2i.win32.common;

namespace timos.win32.composants
{
    public partial class CDateTimePickerForContextMenu : UserControl, IControlALockEdition
    {
        private DateTime m_date1 = DateTime.Now;
        private DateTime m_date2 = DateTime.Now;
        private static bool m_bLinkDates = true;
        private bool m_bBoutonValiderVisible = true;

        private bool m_bDisableChangeEvents = false;

        public CDateTimePickerForContextMenu()
        {
            InitializeComponent();
            UpdateLinkButton();
            m_btnValiderModifications.Visible = m_bBoutonValiderVisible;
        }

        //-----------------------------------------------------------------
        private void UpdateLinkButton()
        {
            if (m_bLinkDates)
                m_btnLinkDates.Image = Resources.chainefermee;
            else
                m_btnLinkDates.Image = Resources.chaineouverte;
        }

        //-----------------------------------------------------------------
        public bool BoutonValiderVisible
        {
            get
            {
                return m_bBoutonValiderVisible;
            }
            set
            {
                m_bBoutonValiderVisible = value;
                m_btnValiderModifications.Visible = value;
            }
        }

        //-----------------------------------------------------------------
        public string Libelle1
        {
            get
            {
                return m_label1.Text;
            }
            set
            {
                m_label1.Text = value;
            }
        }
                
        //-----------------------------------------------------------------
        public string Libelle2
        {
            get
            {
                return m_label2.Text;
            }
            set
            {
                m_label2.Text = value;
            }
        }

        //---------------------------
        public DateTime StartDate
        {
            get
            {
                return m_dtStart.Value;
            }
            set
            {
                m_bDisableChangeEvents = true;
                m_dtStart.Value = value;
                m_date1 = value;
                m_bDisableChangeEvents = false;
            }
        }

        //---------------------------
        public DateTime EndDate
        {
            get
            {
                return m_dtEnd.Value;
            }
            set
            {
                m_bDisableChangeEvents = true;
                m_dtEnd.Value = value;
                m_date2 = value;
                m_bDisableChangeEvents = false;
            }
        }


        private void m_dtStart_OnValueChange(object sender, EventArgs e)
        {
            if (!m_bDisableChangeEvents && m_bLinkDates)
            {
                m_bDisableChangeEvents = true;
                TimeSpan sp = m_date2 - m_date1;
                m_dtEnd.Value = m_dtStart.Value.Add(sp);
                m_bDisableChangeEvents = false;
            }
            m_date1 = m_dtStart.Value;
            m_btnValiderModifications.Visible = m_bBoutonValiderVisible &&  m_date2 >= m_date1;
        }

        private void m_dtEnd_ValueChanged(object sender, EventArgs e)
        {
            if (!m_bDisableChangeEvents && m_bLinkDates)
            {
                m_bDisableChangeEvents = true;
                TimeSpan sp = m_date1 - m_date2;
                m_dtStart.Value = m_dtEnd.Value.Add(sp);
                m_bDisableChangeEvents = false;
            }
            m_date2 = m_dtEnd.Value;
            m_btnValiderModifications.Visible = m_bBoutonValiderVisible && m_date2 >= m_date1;
        }

        private void m_btnLinkDates_Click(object sender, EventArgs e)
        {
            m_bLinkDates = !m_bLinkDates;
            UpdateLinkButton();
        }

        public event EventHandler OnValideDates;

        private void m_btnValiderModifications_Click(object sender, EventArgs e)
        {
            if (OnValideDates != null)
                OnValideDates(this, new EventArgs());
        }

        private void CDateTimePickerForContextMenu_Load(object sender, EventArgs e)
        {
            if (m_dtStart.IsHandleCreated)
            {
                m_dtStart.Value = m_date1;
                m_dtEnd.Value = m_date2;
            }
            
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
    }
}
