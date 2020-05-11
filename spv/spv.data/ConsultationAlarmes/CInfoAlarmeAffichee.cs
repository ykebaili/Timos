using System;
using System.Collections.Generic;
using System.Text;
using sc2i.data;
using sc2i.common;
using System.Drawing;

namespace spv.data.ConsultationAlarmes
{
    public enum ETypeNEEnDefaut
    {
        Site = 1,
        Equipement = 4,
        Liaison = 5,
        Inconnu = 9
    }

   

    /// <summary>
    /// Représente des informations hors ligne (sans connexion à la base de données)
    /// sur une alarme
    /// </summary>
    [Serializable]
    [DynamicClass("AAA_INFO")]
    public class CInfoAlarmeAffichee
    {
        private double c_EtatOperOK = 1.0;

        private int m_nIdAlarmData = 0;       // ID des données de l'alarme dans la table ALARMDATA
        private int m_nIdSpvEvtAlarme = 0;    // ID de l'événement dans la table ALARM
 
        private string m_stAlarmCl;
        private int m_nNumObj = 0;
        private string m_stNumal;

        private int m_nGrave = 0;
        private Int32? m_nIddeb = 0;
        private string m_stNSeuil;		// nom du seuil de déclenchement
        private Int32? m_nVSeuil = 0;		// valeur de la mesure ayant déclenché le seuil sans objet si NSeuil est vide

        private DateTime  m_AlarmDate;
        private DateTime? m_StartAlarmDate = null;
        private DateTime? m_StopAlarmDate = null;
        private DateTime? m_DateEffacement = null; // Heure d'élimination de l'alarme de la liste des retombées

        private int m_nTexte = 0;       // 0 = Phys.
						                // 1 = Conf.
						                // 2 = Freq, 
						                // 3 = Syst. SYST : alarme du système de capture ou de l'équip. de médiation
						                // 4 = al. GSITE
						                // 5 = al. DOMO20
						                // 6 = al. SPY_SAT       
        private string m_stCommentaire; 
        private string m_stInfo;        
        private bool m_bAAcquitter = true;
        private bool m_bAcquittee = false; 
       
        private bool m_bCommut = false;
        private bool m_bSonne = false;   
             
  //      private string m_stFichEltG;   
  //      private string m_stFichAlG;
        private string m_stBindingVarInfo;
        private List<string> m_lstTrapInfo;
        
        private CInfoSiteAlarmeAffichee m_InfoSite = null;
        private CInfoEquipementAlarmeAffichee m_InfoEquip = null;
        private CInfoLiaiAlarmeAffichee m_InfoLiai = null;
        private CInfoAlarmeGereeAffichee m_InfoAlarmGeree = null;

        private List<CInfoClientAlarmeAffichee> m_lstInfoClients;
        private List<CInfoServiceAlarmeAffichee> m_lstInfoServices;      
        
        private const string m_subseparator = ";";
               
        private bool m_bLectureFaite = false;

        [NonSerialized]
        private CSpvAlarmeDonnee m_spvAlarm = null;
        //private CSpvAlarmeEvenement m_spvAlarm = null;

