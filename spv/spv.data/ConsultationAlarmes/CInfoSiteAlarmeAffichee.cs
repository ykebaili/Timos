using System;
using System.Collections.Generic;
using System.Text;
using sc2i.data;
using sc2i.common;


namespace spv.data.ConsultationAlarmes
{
    [Serializable]
    public class CInfoSiteAlarmeAffichee
    {
        private int? m_nId;
        private string m_stName;
        private int? m_nTypeId = 0;
        private string m_stTypeName;

        public CInfoSiteAlarmeAffichee()
        {
        }

        public int? Id
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

        [DynamicField("Site name")]
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

        public int? TypeId
        {
            get
            {
                return m_nTypeId;
            }
            set
            {
                m_nTypeId = value;
            }
        }

        [DynamicField("Site type name")]
        public string TypeName
        {
            get
            {
                return m_stTypeName;
            }
            set
            {
                m_stTypeName = value;
            }
        }
        public CSpvSite GetSpvSite(CContexteDonnee contexteDonnee)
        {
            if ((m_nId == null || m_nId == 0) && Name.Length > 0)
                return GetSpvSiteByName(contexteDonnee);

            if (m_nId == null)
                return null;

            CSpvSite site = new CSpvSite(contexteDonnee);
            if (site.ReadIfExists((int)m_nId))
                return site;

            return null;
        }


        public CSpvSite GetSpvSiteByName(CContexteDonnee ctx)
        {
            CFiltreData filtre = new CFiltreData(CSpvSite.c_champSITE_NOM + "=@1",
                    Name);
            CSpvSite spvSite = new CSpvSite(ctx);
            if (spvSite.ReadIfExists(filtre))
                return spvSite;

            return null;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
