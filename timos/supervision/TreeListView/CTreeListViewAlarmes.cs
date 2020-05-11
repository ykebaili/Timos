using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.common;
using System.Collections;
using futurocom.supervision;
using sc2i.common.memorydb;
using sc2i.expression;
using System.Drawing;
using futurocom.supervision.alarmes;
using timos.supervision.TreeList;
using timos.data.supervision;
using sc2i.win32.common;
using sc2i.formulaire;
using sc2i.data;
using timos.supervision.Masquage;


namespace timos.supervision
{
    public partial class CTreeListViewAlarmes : TreeListView
    {
        private bool m_bTraiteAlarmesEnCours;
        CMemoryDb m_database;
        Dictionary<string, Node> m_dicAlarmeNode = new Dictionary<string, Node>();
        CParametreAffichageListeAlarmes m_parametreAffichage;
        private int m_nDurreePersistanceRetombees = 0;
        private Dictionary<string, Image> m_dicIdTypeAlarmeImage = null;
        private Dictionary<int, CActionSur2iLink> m_dicIndexColonneAction = new Dictionary<int, CActionSur2iLink>();
        private CFiltreMemoryDb m_filtreAlarmes = null;

        ContextMenuStrip m_contextMenu = null;
        
        Timer m_timerUpdateAlarms;
        Timer m_timerPersistanceAlarmesRetombees;

        public CTreeListViewAlarmes()
        {
            InitializeComponent();
        }

        public CTreeListViewAlarmes(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

        }

        // Le filtre utilisé pour filtrer sur les Masquages, les Sévérités...
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CFiltreMemoryDb FiltreAlarmes
        {
            get
            {
                return m_filtreAlarmes;
            }
            set
            {
                m_filtreAlarmes = value;
                RemplirListeAlarmes();
            }
        }

        public void RemplirListeAlarmes()
        {
            BeginUpdate();

            m_dicAlarmeNode.Clear();
            Nodes.Clear();

            CListeEntitesDeMemoryDb<CLocalAlarme> listeAlarmes = new CListeEntitesDeMemoryDb<CLocalAlarme>(m_database, m_filtreAlarmes);

            foreach (CLocalAlarme alarme in listeAlarmes)
            {
                if (alarme.Parent == null)
                {
                    if(m_bTraiteAlarmesEnCours && alarme.DateFin == null)
                        UpdateNode(new CLocalAlarmeAffichee(alarme.Row.Row));
                    if (!m_bTraiteAlarmesEnCours && alarme.DateFin != null && alarme.DateFin.Value.AddMinutes(m_nDurreePersistanceRetombees) > DateTime.Now)
                        UpdateNode(new CLocalAlarmeAffichee(alarme.Row.Row));
                }
            }

            EndUpdate();
        }

        //------------------------------------------------------------------------------------
        public void Init(CMemoryDb db, CParametreAffichageListeAlarmes parametres, Dictionary<string, Image> tableauImages, bool bAlarmesEnCours)
        {
            BeginUpdate();

            m_database = db;
            m_bTraiteAlarmesEnCours = bAlarmesEnCours;
            m_parametreAffichage = parametres;
            m_dicIdTypeAlarmeImage = tableauImages;
            
            m_timerUpdateAlarms = new Timer();
            m_timerUpdateAlarms.Interval = 1000;
            m_timerUpdateAlarms.Tick += new EventHandler(m_timerUpdateAlarms_Tick);
            m_timerUpdateAlarms.Enabled = true;

            if (!bAlarmesEnCours)
            {
                m_timerPersistanceAlarmesRetombees = new Timer();
                m_timerPersistanceAlarmesRetombees.Interval = 60000; // 1 minute
                m_timerPersistanceAlarmesRetombees.Tick += new EventHandler(m_timerPersistanceAlarmesRetombees_Tick);
                m_timerPersistanceAlarmesRetombees.Start();
            }

            AppliqueParametresAffichage();

            if(bAlarmesEnCours)
                RemplirListeAlarmes();

            InitContextMenu();

            EndUpdate();
        }

