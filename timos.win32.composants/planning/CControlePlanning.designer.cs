using System.Drawing;

namespace timos.win32.composants
{
	partial class CControlePlanning
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
				foreach (Image img in m_cacheImages.Values)
				{
					if (img != null)
						img.Dispose();
				}
				m_cacheImages.Clear();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CControlePlanning));
            this.m_panelEchelle = new System.Windows.Forms.PictureBox();
            this.m_panelDessinCalendrier = new System.Windows.Forms.Panel();
            this.m_panelDessin = new System.Windows.Forms.PictureBox();
            this.m_scroll = new System.Windows.Forms.VScrollBar();
            this.m_imageRessourceOk = new System.Windows.Forms.PictureBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_panelLignes = new System.Windows.Forms.PictureBox();
            this.m_timerShowSelection = new System.Windows.Forms.Timer(this.components);
            this.m_timerRefreshDessin = new System.Windows.Forms.Timer(this.components);
            this.m_tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.m_menuRClickCalendrier = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_menuElementAIntervention = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuARemplacerParDatesInter = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuEditerIntervention = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuDiviserIntervention = new System.Windows.Forms.ToolStripMenuItem();
            this.checkListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_menuPopupInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.m_menuRClickLigne = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_menuMasquerLigne = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.m_menuGestionSites = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuGestionActeurs = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuGestionResources = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.m_menuPopupInfoLigne = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuRClickEchelle = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_menuZoomOn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_menu2Jours = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menu3Jours = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menu5jours = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuSemaine = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menu2Semaines = new System.Windows.Forms.ToolStripMenuItem();
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_timerSendEventChangeDate = new System.Windows.Forms.Timer(this.components);
            this.m_menuEditerElementDeLigne = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tooltipDessin = new timos.win32.composants.ModeleTexteToolTip(this.components);
            this.m_tooltipLignes = new timos.win32.composants.ModeleTexteToolTip(this.components);
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.m_menuARemplacerParDatesEchelle = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.m_panelEchelle)).BeginInit();
            this.m_panelDessinCalendrier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_panelDessin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageRessourceOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_panelLignes)).BeginInit();
            this.m_menuRClickCalendrier.SuspendLayout();
            this.m_menuRClickLigne.SuspendLayout();
            this.m_menuRClickEchelle.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelEchelle
            // 
            this.m_panelEchelle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panelEchelle.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelEchelle.Location = new System.Drawing.Point(198, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEchelle, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelEchelle.Name = "m_panelEchelle";
            this.m_tooltipDessin.SetRichToolTipGetAtMethod(this.m_panelEchelle, "");
            this.m_tooltipLignes.SetRichToolTipGetAtMethod(this.m_panelEchelle, "");
            this.m_tooltipDessin.SetRichToolTipMethodProvider(this.m_panelEchelle, null);
            this.m_tooltipLignes.SetRichToolTipMethodProvider(this.m_panelEchelle, null);
            this.m_panelEchelle.Size = new System.Drawing.Size(396, 18);
            this.m_panelEchelle.TabIndex = 0;
            this.m_panelEchelle.TabStop = false;
            this.m_panelEchelle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.m_panelEchelle_MouseMove);
            this.m_panelEchelle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_panelEchelle_MouseDown);
            this.m_panelEchelle.Paint += new System.Windows.Forms.PaintEventHandler(this.m_wndEchelle_Paint);
            this.m_panelEchelle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_panelEchelle_MouseUp);
            // 
            // m_panelDessinCalendrier
            // 
            this.m_panelDessinCalendrier.BackColor = System.Drawing.Color.White;
            this.m_panelDessinCalendrier.Controls.Add(this.m_panelDessin);
            this.m_panelDessinCalendrier.Controls.Add(this.m_scroll);
            this.m_panelDessinCalendrier.Controls.Add(this.m_imageRessourceOk);
            this.m_panelDessinCalendrier.Controls.Add(this.m_panelEchelle);
            this.m_panelDessinCalendrier.Controls.Add(this.splitter1);
            this.m_panelDessinCalendrier.Controls.Add(this.m_panelLignes);
            this.m_panelDessinCalendrier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelDessinCalendrier.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelDessinCalendrier, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelDessinCalendrier.Name = "m_panelDessinCalendrier";
            this.m_tooltipDessin.SetRichToolTipGetAtMethod(this.m_panelDessinCalendrier, "");
            this.m_tooltipLignes.SetRichToolTipGetAtMethod(this.m_panelDessinCalendrier, "");
            this.m_tooltipDessin.SetRichToolTipMethodProvider(this.m_panelDessinCalendrier, null);
            this.m_tooltipLignes.SetRichToolTipMethodProvider(this.m_panelDessinCalendrier, null);
            this.m_panelDessinCalendrier.Size = new System.Drawing.Size(594, 150);
            this.m_panelDessinCalendrier.TabIndex = 1;
            // 
            // m_panelDessin
            // 
            this.m_panelDessin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panelDessin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelDessin.Location = new System.Drawing.Point(198, 18);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelDessin, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelDessin.Name = "m_panelDessin";
            this.m_tooltipDessin.SetRichToolTipGetAtMethod(this.m_panelDessin, "GetTrancheAt");
            this.m_tooltipLignes.SetRichToolTipGetAtMethod(this.m_panelDessin, "");
            this.m_tooltipDessin.SetRichToolTipMethodProvider(this.m_panelDessin, this);
            this.m_tooltipLignes.SetRichToolTipMethodProvider(this.m_panelDessin, null);
            this.m_panelDessin.Size = new System.Drawing.Size(374, 132);
            this.m_panelDessin.TabIndex = 1;
            this.m_panelDessin.TabStop = false;
            this.m_panelDessin.DragOver += new System.Windows.Forms.DragEventHandler(this.m_panelDessin_DragOver);
            this.m_panelDessin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.m_panelDessin_MouseMove);
            this.m_panelDessin.Click += new System.EventHandler(this.m_panelDessin_Click);
            this.m_panelDessin.DragDrop += new System.Windows.Forms.DragEventHandler(this.m_panelDessin_DragDrop);
            this.m_panelDessin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_panelDessin_MouseDown);
            this.m_panelDessin.Paint += new System.Windows.Forms.PaintEventHandler(this.m_panelDessin_Paint);
            this.m_panelDessin.DragLeave += new System.EventHandler(this.m_panelDessin_DragLeave);
            this.m_panelDessin.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_panelDessin_MouseUp);
            this.m_panelDessin.DragEnter += new System.Windows.Forms.DragEventHandler(this.m_panelDessin_DragEnter);
            // 
            // m_scroll
            // 
            this.m_scroll.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_scroll.Location = new System.Drawing.Point(572, 18);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_scroll, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_scroll.Name = "m_scroll";
            this.m_tooltipLignes.SetRichToolTipGetAtMethod(this.m_scroll, "");
            this.m_tooltipDessin.SetRichToolTipGetAtMethod(this.m_scroll, "");
            this.m_tooltipLignes.SetRichToolTipMethodProvider(this.m_scroll, null);
            this.m_tooltipDessin.SetRichToolTipMethodProvider(this.m_scroll, null);
            this.m_scroll.Size = new System.Drawing.Size(22, 132);
            this.m_scroll.TabIndex = 8;
            this.m_scroll.ValueChanged += new System.EventHandler(this.m_scroll_ValueChanged);
            // 
            // m_imageRessourceOk
            // 
            this.m_imageRessourceOk.Image = ((System.Drawing.Image)(resources.GetObject("m_imageRessourceOk.Image")));
            this.m_imageRessourceOk.Location = new System.Drawing.Point(572, 82);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_imageRessourceOk, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_imageRessourceOk.Name = "m_imageRessourceOk";
            this.m_tooltipDessin.SetRichToolTipGetAtMethod(this.m_imageRessourceOk, "");
            this.m_tooltipLignes.SetRichToolTipGetAtMethod(this.m_imageRessourceOk, "");
            this.m_tooltipDessin.SetRichToolTipMethodProvider(this.m_imageRessourceOk, null);
            this.m_tooltipLignes.SetRichToolTipMethodProvider(this.m_imageRessourceOk, null);
            this.m_imageRessourceOk.Size = new System.Drawing.Size(16, 14);
            this.m_imageRessourceOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.m_imageRessourceOk.TabIndex = 7;
            this.m_imageRessourceOk.TabStop = false;
            this.m_imageRessourceOk.Visible = false;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(195, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitter1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.splitter1.Name = "splitter1";
            this.m_tooltipDessin.SetRichToolTipGetAtMethod(this.splitter1, "");
            this.m_tooltipLignes.SetRichToolTipGetAtMethod(this.splitter1, "");
            this.m_tooltipDessin.SetRichToolTipMethodProvider(this.splitter1, null);
            this.m_tooltipLignes.SetRichToolTipMethodProvider(this.splitter1, null);
            this.splitter1.Size = new System.Drawing.Size(3, 150);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // m_panelLignes
            // 
            this.m_panelLignes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panelLignes.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelLignes.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelLignes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelLignes.Name = "m_panelLignes";
            this.m_tooltipDessin.SetRichToolTipGetAtMethod(this.m_panelLignes, "");
            this.m_tooltipLignes.SetRichToolTipGetAtMethod(this.m_panelLignes, "GetLigneAt");
            this.m_tooltipLignes.SetRichToolTipMethodProvider(this.m_panelLignes, this);
            this.m_tooltipDessin.SetRichToolTipMethodProvider(this.m_panelLignes, null);
            this.m_panelLignes.Size = new System.Drawing.Size(195, 150);
            this.m_panelLignes.TabIndex = 3;
            this.m_panelLignes.TabStop = false;
            this.m_panelLignes.DragDrop += new System.Windows.Forms.DragEventHandler(this.m_panelLignes_DragDrop);
            this.m_panelLignes.Paint += new System.Windows.Forms.PaintEventHandler(this.m_panelLignes_Paint);
            this.m_panelLignes.DragLeave += new System.EventHandler(this.m_panelLignes_DragLeave);
            this.m_panelLignes.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_panelLignes_MouseUp);
            this.m_panelLignes.DragEnter += new System.Windows.Forms.DragEventHandler(this.m_panelLignes_DragEnter);
            // 
            // m_timerShowSelection
            // 
            this.m_timerShowSelection.Interval = 300;
            this.m_timerShowSelection.Tick += new System.EventHandler(this.m_timerShowSelection_Tick);
            // 
            // m_timerRefreshDessin
            // 
            this.m_timerRefreshDessin.Interval = 500;
            this.m_timerRefreshDessin.Tick += new System.EventHandler(this.m_timerRefreshDessin_Tick);
            // 
            // m_menuRClickCalendrier
            // 
            this.m_menuRClickCalendrier.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_menuElementAIntervention,
            this.m_menuARemplacerParDatesInter,
            this.m_menuEditerIntervention,
            this.m_menuDiviserIntervention,
            this.checkListToolStripMenuItem,
            this.toolStripMenuItem2,
            this.m_menuPopupInfo,
            this.toolStripMenuItem3});
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_menuRClickCalendrier, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_menuRClickCalendrier.Name = "m_menuRClickIntervention";
            this.m_tooltipDessin.SetRichToolTipGetAtMethod(this.m_menuRClickCalendrier, "");
            this.m_tooltipLignes.SetRichToolTipGetAtMethod(this.m_menuRClickCalendrier, "");
            this.m_tooltipLignes.SetRichToolTipMethodProvider(this.m_menuRClickCalendrier, null);
            this.m_tooltipDessin.SetRichToolTipMethodProvider(this.m_menuRClickCalendrier, null);
            this.m_menuRClickCalendrier.Size = new System.Drawing.Size(165, 148);
            this.m_menuRClickCalendrier.Opening += new System.ComponentModel.CancelEventHandler(this.m_menuRClickIntervention_Opening);
            // 
            // m_menuElementAIntervention
            // 
            this.m_menuElementAIntervention.Name = "m_menuElementAIntervention";
            this.m_menuElementAIntervention.Size = new System.Drawing.Size(164, 22);
            this.m_menuElementAIntervention.Text = "Task elt";
            this.m_menuElementAIntervention.Click += new System.EventHandler(this.m_menuElementAIntervention_Click);
            // 
            // m_menuARemplacerParDatesInter
            // 
            this.m_menuARemplacerParDatesInter.Name = "m_menuARemplacerParDatesInter";
            this.m_menuARemplacerParDatesInter.Size = new System.Drawing.Size(164, 22);
            this.m_menuARemplacerParDatesInter.Text = "replacebyDates";
            // 
            // m_menuEditerIntervention
            // 
            this.m_menuEditerIntervention.Name = "m_menuEditerIntervention";
            this.m_menuEditerIntervention.Size = new System.Drawing.Size(164, 22);
            this.m_menuEditerIntervention.Text = "Details|20023";
            this.m_menuEditerIntervention.Click += new System.EventHandler(this.m_menuEditerIntervention_Click);
            // 
            // m_menuDiviserIntervention
            // 
            this.m_menuDiviserIntervention.Name = "m_menuDiviserIntervention";
            this.m_menuDiviserIntervention.Size = new System.Drawing.Size(164, 22);
            this.m_menuDiviserIntervention.Text = "Divide|20024";
            this.m_menuDiviserIntervention.Click += new System.EventHandler(this.m_menuDiviserIntervention_Click);
            // 
            // checkListToolStripMenuItem
            // 
            this.checkListToolStripMenuItem.Name = "checkListToolStripMenuItem";
            this.checkListToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.checkListToolStripMenuItem.Text = "Check list|20025";
            this.checkListToolStripMenuItem.Click += new System.EventHandler(this.checkListToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(161, 6);
            // 
            // m_menuPopupInfo
            // 
            this.m_menuPopupInfo.Name = "m_menuPopupInfo";
            this.m_menuPopupInfo.Size = new System.Drawing.Size(164, 22);
            this.m_menuPopupInfo.Text = "Info|20019";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(161, 6);
            // 
            // m_menuRClickLigne
            // 
            this.m_menuRClickLigne.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_menuMasquerLigne,
            this.m_menuEditerElementDeLigne,
            this.toolStripMenuItem5,
            this.m_menuGestionSites,
            this.m_menuGestionActeurs,
            this.m_menuGestionResources,
            this.toolStripMenuItem4,
            this.m_menuPopupInfoLigne});
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_menuRClickLigne, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_menuRClickLigne.Name = "m_menuRClickLigne";
            this.m_tooltipDessin.SetRichToolTipGetAtMethod(this.m_menuRClickLigne, "");
            this.m_tooltipLignes.SetRichToolTipGetAtMethod(this.m_menuRClickLigne, "");
            this.m_tooltipLignes.SetRichToolTipMethodProvider(this.m_menuRClickLigne, null);
            this.m_tooltipDessin.SetRichToolTipMethodProvider(this.m_menuRClickLigne, null);
            this.m_menuRClickLigne.Size = new System.Drawing.Size(170, 148);
            this.m_menuRClickLigne.Text = "Members";
            // 
            // m_menuMasquerLigne
            // 
            this.m_menuMasquerLigne.Name = "m_menuMasquerLigne";
            this.m_menuMasquerLigne.Size = new System.Drawing.Size(169, 22);
            this.m_menuMasquerLigne.Text = "Hide|201";
            this.m_menuMasquerLigne.Click += new System.EventHandler(this.m_menuMasquerLigne_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(166, 6);
            // 
            // m_menuGestionSites
            // 
            this.m_menuGestionSites.Name = "m_menuGestionSites";
            this.m_menuGestionSites.Size = new System.Drawing.Size(169, 22);
            this.m_menuGestionSites.Text = "Sites|20015";
            this.m_menuGestionSites.DropDownOpening += new System.EventHandler(this.m_menuAddMember_DropDownOpening);
            // 
            // m_menuGestionActeurs
            // 
            this.m_menuGestionActeurs.Name = "m_menuGestionActeurs";
            this.m_menuGestionActeurs.Size = new System.Drawing.Size(169, 22);
            this.m_menuGestionActeurs.Text = "Members|20017";
            // 
            // m_menuGestionResources
            // 
            this.m_menuGestionResources.Name = "m_menuGestionResources";
            this.m_menuGestionResources.Size = new System.Drawing.Size(169, 22);
            this.m_menuGestionResources.Text = "Resources|20018";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(166, 6);
            // 
            // m_menuPopupInfoLigne
            // 
            this.m_menuPopupInfoLigne.Name = "m_menuPopupInfoLigne";
            this.m_menuPopupInfoLigne.Size = new System.Drawing.Size(169, 22);
            this.m_menuPopupInfoLigne.Text = "info|20019";
            // 
            // m_menuRClickEchelle
            // 
            this.m_menuRClickEchelle.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_menuZoomOn,
            this.toolStripMenuItem6,
            this.m_menuARemplacerParDatesEchelle,
            this.toolStripMenuItem1,
            this.m_menu2Jours,
            this.m_menu3Jours,
            this.m_menu5jours,
            this.m_menuSemaine,
            this.m_menu2Semaines});
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_menuRClickEchelle, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_menuRClickEchelle.Name = "m_menuRClickEchelle";
            this.m_tooltipDessin.SetRichToolTipGetAtMethod(this.m_menuRClickEchelle, "");
            this.m_tooltipLignes.SetRichToolTipGetAtMethod(this.m_menuRClickEchelle, "");
            this.m_tooltipLignes.SetRichToolTipMethodProvider(this.m_menuRClickEchelle, null);
            this.m_tooltipDessin.SetRichToolTipMethodProvider(this.m_menuRClickEchelle, null);
            this.m_menuRClickEchelle.Size = new System.Drawing.Size(190, 170);
            // 
            // m_menuZoomOn
            // 
            this.m_menuZoomOn.Name = "m_menuZoomOn";
            this.m_menuZoomOn.Size = new System.Drawing.Size(189, 22);
            this.m_menuZoomOn.Text = "Zoom on";
            this.m_menuZoomOn.Click += new System.EventHandler(this.m_menuZoomOn_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(186, 6);
            // 
            // m_menu2Jours
            // 
            this.m_menu2Jours.Name = "m_menu2Jours";
            this.m_menu2Jours.Size = new System.Drawing.Size(189, 22);
            this.m_menu2Jours.Text = "2 days|118";
            this.m_menu2Jours.Click += new System.EventHandler(this.m_menu2Jours_Click);
            // 
            // m_menu3Jours
            // 
            this.m_menu3Jours.Name = "m_menu3Jours";
            this.m_menu3Jours.Size = new System.Drawing.Size(189, 22);
            this.m_menu3Jours.Text = "3 days|119";
            this.m_menu3Jours.Click += new System.EventHandler(this.m_menu3Jours_Click);
            // 
            // m_menu5jours
            // 
            this.m_menu5jours.Name = "m_menu5jours";
            this.m_menu5jours.Size = new System.Drawing.Size(189, 22);
            this.m_menu5jours.Text = "5 days|120";
            this.m_menu5jours.Click += new System.EventHandler(this.m_menu5jours_Click);
            // 
            // m_menuSemaine
            // 
            this.m_menuSemaine.Name = "m_menuSemaine";
            this.m_menuSemaine.Size = new System.Drawing.Size(189, 22);
            this.m_menuSemaine.Text = "Week|121";
            this.m_menuSemaine.Click += new System.EventHandler(this.m_menuSemaine_Click);
            // 
            // m_menu2Semaines
            // 
            this.m_menu2Semaines.Name = "m_menu2Semaines";
            this.m_menu2Semaines.Size = new System.Drawing.Size(189, 22);
            this.m_menu2Semaines.Text = "2 weeks|122";
            this.m_menu2Semaines.Click += new System.EventHandler(this.m_menu2Semaines_Click);
            // 
            // m_gestionnaireModeEdition
            // 
            this.m_gestionnaireModeEdition.ModeEdition = true;
            // 
            // m_timerSendEventChangeDate
            // 
            this.m_timerSendEventChangeDate.Interval = 1000;
            this.m_timerSendEventChangeDate.Tick += new System.EventHandler(this.m_timerSendEventChangeDate_Tick);
            // 
            // m_menuEditerElementDeLigne
            // 
            this.m_menuEditerElementDeLigne.Name = "m_menuEditerElementDeLigne";
            this.m_menuEditerElementDeLigne.Size = new System.Drawing.Size(169, 22);
            this.m_menuEditerElementDeLigne.Text = "Detail|20023";
            this.m_menuEditerElementDeLigne.Click += new System.EventHandler(this.m_menuEditerElementDeLigne_Click);
            // 
            // m_tooltipDessin
            // 
            this.m_tooltipDessin.Enable = true;
            this.m_tooltipDessin.TooltipContext = "PLANNING";
            // 
            // m_tooltipLignes
            // 
            this.m_tooltipLignes.Enable = true;
            this.m_tooltipLignes.TooltipContext = "PLANNING_LIGNES";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(186, 6);
            // 
            // m_menuARemplacerParDatesEchelle
            // 
            this.m_menuARemplacerParDatesEchelle.Name = "m_menuARemplacerParDatesEchelle";
            this.m_menuARemplacerParDatesEchelle.Size = new System.Drawing.Size(189, 22);
            this.m_menuARemplacerParDatesEchelle.Text = "Replace by ScaleDate";
            // 
            // CControlePlanning
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_panelDessinCalendrier);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControlePlanning";
            this.m_tooltipDessin.SetRichToolTipGetAtMethod(this, "");
            this.m_tooltipLignes.SetRichToolTipGetAtMethod(this, "");
            this.m_tooltipLignes.SetRichToolTipMethodProvider(this, null);
            this.m_tooltipDessin.SetRichToolTipMethodProvider(this, null);
            this.Size = new System.Drawing.Size(594, 150);
            this.SizeChanged += new System.EventHandler(this.CControlePlanning_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.m_panelEchelle)).EndInit();
            this.m_panelDessinCalendrier.ResumeLayout(false);
            this.m_panelDessinCalendrier.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_panelDessin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageRessourceOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_panelLignes)).EndInit();
            this.m_menuRClickCalendrier.ResumeLayout(false);
            this.m_menuRClickLigne.ResumeLayout(false);
            this.m_menuRClickEchelle.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox m_panelEchelle;
		private System.Windows.Forms.Panel m_panelDessinCalendrier;
		private System.Windows.Forms.Timer m_timerShowSelection;
        private System.Windows.Forms.PictureBox m_panelDessin;
        private System.Windows.Forms.Timer m_timerRefreshDessin;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.PictureBox m_panelLignes;
		private System.Windows.Forms.ToolTip m_tooltip;
		private System.Windows.Forms.ContextMenuStrip m_menuRClickCalendrier;
		private System.Windows.Forms.ContextMenuStrip m_menuRClickLigne;
		private System.Windows.Forms.ToolStripMenuItem m_menuMasquerLigne;
		private System.Windows.Forms.ContextMenuStrip m_menuRClickEchelle;
		private System.Windows.Forms.ToolStripMenuItem m_menuZoomOn;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem m_menu2Jours;
		private System.Windows.Forms.ToolStripMenuItem m_menu3Jours;
		private System.Windows.Forms.ToolStripMenuItem m_menu5jours;
		private System.Windows.Forms.ToolStripMenuItem m_menuSemaine;
        private System.Windows.Forms.ToolStripMenuItem m_menu2Semaines;
		private System.Windows.Forms.PictureBox m_imageRessourceOk;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem m_menuPopupInfo;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private timos.win32.composants.ModeleTexteToolTip m_tooltipDessin;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem m_menuPopupInfoLigne;
		private System.Windows.Forms.ToolStripMenuItem m_menuElementAIntervention;
		private System.Windows.Forms.ToolStripMenuItem m_menuDiviserIntervention;
		private ModeleTexteToolTip m_tooltipLignes;
		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private System.Windows.Forms.Timer m_timerSendEventChangeDate;
		private System.Windows.Forms.ToolStripMenuItem m_menuEditerIntervention;
		private System.Windows.Forms.ToolStripMenuItem checkListToolStripMenuItem;
        private System.Windows.Forms.VScrollBar m_scroll;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem m_menuGestionSites;
        private System.Windows.Forms.ToolStripMenuItem m_menuGestionActeurs;
        private System.Windows.Forms.ToolStripMenuItem m_menuGestionResources;
        private System.Windows.Forms.ToolStripMenuItem m_menuARemplacerParDatesInter;
        private System.Windows.Forms.ToolStripMenuItem m_menuEditerElementDeLigne;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem m_menuARemplacerParDatesEchelle;

	}
}
