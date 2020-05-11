using System;
using System.Collections.Generic;
using System.Text;
using sc2i.data;
using sc2i.common;


namespace spv.data.ConsultationAlarmes
{
    [Serializable]
    public class CInfoLiaiAlarmeAffichee
    {
        private int m_nId;
        private string m_stName;
        private int m_nTypeId = 0;
        private string m_stTypeName;

        public CInfoLiaiAlarmeAffichee()
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

        [DynamicField("Link name")]
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

        public int TypeId
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

        [DynamicField("Link type name")]
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

        public CSpvLiai GetSpvLiai(CContexteDonnee contexteDonnee)
        {
            CSpvLiai liai = new CSpvLiai(contexteDonnee);
            if (liai.ReadIfExists(m_nId))
                return liai;

            return null;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
