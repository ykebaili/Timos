using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;

using timos.serveur;
using sc2i.common;

namespace TimosService
{
    public partial class TimosService : ServiceBase
    {
        public TimosService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            CTimosServeur.ArretServeur += new EventHandler(CTimosServeur_ArretServeur);
            CResultAErreur result = CTimosServeur.GetInstance().InitServeur(AppDomain.CurrentDomain.BaseDirectory + "\\timos.remoting.config", null);
            if (!result)
            {
                C2iEventLog.WriteErreur(result.Erreur.ToString());
                throw new Exception("Erreur while starting the service "+result.Erreur.ToString());
            }
        }

        void CTimosServeur_ArretServeur(object sender, EventArgs e)
        {
            Stop();
        }

        protected override void OnStop()
        {
            // TODO : ajoutez ici le code pour effectuer les destructions nécessaires à l'arrêt de votre service.
        }
    }
}
