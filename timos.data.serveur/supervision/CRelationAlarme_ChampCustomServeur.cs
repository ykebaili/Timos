using System;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.data.dynamic;
using timos.securite;
using sc2i.data.dynamic.loader;
using timos.data.supervision;

namespace timos.data.serveur
{
	/// <summary>
	/// Description résumée de CRelationAlarme_ChampCustomServeur.
	/// </summary>
	public class CRelationAlarme_ChampCustomServeur : CRelationElementAChamp_ChampCustomServeur
	{
		//-------------------------------------------------------------------
#if PDA
		public CRelationEO_ChampCustomServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationAlarme_ChampCustomServeur( int nIdSession )
			:base(nIdSession)
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationAlarme_ChampCustom.c_nomTable;
		}
		
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CRelationAlarme_ChampCustom);
		}
		//-------------------------------------------------------------------
	}
}
