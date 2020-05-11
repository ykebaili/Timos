using System;
using System.Collections.Generic;
using System.Text;
using sc2i.multitiers.client;
using timos.data;
using sc2i.data;
using sc2i.data.dynamic;
using sc2i.drawing;
using System.Drawing;
using timos.data.reseau.graphe;
using System.Timers;
using timos.data.reseau.arbre_operationnel;
using sc2i.common;
using futurocom.supervision;
using sc2i.common.memorydb;
using timos.data.snmp;

namespace timos.data.supervision.vueanimee
{
    //Base des alarmes en cours : contient toutes les alarmes en cours du système
    //Se charge de gérer les réceptions d'alarme. Dés qu'un changement intervient sur la base,
    //L'évenement OnChangeAlarmes est envoyé.
    public delegate void RefreshVueSupervisionDelegate(List<int> idsElementsDeSchema);
    public class CBasePourVueAnimee : IDisposable
    {
        private static CInfoRelation m_relationFromLienAlarmeToLienAlarmeRep = null;
        public delegate void OnChangementDansBaseAlarmeEventHandler(object sender, List<CInfoElementDeSchemaSupervise> elementsConcernes);

        private CContexteDonnee m_contexteDonnee = null;
        private CMemoryDb m_database = new CMemoryDb();
        private int m_nNiveauMasquageMaxAffcihe = 0;

        private Timer m_timerRefresh = new Timer(150);
        
        CRecepteurNotification m_recepteurNotifications;
        /// <summary>
        /// Dictionnaire allant de l'id de l'alarme vers les infos de cette alarme
        /// </summary>
        private Dictionary<string, CLocalAlarme> m_dicAlarmes = new Dictionary<string, CLocalAlarme>();

        private Dictionary<string, List<CInfoElementDeSchemaSupervise>> m_dicAlarmeToElementsConcernes = new Dictionary<string, List<CInfoElementDeSchemaSupervise>>();

        // Elements directement concernés par un objet
        private CDictionnaireConcerne m_dicDirectementConcernesParEquipement = new CDictionnaireConcerne();
        private CDictionnaireConcerne m_dicDirectementConcernesParSite = new CDictionnaireConcerne();
        private CDictionnaireConcerne m_dicDirectementConcernesParLiaison = new CDictionnaireConcerne();
        private CDictionnaireConcerne m_dicDirectementConcernesParServices = new CDictionnaireConcerne();
        private CDictionnaireConcerne m_dicDirectementConcernesParEntiteSnmp = new CDictionnaireConcerne();


        // Les noeuds d'arbre opérationnels relatifs à un élement
        private CDictionnaireElementToNoeudArbre m_dicEquipementToNoeudArbreOp = new CDictionnaireElementToNoeudArbre();
        private CDictionnaireElementToNoeudArbre m_dicSiteToNoeudArbreOp = new CDictionnaireElementToNoeudArbre();
        private CDictionnaireElementToNoeudArbre m_dicLiaisonToNoeudArbreOp = new CDictionnaireElementToNoeudArbre();
        private CDictionnaireElementToNoeudArbre m_dicServiceToNoeudArbreOp = new CDictionnaireElementToNoeudArbre();

        private Dictionary<CElementDeArbreOperationnel, CInfoElementDeSchemaSupervise> m_dicNoeudArbreRacineToInfoElement = new Dictionary<CElementDeArbreOperationnel, CInfoElementDeSchemaSupervise>();


        /// <summary>
        /// Info racine du schéma supervisé
        /// </summary>
        private CInfoSchemaDeSchemaSupervise m_infoSchemaRacine = null;

        //Base de graphes (pour ne pas les recalculer tout le temps)
        private CBaseGraphesReseau m_baseGraphes = new CBaseGraphesReseau();

        //IdElementDeSchemaReseau->CInfoElementDeSchemaSupervise
        private Dictionary<int, CInfoElementDeSchemaSupervise> m_dicElementDeSchemaToInfoSupervision = new Dictionary<int, CInfoElementDeSchemaSupervise>();

