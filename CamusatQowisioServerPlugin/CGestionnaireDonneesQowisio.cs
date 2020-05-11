using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.data;
using System.Collections;
using timos.data;
using System.Data;
using CamusatQowisioClientPlugin;
using sc2i.data.dynamic;
using System.Threading;
using System.IO;
using sc2i.multitiers.client;
using sc2i.multitiers.server;
using System.Xml;
using System.Reflection;
using timos.serveur;
using Tamir.SharpSsh;

namespace CamusatQowisioServerPlugin
{
    public enum EModeTraitment
    {
        SHORT = 1,
        MEDIUM = 2,
        FULL = 4
    }

    [AutoExec("AutoexecInit")]
    [AutoExec("AutoexecStart", AutoExecAttribute.BackGroundService)]
    public class CGestionnaireDonneesQowisio
    {
        private const string c_strCleDernierFichierTraité = "QOCAFUT_LAST_FTP_FILE";

        private const string c_strWorkDir = "Qowisio\\WORK";
        private const string c_strDoneDir = "Qowisio\\DONE";
        private const string c_strErrorDir = "Qowisio\\ERROR";
        private const string c_strDTDFileName = "futurocom-camusat.dtd";

        public static int c_nDelaiTraitementShort = (1000 * 60) * 1; //5; // 5 minutes
        public static int c_nDelaiTraitementMedium = (1000 * 60) * 1; //60; // 1 heure
        public static int c_nDelaiTraitementFull = (1000 * 60) * 60 * 12; // 12 heures

        public static bool m_bTraitementEnCours = false;
        public static DateTime m_lastDateDebutTraitementShort = DateTime.Now;
        public static DateTime m_lastDateDebutTraitementMedium = DateTime.Now;
        public static DateTime m_lastDateDebutTraitementFull = DateTime.Now;

        public static Timer m_timer = null;
        public static CSessionClient m_sessionClient = null;
        
        
        private static bool m_bAutoexecDone = false;
        public static void AutoexecInit()
        {
            lock (typeof(CGestionnaireDonneesQowisio))
            {
                if (m_bAutoexecDone)
                    return;
                m_bAutoexecDone = true;
            }
            m_bTraitementEnCours = true;

            CTimosServeur.OnMajStructureBaseEvent += new EventHandler(CTimosServeur_OnMajStructureBaseEvent);
            

            string strAppData = AppDataPath;
            if (!Directory.Exists(strAppData))
                Directory.CreateDirectory(strAppData);
            C2iEventLog.WriteInfo(strAppData);

            // Récupère le nom du dernier fichier traité
            CDataBaseRegistrePourClient registreClient = new CDataBaseRegistrePourClient(0);

            
            CContexteDonneeServeur.AddTraitementAvantSauvegarde(new TraitementSauvegardeExterne(TraitementAvantSauvegardeExterne));
        
        }

        public static void AutoexecStart()
        {
            // Initialisation du Timer
            m_timer = new Timer(new TimerCallback(OnTimerTraitement), null, 1000 * 10, c_nDelaiTraitementShort);
        }

        //--------------------------------------------------------------------
        static void CTimosServeur_OnMajStructureBaseEvent(object sender, EventArgs e)
        {
            // Mise à jour de la base
            C2iDataBaseUpdateOperationTable opTableCamusatData =
                new C2iDataBaseUpdateOperationTable(typeof(CCamusatQowisioData));
            C2iDataBaseUpdateOperationTable opTableCamusatAlarm =
                new C2iDataBaseUpdateOperationTable(typeof(CCamusatQowisioAlarm));

            IDatabaseConnexion connexion = CSc2iDataServer.GetInstance().GetDatabaseConnexion(0, "");
            if (connexion != null)
            {
                CResultAErreur result = CResultAErreur.True;
                try
                {
                    connexion.BeginTrans();
                    result = opTableCamusatData.ExecuterOperation(connexion, null);
                    if (result)
                        result = opTableCamusatAlarm.ExecuterOperation(connexion, null);
                    if (!result)
                    {
                        connexion.RollbackTrans();
                    }
                    else
                    {
                        connexion.CommitTrans();
                    }
                }
                catch (Exception ex)
                {
                    result.EmpileErreur(ex.Message);
                }
            }
            m_bTraitementEnCours = false;
        }

