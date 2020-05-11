using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.multitiers.client;
using System.Data;

namespace sc2i.common.synchronisation
{
    public class CTransactionSynchroniseur : IServiceTransactions
    {
        private int m_nIdSession;

        private Stack<CSynchroniseurBaseDistante> m_stackSynchroniseurs = new Stack<CSynchroniseurBaseDistante>();

        public CTransactionSynchroniseur(int nIdSession)
        {
            m_nIdSession = nIdSession;
        }

        //----------------------------------------------
        public void AddOperation(string strCleBaseDistante, IOperationSynchronisation operation)
        {
            m_stackSynchroniseurs.Peek().AddOperation(null, strCleBaseDistante, operation);
        }

        //----------------------------------------------
        public bool AccepteTransactionsImbriquees
        {
            get { return true; }
        }

        //----------------------------------------------
        public CResultAErreur BeginTrans(IsolationLevel isolationLevel)
        {
            lock (this)
            {
                CResultAErreur result = CResultAErreur.True;
                m_stackSynchroniseurs.Push(new CSynchroniseurBaseDistante());
                return result;
            }
        }

        //----------------------------------------------
        public CResultAErreur BeginTrans()
        {
            return BeginTrans(IsolationLevel.ReadCommitted);
        }

        //----------------------------------------------
        public CResultAErreur CommitTrans()
        {
            lock (this)
            {
                //Récupère le synchroniseur le plus récent
                CSynchroniseurBaseDistante synchroniseur = m_stackSynchroniseurs.Pop();
                if (m_stackSynchroniseurs.Count > 0)
                {
                    //Copie les données du synchroniseur dans le prochain (transactions imbriquées)
                    return m_stackSynchroniseurs.Peek().IntegreOperations(synchroniseur);
                }
                else
                {
                    CSynchroniseurBaseDistante synchro = CSynchroniseurBaseDistante.GetSynchroniseur(m_nIdSession);
                        CResultAErreur result = synchro.IntegreOperations(synchroniseur);
                    if ( !result )
                        return result;
                    result = synchro.TraiteAll();
                    return result;
                }
            }
        }

        //----------------------------------------------
        public CResultAErreur RollbackTrans()
        {
            m_stackSynchroniseurs.Pop();
            return CResultAErreur.True;
        }

        //----------------------------------------------
        public bool IsInTrans()
        {
            return m_stackSynchroniseurs.Count > 0;
        }   
    }
}
