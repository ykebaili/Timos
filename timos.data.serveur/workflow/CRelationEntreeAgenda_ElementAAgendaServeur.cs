using System;
using System.Data;
using System.Collections;

using sc2i.common;
using sc2i.data;
using sc2i.data.serveur;
using sc2i.data.dynamic;
using timos.acteurs;
using sc2i.multitiers.client;

namespace sc2i.workflow.serveur
{
	/// <summary>
	/// Description résumée de Class1.
	/// </summary>
	public class CRelationEntreeAgenda_ElementAAgendaServeur : CObjetServeur
	{
		/// //////////////////////////////////////////////////
#if PDA
		public CRelationEntreeAgenda_ElementAAgendaServeur()
			:base ()
		{
			
		}
#endif
		/// //////////////////////////////////////////////////
		public CRelationEntreeAgenda_ElementAAgendaServeur( int nIdSession )
			:base ( nIdSession )
		{
			
		}

		//////////////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CRelationEntreeAgenda_ElementAAgenda.c_nomTable;
		}

		//////////////////////////////////////////////////////////////////////
		public override Type GetTypeObjets()
		{
			return typeof(CRelationEntreeAgenda_ElementAAgenda);
		}

		//////////////////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{	
				CRelationEntreeAgenda_ElementAAgenda rel = (CRelationEntreeAgenda_ElementAAgenda)objet;

				return result;
			}
			catch ( Exception e )
			{
				result.EmpileErreur(new CErreurException(e));
				result.EmpileErreur(I.T("Error in the data of Diary Entry|297"));
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
					CRelationEntreeAgenda_ElementAAgenda relation = new CRelationEntreeAgenda_ElementAAgenda ( row );
					relation.VersionToReturn = DataRowVersion.Original;
					if ( relation.RelationTypeEntree_TypeElement.SuppressionAutomatique && relation.EntreeAgenda.Row.RowState != DataRowState.Deleted)
					{
						bool bIsRemplace = false;
						foreach ( CRelationEntreeAgenda_ElementAAgenda rel in relation.EntreeAgenda.RelationsElementsAgenda )
						{
							if ( rel.RelationTypeEntree_TypeElement.Id == relation.RelationTypeEntree_TypeElement.Id )
							{
								bIsRemplace = true;
								break;
							}
						}
						if ( !bIsRemplace )
						{
							result = relation.EntreeAgenda.Delete();
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
