using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

using timos.data;

using sc2i.common;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.win32.common;
using sc2i.data;
using sc2i.drawing;
using sc2i.data.dynamic;

namespace timos
{
	public partial class CPanelEditStructureProjet : UserControl, IControlALockEdition
	{
		private CProjet m_projet = null;
		private bool m_bInitialise = false;
		private bool m_bEditeurMaque;

		//private int m_nWithPanelEdit = 0;

		public CPanelEditionObjetGraphique Editeur
		{
			get
			{
				return m_controlEdition;
			}
		}

		public CPanelEditStructureProjet()
		{
			InitializeComponent();
			m_bSelecContenu = false;
			m_controlEdition.SelectionChanged += new EventHandler(Editeur_ChangementSelection);
		}

		private void Editeur_ChangementSelection(object sender, EventArgs e)
		{
			I2iObjetGraphique elementRef = m_controlEdition.Selection.ControlReference;
			if (elementRef != null)
			{
				SelectionnerContenu(elementRef);
				AfficherPanel(elementRef);
				//ActualiserDesigner();
			}
		}
		//-----------------------------------------------------
		private void CPanelEditProjet_Load(object sender, EventArgs e)
		{
			m_controlEdition.ModeEdition = EModeEditeurProjet.Selection;
		}
		public CResultAErreur InitChamps(CProjet projet)
		{
			m_bInitialise = false;
			CResultAErreur result = CResultAErreur.True;
			m_projet = projet;

			CWndProjetDetail wnd = CWndProjetDetail.GetNewWnd(projet);
			m_controlEdition.WndProjetEdite = wnd;
			//m_controlEdition.Refresh();

			UpdateBoutonsMode();
			InitCmbFiltreContenu();
			m_spcGauche.SplitterDistance = m_lvContenu.Columns[0].Width + m_lvContenu.Columns[1].Width + 10;
			
            //if(m_nWithPanelEdit == 0)
            //    m_nWithPanelEdit = m_spcDroite.SplitterDistance;
			m_bEditeurMaque = true;
			m_panEditionRapide.Visible = false;
            //m_spcDroite.SplitterDistance = m_spcDroite.Width;
            //m_spcDroite.IsSplitterFixed = true;

			m_chkMiniatures.Checked = m_projet.AfficherMiniature;
			m_bInitialise = true;
			return result;
		}
		public CResultAErreur MajChamps()
		{
			CResultAErreur result = CResultAErreur.True;
			result = m_panEditionRapide.MAJChamps();
			return result;
		}



		//-----------------------------------------------------
		private void ActualiserDesigner()
		{
			//m_controlEdition.Refresh();
			//Refresh();
		}

		//-----------------------------------------------------
		private CResultAErreur AfficherEditeur(IElementDeProjet element)
		{
			CResultAErreur result = CResultAErreur.True;
			if (element is CProjet)
			{
				CProjet projet = (CProjet)element;
				if (projet.IsNew() && m_controlEdition.ModeEdition == EModeEditeurProjet.Selection)
					projet.BeginEdit();

				CFormNavigateurPopup.Show(new CFormEditionProjet(projet));
				if (!projet.IsValide() || !projet.VerifieDonnees(false).Result)
					result = CResultAErreur.False;
			}
			if (element is CIntervention)
			{
				CIntervention inter = (CIntervention)element;
				if (inter.IsNew() && m_controlEdition.ModeEdition == EModeEditeurProjet.Selection)
					inter.BeginEdit();

				CFormNavigateurPopup.Show(new CFormEditionIntervention(inter));
				if (!inter.IsValide() || !inter.VerifieDonnees(false).Result)
					result = CResultAErreur.False;

			}
			if (result)
			{
				ActualiserDesigner();
				GenererListeContenu();
			}
			return result;
		}

