using System;
using System.Collections.Generic;
using System.Text;
using spv.data.ConsultationAlarmes;
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

namespace spv.data.VueAnimee
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

        private Timer m_timerRefresh = new Timer(150);
        
        CRecepteurNotification m_recepteurNotifications;
        /// <summary>
        /// Dictionnaire allant de l'id de l'alarme vers les infos de cette alarme
        /// </summary>
        private Dictionary<int, CInfoAlarmeAffichee> m_dicAlarmes = new Dictionary<int, CInfoAlarmeAffichee>();

        private Dictionary<int, List<CInfoElementDeSchemaSupervise>> m_dicAlarmeToElementsConcernes = new Dictionary<int, List<CInfoElementDeSchemaSupervise>>();

        // Elements directement concernés par un objet SPV
        private CDictionnaireConcerne m_dicDirectementConcernesParEquipement = new CDictionnaireConcerne();
        private CDictionnaireConcerne m_dicDirectementConcernesParSite = new CDictionnaireConcerne();
        private CDictionnaireConcerne m_dicDirectementConcernesParLiaison = new CDictionnaireConcerne();
        private CDictionnaireConcerne m_dicDirectementConcernesParServices = new CDictionnaireConcerne();


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
                m_recepteurNotifications = new CRecepteurNotification(contexteDonnee.IdSession, typeof(CDonneeNotificationAlarmes));
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
                    m_imageConnexionOk = SpvDataResource.Connection_Check;
                return m_imageConnexionOk;
            }
            else
            {
                if (m_imageConnexionHS == null)
                    m_imageConnexionHS = SpvDataResource.Connection_Disabled;
                return m_imageConnexionHS;
            }
        }

        //----------------------------------------------------------------------------------------------
        public Image GetImageEtatOperationnel(EEtatOperationnelSchema etat)
        {

            switch (etat)
            {
                case EEtatOperationnelSchema.HS:
                    return SpvDataResource.Connection_Disabled;
                case EEtatOperationnelSchema.Degrade:
                    return SpvDataResource.Connection_warning;
                case EEtatOperationnelSchema.OK:
                    return SpvDataResource.Connection_Check;
                default:
                    return SpvDataResource.Connection_Check;
                    
            }
           
        }


        //----------------------------------------------------------------------------------------------
        // Réception des notifications d'alarmes ici
        void m_recepteurAlarme_Notification(IDonneeNotification donnee)
        {
            CDonneeNotificationAlarmes donneeAlarme = donnee as CDonneeNotificationAlarmes;
            if (donneeAlarme == null)
                return;

            
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


            }
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
        private void StopAlarme(int? nIdAlarme)
        {
            if (nIdAlarme == null)
                return;

            // Traitement de l'état opérationnel des schémas
            CSpvAlarmeDonnee alarmeData = new CSpvAlarmeDonnee(ContexteDonnee);
            if (alarmeData.ReadIfExists(nIdAlarme.Value))
            {
                List<CElementDeArbreOperationnel> listeNoeudsConcernes = new List<CElementDeArbreOperationnel>();
                if (alarmeData.EquipId != null)
                {
                    m_dicEquipementToNoeudArbreOp.TryGetValue(alarmeData.EquipId.Value, out listeNoeudsConcernes);
                }
                else if (alarmeData.SiteId != null)
                {
                    m_dicSiteToNoeudArbreOp.TryGetValue(alarmeData.SiteId.Value, out listeNoeudsConcernes);
                }
                else if (alarmeData.LiaiId != null)
                {
                    m_dicLiaisonToNoeudArbreOp.TryGetValue(alarmeData.LiaiId.Value, out listeNoeudsConcernes);
                }

                // Passe tous les coef opérationnels à 1 = OK
                PropageCoefOperationnel(listeNoeudsConcernes, 1.0);

            }


            List<CInfoElementDeSchemaSupervise> lst = null;
            if (m_dicAlarmeToElementsConcernes.TryGetValue((int)nIdAlarme, out lst))
            {
                List<CInfoElementDeSchemaSupervise> lstAPrevenir = new List<CInfoElementDeSchemaSupervise>(lst);
                while (lstAPrevenir.Count != 0)
                {
                    lstAPrevenir.Sort();
                    CInfoElementDeSchemaSupervise[] infos = lstAPrevenir.ToArray();
                    lstAPrevenir.Clear();
                    foreach (CInfoElementDeSchemaSupervise info in infos)
                    {
                        info.StopAlarme(nIdAlarme.Value);
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
        private void StartAlarme(CInfoAlarmeAffichee infoAlarme)
        {
            //int nIdAlarme = infoAlarme.IdSpvEvtAlarme;
            int nIdAlarmeData = infoAlarme.IdSpvAlarmeData;
            
            m_dicAlarmes[nIdAlarmeData] = infoAlarme;

            // Traitement de l'état opérationnel des schémas
            CSpvAlarmeDonnee alarmeData = new CSpvAlarmeDonnee(ContexteDonnee);
            if (infoAlarme.SeverityCode >= (int)EGraviteAlarme.Major &&
                alarmeData.ReadIfExists(nIdAlarmeData))
            {
                List<CElementDeArbreOperationnel> listeNoeudsConcernes = new List<CElementDeArbreOperationnel>();
                if (alarmeData.EquipId != null)
                {
                    m_dicEquipementToNoeudArbreOp.TryGetValue(alarmeData.EquipId.Value, out listeNoeudsConcernes);
                }
                else if (alarmeData.SiteId != null)
                {
                    m_dicSiteToNoeudArbreOp.TryGetValue(alarmeData.SiteId.Value, out listeNoeudsConcernes);
                }
                else if (alarmeData.LiaiId != null)
                {
                    m_dicLiaisonToNoeudArbreOp.TryGetValue(alarmeData.LiaiId.Value, out listeNoeudsConcernes);
                }

                PropageCoefOperationnel(listeNoeudsConcernes, 0.0);
            }


            List<CInfoElementDeSchemaSupervise> lstConcernes = null;
            if (infoAlarme.InfoEquipement != null)
                m_dicDirectementConcernesParEquipement.TryGetValue(infoAlarme.InfoEquipement.Id, out lstConcernes);
            if (infoAlarme.InfoLiaison != null)
                m_dicDirectementConcernesParLiaison.TryGetValue(infoAlarme.InfoLiaison.Id, out lstConcernes);
            if (infoAlarme.InfoSite != null && infoAlarme.InfoSite.Id != null)
                m_dicDirectementConcernesParSite.TryGetValue(infoAlarme.InfoSite.Id.Value, out lstConcernes);
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
                        info.StartAlarme(infoAlarme, false);
                        CInfoElementDeSchemaSupervise parent = info.Parent;
                        if (parent != null)
                            lstAPrevenir.Add(parent);
                    }
                    bFirstNiveau = false;
                }
                if (lstConcernes.Count > 0)
                    Refresh();
            }
            List<CInfoElementDeSchemaSupervise> lst = new List<CInfoElementDeSchemaSupervise>();
            lst.AddRange ( dicConcernes.Keys );
            m_dicAlarmeToElementsConcernes[nIdAlarmeData] = lst;


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
                            m_dicEquipementToNoeudArbreOp.TryGetValue(((CInfoEquipementDeSchemaSupervise)info).IdEquipementSpv.Value, out listeNoeudsConcernes);
                        }
                        else if (info is CInfoSiteDeSchemaSupervise)
                        {
                            m_dicSiteToNoeudArbreOp.TryGetValue(((CInfoSiteDeSchemaSupervise)info).IdSiteSpv.Value, out listeNoeudsConcernes);
                        }
                        else if (info is CInfoLienDeSchemaSupervise)
                        {
                            m_dicLiaisonToNoeudArbreOp.TryGetValue(((CInfoLienDeSchemaSupervise)info).IdLienSpv.Value, out listeNoeudsConcernes);
                        }
                        else if (info is CInfoSchemaDeSchemaSupervise)
                        {
                            m_dicServiceToNoeudArbreOp.TryGetValue(((CInfoSchemaDeSchemaSupervise)info).IdSchemaSpv, out listeNoeudsConcernes);
                        }

                        if(listeNoeudsConcernes != null)
                            PropageCoefOperationnel(listeNoeudsConcernes, fCoef);
                    }

                }
        }

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

        public event OnChangementDansBaseAlarmeEventHandler OnChangementDansLaBaseEvent;
        private void OnChangementDansLaBase(List<CInfoElementDeSchemaSupervise> lstConcernes)
        {
            if (OnChangementDansLaBaseEvent != null)
                OnChangementDansLaBaseEvent(this, lstConcernes);
        }

        public static List<CReferenceObjetDonnee>GetTousLesConcernesSpv ( CSchemaReseau schema )
        {
            CBasePourVueAnimee basePourVue = new CBasePourVueAnimee ( schema.ContexteDonnee, false );
            basePourVue.TrouveLesConcernes ( schema );
            List<CReferenceObjetDonnee> lst = new List<CReferenceObjetDonnee>();
            basePourVue.FillListeConcernesSpv(basePourVue.m_infoSchemaRacine, lst);
            return lst;
        }

        private void FillListeConcernesSpv(CInfoElementDeSchemaSupervise info, List<CReferenceObjetDonnee> lst)
        {
            CReferenceObjetDonnee reference = info.GetReferenceObjetSpvAssocie();
            if (reference != null)
                lst.Add(reference);
            foreach (CInfoElementDeSchemaSupervise infoFils in info.ListeFils)
            {
                FillListeConcernesSpv(infoFils, lst);
            }
        }




        // Point d'entrée principal
        public void InitForSupervision(CSchemaReseau schema)
        {

            TrouveLesConcernes(schema);
            RempliLesDicsNoeuds();

            LoadAlarmesEtLiensTransForElement ( CSpvLienAccesAlarme.c_champSITE_ID, m_dicDirectementConcernesParSite );
            LoadAlarmesEtLiensTransForElement ( CSpvLienAccesAlarme.c_champLIAI_ID, m_dicDirectementConcernesParLiaison );
            LoadAlarmesEtLiensTransForElement ( CSpvLienAccesAlarme.c_champEQUIP_ID, m_dicDirectementConcernesParEquipement );

            
        }

        private void TrouveLesConcernes(CSchemaReseau schema)
        {
            m_infoSchemaRacine = new CInfoSchemaDeSchemaSupervise(null, null, this, 0);
            m_infoSchemaRacine.InitFromSchema(schema);

            m_dicDirectementConcernesParEquipement.Clear();
            m_dicDirectementConcernesParLiaison.Clear();
            m_dicDirectementConcernesParSite.Clear();
            m_dicDirectementConcernesParServices.Clear();

            m_infoSchemaRacine.FillDicsConcernes(
                m_dicDirectementConcernesParSite,
                m_dicDirectementConcernesParLiaison,
                m_dicDirectementConcernesParEquipement,
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


        //Initialise la base des alarmes en cours avec les alarmes de la base et les acces concernant chaque élément
        private void LoadAlarmesEtLiensTransForElement(string strChampDansAcces, CDictionnaireConcerne dicConcernes)
        {
            //Récupère la relation entre CSpvLienAccesAlarme et CSpvLienAccesAlarmeRep
            if ( m_relationFromLienAlarmeToLienAlarmeRep == null )
            {
                foreach ( CInfoRelation relation in CContexteDonnee.GetListeRelationsTable ( CSpvLienAccesAlarme.c_nomTable ) )
                {
                    if (relation.TableFille == CSpvLienAccesAlarme_Rep.c_nomTable && relation.TableParente == CSpvLienAccesAlarme.c_nomTable)
                    {
                        m_relationFromLienAlarmeToLienAlarmeRep = relation;
                        break;
                    }
                }
            }
            List<int> lstIdsElements = new List<int>();
            lstIdsElements.AddRange ( dicConcernes.Keys );
            int nSizePaquet = 100;
            for ( int nPaquet = 0; nPaquet < lstIdsElements.Count; nPaquet+= nSizePaquet )
            {
                int nMax = Math.Min ( nPaquet + nSizePaquet, lstIdsElements.Count );
                StringBuilder bl = new StringBuilder();
                for (int nId = 0; nId < nMax; nId++)
			{
                    bl.Append ( lstIdsElements[nId] );
                    bl.Append(';');
                }
                if ( bl.Length > 0 )
                {
                    bl.Remove ( bl.Length-1,1 );
                    //Charge tous les Liens d'alarme pour les éléments
                    CListeObjetsDonnees lstLiensAccesAlarme = new CListeObjetsDonnees(m_contexteDonnee, typeof(CSpvLienAccesAlarme));
                    lstLiensAccesAlarme.Filtre = new CFiltreDataAvance ( CSpvLienAccesAlarme.c_nomTable,
                        CSpvAccesAlarme.c_nomTable+"."+strChampDansAcces+" in ("+
                        bl.ToString()+")" );
                    lstLiensAccesAlarme.AssureLectureFaite();

                    // Chargement des acces correspondant
                    CListeObjetsDonnees lstAcces = lstLiensAccesAlarme.GetDependances("AccesAlarmeOne");
                    lstAcces.InterditLectureInDB = true;

                    CListeObjetsDonnees lstEtatAlarme = lstLiensAccesAlarme.GetDependances ( m_relationFromLienAlarmeToLienAlarmeRep );
                    lstEtatAlarme.Filtre = new CFiltreData ( CSpvLienAccesAlarme_Rep.c_champALARM_ID+" is not null");
                    lstEtatAlarme.AssureLectureFaite();
                    lstEtatAlarme.InterditLectureInDB = true;
                    
                    // Chargement des données alarmes
                    CListeObjetsDonnees listAlarmesDonnees = lstEtatAlarme.GetDependances("AlarmeDonnee");
                    listAlarmesDonnees.AssureLectureFaite();
                    listAlarmesDonnees.InterditLectureInDB = true;

                    lstLiensAccesAlarme.InterditLectureInDB = true;
                    lstEtatAlarme.InterditLectureInDB = true;

                    foreach (CSpvAlarmeDonnee donneeAlarme in listAlarmesDonnees)
                    {
                        if (donneeAlarme != null)
                        {
                            CInfoAlarmeAffichee info = new CInfoAlarmeAffichee(donneeAlarme);
                            //m_dicAlarmes[info.IdSpvEvtAlarme] = info;
                            m_dicAlarmes[info.IdSpvAlarmeData] = info;
                            StartAlarme(info);
                        }
                    }

                    foreach ( CSpvLienAccesAlarme lienAlarme in lstLiensAccesAlarme )
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
                    }
                    if (m_infoSchemaRacine != null) 
                    {
                        List<CInfoElementDeSchemaSupervise> lstTmp = new List<CInfoElementDeSchemaSupervise>();
                        m_infoSchemaRacine.RecalculeToutLeMasquage(lstTmp);
                    }
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

        public List<CInfoAlarmeAffichee> GetAlarmesPourElement(CElementDeSchemaReseau element)
        {
            List<CInfoAlarmeAffichee> lst = new List<CInfoAlarmeAffichee>();
            CInfoElementDeSchemaSupervise info = null;
            if (m_dicElementDeSchemaToInfoSupervision.TryGetValue(element.Id, out info))
            {
                foreach (int nId in info.GetIdsAlarmesEnCours())
                {
                    CInfoAlarmeAffichee alarme = null;
                    if (m_dicAlarmes.TryGetValue(nId, out alarme))
                        lst.Add(alarme);
                }
            }
            return lst;
        }



        

    }
}

