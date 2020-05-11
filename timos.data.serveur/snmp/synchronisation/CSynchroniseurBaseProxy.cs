using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.multitiers.client;
using sc2i.common;
using sc2i.process;
using sc2i.data;
using sc2i.data.serveur;
using timos.data.supervision;
using timos.data.snmp.Proxy;
using futurocom.supervision;
using futurocom.snmp.mediation;
using sc2i.common.DonneeCumulee;
using sc2i.data.dynamic;
using sc2i.multitiers.server;

namespace timos.data.snmp.serveur.synchronisation
{
    public class CSynchroniseurBaseProxy : ISynchroniseurServiceMediation
    {
        
        //----------------------------------------------------------------------------------------------------
        public IDonneeSynchronisationMediation GetUpdatesForProxy(int nIdProxy, int nIdLastSyncSession)
        {
            using (CSessionClient session = CSessionClient.CreateInstance())
            {
                CResultAErreur result = session.OpenSession(new CAuthentificationSessionProcess());
                if (!result)
                    return null;
                using (CContexteDonneesSynchro ctx = new CContexteDonneesSynchro(session.IdSession, true))
                {
                    CSc2iDataServer connexionManager = CSc2iDataServer.GetInstance();

                    IDatabaseConnexionSynchronisable cnxSync = connexionManager.GetDatabaseConnexion(session.IdSession, typeof(CTypeAgentSnmpServeur)) as IDatabaseConnexionSynchronisable;
                    if (cnxSync == null)
                        return null;
                    cnxSync.IncrementeSyncSession();
                    int nIdSyncMax = cnxSync.IdSyncSession - 1;

                    CFiltresSynchronisation filtres = new CFiltresSynchronisation();
                    filtres.AddFiltreForTable(CTypeAlarme.c_nomTable, null, false);
                    filtres.AddFiltreForTable(CSeveriteAlarme.c_nomTable, null, false);
                    filtres.AddFiltreForTable(CTypeAgentSnmp.c_nomTable, null, false);
                    filtres.AddFiltreForTable(CAgentSnmp.c_nomTable, 
                        new CFiltreData(CSnmpProxyInDb.c_champId + "=@1",
                            nIdProxy)
                            , false);
                    filtres.AddFiltreForTable(CTypeEntiteSnmp.c_nomTable, null, false);
                    filtres.AddFiltreForTable(CEntiteSnmp.c_nomTable, new CFiltreDataAvance(
                        CEntiteSnmp.c_nomTable,
                        CAgentSnmp.c_nomTable + "." +
                        CSnmpProxyInDb.c_champId + "=@1",
                        nIdProxy), false);
                    filtres.AddFiltreForTable(CRelationTypeEntiteSnmp_ChampCustom.c_nomTable, null, false);
                    filtres.AddFiltreForTable(CRelationEntiteSnmp_ChampCustom.c_nomTable,
                        new CFiltreDataAvance(CRelationEntiteSnmp_ChampCustom.c_nomTable,
                            CEntiteSnmp.c_nomTable + "." +
                            CAgentSnmp.c_nomTable + "." +
                            CSnmpProxyInDb.c_champId + "=@1",
                            nIdProxy), false);
                    // Prend uniquement les Filtrages d'alarme compris entre les dates de validité et marqués Enabled
                    filtres.AddFiltreForTable(CParametrageFiltrageAlarmes.c_nomTable,
                        new CFiltreData(
                            CParametrageFiltrageAlarmes.c_champIsActif + " = @1 AND "+
                            CParametrageFiltrageAlarmes.c_champDateDebutValidite + " <= @2 AND "+
                            CParametrageFiltrageAlarmes.c_champDateFinValidite + " > @2",
                            true,
                            DateTime.Now.Date), false);
                    filtres.AddFiltreForTable(CCategorieMasquageAlarme.c_nomTable, null, false);
                    DateTime dt = DateTime.Now;
                    // Créer le MemoryDB
                    bool bHasData = false;
                    result = ctx.FillWithModifsFromVersion(nIdLastSyncSession, nIdSyncMax, ref bHasData, filtres, true);
                    if (!result)
                        return null;
                    TimeSpan sp = DateTime.Now - dt;
                    Console.WriteLine("Lecture modifs médiation : " + sp.TotalMilliseconds);
                    dt = DateTime.Now;
                    CDonneesSynchronisationMediation donneesSynchro = new CDonneesSynchronisationMediation(
                        CMemoryDbPourSupervision.GetMemoryDb(ctx), nIdSyncMax);

                    
                    CListeObjetsDonnees lstObjets = new CListeObjetsDonnees(ctx, typeof(CSeveriteAlarme));
                    lstObjets.InterditLectureInDB = true;
                    foreach (CSeveriteAlarme severite in lstObjets)
                        severite.GetTypeForSupervision(donneesSynchro.Database);

                    lstObjets = new CListeObjetsDonnees(ctx, typeof(CTypeAlarme));
                    lstObjets.InterditLectureInDB = true;
                    foreach (CTypeAlarme type in lstObjets)
                        type.GetTypeForSupervision(donneesSynchro.Database, true);

                    lstObjets = new CListeObjetsDonnees(ctx, typeof(CTypeAgentSnmp));
                    lstObjets.InterditLectureInDB = true;
                    lstObjets.ReadDependances("TypesEntites");
                    foreach (CTypeAgentSnmp type in lstObjets)
                        type.GetTypeAgentPourSupervision(donneesSynchro.Database);

                    lstObjets = new CListeObjetsDonnees(ctx, typeof(CAgentSnmp));
                    lstObjets.InterditLectureInDB = true;
                    lstObjets.ReadDependances("EntitesSnmp","EntitesSnmp.RelationsChampsCustom",
                        "EntitesSnmp.SiteSupervise",
                        "EntitesSnmp.EquipementLogiqueSupervise",
                        "EntitesSnmp.EquipementLogiqueSupervise.Site",
                        "EntitesSnmp.LienReseauSupervise");
                    foreach (CAgentSnmp agent in lstObjets)
                    {
                        agent.GetAgentPourSupervision(donneesSynchro.Database, true);
                    }

                    lstObjets = new CListeObjetsDonnees(ctx, typeof(CParametrageFiltrageAlarmes));
                    lstObjets.InterditLectureInDB = true;
                    foreach (CParametrageFiltrageAlarmes parametreFiltre in lstObjets)
                        parametreFiltre.GetLocalParametrageForSupervision(donneesSynchro.Database);

                    lstObjets = new CListeObjetsDonnees(ctx, typeof(CCategorieMasquageAlarme));
                    lstObjets.InterditLectureInDB = true;
                    foreach (CCategorieMasquageAlarme categorie in lstObjets)
                        categorie.GetLocalCategorieForSupervision(donneesSynchro.Database);
                    
                    //S'assure que les entités des valeurs de champ entité sont chargés
                    lstObjets = new CListeObjetsDonnees(ctx, typeof(CRelationEntiteSnmp_ChampCustom));
                    lstObjets.InterditLectureInDB = true;
                    foreach (CRelationEntiteSnmp_ChampCustom rel in lstObjets)
                    {
                        if (rel != null && rel.ElementAChamps != null)
                            ((CObjetDonnee)rel.ElementAChamps).AssureData();
                    }

                    lstObjets = new CListeObjetsDonnees(ctx, typeof(CEntiteSnmp));
                    lstObjets.InterditLectureInDB = true;
                    foreach ( CEntiteSnmp entite in lstObjets )
                    {
                        CTypeEntiteSnmp typeEntite = entite.TypeEntiteSnmp;
                        futurocom.snmp.entitesnmp.CTypeEntiteSnmpPourSupervision te = typeEntite.GetTypeEntitePourSupervision(donneesSynchro.Database, true);
                        entite.GetEntitePourSupervision(te);
                    }

                    sp = DateTime.Now - dt;
                    Console.WriteLine("Intégration modifs médiation : " + sp.TotalMilliseconds);
                    return donneesSynchro;
                }
                
            }
        }

