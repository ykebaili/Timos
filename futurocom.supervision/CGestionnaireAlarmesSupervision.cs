using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.expression;
using sc2i.common.memorydb;
using sc2i.common;
using sc2i.common.trace;
using futurocom.supervision.alarmes;

namespace futurocom.supervision
{
    public enum EModeRemonteeAlarmes
    {
        NePasRemonter,
        RemonterEnFin,
        InscrireARemonterMaisNePasLeFaire
    }

    public class CGestionnaireAlarmesSupervision : IGestionnaireAlarmes
    {
        private CMemoryDb m_database = new CMemoryDb();
        private IBaseFiltrageAlarmes m_baseFiltrage = null;

        private List<CLocalAlarme> m_listeAlarmesATransmettre = new List<CLocalAlarme>();

        //Key->Alarme
        private Dictionary<string, CLocalAlarme> m_dicCurrent = new Dictionary<string, CLocalAlarme>();

        //Id->Alarme
        private Dictionary<string, CLocalAlarme> m_dicAlarmes = new Dictionary<string, CLocalAlarme>();

        private Dictionary<string, CLocalAlarme> m_dicEnded = new Dictionary<string, CLocalAlarme>();

        private ITraiteurAlarmeFromMediation m_traiteurAlarmes = null;

        private CFuturocomTrace m_trace = new CFuturocomTrace();




        //-------------------------------------------------------
        public CFuturocomTrace Trace
        {
            get
            {
                return m_trace;
            }
            set
            {
                if (value != null)
                    m_trace = value;
            }
        }

        //-------------------------------------------------------
        public ITraiteurAlarmeFromMediation TraiteurAlarmes
        {
            get
            {
                return m_traiteurAlarmes;
            }
            set
            {
                m_traiteurAlarmes = value;
            }
        }

        //-------------------------------------------------------
        public IEnumerable<CLocalAlarme> CurrentAlarms
        {
            get { return m_dicCurrent.Values; }
        }

        //-------------------------------------------------------
        public IEnumerable<CLocalAlarme> EndedAlarms
        {
            get { return m_dicEnded.Values; }
        }

        //-------------------------------------------------------
        public CMemoryDb Database
        {
            get
            {
                return m_database;
            }
        }

        //-------------------------------------------------------
        /// <summary>
        /// Base de donnée mémoire contenant toutes les entités de configuration du Servie de Médiation
        /// </summary>
        public IBaseFiltrageAlarmes BaseFiltrage
        {
            get
            {
                return m_baseFiltrage;
            }
            set
            {
                m_baseFiltrage = value;
            }
        }

        //--------------------------------------------------------------------------
        /// <summary>
        /// Retourne la liste des Parametres de filtrage des Alarmes
        /// </summary>
        private IEnumerable<CLocalParametrageFiltrageAlarmes> ParametresFiltrage
        {
            get
            {
                if (m_baseFiltrage != null)
                    return m_baseFiltrage.ParametresFiltrage;
                return new List<CLocalParametrageFiltrageAlarmes>();
            }
        }


        //-------------------------------------------------------
        public CLocalAlarme GetAlarmFromId(string strId)
        {
            CLocalAlarme alrm = null;
            m_dicAlarmes.TryGetValue(strId, out alrm);
            return alrm;
        }

        //-------------------------------------------------------
        public void CreateAlarme(CAlarmeACreer alarmeACreer, EModeRemonteeAlarmes modeRemontee)
        {
            bool bGerer = false;
            lock (typeof(CLockerDatabase))
            {
                string strParentKey = alarmeACreer.Alarme.CalcParentKey();

                switch (alarmeACreer.OptionCreation)
                {
                    case EOptionCreationAlarme.Always:
                        bGerer = true;
                        break;
                    case EOptionCreationAlarme.SiPasDeParentActif:
                        if (strParentKey == null)
                            bGerer = true;
                        else
                            bGerer = !m_dicCurrent.ContainsKey(strParentKey);
                        break;
                    case EOptionCreationAlarme.SiParentActif:
                        if (strParentKey == null)
                            bGerer = true;
                        else
                            bGerer = m_dicCurrent.ContainsKey(strParentKey);
                        break;
                    default:
                        break;
                }
                if (alarmeACreer.Alarme.TypeAlarme.RegrouperSurLaCle &&
                    m_dicCurrent.ContainsKey(alarmeACreer.Alarme.GetKey()))
                {
                    CLocalAlarme alrmExistante = m_dicCurrent[alarmeACreer.Alarme.GetKey()];
                    if (alrmExistante.EtatCode == alarmeACreer.Alarme.EtatCode)
                    {
                        m_trace.Write("Alarm already exists", ALTRACE.DEBUG);
                        return;
                    }
                }
            }
            if (bGerer)
                GereAlarme(alarmeACreer.Alarme, modeRemontee);
        }

