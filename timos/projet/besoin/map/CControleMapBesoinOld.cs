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

namespace timos.projet.besoin
{
    public partial class CControleMapBesoinOld : UserControl
    {
        private class CInfoDessinSatisfaction
        {
            private Rectangle m_rectangle;
            private int m_nNiveauHierarchique = 0;
            private bool m_bHasChildren = false;
            private ISatisfactionBesoin m_satisfaction;
            private bool m_bIsExpanded = false;
            private Rectangle? m_rectangleZoneExpand = null;

            //-------------------------------
            public CInfoDessinSatisfaction(
                Rectangle rct, 
                ISatisfactionBesoin satisfaction,
                bool bIsExpanded)
            {
                m_rectangle = rct;
                m_satisfaction = satisfaction;
                ISatisfactionBesoinAvecSousBesoins sab = satisfaction as ISatisfactionBesoinAvecSousBesoins;
                if (sab != null)
                    m_bHasChildren = sab.GetSousBesoinsDeSatisfaction().Count() != 0;
                m_bIsExpanded = bIsExpanded;
            }

            //-------------------------------
            public Rectangle Rectangle
            {
                get
                {
                    return m_rectangle;
                }
                set
                {
                    m_rectangle = value;
                }
            }

            //-------------------------------
            public ISatisfactionBesoin Satisfaction
            {
                get
                {
                    return m_satisfaction;
                }
                set
                {
                    m_satisfaction = value;
                }
            }

            //-------------------------------
            public int NiveauHierarchique
            {
                get
                {
                    return m_nNiveauHierarchique;
                }
                set
                {
                    m_nNiveauHierarchique = value;
                }
            }

            //-------------------------------
            public bool IsExpanded
            {
                get
                {
                    return m_bIsExpanded;
                }
                set
                {
                    m_bIsExpanded = value;
                }
            }

            //-------------------------------
            public bool HasChildren
            {
                get
                {
                    return m_bHasChildren;
                }
                set
                {
                    m_bHasChildren = value;
                }
            }

            //-------------------------------
            public void Offset(int nX, int nY)
            {
                m_rectangle.Offset(nX, nY);
            }

            //------------------------------------------------------
            public void Draw(
                CControleMapBesoinOld controleMap,
                Color couleurFond,
                bool bSelected,
                Graphics g)
            {
                Rectangle rct = Rectangle;
                Brush br = new SolidBrush(Color.FromArgb(64, 0, 0, 0));
                g.FillRectangle(br,
                    rct.Left + 4,
                    rct.Bottom,
                    rct.Width, 4);
                g.FillRectangle(br, rct.Right,
                    rct.Top + 4,
                    4,
                    rct.Height - 4);
                br.Dispose();
                Color c = couleurFond;
                br = new SolidBrush(c);
                g.FillRectangle(br, rct);
                br.Dispose();
                Pen pTour = new Pen(Color.Black, bSelected ? 4 : 1);
                g.DrawRectangle(pTour, rct);
                pTour.Dispose();
                rct.Offset(1, 1);
                rct.Height = controleMap.m_nHauteurSatisfactionDefaut;
                rct.Inflate(-2, -2);

                Image img = sc2i.common.DynamicClassAttribute.GetImage(m_satisfaction.GetType());
                if (img != null)
                {
                    Rectangle rctImage = new Rectangle(rct.Left, rct.Top, 16, 16);
                    g.DrawImage(img, rctImage);
                    rct.Offset(16, 0);
                    rct.Width -= 16;
                }
                if (HasChildren)
                {
                    img = m_bIsExpanded ? Resources.blueUp32 : Resources.blueDown32;
                    Size sz = CUtilImage.GetSizeAvecRatio(img, new Size(2000, 16));
                    Rectangle rctImage = new Rectangle(rct.Right - sz.Width,
                        rct.Bottom - sz.Height,
                        sz.Width,
                        sz.Height);
                    g.DrawImage(img, rctImage, new Rectangle(0,0, img.Width, img.Height),GraphicsUnit.Pixel);
                    Point pt = new Point ( rctImage.Left, rctImage.Top );
                    pt = PointToClient ( pt );
                    m_rectangleZoneExpand = new Rectangle(pt, rctImage.Size );
                }


                string str = m_satisfaction.LibelleSatisfactionComplet;
                StringFormat sf = new StringFormat(StringFormatFlags.FitBlackBox);
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                g.DrawString(str, controleMap.Font, Brushes.Black, rct, sf);
                sf.Dispose();
            }

