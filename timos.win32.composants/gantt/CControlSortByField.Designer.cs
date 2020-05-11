namespace timos.win32.composants.gantt
{
    partial class CControlSortByField
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_rbtnDecroissant = new System.Windows.Forms.RadioButton();
            this.m_rbtnCroissant = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_lblSortBy = new System.Windows.Forms.Label();
            this.m_selectChamp = new sc2i.win32.data.dynamic.CControlSelectDefinitionPropriete();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_rbtnDecroissant);
            this.panel2.Controls.Add(this.m_rbtnCroissant);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(429, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(121, 45);
            this.panel2.TabIndex = 5;
            // 
            // m_rbtnDecroissant
            // 
            this.m_rbtnDecroissant.AutoSize = true;
            this.m_rbtnDecroissant.Location = new System.Drawing.Point(7, 26);
            this.m_rbtnDecroissant.Name = "m_rbtnDecroissant";
            this.m_rbtnDecroissant.Size = new System.Drawing.Size(114, 17);
            this.m_rbtnDecroissant.TabIndex = 1;
            this.m_rbtnDecroissant.TabStop = true;
            this.m_rbtnDecroissant.Text = "Descending|20014";
            this.m_rbtnDecroissant.UseVisualStyleBackColor = true;
            // 
            // m_rbtnCroissant
            // 
            this.m_rbtnCroissant.AutoSize = true;
            this.m_rbtnCroissant.Location = new System.Drawing.Point(7, 4);
            this.m_rbtnCroissant.Name = "m_rbtnCroissant";
            this.m_rbtnCroissant.Size = new System.Drawing.Size(107, 17);
            this.m_rbtnCroissant.TabIndex = 0;
            this.m_rbtnCroissant.TabStop = true;
            this.m_rbtnCroissant.Text = "Ascending|20013";
            this.m_rbtnCroissant.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_selectChamp);
            this.panel1.Controls.Add(this.m_lblSortBy);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(429, 45);
            this.panel1.TabIndex = 6;
            // 
            // m_lblSortBy
            // 
            this.m_lblSortBy.AutoSize = true;
            this.m_lblSortBy.Location = new System.Drawing.Point(4, 4);
            this.m_lblSortBy.Name = "m_lblSortBy";
            this.m_lblSortBy.Size = new System.Drawing.Size(72, 13);
            this.m_lblSortBy.TabIndex = 5;
            this.m_lblSortBy.Text = "Sort by|20011";
            // 
            // m_selectChamp
            // 
            this.m_selectChamp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_selectChamp.DefinitionSelectionnee = null;
            this.m_selectChamp.Location = new System.Drawing.Point(7, 20);
            this.m_selectChamp.Name = "m_selectChamp";
            this.m_selectChamp.Size = new System.Drawing.Size(416, 21);
            this.m_selectChamp.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(0, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(550, 1);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // CControlSortByField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Name = "CControlSortByField";
            this.Size = new System.Drawing.Size(550, 46);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton m_rbtnDecroissant;
        private System.Windows.Forms.RadioButton m_rbtnCroissant;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label m_lblSortBy;
        private sc2i.win32.data.dynamic.CControlSelectDefinitionPropriete m_selectChamp;
        private System.Windows.Forms.Label label1;
    }
}
