using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common.memorydb;
using futurocom.snmp.mediation;

namespace futurocom.snmp.mediation
{
    [Serializable]
    public class CDonneesSynchronisationMediation : IDonneeSynchronisationMediation
    {
        private CMemoryDb m_database = null;
        private int m_nIdSyncSessionDesDonnees = -1;

        //---------------------------------------------------------------------
        public CDonneesSynchronisationMediation(CMemoryDb database, int nIdSyncSessionDesDonnees)
        {
            if (database == null)
                database = new CMemoryDb();
            m_database = database;
            m_nIdSyncSessionDesDonnees = nIdSyncSessionDesDonnees;
        }

        //---------------------------------------------------------------------
        public CMemoryDb Database
        {
            get
            {
                return m_database;
            }
        }


        //---------------------------------------------------------------------
        public int IdSyncSessionDesDonnees
        {
            get
            {
                return m_nIdSyncSessionDesDonnees;
            }
        }


        
    }
}
