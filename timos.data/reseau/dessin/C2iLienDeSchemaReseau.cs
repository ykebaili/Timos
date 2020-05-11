using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using sc2i.drawing;
using sc2i.common;


namespace timos.data
{
    [Serializable]
    public class C2iLienDeSchemaReseau : C2iObjetDeSchema
    {
        public C2iLienDeSchemaReseau()
            : base()
        {

        }

      


        protected bool m_bModeSelection = true;

        //------------------------------------     
        public override bool NoPoignees
        {
            get
            {
                return true;
            }
        }


        //Largeur de la ligne
        public int LineWidth
        {
            get
            {
                return DonneeDessinLien.LineWidth;
            }
            set
            {
                DonneeDessinLien.LineWidth = value;

            }
        }

        public bool Curve
        {
            get
            {
                return DonneeDessinLien.Curve;
            }
            set
            {
                DonneeDessinLien.Curve = value;
            }
        }

        public ESensAllerRetourLienReseau ForwardBackward
        {
            get
            {
                return DonneeDessinLien.Forward_Backward;
            }
            set
            {
                DonneeDessinLien.Forward_Backward = value;
            }
        }

        //------------------------------------     
        public EModeOperationnelSchema OperationnalMode
        {
            get
            {
                return DonneeDessinLien.Operationnal_Mode;
            }
            set
            {
                DonneeDessinLien.Operationnal_Mode = value;
            }
        }


        //------------------------------------     
        protected override IDonneeDessinElementDeSchemaReseau AlloueDonneeDessin()
        {
            return new CDonneeDessinLienDeSchemaReseau(-1);
        }

        //------------------------------------     
        private CDonneeDessinLienDeSchemaReseau DonneeDessinLien
        {
            get
            {
                return DonneeDessin as CDonneeDessinLienDeSchemaReseau;
            }
        }
                    

        //------------------------------------
        public Color ForeColor
        {
            get
            {
                return DonneeDessinLien.ForeColor;
            }

            set
            {
                DonneeDessinLien.ForeColor = value;
            }

        }



        //------------------------------------
        public bool GetModeSelection()
        {
            return m_bModeSelection;
        }


        //------------------------------------
        public void SetModeSelection(bool mode)
        {
            m_bModeSelection = mode;
        }

        //------------------------------------
        public override bool NoRectangleSelection
        {
            get
            {
                return true;
            }
        }

