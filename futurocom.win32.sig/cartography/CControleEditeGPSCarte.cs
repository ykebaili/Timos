using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sc2i.win32.common;
using futurocom.sig.cartography;
using sc2i.common;
using sc2i.common.sig;
using sc2i.win32.common.VEarth;
using GMap.NET.WindowsForms.Markers;
using sc2i.drawing;

namespace futurocom.win32.sig.cartography
{
    public partial class CControleEditeGPSCarte : UserControl, IControlALockEdition
    {
        private CGPSCarte m_carteEditee = null;
        private TreeNode m_nodeEdite = null;

        IEditeurItemCarte m_editeurEnCours = null;

        private CMapDatabase m_mapDatabase = new CMapDatabase();

        private Dictionary<Type, IEditeurItemCarte> m_dicEditeursAlloues = new Dictionary<Type,IEditeurItemCarte>();

        Cursor m_mapCursor = Cursors.Arrow;

        private Cursor m_curseurCreatePoint = C2iCursor.CreateCursorNoResize(Resource.CursorAddGPSPoint, new Point(0, 0));
        private Cursor m_curseurCreateLine = C2iCursor.CreateCursorNoResize(Resource.CursorAddGPSLine, new Point(0, 0));

        private IMapItem m_currentSelectedMapItem = null;

        private CGPSLine m_lineEnCoursEdition = null;

        private const string c_strLayerMoveOnMap = "##MOVEONMAP";

        private CMoveablePoint m_movingPoint = null;


        private enum EModeSouris
        {
            Selection,
            AddPoint,
            AddLine
        }

        private EModeSouris m_modeSouris = EModeSouris.Selection;

        //------------------------------------------------------------------------
        public CControleEditeGPSCarte()
        {
            InitializeComponent();
            m_wndMap.SetMapDatabase(m_mapDatabase);
            CreateDatabase();
            
        }

        //------------------------------------------------------------------------
        private void CreateDatabase()
        {
            m_mapDatabase = new CMapDatabase();
            m_mapDatabase.AddImage(c_strLayerMoveOnMap, Resource.PointToMoveOnMap);
        }

        //------------------------------------------------------------------------
        public CGPSCarte CarteEditee
        {
            get
            {
                return m_carteEditee;
            }
        }

        //------------------------------------------------------------------------
        public void Init ( CGPSCarte carteEditee )
        {
            m_carteEditee = carteEditee;
            DisplayItemProperties(null);
            m_btnModeSouris.Checked = true;
            FillArbre();
            UpdateMapDatabase();
            m_wndMap.AutoZoomAndCenter();
        }


        //------------------------------------------------------------------------
        private void FillArbre()
        {
            m_arbreCartographie.BeginUpdate();
            m_arbreCartographie.Nodes.Clear();
            if ( m_carteEditee != null )
            {
                TreeNode nodeRoot = new TreeNode(m_carteEditee.Libelle);
                nodeRoot.ImageIndex = 0;
                nodeRoot.Tag = m_carteEditee;
                nodeRoot.SelectedImageIndex = 0;
                m_arbreCartographie.Nodes.Add(nodeRoot);
                foreach ( CGPSPoint point in m_carteEditee.Points )
                {
                    TreeNode node = new TreeNode();
                    FillNode(node, point);
                    nodeRoot.Nodes.Add(node);
                }
                foreach ( CGPSLine ligne in m_carteEditee.Lignes )
                {
                    TreeNode node = new TreeNode();
                    FillNode(node, ligne);
                    nodeRoot.Nodes.Add(node);
                }
                nodeRoot.Expand();
            }
            m_arbreCartographie.EndUpdate();
        }

        //------------------------------------------------------------------------
        private void FillNode ( TreeNode node, CGPSPoint point )
        {
            node.Tag = point;
            node.Text = point.Libelle;
            node.ImageIndex = 1;
            node.SelectedImageIndex = 1;
        }

