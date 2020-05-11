using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

using sc2i.common;
using sc2i.win32.common;
using sc2i.win32.data.navigation;

using timos.data;
using timos.data.projet.gantt;
using timos.data.projet.Contraintes;
using timos.win32.composants;
using timos.win32.composants.Properties;
using timos.win32.composants.gantt;
using sc2i.formulaire.win32;
using System.Drawing.Drawing2D;

namespace timos.win32.gantt
{
    public partial class CGanttBar : UserControl, IControlALockEdition
    {
        private const int c_nWidthCrochetReel = 15;

        CParametresAffichageGantt m_parametreAffichage = new CParametresAffichageGantt();
        CParametreDessinLigneGantt m_parametreDessin = CParametreDessinLigneGantt.ParametreParDefaut;
        private IBaseGantt m_baseGantt = null;
        private EventHandler m_fonctionOnChangeParametre = null;

        private Bitmap m_imageDragEnCours = null;

        private IFournisseurXGantt m_fournisseurX = null;
        private IFournisseurYGantt m_fournisseurY = null;

        private Color m_selectedBackColor = Color.LightBlue;

        private Dictionary<IElementDeGantt, int[]> m_dicElementGanttToZoneY = new Dictionary<IElementDeGantt, int[]>();
        private Dictionary<IElementDeGantt, Rectangle> m_dicElementGanttToRectangle = new Dictionary<IElementDeGantt, Rectangle>();

        private Dictionary<IElementDeGantt, Rectangle> m_dicElementGanttToRectangleAccesDirect = new Dictionary<IElementDeGantt, Rectangle>();

        private IElementDeGantt m_elementSelectionne = null;

        public event GanttElementEventHandler BarContextMenuOpenning;

        public CGanttBar()
        {
            m_fonctionOnChangeParametre = new EventHandler(OnChangeParametre);
            InitializeComponent();
        }

        //-------------------------------------------------------------------
        public CParametreDessinLigneGantt ParametreDessinLigne
        {
            get
            {
                return m_parametreDessin;
            }
            set
            {
                if (value != null)
                {
                    m_parametreDessin = value;
                    Refresh();
                }
            }
        }

        //-------------------------------------------------------------------
        public override void Refresh()
        {
            if (m_parametreDessin != null && m_baseGantt != null)
                m_baseGantt.AppliqueParametreDessin(m_parametreDessin);
            base.Refresh();
        }

        //-------------------------------------------------------------------
        public DateTime DateFin
        {
            get
            {
                return ParametreAffichage.CalcDateFin(ClientSize.Width);
            }
        }

        //-------------------------------------------------------------------
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


        //-------------------------------------------------------------------
        public CParametresAffichageGantt ParametreAffichage
        {
            get
            {
                return m_parametreAffichage;
            }
            set
            {
                if (m_parametreAffichage != null)
                    m_parametreAffichage.OnChangeParametrage -= m_fonctionOnChangeParametre;
                m_parametreAffichage = value;
                m_parametreAffichage.OnChangeParametrage += m_fonctionOnChangeParametre;
                
            }
        }

        //-------------------------------------------------------------------
        public void OnChangeParametre(object sender, EventArgs args)
        {
            if (sender == m_parametreAffichage)
                Invalidate();
        }

        //-------------------------------------------------------------------
        public void Init(
            CParametresAffichageGantt parametre,
            IBaseGantt baseGantt,
            IFournisseurXGantt fournisseurX,
            IFournisseurYGantt fournisseurY)
        {
            m_baseGantt = baseGantt;
            ParametreAffichage = parametre;
            m_fournisseurX = fournisseurX;
            m_fournisseurY = fournisseurY;
        }

        //-------------------------------------------------------------------
        private void CBarresGantt_Paint(object sender, PaintEventArgs e)
        {
            DrawGantt(e.Graphics);
        }

