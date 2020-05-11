using System;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.data.dynamic;
using timos.securite;
using sc2i.data.dynamic.loader;

namespace timos.data.serveur
{
    public class CRelationLienReseau_ChampCustomServeur : CRelationElementAChamp_ChampCustomServeur
    {

        	//-------------------------------------------------------------------
		public CRelationLienReseau_ChampCustomServeur( int nIdSession )
			:base(nIdSession)
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationLienReseau_ChampCustom.c_nomTable;
		}
		
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CRelationLienReseau_ChampCustom);
		}
		//-------------------------------------------------------------------
	}

    
}
