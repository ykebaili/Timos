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
    public class CRelationTypeLienReseau_ChampCustomServeur : CObjetServeur
    {

        	//-------------------------------------------------------------------
        public CRelationTypeLienReseau_ChampCustomServeur(int nIdSession)
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
            return CRelationTypeLienReseau_ChampCustom.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
            return typeof(CRelationTypeLienReseau_ChampCustom);
		}
		
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
		{
			CResultAErreur result = CResultAErreur.True;
			return result;
		}
    }
}
