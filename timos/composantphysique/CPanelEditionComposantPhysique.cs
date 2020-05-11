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
using timos.data.composantphysique;


namespace timos.composantphysique
{
    public delegate void OnDessinerEventHandler ( CPanelEditionComposantPhysique panel,
        bool bElement,
        bool bSelection);

    public class CPanelEditionComposantPhysique : CPanelEditionObjetGraphique
    {
        private EFaceVueDynamique m_faceAffichee = EFaceVueDynamique.Front;

        private Type m_typeEdite = null;

        private CFournisseurGeneriqueProprietesDynamiques m_fournisseurPropriete = null;

        private bool m_bInverserAxeX = false;
        private bool m_bInverserAxeY = false;
             
       
        private Cursor m_customCursor = null;
        private EModeEditeurComposantPhysique m_modeEnCours = EModeEditeurComposantPhysique.Selection;

        private CPanelEditeurComposantPhysique m_editeur;

        private ToolStripMenuItem m_mnu_itm_group = null;





        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public CPanelEditionComposantPhysique()
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

        protected override bool ShouldAjusteZoomSurFils()
        {
            return false;
        }

        public C2iComposant3D ComposantEdite
        {
            get
            {
                C2i3DEn2D c2D = ObjetEdite as C2i3DEn2D;
                if (c2D != null)
                    return c2D.Composant3D;
                return null;
            }
            set
            {
                if (value == null)
                    ObjetEdite = null;
                else
                {
                    C2i3DEn2D c2D = value.Get2D(VueAffichee) as C2i3DEn2D;
                    c2D.IsElementReference = true;
                    ObjetEdite = c2D;
                    AjusterZoom();
                }
            }
        }

        public override bool InverserAxeX
        {
            get
            {
                return m_bInverserAxeX;
            }
        }

        public override bool InverserAxeY
        {
            get
            {
                return m_bInverserAxeY;
            }
        }

        public EFaceVueDynamique VueAffichee
        {
            get
            {
                return m_faceAffichee;
            }
            set
            {
                m_faceAffichee = value;
                //List<C2iObjetGraphique> lstSel = new List<C2iObjetGraphique>(Selection);
                Selection.Clear();
                C2i3DEn2D compo = ObjetEdite as C2i3DEn2D;
                if (compo != null)
                {
                    compo.FaceVisible = value;
                }
                switch (value)
                {
                    case EFaceVueDynamique.Front:
                        m_bInverserAxeY = true;
                        m_bInverserAxeX = false;
                        break;
                    case EFaceVueDynamique.Left:
                        m_bInverserAxeX = false;
                        m_bInverserAxeY = true;
                        break;
                    case EFaceVueDynamique.Top:
                        m_bInverserAxeX = false;
                        m_bInverserAxeY = false;
                        break;
                    case EFaceVueDynamique.Rear:
                        m_bInverserAxeX = true;
                        m_bInverserAxeY = true;
                        break;
                    case EFaceVueDynamique.Right:
                        m_bInverserAxeX = true;
                        m_bInverserAxeY = true;
                        break;
                    case EFaceVueDynamique.Bottom:
                        m_bInverserAxeX = false;
                        m_bInverserAxeY = true;
                        break;
                    default:
                        break;
                }
                /*foreach (C2iObjetGraphique obj in lstSel)
                    Selection.Add(obj);*/
                Refresh();
            }
        }


