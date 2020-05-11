using System;
using System.Collections.Generic;
using System.Text;

using sc2i.common;

namespace spv.data.ConsultationAlarmes
{

    public enum ETypeObjetEnAlarme
    {
        AucunObjet  = 0,
        Site        = 1,
        Equipement  = 4,
        Liaison     = 5,
        Inconnu     = 9
    }


    // Position des champs d'un message d'alarme (code message = 0)
    public enum EChampsMessageAlarme
    {
        CodeMessage=0,                  // Code du message (0)
        NombreDeChamps,                 // Nombre de champs dans le message (35)
        IDEvtAlarme,                    // ID dans la table ALARM (ALARM_ID)
        IDAlarmData,                    // ID dans la table ALARMDATA
        IDMessage,                      // ID du message dans la table des messages
        IDAlarmeGeree,                  // ID dans la table ALARMGEREE (ALARMGEREE_ID)
        IDObjetEnAlarme,                // ID de l'objet en alarme (SITE_ID ou EQUIP_ID ou LIAI_ID ou 999 (autre))
        TypeObjetEnAlarme,              // ID du type de l'objet en alarme
        IDDebutAlarme,                  // ID de l'enregistrement de début d'alarme
        NomAlarmeGeree,                 // Nom de l'alarme gérée associée
        ClasseAlarme,                   // Classe de l'alarme (IS, TRAPG, TRAPS, etc.)
        NumeroObjetDeCollecteOuTrap,    // Numéro de l'objet de collecte (n° IS ou n° trap)
        TypeAlarmeX733,                 // Type de l'alarme (Communication, qualité service, etc.)
        DateAlarme,                     // Date de l'événement alarme
        Gravite,                        // Niveau de gravité de l'alarme
        NomSeuil,                       // Nom du seuil associé quand alarme de seuil
        ValeurSeuil,                    // Valeur du seuil quand alarme de seuil
        NumeroSortieAlarmeOuIP,         // N° de sortie alarme (accès GTR ou bit SEM ou adresse IP pour trap)
        NatureAlarme,                   // alarme physique, confirmée, fréquente, de superviseur
        CommentaireAlarmeGeree,
        InformationAdditionnelle,
        IndicateurAAcquitter,
        IndicateurActiverSonnerie,
        TypeSonnerie,                   // Toujours à 0
        IndicateurAlarmeOuCommutateur,  // Alarme ou position de commutateur
        NomDuSite,                      // Nom du site de l'élément en défaut
        NomDuType,                      // Nom du type de l'élément en défaut
        NomElement,                     // Nom de l'élément en défaut (équipement, liaison ou site)
        NomService,                     // Nom du service (ou "+" si plusieurs)
        NomClient,                      // Nom du client (ou "+" si plusieurs)
        EtatOperationnelService,        // Etat opérationnel service (ou espace si plusieurs)
        EtatOperationnelTousServices,   // Etat opérationnel de tous les services concernés par l'alarme
        ChampsFicheElement,             // Noms et valeurs des champs de la fiche de l'élément
        ChampsFicheAlarme,              // Noms et valeurs des champs de la fiche de l'alarme gérée
        VariablesTrap                   // Variables du trap si trap
    };


    // Position des champs d'un message d'acquittement global d'une liste d'alarme
    public enum EChampsMessageAcquittementListe
    {
        CodeMessage = 0,                // Code du message (5)
        NombreDeChamps,                 // Nombre de champs dans le message (7)
        IDAlarme,                       // ID dans la table ALARM (0 = acquittement liste, AlarmId
                                        // acquittement alarme)
        IDMessage,                      // ID du message dans la table des messages
        IDAlarmeGeree,                  // ID dans la table ALARMGEREE (0)
        IDListeAlarme,                  // ID de la liste d'alarme acquittée
        TypeObjetEnAlarme               // Type de l'objet en alarme (0)
    };


