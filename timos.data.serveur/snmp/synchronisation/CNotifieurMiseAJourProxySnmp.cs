using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common.synchronisation;
using sc2i.common;
using futurocom.snmp;
using System.Net;
using sc2i.data.serveur;
using sc2i.data;
using System.Collections;
using System.Data;
using timos.data.snmp;
using timos.data.snmp.Proxy;
using sc2i.multitiers.client;

namespace timos.data.serveur.snmp.synchronisation
{
    [AutoExec("Autoexec")]
    public class CNotifieurMiseAJourProxySnmp : IAgentSynchronisation
    {
        private const string c_cleMediationModifiee = "NOTIFIEUR_MEDIATION_MODIF";
        private const string c_cleConfigModifiee = "NOTIFIEUR_CONFIG_MODIF";

        private CSnmpConnexion m_connexion = null;
        private string m_strIpAgent = "";
        private int m_nIdProxy = -1;


        //------------------------------------------------------------
        public static void Autoexec()
        {
            CContexteDonneeServeur.AddTraitementAvantSauvegarde ( new TraitementSauvegardeExterne(CContexteDonneeServeur_DoTraitementExterneAvantSauvegarde) );
            CContexteDonneeServeur.AddTraitementApresSauvegarde ( new TraitementSauvegardeExterne(CContexteDonneeServeur_DoTraitementExterneApresSauvegarde) );
        }

        private static void FillHashSetProxiesAMettreAJour(CSnmpProxyInDb proxy, HashSet<CSnmpProxyInDb> hs)
        {
            if ( hs.Contains ( proxy ) )
                return;
            hs.Add(proxy);
            foreach (CLienDeProxy lien in proxy.LiensDeProxySource)
            {
                if(!hs.Contains(lien.ProxySource))
                    FillHashSetProxiesAMettreAJour(lien.ProxySource, hs);
            }
        }

        //------------------------------------------------------------
        static CResultAErreur CContexteDonneeServeur_DoTraitementExterneApresSauvegarde(CContexteDonnee contexte, Hashtable tableData)
        {
            CResultAErreur result = CResultAErreur.True;
            HashSet<DataRow> proxyAMediationModifiee = contexte.ExtendedProperties[c_cleMediationModifiee] as HashSet<DataRow>;
            if (proxyAMediationModifiee == null)
                return result;
            CSynchroniseurBaseDistante synchro = CSynchroniseurBaseDistante.GetSynchroniseur(contexte.IdSession);
            foreach (DataRow row in proxyAMediationModifiee)
            {
                if (row[CSnmpProxyInDb.c_champSnmpIp] != DBNull.Value)
                {
                    COperationSynchronisationSurAgentSynchronisation op = new COperationSynchronisationSurAgentSynchronisation(
                        typeof(CNotifieurMiseAJourProxySnmp),
                        row[CSnmpProxyInDb.c_champSnmpIp] + "/" +
                        row[CSnmpProxyInDb.c_champId],
                        EOperationSynchronisationSurAgentSynchronisation.CreateOrUpdate,
                        row[CSnmpProxyInDb.c_champId].ToString());
                    synchro.AddOperation(contexte.IdSession,
                        row[CSnmpProxyInDb.c_champSnmpIp].ToString(), op);
                }
            }
            HashSet<DataRow> proxyAConfigurationModifee = contexte.ExtendedProperties[c_cleConfigModifiee] as HashSet<DataRow>;
            HashSet<CSnmpProxyInDb> proxysAMettreAJour = new HashSet<CSnmpProxyInDb>();
            foreach (DataRow row in proxyAConfigurationModifee)
            {
                CSnmpProxyInDb proxy = new CSnmpProxyInDb(contexte);
                try{
                    if ( proxy.ReadIfExists ( (int)row[CSnmpProxyInDb.c_champId] ))
                    {
                        FillHashSetProxiesAMettreAJour(proxy, proxysAMettreAJour );
                    }
                }
                    catch
                {
                }
            }
            foreach ( CSnmpProxyInDb proxy in proxysAMettreAJour )
            {
                CSynchroniseurBaseDistante.GetSynchroniseur(contexte.IdSession).AddOperation(
                        contexte.IdSession,
                        proxy.CleBaseDistante,
                        new COperationSynchronisationSurAgentSynchronisation(
                            typeof(CSnmpConfigurationSynchroniseur),
                            proxy.AdresseIp,
                            EOperationSynchronisationSurAgentSynchronisation.CreateOrUpdate,
                            proxy.Id.ToString()));
            }

            
            contexte.ExtendedProperties.Remove(c_cleMediationModifiee);
            contexte.ExtendedProperties.Remove ( c_cleConfigModifiee );

            return result;
        }

