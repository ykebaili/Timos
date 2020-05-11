using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common;
using timos.data.workflow.ConsultationHierarchique;
using sc2i.common;
using sc2i.formulaire;

namespace timos.Parametrage.ConsultationHierarchique
{
	public partial class CPanelEditConsultationHierarchique : UserControl, IControlALockEdition
	{
		/// <summary>
		/// Type de folder-> Type d'éditeur
		/// </summary>
		private static Dictionary<Type, Type> m_dicTypeToTypeEditeur = new Dictionary<Type,Type>();

		public static void RegisterTypeEditeur ( Type typeFolder, Type typeEditeur )
		{
			m_dicTypeToTypeEditeur[typeFolder] = typeEditeur;
		}


		private CFolderConsultationHierarchique m_folderRoot = null;

		private Dictionary<Type, IPanelEditionFolderConsultation> m_dicoControles = new Dictionary<Type, IPanelEditionFolderConsultation>();
		private IPanelEditionFolderConsultation m_controleEdition = null;
		private TreeNode m_nodeEdite = null;

        private Type[] m_typesFolders = new Type[0];
		
		public CPanelEditConsultationHierarchique()
		{
			InitializeComponent();
            m_typesFolders = new Type[]{
                typeof(CFolderConsultationFolder),
                typeof(CFolderConsultationFromFiltre),
                typeof(CFolderConsultationFromFormula)
            };
            InitMenuAdd();
		}

		#region IControlALockEdition Membres

		public bool LockEdition
		{
			get
			{
				return !m_extModeEdition.ModeEdition;
			}
			set
			{
				m_extModeEdition.ModeEdition = !value;
				if (OnChangeLockEdition != null)
					OnChangeLockEdition(this, new EventArgs());
			}
		}

		public event EventHandler OnChangeLockEdition;

		#endregion

        //----------------------------------------------------
        public Type[] TypesFolders
        {
            get{
                return m_typesFolders;
            }
            set{
                m_typesFolders = value;
                InitMenuAdd();
            }
        }

        private class CMenuForType : ToolStripMenuItem
        {
            private Type m_type;

            public CMenuForType ( string strText, Type tp )
                :base ( strText )
            {
                m_type = tp ;
            }

            public Type Type
            {
                get{
                    return m_type;
                }
            }
        }

            
        //----------------------------------------------------
        private void InitMenuAdd()
        {
            m_menuAdd.DropDownItems.Clear();
            foreach ( Type tp in m_typesFolders )
            {
                CFolderConsultationHierarchique folder = (CFolderConsultationHierarchique) Activator.CreateInstance ( tp, new object[]{null});
                CMenuForType menu = new CMenuForType ( folder.FolderTypeName, tp );
                m_menuAdd.DropDownItems.Add ( menu );
                menu.Click += new EventHandler(menuType_Click);
            }
        }

		//----------------------------------------------------
		public void  menuType_Click(object sender, EventArgs e)
        {
            CMenuForType menu = sender as CMenuForType;
            if (menu != null)
            {
                TreeNode node = CreateNewFolder(menu.Type);
                m_arbre.SelectedNode = node;
            }
        }

    
        public void InitChamps(CFolderConsultationHierarchique folder,
            Type[] typesFoldersPossibles)
		{
            if ( typesFoldersPossibles != null )
                TypesFolders = typesFoldersPossibles;
			m_folderRoot = folder;
            m_arbre.Nodes.Clear();
            CFolderConsultationRacineFromElement racineType = folder as CFolderConsultationRacineFromElement;
            if (racineType != null)
            {
                TreeNode node = CreateNode(racineType);
                m_arbre.Nodes.Add(node);
                FillNodes(m_folderRoot, node.Nodes);
            }
            else
			    FillNodes(m_folderRoot, m_arbre.Nodes);
		}

		//----------------------------------------------------
		public CResultAErreur MajChamps()
		{
			if (m_controleEdition != null)
				return m_controleEdition.MajChamps();
			return CResultAErreur.True;
		}

		//----------------------------------------------------
		private void FillNodes(CFolderConsultationHierarchique folder, TreeNodeCollection nodes)
		{
			foreach (CFolderConsultationHierarchique folderFils in folder.SousFolders)
			{
				TreeNode node = CreateNode(folderFils);
                nodes.Add(node);
				FillNodes(folderFils, node.Nodes);
			}
		}


