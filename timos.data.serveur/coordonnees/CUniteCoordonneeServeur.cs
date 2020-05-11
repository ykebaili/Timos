using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;

namespace timos.data
{
	/// <summary>
	/// Description résumée de CUniteCoordonneeServeur.
	/// </summary>
	public class CUniteCoordonneeServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
		public CUniteCoordonneeServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CUniteCoordonnee.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CUniteCoordonnee uniteCoordonnee = (CUniteCoordonnee)objet;

				if ( uniteCoordonnee.Libelle == "")
					result.EmpileErreur(I.T( "The label of the unit cannot be empty|174"));
				if (!CObjetDonneeAIdNumerique.IsUnique(uniteCoordonnee, CUniteCoordonnee.c_champLibelle, uniteCoordonnee.Libelle))
					result.EmpileErreur(I.T( "The unit '@1' already exists|173", uniteCoordonnee.Libelle));

				if (uniteCoordonnee.Abreviation == "")
					result.EmpileErreur(I.T( "The abbreviation of the unit cannot be empty|175"));
				if (!CObjetDonneeAIdNumerique.IsUnique(uniteCoordonnee, CUniteCoordonnee.c_champAbreviation, uniteCoordonnee.Abreviation))
					result.EmpileErreur(I.T("The abbreviation '@1' already exists|176", uniteCoordonnee.Abreviation));

                

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
			return typeof(CUniteCoordonnee);
		}
		//-------------------------------------------------------------------
	}
}
