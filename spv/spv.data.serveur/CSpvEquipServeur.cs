using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;

using sc2i.data;
using sc2i.common;
using sc2i.data.serveur;
using spv.data;
using timos.data;
using System.Data.OracleClient;

namespace spv.data.serveur
{
    [AutoExec("Autoexec")]
	public class CSpvEquipServeur : CObjetServeur
	{
       
        public static void Autoexec()
        {
            CGestionnaireHookTraitementAvantSauvegarde.RegisterHook(typeof(CEquipementLogique), PropagerCEquipement);
        }

		///////////////////////////////////////////////////////////////
		public CSpvEquipServeur ( int nIdSession )
			:base(nIdSession)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CSpvEquip.c_nomTable;
		}
		
		///////////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees ( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				//TODO : Insérer la logique de vérification de donnée

                // Saisie obligatoire de l'un des éléments de coordonnées
                CSpvEquip spvEquip = objet as CSpvEquip;
                if (spvEquip.CommentairePourSituer == null && spvEquip.Reference == null &&
                    spvEquip.AdresseIP == null)
                    throw new Exception(I.T("Mandatory supervision fields : Comment or Subrack or reference or IP Address |4"));

				// Si le type d'équipement est EQUIP MEDIATION (type système)
                if (spvEquip.TypeEquipement.Id == CSpvTypeq.c_TypeEquipMediationId)
				{
					if (spvEquip.IndexSnmp == null || spvEquip.IndexSnmp.Length == 0)
						throw new Exception(I.T("Snmp index field should be filled when equipement type is @1|50014", CSpvTypeq.c_strTypeEquipMediation));

					int nIndex = Convert.ToInt32(spvEquip.IndexSnmp);
					if (nIndex < CSpvEquip.c_nMinSnmpIndexMediation || nIndex > CSpvEquip.c_nMaxSnmpIndexMediation)
						throw new Exception(I.T("Snmp index should be between @1 and @2 when equipment type is @3|50015", 
							CSpvTypeq.c_strTypeEquipMediation,
							CSpvEquip.c_nMinSnmpIndexMediation.ToString(),
							CSpvEquip.c_nMaxSnmpIndexMediation.ToString()));

                    int nPos = spvEquip.CommentairePourSituer.IndexOf('/');
                    if (nPos < 0)
                        throw new Exception(I.T("For equipment type EQUIP MEDIATION, equipement label should be like 'mediation_name/service_name'|50016"));

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
			return typeof(CSpvEquip);
		}



        private static CSpvEquip GetSpvEquip(DataRow row)
        {
            CSpvEquip spvEquip;
            CEquipementLogique equipement = new CEquipementLogique(row);
			if (equipement.Site != null)
			{
				spvEquip = CSpvEquip.GetSpvEquipFromEquipement(equipement) as CSpvEquip;
				if (spvEquip == null)
				{
					spvEquip = CSpvEquip.GetSpvEquipFromEquipementAvecCreation(equipement);
				}
				spvEquip.CopyFromObjetTimos(equipement);
				return spvEquip;
			}
			return null;
        }


