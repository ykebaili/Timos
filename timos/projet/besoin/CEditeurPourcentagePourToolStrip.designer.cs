using sc2i.win32.common;
namespace timos.projet.besoin
{
    partial class CEditeurPourcentagePourToolStrip
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
            this.m_txtId = new sc2i.win32.common.C2iTextBoxNumerique();
            this.label1 = new System.Windows.Forms.Label();
            this.m_picValider = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_picValider)).BeginInit();
            this.SuspendLayout();
            // 
            // m_txtId
            // 
            this.m_txtId.Arrondi = 4;
            this.m_txtId.DecimalAutorise = true;
            this.m_txtId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtId.EmptyText = "";
            this.m_txtId.IntValue = 0;
            this.m_txtId.Location = new System.Drawing.Point(0, 0);
            this.m_txtId.LockEdition = false;
            this.m_txtId.Name = "m_txtId";
            this.m_txtId.NullAutorise = false;
            this.m_txtId.SelectAllOnEnter = true;
            this.m_txtId.SeparateurMilliers = "";
            this.m_txtId.Size = new System.Drawing.Size(119, 20);
            this.m_txtId.TabIndex = 0;
            this.m_txtId.Text = "0";
            this.m_txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtId_KeyDown);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(119, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "%";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_picValider
            // 
            this.m_picValider.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_picValider.Image = global::timos.Properties.Resources.check;
            this.m_picValider.Location = new System.Drawing.Point(142, 0);
            this.m_picValider.Name = "m_picValider";
            this.m_picValider.Size = new System.Drawing.Size(20, 20);
            this.m_picValider.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_picValider.TabIndex = 2;
            this.m_picValider.TabStop = false;
            this.m_picValider.Click += new System.EventHandler(this.m_picValider_Click);
            // 
            // CEditeurPourcentagePourToolStrip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_txtId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_picValider);
            this.Name = "CEditeurPourcentagePourToolStrip";
            this.Size = new System.Drawing.Size(162, 20);
            ((System.ComponentModel.ISupportInitialize)(this.m_picValider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C2iTextBoxNumerique m_txtId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox m_picValider;
    }
}
