using System;
using System.Collections.Generic;
using System.Text;

using sc2i.common;
using sc2i.multitiers.client;


namespace timos.serveur
{
    public class CLicenceCheckElementNbPourSession : IServiceTransactions, IObjetAttacheASession
    {
        private CLicenceCheckElementNb m_LicenceCheckElementNb;
        private Stack<Dictionary<string, int>> m_StackModifEnCours;
        private int m_nIdSession;

        public CLicenceCheckElementNbPourSession(CLicenceCheckElementNb parent, int nIdSession)
        {
            m_LicenceCheckElementNb = parent;
            m_nIdSession = nIdSession;
            m_StackModifEnCours = new Stack<Dictionary<string, int>>();
            CGestionnaireObjetsAttachesASession.AttacheObjet(nIdSession, this);
        }

        public bool AccepteTransactionsImbriquees { get { return true; } }
        public int IdSession { get { return m_nIdSession; } }

        //-----------------------------------------------------------------------
        public CResultAErreur AddElements(string strIdTypeLimite, int nNbCreate)
        {
            CResultAErreur result = CResultAErreur.True;
            int nNB;

            result = m_LicenceCheckElementNb.CanCreate(strIdTypeLimite, nNbCreate);
            if (!result)
                return result;

            m_LicenceCheckElementNb.AddElements(strIdTypeLimite, nNbCreate);

			if (m_StackModifEnCours.Count == 0)
			{
				//Modif directe
				Dictionary<string, int> tmp = new Dictionary<string, int>();
				tmp.Add(strIdTypeLimite, nNbCreate);
                return result;
				//return m_LicenceCheckElementNb.Save(tmp);
			}		


            Dictionary<string, int> dictionary = m_StackModifEnCours.Peek();
            if (dictionary.TryGetValue(strIdTypeLimite, out nNB))
            {
                nNB += nNbCreate;
                dictionary[strIdTypeLimite] = nNB;
            }
            else
                dictionary.Add(strIdTypeLimite, nNbCreate);

            return result;
        }

        
        public CResultAErreur BeginTrans()
        {
            return LicenceBeginTrans();
        }

        //-----------------------------------------------------------------------
        public CResultAErreur BeginTrans(System.Data.IsolationLevel isolationLevel)
        {
            return LicenceBeginTrans();
        }

        //-----------------------------------------------------------------------
        public CResultAErreur LicenceBeginTrans()
        {
            CResultAErreur result = CResultAErreur.True;
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            m_StackModifEnCours.Push(dictionary);

            return result;
        }


        //-----------------------------------------------------------------------
        public CResultAErreur RollbackTrans()
        {
            CResultAErreur result = CResultAErreur.True;
            Dictionary<string, int> dictionary = m_StackModifEnCours.Pop();//supprime le dernier dictionary
            foreach (KeyValuePair<string, int> kvp in dictionary)
            {
                m_LicenceCheckElementNb.FreeElements(kvp.Key, kvp.Value);
            }
            return result;
        }

        //-----------------------------------------------------------------------
        public CResultAErreur CommitTrans()
        {
            CResultAErreur result = CResultAErreur.True;

            if (m_StackModifEnCours.Count > 1)
            {
                Dictionary<string, int> dictionaryLast = m_StackModifEnCours.Pop();//supprime le dernier dictionary
                Dictionary<string, int> dictionaryPrev = m_StackModifEnCours.Peek();
                int nNB;

                foreach (KeyValuePair<string, int> kvp in dictionaryLast)
                {
                    if (dictionaryPrev.TryGetValue(kvp.Key, out nNB))
                    {
                        nNB += kvp.Value;
                        dictionaryPrev[kvp.Key] = nNB;
                    }
                    else
                        dictionaryPrev.Add(kvp.Key, kvp.Value);
                }
            }
            else if (m_StackModifEnCours.Count == 1)
              result = m_LicenceCheckElementNb.Save(m_StackModifEnCours.Pop());//supprime le dernier dictionary
            
            return result;
        }//CommitTrans()


        #region IObjetAttacheASession Membres

        public string DescriptifObjetAttacheASession
        {
            get { return "Licence check"; }
        }

        public void OnCloseSession()
        {
            CLicenceCheckElementNb.OnCloseSession(m_nIdSession);
        }

        #endregion
    }
}
