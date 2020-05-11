namespace timos.projet.besoin
{
    partial class CEditeurDonneesBesoinProjet
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
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_txtReferences = new sc2i.win32.common.C2iTextBox();
            this.m_txtSelectTypeProjet = new sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtDuree = new sc2i.win32.common.C2iTextBoxNumeriqueAvecUnite();
            this.m_txtTemplateKey = new sc2i.win32.common.C2iTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.m_btnFormula = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnFormula)).BeginInit();
            this.SuspendLayout();
            // 
            // m_txtReferences
            // 
            this.m_txtReferences.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_txtReferences.EmptyText = "n° séparés par ,";
            this.m_txtReferences.Location = new System.Drawing.Point(532, 0);
            this.m_txtReferences.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtReferences, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtReferences.Name = "m_txtReferences";
            this.m_txtReferences.Size = new System.Drawing.Size(98, 20);
            this.m_txtReferences.TabIndex = 3;
            this.m_txtReferences.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.m_txtReferences.Validated += new System.EventHandler(this.m_txtReferences_Validated);
            // 
            // m_txtSelectTypeProjet
            // 
            this.m_txtSelectTypeProjet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtSelectTypeProjet.ElementSelectionne = null;
            this.m_txtSelectTypeProjet.FonctionTextNull = null;
            this.m_txtSelectTypeProjet.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_txtSelectTypeProjet.Location = new System.Drawing.Point(140, 0);
            this.m_txtSelectTypeProjet.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtSelectTypeProjet, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtSelectTypeProjet.Name = "m_txtSelectTypeProjet";
            this.m_txtSelectTypeProjet.SelectedObject = null;
            this.m_txtSelectTypeProjet.SelectionLength = 0;
            this.m_txtSelectTypeProjet.SelectionStart = 0;
            this.m_txtSelectTypeProjet.Size = new System.Drawing.Size(81, 21);
            this.m_txtSelectTypeProjet.SpecificImage = null;
            this.m_txtSelectTypeProjet.TabIndex = 0;
            this.m_txtSelectTypeProjet.TextNull = "";
            this.m_txtSelectTypeProjet.UseIntellisense = true;
            this.m_txtSelectTypeProjet.ElementSelectionneChanged += new System.EventHandler(this.m_txtSelectTypeProjet_ElementSelectionneChanged);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Projet type|20713";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(442, 0);
            this.m_extModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "Predecessors|20714";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(331, 0);
            this.m_extModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 21);
            this.label3.TabIndex = 7;
            this.label3.Text = "Duration|20715";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtDuree
            // 
            this.m_txtDuree.AllowNoUnit = false;
            this.m_txtDuree.DefaultFormat = "";
            this.m_txtDuree.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_txtDuree.EmptyText = "n° séparés par ,";
            this.m_txtDuree.Location = new System.Drawing.Point(384, 0);
            this.m_txtDuree.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtDuree, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtDuree.Name = "m_txtDuree";
            this.m_txtDuree.Size = new System.Drawing.Size(58, 20);
            this.m_txtDuree.TabIndex = 2;
            this.m_txtDuree.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtDuree.UnitValue = null;
            this.m_txtDuree.UseValueFormat = false;
            this.m_txtDuree.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // m_txtTemplateKey
            // 
            this.m_txtTemplateKey.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_txtTemplateKey.EmptyText = "Template key|20800";
            this.m_txtTemplateKey.Location = new System.Drawing.Point(255, 0);
            this.m_txtTemplateKey.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtTemplateKey, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtTemplateKey.Name = "m_txtTemplateKey";
            this.m_txtTemplateKey.Size = new System.Drawing.Size(76, 20);
            this.m_txtTemplateKey.TabIndex = 1;
            this.m_txtTemplateKey.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = global::timos.Properties.Resources.cle;
            this.pictureBox1.Location = new System.Drawing.Point(239, 0);
            this.m_extModeEdition.SetModeEdition(this.pictureBox1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 21);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // m_btnFormula
            // 
            this.m_btnFormula.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnFormula.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnFormula.Image = global::timos.Properties.Resources.formula;
            this.m_btnFormula.Location = new System.Drawing.Point(221, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnFormula, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnFormula.Name = "m_btnFormula";
            this.m_btnFormula.Size = new System.Drawing.Size(18, 21);
            this.m_btnFormula.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.m_btnFormula.TabIndex = 9;
            this.m_btnFormula.TabStop = false;
            this.m_btnFormula.Click += new System.EventHandler(this.m_btnFormula_Click);
            // 
            // CEditeurDonneesBesoinProjet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_txtSelectTypeProjet);
            this.Controls.Add(this.m_btnFormula);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.m_txtTemplateKey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_txtDuree);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_txtReferences);
            this.Controls.Add(this.label2);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CEditeurDonneesBesoinProjet";
            this.Size = new System.Drawing.Size(630, 21);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnFormula)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
        private sc2i.win32.common.C2iTextBox m_txtReferences;
        private sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide m_txtSelectTypeProjet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private sc2i.win32.common.C2iTextBoxNumeriqueAvecUnite m_txtDuree;
        private System.Windows.Forms.PictureBox pictureBox1;
        private sc2i.win32.common.C2iTextBox m_txtTemplateKey;
        private System.Windows.Forms.PictureBox m_btnFormula;
    }
}
