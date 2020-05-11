using System;
using System.Data;
using sc2i.data;
using sc2i.common;
using sc2i.data.serveur;
using spv.data;
using System.Collections;

namespace spv.data.serveur
{
    public class CSpvTypeAccesAlarmeServeur : CObjetServeur
	{
		
		///////////////////////////////////////////////////////////////
		public CSpvTypeAccesAlarmeServeur ( int nIdSession )
			:base(nIdSession)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CSpvTypeAccesAlarme.c_nomTable;
		}
		
		///////////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees ( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CSpvTypeAccesAlarme typeAcces = objet as CSpvTypeAccesAlarme;

				if (typeAcces.CategorieAccesAlarme == null)
					result.EmpileErreur(I.T("Access type should be defined|2"));
                else
                {
                    if (typeAcces.Row.RowState == DataRowState.Modified && 
                        typeAcces.CodeCategorieAcces != (int) typeAcces.Row[CSpvTypeAccesAlarme.c_champACCES_CATEGORIE, DataRowVersion.Original])
                        result.EmpileErreur(I.T("Access type isn't modifiable|50001"));

                    if (typeAcces.CategorieAccesAlarme == ECategorieAccesAlarme.TrapSnmp)
                    {
                        if (typeAcces.NumeroIANA == null || typeAcces.TrapGenerique == null || typeAcces.TrapSpecifique == null)
                            result.EmpileErreur(I.T("For trap type, fill field iana number, generic trap and specific trap|50022"));
                        else if (typeAcces.TrapGenerique < 0 || typeAcces.TrapGenerique > 6)
                            result.EmpileErreur(I.T("Generic trap should be between 0 and 6|50023"));
                        else if (typeAcces.TrapGenerique < 6 && typeAcces.TrapSpecifique != 0)
                            result.EmpileErreur(I.T("For a generic trap, specific trap should be 0|50024"));
                        else if (typeAcces.TrapGenerique >= 0 && typeAcces.TrapGenerique < 6 && typeAcces.NumeroIANA != 0)
                            result.EmpileErreur(I.T("For a generic trap, IANA number should be 0|50025"));
                    }
                }
				if (typeAcces.NomAcces == null || typeAcces.NomAcces == "")
					result.EmpileErreur(I.T("Access type should have a name|3"));


                if ((typeAcces.SpvSite != null || typeAcces.SpvLiai != null)
                    && typeAcces.CodeCategorieAcces != (int)ECategorieAccesAlarme.SortieBoucle)
                {
                    CCategorieAccesAlarme category = new CCategorieAccesAlarme(ECategorieAccesAlarme.SortieBoucle);

                    result.EmpileErreur(I.T("Only acces type @1 is allowed for this object|60008", category.Libelle));
                }

                CSpvAlarmGeree alarmgeree = typeAcces.GetAlarmeGereeAvecCreationSuppression();
                if ( alarmgeree != null && alarmgeree.AlarmgereeFreqPeriod!=null && 
                    alarmgeree.AlarmgereeFreqPeriod<1)
                {
                    result.EmpileErreur(I.T("Frequent alarm period must be grater then 1|60063"));
                }
                
			}
			catch ( Exception e )
			{
				result.EmpileErreur( new CErreurException ( e ) );
			}
			return result;
		}
		
		///////////////////////////////////////////////////////////////
		public override Type GetTypeObjets()
		{
			return typeof(CSpvTypeAccesAlarme);
		}

		///////////////////////////////////////////////////////////////
		public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
		{
			CResultAErreur result = base.TraitementAvantSauvegarde(contexte);
			if (!result)
				return result;
			DataTable table = contexte.Tables[GetNomTable()];
			if (table == null)
				return result;
			ArrayList lstRows = new System.Collections.ArrayList(table.Rows);
            CSpvTypeAccesAlarme spvType;
			foreach (DataRow row in lstRows)
			{
				if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified)
				{
					spvType = new CSpvTypeAccesAlarme(row);
					//spvType.CalculeUnicite();
                    CSpvTypeq spvTypeq = spvType.SpvTypeq;
                    if (spvTypeq != null)
                        if (row.RowState == DataRowState.Added)
                            result = spvType.GenAccesAlarmeEquips();
                        else
                            result = spvType.MajAccesAlarmeEquips();


                 /*   if (spvType.AlarmeGeree == null)
                    {
                        CSpvAlarmGeree spvAlarmGeree = new CSpvAlarmGeree(contexte);
                        spvAlarmGeree.CreateNewInCurrentContexte();
                        spvAlarmGeree.TypeAccesAlarme = spvType;                        
                    }
                    if (spvType.AlarmeGeree != null)
                    {
                        spvType.AlarmeGeree.Alarmgeree_Name = spvType.NomAcces;
                        //spvType.AlarmeGeree.AlarmgereeUnicity = spvType.UniciteAcces;
                    }*/

                    CSpvAlarmGeree spvAlarmGeree = spvType.GetAlarmeGereeAvecCreationSuppression();
                    if (spvAlarmGeree != null)
                    {
                        spvAlarmGeree.Alarmgeree_Name = spvType.NomAcces;                    

                    }

					// Calcul de l'unicité
					//spvType.CalculeUnicite();

				}
                else if (row.RowState == DataRowState.Deleted)
                {
                    spvType = new CSpvTypeAccesAlarme(row);
                    result = spvType.TraitementDelete();
                }
			}
			return result;
		}

        protected override CFiltreData GetMyFiltreSysteme()
        {
            return new CFiltreData(CSpvTypeAccesAlarme.c_champACCES_CATEGORIE + " IN (@1, @2, @3, @4, @5) and ( "
                + CSpvTypeAccesAlarme.c_champSITE_ID + " is not null or "
                + CSpvTypeAccesAlarme.c_champLIAI_ID + " is not null or "
                + CSpvTypeAccesAlarme.c_champTYPEQ_ID + " is not null)" , 
                  ECategorieAccesAlarme.AlarmeGSite, ECategorieAccesAlarme.CommandeCommut,
                  ECategorieAccesAlarme.EntreeBoucle, ECategorieAccesAlarme.SortieBoucle,
                  ECategorieAccesAlarme.TrapSnmp);           
        }
	}
}
