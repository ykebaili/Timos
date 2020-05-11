namespace spv.win32
{
	partial class CFormEditionTableSnmp
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

		#region Code généré par le Concepteur Windows Form

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.m_panel1 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_cmbTypeEquipement = new sc2i.win32.common.CComboboxAutoFilled();
            this.labelExplanation = new System.Windows.Forms.Label();
            this.m_txtBoxOtherOID = new sc2i.win32.common.C2iTextBox();
            this.m_txtBoxSigningOID = new sc2i.win32.common.C2iTextBox();
            this.m_txtBoxOIDName = new sc2i.win32.common.C2iTextBox();
            this.m_txtBoxLibelle = new sc2i.win32.common.C2iTextBox();
            this.labelTableName = new System.Windows.Forms.Label();
            this.labelEquipementType = new System.Windows.Forms.Label();
            this.labelOtherOID = new System.Windows.Forms.Label();
            this.labelSigningOID = new System.Windows.Forms.Label();
            this.labelNameOID = new System.Windows.Forms.Label();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.m_panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnAnnulerModifications
            // 
            this.m_extLinkField.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAnnulerModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnValiderModifications
            // 
            this.m_extLinkField.SetLinkField(this.m_btnValiderModifications, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnValiderModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnSupprimerObjet
            // 
            this.m_extLinkField.SetLinkField(this.m_btnSupprimerObjet, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnSupprimerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnEditerObjet
            // 
            this.m_extLinkField.SetLinkField(this.m_btnEditerObjet, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnEditerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelNavigation
            // 
            this.m_panelNavigation.Location = new System.Drawing.Point(625, 0);
            this.m_extStyle.SetStyleBackColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_lblNbListes
            // 
            this.m_extStyle.SetStyleBackColor(this.m_lblNbListes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblNbListes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnPrecedent
            // 
            this.m_extStyle.SetStyleBackColor(this.m_btnPrecedent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnPrecedent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnSuivant
            // 
            this.m_extStyle.SetStyleBackColor(this.m_btnSuivant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSuivant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnAjout
            // 
            this.m_extStyle.SetStyleBackColor(this.m_btnAjout, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAjout, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_lblId
            // 
            this.m_extStyle.SetStyleBackColor(this.m_lblId, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblId, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelCle
            // 
            this.m_panelCle.Location = new System.Drawing.Point(517, 0);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(800, 32);
            this.m_extStyle.SetStyleBackColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnHistorique
            // 
            this.m_extStyle.SetStyleBackColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_imageCle
            // 
            this.m_extStyle.SetStyleBackColor(this.m_imageCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_imageCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnChercherObjet
            // 
            this.m_extStyle.SetStyleBackColor(this.m_btnChercherObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnChercherObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panel1
            // 
            this.m_panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panel1.Controls.Add(this.m_cmbTypeEquipement);
            this.m_panel1.Controls.Add(this.labelExplanation);
            this.m_panel1.Controls.Add(this.m_txtBoxOtherOID);
            this.m_panel1.Controls.Add(this.m_txtBoxSigningOID);
            this.m_panel1.Controls.Add(this.m_txtBoxOIDName);
            this.m_panel1.Controls.Add(this.m_txtBoxLibelle);
            this.m_panel1.Controls.Add(this.labelTableName);
            this.m_panel1.Controls.Add(this.labelEquipementType);
            this.m_panel1.Controls.Add(this.labelOtherOID);
            this.m_panel1.Controls.Add(this.labelSigningOID);
            this.m_panel1.Controls.Add(this.labelNameOID);
            this.m_panel1.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panel1, "");
            this.m_panel1.Location = new System.Drawing.Point(12, 40);
            this.m_panel1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panel1.Name = "m_panel1";
            this.m_panel1.Size = new System.Drawing.Size(548, 259);
            this.m_extStyle.SetStyleBackColor(this.m_panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panel1.TabIndex = 4003;
            // 
            // m_cmbTypeEquipement
            // 
            this.m_cmbTypeEquipement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTypeEquipement.FormattingEnabled = true;
            this.m_cmbTypeEquipement.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbTypeEquipement, "");
            this.m_cmbTypeEquipement.ListDonnees = null;
            this.m_cmbTypeEquipement.Location = new System.Drawing.Point(233, 50);
            this.m_cmbTypeEquipement.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbTypeEquipement, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbTypeEquipement.Name = "m_cmbTypeEquipement";
            this.m_cmbTypeEquipement.NullAutorise = false;
            this.m_cmbTypeEquipement.ProprieteAffichee = null;
            this.m_cmbTypeEquipement.Size = new System.Drawing.Size(279, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbTypeEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbTypeEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbTypeEquipement.TabIndex = 10;
            this.m_cmbTypeEquipement.TextNull = "(empty)";
            this.m_cmbTypeEquipement.Tri = true;
            // 
            // labelExplanation
            // 
            this.m_extLinkField.SetLinkField(this.labelExplanation, "");
            this.labelExplanation.Location = new System.Drawing.Point(12, 205);
            this.m_gestionnaireModeEdition.SetModeEdition(this.labelExplanation, sc2i.win32.common.TypeModeEdition.Autonome);
            this.labelExplanation.Name = "labelExplanation";
            this.labelExplanation.Size = new System.Drawing.Size(490, 23);
            this.m_extStyle.SetStyleBackColor(this.labelExplanation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.labelExplanation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.labelExplanation.TabIndex = 9;
            this.labelExplanation.Text = "(*) The third field should be edited if the first two are not|50006";
            // 
            // m_txtBoxOtherOID
            // 
            this.m_extLinkField.SetLinkField(this.m_txtBoxOtherOID, "OIDAutre");
            this.m_txtBoxOtherOID.Location = new System.Drawing.Point(233, 153);
            this.m_txtBoxOtherOID.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtBoxOtherOID, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtBoxOtherOID.Name = "m_txtBoxOtherOID";
            this.m_txtBoxOtherOID.Size = new System.Drawing.Size(279, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtBoxOtherOID, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtBoxOtherOID, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtBoxOtherOID.TabIndex = 8;
            this.m_txtBoxOtherOID.Text = "[OIDAutre]";
            // 
            // m_txtBoxSigningOID
            // 
            this.m_extLinkField.SetLinkField(this.m_txtBoxSigningOID, "OIDSignature");
            this.m_txtBoxSigningOID.Location = new System.Drawing.Point(233, 119);
            this.m_txtBoxSigningOID.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtBoxSigningOID, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtBoxSigningOID.Name = "m_txtBoxSigningOID";
            this.m_txtBoxSigningOID.Size = new System.Drawing.Size(279, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtBoxSigningOID, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtBoxSigningOID, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtBoxSigningOID.TabIndex = 7;
            this.m_txtBoxSigningOID.Text = "[OIDSignature]";
            // 
            // m_txtBoxOIDName
            // 
            this.m_extLinkField.SetLinkField(this.m_txtBoxOIDName, "OIDNom");
            this.m_txtBoxOIDName.Location = new System.Drawing.Point(233, 85);
            this.m_txtBoxOIDName.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtBoxOIDName, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtBoxOIDName.Name = "m_txtBoxOIDName";
            this.m_txtBoxOIDName.Size = new System.Drawing.Size(279, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtBoxOIDName, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtBoxOIDName, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtBoxOIDName.TabIndex = 6;
            this.m_txtBoxOIDName.Text = "[OIDNom]";
            // 
            // m_txtBoxLibelle
            // 
            this.m_extLinkField.SetLinkField(this.m_txtBoxLibelle, "Libelle");
            this.m_txtBoxLibelle.Location = new System.Drawing.Point(233, 16);
            this.m_txtBoxLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtBoxLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtBoxLibelle.Name = "m_txtBoxLibelle";
            this.m_txtBoxLibelle.Size = new System.Drawing.Size(279, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtBoxLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtBoxLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtBoxLibelle.TabIndex = 1;
            this.m_txtBoxLibelle.Text = "[Libelle]";
            // 
            // labelTableName
            // 
            this.m_extLinkField.SetLinkField(this.labelTableName, "");
            this.labelTableName.Location = new System.Drawing.Point(15, 19);
            this.m_gestionnaireModeEdition.SetModeEdition(this.labelTableName, sc2i.win32.common.TypeModeEdition.Autonome);
            this.labelTableName.Name = "labelTableName";
            this.labelTableName.Size = new System.Drawing.Size(200, 23);
            this.m_extStyle.SetStyleBackColor(this.labelTableName, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.labelTableName, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.labelTableName.TabIndex = 0;
            this.labelTableName.Text = "Table name|50002";
            // 
            // labelEquipementType
            // 
            this.m_extLinkField.SetLinkField(this.labelEquipementType, "");
            this.labelEquipementType.Location = new System.Drawing.Point(15, 51);
            this.m_gestionnaireModeEdition.SetModeEdition(this.labelEquipementType, sc2i.win32.common.TypeModeEdition.Autonome);
            this.labelEquipementType.Name = "labelEquipementType";
            this.labelEquipementType.Size = new System.Drawing.Size(200, 23);
            this.m_extStyle.SetStyleBackColor(this.labelEquipementType, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.labelEquipementType, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.labelEquipementType.TabIndex = 2;
            this.labelEquipementType.Text = "Equipment type|120";
            // 
            // labelOtherOID
            // 
            this.m_extLinkField.SetLinkField(this.labelOtherOID, "");
            this.labelOtherOID.Location = new System.Drawing.Point(15, 156);
            this.m_gestionnaireModeEdition.SetModeEdition(this.labelOtherOID, sc2i.win32.common.TypeModeEdition.Autonome);
            this.labelOtherOID.Name = "labelOtherOID";
            this.labelOtherOID.Size = new System.Drawing.Size(200, 23);
            this.m_extStyle.SetStyleBackColor(this.labelOtherOID, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.labelOtherOID, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.labelOtherOID.TabIndex = 5;
            this.labelOtherOID.Text = "Other OID|50005";
            // 
            // labelSigningOID
            // 
            this.m_extLinkField.SetLinkField(this.labelSigningOID, "");
            this.labelSigningOID.Location = new System.Drawing.Point(15, 122);
            this.m_gestionnaireModeEdition.SetModeEdition(this.labelSigningOID, sc2i.win32.common.TypeModeEdition.Autonome);
            this.labelSigningOID.Name = "labelSigningOID";
            this.labelSigningOID.Size = new System.Drawing.Size(200, 23);
            this.m_extStyle.SetStyleBackColor(this.labelSigningOID, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.labelSigningOID, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.labelSigningOID.TabIndex = 4;
            this.labelSigningOID.Text = "Equipement type signing OID|50004";
            // 
            // labelNameOID
            // 
            this.m_extLinkField.SetLinkField(this.labelNameOID, "");
            this.labelNameOID.Location = new System.Drawing.Point(15, 86);
            this.m_gestionnaireModeEdition.SetModeEdition(this.labelNameOID, sc2i.win32.common.TypeModeEdition.Autonome);
            this.labelNameOID.Name = "labelNameOID";
            this.labelNameOID.Size = new System.Drawing.Size(200, 23);
            this.m_extStyle.SetStyleBackColor(this.labelNameOID, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.labelNameOID, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.labelNameOID.TabIndex = 3;
            this.labelNameOID.Text = "Element name OID (*)|50003";
            // 
            // CFormEditionTableSnmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 411);
            this.Controls.Add(this.m_panel1);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CFormEditionTableSnmp";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "CFormEditionTableSnmp";
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.m_panel1, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.m_panel1.ResumeLayout(false);
            this.m_panel1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private sc2i.win32.common.C2iPanelOmbre m_panel1;
        private sc2i.win32.common.C2iTextBox m_txtBoxLibelle;
        private System.Windows.Forms.Label labelTableName;
        private System.Windows.Forms.Label labelEquipementType;
        private System.Windows.Forms.Label labelNameOID;
        private System.Windows.Forms.Label labelSigningOID;
        private System.Windows.Forms.Label labelOtherOID;
        private sc2i.win32.common.C2iTextBox m_txtBoxOIDName;
        private sc2i.win32.common.C2iTextBox m_txtBoxSigningOID;
        private sc2i.win32.common.C2iTextBox m_txtBoxOtherOID;
        private System.Windows.Forms.Label labelExplanation;
        private sc2i.win32.common.CComboboxAutoFilled m_cmbTypeEquipement;
	}
}