        //-------------------------------------------------------------------
        private void DrawGantt ( Graphics g )
        {
            Rectangle rct = ClientRectangle;
            Brush brFond = new SolidBrush(BackColor);
            Brush brFondSel = new SolidBrush(SelectedBackColor);
            Color couleurFond = BackColor;
            Brush brFore = new SolidBrush(ForeColor);
            Pen pen = new Pen(ForeColor);

            g.FillRectangle(brFond, rct);

            if (m_fournisseurY == null || m_fournisseurX == null)
                return;

            IEnumerable<IElementDeGantt> lstElements = new List<IElementDeGantt>();
            if ( m_baseGantt != null )
                lstElements = m_baseGantt.GetElements ( );


            m_dicElementGanttToZoneY.Clear();
            m_dicElementGanttToRectangle.Clear();
            m_dicElementGanttToRectangleAccesDirect.Clear();

            Pen penFleche = new Pen(Color.Black);
            penFleche.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            penFleche.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            penFleche.Width = 3;

        
            try
            {

                foreach (IElementDeGantt eltLigne in lstElements)
                {
                    int[] ys = m_fournisseurY.GetYBounds(eltLigne);
                    if (ys == null || ys.Length != 2)
                        continue;//Pas de position en y
                    bool bIntersectClip = ys[1] >= g.ClipBounds.Top &&
                        ys[0] <= g.ClipBounds.Bottom;
                    bool bLineIsClean = false;
                    
                    m_dicElementGanttToZoneY[eltLigne] = ys;

                    bool bIsSel = eltLigne.ElementsADessinerSurLaLigne.Contains(m_elementSelectionne) || eltLigne == m_elementSelectionne;
                    couleurFond = bIsSel ? SelectedBackColor : BackColor;
                    foreach (IElementDeGantt elt in eltLigne.ElementsADessinerSurLaLigne)
                    {
                        int[] xs = m_fournisseurX.GetXBounds(elt);
                        //int[] xs = new int[] { 2, 12 };
                        if (xs == null || xs.Length != 2)
                            continue;//Pas de positionX
                        Rectangle rctCell = new Rectangle(rct.Left, ys[0], rct.Right, ys[1] - ys[0]);
                        m_dicElementGanttToZoneY[elt] = ys;
                        if (bIntersectClip && !bLineIsClean)
                        {
                            g.FillRectangle(bIsSel ? brFondSel : brFond, rctCell);
                            g.DrawRectangle(pen, rctCell);
                            bLineIsClean = true;
                        }

                        Rectangle rctBarre = new Rectangle(
                            xs[0],
                            ys[0],
                            xs[1] - xs[0],
                            ys[1] - ys[0]);
                        rctBarre.Inflate(0, -4);

                        bool bBarreVisible = rctBarre.Right > g.ClipBounds.Left &&
                            rctBarre.Left < g.ClipBounds.Right;


                        if (bBarreVisible)
                        {
                            if (bIntersectClip)
                            {
                                elt.Draw(rctBarre, m_fournisseurX, g);
                                /*SizeF szText = g.MeasureString(elt.LibelleBarre, Font);
                                g.DrawString(elt.LibelleBarre, Font, brFore, new Point((int)(rctBarre.Left - szText.Width), rctBarre.Y - 2));*/
                                if (elt == m_elementSelectionne && elt != eltLigne)
                                {
                                    Pen p = new Pen(Color.Black, 2);
                                    g.DrawRectangle(p, rctBarre);
                                }
                            }
                            Rectangle rctCorrige = rctBarre;
                            if (rctCorrige.Width == 0)
                                rctCorrige.Inflate(4, 0);
                            m_dicElementGanttToRectangle[elt] = rctCorrige;
                        }
                        else//element non visible
                        {
                            int nYFleche = rctBarre.Top + rctBarre.Height / 2;
                            Rectangle rctFleche = new Rectangle(0, 0, 0, 0);
                            if (rctBarre.Right < 0)
                            {
                                if (bIntersectClip)
                                    g.DrawLine(penFleche, 20, nYFleche, 5, nYFleche);
                                rctFleche = new Rectangle(5, nYFleche - 4, 20, 8);
                            }
                            else if (rctBarre.Left > ClientSize.Width)
                            {
                                if (bIntersectClip)
                                    g.DrawLine(penFleche, ClientSize.Width - 20, nYFleche, ClientSize.Width - 5, nYFleche);
                                rctFleche = new Rectangle(ClientRectangle.Width - 20, nYFleche - 4, 20, 8);
                            }
                            if (rctFleche.Width > 0)
                                m_dicElementGanttToRectangleAccesDirect[elt] = rctFleche;
                        }

                        // Dessin des Contraintes de l'élement
                        foreach (IContrainteDeGantt contrainte in elt.Contraintes)
                        {
                            // On ne dessine que les contraintes propores
                            if (!contrainte.ContraintePropre)
                                continue;

                            DateTime dtContrainte = contrainte.Date;

                            int xContrainte = m_fournisseurX.GetX(contrainte.Date);
                            int xDebutFleche = 0, xFinFleche = 0;

                            // La contrainte est-elle visible ?
                            if (xContrainte > g.ClipBounds.Left && xContrainte < g.ClipBounds.Right)
                            {
                                if (bIntersectClip)
                                {
                                    Color couleurContrainte = Color.Black;
                                    switch (contrainte.Mode.Code)
                                    {
                                        case EModeContrainteDeGantt.DebutAuPlusTot:
                                            couleurContrainte = Color.Green;
                                            xDebutFleche = xContrainte + 2;
                                            xFinFleche = xDebutFleche + 20;
                                            break;
                                        case EModeContrainteDeGantt.DebutAuPlusTard:
                                            couleurContrainte = Color.Green;
                                            xDebutFleche = xContrainte - 2;
                                            xFinFleche = xDebutFleche - 20;
                                            break;
                                        case EModeContrainteDeGantt.FinAuPlusTot:
                                            couleurContrainte = Color.Red;
                                            xFinFleche = xContrainte + 2;
                                            xDebutFleche = xFinFleche + 20;
                                            break;
                                        case EModeContrainteDeGantt.FinAuPlusTard:
                                            couleurContrainte = Color.Red;
                                            xFinFleche = xContrainte - 2;
                                            xDebutFleche = xFinFleche - 20;
                                            break;
                                        default:
                                            break;
                                    }

                                    Pen penContrainte = new Pen(couleurContrainte);
                                    // Dessine la barre verrticale de la contriante
                                    penContrainte.Width = 3;
                                    g.DrawLine(penContrainte, xContrainte, rctCell.Top + 1, xContrainte, rctCell.Bottom);
                                    // Dessine la fleche horizontale de la contrainte
                                    penContrainte.Width = 1;
                                    int yFleche = (int)(rctCell.Top + rctCell.Bottom) / 2;
                                    g.DrawLine(penContrainte, xDebutFleche, yFleche, xFinFleche, yFleche);
                                    // Dessin de la petite fleche de la contrainte
                                    Brush brContrainte = new SolidBrush(penContrainte.Color);
                                    int xEpaisseurFleche = -5;
                                    int yEpaisseurFleche = 6;
                                    if (xFinFleche < xDebutFleche)
                                        xEpaisseurFleche = -xEpaisseurFleche + 1;
                                    g.FillPolygon(brContrainte, new Point[]{
                                    new Point(xFinFleche, yFleche),
                                    new Point(xFinFleche + xEpaisseurFleche, yFleche - yEpaisseurFleche),
                                    new Point(xFinFleche + xEpaisseurFleche, yFleche + yEpaisseurFleche),
                                });
                                    penContrainte.Dispose();
                                    brContrainte.Dispose();
                                }
                            }
                        }

                        int nWidthCrocheReel = c_nWidthCrochetReel;
                        if (elt.DateDebutReelle != null && elt.DateFinReelle != null)
                        {
                            int nTmp = m_fournisseurX.GetX(elt.DateFinReelle.Value) - m_fournisseurX.GetX(elt.DateDebutReelle.Value);
                            nWidthCrocheReel = Math.Max(5, Math.Min(nWidthCrocheReel, nTmp / 2));
                        }

                        Color? cTerminee = m_parametreDessin.ParametreBarre.GetCouleurTerminee(elt);

                        if (cTerminee != null && elt.DateDebutReelle != null)
                        {
                            int nXStart = m_fournisseurX.GetX(elt.DateDebutReelle.Value);

                            bool bAvant = nXStart < 0;
                            bool bApres = nXStart > ClientSize.Width;
                            bool bOut = bAvant || bApres;
                            if (bAvant)
                                nXStart = 20;
                            if (bApres)
                                nXStart = ClientSize.Width - 20;
                            Brush br = null;
                            if (nWidthCrocheReel == c_nWidthCrochetReel || bOut)
                            {
                                br = new LinearGradientBrush(new Point(nXStart, 0),
                                    new Point(nXStart + nWidthCrocheReel, 0),
                                    !bOut ? cTerminee.Value : Color.FromArgb(50, cTerminee.Value),
                                    couleurFond);
                            }
                            else
                                br = new SolidBrush(cTerminee.Value);
                            List<Point> lstPoints = new List<Point>();
                            lstPoints.Add(new Point(nXStart, rctCell.Top + 2));
                            lstPoints.Add(new Point(nXStart + nWidthCrocheReel, rctCell.Top + 2));
                            lstPoints.Add(new Point(nXStart + nWidthCrocheReel, rctCell.Top + 4));
                            lstPoints.Add(new Point(nXStart + 3, rctCell.Top + 4));
                            lstPoints.Add(new Point(nXStart + 3, rctCell.Bottom - 3));
                            lstPoints.Add(new Point(nXStart + nWidthCrocheReel, rctCell.Bottom - 3));
                            lstPoints.Add(new Point(nXStart + nWidthCrocheReel, rctCell.Bottom - 1));
                            lstPoints.Add(new Point(nXStart, rctCell.Bottom - 1));
                            g.FillPolygon(br, lstPoints.ToArray());
                            if (bAvant)
                                g.DrawLine(penFleche, nXStart, rctCell.Top + rctCell.Height / 2, nXStart - 5, rctCell.Top + rctCell.Height / 2);
                            if (bApres)
                                g.DrawLine(penFleche, nXStart + 3, rctCell.Top + rctCell.Height / 2, nXStart + 8, rctCell.Top + rctCell.Height / 2);
                            br.Dispose();
                        }




                        if (cTerminee != null && elt.DateFinReelle != null)
                        {
                            int nXEnd = m_fournisseurX.GetX(elt.DateFinReelle.Value);
                            bool bAvant = nXEnd < 0;
                            bool bApres = nXEnd > ClientSize.Width;
                            bool bOut = bAvant || bApres;
                            if (bAvant)
                                nXEnd = 20;
                            if (bApres)
                                nXEnd = ClientSize.Width - 20;

                            Brush br = null;
                            if (nWidthCrocheReel == c_nWidthCrochetReel)
                                br = new LinearGradientBrush(new Point(nXEnd, 0),
                                 new Point(nXEnd - nWidthCrocheReel - 1, 0),
                                 !bOut ? cTerminee.Value : Color.FromArgb(50, cTerminee.Value),
                                 couleurFond);
                            else
                                br = new SolidBrush(cTerminee.Value);
                            List<Point> lstPoints = new List<Point>();
                            lstPoints.Add(new Point(nXEnd, rctCell.Top + 2));
                            lstPoints.Add(new Point(nXEnd - nWidthCrocheReel, rctCell.Top + 2));
                            lstPoints.Add(new Point(nXEnd - nWidthCrocheReel, rctCell.Top + 4));
                            lstPoints.Add(new Point(nXEnd - 3, rctCell.Top + 4));
                            lstPoints.Add(new Point(nXEnd - 3, rctCell.Bottom - 3));
                            lstPoints.Add(new Point(nXEnd - nWidthCrocheReel, rctCell.Bottom - 3));
                            lstPoints.Add(new Point(nXEnd - nWidthCrocheReel, rctCell.Bottom - 1));
                            lstPoints.Add(new Point(nXEnd, rctCell.Bottom - 1));


                            g.FillPolygon(br, lstPoints.ToArray());
                            if (bAvant)
                                g.DrawLine(penFleche, nXEnd-3, rctCell.Top + rctCell.Height / 2, nXEnd - 8, rctCell.Top + rctCell.Height / 2);
                            if (bApres)
                                g.DrawLine(penFleche, nXEnd , rctCell.Top + rctCell.Height / 2, nXEnd + 5, rctCell.Top + rctCell.Height / 2);
                            br.Dispose();

                        }
                        if (cTerminee != null && elt.DateDebutReelle != null && elt.DateFinReelle != null )
                        {
                            Rectangle rctFin = new Rectangle(
                                m_fournisseurX.GetX(elt.DateDebutReelle.Value) + nWidthCrocheReel / 2, rctCell.Top + 3,
                                m_fournisseurX.GetX(elt.DateFinReelle.Value) - m_fournisseurX.GetX(elt.DateDebutReelle.Value) - nWidthCrocheReel,
                                rctCell.Height - 5);
                            Pen p = new Pen(Color.FromArgb(128, cTerminee.Value), 2);
                            p.DashStyle = DashStyle.Dot;
                            g.DrawLine(p, rctFin.Left, rctFin.Top, rctFin.Right, rctFin.Top);
                            g.DrawLine(p, rctFin.Left, rctFin.Bottom, rctFin.Right, rctFin.Bottom);
                            p.Dispose();
                        }



                    }

                }
                
                penFleche.Dispose();

                
                foreach (KeyValuePair<IElementDeGantt, Rectangle> kv in m_dicElementGanttToRectangle)
                {
                    IElementDeGantt elt = kv.Key;
                    Rectangle rctDest = kv.Value;
                    // Dessin des Liens entre élements de Gantt (Predecesseur --> Successeur)
                    foreach (IElementDeGantt predecesseur in elt.Predecesseurs)
                    {
                        Rectangle rctSource = new Rectangle(0, 0, 0, 0);
                        if (m_dicElementGanttToRectangle.TryGetValue(predecesseur, out rctSource))
                        {
                            Pen penLien = null;
                            if (!elt.RespectePredecesseur(predecesseur))
                            {
                                penLien = new Pen(Color.Red);
                                penLien.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                                penLien.Width = 2;
                            }
                            else
                                penLien = new Pen(Color.Blue);
                            int nYSource,
                                nYDest;
                            nYSource = (rctSource.Bottom + rctSource.Top) / 2;
                            nYDest = rctDest.Top - 2;
                            if (nYDest < nYSource)
                                nYDest = rctDest.Bottom + 2;
                            // Dessin de la partie horizontale du lien
                            g.DrawLine(penLien, rctSource.Right, nYSource,
                                rctDest.Left, nYSource);
                            // Dessin de la partie verticale du lien
                            g.DrawLine(penLien, rctDest.Left, nYSource,
                                rctDest.Left, nYDest);
                            // Dessin de la fleche de bout de lien
                            int nYFleche = 6;
                            if (nYDest > nYSource)
                                nYFleche = -nYFleche;
                            Brush brBlue = new SolidBrush(penLien.Color);
                            g.FillPolygon(brBlue, new Point[]{
                            new Point ( rctDest.Left-5, nYDest+nYFleche ),
                            new Point ( rctDest.Left, nYDest ),
                            new Point ( rctDest.Left+6, nYDest+nYFleche)});
                            penLien.Dispose();
                            brBlue.Dispose();
                        }
                    }

                }
            }
            catch { }
            
            brFond.Dispose();
            brFore.Dispose();
            pen.Dispose();


            //Dessin des lignes
            int nXLigne = 0;
            DateTime dateLigne = ParametreAffichage.DateDebut;
            Pen penLigne = new Pen(Color.FromArgb(120, 192, 192,192));
            penLigne.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            while (nXLigne < ClientSize.Width)
            {
                dateLigne = ParametreAffichage.AddCells(dateLigne, 1);
                nXLigne = m_fournisseurX.GetX(dateLigne);
                g.DrawLine(penLigne, nXLigne, 0, nXLigne, ClientSize.Height);
            }
            penLigne.Dispose();


        }

