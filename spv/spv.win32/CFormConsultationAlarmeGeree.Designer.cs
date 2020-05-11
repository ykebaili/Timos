namespace spv.win32
{
    partial class CFormConsultationAlarmeGeree
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
            this.m_PanelAlarmeGeree = new sc2i.win32.common.C2iPanelOmbre();
            this.m_txtComments = new System.Windows.Forms.RichTextBox();
            this.m_cmbSeverity = new sc2i.win32.common.CComboboxAutoFilled();
            this.label25 = new System.Windows.Forms.Label();
            this.m_cmbEventType = new sc2i.win32.common.CComboboxAutoFilled();
            this.label24 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_chkActiveSon = new System.Windows.Forms.CheckBox();
            this.label23 = new System.Windows.Forms.Label();
            this.m_cmbTypeSon = new sc2i.win32.common.CComboboxAutoFilled();
            this.m_lnkGererCauses = new System.Windows.Forms.LinkLabel();
            this.m_panelSelectCauses = new sc2i.win32.data.navigation.CPanelListeRelationSelection();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.m_txtOID = new sc2i.win32.common.C2iTextBox();
            this.m_chkAutoMib = new System.Windows.Forms.CheckBox();
            this.label20 = new System.Windows.Forms.Label();
            this.m_txtTopLevel = new sc2i.win32.common.C2iTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.m_txtBottomLevel = new sc2i.win32.common.C2iTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.m_txtSeuilNom = new sc2i.win32.common.C2iTextBox();
            this.m_chkAcquitter = new System.Windows.Forms.CheckBox();
            this.m_chkAlarmLocal = new System.Windows.Forms.CheckBox();
            this.m_chkDisplay = new System.Windows.Forms.CheckBox();
            this.m_chkSurveiller = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.m_txtActions = new System.Windows.Forms.RichTextBox();
            this.m_txtPerSec = new sc2i.win32.common.C2iTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.m_cmbProtocol = new sc2i.win32.common.CComboboxAutoFilled();
            this.label11 = new System.Windows.Forms.Label();
            this.m_AlarmNb = new sc2i.win32.common.C2iTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.m_txtConfirmLength = new sc2i.win32.common.C2iTextBox();
            this.m_PanelAlarmeGeree.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_PanelAlarmeGeree
            // 
            this.m_PanelAlarmeGeree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_PanelAlarmeGeree.Controls.Add(this.m_txtComments);
            this.m_PanelAlarmeGeree.Controls.Add(this.m_cmbSeverity);
            this.m_PanelAlarmeGeree.Controls.Add(this.label25);
            this.m_PanelAlarmeGeree.Controls.Add(this.m_cmbEventType);
            this.m_PanelAlarmeGeree.Controls.Add(this.label24);
            this.m_PanelAlarmeGeree.Controls.Add(this.groupBox2);
            this.m_PanelAlarmeGeree.Controls.Add(this.m_lnkGererCauses);
            this.m_PanelAlarmeGeree.Controls.Add(this.m_panelSelectCauses);
            this.m_PanelAlarmeGeree.Controls.Add(this.groupBox1);
            this.m_PanelAlarmeGeree.Controls.Add(this.m_chkAcquitter);
            this.m_PanelAlarmeGeree.Controls.Add(this.m_chkAlarmLocal);
            this.m_PanelAlarmeGeree.Controls.Add(this.m_chkDisplay);
            this.m_PanelAlarmeGeree.Controls.Add(this.m_chkSurveiller);
            this.m_PanelAlarmeGeree.Controls.Add(this.label17);
            this.m_PanelAlarmeGeree.Controls.Add(this.label16);
            this.m_PanelAlarmeGeree.Controls.Add(this.m_txtActions);
            this.m_PanelAlarmeGeree.Controls.Add(this.m_txtPerSec);
            this.m_PanelAlarmeGeree.Controls.Add(this.label15);
            this.m_PanelAlarmeGeree.Controls.Add(this.label13);
            this.m_PanelAlarmeGeree.Controls.Add(this.label14);
            this.m_PanelAlarmeGeree.Controls.Add(this.label10);
            this.m_PanelAlarmeGeree.Controls.Add(this.m_cmbProtocol);
            this.m_PanelAlarmeGeree.Controls.Add(this.label11);
            this.m_PanelAlarmeGeree.Controls.Add(this.m_AlarmNb);
            this.m_PanelAlarmeGeree.Controls.Add(this.label12);
            this.m_PanelAlarmeGeree.Controls.Add(this.m_txtConfirmLength);
            this.m_PanelAlarmeGeree.Location = new System.Drawing.Point(8, 8);
            this.m_PanelAlarmeGeree.LockEdition = true;
            this.m_PanelAlarmeGeree.Name = "m_PanelAlarmeGeree";
            this.m_PanelAlarmeGeree.Size = new System.Drawing.Size(889, 411);
            this.m_extStyle.SetStyleBackColor(this.m_PanelAlarmeGeree, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_PanelAlarmeGeree, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_PanelAlarmeGeree.TabIndex = 0;
            // 
            // m_txtComments
            // 
            this.m_txtComments.Location = new System.Drawing.Point(499, 307);
            this.m_txtComments.Name = "m_txtComments";
            this.m_txtComments.Size = new System.Drawing.Size(362, 52);
            this.m_extStyle.SetStyleBackColor(this.m_txtComments, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtComments, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtComments.TabIndex = 4055;
            this.m_txtComments.Text = "";
            // 
            // m_cmbSeverity
            // 
            this.m_cmbSeverity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbSeverity.FormattingEnabled = true;
            this.m_cmbSeverity.IsLink = false;
            this.m_cmbSeverity.ListDonnees = null;
            this.m_cmbSeverity.Location = new System.Drawing.Point(191, 127);
            this.m_cmbSeverity.LockEdition = true;
            this.m_cmbSeverity.Name = "m_cmbSeverity";
            this.m_cmbSeverity.NullAutorise = false;
            this.m_cmbSeverity.ProprieteAffichee = null;
            this.m_cmbSeverity.Size = new System.Drawing.Size(230, 24);
            this.m_extStyle.SetStyleBackColor(this.m_cmbSeverity, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbSeverity, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbSeverity.TabIndex = 4049;
            this.m_cmbSeverity.TextNull = "(empty)";
            this.m_cmbSeverity.Tri = true;
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(499, 290);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(130, 13);
            this.m_extStyle.SetStyleBackColor(this.label25, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label25, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label25.TabIndex = 4056;
            this.label25.Text = "Comment|132";
            // 
            // m_cmbEventType
            // 
            this.m_cmbEventType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbEventType.FormattingEnabled = true;
            this.m_cmbEventType.IsLink = false;
            this.m_cmbEventType.ListDonnees = null;
            this.m_cmbEventType.Location = new System.Drawing.Point(191, 21);
            this.m_cmbEventType.LockEdition = true;
            this.m_cmbEventType.Name = "m_cmbEventType";
            this.m_cmbEventType.NullAutorise = false;
            this.m_cmbEventType.ProprieteAffichee = null;
            this.m_cmbEventType.Size = new System.Drawing.Size(230, 24);
            this.m_extStyle.SetStyleBackColor(this.m_cmbEventType, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbEventType, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbEventType.TabIndex = 4053;
            this.m_cmbEventType.TextNull = "(empty)";
            this.m_cmbEventType.Tri = true;
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(499, 216);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(130, 14);
            this.m_extStyle.SetStyleBackColor(this.label24, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label24, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label24.TabIndex = 4054;
            this.label24.Text = "Corrective action|131";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_chkActiveSon);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.m_cmbTypeSon);
            this.groupBox2.Location = new System.Drawing.Point(499, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(362, 49);
            this.m_extStyle.SetStyleBackColor(this.groupBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.groupBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.groupBox2.TabIndex = 4052;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ring|130";
            // 
            // m_chkActiveSon
            // 
            this.m_chkActiveSon.AutoSize = true;
            this.m_chkActiveSon.Location = new System.Drawing.Point(256, 19);
            this.m_chkActiveSon.Name = "m_chkActiveSon";
            this.m_chkActiveSon.Size = new System.Drawing.Size(91, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkActiveSon, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkActiveSon, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkActiveSon.TabIndex = 4024;
            this.m_chkActiveSon.Text = "Activated|115";
            this.m_chkActiveSon.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(16, 19);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(69, 23);
            this.m_extStyle.SetStyleBackColor(this.label23, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label23, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label23.TabIndex = 4023;
            this.label23.Text = "Type|129";
            // 
            // m_cmbTypeSon
            // 
            this.m_cmbTypeSon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTypeSon.FormattingEnabled = true;
            this.m_cmbTypeSon.IsLink = false;
            this.m_cmbTypeSon.ListDonnees = null;
            this.m_cmbTypeSon.Location = new System.Drawing.Point(105, 19);
            this.m_cmbTypeSon.LockEdition = false;
            this.m_cmbTypeSon.Name = "m_cmbTypeSon";
            this.m_cmbTypeSon.NullAutorise = false;
            this.m_cmbTypeSon.ProprieteAffichee = null;
            this.m_cmbTypeSon.Size = new System.Drawing.Size(70, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbTypeSon, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbTypeSon, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbTypeSon.TabIndex = 4022;
            this.m_cmbTypeSon.TextNull = "(empty)";
            this.m_cmbTypeSon.Tri = true;
            // 
            // m_lnkGererCauses
            // 
            this.m_lnkGererCauses.Location = new System.Drawing.Point(15, 217);
            this.m_lnkGererCauses.Name = "m_lnkGererCauses";
            this.m_lnkGererCauses.Size = new System.Drawing.Size(82, 46);
            this.m_extStyle.SetStyleBackColor(this.m_lnkGererCauses, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkGererCauses, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkGererCauses.TabIndex = 4058;
            this.m_lnkGererCauses.TabStop = true;
            this.m_lnkGererCauses.Text = "Alarm cause(s)|135";
            this.m_lnkGererCauses.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkGererCauses_LinkClicked);
            // 
            // m_panelSelectCauses
            // 
            this.m_panelSelectCauses.EnableCustomisation = true;
            this.m_panelSelectCauses.ExclusionParException = false;
            this.m_panelSelectCauses.Location = new System.Drawing.Point(97, 204);
            this.m_panelSelectCauses.LockEdition = true;
            this.m_panelSelectCauses.Name = "m_panelSelectCauses";
            this.m_panelSelectCauses.Size = new System.Drawing.Size(384, 179);
            this.m_extStyle.SetStyleBackColor(this.m_panelSelectCauses, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelSelectCauses, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelSelectCauses.TabIndex = 4057;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.m_txtOID);
            this.groupBox1.Controls.Add(this.m_chkAutoMib);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.m_txtTopLevel);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.m_txtBottomLevel);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.m_txtSeuilNom);
            this.groupBox1.Location = new System.Drawing.Point(499, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 129);
            this.m_extStyle.SetStyleBackColor(this.groupBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.groupBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.groupBox1.TabIndex = 4050;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Threshold|133";
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(16, 77);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(69, 23);
            this.m_extStyle.SetStyleBackColor(this.label21, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label21, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label21.TabIndex = 4022;
            this.label21.Text = "OID|137";
            // 
            // m_txtOID
            // 
            this.m_txtOID.Location = new System.Drawing.Point(105, 77);
            this.m_txtOID.LockEdition = false;
            this.m_txtOID.Name = "m_txtOID";
            this.m_txtOID.Size = new System.Drawing.Size(242, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtOID, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtOID, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtOID.TabIndex = 4021;
            // 
            // m_chkAutoMib
            // 
            this.m_chkAutoMib.AutoSize = true;
            this.m_chkAutoMib.Location = new System.Drawing.Point(18, 110);
            this.m_chkAutoMib.Name = "m_chkAutoMib";
            this.m_chkAutoMib.Size = new System.Drawing.Size(115, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkAutoMib, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkAutoMib, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkAutoMib.TabIndex = 4020;
            this.m_chkAutoMib.Text = "Automatic MIB|114";
            this.m_chkAutoMib.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(196, 50);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(75, 23);
            this.m_extStyle.SetStyleBackColor(this.label20, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label20, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label20.TabIndex = 4015;
            this.label20.Text = "Top level|124";
            // 
            // m_txtTopLevel
            // 
            this.m_txtTopLevel.Location = new System.Drawing.Point(277, 50);
            this.m_txtTopLevel.LockEdition = false;
            this.m_txtTopLevel.Name = "m_txtTopLevel";
            this.m_txtTopLevel.Size = new System.Drawing.Size(70, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtTopLevel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtTopLevel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtTopLevel.TabIndex = 4014;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(16, 50);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(88, 23);
            this.m_extStyle.SetStyleBackColor(this.label19, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label19, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label19.TabIndex = 4013;
            this.label19.Text = "Bottom level|124";
            // 
            // m_txtBottomLevel
            // 
            this.m_txtBottomLevel.Location = new System.Drawing.Point(105, 50);
            this.m_txtBottomLevel.LockEdition = false;
            this.m_txtBottomLevel.Name = "m_txtBottomLevel";
            this.m_txtBottomLevel.Size = new System.Drawing.Size(70, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtBottomLevel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtBottomLevel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtBottomLevel.TabIndex = 4012;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(16, 24);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(69, 23);
            this.m_extStyle.SetStyleBackColor(this.label18, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label18, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label18.TabIndex = 4011;
            this.label18.Text = "Name|134";
            // 
            // m_txtSeuilNom
            // 
            this.m_txtSeuilNom.Location = new System.Drawing.Point(105, 24);
            this.m_txtSeuilNom.LockEdition = false;
            this.m_txtSeuilNom.Name = "m_txtSeuilNom";
            this.m_txtSeuilNom.Size = new System.Drawing.Size(242, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtSeuilNom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSeuilNom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSeuilNom.TabIndex = 4010;
            // 
            // m_chkAcquitter
            // 
            this.m_chkAcquitter.AutoSize = true;
            this.m_chkAcquitter.Location = new System.Drawing.Point(228, 181);
            this.m_chkAcquitter.Name = "m_chkAcquitter";
            this.m_chkAcquitter.Size = new System.Drawing.Size(126, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkAcquitter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkAcquitter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkAcquitter.TabIndex = 4047;
            this.m_chkAcquitter.Text = "To acknowledge|113";
            this.m_chkAcquitter.UseVisualStyleBackColor = true;
            // 
            // m_chkAlarmLocal
            // 
            this.m_chkAlarmLocal.AutoSize = true;
            this.m_chkAlarmLocal.Location = new System.Drawing.Point(365, 181);
            this.m_chkAlarmLocal.Name = "m_chkAlarmLocal";
            this.m_chkAlarmLocal.Size = new System.Drawing.Size(100, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkAlarmLocal, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkAlarmLocal, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkAlarmLocal.TabIndex = 4048;
            this.m_chkAlarmLocal.Text = "Local alarm|117";
            this.m_chkAlarmLocal.UseVisualStyleBackColor = true;
            // 
            // m_chkDisplay
            // 
            this.m_chkDisplay.AutoSize = true;
            this.m_chkDisplay.Location = new System.Drawing.Point(124, 181);
            this.m_chkDisplay.Name = "m_chkDisplay";
            this.m_chkDisplay.Size = new System.Drawing.Size(94, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkDisplay, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkDisplay, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkDisplay.TabIndex = 4046;
            this.m_chkDisplay.Text = "To display|118";
            this.m_chkDisplay.UseVisualStyleBackColor = true;
            // 
            // m_chkSurveiller
            // 
            this.m_chkSurveiller.AutoSize = true;
            this.m_chkSurveiller.Location = new System.Drawing.Point(18, 181);
            this.m_chkSurveiller.Name = "m_chkSurveiller";
            this.m_chkSurveiller.Size = new System.Drawing.Size(96, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkSurveiller, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkSurveiller, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkSurveiller.TabIndex = 4045;
            this.m_chkSurveiller.Text = "To monitor|116";
            this.m_chkSurveiller.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(15, 127);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(130, 23);
            this.m_extStyle.SetStyleBackColor(this.label17, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label17, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label17.TabIndex = 4044;
            this.label17.Text = "Severity|123";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(15, 100);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(130, 23);
            this.m_extStyle.SetStyleBackColor(this.label16, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label16, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label16.TabIndex = 4043;
            this.label16.Text = "Protocol|122";
            // 
            // m_txtActions
            // 
            this.m_txtActions.Location = new System.Drawing.Point(499, 233);
            this.m_txtActions.Name = "m_txtActions";
            this.m_txtActions.Size = new System.Drawing.Size(362, 52);
            this.m_extStyle.SetStyleBackColor(this.m_txtActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtActions.TabIndex = 4051;
            this.m_txtActions.Text = "";
            // 
            // m_txtPerSec
            // 
            this.m_txtPerSec.Location = new System.Drawing.Point(308, 74);
            this.m_txtPerSec.LockEdition = true;
            this.m_txtPerSec.Name = "m_txtPerSec";
            this.m_txtPerSec.Size = new System.Drawing.Size(70, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtPerSec, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtPerSec, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtPerSec.TabIndex = 4042;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(265, 74);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 23);
            this.m_extStyle.SetStyleBackColor(this.label15, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label15, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label15.TabIndex = 4041;
            this.label15.Text = "for|127";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(381, 74);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 23);
            this.m_extStyle.SetStyleBackColor(this.label13, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label13, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label13.TabIndex = 4040;
            this.label13.Text = "sec.|128";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(15, 74);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(155, 23);
            this.m_extStyle.SetStyleBackColor(this.label14, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label14, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label14.TabIndex = 4039;
            this.label14.Text = "Frequent alarm number|126";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(15, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 23);
            this.m_extStyle.SetStyleBackColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label10.TabIndex = 4036;
            this.label10.Text = "Event type|120";
            // 
            // m_cmbProtocol
            // 
            this.m_cmbProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbProtocol.FormattingEnabled = true;
            this.m_cmbProtocol.IsLink = false;
            this.m_cmbProtocol.ListDonnees = null;
            this.m_cmbProtocol.Location = new System.Drawing.Point(191, 100);
            this.m_cmbProtocol.LockEdition = true;
            this.m_cmbProtocol.Name = "m_cmbProtocol";
            this.m_cmbProtocol.NullAutorise = false;
            this.m_cmbProtocol.ProprieteAffichee = null;
            this.m_cmbProtocol.Size = new System.Drawing.Size(230, 24);
            this.m_extStyle.SetStyleBackColor(this.m_cmbProtocol, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbProtocol, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbProtocol.TabIndex = 4035;
            this.m_cmbProtocol.TextNull = "(empty)";
            this.m_cmbProtocol.Tri = true;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(15, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(152, 23);
            this.m_extStyle.SetStyleBackColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label11.TabIndex = 4034;
            this.label11.Text = "Confirmation length|121";
            // 
            // m_AlarmNb
            // 
            this.m_AlarmNb.Location = new System.Drawing.Point(191, 74);
            this.m_AlarmNb.LockEdition = true;
            this.m_AlarmNb.Name = "m_AlarmNb";
            this.m_AlarmNb.Size = new System.Drawing.Size(70, 20);
            this.m_extStyle.SetStyleBackColor(this.m_AlarmNb, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_AlarmNb, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_AlarmNb.TabIndex = 4038;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(265, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 23);
            this.m_extStyle.SetStyleBackColor(this.label12, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label12, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label12.TabIndex = 4037;
            this.label12.Text = "sec.|128";
            // 
            // m_txtConfirmLength
            // 
            this.m_txtConfirmLength.Location = new System.Drawing.Point(191, 48);
            this.m_txtConfirmLength.LockEdition = true;
            this.m_txtConfirmLength.Name = "m_txtConfirmLength";
            this.m_txtConfirmLength.Size = new System.Drawing.Size(70, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtConfirmLength, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtConfirmLength, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtConfirmLength.TabIndex = 4033;
            // 
            // CFormConsultationAlarmeGeree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(903, 444);
            this.Controls.Add(this.m_PanelAlarmeGeree);
            this.Name = "CFormConsultationAlarmeGeree";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "CFormConsultationAlarmeGeree";
            this.Load += new System.EventHandler(this.CFormConsultationAlarmeGeree_Load);
            this.m_PanelAlarmeGeree.ResumeLayout(false);
            this.m_PanelAlarmeGeree.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.C2iPanelOmbre m_PanelAlarmeGeree;
        private System.Windows.Forms.RichTextBox m_txtComments;
        protected sc2i.win32.common.CComboboxAutoFilled m_cmbSeverity;
        private System.Windows.Forms.Label label25;
        protected sc2i.win32.common.CComboboxAutoFilled m_cmbEventType;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox m_chkActiveSon;
        private System.Windows.Forms.Label label23;
        protected sc2i.win32.common.CComboboxAutoFilled m_cmbTypeSon;
        private System.Windows.Forms.LinkLabel m_lnkGererCauses;
        private sc2i.win32.data.navigation.CPanelListeRelationSelection m_panelSelectCauses;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label21;
        private sc2i.win32.common.C2iTextBox m_txtOID;
        private System.Windows.Forms.CheckBox m_chkAutoMib;
        private System.Windows.Forms.Label label20;
        private sc2i.win32.common.C2iTextBox m_txtTopLevel;
        private System.Windows.Forms.Label label19;
        private sc2i.win32.common.C2iTextBox m_txtBottomLevel;
        private System.Windows.Forms.Label label18;
        private sc2i.win32.common.C2iTextBox m_txtSeuilNom;
        private System.Windows.Forms.CheckBox m_chkAcquitter;
        private System.Windows.Forms.CheckBox m_chkAlarmLocal;
        private System.Windows.Forms.CheckBox m_chkDisplay;
        private System.Windows.Forms.CheckBox m_chkSurveiller;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.RichTextBox m_txtActions;
        private sc2i.win32.common.C2iTextBox m_txtPerSec;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label10;
        protected sc2i.win32.common.CComboboxAutoFilled m_cmbProtocol;
        private System.Windows.Forms.Label label11;
        private sc2i.win32.common.C2iTextBox m_AlarmNb;
        private System.Windows.Forms.Label label12;
        private sc2i.win32.common.C2iTextBox m_txtConfirmLength;
    }
}