            //Convertit une coordonnée générale en coordonnée locale
            public Point PointToClient ( Point pt )
            {
                pt.Offset ( -Rectangle.Left,-Rectangle.Top );
                return pt;
            }

            //Convertit une coordonnée locale en coordonnée générale
            public Point PointToGeneral ( Point pt )
            {
                pt.Offset ( -Rectangle.Left,-Rectangle.Top );
                return pt;
            }

            public void OnMouseMove(CControleMapBesoinOld controleMap, Point ptLocal)
            {
                if (m_rectangleZoneExpand != null && m_rectangleZoneExpand.Value.Contains(ptLocal))
                {
                    if (m_satisfaction.Equals(controleMap.m_satisfactionRacine))
                        controleMap.Cursor = Cursors.No;
                    else
                        controleMap.Cursor = Cursors.Hand;
                }
                else
                    controleMap.Cursor = Cursors.Default;
            }

            public void OnMouseDown(CControleMapBesoinOld controleMap, Point ptLocal)
            {
            }

            public void OnMouseUp(CControleMapBesoinOld controleMap, Point ptLocal)
            {
                if (m_rectangleZoneExpand != null && m_rectangleZoneExpand.Value.Contains(ptLocal))
                {
                    if (!m_satisfaction.Equals(controleMap.m_satisfactionRacine))
                    {
                        if (m_bIsExpanded)
                            controleMap.m_setSatisfactionsExpanded.Remove(m_satisfaction);
                        else
                            controleMap.m_setSatisfactionsExpanded.Add(m_satisfaction);
                        controleMap.RefreshDessin();
                    }
                }
            }

        }




        private class CNiveau
        {
            private List<ISatisfactionBesoin> m_listeSatisfactions = new List<ISatisfactionBesoin>();
            private int m_nNiveau = 0;

            //-----------------------------------------
            public CNiveau(int nNiveau)
            {
                m_nNiveau = nNiveau;
            }

            //-----------------------------------------
            public void AddSatisfaction(
                CControleMapBesoinOld controleMap,
                ISatisfactionBesoin satisfaction)
            {
                AddSatisfaction ( 0, controleMap, satisfaction );
            }

            //-----------------------------------------
            private void AddSatisfaction ( 
                int nNiveauHierarchique,
                CControleMapBesoinOld controleMap,
                ISatisfactionBesoin satisfaction )
            {
                if (satisfaction != null &&
                    !controleMap.m_setSatisfactionsIntegrés.Contains(satisfaction))
                {
                    controleMap.m_setSatisfactionsIntegrés.Add(satisfaction);
                    m_listeSatisfactions.Add(satisfaction);
                    if (controleMap.m_setSatisfactionsExpanded.Contains(satisfaction))
                    {
                        ISatisfactionBesoinAvecSousBesoins satB = satisfaction as ISatisfactionBesoinAvecSousBesoins;
                        if ( satB != null )
                        {
                            foreach ( CBesoin besoin in satB.GetSousBesoinsDeSatisfaction() )
                            {
                                AddSatisfaction ( nNiveauHierarchique+1, controleMap, besoin );
                            }
                        }
                    }
                }
            }

            //-----------------------------------------
            public IEnumerable<ISatisfactionBesoin> Satisfactions
            {
                get
                {
                    return m_listeSatisfactions.AsReadOnly();
                }
            }

            //-----------------------------------------
            public int Niveau
            {
                get
                {
                    return m_nNiveau;
                }
            }

           
        }

        private List<CNiveau> m_listeNiveaux = new List<CNiveau>();

        private int m_nLargeurNiveauDefaut = 150;
        private int m_nHauteurSatisfactionDefaut = 40;
        private int m_nMargeVerticale = 15;
        private int m_nLargeurFleches = 140;
        private int m_nOffestNiveau = 30;

        private float m_fZoomFactor = 1.0f;

        private ISatisfactionBesoin m_satisfactionRacine = null;


        private float m_fMinZoom = 0.2F;
        private float m_fMaxZoom = 6.0F;

