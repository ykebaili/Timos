using System;
using System.Collections.Generic;
using System.Text;

using sc2i.common;
using sc2i.expression;
using sc2i.data;
using sc2i.multitiers.client;
using spv.data;

namespace spv.snmp
{
    public class CSpvSnmp
    {
        private string m_adresseIP;
        private int m_retry;
        private int m_timeout;
        private SnmpVersion m_version;
        private string m_communaute;
        private int m_portLocal;
        private int m_portDistant;

        private const int c_retry = 2;
        private const int c_timeout = 300;
        private const SnmpVersion c_version = SnmpVersion.snmpV1;
        private const string c_communaute = "public";
        private const int c_portDistant = 161;

        public enum SnmpVersion
        {
            snmpV1 = 0,
            snmpV2C = 1
        }

        public CSpvSnmp()
        {
            Init ("", c_retry, c_timeout, c_version, c_communaute, 0, c_portDistant);
        }


        /// <summary>
        /// Constructeur avec paramètres
        /// </summary>
        /// <param name="adresseIP">Adresse IP du destinataire</param>
        /// <param name="retry">Nombre de reprise de la requête en cas de non réponse du distant</param>
        /// <param name="timeout">Timeout avant d'effectuer une reprise de l'interrogation</param>
        /// <param name="version">Version SNMP</param>
        /// <param name="communaute">Communauté d'interrogation</param>
        /// <param name="portLocal">Port local d'interrogation</param>
        /// <param name="portDistant">Port distant d'interrogation (161 (Get/Set) ou 162 (Trap)</param>
        public CSpvSnmp(string adresseIP, int retry, int timeout, SnmpVersion version, string communaute,
                        int portLocal, int portDistant)
        {
            Init(adresseIP, retry, timeout, version, communaute, portLocal, portDistant);
        }

        private void Init(string adresseIP, int retry, int timeout, SnmpVersion version, string communaute,
                          int portLocal, int portDistant)
        {
            m_adresseIP = adresseIP;
            m_retry = retry;
            m_timeout = timeout;
            m_version = version;
            m_communaute = communaute;
            m_portLocal = portLocal;
            m_portDistant = portDistant;
        }


        private string GetIndexOrZero(string nomVariable)
        {
            string ret = GetIndex(nomVariable);
            return (ret == null ? "0" : ret);
        }


        private string GetIndex(string nomVariable)
        {
            int pos = nomVariable.IndexOf('.');
            if (pos < 0)
                return null;

            return nomVariable.Substring(pos + 1);
        }


        public CResultAErreur Get(List<CSnmpVar> listeSnmpVar)
        {
            CResultAErreur result = CResultAErreur.True;
            return result;
        }

        /// <summary>
        /// Get SNMP
        /// </summary>
        /// <param name="nomModule"></param>
        /// <param name="nomsDesVariables">Si une variable n'intègre pas son index, 0 est pris comme index par défaut</param>
        /// <returns></returns>
        public CResultAErreur Get(string nomModule, params string[] nomsDesVariables)
        {
            string strIndex;
            CSpvMibVariable mibVar;
            List<CSnmpVar> listeSnmpVar = new List<CSnmpVar>();

            CResultAErreur result = CResultAErreur.True;
            CContexteDonnee ctx = new CContexteDonnee();    //ATTENTION, récupérer le ctx de la session

            if (nomModule == null || nomModule.Length == 0)
            {
                result.EmpileErreur(I.T("You should fill the MIB module before doing an snmp get|50003"));
                return result;
            }

            if (nomsDesVariables.Length == 0)
            {
                result.EmpileErreur(I.T("Fill variable(s) name before doing an snmp get|50004"));
                return result;
            }

            foreach (string nomVariable in nomsDesVariables)
            {
                string [] nomModules = new string [1];
                nomModules[0] = nomModule;

                strIndex = GetIndexOrZero(nomVariable);
                mibVar = (CSpvMibVariable) CSpvMibmodule.GetVariable(ctx, nomVariable, nomModules);
                if (mibVar == null)
                {
                    result.EmpileErreur(I.T("Snmp variable not found in bdd|50000"));
                    return result;
                }
                listeSnmpVar.Add(new CSnmpVar (mibVar, strIndex));
            }
            return Get(listeSnmpVar);
        }
     }
}
