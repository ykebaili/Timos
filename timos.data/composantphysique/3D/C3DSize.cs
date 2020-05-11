using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using System.Drawing;

namespace timos.data.composantphysique
{
    [Serializable]
    public struct C3DSize : I2iSerializable
    {
        private int m_nWidth;
        private int m_nHeight;
        private int m_nDepth;

        public C3DSize(int nWidth, int nHeight, int nDepth)
        {
            m_nDepth = nDepth;
            m_nWidth = nWidth;
            m_nHeight = nHeight;
        }

        public int With
        {
            get
            {
                return m_nWidth;
            }
        }

        public int Height
        {
            get
            {
                return m_nHeight;
            }
       }

        public int Depth
        {
            get
            {
                return m_nDepth;
            }
        }

        public void Inflate(int nX, int nY, int nZ)
        {
            m_nWidth += nX;
            m_nHeight += nY;
            m_nDepth += nZ;
        }

        private int GetNumVersion()
        {
            return 0;
        }

        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            serializer.TraiteInt(ref m_nWidth);
            serializer.TraiteInt(ref m_nHeight);
            serializer.TraiteInt(ref m_nDepth);
            return result;
        }

        public Size GetSize2D(EFaceVueDynamique face)
        {
            switch (face)
            {
                default :
                case EFaceVueDynamique.Rear:
                case EFaceVueDynamique.Front:
                    return new Size(With, Height);
                case EFaceVueDynamique.Right:
                case EFaceVueDynamique.Left:
                    return new Size(Depth, Height);
                case EFaceVueDynamique.Bottom:
                case EFaceVueDynamique.Top:
                    return new Size(With, Depth);
            }
        }

        public override string ToString()
        {
            return m_nWidth + "," + m_nHeight + "," + m_nDepth;
        }



    }
}
