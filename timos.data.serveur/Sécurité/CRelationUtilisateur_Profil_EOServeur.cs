using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.securite;

namespace timos.securite.serveur
{
	/// <summary>
	/// Description résumée de CRelationUtilisateur_Profil_EOServeur.
	/// </summary>
	public class CRelationUtilisateur_Profil_EOServeur : CObjetServeur
	{
		//-------------------------------------------------------------------
		//-------------------------------------------------------------------
		public CRelationUtilisateur_Profil_EOServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationUtilisateur_Profil_EO.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CRelationUtilisateur_Profil_EO rel = (CRelationUtilisateur_Profil_EO)objet;


				if (rel.UtilisateurProfil == null)
					result.EmpileErreur(I.T("The relation to User/Profile cannot be null|300"));
				if (rel.EntiteOrganisationnelle == null)
					result.EmpileErreur(I.T("The profile of the Organisational Entity cannot be null|301"));
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
			return typeof(CRelationUtilisateur_Profil_EO);
		}
		//-------------------------------------------------------------------
	}
}