        //--------------------------------------------------------------------------
        void m_timerPersistanceAlarmesRetombees_Tick(object sender, EventArgs e)
        {
            if (m_nDurreePersistanceRetombees > 0)
            {
                foreach (Node nodeRacine in Nodes.ToArray())
                {
                    CLocalAlarmeAffichee alarme = nodeRacine.Tag as CLocalAlarmeAffichee;
                    if (alarme != null)
                    {
                        if (alarme.DateFin != null && alarme.DateFin.Value.AddMinutes(m_nDurreePersistanceRetombees) < DateTime.Now)
                            Nodes.Remove(nodeRacine);    
                    }
                }

            }
        }


        //-------------------------------------------------------------------------------
        private void FillNode(Node node, CLocalAlarmeAffichee alarme)
        {
            node.ClearData();
            node.Tag = alarme;
            m_dicAlarmeNode[alarme.Id] = node;
        }

        //-------------------------------------------------------------------------------
        protected override Image GetNodeBitmap(Node node)
        {
            Image image = base.GetNodeBitmap(node);
            CLocalAlarmeAffichee alarme = node.Tag as CLocalAlarmeAffichee;
            if (alarme != null && alarme.TypeAlarme != null && m_dicIdTypeAlarmeImage != null)
            {
                m_dicIdTypeAlarmeImage.TryGetValue(alarme.TypeAlarme.Id, out image);
            }
            return image;
        }

        //-------------------------------------------------------------------------------
        private void UpdateNode(CLocalAlarmeAffichee alarme)
        {
            // Verifie Formule d'affichage
            if (m_parametreAffichage != null && m_parametreAffichage.FormuleFiltre != null)
            {
                C2iExpression formuleFiltreAffichage = m_parametreAffichage.FormuleFiltre;
                CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(alarme);
                CResultAErreur result = formuleFiltreAffichage.Eval(ctx);
                if (result && result.Data is bool)
                {
                    bool bAfficher = (bool)result.Data;
                    if (!bAfficher)
                        return;
                }
            }

            Node nodeAssocie;
            if (!m_dicAlarmeNode.TryGetValue(alarme.Id, out nodeAssocie))
            {
                // On créer un nouveau Node et on cherche ou l'insérer
                nodeAssocie = new Node(new object[Columns.Count]);
                if (alarme.AlarmeParente != null)
                {
                    Node nodeParent = null;
                    if (m_dicAlarmeNode.TryGetValue(alarme.AlarmeParente.Id, out nodeParent))
                        nodeParent.Nodes.InsertAfter(nodeAssocie, null);
                    else
                        throw new Exception("No Parent Node found !!");
                }
                else
                    Nodes.InsertAfter(nodeAssocie, null);
                            
            }
            FillNode(nodeAssocie, alarme);

            foreach (CLocalAlarmeAffichee alarmeFille in alarme.AlarmesFilles)
            {
                UpdateNode(alarmeFille);
            }

        }

