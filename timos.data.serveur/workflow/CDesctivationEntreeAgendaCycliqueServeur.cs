using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.workflow;


#if !PDA_DATA

namespace sc2i.workflow.serveur
{
	/// <summary>
	/// Description résumée de CComptabiliteServeur.
	/// </summary>
	public class CDesctivationEntreeAgendaCycliqueServeur : CObjetServeur
	{
		//-------------------------------------------------------------------
#if PDA
		public CDesctivationEntreeAgendaCycliqueServeur ()
			:base ()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CDesctivationEntreeAgendaCycliqueServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CDesctivationEntreeAgendaCyclique.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CDesctivationEntreeAgendaCyclique desac = (CDesctivationEntreeAgendaCyclique)objet;

				
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
			return typeof(CDesctivationEntreeAgendaCyclique);
		}
	}
}

#endif