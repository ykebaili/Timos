using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common;
using sc2i.common;

namespace HelpExtender
{
	public partial class CCtrlEditMenu : UserControl
	{
		#region ++ Constructeurs ++
		public CCtrlEditMenu()
		{
			InitializeComponent();
		}
		#endregion

		#region ~~ Méthodes ~~
		public void Initialiser(CMenuItem menu, bool modeEdition)
		{
			m_menu = menu;
			m_nFullWidth = Width;
			m_nShortWidth = Width - pan_edit.Width;

			m_bModeEdition = modeEdition;
			pan_edit.Visible = false;
			pan_cmds.Visible = modeEdition;
			txt_nom.Enabled = modeEdition;
			txt_descrip.Enabled = modeEdition;

			ConstruireMenu( menu );

			Width = m_nShortWidth;
			if (ChangementTaille != null)
				ChangementTaille(this, new EventArgs());

		}

		public CMenuItem Menu
		{
			get
			{
				return m_menu;
			}
		}

		//----------------------------------------------------------------
		/// <summary>
		/// Créée un nouveau noeud et l'initialise
		/// </summary>
		/// <param name="nodeParent"></param>
		/// <param name="menu"></param>
		/// <returns></returns>
		private TreeNode CreateNode ( TreeNodeCollection nodes, CMenuItem menu )
		{
			TreeNode node = new TreeNode (  );
			nodes.Add ( node );
			FillNode ( node, menu );
			return node;
		}

		//----------------------------------------------------------------
		/// <summary>
		/// Remplit un noeud avec les infos d'un menu
		/// </summary>
		/// <param name="node"></param>
		/// <param name="menu"></param>
		private void FillNode(TreeNode node, CMenuItem menu)
		{
			node.Text = menu.Nom;
			node.Tag = menu;
			if (node.Nodes.Count == 0)
			{
				if (menu.Items.Length > 0)
				{
					//Crée un item fictif pour qu'il y ait la croix devant l'item
					TreeNode nodeBidon = new TreeNode();
					node.Nodes.Add(nodeBidon);
				}
			}
		}

		//----------------------------------------------------------------------
		private void m_arbreMenu_AfterExpand(object sender, TreeViewEventArgs e)
		{
			TreeNode node = e.Node;
			//Si le node contient un noeud fils bidon, il faut charger les fils
			if (node.Nodes.Count == 1 && node.Nodes[0].Tag == null)
			{
				node.Nodes.Clear();
				RefreshChilds(node.Nodes, (CMenuItem)node.Tag);
			}
		}

		//----------------------------------------------------------------------
		/// <summary>
		/// Remappe les noeuds d'un treeNode avec les items fils de son Menu 
		/// </summary>
		/// <param name="node"></param>
		private void RefreshChilds(TreeNodeCollection nodes, CMenuItem itemParent)
		{
			Dictionary<CMenuItem, TreeNode> tableMenuToNode = new Dictionary<CMenuItem, TreeNode>();
			foreach (TreeNode nodeFils in nodes)
				tableMenuToNode[(CMenuItem)nodeFils.Tag] = nodeFils;
			TreeNode selectedNode = m_arbreMenu.SelectedNode;
			nodes.Clear();
			
			foreach (CMenuItem itemFils in itemParent.Items)
			{
				TreeNode nodeFils = null;
				if (tableMenuToNode.ContainsKey(itemFils))
				{
					nodeFils = tableMenuToNode[itemFils];
					nodes.Add(nodeFils);
				}
				else
				{
					nodeFils = CreateNode(nodes, itemFils);
				}
			}
			m_arbreMenu.SelectedNode = selectedNode;
		}


		//--------------------------------
		private void ConstruireMenu( CMenuItem menuRoot )
		{
			foreach (CMenuItem child in menuRoot.Items)
			{
				TreeNode node = CreateNode(m_arbreMenu.Nodes, child);
			}
		}
		

		#endregion

		#region :: Propriétés ::
		private int m_nShortWidth;
		private int m_nFullWidth;
		private bool m_bModeEdition;
		private CMenuItem m_menu;
		private CHelpData m_helpAssociee = null;
		#endregion

		
		private List<TreeNode> RecupererLesFreres(TreeNode n)
		{
			List<TreeNode> freres = new List<TreeNode>();
			if(n.Parent == null)
				foreach(TreeNode nfr in m_arbreMenu.Nodes)
					freres.Add(nfr);
			else
				foreach(TreeNode nfr in n.Parent.Nodes)
					freres.Add(nfr);


			return freres;
		}

