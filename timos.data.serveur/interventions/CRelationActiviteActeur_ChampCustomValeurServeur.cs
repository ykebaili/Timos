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
	/// Description résumée de CRelationActiviteActeur_ChampCustomValeurServeur.
	/// </summary>
	public class CRelationActiviteActeur_ChampCustomValeurServeur : CRelationElementAChamp_ChampCustomServeur
	{
		//-------------------------------------------------------------------
		public CRelationActiviteActeur_ChampCustomValeurServeur( int nIdSession )
			:base(nIdSession)
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationActiviteActeur_ChampCustomValeur.c_nomTable;
		}
		
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CRelationActiviteActeur_ChampCustomValeur);
		}
		//-------------------------------------------------------------------
	}
}
