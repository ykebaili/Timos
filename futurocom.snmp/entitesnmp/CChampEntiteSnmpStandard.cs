using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.expression;
using sc2i.common;

namespace futurocom.snmp.entitesnmp
{
    [Serializable]
    public class CChampEntiteSnmpStandard : I2iSerializable, IChampEntiteSNMP
    {
        private string m_strNomChamp = "";
        private string m_strDescription = "";
        private ETypeChampBasique m_typeChamp = ETypeChampBasique.String;
        private string m_strId;

        //------------------------------------
        public CChampEntiteSnmpStandard()
        {
            m_strId = Guid.NewGuid().ToString();
        }

        //------------------------------------
        [DynamicField("Field name")]
        public string NomChamp
        {
            get
            {
                return m_strNomChamp;
            }
            set
            {
                m_strNomChamp = value;
            }
        }

        //------------------------------------
        [DynamicField("Field type")]
        public ETypeChampBasique TypeChamp
        {
            get
            {
                return m_typeChamp;
            }
            set
            {
                m_typeChamp = value;
            }
        }

        //------------------------------------
        public string Id
        {
            get
            {
                return m_strId;
            }
            set
            {
                m_strId = value;
            }
        }

        //------------------------------------
        [DynamicField("Description")]
        public string Description
        {
            get
            {
                return m_strDescription;
            }
            set
            {
                m_strDescription = value;
            }
        }

        //------------------------------------
        [DynamicField("Read only")]
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
            set
            {
            }
        }



        //------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            serializer.TraiteString(ref m_strNomChamp);

            int nTmp = (int)m_typeChamp;
            serializer.TraiteInt(ref nTmp);
            m_typeChamp = (ETypeChampBasique)nTmp;

            serializer.TraiteString(ref m_strId);

            serializer.TraiteString(ref m_strDescription);

            return result;
        }
    }
            

}
