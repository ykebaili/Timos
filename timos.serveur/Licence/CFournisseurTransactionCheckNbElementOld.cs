using System;
using System.Collections.Generic;
using System.Text;
using sc2i.common;
using sc2i.multitiers.client;
using sc2i.multitiers.server;

/*
 * STEF JANVIER 2011 : suppression du comptage des éléments
 * avec gestion de période. Conserve le code pour historique, ça peut resservir
 * 
namespace timos.serveur
{
    [AutoExec("Autoexec")]
    public class CFournisseurTransactionCheckNbElement : IFournisseurServiceTransactionPourSession
    {
        Dictionary<int, CTransactionCheckNbElements> m_DictionaryTransactionsCheckNbElt;
        private static CFournisseurTransactionCheckNbElement m_instance = null;

        public CFournisseurTransactionCheckNbElement()
        {
            m_DictionaryTransactionsCheckNbElt = new Dictionary<int, CTransactionCheckNbElements>();
        }

        public IServiceTransactions GetServiceTransaction(int nIdSession)
        {
            CTransactionCheckNbElements transactionsCheckNbElt;
            if (m_DictionaryTransactionsCheckNbElt.TryGetValue(nIdSession, out transactionsCheckNbElt))
                return transactionsCheckNbElt;
            else
            {
                transactionsCheckNbElt = new CTransactionCheckNbElements( nIdSession);
                m_DictionaryTransactionsCheckNbElt.Add(nIdSession, transactionsCheckNbElt);
                return transactionsCheckNbElt;
            }
        }

        //Les transactions sont executées sur la priorité la plus grande en premier
        public int PrioriteTransaction { get { return 100; } }

        ////////////////////////////////////////////////////////////////////////
        public static void Autoexec()
        {
            CSessionClientSurServeur.RegisterFournisseurTransactions(GetInstance());            
        }

        //-----------------------------------------------------------------------------
        public static CFournisseurTransactionCheckNbElement GetInstance()
        {
            if ( m_instance == null )
                m_instance = new CFournisseurTransactionCheckNbElement();
            return m_instance;
        }

        //-----------------------------------------------------------------------------
        internal static void OnCloseSession(int nIdSession)
        {
            if (GetInstance().m_DictionaryTransactionsCheckNbElt.ContainsKey(nIdSession))
                GetInstance().m_DictionaryTransactionsCheckNbElt.Remove(nIdSession);
        }
    }
}
*/