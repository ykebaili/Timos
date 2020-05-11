using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.workflow;
using System.Drawing;

#if !PDA_DATA

namespace sc2i.workflow.serveur
{
	/// <summary>
	/// Description résumée de CComptabiliteServeur.
	/// </summary>
	public class CRoleSurEntreeAgendaServeur : CObjetServeurAvecBlob
	{
		//-------------------------------------------------------------------
#if PDA
		public CRoleSurEntreeAgendaServeur ()
			:base ()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRoleSurEntreeAgendaServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRoleSurEntreeAgenda.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CRoleSurEntreeAgenda role = (CRoleSurEntreeAgenda)objet;

				if ( role.Code.Trim() == "" )
					result.EmpileErreur(I.T("The role code must be specified|329"));

				if (!CObjetDonneeAIdNumerique.IsUnique(role, CRoleSurEntreeAgenda.c_champCode, role.Code))
					result.EmpileErreur(I.T("The role '@1' already exists|328",role.Code));

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
			return typeof(CRoleSurEntreeAgenda);
		}
		//-------------------------------------------------------------------
	}
}
#endif