        public static CResultAErreur TraitementAvantSauvegardeExterne(CContexteDonnee contexte, Hashtable tableData)
        {
            CResultAErreur result = CResultAErreur.True;
            bool bVidesLesCaches = false;

            DataTable tableEquipements = contexte.Tables[CEquipementLogique.c_nomTable];
            if (tableEquipements != null)
            {
                string strFiltre = 
                    CTypeEquipement.c_champId + " = " + CCamusatQowisioData.c_nIdTypeEquipementQowisioBoxVehicule + " OR " +
                    CTypeEquipement.c_champId + " = " + CCamusatQowisioData.c_nIdTypeEquipementQowisioVirtualSite + " OR " +
                    CTypeEquipement.c_champId + " = " + CCamusatQowisioData.c_nIdTypeEquipementQowisioFuelProbe;
                DataRow[] rows = tableEquipements.Select(strFiltre);
                foreach (DataRow row in rows)
                {
                    if (row.RowState != DataRowState.Unchanged)
                    {
                        bVidesLesCaches = true;
                        break;
                    }
                }
            }

            DataTable tableRelationsChamps = contexte.Tables[CRelationEquipementLogique_ChampCustom.c_nomTable];
            if (tableRelationsChamps != null)
            {
                string strFiltre = CChampCustom.c_champId + " = " + CCamusatQowisioData.c_nIdChampTimosFuelProbeAssociatedTank;
                DataRow[] rows = tableRelationsChamps.Select(strFiltre);
                foreach (DataRow row in rows)
                {
                    if (row.RowState != DataRowState.Unchanged)
                    {
                        bVidesLesCaches = true;
                        break;
                    }
                }
            }

            if (bVidesLesCaches)
            {
                CCamusatQowisioData.ClearAllCacheDatas();
            }

            return result;
        }

        //----------------------------------------------------------------------------------
        private static string AppDataPath
        {
            get
            {
                string strAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                strAppData += "\\Timos";

                return strAppData;
            }
        }

        //----------------------------------------------------------------------------------
        private static string LocalXmlFileToProcess
        {
            get
            {
                return AppDataPath + "\\CAQOFUDATA.XML";
            }
        }

        //----------------------------------------------------------------------------------
        private static string LocalDtdFile
        {
            get
            {
                return AppDataPath + "\\futurocom-camusat.dtd";
            }
        }

        //----------------------------------------------------------------------------------
        private static string GetRepertoire(string strRepertoire)
        {
            CResultAErreurType<string> res = new CResultAErreurType<string>();
            string strPath = AppDataPath;
            if (strPath[strPath.Length - 1] != '\\')
                strPath += "\\";
            if (!Directory.Exists(strPath + strRepertoire))
                CUtilRepertoire.AssureRepertoire(strPath + strRepertoire);
            return strPath + strRepertoire;
        }

        //----------------------------------------------------------------------------------
        private static string WorkDir
        {
            get
            {
                string strWorkDir = GetRepertoire(c_strWorkDir);
                if (!File.Exists(strWorkDir + "\\" + c_strDTDFileName))
                {
                    FileStream destStream = new FileStream(strWorkDir + "\\" + c_strDTDFileName, FileMode.Create, FileAccess.Write);
                    BinaryWriter writer = new BinaryWriter(destStream);
                    Stream srcStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("CamusatQowisioServerPlugin.futurocom-camusat.dtd");
                    Byte[] bts = new byte[1024];
                    int nNbLus = 0;
                    while ((nNbLus = srcStream.Read(bts, 0, 1024)) > 0)
                    {
                        writer.Write(bts, 0, nNbLus);
                    }
                    writer.Close();
                    destStream.Close();
                    srcStream.Close();
                }
                return GetRepertoire(c_strWorkDir);  
            }
        }


