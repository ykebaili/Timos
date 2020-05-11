using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using timos.data.projet.gantt;
using sc2i.win32.common;
using timos.win32.composants.gantt;
using timos.win32.composants;
using sc2i.win32.data.navigation;
using timos.data.projet.besoin;
using sc2i.data;
using sc2i.common;
using timos.data;
using sc2i.win32.data.dynamic;

namespace timos.win32.gantt
{

    
    public class CGanttTree : TreeView, IFournisseurYGantt, IControlALockEdition
    {
        private IBaseGantt m_baseGantt = null;
        Dictionary<IElementDeGantt, TreeNode> m_dicNodes = new Dictionary<IElementDeGantt, TreeNode>();

        private Color m_selectedBackColor = Color.LightBlue;
        private Color m_selectedForeColor = Color.Black;

        private const int WM_VSCROLL = 0x0115;
        private const int WM_MOUSEWHEEL = 0x020A;
        private Timer m_timerDelaiScroll;
        private bool m_bLockEdition = false;
        private ContextMenuStrip m_menuElement;
        private ToolStripMenuItem m_menuSortBy;
        
        //Indique qu'on est dans une opération de remplissage
        private bool m_bIsFilling = false;


        private System.ComponentModel.IContainer components;

        public CGanttTree()
        {
            InitializeComponent();
            m_menuSortBy.Click += new EventHandler(m_menuSortBy_Click);

        }

        
        

        public CParametreDessinLigneGantt ParametreDessinLigne
        {
            set
            {
                if (value != null)
                    ItemHeight = value.HauteurLigne;
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        
        public void Init(IBaseGantt gantt, DateTime dateDebut, DateTime dateFin)
        {
            DateTime dt = DateTime.Now;
            CTreeViewNodeKeeper keepNodes = new CTreeViewNodeKeeper(this);
            m_baseGantt = gantt;
            m_dicNodes.Clear();
            m_bIsFilling = true;
            Nodes.Clear();

            foreach (IElementDeGantt elt in from elt in gantt.GetElements() 
                                                where elt.ElementParent==null
                                                select elt)
            {
                TreeNode node = CreateNode(elt);
                Nodes.Add(node);
            }

            foreach ( TreeNode node in Nodes )
            {
                if ( node.Tag is CElementDeGanttProjet )
                {
                    CProjet projet = ((CElementDeGanttProjet)node.Tag).ProjetAssocie;
                    if (projet != null && projet.TypeProjet.DefaultExpand)
                        node.Expand();
                }
            }

            keepNodes.Apply(this);
            m_bIsFilling = false;
            TimeSpan sp = DateTime.Now - dt;
            //Console.WriteLine("Fill tree : " + sp.TotalMilliseconds);

        }

        public void RefreshNode(IElementDeGantt elt)
        {
            if (elt != null)
            {
                TreeNode node = null;
                if (m_dicNodes.TryGetValue(elt, out node))
                    FillNode(node, elt);
            }
        }

        private TreeNode CreateNode(IElementDeGantt elt)
        {
            TreeNode node = new TreeNode();
            FillNode(node, elt);
            m_dicNodes[elt] = node;
            foreach (IElementDeGantt eltDraw in elt.ElementsADessinerSurLaLigne)
            {
                m_dicNodes[eltDraw] = node;
            }
            if (elt.ElementsFils.Count() != 0)
            {
                node.Nodes.Add(new TreeNode());
            }
            return node;
        }

        public Color SelectedBackColor
        {
            get
            {
                return m_selectedBackColor;
            }
            set
            {
                m_selectedBackColor = value;
            }
        }

        public Color SelectedForeColor
        {
            get
            {
                return m_selectedForeColor;
            }
            set
            {
                m_selectedForeColor = value;
            }
        }

        private void FillNode(TreeNode node, IElementDeGantt elt)
        {
            try
            {
                node.Text = elt.Libelle;
                node.Tag = elt;
            }
            catch { }

        }

        private void m_arbre_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode node = e.Node;
            if (node.Nodes.Count == 1 && node.Nodes[0].Tag == null)
            {
                DateTime dt = DateTime.Now;

                FillChilds(node, null);


                TimeSpan sp = DateTime.Now - dt;
                //Console.WriteLine("Fill childs " + sp.TotalMilliseconds);
            }
        }

        private void FillChilds ( TreeNode node, CParametreTriGantt parametreTri )
        {
            m_bIsFilling = true;
            node.Nodes.Clear();
            IElementDeGantt eltParent = node.Tag as IElementDeGantt;
            if (parametreTri == null)
                parametreTri = CTimosAppRegistre.GetParametreTriGantt(eltParent);
            eltParent.SortChilds(parametreTri);
            List<TreeNode> lstToAdd = new List<TreeNode>();
            foreach (IElementDeGantt elt in eltParent.ElementsFils)
            {
                TreeNode nodeFils = CreateNode(elt);
                lstToAdd.Add(nodeFils);
                if (elt is CElementDeGanttProjet && ((CElementDeGanttProjet)elt).ProjetAssocie.TypeProjet.DefaultExpand)
                    nodeFils.Expand();
            }
            node.Nodes.AddRange ( lstToAdd.ToArray() );
            m_bIsFilling = false;
            
        }


        public int[] GetYBounds(IElementDeGantt element)
        {
            TreeNode node = null;
            if (!m_dicNodes.TryGetValue(element, out node))
                return null;
            Rectangle rct = node.Bounds;
            if (rct.Height == 0)
                return null;
            return new int[] {
                rct.Top, rct.Bottom };
        }

        /// <summary>
        /// Se déclenche lorsqu'un élément change de position
        /// </summary>
        public event EventHandler OnChangePosition;

        private void m_arbre_SendRefresh(object sender, EventArgs e)
        {
            if (OnChangePosition != null)
                OnChangePosition(this, null);
        }

        private void m_arbre_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (OnChangePosition != null)
                OnChangePosition(this, null);
        }

