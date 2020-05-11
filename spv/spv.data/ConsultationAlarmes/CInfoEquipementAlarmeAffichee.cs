using System;
using System.Collections.Generic;
using System.Text;
using sc2i.data;
using sc2i.common;


namespace spv.data.ConsultationAlarmes
{
    [Serializable]
    public class CInfoEquipementAlarmeAffichee
    {
        private int m_nId = 0;
        private string m_stName;
        private int m_nTypeId = 0;
        private string m_stTypeName;

        public CInfoEquipementAlarmeAffichee()
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

        [DynamicField("Equipement name")]
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

        [DynamicField("Equipement type name")]
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

        public CSpvEquip GetSpvEquip(CContexteDonnee contexteDonnee)
        {
            CSpvEquip equip = new CSpvEquip(contexteDonnee);
            if (equip.ReadIfExists(m_nId))
                return equip;

            return null;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
