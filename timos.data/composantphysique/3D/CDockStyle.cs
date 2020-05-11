using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace timos.data.composantphysique
{
    public class CDockStyle : CEmplacementDansParent
    {
        private E3DDockStyle m_dockStyle = E3DDockStyle.None;

        public CDockStyle()
        {
        }

        public CDockStyle(C2iComposant3D composant)
            : base(composant)
        { }

        public E3DDockStyle DockStyle
        {
            get
            {
                return m_dockStyle;
            }
            set
            {
                m_dockStyle = value;
                OnChangeValeur();
            }
        }

        private int GetNumVersion()
        {
            return 0;
        }

        public override CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            int nTmp = (int)m_dockStyle;
            serializer.TraiteInt(ref nTmp);
            m_dockStyle = (E3DDockStyle)nTmp;

            return result;
        }


    }
}
