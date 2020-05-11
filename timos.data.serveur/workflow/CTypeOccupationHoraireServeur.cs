using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;

namespace sc2i.workflow
{
	/// <summary>
	/// Description résumée de CTypeOccupationHoraireServeur.
	/// </summary>
	public class CTypeOccupationHoraireServeur : CObjetDonneeServeurAvecCache
	{

		//-------------------------------------------------------------------
		public CTypeOccupationHoraireServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CTypeOccupationHoraire.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CTypeOccupationHoraire typeOccupationH = (CTypeOccupationHoraire)objet;

                if (typeOccupationH.Libelle == "")
					result.EmpileErreur(I.T("Occupation type label cannot be empty|350"));

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
			return typeof(CTypeOccupationHoraire);
		}
		//-------------------------------------------------------------------
	}
}
