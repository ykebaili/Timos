namespace futurocom.win32.snmp
{
    partial class CPanelDetailObjetDossier
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
            this.label1 = new System.Windows.Forms.Label();
            this.c2iTextBox1 = new sc2i.win32.common.C2iTextBox();
            this.m_lblOID = new sc2i.win32.common.C2iTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.c2iTextBox3 = new sc2i.win32.common.C2iTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_lblDescription = new sc2i.win32.common.C2iTextBox();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageDescriptio = new Crownwood.Magic.Controls.TabPage();
            this.m_panelTop = new System.Windows.Forms.Panel();
            this.m_exLinkField = new sc2i.win32.common.CExtLinkField();
            this.m_tabControl.SuspendLayout();
            this.m_pageDescriptio.SuspendLayout();
            this.m_panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.m_exLinkField.SetLinkField(this.label1, "");
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
            this.m_exLinkField.SetLinkField(this.c2iTextBox1, "Name");
            this.c2iTextBox1.Location = new System.Drawing.Point(109, 1);
            this.c2iTextBox1.LockEdition = true;
            this.c2iTextBox1.Name = "c2iTextBox1";
            this.c2iTextBox1.Size = new System.Drawing.Size(288, 20);
            this.m_exStyle.SetStyleBackColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox1.TabIndex = 1;
            this.c2iTextBox1.Text = "[Name]";
            // 
            // m_lblOID
            // 
            this.m_exLinkField.SetLinkField(this.m_lblOID, "");
            this.m_lblOID.Location = new System.Drawing.Point(113, 33);
            this.m_lblOID.LockEdition = true;
            this.m_lblOID.Name = "m_lblOID";
            this.m_lblOID.Size = new System.Drawing.Size(271, 21);
            this.m_exStyle.SetStyleBackColor(this.m_lblOID, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_lblOID, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblOID.TabIndex = 3;
            // 
            // label2
            // 
            this.m_exLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(7, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.m_exStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 2;
            this.label2.Text = "OID|20001";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c2iTextBox3
            // 
            this.c2iTextBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_exLinkField.SetLinkField(this.c2iTextBox3, "ModuleName");
            this.c2iTextBox3.Location = new System.Drawing.Point(113, 6);
            this.c2iTextBox3.LockEdition = true;
            this.c2iTextBox3.Name = "c2iTextBox3";
            this.c2iTextBox3.Size = new System.Drawing.Size(502, 21);
            this.m_exStyle.SetStyleBackColor(this.c2iTextBox3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.c2iTextBox3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox3.TabIndex = 5;
            this.c2iTextBox3.Text = "[ModuleName]";
            // 
            // label3
            // 
            this.m_exLinkField.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(7, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 17);
            this.m_exStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4;
            this.label3.Text = "Module|20002";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.m_exLinkField.SetLinkField(this.label4, "");
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
            this.m_exLinkField.SetLinkField(this.m_lblDescription, "");
            this.m_lblDescription.Location = new System.Drawing.Point(113, 58);
            this.m_lblDescription.LockEdition = true;
            this.m_lblDescription.Multiline = true;
            this.m_lblDescription.Name = "m_lblDescription";
            this.m_lblDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.m_lblDescription.Size = new System.Drawing.Size(502, 328);
            this.m_exStyle.SetStyleBackColor(this.m_lblDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_lblDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblDescription.TabIndex = 7;
            this.m_lblDescription.Text = "[Description]";
            // 
            // m_tabControl
            // 
            this.m_tabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_tabControl.BoldSelectedPage = true;
            this.m_tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tabControl.ForeColor = System.Drawing.Color.Black;
            this.m_tabControl.IDEPixelArea = false;
            this.m_exLinkField.SetLinkField(this.m_tabControl, "");
            this.m_tabControl.Location = new System.Drawing.Point(0, 23);
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = false;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.m_pageDescriptio;
            this.m_tabControl.Size = new System.Drawing.Size(629, 416);
            this.m_exStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_exStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 19;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageDescriptio});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageDescriptio
            // 
            this.m_pageDescriptio.Controls.Add(this.label3);
            this.m_pageDescriptio.Controls.Add(this.c2iTextBox3);
            this.m_pageDescriptio.Controls.Add(this.label2);
            this.m_pageDescriptio.Controls.Add(this.m_lblOID);
            this.m_pageDescriptio.Controls.Add(this.label4);
            this.m_pageDescriptio.Controls.Add(this.m_lblDescription);
            this.m_exLinkField.SetLinkField(this.m_pageDescriptio, "");
            this.m_pageDescriptio.Location = new System.Drawing.Point(0, 25);
            this.m_pageDescriptio.Name = "m_pageDescriptio";
            this.m_pageDescriptio.Size = new System.Drawing.Size(629, 391);
            this.m_exStyle.SetStyleBackColor(this.m_pageDescriptio, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_pageDescriptio, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageDescriptio.TabIndex = 10;
            this.m_pageDescriptio.Title = "Description|20003";
            // 
            // m_panelTop
            // 
            this.m_panelTop.Controls.Add(this.label1);
            this.m_panelTop.Controls.Add(this.c2iTextBox1);
            this.m_panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_exLinkField.SetLinkField(this.m_panelTop, "");
            this.m_panelTop.Location = new System.Drawing.Point(0, 0);
            this.m_panelTop.Name = "m_panelTop";
            this.m_panelTop.Size = new System.Drawing.Size(629, 23);
            this.m_exStyle.SetStyleBackColor(this.m_panelTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_panelTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelTop.TabIndex = 20;
            // 
            // CPanelDetailObjetDossier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.m_panelTop);
            this.ForeColor = System.Drawing.Color.Black;
            this.m_exLinkField.SetLinkField(this, "");
            this.Name = "CPanelDetailObjetDossier";
            this.Size = new System.Drawing.Size(629, 439);
            this.m_exStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_exStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.m_pageDescriptio.ResumeLayout(false);
            this.m_pageDescriptio.PerformLayout();
            this.m_panelTop.ResumeLayout(false);
            this.m_panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.CExtStyle m_exStyle;
        private System.Windows.Forms.Label label1;
        private sc2i.win32.common.CExtLinkField m_exLinkField;
        private sc2i.win32.common.C2iTextBox c2iTextBox1;
        private sc2i.win32.common.C2iTextBox m_lblOID;
        private System.Windows.Forms.Label label2;
        private sc2i.win32.common.C2iTextBox c2iTextBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private sc2i.win32.common.C2iTextBox m_lblDescription;
        private sc2i.win32.common.C2iTabControl m_tabControl;
        private Crownwood.Magic.Controls.TabPage m_pageDescriptio;
        private System.Windows.Forms.Panel m_panelTop;
    }
}
