namespace timos.Parametrage.ConsultationHierarchique
{
	partial class CPanelEditFolderConsultationFolder
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
            this.m_selectColor = new sc2i.win32.common.C2iColorSelect();
            this.label3 = new System.Windows.Forms.Label();
            this.m_imageSelect = new sc2i.win32.common.C2iSelectImage();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Label|50";
            // 
            // m_txtLibelle
            // 
            this.m_txtLibelle.Location = new System.Drawing.Point(117, 6);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(303, 20);
            this.m_txtLibelle.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Color|20096";
            // 
            // m_selectColor
            // 
            this.m_selectColor.BackColor = System.Drawing.Color.White;
            this.m_selectColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_selectColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_selectColor.Location = new System.Drawing.Point(117, 31);
            this.m_selectColor.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_selectColor, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_selectColor.Name = "m_selectColor";
            this.m_selectColor.SelectedColor = System.Drawing.Color.White;
            this.m_selectColor.Size = new System.Drawing.Size(100, 23);
            this.m_selectColor.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(248, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Image|20097";
            // 
            // m_imageSelect
            // 
            this.m_imageSelect.BackColor = System.Drawing.Color.White;
            this.m_imageSelect.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_imageSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_imageSelect.Location = new System.Drawing.Point(328, 27);
            this.m_imageSelect.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_imageSelect, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_imageSelect.Name = "m_imageSelect";
            this.m_imageSelect.Size = new System.Drawing.Size(35, 30);
            this.m_imageSelect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_imageSelect.TabIndex = 9;
            this.m_imageSelect.TabStop = false;
            // 
            // CPanelEditFolderConsultationFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_imageSelect);
            this.Controls.Add(this.m_selectColor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_txtLibelle);
            this.Controls.Add(this.label1);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CPanelEditFolderConsultationFolder";
            this.Size = new System.Drawing.Size(438, 66);
            this.Load += new System.EventHandler(this.CPanelEditFolderConsultationFolder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_imageSelect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
        private System.Windows.Forms.Label label2;
        private sc2i.win32.common.C2iColorSelect m_selectColor;
        private System.Windows.Forms.Label label3;
        private sc2i.win32.common.C2iSelectImage m_imageSelect;
	}
}
