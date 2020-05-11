using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.common.trace;

namespace futurocom.snmp.mediation
{
    /// <summary>
    /// Permet de faire passer un objet "ServiceMediation" à travers les proxys
    /// </summary>
    public class CProxyServiceMediation : MarshalByRefObject, IServiceMediation
    {
        private IServiceMediation m_serviceMediation = null;

        public CProxyServiceMediation(IServiceMediation serviceMediation)
        {
            m_serviceMediation = serviceMediation;
        }

        //---------------------------------------------------
        public CConfigurationServiceMediation Configuration
        {
            get { return m_serviceMediation.Configuration; }
        }

        //---------------------------------------------------
        public bool IsStarted
        {
            get { return m_serviceMediation.IsStarted; }
        }

        //---------------------------------------------------
        public CResultAErreur Start()
        {
            return m_serviceMediation.Start();
        }

        //---------------------------------------------------
        public CResultAErreur Stop()
        {
            return m_serviceMediation.Stop();
        }

        //---------------------------------------------------
        public void AddTraceListener(IFuturocomTraceListener listener)
        {
            m_serviceMediation.AddTraceListener ( listener );
        }

        //---------------------------------------------------
        public void RemoveTraceListener(IFuturocomTraceListener listener)
        {
            m_serviceMediation.RemoveTraceListener ( listener );
        }

    }
}