		private DialogResult AfficherEditeur(I2iObjetGraphique o)
		{
			ETypeElementDeProjet? t = CUtilProjet.GetTypeElement(o);
			CResultAErreur result = CResultAErreur.True;
			switch (t)
			{
				case ETypeElementDeProjet.Projet:
					CProjet projet = ((CWndProjetBrique)o).Projet;
					result = AfficherEditeur(projet);
					break;

				case ETypeElementDeProjet.Intervention:
					CIntervention inter = ((CWndIntervention)o).Intervention;
					result = AfficherEditeur(inter);
					break;

				case ETypeElementDeProjet.Lien:
				default:
					return DialogResult.Abort;
			}
			if (!result)
				return DialogResult.Abort;

			return DialogResult.OK;
		}

		private void AfficherPanel(I2iObjetGraphique o)
		{
			m_panEditionRapide.Init(o);
			m_panEditionRapide.LockEdition = LockEdition;

			bool etat = m_panEditionRapide.HasElementValide;
            //m_spcDroite.IsSplitterFixed = !etat;
			m_bEditeurMaque = !etat;			
            //m_spcDroite.SplitterDistance = etat?m_nWithPanelEdit: m_spcDroite.Width;
			m_panEditionRapide.Visible = etat;

		}
		private CResultAErreur ValidePanel()
		{
			CResultAErreur result = m_panEditionRapide.MAJChamps();
			if (!result)
				CFormAlerte.Afficher(result.Erreur);
			return result;
		}

		private bool BeforeAction()
		{
			if (!ValidePanel())
				return false;
			else
			{
				GenererListeContenu();
				SelectionnerContenu(m_lastEleSelec);
				return true;
			}
		}
		//-----------------------------------------------------------------
		private void m_controlEdition_AfterAddElement(I2iObjetGraphique e)
		{
			//Si on est en création on edite l'élément (si il est editable)
			//Et si l'édition est annulée on doit supprimer l'élément
			if (m_rbtCreationMode.Checked
			&& e is IWndElementDeProjetPlanifiable
			&& AfficherEditeur(e) != DialogResult.OK)
			{
				SupprimerElement(e);
				return;
			}

			IElementDeProjet ele = CUtilProjet.GetIElementDeProjet(e);
			if (ele is CObjetDonnee && !((CObjetDonnee)ele).VerifieDonnees(false).Result)
			{
				CFormAlerte.Afficher(((CObjetDonnee)ele).VerifieDonnees(false).Erreur);
				SupprimerElement(e);
				return;
			}

			ActualiserDesigner();
			AfficherPanel(e);
			GenererListeContenu();
			SelectionnerContenu(e);
			m_controlEdition.ModeEdition = EModeEditeurProjet.Selection;

		}
		private void SupprimerElement(I2iObjetGraphique ele)
		{
			m_controlEdition.Selection.Clear();
			m_controlEdition.WndProjetEdite.RemoveChild(ele);
			ActualiserDesigner();
		}
		//-----------------------------------------------------
		private void m_controlEdition_AfterRemoveObjetGraphique(object sender, EventArgs e)
		{

			m_controlEdition.WndProjetEdite.NettoieObjetsInvalides();
			ActualiserDesigner();
			GenererListeContenu();
		}
		//-----------------------------------------------------
		private void m_controlEdition_AfterDoubleClicElement(I2iObjetGraphique e)
		{
			if (!LockEdition && AfficherEditeur(e) == DialogResult.OK)
			{
				AfficherPanel(e);
				SelectionnerContenu(e);
			}
			else
			{
				//Si je le fait en recherchant la form editionstandard ça plante

				IFormNavigable frm = null;
				ETypeElementDeProjet? tele = CUtilProjet.GetTypeElement(e);
				IElementDeProjet ele = CUtilProjet.GetIElementDeProjet(e);
				switch (tele)
				{
					case ETypeElementDeProjet.Projet:
						frm = new CFormEditionProjet((CProjet)ele);

						break;
					case ETypeElementDeProjet.Intervention:
						frm = new CFormEditionIntervention((CIntervention)ele);
						break;
					case ETypeElementDeProjet.Lien:
					default:
						return;
				}

				CTimosApp.Navigateur.AffichePage(frm);
			}	
		}


