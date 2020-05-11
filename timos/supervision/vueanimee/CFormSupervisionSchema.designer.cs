namespace timos.supervision.vueanimee
{
    partial class CFormSupervisionSchema
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
            if (m_contexteDonnee != null)
                m_contexteDonnee.Dispose();
            m_contexteDonnee = null;
            if (m_basePourVue != null)
                m_basePourVue.Dispose();
            m_basePourVue = null;

            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormSupervisionSchema));
            this.m_panelTop = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_lblTitre = new System.Windows.Forms.Label();
            this.m_btnRefresh = new System.Windows.Forms.Button();
            this.m_btnExit = new System.Windows.Forms.Button();
            this.m_btnHome = new System.Windows.Forms.Button();
            this.m_btnPagePrecedente = new System.Windows.Forms.Button();
            this.m_controleSchema = new timos.supervision.vueanimee.CControlSchemaSupervise();
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.m_toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnAficherMasque = new System.Windows.Forms.ToolStripDropDownButton();
            this.m_chkAlwaysOnTop = new System.Windows.Forms.CheckBox();
            this.m_imagesBoutons16x16 = new System.Windows.Forms.ImageList(this.components);
            this.m_panelTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.m_toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelTop
            // 
            this.m_panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelTop.Controls.Add(this.panel1);
            this.m_panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelTop.Location = new System.Drawing.Point(0, 0);
            this.m_panelTop.Name = "m_panelTop";
            this.m_panelTop.Size = new System.Drawing.Size(765, 32);
            this.m_extStyle.SetStyleBackColor(this.m_panelTop, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panelTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelTop.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(41)))), ((int)(((byte)(131)))));
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.m_chkAlwaysOnTop);
            this.panel1.Controls.Add(this.m_lblTitre);
            this.panel1.Controls.Add(this.m_btnRefresh);
            this.panel1.Controls.Add(this.m_btnExit);
            this.panel1.Controls.Add(this.m_btnHome);
            this.panel1.Controls.Add(this.m_btnPagePrecedente);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(765, 32);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 3;
            // 
            // m_lblTitre
            // 
            this.m_lblTitre.BackColor = System.Drawing.Color.Transparent;
            this.m_lblTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblTitre.ForeColor = System.Drawing.Color.White;
            this.m_lblTitre.Location = new System.Drawing.Point(214, 4);
            this.m_lblTitre.Name = "m_lblTitre";
            this.m_lblTitre.Size = new System.Drawing.Size(368, 23);
            this.m_extStyle.SetStyleBackColor(this.m_lblTitre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblTitre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblTitre.TabIndex = 3;
            this.m_lblTitre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_btnRefresh
            // 
            this.m_btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.m_btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.m_btnRefresh.FlatAppearance.BorderSize = 0;
            this.m_btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(161)))));
            this.m_btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(190)))));
            this.m_btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("m_btnRefresh.Image")));
            this.m_btnRefresh.Location = new System.Drawing.Point(92, 1);
            this.m_btnRefresh.Name = "m_btnRefresh";
            this.m_btnRefresh.Size = new System.Drawing.Size(32, 30);
            this.m_extStyle.SetStyleBackColor(this.m_btnRefresh, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnRefresh, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnRefresh.TabIndex = 2;
            this.m_btnRefresh.UseVisualStyleBackColor = false;
            this.m_btnRefresh.Click += new System.EventHandler(this.m_btnRefresh_Click);
            // 
            // m_btnExit
            // 
            this.m_btnExit.BackColor = System.Drawing.Color.Transparent;
            this.m_btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.m_btnExit.FlatAppearance.BorderSize = 0;
            this.m_btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(161)))));
            this.m_btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(190)))));
            this.m_btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnExit.Image = ((System.Drawing.Image)(resources.GetObject("m_btnExit.Image")));
            this.m_btnExit.Location = new System.Drawing.Point(134, 1);
            this.m_btnExit.Name = "m_btnExit";
            this.m_btnExit.Size = new System.Drawing.Size(32, 30);
            this.m_extStyle.SetStyleBackColor(this.m_btnExit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnExit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnExit.TabIndex = 2;
            this.m_btnExit.UseVisualStyleBackColor = false;
            this.m_btnExit.Click += new System.EventHandler(this.m_btnExit_Click);
            // 
            // m_btnHome
            // 
            this.m_btnHome.BackColor = System.Drawing.Color.Transparent;
            this.m_btnHome.FlatAppearance.BorderSize = 0;
            this.m_btnHome.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(161)))));
            this.m_btnHome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(190)))));
            this.m_btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnHome.Image = ((System.Drawing.Image)(resources.GetObject("m_btnHome.Image")));
            this.m_btnHome.Location = new System.Drawing.Point(176, 1);
            this.m_btnHome.Name = "m_btnHome";
            this.m_btnHome.Size = new System.Drawing.Size(32, 30);
            this.m_extStyle.SetStyleBackColor(this.m_btnHome, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnHome, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnHome.TabIndex = 2;
            this.m_btnHome.UseVisualStyleBackColor = false;
            this.m_btnHome.Click += new System.EventHandler(this.m_btnHome_Click);
            // 
            // m_btnPagePrecedente
            // 
            this.m_btnPagePrecedente.BackColor = System.Drawing.Color.Transparent;
            this.m_btnPagePrecedente.FlatAppearance.BorderSize = 0;
            this.m_btnPagePrecedente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(161)))));
            this.m_btnPagePrecedente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(190)))));
            this.m_btnPagePrecedente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnPagePrecedente.Image = ((System.Drawing.Image)(resources.GetObject("m_btnPagePrecedente.Image")));
            this.m_btnPagePrecedente.Location = new System.Drawing.Point(8, 1);
            this.m_btnPagePrecedente.Name = "m_btnPagePrecedente";
            this.m_btnPagePrecedente.Size = new System.Drawing.Size(32, 30);
            this.m_extStyle.SetStyleBackColor(this.m_btnPagePrecedente, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnPagePrecedente, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnPagePrecedente.TabIndex = 0;
            this.m_btnPagePrecedente.UseVisualStyleBackColor = false;
            this.m_btnPagePrecedente.Click += new System.EventHandler(this.m_btnPagePrecedente_Click);
            // 
            // m_controleSchema
            // 
            this.m_controleSchema.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_controleSchema.Location = new System.Drawing.Point(0, 57);
            this.m_controleSchema.Name = "m_controleSchema";
            this.m_controleSchema.Size = new System.Drawing.Size(765, 431);
            this.m_extStyle.SetStyleBackColor(this.m_controleSchema, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_controleSchema, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_controleSchema.TabIndex = 1;
            this.m_controleSchema.OnChangeSchemaAffiche += new System.EventHandler(this.m_controleSchema_OnChangeSchemaAffiche);
            // 
            // m_toolStrip
            // 
            this.m_toolStrip.BackColor = System.Drawing.SystemColors.MenuBar;
            this.m_toolStrip.BackgroundImage = global::timos.Properties.Resources.fond_menu_liste_3;
            this.m_toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.m_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.m_btnAficherMasque});
            this.m_toolStrip.Location = new System.Drawing.Point(0, 32);
            this.m_toolStrip.Name = "m_toolStrip";
            this.m_toolStrip.Size = new System.Drawing.Size(765, 25);
            this.m_extStyle.SetStyleBackColor(this.m_toolStrip, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_toolStrip, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_toolStrip.TabIndex = 5;
            this.m_toolStrip.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(110, 22);
            this.toolStripLabel1.Text = "Quick Filter|10315";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // m_btnAficherMasque
            // 
            this.m_btnAficherMasque.Image = global::timos.Properties.Resources.add;
            this.m_btnAficherMasque.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_btnAficherMasque.Name = "m_btnAficherMasque";
            this.m_btnAficherMasque.Size = new System.Drawing.Size(150, 22);
            this.m_btnAficherMasque.Text = "Masked Alarms|10312";
            this.m_btnAficherMasque.ToolTipText = "Show Alarms masked from specified level";
            this.m_btnAficherMasque.Click += new System.EventHandler(this.m_btnAficherMasque_Click);
            // 
            // m_chkAlwaysOnTop
            // 
            this.m_chkAlwaysOnTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_chkAlwaysOnTop.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_chkAlwaysOnTop.BackColor = System.Drawing.Color.Transparent;
            this.m_chkAlwaysOnTop.FlatAppearance.BorderSize = 0;
            this.m_chkAlwaysOnTop.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.m_chkAlwaysOnTop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.m_chkAlwaysOnTop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(190)))));
            this.m_chkAlwaysOnTop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkAlwaysOnTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_chkAlwaysOnTop.ForeColor = System.Drawing.Color.White;
            this.m_chkAlwaysOnTop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_chkAlwaysOnTop.ImageIndex = 0;
            this.m_chkAlwaysOnTop.ImageList = this.m_imagesBoutons16x16;
            this.m_chkAlwaysOnTop.Location = new System.Drawing.Point(623, 4);
            this.m_chkAlwaysOnTop.Name = "m_chkAlwaysOnTop";
            this.m_chkAlwaysOnTop.Size = new System.Drawing.Size(130, 24);
            this.m_extStyle.SetStyleBackColor(this.m_chkAlwaysOnTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkAlwaysOnTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkAlwaysOnTop.TabIndex = 4;
            this.m_chkAlwaysOnTop.Text = "Always visible|10248";
            this.m_chkAlwaysOnTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.m_chkAlwaysOnTop.UseVisualStyleBackColor = false;
            this.m_chkAlwaysOnTop.CheckedChanged += new System.EventHandler(this.m_chkAlwaysOnTop_CheckedChanged);
            // 
            // m_imagesBoutons16x16
            // 
            this.m_imagesBoutons16x16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imagesBoutons16x16.ImageStream")));
            this.m_imagesBoutons16x16.TransparentColor = System.Drawing.Color.Transparent;
            this.m_imagesBoutons16x16.Images.SetKeyName(0, "pin-yellow_16x16.png");
            this.m_imagesBoutons16x16.Images.SetKeyName(1, "pin-yellow_vertical_16x16.png");
            // 
            // CFormSupervisionSchema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 488);
            this.Controls.Add(this.m_controleSchema);
            this.Controls.Add(this.m_toolStrip);
            this.Controls.Add(this.m_panelTop);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "CFormSupervisionSchema";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.Text = "Supervision|20371";
            this.Load += new System.EventHandler(this.CFormSupervisionSchema_Load);
            this.m_panelTop.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.m_toolStrip.ResumeLayout(false);
            this.m_toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel m_panelTop;
        private CControlSchemaSupervise m_controleSchema;
        private sc2i.win32.common.CExtStyle m_extStyle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button m_btnRefresh;
        private System.Windows.Forms.Button m_btnExit;
        private System.Windows.Forms.Button m_btnHome;
        private System.Windows.Forms.Button m_btnPagePrecedente;
        private System.Windows.Forms.Label m_lblTitre;
        private System.Windows.Forms.ToolStrip m_toolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton m_btnAficherMasque;
        private System.Windows.Forms.CheckBox m_chkAlwaysOnTop;
        private System.Windows.Forms.ImageList m_imagesBoutons16x16;
    }
}