using System;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.data.dynamic;
using sc2i.data.dynamic.loader;

using timos.data;

namespace timos.data.serveur
{
    /// <summary>
    /// Description résumée de CRelationTypeTableParametrable_ChampCustomValeurServeur.
    /// </summary>
    public class CRelationTypeTableParametrable_ChampCustomValeurServeur : CRelationElementAChamp_ChampCustomServeur
    {

        //-------------------------------------------------------------------
        public CRelationTypeTableParametrable_ChampCustomValeurServeur(int nIdSession)
            : base(nIdSession)
        {
        }

        //-------------------------------------------------------------------
        public override string GetNomTable()
        {
            return CRelationTypeTableParametrable_ChampCustomValeur.c_nomTable;
        }

        //-------------------------------------------------------------------
        public override Type GetTypeObjets()
        {
            return typeof(CRelationTypeTableParametrable_ChampCustomValeur);
        }

    }
}
