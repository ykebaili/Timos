using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using sc2i.common;
using sc2i.data;
using timos.data;
using sc2i.workflow;
using sc2i.win32.common;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;

namespace timos.acteurs
{
	public partial class CControlProfilsDeElementAContacts : UserControl, IControlALockEdition
	{
		public Form m_frmConteneur;

		public event EventHandler ChangementTailleAffichage;
		

		private CActeursSelonProfil m_acteursSelonProf = null;
		private IElementAContacts m_elemactc = null;
		private List<CActeur> m_acteurs;
		private bool m_bAfficherInactif;
		private int m_nInactifs;
		private int m_nHauteurControl;



		//------------------------------------------------
		public CControlProfilsDeElementAContacts()
		{
			InitializeComponent();
			m_acteurs = new List<CActeur>();
			m_largeurOptimale = m_panTypeProfil.Width;
			m_hauteurOptimale = m_panTypeProfil.Height;

		}

		//------------------------------------------------
		public void Init(CActeursSelonProfil acteursSelonProf, IElementAContacts elemactc)
		{
			m_elemactc = elemactc;
			m_acteursSelonProf = acteursSelonProf;
			m_bAfficherInactif = false;
			m_chkAfficherInnActif.Checked = false;

			m_lnkProfilIntervenant.Text = m_acteursSelonProf.Profil.Libelle;

			//On récupère les acteurs associés à ce profil en prenant également les innactifs
			m_acteurs = m_acteursSelonProf.GetActeurs(m_elemactc, true);

			//On trie les acteurs par rapport à leur occupation actuelle
            //m_acteurs.Sort(new CActeur_OccupationActuelleComparer());

			//On récupère le modèle si il existe
			CModeleTexte modeleUtilise = acteursSelonProf.TypeElementAActeursPossibles.ModeleTexteContacts;
			
			//On ne prends que les acteurs qui travaillent actuellement
			int pos = 0;
			m_nInactifs = 0;
			int largeurEtat = 10;

			foreach (CActeur acteur in m_acteurs)
			{
				CControlContact ctrl = new CControlContact();
				ctrl.m_largeurEtat = largeurEtat;
				if (m_frmConteneur != null)
					ctrl.m_frmConteneur = m_frmConteneur;

				ctrl.Init(acteur, modeleUtilise);
				largeurEtat = ctrl.m_largeurEtat;
				
				m_nHauteurControl = ctrl.HauteurOptimale;

				if (ctrl.LargeurOptimale > m_largeurOptimale)
				{
					m_largeurOptimale = ctrl.LargeurOptimale + 4;
					m_hauteurOptimale += ctrl.HauteurOptimale;
				}
				else
					m_hauteurOptimale += ctrl.HauteurOptimale;

				m_panIntervenants.Controls.Add(ctrl);
				ctrl.TabIndex = pos;
				ctrl.Dock = DockStyle.Top;
				ctrl.BringToFront();

				if (!ctrl.ActeurActif)
				{
					m_hauteurOptimale -= ctrl.HauteurOptimale;
					m_nInactifs++;
					ctrl.Visible = false;
				}
			}
			m_hauteurOptimale -= 2; //marge
			Size = new Size(m_largeurOptimale, m_hauteurOptimale);

		}


		private int m_largeurOptimale;
		private int m_hauteurOptimale;

		public int LargeurOptimale
		{
			get	{ return m_largeurOptimale; }
		}
		public int HauteurOptimale
		{
			get	{ return m_hauteurOptimale;	}
		}

		public bool AfficheInactif
		{
			get { return m_bAfficherInactif; }
			set	{ AfficherActeursInactifs(value); }
		}

		private void AfficherActeursInactifs(bool etat)
		{
			m_panIntervenants.SuspendDrawing();
			if (etat)
			{
				m_bAfficherInactif = true;
				foreach (Control ctrl in m_panIntervenants.Controls)
				{
					if (ctrl is CControlContact)
					{
						CControlContact ctrlInter = (CControlContact)ctrl;
						if (!ctrlInter.ActeurActif)
							ctrlInter.Visible = true;
					}
				}

				m_hauteurOptimale += (m_nInactifs * m_nHauteurControl);
				m_hauteurOptimale += 2; //Marge

				Size = new Size(m_largeurOptimale, m_hauteurOptimale);
                if(ChangementTailleAffichage != null)
				    ChangementTailleAffichage(this, new EventArgs());
			}
			else
			{
				m_bAfficherInactif = false;
				foreach (Control ctrl in m_panIntervenants.Controls)
				{
					if (ctrl is CControlContact)
					{
						CControlContact ctrlInter = (CControlContact)ctrl;
						if (!ctrlInter.ActeurActif)
							ctrlInter.Visible = false;
					}
					
				}

				m_hauteurOptimale -= (m_nInactifs * m_nHauteurControl);
				m_hauteurOptimale -= 2; //Marge

				Size = new Size(m_largeurOptimale, m_hauteurOptimale);
                if (ChangementTailleAffichage != null)
                    ChangementTailleAffichage(this, new EventArgs());
			}
			m_panIntervenants.ResumeDrawing();
		}

		public int NbActeurs
		{
			get
			{
				return m_acteurs.Count;
			}
		}

		private void m_chkAfficherInnActif_CheckedChanged(object sender, EventArgs e)
		{
			AfficheInactif = m_chkAfficherInnActif.Checked;
		}


		private void m_lnkProfilIntervenant_LinkClicked(object sender, EventArgs e)
		{
			CProfilElement prof = m_acteursSelonProf.Profil;
            //Type t = CFormFinder.GetTypeFormToEdit(typeof(CProfilElement));
            //if (typeof(IFormNavigable).IsAssignableFrom(t))
            //{
            //    IFormNavigable iformnav = (IFormNavigable)Activator.CreateInstance(t, new object[] { prof });
            //    CTimosApp.Navigateur.AffichePage(iformnav);
            //}
            CReferenceTypeForm refTypeForm = CFormFinder.GetRefFormToEdit(typeof(CProfilElement));
            if (refTypeForm != null)
            {
                IFormNavigable iformnav = refTypeForm.GetForm(prof) as IFormNavigable;
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

				//Si on passe en edition
				if (m_gestionnaireModeEdition.ModeEdition)
				{

				}
				else
				{

				}


			}
		}
		public event EventHandler OnChangeLockEdition;

        //-----------------------------------------------------------------------------------
        private void CControlProfilsDeElementAContacts_Load(object sender, EventArgs e)
        {
           sc2i.win32.common.CWin32Traducteur.Translate(this);
        }


	
	}

    
	
}
