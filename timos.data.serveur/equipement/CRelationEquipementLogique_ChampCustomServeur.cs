using System;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.data.dynamic;
using sc2i.data.dynamic.loader;

namespace timos.data
{
	/// <summary>
	/// Description résumée de CRelationEquipementLogique_ChampCustomServeur.
	/// </summary>
	public class CRelationEquipementLogique_ChampCustomServeur : CRelationElementAChamp_ChampCustomServeur
	{
		//-------------------------------------------------------------------
		public CRelationEquipementLogique_ChampCustomServeur( int nIdSession )
			:base(nIdSession)
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationEquipementLogique_ChampCustom.c_nomTable;
		}
		
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CRelationEquipementLogique_ChampCustom);
		}
		//-------------------------------------------------------------------
	}
}