        //------------------------------------
        public override Size Size
        {
            get
            {
                return base.Size;
            }
            set
            {
                if (Points.Length < 2)
                    base.Size = value;
                else
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
        }


        //-------------------------------------------------

        public override bool IsPointIn(Point pt)
        {
            Point[] pts = Points;
            if (pts.Length >= 2)
            {
                Point previous = pts[0];
                for (int nPt = 1; nPt < pts.Length; nPt++)
                {
                    if (IsPointOnSegment(pt, previous, pts[nPt]))
                        return true;
                    previous = pts[nPt];
                }
            }
            return false;
        }

        //-------------------------------------------------
        public Point[] Points
        {
            get
            {
                return DonneeDessinLien.Points;
            }
            set
            {
                bool bTmp = false;
                if ( value.Length >= 1 )
                {
                    
                    C2iObjetDeSchema objet1 = GetObjetElement1 ( ref bTmp );
                    if ( objet1 != null )
                    {
                        Point pt1 = value[0];
                        pt1.X = Math.Max ( pt1.X, objet1.Position.X );
                        pt1.X = Math.Min ( pt1.X, objet1.Position.X + objet1.Size.Width );
                        pt1.Y = Math.Max ( pt1.Y, objet1.Position.Y );
                        pt1.Y = Math.Min ( pt1.Y, objet1.Position.Y + objet1.Size.Height );
                        value[0] = pt1;
                        OffsetElement1 = new Point ( pt1.X - objet1.Position.X, pt1.Y - objet1.Position.Y );
                    }
                }
                if (value.Length >= 2)
                {
                    bTmp = false;
                    C2iObjetDeSchema objet2 = GetObjetElement2(ref bTmp);
                    if (objet2 != null)
                    {
                        Point pt2 = value[value.Length-1];
                        pt2.X = Math.Max(pt2.X, objet2.Position.X);
                        pt2.X = Math.Min(pt2.X, objet2.Position.X + objet2.Size.Width);
                        pt2.Y = Math.Max(pt2.Y, objet2.Position.Y);
                        pt2.Y = Math.Min(pt2.Y, objet2.Position.Y + objet2.Size.Height);
                        value[value.Length-1] = pt2;
                        OffsetElement2 = new Point ( pt2.X - objet2.Position.X, pt2.Y - objet2.Position.Y );
                    }
                }
                DonneeDessinLien.Points = value;
                RecalcSizeAndPos();
            }
        }

        //----------------------------------------------
        public Point GetPointCentral()
        {
            if (Points.Length < 2)
            {
                if (Points.Length > 0)
                    return Points[0];
                return new Point(0, 0);
            }
            if (Points.Length % 2 != 0)
                //Nombre impaire
                return Points[Points.Length / 2];
            else
            {
                Point pt1 = Points[Points.Length / 2 - 1];
                Point pt2 = Points[Points.Length / 2];
                return new Point((pt1.X + pt2.X) / 2, (pt1.Y + pt2.Y) / 2);
            }
        }

        //----------------------------------------------
        protected Point OffsetElement1
        {
            get
            {
                return DonneeDessinLien.OffsetElement1;
            }
            set
            {
                DonneeDessinLien.OffsetElement1 = value;
            }
        }

        //----------------------------------------------
        protected Point OffsetElement2
        {
            get
            {
                return DonneeDessinLien.OffsetElement2;
            }
            set
            {
                DonneeDessinLien.OffsetElement2 = value;
            }
        }


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

        //-----------------------------------
        public override Point Position
        {
            get
            {
                return base.Position;
            }
            set
            {
                if (Points.Length < 2)
                    base.Position = value;
                else
                {
                    OnChangePosition(Position, value);
                    RecalcSizeAndPos();
                }
            }
        }


        private void OnChangePosition(Point oldPosition, Point newPosition)
        {
            int nDeplX = newPosition.X - oldPosition.X;
            int nDeplY = newPosition.Y - oldPosition.Y;
            Point[] pts = Points;
            for (int i = 1;  i < pts.Length-1; i++)
            {
                pts[i].X += nDeplX;
                pts[i].Y += nDeplY;
            }
            Points = pts;
        }


        protected void RecalcSizeAndPos()
        {

            int nBottom = 0;
            int nRight = 0;
            int nLeft = int.MaxValue;
            int nTop = int.MaxValue;
            if (Points.Length < 2)
            {
                nLeft = Size.Width;
                nRight = Size.Height;
            }
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
        public int GetIndexPointProche(Point pointDeSelection)
        {
            int nIndex = 0;
            foreach ( Point point in Points )
            {
                if (Distance(point, pointDeSelection) < 5)
                {
                    return nIndex;
                }
                nIndex++;
            }
            return -1;
        }

        /// <summary>
        /// retourne true si le point donné est "proche" d'un point de la ligne
        /// </summary>
        /// <param name="pointToSelect"></param>
        /// <returns></returns>
        public bool IsCloseToPoint(Point pointToSelect)
        {
            Point[] pts = Points;
            for (int i = 0; i < pts.Length; i++)
            {
                if (Distance(pointToSelect, pts[i]) < 5)
                    return true;
            }
            return false;
        }


        public void ReplacePoint(int nIndexPoint, Point newPoint)
        {
            Point[] pts = Points;
            if (nIndexPoint >= 0 && nIndexPoint < pts.Length)
            {
                pts[nIndexPoint] = newPoint;
                Points = pts;
            }
        }

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
            if (fDistance < 5 )
            {
                //Vérifie que le point est environ sur le segment
                if (pt.X >= Math.Min(PointArrivee.X, PointDepart.X)-3 &&
                    pt.X <= Math.Max(PointArrivee.X, PointDepart.X)+3 &&
                    pt.Y >= Math.Min(PointArrivee.Y, PointDepart.Y)-3 &&
                    pt.Y <= Math.Max(PointArrivee.Y, PointDepart.Y)+3)
                    return true;
            }
            return false;*/

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
                if (Distance(point, prevPoint) < 1)
                {
                    pts.Insert(i + 1, pointToInsert);
                    Points = pts.ToArray();
                    return;
                }
            }
        }