        //-------------------------------------------------------
        public void GereAlarme(CLocalAlarme alarme, EModeRemonteeAlarmes modeRemontee)
        {
            CResultAErreur result = CResultAErreur.True;

            DateTime dtChrono = DateTime.Now;
            lock (typeof(CLockerDatabase))
            {
                if (alarme.Database != Database)
                {

                    CLocalAlarme tmpAlarme = new CLocalAlarme(Database);
                    if (!tmpAlarme.ReadIfExist(alarme.Id))
                    {
                        m_dicCurrent.TryGetValue(alarme.GetKey(), out tmpAlarme);
                        if (tmpAlarme == null)
                        {

                            tmpAlarme = Database.ImporteObjet(alarme, false, false) as CLocalAlarme;
                        }
                    }

                    //Reprend l'état de l'alarme qui vient d'arriver. Le reste ne bouge pas
                    tmpAlarme.EtatCode = alarme.EtatCode;//Mise à jour de l'état
                    alarme = tmpAlarme;

                }

                TimeSpan sp = DateTime.Now - dtChrono;

                string strKey = alarme.GetKey();
                if (alarme.Etat.Code == EEtatAlarme.Open && alarme.DateFin == null)
                {
                    IntegreAlarmeAListeOuvertes(alarme);
                }
                else
                {
                    IntegreAlarmeAListeFermees(alarme);
                }

                m_dicAlarmes[alarme.Id] = alarme;
                if (modeRemontee != EModeRemonteeAlarmes.NePasRemonter)
                    AddAlarmeAEnvoyer(alarme);
            }

            GereParent(alarme);
            GereMasquage(alarme);


            if (modeRemontee == EModeRemonteeAlarmes.RemonterEnFin && m_traiteurAlarmes != null)
            {
                SendAlarmes();
            }
        }


        private void GereMasquage(CLocalAlarme alarme)
        {
            /// Passe l'Alarme dans les filtre de masquage, avec ou sans remontée en BDD
            /// Il peut y avoir plusieurs filtres qui masquent l'Alarme. Donc il faut prendre celui qui a 
            /// une Catégorie de Masquage de plus haute priorité
            CLocalParametrageFiltrageAlarmes localMasque = null;

            IEnumerable<IParametrageFiltrageAlarmes> lstParametres = from p in ParametresFiltrage select p as IParametrageFiltrageAlarmes;
            localMasque = CUtilMasquageAlarmes.GetParametreAAppliquer(
                alarme,
                DateTime.Now,
                lstParametres) as CLocalParametrageFiltrageAlarmes;

            if (localMasque != null && localMasque.IgnorerEnBase)
            {
                m_trace.Write("Alarm is hidden " + alarme.Libelle, ALTRACE.DEBUG);
                DeleteAlarme(alarme);
            }


            if (localMasque != null)
                alarme.MasquagePropre = localMasque;

        }

        //-------------------------------------------------------
        private void DeleteAlarme(CLocalAlarme alarme)
        {
            lock (typeof(CLockerDatabase))
            {
                foreach (CLocalAlarme alarmeFille in alarme.Childs.ToArray())
                {
                    DeleteAlarme(alarmeFille);
                }
                if (m_dicAlarmes.ContainsKey(alarme.Id))
                    m_dicAlarmes.Remove(alarme.Id);
                string strKey = alarme.GetKey();
                if (m_dicCurrent.ContainsKey(strKey))
                    m_dicCurrent.Remove(strKey);
                if (m_dicEnded.ContainsKey(strKey))
                    m_dicEnded.Remove(strKey);
                lock (typeof(CLockListeAlarmes))
                {
                    if (m_listeAlarmesATransmettre.Contains(alarme))
                        m_listeAlarmesATransmettre.Remove(alarme);
                }
            }
            alarme.Delete();
        }


        //-------------------------------------------------------
        private void IntegreAlarmeAListeOuvertes(CLocalAlarme alarme)
        {
            string strKey = alarme.GetKey();
            if (!m_dicCurrent.ContainsKey(strKey))
                m_dicCurrent[strKey] = alarme;

            if (m_dicEnded.ContainsKey(strKey))
                m_dicEnded.Remove(strKey);
            foreach (CLocalAlarme fille in alarme.Childs)
                IntegreAlarmeAListeOuvertes(fille);
        }

