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
    /// Description résumée de CRelationTypeRessource_ChampCustomValeurServeur.
    /// </summary>
    public class CRelationTypeRessource_ChampCustomValeurServeur : CRelationElementAChamp_ChampCustomServeur
    {

        //-------------------------------------------------------------------
        public CRelationTypeRessource_ChampCustomValeurServeur(int nIdSession)
            : base(nIdSession)
        {
        }

        //-------------------------------------------------------------------
        public override string GetNomTable()
        {
            return CRelationTypeRessource_ChampCustomValeur.c_nomTable;
        }

        //-------------------------------------------------------------------
        public override Type GetTypeObjets()
        {
            return typeof(CRelationTypeRessource_ChampCustomValeur);
        }

    }
}
