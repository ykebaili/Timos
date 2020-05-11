namespace futurocom.win32.snmp.alarmes
{
    partial class CControleEditeBaseSupervision
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CControleEditeBaseSupervision));
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn3 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn4 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn5 = new sc2i.win32.common.GLColumn();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.tabPage4 = new Crownwood.Magic.Controls.TabPage();
            this.m_wndListeTypesEntites = new sc2i.win32.common.GlacialList();
            this.panel4 = new System.Windows.Forms.Panel();
            this.m_lnkRemoveTypeEntite = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkAddTypeEntite = new sc2i.win32.common.CWndLinkStd();
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.m_browser = new futurocom.win32.snmp.CWndMibBrowser();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_lnkCreateHandler = new System.Windows.Forms.LinkLabel();
            this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
            this.m_wndListeQueries = new sc2i.win32.common.GlacialList();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_lnkRemoveQuery = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkAddQuery = new sc2i.win32.common.CWndLinkStd();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.m_wndListeHandlers = new sc2i.win32.common.GlacialList();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_wndRemoveHandler = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkAddHandler = new sc2i.win32.common.CWndLinkStd();
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.button1 = new System.Windows.Forms.Button();
            this.m_tabControl.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_tabControl
            // 
            this.m_tabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_tabControl.BoldSelectedPage = true;
            this.m_tabControl.ControlBottomOffset = 16;
            this.m_tabControl.ControlRightOffset = 16;
            this.m_tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tabControl.ForeColor = System.Drawing.Color.Black;
            this.m_tabControl.IDEPixelArea = false;
            this.m_tabControl.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 3;
            this.m_tabControl.SelectedTab = this.tabPage4;
            this.m_tabControl.Size = new System.Drawing.Size(629, 424);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 0;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage3,
            this.tabPage2,
            this.tabPage4});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.m_wndListeTypesEntites);
            this.tabPage4.Controls.Add(this.panel4);
            this.tabPage4.Location = new System.Drawing.Point(0, 25);
            this.m_extModeEdition.SetModeEdition(this.tabPage4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(613, 383);
            this.m_extStyle.SetStyleBackColor(this.tabPage4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage4.TabIndex = 13;
            this.tabPage4.Title = "Entity types";
            // 
            // m_wndListeTypesEntites
            // 
            this.m_wndListeTypesEntites.AllowColumnResize = true;
            this.m_wndListeTypesEntites.AllowMultiselect = false;
            this.m_wndListeTypesEntites.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.m_wndListeTypesEntites.AlternatingColors = false;
            this.m_wndListeTypesEntites.AutoHeight = true;
            this.m_wndListeTypesEntites.AutoSort = true;
            this.m_wndListeTypesEntites.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.m_wndListeTypesEntites.CanChangeActivationCheckBoxes = false;
            this.m_wndListeTypesEntites.CheckBoxes = false;
            this.m_wndListeTypesEntites.CheckedItems = ((System.Collections.ArrayList)(resources.GetObject("m_wndListeTypesEntites.CheckedItems")));
            glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "Column1";
            glColumn1.Propriete = "Libelle";
            glColumn1.Text = "Label|20077";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 150;
            this.m_wndListeTypesEntites.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1});
            this.m_wndListeTypesEntites.ContexteUtilisation = "";
            this.m_wndListeTypesEntites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeTypesEntites.EnableCustomisation = true;
            this.m_wndListeTypesEntites.FocusedItem = null;
            this.m_wndListeTypesEntites.FullRowSelect = true;
            this.m_wndListeTypesEntites.GLGridLines = sc2i.win32.common.GLGridStyles.gridSolid;
            this.m_wndListeTypesEntites.GridColor = System.Drawing.SystemColors.ControlLight;
            this.m_wndListeTypesEntites.HasImages = false;
            this.m_wndListeTypesEntites.HeaderHeight = 22;
            this.m_wndListeTypesEntites.HeaderStyle = sc2i.win32.common.GLHeaderStyles.Normal;
            this.m_wndListeTypesEntites.HeaderTextColor = System.Drawing.Color.Black;
            this.m_wndListeTypesEntites.HeaderTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.m_wndListeTypesEntites.HeaderVisible = true;
            this.m_wndListeTypesEntites.HeaderWordWrap = false;
            this.m_wndListeTypesEntites.HotColumnIndex = -1;
            this.m_wndListeTypesEntites.HotItemIndex = -1;
            this.m_wndListeTypesEntites.HotTracking = false;
            this.m_wndListeTypesEntites.HotTrackingColor = System.Drawing.Color.LightGray;
            this.m_wndListeTypesEntites.ImageList = null;
            this.m_wndListeTypesEntites.ItemHeight = 17;
            this.m_wndListeTypesEntites.ItemWordWrap = false;
            this.m_wndListeTypesEntites.ListeSource = null;
            this.m_wndListeTypesEntites.Location = new System.Drawing.Point(0, 24);
            this.m_wndListeTypesEntites.MaxHeight = 17;
            this.m_extModeEdition.SetModeEdition(this.m_wndListeTypesEntites, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_wndListeTypesEntites.Name = "m_wndListeTypesEntites";
            this.m_wndListeTypesEntites.SelectedTextColor = System.Drawing.Color.White;
            this.m_wndListeTypesEntites.SelectionColor = System.Drawing.Color.DarkBlue;
            this.m_wndListeTypesEntites.ShowBorder = true;
            this.m_wndListeTypesEntites.ShowFocusRect = true;
            this.m_wndListeTypesEntites.Size = new System.Drawing.Size(613, 359);
            this.m_wndListeTypesEntites.SortIndex = 0;
            this.m_extStyle.SetStyleBackColor(this.m_wndListeTypesEntites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeTypesEntites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeTypesEntites.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.m_wndListeTypesEntites.TabIndex = 2;
            this.m_wndListeTypesEntites.Text = "glacialList1";
            this.m_wndListeTypesEntites.TrierAuClicSurEnteteColonne = true;
            this.m_wndListeTypesEntites.DoubleClick += new System.EventHandler(this.m_wndListeTypesEntites_DoubleClick);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.m_lnkRemoveTypeEntite);
            this.panel4.Controls.Add(this.m_lnkAddTypeEntite);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.panel4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(613, 24);
            this.m_extStyle.SetStyleBackColor(this.panel4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel4.TabIndex = 3;
            // 
            // m_lnkRemoveTypeEntite
            // 
            this.m_lnkRemoveTypeEntite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkRemoveTypeEntite.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkRemoveTypeEntite.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkRemoveTypeEntite.Location = new System.Drawing.Point(112, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lnkRemoveTypeEntite, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lnkRemoveTypeEntite.Name = "m_lnkRemoveTypeEntite";
            this.m_lnkRemoveTypeEntite.Size = new System.Drawing.Size(112, 24);
            this.m_extStyle.SetStyleBackColor(this.m_lnkRemoveTypeEntite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkRemoveTypeEntite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkRemoveTypeEntite.TabIndex = 1;
            this.m_lnkRemoveTypeEntite.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkRemoveTypeEntite.LinkClicked += new System.EventHandler(this.m_wndRemoveTypeEntite_LinkClicked);
            // 
            // m_lnkAddTypeEntite
            // 
            this.m_lnkAddTypeEntite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAddTypeEntite.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkAddTypeEntite.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkAddTypeEntite.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lnkAddTypeEntite, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lnkAddTypeEntite.Name = "m_lnkAddTypeEntite";
            this.m_lnkAddTypeEntite.Size = new System.Drawing.Size(112, 24);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAddTypeEntite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAddTypeEntite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAddTypeEntite.TabIndex = 0;
            this.m_lnkAddTypeEntite.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAddTypeEntite.LinkClicked += new System.EventHandler(this.m_lnkAddTypeEntite_LinkClicked);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_browser);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.m_extModeEdition.SetModeEdition(this.tabPage1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Selected = false;
            this.tabPage1.Size = new System.Drawing.Size(613, 383);
            this.m_extStyle.SetStyleBackColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage1.TabIndex = 10;
            this.tabPage1.Title = "Mib|20045";
            // 
            // m_browser
            // 
            this.m_browser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_browser.Location = new System.Drawing.Point(0, 29);
            this.m_extModeEdition.SetModeEdition(this.m_browser, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_browser.Name = "m_browser";
            this.m_browser.Size = new System.Drawing.Size(613, 354);
            this.m_extStyle.SetStyleBackColor(this.m_browser, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_browser, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_browser.TabIndex = 0;
            this.m_browser.SelectedDefinitionChanged += new System.EventHandler(this.m_browser_SelectedDefinitionChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_lnkCreateHandler);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(613, 29);
            this.m_extStyle.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel2.TabIndex = 1;
            // 
            // m_lnkCreateHandler
            // 
            this.m_lnkCreateHandler.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkCreateHandler.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lnkCreateHandler, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lnkCreateHandler.Name = "m_lnkCreateHandler";
            this.m_lnkCreateHandler.Size = new System.Drawing.Size(165, 29);
            this.m_extStyle.SetStyleBackColor(this.m_lnkCreateHandler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkCreateHandler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkCreateHandler.TabIndex = 0;
            this.m_lnkCreateHandler.TabStop = true;
            this.m_lnkCreateHandler.Text = "Create handler|20050";
            this.m_lnkCreateHandler.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lnkCreateHandler.Visible = false;
            this.m_lnkCreateHandler.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkCreateHandler_LinkClicked);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.m_wndListeQueries);
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Location = new System.Drawing.Point(0, 25);
            this.m_extModeEdition.SetModeEdition(this.tabPage3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Selected = false;
            this.tabPage3.Size = new System.Drawing.Size(613, 383);
            this.m_extStyle.SetStyleBackColor(this.tabPage3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage3.TabIndex = 12;
            this.tabPage3.Title = "Queries|20068";
            // 
            // m_wndListeQueries
            // 
            this.m_wndListeQueries.AllowColumnResize = true;
            this.m_wndListeQueries.AllowMultiselect = false;
            this.m_wndListeQueries.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.m_wndListeQueries.AlternatingColors = false;
            this.m_wndListeQueries.AutoHeight = true;
            this.m_wndListeQueries.AutoSort = true;
            this.m_wndListeQueries.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.m_wndListeQueries.CanChangeActivationCheckBoxes = false;
            this.m_wndListeQueries.CheckBoxes = false;
            this.m_wndListeQueries.CheckedItems = ((System.Collections.ArrayList)(resources.GetObject("m_wndListeQueries.CheckedItems")));
            glColumn2.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn2.ActiveControlItems")));
            glColumn2.BackColor = System.Drawing.Color.Transparent;
            glColumn2.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn2.ForColor = System.Drawing.Color.Black;
            glColumn2.ImageIndex = -1;
            glColumn2.IsCheckColumn = false;
            glColumn2.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn2.Name = "Column1";
            glColumn2.Propriete = "Libelle";
            glColumn2.Text = "Handler name|20047";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 250;
            this.m_wndListeQueries.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn2});
            this.m_wndListeQueries.ContexteUtilisation = "";
            this.m_wndListeQueries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeQueries.EnableCustomisation = true;
            this.m_wndListeQueries.FocusedItem = null;
            this.m_wndListeQueries.FullRowSelect = true;
            this.m_wndListeQueries.GLGridLines = sc2i.win32.common.GLGridStyles.gridSolid;
            this.m_wndListeQueries.GridColor = System.Drawing.SystemColors.ControlLight;
            this.m_wndListeQueries.HasImages = false;
            this.m_wndListeQueries.HeaderHeight = 22;
            this.m_wndListeQueries.HeaderStyle = sc2i.win32.common.GLHeaderStyles.Normal;
            this.m_wndListeQueries.HeaderTextColor = System.Drawing.Color.Black;
            this.m_wndListeQueries.HeaderTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.m_wndListeQueries.HeaderVisible = true;
            this.m_wndListeQueries.HeaderWordWrap = false;
            this.m_wndListeQueries.HotColumnIndex = -1;
            this.m_wndListeQueries.HotItemIndex = -1;
            this.m_wndListeQueries.HotTracking = false;
            this.m_wndListeQueries.HotTrackingColor = System.Drawing.Color.LightGray;
            this.m_wndListeQueries.ImageList = null;
            this.m_wndListeQueries.ItemHeight = 17;
            this.m_wndListeQueries.ItemWordWrap = false;
            this.m_wndListeQueries.ListeSource = null;
            this.m_wndListeQueries.Location = new System.Drawing.Point(0, 24);
            this.m_wndListeQueries.MaxHeight = 17;
            this.m_extModeEdition.SetModeEdition(this.m_wndListeQueries, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_wndListeQueries.Name = "m_wndListeQueries";
            this.m_wndListeQueries.SelectedTextColor = System.Drawing.Color.White;
            this.m_wndListeQueries.SelectionColor = System.Drawing.Color.DarkBlue;
            this.m_wndListeQueries.ShowBorder = true;
            this.m_wndListeQueries.ShowFocusRect = true;
            this.m_wndListeQueries.Size = new System.Drawing.Size(613, 359);
            this.m_wndListeQueries.SortIndex = 0;
            this.m_extStyle.SetStyleBackColor(this.m_wndListeQueries, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeQueries, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeQueries.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.m_wndListeQueries.TabIndex = 2;
            this.m_wndListeQueries.Text = "glacialList1";
            this.m_wndListeQueries.TrierAuClicSurEnteteColonne = true;
            this.m_wndListeQueries.DoubleClick += new System.EventHandler(this.m_wndListeQueries_DoubleClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.m_lnkRemoveQuery);
            this.panel3.Controls.Add(this.m_lnkAddQuery);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.panel3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(613, 24);
            this.m_extStyle.SetStyleBackColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel3.TabIndex = 3;
            // 
            // m_lnkRemoveQuery
            // 
            this.m_lnkRemoveQuery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkRemoveQuery.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkRemoveQuery.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkRemoveQuery.Location = new System.Drawing.Point(112, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lnkRemoveQuery, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lnkRemoveQuery.Name = "m_lnkRemoveQuery";
            this.m_lnkRemoveQuery.Size = new System.Drawing.Size(112, 24);
            this.m_extStyle.SetStyleBackColor(this.m_lnkRemoveQuery, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkRemoveQuery, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkRemoveQuery.TabIndex = 1;
            this.m_lnkRemoveQuery.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkRemoveQuery.LinkClicked += new System.EventHandler(this.m_lnkRemoveQuery_LinkClicked);
            // 
            // m_lnkAddQuery
            // 
            this.m_lnkAddQuery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAddQuery.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkAddQuery.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkAddQuery.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lnkAddQuery, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lnkAddQuery.Name = "m_lnkAddQuery";
            this.m_lnkAddQuery.Size = new System.Drawing.Size(112, 24);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAddQuery, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAddQuery, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAddQuery.TabIndex = 0;
            this.m_lnkAddQuery.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAddQuery.LinkClicked += new System.EventHandler(this.m_lnkAddQuery_LinkClicked);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.m_wndListeHandlers);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(0, 25);
            this.m_extModeEdition.SetModeEdition(this.tabPage2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(613, 383);
            this.m_extStyle.SetStyleBackColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage2.TabIndex = 11;
            this.tabPage2.Title = "Handlers|20046";
            // 
            // m_wndListeHandlers
            // 
            this.m_wndListeHandlers.AllowColumnResize = true;
            this.m_wndListeHandlers.AllowMultiselect = false;
            this.m_wndListeHandlers.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.m_wndListeHandlers.AlternatingColors = false;
            this.m_wndListeHandlers.AutoHeight = true;
            this.m_wndListeHandlers.AutoSort = true;
            this.m_wndListeHandlers.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.m_wndListeHandlers.CanChangeActivationCheckBoxes = false;
            this.m_wndListeHandlers.CheckBoxes = false;
            this.m_wndListeHandlers.CheckedItems = ((System.Collections.ArrayList)(resources.GetObject("m_wndListeHandlers.CheckedItems")));
            glColumn3.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn3.ActiveControlItems")));
            glColumn3.BackColor = System.Drawing.Color.Transparent;
            glColumn3.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn3.ForColor = System.Drawing.Color.Black;
            glColumn3.ImageIndex = -1;
            glColumn3.IsCheckColumn = false;
            glColumn3.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn3.Name = "Column1";
            glColumn3.Propriete = "Label";
            glColumn3.Text = "Handler name|20047";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn3.Width = 150;
            glColumn4.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn4.ActiveControlItems")));
            glColumn4.BackColor = System.Drawing.Color.Transparent;
            glColumn4.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn4.ForColor = System.Drawing.Color.Black;
            glColumn4.ImageIndex = -1;
            glColumn4.IsCheckColumn = false;
            glColumn4.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn4.Name = "Column2";
            glColumn4.Propriete = "EntrepriseRequestedValue";
            glColumn4.Text = "Entreprise|20048";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn4.Width = 150;
            glColumn5.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn5.ActiveControlItems")));
            glColumn5.BackColor = System.Drawing.Color.Transparent;
            glColumn5.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn5.ForColor = System.Drawing.Color.Black;
            glColumn5.ImageIndex = -1;
            glColumn5.IsCheckColumn = false;
            glColumn5.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn5.Name = "Column3";
            glColumn5.Propriete = "SpecificRequestedValue";
            glColumn5.Text = "Specific|20049";
            glColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn5.Width = 100;
            this.m_wndListeHandlers.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn3,
            glColumn4,
            glColumn5});
            this.m_wndListeHandlers.ContexteUtilisation = "";
            this.m_wndListeHandlers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeHandlers.EnableCustomisation = true;
            this.m_wndListeHandlers.FocusedItem = null;
            this.m_wndListeHandlers.FullRowSelect = true;
            this.m_wndListeHandlers.GLGridLines = sc2i.win32.common.GLGridStyles.gridSolid;
            this.m_wndListeHandlers.GridColor = System.Drawing.SystemColors.ControlLight;
            this.m_wndListeHandlers.HasImages = false;
            this.m_wndListeHandlers.HeaderHeight = 22;
            this.m_wndListeHandlers.HeaderStyle = sc2i.win32.common.GLHeaderStyles.Normal;
            this.m_wndListeHandlers.HeaderTextColor = System.Drawing.Color.Black;
            this.m_wndListeHandlers.HeaderTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.m_wndListeHandlers.HeaderVisible = true;
            this.m_wndListeHandlers.HeaderWordWrap = false;
            this.m_wndListeHandlers.HotColumnIndex = -1;
            this.m_wndListeHandlers.HotItemIndex = -1;
            this.m_wndListeHandlers.HotTracking = false;
            this.m_wndListeHandlers.HotTrackingColor = System.Drawing.Color.LightGray;
            this.m_wndListeHandlers.ImageList = null;
            this.m_wndListeHandlers.ItemHeight = 17;
            this.m_wndListeHandlers.ItemWordWrap = false;
            this.m_wndListeHandlers.ListeSource = null;
            this.m_wndListeHandlers.Location = new System.Drawing.Point(0, 24);
            this.m_wndListeHandlers.MaxHeight = 17;
            this.m_extModeEdition.SetModeEdition(this.m_wndListeHandlers, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_wndListeHandlers.Name = "m_wndListeHandlers";
            this.m_wndListeHandlers.SelectedTextColor = System.Drawing.Color.White;
            this.m_wndListeHandlers.SelectionColor = System.Drawing.Color.DarkBlue;
            this.m_wndListeHandlers.ShowBorder = true;
            this.m_wndListeHandlers.ShowFocusRect = true;
            this.m_wndListeHandlers.Size = new System.Drawing.Size(613, 359);
            this.m_wndListeHandlers.SortIndex = 0;
            this.m_extStyle.SetStyleBackColor(this.m_wndListeHandlers, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeHandlers, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeHandlers.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.m_wndListeHandlers.TabIndex = 0;
            this.m_wndListeHandlers.Text = "glacialList1";
            this.m_wndListeHandlers.TrierAuClicSurEnteteColonne = true;
            this.m_wndListeHandlers.DoubleClick += new System.EventHandler(this.m_wndListeHandlers_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_wndRemoveHandler);
            this.panel1.Controls.Add(this.m_lnkAddHandler);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(613, 24);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 1;
            // 
            // m_wndRemoveHandler
            // 
            this.m_wndRemoveHandler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_wndRemoveHandler.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_wndRemoveHandler.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_wndRemoveHandler.Location = new System.Drawing.Point(112, 0);
            this.m_extModeEdition.SetModeEdition(this.m_wndRemoveHandler, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_wndRemoveHandler.Name = "m_wndRemoveHandler";
            this.m_wndRemoveHandler.Size = new System.Drawing.Size(112, 24);
            this.m_extStyle.SetStyleBackColor(this.m_wndRemoveHandler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndRemoveHandler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndRemoveHandler.TabIndex = 1;
            this.m_wndRemoveHandler.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_wndRemoveHandler.LinkClicked += new System.EventHandler(this.m_wndRemoveHandler_LinkClicked);
            // 
            // m_lnkAddHandler
            // 
            this.m_lnkAddHandler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAddHandler.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkAddHandler.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkAddHandler.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lnkAddHandler, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lnkAddHandler.Name = "m_lnkAddHandler";
            this.m_lnkAddHandler.Size = new System.Drawing.Size(112, 24);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAddHandler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAddHandler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAddHandler.TabIndex = 0;
            this.m_lnkAddHandler.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAddHandler.LinkClicked += new System.EventHandler(this.m_lnkAddHandler_LinkClicked);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(328, 3);
            this.m_extModeEdition.SetModeEdition(this.button1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.m_extStyle.SetStyleBackColor(this.button1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.button1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.button1.TabIndex = 2;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CControleEditeBaseSupervision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_tabControl);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleEditeBaseSupervision";
            this.Size = new System.Drawing.Size(629, 424);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.C2iTabControl m_tabControl;
        private sc2i.win32.common.CExtStyle m_extStyle;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private Crownwood.Magic.Controls.TabPage tabPage2;
        private CWndMibBrowser m_browser;
        private sc2i.win32.common.GlacialList m_wndListeHandlers;
        private System.Windows.Forms.Panel panel1;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel m_lnkCreateHandler;
        private sc2i.win32.common.CWndLinkStd m_wndRemoveHandler;
        private sc2i.win32.common.CWndLinkStd m_lnkAddHandler;
        private Crownwood.Magic.Controls.TabPage tabPage3;
        private sc2i.win32.common.GlacialList m_wndListeQueries;
        private System.Windows.Forms.Panel panel3;
        private sc2i.win32.common.CWndLinkStd m_lnkRemoveQuery;
        private sc2i.win32.common.CWndLinkStd m_lnkAddQuery;
        private Crownwood.Magic.Controls.TabPage tabPage4;
        private sc2i.win32.common.GlacialList m_wndListeTypesEntites;
        private System.Windows.Forms.Panel panel4;
        private sc2i.win32.common.CWndLinkStd m_lnkRemoveTypeEntite;
        private sc2i.win32.common.CWndLinkStd m_lnkAddTypeEntite;
        private System.Windows.Forms.Button button1;
    }
}
