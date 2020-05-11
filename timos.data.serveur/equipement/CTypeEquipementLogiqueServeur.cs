using System;
using System.Collections;
using System.Data;


using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.multitiers.client;
using timos.acteurs;

namespace timos.data
{
	/// <summary>
	/// Description résumée de CTypeEquipementLogiqueServeur.
	/// </summary>
	public class CTypeEquipementLogiqueServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
		public CTypeEquipementLogiqueServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CTypeEquipementLogique.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur TraitementAvantSauvegarde ( CContexteDonnee contexte )
		{
			CResultAErreur result = base.TraitementAvantSauvegarde(contexte);
			if (!result)
				return result;

			return result;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CTypeEquipementLogique typeEquipementLogique = (CTypeEquipementLogique)objet;

				if ( typeEquipementLogique.Libelle == "")
					result.EmpileErreur(I.T("Logical equipment type label cannot be empty|20006"));

				if (!CObjetDonneeAIdNumerique.IsUnique(typeEquipementLogique, CTypeEquipementLogique.c_champLibelle, typeEquipementLogique.Libelle))
					result.EmpileErreur(I.T("This logical equipment type label already exists|20007"));


				if (typeEquipementLogique.Famille == null)
					result.EmpileErreur(I.T("The logical equipment type must be associated to a family|20008"));

			}
			catch ( Exception e )
			{
				result.EmpileErreur( new CErreurException ( e ) );
			}
			return result;
		}
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CTypeEquipementLogique);
		}


	}
}
