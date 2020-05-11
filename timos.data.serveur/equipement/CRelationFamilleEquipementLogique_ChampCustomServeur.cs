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
	/// Description résumée de CRelationFamilleEquipementLogique_ChampCustomServeur.
	/// </summary>
	public class CRelationFamilleEquipementLogique_ChampCustomServeur : CRelationDefinisseurChamp_ChampCustomServeur
	{
		//-------------------------------------------------------------------
		//-------------------------------------------------------------------
		public CRelationFamilleEquipementLogique_ChampCustomServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationFamillEquipementLogique_ChampCustom.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CRelationFamillEquipementLogique_ChampCustom);
		}
		//-------------------------------------------------------------------
	}
}
