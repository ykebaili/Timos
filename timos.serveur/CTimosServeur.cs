using System;
using System.Runtime.Remoting;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Timers;
using System.IO;
using System.Data;
using System.Collections;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using sc2i.common;
using sc2i.multitiers.client;
using sc2i.multitiers.server;
using sc2i.data;
using sc2i.data.serveur;
using sc2i.data.dynamic.loader;
using sc2i.documents.serveur;
using sc2i.process.serveur;
using sc2i.workflow;
using sc2i.process;
using sc2i.custom;
using sc2i.data.dynamic;
using sc2i.documents;

using Lys.Licence;
using Lys.Applications.Timos.Smt;

using timos.data;
using timos.securite;
using timos.acteurs;
using timos.client;
using System.Data.OracleClient;
using System.Net;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using data.hotel.client;
using data.hotel.server;
using timos.data.snmp.polling;
using timos.data.supervision;
using timos.serveur.Licence;
using timos.client.Licence;
using sc2i.data.Package;
using sc2i.common.synchronisation;

namespace timos.serveur
{
	public class CTimosServeur
	{
		public static event EventHandler ArretServeur;

		public const string c_keyRestrictionAllUsers = "ALLUSERS";
		public const string c_mainDataSource = "MAIN_DATA";
		public const string c_droitsDataSource = "USER_RIGHTS_DEF";

		private static CTimosServeur m_instance = null;
		private static CSessionClient m_session = null;

		private Type m_typeConnection;

        private bool m_bReMAJ;

        private CLicenceLogicielPrtct m_LicenceLogiciel = null;
        private string m_strFichierLicenceCharge = "";
		private CConfigModulesTimos m_configModulesAppli = null;
        
        public bool MAJDerniereVersionBase
        {
            get
            {
                return m_bReMAJ;
            }
            set
            {
                m_bReMAJ = value;
            }
        }

		/// /////////////////////////////////////////////////////////
		protected CTimosServeur()
		{
            m_bReMAJ = false;
		}
		/// /////////////////////////////////////////////////////////
		[STAThread]
		public static CTimosServeur GetInstance()
		{
			if (m_instance == null)
				m_instance = new CTimosServeur();

			return m_instance;
		}


		private int m_nCptOp = 0;
		private IIndicateurProgression m_indicateur;
		public void AvancerIndicateur(string message)
		{
			if (m_indicateur != null)
			{
				m_nCptOp++;
				m_indicateur.SetInfo(message);
				m_indicateur.SetValue(m_nCptOp);
			}
		}

        //----------------------------------------------------
        public CLicenceLogicielPrtct LicenceLogiciel
        {
            get
            {
                return m_LicenceLogiciel;
            }
            set
            {
                m_LicenceLogiciel = value;
            }
        }

		//----------------------------------------------------
		public CConfigModulesTimos ModulesApplication
		{
			get
			{
				if (m_configModulesAppli == null)
				{
					if (LicenceLogiciel != null)
						m_configModulesAppli = CConfigModulesTimos.GetNewConfig(LicenceLogiciel.ModulesApp, new List<CLicenceModuleClientPrtct>());
				}
				return m_configModulesAppli;
			}
		}

		
		#region CheckLicence
		private System.Timers.Timer m_timerCheck = new System.Timers.Timer();

		/*private void StartLicenceTrigger()
		{
			m_timerCheck.AutoReset = true;
            m_timerCheck.Interval = 1000000;//toutes les Dix minutes
			m_timerCheck.Elapsed += new ElapsedEventHandler(m_timerCheck_Elapsed);
			m_timerCheck.Start();
		}*/

        /// <summary>
        /// Retrieves the linker timestamp.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        /// <remarks>http://www.codinghorror.com/blog/2005/04/determining-build-date-the-hard-way.html</remarks>
        private static System.DateTime RetrieveLinkerTimestamp(string filePath)
        {
            const int peHeaderOffset = 60;
            const int linkerTimestampOffset = 8;
            var b = new byte[2048];
            System.IO.FileStream s = null;
            try
            {
                s = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                s.Read(b, 0, 2048);
            }
            finally
            {
                if (s != null)
                    s.Close();
            }
            var dt = new System.DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(System.BitConverter.ToInt32(b, System.BitConverter.ToInt32(b, peHeaderOffset) + linkerTimestampOffset));
            return dt.AddHours(System.TimeZone.CurrentTimeZone.GetUtcOffset(dt).Hours);
        }

        private CResultAErreur CheckLicenceOK()
        {
            CResultAErreur result = CResultAErreur.True;

            if (LicenceLogiciel is CLicenceDemo)
                return result;


            if (!LicenceLogiciel.VerifieCleServeur())
            {
                result.EmpileErreur(I.T("License installation error|20003"));
                return result;
            }

            DateTime dt = RetrieveLinkerTimestamp(System.Reflection.Assembly.GetExecutingAssembly().Location);

            if (LicenceLogiciel != null && LicenceLogiciel.DateLimiteUpgradeLogiciel.AddDays(1) < dt)
            {
                result.EmpileErreur(I.T("Licence is not compatible for this Version. Maintenance contract is expired|20005"));
                return result;
            }

            //Vérifie que le support amovible est toujours présent
			if (LicenceLogiciel != null && LicenceLogiciel.IdSupportAmovible.Length > 0)
			{
                bool bCleTrouvee = false;
                ReadOnlyCollection<CDriveInfo> drives = CUtilDrives.GetPhysicalDrives();
				foreach (CDriveInfo d in drives)
                    if (d.ID == LicenceLogiciel.IdSupportAmovible)
                    {
                        bCleTrouvee = true;
                        break;
                    }
                if (!bCleTrouvee)
                    result.EmpileErreur(I.T("Licence error : removable media removed (@1)|20001",DateTime.Now.ToString() ) );
			}

            //Avant la version 5, le champ date limite servait de date limite d'installation
            if (LicenceLogiciel.VersionLicence >= 5 && LicenceLogiciel.DateLimiteUtilisation != null &&  LicenceLogiciel.DateLimiteUtilisation < DateTime.Now)
            {
                result.EmpileErreur(I.T("Licence error : Licence expired|20002"));
            }
            return result;
        }

        private DateTime? m_lastDateConnexionSite = null;
		private void m_timerCheck_Elapsed(object sender, ElapsedEventArgs e)
		{
            if (m_lastDateConnexionSite == null)
                m_lastDateConnexionSite = DateTime.Now.AddYears(-1);
            TimeSpan sp = DateTime.Now - m_lastDateConnexionSite.Value;
            if (sp.TotalHours > 12)//Toutes les 2 heures, vérification d'une MAJ de licence
                //sur le site WEB
            {
                //UpdateLicenceFromWeb();
                m_lastDateConnexionSite = DateTime.Now;
            }


            CResultAErreur result = CheckLicenceOK();

            if (!result)
            {
                C2iEventLog.WriteErreur(result.Erreur.ToString());
                CTimosServeur.m_instance = null;
                if (ArretServeur != null)
                    ArretServeur(this, new EventArgs());
            }
            else//Mise à jour du nombre d'éléments depuis la base
                try
                {
                    CLicenceCheckElementNb.GetInstance().RefreshNombreUtilises();
                }
                catch
                {
                }
		}

        private void UpdateLicenceFromWeb()
        {
            if (m_LicenceLogiciel != null)
            {
                CLicenceLogicielPrtct licence = null;
                if (CLicenceLogicielPrtct.MajFromWeb("http://www.futurocom.net", m_strFichierLicenceCharge))
                {
                    if (CLicenceLogicielPrtct.ImporterLicenceFromDisk(m_strFichierLicenceCharge, ref licence))
                    {
                        m_LicenceLogiciel = licence;
                        CLicenceCheckElementNb.GetInstance().Init(licence);
                    }
                }

            }
        }
		#endregion

