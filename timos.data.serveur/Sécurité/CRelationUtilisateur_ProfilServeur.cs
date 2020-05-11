using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.securite;

namespace timos.securite.serveur
{
	/// <summary>
	/// Description résumée de CRelationUtilisateur_ProfilServeur.
	/// </summary>
	public class CRelationUtilisateur_ProfilServeur : CObjetServeur
	{
		//-------------------------------------------------------------------
		//-------------------------------------------------------------------
		public CRelationUtilisateur_ProfilServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationUtilisateur_Profil.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CRelationUtilisateur_Profil rel = (CRelationUtilisateur_Profil)objet;


				if (rel.Utilisateur == null && rel.RelationParente == null)
					result.EmpileErreur(I.T("The user cannot be null|302"));
				if (rel.Profil == null && rel.Profil_Inclusion == null )
					result.EmpileErreur(I.T("The profile cannot be null|303"));
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
			return typeof(CRelationUtilisateur_Profil);
		}
		//-------------------------------------------------------------------
	}
}
