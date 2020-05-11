using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using System.Drawing;

namespace timos.data.composantphysique
{
    [Serializable]
    public class C3DPrimitiveCube : I3DPrimitive, I2iSerializable
    {
        private C3DPoint m_position;
        private C3DSize m_size;
        private Color m_couleur = Color.Orange;

        //--------------------------------------------------
        public C3DPrimitiveCube(C3DPoint position, C3DSize size, Color couleur)
        {
            m_position = position;
            m_size = size;
            m_couleur = couleur;
        }

        //--------------------------------------------------
        public Color Couleur
        {
            get
            {
                return m_couleur;
            }
        }

        //--------------------------------------------------
        public bool IsTransparente
        {
            get
            {
                return Couleur.A < 253;
            }
        }

        //--------------------------------------------------
        public C3DPoint Position
        {
            get
            {
                return m_position;
            }
            set
            {
                m_position = value;
            }
        }

        //--------------------------------------------------
        public C3DSize Size
        {
            get
            {
                return m_size;
            }
            set
            {
                m_size = value;
            }
        }

        //--------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //--------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (result)
                result = serializer.TraiteObject<C3DPoint>(ref m_position);
            if (result)
                result = serializer.TraiteObject<C3DSize>(ref m_size);
            if (result)
            {
                int nTmp = m_couleur.ToArgb();
                serializer.TraiteInt(ref nTmp);
                m_couleur = Color.FromArgb(nTmp);
            }
            return result;
        }
    }
}
