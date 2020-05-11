namespace timos.projet.Contraintes
{
    partial class CControlEditionContrainteDeProjet
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_dtContrainte = new sc2i.win32.common.C2iDateTimePicker();
            this.m_selectModeContrainte = new sc2i.win32.common.CComboboxAutoFilled();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txtCommentaire = new sc2i.win32.common.C2iTextBox();
            this.m_lnkDelete = new sc2i.win32.common.CWndLinkStd();
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 3);
            this.m_extModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Type|10081";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(247, 4);
            this.m_extModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Date|10082";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_dtContrainte
            // 
            this.m_dtContrainte.CustomFormat = "dd/MM/yyyy HH:mm";
            this.m_dtContrainte.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtContrainte.Location = new System.Drawing.Point(297, 3);
            this.m_dtContrainte.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_dtContrainte, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_dtContrainte.Name = "m_dtContrainte";
            this.m_dtContrainte.Size = new System.Drawing.Size(113, 20);
            this.m_dtContrainte.TabIndex = 4;
            this.m_dtContrainte.Value = new System.DateTime(2010, 9, 22, 16, 57, 35, 667);
            // 
            // m_selectModeContrainte
            // 
            this.m_selectModeContrainte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_selectModeContrainte.FormattingEnabled = true;
            this.m_selectModeContrainte.IsLink = false;
            this.m_selectModeContrainte.ListDonnees = null;
            this.m_selectModeContrainte.Location = new System.Drawing.Point(76, 3);
            this.m_selectModeContrainte.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_selectModeContrainte, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_selectModeContrainte.Name = "m_selectModeContrainte";
            this.m_selectModeContrainte.NullAutorise = false;
            this.m_selectModeContrainte.ProprieteAffichee = null;
            this.m_selectModeContrainte.Size = new System.Drawing.Size(165, 21);
            this.m_selectModeContrainte.TabIndex = 24;
            this.m_selectModeContrainte.TextNull = "(empty)";
            this.m_selectModeContrainte.Tri = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(4, 29);
            this.m_extModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "Comment|10084";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtCommentaire
            // 
            this.m_txtCommentaire.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtCommentaire.Location = new System.Drawing.Point(76, 29);
            this.m_txtCommentaire.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtCommentaire, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtCommentaire.Name = "m_txtCommentaire";
            this.m_txtCommentaire.Size = new System.Drawing.Size(476, 20);
            this.m_txtCommentaire.TabIndex = 25;
            // 
            // m_lnkDelete
            // 
            this.m_lnkDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lnkDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkDelete.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkDelete.Location = new System.Drawing.Point(558, 3);
            this.m_extModeEdition.SetModeEdition(this.m_lnkDelete, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkDelete.Name = "m_lnkDelete";
            this.m_lnkDelete.Size = new System.Drawing.Size(27, 22);
            this.m_lnkDelete.TabIndex = 26;
            this.m_lnkDelete.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkDelete.LinkClicked += new System.EventHandler(this.m_lnkDelete_LinkClicked);
            // 
            // CControlEditionContrainteDeProjet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.m_lnkDelete);
            this.Controls.Add(this.m_txtCommentaire);
            this.Controls.Add(this.m_selectModeContrainte);
            this.Controls.Add(this.m_dtContrainte);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControlEditionContrainteDeProjet";
            this.Size = new System.Drawing.Size(585, 55);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private sc2i.win32.common.C2iDateTimePicker m_dtContrainte;
        private sc2i.win32.common.CComboboxAutoFilled m_selectModeContrainte;
        private System.Windows.Forms.Label label4;
        private sc2i.win32.common.C2iTextBox m_txtCommentaire;
        private sc2i.win32.common.CWndLinkStd m_lnkDelete;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
    }
}
