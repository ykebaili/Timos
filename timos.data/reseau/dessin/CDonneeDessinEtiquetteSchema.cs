using System;
using System.Drawing;

using System.Drawing.Design;
using System.Drawing.Drawing2D;

using sc2i.common;
using sc2i.drawing;
using sc2i.formulaire;

using sc2i.expression;

namespace timos.data
{
    public class CDonneeDessinEtiquetteSchema : CDonneeDessinElementDeSchemaReseau
    {


        private int m_nBorderWidth = 1;

        private Color m_textColor = Color.Black;

        private Color m_borderColor = Color.Black;

        private Color m_backColor = Color.White;

        private Font m_font = null;

        private ContentAlignment m_alignement = ContentAlignment.MiddleLeft;

        private ELabelBorderStyle m_borderStyle = ELabelBorderStyle.Border;

        private bool m_bDrawLine = true;

        private C2iExpression m_expression;

        private int m_IdObjetAssocie;

        public CDonneeDessinEtiquetteSchema(int nIdContexteDonnee)
            : base(nIdContexteDonnee)
        {
        }

        public Color BorderColor
        {
            get
            {
                return m_borderColor;
            }

            set
            {
                m_borderColor = value;
            }

        }

        public bool DrawLine
        {
            get
            {
                return m_bDrawLine;
            }
            set
            {
                m_bDrawLine = value;
            }
        }


        public Color BackColor
        {
            get
            {
                return m_backColor;
            }

            set
            {
                m_backColor = value;
            }

        }


        public Color TextColor
        {
            get
            {
                return m_textColor;
            }

            set
            {
                m_textColor = value;
            }

        }



        public ELabelBorderStyle BorderStyle
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

        public int BorderWidth
        {
            get
            {
                return m_nBorderWidth;
            }

            set
            {
                m_nBorderWidth = value;
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



        public C2iExpression Formula
        {
            get
            {
                return m_expression;
            }
            set
            {
                m_expression = value;
            }

        }

           


        public int IdObjetAssocie
        {
            get
            {
                return m_IdObjetAssocie;
            }

            set
            {
                m_IdObjetAssocie = value;
            }
        }

        


        public virtual int GetNumVersion()
        {
            return 3;
            //3 : Ajout de DrawLine
        }


        

        public override CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;


            result = base.Serialize(serializer);
            if (!result)
                return result;


            serializer.TraiteInt(ref m_nBorderWidth);

            int nTmp;

            nTmp = (int)m_borderStyle;
            serializer.TraiteInt(ref nTmp);
            m_borderStyle = (ELabelBorderStyle)nTmp;


            result = SerializeFont(serializer, ref m_font);
            if (!result)
                return result;


            nTmp = m_backColor.ToArgb();
            serializer.TraiteInt(ref nTmp);
            m_backColor = Color.FromArgb(nTmp);

            nTmp = m_textColor.ToArgb();
            serializer.TraiteInt(ref nTmp);
            m_textColor = Color.FromArgb(nTmp);

            nTmp = m_borderColor.ToArgb();
            serializer.TraiteInt(ref nTmp);
            m_borderColor = Color.FromArgb(nTmp);


            serializer.TraiteInt(ref m_IdObjetAssocie);

            I2iSerializable objet = m_expression;
            result = serializer.TraiteObject(ref objet);
            if (!result)
                return result;
            m_expression = (C2iExpression)objet;

            if (nVersion > 1)
            {
                nTmp = (int)m_alignement;
                serializer.TraiteInt(ref nTmp);
                m_alignement = (ContentAlignment)nTmp;
            }

            if (nVersion >= 3)
                serializer.TraiteBool(ref m_bDrawLine);

            return CResultAErreur.True;
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

    public enum ELabelBorderStyle
    {
        None,
        Border
    }

}
