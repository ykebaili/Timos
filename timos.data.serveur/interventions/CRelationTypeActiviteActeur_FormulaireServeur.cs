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
	/// Description résumée de CRelationTypeActiviteActeur_FormulaireServeur.
	/// </summary>
	public class CRelationTypeActiviteActeur_FormulaireServeur :  CRelationDefinisseurChamp_FormulaireServeur
	{
		//-------------------------------------------------------------------
#if PDA
		public CRelationTypeActiviteActeur_FormulaireServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeActiviteActeur_FormulaireServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationTypeActiviteActeur_Formulaire.c_nomTable;
		}
		
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CRelationTypeActiviteActeur_Formulaire);
		}
		//-------------------------------------------------------------------
	}
}
