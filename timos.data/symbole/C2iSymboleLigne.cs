using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

using sc2i.common;
using sc2i.drawing;
using sc2i.formulaire;

namespace timos.data
{
    [WndName("Line")]
    [Serializable]
    [VisibleInInterfaceAttribute]
    public class C2iSymboleLigne : C2iSymbole
    {

        

        private int m_nLineWidth = 1;

       
        private System.Drawing.Drawing2D.DashStyle m_lineStyle;

        private bool m_bClosed;

        private ArrayList m_arrayPoints = new ArrayList();


        
        private bool m_bBezier = false;

      
        private bool m_bModeSelection = true;

        private HatchStyle? m_hatchStyle;

        private float[] m_customDashPattern = { 1.0f, 1.0f, 1.0f, 1.0f };

        private LineCap m_startCap = LineCap.Flat;
        private LineCap m_endCap = LineCap.Flat;



        /// <summary>
        ///Mode "courbe de Bézier"
        /// si faux : ligne normale
        /// si vrai : courbe de Bézier
        /// (Incompatible avec le mode "ligne fermée")
        /// </summary>
        /// <returns></returns>
        public bool Bezier
        {
            get
            {
                return m_bBezier;
            }
            set
            {
                if ((!m_bBezier) && (value))
                {

                    m_bClosed = false;

                }

                m_bBezier = value;
            }

        }


        /// <summary>
        ///Style de la flèche en début de ligne
        /// par défaut : pas de flèche
        /// </summary>
        /// <returns></returns>
        public LineCap StartCap
        {
            get
            {
                return m_startCap;
            }
            set
            {
                m_startCap = value;
            }

        }

        /// <summary>
        ///Style de la flèche en fin de ligne
        /// par défaut : pas de flèche
        /// </summary>
        /// <returns></returns>
        public LineCap EndCap
        {
            get
            {
                return m_endCap;
            }
            set
            {
                m_endCap = value;
            }

        }

        public Point[] Points
        {
            get
            {
                Point[] tabPoint = (Point[])m_arrayPoints.ToArray(typeof(Point));
                return tabPoint;
            }
            set
            {
                m_arrayPoints.Clear();
                foreach (Point p in value)
                {
                    m_arrayPoints.Add(p);
                    RecalcSizeAndPos();

                }
              
            }

        }

        public float[] LineDashPattern
        {
            get
            {
                return m_customDashPattern;
            }

            set
            {
                m_customDashPattern = value;
            }

        }

        public HatchStyle? HatchBrushStyle
        {
            get
            {
                return m_hatchStyle;
            }
            set
            {
                m_hatchStyle = value;
            }

        }




        public System.Drawing.Drawing2D.DashStyle LineStyle
        {
            get
            {
                return m_lineStyle;
            }
            set
            {
                m_lineStyle = value;

            }
        }
        public int LineWidth
        {
            get
            {
                return m_nLineWidth;
            }
            set
            {
                m_nLineWidth = value;

            }
        }

        public bool GetModeSelection()
        {
            return m_bModeSelection;
        }




        public void SetModeSelection(bool mode)
        {
            m_bModeSelection = mode;
        }


       
        public bool Closed
        {
            get
            {
                return m_bClosed;
            }
            set
            {
                if ((!m_bClosed) && (value))

                    m_bBezier = false;

                m_bClosed = value;
            }
        }
        public override Size Size
        {
            get
            {
                return base.Size;
            }
            set
            {
                Size newSize = value;
                if (value.Height == 0)
                    newSize.Height = 1;
                if (value.Width == 0)
                    newSize.Width = 1;


                Size oldSize = Size;
                base.Size = newSize;
                OnChangeSize(oldSize, newSize);

            }
        }



        /// ///////////////////////////////////////
        private int GetNumVersion()
        {
            return 3;
        }



        public C2iSymboleLigne()
        {
            Size = new Size(64,10);
        }

        

 

        public override Point Position
        {
            get
            {
                return base.Position;
            }
            set
            {
                Point oldPos = Position;
                base.Position = value;
                OnChangePosition(oldPos, Position);


            }
        }


