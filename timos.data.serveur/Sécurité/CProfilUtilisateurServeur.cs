using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.securite;

namespace timos.securite.serveur
{
	/// <summary>
	/// Description résumée de CProfilUtilisateurServeur.
	/// </summary>
	public class CProfilUtilisateurServeur : CObjetServeur
	{
		//-------------------------------------------------------------------
#if PDA
		public CProfilUtilisateurServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CProfilUtilisateurServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CProfilUtilisateur.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CProfilUtilisateur ProfilUtilisateur = (CProfilUtilisateur)objet;

				if ( ProfilUtilisateur.Libelle == "")
					result.EmpileErreur(I.T("The profile label cannot be empty|295"));
				if (!CObjetDonneeAIdNumerique.IsUnique(ProfilUtilisateur, CProfilUtilisateur.c_champLibelle, ProfilUtilisateur.Libelle))
					result.EmpileErreur(I.T("The profile '@1' already exists|296",ProfilUtilisateur.Libelle));
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
			return typeof(CProfilUtilisateur);
		}
		//-------------------------------------------------------------------
	}
}
