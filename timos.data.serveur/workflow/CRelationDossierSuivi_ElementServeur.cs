using System;
using System.Data;
using System.Collections;

using sc2i.common;
using sc2i.data;
using sc2i.data.serveur;
using sc2i.data.dynamic;

namespace sc2i.workflow.serveur
{
	/// <summary>
	/// Description résumée de Class1.
	/// </summary>
	public class CRelationDossierSuivi_ElementServeur : CObjetServeur
	{
		/// //////////////////////////////////////////////////
#if PDA
		public CRelationDossierSuivi_ElementServeur()
			:base ()
		{
			
		}
#endif
		/// //////////////////////////////////////////////////
		public CRelationDossierSuivi_ElementServeur( int nIdSession )
			:base ( nIdSession )
		{
			
		}

		//////////////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CRelationDossierSuivi_Element.c_nomTable;
		}

		//////////////////////////////////////////////////////////////////////
		public override Type GetTypeObjets()
		{
			return typeof(CRelationDossierSuivi_Element);
		}

		//////////////////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{	
				CRelationDossierSuivi_Element rel = (CRelationDossierSuivi_Element)objet;

				return result;
			}
			catch ( Exception e )
			{
				result.EmpileErreur(new CErreurException(e));
				result.EmpileErreur(I.T("Element relation data error|324"));
			}
			return result;
				
		}

		public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
		{
			CResultAErreur result = base.TraitementAvantSauvegarde ( contexte );
			if ( !result )
				return result;
			DataTable table = contexte.Tables[GetNomTable()];
			bool bOldMode = contexte.IsModeDeconnecte;
			if ( !bOldMode )
				contexte.BeginModeDeconnecte();
			ArrayList lst = new ArrayList(table.Rows);
			foreach ( DataRow row in lst )
			{
				if ( row.RowState == DataRowState.Deleted )
				{
					CRelationDossierSuivi_Element relation = new CRelationDossierSuivi_Element( row );
					relation.VersionToReturn = DataRowVersion.Original;
					if ( relation.RelationParametre_TypeElement.SuppressionAutomatique && relation.DossierSuivi.Row.RowState != DataRowState.Deleted)
					{
						bool bIsRemplace = false;
						foreach ( CRelationDossierSuivi_Element rel in relation.DossierSuivi.RelationsElements )
						{
							if ( rel.RelationParametre_TypeElement.Id == relation.RelationParametre_TypeElement.Id )
							{
								bIsRemplace = true;
								break;
							}
						}
						if ( !bIsRemplace )
						{
							result = relation.DossierSuivi.Delete();
							if ( !result )
								return result;
						}
					}
				}
			}
			if ( !bOldMode )
				contexte.EndModeDeconnecteSansSauvegardeEtSansReject();
			return result;
		}



	}
}
