using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;
using sc2i.workflow;

using timos.data;

namespace sc2i.workflow.serveur
{
	/// <summary>
	/// Description résumée de CTypeTableauPlanning_TrancheHoraireServeur.
	/// </summary>
	public class CTypeTableauPlanning_TrancheHoraireServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
#if PDA
		public CTypeTableauPlanning_TrancheHoraireServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CTypeTableauPlanning_TrancheHoraireServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CTypeTableauPlanning_TrancheHoraire.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CTypeTableauPlanning_TrancheHoraire rel = (CTypeTableauPlanning_TrancheHoraire)objet;

                if (rel.Libelle == "")
                    result.EmpileErreur(I.T( "The time slot Label cannot be empty|383"));
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
			return typeof(CTypeTableauPlanning_TrancheHoraire);
		}
		//-------------------------------------------------------------------
	}
}