        //-------------------------------------------------------------------------------
        private void RemoveNode(CLocalAlarmeAffichee alarme)
        {
            Node nodeAssocie;
            if (m_dicAlarmeNode.TryGetValue(alarme.Id, out nodeAssocie))
            {
                int n = Nodes.GetNodeIndex(nodeAssocie);
                Nodes.Remove(nodeAssocie);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        class COperationSurAlarmeAffichee
        {
            public readonly CLocalAlarmeAffichee AlarmeAffichee;
            public readonly EOperationSurAlarme Operation;        
            public COperationSurAlarmeAffichee(CLocalAlarmeAffichee alarme, EOperationSurAlarme op)
            {
                AlarmeAffichee = alarme;
                Operation = op;
            }

        }
        /// <summary>
        /// Opérations de mise à jour possibles 
        /// </summary>
        enum EOperationSurAlarme
        {
            CreateUpdate,
            Delete
        }

        List<COperationSurAlarmeAffichee> m_listeOperationsSurAlarme = new List<COperationSurAlarmeAffichee>();
        //-------------------------------------------------------------------------------
        public void UpdateAlarmDataBase(CMemoryDb dbMaj)
        {
            List<COperationSurAlarmeAffichee> listeTampon = new List<COperationSurAlarmeAffichee>();

            Dictionary<CLocalAlarme, bool> dicAlarmesTraitees = new Dictionary<CLocalAlarme, bool>();
            m_database = dbMaj;
            CListeEntitesDeMemoryDb<CLocalAlarme> listeMaj = new CListeEntitesDeMemoryDb<CLocalAlarme>(m_database, m_filtreAlarmes);
            HashSet<string> lstAlarmesNonMasquees = new HashSet<string>();
            foreach (CLocalAlarme alrm in listeMaj)
            {
                lstAlarmesNonMasquees.Add(alrm.Id);    
            }
            listeMaj = new CListeEntitesDeMemoryDb<CLocalAlarme>(m_database);

            foreach (CLocalAlarme alarmeMaj in listeMaj)
            {
                // Traite uniquement les alarmes ajoutées ou modifiées
                if (alarmeMaj.Row.Row.RowState == System.Data.DataRowState.Modified ||
                    alarmeMaj.Row.Row.RowState == System.Data.DataRowState.Added)
                {
                    // Recherche l'alarme racine
                    CLocalAlarme alarmeParente = alarmeMaj;
                    while (alarmeParente.Parent != null)
                        alarmeParente = alarmeParente.Parent;

                    if (dicAlarmesTraitees.Keys.Contains(alarmeParente))
                        continue;

                    if (!lstAlarmesNonMasquees.Contains(alarmeMaj.Id))
                    {
                        listeTampon.Add(new COperationSurAlarmeAffichee(
                                new CLocalAlarmeAffichee(alarmeParente.Row.Row),
                                EOperationSurAlarme.Delete));
                        continue;
                    }
                                        
                    if (m_bTraiteAlarmesEnCours)
                    {
                        if (alarmeParente.DateFin == null)
                            //UpdateNode(new CLocalAlarmeAffichee(alarmeParente.Row.Row));
                            listeTampon.Add(new COperationSurAlarmeAffichee(
                                new CLocalAlarmeAffichee(alarmeParente.Row.Row), 
                                EOperationSurAlarme.CreateUpdate));
                        else
                            //RemoveNode(new CLocalAlarmeAffichee(alarmeParente.Row.Row));
                            listeTampon.Add(new COperationSurAlarmeAffichee(
                                new CLocalAlarmeAffichee(alarmeParente.Row.Row),
                                EOperationSurAlarme.Delete));
                    }
                    else // Traite alarmes retombées
                    {
                        if(alarmeParente.DateFin != null)
                            //UpdateNode(new CLocalAlarmeAffichee(alarmeParente.Row.Row));
                            listeTampon.Add(new COperationSurAlarmeAffichee(
                                new CLocalAlarmeAffichee(alarmeParente.Row.Row),
                                EOperationSurAlarme.CreateUpdate));
                        else
                            //RemoveNode(new CLocalAlarmeAffichee(alarmeParente.Row.Row));
                            listeTampon.Add(new COperationSurAlarmeAffichee(
                                new CLocalAlarmeAffichee(alarmeParente.Row.Row),
                                EOperationSurAlarme.Delete));
                    }
                    dicAlarmesTraitees[alarmeParente] = true;
                }
            }

            lock (m_listeOperationsSurAlarme)
            {
                m_listeOperationsSurAlarme.AddRange(listeTampon);
            }

            BeginInvoke(new EventHandler(DelayUpdate), null, null);
        }

        //------------------------------------------------------------------------
        // Traite les alarmes à la fin de la tempo
        //int m_nbOperationsRemove = 0; // DEBUG
        private void m_timerUpdateAlarms_Tick(object sender, EventArgs e)
        {
            m_timerUpdateAlarms.Stop();
                        
            BeginUpdate();
            //m_nbOperationsRemove = 0;    
            List<COperationSurAlarmeAffichee> listeCopie;

            lock (m_listeOperationsSurAlarme)
            {
                listeCopie = new List<COperationSurAlarmeAffichee>(m_listeOperationsSurAlarme);
                m_listeOperationsSurAlarme.Clear();
            }

            foreach (COperationSurAlarmeAffichee operation in listeCopie)
            {
                switch (operation.Operation)
                {
                    case EOperationSurAlarme.CreateUpdate:
                        UpdateNode(operation.AlarmeAffichee);
                        break;
                    case EOperationSurAlarme.Delete:
                        //m_nbOperationsRemove++; // DEBUG
                        RemoveNode(operation.AlarmeAffichee);
                        break;
                    default:
                        break;
                }
            }
            EndUpdate();
        }


        public void DelayUpdate(object obj, EventArgs e)
        {
            m_timerUpdateAlarms.Stop();
            m_timerUpdateAlarms.Start();
        }

        //-------------------------------------------------------------------------------
        private void AppliqueParametresAffichage()
        {
            if (m_parametreAffichage == null)
                m_parametreAffichage = CParametreAffichageListeAlarmes.ParametreParDefaut;

            ColumnsOptions.HeaderHeight = m_parametreAffichage.HauteurEnteteColonne;
            RowOptions.ItemHeight = m_parametreAffichage.HauteurLigne;
            RowOptions.HeaderWidth = m_parametreAffichage.LargeurEnteteLigne;
            m_nDurreePersistanceRetombees = m_parametreAffichage.DureePersistanceAlarmesRetombees;

            // Création des Colonnes
            Columns.Clear();
            foreach (CColonneAlarmeAffichee colonneParametree in m_parametreAffichage.Colonnes)
            {
                TreeListColumn col = new TreeListColumn(
                    colonneParametree.Title,
                    colonneParametree.Title,
                    colonneParametree.Width);
                col.HeaderFormat.BackColor = colonneParametree.BackColor;
                col.HeaderFormat.ForeColor = colonneParametree.TextColor;
                col.HeaderFormat.Font = colonneParametree.Font;
                
                Columns.Add(col);

                if (colonneParametree.ActionSurLink != null)
                    m_dicIndexColonneAction.Add(col.Index, colonneParametree.ActionSurLink);
            }

        }


        //-------------------------------------------------------------------------
        void OnCollapseAllChildren(object sender, EventArgs e)
        {
            BeginUpdate();
            if (MultiSelect && NodesSelection.Count > 0)
            {
                foreach (timos.supervision.Node selnode in NodesSelection)
                {
                    foreach (timos.supervision.Node node in selnode.Nodes)
                        node.Collapse();
                }
                NodesSelection.Clear();
            }
            if (FocusedNode != null && FocusedNode.HasChildren)
            {
                foreach (timos.supervision.Node node in FocusedNode.Nodes)
                    node.Collapse();
            }
            EndUpdate();
        }

        //-------------------------------------------------------------------------
        void OnExpandAllChildren(object sender, EventArgs e)
        {
            BeginUpdate();
            if (MultiSelect && NodesSelection.Count > 0)
            {
                foreach (timos.supervision.Node selnode in NodesSelection)
                    selnode.ExpandAll();
                NodesSelection.Clear();
            }
            if (FocusedNode != null)
                FocusedNode.ExpandAll();
            EndUpdate();
        }

        //-------------------------------------------------------------------------
        void OnDeleteSelectedNode(object sender, EventArgs e)
        {
            BeginUpdate();
            timos.supervision.Node node = FocusedNode;
            if (node != null && node.Owner != null)
            {
                node.Collapse();
                timos.supervision.Node nextnode = timos.supervision.NodeCollection.GetNextNode(node, 1);
                if (nextnode == null)
                    nextnode = timos.supervision.NodeCollection.GetNextNode(node, -1);
                node.Owner.Remove(node);
                FocusedNode = nextnode;
            }
            EndUpdate();
        }

        //-------------------------------------------------------------------------
        private void OnAcknowledgeAlarm(object sender, EventArgs e)
        {
            timos.supervision.Node node = FocusedNode;
            if (node != null && node.Owner != null)
            { 
                CLocalAlarmeAffichee alarme = node.Tag as CLocalAlarmeAffichee;
                if (alarme.DateAcquittement == null)
                {
                    if (alarme != null && alarme.TypeAlarme != null && alarme.TypeAlarme.AAcquitter)
                    {
                        // Acquitter l'alarme maintenant
                        alarme.Acquitter(CTimosApp.SessionClient.IdSession);
                    }
                }
                else
                {
                    CFormAlerte.Afficher(I.T("Alarm @1 has already been Acknowledged|10259", alarme.Libelle));
                }
            }
        }

        //-------------------------------------------------------------------------
        private void OnClearAlarm(object sender, EventArgs e)
        {
            Node node = FocusedNode;
            if (node != null && node.Owner != null)
            {
                CLocalAlarmeAffichee alarme = node.Tag as CLocalAlarmeAffichee;
                // Faire retomber l'alarme ici
                CResultAErreur result = alarme.RetombageManuel(CTimosApp.SessionClient.IdSession);
                if (!result)
                    CFormAlerte.Afficher(result.Erreur);
            }
        }

       

        //-------------------------------------------------------------------------
        private void OnShowAlarmDetail(object sender, EventArgs e)
        {
            Node node = FocusedNode;
            if (node != null && node.Owner != null)
            {
                CLocalAlarmeAffichee alarme = node.Tag as CLocalAlarmeAffichee;
                // Edite la fenêtre de détail de l'Alarme
                CAlarme alarmeInDB = new CAlarme(CContexteDonneeSysteme.GetInstance());
                if (alarmeInDB.ReadIfExists(new CFiltreData(
                        CAlarme.c_champAlarmId + " = @1",
                        alarme.Id)))
                {
                    CTimosApp.Navigateur.AffichePage(new CFormEditionAlarme(alarmeInDB));
                }
            }
        }

        //-------------------------------------------------------------------------
        private void OnMaskAlarm(object sender, EventArgs e)
        {
            Node node = FocusedNode;
            if (node != null && node.Owner != null)
            {
                CLocalAlarmeAffichee alarme = node.Tag as CLocalAlarmeAffichee;
                // Edite la fenêtre de détail de l'Alarme
                CAlarme alarmeInDB = new CAlarme(CContexteDonneeSysteme.GetInstance());
                if (alarmeInDB.ReadIfExists(new CFiltreData(
                        CAlarme.c_champAlarmId + " = @1",
                        alarme.Id)))
                {
                    CFormMasquageAlarmeManuel.CreateMasquage(alarmeInDB, true);
                }
            }
        }

        //-------------------------------------------------------------------------
        protected override void BeforeShowContextMenu()
        {
            if (GetHitNode() == null)
                ContextMenuStrip = null;
            else
            {
                InitContextMenu();
                CompleteContextMenu();
                ContextMenuStrip = m_contextMenu;
            }
        }

        //------------------------------------------------------------------------
        private void CompleteContextMenu()
        {
            m_contextMenu.Items.Add(new ToolStripSeparator());
            ToolStripMenuItem itemVoirDetails = new ToolStripMenuItem(I.T("Show Alarm detail|10278"), null, OnShowAlarmDetail);
            ToolStripMenuItem itemAcquitter = new ToolStripMenuItem(I.T("Acknowledge|10260"), null, OnAcknowledgeAlarm);
            ToolStripMenuItem itemRetomber = new ToolStripMenuItem(I.T("Clear Manualy|10261"), null, OnClearAlarm);
            ToolStripMenuItem itemMasquer = new ToolStripMenuItem(I.T("Mask Alarm now|10316"), null, OnMaskAlarm);
            
            timos.supervision.Node node = FocusedNode;
            if (node != null)
            {
                CLocalAlarmeAffichee alarme = node.Tag as CLocalAlarmeAffichee;
                if (alarme != null && alarme.TypeAlarme != null)
                {
                    // Affiche la fenêtre de détail
                    m_contextMenu.Items.Add(itemVoirDetails);
                    if (alarme.MasquagePropre == null && alarme.MasquageHerite == null)
                        m_contextMenu.Items.Add(itemMasquer);
                    // Alarme à Acquitter    
                    itemAcquitter.Enabled = alarme.TypeAlarme.AAcquitter;
                    m_contextMenu.Items.Add(itemAcquitter);
                    // Faire retomber l'Alarme manuellement
                    m_contextMenu.Items.Add(itemRetomber);
                }
            }
        }

        //------------------------------------------------------------------------
        private void InitContextMenu()
        {
            if(m_contextMenu == null)
                m_contextMenu = new ContextMenuStrip();
            m_contextMenu.Items.Clear();
            m_contextMenu.Items.Add(new ToolStripMenuItem(I.T("Collapse All Children|10218"), null, new EventHandler(OnCollapseAllChildren)));
            m_contextMenu.Items.Add(new ToolStripMenuItem(I.T("Expand All Children|102219"), null, new EventHandler(OnExpandAllChildren)));
        }

        //------------------------------------------------------------------------
        protected override object GetData(Node node, TreeListColumn column)
        {
            if (node[column.Index] != null)
                return node[column.Index];
            
            CResultAErreur result = CResultAErreur.True;

            CLocalAlarmeAffichee localAlarme = node.Tag as CLocalAlarmeAffichee;
            if(localAlarme != null)
            {
                try
                {
                    CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(localAlarme);
                    C2iExpression exp = m_parametreAffichage.Colonnes[column.Index].FormuleDonnee;
                    if (exp != null)
                    {
                        result = exp.Eval(ctx);
                        if (result)
                        {
                            node[column.Index] = result.Data;
                            return result.Data;
                        }
                    }
                    else
                        return null;
                }
                catch (Exception ex)
                {
                    result.EmpileErreur(ex.Message);
                    return result;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------
        protected override void PaintRowHeader(Graphics g, Rectangle rc, Node node, bool isHot)
        {
            base.PaintRowHeader(g, rc, node, isHot);

            if (node != null)
            {
                CLocalAlarmeAffichee alarme = node.Tag as CLocalAlarmeAffichee;
                if (alarme != null && alarme.Severite != null)
                {
                    Color couleurSeverite = alarme.Severite.Couleur;
                    Brush br = new SolidBrush(couleurSeverite);
                    int x = 10, y = 10;
                    Rectangle recCarre = new Rectangle(
                        rc.X + (int)((rc.Width - x) / 2),
                        rc.Y + (int)((rc.Height - y) / 2),
                        x, y); 
                    g.FillRectangle(br, recCarre);
                }
            }
        }

        //------------------------------------------------------------------------------------
        protected override TextFormatting GetFormatting(Node node, TreeListColumn column)
        {
            CResultAErreur result = CResultAErreur.True;

            TextFormatting format = new TextFormatting(base.GetFormatting(node, column));
            CLocalAlarmeAffichee alarme = node.Tag as CLocalAlarmeAffichee;
            if (alarme != null)
            {
                try
                {
                    CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(alarme);
                    C2iExpression exp = m_parametreAffichage.FormuleItemBackColor;
                    if (exp != null)
                    {
                        result = exp.Eval(ctx);
                        if (result)
                        {
                            Color couleurFond = (Color)result.Data;
                            if (couleurFond != null)
                                format.BackColor = couleurFond;
                        }
                    }
                    exp = m_parametreAffichage.FormuleItemForeColor;
                    if (exp != null)
                    {
                        result = exp.Eval(ctx);
                        if (result)
                        {
                            Color couleurTexte = (Color)result.Data;
                            if (couleurTexte != null)
                                format.ForeColor = couleurTexte;
                        }
                    }
                    CActionSur2iLink action = null;
                    if(m_dicIndexColonneAction.TryGetValue(column.Index, out action))
                    {
                        Font font = new Font(format.Font, FontStyle.Underline);
                        format.Font = font;
                    }

                }
                catch
                {
                }
            }
            return format;
        }


        //---------------------------------------------------------------------------
        /// <summary>
        /// Gestion du Tool Tip sur les cellules qui ne s'affichent pas entièrement
        /// </summary>
        private Node m_lastNodeForToolTip;
        private TreeListColumn m_lastColumnForToolTip;
        private Point m_lastMouseLocation;
        private string m_strTooltipText = "";
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            try
            {
                bool bShowToolTip = false;
                Node nodeSurvole = CalcHitNode(e.Location);
                if (nodeSurvole != null && nodeSurvole != m_lastNodeForToolTip)
                {
                    bShowToolTip = true;
                    m_lastNodeForToolTip = nodeSurvole;
                }
                TreeListColumn colonneSurvolee = CalcColumnHit(e.Location).Column;
                if (colonneSurvolee != null && colonneSurvolee != m_lastColumnForToolTip)
                {
                    bShowToolTip = true;
                    m_lastColumnForToolTip = colonneSurvolee;
                    // Gestion curseur souris
                    if (m_dicIndexColonneAction.Keys.Contains(colonneSurvolee.Index))
                        Cursor.Current = Cursors.Hand;
                    else
                        Cursor.Current = Cursors.Default;
                }
                

                if (bShowToolTip)
                {
                    object dataForToolTip = GetData(nodeSurvole, colonneSurvolee);
                    if (dataForToolTip != null)
                    {
                        string texte = dataForToolTip.ToString();
                        if (texte.Trim() != "")
                        {
                            Graphics g = CreateGraphics();
                            TextFormatting format = GetFormatting(nodeSurvole, colonneSurvolee);
                            SizeF dim = g.MeasureString(texte, format.Font);
                            Rectangle rc = Util.AdjustRectangle(colonneSurvolee.CalculatedRect, format.Padding);
                            int nOffset = 0;
                            if (colonneSurvolee.Index == 0)
                                nOffset = GetIndentSize(nodeSurvole) + 16;
                            if ((int)dim.Width >= (rc.Width - nOffset))
                                DelayShowTooltip(e.Location, texte);
                            else
                                HideTooltip();
                        }
                        else
                            HideTooltip();
                    }
                    else
                        HideTooltip();
                }
            }
            catch 
            {
                HideTooltip(); 
            }
            
        }

        private void DelayShowTooltip(Point position, string strText)
        {
            m_timerTooltip.Stop();
            m_lastMouseLocation = position;
            m_strTooltipText = strText;
            if (m_strTooltipText != "")
                m_timerTooltip.Start();
        }

        private void HideTooltip()
        {
            m_toolTip.Hide(this);
            m_timerTooltip.Stop();
        }

        private void m_timerTooltip_Tick(object sender, EventArgs e)
        {
            m_timerTooltip.Stop();
            try
            {
                m_toolTip.Show(m_strTooltipText, this, m_lastMouseLocation, 5000);
            }
            catch { }

        }
    }


    /// <summary>
    /// 
    /// </summary>
    public class CLockerNotificationAlarmes
    {
    }

}
