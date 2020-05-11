using System;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.data.dynamic;
using sc2i.data.dynamic.loader;

namespace timos.data
{
	/// <summary>
	/// Description résumée de CRelationEquipementLogique_ChampCustomValeurServeur.
	/// </summary>
	public class CRelationTypeEquipementLogique_ChampCustomValeurServeur : CRelationElementAChamp_ChampCustomServeur
	{
		//-------------------------------------------------------------------
		//-------------------------------------------------------------------
		public CRelationTypeEquipementLogique_ChampCustomValeurServeur( int nIdSession )
			:base(nIdSession)
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationTypeEquipementLogique_ChampCustomValeur.c_nomTable;
		}
		
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CRelationTypeEquipementLogique_ChampCustomValeur);
		}
		//-------------------------------------------------------------------
	}
}
