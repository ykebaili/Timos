using System;
using System.Collections.Generic;
using System.Text;
using sc2i.data;
using sc2i.common;

namespace spv.data.SNMP
{
    [Serializable]
    public class CRequeteSNMPVariable : CRequeteSNMP
    {
        private string m_strNomVariable;
        private int m_nIdMibModule;
        private CSpvMibobj m_spvMibObj;

        public CRequeteSNMPVariable()
        {
        }

        public CRequeteSNMPVariable(string strIpAgent,
            string strCommunity,
            int nIdModuleMib,
            string strNomVariable)
            : base(strIpAgent,strCommunity)
        {
            m_strNomVariable = strNomVariable;
            m_nIdMibModule = nIdModuleMib;
        }

        public string NomVariable
        {
            get
            {
                return m_strNomVariable;
            }
            set
            {
                m_strNomVariable = value;
            }
        }

        public int IdMibModule
        {
            get
            {
                return m_nIdMibModule;
            }
            set
            {
                m_nIdMibModule = value;
            }
        }

        public CSpvMibobj objetMib
        {
            get
            {
                return m_spvMibObj;
            }
            set
            {
                m_spvMibObj = value;
            }
        }

        public override string GetOID( CContexteDonnee contexteDonnee)
        {
            if (objetMib == null)
                SeekVariable(contexteDonnee);

            if (objetMib != null)
                //on enlève le "." au début, puis on ajoute ".0" à la fin
                return objetMib.OidObjet + ".0";
            return "";
        }


        public override string GetType(CContexteDonnee contexteDonnee)
        {
            if (objetMib == null)
                SeekVariable(contexteDonnee);

            if (objetMib != null)
                return objetMib.TypeSnmp;
            return "";
        }


        public bool SeekVariable(CContexteDonnee ctx)
        {
            objetMib = null;
            CSpvMibobj objVariable = new CSpvMibobj(ctx);
            if (objVariable.ReadIfExists(new CFiltreData(
                CSpvMibobj.c_champMIBOBJ_NAME + "=@1 and " +
                CSpvMibobj.c_champMIBMODULE_ID + "=@2",
                NomVariable,
                IdMibModule)))
            {
                objetMib = objVariable;
                return true;
            }
            return false;
        }


        internal override string GetDescriptionVariableSNMP()
        {
            return I.T("Variable @1|20003", NomVariable);
        }

    }
}
