using System;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.data.dynamic;
using timos.securite;
using sc2i.data.dynamic.loader;

namespace timos.data.serveur
{
	/// <summary>
	/// Description résumée de CRelationIntervention_ChampCustomServeur.
	/// </summary>
	public class CRelationIntervention_ChampCustomServeur : CRelationElementAChamp_ChampCustomServeur
	{
		//-------------------------------------------------------------------
		public CRelationIntervention_ChampCustomServeur( int nIdSession )
			:base(nIdSession)
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationIntervention_ChampCustom.c_nomTable;
		}
		
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CRelationIntervention_ChampCustom);
		}
		//-------------------------------------------------------------------
	}
}
