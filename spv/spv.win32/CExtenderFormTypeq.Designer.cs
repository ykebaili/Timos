namespace spv.win32
{
    partial class CExtenderFormTypeq
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
            this.labelMainIdent = new System.Windows.Forms.Label();
            this.labelSecondaryOID = new System.Windows.Forms.Label();
            this.LabelSecondaryName = new System.Windows.Forms.Label();
            this.LabelSecondaryValue = new System.Windows.Forms.Label();
            this.groupBoxSNMPIdent = new System.Windows.Forms.GroupBox();
            this.m_chkAutomaticMIB = new System.Windows.Forms.CheckBox();
            this.m_txtBoxIdentValeur = new sc2i.win32.common.C2iTextBox();
            this.m_txtBoxIdentNom = new sc2i.win32.common.C2iTextBox();
            this.m_txtBoxIdentOID = new sc2i.win32.common.C2iTextBox();
            this.m_txtBoxRefSnmp = new sc2i.win32.common.C2iTextBox();
            this.groupBoxCommut = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_radio2vers1 = new System.Windows.Forms.RadioButton();
            this.m_radioNotCommut = new System.Windows.Forms.RadioButton();
            this.m_radio_nVers1 = new System.Windows.Forms.RadioButton();
            this.labelOID = new System.Windows.Forms.Label();
            this.m_txtBoxCommutOID = new sc2i.win32.common.C2iTextBox();
            this.m_chkToSupervise = new System.Windows.Forms.CheckBox();
            this.groupBoxMibs = new System.Windows.Forms.GroupBox();
            this.m_lnkSupprimer = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkAjouter = new sc2i.win32.common.CWndLinkStd();
            this.m_listMibs = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_TreeMibs = new System.Windows.Forms.TreeView();
            this.m_chkJustDiscovered = new System.Windows.Forms.CheckBox();
            this.groupBoxSNMPIdent.SuspendLayout();
            this.groupBoxCommut.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBoxMibs.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelMainIdent
            // 
            this.labelMainIdent.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.labelMainIdent, "");
            this.labelMainIdent.Location = new System.Drawing.Point(13, 26);
            this.m_extModeEdition.SetModeEdition(this.labelMainIdent, sc2i.win32.common.TypeModeEdition.Autonome);
            this.labelMainIdent.Name = "labelMainIdent";
            this.labelMainIdent.Size = new System.Drawing.Size(99, 13);
            this.m_extStyle.SetStyleBackColor(this.labelMainIdent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.labelMainIdent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.labelMainIdent.TabIndex = 5;
            this.labelMainIdent.Text = "Main  (sysDescr)|15";
            // 
            // labelSecondaryOID
            // 
            this.labelSecondaryOID.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.labelSecondaryOID, "");
            this.labelSecondaryOID.Location = new System.Drawing.Point(13, 57);
            this.m_extModeEdition.SetModeEdition(this.labelSecondaryOID, sc2i.win32.common.TypeModeEdition.Autonome);
            this.labelSecondaryOID.Name = "labelSecondaryOID";
            this.labelSecondaryOID.Size = new System.Drawing.Size(103, 13);
            this.m_extStyle.SetStyleBackColor(this.labelSecondaryOID, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.labelSecondaryOID, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.labelSecondaryOID.TabIndex = 6;
            this.labelSecondaryOID.Text = "Secondary  (OID)|16";
            // 
            // LabelSecondaryName
            // 
            this.LabelSecondaryName.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.LabelSecondaryName, "");
            this.LabelSecondaryName.Location = new System.Drawing.Point(13, 88);
            this.m_extModeEdition.SetModeEdition(this.LabelSecondaryName, sc2i.win32.common.TypeModeEdition.Autonome);
            this.LabelSecondaryName.Name = "LabelSecondaryName";
            this.LabelSecondaryName.Size = new System.Drawing.Size(112, 13);
            this.m_extStyle.SetStyleBackColor(this.LabelSecondaryName, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.LabelSecondaryName, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.LabelSecondaryName.TabIndex = 7;
            this.LabelSecondaryName.Text = "Secondary  (Name)|17";
            // 
            // LabelSecondaryValue
            // 
            this.LabelSecondaryValue.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.LabelSecondaryValue, "");
            this.LabelSecondaryValue.Location = new System.Drawing.Point(13, 119);
            this.m_extModeEdition.SetModeEdition(this.LabelSecondaryValue, sc2i.win32.common.TypeModeEdition.Autonome);
            this.LabelSecondaryValue.Name = "LabelSecondaryValue";
            this.LabelSecondaryValue.Size = new System.Drawing.Size(111, 13);
            this.m_extStyle.SetStyleBackColor(this.LabelSecondaryValue, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.LabelSecondaryValue, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.LabelSecondaryValue.TabIndex = 8;
            this.LabelSecondaryValue.Text = "Secondary  (Value)|18";
            // 
            // groupBoxSNMPIdent
            // 
            this.groupBoxSNMPIdent.Controls.Add(this.m_chkAutomaticMIB);
            this.groupBoxSNMPIdent.Controls.Add(this.m_txtBoxIdentValeur);
            this.groupBoxSNMPIdent.Controls.Add(this.m_txtBoxIdentNom);
            this.groupBoxSNMPIdent.Controls.Add(this.m_txtBoxIdentOID);
            this.groupBoxSNMPIdent.Controls.Add(this.m_txtBoxRefSnmp);
            this.groupBoxSNMPIdent.Controls.Add(this.LabelSecondaryValue);
            this.groupBoxSNMPIdent.Controls.Add(this.LabelSecondaryName);
            this.groupBoxSNMPIdent.Controls.Add(this.labelSecondaryOID);
            this.groupBoxSNMPIdent.Controls.Add(this.labelMainIdent);
            this.m_extLinkField.SetLinkField(this.groupBoxSNMPIdent, "");
            this.groupBoxSNMPIdent.Location = new System.Drawing.Point(3, 3);
            this.m_extModeEdition.SetModeEdition(this.groupBoxSNMPIdent, sc2i.win32.common.TypeModeEdition.Autonome);
            this.groupBoxSNMPIdent.Name = "groupBoxSNMPIdent";
            this.groupBoxSNMPIdent.Size = new System.Drawing.Size(458, 156);
            this.m_extStyle.SetStyleBackColor(this.groupBoxSNMPIdent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.groupBoxSNMPIdent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.groupBoxSNMPIdent.TabIndex = 9;
            this.groupBoxSNMPIdent.TabStop = false;
            this.groupBoxSNMPIdent.Text = "SNMP Identification |19";
            // 
            // m_chkAutomaticMIB
            // 
            this.m_chkAutomaticMIB.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkAutomaticMIB, "");
            this.m_chkAutomaticMIB.Location = new System.Drawing.Point(333, 87);
            this.m_extModeEdition.SetModeEdition(this.m_chkAutomaticMIB, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkAutomaticMIB.Name = "m_chkAutomaticMIB";
            this.m_chkAutomaticMIB.Size = new System.Drawing.Size(109, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkAutomaticMIB, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkAutomaticMIB, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkAutomaticMIB.TabIndex = 14;
            this.m_chkAutomaticMIB.Text = "Automatic MIB|19";
            this.m_chkAutomaticMIB.UseVisualStyleBackColor = true;
            // 
            // m_txtBoxIdentValeur
            // 
            this.m_extLinkField.SetLinkField(this.m_txtBoxIdentValeur, "");
            this.m_txtBoxIdentValeur.Location = new System.Drawing.Point(151, 115);
            this.m_txtBoxIdentValeur.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtBoxIdentValeur, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtBoxIdentValeur.Name = "m_txtBoxIdentValeur";
            this.m_txtBoxIdentValeur.Size = new System.Drawing.Size(176, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtBoxIdentValeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtBoxIdentValeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtBoxIdentValeur.TabIndex = 12;
            this.m_txtBoxIdentValeur.Text = "[TypeqIdentValeur]";
            // 
            // m_txtBoxIdentNom
            // 
            this.m_extLinkField.SetLinkField(this.m_txtBoxIdentNom, "");
            this.m_txtBoxIdentNom.Location = new System.Drawing.Point(151, 84);
            this.m_txtBoxIdentNom.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtBoxIdentNom, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtBoxIdentNom.Name = "m_txtBoxIdentNom";
            this.m_txtBoxIdentNom.Size = new System.Drawing.Size(176, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtBoxIdentNom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtBoxIdentNom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtBoxIdentNom.TabIndex = 11;
            this.m_txtBoxIdentNom.Text = "[TypeqIdentNom]";
            // 
            // m_txtBoxIdentOID
            // 
            this.m_extLinkField.SetLinkField(this.m_txtBoxIdentOID, "");
            this.m_txtBoxIdentOID.Location = new System.Drawing.Point(151, 53);
            this.m_txtBoxIdentOID.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtBoxIdentOID, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtBoxIdentOID.Name = "m_txtBoxIdentOID";
            this.m_txtBoxIdentOID.Size = new System.Drawing.Size(176, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtBoxIdentOID, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtBoxIdentOID, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtBoxIdentOID.TabIndex = 10;
            this.m_txtBoxIdentOID.Text = "[TypeqIdentOID]";
            // 
            // m_txtBoxRefSnmp
            // 
            this.m_extLinkField.SetLinkField(this.m_txtBoxRefSnmp, "");
            this.m_txtBoxRefSnmp.Location = new System.Drawing.Point(151, 22);
            this.m_txtBoxRefSnmp.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtBoxRefSnmp, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtBoxRefSnmp.Name = "m_txtBoxRefSnmp";
            this.m_txtBoxRefSnmp.Size = new System.Drawing.Size(176, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtBoxRefSnmp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtBoxRefSnmp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtBoxRefSnmp.TabIndex = 9;
            this.m_txtBoxRefSnmp.Text = "[TypeqRefSnmp]";
            // 
            // groupBoxCommut
            // 
            this.groupBoxCommut.Controls.Add(this.panel1);
            this.groupBoxCommut.Controls.Add(this.labelOID);
            this.groupBoxCommut.Controls.Add(this.m_txtBoxCommutOID);
            this.m_extLinkField.SetLinkField(this.groupBoxCommut, "");
            this.groupBoxCommut.Location = new System.Drawing.Point(470, 166);
            this.m_extModeEdition.SetModeEdition(this.groupBoxCommut, sc2i.win32.common.TypeModeEdition.Autonome);
            this.groupBoxCommut.Name = "groupBoxCommut";
            this.groupBoxCommut.Size = new System.Drawing.Size(343, 226);
            this.m_extStyle.SetStyleBackColor(this.groupBoxCommut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.groupBoxCommut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.groupBoxCommut.TabIndex = 10;
            this.groupBoxCommut.TabStop = false;
            this.groupBoxCommut.Text = "Switch|21";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_radio2vers1);
            this.panel1.Controls.Add(this.m_radioNotCommut);
            this.panel1.Controls.Add(this.m_radio_nVers1);
            this.m_extLinkField.SetLinkField(this.panel1, "");
            this.panel1.Location = new System.Drawing.Point(15, 27);
            this.m_extModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 30);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 16;
            // 
            // m_radio2vers1
            // 
            this.m_radio2vers1.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_radio2vers1, "");
            this.m_radio2vers1.Location = new System.Drawing.Point(70, 7);
            this.m_extModeEdition.SetModeEdition(this.m_radio2vers1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_radio2vers1.Name = "m_radio2vers1";
            this.m_radio2vers1.Size = new System.Drawing.Size(60, 17);
            this.m_extStyle.SetStyleBackColor(this.m_radio2vers1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_radio2vers1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_radio2vers1.TabIndex = 1;
            this.m_radio2vers1.TabStop = true;
            this.m_radio2vers1.Text = "2->1|23";
            this.m_radio2vers1.UseVisualStyleBackColor = true;
            // 
            // m_radioNotCommut
            // 
            this.m_radioNotCommut.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_radioNotCommut, "");
            this.m_radioNotCommut.Location = new System.Drawing.Point(11, 7);
            this.m_extModeEdition.SetModeEdition(this.m_radioNotCommut, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_radioNotCommut.Name = "m_radioNotCommut";
            this.m_radioNotCommut.Size = new System.Drawing.Size(53, 17);
            this.m_extStyle.SetStyleBackColor(this.m_radioNotCommut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_radioNotCommut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_radioNotCommut.TabIndex = 0;
            this.m_radioNotCommut.TabStop = true;
            this.m_radioNotCommut.Text = "No|22";
            this.m_radioNotCommut.UseVisualStyleBackColor = true;
            // 
            // m_radio_nVers1
            // 
            this.m_radio_nVers1.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_radio_nVers1, "");
            this.m_radio_nVers1.Location = new System.Drawing.Point(136, 7);
            this.m_extModeEdition.SetModeEdition(this.m_radio_nVers1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_radio_nVers1.Name = "m_radio_nVers1";
            this.m_radio_nVers1.Size = new System.Drawing.Size(60, 17);
            this.m_extStyle.SetStyleBackColor(this.m_radio_nVers1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_radio_nVers1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_radio_nVers1.TabIndex = 2;
            this.m_radio_nVers1.TabStop = true;
            this.m_radio_nVers1.Text = "n->1|24";
            this.m_radio_nVers1.UseVisualStyleBackColor = true;
            // 
            // labelOID
            // 
            this.labelOID.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.labelOID, "");
            this.labelOID.Location = new System.Drawing.Point(12, 78);
            this.m_extModeEdition.SetModeEdition(this.labelOID, sc2i.win32.common.TypeModeEdition.Autonome);
            this.labelOID.Name = "labelOID";
            this.labelOID.Size = new System.Drawing.Size(40, 13);
            this.m_extStyle.SetStyleBackColor(this.labelOID, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.labelOID, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.labelOID.TabIndex = 15;
            this.labelOID.Text = "OID|25";
            // 
            // m_txtBoxCommutOID
            // 
            this.m_extLinkField.SetLinkField(this.m_txtBoxCommutOID, "");
            this.m_txtBoxCommutOID.Location = new System.Drawing.Point(58, 74);
            this.m_txtBoxCommutOID.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtBoxCommutOID, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtBoxCommutOID.Name = "m_txtBoxCommutOID";
            this.m_txtBoxCommutOID.Size = new System.Drawing.Size(268, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtBoxCommutOID, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtBoxCommutOID, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtBoxCommutOID.TabIndex = 15;
            this.m_txtBoxCommutOID.Text = "[CommutOID]";
            // 
            // m_chkToSupervise
            // 
            this.m_chkToSupervise.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkToSupervise, "");
            this.m_chkToSupervise.Location = new System.Drawing.Point(477, 60);
            this.m_extModeEdition.SetModeEdition(this.m_chkToSupervise, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkToSupervise.Name = "m_chkToSupervise";
            this.m_chkToSupervise.Size = new System.Drawing.Size(90, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkToSupervise, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkToSupervise, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkToSupervise.TabIndex = 11;
            this.m_chkToSupervise.Text = "To monitor|26";
            this.m_chkToSupervise.UseVisualStyleBackColor = true;
            // 
            // groupBoxMibs
            // 
            this.groupBoxMibs.Controls.Add(this.m_lnkSupprimer);
            this.groupBoxMibs.Controls.Add(this.m_lnkAjouter);
            this.groupBoxMibs.Controls.Add(this.m_listMibs);
            this.groupBoxMibs.Controls.Add(this.m_TreeMibs);
            this.m_extLinkField.SetLinkField(this.groupBoxMibs, "");
            this.groupBoxMibs.Location = new System.Drawing.Point(3, 166);
            this.m_extModeEdition.SetModeEdition(this.groupBoxMibs, sc2i.win32.common.TypeModeEdition.Autonome);
            this.groupBoxMibs.Name = "groupBoxMibs";
            this.groupBoxMibs.Size = new System.Drawing.Size(458, 226);
            this.m_extStyle.SetStyleBackColor(this.groupBoxMibs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.groupBoxMibs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.groupBoxMibs.TabIndex = 12;
            this.groupBoxMibs.TabStop = false;
            this.groupBoxMibs.Text = "Mibs|50009";
            // 
            // m_lnkSupprimer
            // 
            this.m_lnkSupprimer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkSupprimer.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkSupprimer, "");
            this.m_lnkSupprimer.Location = new System.Drawing.Point(186, 157);
            this.m_extModeEdition.SetModeEdition(this.m_lnkSupprimer, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkSupprimer.Name = "m_lnkSupprimer";
            this.m_lnkSupprimer.Size = new System.Drawing.Size(89, 24);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSupprimer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSupprimer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSupprimer.TabIndex = 3;
            this.m_lnkSupprimer.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkSupprimer.LinkClicked += new System.EventHandler(this.m_lnkSupprimer_LinkClicked);
            // 
            // m_lnkAjouter
            // 
            this.m_lnkAjouter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAjouter.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkAjouter, "");
            this.m_lnkAjouter.Location = new System.Drawing.Point(186, 46);
            this.m_extModeEdition.SetModeEdition(this.m_lnkAjouter, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkAjouter.Name = "m_lnkAjouter";
            this.m_lnkAjouter.Size = new System.Drawing.Size(89, 24);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAjouter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAjouter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAjouter.TabIndex = 2;
            this.m_lnkAjouter.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAjouter.LinkClicked += new System.EventHandler(this.m_lnkAjouter_LinkClicked);
            // 
            // m_listMibs
            // 
            this.m_listMibs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn1});
            this.m_listMibs.EnableCustomisation = true;
            this.m_listMibs.FullRowSelect = true;
            this.m_extLinkField.SetLinkField(this.m_listMibs, "");
            this.m_listMibs.Location = new System.Drawing.Point(281, 16);
            this.m_extModeEdition.SetModeEdition(this.m_listMibs, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_listMibs.Name = "m_listMibs";
            this.m_listMibs.Size = new System.Drawing.Size(161, 201);
            this.m_extStyle.SetStyleBackColor(this.m_listMibs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_listMibs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_listMibs.TabIndex = 1;
            this.m_listMibs.UseCompatibleStateImageBehavior = false;
            this.m_listMibs.View = System.Windows.Forms.View.Details;
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "NomModuleUtilisateur";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Label|3";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 120;
            // 
            // m_TreeMibs
            // 
            this.m_extLinkField.SetLinkField(this.m_TreeMibs, "");
            this.m_TreeMibs.Location = new System.Drawing.Point(6, 16);
            this.m_extModeEdition.SetModeEdition(this.m_TreeMibs, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_TreeMibs.Name = "m_TreeMibs";
            this.m_TreeMibs.Size = new System.Drawing.Size(174, 201);
            this.m_extStyle.SetStyleBackColor(this.m_TreeMibs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_TreeMibs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_TreeMibs.TabIndex = 0;
            // 
            // m_chkJustDiscovered
            // 
            this.m_chkJustDiscovered.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkJustDiscovered, "");
            this.m_chkJustDiscovered.Location = new System.Drawing.Point(477, 29);
            this.m_extModeEdition.SetModeEdition(this.m_chkJustDiscovered, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkJustDiscovered.Name = "m_chkJustDiscovered";
            this.m_chkJustDiscovered.Size = new System.Drawing.Size(132, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkJustDiscovered, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkJustDiscovered, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkJustDiscovered.TabIndex = 18;
            this.m_chkJustDiscovered.Text = "Just discovered|20021";
            this.m_chkJustDiscovered.UseVisualStyleBackColor = true;
            // 
            // CExtenderFormTypeq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.m_chkJustDiscovered);
            this.Controls.Add(this.groupBoxMibs);
            this.Controls.Add(this.m_chkToSupervise);
            this.Controls.Add(this.groupBoxCommut);
            this.Controls.Add(this.groupBoxSNMPIdent);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CExtenderFormTypeq";
            this.Size = new System.Drawing.Size(827, 420);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.groupBoxSNMPIdent.ResumeLayout(false);
            this.groupBoxSNMPIdent.PerformLayout();
            this.groupBoxCommut.ResumeLayout(false);
            this.groupBoxCommut.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBoxMibs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMainIdent;
        private System.Windows.Forms.Label labelSecondaryOID;
        private System.Windows.Forms.Label LabelSecondaryName;
        private System.Windows.Forms.Label LabelSecondaryValue;
        private System.Windows.Forms.GroupBox groupBoxSNMPIdent;
        private sc2i.win32.common.C2iTextBox m_txtBoxRefSnmp;
        private sc2i.win32.common.C2iTextBox m_txtBoxIdentOID;
        private sc2i.win32.common.C2iTextBox m_txtBoxIdentNom;
        private sc2i.win32.common.C2iTextBox m_txtBoxIdentValeur;
        private System.Windows.Forms.CheckBox m_chkAutomaticMIB;
        private System.Windows.Forms.GroupBox groupBoxCommut;
        private System.Windows.Forms.RadioButton m_radioNotCommut;
        private System.Windows.Forms.RadioButton m_radio2vers1;
        private System.Windows.Forms.Label labelOID;
        private sc2i.win32.common.C2iTextBox m_txtBoxCommutOID;
        private System.Windows.Forms.RadioButton m_radio_nVers1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox m_chkToSupervise;
        private System.Windows.Forms.GroupBox groupBoxMibs;
        private sc2i.win32.common.CWndLinkStd m_lnkSupprimer;
        private sc2i.win32.common.CWndLinkStd m_lnkAjouter;
        private sc2i.win32.common.ListViewAutoFilled m_listMibs;
        private System.Windows.Forms.TreeView m_TreeMibs;
        private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn1;
        private System.Windows.Forms.CheckBox m_chkJustDiscovered;
    }
}
