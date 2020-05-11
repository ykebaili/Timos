using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.data.navigation;
using timos.data.projet.besoin;
using sc2i.common;
using sc2i.win32.common;

namespace timos.projet.besoin
{
    public partial class CFormPhaseSpecificationsPopup : CFormToolPopup
    {
        private CPhaseSpecifications m_phase = null;

        //---------------------------------------------------------------
        public CFormPhaseSpecificationsPopup()
            :base()
        {
            InitializeComponent();
            m_picPhase.Image = DynamicClassAttribute.GetImage(typeof(CPhaseSpecifications));
            CWin32Traducteur.Translate(this);
        }

        //---------------------------------------------------------------
        public static void ShowPhase(CPhaseSpecifications phase)
        {
            if (phase != null && !phase.IsNew())
            {
                CFormPhaseSpecificationsPopup frm = new CFormPhaseSpecificationsPopup();
                phase = phase.GetObjetInContexte(sc2i.win32.data.CSc2iWin32DataClient.ContexteCourant) as CPhaseSpecifications;
                frm.m_phase = phase;
                frm.Text = phase.Libelle;
                frm.Show();
            }
        }

        //---------------------------------------------------------------
        private void CFormPhaseSpecificationsPopup_Load(object sender, EventArgs e)
        {
            AutoArrangeSize();
            m_wndListeBesoins.InterditCout();
            FillDialogFromPhase();
        }

        //---------------------------------------------------------------
        private void FillDialogFromPhase()
        {
            m_wndListeBesoins.Init(m_phase);
            m_lblPhase.Text = m_phase.Libelle;
        }

        //---------------------------------------------------------------
        private void m_btnEditPhase_LinkClicked(object sender, EventArgs e)
        {
            if (NavigateurAssocie != null)
                NavigateurAssocie.EditeElement(m_phase, false, "");
        }

        //---------------------------------------------------------------
        private void m_imageRefresh_Click(object sender, EventArgs e)
        {
            if (!m_phase.IsValide() || m_phase == null)
                Close();
            m_phase.Refresh();
            FillDialogFromPhase();
        }


    }
}
