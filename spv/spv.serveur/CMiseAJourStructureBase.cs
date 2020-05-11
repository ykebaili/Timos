using System;
using System.Collections.Generic;
using System.Text;
using sc2i.common;
using timos.serveur;
using System.Data.OracleClient;

using sc2i.data;
using sc2i.data.serveur;
using spv.data;
using sc2i.documents;
using timos.data;
using System.Drawing;
using System.Data;
using spv.data;

namespace spv.serveur
{
    [AutoExec("Autoexec")]
    public static class CMiseAJourStructureBase
    {
        private static string c_tableVersion = "VERSION";
        private static string c_champDateVersion = "VERSION_DATE";
        private static string c_champVersionLogiciel = "VERSION_NOM";
        private static string c_champVersionBDD = "VERSION_BDD";

        // Constantes pour la gestion des messages d'erreur Oracle
        private static int c_ErrMess = 0;       // message d'erreur
        private static int c_InfoMess = 1;      // message d'information
        private static int c_Anglais = 0;       // Message en anglais
        private static int c_Francais = 1;      // Message en français

        private static bool m_bIsInit = false;
        public static void Autoexec()
        {
            lock (typeof(CMiseAJourStructureBase))
            {
                if (m_bIsInit)
                    return;
                m_bIsInit = true;
            }
            CTimosServeur.OnMajStructureBaseEvent += new EventHandler(CTimosServeur_OnMajStructureBaseEvent);
        }


