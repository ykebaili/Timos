using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.data;

namespace timos.data.vuephysique
{
    public interface IElementAVuePhysique : IObjetDonneeAIdNumerique
    {
        CVuePhysique VuePhysique {get;}

        CVuePhysique GetVuePhysiqueAvecCreation();
    }
}
