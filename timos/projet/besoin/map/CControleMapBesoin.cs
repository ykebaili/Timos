using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using sc2i.drawing;
using timos.data.projet.besoin;
using sc2i.data;
using sc2i.win32.data;
using timos.Properties;
using sc2i.win32.common;
using sc2i.common;

namespace timos.projet.besoin.map
{
    public partial class CControleMapBesoin : UserControl
    {
        private float m_fZoomFactor = 1.0f;

        private ISatisfactionBesoin m_satisfactionRacine = null;


        private float m_fMinZoom = 0.2F;
        private float m_fMaxZoom = 6.0F;

        private Size m_marge = new Size(15, 15);

        private ISatisfactionBesoin m_satisfactionSel = null;
        private CRelationBesoin_Satisfaction m_lienSel = null;
        
        private Dictionary<CRelationBesoin_Satisfaction, CSegmentDroite> m_dicSatisfactionToSegment = new Dictionary<CRelationBesoin_Satisfaction, CSegmentDroite>();

        private CBaseMapSatisfaction m_baseMap = new CBaseMapSatisfaction();
        

        //------------------------------------------------------
        public CControleMapBesoin()
        {
            InitializeComponent();
            System.Reflection.PropertyInfo aProp =
            typeof(System.Windows.Forms.Control).GetProperty(
               "DoubleBuffered",
               System.Reflection.BindingFlags.NonPublic |
               System.Reflection.BindingFlags.Instance);
            aProp.SetValue(m_panelDessin, true, null);
            sc2i.win32.common.CWin32Traducteur.Translate(GetType(), m_menuSatisfaction);
            m_baseMap.OnChangementDansDessin += new EventHandler(m_baseMap_OnChangementDansDessin);
        }

        void m_baseMap_OnChangementDansDessin(object sender, EventArgs e)
        {
            CalcScrollSizes();
            Refresh();
        }

        //------------------------------------------------------
        public void Init(ISatisfactionBesoin satisfaction)
        {
            m_satisfactionRacine = satisfaction;
            List<ISatisfactionBesoin> lst = new List<ISatisfactionBesoin>();
            lst.Add(satisfaction);
            m_baseMap.Init(lst);
            m_satisfactionSel = null;
            m_lienSel = null;
            
            CDessinSatisfaction dessin = m_baseMap.GetDessin(satisfaction);
            if (dessin != null)
                dessin.Expand();
        }

        //------------------------------------------------------
        private void RefreshDessin()
        {
            Init(m_satisfactionRacine);
            Refresh();
        }

        //------------------------------------------------------
        private Size LogicalTotalSize
        {
            get {
                Size sz = m_baseMap.TotalSize;
                
                return new Size(sz.Width+m_marge.Width*2, sz.Height+m_marge.Height*2);
            }
        }

        //------------------------------------------------------
        private void CalcScrollSizes()
        {
            Size sz = LogicalTotalSize;
            m_panelDessin.AutoScrollMinSize = new Size(
                SizeToDisplay(sz.Width)+m_marge.Width*2,
                SizeToDisplay(sz.Height)+m_marge.Height*2);
        }

                    


        

        public static int GetXIndexNiveau(int nIndexNiveau, int nLargeurNiveau, int nLargeurFleche)
        {
            return nIndexNiveau * (nLargeurFleche + nLargeurNiveau);
        }

        //--------------------------------------------------
        private Point PointToLogical(Point pt)
        {
            Point ptNew = pt;
            ptNew.Offset(-m_panelDessin.AutoScrollPosition.X-m_marge.Width,
                -m_panelDessin.AutoScrollPosition.Y-m_marge.Height);
            ptNew.X = (int)(ptNew.X/ m_fZoomFactor);
            ptNew.Y = (int)(ptNew.Y/ m_fZoomFactor);
            return ptNew;
        }