        private void m_arbre_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            if (OnChangePosition != null)
                OnChangePosition(this, null);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.m_timerDelaiScroll = new System.Windows.Forms.Timer(this.components);
            this.m_menuElement = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_menuSortBy = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuElement.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_timerDelaiScroll
            // 
            this.m_timerDelaiScroll.Interval = 500;
            this.m_timerDelaiScroll.Tick += new System.EventHandler(this.m_timerDelaiScroll_Tick);
            // 
            // m_menuElement
            // 
            this.m_menuElement.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_menuSortBy});
            this.m_menuElement.Name = "m_menuElement";
            this.m_menuElement.Size = new System.Drawing.Size(192, 48);
            // 
            // m_menuSortBy
            // 
            this.m_menuSortBy.Name = "m_menuSortBy";
            this.m_menuSortBy.Size = new System.Drawing.Size(191, 22);
            this.m_menuSortBy.Text = "Sort|20011";
            // 
            // CGanttTree
            // 
            this.AllowDrop = true;
            this.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.HideSelection = false;
            this.ItemHeight = 22;
            this.LineColor = System.Drawing.Color.Black;
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CGanttTree_MouseDoubleClick);
            this.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.m_arbre_AfterCollapse);
            this.DragLeave += new System.EventHandler(this.CGanttTree_DragLeave);
            this.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.CGanttTree_DrawNode);
            this.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.m_arbre_BeforeExpand);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.CGanttTree_DragDrop);
            this.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.CGanttTree_AfterSelect);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CGanttTree_MouseDown);
            this.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.CGanttTree_NodeMouseClick);
            this.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.m_arbre_AfterExpand);
            this.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.CGanttTree_ItemDrag);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.CGanttTree_DragOver);
            this.m_menuElement.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void CGanttTree_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (m_bIsFilling)
                return;
            Pen pen = new Pen(ForeColor);
            Color back = BackColor;
            if (e.Node == SelectedNode)
                back = SelectedBackColor;
            Brush br = new SolidBrush ( back );
            e.Graphics.FillRectangle(br, new Rectangle(e.Bounds.Left, e.Bounds.Top, ClientSize.Width, ItemHeight));
            br.Dispose();
            e.Graphics.DrawLine ( pen, 0, e.Bounds.Top, ClientSize.Width, e.Bounds.Top );
            e.Graphics.DrawLine(pen, 0, e.Bounds.Bottom, ClientSize.Width, e.Bounds.Bottom);
            pen.Dispose();
            if (e.Node == SelectedNode)
            {
                e.Node.BackColor = SelectedBackColor;
                e.Node.ForeColor = SelectedForeColor;
            }
            else
            {
                e.Node.BackColor = Color.Transparent;
                e.Node.ForeColor = ForeColor;
            }
            br = new SolidBrush(e.Node.ForeColor);
            IElementDeGantt elt = e.Node.Tag as IElementDeGantt;
            int nOffestX = 0;
            if (elt != null && elt.Image != null)
            {
                e.Graphics.DrawImageUnscaled(elt.Image, e.Bounds.Left, e.Bounds.Top + e.Bounds.Height/2-elt.Image.Height/2);
                nOffestX += elt.Image.Width;
            }
            SizeF rctText = e.Graphics.MeasureString(e.Node.Text, Font);
            e.Graphics.DrawString(e.Node.Text, Font, br, e.Bounds.Left + nOffestX, e.Bounds.Top + e.Bounds.Height/2 -((int)rctText.Height/2));
            br.Dispose();
        }

        public event EventHandler SelectionChanged;

        //----------------------------------------------
        public IElementDeGantt SelectedElement
        {
            get
            {
                if (SelectedNode != null)
                    return SelectedNode.Tag as IElementDeGantt;
                return null;
            }
            set
            {
                if (value != SelectedElement)
                {
                    TreeNode node = null;
                    if (value != null)
                        m_dicNodes.TryGetValue(value, out node);
                    if ( node == null && m_baseGantt != null && value != null)
                    {
                        IElementDeGantt eltSel = m_baseGantt.GetElements().FirstOrDefault ( 
                            e=>e.ElementKey == value.ElementKey);
                        if ( eltSel != null )
                        {
                            CreateNodeAndHierarchie(eltSel);
                            m_dicNodes.TryGetValue ( eltSel, out node );
                        }
                    }
                    SelectedNode = node;
                    if ( node != null )
                        node = node.Parent;
                    while (node != null && !node.IsExpanded)
                    {
                        node.Expand();
                        node = node.Parent;
                    }
                }
            }
        }

        private TreeNode CreateNodeAndHierarchie(IElementDeGantt eltGantt)
        {
            TreeNode nodeParent = null;
            if (eltGantt.ElementParent != null)
                nodeParent = CreateNodeAndHierarchie(eltGantt.ElementParent);
            if (nodeParent != null && !nodeParent.IsExpanded)
                nodeParent.Expand();
            TreeNode node = null;
            m_dicNodes.TryGetValue(eltGantt, out node);
            return node;
        }

        private void CGanttTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (SelectionChanged != null)
                SelectionChanged(this, new EventArgs());
        }

        protected override void WndProc(ref Message m)
        {
            try
            {
                base.WndProc(ref m);
            }
            catch { }
            if (OnChangePosition != null && m.Msg == WM_VSCROLL)
            {
                if (MouseButtons == MouseButtons.None)
                {
                    m_timerDelaiScroll.Stop();
                    OnChangePosition(this, new EventArgs());
                }
                else
                {
                    m_timerDelaiScroll.Stop();
                    m_timerDelaiScroll.Start();
                }
            }
            if (OnChangePosition != null && m.Msg == WM_MOUSEWHEEL)
            {
                OnChangePosition(this, new EventArgs());
            }
                
            
        }

        private void m_timerDelaiScroll_Tick(object sender, EventArgs e)
        {
            if (OnChangePosition != null)
                OnChangePosition(this, new EventArgs());
            m_timerDelaiScroll.Enabled = false;
        }

        public event GanttElementEventHandler ElementGanttMouseDown;
        public event GanttElementEventHandler ElementGanttDoubleClick;

        //------------------------------------------------------------------
        private void CGanttTree_MouseDown(object sender, MouseEventArgs e)
        {
            IEnumerable<IElementDeGantt> elts = from kv in m_dicNodes
                                                where
                                                    kv.Value.Bounds.Top < e.Y &&
                                                    kv.Value.Bounds.Bottom > e.Y
                                                select kv.Key;
            if (elts.Count() != 0)
            {
                SelectedElement = elts.ElementAt(0);
                if (ElementGanttMouseDown != null)
                {
                    ElementGanttMouseDown(
                        this, new CGanttElementEventArgs(
                            SelectedElement,
                            PointToScreen(new Point(e.X, e.Y)),
                            e.Button));
                }
            }
        }

        private void CGanttTree_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            IEnumerable<IElementDeGantt> elts = from kv in m_dicNodes
                                                where
                                                    kv.Value.Bounds.Top < e.Y &&
                                                    kv.Value.Bounds.Bottom > e.Y
                                                select kv.Key;
            if (elts.Count() != 0)
            {
                SelectedElement = elts.ElementAt(0);
                if (ElementGanttDoubleClick != null)
                {
                    ElementGanttDoubleClick(
                        this, new CGanttElementEventArgs(
                            SelectedElement,
                            PointToScreen(new Point(e.X, e.Y)),
                            e.Button));
                }
            }
        }

        //------------------------------------------------------------------------
        private void CGanttTree_ItemDrag(object sender, ItemDragEventArgs e)
        {
            TreeNode node = e.Item as TreeNode;

            DataObject obj = new DataObject(e.Item);
            if (node != null && node.Tag is CElementDeGanttProjet)
            {
                obj.SetData(new CReferenceObjetDonnee(((CElementDeGanttProjet)node.Tag).ProjetAssocie));
            }
            this.DoDragDrop(obj, DragDropEffects.Move | DragDropEffects.Copy | DragDropEffects.Link);
        }

        private Rectangle m_rectZoneDestDragDrop = new Rectangle(0, 0, 0, 0);
        private void UndrawZoneDestDragDrop()
        {
            if (m_rectZoneDestDragDrop.Width > 0)
            {
                Invalidate(m_rectZoneDestDragDrop);
                Update();
            }
        }


        //------------------------------------------------------------------------
        private void CGanttTree_DragDrop(object sender, DragEventArgs e)
        {
            UndrawZoneDestDragDrop();
            if (e.Data.GetDataPresent(typeof(TreeNode)) && !LockEdition)
            {
                TreeNode nodeMoved = e.Data.GetData(typeof(TreeNode)) as TreeNode;
                Point pt = PointToClient(new Point(e.X, e.Y));
                TreeNode nodeDest = null;
                bool bAfter = false;
                GetDestDragDrop(nodeMoved, pt, ref nodeDest, ref bAfter);
                if (nodeDest != null)
                {
                    TreeNodeCollection nodes = nodeDest.Parent != null ? nodeDest.Parent.Nodes : Nodes;
                    int nIndexMoved = nodes.IndexOf(nodeMoved);
                    nodes.Remove(nodeMoved);
                    int nIndexDest = nodes.IndexOf(nodeDest) + (bAfter ? 1 : 0);
                    if (nIndexDest != nIndexMoved)
                    {
                        if (nIndexDest >= nodes.Count)
                            nodes.Add(nodeMoved);
                        else
                            nodes.Insert(nIndexDest, nodeMoved);
                        RenumerotteElements(nodes);
                        SelectedNode = nodeMoved;
                        if (OnChangePosition != null)
                            OnChangePosition(this, null);
                        IElementDeGantt parent = nodeMoved.Tag as IElementDeGantt;
                        if (parent != null)
                            parent = parent.ElementParent;
                        CTimosAppRegistre.SetParametreTriGantt(parent, null);
                    }
                }
            }
        }

        //------------------------------------------------------------------------
        private void RenumerotteElements(TreeNodeCollection nodes)
        {
            int nIndex = 0;
            foreach (TreeNode node in nodes)
            {
                IElementDeGantt elt = node.Tag as IElementDeGantt;
                if (elt.CanBeSortedInParent)
                    elt.IndexTri = nIndex++;
            }

        }


        //------------------------------------------------------------------------
        private void CGanttTree_DragLeave(object sender, EventArgs e)
        {
            UndrawZoneDestDragDrop();
        }

        //------------------------------------------------------------------------
        void GetDestDragDrop(TreeNode nodeMoved, Point ptSourisClient, ref TreeNode nodeDest, ref bool bAfter)
        {
            IElementDeGantt elt = nodeMoved.Tag as IElementDeGantt;
            if ( elt == null || LockEdition)
                return;

            TreeNode nodeSousSouris = GetNodeAt(ptSourisClient);

            if (nodeSousSouris != null && nodeSousSouris != nodeMoved && nodeSousSouris.Parent == nodeMoved.Parent)
            {
                nodeDest = nodeSousSouris;
                Rectangle rct = nodeDest.Bounds;
                bAfter = ptSourisClient.Y > rct.Top + rct.Height / 2;
            }
            else
                nodeDest = null;
        }

        //------------------------------------------------------------------------
        private void CGanttTree_DragOver(object sender, DragEventArgs e)
        {
            UndrawZoneDestDragDrop();
            if (e.Data.GetDataPresent(typeof(TreeNode)) && !LockEdition)
            {
                TreeNode nodeMoved = e.Data.GetData(typeof(TreeNode)) as TreeNode;
                TreeNode nodeDest = null;
                bool bAfter = false;
                Point pt = PointToClient(new Point(e.X, e.Y));
                GetDestDragDrop(nodeMoved, pt, ref nodeDest, ref bAfter);
                if ( nodeDest != null )
                {
                    e.Effect = DragDropEffects.Move;
                    Rectangle rct = nodeDest.Bounds;
                    using (Graphics g = CreateGraphics())
                    {
                        Brush br = new System.Drawing.Drawing2D.HatchBrush(System.Drawing.Drawing2D.HatchStyle.DottedGrid, Color.Black, Color.Blue);
                        int nY = rct.Top;
                        if (bAfter)
                            nY = rct.Bottom;
                        m_rectZoneDestDragDrop = new Rectangle(0, nY - 1, Width , 3);
                        g.FillRectangle(br, m_rectZoneDestDragDrop);
                        br.Dispose();
                    }
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                    m_rectZoneDestDragDrop = new Rectangle(0, 0, 0, 0);
                }
            }
        }



        //--------------------------------------------------
        public bool LockEdition
        {
            get
            {
                return m_bLockEdition;
            }
            set
            {
                m_bLockEdition = value;
                if (OnChangeLockEdition != null)
                    OnChangeLockEdition(this, new EventArgs());
            }
        }

        //--------------------------------------------------
        public event EventHandler OnChangeLockEdition;

        private TreeNode m_treeNodeMenuContextuel = null;
        private void CGanttTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                m_treeNodeMenuContextuel = e.Node;
                CWin32Traducteur.Translate(m_menuElement);
                m_menuElement.Show(this, new Point(e.X, e.Y));
            }
        }

        
        void m_menuSortBy_Click(object sender, EventArgs e)
        {
            if (m_treeNodeMenuContextuel != null)
            {
                CParametreTriGantt parametre = CTimosAppRegistre.GetParametreTriGantt(m_treeNodeMenuContextuel.Tag as IElementDeGantt);
                if (  CFormTriGantt.GetParametre(ref parametre) )
                {
                    IElementDeGantt elt = m_treeNodeMenuContextuel.Tag as IElementDeGantt;
                    CTimosAppRegistre.SetParametreTriGantt(elt, parametre);
                    FillChilds(m_treeNodeMenuContextuel, parametre);
                    if (OnChangePosition != null)
                        OnChangePosition(this, null);
                    
                }
            }
        }

        //--------------------------------------------
        public ContextMenuStrip MenuRClick
        {
            get
            {
                return m_menuElement;
            }
        }

    }
}
