using System;
using System.Resources;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

using sc2i.data;
using sc2i.win32.data.navigation;
using sc2i.win32.common;
using sc2i.drawing;

using timos.data;

namespace timos
{

	public class CControlEditionProjet : CPanelEditionObjetGraphique
	{
		#region Code généré par le concepteur


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
			this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
			this.SuspendLayout();
			// 
			// CControlEditionProjet
			// 
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.White;
			this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
			this.Name = "CControlEditionProjet";
			this.DoubleClicSurElement += new EventHandler(this.CControlEditionProjet_DoubleClicSurElement);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CControlEdition_MouseUp);
			this.BeforeDeleteElement += new EventHandlerPanelEditionGraphiqueSuppression(CControlEditionProjet_BeforeDeleteElement);
			this.ResumeLayout(false);

		}

		private bool CControlEditionProjet_BeforeDeleteElement(List<I2iObjetGraphique> objs)
		{
			for (int n = objs.Count; n > 0; n--)
			{
				I2iObjetGraphique ele = objs[n - 1];
				if (ele.IsLock && ele.GetType() != typeof(CWndLienDeProjet))
					objs.RemoveAt(n - 1);
			}

			return true;
		}
		public override bool MNU_DeleteShow()
		{
			return Selection.Count > 0 && !Selection.Contains(ObjetEdite);
		}
		private System.ComponentModel.IContainer components = null;

		#endregion


		private IWndElementDeProjetPlanifiable m_eleDebutLien = null;
		private bool m_bModeCreation = true;

		private EModeEditeurProjet m_modeEnCours = EModeEditeurProjet.Selection;
		private Cursor m_customCursor = null;
		private CExtModeEdition m_extModeEdition;

		public CControlEditionProjet()
		{
			InitializeComponent();
		}

		private void CControlEditionProjet_DoubleClicSurElement(object sender, EventArgs e)
		{
			if (AfterDoubleClicElement != null)
			{
				I2iObjetGraphique o = Selection.ControlReference;
				if (o != null)
					AfterDoubleClicElement(o);
			}
		}

		
		/// ////////////////////////////////////////////////////////////////
		public event EventHandler AfterModeEditionChanged;

		public event EventHandlerAnnulable BeforeAddElement;
		public event EventHandlerForIElementDeProjet AfterAddElement;

		public event EventHandlerAnnulable BeforeUnselectElement;

		public event EventHandlerAnnulable BeforeSelectElement;
		public event EventHandlerForIElementDeProjet AfterSelectElement;

		public event EventHandlerForIElementDeProjet AfterDoubleClicElement;

		/// ////////////////////////////////////////////////////////////////
		public EModeEditeurProjet ModeEdition
		{
			get
			{
				return m_modeEnCours;
			}
			set
			{
				if ( m_modeEnCours != value )
				{
					m_modeEnCours = value;
                    if (m_modeEnCours == EModeEditeurProjet.Selection)
                        ModeSouris = EModeSouris.Selection;
                    else
                        ModeSouris = EModeSouris.Custom;
					LoadCurseurAdapté();
					
					if ( AfterModeEditionChanged != null )
						AfterModeEditionChanged ( this, new EventArgs() );
				}
			}
		}
		public CProjet ProjetEnCreation
		{
			get
			{
				return WndProjetEdite.Projet;
			}
		}
		public CWndProjetDetail WndProjetEdite
		{
			get
			{
				return (CWndProjetDetail)ObjetEdite;
			}
			set
			{
				ObjetEdite = value;
				if (value != null)
					this.AutoScrollMinSize = value.Size;
			}
		}

		public IWndElementDeProjetPlanifiable ElementAttachableDepart
		{
			get
			{
				return m_eleDebutLien;
			}
		}

		public bool ModeCreation
		{
			get
			{
				return m_bModeCreation;
			}
			set
			{
				m_bModeCreation = value;
			}
		}

		private void LoadCurseurAdapté()
		{
			if ( m_customCursor != null && m_customCursor!= Cursors.Arrow)
				m_customCursor.Dispose();
			m_customCursor = null;
			MemoryStream s = null;
			switch ( ModeEdition )
			{
				case EModeEditeurProjet.Projet:
				case EModeEditeurProjet.Intervention:
					if (m_bModeCreation)
						s = new MemoryStream(Properties.Resources.curAction);
					else
						s = new MemoryStream(Properties.Resources.curActionAdd);
					break;
				case EModeEditeurProjet.LienStart:
					s = new MemoryStream(Properties.Resources.curLien1);
					break;
				case EModeEditeurProjet.LienEnd:
					s = new MemoryStream(Properties.Resources.curLien2);
					break;
				default :
					m_customCursor = Cursors.Arrow;
					break;
			}
			if (s != null)
			{
				m_customCursor = new Cursor(s);
				s.Close();
			}
			Cursor = m_customCursor;
		}

		private I2iObjetGraphique m_lastElementClic;
		/// ////////////////////////////////////////////////////////////////
		private void CControlEdition_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
            Point ptSouris = GetLogicalPointFromDisplay(new Point(e.X, e.Y));
			I2iObjetGraphique wndNouvelEle = null;

			switch ( ModeEdition )
			{
				case EModeEditeurProjet.Selection:
					break;


				case EModeEditeurProjet.Projet:

					if (BeforeAddElement != null && !BeforeAddElement())
						break;

					CProjet nouveauProjet;
					if (m_bModeCreation)
					{
						nouveauProjet = new CProjet(WndProjetEdite.Projet.ContexteDonnee);
						nouveauProjet.CreateNew();
					}
					else
					{
						CFiltreData filtre = new CFiltreDataAvance(CProjet.c_nomTable, "HasNo(" + CProjet.c_champIdParent + ") AND " + CProjet.c_champCodeSystemeComplet + " not like @1",ProjetEnCreation.CodeSystemePartiel+"%" );
						
						//string strIdsPrjsToIgnore = ProjetEnCreation.Id.ToString();
						//foreach (CProjet prjFils in ProjetEnCreation.ProjetsFils)
						//    strIdsPrjsToIgnore += "," + prjFils.Id.ToString();
						//filtre = CFiltreData.GetAndFiltre(filtre, new CFiltreDataAvance(CProjet.c_nomTable, CProjet.c_champId + " not in (" + strIdsPrjsToIgnore +")"));
						CListeObjetsDonnees lstPrjs = new CListeObjetsDonnees(ProjetEnCreation.ContexteDonnee, typeof(CProjet), filtre);
						CFormListeProjet frmProjets = new CFormListeProjet(lstPrjs);
						nouveauProjet = (CProjet)CFormNavigateurPopupListe.SelectObject(frmProjets, null, "");

						if (nouveauProjet == null)
							return;
					}

					nouveauProjet.Projet = ProjetEnCreation;

					nouveauProjet.DesignerProjetX = e.X;
					nouveauProjet.DesignerProjetY = e.Y;

					wndNouvelEle = new CWndProjetBrique(nouveauProjet);
					break;


				case EModeEditeurProjet.Intervention:
					if (BeforeAddElement != null && !BeforeAddElement())
						break;

					CIntervention nouvelleInter;

					if (m_bModeCreation)
					{
						nouvelleInter = new CIntervention(WndProjetEdite.Projet.ContexteDonnee);
						nouvelleInter.CreateNew();
					}
					else
					{
						CFiltreData filtre = new CFiltreDataAvance(CIntervention.c_nomTable, "HasNo(" + CProjet.c_champId + ")");
						CListeObjetsDonnees lstInter = new CListeObjetsDonnees(ProjetEnCreation.ContexteDonnee, typeof(CIntervention), filtre);
						CFormListeInterventions frmInters = new CFormListeInterventions(lstInter);
						nouvelleInter = (CIntervention)CFormNavigateurPopupListe.SelectObject(frmInters, null, "");
						if (nouvelleInter == null)
							return;
					}
					
					nouvelleInter.DesignerProjetX = e.X;
					nouvelleInter.DesignerProjetY = e.Y;
					nouvelleInter.Projet = WndProjetEdite.Projet;
					wndNouvelEle = new CWndIntervention(nouvelleInter);
					break;

				case EModeEditeurProjet.LienStart:
					I2iObjetGraphique o = WndProjetEdite.GetObjetFilsFromPoint(ptSouris);
					if(o != null && o is IWndElementDeProjetPlanifiable)
					{
						m_eleDebutLien = (IWndElementDeProjetPlanifiable)o;
						ModeEdition = EModeEditeurProjet.LienEnd;
					}

					break;

				case EModeEditeurProjet.LienEnd:
					ModeEdition = EModeEditeurProjet.LienStart;
					I2iObjetGraphique ele = WndProjetEdite.GetObjetFilsFromPoint(ptSouris);
					bool bCreer = true;
					if (ele != null && ele != m_eleDebutLien && ele is IWndElementDeProjetPlanifiable)
					{
						foreach (I2iObjetGraphique objet in ObjetEdite.Childs)
							if (objet is CWndLienDeProjet)
							{
								CWndLienDeProjet wndLien = (CWndLienDeProjet)objet;
								if (wndLien.ElementArrivee == m_eleDebutLien &&
									wndLien.ElementDepart == ele ||
									wndLien.ElementArrivee == ele &&
									wndLien.ElementDepart == m_eleDebutLien)
								{
									bCreer = false;
									break;
								}
							}

						if (bCreer && BeforeAddElement != null && !BeforeAddElement())
							break;

						if (bCreer)
						{
							CLienDeProjet lien = new CLienDeProjet(WndProjetEdite.Projet.ContexteDonnee);
							lien.CreateNewInCurrentContexte();
							lien.ElementA = m_eleDebutLien.ElementDuProjet;
							lien.ElementB = ((IWndElementDeProjetPlanifiable) ele).ElementDuProjet;
							lien.Projet = WndProjetEdite.Projet;

							CWndLienDeProjet wndLien = new CWndLienDeProjet(lien);
							wndLien.ElementDepart = (IWndElementDeProjetPlanifiable)m_eleDebutLien;
							wndLien.ElementArrivee = (IWndElementDeProjetPlanifiable)ele;
							wndNouvelEle = wndLien;
							ModeEdition = EModeEditeurProjet.LienStart;
						}
					}
					break;
			}
			if ( wndNouvelEle != null )
			{
				Point pt = new Point ( ptSouris.X-wndNouvelEle.Size.Width/2, ptSouris.Y - wndNouvelEle.Size.Height/2);
				wndNouvelEle.Position = pt;
				WndProjetEdite.AddChild(wndNouvelEle);

				Selection.Clear();
				Selection.Add(wndNouvelEle);
				//Refresh();

				if ( AfterAddElement != null )
					AfterAddElement(wndNouvelEle);
			}
		}

		public void SelectionnerElement(IElementDeProjet ele)
		{
			I2iObjetGraphique o = null;
			foreach (I2iObjetGraphique objet in ObjetEdite.Childs)
			{
				switch (ele.TypeElementDeProjet.Code)
				{
					case ETypeElementDeProjet.Projet:
						if (objet is CWndProjetBrique && ele.Equals(((CWndProjetBrique)objet).Projet))
							o = objet;
						break;

					case ETypeElementDeProjet.Intervention:
						if (objet is CWndIntervention && ele.Equals(((CWndIntervention)objet).Intervention))
							o = objet;
						break;

					case ETypeElementDeProjet.Lien:
						if (objet is CWndLienDeProjet && ele.Equals(((CWndLienDeProjet)objet).LienDeProjet))
							o = objet;
						break;

					default:
						return;
				}
				if (o != null)
					break;
			}
			if (BeforeSelectElement != null && !BeforeSelectElement())
				return;

			Selection.Clear();
			Selection.Add(o);
			if (AfterSelectElement != null)
				AfterSelectElement(o);
		}
		public void AjouterElement(IElementDeProjet ele)
		{

		}

		//-----------------------------------------------------------------
		public override bool LockEdition
		{
			get
			{
				return m_extModeEdition.ModeEdition;
			}
			set
			{
				m_extModeEdition.ModeEdition = !value;
				if (OnChangeLockEdition != null)
					OnChangeLockEdition(this, new EventArgs());
			}
		}
		public event EventHandler OnChangeLockEdition;

	}

	public delegate void EventHandlerForIElementDeProjet(I2iObjetGraphique e);
	public delegate void EventHandlerForAddIElementDeProjet(MouseEventArgs mouseEvent,ETypeElementDeProjet typeEle);

	public delegate IElementDeProjetPlanifiable EventHandlerForAddIElementDeProjetAttachable();

	public delegate bool EventHandlerAnnulable();

	public enum EModeEditeurProjet
	{
		Selection,
		Projet,
		Intervention,
		LienStart,
		LienEnd
	}
}

