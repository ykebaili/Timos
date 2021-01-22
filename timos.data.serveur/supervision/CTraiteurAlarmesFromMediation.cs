using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using futurocom.supervision;
using sc2i.common;
using sc2i.multitiers.client;
using sc2i.multitiers.server;
using sc2i.data;
using sc2i.common.memorydb;
using futurocom.snmp;
using timos.data.supervision;
using sc2i.data.serveur;
using System.Data;
using System.Threading;
using timos.data.snmp;

namespace timos.data.serveur.supervision
{
    /// <summary>
    /// traite les alarmes issues des services de médiation
    /// </summary>
    //[AutoExec("Autoexec", AutoExecAttribute.BackGroundService)]
    public class CTraiteurAlarmesFromMediation : ITraiteurAlarmeFromMediation
    {
        private CSessionClient m_sessionClient = null;
        private CContexteDonnee m_contexteDonnee = null;
        private static CTraiteurAlarmesFromMediation m_instance = null;

        private static int c_nPeriodeDemasquage = 1000*10; //Toutes les 60 secondes
        private Timer m_timerMasquage = null;

        //----------------------------------------------------
        public static void Autoexec()
        {
            CSnmpConnexion.TraiteurAlarme = DefaultInstance;
        }

        //----------------------------------------------------
        private bool m_bIsDemasquageEnCours = false;
        public void OnGereDemasquage(object state)
        {
            if (m_bIsDemasquageEnCours)
                return;
            m_bIsDemasquageEnCours = true;
            try
            {
                lock (typeof(CLockerTraitementAlarme))
                {
                    CResultAErreur result = AssureSessionEtContexte();
                    if (!result)
                        return;
                    CListeObjetsDonnees lstParametres = new CListeObjetsDonnees(m_contexteDonnee, typeof(CParametrageFiltrageAlarmes));
                    lstParametres.Filtre = new CFiltreData(
                        CParametrageFiltrageAlarmes.c_champDateDebutValidite + "<=@1 and " +
                        CParametrageFiltrageAlarmes.c_champDateFinValidite + ">=@2",
                        DateTime.Now,
                        DateTime.Now.AddDays(-1).AddHours(-2));
                    List<CParametrageFiltrageAlarmes> lst = lstParametres.ToList<CParametrageFiltrageAlarmes>();
                    HashSet<CAlarme> lstAlarmesARecalculer = new HashSet<CAlarme>();
                    foreach (CParametrageFiltrageAlarmes parametre in lst)
                    {
                        bool bOldIsApplicable = parametre.IsAppliquableEnCeMoment;
                        parametre.RecalcIsApplicableEnCeMoment();
                        if (bOldIsApplicable != parametre.IsAppliquableEnCeMoment &&
                            !parametre.IsAppliquableEnCeMoment)
                        {
                            //Il faut démasquer
                            CListeObjetsDonnees lstAlarmes = new CListeObjetsDonnees(m_contexteDonnee, typeof(CAlarme));
                            lstAlarmes.Filtre = new CFiltreData(CAlarme.c_champIdMasquagePropre + "=@1 and " +
                            CAlarme.c_champDateFin + " is null",
                                parametre.Id);
                            foreach (CAlarme alrm in lstAlarmes)
                            {
                                alrm.MasquagePropre = null;
                                lstAlarmesARecalculer.Add(alrm);
                            }
                        }
                    }
                    lstParametres.Filtre = new CFiltreData(
                        CParametrageFiltrageAlarmes.c_champDateDebutValidite + "<=@1 and " +
                        CParametrageFiltrageAlarmes.c_champDateFinValidite + ">=@2",
                        DateTime.Now,
                        DateTime.Now.AddDays(-1));
                    lstParametres.PreserveChanges = true;
                    IEnumerable<IParametrageFiltrageAlarmes> parametres = lstParametres.ToList<IParametrageFiltrageAlarmes>();
                    foreach (CAlarme alarme in lstAlarmesARecalculer)
                    {
                        CParametrageFiltrageAlarmes p = CUtilMasquageAlarmes.GetParametreAAppliquer(alarme, DateTime.Now, parametres) as CParametrageFiltrageAlarmes;
                        if (p != null)
                            alarme.MasquagePropre = p;
                    }
                    result = m_contexteDonnee.SaveAll(true);
                }
            }
            catch (Exception e)
            {
            }
            finally
            {
                m_bIsDemasquageEnCours = false;
            }

        }

