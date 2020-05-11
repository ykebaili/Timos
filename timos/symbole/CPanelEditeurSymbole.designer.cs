namespace timos
{
    partial class CPanelEditeurSymbole
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPanelEditeurSymbole));
            sc2i.win32.common.CGrilleEditeurObjetGraphique cGrilleEditeurObjetGraphique1 = new sc2i.win32.common.CGrilleEditeurObjetGraphique();
            sc2i.win32.common.CProfilEditeurObjetGraphique cProfilEditeurObjetGraphique1 = new sc2i.win32.common.CProfilEditeurObjetGraphique();
            this.m_propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.m_btnOpen = new System.Windows.Forms.Button();
            this.m_btnSave = new System.Windows.Forms.Button();
            this.m_listeControles = new timos.CPanelListe2iSymbole();
            this.m_panelEditionSymbole = new timos.CPanelEditionSymbole();
            this.m_panelToolBar = new System.Windows.Forms.Panel();
            this.m_btnModeEditLine = new System.Windows.Forms.RadioButton();
            this.m_btnModeZoom = new System.Windows.Forms.RadioButton();
            this.m_btnModeSelection = new System.Windows.Forms.RadioButton();
            this.m_tooltipTraductible = new sc2i.win32.common.CToolTipTraductible(this.components);
            this.m_panelToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_propertyGrid
            // 
            this.m_propertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_propertyGrid.Location = new System.Drawing.Point(586, 3);
            this.m_propertyGrid.Name = "m_propertyGrid";
            this.m_propertyGrid.Size = new System.Drawing.Size(188, 436);
            this.m_propertyGrid.TabIndex = 2;
            this.m_propertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.m_propertyGrid_PropertyValueChanged);
            // 
            // m_btnOpen
            // 
            this.m_btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("m_btnOpen.Image")));
            this.m_btnOpen.Location = new System.Drawing.Point(127, 412);
            this.m_btnOpen.Name = "m_btnOpen";
            this.m_btnOpen.Size = new System.Drawing.Size(24, 23);
            this.m_btnOpen.TabIndex = 32;
            this.m_btnOpen.Click += new System.EventHandler(this.m_btnOpen_Click);
            // 
            // m_btnSave
            // 
            this.m_btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnSave.Image = ((System.Drawing.Image)(resources.GetObject("m_btnSave.Image")));
            this.m_btnSave.Location = new System.Drawing.Point(157, 412);
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Size = new System.Drawing.Size(24, 23);
            this.m_btnSave.TabIndex = 31;
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // m_listeControles
            // 
            this.m_listeControles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_listeControles.AutoScroll = true;
            this.m_listeControles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_listeControles.Location = new System.Drawing.Point(0, 0);
            this.m_listeControles.Name = "m_listeControles";
            this.m_listeControles.Size = new System.Drawing.Size(181, 406);
            this.m_listeControles.TabIndex = 1;
            // 
            // m_panelEditionSymbole
            // 
            this.m_panelEditionSymbole.AllowDrop = true;
            this.m_panelEditionSymbole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelEditionSymbole.BackColor = System.Drawing.Color.White;
            this.m_panelEditionSymbole.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.m_panelEditionSymbole.Echelle = 1F;
            this.m_panelEditionSymbole.Editeur = null;
            this.m_panelEditionSymbole.EffetAjoutSuppression = false;
            this.m_panelEditionSymbole.EffetFonduMenu = true;
            this.m_panelEditionSymbole.EnDeplacement = false;
            this.m_panelEditionSymbole.FormesDesPoignees = sc2i.win32.common.EFormePoignee.Carre;
            this.m_panelEditionSymbole.FournisseurPropriete = null;
            cGrilleEditeurObjetGraphique1.Couleur = System.Drawing.Color.LightGray;
            cGrilleEditeurObjetGraphique1.HauteurCarreau = 20;
            cGrilleEditeurObjetGraphique1.LargeurCarreau = 20;
            cGrilleEditeurObjetGraphique1.Representation = sc2i.win32.common.ERepresentationGrille.LignesContinues;
            cGrilleEditeurObjetGraphique1.TailleCarreau = new System.Drawing.Size(20, 20);
            this.m_panelEditionSymbole.GrilleAlignement = cGrilleEditeurObjetGraphique1;
            this.m_panelEditionSymbole.HauteurMinimaleDesObjets = 10;
            this.m_panelEditionSymbole.HistorisationActive = true;
            this.m_panelEditionSymbole.LargeurMinimaleDesObjets = 10;
            this.m_panelEditionSymbole.Location = new System.Drawing.Point(187, 30);
            this.m_panelEditionSymbole.LockEdition = false;
            this.m_panelEditionSymbole.Marge = 10;
            this.m_panelEditionSymbole.ModeAffichageGrille = sc2i.win32.common.EModeAffichageGrille.AuDeplacement;
            this.m_panelEditionSymbole.ModeEdition = timos.EModeEditeurSymbole.Selection;
            this.m_panelEditionSymbole.ModeRepresentationGrille = sc2i.win32.common.ERepresentationGrille.LignesContinues;
            this.m_panelEditionSymbole.ModeSouris = sc2i.win32.common.CPanelEditionObjetGraphique.EModeSouris.Selection;
            this.m_panelEditionSymbole.Name = "m_panelEditionSymbole";
            this.m_panelEditionSymbole.NoClipboard = false;
            this.m_panelEditionSymbole.NoDelete = false;
            this.m_panelEditionSymbole.NoDoubleClick = false;
            this.m_panelEditionSymbole.NombreHistorisation = 10;
            this.m_panelEditionSymbole.NoMenu = false;
            this.m_panelEditionSymbole.ObjetEdite = null;
            cProfilEditeurObjetGraphique1.FormeDesPoignees = sc2i.win32.common.EFormePoignee.Carre;
            cProfilEditeurObjetGraphique1.Grille = cGrilleEditeurObjetGraphique1;
            cProfilEditeurObjetGraphique1.HistorisationActive = true;
            cProfilEditeurObjetGraphique1.Marge = 10;
            cProfilEditeurObjetGraphique1.ModeAffichageGrille = sc2i.win32.common.EModeAffichageGrille.AuDeplacement;
            cProfilEditeurObjetGraphique1.NombreHistorisation = 10;
            cProfilEditeurObjetGraphique1.ToujoursAlignerSurLaGrille = false;
            this.m_panelEditionSymbole.Profil = cProfilEditeurObjetGraphique1;
            this.m_panelEditionSymbole.RefreshSelectionChanged = true;
            this.m_panelEditionSymbole.SelectionVisible = true;
            this.m_panelEditionSymbole.Size = new System.Drawing.Size(393, 405);
            this.m_panelEditionSymbole.TabIndex = 0;
            this.m_panelEditionSymbole.ToujoursAlignerSelonLesControles = true;
            this.m_panelEditionSymbole.ToujoursAlignerSurLaGrille = false;
            this.m_panelEditionSymbole.TypeEdite = null;
            this.m_panelEditionSymbole.OnChangeModeEdition += new System.EventHandler(this.m_panelEditionSymbole_OnChangeModeEdition);
            this.m_panelEditionSymbole.SelectionChanged += new System.EventHandler(this.m_panelEditionSymbole_SelectionChanged);
            // 
            // m_panelToolBar
            // 
            this.m_panelToolBar.Controls.Add(this.m_btnModeEditLine);
            this.m_panelToolBar.Controls.Add(this.m_btnModeZoom);
            this.m_panelToolBar.Controls.Add(this.m_btnModeSelection);
            this.m_panelToolBar.Location = new System.Drawing.Point(187, 0);
            this.m_panelToolBar.Name = "m_panelToolBar";
            this.m_panelToolBar.Size = new System.Drawing.Size(399, 30);
            this.m_panelToolBar.TabIndex = 33;
            // 
            // m_btnModeEditLine
            // 
            this.m_btnModeEditLine.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_btnModeEditLine.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnModeEditLine.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_btnModeEditLine.Image = ((System.Drawing.Image)(resources.GetObject("m_btnModeEditLine.Image")));
            this.m_btnModeEditLine.Location = new System.Drawing.Point(56, 0);
            this.m_btnModeEditLine.Name = "m_btnModeEditLine";
            this.m_btnModeEditLine.Size = new System.Drawing.Size(28, 30);
            this.m_btnModeEditLine.TabIndex = 2;
            this.m_tooltipTraductible.SetToolTip(this.m_btnModeEditLine, "Edit selected line|30396");
            this.m_btnModeEditLine.UseVisualStyleBackColor = true;
            this.m_btnModeEditLine.Visible = false;
            this.m_btnModeEditLine.CheckedChanged += new System.EventHandler(this.m_btnModeEditLine_CheckedChanged);
            // 
            // m_btnModeZoom
            // 
            this.m_btnModeZoom.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_btnModeZoom.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnModeZoom.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_btnModeZoom.Image = ((System.Drawing.Image)(resources.GetObject("m_btnModeZoom.Image")));
            this.m_btnModeZoom.Location = new System.Drawing.Point(28, 0);
            this.m_btnModeZoom.Name = "m_btnModeZoom";
            this.m_btnModeZoom.Size = new System.Drawing.Size(28, 30);
            this.m_btnModeZoom.TabIndex = 1;
            this.m_tooltipTraductible.SetToolTip(this.m_btnModeZoom, "Zoom|30393");
            this.m_btnModeZoom.UseVisualStyleBackColor = true;
            this.m_btnModeZoom.CheckedChanged += new System.EventHandler(this.m_btnModeZoom_CheckedChanged);
            // 
            // m_btnModeSelection
            // 
            this.m_btnModeSelection.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_btnModeSelection.Checked = true;
            this.m_btnModeSelection.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnModeSelection.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_btnModeSelection.Image = ((System.Drawing.Image)(resources.GetObject("m_btnModeSelection.Image")));
            this.m_btnModeSelection.Location = new System.Drawing.Point(0, 0);
            this.m_btnModeSelection.Name = "m_btnModeSelection";
            this.m_btnModeSelection.Size = new System.Drawing.Size(28, 30);
            this.m_btnModeSelection.TabIndex = 0;
            this.m_btnModeSelection.TabStop = true;
            this.m_tooltipTraductible.SetToolTip(this.m_btnModeSelection, "Select|30392");
            this.m_btnModeSelection.UseVisualStyleBackColor = true;
            this.m_btnModeSelection.CheckedChanged += new System.EventHandler(this.m_btnModeSelection_CheckedChanged);
            // 
            // CPanelEditeurSymbole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_panelToolBar);
            this.Controls.Add(this.m_btnOpen);
            this.Controls.Add(this.m_btnSave);
            this.Controls.Add(this.m_propertyGrid);
            this.Controls.Add(this.m_listeControles);
            this.Controls.Add(this.m_panelEditionSymbole);
            this.Name = "CPanelEditeurSymbole";
            this.Size = new System.Drawing.Size(777, 442);
            this.m_panelToolBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CPanelEditionSymbole m_panelEditionSymbole;
        private CPanelListe2iSymbole m_listeControles;
        private System.Windows.Forms.PropertyGrid m_propertyGrid;
        private System.Windows.Forms.Button m_btnOpen;
        private System.Windows.Forms.Button m_btnSave;
        private System.Windows.Forms.Panel m_panelToolBar;
        private System.Windows.Forms.RadioButton m_btnModeEditLine;
        private System.Windows.Forms.RadioButton m_btnModeZoom;
        private System.Windows.Forms.RadioButton m_btnModeSelection;
        private sc2i.win32.common.CToolTipTraductible m_tooltipTraductible;
   
    }
}
