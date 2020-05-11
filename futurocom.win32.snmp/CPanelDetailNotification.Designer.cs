namespace futurocom.win32.snmp
{
    partial class CPanelDetailNotification
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
            this.m_exStyle = new sc2i.win32.common.CExtStyle();
            this.c2iTabControl1 = new sc2i.win32.common.C2iTabControl(this.components);
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.c2iTextBox3 = new sc2i.win32.common.C2iTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_lblOID = new sc2i.win32.common.C2iTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_lblDescription = new sc2i.win32.common.C2iTextBox();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.m_wndListeObjects = new sc2i.win32.common.CListLink();
            this.m_panelTop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.c2iTextBox1 = new sc2i.win32.common.C2iTextBox();
            this.m_exLinkField = new sc2i.win32.common.CExtLinkField();
            this.m_btnSendTrap = new System.Windows.Forms.Button();
            this.c2iTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.m_panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // c2iTabControl1
            // 
            this.c2iTabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iTabControl1.BoldSelectedPage = true;
            this.c2iTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c2iTabControl1.ForeColor = System.Drawing.Color.Black;
            this.c2iTabControl1.IDEPixelArea = false;
            this.m_exLinkField.SetLinkField(this.c2iTabControl1, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.c2iTabControl1, false);
            this.c2iTabControl1.Location = new System.Drawing.Point(0, 23);
            this.c2iTabControl1.Name = "c2iTabControl1";
            this.c2iTabControl1.Ombre = false;
            this.c2iTabControl1.PositionTop = true;
            this.c2iTabControl1.SelectedIndex = 0;
            this.c2iTabControl1.SelectedTab = this.tabPage1;
            this.c2iTabControl1.Size = new System.Drawing.Size(437, 252);
            this.m_exStyle.SetStyleBackColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_exStyle.SetStyleForeColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iTabControl1.TabIndex = 21;
            this.c2iTabControl1.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2});
            this.c2iTabControl1.TextColor = System.Drawing.Color.Black;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_btnSendTrap);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.c2iTextBox3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.m_lblOID);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.m_lblDescription);
            this.m_exLinkField.SetLinkField(this.tabPage1, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.tabPage1, false);
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(437, 227);
            this.m_exStyle.SetStyleBackColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage1.TabIndex = 10;
            this.tabPage1.Title = "Description|20003";
            // 
            // label3
            // 
            this.m_exLinkField.SetLinkField(this.label3, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.label3, false);
            this.label3.Location = new System.Drawing.Point(7, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 17);
            this.m_exStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4;
            this.label3.Text = "Module|20002";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c2iTextBox3
            // 
            this.c2iTextBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iTextBox3.EmptyText = "";
            this.m_exLinkField.SetLinkField(this.c2iTextBox3, "ModuleName");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.c2iTextBox3, true);
            this.c2iTextBox3.Location = new System.Drawing.Point(113, 6);
            this.c2iTextBox3.LockEdition = true;
            this.c2iTextBox3.Name = "c2iTextBox3";
            this.c2iTextBox3.Size = new System.Drawing.Size(310, 21);
            this.m_exStyle.SetStyleBackColor(this.c2iTextBox3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.c2iTextBox3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox3.TabIndex = 5;
            this.c2iTextBox3.Text = "[ModuleName]";
            // 
            // label2
            // 
            this.m_exLinkField.SetLinkField(this.label2, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.label2, false);
            this.label2.Location = new System.Drawing.Point(7, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.m_exStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 2;
            this.label2.Text = "OID|20001";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblOID
            // 
            this.m_lblOID.EmptyText = "";
            this.m_exLinkField.SetLinkField(this.m_lblOID, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_lblOID, false);
            this.m_lblOID.Location = new System.Drawing.Point(113, 33);
            this.m_lblOID.LockEdition = true;
            this.m_lblOID.Name = "m_lblOID";
            this.m_lblOID.Size = new System.Drawing.Size(271, 21);
            this.m_exStyle.SetStyleBackColor(this.m_lblOID, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_lblOID, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblOID.TabIndex = 3;
            // 
            // label4
            // 
            this.m_exLinkField.SetLinkField(this.label4, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.label4, false);
            this.label4.Location = new System.Drawing.Point(7, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 17);
            this.m_exStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 6;
            this.label4.Text = "Description|20003";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblDescription
            // 
            this.m_lblDescription.AcceptsReturn = true;
            this.m_lblDescription.AcceptsTab = true;
            this.m_lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblDescription.EmptyText = "";
            this.m_exLinkField.SetLinkField(this.m_lblDescription, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_lblDescription, false);
            this.m_lblDescription.Location = new System.Drawing.Point(113, 58);
            this.m_lblDescription.LockEdition = true;
            this.m_lblDescription.Multiline = true;
            this.m_lblDescription.Name = "m_lblDescription";
            this.m_lblDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.m_lblDescription.Size = new System.Drawing.Size(310, 164);
            this.m_exStyle.SetStyleBackColor(this.m_lblDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_lblDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblDescription.TabIndex = 7;
            this.m_lblDescription.Text = "[Description]";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.m_wndListeObjects);
            this.m_exLinkField.SetLinkField(this.tabPage2, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.tabPage2, false);
            this.tabPage2.Location = new System.Drawing.Point(0, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(437, 227);
            this.m_exStyle.SetStyleBackColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage2.TabIndex = 11;
            this.tabPage2.Title = "Objects|20017";
            // 
            // m_wndListeObjects
            // 
            this.m_wndListeObjects.ColorActive = System.Drawing.Color.Red;
            this.m_wndListeObjects.ColorDesactive = System.Drawing.Color.Blue;
            this.m_wndListeObjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.m_wndListeObjects.ForeColor = System.Drawing.Color.Blue;
            this.m_wndListeObjects.FullRowSelect = true;
            this.m_wndListeObjects.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_exLinkField.SetLinkField(this.m_wndListeObjects, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_wndListeObjects, false);
            this.m_wndListeObjects.Location = new System.Drawing.Point(3, 3);
            this.m_wndListeObjects.MultiSelect = false;
            this.m_wndListeObjects.Name = "m_wndListeObjects";
            this.m_wndListeObjects.Size = new System.Drawing.Size(255, 221);
            this.m_exStyle.SetStyleBackColor(this.m_wndListeObjects, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_wndListeObjects, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeObjects.TabIndex = 0;
            this.m_wndListeObjects.UseCompatibleStateImageBehavior = false;
            this.m_wndListeObjects.View = System.Windows.Forms.View.Details;
            this.m_wndListeObjects.ItemClick += new sc2i.win32.common.ListLinkItemClickEventHandler(this.m_wndListeObjects_ItemClick);
            // 
            // m_panelTop
            // 
            this.m_panelTop.Controls.Add(this.label1);
            this.m_panelTop.Controls.Add(this.c2iTextBox1);
            this.m_panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_exLinkField.SetLinkField(this.m_panelTop, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_panelTop, false);
            this.m_panelTop.Location = new System.Drawing.Point(0, 0);
            this.m_panelTop.Name = "m_panelTop";
            this.m_panelTop.Size = new System.Drawing.Size(437, 23);
            this.m_exStyle.SetStyleBackColor(this.m_panelTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_panelTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelTop.TabIndex = 22;
            // 
            // label1
            // 
            this.m_exLinkField.SetLinkField(this.label1, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.label1, false);
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.m_exStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name|20000";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c2iTextBox1
            // 
            this.c2iTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iTextBox1.EmptyText = "";
            this.m_exLinkField.SetLinkField(this.c2iTextBox1, "Name");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.c2iTextBox1, true);
            this.c2iTextBox1.Location = new System.Drawing.Point(109, 1);
            this.c2iTextBox1.LockEdition = true;
            this.c2iTextBox1.Name = "c2iTextBox1";
            this.c2iTextBox1.Size = new System.Drawing.Size(325, 20);
            this.m_exStyle.SetStyleBackColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox1.TabIndex = 1;
            this.c2iTextBox1.Text = "[Name]";
            // 
            // m_exLinkField
            // 
            this.m_exLinkField.SourceTypeString = "";
            // 
            // m_btnSendTrap
            // 
            this.m_btnSendTrap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnSendTrap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_btnSendTrap.ForeColor = System.Drawing.Color.Black;
            this.m_exLinkField.SetLinkField(this.m_btnSendTrap, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_btnSendTrap, false);
            this.m_btnSendTrap.Location = new System.Drawing.Point(6, 199);
            this.m_btnSendTrap.Name = "m_btnSendTrap";
            this.m_btnSendTrap.Size = new System.Drawing.Size(101, 23);
            this.m_exStyle.SetStyleBackColor(this.m_btnSendTrap, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_exStyle.SetStyleForeColor(this.m_btnSendTrap, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_btnSendTrap.TabIndex = 9;
            this.m_btnSendTrap.Text = "Send trap|20118";
            this.m_btnSendTrap.UseVisualStyleBackColor = false;
            this.m_btnSendTrap.Click += new System.EventHandler(this.m_btnSendTrap_Click);
            // 
            // CPanelDetailNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.c2iTabControl1);
            this.Controls.Add(this.m_panelTop);
            this.ForeColor = System.Drawing.Color.Black;
            this.m_exLinkField.SetLinkField(this, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this, false);
            this.Name = "CPanelDetailNotification";
            this.Size = new System.Drawing.Size(437, 275);
            this.m_exStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_exStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.Load += new System.EventHandler(this.CPanelDetailNotification_Load);
            this.c2iTabControl1.ResumeLayout(false);
            this.c2iTabControl1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.m_panelTop.ResumeLayout(false);
            this.m_panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.CExtStyle m_exStyle;
        private sc2i.win32.common.CExtLinkField m_exLinkField;
        private sc2i.win32.common.C2iTabControl c2iTabControl1;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private System.Windows.Forms.Label label3;
        private sc2i.win32.common.C2iTextBox c2iTextBox3;
        private System.Windows.Forms.Label label2;
        private sc2i.win32.common.C2iTextBox m_lblOID;
        private System.Windows.Forms.Label label4;
        private sc2i.win32.common.C2iTextBox m_lblDescription;
        private Crownwood.Magic.Controls.TabPage tabPage2;
        private System.Windows.Forms.Panel m_panelTop;
        private System.Windows.Forms.Label label1;
        private sc2i.win32.common.C2iTextBox c2iTextBox1;
        private sc2i.win32.common.CListLink m_wndListeObjects;
        private System.Windows.Forms.Button m_btnSendTrap;

    }
}