        private Image m_imageConnexionOk = null;
        private Image m_imageConnexionHS = null;

        //Liste des éléments à redessiner lors d'un refresh
        private Dictionary<int, bool> m_dicChangesDepuisDernierRefresh = new Dictionary<int, bool>();


        //----------------------------------------------------------------------------------------------
        public CBasePourVueAnimee(CContexteDonnee contexteDonnee, bool bAvecNotifications)
        {
            if ( bAvecNotifications )
            {
                m_recepteurNotifications = new CRecepteurNotification(contexteDonnee.IdSession, typeof(CNotificationModificationsAlarme));
                m_recepteurNotifications.OnReceiveNotification +=new NotificationEventHandler(m_recepteurAlarme_Notification);
            }
            m_contexteDonnee = contexteDonnee;
            m_baseGraphes = new CBaseGraphesReseau();

            m_timerRefresh.Elapsed += new ElapsedEventHandler(m_timerRefresh_Elapsed);
        }

        public delegate void AfterLoadElementDelegate(int nIdElementDeSchema);

        public AfterLoadElementDelegate AfterLoadElement;

        //----------------------------------------------------------------------------------------------
        public void SetInfoPourElementDeSchema(CInfoElementDeSchemaSupervise info, int nIdElementDeSchema)
        {
            m_dicElementDeSchemaToInfoSupervision[nIdElementDeSchema] = info;
            if (AfterLoadElement != null)
                AfterLoadElement(nIdElementDeSchema);
        }

        public CContexteDonnee ContexteDonnee
        {
            get
            {
                return m_contexteDonnee;
            }
        }

        public CMemoryDb DataBase
        {
            get
            {
                return m_database;
            }
        }

        public CBaseGraphesReseau BaseGraphes
        {
            get
            {
                return m_baseGraphes;
            }
        }

        private bool m_bIsDisposed = false;
        //----------------------------------------------------------------------------------------------
        public void Dispose()
        {
            m_bIsDisposed = true;
 	        if ( m_recepteurNotifications != null )
                m_recepteurNotifications.Dispose();
            m_recepteurNotifications = null;
            if (m_imageConnexionHS != null)
                m_imageConnexionHS.Dispose();
            if (m_imageConnexionOk != null)
                m_imageConnexionOk.Dispose();
            m_imageConnexionHS = null;
            m_imageConnexionOk = null;
            if (m_timerRefresh != null)
            {
                m_timerRefresh.Stop();
                m_timerRefresh.Dispose();
            }
        }

        //----------------------------------------------------------------------------------------------
        public Image GetImageIsOperationnel(bool bIsOperationnel)
        {

            if (bIsOperationnel)
            {
                if (m_imageConnexionOk == null)
                    m_imageConnexionOk = timos.data.Resource.Connection_Check;
                return m_imageConnexionOk;
            }
            else
            {
                if (m_imageConnexionHS == null)
                    m_imageConnexionHS = timos.data.Resource.Connection_Disabled;
                return m_imageConnexionHS;
            }
        }

        //----------------------------------------------------------------------------------------------
        public Image GetImageEtatOperationnel(EEtatOperationnelSchema etat)
        {

            switch (etat)
            {
                case EEtatOperationnelSchema.HS:
                    return timos.data.Resource.Connection_Disabled;
                case EEtatOperationnelSchema.Degrade:
                    return timos.data.Resource.Connection_warning;
                case EEtatOperationnelSchema.OK:
                    return timos.data.Resource.Connection_Check;
                default:
                    return timos.data.Resource.Connection_Check;
                    
            }
           
        }