        //------------------------------------------------------------
        public static CResultAErreur CContexteDonneeServeur_DoTraitementExterneAvantSauvegarde(CContexteDonnee contexte, Hashtable tableData)
        {
            CResultAErreur result = CResultAErreur.True;
            HashSet<DataRow> proxyAConfigModifiee = new HashSet<DataRow>();
            HashSet<DataRow> proxyAMediationModifee = new HashSet<DataRow>();
            bool bAll = false;
            foreach (DataTable table in new ArrayList(contexte.Tables))
            {
                Type tp = CContexteDonnee.GetTypeForTable(table.TableName);
                if (typeof(IElementADonneePourMediationSNMP).IsAssignableFrom( tp ))
                {
                    foreach (DataRow row in table.Rows)
                    {
                        if (
                            row.RowState == DataRowState.Added || 
                            row.RowState == DataRowState.Modified || 
                            row.RowState == DataRowState.Deleted)
                        {
                            IElementADonneePourMediationSNMP elt = contexte.GetNewObjetForRow(row) as IElementADonneePourMediationSNMP;
                            if (row.RowState == DataRowState.Deleted)
                                ((CObjetDonnee)elt).VersionToReturn = DataRowVersion.Original;
                            try
                            {
                                for (int nPasse = 0; nPasse < 2; nPasse++)
                                {
                                    HashSet<DataRow> dataRows = null;
                                    int[] elts;
                                    if (nPasse == 0)
                                    {
                                        elts = elt.IdsProxysConcernesParDonneesMediation;
                                        dataRows = proxyAMediationModifee;
                                    }
                                    else
                                    {

                                        elts = elt.IdsProxysConcernesParConfigurationProxy;
                                        dataRows = proxyAConfigModifiee;
                                    }
                                    if (elts == null)
                                    {
                                        CListeObjetsDonnees lstProxys = new CListeObjetsDonnees(contexte, typeof(CSnmpProxyInDb));
                                        foreach (CSnmpProxyInDb proxy in lstProxys)
                                        {
                                            dataRows.Add(proxy.Row.Row);
                                        }
                                        bAll = true;
                                        break;
                                    }
                                    else
                                    {
                                        foreach (int nIdProxy in elts)
                                        {
                                            CSnmpProxyInDb proxy = new CSnmpProxyInDb(contexte);
                                            if (proxy.ReadIfExists(nIdProxy))
                                                dataRows.Add(proxy.Row);
                                        }
                                    }
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                }
                if (bAll)
                    break;
            }

            if (proxyAMediationModifee.Count > 0 || proxyAConfigModifiee.Count > 0)
            {
                contexte.ExtendedProperties[c_cleMediationModifiee] = proxyAMediationModifee;
                contexte.ExtendedProperties[c_cleConfigModifiee] = proxyAConfigModifiee;
            }

            return result;

        }
        
        public string GetCle()
        {
            return GetType()+"/"+m_strIpAgent+"/"+m_nIdProxy;
        }

        //------------------------------------------------------------
        public string ParametresAgent
        {
            get { return m_strIpAgent + "/" + m_nIdProxy; }
        }

        //------------------------------------------------------------
        public void Init(string strParametresAgent)
        {
            string[] strParams = strParametresAgent.Split('/');
            m_strIpAgent = strParams[0];
            m_nIdProxy = Int32.Parse(strParams[1]);
        }

        //------------------------------------------------------------
        protected CSnmpConnexion GetConnexion()
        {
            if (m_connexion == null)
            {
                m_connexion = new CSnmpConnexion();
                m_connexion.EndPoint = new IPEndPoint(IPAddress.Parse(m_strIpAgent), 0);
            }
            return m_connexion;
        }

        //------------------------------------------------------------
        public CResultAErreur DoOperation(IOperationSynchronisation operation, int nIdSession)
        {
            CResultAErreur result = CResultAErreur.True;

            CAppelleurFonctionAsynchrone ap = new CAppelleurFonctionAsynchrone();
            CAppeleurFonctionAvecDelai.CallFonctionAvecDelai (
                GetConnexion(),
                "NotifyProxyNecessiteMAJ",1,
                Int32.Parse(operation.IdElementASynchroniser), false, true);

            return CResultAErreur.True;
        }
    }
}