        //----------------------------------------------------------------------------------
        private static string DoneDir
        {
            get
            {
                return GetRepertoire(c_strDoneDir + "\\" +
                    DateTime.Now.ToString("yyyy") + "\\" +
                    DateTime.Now.ToString("MM") + "\\" +
                    DateTime.Now.ToString("dd"));
                
            }
        }

        //----------------------------------------------------------------------------------
        private static string ErrorDir
        {
            get
            {
                return GetRepertoire(c_strErrorDir + "\\" +
                    DateTime.Now.ToString("yyyy") + "\\" +
                    DateTime.Now.ToString("MM")+ "\\" +
                    DateTime.Now.ToString("dd"));
            }
        }

        //----------------------------------------------------------------------------------
        private static void MoveSafely(string strFichierSource, ref string strFichierDest)
        {
            int nIndex = 0;
            string strFile = strFichierDest;
            while (File.Exists(strFile))
            {
                nIndex++;
                int nPos = strFichierDest.LastIndexOf('.');
                if (nPos > 0)
                    strFile = strFichierDest.Substring(0, nPos ) +
                        "_" + nIndex + strFichierDest.Substring(nPos);
                else
                    strFile = strFichierDest + "_" + nIndex;
            }
            File.Move(strFichierSource, strFile);
            strFichierDest = strFile;
        }

