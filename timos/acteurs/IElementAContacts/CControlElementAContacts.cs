using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using sc2i.common;
using sc2i.data;

using timos.data;
using sc2i.win32.common;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;

namespace timos.acteurs
{
	public partial class CControlElementAContacts : UserControl, IControlALockEdition
	{
		public Form m_frmConteneur;

		private bool m_bInitialise = false;
		//public event EventHandler ChangementTailleControlFils;
		public event EventHandler ChangementTailleAffichage;

		private string m_Err = "";
		private bool m_bRien = false;
		private IElementAContacts m_elemactc;
		private List<CActeursSelonProfil> m_lstProfilsActeurs;
		private int m_nbActeurs;

		//------------------------------------------------
		public CControlElementAContacts()
		{
			InitializeComponent();
			m_largeurOptimale = m_panTitre.Width;
			m_hauteurOptimale = m_panTitre.Height;
		}

		//------------------------------------------------
		public void Init(IElementAContacts elemactc)
		{
			m_elemactc = elemactc;

			m_bInitialise = false;
			m_bRien = false;

			//On récupère les Profils retournat les acteurs
			m_lstProfilsActeurs = new List<CActeursSelonProfil>();
			m_lstProfilsActeurs = m_elemactc.TypeElementAContactPossible.ProfilsContacts;

			//On les ordonnes
			CActeursSelonProfilPositionComparer comparer = new CActeursSelonProfilPositionComparer();
			m_lstProfilsActeurs.Sort(comparer);

			//On créé les controles pour les afficher
			int pos = 0;
			m_nbActeurs = 0;
			m_hauteurOptimale = m_panTitre.Height;
			foreach (CActeursSelonProfil acteurSelonProf in m_lstProfilsActeurs)
			{
				CControlProfilsDeElementAContacts ctrl = new CControlProfilsDeElementAContacts();
				if (m_frmConteneur != null)
					ctrl.m_frmConteneur = m_frmConteneur;

				ctrl.Init(acteurSelonProf, m_elemactc);

				//m_largeurOptimale = Math.Min(Math.Max(ctrl.LargeurOptimale + 4, m_largeurOptimale),400);
				m_largeurOptimale = ctrl.LargeurOptimale;

				

				//Si il n'y a pas d'acteur on n'affiche pas le controles
				if (ctrl.NbActeurs > 0)
				{
					m_nbActeurs += ctrl.NbActeurs;
					m_hauteurOptimale += ctrl.HauteurOptimale;
					ctrl.ChangementTailleAffichage += new EventHandler(CControlContactsPhase_ChangementTailleControlFils);

					m_panControles.Controls.Add(ctrl);

					ctrl.TabIndex = pos;
					ctrl.Dock = DockStyle.Top;
					ctrl.BringToFront();
					pos++;

				}
			}

			m_hauteurOptimale = Math.Min(m_hauteurOptimale, 350);
			m_panControles.Height = m_hauteurOptimale - m_panTitre.Height;

			Size = new Size(m_largeurOptimale, Math.Min(m_hauteurOptimale,350));

			if (m_nbActeurs == 0)
			{
				m_Err = I.T("There is no available contacts|1261");
				m_lblTitre.Text = m_Err;
				m_lblTitre.Dock = DockStyle.Fill;
				m_bRien = true;
			}
			else
			{
				m_lblTitre.Dock = DockStyle.None;
				
			}
			m_bInitialise = true;

		}


		private int m_largeurOptimale;
		private int m_hauteurOptimale;

		public int LargeurOptimale
		{
			get { return m_largeurOptimale; }
		}
		public int HauteurOptimale
		{
			get { return m_hauteurOptimale; }
		}

		public string MessageErreur
		{
			get { return m_Err; }
		}
		public bool RienAAfficher
		{
			get { return m_bRien; }
		}

		void CControlContactsPhase_ChangementTailleControlFils(object sender, EventArgs e)
		{
			if (m_bInitialise)
			{
				m_panControles.SuspendDrawing();
				//RAZ Hauteur
				m_hauteurOptimale = m_panTitre.Height;
				foreach (Control ctrl in m_panControles.Controls)
				{
					if (ctrl is CControlProfilsDeElementAContacts)
					{
						CControlProfilsDeElementAContacts ctrlActeurSelonProf = (CControlProfilsDeElementAContacts)ctrl;
						m_hauteurOptimale += ctrlActeurSelonProf.HauteurOptimale;
					}
				}

				m_hauteurOptimale += 2; //Marge

				if (m_hauteurOptimale > 350)
					m_hauteurOptimale = 350;


				Size = new Size(m_largeurOptimale, m_hauteurOptimale);
				m_panControles.Height += m_hauteurOptimale - m_panTitre.Height;
                if (ChangementTailleAffichage != null)
                    ChangementTailleAffichage(this, new EventArgs());
				m_panControles.ResumeDrawing();
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

        //----------------------------------------------------------------------------------
        private void CControlElementAContacts_Load(object sender, EventArgs e)
        {
            sc2i.win32.common.CWin32Traducteur.Translate(this);
        }




	}
}