        //----------------------------------------------------------------------------------------------
        // Réception des notifications d'alarmes ici
        void m_recepteurAlarme_Notification(IDonneeNotification donnee)
        {
            CNotificationModificationsAlarme notificationAlarme = donnee as CNotificationModificationsAlarme;
            if (notificationAlarme == null)
                return;

            CListeEntitesDeMemoryDb<CLocalAlarme> lstAlarmes = new CListeEntitesDeMemoryDb<CLocalAlarme>(notificationAlarme.MemoryDb);

            foreach (CLocalAlarme alarme in lstAlarmes)
            {
                if (alarme.Childs.Count() == 0)
                {
                    if (alarme.DateFin == null)
                        StartAlarme(alarme);
                    else
                        StopAlarme(alarme);
                }
            }

            /*
            CEvenementAlarm[] lstAlarmes = donneeAlarme.Alarmes;
            foreach (CEvenementAlarm evAlarme in lstAlarmes)
            {
                if (evAlarme is CEvenementAlarmStartStop)
                {
                    CEvenementAlarmStartStop evtAlarmStartStop = (CEvenementAlarmStartStop)evAlarme;
                    if (evtAlarmStartStop.Gravite == EGraviteAlarmeAvecMasquage.EndAlarm)
                    {
                        if (evtAlarmStartStop.IdAlarmData > 0)
                        {
                            int nIdAlarmeData = evtAlarmStartStop.IdAlarmData;
                            StopAlarme(nIdAlarmeData);
                        }
                    }
                    else
                        StartAlarme(new CInfoAlarmeAffichee(evtAlarmStartStop));
                }
                else if (evAlarme is CEvenementAlarmMasqueeParUneAutre)
                {
                    CEvenementAlarmMasqueeParUneAutre evenementAlarm =
                        (CEvenementAlarmMasqueeParUneAutre)evAlarme;

                    //if (evenementAlarm.AlarmStartId > 0)
                    //    StopAlarme(evenementAlarm.AlarmStartId);
                    if (evenementAlarm.IdAlarmeData> 0)
                        StopAlarme(evenementAlarm.IdAlarmeData);
                }
                else if (evAlarme is CEvenementAlarmMask)
                {
                    CEvenementAlarmMask evenementAlarm = (CEvenementAlarmMask)evAlarme;
                    if (evenementAlarm.IdLienAccesAlarme > 0)
                        MaskAlarme(evenementAlarm);
                }


            }*/
            List<CInfoElementDeSchemaSupervise> lstConcernes = new List<CInfoElementDeSchemaSupervise>();
            OnChangementDansLaBase(lstConcernes);
        }

        public RefreshVueSupervisionDelegate RefreshVueSupervision;

        class CLockerRefresh{}
        //----------------------------------------------------------------------------------------------
        private void Refresh()
        {
            if (m_bIsDisposed)
                return;
            m_timerRefresh.Stop();
            List<int> lstToRefresh = new List<int>();
            lock ( typeof(CLockerRefresh) )
            {
                lstToRefresh.AddRange(m_dicChangesDepuisDernierRefresh.Keys);
                m_dicChangesDepuisDernierRefresh = new Dictionary<int, bool>();
            }
            if (RefreshVueSupervision != null)
                RefreshVueSupervision(lstToRefresh);
        }

        //----------------------------------------------------------------------------------------------
        private void DelayRefresh()
        {
            if (m_bIsDisposed)
                return;
            m_timerRefresh.Stop();
            m_timerRefresh.Start();
        }

        //----------------------------------------------------------------------------------------------
        void m_timerRefresh_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (m_bIsDisposed)
                return;
            m_timerRefresh.Stop();
 	        Refresh();
        }

        //----------------------------------------------------------------------------------------------
        public void OnChangementEtatSupervise(CInfoElementDeSchemaSupervise info)
        {
            lock ( typeof(CLockerRefresh) )
            {
                if  (info.IdElementDeSchema != null )
                    m_dicChangesDepuisDernierRefresh[info.IdElementDeSchema.Value] = true;
            }
        }

