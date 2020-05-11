using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using timos.data.projet.besoin;
using System.Drawing;
using timos.Properties;
using sc2i.drawing;
using System.Windows.Forms;

namespace timos.projet.besoin.map
{
    public class CDessinSatisfaction
    {
        private ISatisfactionBesoin m_satisfaction = null;
        private List<CDessinSatisfaction> m_listeFils = null;
        private bool m_bIsExpanded = false;

        private Rectangle? m_rectangle = null;
        private CNiveauMapSatisfaction m_niveau = null;

        private CDessinSatisfaction m_dessinParent = null;
        private Rectangle? m_rectangleZoneExpand = null;

        private bool? m_bIsExpandable = null;

        private int m_nBasZoneOccupee = 1;


        //---------------------------------------------------------------
        public CDessinSatisfaction(
            CNiveauMapSatisfaction niveau, 
            ISatisfactionBesoin satisfaction)
        {
            m_satisfaction = satisfaction;
            m_niveau = niveau;
            niveau.BaseSatisfactions.RegisterDessin(this);

        }

        //---------------------------------------------------------------
        public override int GetHashCode()
        {
            return Satisfaction.GetHashCode();
        }

        //---------------------------------------------------------------
        public override bool Equals(object obj)
        {
            CDessinSatisfaction autre = obj as CDessinSatisfaction;
            if (autre == null)
                return false;
            if ( autre.Satisfaction != null )
                return autre.Satisfaction.Equals(Satisfaction);
            return false;
        }

        //---------------------------------------------------------------
        public CNiveauMapSatisfaction Niveau
        {
            get
            {
                return m_niveau;
            }
        }

        //---------------------------------------------------------------
        public ISatisfactionBesoin Satisfaction
        {
            get
            {
                return m_satisfaction;
            }
        }

        //---------------------------------------------------------------
        public bool IsPositionValide()
        {
            return m_rectangle != null;
        }

        //---------------------------------------------------------------
        public int BasZoneOccupee
        {
            get
            {
                return m_nBasZoneOccupee;
            }
        }


        //---------------------------------------------------------------
        public Rectangle Rectangle
        {
            get
            {
                if (!IsVisible() && DessinParent != null)
                    return DessinParent.Rectangle;
                if (m_rectangle == null)
                    return new Rectangle(0, 0, 1, 1);
                return m_rectangle.Value;
            }
            set
            {
                m_rectangle = value;
            }
        }

        //---------------------------------------------------------------
        public void Expand()
        {
            m_bIsExpanded = true;
            if (m_listeFils == null)
            {
                CalculeFils();
            }
            Niveau.BaseSatisfactions.OnChangeNiveau(Niveau);
            
        }

        //---------------------------------------------------------------
        public void Collapse()
        {
            m_bIsExpanded = false;
            if (m_listeFils != null)
            {
                /*foreach (CDessinSatisfaction dessin in m_listeFils)
                {
                    m_niveau.RemoveSatisfactionVisible(dessin);
                }*/
            }
            Niveau.BaseSatisfactions.OnChangeNiveau(Niveau);

        }

        //---------------------------------------------------------------
        private void CalculeFils()
        {
            m_listeFils = new List<CDessinSatisfaction>();
            ISatisfactionBesoinAvecSousBesoins satB = Satisfaction as ISatisfactionBesoinAvecSousBesoins;
            if (satB != null)
            {
                foreach (CBesoin besoin in satB.GetSousBesoinsDeSatisfactionDirects())
                {
                    if (!m_niveau.BaseSatisfactions.IsDejaIntegréee(besoin))
                    {
                        CDessinSatisfaction dessin = new CDessinSatisfaction(m_niveau, besoin);
                        dessin.m_dessinParent = this;
                        m_listeFils.Add(dessin);
                        m_niveau.AddSatisfactionVisible(dessin);
                    }
                }
                foreach (ISatisfactionBesoin sousSat in satB.GetSousSatisfactions())
                {
                    if (!m_niveau.BaseSatisfactions.IsDejaIntegréee(sousSat))
                    {
                        CDessinSatisfaction dessin = new CDessinSatisfaction(m_niveau, sousSat);
                        dessin.m_dessinParent = this;
                        m_listeFils.Add(dessin);
                        m_niveau.AddSatisfactionVisible(dessin);
                    }
                }
            }
        }