        //----------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        public static void OnTimerTraitement(object target)
        {
            CResultAErreur result = CResultAErreur.True;

            TimeSpan ts = DateTime.Now - m_lastDateDebutTraitementShort;
            if (m_bTraitementEnCours)
            {
                if (ts.TotalMinutes < 5)
                    return;
                else
                {
                    C2iEventLog.WriteErreur("CCamusatQowisioDataServeur : data processing >= 5 minutes");
                    return;
                }
            }

            m_bTraitementEnCours = true;
            m_lastDateDebutTraitementShort = DateTime.Now;

            // Determine le mode du traitement SHORT/MEDIUM/FULL
            EModeTraitment modeTraitement = EModeTraitment.SHORT;

            ts = DateTime.Now - m_lastDateDebutTraitementMedium;
            if (ts.TotalMilliseconds >= c_nDelaiTraitementMedium)
            {
                modeTraitement = modeTraitement | EModeTraitment.MEDIUM;
                m_lastDateDebutTraitementMedium = DateTime.Now;
            }
            ts = DateTime.Now - m_lastDateDebutTraitementMedium;
            if (ts.TotalMilliseconds >= c_nDelaiTraitementFull)
            {
                modeTraitement = modeTraitement | EModeTraitment.FULL;
                m_lastDateDebutTraitementFull = DateTime.Now;
            }

            try
            {
                System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Lowest;
                try
                {
                    m_sessionClient = CSessionClient.CreateInstance();
                    result = m_sessionClient.OpenSession(new CAuthentificationSessionServer(),
                        "Qowisio XML data processing",
                        ETypeApplicationCliente.Service);
                    if (!result)
                    {
                        C2iEventLog.WriteErreur("Working session openning error for CCamusatQowisioDataServeur");
                        return;
                    }
                    
                    try
                    {
                        //Récupère les fichiers FTP
                        string strFTPserver = CCamusatQowisioServeurRegistre.FTPServer;
                        string strFTPuser = CCamusatQowisioServeurRegistre.FTPUser;
                        string strFTPpassword = CCamusatQowisioServeurRegistre.FTPPassword;
                        int nFTPport = CCamusatQowisioServeurRegistre.FTPPort;
                        string strIncomingDirectory = CCamusatQowisioServeurRegistre.FTPIncomingDirectory;

                        List<string> listeFichiersATraiter = new List<string>();
                        ArrayList listFiles = null;

                        string strLastFile = new CDataBaseRegistrePourClient(m_sessionClient.IdSession).GetValeurString(c_strCleDernierFichierTraité, "");

                        Sftp ftp = new Sftp(strFTPserver, strFTPuser, strFTPpassword);
                        try
                        {
                            ftp.Connect(); /* Open the FTP connection */


                            listFiles = ftp.GetFileList(strIncomingDirectory);
                            listFiles.Sort();
                            listFiles.Reverse();
                            /*
                                                            // constitue la liste des fichiers à traiter
                                                            listFiles.AddRange(ftp.GetFiles());
                                                            listFiles.Sort(new CFtpFileInfoComparer());
                                                            listFiles.Reverse();*/

                            foreach (string strFtpFile in listFiles)
                            {
                                if (strFtpFile.CompareTo(strLastFile) <= 0)
                                    break;
                                string strWorkFile = WorkDir + "\\" + strFtpFile;
                                if (strFtpFile.ToUpper().EndsWith("XML"))
                                {
                                    if (!File.Exists(strWorkFile))
                                    {
                                        ftp.Get(strIncomingDirectory + "/" + strFtpFile, strWorkFile);
                                        //ftp.GetFile(fileInfo.Name, strWorkFile, false); /* download /incoming/file.txt as file.txt to current executing directory, overwrite if it exists */
                                        //ftp.RemoveFile(fileInfo.Name);
                                    }
                                    listeFichiersATraiter.Insert(0, strFtpFile);
                                }

                            }
                            if (listeFichiersATraiter.Count > 0)
                                new CDataBaseRegistrePourClient(m_sessionClient.IdSession).SetValeur(c_strCleDernierFichierTraité, listeFichiersATraiter[listeFichiersATraiter.Count - 1]);


                            ftp.Close();
                        }
                        catch (Exception ex)
                        {
                            C2iEventLog.WriteErreur("CCamusatQowisioDataServeur error openning FTP connection: " + ex.Message);
                        }
                        finally
                        {
                            ftp.Close();
                        }

                        // Traite la liste des fichiers à traiter
                        using (CContexteDonnee contexte = new CContexteDonnee(m_sessionClient.IdSession, true, false))
                        {
                            List<string> lstFichiersWork = new List<string>(Directory.GetFiles(WorkDir, "*.xml"));
                            lstFichiersWork.Sort();

                            //CCamusatQowisioDataServeur serveur = new CCamusatQowisioDataServeur(m_sessionClient.IdSession);
                            foreach (string strWorkFile in lstFichiersWork)
                            {
                                try
                                {
                                    string strNomFichier = Path.GetFileName(strWorkFile);

                                    // Traitement d'un fichier XML
                                    result = TraiteFichierQowisio(strWorkFile, contexte, modeTraitement);
                                    string strArchive = DoneDir + "\\" + strNomFichier;
                                    if (result)
                                    {

                                        MoveSafely(strWorkFile, ref strArchive);
                                    }
                                    else
                                    {
                                        strArchive = ErrorDir + "\\" + strNomFichier;
                                        MoveSafely(strWorkFile, ref strArchive);
                                        FileStream stream = new FileStream(strArchive + ".Err", FileMode.CreateNew, FileAccess.Write);
                                        StreamWriter writer = new StreamWriter(stream);
                                        writer.Write(result.MessageErreur);
                                        writer.Close();
                                        stream.Close();
                                    }
                                }
                                catch (Exception e)
                                {
                                    C2iEventLog.WriteErreur("CCamusatQowisioDataServeur error while processing file : " + strWorkFile + " - " + e.Message);
                                }

                            }
                        }



                    }
                    catch (Exception ex)
                    {
                        C2iEventLog.WriteErreur("CCamusatQowisioDataServeur error processing files : " + ex.Message);
                    }
                    finally
                    {
                        try
                        {
                            m_sessionClient.CloseSession();
                        }
                        catch { }

                    }

                }
                catch (Exception e)
                {
                    C2iEventLog.WriteErreur("CCamusatQowisioDataServeur error in OnTimerTraitement : " + e.Message);
                }
            }
            catch (Exception ex)
            {
                C2iEventLog.WriteErreur("CCamusatQowisioDataServeur error in OnTimerTraitement : " + ex.Message);
            }
            finally
            {
                m_bTraitementEnCours = false;
            }
        }


