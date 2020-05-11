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
	public class CRelationTypeDossierSuivi_TypeElementServeur : CObjetServeurAvecBlob
	{
		/// //////////////////////////////////////////////////
#if PDA
		public CRelationTypeDossierSuivi_TypeElementServeur()
			:base ()
		{
			
		}
#endif
		/// //////////////////////////////////////////////////
		public CRelationTypeDossierSuivi_TypeElementServeur( int nIdSession )
			:base ( nIdSession )
		{
			
		}

		//////////////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CRelationTypeDossierSuivi_TypeElement.c_nomTable;
		}

		//////////////////////////////////////////////////////////////////////
		public override Type GetTypeObjets()
		{
			return typeof(CRelationTypeDossierSuivi_TypeElement);
		}

		//////////////////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{	
				CRelationTypeDossierSuivi_TypeElement relation = (CRelationTypeDossierSuivi_TypeElement)objet;
				if ( relation.Libelle == "" )
				{
					result.EmpileErreur(I.T("Link label cannot be empty|325"));
				}
				CFiltreData filtre = new CFiltreData (
					CRelationTypeDossierSuivi_TypeElement.c_champLibelle+"=@1 and "+
					CRelationTypeDossierSuivi_TypeElement.c_champId+"<>@2 and "+
					CTypeDossierSuivi.c_champId+"=@3",
					relation.Libelle,
					relation.Id,
					relation.TypeDossierSuivi.Id);
				if ( CountRecords(CRelationTypeDossierSuivi_TypeElement.c_nomTable,
					filtre) > 0 )
				{
					result.EmpileErreur(I.T("The label '@1' already exists|326",relation.Libelle));
				}

				
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
