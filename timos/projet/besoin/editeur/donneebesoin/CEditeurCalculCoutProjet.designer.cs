namespace timos.projet.besoin
{
    partial class CEditeurCalculCoutProjet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CEditeurCalculCoutProjet));
            this.m_panelControlesDetailCout = new System.Windows.Forms.Panel();
            this.m_txtCoutUnitaire = new sc2i.win32.common.C2iTextBoxNumerique();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.m_menuUnites = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_panelControlesDetailCout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // m_panelControlesDetailCout
            // 
            this.m_panelControlesDetailCout.Controls.Add(this.m_txtCoutUnitaire);
            this.m_panelControlesDetailCout.Controls.Add(this.pictureBox1);
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
            this.m_txtCoutUnitaire.Location = new System.Drawing.Point(0, 0);
            this.m_txtCoutUnitaire.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtCoutUnitaire, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtCoutUnitaire.Name = "m_txtCoutUnitaire";
            this.m_txtCoutUnitaire.NullAutorise = true;
            this.m_txtCoutUnitaire.SelectAllOnEnter = true;
            this.m_txtCoutUnitaire.SeparateurMilliers = " ";
            this.m_txtCoutUnitaire.Size = new System.Drawing.Size(199, 20);
            this.m_txtCoutUnitaire.TabIndex = 1;
            this.m_txtCoutUnitaire.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtCoutUnitaire.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.m_txtCoutUnitaire.Validated += new System.EventHandler(this.m_txtCoutUnitaire_Validated);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(199, 0);
            this.m_extModeEdition.SetModeEdition(this.pictureBox1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 21);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // m_menuUnites
            // 
            this.m_extModeEdition.SetModeEdition(this.m_menuUnites, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_menuUnites.Name = "m_menuUnites";
            this.m_menuUnites.Size = new System.Drawing.Size(61, 4);
            // 
            // CEditeurCalculCoutProjet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_panelControlesDetailCout);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CEditeurCalculCoutProjet";
            this.Size = new System.Drawing.Size(215, 21);
            this.m_panelControlesDetailCout.ResumeLayout(false);
            this.m_panelControlesDetailCout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel m_panelControlesDetailCout;
        private System.Windows.Forms.PictureBox pictureBox1;
        private sc2i.win32.common.C2iTextBoxNumerique m_txtCoutUnitaire;
        private System.Windows.Forms.ContextMenuStrip m_menuUnites;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
    }
}
