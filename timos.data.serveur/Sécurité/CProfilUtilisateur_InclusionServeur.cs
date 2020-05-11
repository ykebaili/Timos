using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.securite;

namespace timos.securite.serveur
{
	/// <summary>
	/// Description résumée de CProfilUtilisateur_InclusionServeur.
	/// </summary>
	public class CProfilUtilisateur_InclusionServeur : CObjetServeur
	{
		//-------------------------------------------------------------------
#if PDA
		public CProfilUtilisateur_InclusionServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CProfilUtilisateur_InclusionServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CProfilUtilisateur_Inclusion.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CProfilUtilisateur_Inclusion inc = (CProfilUtilisateur_Inclusion)objet;

				if ( inc.ProfilParent == null && inc.InclusionParente == null )
					result.EmpileErreur(I.T( "The profile inclusion should be linked to a profile or an inclusion|103"));
				if ( inc.ProfilFils == null )
                    result.EmpileErreur(I.T("The profile inclusion should be linked to a child profile|104"));
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
			return typeof(CProfilUtilisateur_Inclusion);
		}
		//-------------------------------------------------------------------
	}
}
