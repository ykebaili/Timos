namespace futurocom.win32.sig
{
    partial class CControleEditeMapLineGenerator
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
            this.m_panelFiltre = new sc2i.win32.data.dynamic.CPanelEditFiltreDynamique();
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_panelDessins = new futurocom.win32.sig.CControleEditeMapsLinesDessins();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.m_panelActionNotNull = new System.Windows.Forms.Panel();
            this.m_btnDeleteActionSurClick = new System.Windows.Forms.PictureBox();
            this.m_pictureActionNotNull = new System.Windows.Forms.PictureBox();
            this.m_lnkClickAction = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.m_txtFormuleLongitude2 = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.label6 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.m_txtFormuleLatitude2 = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.m_txtFormuleLongitude1 = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_txtFormuleLatitude1 = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.panel1.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.m_panelActionNotNull.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnDeleteActionSurClick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_pictureActionNotNull)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelFiltre
            // 
            this.m_panelFiltre.BackColor = System.Drawing.Color.White;
            this.m_panelFiltre.DefinitionRacineDeChampsFiltres = null;
            this.m_panelFiltre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelFiltre.FiltreDynamique = null;
            this.m_panelFiltre.Location = new System.Drawing.Point(0, 0);
            this.m_panelFiltre.LockEdition = true;
            this.m_extModeEdition.SetModeEdition(this.m_panelFiltre, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelFiltre.ModeFiltreExpression = false;
            this.m_panelFiltre.ModeSansType = false;
            this.m_panelFiltre.Name = "m_panelFiltre";
            this.m_panelFiltre.Size = new System.Drawing.Size(415, 240);
            this.m_extStyle.SetStyleBackColor(this.m_panelFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelFiltre.TabIndex = 0;
            this.m_panelFiltre.OnChangeTypeElements += new sc2i.win32.data.dynamic.ChangeTypeElementsEventHandler(this.m_panelFiltre_OnChangeTypeElements);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_txtLibelle);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 3);
            this.m_extModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(431, 21);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 1;
            // 
            // m_txtLibelle
            // 
            this.m_txtLibelle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtLibelle.EmptyText = "";
            this.m_txtLibelle.Location = new System.Drawing.Point(100, 0);
            this.m_txtLibelle.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(331, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 21);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item label|20003";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.splitter1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(431, 3);
            this.m_extStyle.SetStyleBackColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // m_panelDessins
            // 
            this.m_panelDessins.CurrentItemIndex = null;
            this.m_panelDessins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelDessins.Items = new sc2i.win32.common.customizableList.CCustomizableListItem[0];
            this.m_panelDessins.Location = new System.Drawing.Point(0, 0);
            this.m_panelDessins.LockEdition = true;
            this.m_extModeEdition.SetModeEdition(this.m_panelDessins, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelDessins.Name = "m_panelDessins";
            this.m_panelDessins.Size = new System.Drawing.Size(415, 355);
            this.m_extStyle.SetStyleBackColor(this.m_panelDessins, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelDessins, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelDessins.TabIndex = 3;
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
            this.m_tabControl.Location = new System.Drawing.Point(0, 24);
            this.m_extModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.tabPage1;
            this.m_tabControl.Size = new System.Drawing.Size(431, 396);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_panelFiltre);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.m_extModeEdition.SetModeEdition(this.tabPage1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(415, 355);
            this.m_extStyle.SetStyleBackColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage1.TabIndex = 10;
            this.tabPage1.Title = "Items|20008";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 240);
            this.m_extModeEdition.SetModeEdition(this.panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(415, 115);
            this.m_extStyle.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel2.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.m_panelActionNotNull);
            this.panel5.Controls.Add(this.m_lnkClickAction);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 84);
            this.m_extModeEdition.SetModeEdition(this.panel5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(415, 22);
            this.m_extStyle.SetStyleBackColor(this.panel5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel5.TabIndex = 3;
            // 
            // m_panelActionNotNull
            // 
            this.m_panelActionNotNull.Controls.Add(this.m_btnDeleteActionSurClick);
            this.m_panelActionNotNull.Controls.Add(this.m_pictureActionNotNull);
            this.m_panelActionNotNull.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelActionNotNull.Location = new System.Drawing.Point(209, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelActionNotNull, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelActionNotNull.Name = "m_panelActionNotNull";
            this.m_panelActionNotNull.Size = new System.Drawing.Size(66, 22);
            this.m_extStyle.SetStyleBackColor(this.m_panelActionNotNull, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelActionNotNull, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelActionNotNull.TabIndex = 5;
            // 
            // m_btnDeleteActionSurClick
            // 
            this.m_btnDeleteActionSurClick.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnDeleteActionSurClick.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnDeleteActionSurClick.Image = global::futurocom.win32.sig.Resource.delete;
            this.m_btnDeleteActionSurClick.Location = new System.Drawing.Point(18, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnDeleteActionSurClick, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnDeleteActionSurClick.Name = "m_btnDeleteActionSurClick";
            this.m_btnDeleteActionSurClick.Size = new System.Drawing.Size(18, 22);
            this.m_btnDeleteActionSurClick.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_extStyle.SetStyleBackColor(this.m_btnDeleteActionSurClick, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnDeleteActionSurClick, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnDeleteActionSurClick.TabIndex = 5;
            this.m_btnDeleteActionSurClick.TabStop = false;
            this.m_btnDeleteActionSurClick.Click += new System.EventHandler(this.m_btnDeleteActionSurClick_Click);
            // 
            // m_pictureActionNotNull
            // 
            this.m_pictureActionNotNull.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_pictureActionNotNull.Image = global::futurocom.win32.sig.Resource.valide;
            this.m_pictureActionNotNull.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_pictureActionNotNull, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_pictureActionNotNull.Name = "m_pictureActionNotNull";
            this.m_pictureActionNotNull.Size = new System.Drawing.Size(18, 22);
            this.m_pictureActionNotNull.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_extStyle.SetStyleBackColor(this.m_pictureActionNotNull, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pictureActionNotNull, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pictureActionNotNull.TabIndex = 4;
            this.m_pictureActionNotNull.TabStop = false;
            // 
            // m_lnkClickAction
            // 
            this.m_lnkClickAction.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkClickAction.Location = new System.Drawing.Point(100, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lnkClickAction, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lnkClickAction.Name = "m_lnkClickAction";
            this.m_lnkClickAction.Size = new System.Drawing.Size(109, 22);
            this.m_extStyle.SetStyleBackColor(this.m_lnkClickAction, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkClickAction, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkClickAction.TabIndex = 2;
            this.m_lnkClickAction.TabStop = true;
            this.m_lnkClickAction.Text = "On click action|20015";
            this.m_lnkClickAction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lnkClickAction.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkClickAction_LinkClicked);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 22);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 3;
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.m_txtFormuleLongitude2);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 63);
            this.m_extModeEdition.SetModeEdition(this.panel7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(415, 21);
            this.m_extStyle.SetStyleBackColor(this.panel7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel7.TabIndex = 7;
            // 
            // m_txtFormuleLongitude2
            // 
            this.m_txtFormuleLongitude2.AllowGraphic = true;
            this.m_txtFormuleLongitude2.AllowNullFormula = false;
            this.m_txtFormuleLongitude2.AllowSaisieTexte = true;
            this.m_txtFormuleLongitude2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtFormuleLongitude2.Formule = null;
            this.m_txtFormuleLongitude2.Location = new System.Drawing.Point(100, 0);
            this.m_txtFormuleLongitude2.LockEdition = false;
            this.m_txtFormuleLongitude2.LockZoneTexte = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtFormuleLongitude2, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtFormuleLongitude2.Name = "m_txtFormuleLongitude2";
            this.m_txtFormuleLongitude2.Size = new System.Drawing.Size(315, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtFormuleLongitude2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFormuleLongitude2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleLongitude2.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 21);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 0;
            this.label6.Text = "Longitude 2|20046";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.m_txtFormuleLatitude2);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 42);
            this.m_extModeEdition.SetModeEdition(this.panel6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(415, 21);
            this.m_extStyle.SetStyleBackColor(this.panel6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel6.TabIndex = 6;
            // 
            // m_txtFormuleLatitude2
            // 
            this.m_txtFormuleLatitude2.AllowGraphic = true;
            this.m_txtFormuleLatitude2.AllowNullFormula = false;
            this.m_txtFormuleLatitude2.AllowSaisieTexte = true;
            this.m_txtFormuleLatitude2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtFormuleLatitude2.Formule = null;
            this.m_txtFormuleLatitude2.Location = new System.Drawing.Point(100, 0);
            this.m_txtFormuleLatitude2.LockEdition = false;
            this.m_txtFormuleLatitude2.LockZoneTexte = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtFormuleLatitude2, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtFormuleLatitude2.Name = "m_txtFormuleLatitude2";
            this.m_txtFormuleLatitude2.Size = new System.Drawing.Size(315, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtFormuleLatitude2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFormuleLatitude2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleLatitude2.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 21);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 0;
            this.label5.Text = "Latitude 2|20045";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.m_txtFormuleLongitude1);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 21);
            this.m_extModeEdition.SetModeEdition(this.panel4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(415, 21);
            this.m_extStyle.SetStyleBackColor(this.panel4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel4.TabIndex = 1;
            // 
            // m_txtFormuleLongitude1
            // 
            this.m_txtFormuleLongitude1.AllowGraphic = true;
            this.m_txtFormuleLongitude1.AllowNullFormula = false;
            this.m_txtFormuleLongitude1.AllowSaisieTexte = true;
            this.m_txtFormuleLongitude1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtFormuleLongitude1.Formule = null;
            this.m_txtFormuleLongitude1.Location = new System.Drawing.Point(100, 0);
            this.m_txtFormuleLongitude1.LockEdition = false;
            this.m_txtFormuleLongitude1.LockZoneTexte = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtFormuleLongitude1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtFormuleLongitude1.Name = "m_txtFormuleLongitude1";
            this.m_txtFormuleLongitude1.Size = new System.Drawing.Size(315, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtFormuleLongitude1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFormuleLongitude1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleLongitude1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 21);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 0;
            this.label3.Text = "Longitude 1|20044";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.m_txtFormuleLatitude1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.panel3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(415, 21);
            this.m_extStyle.SetStyleBackColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel3.TabIndex = 0;
            // 
            // m_txtFormuleLatitude1
            // 
            this.m_txtFormuleLatitude1.AllowGraphic = true;
            this.m_txtFormuleLatitude1.AllowNullFormula = false;
            this.m_txtFormuleLatitude1.AllowSaisieTexte = true;
            this.m_txtFormuleLatitude1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtFormuleLatitude1.Formule = null;
            this.m_txtFormuleLatitude1.Location = new System.Drawing.Point(100, 0);
            this.m_txtFormuleLatitude1.LockEdition = false;
            this.m_txtFormuleLatitude1.LockZoneTexte = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtFormuleLatitude1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtFormuleLatitude1.Name = "m_txtFormuleLatitude1";
            this.m_txtFormuleLatitude1.Size = new System.Drawing.Size(315, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtFormuleLatitude1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFormuleLatitude1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleLatitude1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 21);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 0;
            this.label2.Text = "Latitude 1|20043";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.m_panelDessins);
            this.tabPage2.Location = new System.Drawing.Point(0, 25);
            this.m_extModeEdition.SetModeEdition(this.tabPage2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(415, 355);
            this.m_extStyle.SetStyleBackColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage2.TabIndex = 11;
            this.tabPage2.Title = "Drawing|20009";
            // 
            // CControleEditeMapLineGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleEditeMapLineGenerator";
            this.Size = new System.Drawing.Size(431, 420);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.m_panelActionNotNull.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnDeleteActionSurClick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_pictureActionNotNull)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.data.dynamic.CPanelEditFiltreDynamique m_panelFiltre;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private sc2i.win32.common.C2iTextBox m_txtLibelle;
        private System.Windows.Forms.Splitter splitter1;
        private CControleEditeMapsLinesDessins m_panelDessins;
        private sc2i.win32.common.CExtStyle m_extStyle;
        private sc2i.win32.common.C2iTabControl m_tabControl;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private Crownwood.Magic.Controls.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleLongitude1;
        private System.Windows.Forms.Label label3;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleLatitude1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel m_lnkClickAction;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox m_pictureActionNotNull;
        private System.Windows.Forms.Panel m_panelActionNotNull;
        private System.Windows.Forms.PictureBox m_btnDeleteActionSurClick;
        private System.Windows.Forms.Panel panel7;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleLongitude2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel6;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleLatitude2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}
