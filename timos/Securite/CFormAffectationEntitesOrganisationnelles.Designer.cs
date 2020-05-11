namespace timos
{
	partial class CFormAffectationEntitesOrganisationnelles
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
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormAffectationEntitesOrganisationnelles));
            this.label1 = new System.Windows.Forms.Label();
            this.m_lblEntite = new System.Windows.Forms.Label();
            this.m_exStyle = new sc2i.win32.common.CExtStyle();
            this.c2iPanelOmbre1 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_lnkAjouter = new sc2i.win32.common.CWndLinkStd();
            this.m_wndListeEos = new sc2i.win32.common.GlacialList();
            this.label2 = new System.Windows.Forms.Label();
            this.m_lnkSupprimer = new sc2i.win32.common.CWndLinkStd();
            this.m_btnAnnuler = new System.Windows.Forms.Button();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.c2iPanelOmbre1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.m_extModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.m_exStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 0;
            this.label1.Text = "Element |123";
            // 
            // m_lblEntite
            // 
            this.m_lblEntite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblEntite.BackColor = System.Drawing.Color.White;
            this.m_lblEntite.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblEntite.Location = new System.Drawing.Point(89, 11);
            this.m_extModeEdition.SetModeEdition(this.m_lblEntite, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblEntite.Name = "m_lblEntite";
            this.m_lblEntite.Size = new System.Drawing.Size(400, 40);
            this.m_exStyle.SetStyleBackColor(this.m_lblEntite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_lblEntite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblEntite.TabIndex = 1;
            // 
            // c2iPanelOmbre1
            // 
            this.c2iPanelOmbre1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iPanelOmbre1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre1.Controls.Add(this.m_lnkAjouter);
            this.c2iPanelOmbre1.Controls.Add(this.m_lblEntite);
            this.c2iPanelOmbre1.Controls.Add(this.label1);
            this.c2iPanelOmbre1.Controls.Add(this.m_wndListeEos);
            this.c2iPanelOmbre1.Controls.Add(this.label2);
            this.c2iPanelOmbre1.Controls.Add(this.m_lnkSupprimer);
            this.c2iPanelOmbre1.ForeColor = System.Drawing.Color.Black;
            this.c2iPanelOmbre1.Location = new System.Drawing.Point(2, 12);
            this.c2iPanelOmbre1.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.c2iPanelOmbre1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.c2iPanelOmbre1.Name = "c2iPanelOmbre1";
            this.c2iPanelOmbre1.Size = new System.Drawing.Size(514, 371);
            this.m_exStyle.SetStyleBackColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_exStyle.SetStyleForeColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre1.TabIndex = 2;
            this.c2iPanelOmbre1.Paint += new System.Windows.Forms.PaintEventHandler(this.c2iPanelOmbre1_Paint);
            // 
            // m_lnkAjouter
            // 
            this.m_lnkAjouter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkAjouter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAjouter.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkAjouter.Location = new System.Drawing.Point(10, 320);
            this.m_extModeEdition.SetModeEdition(this.m_lnkAjouter, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkAjouter.Name = "m_lnkAjouter";
            this.m_lnkAjouter.Size = new System.Drawing.Size(77, 16);
            this.m_exStyle.SetStyleBackColor(this.m_lnkAjouter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_lnkAjouter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAjouter.TabIndex = 6;
            this.m_lnkAjouter.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAjouter.LinkClicked += new System.EventHandler(this.m_lnkAjouter_LinkClicked);
            // 
            // m_wndListeEos
            // 
            this.m_wndListeEos.AllowColumnResize = true;
            this.m_wndListeEos.AllowMultiselect = false;
            this.m_wndListeEos.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.m_wndListeEos.AlternatingColors = false;
            this.m_wndListeEos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_wndListeEos.AutoHeight = true;
            this.m_wndListeEos.AutoSort = true;
            this.m_wndListeEos.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.m_wndListeEos.CanChangeActivationCheckBoxes = false;
            this.m_wndListeEos.CheckBoxes = false;
            glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "LibelleComplet";
            glColumn1.Propriete = "EntiteOrganisationnelle.Libelle";
            glColumn1.Text = "Label|50";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 450;
            this.m_wndListeEos.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1});
            this.m_wndListeEos.ContexteUtilisation = "";
            this.m_wndListeEos.EnableCustomisation = true;
            this.m_wndListeEos.FocusedItem = null;
            this.m_wndListeEos.FullRowSelect = true;
            this.m_wndListeEos.GLGridLines = sc2i.win32.common.GLGridStyles.gridSolid;
            this.m_wndListeEos.GridColor = System.Drawing.Color.Gray;
            this.m_wndListeEos.HeaderHeight = 22;
            this.m_wndListeEos.HeaderStyle = sc2i.win32.common.GLHeaderStyles.Normal;
            this.m_wndListeEos.HeaderTextColor = System.Drawing.Color.Black;
            this.m_wndListeEos.HeaderTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.m_wndListeEos.HeaderVisible = true;
            this.m_wndListeEos.HeaderWordWrap = false;
            this.m_wndListeEos.HotColumnIndex = -1;
            this.m_wndListeEos.HotItemIndex = -1;
            this.m_wndListeEos.HotTracking = false;
            this.m_wndListeEos.HotTrackingColor = System.Drawing.Color.LightGray;
            this.m_wndListeEos.ImageList = null;
            this.m_wndListeEos.ItemHeight = 17;
            this.m_wndListeEos.ItemWordWrap = false;
            this.m_wndListeEos.ListeSource = null;
            this.m_wndListeEos.Location = new System.Drawing.Point(10, 79);
            this.m_wndListeEos.MaxHeight = 17;
            this.m_extModeEdition.SetModeEdition(this.m_wndListeEos, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_wndListeEos.Name = "m_wndListeEos";
            this.m_wndListeEos.SelectedTextColor = System.Drawing.Color.White;
            this.m_wndListeEos.SelectionColor = System.Drawing.Color.DarkBlue;
            this.m_wndListeEos.ShowBorder = true;
            this.m_wndListeEos.ShowFocusRect = true;
            this.m_wndListeEos.Size = new System.Drawing.Size(479, 235);
            this.m_wndListeEos.SortIndex = 0;
            this.m_exStyle.SetStyleBackColor(this.m_wndListeEos, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_wndListeEos, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeEos.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.m_wndListeEos.TabIndex = 3;
            this.m_wndListeEos.TrierAuClicSurEnteteColonne = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.m_extModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(312, 13);
            this.m_exStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4;
            this.label2.Text = "This element is l inked to the following Organizational Entities|124";
            // 
            // m_lnkSupprimer
            // 
            this.m_lnkSupprimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkSupprimer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkSupprimer.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkSupprimer.Location = new System.Drawing.Point(89, 320);
            this.m_extModeEdition.SetModeEdition(this.m_lnkSupprimer, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkSupprimer.Name = "m_lnkSupprimer";
            this.m_lnkSupprimer.Size = new System.Drawing.Size(77, 16);
            this.m_exStyle.SetStyleBackColor(this.m_lnkSupprimer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_lnkSupprimer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSupprimer.TabIndex = 5;
            this.m_lnkSupprimer.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkSupprimer.LinkClicked += new System.EventHandler(this.m_lnkSupprimer_LinkClicked);
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.m_btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnAnnuler.Location = new System.Drawing.Point(282, 381);
            this.m_extModeEdition.SetModeEdition(this.m_btnAnnuler, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(151, 29);
            this.m_exStyle.SetStyleBackColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAnnuler.TabIndex = 4;
            this.m_btnAnnuler.Text = "Cancel|11";
            this.m_btnAnnuler.UseVisualStyleBackColor = true;
            // 
            // m_btnOk
            // 
            this.m_btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.m_btnOk.Location = new System.Drawing.Point(67, 381);
            this.m_extModeEdition.SetModeEdition(this.m_btnOk, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(151, 29);
            this.m_exStyle.SetStyleBackColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnOk.TabIndex = 3;
            this.m_btnOk.Text = "Ok|10";
            this.m_btnOk.UseVisualStyleBackColor = true;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            // 
            // CFormAffectationEntitesOrganisationnelles
            // 
            this.AcceptButton = this.m_btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.m_btnAnnuler;
            this.ClientSize = new System.Drawing.Size(518, 422);
            this.Controls.Add(this.m_btnAnnuler);
            this.Controls.Add(this.m_btnOk);
            this.Controls.Add(this.c2iPanelOmbre1);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CFormAffectationEntitesOrganisationnelles";
            this.m_exStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondFenetre);
            this.m_exStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "Affectation des entités organisationnelles|122";
            this.Load += new System.EventHandler(this.CFormAffectationEntitesOrganisationnelles_Load);
            this.c2iPanelOmbre1.ResumeLayout(false);
            this.c2iPanelOmbre1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label m_lblEntite;
		private sc2i.win32.common.CExtStyle m_exStyle;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre1;
		private System.Windows.Forms.Button m_btnAnnuler;
		private System.Windows.Forms.Button m_btnOk;
		private sc2i.win32.common.GlacialList m_wndListeEos;
		private System.Windows.Forms.Label label2;
		private sc2i.win32.common.CWndLinkStd m_lnkAjouter;
		private sc2i.win32.common.CWndLinkStd m_lnkSupprimer;
		private sc2i.win32.common.CExtModeEdition m_extModeEdition;
	}
}