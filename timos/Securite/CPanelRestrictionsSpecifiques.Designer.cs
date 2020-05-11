namespace timos.Securite
{
    partial class CPanelRestrictionsSpecifiques
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
            this.m_panelGauche = new System.Windows.Forms.Panel();
            this.m_wndListeGroupes = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_cmbGroupeRestriction = new sc2i.win32.common.CComboboxAutoFilled();
            this.m_lnkAddGroupeRestriction = new sc2i.win32.common.CWndLinkStd();
            this.label1 = new System.Windows.Forms.Label();
            this.m_lnkRemoveGroup = new System.Windows.Forms.Panel();
            this.cWndLinkStd1 = new sc2i.win32.common.CWndLinkStd();
            this.m_panelDetailGroupe = new System.Windows.Forms.Panel();
            this.m_tabApplication = new sc2i.win32.common.C2iTabControl(this.components);
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.m_arbreGroupes = new System.Windows.Forms.TreeView();
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.m_wndListeActeurs = new sc2i.win32.data.navigation.CPanelListeRelationSelection();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn3 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
            this.m_wndListeProfils = new sc2i.win32.data.navigation.CPanelListeRelationSelection();
            this.listViewAutoFilledColumn2 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_panelTopDetail = new System.Windows.Forms.Panel();
            this.m_btnAppliquerASelection = new System.Windows.Forms.RadioButton();
            this.m_btnAppliquerAToutLeMonde = new System.Windows.Forms.RadioButton();
            this.m_lblNomGroupe = new System.Windows.Forms.Label();
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_lblLibelleElement = new System.Windows.Forms.Label();
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.m_panelGauche.SuspendLayout();
            this.panel1.SuspendLayout();
            this.m_lnkRemoveGroup.SuspendLayout();
            this.m_panelDetailGroupe.SuspendLayout();
            this.m_tabApplication.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.m_panelTopDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelGauche
            // 
            this.m_panelGauche.Controls.Add(this.m_wndListeGroupes);
            this.m_panelGauche.Controls.Add(this.panel1);
            this.m_panelGauche.Controls.Add(this.label1);
            this.m_panelGauche.Controls.Add(this.m_lnkRemoveGroup);
            this.m_panelGauche.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelGauche.Location = new System.Drawing.Point(0, 30);
            this.m_extModeEdition.SetModeEdition(this.m_panelGauche, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelGauche.Name = "m_panelGauche";
            this.m_panelGauche.Size = new System.Drawing.Size(244, 304);
            this.m_extStyle.SetStyleBackColor(this.m_panelGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelGauche.TabIndex = 0;
            // 
            // m_wndListeGroupes
            // 
            this.m_wndListeGroupes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.m_wndListeGroupes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeGroupes.HideSelection = false;
            this.m_wndListeGroupes.Location = new System.Drawing.Point(0, 41);
            this.m_extModeEdition.SetModeEdition(this.m_wndListeGroupes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_wndListeGroupes.MultiSelect = false;
            this.m_wndListeGroupes.Name = "m_wndListeGroupes";
            this.m_wndListeGroupes.Size = new System.Drawing.Size(244, 242);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeGroupes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeGroupes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeGroupes.TabIndex = 1;
            this.m_wndListeGroupes.UseCompatibleStateImageBehavior = false;
            this.m_wndListeGroupes.View = System.Windows.Forms.View.Details;
            this.m_wndListeGroupes.SelectedIndexChanged += new System.EventHandler(this.m_wndListeGroupes_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Restriction group|20533";
            this.columnHeader1.Width = 221;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_cmbGroupeRestriction);
            this.panel1.Controls.Add(this.m_lnkAddGroupeRestriction);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 20);
            this.m_extModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(244, 21);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 2;
            // 
            // m_cmbGroupeRestriction
            // 
            this.m_cmbGroupeRestriction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_cmbGroupeRestriction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbGroupeRestriction.FormattingEnabled = true;
            this.m_cmbGroupeRestriction.IsLink = false;
            this.m_cmbGroupeRestriction.ListDonnees = null;
            this.m_cmbGroupeRestriction.Location = new System.Drawing.Point(0, 0);
            this.m_cmbGroupeRestriction.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_cmbGroupeRestriction, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbGroupeRestriction.Name = "m_cmbGroupeRestriction";
            this.m_cmbGroupeRestriction.NullAutorise = true;
            this.m_cmbGroupeRestriction.ProprieteAffichee = null;
            this.m_cmbGroupeRestriction.Size = new System.Drawing.Size(217, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbGroupeRestriction, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbGroupeRestriction, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbGroupeRestriction.TabIndex = 1;
            this.m_cmbGroupeRestriction.TextNull = "(empty)";
            this.m_cmbGroupeRestriction.Tri = true;
            // 
            // m_lnkAddGroupeRestriction
            // 
            this.m_lnkAddGroupeRestriction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAddGroupeRestriction.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_lnkAddGroupeRestriction.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkAddGroupeRestriction.Location = new System.Drawing.Point(217, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lnkAddGroupeRestriction, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkAddGroupeRestriction.Name = "m_lnkAddGroupeRestriction";
            this.m_lnkAddGroupeRestriction.Size = new System.Drawing.Size(27, 21);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAddGroupeRestriction, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAddGroupeRestriction, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAddGroupeRestriction.TabIndex = 1;
            this.m_lnkAddGroupeRestriction.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAddGroupeRestriction.LinkClicked += new System.EventHandler(this.m_lnkAddGroupeRestriction_LinkClicked);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 20);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 1;
            this.label1.Text = "Restriction group|20533";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lnkRemoveGroup
            // 
            this.m_lnkRemoveGroup.Controls.Add(this.cWndLinkStd1);
            this.m_lnkRemoveGroup.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_lnkRemoveGroup.Location = new System.Drawing.Point(0, 283);
            this.m_extModeEdition.SetModeEdition(this.m_lnkRemoveGroup, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lnkRemoveGroup.Name = "m_lnkRemoveGroup";
            this.m_lnkRemoveGroup.Size = new System.Drawing.Size(244, 21);
            this.m_extStyle.SetStyleBackColor(this.m_lnkRemoveGroup, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkRemoveGroup, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkRemoveGroup.TabIndex = 1;
            // 
            // cWndLinkStd1
            // 
            this.cWndLinkStd1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cWndLinkStd1.Dock = System.Windows.Forms.DockStyle.Left;
            this.cWndLinkStd1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.cWndLinkStd1.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.cWndLinkStd1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.cWndLinkStd1.Name = "cWndLinkStd1";
            this.cWndLinkStd1.Size = new System.Drawing.Size(103, 21);
            this.m_extStyle.SetStyleBackColor(this.cWndLinkStd1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.cWndLinkStd1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cWndLinkStd1.TabIndex = 2;
            this.cWndLinkStd1.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.cWndLinkStd1.LinkClicked += new System.EventHandler(this.cWndLinkStd1_LinkClicked);
            // 
            // m_panelDetailGroupe
            // 
            this.m_panelDetailGroupe.Controls.Add(this.m_tabApplication);
            this.m_panelDetailGroupe.Controls.Add(this.m_panelTopDetail);
            this.m_panelDetailGroupe.Controls.Add(this.m_lblNomGroupe);
            this.m_panelDetailGroupe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelDetailGroupe.Location = new System.Drawing.Point(244, 30);
            this.m_extModeEdition.SetModeEdition(this.m_panelDetailGroupe, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelDetailGroupe.Name = "m_panelDetailGroupe";
            this.m_panelDetailGroupe.Size = new System.Drawing.Size(413, 304);
            this.m_extStyle.SetStyleBackColor(this.m_panelDetailGroupe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelDetailGroupe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelDetailGroupe.TabIndex = 1;
            // 
            // m_tabApplication
            // 
            this.m_tabApplication.BoldSelectedPage = true;
            this.m_tabApplication.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tabApplication.IDEPixelArea = false;
            this.m_tabApplication.Location = new System.Drawing.Point(0, 51);
            this.m_extModeEdition.SetModeEdition(this.m_tabApplication, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_tabApplication.Name = "m_tabApplication";
            this.m_tabApplication.Ombre = false;
            this.m_tabApplication.PositionTop = true;
            this.m_tabApplication.SelectedIndex = 0;
            this.m_tabApplication.SelectedTab = this.tabPage1;
            this.m_tabApplication.Size = new System.Drawing.Size(413, 253);
            this.m_extStyle.SetStyleBackColor(this.m_tabApplication, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabApplication, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabApplication.TabIndex = 1;
            this.m_tabApplication.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2,
            this.tabPage3});
            this.m_tabApplication.SelectionChanged += new System.EventHandler(this.m_tabApplication_SelectionChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.m_arbreGroupes);
            this.tabPage2.Location = new System.Drawing.Point(0, 25);
            this.m_extModeEdition.SetModeEdition(this.tabPage2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(413, 228);
            this.m_extStyle.SetStyleBackColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage2.TabIndex = 11;
            this.tabPage2.Title = "Member groups|20537";
            // 
            // m_arbreGroupes
            // 
            this.m_arbreGroupes.CheckBoxes = true;
            this.m_arbreGroupes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_arbreGroupes.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_arbreGroupes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_arbreGroupes.Name = "m_arbreGroupes";
            this.m_arbreGroupes.Size = new System.Drawing.Size(413, 228);
            this.m_extStyle.SetStyleBackColor(this.m_arbreGroupes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_arbreGroupes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_arbreGroupes.TabIndex = 0;
            this.m_arbreGroupes.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.m_arbreGroupes_AfterCheck);
            this.m_arbreGroupes.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.m_arbreGroupes_BeforeCheck);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_wndListeActeurs);
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.m_extModeEdition.SetModeEdition(this.tabPage1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(413, 228);
            this.m_extStyle.SetStyleBackColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage1.TabIndex = 10;
            this.tabPage1.Title = "Members|20536";
            // 
            // m_wndListeActeurs
            // 
            this.m_wndListeActeurs.Columns.AddRange(new sc2i.win32.common.ListViewAutoFilledColumn[] {
            this.listViewAutoFilledColumn1,
            this.listViewAutoFilledColumn3});
            this.m_wndListeActeurs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeActeurs.EnableCustomisation = true;
            this.m_wndListeActeurs.ExclusionParException = false;
            this.m_wndListeActeurs.Location = new System.Drawing.Point(0, 0);
            this.m_wndListeActeurs.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_wndListeActeurs, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_wndListeActeurs.Name = "m_wndListeActeurs";
            this.m_wndListeActeurs.Size = new System.Drawing.Size(413, 228);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeActeurs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeActeurs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeActeurs.TabIndex = 0;
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "Nom";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Name|20539";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 150;
            // 
            // listViewAutoFilledColumn3
            // 
            this.listViewAutoFilledColumn3.Field = "Prenom";
            this.listViewAutoFilledColumn3.PrecisionWidth = 0;
            this.listViewAutoFilledColumn3.ProportionnalSize = false;
            this.listViewAutoFilledColumn3.Text = "First name|20542";
            this.listViewAutoFilledColumn3.Visible = true;
            this.listViewAutoFilledColumn3.Width = 120;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.m_wndListeProfils);
            this.tabPage3.Location = new System.Drawing.Point(0, 25);
            this.m_extModeEdition.SetModeEdition(this.tabPage3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Selected = false;
            this.tabPage3.Size = new System.Drawing.Size(413, 228);
            this.m_extStyle.SetStyleBackColor(this.tabPage3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage3.TabIndex = 12;
            this.tabPage3.Title = "User profiles|20538";
            // 
            // m_wndListeProfils
            // 
            this.m_wndListeProfils.Columns.AddRange(new sc2i.win32.common.ListViewAutoFilledColumn[] {
            this.listViewAutoFilledColumn2});
            this.m_wndListeProfils.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeProfils.EnableCustomisation = true;
            this.m_wndListeProfils.ExclusionParException = false;
            this.m_wndListeProfils.Location = new System.Drawing.Point(0, 0);
            this.m_wndListeProfils.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_wndListeProfils, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_wndListeProfils.Name = "m_wndListeProfils";
            this.m_wndListeProfils.Size = new System.Drawing.Size(413, 228);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeProfils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeProfils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeProfils.TabIndex = 1;
            // 
            // listViewAutoFilledColumn2
            // 
            this.listViewAutoFilledColumn2.Field = "Libelle";
            this.listViewAutoFilledColumn2.PrecisionWidth = 0;
            this.listViewAutoFilledColumn2.ProportionnalSize = false;
            this.listViewAutoFilledColumn2.Text = "Label|50";
            this.listViewAutoFilledColumn2.Visible = true;
            this.listViewAutoFilledColumn2.Width = 350;
            // 
            // m_panelTopDetail
            // 
            this.m_panelTopDetail.Controls.Add(this.m_btnAppliquerASelection);
            this.m_panelTopDetail.Controls.Add(this.m_btnAppliquerAToutLeMonde);
            this.m_panelTopDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelTopDetail.Location = new System.Drawing.Point(0, 30);
            this.m_extModeEdition.SetModeEdition(this.m_panelTopDetail, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelTopDetail.Name = "m_panelTopDetail";
            this.m_panelTopDetail.Size = new System.Drawing.Size(413, 21);
            this.m_extStyle.SetStyleBackColor(this.m_panelTopDetail, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelTopDetail, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelTopDetail.TabIndex = 0;
            // 
            // m_btnAppliquerASelection
            // 
            this.m_btnAppliquerASelection.AutoSize = true;
            this.m_btnAppliquerASelection.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnAppliquerASelection.Location = new System.Drawing.Point(136, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnAppliquerASelection, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnAppliquerASelection.Name = "m_btnAppliquerASelection";
            this.m_btnAppliquerASelection.Size = new System.Drawing.Size(140, 21);
            this.m_extStyle.SetStyleBackColor(this.m_btnAppliquerASelection, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAppliquerASelection, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAppliquerASelection.TabIndex = 1;
            this.m_btnAppliquerASelection.TabStop = true;
            this.m_btnAppliquerASelection.Text = "Apply to selection|20535";
            this.m_btnAppliquerASelection.UseVisualStyleBackColor = true;
            this.m_btnAppliquerASelection.CheckedChanged += new System.EventHandler(this.m_btnAppliquerAToutLeMonde_CheckedChanged);
            // 
            // m_btnAppliquerAToutLeMonde
            // 
            this.m_btnAppliquerAToutLeMonde.AutoSize = true;
            this.m_btnAppliquerAToutLeMonde.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnAppliquerAToutLeMonde.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnAppliquerAToutLeMonde, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnAppliquerAToutLeMonde.Name = "m_btnAppliquerAToutLeMonde";
            this.m_btnAppliquerAToutLeMonde.Size = new System.Drawing.Size(136, 21);
            this.m_extStyle.SetStyleBackColor(this.m_btnAppliquerAToutLeMonde, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAppliquerAToutLeMonde, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAppliquerAToutLeMonde.TabIndex = 0;
            this.m_btnAppliquerAToutLeMonde.TabStop = true;
            this.m_btnAppliquerAToutLeMonde.Text = "Apply to all users|20534";
            this.m_btnAppliquerAToutLeMonde.UseVisualStyleBackColor = true;
            this.m_btnAppliquerAToutLeMonde.CheckedChanged += new System.EventHandler(this.m_btnAppliquerAToutLeMonde_CheckedChanged);
            // 
            // m_lblNomGroupe
            // 
            this.m_lblNomGroupe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.m_lblNomGroupe.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_lblNomGroupe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblNomGroupe.ForeColor = System.Drawing.Color.White;
            this.m_lblNomGroupe.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lblNomGroupe, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblNomGroupe.Name = "m_lblNomGroupe";
            this.m_lblNomGroupe.Size = new System.Drawing.Size(413, 30);
            this.m_extStyle.SetStyleBackColor(this.m_lblNomGroupe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblNomGroupe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblNomGroupe.TabIndex = 2;
            this.m_lblNomGroupe.Text = "label2";
            this.m_lblNomGroupe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_lblLibelleElement
            // 
            this.m_lblLibelleElement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.m_lblLibelleElement.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_lblLibelleElement.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblLibelleElement.ForeColor = System.Drawing.Color.White;
            this.m_lblLibelleElement.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lblLibelleElement, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblLibelleElement.Name = "m_lblLibelleElement";
            this.m_lblLibelleElement.Size = new System.Drawing.Size(657, 30);
            this.m_extStyle.SetStyleBackColor(this.m_lblLibelleElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblLibelleElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblLibelleElement.TabIndex = 1;
            this.m_lblLibelleElement.Text = "label2";
            this.m_lblLibelleElement.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CPanelRestrictionsSpecifiques
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.m_panelDetailGroupe);
            this.Controls.Add(this.m_panelGauche);
            this.Controls.Add(this.m_lblLibelleElement);
            this.ForeColor = System.Drawing.Color.Black;
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CPanelRestrictionsSpecifiques";
            this.Size = new System.Drawing.Size(657, 334);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelGauche.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.m_lnkRemoveGroup.ResumeLayout(false);
            this.m_panelDetailGroupe.ResumeLayout(false);
            this.m_tabApplication.ResumeLayout(false);
            this.m_tabApplication.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.m_panelTopDetail.ResumeLayout(false);
            this.m_panelTopDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel m_panelGauche;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView m_wndListeGroupes;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Panel panel1;
        private sc2i.win32.common.CComboboxAutoFilled m_cmbGroupeRestriction;
        private sc2i.win32.common.CWndLinkStd m_lnkAddGroupeRestriction;
        private System.Windows.Forms.Panel m_lnkRemoveGroup;
        private sc2i.win32.common.CWndLinkStd cWndLinkStd1;
        private System.Windows.Forms.Panel m_panelDetailGroupe;
        private System.Windows.Forms.Panel m_panelTopDetail;
        private System.Windows.Forms.RadioButton m_btnAppliquerAToutLeMonde;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
        private sc2i.win32.common.CExtStyle m_extStyle;
        private sc2i.win32.common.C2iTabControl m_tabApplication;
        private System.Windows.Forms.RadioButton m_btnAppliquerASelection;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private Crownwood.Magic.Controls.TabPage tabPage2;
        private Crownwood.Magic.Controls.TabPage tabPage3;
        private sc2i.win32.data.navigation.CPanelListeRelationSelection m_wndListeActeurs;
        private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn1;
        private sc2i.win32.data.navigation.CPanelListeRelationSelection m_wndListeProfils;
        private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn2;
        private System.Windows.Forms.TreeView m_arbreGroupes;
        private System.Windows.Forms.Label m_lblLibelleElement;
        private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn3;
        private System.Windows.Forms.Label m_lblNomGroupe;
    }
}