        //------------------------------------------------------------
        /// <summary>
        /// Return l'objet de schéma associé à l'élément1 du lien
        /// </summary>
        /// <param name="bCreate">Indique si l'objet peut être créé. En sortie, indique s'il a été créé par cette fonction</param>
        /// <returns></returns>
        public C2iObjetDeSchema GetObjetElement1(ref bool bCreate)
        {
            if (ElementDeSchema == null || !ElementDeSchema.IsValide())
                return null;
            CLienReseau lien = ElementDeSchema.LienReseau;
            if (lien == null)
                return null;
            IElementDeSchemaReseau extremite = null;
            CCheminLienReseau racine = ElementDeSchema.RacineChemin1;
            if (racine != null)
                extremite = racine.Etape as IElementDeSchemaReseau;
            if (extremite == null)
                extremite = lien.Element1 as IElementDeSchemaReseau;

            return GetObjetElement(extremite, ref bCreate);
        }


        //------------------------------------------------------------
        protected C2iObjetDeSchema GetObjetElement ( IElementDeSchemaReseau elt, ref bool bCreate )
        {
            bool bAutoriseCreate = bCreate;
            bCreate = false;
            if ( elt == null )
                return null;
            C2iObjetDeSchema objetParent = Parent as C2iObjetDeSchema;
            if ( objetParent == null )
                return null;
            while ( (objetParent.Parent as C2iObjetDeSchema)!= null )
                objetParent = objetParent.Parent as C2iObjetDeSchema;
            C2iObjetDeSchema objetElement = objetParent.FindChildRepresentant(elt);
            if ( objetElement != null )
                return objetElement;
            if ( bAutoriseCreate )
            {
                C2iObjetDeSchema objet = CreateObjetFor(elt);
                if (objet == null)
                    return null;
                objet.Position = new Point(Position.X - objet.Size.Width / 2,
                    Position.Y - objet.Size.Height / 2);
                bCreate = true;
                return objet;
            }
            return null;
        }

        //------------------------------------------------------------
        public C2iObjetDeSchema GetObjetElement2(ref bool bCreate)
        {
            if (ElementDeSchema == null || !ElementDeSchema.IsValide())
                return null;
            CLienReseau lien = ElementDeSchema.LienReseau;
            if (lien == null)
                return null;
            IElementDeSchemaReseau extremite = null;
            CCheminLienReseau racine = ElementDeSchema.RacineChemin2;
            if (racine != null)
                extremite = racine.Etape as IElementDeSchemaReseau;
            if (extremite == null)
                extremite = lien.Element2 as IElementDeSchemaReseau;

            return GetObjetElement(extremite, ref bCreate);
        }