    // Position des champs d'un message signalant la retombée d'une alarme
    public enum EChampsMessageAlarmeFille
    {
        CodeMessage = 0,                // Code du message (4)
        NombreDeChamps,                 // Nombre de champs dans le message (11)
        IDAlarme,                       // ID dans la table ALARM (ALARM_ID)
        IDMessage,                      // ID du message dans la table des messages
        IDAlarmeGeree,                  // ID dans la table ALARMGEREE (ALARMGEREE_ID)
        IDObjetEnAlarme,                // ID de l'objet en alarme (SITE_ID ou EQUIP_ID ou LIAI_ID ou 999 (autre))
        TypeObjetEnAlarme,              // Type de l'objet en alarme
        ClasseAlarme,                   // Classe de l'alarme (IS, TRAPG, TRAPS, etc.)
        NumeroObjetDeCollecteOuTrap,    // Numéro de l'objet de collecte (n° IS ou n° trap)
        NumeroSortieAlarmeOuIP,         // N° de sortie alarme (accès GTR ou bit SEM ou adresse IP pour trap)
        EtatOperationnelTousServices,   // Etat opérationnel de tous les services concernés par l'alarme
    };


    // Position des champs d'un message signalant un masquage d'alarme
    public enum EChampsMasquageAlarme
    {
        CodeMessage = 0,                // Code du message (7)
        NombreDeChamps,                 // Nombre de champs dans le message (18)
        IDAlarme,                       // ID dans la table ALARM (ALARM_ID)
        IDMessage,                      // ID du message dans la table des messages
        IDAlarmeGeree,                  // ID dans la table ALARMGEREE (0)
        IDObjetConcerne,                // ID de l'objet en alarme (SITE_ID ou EQUIP_ID ou LIAI_ID ou 999 (inconnu))
        TypeObjetConcerne,              // Type de l'objet en alarme
        IDDebutAlarme,                  // ID de l'enregistrement de début d'alarme (0)
        NomAlarmeGeree,                 // Nom de l'alarme gérée associée (espace)
        ClasseAlarme,                   // Classe de l'alarme associée (IS, TRAPG, TRAPS, etc.)
        NumeroObjetDeCollecteOuTrap,    // Numéro de l'objet de collecte associé (n° IS ou n° trap)
        TypeAlarmeX733,                 // Type de l'alarme (0)
        DateAlarme,                     // Date de l'alarme (espace)
        EvenementMasquage,              // Evénement de masquage (début ou fin, administrateur ou opérateur)
        NomSeuil,                       // Nom du seuil associé (espace)
        ValeurSeuil,                    // Valeur du seuil quand alarme de seuil (0)
        IdLienAccesAlarme,              // ID du lien accès alarme
        EtatOperationnelTousServices,   // Etat opérationnel de tous les services concernés par l'accès alarme
    };


