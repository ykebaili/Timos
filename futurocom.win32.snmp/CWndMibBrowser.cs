using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using futurocom.snmp;
using System.Collections;
using sc2i.common;
using sc2i.win32.common;
using futurocom.snmp.Mib;

namespace futurocom.win32.snmp
{
    public partial class CWndMibBrowser : UserControl, IMibNavigator
    {
        private CSnmpConnexion m_connexion = null;
        private IDefinition m_root = null;
        /// <summary>
        /// Stock les viewers déjà alloués
        /// </summary>
        private Dictionary<Type, ISNMPClassViewer> m_dicViewerConnus = new Dictionary<Type,ISNMPClassViewer>();
        private CPanelDetailTrap m_panelDetailTrap = null;

        //--------------------------------------------------------------------
        public CWndMibBrowser()
        {
            InitializeComponent();
            m_wndListe.MibNavigator = this;
            m_slideListe.Collapse();
        }

        //--------------------------------------------------------------------
        public void Init(IDefinition rootDefinition, CSnmpConnexion connexion)
        {
            m_root = rootDefinition;
            m_connexion = connexion;
            m_mibTree.Init(rootDefinition);
        }

        //--------------------------------------------------------------------
        public IDefinition RootDefinition
        {
            get
            {
                return m_root;
            }
        }

        //--------------------------------------------------------------------
        private void m_mibTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DisplayDefinition(e.Node);
        }

        public event EventHandler SelectedDefinitionChanged;


        //--------------------------------------------------------------------
        private void DisplayDefinition(TreeNode node)
        {
            m_panelViewer.SuspendDrawing();
            //Masque le viewer visible
            foreach (Control ctrl in m_panelViewer.Controls)
                ctrl.Visible = false;

            IDefinition definition = m_mibTree.GetDefinition(node);
            if (definition != null)
            {
                m_lblType.Text = definition.Name + " (" + CUtilSurEnum.GetNomConvivial(definition.Type.ToString()) + ")";
                Type tpViewer = CSNMPClassViewer.GetViewerTypeFor(definition);
                if (tpViewer != null)
                {
                    ISNMPClassViewer viewer = null;
                    if (!m_dicViewerConnus.TryGetValue(tpViewer, out viewer))
                    {
                        viewer = Activator.CreateInstance(tpViewer, null) as ISNMPClassViewer;
                        m_panelViewer.Controls.Add((Control)viewer);
                        ((Control)viewer).Dock = DockStyle.Fill;
                        m_dicViewerConnus[tpViewer] = viewer;
                    }
                    ((Control)viewer).Visible = true;
                    viewer.DisplayElement(definition);
                    viewer.MibNavigator = this;
                }
            }
            /*else
            {
                TrapType trap = m_mibTree.GetTrap(node);
                if (trap != null)
                {
                    m_lblType.Text = trap.Name + " (" + I.T("Trap|20107") + ")";
                    if (m_panelDetailTrap == null)
                    {
                        m_panelDetailTrap = new CPanelDetailTrap();
                        m_panelViewer.Controls.Add(m_panelDetailTrap);
                        ((Control)m_panelDetailTrap).Dock = DockStyle.Fill;
                    }
                    m_panelDetailTrap.Visible = true;
                    m_panelDetailTrap.DisplayElement(trap);
                    m_panelDetailTrap.MibNavigator = this;
                }
            }*/
                        
            m_panelViewer.ResumeDrawing();
            UpdateBoutonsNavigation();
            if (SelectedDefinitionChanged != null)
                SelectedDefinitionChanged(this, null);
        }

        //--------------------------------------------
        public IDefinition SelectedDefinition
        {
            get
            {
                TreeNode node = m_mibTree.SelectedNode;
                if (node != null)
                    return node.Tag as IDefinition;
                return null;
            }
        }


        //----------------------------------------------------
        public void NavigateTo(string strName)
        {
            NavigateTo(null, strName );
        }

        //----------------------------------------------------
        public void NavigateTo(string strModule, string strName)
        {
            m_mibTree.NavigateTo(strModule, strName);
        }

        //----------------------------------------------------
        public IObjectTree ObjectTree
        {
            get
            {
                return m_mibTree.ObjectTree;
            }
        }

        //----------------------------------------------------
        public bool HasPrevious
        {
            get { return m_mibTree.HasPrevious; }
        }

        //----------------------------------------------------
        public bool HasNext
        {
            get { return m_mibTree.HasNext; }
        }

        //----------------------------------------------------
        public void GoToPrevious()
        {
            m_mibTree.GoToPrevious();
        }

        //----------------------------------------------------
        public void GoToNext()
        {
            m_mibTree.GoToNext();
        }

        //----------------------------------------------------
        private void m_boutonPrevious_Click(object sender, EventArgs e)
        {
            m_mibTree.GoToPrevious();
        }

