using sc2i.formulaire.win32.editor;
namespace futurocom.win32.sig
{
    partial class CControleEditeMapDatabaseGenerator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CControleEditeMapDatabaseGenerator));
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.m_wndListeItems = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_wndRemoveItemMapGenerator = new sc2i.win32.common.CWndLinkStd();
            this.m_wndAddItemGenerator = new sc2i.win32.common.CWndLinkStd();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_panelEditeGenerator = new System.Windows.Forms.Panel();
            this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
            this.m_wndListeVariables = new sc2i.win32.common.ListViewAutoFilled();
            this.colNomChamp = ((sc2i.win32.common.ListViewAutoFilledColumn)(new sc2i.win32.common.ListViewAutoFilledColumn()));
            this.m_colType = ((sc2i.win32.common.ListViewAutoFilledColumn)(new sc2i.win32.common.ListViewAutoFilledColumn()));
            this.m_btnSupprimerChamp = new sc2i.win32.common.CWndLinkStd();
            this.m_btnModifierChamp = new sc2i.win32.common.CWndLinkStd();
            this.m_btnAjouterChamp = new sc2i.win32.common.CWndLinkStd();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.m_panelFormulaire = new sc2i.formulaire.win32.editor.CPanelEditionFullFormulaire();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.m_menuNewItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.m_selectTypeSource = new sc2i.win32.common.C2iComboSelectDynamicClass(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_menuNewVariable = new System.Windows.Forms.ContextMenu();
            this.m_menuVariableSaisie = new System.Windows.Forms.MenuItem();
            this.m_menuVariableCalculée = new System.Windows.Forms.MenuItem();
            this.m_menuVariableSelection = new System.Windows.Forms.MenuItem();
            this.m_panelCopierColler = new System.Windows.Forms.Panel();
            this.m_btnOpen = new System.Windows.Forms.Button();
            this.m_btnSave = new System.Windows.Forms.Button();
            this.m_btnPaste = new System.Windows.Forms.Button();
            this.m_btnCopy = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.m_panelCopierColler.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_wndListeItems
            // 
            this.m_wndListeItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.m_wndListeItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_wndListeItems.HideSelection = false;
            this.m_wndListeItems.Location = new System.Drawing.Point(0, 43);
            this.m_extModeEdition.SetModeEdition(this.m_wndListeItems, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_wndListeItems.MultiSelect = false;
            this.m_wndListeItems.Name = "m_wndListeItems";
            this.m_wndListeItems.Size = new System.Drawing.Size(200, 310);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeItems, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeItems, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeItems.TabIndex = 0;
            this.m_wndListeItems.UseCompatibleStateImageBehavior = false;
            this.m_wndListeItems.View = System.Windows.Forms.View.Details;
            this.m_wndListeItems.SelectedIndexChanged += new System.EventHandler(this.m_wndListeItems_SelectedIndexChanged);
            this.m_wndListeItems.SizeChanged += new System.EventHandler(this.m_wndListeItems_SizeChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 183;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 22);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 3;
            this.label1.Text = "Map items|2000";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_wndListeItems);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 353);
            this.m_extStyle.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel2.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.m_wndRemoveItemMapGenerator);
            this.panel3.Controls.Add(this.m_wndAddItemGenerator);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 22);
            this.m_extModeEdition.SetModeEdition(this.panel3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 21);
            this.m_extStyle.SetStyleBackColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel3.TabIndex = 4;
            // 
            // m_wndRemoveItemMapGenerator
            // 
            this.m_wndRemoveItemMapGenerator.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_wndRemoveItemMapGenerator.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_wndRemoveItemMapGenerator.CustomImage")));
            this.m_wndRemoveItemMapGenerator.CustomText = "Remove";
            this.m_wndRemoveItemMapGenerator.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_wndRemoveItemMapGenerator.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_wndRemoveItemMapGenerator.Location = new System.Drawing.Point(24, 0);
            this.m_extModeEdition.SetModeEdition(this.m_wndRemoveItemMapGenerator, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_wndRemoveItemMapGenerator.Name = "m_wndRemoveItemMapGenerator";
            this.m_wndRemoveItemMapGenerator.ShortMode = true;
            this.m_wndRemoveItemMapGenerator.Size = new System.Drawing.Size(24, 21);
            this.m_extStyle.SetStyleBackColor(this.m_wndRemoveItemMapGenerator, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndRemoveItemMapGenerator, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndRemoveItemMapGenerator.TabIndex = 1;
            this.m_wndRemoveItemMapGenerator.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_wndRemoveItemMapGenerator.LinkClicked += new System.EventHandler(this.m_wndRemoveItemMapGenerator_LinkClicked);
            // 
            // m_wndAddItemGenerator
            // 
            this.m_wndAddItemGenerator.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_wndAddItemGenerator.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_wndAddItemGenerator.CustomImage")));
            this.m_wndAddItemGenerator.CustomText = "Add";
            this.m_wndAddItemGenerator.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_wndAddItemGenerator.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_wndAddItemGenerator.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_wndAddItemGenerator, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_wndAddItemGenerator.Name = "m_wndAddItemGenerator";
            this.m_wndAddItemGenerator.ShortMode = true;
            this.m_wndAddItemGenerator.Size = new System.Drawing.Size(24, 21);
            this.m_extStyle.SetStyleBackColor(this.m_wndAddItemGenerator, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndAddItemGenerator, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndAddItemGenerator.TabIndex = 0;
            this.m_wndAddItemGenerator.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_wndAddItemGenerator.LinkClicked += new System.EventHandler(this.m_wndAddItemGenerator_LinkClicked);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(200, 0);
            this.m_extModeEdition.SetModeEdition(this.splitter1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 353);
            this.m_extStyle.SetStyleBackColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // m_tabControl
            // 
            this.m_tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_tabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_tabControl.BoldSelectedPage = true;
            this.m_tabControl.ControlBottomOffset = 16;
            this.m_tabControl.ControlRightOffset = 16;
            this.m_tabControl.ForeColor = System.Drawing.Color.Black;
            this.m_tabControl.IDEPixelArea = false;
            this.m_tabControl.Location = new System.Drawing.Point(0, 30);
            this.m_extModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.tabPage1;
            this.m_tabControl.Size = new System.Drawing.Size(766, 400);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 0;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage3,
            this.tabPage2});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.m_extModeEdition.SetModeEdition(this.tabPage1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(750, 359);
            this.m_extStyle.SetStyleBackColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage1.TabIndex = 10;
            this.tabPage1.Title = "Map items|2000";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.m_panelEditeGenerator);
            this.panel1.Controls.Add(this.m_panelCopierColler);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.m_extModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(744, 353);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 7;
            // 
            // m_panelEditeGenerator
            // 
            this.m_panelEditeGenerator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelEditeGenerator.Location = new System.Drawing.Point(203, 33);
            this.m_extModeEdition.SetModeEdition(this.m_panelEditeGenerator, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelEditeGenerator.Name = "m_panelEditeGenerator";
            this.m_panelEditeGenerator.Size = new System.Drawing.Size(541, 320);
            this.m_extStyle.SetStyleBackColor(this.m_panelEditeGenerator, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEditeGenerator, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEditeGenerator.TabIndex = 6;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.m_wndListeVariables);
            this.tabPage3.Controls.Add(this.m_btnSupprimerChamp);
            this.tabPage3.Controls.Add(this.m_btnModifierChamp);
            this.tabPage3.Controls.Add(this.m_btnAjouterChamp);
            this.tabPage3.Location = new System.Drawing.Point(0, 25);
            this.m_extModeEdition.SetModeEdition(this.tabPage3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Selected = false;
            this.tabPage3.Size = new System.Drawing.Size(750, 359);
            this.m_extStyle.SetStyleBackColor(this.tabPage3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage3.TabIndex = 12;
            this.tabPage3.Title = "Filter variables|10403";
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
            this.m_wndListeVariables.Location = new System.Drawing.Point(8, 33);
            this.m_extModeEdition.SetModeEdition(this.m_wndListeVariables, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_wndListeVariables.Name = "m_wndListeVariables";
            this.m_wndListeVariables.Size = new System.Drawing.Size(725, 310);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeVariables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeVariables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeVariables.TabIndex = 8;
            this.m_wndListeVariables.UseCompatibleStateImageBehavior = false;
            this.m_wndListeVariables.View = System.Windows.Forms.View.Details;
            // 
            // colNomChamp
            // 
            this.colNomChamp.Field = "Nom";
            this.colNomChamp.PrecisionWidth = 0D;
            this.colNomChamp.ProportionnalSize = false;
            this.colNomChamp.Text = "Name|253";
            this.colNomChamp.Visible = true;
            this.colNomChamp.Width = 250;
            // 
            // m_colType
            // 
            this.m_colType.Field = "LibelleType";
            this.m_colType.PrecisionWidth = 0D;
            this.m_colType.ProportionnalSize = false;
            this.m_colType.Text = "Type|254";
            this.m_colType.Visible = true;
            this.m_colType.Width = 120;
            // 
            // m_btnSupprimerChamp
            // 
            this.m_btnSupprimerChamp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnSupprimerChamp.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_btnSupprimerChamp.CustomImage")));
            this.m_btnSupprimerChamp.CustomText = "Remove";
            this.m_btnSupprimerChamp.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_btnSupprimerChamp.Location = new System.Drawing.Point(168, 7);
            this.m_extModeEdition.SetModeEdition(this.m_btnSupprimerChamp, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnSupprimerChamp.Name = "m_btnSupprimerChamp";
            this.m_btnSupprimerChamp.ShortMode = false;
            this.m_btnSupprimerChamp.Size = new System.Drawing.Size(104, 22);
            this.m_extStyle.SetStyleBackColor(this.m_btnSupprimerChamp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSupprimerChamp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnSupprimerChamp.TabIndex = 7;
            this.m_btnSupprimerChamp.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_btnSupprimerChamp.LinkClicked += new System.EventHandler(this.m_btnSupprimerChamp_LinkClicked);
            // 
            // m_btnModifierChamp
            // 
            this.m_btnModifierChamp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnModifierChamp.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_btnModifierChamp.CustomImage")));
            this.m_btnModifierChamp.CustomText = "Detail";
            this.m_btnModifierChamp.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_btnModifierChamp.Location = new System.Drawing.Point(88, 7);
            this.m_extModeEdition.SetModeEdition(this.m_btnModifierChamp, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnModifierChamp.Name = "m_btnModifierChamp";
            this.m_btnModifierChamp.ShortMode = false;
            this.m_btnModifierChamp.Size = new System.Drawing.Size(72, 22);
            this.m_extStyle.SetStyleBackColor(this.m_btnModifierChamp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnModifierChamp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnModifierChamp.TabIndex = 6;
            this.m_btnModifierChamp.TypeLien = sc2i.win32.common.TypeLinkStd.Modification;
            this.m_btnModifierChamp.LinkClicked += new System.EventHandler(this.m_btnModifierChamp_LinkClicked);
            // 
            // m_btnAjouterChamp
            // 
            this.m_btnAjouterChamp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnAjouterChamp.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_btnAjouterChamp.CustomImage")));
            this.m_btnAjouterChamp.CustomText = "Add";
            this.m_btnAjouterChamp.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_btnAjouterChamp.Location = new System.Drawing.Point(8, 7);
            this.m_extModeEdition.SetModeEdition(this.m_btnAjouterChamp, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnAjouterChamp.Name = "m_btnAjouterChamp";
            this.m_btnAjouterChamp.ShortMode = false;
            this.m_btnAjouterChamp.Size = new System.Drawing.Size(72, 22);
            this.m_extStyle.SetStyleBackColor(this.m_btnAjouterChamp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAjouterChamp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAjouterChamp.TabIndex = 5;
            this.m_btnAjouterChamp.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_btnAjouterChamp.LinkClicked += new System.EventHandler(this.m_btnAjouterChamp_LinkClicked);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.m_panelFormulaire);
            this.tabPage2.Controls.Add(this.splitter2);
            this.tabPage2.Location = new System.Drawing.Point(0, 25);
            this.m_extModeEdition.SetModeEdition(this.tabPage2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(750, 359);
            this.m_extStyle.SetStyleBackColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage2.TabIndex = 11;
            this.tabPage2.Title = "Filter form|20001";
            // 
            // m_panelFormulaire
            // 
            this.m_panelFormulaire.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelFormulaire.EntiteEditee = null;
            this.m_panelFormulaire.FournisseurProprietes = null;
            this.m_panelFormulaire.Location = new System.Drawing.Point(0, 24);
            this.m_panelFormulaire.LockEdition = true;
            this.m_extModeEdition.SetModeEdition(this.m_panelFormulaire, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelFormulaire.Name = "m_panelFormulaire";
            this.m_panelFormulaire.Size = new System.Drawing.Size(747, 335);
            this.m_extStyle.SetStyleBackColor(this.m_panelFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelFormulaire.TabIndex = 0;
            this.m_panelFormulaire.TypeEdite = null;
            this.m_panelFormulaire.WndEditee = null;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Location = new System.Drawing.Point(747, 0);
            this.m_extModeEdition.SetModeEdition(this.splitter2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 359);
            this.m_extStyle.SetStyleBackColor(this.splitter2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitter2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitter2.TabIndex = 1;
            this.splitter2.TabStop = false;
            // 
            // m_menuNewItem
            // 
            this.m_extModeEdition.SetModeEdition(this.m_menuNewItem, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_menuNewItem.Name = "m_menuNewItem";
            this.m_menuNewItem.Size = new System.Drawing.Size(61, 4);
            this.m_extStyle.SetStyleBackColor(this.m_menuNewItem, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_menuNewItem, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.m_selectTypeSource);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.panel4, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(766, 24);
            this.m_extStyle.SetStyleBackColor(this.panel4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel4.TabIndex = 0;
            // 
            // m_selectTypeSource
            // 
            this.m_selectTypeSource.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_selectTypeSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_selectTypeSource.FormattingEnabled = true;
            this.m_selectTypeSource.IsLink = false;
            this.m_selectTypeSource.Location = new System.Drawing.Point(153, 0);
            this.m_selectTypeSource.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_selectTypeSource, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_selectTypeSource.Name = "m_selectTypeSource";
            this.m_selectTypeSource.Size = new System.Drawing.Size(331, 21);
            this.m_extStyle.SetStyleBackColor(this.m_selectTypeSource, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_selectTypeSource, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectTypeSource.TabIndex = 1;
            this.m_selectTypeSource.TypeSelectionne = null;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 24);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 0;
            this.label2.Text = "Source element type|20012";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_menuNewVariable
            // 
            this.m_menuNewVariable.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.m_menuVariableSaisie,
            this.m_menuVariableCalculée,
            this.m_menuVariableSelection});
            // 
            // m_menuVariableSaisie
            // 
            this.m_menuVariableSaisie.Index = 0;
            this.m_menuVariableSaisie.Text = "Entered|10001";
            this.m_menuVariableSaisie.Click += new System.EventHandler(this.m_menuVariableSaisie_Click);
            // 
            // m_menuVariableCalculée
            // 
            this.m_menuVariableCalculée.Index = 1;
            this.m_menuVariableCalculée.Text = "Computed|10002";
            this.m_menuVariableCalculée.Click += new System.EventHandler(this.m_menuVariableCalculée_Click);
            // 
            // m_menuVariableSelection
            // 
            this.m_menuVariableSelection.Index = 2;
            this.m_menuVariableSelection.Text = "Element selection|10003";
            this.m_menuVariableSelection.Click += new System.EventHandler(this.m_menuVariableSelection_Click);
            // 
            // m_panelCopierColler
            // 
            this.m_panelCopierColler.Controls.Add(this.m_btnCopy);
            this.m_panelCopierColler.Controls.Add(this.m_btnPaste);
            this.m_panelCopierColler.Controls.Add(this.m_btnSave);
            this.m_panelCopierColler.Controls.Add(this.m_btnOpen);
            this.m_panelCopierColler.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelCopierColler.Location = new System.Drawing.Point(203, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelCopierColler, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelCopierColler.Name = "m_panelCopierColler";
            this.m_panelCopierColler.Size = new System.Drawing.Size(541, 33);
            this.m_extStyle.SetStyleBackColor(this.m_panelCopierColler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCopierColler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelCopierColler.TabIndex = 0;
            this.m_panelCopierColler.Visible = false;
            // 
            // m_btnOpen
            // 
            this.m_btnOpen.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("m_btnOpen.Image")));
            this.m_btnOpen.Location = new System.Drawing.Point(508, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnOpen, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnOpen.Name = "m_btnOpen";
            this.m_btnOpen.Size = new System.Drawing.Size(33, 33);
            this.m_extStyle.SetStyleBackColor(this.m_btnOpen, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnOpen, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnOpen.TabIndex = 32;
            this.m_btnOpen.Click += new System.EventHandler(this.m_btnOpen_Click);
            // 
            // m_btnSave
            // 
            this.m_btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnSave.Image = ((System.Drawing.Image)(resources.GetObject("m_btnSave.Image")));
            this.m_btnSave.Location = new System.Drawing.Point(475, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnSave, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Size = new System.Drawing.Size(33, 33);
            this.m_extStyle.SetStyleBackColor(this.m_btnSave, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSave, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnSave.TabIndex = 31;
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // m_btnPaste
            // 
            this.m_btnPaste.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnPaste.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnPaste.Image = ((System.Drawing.Image)(resources.GetObject("m_btnPaste.Image")));
            this.m_btnPaste.Location = new System.Drawing.Point(442, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnPaste, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnPaste.Name = "m_btnPaste";
            this.m_btnPaste.Size = new System.Drawing.Size(33, 33);
            this.m_extStyle.SetStyleBackColor(this.m_btnPaste, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnPaste, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnPaste.TabIndex = 30;
            this.m_btnPaste.Click += new System.EventHandler(this.m_btnPaste_Click);
            // 
            // m_btnCopy
            // 
            this.m_btnCopy.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("m_btnCopy.Image")));
            this.m_btnCopy.Location = new System.Drawing.Point(409, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnCopy, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnCopy.Name = "m_btnCopy";
            this.m_btnCopy.Size = new System.Drawing.Size(33, 33);
            this.m_extStyle.SetStyleBackColor(this.m_btnCopy, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnCopy, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnCopy.TabIndex = 29;
            this.m_btnCopy.Click += new System.EventHandler(this.m_btnCopy_Click);
            // 
            // CControleEditeMapDatabaseGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.panel4);
            this.ForeColor = System.Drawing.Color.Black;
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleEditeMapDatabaseGenerator";
            this.Size = new System.Drawing.Size(766, 430);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondFenetre);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTexteFenetre);
            this.Load += new System.EventHandler(this.CControleEditeMapDatabaseGenerator_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.m_panelCopierColler.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.CExtStyle m_extStyle;
        private System.Windows.Forms.ListView m_wndListeItems;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private sc2i.win32.common.CWndLinkStd m_wndRemoveItemMapGenerator;
        private sc2i.win32.common.CWndLinkStd m_wndAddItemGenerator;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
        private sc2i.win32.common.C2iTabControl m_tabControl;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private Crownwood.Magic.Controls.TabPage tabPage2;
        private CPanelEditionFullFormulaire m_panelFormulaire;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.ContextMenuStrip m_menuNewItem;
        private System.Windows.Forms.Panel m_panelEditeGenerator;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private sc2i.win32.common.C2iComboSelectDynamicClass m_selectTypeSource;
        private Crownwood.Magic.Controls.TabPage tabPage3;
        private sc2i.win32.common.ListViewAutoFilled m_wndListeVariables;
        private sc2i.win32.common.ListViewAutoFilledColumn colNomChamp;
        private sc2i.win32.common.ListViewAutoFilledColumn m_colType;
        private sc2i.win32.common.CWndLinkStd m_btnSupprimerChamp;
        private sc2i.win32.common.CWndLinkStd m_btnModifierChamp;
        private sc2i.win32.common.CWndLinkStd m_btnAjouterChamp;
        private System.Windows.Forms.ContextMenu m_menuNewVariable;
        private System.Windows.Forms.MenuItem m_menuVariableSaisie;
        private System.Windows.Forms.MenuItem m_menuVariableCalculée;
        private System.Windows.Forms.MenuItem m_menuVariableSelection;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel m_panelCopierColler;
        private System.Windows.Forms.Button m_btnCopy;
        private System.Windows.Forms.Button m_btnPaste;
        private System.Windows.Forms.Button m_btnSave;
        private System.Windows.Forms.Button m_btnOpen;
    }
}