		public event EventHandler ChangementTaille;

		private TreeNode m_lastNodeEnEdition = null;
		private void tv_menu_AfterSelect(object sender, TreeViewEventArgs e)
		{
			ValideModifs();
			bool bChangement = false;
			if (e.Node != null)
			{
				bChangement = !pan_edit.Visible;
				pan_edit.Visible = true;
				Width = m_nFullWidth;
				CMenuItem itm = (CMenuItem)e.Node.Tag;
				txt_descrip.Text = itm.Description;
				txt_nom.Text = itm.Nom;
				SetHelpAssociee(itm.Help);
				//ctrl_liesA.Initialiser(itm, m_bModeEdition);
			}
			else
			{
				bChangement = pan_edit.Visible;
				pan_edit.Visible = false;
			}

			if (bChangement && ChangementTaille != null)
				ChangementTaille(sender, new EventArgs());
			m_lastNodeEnEdition = e.Node;
		}

		private void SetHelpAssociee(CHelpData help)
		{
			m_lblHelpLiee.Text = help == null ? "" : help.NomCourt;
			if ( help != null )
				txt_nom.Text = help.NomCourt;
			m_helpAssociee = help;
		}


		//-----------------------------------------------------
		private void btn_up_Click(object sender, EventArgs e)
		{
			if (m_arbreMenu.SelectedNode != null)
			{
				CMenuItem itm = (CMenuItem)m_arbreMenu.SelectedNode.Tag;
				if (itm.MenuParent != null)
				{
					if (itm.MenuParent.MonterFils(itm))
					{
						TreeNode nodeParent = m_arbreMenu.SelectedNode.Parent;
						TreeNodeCollection nodes = m_arbreMenu.Nodes;
						if (nodeParent != null)
							nodes = nodeParent.Nodes;
						RefreshChilds(nodes, itm.MenuParent);
					}
				}
			}
		}
			
		private void btn_down_Click(object sender, EventArgs e)
		{
			if (m_arbreMenu.SelectedNode != null)
			{
				CMenuItem itm = (CMenuItem)m_arbreMenu.SelectedNode.Tag;
				if (itm.MenuParent != null)
				{
					if (itm.MenuParent.DescendreFils(itm))
					{
						TreeNode nodeParent = m_arbreMenu.SelectedNode.Parent;
						TreeNodeCollection nodes = m_arbreMenu.Nodes;
						if (nodeParent != null)
							nodes = nodeParent.Nodes;
						RefreshChilds(nodes, itm.MenuParent);
					}
				}
			}
		}

		private void btn_topere_Click(object sender, EventArgs e)
		{
			/*if (m_arbreMenu.SelectedNode != null)
			{
				TreeNode nselec = m_arbreMenu.SelectedNode;
				TreeNode npere = nselec.Parent;
				if (npere == null)
					return;
				else
				{
					npere.Nodes.Remove(nselec);

					if (npere.Parent != null)
						npere.Parent.Nodes.Insert(npere.Index + 1, nselec);
					else
						m_arbreMenu.Nodes.Insert(npere.Index + 1, nselec);

					CMenuItem itm = (CMenuItem)nselec.Tag;
					CMenuItem.RemonterEnPere(itm, m_mnu.Items);
				}
			}*/
		}

		//----------------------------------------------------------------------
		private void btn_tofils_Click(object sender, EventArgs e)
		{
			/*if (m_arbreMenu.SelectedNode != null)
			{
				TreeNode nselec = m_arbreMenu.SelectedNode;
				List<TreeNode> freres = RecupererLesFreres(nselec);

				//Si il est le seul il ne peut pas descendre
				if (freres.Count == 1)
					return;
				else
				{
					TreeNode npere = null;
					//C'est le premier il intègre le suivant
					if (nselec.Index == 0)
						npere = nselec.NextNode;
					//Dans tout les autres cas il intègre le précédant
					else
						npere = nselec.PrevNode;

					if (nselec.Parent == null)
						m_arbreMenu.Nodes.RemoveAt(nselec.Index);
					else
						nselec.Parent.Nodes.RemoveAt(nselec.Index);


					npere.Nodes.Add(nselec);
					CMenuItem itm = (CMenuItem)nselec.Tag;
					CMenuItem.RedescendreEnFils(itm, m_mnu.Items);
				}
			}*/
		}

