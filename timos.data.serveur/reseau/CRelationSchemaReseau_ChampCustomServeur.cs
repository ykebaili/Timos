using System;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.data.dynamic;
using timos.securite;
using sc2i.data.dynamic.loader;
using timos.data;

namespace timos.data.serveur
{
    public class CRelationSchemaReseau_ChampCustomServeur : CRelationElementAChamp_ChampCustomServeur
    {

        //-------------------------------------------------------------------
        public CRelationSchemaReseau_ChampCustomServeur(int nIdSession)
            : base(nIdSession)
        {
        }
        //-------------------------------------------------------------------
        public override string GetNomTable()
        {
            return CRelationSchemaReseau_ChampCustom.c_nomTable;
        }

        //-------------------------------------------------------------------
        public override Type GetTypeObjets()
        {
            return typeof(CRelationSchemaReseau_ChampCustom);
        }
        //-------------------------------------------------------------------
    }


}
