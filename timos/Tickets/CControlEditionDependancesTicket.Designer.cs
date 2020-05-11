namespace timos
{
	partial class CControlEditionDependancesTicket
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

		#region Code généré par le Concepteur de composants

		/// <summary> 
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_chkEsclaveClotureAuto = new System.Windows.Forms.CheckBox();
            this.m_chkMaitreClotureAuto = new System.Windows.Forms.CheckBox();
            this.m_txtEsclaveSelec = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_txtMaitreSelec = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_gbMaitres = new System.Windows.Forms.GroupBox();
            this.m_lnkMaitreEditer = new sc2i.win32.common.C2iLink(this.components);
            this.m_MaitreAjout = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkMaitreSupp = new sc2i.win32.common.CWndLinkStd();
            this.m_listeMaitres = new sc2i.win32.common.ListViewAutoFilled();
            this.col_master_num = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.col_master_auto = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_gbEsclaves = new System.Windows.Forms.GroupBox();
            this.m_lnkEsclaveEditer = new sc2i.win32.common.C2iLink(this.components);
            this.m_EsclaveAjout = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkEsclaveSupp = new sc2i.win32.common.CWndLinkStd();
            this.m_listeEsclaves = new sc2i.win32.common.ListViewAutoFilled();
            this.col_slave_num = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.col_slave_cloture = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_gestionnaireMaitres = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.m_gestionnaireEsclaves = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.m_tooltip = new sc2i.win32.common.CToolTipTraductible(this.components);
            this.m_gbMaitres.SuspendLayout();
            this.m_gbEsclaves.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_chkEsclaveClotureAuto
            // 
            this.m_chkEsclaveClotureAuto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_chkEsclaveClotureAuto.AutoSize = true;
            this.m_chkEsclaveClotureAuto.Location = new System.Drawing.Point(177, 175);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkEsclaveClotureAuto, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkEsclaveClotureAuto.Name = "m_chkEsclaveClotureAuto";
            this.m_chkEsclaveClotureAuto.Size = new System.Drawing.Size(129, 17);
            this.m_chkEsclaveClotureAuto.TabIndex = 2;
            this.m_chkEsclaveClotureAuto.Text = "Automatic closing|617";
            this.m_chkEsclaveClotureAuto.UseVisualStyleBackColor = true;
            // 
            // m_chkMaitreClotureAuto
            // 
            this.m_chkMaitreClotureAuto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_chkMaitreClotureAuto.AutoSize = true;
            this.m_chkMaitreClotureAuto.Location = new System.Drawing.Point(177, 188);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkMaitreClotureAuto, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkMaitreClotureAuto.Name = "m_chkMaitreClotureAuto";
            this.m_chkMaitreClotureAuto.Size = new System.Drawing.Size(129, 17);
            this.m_chkMaitreClotureAuto.TabIndex = 2;
            this.m_chkMaitreClotureAuto.Text = "Automatic closing|617";
            this.m_chkMaitreClotureAuto.UseVisualStyleBackColor = true;
            // 
            // m_txtEsclaveSelec
            // 
            this.m_txtEsclaveSelec.ElementSelectionne = null;
            this.m_txtEsclaveSelec.FonctionTextNull = null;
            this.m_txtEsclaveSelec.HasLink = true;
            this.m_txtEsclaveSelec.Location = new System.Drawing.Point(18, 15);
            this.m_txtEsclaveSelec.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtEsclaveSelec, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtEsclaveSelec.Name = "m_txtEsclaveSelec";
            this.m_txtEsclaveSelec.SelectedObject = null;
            this.m_txtEsclaveSelec.Size = new System.Drawing.Size(192, 21);
            this.m_txtEsclaveSelec.TabIndex = 4;
            this.m_txtEsclaveSelec.TextNull = "";
            // 
            // m_txtMaitreSelec
            // 
            this.m_txtMaitreSelec.ElementSelectionne = null;
            this.m_txtMaitreSelec.FonctionTextNull = null;
            this.m_txtMaitreSelec.HasLink = true;
            this.m_txtMaitreSelec.Location = new System.Drawing.Point(18, 15);
            this.m_txtMaitreSelec.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtMaitreSelec, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtMaitreSelec.Name = "m_txtMaitreSelec";
            this.m_txtMaitreSelec.SelectedObject = null;
            this.m_txtMaitreSelec.Size = new System.Drawing.Size(192, 21);
            this.m_txtMaitreSelec.TabIndex = 4;
            this.m_txtMaitreSelec.TextNull = "";
            // 
            // m_gbMaitres
            // 
            this.m_gbMaitres.Controls.Add(this.m_lnkMaitreEditer);
            this.m_gbMaitres.Controls.Add(this.m_MaitreAjout);
            this.m_gbMaitres.Controls.Add(this.m_lnkMaitreSupp);
            this.m_gbMaitres.Controls.Add(this.m_listeMaitres);
            this.m_gbMaitres.Controls.Add(this.m_txtMaitreSelec);
            this.m_gbMaitres.Controls.Add(this.m_chkMaitreClotureAuto);
            this.m_gbMaitres.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_gbMaitres.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_gbMaitres, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_gbMaitres.Name = "m_gbMaitres";
            this.m_gbMaitres.Size = new System.Drawing.Size(627, 209);
            this.m_gbMaitres.TabIndex = 5;
            this.m_gbMaitres.TabStop = false;
            this.m_gbMaitres.Text = "Master Tickets|615";
            // 
            // m_lnkMaitreEditer
            // 
            this.m_lnkMaitreEditer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkMaitreEditer.ClickEnabled = true;
            this.m_lnkMaitreEditer.ColorLabel = System.Drawing.SystemColors.ControlText;
            this.m_lnkMaitreEditer.ColorLinkDisabled = System.Drawing.Color.Blue;
            this.m_lnkMaitreEditer.ColorLinkEnabled = System.Drawing.Color.Blue;
            this.m_lnkMaitreEditer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkMaitreEditer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.m_lnkMaitreEditer.ForeColor = System.Drawing.Color.Blue;
            this.m_lnkMaitreEditer.Location = new System.Drawing.Point(102, 189);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkMaitreEditer, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lnkMaitreEditer.Name = "m_lnkMaitreEditer";
            this.m_lnkMaitreEditer.Size = new System.Drawing.Size(66, 14);
            this.m_lnkMaitreEditer.TabIndex = 4012;
            this.m_lnkMaitreEditer.Text = "See...|621";
            this.m_lnkMaitreEditer.LinkClicked += new System.EventHandler(this.m_lnkMaitreEditer_LinkClicked);
            // 
            // m_MaitreAjout
            // 
            this.m_MaitreAjout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_MaitreAjout.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_MaitreAjout.Location = new System.Drawing.Point(216, 13);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_MaitreAjout, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_MaitreAjout.Name = "m_MaitreAjout";
            this.m_MaitreAjout.Size = new System.Drawing.Size(67, 24);
            this.m_MaitreAjout.TabIndex = 4011;
            this.m_MaitreAjout.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_MaitreAjout.LinkClicked += new System.EventHandler(this.m_MaitreAjout_LinkClicked);
            // 
            // m_lnkMaitreSupp
            // 
            this.m_lnkMaitreSupp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkMaitreSupp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkMaitreSupp.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkMaitreSupp.Location = new System.Drawing.Point(18, 183);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkMaitreSupp, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkMaitreSupp.Name = "m_lnkMaitreSupp";
            this.m_lnkMaitreSupp.Size = new System.Drawing.Size(83, 24);
            this.m_lnkMaitreSupp.TabIndex = 4010;
            this.m_lnkMaitreSupp.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkMaitreSupp.LinkClicked += new System.EventHandler(this.m_lnkMaitreSupp_LinkClicked);
            // 
            // m_listeMaitres
            // 
            this.m_listeMaitres.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_listeMaitres.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_master_num,
            this.col_master_auto});
            this.m_listeMaitres.EnableCustomisation = true;
            this.m_listeMaitres.FullRowSelect = true;
            this.m_listeMaitres.HideSelection = false;
            this.m_listeMaitres.Location = new System.Drawing.Point(18, 42);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_listeMaitres, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_listeMaitres.MultiSelect = false;
            this.m_listeMaitres.Name = "m_listeMaitres";
            this.m_listeMaitres.Size = new System.Drawing.Size(588, 135);
            this.m_listeMaitres.TabIndex = 5;
            this.m_listeMaitres.UseCompatibleStateImageBehavior = false;
            this.m_listeMaitres.View = System.Windows.Forms.View.Details;
            // 
            // col_master_num
            // 
            this.col_master_num.Field = "TicketMaitre.Numero";
            this.col_master_num.PrecisionWidth = 0;
            this.col_master_num.ProportionnalSize = false;
            this.col_master_num.Text = "Ticket number|618";
            this.col_master_num.Visible = true;
            this.col_master_num.Width = 150;
            // 
            // col_master_auto
            // 
            this.col_master_auto.Field = "ClotureAutoEscalve";
            this.col_master_auto.PrecisionWidth = 0;
            this.col_master_auto.ProportionnalSize = false;
            this.col_master_auto.Text = "Automatic closing|617";
            this.col_master_auto.Visible = true;
            this.col_master_auto.Width = 213;
            // 
            // m_gbEsclaves
            // 
            this.m_gbEsclaves.Controls.Add(this.m_lnkEsclaveEditer);
            this.m_gbEsclaves.Controls.Add(this.m_EsclaveAjout);
            this.m_gbEsclaves.Controls.Add(this.m_lnkEsclaveSupp);
            this.m_gbEsclaves.Controls.Add(this.m_listeEsclaves);
            this.m_gbEsclaves.Controls.Add(this.m_txtEsclaveSelec);
            this.m_gbEsclaves.Controls.Add(this.m_chkEsclaveClotureAuto);
            this.m_gbEsclaves.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_gbEsclaves.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_gbEsclaves, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_gbEsclaves.Name = "m_gbEsclaves";
            this.m_gbEsclaves.Size = new System.Drawing.Size(627, 205);
            this.m_gbEsclaves.TabIndex = 6;
            this.m_gbEsclaves.TabStop = false;
            this.m_gbEsclaves.Text = "Slave Tickets|616";
            // 
            // m_lnkEsclaveEditer
            // 
            this.m_lnkEsclaveEditer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkEsclaveEditer.ClickEnabled = true;
            this.m_lnkEsclaveEditer.ColorLabel = System.Drawing.SystemColors.ControlText;
            this.m_lnkEsclaveEditer.ColorLinkDisabled = System.Drawing.Color.Blue;
            this.m_lnkEsclaveEditer.ColorLinkEnabled = System.Drawing.Color.Blue;
            this.m_lnkEsclaveEditer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkEsclaveEditer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.m_lnkEsclaveEditer.ForeColor = System.Drawing.Color.Blue;
            this.m_lnkEsclaveEditer.Location = new System.Drawing.Point(100, 176);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkEsclaveEditer, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lnkEsclaveEditer.Name = "m_lnkEsclaveEditer";
            this.m_lnkEsclaveEditer.Size = new System.Drawing.Size(68, 15);
            this.m_lnkEsclaveEditer.TabIndex = 4012;
            this.m_lnkEsclaveEditer.Text = "See...|621";
            this.m_lnkEsclaveEditer.LinkClicked += new System.EventHandler(this.m_lnkEsclaveEditer_LinkClicked);
            // 
            // m_EsclaveAjout
            // 
            this.m_EsclaveAjout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_EsclaveAjout.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_EsclaveAjout.Location = new System.Drawing.Point(216, 13);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_EsclaveAjout, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_EsclaveAjout.Name = "m_EsclaveAjout";
            this.m_EsclaveAjout.Size = new System.Drawing.Size(67, 24);
            this.m_EsclaveAjout.TabIndex = 4011;
            this.m_EsclaveAjout.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_EsclaveAjout.LinkClicked += new System.EventHandler(this.m_EsclaveAjout_LinkClicked);
            // 
            // m_lnkEsclaveSupp
            // 
            this.m_lnkEsclaveSupp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkEsclaveSupp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkEsclaveSupp.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkEsclaveSupp.Location = new System.Drawing.Point(18, 170);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkEsclaveSupp, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkEsclaveSupp.Name = "m_lnkEsclaveSupp";
            this.m_lnkEsclaveSupp.Size = new System.Drawing.Size(83, 24);
            this.m_lnkEsclaveSupp.TabIndex = 4011;
            this.m_lnkEsclaveSupp.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkEsclaveSupp.LinkClicked += new System.EventHandler(this.m_lnkEsclaveSupp_LinkClicked);
            // 
            // m_listeEsclaves
            // 
            this.m_listeEsclaves.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_listeEsclaves.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_slave_num,
            this.col_slave_cloture});
            this.m_listeEsclaves.EnableCustomisation = true;
            this.m_listeEsclaves.FullRowSelect = true;
            this.m_listeEsclaves.HideSelection = false;
            this.m_listeEsclaves.Location = new System.Drawing.Point(18, 42);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_listeEsclaves, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_listeEsclaves.MultiSelect = false;
            this.m_listeEsclaves.Name = "m_listeEsclaves";
            this.m_listeEsclaves.Size = new System.Drawing.Size(588, 122);
            this.m_listeEsclaves.TabIndex = 6;
            this.m_listeEsclaves.UseCompatibleStateImageBehavior = false;
            this.m_listeEsclaves.View = System.Windows.Forms.View.Details;
            // 
            // col_slave_num
            // 
            this.col_slave_num.Field = "TicketEsclave.Numero";
            this.col_slave_num.PrecisionWidth = 0;
            this.col_slave_num.ProportionnalSize = false;
            this.col_slave_num.Text = "Ticket number|618";
            this.col_slave_num.Visible = true;
            this.col_slave_num.Width = 150;
            // 
            // col_slave_cloture
            // 
            this.col_slave_cloture.Field = "ClotureAutoEscalve";
            this.col_slave_cloture.PrecisionWidth = 0;
            this.col_slave_cloture.ProportionnalSize = false;
            this.col_slave_cloture.Text = "Automatic closing|617";
            this.col_slave_cloture.Visible = true;
            this.col_slave_cloture.Width = 197;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m_gbMaitres);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1.Panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_gbEsclaves);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1.Panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.splitContainer1.Size = new System.Drawing.Size(631, 426);
            this.splitContainer1.SplitterDistance = 213;
            this.splitContainer1.TabIndex = 7;
            // 
            // m_gestionnaireMaitres
            // 
            this.m_gestionnaireMaitres.ListeAssociee = this.m_listeMaitres;
            this.m_gestionnaireMaitres.ObjetEdite = null;
            this.m_gestionnaireMaitres.InitChamp += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireMaitres_InitChamp);
            this.m_gestionnaireMaitres.MAJ_Champs += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireMaitres_MAJ_Champs);
            // 
            // m_gestionnaireEsclaves
            // 
            this.m_gestionnaireEsclaves.ListeAssociee = this.m_listeEsclaves;
            this.m_gestionnaireEsclaves.ObjetEdite = null;
            this.m_gestionnaireEsclaves.InitChamp += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireEsclaves_InitChamp);
            this.m_gestionnaireEsclaves.MAJ_Champs += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireEsclaves_MAJ_Champs);
            // 
            // CControlEditionDependancesTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.splitContainer1);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControlEditionDependancesTicket";
            this.Size = new System.Drawing.Size(631, 426);
            this.Load += new System.EventHandler(this.CControlEditionDependancesTicket_Load);
            this.m_gbMaitres.ResumeLayout(false);
            this.m_gbMaitres.PerformLayout();
            this.m_gbEsclaves.ResumeLayout(false);
            this.m_gbEsclaves.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private System.Windows.Forms.CheckBox m_chkEsclaveClotureAuto;
		private System.Windows.Forms.CheckBox m_chkMaitreClotureAuto;
		private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_txtEsclaveSelec;
		private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_txtMaitreSelec;
		private System.Windows.Forms.GroupBox m_gbMaitres;
		private System.Windows.Forms.GroupBox m_gbEsclaves;
		private sc2i.win32.common.ListViewAutoFilled m_listeMaitres;
		private sc2i.win32.common.ListViewAutoFilled m_listeEsclaves;
		private sc2i.win32.common.CWndLinkStd m_lnkMaitreSupp;
		private sc2i.win32.common.CWndLinkStd m_lnkEsclaveSupp;
		private sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee m_gestionnaireMaitres;
		private sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee m_gestionnaireEsclaves;
		private sc2i.win32.common.ListViewAutoFilledColumn col_master_num;
		private sc2i.win32.common.ListViewAutoFilledColumn col_master_auto;
		private sc2i.win32.common.ListViewAutoFilledColumn col_slave_num;
		private sc2i.win32.common.ListViewAutoFilledColumn col_slave_cloture;
		private sc2i.win32.common.CWndLinkStd m_MaitreAjout;
		private sc2i.win32.common.CWndLinkStd m_EsclaveAjout;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private sc2i.win32.common.C2iLink m_lnkMaitreEditer;
		private sc2i.win32.common.C2iLink m_lnkEsclaveEditer;
        private sc2i.win32.common.CToolTipTraductible m_tooltip;
	}
}
