using timos.projet.besoin;
namespace timos.projet
{
    partial class CFormQuickEditProjet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_panTop = new sc2i.win32.common.C2iPanelOmbre();
            this.m_lnkSubTypes = new System.Windows.Forms.LinkLabel();
            this.m_selectTypeProjet = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.m_lblProject = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.m_lnkDroits = new System.Windows.Forms.LinkLabel();
            this.m_lblTypeTable = new System.Windows.Forms.Label();
            this.m_dtpDateDebutReelle = new sc2i.win32.common.C2iDateTimeExPicker();
            this.m_lblDateDebut = new System.Windows.Forms.Label();
            this.m_dtpDateFinReelle = new sc2i.win32.common.C2iDateTimeExPicker();
            this.m_dtpDatesPrevisionnelles = new timos.win32.composants.CDateTimePickerForContextMenu();
            this.m_lblDateFin = new System.Windows.Forms.Label();
            this.m_chkDatesAuto = new System.Windows.Forms.CheckBox();
            this.m_TabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_tabPageFormulaire = new Crownwood.Magic.Controls.TabPage();
            this.m_PanelChamps = new sc2i.win32.data.dynamic.CPanelChampsCustom();
            this.m_pageInformations = new Crownwood.Magic.Controls.TabPage();
            this.m_panelBesoins = new System.Windows.Forms.Panel();
            this.m_wndSpecifications = new timos.projet.besoin.CControleListeBesoins();
            this.m_panelHautBesoin = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_lblDescription = new System.Windows.Forms.Label();
            this.m_txtDescrip = new sc2i.win32.common.C2iTextBox();
            this.m_menuSousTypes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_extLinkField = new sc2i.win32.common.CExtLinkField();
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.m_extModulesAssociator = new timos.CExtModulesAssociator();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.m_panTop.SuspendLayout();
            this.m_TabControl.SuspendLayout();
            this.m_tabPageFormulaire.SuspendLayout();
            this.m_pageInformations.SuspendLayout();
            this.m_panelBesoins.SuspendLayout();
            this.m_panelHautBesoin.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_panTop);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.panel1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.panel1, false);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel1, "");
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(913, 127);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 0;
            // 
            // m_panTop
            // 
            this.m_panTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panTop.Controls.Add(this.m_lnkSubTypes);
            this.m_panTop.Controls.Add(this.m_selectTypeProjet);
            this.m_panTop.Controls.Add(this.m_lblProject);
            this.m_panTop.Controls.Add(this.m_txtLibelle);
            this.m_panTop.Controls.Add(this.m_lnkDroits);
            this.m_panTop.Controls.Add(this.m_lblTypeTable);
            this.m_panTop.Controls.Add(this.m_dtpDateDebutReelle);
            this.m_panTop.Controls.Add(this.m_lblDateDebut);
            this.m_panTop.Controls.Add(this.m_dtpDateFinReelle);
            this.m_panTop.Controls.Add(this.m_dtpDatesPrevisionnelles);
            this.m_panTop.Controls.Add(this.m_lblDateFin);
            this.m_panTop.Controls.Add(this.m_chkDatesAuto);
            this.m_panTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panTop.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panTop, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panTop, false);
            this.m_panTop.Location = new System.Drawing.Point(0, 0);
            this.m_panTop.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panTop, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panTop, "");
            this.m_panTop.Name = "m_panTop";
            this.m_panTop.Size = new System.Drawing.Size(913, 127);
            this.m_extStyle.SetStyleBackColor(this.m_panTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panTop.TabIndex = 1;
            // 
            // m_lnkSubTypes
            // 
            this.m_lnkSubTypes.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lnkSubTypes, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkSubTypes, false);
            this.m_lnkSubTypes.Location = new System.Drawing.Point(352, 26);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkSubTypes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkSubTypes, "");
            this.m_lnkSubTypes.Name = "m_lnkSubTypes";
            this.m_lnkSubTypes.Size = new System.Drawing.Size(87, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSubTypes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSubTypes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSubTypes.TabIndex = 4022;
            this.m_lnkSubTypes.TabStop = true;
            this.m_lnkSubTypes.Text = "SubTypes|20585";
            this.m_lnkSubTypes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkSubTypes_LinkClicked);
            // 
            // m_selectTypeProjet
            // 
            this.m_selectTypeProjet.ComportementLinkStd = true;
            this.m_selectTypeProjet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_selectTypeProjet.ElementSelectionne = null;
            this.m_selectTypeProjet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_selectTypeProjet.FormattingEnabled = true;
            this.m_selectTypeProjet.IsLink = true;
            this.m_extLinkField.SetLinkField(this.m_selectTypeProjet, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_selectTypeProjet, false);
            this.m_selectTypeProjet.LinkProperty = "";
            this.m_selectTypeProjet.ListDonnees = null;
            this.m_selectTypeProjet.Location = new System.Drawing.Point(123, 22);
            this.m_selectTypeProjet.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_selectTypeProjet, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_selectTypeProjet, "");
            this.m_selectTypeProjet.Name = "m_selectTypeProjet";
            this.m_selectTypeProjet.NullAutorise = false;
            this.m_selectTypeProjet.ProprieteAffichee = null;
            this.m_selectTypeProjet.ProprieteParentListeObjets = null;
            this.m_selectTypeProjet.SelectionneurParent = null;
            this.m_selectTypeProjet.Size = new System.Drawing.Size(222, 21);
            this.m_extStyle.SetStyleBackColor(this.m_selectTypeProjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_selectTypeProjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectTypeProjet.TabIndex = 4019;
            this.m_selectTypeProjet.TextNull = "(empty)";
            this.m_selectTypeProjet.Tri = true;
            this.m_selectTypeProjet.TypeFormEdition = null;
            // 
            // m_lblProject
            // 
            this.m_lblProject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_lblProject.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_lblProject, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblProject, false);
            this.m_lblProject.Location = new System.Drawing.Point(6, 5);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblProject, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblProject, "");
            this.m_lblProject.Name = "m_lblProject";
            this.m_lblProject.Size = new System.Drawing.Size(108, 17);
            this.m_extStyle.SetStyleBackColor(this.m_lblProject, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblProject, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblProject.TabIndex = 4005;
            this.m_lblProject.Text = "Project label |745";
            // 
            // m_txtLibelle
            // 
            this.m_txtLibelle.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtLibelle, true);
            this.m_txtLibelle.Location = new System.Drawing.Point(123, 2);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(620, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Libelle]";
            // 
            // m_lnkDroits
            // 
            this.m_lnkDroits.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lnkDroits, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkDroits, false);
            this.m_lnkDroits.Location = new System.Drawing.Point(530, 95);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkDroits, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkDroits, "");
            this.m_lnkDroits.Name = "m_lnkDroits";
            this.m_lnkDroits.Size = new System.Drawing.Size(69, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkDroits, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkDroits, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkDroits.TabIndex = 4021;
            this.m_lnkDroits.TabStop = true;
            this.m_lnkDroits.Text = "Rights|20541";
            this.m_lnkDroits.Visible = false;
            // 
            // m_lblTypeTable
            // 
            this.m_extLinkField.SetLinkField(this.m_lblTypeTable, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblTypeTable, false);
            this.m_lblTypeTable.Location = new System.Drawing.Point(6, 27);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblTypeTable, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblTypeTable, "");
            this.m_lblTypeTable.Name = "m_lblTypeTable";
            this.m_lblTypeTable.Size = new System.Drawing.Size(117, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblTypeTable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblTypeTable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblTypeTable.TabIndex = 4016;
            this.m_lblTypeTable.Text = "Project Type|1215";
            // 
            // m_dtpDateDebutReelle
            // 
            this.m_dtpDateDebutReelle.Checked = true;
            this.m_dtpDateDebutReelle.CustomFormat = "dd/MM/yyyy HH:mm";
            this.m_dtpDateDebutReelle.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_extLinkField.SetLinkField(this.m_dtpDateDebutReelle, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_dtpDateDebutReelle, false);
            this.m_dtpDateDebutReelle.Location = new System.Drawing.Point(395, 45);
            this.m_dtpDateDebutReelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_dtpDateDebutReelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_dtpDateDebutReelle, "");
            this.m_dtpDateDebutReelle.Name = "m_dtpDateDebutReelle";
            this.m_dtpDateDebutReelle.Size = new System.Drawing.Size(130, 20);
            this.m_extStyle.SetStyleBackColor(this.m_dtpDateDebutReelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_dtpDateDebutReelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_dtpDateDebutReelle.TabIndex = 2;
            this.m_dtpDateDebutReelle.TextNull = "None";
            this.m_dtpDateDebutReelle.Value.DateTimeValue = new System.DateTime(2014, 2, 21, 12, 10, 4, 934);
            // 
            // m_lblDateDebut
            // 
            this.m_lblDateDebut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_lblDateDebut.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_lblDateDebut, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblDateDebut, false);
            this.m_lblDateDebut.Location = new System.Drawing.Point(286, 47);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblDateDebut, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblDateDebut, "");
            this.m_lblDateDebut.Name = "m_lblDateDebut";
            this.m_lblDateDebut.Size = new System.Drawing.Size(120, 17);
            this.m_extStyle.SetStyleBackColor(this.m_lblDateDebut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblDateDebut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblDateDebut.TabIndex = 4005;
            this.m_lblDateDebut.Text = "True start date|10075";
            this.m_lblDateDebut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_dtpDateFinReelle
            // 
            this.m_dtpDateFinReelle.Checked = true;
            this.m_dtpDateFinReelle.CustomFormat = "dd/MM/yyyy HH:mm";
            this.m_dtpDateFinReelle.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_extLinkField.SetLinkField(this.m_dtpDateFinReelle, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_dtpDateFinReelle, false);
            this.m_dtpDateFinReelle.Location = new System.Drawing.Point(395, 66);
            this.m_dtpDateFinReelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_dtpDateFinReelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_dtpDateFinReelle, "");
            this.m_dtpDateFinReelle.Name = "m_dtpDateFinReelle";
            this.m_dtpDateFinReelle.Size = new System.Drawing.Size(130, 20);
            this.m_extStyle.SetStyleBackColor(this.m_dtpDateFinReelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_dtpDateFinReelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_dtpDateFinReelle.TabIndex = 3;
            this.m_dtpDateFinReelle.TextNull = "None";
            this.m_dtpDateFinReelle.Value.DateTimeValue = new System.DateTime(2014, 2, 21, 12, 10, 4, 964);
            // 
            // m_dtpDatesPrevisionnelles
            // 
            this.m_dtpDatesPrevisionnelles.BoutonValiderVisible = false;
            this.m_dtpDatesPrevisionnelles.EndDate = new System.DateTime(2010, 9, 27, 10, 28, 28, 140);
            this.m_dtpDatesPrevisionnelles.Libelle1 = "Planned start date|10078";
            this.m_dtpDatesPrevisionnelles.Libelle2 = "Planned end date|10079";
            this.m_extLinkField.SetLinkField(this.m_dtpDatesPrevisionnelles, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_dtpDatesPrevisionnelles, false);
            this.m_dtpDatesPrevisionnelles.Location = new System.Drawing.Point(9, 45);
            this.m_dtpDatesPrevisionnelles.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_dtpDatesPrevisionnelles, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_dtpDatesPrevisionnelles, "");
            this.m_dtpDatesPrevisionnelles.Name = "m_dtpDatesPrevisionnelles";
            this.m_dtpDatesPrevisionnelles.Size = new System.Drawing.Size(280, 43);
            this.m_dtpDatesPrevisionnelles.StartDate = new System.DateTime(2010, 9, 27, 10, 28, 28, 140);
            this.m_extStyle.SetStyleBackColor(this.m_dtpDatesPrevisionnelles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_dtpDatesPrevisionnelles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_dtpDatesPrevisionnelles.TabIndex = 4018;
            // 
            // m_lblDateFin
            // 
            this.m_lblDateFin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_lblDateFin.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_lblDateFin, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblDateFin, false);
            this.m_lblDateFin.Location = new System.Drawing.Point(286, 68);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblDateFin, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblDateFin, "");
            this.m_lblDateFin.Name = "m_lblDateFin";
            this.m_lblDateFin.Size = new System.Drawing.Size(120, 17);
            this.m_extStyle.SetStyleBackColor(this.m_lblDateFin, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblDateFin, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblDateFin.TabIndex = 4005;
            this.m_lblDateFin.Text = "True end date|10076";
            this.m_lblDateFin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_chkDatesAuto
            // 
            this.m_extLinkField.SetLinkField(this.m_chkDatesAuto, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_chkDatesAuto, false);
            this.m_chkDatesAuto.Location = new System.Drawing.Point(116, 88);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkDatesAuto, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkDatesAuto, "");
            this.m_chkDatesAuto.Name = "m_chkDatesAuto";
            this.m_chkDatesAuto.Size = new System.Drawing.Size(222, 24);
            this.m_extStyle.SetStyleBackColor(this.m_chkDatesAuto, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkDatesAuto, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkDatesAuto.TabIndex = 4017;
            this.m_chkDatesAuto.Text = "Automatic dates|10080";
            this.m_chkDatesAuto.UseVisualStyleBackColor = true;
            // 
            // m_TabControl
            // 
            this.m_TabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_TabControl.BoldSelectedPage = true;
            this.m_TabControl.ControlBottomOffset = 16;
            this.m_TabControl.ControlRightOffset = 16;
            this.m_TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_TabControl.ForeColor = System.Drawing.Color.Black;
            this.m_TabControl.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_TabControl, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_TabControl, false);
            this.m_TabControl.Location = new System.Drawing.Point(0, 127);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_TabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_TabControl, "");
            this.m_TabControl.Name = "m_TabControl";
            this.m_TabControl.Ombre = true;
            this.m_TabControl.PositionTop = true;
            this.m_TabControl.SelectedIndex = 0;
            this.m_TabControl.SelectedTab = this.m_tabPageFormulaire;
            this.m_TabControl.Size = new System.Drawing.Size(913, 375);
            this.m_extStyle.SetStyleBackColor(this.m_TabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_TabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_TabControl.TabIndex = 4005;
            this.m_TabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_tabPageFormulaire,
            this.m_pageInformations});
            this.m_TabControl.TextColor = System.Drawing.Color.Black;
            this.m_TabControl.SelectionChanged += new System.EventHandler(this.m_TabControl_SelectionChanged);
            // 
            // m_tabPageFormulaire
            // 
            this.m_tabPageFormulaire.Controls.Add(this.m_PanelChamps);
            this.m_extLinkField.SetLinkField(this.m_tabPageFormulaire, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_tabPageFormulaire, false);
            this.m_tabPageFormulaire.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabPageFormulaire, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabPageFormulaire, "");
            this.m_tabPageFormulaire.Name = "m_tabPageFormulaire";
            this.m_tabPageFormulaire.Size = new System.Drawing.Size(897, 334);
            this.m_extStyle.SetStyleBackColor(this.m_tabPageFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabPageFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabPageFormulaire.TabIndex = 17;
            this.m_tabPageFormulaire.Title = "Properties|49";
            // 
            // m_PanelChamps
            // 
            this.m_PanelChamps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_PanelChamps.BoldSelectedPage = true;
            this.m_PanelChamps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_PanelChamps.ElementEdite = null;
            this.m_PanelChamps.ForeColor = System.Drawing.Color.Black;
            this.m_PanelChamps.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_PanelChamps, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_PanelChamps, false);
            this.m_PanelChamps.Location = new System.Drawing.Point(0, 0);
            this.m_PanelChamps.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_PanelChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_PanelChamps, "");
            this.m_PanelChamps.Name = "m_PanelChamps";
            this.m_PanelChamps.Ombre = false;
            this.m_PanelChamps.PositionTop = true;
            this.m_PanelChamps.Size = new System.Drawing.Size(897, 334);
            this.m_extStyle.SetStyleBackColor(this.m_PanelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_PanelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_PanelChamps.TabIndex = 2;
            this.m_PanelChamps.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageInformations
            // 
            this.m_pageInformations.Controls.Add(this.m_panelBesoins);
            this.m_pageInformations.Controls.Add(this.panel3);
            this.m_extLinkField.SetLinkField(this.m_pageInformations, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageInformations, false);
            this.m_pageInformations.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageInformations, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageInformations, "");
            this.m_pageInformations.Name = "m_pageInformations";
            this.m_pageInformations.Selected = false;
            this.m_pageInformations.Size = new System.Drawing.Size(897, 334);
            this.m_extStyle.SetStyleBackColor(this.m_pageInformations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageInformations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageInformations.TabIndex = 18;
            this.m_pageInformations.Title = "Informations|119";
            // 
            // m_panelBesoins
            // 
            this.m_panelBesoins.Controls.Add(this.m_wndSpecifications);
            this.m_panelBesoins.Controls.Add(this.m_panelHautBesoin);
            this.m_panelBesoins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelBesoins, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelBesoins, false);
            this.m_panelBesoins.Location = new System.Drawing.Point(0, 91);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelBesoins, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelBesoins, "APROJECT_NEEDS");
            this.m_panelBesoins.Name = "m_panelBesoins";
            this.m_panelBesoins.Size = new System.Drawing.Size(897, 243);
            this.m_extStyle.SetStyleBackColor(this.m_panelBesoins, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelBesoins, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelBesoins.TabIndex = 4010;
            // 
            // m_wndSpecifications
            // 
            this.m_wndSpecifications.CurrentItemIndex = null;
            this.m_wndSpecifications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndSpecifications.Items = new sc2i.win32.common.customizableList.CCustomizableListItem[0];
            this.m_extLinkField.SetLinkField(this.m_wndSpecifications, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_wndSpecifications, false);
            this.m_wndSpecifications.Location = new System.Drawing.Point(0, 21);
            this.m_wndSpecifications.LockEdition = true;
            this.m_wndSpecifications.ModeAffichage = timos.projet.besoin.EModeAffichageBesoins.ModeSansCout;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndSpecifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndSpecifications, "");
            this.m_wndSpecifications.Name = "m_wndSpecifications";
            this.m_wndSpecifications.Size = new System.Drawing.Size(897, 222);
            this.m_extStyle.SetStyleBackColor(this.m_wndSpecifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndSpecifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndSpecifications.TabIndex = 4010;
            // 
            // m_panelHautBesoin
            // 
            this.m_panelHautBesoin.Controls.Add(this.label3);
            this.m_panelHautBesoin.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.m_panelHautBesoin, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelHautBesoin, false);
            this.m_panelHautBesoin.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelHautBesoin, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelHautBesoin, "");
            this.m_panelHautBesoin.Name = "m_panelHautBesoin";
            this.m_panelHautBesoin.Size = new System.Drawing.Size(897, 21);
            this.m_extStyle.SetStyleBackColor(this.m_panelHautBesoin, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelHautBesoin, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelHautBesoin.TabIndex = 4009;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label3, false);
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(266, 21);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 1;
            this.label3.Text = "Project needs|20630";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.m_lblDescription);
            this.panel3.Controls.Add(this.m_txtDescrip);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.panel3, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.panel3, false);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel3, "");
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(897, 91);
            this.m_extStyle.SetStyleBackColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel3.TabIndex = 4007;
            // 
            // m_lblDescription
            // 
            this.m_lblDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_lblDescription.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_lblDescription, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblDescription, false);
            this.m_lblDescription.Location = new System.Drawing.Point(3, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblDescription, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblDescription, "");
            this.m_lblDescription.Name = "m_lblDescription";
            this.m_lblDescription.Size = new System.Drawing.Size(185, 15);
            this.m_extStyle.SetStyleBackColor(this.m_lblDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblDescription.TabIndex = 4005;
            this.m_lblDescription.Text = "Project description|1233";
            // 
            // m_txtDescrip
            // 
            this.m_txtDescrip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtDescrip.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtDescrip, "Description");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtDescrip, true);
            this.m_txtDescrip.Location = new System.Drawing.Point(6, 18);
            this.m_txtDescrip.LockEdition = false;
            this.m_txtDescrip.MaxLength = 2000;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtDescrip, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtDescrip, "");
            this.m_txtDescrip.Multiline = true;
            this.m_txtDescrip.Name = "m_txtDescrip";
            this.m_txtDescrip.Size = new System.Drawing.Size(888, 70);
            this.m_extStyle.SetStyleBackColor(this.m_txtDescrip, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtDescrip, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtDescrip.TabIndex = 5;
            this.m_txtDescrip.Text = "[Description]";
            // 
            // m_menuSousTypes
            // 
            this.m_extLinkField.SetLinkField(this.m_menuSousTypes, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_menuSousTypes, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_menuSousTypes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_menuSousTypes, "");
            this.m_menuSousTypes.Name = "m_menuSousTypes";
            this.m_menuSousTypes.Size = new System.Drawing.Size(61, 4);
            this.m_extStyle.SetStyleBackColor(this.m_menuSousTypes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_menuSousTypes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_btnCancel);
            this.panel2.Controls.Add(this.m_btnOk);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_extLinkField.SetLinkField(this.panel2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.panel2, false);
            this.panel2.Location = new System.Drawing.Point(0, 502);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel2, "");
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(913, 48);
            this.m_extStyle.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel2.TabIndex = 4023;
            // 
            // m_btnOk
            // 
            this.m_btnOk.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_btnOk.ForeColor = System.Drawing.Color.White;
            this.m_btnOk.Image = global::timos.Properties.Resources.check;
            this.m_extLinkField.SetLinkField(this.m_btnOk, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnOk, false);
            this.m_btnOk.Location = new System.Drawing.Point(381, 2);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnOk, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_btnOk, "");
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(40, 40);
            this.m_extStyle.SetStyleBackColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnOk.TabIndex = 2;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            // 
            // m_extLinkField
            // 
            this.m_extLinkField.SourceTypeString = "";
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_btnCancel.ForeColor = System.Drawing.Color.White;
            this.m_btnCancel.Image = global::timos.Properties.Resources.cancel;
            this.m_extLinkField.SetLinkField(this.m_btnCancel, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnCancel, true);
            this.m_btnCancel.Location = new System.Drawing.Point(460, 2);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnCancel, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_btnCancel, "");
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(40, 40);
            this.m_extStyle.SetStyleBackColor(this.m_btnCancel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnCancel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnCancel.TabIndex = 2;
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // CFormQuickEditProjet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 550);
            this.Controls.Add(this.m_TabControl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormQuickEditProjet";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondFenetre);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTexteFenetre);
            this.Load += new System.EventHandler(this.CFormQuickEditProjet_Load);
            this.panel1.ResumeLayout(false);
            this.m_panTop.ResumeLayout(false);
            this.m_panTop.PerformLayout();
            this.m_TabControl.ResumeLayout(false);
            this.m_TabControl.PerformLayout();
            this.m_tabPageFormulaire.ResumeLayout(false);
            this.m_pageInformations.ResumeLayout(false);
            this.m_panelBesoins.ResumeLayout(false);
            this.m_panelHautBesoin.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        protected sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
        public sc2i.win32.common.CExtLinkField m_extLinkField;
        protected sc2i.win32.common.CExtStyle m_extStyle;
        private System.Windows.Forms.Panel panel1;
        private sc2i.win32.common.C2iPanelOmbre m_panTop;
        private System.Windows.Forms.LinkLabel m_lnkSubTypes;
        private sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees m_selectTypeProjet;
        private System.Windows.Forms.Label m_lblProject;
        private sc2i.win32.common.C2iTextBox m_txtLibelle;
        private System.Windows.Forms.LinkLabel m_lnkDroits;
        private System.Windows.Forms.Label m_lblTypeTable;
        private timos.win32.composants.CDateTimePickerForContextMenu m_dtpDatesPrevisionnelles;
        private sc2i.win32.common.C2iDateTimeExPicker m_dtpDateDebutReelle;
        private System.Windows.Forms.Label m_lblDateDebut;
        private sc2i.win32.common.C2iDateTimeExPicker m_dtpDateFinReelle;
        private System.Windows.Forms.Label m_lblDateFin;
        private System.Windows.Forms.CheckBox m_chkDatesAuto;
        private sc2i.win32.common.C2iTabControl m_TabControl;
        private Crownwood.Magic.Controls.TabPage m_tabPageFormulaire;
        private sc2i.win32.data.dynamic.CPanelChampsCustom m_PanelChamps;
        private System.Windows.Forms.ContextMenuStrip m_menuSousTypes;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button m_btnOk;
        private Crownwood.Magic.Controls.TabPage m_pageInformations;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label m_lblDescription;
        private sc2i.win32.common.C2iTextBox m_txtDescrip;
        private System.Windows.Forms.Panel m_panelBesoins;
        private System.Windows.Forms.Panel m_panelHautBesoin;
        private System.Windows.Forms.Label label3;
        private CControleListeBesoins m_wndSpecifications;
        protected CExtModulesAssociator m_extModulesAssociator;
        private System.Windows.Forms.Button m_btnCancel;
    }
}