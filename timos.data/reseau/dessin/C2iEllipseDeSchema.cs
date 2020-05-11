using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;


using sc2i.common;
using sc2i.drawing;
using sc2i.formulaire;

namespace timos.data
{
    [WndName("Ellipse")]
    [Serializable]
    [VisibleInInterfaceAttribute]
    public class C2iEllipseDeSchema : C2iFormDeSchema
    {
        public C2iEllipseDeSchema()
            : base()
        {
        }

        public C2iEllipseDeSchema(int nIdContexteDonnee)
            :base ( nIdContexteDonnee )
        {

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
            g.FillEllipse(b, rect);
            b.Dispose();
            DrawCadre(g);
            base.MyDraw(ctx);
        }

        /// /////////////////////////////////////////////////
        protected void DrawCadre(Graphics g)
        {
            Rectangle rect = new Rectangle(Position, Size);
            if (BorderStyle == PanelBorderStyle.None)
            {

                return;
            }

            if (BorderStyle == PanelBorderStyle.Border)
            {
                Pen pen = new Pen(ForeColor);
                pen.DashStyle = m_lineStyle;
                pen.Width = BorderWidth;
                if (m_lineStyle == System.Drawing.Drawing2D.DashStyle.Custom)
                    pen.DashPattern = m_customDashPattern;
                g.DrawEllipse(pen, rect);


                pen.Dispose();
            }

        }

        /// ///////////////////////////////////////
        private int GetNumVersion()
        {
            return 3;
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

            return result;
        }

    }
}