    /// <summary>
    /// La classe CMessageAlarmeNotification est chargée de décoder
    /// le message d'alarme trouvé dans la base et ne sert à rien d'autre.
    /// Le message alarme notification peut être exploité pour créer un CInfoAlarmeAffichee,
    /// ou d'autres infos d'évenement d'alarme.
    /// </summary>
    [Serializable]
    public class CMessageAlarmeNotification
    {
        private const char cSeparateur = ';';
        private const string strSeparateur = ";";
        private const char cSousSep = '!';
        private ECategorieMessageAlarme m_nCodeMessage;
        private int m_nIdEvtAlarme;                       // ID de l'événement alarme
        private int m_nIdAlarmData;                       // ID des données de l'alarme
        private int m_nIdAlarmeGeree;                   
        private int m_nIdObjetConcerne = 0;
        private int m_nIdEquipement = 0;
        private int m_nIdSite = 0;
        private int m_nIdLiaison = 0;
        private int m_nIdDebutAlarme = 0;              // ID de l'événement alarme de début (quand message de fin)
        private string m_strNomAlarmeGeree;
        private ETypeObjetEnAlarme m_TypeObjetConcerne = ETypeObjetEnAlarme.Inconnu;
        private EGraviteAlarmeAvecMasquage m_GraviteAlarme;
        private EEvenementMasquage m_EvenementMasquage;
        private string m_strCommentaire;
        private string m_strClasseAlarme;
        private int m_nNumeroObjetDeCollecteOuTrap;
        private EAlarmEvent m_TypeEvenementAlarme;
        private DateTime m_DateEvenementAlarme;
        private string m_strNomSeuil;
        private int m_nValeurSeuil;
        private string m_strNumeroSortieAlarmeOuIP;
        private int m_nIdLienAccesAlarme;
        private EAlarmNature m_NatureAlarme;
        private string m_strInfoAdditionnelle;
        private bool m_bAAcquitter;
        private bool m_bSonner;
        private ETypeSon m_TypeSonnerie;
        private bool m_bPositionCommutateur;
        private string m_strNomSite;
        private string m_strNomTypeObjet;
        private string m_strNomObjet;
        private string[] m_ServicesConcernes;
        private int[] m_IdServicesConcernes;
        private string m_strNomClientsConcernes;
        private string[] m_ClientsConcernes;
        private string m_strEtatServices;
        private double[] m_EtatServices;
        private string m_strEtatsServices;
        private string m_strVariablesTrap;
        private string[] m_VariablesTrap;
        private int m_nTemp;
        private bool m_bMessagePourEM = false;
        private int m_nIdListeAlarmeAcquittee;
        private DateTime m_DateRetombeeFille;

