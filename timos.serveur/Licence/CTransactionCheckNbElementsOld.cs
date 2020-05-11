using System;
using System.Collections.Generic;
using System.Text;
using sc2i.common;
using sc2i.multitiers.client;
/*
 * STEF JANVIER 2011 : suppression du comptage des éléments
 * avec gestion de période. Conserve le code pour historique, ça peut resservir
 * 
namespace timos.serveur
{
    public class CTransactionCheckNbElements : IServiceTransactions, IObjetAttacheASession
    {
        private int m_nIdSession;

        public CTransactionCheckNbElements (int nIdSession)
        {
            m_nIdSession = nIdSession;
            CGestionnaireObjetsAttachesASession.AttacheObjet(nIdSession, this);
        }
        public bool AccepteTransactionsImbriquees { get { return true; } }
        public int SessionId { get { return m_nIdSession; } }

        public CResultAErreur BeginTrans()
        {
            return CLicenceCheckElementNb.GetInstance().GetLicenceCheckElementNbPourSession(m_nIdSession).BeginTrans();
        }

        //-----------------------------------------------------------------------
        public CResultAErreur BeginTrans(System.Data.IsolationLevel isolationLevel)
        {
            return CLicenceCheckElementNb.GetInstance().GetLicenceCheckElementNbPourSession(m_nIdSession).BeginTrans(isolationLevel);
        }

        
        //-----------------------------------------------------------------------
        public CResultAErreur RollbackTrans()
        {
           return CLicenceCheckElementNb.GetInstance().GetLicenceCheckElementNbPourSession(m_nIdSession).RollbackTrans();
        }

        //-----------------------------------------------------------------------
        public CResultAErreur CommitTrans()
        {
            return CLicenceCheckElementNb.GetInstance().GetLicenceCheckElementNbPourSession(m_nIdSession).CommitTrans();
        }//CommitTrans()



        #region IObjetAttacheASession Membres

        public string DescriptifObjetAttacheASession
        {
            get { return "Check elements transaction"; }
        }

        public void OnCloseSession()
        {
            CFournisseurTransactionCheckNbElement.OnCloseSession(m_nIdSession);
        }

        #endregion
    }
}
*/