        //------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strXmlFile"></param>
        /// <param name="contexte"></param>
        private static CResultAErreur TraiteFichierQowisio(string strXmlFile, CContexteDonnee contexte, EModeTraitment modeTraitement)
        {
            CResultAErreur result = CResultAErreur.True;

            try
            {
                XmlDocument fichierXmlQowisio = new XmlDocument();
                fichierXmlQowisio.Load(strXmlFile);

                XmlNode nodeExport = fichierXmlQowisio.SelectSingleNode("export");
                if (nodeExport == null)
                {
                    result.EmpileErreur("<export> node not found in file : " + strXmlFile);
                    return result;
                }

                if ((modeTraitement & EModeTraitment.MEDIUM) == EModeTraitment.MEDIUM)
                {
                    XmlNode nodeInventory = nodeExport.SelectSingleNode("inventory");
                    if (nodeInventory != null)
                    {
                        result += TraiteInventaireQowisio(nodeInventory, contexte);
                        if (!result)
                        {
                            C2iEventLog.WriteErreur("CCamusatQowisioDataServeur error in TraiteInventaireQowisio : " + result.MessageErreur);
                            return result;
                        }
                    }
                }
                if ((modeTraitement & EModeTraitment.SHORT) == EModeTraitment.SHORT)
                {
                    XmlNode nodeData = nodeExport.SelectSingleNode("data");
                    if (nodeData != null)
                    {
                        result = TraiteDataQowisio(nodeData, contexte);
                        if (!result)
                        {
                            C2iEventLog.WriteErreur("CCamusatQowisioDataServeur error in TraiteDataQowisio : " + result.MessageErreur);
                        }
                    }
                    XmlNode nodeAlarms = nodeExport.SelectSingleNode("alarms");
                    if (nodeAlarms != null)
                    {

                        result = TraiteAlarmesQowisio(nodeAlarms, contexte);
                        if (!result)
                        {
                            C2iEventLog.WriteErreur("CCamusatQowisioDataServeur error in TraiteAlarmesQowisio : " + result.MessageErreur);
                        }
                    }
                }
                result = contexte.SaveAll(true);
                if (!result)
                    C2iEventLog.WriteErreur(result.MessageErreur);
            }

            catch (Exception e)
            {
                string strErreur = "CCamusatQowisioDataServeur error in TraiteFichierQowisio : " + e.Message;
                C2iEventLog.WriteErreur(strErreur);
                result.EmpileErreur(strErreur);
                Console.WriteLine(strErreur);
                return result;
            }
            finally
            {
            }

            return result;
        }