        /// <summary>
        ///Recalcule les coordonnées des points de la ligne 
        /// après un changement de taille afin d'appliquer une 
        /// homothétie à la forme
        /// </summary>
        /// <returns></returns>
        private void OnChangeSize(Size previousSize, Size newSize)
        {
            double dVScale;
            double dHScale;
            if (previousSize.Height != 0)
                dVScale = (double)newSize.Height / (double)previousSize.Height;
            else
                dVScale = 1.0;
            if (previousSize.Width != 0)
                dHScale = (double)newSize.Width / (double)previousSize.Width;
            else
                dHScale = 1.0;
            Point[] pts = Points;
            for (int i = 0; i < pts.Length; i++)
            {
                Point newPoint = new Point(pts[i].X - Position.X, pts[i].Y - Position.Y);
                newPoint.X = (int)(((double)newPoint.X) * dHScale) + Position.X;
                newPoint.Y = (int)(((double)newPoint.Y) * dVScale) + Position.Y;
                pts[i] = newPoint;
            }
            Points = pts;
        }

        /// <summary>
        ///Recalcule les coordonnées des points de la ligne 
        /// après un changement de positionn
        /// </summary>
        /// <returns></returns>

        private void OnChangePosition(Point oldPosition, Point newPosition)
        {
            int nDeplX = newPosition.X - oldPosition.X;
            int nDeplY = newPosition.Y - oldPosition.Y;
            Point[] pts = Points;
            for (int i = 0; i < pts.Length; i++)
            {
                pts[i].X += nDeplX;
                pts[i].Y += nDeplY;
            }
            Points = pts;
        }

        /// <summary>
        ///Recalcule la taille et la position de l'objet graphique
        /// après une modification du tableau de points
        /// </summary>
        /// <returns></returns>


        private void RecalcSizeAndPos()
        {

            int nBottom = 0;
            int nRight = 0;
            int nLeft = int.MaxValue;
            int nTop = int.MaxValue;
            foreach (Point point in Points)
            {

                if (point.X <= nLeft)
                    nLeft = point.X;
                if (point.X >= nRight)
                    nRight = point.X;
                if (point.Y <= nTop)
                    nTop = point.Y;
                if (point.Y >= nBottom)
                    nBottom = point.Y;
               
            }

            System.Drawing.Size newSize = new System.Drawing.Size((nRight - nLeft), (nBottom - nTop));
            if (newSize.Width == 0)
                newSize.Width = 1;
            if (newSize.Height == 0)
                newSize.Height = 1;
            base.Size = newSize;
            Point newPosition = new Point(nLeft, nTop);
            base.Position = newPosition;

        }


        /// <summary>
        ///Calcule la distance entre deux points
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>