        private static bool ConstraintExists(IDatabaseConnexion connexion, string strNomObjet)
        {
            string strSQL = "SELECT * FROM USER_CONSTRAINTS ";
            strSQL += "WHERE CONSTRAINT_NAME ='" + strNomObjet + "'";
            IDataAdapter adapter = connexion.GetSimpleReadAdapter(strSQL);
            DataSet dsTmp = new DataSet();
            connexion.FillAdapter(adapter, dsTmp);
            if (dsTmp.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }

        private static bool IndexExists(IDatabaseConnexion connexion, string strNomObjet)
        {
            string strSQL = "SELECT * FROM USER_INDEXES ";
            strSQL += "WHERE INDEX_NAME ='" + strNomObjet + "'";
            IDataAdapter adapter = connexion.GetSimpleReadAdapter(strSQL);
            DataSet dsTmp = new DataSet();
            connexion.FillAdapter(adapter, dsTmp);
            if (dsTmp.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }


        private static bool FunctionExists(IDatabaseConnexion connexion, string strNomFonction)
        {
            string strFuncExist = "SELECT * FROM USER_OBJECTS ";
            strFuncExist += "WHERE OBJECT_NAME ='" + strNomFonction + "'";
            strFuncExist += " AND OBJECT_TYPE = 'FUNCTION'";
            IDataAdapter adapter = connexion.GetSimpleReadAdapter(strFuncExist);
			DataSet dsTmp = new DataSet();
            connexion.FillAdapter(adapter, dsTmp);
            if (dsTmp.Tables[0].Rows.Count > 0)
				return true;
			else
				return false;
        }


        private static bool ProcedureExists(IDatabaseConnexion connexion, string strNomProcedure)
        {
            string strFuncExist = "SELECT * FROM USER_OBJECTS ";
            strFuncExist += "WHERE OBJECT_NAME ='" + strNomProcedure + "'";
            strFuncExist += " AND OBJECT_TYPE = 'PROCEDURE'";
            IDataAdapter adapter = connexion.GetSimpleReadAdapter(strFuncExist);
            DataSet dsTmp = new DataSet();
            connexion.FillAdapter(adapter, dsTmp);
            if (dsTmp.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }


        private static bool ViewExists(IDatabaseConnexion connexion, string strNomVue)
        {
            string strSQL = "SELECT * FROM USER_OBJECTS ";
            strSQL += "WHERE OBJECT_NAME ='" + strNomVue + "'";
            strSQL += " AND OBJECT_TYPE = 'VIEW'";
            IDataAdapter adapter = connexion.GetSimpleReadAdapter(strSQL);
            DataSet dsTmp = new DataSet();
            connexion.FillAdapter(adapter, dsTmp);
            if (dsTmp.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }


        private static bool PackageExists(IDatabaseConnexion connexion, string strNomPack)
        {
            string strSQL = "SELECT * FROM USER_OBJECTS ";
            strSQL += "WHERE OBJECT_NAME ='" + strNomPack + "'";
            strSQL += " AND OBJECT_TYPE = 'PACKAGE'";
            IDataAdapter adapter = connexion.GetSimpleReadAdapter(strSQL);
            DataSet dsTmp = new DataSet();
            connexion.FillAdapter(adapter, dsTmp);
            if (dsTmp.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }


        private static int GetCurrentVersionBDD(IDatabaseConnexion connexion)
        {
            string strRequete = "select max(" + c_champVersionBDD + ") from " + c_tableVersion;
            CResultAErreur result = connexion.ExecuteScalar(strRequete);
            if (!result)
                throw new Exception("Database update error, can not retrieve db version number");
            if (result.Data == null)
                return -1;
            return Convert.ToInt32(result.Data);
        }

        private static CResultAErreur SetOperation(IDatabaseConnexion connexion, int nVersion,
                                                    int nOperation)
        {
            CResultAErreur result = CResultAErreur.True;
            result = connexion.RunStatement(
                "INSERT INTO operation_maj VALUES (" + nVersion + ", " + nOperation + ")");
            return result;
        }

        private static bool ExistOperation(IDatabaseConnexion connexion, int nVersion,
                                            int nOperation)
        {
            CResultAErreur result = CResultAErreur.True;
            string strSQL = 
                "SELECT COUNT(*) FROM operation_maj WHERE version_num = " + nVersion;
            strSQL += " AND operation_num = " + nOperation;
            result = connexion.ExecuteScalar(strSQL);
            if (!result)
                throw new Exception("Database update error, can not retrieve db operation number");
            if (result.Data != null)
                if (Convert.ToInt32(result.Data) > 0)
                    return true;
            return false;
        }


        //--------------------------------------------------------------------
        static void CTimosServeur_OnMajStructureBaseEvent(object sender, EventArgs e)
        {
            IDatabaseConnexion connexion = CSc2iDataServer.GetInstance().GetDatabaseConnexion(0, CSpvServeur.c_spvConnection);
            COracleDataBaseCreator creator = new COracleDataBaseCreator((COracleDatabaseConnexion)connexion);

            CResultAErreur result = CResultAErreur.True;

            //Vérifie l'existance de la colonne NumVersion dans la base Oracle
            if (!creator.ChampExists(c_tableVersion, c_champVersionBDD))
            {
                string strRequete = "Alter table " + c_tableVersion + " add (" +
                    c_champVersionBDD + " number)";
                result = connexion.RunStatement(strRequete);
            }
            if (result)
            {
                int nVersionBDD = GetCurrentVersionBDD(connexion);

                if (nVersionBDD < 1)
                {
                    result = UpdateToVersion1(connexion, creator);
                    if (result)
                        nVersionBDD++;
                }
                if ( nVersionBDD < 2 && result )
                {
                    result = UpdateToVersion2(connexion, creator);
                }
                if (nVersionBDD < 3 && result)
                    result = UpdateToVersion3(connexion, creator);

                if (nVersionBDD < 4 && result)
                    result = UpdateToVersion4(connexion, creator);
            }
            if (!result)
                throw new CExceptionErreur(result.Erreur);
        }

        //--------------------------------------------------------------------
        #region UpdateToVersion 1
        private static CResultAErreur UpdateToVersion1(IDatabaseConnexion connexion, COracleDataBaseCreator createur)
        {
            CResultAErreur result = CResultAErreur.True;

            try
            {
                //result = createur.DeleteTable ( CConsultationAlarmesEnCoursInDb.c_nomTableInDb);
                // Mise à jour des structures
                result = createur.CreationOuUpdateTableFromType(typeof(CSpvSys_Champ_Auto));

                if (result)
                    result = createur.CreationOuUpdateTableFromType(typeof(CConsultationAlarmesEnCoursInDb));


                // Mise à jour de la table MIBMODULE
                if (result && !createur.ChampExists(CSpvMibmodule.c_nomTableInDb, CDocumentGED.c_champId))
                {
                    CInfoChampTable info = new CInfoChampTable(CDocumentGED.c_champId,
                        typeof(int),
                        0, false, false, true, false, true);
                    result = createur.CreateChamp(CSpvMibmodule.c_nomTableInDb, info);
                }

                if (result)
                {
                    CInfoChampTable info = new CInfoChampTable(CSpvMibmodule.c_champMIBMODULE_SMI,
                        typeof(int), 0, false, false, true, false, true);
                    result = createur.UpdateChamp(CSpvMibmodule.c_nomTableInDb, info, false, false, true);
                }

                // Mise à jour de la table FAMILLE

                if (result && !createur.ChampExists(CSpvFamille.c_nomTableInDb, CSpvFamille.c_champCodeComplet))
                {
                    CInfoChampTable info = new CInfoChampTable(CSpvFamille.c_champCodeComplet,
                        typeof(string), 64, false, false, true, false, true);
                    result = createur.CreateChamp(CSpvFamille.c_nomTableInDb, info);
                }

                if (result && !createur.ChampExists(CSpvFamille.c_nomTableInDb, CSpvFamille.c_champCodePartiel))
                {
                    CInfoChampTable info = new CInfoChampTable(CSpvFamille.c_champCodePartiel,
                        typeof(string), 2, false, false, true, false, true);
                    result = createur.CreateChamp(CSpvFamille.c_nomTableInDb, info);
                }

                if (result && !createur.ChampExists(CSpvFamille.c_nomTableInDb, CSpvFamille.c_champNiveau))
                {
                    CInfoChampTable info = new CInfoChampTable(CSpvFamille.c_champNiveau,
                        typeof(int), 0, false, false, true, false, true);
                    result = createur.CreateChamp(CSpvFamille.c_nomTableInDb, info);
                }

                // Mise à jour de la table TYPLIAI
                if (result && !createur.ChampExists(CSpvTypliai.c_nomTableInDb, CSpvTypliai.c_champSmtTypeLienReseau_Id))
                {
                    CInfoChampTable info = new CInfoChampTable(CSpvTypliai.c_champSmtTypeLienReseau_Id,
                        typeof(int),
                        0, false, false, true, false, true);
                    result = createur.CreateChamp(CSpvTypliai.c_nomTableInDb, info);
                }

                // Mise à jour de la table CSpvLiai
                if (result && !createur.ChampExists(CSpvLiai.c_nomTableInDb, CSpvLiai.c_champSmtLienReseau_Id))
                {
                    CInfoChampTable info = new CInfoChampTable(CSpvLiai.c_champSmtLienReseau_Id,
                        typeof(int),
                        0, false, false, true, false, true);
                    result = createur.CreateChamp(CSpvLiai.c_nomTableInDb, info);
                }

                // Mise à jour de la table CSpvExt
                if (result && createur.TableExists("EXT") &&
                    !createur.ChampExists("EXT", "SMTEXTLIENSURSITE_ID"))
                {
                    CInfoChampTable info = new CInfoChampTable("SMTEXTLIENSURSITE_ID",
                        typeof(int),
                        0, false, false, true, false, true);
                    result = createur.CreateChamp("EXT", info);
                }


                if (result && !createur.ChampExists("ACCES", "SMTPORT_ID"))
                {
                    CInfoChampTable info = new CInfoChampTable("SMTPORT_ID",
                        typeof(int), 0, false, false, true, false, true);
                    result = createur.CreateChamp("ACCES", info);
                }
                if (result && createur.TableExists("TYPPROG") &&
                    !createur.ChampExists("TYPPROG", "SMTDIAGTYPE_ID"))
                {
                    CInfoChampTable info = new CInfoChampTable("SMTDIAGTYPE_ID",
                        typeof(int), 0, false, false, true, false, true);
                    result = createur.CreateChamp("TYPPROG", info);
                }
                if (result && createur.TableExists("PROG") &&
                    !createur.ChampExists("PROG", "SMTDIAG_ID"))
                {
                    CInfoChampTable info = new CInfoChampTable("SMTDIAG_ID",
                        typeof(int), 0, false, false, true, false, true);
                    result = createur.CreateChamp("PROG", info);
                }

                // Mise à jour de la table ALARMGEREE
                if (result && !createur.ChampExists(CSpvAlarmGeree.c_nomTableInDb, CSpvAlarmGeree.c_champALARMGEREE_PROPAGER))
                {
                    CInfoChampTable info = new CInfoChampTable(CSpvAlarmGeree.c_champALARMGEREE_PROPAGER,
                        typeof(bool), 1, false, false, true, false, true);
                    result = createur.CreateChamp(CSpvAlarmGeree.c_nomTableInDb, info);
                }


                if (result)
                {
                    /*                 string strRequete = "update " + CSpvLienAccesAlarmes.c_nomTableInDb + " set " +
                                         CSpvLienAccesAlarmes.c_champCOMMUT + " = 0 where " +
                                         CSpvLienAccesAlarmes.c_champCOMMUT + " is null";
                                     result = createur.Connection.RunStatement(strRequete);
                                     if (!result)
                                         throw new Exception("Acces_accesc.Commut update error ");
                                     else*/
                    {
                        try
                        {
                            CInfoChampTable info = new CInfoChampTable(CSpvLienAccesAlarme.c_champCOMMUT,
                                typeof(System.Boolean), 1, false, false, false, false, true);
                            createur.UpdateChamp(CSpvLienAccesAlarme.c_nomTableInDb, info, true, false, false);
                        }
                        catch (Exception e)
                        {
                            return result;
                        }

                    }
                }
                /*
                if (result)
                    result = createur.CreationOuUpdateTableFromType(typeof(CSpvService_DependanceSite_Source));
                if (result)
                    result = createur.CreationOuUpdateTableFromType(typeof(CSpvService_DependanceSchemaOuLien));
                if (result)
                    result = createur.CreationOuUpdateTableFromType(typeof(CSpvService_DependanceLiaison_Source));
                if (result)
                    result = createur.CreationOuUpdateTableFromType(typeof(CSpvService_DependanceCablage_Source));
                */

                // Mise à jour de la table CableEQU qui pointe sur SChemaReseau
                if (result && createur.TableExists("CABLEQU") &&
                    !createur.ChampExists("CABLEQU", CSchemaReseau.c_champId))
                {
                    CInfoChampTable info = new CInfoChampTable(CSchemaReseau.c_champId,
                        typeof(int),
                        0, false, false, true, false, true);
                    result = createur.CreateChamp("CABLEQU", info);
                }

                if (result)
                    result = createur.CreationOuUpdateTableFromType(typeof(CSpvAlarmcouleur));


                ///Mise à jour de la table "Equip_msk_source
                if (result)
                    result = createur.CreationOuUpdateTableFromType(typeof(CSpvEquip_Msk_Source));

                //Nettoyage de EQUIP_MSK
                /*        if (result && createur.ChampExists(CSpvEquip_Msk.c_nomTableInDb,"PROG_ID"))
                            result = createur.DeleteChamp(CSpvEquip_Msk.c_nomTableInDb, "PROG_ID");
                        if (result && createur.ChampExists(CSpvEquip_Msk.c_nomTableInDb, "SITE_ID"))
                            result = createur.DeleteChamp(CSpvEquip_Msk.c_nomTableInDb, "SITE_ID");
                        if (result && createur.ChampExists(CSpvEquip_Msk.c_nomTableInDb, "CABLEQU_ID"))
                            result = createur.DeleteChamp(CSpvEquip_Msk.c_nomTableInDb, "CABLEQU_ID");
                        //Suppression des triggers qui ne marchent plus sur EQUIP_MSK
                        if (result)
                        {
                            connexion.RunStatement("drop trigger TIDBA_EQUIP_MSK");
                            connexion.RunStatement("drop trigger TUDBA_EQUIP_MSK");
                            connexion.RunStatement("drop trigger TIB_EQUIP_MSK");
                        }*/
                //tmp

                if (result && !createur.ChampExists(CConsultationAlarmesEnCoursInDb.c_nomTableInDb, CConsultationAlarmesEnCoursInDb.c_champActiverEMail))
                {
                    CInfoChampTable info = new CInfoChampTable(CConsultationAlarmesEnCoursInDb.c_champActiverEMail,
                        typeof(int),
                        1, false, false, false, false, true);
                    result = createur.CreateChamp(CConsultationAlarmesEnCoursInDb.c_nomTableInDb, info);
                }

                if (result)
                    result = createur.CreationOuUpdateTableFromType(typeof(CParamlArmEC_EMail));

                // Mise à jour de la table CSpvTypeq
                if (result && !createur.ChampExists(CSpvTypeq.c_nomTableInDb, CSpvTypeq.c_champSmtTypeEquipement_Id))
                {
                    CInfoChampTable info = new CInfoChampTable(CSpvTypeq.c_champSmtTypeEquipement_Id,
                        typeof(int), 0, false, false, true, false, true);
                    result = createur.CreateChamp(CSpvTypeq.c_nomTableInDb, info);
                }

                // Indicateur de type nouvellement découvert
                if (result && !createur.ChampExists(CSpvTypeq.c_nomTableInDb, CSpvTypeq.c_champTYPEQ_NEWDECOUVERT))
                {
                    CInfoChampTable info = new CInfoChampTable(CSpvTypeq.c_champTYPEQ_NEWDECOUVERT,
                        typeof(bool),
                        1, false, false, false, false, true);
                    result = createur.CreateChamp(CSpvTypeq.c_nomTableInDb, info);
                }

                // Mise à jour de la table CSpvEquip
                if (result && !createur.ChampExists(CSpvEquip.c_nomTableInDb, CSpvEquip.c_champSmtEquipementLogique_Id))
                {
                    CInfoChampTable info = new CInfoChampTable(CSpvEquip.c_champSmtEquipementLogique_Id,
                        typeof(int), 0, false, false, true, false, true);
                    result = createur.CreateChamp(CSpvEquip.c_nomTableInDb, info);
                }

                // Mise à jour de la table CSpvSite
                if (result && !createur.ChampExists(CSpvSite.c_nomTableInDb, CSpvSite.c_champSmtSite_Id))
                {
                    CInfoChampTable info = new CInfoChampTable(CSpvSite.c_champSmtSite_Id,
                        typeof(int), 0, false, false, true, false, true);
                    result = createur.CreateChamp(CSpvSite.c_nomTableInDb, info);
                }

                // Mise à jour de la table CSpvTypsite
                if (result && !createur.ChampExists(CSpvTypsite.c_nomTableInDb, CSpvTypsite.c_champSmtTypeSite_Id))
                {
                    CInfoChampTable info = new CInfoChampTable(CSpvTypsite.c_champSmtTypeSite_Id,
                        typeof(int), 0, false, false, true, false, true);
                    result = createur.CreateChamp(CSpvTypsite.c_nomTableInDb, info);
                }

                // Mise à jour de la table CSpvClient
                if (result && !createur.ChampExists(CSpvClient.c_nomTableInDb, CSpvClient.c_champSmtClient_Id))
                {
                    CInfoChampTable info = new CInfoChampTable(CSpvClient.c_champSmtClient_Id,
                        typeof(int), 0, false, false, true, false, true);
                    result = createur.CreateChamp(CSpvClient.c_nomTableInDb, info);
                }

                // Mise à jour de la table CSpvLiai_Liaic
                if (result && createur.TableExists("LIAI_LIAIC") &&
                    createur.ChampExists("LIAI_LIAIC", "SMT_LIAISUPPORT_ID"))
                {
                    createur.DeleteChamp("LIAI_LIAIC", "SMT_LIAISUPPORT_ID");
                }

                //Création de la classe CSpvChampCustomSNMP
                if (result)
                    result = createur.CreationOuUpdateTableFromType(typeof(CSpvChampCustomSNMP));
                if (result && createur.ChampExists(CSpvAlarmcouleur.c_nomTableInDb, "ALARMCOUL_NOM"))
                    result = createur.DeleteChamp(CSpvAlarmcouleur.c_nomTableInDb, "ALARMCOUL_NOM");
                if (result && createur.ChampExists(CSpvAlarmcouleur.c_nomTableInDb, "ALARMCOUL_ABREV"))
                    result = createur.DeleteChamp(CSpvAlarmcouleur.c_nomTableInDb, "ALARMCOUL_ABREV");
                if (result && createur.ChampExists(CSpvAlarmcouleur.c_nomTableInDb, "ALARMCOUL_COULEUR"))
                    result = createur.DeleteChamp(CSpvAlarmcouleur.c_nomTableInDb, "ALARMCOUL_COULEUR");

                if (result)
                    result = AssureCouleursAlarmeParDefaut();

				// Nettoyage des triggers
                if (result && createur.TriggerExists("TD_EQUIP"))
                    result = connexion.RunStatement("drop trigger TD_EQUIP");

                if (result && createur.TriggerExists("TD_CLIENT"))
                    result = connexion.RunStatement("drop trigger TD_CLIENT");

                if (result && createur.TriggerExists("TD_LIAI"))
                    result = connexion.RunStatement("drop trigger TD_LIAI");

                if (result && createur.TriggerExists("TD_LICENCE"))
                    result = connexion.RunStatement("drop trigger TD_LICENCE");

                if (result && createur.TriggerExists("TD_PROG"))
                    result = connexion.RunStatement("drop trigger TD_PROG");

                if (result && createur.TriggerExists("TD_PROGCABL"))
                    result = connexion.RunStatement("drop trigger TD_PROGCABL");

                if (result && createur.TriggerExists("TD_PROG"))
                    result = connexion.RunStatement("drop trigger TD_PROG");

                if (result && createur.TriggerExists("TD_PROGOPER"))
                    result = connexion.RunStatement("drop trigger TD_PROGOPER");

                if (result && createur.TriggerExists("TD_SITE"))
                    result = connexion.RunStatement("drop trigger TD_SITE");

                if (result && createur.TriggerExists("TD_TYPEQ"))
                    result = connexion.RunStatement("drop trigger TD_TYPEQ");

                if (result && createur.TriggerExists("TD_XNASVC"))
                    result = connexion.RunStatement("drop trigger TD_XNASVC");

                if (result && createur.TriggerExists("TDB_ACCES_ACCESC"))
                    result = connexion.RunStatement("drop trigger TDB_ACCES_ACCESC");

                if (result && createur.TriggerExists("TDB_ALARMGEREE"))
                    result = connexion.RunStatement("drop trigger TDB_ALARMGEREE");

                if (result && createur.TriggerExists("TDB_PARAM"))
                    result = connexion.RunStatement("drop trigger TDB_PARAM");

                if (result && createur.TriggerExists("TDB_PROG"))
                    result = connexion.RunStatement("drop trigger TDB_PROG");

                if (result && createur.TriggerExists("TDB_SITE"))
                    result = connexion.RunStatement("drop trigger TDB_SITE");

                if (result && createur.TriggerExists("TDB_TYPEQ"))
                    result = connexion.RunStatement("drop trigger TDB_TYPEQ");

                if (result && createur.TriggerExists("TI_ACCES_ACCESC"))
                    result = connexion.RunStatement("drop trigger TI_ACCES_ACCESC");

                if (result && createur.TriggerExists("TI_CABLEQU"))
                    result = connexion.RunStatement("drop trigger TI_CABLEQU");

                if (result && createur.TriggerExists("TI_EQUIP"))
                    result = connexion.RunStatement("drop trigger TI_EQUIP");

                if (result && createur.TriggerExists("TI_LIAI"))
                    result = connexion.RunStatement("drop trigger TI_LIAI");

                if (result && createur.TriggerExists("TI_PROGCABL"))
                    result = connexion.RunStatement("drop trigger TI_PROGCABL");

                if (result && createur.TriggerExists("TI_PROG"))
                    result = connexion.RunStatement("drop trigger TI_PROG");

                if (result && createur.TriggerExists("TI_PROGOPER"))
                    result = connexion.RunStatement("drop trigger TI_PROGOPER");

                if (result && createur.TriggerExists("TI_SITE"))
                    result = connexion.RunStatement("drop trigger TI_SITE");

                if (result && createur.TriggerExists("TI_XNASVC"))
                    result = connexion.RunStatement("drop trigger TI_XNASVC");

				if (result && createur.TriggerExists("TIB_ACCES"))
					result = connexion.RunStatement("drop trigger TIB_ACCES");

                if (result && createur.TriggerExists("TIB_ACQUITTEMENT"))
                    result = connexion.RunStatement("drop trigger TIB_ACQUITTEMENT");

                if (result && createur.TriggerExists("TIB_GDCSVC"))
                    result = connexion.RunStatement("drop trigger TIB_GDCSVC");

                if (result && createur.TriggerExists("TIB_GDCSVCTEMP"))
                    result = connexion.RunStatement("drop trigger TIB_GDCSVCTEMP");

                if (result && createur.TriggerExists("TIB_LIAI"))
                    result = connexion.RunStatement("drop trigger TIB_LIAI");

                if (result && createur.TriggerExists("TIB_SITE"))
                    result = connexion.RunStatement("drop trigger TIB_SITE");

                if (result && createur.TriggerExists("TIU_PARAM"))
                    result = connexion.RunStatement("drop trigger TIU_PARAM");

                if (result && createur.TriggerExists("TIUB_ALARMGEREE"))
                    result = connexion.RunStatement("drop trigger TIUB_ALARMGEREE");

                if (result && createur.TriggerExists("TIUB_EQUIP"))
                    result = connexion.RunStatement("drop trigger TIUB_EQUIP");

                if (result && createur.TriggerExists("TU_ACCES_ACCESC"))
                    result = connexion.RunStatement("drop trigger TU_ACCES_ACCESC");

                if (result && createur.TriggerExists("TU_ALARMGEREE"))
                    result = connexion.RunStatement("drop trigger TU_ALARMGEREE");

                if (result && createur.TriggerExists("TU_EQUIP"))
                    result = connexion.RunStatement("drop trigger TU_EQUIP");

                if (result && createur.TriggerExists("TU_LICENCE"))
                    result = connexion.RunStatement("drop trigger TU_LICENCE");

                if (result && createur.TriggerExists("TU_TYPLIAI"))
                    result = connexion.RunStatement("drop trigger TU_TYPLIAI");

				if (result && createur.TriggerExists("TUB_ACCES"))
					result = connexion.RunStatement("drop trigger TUB_ACCES");

                if (result && createur.TriggerExists("TUB_GDCSVC"))
                    result = connexion.RunStatement("drop trigger TUB_GDCSVC");

                if (result && createur.TriggerExists("TUB_GDCSVCTEMP"))
                    result = connexion.RunStatement("drop trigger TUB_GDCSVCTEMP");

                if (result && createur.TriggerExists("TUB_SITE"))
                    result = connexion.RunStatement("drop trigger TUB_SITE");

                if (result && createur.TriggerExists("TUB_TYPEQ"))
                    result = connexion.RunStatement("drop trigger TUB_TYPEQ");


                if (result)
                    result = SetVersionBDD(
                        connexion,
                        "Version 2.5.0.1",
                        1);


                return result;

            }
            catch (Exception e)
            {
                result.EmpileErreur(e.Message);
                return result;
            }
        }

        private static CResultAErreur AssureCouleursAlarmeParDefaut()
        {
            List<IEnumALibelle> couleurs = new List<IEnumALibelle>(CUtilSurEnum.GetEnumsALibelle(typeof(CCouleurAlarme)));
            using (CContexteDonnee contexte = new CContexteDonnee(0, true, false))
            {
                foreach (CCouleurAlarme couleur in couleurs)
                {
                    CSpvAlarmcouleur alarmCol = new CSpvAlarmcouleur(contexte);
                    if (!alarmCol.ReadIfExists(new CFiltreData(CSpvAlarmcouleur.c_champALARMCOUL_GRAVITE + "=@1",
                        couleur.CodeInt)))
                    {
                        alarmCol.CreateNewInCurrentContexte();
                        alarmCol.TypeCouleur = couleur;
                        alarmCol.Couleur = CSpvAlarmcouleur.DefaultColor(couleur.Code);
                    }
                }
                return contexte.SaveAll(true);
            }
        }
        #endregion


        #region UpdateToVersion2
        public static CResultAErreur UpdateToVersion2(IDatabaseConnexion connexion, COracleDataBaseCreator createur)
        {
            CResultAErreur result = CResultAErreur.True;

            string strSQL = "";

            // Création de la table permettant de savoir si une opération de mise à jour
            // a été passée ou non
            if (result && ! createur.TableExists("OPERATION_MAJ"))
            {
                strSQL = @"CREATE TABLE operation_maj (version_num NUMBER, operation_num NUMBER,
                        constraint pk_operation_maj primary key (version_num, operation_num)";
                string strSpace;
                strSpace = ((COracleDatabaseConnexion)connexion).NomTableSpaceIndex;
                if (strSpace != "")
                    strSQL += " using index tablespace " + strSpace + ")";
                else
                    strSQL += ")";
                result = connexion.RunStatement(strSQL);
            }


            // Création de la nouvelle fonction de calcul d'unicité d'un ACCES
            // Cette fonction sera exploitée dans le nouvel index unique de la table ACCES
            if (result && !FunctionExists(connexion, "ACCESCALCULUNICITE2"))
            {
                strSQL += "create or replace FUNCTION ACCESCALCULUNICITE2\n";
                strSQL += "(\n";
                strSQL += " EquipId  ACCES.EQUIP_ID%TYPE,\n";
                strSQL += " SiteId   ACCES.SITE_ID%TYPE,\n";
                strSQL += " LiaiId   ACCES.LIAI_ID%TYPE,\n";
                strSQL += " TypeqId  ACCES.TYPEQ_ID%TYPE,\n";
                strSQL += " AccesNom ACCES.ACCES_NOM%TYPE\n";
                strSQL += ")\n";
                strSQL += "RETURN VARCHAR2 DETERMINISTIC AS\n";
                strSQL += "BEGIN\n";
                strSQL += "   if EquipId is not null then \n";
                strSQL += "       return 'EQUIP/' || to_char (EquipId) || '/' || AccesNom;\n";
                strSQL += "   elsif SiteId is not null then\n";
                strSQL += "       return 'SITE/' || to_char (SiteId) || '/' || AccesNom;\n";
                strSQL += "   elsif LiaiId is not null then\n";
                strSQL += "       return 'LIAI/' || to_char (LiaiId) || '/' || AccesNom;\n";
                strSQL += "   elsif TypeqId is not null then\n";
                strSQL += "       return 'TYPEQ/' || to_char (TypeqId) || '/' || AccesNom;\n";
                strSQL += "   else\n";
                strSQL += "       return 'AccesNom';\n";
                strSQL += "   end if;\n";
                strSQL += "END ACCESCALCULUNICITE2;\n";

                result = connexion.RunStatement(strSQL);
            }

            if (result && createur.TriggerExists("TU_ACQUITTEMENT"))
                result = connexion.RunStatement("drop trigger TU_ACQUITTEMENT");

            // Supression de la contrainte UN_ACCES et de l'index correspondant
            if (result && ConstraintExists(connexion, "UN_ACCES"))
            {
                strSQL = "alter table ACCES drop constraint UN_ACCES";
                result = connexion.RunStatement(strSQL);

                if (result && IndexExists(connexion, "UN_ACCES"))
                    result = connexion.RunStatement("drop index UN_ACCES");

                // Suppression des enregistrements ACCES_ACCESC correspondant à des modèles d'équipements
                if (result)
                    result = connexion.RunStatement(
                        @"delete acces_accesc where acces1_id in (select acces_id from acces, acces_accesc
                        where acces.site_id is null 
                        and acces.equip_id is null 
                        and acces.liai_id is null 
                        and acces.typeq_id is null
                        and (acces_id = acces1_id or acces_id = acces2_id))");

                if (result)
                    result = connexion.RunStatement(
                        @"delete acces_accesc where acces2_id in (select acces_id from acces, acces_accesc
                        where acces.site_id is null 
                        and acces.equip_id is null 
                        and acces.liai_id is null 
                        and acces.typeq_id is null
                        and (acces_id = acces1_id or acces_id = acces2_id))");

                // Effacement des accès correspondant aux modèles d'équipements
                if (result && createur.ChampExists("ACCES", "ACCES_UNICITE"))
                {
                    result = connexion.RunStatement(
                        @"delete acces where site_id is null 
                            and equip_id is null and liai_id is null and typeq_id is null
                            and acces_unicite like 'MODELEQUIP%'");

                    // On supprime la colonne ACCES_UNICITE de la table ACCES
                    if (result)
                        result = connexion.RunStatement(
                            "alter table ACCES drop column ACCES_UNICITE");
                }

                // Création du nouvel index uncité accès
                //strNomTableSpaceIndex = ((COracleDatabaseConnexion)Connection).NomTableSpaceIndex;
                if (result)
                {
                    strSQL = @"create unique index UN_ACCES on ACCES 
                            (AccesCalculUnicite2 (EQUIP_ID, SITE_ID, LIAI_ID, TYPEQ_ID, ACCES_NOM))";
                    string strSpace;
                    strSpace = ((COracleDatabaseConnexion)connexion).NomTableSpaceIndex;
                    if (strSpace != "")
                        strSQL += " tablespace " + strSpace;
                    result = connexion.RunStatement(strSQL);
                }
            }

            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion2.ReparationAccesAccesc2.Replace("\r", ""));

            // Création de la table ALARME (contient les alarmes) puis mise à jour de cette table
            // à partir de la table ALARM (qui contient les événements montée et descente)
            string strTable = "alarm_backup";
            if (result && ! createur.TableExists(strTable))
                result = connexion.RunStatement(
                    "create table " + strTable + " as select * from alarm");

            if (result)
                result = createur.CreationOuUpdateTableFromType(typeof(CSpvAlarmeDonnee));

            if (result && !ConstraintExists(connexion, "CK_ALARMDATA_ALARMGEREE_GRAVE"))
                result = connexion.RunStatement(
                    @"alter table ALARMDATA add constraint CK_ALARMDATA_ALARMGEREE_GRAVE 
                        check (alarmgeree_grave in (3, 4, 5, 6, 7))");

            if (result && !ConstraintExists(connexion, "CK_ALARMDATA_ALARMGEREE_TYPAL"))
                result = connexion.RunStatement(
                    @"alter table ALARMDATA add constraint CK_ALARMDATA_ALARMGEREE_TYPAL 
                        check (alarmgeree_typal in (0, 1, 2, 3, 4))");

            // Ajout de la colonne ALARMDATA_ID dans ALARM
            if (result && !createur.ChampExists(CSpvEvenementReseau.c_nomTableInDb, CSpvEvenementReseau.c_champALARME_ID))
            {
                CInfoChampTable info = new CInfoChampTable(CSpvEvenementReseau.c_champALARME_ID,
                    typeof(int), 0, false, true, false, false, true);
                result = createur.CreateChamp(CSpvEvenementReseau.c_nomTableInDb, info);
            }

            if (result && ! ConstraintExists(connexion, "FK1_ALARM"))
                connexion.RunStatement("alter table " +
                    CSpvEvenementReseau.c_nomTableInDb +
                    " add constraint FK1_ALARM foreign key (" +
                    CSpvEvenementReseau.c_champALARME_ID +
                    ") references " + CSpvAlarmeDonnee.c_nomTableInDb +
                    "(" + CSpvAlarmeDonnee.c_champALARMEDONNEE_ID + ")");

            // Ajout de la colonne EVENEMENT_TYPE dans ALARM
            if (result && !createur.ChampExists(CSpvEvenementReseau.c_nomTableInDb, CSpvEvenementReseau.c_champEVENEMENT_TYPE))
            {
                CInfoChampTable info = new CInfoChampTable(CSpvEvenementReseau.c_champEVENEMENT_TYPE,
                    typeof(int), 0, false, false, false, false, true);
                result = createur.CreateChamp(CSpvEvenementReseau.c_nomTableInDb, info);
            }

            if (result && !createur.SequenceExists(CSpvAlarmeDonnee.c_sequenceAssociee))
                result = connexion.RunStatement("create sequence " +
                    CSpvAlarmeDonnee.c_sequenceAssociee + " start with 1");

            if (result && !IsALARMEdansSysChampAuto())
            {
                result = connexion.RunStatement(
                    "insert into " + CSpvSys_Champ_Auto.c_nomTableInDb + " (" +
                        CSpvSys_Champ_Auto.c_champTABLE_NAME + "," +
                        CSpvSys_Champ_Auto.c_champCHAMP_NAME + "," +
                        CSpvSys_Champ_Auto.c_champTG_NAME + "," +
                        CSpvSys_Champ_Auto.c_champSQ_NAME + ") values ('" +
                        CSpvAlarmeDonnee.c_nomTableInDb + "','" +
                        CSpvAlarmeDonnee.c_champALARMEDONNEE_ID + "',' ','" +
                        CSpvAlarmeDonnee.c_sequenceAssociee + "')");
            }

            // Ajout de la colonne ALARMDATA_ID dans la table ACCES_ACCESC_REP
            if (result && !createur.ChampExists(CSpvLienAccesAlarme_Rep.c_nomTableInDb, CSpvLienAccesAlarme_Rep.c_champALARMEDONNEE_ID))
            {
                CInfoChampTable info = new CInfoChampTable(CSpvLienAccesAlarme_Rep.c_champALARMEDONNEE_ID,
                    typeof(int), 0, false, false, true, false, true);
                result = createur.CreateChamp(CSpvLienAccesAlarme_Rep.c_nomTableInDb, info);
            }

            if (result)
            {
                strSQL = "select count(*) from ALARM where ALARM_IDDEB is null";
                int nNbAlarm = 0, nNbAlarme = 0;
                result = connexion.ExecuteScalar(strSQL);
                if (result)
                {
                    nNbAlarm = Convert.ToInt32(result.Data);
                    strSQL = "select count(*) from ALARMDATA";
                    result = connexion.ExecuteScalar(strSQL);
                }

                if (result)
                {
                    nNbAlarme = Convert.ToInt32(result.Data);
                    if (nNbAlarme == 0 && nNbAlarm > 0)
                        result = InitialiseTableAlarme(connexion);
                }

                if (result)
                    result = connexion.RunStatement(ScriptsSQLVersion2.GetClasseObjetEnDefaut.Replace("\r", ""));

                // Mise à jour de la table ALARM3
                if (result && !createur.ChampExists(CSpvEvenementReseauConcernes.c_nomTableInDb, CSpvEvenementReseauConcernes.c_champALARM3_ELTSITEID))
                {
                    CInfoChampTable info = new CInfoChampTable(CSpvEvenementReseauConcernes.c_champALARM3_ELTSITEID,
                        typeof(int), 0, false, false, true, false, true);
                    result = createur.CreateChamp(CSpvEvenementReseauConcernes.c_nomTableInDb, info);
                }

                if (result && !createur.ChampExists(CSpvEvenementReseauConcernes.c_nomTableInDb, CSpvEvenementReseauConcernes.c_champALARM3_ELTTYPEID))
                {
                    CInfoChampTable info = new CInfoChampTable(CSpvEvenementReseauConcernes.c_champALARM3_ELTTYPEID,
                        typeof(int), 0, false, false, true, false, true);
                    result = createur.CreateChamp(CSpvEvenementReseauConcernes.c_nomTableInDb, info);
                }

                if (result && !createur.ChampExists(CSpvEvenementReseauConcernes.c_nomTableInDb, CSpvEvenementReseauConcernes.c_champALARM3_ELTID))
                {
                    CInfoChampTable info = new CInfoChampTable(CSpvEvenementReseauConcernes.c_champALARM3_ELTID,
                        typeof(int), 0, false, false, true, false, true);
                    result = createur.CreateChamp(CSpvEvenementReseauConcernes.c_nomTableInDb, info);
                }

                if (result && !createur.ChampExists(CSpvEvenementReseauConcernes.c_nomTableInDb, CSpvEvenementReseauConcernes.c_champALARM3_ELTCLASSE))
                {
                    CInfoChampTable info = new CInfoChampTable(CSpvEvenementReseauConcernes.c_champALARM3_ELTCLASSE,
                        typeof(int), 0, false, false, true, false, true);
                    result = createur.CreateChamp(CSpvEvenementReseauConcernes.c_nomTableInDb, info);

                    if (result)
                        result = connexion.RunStatement("alter table ALARM3 modify (" + 
                                    CSpvEvenementReseauConcernes.c_champALARM3_ELTCLASSE + 
                                    " default (" + (int) EClasseObjetEnAlarme.Inconnu + "))");
                }
            }

            if (result && !ExistOperation(connexion, 2, 1))
            {
                result = MajTableAlarm3(connexion);
                if (result)
                    result = SetOperation(connexion, 2, 1);
            }

            if (result)
                result = InitialiseAccesAccescRep(connexion);

            if (result)
                result = SuppressionColonnesTableAlarm(connexion, createur);

            // Création de la table de corrélation entre alarmes (remplace ALARM_ALARMC)
            // et init. de celle-ci à partir de la table ALARM_ALARMC
            if (result)
            {
                if (!createur.TableExists(CSpvAlarmeDonneeCorrelation.c_nomTableInDb))
                {
                    strSQL =
                        "create table " + CSpvAlarmeDonneeCorrelation.c_nomTableInDb + "\n" +
                        "(\n" +
                        CSpvAlarmeDonneeCorrelation.c_champALARMEDONNEE_ID + " NUMBER  not null,\n" +
                        CSpvAlarmeDonneeCorrelation.c_champALARMEDONNEE_BINDINGID + " NUMBER not null,\n" +
                        "constraint pk_" + CSpvAlarmeDonneeCorrelation.c_nomTableInDb +
                        " primary key (" + CSpvAlarmeDonneeCorrelation.c_champALARMEDONNEE_ID + "," +
                        CSpvAlarmeDonneeCorrelation.c_champALARMEDONNEE_BINDINGID + ")\n";

                    string strSpace;
                    strSpace = ((COracleDatabaseConnexion)connexion).NomTableSpaceIndex;
                    if (strSpace != "")
                        strSQL += "using index tablespace " + strSpace + ")";
                    else
                        strSQL += ")";

                    result = connexion.RunStatement(strSQL);
                }

                if (result && createur.TableExists("ALARM_ALARMC"))
                {
                    result = connexion.RunStatement(ScriptsSQLVersion2.InitialisationTableAlarmeCorrelation.Replace("\r", ""));
                    if (result)
                        result = connexion.RunStatement("drop table ALARM_ALARMC");
                }
            }

            // Création de la table ALARM_TEMP pour résoudre les problèmes de mutation
            // entre les triggers TIB_ALARM et TI_ALARME
            if (result && !createur.TableExists("ALARM_TEMP"))
                result = connexion.RunStatement(
                    "create global temporary table ALARM_TEMP as select * from ALARM where 0=1");

            if (result && createur.TriggerExists("TI_ALARM"))
                result = connexion.RunStatement("drop trigger TI_ALARM");

            if (result && createur.TriggerExists("TU_ALARM"))
                result = connexion.RunStatement("drop trigger TU_ALARM");

            // Exécution des procédures fonctions et triggers modifiés pour la version2
            // A  partir du fichier texte contenant le script SQL et extrait des ressources,
            // il faut nettoyer le fichier des caractères \r, sinon la compilation SQL
            // échoue.
            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion2.GetFormatDateString.Replace("\r", ""));

            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion2.co_date.Replace("\r", ""));

            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion2.ExtractValeurSeuil.Replace("\r", ""));

            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion2.AlarmNature.Replace("\r", ""));

            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion2.SetAlarm.Replace("\r", ""));

            // Vider la table MESSALRM pour ne pas avoir de problème compte tenu du changement de format
            // sur les programmes et clients concernés (ID à la place des noms).
            if (result)
                result = connexion.ExecuteScalar("delete MESSALRM");

            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion2.MajOperEquip.Replace("\r", ""));

            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion2.MajOperLiai.Replace("\r", ""));

            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion2.Maj2OperEquip.Replace("\r", ""));

            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion2.MajOperSite.Replace("\r", ""));

            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion2.maj_oper.Replace("\r", ""));

            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion2.mess_alrm.Replace("\r", ""));

            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion2.correl_alrm.Replace("\r", ""));

            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion2.Start_Alrm.Replace("\r", ""));

            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion2.PostAlrm.Replace("\r", ""));

            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion2.tib_alarm.Replace("\r", ""));

            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion2.tiu_alarmdata.Replace("\r", ""));

            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion2.tub_acces_accesc2.Replace("\r", ""));

            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion2.tdb_finalarm.Replace("\r", ""));

            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion2.tib_acces_accesc.Replace("\r", ""));

            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion2.GetSiteNom.Replace("\r", ""));

            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion2.GetNomObjetEnDefaut.Replace("\r", ""));

            if (result)
                result = SetVersionBDD(
                    connexion,
                    "Version 2.5.0.2",
                    2);
            return result;
        }




        private static CResultAErreur MajTableAlarm3(IDatabaseConnexion connexion)
        {
            CResultAErreur result = CResultAErreur.True;
            result = connexion.RunStatement(ScriptsSQLVersion2.MajTableAlarm3.Replace("\r", ""));
            if (result)
                connexion.CommitTrans();
            else
                connexion.RollbackTrans();
            return result;
        }


        private static CResultAErreur InitialiseAccesAccescRep(IDatabaseConnexion connexion)
        {
            CResultAErreur result = CResultAErreur.True;
            result = connexion.RunStatement(ScriptsSQLVersion2.InitialiseAccesAccescRep.Replace("\r", ""));
            if (result)
                connexion.CommitTrans();
            else
                connexion.RollbackTrans();
            return result;
        }


        private static CResultAErreur SuppressionColonnesTableAlarm(IDatabaseConnexion connexion, COracleDataBaseCreator createur)
        {
            CResultAErreur result = CResultAErreur.True;
            string [] strCols = new string[] 
                {"ALARM_TYPE", "SITE_ID", "LIAI_ID", "ALARM_NOM", "ALARM_LOCAL",
                    "ALARM_NSEUIL", "ALARM_VSEUIL", "CABLAGEP_ID", "ALARM_IANA", "ALARM_AQUITTEE",
                    "ALARM_ACQUITWHO", "ALARM_ACQUITWHEN", "ALARM_DEB_SEC", "CABLAGES_ID"};

            foreach (string strCol in strCols)
            {
                if (createur.ChampExists(CSpvEvenementReseau.c_nomTableInDb, strCol))
                    result = connexion.RunStatement(@"alter table ALARM drop column " + strCol);

                if (!result)
                    break;
            }

            return result;
        }


        private static CResultAErreur InitialiseTableAlarme(IDatabaseConnexion connexion)
        {
            CResultAErreur result = CResultAErreur.True;

            // Création des enregistrements dans ALARME à partir de ALARM
            
            result = connexion.RunStatement(ScriptsSQLVersion2.InitialisationTableAlarme.Replace("\r", ""));
            if (! result)
                return result;

            // Mise à jour de la table ALARME à partir de ALARM pour les dates de fin
            result = connexion.RunStatement(ScriptsSQLVersion2.MajTableAlarmeFromAlarmFin.Replace("\r", ""));

            // Mise à jour de la table ALARM3
            // On met les ID des enregistrements à la place des noms pour les programmes
            // concernés et les clients concernés

            if (result)
                connexion.CommitTrans();
            else
                connexion.RollbackTrans();

            return result;
        }

        private static bool IsALARMEdansSysChampAuto()
        {
            using (CContexteDonnee contexte = new CContexteDonnee(0, true, false))
            {
                CSpvSys_Champ_Auto spvSysChampAuto = new CSpvSys_Champ_Auto(contexte);
                if (spvSysChampAuto.ReadIfExists(
                    new CFiltreData(CSpvSys_Champ_Auto.c_champTABLE_NAME + "=@1", 
                                    CSpvAlarmeDonnee.c_nomTableInDb)))
                    return true;
                return false;
            }
        }

        #endregion

        #region Update version 3
        public static CResultAErreur UpdateToVersion3(IDatabaseConnexion connexion, COracleDataBaseCreator createur)
        {
            CResultAErreur result = CResultAErreur.True;
            if (result && ConstraintExists(connexion, "FK3_LIAI"))
                result = connexion.RunStatement("alter table LIAI drop constraint FK3_LIAI");
            if (result && ConstraintExists(connexion, "FK4_LIAI"))
                result = connexion.RunStatement("alter table LIAI drop constraint FK4_LIAI");
            if (result)
                result = createur.CreationOuUpdateTableFromType(typeof(CSpvSchemaReseau));
            if (result)
                result = createur.CreationOuUpdateTableFromType(typeof(CSpvSchemaReseau_Rep));
            if (result)
                result = createur.CreationOuUpdateTableFromType(typeof(CSpvSite_Rep));
            if (result)
                result = createur.CreationOuUpdateTableFromType(typeof(CSpvEquip_Rep));
            if (result)
                result = createur.CreationOuUpdateTableFromType(typeof(CSpvLiai_Rep));
            if (result)
                result = createur.CreationOuUpdateTableFromType(typeof(CSpvElementDeGraphe));
            /*
            if (result)
                result = createur.CreationOuUpdateTableFromType(typeof(CSpvLiai));
             * Cette technique ne convient pas car SMTLIENRESEAU_ID ne peut pas être null
             * car la BDD n'est pas encore importée dans SMT
             */
            if (result && !createur.ChampExists(CSpvLiai.c_nomTableInDb, CSpvLiai.c_champLIAI_EQUIPSOURCE))
            {
                CInfoChampTable info = new CInfoChampTable(CSpvLiai.c_champLIAI_EQUIPSOURCE,
                    typeof(int), 0, false, false, true, false, true);
                result = createur.CreateChamp(CSpvLiai.c_nomTableInDb, info);
            }
            if (result && !createur.ChampExists(CSpvLiai.c_nomTableInDb, CSpvLiai.c_champLIAI_EQUIPDEST))
            {
                CInfoChampTable info = new CInfoChampTable(CSpvLiai.c_champLIAI_EQUIPDEST,
                    typeof(int), 0, false, false, true, false, true);
                result = createur.CreateChamp(CSpvLiai.c_nomTableInDb, info);
            } 
            if (result)
                result = createur.DeleteChamp(CSpvLiai.c_nomTableInDb, "LIAI_EXTAID");
            if (result)
                result = createur.DeleteChamp(CSpvLiai.c_nomTableInDb, "LIAI_EXTBID");


            if (result && PackageExists(connexion, "MODE_OPERATIONNEL_SCHEMA"))
                result = connexion.RunStatement("drop package MODE_OPERATIONNEL_SCHEMA");

            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion3.Diagramme_decl.Replace("\r", ""));

            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion3.Diagramme_corps.Replace("\r", ""));

            string strSpace = ((COracleDatabaseConnexion)connexion).NomTableSpaceIndex;

            // Création table MESSAGE pour internationalisation de ceux-ci
            String strTable = "MESSAGE";
            String strSQL;
            if (result && !createur.TableExists(strTable))
            {
                strSQL = "CREATE TABLE " + strTable + "\n";
                strSQL += "(\n";
                strSQL += strTable + "_ID		NUMBER NOT NULL,\n";
                strSQL += strTable + "_TYPE	    NUMBER(1) NOT NULL,\n";
                strSQL += strTable + "_LANG     NUMBER(2) NOT NULL,\n";
                strSQL += strTable + "_NUM		NUMBER NOT NULL,\n";
                strSQL += strTable + "_TEXT		VARCHAR2(256) NOT NULL,\n";
                strSQL += "constraint pk_message primary key (MESSAGE_ID)";

                if (strSpace != "")
                    strSQL += " using index tablespace " + strSpace + ")";
                else
                    strSQL += ")";

                result = connexion.RunStatement(strSQL);
            }

            if (result && !createur.SequenceExists("SEQ_" + strTable))
                result = connexion.RunStatement("create sequence " +
                    "SEQ_" + strTable + " start with 1");

            // Création de la contrainte d'unicité sur la table MESSAGE
            if (result && ! ConstraintExists(connexion, "UN_" + strTable))
            {
                strSQL = "alter table " + strTable;
                strSQL += " add constraint UN_" + strTable + " unique";
                strSQL += " (" + strTable + "_TYPE";
                strSQL += ", " + strTable + "_LANG";
                strSQL += ", " + strTable + "_NUM)";
                
                if (strSpace != "")
                    strSQL += " using index tablespace " + strSpace;
                result = connexion.RunStatement(strSQL);
            }

            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion3.spv_types_decl.Replace("\r", ""));
            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion3.spv_mess_decl.Replace("\r", ""));
            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion3.spv_mess_corps.Replace("\r", ""));
            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion3.parametre_decl.Replace("\r", ""));
            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion3.parametre_corps.Replace("\r", ""));
            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion3.alarme_geree_decl.Replace("\r", ""));
            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion3.alarme_geree_corps.Replace("\r", ""));
            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion3.lien_acces_alarme_decl.Replace("\r", ""));
            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion3.lien_acces_alarme_corps.Replace("\r", ""));
            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion3.Diagramme_decl.Replace("\r", ""));
            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion3.Diagramme_corps.Replace("\r", ""));
            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion3.equipement_decl.Replace("\r", ""));
            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion3.equipement_corps.Replace("\r", ""));
            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion3.Liaison_decl.Replace("\r", ""));
            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion3.Liaison_corps.Replace("\r", ""));
            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion3.pack_alarme_decl.Replace("\r", ""));
            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion3.pack_alarme_corps.Replace("\r", ""));
            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion3.pack_site_decl.Replace("\r", ""));
            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion3.pack_site_corps.Replace("\r", ""));
            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion3.tdb_finalarm.Replace("\r", ""));
            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion3.tib2_alarm.Replace("\r", ""));
            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion3.tib_alarm.Replace("\r", ""));
            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion3.ti_network_graph.Replace("\r", ""));
            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion3.tib_network_graph.Replace("\r", ""));
            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion3.tiu_alarmdata.Replace("\r", ""));
            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion3.tub_acces_accesc2.Replace("\r", ""));
            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion3.tib_ntwdiag_rep.Replace("\r", ""));
            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion3.tdb_alarm.Replace("\r", ""));
            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion3.PurgeAlarmes.Replace("\r", ""));

            
            // Création de la table NETWORK_GRAPH_TEMP pour résoudre les problèmes de mutation
            // dans les triggers sur NETWORK_GRAPH
            if (result && !createur.TableExists("NETWORK_GRAPH_TEMP"))
            {
                strSQL = @"create global temporary table NETWORK_GRAPH_TEMP AS
                        SELECT ntwgph_id FROM network_graph WHERE 0=1";

                result = connexion.RunStatement(strSQL);
            }

            // CSpvElementDeGraph est passé en NoTriggerAutoIncrement du fait du trigger
            // before insert à créer et que l'ordre d'exécution des triggers n'est pas maîtrisable
            // avant la version 11g de la BDD
            //Supprime le trigger s'il existe
            DataSet dsTrigger = new DataSet();
            IDataAdapter adapter = connexion.GetSimpleReadAdapter ( "select * from "+
                COracleDatabaseConnexion.c_nomTableSysChampAuto+" where "+
                COracleDatabaseConnexion.c_nomChampSysChampAutoNomTable+"='"+CSpvElementDeGraphe.c_nomTableInDb+"' and "+
                COracleDatabaseConnexion.c_nomChampSysChampAutoNomChamp+"='"+CSpvElementDeGraphe.c_champId+"'");
            connexion.FillAdapter ( adapter, dsTrigger );
            if ( dsTrigger.Tables.Count > 0 )
            {
                DataTable table = dsTrigger.Tables[0];
                if ( table.Rows.Count != 0 )
                {
                    DataRow row = table.Rows[0];
                    string strTrigger = (string)row[COracleDatabaseConnexion.c_nomChampSysChampAutoTriggerName];
                    strTrigger = strTrigger.Trim();
                    if ( strTrigger.Length != 0 )
                    {
                        result = connexion.RunStatement("drop trigger "+strTrigger);
                    }
                }
            }

            /*
            if (result && createur.TriggerExists("NETWORK_GRAPHTB"))
                result = connexion.RunStatement("drop trigger NETWORK_GRAPHTB");
            if (result && createur.SequenceExists("NETWORK_GRAPHSB"))
            {
                result = connexion.RunStatement("drop sequence NETWORK_GRAPHSB");
                if (result)
                {
                    strSQL = @"UPDATE sys_champ_auto SET tg_name = ' ', sq_name = '";
                    strSQL += CSpvElementDeGraphe.c_sequenceAssociee;
                    strSQL += "' WHERE table_name = '" + CSpvElementDeGraphe.c_nomTableInDb + "'"; ;
                    result = connexion.RunStatement(strSQL); 
                }
            }
            if (result && !createur.SequenceExists(CSpvElementDeGraphe.c_sequenceAssociee))
            {
                int nSeq = 1;
                string strRequete = "select MAX(" + CSpvElementDeGraphe.c_champId + ") from "
                                  + CSpvElementDeGraphe.c_nomTableInDb;
                result = connexion.ExecuteScalar(strRequete);
                if (result && result.Data != null)
                    nSeq = Convert.ToInt32(result.Data);
                nSeq += 1;
                result = connexion.RunStatement("create sequence " +
                    CSpvElementDeGraphe.c_sequenceAssociee + " start with " + nSeq);
            }
             * */

            if (result && ProcedureExists(connexion, "CABLAGE_IS"))
                result = connexion.RunStatement("drop procedure CABLAGE_IS");
            if (result && ProcedureExists(connexion, "VERIFALARMENCOURS"))
                result = connexion.RunStatement("drop procedure VERIFALARMENCOURS");
            if (result && ProcedureExists(connexion, "MAJ_OPER"))
                result = connexion.RunStatement("drop procedure MAJ_OPER");
            if (result && ProcedureExists(connexion, "MAJOPEREQUIP"))
                result = connexion.RunStatement("drop procedure MAJOPEREQUIP");
            if (result && ProcedureExists(connexion, "MAJ2OPEREQUIP"))
                result = connexion.RunStatement("drop procedure MAJ2OPEREQUIP");
            if (result && ProcedureExists(connexion, "TSPROPERPROG"))
                result = connexion.RunStatement("drop procedure TSPROPERPROG");
            if (result && ProcedureExists(connexion, "FINDTSPROPER"))
                result = connexion.RunStatement("drop procedure FINDTSPROPER");
            if (result && ProcedureExists(connexion, "OPERENGLOB"))
                result = connexion.RunStatement("drop procedure OPERENGLOB");
            if (result && ProcedureExists(connexion, "MAJOPERLIAI"))
                result = connexion.RunStatement("drop procedure MAJOPERLIAI");
            if (result && ProcedureExists(connexion, "MAJOPERSUPTE"))
                result = connexion.RunStatement("drop procedure MAJOPERSUPTE");
            if (result && ProcedureExists(connexion, "MAJOPERSITE"))
                result = connexion.RunStatement("drop procedure MAJOPERSITE");
            if (result && ProcedureExists(connexion, "POSTALRM"))
                result = connexion.RunStatement("drop procedure POSTALRM");
            if (result && ProcedureExists(connexion, "MESS_ALRM"))
                result = connexion.RunStatement("drop procedure MESS_ALRM");
            if (result && ProcedureExists(connexion, "START_ALRM"))
                result = connexion.RunStatement("drop procedure START_ALRM");
            if (result && ProcedureExists(connexion, "DELTYPEQ"))
                result = connexion.RunStatement("drop procedure DELTYPEQ");
            if (result && FunctionExists(connexion, "MAJOPERINCLUS"))
                result = connexion.RunStatement("drop function MAJOPERINCLUS");
            if (result && FunctionExists(connexion, "OPERSUPPORT"))
                result = connexion.RunStatement("drop function OPERSUPPORT");
            if (result && ProcedureExists(connexion, "TESTXNASVC"))
                result = connexion.RunStatement("drop procedure TESTXNASVC");
            if (result && ProcedureExists(connexion, "TESTGDCSVC"))
                result = connexion.RunStatement("drop procedure TESTGDCSVC");
            if (result && ProcedureExists(connexion, "UPDATEEQUIPAFTERCABLEQU"))
                result = connexion.RunStatement("drop procedure UPDATEEQUIPAFTERCABLEQU");
            if (result && ProcedureExists(connexion, "UPDATEPROGOPERPROG"))
                result = connexion.RunStatement("drop procedure UPDATEPROGOPERPROG");
            if (result && ProcedureExists(connexion, "VERFSITEBAIE"))
                result = connexion.RunStatement("drop procedure VERFSITEBAIE");
            if (result && ProcedureExists(connexion, "COPALARMGEREE"))
                result = connexion.RunStatement("drop procedure COPALARMGEREE");
            if (result && ProcedureExists(connexion, "COPACCES"))
                result = connexion.RunStatement("drop procedure COPACCES");
            if (result && ProcedureExists(connexion, "DELACCES"))
                result = connexion.RunStatement("drop procedure DELACCES");
            if (result && ProcedureExists(connexion, "DEL1ACCES"))
                result = connexion.RunStatement("drop procedure DEL1ACCES");
            if (result && ProcedureExists(connexion, "DELALARMGEREE"))
                result = connexion.RunStatement("drop procedure DELALARMGEREE");
            if (result && ProcedureExists(connexion, "DEL1ALARMGEREE"))
                result = connexion.RunStatement("drop procedure DEL1ALARMGEREE");
            if (result && ProcedureExists(connexion, "PURGELIAISONS"))
                result = connexion.RunStatement("drop procedure PURGELIAISONS");
            if (result && ProcedureExists(connexion, "DELLIAI"))
                result = connexion.RunStatement("drop procedure DELLIAI");
            if (result && ProcedureExists(connexion, "DELLIAISPEC"))
                result = connexion.RunStatement("drop procedure DELLIAISPEC");
            if (result && ProcedureExists(connexion, "DELLIAILIAIC"))
                result = connexion.RunStatement("drop procedure DELLIAILIAIC");
            if (result && ProcedureExists(connexion, "DELPROGSPEC"))
                result = connexion.RunStatement("drop procedure DELPROGSPEC");
            if (result && ProcedureExists(connexion, "DELTYPEQINC"))
                result = connexion.RunStatement("drop procedure DELTYPEQINC");
            if (result && ProcedureExists(connexion, "DEL1TYPEQINC"))
                result = connexion.RunStatement("drop procedure DEL1TYPEQINC");
            if (result && ProcedureExists(connexion, "CREATEMESSEMMESSFORAL"))
                result = connexion.RunStatement("drop procedure CREATEMESSEMMESSFORAL");
            if (result && ProcedureExists(connexion, "CREATEMESSEMMESSFORALS"))
                result = connexion.RunStatement("drop procedure CREATEMESSEMMESSFORALS");
            if (result && ProcedureExists(connexion, "CRELIAILIAIC"))
                result = connexion.RunStatement("drop procedure CRELIAILIAIC");
            if (result && ProcedureExists(connexion, "CRELIAILIAIC"))
                result = connexion.RunStatement("drop procedure CRELIAILIAIC");
            if (result && ProcedureExists(connexion, "DELCABLAGE"))
                result = connexion.RunStatement("drop procedure DELCABLAGE");
            if (result && ProcedureExists(connexion, "DELCABLAGEPHYS"))
                result = connexion.RunStatement("drop procedure DELCABLAGEPHYS");
            if (result && ProcedureExists(connexion, "DELCABLAGE"))
                result = connexion.RunStatement("drop procedure DELCABLAGE");
            if (result && ProcedureExists(connexion, "DELEQUIP"))
                result = connexion.RunStatement("drop procedure DELEQUIP");
            if (result && ProcedureExists(connexion, "DELEQUIPSPEC"))
                result = connexion.RunStatement("drop procedure DELEQUIPSPEC");
            if (result && ProcedureExists(connexion, "DELCABLAGE"))
                result = connexion.RunStatement("drop procedure DELCABLAGE");
            if (result && ProcedureExists(connexion, "DELCABLAGE"))
                result = connexion.RunStatement("drop procedure DELCABLAGE");
            if (result && ProcedureExists(connexion, "GENALLACCESACCESC"))
                result = connexion.RunStatement("drop procedure GENALLACCESACCESC");
            if (result && ProcedureExists(connexion, "GENALLACCESACCESC"))
                result = connexion.RunStatement("drop procedure GENALLACCESACCESC");
            if (result && ProcedureExists(connexion, "GENACCESACCESC"))
                result = connexion.RunStatement("drop procedure GENACCESACCESC");
            if (result && ProcedureExists(connexion, "MAJEQUIPNBOCC"))
                result = connexion.RunStatement("drop procedure MAJEQUIPNBOCC");
            if (result && ProcedureExists(connexion, "MAJGDCSVC"))
                result = connexion.RunStatement("drop procedure MAJGDCSVC");
            if (result && ProcedureExists(connexion, "MAJEQUIPNBOCC"))
                result = connexion.RunStatement("drop procedure MAJEQUIPNBOCC");
            if (result && ProcedureExists(connexion, "MAJPROGACTIV"))
                result = connexion.RunStatement("drop procedure MAJPROGACTIV");
            if (result && ProcedureExists(connexion, "MAJXNASVC"))
                result = connexion.RunStatement("drop procedure MAJXNASVC");
            if (result && ProcedureExists(connexion, "MAJEQUIPNBOCC"))
                result = connexion.RunStatement("drop procedure MAJEQUIPNBOCC");
            if (result && ProcedureExists(connexion, "MASK_ALRM"))
                result = connexion.RunStatement("drop procedure MASK_ALRM");
            if (result && ProcedureExists(connexion, "UPDATEPROGACTIV"))
                result = connexion.RunStatement("drop procedure UPDATEPROGACTIV");
            if (result && ProcedureExists(connexion, "SAVEPERIODIQUE"))
                result = connexion.RunStatement("drop procedure SAVEPERIODIQUE");
            if (result && ProcedureExists(connexion, "SAVETEMPORAIRE"))
                result = connexion.RunStatement("drop procedure SAVETEMPORAIRE");
            if (result && ProcedureExists(connexion, "SAVETEMPORAIRE"))
                result = connexion.RunStatement("drop procedure SAVETEMPORAIRE");
            if (result && ProcedureExists(connexion, "SPECTDPROGSERVICE"))
                result = connexion.RunStatement("drop procedure SPECTDPROGSERVICE");
            if (result && ProcedureExists(connexion, "SPECTIPROGSERVICE"))
                result = connexion.RunStatement("drop procedure SPECTIPROGSERVICE");
            if (result && ProcedureExists(connexion, "VERFSITEBAIEEQUIP"))
                result = connexion.RunStatement("drop procedure VERFSITEBAIEEQUIP");
            if (result && ProcedureExists(connexion, "VERIFACTIFPROG"))
                result = connexion.RunStatement("drop procedure VERIFACTIFPROG");
            if (result && ProcedureExists(connexion, "PURGEBAGOT"))
                result = connexion.RunStatement("drop procedure PURGEBAGOT");
            if (result && ProcedureExists(connexion, "MAJALARMPROG"))
                result = connexion.RunStatement("drop procedure MAJALARMPROG");

            if (result && FunctionExists(connexion, "CALCNBOBJ"))
                result = connexion.RunStatement("drop function CALCNBOBJ");
            if (result && FunctionExists(connexion, "GETLIAINOM"))
                result = connexion.RunStatement("drop function GETLIAINOM");
            if (result && FunctionExists(connexion, "ACCESCALCULUNICITE"))
                result = connexion.RunStatement("drop function ACCESCALCULUNICITE");
            if (result && FunctionExists(connexion, "ALARMGEREEGETFATHER"))
                result = connexion.RunStatement("drop function ALARMGEREEGETFATHER");
            if (result && FunctionExists(connexion, "ACCESGETFATHER"))
                result = connexion.RunStatement("drop function ACCESGETFATHER");
            if (result && FunctionExists(connexion, "BOOLTOCHAR"))
                result = connexion.RunStatement("drop function BOOLTOCHAR");
            if (result && FunctionExists(connexion, "CORREL_ALRM"))
                result = connexion.RunStatement("drop function CORREL_ALRM");
            if (result && FunctionExists(connexion, "GETDEBITLIAI"))
                result = connexion.RunStatement("drop function GETDEBITLIAI");
            if (result && FunctionExists(connexion, "GETELTNOM"))
                result = connexion.RunStatement("drop function GETELTNOM");
            if (result && FunctionExists(connexion, "GETFAMILYNAME"))
                result = connexion.RunStatement("drop function GETFAMILYNAME");
            if (result && FunctionExists(connexion, "GETMIBS"))
                result = connexion.RunStatement("drop function GETMIBS");
            if (result && FunctionExists(connexion, "GETMODCALC"))
                result = connexion.RunStatement("drop function GETMODCALC");
            if (result && FunctionExists(connexion, "GETNEWLIAINOM"))
                result = connexion.RunStatement("drop function GETNEWLIAINOM");
            if (result && FunctionExists(connexion, "GETNEXTSUBSTRING"))
                result = connexion.RunStatement("drop function GETNEXTSUBSTRING");
            if (result && FunctionExists(connexion, "GETNOMOBJETENDEFAUT"))
                result = connexion.RunStatement("drop function GETNOMOBJETENDEFAUT");
            if (result && FunctionExists(connexion, "GETNUMJOUR"))
                result = connexion.RunStatement("drop function GETNUMJOUR");
            if (result && FunctionExists(connexion, "GETOBJNAMEFROMOBJID"))
                result = connexion.RunStatement("drop function GETOBJNAMEFROMOBJID");
            if (result && FunctionExists(connexion, "GETOPERELT"))
                result = connexion.RunStatement("drop function GETOPERELT");
            if (result && FunctionExists(connexion, "GETPARAMVALUE"))
                result = connexion.RunStatement("drop function GETPARAMVALUE");
            if (result && FunctionExists(connexion, "GETTABLENOM"))
                result = connexion.RunStatement("drop function GETTABLENOM");
            if (result && FunctionExists(connexion, "ISNULL"))
                result = connexion.RunStatement("drop function ISNULL");
            if (result && FunctionExists(connexion, "ISNULLOREXISTOBJ"))
                result = connexion.RunStatement("drop function ISNULLOREXISTOBJ");
            if (result && FunctionExists(connexion, "ISNULLOREXISTFAM"))
                result = connexion.RunStatement("drop function ISNULLOREXISTFAM");
            if (result && FunctionExists(connexion, "ISNULLORNOTEXISTOBJ"))
                result = connexion.RunStatement("drop function ISNULLORNOTEXISTOBJ");
            if (result && FunctionExists(connexion, "ISNULLORSUPPROREXISTFAM"))
                result = connexion.RunStatement("drop function ISNULLORSUPPROREXISTFAM");
            if (result && FunctionExists(connexion, "ISNULLORSUPPROREXISTOBJ"))
                result = connexion.RunStatement("drop function ISNULLORSUPPROREXISTOBJ");
            if (result && FunctionExists(connexion, "EXISTOBJ"))
                result = connexion.RunStatement("drop function EXISTOBJ");
            if (result && FunctionExists(connexion, "ISSONOF"))
                result = connexion.RunStatement("drop function ISSONOF");
            if (result && FunctionExists(connexion, "MAX4"))
                result = connexion.RunStatement("drop function MAX4");
            if (result && FunctionExists(connexion, "MAX3"))
                result = connexion.RunStatement("drop function MAX3");
            if (result && FunctionExists(connexion, "MAX2"))
                result = connexion.RunStatement("drop function MAX2");
            if (result && FunctionExists(connexion, "OUTSITE"))
                result = connexion.RunStatement("drop function OUTSITE");
            if (result && FunctionExists(connexion, "SORTOID"))
                result = connexion.RunStatement("drop function SORTOID");
            if (result && FunctionExists(connexion, "TSCOUPE"))
                result = connexion.RunStatement("drop function TSCOUPE");
            if (result && FunctionExists(connexion, "GETSITENOM"))
                result = connexion.RunStatement("drop function GETSITENOM");
            if (result && FunctionExists(connexion, "ALARMNATURE"))
                result = connexion.RunStatement("drop function ALARMNATURE");
            if (result && FunctionExists(connexion, "ISMASKEDBY"))
                result = connexion.RunStatement("drop function ISMASKEDBY");
            if (result && FunctionExists(connexion, "ISMASKEDLIAI"))
                result = connexion.RunStatement("drop function ISMASKEDLIAI");

            if (result && ViewExists(connexion, "V1018_01A"))
                result = connexion.RunStatement("drop view V1018_01A");
            if (result && ViewExists(connexion, "V1004_01"))
                result = connexion.RunStatement("drop view V1004_01");


            if (result)
                result = InsereMessages(connexion, c_ErrMess, c_Anglais,
                    ScriptsSQLVersion3.message_erreur_gb);
            if (result)
                result = InsereMessages(connexion, c_ErrMess, c_Francais,
                    ScriptsSQLVersion3.message_erreur_fr);

            // Mise à jour de la table NETWORK_DIAG à partir de PROG
            // et mise à niveau de ALARM3_PRCONC, on remplace les ID
            // de PROG par les ID de NETWORK_DIAG
            if (result && createur.TableExists("PROG"))
            {
                result = connexion.ExecuteScalar(
                    @"select count(*) from prog, network_diag
                        where ntwdiag_smt_id (+) = smtdiag_id
                        and ntwdiag_smt_id is null");
                if (result && result.Data != null && Convert.ToInt32(result.Data) > 0)
                {
                    result = connexion.RunStatement(ScriptsSQLVersion3.MajDiagFromProg.Replace("\r", ""));
                    if (result)
                        result = connexion.RunStatement(ScriptsSQLVersion3.MajTableAlarm3.Replace("\r", ""));
                }
            }

            // Création de la table permettant de savoir si une opération de mise à jour
            // a été passée ou non
            if (result && ! createur.TableExists("OPERATION_MAJ"))
            {
                strSQL = @"CREATE TABLE operation_maj (version_num NUMBER, operation_num NUMBER,
                        constraint pk_operation_maj primary key (version_num, operation_num)";
                if (strSpace != "")
                    strSQL += " using index tablespace " + strSpace + ")";
                else
                    strSQL += ")";
                result = connexion.RunStatement(strSQL);
            }

            if (result && ! ExistOperation(connexion, 3, 1))
            {
                // Opération 1 de la version 3
                result = connexion.RunStatement(
                    "UPDATE alarm2 SET alarm2_tsproper = REPLACE (alarm2_tsproper, ',', '!')");
                if (result)
                    result = SetOperation(connexion, 3, 1);
            }

            // Création et mise à jour de la table NETWORK_DIAG_MASQUE
            if (result && !createur.TableExists("NETWORK_DIAG_MASQUE"))
                result = CreDiagMasqueTable(connexion, strSpace);

            if (result && ConstraintExists(connexion, "EQUIP_MSK_SRCFF"))
            {
                strSQL = "alter table EQUIP_MSK_SRC drop constraint EQUIP_MSK_SRCFF";
                result = connexion.RunStatement(strSQL);
                // Pour pouvoir virer la table PROG_CABL
            }

            if (result && createur.TableExists("CABLEQU_EQUIP"))
                result = connexion.RunStatement("drop table CABLEQU_EQUIP");
            if (result && createur.TableExists("LIAI_CABLEQU"))
                result = connexion.RunStatement("drop table LIAI_CABLEQU");
            if (result && createur.TableExists("PROG_USEDCABL_SRC"))
                result = connexion.RunStatement("drop table PROG_USEDCABL_SRC");
            if (result && createur.TableExists("CABLEQU"))
                result = connexion.RunStatement("drop table CABLEQU");
            if (result && createur.TableExists("EXT"))
                result = connexion.RunStatement("drop table EXT");
            if (result && createur.TableExists("PROG_CABL_REP"))
                result = connexion.RunStatement("drop table PROG_CABL_REP");
            if (result && createur.TableExists("PROG_CABL"))
                result = connexion.RunStatement("drop table PROG_CABL");
            if (result && createur.TableExists("PROG_OPER_REP"))
                result = connexion.RunStatement("drop table PROG_OPER_REP");
            if (result && createur.TableExists("PROG_OPER"))
                result = connexion.RunStatement("drop table PROG_OPER");
            if (result && createur.TableExists("PROG_REP"))
                result = connexion.RunStatement("drop table PROG_REP");
            if (result && createur.TableExists("PROG_USEDLIAI_SRC"))
                result = connexion.RunStatement("drop table PROG_USEDLIAI_SRC");
            if (result && createur.TableExists("PROG_USEDLIAIS"))
                result = connexion.RunStatement("drop table PROG_USEDLIAIS");
            if (result && createur.TableExists("PROG_USEDSITES_SRC"))
                result = connexion.RunStatement("drop table PROG_USEDSITES_SRC");
            if (result && createur.TableExists("PROG_USEDSITES"))
                result = connexion.RunStatement("drop table PROG_USEDSITES");
            if (result && createur.TableExists("PROG_USEDDIAG"))
                result = connexion.RunStatement("drop table PROG_USEDDIAG");
            if (result && createur.TableExists("GDCSVC_TEMP2"))
                result = connexion.RunStatement("drop table GDCSVC_TEMP2");
            if (result && createur.TableExists("GDCSVC_TEMP"))
                result = connexion.RunStatement("drop table GDCSVC_TEMP");
            if (result && createur.TableExists("GDCSVC"))
                result = connexion.RunStatement("drop table GDCSVC");
            if (result && createur.TableExists("PROG_MSK"))
                result = connexion.RunStatement("drop table PROG_MSK");
            if (result && createur.TableExists("PROG_ACTIV"))
                result = connexion.RunStatement("drop table PROG_ACTIV");
            if (result && createur.TableExists("ROUTAGE"))
                result = connexion.RunStatement("drop table ROUTAGE");
            if (result && createur.TableExists("ALARM_PROG"))
                result = connexion.RunStatement("drop table ALARM_PROG");
            if (result && createur.TableExists("PROG"))
                result = connexion.RunStatement("drop table PROG");
            if (result && createur.TableExists("TYPPROG"))
                result = connexion.RunStatement("drop table TYPPROG");
            if (result && createur.TableExists("XNASVC_TEMP"))
                result = connexion.RunStatement("drop table XNASVC_TEMP");
            if (result && createur.TableExists("XNASVC_REP"))
                result = connexion.RunStatement("drop table XNASVC_REP");
            if (result && createur.TableExists("XNASVC"))
                result = connexion.RunStatement("drop table XNASVC");

            if (result)
                result = createur.CreationOuUpdateTableFromType(typeof(CSpvEquip_Msk_Source));
            if (result)
                result = createur.DeleteChamp(CSpvEquip_Msk_Source.c_nomTableInDb, "ACCES_ACCESC_ID");
            if (result)
                result = createur.DeleteChamp(CSpvEquip_Msk_Source.c_nomTableInDb, "PROG_ID");
            if (result)
                result = createur.DeleteChamp(CSpvEquip_Msk_Source.c_nomTableInDb, "CABLEQU_ID");

            // Initialisation des états opérationnels équipements, sites, liaisons et
            // diagrammes en dépendant.
            if (result && !ExistOperation(connexion, 3, 2))
            {
                // Opération 2 de la version 3
                result = connexion.RunStatement("begin equipement.init_oper_equips; end;");
                if (result)
                    result = connexion.RunStatement("begin pack_site.init_oper_sites; end;");
                if (result)
                    result = connexion.RunStatement("begin liaison.init_oper_liais; end;");
                if (result)
                    result = SetOperation(connexion, 3, 2);
            }
            if (result)
            {
                try
                {
                    connexion.RunStatement("alter table " + CSpvLiai.c_nomTableInDb + " modify (" +
                        CSpvLiai.c_champSITE_ORIGID + " null, " +
                        CSpvLiai.c_champSITE_DESTID + " null)");
                }
                catch { }

                try
                {
                    connexion.RunStatement("alter table " + CSpvLiai.c_nomTableInDb + " modify (" +
                        CSpvLiai.c_champLIAI_CDRM + " null, " +
                        CSpvLiai.c_champLIAI_CDRP + " null, " +
                        CSpvLiai.c_champLIAI_CDRS + " null)");
                }
                catch { }

            }

            if (result)
                result = SetVersionBDD(
                    connexion,
                    "Version 2.5.0.3",
                    3);

            return result;
        }

        #region Update version 4
        public static CResultAErreur UpdateToVersion4(IDatabaseConnexion connexion, COracleDataBaseCreator createur)
        {
            CResultAErreur result = CResultAErreur.True;
            

            return result;
        }
        #endregion


        
        private static CResultAErreur InsereMessages(
            IDatabaseConnexion connexion, int nType, int nLangue, string strContenuFichier)
        {
            CResultAErreur result = CResultAErreur.True;
            strContenuFichier.Replace("\r", "");
            string [] strLignes = strContenuFichier.Split('\n');
            foreach (string strUneLigne in strLignes)
            {
                string[] strBanal = strUneLigne.Split(';');

                string strSQL;
                strSQL = "DELETE message WHERE message_lang = " + nLangue;
                strSQL += " AND message_type = " + nType;
                strSQL += " AND message_num = " + strBanal[0];
                result = connexion.RunStatement(strSQL);

                if (result)
                {
                    strSQL = "INSERT INTO message VALUES (";
                    strSQL += "seq_message.NEXTVAL, " + nType + ", " + nLangue;
                    strSQL += ", " + strBanal[0] + ", '" + strBanal[1] + "')";
                    result = connexion.RunStatement(strSQL);
                }
                if (!result)
                    break;
            }
            return result;
        }


        private static CResultAErreur CreDiagMasqueTable
            (
             IDatabaseConnexion connexion,
             string strSpace
            )
        {
            CResultAErreur result = CResultAErreur.True;
            string strSQL;
            strSQL = @"CREATE TABLE network_diag_masque (
                            network_diag_masque_id NUMBER NOT NULL,
                            ntwdiag_id NUMBER NOT NULL,
                            network_diag_masque_etat NUMBER DEFAULT 0 NOT NULL 
                                CONSTRAINT ck_network_diag_masque 
                                CHECK(network_diag_masque_etat IN (0, 1, 2)),
                            acces_accesc_id NUMBER NOT NULL,
                                CONSTRAINT fk1_network_diag_masque FOREIGN KEY
                                (ntwdiag_id)
                                REFERENCES network_diag (ntwdiag_id),
                                CONSTRAINT fk2_network_diag_masque FOREIGN KEY
                                (acces_accesc_id) 
                                REFERENCES acces_accesc (acces_accesc_id),
                                CONSTRAINT pk_network_diag_masque PRIMARY KEY
                                (network_diag_masque_id)";
            if (strSpace != "")
                strSQL += " USING INDEX TABLESPACE " + strSpace + ")";
            else
                strSQL += ")";

            result = connexion.RunStatement(strSQL);
            if (result)
                result = connexion.RunStatement(
                    "CREATE SEQUENCE seq_network_diag_masque");

            if (result)
                result = connexion.RunStatement(ScriptsSQLVersion3.InitNetworkDiagMasque.Replace("\r", ""));
            
            return result;
        }

        #endregion

        public static CResultAErreur SetVersionBDD(
            IDatabaseConnexion connexion,
            string strNumVersion, 
            int nVersion)
        {
            CResultAErreur result = CResultAErreur.True;
            string strRequete = "select * from "+c_tableVersion+" where "+
                c_champVersionLogiciel+"='"+strNumVersion+"'";
            IDataAdapter adapter = connexion.GetSimpleReadAdapter ( strRequete );
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable table = ds.Tables[0];
            if (table.Rows.Count > 0)
            {
                strRequete = "update " + c_tableVersion + " set " + c_champVersionBDD + "=" +
                    nVersion + " where " +
                    c_champVersionLogiciel + "='" + strNumVersion + "'";
                result = connexion.RunStatement(strRequete);
                return result;
            }
            else
            {
                strRequete = "insert into " + c_tableVersion + "(" +
                c_champDateVersion + "," + c_champVersionLogiciel  + "," + c_champVersionBDD + ") values(SysDate," +
                "'" + strNumVersion + "'," +
                nVersion + ")";
                result = connexion.RunStatement(strRequete);
                return result;
            }
        }


        
    }
}