        public CMessageAlarmeNotification(string strMessage)
        {
            String[] strDonnees = strMessage.Split('#');
            m_nCodeMessage = (ECategorieMessageAlarme) int.Parse(strDonnees[(int) EChampsMessageAlarme.CodeMessage]);
            string[] strTempArray;

            try
            {
                switch (m_nCodeMessage)
                {
                    case ECategorieMessageAlarme.AlarmStartStop:
                        m_nIdEvtAlarme = int.Parse(strDonnees[(int) EChampsMessageAlarme.IDEvtAlarme]);
                        m_nIdAlarmData = int.Parse(strDonnees[(int)EChampsMessageAlarme.IDAlarmData]);
                        m_nIdAlarmeGeree = int.Parse(strDonnees[(int) EChampsMessageAlarme.IDAlarmeGeree]);
                        m_nIdObjetConcerne = int.Parse(strDonnees[(int) EChampsMessageAlarme.IDObjetEnAlarme]);

                        m_TypeObjetConcerne = (ETypeObjetEnAlarme)
                            int.Parse(strDonnees[(int)EChampsMessageAlarme.TypeObjetEnAlarme]);

                        switch (m_TypeObjetConcerne)
                        {
                            case ETypeObjetEnAlarme.Equipement:
                                m_nIdEquipement = m_nIdObjetConcerne;
                                break;
                            case ETypeObjetEnAlarme.Site:
                                m_nIdSite = m_nIdObjetConcerne;
                                break;
                            case ETypeObjetEnAlarme.Liaison:
                                m_nIdLiaison = m_nIdObjetConcerne;
                                break;
                        }

                        if (int.TryParse(strDonnees[(int)EChampsMessageAlarme.IDDebutAlarme], out m_nTemp))
                            m_nIdDebutAlarme = m_nTemp;

                        m_strNomAlarmeGeree = strDonnees[(int) EChampsMessageAlarme.NomAlarmeGeree];
                        m_strClasseAlarme = strDonnees[(int) EChampsMessageAlarme.ClasseAlarme];
                        m_nNumeroObjetDeCollecteOuTrap =
                            CDivers.ConvertToint(strDonnees[(int)EChampsMessageAlarme.NumeroObjetDeCollecteOuTrap], 0);

                        m_TypeEvenementAlarme =
                            (EAlarmEvent)int.Parse(strDonnees[(int)EChampsMessageAlarme.TypeAlarmeX733]);

                        m_DateEvenementAlarme = DateTime.ParseExact(strDonnees[(int) EChampsMessageAlarme.DateAlarme],
                            "yyyy MM dd HH:mm:ss", null);
                        m_GraviteAlarme = (EGraviteAlarmeAvecMasquage) 
                            int.Parse(strDonnees[(int) EChampsMessageAlarme.Gravite]);

                        m_strNomSeuil = strDonnees[(int) EChampsMessageAlarme.NomSeuil];
                        m_nValeurSeuil = CDivers.ConvertToint(strDonnees[(int)EChampsMessageAlarme.ValeurSeuil], 0);

                        m_strNumeroSortieAlarmeOuIP = strDonnees[(int) EChampsMessageAlarme.NumeroSortieAlarmeOuIP];

                        m_NatureAlarme = (EAlarmNature)int.Parse(strDonnees[(int) EChampsMessageAlarme.NatureAlarme]);
                        m_strCommentaire = strDonnees[(int) EChampsMessageAlarme.CommentaireAlarmeGeree];
                        m_strInfoAdditionnelle = strDonnees[(int) EChampsMessageAlarme.InformationAdditionnelle];
                        if ( strDonnees[(int) EChampsMessageAlarme.IndicateurAAcquitter] == "" )
                            m_bAAcquitter = false;
                        else
                            m_bAAcquitter = System.Convert.ToBoolean (int.Parse(strDonnees[(int) EChampsMessageAlarme.IndicateurAAcquitter]));
                        if ( strDonnees[(int)EChampsMessageAlarme.IndicateurActiverSonnerie] == "" )
                            m_bSonner = false;
                        else
                            m_bSonner = System.Convert.ToBoolean (int.Parse(strDonnees[(int) EChampsMessageAlarme.IndicateurActiverSonnerie]));
                        m_TypeSonnerie = (ETypeSon)int.Parse(strDonnees[(int)EChampsMessageAlarme.TypeSonnerie]);
                        m_bPositionCommutateur =
                            System.Convert.ToBoolean(int.Parse(strDonnees[(int)EChampsMessageAlarme.IndicateurAlarmeOuCommutateur]));
                        m_strNomSite = strDonnees[(int) EChampsMessageAlarme.NomDuSite];
                        m_strNomTypeObjet = strDonnees[(int) EChampsMessageAlarme.NomDuType];
                        m_strNomObjet = strDonnees[(int) EChampsMessageAlarme.NomElement];

                        string strServicesConcernes = strDonnees[(int)EChampsMessageAlarme.NomService];
                        string[] strSrv, strNomSrv, strTemp;
                        int[] nIdSrv;
                        strSrv = strServicesConcernes.Split(new char[] { cSeparateur },
                                StringSplitOptions.RemoveEmptyEntries);
                        nIdSrv = new int[strSrv.Length];
                        strNomSrv = new String[strSrv.Length];
                        for (int i = 0; i < strSrv.Length; i++)
                        {
                            strTemp = strSrv[i].Split(new char[] { cSousSep });
                            nIdSrv[i] = Convert.ToInt32(strTemp[0]);
                            strNomSrv[i] = strTemp[1];
                        }
                        m_IdServicesConcernes = nIdSrv;
                        m_ServicesConcernes = strNomSrv;

                        m_strNomClientsConcernes = strDonnees[(int) EChampsMessageAlarme.NomClient];
                        if (m_strNomClientsConcernes.Contains(strSeparateur))
                            m_ClientsConcernes = m_strNomClientsConcernes.Split(new char[] { cSeparateur },
                                StringSplitOptions.RemoveEmptyEntries);

                        m_strEtatServices = strDonnees[(int) EChampsMessageAlarme.EtatOperationnelService];
                        if (m_strEtatServices.Contains(strSeparateur) || m_strEtatServices.Length > 0)
                        {
                            strTempArray = m_strEtatServices.Split(new char[] { cSeparateur }, 
                                StringSplitOptions.RemoveEmptyEntries);
                            m_EtatServices = new double[strTempArray.Length];
                            for (int i = 0; i < strTempArray.Length; i++)
                                m_EtatServices[i] = double.Parse(strTempArray[i]);
                        }
                        m_strEtatsServices = strDonnees[(int) EChampsMessageAlarme.EtatOperationnelTousServices];
                        m_strVariablesTrap = strDonnees[(int)EChampsMessageAlarme.VariablesTrap];

                        if (m_strVariablesTrap.Length > 0 && m_strVariablesTrap.Substring(0, 9) == "Trap SNMP")
                        {
                            // Dans ce cas, le format est le suivant :
                            // Trap SNMP : EquipId;variables traps séparées par";"
                            // exemple : Trap SNMP : 8601;.1.3.6.1.4.1,i,0;.1.3.6.1.4.1.9485.1.0,i,3;
                            int nPos = m_strVariablesTrap.IndexOf(cSeparateur);
                            m_strVariablesTrap = m_strVariablesTrap.Substring(nPos + 1);
                            if (m_strVariablesTrap.Length > 0)
                                m_VariablesTrap = m_strVariablesTrap.Split(cSeparateur);
                        }

                        break;
                    case ECategorieMessageAlarme.AcquittementListeAlarme:
                        m_nIdEvtAlarme = int.Parse(strDonnees[(int)EChampsMessageAcquittementListe.IDAlarme]);
                        m_nIdListeAlarmeAcquittee = int.Parse(strDonnees[(int) EChampsMessageAcquittementListe.IDListeAlarme]);

                        break;

                    case ECategorieMessageAlarme.AlarmMasqueeParUneAutre:
                        m_nIdEvtAlarme = int.Parse(strDonnees[(int) EChampsMessageAlarmeFille.IDAlarme]);
                        m_nIdAlarmeGeree = int.Parse(strDonnees[(int) EChampsMessageAlarmeFille.IDAlarmeGeree]);
                        m_nIdObjetConcerne = int.Parse(strDonnees[(int) EChampsMessageAlarmeFille.IDObjetEnAlarme]);

                        switch (m_TypeObjetConcerne)
                        {
                            case ETypeObjetEnAlarme.Equipement:
                                m_nIdEquipement = m_nIdObjetConcerne;
                                break;
                            case ETypeObjetEnAlarme.Site:
                                m_nIdSite = m_nIdObjetConcerne;
                                break;
                            case ETypeObjetEnAlarme.Liaison:
                                m_nIdLiaison = m_nIdObjetConcerne;
                                break;
                        }

                        if (int.TryParse(strDonnees[(int)EChampsMessageAlarmeFille.TypeObjetEnAlarme], out m_nTemp))
                            m_TypeObjetConcerne = (ETypeObjetEnAlarme)m_nTemp;
                        m_strClasseAlarme = strDonnees[(int) EChampsMessageAlarmeFille.ClasseAlarme];
                        m_nNumeroObjetDeCollecteOuTrap = int.Parse(strDonnees[(int) EChampsMessageAlarmeFille.NumeroObjetDeCollecteOuTrap]);
                        m_strNumeroSortieAlarmeOuIP = strDonnees[(int) EChampsMessageAlarmeFille.NumeroSortieAlarmeOuIP];
                        m_strEtatsServices = strDonnees[(int) EChampsMessageAlarmeFille.EtatOperationnelTousServices];
                        m_DateRetombeeFille = CDivers.GetSysdateNotNull();

                        break;

                    case ECategorieMessageAlarme.MasquageAccesAlarme:
                        m_nIdObjetConcerne = int.Parse(strDonnees[(int) EChampsMasquageAlarme.IDObjetConcerne]);

                        m_TypeObjetConcerne =
                            (ETypeObjetEnAlarme)int.Parse(strDonnees[(int) EChampsMasquageAlarme.TypeObjetConcerne]);

                        switch (m_TypeObjetConcerne)
                        {
                            case ETypeObjetEnAlarme.Equipement:
                                m_nIdEquipement = m_nIdObjetConcerne;
                                break;
                            case ETypeObjetEnAlarme.Site:
                                m_nIdSite = m_nIdObjetConcerne;
                                break;
                            case ETypeObjetEnAlarme.Liaison:
                                m_nIdLiaison = m_nIdObjetConcerne;
                                break;
                        }

                        m_strClasseAlarme = strDonnees[(int) EChampsMasquageAlarme.ClasseAlarme];
                        m_nNumeroObjetDeCollecteOuTrap = 
                            int.Parse(strDonnees[(int) EChampsMasquageAlarme.NumeroObjetDeCollecteOuTrap]);

                        m_EvenementMasquage = (EEvenementMasquage)
                            int.Parse(strDonnees[(int) EChampsMasquageAlarme.EvenementMasquage]);

                        m_nIdLienAccesAlarme =
                            int.Parse(strDonnees[(int) EChampsMasquageAlarme.IdLienAccesAlarme]);

                        m_strEtatsServices = strDonnees[(int)EChampsMasquageAlarme.EtatOperationnelTousServices];

                        break;

                    default:
                        m_bMessagePourEM = true;
                        break;
                }
            }
            catch (Exception e)
            {
                throw new Exception(I.T("Error in decoding MESSALRM message (@1)|50002", e.Message));
            }

        }

