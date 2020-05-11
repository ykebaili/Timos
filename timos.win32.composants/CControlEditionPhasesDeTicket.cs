using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using sc2i.win32.common;
using sc2i.drawing;

using timos.data;

namespace timos.win32.composants
{


	public class CControlEditionPhasesDeTicket : sc2i.win32.common.CPanelEditionObjetGraphique
	{
		#region Code généré par le concepteur
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
				if (m_customCursor != null && m_customCursor != Cursors.Arrow)
					m_customCursor.Dispose();
				m_customCursor = null;
			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			sc2i.win32.common.CProfilEditeurObjetGraphique cProfilEditeurObjetGraphique2 = new sc2i.win32.common.CProfilEditeurObjetGraphique();
			sc2i.win32.common.CGrilleEditeurObjetGraphique cGrilleEditeurObjetGraphique2 = new sc2i.win32.common.CGrilleEditeurObjetGraphique();
			this.SuspendLayout();
			// 
			// CControlEditionPhasesDeTicket
			// 
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.White;
			this.ModeRepresentationGrille = sc2i.win32.common.ERepresentationGrille.LignesContinues;
			this.Name = "CControlEditionPhasesDeTicket";
			cProfilEditeurObjetGraphique2.FormeDesPoignees = sc2i.win32.common.EFormePoignee.Carre;
			cGrilleEditeurObjetGraphique2.Couleur = System.Drawing.Color.LightGray;
			cGrilleEditeurObjetGraphique2.HauteurCarreau = 20;
			cGrilleEditeurObjetGraphique2.LargeurCarreau = 20;
			cGrilleEditeurObjetGraphique2.Representation = sc2i.win32.common.ERepresentationGrille.LignesContinues;
			cGrilleEditeurObjetGraphique2.TailleCarreau = new System.Drawing.Size(20, 20);
			cProfilEditeurObjetGraphique2.Grille = cGrilleEditeurObjetGraphique2;
			cProfilEditeurObjetGraphique2.HistorisationActive = true;
			cProfilEditeurObjetGraphique2.Marge = 10;
			cProfilEditeurObjetGraphique2.ModeAffichageGrille = sc2i.win32.common.EModeAffichageGrille.AuDeplacement;
			cProfilEditeurObjetGraphique2.NombreHistorisation = 10;
			cProfilEditeurObjetGraphique2.ToujoursAlignerSurLaGrille = false;
			this.Profil = cProfilEditeurObjetGraphique2;
			this.ToujoursAlignerSurLaGrille = false;
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CControlEditionPhasesDeTicket_MouseUp);
			this.BeforeDeleteElement += new sc2i.win32.common.EventHandlerPanelEditionGraphiqueSuppression(this.CControlEditionPhasesDeTicket_BeforeDeleteElement);
			this.ResumeLayout(false);

		}
		#endregion
		//Lorsqu'on est en mode lien2 : contient l'action départ du lien
		private CWndTypeTypeTicket_TypePhase m_typePhaseDebutLien = null;

		private CTypePhase m_typePhaseEnCreation = null;

		private EModeEditeurPhaseTicket m_modeEnCours = EModeEditeurPhaseTicket.Selection;
		private Cursor m_customCursor = null;

		public CControlEditionPhasesDeTicket()
		{
			InitializeComponent();
		}
		
		public event EventHandler AfterModeEditionChanged;
		public override bool MNU_DeleteShow()
		{
			return Selection.Count > 0 && !Selection.Contains(ObjetEdite);
		}
		/// ////////////////////////////////////////////////////////////////
		public EModeEditeurPhaseTicket ModeEdition
		{
			get
			{
				return m_modeEnCours;
			}
			set
			{
				if ( m_modeEnCours != value )
				{
					if (LockEdition)
						m_modeEnCours = EModeEditeurPhaseTicket.Selection;
					else
						m_modeEnCours = value;
                    if (m_modeEnCours == EModeEditeurPhaseTicket.Selection)
                        ModeSouris = EModeSouris.Selection;
                    else
                        ModeSouris = EModeSouris.Custom;

					LoadCurseurAdaptéPhaseTicket();
					
					if ( AfterModeEditionChanged != null )
						AfterModeEditionChanged ( this, new EventArgs() );
				}
			}
		}

		public CTypePhase TypePhaseEnCreation
		{
			get
			{
				return m_typePhaseEnCreation;
			}
			set
			{
				m_typePhaseEnCreation = value;
			}
			}


		/// //////////////////////////////////////////
        private void LoadCurseurAdaptéPhaseTicket()
		{
			if ( m_customCursor != null && m_customCursor!= Cursors.Arrow)
				m_customCursor.Dispose();
			m_customCursor = null;
			switch ( ModeEdition )
			{
				case EModeEditeurPhaseTicket.Phase:
					m_customCursor = new Cursor ( GetType(), "curAction.cur");
					break;
				case EModeEditeurPhaseTicket.Lien1:
					m_customCursor = new Cursor ( GetType(), "curLien1.cur");
					break;
				case EModeEditeurPhaseTicket.Lien2:
					m_customCursor = new Cursor ( GetType(), "curLien2.cur");
					break;
				default :
					m_customCursor = Cursors.Arrow;
					break;
			}
			Cursor = m_customCursor;
		}

		/// ////////////////////////////////////////////////////////////////
		public event EventHandler AfterAddElementToTypePhase;

		/// ////////////////////////////////////////////////////////////////
		private void CControlEditionPhasesDeTicket_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Point ptSouris = GetLogicalPointFromDisplay ( new Point (e.X, e.Y ) );
			CWndTypeTypeTicket_TypePhase wndNouvellePhase = null;
			switch ( ModeEdition )
			{
				case EModeEditeurPhaseTicket.Phase:
					if (TypePhaseEnCreation != null)
					{
						CTypeTicket_TypePhase nouvellePhase;
						nouvellePhase = new CTypeTicket_TypePhase(WndTypeTicketEdite.TypeTicket.ContexteDonnee);
						nouvellePhase.CreateNewInCurrentContexte();
						nouvellePhase.TypeTicket = WndTypeTicketEdite.TypeTicket;
						nouvellePhase.TypePhase = TypePhaseEnCreation;
						wndNouvellePhase = new CWndTypeTypeTicket_TypePhase(nouvellePhase);
						WndTypeTicketEdite.AddChild(wndNouvellePhase);
						RefreshSelectionChanged = false;
						Selection.Clear();
						RefreshSelectionChanged = true;
						Selection.Add(wndNouvellePhase);
					}
					break;
				case EModeEditeurPhaseTicket.Lien1:
					m_typePhaseDebutLien = WndTypeTicketEdite.GetTypePhaseFromPoint ( ptSouris );
					
					if ( m_typePhaseDebutLien != null )
					{
						ModeEdition = EModeEditeurPhaseTicket.Lien2;
					}
					break;
				case EModeEditeurPhaseTicket.Lien2:
					ModeEdition = EModeEditeurPhaseTicket.Lien1;
					CWndTypeTypeTicket_TypePhase phase = WndTypeTicketEdite.GetTypePhaseFromPoint(ptSouris);
					bool bCreer = true;
					if ( phase != null && phase != m_typePhaseDebutLien )
					{
						//Vérifie qu'il n'y a pas déjà un lien
						foreach (I2iObjetGraphique objet in ObjetEdite.Childs)
						{
							if (objet is CWndLienTypePhase_TypePhase)
							{
								CWndLienTypePhase_TypePhase wndLien = (CWndLienTypePhase_TypePhase)objet;
								if (wndLien.TypePhaseArrivee == m_typePhaseDebutLien &&
									wndLien.TypePhaseDepart == phase ||
									wndLien.TypePhaseArrivee == phase &&
									wndLien.TypePhaseDepart == m_typePhaseDebutLien)
									bCreer = false;
									break;
							}
						}
						if (bCreer)
						{

							CLienTypePhase lien = new CLienTypePhase(WndTypeTicketEdite.TypeTicket.ContexteDonnee);
							lien.CreateNewInCurrentContexte();
							lien.FromTypePhase = m_typePhaseDebutLien.TypeTicket_TypePhase;
							lien.ToTypePhase = phase.TypeTicket_TypePhase;

							CWndLienTypePhase_TypePhase wndLien = new CWndLienTypePhase_TypePhase();
							wndLien.Lien = lien;
							wndLien.TypePhaseDepart = m_typePhaseDebutLien;
							wndLien.TypePhaseArrivee = phase;
							WndTypeTicketEdite.AddChild(wndLien);
							RefreshSelectionChanged = true;
							Selection.Clear();
							RefreshSelectionChanged = false;
							Selection.Add(wndNouvellePhase);
							ModeEdition = EModeEditeurPhaseTicket.Lien1;
						}
					}
					break;
			}
			if ( wndNouvellePhase != null )
			{
				Point pt = new Point ( ptSouris.X-wndNouvellePhase.Size.Width/2, ptSouris.Y - wndNouvellePhase.Size.Height/2);
				wndNouvellePhase.Position = pt;
				ModeEdition = EModeEditeurPhaseTicket.Selection;
				RefreshSelectionChanged = false;
				Selection.Clear();
				RefreshSelectionChanged = true;
				Selection.Add ( wndNouvellePhase );
				if ( AfterAddElementToTypePhase != null )
					AfterAddElementToTypePhase(this, new EventArgs());
			}
		}

		/// //////////////////////////////////////////
		public CWndTypeTicket WndTypeTicketEdite
		{
			get
			{
				return (CWndTypeTicket)ObjetEdite;
			}
			set
			{
				ObjetEdite = value;
				if ( value != null )
					this.AutoScrollMinSize = value.Size;
			}
		}

		private bool CControlEditionPhasesDeTicket_BeforeDeleteElement(List<I2iObjetGraphique> objs)
		{
			for (int n = objs.Count; n > 0; n--)
			{
				I2iObjetGraphique ele = objs[n - 1];
				Type tp = typeof(CWndLienTypePhase_TypePhase);
				if (ele.IsLock && !tp.IsAssignableFrom(ele.GetType()))
					objs.RemoveAt(n - 1);
			}

			return true;
		}
	}

	public enum EModeEditeurPhaseTicket
	{
		Selection,
		Phase,
		Lien1,
		Lien2
	}
}

