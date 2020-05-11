namespace timos.coordonnees
{
	partial class CControlEditeCoordonnee
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
            this.m_txtBoxCoordonnee = new sc2i.win32.common.C2iTextBox();
            this.m_btnAide = new System.Windows.Forms.Button();
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_panelConteneur = new System.Windows.Forms.Panel();
            this.m_txtDebut = new sc2i.win32.common.C2iTextBox();
            this.m_tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.m_timerVerification = new System.Windows.Forms.Timer(this.components);
            this.m_panelConteneur.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_txtBoxCoordonnee
            // 
            this.m_txtBoxCoordonnee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtBoxCoordonnee.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_txtBoxCoordonnee.Location = new System.Drawing.Point(284, 0);
            this.m_txtBoxCoordonnee.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtBoxCoordonnee, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtBoxCoordonnee.Name = "m_txtBoxCoordonnee";
            this.m_txtBoxCoordonnee.Size = new System.Drawing.Size(84, 20);
            this.m_txtBoxCoordonnee.TabIndex = 0;
            this.m_txtBoxCoordonnee.TextChanged += new System.EventHandler(this.m_txtBoxCoordonnee_TextChanged);
            // 
            // m_btnAide
            // 
            this.m_btnAide.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnAide.Location = new System.Drawing.Point(368, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAide, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnAide.Name = "m_btnAide";
            this.m_btnAide.Size = new System.Drawing.Size(27, 20);
            this.m_btnAide.TabIndex = 1;
            this.m_btnAide.Text = "...";
            this.m_btnAide.UseVisualStyleBackColor = true;
            this.m_btnAide.Click += new System.EventHandler(this.m_btnAide_Click);
            // 
            // m_panelConteneur
            // 
            this.m_panelConteneur.Controls.Add(this.m_txtDebut);
            this.m_panelConteneur.Controls.Add(this.m_txtBoxCoordonnee);
            this.m_panelConteneur.Controls.Add(this.m_btnAide);
            this.m_panelConteneur.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelConteneur.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelConteneur, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelConteneur.Name = "m_panelConteneur";
            this.m_panelConteneur.Size = new System.Drawing.Size(395, 20);
            this.m_panelConteneur.TabIndex = 3;
            // 
            // m_txtDebut
            // 
            this.m_txtDebut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtDebut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtDebut.Location = new System.Drawing.Point(0, 0);
            this.m_txtDebut.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtDebut, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtDebut.Name = "m_txtDebut";
            this.m_txtDebut.Size = new System.Drawing.Size(284, 20);
            this.m_txtDebut.TabIndex = 2;
            this.m_txtDebut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // m_tooltip
            // 
            this.m_tooltip.Popup += new System.Windows.Forms.PopupEventHandler(this.m_tooltip_Popup);
            // 
            // m_timerVerification
            // 
            this.m_timerVerification.Tick += new System.EventHandler(this.m_timerVerification_Tick);
            // 
            // CControlEditeCoordonnee
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_panelConteneur);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControlEditeCoordonnee";
            this.Size = new System.Drawing.Size(395, 25);
            this.m_panelConteneur.ResumeLayout(false);
            this.m_panelConteneur.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private sc2i.win32.common.C2iTextBox m_txtBoxCoordonnee;
		private System.Windows.Forms.Button m_btnAide;
		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private System.Windows.Forms.ToolTip m_tooltip;
        private System.Windows.Forms.Timer m_timerVerification;
		private System.Windows.Forms.Panel m_panelConteneur;
        private sc2i.win32.common.C2iTextBox m_txtDebut;
	}
}
