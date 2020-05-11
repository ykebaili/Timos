using System;

using sc2i.common;
using sc2i.data;
using sc2i.data.serveur;
using sc2i.data.dynamic;

namespace sc2i.workflow.serveur
{
	/// <summary>
	/// Description résumée de Class1.
	/// </summary>
	public class CRelationTachePlanifieeProcessServeur : CObjetServeur
	{
		/// //////////////////////////////////////////////////
#if PDA
		public CRelationTachePlanifieeProcessServeur()
			:base ()
		{
			
		}
#endif
		/// //////////////////////////////////////////////////
		public CRelationTachePlanifieeProcessServeur( int nIdSession )
			:base ( nIdSession )
		{
			
		}

		//////////////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CRelationTachePlanifieeProcess.c_nomTable;
		}

		//////////////////////////////////////////////////////////////////////
		public override Type GetTypeObjets()
		{
			return typeof(CRelationTachePlanifieeProcess);
		}

		//////////////////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{	
				CRelationTachePlanifieeProcess rel = (CRelationTachePlanifieeProcess)objet;

				return result;
			}
			catch ( Exception e )
			{
				result.EmpileErreur(new CErreurException(e));
			}
			return result;
				
		}


	}
}