        private Size m_marge = new Size(15, 15);

        private ISatisfactionBesoin m_satisfactionSel = null;
        private CRelationBesoin_Satisfaction m_lienSel = null;
        private HashSet<ISatisfactionBesoin> m_setSatisfactionsExpanded = new HashSet<ISatisfactionBesoin>();

        private Dictionary<CRelationBesoin_Satisfaction, CSegmentDroite> m_dicSatisfactionToSegment = new Dictionary<CRelationBesoin_Satisfaction, CSegmentDroite>();


        private Dictionary<ISatisfactionBesoin, CInfoDessinSatisfaction> m_dicSatisfactionToRect = new Dictionary<ISatisfactionBesoin, CInfoDessinSatisfaction>();
        private HashSet<ISatisfactionBesoin> m_setSatisfactionsIntegrés = new HashSet<ISatisfactionBesoin>();

        //------------------------------------------------------
        public CControleMapBesoinOld()
        {
            InitializeComponent();
            System.Reflection.PropertyInfo aProp =
            typeof(System.Windows.Forms.Control).GetProperty(
               "DoubleBuffered",
               System.Reflection.BindingFlags.NonPublic |
               System.Reflection.BindingFlags.Instance);
            aProp.SetValue(m_panelDessin, true, null);
            sc2i.win32.common.CWin32Traducteur.Translate(m_menuSatisfaction);
        }

        //------------------------------------------------------
        public void Init(ISatisfactionBesoin satisfaction)
        {
            m_satisfactionRacine = satisfaction;
            List<ISatisfactionBesoin> lst = new List<ISatisfactionBesoin>();
            lst.Add(satisfaction);
            ISatisfactionBesoinAvecSousBesoins sab = satisfaction as ISatisfactionBesoinAvecSousBesoins;
            if (sab != null)
                m_setSatisfactionsExpanded.Add(sab);
            Init(lst);
        }

        //------------------------------------------------------
        private void Init ( IEnumerable<ISatisfactionBesoin> lstSatisfactions )
        {
            m_listeNiveaux.Clear();
            m_setSatisfactionsIntegrés.Clear();
            CNiveau niveau = new CNiveau(0);
            foreach (ISatisfactionBesoin sat in lstSatisfactions)
            {
                niveau.AddSatisfaction(this, sat);
            }
            m_listeNiveaux.Add(niveau);
            
    
            CNiveau niveau0 = niveau;
            while (niveau.Satisfactions.Count() != 0)
            {
                niveau = CalculeNiveauSuivant();
            }
            niveau = niveau0;
            while (niveau.Satisfactions.Count() != 0)
            {
                niveau = CalculeNiveauPrecedent();
            }
            CalculeRectangles();
            m_satisfactionSel = null;
            m_lienSel = null;
        }

        //------------------------------------------------------
        private void RefreshDessin()
        {
            Init(m_satisfactionRacine);
            Refresh();
        }

