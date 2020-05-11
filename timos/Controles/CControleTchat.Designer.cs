namespace timos
{
	partial class CControleChat
	{
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		/// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Code généré par le Concepteur Windows Form

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CControleChat));
            this.m_txtToSend = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.m_tnEnvoyer = new System.Windows.Forms.Button();
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_txtMessage = new System.Windows.Forms.TextBox();
            this.m_panelUser = new System.Windows.Forms.Panel();
            this.m_lblUser = new System.Windows.Forms.Label();
            this.m_imageMSN = new System.Windows.Forms.PictureBox();
            this.m_panelHeader = new System.Windows.Forms.Panel();
            this.m_btnFermer = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_wndListeMessages = new System.Windows.Forms.ListView();
            this.m_colAttente = new System.Windows.Forms.ColumnHeader();
            this.m_timerEmpile = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.m_panelUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageMSN)).BeginInit();
            this.m_panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnFermer)).BeginInit();
            this.SuspendLayout();
            // 
            // m_txtToSend
            // 
            this.m_txtToSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtToSend.Location = new System.Drawing.Point(0, 13);
            this.m_txtToSend.Multiline = true;
            this.m_txtToSend.Name = "m_txtToSend";
            this.m_txtToSend.Size = new System.Drawing.Size(261, 67);
            this.m_extStyle.SetStyleBackColor(this.m_txtToSend, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtToSend, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtToSend.TabIndex = 1;
            this.m_txtToSend.KeyUp += new System.Windows.Forms.KeyEventHandler(this.m_txtToSend_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_txtToSend);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.m_tnEnvoyer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 271);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(261, 100);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(41)))), ((int)(((byte)(131)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 13);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter your message here|718";
            // 
            // m_tnEnvoyer
            // 
            this.m_tnEnvoyer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_tnEnvoyer.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_tnEnvoyer.Location = new System.Drawing.Point(0, 80);
            this.m_tnEnvoyer.Name = "m_tnEnvoyer";
            this.m_tnEnvoyer.Size = new System.Drawing.Size(261, 20);
            this.m_extStyle.SetStyleBackColor(this.m_tnEnvoyer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tnEnvoyer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tnEnvoyer.TabIndex = 3;
            this.m_tnEnvoyer.Text = "Send it|719";
            this.m_tnEnvoyer.UseVisualStyleBackColor = true;
            this.m_tnEnvoyer.Click += new System.EventHandler(this.m_tnEnvoyer_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_txtMessage);
            this.panel2.Controls.Add(this.m_panelUser);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 21);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(261, 250);
            this.m_extStyle.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel2.TabIndex = 3;
            // 
            // m_txtMessage
            // 
            this.m_txtMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtMessage.Location = new System.Drawing.Point(0, 26);
            this.m_txtMessage.Multiline = true;
            this.m_txtMessage.Name = "m_txtMessage";
            this.m_txtMessage.ReadOnly = true;
            this.m_txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.m_txtMessage.Size = new System.Drawing.Size(261, 224);
            this.m_extStyle.SetStyleBackColor(this.m_txtMessage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtMessage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtMessage.TabIndex = 2;
            // 
            // m_panelUser
            // 
            this.m_panelUser.BackColor = System.Drawing.Color.White;
            this.m_panelUser.Controls.Add(this.m_lblUser);
            this.m_panelUser.Controls.Add(this.m_imageMSN);
            this.m_panelUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelUser.ForeColor = System.Drawing.Color.Black;
            this.m_panelUser.Location = new System.Drawing.Point(0, 0);
            this.m_panelUser.Name = "m_panelUser";
            this.m_panelUser.Size = new System.Drawing.Size(261, 26);
            this.m_extStyle.SetStyleBackColor(this.m_panelUser, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelUser, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelUser.TabIndex = 1;
            // 
            // m_lblUser
            // 
            this.m_lblUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lblUser.Location = new System.Drawing.Point(27, 0);
            this.m_lblUser.Name = "m_lblUser";
            this.m_lblUser.Size = new System.Drawing.Size(234, 26);
            this.m_extStyle.SetStyleBackColor(this.m_lblUser, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblUser, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblUser.TabIndex = 1;
            // 
            // m_imageMSN
            // 
            this.m_imageMSN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_imageMSN.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_imageMSN.Image = ((System.Drawing.Image)(resources.GetObject("m_imageMSN.Image")));
            this.m_imageMSN.Location = new System.Drawing.Point(0, 0);
            this.m_imageMSN.Name = "m_imageMSN";
            this.m_imageMSN.Size = new System.Drawing.Size(27, 26);
            this.m_imageMSN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_extStyle.SetStyleBackColor(this.m_imageMSN, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_imageMSN, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_imageMSN.TabIndex = 0;
            this.m_imageMSN.TabStop = false;
            this.m_imageMSN.Click += new System.EventHandler(this.m_imageMSN_Click);
            // 
            // m_panelHeader
            // 
            this.m_panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(41)))), ((int)(((byte)(131)))));
            this.m_panelHeader.Controls.Add(this.m_btnFermer);
            this.m_panelHeader.Controls.Add(this.label2);
            this.m_panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelHeader.ForeColor = System.Drawing.Color.White;
            this.m_panelHeader.Location = new System.Drawing.Point(0, 0);
            this.m_panelHeader.Name = "m_panelHeader";
            this.m_panelHeader.Size = new System.Drawing.Size(261, 21);
            this.m_extStyle.SetStyleBackColor(this.m_panelHeader, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelHeader, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelHeader.TabIndex = 2;
            // 
            // m_btnFermer
            // 
            this.m_btnFermer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnFermer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnFermer.Image = ((System.Drawing.Image)(resources.GetObject("m_btnFermer.Image")));
            this.m_btnFermer.Location = new System.Drawing.Point(244, 3);
            this.m_btnFermer.Name = "m_btnFermer";
            this.m_btnFermer.Size = new System.Drawing.Size(14, 14);
            this.m_btnFermer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.m_extStyle.SetStyleBackColor(this.m_btnFermer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnFermer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnFermer.TabIndex = 5;
            this.m_btnFermer.TabStop = false;
            this.m_btnFermer.Click += new System.EventHandler(this.m_btnFermer_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 0;
            this.label2.Text = "Chat|717";
            // 
            // m_wndListeMessages
            // 
            this.m_wndListeMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_colAttente});
            this.m_wndListeMessages.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_wndListeMessages.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_wndListeMessages.Location = new System.Drawing.Point(0, 371);
            this.m_wndListeMessages.Name = "m_wndListeMessages";
            this.m_wndListeMessages.Size = new System.Drawing.Size(261, 65);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeMessages, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeMessages, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeMessages.TabIndex = 4;
            this.m_wndListeMessages.UseCompatibleStateImageBehavior = false;
            this.m_wndListeMessages.View = System.Windows.Forms.View.Details;
            this.m_wndListeMessages.Visible = false;
            this.m_wndListeMessages.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.m_wndListeMessages_MouseDoubleClick);
            // 
            // m_colAttente
            // 
            this.m_colAttente.Width = 239;
            // 
            // m_timerEmpile
            // 
            this.m_timerEmpile.Enabled = true;
            this.m_timerEmpile.Interval = 1000;
            this.m_timerEmpile.Tick += new System.EventHandler(this.m_timerEmpile_Tick);
            // 
            // CControleChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_panelHeader);
            this.Controls.Add(this.m_wndListeMessages);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "CControleChat";
            this.Size = new System.Drawing.Size(261, 436);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTexteFenetre);
            this.Load += new System.EventHandler(this.CControleChat_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.m_panelUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_imageMSN)).EndInit();
            this.m_panelHeader.ResumeLayout(false);
            this.m_panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnFermer)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private sc2i.win32.common.CExtStyle m_extStyle;
		private System.Windows.Forms.TextBox m_txtToSend;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel m_panelUser;
		private System.Windows.Forms.Label m_lblUser;
		private System.Windows.Forms.PictureBox m_imageMSN;
		private System.Windows.Forms.Button m_tnEnvoyer;
		private System.Windows.Forms.Panel m_panelHeader;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox m_btnFermer;
		private System.Windows.Forms.TextBox m_txtMessage;
		private System.Windows.Forms.ListView m_wndListeMessages;
		private System.Windows.Forms.ColumnHeader m_colAttente;
		private System.Windows.Forms.Timer m_timerEmpile;
	}
}