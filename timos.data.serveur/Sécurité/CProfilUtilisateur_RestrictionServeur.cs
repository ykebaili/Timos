using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.securite;

namespace timos.securite.serveur
{
	/// <summary>
	/// Description résumée de CRelationProfilUtilisateur_EOServeur.
	/// </summary>
	public class CProfilUtilisateur_RestrictionServeur : CObjetServeur
	{
		//-------------------------------------------------------------------
#if PDA
		public CRelationProfilUtilisateur_EOServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CProfilUtilisateur_RestrictionServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CProfilUtilisateur_Restriction.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CProfilUtilisateur_Restriction rel = (CProfilUtilisateur_Restriction)objet;
				if (rel.Profil == null)
					result.EmpileErreur(I.T("The profile cannot be empty|293"));
				if (rel.Restrictions == null)
					result.EmpileErreur(I.T("The restriction group cannnot be null|294"));
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
			return typeof(CProfilUtilisateur_Restriction);
		}
		//-------------------------------------------------------------------
	}
}