        //---------------------------------------------------------------
        public bool IsCollapse()
        {
            return !m_bIsExpanded;
        }

        //---------------------------------------------------------------
        public bool IsVisible()
        {
            if ( DessinParent == null )
                return true;
            return !DessinParent.IsCollapse() && DessinParent.IsVisible();
        }

        //---------------------------------------------------------------
        public CDessinSatisfaction DessinParent
        {
            get
            {
                return m_dessinParent;
            }
        }
        
        //---------------------------------------------------------------
        /// <summary>
        /// Attention, la liste est vide tant qu'on n'a pas appellé Expand()
        /// </summary>
        public IEnumerable<CDessinSatisfaction> DessinsFils
        {
            get
            {
                if (m_listeFils == null)
                    return new CDessinSatisfaction[0];
                return m_listeFils.ToArray();
            }
        }

        //---------------------------------------------------------------
        public void SetPositionInvalide()
        {
            m_rectangle = null;
        }

        //---------------------------------------------------------------
        public void Offset(int nX, int nY)
        {
            if (m_rectangle == null)
                return;
            Rectangle rct = m_rectangle.Value;
            rct.Offset(nX, nY);
            m_rectangle = rct;
        }

        //------------------------------------------------------
        public bool IsExpandable()
        {
            if (m_bIsExpandable == null)
            {
                ISatisfactionBesoinAvecSousBesoins satB = Satisfaction as ISatisfactionBesoinAvecSousBesoins;
                if (satB != null && satB.GetSousBesoinsDeSatisfactionDirects().Count() > 0)
                    m_bIsExpandable = true;
                else
                    m_bIsExpandable = false;
            }
            return m_bIsExpandable.Value;
        }

        //---------------------------------------------------------------
        //Retourne la position de fin de l'élément
        internal int CalculeDessin(int nX, int nYTop)
        {
            bool bMargeOnNext = false;
            int nNextY = nYTop;
            int nYTopItem = nYTop;
            List<CDessinSatisfaction> lstSatisfactionsDeThis = new List<CDessinSatisfaction>();
            CBesoin besoin = Satisfaction as CBesoin;
            if (besoin != null)
            {
                foreach (CRelationBesoin_Satisfaction sat in besoin.RelationsSatisfactions)
                {
                    CDessinSatisfaction dessinSatisfaction = Niveau.BaseSatisfactions.GetDessin(sat.Satisfaction);
                    if (dessinSatisfaction != null && !dessinSatisfaction.IsPositionValide() &&
                        dessinSatisfaction.IsVisible())
                    {
                        lstSatisfactionsDeThis.Add(dessinSatisfaction);
                    }
                }
            }
            for (int nSatisfactionDeThis = 0; nSatisfactionDeThis < lstSatisfactionsDeThis.Count; nSatisfactionDeThis++)
            {
                CDessinSatisfaction satisfactionDeThis = lstSatisfactionsDeThis[nSatisfactionDeThis];
                if ( !satisfactionDeThis.IsPositionValide() )
                {
                    if ( bMargeOnNext )
                        nNextY += Niveau.BaseSatisfactions.m_nMargeVerticale;

                    nNextY = satisfactionDeThis.CalculeDessin(nX, nNextY);
                    if (satisfactionDeThis.Niveau == Niveau)
                        nYTopItem = nNextY;
                    bMargeOnNext = true;
                }
            }
            int nHauteurTotale = Math.Max(Niveau.BaseSatisfactions.m_nHauteurSatisfactionDefaut, nNextY - nYTop);
            Rectangle rct = new Rectangle(nX, nYTopItem + nHauteurTotale / 2 - Niveau.BaseSatisfactions.m_nMargeVerticale,
                Niveau.BaseSatisfactions.m_nLargeurNiveauDefaut,
                Niveau.BaseSatisfactions.m_nHauteurSatisfactionDefaut);
            int nYMax = nYTopItem + nHauteurTotale;
            int nYMin = rct.Top;
            if (m_bIsExpanded)
            {
                if (m_listeFils != null)
                {
                    foreach (CDessinSatisfaction dessin in m_listeFils)
                    {
                        if (!dessin.IsPositionValide())
                            nYMax = Math.Max(dessin.CalculeDessin(nX , nYMax), nYMax);
                        else
                            nYMin = Math.Min(dessin.Rectangle.Top, nYMin);
                    }
                }
                rct.Offset(Niveau.BaseSatisfactions.m_nOffestNiveau / 3,0);
            }
            if (nYMin < rct.Top)
            {
                //Un des fils est plus Haut->monte au dessus du fils
                foreach (CDessinSatisfaction dessin in Niveau.Dessins)
                {
                    if (dessin.IsPositionValide() && dessin.IsVisible() && dessin.Rectangle.Top >= nYMin)
                        dessin.Offset(0, Niveau.BaseSatisfactions.m_nHauteurSatisfactionDefaut);
                }
                rct.Offset(0, nYMin - rct.Top);
            }
            CDessinSatisfaction parent = DessinParent;
            if ( m_bIsExpanded )
                rct.Height = nYMax - rct.Top ;
            m_nBasZoneOccupee = nYMax;
            Rectangle = rct;
            nNextY = Math.Max(nNextY, nYMax);
            return nNextY;
        }

