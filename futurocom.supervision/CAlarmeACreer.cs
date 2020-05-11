using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace futurocom.supervision
{
    public enum EOptionCreationAlarme
    {
        Always = 0,
        SiPasDeParentActif = 1,
        SiParentActif = 2
    }
    /// <summary>
    /// contient une alarme pas encore créée avec des options de création pour le gestionnaire
    /// d'alarmes
    /// </summary>
    [Serializable]
    public class CAlarmeACreer
    {
        private EOptionCreationAlarme m_optionCreation = EOptionCreationAlarme.Always;
        private CLocalAlarme m_alarme = null;

        public CAlarmeACreer(CLocalAlarme alarme, EOptionCreationAlarme option)
        {
            m_alarme = alarme;
            m_optionCreation = option;
        }

        public CLocalAlarme Alarme
        {
            get
            {
                return m_alarme;
            }
        }

        public EOptionCreationAlarme OptionCreation
        {
            get
            {
                return m_optionCreation;
            }
        }
    }
}
