namespace spv.win32
{
	partial class CPanelListChampsExport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPanelListChampsExport));
            this.m_btnBas = new System.Windows.Forms.PictureBox();
            this.m_btnHaut = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_wndListeChamps = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.m_imagesChamps = new System.Windows.Forms.ImageList(this.components);
            this.m_btnSupprimer = new sc2i.win32.common.CWndLinkStd();
            this.m_btnDetail = new sc2i.win32.common.CWndLinkStd();
            this.m_btnAjouter = new sc2i.win32.common.CWndLinkStd();
            this.m_imagesFiltre = new System.Windows.Forms.ImageList(this.components);
            this.m_tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_menuAjouterChampDonnee = new System.Windows.Forms.MenuItem();
            this.m_menuAjouterChamp = new System.Windows.Forms.ContextMenu();
            this.m_menuAjouterChampCalcule = new System.Windows.Forms.MenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnBas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHaut)).BeginInit();
            this.SuspendLayout();
            // 
            // m_btnBas
            // 
            this.m_btnBas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnBas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnBas.Image = ((System.Drawing.Image)(resources.GetObject("m_btnBas.Image")));
            this.m_btnBas.Location = new System.Drawing.Point(520, 11);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnBas, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnBas.Name = "m_btnBas";
            this.m_btnBas.Size = new System.Drawing.Size(15, 15);
            this.m_btnBas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.m_btnBas.TabIndex = 10;
            this.m_btnBas.TabStop = false;
            this.m_btnBas.Click += new System.EventHandler(this.m_btnBas_Click);
            // 
            // m_btnHaut
            // 
            this.m_btnHaut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnHaut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnHaut.Image = ((System.Drawing.Image)(resources.GetObject("m_btnHaut.Image")));
            this.m_btnHaut.Location = new System.Drawing.Point(499, 11);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnHaut, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnHaut.Name = "m_btnHaut";
            this.m_btnHaut.Size = new System.Drawing.Size(15, 15);
            this.m_btnHaut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.m_btnHaut.TabIndex = 9;
            this.m_btnHaut.TabStop = false;
            this.m_btnHaut.Click += new System.EventHandler(this.m_btnHaut_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Table fields|186";
            // 
            // m_wndListeChamps
            // 
            this.m_wndListeChamps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_wndListeChamps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.m_wndListeChamps.FullRowSelect = true;
            this.m_wndListeChamps.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_wndListeChamps.HideSelection = false;
            this.m_wndListeChamps.LabelEdit = true;
            this.m_wndListeChamps.Location = new System.Drawing.Point(6, 27);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeChamps, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_wndListeChamps.MultiSelect = false;
            this.m_wndListeChamps.Name = "m_wndListeChamps";
            this.m_wndListeChamps.Size = new System.Drawing.Size(529, 144);
            this.m_wndListeChamps.SmallImageList = this.m_imagesChamps;
            this.m_wndListeChamps.TabIndex = 2;
            this.m_wndListeChamps.UseCompatibleStateImageBehavior = false;
            this.m_wndListeChamps.View = System.Windows.Forms.View.Details;
            this.m_wndListeChamps.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.m_wndListeChamps_AfterLabelEdit);
            this.m_wndListeChamps.SelectedIndexChanged += new System.EventHandler(this.m_wndListeChamps_SelectedIndexChanged);
            this.m_wndListeChamps.MouseMove += new System.Windows.Forms.MouseEventHandler(this.m_wndListeChamps_MouseMove);
            this.m_wndListeChamps.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.m_wndListeChamps_BeforeLabelEdit);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 500;
            // 
            // m_imagesChamps
            // 
            this.m_imagesChamps.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imagesChamps.ImageStream")));
            this.m_imagesChamps.TransparentColor = System.Drawing.Color.Transparent;
            this.m_imagesChamps.Images.SetKeyName(0, "");
            this.m_imagesChamps.Images.SetKeyName(1, "");
            this.m_imagesChamps.Images.SetKeyName(2, "");
            this.m_imagesChamps.Images.SetKeyName(3, "");
            // 
            // m_btnSupprimer
            // 
            this.m_btnSupprimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnSupprimer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnSupprimer.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_btnSupprimer.Location = new System.Drawing.Point(145, 176);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnSupprimer, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnSupprimer.Name = "m_btnSupprimer";
            this.m_btnSupprimer.Size = new System.Drawing.Size(80, 16);
            this.m_btnSupprimer.TabIndex = 6;
            this.m_btnSupprimer.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_btnSupprimer.LinkClicked += new System.EventHandler(this.m_btnSupprimer_LinkClicked);
            // 
            // m_btnDetail
            // 
            this.m_btnDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnDetail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnDetail.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_btnDetail.Location = new System.Drawing.Point(77, 176);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnDetail, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnDetail.Name = "m_btnDetail";
            this.m_btnDetail.Size = new System.Drawing.Size(64, 16);
            this.m_btnDetail.TabIndex = 5;
            this.m_btnDetail.TypeLien = sc2i.win32.common.TypeLinkStd.Modification;
            this.m_btnDetail.LinkClicked += new System.EventHandler(this.m_btnDetail_LinkClicked);
            // 
            // m_btnAjouter
            // 
            this.m_btnAjouter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnAjouter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnAjouter.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_btnAjouter.Location = new System.Drawing.Point(9, 176);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAjouter, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnAjouter.Name = "m_btnAjouter";
            this.m_btnAjouter.Size = new System.Drawing.Size(64, 16);
            this.m_btnAjouter.TabIndex = 4;
            this.m_btnAjouter.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_btnAjouter.LinkClicked += new System.EventHandler(this.m_btnAjouter_LinkClicked);
            // 
            // m_imagesFiltre
            // 
            this.m_imagesFiltre.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imagesFiltre.ImageStream")));
            this.m_imagesFiltre.TransparentColor = System.Drawing.Color.Transparent;
            this.m_imagesFiltre.Images.SetKeyName(0, "");
            this.m_imagesFiltre.Images.SetKeyName(1, "");
            // 
            // m_menuAjouterChampDonnee
            // 
            this.m_menuAjouterChampDonnee.Index = 0;
            this.m_menuAjouterChampDonnee.Text = "Champ de donnée";
            this.m_menuAjouterChampDonnee.Click += new System.EventHandler(this.m_menuAjouterChampDonnee_Click);
            // 
            // m_menuAjouterChamp
            // 
            this.m_menuAjouterChamp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.m_menuAjouterChampDonnee,
            this.m_menuAjouterChampCalcule});
            this.m_menuAjouterChamp.Popup += new System.EventHandler(this.m_menuAjouterChamp_Popup);
            // 
            // m_menuAjouterChampCalcule
            // 
            this.m_menuAjouterChampCalcule.Index = 1;
            this.m_menuAjouterChampCalcule.Text = "Champ calcule";
            this.m_menuAjouterChampCalcule.Click += new System.EventHandler(this.m_menuAjouterChampCalcule_Click);
            // 
            // CPanelListChampsExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_btnAjouter);
            this.Controls.Add(this.m_btnDetail);
            this.Controls.Add(this.m_btnSupprimer);
            this.Controls.Add(this.m_wndListeChamps);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_btnHaut);
            this.Controls.Add(this.m_btnBas);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CPanelListChampsExport";
            this.Size = new System.Drawing.Size(547, 196);
            this.Load += new System.EventHandler(this.CPanelEditTableExportComplexe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnBas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHaut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox m_btnBas;
		private System.Windows.Forms.PictureBox m_btnHaut;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ListView m_wndListeChamps;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private sc2i.win32.common.CWndLinkStd m_btnSupprimer;
		private sc2i.win32.common.CWndLinkStd m_btnDetail;
        private sc2i.win32.common.CWndLinkStd m_btnAjouter;
        private System.Windows.Forms.ImageList m_imagesFiltre;
        private System.Windows.Forms.ToolTip m_tooltip;
		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
        private System.Windows.Forms.ImageList m_imagesChamps;
        private System.Windows.Forms.MenuItem m_menuAjouterChampDonnee;
        private System.Windows.Forms.ContextMenu m_menuAjouterChamp;
        private System.Windows.Forms.MenuItem m_menuAjouterChampCalcule;
	}
}
