using System;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.data.dynamic;
using sc2i.data.dynamic.loader;
using timos.acteurs;
using timos.securite;

namespace timos.data.commandes.serveur
{
	/// <summary>
	/// Description r�sum�e de CRelationEntiteOrganisationnelle_FormulaireServeur.
	/// </summary>
	public class CRelationTypeLivraisonEquipement_FormulaireServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
#if PDA
		public CRelationEntiteOrganisationnelle_FormulaireServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeLivraisonEquipement_FormulaireServeur(int nIdSession)
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationTypeLivraisonEquipement_Formulaire.c_nomTable;
		}
		
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CRelationTypeLivraisonEquipement_Formulaire);
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
		{
			CResultAErreur result = CResultAErreur.True;
			return result;
		}
	}
}
