using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.data.dynamic;
using sc2i.common;
using sc2i.data;
using futurocom.snmp.dynamic;
using futurocom.snmp.entitesnmp;
using sc2i.multitiers.client;

namespace timos.data.snmp
{
    public class CCoupleEntiteSnmp_Champ
    {
        private CEntiteSnmp m_entite;
        private CChampCustom m_champCustom;

        //----------------------------------------------------------------------
        public CCoupleEntiteSnmp_Champ(CEntiteSnmp entite, CChampCustom champ)
        {
            m_entite = entite;
            m_champCustom = champ;
        }

        //----------------------------------------------------------------------
        public CEntiteSnmp Entite
        {
            get
            {
                return m_entite;
            }
        }

        //----------------------------------------------------------------------
        public CChampCustom ChampCustom
        {
            get
            {
                return m_champCustom;
            }
        }
    }

    public class CListeCouplesEntiteChamp : List<CCoupleEntiteSnmp_Champ>
    {
        //----------------------------------------------------------------------
        public void AddChamp(CEntiteSnmp entite, CChampCustom champ)
        {
            Add(new CCoupleEntiteSnmp_Champ(entite, champ));
        }

        //----------------------------------------------------------------------
        public CResultAErreur UpdateValeurs( CContexteDonnee contexteDeBasePasEnEdition, IIndicateurProgression indicateurProgression )
        {
            if ( Count == 0 )
                return CResultAErreur.True;
            CConteneurIndicateurProgression progress = CConteneurIndicateurProgression.GetConteneur(indicateurProgression);
            CResultAErreur result = CResultAErreur.True;
            //Lecture entite par entité pour optimiser la lecture
            Dictionary<CEntiteSnmp, HashSet<CChampCustom>> lstChamps = new Dictionary<CEntiteSnmp, HashSet<CChampCustom>>();
            progress.SetBornesSegment(0, Count);
            foreach (CCoupleEntiteSnmp_Champ couple in this)
            {
                HashSet<CChampCustom> set = null;
                if (!lstChamps.TryGetValue(couple.Entite, out set))
                {
                    set = new HashSet<CChampCustom>();
                    lstChamps[couple.Entite] = set;
                }
                set.Add(couple.ChampCustom);
            }

            CSessionClient session = CSousSessionClient.GetNewSousSession(this[0].Entite.ContexteDonnee.IdSession);
            session.OpenSession(new CAuthentificationSessionSousSession(this[0].Entite.ContexteDonnee.IdSession),
                "SNMP", ETypeApplicationCliente.Service);
            using (CContexteDonnee ctxModif = new CContexteDonnee(session.IdSession, true, false))
            {
                int nIndex = 1;
                foreach (KeyValuePair<CEntiteSnmp, HashSet<CChampCustom>> kv in lstChamps)
                {
                    CEntiteSnmp entite = kv.Key.GetObjetInContexte(ctxModif) as CEntiteSnmp;
                    CInterrogateurSnmp dynamicAgent = new CInterrogateurSnmp();
                    dynamicAgent.Connexion = entite.AgentSnmp.GetNewSnmpConnexion();
                    CEntiteSnmpPourSupervision ettSup = null;
                    foreach (CChampCustom champ in kv.Value)
                    {
                        int nIdChamp = champ.Id;
                        if (entite.ReadChampSnmp(nIdChamp, dynamicAgent, ref ettSup))
                            entite.CopieValeurSnmpDansValeurChamp(nIdChamp);
                        progress.SetValue(nIndex++);
                    }

                }
                progress.SetValue(Count);
                ctxModif.SaveAll(true);
                System.Threading.Thread.Sleep(2000);
                session.CloseSession();
            }
            return result;
        }
        
    }
}