		//-----------------------------------------------------
		private void m_controlEdition_AfterClicElementInSelection(I2iObjetGraphique e)
		{

		}



		#region Mode Edition
		//-----------------------------------------------------
		private void m_controlEdition_AfterModeEditionChanged(object sender, EventArgs e)
		{
			UpdateBoutonsMode();
		}


		/// //////////////////////////////////////////
		private bool m_bIsUpdating = false;
		private RadioButton m_rbtLast;
		private void UpdateBoutonsMode()
		{
			if (m_bIsUpdating)
				return;
			
			m_bIsUpdating = true;
			RadioButton rbtSelec = null;
			switch (m_controlEdition.ModeEdition)
			{
				case EModeEditeurProjet.Selection:		rbtSelec = m_chkCurseur;	break;
				case EModeEditeurProjet.Projet:			rbtSelec = m_chkProjet;		break;
				case EModeEditeurProjet.Intervention:	rbtSelec = m_chkInter;		break;
				case EModeEditeurProjet.LienStart:		rbtSelec = m_chkLien;		break;
			}
			if (rbtSelec != null)
			{
				rbtSelec.BackgroundImage = InvertColors(rbtSelec.BackgroundImage);
				rbtSelec.Checked = true;
				
				if (m_rbtLast != null)
					m_rbtLast.BackgroundImage = InvertColors(m_rbtLast.BackgroundImage);

					//InvertColors(m_rbtLast.BackgroundImage);

				m_rbtLast = rbtSelec;
			}
			m_bIsUpdating = false;
		}

		public static Bitmap InvertColors(Bitmap bmp)
		{

			//Image.FromStream(new MemoryStream(Image.sa rbtSelec.BackgroundImage
			Color cSource;
			Color cDest;
			for (int y = 0; y < bmp.Height; y++)
			{
				for (int x = 0; x < bmp.Width; x++)
				{
					cSource = bmp.GetPixel(x, y);
					cDest = Color.FromArgb(255 - cSource.R, 255 - cSource.G, 255 - cSource.B);
					bmp.SetPixel(x, y, cDest);
				}
			}
			return bmp;
		}

		public static Image InvertColors(Image img)
		{
			if (img == null)
				return null;
			return InvertColors(new Bitmap(img));
		}


		//-----------------------------------------------------------------
		private void m_chkProjet_CheckedChanged(object sender, EventArgs e)
		{
			if (m_chkProjet.Checked)
			{
				m_controlEdition.ModeEdition = EModeEditeurProjet.Projet;
				m_controlEdition.LockEdition = true;
			}
		}
		private void m_chkInter_CheckedChanged(object sender, EventArgs e)
		{
			if (m_chkInter.Checked)
			{
				m_controlEdition.ModeEdition = EModeEditeurProjet.Intervention;
				m_controlEdition.LockEdition = true;
			}
		}
		private void m_chkCurseur_CheckedChanged(object sender, EventArgs e)
		{
			if (m_chkCurseur.Checked)
			{
				m_controlEdition.ModeEdition = EModeEditeurProjet.Selection;
				m_controlEdition.LockEdition = false;
			}
		}
		private void m_chkLien_CheckedChanged(object sender, EventArgs e)
		{
			if (m_chkLien.Checked)
			{
				m_controlEdition.ModeEdition = EModeEditeurProjet.LienStart;
				m_controlEdition.LockEdition = true;
			}
		}
		#endregion

		//-----------------------------------------------------------------
		public bool LockEdition
		{
			get
			{
				return !m_extModeEdition.ModeEdition;
			}
			set
			{

				m_extModeEdition.ModeEdition = !value;
				m_controlEdition.Selection.Clear();
				//m_controlEdition.Refresh();

				if (OnChangeLockEdition != null)
					OnChangeLockEdition(this, new EventArgs());

				if (value)
				{
					m_panEditionRapide.LockEdition = LockEdition;
					m_controlEdition.ModeEdition = EModeEditeurProjet.Selection;
				}
			}
		}
		public event EventHandler OnChangeLockEdition;

