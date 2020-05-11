using System;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.data.dynamic;
using sc2i.data.dynamic.loader;

namespace timos.data.commandes.serveur
{
	/// <summary>
	/// Description résumée de CRelationCommande_ChampCustomServeur.
	/// </summary>
	public class CRelationCommande_ChampCustomServeur : CRelationElementAChamp_ChampCustomServeur
	{
		//-------------------------------------------------------------------
		public CRelationCommande_ChampCustomServeur( int nIdSession )
			:base(nIdSession)
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationCommande_ChampCustom.c_nomTable;
		}
		
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CRelationCommande_ChampCustom);
		}
		//-------------------------------------------------------------------
	}
}
