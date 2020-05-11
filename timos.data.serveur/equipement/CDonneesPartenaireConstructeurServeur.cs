using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;
using sc2i.multitiers.client;
using timos.acteurs.serveur;


namespace timos.data.serveur
{
	/// <summary>
	/// Description résumée de CDonneesActeurConstructeurServeur.
	/// </summary>
	public class CDonneesActeurConstructeurServeur : CDonneesActeurServeur
	{

		//-------------------------------------------------------------------
		public CDonneesActeurConstructeurServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CDonneesActeurConstructeur.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;

            try
			{
				CDonneesActeurConstructeur donnees = (CDonneesActeurConstructeur)objet;

				if (donnees.Acteur == null)
					result.EmpileErreur(I.T("The Manufacturer must match a member|245"));
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
			return typeof(CDonneesActeurConstructeur);
		}
	}
}