        public ECategorieMessageAlarme CodeMessage
        {
            get
            {
                return m_nCodeMessage;
            }
            set
            {
                m_nCodeMessage = value;
            }
        }


        public bool MessagePourEm
        {
            get
            {
                return m_bMessagePourEM;
            }
        }

        public int IdEvtAlarme
        {
            get
            {
                return m_nIdEvtAlarme;
            }
            set
            {
                m_nIdEvtAlarme = value;
            }
        }


        public int IdAlarmData
        {
            get
            {
                return m_nIdAlarmData;
            }
        }


        public int IdAlarmeGeree
        {
            get
            {
                return m_nIdAlarmeGeree;
            }
            set
            {
                m_nIdAlarmeGeree = value;
            }
        }

        public int IdSite
        {
            get
            {
                return m_nIdSite;
            }
            set
            {
                m_nIdSite = value;
            }
        }

        public int IdEquipement
        {
            get
            {
                return m_nIdEquipement;
            }
            set
            {
                m_nIdEquipement = value;
            }
        }


        public int IdLiaison
        {
            get
            {
                return m_nIdLiaison;
            }
            set
            {
                m_nIdLiaison = value;
            }
        }


        public int IdAlarmeDebut
        {
            get
            {
                return m_nIdDebutAlarme;
            }
            set
            {
                m_nIdDebutAlarme = value;
            }
        }

