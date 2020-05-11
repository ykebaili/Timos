using sc2i.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timos.data.snmp.polling
{
    [Serializable]
    public class CListeSnmpPollingFields : I2iSerializable
    {
        private List<CSnmpPollingFieldSetup> m_listeFields = new List<CSnmpPollingFieldSetup>();

        //-------------------------------------------------------------------------------
        public CListeSnmpPollingFields()
        {
        }

        //-------------------------------------------------------------------------------
        public void AddField(CSnmpPollingFieldSetup field)
        {
            foreach ( CSnmpPollingFieldSetup test in m_listeFields )
            {
                if ( test.PollingFieldUID == field.PollingFieldUID )
                {
                    m_listeFields.Remove(test);
                    break;
                }
            }
            m_listeFields.Add(field);
        }

        //-------------------------------------------------------------------------------
        public void RemoveField(CSnmpPollingFieldSetup field)
        {
            m_listeFields.Remove(field);
        }

        //-------------------------------------------------------------------------------
        public IEnumerable<CSnmpPollingFieldSetup> Fields
        {
            get
            {
                return m_listeFields.AsReadOnly();
            }
        }

        //-------------------------------------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //-------------------------------------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            result = serializer.TraiteListe<CSnmpPollingFieldSetup>(m_listeFields);
            if (!result)
                return result;
            return result;
        }

        //-------------------------------------------------------------------------------
        public void Clear()
        {
            m_listeFields.Clear();
        }
    }
}