        ////////////////////////////////////////////////////////////////////
        public static void PropagerCEquipement(CContexteDonnee contexte, Hashtable tableData, ref CResultAErreur result)
        {
            // Traitement CEquipementLogique
            DataTable dt = contexte.Tables[CEquipementLogique.c_nomTable];
            if (dt != null)
            {
                ArrayList rows = new ArrayList(dt.Rows);
                CSpvEquip spvEquip;

                foreach (DataRow row in rows)
                {
                    if (row.RowState != DataRowState.Unchanged)
                    {
                        switch (row.RowState)
                        {
                            case DataRowState.Added:
                            case DataRowState.Modified:
                                spvEquip = CSpvEquipServeur.GetSpvEquip(row);
                                if (spvEquip == null)
                                    continue;

                                break;

                            default:
                                break;
                        }
                    }

                }//foreach (DataRow row in rows)
            }// if (dt != null)

            // Traitement CSpvEquip
            DataTable table = contexte.Tables[CSpvEquip.c_nomTable];
            if (table == null)
                return;

            List<DataRow> lstCrees = (List<DataRow>)table.ExtendedProperties[CDivers.c_cleRowCrees];
            if (lstCrees != null)
                table.ExtendedProperties.Clear();

            lstCrees = new List<DataRow>();

            ArrayList lstRows = new System.Collections.ArrayList(table.Rows);
            foreach (DataRow row in lstRows)
            {
                // Stockage temporaire des enregistrements dans une liste
                // pour traitement dans AfterSave (messages pour
                // EmessEM). Car à ce niveau, on ne dispose pas de l'ID de l'équipement
                CSpvEquip spvEquip;
                if (row.RowState == DataRowState.Added)
                {
                    spvEquip = new CSpvEquip(row);
                    if (spvEquip.ASuperviser)
                        lstCrees.Add(row);

                    spvEquip.TraitementMetier(row.RowState);
                }
                else if (row.RowState == DataRowState.Modified)
                {
                    spvEquip = new CSpvEquip(row);
                    spvEquip.TraitementMetier(row.RowState);

                    if (((bool)spvEquip.Row[CSpvEquip.c_champEQUIP_TOSURV, DataRowVersion.Original] == true &&
                        !spvEquip.ASuperviser) || (
                        (bool)spvEquip.Row[CSpvEquip.c_champEQUIP_TOSURV, DataRowVersion.Original] == true &&
                         spvEquip.ASuperviser && (
                         spvEquip.Row[CSpvEquip.c_champEQUIP_ADDRIP, DataRowVersion.Original] !=
                         spvEquip.Row[CSpvEquip.c_champEQUIP_ADDRIP] || (
                         spvEquip.Row[CSpvEquip.c_champEQUIP_EMNAME, DataRowVersion.Original] !=
                         spvEquip.Row[CSpvEquip.c_champEQUIP_EMNAME]))))
                    {
                        // Message pour EmessEM
                        CSpvMessem spvMessem = new CSpvMessem(spvEquip.ContexteDonnee);
                        spvMessem.CreateNewInCurrentContexte();
                        spvMessem.FormatMessDelEquip(spvEquip.Id,
                            (string)spvEquip.Row[CSpvEquip.c_champEQUIP_ADDRIP, DataRowVersion.Original],
                            (string)spvEquip.Row[CSpvEquip.c_champEQUIP_EMNAME, DataRowVersion.Original],
                            spvEquip.ASuperviser);
                    }

                    if (((bool)spvEquip.Row[CSpvEquip.c_champEQUIP_TOSURV, DataRowVersion.Original] == false &&
                        spvEquip.ASuperviser) || (
                        (bool)spvEquip.Row[CSpvEquip.c_champEQUIP_TOSURV, DataRowVersion.Original] == true &&
                        spvEquip.ASuperviser && (
                        spvEquip.Row[CSpvEquip.c_champEQUIP_ADDRIP, DataRowVersion.Original] !=
                        spvEquip.Row[CSpvEquip.c_champEQUIP_ADDRIP] || (
                        spvEquip.Row[CSpvEquip.c_champEQUIP_EMNAME, DataRowVersion.Original] !=
                        spvEquip.Row[CSpvEquip.c_champEQUIP_EMNAME]))))
                    {
                        // Message pour EmessEM
                        CSpvMessem spvMessem = new CSpvMessem(spvEquip.ContexteDonnee);
                        spvMessem.CreateNewInCurrentContexte();
                        spvMessem.FormatMessCreEquip(spvEquip.Id);
                    }
                }
                else if (row.RowState == DataRowState.Deleted)
                {
                    spvEquip = new CSpvEquip(row);
                    if ((bool)spvEquip.Row[CSpvEquip.c_champEQUIP_TOSURV, DataRowVersion.Original] == true)
                    {
                        // Message pour EmessEM
                        CSpvMessem spvMessem = new CSpvMessem(spvEquip.ContexteDonnee);
                        spvMessem.CreateNewInCurrentContexte();
                        spvMessem.FormatMessDelEquip(
                            (Int32)spvEquip.Row[CSpvEquip.c_champEQUIP_ID, DataRowVersion.Original],
                            (string)spvEquip.Row[CSpvEquip.c_champEQUIP_ADDRIP, DataRowVersion.Original],
                            (string)spvEquip.Row[CSpvEquip.c_champEQUIP_EMNAME, DataRowVersion.Original],
                            (bool)spvEquip.Row[CSpvEquip.c_champEQUIP_TOSURV, DataRowVersion.Original]);
                    }

                    if ((string)spvEquip.Row[CSpvEquip.c_champTYPEQ_NOM, DataRowVersion.Original] == CSpvTypeq.c_strTypeEquipMediation)
                    {
                        spvEquip.SuppressionTestEM(
                            (string)spvEquip.Row[CSpvEquip.c_champSITE_EQUIP_COMMENT, DataRowVersion.Original],
                            (string)spvEquip.Row[CSpvEquip.c_champEQUIP_INDEXSNMP, DataRowVersion.Original]);
                        CSpvTestem testEM = new CSpvTestem(spvEquip.ContexteDonnee);
                    }
                }
            }
            table.ExtendedProperties.Add(CDivers.c_cleRowCrees, lstCrees);
        }