        private int CalcX(DateTime date)
        {
            DateTime dateFin = ParametreAffichage.CalcDateFin(ClientSize.Width);
            if (date < ParametreAffichage.DateDebut)
                return -1;
            if (date > dateFin)
                return ClientSize.Width + 1;
            DateTime dateDebut = ParametreAffichage.DateDebut;
            
            TimeSpan spTotal = dateFin - ParametreAffichage.DateDebut;
            TimeSpan spElement = date - ParametreAffichage.DateDebut;
            double fRatio = spElement.TotalHours / spTotal.TotalHours;
            return (int)((ClientSize.Width) * fRatio);
        }

        protected void Refresh(IElementDeGantt elt)
        {
            if (m_fournisseurY == null)
                return;
            int[] ys = m_fournisseurY.GetYBounds(elt);
            if (ys == null)
                return;
            Rectangle rct = new Rectangle(0, ys[0], ClientSize.Width,
                ys[1] - ys[0]);
            Invalidate(rct);
        }

        public event EventHandler SelectionChanged;

        public IElementDeGantt SelectedElement
        {
            get
            {
                return m_elementSelectionne;
            }
            set
            {
                if (m_elementSelectionne != value && 
                    (value== null || !value.ElementsADessinerSurLaLigne.Contains (m_elementSelectionne)))
                {
                    if (m_elementSelectionne != null)
                        Refresh(m_elementSelectionne);
                    m_elementSelectionne = value;
                    if (SelectionChanged != null)
                        SelectionChanged(this, new EventArgs());
                    if (m_elementSelectionne != null)
                        Refresh(m_elementSelectionne);
                }
            }
        }