        //--------------------------------------------------
        private Point PointToDisplay(Point pt)
        {
            Point ptNew = pt;
            ptNew.X = (int)(ptNew.X * m_fZoomFactor);
            ptNew.Y = (int)(ptNew.Y * m_fZoomFactor);
            ptNew.Offset(m_panelDessin.AutoScrollPosition.X+m_marge.Width,
                m_panelDessin.AutoScrollPosition.Y+m_marge.Height);

            return ptNew;
        }

        //--------------------------------------------------
        private int SizeToLogical(int nSize)
        {
            return (int)((double)nSize / m_fZoomFactor);
        }

        //--------------------------------------------------
        private int SizeToDisplay(int nSize)
        {
            return (int)((double)nSize * m_fZoomFactor);
        }

        //--------------------------------------------------
        private void PrepareGraphic(Graphics g)
        {
            g.ResetTransform();
            g.TranslateTransform(
                m_panelDessin.AutoScrollPosition.X + m_marge.Width,
                m_panelDessin.AutoScrollPosition.Y + m_marge.Height);

            g.ScaleTransform(m_fZoomFactor, m_fZoomFactor);
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            
        }


        private void m_panelDessin_Paint(object sender, PaintEventArgs e)
        {
            Matrix m = new Matrix();

            e.Graphics.FillRectangle(Brushes.White, e.ClipRectangle);


            PrepareGraphic(e.Graphics);

            int nX0 = PointToLogical(new Point(0,0)).X;
            int nIndexNiveauStart = (nX0 ) / (m_baseMap.m_nLargeurNiveauDefaut + m_baseMap.m_nLargeurFleches);
            if (nX0 < 0)
                nIndexNiveauStart--;

            int nNbNiveauxVisibles = SizeToLogical(m_panelDessin.Width)/(m_baseMap.m_nLargeurNiveauDefaut+m_baseMap.m_nLargeurFleches)+2;

            List<ISatisfactionBesoin> satisfactionsDessines = new List<ISatisfactionBesoin>();
            if ( nIndexNiveauStart < 0 )
                nIndexNiveauStart = 0;

            List<CDessinSatisfaction> lstToDraw = m_baseMap.GetListeADessiner();
            foreach (CDessinSatisfaction dessin in lstToDraw)
            {
                if ( dessin.IsPositionValide() && dessin.IsVisible() )
                {
                    Rectangle rct = dessin.Rectangle;
                    Point pt = PointToDisplay ( new Point ( rct.Left, rct.Top ) );
                    rct = new Rectangle ( pt, rct.Size );
                    if ( rct.IntersectsWith(m_panelDessin.ClientRectangle ))
                    {
                        bool bSel = dessin.Satisfaction.Equals ( m_satisfactionSel );
                        satisfactionsDessines.Add(dessin.Satisfaction);
                        dessin.Draw(Color.White, Font, bSel, e.Graphics);
                    }

                }
            }
            //Trace les lignes
            HashSet<CRelationBesoin_Satisfaction> liensDessines = new HashSet<CRelationBesoin_Satisfaction>();
            Pen p = new Pen ( Color.Black );
            Pen pSel = new Pen(Color.Yellow, 2);
            //p.EndCap = LineCap.ArrowAnchor;

            m_dicSatisfactionToSegment.Clear();
            foreach (ISatisfactionBesoin satDessinee in satisfactionsDessines)
            {
                CBesoin besoin = satDessinee as CBesoin;
                if (besoin != null)
                {
                    foreach (CRelationBesoin_Satisfaction rel in besoin.RelationsSatisfactions)
                    {
                        if (!liensDessines.Contains(rel))
                        {
                            CSegmentDroite segment = DrawLien(
                                e.Graphics,
                                rel.Besoin,
                                rel.Satisfaction,
                                rel == m_lienSel ? pSel : p);
                            liensDessines.Add(rel);
                            if (segment != null)
                                m_dicSatisfactionToSegment[rel] = segment;
                        }
                    }
                }
                foreach (CRelationBesoin_Satisfaction rel in satDessinee.RelationsSatisfaits)
                {
                    if (!liensDessines.Contains(rel))
                    {
                        CSegmentDroite segment = DrawLien(
                            e.Graphics,
                            rel.Besoin,
                            rel.Satisfaction,
                            rel == m_lienSel ? pSel : p);
                        liensDessines.Add(rel);
                        if (segment != null)
                            m_dicSatisfactionToSegment[rel] = segment;
                    }
                }
            }
            pSel.Dispose();
            p.Dispose();



            e.Graphics.ResetTransform();
        }