		/// /////////////////////////////////////////////////////////
		[STAThread]
		public CResultAErreur InitServeur( string strFichierConfigRemoting, IIndicateurProgression indicateurProgress )
		{
			CResultAErreur result = CResultAErreur.True;
            try
            {
                C2iEventLog.Init("TIMOS", "Timos Server", NiveauBavardage.VraiPiplette);

                m_indicateur = indicateurProgress;
                if (m_indicateur != null)
                {
                    indicateurProgress.PushLibelle(I.T("Server Initialising|30006"));
                    indicateurProgress.PushSegment(0, 13);
                }

                #region lecture du fichier Licence
                if (indicateurProgress != null)
                    indicateurProgress.PushLibelle(I.T("Reading Licence...|10001"));

                try
                {
                    #region Lecture chemin physique
                    C2iEventLog.WriteInfo(AppDomain.CurrentDomain.BaseDirectory + CLicenceLogicielPrtct.GetLicenceFileName());

                    m_strFichierLicenceCharge = AppDomain.CurrentDomain.BaseDirectory + CLicenceLogicielPrtct.GetLicenceFileName();//"LLogiciel.txt"
                    m_LicenceLogiciel = CLicenceLogicielPrtct.ReadLicenceChezclient(
                        m_strFichierLicenceCharge);

                    if (LicenceLogiciel != null && LicenceLogiciel.VersionLicence < 3)
                    //Avant version 3 du gestionnaire de licence,
                    //i:l n'y avait pas de profils
                    {
                        CUserProfilPrtct profilSecour = new CUserProfilPrtct();
                        profilSecour.Nom = I.T("Spare profile > Please update your licence !|10000");
                        profilSecour.Id = "#?";
                        profilSecour.Priorite = 0;
                        profilSecour.Nombre = 100;
                        profilSecour.ModulesClient.AddRange(CConfigModulesTimos.ModulesClientPossibles);
                        m_LicenceLogiciel.ProfilsUtilisateurs.Add(profilSecour);

                        m_LicenceLogiciel.ModulesApp.Clear();
                        m_LicenceLogiciel.ModulesApp.AddRange(CConfigModulesTimos.ModulesApplicatifPossibles);

                    }
                    #endregion
                    #region Lecture Support Amovible
                    if (LicenceLogiciel == null)
                    {
                        m_strFichierLicenceCharge = "";
                        ReadOnlyCollection<CDriveInfo> drives = CUtilDrives.GetPhysicalDrives();
                        foreach (CDriveInfo d in drives)
                        {
                            foreach (char c in d.LettresPartitions)
                            {
                                string strPath = c + ":\\" + CLicenceLogicielPrtct.GetLicenceFileName();
                                if (File.Exists(strPath))
                                {
                                    CLicenceLogicielPrtct li = new CLicenceLogicielPrtct();
                                    result = CLicenceLogicielPrtct.ImporterLicenceFromDisk(strPath, ref li);
                                    if (result && li.IsInstallationAmovible
                                        && d.ID == li.IdSupportAmovible)
                                    {
                                        m_LicenceLogiciel = li;
                                        m_strFichierLicenceCharge = strPath;
                                        break;
                                    }
                                }
                            }
                            if (LicenceLogiciel != null)
                                break;
                        }
                    }
                    #endregion


                    if (LicenceLogiciel == null)
                        LicenceLogiciel = new CLicenceDemo();

                    if (LicenceLogiciel == null)
                    {
                        result.EmpileErreur(I.T("Licencing error, no licence file|20000"));
                        return result;
                    }

                    if (LicenceLogiciel != null)
                    {

                        result = CheckLicenceOK();
                        if (!result)
                        {
                            //UpdateLicenceFromWeb();
                            result = CheckLicenceOK();
                        }
                        /*if (result)
                            StartLicenceTrigger();*/

                    }
                }
                catch (Exception e)
                {
                    result.EmpileErreur(e.Message);
                    return result;
                }
                if (!result)
                    return result;
                #endregion

                AvancerIndicateur(I.T("Reading file timos.mes...|30007"));

                CTraducteur.ReadFichier("timos.mes");

                C2iEventLog.WriteInfo("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

                #region Configuration du remoting


                RemotingConfiguration.Configure(strFichierConfigRemoting, false);
                RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.Off;
                AvancerIndicateur(I.T("Remoting Configuration...|30008"));
                if (CTimosServeurRegistre.IsServeurSecondaire)
                {
                    C2iAppliServeur.SetValeur(CHandlerEvenementServeur.c_cleDesactivation, true);
                    C2iAppliServeur.SetValeur(CDocumentGEDServeur.c_cleDesactivationNettoyage, true);
                    C2iEventLog.WriteInfo("Le service Timos est un serveur secondaire", NiveauBavardage.PetiteCausette);
                }

                AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);

                C2iSponsor.EnableSecurite();
                #endregion

                #region Configuration de l'allocateur d'objets
                C2iFactory.InitFromFile(strFichierConfigRemoting);

                AvancerIndicateur(I.T("Opening session...|30009"));

                m_session = CSessionClient.CreateInstance();
                result = m_session.OpenSession(new CAuthentificationSessionServer(), "Serveur d'objets", ETypeApplicationCliente.Service);
                if (!result)
                {
                    result.EmpileErreur(I.T("Opening session error|30010"));
                    return result;
                }

                //Configuration du DataHotel interne
                CDataRoomManager.RepertoireStockage = CTimosServeurRegistre.RepertoireDataHotelInterne;
                result = CDataRoomServer.Init(strFichierConfigRemoting, false);
                if (!result)
                    return result;

                //Configuration du DataHotel de polling
                CSnmpPollingHotelServer.InitPollingUrl(CTimosServeurRegistre.URLDataHotelPolling);

                result = CLicenceUsagePolling.InitUsagePolling(new CTimosServeurRegistre().GetFactoryURL());


                CSc2iDataServer.AddDefinitionConnexion(
                    new CDefinitionConnexionDataSource(
                    c_droitsDataSource,
                    typeof(CGestionnaireDroitsUtilisateurs),
                    ""));

                CSc2iDataServer.SetIdConnexionForClasse(typeof(CDroitUtilisateurServeur), c_droitsDataSource);
                #endregion

                #region Configuration de la base de données
                AvancerIndicateur(I.T("Database connexion...|30011"));

                //Récuperation du type de connection
                m_typeConnection = CTimosServeurRegistre.TypeConnection;

                CSc2iDataServer.Init(
                    new CDefinitionConnexionDataSource(
                    c_mainDataSource,
                    m_typeConnection,
                    CTimosServeurRegistre.DatabaseConnexionString,
                    CTimosServeurRegistre.PrefixeTablesSMT));
                #endregion

                #region Ajout des références DLL
                AvancerIndicateur(I.T("Adding DLL references...|30012"));

                AppDomain.CurrentDomain.Load("sc2i.data.dynamic");
                AppDomain.CurrentDomain.Load("sc2i.data.dynamic.loader");
                AppDomain.CurrentDomain.Load("sc2i.process");
                AppDomain.CurrentDomain.Load("sc2i.process.serveur");
                AppDomain.CurrentDomain.Load("sc2i.documents");
                AppDomain.CurrentDomain.Load("sc2i.documents.serveur");
                AppDomain.CurrentDomain.Load("sc2i.expression");
                AppDomain.CurrentDomain.Load("sc2i.Formulaire");
                AppDomain.CurrentDomain.Load("futurocom.sig");
                AppDomain.CurrentDomain.Load("futurocom.sig.server");
                AppDomain.CurrentDomain.Load("Timos.data");
                AppDomain.CurrentDomain.Load("Timos.data.serveur");

                #region Teste la connexion
                AvancerIndicateur(I.T("Connexion test...|30013"));
                IDatabaseConnexion cnx = CSc2iDataServer.GetInstance().GetDatabaseConnexion(m_session.IdSession, c_mainDataSource);

                //Attend la connexion pendant au max 5 minutes pour que ça démarre
                DateTime dtStartAttente = DateTime.Now;
                TimeSpan delaiAttente = DateTime.Now - dtStartAttente;
                result = cnx.IsConnexionValide();
                while (!result && delaiAttente.TotalSeconds < 5 * 60)
                {
                    C2iEventLog.WriteErreur(result.MessageErreur);
                    delaiAttente = DateTime.Now - dtStartAttente;
                    C2iEventLog.WriteErreur(I.T("Connection not availiable(@1)|30014", delaiAttente.TotalSeconds.ToString() + " s)") +
                        Environment.NewLine +
                        CTimosServeurRegistre.DatabaseConnexionString);
                    string messageErreur = I.T("The connection with the database could not have been established. Verify the connection string and check if the database has been started|30015");
                    C2iEventLog.WriteErreur(messageErreur);

                    result.EmpileErreur(messageErreur);
                    return result;
                }

                if (typeof(CSqlDatabaseConnexion).IsAssignableFrom(m_typeConnection))
                    cnx.RunStatement("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                else if (typeof(COracleDatabaseConnexion).IsAssignableFrom(m_typeConnection))
                {
                    ((COracleDatabaseConnexion)cnx).NomTableSpaceIndex = CTimosServeurRegistre.NomTableSpaceIndexOracle;
                    cnx.RunStatement("SET TRANSACTION ISOLATION LEVEL SERIALIZABLE");
                }
                C2iEventLog.WriteInfo("Database : " + CTimosServeurRegistre.DatabaseConnexionString, NiveauBavardage.VraiPiplette);

                #endregion

                CDataHotelClient.RegisterProxyForClients();

                CGestionnairePlugins.InitPlugins(AppDomain.CurrentDomain.BaseDirectory, "plg");
                CGestionnairePlugins.InitPlugins(CTimosServeurRegistre.RepertoirePlugins, "");
                // Initialilsation des plugins à partir de TIMOS_REGISTRY
                CDatabaseRegistre registre = new CDatabaseRegistre(m_session.IdSession);
                string strFUT_SRV = registre.GetValeurString("FUT_SRV", "");
                if (strFUT_SRV.Trim() != string.Empty)
                {
                    List<string> listPluginFiles = new List<string>();
                    foreach (string strNomPlg in strFUT_SRV.Split(';'))
                    {
                        string strTmp = AppDomain.CurrentDomain.BaseDirectory + strNomPlg;
                        if (File.Exists(strTmp))
                            listPluginFiles.Add(strTmp);
                    }
                    CGestionnairePlugins.LoadPlugins(listPluginFiles.ToArray());
                }

                foreach (Assembly ass in AppDomain.CurrentDomain.GetAssemblies())
                    CContexteDonnee.AddAssembly(ass);
                #endregion


                if (LicenceLogiciel is CLicenceDemo)
                {
                    ((CLicenceDemo)LicenceLogiciel).InitTypesProteges();
                    CLicenceCheckElementNb.GetInstance().RefreshNombreUtilises();
                }


                CTimosServeurRegistre.InitRegistreApplication(new CTimosServeurRegistre());
                //Initialisation des classes autoexecutables
                
                //Démarre les autoexecs, mais pas les services en tâche de fond
                CAutoexecuteurClasses.RunAutoexecsWithExclude(AutoExecAttribute.BackGroundService);

                // 
                CSessionClientSurServeur.RegisterFournisseurTransactions(CGestionnaireTransactionsSynchroniseur.GetInstance());

                //Initialisation du serveur de documents GED
                AvancerIndicateur(I.T("EDM documents server initialisation...|30016"));

                CDocumentGEDServeur.Init(CTimosServeurRegistre.RepertoireGED, CTimosServeurRegistre.TypeStockageAutorisePourLesUtilisateurs);

                //Initialisation de la base d'utilisateurs AD
                //CAdBase.Init(CTimosServeurRegistre.RacineAd,"","");

                //Initialise les fournisseurs de services
                //CSessionClientSurServeur.RegisterFournisseur( new CFournisseurFiltresForSynchronisation() );

                //Initialise les restrictions standards
                CConfigurationRestrictions.InitFromXml(strFichierConfigRemoting);

                #region Vérifie que les champs des tables font bien moins de 25 cars
                AvancerIndicateur(I.T("Table Names Verification...|30017"));

                DateTime dt = DateTime.Now;
                int nNbTypes = 0;
                int nNbChamps = 0;

                foreach (Type tp in CContexteDonnee.GetAllTypes())
                {
                    nNbTypes++;
                    try
                    {
                        CStructureTable structure = CStructureTable.GetStructure(tp);
                        if (structure.NomTable.Length > 25)
                            result.EmpileErreur("Table " + structure.NomTable + " (" + tp.ToString() + ")=" + structure.NomTable.Length + "cars");
                        if (structure.NomTable.ToUpper() != structure.NomTable)
                            result.EmpileErreur(I.T("Table name @1 must be uppercase|30018", structure.NomTable));
                        foreach (CInfoChampTable champ in structure.Champs)
                        {
                            nNbChamps++;
                            if (champ.NomChamp.Length > 25)
                                result.EmpileErreur("Table " + structure.NomTable + " (" + tp.ToString() + ")\t champ " + champ.NomChamp + "=" + champ.NomChamp.Length + "cars");
                            if (champ.NomChamp.ToUpper() != champ.NomChamp)
                                result.EmpileErreur(I.T("The name of the field '@1' of the field '@2' must be uppercase|30019", champ.NomChamp, structure.NomTable));
                        }
                    }
                    catch (Exception e)
                    {
                        result.EmpileErreur(e.Message);
                    }
                }
                TimeSpan sp = DateTime.Now - dt;
                Console.WriteLine(I.T("Table name verification |30020") + sp.TotalMilliseconds);
                if (!result)
                    return result;
                #endregion

                #region Mise à jour de la structure de la base
                AvancerIndicateur(I.T("Database structure update...|30021"));

                CUpdaterDataBase updaterDataBase = CUpdaterDataBase.GetInstance(cnx, new CTimosStructureBase());
                updaterDataBase.MAJDerniereVersionBase = m_bReMAJ;

                if (indicateurProgress != null)
                    indicateurProgress.PushSegment(m_nCptOp, m_nCptOp + 1);
                result = updaterDataBase.UpdateStructureBase(m_indicateur);
                if (indicateurProgress != null)
                    indicateurProgress.PopSegment();
                if (!result)
                    return result;

                if (OnMajStructureBaseEvent != null)
                    OnMajStructureBaseEvent(this, new EventArgs());

                //S'assure que la gestion des éléments est initialisé dans les licences
                CLicenceCheckElementNb.GetInstance();
                #endregion


                //Restrictions sur applications
                CListeRestrictionsUtilisateurSurType restrictionsModules = CModuleRestrictionProvider.GetRestrictionsApp(ModulesApplication);
                CConfigurationRestrictions.AjouteRestrictions(c_keyRestrictionAllUsers, restrictionsModules);


                //Initialisation des classes autoexecutables
                //CAutoexecuteurClasses.RunAutoexecs();


                //Initialisation du serveur de documents GED
                AvancerIndicateur(I.T("EDM documents server initialisation...|30016"));

                //CDocumentGEDServeur.Init(CTimosServeurRegistre.RepertoireGED);

                //Initialisation de la base d'utilisateurs AD
                //CAdBase.Init(CTimosServeurRegistre.RacineAd,"","");

                //Initialise les fournisseurs de services
                //CSessionClientSurServeur.RegisterFournisseur( new CFournisseurFiltresForSynchronisation() );



                AvancerIndicateur(I.T("Final Initialization|30022"));

                CGestionnaireEvenements.Init();

                foreach (string strServeur in CTimosServeurRegistre.ServeursAnnexes)
                    if (strServeur.Trim() != "")
                    {
                        C2iEventLog.WriteInfo("Second Server " + strServeur, NiveauBavardage.PetiteCausette);
                        CGestionnaireNotification.RegisterServeurAnnexe(strServeur);
                    }



                #region Création d'un utilisateur par défaut s'il n'y a pas d'utilisateurs
                using (CContexteDonnee contexte = new CContexteDonnee(0, true, false))
                {
                    CListeObjetsDonnees listeUsers = new CListeObjetsDonnees(contexte, typeof(CDonneesActeurUtilisateur));
                    if (listeUsers.Count == 0)
                    {
                        CActeur acteur = new CActeur(contexte);
                        acteur.CreateNew();
                        acteur.Nom = I.T("Temporary user|30026");
                        acteur.CommitEdit();
                        CDonneesActeurUtilisateur user = new CDonneesActeurUtilisateur(contexte);
                        user.CreateNew();
                        user.Acteur = acteur;
                        user.Login = "Administrator";
                        user.Password = C2iCrypto.Crypte("tochange");
                        user.IdProfilLicence = "";
                        result = user.CommitEdit();

                        // Affecte la licence la plus forte à l'utilisateur par défaut
                        int nPriorite = 0;
                        foreach (CUserProfilPrtct profil in m_LicenceLogiciel.ProfilsUtilisateurs)
                        {
                            // Recherche le profil de licence de priorité la plus forte (0 est la plus faible)
                            if (profil.Priorite >= nPriorite)
                            {
                                nPriorite = profil.Priorite;
                                user.IdProfilLicence = profil.Id;
                            }
                        }

                        // Affecte tous les Droits systèmes existants à l'utilisateur par défaut
                        CListeObjetsDonnees lstDroits = new CListeObjetsDonnees(contexte, typeof(CDroitUtilisateur));
                        foreach (CDroitUtilisateur droit in lstDroits)
                        {
                            CRelationActeurUtilisateur_Droit relation = new CRelationActeurUtilisateur_Droit(contexte);
                            relation.CreateNew();
                            relation.DonneeActeurUtilisateur = user;
                            relation.Droit = droit;
                            relation.CommitEdit();
                        }

                    }
                }
                #endregion

                if (!result)
                    return result;

                CVersionDonneesObjet.EnableJournalisation = ModulesApplication.GetRestrictionForModuleApp(CConfigModulesTimos.c_appModule_Journalisation_ID) != ERestriction.Hide;

                CGestionnaireObjetsAttachesASession.OnAttacheObjet += new LinkObjectEventHandler(CGestionnaireObjetsAttachesASession_OnAttacheObjet);

                //Initialise la gestion du nombre d'élément comptés
                CLicenceCheckElementNb.GetInstance();

               

                //Démarre les services en tâche de fond
                //Démarre les autoexecs, mais pas les services en tâche de fond
                CAutoexecuteurClasses.RunAutoexecsIncludeOnly(AutoExecAttribute.BackGroundService);

               
                

            }
            catch (ReflectionTypeLoadException loadex)
            {
                result.EmpileErreur(new CErreurException(loadex));
                StringBuilder bl = new StringBuilder();
                foreach (Exception exSub in loadex.LoaderExceptions)
                {
                    bl.AppendLine(exSub.Message);
                    FileNotFoundException exFileNotFound = exSub as FileNotFoundException;
                    if (exFileNotFound != null && !string.IsNullOrEmpty(exFileNotFound.FusionLog))
                    {
                        bl.AppendLine("Not found : " + exFileNotFound.FusionLog);
                    }
                }
                result.EmpileErreur(bl.ToString());
            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
            }
			return result;
		}

        public static event EventHandler OnMajStructureBaseEvent;

		//---------------------------------------------------------------------------------
		void CGestionnaireObjetsAttachesASession_OnAttacheObjet(int nIdSession, IObjetAttacheASession objetAttache)
		{
			CContexteDonnee contexte = objetAttache as CContexteDonnee;
			if ( contexte != null )
				contexte.OnChangeVersionDeTravail += new EventHandler(contexte_OnChangeVersionDeTravail);
		}

		//---------------------------------------------------------------------------------
		void contexte_OnChangeVersionDeTravail(object sender, EventArgs e)
		{
			CContexteDonnee contexte = sender as CContexteDonnee;
			if (contexte != null)
			{
				CSessionClient session = CSessionClient.GetSessionForIdSession(contexte.IdSession);
				try
				{
					session.RefreshUtilisateur();
				}
				catch
				{
				}
			}
		}
	}