        //----------------------------------------------------------------------------------------------
        private void StopAlarme(CLocalAlarme alarme)
        {
            // Traitement de l'état opérationnel des schémas
            List<CElementDeArbreOperationnel> listeNoeudsConcernes = new List<CElementDeArbreOperationnel>();
            if (alarme.EquipementId != null)
            {
                m_dicEquipementToNoeudArbreOp.TryGetValue(alarme.EquipementId, out listeNoeudsConcernes);
            }
            else if (alarme.SiteId != null)
            {
                m_dicSiteToNoeudArbreOp.TryGetValue(alarme.SiteId, out listeNoeudsConcernes);
            }
            else if (alarme.LienId != null)
            {
                m_dicLiaisonToNoeudArbreOp.TryGetValue(alarme.LienId, out listeNoeudsConcernes);
            }

            // Passe tous les coef opérationnels à 1 = OK
            PropageCoefOperationnel(listeNoeudsConcernes, 1.0);


            List<CInfoElementDeSchemaSupervise> lst = null;
            if (m_dicAlarmeToElementsConcernes.TryGetValue(alarme.Id, out lst))
            {
                List<CInfoElementDeSchemaSupervise> lstAPrevenir = new List<CInfoElementDeSchemaSupervise>(lst);
                while (lstAPrevenir.Count != 0)
                {
                    lstAPrevenir.Sort();
                    CInfoElementDeSchemaSupervise[] infos = lstAPrevenir.ToArray();
                    lstAPrevenir.Clear();
                    foreach (CInfoElementDeSchemaSupervise info in infos)
                    {
                        info.StopAlarme(alarme.Id);
                        CInfoElementDeSchemaSupervise parent = info.Parent;
                        if (parent != null)
                            lstAPrevenir.Add(parent);
                    }
                }
            }

            if (lst != null && lst.Count > 0)
                Refresh();

        }

        //----------------------------------------------------------------------------------------------
        private void StartAlarme(CLocalAlarme infoAlarme)
        {
            m_dicAlarmes[infoAlarme.Id] = infoAlarme;

            // Traitement de l'état opérationnel des schémas
            List<CElementDeArbreOperationnel> listeNoeudsConcernes = new List<CElementDeArbreOperationnel>();
            if (infoAlarme.EquipementId != null)
            {
                m_dicEquipementToNoeudArbreOp.TryGetValue(infoAlarme.EquipementId, out listeNoeudsConcernes);
            }
            else if (infoAlarme.SiteId != null)
            {
                m_dicSiteToNoeudArbreOp.TryGetValue(infoAlarme.SiteId, out listeNoeudsConcernes);
            }
            else if (infoAlarme.LienId != null)
            {
                m_dicLiaisonToNoeudArbreOp.TryGetValue(infoAlarme.LienId, out listeNoeudsConcernes);
            }

            if (infoAlarme.MasquageApplique == null || infoAlarme.MasquageHerite.Priorite <= this.NiveauMasquageMaxAffiche)
                PropageCoefOperationnel(listeNoeudsConcernes, infoAlarme.IsHS ? 0 : 0.5);
            else
                PropageCoefOperationnel(listeNoeudsConcernes, 1);


            List<CInfoElementDeSchemaSupervise> lstConcernes = new List<CInfoElementDeSchemaSupervise>();
            List<CInfoElementDeSchemaSupervise> lst = null;
            if (infoAlarme.EquipementId != null)
            {
                m_dicDirectementConcernesParEquipement.TryGetValue(infoAlarme.EquipementId, out lst);
                if (lst != null)
                    lstConcernes.AddRange(lst);
            }
            if (infoAlarme.LienId != null)
            {
                m_dicDirectementConcernesParLiaison.TryGetValue(infoAlarme.LienId, out lst);
                if (lst != null)
                    lstConcernes.AddRange(lst);
            }
            if (infoAlarme.EntiteSnmpId != null)
            {
                m_dicDirectementConcernesParEntiteSnmp.TryGetValue(infoAlarme.EntiteSnmpId, out lst);
                if(lst != null)
                    lstConcernes.AddRange(lst);
            }
            if (infoAlarme.SiteId != null && infoAlarme.EquipementId == null && infoAlarme.EntiteSnmpId == null)
            {
                m_dicDirectementConcernesParSite.TryGetValue(infoAlarme.SiteId, out lst);
                if (lst != null)
                    lstConcernes.AddRange(lst);
            }

            Dictionary<CInfoElementDeSchemaSupervise, bool> dicConcernes = new Dictionary<CInfoElementDeSchemaSupervise,bool>();
            if (lstConcernes != null)
            {
                List<CInfoElementDeSchemaSupervise> lstAPrevenir = new List<CInfoElementDeSchemaSupervise>(lstConcernes);
                bool bFirstNiveau = true;
                while (lstAPrevenir.Count != 0)
                {
                    lstAPrevenir.Sort();
                    CInfoElementDeSchemaSupervise[] infos = lstAPrevenir.ToArray();
                    lstAPrevenir.Clear();
                    foreach (CInfoElementDeSchemaSupervise info in infos)
                    {
                        if ( bFirstNiveau )
                            dicConcernes[info] = true;
                        info.StartAlarme(infoAlarme, !bFirstNiveau);
                        CInfoElementDeSchemaSupervise parent = info.Parent;
                        if (parent != null)
                            lstAPrevenir.Add(parent);
                    }
                    bFirstNiveau = false;
                }
                if (lstConcernes.Count > 0)
                    Refresh();
            }
            lst = new List<CInfoElementDeSchemaSupervise>();
            lst.AddRange ( dicConcernes.Keys );
            m_dicAlarmeToElementsConcernes[infoAlarme.Id] = lst;


        }