        public string NomAlarmeGeree
        {
            get
            {
                return m_strNomAlarmeGeree;
            }
            set
            {
                m_strNomAlarmeGeree = value;
            }
        }

        public ETypeObjetEnAlarme TypeObjetEnAlarme
        {
            get
            {
                return m_TypeObjetConcerne;
            }
            set
            {
                m_TypeObjetConcerne = value;
            }
        }

        public EGraviteAlarmeAvecMasquage GraviteAlarme
        {
            get
            {
                return m_GraviteAlarme;
            }
            set
            {
                m_GraviteAlarme = value;
            }
        }

        public string Commentaire
        {
            get
            {
                return m_strCommentaire;
            }
            set
            {
                m_strCommentaire = value;
            }
        }

        public string ClasseAlarme
        {
            get
            {
                return m_strClasseAlarme;
            }
            set
            {
                m_strClasseAlarme = value;
            }
        }

        public int NumeroObjetDeCollecteOuTrap
        {
            get
            {
                return m_nNumeroObjetDeCollecteOuTrap;
            }
            set
            {
                m_nNumeroObjetDeCollecteOuTrap = value;
            }
        }

        public EAlarmEvent TypeEvenementAlarme
        {
            get
            {
                return m_TypeEvenementAlarme;
            }
            set
            {
                m_TypeEvenementAlarme = value;
            }
        }

