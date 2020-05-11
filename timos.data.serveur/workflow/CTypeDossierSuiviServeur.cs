using System;

using sc2i.common;
using sc2i.data;
using sc2i.data.serveur;
using sc2i.data.dynamic;
using sc2i.workflow;

namespace sc2i.workflow.serveur
{
	/// <summary>
	/// Description rÃ©sumÃ©e de Class1.
	/// </summary>
	public class CTypeDossierSuiviServeur : CObjetServeurAvecBlob
	{
		/// //////////////////////////////////////////////////
#if PDA
		public CTypeDossierSuiviServeur()
			:base ( )
		{
			
		}
#endif
		/// //////////////////////////////////////////////////
		public CTypeDossierSuiviServeur( int nIdSession )
			:base ( nIdSession )
		{
			
		}

		//////////////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CTypeDossierSuivi.c_nomTable;
		}

		//////////////////////////////////////////////////////////////////////
		public override Type GetTypeObjets()
		{
			return typeof(CTypeDossierSuivi);
		}

		//////////////////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{	
				CTypeDossierSuivi parametre = (CTypeDossierSuivi)objet;
				if ( parametre.Libelle == "" )
				{
					result.EmpileErreur(I.T("Workbook type label cannot be empty|344"));
				}
				CFiltreData filtre = null;
				if ( parametre.TypeDossierParent != null )
				{
					filtre = new CFiltreData ( 
						CTypeDossierSuivi.c_champLibelle+"=@1 and "+
						CTypeDossierSuivi.c_champTypeDossierParent+"=@2 and "+
						CTypeDossierSuivi.c_champId+"<>@3",
						parametre.Libelle,
						parametre.TypeDossierParent.Id,
						parametre.Id );
				}
				else
				{
					filtre = new CFiltreData ( 
						CTypeDossierSuivi.c_champLibelle+"=@1 and "+
						CTypeDossierSuivi.c_champTypeDossierParent+" is null and "+
						CTypeDossierSuivi.c_champId+"<>@2",
						parametre.Libelle,
						parametre.Id );
				}
				if ( CountRecords ( CTypeDossierSuivi.c_nomTable, filtre ) > 0 )
				{
					result.EmpileErreur(I.T("Another Workbook type has this label|345"));
				}

			
				return result;
			}
			catch ( Exception e )
			{
				result.EmpileErreur(new CErreurException(e));
				result.EmpileErreur(I.T("Workbook Type data error|346"));
			}
			return result;
				
		}


	}
}
