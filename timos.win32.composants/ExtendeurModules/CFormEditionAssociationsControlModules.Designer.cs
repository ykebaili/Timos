namespace timos
{
	partial class CFormEditionAssociationsControlModules
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.m_ctrlModulesApp = new sc2i.win32.common.CCtrlVidoirDevidoir();
            this.m_tabControl = new System.Windows.Forms.TabControl();
            this.pageModulesApplicatif = new System.Windows.Forms.TabPage();
            this.pageModulesClient = new System.Windows.Forms.TabPage();
            this.m_ctrlModulesClient = new sc2i.win32.common.CCtrlVidoirDevidoir();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_panBas = new System.Windows.Forms.Panel();
            this.m_txtDescrip = new System.Windows.Forms.TextBox();
            this.m_lblDescrip = new System.Windows.Forms.Label();
            this.m_tabControl.SuspendLayout();
            this.pageModulesApplicatif.SuspendLayout();
            this.pageModulesClient.SuspendLayout();
            this.m_panBas.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_ctrlModulesApp
            // 
            this.m_ctrlModulesApp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_ctrlModulesApp.Location = new System.Drawing.Point(3, 3);
            this.m_ctrlModulesApp.LockEdition = false;
            this.m_ctrlModulesApp.Name = "m_ctrlModulesApp";
            this.m_ctrlModulesApp.Size = new System.Drawing.Size(598, 266);
            this.m_ctrlModulesApp.TabIndex = 0;
            this.m_ctrlModulesApp.ChangementSelection += new System.EventHandler(this.m_ctrlModulesApp_ChangementSelection);
            // 
            // m_tabControl
            // 
            this.m_tabControl.Controls.Add(this.pageModulesApplicatif);
            this.m_tabControl.Controls.Add(this.pageModulesClient);
            this.m_tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tabControl.Location = new System.Drawing.Point(0, 0);
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.Size = new System.Drawing.Size(612, 298);
            this.m_tabControl.TabIndex = 1;
            // 
            // pageModulesApplicatif
            // 
            this.pageModulesApplicatif.Controls.Add(this.m_ctrlModulesApp);
            this.pageModulesApplicatif.Location = new System.Drawing.Point(4, 22);
            this.pageModulesApplicatif.Name = "pageModulesApplicatif";
            this.pageModulesApplicatif.Padding = new System.Windows.Forms.Padding(3);
            this.pageModulesApplicatif.Size = new System.Drawing.Size(604, 272);
            this.pageModulesApplicatif.TabIndex = 0;
            this.pageModulesApplicatif.Text = "Application Modules|30001";
            this.pageModulesApplicatif.UseVisualStyleBackColor = true;
            // 
            // pageModulesClient
            // 
            this.pageModulesClient.Controls.Add(this.m_ctrlModulesClient);
            this.pageModulesClient.Location = new System.Drawing.Point(4, 22);
            this.pageModulesClient.Name = "pageModulesClient";
            this.pageModulesClient.Padding = new System.Windows.Forms.Padding(3);
            this.pageModulesClient.Size = new System.Drawing.Size(604, 272);
            this.pageModulesClient.TabIndex = 1;
            this.pageModulesClient.Text = "Client Modules|30002";
            this.pageModulesClient.UseVisualStyleBackColor = true;
            // 
            // m_ctrlModulesClient
            // 
            this.m_ctrlModulesClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_ctrlModulesClient.Location = new System.Drawing.Point(3, 3);
            this.m_ctrlModulesClient.LockEdition = false;
            this.m_ctrlModulesClient.Name = "m_ctrlModulesClient";
            this.m_ctrlModulesClient.Size = new System.Drawing.Size(598, 266);
            this.m_ctrlModulesClient.TabIndex = 1;
            this.m_ctrlModulesClient.ChangementSelection += new System.EventHandler(this.m_ctrlModulesClient_ChangementSelection);
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(129, 113);
            this.panel1.TabIndex = 2;
            // 
            // m_panBas
            // 
            this.m_panBas.BackColor = System.Drawing.Color.White;
            this.m_panBas.Controls.Add(this.m_txtDescrip);
            this.m_panBas.Controls.Add(this.m_lblDescrip);
            this.m_panBas.Controls.Add(this.panel1);
            this.m_panBas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_panBas.Location = new System.Drawing.Point(0, 298);
            this.m_panBas.Name = "m_panBas";
            this.m_panBas.Size = new System.Drawing.Size(612, 113);
            this.m_panBas.TabIndex = 3;
            // 
            // m_txtDescrip
            // 
            this.m_txtDescrip.BackColor = System.Drawing.Color.White;
            this.m_txtDescrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_txtDescrip.Location = new System.Drawing.Point(129, 23);
            this.m_txtDescrip.Multiline = true;
            this.m_txtDescrip.Name = "m_txtDescrip";
            this.m_txtDescrip.ReadOnly = true;
            this.m_txtDescrip.Size = new System.Drawing.Size(483, 90);
            this.m_txtDescrip.TabIndex = 4;
            this.m_txtDescrip.Visible = false;
            // 
            // m_lblDescrip
            // 
            this.m_lblDescrip.AutoSize = true;
            this.m_lblDescrip.Location = new System.Drawing.Point(136, 7);
            this.m_lblDescrip.Name = "m_lblDescrip";
            this.m_lblDescrip.Size = new System.Drawing.Size(128, 13);
            this.m_lblDescrip.TabIndex = 3;
            this.m_lblDescrip.Text = "Module description|30000";
            this.m_lblDescrip.Visible = false;
            // 
            // CFormEditionAssociationsControlModules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(612, 411);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.m_panBas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CFormEditionAssociationsControlModules";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List of modules associated with the control|30003";
            this.m_tabControl.ResumeLayout(false);
            this.pageModulesApplicatif.ResumeLayout(false);
            this.pageModulesClient.ResumeLayout(false);
            this.m_panBas.ResumeLayout(false);
            this.m_panBas.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private sc2i.win32.common.CCtrlVidoirDevidoir m_ctrlModulesApp;
		private System.Windows.Forms.TabControl m_tabControl;
		private System.Windows.Forms.TabPage pageModulesApplicatif;
		private System.Windows.Forms.TabPage pageModulesClient;
		private sc2i.win32.common.CCtrlVidoirDevidoir m_ctrlModulesClient;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel m_panBas;
		private System.Windows.Forms.Label m_lblDescrip;
		private System.Windows.Forms.TextBox m_txtDescrip;
	}
}
