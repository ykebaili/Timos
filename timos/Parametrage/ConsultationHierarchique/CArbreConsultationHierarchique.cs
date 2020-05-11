using System;
using System.Collections.Generic;
using System.Text;

using timos.data.workflow.ConsultationHierarchique;
using sc2i.data;
using System.Windows.Forms;
using CrystalDecisions.Enterprise;
using System.Reflection;
using System.Drawing;

namespace timos.Parametrage.ConsultationHierarchique
{
    public delegate DragDropEffects DragItemFromArbreConsultationEventHandler ( object sender, CNodeConsultationHierarchique node );

    public class CArbreConsultationHierarchique : TreeView
    {
        private CFolderConsultationHierarchique m_folderRoot = null;
        private CContexteDonnee m_contexteDonnee = null;
        private bool m_bAfficherElementRacine = false;

        private ImageList m_imageList = new ImageList();
        private Dictionary<CFolderConsultationHierarchique, int> m_dicIndexImages = new Dictionary<CFolderConsultationHierarchique, int>();

        //---------------------------------------------------
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (m_imageList != null)
                m_imageList.Dispose();
            m_imageList = null;
        }

        //---------------------------------------------------
        public CArbreConsultationHierarchique()
            :base()
        {
            InitializeComponent();
            ImageList = m_imageList;
            m_imageList.Images.Add(new Bitmap(1,1));
        }


        //---------------------------------------------------
        public void InitChamps(
            CFolderConsultationHierarchique folderRoot,
            CContexteDonnee contexteDonnee)
        {
            InitChamps(folderRoot, contexteDonnee, false);
        }

        
        //---------------------------------------------------
        public void InitChamps(
            CFolderConsultationHierarchique folderRoot,
            CContexteDonnee contexteDonnee,
            bool bAfficherElementRacine)
        {
            m_folderRoot = folderRoot;
            m_contexteDonnee = contexteDonnee;
            m_bAfficherElementRacine = bAfficherElementRacine;
            FillArbre();
        }



        //---------------------------------------------------
        private void FillArbre()
        {
            Nodes.Clear();
            CFolderConsultationRacineFromElement racineType = m_folderRoot as CFolderConsultationRacineFromElement;
            object source = null;
            TreeNode nodeParent = null;
            if (racineType != null)
            {
                source = racineType.ObjetRacine;
                IObjetDonnee donneSource = source as IObjetDonnee;
                nodeParent = new TreeNode(donneSource != null? donneSource.DescriptionElement : source.ToString());
                nodeParent.Tag = new CNodeConsultationHierarchique(source, racineType, null);

            }
            FillChilds(source, m_folderRoot, nodeParent);
            if (nodeParent != null)
            {
                if (m_bAfficherElementRacine)
                    Nodes.Add(nodeParent);
                else
                foreach (TreeNode node in nodeParent.Nodes)
                {
                    Nodes.Add(node);
                }
            }
        }

        //---------------------------------------------------
        private void FillChilds(object source, CFolderConsultationHierarchique folder, TreeNode nodeParent)
        {
            foreach (CFolderConsultationHierarchique folderFils in folder.SousFolders)
            {
                CreateNodes(source, folderFils, nodeParent);
            }
        }

        //---------------------------------------------------
        private void CreateNodes(object source, CFolderConsultationHierarchique folder, TreeNode nodeParent)
        {
            CNodeConsultationHierarchique dataParent = null;
            if (nodeParent != null)
                dataParent = nodeParent.Tag as CNodeConsultationHierarchique;
            object[] objets = folder.GetObjets(dataParent, m_contexteDonnee);
            if (objets != null)
            {
                foreach (object obj in objets)
                {
                    CNodeConsultationHierarchique data = new CNodeConsultationHierarchique(obj, folder, dataParent);
                    TreeNode node = CreateNode(data);
                    if (nodeParent != null)
                        nodeParent.Nodes.Add(node);
                    else
                        Nodes.Add(node);
                }
            }
        }

