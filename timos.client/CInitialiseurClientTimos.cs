using System;
using System.Reflection;
using System.Security.Principal;
using System.Runtime.Remoting.Lifetime;

using sc2i.common;
using sc2i.multitiers.client;
using sc2i.data;

using timos.data;
using System.Runtime.Remoting.Proxies;
using sc2i.process;
using System.Text;
using futurocom.snmp.Proxy;
using futurocom.snmp;
using System.Collections.Generic;
using timos.data.supervision;
using sc2i.common.memorydb;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using data.hotel.client;

namespace timos.client
{
	/// <summary>
	/// Description résumée de CInitialiseurClientping.
	/// </summary>
	public class CInitialiseurClientTimos
	{
		private static string m_strUrlServeurMain = "";
		private static int m_nPortServeur = 8080;

		public static CResultAErreur InitClientTimos ( C2iMultitiersClientRegistre registre )
		{
			return InitClientTimos ( registre, false, null );
		}


		/// ///////////////////////////////////////////////////////////
		public static CResultAErreur InitClientTimos ( 
			C2iMultitiersClientRegistre registre, 
			bool bAvecSynchronisation,
			IIndicateurProgression indicateurProgression)

		{
			return InitClientTimos (
				registre.GetFactoryURL(),
				registre.GetRemotingTCPChannel(),
                registre.GetBindTCPChannelBindTo(),
				indicateurProgression );
		}

		/// ///////////////////////////////////////////////////////////
		public static CResultAErreur InitClientTimos ( 
			string strServeurUrl,
			int nTcpChannel,
            string strBindTo,
			IIndicateurProgression indicateurProgression)
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);

                //SUPPRIMé journal d'évenements: sur les postes clients qui ne sont pas autorisés
                //à créer un journal d'évenements, ça bloque, et comme ce n'est pas
                //très important sur un poste client, il n'y a plus 
                //de journal d'évenements TIMOS sur les postes clients.
				//C2iEventLog.Init("", "Client Timos", NiveauBavardage.VraiPiplette);
				
				m_strUrlServeurMain = strServeurUrl;
				m_nPortServeur = nTcpChannel;
				result = CSC2iMultitiersClient.Init ( m_nPortServeur ,m_strUrlServeurMain, strBindTo );

				LifetimeServices.LeaseTime = new TimeSpan(0, 5, 0);
				LifetimeServices.LeaseManagerPollTime = new TimeSpan(0, 5, 0);
				LifetimeServices.SponsorshipTimeout = new TimeSpan(0, 3, 0);
				LifetimeServices.RenewOnCallTime = new TimeSpan(0, 8, 0);
				/*LifetimeServices.LeaseTime = new TimeSpan(0, 0, 3);
				LifetimeServices.LeaseManagerPollTime = new TimeSpan(0, 0, 10);
				LifetimeServices.SponsorshipTimeout = new TimeSpan(0, 0, 10);
				LifetimeServices.RenewOnCallTime = new TimeSpan(0, 0, 5);*/
			
				/*if ( !result )
				{
					//On ne parvient pas à contacter le serveur primaire, s'adresse au serveur secondaire
					result = CSC2iMultitiersClient.Init (
						m_nPortServeur,
						m_strUrlServeurSecondaire);
					if ( result )
						CSessionClient.AfterOpenSession += new SessionEventHandler(AfterOpenSessionModeDeconnecte);
				}
				else
				{
					if ( bAvecSynchronisation && m_strUrlServeurSecondaire != "")
					{
						//On a contacté le serveur primaire, tente une synchronisation
						result = SynchroniseSecondaireToMain( indicateurProgression );
						if ( !result )
							return result;
						CSessionClient.BeforeClosingSession += new SessionEventHandler(BeforeCloseSessionModeConnecte);
					}
				}*/
				if ( !result )
					return result;
				

				C2iSponsor.EnableSecurite();
				//			System.Runtime.Remoting.RemotingConfiguration.Configure (strFichierConfig);
				//			sc2i.multitiers.client.C2iFactory.InitFromFile(strFichierConfig);

				AppDomain.CurrentDomain.Load("sc2i.data.client");
				AppDomain.CurrentDomain.Load("sc2i.data.dynamic");
				AppDomain.CurrentDomain.Load("timos.data");
				AppDomain.CurrentDomain.Load("sc2i.process");
				AppDomain.CurrentDomain.Load("sc2i.documents");
                AppDomain.CurrentDomain.Load("futurocom.sig");
                AppDomain.CurrentDomain.Load("data.hotel.client");

				#region Chargement des plugins