        //----------------------------------------------------------------
        private int m_nXStartDrag = -1;
        private int m_nYStartDrag = -1;
        private bool m_bDragEnCours = false;
        private void CGanttBar_MouseDown(object sender, MouseEventArgs e)
        {
            m_nXStartDrag = e.X;
            m_nYStartDrag = e.Y;
            Capture = true;
        }

        //----------------------------------------------------------------
        private void CalculImageDragDrop()
        {
            if (m_imageDragEnCours != null)
            {
                m_imageDragEnCours.Dispose();
                m_imageDragEnCours = null;
            }
            if (SelectedElement == null)
                return;
            int[] nYs;
            if (m_dicElementGanttToZoneY.TryGetValue(SelectedElement, out nYs))
            {
                Rectangle rct = new Rectangle(0, nYs[0], ClientSize.Width, nYs[1]-nYs[0]);
                m_imageDragEnCours = new Bitmap(ClientSize.Width, nYs[1] - nYs[0]);
                Graphics g = Graphics.FromImage(m_imageDragEnCours);
                g.TranslateTransform(0, -rct.Top);
                g.SetClip (  new Rectangle(0, 0, ClientSize.Width, nYs[1]) );
                DrawGantt(g);
            }
        }

        //----------------------------------------------------------------
        private void DrawImageDragDrop()
        {
            if (m_imageDragEnCours == null)
                return;
            if (SelectedElement == null)
                return;

            int[] nYs;
            if (m_dicElementGanttToZoneY.TryGetValue(SelectedElement, out nYs))
            {
                Graphics g = CreateGraphics();
                g.DrawImageUnscaled(m_imageDragEnCours, new Point(0, nYs[0]));
                g.Dispose();
            }
        }