		#region Panel Selection gauche
		private Hashtable m_htbIdxFiltreContenu;
		private void InitCmbFiltreContenu()
		{

			m_oldWithColType = m_lvContenu.Columns[1].Width;

			List<CTypeElementDeProjet> eles = new List<CTypeElementDeProjet>();
			eles.Add(new CTypeElementDeProjet(ETypeElementDeProjet.Projet));
			eles.Add(new CTypeElementDeProjet(ETypeElementDeProjet.Intervention));
			eles.Add(new CTypeElementDeProjet(ETypeElementDeProjet.Lien));

			m_cmbFiltreContenu.Items.Clear();
			m_htbIdxFiltreContenu = new Hashtable();

			m_cmbFiltreContenu.Items.Add(I.T( "All|913"));
			m_htbIdxFiltreContenu.Add(0, null);

			foreach (CTypeElementDeProjet e in eles)
			{
				m_cmbFiltreContenu.Items.Add(e.Libelle);
				m_htbIdxFiltreContenu.Add(m_cmbFiltreContenu.Items.Count - 1, e);
			}

			m_cmbFiltreContenu.SelectedIndex = 0;
			GenererListeContenu();
		}


		private int m_oldWithColType;
		private void GenererListeContenu()
		{
			m_lvContenu.Items.Clear();

			if (m_cmbFiltreContenu.SelectedIndex == 0)
			{
				if (m_oldWithColType != 0)
					m_lvContenu.Columns[1].Width = m_oldWithColType;

				AjouterProjetsFilsContenus();
				AjouterInterventionsContenues();
				AjouterLiensContenus();
			}
			else
			{
				if (m_lvContenu.Columns[1].Width != 0)
				{
					m_oldWithColType = m_lvContenu.Columns[1].Width;
					m_lvContenu.Columns[1].Width = 0;
				}
				CTypeElementDeProjet tobj = (CTypeElementDeProjet)m_htbIdxFiltreContenu[m_cmbFiltreContenu.SelectedIndex];
				switch (tobj.Code)
				{
					case ETypeElementDeProjet.Projet:
						AjouterProjetsFilsContenus();
						break;
					case ETypeElementDeProjet.Intervention:
						AjouterInterventionsContenues();
						break;
					case ETypeElementDeProjet.Lien:
						AjouterLiensContenus();
						break;
					default:
						break;
				}
			}
		}
		private void AjouterProjetsFilsContenus()
		{
			CListeObjetsDonnees prjs = m_projet.ProjetsFils;
			foreach (CProjet p in prjs)
				AjouterElementContenu(p);
		}
		private void AjouterInterventionsContenues()
		{
			CListeObjetsDonnees inters = m_projet.Interventions;
			foreach (CIntervention i in inters)
				AjouterElementContenu(i);

		}
		private void AjouterLiensContenus()
		{
			CListeObjetsDonnees lnks = m_projet.LiensDuProjet;
			foreach (CLienDeProjet l in lnks)
				AjouterElementContenu(l);
		}

		private void AjouterElementContenu(IElementDeProjet ele)
		{
			ListViewItem itm = new ListViewItem(ele.Libelle);
			itm.Tag = ele;
			string strType = I.T("Unknown|1240");
			Type t = ele.GetType();
			if(t == typeof(CLienDeProjet))
				strType = I.T( "Link|83");
			else if(t == typeof(CProjet))
				strType = I.T( "Project|749");
			else if(t == typeof(CIntervention))
				strType = I.T("Intervention|561");
			itm.SubItems.Add(strType);
			m_lvContenu.Items.Add(itm);
		}

