using System;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.data.dynamic;
using sc2i.data.dynamic.loader;
using timos.acteurs;

using timos.data;

namespace timos.data.serveur
{
    public class CRelationTypeSchemaReseau_ChampCustomServeur : CObjetServeur
    {

        //-------------------------------------------------------------------
        public CRelationTypeSchemaReseau_ChampCustomServeur(int nIdSession)
            : base(nIdSession)
        {
        }
        //-------------------------------------------------------------------
        public override string GetNomTable()
        {
            return CRelationTypeSchemaReseau_ChampCustom.c_nomTable;
        }
        //-------------------------------------------------------------------
        public override Type GetTypeObjets()
        {
            return typeof(CRelationTypeSchemaReseau_ChampCustom);
        }

        //-------------------------------------------------------------------
        public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
        {
            CResultAErreur result = CResultAErreur.True;
            return result;
        }
    }
}