	#region TO TEST

	public class CMAJ_StructureBase2 : IStructureDataBase
	{

		//---------------------------------------------------------------------------
		public int GetLastVersion()
		{
			return 3;
		}
		//---------------------------------------------------------------------------
		public C2iDataBaseUpdateOperationList GetListeTypeOfVersion(int nVersion)
		{
			C2iDataBaseUpdateOperationList lstRtr = new C2iDataBaseUpdateOperationList();
			switch (nVersion)
			{
				case 1: lstRtr = UpdateVersion1(); break;
				case 2: lstRtr = UpdateVersion2(); break;
				case 3: lstRtr = UpdateVersion3(); break;
				default:
					break;
			}

			return lstRtr;
		}

		//---------------------------------------------------------------------------
		private C2iDataBaseUpdateOperationList m_cacheLstV1;
		public C2iDataBaseUpdateOperationList UpdateVersion1()
		{

			if (m_cacheLstV1 != null)
				return m_cacheLstV1;
			else
				m_cacheLstV1 = new C2iDataBaseUpdateOperationList();

			#region sc2i.data et sc2i.data.dynamic
			m_cacheLstV1.Add(typeof(CVariableSurObjet));

			m_cacheLstV1.Add(typeof(CFormulaire));

			m_cacheLstV1.Add(typeof(CFiltreDynamiqueInDb));

			m_cacheLstV1.Add(typeof(CGroupeUtilisateursSynchronisation));

			m_cacheLstV1.Add(typeof(C2iStructureExportInDB));

			m_cacheLstV1.Add(typeof(CTypeDonneeCumulee));

			m_cacheLstV1.Add(typeof(CParametreSynchronisationInDb));

			m_cacheLstV1.Add(typeof(CDonneeCumulee));

			m_cacheLstV1.Add(typeof(CChampCalcule));

			m_cacheLstV1.Add(typeof(CChampCustom));

			m_cacheLstV1.Add(typeof(CValeurChampCustom));

			m_cacheLstV1.Add(typeof(CValeurVariableSurObjet));

			m_cacheLstV1.Add(typeof(CRelationGroupeUtilisateursSynchro_Utilisateurs));

			m_cacheLstV1.Add(typeof(CRelationRoleActeur_GroupeActeur));

			m_cacheLstV1.Add(typeof(CRelationFormulaireChampCustom));

			m_cacheLstV1.Add(typeof(CGroupeUtilisateursSynchronisation));
			#endregion

			#region sc2i.document
			m_cacheLstV1.Add(typeof(CCategorieGED));

			m_cacheLstV1.Add(typeof(CRelationDocumentGED_Categorie));

			m_cacheLstV1.Add(typeof(CDocumentGED));

			m_cacheLstV1.Add(typeof(CRelationCategorieGED_ChampCustom));

			m_cacheLstV1.Add(typeof(CRelationCategorieGED_Formulaire));

			m_cacheLstV1.Add(typeof(CRelationDocumentGED_ChampCustomValeur));

			m_cacheLstV1.Add(typeof(CRelationElementToDocument));

			m_cacheLstV1.Add(typeof(C2iCategorieRapportCrystal));

			m_cacheLstV1.Add(typeof(C2iRapportCrystal));
			#endregion

			#region skip

			//#region sc2i.process
			//m_cacheLstV1.Add(typeof(CGroupeParametrage));

			//m_cacheLstV1.Add(typeof(CProcessInDb));

			//m_cacheLstV1.Add(typeof(CSynchronismeDonnees));

			//m_cacheLstV1.Add(typeof(CEvenement));

			//m_cacheLstV1.Add(typeof(CProcessEnExecutionInDb));

			//m_cacheLstV1.Add(typeof(CComportementGenerique));

			//m_cacheLstV1.Add(typeof(CRelationDefinisseurComportementInduit));

			//m_cacheLstV1.Add(typeof(CRelationElementComportement));

			//m_cacheLstV1.Add(typeof(CHandlerEvenement));

			//m_cacheLstV1.Add(typeof(CBesoinInterventionProcess));
			//#endregion

			//#region sc2i.workflow
			//m_cacheLstV1.Add(typeof(CGrilleGenerique));

			//m_cacheLstV1.Add(typeof(CListeEntites));

			//m_cacheLstV1.Add(typeof(CRelationListeEntites_Entite));

			//m_cacheLstV1.Add(typeof(CPostIt));

			//m_cacheLstV1.Add(typeof(CTachePlanifiee));

			//m_cacheLstV1.Add(typeof(CRelationTachePlanifieeProcess));

			//m_cacheLstV1.Add(typeof(CRelationTachePlanifieeTypeDonneeCumulee));
			//#endregion

			//#region	Calendrier
			//m_cacheLstV1.Add(typeof(CCalendrier));

			//m_cacheLstV1.Add(typeof(CCalendrier_JourParticulier));

			//m_cacheLstV1.Add(typeof(CHoraireJournalier));

			//m_cacheLstV1.Add(typeof(CHoraireJournalier_Tranche));

			//m_cacheLstV1.Add(typeof(CTypeOccupationHoraire));
			//#endregion

			//#region Agenda
			//m_cacheLstV1.Add(typeof(CTypeEntreeAgenda));

			//m_cacheLstV1.Add(typeof(CRoleSurEntreeAgenda));

			//m_cacheLstV1.Add(typeof(CRelationTypeEntreeAgenda_ChampCustom));

			//m_cacheLstV1.Add(typeof(CRelationTypeEntreeAgenda_Formulaire));

			//m_cacheLstV1.Add(typeof(CRelationTypeEntreeAgenda_TypeElementAAgenda));

			//m_cacheLstV1.Add(typeof(CEntreeAgenda));

			//m_cacheLstV1.Add(typeof(CRelationEntreeAgenda_ElementAAgenda));

			//m_cacheLstV1.Add(typeof(CDesctivationEntreeAgendaCyclique));

			//m_cacheLstV1.Add(typeof(CEntreeAgenda_SynchroExt));

			//m_cacheLstV1.Add(typeof(CRelationEntreeAgenda_ChampCustom));
			//#endregion

			//#region Dossier
			//m_cacheLstV1.Add(typeof(CTypeDossierSuivi));

			//m_cacheLstV1.Add(typeof(CRelationTypeDossierSuivi_ChampCustom));

			//m_cacheLstV1.Add(typeof(CRelationTypeDossierSuivi_Formulaire));

			//m_cacheLstV1.Add(typeof(CRelationTypeDossierSuivi_TypeElement));

			//m_cacheLstV1.Add(typeof(CDossierSuivi));

			//m_cacheLstV1.Add(typeof(CRelationDossierSuivi_ChampCustom));

			//m_cacheLstV1.Add(typeof(CRelationDossierSuivi_Element));
			//#endregion

			//#region Sécurité
			//m_cacheLstV1.Add(typeof(CGroupeRestrictionSurType));

			//m_cacheLstV1.Add(typeof(CRestrictionChampCustom));

			//m_cacheLstV1.Add(typeof(CTypeEntiteOrganisationnelle));

			//m_cacheLstV1.Add(typeof(CRelationTypeEO_ChampCustom));

			//m_cacheLstV1.Add(typeof(CRelationTypeEO_Formulaire));

			//m_cacheLstV1.Add(typeof(CEntiteOrganisationnelle));

			//m_cacheLstV1.Add(typeof(CRelationEO_ChampCustom));

			//m_cacheLstV1.Add(typeof(CProfilUtilisateur));

			//m_cacheLstV1.Add(typeof(CProfilUtilisateur_Restriction));

			//m_cacheLstV1.Add(typeof(CRelationUtilisateur_Profil));

			//m_cacheLstV1.Add(typeof(CRelationElement_EO));

			//m_cacheLstV1.Add(typeof(CRelationUtilisateur_Profil_EO));

			//m_cacheLstV1.Add(typeof(CProfilUtilisateur_Inclusion));
			//#endregion

			////custom
			//m_cacheLstV1.Add(typeof(CMenuCustom));

			//#region Acteurs
			//m_cacheLstV1.Add(typeof(CCivilite));

			//m_cacheLstV1.Add(typeof(CActeur));

			//m_cacheLstV1.Add(typeof(CRelationActeurUtilisateur_Droit));

			//m_cacheLstV1.Add(typeof(CGroupeActeur));

			//m_cacheLstV1.Add(typeof(CRelationGroupeActeur_ChampCustom));

			//m_cacheLstV1.Add(typeof(CRelationGroupeActeur_Formulaire));

			//m_cacheLstV1.Add(typeof(CRelationGroupeActeurNecessite));

			//m_cacheLstV1.Add(typeof(CRelationGroupeActeur_GroupeActeur));

			//m_cacheLstV1.Add(typeof(CRelationActeur_ChampCustom));

			//m_cacheLstV1.Add(typeof(CRelationActeur_GroupeActeur));

			//m_cacheLstV1.Add(typeof(CDonneesActeurUtilisateur));

			//m_cacheLstV1.Add(typeof(CDonneesActeurClient));
			//#endregion

			////m_cacheLstV1.Add(typeof(CTestSecurite));

			//#region Sites
			//m_cacheLstV1.Add(typeof(CTypeSite));

			//m_cacheLstV1.Add(typeof(CSite));

			//m_cacheLstV1.Add(typeof(CRelationTypeSite_TypeSite));

			//m_cacheLstV1.Add(typeof(CRelationSite_ChampCustom));

			//m_cacheLstV1.Add(typeof(CRelationTypeSite_ChampCustom));

			//m_cacheLstV1.Add(typeof(CRelationTypeSite_Formulaire));
			//#endregion

			//#region Equipement
			//m_cacheLstV1.Add(typeof(CFamilleEquipement));

			//m_cacheLstV1.Add(typeof(CTypeEquipement));

			//m_cacheLstV1.Add(typeof(CRelationTypeEquipement_Heritage));

			//m_cacheLstV1.Add(typeof(CRelationTypeEquipement_ChampCustom));

			//m_cacheLstV1.Add(typeof(CRelationTypeEquipement_Formulaire));

			//m_cacheLstV1.Add(typeof(CEquipement));

			//m_cacheLstV1.Add(typeof(CRelationEquipement_ChampCustom));

			//m_cacheLstV1.Add(typeof(CRelationFamilleEquipement_ChampCustom));

			//m_cacheLstV1.Add(typeof(CRelationFamilleEquipement_Formulaire));

			//m_cacheLstV1.Add(typeof(CRelationTypeEquipement_ChampCustomValeur));

			//m_cacheLstV1.Add(typeof(CRelationTypeEquipement_TypesIncluables));

			//m_cacheLstV1.Add(typeof(CDonneesActeurFournisseur));

			//m_cacheLstV1.Add(typeof(CDonneesActeurConstructeur));

			//m_cacheLstV1.Add(typeof(CRelationTypeEquipement_Fournisseurs));

			//m_cacheLstV1.Add(typeof(CRelationTypeEquipement_Constructeurs));

			//m_cacheLstV1.Add(typeof(CTypeStock));

			//m_cacheLstV1.Add(typeof(CStock));

			//m_cacheLstV1.Add(typeof(CRelationTypeEquipement_TypeStock));

			//m_cacheLstV1.Add(typeof(CStatutEquipement));

			//m_cacheLstV1.Add(typeof(CMouvementEquipement));

			//m_cacheLstV1.Add(typeof(CRelationTypeEquipement_TypeRemplacement));
			//#endregion

			//#region Ressources et contraintes
			//m_cacheLstV1.Add(typeof(CTypeRessource));

			//m_cacheLstV1.Add(typeof(CRessourceMaterielle));

			//m_cacheLstV1.Add(typeof(CTypeContrainte));

			//m_cacheLstV1.Add(typeof(CContrainte));

			//m_cacheLstV1.Add(typeof(CRelationContrainte_Ressource));

			//m_cacheLstV1.Add(typeof(CRelationTypeContrainte_TypeRessource));

			//m_cacheLstV1.Add(typeof(CRelationTypeRessource_Formulaire));

			//m_cacheLstV1.Add(typeof(CRelationTypeContrainte_Formulaire));

			//m_cacheLstV1.Add(typeof(CRelationRessource_ChampCustomValeur));

			//m_cacheLstV1.Add(typeof(CRelationTypeRessource_ChampCustom));

			//m_cacheLstV1.Add(typeof(CRelationContrainte_ChampCustom));

			//m_cacheLstV1.Add(typeof(CRelationTypeContrainte_ChampCustom));

			//m_cacheLstV1.Add(typeof(CAttributRessource));

			//m_cacheLstV1.Add(typeof(CAttributContrainte));

			//m_cacheLstV1.Add(typeof(CAttributTypeContrainte));

			//m_cacheLstV1.Add(typeof(CMouvementRessource));
			//#endregion

			//#region Système de Coordonnées
			//m_cacheLstV1.Add(typeof(CRelationSystemeCoordonnees_FormatNumerotation));

			//m_cacheLstV1.Add(typeof(CSystemeCoordonnees));

			//m_cacheLstV1.Add(typeof(CFormatNumerotation));

			//m_cacheLstV1.Add(typeof(CUniteCoordonnee));

			//m_cacheLstV1.Add(typeof(CParametrageSystemeCoordonnees));

			//m_cacheLstV1.Add(typeof(CParametrageNiveau));
			//#endregion

			//#region Tickets
			//m_cacheLstV1.Add(typeof(CQualificationTicket));

			//m_cacheLstV1.Add(typeof(CTypeTicket));

			//m_cacheLstV1.Add(typeof(CTicket));

			//m_cacheLstV1.Add(typeof(CPhaseTicket));

			//m_cacheLstV1.Add(typeof(CRelationTicket_Site));

			//m_cacheLstV1.Add(typeof(CRelationTicket_EOconcernees));

			//m_cacheLstV1.Add(typeof(CUrgenceTicket));

			//m_cacheLstV1.Add(typeof(CDependanceTicket));

			//m_cacheLstV1.Add(typeof(CRelationTicket_ChampCustomValeur));

			//m_cacheLstV1.Add(typeof(CRelationTypeTicket_ChampCustom));

			//m_cacheLstV1.Add(typeof(CRelationTypeTicket_Formulaire));

			//m_cacheLstV1.Add(typeof(COrigineTicket));

			//m_cacheLstV1.Add(typeof(CTypeTicketContrat));

			//m_cacheLstV1.Add(typeof(CEtatCloture));

			//m_cacheLstV1.Add(typeof(CCauseGel));

			//m_cacheLstV1.Add(typeof(CGel));

			//m_cacheLstV1.Add(typeof(CRelationTypePhaseTicket_TypeIntervention));

			//m_cacheLstV1.Add(typeof(CLienTypePhase));

			//m_cacheLstV1.Add(typeof(CRelationPhase_ChampCustomValeur));

			//m_cacheLstV1.Add(typeof(CHistoriqueTicket));

			//m_cacheLstV1.Add(typeof(CActeursSelonProfil));

			//m_cacheLstV1.Add(typeof(CTypePhase));

			//m_cacheLstV1.Add(typeof(CTypeTicket_TypePhase));

			//m_cacheLstV1.Add(typeof(CNotePhase));
			//#endregion

			//#region Interventions

			//m_cacheLstV1.Add(typeof(CTypeContrat));
			//m_cacheLstV1.Add(typeof(CContrat), CTypeContrat.c_champId);
			//m_cacheLstV1.Add(new DelegueMethodeMAJ(CreateTypeContrat));
			//m_cacheLstV1.Add(typeof(CContrat));

			//m_cacheLstV1.Add(typeof(CTypeIntervention));


			//m_cacheLstV1.Add(typeof(CTypeOperation));

			//m_cacheLstV1.Add(typeof(CRelationTypeIntervention_ChampCustom));

			//m_cacheLstV1.Add(typeof(CRelationTypeIntervention_Formulaire));

			//m_cacheLstV1.Add(typeof(CTypeIntervention_TypeOperation));

			//m_cacheLstV1.Add(typeof(CIntervention));

			//m_cacheLstV1.Add(typeof(CRelationIntervention_ChampCustom));

			//m_cacheLstV1.Add(typeof(COperation));

			//m_cacheLstV1.Add(typeof(CRelationOperation_ChampCustom));

			//m_cacheLstV1.Add(typeof(CTypeIntervention_ProfilIntervenant));

			//m_cacheLstV1.Add(typeof(CIntervention_Intervenant));

			//m_cacheLstV1.Add(typeof(CFractionIntervention));

			//m_cacheLstV1.Add(typeof(CIntervention_Ressource));

			//#endregion

			//m_cacheLstV1.Add(typeof(CModeleTexte));

			//m_cacheLstV1.Add(typeof(CRemplacementEquipement));

			#endregion
			return m_cacheLstV1;
		}
		//---------------------------------------------------------------------------
		private C2iDataBaseUpdateOperationList m_cacheLstV2;
		public C2iDataBaseUpdateOperationList UpdateVersion2()
		{
			if (m_cacheLstV2 != null)
				return m_cacheLstV2;
			else
				m_cacheLstV2 = new C2iDataBaseUpdateOperationList();


			//m_cacheLstV2.Add(typeof(CTest));
			m_cacheLstV2.Add(new DelegueMethodeMAJ(DoErreur));


			#region Acteurs
			m_cacheLstV2.Add(typeof(CDonneesActeurClient));
			m_cacheLstV2.Add(typeof(CActeur));
			#endregion

			m_cacheLstV2.Add(typeof(CTypeOccupationHoraire));
			m_cacheLstV2.Add(typeof(CMouvementEquipement));

			m_cacheLstV2.Add(typeof(CTypeContrainte));
			m_cacheLstV2.Add(typeof(CContrainte));
			m_cacheLstV2.Add(typeof(CTypeSite));
			m_cacheLstV2.Add(typeof(CGroupeRestrictionSurType));

			#region Tickets
			m_cacheLstV2.Add(typeof(CTypePhase));
			m_cacheLstV2.Add(typeof(CTypeTicket_TypePhase));
			m_cacheLstV2.Add(typeof(CTicket));
			m_cacheLstV2.Add(typeof(CTypeTicket));
			m_cacheLstV2.Add(typeof(CPhaseTicket));
			m_cacheLstV2.Add(typeof(CNotePhase));
			m_cacheLstV2.Add(typeof(CLienTypePhase));
			#endregion

			#region Interventions et Suivi Activité
			m_cacheLstV2.Add(typeof(CTypeActiviteActeur));

			// Procédure de mise à jour du type de contrat obligatoire
			m_cacheLstV2.Add(typeof(CTypeContrat));
			m_cacheLstV2.Add(typeof(CContrat), CTypeContrat.c_champId);
			m_cacheLstV2.Add(new DelegueMethodeMAJ(CreateTypeContrat));
			m_cacheLstV2.Add(typeof(CContrat));

			m_cacheLstV2.Add(typeof(CActiviteActeur));
			m_cacheLstV2.Add(typeof(CIntervention_ActiviteActeur));
			m_cacheLstV2.Add(typeof(CRelationTypeActiviteActeur_ChampCustom));
			m_cacheLstV2.Add(typeof(CRelationTypeActiviteActeur_Formulaire));
			m_cacheLstV2.Add(typeof(CRelationActiviteActeur_ChampCustomValeur));
			m_cacheLstV2.Add(typeof(CTypeIntervention));
			m_cacheLstV2.Add(typeof(CIntervention));
			m_cacheLstV2.Add(typeof(CProfilElement));
			m_cacheLstV2.Add(typeof(CProfilElement_ProfilInclu));
			m_cacheLstV2.Add(typeof(CProfilElement_TypeEO));
			m_cacheLstV2.Add(typeof(CTypeOperation));
			m_cacheLstV2.Add(typeof(CTypeIntervention_TypeOperation));
			m_cacheLstV2.Add(typeof(CListeOperations));
			m_cacheLstV2.Add(typeof(CIntervention_ListeOperations));
			m_cacheLstV2.Add(typeof(CIntervention_Ressource));
			m_cacheLstV2.Add(typeof(CRelationContrat_ChampCustom));
			m_cacheLstV2.Add(typeof(CContrat_Site));
			m_cacheLstV2.Add(typeof(CContrat_ListeOperations));
			m_cacheLstV2.Add(typeof(CContratListeOp_Site));
			m_cacheLstV2.Add(typeof(COperation));

			#endregion

			m_cacheLstV2.Add(typeof(CTypeEntiteOrganisationnelle));
			m_cacheLstV2.Add(typeof(CParametrageSystemeCoordonnees));

			m_cacheLstV2.Add(typeof(CEvenement));
			m_cacheLstV2.Add(typeof(CSite));
			m_cacheLstV2.Add(typeof(CRelationTypeEquipement_Stock));
			m_cacheLstV2.Add(typeof(CRelationTypeEquipement_TypeStock));
			m_cacheLstV2.Add(typeof(CStock));
			m_cacheLstV2.Add(typeof(CTypeEquipement));
			m_cacheLstV2.Add(typeof(CTypeStock));
			m_cacheLstV2.Add(typeof(CRelationTypeEquipement_ChampCustomValeur));
			m_cacheLstV2.Add(typeof(CRelationFamilleEquipement_ChampCustom));
			m_cacheLstV2.Add(typeof(CRelationFamilleEquipement_Formulaire));

			m_cacheLstV2.Add(typeof(CActeursSelonProfil));
			m_cacheLstV2.Add(typeof(CGroupeActeur));
			m_cacheLstV2.Add(typeof(CRelationActeur_GroupeActeur));
			m_cacheLstV2.Add(typeof(CTypeIntervention_ProfilIntervenant));

			#region Projet
			m_cacheLstV2.Add(typeof(CTypeProjet));
			m_cacheLstV2.Add(typeof(CRelationTypeProjet_ChampCustom));
			m_cacheLstV2.Add(typeof(CRelationTypeProjet_Formulaire));

			m_cacheLstV2.Add(typeof(CProjet));
			m_cacheLstV2.Add(typeof(CRelationProjet_ChampCustom));

			m_cacheLstV2.Add(typeof(CLienDeProjet));

			m_cacheLstV2.Add(typeof(CAnomalieProjet));
			#endregion

			m_cacheLstV2.Add(typeof(CTypeOccupationHoraire));

			m_cacheLstV2.Add(typeof(CRelationTypeEO_FormulaireParType));
			m_cacheLstV2.Add(typeof(CRelationElementAEO_ChampCustom));

			m_cacheLstV2.Add(typeof(CRelationTypeDossierSuivi_Formulaire));
			m_cacheLstV2.Add(typeof(CRelationTypeDossierSuivi_ChampCustom));
			m_cacheLstV2.Add(typeof(CRelationDossierSuivi_ChampCustom));
			m_cacheLstV2.Add(typeof(CFractionIntervention));
			m_cacheLstV2.Add(typeof(CIntervention_Ressource));
			m_cacheLstV2.Add(typeof(CHandlerEvenement));
			m_cacheLstV2.Add(typeof(CBesoinInterventionProcess));
			//m_cacheLstV2.Add(typeof(CCauseGel));

			//Table parametrable
			m_cacheLstV2.Add(typeof(CTypeTableParametrable));
			m_cacheLstV2.Add(typeof(CTableParametrable));
			m_cacheLstV2.Add(typeof(CColonneTableParametrable));

			m_cacheLstV2.Add(typeof(CRelationTypeEquipement_TypeTableParametrable));
			m_cacheLstV2.Add(typeof(CRelationTypeSite_TypeTableParametrable));
			m_cacheLstV2.Add(typeof(CRelationEquipement_TableParametrable));
			m_cacheLstV2.Add(typeof(CRelationSite_TableParametrable));

			// Planning EO / Acteurs
			m_cacheLstV2.Add(typeof(CTypeTableauPlanning));
			m_cacheLstV2.Add(typeof(CTypeTableauPlanning_TrancheHoraire));
			m_cacheLstV2.Add(typeof(CEOplanifiee_Acteur));

			m_cacheLstV2.Add(typeof(CTypeEquipement));
			m_cacheLstV2.Add(typeof(CEquipement));
			m_cacheLstV2.Add(typeof(CRemplacementEquipement));

			m_cacheLstV2.Add(typeof(CVersionDonnees));
			m_cacheLstV2.Add(typeof(CVersionDonneesObjet));
			m_cacheLstV2.Add(typeof(CVersionDonneesObjetOperation));

			#region Stock
			m_cacheLstV2.Add(typeof(CTypeStock));
			m_cacheLstV2.Add(typeof(CStock));
			m_cacheLstV2.Add(typeof(CRelationStock_ChampCustomValeur));
			m_cacheLstV2.Add(typeof(CRelationTypeStock_ChampCustom));
			m_cacheLstV2.Add(typeof(CRelationTypeStock_Formulaire));

			#endregion


			return m_cacheLstV2;
		}

