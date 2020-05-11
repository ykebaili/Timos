namespace timos.interventions
{
	partial class CPanelPlanification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPanelPlanification));
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn3 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn4 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn5 = new sc2i.win32.common.GLColumn();
            this.m_panelAPreplanifier = new sc2i.win32.common.C2iPanel(this.components);
            this.m_panelTachesPrePlanifiees = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_wndListeInterAPlanifier = new sc2i.win32.common.GlacialList();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_lnkDetailIntervention = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkAjouterIntervention = new sc2i.win32.common.CWndLinkStd();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_panelFiltresInter = new System.Windows.Forms.Panel();
            this.m_picIntersFiltre = new System.Windows.Forms.PictureBox();
            this.m_chkIntersFiltre = new System.Windows.Forms.CheckBox();
            this.m_panelListInters = new System.Windows.Forms.Panel();
            this.m_picIntersSurListe = new System.Windows.Forms.PictureBox();
            this.m_chkIntersSurListe = new System.Windows.Forms.CheckBox();
            this.m_chkIntersNonAffectées = new System.Windows.Forms.CheckBox();
            this.m_chkIntersNonPlanifiées = new System.Windows.Forms.CheckBox();
            this.m_chkIntersSurSiteSelectionné = new System.Windows.Forms.CheckBox();
            this.m_lblDatesListe = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_timerRefreshInterventionsPlanifiees = new System.Windows.Forms.Timer(this.components);
            this.m_tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_btnModeIntervenants = new System.Windows.Forms.RadioButton();
            this.m_panelMode = new System.Windows.Forms.Panel();
            this.m_btnTailleLigne = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.m_btnModeRessources = new System.Windows.Forms.RadioButton();
            this.m_btnOpenConfig = new System.Windows.Forms.PictureBox();
            this.m_btnSaveConfig = new System.Windows.Forms.PictureBox();
            this.m_menuListeEntitesInter = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_menuFiltresInters = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_menuLoadFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_menuOpenConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuSaveConfig = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_menuSaveConfigDirect = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuSaveConfigAs = new System.Windows.Forms.ToolStripMenuItem();
            this.m_controlePlanning = new timos.win32.composants.CControlePlanning();
            this.m_panelAPreplanifier.SuspendLayout();
            this.m_panelTachesPrePlanifiees.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.m_panelFiltresInter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_picIntersFiltre)).BeginInit();
            this.m_panelListInters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_picIntersSurListe)).BeginInit();
            this.m_panelMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnOpenConfig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnSaveConfig)).BeginInit();
            this.m_menuLoadFile.SuspendLayout();
            this.m_menuSaveConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelAPreplanifier
            // 
            this.m_panelAPreplanifier.Controls.Add(this.m_panelTachesPrePlanifiees);
            this.m_panelAPreplanifier.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_panelAPreplanifier.Location = new System.Drawing.Point(0, 222);
            this.m_panelAPreplanifier.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelAPreplanifier, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelAPreplanifier.Name = "m_panelAPreplanifier";
            this.m_panelAPreplanifier.Size = new System.Drawing.Size(847, 120);
            this.m_panelAPreplanifier.TabIndex = 1;
            // 
            // m_panelTachesPrePlanifiees
            // 
            this.m_panelTachesPrePlanifiees.Controls.Add(this.panel3);
            this.m_panelTachesPrePlanifiees.Controls.Add(this.panel1);
            this.m_panelTachesPrePlanifiees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelTachesPrePlanifiees.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelTachesPrePlanifiees, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelTachesPrePlanifiees.Name = "m_panelTachesPrePlanifiees";
            this.m_panelTachesPrePlanifiees.Size = new System.Drawing.Size(847, 120);
            this.m_panelTachesPrePlanifiees.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.m_wndListeInterAPlanifier);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(242, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(605, 120);
            this.panel3.TabIndex = 8;
            // 
            // m_wndListeInterAPlanifier
            // 
            this.m_wndListeInterAPlanifier.AllowColumnResize = true;
            this.m_wndListeInterAPlanifier.AllowMultiselect = true;
            this.m_wndListeInterAPlanifier.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.m_wndListeInterAPlanifier.AlternatingColors = false;
            this.m_wndListeInterAPlanifier.AutoHeight = true;
            this.m_wndListeInterAPlanifier.AutoSort = true;
            this.m_wndListeInterAPlanifier.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.m_wndListeInterAPlanifier.CanChangeActivationCheckBoxes = false;
            this.m_wndListeInterAPlanifier.CheckBoxes = false;
            this.m_wndListeInterAPlanifier.CheckedItems = ((System.Collections.ArrayList)(resources.GetObject("m_wndListeInterAPlanifier.CheckedItems")));
            glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "col_datedebut";
            glColumn1.Propriete = "DateDebutPrePlanifiee";
            glColumn1.Text = "Start Date|610";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 100;
            glColumn2.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn2.ActiveControlItems")));
            glColumn2.BackColor = System.Drawing.Color.Transparent;
            glColumn2.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn2.ForColor = System.Drawing.Color.Black;
            glColumn2.ImageIndex = -1;
            glColumn2.IsCheckColumn = false;
            glColumn2.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn2.Name = "colDateFin";
            glColumn2.Propriete = "DateFinPrePlanifiee";
            glColumn2.Text = "End date|20651";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 100;
            glColumn3.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn3.ActiveControlItems")));
            glColumn3.BackColor = System.Drawing.Color.Transparent;
            glColumn3.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn3.ForColor = System.Drawing.Color.Black;
            glColumn3.ImageIndex = -1;
            glColumn3.IsCheckColumn = false;
            glColumn3.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn3.Name = "m_colSite";
            glColumn3.Propriete = "Site.Libelle";
            glColumn3.Text = "Site|20657";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn3.Width = 150;
            glColumn4.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn4.ActiveControlItems")));
            glColumn4.BackColor = System.Drawing.Color.Transparent;
            glColumn4.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn4.ForColor = System.Drawing.Color.Black;
            glColumn4.ImageIndex = -1;
            glColumn4.IsCheckColumn = false;
            glColumn4.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn4.Name = "col_type";
            glColumn4.Propriete = "TypeIntervention.Libelle";
            glColumn4.Text = "Type|54";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn4.Width = 100;
            glColumn5.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn5.ActiveControlItems")));
            glColumn5.BackColor = System.Drawing.Color.Transparent;
            glColumn5.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn5.ForColor = System.Drawing.Color.Black;
            glColumn5.ImageIndex = -1;
            glColumn5.IsCheckColumn = false;
            glColumn5.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn5.Name = "m_colLibelle";
            glColumn5.Propriete = "Libelle";
            glColumn5.Text = "Label|50";
            glColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn5.Width = 250;
            this.m_wndListeInterAPlanifier.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1,
            glColumn2,
            glColumn3,
            glColumn4,
            glColumn5});
            this.m_wndListeInterAPlanifier.ContexteUtilisation = "";
            this.m_wndListeInterAPlanifier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeInterAPlanifier.EnableCustomisation = true;
            this.m_wndListeInterAPlanifier.FocusedItem = null;
            this.m_wndListeInterAPlanifier.FullRowSelect = true;
            this.m_wndListeInterAPlanifier.GLGridLines = sc2i.win32.common.GLGridStyles.gridSolid;
            this.m_wndListeInterAPlanifier.GridColor = System.Drawing.Color.Gray;
            this.m_wndListeInterAPlanifier.HasImages = false;
            this.m_wndListeInterAPlanifier.HeaderHeight = 22;
            this.m_wndListeInterAPlanifier.HeaderStyle = sc2i.win32.common.GLHeaderStyles.Normal;
            this.m_wndListeInterAPlanifier.HeaderTextColor = System.Drawing.Color.Black;
            this.m_wndListeInterAPlanifier.HeaderTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.m_wndListeInterAPlanifier.HeaderVisible = true;
            this.m_wndListeInterAPlanifier.HeaderWordWrap = false;
            this.m_wndListeInterAPlanifier.HotColumnIndex = -1;
            this.m_wndListeInterAPlanifier.HotItemIndex = -1;
            this.m_wndListeInterAPlanifier.HotTracking = false;
            this.m_wndListeInterAPlanifier.HotTrackingColor = System.Drawing.Color.LightGray;
            this.m_wndListeInterAPlanifier.ImageList = null;
            this.m_wndListeInterAPlanifier.ItemHeight = 17;
            this.m_wndListeInterAPlanifier.ItemWordWrap = false;
            this.m_wndListeInterAPlanifier.ListeSource = null;
            this.m_wndListeInterAPlanifier.Location = new System.Drawing.Point(0, 19);
            this.m_wndListeInterAPlanifier.MaxHeight = 17;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeInterAPlanifier, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_wndListeInterAPlanifier.Name = "m_wndListeInterAPlanifier";
            this.m_wndListeInterAPlanifier.SelectedTextColor = System.Drawing.Color.White;
            this.m_wndListeInterAPlanifier.SelectionColor = System.Drawing.Color.DarkBlue;
            this.m_wndListeInterAPlanifier.ShowBorder = true;
            this.m_wndListeInterAPlanifier.ShowFocusRect = true;
            this.m_wndListeInterAPlanifier.Size = new System.Drawing.Size(605, 101);
            this.m_wndListeInterAPlanifier.SortIndex = 0;
            this.m_wndListeInterAPlanifier.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.m_wndListeInterAPlanifier.TabIndex = 4;
            this.m_wndListeInterAPlanifier.Text = "m_listeAPlanifier";
            this.m_wndListeInterAPlanifier.TrierAuClicSurEnteteColonne = true;
            this.m_wndListeInterAPlanifier.OnBeginDragItem += new sc2i.win32.common.GlacialList.DragItemEventHandler(this.m_wndListeInterAPlanifier_OnBeginDragItem);
            this.m_wndListeInterAPlanifier.MouseMove += new System.Windows.Forms.MouseEventHandler(this.m_wndListeInterAPlanifier_MouseMove);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_lnkDetailIntervention);
            this.panel2.Controls.Add(this.m_lnkAjouterIntervention);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(605, 19);
            this.panel2.TabIndex = 7;
            // 
            // m_lnkDetailIntervention
            // 
            this.m_lnkDetailIntervention.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkDetailIntervention.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkDetailIntervention.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkDetailIntervention.Location = new System.Drawing.Point(77, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkDetailIntervention, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lnkDetailIntervention.Name = "m_lnkDetailIntervention";
            this.m_lnkDetailIntervention.Size = new System.Drawing.Size(77, 19);
            this.m_lnkDetailIntervention.TabIndex = 4;
            this.m_lnkDetailIntervention.TypeLien = sc2i.win32.common.TypeLinkStd.Modification;
            this.m_lnkDetailIntervention.LinkClicked += new System.EventHandler(this.m_lnkDetailIntervention_LinkClicked);
            // 
            // m_lnkAjouterIntervention
            // 
            this.m_lnkAjouterIntervention.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAjouterIntervention.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkAjouterIntervention.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkAjouterIntervention.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAjouterIntervention, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkAjouterIntervention.Name = "m_lnkAjouterIntervention";
            this.m_lnkAjouterIntervention.Size = new System.Drawing.Size(77, 19);
            this.m_lnkAjouterIntervention.TabIndex = 5;
            this.m_lnkAjouterIntervention.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAjouterIntervention.Visible = false;
            this.m_lnkAjouterIntervention.LinkClicked += new System.EventHandler(this.m_lnkAjouterIntervention_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.m_panelFiltresInter);
            this.panel1.Controls.Add(this.m_panelListInters);
            this.panel1.Controls.Add(this.m_chkIntersNonAffectées);
            this.panel1.Controls.Add(this.m_chkIntersNonPlanifiées);
            this.panel1.Controls.Add(this.m_chkIntersSurSiteSelectionné);
            this.panel1.Controls.Add(this.m_lblDatesListe);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(242, 120);
            this.panel1.TabIndex = 6;
            // 
            // m_panelFiltresInter
            // 
            this.m_panelFiltresInter.Controls.Add(this.m_picIntersFiltre);
            this.m_panelFiltresInter.Controls.Add(this.m_chkIntersFiltre);
            this.m_panelFiltresInter.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelFiltresInter.Location = new System.Drawing.Point(0, 99);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelFiltresInter, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelFiltresInter.Name = "m_panelFiltresInter";
            this.m_panelFiltresInter.Size = new System.Drawing.Size(242, 17);
            this.m_panelFiltresInter.TabIndex = 9;
            // 
            // m_picIntersFiltre
            // 
            this.m_picIntersFiltre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_picIntersFiltre.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_picIntersFiltre.Image = ((System.Drawing.Image)(resources.GetObject("m_picIntersFiltre.Image")));
            this.m_picIntersFiltre.Location = new System.Drawing.Point(106, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_picIntersFiltre, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_picIntersFiltre.Name = "m_picIntersFiltre";
            this.m_picIntersFiltre.Size = new System.Drawing.Size(17, 17);
            this.m_picIntersFiltre.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_picIntersFiltre.TabIndex = 10;
            this.m_picIntersFiltre.TabStop = false;
            this.m_picIntersFiltre.Click += new System.EventHandler(this.m_picIntersFiltre_Click);
            // 
            // m_chkIntersFiltre
            // 
            this.m_chkIntersFiltre.AutoSize = true;
            this.m_chkIntersFiltre.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_chkIntersFiltre.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkIntersFiltre, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_chkIntersFiltre.Name = "m_chkIntersFiltre";
            this.m_chkIntersFiltre.Size = new System.Drawing.Size(106, 17);
            this.m_chkIntersFiltre.TabIndex = 11;
            this.m_chkIntersFiltre.Text = "Other filter|20661";
            this.m_chkIntersFiltre.UseVisualStyleBackColor = true;
            this.m_chkIntersFiltre.CheckedChanged += new System.EventHandler(this.m_chkIntersFiltre_CheckedChanged);
            // 
            // m_panelListInters
            // 
            this.m_panelListInters.Controls.Add(this.m_picIntersSurListe);
            this.m_panelListInters.Controls.Add(this.m_chkIntersSurListe);
            this.m_panelListInters.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelListInters.Location = new System.Drawing.Point(0, 82);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelListInters, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelListInters.Name = "m_panelListInters";
            this.m_panelListInters.Size = new System.Drawing.Size(242, 17);
            this.m_panelListInters.TabIndex = 6;
            // 
            // m_picIntersSurListe
            // 
            this.m_picIntersSurListe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_picIntersSurListe.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_picIntersSurListe.Image = ((System.Drawing.Image)(resources.GetObject("m_picIntersSurListe.Image")));
            this.m_picIntersSurListe.Location = new System.Drawing.Point(74, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_picIntersSurListe, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_picIntersSurListe.Name = "m_picIntersSurListe";
            this.m_picIntersSurListe.Size = new System.Drawing.Size(17, 17);
            this.m_picIntersSurListe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_picIntersSurListe.TabIndex = 10;
            this.m_picIntersSurListe.TabStop = false;
            this.m_picIntersSurListe.Click += new System.EventHandler(this.m_picIntersSurListe_Click);
            // 
            // m_chkIntersSurListe
            // 
            this.m_chkIntersSurListe.AutoSize = true;
            this.m_chkIntersSurListe.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_chkIntersSurListe.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkIntersSurListe, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_chkIntersSurListe.Name = "m_chkIntersSurListe";
            this.m_chkIntersSurListe.Size = new System.Drawing.Size(74, 17);
            this.m_chkIntersSurListe.TabIndex = 9;
            this.m_chkIntersSurListe.Text = "List|20658";
            this.m_chkIntersSurListe.UseVisualStyleBackColor = true;
            this.m_chkIntersSurListe.CheckedChanged += new System.EventHandler(this.m_chkIntersSurListe_CheckedChanged);
            // 
            // m_chkIntersNonAffectées
            // 
            this.m_chkIntersNonAffectées.AutoSize = true;
            this.m_chkIntersNonAffectées.Checked = true;
            this.m_chkIntersNonAffectées.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkIntersNonAffectées.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_chkIntersNonAffectées.Location = new System.Drawing.Point(0, 65);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkIntersNonAffectées, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_chkIntersNonAffectées.Name = "m_chkIntersNonAffectées";
            this.m_chkIntersNonAffectées.Size = new System.Drawing.Size(242, 17);
            this.m_chkIntersNonAffectées.TabIndex = 10;
            this.m_chkIntersNonAffectées.Text = "Not assigned|20662";
            this.m_chkIntersNonAffectées.UseVisualStyleBackColor = true;
            this.m_chkIntersNonAffectées.CheckedChanged += new System.EventHandler(this.m_chkIntersNonAffectées_CheckedChanged);
            // 
            // m_chkIntersNonPlanifiées
            // 
            this.m_chkIntersNonPlanifiées.AutoSize = true;
            this.m_chkIntersNonPlanifiées.Checked = true;
            this.m_chkIntersNonPlanifiées.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkIntersNonPlanifiées.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_chkIntersNonPlanifiées.Location = new System.Drawing.Point(0, 48);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkIntersNonPlanifiées, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_chkIntersNonPlanifiées.Name = "m_chkIntersNonPlanifiées";
            this.m_chkIntersNonPlanifiées.Size = new System.Drawing.Size(242, 17);
            this.m_chkIntersNonPlanifiées.TabIndex = 8;
            this.m_chkIntersNonPlanifiées.Text = "Not planned|20660";
            this.m_chkIntersNonPlanifiées.UseVisualStyleBackColor = true;
            this.m_chkIntersNonPlanifiées.CheckedChanged += new System.EventHandler(this.m_chkIntersNonPlanifiées_CheckedChanged);
            // 
            // m_chkIntersSurSiteSelectionné
            // 
            this.m_chkIntersSurSiteSelectionné.AutoSize = true;
            this.m_chkIntersSurSiteSelectionné.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_chkIntersSurSiteSelectionné.Location = new System.Drawing.Point(0, 31);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkIntersSurSiteSelectionné, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_chkIntersSurSiteSelectionné.Name = "m_chkIntersSurSiteSelectionné";
            this.m_chkIntersSurSiteSelectionné.Size = new System.Drawing.Size(242, 17);
            this.m_chkIntersSurSiteSelectionné.TabIndex = 6;
            this.m_chkIntersSurSiteSelectionné.Text = "Filter on | 20658";
            this.m_chkIntersSurSiteSelectionné.UseVisualStyleBackColor = true;
            this.m_chkIntersSurSiteSelectionné.CheckedChanged += new System.EventHandler(this.m_chkIntersSurSiteSelectionné_CheckedChanged);
            // 
            // m_lblDatesListe
            // 
            this.m_lblDatesListe.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_lblDatesListe.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblDatesListe, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblDatesListe.Name = "m_lblDatesListe";
            this.m_lblDatesListe.Size = new System.Drawing.Size(242, 31);
            this.m_lblDatesListe.TabIndex = 5;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Black;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 219);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitter1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(847, 3);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // m_timerRefreshInterventionsPlanifiees
            // 
            this.m_timerRefreshInterventionsPlanifiees.Interval = 500;
            this.m_timerRefreshInterventionsPlanifiees.Tick += new System.EventHandler(this.m_timerRefreshInterventionsPlanifiees_Tick);
            // 
            // m_btnModeIntervenants
            // 
            this.m_btnModeIntervenants.AutoSize = true;
            this.m_btnModeIntervenants.Checked = true;
            this.m_btnModeIntervenants.Location = new System.Drawing.Point(3, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnModeIntervenants, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnModeIntervenants.Name = "m_btnModeIntervenants";
            this.m_btnModeIntervenants.Size = new System.Drawing.Size(120, 17);
            this.m_btnModeIntervenants.TabIndex = 4;
            this.m_btnModeIntervenants.TabStop = true;
            this.m_btnModeIntervenants.Text = "Operators mode|609";
            this.m_btnModeIntervenants.UseVisualStyleBackColor = true;
            this.m_btnModeIntervenants.CheckedChanged += new System.EventHandler(this.m_btnModeIntervenants_CheckedChanged);
            // 
            // m_panelMode
            // 
            this.m_panelMode.Controls.Add(this.m_btnTailleLigne);
            this.m_panelMode.Controls.Add(this.label1);
            this.m_panelMode.Controls.Add(this.m_btnModeRessources);
            this.m_panelMode.Controls.Add(this.m_btnModeIntervenants);
            this.m_panelMode.Controls.Add(this.m_btnOpenConfig);
            this.m_panelMode.Controls.Add(this.m_btnSaveConfig);
            this.m_panelMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelMode.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelMode, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelMode.Name = "m_panelMode";
            this.m_panelMode.Size = new System.Drawing.Size(847, 23);
            this.m_panelMode.TabIndex = 5;
            // 
            // m_btnTailleLigne
            // 
            this.m_btnTailleLigne.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnTailleLigne.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_btnTailleLigne.Image = global::timos.Properties.Resources.ResizeLigne;
            this.m_btnTailleLigne.Location = new System.Drawing.Point(767, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnTailleLigne, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnTailleLigne.Name = "m_btnTailleLigne";
            this.m_btnTailleLigne.Size = new System.Drawing.Size(23, 23);
            this.m_btnTailleLigne.TabIndex = 6;
            this.m_btnTailleLigne.UseVisualStyleBackColor = true;
            this.m_btnTailleLigne.Click += new System.EventHandler(this.m_btnTailleLigne_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(790, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 23);
            this.label1.TabIndex = 9;
            // 
            // m_btnModeRessources
            // 
            this.m_btnModeRessources.AutoSize = true;
            this.m_btnModeRessources.Location = new System.Drawing.Point(166, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnModeRessources, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnModeRessources.Name = "m_btnModeRessources";
            this.m_btnModeRessources.Size = new System.Drawing.Size(125, 17);
            this.m_btnModeRessources.TabIndex = 5;
            this.m_btnModeRessources.TabStop = true;
            this.m_btnModeRessources.Text = "Resources mode|613";
            this.m_btnModeRessources.UseVisualStyleBackColor = true;
            this.m_btnModeRessources.CheckedChanged += new System.EventHandler(this.m_btnModeRessources_CheckedChanged);
            // 
            // m_btnOpenConfig
            // 
            this.m_btnOpenConfig.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnOpenConfig.Image = global::timos.Properties.Resources.OpenFile;
            this.m_btnOpenConfig.Location = new System.Drawing.Point(801, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnOpenConfig, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnOpenConfig.Name = "m_btnOpenConfig";
            this.m_btnOpenConfig.Size = new System.Drawing.Size(23, 23);
            this.m_btnOpenConfig.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_btnOpenConfig.TabIndex = 10;
            this.m_btnOpenConfig.TabStop = false;
            this.m_btnOpenConfig.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_btnOpenConfig_MouseUp);
            // 
            // m_btnSaveConfig
            // 
            this.m_btnSaveConfig.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnSaveConfig.Image = global::timos.Properties.Resources.SaveFile;
            this.m_btnSaveConfig.Location = new System.Drawing.Point(824, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnSaveConfig, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnSaveConfig.Name = "m_btnSaveConfig";
            this.m_btnSaveConfig.Size = new System.Drawing.Size(23, 23);
            this.m_btnSaveConfig.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_btnSaveConfig.TabIndex = 11;
            this.m_btnSaveConfig.TabStop = false;
            this.m_btnSaveConfig.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_btnSaveConfig_MouseUp);
            // 
            // m_menuListeEntitesInter
            // 
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_menuListeEntitesInter, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_menuListeEntitesInter.Name = "m_menuListeEntitesInter";
            this.m_menuListeEntitesInter.Size = new System.Drawing.Size(61, 4);
            // 
            // m_menuFiltresInters
            // 
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_menuFiltresInters, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_menuFiltresInters.Name = "m_menuListeEntitesInter";
            this.m_menuFiltresInters.Size = new System.Drawing.Size(61, 4);
            // 
            // m_menuLoadFile
            // 
            this.m_menuLoadFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_menuOpenConfig});
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_menuLoadFile, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_menuLoadFile.Name = "m_menuLoadFile";
            this.m_menuLoadFile.Size = new System.Drawing.Size(146, 26);
            this.m_menuLoadFile.Opening += new System.ComponentModel.CancelEventHandler(this.m_menuLoadFile_Opening);
            // 
            // m_menuOpenConfig
            // 
            this.m_menuOpenConfig.Name = "m_menuOpenConfig";
            this.m_menuOpenConfig.Size = new System.Drawing.Size(145, 22);
            this.m_menuOpenConfig.Text = "Open|20667";
            this.m_menuOpenConfig.Click += new System.EventHandler(this.m_menuOpenConfig_Click);
            // 
            // m_menuSaveConfig
            // 
            this.m_menuSaveConfig.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_menuSaveConfigDirect,
            this.m_menuSaveConfigAs});
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_menuSaveConfig, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_menuSaveConfig.Name = "m_menuSaveConfig";
            this.m_menuSaveConfig.Size = new System.Drawing.Size(158, 70);
            this.m_menuSaveConfig.Opening += new System.ComponentModel.CancelEventHandler(this.m_menuSaveConfig_Opening);
            // 
            // m_menuSaveConfigDirect
            // 
            this.m_menuSaveConfigDirect.Name = "m_menuSaveConfigDirect";
            this.m_menuSaveConfigDirect.Size = new System.Drawing.Size(157, 22);
            this.m_menuSaveConfigDirect.Text = "&Save|20668";
            this.m_menuSaveConfigDirect.Click += new System.EventHandler(this.m_menuSaveConfigDirect_Click);
            // 
            // m_menuSaveConfigAs
            // 
            this.m_menuSaveConfigAs.Name = "m_menuSaveConfigAs";
            this.m_menuSaveConfigAs.Size = new System.Drawing.Size(157, 22);
            this.m_menuSaveConfigAs.Text = "Save &as|20669";
            this.m_menuSaveConfigAs.Click += new System.EventHandler(this.m_menuSaveConfigAs_Click);
            // 
            // m_controlePlanning
            // 
            this.m_controlePlanning.AutoTooltip = true;
            this.m_controlePlanning.BaseAffichee = null;
            this.m_controlePlanning.DateDebut = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
            this.m_controlePlanning.DateFin = new System.DateTime(1950, 1, 2, 0, 0, 0, 0);
            this.m_controlePlanning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_controlePlanning.ElementAInterventionSelectionne = null;
            this.m_controlePlanning.EnableAffichageDatesEnBas = true;
            this.m_controlePlanning.HauteurLigne = 26;
            this.m_controlePlanning.Location = new System.Drawing.Point(0, 23);
            this.m_controlePlanning.LockEdition = false;
            this.m_controlePlanning.MasquerEntetesLignes = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_controlePlanning, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_controlePlanning.Name = "m_controlePlanning";
            this.m_controlePlanning.Size = new System.Drawing.Size(847, 196);
            this.m_controlePlanning.TabIndex = 0;
            this.m_controlePlanning.TypeRessourcesAAffecter = typeof(timos.acteurs.CActeur);
            this.m_controlePlanning.OnChangeBornesDates += new System.EventHandler(this.m_controlePlanning_OnChangeBornesDates);
            this.m_controlePlanning.OnEditerIntervention += new System.EventHandler(this.m_controlePlanning_OnEditerIntervention);
            this.m_controlePlanning.OnChangeSelectionElementAIntervention += new System.EventHandler(this.m_controlePlanning_OnChangeSelectionElementAIntervention);
            // 
            // CPanelPlanification
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_controlePlanning);
            this.Controls.Add(this.m_panelMode);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.m_panelAPreplanifier);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CPanelPlanification";
            this.Size = new System.Drawing.Size(847, 342);
            this.m_panelAPreplanifier.ResumeLayout(false);
            this.m_panelTachesPrePlanifiees.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.m_panelFiltresInter.ResumeLayout(false);
            this.m_panelFiltresInter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_picIntersFiltre)).EndInit();
            this.m_panelListInters.ResumeLayout(false);
            this.m_panelListInters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_picIntersSurListe)).EndInit();
            this.m_panelMode.ResumeLayout(false);
            this.m_panelMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnOpenConfig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnSaveConfig)).EndInit();
            this.m_menuLoadFile.ResumeLayout(false);
            this.m_menuSaveConfig.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private timos.win32.composants.CControlePlanning m_controlePlanning;
        private sc2i.win32.common.C2iPanel m_panelAPreplanifier;
        private sc2i.win32.common.GlacialList m_wndListeInterAPlanifier;
		private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Timer m_timerRefreshInterventionsPlanifiees;
		private sc2i.win32.common.CWndLinkStd m_lnkAjouterIntervention;
		private sc2i.win32.common.CWndLinkStd m_lnkDetailIntervention;
		private System.Windows.Forms.ToolTip m_tooltip;
		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private System.Windows.Forms.Panel m_panelTachesPrePlanifiees;
		private System.Windows.Forms.RadioButton m_btnModeIntervenants;
		private System.Windows.Forms.Panel m_panelMode;
		private System.Windows.Forms.RadioButton m_btnModeRessources;
        private System.Windows.Forms.Button m_btnTailleLigne;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label m_lblDatesListe;
        private System.Windows.Forms.CheckBox m_chkIntersSurSiteSelectionné;
        private System.Windows.Forms.CheckBox m_chkIntersNonPlanifiées;
        private System.Windows.Forms.CheckBox m_chkIntersSurListe;
        private System.Windows.Forms.Panel m_panelFiltresInter;
        private System.Windows.Forms.PictureBox m_picIntersFiltre;
        private System.Windows.Forms.Panel m_panelListInters;
        private System.Windows.Forms.PictureBox m_picIntersSurListe;
        private System.Windows.Forms.CheckBox m_chkIntersFiltre;
        private System.Windows.Forms.ContextMenuStrip m_menuListeEntitesInter;
        private System.Windows.Forms.ContextMenuStrip m_menuFiltresInters;
        private System.Windows.Forms.CheckBox m_chkIntersNonAffectées;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox m_btnOpenConfig;
        private System.Windows.Forms.PictureBox m_btnSaveConfig;
        private System.Windows.Forms.ContextMenuStrip m_menuLoadFile;
        private System.Windows.Forms.ToolStripMenuItem m_menuOpenConfig;
        private System.Windows.Forms.ContextMenuStrip m_menuSaveConfig;
        private System.Windows.Forms.ToolStripMenuItem m_menuSaveConfigDirect;
        private System.Windows.Forms.ToolStripMenuItem m_menuSaveConfigAs;
	}
}