        //-------------------------------------------------------
        private void IntegreAlarmeAListeFermees(CLocalAlarme alarme)
        {
            string strKey = alarme.GetKey();
            if (m_dicCurrent.ContainsKey(strKey))
                m_dicCurrent.Remove(strKey);
            if (!m_dicEnded.ContainsKey(strKey))
                m_dicEnded[strKey] = alarme;
            foreach (CLocalAlarme fille in alarme.Childs)
                IntegreAlarmeAListeFermees(fille);
        }

        //-------------------------------------------------------
        private static int m_nNbTotalAEnvoyer = 0;
        private void AddAlarmeAEnvoyer(CLocalAlarme alarme)
        {
            lock (typeof(CLockListeAlarmes))
            {
                if (!m_listeAlarmesATransmettre.Contains(alarme))
                {
                    m_listeAlarmesATransmettre.Add(alarme);
                    m_nNbTotalAEnvoyer++;
                }
                foreach (CLocalAlarme child in alarme.Childs.ToArray())
                    AddAlarmeAEnvoyer(child);
            }
        }

        //-------------------------------------------------------
        private class CLockListeAlarmes { }

        //-------------------------------------------------------
        private class CLockTraiteurAlarmes { }

        //-------------------------------------------------------
        private static int m_nNbSend = 0;
        private static int m_nWaitingCounter = 0;
        public void SendAlarmes()
        {
            if (m_traiteurAlarmes == null)
                return;
            if (m_nWaitingCounter > 5)
                return;
            m_nWaitingCounter++;
            lock (typeof(CLockTraiteurAlarmes))
            {
                m_nWaitingCounter--;
                List<CLocalAlarme> lstToSend = null;
                lock (typeof(CLockListeAlarmes))
                {
                    if (m_listeAlarmesATransmettre.Count < 250 || m_nWaitingCounter == 0)
                    {
                        lstToSend = m_listeAlarmesATransmettre;
                        m_listeAlarmesATransmettre = new List<CLocalAlarme>();
                    }
                    else
                    {
                        lstToSend = new List<CLocalAlarme>();
                        for (int n = 0; n < 250; n++)
                            lstToSend.Add(m_listeAlarmesATransmettre[n]);
                        m_listeAlarmesATransmettre.RemoveRange(0, 250);
                    }

                }
                try
                {
                    System.Data.DataTable tbl = Database.Tables[CLocalAlarme.c_nomTable];
                    Console.WriteLine("Nb in db : " + tbl.Rows.Count);
                    if (lstToSend.Count == 0)
                        return;
                    using (CMemoryDb memDB = new CMemoryDb())
                    {
                        memDB.EnforceConstraints = false;
                        lock (typeof(CLockerDatabase))
                        {
                            foreach (CLocalAlarme alrm in lstToSend)
                            {
                                try
                                {
                                    if (alrm.Row.Row.RowState != System.Data.DataRowState.Detached)
                                        memDB.ImporteObjet(alrm, true, false);

                                }
                                catch (Exception e)
                                {
                                    throw e;
                                }
                            }
                        }
                        m_nNbSend += lstToSend.Count;
                        CResultAErreurType<CMappageIdsAlarmes> result = m_traiteurAlarmes.Traite(memDB);
                        if (result)
                        {
                            if (result.DataType != null)
                            {
                                foreach (KeyValuePair<string, string> kv in result.DataType)
                                {
                                    if (kv.Value != kv.Key)
                                    {
                                        CLocalAlarme alarme = GetAlarmFromId(kv.Key);
                                        if (alarme != null)
                                        {
                                            alarme.Id = kv.Key;
                                            m_dicAlarmes.Remove(kv.Key);
                                            m_dicAlarmes[kv.Value] = alarme;
                                        }
                                    }
                                }
                            }
                            NettoyageDB();
                            return;
                        }
                        if (!result)
                        {
                            m_trace.Write("Error while sending to Timos manager", ALTRACE.DEBUG);
                            m_trace.Write(result.Erreur.ToString(), ALTRACE.DEBUG);
                        }
                    }

                }
                catch (Exception exep)
                {

                }
                lock (typeof(CLockListeAlarmes))
                {
                    for (int n = lstToSend.Count - 1; n >= 0; n--)
                    {
                        if (lstToSend[n].Row.Row.RowState == System.Data.DataRowState.Detached)
                            lstToSend.RemoveAt(n);
                    }
                    m_listeAlarmesATransmettre.InsertRange(0, lstToSend);
                }
            }
        }

        public class CLockerDatabase { }

