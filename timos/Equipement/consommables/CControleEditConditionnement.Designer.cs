namespace timos.Equipement.consommables
{
    partial class CControleEditConditionnement
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
            this.m_lnkSupprimer = new sc2i.win32.common.CWndLinkStd();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtReference = new sc2i.win32.common.C2iTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_numNombreUnite = new sc2i.win32.common.C2iTextBoxNumerique();
            this.m_lblDynamicUnit = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_selectFournisseur = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.SuspendLayout();
            // 
            // m_lnkSupprimer
            // 
            this.m_lnkSupprimer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkSupprimer.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_lnkSupprimer.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkSupprimer.Location = new System.Drawing.Point(656, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkSupprimer, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkSupprimer.Name = "m_lnkSupprimer";
            this.m_lnkSupprimer.Size = new System.Drawing.Size(80, 22);
            this.m_lnkSupprimer.TabIndex = 0;
            this.m_lnkSupprimer.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkSupprimer.LinkClicked += new System.EventHandler(this.m_lnkSupprimer_LinkClicked);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Reference|10374";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtReference
            // 
            this.m_txtReference.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_txtReference.Location = new System.Drawing.Point(73, 0);
            this.m_txtReference.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtReference, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtReference.Name = "m_txtReference";
            this.m_txtReference.Size = new System.Drawing.Size(168, 20);
            this.m_txtReference.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(241, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Number|10388";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_numNombreUnite
            // 
            this.m_numNombreUnite.Arrondi = 0;
            this.m_numNombreUnite.DecimalAutorise = true;
            this.m_numNombreUnite.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_numNombreUnite.IntValue = 0;
            this.m_numNombreUnite.Location = new System.Drawing.Point(295, 0);
            this.m_numNombreUnite.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_numNombreUnite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_numNombreUnite.Name = "m_numNombreUnite";
            this.m_numNombreUnite.NullAutorise = false;
            this.m_numNombreUnite.SelectAllOnEnter = true;
            this.m_numNombreUnite.SeparateurMilliers = "";
            this.m_numNombreUnite.Size = new System.Drawing.Size(100, 20);
            this.m_numNombreUnite.TabIndex = 4;
            // 
            // m_lblDynamicUnit
            // 
            this.m_lblDynamicUnit.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lblDynamicUnit.Location = new System.Drawing.Point(395, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblDynamicUnit, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblDynamicUnit.Name = "m_lblDynamicUnit";
            this.m_lblDynamicUnit.Size = new System.Drawing.Size(33, 22);
            this.m_lblDynamicUnit.TabIndex = 5;
            this.m_lblDynamicUnit.Text = "U";
            this.m_lblDynamicUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(428, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "Supplier|10389";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_selectFournisseur
            // 
            this.m_selectFournisseur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_selectFournisseur.ElementSelectionne = null;
            this.m_selectFournisseur.FonctionTextNull = null;
            this.m_selectFournisseur.HasLink = true;
            this.m_selectFournisseur.Location = new System.Drawing.Point(492, 0);
            this.m_selectFournisseur.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_selectFournisseur, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_selectFournisseur.Name = "m_selectFournisseur";
            this.m_selectFournisseur.SelectedObject = null;
            this.m_selectFournisseur.Size = new System.Drawing.Size(164, 22);
            this.m_selectFournisseur.TabIndex = 7;
            this.m_selectFournisseur.TextNull = "";
            // 
            // CControleEditConditionnement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_selectFournisseur);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_lblDynamicUnit);
            this.Controls.Add(this.m_numNombreUnite);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_txtReference);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_lnkSupprimer);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleEditConditionnement";
            this.Size = new System.Drawing.Size(736, 22);
            this.Load += new System.EventHandler(this.CControleEditConditionnement_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
        private sc2i.win32.common.CWndLinkStd m_lnkSupprimer;
        private System.Windows.Forms.Label label1;
        private sc2i.win32.common.C2iTextBox m_txtReference;
        private System.Windows.Forms.Label label2;
        private sc2i.win32.common.C2iTextBoxNumerique m_numNombreUnite;
        private System.Windows.Forms.Label m_lblDynamicUnit;
        private System.Windows.Forms.Label label3;
        private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_selectFournisseur;
    }
}