        public DateTime DateEvenementAlarme
        {
            get
            {
                return m_DateEvenementAlarme;
            }
            set
            {
                m_DateEvenementAlarme = value;
            }
        }

        public string NomSeuil
        {
            get
            {
                return m_strNomSeuil;
            }
            set
            {
                m_strNomSeuil = value;
            }
        }

        public int ValeurSeuil
        {
            get
            {
                return m_nValeurSeuil;
            }
            set
            {
                m_nValeurSeuil = value;
            }
        }

        public string NumeroSortieAlarmeOuIP
        {
            get
            {
                return m_strNumeroSortieAlarmeOuIP;
            }
            set
            {
                m_strNumeroSortieAlarmeOuIP = value;
            }
        }

        public EAlarmNature NatureAlarme
        {
            get
            {
                return m_NatureAlarme;
            }
            set
            {
                m_NatureAlarme = value;
            }
        }

        public string InfoAdditionnelle
        {
            get
            {
                return m_strInfoAdditionnelle;
            }
            set
            {
                m_strInfoAdditionnelle = value;
            }
        }

        public bool AAcquitter
        {
            get
            {
                return m_bAAcquitter;
            }
            set
            {
                m_bAAcquitter = value;
            }
        }

        public bool Sonner
        {
            get
            {
                return m_bSonner;
            }
            set
            {
                m_bSonner = value;
            }
        }

        public ETypeSon TypeSonnerie
        {
            get
            {
                return m_TypeSonnerie;
            }
            set
            {
                m_TypeSonnerie = value;
            }
        }

        public bool EstPositionCommutateur
        {
            get
            {
                return m_bPositionCommutateur;
            }
            set
            {
                m_bPositionCommutateur = value;
            }
        }

        public string NomSite
        {
            get
            {
                return m_strNomSite;
            }
            set
            {
                m_strNomSite = value;
            }
        }

        public string NomTypeObjet
        {
            get
            {
                return m_strNomTypeObjet;
            }
            set
            {
                m_strNomTypeObjet = value;
            }
        }

        public string NomObjet
        {
            get
            {
                return m_strNomObjet;
            }
            set
            {
                m_strNomObjet = value;
            }
        }

        public string[] ServicesConcernes
        {
            get
            {
                return m_ServicesConcernes;
            }
            set
            {
                m_ServicesConcernes = value;
            }
        }

        public int[] IdServicesConcernes
        {
            get
            {
                return m_IdServicesConcernes;
            }
            set
            {
                m_IdServicesConcernes = value;
            }
        }

        public string[] ClientsConcernes
        {
            get
            {
                return m_ClientsConcernes;
            }
            set
            {
                m_ClientsConcernes = value;
            }
        }

        public double[] EtatServices
        {
            get
            {
                return m_EtatServices;
            }
            set
            {
                m_EtatServices = value;
            }
        }

        public string EtatsServices
        {
            get
            {
                return m_strEtatsServices;
            }
            set
            {
                m_strEtatsServices = value;
            }
        }

        public string[] VariablesTrap
        {
            get
            {
                return m_VariablesTrap;
            }
            set
            {
                m_VariablesTrap = value;
            }
        }

        public int IdListeAlarmeAcquittee
        {
            get
            {
                return m_nIdListeAlarmeAcquittee;
            }
            set
            {
                m_nIdListeAlarmeAcquittee = value;
            }
        }

        public DateTime DateRetombeeFille
        {
            get
            {
                return m_DateRetombeeFille;
            }
            set
            {
                m_DateRetombeeFille = value;
            }
        }


        public EEvenementMasquage EvenementMasquage
        {
            get
            {
                return m_EvenementMasquage;
            }
            set
            {
                m_EvenementMasquage = value;
            }
        }

        public int IdLienAccesAlarme
        {
            get
            {
                return m_nIdLienAccesAlarme;
            }
            set
            {
                m_nIdLienAccesAlarme = value;
            }
        }
    }
}
