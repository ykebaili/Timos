using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;


using sc2i.common;
using System.Runtime.Remoting;
using futurocom.snmp.Proxy;
using futurocom.snmp.mediation;

namespace ServiceMediation
{
    public partial class TimosMediationService : ServiceBase
    {
        public TimosMediationService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            try
            {
                C2iEventLog.Init("Timos", NiveauBavardage.VraiPiplette);
                RemotingConfiguration.Configure(AppDomain.CurrentDomain.BaseDirectory + "\\serviceMediation.remoting.config", false);
                RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.On;
                CAutoexecuteurClasses.RunAllAutoexecs();
                CSnmpProxyConfiguration.GetInstance().MiseAJour(true);
                CServiceMediation.GetDefaultInstance().Configuration.MettreAJour(true, true);
            }
            catch (Exception e)
            {
                C2iEventLog.WriteErreur(e.Message);
                throw e;
            }
        }

       

        protected override void OnStop()
        {
            // TODO : ajoutez ici le code pour effectuer les destructions nécessaires à l'arrêt de votre service.
        }
    }
}
