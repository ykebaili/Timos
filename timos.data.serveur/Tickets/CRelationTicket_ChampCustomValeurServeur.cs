using System;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.data.dynamic;
using sc2i.data.dynamic.loader;

using timos.data;

namespace timos.data.serveur
{
	/// <summary>
	/// Description r�sum�e de CRelationTicket_ChampCustomServeur.
	/// </summary>
	public class CRelationTicket_ChampCustomValeurServeur : CRelationElementAChamp_ChampCustomServeur
	{
		//-------------------------------------------------------------------
#if PDA
		public CRelationEO_ChampCustomServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTicket_ChampCustomValeurServeur( int nIdSession )
			:base(nIdSession)
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationTicket_ChampCustomValeur.c_nomTable;
		}
		
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CRelationTicket_ChampCustomValeur);
		}
		//-------------------------------------------------------------------
	}
}
