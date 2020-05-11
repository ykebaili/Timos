using timos.composantphysique;
namespace timos.composantphysique
{
    partial class CPanelEditeurComposantPhysique
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPanelEditeurComposantPhysique));
            sc2i.win32.common.CGrilleEditeurObjetGraphique cGrilleEditeurObjetGraphique1 = new sc2i.win32.common.CGrilleEditeurObjetGraphique();
            sc2i.win32.common.CProfilEditeurObjetGraphique cProfilEditeurObjetGraphique1 = new sc2i.win32.common.CProfilEditeurObjetGraphique();
            sc2i.win32.common.CGrilleEditeurObjetGraphique cGrilleEditeurObjetGraphique2 = new sc2i.win32.common.CGrilleEditeurObjetGraphique();
            sc2i.win32.common.CProfilEditeurObjetGraphique cProfilEditeurObjetGraphique2 = new sc2i.win32.common.CProfilEditeurObjetGraphique();
            sc2i.win32.common.CGrilleEditeurObjetGraphique cGrilleEditeurObjetGraphique3 = new sc2i.win32.common.CGrilleEditeurObjetGraphique();
            sc2i.win32.common.CProfilEditeurObjetGraphique cProfilEditeurObjetGraphique3 = new sc2i.win32.common.CProfilEditeurObjetGraphique();
            this.m_btnOpen = new System.Windows.Forms.Button();
            this.m_btnSave = new System.Windows.Forms.Button();
            this.m_panelToolBar = new System.Windows.Forms.Panel();
            this.m_btnModeEditLine = new System.Windows.Forms.RadioButton();
            this.m_btnModeZoom = new System.Windows.Forms.RadioButton();
            this.m_btnModeSelection = new System.Windows.Forms.RadioButton();
            this.m_panelGauche = new System.Windows.Forms.Panel();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_listeControles = new timos.composantphysique.CPanelListe2iComposantPhysique();
            this.m_panelCentre = new System.Windows.Forms.Panel();
            this.m_splitContainerCentral = new System.Windows.Forms.SplitContainer();
            this.m_containerTop = new System.Windows.Forms.SplitContainer();
            this.m_editeurTopLeft = new timos.composantphysique.CPanelEditionComposantPhysique();
            this.m_editeurTopRight = new timos.composantphysique.CPanelEditionComposantPhysique();
            this.m_containerBottom = new System.Windows.Forms.SplitContainer();
            this.m_editeurBottomLeft = new timos.composantphysique.CPanelEditionComposantPhysique();
            this.m_vue3D = new timos.data.composantphysique.CVue3D();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_btnBottom = new System.Windows.Forms.Button();
            this.m_btnRight = new System.Windows.Forms.Button();
            this.m_btnShowTop = new System.Windows.Forms.Button();
            this.m_btnTop = new System.Windows.Forms.Button();
            this.m_btnLeft = new System.Windows.Forms.Button();
            this.m_btnFront = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.m_tabOnRight = new sc2i.win32.common.C2iTabControl(this.components);
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.m_propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.m_panelFormules = new System.Windows.Forms.Panel();
            this.m_tooltipTraductible = new sc2i.win32.common.CToolTipTraductible(this.components);
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.m_chkModeRuntime = new System.Windows.Forms.CheckBox();
            this.m_panelToolBar.SuspendLayout();
            this.m_panelGauche.SuspendLayout();
            this.panel1.SuspendLayout();
            this.m_panelCentre.SuspendLayout();
            this.m_splitContainerCentral.Panel1.SuspendLayout();
            this.m_splitContainerCentral.Panel2.SuspendLayout();
            this.m_splitContainerCentral.SuspendLayout();
            this.m_containerTop.Panel1.SuspendLayout();
            this.m_containerTop.Panel2.SuspendLayout();
            this.m_containerTop.SuspendLayout();
            this.m_containerBottom.Panel1.SuspendLayout();
            this.m_containerBottom.Panel2.SuspendLayout();
            this.m_containerBottom.SuspendLayout();
            this.panel2.SuspendLayout();
            this.m_tabOnRight.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnOpen
            // 
            this.m_btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("m_btnOpen.Image")));
            this.m_btnOpen.Location = new System.Drawing.Point(84, 3);
            this.m_btnOpen.Name = "m_btnOpen";
            this.m_btnOpen.Size = new System.Drawing.Size(24, 23);
            this.m_extStyle.SetStyleBackColor(this.m_btnOpen, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnOpen, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnOpen.TabIndex = 32;
            this.m_btnOpen.Click += new System.EventHandler(this.m_btnOpen_Click);
            // 
            // m_btnSave
            // 
            this.m_btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnSave.Image = ((System.Drawing.Image)(resources.GetObject("m_btnSave.Image")));
            this.m_btnSave.Location = new System.Drawing.Point(114, 3);
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Size = new System.Drawing.Size(24, 23);
            this.m_extStyle.SetStyleBackColor(this.m_btnSave, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSave, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnSave.TabIndex = 31;
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // m_panelToolBar
            // 
            this.m_panelToolBar.Controls.Add(this.m_chkModeRuntime);
            this.m_panelToolBar.Controls.Add(this.m_btnModeEditLine);
            this.m_panelToolBar.Controls.Add(this.m_btnModeZoom);
            this.m_panelToolBar.Controls.Add(this.m_btnModeSelection);
            this.m_panelToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelToolBar.Location = new System.Drawing.Point(0, 0);
            this.m_panelToolBar.Name = "m_panelToolBar";
            this.m_panelToolBar.Size = new System.Drawing.Size(432, 30);
            this.m_extStyle.SetStyleBackColor(this.m_panelToolBar, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelToolBar, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
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
            this.m_extStyle.SetStyleBackColor(this.m_btnModeEditLine, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnModeEditLine, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
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
            this.m_extStyle.SetStyleBackColor(this.m_btnModeZoom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnModeZoom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
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
            this.m_extStyle.SetStyleBackColor(this.m_btnModeSelection, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnModeSelection, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnModeSelection.TabIndex = 0;
            this.m_btnModeSelection.TabStop = true;
            this.m_tooltipTraductible.SetToolTip(this.m_btnModeSelection, "Select|30392");
            this.m_btnModeSelection.UseVisualStyleBackColor = true;
            this.m_btnModeSelection.CheckedChanged += new System.EventHandler(this.m_btnModeSelection_CheckedChanged);
            // 
            // m_panelGauche
            // 
            this.m_panelGauche.Controls.Add(this.splitter3);
            this.m_panelGauche.Controls.Add(this.panel1);
            this.m_panelGauche.Controls.Add(this.m_listeControles);
            this.m_panelGauche.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelGauche.Location = new System.Drawing.Point(0, 0);
            this.m_panelGauche.Name = "m_panelGauche";
            this.m_panelGauche.Size = new System.Drawing.Size(141, 442);
            this.m_extStyle.SetStyleBackColor(this.m_panelGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelGauche.TabIndex = 35;
            // 
            // splitter3
            // 
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter3.Location = new System.Drawing.Point(0, 148);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(141, 3);
            this.m_extStyle.SetStyleBackColor(this.splitter3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitter3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitter3.TabIndex = 13;
            this.splitter3.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_btnSave);
            this.panel1.Controls.Add(this.m_btnOpen);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 413);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(141, 29);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 0;
            // 
            // m_listeControles
            // 
            this.m_listeControles.AutoScroll = true;
            this.m_listeControles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_listeControles.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_listeControles.Location = new System.Drawing.Point(0, 0);
            this.m_listeControles.Name = "m_listeControles";
            this.m_listeControles.Size = new System.Drawing.Size(141, 148);
            this.m_extStyle.SetStyleBackColor(this.m_listeControles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_listeControles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_listeControles.TabIndex = 1;
            // 
            // m_panelCentre
            // 
            this.m_panelCentre.Controls.Add(this.m_splitContainerCentral);
            this.m_panelCentre.Controls.Add(this.panel2);
            this.m_panelCentre.Controls.Add(this.m_panelToolBar);
            this.m_panelCentre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelCentre.Location = new System.Drawing.Point(144, 0);
            this.m_panelCentre.Name = "m_panelCentre";
            this.m_panelCentre.Size = new System.Drawing.Size(432, 442);
            this.m_extStyle.SetStyleBackColor(this.m_panelCentre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCentre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelCentre.TabIndex = 36;
            // 
            // m_splitContainerCentral
            // 
            this.m_splitContainerCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_splitContainerCentral.Location = new System.Drawing.Point(0, 30);
            this.m_splitContainerCentral.Name = "m_splitContainerCentral";
            this.m_splitContainerCentral.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // m_splitContainerCentral.Panel1
            // 
            this.m_splitContainerCentral.Panel1.Controls.Add(this.m_containerTop);
            this.m_extStyle.SetStyleBackColor(this.m_splitContainerCentral.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainerCentral.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_splitContainerCentral.Panel2
            // 
            this.m_splitContainerCentral.Panel2.Controls.Add(this.m_containerBottom);
            this.m_extStyle.SetStyleBackColor(this.m_splitContainerCentral.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainerCentral.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_splitContainerCentral.Size = new System.Drawing.Size(432, 383);
            this.m_splitContainerCentral.SplitterDistance = 190;
            this.m_extStyle.SetStyleBackColor(this.m_splitContainerCentral, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainerCentral, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_splitContainerCentral.TabIndex = 36;
            // 
            // m_containerTop
            // 
            this.m_containerTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_containerTop.Location = new System.Drawing.Point(0, 0);
            this.m_containerTop.Name = "m_containerTop";
            // 
            // m_containerTop.Panel1
            // 
            this.m_containerTop.Panel1.Controls.Add(this.m_editeurTopLeft);
            this.m_extStyle.SetStyleBackColor(this.m_containerTop.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_containerTop.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_containerTop.Panel2
            // 
            this.m_containerTop.Panel2.Controls.Add(this.m_editeurTopRight);
            this.m_extStyle.SetStyleBackColor(this.m_containerTop.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_containerTop.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_containerTop.Size = new System.Drawing.Size(432, 190);
            this.m_containerTop.SplitterDistance = 213;
            this.m_extStyle.SetStyleBackColor(this.m_containerTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_containerTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_containerTop.TabIndex = 34;
            // 
            // m_editeurTopLeft
            // 
            this.m_editeurTopLeft.AllowDrop = true;
            this.m_editeurTopLeft.BackColor = System.Drawing.SystemColors.Control;
            this.m_editeurTopLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_editeurTopLeft.ComposantEdite = null;
            this.m_editeurTopLeft.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.m_editeurTopLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_editeurTopLeft.Echelle = 1F;
            this.m_editeurTopLeft.Editeur = null;
            this.m_editeurTopLeft.EffetAjoutSuppression = false;
            this.m_editeurTopLeft.EffetFonduMenu = true;
            this.m_editeurTopLeft.EnDeplacement = false;
            this.m_editeurTopLeft.FormesDesPoignees = sc2i.win32.common.EFormePoignee.Carre;
            this.m_editeurTopLeft.FournisseurPropriete = null;
            cGrilleEditeurObjetGraphique1.Couleur = System.Drawing.Color.LightGray;
            cGrilleEditeurObjetGraphique1.HauteurCarreau = 20;
            cGrilleEditeurObjetGraphique1.LargeurCarreau = 20;
            cGrilleEditeurObjetGraphique1.Representation = sc2i.win32.common.ERepresentationGrille.LignesContinues;
            cGrilleEditeurObjetGraphique1.TailleCarreau = new System.Drawing.Size(20, 20);
            this.m_editeurTopLeft.GrilleAlignement = cGrilleEditeurObjetGraphique1;
            this.m_editeurTopLeft.HauteurMinimaleDesObjets = 10;
            this.m_editeurTopLeft.HistorisationActive = true;
            this.m_editeurTopLeft.LargeurMinimaleDesObjets = 10;
            this.m_editeurTopLeft.Location = new System.Drawing.Point(0, 0);
            this.m_editeurTopLeft.LockEdition = false;
            this.m_editeurTopLeft.Marge = 10;
            this.m_editeurTopLeft.ModeAffichageGrille = sc2i.win32.common.EModeAffichageGrille.AuDeplacement;
            this.m_editeurTopLeft.ModeEdition = timos.composantphysique.EModeEditeurComposantPhysique.Selection;
            this.m_editeurTopLeft.ModeRepresentationGrille = sc2i.win32.common.ERepresentationGrille.LignesContinues;
            this.m_editeurTopLeft.ModeSouris = sc2i.win32.common.CPanelEditionObjetGraphique.EModeSouris.Selection;
            this.m_editeurTopLeft.Name = "m_editeurTopLeft";
            this.m_editeurTopLeft.NoClipboard = false;
            this.m_editeurTopLeft.NoDelete = false;
            this.m_editeurTopLeft.NoDoubleClick = false;
            this.m_editeurTopLeft.NombreHistorisation = 10;
            this.m_editeurTopLeft.NoMenu = false;
            this.m_editeurTopLeft.ObjetEdite = null;
            cProfilEditeurObjetGraphique1.FormeDesPoignees = sc2i.win32.common.EFormePoignee.Carre;
            cProfilEditeurObjetGraphique1.Grille = cGrilleEditeurObjetGraphique1;
            cProfilEditeurObjetGraphique1.HistorisationActive = true;
            cProfilEditeurObjetGraphique1.Marge = 10;
            cProfilEditeurObjetGraphique1.ModeAffichageGrille = sc2i.win32.common.EModeAffichageGrille.AuDeplacement;
            cProfilEditeurObjetGraphique1.NombreHistorisation = 10;
            cProfilEditeurObjetGraphique1.ToujoursAlignerSurLaGrille = false;
            this.m_editeurTopLeft.Profil = cProfilEditeurObjetGraphique1;
            this.m_editeurTopLeft.RefreshSelectionChanged = true;
            this.m_editeurTopLeft.SelectionVisible = true;
            this.m_editeurTopLeft.Size = new System.Drawing.Size(213, 190);
            this.m_extStyle.SetStyleBackColor(this.m_editeurTopLeft, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_editeurTopLeft, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_editeurTopLeft.TabIndex = 0;
            this.m_editeurTopLeft.ToujoursAlignerSelonLesControles = true;
            this.m_editeurTopLeft.ToujoursAlignerSurLaGrille = false;
            this.m_editeurTopLeft.TypeEdite = null;
            this.m_editeurTopLeft.VueAffichee = timos.data.EFaceVueDynamique.Front;
            this.m_editeurTopLeft.SelectionChanged += new System.EventHandler(this.Editeur_SelectionChanged);
            this.m_editeurTopLeft.DessinerEventHandler += new timos.composantphysique.OnDessinerEventHandler(this.editeur_DessinerEventHandler);
            // 
            // m_editeurTopRight
            // 
            this.m_editeurTopRight.AllowDrop = true;
            this.m_editeurTopRight.BackColor = System.Drawing.SystemColors.Control;
            this.m_editeurTopRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_editeurTopRight.ComposantEdite = null;
            this.m_editeurTopRight.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.m_editeurTopRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_editeurTopRight.Echelle = 1F;
            this.m_editeurTopRight.Editeur = null;
            this.m_editeurTopRight.EffetAjoutSuppression = false;
            this.m_editeurTopRight.EffetFonduMenu = true;
            this.m_editeurTopRight.EnDeplacement = false;
            this.m_editeurTopRight.FormesDesPoignees = sc2i.win32.common.EFormePoignee.Carre;
            this.m_editeurTopRight.FournisseurPropriete = null;
            cGrilleEditeurObjetGraphique2.Couleur = System.Drawing.Color.LightGray;
            cGrilleEditeurObjetGraphique2.HauteurCarreau = 20;
            cGrilleEditeurObjetGraphique2.LargeurCarreau = 20;
            cGrilleEditeurObjetGraphique2.Representation = sc2i.win32.common.ERepresentationGrille.LignesContinues;
            cGrilleEditeurObjetGraphique2.TailleCarreau = new System.Drawing.Size(20, 20);
            this.m_editeurTopRight.GrilleAlignement = cGrilleEditeurObjetGraphique2;
            this.m_editeurTopRight.HauteurMinimaleDesObjets = 10;
            this.m_editeurTopRight.HistorisationActive = true;
            this.m_editeurTopRight.LargeurMinimaleDesObjets = 10;
            this.m_editeurTopRight.Location = new System.Drawing.Point(0, 0);
            this.m_editeurTopRight.LockEdition = false;
            this.m_editeurTopRight.Marge = 10;
            this.m_editeurTopRight.ModeAffichageGrille = sc2i.win32.common.EModeAffichageGrille.AuDeplacement;
            this.m_editeurTopRight.ModeEdition = timos.composantphysique.EModeEditeurComposantPhysique.Selection;
            this.m_editeurTopRight.ModeRepresentationGrille = sc2i.win32.common.ERepresentationGrille.LignesContinues;
            this.m_editeurTopRight.ModeSouris = sc2i.win32.common.CPanelEditionObjetGraphique.EModeSouris.Selection;
            this.m_editeurTopRight.Name = "m_editeurTopRight";
            this.m_editeurTopRight.NoClipboard = false;
            this.m_editeurTopRight.NoDelete = false;
            this.m_editeurTopRight.NoDoubleClick = false;
            this.m_editeurTopRight.NombreHistorisation = 10;
            this.m_editeurTopRight.NoMenu = false;
            this.m_editeurTopRight.ObjetEdite = null;
            cProfilEditeurObjetGraphique2.FormeDesPoignees = sc2i.win32.common.EFormePoignee.Carre;
            cProfilEditeurObjetGraphique2.Grille = cGrilleEditeurObjetGraphique2;
            cProfilEditeurObjetGraphique2.HistorisationActive = true;
            cProfilEditeurObjetGraphique2.Marge = 10;
            cProfilEditeurObjetGraphique2.ModeAffichageGrille = sc2i.win32.common.EModeAffichageGrille.AuDeplacement;
            cProfilEditeurObjetGraphique2.NombreHistorisation = 10;
            cProfilEditeurObjetGraphique2.ToujoursAlignerSurLaGrille = false;
            this.m_editeurTopRight.Profil = cProfilEditeurObjetGraphique2;
            this.m_editeurTopRight.RefreshSelectionChanged = true;
            this.m_editeurTopRight.SelectionVisible = true;
            this.m_editeurTopRight.Size = new System.Drawing.Size(215, 190);
            this.m_extStyle.SetStyleBackColor(this.m_editeurTopRight, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_editeurTopRight, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_editeurTopRight.TabIndex = 1;
            this.m_editeurTopRight.ToujoursAlignerSelonLesControles = true;
            this.m_editeurTopRight.ToujoursAlignerSurLaGrille = false;
            this.m_editeurTopRight.TypeEdite = null;
            this.m_editeurTopRight.VueAffichee = timos.data.EFaceVueDynamique.Left;
            this.m_editeurTopRight.SelectionChanged += new System.EventHandler(this.Editeur_SelectionChanged);
            this.m_editeurTopRight.DessinerEventHandler += new timos.composantphysique.OnDessinerEventHandler(this.editeur_DessinerEventHandler);
            // 
            // m_containerBottom
            // 
            this.m_containerBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_containerBottom.Location = new System.Drawing.Point(0, 0);
            this.m_containerBottom.Name = "m_containerBottom";
            // 
            // m_containerBottom.Panel1
            // 
            this.m_containerBottom.Panel1.Controls.Add(this.m_editeurBottomLeft);
            this.m_extStyle.SetStyleBackColor(this.m_containerBottom.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_containerBottom.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_containerBottom.Panel2
            // 
            this.m_containerBottom.Panel2.Controls.Add(this.m_vue3D);
            this.m_extStyle.SetStyleBackColor(this.m_containerBottom.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_containerBottom.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_containerBottom.Size = new System.Drawing.Size(432, 189);
            this.m_containerBottom.SplitterDistance = 213;
            this.m_extStyle.SetStyleBackColor(this.m_containerBottom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_containerBottom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_containerBottom.TabIndex = 35;
            // 
            // m_editeurBottomLeft
            // 
            this.m_editeurBottomLeft.AllowDrop = true;
            this.m_editeurBottomLeft.BackColor = System.Drawing.SystemColors.Control;
            this.m_editeurBottomLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_editeurBottomLeft.ComposantEdite = null;
            this.m_editeurBottomLeft.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.m_editeurBottomLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_editeurBottomLeft.Echelle = 1F;
            this.m_editeurBottomLeft.Editeur = null;
            this.m_editeurBottomLeft.EffetAjoutSuppression = false;
            this.m_editeurBottomLeft.EffetFonduMenu = true;
            this.m_editeurBottomLeft.EnDeplacement = false;
            this.m_editeurBottomLeft.FormesDesPoignees = sc2i.win32.common.EFormePoignee.Carre;
            this.m_editeurBottomLeft.FournisseurPropriete = null;
            cGrilleEditeurObjetGraphique3.Couleur = System.Drawing.Color.LightGray;
            cGrilleEditeurObjetGraphique3.HauteurCarreau = 20;
            cGrilleEditeurObjetGraphique3.LargeurCarreau = 20;
            cGrilleEditeurObjetGraphique3.Representation = sc2i.win32.common.ERepresentationGrille.LignesContinues;
            cGrilleEditeurObjetGraphique3.TailleCarreau = new System.Drawing.Size(20, 20);
            this.m_editeurBottomLeft.GrilleAlignement = cGrilleEditeurObjetGraphique3;
            this.m_editeurBottomLeft.HauteurMinimaleDesObjets = 10;
            this.m_editeurBottomLeft.HistorisationActive = true;
            this.m_editeurBottomLeft.LargeurMinimaleDesObjets = 10;
            this.m_editeurBottomLeft.Location = new System.Drawing.Point(0, 0);
            this.m_editeurBottomLeft.LockEdition = false;
            this.m_editeurBottomLeft.Marge = 10;
            this.m_editeurBottomLeft.ModeAffichageGrille = sc2i.win32.common.EModeAffichageGrille.AuDeplacement;
            this.m_editeurBottomLeft.ModeEdition = timos.composantphysique.EModeEditeurComposantPhysique.Selection;
            this.m_editeurBottomLeft.ModeRepresentationGrille = sc2i.win32.common.ERepresentationGrille.LignesContinues;
            this.m_editeurBottomLeft.ModeSouris = sc2i.win32.common.CPanelEditionObjetGraphique.EModeSouris.Selection;
            this.m_editeurBottomLeft.Name = "m_editeurBottomLeft";
            this.m_editeurBottomLeft.NoClipboard = false;
            this.m_editeurBottomLeft.NoDelete = false;
            this.m_editeurBottomLeft.NoDoubleClick = false;
            this.m_editeurBottomLeft.NombreHistorisation = 10;
            this.m_editeurBottomLeft.NoMenu = false;
            this.m_editeurBottomLeft.ObjetEdite = null;
            cProfilEditeurObjetGraphique3.FormeDesPoignees = sc2i.win32.common.EFormePoignee.Carre;
            cProfilEditeurObjetGraphique3.Grille = cGrilleEditeurObjetGraphique3;
            cProfilEditeurObjetGraphique3.HistorisationActive = true;
            cProfilEditeurObjetGraphique3.Marge = 10;
            cProfilEditeurObjetGraphique3.ModeAffichageGrille = sc2i.win32.common.EModeAffichageGrille.AuDeplacement;
            cProfilEditeurObjetGraphique3.NombreHistorisation = 10;
            cProfilEditeurObjetGraphique3.ToujoursAlignerSurLaGrille = false;
            this.m_editeurBottomLeft.Profil = cProfilEditeurObjetGraphique3;
            this.m_editeurBottomLeft.RefreshSelectionChanged = true;
            this.m_editeurBottomLeft.SelectionVisible = true;
            this.m_editeurBottomLeft.Size = new System.Drawing.Size(213, 189);
            this.m_extStyle.SetStyleBackColor(this.m_editeurBottomLeft, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_editeurBottomLeft, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_editeurBottomLeft.TabIndex = 0;
            this.m_editeurBottomLeft.ToujoursAlignerSelonLesControles = true;
            this.m_editeurBottomLeft.ToujoursAlignerSurLaGrille = false;
            this.m_editeurBottomLeft.TypeEdite = null;
            this.m_editeurBottomLeft.VueAffichee = timos.data.EFaceVueDynamique.Top;
            this.m_editeurBottomLeft.SelectionChanged += new System.EventHandler(this.Editeur_SelectionChanged);
            this.m_editeurBottomLeft.DessinerEventHandler += new timos.composantphysique.OnDessinerEventHandler(this.editeur_DessinerEventHandler);
            // 
            // m_vue3D
            // 
            this.m_vue3D.Composant = null;
            this.m_vue3D.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_vue3D.DrawRenderTime = false;
            this.m_vue3D.FrameRate = 10F;
            this.m_vue3D.GDIEnabled = false;
            this.m_vue3D.Location = new System.Drawing.Point(0, 0);
            this.m_vue3D.Name = "m_vue3D";
            this.m_vue3D.Size = new System.Drawing.Size(215, 189);
            this.m_extStyle.SetStyleBackColor(this.m_vue3D, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_vue3D, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_vue3D.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_btnBottom);
            this.panel2.Controls.Add(this.m_btnRight);
            this.panel2.Controls.Add(this.m_btnShowTop);
            this.panel2.Controls.Add(this.m_btnTop);
            this.panel2.Controls.Add(this.m_btnLeft);
            this.panel2.Controls.Add(this.m_btnFront);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 413);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(432, 29);
            this.m_extStyle.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel2.TabIndex = 3;
            // 
            // m_btnBottom
            // 
            this.m_btnBottom.Location = new System.Drawing.Point(287, 3);
            this.m_btnBottom.Name = "m_btnBottom";
            this.m_btnBottom.Size = new System.Drawing.Size(49, 23);
            this.m_extStyle.SetStyleBackColor(this.m_btnBottom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnBottom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnBottom.TabIndex = 5;
            this.m_btnBottom.Text = "Bottom";
            this.m_btnBottom.UseVisualStyleBackColor = true;
            this.m_btnBottom.Click += new System.EventHandler(this.m_btnBottom_Click);
            // 
            // m_btnRight
            // 
            this.m_btnRight.Location = new System.Drawing.Point(232, 3);
            this.m_btnRight.Name = "m_btnRight";
            this.m_btnRight.Size = new System.Drawing.Size(49, 23);
            this.m_extStyle.SetStyleBackColor(this.m_btnRight, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnRight, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnRight.TabIndex = 4;
            this.m_btnRight.Text = "Right";
            this.m_btnRight.UseVisualStyleBackColor = true;
            this.m_btnRight.Click += new System.EventHandler(this.m_btnRight_Click);
            // 
            // m_btnShowTop
            // 
            this.m_btnShowTop.Location = new System.Drawing.Point(177, 3);
            this.m_btnShowTop.Name = "m_btnShowTop";
            this.m_btnShowTop.Size = new System.Drawing.Size(49, 23);
            this.m_extStyle.SetStyleBackColor(this.m_btnShowTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnShowTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnShowTop.TabIndex = 3;
            this.m_btnShowTop.Text = "Back";
            this.m_btnShowTop.UseVisualStyleBackColor = true;
            this.m_btnShowTop.Click += new System.EventHandler(this.m_btnShowTop_Click);
            // 
            // m_btnTop
            // 
            this.m_btnTop.Location = new System.Drawing.Point(111, 3);
            this.m_btnTop.Name = "m_btnTop";
            this.m_btnTop.Size = new System.Drawing.Size(49, 23);
            this.m_extStyle.SetStyleBackColor(this.m_btnTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnTop.TabIndex = 2;
            this.m_btnTop.Text = "Top";
            this.m_btnTop.UseVisualStyleBackColor = true;
            this.m_btnTop.Click += new System.EventHandler(this.m_btnTop_Click);
            // 
            // m_btnLeft
            // 
            this.m_btnLeft.Location = new System.Drawing.Point(56, 3);
            this.m_btnLeft.Name = "m_btnLeft";
            this.m_btnLeft.Size = new System.Drawing.Size(49, 23);
            this.m_extStyle.SetStyleBackColor(this.m_btnLeft, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnLeft, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnLeft.TabIndex = 1;
            this.m_btnLeft.Text = "Left";
            this.m_btnLeft.UseVisualStyleBackColor = true;
            this.m_btnLeft.Click += new System.EventHandler(this.m_btnLeft_Click);
            // 
            // m_btnFront
            // 
            this.m_btnFront.Location = new System.Drawing.Point(3, 3);
            this.m_btnFront.Name = "m_btnFront";
            this.m_btnFront.Size = new System.Drawing.Size(49, 23);
            this.m_extStyle.SetStyleBackColor(this.m_btnFront, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnFront, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnFront.TabIndex = 0;
            this.m_btnFront.Text = "Front";
            this.m_btnFront.UseVisualStyleBackColor = true;
            this.m_btnFront.Click += new System.EventHandler(this.m_btnFront_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(141, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 442);
            this.m_extStyle.SetStyleBackColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitter1.TabIndex = 37;
            this.splitter1.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Location = new System.Drawing.Point(576, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 442);
            this.m_extStyle.SetStyleBackColor(this.splitter2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitter2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitter2.TabIndex = 38;
            this.splitter2.TabStop = false;
            // 
            // m_tabOnRight
            // 
            this.m_tabOnRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_tabOnRight.BoldSelectedPage = true;
            this.m_tabOnRight.ControlBottomOffset = 16;
            this.m_tabOnRight.ControlRightOffset = 16;
            this.m_tabOnRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_tabOnRight.ForeColor = System.Drawing.Color.Black;
            this.m_tabOnRight.IDEPixelArea = false;
            this.m_tabOnRight.Location = new System.Drawing.Point(579, 0);
            this.m_tabOnRight.Name = "m_tabOnRight";
            this.m_tabOnRight.Ombre = true;
            this.m_tabOnRight.PositionTop = true;
            this.m_tabOnRight.SelectedIndex = 0;
            this.m_tabOnRight.SelectedTab = this.tabPage1;
            this.m_tabOnRight.Size = new System.Drawing.Size(198, 442);
            this.m_extStyle.SetStyleBackColor(this.m_tabOnRight, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabOnRight, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabOnRight.TabIndex = 34;
            this.m_tabOnRight.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2});
            this.m_tabOnRight.TextColor = System.Drawing.Color.Black;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_propertyGrid);
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(182, 401);
            this.m_extStyle.SetStyleBackColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage1.TabIndex = 10;
            this.tabPage1.Title = "Properties|20184";
            // 
            // m_propertyGrid
            // 
            this.m_propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_propertyGrid.Location = new System.Drawing.Point(0, 0);
            this.m_propertyGrid.Name = "m_propertyGrid";
            this.m_propertyGrid.Size = new System.Drawing.Size(182, 401);
            this.m_extStyle.SetStyleBackColor(this.m_propertyGrid, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_propertyGrid, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_propertyGrid.TabIndex = 2;
            this.m_propertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.m_propertyGrid_PropertyValueChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.m_panelFormules);
            this.tabPage2.Location = new System.Drawing.Point(0, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(182, 401);
            this.m_extStyle.SetStyleBackColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage2.TabIndex = 11;
            this.tabPage2.Title = "Dynamic|20185";
            // 
            // m_panelFormules
            // 
            this.m_panelFormules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelFormules.Location = new System.Drawing.Point(0, 0);
            this.m_panelFormules.Name = "m_panelFormules";
            this.m_panelFormules.Size = new System.Drawing.Size(182, 401);
            this.m_extStyle.SetStyleBackColor(this.m_panelFormules, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelFormules, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelFormules.TabIndex = 0;
            // 
            // m_chkModeRuntime
            // 
            this.m_chkModeRuntime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_chkModeRuntime.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_chkModeRuntime.AutoSize = true;
            this.m_chkModeRuntime.Location = new System.Drawing.Point(344, 4);
            this.m_chkModeRuntime.Name = "m_chkModeRuntime";
            this.m_chkModeRuntime.Size = new System.Drawing.Size(85, 23);
            this.m_extStyle.SetStyleBackColor(this.m_chkModeRuntime, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkModeRuntime, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkModeRuntime.TabIndex = 3;
            this.m_chkModeRuntime.Text = "Runtime mode";
            this.m_chkModeRuntime.UseVisualStyleBackColor = true;
            this.m_chkModeRuntime.CheckedChanged += new System.EventHandler(this.m_chkModeRuntime_CheckedChanged);
            // 
            // CPanelEditeurComposantPhysique
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_panelCentre);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.m_panelGauche);
            this.Controls.Add(this.m_tabOnRight);
            this.Name = "CPanelEditeurComposantPhysique";
            this.Size = new System.Drawing.Size(777, 442);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelToolBar.ResumeLayout(false);
            this.m_panelToolBar.PerformLayout();
            this.m_panelGauche.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.m_panelCentre.ResumeLayout(false);
            this.m_splitContainerCentral.Panel1.ResumeLayout(false);
            this.m_splitContainerCentral.Panel2.ResumeLayout(false);
            this.m_splitContainerCentral.ResumeLayout(false);
            this.m_containerTop.Panel1.ResumeLayout(false);
            this.m_containerTop.Panel2.ResumeLayout(false);
            this.m_containerTop.ResumeLayout(false);
            this.m_containerBottom.Panel1.ResumeLayout(false);
            this.m_containerBottom.Panel2.ResumeLayout(false);
            this.m_containerBottom.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.m_tabOnRight.ResumeLayout(false);
            this.m_tabOnRight.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CPanelEditionComposantPhysique m_editeurTopLeft;
        private CPanelListe2iComposantPhysique m_listeControles;
        private System.Windows.Forms.PropertyGrid m_propertyGrid;
        private System.Windows.Forms.Button m_btnOpen;
        private System.Windows.Forms.Button m_btnSave;
        private System.Windows.Forms.Panel m_panelToolBar;
        private System.Windows.Forms.RadioButton m_btnModeEditLine;
        private System.Windows.Forms.RadioButton m_btnModeZoom;
        private System.Windows.Forms.RadioButton m_btnModeSelection;
        private sc2i.win32.common.CToolTipTraductible m_tooltipTraductible;
        private sc2i.win32.common.C2iTabControl m_tabOnRight;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private Crownwood.Magic.Controls.TabPage tabPage2;
        private System.Windows.Forms.Panel m_panelGauche;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel m_panelCentre;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel m_panelFormules;
        private sc2i.win32.common.CExtStyle m_extStyle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button m_btnBottom;
        private System.Windows.Forms.Button m_btnRight;
        private System.Windows.Forms.Button m_btnShowTop;
        private System.Windows.Forms.Button m_btnTop;
        private System.Windows.Forms.Button m_btnLeft;
        private System.Windows.Forms.Button m_btnFront;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.SplitContainer m_containerTop;
        private CPanelEditionComposantPhysique m_editeurTopRight;
        private System.Windows.Forms.SplitContainer m_containerBottom;
        private CPanelEditionComposantPhysique m_editeurBottomLeft;
        private System.Windows.Forms.SplitContainer m_splitContainerCentral;
        private timos.data.composantphysique.CVue3D m_vue3D;
        private System.Windows.Forms.CheckBox m_chkModeRuntime;
   
    }
}