        //------------------------------------------------------------------------
        private void FillNode(TreeNode node, CGPSLine line)
        {
            m_bIsFillingTree = true;
            node.Nodes.Clear();
            node.Text = line.Libelle;
            node.ImageIndex = 2;
            node.SelectedImageIndex = 2;
            node.Tag = line;
            CGPSLineTrace trace = line.DetailLigne;
            int nIndex = 1;
            foreach ( CGPSLineSegment segment in trace.Segments )
            {
                TreeNode nodeSegment = new TreeNode();
                FillNode ( nodeSegment, segment );
                node.Nodes.Add(nodeSegment);
            }
            m_bIsFillingTree = false;
        }

        private static void FillNode(TreeNode nodeSegment, CGPSLineSegment segment)
        {
            nodeSegment.Text = segment.Libelle.Length == 0 ? I.T("Segment|20053") : segment.Libelle;
            if (segment.TypeLigne != null)
                nodeSegment.Text += "(" + segment.TypeLigne.Libelle + ")";
            nodeSegment.ImageIndex = nodeSegment.SelectedImageIndex = 3;
            nodeSegment.Tag = segment;
            nodeSegment.BackColor = segment.Couleur;
            nodeSegment.ForeColor = CUtilCouleur.GetCouleurVisibleSur(segment.Couleur);
        }

        //------------------------------------------------------------------------
        private void FillNodeFromObjet ( TreeNode node, object objet )
        {
            m_arbreCartographie.BeginUpdate();
            if (objet is CGPSPoint)
                FillNode(node, (CGPSPoint)objet);
            if (objet is CGPSLine)
                FillNode(node, (CGPSLine)objet);
            if (objet is CGPSLineSegment)
                FillNode(node, (CGPSLineSegment)objet);
            m_arbreCartographie.EndUpdate();
        }


        //------------------------------------------------------------------------
        public void UpdateCarteLabel()
        {
            TreeNode node = m_arbreCartographie.Nodes.Count > 0 ? m_arbreCartographie.Nodes[0] : null;
            if ( node != null && node.Tag is CGPSCarte && m_gestionnaireModeEdition.ModeEdition )
            {
                node.Text = ((CGPSCarte)node.Tag).Libelle;
            }
        }

        //------------------------------------------------------------------------
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

        //------------------------------------------------------------------------
        public event EventHandler OnChangeLockEdition;

