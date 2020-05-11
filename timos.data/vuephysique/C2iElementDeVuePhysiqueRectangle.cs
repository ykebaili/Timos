using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.drawing;
using sc2i.common;
using sc2i.formulaire;

namespace timos.data.vuephysique
{
    [WndName("Rectangle")]
    [Serializable]
    [VisibleInInterface]
    public class C2iElementDeVuePhysiqueRectangle : C2iElementDeVuePhysiqueDessinBase
    {
        
        //--------------------------------------------------------------------
        protected override void MyDraw(sc2i.drawing.CContextDessinObjetGraphique ctx)
        {
            throw new NotImplementedException();
        }
        
        //--------------------------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //--------------------------------------------------------------------
        protected override CResultAErreur MySerialize(sc2i.common.C2iSerializer serializer)
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
