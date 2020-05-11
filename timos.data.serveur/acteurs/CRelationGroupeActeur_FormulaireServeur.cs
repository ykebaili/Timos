using System;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.data.dynamic;
using sc2i.data.dynamic.loader;
using timos.acteurs;

namespace timos.acteurs.serveur
{
	/// <summary>
	/// Description résumée de CRelationGroupeActeur_FormulaireServeur.
	/// </summary>
	public class CRelationGroupeActeur_FormulaireServeur :  CRelationDefinisseurChamp_FormulaireServeur
	{
		//-------------------------------------------------------------------
#if PDA
		public CRelationGroupeActeur_FormulaireServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationGroupeActeur_FormulaireServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationGroupeActeur_Formulaire.c_nomTable;
		}
		
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CRelationGroupeActeur_Formulaire);
		}
		//-------------------------------------------------------------------
	}
}
