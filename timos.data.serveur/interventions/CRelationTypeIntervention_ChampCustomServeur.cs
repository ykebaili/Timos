using System;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.data.dynamic;
using sc2i.data.dynamic.loader;
using timos.acteurs;

namespace timos.data
{
	/// <summary>
	/// Description résumée de CRelationTypeIntervention_ChampCustomServeur.
	/// </summary>
	public class CRelationTypeIntervention_ChampCustomServeur : CRelationDefinisseurChamp_ChampCustomServeur
	{
		//-------------------------------------------------------------------
#if PDA
		public CRelationTypeIntervention_ChampCustomServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeIntervention_ChampCustomServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationTypeIntervention_ChampCustom.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CRelationTypeIntervention_ChampCustom);
		}
		//-------------------------------------------------------------------
	}
}
