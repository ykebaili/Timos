using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using timos.win32.composants;
using sc2i.common;
using sc2i.data;
using timos.data;
using sc2i.workflow;
using sc2i.win32.common;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;

namespace timos.acteurs
{
	public partial class CControlContact : UserControl, IControlALockEdition
	{
		public Form m_frmConteneur;
		public int m_largeurEtat;
		private CActeur m_acteur = null;
		private bool m_actif;

		//------------------------------------------------
		public CControlContact()
		{
			InitializeComponent();
			m_largeurOptimale = Width;
			m_hauteurOptimale = m_lblGabarit.Height; ;
		}

		//------------------------------------------------
		public void Init(CActeur acteur)
		{
			Init(acteur, null);
		}
		public void Init(CActeur acteur, CModeleTexte modeleUtilise)
		{
			m_acteur = acteur;
			//SuspendLayout();
			if (modeleUtilise == null)
			{
				m_lnkNomIntervenant.Visible = true;
				m_lnkActeur.Visible = false;
				m_modele.Visible = false;
				m_extLinkField.FillDialogFromObjet(m_acteur);
				m_largeurOptimale = 500;
			}
			else
			{
				m_lnkNomIntervenant.Visible = false;
				m_modele.Visible = true;
				m_modele.Init(modeleUtilise, acteur);
				m_lnkActeur.Visible = true;
				m_largeurOptimale = modeleUtilise.Largeur + m_panOccupation.Width + 6;
				m_hauteurOptimale = modeleUtilise.Hauteur;
			}
			Size = new Size(m_largeurOptimale, m_hauteurOptimale);


			{
				//On récupère la tranche de travail actuelle
				CTrancheHoraire[] tranches = m_acteur.GetHoraires(DateTime.Now, DateTime.Now);

				if (tranches.Length > 0)
				{
					CTrancheHoraire tranche = tranches[0];
					CTypeOccupationHoraire typeoccup = tranche.TypeOccupationHoraire;
					m_lblEtat.Text = typeoccup.Libelle;
					m_panOccupation.BackColor = Color.FromArgb(typeoccup.Couleur);
					m_actif = typeoccup.EstDisponible;

					if (m_frmConteneur != null)
						m_lblEtat.Click += new EventHandler(m_lblEtat_Click);
				}
				else
				{
					m_lblEtat.Text = I.T("Inactive|1305");
					m_panOccupation.BackColor = Color.Red;
					m_actif = false;
				}
			}
            //else
            //{
            //    m_lblEtat.Text = I.T("Missing information|1306");
            //    m_panOccupation.BackColor = Color.Red;
            //    m_actif = false;
            //}

			//Position du label Etat
			if (m_lblEtat.Width > m_largeurEtat)
			{
				m_panOccupation.Width = m_lblEtat.Width + 6;
				m_largeurEtat = m_panOccupation.Width;
			}
			else
			{
				//On centre
				m_panOccupation.Width = m_largeurEtat;
				int x = (m_largeurEtat - m_lblEtat.Width) / 2;
				m_lblEtat.Location = new Point(x, m_lblEtat.Location.Y);
			}


		}

		void m_lblEtat_Click(object sender, EventArgs e)
		{
			CFormFloatContactOccupation.Afficher(m_acteur, m_frmConteneur);
		}


		private int m_largeurOptimale;
		private int m_hauteurOptimale;

		public int LargeurOptimale
		{
			get	{ return m_largeurOptimale;	}
		}
		public int HauteurOptimale
		{
			get	{ return m_hauteurOptimale;	}
		}

		/// ////////////////////////////////////////
		public bool ActeurActif
		{
			get	{ return m_actif; }
		}


		private void m_lnkNomIntervenant_LinkClicked(object sender, EventArgs e)
		{
            //Type t = CFormFinder.GetTypeFormToEdit(typeof(CActeur));
            //if (typeof(IFormNavigable).IsAssignableFrom(t))
            //{
            //    IFormNavigable iformnav = (IFormNavigable)Activator.CreateInstance(t, new object[] { m_acteur });
            //    CTimosApp.Navigateur.AffichePage(iformnav);
            //}
            CReferenceTypeForm refTypeForm = CFormFinder.GetRefFormToEdit(typeof(CActeur));
            if (refTypeForm != null)
            {
                IFormNavigable iformnav = refTypeForm.GetForm(m_acteur) as IFormNavigable;
                if (iformnav != null)
                    CTimosApp.Navigateur.AffichePage(iformnav);
            }

		}

		//LockEdition
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

		private void m_lnkActeur_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
            //Type t = CFormFinder.GetTypeFormToEdit(typeof(CActeur));
            //if (typeof(IFormNavigable).IsAssignableFrom(t))
            //{
            //    IFormNavigable iformnav = (IFormNavigable)Activator.CreateInstance(t, new object[] { m_acteur });
            //    CTimosApp.Navigateur.AffichePage(iformnav);
            //}

            CReferenceTypeForm refTypeForm = CFormFinder.GetRefFormToEdit(typeof(CActeur));
            if (refTypeForm != null)
            {
                IFormNavigable iformnav = refTypeForm.GetForm(m_acteur) as IFormNavigable;
                if (iformnav != null)
                    CTimosApp.Navigateur.AffichePage(iformnav);
            }

		}

		
	}
}
