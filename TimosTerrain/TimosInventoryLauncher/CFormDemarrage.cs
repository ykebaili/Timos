using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.ServiceProcess;

using sc2i.FileUpdater;
using sc2i.common;
using sc2i.win32.common;

namespace TimosInventoryLauncher
{
	/// <summary>
	/// Description résumée de Form1.
	/// </summary>
	public class CFormDemarrage : System.Windows.Forms.Form, IInformeurDeSuivi
	{

		private CResultAErreur m_resultUpdate = CResultAErreur.True;
		private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label m_labelInfo;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CFormDemarrage()
		{
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			InitializeComponent();

			//
			// TODO : ajoutez le code du constructeur après l'appel à InitializeComponent
			//
		}

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_labelInfo = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.m_labelInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(603, 96);
            this.panel1.TabIndex = 2;
            // 
            // m_labelInfo
            // 
            this.m_labelInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.m_labelInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_labelInfo.ForeColor = System.Drawing.Color.Black;
            this.m_labelInfo.Location = new System.Drawing.Point(0, 77);
            this.m_labelInfo.Name = "m_labelInfo";
            this.m_labelInfo.Size = new System.Drawing.Size(601, 17);
            this.m_labelInfo.TabIndex = 1;
            this.m_labelInfo.Text = "Starting the Application|30000";
            this.m_labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox3.Image = global::TimosInventoryLauncher.Properties.Resources.flower_banner;
            this.pictureBox3.Location = new System.Drawing.Point(112, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(370, 77);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox2.Image = global::TimosInventoryLauncher.Properties.Resources.Logo_timos_Inventory;
            this.pictureBox2.Location = new System.Drawing.Point(482, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(119, 77);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::TimosInventoryLauncher.Properties.Resources.Logo_futurocom_seul;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 77);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // CFormDemarrage
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(603, 96);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CFormDemarrage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Starting|30001";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Point d'entrée principal de l'application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			BinaryServerFormatterSinkProvider serverProv = new BinaryServerFormatterSinkProvider();
			serverProv.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;

			BinaryClientFormatterSinkProvider clientProv = new BinaryClientFormatterSinkProvider();
			Hashtable table = new Hashtable();
			table["port"] = 0;
			TcpChannel channel = new TcpChannel ( table, clientProv, serverProv );

			ChannelServices.RegisterChannel(channel, false);
			Application.Run(new CFormDemarrage());
		}
		public void SetMessageInfoSuivi ( string strInfo )
		{
			m_labelInfo.Text = I.T("Update |30002")+strInfo;
			m_labelInfo.Refresh();
		}

		private string RepertoireAppli
		{
			get
			{
				return AppDomain.CurrentDomain.BaseDirectory+"TimosInventory";
			}
		}

		public void StartThreadUpdate()
		{
			string strPort = new CTimosInventoryRegistreLauncher().GetLocalPort().ToString();
			IInterfaceToServiceClient updater = (IInterfaceToServiceClient)Activator.GetObject ( typeof(IInterfaceToServiceClient), "tcp://127.0.0.1:"+
				strPort+"/IInterfaceToServiceClient" );
			try
			{
				if ( m_resultUpdate )
					m_resultUpdate = updater.UpdateApp ("SMTINV_WIN32_APP", RepertoireAppli, this, true);
				if ( !m_resultUpdate )
					m_resultUpdate.EmpileErreur(I.T("Client service error|30002"));
			}
			catch ( Exception e )
			{
				m_resultUpdate.EmpileErreur(new CErreurException(e));
				m_resultUpdate.EmpileErreur(I.T("Port error |30004 ")+strPort);
			}
		}

		private void LanceMiseAJour()
		{
			Thread th = new Thread(new ThreadStart(StartThreadUpdate));
			this.Show();
			this.Update();
			this.Refresh();
			th.Start();
			th.Join();

			if ( !m_resultUpdate )
            {
                m_resultUpdate.EmpileErreur("Update server is not available");
                    CFormAlerte.Afficher ( m_resultUpdate.Erreur );
            }
			//if ( m_resultUpdate )
			{
				string strProgToLaunch = (string)m_resultUpdate.Data;
				if ( strProgToLaunch != "" )
				{
					strProgToLaunch = RepertoireAppli+"\\"+strProgToLaunch;
					Process process = new Process();

					process.StartInfo.FileName = strProgToLaunch;
					process.StartInfo.WorkingDirectory = RepertoireAppli;
					process.StartInfo.UseShellExecute = true;
					process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
					try
					{
						process.Start();
					}
					catch ( Exception ex)
					{
						CFormAlerte.Afficher(I.T("Error while starting the application\r\n|30005")+ex.ToString(), EFormAlerteType.Erreur);
					}
					Close();
				}
			}
			/*else
			{
				m_resultUpdate.Erreur.EmpileErreur(I.T("Update Error|30006"));
				CFormAlerte.Afficher(m_resultUpdate.Erreur.ToString(), EFormAlerteType.Erreur);
			}*/
			Close();
		}


		private void Form1_Load(object sender, System.EventArgs e)
		{
            CWin32Traducteur.Translate(this);
			Refresh();
			LanceMiseAJour();
		}
	
	}
}
