using sc2i.data;
using sc2i.multitiers.client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportDocsMyanmar
{
    public class CImportMyanmarConst
    {
        private static CSessionClient m_sessionClient;
        private static CContexteDonnee m_contexteDonnee = null;

        public static CSessionClient SessionClient
        {
            get
            {
                return m_sessionClient;
            }
            set
            {
                m_sessionClient = value;
            }
        }

        public static CContexteDonnee ContexteDonnee
        {
            get
            {
                if (m_contexteDonnee == null && m_sessionClient != null)
                {
                    m_contexteDonnee = new CContexteDonnee(m_sessionClient.IdSession, true, false);
                }
                return m_contexteDonnee;

            }
        }
    }
}
