using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using sc2i.common;

namespace timos.process
{
	/// <summary>
	/// Description résumée de CFormFermetureAutomatique.
	/// </summary>
	public class CFormFermetureAutomatique : System.Windows.Forms.Form
	{
		private DateTime m_dateExtinction = DateTime.Now.AddMinutes(1);
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button m_btnReduire;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label m_lblTempsRestant;
		private System.Windows.Forms.Timer m_timerSecondes;
		private System.Windows.Forms.LinkLabel linkLabel1;
        private Panel panel2;
		private System.ComponentModel.IContainer components;

		public CFormFermetureAutomatique()
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
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Code généré par le Concepteur Windows Form
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormFermetureAutomatique));
            this.m_lblTempsRestant = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_btnReduire = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.m_timerSecondes = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // m_lblTempsRestant
            // 
            this.m_lblTempsRestant.BackColor = System.Drawing.Color.White;
            this.m_lblTempsRestant.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblTempsRestant.ForeColor = System.Drawing.Color.Red;
            this.m_lblTempsRestant.Location = new System.Drawing.Point(61, 104);
            this.m_lblTempsRestant.Name = "m_lblTempsRestant";
            this.m_lblTempsRestant.Size = new System.Drawing.Size(389, 26);
            this.m_lblTempsRestant.TabIndex = 3;
            this.m_lblTempsRestant.Text = "Application will be closed in @1 seconds";
            this.m_lblTempsRestant.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(434, 69);
            this.label1.TabIndex = 0;
            this.label1.Text = "Maintenance operation. The application will be automatically shut down in 1 minut" +
                "e. Unsaved data will be lost. Please save any modified data.|1058";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // m_btnReduire
            // 
            this.m_btnReduire.BackColor = System.Drawing.SystemColors.Control;
            this.m_btnReduire.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnReduire.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_btnReduire.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_btnReduire.Location = new System.Drawing.Point(463, 0);
            this.m_btnReduire.Name = "m_btnReduire";
            this.m_btnReduire.Size = new System.Drawing.Size(31, 22);
            this.m_btnReduire.TabIndex = 2;
            this.m_btnReduire.Text = "__";
            this.m_btnReduire.UseVisualStyleBackColor = false;
            this.m_btnReduire.Click += new System.EventHandler(this.m_btnReduire_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.m_lblTempsRestant);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(496, 163);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_btnReduire);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(494, 22);
            this.panel2.TabIndex = 6;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Location = new System.Drawing.Point(190, 139);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(100, 23);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Close now|1057";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::timos.Properties.Resources.warning;
            this.pictureBox1.Location = new System.Drawing.Point(11, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // m_timerSecondes
            // 
            this.m_timerSecondes.Enabled = true;
            this.m_timerSecondes.Interval = 1000;
            this.m_timerSecondes.Tick += new System.EventHandler(this.m_timerSecondes_Tick);
            // 
            // CFormFermetureAutomatique
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(496, 163);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CFormFermetureAutomatique";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Automatic application closing|30257";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.CFormFermetureAutomatique_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
		private void AfficheDelai ( )
		{
            m_lblTempsRestant.Text = I.T("Application will be closed in @1 seconds|30255", GetTempsRestant().ToString());
            Text = I.T("@1 seconds left before closing|30256", GetTempsRestant().ToString());
			if ( GetTempsRestant()<1 )
				Close();
		}

		public int GetTempsRestant()
		{
			return (int)((TimeSpan)(m_dateExtinction-DateTime.Now)).TotalSeconds;
		}

		private void m_timerSecondes_Tick(object sender, System.EventArgs e)
		{
			AfficheDelai();
		}

		private void m_btnReduire_Click(object sender, System.EventArgs e)
		{
			if ( WindowState != FormWindowState.Minimized )
				WindowState = FormWindowState.Minimized;
		}

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			Close();
		}

        private void CFormFermetureAutomatique_Load(object sender, EventArgs e)
        {
            sc2i.win32.common.CWin32Traducteur.Translate(this);
        }

	}
}
