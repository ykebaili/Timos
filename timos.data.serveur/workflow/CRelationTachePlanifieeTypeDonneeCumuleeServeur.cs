using System;

using sc2i.common;
using sc2i.data;
using sc2i.data.serveur;
using sc2i.data.dynamic;

using sc2i.workflow;

namespace sc2i.workflow.serveur
{
	/// <summary>
	/// Description résumée de Class1.
	/// </summary>
	public class CRelationTachePlanifieeTypeDonneeCumuleeServeur : CObjetServeur
	{
		/// //////////////////////////////////////////////////
#if PDA
		public CRelationTachePlanifieeTypeDonneeCumuleeServeur()
			:base ()
		{
			
		}
#endif
		/// //////////////////////////////////////////////////
		public CRelationTachePlanifieeTypeDonneeCumuleeServeur( int nIdSession )
			:base ( nIdSession )
		{
			
		}

		//////////////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CRelationTachePlanifieeTypeDonneeCumulee.c_nomTable;
		}

		//////////////////////////////////////////////////////////////////////
		public override Type GetTypeObjets()
		{
			return typeof(CRelationTachePlanifieeTypeDonneeCumulee);
		}

		//////////////////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{	
				CRelationTachePlanifieeTypeDonneeCumulee rel = (CRelationTachePlanifieeTypeDonneeCumulee)objet;

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
