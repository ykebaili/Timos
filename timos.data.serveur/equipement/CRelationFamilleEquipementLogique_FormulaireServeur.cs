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
	/// Description résumée de CRelationFamilleEquipementLogique_FormulaireServeur.
	/// </summary>
	public class CRelationFamilleEquipementLogique_FormulaireServeur :  CRelationDefinisseurChamp_FormulaireServeur
	{
		//-------------------------------------------------------------------
		//-------------------------------------------------------------------
		public CRelationFamilleEquipementLogique_FormulaireServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationFamilleEquipementLogique_Formulaire.c_nomTable;
		}
		
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CRelationFamilleEquipementLogique_Formulaire);
		}
		//-------------------------------------------------------------------
	}
}
