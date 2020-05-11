namespace timos
{
	partial class CControlEditionEntitesLiees
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
            this.m_txtSelectEO = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_txtSelectSite = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_gbSites = new System.Windows.Forms.GroupBox();
            this.m_lnkEditerSite = new sc2i.win32.common.C2iLink(this.components);
            this.m_lnkAjouterSite = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkSupprimerSite = new sc2i.win32.common.CWndLinkStd();
            this.m_controlOrdreSites = new sc2i.win32.common.CCtrlUpDownListView();
            this.m_listeSites = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_gbEOs = new System.Windows.Forms.GroupBox();
            this.l_lnkEditerEO = new sc2i.win32.common.C2iLink(this.components);
            this.m_lnkAjouterEO = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkSupprimerEO = new sc2i.win32.common.CWndLinkStd();
            this.m_listeEOs = new sc2i.win32.common.ListViewAutoFilled();
            this.col_eo_label = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.m_gbSites.SuspendLayout();
            this.m_gbEOs.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_txtSelectEO
            // 
            this.m_txtSelectEO.ElementSelectionne = null;
            this.m_txtSelectEO.FonctionTextNull = null;
            this.m_txtSelectEO.HasLink = true;
            this.m_txtSelectEO.Location = new System.Drawing.Point(18, 15);
            this.m_txtSelectEO.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectEO, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtSelectEO.Name = "m_txtSelectEO";
            this.m_txtSelectEO.SelectedObject = null;
            this.m_txtSelectEO.Size = new System.Drawing.Size(289, 21);
            this.m_txtSelectEO.TabIndex = 4;
            this.m_txtSelectEO.TextNull = "";
            // 
            // m_txtSelectSite
            // 
            this.m_txtSelectSite.ElementSelectionne = null;
            this.m_txtSelectSite.FonctionTextNull = null;
            this.m_txtSelectSite.HasLink = true;
            this.m_txtSelectSite.Location = new System.Drawing.Point(18, 14);
            this.m_txtSelectSite.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectSite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtSelectSite.Name = "m_txtSelectSite";
            this.m_txtSelectSite.SelectedObject = null;
            this.m_txtSelectSite.Size = new System.Drawing.Size(289, 21);
            this.m_txtSelectSite.TabIndex = 4;
            this.m_txtSelectSite.TextNull = "";
            // 
            // m_gbSites
            // 
            this.m_gbSites.Controls.Add(this.m_lnkEditerSite);
            this.m_gbSites.Controls.Add(this.m_lnkAjouterSite);
            this.m_gbSites.Controls.Add(this.m_lnkSupprimerSite);
            this.m_gbSites.Controls.Add(this.m_controlOrdreSites);
            this.m_gbSites.Controls.Add(this.m_listeSites);
            this.m_gbSites.Controls.Add(this.m_txtSelectSite);
            this.m_gbSites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_gbSites.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_gbSites, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_gbSites.Name = "m_gbSites";
            this.m_gbSites.Size = new System.Drawing.Size(666, 206);
            this.m_gbSites.TabIndex = 5;
            this.m_gbSites.TabStop = false;
            this.m_gbSites.Text = "Sites|225";
            // 
            // m_lnkEditerSite
            // 
            this.m_lnkEditerSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkEditerSite.ClickEnabled = true;
            this.m_lnkEditerSite.ColorLabel = System.Drawing.SystemColors.ControlText;
            this.m_lnkEditerSite.ColorLinkDisabled = System.Drawing.Color.Blue;
            this.m_lnkEditerSite.ColorLinkEnabled = System.Drawing.Color.Blue;
            this.m_lnkEditerSite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkEditerSite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.m_lnkEditerSite.ForeColor = System.Drawing.Color.Blue;
            this.m_lnkEditerSite.Location = new System.Drawing.Point(113, 182);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkEditerSite, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lnkEditerSite.Name = "m_lnkEditerSite";
            this.m_lnkEditerSite.Size = new System.Drawing.Size(67, 14);
            this.m_lnkEditerSite.TabIndex = 4012;
            this.m_lnkEditerSite.Text = "See...|621";
            this.m_lnkEditerSite.LinkClicked += new System.EventHandler(this.m_lnkEditerSite_LinkClicked);
            // 
            // m_lnkAjouterSite
            // 
            this.m_lnkAjouterSite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAjouterSite.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkAjouterSite.Location = new System.Drawing.Point(314, 14);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAjouterSite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkAjouterSite.Name = "m_lnkAjouterSite";
            this.m_lnkAjouterSite.Size = new System.Drawing.Size(67, 21);
            this.m_lnkAjouterSite.TabIndex = 4011;
            this.m_lnkAjouterSite.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAjouterSite.LinkClicked += new System.EventHandler(this.m_lnkAjouterSite_LinkClicked);
            // 
            // m_lnkSupprimerSite
            // 
            this.m_lnkSupprimerSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkSupprimerSite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkSupprimerSite.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkSupprimerSite.Location = new System.Drawing.Point(18, 175);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkSupprimerSite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkSupprimerSite.Name = "m_lnkSupprimerSite";
            this.m_lnkSupprimerSite.Size = new System.Drawing.Size(89, 21);
            this.m_lnkSupprimerSite.TabIndex = 4010;
            this.m_lnkSupprimerSite.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkSupprimerSite.LinkClicked += new System.EventHandler(this.m_lnkSupprimerSite_LinkClicked);
            // 
            // m_controlOrdreSites
            // 
            this.m_controlOrdreSites.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_controlOrdreSites.ListeGeree = this.m_listeSites;
            this.m_controlOrdreSites.Location = new System.Drawing.Point(514, 183);
            this.m_controlOrdreSites.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_controlOrdreSites, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_controlOrdreSites.Name = "m_controlOrdreSites";
            this.m_controlOrdreSites.ProprieteNumero = "OrdreSite";
            this.m_controlOrdreSites.Size = new System.Drawing.Size(56, 20);
            this.m_controlOrdreSites.TabIndex = 4014;
            // 
            // m_listeSites
            // 
            this.m_listeSites.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_listeSites.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn1});
            this.m_listeSites.EnableCustomisation = true;
            this.m_listeSites.FullRowSelect = true;
            this.m_listeSites.HideSelection = false;
            this.m_listeSites.Location = new System.Drawing.Point(18, 41);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_listeSites, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_listeSites.MultiSelect = false;
            this.m_listeSites.Name = "m_listeSites";
            this.m_listeSites.Size = new System.Drawing.Size(627, 122);
            this.m_listeSites.TabIndex = 5;
            this.m_listeSites.UseCompatibleStateImageBehavior = false;
            this.m_listeSites.View = System.Windows.Forms.View.Details;
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "Site.Libelle";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Site label|619";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 324;
            // 
            // m_gbEOs
            // 
            this.m_gbEOs.Controls.Add(this.l_lnkEditerEO);
            this.m_gbEOs.Controls.Add(this.m_lnkAjouterEO);
            this.m_gbEOs.Controls.Add(this.m_lnkSupprimerEO);
            this.m_gbEOs.Controls.Add(this.m_listeEOs);
            this.m_gbEOs.Controls.Add(this.m_txtSelectEO);
            this.m_gbEOs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_gbEOs.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_gbEOs, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_gbEOs.Name = "m_gbEOs";
            this.m_gbEOs.Size = new System.Drawing.Size(666, 208);
            this.m_gbEOs.TabIndex = 6;
            this.m_gbEOs.TabStop = false;
            this.m_gbEOs.Text = "Organizational Entities|53";
            // 
            // l_lnkEditerEO
            // 
            this.l_lnkEditerEO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.l_lnkEditerEO.ClickEnabled = true;
            this.l_lnkEditerEO.ColorLabel = System.Drawing.SystemColors.ControlText;
            this.l_lnkEditerEO.ColorLinkDisabled = System.Drawing.Color.Blue;
            this.l_lnkEditerEO.ColorLinkEnabled = System.Drawing.Color.Blue;
            this.l_lnkEditerEO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.l_lnkEditerEO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.l_lnkEditerEO.ForeColor = System.Drawing.Color.Blue;
            this.l_lnkEditerEO.Location = new System.Drawing.Point(113, 179);
            this.m_gestionnaireModeEdition.SetModeEdition(this.l_lnkEditerEO, sc2i.win32.common.TypeModeEdition.Autonome);
            this.l_lnkEditerEO.Name = "l_lnkEditerEO";
            this.l_lnkEditerEO.Size = new System.Drawing.Size(60, 18);
            this.l_lnkEditerEO.TabIndex = 4012;
            this.l_lnkEditerEO.Text = "See...|621";
            this.l_lnkEditerEO.LinkClicked += new System.EventHandler(this.l_lnkEditerEO_LinkClicked);
            // 
            // m_lnkAjouterEO
            // 
            this.m_lnkAjouterEO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAjouterEO.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkAjouterEO.Location = new System.Drawing.Point(314, 15);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAjouterEO, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkAjouterEO.Name = "m_lnkAjouterEO";
            this.m_lnkAjouterEO.Size = new System.Drawing.Size(67, 21);
            this.m_lnkAjouterEO.TabIndex = 4011;
            this.m_lnkAjouterEO.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAjouterEO.LinkClicked += new System.EventHandler(this.m_lnkAjouterEO_LinkClicked);
            // 
            // m_lnkSupprimerEO
            // 
            this.m_lnkSupprimerEO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkSupprimerEO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkSupprimerEO.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkSupprimerEO.Location = new System.Drawing.Point(18, 175);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkSupprimerEO, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkSupprimerEO.Name = "m_lnkSupprimerEO";
            this.m_lnkSupprimerEO.Size = new System.Drawing.Size(104, 21);
            this.m_lnkSupprimerEO.TabIndex = 4011;
            this.m_lnkSupprimerEO.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkSupprimerEO.LinkClicked += new System.EventHandler(this.m_lnkSupprimerEO_LinkClicked);
            // 
            // m_listeEOs
            // 
            this.m_listeEOs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_listeEOs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_eo_label});
            this.m_listeEOs.EnableCustomisation = true;
            this.m_listeEOs.FullRowSelect = true;
            this.m_listeEOs.HideSelection = false;
            this.m_listeEOs.Location = new System.Drawing.Point(18, 42);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_listeEOs, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_listeEOs.MultiSelect = false;
            this.m_listeEOs.Name = "m_listeEOs";
            this.m_listeEOs.Size = new System.Drawing.Size(627, 125);
            this.m_listeEOs.TabIndex = 6;
            this.m_listeEOs.UseCompatibleStateImageBehavior = false;
            this.m_listeEOs.View = System.Windows.Forms.View.Details;
            // 
            // col_eo_label
            // 
            this.col_eo_label.Field = "EntiteOrganisationnelle.Libelle";
            this.col_eo_label.PrecisionWidth = 0;
            this.col_eo_label.ProportionnalSize = false;
            this.col_eo_label.Text = "Organizational Entity label|620";
            this.col_eo_label.Visible = true;
            this.col_eo_label.Width = 333;
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
            this.splitContainer1.Panel1.Controls.Add(this.m_gbSites);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1.Panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_gbEOs);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1.Panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.splitContainer1.Size = new System.Drawing.Size(670, 426);
            this.splitContainer1.SplitterDistance = 210;
            this.splitContainer1.TabIndex = 7;
            // 
            // m_tooltip
            // 
            this.m_tooltip.IsBalloon = true;
            // 
            // CControlEditionEntitesLiees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.splitContainer1);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControlEditionEntitesLiees";
            this.Size = new System.Drawing.Size(670, 426);
            this.Load += new System.EventHandler(this.CControlEditionEntitesLiees_Load);
            this.m_gbSites.ResumeLayout(false);
            this.m_gbEOs.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
        private System.Windows.Forms.ToolTip m_tooltip;
		private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_txtSelectEO;
		private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_txtSelectSite;
        private System.Windows.Forms.GroupBox m_gbSites;
        private System.Windows.Forms.GroupBox m_gbEOs;
		private sc2i.win32.common.ListViewAutoFilled m_listeSites;
		private sc2i.win32.common.ListViewAutoFilled m_listeEOs;
		private sc2i.win32.common.CWndLinkStd m_lnkSupprimerSite;
        private sc2i.win32.common.CWndLinkStd m_lnkSupprimerEO;
        private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn1;
        private sc2i.win32.common.ListViewAutoFilledColumn col_eo_label;
		private sc2i.win32.common.CWndLinkStd m_lnkAjouterSite;
		private sc2i.win32.common.CWndLinkStd m_lnkAjouterEO;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private sc2i.win32.common.C2iLink m_lnkEditerSite;
        private sc2i.win32.common.C2iLink l_lnkEditerEO;
		private sc2i.win32.common.CCtrlUpDownListView m_controlOrdreSites;
	}
}
