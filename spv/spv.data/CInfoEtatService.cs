using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace spv.data
{
    public class CInfoEtatService
    {
        private int m_nServiceId;
        private EEtatOperationnelService m_EtatAvant;
        private EEtatOperationnelService m_EtatApres;
        private EEtatMasquageService m_EtatMasquage;

        public CInfoEtatService()
        {
            m_nServiceId = -1;
            m_EtatAvant = EEtatOperationnelService.OK;
            m_EtatApres = EEtatOperationnelService.OK;
            m_EtatMasquage = EEtatMasquageService.NomMasque;
        }

        public CInfoEtatService
            (Int32 nIdService,
             EEtatOperationnelService etatAvant,
             EEtatOperationnelService etatApres,
             EEtatMasquageService etatMasquage
            )
        {
            m_nServiceId = nIdService;
            m_EtatAvant = etatAvant;
            m_EtatApres = EtatApres;
            m_EtatMasquage = etatMasquage;
        }

        public Int32 IdService
        {
            get
            {
                return m_nServiceId;
            }
        }

        public EEtatOperationnelService EtatAvant
        {
            get
            {
                return m_EtatAvant;
            }
        }

        public EEtatOperationnelService EtatApres
        {
            get
            {
                return m_EtatApres;
            }
        }

        public EEtatMasquageService EtatMasquage
        {
            get
            {
                return m_EtatMasquage;
            }
        }
    }
}
