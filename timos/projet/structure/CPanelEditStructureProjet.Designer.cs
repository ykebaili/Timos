namespace timos
{
	partial class CPanelEditStructureProjet
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
            sc2i.win32.common.CGrilleEditeurObjetGraphique cGrilleEditeurObjetGraphique2 = new sc2i.win32.common.CGrilleEditeurObjetGraphique();
            sc2i.win32.common.CProfilEditeurObjetGraphique cProfilEditeurObjetGraphique2 = new sc2i.win32.common.CProfilEditeurObjetGraphique();
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_panMode = new System.Windows.Forms.Panel();
            this.m_rbtSelectionMode = new System.Windows.Forms.RadioButton();
            this.m_rbtCreationMode = new System.Windows.Forms.RadioButton();
            this.m_panCmds = new System.Windows.Forms.Panel();
            this.m_chkInter = new System.Windows.Forms.RadioButton();
            this.m_chkProjet = new System.Windows.Forms.RadioButton();
            this.m_chkCurseur = new System.Windows.Forms.RadioButton();
            this.m_chkLien = new System.Windows.Forms.RadioButton();
            this.m_lvContenu = new System.Windows.Forms.ListView();
            this.m_colContenuLibelle = new System.Windows.Forms.ColumnHeader();
            this.m_colContenuType = new System.Windows.Forms.ColumnHeader();
            this.m_cmbFiltreContenu = new System.Windows.Forms.ComboBox();
            this.m_spcGauche = new System.Windows.Forms.SplitContainer();
            this.m_tbpCtrl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_tbpTools = new Crownwood.Magic.Controls.TabPage();
            this.m_tbpElements = new Crownwood.Magic.Controls.TabPage();
            this.m_tbpOptions = new Crownwood.Magic.Controls.TabPage();
            this.m_chkIcoEtat = new System.Windows.Forms.CheckBox();
            this.m_chkIcoAnomalies = new System.Windows.Forms.CheckBox();
            this.m_chkMiniatures = new System.Windows.Forms.CheckBox();
            this.m_spcDroite = new System.Windows.Forms.SplitContainer();
            this.m_controlEdition = new timos.CControlEditionProjet();
            this.m_panEditionRapide = new timos.CPanIEditeurWndElementDeProjet();
            this.m_toolTip = new sc2i.win32.common.CToolTipTraductible(this.components);
            this.m_panMode.SuspendLayout();
            this.m_panCmds.SuspendLayout();
            this.m_spcGauche.Panel1.SuspendLayout();
            this.m_spcGauche.Panel2.SuspendLayout();
            this.m_spcGauche.SuspendLayout();
            this.m_tbpCtrl.SuspendLayout();
            this.m_tbpTools.SuspendLayout();
            this.m_tbpElements.SuspendLayout();
            this.m_tbpOptions.SuspendLayout();
            this.m_spcDroite.Panel1.SuspendLayout();
            this.m_spcDroite.Panel2.SuspendLayout();
            this.m_spcDroite.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panMode
            // 
            this.m_panMode.Controls.Add(this.m_rbtSelectionMode);
            this.m_panMode.Controls.Add(this.m_rbtCreationMode);
            this.m_panMode.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_panMode.Location = new System.Drawing.Point(0, 335);
            this.m_extModeEdition.SetModeEdition(this.m_panMode, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panMode.Name = "m_panMode";
            this.m_panMode.Size = new System.Drawing.Size(203, 58);
            this.m_panMode.TabIndex = 11;
            // 
            // m_rbtSelectionMode
            // 
            this.m_rbtSelectionMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_rbtSelectionMode.Location = new System.Drawing.Point(3, 19);
            this.m_extModeEdition.SetModeEdition(this.m_rbtSelectionMode, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_rbtSelectionMode.Name = "m_rbtSelectionMode";
            this.m_rbtSelectionMode.Size = new System.Drawing.Size(197, 23);
            this.m_rbtSelectionMode.TabIndex = 10;
            this.m_rbtSelectionMode.Text = "Select from existing elements|1239";
            this.m_rbtSelectionMode.UseVisualStyleBackColor = true;
            this.m_rbtSelectionMode.CheckedChanged += new System.EventHandler(this.m_rbtCreationMode_CheckedChanged);
            // 
            // m_rbtCreationMode
            // 
            this.m_rbtCreationMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_rbtCreationMode.Checked = true;
            this.m_rbtCreationMode.Location = new System.Drawing.Point(3, 3);
            this.m_extModeEdition.SetModeEdition(this.m_rbtCreationMode, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_rbtCreationMode.Name = "m_rbtCreationMode";
            this.m_rbtCreationMode.Size = new System.Drawing.Size(197, 19);
            this.m_rbtCreationMode.TabIndex = 10;
            this.m_rbtCreationMode.TabStop = true;
            this.m_rbtCreationMode.Text = "Create new elements|1238";
            this.m_rbtCreationMode.UseVisualStyleBackColor = true;
            this.m_rbtCreationMode.CheckedChanged += new System.EventHandler(this.m_rbtCreationMode_CheckedChanged);
            // 
            // m_panCmds
            // 
            this.m_panCmds.Controls.Add(this.m_chkInter);
            this.m_panCmds.Controls.Add(this.m_chkProjet);
            this.m_panCmds.Controls.Add(this.m_chkCurseur);
            this.m_panCmds.Controls.Add(this.m_chkLien);
            this.m_panCmds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panCmds.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panCmds, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panCmds.Name = "m_panCmds";
            this.m_panCmds.Size = new System.Drawing.Size(203, 335);
            this.m_panCmds.TabIndex = 11;
            // 
            // m_chkInter
            // 
            this.m_chkInter.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_chkInter.BackgroundImage = global::timos.Properties.Resources.intervention;
            this.m_chkInter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_chkInter.Location = new System.Drawing.Point(71, 63);
            this.m_extModeEdition.SetModeEdition(this.m_chkInter, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkInter.Name = "m_chkInter";
            this.m_chkInter.Size = new System.Drawing.Size(62, 40);
            this.m_chkInter.TabIndex = 9;
            this.m_chkInter.Text = "I";
            this.m_toolTip.SetToolTip(this.m_chkInter, "Intervention");
            this.m_chkInter.CheckedChanged += new System.EventHandler(this.m_chkInter_CheckedChanged);
            // 
            // m_chkProjet
            // 
            this.m_chkProjet.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_chkProjet.BackgroundImage = global::timos.Properties.Resources.projet;
            this.m_chkProjet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_chkProjet.Location = new System.Drawing.Point(5, 63);
            this.m_extModeEdition.SetModeEdition(this.m_chkProjet, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkProjet.Name = "m_chkProjet";
            this.m_chkProjet.Size = new System.Drawing.Size(60, 40);
            this.m_chkProjet.TabIndex = 9;
            this.m_chkProjet.Text = "P";
            this.m_toolTip.SetToolTip(this.m_chkProjet, "Projet");
            this.m_chkProjet.CheckedChanged += new System.EventHandler(this.m_chkProjet_CheckedChanged);
            // 
            // m_chkCurseur
            // 
            this.m_chkCurseur.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_chkCurseur.BackgroundImage = global::timos.Properties.Resources.selection;
            this.m_chkCurseur.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_chkCurseur.Checked = true;
            this.m_chkCurseur.Location = new System.Drawing.Point(3, 0);
            this.m_extModeEdition.SetModeEdition(this.m_chkCurseur, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkCurseur.Name = "m_chkCurseur";
            this.m_chkCurseur.Size = new System.Drawing.Size(53, 43);
            this.m_chkCurseur.TabIndex = 6;
            this.m_chkCurseur.TabStop = true;
            this.m_toolTip.SetToolTip(this.m_chkCurseur, "Selection");
            this.m_chkCurseur.CheckedChanged += new System.EventHandler(this.m_chkCurseur_CheckedChanged);
            // 
            // m_chkLien
            // 
            this.m_chkLien.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_chkLien.BackgroundImage = global::timos.Properties.Resources.lien;
            this.m_chkLien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_chkLien.Location = new System.Drawing.Point(5, 124);
            this.m_extModeEdition.SetModeEdition(this.m_chkLien, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkLien.Name = "m_chkLien";
            this.m_chkLien.Size = new System.Drawing.Size(51, 40);
            this.m_chkLien.TabIndex = 8;
            this.m_chkLien.Text = "L";
            this.m_toolTip.SetToolTip(this.m_chkLien, "Relation");
            this.m_chkLien.CheckedChanged += new System.EventHandler(this.m_chkLien_CheckedChanged);
            // 
            // m_lvContenu
            // 
            this.m_lvContenu.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_colContenuLibelle,
            this.m_colContenuType});
            this.m_lvContenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lvContenu.FullRowSelect = true;
            this.m_lvContenu.GridLines = true;
            this.m_lvContenu.Location = new System.Drawing.Point(0, 21);
            this.m_extModeEdition.SetModeEdition(this.m_lvContenu, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lvContenu.Name = "m_lvContenu";
            this.m_lvContenu.Size = new System.Drawing.Size(203, 372);
            this.m_lvContenu.TabIndex = 6;
            this.m_lvContenu.UseCompatibleStateImageBehavior = false;
            this.m_lvContenu.View = System.Windows.Forms.View.Details;
            this.m_lvContenu.SelectedIndexChanged += new System.EventHandler(this.m_lvContenu_SelectedIndexChanged);
            // 
            // m_colContenuLibelle
            // 
            this.m_colContenuLibelle.Text = "Label|50";
            this.m_colContenuLibelle.Width = 120;
            // 
            // m_colContenuType
            // 
            this.m_colContenuType.Text = "Type|54";
            this.m_colContenuType.Width = 80;
            // 
            // m_cmbFiltreContenu
            // 
            this.m_cmbFiltreContenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_cmbFiltreContenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbFiltreContenu.FormattingEnabled = true;
            this.m_cmbFiltreContenu.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_cmbFiltreContenu, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_cmbFiltreContenu.Name = "m_cmbFiltreContenu";
            this.m_cmbFiltreContenu.Size = new System.Drawing.Size(203, 21);
            this.m_cmbFiltreContenu.TabIndex = 7;
            this.m_cmbFiltreContenu.SelectedIndexChanged += new System.EventHandler(this.m_cmbFiltreContenu_SelectedIndexChanged);
            // 
            // m_spcGauche
            // 
            this.m_spcGauche.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_spcGauche.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_spcGauche, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_spcGauche.Name = "m_spcGauche";
            // 
            // m_spcGauche.Panel1
            // 
            this.m_spcGauche.Panel1.Controls.Add(this.m_tbpCtrl);
            this.m_extModeEdition.SetModeEdition(this.m_spcGauche.Panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            // 
            // m_spcGauche.Panel2
            // 
            this.m_spcGauche.Panel2.Controls.Add(this.m_spcDroite);
            this.m_extModeEdition.SetModeEdition(this.m_spcGauche.Panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_spcGauche.Size = new System.Drawing.Size(668, 418);
            this.m_spcGauche.SplitterDistance = 203;
            this.m_spcGauche.TabIndex = 8;
            // 
            // m_tbpCtrl
            // 
            this.m_tbpCtrl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_tbpCtrl.BoldSelectedPage = true;
            this.m_tbpCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tbpCtrl.IDEPixelArea = false;
            this.m_tbpCtrl.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_tbpCtrl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_tbpCtrl.Name = "m_tbpCtrl";
            this.m_tbpCtrl.Ombre = false;
            this.m_tbpCtrl.PositionTop = true;
            this.m_tbpCtrl.SelectedIndex = 0;
            this.m_tbpCtrl.SelectedTab = this.m_tbpTools;
            this.m_tbpCtrl.Size = new System.Drawing.Size(203, 418);
            this.m_tbpCtrl.TabIndex = 10;
            this.m_tbpCtrl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_tbpTools,
            this.m_tbpElements,
            this.m_tbpOptions});
            // 
            // m_tbpTools
            // 
            this.m_tbpTools.Controls.Add(this.m_panCmds);
            this.m_tbpTools.Controls.Add(this.m_panMode);
            this.m_tbpTools.Location = new System.Drawing.Point(0, 25);
            this.m_extModeEdition.SetModeEdition(this.m_tbpTools, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_tbpTools.Name = "m_tbpTools";
            this.m_tbpTools.Size = new System.Drawing.Size(203, 393);
            this.m_tbpTools.TabIndex = 10;
            this.m_tbpTools.Title = "Tools|1273";
            // 
            // m_tbpElements
            // 
            this.m_tbpElements.Controls.Add(this.m_lvContenu);
            this.m_tbpElements.Controls.Add(this.m_cmbFiltreContenu);
            this.m_tbpElements.Location = new System.Drawing.Point(0, 25);
            this.m_extModeEdition.SetModeEdition(this.m_tbpElements, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_tbpElements.Name = "m_tbpElements";
            this.m_tbpElements.Selected = false;
            this.m_tbpElements.Size = new System.Drawing.Size(203, 393);
            this.m_tbpElements.TabIndex = 11;
            this.m_tbpElements.Title = "Elements|923";
            // 
            // m_tbpOptions
            // 
            this.m_tbpOptions.Controls.Add(this.m_chkIcoEtat);
            this.m_tbpOptions.Controls.Add(this.m_chkIcoAnomalies);
            this.m_tbpOptions.Controls.Add(this.m_chkMiniatures);
            this.m_tbpOptions.Location = new System.Drawing.Point(0, 25);
            this.m_extModeEdition.SetModeEdition(this.m_tbpOptions, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_tbpOptions.Name = "m_tbpOptions";
            this.m_tbpOptions.Selected = false;
            this.m_tbpOptions.Size = new System.Drawing.Size(203, 393);
            this.m_tbpOptions.TabIndex = 12;
            this.m_tbpOptions.Title = "Options|56";
            // 
            // m_chkIcoEtat
            // 
            this.m_chkIcoEtat.AutoSize = true;
            this.m_chkIcoEtat.Location = new System.Drawing.Point(6, 50);
            this.m_extModeEdition.SetModeEdition(this.m_chkIcoEtat, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_chkIcoEtat.Name = "m_chkIcoEtat";
            this.m_chkIcoEtat.Size = new System.Drawing.Size(140, 17);
            this.m_chkIcoEtat.TabIndex = 14;
            this.m_chkIcoEtat.Text = "Show states icons|1276";
            this.m_chkIcoEtat.UseVisualStyleBackColor = true;
            this.m_chkIcoEtat.CheckedChanged += new System.EventHandler(this.m_chkIcoEtat_CheckedChanged);
            // 
            // m_chkIcoAnomalies
            // 
            this.m_chkIcoAnomalies.AutoSize = true;
            this.m_chkIcoAnomalies.Location = new System.Drawing.Point(6, 29);
            this.m_extModeEdition.SetModeEdition(this.m_chkIcoAnomalies, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_chkIcoAnomalies.Name = "m_chkIcoAnomalies";
            this.m_chkIcoAnomalies.Size = new System.Drawing.Size(158, 17);
            this.m_chkIcoAnomalies.TabIndex = 13;
            this.m_chkIcoAnomalies.Text = "Show Anomalies icons|1275";
            this.m_chkIcoAnomalies.UseVisualStyleBackColor = true;
            this.m_chkIcoAnomalies.CheckedChanged += new System.EventHandler(this.m_chkIcoAnomalies_CheckedChanged);
            // 
            // m_chkMiniatures
            // 
            this.m_chkMiniatures.AutoSize = true;
            this.m_chkMiniatures.Location = new System.Drawing.Point(6, 6);
            this.m_extModeEdition.SetModeEdition(this.m_chkMiniatures, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_chkMiniatures.Name = "m_chkMiniatures";
            this.m_chkMiniatures.Size = new System.Drawing.Size(160, 17);
            this.m_chkMiniatures.TabIndex = 12;
            this.m_chkMiniatures.Text = "Show projects thumbs|1274";
            this.m_chkMiniatures.UseVisualStyleBackColor = true;
            // 
            // m_spcDroite
            // 
            this.m_spcDroite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_spcDroite.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_spcDroite, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_spcDroite.Name = "m_spcDroite";
            // 
            // m_spcDroite.Panel1
            // 
            this.m_spcDroite.Panel1.Controls.Add(this.m_controlEdition);
            this.m_extModeEdition.SetModeEdition(this.m_spcDroite.Panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            // 
            // m_spcDroite.Panel2
            // 
            this.m_spcDroite.Panel2.Controls.Add(this.m_panEditionRapide);
            this.m_extModeEdition.SetModeEdition(this.m_spcDroite.Panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_spcDroite.Size = new System.Drawing.Size(461, 418);
            this.m_spcDroite.SplitterDistance = 294;
            this.m_spcDroite.TabIndex = 0;
            // 
            // m_controlEdition
            // 
            this.m_controlEdition.AllowDrop = true;
            this.m_controlEdition.AutoScroll = true;
            this.m_controlEdition.BackColor = System.Drawing.Color.White;
            this.m_controlEdition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_controlEdition.Echelle = 1F;
            this.m_controlEdition.EffetAjoutSuppression = false;
            this.m_controlEdition.EffetFonduMenu = true;
            this.m_controlEdition.EnDeplacement = false;
            this.m_controlEdition.FormesDesPoignees = sc2i.win32.common.EFormePoignee.Carre;
            cGrilleEditeurObjetGraphique2.Couleur = System.Drawing.Color.LightGray;
            cGrilleEditeurObjetGraphique2.HauteurCarreau = 20;
            cGrilleEditeurObjetGraphique2.LargeurCarreau = 20;
            cGrilleEditeurObjetGraphique2.Representation = sc2i.win32.common.ERepresentationGrille.LignesContinues;
            cGrilleEditeurObjetGraphique2.TailleCarreau = new System.Drawing.Size(20, 20);
            this.m_controlEdition.GrilleAlignement = cGrilleEditeurObjetGraphique2;
            this.m_controlEdition.HauteurMinimaleDesObjets = 10;
            this.m_controlEdition.HistorisationActive = false;
            this.m_controlEdition.LargeurMinimaleDesObjets = 10;
            this.m_controlEdition.Location = new System.Drawing.Point(0, 0);
            this.m_controlEdition.LockEdition = false;
            this.m_controlEdition.Marge = 10;
            this.m_controlEdition.ModeAffichageGrille = sc2i.win32.common.EModeAffichageGrille.AuDeplacement;
            this.m_controlEdition.ModeCreation = true;
            this.m_controlEdition.ModeEdition = timos.EModeEditeurProjet.Selection;
            this.m_extModeEdition.SetModeEdition(this.m_controlEdition, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_controlEdition.ModeRepresentationGrille = sc2i.win32.common.ERepresentationGrille.LignesContinues;
            this.m_controlEdition.Name = "m_controlEdition";
            this.m_controlEdition.NombreHistorisation = 10;
            this.m_controlEdition.ObjetEdite = null;
            cProfilEditeurObjetGraphique2.FormeDesPoignees = sc2i.win32.common.EFormePoignee.Carre;
            cProfilEditeurObjetGraphique2.Grille = cGrilleEditeurObjetGraphique2;
            cProfilEditeurObjetGraphique2.HistorisationActive = false;
            cProfilEditeurObjetGraphique2.Marge = 10;
            cProfilEditeurObjetGraphique2.ModeAffichageGrille = sc2i.win32.common.EModeAffichageGrille.AuDeplacement;
            cProfilEditeurObjetGraphique2.NombreHistorisation = 10;
            cProfilEditeurObjetGraphique2.ToujoursAlignerSurLaGrille = false;
            this.m_controlEdition.Profil = cProfilEditeurObjetGraphique2;
            this.m_controlEdition.RefreshSelectionChanged = true;
            this.m_controlEdition.Size = new System.Drawing.Size(294, 418);
            this.m_controlEdition.TabIndex = 0;
            this.m_controlEdition.ToujoursAlignerSelonLesControles = true;
            this.m_controlEdition.ToujoursAlignerSurLaGrille = false;
            this.m_controlEdition.WndProjetEdite = null;
            this.m_controlEdition.AfterSelectElement += new timos.EventHandlerForIElementDeProjet(this.m_controlEdition_AfterClicElementInSelection);
            this.m_controlEdition.BeforeSelectElement += new timos.EventHandlerAnnulable(this.BeforeAction);
            this.m_controlEdition.BeforeAddElement += new timos.EventHandlerAnnulable(this.BeforeAction);
            this.m_controlEdition.AfterModeEditionChanged += new System.EventHandler(this.m_controlEdition_AfterModeEditionChanged);
            this.m_controlEdition.BeforeUnselectElement += new timos.EventHandlerAnnulable(this.BeforeAction);
            this.m_controlEdition.AfterDoubleClicElement += new timos.EventHandlerForIElementDeProjet(this.m_controlEdition_AfterDoubleClicElement);
            this.m_controlEdition.BeforeDeleteElement += new sc2i.win32.common.EventHandlerPanelEditionGraphiqueSuppression(this.m_controlEdition_BeforeDeleteElement);
            this.m_controlEdition.AfterRemoveObjetGraphique += new System.EventHandler(this.m_controlEdition_AfterRemoveObjetGraphique);
            this.m_controlEdition.AfterAddElement += new timos.EventHandlerForIElementDeProjet(this.m_controlEdition_AfterAddElement);
            // 
            // m_panEditionRapide
            // 
            this.m_panEditionRapide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panEditionRapide.Location = new System.Drawing.Point(0, 0);
            this.m_panEditionRapide.LockEdition = true;
            this.m_extModeEdition.SetModeEdition(this.m_panEditionRapide, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panEditionRapide.Name = "m_panEditionRapide";
            this.m_panEditionRapide.Size = new System.Drawing.Size(163, 418);
            this.m_panEditionRapide.TabIndex = 0;
            this.m_panEditionRapide.ProprieteModifiee += new System.EventHandler(this.m_panEditionRapide_ProprieteModifiee);
            this.m_panEditionRapide.OnClickProprietes += new System.EventHandler(this.m_panEditionRapide_OnClickProprietes);
            // 
            // CPanelEditStructureProjet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_spcGauche);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CPanelEditStructureProjet";
            this.Size = new System.Drawing.Size(668, 418);
            this.Load += new System.EventHandler(this.CPanelEditProjet_Load);
            this.m_panMode.ResumeLayout(false);
            this.m_panCmds.ResumeLayout(false);
            this.m_spcGauche.Panel1.ResumeLayout(false);
            this.m_spcGauche.Panel2.ResumeLayout(false);
            this.m_spcGauche.ResumeLayout(false);
            this.m_tbpCtrl.ResumeLayout(false);
            this.m_tbpCtrl.PerformLayout();
            this.m_tbpTools.ResumeLayout(false);
            this.m_tbpElements.ResumeLayout(false);
            this.m_tbpOptions.ResumeLayout(false);
            this.m_tbpOptions.PerformLayout();
            this.m_spcDroite.Panel1.ResumeLayout(false);
            this.m_spcDroite.Panel2.ResumeLayout(false);
            this.m_spcDroite.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private CControlEditionProjet m_controlEdition;
		private sc2i.win32.common.CExtModeEdition m_extModeEdition;
		private System.Windows.Forms.RadioButton m_chkCurseur;
		private System.Windows.Forms.RadioButton m_chkLien;
		private System.Windows.Forms.RadioButton m_chkProjet;
		private System.Windows.Forms.RadioButton m_chkInter;
		private System.Windows.Forms.ListView m_lvContenu;
		private System.Windows.Forms.ComboBox m_cmbFiltreContenu;
		private System.Windows.Forms.SplitContainer m_spcGauche;
		private System.Windows.Forms.SplitContainer m_spcDroite;
		private System.Windows.Forms.ColumnHeader m_colContenuLibelle;
		private System.Windows.Forms.ColumnHeader m_colContenuType;
		private System.Windows.Forms.RadioButton m_rbtSelectionMode;
		private System.Windows.Forms.RadioButton m_rbtCreationMode;
		private CPanIEditeurWndElementDeProjet m_panEditionRapide;
		private System.Windows.Forms.Panel m_panMode;
		private System.Windows.Forms.Panel m_panCmds;
		private sc2i.win32.common.CToolTipTraductible m_toolTip;
		private System.Windows.Forms.CheckBox m_chkIcoEtat;
		private System.Windows.Forms.CheckBox m_chkIcoAnomalies;
		private System.Windows.Forms.CheckBox m_chkMiniatures;
		private sc2i.win32.common.C2iTabControl m_tbpCtrl;
		private Crownwood.Magic.Controls.TabPage m_tbpTools;
		private Crownwood.Magic.Controls.TabPage m_tbpElements;
		private Crownwood.Magic.Controls.TabPage m_tbpOptions;
	}
}
