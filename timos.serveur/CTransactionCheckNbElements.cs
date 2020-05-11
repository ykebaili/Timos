using System;
using System.Collections.Generic;
using System.Text;
using sc2i.common;
using sc2i.multitiers.client;

namespace timos.serveur
{
    public class CTransactionCheckNbElements : IServiceTransactions
    {
        private int m_nbSessionId;

        public CTransactionCheckNbElements (int nSessionId)
        {
            m_nbSessionId = nSessionId;
        }
        public bool AccepteTransactionsImbriquees { get { return true; } }
        public int SessionId { get { return m_nbSessionId; } }

        public CResultAErreur BeginTrans()
        {
            return CLicenceCheckElementNb.GetInstance().GetLicenceCheckElementNbPourSession(m_nbSessionId).BeginTrans();
        }

        //-----------------------------------------------------------------------
        public CResultAErreur BeginTrans(System.Data.IsolationLevel isolationLevel)
        {
            return CLicenceCheckElementNb.GetInstance().GetLicenceCheckElementNbPourSession(m_nbSessionId).BeginTrans(isolationLevel);
        }

        
        //-----------------------------------------------------------------------
        public CResultAErreur RollbackTrans()
        {
           return CLicenceCheckElementNb.GetInstance().GetLicenceCheckElementNbPourSession(m_nbSessionId).RollbackTrans();
        }

        //-----------------------------------------------------------------------
        public CResultAErreur CommitTrans()
        {
            return CLicenceCheckElementNb.GetInstance().GetLicenceCheckElementNbPourSession(m_nbSessionId).CommitTrans();
        }//CommitTrans()


    }
}
