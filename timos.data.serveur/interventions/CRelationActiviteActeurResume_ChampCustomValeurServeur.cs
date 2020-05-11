using System;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.data.dynamic;
using sc2i.data.dynamic.loader;

using timos.securite;

namespace timos.data.serveur
{
	/// <summary>
	/// Description résumée de CRelationActiviteActeurResume_ChampCustomValeurServeur.
	/// </summary>
	public class CRelationActiviteActeurResume_ChampCustomValeurServeur : CRelationElementAChamp_ChampCustomServeur
	{
		//-------------------------------------------------------------------
		public CRelationActiviteActeurResume_ChampCustomValeurServeur( int nIdSession )
			:base(nIdSession)
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationActiviteActeurResume_ChampCustomValeur.c_nomTable;
		}
		
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CRelationActiviteActeurResume_ChampCustomValeur);
		}
		//-------------------------------------------------------------------
	}
}