        public CPanelEditeurComposantPhysique Editeur
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
            // CPanelEditionComposantPhysique
            // 
            cGrilleEditeurObjetGraphique1.Couleur = System.Drawing.Color.LightGray;
            cGrilleEditeurObjetGraphique1.HauteurCarreau = 20;
            cGrilleEditeurObjetGraphique1.LargeurCarreau = 20;
            cGrilleEditeurObjetGraphique1.Representation = sc2i.win32.common.ERepresentationGrille.LignesContinues;
            cGrilleEditeurObjetGraphique1.TailleCarreau = new System.Drawing.Size(20, 20);
            this.GrilleAlignement = cGrilleEditeurObjetGraphique1;
            this.ModeRepresentationGrille = sc2i.win32.common.ERepresentationGrille.LignesContinues;
            this.Name = "CPanelEditionComposantPhysique";
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
            //  this.Paint += new System.Windows.Forms.PaintEventHandler(this.CPanelEditionComposantPhysique_Paint);
            this.DoubleClick += new System.EventHandler(this.CPanelEditionComposantPhysique_DoubleClick);
            this.SelectionChanged += new System.EventHandler(this.CPanelEditionComposantPhysique_SelectionChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CPanelEditionComposantPhysique_KeyDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CPanelEditionComposantPhysique_MouseMove);
            this.AfterAddElements += new sc2i.win32.common.EventHandlerPanelEditionGraphiqueSuppression(this.CPanelEditionComposantPhysique_AfterAddElements);
            this.ResumeLayout(false);

        }

