using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sc2i.common.synchronisation
{
    
    internal class CDonneesSynchronisationBaseDistante
    {
        //Clé de la destination de la synchronisation :
        //Indique qui va être mis à jour par cette synchro
        private string m_strCleDestination = "";

        private DateTime? m_lastDateSynchro = null;
        private List<IOperationSynchronisation> m_listeOperations = new List<IOperationSynchronisation>();

        //---------------------------------------
        public CDonneesSynchronisationBaseDistante ( 
            string strCleDestination )
        {
            m_strCleDestination = strCleDestination;
        }

        //---------------------------------------
        /// <summary>
        /// Indique qui sera mis à jour par cette synchro
        /// </summary>
        public string CleDestination
        {
            get
            {
                return m_strCleDestination;
            }
        }

        //---------------------------------------
        public DateTime? LastDateSynchro
        {
            get
            {
                return m_lastDateSynchro;
            }
        }

        //---------------------------------------
        public void AddOperation ( IOperationSynchronisation operation )
        {
            lock ( this )
            {
                m_listeOperations.Add ( operation );
            }
        }

        //---------------------------------------
        public IEnumerable<IOperationSynchronisation> Operations
        {
            get
            {
                return m_listeOperations.AsReadOnly();
            }
        }

        //---------------------------------------
        private bool m_bTraitementEnCours = false;
        public CResultAErreur DoOperations(int nIdSession)
        {
            CResultAErreur result = CResultAErreur.True;
            List<IOperationSynchronisation> lstOperationsAFaire = null;
            lock (this)
            {
                if (m_bTraitementEnCours)
                    return result;
                m_bTraitementEnCours = true;
                lstOperationsAFaire = m_listeOperations;//Copie les opérations connues
                m_listeOperations = new List<IOperationSynchronisation>();//Vide les opérations à faire
                m_lastDateSynchro = DateTime.Now;
            }
            try
            {
                if (lstOperationsAFaire == null || lstOperationsAFaire.Count == 0)
                    return result;
                //Stocke les agents
                Dictionary<string, IAgentSynchronisation> dicAgents = new Dictionary<string, IAgentSynchronisation>();
                foreach (IOperationSynchronisation operation in lstOperationsAFaire.ToArray())
                {
                    IAgentSynchronisation agent = operation.GetAgent();
                    result = agent.DoOperation(operation, nIdSession);
                    if (result)
                    {
                        lstOperationsAFaire.RemoveAt(0);
                    }
                    else
                    {
                        result.EmpileErreur("Sync error");
                        return result;

                    }
                }
            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
            }
            finally
            {
                
                if (!result)
                //Si echec, remet en tête les opérations qui n'ont pas abouti
                {
                    lock (this)
                    {
                        m_listeOperations.InsertRange(0, lstOperationsAFaire);
                    }

                }
                m_bTraitementEnCours = false;
            }
            return result;
        }

        internal CResultAErreur IntegreOperations(CDonneesSynchronisationBaseDistante donnee)
        {
            lock (this)
            {
                foreach (IOperationSynchronisation operation in donnee.m_listeOperations)
                    m_listeOperations.Add(operation);
            }
            return CResultAErreur.True;
        }
    }
}
