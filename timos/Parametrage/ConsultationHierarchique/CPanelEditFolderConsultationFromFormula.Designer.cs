namespace timos.Parametrage.ConsultationHierarchique
{
    partial class CPanelEditFolderConsultationFromFormula
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
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtFormuleLibelle = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_selectColor = new sc2i.win32.common.C2iColorSelect();
            this.m_imageSelect = new sc2i.win32.common.C2iSelectImage();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtFormuleElements = new sc2i.win32.expression.CTextBoxZoomFormule();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Label|50";
            // 
            // m_txtLibelle
            // 
            this.m_txtLibelle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtLibelle.Location = new System.Drawing.Point(125, 3);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(375, 20);
            this.m_txtLibelle.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 33);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Element text|20092";
            // 
            // m_txtFormuleLibelle
            // 
            this.m_txtFormuleLibelle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormuleLibelle.Formule = null;
            this.m_txtFormuleLibelle.Location = new System.Drawing.Point(125, 29);
            this.m_txtFormuleLibelle.LockEdition = false;
            this.m_txtFormuleLibelle.LockZoneTexte = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtFormuleLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtFormuleLibelle.Name = "m_txtFormuleLibelle";
            this.m_txtFormuleLibelle.Size = new System.Drawing.Size(375, 42);
            this.m_txtFormuleLibelle.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 112);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Elements formula|20098";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 77);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Color|20096";
            // 
            // m_selectColor
            // 
            this.m_selectColor.BackColor = System.Drawing.Color.White;
            this.m_selectColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_selectColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_selectColor.Location = new System.Drawing.Point(125, 76);
            this.m_selectColor.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_selectColor, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_selectColor.Name = "m_selectColor";
            this.m_selectColor.SelectedColor = System.Drawing.Color.White;
            this.m_selectColor.Size = new System.Drawing.Size(100, 23);
            this.m_selectColor.TabIndex = 7;
            // 
            // m_imageSelect
            // 
            this.m_imageSelect.BackColor = System.Drawing.Color.White;
            this.m_imageSelect.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_imageSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_imageSelect.Location = new System.Drawing.Point(325, 72);
            this.m_imageSelect.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_imageSelect, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_imageSelect.Name = "m_imageSelect";
            this.m_imageSelect.Size = new System.Drawing.Size(35, 30);
            this.m_imageSelect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_imageSelect.TabIndex = 11;
            this.m_imageSelect.TabStop = false;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(245, 77);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 22);
            this.label5.TabIndex = 10;
            this.label5.Text = "Image|20097";
            // 
            // m_txtFormuleElements
            // 
            this.m_txtFormuleElements.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormuleElements.Formule = null;
            this.m_txtFormuleElements.Location = new System.Drawing.Point(125, 108);
            this.m_txtFormuleElements.LockEdition = false;
            this.m_txtFormuleElements.LockZoneTexte = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtFormuleElements, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtFormuleElements.Name = "m_txtFormuleElements";
            this.m_txtFormuleElements.Size = new System.Drawing.Size(375, 42);
            this.m_txtFormuleElements.TabIndex = 12;
            this.m_txtFormuleElements.Validated += new System.EventHandler(this.m_txtFormuleElements_Validated);
            // 
            // CPanelEditFolderConsultationFromFormula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_txtFormuleElements);
            this.Controls.Add(this.m_imageSelect);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.m_selectColor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_txtFormuleLibelle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_txtLibelle);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CPanelEditFolderConsultationFromFormula";
            this.Size = new System.Drawing.Size(512, 167);
            this.Load += new System.EventHandler(this.CPanelEditFolderConsultationFromFormula_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.m_imageSelect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
        private sc2i.win32.common.C2iTextBox m_txtLibelle;
        private System.Windows.Forms.Label label2;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleLibelle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private sc2i.win32.common.C2iColorSelect m_selectColor;
        private sc2i.win32.common.C2iSelectImage m_imageSelect;
        private System.Windows.Forms.Label label5;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleElements;
	}
}
