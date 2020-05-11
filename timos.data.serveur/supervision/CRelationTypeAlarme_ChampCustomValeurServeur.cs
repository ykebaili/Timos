using System;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.data.dynamic;
using sc2i.data.dynamic.loader;

using timos.data;
using timos.data.supervision;

namespace timos.data.serveur
{
	/// <summary>
	/// Description résumée de CRelationTypeAlarme_ChampCustomServeur.
	/// </summary>
	public class CRelationTypeAlarme_ChampCustomValeurServeur : CRelationElementAChamp_ChampCustomServeur
	{
		//-------------------------------------------------------------------
#if PDA
		public CRelationEO_ChampCustomServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeAlarme_ChampCustomValeurServeur( int nIdSession )
			:base(nIdSession)
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationTypeAlarme_ChampCustomValeur.c_nomTable;
		}
		
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CRelationTypeAlarme_ChampCustomValeur);
		}
		//-------------------------------------------------------------------
	}
}
