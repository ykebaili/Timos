using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;

namespace timos.data
{
	/// <summary>
	/// Description résumée de CParametrageNiveauServeur.
	/// </summary>
	public class CParametrageNiveauServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
		public CParametrageNiveauServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CParametrageNiveau.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CParametrageNiveau parametrageNiveau = (CParametrageNiveau)objet;

				/*if ( parametrageNiveau.Libelle == "")
					result.EmpileErreur(I.T("The label of level setting cannot be empty|188"));
*/
				/*if(!parametrageNiveau.CanEdit)
					result.EmpileErreur(I.T( "Coordinate setting currently used by objects : impossible to carry out the operation|190"));
				*/
				//Verification si la taille + le premier indice ne dépasse pas le format de numérotation
				if(parametrageNiveau.DernierIndice > parametrageNiveau.FormatNumerotation.IndexMax)
					result.EmpileErreur(I.T("The first reference @1 and size @2 allow to reach @3, but  the numbering format @4 is limited to @5|191",parametrageNiveau.PremiereReference,parametrageNiveau.Taille.ToString(),parametrageNiveau.DerniereReference,parametrageNiveau.FormatNumerotation.Libelle,parametrageNiveau.FormatNumerotation.ReferenceMax));



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
			return typeof(CParametrageNiveau);
		}
		//-------------------------------------------------------------------
		public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
		{
			CResultAErreur  result = base.TraitementAvantSauvegarde(contexte);
			if (!result)
				return result;
			DataTable table = contexte.Tables[GetNomTable()];
			if (table == null)
				return result;
			ArrayList lst = new ArrayList(table.Rows);
			foreach (DataRow row in lst)
			{
				if (row.RowState == DataRowState.Modified)
				{
					CParametrageNiveau parametrage = new CParametrageNiveau(row);
					parametrage.ParametrageSystemeCoordonnees.ForceChangementSyncSession();
				}
			}
			return result;

		}
	}
}
