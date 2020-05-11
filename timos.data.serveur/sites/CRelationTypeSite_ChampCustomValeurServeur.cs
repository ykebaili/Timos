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
    /// Description r�sum�e de CRelationTypeSite_ChampCustomValeurServeur.
    /// </summary>
    public class CRelationTypeSite_ChampCustomValeurServeur : CRelationElementAChamp_ChampCustomServeur
    {

        //-------------------------------------------------------------------
        public CRelationTypeSite_ChampCustomValeurServeur(int nIdSession)
            : base(nIdSession)
        {
        }

        //-------------------------------------------------------------------
        public override string GetNomTable()
        {
            return CRelationTypeSite_ChampCustomValeur.c_nomTable;
        }

        //-------------------------------------------------------------------
        public override Type GetTypeObjets()
        {
            return typeof(CRelationTypeSite_ChampCustomValeur);
        }

    }
}
