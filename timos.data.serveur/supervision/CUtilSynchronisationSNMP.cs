using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.data;
using System.Data;
using System.Collections;
using timos.data.snmp.Proxy;
using sc2i.common.synchronisation;
using futurocom.snmp;
using System.Net;

namespace timos.data.serveur.supervision
{
    /// <summary>
    /// Utilitaire pour la synchronisation SNMP des
    /// types d'alarme, types d'agent et agents
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class CUtilSynchronisationSNMP: IAgentSynchronisation
    {
        private CSnmpConnexion m_connexion = null;
        private string m_strIpProxy = "";
        //---------------------------------------------------------------------------
        public CUtilSynchronisationSNMP(  )
        {
        }

        //---------------------------------------------------------------------------
        public abstract string GetNomTable();

        //---------------------------------------------------------------------------
        public abstract string ChampIdDeTypeSynchronise{get;}

        //---------------------------------------------------------------------------
        public CResultAErreur TraitementAvantSauvegarde( CContexteDonnee contexte )
        {
            CResultAErreur result = CResultAErreur.True;
            DataTable table = contexte.Tables[GetNomTable()];
            if (table == null)
                return result;
            ArrayList lst = new ArrayList(table.Rows);
            HashSet<DataRow> rowsToSend = table.ExtendedProperties[GetType()] as HashSet<DataRow>;
            if (rowsToSend == null)
            {
                rowsToSend = new HashSet<DataRow>();
                table.ExtendedProperties[GetType()] = rowsToSend;
            }
            foreach (DataRow row in lst)
            {
                if (row.RowState == DataRowState.Modified || row.RowState == DataRowState.Added)
                {
                    rowsToSend.Add(row);
                }
                if (row.RowState == DataRowState.Deleted)
                {
                    rowsToSend.Add(row);
                }
            }
            return result;
        }

        //---------------------------------------------------------------------------
        public virtual bool DoitMettreAJour(CSnmpProxyInDb proxy, DataRow row)
        {
            return true;
        }

        //---------------------------------------------------------------------------
        public CResultAErreur TraitementApresSauvegarde(CContexteDonnee contexte)
        {
            CResultAErreur result = CResultAErreur.True;
            DataTable table = contexte.Tables[GetNomTable()];
            if (table == null)
                return result;
            HashSet<DataRow> rowsToSend = table.ExtendedProperties[GetType()] as HashSet<DataRow>;
            if (rowsToSend == null)
                return result;
            CListeObjetsDonnees lstServiceMediation = new CListeObjetsDonnees(contexte, typeof(CSnmpProxyInDb));

            HashSet<string> myIps = new HashSet<string>();
            System.Net.IPHostEntry moiMeme = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            foreach (IPAddress adresse in moiMeme.AddressList)
                myIps.Add(adresse.ToString());
            
            foreach (CSnmpProxyInDb proxy in lstServiceMediation.ToArrayList())
            {
                string strParametresAgent = proxy.AdresseIp;
                foreach (DataRow row in rowsToSend)
                {
                    if (DoitMettreAJour(proxy, row))
                    {
                        EOperationSynchronisationSurAgentSynchronisation typeOperation = EOperationSynchronisationSurAgentSynchronisation.CreateOrUpdate;
                        if (row.RowState == DataRowState.Deleted)
                            typeOperation = EOperationSynchronisationSurAgentSynchronisation.Delete;
                        string strId = row[ChampIdDeTypeSynchronise,
                            row.RowState == DataRowState.Deleted ? DataRowVersion.Original : DataRowVersion.Current].ToString();
                        IOperationSynchronisation operation = new COperationSynchronisationSurAgentSynchronisation(
                                GetType(),
                                strParametresAgent,
                                typeOperation,
                                strId);
                        if (myIps.Contains(proxy.AdresseIp))
                        {
                            Init(proxy.AdresseIp);
                            result = DoOperation(operation, contexte);
                            if (!result)
                                return result;
                        }
                        else
                        {
                            CSynchroniseurBaseDistante.DefaultInstance.AddOperation(contexte.IdSession, proxy.CleBaseDistante,
                                operation);
                        }
                    }
                }
            }
            table.ExtendedProperties.Remove(GetType());
            return result;
        }

        #region IAgentSynchronisation Membres

        public string GetCle()
        {
            return GetType().ToString() + "/" + m_strIpProxy;
        }

        public string ParametresAgent
        {
            get { return m_strIpProxy; }
        }

        public void Init(string strParametresAgent)
        {
            m_strIpProxy = strParametresAgent;
        }

        public virtual CResultAErreur DoOperation(IOperationSynchronisation operation)
        {
            return DoOperation(operation, null);
        }

        public abstract CResultAErreur DoOperation(  IOperationSynchronisation operation, CContexteDonnee contexteDonnee );

        protected CSnmpConnexion GetConnexion()
        {
            if (m_connexion == null)
            {
                m_connexion = new CSnmpConnexion();
                m_connexion.EndPoint = new IPEndPoint(IPAddress.Parse(m_strIpProxy), 0);
            }
            return m_connexion;
        }

        #endregion
    }
}
