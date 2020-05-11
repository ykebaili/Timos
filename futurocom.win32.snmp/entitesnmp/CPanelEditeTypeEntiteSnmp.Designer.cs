namespace futurocom.win32.snmp.entitesnmp
{
    partial class CPanelEditeTypeEntiteSnmp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPanelEditeTypeEntiteSnmp));
            sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.c2iTextBox1 = new sc2i.win32.common.C2iTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.c2iTabControl1 = new sc2i.win32.common.C2iTabControl(this.components);
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.m_wndListeChamps = new sc2i.win32.common.GlacialList();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_lnkRemoveField = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkAddField = new sc2i.win32.common.CWndLinkStd();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.m_menuFromRequete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_extLinkField = new sc2i.win32.common.CExtLinkField();
            this.m_menuAddField = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.snmpFieldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.standardField20086ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_txtFormuleIndex = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.m_panelFormulaire = new sc2i.formulaire.win32.editor.CPanelEditionFullFormulaire();
            this.label3 = new System.Windows.Forms.Label();
            this.m_cmbModeGestion = new sc2i.win32.common.C2iComboBox();
            this.m_txtFormuleLibelle = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.label4 = new System.Windows.Forms.Label();
            this.m_lnkEditSourceQuery = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.m_lblRequeteSource = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.c2iTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.m_menuAddField.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_lnkEditSourceQuery);
            this.panel1.Controls.Add(this.m_lblRequeteSource);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.m_cmbModeGestion);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.m_txtFormuleLibelle);
            this.panel1.Controls.Add(this.c2iTextBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.panel1, "");
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(699, 95);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 0;
            // 
            // c2iTextBox1
            // 
            this.m_extLinkField.SetLinkField(this.c2iTextBox1, "Libelle");
            this.c2iTextBox1.Location = new System.Drawing.Point(130, 2);
            this.c2iTextBox1.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.c2iTextBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.c2iTextBox1.Name = "c2iTextBox1";
            this.c2iTextBox1.Size = new System.Drawing.Size(339, 20);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox1.TabIndex = 1;
            this.c2iTextBox1.Text = "[Libelle]";
            // 
            // label1
            // 
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.m_extModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 17);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 0;
            this.label1.Text = "Label|20077";
            // 
            // c2iTabControl1
            // 
            this.c2iTabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iTabControl1.BoldSelectedPage = true;
            this.c2iTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c2iTabControl1.ForeColor = System.Drawing.Color.Black;
            this.c2iTabControl1.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.c2iTabControl1, "");
            this.c2iTabControl1.Location = new System.Drawing.Point(0, 95);
            this.m_extModeEdition.SetModeEdition(this.c2iTabControl1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.c2iTabControl1.Name = "c2iTabControl1";
            this.c2iTabControl1.Ombre = false;
            this.c2iTabControl1.PositionTop = true;
            this.c2iTabControl1.SelectedIndex = 0;
            this.c2iTabControl1.SelectedTab = this.tabPage1;
            this.c2iTabControl1.Size = new System.Drawing.Size(699, 312);
            this.m_extStyle.SetStyleBackColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iTabControl1.TabIndex = 1;
            this.c2iTabControl1.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2});
            this.c2iTabControl1.TextColor = System.Drawing.Color.Black;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_wndListeChamps);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel3);
            this.m_extLinkField.SetLinkField(this.tabPage1, "");
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.m_extModeEdition.SetModeEdition(this.tabPage1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(699, 287);
            this.m_extStyle.SetStyleBackColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage1.TabIndex = 10;
            this.tabPage1.Title = "Fields|20078";
            // 
            // m_wndListeChamps
            // 
            this.m_wndListeChamps.AllowColumnResize = true;
            this.m_wndListeChamps.AllowMultiselect = false;
            this.m_wndListeChamps.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.m_wndListeChamps.AlternatingColors = false;
            this.m_wndListeChamps.AutoHeight = true;
            this.m_wndListeChamps.AutoSort = true;
            this.m_wndListeChamps.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.m_wndListeChamps.CanChangeActivationCheckBoxes = false;
            this.m_wndListeChamps.CheckBoxes = false;
            this.m_wndListeChamps.CheckedItems = ((System.Collections.ArrayList)(resources.GetObject("m_wndListeChamps.CheckedItems")));
            glColumn2.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn2.ActiveControlItems")));
            glColumn2.BackColor = System.Drawing.Color.Transparent;
            glColumn2.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn2.ForColor = System.Drawing.Color.Black;
            glColumn2.ImageIndex = -1;
            glColumn2.IsCheckColumn = false;
            glColumn2.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn2.Name = "Column1";
            glColumn2.Propriete = "NomChamp";
            glColumn2.Text = "Field name|20080";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 300;
            this.m_wndListeChamps.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn2});
            this.m_wndListeChamps.ContexteUtilisation = "";
            this.m_wndListeChamps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeChamps.EnableCustomisation = true;
            this.m_wndListeChamps.FocusedItem = null;
            this.m_wndListeChamps.FullRowSelect = true;
            this.m_wndListeChamps.GLGridLines = sc2i.win32.common.GLGridStyles.gridSolid;
            this.m_wndListeChamps.GridColor = System.Drawing.SystemColors.ControlLight;
            this.m_wndListeChamps.HasImages = false;
            this.m_wndListeChamps.HeaderHeight = 22;
            this.m_wndListeChamps.HeaderStyle = sc2i.win32.common.GLHeaderStyles.Normal;
            this.m_wndListeChamps.HeaderTextColor = System.Drawing.Color.Black;
            this.m_wndListeChamps.HeaderTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.m_wndListeChamps.HeaderVisible = true;
            this.m_wndListeChamps.HeaderWordWrap = false;
            this.m_wndListeChamps.HotColumnIndex = -1;
            this.m_wndListeChamps.HotItemIndex = -1;
            this.m_wndListeChamps.HotTracking = false;
            this.m_wndListeChamps.HotTrackingColor = System.Drawing.Color.LightGray;
            this.m_wndListeChamps.ImageList = null;
            this.m_wndListeChamps.ItemHeight = 17;
            this.m_wndListeChamps.ItemWordWrap = false;
            this.m_extLinkField.SetLinkField(this.m_wndListeChamps, "");
            this.m_wndListeChamps.ListeSource = null;
            this.m_wndListeChamps.Location = new System.Drawing.Point(0, 28);
            this.m_wndListeChamps.MaxHeight = 17;
            this.m_extModeEdition.SetModeEdition(this.m_wndListeChamps, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_wndListeChamps.Name = "m_wndListeChamps";
            this.m_wndListeChamps.SelectedTextColor = System.Drawing.Color.White;
            this.m_wndListeChamps.SelectionColor = System.Drawing.Color.DarkBlue;
            this.m_wndListeChamps.ShowBorder = true;
            this.m_wndListeChamps.ShowFocusRect = true;
            this.m_wndListeChamps.Size = new System.Drawing.Size(699, 232);
            this.m_wndListeChamps.SortIndex = 0;
            this.m_extStyle.SetStyleBackColor(this.m_wndListeChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeChamps.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.m_wndListeChamps.TabIndex = 0;
            this.m_wndListeChamps.Text = "glacialList1";
            this.m_wndListeChamps.TrierAuClicSurEnteteColonne = true;
            this.m_wndListeChamps.DoubleClick += new System.EventHandler(this.m_wndListeChamps_DoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_lnkRemoveField);
            this.panel2.Controls.Add(this.m_lnkAddField);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.panel2, "");
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(699, 28);
            this.m_extStyle.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel2.TabIndex = 1;
            // 
            // m_lnkRemoveField
            // 
            this.m_lnkRemoveField.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkRemoveField.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkRemoveField.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkRemoveField, "");
            this.m_lnkRemoveField.Location = new System.Drawing.Point(112, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lnkRemoveField, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkRemoveField.Name = "m_lnkRemoveField";
            this.m_lnkRemoveField.Size = new System.Drawing.Size(112, 28);
            this.m_extStyle.SetStyleBackColor(this.m_lnkRemoveField, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkRemoveField, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkRemoveField.TabIndex = 1;
            this.m_lnkRemoveField.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkRemoveField.LinkClicked += new System.EventHandler(this.m_lnkRemoveField_LinkClicked);
            // 
            // m_lnkAddField
            // 
            this.m_lnkAddField.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAddField.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkAddField.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkAddField, "");
            this.m_lnkAddField.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lnkAddField, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkAddField.Name = "m_lnkAddField";
            this.m_lnkAddField.Size = new System.Drawing.Size(112, 28);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAddField, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAddField, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAddField.TabIndex = 0;
            this.m_lnkAddField.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.m_txtFormuleIndex);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_extLinkField.SetLinkField(this.panel3, "");
            this.panel3.Location = new System.Drawing.Point(0, 260);
            this.m_extModeEdition.SetModeEdition(this.panel3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(699, 27);
            this.m_extStyle.SetStyleBackColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel3.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(241, 27);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 0;
            this.label2.Text = "Default SNMP index formula|20084";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.m_panelFormulaire);
            this.m_extLinkField.SetLinkField(this.tabPage2, "");
            this.tabPage2.Location = new System.Drawing.Point(0, 25);
            this.m_extModeEdition.SetModeEdition(this.tabPage2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(699, 287);
            this.m_extStyle.SetStyleBackColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage2.TabIndex = 11;
            this.tabPage2.Title = "Form|20079";
            // 
            // m_menuFromRequete
            // 
            this.m_extLinkField.SetLinkField(this.m_menuFromRequete, "");
            this.m_extModeEdition.SetModeEdition(this.m_menuFromRequete, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_menuFromRequete.Name = "m_menuFromRequete";
            this.m_menuFromRequete.Size = new System.Drawing.Size(61, 4);
            this.m_extStyle.SetStyleBackColor(this.m_menuFromRequete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_menuFromRequete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_menuAddField
            // 
            this.m_menuAddField.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.snmpFieldToolStripMenuItem,
            this.standardField20086ToolStripMenuItem});
            this.m_extLinkField.SetLinkField(this.m_menuAddField, "");
            this.m_extModeEdition.SetModeEdition(this.m_menuAddField, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_menuAddField.Name = "m_menuAddField";
            this.m_menuAddField.Size = new System.Drawing.Size(187, 48);
            this.m_extStyle.SetStyleBackColor(this.m_menuAddField, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_menuAddField, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // snmpFieldToolStripMenuItem
            // 
            this.snmpFieldToolStripMenuItem.Name = "snmpFieldToolStripMenuItem";
            this.snmpFieldToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.snmpFieldToolStripMenuItem.Text = "Snmp field|20085";
            this.snmpFieldToolStripMenuItem.Click += new System.EventHandler(this.snmpFieldToolStripMenuItem_Click);
            // 
            // standardField20086ToolStripMenuItem
            // 
            this.standardField20086ToolStripMenuItem.Name = "standardField20086ToolStripMenuItem";
            this.standardField20086ToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.standardField20086ToolStripMenuItem.Text = "Standard field|20086";
            this.standardField20086ToolStripMenuItem.Click += new System.EventHandler(this.standardField20086ToolStripMenuItem_Click);
            // 
            // m_txtFormuleIndex
            // 
            this.m_txtFormuleIndex.AllowGraphic = true;
            this.m_txtFormuleIndex.AllowSaisieTexte = true;
            this.m_txtFormuleIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtFormuleIndex.Formule = null;
            this.m_extLinkField.SetLinkField(this.m_txtFormuleIndex, "");
            this.m_txtFormuleIndex.Location = new System.Drawing.Point(241, 0);
            this.m_txtFormuleIndex.LockEdition = false;
            this.m_txtFormuleIndex.LockZoneTexte = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtFormuleIndex, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtFormuleIndex.Name = "m_txtFormuleIndex";
            this.m_txtFormuleIndex.Size = new System.Drawing.Size(458, 27);
            this.m_extStyle.SetStyleBackColor(this.m_txtFormuleIndex, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFormuleIndex, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleIndex.TabIndex = 1;
            // 
            // m_panelFormulaire
            // 
            this.m_panelFormulaire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelFormulaire.EntiteEditee = null;
            this.m_panelFormulaire.FournisseurProprietes = null;
            this.m_extLinkField.SetLinkField(this.m_panelFormulaire, "");
            this.m_panelFormulaire.Location = new System.Drawing.Point(0, 0);
            this.m_panelFormulaire.LockEdition = true;
            this.m_extModeEdition.SetModeEdition(this.m_panelFormulaire, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelFormulaire.Name = "m_panelFormulaire";
            this.m_panelFormulaire.Size = new System.Drawing.Size(699, 287);
            this.m_extStyle.SetStyleBackColor(this.m_panelFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelFormulaire.TabIndex = 0;
            this.m_panelFormulaire.TypeEdite = null;
            this.m_panelFormulaire.WndEditee = null;
            // 
            // label3
            // 
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(3, 28);
            this.m_extModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 17);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 2;
            this.label3.Text = "Label|20077";
            // 
            // m_cmbModeGestion
            // 
            this.m_cmbModeGestion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbModeGestion.FormattingEnabled = true;
            this.m_cmbModeGestion.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbModeGestion, "");
            this.m_cmbModeGestion.Location = new System.Drawing.Point(130, 24);
            this.m_cmbModeGestion.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_cmbModeGestion, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbModeGestion.Name = "m_cmbModeGestion";
            this.m_cmbModeGestion.Size = new System.Drawing.Size(189, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbModeGestion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbModeGestion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbModeGestion.TabIndex = 3;
            // 
            // m_txtFormuleLibelle
            // 
            this.m_txtFormuleLibelle.AllowGraphic = true;
            this.m_txtFormuleLibelle.AllowSaisieTexte = true;
            this.m_txtFormuleLibelle.Formule = null;
            this.m_extLinkField.SetLinkField(this.m_txtFormuleLibelle, "");
            this.m_txtFormuleLibelle.Location = new System.Drawing.Point(130, 47);
            this.m_txtFormuleLibelle.LockEdition = false;
            this.m_txtFormuleLibelle.LockZoneTexte = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtFormuleLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtFormuleLibelle.Name = "m_txtFormuleLibelle";
            this.m_txtFormuleLibelle.Size = new System.Drawing.Size(566, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtFormuleLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFormuleLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleLibelle.TabIndex = 1;
            // 
            // label4
            // 
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.label4.Location = new System.Drawing.Point(3, 48);
            this.m_extModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 17);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 0;
            this.label4.Text = "Label formula|20097";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lnkEditSourceQuery
            // 
            this.m_lnkEditSourceQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_lnkEditSourceQuery, "");
            this.m_lnkEditSourceQuery.Location = new System.Drawing.Point(558, 70);
            this.m_extModeEdition.SetModeEdition(this.m_lnkEditSourceQuery, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkEditSourceQuery.Name = "m_lnkEditSourceQuery";
            this.m_lnkEditSourceQuery.Size = new System.Drawing.Size(138, 14);
            this.m_extStyle.SetStyleBackColor(this.m_lnkEditSourceQuery, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkEditSourceQuery, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkEditSourceQuery.TabIndex = 3;
            this.m_lnkEditSourceQuery.TabStop = true;
            this.m_lnkEditSourceQuery.Text = "Edit source query|20098";
            this.m_lnkEditSourceQuery.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lnkEditSourceQuery.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkEditSourceQuery_LinkClicked);
            // 
            // label5
            // 
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.label5.Location = new System.Drawing.Point(3, 67);
            this.m_extModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 17);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 4;
            this.label5.Text = "Source query|20099";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblRequeteSource
            // 
            this.m_lblRequeteSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblRequeteSource.BackColor = System.Drawing.SystemColors.Control;
            this.m_lblRequeteSource.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_extLinkField.SetLinkField(this.m_lblRequeteSource, "");
            this.m_lblRequeteSource.Location = new System.Drawing.Point(130, 69);
            this.m_extModeEdition.SetModeEdition(this.m_lblRequeteSource, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblRequeteSource.Name = "m_lblRequeteSource";
            this.m_lblRequeteSource.Size = new System.Drawing.Size(422, 15);
            this.m_extStyle.SetStyleBackColor(this.m_lblRequeteSource, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblRequeteSource, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblRequeteSource.TabIndex = 5;
            this.m_lblRequeteSource.Click += new System.EventHandler(this.m_lblRequeteSource_Click);
            // 
            // CPanelEditeTypeEntiteSnmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.c2iTabControl1);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CPanelEditeTypeEntiteSnmp";
            this.Size = new System.Drawing.Size(699, 407);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.Load += new System.EventHandler(this.CPanelEditeTypeEntiteSnmp_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.c2iTabControl1.ResumeLayout(false);
            this.c2iTabControl1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.m_menuAddField.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.CExtStyle m_extStyle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private sc2i.win32.common.C2iTextBox c2iTextBox1;
        private sc2i.win32.common.CExtLinkField m_extLinkField;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
        private sc2i.win32.common.C2iTabControl c2iTabControl1;
        private Crownwood.Magic.Controls.TabPage tabPage2;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private sc2i.win32.common.GlacialList m_wndListeChamps;
        private System.Windows.Forms.Panel panel2;
        private sc2i.win32.common.CWndLinkStd m_lnkRemoveField;
        private sc2i.win32.common.CWndLinkStd m_lnkAddField;
        private sc2i.formulaire.win32.editor.CPanelEditionFullFormulaire m_panelFormulaire;
        private System.Windows.Forms.ContextMenuStrip m_menuFromRequete;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleIndex;
        private System.Windows.Forms.ContextMenuStrip m_menuAddField;
        private System.Windows.Forms.ToolStripMenuItem snmpFieldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem standardField20086ToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private sc2i.win32.common.C2iComboBox m_cmbModeGestion;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleLibelle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel m_lnkEditSourceQuery;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label m_lblRequeteSource;
    }
}