        //------------------------------------------------------
        //Convertit une coordonnée générale en coordonnée locale
        public Point PointToClient(Point pt)
        {
            pt.Offset(-Rectangle.Left, -Rectangle.Top);
            return pt;
        }

        //------------------------------------------------------
        //Convertit une coordonnée locale en coordonnée générale
        public Point PointToGeneral(Point pt)
        {
            pt.Offset(-Rectangle.Left, -Rectangle.Top);
            return pt;
        }



        //------------------------------------------------------
        public void Draw(
            Color couleurFond,
            Font ft,
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
            rct.Height = Niveau.BaseSatisfactions.m_nHauteurSatisfactionDefaut;
            rct.Inflate(-2, -2);

            Image img = sc2i.common.DynamicClassAttribute.GetImage(m_satisfaction.GetType());
            if (img != null)
            {
                Rectangle rctImage = new Rectangle(rct.Left, rct.Top, 16, 16);
                g.DrawImage(img, rctImage);
                rct.Offset(16, 0);
                rct.Width -= 16;
            }
            if (IsExpandable())
            {
                img = m_bIsExpanded ? Resources.blueUp32 : Resources.blueDown32;
                Size sz = CUtilImage.GetSizeAvecRatio(img, new Size(2000, 16));
                Rectangle rctImage = new Rectangle(rct.Right - sz.Width,
                    rct.Bottom - sz.Height,
                    sz.Width,
                    sz.Height);
                g.DrawImage(img, rctImage, new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
                Point pt = new Point(rctImage.Left, rctImage.Top);
                pt = PointToClient(pt);
                m_rectangleZoneExpand = rctImage;
            }
            else
                m_rectangleZoneExpand = null;


            string str = m_satisfaction.LibelleSatisfactionComplet;
            if (DessinParent != null)
                str = m_satisfaction.Libelle;
            StringFormat sf = new StringFormat(StringFormatFlags.FitBlackBox);
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            g.DrawString(str, ft, Brushes.Black, rct, sf);
            sf.Dispose();
        }

        //---------------------------------------------------------
        internal void OffsetChilds(int nNiveau)
        {
            if (!IsCollapse())
            {
                foreach (CDessinSatisfaction dessin in m_listeFils)
                {
                    if (dessin.IsPositionValide())
                    {
                        Rectangle rct = dessin.Rectangle;
                        dessin.m_rectangle = new Rectangle(rct.Left + (nNiveau+1) * Niveau.BaseSatisfactions.m_nOffestNiveau,
                            rct.Top,
                            rct.Width,
                            rct.Height);
                    }
                    dessin.OffsetChilds(nNiveau + 1);
                }
            }
        }

        //---------------------------------------------------------
        public void OnMouseMove(CControleMapBesoin controleMap, Point ptLocal)
        {
            if (m_rectangleZoneExpand != null && m_rectangleZoneExpand.Value.Contains(ptLocal))
            {
                controleMap.Cursor = Cursors.Hand;
            }
            else
                controleMap.Cursor = Cursors.Default;
        }

        //---------------------------------------------------------
        public void OnMouseDown(CControleMapBesoin controleMap, Point ptLocal)
        {
        }

        //---------------------------------------------------------
        public void OnMouseUp(CControleMapBesoin controleMap, Point ptLocal)
        {
            if (m_rectangleZoneExpand != null && m_rectangleZoneExpand.Value.Contains(ptLocal))
            {
                if ( IsCollapse() )
                    Expand();
                else
                    Collapse();
            }
        }
    }

}