        private void m_arbreCartographie_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Node.Tag is CGPSCarte)
            {
                ((CGPSCarte)e.Node.Tag).Libelle = e.Label;
                if ( OnCarteLabelChanged != null )
                    OnCarteLabelChanged ( this, new EventArgs() );
            }
            else if (e.Node.Tag is CGPSPoint)
                ((CGPSPoint)e.Node.Tag).Libelle = e.Label;
            else if (e.Node.Tag is CGPSLine)
                ((CGPSLine)e.Node.Tag).Libelle = e.Label;
            else if (e.Node.Tag is CGPSLineSegment)
                ((CGPSLineSegment)e.Node.Tag).Libelle = e.Label;
        }

        //------------------------------------------------------------------------
        private void m_arbreCartographie_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (!m_gestionnaireModeEdition.ModeEdition)
                e.CancelEdit = true;
        }

        public event EventHandler OnCarteLabelChanged;

        //------------------------------------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            EndLineEnCours();
            foreach ( CGPSLine line in m_carteEditee.Lignes )
            {
                line.DetailLigne = line.DetailLigne;
            }
            UpdateMapDatabase();
            return result;
        }

        //------------------------------------------------------------------------
        private void SetModeSouris()
        {
            if ( m_modeSouris == EModeSouris.AddLine && m_lineEnCoursEdition != null )
            {
                EndLineEnCours();
            }
            m_modeSouris = EModeSouris.Selection;
        }


        //------------------------------------------------------------------------
        private void m_btnModeSouris_CheckedChanged(object sender, EventArgs e)
        {
            SetModeSouris();
            m_mapCursor = Cursors.Arrow;
            m_wndMap.Cursor = m_mapCursor;
        }


        //------------------------------------------------------------------------
        private void m_btnAjoutPoint_CheckedChanged(object sender, EventArgs e)
        {
            SetModeAjoutPoint();
        }

        //------------------------------------------------------------------------
        private void SetModeAjoutPoint()
        {
            if (m_gestionnaireModeEdition.ModeEdition)
            {
                m_modeSouris = EModeSouris.AddPoint;
                m_mapCursor = m_curseurCreatePoint;
                m_wndMap.Cursor = m_mapCursor;
            }
        }

        //------------------------------------------------------------------------
        private void m_btnAjoutLigne_CheckedChanged(object sender, EventArgs e)
        {
            SetModeAjoutLigne();
        }

        //------------------------------------------------------------------------
        private void SetModeAjoutLigne()
        {
            if (m_gestionnaireModeEdition.ModeEdition)
            {
                m_modeSouris = EModeSouris.AddLine;
                m_mapCursor = m_curseurCreateLine;
                m_wndMap.Cursor = m_mapCursor;
                
            }
        }

        //------------------------------------------------------------------------
        private bool m_bIsMoving = false;
        Point m_pointStartMove;
        private void m_wndMap_OnEarthMouseDown(object sender, EarthMouseEventArgs args)
        {
            m_bIsMoving = false;

            if (m_modeSouris == EModeSouris.AddPoint)
            {
                MouseDownAddPoint(args);
            }
            if ( m_modeSouris == EModeSouris.AddLine )
            {
                MouseDownAddLine(args);
            }
            if ( m_modeSouris == EModeSouris.Selection && args.Buttons == MouseButtons.Left && m_gestionnaireModeEdition.ModeEdition)
            {
                
                //Cherche les points moveable
                foreach( IMapItem item in GetLayerMoveOnMap().Items )
                {
                    IWin32MapItem gItem = m_wndMap.GetGMapItemFromIMapItem(item);
                    GMarkerGoogle marker = gItem as GMarkerGoogle;
                    if ( marker.IsMouseOver )
                    {
                        m_movingPoint = gItem.Item.Tag as CMoveablePoint;
                        m_wndMap.CaptureOnMapWindow = true;
                        args.IsProcessed = true;
                        m_pointStartMove = args.MousePoint;
                    }
                }
            }
        }

        //------------------------------------------------------------------------
        private void MouseDownAddLine(EarthMouseEventArgs args)
        {
            args.IsProcessed = true;
            if (args.Buttons == System.Windows.Forms.MouseButtons.Left)
            {
                if (m_lineEnCoursEdition == null)
                {
                    m_lineEnCoursEdition = new CGPSLine(m_carteEditee.ContexteDonnee);
                    m_lineEnCoursEdition.CreateNewInCurrentContexte();
                    m_lineEnCoursEdition.Libelle = I.T("New line|20056");
                    m_lineEnCoursEdition.Carte = m_carteEditee;
                    CGPSLineTrace trace = m_lineEnCoursEdition.DetailLigne;
                    trace.PointDepart = new SLatLong(args.Latitude, args.Longitude);
                    TreeNode node = new TreeNode();
                    FillNode(node, m_lineEnCoursEdition);
                    m_arbreCartographie.Nodes[0].Nodes.Add(node);
                    m_arbreCartographie.SelectedNode = node;
                    m_wndMap.ShowMouseMarker(args.Latitude, args.Longitude);
                }
                else
                {
                    CGPSLineSegment segment = new CGPSLineSegment(m_lineEnCoursEdition.DetailLigne);
                    segment.PointDestination = new SLatLong(args.Latitude, args.Longitude);
                    CGPSLineTrace trace = m_lineEnCoursEdition.DetailLigne;
                    if (trace.Segments.Count() > 0)
                    {
                        CGPSLineSegment lastSeg = trace.Segments.ElementAt(trace.Segments.Count() - 1);
                        segment.Width = lastSeg.Width;
                        segment.Couleur = lastSeg.Couleur;
                    }
                    m_wndMap.ShowMouseMarker(args.Latitude, args.Longitude);
                    trace.AddSegment(segment);
                    foreach (IMapItem item in m_lineEnCoursEdition.FindMapItems(m_mapDatabase))
                    {
                        item.Layer.RemoveItem(item);
                        m_wndMap.DeleteItem(item);
                    }
                    foreach (IMapItem item in m_lineEnCoursEdition.CreateMapItems(m_mapDatabase.GetLayer(m_carteEditee.IdUniversel, true)))
                        m_wndMap.AddMapItem(item);
                    TreeNode node = FindNode(m_lineEnCoursEdition);
                    if (node != null)
                        FillNode(node, m_lineEnCoursEdition);
                    node = FindNode(segment);
                    if (node != null)
                        m_arbreCartographie.SelectedNode = node;

                }
            }
        }

        //------------------------------------------------------------------------
        private void MouseDownAddPoint(EarthMouseEventArgs args)
        {
            if (args.Buttons == MouseButtons.Left)
            {
                args.IsProcessed = true;
                CGPSPoint point = new CGPSPoint(m_carteEditee.ContexteDonnee);
                point.CreateNewInCurrentContexte();
                point.Libelle = I.T("New point|20050");
                point.Latitude = args.Latitude;
                point.Longitude = args.Longitude;
                point.Carte = m_carteEditee;
                TreeNode node = new TreeNode();
                FillNode(node, point);
                m_arbreCartographie.Nodes[0].Nodes.Add(node);
                m_arbreCartographie.SelectedNode = node;
                IEnumerable<IMapItem> items = point.CreateMapItems(m_mapDatabase.GetLayer(m_carteEditee.IdUniversel, true));
                foreach (IMapItem item in items)
                {
                    m_wndMap.AddMapItem(item);
                    //item.MouseClicked += item_MouseClicked;
                }
            }
        }

        //------------------------------------------------------------------------
        private void m_wndMap_OnEarthMouseMove(object sender, EarthMouseEventArgs args)
        {
            Console.WriteLine("MouseMove");
            if ( m_movingPoint != null && args.Buttons == MouseButtons.Left)
            {
                if ( !m_bIsMoving )
                {
                    if (Math.Abs(args.MousePoint.X - m_pointStartMove.X) > 3 ||
                        Math.Abs(args.MousePoint.Y - m_pointStartMove.Y) > 3)
                        m_bIsMoving = true;
                }
                if (m_bIsMoving)
                {
                    m_wndMap.Cursor = null;
                    m_movingPoint.MoveTo(new SLatLong(args.Latitude, args.Longitude));
                    foreach (IMapItem item in m_movingPoint.MapItems)
                        m_wndMap.RefreshItem(item);
                    if (m_movingPoint.ItemSurMap != null)
                        m_wndMap.RefreshItem(m_movingPoint.ItemSurMap);
                    args.IsProcessed = true;
                }
            }
            else
                m_wndMap.Cursor = m_mapCursor;
        }

        //------------------------------------------------------------------------
        private void m_wndMap_OnEarthMouseUp(object sender, EarthMouseEventArgs args)
        {
            if ( m_movingPoint != null && m_bIsMoving)
            {
                m_wndMap.Cursor = Cursors.SizeAll;
                m_movingPoint.MoveTo(new SLatLong(args.Latitude, args.Longitude));
                foreach (IMapItem item in m_movingPoint.MapItems)
                    m_wndMap.RefreshItem(item);
                if (m_movingPoint.ItemSurMap != null)
                    m_wndMap.RefreshItem(m_movingPoint.ItemSurMap);
                m_movingPoint = null;
                m_wndMap.CaptureOnMapWindow = false;
                if (m_editeurEnCours != null)
                    m_editeurEnCours.RefreshData();
            }
            m_wndMap.Cursor = m_mapCursor;
        }

        //------------------------------------------------------------------------
        public void UpdateMapDatabase()
        {
            if (m_carteEditee != null)
            {
                CreateDatabase();
                IEnumerable<CMapLayer> layers = m_carteEditee.GenereItems(m_mapDatabase);
                m_wndMap.SetMapDatabase(m_mapDatabase);
            }
        }

        //------------------------------------------------------------------------
        private void m_wndMap_MapItemClicked(CVEarthCtrl ctrl, MapItemClickEventArgs args)
        {
            IMapItem item = args.Item;
            if (item != null)
                SelectItemInTree(item);
            m_currentSelectedMapItem = item;
            if ( args.MouseArgs.Button == System.Windows.Forms.MouseButtons.Right )
            {
                
                m_menuItem.Show(this, new Point(args.MouseArgs.X, args.MouseArgs.Y));
            }
        }

        

        //------------------------------------------------------------------------
        private TreeNode FindNode ( object tag)
        {
            return FindNode(tag, m_arbreCartographie.Nodes);
        }


        //------------------------------------------------------------------------
        private TreeNode FindNode ( object tag, TreeNodeCollection nodes)
        { 
            if ( tag == null )
                return null;
            foreach ( TreeNode node in nodes )
            {
                if ( node.Tag != null && node.Tag.Equals(tag) || node.Tag == tag )
                {
                    m_arbreCartographie.SelectedNode = node;
                    return node;
                }
            }
            foreach ( TreeNode node in nodes )
            {
                TreeNode found = FindNode(tag, node.Nodes);
                if (found != null)
                    return found;
            }
            return null;
        }

        //------------------------------------------------------------------------
        private bool SelectItemInTree(IMapItem item)
        {
            TreeNode node = FindNode ( item.Tag, m_arbreCartographie.Nodes );
            if ( node != null )
            {
                m_arbreCartographie.SelectedNode = node;
            return true;
            }
            return false;
        }
            

        //------------------------------------------------------------------------
        private void UpdateCurrentNode()
        {
            if ( m_nodeEdite != null )
            {
                object tag = m_nodeEdite.Tag;
                if (tag is CGPSPoint)
                    FillNode(m_nodeEdite, (CGPSPoint)tag);
                if (tag is CGPSLine)
                    FillNode(m_nodeEdite, (CGPSLine)tag);
                if (tag is CGPSLineSegment)
                    FillNode(m_nodeEdite, (CGPSLineSegment)tag);
            }
        }

        //------------------------------------------------------------------------
        private bool m_bIsFillingTree = false;
        private void DisplayItemProperties(TreeNode node)
        {
            if (m_bIsFillingTree)
                return;
            object item = node!=null?node.Tag:null;
            if (m_editeurEnCours != null)
            {
                ((Control)m_editeurEnCours).Visible = false;
                m_panelPropriétés.Controls.Remove((Control)m_editeurEnCours);
            }
            m_editeurEnCours = null;
            m_nodeEdite = null;
            if (item != null)
                m_dicEditeursAlloues.TryGetValue(item.GetType(), out m_editeurEnCours);
            if (m_editeurEnCours == null && item != null)
            {
                Type tpEditeur = CGestionnaireEditionItemCarte.GetTypeEditeur(item.GetType());
                if (tpEditeur != null)
                {
                    m_editeurEnCours = Activator.CreateInstance(tpEditeur) as IEditeurItemCarte;
                    CWin32Traducteur.Translate(m_editeurEnCours);
                    m_editeurEnCours.OnModification += m_editeurEnCours_OnModification;
                    if (m_editeurEnCours != null)
                    {
                        m_dicEditeursAlloues[item.GetType()] = m_editeurEnCours;
                    }
                }
            }
            if (m_editeurEnCours != null)
            {
                Control ctrl = m_editeurEnCours as Control;
                ctrl.Dock = DockStyle.Fill;
                ctrl.Parent = m_panelPropriétés;
                ctrl.Visible = true;
                m_editeurEnCours.Init(item);
                m_nodeEdite = node;
                m_editeurEnCours.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
            }

            TreeNode nodeWithElementDeGpsCarte = GetNodeIElementDeGpsCarte(node); ;
            if (nodeWithElementDeGpsCarte != null)
                ShowMovePoints(nodeWithElementDeGpsCarte.Tag as IElementDeGPSCarte);

        }

        //------------------------------------------------------------------------
        private TreeNode GetNodeIElementDeGpsCarte(TreeNode node)
        {
            if (node == null)
                return null;
            if (node.Tag is IElementDeGPSCarte)
                return node;
            return GetNodeIElementDeGpsCarte(node.Parent);
        }

        //------------------------------------------------------------------------
        private void ShowMovePoints ( IElementDeGPSCarte elt )
        {
            ClearMovePoints();
            if ( elt != null )
            {
                foreach (CMoveablePoint point in elt.GetMoveablePoints(m_mapDatabase))
                    CreateMovePoint(point);
            }
            
        }

        //------------------------------------------------------------------------
        void m_editeurEnCours_OnModification(object sender, EventArgs e)
        {
            UpdateCurrentNode();
            TreeNode nodeEnCours = m_nodeEdite;
            if ( nodeEnCours != null )
            {
                nodeEnCours = GetNodeIElementDeGpsCarte(nodeEnCours);
            }
            if (nodeEnCours != null && nodeEnCours.Tag is IElementDeGPSCarte)
            {
                List<IMapItem> itemsToDelete = new List<IMapItem>();
                IEnumerable<IMapItem> items = ((IElementDeGPSCarte)nodeEnCours.Tag).UpdateMapItems(m_mapDatabase, itemsToDelete);
                foreach (IMapItem itemToDelete in itemsToDelete)
                    m_wndMap.DeleteItem(itemToDelete);
                foreach (IMapItem item in items)
                {
                    m_wndMap.RefreshItem(item);
                }
                if (itemsToDelete.Count() > 0)
                    ShowMovePoints((IElementDeGPSCarte)nodeEnCours.Tag);
            }
                
        }

        //------------------------------------------------------------------------
        private void m_arbreCartographie_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            DisplayItemProperties(e.Node);
        }

        //------------------------------------------------------------------------
        private void m_menuItem_Opening(object sender, CancelEventArgs e)
        {
            object tag = m_currentSelectedMapItem != null?m_currentSelectedMapItem.Tag : null;
            m_menuDeleteItem.Visible = tag is IElementDeGPSCarte && m_gestionnaireModeEdition.ModeEdition;
            m_menuAddAPoint.Visible = tag is CGPSLineSegment && m_gestionnaireModeEdition.ModeEdition;
            m_menuDeletePoint.Visible = tag is CMoveablePoint && ((CMoveablePoint)tag).IsDeletable;
        }

        //------------------------------------------------------------------------
        private void m_menuDeleteItem_Click(object sender, EventArgs e)
        {
            if ( m_currentSelectedMapItem != null && m_currentSelectedMapItem.Tag is IElementDeGPSCarte)
            {
                if ( MessageBox.Show(I.T("Delete this item ?|20055"), "", MessageBoxButtons.YesNo) == DialogResult.Yes )
                {
                    ((IElementDeGPSCarte)m_currentSelectedMapItem.Tag).DeleteThisMapItem();
                    m_currentSelectedMapItem = null;
                    DisplayItemProperties(null);
                    FillArbre();
                    UpdateMapDatabase();
                }
            }
        }

        
        //------------------------------------------------------------------------
        private void EndLineEnCours()
        {
            if ( m_lineEnCoursEdition != null )
            {
                foreach (IMapItem item in m_lineEnCoursEdition.FindMapItems(m_mapDatabase))
                {
                    item.Layer.RemoveItem(item);
                    m_wndMap.DeleteItem(item);
                }
                m_lineEnCoursEdition.DetailLigne = m_lineEnCoursEdition.DetailLigne;
                foreach (IMapItem item in m_lineEnCoursEdition.CreateMapItems(m_mapDatabase.GetLayer(m_carteEditee.IdUniversel, true)))
                    m_wndMap.AddMapItem(item);
                TreeNode node = FindNode(m_lineEnCoursEdition);
                if ( node != null )
                {
                    FillNodeFromObjet(node, m_lineEnCoursEdition);
                }
                m_lineEnCoursEdition = null;
                m_wndMap.HideMouseMarker();

            }
        }

        //------------------------------------------------------------------------
        private CMapLayer GetLayerMoveOnMap()
        {
            return m_mapDatabase.GetLayer(c_strLayerMoveOnMap, true);
        }

        //------------------------------------------------------------------------
        private CMapItemImage CreateMovePoint ( CMoveablePoint moveablePoint )
        {
            CMapItemImage item = new CMapItemImage(GetLayerMoveOnMap(), moveablePoint.Point.Latitude, moveablePoint.Point.Longitude, c_strLayerMoveOnMap);
            moveablePoint.ItemSurMap = item;
            item.Tag = moveablePoint;
            m_wndMap.AddMapItem(item);
            return item;
        }

        //------------------------------------------------------------------------
        private void ClearMovePoints()
        {
            foreach (IMapItem item in GetLayerMoveOnMap().Items.ToArray())
                m_wndMap.DeleteItem(item);
            GetLayerMoveOnMap().ClearItems();
        }

        //------------------------------------------------------------------------
        private void m_menuAddAPoint_Click(object sender, EventArgs e)
        {
            object tag = m_currentSelectedMapItem != null ? m_currentSelectedMapItem.Tag : null;
            CGPSLineSegment segment = tag as CGPSLineSegment;
            if ( segment != null )
            {
                segment.DiviseSegment();
                TreeNode node = m_arbreCartographie.SelectedNode;
                node = GetNodeIElementDeGpsCarte(node);
                if ( node != null )
                {
                    IElementDeGPSCarte elt = node.Tag as IElementDeGPSCarte;
                    if (elt != null)
                    {
                        foreach (IMapItem item in elt.FindMapItems(m_mapDatabase))
                        {
                            item.Layer.RemoveItem(item);
                            m_wndMap.DeleteItem(item);
                        }
                        foreach ( IMapItem item in elt.CreateMapItems(m_mapDatabase.GetLayer(m_carteEditee.IdUniversel)))
                            m_wndMap.AddMapItem(item);
                        FillNodeFromObjet(node, elt);
                        DisplayItemProperties(node);
                    }
                }
            }
        }

        private void m_menuDeletePoint_Click(object sender, EventArgs e)
        {
            CMoveablePoint movePoint = m_currentSelectedMapItem != null ? m_currentSelectedMapItem.Tag as CMoveablePoint: null;
            if ( movePoint != null && movePoint.IsDeletable )
            {
                foreach ( IMapItem item in movePoint.Delete(m_mapDatabase) )
                {
                    item.Layer.RemoveItem(item);
                    m_wndMap.DeleteItem(item);
                }
                TreeNode node = m_arbreCartographie.SelectedNode;
                node = GetNodeIElementDeGpsCarte(node);
                if (node != null)
                {
                    IElementDeGPSCarte elt = node.Tag as IElementDeGPSCarte;
                    if (elt != null)
                    {
                        foreach ( IMapItem item in elt.FindMapItems(m_mapDatabase) )
                        {
                            m_wndMap.RefreshItem(item);
                        }
                        FillNodeFromObjet(node, elt);
                        DisplayItemProperties(node);
                    }
                }
            }
        }

        //-------------------------------------------------------------------
        private void m_btnPhoto_Click(object sender, EventArgs e)
        {
            using (Image img = m_wndMap.ToImage() )
            {
                if (m_gestionnaireModeEdition.ModeEdition && m_carteEditee != null)
                    m_carteEditee.ImageCarte = img as Bitmap;
                Clipboard.SetImage(img);
            }
        }

       

        
    }
}
