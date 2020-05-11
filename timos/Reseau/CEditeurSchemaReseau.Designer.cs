namespace timos.Reseau
{
    partial class CEditeurSchemaReseau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CEditeurSchemaReseau));
            sc2i.win32.common.CGrilleEditeurObjetGraphique cGrilleEditeurObjetGraphique1 = new sc2i.win32.common.CGrilleEditeurObjetGraphique();
            sc2i.win32.common.CProfilEditeurObjetGraphique cProfilEditeurObjetGraphique1 = new sc2i.win32.common.CProfilEditeurObjetGraphique();
            this.m_panelGauche = new sc2i.win32.common.C2iPanel(this.components);
            this.m_arbreConsultation = new timos.Parametrage.ConsultationHierarchique.CArbreConsultationHierarchique();
            this.m_panelTopLeft = new sc2i.win32.common.C2iPanel(this.components);
            this.m_cmbArbreHierarchique = new sc2i.win32.data.CComboBoxListeObjetsDonnees();
            this.m_btnGraphe = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_panelToolBar = new System.Windows.Forms.Panel();
            this.m_btnModeEditLine = new System.Windows.Forms.RadioButton();
            this.m_btnEtiquette = new System.Windows.Forms.RadioButton();
            this.m_btnModeAjoutSchema = new System.Windows.Forms.RadioButton();
            this.m_btnModeAjoutLien = new System.Windows.Forms.RadioButton();
            this.m_btnModeZoom = new System.Windows.Forms.RadioButton();
            this.m_btnModeSelection = new System.Windows.Forms.RadioButton();
            this.m_cmbVueDynamique = new sc2i.win32.data.CComboBoxListeObjetsDonnees();
            this.m_propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.m_tabDeGauche = new sc2i.win32.common.C2iTabControl(this.components);
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.m_panelElements = new timos.CPanelListeSchemaReseau();
            this.c2iPanel1 = new sc2i.win32.common.C2iPanel(this.components);
            this.m_panelSchema = new timos.Reseau.CPanelEditionSchemaReseau();
            this.m_tooltipTraductible = new sc2i.win32.common.CToolTipTraductible(this.components);
            this.m_panelGauche.SuspendLayout();
            this.m_panelTopLeft.SuspendLayout();
            this.m_panelToolBar.SuspendLayout();
            this.m_tabDeGauche.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.c2iPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelGauche
            // 
            this.m_panelGauche.Controls.Add(this.m_arbreConsultation);
            this.m_panelGauche.Controls.Add(this.m_panelTopLeft);
            this.m_panelGauche.Controls.Add(this.m_btnGraphe);
            this.m_panelGauche.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelGauche.Location = new System.Drawing.Point(0, 0);
            this.m_panelGauche.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelGauche, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelGauche.Name = "m_panelGauche";
            this.m_panelGauche.Size = new System.Drawing.Size(193, 354);
            this.m_panelGauche.TabIndex = 0;
            // 
            // m_arbreConsultation
            // 
            this.m_arbreConsultation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_arbreConsultation.ImageIndex = 0;
            this.m_arbreConsultation.Location = new System.Drawing.Point(0, 33);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_arbreConsultation, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_arbreConsultation.Name = "m_arbreConsultation";
            this.m_arbreConsultation.SelectedImageIndex = 0;
            this.m_arbreConsultation.Size = new System.Drawing.Size(193, 298);
            this.m_arbreConsultation.TabIndex = 0;
            this.m_arbreConsultation.OnDragNode += new timos.Parametrage.ConsultationHierarchique.DragItemFromArbreConsultationEventHandler(this.m_arbreConsultation_OnDragNode);
            // 
            // m_panelTopLeft
            // 
            this.m_panelTopLeft.Controls.Add(this.m_cmbArbreHierarchique);
            this.m_panelTopLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelTopLeft.Location = new System.Drawing.Point(0, 0);
            this.m_panelTopLeft.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelTopLeft, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelTopLeft.Name = "m_panelTopLeft";
            this.m_panelTopLeft.Size = new System.Drawing.Size(193, 33);
            this.m_panelTopLeft.TabIndex = 1;
            // 
            // m_cmbArbreHierarchique
            // 
            this.m_cmbArbreHierarchique.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbArbreHierarchique.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbArbreHierarchique.ElementSelectionne = null;
            this.m_cmbArbreHierarchique.FormattingEnabled = true;
            this.m_cmbArbreHierarchique.IsLink = false;
            this.m_cmbArbreHierarchique.ListDonnees = null;
            this.m_cmbArbreHierarchique.Location = new System.Drawing.Point(3, 3);
            this.m_cmbArbreHierarchique.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbArbreHierarchique, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbArbreHierarchique.Name = "m_cmbArbreHierarchique";
            this.m_cmbArbreHierarchique.NullAutorise = false;
            this.m_cmbArbreHierarchique.ProprieteAffichee = null;
            this.m_cmbArbreHierarchique.ProprieteParentListeObjets = null;
            this.m_cmbArbreHierarchique.SelectionneurParent = null;
            this.m_cmbArbreHierarchique.Size = new System.Drawing.Size(187, 21);
            this.m_cmbArbreHierarchique.TabIndex = 0;
            this.m_cmbArbreHierarchique.TextNull = "(empty)";
            this.m_cmbArbreHierarchique.Tri = true;
            this.m_cmbArbreHierarchique.SelectedIndexChanged += new System.EventHandler(this.m_cmbArbreHierarchique_SelectedIndexChanged);
            // 
            // m_btnGraphe
            // 
            this.m_btnGraphe.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_btnGraphe.Location = new System.Drawing.Point(0, 331);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnGraphe, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnGraphe.Name = "m_btnGraphe";
            this.m_btnGraphe.Size = new System.Drawing.Size(193, 23);
            this.m_btnGraphe.TabIndex = 2;
            this.m_btnGraphe.Text = "Test graphe";
            this.m_btnGraphe.UseVisualStyleBackColor = true;
            this.m_btnGraphe.Visible = false;
            this.m_btnGraphe.Click += new System.EventHandler(this.m_btnGraphe_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(193, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitter1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(2, 379);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // m_panelToolBar
            // 
            this.m_panelToolBar.Controls.Add(this.m_btnModeEditLine);
            this.m_panelToolBar.Controls.Add(this.m_btnEtiquette);
            this.m_panelToolBar.Controls.Add(this.m_btnModeAjoutSchema);
            this.m_panelToolBar.Controls.Add(this.m_btnModeAjoutLien);
            this.m_panelToolBar.Controls.Add(this.m_btnModeZoom);
            this.m_panelToolBar.Controls.Add(this.m_btnModeSelection);
            this.m_panelToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelToolBar.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelToolBar, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelToolBar.Name = "m_panelToolBar";
            this.m_panelToolBar.Size = new System.Drawing.Size(370, 32);
            this.m_panelToolBar.TabIndex = 3;
            // 
            // m_btnModeEditLine
            // 
            this.m_btnModeEditLine.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_btnModeEditLine.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnModeEditLine.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_btnModeEditLine.Image = ((System.Drawing.Image)(resources.GetObject("m_btnModeEditLine.Image")));
            this.m_btnModeEditLine.Location = new System.Drawing.Point(160, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnModeEditLine, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnModeEditLine.Name = "m_btnModeEditLine";
            this.m_btnModeEditLine.Size = new System.Drawing.Size(32, 32);
            this.m_btnModeEditLine.TabIndex = 9;
            this.m_tooltipTraductible.SetToolTip(this.m_btnModeEditLine, "Edit selected line|30396");
            this.m_btnModeEditLine.UseVisualStyleBackColor = true;
            this.m_btnModeEditLine.Visible = false;
            this.m_btnModeEditLine.CheckedChanged += new System.EventHandler(this.m_btnModeEditLine_CheckedChanged);
            // 
            // m_btnEtiquette
            // 
            this.m_btnEtiquette.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_btnEtiquette.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnEtiquette.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_btnEtiquette.Image = ((System.Drawing.Image)(resources.GetObject("m_btnEtiquette.Image")));
            this.m_btnEtiquette.Location = new System.Drawing.Point(128, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnEtiquette, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnEtiquette.Name = "m_btnEtiquette";
            this.m_btnEtiquette.Size = new System.Drawing.Size(32, 32);
            this.m_btnEtiquette.TabIndex = 8;
            this.m_tooltipTraductible.SetToolTip(this.m_btnEtiquette, "Add a label|30406");
            this.m_btnEtiquette.UseVisualStyleBackColor = true;
            this.m_btnEtiquette.CheckedChanged += new System.EventHandler(this.m_btnEtiquette_CheckedChanged);
            // 
            // m_btnModeAjoutSchema
            // 
            this.m_btnModeAjoutSchema.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_btnModeAjoutSchema.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnModeAjoutSchema.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_btnModeAjoutSchema.Image = ((System.Drawing.Image)(resources.GetObject("m_btnModeAjoutSchema.Image")));
            this.m_btnModeAjoutSchema.Location = new System.Drawing.Point(96, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnModeAjoutSchema, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnModeAjoutSchema.Name = "m_btnModeAjoutSchema";
            this.m_btnModeAjoutSchema.Size = new System.Drawing.Size(32, 32);
            this.m_btnModeAjoutSchema.TabIndex = 6;
            this.m_tooltipTraductible.SetToolTip(this.m_btnModeAjoutSchema, "Add included diagram|30395");
            this.m_btnModeAjoutSchema.UseVisualStyleBackColor = true;
            this.m_btnModeAjoutSchema.CheckedChanged += new System.EventHandler(this.m_btnModeAjoutSchema_CheckedChanged);
            // 
            // m_btnModeAjoutLien
            // 
            this.m_btnModeAjoutLien.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_btnModeAjoutLien.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnModeAjoutLien.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_btnModeAjoutLien.Image = ((System.Drawing.Image)(resources.GetObject("m_btnModeAjoutLien.Image")));
            this.m_btnModeAjoutLien.Location = new System.Drawing.Point(64, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnModeAjoutLien, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnModeAjoutLien.Name = "m_btnModeAjoutLien";
            this.m_btnModeAjoutLien.Size = new System.Drawing.Size(32, 32);
            this.m_btnModeAjoutLien.TabIndex = 4;
            this.m_tooltipTraductible.SetToolTip(this.m_btnModeAjoutLien, "Add link|30394");
            this.m_btnModeAjoutLien.UseVisualStyleBackColor = true;
            this.m_btnModeAjoutLien.CheckedChanged += new System.EventHandler(this.m_btnModeAjoutLien_CheckedChanged_1);
            // 
            // m_btnModeZoom
            // 
            this.m_btnModeZoom.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_btnModeZoom.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnModeZoom.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_btnModeZoom.Image = ((System.Drawing.Image)(resources.GetObject("m_btnModeZoom.Image")));
            this.m_btnModeZoom.Location = new System.Drawing.Point(32, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnModeZoom, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnModeZoom.Name = "m_btnModeZoom";
            this.m_btnModeZoom.Size = new System.Drawing.Size(32, 32);
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
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnModeSelection, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnModeSelection.Name = "m_btnModeSelection";
            this.m_btnModeSelection.Size = new System.Drawing.Size(32, 32);
            this.m_btnModeSelection.TabIndex = 0;
            this.m_btnModeSelection.TabStop = true;
            this.m_tooltipTraductible.SetToolTip(this.m_btnModeSelection, "Select|30392");
            this.m_btnModeSelection.UseVisualStyleBackColor = true;
            this.m_btnModeSelection.CheckedChanged += new System.EventHandler(this.m_btnModeSelection_CheckedChanged);
            // 
            // m_cmbVueDynamique
            // 
            this.m_cmbVueDynamique.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbVueDynamique.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbVueDynamique.ElementSelectionne = null;
            this.m_cmbVueDynamique.FormattingEnabled = true;
            this.m_cmbVueDynamique.IsLink = false;
            this.m_cmbVueDynamique.ListDonnees = null;
            this.m_cmbVueDynamique.Location = new System.Drawing.Point(208, 6);
            this.m_cmbVueDynamique.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbVueDynamique, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_cmbVueDynamique.Name = "m_cmbVueDynamique";
            this.m_cmbVueDynamique.NullAutorise = true;
            this.m_cmbVueDynamique.ProprieteAffichee = null;
            this.m_cmbVueDynamique.ProprieteParentListeObjets = null;
            this.m_cmbVueDynamique.SelectionneurParent = null;
            this.m_cmbVueDynamique.Size = new System.Drawing.Size(153, 21);
            this.m_cmbVueDynamique.TabIndex = 10;
            this.m_cmbVueDynamique.TextNull = "(None)";
            this.m_cmbVueDynamique.Tri = true;
            this.m_cmbVueDynamique.SelectionChangeCommitted += new System.EventHandler(this.m_cmbVueDynamique_SelectionChangeCommitted);
            // 
            // m_propertyGrid
            // 
            this.m_propertyGrid.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_propertyGrid.Location = new System.Drawing.Point(565, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_propertyGrid, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_propertyGrid.Name = "m_propertyGrid";
            this.m_propertyGrid.Size = new System.Drawing.Size(164, 379);
            this.m_propertyGrid.TabIndex = 4;
            this.m_propertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.m_propertyGrid_PropertyValueChanged);
            // 
            // m_tabDeGauche
            // 
            this.m_tabDeGauche.BoldSelectedPage = true;
            this.m_tabDeGauche.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_tabDeGauche.IDEPixelArea = false;
            this.m_tabDeGauche.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabDeGauche, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_tabDeGauche.Name = "m_tabDeGauche";
            this.m_tabDeGauche.Ombre = false;
            this.m_tabDeGauche.PositionTop = true;
            this.m_tabDeGauche.SelectedIndex = 0;
            this.m_tabDeGauche.SelectedTab = this.tabPage1;
            this.m_tabDeGauche.Size = new System.Drawing.Size(193, 379);
            this.m_tabDeGauche.TabIndex = 5;
            this.m_tabDeGauche.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2});
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.m_panelGauche);
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(193, 354);
            this.tabPage1.TabIndex = 10;
            this.tabPage1.Title = "Network|20130";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.m_panelElements);
            this.tabPage2.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(193, 354);
            this.tabPage2.TabIndex = 11;
            this.tabPage2.Title = "Others|20131";
            // 
            // m_panelElements
            // 
            this.m_panelElements.AutoScroll = true;
            this.m_panelElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelElements.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelElements, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelElements.Name = "m_panelElements";
            this.m_panelElements.Size = new System.Drawing.Size(193, 354);
            this.m_panelElements.TabIndex = 6;
            // 
            // c2iPanel1
            // 
            this.c2iPanel1.Controls.Add(this.m_cmbVueDynamique);
            this.c2iPanel1.Controls.Add(this.m_panelSchema);
            this.c2iPanel1.Controls.Add(this.m_panelToolBar);
            this.c2iPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c2iPanel1.Location = new System.Drawing.Point(195, 0);
            this.c2iPanel1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.c2iPanel1.Name = "c2iPanel1";
            this.c2iPanel1.Size = new System.Drawing.Size(370, 379);
            this.c2iPanel1.TabIndex = 6;
            // 
            // m_panelSchema
            // 
            this.m_panelSchema.AllowDrop = true;
            this.m_panelSchema.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.m_panelSchema.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelSchema.Echelle = 1F;
            this.m_panelSchema.Editeur = null;
            this.m_panelSchema.EffetAjoutSuppression = false;
            this.m_panelSchema.EffetFonduMenu = true;
            this.m_panelSchema.EnDeplacement = false;
            this.m_panelSchema.FormesDesPoignees = sc2i.win32.common.EFormePoignee.Carre;
            cGrilleEditeurObjetGraphique1.Couleur = System.Drawing.Color.LightGray;
            cGrilleEditeurObjetGraphique1.HauteurCarreau = 20;
            cGrilleEditeurObjetGraphique1.LargeurCarreau = 20;
            cGrilleEditeurObjetGraphique1.Representation = sc2i.win32.common.ERepresentationGrille.LignesContinues;
            cGrilleEditeurObjetGraphique1.TailleCarreau = new System.Drawing.Size(20, 20);
            this.m_panelSchema.GrilleAlignement = cGrilleEditeurObjetGraphique1;
            this.m_panelSchema.HauteurMinimaleDesObjets = 10;
            this.m_panelSchema.HistorisationActive = true;
            this.m_panelSchema.LargeurMinimaleDesObjets = 10;
            this.m_panelSchema.LienReseauEdite = null;
            this.m_panelSchema.Location = new System.Drawing.Point(0, 32);
            this.m_panelSchema.LockEdition = false;
            this.m_panelSchema.Marge = 10;
            this.m_panelSchema.ModeAffichageGrille = sc2i.win32.common.EModeAffichageGrille.AuDeplacement;
            this.m_panelSchema.ModeEdition = timos.Reseau.EModeEditeurSchema.Selection;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelSchema, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelSchema.ModeRepresentationGrille = sc2i.win32.common.ERepresentationGrille.LignesContinues;
            this.m_panelSchema.ModeSouris = sc2i.win32.common.CPanelEditionObjetGraphique.EModeSouris.Selection;
            this.m_panelSchema.Name = "m_panelSchema";
            this.m_panelSchema.NoClipboard = false;
            this.m_panelSchema.NoDelete = false;
            this.m_panelSchema.NoDoubleClick = false;
            this.m_panelSchema.NombreHistorisation = 10;
            this.m_panelSchema.NoMenu = false;
            this.m_panelSchema.ObjetEdite = null;
            this.m_panelSchema.ObjetSchemaReseau = null;
            this.m_panelSchema.ParametreDynamique = null;
            cProfilEditeurObjetGraphique1.FormeDesPoignees = sc2i.win32.common.EFormePoignee.Carre;
            cProfilEditeurObjetGraphique1.Grille = cGrilleEditeurObjetGraphique1;
            cProfilEditeurObjetGraphique1.HistorisationActive = true;
            cProfilEditeurObjetGraphique1.Marge = 10;
            cProfilEditeurObjetGraphique1.ModeAffichageGrille = sc2i.win32.common.EModeAffichageGrille.AuDeplacement;
            cProfilEditeurObjetGraphique1.NombreHistorisation = 10;
            cProfilEditeurObjetGraphique1.ToujoursAlignerSurLaGrille = false;
            this.m_panelSchema.Profil = cProfilEditeurObjetGraphique1;
            this.m_panelSchema.RefreshSelectionChanged = true;
            this.m_panelSchema.SchemaReseau = null;
            this.m_panelSchema.SelectionVisible = true;
            this.m_panelSchema.Size = new System.Drawing.Size(370, 347);
            this.m_panelSchema.TabIndex = 2;
            this.m_panelSchema.ToujoursAlignerSelonLesControles = true;
            this.m_panelSchema.ToujoursAlignerSurLaGrille = false;
            this.m_panelSchema.OnChangeModeEdition += new System.EventHandler(this.m_panelSchema_OnChangeModeEdition);
            this.m_panelSchema.SelectionChanged += new System.EventHandler(this.m_panelSchema_SelectionChanged);
            // 
            // CEditeurSchemaReseau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.c2iPanel1);
            this.Controls.Add(this.m_propertyGrid);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.m_tabDeGauche);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CEditeurSchemaReseau";
            this.Size = new System.Drawing.Size(729, 379);
            this.Load += new System.EventHandler(this.CEditeurSchemaReseau_Load);
            this.m_panelGauche.ResumeLayout(false);
            this.m_panelTopLeft.ResumeLayout(false);
            this.m_panelToolBar.ResumeLayout(false);
            this.m_tabDeGauche.ResumeLayout(false);
            this.m_tabDeGauche.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.c2iPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.C2iPanel m_panelGauche;
        private System.Windows.Forms.Splitter splitter1;
        private CPanelEditionSchemaReseau m_panelSchema;
        private timos.Parametrage.ConsultationHierarchique.CArbreConsultationHierarchique m_arbreConsultation;
        private sc2i.win32.common.C2iPanel m_panelTopLeft;
        private sc2i.win32.data.CComboBoxListeObjetsDonnees m_cmbArbreHierarchique;
        private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
        private System.Windows.Forms.Panel m_panelToolBar;
        private System.Windows.Forms.RadioButton m_btnModeZoom;
        private System.Windows.Forms.RadioButton m_btnModeSelection;
        private System.Windows.Forms.RadioButton m_btnModeAjoutLien;
        private System.Windows.Forms.RadioButton m_btnModeAjoutSchema;
        private sc2i.win32.common.CToolTipTraductible m_tooltipTraductible;
        private System.Windows.Forms.PropertyGrid m_propertyGrid;
        private System.Windows.Forms.RadioButton m_btnModeEditLine;
        private System.Windows.Forms.RadioButton m_btnEtiquette;
        private sc2i.win32.common.C2iTabControl m_tabDeGauche;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private Crownwood.Magic.Controls.TabPage tabPage2;
        private CPanelListeSchemaReseau m_panelElements;
        private sc2i.win32.common.C2iPanel c2iPanel1;
        private System.Windows.Forms.Button m_btnGraphe;
        private sc2i.win32.data.CComboBoxListeObjetsDonnees m_cmbVueDynamique;
      

    }
}