        //-------------------------------------------------------
        private CLocalAlarme GetNewAlarme()
        {
            lock (typeof(CLockerDatabase))
            {
                CLocalAlarme alrm = new CLocalAlarme(m_database);
                alrm.CreateNew();
                return alrm;
            }
        }

        //-------------------------------------------------------
        private void GereParent(CLocalAlarme alarme)
        {
            if (alarme == null)
                return;
            CLocalTypeAlarme type = alarme.TypeAlarme;
            if (alarme.Parent == null && type.TypeParent != null)
            {
                string strKey = alarme.CalcParentKey();
                CLocalAlarme parent = GetCurrentAlarmFromKey(strKey); ;
                if (parent != null)
                {
                    alarme.Parent = parent;
                }
                else
                {
                    parent = GetNewAlarme();
                    parent.TypeAlarme = type.TypeParent;
                    if ((parent.TypeAlarme.TypeElementSupervise & ETypeElementSupervise.Site) == ETypeElementSupervise.Site)
                        parent.SiteId = alarme.SiteId;
                    if ((parent.TypeAlarme.TypeElementSupervise & ETypeElementSupervise.Equipement) == ETypeElementSupervise.Equipement)
                        parent.EquipementId = alarme.EquipementId;
                    if ((parent.TypeAlarme.TypeElementSupervise & ETypeElementSupervise.Lien) == ETypeElementSupervise.Lien)
                        parent.LienId = alarme.LienId;
                    if ((parent.TypeAlarme.TypeElementSupervise & ETypeElementSupervise.EntiteSnmp) == ETypeElementSupervise.EntiteSnmp)
                        parent.EntiteSnmpId = alarme.EntiteSnmpId;

                    CLocalTypeAlarme typeForChamps = parent.TypeAlarme;
                    while (typeForChamps != null)
                    {
                        foreach (CLocalRelationTypeAlarmeChampAlarme rel in typeForChamps.RelationsChamps)
                        {
                            parent.SetValeurChamp(rel.Champ.Id, alarme.GetValeurChamp(rel.Champ.Id));
                        }
                        typeForChamps = typeForChamps.TypeParent;
                    }
                    alarme.Parent = parent;
                }
                parent.Etat = new CEtatAlarme(EEtatAlarme.Open);
            }
            if (alarme.Parent != null)
            {
                alarme.AgitSurParent();
                GereAlarme(alarme.Parent, EModeRemonteeAlarmes.InscrireARemonterMaisNePasLeFaire);
            }
        }


        //-------------------------------------------------------
        public CLocalAlarme GetCurrentAlarmFromKey(string strKey)
        {
            CLocalAlarme alarme = null;
            m_dicCurrent.TryGetValue(strKey, out alarme);
            return alarme;
        }

        //-------------------------------------------------------
        public void RedescendAlarmes(CMemoryDb dbContenantLesAlarmesARedescendre)
        {
            CListeEntitesDeMemoryDb<CLocalAlarme> lst = new CListeEntitesDeMemoryDb<CLocalAlarme>(dbContenantLesAlarmesARedescendre);
            foreach (CLocalAlarme alrm in lst)
            {
                CLocalAlarme myAlarm = new CLocalAlarme(m_database);
                if (myAlarm.ReadIfExist(alrm.Id))
                {
                    GereAlarme(alrm, EModeRemonteeAlarmes.NePasRemonter);
                }
            }
        }



        //-------------------------------------------------------
        public void NettoyageDB()
        {
            lock (typeof(CLockerDatabase))
                lock (typeof(CLockListeAlarmes))
                {
                    List<CLocalAlarme> listeATraiter = new List<CLocalAlarme>();
                    CListeEntitesDeMemoryDb<CLocalAlarme> lst = new CListeEntitesDeMemoryDb<CLocalAlarme>(Database);
                    lst.Filtre = new CFiltreMemoryDb(CLocalAlarme.c_champIdParent + " is null");
                    foreach (CLocalAlarme alarme in lst)
                    {
                        if (!m_listeAlarmesATransmettre.Contains(alarme))
                            listeATraiter.Add(alarme);
                    }
                    while (listeATraiter.Count > 0)
                    {
                        List<CLocalAlarme> nextList = new List<CLocalAlarme>();
                        foreach (CLocalAlarme alrm in listeATraiter)
                        {
                            if (alrm.EtatCode == EEtatAlarme.Close)
                            {
                                CLocalAlarme parent = alrm.Parent;
                                if (parent != null && !m_listeAlarmesATransmettre.Contains(parent))
                                    nextList.Add(parent);
                            }
                            DeleteAlarme(alrm);
                        }
                        listeATraiter = nextList;
                    }
                }
        }
    }
}

