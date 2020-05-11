using System;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.data.dynamic;
using sc2i.data.dynamic.loader;
using timos.acteurs;

namespace timos.data
{
	/// <summary>
	/// Description résumée de CRelationSystemeCoordonnees_FormatNumerotationServeur.
	/// </summary>
	public class CRelationSystemeCoordonnees_FormatNumerotationServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
		public CRelationSystemeCoordonnees_FormatNumerotationServeur(int nIdSession)
			: base(nIdSession)
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable()
		{
			return CRelationSystemeCoordonnees_FormatNumerotation.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CRelationSystemeCoordonnees_FormatNumerotation);
		}


		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
		{
			CResultAErreur result = CResultAErreur.True;
				try
			{

				CRelationSystemeCoordonnees_FormatNumerotation relationSCFN = (CRelationSystemeCoordonnees_FormatNumerotation)objet;
				if (relationSCFN.Libelle == "" || relationSCFN.Libelle == null)
					result.EmpileErreur(I.T("The Label cannot be empty|181"));
				if(relationSCFN.Unite == null)
					result.EmpileErreur(I.T( "The unit is necessary|199", relationSCFN.Libelle));
			}
			catch ( Exception e )
			{
				result.EmpileErreur( new CErreurException ( e ) );
			}
			

			return result;
		}
	}
}