        //-----------------------------------------------------
        private CSegmentDroite DrawLien(
            Graphics g,
            ISatisfactionBesoin besoinSatisfait, 
            ISatisfactionBesoin satisfaction,
            Pen p)
        {
            if (besoinSatisfait == null || satisfaction == null)
                return null;
            CDessinSatisfaction dessin1 = m_baseMap.GetDessin(besoinSatisfait);
            CDessinSatisfaction dessin2 = m_baseMap.GetDessin(satisfaction);
            CSegmentDroite segment = null;
            if (dessin1 != null && dessin2 != null)
            {
                segment = new CSegmentDroite(new Point(dessin1.Rectangle.Right, dessin1.Rectangle.Top + m_baseMap.m_nHauteurSatisfactionDefaut / 2),
                    new Point(dessin2.Rectangle.Left, dessin2.Rectangle.Top + m_baseMap.m_nHauteurSatisfactionDefaut / 2));
                g.DrawLine(p,segment.Point1, segment.Point2 );
                segment.DrawFlechePt1(g, p, 4);
                CBesoin besoin = besoinSatisfait as CBesoin;
                if (besoin != null)
                {
                    double fCpt = CUtilSatisfaction.GetPourcentageFor(besoin, satisfaction);
                    if (fCpt < 99)
                    {
                        Point pt = segment.Milieu;
                        string strChaine = fCpt.ToString("0.##") + "%";
                        SizeF sz = g.MeasureString(strChaine, Font);
                        pt.Offset(-(int)(sz.Width / 2), -(int)(sz.Height / 2));
                        Rectangle rct = new Rectangle(pt, new Size((int)sz.Width, (int)sz.Height));
                        Brush br = new SolidBrush(Color.FromArgb(128, Color.White));
                        g.FillRectangle(br, rct);
                        br.Dispose();

                        g.DrawString(strChaine, Font, Brushes.Black, pt);
                    }
                }
            }
            return segment;
        }

    

        private void CControleMapBesoin_Load(object sender, EventArgs e)
        {
            /*if (m_satisfactionRacine != null)
                CenterOn(m_satisfactionRacine);*/
            RefreshTrackZoom();
        }

        

 
        //------------------------------------------------------------------
        private bool m_bIsRefreshingTrack = false;
        private void RefreshTrackZoom()
        {
            try
            {
                m_bIsRefreshingTrack = true;
                m_trackZoom.Minimum = 0;
                m_trackZoom.Maximum = 20;
                if (m_fZoomFactor == 1)
                    m_trackZoom.Value = 10;
                else if (m_fZoomFactor < 1)
                {
                    double fVal = (m_fZoomFactor - m_fMinZoom) * 10;
                    fVal /= (1 - m_fMinZoom);
                    m_trackZoom.Value = (int)fVal;
                }
                else
                {
                    double fVal = (m_fZoomFactor - 1) * 10;
                    fVal /= (m_fMaxZoom - 1);
                    m_trackZoom.Value = (int)fVal + 10;
                }
            }
            catch { }
            m_lblZoom.Text = "x" + m_fZoomFactor.ToString("0.#");
            m_bIsRefreshingTrack = false;
        }

