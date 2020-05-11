using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using sc2i.common;

namespace timos.data.composantphysique
{
    public class CGraduateCoordinate : CEmplacementDansParent
    {
        private int m_nPosition = 0;

        public CGraduateCoordinate()
        { }

        public CGraduateCoordinate(C2iComposant3D composant)
            : base(composant)
        {
        }

        public int Position
        {
            get
            {
                return m_nPosition;
            }
            set
            {
                m_nPosition = value;
                IConteneurGradue conteneur = ComposantAssocie != null ? ComposantAssocie.Parent as IConteneurGradue : null;
                if (conteneur != null)
                    conteneur.AjustePosition(ComposantAssocie, value);                
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
            serializer.TraiteInt(ref m_nPosition);
            return result;
        }

    }
}
