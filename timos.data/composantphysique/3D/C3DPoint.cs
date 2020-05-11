using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace timos.data.composantphysique
{
    [Serializable]
    public struct C3DPoint : I2iSerializable
    {
        private int m_nX;
        private int m_nY;
        private int m_nZ;

        public C3DPoint(int nX, int nY, int nZ)
        {
            m_nX = nX;
            m_nY = nY;
            m_nZ = nZ;
        }

        public int X
        {
            get
            {
                return m_nX;
            }
        }

        public int Y
        {
            get
            {
                return m_nY;
            }
        }

        public int Z
        {
            get
            {
                return m_nZ;
            }
        }

        public void Offset(int nX, int nY, int nZ)
        {
            m_nX += nX;
            m_nY += nY;
            m_nZ += nZ;
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
            serializer.TraiteInt(ref m_nX);
            serializer.TraiteInt(ref m_nY);
            serializer.TraiteInt(ref m_nZ);

            return result;
        }

        public override string ToString()
        {
            return m_nX + "," + m_nY + "," + m_nZ;
        }
        

    }
}