        //------------------------------------------------------------------
        private void SetZoomFromTrack()
        {
            int nVal = m_trackZoom.Value;
            if (nVal == 10)
                m_fZoomFactor = 1;
            else if (nVal < 10)
            {
                float fVal = nVal * (1 - m_fMinZoom) / 10 + m_fMinZoom;
                m_fZoomFactor = fVal;
            }
            else
            {
                float fVal = (nVal - 10) * (m_fMaxZoom - 1) / 10 + 1;
                m_fZoomFactor = fVal;
            }
            RefreshTrackZoom();
            CalcScrollSizes();
            m_panelDessin.Refresh();
        }

        private void m_trackZoom_ValueChanged(object sender, EventArgs e)
        {
            if (!m_bIsRefreshingTrack)
                SetZoomFromTrack();
        }

        private void m_picZoomPage_Click(object sender, EventArgs e)
        {
            AjusteZoom();
        }

        private void AjusteZoom()
        {
            Size szFull = LogicalTotalSize;
            Size szPage = m_panelDessin.Size;
            float fFacteurX = (float)szPage.Width / (float)szFull.Width;
            float fFacteurY = (float)szPage.Height / (float)szFull.Height;
            m_fZoomFactor = Math.Max(m_fMinZoom, Math.Min(fFacteurX, fFacteurY));
            CalcScrollSizes();
            RefreshTrackZoom();
            m_panelDessin.Refresh();
        }

        //-----------------------------------------------------
        private CDessinSatisfaction GetDessinSatisfactionFromLogical(Point ptLogique)
        {
            return m_baseMap.GetDessinAt(ptLogique);
        }

        //-----------------------------------------------------
        private CDessinSatisfaction GetDessinSatisfactionFromDisplay(Point ptDisplay)
        {
            Point pt = PointToLogical(ptDisplay);
            return GetDessinSatisfactionFromLogical(pt);
        }

        //-----------------------------------------------------
        private ISatisfactionBesoin GetSatisfactionFromDisplay(Point ptDisplay)
        {
            CDessinSatisfaction info = GetDessinSatisfactionFromDisplay(ptDisplay);
            if (info != null)
                return info.Satisfaction;
            return null;
        }

        //-----------------------------------------------------
        private CRelationBesoin_Satisfaction GetLien(Point ptDisplay)
        {
            Point pt = PointToLogical(ptDisplay);
            foreach (KeyValuePair<CRelationBesoin_Satisfaction, CSegmentDroite> kv in m_dicSatisfactionToSegment)
            {
                if (kv.Value.GetDistance(pt) < 4)
                    return kv.Key;
            }
            return null;
        }

        //-----------------------------------------------------
        private void Invalidate(CRelationBesoin_Satisfaction sat)
        {
            if (sat != null)
            {
                CSegmentDroite segment = null;
                m_dicSatisfactionToSegment.TryGetValue(sat, out segment);
                if (segment != null)
                {
                    Rectangle rct = new Rectangle(PointToDisplay(new Point(segment.Left - 5, segment.Top - 5)),
                        new Size(SizeToDisplay(segment.SizeEnglobant.Width + 10), SizeToDisplay(segment.SizeEnglobant.Height + 10)));
                    rct.Inflate(2, 2);
                    m_panelDessin.Invalidate(rct);
                }
            }
        }
                    

        //-----------------------------------------------------
        private void Invalidate ( ISatisfactionBesoin satisfaction )
        {
            if ( satisfaction != null )
            {
                CDessinSatisfaction dessin = m_baseMap.GetDessin(satisfaction);
                if (dessin != null)
                {
                    Rectangle r = new Rectangle(PointToDisplay ( new Point ( dessin.Rectangle.Left-5, dessin.Rectangle.Top-5) ),
                        new Size ( SizeToDisplay ( dessin.Rectangle.Width+11), SizeToDisplay(dessin.Rectangle.Height+11 ) ) );
                    r.Inflate(2, 2);
                    m_panelDessin.Invalidate ( r );
                }
            }
        }