        //---------------------------------------------------------------------------
        protected override void MyDraw(sc2i.drawing.CContextDessinObjetGraphique ctx)
        {
            if (ElementDeSchema == null || !ElementDeSchema.IsValide())
                return;
            bool bNewObjet1 = true;
            bool bNewObjet2 = true;
            C2iObjetDeSchema objet1 = GetObjetElement1 ( ref bNewObjet1 );
            C2iObjetDeSchema objet2 = GetObjetElement2(ref bNewObjet2);
            if (objet1 == null || objet2 == null)
                return;
            if (bNewObjet1)
                objet1.Position = Position;
            if (bNewObjet2)
                objet2.Position = new Point(Position.X + Size.Width, Position.Y + Size.Height);
            
            //Vérifie que la position des objets 1 et 2 permet de voir le lien
            if (objet1.RectangleAbsolu.IntersectsWith(objet2.RectangleAbsolu))
            {
                //Il faut déplacer l'un des deux objets
                if (bNewObjet1)
                {
                    //On déplace l'objet 1
                    if (objet1.Position.X < objet2.Position.X)
                        objet1.Position = new Point( objet2.RectangleAbsolu.Left - objet1.Size.Width * 2, objet1.Position.Y);
                    if (objet1.Position.X > objet2.Position.X)
                        objet1.Position = new Point(objet2.RectangleAbsolu.Right + objet1.Size.Width, objet1.Position.Y);
                    
                }
                else if (bNewObjet2)
                {
                    //On déplace l'objet 2
                    if (objet2.Position.X < objet1.Position.X)
                        objet2.Position = new Point(objet1.RectangleAbsolu.Left - objet2.Size.Width * 2, objet2.Position.Y);
                    if (objet2.Position.X > objet1.Position.X)
                        objet2.Position = new Point(objet1.RectangleAbsolu.Right + objet2.Size.Width, objet2.Position.Y );
                }
            }

      
            Point pt1 = new Point(objet1.Position.X + objet1.Size.Width / 2,
                   objet1.Position.Y + objet1.Size.Height / 2);
            
            Point pt2 = new Point(objet2.Position.X + objet2.Size.Width / 2,
                objet2.Position.Y + objet2.Size.Height / 2);

            
            List<Point> pts = new List<Point>(Points);
            //Calcule la position de départ
            if (OffsetElement1.X >= 0)
                pt1.X = objet1.Position.X + OffsetElement1.X;
            if (OffsetElement1.Y >= 0)
                pt1.Y = objet1.Position.Y + OffsetElement1.Y;
            if (OffsetElement2.X >= 0)
                pt2.X = objet2.Position.X + OffsetElement2.X;
            if (OffsetElement2.Y >= 0)
                pt2.Y = objet2.Position.Y + OffsetElement2.Y;
            if (pts.Count < 1)
                pts.Add(pt1);
            else
                pts[0] = pt1;
            if (pts.Count < 2)
                pts.Add(pt2);
            else
                pts[pts.Count - 1] = pt2;
            Points = pts.ToArray();
           
            Pen pen =new Pen(ForeColor);
            pen.Width = LineWidth;
            switch (DonneeDessinLien.Forward_Backward)
            {
                case ESensAllerRetourLienReseau.Backward:
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
                    pen.DashPattern = new float[] { 5.0f, 5.0f, 1.0f, 5.0f };
                    break;
            }
            Pen penFleche = new Pen(ForeColor);
            penFleche.Width = LineWidth;
            if (pts.Count > 2 && DonneeDessinLien.Curve)
            {

                ctx.Graphic.DrawCurve(pen, pts.ToArray());
                for (int n = 1; n < pts.Count-1; n++)
                    DrawFleches(ctx, penFleche, pts[n], pts[n-1], pts[n+1], ElementDeSchema.LienReseau.Direction);
            }
            else
            {
                for (int i = 0; i < pts.Count - 1; i++)
                {
                    ctx.Graphic.DrawLine(pen, (Point)pts[i], (Point)pts[i + 1]);

                    DrawFleches(ctx, penFleche, null, (Point)pts[i], (Point)pts[i + 1], ElementDeSchema.LienReseau.Direction);
                }
            }
            pen.Dispose();
            penFleche.Dispose();

            if (m_bModeSelection == false)
            {
                Brush bPoint = new SolidBrush(Color.FromArgb(128, ForeColor));
                
                for (int i = 0; i < pts.Count; i++)
                    
                    ctx.Graphic.FillRectangle(bPoint, pts[i].X - 2, pts[i].Y - 2, 5, 5);

                
                bPoint.Dispose();
            }
        }