        /*
        public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
        {
            CResultAErreur result = base.TraitementAvantSauvegarde(contexte);

            if (!result)
                return result;

            DataTable table = contexte.Tables[GetNomTable()];
            if (table == null)
                return result;

            List<DataRow> lstCrees = new List<DataRow>();

            ArrayList lstRows = new System.Collections.ArrayList(table.Rows);
            foreach (DataRow row in lstRows)
            {
                // Stockage temporaire des enregistrements dans une liste
                // pour traitement dans AfterSave (messages pour
                // EmessEM). Car à ce niveau, on ne dispose pas de l'ID de l'équipement
                CSpvEquip spvEquip;
                if (row.RowState == DataRowState.Added)
                {
                    spvEquip = new CSpvEquip(row);
                    if (spvEquip.ASuperviser)
                        lstCrees.Add(row);

                    spvEquip.TraitementMetier(row.RowState);
                }
                else if (row.RowState == DataRowState.Modified)
                {
                    spvEquip = new CSpvEquip(row);
                    spvEquip.TraitementMetier(row.RowState);

                    if (((bool)spvEquip.Row[CSpvEquip.c_champEQUIP_TOSURV, DataRowVersion.Original] == true &&
                        !spvEquip.ASuperviser) || (
                        (bool)spvEquip.Row[CSpvEquip.c_champEQUIP_TOSURV, DataRowVersion.Original] == true &&
                         spvEquip.ASuperviser && (
                         spvEquip.Row[CSpvEquip.c_champEQUIP_ADDRIP, DataRowVersion.Original] !=
                         spvEquip.Row[CSpvEquip.c_champEQUIP_ADDRIP] || (
                         spvEquip.Row[CSpvEquip.c_champEQUIP_EMNAME, DataRowVersion.Original] !=
                         spvEquip.Row[CSpvEquip.c_champEQUIP_EMNAME]))))
                    {
                        // Message pour EmessEM
                        CSpvMessem spvMessem = new CSpvMessem(spvEquip.ContexteDonnee);
                        spvMessem.CreateNewInCurrentContexte();
                        spvMessem.FormatMessDelEquip(spvEquip.Id,
                            (string)spvEquip.Row[CSpvEquip.c_champEQUIP_ADDRIP, DataRowVersion.Original],
                            (string)spvEquip.Row[CSpvEquip.c_champEQUIP_EMNAME, DataRowVersion.Original],
                            spvEquip.ASuperviser);
                    }

                    if (((bool)spvEquip.Row[CSpvEquip.c_champEQUIP_TOSURV, DataRowVersion.Original] == false &&
                        spvEquip.ASuperviser) || (
                        (bool)spvEquip.Row[CSpvEquip.c_champEQUIP_TOSURV, DataRowVersion.Original] == true &&
                        spvEquip.ASuperviser && (
                        spvEquip.Row[CSpvEquip.c_champEQUIP_ADDRIP, DataRowVersion.Original] !=
                        spvEquip.Row[CSpvEquip.c_champEQUIP_ADDRIP] || (
                        spvEquip.Row[CSpvEquip.c_champEQUIP_EMNAME, DataRowVersion.Original] !=
                        spvEquip.Row[CSpvEquip.c_champEQUIP_EMNAME]))))
                    {
                        // Message pour EmessEM
                        CSpvMessem spvMessem = new CSpvMessem(spvEquip.ContexteDonnee);
                        spvMessem.CreateNewInCurrentContexte();
                        spvMessem.FormatMessCreEquip(spvEquip.Id);
                    }
                }
                else if (row.RowState == DataRowState.Deleted)
                {
                    spvEquip = new CSpvEquip(row);
                    if ((bool)spvEquip.Row[CSpvEquip.c_champEQUIP_TOSURV, DataRowVersion.Original] == true)
                    {
                        // Message pour EmessEM
                        CSpvMessem spvMessem = new CSpvMessem(spvEquip.ContexteDonnee);
                        spvMessem.CreateNewInCurrentContexte();
                        spvMessem.FormatMessDelEquip(spvEquip.Id,
                            (string)spvEquip.Row[CSpvEquip.c_champEQUIP_ADDRIP, DataRowVersion.Original],
                            (string)spvEquip.Row[CSpvEquip.c_champEQUIP_EMNAME, DataRowVersion.Original],
                            spvEquip.ASuperviser);
                    }
                }
            }
            table.ExtendedProperties.Add(CDivers.c_cleRowCrees, lstCrees);
            return result;
        }*/

