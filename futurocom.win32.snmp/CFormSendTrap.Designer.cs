namespace futurocom.win32.snmp
{
    partial class CFormSendTrap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormSendTrap));
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_btnAnnuler = new System.Windows.Forms.Button();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.c2iPanelOmbre1 = new sc2i.win32.common.C2iPanel(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.c2iPanelOmbre2 = new sc2i.win32.common.C2iPanel(this.components);
            this.m_panelVariables = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.m_txtCommunity = new sc2i.win32.common.C2iTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.m_cmbGenericCode = new sc2i.win32.common.C2iComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.m_txtEntreprise = new sc2i.win32.common.C2iTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_cmbTrapVersion = new sc2i.win32.common.C2iComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_txtIP = new sc2i.win32.common.C2iTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.m_txtIpDest = new sc2i.win32.common.C2iTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.m_txtPortDest = new sc2i.win32.common.C2iTextBoxNumerique();
            this.m_txtSpecificCode = new sc2i.win32.common.C2iTextBoxNumerique();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.c2iPanelOmbre1.SuspendLayout();
            this.c2iPanelOmbre2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.m_btnAnnuler);
            this.panel1.Controls.Add(this.m_btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 438);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(649, 48);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 2;
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnAnnuler.ForeColor = System.Drawing.Color.White;
            this.m_btnAnnuler.Image = ((System.Drawing.Image)(resources.GetObject("m_btnAnnuler.Image")));
            this.m_btnAnnuler.Location = new System.Drawing.Point(331, 2);
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(40, 40);
            this.m_extStyle.SetStyleBackColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAnnuler.TabIndex = 1;
            // 
            // m_btnOk
            // 
            this.m_btnOk.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnOk.ForeColor = System.Drawing.Color.White;
            this.m_btnOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btnOk.Image")));
            this.m_btnOk.Location = new System.Drawing.Point(277, 2);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(40, 40);
            this.m_extStyle.SetStyleBackColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnOk.TabIndex = 0;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            // 
            // c2iPanelOmbre1
            // 
            this.c2iPanelOmbre1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre1.Controls.Add(this.panel9);
            this.c2iPanelOmbre1.Controls.Add(this.panel8);
            this.c2iPanelOmbre1.Controls.Add(this.label1);
            this.c2iPanelOmbre1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.c2iPanelOmbre1.ForeColor = System.Drawing.Color.Black;
            this.c2iPanelOmbre1.Location = new System.Drawing.Point(0, 367);
            this.c2iPanelOmbre1.LockEdition = false;
            this.c2iPanelOmbre1.Name = "c2iPanelOmbre1";
            this.c2iPanelOmbre1.Size = new System.Drawing.Size(649, 71);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(649, 23);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 3;
            this.label1.Text = "Trap receiver|20109";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c2iPanelOmbre2
            // 
            this.c2iPanelOmbre2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre2.Controls.Add(this.m_panelVariables);
            this.c2iPanelOmbre2.Controls.Add(this.label9);
            this.c2iPanelOmbre2.Controls.Add(this.panel7);
            this.c2iPanelOmbre2.Controls.Add(this.panel6);
            this.c2iPanelOmbre2.Controls.Add(this.panel4);
            this.c2iPanelOmbre2.Controls.Add(this.panel5);
            this.c2iPanelOmbre2.Controls.Add(this.panel3);
            this.c2iPanelOmbre2.Controls.Add(this.panel2);
            this.c2iPanelOmbre2.Controls.Add(this.label2);
            this.c2iPanelOmbre2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c2iPanelOmbre2.ForeColor = System.Drawing.Color.Black;
            this.c2iPanelOmbre2.Location = new System.Drawing.Point(0, 0);
            this.c2iPanelOmbre2.LockEdition = false;
            this.c2iPanelOmbre2.Name = "c2iPanelOmbre2";
            this.c2iPanelOmbre2.Size = new System.Drawing.Size(649, 367);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre2.TabIndex = 4;
            // 
            // m_panelVariables
            // 
            this.m_panelVariables.AutoScroll = true;
            this.m_panelVariables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelVariables.Location = new System.Drawing.Point(0, 172);
            this.m_panelVariables.Name = "m_panelVariables";
            this.m_panelVariables.Size = new System.Drawing.Size(649, 195);
            this.m_extStyle.SetStyleBackColor(this.m_panelVariables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelVariables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelVariables.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(0, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(649, 23);
            this.m_extStyle.SetStyleBackColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label9.TabIndex = 11;
            this.label9.Text = "Trap variables|20117";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.m_txtCommunity);
            this.panel7.Controls.Add(this.label8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 128);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(649, 21);
            this.m_extStyle.SetStyleBackColor(this.panel7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel7.TabIndex = 5;
            // 
            // m_txtCommunity
            // 
            this.m_txtCommunity.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_txtCommunity.EmptyText = "";
            this.m_txtCommunity.Location = new System.Drawing.Point(130, 0);
            this.m_txtCommunity.LockEdition = false;
            this.m_txtCommunity.Name = "m_txtCommunity";
            this.m_txtCommunity.Size = new System.Drawing.Size(173, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtCommunity, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtCommunity, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtCommunity.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 19);
            this.m_extStyle.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 0;
            this.label8.Text = "Community|20116";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.m_txtSpecificCode);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 107);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(649, 21);
            this.m_extStyle.SetStyleBackColor(this.panel6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel6.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 19);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 0;
            this.label7.Text = "Specific code|20114";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.m_cmbGenericCode);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 86);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(649, 21);
            this.m_extStyle.SetStyleBackColor(this.panel4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel4.TabIndex = 3;
            // 
            // m_cmbGenericCode
            // 
            this.m_cmbGenericCode.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_cmbGenericCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbGenericCode.FormattingEnabled = true;
            this.m_cmbGenericCode.IsLink = false;
            this.m_cmbGenericCode.Location = new System.Drawing.Point(130, 0);
            this.m_cmbGenericCode.LockEdition = false;
            this.m_cmbGenericCode.Name = "m_cmbGenericCode";
            this.m_cmbGenericCode.Size = new System.Drawing.Size(173, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbGenericCode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbGenericCode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbGenericCode.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 19);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 0;
            this.label5.Text = "Generic code|20113";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.m_txtEntreprise);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 65);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(649, 21);
            this.m_extStyle.SetStyleBackColor(this.panel5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel5.TabIndex = 2;
            // 
            // m_txtEntreprise
            // 
            this.m_txtEntreprise.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_txtEntreprise.EmptyText = "";
            this.m_txtEntreprise.Location = new System.Drawing.Point(130, 0);
            this.m_txtEntreprise.LockEdition = false;
            this.m_txtEntreprise.Name = "m_txtEntreprise";
            this.m_txtEntreprise.Size = new System.Drawing.Size(408, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtEntreprise, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtEntreprise, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtEntreprise.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 19);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 0;
            this.label6.Text = "Entreprise|20112";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.m_cmbTrapVersion);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 44);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(649, 21);
            this.m_extStyle.SetStyleBackColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel3.TabIndex = 1;
            // 
            // m_cmbTrapVersion
            // 
            this.m_cmbTrapVersion.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_cmbTrapVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbTrapVersion.FormattingEnabled = true;
            this.m_cmbTrapVersion.IsLink = false;
            this.m_cmbTrapVersion.Location = new System.Drawing.Point(130, 0);
            this.m_cmbTrapVersion.LockEdition = false;
            this.m_cmbTrapVersion.Name = "m_cmbTrapVersion";
            this.m_cmbTrapVersion.Size = new System.Drawing.Size(173, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbTrapVersion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbTrapVersion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbTrapVersion.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 19);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 0;
            this.label4.Text = "Trap version|20115";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.m_txtIP);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(649, 21);
            this.m_extStyle.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel2.TabIndex = 0;
            // 
            // m_txtIP
            // 
            this.m_txtIP.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_txtIP.EmptyText = "";
            this.m_txtIP.Location = new System.Drawing.Point(130, 0);
            this.m_txtIP.LockEdition = false;
            this.m_txtIP.Name = "m_txtIP";
            this.m_txtIP.Size = new System.Drawing.Size(100, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtIP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtIP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtIP.TabIndex = 1;
            this.m_txtIP.Text = "127.0.0.1";
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 19);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 0;
            this.label3.Text = "Sender IP|20111";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(649, 23);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4;
            this.label2.Text = "Trap detail|20110";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.m_txtIpDest);
            this.panel8.Controls.Add(this.label10);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 23);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(649, 21);
            this.m_extStyle.SetStyleBackColor(this.panel8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel8.TabIndex = 0;
            // 
            // m_txtIpDest
            // 
            this.m_txtIpDest.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_txtIpDest.EmptyText = "";
            this.m_txtIpDest.Location = new System.Drawing.Point(130, 0);
            this.m_txtIpDest.LockEdition = false;
            this.m_txtIpDest.Name = "m_txtIpDest";
            this.m_txtIpDest.Size = new System.Drawing.Size(100, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtIpDest, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtIpDest, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtIpDest.TabIndex = 1;
            this.m_txtIpDest.Text = "127.0.0.1";
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Left;
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 19);
            this.m_extStyle.SetStyleBackColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label10.TabIndex = 0;
            this.label10.Text = "Receiver IP|20111";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.m_txtPortDest);
            this.panel9.Controls.Add(this.label11);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 44);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(649, 21);
            this.m_extStyle.SetStyleBackColor(this.panel9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel9.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Left;
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(130, 19);
            this.m_extStyle.SetStyleBackColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label11.TabIndex = 0;
            this.label11.Text = "Receiver port|20113";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtPortDest
            // 
            this.m_txtPortDest.Arrondi = 0;
            this.m_txtPortDest.DecimalAutorise = false;
            this.m_txtPortDest.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_txtPortDest.DoubleValue = 162;
            this.m_txtPortDest.EmptyText = "";
            this.m_txtPortDest.IntValue = 162;
            this.m_txtPortDest.Location = new System.Drawing.Point(130, 0);
            this.m_txtPortDest.LockEdition = false;
            this.m_txtPortDest.Name = "m_txtPortDest";
            this.m_txtPortDest.NullAutorise = false;
            this.m_txtPortDest.SelectAllOnEnter = true;
            this.m_txtPortDest.SeparateurMilliers = "";
            this.m_txtPortDest.Size = new System.Drawing.Size(47, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtPortDest, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtPortDest, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtPortDest.TabIndex = 1;
            this.m_txtPortDest.Text = "162";
            this.m_txtPortDest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtPortDest.TextChanged += new System.EventHandler(this.m_txtPortDest_TextChanged);
            // 
            // m_txtSpecificCode
            // 
            this.m_txtSpecificCode.Arrondi = 0;
            this.m_txtSpecificCode.DecimalAutorise = false;
            this.m_txtSpecificCode.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_txtSpecificCode.EmptyText = "";
            this.m_txtSpecificCode.IntValue = 0;
            this.m_txtSpecificCode.Location = new System.Drawing.Point(130, 0);
            this.m_txtSpecificCode.LockEdition = false;
            this.m_txtSpecificCode.Name = "m_txtSpecificCode";
            this.m_txtSpecificCode.NullAutorise = false;
            this.m_txtSpecificCode.SelectAllOnEnter = true;
            this.m_txtSpecificCode.SeparateurMilliers = "";
            this.m_txtSpecificCode.Size = new System.Drawing.Size(100, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtSpecificCode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSpecificCode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSpecificCode.TabIndex = 1;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.linkLabel1.Location = new System.Drawing.Point(537, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(112, 48);
            this.m_extStyle.SetStyleBackColor(this.linkLabel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.linkLabel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Copy formula to clipboard|20122";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // CFormSendTrap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 486);
            this.Controls.Add(this.c2iPanelOmbre2);
            this.Controls.Add(this.c2iPanelOmbre1);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "CFormSendTrap";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondFenetre);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTexteFenetre);
            this.Text = "Send trap|20108";
            this.Load += new System.EventHandler(this.CFormSendTrap_Load);
            this.panel1.ResumeLayout(false);
            this.c2iPanelOmbre1.ResumeLayout(false);
            this.c2iPanelOmbre2.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.CExtStyle m_extStyle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button m_btnAnnuler;
        private System.Windows.Forms.Button m_btnOk;
        private sc2i.win32.common.C2iPanel c2iPanelOmbre1;
        private System.Windows.Forms.Label label1;
        private sc2i.win32.common.C2iPanel c2iPanelOmbre2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private sc2i.win32.common.C2iTextBox m_txtIP;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private sc2i.win32.common.C2iComboBox m_cmbGenericCode;
        private System.Windows.Forms.Label label5;
        private sc2i.win32.common.C2iComboBox m_cmbTrapVersion;
        private System.Windows.Forms.Panel panel5;
        private sc2i.win32.common.C2iTextBox m_txtEntreprise;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel7;
        private sc2i.win32.common.C2iTextBox m_txtCommunity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel m_panelVariables;
        private System.Windows.Forms.Panel panel8;
        private sc2i.win32.common.C2iTextBox m_txtIpDest;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label11;
        private sc2i.win32.common.C2iTextBoxNumerique m_txtPortDest;
        private sc2i.win32.common.C2iTextBoxNumerique m_txtSpecificCode;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}