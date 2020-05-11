using System;
using System.Collections.Generic;
using System.Text;
using sc2i.data;
using sc2i.common;


namespace spv.data.ConsultationAlarmes
{
    [Serializable]
    public class CInfoClientAlarmeAffichee
    {
        private int m_nId;
        private string m_stName;

        public CInfoClientAlarmeAffichee()
        {
        }

        public int Id
        {
            get
            {
                return m_nId;
            }
            set
            {
                m_nId = value;
            }
        }

        [DynamicField("Client name")]
        public string Name
        {
            get
            {
                return m_stName;
            }
            set
            {
                m_stName = value;
            }
        }

        public CSpvClient GetSpvClient(CContexteDonnee contexteDonnee)
        {
            if (m_nId == 0 && Name.Length > 0)
                return GetSpvClientByName(contexteDonnee);

            CSpvClient client = new CSpvClient(contexteDonnee);
            if (client.ReadIfExists(m_nId))
                return client;

            return null;
        }

        public CSpvClient GetSpvClientByName(CContexteDonnee ctx)
        {
            CFiltreData filtre = new CFiltreData(CSpvClient.c_champCLIENT_NOM + "=@1",
                    Name);
            CSpvClient spvClient = new CSpvClient(ctx);
            if (spvClient.ReadIfExists(filtre))
                return spvClient;

            return null;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
