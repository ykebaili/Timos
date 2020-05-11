namespace timos.Controles.ActionsSurLink
{
    partial class CPanelEditeActionSurLinkFormulairePopup
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
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.m_panelEditionFormulaire = new sc2i.formulaire.win32.editor.CPanelEditionFullFormulaire();
            this.m_panelTop = new System.Windows.Forms.Panel();
            this.m_wndFormuleElementEdite = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelEditionFormulaire
            // 
            this.m_panelEditionFormulaire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelEditionFormulaire.EntiteEditee = null;
            this.m_panelEditionFormulaire.FournisseurProprietes = null;
            this.m_panelEditionFormulaire.Location = new System.Drawing.Point(0, 68);
            this.m_panelEditionFormulaire.LockEdition = true;
            this.m_panelEditionFormulaire.Name = "m_panelEditionFormulaire";
            this.m_panelEditionFormulaire.Size = new System.Drawing.Size(610, 266);
            this.m_extStyle.SetStyleBackColor(this.m_panelEditionFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEditionFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEditionFormulaire.TabIndex = 1;
            this.m_panelEditionFormulaire.TypeEdite = null;
            this.m_panelEditionFormulaire.WndEditee = null;
            // 
            // m_panelTop
            // 
            this.m_panelTop.Controls.Add(this.m_wndFormuleElementEdite);
            this.m_panelTop.Controls.Add(this.label2);
            this.m_panelTop.Controls.Add(this.m_txtLibelle);
            this.m_panelTop.Controls.Add(this.label1);
            this.m_panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelTop.Location = new System.Drawing.Point(0, 0);
            this.m_panelTop.Name = "m_panelTop";
            this.m_panelTop.Size = new System.Drawing.Size(610, 68);
            this.m_extStyle.SetStyleBackColor(this.m_panelTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelTop.TabIndex = 2;
            // 
            // m_wndFormuleElementEdite
            // 
            this.m_wndFormuleElementEdite.AllowGraphic = true;
            this.m_wndFormuleElementEdite.AllowNullFormula = false;
            this.m_wndFormuleElementEdite.AllowSaisieTexte = true;
            this.m_wndFormuleElementEdite.Formule = null;
            this.m_wndFormuleElementEdite.Location = new System.Drawing.Point(163, 35);
            this.m_wndFormuleElementEdite.LockEdition = false;
            this.m_wndFormuleElementEdite.LockZoneTexte = false;
            this.m_wndFormuleElementEdite.Name = "m_wndFormuleElementEdite";
            this.m_wndFormuleElementEdite.Size = new System.Drawing.Size(316, 22);
            this.m_extStyle.SetStyleBackColor(this.m_wndFormuleElementEdite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndFormuleElementEdite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndFormuleElementEdite.TabIndex = 3;
            this.m_wndFormuleElementEdite.OnChangeTexteFormule += new System.EventHandler(this.m_wndFormuleElementEdite_OnChangeTexteFormule);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 23);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 2;
            this.label2.Text = "Edited element Formula|10412";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtLibelle
            // 
            this.m_txtLibelle.EmptyText = "";
            this.m_txtLibelle.Location = new System.Drawing.Point(66, 6);
            this.m_txtLibelle.LockEdition = false;
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(413, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 25);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 0;
            this.label1.Text = "Label|50";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CPanelEditeActionSurLinkFormulairePopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.m_panelEditionFormulaire);
            this.Controls.Add(this.m_panelTop);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "CPanelEditeActionSurLinkFormulairePopup";
            this.Size = new System.Drawing.Size(610, 334);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelTop.ResumeLayout(false);
            this.m_panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.CExtStyle m_extStyle;
        private sc2i.formulaire.win32.editor.CPanelEditionFullFormulaire m_panelEditionFormulaire;
        private System.Windows.Forms.Panel m_panelTop;
        private sc2i.win32.common.C2iTextBox m_txtLibelle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private sc2i.win32.expression.CTextBoxZoomFormule m_wndFormuleElementEdite;
    }
}
