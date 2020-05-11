using System;

using sc2i.common;
using sc2i.data;
using sc2i.data.serveur;
using sc2i.data.dynamic;
using sc2i.data.dynamic.loader;

namespace sc2i.workflow.serveur
{
	/// <summary>
	/// Description résumée de Class1.
	/// </summary>
	public class CRelationEntreeAgenda_ChampCustomServeur : CRelationElementAChamp_ChampCustomServeur
	{
		/// //////////////////////////////////////////////////
#if PDA
		public CRelationEntreeAgenda_ChampCustomServeur()
			:base ()
		{
			
		}
#endif
		/// //////////////////////////////////////////////////
		public CRelationEntreeAgenda_ChampCustomServeur( int nIdSession )
			:base ( nIdSession )
		{
			
		}

		//////////////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CRelationEntreeAgenda_ChampCustom.c_nomTable;
		}

		//////////////////////////////////////////////////////////////////////
		public override Type GetTypeObjets()
		{
			return typeof(CRelationEntreeAgenda_ChampCustom);
		}

	}
}
