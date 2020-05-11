using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using timos.data.snmp;
using sc2i.common.synchronisation;
using sc2i.common;

namespace timos.data.serveur.snmp
{
    public class CSynchroMediation : MarshalByRefObject, ISynchroMediation
    {
        private int m_nIdSession = 0;
        public CSynchroMediation()
        {
        }

        public CSynchroMediation(int nIdSession)
        {
            m_nIdSession = nIdSession;
        }

        public CResultAErreur DoSynchro()
        {
            CResultAErreur result = CSynchroniseurBaseDistante.DefaultInstance.TraiteAll();
            return result;
        }

        public void RenouvelleBailParAppel()
        {
        }

        public int IdSession
        {
            get
            {
                return m_nIdSession;
            }
            set
            {
                m_nIdSession = value;
            }
        }
    }
}
