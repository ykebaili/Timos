using System;
using System.Collections.Generic;
using System.Text;
using sc2i.data;
using sc2i.common;
using sc2i.multitiers.client;

namespace spv.data.SNMP
{
    [Serializable]
    public class CRequeteSNMPDansTable : CRequeteSNMPVariable
    {
        private string m_strNomTable;
        private int m_nRowIndex;

        public CRequeteSNMPDansTable()
            : base()
        {
        }

        public CRequeteSNMPDansTable(string strIpAgent,
            string strCommunity,
            int nIdModuleMib,
            string strNomTable,
            string strNomVariable,
            int nRowIndex)
            : base(strIpAgent, strCommunity, nIdModuleMib, strNomVariable)
        {
            m_strNomTable = strNomTable;
            m_nRowIndex = nRowIndex;
        }

        public string NomTable
        {
            get
            {
                return m_strNomTable;
            }
            set
            {
                m_strNomTable = value;
            }
        }


        public int RowIndex
        {
            get
            {
                return m_nRowIndex;
            }
            set
            {
                RowIndex = value;
            }
        }

        public override string GetOID( CContexteDonnee contexteDonnee)
        {
            CSpvMibobj objVariable = new CSpvMibobj(contexteDonnee);
            if (objVariable.ReadIfExists(new CFiltreData(
                CSpvMibobj.c_champMIBOBJ_NAME + "=@1 and " +
                CSpvMibobj.c_champMIBOBJ_FATHERNAME + "=@2 and " +
                CSpvMibobj.c_champMIBMODULE_ID + "=@3",
                NomVariable,
                NomTable,
                IdMibModule)))
            {
                if (RowIndex < 0)
                    return objVariable.OidObjet;        // Pour du balayage de table on met l'OID pur de la variable

                return objVariable.OidObjet + "." + RowIndex.ToString();
            }
            return "";

        }


        internal override string GetDescriptionVariableSNMP()
        {
            return I.T("Table @1, Variable  @2|30003", NomTable, NomVariable);
        }


        /// <summary>
        /// Le data du result contient le résultat de la requête (List<CVariableSNMPResultat>)
        /// </summary>
        /// <param name="contexteDonnee"></param>
        /// <returns></returns>
        public CResultAErreur GetTableSNMP(CContexteDonnee contexteDonnee)
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
            return requeteurServeur.GetTable(requeteOID);
        }
    }
}
