using System;
using System.Collections;

using sc2i.common;
using sc2i.data;
using sc2i.data.serveur;
using sc2i.data.dynamic;
using sc2i.workflow;

namespace sc2i.workflow.serveur
{
	/// <summary>
	/// Description rÃƒÆ’Ã‚Â©sumÃƒÆ’Ã‚Â©e de Class1.
	/// </summary>
	public class CDossierSuiviServeur : CObjetServeur
	{
		/// //////////////////////////////////////////////////
#if PDA
		public CDossierSuiviServeur()
			:base ()
		{
			
		}
#endif
		/// //////////////////////////////////////////////////
		public CDossierSuiviServeur( int nIdSession )
			:base ( nIdSession )
		{
			
		}

		//////////////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CDossierSuivi.c_nomTable;
		}

		//////////////////////////////////////////////////////////////////////
		public override Type GetTypeObjets()
		{
			return typeof(CDossierSuivi);
		}

		//////////////////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{	
				CDossierSuivi DossierSuivi = (CDossierSuivi)objet;
				if ( DossierSuivi.Libelle == "" )
				{
					result.EmpileErreur(I.T("Workbook label should not be empty|306"));
				}

				if ( DossierSuivi.TypeDossier == null )
				{
					result.EmpileErreur(I.T("The Worbook Type connot be null|307"));
				}
				else
					if ( DossierSuivi.ElementSuivi != null &&  DossierSuivi.TypeDossier.TypeSuivi != null &&
						!DossierSuivi.ElementSuivi.GetType().Equals(DossierSuivi.TypeDossier.TypeSuivi ))
					result.EmpileErreur(I.T("Workbook linked element is not of the expected type (@1)|308",
						DynamicClassAttribute.GetNomConvivial(DossierSuivi.TypeDossier.TypeSuivi)));

				CRelationDossierSuivi_ChampCustomServeur relServeur = new CRelationDossierSuivi_ChampCustomServeur(IdSession);
				foreach ( CRelationDossierSuivi_ChampCustom rel in CNettoyeurValeursChamps.RelationsChampsNormales(DossierSuivi) )
				{
					CResultAErreur resultTmp = relServeur.VerifieDonnees(rel);
					if ( !resultTmp )
					{
						result.Erreur.EmpileErreurs(resultTmp.Erreur);
						result.SetFalse();
					}
				}

				Hashtable m_tableRelationsToElements = new Hashtable();
				foreach ( CRelationDossierSuivi_Element relElement in DossierSuivi.RelationsElements )
					m_tableRelationsToElements[relElement.RelationParametre_TypeElement.Id] = true;

				return result;
			}
			catch ( Exception e )
			{
				result.EmpileErreur(new CErreurException(e));
				result.EmpileErreur(I.T( "Workbook data error|309"));
			}
			return result;
				
		}


	}
}
