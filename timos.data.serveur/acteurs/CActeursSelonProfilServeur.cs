using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;

using timos.data;

namespace timos.data.serveur
{
	/// <summary>
	/// Description résumée de CActeursSelonProfilServeur.
	/// </summary>
	public class CActeursSelonProfilServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
#if PDA
		public CContactsSelonProfilServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CActeursSelonProfilServeur(int nIdSession)
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CActeursSelonProfil.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CActeursSelonProfil ActeursSelonProf = (CActeursSelonProfil)objet;

				CProfilElement prof = ActeursSelonProf.Profil;

				if (prof == null)
					result.EmpileErreur(I.T( "The profile cannot be empty|263"));

				if (prof.TypeElements != typeof(CActeur))
					result.EmpileErreur(I.T( "The profile must return Members|264"));

				if (ActeursSelonProf.TypeIntervention != null)
					if (prof.TypeSource != typeof(CIntervention))
						result.EmpileErreur(I.T( "Profile Source Elements must be Interventions|265"));
				else if (ActeursSelonProf.TypePhase != null)
					if (prof.TypeSource != typeof(CPhaseTicket))
						result.EmpileErreur(I.T("Profile Source Elements must be Ticket Phases|266"));
				else
						result.EmpileErreur(I.T( "Profie objetc Type must be defined|267"));


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
			return typeof(CActeursSelonProfil);
		}
		//-------------------------------------------------------------------
	}
}