        //------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fichierXml"></param>
        /// <param name="contexte"></param>
        /// <returns></returns>
        private static CResultAErreur TraiteInventaireQowisio(XmlNode nodeInventory, CContexteDonnee contexte)
        {
            CResultAErreur result = CResultAErreur.True;

            if (nodeInventory != null)
            {
                XmlNode nodeHosts = nodeInventory.FirstChild;
                if (nodeHosts != null)
                {
                    foreach (XmlNode nodeHost in nodeHosts.ChildNodes)
                    {
                        // Traitement du Host
                        string strHostId = nodeHost.SelectSingleNode("host_id").InnerText;
                        string strHostType = nodeHost.SelectSingleNode("type").InnerText;
                        string strHostName = nodeHost.SelectSingleNode("name").InnerText;

                        result = AssureHostExiste(strHostId, strHostType, strHostName, contexte);
                        if (!result)
                        {
                            result.EmpileErreur("Error in AssureHostExiste fo host : " + strHostId + " - " + strHostName);
                            return result;
                        }
                        else
                        {
                            CEquipementLogique parentHost = result.Data as CEquipementLogique;
                            if (parentHost == null)
                            {
                                result.EmpileErreur("Parent Host is null");
                                return result;
                            }
                            // Traitement des sondes
                            XmlNode nodeProbes = nodeHost.SelectSingleNode("FuelProbes");
                            foreach (XmlNode nodeProbe in nodeProbes.ChildNodes)
                            {
                                string strFuelProbeId = nodeProbe.SelectSingleNode("FuelProbe_id").InnerText;
                                string strTankShape = nodeProbe.SelectSingleNode("TankShape").InnerText;
                                string strTankDimensions = nodeProbe.SelectSingleNode("TankDimensions").InnerText;
                                string strTankCapacity = nodeProbe.SelectSingleNode("TankCapacity").InnerText;
                                string strFuelProbeType = nodeProbe.SelectSingleNode("FuelProbeType").InnerText;

                                result = AssureProbeExiste(
                                    parentHost,
                                    strFuelProbeId,
                                    strTankShape,
                                    strTankDimensions,
                                    strTankCapacity,
                                    strFuelProbeType,
                                    contexte);
                                if (!result)
                                {
                                    result.EmpileErreur("Error in AssureProbeExiste fo Probe : " + strFuelProbeId + " - " + strFuelProbeType);
                                    return result;
                                }

                            }
                        }
                    }
                }
                else
                {
                    result.EmpileErreur("XML node <hosts> not found in file : " + nodeInventory.Name);
                    return result;

                }
            }
            else
            {
                result.EmpileErreur("XML node <inventory> not found");
                return result;
            }


            return result;
        }

        //-------------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fichierXml"></param>
        /// <param name="contexte"></param>
        /// <returns></returns>
        private static CResultAErreur TraiteDataQowisio(XmlNode nodeData, CContexteDonnee contexte)
        {
            CResultAErreur result = CResultAErreur.True;

            if (nodeData != null)
            {
                foreach (XmlNode nodeHostDatas in nodeData.ChildNodes)
                {
                    foreach (XmlNode cData in nodeHostDatas.ChildNodes)
                    {
                        string strDataCsv = cData.InnerText;
                        result += TraiteCsvDataRow(strDataCsv, contexte);
                    }
                }
            }

            return result;
        }

        //-------------------------------------------------------------------------------------------
        private static CResultAErreur TraiteCsvDataRow(string strCsvRow, CContexteDonnee contexte)
        {
            CResultAErreur result = CResultAErreur.True;

            try
            {
                CCamusatQowisioData data = CCamusatQowisioData.StaticTraiteDataRowFromCsv(contexte, strCsvRow).DataType;
                
            }
            catch (Exception ex)
            {
                result.EmpileErreur(ex.Message);
            }

            return result;
        }



        //-------------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fichierXml"></param>
        /// <param name="contexte"></param>
        /// <returns></returns>
        private static CResultAErreur TraiteAlarmesQowisio(XmlNode nodeAlarms, CContexteDonnee contexte)
        {
            CResultAErreur result = CResultAErreur.True;

            if (nodeAlarms != null)
            {
                // Traitement des alarmes ici
                foreach (XmlNode nodeHostDatas in nodeAlarms.ChildNodes)
                {
                    foreach (XmlNode cData in nodeHostDatas.ChildNodes)
                    {
                        string strAlarmCsv = cData.InnerText;
                        result += TraiteCsvAlarmRow(strAlarmCsv, contexte);
                    }
                }

            }

            return result;
        }

