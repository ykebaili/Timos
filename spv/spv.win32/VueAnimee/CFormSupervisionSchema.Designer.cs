namespace spv.win32.VueAnimee
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
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormSupervisionSchema));
            this.m_panelTop = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_lblTitre = new System.Windows.Forms.Label();
            this.m_btnRefresh = new System.Windows.Forms.Button();
            this.m_btnExit = new System.Windows.Forms.Button();
            this.m_btnHome = new System.Windows.Forms.Button();
            this.m_btnPagePrecedente = new System.Windows.Forms.Button();
            this.m_controleSchema = new spv.win32.VueAnimee.CControlSchemaSupervise();
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.m_chkALwaysVisible = new System.Windows.Forms.CheckBox();
            this.m_panelTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelTop
            // 
            this.m_panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelTop.Controls.Add(this.m_chkALwaysVisible);
            this.m_panelTop.Controls.Add(this.panel1);
            this.m_panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelTop.Location = new System.Drawing.Point(0, 0);
            this.m_panelTop.Name = "m_panelTop";
            this.m_panelTop.Size = new System.Drawing.Size(589, 54);
            this.m_extStyle.SetStyleBackColor(this.m_panelTop, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panelTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelTop.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(41)))), ((int)(((byte)(131)))));
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.m_lblTitre);
            this.panel1.Controls.Add(this.m_btnRefresh);
            this.panel1.Controls.Add(this.m_btnExit);
            this.panel1.Controls.Add(this.m_btnHome);
            this.panel1.Controls.Add(this.m_btnPagePrecedente);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(589, 32);
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
            this.m_lblTitre.Size = new System.Drawing.Size(337, 23);
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
            this.m_controleSchema.Location = new System.Drawing.Point(0, 54);
            this.m_controleSchema.Name = "m_controleSchema";
            this.m_controleSchema.Size = new System.Drawing.Size(589, 313);
            this.m_extStyle.SetStyleBackColor(this.m_controleSchema, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_controleSchema, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_controleSchema.TabIndex = 1;
            this.m_controleSchema.OnChangeSchemaAffiche += new System.EventHandler(this.m_controleSchema_OnChangeSchemaAffiche);
            // 
            // m_chkALwaysVisible
            // 
            this.m_chkALwaysVisible.AutoSize = true;
            this.m_chkALwaysVisible.Location = new System.Drawing.Point(12, 34);
            this.m_chkALwaysVisible.Name = "m_chkALwaysVisible";
            this.m_chkALwaysVisible.Size = new System.Drawing.Size(123, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkALwaysVisible, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkALwaysVisible, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkALwaysVisible.TabIndex = 4;
            this.m_chkALwaysVisible.Text = "Always visible|10019";
            this.m_chkALwaysVisible.UseVisualStyleBackColor = true;
            this.m_chkALwaysVisible.CheckedChanged += new System.EventHandler(this.m_chkALwaysVisible_CheckedChanged);
            // 
            // CFormSupervisionSchema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 367);
            this.Controls.Add(this.m_controleSchema);
            this.Controls.Add(this.m_panelTop);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "CFormSupervisionSchema";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.Text = "Supervision|20014";
            this.Load += new System.EventHandler(this.CFormSupervisionSchema_Load);
            this.m_panelTop.ResumeLayout(false);
            this.m_panelTop.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.CheckBox m_chkALwaysVisible;
    }
}