		private void m_cmbFiltreContenu_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (m_bInitialise)
				GenererListeContenu();
		}
		private bool m_bSelecContenu = false;
		private void m_lvContenu_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (m_bInitialise && !m_bSelecContenu && m_lvContenu.SelectedItems.Count == 1)
			{
				m_lastItmSelec = m_lvContenu.SelectedItems[0];
				m_controlEdition.SelectionnerElement((IElementDeProjet)m_lastItmSelec.Tag);
			}
		}
		private IElementDeProjet m_lastEleSelec;
		private void SelectionnerContenu(I2iObjetGraphique o)
		{
			IElementDeProjet ele = CUtilProjet.GetIElementDeProjet(o);
			SelectionnerContenu(ele);
		}
		private void SelectionnerContenu(IElementDeProjet ele)
		{
			m_lastEleSelec = ele;
			m_bSelecContenu = true;
		
			bool existeEncore = ((ele != null) && ((CObjetDonnee)ele).IsValide());

			foreach (ListViewItem itm in m_lvContenu.Items)
				if (existeEncore && itm.Tag.Equals(ele))
					itm.Selected = true;
				else
					itm.Selected = false;

			m_bSelecContenu = false;
			ActualiserCouleur();
		}

		private ListViewItem m_lastItmSelec;

		private void ActualiserCouleur()
		{
			foreach (ListViewItem itm in m_lvContenu.Items)
			{
		
				if (itm.Selected)
				{
					itm.BackColor = Color.Black;
					itm.ForeColor = Color.White;
				}
				else
				{
					itm.BackColor = Color.White;
					itm.ForeColor = Color.Black;
				}
			}
			
		}
		#endregion

		private void m_rbtCreationMode_CheckedChanged(object sender, EventArgs e)
		{
			if(m_bInitialise)
				m_controlEdition.ModeCreation = m_rbtCreationMode.Checked;
		}
		private bool ObjetGraphiqueIsLien(I2iObjetGraphique obj)
		{
			return CUtilProjet.GetTypeElement(obj) == ETypeElementDeProjet.Lien;
		}
		private bool m_controlEdition_BeforeDeleteElement(List<I2iObjetGraphique> objs)
		{
			if (LockEdition)
				return false;
			if (!objs.TrueForAll(ObjetGraphiqueIsLien))
			{
				if (CFormDeleteIElementDeProjet.AfficherDialog(objs) != DialogResult.OK)
					return false;
			}
			return true;
		}

        //private void m_spcDroite_SplitterMoved(object sender, SplitterEventArgs e)
        //{
        //    int widthSpcD = m_spcDroite.SplitterDistance;
        //    if (!m_bEditeurMaque)
        //        m_nWithPanelEdit = widthSpcD;
        //}

		private void m_panEditionRapide_ProprieteModifiee(object sender, EventArgs e)
		{
			//m_controlEdition.Refresh();
		}

		private void m_chkMiniatures_CheckedChanged(object sender, EventArgs e)
		{
			if(m_bInitialise)
			{
				m_projet.BeginEdit();
				m_projet.AfficherMiniature = m_chkMiniatures.Checked;
				m_projet.CommitEdit();
				//m_controlEdition.Refresh();
			}
		}

		private void m_chkIcoAnomalies_CheckedChanged(object sender, EventArgs e)
		{
			if (m_bInitialise)
			{
				m_projet.BeginEdit();
				m_projet.AfficherIcoAno = m_chkIcoAnomalies.Checked;
				m_projet.CommitEdit();
				//m_controlEdition.Refresh();
			}
		}

		private void m_chkIcoEtat_CheckedChanged(object sender, EventArgs e)
		{
			if (m_bInitialise)
			{
				m_projet.BeginEdit();
				m_projet.AfficherIcoEtat = m_chkIcoEtat.Checked;
				m_projet.CommitEdit();
				//m_controlEdition.Refresh();
			}
		}

		private void m_panEditionRapide_OnClickProprietes(object sender, EventArgs e)
		{
			AfficherEditeur((IElementDeProjet)sender);
		}

        private bool m_controlEdition_BeforeDeleteElement()
        {
            return default(bool);
        }
	}
}
