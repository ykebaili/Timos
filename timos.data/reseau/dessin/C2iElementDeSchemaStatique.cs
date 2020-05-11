using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

using sc2i.common;
using sc2i.drawing;


namespace timos.data
{
    [Serializable]
    public class C2iElementDeSchemaStatique : C2iObjetDeSchema, IDonneeDessinElementDeSchemaReseau
    {
        private int m_nIdContexteDonnee = -1;

        private int m_nIdObjetDeSchemaReseau = -1;

        private Color m_backColor = Color.Transparent;
        private Color m_foreColor = Color.Black;

        public C2iElementDeSchemaStatique()
            : base()
        {
            m_nIdObjetDeSchemaReseau = -1;
            Size = new Size(64, 16);
            BackColor = Color.White;
        }

        public C2iElementDeSchemaStatique(int nIdContexteDonnee)
            : base()
        {
            Size = new Size(64, 16);
            BackColor = Color.White;
            m_nIdContexteDonnee = nIdContexteDonnee;
        }

        public int IdContexteDonnee
        {
            get
            {
                return m_nIdContexteDonnee;
            }
        }

        

        public virtual bool ShouldSaveInBlob
        {
            get
            {
                return false;
            }
        }

        public override int  IdObjetDeSchema
        {
            get
            {
                return m_nIdObjetDeSchemaReseau;
            }
            set
            {
                m_nIdObjetDeSchemaReseau = value;
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

        public Color ForeColor
        {
            get
            {
                return m_foreColor;
            }
            set
            {
                m_foreColor = value;
            }
        }

        public override bool AcceptChilds
        {
            get
            {
                return false;
            }
        }

        private int GetNumVersion()
        {
            return 0;
        }


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

            int nColor = BackColor.ToArgb();
            serializer.TraiteInt(ref nColor);
            BackColor = Color.FromArgb(nColor);

            nColor = ForeColor.ToArgb();
            serializer.TraiteInt(ref nColor);
            ForeColor = Color.FromArgb(nColor);
            return result;
        }

        protected override IDonneeDessinElementDeSchemaReseau AlloueDonneeDessin()
        {
            return this;
        }

        public int Transparency
        {
            get
            {
                double fVal = 255.0 - BackColor.A;
                fVal /= 2.55;
                return (int)Math.Round(fVal);
            }
            set
            {
                int nVal = Math.Max(0, value);
                nVal = Math.Min(value, 100);
                double fFacteur = 100 - nVal;
                fFacteur *= 2.55;
                BackColor = Color.FromArgb((int)Math.Round(fFacteur), BackColor);
            }
        }

       

    }
}