		//---------------------------------------------------------------------------		
		public static CResultAErreur CreateTypeContrat(IDataBaseCreator creator)
		{
			IDatabaseConnexion cnx = creator.Connection;
			CResultAErreur result = CResultAErreur.True;
			using (CContexteDonnee ctx = new CContexteDonnee(cnx.IdSession, true, false))
			{

				bool bTableContratExiste = false;
				bool bTableTypeContratExiste = false;

				string[] strTables = cnx.TablesNames;
				foreach (string nomTable in strTables)
				{
					if (nomTable == CContrat.c_nomTable)
						bTableContratExiste = true;
					if (nomTable == CTypeContrat.c_nomTable)
						bTableTypeContratExiste = true;
				}

				if (!bTableContratExiste || !bTableTypeContratExiste)
					return CResultAErreur.True;


				CListeObjetsDonnees listeTypeContrats = new CListeObjetsDonnees(ctx, typeof(CTypeContrat));
				CFiltreData filtre = new CFiltreData(CTypeContrat.c_champId + " is null");
				int nNbContrats = cnx.CountRecords(CContrat.c_nomTable, filtre);

				if (nNbContrats > 0)
				{
					CTypeContrat tp;
					if (listeTypeContrats.Count > 0)
					{
						tp = (CTypeContrat)listeTypeContrats[0];
					}
					else
					{
						tp = new CTypeContrat(ctx);
						tp.CreateNew();
						tp.Libelle = I.T("Standard Contract Type|1");
						result = tp.CommitEdit();
					}
					if (!result)
						return result;

					//Maintenant, passe tous les contrats qui sont à null, en pas null

					cnx.SetValeurChamp(
						CContrat.c_nomTable,
						new string[] { CTypeContrat.c_champId },
						new object[] { tp.Id }, filtre);
				}
			}
			return result;
		}
		public static CResultAErreur DoErreur(IDataBaseCreator creator)
		{
            IDatabaseConnexion cnx = creator.Connection;
			return CResultAErreur.False;
		}

