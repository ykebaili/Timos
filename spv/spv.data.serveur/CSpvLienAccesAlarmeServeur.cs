using System;
using System.Data;
using System.Data.OracleClient;

using sc2i.data;
using sc2i.common;
using sc2i.data.serveur;
using spv.data;
using spv.data.ConsultationAlarmes;
using System.Collections;


namespace spv.data.serveur
{
	public class CSpvLienAccesAlarmeServeur : CObjetServeur
	{
		
		///////////////////////////////////////////////////////////////
		public CSpvLienAccesAlarmeServeur ( int nIdSession )
			:base(nIdSession)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CSpvLienAccesAlarme.c_nomTable;
		}
		
		///////////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees ( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
                CSpvLienAccesAlarme lienAccesAlarme = objet as CSpvLienAccesAlarme;

                if (lienAccesAlarme.AccesAlarmeOne == null)
                    result.EmpileErreur(I.T("Alarm access should be defined|60003"));
                if (lienAccesAlarme.AccesAlarmeTwo == null)
                    result.EmpileErreur(I.T("N° Card Access should be defined|60001"));
                if (lienAccesAlarme.CodeGravite == null)
                    result.EmpileErreur(I.T("Severity  should be defined|60002"));
                if (lienAccesAlarme.MaskAdminMin > lienAccesAlarme.MaskAdminMax)
                    result.EmpileErreur(I.T("Administator masking start date is after the end date|60004"));
                if (lienAccesAlarme.MaskBriMin > lienAccesAlarme.MaskBriMax)
                    result.EmpileErreur(I.T("Operating agent masking start date is after the end date|60005"));

