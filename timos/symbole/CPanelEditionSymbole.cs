using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using sc2i.common;
using sc2i.drawing;
using System.Drawing.Drawing2D;
using sc2i.win32.common;
using sc2i.expression;
using timos.data;


namespace timos
{
    public class CPanelEditionSymbole : CPanelEditionObjetGraphique
    {
        private C2iSymboleLigne m_ligneEditee;

        private Type m_typeEdite = null;

        private CFournisseurGeneriqueProprietesDynamiques m_fournisseurPropriete = null;


             
        private int m_nIndexSelectedPoint = -1;
       
        private Cursor m_customCursor = null;
        private EModeEditeurSymbole m_modeEnCours = EModeEditeurSymbole.Selection;

        private CPanelEditeurSymbole m_editeur;

        private ToolStripMenuItem m_mnu_itm_group = null;
        private ToolStripMenuItem m_mnu_itm_ungroup = null;

        private ToolStripMenuItem m_mnu_itm_horizontal_flip = null;
        private ToolStripMenuItem m_mnu_itm_vertical_flip = null;




        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public CPanelEditionSymbole()
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
                if (m_customCursor != null && m_customCursor != Cursors.Arrow)
                    m_customCursor.Dispose();
                m_customCursor = null;
            }
            base.Dispose(disposing);
        }


        public Type TypeEdite
        {
            get
            {
                return m_typeEdite;
            }
            set
            {
                m_typeEdite = value;

            }

        }


        public CPanelEditeurSymbole Editeur
        {
            get
            {
                return m_editeur;
            }
            set
            {
                m_editeur = value;
            }
        }

        public CFournisseurGeneriqueProprietesDynamiques FournisseurPropriete
        {
            get
            {
                return m_fournisseurPropriete;
            }
            set
            {
                m_fournisseurPropriete = value;
            }

        }

        



        protected void InitializeComponent()
        {
            sc2i.win32.common.CGrilleEditeurObjetGraphique cGrilleEditeurObjetGraphique1 = new sc2i.win32.common.CGrilleEditeurObjetGraphique();
            sc2i.win32.common.CProfilEditeurObjetGraphique cProfilEditeurObjetGraphique1 = new sc2i.win32.common.CProfilEditeurObjetGraphique();
            this.SuspendLayout();
            // 
            // CPanelEditionSymbole
            // 
            cGrilleEditeurObjetGraphique1.Couleur = System.Drawing.Color.LightGray;
            cGrilleEditeurObjetGraphique1.HauteurCarreau = 20;
            cGrilleEditeurObjetGraphique1.LargeurCarreau = 20;
            cGrilleEditeurObjetGraphique1.Representation = sc2i.win32.common.ERepresentationGrille.LignesContinues;
            cGrilleEditeurObjetGraphique1.TailleCarreau = new System.Drawing.Size(20, 20);
            this.GrilleAlignement = cGrilleEditeurObjetGraphique1;
            this.ModeRepresentationGrille = sc2i.win32.common.ERepresentationGrille.LignesContinues;
            this.Name = "CPanelEditionSymbole";
            cProfilEditeurObjetGraphique1.FormeDesPoignees = sc2i.win32.common.EFormePoignee.Carre;
            cProfilEditeurObjetGraphique1.Grille = cGrilleEditeurObjetGraphique1;
            cProfilEditeurObjetGraphique1.HistorisationActive = true;
            cProfilEditeurObjetGraphique1.Marge = 10;
            cProfilEditeurObjetGraphique1.ModeAffichageGrille = sc2i.win32.common.EModeAffichageGrille.AuDeplacement;
            cProfilEditeurObjetGraphique1.NombreHistorisation = 10;
            cProfilEditeurObjetGraphique1.ToujoursAlignerSurLaGrille = false;
            this.Profil = cProfilEditeurObjetGraphique1;
            this.Size = new System.Drawing.Size(457, 432);
            this.ToujoursAlignerSurLaGrille = false;
            //  this.Paint += new System.Windows.Forms.PaintEventHandler(this.CPanelEditionSymbole_Paint);
            this.DoubleClick += new System.EventHandler(this.CPanelEditionSymbole_DoubleClick);
            this.SelectionChanged += new System.EventHandler(this.CPanelEditionSymbole_SelectionChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CPanelEditionSymbole_KeyDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CPanelEditionSymbole_MouseMove);
            this.AfterAddElements += new sc2i.win32.common.EventHandlerPanelEditionGraphiqueSuppression(this.CPanelEditionSymbole_AfterAddElements);
            this.ResumeLayout(false);

        }

        public EModeEditeurSymbole ModeEdition
        {
            get
            {
                return m_modeEnCours;
            }
            set
            {

                if (value == EModeEditeurSymbole.Selection)
                {
                    ModeSouris = EModeSouris.Selection;
                    SelectionVisible = true;
                    if (m_ligneEditee != null)
                    {
                        m_ligneEditee.SetModeSelection(true);
                        
                        Refresh();
                    }
                }
                else if (value == EModeEditeurSymbole.Zoom)
                {
                    ModeSouris = EModeSouris.Zoom;
                    SelectionVisible = true;
                    if (m_ligneEditee != null)
                    {
                        m_ligneEditee.SetModeSelection(true);
                       
                    }
                }
                else
                {
                    SelectionVisible = false;
                    ModeSouris = EModeSouris.Custom;
                }
                m_modeEnCours = value;

                LoadCurseurAdapté();

                if (OnChangeModeEdition != null)
                    OnChangeModeEdition(this, null);
            }
        }


        public event EventHandler OnChangeModeEdition; 


        protected override void LoadCurseurAdapté()
        {


            switch (ModeEdition)
            {


                case EModeEditeurSymbole.Selection:
                case EModeEditeurSymbole.Zoom:
                    base.LoadCurseurAdapté();
                    return;


                case EModeEditeurSymbole.EditionLigne:
                    {
                        if ((ModifierKeys & Keys.Shift) == Keys.Shift)
                        {

                            Cursor = C2iCursorLoader.LoadCursor(GetType(), "editLineDelPoint", Properties.Resources.editLineDelPoint);

                        }
                        else if ((ModifierKeys & Keys.Control) == Keys.Control)
                        {

                            Cursor = C2iCursorLoader.LoadCursor(GetType(), "editLineAddPoint", Properties.Resources.editLineAddPoint);

                        }
                        else
                        {
                            Point pt = GetLogicalPointFromDisplay(PointToClient(Cursor.Position));
                            if (m_ligneEditee != null && m_ligneEditee.IsCloseToPoint(pt))
                                Cursor = C2iCursorLoader.LoadCursor(GetType(), "editLineMovePoint", Properties.Resources.editLineMovePoint);
                            else
                                Cursor = C2iCursorLoader.LoadCursor(GetType(), "editLine", Properties.Resources.editLine);

                        }


                        break;
                    }
                case EModeEditeurSymbole.EditionModificationPoint:
                    {

                        Cursor = C2iCursorLoader.LoadCursor(GetType(), "editLineMovePoint", Properties.Resources.editLineMovePoint);


                        break;

                    }


            }
        }


        public override bool LockEdition
        {
            get
            {
                return base.LockEdition;
            }
            set
            {
                if (ModeEdition != EModeEditeurSymbole.Selection)
                    ModeEdition = EModeEditeurSymbole.Selection;

                base.LockEdition = value;
            }
        }


        //Version pour timos
        /*
            private void LoadCurseurAdapte()
            {
                if (m_customCursor != null && (m_customCursor != Cursors.Arrow && m_customCursor != Cursors.Hand))
                    m_customCursor.Dispose();
                m_customCursor = null;

                MemoryStream s = null;
                switch (ModeEdition)
                {
                    case EModeEditeurSymbole.Selection:
                        {
                            m_customCursor = Cursors.Arrow;
                            m_curseurEnCours = ECurseurEnCours.CursSelect;
                            break;
                        }
                    case EModeEditeurSymbole.EditionLigne:
                        {
                            if ((ModifierKeys & Keys.Shift) == Keys.Shift)
                            {
                                s = new MemoryStream(Properties.Resources.curSuppr);
                                m_curseurEnCours = ECurseurEnCours.CursSuppr;

                            }
                            else if ((ModifierKeys & Keys.Control) == Keys.Control)
                            {
                                s = new MemoryStream(Properties.Resources.curAdd);
                                m_curseurEnCours = ECurseurEnCours.CursAdd;

                            }
                            else
                            {
                                m_customCursor = Cursors.Arrow;
                                m_curseurEnCours = ECurseurEnCours.CursEdit;

                            }


                            break;
                        }
                    case EModeEditeurSymbole.EditionModificationPoint:
                        {
                            s = new MemoryStream(Properties.Resources.curMove);
                            m_curseurEnCours = ECurseurEnCours.CursMove;


                            break;

                        }

                }
                if (s != null)
                {
                    m_customCursor = new Cursor(s);
                    s.Close();
                }
                Cursor = m_customCursor;

            }
            */


        /*
        //version pour l'éditeur indépendant (sans les curseurs personnalisés)
        private void LoadCurseurAdapte()
        {
            if (m_customCursor != null && (m_customCursor != Cursors.Arrow && m_customCursor != Cursors.Hand))
                m_customCursor.Dispose();
            m_customCursor = null;

            MemoryStream s = null;
            switch (ModeEdition)
            {
                case EModeEditeurSymbole.Selection:
                    {
                        m_customCursor = Cursors.Arrow;
                        m_curseurEnCours = ECurseurEnCours.CursSelect;
                        break;
                    }
                case EModeEditeurSymbole.EditionLigne:
                    {
                        if ((ModifierKeys & Keys.Shift) == Keys.Shift)
                        {
                            //s = new MemoryStream(Properties.Resources.curSuppr);
                            m_customCursor = Cursors.Hand;
                            m_curseurEnCours = ECurseurEnCours.CursSuppr;

                        }
                        else if ((ModifierKeys & Keys.Control) == Keys.Control)
                        {
                            //s = new MemoryStream(Properties.Resources.curAdd);
                            m_customCursor = Cursors.Hand;
                            m_curseurEnCours = ECurseurEnCours.CursAdd;

                        }
                        else
                        {
                            m_customCursor = Cursors.Arrow;
                            m_curseurEnCours = ECurseurEnCours.CursEdit;

                        }


                        break;
                    }
                case EModeEditeurSymbole.EditionModificationPoint:
                    {
                        //s = new MemoryStream(Properties.Resources.curMove);
                        m_customCursor = Cursors.Hand;
                        m_curseurEnCours = ECurseurEnCours.CursMove;


                        break;

                    }

            }
            if (s != null)
            {
                m_customCursor = new Cursor(s);
                s.Close();
            }
            Cursor = m_customCursor;

        }

        public void LoadCuresurPoint(bool bCloseToPoint)
        {
            if (bCloseToPoint)
            {
                m_customCursor = Cursors.Hand;
                m_curseurEnCours = ECurseurEnCours.CursEdit;

            }
            else
            {
                m_customCursor = Cursors.Arrow;
                m_curseurEnCours = ECurseurEnCours.CursSelect;

            }
            Cursor = m_customCursor;
        }


        public void LoadCurseur(ECurseurEnCours newCurseur)
        {
            if (newCurseur != m_curseurEnCours)
            {
                if (m_customCursor != null && (m_customCursor != Cursors.Arrow && m_customCursor != Cursors.Hand))
                    m_customCursor.Dispose();
                m_customCursor = null;

                MemoryStream s = null;
                switch (newCurseur)
                {
                    case ECurseurEnCours.CursSelect:
                        {
                            m_customCursor = Cursors.Arrow;
                            m_curseurEnCours = ECurseurEnCours.CursSelect;

                            break;
                        }
                    case ECurseurEnCours.CursSuppr:
                        {

                            //  s = new MemoryStream(Properties.Resources.curSuppr);
                            m_customCursor = Cursors.Hand;
                            m_curseurEnCours = ECurseurEnCours.CursSuppr;
                            break;

                        }
                    case ECurseurEnCours.CursAdd:
                        {
                            // s = new MemoryStream(Properties.Resources.curAdd);
                            m_customCursor = Cursors.Hand;
                            m_curseurEnCours = ECurseurEnCours.CursAdd;
                            break;

                        }
                    case ECurseurEnCours.CursEdit:
                        {
                            m_customCursor = Cursors.Hand;
                            m_curseurEnCours = ECurseurEnCours.CursEdit;
                            break;
                        }

                    case ECurseurEnCours.CursMove:
                        {
                            //  s = new MemoryStream(Properties.Resources.curMove);
                            m_customCursor = Cursors.Hand;
                            m_curseurEnCours = ECurseurEnCours.CursMove;

                            break;

                        }

                }
                if (s != null)
                {
                    m_customCursor = new Cursor(s);
                    s.Close();
                }
                Cursor = m_customCursor;
            }
        }

        */




        public enum ECurseurEnCours
        {
            CursSelect,
            CursEdit,
            CursAdd,
            CursSuppr,
            CursMove,

        }




