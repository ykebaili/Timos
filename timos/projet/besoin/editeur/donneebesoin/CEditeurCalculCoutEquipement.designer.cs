namespace timos.projet.besoin
{
    partial class CEditeurCalculCoutEquipement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CEditeurCalculCoutEquipement));
            this.m_panelControlesDetailCout = new System.Windows.Forms.Panel();
            this.m_txtCoutUnitaire = new sc2i.win32.common.C2iTextBoxNumerique();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.m_lblEgal = new System.Windows.Forms.Label();
            this.m_btnCoutVerrouillé = new System.Windows.Forms.PictureBox();
            this.m_lblx = new System.Windows.Forms.Label();
            this.m_txtQuantité = new sc2i.win32.common.C2iTextBoxNumerique();
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_panelControlesDetailCout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnCoutVerrouillé)).BeginInit();
            this.SuspendLayout();
            // 
            // m_panelControlesDetailCout
            // 
            this.m_panelControlesDetailCout.Controls.Add(this.m_txtCoutUnitaire);
            this.m_panelControlesDetailCout.Controls.Add(this.pictureBox1);
            this.m_panelControlesDetailCout.Controls.Add(this.m_lblEgal);
            this.m_panelControlesDetailCout.Controls.Add(this.m_btnCoutVerrouillé);
            this.m_panelControlesDetailCout.Controls.Add(this.m_lblx);
            this.m_panelControlesDetailCout.Controls.Add(this.m_txtQuantité);
            this.m_panelControlesDetailCout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelControlesDetailCout.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelControlesDetailCout, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelControlesDetailCout.Name = "m_panelControlesDetailCout";
            this.m_panelControlesDetailCout.Size = new System.Drawing.Size(215, 21);
            this.m_panelControlesDetailCout.TabIndex = 9;
            // 
            // m_txtCoutUnitaire
            // 
            this.m_txtCoutUnitaire.Arrondi = 4;
            this.m_txtCoutUnitaire.DecimalAutorise = true;
            this.m_txtCoutUnitaire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtCoutUnitaire.DoubleValue = null;
            this.m_txtCoutUnitaire.EmptyText = "C.U.";
            this.m_txtCoutUnitaire.IntValue = null;
            this.m_txtCoutUnitaire.Location = new System.Drawing.Point(83, 0);
            this.m_txtCoutUnitaire.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtCoutUnitaire, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_txtCoutUnitaire.Name = "m_txtCoutUnitaire";
            this.m_txtCoutUnitaire.NullAutorise = true;
            this.m_txtCoutUnitaire.SelectAllOnEnter = true;
            this.m_txtCoutUnitaire.SeparateurMilliers = " ";
            this.m_txtCoutUnitaire.Size = new System.Drawing.Size(103, 20);
            this.m_txtCoutUnitaire.TabIndex = 1;
            this.m_txtCoutUnitaire.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtCoutUnitaire.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.m_txtCoutUnitaire.Validated += new System.EventHandler(this.m_txtCoutUnitaire_Validated);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(186, 0);
            this.m_extModeEdition.SetModeEdition(this.pictureBox1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 21);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // m_lblEgal
            // 
            this.m_lblEgal.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_lblEgal.Location = new System.Drawing.Point(202, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lblEgal, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblEgal.Name = "m_lblEgal";
            this.m_lblEgal.Size = new System.Drawing.Size(13, 21);
            this.m_lblEgal.TabIndex = 12;
            this.m_lblEgal.Text = "=";
            this.m_lblEgal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_btnCoutVerrouillé
            // 
            this.m_btnCoutVerrouillé.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnCoutVerrouillé.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnCoutVerrouillé.Image = global::timos.Properties.Resources.lock_padlock;
            this.m_btnCoutVerrouillé.Location = new System.Drawing.Point(64, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnCoutVerrouillé, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnCoutVerrouillé.Name = "m_btnCoutVerrouillé";
            this.m_btnCoutVerrouillé.Size = new System.Drawing.Size(19, 21);
            this.m_btnCoutVerrouillé.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_btnCoutVerrouillé.TabIndex = 16;
            this.m_btnCoutVerrouillé.TabStop = false;
            this.m_btnCoutVerrouillé.Click += new System.EventHandler(this.m_btnCoutVerrouillé_Click);
            // 
            // m_lblx
            // 
            this.m_lblx.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lblx.Location = new System.Drawing.Point(51, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lblx, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblx.Name = "m_lblx";
            this.m_lblx.Size = new System.Drawing.Size(13, 21);
            this.m_lblx.TabIndex = 1;
            this.m_lblx.Text = "x";
            this.m_lblx.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_txtQuantité
            // 
            this.m_txtQuantité.Arrondi = 0;
            this.m_txtQuantité.DecimalAutorise = false;
            this.m_txtQuantité.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_txtQuantité.EmptyText = "Qté";
            this.m_txtQuantité.IntValue = 0;
            this.m_txtQuantité.Location = new System.Drawing.Point(0, 0);
            this.m_txtQuantité.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtQuantité, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtQuantité.Name = "m_txtQuantité";
            this.m_txtQuantité.NullAutorise = false;
            this.m_txtQuantité.SelectAllOnEnter = true;
            this.m_txtQuantité.SeparateurMilliers = "";
            this.m_txtQuantité.Size = new System.Drawing.Size(51, 20);
            this.m_txtQuantité.TabIndex = 0;
            this.m_txtQuantité.Text = "0";
            this.m_txtQuantité.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtQuantité.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.m_txtQuantité.Validated += new System.EventHandler(this.m_txtQuantité_Validated);
            // 
            // CEditeurCalculCoutEquipement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_panelControlesDetailCout);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CEditeurCalculCoutEquipement";
            this.Size = new System.Drawing.Size(215, 21);
            this.m_panelControlesDetailCout.ResumeLayout(false);
            this.m_panelControlesDetailCout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnCoutVerrouillé)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel m_panelControlesDetailCout;
        private System.Windows.Forms.PictureBox pictureBox1;
        private sc2i.win32.common.C2iTextBoxNumerique m_txtCoutUnitaire;
        private System.Windows.Forms.Label m_lblEgal;
        private System.Windows.Forms.Label m_lblx;
        private sc2i.win32.common.C2iTextBoxNumerique m_txtQuantité;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
        private System.Windows.Forms.PictureBox m_btnCoutVerrouillé;
    }
}
