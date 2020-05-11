using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

using timos.data;

namespace timos.data.serveur
{
    /// <summary>
    /// Description résumée de COperationServeur.
    /// </summary>
    public class COperationServeur : CObjetServeur
    {
        //-------------------------------------------------------------------
        public COperationServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return COperation.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			
            try
			{
                COperation operation = (COperation)objet;

				if ( operation.TypeOperation == null )
					result.EmpileErreur(I.T( "The Operation type cannot be null|152"));

                if (result)
                    result = operation.VerifieCoherenceHierarchique();

                if (result && operation.TypeOperation != null)
                {
                    // Equipement lié
                    if (operation.TypeOperation.IsLieeAEquipement)
                    {
                        if (operation.ElementAOperationPrevisionnelle is CListeOperations &&
                            operation.TypeEquipement == null)
                        {
                            result.EmpileErreur(I.T("The linked Equipment Type must be defined|361"));
                        }
                        // Lié à une Intervention ou à une Fraction, l'équipement doit être renseigné
                        if (operation.ElementAOperationPrevisionnelle is CIntervention &&
                            operation.Equipement == null)
                        {
                            result.EmpileErreur(I.T("The linked Equipment must be defined|362"));
                        }
                    }
                }

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
            return typeof(COperation);
		}
		
		//-------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		/// <param name="contexte"></param>
		/// <returns></returns>
        public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
		{
			CResultAErreur result = base.TraitementAvantSauvegarde(contexte);
			if (!result)
				return result;
			DataTable table = contexte.Tables[GetNomTable()];
			if ( table == null )
				return result;
			ArrayList lst = new ArrayList(table.Rows);

			Dictionary<CFractionIntervention, bool> lstFractions = new Dictionary<CFractionIntervention,bool>();
			foreach (DataRow row in table.Rows)
			{
				if (row.RowState == DataRowState.Added)
				{
					COperation operation = new COperation(row);
                    if(operation.FractionIntervention != null)
					    lstFractions[operation.FractionIntervention] = true;

                    CTypeOperation opType = operation.TypeOperation;

                    // Propage le lien de l'opération vers la phase si l'option est activée
                    if (opType != null && opType.PropagerSurPhaseApplique)
                    {
                        if (operation.FractionIntervention != null &&
                            operation.FractionIntervention.Intervention != null)
                        {
                            CPhaseTicket phase = operation.FractionIntervention.Intervention.PhaseTicket;
                            if(phase != null)
                                operation.PhaseTicket = phase;                            
                        }
                    }
				}
			}
            
			foreach (CFractionIntervention fraction in lstFractions.Keys)
				fraction.UpdateEtat();
			return result;
		}
    }
}