        //------------------------------------------------------
        private void CalculeRectangles()
        {
            m_dicSatisfactionToRect.Clear();
            
            for (int nIndex = 1; nIndex < m_listeNiveaux.Count; nIndex++)
            {
                int nYTop = 0;
                /*
                            while (nIndex < m_listeNiveaux.Count && m_listeNiveaux[nIndex].Satisfactions.Count() == 0 )
                                nIndex++;*/
                
                if (nIndex < m_listeNiveaux.Count)
                {
                    int nWidthNiveau = 0;
                    //trouve le dernier élément de ce niveau
                    CNiveau niveau = m_listeNiveaux[nIndex];
                    foreach (ISatisfactionBesoin satisfaction in niveau.Satisfactions)
                    {
                        CInfoDessinSatisfaction dessin = null;
                        if (m_dicSatisfactionToRect.TryGetValue(satisfaction, out dessin))
                        {
                            if (dessin != null)
                            {
                                nYTop = dessin.Rectangle.Bottom + m_nMargeVerticale;
                                nWidthNiveau = Math.Max ( dessin.Rectangle.Width, nWidthNiveau );
                            }
                        }
                    }



                    foreach (ISatisfactionBesoin satisfaction in niveau.Satisfactions)
                    {
                        if (!m_dicSatisfactionToRect.ContainsKey(satisfaction))
                        {
                            nYTop = CalculeRectangles(satisfaction, nIndex - 1, nYTop);
                            nYTop += m_nMargeVerticale;
                        }
                    }
                }
            }

            //Calcule tous les englobants = remplace les rectangles simples par des rectangles englobant
            //les fils qui suivent
            foreach (CNiveau niveaux in m_listeNiveaux)
            {
                CalculeEnglobants(niveaux);
            }



            int? nMinX = null;
            int? nMinY = null;
            int? nMaxX = null;
            int? nMaxY = null;
            foreach (CInfoDessinSatisfaction dessin in m_dicSatisfactionToRect.Values)
            {
                if (dessin != null)
                {
                    if (nMinX == null || nMinX.Value > dessin.Rectangle.Left)
                        nMinX = dessin.Rectangle.Left;
                    if (nMinY == null || nMinY.Value > dessin.Rectangle.Top)
                        nMinY = dessin.Rectangle.Top;
                    if (nMaxX == null || nMaxX.Value < dessin.Rectangle.Right)
                        nMaxX = dessin.Rectangle.Right;
                    if (nMaxY == null || nMaxY.Value < dessin.Rectangle.Bottom)
                        nMaxY = dessin.Rectangle.Bottom;
                }
            }
            if (nMinX == null || nMaxX == null || nMinY == null || nMaxY == null)
                return;
            //Offset de tous les rectangles
            Point ptOffset = new Point(-nMinX.Value, -nMinY.Value);
            foreach (KeyValuePair<ISatisfactionBesoin, CInfoDessinSatisfaction> kv in m_dicSatisfactionToRect)
            {
                if (kv.Value != null)
                {
                    kv.Value.Offset(ptOffset.X, ptOffset.Y);
                }
            }
            CalcScrollSizes();
            
        }

        //------------------------------------------------------
        private void CalculeEnglobants(CNiveau niveau)
        {
            int nIndex = 0;
            int nMaxWidth = 0;
            while (nIndex < niveau.Satisfactions.Count())
            {
                Rectangle rct = CalculeEnglobants(niveau, ref nIndex, 0);
                nMaxWidth = Math.Max(nMaxWidth, rct.Width);
            }
            int nOffset = nMaxWidth - m_nLargeurNiveauDefaut ;
            if (nOffset > 0)
            {
                foreach (CNiveau autreNiveau in m_listeNiveaux)
                {
                    if (autreNiveau.Niveau > niveau.Niveau)
                    {
                        foreach (ISatisfactionBesoin sat in autreNiveau.Satisfactions)
                        {
                            CInfoDessinSatisfaction dessin = null;
                            m_dicSatisfactionToRect.TryGetValue(sat, out dessin);
                            dessin.Offset(nOffset,0);
                        }
                    }
                }
            }
        }

        //------------------------------------------------------
        private Rectangle CalculeEnglobants(CNiveau niveau, ref int nIndexNext, int nIndexHierarchique)
        {
            ISatisfactionBesoin satisfaction = niveau.Satisfactions.ElementAt(nIndexNext);

            CInfoDessinSatisfaction dessin = null;
            
            m_dicSatisfactionToRect.TryGetValue(satisfaction, out dessin);
            Rectangle rctRetour = dessin.Rectangle;

            nIndexNext++;
            HashSet<ISatisfactionBesoin> besoinsFils = new HashSet<ISatisfactionBesoin>();
            int nIndexStartFils = nIndexNext;

            ISatisfactionBesoinAvecSousBesoins satB = satisfaction as ISatisfactionBesoinAvecSousBesoins;
            if (satB != null && m_setSatisfactionsExpanded.Contains(satB))
            {
                
                foreach (CBesoin besoin in satB.GetSousBesoinsDeSatisfaction())
                {
                    besoinsFils.Add(besoin);
                }
            }
            else if (satisfaction is CBesoin)
            {
                foreach (CBesoin besoin in ((CBesoin)satisfaction).BesoinsFils)
                    besoinsFils.Add(besoin);
            }

            if ( besoinsFils.Count > 0 )
            {            
                while ( nIndexNext < niveau.Satisfactions.Count() &&
                        besoinsFils.Contains ( niveau.Satisfactions.ElementAt(nIndexNext)) )
                {
                    Rectangle rctFils = CalculeEnglobants ( niveau, ref nIndexNext, nIndexHierarchique+1 );
                    rctRetour = Rectangle.Union ( rctRetour, rctFils );
                }
                for (int nFils = nIndexStartFils; nFils < nIndexNext; nFils++)
                {
                    ISatisfactionBesoin satFils = niveau.Satisfactions.ElementAt(nFils);
                    CInfoDessinSatisfaction dessinFils = null;
                    m_dicSatisfactionToRect.TryGetValue(satFils, out dessinFils);
                    dessinFils.Offset(m_nOffestNiveau, 0);
                }
                rctRetour.Width += m_nOffestNiveau;
                dessin.Rectangle = new Rectangle(rctRetour.Left + m_nOffestNiveau/3, rctRetour.Top, m_nLargeurNiveauDefaut, rctRetour.Height+4);
            }
            dessin.NiveauHierarchique = nIndexHierarchique;
            return rctRetour;
        }