        private double Distance(Point point1, Point point2)
        {


            return Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2));

        }


        /// <summary>
        /// Retourne l'index d'un point proche du point de sélection.
        /// Si négatif, pas de point près de la sélection
        /// </summary>
        /// <param name="pointToSelect"></param>
        /// <returns></returns>
        public int GetIndexPointProche(Point pointToSelect)
        {
            int nIndex = 0;
            foreach (Point point in Points)
            {
                if (((m_nLineWidth < 3) && (Distance(point, pointToSelect) < 5 * m_nLineWidth)) || ((m_nLineWidth >= 3) && (Distance(point, pointToSelect) < 3 * m_nLineWidth)))
               {
                    return nIndex;
                }
                nIndex++;
            }
            return -1;
        }




        /// <summary>
        /// Remplace le point situé à l'index nIndexPoint par le point 
        /// de coordonnées newPoint
        /// </summary>
        /// <param name="pt"></param>
        /// <param name="nIndexPoint"></param>
        /// <param name="newPoint"></param>
        /// <returns></returns>

        public void ReplacePoint(int nIndexPoint, Point newPoint)
        {
            Point[] pts = Points;
            if (nIndexPoint >= 0 && nIndexPoint < pts.Length)
            {
                pts[nIndexPoint] = newPoint;
                Points = pts;
            }
        }

        /// <summary>
        /// Supprime le point de la ligne situé à l'index nIndexpoints
        /// </summary>
        /// <param name="nIndexPoint"></param>
        /// <returns></returns>
        public bool RemovePoint(int nIndexPoints)
        {
            List<Point> pts = new List<Point>(Points);
            if (nIndexPoints >= 0 && nIndexPoints < pts.Count)
            {
                pts.RemoveAt(nIndexPoints);
                Points = pts.ToArray();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Retourne true si le point est proche du segment demandé.
        /// </summary>
        /// <param name="pt"></param>
        /// <param name="PointDepart"></param>
        /// <param name="PointArrivee"></param>
        /// <returns></returns>
        public bool IsPointOnSegment(Point pt, Point PointDepart, Point PointArrivee)
        {
            return new CSegmentDroite(PointArrivee, PointDepart).GetDistance(pt) < 6;
            /*
            //Calcule la distance entre la droite et le point
            CSegmentDroite segment = new CSegmentDroite(PointArrivee, PointDepart);
            double fA = 0, fB = 0, fC = 0;
            segment.GetEquationDroite(ref fA, ref fB, ref fC);
            double fSqrt = Math.Sqrt(fA * fA + fB * fB);
            if (fSqrt == 0)
                return false;
            double fDistance = Math.Abs((fA * (double)pt.X + fB * (double)pt.Y + fC) / fSqrt);
            if (((m_nLineWidth < 3) && (fDistance < 5 * m_nLineWidth)) || ((m_nLineWidth >= 3) && (fDistance < 3 * m_nLineWidth)))
            {
                //Vérifie que le point est environ sur le segment
                if (pt.X >= Math.Min(PointArrivee.X, PointDepart.X) &&
                    pt.X <= Math.Max(PointArrivee.X, PointDepart.X) &&
                    pt.Y >= Math.Min(PointArrivee.Y, PointDepart.Y) &&
                    pt.Y <= Math.Max(PointArrivee.Y, PointDepart.Y))
                    return true;
            }
            return false;*/

        }




        /// <summary>
        /// vérifie si le point "PointToSelect" est proche d'un point quelconque de la ligne
        /// retourne true si l'on est proche d'un point, false sinon
        /// </summary>
        public bool IsCloseToPoint(Point pointToSelect)
        {

            
            for (int i = 0; i < Points.Length; i++)
            {

                if (IsCloseToSelectedPoint(pointToSelect, Points[i]))
                    return true;
            }
            return false;
        }


        //vérifie si le point "PointToSelect" est proche du point "SelectedPoint"
        //retourne true si l'on est proche d'un point, false sinon
        //la distance à évaluer tient compte de l'épaisseur de la ligne
        public bool IsCloseToSelectedPoint(Point pointToSelect, Point SelectedPoint)
        {
            if (((m_nLineWidth < 3) && (Distance(SelectedPoint, pointToSelect) < 5 * m_nLineWidth)) || ((m_nLineWidth >= 3) && (Distance(SelectedPoint, pointToSelect) < 3 * m_nLineWidth)))
            {
                return true;
            }

            return false;
        }
       

     



   

        protected override void MyDraw(CContextDessinObjetGraphique ctx)
        {

            DrawLigne(ctx.Graphic,false);

            base.MyDraw(ctx);

        }


    protected void DrawLigne(Graphics g,bool bSelection)
    {

            Point[] pts = Points;


            if (pts.Length <2)
            {
                List<Point> listePoints = new List<Point>();
                Rectangle rectSize = new Rectangle(Position, Size);
                Point newPoint1 = new Point(rectSize.Left, rectSize.Top);
                Point newPoint2 = new Point(rectSize.Right, rectSize.Bottom);
                listePoints.Add(newPoint1);
                listePoints.Add(newPoint2);

                pts = listePoints.ToArray();

                Points = pts;
                
            }
            
            if(Parent != null && bSelection)
                for (int i = 0; i < pts.Length; i++)
                {
                    pts[i] = Parent.ClientToGlobal(pts[i]);
                }

            Brush b;

            if (m_hatchStyle != null)
                b = new System.Drawing.Drawing2D.HatchBrush(m_hatchStyle.Value, ForeColor, BackColor);
            else
                b = new SolidBrush(BackColor);

            

            Pen pen;
            if (bSelection)
            {
                 pen = new Pen(Color.Red, 2);
                 pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            }
            else
            {
                pen = new Pen(ForeColor);
                pen.Width = LineWidth;
                pen.DashStyle = m_lineStyle;
                if (m_lineStyle == System.Drawing.Drawing2D.DashStyle.Custom)
                    pen.DashPattern = m_customDashPattern;
            }
           
            if (m_bBezier)
            {
                
                if (pts.Length < 4 || ((pts.Length - 4) % 3 != 0))
                {
                    List<Point> listePoints = new List<Point>(pts);
                    while (listePoints.Count < 4 || ((listePoints.Count - 4) % 3 != 0))
                    {
                        listePoints.Add(pts[pts.Length - 1]);
                                               
                    }
                    Point[] tabBezier = listePoints.ToArray();
                    g.DrawBeziers(pen, tabBezier);
                }
                else
                    g.DrawBeziers(pen, pts);
            
               

            }
            else
            {
                if (m_bClosed)
                {
                    
                    g.FillPolygon(b, pts);

                }
                Point previousPoint = pts[0];

                //dessin du premier segment de la ligne


                if (!m_bClosed)
                    pen.StartCap = m_startCap;
                //dessin de la flèche de début si la ligne n'est pas fermée

                //dessin de la flèche de fin si l'on n'a que deux points
                if (!m_bClosed && (pts.Length == 2))
                    pen.EndCap = m_endCap;

                 g.DrawLine(pen, previousPoint, pts[1]);

               
                
                //dessin des segments intermédiaires (toujours sans flèche)
                pen.StartCap = LineCap.Flat;
                if (m_arrayPoints.Count > 3)
                {
                    for (int i = 1; i < pts.Length - 1; i++)
                    {
                        g.DrawLine(pen, previousPoint, pts[i]);
                        previousPoint = pts[i];
                    }
                }

                //dessin du dernier segment (avec la flèche de fin)
                if (m_arrayPoints.Count > 2)
                {
                    if (!m_bClosed)
                        pen.EndCap = m_endCap;
                    g.DrawLine(pen, pts[pts.Length - 2], pts[pts.Length - 1]);

                }

                //on ferme la forme si la ligne est fermée
                if (m_bClosed)
                {
                    g.DrawLine(pen, pts[pts.Length - 1], pts[0]);

                }
            }
            pen.Dispose();
        }





        //dessine la ligne sélectionnée avec des carrés autour des points de la ligne
        //si l'on est en mode édition de ligne
        

        public override void DrawSelected(Graphics g)
        {

            Point[] pts=Points;

            
     
            if (!m_bModeSelection)
            {
                DrawLigne(g, true);
                Brush bPoint = new SolidBrush(Color.FromArgb(128, ForeColor));

                for (int i = 0; i < pts.Length; i++)
                {
                    Point point = pts[i];
                    if (Parent != null)
                        point = Parent.ClientToGlobal(point);
                    if (m_nLineWidth < 3)

                        g.FillRectangle(bPoint, point.X - 2 * m_nLineWidth, point.Y - 2 * m_nLineWidth, 5 * m_nLineWidth, 5 * m_nLineWidth);

                    else

                        g.FillRectangle(bPoint, point.X - m_nLineWidth, point.Y - m_nLineWidth, 3 * m_nLineWidth, 3 * m_nLineWidth);

                }
                bPoint.Dispose();
   
            }
            else 
                 base.DrawSelected(g);
    
        }
     

        /// <summary>
        /// Retourne le point de la ligne situé avant un point donné
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public Point? PointOnlineBeforePoint(Point pt)
        {
            Point[] pts = Points;
            if (pts.Length > 1)
            {
                Point prevPoint = pts[0];
                for (int i = 1; i <= pts.Length - 1; i++)
                {
                    if (IsPointOnSegment(pt, prevPoint, pts[i]))
                        return prevPoint;
                    prevPoint = (Point)pts[i];
                }

            }
            return null;
        }


        /// <summary>
        /// Insère un point après le point donné
        /// </summary>
        /// <param name="prevPoint"></param>
        /// <param name="pointToInsert"></param>
        public void InsertAfterPoint(Point prevPoint, Point pointToInsert)
        {
            List<Point> pts = new List<Point>(Points);
            for (int i = 0; i < pts.Count; i++)
            {
                Point point = (Point)pts[i];
                if (((m_nLineWidth < 3) && (Distance(point, prevPoint) < 5 * m_nLineWidth)) || ((m_nLineWidth >= 3) && (Distance(point, prevPoint) < 3 * m_nLineWidth)))
                {
                    pts.Insert(i + 1, pointToInsert);
                    Points = pts.ToArray();
                    return;
                }
            }
        }


        /// <summary>
        /// Insère un point après le dernier point de la ligne
        /// </summary>
        /// <param name="prevPoint"></param>
        /// <param name="pointToInsert"></param>
        public void InsertAfterLastPoint(Point pointToInsert)
        {
            List<Point> pts = new List<Point>(Points);
            pts.Insert(pts.Count, pointToInsert);
            Points = pts.ToArray();
        }

   





        /// ///////////////////////////////////////
        protected override CResultAErreur MySerialize(C2iSerializer serializer)
        {

            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;

            result = base.MySerialize(serializer);
            if (!result)
                return result;


            serializer.TraiteInt(ref m_nLineWidth);


            int nLineStyle = (int)m_lineStyle;
            serializer.TraiteInt(ref nLineStyle);
            m_lineStyle = (System.Drawing.Drawing2D.DashStyle)nLineStyle;

            serializer.TraiteBool(ref m_bClosed);
            serializer.TraiteBool(ref m_bBezier);

            int nTmp;

            if (nVersion > 2)
            {
                int? nVal = (int?)m_hatchStyle;
                bool bHasVal = nVal != null;
                serializer.TraiteBool(ref bHasVal);
                if (bHasVal)
                {
                    nTmp = nVal != null ? nVal.Value : 0;
                    serializer.TraiteInt(ref nTmp);
                    m_hatchStyle = (HatchStyle?)nTmp;
                }
                else
                {
                    nVal = null;
                    m_hatchStyle = (HatchStyle?)nVal;
                }
            }

            int nStartCap = (int)m_startCap;
            serializer.TraiteInt(ref nStartCap);
            m_startCap = (System.Drawing.Drawing2D.LineCap)nStartCap;

            int nEndCap = (int)m_endCap;
            serializer.TraiteInt(ref nEndCap);
            m_endCap = (System.Drawing.Drawing2D.LineCap)nEndCap;

            int nNbPts = m_arrayPoints.Count;
            serializer.TraiteInt(ref nNbPts);
            switch (serializer.Mode)
            {
                case ModeSerialisation.Ecriture:
                    {
                        foreach (Point pt in m_arrayPoints)
                        {

                            int nX = pt.X;
                            int nY = pt.Y;
                            serializer.TraiteInt(ref nX);
                            serializer.TraiteInt(ref nY);

                        }
                        break;
                    }
                case ModeSerialisation.Lecture:
                    {
                        m_arrayPoints.Clear();
                        for (int n = 0; n < nNbPts; n++)
                        {
                            int nX = 0;
                            int nY = 0;
                            serializer.TraiteInt(ref nX);
                            serializer.TraiteInt(ref nY);
                            m_arrayPoints.Add(new Point(nX, nY));

                        }
                        break;


                    }


            }


            IList listTmp = new ArrayList();
            for (int i = 0; i < 4; i++)
            {
                double dTmp = (double)m_customDashPattern[i];
                listTmp.Add((object)dTmp);
            }
            serializer.TraiteListeObjetsSimples(ref listTmp);
            if (serializer.Mode == ModeSerialisation.Lecture)
            {
                for (int i = 0; i < 4; i++)

                    m_customDashPattern[i] = (float)(double)listTmp[i];
            }
            return result;

        }


        public override void HorizontalFlip()
        {

            Point[] pts = Points;
            int newX;
            int nMilieu = Position.X + Size.Width / 2;

            
            for (int i = 0; i < pts.Length; i++)
            {
              

                Point p = pts[i];

                if (p.X < nMilieu)
                    newX = p.X + 2 * (nMilieu - p.X);

                else
                    newX = p.X - 2 * (p.X - nMilieu);
                pts[i] = new Point(newX, p.Y);

            }
            Points = pts;
            base.HorizontalFlip();
        }


        public override void VerticalFlip()
        {
            Point[] pts = Points;
            int newY;
            int nMilieu = Position.Y + Size.Height / 2;
            for (int i = 0; i < pts.Length; i++)
            {
               

                Point p = pts[i];

                if (p.Y < nMilieu)
                    newY = p.Y + 2 * (nMilieu - p.Y);

                else
                    newY = p.Y - 2 * (p.Y - nMilieu);
                 pts[i] = new Point(p.X, newY);

            }

            Points = pts;
            base.VerticalFlip();
        }
    }
}