        //-----------------------------------------------------
        private void DoSelection(Point pt, bool bAcceptNull)
        {
            ISatisfactionBesoin satisfaction = GetSatisfactionFromDisplay(pt);
            if (satisfaction != m_satisfactionSel && (satisfaction != null || bAcceptNull))
            {
                Invalidate(m_lienSel);
                Invalidate(m_satisfactionSel);
                m_satisfactionSel = satisfaction;
                m_lienSel = null;
                Invalidate(satisfaction);
            }
            if (satisfaction == null)
            {
                CRelationBesoin_Satisfaction sat = GetLien(pt);
                if (sat != m_lienSel && (sat != null || bAcceptNull))
                {
                    Invalidate(m_lienSel);
                    m_lienSel = sat;
                    Invalidate(m_lienSel);
                }
            }
        }



        //-----------------------------------------------------
        private void m_panelDessin_MouseUp(object sender, MouseEventArgs e)
        {
            m_panelDessin.Capture = false;
            m_panelDessin.Cursor = Cursors.Arrow;
            m_ptStartScroll = null;
            if (e.Button == MouseButtons.Right && !m_bHasScroll)
            {
                DoSelection(new Point(e.X, e.Y), true);
                if (m_satisfactionSel != null)
                {
                    m_menuSatisfaction.Show(m_panelDessin, new Point(e.X, e.Y));
                }
                else if (m_lienSel != null)
                {
                    ContextMenuStrip strip = new ContextMenuStrip();
                    double fPct = CUtilSatisfaction.GetPourcentageFor(m_lienSel.Besoin, m_lienSel.Satisfaction);
                    CToolStripPourcentage toolStripPourcentage = new CToolStripPourcentage(fPct);
                    toolStripPourcentage.OnValideSaisie += new EventHandler(toolStripPourcentage_OnValideSaisie);
                    toolStripPourcentage.Tag = m_lienSel;
                    strip.Items.Add(toolStripPourcentage);
                    strip.Show ( this, new Point ( e.X, e.Y ));
                }

            }
            if (m_satisfactionSel != null)
            {
                CDessinSatisfaction dessin = m_baseMap.GetDessin(m_satisfactionSel);
                {
                    Point pt = PointToLogical(new Point(e.X, e.Y));
                    dessin.OnMouseUp(this, pt);
                }
            }
            Cursor = Cursors.Arrow;
        }

        void toolStripPourcentage_OnValideSaisie(object sender, EventArgs e)
        {
            CToolStripPourcentage pct = sender as CToolStripPourcentage;
            CRelationBesoin_Satisfaction rel = pct != null ? pct.Tag as CRelationBesoin_Satisfaction : null;
            if (rel != null && pct.Value != null)
            {
                if (CFormAlerte.Afficher(I.T("Change repartition for '@1' uses '@2'% of '@3' cost ?|20687",
                    rel.Besoin.LibelleComplet,
                    pct.Value.Value.ToString("0.##"),
                    rel.Satisfaction.Libelle),
                    EFormAlerteBoutons.OuiNon,
                    EFormAlerteType.Question) == DialogResult.Yes)
                {
                    bool bCommit = false;
                    if (rel.ContexteDonnee.ContextePrincipal == null)
                    {
                        bCommit = true;
                        rel.BeginEdit();
                    }
                    CUtilSatisfaction.SetPourcentageFor(rel.Besoin, rel.Satisfaction, pct.Value.Value);
                    if (bCommit)
                    {
                        CResultAErreur result = rel.CommitEdit();
                        if (!result)
                            CFormAlerte.Afficher(result.Erreur);
                    }
                    Refresh();
                }

            }
        }

