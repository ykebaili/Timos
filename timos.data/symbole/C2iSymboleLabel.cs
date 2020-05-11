using System;
using System.Drawing;
using System.IO;


using sc2i.common;
using sc2i.drawing;
using sc2i.formulaire;
using System.Drawing.Drawing2D;



namespace timos.data
{
    /// <summary>
    /// Description résumée de C2iSymboleLabel.
    /// </summary>
    /// 
    [WndName("Label")]
    [Serializable]
    [VisibleInInterfaceAttribute]
    public class C2iSymboleLabel : C2iSymbole
    {

        public enum LabelBorderStyle
        {
            None,
            Border
        }

       
        private ContentAlignment m_alignement = ContentAlignment.MiddleLeft;
        private Font m_font = null;
        private string m_strTexte = "Texte";
        private LabelBorderStyle m_borderStyle = LabelBorderStyle.None;
        /// ///////////////////////
        public C2iSymboleLabel()
        {
            Size = new Size(64, 16);
            BackColor = System.Drawing.Color.Transparent;
            m_font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
        }


        /// ///////////////////////
        public string Text
        {
            get
            {
                return m_strTexte;
            }
            set
            {
                m_strTexte = value;
            }
        }

        /// ///////////////////////
        public LabelBorderStyle BorderStyle
        {
            get
            {
                return m_borderStyle;
            }
            set
            {
                m_borderStyle = value;
            }
        }

        /// ///////////////////////
        public ContentAlignment TextAlign
        {
            get
            {
                return m_alignement;
            }
            set
            {
                m_alignement = value;
            }
        }


        public Font Font
        {
            get
            {

                return m_font;
            }
            set
            {
                m_font = value;
            }
        }
        /// ///////////////////////
        [System.ComponentModel.Browsable(false)]
        protected override Point OrigineCliente
        {
            get
            {
                if (BorderStyle == LabelBorderStyle.None)
                    return new Point(0, 0);
                else
                    return new Point(1, 1);
            }
        }

        /// ///////////////////////////////////////
        [System.ComponentModel.Browsable(false)]
        protected override Size ClientSize
        {
            get
            {
                Size sz = Size;
                if (BorderStyle != LabelBorderStyle.None)
                {
                    sz.Width -= 2;
                    sz.Height -= 2;
                }
                return sz;
            }
        }


        /// ///////////////////////
        protected override void MyDraw(CContextDessinObjetGraphique ctx)
        {
            Graphics g = ctx.Graphic;
            Brush b = new SolidBrush(BackColor);
            Rectangle rect = new Rectangle(Position, Size);
            g.FillRectangle(b, rect);
            b.Dispose();
            DrawCadre(g);
            base.MyDraw(ctx);
        }

        /// ///////////////////////
        public override void DrawInterieur(CContextDessinObjetGraphique ctx)
        {
            Graphics g = ctx.Graphic;
            if (Font == null)
                return;
            if (Text == "")
                return;

            Brush br = new SolidBrush(ForeColor);
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Near;
            format.Alignment = StringAlignment.Near;

            switch (TextAlign)
            {
                case ContentAlignment.BottomCenter:
                case ContentAlignment.BottomLeft:
                case ContentAlignment.BottomRight:
                    format.LineAlignment = StringAlignment.Far;
                    break;
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.MiddleRight:
                    format.LineAlignment = StringAlignment.Center;
                    break;
            }
            switch (TextAlign)
            {
                case ContentAlignment.BottomCenter:
                case ContentAlignment.MiddleCenter:
                case ContentAlignment.TopCenter:
                    format.Alignment = StringAlignment.Center;
                    break;
                case ContentAlignment.BottomRight:
                case ContentAlignment.MiddleRight:
                case ContentAlignment.TopRight:
                    format.Alignment = StringAlignment.Far;
                    break;
            }
            g.DrawString(Text, Font, br, ClientRect, format);
            br.Dispose();
        }

        /// /////////////////////////////////////////////////
        protected void DrawCadre(Graphics g)
        {
            if (BorderStyle == LabelBorderStyle.None)
                return;
            Rectangle rect = new Rectangle(Position.X, Position.Y, Size.Width, Size.Height);
            //rect = contexte.ConvertToAbsolute(rect);
            if (BorderStyle == LabelBorderStyle.Border)
            {
                Pen pen = new Pen(ForeColor);
                g.DrawRectangle(pen, rect);
                pen.Dispose();
            }

        }

        /// ///////////////////////////////////////
        private int GetNumVersion()
        {
            return 0;
        }

        /// ///////////////////////////////////////
        protected override CResultAErreur MySerialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            serializer.TraiteString(ref m_strTexte);

            int nTmp = (int)m_alignement;
            serializer.TraiteInt(ref nTmp);
            m_alignement = (ContentAlignment)nTmp;

            nTmp = (int)m_borderStyle;
            serializer.TraiteInt(ref nTmp);
            m_borderStyle = (LabelBorderStyle)nTmp;


            result = SerializeFont(serializer, ref m_font);
            if (!result)
                return result;


            return result;
        }



        public static CResultAErreur SerializeFont(C2iSerializer serializer, ref Font ft)
        {
            CResultAErreur result = CResultAErreur.True;
            bool bHasFont = ft != null;
            serializer.TraiteBool(ref bHasFont);
            if (bHasFont)
            {
                if (serializer.Mode == ModeSerialisation.Lecture)
                    ft = new Font("Arial", 1, FontStyle.Regular);

                Byte gdiCharset = ft.GdiCharSet;
                bool gdiVerticalFont = ft.GdiVerticalFont;
                int nUnit = (int)ft.Unit;
                string strName = ft.Name;
                double fSize = ft.Size;
                int nStyle = (int)ft.Style;
                serializer.TraiteByte(ref gdiCharset);
                serializer.TraiteBool(ref gdiVerticalFont);
                serializer.TraiteString(ref strName);
                serializer.TraiteDouble(ref fSize);
                serializer.TraiteInt(ref nStyle);
                serializer.TraiteInt(ref nUnit);
                if (serializer.Mode == ModeSerialisation.Lecture)
                    ft = new Font(strName, (float)fSize, (FontStyle)nStyle, (GraphicsUnit)nUnit, gdiCharset, gdiVerticalFont);
            }
            return result;
        }
    }
}
