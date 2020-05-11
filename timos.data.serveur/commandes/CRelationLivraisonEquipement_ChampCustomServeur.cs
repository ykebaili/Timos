using System;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.data.dynamic;
using sc2i.data.dynamic.loader;

namespace timos.data.commandes.serveur
{
	/// <summary>
	/// Description résumée de CRelationLivraisonEquipement_ChampCustomServeur.
	/// </summary>
	public class CRelationLivraisonEquipement_ChampCustomServeur : CRelationElementAChamp_ChampCustomServeur
	{
		//-------------------------------------------------------------------
		public CRelationLivraisonEquipement_ChampCustomServeur( int nIdSession )
			:base(nIdSession)
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationLivraisonEquipement_ChampCustom.c_nomTable;
		}
		
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CRelationLivraisonEquipement_ChampCustom);
		}
		//-------------------------------------------------------------------
	}
}
