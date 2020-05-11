using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using futurocom.supervision;
using sc2i.common.memorydb;

namespace futurocom.supervision.alarmes
{
    public class CBaseAffichageListeAlarmes
    {
        private List<CLocalAlarmeAffichee> m_alarmes = new List<CLocalAlarmeAffichee>();
        private CMemoryDb m_database;

        public CBaseAffichageListeAlarmes(CMemoryDb database)
        {
            m_database = database;
        }

        private void AddElement(CLocalAlarmeAffichee alarme)
        {
            if ( !m_alarmes.Contains ( alarme ) )
                m_alarmes.Add(alarme);
            foreach (CLocalAlarmeAffichee elt in alarme.Childs)
                AddElement(elt);
        }

        public IEnumerable<CLocalAlarmeAffichee> GetElements()
        {
            return m_alarmes.AsReadOnly();
        }

        public void AppliqueParametreListeAlarmes(CParametreAffichageListeAlarmes parametre)
        {
            foreach (CLocalAlarmeAffichee elt in GetElements())
            {
                        
            }

        }

        

    }
}