        public CInfoAlarmeAffichee(CEvenementAlarmStartStop evenementAlarme)
        {
            m_lstTrapInfo = new List<string>();
            m_lstInfoClients = new List<CInfoClientAlarmeAffichee>();
            m_lstInfoServices = new List<CInfoServiceAlarmeAffichee>();

            m_nIdAlarmData = evenementAlarme.IdAlarmData;
            m_nIdSpvEvtAlarme = evenementAlarme.IdEvtAlarme;
            m_InfoAlarmGeree = new CInfoAlarmeGereeAffichee();
            m_InfoAlarmGeree.Id = evenementAlarme.IdAlarmeGeree;
            m_InfoAlarmGeree.Name = evenementAlarme.NomAlarmeGeree;

            if (evenementAlarme.NomSite != null && evenementAlarme.NomSite.Length > 0)
            {
                m_InfoSite = new CInfoSiteAlarmeAffichee();
                m_InfoSite.Name = evenementAlarme.NomSite;
            }

            if (evenementAlarme.IdSite > 0)
            {
                if (m_InfoSite == null)
                    m_InfoSite = new CInfoSiteAlarmeAffichee();
                m_InfoSite.Id = evenementAlarme.IdSite;
                m_InfoSite.TypeName = evenementAlarme.NomTypeObjet;
            }
            else if (evenementAlarme.IdEquipement > 0)
            {
                m_InfoEquip = new CInfoEquipementAlarmeAffichee();
                m_InfoEquip.Id = (int) evenementAlarme.IdEquipement;
                m_InfoEquip.TypeName = evenementAlarme.NomTypeObjet;
                m_InfoEquip.Name = evenementAlarme.NomObjet;
            }
            else if (evenementAlarme.IdLiaison > 0)
            {
                m_InfoLiai = new CInfoLiaiAlarmeAffichee();
                m_InfoLiai.Id = (int) evenementAlarme.IdLiaison;
                m_InfoLiai.TypeName = evenementAlarme.NomTypeObjet;
                m_InfoLiai.Name = evenementAlarme.NomObjet;
            }

            m_nIddeb = evenementAlarme.IdAlarmeDebut;
            m_stAlarmCl = evenementAlarme.ClasseAlarme;
            m_nNumObj = evenementAlarme.NumeroObjetDeCollecteOuTrap;
            m_InfoAlarmGeree.CodeAlarmEvent = evenementAlarme.TypeEvenementAlarme;

            m_AlarmDate = evenementAlarme.DateEvenementAlarme;
            if (m_nIddeb > 0)   // C'est un événement de fin d'alarme
                m_StopAlarmDate = m_AlarmDate;
            else
                m_StartAlarmDate = m_AlarmDate;
            
            m_nGrave     = (int) evenementAlarme.Gravite;
            m_stNSeuil  = evenementAlarme.NomSeuil;
            m_nVSeuil    = evenementAlarme.ValeurSeuil;
            m_stNumal   = evenementAlarme.NumeroSortieAlarmeOuIP;
            m_nTexte = (int) evenementAlarme.NatureAlarme;

            m_stCommentaire   = evenementAlarme.Commentaire;
            m_stInfo          = evenementAlarme.InfoAdditionnelle;

            m_bAAcquitter = evenementAlarme.AAcquitter;
            m_bSonne = evenementAlarme.Sonner;

            m_InfoAlarmGeree.CodeRingType = (int?) evenementAlarme.TypeSonnerie;
            m_bCommut = evenementAlarme.EstPositionCommutateur;

            for (int i = 0; evenementAlarme.ServicesConcernes != null && 
                 i < evenementAlarme.ServicesConcernes.Length; i++)
            {
                CInfoServiceAlarmeAffichee service = new CInfoServiceAlarmeAffichee();
                service.Name = evenementAlarme.ServicesConcernes[i];
                service.Id = evenementAlarme.IdServicesConcernes[i];
                service.EtatOper = evenementAlarme.EtatServices[i];
                m_lstInfoServices.Add(service);
            }

            if (evenementAlarme.ClientsConcernes != null)
            {
                foreach (string strClient in evenementAlarme.ClientsConcernes)
                {
                    CInfoClientAlarmeAffichee client = new CInfoClientAlarmeAffichee();
                    client.Name = strClient;
                    m_lstInfoClients.Add(client);
                }
            }

            if (evenementAlarme.VariablesTrap != null)
            {
                foreach (string strVariableTrap in evenementAlarme.VariablesTrap)
                    m_lstTrapInfo.Add(strVariableTrap);
            }

            m_bLectureFaite = true;
        }


        public CInfoAlarmeAffichee(CSpvAlarmeDonnee spvAlarm)
        {
            m_spvAlarm = spvAlarm;
        }

        /*
         * public CInfoAlarmeAffichee(CSpvAlarmeEvenement spvAlarm)
        {
            m_spvAlarm = spvAlarm;
        }*/

        private void AssureData()
        {
            if (!m_bLectureFaite)
                ReadData();
        }