        //----------------------------------------------------
        public static CTraiteurAlarmesFromMediation DefaultInstance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = new CTraiteurAlarmesFromMediation();
                    m_instance.m_timerMasquage = new Timer(m_instance.OnGereDemasquage, null, c_nPeriodeDemasquage, 1000 * 20);
                }
                return m_instance;
            }
        }


        //----------------------------------------------------
        private CTraiteurAlarmesFromMediation()
        {
        }

        //----------------------------------------------------
        private class CLockerTraitementAlarme
        {
        }

        //----------------------------------------------------
        private CResultAErreur AssureSessionEtContexte()
        {
            CResultAErreur resErreur = CResultAErreur.True;
            System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Lowest;
            if (m_sessionClient == null || !m_sessionClient.IsConnected)
            {
                m_sessionClient = CSessionClient.CreateInstance();
                resErreur = m_sessionClient.OpenSession(new CAuthentificationSessionServer(),
                    I.T("Alarm management|20154"),
                    ETypeApplicationCliente.Service);
                if (!resErreur)
                {
                    resErreur.EmpileErreur(resErreur.Erreur);
                    C2iEventLog.WriteErreur(I.T("Error while open alarm management session|20155"));
                    resErreur.EmpileErreur(I.T("Error while open alarm management session|20155"));
                    return resErreur;
                }
            }

            if (m_contexteDonnee == null)
            {
                m_contexteDonnee = new CContexteDonnee(m_sessionClient.IdSession, true, true);
                CListeObjetsDonnees lst = new CListeObjetsDonnees(m_contexteDonnee, typeof(CTypeAlarme));
                lst.AssureLectureFaite();
                lst.ReadDependances("RelationsChampsCustomListe");
                lst = new CListeObjetsDonnees(m_contexteDonnee, typeof(CSeveriteAlarme));
                lst.AssureLectureFaite();
            }

            return resErreur;
        }

        //----------------------------------------------------
        private static int m_nReceived = 0;
        private static int m_nNbAlarmesTraitees = 0;
        public CResultAErreurType<CMappageIdsAlarmes> Traite(CMemoryDb dbContenantLesAlarmesATraiter)
        {
            CResultAErreurType<CMappageIdsAlarmes> result = new CResultAErreurType<CMappageIdsAlarmes>();
            result.SetTrue();
            CResultAErreur resErreur = CResultAErreur.True;
            try
            {
                lock (typeof(CLockerTraitementAlarme))
                {
                    resErreur = AssureSessionEtContexte();
                    if (!resErreur)
                    {
                        result.EmpileErreur(resErreur.Erreur);
                        return result;
                    }

                    CListeEntitesDeMemoryDb<CLocalAlarme> lstAlarmes = new CListeEntitesDeMemoryDb<CLocalAlarme>(dbContenantLesAlarmesATraiter);
                    lstAlarmes.Filtre = new CFiltreMemoryDb(CMemoryDb.c_champIsToRead + "=@1", false);
                    lstAlarmes.Sort = CLocalAlarme.c_champDateDebut;
                    //Mappage des ids pour les alarmes qui changent d'ID
                    m_nNbAlarmesTraitees += lstAlarmes.Count();
                    CMappageIdsAlarmes dicMapIds = new CMappageIdsAlarmes();
                    HashSet<string> alarmesTraitees = new HashSet<string>();
                    using (CContexteDonnee ctxEdit = m_contexteDonnee.GetContexteEdition())
                    {
                        ctxEdit.EnableTraitementsExternes = false;
                        ctxEdit.DisableHistorisation = true;
                        try
                        {
                            foreach (CLocalAlarme alrm in lstAlarmes)
                            {
                                if (!alarmesTraitees.Contains(alrm.Id))
                                {
                                    CLocalAlarme root = alrm;
                                    while (root.Parent != null && !root.Parent.IsToRead())
                                        root = root.Parent;
                                    GereHierarchie(ctxEdit, root, dicMapIds, alarmesTraitees, null);
                                }
                            }
                            result.DataType = dicMapIds;
                        }
                        catch (Exception e)
                        {
                            result.EmpileErreur(new CErreurException(e));
                        }
                        finally
                        {
                            if (result)
                            {
                                resErreur = SauvegardeOptimisee(ctxEdit);
                                if (!resErreur)
                                    result.EmpileErreur(resErreur.Erreur);
                            }
                            else
                                ctxEdit.CancelEdit();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                {
                    C2iEventLog.WriteErreur(I.T("Error in Alarms @1|20156", e.ToString()));
                }
            }
            finally
            {

            }
            Console.WriteLine("Alarmes traitées : " + m_nNbAlarmesTraitees + " à " + DateTime.Now.ToString("HH:mm:ss"));
            return result;
        }

        //----------------------------------------------------
        private CResultAErreur SauvegardeOptimisee(CContexteDonnee ctxEdition)
        {
            CResultAErreur result = CResultAErreur.True;
            m_sessionClient.BeginTrans();
            try
            {
                CAlarmeServeur serveur = new CAlarmeServeur(m_sessionClient.IdSession);
                serveur.TraitementAvantSauvegarde(ctxEdition);
                CDonneeNotificationModificationContexteDonnee donneeNotif = new CDonneeNotificationModificationContexteDonnee(m_sessionClient.IdSession );
                CListeRestrictionsUtilisateurSurType lst = new CListeRestrictionsUtilisateurSurType();
                CContexteSauvegardeObjetsDonnees ctx = new CContexteSauvegardeObjetsDonnees(ctxEdition, donneeNotif, lst);
                result = serveur.SaveAll(ctx, DataRowState.Modified | DataRowState.Added);
                if (result)
                {
                    CRelationAlarme_ChampCustomServeur chServeur = new CRelationAlarme_ChampCustomServeur(m_sessionClient.IdSession);
                    result = chServeur.SaveAll(ctx, DataRowState.Modified | DataRowState.Added);
                }
              
                if (result)
                    result = serveur.TraitementApresSauvegarde(ctxEdition, true);
                if (result)
                    CEnvoyeurNotification.EnvoieNotifications(new IDonneeNotification[]{ctx.DonneeNotification});
            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
            }
            finally
            {
                if (result)
                    result = m_sessionClient.CommitTrans();
                else
                    m_sessionClient.RollbackTrans();
            }
            return result;
        }

        //----------------------------------------------------
        private void GereHierarchie(
            CContexteDonnee ctxEdit,
            CLocalAlarme alarme, 
            CMappageIdsAlarmes dicMapIds,
            HashSet<string> alarmesTraitees,
            CAlarme alarmeParente )
        {
            if (alarmesTraitees.Contains(alarme.Id))
                return;

            CAlarme alarmeInDb = new CAlarme(ctxEdit);
            bool bExiste = false;
            string strIdAlarme = alarme.Id;
            if ( alarmeInDb.ReadIfExists ( new CFiltreData ( CAlarme.c_champAlarmId+"=@1", strIdAlarme ) ))
            {
                bExiste = true;
            }
            else if (dicMapIds.TryGetValue(alarme.Id, out strIdAlarme))
            {
                if (alarmeInDb.ReadIfExists(new CFiltreData(CAlarme.c_champAlarmId + "=@1", strIdAlarme)))
                    bExiste = true;
            }
            else
                strIdAlarme = alarme.Id;
            if ( !bExiste )
            {
                if (alarmeInDb.ReadIfExists(
                    new CFiltreData(CAlarme.c_champCle + "=@1 and " +
                    CAlarme.c_champDateFin +" is null",
                    alarme.GetKey())))
                    bExiste = true;
            }
            if (!bExiste)
                alarmeInDb.CreateNewInCurrentContexte();
            else
            {
                strIdAlarme = alarmeInDb.AlarmId;
            }
            alarmesTraitees.Add(alarme.Id);
            alarmeInDb.AlarmeParente = alarmeParente;
            alarmeInDb.FillFromLocalAlarmeFromMediation ( alarme );
            alarmeInDb.AlarmId = strIdAlarme;
            
            if (alarmeInDb.AlarmId != alarme.Id)
            {
                dicMapIds[alarme.Id] = alarmeInDb.AlarmId;
                alarme.Id = alarmeInDb.AlarmId;
            }
            foreach (CLocalAlarme alarmeFille in alarme.Childs)
                GereHierarchie(ctxEdit, alarmeFille, dicMapIds, alarmesTraitees, alarmeInDb);
        }

        //----------------------------------------------------
        public void UpdateAgentIpFromMediation(string strAgentId, string strNewIp, bool bUpdateTimosDb)
        {
            if (bUpdateTimosDb)
            {
                AssureSessionEtContexte();
                int nIdAgent = -1;
                if (Int32.TryParse(strAgentId, out nIdAgent) && m_contexteDonnee != null)
                {
                    using (CContexteDonnee ctxEdit = m_contexteDonnee.GetContexteEdition())
                    {
                        CAgentSnmp agent = new CAgentSnmp(ctxEdit);
                        if (agent.ReadIfExists(nIdAgent))
                        {
                            agent.SnmpIp = strNewIp;
                            ctxEdit.EnableTraitementsAvantSauvegarde = false;
                            ctxEdit.EnableTraitementsExternes = false;
                            ctxEdit.CommitEdit();
                        }
                    }
                }
            }
        }
    }
}
