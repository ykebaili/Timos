using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.drawing;
using sc2i.common;

namespace timos.data.vuephysique
{
    public abstract class C2iElementDeVuePhysique : C2iObjetGraphique
    {
        public C2iElementDeVuePhysique()
            : base()
        {
        }

        private int GetNumVersion()
        {
            return 0;
        }

        protected override CResultAErreur MySerialize(sc2i.common.C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            return result;
        }
 
    }
}