        private void ReadData()
        {
            using (CContexteDonnee contexte = new CContexteDonnee(0, true, false))
            {
                CSpvEvenementReseau evt;
                if (m_spvAlarm == null)     // Init. à partir de l'événement réseau
                {
                    evt = new CSpvEvenementReseau(contexte);
                    if (evt.ReadIfExists(m_nIdSpvEvtAlarme))
                        m_spvAlarm = evt.SpvAlarme;
                    else
                        return;
                }
                else
                    evt = m_spvAlarm.EvenementDebut;

                CDivers div = new CDivers();

                m_lstTrapInfo = new List<string>();
                m_lstInfoClients = new List<CInfoClientAlarmeAffichee>();
                m_lstInfoServices = new List<CInfoServiceAlarmeAffichee>();

                m_nIdAlarmData = m_spvAlarm.Id;

                m_InfoAlarmGeree = new CInfoAlarmeGereeAffichee();
                if (evt.SpvAlarmgeree != null)
                {
                    m_InfoAlarmGeree.Id = (int)evt.SpvAlarmgeree.Id;
                    m_InfoAlarmGeree.Name = evt.SpvAlarmgeree.Alarmgeree_Name;
                }

                if (m_spvAlarm.SpvSite != null)
                {
                    if (m_InfoSite == null)
                        m_InfoSite = new CInfoSiteAlarmeAffichee();
                    m_InfoSite.Id = (int)m_spvAlarm.SpvSite.Id;
                    m_InfoSite.Name = m_spvAlarm.SpvSite.SiteNom;
                    if (m_spvAlarm.SpvSite.TypeSite != null)
                        m_InfoSite.TypeName = m_spvAlarm.SpvSite.TypeSite.TypeSiteNom;
                    
                }

                else if (m_spvAlarm.SpvEquip != null)
                {
                    m_InfoEquip = new CInfoEquipementAlarmeAffichee();
                    m_InfoEquip.Id = (int)m_spvAlarm.EquipId;
                    m_InfoEquip.TypeName = m_spvAlarm.SpvEquip.TypeEquipement.Libelle;
                    m_InfoEquip.Name = m_spvAlarm.SpvEquip.CommentairePourSituer;
                }

                else if (m_spvAlarm.SpvLiai != null)
                {
                    m_InfoLiai = new CInfoLiaiAlarmeAffichee();
                    m_InfoLiai.Id = (int)m_spvAlarm.LiaiId;
                    m_InfoLiai.TypeName = m_spvAlarm.SpvLiai.Typeliaison.Libelle;
                    m_InfoLiai.Name = m_spvAlarm.SpvLiai.NomComplet;
                }

                //if (m_InfoSite == null)
                //    m_InfoSite = new CInfoSiteAlarmeAffichee();

                m_nIddeb = evt.Id;
                m_stAlarmCl = evt.AlarmCategory;
                m_nNumObj = evt.AlarmNumObj;
                m_InfoAlarmGeree.CodeAlarmEvent = (EAlarmEvent)m_spvAlarm.CodeEvenementX733;

                if (evt.TypeEvenementReseau == ETypeEvenementReseau.DebutAlarme)
                {
                    m_AlarmDate = m_spvAlarm.DateDebut;
                    m_StartAlarmDate = m_AlarmDate;
                }
                else
                {
                    m_AlarmDate = (System.DateTime)m_spvAlarm.DateFin;
                    m_StopAlarmDate = m_AlarmDate;
                    m_StartAlarmDate = m_spvAlarm.DateDebut;
                }

                m_nGrave = m_spvAlarm.CodeGravite;
                m_stNSeuil = m_spvAlarm.NomSeuilAlarme;
                m_nVSeuil = m_spvAlarm.ValeurSeuilAlarme;
                m_stNumal = evt.AlarmNumAl;
                m_nTexte = evt.CodeAlarmNature;

                m_stCommentaire = m_spvAlarm.Commententaire;
                m_stInfo = evt.AlarmInfo;

                if (m_spvAlarm.SpvLienAccesAlarme != null)
                {
                    m_bAAcquitter = (bool)m_spvAlarm.SpvLienAccesAlarme.Acquitter;
                    m_bSonne = (bool)m_spvAlarm.SpvLienAccesAlarme.SonActive;
                }

                if (evt.SpvAlarmgeree != null)
                    m_InfoAlarmGeree.CodeRingType = evt.SpvAlarmgeree.CodeAlarmgereeTypeSon;
                m_bCommut = evt.AlarmCommut;

                m_nIdSpvEvtAlarme = evt.Id;
                if (evt.ElementGereNomSite != null && evt.ElementGereNomSite.Length > 0)
                {
                    if (m_InfoSite == null)
                        m_InfoSite = new CInfoSiteAlarmeAffichee();
                    m_InfoSite.Name = evt.ElementGereNomSite;
                }
                m_InfoAlarmGeree.Name = m_spvAlarm.NomAlarmeGeree;

                //string stProgConcNom = m_spvAlarm.ProgrammesConcernes;
                if (m_spvAlarm.ServicesConcernes != null)
                {
                    foreach (System.Int32 nServiceId in m_spvAlarm.ServicesConcernes)
                    {
                        CInfoServiceAlarmeAffichee serviceAff = new CInfoServiceAlarmeAffichee();
                        serviceAff.Id = nServiceId;
                        CSpvSchemaReseau service = serviceAff.GetSpvService(contexte);
                        serviceAff.Name = service.Libelle;
                        m_lstInfoServices.Add(serviceAff);
                    }
                }


                if (m_spvAlarm.ClientsConcernes != null)
                {
                    foreach (System.Int32 nClientId in m_spvAlarm.ClientsConcernes)
                    {
                        CInfoClientAlarmeAffichee clientAff = new CInfoClientAlarmeAffichee();
                        clientAff.Id = nClientId;
                        CSpvClient client = clientAff.GetSpvClient(contexte);
                        clientAff.Name = client.CLIENT_NOM;
                        m_lstInfoClients.Add(clientAff);
                    }
                }

                if (m_spvAlarm.ProgsOper != null)
                {
                    CInfoServiceAlarmeAffichee infoService;
                    for (int i = 0; i < m_lstInfoServices.Count; i++)
                    {
                        infoService = m_lstInfoServices[i];
                        if (m_spvAlarm.ProgsOper.Length > i)
                            infoService.EtatOper = m_spvAlarm.ProgsOper[i];
                    }
                }

                m_stBindingVarInfo = m_spvAlarm.GetBindingVarInfo();
                FillTrapInfo();

                //m_bAcquittee = (m_spvAlarm.Acquittee == null) ? false : m_spvAlarm.Acquittee;
                m_bAcquittee = m_spvAlarm.Acquittee;

                m_bLectureFaite = true;
            }
        }