        //------------------------------------------------------
        public void CenterOn(ISatisfactionBesoin satisfaction)
        {
            CInfoDessinSatisfaction dessin = null;
            if (m_dicSatisfactionToRect.TryGetValue(satisfaction, out dessin))
            {
                if (dessin != null)
                {
                    Point ptCentre = new Point(dessin.Rectangle.Left + dessin.Rectangle.Width / 2,
                        dessin.Rectangle.Top + dessin.Rectangle.Height / 2);
                    ptCentre = PointToDisplay(ptCentre);
                    //Calcule la position des scrollBars pour être centré sur cet élément
                    ptCentre.Offset(-m_panelDessin.Width/2, -m_panelDessin.Height/2);

                    m_panelDessin.AutoScrollPosition = new Point(ptCentre.X, ptCentre.Y);
                    Refresh();
                }
            }
        }

        //------------------------------------------------------
        private Size LogicalTotalSize
        {
            get {
                int nWidth = 0;
                int nHeight = 0;
                foreach (CInfoDessinSatisfaction dessin in m_dicSatisfactionToRect.Values)
                {
                    if (dessin != null)
                    {
                        nWidth = Math.Max(dessin.Rectangle.Right, nWidth);
                        nHeight = Math.Max(dessin.Rectangle.Bottom, nHeight);
                    }
                }
                return new Size(nWidth+m_marge.Width*2, nHeight+m_marge.Height*2);
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

        //------------------------------------------------------
        private int CalculeRectangles(ISatisfactionBesoin satisfaction, int nIndexNiveau, int nYTop)
        {
            int nNextPos = nYTop;
            bool bMargeOnNext = false;
            List<ISatisfactionBesoin> lstFils = new List<ISatisfactionBesoin>();
            CBesoin besoin = satisfaction as CBesoin;
            if (besoin != null)
            {
                foreach (CRelationBesoin_Satisfaction sat in besoin.RelationsSatisfactions)
                {
                    ISatisfactionBesoin fils = sat.Satisfaction;
                    if (fils != null)
                    {
                        if (m_setSatisfactionsIntegrés.Contains(fils) && !m_dicSatisfactionToRect.ContainsKey(fils))
                            lstFils.Add(fils);
                    }
                }
            }
            for ( int nFils = 0; nFils < lstFils.Count; nFils++)
            {
                ISatisfactionBesoin fils = lstFils[nFils];
                if (!m_dicSatisfactionToRect.ContainsKey(fils))
                {
                    if (bMargeOnNext)
                        nNextPos += m_nMargeVerticale;
                    m_dicSatisfactionToRect[fils] = null;
                    nNextPos = CalculeRectangles(fils, nIndexNiveau + 1, nNextPos);
                    bMargeOnNext = true;
                }
            }
            int nHauteurTotale = Math.Max(m_nHauteurSatisfactionDefaut, nNextPos - nYTop);
            int nX = GetXIndexNiveau(nIndexNiveau, m_nLargeurNiveauDefaut, m_nLargeurFleches);
            Rectangle rct = new Rectangle(nX, nYTop + nHauteurTotale / 2 - m_nMargeVerticale,
                m_nLargeurNiveauDefaut,
                m_nHauteurSatisfactionDefaut);
            m_dicSatisfactionToRect[satisfaction] = new CInfoDessinSatisfaction(rct, satisfaction, m_setSatisfactionsExpanded.Contains ( satisfaction));
            return nYTop + nHauteurTotale;                         

        }
            



        //------------------------------------------------------
        private CNiveau CalculeNiveauPrecedent()
        {
            CNiveau niveauPrec = m_listeNiveaux[0];
            CNiveau niveau = new CNiveau(niveauPrec.Niveau-1);
            foreach (ISatisfactionBesoin satisfaction in niveauPrec.Satisfactions)
            {
                foreach (CRelationBesoin_Satisfaction rel in satisfaction.RelationsSatisfaits)
                {
                    if (!m_setSatisfactionsIntegrés.Contains(rel.Besoin))
                    {
                        niveau.AddSatisfaction(this, rel.Besoin);
                    }

                }
            }
            m_listeNiveaux.Insert ( 0, niveau );
            return niveau;
        }

        //------------------------------------------------------
        private CNiveau CalculeNiveauSuivant (  )
        {
            CNiveau niveauSuiv = m_listeNiveaux[m_listeNiveaux.Count - 1];
            CNiveau niveau = new CNiveau ( m_listeNiveaux[m_listeNiveaux.Count-1].Niveau+1);
            foreach ( ISatisfactionBesoin sat in niveauSuiv.Satisfactions )
            {
                CBesoin besoin = sat as CBesoin;
                if (besoin != null)
                {
                    foreach (CRelationBesoin_Satisfaction rel in besoin.RelationsSatisfactions)
                    {
                        niveau.AddSatisfaction(this, rel.Satisfaction);
                    }
                }
            }
            m_listeNiveaux.Add ( niveau );
            return niveau;
        }

         //------------------------------------------------------
        private int NiveauMin
        {
            get
            {
                if (m_listeNiveaux.Count > 0)
                    return m_listeNiveaux[0].Niveau;
                return 0;
            }
        }

        //------------------------------------------------------
        private int NiveauMax
        {
            get
            {
                if (m_listeNiveaux.Count > 0)
                    return m_listeNiveaux[m_listeNiveaux.Count - 1].Niveau;
                return 0;
            }
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
            int nIndexNiveauStart = (nX0 ) / (m_nLargeurNiveauDefaut + m_nLargeurFleches);
            if (nX0 < 0)
                nIndexNiveauStart--;

            int nNbNiveauxVisibles = SizeToLogical(m_panelDessin.Width)/(m_nLargeurNiveauDefaut+m_nLargeurFleches)+2;

            List<ISatisfactionBesoin> satisfactionsDessines = new List<ISatisfactionBesoin>();
            if ( nIndexNiveauStart < 0 )
                nIndexNiveauStart = 0;
            for (int nIndexNiveau = nIndexNiveauStart; nIndexNiveau <= nIndexNiveauStart + nNbNiveauxVisibles &&
                nIndexNiveau < m_listeNiveaux.Count; nIndexNiveau++)
            {
                CNiveau niveau = m_listeNiveaux[nIndexNiveau];
                int nNiveau = niveau.Niveau;
                Color couleurNiveau = Color.LightGreen;
                if (nNiveau > 0)
                    couleurNiveau = Color.White;
                else if (nNiveau < 0)
                    couleurNiveau = Color.LightBlue;
                foreach (ISatisfactionBesoin satisfaction in niveau.Satisfactions)
                {
                    CInfoDessinSatisfaction dessin = null;
                    if (m_dicSatisfactionToRect.TryGetValue(satisfaction, out dessin))
                    {
                        Point pt = PointToDisplay(new Point(dessin.Rectangle.Left, dessin.Rectangle.Bottom));
                        if (pt.Y > 0)
                        {
                            pt = PointToDisplay(new Point(dessin.Rectangle.Left, dessin.Rectangle.Top));
                            if (pt.Y < m_panelDessin.Height)
                            {
                                bool bSel = dessin.Satisfaction.Equals ( m_satisfactionSel );
                                dessin.Draw ( this, couleurNiveau, bSel, e.Graphics );
                                satisfactionsDessines.Add(satisfaction);
                            }
                        }
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
            CInfoDessinSatisfaction dessin1 = null;
            CInfoDessinSatisfaction dessin2 = null;
            m_dicSatisfactionToRect.TryGetValue(besoinSatisfait, out dessin1);
            m_dicSatisfactionToRect.TryGetValue(satisfaction, out dessin2);
            CSegmentDroite segment = null;
            if (dessin1 != null && dessin2 != null)
            {
                segment = new CSegmentDroite(new Point(dessin1.Rectangle.Right, dessin1.Rectangle.Top + m_nHauteurSatisfactionDefaut / 2),
                    new Point(dessin2.Rectangle.Left, dessin2.Rectangle.Top + m_nHauteurSatisfactionDefaut / 2));
                g.DrawLine(p,segment.Point1, segment.Point2 );
                segment.DrawFlechePt1(g, p, 4);
            }
            return segment;
        }

    

        private void CControleMapBesoin_Load(object sender, EventArgs e)
        {
            if (m_satisfactionRacine != null)
                CenterOn(m_satisfactionRacine);
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
        private CInfoDessinSatisfaction GetInfoFromLogical(Point ptLogique)
        {
            CInfoDessinSatisfaction infoSel = null;
            foreach (KeyValuePair<ISatisfactionBesoin, CInfoDessinSatisfaction> kv in m_dicSatisfactionToRect)
            {
                if (kv.Value != null && kv.Value.Rectangle.Contains(ptLogique))
                {
                    if (infoSel == null || infoSel.Rectangle.Height > kv.Value.Rectangle.Height)
                    {
                        infoSel = kv.Value;
                    }
                }
            }
            return infoSel;
        }

        //-----------------------------------------------------
        private CInfoDessinSatisfaction GetInfoFromDisplay(Point ptDisplay)
        {
            Point pt = PointToLogical(ptDisplay);
            return GetInfoFromLogical(pt);
        }

        //-----------------------------------------------------
        private ISatisfactionBesoin GetSatisfactionFromDisplay(Point ptDisplay)
        {
            CInfoDessinSatisfaction info = GetInfoFromDisplay(ptDisplay);
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
                CInfoDessinSatisfaction dessin = null;
                m_dicSatisfactionToRect.TryGetValue(satisfaction, out dessin);
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
            }
            if (m_satisfactionSel != null)
            {
                CInfoDessinSatisfaction info = null;
                if (m_dicSatisfactionToRect.TryGetValue(m_satisfactionSel, out info))
                {
                    Point pt = info.PointToClient(PointToLogical(new Point(e.X, e.Y)));
                    info.OnMouseUp(this, pt);
                }
            }
            Cursor = Cursors.Arrow;
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
                CInfoDessinSatisfaction info = GetInfoFromLogical(pt);
                if (info != null)
                    info.OnMouseMove(this, info.PointToClient(pt));
            }
        }

        //------------------------------------------------------------------------------
        private void afficherLaPhaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CBesoin besoin = m_satisfactionSel as CBesoin;
            if (besoin != null && besoin.PhaseSpecifications != null)
            {
                ISatisfactionBesoin sat = null;
                CPhaseSpecifications phase = besoin.PhaseSpecifications;
                if (phase != null && phase.Projet != null)
                    sat = phase.Projet;
                else
                    sat = phase;
                Init(sat);
                Refresh();
            }
        }


        //------------------------------------------------------------------------------
        private void m_menuSatisfaction_Opening(object sender, CancelEventArgs e)
        {
            m_menuAfficherPhase.Visible = m_satisfactionSel != null && m_satisfactionSel is CBesoin;

            m_menuDetaillerSatisfaction.Visible = m_satisfactionSel is ISatisfactionBesoinAvecSousBesoins && m_satisfactionSel != m_satisfactionRacine;
            m_menuDetaillerSatisfaction.Checked = m_satisfactionSel != null && m_setSatisfactionsExpanded.Contains(m_satisfactionSel);
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
        private void m_menuDetaillerSatisfaction_Click(object sender, EventArgs e)
        {
            ISatisfactionBesoinAvecSousBesoins sat = m_satisfactionSel as ISatisfactionBesoinAvecSousBesoins;
            if (sat != null)
            {
                if (m_setSatisfactionsExpanded.Contains(sat))
                    m_setSatisfactionsExpanded.Remove(sat);
                else
                    m_setSatisfactionsExpanded.Add(sat);
                RefreshDessin();
            }
        }

    }


}
