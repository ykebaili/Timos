namespace timos.interventions
{
	partial class CPanelInfoGel
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
            sc2i.win32.common.GLColumn glColumn3 = new sc2i.win32.common.GLColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPanelInfoGel));
            sc2i.win32.common.GLColumn glColumn4 = new sc2i.win32.common.GLColumn();
            this.m_panelGelEtLinks = new System.Windows.Forms.Panel();
            this.m_panelInfoGel = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_lblInfoDebutGel = new System.Windows.Forms.Label();
            this.m_lblInfoFinGel = new System.Windows.Forms.Label();
            this.m_panDates = new System.Windows.Forms.Panel();
            this.m_lblFrezingCause = new System.Windows.Forms.Label();
            this.m_lnkEndDate = new System.Windows.Forms.LinkLabel();
            this.m_lnkStart = new System.Windows.Forms.LinkLabel();
            this.m_lblDatesGel = new System.Windows.Forms.Label();
            this.m_lnkGeler = new System.Windows.Forms.LinkLabel();
            this.m_lnkDegeler = new System.Windows.Forms.LinkLabel();
            this.m_wndListeGels = new sc2i.win32.common.GlacialList();
            this.m_lblGel = new System.Windows.Forms.Label();
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.m_chkAfficherQueLaPhaseEnCours = new System.Windows.Forms.CheckBox();
            this.Load += new System.EventHandler(CPanelInfoGel_Load);
            this.m_panelGelEtLinks.SuspendLayout();
            this.m_panelInfoGel.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.m_panDates.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelGelEtLinks
            // 
            this.m_panelGelEtLinks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelGelEtLinks.Controls.Add(this.m_panelInfoGel);
            this.m_panelGelEtLinks.Controls.Add(this.m_lnkGeler);
            this.m_panelGelEtLinks.Controls.Add(this.m_lnkDegeler);
            this.m_panelGelEtLinks.Location = new System.Drawing.Point(282, 22);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelGelEtLinks, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelGelEtLinks.Name = "m_panelGelEtLinks";
            this.m_panelGelEtLinks.Size = new System.Drawing.Size(292, 223);
            this.m_panelGelEtLinks.TabIndex = 7;
            // 
            // m_panelInfoGel
            // 
            this.m_panelInfoGel.Controls.Add(this.splitContainer1);
            this.m_panelInfoGel.Controls.Add(this.m_panDates);
            this.m_panelInfoGel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelInfoGel.Location = new System.Drawing.Point(0, 26);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelInfoGel, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelInfoGel.Name = "m_panelInfoGel";
            this.m_panelInfoGel.Size = new System.Drawing.Size(292, 197);
            this.m_panelInfoGel.TabIndex = 6;
            this.m_panelInfoGel.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m_lblInfoDebutGel);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1.Panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_lblInfoFinGel);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1.Panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.splitContainer1.Size = new System.Drawing.Size(292, 148);
            this.splitContainer1.SplitterDistance = 72;
            this.splitContainer1.TabIndex = 2;
            // 
            // m_lblInfoDebutGel
            // 
            this.m_lblInfoDebutGel.BackColor = System.Drawing.Color.White;
            this.m_lblInfoDebutGel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblInfoDebutGel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lblInfoDebutGel.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblInfoDebutGel, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblInfoDebutGel.Name = "m_lblInfoDebutGel";
            this.m_lblInfoDebutGel.Size = new System.Drawing.Size(292, 72);
            this.m_lblInfoDebutGel.TabIndex = 0;
            // 
            // m_lblInfoFinGel
            // 
            this.m_lblInfoFinGel.BackColor = System.Drawing.Color.White;
            this.m_lblInfoFinGel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblInfoFinGel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lblInfoFinGel.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblInfoFinGel, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblInfoFinGel.Name = "m_lblInfoFinGel";
            this.m_lblInfoFinGel.Size = new System.Drawing.Size(292, 72);
            this.m_lblInfoFinGel.TabIndex = 1;
            // 
            // m_panDates
            // 
            this.m_panDates.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panDates.Controls.Add(this.m_lblFrezingCause);
            this.m_panDates.Controls.Add(this.m_lnkEndDate);
            this.m_panDates.Controls.Add(this.m_lnkStart);
            this.m_panDates.Controls.Add(this.m_lblDatesGel);
            this.m_panDates.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panDates.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panDates, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panDates.Name = "m_panDates";
            this.m_panDates.Size = new System.Drawing.Size(292, 49);
            this.m_panDates.TabIndex = 1;
            // 
            // m_lblFrezingCause
            // 
            this.m_lblFrezingCause.Location = new System.Drawing.Point(1, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblFrezingCause, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblFrezingCause.Name = "m_lblFrezingCause";
            this.m_lblFrezingCause.Size = new System.Drawing.Size(290, 22);
            this.m_lblFrezingCause.TabIndex = 3;
            this.m_lblFrezingCause.Text = "Freezing cause";
            // 
            // m_lnkEndDate
            // 
            this.m_lnkEndDate.AutoSize = true;
            this.m_lnkEndDate.Location = new System.Drawing.Point(179, 28);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkEndDate, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkEndDate.Name = "m_lnkEndDate";
            this.m_lnkEndDate.Size = new System.Drawing.Size(59, 13);
            this.m_lnkEndDate.TabIndex = 2;
            this.m_lnkEndDate.TabStop = true;
            this.m_lnkEndDate.Text = "DATEEND";
            this.m_lnkEndDate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkEndDate_LinkClicked);
            // 
            // m_lnkStart
            // 
            this.m_lnkStart.AutoSize = true;
            this.m_lnkStart.Location = new System.Drawing.Point(3, 28);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkStart, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkStart.Name = "m_lnkStart";
            this.m_lnkStart.Size = new System.Drawing.Size(72, 13);
            this.m_lnkStart.TabIndex = 2;
            this.m_lnkStart.TabStop = true;
            this.m_lnkStart.Text = "DATESTART";
            this.m_lnkStart.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkStart_LinkClicked);
            // 
            // m_lblDatesGel
            // 
            this.m_lblDatesGel.AutoSize = true;
            this.m_lblDatesGel.Location = new System.Drawing.Point(81, 28);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblDatesGel, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblDatesGel.Name = "m_lblDatesGel";
            this.m_lblDatesGel.Size = new System.Drawing.Size(57, 13);
            this.m_lblDatesGel.TabIndex = 1;
            this.m_lblDatesGel.Text = "...en cours";
            // 
            // m_lnkGeler
            // 
            this.m_lnkGeler.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_lnkGeler.Location = new System.Drawing.Point(0, 13);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkGeler, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkGeler.Name = "m_lnkGeler";
            this.m_lnkGeler.Size = new System.Drawing.Size(292, 13);
            this.m_lnkGeler.TabIndex = 2;
            this.m_lnkGeler.TabStop = true;
            this.m_lnkGeler.Text = "Freeze Intervention|608";
            this.m_lnkGeler.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkGeler_LinkClicked);
            // 
            // m_lnkDegeler
            // 
            this.m_lnkDegeler.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_lnkDegeler.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkDegeler, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkDegeler.Name = "m_lnkDegeler";
            this.m_lnkDegeler.Size = new System.Drawing.Size(292, 13);
            this.m_lnkDegeler.TabIndex = 3;
            this.m_lnkDegeler.TabStop = true;
            this.m_lnkDegeler.Text = "Unfreeze Intervention|607";
            this.m_lnkDegeler.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkDegeler_LinkClicked);
            // 
            // m_wndListeGels
            // 
            this.m_wndListeGels.AllowColumnResize = true;
            this.m_wndListeGels.AllowMultiselect = false;
            this.m_wndListeGels.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.m_wndListeGels.AlternatingColors = false;
            this.m_wndListeGels.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_wndListeGels.AutoHeight = true;
            this.m_wndListeGels.AutoSort = true;
            this.m_wndListeGels.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.m_wndListeGels.CanChangeActivationCheckBoxes = false;
            this.m_wndListeGels.CheckBoxes = false;
            glColumn3.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn3.ActiveControlItems")));
            glColumn3.BackColor = System.Drawing.Color.Transparent;
            glColumn3.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn3.ForColor = System.Drawing.Color.Black;
            glColumn3.ImageIndex = -1;
            glColumn3.IsCheckColumn = false;
            glColumn3.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn3.Name = "col_start";
            glColumn3.Propriete = "DateDebutString";
            glColumn3.Text = "Start|571";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn3.Width = 120;
            glColumn4.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn4.ActiveControlItems")));
            glColumn4.BackColor = System.Drawing.Color.Transparent;
            glColumn4.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn4.ForColor = System.Drawing.Color.Black;
            glColumn4.ImageIndex = -1;
            glColumn4.IsCheckColumn = false;
            glColumn4.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn4.Name = "col_end";
            glColumn4.Propriete = "DateFinString";
            glColumn4.Text = "End|574";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn4.Width = 120;
            this.m_wndListeGels.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn3,
            glColumn4});
            this.m_wndListeGels.ContexteUtilisation = "";
            this.m_wndListeGels.EnableCustomisation = false;
            this.m_wndListeGels.FocusedItem = null;
            this.m_wndListeGels.FullRowSelect = false;
            this.m_wndListeGels.GLGridLines = sc2i.win32.common.GLGridStyles.gridSolid;
            this.m_wndListeGels.GridColor = System.Drawing.Color.Gray;
            this.m_wndListeGels.HeaderHeight = 22;
            this.m_wndListeGels.HeaderStyle = sc2i.win32.common.GLHeaderStyles.Normal;
            this.m_wndListeGels.HeaderTextColor = System.Drawing.Color.Black;
            this.m_wndListeGels.HeaderVisible = true;
            this.m_wndListeGels.HeaderWordWrap = false;
            this.m_wndListeGels.HotColumnIndex = -1;
            this.m_wndListeGels.HotItemIndex = -1;
            this.m_wndListeGels.HotTracking = false;
            this.m_wndListeGels.HotTrackingColor = System.Drawing.Color.LightGray;
            this.m_wndListeGels.ImageList = null;
            this.m_wndListeGels.ItemHeight = 18;
            this.m_wndListeGels.ItemWordWrap = true;
            this.m_wndListeGels.ListeSource = null;
            this.m_wndListeGels.Location = new System.Drawing.Point(3, 22);
            this.m_wndListeGels.MaxHeight = 18;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeGels, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_wndListeGels.Name = "m_wndListeGels";
            this.m_wndListeGels.SelectedTextColor = System.Drawing.Color.White;
            this.m_wndListeGels.SelectionColor = System.Drawing.Color.DarkBlue;
            this.m_wndListeGels.ShowBorder = true;
            this.m_wndListeGels.ShowFocusRect = true;
            this.m_wndListeGels.Size = new System.Drawing.Size(273, 223);
            this.m_wndListeGels.SortIndex = 0;
            this.m_wndListeGels.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.m_wndListeGels.TabIndex = 6;
            this.m_wndListeGels.Text = "lst";
            this.m_wndListeGels.TrierAuClicSurEnteteColonne = true;
            this.m_wndListeGels.OnChangeSelection += new System.EventHandler(this.m_wndListeGels_OnChangeSelection);
            // 
            // m_lblGel
            // 
            this.m_lblGel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblGel.ForeColor = System.Drawing.Color.Black;
            this.m_lblGel.Location = new System.Drawing.Point(0, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblGel, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblGel.Name = "m_lblGel";
            this.m_lblGel.Size = new System.Drawing.Size(117, 16);
            this.m_lblGel.TabIndex = 5;
            this.m_lblGel.Text = "Freezing|606";
            // 
            // m_chkAfficherQueLaPhaseEnCours
            // 
            this.m_chkAfficherQueLaPhaseEnCours.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_chkAfficherQueLaPhaseEnCours.Location = new System.Drawing.Point(4, 252);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkAfficherQueLaPhaseEnCours, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_chkAfficherQueLaPhaseEnCours.Name = "m_chkAfficherQueLaPhaseEnCours";
            this.m_chkAfficherQueLaPhaseEnCours.Size = new System.Drawing.Size(396, 18);
            this.m_chkAfficherQueLaPhaseEnCours.TabIndex = 8;
            this.m_chkAfficherQueLaPhaseEnCours.Text = "Display only current phase freezing|10011";
            this.m_chkAfficherQueLaPhaseEnCours.UseVisualStyleBackColor = true;
            this.m_chkAfficherQueLaPhaseEnCours.CheckedChanged += new System.EventHandler(this.m_chkAfficherQueLaPhaseEnCours_CheckedChanged);
            // 
            // CPanelInfoGel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_chkAfficherQueLaPhaseEnCours);
            this.Controls.Add(this.m_panelGelEtLinks);
            this.Controls.Add(this.m_wndListeGels);
            this.Controls.Add(this.m_lblGel);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CPanelInfoGel";
            this.Size = new System.Drawing.Size(579, 273);
            this.m_panelGelEtLinks.ResumeLayout(false);
            this.m_panelInfoGel.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.m_panDates.ResumeLayout(false);
            this.m_panDates.PerformLayout();
            this.ResumeLayout(false);

		}

 

		#endregion

		private System.Windows.Forms.Panel m_panelGelEtLinks;
		private System.Windows.Forms.Panel m_panelInfoGel;
		private System.Windows.Forms.Label m_lblInfoDebutGel;
		private System.Windows.Forms.Label m_lblDatesGel;
		private System.Windows.Forms.LinkLabel m_lnkGeler;
		private System.Windows.Forms.LinkLabel m_lnkDegeler;
		private sc2i.win32.common.GlacialList m_wndListeGels;
		private System.Windows.Forms.Label m_lblGel;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Label m_lblInfoFinGel;
		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private System.Windows.Forms.ToolTip m_tooltip;
		private System.Windows.Forms.Panel m_panDates;
		private System.Windows.Forms.LinkLabel m_lnkEndDate;
		private System.Windows.Forms.LinkLabel m_lnkStart;
        private System.Windows.Forms.Label m_lblFrezingCause;
        private System.Windows.Forms.CheckBox m_chkAfficherQueLaPhaseEnCours;
	}
}