        public CSpvAlarmeDonnee GetSpvAlarme(CContexteDonnee contexteDonnee)
        {
            AssureData();

            CSpvAlarmeDonnee alarme = new CSpvAlarmeDonnee(contexteDonnee);
            if (alarme.ReadIfExists(m_nIdAlarmData))
                return alarme;
            return null;
           
        }

        /*
         * public CSpvAlarmeEvenement GetSpvAlarm(CContexteDonnee contexteDonnee)
        {
            AssureData();

            CSpvAlarmeEvenement alarm = new CSpvAlarmeEvenement(contexteDonnee);
            if (alarm.ReadIfExists(m_nIdSpvAlarme))
                return alarm;
            return null;
           
        }*/

      //  [DynamicField("Alarme ID")]
        public int IdSpvAlarmeData
        {
            get
            {
                AssureData();
                return m_nIdAlarmData;
            }       
        }

        public int IdSpvEvtAlarme
        {
            get
            {
                return m_nIdSpvEvtAlarme;
            }
        }

       
        [DynamicField("Threshold name")]
        public string SeuilName
        {
            get
            {
                AssureData();
                return m_stNSeuil;
            }
        }

        [DynamicField("Threshold value")]
        public int? SeuilValeur
        {
            get
            {
                AssureData();
                return m_nVSeuil;
            }
        }
      

        [DynamicField("Alarm comment")]
        public string AlarmComment
        {
            get
            {
                AssureData();
                return m_stCommentaire;
            }
        }
    
        [DynamicField("Alarm Date")]
        public DateTime AlarmDate
        {
            get
            {
                AssureData();
                return m_AlarmDate;
            }
        }

        public DateTime? DateDebut
        {
            get
            {
                AssureData();
                return m_StartAlarmDate;
            }
        }

      //  [DynamicField("Ending Date")]
        public DateTime? DateFin
        {
            get
            {
                AssureData();
                return m_StopAlarmDate;
            }
            set
            {
                m_StopAlarmDate = value;
            }
        }

    //    [DynamicField("Duration")]
        public TimeSpan? Duree
        {
            get
            {
                TimeSpan duree;

                AssureData();                

                if (IsFinished())
                {
                    duree = (DateTime)DateFin - AlarmDate;
                    return duree;
                }
                else
                    return null;                
            }            
        }