				CGestionnairePlugins.InitPlugins(AppDomain.CurrentDomain.BaseDirectory, "plg");
                // Initialilsation des plugins à partir de TIMOS_REGISTRY
                CDataBaseRegistrePourClient registre = new CDataBaseRegistrePourClient(0);
                string strFUT_CLT = registre.GetValeurString("FUT_CLT", "");
                if (strFUT_CLT.Trim() != string.Empty)
                {
                    List<string> listPluginFiles = new List<string>();
                    foreach (string strNomPlg in strFUT_CLT.Split(';'))
                    {
                        string strTmp = AppDomain.CurrentDomain.BaseDirectory + strNomPlg;
                        if (File.Exists(strTmp))
                            listPluginFiles.Add(strTmp);
                    }
                    CGestionnairePlugins.LoadPlugins(listPluginFiles.ToArray());
                }


				#endregion

				foreach ( Assembly ass in AppDomain.CurrentDomain.GetAssemblies() )
					CContexteDonnee.AddAssembly ( ass );
				
				AppDomain.CurrentDomain.AssemblyLoad += new AssemblyLoadEventHandler ( OnLoadAssembly );

				CGestionnaireObjetsAttachesASession.OnAttacheObjet += new LinkObjectEventHandler(OnAttacheObjectASession);

				CAutoexecuteurClasses.RunAllAutoexecs();

				CVersionDonneesObjet.EnableJournalisation = true;

                // Création d'une Configuration SNMP par défaut
                // Redirige tout vers le Serveur Timos (entant que Proxy par défaut)
                CSnmpProxyConfiguration configurationDefaut = new CSnmpProxyConfiguration();
                CPlageIP plageToutes = new CPlageIP("255.255.255.255", 32);

                CSnmpProxy proxyDefaut = new CSnmpProxy(configurationDefaut.Database);
                proxyDefaut.CreateNew();
                string strIp = strServeurUrl.Substring(strServeurUrl.IndexOf("//") + 2);
                string strPort = strIp.Substring(strIp.IndexOf(':') + 1);
                strIp = strIp.Substring(0, strIp.IndexOf(':'));
                try
                {
                    proxyDefaut.AdresseIP = new IP(strIp).ToIPAddress();
                }
                catch
                {
                    try
                    {
                        IPHostEntry entry = Dns.GetHostEntry(strIp);
                        if (entry != null)
                            foreach (IPAddress adr in entry.AddressList)
                            {
                                //Cherche une IP V4 dans les paramètres
                                string strIpTest = adr.ToString();
                                Regex ex = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
                                if (ex.IsMatch(strIpTest))
                                {
                                    proxyDefaut.AdresseIP = adr;
                                    break;
                                }
                            }
                    }
                    catch { }
                }
                proxyDefaut.Port = Int32.Parse(strPort);
                proxyDefaut.AddPlage(plageToutes);

                CDataHotelClient.InitForUseProxy(m_strUrlServeurMain);

                CSnmpProxyConfiguration.SetDefaultInstance(configurationDefaut);
                CSnmpConnexion.ToutPasserParDesProxies = true;


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
			catch ( Exception e )
			{
                StringBuilder bl = new StringBuilder();
                ReflectionTypeLoadException lex = e as System.Reflection.ReflectionTypeLoadException;
                if (lex != null)
                {

                    foreach (Exception ee in lex.LoaderExceptions)
                    {
                        bl.Append(ee.Message.ToString());
                        bl.Append("\r\n");
                    }
                }
                else
                    bl.Append(e.Message.ToString());
                result.EmpileErreur(bl.ToString());
			}
			
			return result;
		}


		//------------------------------------------------------------------------------
		public static void OnLoadAssembly ( object sender, AssemblyLoadEventArgs args )
		{
			CAutoexecuteurClasses.RunAutoexec ( args.LoadedAssembly, null, null );
		}


		//------------------------------------------------------------------------------
		public static void OnAttacheObjectASession(int nIdSession, IObjetAttacheASession objet)
		{
			CContexteDonnee contexte = objet as CContexteDonnee;
			if ( contexte != null )
				contexte.OnChangeVersionDeTravail += new EventHandler(CInitialiseurClientTimos_OnChangeVersionDeTravail);
		}

		//------------------------------------------------------------------------------
		public static void CInitialiseurClientTimos_OnChangeVersionDeTravail(object sender, EventArgs e)
		{
			CContexteDonnee contexte = sender as CContexteDonnee;
			if (contexte != null)
			{
				int nIdSession = contexte.IdSession;
				CSessionClient session = CSessionClient.GetSessionForIdSession(nIdSession);
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

	

}