        private void examinerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_satisfactionSel != null)
            {
                Init(m_satisfactionSel);
                Refresh();
            }
        }

        private Point? m_ptStartScroll = null;
        private bool m_bHasScroll = false;
        private Point? m_ptStartDrag = null;
        private void m_panelDessin_MouseDown(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Right)
            {
                m_bHasScroll = false;
                m_ptStartScroll = new Point(e.X, e.Y);
                m_panelDessin.Capture = true;
                DoSelection(m_ptStartScroll.Value, false);
                m_panelDessin.Cursor = Cursors.Hand;
            }

            if (e.Button == MouseButtons.Left)
            {
                m_ptStartDrag = new Point(e.X, e.Y);
                DoSelection(m_ptStartDrag.Value, true);
            }
        }

        private void m_panelDessin_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && m_ptStartScroll != null)
            {
                Point ptEcart = new Point(m_ptStartScroll.Value.X-e.X,
                    m_ptStartScroll.Value.Y- e.Y);
                Point pt = new Point (-m_panelDessin.AutoScrollPosition.X, -m_panelDessin.AutoScrollPosition.Y);
                pt.Offset(ptEcart);
                m_bHasScroll = true;
                m_ptStartScroll = new Point(e.X, e.Y);
                m_panelDessin.AutoScrollPosition = pt;
                m_panelDessin.Invalidate();
            }
            if (e.Button == MouseButtons.Left && m_ptStartDrag != null && m_satisfactionSel != null)
            {
                if (Math.Abs(m_ptStartDrag.Value.X - e.X) > 3 ||
                    Math.Abs(m_ptStartDrag.Value.Y - e.Y) > 3)
                {
                    CObjetDonnee objet = m_satisfactionSel as CObjetDonnee;
                    if (objet != null)
                        DoDragDrop(new CReferenceObjetDonneeDragDropData(objet), DragDropEffects.Link | DragDropEffects.Copy);
                }
            }
            if (e.Button == MouseButtons.None)
            {
                Point pt = new Point(e.X, e.Y);
                pt = PointToLogical(pt);
                CDessinSatisfaction info = GetDessinSatisfactionFromLogical(pt);
                if (info != null)
                    info.OnMouseMove(this, pt);
            }
        }

        //------------------------------------------------------------------------------
        private void afficherLaPhaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CBesoin besoin = m_satisfactionSel as CBesoin;
            if (besoin != null && besoin.PhaseSpecifications != null)
            {
                CPhaseSpecifications phase = besoin.PhaseSpecifications;
                Init(phase);
                Refresh();
            }
        }


        //------------------------------------------------------------------------------
        private void m_menuSatisfaction_Opening(object sender, CancelEventArgs e)
        {
            m_menuAfficherPhase.Visible = m_satisfactionSel != null && m_satisfactionSel is CBesoin;
            if (m_satisfactionSel != null)
            {
                CDessinSatisfaction dessin = m_baseMap.GetDessin(m_satisfactionSel);
                CPhaseSpecifications phase = m_satisfactionSel as CPhaseSpecifications;
                m_menuAfficherProjet.Visible = dessin != null && phase != null && phase.Projet != null && dessin.DessinParent == null;
            }
            m_menuMasquerProjet.Visible = false;
            /*m_menuDetaillerSatisfaction.Visible = m_satisfactionSel is ISatisfactionBesoinAvecSousBesoins && m_satisfactionSel != m_satisfactionRacine;
            m_menuDetaillerSatisfaction.Checked = m_satisfactionSel != null && m_setSatisfactionsExpanded.Contains(m_satisfactionSel);*/
        }


        //------------------------------------------------------------------------------
        private void m_menuAfficherElement_Click(object sender, EventArgs e)
        {
            ISatisfactionBesoin sat = m_satisfactionSel;
            if (sat != null && sat.ObjetPourEditionElementACout != null)
            {
                CObjetDonnee objet = sat.ObjetPourEditionElementACout.GetObjetInContexte(CSc2iWin32DataClient.ContexteCourant);
                CTimosApp.Navigateur.EditeElement(objet, false, "");
            }
        }

        //------------------------------------------------------------------------------
        private void m_menuAfficherProjet_Click(object sender, EventArgs e)
        {
            CPhaseSpecifications phase = m_satisfactionSel as CPhaseSpecifications;
            if (phase != null && phase.Projet != null)
            {
                Init(phase.Projet);
                Refresh();
            }
        }

        

    }


}
