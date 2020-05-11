using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using sc2i.common;
using sc2i.win32.common;
using timos.data;
using timos.securite;
using sc2i.data;

namespace timos.interventions
{
	public partial class CArbreFiltreCorrespondanceEO : UserControl,IControlALockEdition
	{
		private IElementAFiltreEO m_profil;
		public CArbreFiltreCorrespondanceEO()
		{
			InitializeComponent();
		}

		//-------------------------------------------------------------------------
		private bool m_bIsInit = false;
		public CResultAErreur InitChamps(IElementAFiltreEO profil)
		{
			m_bIsInit = false;
			CResultAErreur result = CResultAErreur.True;
			m_profil = profil;
			InitTypesEos();
			m_bIsInit = true;

			return result;
		}

		//-------------------------------------------------------------------------
		public IElementAFiltreEO Profil
		{
			get
			{
				return m_profil;
			}
		}
		//-------------------------------------------------------------------------
		private void InitTypesEos()
		{
			m_arbreEO.Nodes.Clear();
			Hashtable tableCorrespondances = new Hashtable();
			foreach ( COptionCorrespondanceEO option in Profil.OptionsPropres )
				tableCorrespondances[option.TypeEO] = option.ModeComparaison;
			CListeObjetsDonnees listeTypesEo = new CListeObjetsDonnees(Profil.ContexteDonnee, typeof(CTypeEntiteOrganisationnelle));
			listeTypesEo.Filtre = new CFiltreData(CTypeEntiteOrganisationnelle.c_champIdParent + " is null");
			foreach (CTypeEntiteOrganisationnelle tp in listeTypesEo)
			{
				TreeNode node = new TreeNode();
				FillItemTypeEO(node, tp, tableCorrespondances);
				m_arbreEO.Nodes.Add(node);
			}
		}

		//-------------------------------------------------------------------------
		private void RedrawNode(TreeNode node)
		{
			COptionCorrespondanceEO option = (COptionCorrespondanceEO)node.Tag;
			if (!node.Checked)
				node.ImageIndex = 0;
			else
				node.ImageIndex = (int)option.ModeComparaison + 1;
			node.SelectedImageIndex = node.ImageIndex;
		}

		//-------------------------------------------------------------------------
		public CResultAErreur MajChamps()
		{
			CResultAErreur result = CResultAErreur.True;
			List<COptionCorrespondanceEO> liste = new List<COptionCorrespondanceEO>();
			foreach (TreeNode node in m_arbreEO.Nodes)
				FillListeOptionsChecked(node, liste);
			Profil.OptionsPropres = liste.ToArray();
			return result;
		}

		//-------------------------------------------------------------------------
		protected void FillListeOptionsChecked ( TreeNode node, List<COptionCorrespondanceEO> liste )
		{
			if ( node.Checked )
				liste.Add ( (COptionCorrespondanceEO)node.Tag);
			foreach ( TreeNode fils in node.Nodes )
				FillListeOptionsChecked ( fils, liste );
		}

		//-------------------------------------------------------------------------
		private void FillItemTypeEO(
			TreeNode node,
			CTypeEntiteOrganisationnelle typeEO,
			Hashtable tableSel)
		{
			node.Text = typeEO.Libelle;
			COptionCorrespondanceEO option = new COptionCorrespondanceEO(typeEO, EModeComparaisonEO.FillesUniquement);
			if (tableSel.Contains(typeEO))
			{
				node.Checked = true;
				option = new COptionCorrespondanceEO(typeEO, (EModeComparaisonEO)tableSel[typeEO]);
			}
			node.Tag = option;
			RedrawNode(node);
			foreach (CTypeEntiteOrganisationnelle tp in typeEO.TypesFils)
			{
				TreeNode newNode = new TreeNode();
				FillItemTypeEO(newNode, tp, tableSel);
				node.Nodes.Add(newNode);
				if (newNode.Checked || newNode.IsExpanded)
					node.Expand();
			}
		}


		//-------------------------------------------------------------------------
		private void m_arbreEO_BeforeCheck(object sender, TreeViewCancelEventArgs e)
		{
			if (!m_gestionnaireModeEdition.ModeEdition && m_bIsInit)
				e.Cancel = true;
		}

		//-------------------------------------------------------------------------
		private TreeNode m_nodeMenu = null;
		private void m_arbreEO_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Node.Checked && m_gestionnaireModeEdition.ModeEdition)
			{
				Point pt = e.Location;
				TreeViewHitTestInfo info = m_arbreEO.HitTest(pt);
				if (info.Location == TreeViewHitTestLocations.Image)
				{
					COptionCorrespondanceEO option = (COptionCorrespondanceEO)e.Node.Tag;
					m_menuBrancheComplete.Checked = option.ModeComparaison == EModeComparaisonEO.BrancheComplete;
					m_menuEgaliteStricte.Checked = option.ModeComparaison == EModeComparaisonEO.Egalite;
					m_menuFillesSeulement.Checked = option.ModeComparaison == EModeComparaisonEO.FillesUniquement;
					m_menuParentsSeulement.Checked = option.ModeComparaison == EModeComparaisonEO.ParentsUniquement;
					m_menuArbreEO.Show(m_arbreEO, pt);
					m_nodeMenu = e.Node;
				}
			}
		}


		//--------------------------------------------------------------
		private void SetOption(TreeNode node, EModeComparaisonEO mode)
		{
			if (node != null)
			{
				COptionCorrespondanceEO option = (COptionCorrespondanceEO)node.Tag;
				option.ModeComparaison = mode;
				RedrawNode(node);
			}
		}

		private void m_arbreEO_AfterCheck(object sender, TreeViewEventArgs e)
		{
			RedrawNode(e.Node);
		}

		private void m_menuFillesSeulement_Click(object sender, EventArgs e)
		{
			SetOption(m_nodeMenu, EModeComparaisonEO.FillesUniquement);
		}

		private void m_menuParentsSeulement_Click(object sender, EventArgs e)
		{
			SetOption(m_nodeMenu, EModeComparaisonEO.ParentsUniquement);
		}

		private void m_menuEgaliteStricte_Click(object sender, EventArgs e)
		{
			SetOption(m_nodeMenu, EModeComparaisonEO.Egalite);
		}

		private void m_menuBrancheComplete_Click(object sender, EventArgs e)
		{
			SetOption(m_nodeMenu, EModeComparaisonEO.BrancheComplete);
		}

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
	}
}
