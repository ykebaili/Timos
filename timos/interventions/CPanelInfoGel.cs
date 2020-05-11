using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using sc2i.win32.common;
using sc2i.common;
using sc2i.data;

using timos.data;
using sc2i.process.workflow.gels;

namespace timos.interventions
{
	public partial class CPanelInfoGel : UserControl, IControlALockEdition
	{
		private IElementGelable m_elementGelable = null;
        public event EventHandler OnChangeEtatGel = null;

		public CPanelInfoGel()
		{
			InitializeComponent();
		}


        void CPanelInfoGel_Load(object sender, System.EventArgs e)
        {
            CWin32Traducteur.Translate(this);
        }

		//-------------------------------------------------------------------------
		public void Init(IElementGelable element)
		{
			if (element == null)
			{
				Visible = false;
				return;
			}
			m_elementGelable = element;
			Visible = true;
			if (element is CIntervention)
			{
                m_lnkGeler.Text = I.T( "Freeze Intervention|608");
				m_lnkDegeler.Text = I.T( "Unfreeze Intervention|607");
			}
			if ( element is CPhaseTicket )
			{
				m_lnkGeler.Text = I.T( "Freeze Ticket|669");
				m_lnkDegeler.Text = I.T( "Unfreeze Ticket|668");
			}
			m_lnkDegeler.Visible = element.EstGelee;
			m_lnkGeler.Visible = !element.EstGelee;
            
            // Affiche les Gels de toutes les Phases de tous les Tickets
            InitListeGels();

            AfficheInfosGels();
		}

        //-------------------------------------------------------------------------
        private void InitListeGels()
        {
            if (m_elementGelable == null)
                return;

            CPhaseTicket phaseEnCours = m_elementGelable as CPhaseTicket;
            if (phaseEnCours != null && !m_chkAfficherQueLaPhaseEnCours.Checked)
            {
                CListeObjetsDonnees listeGels = new CListeObjetsDonnees(phaseEnCours.ContexteDonnee, typeof(CGel));
                // Va chercher tous les gels de toutes les phases du Ticket 
                //listeGels.Filtre = new CFiltreDataAvance(CGel.c_nomTable,
                //    CPhaseTicket.c_nomTable + "."+
                //    CTicket.c_champId + "= @1",
                //    phaseEnCours.Ticket.Id);
                //List<CGel> listeSource = listeGels.ToList<CGel>();
                List<CGel> listeSource = new List<CGel>();
                // Ajoute les éventuels nouveaux gels qui sont pas encore dans la base
                foreach (CPhaseTicket phase in phaseEnCours.Ticket.PhasesListe)
                {
                    foreach (CGel gel in phase.Gels)
                    {
                        //if (!listeSource.Contains(gel))
                            listeSource.Add(gel);
                    }
                }
                m_wndListeGels.ListeSource = listeSource;
            }
            else
            {
                m_wndListeGels.ListeSource = m_elementGelable.Gels;
            }
            m_wndListeGels.Refresh();
        }
		
		//-------------------------------------------------------------------------
		private void m_wndListeGels_OnChangeSelection(object sender, EventArgs e)
		{
			AfficheInfosGels();
		}

		//-------------------------------------------------------------------------
		private void AfficheInfosGels()
		{
            if (m_wndListeGels.SelectedItems.Count != 1)
            {
                m_panelInfoGel.Visible = false;
                return;
            }
			CGel gel = (CGel)m_wndListeGels.SelectedItems[0];
			m_panelInfoGel.Visible = true;
			m_lnkStart.Text = gel.DateDebut.ToString("g");
			int nXLblDate = m_lnkStart.Location.X + m_lnkStart.Width;
			m_lblDatesGel.Location = new Point(nXLblDate, m_lblDatesGel.Location.Y);
			if (gel.DateFin == null)
			{
				m_lblDatesGel.Text = "... " + I.T("ongoing|61");
				m_lnkEndDate.Visible = false;
			}
			else
			{
				m_lnkEndDate.Visible = true;
				m_lblDatesGel.Text = I.T("to|62");
				int nXEndDate = m_lblDatesGel.Location.X + m_lblDatesGel.Width;
				m_lnkEndDate.Location = new Point(nXEndDate, m_lnkEndDate.Location.Y);
				m_lnkEndDate.Text = ((DateTime)gel.DateFin).ToString("g");
			}
			m_lblInfoDebutGel.Text = gel.InfosDebutGel;
			m_tooltip.SetToolTip(m_lblInfoDebutGel, gel.InfosDebutGel);
			m_lblInfoFinGel.Text = gel.InfosFinGel;
			m_tooltip.SetToolTip(m_lblInfoFinGel, gel.InfosFinGel);
            if(gel.CauseGel != null)
                m_lblFrezingCause.Text = gel.CauseGel.Libelle;

		}

		//----------------------------------------------------------------------------
		private void OnChangeGel(object sender, EventArgs args)
		{
			try
			{
				Init(m_elementGelable);
                if (OnChangeEtatGel != null)
                    OnChangeEtatGel(this, new EventArgs());
			}
			catch { }
		}

        //----------------------------------------------------------------------------
        #region IControlALockEdition Membres

		public bool LockEdition
		{
			get
			{
				return !m_gestionnaireModeEdition.ModeEdition;
			}
			set
			{
				m_gestionnaireModeEdition.ModeEdition = !value;
				if (OnChangeLockEdition != null)
					OnChangeLockEdition(this, new EventArgs());
			}
		}

		public event EventHandler OnChangeLockEdition;

		#endregion

       //-----------------------------------------------------------------------------
        private void m_lnkGeler_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
            CFormGelerIntervention.Geler(m_elementGelable, new EventHandler(OnChangeGel));
		}


        //--------------------------------------------------------
        private void m_lnkDegeler_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CFormGelerIntervention.Degeler(m_elementGelable, new EventHandler(OnChangeGel));
        }

        //--------------------------------------------------------
        private void m_lnkStart_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CFormGelerIntervention.ModificationGeler((CGel)m_wndListeGels.SelectedItems[0], new EventHandler(OnChangeGel));

		}

        //--------------------------------------------------------
        private void m_lnkEndDate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CFormGelerIntervention.ModificationDegeler((CGel)m_wndListeGels.SelectedItems[0], new EventHandler(OnChangeGel));

		}

        //--------------------------------------------------------
        private void m_chkAfficherQueLaPhaseEnCours_CheckedChanged(object sender, EventArgs e)
        {
            InitListeGels();
        }
	}
}
