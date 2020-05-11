using System;
using System.Collections.Generic;
using System.Text;
using sc2i.data;

namespace spv.data.ConsultationAlarmes
{

    public enum EEvenementMasquage
    {
        FinMasquageBrigadier = 0,
        DebutMasquageBrigadier = 1,
        FinMasquageAdministrateur = 2,
        DebutMasquageAdministrateur = 3
    }

    public enum EMasquage
    {
        NonMasque,
        MasqueBrigadier,
        MasqueAdministrateur
    }

    [Serializable]
    /*
    public class CEvenementAlarmMask
    {
        private int m_nSeverity;
        private string m_stNomL;
        private int m_nIdLienAccesAlarme;
        private int? m_nIdSite;
        private int? m_nIdEquipement;
        private int? m_nIdLiaison;

        private EEvenementMasquage ?m_detailMasquage = null;
        
        private const int m_nPositionGravite = 14;

        public CEvenementAlarmMask(string stMessalrmMessage, string stSeparator)
        {
            int     index = 0;
            CDivers div = new CDivers();
            string  st;

            string[] strDatas = stMessalrmMessage.Split('#');
            //for (int i = 0; i < m_nPositionGravite - 1; i++)
            //    st = div.Extract(stMessalrmMessage, ref index, stSeparator);

            m_nSeverity = div.ConvertToInt32(strDatas[(int)EChampMessageAlarme.Gravite],0);// div.Extract(stMessalrmMessage, ref index, stSeparator), 0);
            try{
                m_detailMasquage = (EEvenementMasquage)m_nSeverity;
            }
            catch{
            }
            m_nIdLienAccesAlarme = div.ConvertToInt32(strDatas[(int)EChampMessageAlarme.NumAlarm], 0);
            ETypeNEEnDefaut? nTypeElement = null;
            try{
                nTypeElement = (ETypeNEEnDefaut)div.ConvertToInt32(strDatas[(int)EChampMessageAlarme.TypeNeEnDefaut], 0);
            }
            catch{}
            int? nIdElement = div.ConvertToInt32(strDatas[(int)EChampMessageAlarme.IdNeEnDefaut],0);
            if ( nIdElement == 0 )
                nIdElement = null;
            switch (nTypeElement)
            {
                case ETypeNEEnDefaut.Equipement:
                    m_nIdEquipement = nIdElement;
                    break;
                case ETypeNEEnDefaut.Site:
                    m_nIdSite = nIdElement;
                    break;
                case ETypeNEEnDefaut.Liaison:
                    m_nIdLiaison = nIdElement;
                    break;
            }
                    

            if (m_nSeverity / 2 != 0)
                m_stNomL = (new CMaskedBy(EMaskedBy.Administrateur)).Libelle;
            else
                m_stNomL = (new CMaskedBy(EMaskedBy.Brigadier)).Libelle;

            m_nSeverity = m_nSeverity % 2;

            if (m_stNomL == (new CMaskedBy(EMaskedBy.Administrateur)).Libelle)
                m_nSeverity = 2 * m_nSeverity;            


        }

        public int Severity
        {
            get
            {
                return m_nSeverity;
            }
            set
            {
                m_nSeverity = value;
            }
        }

        public EEvenementMasquage ? DetailMasquage
        {
            get {
                return m_detailMasquage;
            }
        }



        public string LocalName
        {
            get
            {
                return m_stNomL;
            }
            set
            {
                m_stNomL = value;
            }
        }

        public int IdLienAccesAlarme
        {
            get
            {
                return m_nIdLienAccesAlarme;
            }
        }

        public int? IdSite
        {
            get
            {
                return m_nIdSite;
            }
        }

        public int? IdEquipement
        {
            get
            {
                return m_nIdEquipement;
            }
        }
        public int? IdLiaison
        {
            get
            {
                return m_nIdLiaison;
            }
        }
                
    }
*/
    public class CEvenementAlarmMask : CEvenementAlarm
    {
        private EMasquage m_nNiveauMasquage;
        private string m_stNomL;

        public CEvenementAlarmMask(CMessageAlarmeNotification message)
            : base(message)
        {
            int nSeverity = (int) Message.EvenementMasquage;

            if (nSeverity / 2 != 0)   // Début de masquage
                m_stNomL = (new CMaskedBy(EMaskedBy.Administrateur)).Libelle;
            else
                m_stNomL = (new CMaskedBy(EMaskedBy.Brigadier)).Libelle;

            nSeverity = nSeverity % 2;

            if (m_stNomL == (new CMaskedBy(EMaskedBy.Administrateur)).Libelle)
                nSeverity = 2 * nSeverity;

            m_nNiveauMasquage = (EMasquage)nSeverity;
        }

        public int IdLienAccesAlarme
        {
            get
            {
                return Message.IdLienAccesAlarme;
            }
        }

        public EMasquage NiveauMasquage
        {
            get
            {
                return m_nNiveauMasquage;
            }
            set
            {
                m_nNiveauMasquage = value;
            }
        }


        public string LocalName
        {
            get
            {
                return m_stNomL;
            }
            set
            {
                m_stNomL = value;
            }
        }

        public int? IdSite
        {
            get
            {
                return Message.IdSite;
            }
        }

        public int? IdEquipement
        {
            get
            {
                return Message.IdEquipement;
            }
        }

        public int? IdLiaison
        {
            get
            {
                return Message.IdLiaison;
            }
        }

        public EEvenementMasquage DetailMasquage
        {
            get
            {
                return Message.EvenementMasquage;
            }
        }
    }
}
