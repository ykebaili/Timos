using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using futurocom.snmp;

using sc2i.win32.common;
using futurocom.win32.snmp;
using futurocom.snmp.Mib;
using sc2i.common;

namespace SnmpTest
{
    public class CMibTree : TreeView, IMibNavigator
    {
        private CMibNavigatorHistory m_historique = new CMibNavigatorHistory();
        private IDefinition m_root = null;
        private ImageList m_imagesTree;
        private System.ComponentModel.IContainer components;
        //-------------------------------
        public CMibTree()
        {
            InitializeComponent();
            m_imagesTree.Images.AddRange(CSnmpIcons.GetImagesForDefinitionType());

        }

        //-------------------------------
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.m_imagesTree = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // m_imagesTree
            // 
            this.m_imagesTree.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.m_imagesTree.ImageSize = new System.Drawing.Size(16, 16);
            this.m_imagesTree.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // CMibTree
            // 
            this.ImageIndex = 0;
            this.ImageList = this.m_imagesTree;
            this.LineColor = System.Drawing.Color.Black;
            this.SelectedImageIndex = 0;
            this.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.CMibTree_BeforeExpand);
            this.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.CMibTree_AfterSelect);
            this.ResumeLayout(false);

        }

        //-------------------------------
        public IObjectTree ObjectTree
        {
            get
            {
                if (m_root != null)
                    return m_root.Tree;
                return null;
            }
        }

        //-------------------------------
        public void Init(IDefinition root)
        {
            m_root = root;
            CTreeViewNodeKeeper keeper = new CTreeViewNodeKeeper(this);
            Nodes.Clear();
            foreach (IDefinition def in root.Children)
            {
                TreeNode node = CreateNode(def);
                
                Nodes.Add(node);
            }
            keeper.Apply(this);
        }

        //-------------------------------
        private TreeNode CreateNode(IDefinition definition)
        {
            TreeNode node = new TreeNode(definition.Name);
            node.Tag = definition;
            int nImage = (int)definition.Type;
            if (nImage < 0 || nImage > m_imagesTree.Images.Count)
                nImage = 0;
            node.SelectedImageIndex = nImage;
            node.ImageIndex = nImage;
            if (definition.Children.Count() > 0)
            {
                node.Nodes.Add(new TreeNode());
            }
            return node;
        }

        //-------------------------------
        private TreeNode CreateNode(TrapType trap)
        {
            TreeNode node = new TreeNode(trap.Name);
            node.Tag = trap;
            int nImage = (int)DefinitionType.Notification;
            if (nImage < 0 || nImage > m_imagesTree.Images.Count)
                nImage = 0;
            node.SelectedImageIndex = nImage;
            node.ImageIndex = nImage;
            return node;
        }

        //-------------------------------
        private void CMibTree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            AssureChilds(e.Node);
            e.Node.EnsureVisible();
        }

        //-------------------------------
        private void AssureChilds ( TreeNode node )
        {
            if (node == null)
                return;
            if (node.Nodes.Count == 1 && node.Nodes[0].Tag == null)
            {
                node.Nodes.Clear();
                IDefinition def = node.Tag as IDefinition;
                if (def != null)
                {
                    foreach (IDefinition child in def.Children)
                    {
                        node.Nodes.Add(CreateNode(child));
                    }
                    if ( node.Nodes.Count == 1 )
                        node.Nodes[0].Expand();
                }
            }
        }

        //-------------------------------
        public IDefinition GetDefinition(TreeNode node)
        {
            if ( node != null )
                return node.Tag as IDefinition;
            return null;
        }

        //-------------------------------
        public IEntity GetEntity(TreeNode node)
        {
            IDefinition def = GetDefinition(node);
            if (def != null)
                return def.Entity;
            return null;
        }

        //-------------------------------
        public TrapType GetTrap(TreeNode node)
        {
            if (node != null)
                return node.Tag as TrapType;
            return null;
        }


        //-------------------------------
        public void NavigateTo(string strName)
        {
            NavigateTo(null, strName);
        }

        //-------------------------------
        private void NavigateTo(IDefinition definition)
        {
            if (definition != null)
            {
                TreeNode node = FindNode(definition);
                if (node != null)
                {
                    TreeNode parent = node.Parent;
                    while (parent != null)
                    {
                        parent.Expand();
                        parent = parent.Parent;
                    }
                    SelectedNode = node;
                }
            }
        }


        //-------------------------------
        public void NavigateTo(string strModule, string strName)
        {
            //Cherche la définitino
            if (m_root == null)
                return;
            IObjectTree tree = m_root.Tree;
            if (tree == null)
                return;
            IDefinition definition = strModule == null ? tree.Find(strName) : tree.Find(strModule, strName);
            NavigateTo(definition);
        }

        //-------------------------------
        private TreeNode FindNode(IDefinition definition)
        {
            if ( definition == null )
                return null;
            TreeNodeCollection nodes = Nodes;
            if (definition.ParentDefinition != null && definition.ParentDefinition.ParentDefinition != null)
            {
                TreeNode node = FindNode(definition.ParentDefinition);
                if (node == null)
                    return node;
                AssureChilds ( node );
                nodes = node.Nodes;

            }
            foreach (TreeNode child in nodes)
            {
                if (child.Tag == definition)
                    return child;
            }
            return null;
        }

       //-------------------------------
        public bool HasPrevious
        {
            get { return m_historique.HasPrevious; }
        }

        //-------------------------------
        public bool HasNext
        {
            get { return m_historique.HasNext; }
        }

        //-------------------------------
        public void GoToPrevious()
        {
            IDefinition def = m_historique.MovePrevious();
            NavigateTo(def);
        }

        //-------------------------------
        public void GoToNext()
        {
            IDefinition def = m_historique.MoveNext();
            NavigateTo(def);
        }

        //-------------------------------
        public IDefinition GetCurrent()
        {
            if (SelectedNode != null)
                return GetDefinition(SelectedNode);
            return null;
        }


        //-------------------------------
        private void CMibTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {
                IDefinition definition = GetDefinition(e.Node);
                m_historique.SetCurrent(definition);
            }
        }

        
    }
}
