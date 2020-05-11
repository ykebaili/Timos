using System;
using System.Collections.Generic;
using System.Text;
using sc2i.data;
using sc2i.common;
using sc2i.multitiers.client;

namespace spv.data.SNMP
{
    [Serializable]
    public class CVariableSNMPResultat
    {
        private string m_strValeur;     // Valeur de la variable
        private string m_strOid;        // OID complet
        private string m_strIndex;      // Partie index dans cet OID

        public CVariableSNMPResultat(string strValeur, string strOid)
        {
            m_strValeur = strValeur;
            m_strOid = strOid;
        }

        public string Valeur
        {
            get
            {
                return m_strValeur;
            }
            set
            {
                m_strValeur = value;
            }
        }

        public string Oid
        {
            get
            {
                return m_strOid;
            }
            set
            {
                m_strOid = value;
            }
        }

        public string Index
        {
            get
            {
                return m_strIndex;
            }
            set
            {
                m_strIndex = value;
            }
        }
    }


    [Serializable]
    public abstract class CRequeteSNMP
    {
        public enum EVersionSNMP
        {
            V1,
            V2C
        }

        private string m_strIpAgent;
        private string m_strCommunity;
        private EVersionSNMP m_version = EVersionSNMP.V1;
        private int m_nTimeOut = 300;
        private int m_nNbRetry = 2;
        private int m_nPort = 161;
        

        public CRequeteSNMP()
        {
            InitDepuisParametresSNMP();
        }

        public CRequeteSNMP(string strIpAgent, string strCommunity)
        {
            IpAgent = strIpAgent;
            Community = strCommunity;
            InitDepuisParametresSNMP();
        }

        private void InitDepuisParametresSNMP()
        {
            try
            {
                string strParam =
                    CSpvParamSysteme.GetParametreSysteme(CSpvParamSysteme.c_parametreSNMP_TIMEOUT);
                if (strParam != "")
                    TimeOut = Convert.ToInt32(strParam);

                strParam = CSpvParamSysteme.GetParametreSysteme(CSpvParamSysteme.c_parametreSNMP_RETRY);
                if (strParam != "")
                    NbRetry = Convert.ToInt32(strParam);
            }
            catch
            {
            }
        }

        public string IpAgent
        {
            get{
                return m_strIpAgent;
            }
            set{m_strIpAgent = value;
            }
        }

        public int TimeOut
        {
            get
            {
                return m_nTimeOut;
            }
            set
            {
                m_nTimeOut = value;
            }
        }

        public EVersionSNMP VersionSNMP
        {
            get
            {
                return m_version;
            }
            set
            {
                m_version = value;
            }
        }

        public int Port
        {
            get
            {
                return m_nPort;
            }
            set
            {
                m_nPort = value;
            }
        }

        public int NbRetry
        {
            get
            {
                return m_nNbRetry;
            }
            set
            {
                m_nNbRetry = value;
            }
        }

        public string Community
        {
            get{
                return m_strCommunity;
            }
            set{
                m_strCommunity = value;
            }
        }


        /// <summary>
        /// Retourne l'OID à utiliser pour cette requête
        /// </summary>
        /// <returns></returns>
        public abstract string GetOID( CContexteDonnee contexteDonnee);

        /// <summary>
        /// Retourne une description de la variable accedée
        /// </summary>
        internal abstract string GetDescriptionVariableSNMP();

        /// <summary>
        /// Retourne le type de la variable utilisée pour cette requête
        /// tel que défini dans la base de données SPV (MibObj)
        /// </summary>
        /// <param name="contexteDonnee"></param>
        /// <returns></returns>
        public abstract string GetType(CContexteDonnee contexteDonnee);


