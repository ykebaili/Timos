using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.multitiers.client;

namespace sc2i.common.synchronisation
{
    public class CGestionnaireTransactionsSynchroniseur : IFournisseurServiceTransactionPourSession
    {
        private static Dictionary<int, CTransactionSynchroniseur> m_dicTransactions = new Dictionary<int, CTransactionSynchroniseur>();

        private static CGestionnaireTransactionsSynchroniseur m_instance = null;

        public static CGestionnaireTransactionsSynchroniseur GetInstance()
        {
            if (m_instance == null)
                m_instance = new CGestionnaireTransactionsSynchroniseur();
            return m_instance;
        }

        public IServiceTransactions GetServiceTransaction(int nIdSession)
        {
            CTransactionSynchroniseur transaction = null;
            if ( !m_dicTransactions.TryGetValue(nIdSession, out transaction ))
            {
                transaction = new CTransactionSynchroniseur(nIdSession);
                m_dicTransactions[nIdSession] = transaction;
            }
            return transaction;
        }

        public int PrioriteTransaction
        {
            get { return 1000;}//transaction comitée en dernier (peu de change d'erreur)
        }

    }
}