		//---------------------------------------------------------------------------
		private C2iDataBaseUpdateOperationList m_cacheLstV3;
		public C2iDataBaseUpdateOperationList UpdateVersion3()
		{
			if (m_cacheLstV3 != null)
				return m_cacheLstV3;
			else
				m_cacheLstV3 = new C2iDataBaseUpdateOperationList();

			m_cacheLstV3.Add(typeof(CTypeOperation));
			m_cacheLstV3.Add(typeof(COperation));
			m_cacheLstV3.Add(new DelegueMethodeMAJ(Oracle_AddClePrimaireSC2I_SYNC_LOG));
			//m_cacheLstV3.Add(typeof(CTest));
			//m_cacheLstV3.Add(1, false);

			return m_cacheLstV3;
		}

		public static CResultAErreur Oracle_AddClePrimaireSC2I_SYNC_LOG(IDataBaseCreator creator)
		{
			IDatabaseConnexion cnx = creator.Connection;
			CResultAErreur result = CResultAErreur.True;
			if (typeof(COracleDatabaseConnexion).IsAssignableFrom(cnx.GetType()))
			{
				string strRqtTestExist = @"SELECT DISTINCT Contrainte.CONSTRAINT_NAME 
						FROM SYS.USER_CONS_COLUMNS Colonne, SYS.USER_CONSTRAINTS Contrainte 
						WHERE Colonne.CONSTRAINT_NAME = Contrainte.CONSTRAINT_NAME 
						AND (Colonne.TABLE_NAME ='SC2I_SYNC_LOG') 
						AND (Colonne.COLUMN_NAME='SSL_ID') 
						AND (Contrainte.CONSTRAINT_TYPE = 'P')";
				IDataAdapter adapter = cnx.GetSimpleReadAdapter(strRqtTestExist);
				DataSet ds = new DataSet();
				adapter.Fill(ds);
				if (ds.Tables.Count == 1)
				{
					DataTable dt = ds.Tables[0];
					if (dt.Rows.Count == 0)
					{
						string strRqt = @"ALTER TABLE SC2I_SYNC_LOG 
										ADD CONSTRAINT PK_SC2I_SYNC_LOG 
										PRIMARY KEY (SSL_ID)";
						if (((COracleDatabaseConnexion)cnx).NomTableSpaceIndex != "")
							strRqt += " using index tablespace " + ((COracleDatabaseConnexion)cnx).NomTableSpaceIndex;
						result = cnx.RunStatement(strRqt);
					}
				}
				else
					result.EmpileErreur(I.T("Impossible to update SC2I_SYNC_LOG|30023"));
			}
			return result;
		}
	}



