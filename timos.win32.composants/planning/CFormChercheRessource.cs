using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using sc2i.common;
using sc2i.win32.common;
using timos.acteurs;
using sc2i.data;
using timos.data;
using sc2i.win32.data.navigation;
using sc2i.win32.data;

namespace timos.win32.composants
{

	public delegate void SetRessourceEventHandler ( object sender, CRessourceMaterielle ressource );
	public partial class CFormChercheRessource : CFloatingFormBase
	{
		private CContrainte m_contrainte = null;
		private CIntervention m_intervention = null;
		private Dictionary<IPossesseurRessource, TreeNode> m_tableEmplacements = new Dictionary<IPossesseurRessource, TreeNode>();
		private SetRessourceEventHandler m_handlerSetRessource = null;

		//------------------------------------------------------------------
		public CFormChercheRessource()
		{
			InitializeComponent();
            m_controlPlanning.BaseAffichee = new CFournisseurEntreesPlanning(CSc2iWin32DataClient.ContexteCourant);
		}

		//------------------------------------------------------------------
		public static void  FindRessource( 
			CIntervention tache, 
			CContrainte contrainte,
			SetRessourceEventHandler handler )
		{
			CFormChercheRessource form = new CFormChercheRessource();
			form.m_contrainte = contrainte;
			form.m_intervention = tache;
			form.m_handlerSetRessource = handler;
			form.Show();

		}


		//------------------------------------------------------------------
		private void CFormChercheRessource_Load(object sender, EventArgs e)
		{
			m_lblContrainte.Text = m_contrainte.TypeContrainte.Libelle+" "+m_contrainte.Libelle;
			if (m_intervention != null)
			{
				m_panelFiltre.Visible = true;
				pictureBox1.Image = m_contrainte.TypeContrainte.ImageApplique;
				CListeObjetsDonnees listeProfilsRessource = new CListeObjetsDonnees(m_intervention.ContexteDonnee, typeof(CProfilElement));
				listeProfilsRessource.Filtre = new CFiltreData(
					CProfilElement.c_champTypeElements + "=@1 and " +
					CProfilElement.c_champTypeSource + "=@2",
					typeof(CRessourceMaterielle).ToString(),
					typeof(CIntervention).ToString());
				m_cmbProfilRessource.Init(listeProfilsRessource, "Libelle", false);
				m_cmbProfilRessource.ElementSelectionne = m_intervention.TypeIntervention.ProfilRessourceDefaut;
			}
			else
			{
				m_panelFiltre.Visible = false;
			}
			FillArbre();
		}

		//------------------------------------------------------------------
		private void FillArbre()
		{
			CProfilElement profil = (CProfilElement)m_cmbProfilRessource.ElementSelectionne;
			IList ressources;
			if (m_intervention != null)
			{
				if (profil != null)
				{
					ressources = profil.GetElementsForSource(m_intervention, m_contrainte, null);
				}
				else return;
			}
			else
			{
				ressources = m_contrainte.GetToutesLesRessourcesLevant(null);
			}

			m_arbre.Nodes.Clear();
			m_tableEmplacements.Clear();
			foreach (CRessourceMaterielle ressource in ressources)
			{
				TreeNode nodeEmplacement = GetNode(ressource.Emplacement);
				if ( nodeEmplacement != null )
				{
					TreeNode nodeRessource = new TreeNode(ressource.Libelle);
					nodeRessource.Tag = ressource;
					nodeRessource.ImageIndex = 2;
					nodeRessource.SelectedImageIndex = 2;
					nodeEmplacement.Nodes.Add(nodeRessource);
				}
			}
		}

		//-------------------------------------------------------------
		private TreeNode GetNode(IPossesseurRessource emplacement)
		{
			if (m_tableEmplacements.ContainsKey(emplacement))
				return m_tableEmplacements[emplacement];
			TreeNodeCollection coll = m_arbre.Nodes;
			if (emplacement is CSite)
			{
				CSite site = (CSite)emplacement;
				if (site.SiteParent != null)
				{
					TreeNode nodeParent = GetNode(site.SiteParent);
					if (nodeParent == null)
						return null;
					coll = nodeParent.Nodes;
				}
			}
			TreeNode node = new TreeNode(emplacement.Libelle);
			node.Tag = emplacement;
			if ( emplacement is CSite )
				node.ImageIndex = 0;
			else if ( emplacement is CActeur )
				node.ImageIndex = 1;
			node.SelectedImageIndex = node.ImageIndex;

			m_tableEmplacements[emplacement] = node;
			coll.Add(node);
			return node;
		}


		//-------------------------------------------------------------------------------------
		private void m_arbre_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Node != null && e.Node.Tag is CRessourceMaterielle)
			{
				if (m_handlerSetRessource != null)
					m_handlerSetRessource(this, (CRessourceMaterielle)e.Node.Tag);
				else
				{
                    //Type typeForm = CFormFinder.GetTypeFormToEdit(typeof(CRessourceMaterielle));
                    //if (typeForm != null && typeof(CFormEditionStandard).IsAssignableFrom(typeForm))
                    //{
                    //    CFormEditionStandard form = (CFormEditionStandard)Activator.CreateInstance(typeForm, e.Node.Tag);
                    //    CSc2iWin32DataNavigation.Navigateur.AffichePage(form);
                    //}
                    CReferenceTypeForm refTypeForm = CFormFinder.GetRefFormToEdit(typeof(CRessourceMaterielle));
                    if (refTypeForm != null)
                    {
                        CFormEditionStandard form = refTypeForm.GetForm((CObjetDonneeAIdNumeriqueAuto)e.Node.Tag) as CFormEditionStandard;
                        if (form != null)
                            CSc2iWin32DataNavigation.Navigateur.AffichePage(form);
                    }

				}
				Hide();
			}
		}

		//-------------------------------------------------------------------------------------
		private void m_cmbProfilRessource_SelectionChangeCommitted(object sender, EventArgs e)
		{
			FillArbre();
		}

		private void m_panelDispo_Paint(object sender, PaintEventArgs e)
		{

		}

		private void m_arbre_AfterSelect(object sender, TreeViewEventArgs e)
		{
			m_timerUpdatePlanning.Enabled = false;
			m_timerUpdatePlanning.Enabled = true;
		}

		private void m_timerUpdatePlanning_Tick(object sender, EventArgs e)
		{
			m_timerUpdatePlanning.Enabled = false;
			if (m_arbre.SelectedNode != null &&
				m_arbre.SelectedNode.Tag is IRessourceEntreePlanning && 
				m_intervention != null )
			{
                m_controlPlanning.BaseAffichee = new CFournisseurEntreesPlanning(m_intervention.ContexteDonnee);
				m_controlPlanning.AfficheForRessource((IRessourceEntreePlanning)m_arbre.SelectedNode.Tag, m_intervention);
				m_panelDispo.Visible = true;
			}
			else
				m_panelDispo.Visible = false;

		}

		private void CFormChercheRessource_Leave(object sender, EventArgs e)
		{

		}





	}
}