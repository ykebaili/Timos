using System;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.data.dynamic;
using sc2i.data.dynamic.loader;
using timos.data.equipement.consommables;


namespace timos.data
{
	/// <summary>
	/// Description résumée de CRelationConsommable_ChampCustomValeurServeur.
	/// </summary>
	public class CRelationLotConsommable_ChampCustomServeur : CRelationElementAChamp_ChampCustomServeur
	{
		//-------------------------------------------------------------------
#if PDA
		public CRelationConsommable_ChampCustomValeurServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationLotConsommable_ChampCustomServeur( int nIdSession )
			:base(nIdSession)
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationLotConsommable_ChampCustom.c_nomTable;
		}
		
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
            return typeof(CRelationLotConsommable_ChampCustom);
		}
		//-------------------------------------------------------------------
	}
}