        //----------------------------------------------------------------
        private DateTime GetDateDragDrop( int nX)
        {
            int nNbCells = (nX - m_nXStartDrag) / ParametreAffichage.CellWidth;
            return m_fournisseurX.AddCells(SelectedElement.DateDebut, nNbCells);
        }

        //----------------------------------------------------------------
        private void DrawRectDragDrop(int nX)
        {
            Rectangle rct;
            if (SelectedElement == null)
                return;
            if (m_dicElementGanttToRectangle.TryGetValue(SelectedElement, out rct))
            {
                int nNbCells = (nX - m_nXStartDrag) / ParametreAffichage.CellWidth;
                rct = new Rectangle(rct.Left + nNbCells * ParametreAffichage.CellWidth, rct.Y, rct.Width, rct.Height);
                int nLeft = rct.Left;
                int nRight = rct.Right;
                if (nLeft < 0)
                    nLeft = -1;
                if (nRight > ClientSize.Width)
                    nRight = ClientSize.Width + 1;
                rct = new Rectangle(rct.Left, rct.Y, nRight - nLeft, rct.Height);
                Graphics g = CreateGraphics();
                Pen pen = new Pen(Color.Black);
                Brush br = new SolidBrush(Color.FromArgb ( 50, 0, 0, 255));
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                g.FillRectangle(br, rct);
                g.DrawRectangle(pen, rct);
                br.Dispose();
                pen.Dispose();
                
                g.Dispose();
                m_fournisseurX.Highlight(rct.Left, rct.Right);
            }
        }


