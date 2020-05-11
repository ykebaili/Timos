using System;
using System.Collections.Generic;
using System.Text;
using sc2i.data;
using sc2i.common;


namespace spv.data.ConsultationAlarmes
{
    [Serializable]
    public class CInfoServiceAlarmeAffichee
    {
        private int m_nId;
        private string m_stName;
        private double m_EtatOper;
        private double m_OldEtatOper;

        public CInfoServiceAlarmeAffichee()
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

        [DynamicField("Service name")]
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

        public double EtatOper
        {
            get
            {
                return m_EtatOper;
            }
            set
            {
                m_EtatOper = value;
            }
        }

        
        public double OldEtatOper
        {
            get
            {
                return m_OldEtatOper;
            }
            set
            {
                m_OldEtatOper = value;
            }
        }

        
        public CSpvSchemaReseau GetSpvService(CContexteDonnee contexteDonnee)
        {
            if (m_nId == 0 && Name.Length > 0)
                return GetSpvServiceByName(contexteDonnee);


            CSpvSchemaReseau service = new CSpvSchemaReseau(contexteDonnee);
            if (service.ReadIfExists(m_nId))
                return service;

            return null;
        }

        public CSpvSchemaReseau GetSpvServiceByName(CContexteDonnee ctx)
        {
            CFiltreData filtre = new CFiltreData(CSpvSchemaReseau.c_champLibelle + "=@1",
                    Name);
            CSpvSchemaReseau spvService = new CSpvSchemaReseau(ctx);
            if (spvService.ReadIfExists(filtre))
                return spvService;

            return null;
        }
        
        public override string ToString()
        {
            return Name;
        }
    }
}