        private static CResultAErreur TraiteCsvAlarmRow(string strAlarmCsv, CContexteDonnee contexte)
        {
            CResultAErreur result = CResultAErreur.True;

            try
            {
                CCamusatQowisioAlarm newAlarm = new CCamusatQowisioAlarm(contexte);
                newAlarm.CreateNewInCurrentContexte();
                result = newAlarm.TraiteAlarmRowFromCsv(strAlarmCsv);
                if (!result)
                    newAlarm.CancelCreate();
            }
            catch (Exception ex)
            {
                result.EmpileErreur(ex.Message);
            }
            return result;
        }

        //------------------------------------------------------------------------------------
        /// <summary>
        /// Assure l'exostance d'un Host partir des données fournies.
        /// Créé l'équipemtn logique du bon type si le Host n'existe pas
        /// </summary>
        /// <param name="strHostId"></param>
        /// <param name="strType"></param>
        /// <param name="strName"></param>
        /// <returns></returns>
        private static CResultAErreur AssureHostExiste(string strHostId, string strType, string strName, CContexteDonnee contexte)
        {
            CResultAErreur result = CResultAErreur.True;
            // Vérifie si le host existe ans Timos

            CTypeEquipement typeEquipement = new CTypeEquipement(contexte);
            result = CCamusatQowisioData.GetEquipementLogiqueFromQowisioId(strHostId, contexte);
            if (!result)
                return result;
            CEquipementLogique qowisioBox = result.Data as CEquipementLogique;

            if (strType == "SITE" && typeEquipement.ReadIfExists(CCamusatQowisioData.c_nIdTypeEquipementQowisioVirtualSite))
            {
                // C'est trouvé, rien à faire de plus
            }
            else if (strType == "PICKUP" && typeEquipement.ReadIfExists(CCamusatQowisioData.c_nIdTypeEquipementQowisioBoxVehicule))
            {
                // Trouvé
            }
            else
            {
                result.EmpileErreur("No Equipment Type found for Host Id : " + strHostId);
                return result;
            }

            if (qowisioBox == null)
            {
                // Créer un nouvel equipement logique Timos
                CSite siteAwaitingElements = new CSite(contexte);
                if (siteAwaitingElements.ReadIfExists(CCamusatQowisioData.c_nIdSiteQowisionAwaitingElements))
                {
                    qowisioBox = new CEquipementLogique(contexte);
                    qowisioBox.CreateNewInCurrentContexte();
                    qowisioBox.TypeEquipement = typeEquipement;
                    qowisioBox.Site = siteAwaitingElements;
                    qowisioBox.SetValeurChamp(CCamusatQowisioData.c_nIdChampTimosQowisioId, strHostId);
                    qowisioBox.Libelle = strName;
                }
                else
                {
                    result.EmpileErreur("No Site found for awaiting elements. Host Id :  " + strHostId);
                    return result;
                }
            }   
            else
            {
                qowisioBox.TypeEquipement = typeEquipement;
            }

            result.Data = qowisioBox;
            return result;
        }