        private static CSessionClient m_sessionPolling = null;

        //----------------------------------------------------
        private CResultAErreur AssureSessionPolling()
        {
            CResultAErreur resErreur = CResultAErreur.True;
            System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Lowest;
            if (m_sessionPolling == null || !m_sessionPolling.IsConnected)
            {
                m_sessionPolling = CSessionClient.CreateInstance();
                resErreur = m_sessionPolling.OpenSession(new CAuthentificationSessionServer(),
                    "Snmp polling manager",
                    ETypeApplicationCliente.Service);
                if (!resErreur)
                {
                    resErreur.EmpileErreur(resErreur.Erreur);
                    C2iEventLog.WriteErreur("Error while open snmp polling management");
                    resErreur.EmpileErreur("Error while open snmp polling management");
                    return resErreur;
                }
            }

            return resErreur;
        }
        //----------------------------------------------------------------------------------------------------
        public CResultAErreur SendDonneesPooled(List<CDonneeCumuleeTransportable> lstDonnees)
        {
            CResultAErreur result = AssureSessionPolling();
            if (!result)
                return result;

            using (CContexteDonnee ctx = new CContexteDonnee(m_sessionPolling.IdSession, true, false))
            {
                foreach (CDonneeCumuleeTransportable donnee in lstDonnees)
                {
                    CDonneeCumulee data = new CDonneeCumulee(ctx);
                    data.CreateNewInCurrentContexte();
                    if (!data.FillFromDonneeTransportable(donnee))
                        data.Delete(true);
                }
                ctx.EnableTraitementsAvantSauvegarde = false;
                ctx.EnableTraitementsExternes = false;
                result = ctx.SaveAll(false);
            }
            result.Data = null;
            return result;
        }

    }
}
