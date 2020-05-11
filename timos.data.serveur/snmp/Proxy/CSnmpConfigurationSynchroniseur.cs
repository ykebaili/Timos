using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using sc2i.common.synchronisation;
using sc2i.common;
using timos.data.supervision;
using sc2i.data;
using futurocom.supervision;
using futurocom.snmp;
using timos.data.snmp.Proxy;
using futurocom.snmp.Proxy;
using System.Net;

namespace timos.data.serveur
{
    public class CSnmpConfigurationSynchroniseur : IAgentSynchronisation
    {
        private string m_strIpBaseDistante = "";
        private ISnmpConnexion m_connexion = null;

        public CSnmpConfigurationSynchroniseur()
        {
        }

        #region IAgentSynchronisation Membres

        public string GetCle()
        {
            return GetType().ToString() + "|" + m_strIpBaseDistante;
        }

        public string ParametresAgent
        {
            get
            {
                return m_strIpBaseDistante;
            }
        }

        public void Init(string strParametresAgent)
        {
            m_strIpBaseDistante = strParametresAgent;
        }

        protected ISnmpConnexion GetConnexion()
        {
            if (m_connexion == null)
            {
                m_connexion = new CSnmpConnexion();
                m_connexion.EndPoint = new IPEndPoint(IPAddress.Parse(m_strIpBaseDistante), 0);
            }
            return m_connexion;
        }

        //----------------------------------------------------------------------------------
        public CResultAErreur DoOperation(IOperationSynchronisation operation, int nIdSession)
        {
            CResultAErreur result = CResultAErreur.True;

            CAppeleurFonctionAvecDelai.CallFonctionAvecDelai(this,
                "DoOperationAsynchrone",
                1,
                operation,
                nIdSession);
            return result;
        }

        //----------------------------------------------------------------------------------
        public void DoOperationAsynchrone ( IOperationSynchronisation operation , int nIdSession )
        {
        CSnmpProxyInDb proxy = new CSnmpProxyInDb(CContexteDonneeSysteme.GetInstance());
            if (proxy.ReadIfExists(Int32.Parse(operation.IdElementASynchroniser)))
            {
                CSnmpProxyConfiguration configurationAEnvoyer = proxy.GetConfiguration();
                if (configurationAEnvoyer != null)
                {
                    CAppeleurFonctionAvecDelai.CallFonctionAvecDelai(
                        GetConnexion(),
                        "CreateUpdateObjet", 1,
                        configurationAEnvoyer);
                }

            }
        }

        #endregion
    }
}
