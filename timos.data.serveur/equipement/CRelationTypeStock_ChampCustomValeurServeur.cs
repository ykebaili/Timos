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
    /// Description résumée de CRelationTypeStock_ChampCustomValeurServeur.
    /// </summary>
    public class CRelationTypeStock_ChampCustomValeurServeur : CRelationElementAChamp_ChampCustomServeur
    {

        //-------------------------------------------------------------------
        public CRelationTypeStock_ChampCustomValeurServeur(int nIdSession)
            : base(nIdSession)
        {
        }

        //-------------------------------------------------------------------
        public override string GetNomTable()
        {
            return CRelationTypeStock_ChampCustomValeur.c_nomTable;
        }

        //-------------------------------------------------------------------
        public override Type GetTypeObjets()
        {
            return typeof(CRelationTypeStock_ChampCustomValeur);
        }

    }
}