        private void PropageCoefOperationnel(List<CElementDeArbreOperationnel> listeNoeudsConcernes, double fCoef)
        {
            // Passe tous les coef opérationnels à 0 = HS
            if (listeNoeudsConcernes != null)
                foreach (CElementDeArbreOperationnel node in listeNoeudsConcernes)
                {
                    node.SetCoeffOperationnel(fCoef);
                    node.RecalculeCoefOperationnelFromChilds();
                    CElementDeArbreOperationnel nodeParent = node;
                    while (nodeParent.ElementParent != null)
                    {
                        nodeParent = nodeParent.ElementParent;
                    }
                    
                    CInfoElementDeSchemaSupervise info = null;
                    if (m_dicNoeudArbreRacineToInfoElement.TryGetValue(nodeParent, out info))
                    {
                        if (info is CInfoEquipementDeSchemaSupervise)
                        {
                            m_dicEquipementToNoeudArbreOp.TryGetValue(((CInfoEquipementDeSchemaSupervise)info).IdEquipement, out listeNoeudsConcernes);
                        }
                        else if (info is CInfoSiteDeSchemaSupervise)
                        {
                            m_dicSiteToNoeudArbreOp.TryGetValue(((CInfoSiteDeSchemaSupervise)info).IdSite, out listeNoeudsConcernes);
                        }
                        else if (info is CInfoLienDeSchemaSupervise)
                        {
                            m_dicLiaisonToNoeudArbreOp.TryGetValue(((CInfoLienDeSchemaSupervise)info).IdLien, out listeNoeudsConcernes);
                        }
                        else if (info is CInfoSchemaDeSchemaSupervise)
                        {
                            m_dicServiceToNoeudArbreOp.TryGetValue(((CInfoSchemaDeSchemaSupervise)info).IdSchema, out listeNoeudsConcernes);
                        }

                        if(listeNoeudsConcernes != null)
                            PropageCoefOperationnel(listeNoeudsConcernes, fCoef);
                    }

                }
        }
        /*
        //----------------------------------------------------------------------------------------------
        private void MaskAlarme(CEvenementAlarmMask evenement)
        {
            if (evenement.IdLienAccesAlarme <= 0 || evenement.DetailMasquage == null)
                return;
            CDictionnaireConcerne dic = null;
            int nIdElement = 0;
            if (evenement.IdSite != null)
            {
                nIdElement = evenement.IdSite.Value;
                dic = m_dicDirectementConcernesParSite;
            }
            if (evenement.IdEquipement != null)
            {
                nIdElement = evenement.IdEquipement.Value;
                dic = m_dicDirectementConcernesParEquipement;
            }
            if (evenement.IdLiaison != null)
            {
                nIdElement = evenement.IdLiaison.Value;
                dic = m_dicDirectementConcernesParLiaison;
            }
            List<CInfoElementDeSchemaSupervise> lst = null;
            EGraviteAlarmeAvecMasquage gravite = (EGraviteAlarmeAvecMasquage)evenement.NiveauMasquage;
            if (dic.TryGetValue((int)nIdElement, out lst))
            {
                List<CInfoElementDeSchemaSupervise> lstAPrevenir = new List<CInfoElementDeSchemaSupervise>(lst);
                while (lstAPrevenir.Count != 0)
                {
                    lstAPrevenir.Sort();
                    CInfoElementDeSchemaSupervise[] infos = lstAPrevenir.ToArray();
                    lstAPrevenir.Clear();
                    foreach (CInfoElementDeSchemaSupervise info in infos)
                    {
                        switch ( evenement.DetailMasquage )
                        {
                            case EEvenementMasquage.DebutMasquageAdministrateur :
                                info.SetMasquageAdministrateur ( evenement.IdLienAccesAlarme, true );
                                break;
                            case EEvenementMasquage.FinMasquageAdministrateur:
                                info.SetMasquageAdministrateur ( evenement.IdLienAccesAlarme, false );
                                break;
                            case EEvenementMasquage.DebutMasquageBrigadier :
                                info.SetMasquageBrigadier ( evenement.IdLienAccesAlarme, true );
                                break;
                            case EEvenementMasquage.FinMasquageBrigadier :
                                info.SetMasquageBrigadier ( evenement.IdLienAccesAlarme, false );
                                break;
                        }
                        CInfoElementDeSchemaSupervise parent = info.Parent;
                        if (parent != null)
                            lstAPrevenir.Add(parent);
                    }
                }
                if (lst.Count != 0 && m_infoSchemaRacine != null)
                {
                    List<CInfoElementDeSchemaSupervise> lstModifs = new List<CInfoElementDeSchemaSupervise>();
                    m_infoSchemaRacine.RecalculeToutLeMasquage(lstModifs);
                    lock (typeof(CLockerRefresh))
                    {
                        foreach (CInfoElementDeSchemaSupervise info in lstModifs)
                        {
                            if (info.IdElementDeSchema != null)
                                m_dicChangesDepuisDernierRefresh[info.IdElementDeSchema.Value] = true;
                        }
                    }
                    Refresh();
                }

            }
        }
        */
        public event OnChangementDansBaseAlarmeEventHandler OnChangementDansLaBaseEvent;
        private void OnChangementDansLaBase(List<CInfoElementDeSchemaSupervise> lstConcernes)
        {
            if (OnChangementDansLaBaseEvent != null)
                OnChangementDansLaBaseEvent(this, lstConcernes);
        }

