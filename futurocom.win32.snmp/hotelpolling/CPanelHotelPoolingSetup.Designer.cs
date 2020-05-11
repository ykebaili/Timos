namespace futurocom.win32.snmp.hotelpolling
{
    partial class CPanelHotelPoolingSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPanelHotelPoolingSetup));
            this.cExtStyle1 = new sc2i.win32.common.CExtStyle();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_txtNumPort = new sc2i.win32.common.C2iTextBoxNumerique();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txtFrequence = new sc2i.win32.common.C2iTextBoxNumeriqueAvecUnite();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtIP = new sc2i.win32.common.C2iTextBox();
            this.m_wndListeChamps = new sc2i.win32.common.customizableList.CCustomizableList();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_btnRemoveData = new sc2i.win32.common.CWndLinkStd();
            this.m_btnAddData = new sc2i.win32.common.CWndLinkStd();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_txtLibelle
            // 
            this.m_txtLibelle.EmptyText = "";
            this.m_txtLibelle.Location = new System.Drawing.Point(136, 7);
            this.m_txtLibelle.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(323, 20);
            this.cExtStyle1.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 5);
            this.m_extModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 23);
            this.cExtStyle1.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 0;
            this.label2.Text = "Libellé|20125";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_txtNumPort);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.m_txtFrequence);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.m_txtIP);
            this.panel1.Controls.Add(this.m_txtLibelle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(585, 94);
            this.cExtStyle1.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 0;
            // 
            // m_txtNumPort
            // 
            this.m_txtNumPort.Arrondi = 0;
            this.m_txtNumPort.DecimalAutorise = true;
            this.m_txtNumPort.EmptyText = "";
            this.m_txtNumPort.IntValue = 0;
            this.m_txtNumPort.Location = new System.Drawing.Point(136, 71);
            this.m_txtNumPort.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtNumPort, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtNumPort.Name = "m_txtNumPort";
            this.m_txtNumPort.NullAutorise = false;
            this.m_txtNumPort.SelectAllOnEnter = true;
            this.m_txtNumPort.SeparateurMilliers = "";
            this.m_txtNumPort.Size = new System.Drawing.Size(100, 20);
            this.cExtStyle1.SetStyleBackColor(this.m_txtNumPort, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_txtNumPort, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtNumPort.TabIndex = 7;
            this.m_txtNumPort.Text = "0";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 70);
            this.m_extModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 21);
            this.cExtStyle1.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 4;
            this.label4.Text = "Hotel port|20135";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtFrequence
            // 
            this.m_txtFrequence.AllowNoUnit = false;
            this.m_txtFrequence.DefaultFormat = "h min s";
            this.m_txtFrequence.EmptyText = "h min s";
            this.m_txtFrequence.Location = new System.Drawing.Point(136, 29);
            this.m_txtFrequence.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtFrequence, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtFrequence.Name = "m_txtFrequence";
            this.m_txtFrequence.Size = new System.Drawing.Size(134, 20);
            this.cExtStyle1.SetStyleBackColor(this.m_txtFrequence, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_txtFrequence, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFrequence.TabIndex = 3;
            this.m_txtFrequence.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtFrequence.UnitValue = null;
            this.m_txtFrequence.UseValueFormat = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 49);
            this.m_extModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 21);
            this.cExtStyle1.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hotel IP|20134";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 28);
            this.m_extModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 21);
            this.cExtStyle1.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 0;
            this.label3.Text = "Polling frequency|20130";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtIP
            // 
            this.m_txtIP.EmptyText = "";
            this.m_txtIP.Location = new System.Drawing.Point(136, 50);
            this.m_txtIP.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtIP, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtIP.Name = "m_txtIP";
            this.m_txtIP.Size = new System.Drawing.Size(134, 20);
            this.cExtStyle1.SetStyleBackColor(this.m_txtIP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_txtIP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtIP.TabIndex = 5;
            // 
            // m_wndListeChamps
            // 
            this.m_wndListeChamps.CurrentItemIndex = null;
            this.m_wndListeChamps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeChamps.ItemControl = null;
            this.m_wndListeChamps.Items = new sc2i.win32.common.customizableList.CCustomizableListItem[0];
            this.m_wndListeChamps.Location = new System.Drawing.Point(0, 143);
            this.m_wndListeChamps.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_wndListeChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_wndListeChamps.Name = "m_wndListeChamps";
            this.m_wndListeChamps.Size = new System.Drawing.Size(585, 207);
            this.cExtStyle1.SetStyleBackColor(this.m_wndListeChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_wndListeChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeChamps.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_btnRemoveData);
            this.panel2.Controls.Add(this.m_btnAddData);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 94);
            this.m_extModeEdition.SetModeEdition(this.panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(585, 26);
            this.cExtStyle1.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel2.TabIndex = 2;
            // 
            // m_btnRemoveData
            // 
            this.m_btnRemoveData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnRemoveData.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_btnRemoveData.CustomImage")));
            this.m_btnRemoveData.CustomText = "Remove";
            this.m_btnRemoveData.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnRemoveData.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_btnRemoveData.Location = new System.Drawing.Point(112, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnRemoveData, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnRemoveData.Name = "m_btnRemoveData";
            this.m_btnRemoveData.ShortMode = false;
            this.m_btnRemoveData.Size = new System.Drawing.Size(112, 26);
            this.cExtStyle1.SetStyleBackColor(this.m_btnRemoveData, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_btnRemoveData, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnRemoveData.TabIndex = 1;
            this.m_btnRemoveData.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_btnRemoveData.LinkClicked += new System.EventHandler(this.m_btnRemoveData_LinkClicked);
            // 
            // m_btnAddData
            // 
            this.m_btnAddData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnAddData.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_btnAddData.CustomImage")));
            this.m_btnAddData.CustomText = "Add";
            this.m_btnAddData.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnAddData.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_btnAddData.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnAddData, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnAddData.Name = "m_btnAddData";
            this.m_btnAddData.ShortMode = false;
            this.m_btnAddData.Size = new System.Drawing.Size(112, 26);
            this.cExtStyle1.SetStyleBackColor(this.m_btnAddData, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_btnAddData, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAddData.TabIndex = 0;
            this.m_btnAddData.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_btnAddData.LinkClicked += new System.EventHandler(this.m_btnAddData_LinkClicked);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 120);
            this.m_extModeEdition.SetModeEdition(this.panel3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(585, 23);
            this.cExtStyle1.SetStyleBackColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel3.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(360, 0);
            this.m_extModeEdition.SetModeEdition(this.label8, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(225, 23);
            this.cExtStyle1.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 3;
            this.label8.Text = "Polling Formula|20139";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(240, 0);
            this.m_extModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 23);
            this.cExtStyle1.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 2;
            this.label7.Text = "Entity Id|20138";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(120, 0);
            this.m_extModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 23);
            this.cExtStyle1.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 1;
            this.label6.Text = "Field|20137";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 23);
            this.cExtStyle1.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 0;
            this.label5.Text = "Table|20136";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_extModeEdition
            // 
            this.m_extModeEdition.ModeEdition = true;
            // 
            // CPanelHotelPoolingSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_wndListeChamps);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CPanelHotelPoolingSetup";
            this.Size = new System.Drawing.Size(585, 350);
            this.cExtStyle1.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.cExtStyle1.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.CExtStyle cExtStyle1;
        private sc2i.win32.common.C2iTextBox m_txtLibelle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private sc2i.win32.common.customizableList.CCustomizableList m_wndListeChamps;
        private System.Windows.Forms.Label label3;
        private sc2i.win32.common.C2iTextBoxNumeriqueAvecUnite m_txtFrequence;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private sc2i.win32.common.C2iTextBox m_txtIP;
        private sc2i.win32.common.C2iTextBoxNumerique m_txtNumPort;
        private System.Windows.Forms.Panel panel2;
        private sc2i.win32.common.CWndLinkStd m_btnRemoveData;
        private sc2i.win32.common.CWndLinkStd m_btnAddData;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
    }
}
