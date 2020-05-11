using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.data;

namespace timos.data.coordonnees
{
    public static class COptionCoordonnéeGlobale
    {
        public static EOptionControleCoordonnees GetOptionType(int nIdSession, Type tpObjet)
        {
            if (tpObjet == typeof(CTypeSite))
                tpObjet = typeof(CSite);
            if ( tpObjet == typeof(CTypeEquipement ))
                tpObjet = typeof(CEquipement );
            long nVal = new CDataBaseRegistrePourClient(nIdSession).GetValeurLong("COORD_"+tpObjet.ToString(), (long)EOptionControleCoordonnees.IgnorerLesFilsSansCoordonnees);
            return (EOptionControleCoordonnees)nVal;
        }

        public static void SetOptionType(int nIdSession, Type tpObjet, EOptionControleCoordonnees option)
        {
            new CDataBaseRegistrePourClient(nIdSession).SetValeur("COORD_"+tpObjet.ToString(), ((long)option).ToString());
        }
    }
}
