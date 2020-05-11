using System;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.data.dynamic;
using sc2i.data.dynamic.loader;
using timos.acteurs;
using timos.data.equipement.consommables;

namespace timos.data
{
	/// <summary>
	/// Description résumée de CRelationTypeConsommable_FormulaireServeur.
	/// </summary>
	public class CRelationTypeConsommable_FormulaireServeur :  CRelationDefinisseurChamp_FormulaireServeur
	{
		//-------------------------------------------------------------------
#if PDA
		public CRelationTypeConsommable_FormulaireServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeConsommable_FormulaireServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationTypeConsommable_Formulaire.c_nomTable;
		}
		
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CRelationTypeConsommable_Formulaire);
		}
		//-------------------------------------------------------------------
	}
}
