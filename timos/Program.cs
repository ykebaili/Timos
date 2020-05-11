using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Threading;

using sc2i.common;
using sc2i.multitiers.client;
using sc2i.data;
using sc2i.win32.data;
using sc2i.win32.common;
using sc2i.workflow;

using timos.data;
using timos.acteurs;
using timos.client;
using timos.securite;

using Lys.Licence;
using System.Security.Principal;
using sc2i.win32.data.navigation;
using System.IO;
using sc2i.data.dynamic;
using System.Text;
using sc2i.win32.data.dynamic;
using sc2i.expression;
using System.Runtime.InteropServices;
using timos.data.projet.besoin;
using timos.FinalCustomer;
using timos.data.supervision;
using Microsoft.Win32;

namespace timos
{

    static class Program
    {

		private static void Lancer()
		{
			//MessageBox.Show("Test");
		}

        public static void SplashScreen()
        {
            Application.Run(new CFormSplash());
        }

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Test
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CFinalCustomerInformations.Init();

            SystemEvents.SessionEnding += SystemEvents_SessionEnding;

            Thread thSplash = new Thread(new ThreadStart(SplashScreen));
            thSplash.Start();
            //new CFormPoissonAvril().ShowDialog();
#if DEBUG
            Thread.Sleep(10000);

            //CRecepteurNotification recepteur = new CRecepteurNotification(-1, typeof(CDonneeNotificationServeurStarted));
            //recepteur.OnReceiveNotification += new NotificationEventHandler(recepteur_OnReceiveNotification);
            //Application.Run();
#endif

            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            CTraducteur.ReadFichier("timos.mes");

            //System.Threading.Thread.CurrentThread.ApartmentState = System.Threading.ApartmentState.STA;

            CServicePopupProgressionTimos serviceIndicateur = new CServicePopupProgressionTimos();
            IIndicateurProgression indicateur = null;/* = serviceIndicateur.GetNewIndicateurAndPopup();
			indicateur.SetInfo("Démarrage");*/
#if DEBUG
#else
            try
            {
#endif

            AppDomain.CurrentDomain.Load("futurocom.win32.sig");
            AppDomain.CurrentDomain.Load("futurocom.win32.chart");
            AppDomain.CurrentDomain.Load("data.hotel.easyquery");
            AppDomain.CurrentDomain.Load("data.hotel.easyquery.win32");

                CTimosAppRegistre timosRegistre = new CTimosAppRegistre();
                CResultAErreur result = timos.client.CInitialiseurClientTimos.InitClientTimos(timosRegistre, true, indicateur);

                /*GC.Collect();
                GC.WaitForPendingFinalizers();
                long nMemo = GC.GetTotalMemory(true);
                DateTime dtChrono = DateTime.Now;
                //for (int n = 0; n < 10000; n++)
                {
                    using (CContexteDonnee ctx = new CContexteDonnee(0, true, false))
                    {
                        for (int n = 0; n < 10000; n++)
                        {
                            using (CContexteDonnee ctx2 = ctx.GetContexteEdition())
                            {
                                CTypeAlarme tp = new CTypeAlarme(ctx2);
                                tp.ReadIfExists(129);
                            }
                        }
                    }
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
                long nMemo2 = GC.GetTotalMemory(true);
                System.Threading.Thread.Sleep(10000);
                TimeSpan sp = DateTime.Now - dtChrono;
                Console.WriteLine("TEST : " + sp.TotalMilliseconds);*/


                //serviceIndicateur.EndIndicateur(indicateur);
                if (!result)
                {
                    thSplash.Abort();
                    result.EmpileErreur(I.T("Error while opening application|1219"));
                    CFormAlerte.Afficher(result.Erreur, EFormAlerteBoutons.Ok, EFormAlerteType.Exclamation);
                }
                else
                {
                    
                    CSc2iWin32DataClient.Init(CFournisseurContexteDonnee.GetInstance());
                    CReferenceObjetDonnee.SetFournisseurContexteDonnee(CFournisseurContexteDonnee.GetInstance());

                    //Effet Fondu
                    CEffetFonduPourFormManager.EffetActif = timosRegistre.OptionsGraphiques_FonduActif;
                    if (AuthentifierUtilisateur(thSplash))
                    {
                        string strVersionServeur = CTimosApp.SessionClient.SessionSurServeur.GetVersionServeur();
                        string strVersionClient = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                        if (strVersionClient != strVersionServeur)
                        {
                            result.EmpileErreur(I.T("Server (@2) and client (@1) version doesn't match. Please, update your Timos client version|20144",
                                strVersionClient, strVersionServeur));
                            CFormAlerte.Afficher(result.Erreur);
                            CTimosApp.SessionClient.CloseSession();
                            return;
                        }
                        //Si le profil affecté n'est pas le même que le profil demandé
                        //pour l'utilisateur, affiche une boite de message indiquant
                        //la différence de profil
                        CDonneesActeurUtilisateur user = CUtilSession.GetUserForSession(CSc2iWin32DataClient.ContexteCourant);
                        if (user != null && user.IdProfilLicence.Length != 0)
                        {
                            CInfoLicenceUserProfil profil = (CInfoLicenceUserProfil)CTimosApp.SessionClient.GetPropriete(CInfoLicenceUserProfil.c_nomIdentification);
                            if (profil != null && profil.Id != user.IdProfilLicence)
                            {
                                CFormAlerte.Afficher(I.T("You are connected as @1|20023", profil.Nom), EFormAlerteType.Info);
                            }
                        }
                        bool bRestart = true;
                        foreach (Assembly ass in CGestionnaireAssemblies.GetAssemblies())
                            CGestionnaireExtendeurFormEditionStandard.RegisterExtendersInAssembly(ass);

                        C2iRegistre.InitRegistreApplication(new CTimosAppRegistre());
#if DEBUG
                        //ImporterChamps();

                        CRelationBesoin_Satisfaction.InitCachePourUnClientJamaisCotéServeur();

                        string str = "";
                        foreach (RelationTypeIdAttribute r in CContexteDonnee.RelationsTypeIds)
                        {
                            str += r.TableFille;
                            str += "\t";
                            str += r.ChampType;
                            str += Environment.NewLine;
                        }
                        
                        Application.Run(new CFormMain());
#else

                    
                    while (bRestart)
					{
						bRestart = false;

                        try
                        {
							
							Application.Run(new CFormMain());
						}
						catch (Exception e)
						{
							result = CResultAErreur.True;
							result.EmpileErreur(new CErreurException(e));
							CFormAfficheErreur.Show(result.Erreur);
							bRestart = true;
						}
					}
#endif
                    }
                }
#if DEBUG
#else     
            }
            catch (Exception ex)
            {
                StringBuilder bl = new StringBuilder();
                ReflectionTypeLoadException lex = ex as System.Reflection.ReflectionTypeLoadException;
                if ( lex != null )
                {

                    foreach (Exception ee in lex.LoaderExceptions)
                    {
                        bl.Append(ee.Message.ToString());
                        bl.Append("\r\n");
                    }
                }
                else
                    bl.Append ( ex.Message.ToString( ) );
                CFormAlerte.Afficher(bl.ToString());
            }
#endif
        }