        public bool IsFinished()
        {
            AssureData();
            return (DateFin!=null || SeverityCode==(int)EGraviteAlarme.NoAlarm);
        }

        [DynamicField("Collection equipment / origin trap")]
        public string EDC
        {
            get
            {
                AssureData();
                string stEDC = string.Format("{0} {1} Al {2}", m_stAlarmCl, m_nNumObj, m_stNumal);
                return stEDC;
            }
        }

        
        [DynamicField("Additional information")]
        public string Info
        {
            get
            {
                AssureData();
                return m_stInfo;
     //test           return "Trap SNMP : 30;.1.3.6.1.4.1.119.2.3.69.202.101.2.1 = 642;.1.3.6.1.4.1.119.2.3.69.202.101.2.2 = 2005/03/14;.1.3.6.1.4.1.119.2.3.69.202.101.2.3 = 17:39:51;.1.3.6.1.4.1.119.2.3.69.202.101.2.4 = 1;.1.3.6.1.4.1.119.2.3.69.202.101.2.5 = 0;.1.3.6.1.4.1.119.2.3.69.202.101.2.6 = 0;.1.3.6.1.4.1.119.2.3.69.202.101.2.7 = .1.3.6.1.4.1.119.2.3.69.202.101.1.1.1.4.172.18.0.42;.1.3.6.1.4.1.119.2.3.69.202.101.2.8 = 5;";//tmp
            }
        }

        [DynamicChilds("Information Trap", typeof(string))] 
        public List<string> ListTrapInfo
        {
            get
            {
                AssureData();
                return m_lstTrapInfo;
            }
        }

        private void FillTrapInfo()
        {
            string stTrap;
            string stInfo;
            int    indx;
            CDivers div = new CDivers();           

            m_lstTrapInfo.Clear();

            if (m_stAlarmCl.CompareTo("TRAPG") != 0 && m_stAlarmCl.CompareTo("TRAPS") != 0)
                return;

            if (m_stBindingVarInfo.Length==0)
	        {
                indx = Info.IndexOf(m_subseparator);
                stTrap = Info.Substring(indx + 1);//skip "TRAP SNMP;"
	        }
	        else
                stTrap = m_stBindingVarInfo;

            indx=0;
            while (indx>=0)
	        {
                stInfo = div.Extract(stTrap, ref indx, m_subseparator);
                if (indx > 0)
                    m_lstTrapInfo.Add(stInfo);
	        }
        }

        [DynamicChilds("Concerned Services Information", typeof(CInfoServiceAlarmeAffichee))]
        public List<CInfoServiceAlarmeAffichee> ServicesConcernes
        {
            get
            {
                AssureData();
                return m_lstInfoServices;
            }
        }

        [DynamicChilds("Concerned Clients Information", typeof(CInfoClientAlarmeAffichee))]
        public List<CInfoClientAlarmeAffichee> ClientsConcernes
        {
            get
            {
                AssureData();
                return m_lstInfoClients;
            }
        }

        [DynamicField("Concerned Site Information")]
        public CInfoSiteAlarmeAffichee InfoSite
        {
            get
            {
                AssureData();
                return m_InfoSite;
            }
        }

        [DynamicField("Concerned Equipement Information")]
        public CInfoEquipementAlarmeAffichee InfoEquipement
        {
            get
            {
                AssureData();
                return m_InfoEquip;
            }
        }

        [DynamicField("Concerned Link Information")]
        public CInfoLiaiAlarmeAffichee InfoLiaison
        {
            get
            {
                AssureData();
                return m_InfoLiai;
            }
        }

        [DynamicField("Alarm access type information")]
        public CInfoAlarmeGereeAffichee AlarmeGeree
        {
            get
            {
                AssureData();
                return m_InfoAlarmGeree;
            }
        }

        [DynamicField("Severity Code")]
        public int SeverityCode
        {
            get
            {
                AssureData();
                return m_nGrave;
            }
        }

        [DynamicField("Severity")]
        public CGraviteAlarmeAvecMasquage Severity
        {
            get
            {
                AssureData();
                if (Enum.IsDefined(typeof(EGraviteAlarme), SeverityCode))
                {
                    try
                    {
                        return new CGraviteAlarmeAvecMasquage((EGraviteAlarmeAvecMasquage)SeverityCode);
                    }
                    catch
                    {
                    }
                }
                return null;              
            }
            
        }