		public override IDataAdapter GetDataAdapter(DataRowState rowsPriseEnCharge, params string[] champsExclus)
		{
			IDataAdapter adapter = base.GetDataAdapter(rowsPriseEnCharge, champsExclus);
			C2iOracleDataAdapter oracleAdapter = adapter as C2iOracleDataAdapter;
			if (oracleAdapter != null)
			{
				oracleAdapter.RowUpdated += new OracleRowUpdatedEventHandler(OnRowUpdated);
			}
			return oracleAdapter;
		}

		void OnRowUpdated(object sender, OracleRowUpdatedEventArgs e)
		{
			if (e.StatementType == StatementType.Insert ||
				e.StatementType == StatementType.Update)
			{
				C2iOracleDataAdapter adapter = sender as C2iOracleDataAdapter;
				CSpvEquip equipement = new CSpvEquip(e.Row);
				bool bSuperviser = equipement.ASuperviser;
                if (e.StatementType == StatementType.Insert ||
					e.Row[CSpvEquip.c_champEQUIP_TOSURV] != e.Row[CSpvEquip.c_champEQUIP_TOSURV, DataRowVersion.Original])
				{
					int nValeurMasquage = bSuperviser ? 0 : 2;
					OracleCommand cmd = e.Command.Connection.CreateCommand();
					cmd.Transaction = e.Command.Transaction;
					cmd.CommandText = "Begin SetMaskAdmEquip(" +
						equipement.Id + "," + nValeurMasquage + "); end;";
					cmd.ExecuteScalar();
				}
			}			
		}
        

        public override CResultAErreur TraitementApresSauvegarde(CContexteDonnee contexte, bool bOperationReussie)
        {
            CResultAErreur result = base.TraitementApresSauvegarde(contexte, bOperationReussie);

            if (!result)
                return result;

            DataTable table = contexte.Tables[GetNomTable()];
            if (table == null)
                return result;

            List<DataRow> lstCrees = (List<DataRow>)table.ExtendedProperties[CDivers.c_cleRowCrees];
            if (lstCrees == null)
                return result;

            foreach (DataRow row in lstCrees)
            {
				CSpvEquip spvEquip = new CSpvEquip(row);
                if (spvEquip.ASuperviser)
                {
                    // Création du message dans MessEm
                    CSpvMessem spvMessem = new CSpvMessem(spvEquip.ContexteDonnee);
                    spvMessem.CreateNewInCurrentContexte();
                    spvMessem.FormatMessCreEquip(spvEquip.Id);
                }
            }

            return result;
		}

	}
}
