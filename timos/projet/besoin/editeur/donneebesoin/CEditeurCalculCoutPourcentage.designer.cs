namespace timos.projet.besoin
{
    partial class CEditeurCalculCoutPourcentage
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
            this.m_txtPourcentage = new sc2i.win32.common.C2iTextBoxNumerique();
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_txtReferences = new sc2i.win32.common.C2iTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_imageTache = new System.Windows.Forms.PictureBox();
            this.m_lblEgal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageTache)).BeginInit();
            this.SuspendLayout();
            // 
            // m_txtPourcentage
            // 
            this.m_txtPourcentage.Arrondi = 4;
            this.m_txtPourcentage.DecimalAutorise = true;
            this.m_txtPourcentage.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_txtPourcentage.EmptyText = "";
            this.m_txtPourcentage.IntValue = 0;
            this.m_txtPourcentage.Location = new System.Drawing.Point(0, 0);
            this.m_txtPourcentage.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtPourcentage, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtPourcentage.Name = "m_txtPourcentage";
            this.m_txtPourcentage.NullAutorise = false;
            this.m_txtPourcentage.SelectAllOnEnter = true;
            this.m_txtPourcentage.SeparateurMilliers = "";
            this.m_txtPourcentage.Size = new System.Drawing.Size(51, 20);
            this.m_txtPourcentage.TabIndex = 0;
            this.m_txtPourcentage.Text = "0";
            this.m_txtPourcentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtPourcentage.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.m_txtPourcentage.Validated += new System.EventHandler(this.m_txtPourcentage_Validated);
            // 
            // m_txtReferences
            // 
            this.m_txtReferences.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtReferences.EmptyText = "n° séparés par ,";
            this.m_txtReferences.Location = new System.Drawing.Point(100, 0);
            this.m_txtReferences.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtReferences, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtReferences.Name = "m_txtReferences";
            this.m_txtReferences.Size = new System.Drawing.Size(102, 20);
            this.m_txtReferences.TabIndex = 1;
            this.m_txtReferences.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.m_txtReferences.Validated += new System.EventHandler(this.m_txtReferences_Validated);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(51, 0);
            this.m_extModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "% de";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_imageTache
            // 
            this.m_imageTache.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_imageTache.Image = global::timos.Properties.Resources.tache;
            this.m_imageTache.Location = new System.Drawing.Point(84, 0);
            this.m_extModeEdition.SetModeEdition(this.m_imageTache, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_imageTache.Name = "m_imageTache";
            this.m_imageTache.Size = new System.Drawing.Size(16, 21);
            this.m_imageTache.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_imageTache.TabIndex = 3;
            this.m_imageTache.TabStop = false;
            // 
            // m_lblEgal
            // 
            this.m_lblEgal.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_lblEgal.Location = new System.Drawing.Point(202, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lblEgal, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblEgal.Name = "m_lblEgal";
            this.m_lblEgal.Size = new System.Drawing.Size(13, 21);
            this.m_lblEgal.TabIndex = 13;
            this.m_lblEgal.Text = "=";
            this.m_lblEgal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CEditeurCalculCoutPourcentage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_txtReferences);
            this.Controls.Add(this.m_imageTache);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_txtPourcentage);
            this.Controls.Add(this.m_lblEgal);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CEditeurCalculCoutPourcentage";
            this.Size = new System.Drawing.Size(215, 21);
            ((System.ComponentModel.ISupportInitialize)(this.m_imageTache)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private sc2i.win32.common.C2iTextBoxNumerique m_txtPourcentage;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
        private sc2i.win32.common.C2iTextBox m_txtReferences;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox m_imageTache;
        private System.Windows.Forms.Label m_lblEgal;
    }
}