        //----------------------------------------------------
        private void m_boutonNext_Click(object sender, EventArgs e)
        {
            m_mibTree.GoToNext();
        }

        //----------------------------------------------------
        public IDefinition GetCurrent()
        {
            return m_mibTree.GetCurrent();
        }

        //----------------------------------------------------
        private void UpdateBoutonsNavigation()
        {
            m_boutonNext.Enabled = HasNext;
            m_boutonPrevious.Enabled = HasPrevious;
        }

        private void m_menuParcourir_Click(object sender, EventArgs e)
        {
            TreeNode node = m_mibTree.SelectedNode;
            IDefinition def = m_mibTree.GetDefinition(node);
            if (def != null)
            {
                m_wndListe.Init(def);
                m_slideListe.IsCollapse = false;
            }
        }

        private void m_slideListe_OnCollapseChange(object sender, EventArgs e)
        {
            m_splitterListe.Enabled = !m_slideListe.IsCollapse;
            if (m_slideListe.ExtendedSize < 30)
                m_slideListe.ExtendedSize = Size.Height / 2;
        }

        private void m_mibTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node != null)
                m_mibTree.SelectedNode = e.Node;
        }

        //----------------------------------
        private void m_btnParametres_Click(object sender, EventArgs e)
        {
            SetupConnexion();
        }

        //----------------------------------
        private bool SetupConnexion()
        {
            return CFormSetupInterrogationSNMP.EditeConnexion(ref m_connexion);
        }

        //----------------------------------
        public void GetSNMP()
        {
            IDefinition definition = GetCurrent();
            if (definition != null)
            {
                if (m_connexion == null)
                {
                    if (!SetupConnexion())
                        return;
                }
                List<uint> lstOID = new List<uint>(definition.GetNumericalForm());
                lstOID.Add(0);
                CResultAErreurType<Variable> result = m_connexion.Get(lstOID.ToArray());
                if (!result)
                {
                    CFormAfficheErreur.Show(result.Erreur);
                }
                else
                {
                    CFormViewSNMPResult.ViewResult("Get " + definition.Name,
                        result.DataType,
                        this,
                        definition.Tree);
                }
            }
        }

        //-------------------------------------------------------
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        //-------------------------------------------------------
        private void m_menuGetFromArbre_Click(object sender, EventArgs e)
        {
            GetSNMP();
        }

        //-------------------------------------------------------
        private bool CanGet( IDefinition def )
        {
            return def != null && def.Type == DefinitionType.Scalar;
        }

        //-------------------------------------------------------
        private bool CanVoirTable(IDefinition def)
        {
            return def != null && def.Type == DefinitionType.Table;
        }

        //-------------------------------------------------------
        private void m_menuArbre_Opening(object sender, CancelEventArgs e)
        {
            m_menuGetFromArbre.Visible = CanGet( GetCurrent() );
            m_mnuVoirTable.Visible = CanVoirTable(GetCurrent());
        }

        //-------------------------------------------------------
        private void m_mnuVoirTable_Click(object sender, EventArgs e)
        {
            IDefinition definition = GetCurrent();
            if (definition != null)
            {
                if (m_connexion == null)
                {
                    if (!SetupConnexion())
                        return;
                }
                CResultAErreurType<DataTable> result = m_connexion.GetTable(definition.GetNumericalForm());
                if (!result)
                {
                    CFormAfficheErreur.Show(result.Erreur);
                }
                else
                {
                    DataTable table = result.DataType;
                    IObjectTree tree = definition.Tree;
                    if (tree != null)
                    {
                        foreach (DataColumn col in table.Columns)
                        {
                            try
                            {
                                uint[] oid = ObjectIdentifier.Convert(col.ColumnName);
                                IDefinition def = tree.Find(oid);
                                if (def != null)
                                    col.ColumnName = def.Name;
                            }
                            catch
                            {
                            }
                        }
                    }
                        
                    CFormVisuTable.ShowTable("Table " + definition.Name, result.DataType);
                }
            }
        }

        //-------------------------------------------------------
        private void m_menuWalk_Click(object sender, EventArgs e)
        {
            IDefinition definition = GetCurrent();
            if (definition != null)
            {
                if (m_connexion == null)
                {
                    if (!SetupConnexion())
                        return;
                }
                CResultAErreurType<IList<Variable>> result = m_connexion.Walk(definition.GetNumericalForm());
                if (!result)
                {
                    CFormAfficheErreur.Show(result.Erreur);
                }
                else
                {
                    CFormViewSNMPResult.ViewResult("Walk " + definition.Name,
                        result.DataType,
                        this,
                        definition.Tree);
                }
            }
        }

        private void m_wndListe_Load(object sender, EventArgs e)
        {

        }

        //-------------------------------------------------------
    }
}
