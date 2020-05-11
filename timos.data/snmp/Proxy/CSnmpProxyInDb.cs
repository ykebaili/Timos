using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

using tiag.client;

using timos.data;
using futurocom.snmp.Mib;
using timos.data.snmp;
using futurocom.snmp;
using futurocom.easyquery;
using futurocom.snmp.alarme;
using futurocom.snmp.entitesnmp;
using futurocom.snmp.dynamic;
using futurocom.easyquery.snmp;
using futurocom.snmp.Proxy;
using System.Data;
using sc2i.common.memorydb;
using timos.data.supervision;
using System.Net;

namespace timos.data.snmp.Proxy
{
    /// <summary>
    /// Un proxy SNMP permet de dialoguer suivant le protocole SNMP avec des équipements<br/>
    /// ou de jouer le rôle de passerelle vers d'autres proxy SNMP.<br/>
    /// Une interrogation SNMP n'est jamais faite par un poste client, elle passe toujours
    /// par le serveur TIMOS puis au moins un proxy, ceci pour des raisons de sécurité réseau.<br/>
    /// En effet, pour communiquer avec le proxy, il suffit d'autoriser le port prévu pour<br/>
    /// cette communication, et uniquement celui-ci et ce, en mode TCP. Un proxy peut-être<br/>
    /// au plus près des équipements, sur le réseau de ces équipements et derrière un ou plusieurs firewall.
    /// </summary>
    [DynamicClass("SNMP Proxy")]
    [Table(CSnmpProxyInDb.c_nomTable, CSnmpProxyInDb.c_champId, true)]
    [FullTableSync]
    [ObjetServeurURI("CSnmpProxyInDbServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModuleSNMP)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_ParametrageSnmp_ID)]
    public class CSnmpProxyInDb : CObjetDonneeAIdNumeriqueAuto, IElementADonneePourMediationSNMP
    {
        public const string c_nomTable = "SNMP_PROXY";
        public const string c_champId = "SNMPPRX_ID";
        public const string c_champLibelle = "SNMPPRX_LABEL";
        public const string c_champSnmpIp = "SNMPPRX_IP";
        public const string c_champSnmpPort = "SNMPPRX_PORT";
        public const string c_champPriorite = "SNMPPRX_PRIORITY";
        public const string c_champPollingFreq = "SNMPPRX_POLL_FREQ";

        /// /////////////////////////////////////////////
        public CSnmpProxyInDb(CContexteDonnee contexte)
            : base(contexte)
        {
        }

        /// /////////////////////////////////////////////
        public CSnmpProxyInDb(DataRow row)
            : base(row)
        {
        }

        public override string DescriptionElement
        {
            get { return I.T("SNMP Proxy : @1|10018", Libelle); }
        }

        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champLibelle };
        }

        protected override void MyInitValeurDefaut()
        {
            Port = 0;
        }

        /// /////////////////////////////////////////////
        ///Identifiant du proxy pour la mise  à jour de données
        public string CleBaseDistante
        {
            get
            {
                return "PROXY_" + AdresseIp + "_" + Port;
            }
        }

        /// /////////////////////////////////////////////
        /// <summary>
        /// Nom du proxy
        /// </summary>
        [DescriptionField]
        [TableFieldProperty(c_champLibelle, 255)]
        [DynamicField("Label")]
        public string Libelle
        {
            get
            {
                return (string)Row[c_champLibelle];
            }
            set
            {
                Row[c_champLibelle] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Adresse IP du proxy
        /// </summary>
        [TableFieldProperty(c_champSnmpIp, 64)]
        [DynamicField("IP Address")]
        public string AdresseIp
        {
            get
            {
                return (string)Row[c_champSnmpIp];
            }
            set
            {
                Row[c_champSnmpIp] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Port de communication avec TIMOS ou avec un autre proxy en amont,<br/>
        /// en général 8160.
        /// </summary>
        [TableFieldProperty(c_champSnmpPort)]
        [DynamicField("Port")]
        public int Port
        {
            get
            {
                return (int)Row[c_champSnmpPort];
            }
            set
            {
                Row[c_champSnmpPort] = value;
            }
        }

        //-----------------------------------------------------------------------
        /// <summary>
        /// Chaîne de connexion au serveur TIMOS ou au proxy en amont :<br/>
        /// tcp://addr_ip:port (ex: tcp://192.168.0.14:8160)
        /// </summary>
        [DynamicField("Connection String")]
        public string ChaineDeConnexion
        {
            get
            {
                return "tcp://" + AdresseIp + ":" + Port;
            }
        }

        //-----------------------------------------------------------------------
        public IPEndPoint EndPoint
        {
            get
            {
                return new IPEndPoint(IPAddress.Parse(AdresseIp), Port);
            }
        }

        //-----------------------------------------------------------------------
        /// <summary>
        /// Priorité du proxy
        /// </summary>
        [TableFieldProperty(c_champPriorite)]
        [DynamicField("Priority")]
        public int Priorite
        {
            get
            {
                return (int)Row[c_champPriorite];
            }
            set
            {
                Row[c_champPriorite] = value;
            }
        }

        //-----------------------------------------------------------------------
        /// <summary>
        /// Fréquence à laquelle le proxy fait du polling sur les 
        /// équipements SNMP qu'il gère (en minutes)
        /// <BR>La valeur 0 indique que le polling est désactivé sur
        /// ce proxy (il s'agit de la valeur par défaut)
        /// </summary>
        [DynamicField("Polling frequency")]
        [TableFieldProperty(c_champPollingFreq)]
        public double FrequencePollingMinutes
        {
            get
            {
                return Row.Get<double>(c_champPollingFreq);
            }
            set
            {
                Row[c_champPollingFreq] = value;
            }
        }

        //----------------------------------------------------------------------
        /// <summary>
        /// Retourne la liste des liens avec des proxy aval (destination),<br/>
        /// dans la chaîne des proxy
        /// </summary>
        [RelationFille(typeof(CLienDeProxy), "ProxySource")]
        [DynamicChilds("Destination Proxy Links", typeof(CLienDeProxy))]
        public CListeObjetsDonnees LiensDeProxyDestination
        {
            get
            {
                return GetDependancesListe(CLienDeProxy.c_nomTable, c_champId);
            }
        }

        //---------------------------------------------------------------------
        /// <summary>
        /// Retourne la liste des liens avec des proxy amont (source),<br/>
        /// dans la chaîne des proxy
        /// </summary>
        [RelationFille(typeof(CLienDeProxy), "ProxyDestination")]
        [DynamicChilds("Source Proxy Links", typeof(CLienDeProxy))]
        public CListeObjetsDonnees LiensDeProxySource
        {
            get
            {
                return GetDependancesListe(CLienDeProxy.c_nomTable, CLienDeProxy.c_champProxyDest);
            }
        }


        //------------------------------------------------------------------------
        /// <summary>
        /// Retourne la liste des agents SNMP gérés par le proxy
        /// </summary>
        [RelationFille(typeof(CAgentSnmp), "ProxyDeMediationSnmp")]
        [DynamicChilds("Managed Snmp Agents", typeof(CAgentSnmp))]
        public CListeObjetsDonnees AgentsSnmpGeres
        {
            get
            {
                return GetDependancesListe(CAgentSnmp.c_nomTable, c_champId);
            }
        }

        //----------------------------------------------------------------------
        public CSnmpProxy GetTypePourSupervision(CMemoryDb database)
        {
            if (database == null)
                database = CMemoryDbPourSupervision.GetMemoryDb(ContexteDonnee);
            CSnmpProxy proxy = new CSnmpProxy(database);
            if (!proxy.ReadIfExist(Id.ToString(), false))
                proxy.CreateNew(Id.ToString());
            else
                if (!proxy.IsToRead())
                    return proxy;
            proxy.Row[CMemoryDb.c_champIsToRead] = false;
            proxy.Libelle = Libelle;
            proxy.AdresseIP = GetIPFromString(AdresseIp);
            proxy.Port = Port;
            proxy.Priorite = Priorite;
            proxy.FrequencePollingMinutes = FrequencePollingMinutes;

            return proxy;
        }

        //----------------------------------------------------------------------
        public IPAddress GetIPFromString(string strIP)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            try
            {
                ip = new IP(strIP).ToIPAddress();
            }
            catch
            { }

            return ip;
        }


        //----------------------------------------------------------------------
        /// <summary>
        /// Retourne une Configuration SNMP à envoyer au Proxy en cours
        /// </summary>
        /// <returns></returns>
        public CSnmpProxyConfiguration GetConfiguration()
        {
            CSnmpProxyConfiguration configuration = new CSnmpProxyConfiguration();
            configuration.IdProxyConfiguré = Id;
            configuration.FrequencePollingMinutes = FrequencePollingMinutes;

            List<CSnmpProxy> listeProxyConfigures = new List<CSnmpProxy>();

            // Ajouter les Proxy distants (Next) et leurs plages IP gérées
            foreach (CLienDeProxy lienProxy in LiensDeProxyDestination)
            {
                if (lienProxy.ProxyDestination != null)
                {
                    HashSet<CPlageIP> hPlages = new HashSet<CPlageIP>();
                    hPlages.Add(new CPlageIP(lienProxy.ProxyDestination.AdresseIp, 0));
                    CSnmpProxy proxyAAjouterALaConfig = lienProxy.ProxyDestination.GetTypePourSupervision(configuration.Database);
                    if (proxyAAjouterALaConfig != null)                        
                    {
                        foreach (CPlageIP plage in lienProxy.PlagesIP)
                        {
                            hPlages.Add(plage);
                        }
                        lienProxy.ProxyDestination.FillHashSetPlagesGerees(hPlages);

                        foreach (CPlageIP plage in hPlages)
                        {
                            proxyAAjouterALaConfig.AddPlage(plage);
                        }
                        listeProxyConfigures.Add(proxyAAjouterALaConfig);
                    }
                }
            }

            // Ajoute les proxies Sources (Prev) à la configuration
            foreach (CLienDeProxy lienPrev in LiensDeProxySource)
            {
                if (lienPrev.ProxySource != null)
                {
                    CSnmpProxy proxyAAjouterALaConfig = lienPrev.ProxySource.GetTypePourSupervision(configuration.Database);
                    proxyAAjouterALaConfig.IsProxyPrev = true;

                    listeProxyConfigures.Add(proxyAAjouterALaConfig); // En tant que Proxy Source (Précédent)
                }
            }

            return configuration;
        }


        private void FillHashSetPlagesGerees(HashSet<CPlageIP> hPlages)
        {
            foreach (CAgentSnmp agent in AgentsSnmpGeres)
            {
                hPlages.Add(new CPlageIP(agent.SnmpIp, 0));
            }
           
            foreach (CLienDeProxy lien in LiensDeProxyDestination)
            {
                foreach (CPlageIP plage in lien.PlagesIP.ToArray())
                    hPlages.Add(plage);

                CSnmpProxyInDb proxy = lien.ProxyDestination;
                if (proxy != null)
                {
                    hPlages.Add(new CPlageIP(proxy.AdresseIp, 0));
                    proxy.FillHashSetPlagesGerees(hPlages);
                }
            }
        }


        /// <summary>
        /// Force la mise à jour de la configuration du proxy
        /// </summary>
        [DynamicMethod("Update physical service configuration")]
        public void UpdateDistantConfiguration()
        {
            CSnmpConnexion cnx = new CSnmpConnexion();
            cnx.EndPoint = new IPEndPoint(IPAddress.Parse(AdresseIp), Port);
            cnx.SetConfigurationDeSnmpProxy(GetConfiguration());
            cnx.NotifyProxyNecessiteMAJ(Id, false, true, false);
        }

        /// <summary>
        /// Force la mise à jour complète de la configuration du proxy
        /// </summary>
        [DynamicMethod("Update physical service configuration")]
        public void UpdateFullDistantConfiguration()
        {
            CSnmpConnexion cnx = new CSnmpConnexion();
            cnx.EndPoint = new IPEndPoint(IPAddress.Parse(AdresseIp), Port);
            cnx.SetConfigurationDeSnmpProxy(GetConfiguration());
            cnx.NotifyProxyNecessiteMAJ(Id, true, true, true);
        }




        #region IElementADonneePourMediationSNMP Membres

        public int[] IdsProxysConcernesParDonneesMediation
        {
            get { return new int[0]; }
        }

        public int[] IdsProxysConcernesParConfigurationProxy
        {
            get
            {
                if (IsValide())
                    return new int[] { Id };
                return new int[0];

            }
        }

        #endregion
    }
}