		//----------------------------------------------------
		private TreeNode CreateNode(CFolderConsultationHierarchique folder)
		{
			TreeNode node = new TreeNode(folder.Libelle);
			node.Tag = folder;
			return node;
		}

		
		//----------------------------------------------------
		private void m_arbre_AfterSelect(object sender, TreeViewEventArgs e)
		{
            AfterSelect(e.Node);
        }

        private void AfterSelect ( TreeNode node )
        {
			if (!LockEdition && m_controleEdition != null)
			{
				m_controleEdition.MajChamps();
				m_nodeEdite.Text = ((CFolderConsultationHierarchique)m_nodeEdite.Tag).Libelle;
			}
            if ( m_controleEdition != null )
                ((Control)m_controleEdition).Visible = false;
			m_controleEdition = null;
			m_nodeEdite = null;
			if (node != null)
			{
                CFolderConsultationHierarchique folder = node.Tag as CFolderConsultationHierarchique;
				if (folder != null)
				{
					Type tpFolder = folder.GetType();
					IPanelEditionFolderConsultation panelEdition = null;
					if (!m_dicoControles.TryGetValue(tpFolder, out panelEdition))
					{
						Type tpEditeur = null;
						if (m_dicTypeToTypeEditeur.TryGetValue(tpFolder, out tpEditeur))
						{
							panelEdition = Activator.CreateInstance(tpEditeur) as IPanelEditionFolderConsultation;
							if (panelEdition != null)
							{
								Control ctrl = panelEdition as Control;
								ctrl.Parent = m_panelEdition;
								m_panelEdition.Controls.Add(ctrl);
								ctrl.Dock = DockStyle.Fill;
								m_dicoControles[tpFolder] = panelEdition;
							}
						}
					}
					if (panelEdition != null)
					{
						((Control)panelEdition).Visible = true;
						panelEdition.InitChamps(folder);
                        ((IControlALockEdition)panelEdition).LockEdition = !m_extModeEdition.ModeEdition;
					}
					m_controleEdition = panelEdition;
                    m_nodeEdite = node;
				}
			}
		}

		private void m_arbre_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			
		}

		private void m_arbre_MouseUp(object sender, MouseEventArgs e)
		{
			if ((e.Button & MouseButtons.Right) == MouseButtons.Right)
			{
				Point pt = new Point(e.X, e.Y);
                TreeViewHitTestInfo info = m_arbre.HitTest(pt);
                m_arbre.SelectedNode = info.Node;
                AfterSelect(m_arbre.SelectedNode);
				pt = m_arbre.PointToScreen(pt);
				ShowContextMenu(pt);
			}
		}

		private void ShowContextMenu(Point pt)
		{
            if (LockEdition)
                return;
			m_menuSupprimer.Visible = m_arbre.SelectedNode != null;
			m_menuArbre.Show ( pt );
		}

		private TreeNode CreateNewFolder( Type type)
		{
			CFolderConsultationHierarchique folderParent = m_folderRoot;
			if (m_arbre.SelectedNode != null)
				folderParent = m_arbre.SelectedNode.Tag as CFolderConsultationHierarchique;
			CFolderConsultationHierarchique newFolder = Activator.CreateInstance(type, new object[] { folderParent }) as CFolderConsultationHierarchique;
			folderParent.AddFolder(newFolder);
			TreeNode node = CreateNode(newFolder);
			if (m_arbre.SelectedNode != null)
				m_arbre.SelectedNode.Nodes.Add(node);
			else
				m_arbre.Nodes.Add(node);
			return node;
		}


		private void m_menuSupprimer_Click(object sender, EventArgs e)
		{
			if ( m_arbre.SelectedNode != null )
			{
				TreeNode nodeParent = m_arbre.SelectedNode.Parent;
				CFolderConsultationHierarchique folderParent = null;
				if ( nodeParent != null )
					folderParent = nodeParent.Tag as CFolderConsultationHierarchique;
				else
					folderParent = m_folderRoot;
                CFolderConsultationRacineFromElement racineType = m_arbre.SelectedNode.Tag as CFolderConsultationRacineFromElement;
                if ( racineType != null )
                {
                    CFormAlerte.Afficher(I.T("Can not delete that node|20107"));
                    return;
                }
				folderParent.RemoveFolder ( m_arbre.SelectedNode.Tag as CFolderConsultationHierarchique );
				if ( nodeParent != null )
					nodeParent.Nodes.Remove ( m_arbre.SelectedNode );
				else
					m_arbre.Nodes.Remove ( m_arbre.SelectedNode );
			}
		}

		public CFolderConsultationHierarchique Folder
		{
			get
			{
				return m_folderRoot;
			}
		}
	}
}
