using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.formulaire;
using sc2i.custom;
using sc2i.expression;

namespace timos.Controles.ActionsSurLink
{
    public interface IControlEditeurSpecifiqueMenuItem : IDisposable
    {
        void InitChamps(IMenuItem menuItem, CObjetPourSousProprietes objetPourSousProprietes);
        CResultAErreur MajChamps();
        IMenuItem MenuItemEdite { get; }

    }
}
