using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace timos.data.projet
{
    /// <summary>
    /// Indique comment sont recalculées les dates de projet en cas de changemment
    /// </summary>
    /// <remarks>
    /// Automatic : on ne s'occupe de rien, le projet se recalcule tout seul au fil de l'eau
    /// Suspended : Les dates ne se recalculent pas automatiquement, mais elles seront recalculées à la sauvegarde du projet
    /// Inactive : Les dates ne se recalculent pas automatiquement, ni à la sauvegarde du projet. A utiliser en connaissance de cause !
    /// </remarks>
    public enum EModeCalculDatesProjet
    {
        Automatic = 0,
        Suspended = 1,
        Inactive = 2
    }


    public class CModeCalculDatesProjet : CEnumALibelle<EModeCalculDatesProjet>
    {
        public CModeCalculDatesProjet(EModeCalculDatesProjet mode)
            : base(mode)
        {
        }

        public override string Libelle
        {
            get
            {
                return Code.ToString();
            }
        }
    }
}
