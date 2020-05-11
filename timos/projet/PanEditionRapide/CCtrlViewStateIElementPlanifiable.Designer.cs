namespace timos
{
	partial class CCtrlViewStateIElementPlanifiable
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
            this.m_panImg = new System.Windows.Forms.Panel();
            this.m_pbox = new System.Windows.Forms.PictureBox();
            this.m_panCombo = new System.Windows.Forms.Panel();
            this.m_lblEtat = new System.Windows.Forms.Label();
            this.m_panImg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_pbox)).BeginInit();
            this.m_panCombo.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panImg
            // 
            this.m_panImg.Controls.Add(this.m_pbox);
            this.m_panImg.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_panImg.Location = new System.Drawing.Point(117, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panImg, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panImg.Name = "m_panImg";
            this.m_panImg.Size = new System.Drawing.Size(28, 23);
            this.m_panImg.TabIndex = 1;
            // 
            // m_pbox
            // 
            this.m_pbox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_pbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_pbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_pbox.InitialImage = null;
            this.m_pbox.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pbox, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_pbox.Name = "m_pbox";
            this.m_pbox.Size = new System.Drawing.Size(28, 23);
            this.m_pbox.TabIndex = 0;
            this.m_pbox.TabStop = false;
            // 
            // m_panCombo
            // 
            this.m_panCombo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panCombo.Controls.Add(this.m_lblEtat);
            this.m_panCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panCombo.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panCombo, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panCombo.Name = "m_panCombo";
            this.m_panCombo.Size = new System.Drawing.Size(117, 23);
            this.m_panCombo.TabIndex = 2;
            // 
            // m_lblEtat
            // 
            this.m_lblEtat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lblEtat.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblEtat, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblEtat.Name = "m_lblEtat";
            this.m_lblEtat.Size = new System.Drawing.Size(115, 21);
            this.m_lblEtat.TabIndex = 1;
            this.m_lblEtat.Text = "State|30105";
            this.m_lblEtat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CCtrlViewStateIElementPlanifiable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_panCombo);
            this.Controls.Add(this.m_panImg);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CCtrlViewStateIElementPlanifiable";
            this.Size = new System.Drawing.Size(145, 23);
            this.m_panImg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_pbox)).EndInit();
            this.m_panCombo.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private System.Windows.Forms.Panel m_panImg;
		private System.Windows.Forms.PictureBox m_pbox;
		private System.Windows.Forms.Panel m_panCombo;
		private System.Windows.Forms.Label m_lblEtat;
	}
}
