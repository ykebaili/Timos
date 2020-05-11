using System;
using System.Collections;
using System.Data;
using System.Threading;

using sc2i.common;
using sc2i.data;
using sc2i.data.serveur;
using sc2i.data.dynamic;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.multitiers.server;


namespace sc2i.workflow.serveur
{
	/// <summary>
	/// Description résumée de Class1.
	/// </summary>
	public class CEntreeAgenda_SynchroExtServeur : CObjetServeurAvecBlob
	{
		/// //////////////////////////////////////////////////
		public CEntreeAgenda_SynchroExtServeur( int nIdSession )
			:base ( nIdSession )
		{
			
		}

		//////////////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CEntreeAgenda_SynchroExt.c_nomTable;
		}

		//////////////////////////////////////////////////////////////////////
		public override Type GetTypeObjets()
		{
			return typeof(CEntreeAgenda_SynchroExt);
		}

		//////////////////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{	
				CEntreeAgenda_SynchroExt entree = (CEntreeAgenda_SynchroExt)objet;

				return result;
			}
			catch ( Exception e )
			{
				result.EmpileErreur(new CErreurException(e));
				result.EmpileErreur(I.T("Error in the data of the Diary entry|310"));
			}
			return result;
				
		}


	}
}