                // Chaque accès (entrée ou sortie alarme) ne peut être câblé qu'une fois
                /*
                CFiltreData filtre = new CFiltreData("(" 
                    + CSpvLienAccesAlarme.c_champACCES1_ID + "=@1 or ("
                    + CSpvLienAccesAlarme.c_champACCES2_ID + "=@2 and @2 <> 0) or ("
                    + CSpvLienAccesAlarme.c_champACCES1_ID + "=@2 and @2 <> 0) or "
                    + CSpvLienAccesAlarme.c_champACCES2_ID + "=@1) and "
                    + CSpvLienAccesAlarme.c_champACCES_ACCESC_ID + "<>@3",
                    lienAccesAlarme.AccesAlarmeOne.Id, lienAccesAlarme.AccesAlarmeTwo.Id, lienAccesAlarme.Id);*/
                CFiltreData filtre = new CFiltreData("(("
                    + CSpvLienAccesAlarme.c_champACCES1_ID + "=@1 and " 
                    + CSpvLienAccesAlarme.c_champACCES2_ID + "=@2) or ("
                    + CSpvLienAccesAlarme.c_champACCES1_ID + "=@2 and " 
                    + CSpvLienAccesAlarme.c_champACCES2_ID + "=@1)) and ("
                    + CSpvLienAccesAlarme.c_champACCES1_ID + " <> 0 or "
                    + CSpvLienAccesAlarme.c_champACCES2_ID + " <> 0) and "
                    + CSpvLienAccesAlarme.c_champACCES_ACCESC_ID + " <> @3",
                    lienAccesAlarme.AccesAlarmeOne.Id, lienAccesAlarme.AccesAlarmeTwo.Id, lienAccesAlarme.Id);
                CSpvLienAccesAlarme autreLien = new CSpvLienAccesAlarme(objet.ContexteDonnee);
                if (autreLien.ReadIfExists(filtre))
                    result.EmpileErreur(I.T("Alarm access already wired (input or output)|50006"));

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
			return typeof(CSpvLienAccesAlarme);
		}


   /*     public override IDataAdapter GetDataAdapter(DataRowState rowsPriseEnCharge, params string[] champsExclus)
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
            if (e.StatementType == StatementType.Insert)
            {
                CSpvLienAccesAlarme accesAccesc = new CSpvLienAccesAlarme(e.Row);
                OracleCommand cmd = e.Command.Connection.CreateCommand();
                cmd.Transaction = e.Command.Transaction;
                if (accesAccesc.Surveiller == false && accesAccesc.SpvAlarmgeree != null)
                {
                    cmd.CommandText = "Begin SetMaskAdmAccess (" +
                        accesAccesc.Id + ",2); end;";
                    cmd.ExecuteScalar();
                }
            }
        }*/

        public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
        {
            CResultAErreur result = base.TraitementAvantSauvegarde(contexte);

            if (!result)
                return result;

            DataTable table = contexte.Tables[GetNomTable()];
            if (table == null)
                return result;

            try
            {
                ArrayList lstRows = new System.Collections.ArrayList(table.Rows);
                foreach (DataRow row in lstRows)
                {

                    if (row.RowState == DataRowState.Modified)
                    {
                        Int32 acces1OriginalId = (Int32)row[CSpvLienAccesAlarme.c_champACCES1_ID, DataRowVersion.Original];
                        Int32 acces1CurrentId = (Int32)row[CSpvLienAccesAlarme.c_champACCES1_ID, DataRowVersion.Current];
                        Int32 acces2OriginalId = (Int32)row[CSpvLienAccesAlarme.c_champACCES2_ID, DataRowVersion.Original];
                        Int32 acces2CurrentId = (Int32)row[CSpvLienAccesAlarme.c_champACCES2_ID, DataRowVersion.Current];

                        if (acces1OriginalId != acces1CurrentId)
                        {
                            CSpvAccesAlarme acces1Original = new CSpvAccesAlarme(contexte);
                            if (acces1Original.ReadIfExists(acces1OriginalId))
                                acces1Original.AccesEtat = acces1Original.AccesEtat & 0xE;
                        }

                        if (acces2OriginalId != acces2CurrentId)
                        {
                            CSpvAccesAlarme acces2Original = new CSpvAccesAlarme(contexte);
                            if (acces2Original.ReadIfExists(acces2OriginalId))
                                acces2Original.AccesEtat = acces2Original.AccesEtat & 0xE;
                        }

                        // Mise à jour de la redondance de gravité dans l'enregistrement xxx_Rep.
                        CSpvLienAccesAlarme spvLienAccesAlarme = new CSpvLienAccesAlarme(row);
                        foreach (CSpvLienAccesAlarme_Rep spvLienAccesAlarmeRep in spvLienAccesAlarme.Acces_Accesc_Rep)
                        {
                            spvLienAccesAlarmeRep.CodeAlarmGrave = spvLienAccesAlarme.CodeGravite;
                        }

                        // Création du message à destination des IS lorsque la tempo
                        // de l'accès est modifiée
                        Int32? nOldDuree = (Int32?)row[CSpvLienAccesAlarme.c_champALARMGEREE_MIN, DataRowVersion.Original];
                        Int32? nNewDuree = spvLienAccesAlarme.DureeMin;
                        if (nOldDuree != null && nNewDuree != null && nOldDuree != nNewDuree &&
                            spvLienAccesAlarme.AccesAlarmeTwo.SpvEquip != null &&
                            spvLienAccesAlarme.AccesAlarmeTwo.SpvEquip.TypeEquipement.Id == CSpvTypeq.c_TypeCarteGTRId)
                        {
                            CSpvMessalrm spvMessAlrm = new CSpvMessalrm(contexte);
                            spvMessAlrm.CreateNewInCurrentContexte();
                            spvMessAlrm.MessageModifTempoPourSaturneIS(
                                spvLienAccesAlarme.AccesAlarmeTwo.SpvEquip.CommentairePourSituer,
                                spvLienAccesAlarme.AccesAlarmeTwo.NomAcces);
                        }
                    }

                    if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified)
                    {
                        CSpvLienAccesAlarme spvLienAccesAlarme = new CSpvLienAccesAlarme(row);

                        CSpvAccesAlarme acces1 = new CSpvAccesAlarme(contexte);
                        CSpvAccesAlarme acces2 = new CSpvAccesAlarme(contexte);

                        if (acces1.ReadIfExists(spvLienAccesAlarme.AccesAlarmeOne.Id))
                            acces1.AccesEtat = acces1.AccesEtat | 1;

                        if (acces2.ReadIfExists(spvLienAccesAlarme.AccesAlarmeTwo.Id))
                            acces2.AccesEtat = acces2.AccesEtat | 1;


                        if (row.RowState == DataRowState.Added)
                        {
                            /*
                            if (acces1.ReadIfExists(spvAccesAccesc.AccesAlarmeOne.Id))
                                spvAccesAccesc.SpvAlarmgeree = acces1.AlarmeGeree();*/

                            /* Sans doute ajouté pour le cas particulier des équipements de médiation
                             * à revoir car perturbe tous les autres cas
                            if (spvLienAccesAlarme.AccesAlarmeOne != spvLienAccesAlarme.SpvAccesAlarmeSysteme0())
                            {
                                spvLienAccesAlarme.SpvAlarmgeree = spvLienAccesAlarme.AccesAlarmeOne.AlarmeGeree();
                                spvLienAccesAlarme.BindingId = -3;  // Rechercher l'ID dans le before save
                            }*/

                            CSpvLienAccesAlarme_Rep lienTest = new CSpvLienAccesAlarme_Rep(contexte);
                            if (!lienTest.ReadIfExists(spvLienAccesAlarme.Id))
                            {
                                CSpvLienAccesAlarme_Rep spvLienAccesAlarmeRep = new CSpvLienAccesAlarme_Rep(contexte);
                                if (!spvLienAccesAlarmeRep.ReadIfExists(spvLienAccesAlarme.Id))
                                {
                                    spvLienAccesAlarmeRep.LienAccesAlarmes = spvLienAccesAlarme;
                                    spvLienAccesAlarmeRep.CodeAlarmGrave = spvLienAccesAlarme.CodeGravite;
                                    spvLienAccesAlarmeRep.CreateNewInCurrentContexte(new object[] { spvLienAccesAlarme.Id });

                                    if (spvLienAccesAlarme.SpvEquip != null &&
                                        spvLienAccesAlarme.SpvEquip.TypeEquipement.Id == CSpvTypeq.c_TypeEquipMediationId)
                                    {
                                        // Ne pas revalider la propriété AlarmCategory sur CSpvLienAccesAlarme_Rep
                                        // elle pose problème avec la contrainte check lorsque le framework
                                        // la remplit automatiquement avec espace lorsqu'elle est null.
                                        spvLienAccesAlarmeRep.Row[CSpvLienAccesAlarme_Rep.c_champALARM_CL] = CSpvEvenementReseau.c_strClasseSYST;
                                        int nAlarmNumObj = Convert.ToInt32(spvLienAccesAlarme.SpvEquip.IndexSnmp);
                                        spvLienAccesAlarmeRep.AlarmNumObj = nAlarmNumObj;
                                        spvLienAccesAlarmeRep.AlarmNumAl = spvLienAccesAlarme.SpvEquip.CommentairePourSituer;
                                        //Vérifier que les alarmes système fonctionnent sans la mise à jour
                                        //ci-dessous
                                        //spvLienAccesAlarmeRep.EQUIP_ID = spvLienAccesAlarme.SpvEquip.Id;
                                    }
                                }
                            }
                        }
                        else if (row.RowState == DataRowState.Modified)
                        {
                            // Constitution du message pour EmessEM
                            bool bOldASurveiller = (bool)row[CSpvLienAccesAlarme.c_champALARMGEREE_TOSURV, DataRowVersion.Original];
                            bool bNewASurveiller = spvLienAccesAlarme.Surveiller;
                            Int32? nOldDureeMin = (Int32?)row[CSpvLienAccesAlarme.c_champALARMGEREE_MIN, DataRowVersion.Original];
                            Int32? nNewDureeMin = spvLienAccesAlarme.DureeMin;
                            Int32? nOldFreqPeriode = (Int32?)row[CSpvLienAccesAlarme.c_champALARMGEREE_FREQD, DataRowVersion.Original];
                            Int32? nNewFreqPeriode = spvLienAccesAlarme.FreqPeriod;
                            Int32? nOldFreqNb = (Int32?)row[CSpvLienAccesAlarme.c_champALARMGEREE_FREQN, DataRowVersion.Original];
                            Int32? nNewFreqNb = spvLienAccesAlarme.FreqNb;

                            if (bOldASurveiller != bNewASurveiller ||
                                nOldDureeMin != nNewDureeMin ||
                                nOldFreqPeriode != nNewFreqPeriode ||
                                nOldFreqNb != nNewFreqNb)
                            {
                                CSpvMessem spvMessem = new CSpvMessem(contexte);
                                spvMessem.CreateNewInCurrentContexte();
                                if (!spvMessem.FormatMessAccesAlarme(spvLienAccesAlarme, row.RowState))
                                    spvMessem.CancelCreate();
                            }
                        }
                    }

                    if (row.RowState == DataRowState.Deleted)
                    {
                        Int32 acces1OriginalId = (Int32)row[CSpvLienAccesAlarme.c_champACCES1_ID, DataRowVersion.Original];
                        Int32 acces2OriginalId = (Int32)row[CSpvLienAccesAlarme.c_champACCES2_ID, DataRowVersion.Original];

                        CSpvAccesAlarme acces1Original = new CSpvAccesAlarme(contexte);
                        if (acces1Original.ReadIfExists(acces1OriginalId))
                            acces1Original.AccesEtat = acces1Original.AccesEtat & 0xE;

                        CSpvAccesAlarme acces2Original = new CSpvAccesAlarme(contexte);
                        if (acces2Original.ReadIfExists(acces2OriginalId))
                            acces2Original.AccesEtat = acces2Original.AccesEtat & 0xE;

                        Int32 nMaskBriMin =
                            (Int32)row[CSpvLienAccesAlarme.c_champMSKBRI_MIN, DataRowVersion.Original];

                        Int32 nMaskAdmMin =
                            (Int32)row[CSpvLienAccesAlarme.c_champMSKADM_MIN, DataRowVersion.Original];


                        // Construction des messages de démasquage accès alarme
                        if (nMaskBriMin > 0 || nMaskAdmMin > 0)
                        {
                            Int32 nSiteId = -1;
                            if (row[CSpvLienAccesAlarme.c_champSITE_ID, DataRowVersion.Original] != DBNull.Value)
                                nSiteId = (Int32)row[CSpvLienAccesAlarme.c_champSITE_ID, DataRowVersion.Original];

                            Int32 nEquipId = -1;
                            if (row[CSpvLienAccesAlarme.c_champEQUIP_ID, DataRowVersion.Original] != DBNull.Value)
                                nEquipId = (Int32)row[CSpvLienAccesAlarme.c_champEQUIP_ID, DataRowVersion.Original];

                            Int32 nLiaiId = -1;
                            if (row[CSpvLienAccesAlarme.c_champLIAI_ID, DataRowVersion.Original] != DBNull.Value)
                                nLiaiId = (Int32)row[CSpvLienAccesAlarme.c_champLIAI_ID, DataRowVersion.Original];

                            Int32 nAccesAccescId =
                                (Int32)row[CSpvLienAccesAlarme.c_champACCES_ACCESC_ID, DataRowVersion.Original];

                            CSpvMessalrm spvMessAlrm;
                            if (nMaskBriMin > 0)
                            {
                                spvMessAlrm = new CSpvMessalrm(contexte);
                                spvMessAlrm.CreateNewInCurrentContexte();
                                spvMessAlrm.MessageMasquageAlarme(" ", 0, nAccesAccescId.ToString(),
                                    (int)EEvenementMasquage.FinMasquageBrigadier, nSiteId, nEquipId, nLiaiId, "");
                            }
                            else
                            {
                                spvMessAlrm = new CSpvMessalrm(contexte);
                                spvMessAlrm.CreateNewInCurrentContexte();
                                spvMessAlrm.MessageMasquageAlarme(" ", 0, nAccesAccescId.ToString(),
                                    (int)EEvenementMasquage.FinMasquageAdministrateur, nSiteId, nEquipId, nLiaiId, "");
                            }
                        }

                        // Construction des messages à destination de EmessEM
                        CSpvLienAccesAlarme spvLienAccesAlarme = new CSpvLienAccesAlarme(row);
                        spvLienAccesAlarme.VersionToReturn = DataRowVersion.Original;
                        CSpvMessem spvMessem = new CSpvMessem(contexte);
                        spvMessem.CreateNewInCurrentContexte();
                        if (!spvMessem.FormatMessAccesAlarme(spvLienAccesAlarme, DataRowState.Deleted))
                            spvMessem.CancelCreate();
                            
                        
                    }
                }
            }
            catch (Exception e)
            {
                result.EmpileErreur(e.Message);
            }
            return result;
        }


        public override CResultAErreur BeforeSave(CContexteSauvegardeObjetsDonnees contexte, IDataAdapter adapter, DataRowState etatsAPrendreEnCompte)
        {
            CResultAErreur result = base.BeforeSave(contexte, adapter, etatsAPrendreEnCompte);
            if (!result)
                return result;

            DataTable table = contexte.ContexteDonnee.Tables[GetNomTable()];
            if (table == null)
                return result;

            ArrayList lstRows = new System.Collections.ArrayList(table.Rows);
            foreach (DataRow row in lstRows)
            {
                    
                if (row.RowState == DataRowState.Added)
                {
                    // Recherche du BindingId lorsqu'il est négatif
                    CSpvLienAccesAlarme spvLienAccesAlarme = new CSpvLienAccesAlarme(row);
                    int? nLienId = spvLienAccesAlarme.BindingId;
                    if (nLienId < 0)    // il faut le trouver
                    {
                        if (spvLienAccesAlarme.AccesAlarmeOne.SpvEquip != null)
                            spvLienAccesAlarme.BindingId = spvLienAccesAlarme.AccesAlarmeOne.SpvEquip.Id;
                        else if (spvLienAccesAlarme.AccesAlarmeOne.SpvSite != null)
                            spvLienAccesAlarme.BindingId = spvLienAccesAlarme.AccesAlarmeOne.SpvSite.Id;
                        else if (spvLienAccesAlarme.AccesAlarmeOne.SpvLiai != null)
                            spvLienAccesAlarme.BindingId = spvLienAccesAlarme.AccesAlarmeOne.SpvLiai.Id;
                        else
                            spvLienAccesAlarme.BindingId = null;    // pas normal
                    }

                    if (spvLienAccesAlarme.AccesAlarmeOne != spvLienAccesAlarme.SpvAccesAlarmeSysteme0())
                    {
                        // Création du message pour EmessEM
                        CSpvMessem spvMessem = new CSpvMessem(contexte.ContexteDonnee);
                        spvMessem.CreateNewInCurrentContexte();
                        if (!spvMessem.FormatMessAccesAlarme(spvLienAccesAlarme, row.RowState))
                            spvMessem.CancelCreate();
                            
                    }
                }
            }
            return result;
        }

        ////-------------------------------------------------------------------
        protected override CFiltreData GetMyFiltreSysteme()
        {
            return new CFiltreData(CSpvLienAccesAlarme.c_champACCES_BINDINGCLASSID + "=@1",
                CSpvLienAccesAlarme.c_BindingClassId);
        }

        public override IDataAdapter GetDataAdapter(DataRowState rowsPriseEnCharge, params string[] champsExclus)
        {
            return base.GetDataAdapter(rowsPriseEnCharge, champsExclus);
        }
	}
}
