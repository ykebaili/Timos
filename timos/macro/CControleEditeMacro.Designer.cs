namespace timos.macro
{
    partial class CControleEditeMacro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CControleEditeMacro));
            this.label1 = new System.Windows.Forms.Label();
            this.m_panelTop = new System.Windows.Forms.Panel();
            this.m_btnSave = new System.Windows.Forms.PictureBox();
            this.m_btnLoad = new System.Windows.Forms.PictureBox();
            this.m_txtNomMacro = new System.Windows.Forms.TextBox();
            this.m_panelFill = new sc2i.win32.common.C2iPanel(this.components);
            this.m_arbreModifications = new System.Windows.Forms.TreeView();
            this.m_listeImagesObjet = new System.Windows.Forms.ImageList(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_panelEditeModif = new System.Windows.Forms.Panel();
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_tablControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageFormulaire = new Crownwood.Magic.Controls.TabPage();
            this.m_panelFormulaire = new sc2i.formulaire.win32.editor.CPanelEditionFullFormulaire();
            this.m_pageModifs = new Crownwood.Magic.Controls.TabPage();
            this.m_pageVariables = new Crownwood.Magic.Controls.TabPage();
            this.m_wndListeVariables = new sc2i.win32.common.ListViewAutoFilled();
            this.colNomChamp = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_colType = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_btnSupprimerChamp = new sc2i.win32.common.CWndLinkStd();
            this.m_btnModifierChamp = new sc2i.win32.common.CWndLinkStd();
            this.m_btnAjouterChamp = new sc2i.win32.common.CWndLinkStd();
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.m_menuNewVariable = new System.Windows.Forms.ContextMenu();
            this.m_menuVariableSaisie = new System.Windows.Forms.MenuItem();
            this.m_menuNewVariableCalculée = new System.Windows.Forms.MenuItem();
            this.m_menuNewVariableSelection = new System.Windows.Forms.MenuItem();
            this.m_menuNewListeObjets = new System.Windows.Forms.MenuItem();
            this.m_panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnLoad)).BeginInit();
            this.m_panelFill.SuspendLayout();
            this.m_tablControl.SuspendLayout();
            this.m_pageFormulaire.SuspendLayout();
            this.m_pageModifs.SuspendLayout();
            this.m_pageVariables.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.m_extModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 0;
            this.label1.Text = "#Nom de la macro";
            // 
            // m_panelTop
            // 
            this.m_panelTop.Controls.Add(this.m_btnSave);
            this.m_panelTop.Controls.Add(this.m_btnLoad);
            this.m_panelTop.Controls.Add(this.m_txtNomMacro);
            this.m_panelTop.Controls.Add(this.label1);
            this.m_panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelTop.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelTop, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelTop.Name = "m_panelTop";
            this.m_panelTop.Size = new System.Drawing.Size(594, 31);
            this.m_extStyle.SetStyleBackColor(this.m_panelTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelTop.TabIndex = 1;
            // 
            // m_btnSave
            // 
            this.m_btnSave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnSave.Image = ((System.Drawing.Image)(resources.GetObject("m_btnSave.Image")));
            this.m_btnSave.Location = new System.Drawing.Point(538, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnSave, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Size = new System.Drawing.Size(28, 31);
            this.m_btnSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_extStyle.SetStyleBackColor(this.m_btnSave, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSave, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnSave.TabIndex = 5;
            this.m_btnSave.TabStop = false;
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // m_btnLoad
            // 
            this.m_btnLoad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_btnLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnLoad.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnLoad.Image = ((System.Drawing.Image)(resources.GetObject("m_btnLoad.Image")));
            this.m_btnLoad.Location = new System.Drawing.Point(566, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnLoad, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnLoad.Name = "m_btnLoad";
            this.m_btnLoad.Size = new System.Drawing.Size(28, 31);
            this.m_btnLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_extStyle.SetStyleBackColor(this.m_btnLoad, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnLoad, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnLoad.TabIndex = 4;
            this.m_btnLoad.TabStop = false;
            this.m_btnLoad.Click += new System.EventHandler(this.m_btnLoad_Click);
            // 
            // m_txtNomMacro
            // 
            this.m_txtNomMacro.Location = new System.Drawing.Point(126, 3);
            this.m_extModeEdition.SetModeEdition(this.m_txtNomMacro, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtNomMacro.Name = "m_txtNomMacro";
            this.m_txtNomMacro.Size = new System.Drawing.Size(246, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtNomMacro, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtNomMacro, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtNomMacro.TabIndex = 1;
            this.m_txtNomMacro.TextChanged += new System.EventHandler(this.m_txtNomMacro_TextChanged);
            // 
            // m_panelFill
            // 
            this.m_panelFill.Controls.Add(this.m_arbreModifications);
            this.m_panelFill.Controls.Add(this.splitter1);
            this.m_panelFill.Controls.Add(this.m_panelEditeModif);
            this.m_panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelFill.Location = new System.Drawing.Point(0, 0);
            this.m_panelFill.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_panelFill, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelFill.Name = "m_panelFill";
            this.m_panelFill.Size = new System.Drawing.Size(594, 290);
            this.m_extStyle.SetStyleBackColor(this.m_panelFill, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelFill, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelFill.TabIndex = 2;
            // 
            // m_arbreModifications
            // 
            this.m_arbreModifications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_arbreModifications.ImageIndex = 0;
            this.m_arbreModifications.ImageList = this.m_listeImagesObjet;
            this.m_arbreModifications.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_arbreModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_arbreModifications.Name = "m_arbreModifications";
            this.m_arbreModifications.SelectedImageIndex = 0;
            this.m_arbreModifications.Size = new System.Drawing.Size(269, 290);
            this.m_extStyle.SetStyleBackColor(this.m_arbreModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_arbreModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_arbreModifications.TabIndex = 0;
            this.m_arbreModifications.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.m_arbreModifications_BeforeExpand);
            this.m_arbreModifications.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_arbreModifications_AfterSelect);
            // 
            // m_listeImagesObjet
            // 
            this.m_listeImagesObjet.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_listeImagesObjet.ImageStream")));
            this.m_listeImagesObjet.TransparentColor = System.Drawing.Color.Transparent;
            this.m_listeImagesObjet.Images.SetKeyName(0, "PetiteNote.gif");
            this.m_listeImagesObjet.Images.SetKeyName(1, "add.gif");
            this.m_listeImagesObjet.Images.SetKeyName(2, "delete.gif");
            this.m_listeImagesObjet.Images.SetKeyName(3, "edit.gif");
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(269, 0);
            this.m_extModeEdition.SetModeEdition(this.splitter1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 290);
            this.m_extStyle.SetStyleBackColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // m_panelEditeModif
            // 
            this.m_panelEditeModif.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_panelEditeModif.Location = new System.Drawing.Point(272, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelEditeModif, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelEditeModif.Name = "m_panelEditeModif";
            this.m_panelEditeModif.Size = new System.Drawing.Size(322, 290);
            this.m_extStyle.SetStyleBackColor(this.m_panelEditeModif, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEditeModif, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEditeModif.TabIndex = 1;
            // 
            // m_tablControl
            // 
            this.m_tablControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_tablControl.BoldSelectedPage = true;
            this.m_tablControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tablControl.ForeColor = System.Drawing.Color.Black;
            this.m_tablControl.IDEPixelArea = false;
            this.m_tablControl.Location = new System.Drawing.Point(0, 31);
            this.m_extModeEdition.SetModeEdition(this.m_tablControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_tablControl.Name = "m_tablControl";
            this.m_tablControl.Ombre = false;
            this.m_tablControl.PositionTop = true;
            this.m_tablControl.SelectedIndex = 1;
            this.m_tablControl.SelectedTab = this.m_pageVariables;
            this.m_tablControl.Size = new System.Drawing.Size(594, 315);
            this.m_extStyle.SetStyleBackColor(this.m_tablControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tablControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tablControl.TabIndex = 0;
            this.m_tablControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageModifs,
            this.m_pageVariables,
            this.m_pageFormulaire});
            this.m_tablControl.TextColor = System.Drawing.Color.Black;
            this.m_tablControl.SelectionChanged += new System.EventHandler(this.m_tablControl_SelectionChanged);
            // 
            // m_pageFormulaire
            // 
            this.m_pageFormulaire.Controls.Add(this.m_panelFormulaire);
            this.m_pageFormulaire.Location = new System.Drawing.Point(0, 25);
            this.m_extModeEdition.SetModeEdition(this.m_pageFormulaire, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_pageFormulaire.Name = "m_pageFormulaire";
            this.m_pageFormulaire.Selected = false;
            this.m_pageFormulaire.Size = new System.Drawing.Size(594, 290);
            this.m_extStyle.SetStyleBackColor(this.m_pageFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageFormulaire.TabIndex = 12;
            this.m_pageFormulaire.Title = "#Formulaire";
            // 
            // m_panelFormulaire
            // 
            this.m_panelFormulaire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelFormulaire.EntiteEditee = null;
            this.m_panelFormulaire.FournisseurProprietes = null;
            this.m_panelFormulaire.Location = new System.Drawing.Point(0, 0);
            this.m_panelFormulaire.LockEdition = true;
            this.m_extModeEdition.SetModeEdition(this.m_panelFormulaire, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelFormulaire.Name = "m_panelFormulaire";
            this.m_panelFormulaire.Size = new System.Drawing.Size(594, 290);
            this.m_extStyle.SetStyleBackColor(this.m_panelFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelFormulaire.TabIndex = 0;
            this.m_panelFormulaire.TypeEdite = null;
            this.m_panelFormulaire.WndEditee = null;
            // 
            // m_pageModifs
            // 
            this.m_pageModifs.Controls.Add(this.m_panelFill);
            this.m_pageModifs.Location = new System.Drawing.Point(0, 25);
            this.m_extModeEdition.SetModeEdition(this.m_pageModifs, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_pageModifs.Name = "m_pageModifs";
            this.m_pageModifs.Selected = false;
            this.m_pageModifs.Size = new System.Drawing.Size(594, 290);
            this.m_extStyle.SetStyleBackColor(this.m_pageModifs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageModifs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageModifs.TabIndex = 10;
            this.m_pageModifs.Title = "#Modifications";
            // 
            // m_pageVariables
            // 
            this.m_pageVariables.Controls.Add(this.m_wndListeVariables);
            this.m_pageVariables.Controls.Add(this.m_btnSupprimerChamp);
            this.m_pageVariables.Controls.Add(this.m_btnModifierChamp);
            this.m_pageVariables.Controls.Add(this.m_btnAjouterChamp);
            this.m_pageVariables.Location = new System.Drawing.Point(0, 25);
            this.m_extModeEdition.SetModeEdition(this.m_pageVariables, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_pageVariables.Name = "m_pageVariables";
            this.m_pageVariables.Size = new System.Drawing.Size(594, 290);
            this.m_extStyle.SetStyleBackColor(this.m_pageVariables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageVariables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageVariables.TabIndex = 11;
            this.m_pageVariables.Title = "#Variables";
            // 
            // m_wndListeVariables
            // 
            this.m_wndListeVariables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_wndListeVariables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNomChamp,
            this.m_colType});
            this.m_wndListeVariables.EnableCustomisation = true;
            this.m_wndListeVariables.FullRowSelect = true;
            this.m_wndListeVariables.Location = new System.Drawing.Point(5, 27);
            this.m_extModeEdition.SetModeEdition(this.m_wndListeVariables, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_wndListeVariables.Name = "m_wndListeVariables";
            this.m_wndListeVariables.Size = new System.Drawing.Size(586, 260);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeVariables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeVariables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeVariables.TabIndex = 8;
            this.m_wndListeVariables.UseCompatibleStateImageBehavior = false;
            this.m_wndListeVariables.View = System.Windows.Forms.View.Details;
            this.m_wndListeVariables.DoubleClick += new System.EventHandler(this.m_wndListeVariables_DoubleClick);
            this.m_wndListeVariables.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_wndListeVariables_MouseUp);
            // 
            // colNomChamp
            // 
            this.colNomChamp.Field = "Nom";
            this.colNomChamp.PrecisionWidth = 0;
            this.colNomChamp.ProportionnalSize = false;
            this.colNomChamp.Text = "Name|253";
            this.colNomChamp.Visible = true;
            this.colNomChamp.Width = 250;
            // 
            // m_colType
            // 
            this.m_colType.Field = "LibelleType";
            this.m_colType.PrecisionWidth = 0;
            this.m_colType.ProportionnalSize = false;
            this.m_colType.Text = "Type|254";
            this.m_colType.Visible = true;
            this.m_colType.Width = 120;
            // 
            // m_btnSupprimerChamp
            // 
            this.m_btnSupprimerChamp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnSupprimerChamp.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_btnSupprimerChamp.Location = new System.Drawing.Point(165, 3);
            this.m_extModeEdition.SetModeEdition(this.m_btnSupprimerChamp, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnSupprimerChamp.Name = "m_btnSupprimerChamp";
            this.m_btnSupprimerChamp.Size = new System.Drawing.Size(94, 18);
            this.m_extStyle.SetStyleBackColor(this.m_btnSupprimerChamp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSupprimerChamp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnSupprimerChamp.TabIndex = 7;
            this.m_btnSupprimerChamp.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_btnSupprimerChamp.LinkClicked += new System.EventHandler(this.m_btnSupprimerChamp_LinkClicked);
            // 
            // m_btnModifierChamp
            // 
            this.m_btnModifierChamp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnModifierChamp.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_btnModifierChamp.Location = new System.Drawing.Point(85, 3);
            this.m_extModeEdition.SetModeEdition(this.m_btnModifierChamp, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnModifierChamp.Name = "m_btnModifierChamp";
            this.m_btnModifierChamp.Size = new System.Drawing.Size(72, 18);
            this.m_extStyle.SetStyleBackColor(this.m_btnModifierChamp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnModifierChamp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnModifierChamp.TabIndex = 6;
            this.m_btnModifierChamp.TypeLien = sc2i.win32.common.TypeLinkStd.Modification;
            this.m_btnModifierChamp.LinkClicked += new System.EventHandler(this.m_btnModifierChamp_LinkClicked);
            // 
            // m_btnAjouterChamp
            // 
            this.m_btnAjouterChamp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnAjouterChamp.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_btnAjouterChamp.Location = new System.Drawing.Point(5, 3);
            this.m_extModeEdition.SetModeEdition(this.m_btnAjouterChamp, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnAjouterChamp.Name = "m_btnAjouterChamp";
            this.m_btnAjouterChamp.Size = new System.Drawing.Size(72, 18);
            this.m_extStyle.SetStyleBackColor(this.m_btnAjouterChamp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAjouterChamp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAjouterChamp.TabIndex = 5;
            this.m_btnAjouterChamp.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_btnAjouterChamp.LinkClicked += new System.EventHandler(this.m_btnAjouterChamp_LinkClicked);
            // 
            // m_menuNewVariable
            // 
            this.m_menuNewVariable.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.m_menuVariableSaisie,
            this.m_menuNewVariableCalculée,
            this.m_menuNewVariableSelection,
            this.m_menuNewListeObjets});
            // 
            // m_menuVariableSaisie
            // 
            this.m_menuVariableSaisie.Index = 0;
            this.m_menuVariableSaisie.Text = "Entered|30010";
            this.m_menuVariableSaisie.Click += new System.EventHandler(this.m_menuVariableSaisie_Click);
            // 
            // m_menuNewVariableCalculée
            // 
            this.m_menuNewVariableCalculée.Index = 1;
            this.m_menuNewVariableCalculée.Text = "Computed|30011";
            this.m_menuNewVariableCalculée.Click += new System.EventHandler(this.m_menuNewVariableCalculée_Click);
            // 
            // m_menuNewVariableSelection
            // 
            this.m_menuNewVariableSelection.Index = 2;
            this.m_menuNewVariableSelection.Text = "Element selection|30012";
            this.m_menuNewVariableSelection.Click += new System.EventHandler(this.m_menuNewVariableSelection_Click);
            // 
            // m_menuNewListeObjets
            // 
            this.m_menuNewListeObjets.Index = 3;
            this.m_menuNewListeObjets.Text = "Object list|30054";
            this.m_menuNewListeObjets.Visible = false;
            // 
            // CControleEditeMacro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_tablControl);
            this.Controls.Add(this.m_panelTop);
            this.ForeColor = System.Drawing.Color.Black;
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleEditeMacro";
            this.Size = new System.Drawing.Size(594, 346);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelTop.ResumeLayout(false);
            this.m_panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnLoad)).EndInit();
            this.m_panelFill.ResumeLayout(false);
            this.m_tablControl.ResumeLayout(false);
            this.m_tablControl.PerformLayout();
            this.m_pageFormulaire.ResumeLayout(false);
            this.m_pageModifs.ResumeLayout(false);
            this.m_pageVariables.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel m_panelTop;
        private System.Windows.Forms.TextBox m_txtNomMacro;
        private sc2i.win32.common.C2iPanel m_panelFill;
        private System.Windows.Forms.TreeView m_arbreModifications;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel m_panelEditeModif;
        private System.Windows.Forms.ImageList m_listeImagesObjet;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
        private sc2i.win32.common.CExtStyle m_extStyle;
        private sc2i.win32.common.C2iTabControl m_tablControl;
        private Crownwood.Magic.Controls.TabPage m_pageVariables;
        private sc2i.win32.common.ListViewAutoFilled m_wndListeVariables;
        private sc2i.win32.common.ListViewAutoFilledColumn colNomChamp;
        private sc2i.win32.common.ListViewAutoFilledColumn m_colType;
        private sc2i.win32.common.CWndLinkStd m_btnSupprimerChamp;
        private sc2i.win32.common.CWndLinkStd m_btnModifierChamp;
        private sc2i.win32.common.CWndLinkStd m_btnAjouterChamp;
        private Crownwood.Magic.Controls.TabPage m_pageModifs;
        private Crownwood.Magic.Controls.TabPage m_pageFormulaire;
        private sc2i.formulaire.win32.editor.CPanelEditionFullFormulaire m_panelFormulaire;
        private System.Windows.Forms.ContextMenu m_menuNewVariable;
        private System.Windows.Forms.MenuItem m_menuVariableSaisie;
        private System.Windows.Forms.MenuItem m_menuNewVariableCalculée;
        private System.Windows.Forms.MenuItem m_menuNewVariableSelection;
        private System.Windows.Forms.MenuItem m_menuNewListeObjets;
        private System.Windows.Forms.PictureBox m_btnSave;
        private System.Windows.Forms.PictureBox m_btnLoad;
    }
}
