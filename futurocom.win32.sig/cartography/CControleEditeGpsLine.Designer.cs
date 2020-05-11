namespace futurocom.win32.sig.cartography
{
    partial class CControleEditeGpsLine
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
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.panel5 = new System.Windows.Forms.Panel();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_txtTypeLigne = new sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.m_txtLibelle);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 23);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(216, 27);
            this.panel5.TabIndex = 0;
            // 
            // m_txtLibelle
            // 
            this.m_txtLibelle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtLibelle.EmptyText = "";
            this.m_txtLibelle.Location = new System.Drawing.Point(76, 0);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(140, 20);
            this.m_txtLibelle.TabIndex = 4;
            this.m_txtLibelle.Validated += new System.EventHandler(this.m_txtLibelle_Validated);
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 27);
            this.label5.TabIndex = 3;
            this.label5.Text = "Text|20052";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Line|20058";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_txtTypeLigne);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(216, 27);
            this.panel1.TabIndex = 6;
            // 
            // m_txtTypeLigne
            // 
            this.m_txtTypeLigne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtTypeLigne.ElementSelectionne = null;
            this.m_txtTypeLigne.FonctionTextNull = null;
            this.m_txtTypeLigne.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_txtTypeLigne.Location = new System.Drawing.Point(76, 0);
            this.m_txtTypeLigne.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtTypeLigne, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtTypeLigne.Name = "m_txtTypeLigne";
            this.m_txtTypeLigne.SelectedObject = null;
            this.m_txtTypeLigne.SelectionLength = 0;
            this.m_txtTypeLigne.SelectionStart = 0;
            this.m_txtTypeLigne.Size = new System.Drawing.Size(140, 27);
            this.m_txtTypeLigne.SpecificImage = null;
            this.m_txtTypeLigne.TabIndex = 5;
            this.m_txtTypeLigne.TextNull = "";
            this.m_txtTypeLigne.UseIntellisense = true;
            this.m_txtTypeLigne.ElementSelectionneChanged += new System.EventHandler(this.m_txtTypeLigne_ElementSelectionneChanged);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "Line type|20065";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CControleEditeGpsLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.label1);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleEditeGpsLine";
            this.Size = new System.Drawing.Size(216, 241);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label5;
        private sc2i.win32.common.C2iTextBox m_txtLibelle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide m_txtTypeLigne;
    }
}