        /// <summary>
        /// Le data du result contient un CRequeteSNMPOID
        /// </summary>
        /// <param name="contexte"></param>
        /// <returns></returns>
        public virtual CResultAErreur GetRequeteSNMPOID(CContexteDonnee contexte)
        {
            CResultAErreur result = CResultAErreur.True;
            CRequeteSnmpOID requeteOID = new CRequeteSnmpOID ();
            requeteOID.IpAgent = IpAgent;
            requeteOID.Community = Community;
            requeteOID.OID = GetOID(contexte);
            if ( requeteOID.OID.Length == 0 )
            {
                result.EmpileErreur(I.T("Can not find OID for SNMP object @1|30001", GetDescriptionVariableSNMP()));
                return result;
            }
            requeteOID.Type = GetType(contexte);
            if (requeteOID.Type.Length == 0)
            {
                result.EmpileErreur(I.T("Can not find Type for SNMP object @1|30002", GetDescriptionVariableSNMP()));
                return result;
            }
            requeteOID.TimeOut = TimeOut;
            requeteOID.NbRetry = NbRetry;
            requeteOID.VersionSNMP = VersionSNMP;
            requeteOID.Port = Port;
            result.Data = requeteOID;
            return result;
        }

        /// <summary>
        /// Le data du result contient le résultat de la requête
        /// </summary>
        /// <param name="contexteDonnee"></param>
        /// <returns></returns>
        public CResultAErreur GetValueSNMP( CContexteDonnee contexteDonnee )
        {
            CResultAErreur result = CResultAErreur.True;
            IRequeteSNMPServeur requeteurServeur = C2iFactory.GetNewObjetForSession("CRequeteSNMPServeur", typeof(IRequeteSNMPServeur), contexteDonnee.IdSession) as IRequeteSNMPServeur;
            if ( requeteurServeur == null )
            {
                result.EmpileErreur(I.T("Can not instanciate SNMP Query server|20001"));
                return result;
            }
            result = GetRequeteSNMPOID(contexteDonnee);
            if (!result)
                return result;
            CRequeteSnmpOID requeteOID = result.Data as CRequeteSnmpOID;
            if (requeteOID == null)
            {
                result.EmpileErreur(I.T("Error while creating OID SNMP QUERY|20005"));
                return result;
            }
            return requeteurServeur.GetValue(requeteOID);
        }


        /// <summary>
        /// Le data du result contient le résultat de la requête (CVariableSNMPResultat)
        /// </summary>
        /// <param name="contexteDonnee"></param>
        /// <returns></returns>
        public CResultAErreur GetNextValueSNMP(CContexteDonnee contexteDonnee)
        {
            CResultAErreur result = CResultAErreur.True;
            IRequeteSNMPServeur requeteurServeur = C2iFactory.GetNewObjetForSession("CRequeteSNMPServeur", typeof(IRequeteSNMPServeur), contexteDonnee.IdSession) as IRequeteSNMPServeur;
            if (requeteurServeur == null)
            {
                result.EmpileErreur(I.T("Can not instanciate SNMP Query server|20001"));
                return result;
            }
            result = GetRequeteSNMPOID(contexteDonnee);
            if (!result)
                return result;
            CRequeteSnmpOID requeteOID = result.Data as CRequeteSnmpOID;
            if (requeteOID == null)
            {
                result.EmpileErreur(I.T("Error while creating OID SNMP QUERY|20005"));
                return result;
            }
            return requeteurServeur.GetNextValue(requeteOID);
        }


        public CResultAErreur SetValueSNMP(CContexteDonnee contexte, object valeur)
        {
            CResultAErreur result = CResultAErreur.True;
            IRequeteSNMPServeur requeteurServeur = C2iFactory.GetNewObjetForSession("CRequeteSNMPServeur", typeof(IRequeteSNMPServeur), contexte.IdSession) as IRequeteSNMPServeur;
            if (requeteurServeur == null)
            {
                result.EmpileErreur(I.T("Can not instanciate SNMP Query server|20001"));
                return result;
            }
            result = GetRequeteSNMPOID(contexte);
            if (!result)
                return result;
            CRequeteSnmpOID requeteOID = result.Data as CRequeteSnmpOID;
            if (requeteOID == null)
            {
                result.EmpileErreur(I.T("Error while creating OID SNMP QUERY|20005"));
                return result;
            }
            return requeteurServeur.SetValue(requeteOID, valeur);
        }
    }

    public interface IRequeteSNMPServeur
    {
        CResultAErreur GetValue(CRequeteSnmpOID requete);
        CResultAErreur GetNextValue(CRequeteSnmpOID requete);
        CResultAErreur GetTable(CRequeteSnmpOID requete);
        CResultAErreur SetValue(CRequeteSnmpOID requete, object valeur);
    }
}
