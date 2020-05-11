using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;

namespace TimosService
{
	/// <summary>
	/// Description résumée de CLysServeurInstaller.
	/// </summary>
	[RunInstaller(true)]
	public class CTimosServeurInstaller : System.Configuration.Install.Installer
	{
		private System.ServiceProcess.ServiceInstaller m_serviceInstaller;
		private System.ServiceProcess.ServiceController m_serviceController;
		private System.ServiceProcess.ServiceProcessInstaller m_processInstaller;
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		//private System.ComponentModel.Container components = null;

		public CTimosServeurInstaller()
		{
			// Cet appel est requis par le concepteur.
			InitializeComponent();

			// TODO : ajoutez les initialisations après l'appel à InitComponent
		}

		#region Component Designer generated code
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.m_serviceInstaller = new System.ServiceProcess.ServiceInstaller();
			this.m_processInstaller = new System.ServiceProcess.ServiceProcessInstaller();
			this.m_serviceController = new System.ServiceProcess.ServiceController();
			// 
			// m_serviceInstaller
			// 
			this.m_serviceInstaller.DisplayName = "Futurocom - Serveur Timos";
			this.m_serviceInstaller.ServiceName = "TimosService";
			this.m_serviceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
			this.m_serviceInstaller.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.m_serviceInstaller_AfterInstall);
			// 
			// m_processInstaller
			// 
			this.m_processInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
			this.m_processInstaller.Password = null;
			this.m_processInstaller.Username = null;
			this.m_processInstaller.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.m_processInstaller_AfterInstall);
			// 
			// m_serviceController
			// 
			this.m_serviceController.ServiceName = "TimosService";
			// 
			// CTimosServeurInstaller
			// 
			this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.m_processInstaller,
            this.m_serviceInstaller});

		}
		#endregion

		private void m_processInstaller_AfterInstall(object sender, System.Configuration.Install.InstallEventArgs e)
		{
			
		}

		private void m_serviceInstaller_AfterInstall(object sender, System.Configuration.Install.InstallEventArgs e)
		{
			m_serviceController.Start();
		}
	}
}
