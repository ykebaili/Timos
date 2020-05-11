namespace HelpExtender
{
	partial class CFormAide
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormAide));
            this.m_txtAide = new System.Windows.Forms.RichTextBox();
            this.m_panelTop = new System.Windows.Forms.Panel();
            this.m_chkModeEdition = new System.Windows.Forms.CheckBox();
            this.ctrl_voirAussi = new HelpExtender.CCtrlVoirAussi();
            this.pan_separateur1 = new System.Windows.Forms.Panel();
            this.m_btnHelp = new System.Windows.Forms.PictureBox();
            this.pan_separateur2 = new System.Windows.Forms.Panel();
            this.m_btnEditer = new System.Windows.Forms.PictureBox();
            this.pan_separateur3 = new System.Windows.Forms.Panel();
            this.m_btnMenu = new System.Windows.Forms.PictureBox();
            this.pan_separateur4 = new System.Windows.Forms.Panel();
            this.btn_precedant = new System.Windows.Forms.Button();
            this.btn_suivant = new System.Windows.Forms.Button();
            this.m_lblTitre = new System.Windows.Forms.Label();
            this.visualiseur = new HelpExtender.CtrlHelpViewer();
            this.m_imagesCadenas = new System.Windows.Forms.ImageList(this.components);
            this.m_panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnEditer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // m_txtAide
            // 
            this.m_txtAide.AcceptsTab = true;
            this.m_txtAide.BackColor = System.Drawing.Color.White;
            this.m_txtAide.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtAide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtAide.Location = new System.Drawing.Point(0, 54);
            this.m_txtAide.Name = "m_txtAide";
            this.m_txtAide.ReadOnly = true;
            this.m_txtAide.Size = new System.Drawing.Size(317, 465);
            this.m_txtAide.TabIndex = 0;
            this.m_txtAide.Text = "";
            // 
            // m_panelTop
            // 
            this.m_panelTop.Controls.Add(this.m_chkModeEdition);
            this.m_panelTop.Controls.Add(this.ctrl_voirAussi);
            this.m_panelTop.Controls.Add(this.pan_separateur1);
            this.m_panelTop.Controls.Add(this.m_btnHelp);
            this.m_panelTop.Controls.Add(this.pan_separateur2);
            this.m_panelTop.Controls.Add(this.m_btnEditer);
            this.m_panelTop.Controls.Add(this.pan_separateur3);
            this.m_panelTop.Controls.Add(this.m_btnMenu);
            this.m_panelTop.Controls.Add(this.pan_separateur4);
            this.m_panelTop.Controls.Add(this.btn_precedant);
            this.m_panelTop.Controls.Add(this.btn_suivant);
            this.m_panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelTop.Location = new System.Drawing.Point(0, 0);
            this.m_panelTop.Name = "m_panelTop";
            this.m_panelTop.Size = new System.Drawing.Size(317, 23);
            this.m_panelTop.TabIndex = 1;
            // 
            // m_chkModeEdition
            // 
            this.m_chkModeEdition.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_chkModeEdition.AutoSize = true;
            this.m_chkModeEdition.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_chkModeEdition.Image = ((System.Drawing.Image)(resources.GetObject("m_chkModeEdition.Image")));
            this.m_chkModeEdition.Location = new System.Drawing.Point(153, 0);
            this.m_chkModeEdition.Name = "m_chkModeEdition";
            this.m_chkModeEdition.Size = new System.Drawing.Size(20, 23);
            this.m_chkModeEdition.TabIndex = 12;
            this.m_chkModeEdition.UseVisualStyleBackColor = true;
            this.m_chkModeEdition.CheckedChanged += new System.EventHandler(this.m_chkModeEdition_CheckedChanged);
            // 
            // ctrl_voirAussi
            // 
            this.ctrl_voirAussi.Dock = System.Windows.Forms.DockStyle.Left;
            this.ctrl_voirAussi.FaireClignoterLesControlsAuSurvol = false;
            this.ctrl_voirAussi.Location = new System.Drawing.Point(0, 0);
            this.ctrl_voirAussi.Name = "ctrl_voirAussi";
            this.ctrl_voirAussi.Size = new System.Drawing.Size(108, 23);
            this.ctrl_voirAussi.TabIndex = 5;
            this.ctrl_voirAussi.TitreMenu = "";
            this.ctrl_voirAussi.ClicSurElement += new System.EventHandler(this.ctrl_voirAussi_ClicSurElement);
            // 
            // pan_separateur1
            // 
            this.pan_separateur1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pan_separateur1.Location = new System.Drawing.Point(173, 0);
            this.pan_separateur1.Name = "pan_separateur1";
            this.pan_separateur1.Size = new System.Drawing.Size(5, 23);
            this.pan_separateur1.TabIndex = 5;
            // 
            // m_btnHelp
            // 
            this.m_btnHelp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_btnHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnHelp.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("m_btnHelp.Image")));
            this.m_btnHelp.Location = new System.Drawing.Point(178, 0);
            this.m_btnHelp.Name = "m_btnHelp";
            this.m_btnHelp.Size = new System.Drawing.Size(26, 23);
            this.m_btnHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_btnHelp.TabIndex = 2;
            this.m_btnHelp.TabStop = false;
            this.m_btnHelp.Click += new System.EventHandler(this.m_btnHelp_Click);
            // 
            // pan_separateur2
            // 
            this.pan_separateur2.Dock = System.Windows.Forms.DockStyle.Right;
            this.pan_separateur2.Location = new System.Drawing.Point(204, 0);
            this.pan_separateur2.Name = "pan_separateur2";
            this.pan_separateur2.Size = new System.Drawing.Size(5, 23);
            this.pan_separateur2.TabIndex = 6;
            // 
            // m_btnEditer
            // 
            this.m_btnEditer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_btnEditer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnEditer.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnEditer.Image = ((System.Drawing.Image)(resources.GetObject("m_btnEditer.Image")));
            this.m_btnEditer.Location = new System.Drawing.Point(209, 0);
            this.m_btnEditer.Name = "m_btnEditer";
            this.m_btnEditer.Size = new System.Drawing.Size(25, 23);
            this.m_btnEditer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_btnEditer.TabIndex = 1;
            this.m_btnEditer.TabStop = false;
            this.m_btnEditer.Visible = false;
            this.m_btnEditer.Click += new System.EventHandler(this.m_btnEditer_Click);
            // 
            // pan_separateur3
            // 
            this.pan_separateur3.Dock = System.Windows.Forms.DockStyle.Right;
            this.pan_separateur3.Location = new System.Drawing.Point(234, 0);
            this.pan_separateur3.Name = "pan_separateur3";
            this.pan_separateur3.Size = new System.Drawing.Size(5, 23);
            this.pan_separateur3.TabIndex = 7;
            // 
            // m_btnMenu
            // 
            this.m_btnMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_btnMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnMenu.Image = ((System.Drawing.Image)(resources.GetObject("m_btnMenu.Image")));
            this.m_btnMenu.Location = new System.Drawing.Point(239, 0);
            this.m_btnMenu.Name = "m_btnMenu";
            this.m_btnMenu.Size = new System.Drawing.Size(25, 23);
            this.m_btnMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_btnMenu.TabIndex = 9;
            this.m_btnMenu.TabStop = false;
            this.m_btnMenu.Click += new System.EventHandler(this.m_btnMenu_Click);
            // 
            // pan_separateur4
            // 
            this.pan_separateur4.Dock = System.Windows.Forms.DockStyle.Right;
            this.pan_separateur4.Location = new System.Drawing.Point(264, 0);
            this.pan_separateur4.Name = "pan_separateur4";
            this.pan_separateur4.Size = new System.Drawing.Size(5, 23);
            this.pan_separateur4.TabIndex = 8;
            // 
            // btn_precedant
            // 
            this.btn_precedant.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_precedant.Location = new System.Drawing.Point(269, 0);
            this.btn_precedant.Name = "btn_precedant";
            this.btn_precedant.Size = new System.Drawing.Size(24, 23);
            this.btn_precedant.TabIndex = 11;
            this.btn_precedant.Text = "<";
            this.btn_precedant.UseVisualStyleBackColor = true;
            this.btn_precedant.Click += new System.EventHandler(this.btn_precedant_Click);
            // 
            // btn_suivant
            // 
            this.btn_suivant.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_suivant.Location = new System.Drawing.Point(293, 0);
            this.btn_suivant.Name = "btn_suivant";
            this.btn_suivant.Size = new System.Drawing.Size(24, 23);
            this.btn_suivant.TabIndex = 10;
            this.btn_suivant.Text = ">";
            this.btn_suivant.UseVisualStyleBackColor = true;
            this.btn_suivant.Click += new System.EventHandler(this.btn_suivant_Click);
            // 
            // m_lblTitre
            // 
            this.m_lblTitre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.m_lblTitre.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_lblTitre.Location = new System.Drawing.Point(0, 23);
            this.m_lblTitre.Name = "m_lblTitre";
            this.m_lblTitre.Size = new System.Drawing.Size(317, 31);
            this.m_lblTitre.TabIndex = 2;
            // 
            // visualiseur
            // 
            this.visualiseur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.visualiseur.LiensVersHelpActifs = true;
            this.visualiseur.Location = new System.Drawing.Point(0, 54);
            this.visualiseur.MinimumSize = new System.Drawing.Size(20, 20);
            this.visualiseur.Name = "visualiseur";
            this.visualiseur.Size = new System.Drawing.Size(317, 465);
            this.visualiseur.TabIndex = 4;
            this.visualiseur.NavigationVersHelp += new HelpExtender.EvenementNavigationVersAide(this.visualiseur_NavigationVersHelp);
            // 
            // m_imagesCadenas
            // 
            this.m_imagesCadenas.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imagesCadenas.ImageStream")));
            this.m_imagesCadenas.TransparentColor = System.Drawing.Color.Transparent;
            this.m_imagesCadenas.Images.SetKeyName(0, "modifiab.bmp");
            this.m_imagesCadenas.Images.SetKeyName(1, "readonl_.bmp");
            // 
            // CFormAide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(317, 519);
            this.Controls.Add(this.visualiseur);
            this.Controls.Add(this.m_txtAide);
            this.Controls.Add(this.m_lblTitre);
            this.Controls.Add(this.m_panelTop);
            this.Name = "CFormAide";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Help|30006";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CFormAide_FormClosing);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CFormAide_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CFormAide_MouseDown);
            this.m_panelTop.ResumeLayout(false);
            this.m_panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnEditer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnMenu)).EndInit();
            this.ResumeLayout(false);

		}



		#endregion

		private System.Windows.Forms.RichTextBox m_txtAide;
		private System.Windows.Forms.Panel m_panelTop;
		private System.Windows.Forms.Label m_lblTitre;
		private System.Windows.Forms.PictureBox m_btnEditer;
		private System.Windows.Forms.PictureBox m_btnHelp;
		private CtrlHelpViewer visualiseur;
		private CCtrlVoirAussi ctrl_voirAussi;
		private System.Windows.Forms.Panel pan_separateur1;
		private System.Windows.Forms.Panel pan_separateur2;
		private System.Windows.Forms.Panel pan_separateur3;
		private System.Windows.Forms.PictureBox m_btnMenu;
		private System.Windows.Forms.Panel pan_separateur4;
		private System.Windows.Forms.Button btn_suivant;
		private System.Windows.Forms.Button btn_precedant;
		private System.Windows.Forms.CheckBox m_chkModeEdition;
		private System.Windows.Forms.ImageList m_imagesCadenas;
	}
}