		//----------------------------------------------------------------------
		private void btn_add_Click(object sender, EventArgs e)
		{
			CMenuItem menu = new CMenuItem(m_menu, I.T("New category|30039"));
			m_menu.AddItem(menu);
			RefreshChilds(m_arbreMenu.Nodes, m_menu);
		}

		/*//----------------------------------------------------------------------
		private void btn_supp_Click(object sender, EventArgs e)
		{
			if (m_arbreMenu.SelectedNode != null)
			{
				CMenuItem.Retirer((CMenuItem) m_arbreMenu.SelectedNode.Tag, m_mnu.Items);
				m_mnu.ActualiserMenuItems();
				m_arbreMenu.SelectedNode.Remove();
			}
		}*/


		//----------------------------------------------------------------------
		public void ValideModifs()
		{
			if (m_lastNodeEnEdition != null)
			{
				m_lastNodeEnEdition.Text = txt_nom.Text;
				CMenuItem mnuitm = (CMenuItem)m_lastNodeEnEdition.Tag;
				mnuitm.Nom = txt_nom.Text;
				mnuitm.Description = txt_descrip.Text;
				mnuitm.Help = m_helpAssociee;
				//mnuitm.Helps = ctrl_liesA.Selection;
			}
			
		}

		//----------------------------------------------------------------------
		public event EventHandler DoubleClickHelp;
		private void ctrl_liesA_DoubleClickHelp(object sender, EventArgs e)
		{
			if (DoubleClickHelp != null)
				DoubleClickHelp(sender, e);
		}

		//----------------------------------------------------------------------
		private void m_btnSelectHelp_Click(object sender, EventArgs e)
		{
			CHelpData help = CFormSelectHelpPage.SelectHelp();
			if (help != null)
			{
				SetHelpAssociee(help);
				ValideModifs();
			}
		}

		//----------------------------------------------------------------------
		public CHelpData HelpSelectionnee
		{
			get
			{
				TreeNode node = m_arbreMenu.SelectedNode;
				if (node != null)
				{
					if (node.Tag is CMenuItem)
					{
						CMenuItem item = (CMenuItem)node.Tag;
						if (item.Help != null)
							return item.Help;
					}
				}
				return null;
			}
		}

		//------------------------------------------------
		private void m_arbreMenu_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if ((e.Button & MouseButtons.Right) == MouseButtons.Right)
			{
				m_arbreMenu.SelectedNode = e.Node;
				Point pt = new Point(e.X, e.Y);
				m_menuArbre.Show(m_arbreMenu, pt);
			}
		}

		//-------------------------------------------------
		private void m_menuAjouter_Click(object sender, EventArgs e)
		{
			TreeNode node = m_arbreMenu.SelectedNode;
			if (node.Tag is CMenuItem)
			{
				CMenuItem itemParent = (CMenuItem)node.Tag;
                CMenuItem newItem = new CMenuItem(itemParent, I.T("New category|30039"));
				itemParent.AddItem(newItem);

				RefreshChilds(node.Nodes, (CMenuItem)node.Tag);
				node.Expand();
				foreach (TreeNode nodeFils in node.Nodes)
					if (nodeFils.Tag != null && nodeFils.Tag.Equals(newItem))
						m_arbreMenu.SelectedNode = nodeFils;
			}
		}

		//------------------------------------------------
		private void txt_nom_Validated(object sender, EventArgs e)
		{
			ValideModifs();
		}

		//-------------------------------------------------
		private void txt_descrip_Validated(object sender, EventArgs e)
		{
			ValideModifs();
		}

		//-------------------------------------------------
		private void m_btnNoHelpLiee_Click(object sender, EventArgs e)
		{
			SetHelpAssociee(null);
			ValideModifs();
		}

		//-------------------------------------------------
		private void m_menuSupprimer_Click(object sender, EventArgs e)
		{
			TreeNode node = m_arbreMenu.SelectedNode;
			if (node == null)
				return;
			CMenuItem item = (CMenuItem)node.Tag;
			if (CFormAlerte.Afficher(I.T("Delete the category |30040") + node.Text + " ?",
				EFormAlerteType.Question) == DialogResult.Yes)
			{
				if (item.MenuParent != null)
				{
					item.MenuParent.RemoveItem(item);
					if (node.Parent != null)
						node.Parent.Nodes.Remove(node);
					else
						m_arbreMenu.Nodes.Remove(node);
				}
			}
		}


		
		
	}
}