        private TreeNode CreateNode(CNodeConsultationHierarchique data)
        {
            string strLibelle = data.Folder.GetLibelleNode(data);
            TreeNode node = new TreeNode(strLibelle);
            node.Tag = data;
            node.BackColor = data.Folder.Couleur;
            int nIndex = -1;
            if (!m_dicIndexImages.TryGetValue(data.Folder, out nIndex))
            {
                nIndex = -1;
                Image bmp = data.Folder.Image;
                if (bmp != null)
                {
                    m_imageList.Images.Add(bmp);
                    nIndex = m_imageList.Images.Count - 1;
                }
                m_dicIndexImages[data.Folder] = nIndex;
            }
            if (nIndex >= 0)
            {
                node.ImageIndex = nIndex;
                node.SelectedImageIndex = nIndex;
            }
            

            IObjetDonneeAutoReference objAuto = data.ObjetLie as IObjetDonneeAutoReference;
            if (data.Folder.SousFolders.Length > 0 ||
                (objAuto != null))
            {
                TreeNode nodeDummy = new TreeNode();
                node.Nodes.Add(nodeDummy);
            }
            return node;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CArbreConsultationHierarchique
            // 
            this.LineColor = System.Drawing.Color.Black;
            this.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.CArbreConsultationHierarchique_BeforeExpand);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CArbreConsultationHierarchique_MouseUp);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CArbreConsultationHierarchique_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CArbreConsultationHierarchique_MouseDown);
            this.ResumeLayout(false);

        }

        private void CArbreConsultationHierarchique_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            using (sc2i.win32.common.CWaitCursor waiter = new sc2i.win32.common.CWaitCursor())
            {
                TreeNode node = e.Node;
                if (node.Nodes.Count == 1 && node.Nodes[0].Tag == null)
                {
                    node.Nodes.Clear();
                    CNodeConsultationHierarchique data = node.Tag as CNodeConsultationHierarchique;
                    IObjetDonneeAutoReference objetAutoRef = data.ObjetLie as IObjetDonneeAutoReference;
                    CFolderConsultationFolder folderParent = null;
                    folderParent = ((CNodeConsultationHierarchique)node.Tag).Folder as CFolderConsultationFolder;
                    if (objetAutoRef != null  && (folderParent == null))
                    {
                        string strProp = objetAutoRef.ProprieteListeFils;
                        PropertyInfo prop = objetAutoRef.GetType().GetProperty(strProp);
                        if (prop != null)
                        {
                            MethodInfo methode = prop.GetGetMethod();
                            if (methode != null)
                            {
                                CListeObjetsDonnees listeFils = methode.Invoke(objetAutoRef, new object[0]) as CListeObjetsDonnees;
                                if (listeFils != null)
                                {
                                    foreach (CObjetDonnee objet in listeFils)
                                    {
                                        CNodeConsultationHierarchique dataFils = new CNodeConsultationHierarchique(
                                            objet,
                                            data.Folder,
                                            node.Tag as CNodeConsultationHierarchique);
                                        TreeNode newNode = CreateNode(dataFils);
                                        node.Nodes.Add(newNode);
                                    }
                                }
                            }
                        }
                    }
                    foreach (CFolderConsultationHierarchique folderFils in data.Folder.SousFolders)
                        CreateNodes(data.ObjetLie, folderFils, node);
                }
            }
        }

        TreeNode m_nodeSurLequelOnAFaitMouseDown = null;
        Point m_pointSurLequelOnAFaitMouseDown = new Point(0, 0);
        private void CArbreConsultationHierarchique_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                m_pointSurLequelOnAFaitMouseDown = new Point(e.X, e.Y);
                TreeNode node = GetNodeAt(m_pointSurLequelOnAFaitMouseDown);
                m_nodeSurLequelOnAFaitMouseDown = node;
            }
        }

        private void CArbreConsultationHierarchique_MouseUp(object sender, MouseEventArgs e)
        {
            m_nodeSurLequelOnAFaitMouseDown = null;
        }

        public event DragItemFromArbreConsultationEventHandler OnDragNode;

        private void CArbreConsultationHierarchique_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left &&
                m_nodeSurLequelOnAFaitMouseDown != null)
            {
                if (Math.Abs(e.X - m_pointSurLequelOnAFaitMouseDown.X) > 3 ||
                    Math.Abs(e.Y - m_pointSurLequelOnAFaitMouseDown.Y) > 3)
                {
                    CNodeConsultationHierarchique node = m_nodeSurLequelOnAFaitMouseDown.Tag as CNodeConsultationHierarchique;
                    if (OnDragNode != null)
                    {
                        OnDragNode(this, node);
                    }
                }
            }
        }

    }
}