        public static List<CReferenceObjetDonnee>GetTousLesConcernes ( CSchemaReseau schema )
        {
            CBasePourVueAnimee basePourVue = new CBasePourVueAnimee ( schema.ContexteDonnee, false );
            basePourVue.TrouveLesConcernes ( schema );
            List<CReferenceObjetDonnee> lst = new List<CReferenceObjetDonnee>();
            basePourVue.FillListeConcernes(basePourVue.m_infoSchemaRacine, lst);
            return lst;
        }

        private void FillListeConcernes(CInfoElementDeSchemaSupervise info, List<CReferenceObjetDonnee> lst)
        {
            CReferenceObjetDonnee reference = info.GetReferenceObjetAssocie();
            if (reference != null)
                lst.Add(reference);
            foreach (CInfoElementDeSchemaSupervise infoFils in info.ListeFils)
            {
                FillListeConcernes(infoFils, lst);
            }
        }




        // Point d'entrée principal
        public void InitForSupervision(CSchemaReseau schema)
        {
            TrouveLesConcernes(schema);
            RempliLesDicsNoeuds();

            LoadAlarmesForElement ( CSite.c_champId, m_dicDirectementConcernesParSite );
            LoadAlarmesForElement ( CLienReseau.c_champId, m_dicDirectementConcernesParLiaison );
            LoadAlarmesForElement ( CEquipementLogique.c_champId, m_dicDirectementConcernesParEquipement );
            LoadAlarmesForElement(CEntiteSnmp.c_champId, m_dicDirectementConcernesParEntiteSnmp);

            
        }

