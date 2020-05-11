using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.multitiers.client;

namespace sc2i.common.synchronisation
{
    public class CSynchroniseurBaseDistante : IObjetAttacheASession
    {
        private int m_nIdSession = -1;
        /// <summary>
        /// Clé de la base distante->Données à synchroniser
        /// </summary>
        private Dictionary<string, CDonneesSynchronisationBaseDistante> m_dicDonneesSynchro = new Dictionary<string, CDonneesSynchronisationBaseDistante>();

        private static Dictionary<int, CSynchroniseurBaseDistante> m_dicSessionToSynchroniseur = new Dictionary<int, CSynchroniseurBaseDistante>();

        //--------------------------------------------------------------------
        public CSynchroniseurBaseDistante(int nIdSession)
        {
        }

        //--------------------------------------------------------------------
        internal CSynchroniseurBaseDistante()
        {
            m_nIdSession = -1;
        }

        //--------------------------------------------------------------------
        public static CSynchroniseurBaseDistante GetSynchroniseur(int nIdSession)
        {
            CSynchroniseurBaseDistante synchro = null;
            if (!m_dicSessionToSynchroniseur.TryGetValue(nIdSession, out synchro))
            {
                synchro = new CSynchroniseurBaseDistante(nIdSession);
                m_dicSessionToSynchroniseur[nIdSession] = synchro;
            }
            return synchro;
        }

        //--------------------------------------------------------------------
        /// <summary>
        /// Id session est null si on ne gère pas de transaction
        /// </summary>
        /// <param name="nIdSession"></param>
        /// <param name="strCleBaseDistante"></param>
        /// <param name="operation"></param>
        public void AddOperation(
            int? nIdSession, 
            string strCleBaseDistante, 
            IOperationSynchronisation operation)
        {
            lock (this)
            {
                if (nIdSession != null)
                {
                    CTransactionSynchroniseur trans = CGestionnaireTransactionsSynchroniseur.GetInstance().GetServiceTransaction(nIdSession.Value) as CTransactionSynchroniseur;
                    if (trans != null && trans.IsInTrans())
                    {
                        trans.AddOperation(strCleBaseDistante, operation);
                        return;
                    }
                }
                CDonneesSynchronisationBaseDistante donnee = null;
                if (!m_dicDonneesSynchro.TryGetValue(strCleBaseDistante, out donnee))
                {
                    donnee = new CDonneesSynchronisationBaseDistante(strCleBaseDistante);
                    m_dicDonneesSynchro[strCleBaseDistante] = donnee;
                }
                donnee.AddOperation(operation);
            }
        }

        //--------------------------------------------------------------------
        public CResultAErreur TraiteAgent(string strCleAgent)
        {
            CResultAErreur result = CResultAErreur.True;
            CDonneesSynchronisationBaseDistante donnee = null;
            if (m_dicDonneesSynchro.TryGetValue(strCleAgent, out donnee))
                return donnee.DoOperations(m_nIdSession);
            return result;
        }

        //--------------------------------------------------------------------
        public CResultAErreur TraiteAll()
        {
            CResultAErreur result = CResultAErreur.True;
            bool bHasTravail = true;
            while (bHasTravail)
            {
                result = TraiteNextDestination();
                if ( !result )
                    return result;
                bHasTravail = m_dicDonneesSynchro.Values.FirstOrDefault(d => d.Operations.Count() > 0) != null;
            }
            return result;
        }

        //--------------------------------------------------------------------
        public CResultAErreur TraiteNextDestination()
        {
            CResultAErreur result = CResultAErreur.True;
            CDonneesSynchronisationBaseDistante donneeSyncRetenue = null;
            lock (this)
            {
                DateTime? dtMin = null;
                foreach ( KeyValuePair<string, CDonneesSynchronisationBaseDistante> kv in m_dicDonneesSynchro )
                {
                    if (kv.Value.Operations.Count() > 0)
                    {
                        if (dtMin == null || (kv.Value.LastDateSynchro != null && kv.Value.LastDateSynchro < dtMin))
                        {
                            donneeSyncRetenue = kv.Value;
                            dtMin = kv.Value.LastDateSynchro;
                        }
                    }
                }
            }
            if ( donneeSyncRetenue != null )
                result = donneeSyncRetenue.DoOperations(m_nIdSession);
            return result;
        }


        //----------------------------------------------------------------------
        /// <summary>
        /// Intègre les opérations d'un synchroniseur
        /// </summary>
        /// <param name="synchroniseur"></param>
        /// <returns></returns>
        internal CResultAErreur IntegreOperations(CSynchroniseurBaseDistante synchroniseur)
        {
            CResultAErreur result = CResultAErreur.True;
            foreach (KeyValuePair<string, CDonneesSynchronisationBaseDistante> kv in synchroniseur.m_dicDonneesSynchro)
            {
                CDonneesSynchronisationBaseDistante donneeDeMoi = null;
                if (!m_dicDonneesSynchro.TryGetValue(kv.Key, out donneeDeMoi))
                {
                    donneeDeMoi = new CDonneesSynchronisationBaseDistante(kv.Value.CleDestination);
                    m_dicDonneesSynchro[kv.Key] = donneeDeMoi;
                }
                result = donneeDeMoi.IntegreOperations(kv.Value);
                if (!result)
                    return result;
            }
            return result;
        }

        #region IObjetAttacheASession Membres

        public string DescriptifObjetAttacheASession
        {
            get { return "External synchronisation"; }
        }

        public void OnCloseSession()
        {
            if (m_dicSessionToSynchroniseur.ContainsKey(m_nIdSession))
                m_dicSessionToSynchroniseur.Remove(m_nIdSession);
        }

        #endregion
    }
}