	/*[Table(CTest.c_nomTable, CTest.c_champId, true)]
	[ObjetServeurURI("CTestServeur")]
	public class CTest : CObjetDonneeAIdNumeriqueAuto, IObjetALectureTableComplete
	{
		public const string c_nomTable = "CTEST";

		public const string c_champId = "CTEST_ID";
		public const string c_champString = "CTEST_STRING";
		public const string c_champBool = "CTEST_BOOL";
		public const string c_champDateTime = "CTEST_DATETIME";
		public const string c_champInt = "CTEST_INT";
		public const string c_champDouble = "CTEST_DOUBLE";

		/// /////////////////////////////////////////////
		public CTest(CContexteDonnee contexte)
			: base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CTest(DataRow row)
			: base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get { return Id.ToString(); }
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] { c_champId };
		}

		[TableFieldProperty(c_champString, 30, NullAutorise = false)]
		public string String
		{
			get { return (string)Row[c_champString]; }
			set { Row[c_champString] = value; }
		}

		[TableFieldProperty(c_champInt, NullAutorise = false)]
		public int Int
		{
			get { return (int)Row[c_champInt]; }
			set { Row[c_champInt] = value; }
		}
		[TableFieldProperty(c_champBool, NullAutorise = false)]
		public bool Bool
		{
			get { return (bool)Row[c_champBool]; }
			set { Row[c_champBool] = value; }
		}
		[TableFieldProperty(c_champDateTime, NullAutorise = false)]
		public DateTime DateTime
		{
			get { return (DateTime)Row[c_champDateTime]; }
			set { Row[c_champDateTime] = value; }
		}
		[TableFieldProperty(c_champDouble, NullAutorise = false)]
		public double Double
		{
			get { return (double)Row[c_champDouble]; }
			set { Row[c_champDouble] = value; }
		}


		const string c_champElement = "CTEST_ELEMENT";
		[Relation(CTypeSite.c_nomTable, CTypeSite.c_champId, c_champElement, true, false)]
		//[TableFieldProperty(c_champElement, NullAutorise = false)]
		public CTypeSite TypeSite
		{
			//get { return (int)Row[c_champElement]; }
			//set { Row[c_champElement] = value; }

			get
			{
			    return (CTypeSite)GetParent(c_champElement, typeof(CTypeSite));
			}
			set
			{
			    SetParent(c_champElement, value);
			}
		}
	}

	public class CTestServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
		public CTestServeur(int nIdSession)
			: base(nIdSession)
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable()
		{
			return CTest.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
		{
			CResultAErreur result = CResultAErreur.True;
			return result;
		}
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CTest);
		}
		//-------------------------------------------------------------------
	}*/

	#endregion
}
