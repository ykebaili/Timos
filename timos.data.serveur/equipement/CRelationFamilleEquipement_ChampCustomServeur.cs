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
	/// Description résumée de CRelationFamilleEquipement_ChampCustomServeur.
	/// </summary>
	public class CRelationFamilleEquipement_ChampCustomServeur : CRelationDefinisseurChamp_ChampCustomServeur
	{
		//-------------------------------------------------------------------
#if PDA
		public CRelationFamilleEquipement_ChampCustomServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationFamilleEquipement_ChampCustomServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationFamilleEquipement_ChampCustom.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CRelationFamilleEquipement_ChampCustom);
		}
		//-------------------------------------------------------------------
	}
}
