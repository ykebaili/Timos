using System;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.data.dynamic;
using timos.securite;
using sc2i.data.dynamic.loader;

namespace timos.securite.serveur
{
	/// <summary>
	/// Description résumée de CRelationEO_ChampCustomServeur.
	/// </summary>
	public class CRelationEO_ChampCustomServeur : CRelationElementAChamp_ChampCustomServeur
	{
		//-------------------------------------------------------------------
#if PDA
		public CRelationEO_ChampCustomServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationEO_ChampCustomServeur( int nIdSession )
			:base(nIdSession)
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationEO_ChampCustom.c_nomTable;
		}
		
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CRelationEO_ChampCustom);
		}
		//-------------------------------------------------------------------
	}
}
