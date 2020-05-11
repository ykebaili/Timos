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
	/// Description résumée de CRelationTypeEquipement_ChampCustomServeur.
	/// </summary>
	public class CRelationTypeEquipement_ChampCustomServeur : CRelationDefinisseurChamp_ChampCustomServeur
	{
		//-------------------------------------------------------------------
#if PDA
		public CRelationTypeEquipement_ChampCustomServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeEquipement_ChampCustomServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationTypeEquipement_ChampCustom.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CRelationTypeEquipement_ChampCustom);
		}
		//-------------------------------------------------------------------
	}
}
