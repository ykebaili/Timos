using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.formulaire;
using sc2i.common;
using sc2i.expression;

namespace timos.Controles.ActionsSurLink
{
    public interface IEditeurUneActionSur2iLink : IDisposable
    {
        void InitChamps ( CActionSur2iLink action, CObjetPourSousProprietes objetPourSousProprietes );

        CResultAErreur MajChamps();


    }
}
