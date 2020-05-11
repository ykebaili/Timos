using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

using sc2i.common;
using sc2i.drawing;
using sc2i.formulaire;

namespace timos.data
{
    [WndName("Triangle")]
    [Serializable]
    [VisibleInInterfaceAttribute]
    public class C2iSymboleTriangle : C2iSymboleForme
    {

    
        public enum EdgePositionValue
        {
            Top,
            Bottom,
            Left,
            Right
        }
        private EdgePositionValue m_edge = EdgePositionValue.Top;


        public C2iSymboleTriangle()
        {
        
        }
    

        public EdgePositionValue EdgePosition
        {
            get
            {
                return m_edge;

            }
            set
            {
                m_edge = value;

            }

        }


        /// ///////////////////////
        protected override void MyDraw(CContextDessinObjetGraphique ctx)
        {
            Graphics g = ctx.Graphic;
            Brush b;
            if (m_hatchStyle != null)
                b = new System.Drawing.Drawing2D.HatchBrush(m_hatchStyle.Value, ForeColor, BackColor);
            else
                b = new SolidBrush(BackColor);
            Rectangle rect = new Rectangle(Position, Size);
            //rect = contexte.ConvertToAbsolute(rect);
            Point[] P = new Point[3];

            switch(m_edge)
            {
                case EdgePositionValue.Top:
                    {
                        P[0].X = Position.X + (Size.Width / 2);
                        P[0].Y = Position.Y;
                        P[1].X = Position.X; 
                        P[1].Y = Position.Y+ Size.Height;
                        P[2].X = Position.X + Size.Width;
                        P[2].Y = Position.Y + Size.Height;
                        break;
                    }
                case EdgePositionValue .Bottom :
                    {
                        P[0].X = Position.X;
                        P[0].Y = Position.Y;
                        P[1].X = Position.X + Size.Width;
                        P[1].Y = Position.Y;
                        P[2].X = Position.X + (Size.Width / 2);
                        P[2].Y = Position.Y + Size.Height;
                        break;
                    }

                case EdgePositionValue.Left :
                    {
                        P[0].X = Position.X;
                        P[0].Y = Position.Y + (Size.Height / 2);
                        P[1].X = Position.X + Size.Width;
                        P[1].Y = Position.Y;
                        P[2].X = Position.X + Size.Width;
                        P[2].Y = Position.Y + Size.Height;
                        break;
                    }
                case EdgePositionValue.Right :
                    {
                        P[0].X = Position.X;
                        P[0].Y = Position.Y;
                        P[1].X = Position.X;
                        P[1].Y = Position.Y+ Size.Height;
                        P[2].X = Position.X + Size.Width;
                        P[2].Y = Position.Y + (Size.Height /2);
                        break;
                    }

            }

            g.FillPolygon(b, P);  
          
            b.Dispose();
            DrawCadre(g,P);
            base.MyDraw(ctx);
        }

        /// /////////////////////////////////////////////////
        protected void DrawCadre(Graphics g,Point []P)
        {
            Rectangle rect = new Rectangle(Position, Size);
            if ((BorderStyle == PanelBorderStyle.None) || (BorderWidth <= 0))
            {

                return;
            }

            if (BorderStyle == PanelBorderStyle.Border)
            {
                Pen pen = new Pen(ForeColor);
                pen.Width = BorderWidth;
                pen.DashStyle = m_lineStyle;
                if (m_lineStyle == System.Drawing.Drawing2D.DashStyle.Custom)
                    pen.DashPattern = m_customDashPattern;
                g.DrawPolygon(pen, P);

              
                pen.Dispose();
            }
       
        }


        public override void HorizontalFlip()
        {
            if (m_edge == EdgePositionValue.Left)
                m_edge = EdgePositionValue.Right;
            else if (m_edge == EdgePositionValue.Right)
                m_edge = EdgePositionValue.Left;
            base.HorizontalFlip();
        }
        public override void VerticalFlip()
        {
            if (m_edge == EdgePositionValue.Bottom)
                m_edge = EdgePositionValue.Top;
            else if (m_edge == EdgePositionValue.Top)
                m_edge = EdgePositionValue.Bottom;
            base.VerticalFlip();
        }

        /// ///////////////////////////////////////
        private int GetNumVersion()
        {
            return 3;
        }

        /// ///////////////////////////////////////
        protected override CResultAErreur MySerialize(C2iSerializer serializer)
        {
            //return CResultAErreur.True;
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;

            result = base.MySerialize(serializer);
            if (!result)
                return result;
            int nTmp;
            if (nVersion <= 2)
            {
                nTmp = m_gridSize.Width;
                serializer.TraiteInt(ref nTmp);
                m_gridSize.Width = nTmp;

                nTmp = m_gridSize.Height;
                serializer.TraiteInt(ref nTmp);
                m_gridSize.Height = nTmp;

                int nStyle = (int)m_borderStyle;
                serializer.TraiteInt(ref nStyle);
                m_borderStyle = (PanelBorderStyle)nStyle;
         
                serializer.TraiteInt(ref m_borderWidth);
                
            }
            if (nVersion == 2)
            {
                int nLineStyle = (int)m_lineStyle;
                serializer.TraiteInt(ref nLineStyle);
                m_lineStyle = (System.Drawing.Drawing2D.DashStyle)nLineStyle;
              
            }

            int nEdge = (int)m_edge;
            serializer.TraiteInt(ref nEdge);
            m_edge = (EdgePositionValue)nEdge;


            return result;
        }


    }
}