        static void SystemEvents_SessionEnding(object sender, SessionEndingEventArgs e)
        {
            try
            {
                CSessionClient.GetSessionUnique().CloseSession();
            }
            catch { }
        }

		private static void ImporterChamps()
		{
            StreamReader reader = new StreamReader("C:\\Partage\\Import Orange\\Champs controles.txt", Encoding.Default);
			string strLigne = reader.ReadLine();
			strLigne = reader.ReadLine();
			using (CContexteDonnee contexte = new CContexteDonnee(CSessionClient.GetSessionUnique().IdSession, true, false))
			{
				while (strLigne != null)
				{
					CRoleChampCustom roleSite = CRoleChampCustom.GetRole(CSite.c_roleChampCustom);
                    CRoleChampCustom roleWorkBook = CRoleChampCustom.GetRole(CDossierSuivi.c_roleChampCustom);
                    CRoleChampCustom roleCaracteristique = CRoleChampCustom.GetRole(CCaracteristiqueEntite.c_roleChampCustom);
					string[] datas = strLigne.Split('\t');
					if (datas.Length >= 1)
					{
						CChampCustom champ = new CChampCustom(contexte);
						if (!champ.ReadIfExists(new CFiltreData(CChampCustom.c_champNom + "=@1",
							datas[0])))
						{
							champ.CreateNewInCurrentContexte();
						}
						champ.Nom = datas[0];
						C2iTypeDonnee tp = new C2iTypeDonnee(TypeDonnee.tString);
                        if (datas.Length > 1)
                        {
                            if (datas[1].ToUpper() == "BOOL")
                                tp = new C2iTypeDonnee(TypeDonnee.tBool);
                            else if (datas[1].ToUpper() == "DATE")
                                tp = new C2iTypeDonnee(TypeDonnee.tDate);
                        }
						champ.TypeDonneeChamp = tp;
						champ.Categorie = "";
                        if (datas.Length > 2)
                            champ.Categorie = datas[2];
                        CRoleChampCustom role= roleCaracteristique;
						champ.Role = role;
					}
					strLigne = reader.ReadLine();
				}
				reader.Close();
				CResultAErreur result = contexte.SaveAll(true);
				if (!result)
					CFormAfficheErreur.Show(result.Erreur);
			}

		}

		static void recepteur_OnReceiveNotification(IDonneeNotification donnee)
		{
			Lancer();
		}


        [DllImport("user32")]
        public static extern int GetKeyState(int nVirtKey);

		public static bool AuthentifierUtilisateur(Thread thSplash)
		{

            CResultAErreur result = CResultAErreur.False;

            if ((Control.ModifierKeys & Keys.Shift) == 0)
            {
                result = CAuthentificateurTimos.TryAuthentificationSupportAmovible();
                if (!result)
                    result = CAuthentificateurTimos.TryAuthentificationAD();
            }
            if (thSplash != null)
                thSplash.Abort();
            if (!result)
                return AuthentificationLogin();
   
            return result.Result;
		}

		public static bool AuthentificationLogin()
		{
			CFormLogin form = new CFormLogin();
			return (form.ShowDialog() == DialogResult.OK);
		}



    }
}