        //-----------------------------------------------------------------------------------------
        /// <summary>
        /// Assure l'existance d'une Fuel Probe partir des données fournies.
        /// Créé l'équipemtn logique du bon type si le Host n'existe pas
        /// </summary>
        /// <param name="strHostId"></param>
        /// <param name="strType"></param>
        /// <param name="strName"></param>
        /// <returns></returns>
        private static CResultAErreur AssureProbeExiste(CEquipementLogique parentQowisioBox, string strProbeId, string strTankShape, string strTankDimensions, string strTankCapacity, string strType, CContexteDonnee contexte)
        {
            CResultAErreur result = CResultAErreur.True;

            if (parentQowisioBox == null)
            {
                result.EmpileErreur("Can not create Qowisio Fuel Probe Id = " + strProbeId + " because parent Qowisio Box is nul");
                return result;
            }

            result = CCamusatQowisioData.GetEquipementLogiqueFromQowisioId(strProbeId, contexte);
            if (!result)
                return result;
            CEquipementLogique qowisioFuelProbe = result.Data as CEquipementLogique;

            if (qowisioFuelProbe == null)
            {
                // Créer un nouvel equipement logique Timos
                CSite siteAwaitingElements = new CSite(contexte);
                if (siteAwaitingElements.ReadIfExists(CCamusatQowisioData.c_nIdSiteQowisionAwaitingElements))
                {
                    CTypeEquipement typeEquipement = new CTypeEquipement(contexte);
                    if (typeEquipement.ReadIfExists(CCamusatQowisioData.c_nIdTypeEquipementQowisioFuelProbe))
                    {
                        qowisioFuelProbe = new CEquipementLogique(contexte);
                        qowisioFuelProbe.CreateNewInCurrentContexte();
                        qowisioFuelProbe.TypeEquipement = typeEquipement;
                        qowisioFuelProbe.EquipementLogiqueContenant = parentQowisioBox;
                        qowisioFuelProbe.Site = siteAwaitingElements; // Site des equipements logiques en attente d'affectation
                        qowisioFuelProbe.Libelle = "Fuel Probe " + strProbeId;
                        result = qowisioFuelProbe.SetValeurChamp(CCamusatQowisioData.c_nIdChampTimosQowisioId, strProbeId);
                        if (result)
                            result = qowisioFuelProbe.SetValeurChamp(CCamusatQowisioData.c_nIdChampTimosFuelProbeAssociatedTank, null); // Relation vers Tank
                        else
                            return result;
                    }
                    else
                    {
                        result.EmpileErreur("No Equipment Type found for Fuel Probe Id : " + strProbeId);
                        return result;
                    }
                }
                else
                {
                    result.EmpileErreur("No Site found for awaiting elements. Host Id :  " + strProbeId);
                    return result;
                }
            }
            else
            {
                if (qowisioFuelProbe.EquipementLogiqueContenant != parentQowisioBox)
                {
                    qowisioFuelProbe.EquipementLogiqueContenant = parentQowisioBox;
                    result = qowisioFuelProbe.SetValeurChamp(CCamusatQowisioData.c_nIdChampTimosFuelProbeAssociatedTank, null); // Relation vers Tank
                    if (!result)
                        return result;
                }
            }
            if (qowisioFuelProbe != null)
            {
                //  Maj champs de fuel probe (equipement logique)
                result = qowisioFuelProbe.SetValeurChamp(CCamusatQowisioData.c_nIdChampTimosFuelTankShape, strTankShape);
                if (result)
                    result = qowisioFuelProbe.SetValeurChamp(CCamusatQowisioData.c_nIdChampTimosFuelTankDimensions, strTankDimensions);
                if (result)
                    result = qowisioFuelProbe.SetValeurChamp(CCamusatQowisioData.c_nIdChampTimosFuelTankCapacity, strTankCapacity);
                if (result)
                    result = qowisioFuelProbe.SetValeurChamp(CCamusatQowisioData.c_nIdChampTimosFuelProbeType, strType);

                if (!result)
                    return result;

                // Maj champs de Tank (equipement physique)
                CEquipement tank = qowisioFuelProbe.GetValeurChamp(CCamusatQowisioData.c_nIdChampTimosFuelProbeAssociatedTank) as CEquipement;
                if (tank != null)
                {
                    result = qowisioFuelProbe.SetValeurChamp(CCamusatQowisioData.c_nIdChampTimosFuelTankShape, strTankShape);
                    if (result)
                        result = qowisioFuelProbe.SetValeurChamp(CCamusatQowisioData.c_nIdChampTimosFuelTankDimensions, strTankDimensions);
                    if (result)
                        result = qowisioFuelProbe.SetValeurChamp(CCamusatQowisioData.c_nIdChampTimosFuelTankCapacity, strTankCapacity);
                }
            }

            result.Data = qowisioFuelProbe;
            return result;
        }
    }
}
