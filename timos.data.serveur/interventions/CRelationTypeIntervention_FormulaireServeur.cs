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
	/// Description résumée de CRelationTypeIntervention_FormulaireServeur.
	/// </summary>
	public class CRelationTypeIntervention_FormulaireServeur :  CRelationDefinisseurChamp_FormulaireServeur
	{
		//-------------------------------------------------------------------
#if PDA
		public CRelationTypeIntervention_FormulaireServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeIntervention_FormulaireServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationTypeIntervention_Formulaire.c_nomTable;
		}
		
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CRelationTypeIntervention_Formulaire);
		}
		//-------------------------------------------------------------------
	}
}
