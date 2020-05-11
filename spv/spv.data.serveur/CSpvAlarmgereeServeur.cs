using System;
using System.Data;
using System.Collections;
using System.Data.OracleClient;

using sc2i.data;
using sc2i.common;
using sc2i.data.serveur;
using spv.data;


namespace spv.data.serveur
{
	public class CSpvAlarmgereeServeur : CObjetServeur
	{
		
		///////////////////////////////////////////////////////////////
		public CSpvAlarmgereeServeur ( int nIdSession )
			:base(nIdSession)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CSpvAlarmGeree.c_nomTable;
		}
		
		///////////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees ( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CSpvAlarmGeree alarmgeree = (CSpvAlarmGeree)objet;
                if (alarmgeree.Automatic_MIB)
	            {
                    if (alarmgeree.AlarmgereeSeuilNom == null || alarmgeree.AlarmgereeSeuilNom.Length == 0)
                        result.EmpileErreur (I.T("When <Automatic MIB> is checked for the threshold, threshold name should be filled|50003"));

                    else if (alarmgeree.TypeAccesAlarme.SpvTypeq.TypeqModulesMIB.Count <= 0)
                        result.EmpileErreur (I.T("When <Automatic MIB> is checked for the threshold, MIBs should be associated with the equipement type|50002"));

                    /*
                    CListeObjetsDonnees lst = new CListeObjetsDonnees(objet.ContexteDonnee, typeof(CSpvMibobj));
                    lst.Filtre = new CFiltreData(CSpvMibobj.c_champMIBOBJ_NAME + "=@1", alarmgeree.AlarmgereeSeuilNom);
                    int nNb = lst.Count;

                    if(nNb<=0)
                        result.EmpileErreur(I.T("@1 is not found in the MIB|60000",alarmgeree.AlarmgereeSeuilNom));
                     * */
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
			return typeof(CSpvAlarmGeree);
		}


        public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
        {
            CResultAErreur result = CResultAErreur.True;

            DataTable dt = contexte.Tables[CSpvAlarmGeree.c_nomTable];
            if (dt != null)
            {
                ArrayList rows = new ArrayList(dt.Rows);
                CSpvAlarmGeree spvAlarmGeree;

                foreach (DataRow row in rows)
                {
                    if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified)
                    {
                        spvAlarmGeree = new CSpvAlarmGeree(row);
                        spvAlarmGeree.CalculeUnicite();
                        
                       if (spvAlarmGeree.Automatic_MIB &&
                            spvAlarmGeree.AlarmgereeSeuilNom != null &&
                            spvAlarmGeree.AlarmgereeSeuilNom.Length > 0 &&
                            spvAlarmGeree.TypeAccesAlarme.SpvTypeq.TypeqModulesMIB.Count > 0)
                            result = spvAlarmGeree.MibAuto();

                        if (row.RowState == DataRowState.Modified &&
                            (int)row[CSpvAlarmGeree.c_champALARMGEREE_MIN, DataRowVersion.Original] !=
                            spvAlarmGeree.DureeMin)
                        {
                            CSpvMessalrm spvMessalrm = new CSpvMessalrm(contexte);
                            spvMessalrm.CreateNewInCurrentContexte();
                            spvMessalrm.MessageModifTempoPourSaturneIS(spvAlarmGeree.Id);
                        }

                    }
                }
            }
            return result;           
        }
	}
}