        private void TrouveLesConcernes(CSchemaReseau schema)
        {
            m_infoSchemaRacine = new CInfoSchemaDeSchemaSupervise(null, null, this, 0);
            m_infoSchemaRacine.InitFromSchema(schema);

            m_dicDirectementConcernesParEquipement.Clear();
            m_dicDirectementConcernesParLiaison.Clear();
            m_dicDirectementConcernesParSite.Clear();
            m_dicDirectementConcernesParEntiteSnmp.Clear();
            m_dicDirectementConcernesParServices.Clear();

            m_infoSchemaRacine.FillDicsConcernes(
                m_dicDirectementConcernesParSite,
                m_dicDirectementConcernesParLiaison,
                m_dicDirectementConcernesParEquipement,
                m_dicDirectementConcernesParEntiteSnmp,
                m_dicDirectementConcernesParServices);
        }

        private void RempliLesDicsNoeuds()
        {
            
            m_dicEquipementToNoeudArbreOp.Clear();
            m_dicSiteToNoeudArbreOp.Clear(); 
            m_dicLiaisonToNoeudArbreOp.Clear();
            m_dicServiceToNoeudArbreOp.Clear();

            m_dicNoeudArbreRacineToInfoElement.Clear();

            if (m_infoSchemaRacine != null)
            {
                m_infoSchemaRacine.FillDicsElementToNoeudsArbre(
                    m_dicEquipementToNoeudArbreOp,
                    m_dicSiteToNoeudArbreOp,
                    m_dicLiaisonToNoeudArbreOp,
                    m_dicServiceToNoeudArbreOp);

                m_infoSchemaRacine.FillDicNoeudArbreRacineToInfoElement(
                    m_dicNoeudArbreRacineToInfoElement);
            }
        }