        public EModeEditeurComposantPhysique ModeEdition
        {
            get
            {
                return m_modeEnCours;
            }
            set
            {

                if (value == EModeEditeurComposantPhysique.Selection)
                {
                    ModeSouris = EModeSouris.Selection;
                    SelectionVisible = true;
                    
                }
                else if (value == EModeEditeurComposantPhysique.Zoom)
                {
                    ModeSouris = EModeSouris.Zoom;
                    SelectionVisible = true;
                    
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


                case EModeEditeurComposantPhysique.Selection:
                case EModeEditeurComposantPhysique.Zoom:
                    base.LoadCurseurAdapté();
                    return;


               /* case EModeEditeurComposantPhysique.EditionLigne:
                    {
                        if ((ModifierKeys & Keys.Shift) == Keys.Shift)
                        {

                            Cursor = C2iCursorLoader.LoadCursor(GetType(), "editLineDelPoint", Resources.editLineDelPoint);

                        }
                        else if ((ModifierKeys & Keys.Control) == Keys.Control)
                        {

                            Cursor = C2iCursorLoader.LoadCursor(GetType(), "editLineAddPoint", Resources.editLineAddPoint);

                        }
                        else
                        {
                            Point pt = GetLogicalPointFromDisplay(PointToClient(Cursor.Position));
                            if (m_ligneEditee != null && m_ligneEditee.IsCloseToPoint(pt))
                                Cursor = C2iCursorLoader.LoadCursor(GetType(), "editLineMovePoint", Resources.editLineMovePoint);
                            else
                                Cursor = C2iCursorLoader.LoadCursor(GetType(), "editLine", Resources.editLine);

                        }


                        break;
                    }
                case EModeEditeurComposantPhysique.EditionModificationPoint:
                    {

                        Cursor = C2iCursorLoader.LoadCursor(GetType(), "editLineMovePoint", EditeurGraphique.Properties.Resources.editLineMovePoint);


                        break;

                    }*/


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
                if (ModeEdition != EModeEditeurComposantPhysique.Selection)
                    ModeEdition = EModeEditeurComposantPhysique.Selection;

                base.LockEdition = value;
            }
        }


        


        public enum ECurseurEnCours
        {
            CursSelect,
            CursEdit,
            CursAdd,
            CursSuppr,
            CursMove,

        }


        

        public override void OnMouseUpNonStandard(object sender, MouseEventArgs e)
        {

            Point ptSouris = GetLogicalPointFromDisplay(new Point(e.X, e.Y));




            
        }
        private bool CPanelEditionComposantPhysique_AfterAddElements(List<I2iObjetGraphique> nouveaux)
        {
            
            foreach (I2iObjetGraphique obj in nouveaux)
            {
                C2i3DEn2D composant = obj as C2i3DEn2D;
                if (composant != null)
                {
                    composant.FaceVisible = EFaceVueDynamique.Front;
                }
            }

            return true;
        }

        protected override List<CDonneeDragDropObjetGraphique> GetDragDropData(IDataObject data)
        {
            List<CDonneeDragDropObjetGraphique> lst = base.GetDragDropData(data);
            foreach (CDonneeDragDropObjetGraphique donnee in lst)
            {
                C2i3DEn2D c3D = donnee.ObjetDragDrop as C2i3DEn2D;
            }
            return lst;
        }




        private void CPanelEditionComposantPhysique_DoubleClick(object sender, EventArgs e)
        {

            
        }
        

        public override void OnMouseDownNonStandard(object sender, MouseEventArgs e)
        {
            Point ptSouris = GetLogicalPointFromDisplay(new Point(e.X, e.Y));

            this.Capture = true;
        }
          

        private void CPanelEditionComposantPhysique_MouseMove(object sender, MouseEventArgs e)
        {

            if (ModeSouris != EModeSouris.Custom)
                return;
            LoadCurseurAdapté();
            Point mousePoint = GetLogicalPointFromDisplay(new Point(e.X, e.Y));

        }



        private void CPanelEditionSchemaReseau_MouseMove(object sender, MouseEventArgs e)
        {

            if (ModeSouris != EModeSouris.Custom)
                return;
            LoadCurseurAdapté();
            Point mousePoint = GetLogicalPointFromDisplay(new Point(e.X, e.Y));

        }


        protected override void AfficherMenuAdditonnel(ContextMenuStrip menu)
        {
        }


        private bool MNUGroup_Show()
        {
            return false;
            

        }


        private bool MNUHorizontalFlip_Show()
        {
            return false;
           
        }

        private bool MNUVerticalFlip_Show()
        {
            return false;
            

        }


        
        public void AjusterFond()
        {

            
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
           

        }
        public virtual void MNU_VerticalFlip()
        {
           
        }

       

        private void CPanelEditionComposantPhysique_KeyDown(object sender, KeyEventArgs e)
        {
        }




        private void CPanelEditionComposantPhysique_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        public event OnDessinerEventHandler DessinerEventHandler;

        public override void Dessiner(bool bElement, bool bSelection)
        {
            if (DessinerEventHandler != null)
                DessinerEventHandler(this, bElement, bSelection);
        }

        public virtual void DoMyDessin ( bool bElement, bool bSelection )
        {
            //SetSelection(Selection);
            base.Dessiner(bElement, bSelection);
            
        }

        public override void MyDrawElementsSupplementaires(Graphics gPretPourDessinElementsLogiques)
        {
            base.MyDrawElementsSupplementaires(gPretPourDessinElementsLogiques);
            Matrix oldM = gPretPourDessinElementsLogiques.Transform;
            gPretPourDessinElementsLogiques.Transform.Reset();
            gPretPourDessinElementsLogiques.Transform = new Matrix();
            //gPretPourDessinElementsLogiques.TranslateTransform(-AutoScrollPosition.X, -AutoScrollPosition.Y);
            Brush br = new SolidBrush(Color.FromArgb(128, 0, 0, 0));
            gPretPourDessinElementsLogiques.DrawString(VueAffichee.ToString(), Font, br, new Point(5, 5));
            //Dessin des axes
            Pen pen = new Pen(br);
            pen.EndCap = LineCap.ArrowAnchor;
            SizeF szText = gPretPourDessinElementsLogiques.MeasureString("x", Font);
            switch (VueAffichee)
            {
                case EFaceVueDynamique.Front:
                    gPretPourDessinElementsLogiques.DrawLine(pen, new Point(2, ClientSize.Height-2), new Point(42, ClientSize.Height-2));
                    gPretPourDessinElementsLogiques.DrawLine(pen, new Point(2, ClientSize.Height-2), new Point(2, ClientSize.Height-42));
                    gPretPourDessinElementsLogiques.DrawString("x", Font, br, new Point(42-(int)szText.Width, ClientSize.Height - 4 - (int)szText.Height));
                    gPretPourDessinElementsLogiques.DrawString("y", Font, br, new Point(4, ClientSize.Height - 40));
                    break;
                case EFaceVueDynamique.Left:
                    gPretPourDessinElementsLogiques.DrawLine(pen, new Point(2, ClientSize.Height - 2), new Point(42, ClientSize.Height - 2));
                    gPretPourDessinElementsLogiques.DrawLine(pen, new Point(2, ClientSize.Height - 2), new Point(2, ClientSize.Height - 42));
                    gPretPourDessinElementsLogiques.DrawString("z", Font, br, new Point(42 - (int)szText.Width, ClientSize.Height - 4 - (int)szText.Height));
                    gPretPourDessinElementsLogiques.DrawString("y", Font, br, new Point(4, ClientSize.Height - 40));
                    break;
                case EFaceVueDynamique.Top:
                    gPretPourDessinElementsLogiques.DrawLine(pen, new Point(2, 2), new Point(42, 2));
                    gPretPourDessinElementsLogiques.DrawLine(pen, new Point(2, 2), new Point(2, 42));
                    gPretPourDessinElementsLogiques.DrawString("x", Font, br, new Point(42 - (int)szText.Width, 4));
                    gPretPourDessinElementsLogiques.DrawString("z", Font, br, new Point(4, 42-(int)szText.Height));
                    break;
                case EFaceVueDynamique.Rear:
                    gPretPourDessinElementsLogiques.DrawLine(pen, new Point(ClientSize.Width-2, ClientSize.Height - 2), new Point(ClientSize.Width-42, ClientSize.Height - 2));
                    gPretPourDessinElementsLogiques.DrawLine(pen, new Point(ClientSize.Width - 2, ClientSize.Height - 2), new Point(ClientSize.Width - 2, ClientSize.Height - 42));
                    gPretPourDessinElementsLogiques.DrawString("x", Font, br, new Point(ClientSize.Width - 42 , ClientSize.Height - 4 - (int)szText.Height));
                    gPretPourDessinElementsLogiques.DrawString("y", Font, br, new Point(ClientSize.Width-4 - (int)szText.Width, ClientSize.Height - 40));
                    break;
                case EFaceVueDynamique.Right:
                    gPretPourDessinElementsLogiques.DrawLine(pen, new Point(ClientSize.Width - 2,  2), new Point(ClientSize.Width - 42, 2));
                    gPretPourDessinElementsLogiques.DrawLine(pen, new Point(ClientSize.Width - 2, 2), new Point(ClientSize.Width - 2, 42));
                    gPretPourDessinElementsLogiques.DrawString("z", Font, br, new Point(ClientSize.Width - 42));
                    gPretPourDessinElementsLogiques.DrawString("y", Font, br, new Point(ClientSize.Width - 4 - (int)szText.Width, 42-(int)szText.Height));
                    break;
                case EFaceVueDynamique.Bottom:
                    gPretPourDessinElementsLogiques.DrawLine(pen, new Point(2, ClientSize.Height - 2), new Point(42, ClientSize.Height - 2));
                    gPretPourDessinElementsLogiques.DrawLine(pen, new Point(2, ClientSize.Height - 2), new Point(2, ClientSize.Height - 42));
                    gPretPourDessinElementsLogiques.DrawString("x", Font, br, new Point(42 - (int)szText.Width, ClientSize.Height - 4 - (int)szText.Height));
                    gPretPourDessinElementsLogiques.DrawString("z", Font, br, new Point(4, ClientSize.Height - 40));
                    break;
                default:
                    break;
            }
            
            pen.Dispose();
            br.Dispose();
            
            gPretPourDessinElementsLogiques.Transform = oldM;
        }

        public void SetSelection(List<I2iObjetGraphique> lst)
        {
            List<I2iObjetGraphique> listePourMoi = new List<I2iObjetGraphique>();
            Selection.Clear();
            if (ObjetEdite != null && lst != null)
            {
                lst = new List<I2iObjetGraphique>(lst);
                Size szRef = ObjetEdite.Size;
                foreach (I2iObjetGraphique obj in lst)
                {
                    C2i3DEn2D c3D = obj as C2i3DEn2D;
                    if (c3D != null)
                        listePourMoi.Add(c3D.Composant3D.Get2D(VueAffichee));
                }
                Selection.AddRange(listePourMoi);
            }
        }

        protected override void JusteBeforePositionneSurApresDragDrop(I2iObjetGraphique objet)
        {
            C2i3DEn2D obj2D = objet as C2i3DEn2D;
            if (obj2D != null)
                obj2D.FaceVisible = m_faceAffichee;
        }

    }


    public enum EModeEditeurComposantPhysique
    {
        Selection,
        Zoom,
        EditionLigne,
        EditionModificationPoint
    }

}
