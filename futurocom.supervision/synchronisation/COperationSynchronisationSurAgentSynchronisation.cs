using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace sc2i.common.synchronisation
{
    public enum EOperationSynchronisationSurAgentSynchronisation
    {
        CreateOrUpdate = 0,
        Delete
    }

    public class COperationSynchronisationSurAgentSynchronisation : IOperationSynchronisation
    {
        private Type m_typeAgent = null;
        private string m_strParametresAgentSynchro = "";
        private string m_strIdElementASynchroniser = "";
        private EOperationSynchronisationSurAgentSynchronisation m_operation = EOperationSynchronisationSurAgentSynchronisation.CreateOrUpdate;
        private DateTime m_dateTimeCreationOperation = DateTime.Now;

        public COperationSynchronisationSurAgentSynchronisation()
        {
        }

        public COperationSynchronisationSurAgentSynchronisation(
            Type typeAgentSynchro,
            string strParametresAgentSynchro,
            EOperationSynchronisationSurAgentSynchronisation operation,
            string strIdElementASynchroniser)
        {
            m_typeAgent = typeAgentSynchro;
            m_strParametresAgentSynchro = strParametresAgentSynchro;
            m_operation = operation;
            m_strIdElementASynchroniser = strIdElementASynchroniser;
            
        }

        //----------------------------------------------
        public IAgentSynchronisation GetAgent()
        {
            IAgentSynchronisation agent = Activator.CreateInstance(m_typeAgent) as IAgentSynchronisation;
            agent.Init(m_strParametresAgentSynchro);
            return agent;
        }

        //----------------------------------------------
        public Type TypeAgentSynchro
        {
            get
            {
                return m_typeAgent;
            }
        }

        //----------------------------------------------
        public string ParametresAgentSynchro
        {
            get
            {
                return m_strParametresAgentSynchro;
            }
        }


        //----------------------------------------------
        public EOperationSynchronisationSurAgentSynchronisation Operation
        {
            get
            {
                return m_operation;
            }
            set
            {
                m_operation = value;
            }
        }

        //----------------------------------------------
        public DateTime DateCreationOperation
        {
            get
            {
                return m_dateTimeCreationOperation;
            }
        }

        //----------------------------------------------
        public string IdElementASynchroniser
        {
            get
            {
                return m_strIdElementASynchroniser;
            }
            set
            {
                m_strIdElementASynchroniser = value;
            }
        }

        

    }
}