        //----------------------------------------------------------------
        private void CGanttBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (!m_bDragEnCours)
            {
                IElementDeGantt elt = GetElementAt ( new Point ( e.X, e.Y ) );
                if (elt != null && !LockEdition)
                {
                    if (elt.MoveAutorise)
                        Cursor = Cursors.NoMoveHoriz;
                    else
                        Cursor = Cursors.No;
                }
                else
                {
                    Point pt = new Point(e.X, e.Y);
                    KeyValuePair<IElementDeGantt, Rectangle>? kv = m_dicElementGanttToRectangleAccesDirect.FirstOrDefault
                        (
                        k => k.Value.Contains(pt)
                        );
                    if (kv != null && kv.Value.Key != null)
                        Cursor = Cursors.Hand;
                    else
                    {
                        if (ModifierKeys == Keys.Control && !LockEdition)
                            Cursor = (Cursor)new Cursor(new MemoryStream(Resources.CurseurLienProjet));
                        else
                            Cursor = Cursors.Arrow;
                    }
                }
                if ( !LockEdition && Math.Abs ( e.X - m_nXStartDrag ) > 3 && MouseButtons == MouseButtons.Left)
                {
                    elt = GetElementAt ( new Point ( m_nXStartDrag, m_nYStartDrag ));
                    if ( elt != null  && elt.MoveAutorise)
                    {
                        m_bDragEnCours = true;
                        SelectedElement = elt;
                        CalculImageDragDrop();
                        Capture = true;
                    }
                }
            }
            if (m_bDragEnCours && MouseButtons == MouseButtons.Left )
            {
                DrawImageDragDrop();
                DrawRectDragDrop( e.X );
            }

        }