        //---------------------------------------------------------------------------
        public override void DrawSelected(Graphics g)
        {
            Pen pen = new Pen(Color.Red, 2);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            Point[] pts = Points;
            if (pts.Length >= 2)
                g.DrawLines(pen, pts);
            pen.Dispose();
            if (m_bModeSelection == false)
            {
                Brush bPoint = new SolidBrush(Color.FromArgb(128, ForeColor));

                for (int i = 0; i < pts.Length; i++)

                    g.FillRectangle(bPoint, pts[i].X - 2, pts[i].Y - 2, 5, 5);


                bPoint.Dispose();
            }
        }

        /// <summary>
        /// Crée l'objet correspondant à l'une des extremités du lien
        /// </summary>
        private C2iObjetDeSchema CreateObjetFor(IElementDeSchemaReseau elementACreer)
        {
            CElementDeSchemaReseau eltDeSchema = new CElementDeSchemaReseau(ElementDeSchema.ContexteDonnee);
            eltDeSchema.CreateNewInCurrentContexte();
            eltDeSchema.SchemaReseau = ElementDeSchema.SchemaReseau;
            eltDeSchema.ElementAssocie = elementACreer;
            C2iObjetDeSchema objetDeSchema = eltDeSchema.ObjetDeSchema;
            Parent.AddChild(objetDeSchema);
            objetDeSchema.Parent = Parent;
            return objetDeSchema;
        }



        //Dessine les flèches sur un lien en fonction des extrémités du segment et du sens du lien
        protected void DrawFleches(
            CContextDessinObjetGraphique ctx,
            Pen pen,
            Point ?ptEmplacement,
            Point ptPrecedent, 
            Point ptSuivant, 
            EDirectionLienReseau sens)
        {
            Point milieu;
            if ( ptEmplacement != null )
                milieu = ptEmplacement.Value;
            else
                milieu = new Point((ptSuivant.X + ptPrecedent.X) / 2, (ptSuivant.Y + ptPrecedent.Y) / 2);
            
            double fDim2 = 25.0;

            double fCosa = (double)Math.Abs(ptPrecedent.X - milieu.X) / (double)(Math.Sqrt((ptPrecedent.X - milieu.X) * (ptPrecedent.X - milieu.X) + (ptPrecedent.Y - milieu.Y) * (ptPrecedent.Y - milieu.Y)));
            double fSina = (double)Math.Abs(ptPrecedent.Y - milieu.Y) / (double)(Math.Sqrt((ptPrecedent.X - milieu.X) * (ptPrecedent.X - milieu.X) + (ptPrecedent.Y - milieu.Y) * (ptPrecedent.Y - milieu.Y)));
      

            switch (sens)
            {
                case  EDirectionLienReseau.UnVersDeux :
                {

                    DrawFleche(ctx,pen, ptPrecedent,ptSuivant,milieu);


                    break;

                }

                case  EDirectionLienReseau.DeuxVersUn :
                {

                    DrawFleche(ctx, pen,ptSuivant, ptPrecedent, milieu);
                
                    break;
                }
            case  EDirectionLienReseau.Bidirectionnel:
                {
                    Point ext1 = new Point(0, 0);
                    Point ext2 = new Point(0, 0);
                    if (ptPrecedent.X < milieu.X)
                    {
                        ext1.X = (int)(milieu.X + (long)(fDim2 * Math.Sqrt(3) * fCosa / 2.0));
                        ext2.X = (int)(milieu.X - (long)(fDim2 * Math.Sqrt(3) * fCosa / 2.0));
                    }
                    else
                    {
                        ext1.X = (int)(milieu.X - (long)(fDim2 * Math.Sqrt(3) * fCosa / 2.0));
                        ext2.X = (int)(milieu.X + (long)(fDim2 * Math.Sqrt(3) * fCosa / 2.0));
                    }
                    if (ptPrecedent.Y < milieu.Y)
                    {
                        ext1.Y = (int)(milieu.Y + (long)(fDim2 * Math.Sqrt(3) * fSina / 2.0));
                        ext2.Y = (int)(milieu.Y - (long)(fDim2 * Math.Sqrt(3) * fSina / 2.0));
                    }

                    else
                    {
                        ext1.Y = (int)(milieu.Y - (long)(fDim2 * Math.Sqrt(3) * fSina / 2.0));
                        ext2.Y = (int)(milieu.Y + (long)(fDim2 * Math.Sqrt(3) * fSina / 2.0));
                    }
                    DrawFleche(ctx,pen, ptPrecedent, ptSuivant,ext1);
                    DrawFleche(ctx,pen, ptSuivant, ptPrecedent, ext2);

                    break;
                }


            }

        }


