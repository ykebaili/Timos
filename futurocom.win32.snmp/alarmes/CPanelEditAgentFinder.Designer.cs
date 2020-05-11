namespace futurocom.win32.snmp.alarmes
{
    partial class CPanelEditAgentFinder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPanelEditAgentFinder));
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn3 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn4 = new sc2i.win32.common.GLColumn();
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtNom = new sc2i.win32.common.C2iTextBox();
            this.m_txtDescription = new sc2i.win32.common.C2iTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.c2iTextBox3 = new sc2i.win32.common.C2iTextBox();
            this.c2iTextBox4 = new sc2i.win32.common.C2iTextBox();
            this.m_cmbGenericCode = new System.Windows.Forms.ComboBox();
            this.c2iTextBox5 = new sc2i.win32.common.C2iTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_txtFormuleCondition = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.label7 = new System.Windows.Forms.Label();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_wndListeChamps = new sc2i.win32.common.GlacialList();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_lnkRemoveChamp = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkDetailChampTrap = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkAddChamp = new sc2i.win32.common.CWndLinkStd();
            this.label8 = new System.Windows.Forms.Label();
            this.m_wndListeChampsSupplementaires = new sc2i.win32.common.GlacialList();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_lnkRemoveChampSupplementaire = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkEditChampSupp = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkAddChampSupplementaire = new sc2i.win32.common.CWndLinkStd();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage4 = new Crownwood.Magic.Controls.TabPage();
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_linkField = new sc2i.win32.common.CExtLinkField();
            this.m_txtFormuleCleSpecifiqueAgent = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.label12 = new System.Windows.Forms.Label();
            this.m_chkUpdateIPOnMediation = new System.Windows.Forms.CheckBox();
            this.m_chkUpdateIpInTimos = new System.Windows.Forms.CheckBox();
            this.m_tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.m_linkField.SetLinkField(this.label1, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.label1, false);
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.m_extModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 20);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 0;
            this.label1.Text = "Entreprise|20054";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtNom
            // 
            this.m_txtNom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtNom.EmptyText = "";
            this.m_linkField.SetLinkField(this.m_txtNom, "Libelle");
            this.m_linkField.SetLinkFieldAutoUpdate(this.m_txtNom, true);
            this.m_txtNom.Location = new System.Drawing.Point(151, 4);
            this.m_txtNom.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtNom, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtNom.Name = "m_txtNom";
            this.m_txtNom.Size = new System.Drawing.Size(526, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtNom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtNom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtNom.TabIndex = 1;
            this.m_txtNom.Text = "[Libelle]";
            // 
            // m_txtDescription
            // 
            this.m_txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtDescription.EmptyText = "";
            this.m_linkField.SetLinkField(this.m_txtDescription, "Description");
            this.m_linkField.SetLinkFieldAutoUpdate(this.m_txtDescription, true);
            this.m_txtDescription.Location = new System.Drawing.Point(151, 34);
            this.m_txtDescription.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtDescription, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtDescription.Multiline = true;
            this.m_txtDescription.Name = "m_txtDescription";
            this.m_txtDescription.Size = new System.Drawing.Size(526, 51);
            this.m_extStyle.SetStyleBackColor(this.m_txtDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtDescription.TabIndex = 3;
            this.m_txtDescription.Text = "[Description]";
            // 
            // label2
            // 
            this.m_linkField.SetLinkField(this.label2, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.label2, false);
            this.label2.Location = new System.Drawing.Point(4, 34);
            this.m_extModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 20);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description|20052";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.m_linkField.SetLinkField(this.label3, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.label3, false);
            this.label3.Location = new System.Drawing.Point(12, 66);
            this.m_extModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 20);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 0;
            this.label3.Text = "Generic code|20055";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.m_linkField.SetLinkField(this.label4, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.label4, false);
            this.label4.Location = new System.Drawing.Point(12, 37);
            this.m_extModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 20);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 0;
            this.label4.Text = "Community|20056";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.m_linkField.SetLinkField(this.label5, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.label5, false);
            this.label5.Location = new System.Drawing.Point(12, 92);
            this.m_extModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 20);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 0;
            this.label5.Text = "Specific trap|20057";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c2iTextBox3
            // 
            this.c2iTextBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iTextBox3.EmptyText = "";
            this.m_linkField.SetLinkField(this.c2iTextBox3, "EntrepriseRequestedValue");
            this.m_linkField.SetLinkFieldAutoUpdate(this.c2iTextBox3, true);
            this.c2iTextBox3.Location = new System.Drawing.Point(150, 12);
            this.c2iTextBox3.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.c2iTextBox3, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.c2iTextBox3.Name = "c2iTextBox3";
            this.c2iTextBox3.Size = new System.Drawing.Size(359, 23);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox3.TabIndex = 5;
            this.c2iTextBox3.Text = "[EntrepriseRequestedValue]";
            // 
            // c2iTextBox4
            // 
            this.c2iTextBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iTextBox4.EmptyText = "";
            this.m_linkField.SetLinkField(this.c2iTextBox4, "CommunityRequestedValue");
            this.m_linkField.SetLinkFieldAutoUpdate(this.c2iTextBox4, true);
            this.c2iTextBox4.Location = new System.Drawing.Point(150, 38);
            this.c2iTextBox4.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.c2iTextBox4, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.c2iTextBox4.Name = "c2iTextBox4";
            this.c2iTextBox4.Size = new System.Drawing.Size(359, 23);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox4.TabIndex = 6;
            this.c2iTextBox4.Text = "[CommunityRequestedValue]";
            // 
            // m_cmbGenericCode
            // 
            this.m_cmbGenericCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbGenericCode.FormattingEnabled = true;
            this.m_linkField.SetLinkField(this.m_cmbGenericCode, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.m_cmbGenericCode, false);
            this.m_cmbGenericCode.Location = new System.Drawing.Point(150, 65);
            this.m_extModeEdition.SetModeEdition(this.m_cmbGenericCode, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbGenericCode.Name = "m_cmbGenericCode";
            this.m_cmbGenericCode.Size = new System.Drawing.Size(217, 23);
            this.m_extStyle.SetStyleBackColor(this.m_cmbGenericCode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbGenericCode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbGenericCode.TabIndex = 7;
            // 
            // c2iTextBox5
            // 
            this.c2iTextBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iTextBox5.EmptyText = "";
            this.m_linkField.SetLinkField(this.c2iTextBox5, "SpecificRequestedValue");
            this.m_linkField.SetLinkFieldAutoUpdate(this.c2iTextBox5, true);
            this.c2iTextBox5.Location = new System.Drawing.Point(150, 92);
            this.c2iTextBox5.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.c2iTextBox5, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.c2iTextBox5.Name = "c2iTextBox5";
            this.c2iTextBox5.Size = new System.Drawing.Size(359, 23);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox5.TabIndex = 8;
            this.c2iTextBox5.Text = "[SpecificRequestedValue]";
            // 
            // label6
            // 
            this.m_linkField.SetLinkField(this.label6, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.label6, false);
            this.label6.Location = new System.Drawing.Point(12, 119);
            this.m_extModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 20);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 9;
            this.label6.Text = "Advanced condition|20058";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtFormuleCondition
            // 
            this.m_txtFormuleCondition.AllowGraphic = true;
            this.m_txtFormuleCondition.AllowNullFormula = false;
            this.m_txtFormuleCondition.AllowSaisieTexte = true;
            this.m_txtFormuleCondition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormuleCondition.Formule = null;
            this.m_linkField.SetLinkField(this.m_txtFormuleCondition, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.m_txtFormuleCondition, false);
            this.m_txtFormuleCondition.Location = new System.Drawing.Point(151, 119);
            this.m_txtFormuleCondition.LockEdition = false;
            this.m_txtFormuleCondition.LockZoneTexte = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtFormuleCondition, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtFormuleCondition.Name = "m_txtFormuleCondition";
            this.m_txtFormuleCondition.Size = new System.Drawing.Size(358, 22);
            this.m_extStyle.SetStyleBackColor(this.m_txtFormuleCondition, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFormuleCondition, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleCondition.TabIndex = 10;
            // 
            // label7
            // 
            this.m_linkField.SetLinkField(this.label7, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.label7, false);
            this.label7.Location = new System.Drawing.Point(4, 4);
            this.m_extModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 20);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 9;
            this.label7.Text = "Label|20051";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_tabControl
            // 
            this.m_tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_tabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_tabControl.BoldSelectedPage = true;
            this.m_tabControl.ForeColor = System.Drawing.Color.Black;
            this.m_tabControl.IDEPixelArea = false;
            this.m_linkField.SetLinkField(this.m_tabControl, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.m_tabControl, false);
            this.m_tabControl.Location = new System.Drawing.Point(0, 91);
            this.m_extModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = false;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 2;
            this.m_tabControl.SelectedTab = this.tabPage4;
            this.m_tabControl.Size = new System.Drawing.Size(694, 311);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 10;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage3,
            this.tabPage4});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            this.m_tabControl.SelectionChanged += new System.EventHandler(this.m_tabControl_SelectionChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_txtFormuleCondition);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.c2iTextBox5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.m_cmbGenericCode);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.c2iTextBox4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.c2iTextBox3);
            this.m_linkField.SetLinkField(this.tabPage1, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.tabPage1, false);
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.m_extModeEdition.SetModeEdition(this.tabPage1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Selected = false;
            this.tabPage1.Size = new System.Drawing.Size(694, 286);
            this.m_extStyle.SetStyleBackColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage1.TabIndex = 10;
            this.tabPage1.Title = "Launch condition|20053";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.splitContainer1);
            this.m_linkField.SetLinkField(this.tabPage3, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.tabPage3, false);
            this.tabPage3.Location = new System.Drawing.Point(0, 25);
            this.m_extModeEdition.SetModeEdition(this.tabPage3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Selected = false;
            this.tabPage3.Size = new System.Drawing.Size(694, 286);
            this.m_extStyle.SetStyleBackColor(this.tabPage3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage3.TabIndex = 12;
            this.tabPage3.Title = "Fields|20060";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_linkField.SetLinkField(this.splitContainer1, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.splitContainer1, false);
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.splitContainer1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m_wndListeChamps);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.m_linkField.SetLinkField(this.splitContainer1.Panel1, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.splitContainer1.Panel1, false);
            this.m_extModeEdition.SetModeEdition(this.splitContainer1.Panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.splitContainer1.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer1.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_wndListeChampsSupplementaires);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.m_linkField.SetLinkField(this.splitContainer1.Panel2, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.splitContainer1.Panel2, false);
            this.m_extModeEdition.SetModeEdition(this.splitContainer1.Panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.splitContainer1.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer1.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitContainer1.Size = new System.Drawing.Size(694, 286);
            this.splitContainer1.SplitterDistance = 142;
            this.m_extStyle.SetStyleBackColor(this.splitContainer1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitContainer1.TabIndex = 2;
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
            glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "Column1";
            glColumn1.Propriete = "OID";
            glColumn1.Text = "OID|20062";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 200;
            glColumn2.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn2.ActiveControlItems")));
            glColumn2.BackColor = System.Drawing.Color.Transparent;
            glColumn2.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn2.ForColor = System.Drawing.Color.Black;
            glColumn2.ImageIndex = -1;
            glColumn2.IsCheckColumn = false;
            glColumn2.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn2.Name = "Column2";
            glColumn2.Propriete = "Name";
            glColumn2.Text = "Name|20063";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 200;
            this.m_wndListeChamps.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1,
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
            this.m_linkField.SetLinkField(this.m_wndListeChamps, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.m_wndListeChamps, false);
            this.m_wndListeChamps.ListeSource = null;
            this.m_wndListeChamps.Location = new System.Drawing.Point(0, 27);
            this.m_wndListeChamps.MaxHeight = 17;
            this.m_extModeEdition.SetModeEdition(this.m_wndListeChamps, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_wndListeChamps.Name = "m_wndListeChamps";
            this.m_wndListeChamps.SelectedTextColor = System.Drawing.Color.White;
            this.m_wndListeChamps.SelectionColor = System.Drawing.Color.DarkBlue;
            this.m_wndListeChamps.ShowBorder = true;
            this.m_wndListeChamps.ShowFocusRect = true;
            this.m_wndListeChamps.Size = new System.Drawing.Size(694, 115);
            this.m_wndListeChamps.SortIndex = 0;
            this.m_extStyle.SetStyleBackColor(this.m_wndListeChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeChamps.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.m_wndListeChamps.TabIndex = 1;
            this.m_wndListeChamps.Text = "glacialList1";
            this.m_wndListeChamps.TrierAuClicSurEnteteColonne = true;
            this.m_wndListeChamps.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.m_wndListeChamps_MouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_lnkRemoveChamp);
            this.panel1.Controls.Add(this.m_lnkDetailChampTrap);
            this.panel1.Controls.Add(this.m_lnkAddChamp);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_linkField.SetLinkField(this.panel1, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.panel1, false);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(694, 27);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 0;
            // 
            // m_lnkRemoveChamp
            // 
            this.m_lnkRemoveChamp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkRemoveChamp.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_lnkRemoveChamp.CustomImage")));
            this.m_lnkRemoveChamp.CustomText = "Remove";
            this.m_lnkRemoveChamp.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkRemoveChamp.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_linkField.SetLinkField(this.m_lnkRemoveChamp, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.m_lnkRemoveChamp, false);
            this.m_lnkRemoveChamp.Location = new System.Drawing.Point(484, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lnkRemoveChamp, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkRemoveChamp.Name = "m_lnkRemoveChamp";
            this.m_lnkRemoveChamp.ShortMode = false;
            this.m_lnkRemoveChamp.Size = new System.Drawing.Size(112, 27);
            this.m_extStyle.SetStyleBackColor(this.m_lnkRemoveChamp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkRemoveChamp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkRemoveChamp.TabIndex = 1;
            this.m_lnkRemoveChamp.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkRemoveChamp.LinkClicked += new System.EventHandler(this.m_lnkRemoveChamp_LinkClicked);
            // 
            // m_lnkDetailChampTrap
            // 
            this.m_lnkDetailChampTrap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkDetailChampTrap.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_lnkDetailChampTrap.CustomImage")));
            this.m_lnkDetailChampTrap.CustomText = "Detail";
            this.m_lnkDetailChampTrap.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkDetailChampTrap.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_linkField.SetLinkField(this.m_lnkDetailChampTrap, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.m_lnkDetailChampTrap, false);
            this.m_lnkDetailChampTrap.Location = new System.Drawing.Point(372, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lnkDetailChampTrap, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkDetailChampTrap.Name = "m_lnkDetailChampTrap";
            this.m_lnkDetailChampTrap.ShortMode = false;
            this.m_lnkDetailChampTrap.Size = new System.Drawing.Size(112, 27);
            this.m_extStyle.SetStyleBackColor(this.m_lnkDetailChampTrap, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkDetailChampTrap, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkDetailChampTrap.TabIndex = 3;
            this.m_lnkDetailChampTrap.TypeLien = sc2i.win32.common.TypeLinkStd.Modification;
            this.m_lnkDetailChampTrap.LinkClicked += new System.EventHandler(this.m_lnkDetailChampTrap_LinkClicked);
            // 
            // m_lnkAddChamp
            // 
            this.m_lnkAddChamp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAddChamp.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_lnkAddChamp.CustomImage")));
            this.m_lnkAddChamp.CustomText = "Add";
            this.m_lnkAddChamp.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkAddChamp.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_linkField.SetLinkField(this.m_lnkAddChamp, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.m_lnkAddChamp, false);
            this.m_lnkAddChamp.Location = new System.Drawing.Point(260, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lnkAddChamp, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkAddChamp.Name = "m_lnkAddChamp";
            this.m_lnkAddChamp.ShortMode = false;
            this.m_lnkAddChamp.Size = new System.Drawing.Size(112, 27);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAddChamp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAddChamp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAddChamp.TabIndex = 0;
            this.m_lnkAddChamp.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAddChamp.LinkClicked += new System.EventHandler(this.m_lnkAddChamp_LinkClicked);
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_linkField.SetLinkField(this.label8, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.label8, false);
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.label8, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(260, 27);
            this.m_extStyle.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 2;
            this.label8.Text = "Trap fields|20072";
            // 
            // m_wndListeChampsSupplementaires
            // 
            this.m_wndListeChampsSupplementaires.AllowColumnResize = true;
            this.m_wndListeChampsSupplementaires.AllowMultiselect = false;
            this.m_wndListeChampsSupplementaires.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.m_wndListeChampsSupplementaires.AlternatingColors = false;
            this.m_wndListeChampsSupplementaires.AutoHeight = true;
            this.m_wndListeChampsSupplementaires.AutoSort = true;
            this.m_wndListeChampsSupplementaires.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.m_wndListeChampsSupplementaires.CanChangeActivationCheckBoxes = false;
            this.m_wndListeChampsSupplementaires.CheckBoxes = false;
            this.m_wndListeChampsSupplementaires.CheckedItems = ((System.Collections.ArrayList)(resources.GetObject("m_wndListeChampsSupplementaires.CheckedItems")));
            glColumn3.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn3.ActiveControlItems")));
            glColumn3.BackColor = System.Drawing.Color.Transparent;
            glColumn3.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn3.ForColor = System.Drawing.Color.Black;
            glColumn3.ImageIndex = -1;
            glColumn3.IsCheckColumn = false;
            glColumn3.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn3.Name = "Column1";
            glColumn3.Propriete = "OID";
            glColumn3.Text = "OID|20062";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn3.Width = 200;
            glColumn4.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn4.ActiveControlItems")));
            glColumn4.BackColor = System.Drawing.Color.Transparent;
            glColumn4.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn4.ForColor = System.Drawing.Color.Black;
            glColumn4.ImageIndex = -1;
            glColumn4.IsCheckColumn = false;
            glColumn4.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn4.Name = "Column2";
            glColumn4.Propriete = "Name";
            glColumn4.Text = "Name|20063";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn4.Width = 200;
            this.m_wndListeChampsSupplementaires.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn3,
            glColumn4});
            this.m_wndListeChampsSupplementaires.ContexteUtilisation = "";
            this.m_wndListeChampsSupplementaires.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeChampsSupplementaires.EnableCustomisation = true;
            this.m_wndListeChampsSupplementaires.FocusedItem = null;
            this.m_wndListeChampsSupplementaires.FullRowSelect = true;
            this.m_wndListeChampsSupplementaires.GLGridLines = sc2i.win32.common.GLGridStyles.gridSolid;
            this.m_wndListeChampsSupplementaires.GridColor = System.Drawing.SystemColors.ControlLight;
            this.m_wndListeChampsSupplementaires.HasImages = false;
            this.m_wndListeChampsSupplementaires.HeaderHeight = 22;
            this.m_wndListeChampsSupplementaires.HeaderStyle = sc2i.win32.common.GLHeaderStyles.Normal;
            this.m_wndListeChampsSupplementaires.HeaderTextColor = System.Drawing.Color.Black;
            this.m_wndListeChampsSupplementaires.HeaderTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.m_wndListeChampsSupplementaires.HeaderVisible = true;
            this.m_wndListeChampsSupplementaires.HeaderWordWrap = false;
            this.m_wndListeChampsSupplementaires.HotColumnIndex = -1;
            this.m_wndListeChampsSupplementaires.HotItemIndex = -1;
            this.m_wndListeChampsSupplementaires.HotTracking = false;
            this.m_wndListeChampsSupplementaires.HotTrackingColor = System.Drawing.Color.LightGray;
            this.m_wndListeChampsSupplementaires.ImageList = null;
            this.m_wndListeChampsSupplementaires.ItemHeight = 17;
            this.m_wndListeChampsSupplementaires.ItemWordWrap = false;
            this.m_linkField.SetLinkField(this.m_wndListeChampsSupplementaires, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.m_wndListeChampsSupplementaires, false);
            this.m_wndListeChampsSupplementaires.ListeSource = null;
            this.m_wndListeChampsSupplementaires.Location = new System.Drawing.Point(0, 27);
            this.m_wndListeChampsSupplementaires.MaxHeight = 17;
            this.m_extModeEdition.SetModeEdition(this.m_wndListeChampsSupplementaires, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_wndListeChampsSupplementaires.Name = "m_wndListeChampsSupplementaires";
            this.m_wndListeChampsSupplementaires.SelectedTextColor = System.Drawing.Color.White;
            this.m_wndListeChampsSupplementaires.SelectionColor = System.Drawing.Color.DarkBlue;
            this.m_wndListeChampsSupplementaires.ShowBorder = true;
            this.m_wndListeChampsSupplementaires.ShowFocusRect = true;
            this.m_wndListeChampsSupplementaires.Size = new System.Drawing.Size(694, 113);
            this.m_wndListeChampsSupplementaires.SortIndex = 0;
            this.m_extStyle.SetStyleBackColor(this.m_wndListeChampsSupplementaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeChampsSupplementaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeChampsSupplementaires.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.m_wndListeChampsSupplementaires.TabIndex = 2;
            this.m_wndListeChampsSupplementaires.Text = "glacialList1";
            this.m_wndListeChampsSupplementaires.TrierAuClicSurEnteteColonne = true;
            this.m_wndListeChampsSupplementaires.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.m_wndListeChampsSupplementaires_MouseDoubleClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.m_lnkRemoveChampSupplementaire);
            this.panel3.Controls.Add(this.m_lnkEditChampSupp);
            this.panel3.Controls.Add(this.m_lnkAddChampSupplementaire);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_linkField.SetLinkField(this.panel3, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.panel3, false);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.panel3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(694, 27);
            this.m_extStyle.SetStyleBackColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel3.TabIndex = 1;
            // 
            // m_lnkRemoveChampSupplementaire
            // 
            this.m_lnkRemoveChampSupplementaire.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkRemoveChampSupplementaire.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_lnkRemoveChampSupplementaire.CustomImage")));
            this.m_lnkRemoveChampSupplementaire.CustomText = "Remove";
            this.m_lnkRemoveChampSupplementaire.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkRemoveChampSupplementaire.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_linkField.SetLinkField(this.m_lnkRemoveChampSupplementaire, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.m_lnkRemoveChampSupplementaire, false);
            this.m_lnkRemoveChampSupplementaire.Location = new System.Drawing.Point(484, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lnkRemoveChampSupplementaire, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkRemoveChampSupplementaire.Name = "m_lnkRemoveChampSupplementaire";
            this.m_lnkRemoveChampSupplementaire.ShortMode = false;
            this.m_lnkRemoveChampSupplementaire.Size = new System.Drawing.Size(112, 27);
            this.m_extStyle.SetStyleBackColor(this.m_lnkRemoveChampSupplementaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkRemoveChampSupplementaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkRemoveChampSupplementaire.TabIndex = 1;
            this.m_lnkRemoveChampSupplementaire.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkRemoveChampSupplementaire.LinkClicked += new System.EventHandler(this.m_lnkRemoveChampSupplementaire_LinkClicked);
            // 
            // m_lnkEditChampSupp
            // 
            this.m_lnkEditChampSupp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkEditChampSupp.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_lnkEditChampSupp.CustomImage")));
            this.m_lnkEditChampSupp.CustomText = "Detail";
            this.m_lnkEditChampSupp.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkEditChampSupp.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_linkField.SetLinkField(this.m_lnkEditChampSupp, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.m_lnkEditChampSupp, false);
            this.m_lnkEditChampSupp.Location = new System.Drawing.Point(372, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lnkEditChampSupp, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkEditChampSupp.Name = "m_lnkEditChampSupp";
            this.m_lnkEditChampSupp.ShortMode = false;
            this.m_lnkEditChampSupp.Size = new System.Drawing.Size(112, 27);
            this.m_extStyle.SetStyleBackColor(this.m_lnkEditChampSupp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkEditChampSupp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkEditChampSupp.TabIndex = 3;
            this.m_lnkEditChampSupp.TypeLien = sc2i.win32.common.TypeLinkStd.Modification;
            this.m_lnkEditChampSupp.LinkClicked += new System.EventHandler(this.m_lnkEditChampSupp_LinkClicked);
            // 
            // m_lnkAddChampSupplementaire
            // 
            this.m_lnkAddChampSupplementaire.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAddChampSupplementaire.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_lnkAddChampSupplementaire.CustomImage")));
            this.m_lnkAddChampSupplementaire.CustomText = "Add";
            this.m_lnkAddChampSupplementaire.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkAddChampSupplementaire.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_linkField.SetLinkField(this.m_lnkAddChampSupplementaire, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.m_lnkAddChampSupplementaire, false);
            this.m_lnkAddChampSupplementaire.Location = new System.Drawing.Point(260, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lnkAddChampSupplementaire, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkAddChampSupplementaire.Name = "m_lnkAddChampSupplementaire";
            this.m_lnkAddChampSupplementaire.ShortMode = false;
            this.m_lnkAddChampSupplementaire.Size = new System.Drawing.Size(112, 27);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAddChampSupplementaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAddChampSupplementaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAddChampSupplementaire.TabIndex = 0;
            this.m_lnkAddChampSupplementaire.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAddChampSupplementaire.LinkClicked += new System.EventHandler(this.m_lnkAddChampSupplementaires_LinkClicked);
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Left;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_linkField.SetLinkField(this.label9, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.label9, false);
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.label9, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(260, 27);
            this.m_extStyle.SetStyleBackColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label9.TabIndex = 2;
            this.label9.Text = "Additionnal fields|20073";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.m_chkUpdateIpInTimos);
            this.tabPage4.Controls.Add(this.m_chkUpdateIPOnMediation);
            this.tabPage4.Controls.Add(this.m_txtFormuleCleSpecifiqueAgent);
            this.tabPage4.Controls.Add(this.label12);
            this.m_linkField.SetLinkField(this.tabPage4, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.tabPage4, false);
            this.tabPage4.Location = new System.Drawing.Point(0, 25);
            this.m_extModeEdition.SetModeEdition(this.tabPage4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(694, 286);
            this.m_extStyle.SetStyleBackColor(this.tabPage4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage4.TabIndex = 13;
            this.tabPage4.Title = "Agent identification|20131";
            // 
            // m_linkField
            // 
            this.m_linkField.SourceTypeString = "";
            // 
            // m_txtFormuleCleSpecifiqueAgent
            // 
            this.m_txtFormuleCleSpecifiqueAgent.AllowGraphic = true;
            this.m_txtFormuleCleSpecifiqueAgent.AllowNullFormula = false;
            this.m_txtFormuleCleSpecifiqueAgent.AllowSaisieTexte = true;
            this.m_txtFormuleCleSpecifiqueAgent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormuleCleSpecifiqueAgent.Formule = null;
            this.m_linkField.SetLinkField(this.m_txtFormuleCleSpecifiqueAgent, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.m_txtFormuleCleSpecifiqueAgent, false);
            this.m_txtFormuleCleSpecifiqueAgent.Location = new System.Drawing.Point(16, 32);
            this.m_txtFormuleCleSpecifiqueAgent.LockEdition = false;
            this.m_txtFormuleCleSpecifiqueAgent.LockZoneTexte = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtFormuleCleSpecifiqueAgent, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtFormuleCleSpecifiqueAgent.Name = "m_txtFormuleCleSpecifiqueAgent";
            this.m_txtFormuleCleSpecifiqueAgent.Size = new System.Drawing.Size(661, 86);
            this.m_extStyle.SetStyleBackColor(this.m_txtFormuleCleSpecifiqueAgent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFormuleCleSpecifiqueAgent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleCleSpecifiqueAgent.TabIndex = 12;
            // 
            // label12
            // 
            this.m_linkField.SetLinkField(this.label12, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.label12, false);
            this.label12.Location = new System.Drawing.Point(13, 9);
            this.m_extModeEdition.SetModeEdition(this.label12, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(419, 20);
            this.m_extStyle.SetStyleBackColor(this.label12, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label12, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label12.TabIndex = 11;
            this.label12.Text = "Formula returning Specific Identification Key for Agent|10421";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_chkUpdateIPOnMediation
            // 
            this.m_chkUpdateIPOnMediation.AutoSize = true;
            this.m_linkField.SetLinkField(this.m_chkUpdateIPOnMediation, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.m_chkUpdateIPOnMediation, true);
            this.m_chkUpdateIPOnMediation.Location = new System.Drawing.Point(16, 125);
            this.m_extModeEdition.SetModeEdition(this.m_chkUpdateIPOnMediation, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_chkUpdateIPOnMediation.Name = "m_chkUpdateIPOnMediation";
            this.m_chkUpdateIPOnMediation.Size = new System.Drawing.Size(321, 19);
            this.m_extStyle.SetStyleBackColor(this.m_chkUpdateIPOnMediation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkUpdateIPOnMediation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkUpdateIPOnMediation.TabIndex = 13;
            this.m_chkUpdateIPOnMediation.Text = "Automatic update Agent IP on mediation services|20132";
            this.m_chkUpdateIPOnMediation.UseVisualStyleBackColor = true;
            // 
            // m_chkUpdateIpInTimos
            // 
            this.m_chkUpdateIpInTimos.AutoSize = true;
            this.m_linkField.SetLinkField(this.m_chkUpdateIpInTimos, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.m_chkUpdateIpInTimos, false);
            this.m_chkUpdateIpInTimos.Location = new System.Drawing.Point(16, 150);
            this.m_extModeEdition.SetModeEdition(this.m_chkUpdateIpInTimos, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_chkUpdateIpInTimos.Name = "m_chkUpdateIpInTimos";
            this.m_chkUpdateIpInTimos.Size = new System.Drawing.Size(307, 19);
            this.m_extStyle.SetStyleBackColor(this.m_chkUpdateIpInTimos, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkUpdateIpInTimos, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkUpdateIpInTimos.TabIndex = 14;
            this.m_chkUpdateIpInTimos.Text = "Automatic update Agent IP on Timos Database|20133";
            this.m_chkUpdateIpInTimos.UseVisualStyleBackColor = true;
            // 
            // CPanelEditAgentFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.m_txtDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_txtNom);
            this.ForeColor = System.Drawing.Color.Black;
            this.m_linkField.SetLinkField(this, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this, false);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CPanelEditAgentFinder";
            this.Size = new System.Drawing.Size(694, 402);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private sc2i.win32.common.CExtStyle m_extStyle;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
        private System.Windows.Forms.Label label1;
        private sc2i.win32.common.CExtLinkField m_linkField;
        private sc2i.win32.common.C2iTextBox m_txtNom;
        private sc2i.win32.common.C2iTextBox m_txtDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private sc2i.win32.common.C2iTextBox c2iTextBox3;
        private System.Windows.Forms.Label label5;
        private sc2i.win32.common.C2iTextBox c2iTextBox4;
        private sc2i.win32.common.C2iTextBox c2iTextBox5;
        private System.Windows.Forms.ComboBox m_cmbGenericCode;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleCondition;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private sc2i.win32.common.C2iTabControl m_tabControl;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private Crownwood.Magic.Controls.TabPage tabPage3;
        private sc2i.win32.common.GlacialList m_wndListeChamps;
        private System.Windows.Forms.Panel panel1;
        private sc2i.win32.common.CWndLinkStd m_lnkRemoveChamp;
        private sc2i.win32.common.CWndLinkStd m_lnkAddChamp;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label8;
        private sc2i.win32.common.GlacialList m_wndListeChampsSupplementaires;
        private System.Windows.Forms.Panel panel3;
        private sc2i.win32.common.CWndLinkStd m_lnkRemoveChampSupplementaire;
        private sc2i.win32.common.CWndLinkStd m_lnkAddChampSupplementaire;
        private System.Windows.Forms.Label label9;
        private Crownwood.Magic.Controls.TabPage tabPage4;
        private sc2i.win32.common.CWndLinkStd m_lnkDetailChampTrap;
        private sc2i.win32.common.CWndLinkStd m_lnkEditChampSupp;
        private System.Windows.Forms.CheckBox m_chkUpdateIPOnMediation;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleCleSpecifiqueAgent;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox m_chkUpdateIpInTimos;
    }
}