        public bool AAcquitter
        {
            get
            {
                AssureData();
                return m_bAAcquitter;
            }
        }

        public bool EstAcquittee
        {
            get
            {
                AssureData();
                return m_bAcquittee;
            }
            set
            {
                m_bAcquittee = value;
            }
        }

        public DateTime? DateEffacement
        {
            get
            {
                return m_DateEffacement;
            }
            set
            {
                if (EstAcquittee || !AAcquitter)
                    m_DateEffacement = value;
            }
        }

        public bool PeutElleDisparaitre()
        {
            return (EstAcquittee || !AAcquitter) && m_DateEffacement != null && 
                    m_DateEffacement <= DateTime.Now;
        }
        
        public bool Commut
        {
            get
            {
                AssureData();
                return m_bCommut;
            }
        }
        public bool Sonne
        {
            get
            {
                AssureData();
                return m_bSonne;
            }
        } 
 
        [DynamicField("Managed element type")]
        public string ElementGereType
        {
            get
            {
                AssureData();
                if (InfoEquipement != null)
                    return InfoEquipement.TypeName;
                else if (InfoLiaison != null)
                    return InfoLiaison.TypeName;
                else if (InfoSite != null && InfoSite.Id > 0)
                    return InfoSite.TypeName;
                else
                    return "";
            }
        }

        [DynamicField("Managed element name")]
        public string ElementGereName
        {
            get
            {
                AssureData();
                if (InfoEquipement != null)
                    return InfoEquipement.Name;
                else if (InfoLiaison != null)
                    return InfoLiaison.Name;
                else if (InfoSite != null && InfoSite.Id > 0)
                    return InfoSite.Name;
                else
                    return "";
            }
        }

        [DynamicField("Concerned clients names")]
        public string ClientsConcerneName
        {
            get
            {
                AssureData();
                string str = "";
               
                foreach(CInfoClientAlarmeAffichee client in ClientsConcernes)
                {
                    if (client.Name.Length == 0)
                        continue;
                    str += client.Name;
                    str += m_subseparator;
                }
                
                if (str.Length > 0)
                    return str.Substring(0, str.Length - 1);
                else
                    return str;               
            }
        }

        [DynamicField("Concerned services names")]
        public string ServicesConcerneName
        {
            get
            {
                AssureData();
                string str="";
                foreach (CInfoServiceAlarmeAffichee prog in ServicesConcernes)
                {
                    if (prog.Name.Length == 0)
                        continue;
                    str += prog.Name;
                    str += m_subseparator;
                }
                if (str.Length > 0)
                    return str.Substring(0, str.Length - 1);
                else
                    return str;  
              
            }
        }

        [DynamicField("Concerned services states")]
        public string ServicesConcerneState
        {
            get
            {
                AssureData();
                string str ="";
                foreach (CInfoServiceAlarmeAffichee prog in ServicesConcernes)
                {
                    str += prog.EtatOper;
                    str += m_subseparator;
                }
                if (str.Length > 0)
                    return str.Substring(0, str.Length - 1);
                else
                    return str;  
            }
        }

        public int CodeAlarmeNature
        {
            get
            {
                return m_nTexte;
            }
        }

        [DynamicField("Start Alarm Id")]
        public Int32? StartAlarmId
        {
            get
            {
                return m_nIddeb;
            }
        }

        public bool WaiteToBeAcknowledged()
        {
            return (AAcquitter && !EstAcquittee);  
        }

        public object GetElementGere ( CContexteDonnee ctx )
        {
            if (InfoEquipement != null && InfoEquipement.Id >0)
                    return InfoEquipement.GetSpvEquip ( ctx );
                if ( InfoSite != null && InfoSite.Id > 0 )
                    return InfoSite.GetSpvSite ( ctx );
                if (InfoLiaison != null && InfoLiaison.Id > 0)
                    return InfoLiaison.GetSpvLiai ( ctx );
                return null;
        }

        public double GetEtatOperationnelService(int nIdService)
        {
            foreach (CInfoServiceAlarmeAffichee info in ServicesConcernes)
                if (info.Id == nIdService)
                    return info.EtatOper;
            return c_EtatOperOK;
        }     
    }
}
