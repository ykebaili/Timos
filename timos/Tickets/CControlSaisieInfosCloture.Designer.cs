using sc2i.common;

namespace timos
{
    partial class CControlSaisieInfosCloture
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
            this.m_txtInfosCloture = new sc2i.win32.common.C2iTextBox();
            this.m_cmbxSelectEtatCloture = new sc2i.win32.data.CComboBoxListeObjetsDonnees();
            this.m_txtSelectResoluPar = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.lbl_datecloture = new System.Windows.Forms.Label();
            this.lbl_etat = new System.Windows.Forms.Label();
            this.lbl_responsable = new System.Windows.Forms.Label();
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.lbl_info = new System.Windows.Forms.Label();
            this.m_dateClotureTech = new sc2i.win32.common.C2iDateTimeExPicker();
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_extLinkField = new sc2i.win32.common.CExtLinkField();
            this.SuspendLayout();
            // 
            // m_txtInfosCloture
            // 
            this.m_txtInfosCloture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtInfosCloture.BackColor = System.Drawing.Color.White;
            this.m_extLinkField.SetLinkField(this.m_txtInfosCloture, "InfosCloture");
            this.m_txtInfosCloture.Location = new System.Drawing.Point(3, 82);
            this.m_txtInfosCloture.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtInfosCloture, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtInfosCloture.Multiline = true;
            this.m_txtInfosCloture.Name = "m_txtInfosCloture";
            this.m_txtInfosCloture.Size = new System.Drawing.Size(360, 51);
            this.m_extStyle.SetStyleBackColor(this.m_txtInfosCloture, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtInfosCloture, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtInfosCloture.TabIndex = 7;
            this.m_txtInfosCloture.Text = "[InfosCloture]";
            // 
            // m_cmbxSelectEtatCloture
            // 
            this.m_cmbxSelectEtatCloture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbxSelectEtatCloture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbxSelectEtatCloture.ElementSelectionne = null;
            this.m_cmbxSelectEtatCloture.FormattingEnabled = true;
            this.m_cmbxSelectEtatCloture.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbxSelectEtatCloture, "");
            this.m_cmbxSelectEtatCloture.ListDonnees = null;
            this.m_cmbxSelectEtatCloture.Location = new System.Drawing.Point(140, 41);
            this.m_cmbxSelectEtatCloture.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbxSelectEtatCloture, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbxSelectEtatCloture.Name = "m_cmbxSelectEtatCloture";
            this.m_cmbxSelectEtatCloture.NullAutorise = false;
            this.m_cmbxSelectEtatCloture.ProprieteAffichee = null;
            this.m_cmbxSelectEtatCloture.ProprieteParentListeObjets = null;
            this.m_cmbxSelectEtatCloture.SelectionneurParent = null;
            this.m_cmbxSelectEtatCloture.Size = new System.Drawing.Size(176, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbxSelectEtatCloture, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbxSelectEtatCloture, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbxSelectEtatCloture.TabIndex = 3;
            this.m_cmbxSelectEtatCloture.TextNull = "(vide)";
            this.m_cmbxSelectEtatCloture.Tri = true;
            // 
            // m_txtSelectResoluPar
            // 
            this.m_txtSelectResoluPar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtSelectResoluPar.ElementSelectionne = null;
            this.m_txtSelectResoluPar.FonctionTextNull = null;
            this.m_txtSelectResoluPar.HasLink = true;
            this.m_extLinkField.SetLinkField(this.m_txtSelectResoluPar, "");
            this.m_txtSelectResoluPar.Location = new System.Drawing.Point(140, 20);
            this.m_txtSelectResoluPar.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectResoluPar, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtSelectResoluPar.Name = "m_txtSelectResoluPar";
            this.m_txtSelectResoluPar.SelectedObject = null;
            this.m_txtSelectResoluPar.Size = new System.Drawing.Size(223, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtSelectResoluPar, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSelectResoluPar, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectResoluPar.TabIndex = 2;
            this.m_txtSelectResoluPar.TextNull = "";
            // 
            // lbl_datecloture
            // 
            this.m_extLinkField.SetLinkField(this.lbl_datecloture, "");
            this.lbl_datecloture.Location = new System.Drawing.Point(-1, 4);
            this.lbl_datecloture.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_datecloture, sc2i.win32.common.TypeModeEdition.Autonome);
            this.lbl_datecloture.Name = "lbl_datecloture";
            this.lbl_datecloture.Size = new System.Drawing.Size(154, 13);
            this.m_extStyle.SetStyleBackColor(this.lbl_datecloture, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.lbl_datecloture, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_datecloture.TabIndex = 0;
            this.lbl_datecloture.Text = "Technical closing date |622";
            // 
            // lbl_etat
            // 
            this.m_extLinkField.SetLinkField(this.lbl_etat, "");
            this.lbl_etat.Location = new System.Drawing.Point(-1, 44);
            this.lbl_etat.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_etat, sc2i.win32.common.TypeModeEdition.Autonome);
            this.lbl_etat.Name = "lbl_etat";
            this.lbl_etat.Size = new System.Drawing.Size(154, 15);
            this.m_extStyle.SetStyleBackColor(this.lbl_etat, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.lbl_etat, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_etat.TabIndex = 0;
            this.lbl_etat.Text = "Ticket closing state |624";
            // 
            // lbl_responsable
            // 
            this.m_extLinkField.SetLinkField(this.lbl_responsable, "");
            this.lbl_responsable.Location = new System.Drawing.Point(-1, 24);
            this.lbl_responsable.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_responsable, sc2i.win32.common.TypeModeEdition.Autonome);
            this.lbl_responsable.Name = "lbl_responsable";
            this.lbl_responsable.Size = new System.Drawing.Size(154, 14);
            this.m_extStyle.SetStyleBackColor(this.lbl_responsable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.lbl_responsable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_responsable.TabIndex = 0;
            this.lbl_responsable.Text = "Person in charge of closing :|623";
            // 
            // lbl_info
            // 
            this.m_extLinkField.SetLinkField(this.lbl_info, "");
            this.lbl_info.Location = new System.Drawing.Point(-1, 65);
            this.lbl_info.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_info, sc2i.win32.common.TypeModeEdition.Autonome);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(232, 18);
            this.m_extStyle.SetStyleBackColor(this.lbl_info, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.lbl_info, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_info.TabIndex = 0;
            this.lbl_info.Text = "Ticket closing information  |625";
            // 
            // m_dateClotureTech
            // 
            this.m_dateClotureTech.Checked = false;
            this.m_dateClotureTech.CustomFormat = "dd/MM/yyyy  HH:mm";
            this.m_dateClotureTech.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_extLinkField.SetLinkField(this.m_dateClotureTech, "");
            this.m_dateClotureTech.Location = new System.Drawing.Point(140, 1);
            this.m_dateClotureTech.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_dateClotureTech, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_dateClotureTech.Name = "m_dateClotureTech";
            this.m_dateClotureTech.Size = new System.Drawing.Size(175, 20);
            this.m_extStyle.SetStyleBackColor(this.m_dateClotureTech, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_dateClotureTech, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_dateClotureTech.TabIndex = 8;
            this.m_dateClotureTech.TextNull = I.T("None|148");
            // 
            // CControlSaisieInfosCloture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_dateClotureTech);
            this.Controls.Add(this.m_cmbxSelectEtatCloture);
            this.Controls.Add(this.m_txtInfosCloture);
            this.Controls.Add(this.m_txtSelectResoluPar);
            this.Controls.Add(this.lbl_info);
            this.Controls.Add(this.lbl_datecloture);
            this.Controls.Add(this.lbl_responsable);
            this.Controls.Add(this.lbl_etat);
            this.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControlSaisieInfosCloture";
            this.Size = new System.Drawing.Size(366, 137);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.Load += new System.EventHandler(this.CControlSaisieInfosCloture_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private sc2i.win32.common.C2iTextBox m_txtInfosCloture;
        private System.Windows.Forms.Label lbl_datecloture;
        private System.Windows.Forms.Label lbl_responsable;
        private System.Windows.Forms.Label lbl_etat;
        private sc2i.win32.data.CComboBoxListeObjetsDonnees m_cmbxSelectEtatCloture;
        private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_txtSelectResoluPar;
        protected sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
        private sc2i.win32.common.CExtStyle m_extStyle;
        private sc2i.win32.common.CExtLinkField m_extLinkField;
        private System.Windows.Forms.Label lbl_info;
        private sc2i.win32.common.C2iDateTimeExPicker m_dateClotureTech;
    }
}
