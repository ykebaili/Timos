using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.workflow;

namespace sc2i.workflow.serveur
{
	/// <summary>
	/// Description résumée de CTypeTableauPlanningServeur.
	/// </summary>
	public class CTypeTableauPlanningServeur : CObjetServeurAvecBlob
	{
#if PDA
		public CTypeTableauPlanningServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CTypeTableauPlanningServeur( int nIdSession )
			:base(nIdSession)
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CTypeTableauPlanning.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CTypeTableauPlanning typeTableau = (CTypeTableauPlanning)objet;

                if (typeTableau.Libelle == "")
					result.EmpileErreur(I.T("The label cannot be empty|126"));

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
			return typeof(CTypeTableauPlanning);
		}
		//-------------------------------------------------------------------
	}
}