        //dessine une flèche sur un segment en connaissant les extrémités du segment et la position de l'extrémité de la flèche
        //La flèche se dessine dans le sens pt1 ->pt2
        private void DrawFleche(sc2i.drawing.CContextDessinObjetGraphique ctx, Pen pen,Point pt1, Point pt2, Point extremite)
        {
           
            double fCosa = (double)Math.Abs(pt1.X - extremite.X) / (double)(Math.Sqrt((pt1.X - extremite.X) * (pt1.X - extremite.X) + (pt1.Y - extremite.Y) * (pt1.Y - extremite.Y)));
            double fSina = (double)Math.Abs(pt1.Y - extremite.Y) / (double)(Math.Sqrt((pt1.X - extremite.X) * (pt1.X - extremite.X) + (pt1.Y - extremite.Y) * (pt1.Y - extremite.Y)));
            Point m = new Point(0, 0);
          

            double fDim = 12.0;
            Point[] p = new Point[2];
            p[0] = new Point(0, 0);
            p[1] = new Point(0, 0);
            //flèche vers la gauche
            if (pt1.X > extremite.X) 
            {
                m.X = (int)(extremite.X + (long)(fDim * Math.Sqrt(3) * fCosa / 2.0));
                p[0].X = (int)(m.X + (long)(fDim * fSina / 2.0));
                p[1].X = (int)(m.X - (long)(fDim * fSina / 2.0));
            }
            //flèche vers la droite
            else if (pt1.X <= extremite.X) 
            {
                m.X = (int)(extremite.X - (long)(fDim * Math.Sqrt(3) * fCosa / 2.0));
                p[0].X = (int)(m.X - (long)(fDim * fSina / 2.0));
                p[1].X = (int)(m.X + (long)(fDim * fSina / 2.0));
            }
            //flèche vers le bas
            if (pt1.Y > extremite.Y)
            {
                m.Y = (int)(extremite.Y + (long)(fDim * Math.Sqrt(3) * fSina / 2.0));
                p[0].Y = (int)(m.Y - (long)(fDim * fCosa / 2.0));
                p[1].Y = (int)(m.Y + (long)(fDim * fCosa / 2.0));
            }
            //flèche vers le haut
            else if (pt1.Y <= extremite.Y)
            {
                m.Y = (int)(extremite.Y - (long)(fDim * Math.Sqrt(3) * fSina / 2.0));
                p[0].Y = (int)(m.Y + (long)(fDim * fCosa / 2.0));
                p[1].Y = (int)(m.Y - (long)(fDim * fCosa / 2.0));
            }

            ctx.Graphic.DrawLine(pen, extremite.X, extremite.Y, p[0].X, p[0].Y);
            ctx.Graphic.DrawLine(pen, extremite.X, extremite.Y, p[1].X, p[1].Y);

        }



        private int GetNumVersion()
        {
            return 1;
        }

        public override Point GetCenterPoint()
        {
            if (Points.Length < 2)
                return base.GetCenterPoint();
            if (Points.Length % 2 == 1)
                return Points[Points.Length / 2] ;
            Point pt1 = Points[Points.Length / 2-1];
            Point pt2 = Points[Points.Length / 2];
            return new Point((pt1.X + pt2.X) / 2, (pt1.Y + pt2.Y) / 2);
        }


    }
}