        [ControleExterneEvent("Before moving", "Is launched before a gantt bar is moved")]
        public event ControleExterneEventHandler BeforeMoveBar;


        //Permet aux éléments qui chopent l'évenement BeforeMoveBar de connaitre
        //le projet en cours de déplacement
        private IElementDeGantt m_movingBar;
        [DynamicField("Moving bar")]
        public IElementDeGantt MovingBar
        {
            get
            {
                return m_movingBar;
            }
            set
            {
                m_movingBar = value;
            }
        }


        //----------------------------------------------------------------
        private void CGanttBar_MouseUp(object sender, MouseEventArgs e)
        {
            Capture = false;

            Point ptMenu = new Point(e.X, e.Y);
            ptMenu = PointToScreen(ptMenu);

            if (!m_bDragEnCours)
            {
                IElementDeGantt eltSel = GetElementAt(new Point(e.X, e.Y));
                if (eltSel == null)
                {
                    KeyValuePair<IElementDeGantt, int[]>? sel = m_dicElementGanttToZoneY.FirstOrDefault(kv => kv.Value[0] < e.Y && kv.Value[1] > e.Y);
                    if (sel != null)
                        eltSel = sel.Value.Key;
                }
                if (eltSel != null)
                {
                    if (!LockEdition)
                    {
                        if ((e.Button & MouseButtons.Left) == MouseButtons.Left && ModifierKeys == Keys.Control && SelectedElement != null)
                        {
                            if (eltSel is CElementDeGanttProjet && SelectedElement is CElementDeGanttProjet)
                            {
                                if (eltSel.Predecesseurs.Contains(SelectedElement))
                                {
                                    if (MessageBox.Show(I.T("Remove dependancy between @1 and @2 ?|20002",
                                        eltSel.Libelle, SelectedElement.Libelle), "",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        eltSel.RemovePredecesseur(SelectedElement);
                                        Refresh();
                                    }
                                }
                                else
                                {
                                    if (MessageBox.Show(I.T("Create dependancy between @1 and @2 ?|20003",
                                        eltSel.Libelle, SelectedElement.Libelle), "",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        CResultAErreur result = eltSel.AddPredecesseur(SelectedElement);
                                        if (!result)
                                        {
                                            CFormAfficheErreur.Show(result.Erreur);
                                        }
                                        else
                                            Refresh();
                                    }
                                }
                            }
                        }
                    }
                    //Acces direct ?
                    Point pt = new Point(e.X, e.Y);
                    KeyValuePair<IElementDeGantt, Rectangle>? kv = m_dicElementGanttToRectangleAccesDirect.FirstOrDefault
                        (
                        k => k.Value.Contains(pt)
                        );
                    if (kv != null && kv.Value.Key != null)
                    {
                        ParametreAffichage.DateDebut = ParametreAffichage.AddCells(kv.Value.Key.DateDebut,-1);
                    }
                    SelectedElement = eltSel;
                }
                else
                {
                    SelectedElement = null;
                }

                // Gestion du menu contextuel
                if ((e.Button & MouseButtons.Right) == MouseButtons.Right)
                {
                    ContextMenuStrip menuElementDeGantt = new ContextMenuStrip();
                    menuElementDeGantt.Opening += new CancelEventHandler(menuElementDeGantt_Opening);


                    if (SelectedElement != null)
                    {
                        bool bEnableMenu = !LockEdition;
                        // Ajoute les items sur l'élement de Gantt
                        ToolStripMenuItem itemLabelElementDeGantt = new ToolStripMenuItem(SelectedElement.Libelle);
                        itemLabelElementDeGantt.Enabled = false;

                        CToolStripDateTimePicker itemControlDateDebut = new CToolStripDateTimePicker();
                        itemControlDateDebut.StartDate = SelectedElement.DateDebut;
                        itemControlDateDebut.EndDate = SelectedElement.DateFin;
                        itemControlDateDebut.OnValideDates += new EventHandler(itemControlDates_OnValueChanged);
                        itemControlDateDebut.Enabled = bEnableMenu;

                        menuElementDeGantt.Items.Add(itemLabelElementDeGantt);
                        menuElementDeGantt.Items.Add(itemControlDateDebut);

                        menuElementDeGantt.Items.Add(new ToolStripSeparator());

                    }
                    else
                    {
                        ToolStripMenuItem itemTitre = new ToolStripMenuItem("-----------------"); // Juste pour permetre au menu de s'ouvrir même si Selectedelement est null
                        itemTitre.Enabled = false;
                        menuElementDeGantt.Items.Add(itemTitre);
                    }

                    // Affiche le menu contextuel sur elements de Gantt
                    menuElementDeGantt.Show(ptMenu);
                }
            }
            else
            {
                DrawImageDragDrop();
                if (m_imageDragEnCours != null)
                {
                    m_imageDragEnCours.Dispose();
                    m_imageDragEnCours = null;
                }
                m_bDragEnCours = false;
                m_fournisseurX.Highlight(-1, -1);
                DateTime dateDebut = m_fournisseurX.AddCells(SelectedElement.DateDebut, (int)((e.X - m_nXStartDrag) / ParametreAffichage.CellWidth));
                TimeSpan sp = dateDebut - SelectedElement.DateDebut;
                //SelectedElement.Move(sp, null, EModeDeplacementProjet.MoveAutoOnly, true);
                bool bDoMove = true;
                if (BeforeMoveBar != null)
                {
                    MovingBar = SelectedElement;
                    bDoMove = BeforeMoveBar("BeforeMoveBar", this);
                }
                if ( bDoMove )
                    MoveElement(sp, null);
                Refresh();

            }
        }

        

        //----------------------------------------------------------------
        void menuElementDeGantt_Opening(object sender, CancelEventArgs e)
        {
            if (BarContextMenuOpenning != null)
                BarContextMenuOpenning(sender, new CGanttElementEventArgs(SelectedElement, new Point(0, 0), MouseButtons.Right));
        }

        //----------------------------------------------------------------
        void itemControlDates_OnValueChanged(object sender, EventArgs e)
        {
            if (!LockEdition && SelectedElement != null)
            {
                CToolStripDateTimePicker picker = sender as CToolStripDateTimePicker;
                if (picker != null)
                {
                    DateTime dtStart = picker.StartDate;
                    DateTime dtEnd = picker.EndDate;
                    TimeSpan duree = dtEnd - dtStart;
                    TimeSpan ecart = dtStart - SelectedElement.DateDebut;
                    //SelectedElement.Move(ecart, duree, EModeDeplacementProjet.MoveAutoOnly, true);
                    MoveElement(ecart, duree);
                    picker.GetCurrentParent().Visible = false;
                    Refresh();
                    if (SelectedElement.ElementParent != null)
                        SelectedElement.DatesAreDirty = true;
                }
            }
        }

        

        
        //----------------------------------------------------------------
        public IElementDeGantt GetElementAt(Point pt)
        {
            KeyValuePair<IElementDeGantt, Rectangle>? sel = m_dicElementGanttToRectangle.FirstOrDefault(kv => kv.Value.Contains ( pt ));
            if (sel != null)
                return sel.Value.Key;
            else
                return null;
        }

        public bool LockEdition
        {
            get
            {
                return !m_extModeEdition.ModeEdition;
            }
            set
            {
                m_extModeEdition.ModeEdition = !value;
                if ( OnChangeLockEdition != null )
                    OnChangeLockEdition ( this, new EventArgs() );
            }
        }

        public event EventHandler OnChangeLockEdition;


        public MoveGanttElementDelegate MoveElementFonctionDeleguee;
        public event OnMoveGanttElement OnMoveElementDeGantt;

        CFormConfirmationAvantDeplacementElementDeGantt m_formConfirmation = new CFormConfirmationAvantDeplacementElementDeGantt();
        //---------------------------------------------------------------------------------------------------------
        // Déplace l'élément sélectionné apès avoir posé les bonnes questions à l'utilisateur
        private void MoveElement(TimeSpan tsDeplacement, TimeSpan? tsDuree)
        {

            EModeDeplacementProjet mode = EModeDeplacementProjet.MoveAutoOnly;
            if (SelectedElement != null)
            {
                // Appelle une fonction de traitement du mouvement externe
                if (MoveElementFonctionDeleguee != null)
                    MoveElementFonctionDeleguee(SelectedElement, tsDeplacement, tsDuree, true);

                else
                {
                    if (m_formConfirmation.DemanderConfirmation(SelectedElement))
                    {
                        // Faire ici le mouvement
                        if (m_formConfirmation.DeplacerLesFilsNonAuto)
                            mode = EModeDeplacementProjet.MoveNonAuto;
                        SelectedElement.Move(tsDeplacement, tsDuree, mode, true);

                    }

                }

                // Déclenche l'événement lorsqu'un élément du Gantt est déplacé
                if (OnMoveElementDeGantt != null)
                    OnMoveElementDeGantt(SelectedElement);


            }
            

        }

    }
}