        //Initialise la base des alarmes en cours avec les alarmes de la base 
        private void LoadAlarmesForElement(string strChampDansAlarme, CDictionnaireConcerne dicConcernes)
        {
            List<CDbKey> lstKeysElements = new List<CDbKey>();
            lstKeysElements.AddRange(dicConcernes.Keys);
            int nSizePaquet = 100;
            for (int nPaquet = 0; nPaquet < lstKeysElements.Count; nPaquet += nSizePaquet)
            {
                int nMax = Math.Min(nPaquet + nSizePaquet, lstKeysElements.Count);
                StringBuilder bl = new StringBuilder();
                for (int nId = 0; nId < nMax; nId++)
			{
                bl.Append(lstKeysElements[nId]);
                    bl.Append(',');
                }
                if ( bl.Length > 0 )
                {
                    bl.Remove ( bl.Length-1,1 );
                    //Charge tous les Liens d'alarme pour les éléments
                    CListeObjetsDonnees lstAlarmes = new CListeObjetsDonnees(m_contexteDonnee, typeof(CAlarme));
                    lstAlarmes.Filtre = new CFiltreData ( strChampDansAlarme+" in ("+
                        bl.ToString()+") and "+
                        CAlarme.c_champDateFin +" is null" );

                    lstAlarmes.AssureLectureFaite();

                    //CMemoryDb database =  new CMemoryDb();

                    foreach (CAlarme alarme in lstAlarmes)
                    {
                        if (alarme != null && alarme.AlarmesFilles.Count == 0)
                        {
                            CLocalAlarme locAlrm = alarme.GetLocalAlarme(m_database, true);
                            //m_dicAlarmes[info.IdSpvEvtAlarme] = info;
                            m_dicAlarmes[locAlrm.Id] = locAlrm;
                            StartAlarme(locAlrm);
                        }
                    }

                    /*
                    foreach ( CSpvLienAccesAlarme lienAlarme in lstAlarmes )
                    {
                        CSpvAcces acces = lienAlarme.AccesAlarmeOne;
                        if ( acces != null )
                        {
                            int? nId = acces.Row[strChampDansAcces] as int?;
                            if (nId != null)
                            {
                                List<CInfoElementDeSchemaSupervise> lst = null;
                                if (dicConcernes.TryGetValue(nId.Value, out lst))
                                {
                                    foreach (CInfoElementDeSchemaSupervise info in lst)
                                    {
                                        info.SetConcerneParAlarmes();
                                        if (lienAlarme.MaskAdminDateMin != null && lienAlarme.MaskBriDateMin > DateTime.Now)
                                        {
                                            if (lienAlarme.MaskAdminDateMax == null || lienAlarme.MaskAdminDateMax < DateTime.Now)
                                                info.SetMasquageAdministrateur(lienAlarme.Id, true);
                                        }
                                        if (lienAlarme.MaskBriDateMin != null && lienAlarme.MaskBriDateMin > DateTime.Now)
                                            if (lienAlarme.MaskBriDateMax == null || lienAlarme.MaskBriDateMax < DateTime.Now)
                                                info.SetMasquageBrigadier(lienAlarme.Id, true);
                                    }
                                }
                            }
                        }
                    }*/
                    /*if (m_infoSchemaRacine != null)
                    {
                        List<CInfoElementDeSchemaSupervise> lstTmp = new List<CInfoElementDeSchemaSupervise>();
                        m_infoSchemaRacine.RecalculeToutLeMasquage(lstTmp);
                    }*/
                }
            }
        }

        public bool DoDessinSupplementaireBefore ( CContextDessinObjetGraphique ctx, C2iObjetGraphique objet )
        {
            C2iLienDeSchemaReseau dessinLien = objet as C2iLienDeSchemaReseau;
            if ( dessinLien == null )//Optim : seuls les liens sont dessinés avant. Pour le moment, les autres non
                return true;
            //Dessine sous les segments
            CInfoElementDeSchemaSupervise infoSupervision = null;
            if (!m_dicElementDeSchemaToInfoSupervision.TryGetValue(dessinLien.ElementDeSchema.Id, out infoSupervision))
                return true;
            infoSupervision.BeforeDrawObjet(ctx, dessinLien);
            
            return true;
        }

        public bool DoDessinSupplementaireAfter(CContextDessinObjetGraphique ctx, C2iObjetGraphique objet)
        {
            
            C2iObjetDeSchema objetDeSchema = objet as C2iObjetDeSchema;
            if (objetDeSchema == null || objetDeSchema.ElementDeSchema == null)
                return true;
            CInfoElementDeSchemaSupervise infoSupervision = null;
            if (!m_dicElementDeSchemaToInfoSupervision.TryGetValue(objetDeSchema.ElementDeSchema.Id, out infoSupervision))
                return true;
            infoSupervision.AfterDrawObjet(ctx, objetDeSchema);
            return true;
        }

        public List<CLocalAlarme> GetAlarmesPourElement(CElementDeSchemaReseau element)
        {
            List<CLocalAlarme> lst = new List<CLocalAlarme>();
            CInfoElementDeSchemaSupervise info = null;
            if (m_dicElementDeSchemaToInfoSupervision.TryGetValue(element.Id, out info))
            {
                foreach (string strId in info.GetIdsAlarmesEnCours())
                {
                    CLocalAlarme alarme = null;
                    if (m_dicAlarmes.TryGetValue(strId, out alarme))
                        lst.Add(alarme);
                }
            }
            return lst;
        }


        public int NiveauMasquageMaxAffiche
        {
            get
            {
                return m_nNiveauMasquageMaxAffcihe;
            }
            set
            {
                m_nNiveauMasquageMaxAffcihe = value;
            }
        }

        

    }
}