/*

        private void CPanelEditionSymbole_MouseUp(object sender, MouseEventArgs e)
        {
            Point mousePoint = GetMouseLogicalPoint(new Point(e.X, e.Y));
            Refresh();
            if (this.ObjetEdite != null)
            {
                if (ModeEdition == EModeEditeurSymbole.Selection)
                {
                    Refresh();
                }

                if (ModeEdition == EModeEditeurSymbole.EditionModificationPoint && m_ligneEditee != null && m_SelectedPoint != null)
                {
                    m_ligneEditee.ReplacePoint((Point)m_SelectedPoint, mousePoint);
                    // m_SelectedPoint = null;
                    // m_ligneEditee.UnSelectPoint();
                    Refresh();
                    ModeEdition = EModeEditeurSymbole.EditionLigne;

                }
                if (ModeEdition == EModeEditeurSymbole.EditionLigne && m_ligneEditee != null)
                {

                    m_ligneEditee.SetModeSelection(false);
                    Point pt = mousePoint;

                    if ((ModifierKeys & Keys.Control) == Keys.Control)
                    {
                        Point? prevPointOnLine;
                        if ((prevPointOnLine = m_ligneEditee.PointOnlineAfterPoint(pt)) != null)
                        {
                            //if (CFormAlerte.Afficher("Do you want to add a new point on the line", EFormAlerteType.Question) == DialogResult.Yes)
                            if (MessageBox.Show(I.T("Do you want to add a new point on the line ?|30032"), "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                m_ligneEditee.InsertAfterPoint((Point)prevPointOnLine, pt);

                        }
                        else
                            m_ligneEditee.AddPoint(pt);

                    }
                    else
                    {

                        m_SelectedPoint = m_ligneEditee.SelectPoint(mousePoint);

                        if (((ModifierKeys & Keys.Shift) == Keys.Shift) && (m_SelectedPoint != null))
                        {
                            if (m_ligneEditee.RemovePoint((Point)m_SelectedPoint))
                            {
                                m_SelectedPoint = null;
                                m_ligneEditee.UnSelectPoint();
                                Refresh();
                            }
                            else
                                MessageBox.Show(I.T("Impossible to remove the point|30033"));
                        }

                    }

                    Refresh();

                }

            }
        }
        */


        public void EditeLine(C2iSymboleLigne ligne)
        {
            Selection.Clear();
            Selection.Add(ligne);
            ModeEdition = EModeEditeurSymbole.EditionLigne;
            m_ligneEditee = ligne;
            m_ligneEditee.SetModeSelection(false);
            Refresh();
        }


        public override void OnMouseUpNonStandard(object sender, MouseEventArgs e)
        {
            Point ptSouris = GetLogicalPointFromDisplay(new Point(e.X, e.Y));
            ptSouris = m_ligneEditee.Parent.GlobalToClient(ptSouris);

            if (ModeEdition == EModeEditeurSymbole.EditionModificationPoint && m_ligneEditee != null && m_nIndexSelectedPoint >= 0)
            {
                if ((ModifierKeys & Keys.Shift) == Keys.Shift)
                    ptSouris = new Point(GetThePlusProche(ptSouris.X, EDimentionDessin.X),
                        GetThePlusProche(ptSouris.Y, EDimentionDessin.Y));
                                
                m_ligneEditee.ReplacePoint(m_nIndexSelectedPoint, ptSouris);

                Refresh();
                ModeEdition = EModeEditeurSymbole.EditionLigne;
            }
            else if (ModeEdition == EModeEditeurSymbole.EditionLigne && m_ligneEditee != null)
            {
                if (e.Button == MouseButtons.Right)
                {
                    ModeEdition = EModeEditeurSymbole.Selection;

                    if (m_ligneEditee != null)
                    {
                        m_ligneEditee.SetModeSelection(true);
                        m_ligneEditee = null;
                    }
                    Refresh();
                }
                else
                {
                    m_ligneEditee.SetModeSelection(false);

                    if ((ModifierKeys & Keys.Control) == Keys.Control)
                    {
                        // On ajoute un point
                        Point pt = ptSouris;
                        Point? prevPointOnLine;
                        if ((prevPointOnLine = m_ligneEditee.PointOnlineBeforePoint(pt)) != null)
                        {
                            m_ligneEditee.InsertAfterPoint((Point)prevPointOnLine, pt);
                            Refresh();
                        }
                        else
                        {
                            m_ligneEditee.InsertAfterLastPoint(pt);
                        }
                    }
                    else
                    {
                        m_nIndexSelectedPoint = m_ligneEditee.GetIndexPointProche(ptSouris);

                        if (((ModifierKeys & Keys.Shift) == Keys.Shift) && (m_nIndexSelectedPoint >= 0))
                        {
                            // On supprime un point
                            if (m_ligneEditee.RemovePoint(m_nIndexSelectedPoint))
                            {
                                m_nIndexSelectedPoint = -1;
                                Refresh();
                            }
                            else
                                MessageBox.Show(I.T("Impossible to remove the point|30033"));
                        }
                    }
                }
            }
        }


        private bool CPanelEditionSymbole_AfterAddElements(List<I2iObjetGraphique> nouveaux)
        {
            if (ModeEdition != EModeEditeurSymbole.Selection)
            {
                m_editeur.SetBoutonSelection(true);
                ModeEdition = EModeEditeurSymbole.Selection;
                if (m_ligneEditee != null)
                {

                    m_ligneEditee.SetModeSelection(true);
                   

                }

            }
            foreach (I2iObjetGraphique obj in nouveaux)
            {
                if (typeof(C2iSymbole).IsAssignableFrom(obj.GetType()))
                {
                    m_ligneEditee = obj as C2iSymboleLigne;
                
              /*      if (m_ligneEditee != null)
                    {
                        ModeEdition = EModeEditeurSymbole.EditionLigne;

                        m_ligneEditee.SetModeSelection(false);

                    }*/
                }
            }

            return true;
        }




        private void CPanelEditionSymbole_DoubleClick(object sender, EventArgs e)
        {

            if ((!LockEdition))// && (ObjetEdite != null))
            {
                if (ModeEdition == EModeEditeurSymbole.Selection)
                {
                    if (Selection.Count == 1)
                    {
                        m_ligneEditee = Selection[0] as C2iSymboleLigne;
                        if (m_ligneEditee != null)
                        {
                            this.ModeEdition = EModeEditeurSymbole.EditionLigne;

                            m_ligneEditee.SetModeSelection(false);
                        }
                    }

                }
            }
        }
        /*
        private void CPanelEditionSymbole_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (ModeEdition == EModeEditeurSymbole.EditionLigne)
                {
                    ModeEdition = EModeEditeurSymbole.Selection;

                    if (m_ligneEditee != null)
                    {
                        m_ligneEditee.SetModeSelection(true);
                        m_ligneEditee = null;
                    }
                }


            }

        }

        private void CPanelEditionSymbole_MouseDown(object sender, MouseEventArgs e)
        {
            Point mousePoint = GetMouseLogicalPoint(new Point(e.X, e.Y));

            this.Capture = true;
            
            if (this.ObjetEdite != null)
            {
                if (ModeEdition == EModeEditeurSymbole.EditionLigne && m_ligneEditee != null && (ModifierKeys & Keys.Shift) != Keys.Shift)
                {
                     mousePoint = m_ligneEditee.Parent.GlobalToClient(mousePoint);
                    
                    if ((m_SelectedPoint = m_ligneEditee.SelectPoint(mousePoint)) != null)
                        ModeEdition = EModeEditeurSymbole.EditionModificationPoint;


                }
            }
        }


        */


        public override void OnMouseDownNonStandard(object sender, MouseEventArgs e)
        {
            Point ptSouris = GetLogicalPointFromDisplay(new Point(e.X, e.Y));

            this.Capture = true;



            if (this.ObjetEdite != null)
            {
                if (ModeEdition == EModeEditeurSymbole.EditionLigne)
                {


                    if (m_ligneEditee != null && (ModifierKeys & Keys.Shift) != Keys.Shift)
                    {
                        ptSouris = m_ligneEditee.Parent.GlobalToClient(ptSouris);

                        if ((m_nIndexSelectedPoint = m_ligneEditee.GetIndexPointProche(ptSouris)) >= 0)
                            ModeEdition = EModeEditeurSymbole.EditionModificationPoint;

                    }

                }




            }

        }
          


        private void CPanelEditionSymbole_MouseMove(object sender, MouseEventArgs e)
        {

            if (ModeSouris != EModeSouris.Custom)
                return;
            LoadCurseurAdapté();
            Point mousePoint = GetLogicalPointFromDisplay(new Point(e.X, e.Y));


            if (this.ObjetEdite != null)
            {
                if (ModeEdition == EModeEditeurSymbole.EditionModificationPoint && m_ligneEditee != null && m_nIndexSelectedPoint >= 0)
                {
                    mousePoint = m_ligneEditee.Parent.GlobalToClient(mousePoint);
                    if ((ModifierKeys & Keys.Shift) == Keys.Shift)
                        mousePoint = new Point(GetThePlusProche(mousePoint.X, EDimentionDessin.X),
                            GetThePlusProche(mousePoint.Y, EDimentionDessin.Y));
                    m_ligneEditee.ReplacePoint(m_nIndexSelectedPoint, mousePoint);
                    Refresh();

                }
            }
        }


        private C2iSymboleSelectionMultiple CreatePanelSelectionMultiple()
        {

            C2iSymboleSelectionMultiple panelSelection = new C2iSymboleSelectionMultiple();

            if (Selection.Count <= 0)
            {
                return null;
            }
            if (Selection.Count > 1)
            {
                C2iSymbole prevSymbole = (C2iSymbole)Selection[0];
                for (int i = 1; i < Selection.Count; i++)
                {
                    if (prevSymbole.Parent != Selection[i].Parent)
                    {
                        MessageBox.Show(I.T("Impossible to group objects not having the same parent|30031"));
                        return null;
                    }
                    prevSymbole = (C2iSymbole)Selection[i];
                }
            }
            panelSelection.ForeColor = Color.Transparent;
            panelSelection.BackColor = Color.Transparent;
            Selection[0].Parent.AddChild(panelSelection);
            if (panelSelection.Parent != null)
                panelSelection.Parent.RemoveChild(panelSelection);
            panelSelection.Parent = Selection[0].Parent;
            ArrayList arraySymbole = new ArrayList();
            ArrayList arrayPos = new ArrayList();

            foreach (C2iSymbole symbole in Selection[0].Parent.Childs)
            {
                if (Selection.Contains(symbole))
                {
                    arraySymbole.Add(symbole);
                    arrayPos.Add(symbole.PositionAbsolue);
                }

            }

            foreach (C2iSymbole symbole in arraySymbole)
            {
                panelSelection.AddChild(symbole);
                if (symbole.Parent != null)
                    symbole.Parent.RemoveChild(symbole);
                symbole.Parent = panelSelection;
                Selection.Remove(symbole);
            }
            for (int i = 0; i < arraySymbole.Count; i++)
            {
                ((C2iSymbole)arraySymbole[i]).PositionAbsolue = (Point)arrayPos[i];
            }

            Refresh();

            return panelSelection;
        }



        protected override void AfficherMenuAdditonnel(ContextMenuStrip menu)
        {

            if (m_mnu_itm_group == null)
            {
                m_mnu_itm_group = new System.Windows.Forms.ToolStripMenuItem();

                menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { m_mnu_itm_group });

                m_mnu_itm_group.Name = "m_mnu_itm_group";
                m_mnu_itm_group.Size = new System.Drawing.Size(194, 22);
                m_mnu_itm_group.Text = I.T("Group|30272");
                m_mnu_itm_group.Click += new System.EventHandler(this.m_mnu_itm_group_Click);

            }
            if (m_mnu_itm_ungroup == null)
            {
                m_mnu_itm_ungroup = new System.Windows.Forms.ToolStripMenuItem();

                menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { m_mnu_itm_ungroup });

                m_mnu_itm_ungroup.Name = "m_mnu_itm_ungroup";
                m_mnu_itm_ungroup.Size = new System.Drawing.Size(194, 22);
                m_mnu_itm_ungroup.Text = I.T("Ungroup|30273");
                m_mnu_itm_ungroup.Click += new System.EventHandler(this.m_mnu_itm_ungroup_Click);

            }

            if (m_mnu_itm_horizontal_flip == null)
            {
                m_mnu_itm_horizontal_flip = new System.Windows.Forms.ToolStripMenuItem();

                menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { m_mnu_itm_horizontal_flip });

                m_mnu_itm_horizontal_flip .Name = "m_mnu_itm_horizontal_flip";
                m_mnu_itm_horizontal_flip.Size = new System.Drawing.Size(194, 22);
                m_mnu_itm_horizontal_flip.Text = I.T("Horizontal flip|30374");
                m_mnu_itm_horizontal_flip.Click += new System.EventHandler(this.m_mnu_itm_horizontal_flip_Click);

            }

            if (m_mnu_itm_vertical_flip == null)
            {
                m_mnu_itm_vertical_flip = new System.Windows.Forms.ToolStripMenuItem();

                menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { m_mnu_itm_vertical_flip });

                m_mnu_itm_vertical_flip.Name = "m_mnu_itm_vertical_flip";
                m_mnu_itm_vertical_flip.Size = new System.Drawing.Size(194, 22);
                m_mnu_itm_vertical_flip.Text = I.T("Vertical flip|30375");
                m_mnu_itm_vertical_flip.Click += new System.EventHandler(this.m_mnu_itm_vertical_flip_Click);

            }




            bool bGroupVisible = MNUGroup_Show();
            bool bUngroupVisible = MNUUngroup_Show();
            bool bHorizontalFilpVisible = MNUHorizontalFlip_Show();
            bool bVerticalFlipVisible = MNUVerticalFlip_Show();
            m_mnu_itm_group.Visible = bGroupVisible;
            m_mnu_itm_ungroup.Visible = bUngroupVisible;
            m_mnu_itm_horizontal_flip.Visible = bHorizontalFilpVisible;
            m_mnu_itm_vertical_flip.Visible = bVerticalFlipVisible;

        }


        private bool MNUGroup_Show()
        {

            if ((ObjetEdite != null) && (ModeEdition == EModeEditeurSymbole.Selection) && (Selection.Count > 1))
                return true;
            else
                return false;

        }


        private bool MNUUngroup_Show()
        {

            foreach (I2iObjetGraphique objet in Selection)
            {
                if (objet.GetType() == typeof(C2iSymboleSelectionMultiple))
                {
                    return true;
                }
            }
            return false;


        }

        private bool MNUHorizontalFlip_Show()
        {

            if ((ObjetEdite != null) && (ModeEdition == EModeEditeurSymbole.Selection) && (Selection.Count > 0))
                return true;
            else
                return false;

        }

        private bool MNUVerticalFlip_Show()
        {

            if ((ObjetEdite != null) && (ModeEdition == EModeEditeurSymbole.Selection) && (Selection.Count > 0))
                return true;
            else
                return false;

        }


        public void RemovePanelSelectionMultiple()
        {

            ArrayList arrayGroupes = new ArrayList();
            foreach (I2iObjetGraphique objet in Selection)
            {
                if (objet.GetType() == typeof(C2iSymboleSelectionMultiple))
                {
                    arrayGroupes.Add(objet);

                }

            }

            foreach (I2iObjetGraphique objet in arrayGroupes)
            {
                C2iSymboleSelectionMultiple panelSelection = (C2iSymboleSelectionMultiple)objet;
                Selection.Remove(panelSelection);

                C2iSymbole[] tabSymbole = new C2iSymbole[panelSelection.Childs.Length];
                Point[] tabPos = new Point[panelSelection.Childs.Length];
                C2iSymbole objParent = (C2iSymbole)panelSelection.Parent;
                for (int i = 0; i < panelSelection.Childs.Length; i++)
                {
                    tabSymbole[i] = (C2iSymbole)panelSelection.Childs[i];
                    tabPos[i] = panelSelection.Childs[i].PositionAbsolue;
                }
                panelSelection.Parent.RemoveChild(panelSelection);
                for (int i = 0; i < tabSymbole.Length; i++)
                {
                    objParent.AddChild(tabSymbole[i]);
                    if (tabSymbole[i].Parent != null)
                        tabSymbole[i].Parent.RemoveChild(tabSymbole[i]);
                    tabSymbole[i].Parent = objParent;
                }

                for (int i = 0; i < tabPos.Length; i++)
                {
                    tabSymbole[i].Position = tabPos[i];
                    tabSymbole[i].PositionAbsolue = tabPos[i];
                }
            }


        }


        public void AjusterFond()
        {

            Selection.Clear();
            foreach (C2iSymbole symb in ObjetEdite.Childs)
            {
                Selection.Add(symb);
            }

            if (Selection.Count > 1)
            {
                C2iSymboleSelectionMultiple panelGroupe = new C2iSymboleSelectionMultiple();

                panelGroupe = CreatePanelSelectionMultiple();

                if (panelGroupe != null)
                {
                    panelGroupe.Parent = ObjetEdite;
                    panelGroupe.Position = new Point(0, 0);

                    Size newSize = panelGroupe.Size;
                    Selection.Add(panelGroupe);
                    
                    RemovePanelSelectionMultiple();

                    ObjetEdite.Size = newSize;
                    Selection.Clear();
                }
            }
            else if (Selection.Count == 1)
            {
                Selection[0].Position = new Point(0, 0);
                Size newSize = new Size(Selection[0].Size.Width + 2, Selection[0].Size.Height + 2);
                ObjetEdite.Size = newSize;
                Selection.Clear();
            }
        }


        private void m_mnu_itm_group_Click(object sender, EventArgs e)
        {
            MNU_Group();
        }
        public virtual void MNU_Group()
        {
            CreatePanelSelectionMultiple();
        }

        private void m_mnu_itm_ungroup_Click(object sender, EventArgs e)
        {
            MNU_Ungroup();
        }
        public virtual void MNU_Ungroup()
        {
            RemovePanelSelectionMultiple();
        }

        private void  m_mnu_itm_horizontal_flip_Click(object sender, EventArgs e)
        {
            MNU_HorizontalFlip();
        }
        private void m_mnu_itm_vertical_flip_Click(object sender, EventArgs e)
        {
            MNU_VerticalFlip();
        }
        public virtual void MNU_HorizontalFlip()
        {
            foreach (C2iSymbole obj in Selection)
            {
                obj.HorizontalFlip();
            }
            Refresh();

        }
        public virtual void MNU_VerticalFlip()
        {
            foreach (C2iSymbole obj in Selection)
            {
                obj.VerticalFlip();
            }
            Refresh();
        }

       

        private void CPanelEditionSymbole_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape || e.KeyData == Keys.Delete)
            {
                if (ModeEdition != EModeEditeurSymbole.Selection)
                {
                    ModeEdition = EModeEditeurSymbole.Selection;
                    if (m_ligneEditee != null)
                    {
                        m_ligneEditee.SetModeSelection(true);
                        m_ligneEditee = null;

                    }

                }
            }


            Refresh();

        }




        private void CPanelEditionSymbole_SelectionChanged(object sender, EventArgs e)
        {
            foreach (C2iSymbole element in Selection)
                element.OnDesignSelect(TypeEdite, FournisseurPropriete);

            if (m_editeur != null)
            {
                if (Selection.Count == 1)
                {
                    if (Selection[0].GetType() == typeof(C2iSymboleLigne))
                    {
                        Editeur.BoutonEditionLigneVisible(true);
                        return;
                    }
                }
                Editeur.BoutonEditionLigneVisible(false);
            }
        }








    }


    public enum EModeEditeurSymbole
    {
        Selection,
        Zoom,
        EditionLigne,
        EditionModificationPoint
    }

}
