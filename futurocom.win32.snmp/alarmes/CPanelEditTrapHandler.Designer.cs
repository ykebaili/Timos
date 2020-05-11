namespace futurocom.win32.snmp.alarmes
{
    partial class CPanelEditTrapHandler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPanelEditTrapHandler));
            sc2i.win32.common.GLColumn glColumn8 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn9 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn10 = new sc2i.win32.common.GLColumn();
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
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.m_wndListeCreations = new sc2i.win32.common.GlacialList();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_lnkDupliqueCreator = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkRemoveCreation = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkDetailCreateur = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkAddCreation = new sc2i.win32.common.CWndLinkStd();
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
            this.m_editeurPreTraitement = new sc2i.win32.expression.CEditeurExpressionGraphique();
            this.panel4 = new System.Windows.Forms.Panel();
            this.m_txtFormuleIndexEntite = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.label11 = new System.Windows.Forms.Label();
            this.m_cmbTypeEntite = new sc2i.win32.common.CComboboxAutoFilled();
            this.label10 = new System.Windows.Forms.Label();
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_linkField = new sc2i.win32.common.CExtLinkField();
            this.m_tabControl.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel4.SuspendLayout();
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
            this.m_txtNom.Size = new System.Drawing.Size(536, 20);
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
            this.m_txtDescription.Size = new System.Drawing.Size(536, 51);
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
            this.c2iTextBox3.Size = new System.Drawing.Size(355, 21);
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
            this.c2iTextBox4.Size = new System.Drawing.Size(355, 21);
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
            this.m_cmbGenericCode.Size = new System.Drawing.Size(217, 21);
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
            this.c2iTextBox5.Size = new System.Drawing.Size(355, 21);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox5.TabIndex = 8;
            this.c2iTextBox5.Text = "[SpecificRequestedValue]";
            // 
            // label6
            // 
            this.m_linkField.SetLinkField(this.label6, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.label6, false);
            this.label6.Location = new System.Drawing.Point(13, 119);
            this.m_extModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 20);
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
            this.m_txtFormuleCondition.Size = new System.Drawing.Size(354, 20);
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
            this.m_tabControl.SelectedIndex = 3;
            this.m_tabControl.SelectedTab = this.tabPage2;
            this.m_tabControl.Size = new System.Drawing.Size(690, 311);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 10;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage3,
            this.tabPage4,
            this.tabPage2});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            this.m_tabControl.SelectionChanged += new System.EventHandler(this.m_tabControl_SelectionChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.m_wndListeCreations);
            this.tabPage2.Controls.Add(this.panel2);
            this.m_linkField.SetLinkField(this.tabPage2, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.tabPage2, false);
            this.tabPage2.Location = new System.Drawing.Point(0, 25);
            this.m_extModeEdition.SetModeEdition(this.tabPage2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(690, 286);
            this.m_extStyle.SetStyleBackColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage2.TabIndex = 11;
            this.tabPage2.Title = "Alarm creation|20061";
            // 
            // m_wndListeCreations
            // 
            this.m_wndListeCreations.AllowColumnResize = true;
            this.m_wndListeCreations.AllowMultiselect = false;
            this.m_wndListeCreations.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.m_wndListeCreations.AlternatingColors = false;
            this.m_wndListeCreations.AutoHeight = true;
            this.m_wndListeCreations.AutoSort = true;
            this.m_wndListeCreations.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.m_wndListeCreations.CanChangeActivationCheckBoxes = false;
            this.m_wndListeCreations.CheckBoxes = false;
            this.m_wndListeCreations.CheckedItems = ((System.Collections.ArrayList)(resources.GetObject("m_wndListeCreations.CheckedItems")));
            glColumn8.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn8.ActiveControlItems")));
            glColumn8.BackColor = System.Drawing.Color.Transparent;
            glColumn8.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn8.ForColor = System.Drawing.Color.Black;
            glColumn8.ImageIndex = -1;
            glColumn8.IsCheckColumn = false;
            glColumn8.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn8.Name = "m_colCode";
            glColumn8.Propriete = "Code";
            glColumn8.Text = "Code|20075";
            glColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn8.Width = 100;
            glColumn9.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn9.ActiveControlItems")));
            glColumn9.BackColor = System.Drawing.Color.Transparent;
            glColumn9.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn9.ForColor = System.Drawing.Color.Black;
            glColumn9.ImageIndex = -1;
            glColumn9.IsCheckColumn = false;
            glColumn9.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn9.Name = "Column2";
            glColumn9.Propriete = "Libelle";
            glColumn9.Text = "Creator label|20075";
            glColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn9.Width = 250;
            glColumn10.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn10.ActiveControlItems")));
            glColumn10.BackColor = System.Drawing.Color.Transparent;
            glColumn10.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn10.ForColor = System.Drawing.Color.Black;
            glColumn10.ImageIndex = -1;
            glColumn10.IsCheckColumn = false;
            glColumn10.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn10.Name = "m_colLibelleType";
            glColumn10.Propriete = "TypeAlarme.Libelle";
            glColumn10.Text = "Created alarm type|20004";
            glColumn10.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn10.Width = 300;
            this.m_wndListeCreations.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn8,
            glColumn9,
            glColumn10});
            this.m_wndListeCreations.ContexteUtilisation = "";
            this.m_wndListeCreations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeCreations.EnableCustomisation = true;
            this.m_wndListeCreations.FocusedItem = null;
            this.m_wndListeCreations.FullRowSelect = true;
            this.m_wndListeCreations.GLGridLines = sc2i.win32.common.GLGridStyles.gridSolid;
            this.m_wndListeCreations.GridColor = System.Drawing.SystemColors.ControlLight;
            this.m_wndListeCreations.HasImages = false;
            this.m_wndListeCreations.HeaderHeight = 22;
            this.m_wndListeCreations.HeaderStyle = sc2i.win32.common.GLHeaderStyles.Normal;
            this.m_wndListeCreations.HeaderTextColor = System.Drawing.Color.Black;
            this.m_wndListeCreations.HeaderTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.m_wndListeCreations.HeaderVisible = true;
            this.m_wndListeCreations.HeaderWordWrap = false;
            this.m_wndListeCreations.HotColumnIndex = -1;
            this.m_wndListeCreations.HotItemIndex = -1;
            this.m_wndListeCreations.HotTracking = false;
            this.m_wndListeCreations.HotTrackingColor = System.Drawing.Color.LightGray;
            this.m_wndListeCreations.ImageList = null;
            this.m_wndListeCreations.ItemHeight = 17;
            this.m_wndListeCreations.ItemWordWrap = false;
            this.m_linkField.SetLinkField(this.m_wndListeCreations, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.m_wndListeCreations, false);
            this.m_wndListeCreations.ListeSource = null;
            this.m_wndListeCreations.Location = new System.Drawing.Point(0, 27);
            this.m_wndListeCreations.MaxHeight = 17;
            this.m_extModeEdition.SetModeEdition(this.m_wndListeCreations, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_wndListeCreations.Name = "m_wndListeCreations";
            this.m_wndListeCreations.SelectedTextColor = System.Drawing.Color.White;
            this.m_wndListeCreations.SelectionColor = System.Drawing.Color.DarkBlue;
            this.m_wndListeCreations.ShowBorder = true;
            this.m_wndListeCreations.ShowFocusRect = true;
            this.m_wndListeCreations.Size = new System.Drawing.Size(690, 259);
            this.m_wndListeCreations.SortIndex = 0;
            this.m_extStyle.SetStyleBackColor(this.m_wndListeCreations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeCreations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeCreations.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.m_wndListeCreations.TabIndex = 2;
            this.m_wndListeCreations.Text = "glacialList1";
            this.m_wndListeCreations.TrierAuClicSurEnteteColonne = true;
            this.m_wndListeCreations.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.m_wndListeCreations_MouseDoubleClick);
            this.m_wndListeCreations.OnChangeSelection += new System.EventHandler(this.m_wndListeCreations_OnChangeSelection);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_lnkDupliqueCreator);
            this.panel2.Controls.Add(this.m_lnkRemoveCreation);
            this.panel2.Controls.Add(this.m_lnkDetailCreateur);
            this.panel2.Controls.Add(this.m_lnkAddCreation);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_linkField.SetLinkField(this.panel2, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.panel2, false);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(690, 27);
            this.m_extStyle.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel2.TabIndex = 1;
            // 
            // m_lnkDupliqueCreator
            // 
            this.m_lnkDupliqueCreator.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkDupliqueCreator.CustomImage = global::futurocom.win32.snmp.Properties.Resources.Duplicate;
            this.m_lnkDupliqueCreator.CustomText = "Duplicate|20124";
            this.m_lnkDupliqueCreator.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkDupliqueCreator.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_linkField.SetLinkField(this.m_lnkDupliqueCreator, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.m_lnkDupliqueCreator, false);
            this.m_lnkDupliqueCreator.Location = new System.Drawing.Point(336, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lnkDupliqueCreator, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lnkDupliqueCreator.Name = "m_lnkDupliqueCreator";
            this.m_lnkDupliqueCreator.ShortMode = false;
            this.m_lnkDupliqueCreator.Size = new System.Drawing.Size(112, 27);
            this.m_extStyle.SetStyleBackColor(this.m_lnkDupliqueCreator, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkDupliqueCreator, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkDupliqueCreator.TabIndex = 3;
            this.m_lnkDupliqueCreator.TypeLien = sc2i.win32.common.TypeLinkStd.Custom;
            this.m_lnkDupliqueCreator.LinkClicked += new System.EventHandler(this.m_lnkDupliqueCreator_LinkClicked);
            // 
            // m_lnkRemoveCreation
            // 
            this.m_lnkRemoveCreation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkRemoveCreation.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_lnkRemoveCreation.CustomImage")));
            this.m_lnkRemoveCreation.CustomText = "Remove";
            this.m_lnkRemoveCreation.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkRemoveCreation.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_linkField.SetLinkField(this.m_lnkRemoveCreation, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.m_lnkRemoveCreation, false);
            this.m_lnkRemoveCreation.Location = new System.Drawing.Point(224, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lnkRemoveCreation, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkRemoveCreation.Name = "m_lnkRemoveCreation";
            this.m_lnkRemoveCreation.ShortMode = false;
            this.m_lnkRemoveCreation.Size = new System.Drawing.Size(112, 27);
            this.m_extStyle.SetStyleBackColor(this.m_lnkRemoveCreation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkRemoveCreation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkRemoveCreation.TabIndex = 1;
            this.m_lnkRemoveCreation.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkRemoveCreation.LinkClicked += new System.EventHandler(this.m_lnkRemoveCreation_LinkClicked);
            // 
            // m_lnkDetailCreateur
            // 
            this.m_lnkDetailCreateur.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkDetailCreateur.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_lnkDetailCreateur.CustomImage")));
            this.m_lnkDetailCreateur.CustomText = "Detail";
            this.m_lnkDetailCreateur.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkDetailCreateur.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_linkField.SetLinkField(this.m_lnkDetailCreateur, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.m_lnkDetailCreateur, false);
            this.m_lnkDetailCreateur.Location = new System.Drawing.Point(112, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lnkDetailCreateur, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkDetailCreateur.Name = "m_lnkDetailCreateur";
            this.m_lnkDetailCreateur.ShortMode = false;
            this.m_lnkDetailCreateur.Size = new System.Drawing.Size(112, 27);
            this.m_extStyle.SetStyleBackColor(this.m_lnkDetailCreateur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkDetailCreateur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkDetailCreateur.TabIndex = 2;
            this.m_lnkDetailCreateur.TypeLien = sc2i.win32.common.TypeLinkStd.Modification;
            this.m_lnkDetailCreateur.LinkClicked += new System.EventHandler(this.m_lnkDetailCreateur_LinkClicked);
            // 
            // m_lnkAddCreation
            // 
            this.m_lnkAddCreation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAddCreation.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_lnkAddCreation.CustomImage")));
            this.m_lnkAddCreation.CustomText = "Add";
            this.m_lnkAddCreation.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkAddCreation.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_linkField.SetLinkField(this.m_lnkAddCreation, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.m_lnkAddCreation, false);
            this.m_lnkAddCreation.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lnkAddCreation, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkAddCreation.Name = "m_lnkAddCreation";
            this.m_lnkAddCreation.ShortMode = false;
            this.m_lnkAddCreation.Size = new System.Drawing.Size(112, 27);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAddCreation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAddCreation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAddCreation.TabIndex = 0;
            this.m_lnkAddCreation.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAddCreation.LinkClicked += new System.EventHandler(this.m_lnkAddCreation_LinkClicked);
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
            this.tabPage1.Size = new System.Drawing.Size(690, 286);
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
            this.tabPage3.Size = new System.Drawing.Size(690, 286);
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
            this.splitContainer1.Size = new System.Drawing.Size(690, 286);
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
            this.m_wndListeChamps.Size = new System.Drawing.Size(690, 115);
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
            this.panel1.Size = new System.Drawing.Size(690, 27);
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
            this.m_wndListeChampsSupplementaires.Size = new System.Drawing.Size(690, 113);
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
            this.panel3.Size = new System.Drawing.Size(690, 27);
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
            this.tabPage4.Controls.Add(this.m_editeurPreTraitement);
            this.tabPage4.Controls.Add(this.panel4);
            this.m_linkField.SetLinkField(this.tabPage4, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.tabPage4, false);
            this.tabPage4.Location = new System.Drawing.Point(0, 25);
            this.m_extModeEdition.SetModeEdition(this.tabPage4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Selected = false;
            this.tabPage4.Size = new System.Drawing.Size(690, 286);
            this.m_extStyle.SetStyleBackColor(this.tabPage4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage4.TabIndex = 13;
            this.tabPage4.Title = "Trap pretreatment|20074";
            // 
            // m_editeurPreTraitement
            // 
            this.m_editeurPreTraitement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_linkField.SetLinkField(this.m_editeurPreTraitement, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.m_editeurPreTraitement, false);
            this.m_editeurPreTraitement.Location = new System.Drawing.Point(0, 28);
            this.m_extModeEdition.SetModeEdition(this.m_editeurPreTraitement, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_editeurPreTraitement.Name = "m_editeurPreTraitement";
            this.m_editeurPreTraitement.Size = new System.Drawing.Size(690, 258);
            this.m_extStyle.SetStyleBackColor(this.m_editeurPreTraitement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_editeurPreTraitement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_editeurPreTraitement.TabIndex = 14;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.m_txtFormuleIndexEntite);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.m_cmbTypeEntite);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_linkField.SetLinkField(this.panel4, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.panel4, false);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.panel4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(690, 28);
            this.m_extStyle.SetStyleBackColor(this.panel4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel4.TabIndex = 15;
            // 
            // m_txtFormuleIndexEntite
            // 
            this.m_txtFormuleIndexEntite.AllowGraphic = true;
            this.m_txtFormuleIndexEntite.AllowNullFormula = false;
            this.m_txtFormuleIndexEntite.AllowSaisieTexte = true;
            this.m_txtFormuleIndexEntite.Formule = null;
            this.m_linkField.SetLinkField(this.m_txtFormuleIndexEntite, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.m_txtFormuleIndexEntite, false);
            this.m_txtFormuleIndexEntite.Location = new System.Drawing.Point(481, 4);
            this.m_txtFormuleIndexEntite.LockEdition = false;
            this.m_txtFormuleIndexEntite.LockZoneTexte = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtFormuleIndexEntite, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtFormuleIndexEntite.Name = "m_txtFormuleIndexEntite";
            this.m_txtFormuleIndexEntite.Size = new System.Drawing.Size(206, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtFormuleIndexEntite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFormuleIndexEntite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleIndexEntite.TabIndex = 4;
            // 
            // label11
            // 
            this.m_linkField.SetLinkField(this.label11, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.label11, false);
            this.label11.Location = new System.Drawing.Point(383, 4);
            this.m_extModeEdition.SetModeEdition(this.label11, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 21);
            this.m_extStyle.SetStyleBackColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label11.TabIndex = 3;
            this.label11.Text = "Index|20104";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_cmbTypeEntite
            // 
            this.m_cmbTypeEntite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTypeEntite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbTypeEntite.FormattingEnabled = true;
            this.m_cmbTypeEntite.IsLink = false;
            this.m_linkField.SetLinkField(this.m_cmbTypeEntite, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.m_cmbTypeEntite, false);
            this.m_cmbTypeEntite.ListDonnees = null;
            this.m_cmbTypeEntite.Location = new System.Drawing.Point(179, 5);
            this.m_cmbTypeEntite.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_cmbTypeEntite, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_cmbTypeEntite.Name = "m_cmbTypeEntite";
            this.m_cmbTypeEntite.NullAutorise = true;
            this.m_cmbTypeEntite.ProprieteAffichee = "Libelle";
            this.m_cmbTypeEntite.Size = new System.Drawing.Size(198, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbTypeEntite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbTypeEntite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbTypeEntite.TabIndex = 2;
            this.m_cmbTypeEntite.TextNull = "(empty)";
            this.m_cmbTypeEntite.Tri = true;
            // 
            // label10
            // 
            this.m_linkField.SetLinkField(this.label10, "");
            this.m_linkField.SetLinkFieldAutoUpdate(this.label10, false);
            this.label10.Location = new System.Drawing.Point(7, 4);
            this.m_extModeEdition.SetModeEdition(this.label10, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(166, 21);
            this.m_extStyle.SetStyleBackColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label10.TabIndex = 0;
            this.label10.Text = "Associated entity type|20103";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_linkField
            // 
            this.m_linkField.SourceTypeString = "";
            // 
            // CPanelEditTrapHandler
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
            this.Name = "CPanelEditTrapHandler";
            this.Size = new System.Drawing.Size(690, 402);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
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
        private Crownwood.Magic.Controls.TabPage tabPage2;
        private Crownwood.Magic.Controls.TabPage tabPage3;
        private sc2i.win32.common.GlacialList m_wndListeChamps;
        private System.Windows.Forms.Panel panel1;
        private sc2i.win32.common.CWndLinkStd m_lnkRemoveChamp;
        private sc2i.win32.common.CWndLinkStd m_lnkAddChamp;
        private sc2i.win32.common.GlacialList m_wndListeCreations;
        private System.Windows.Forms.Panel panel2;
        private sc2i.win32.common.CWndLinkStd m_lnkRemoveCreation;
        private sc2i.win32.common.CWndLinkStd m_lnkAddCreation;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label8;
        private sc2i.win32.common.GlacialList m_wndListeChampsSupplementaires;
        private System.Windows.Forms.Panel panel3;
        private sc2i.win32.common.CWndLinkStd m_lnkRemoveChampSupplementaire;
        private sc2i.win32.common.CWndLinkStd m_lnkAddChampSupplementaire;
        private System.Windows.Forms.Label label9;
        private Crownwood.Magic.Controls.TabPage tabPage4;
        private sc2i.win32.expression.CEditeurExpressionGraphique m_editeurPreTraitement;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label10;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleIndexEntite;
        private System.Windows.Forms.Label label11;
        private sc2i.win32.common.CComboboxAutoFilled m_cmbTypeEntite;
        private sc2i.win32.common.CWndLinkStd m_lnkDetailChampTrap;
        private sc2i.win32.common.CWndLinkStd m_lnkEditChampSupp;
        private sc2i.win32.common.CWndLinkStd m_lnkDetailCreateur;
        private sc2i.win32.common.CWndLinkStd m_lnkDupliqueCreator;
    }
}
