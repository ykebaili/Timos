namespace timos.coordonnees
{
	partial class CControlFindIObjetACoordonnees
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
			this.m_btnSearche = new System.Windows.Forms.Button();
			this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
			this.m_lblCritere = new System.Windows.Forms.Label();
			this.m_chklstCriteres = new System.Windows.Forms.CheckedListBox();
			this.m_btnOptions = new System.Windows.Forms.Button();
			this.m_panelSearche = new System.Windows.Forms.Panel();
			this.m_panelOptions = new System.Windows.Forms.Panel();
			this.m_chkAfficherResultat = new System.Windows.Forms.CheckBox();
			this.m_chkNavigAutoToOnetResult = new System.Windows.Forms.CheckBox();
			this.m_tooltip = new System.Windows.Forms.ToolTip(this.components);
			this.m_timerVerification = new System.Windows.Forms.Timer(this.components);
			this.m_panelSearche.SuspendLayout();
			this.m_panelOptions.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_txtBoxCoordonnee
			// 
			this.m_txtBoxCoordonnee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtBoxCoordonnee.Location = new System.Drawing.Point(3, 3);
			this.m_txtBoxCoordonnee.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtBoxCoordonnee, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_txtBoxCoordonnee.Name = "m_txtBoxCoordonnee";
			this.m_txtBoxCoordonnee.Size = new System.Drawing.Size(248, 20);
			this.m_txtBoxCoordonnee.TabIndex = 0;
			this.m_txtBoxCoordonnee.TextChanged += new System.EventHandler(this.m_txtBoxCoordonnee_TextChanged);
			// 
			// m_btnSearche
			// 
			this.m_btnSearche.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btnSearche.Location = new System.Drawing.Point(257, 3);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnSearche, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_btnSearche.Name = "m_btnSearche";
			this.m_btnSearche.Size = new System.Drawing.Size(70, 22);
			this.m_btnSearche.TabIndex = 1;
			this.m_btnSearche.Text = "Search|71";
			this.m_btnSearche.UseVisualStyleBackColor = true;
			this.m_btnSearche.Click += new System.EventHandler(this.m_btnSearch_Click);
			// 
			// m_lblCritere
			// 
			this.m_lblCritere.Location = new System.Drawing.Point(3, 42);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblCritere, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_lblCritere.Name = "m_lblCritere";
			this.m_lblCritere.Size = new System.Drawing.Size(236, 15);
			this.m_lblCritere.TabIndex = 3;
			this.m_lblCritere.Text = "Find in|831";
			// 
			// m_chklstCriteres
			// 
			this.m_chklstCriteres.FormattingEnabled = true;
			this.m_chklstCriteres.Items.AddRange(new object[] {
            "Organizational Entities",
            "Sites",
            "Stocks",
            "Equipments"});
			this.m_chklstCriteres.Location = new System.Drawing.Point(6, 57);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_chklstCriteres, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_chklstCriteres.Name = "m_chklstCriteres";
			this.m_chklstCriteres.Size = new System.Drawing.Size(233, 64);
			this.m_chklstCriteres.TabIndex = 4;
			// 
			// m_btnOptions
			// 
			this.m_btnOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btnOptions.Location = new System.Drawing.Point(333, 3);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnOptions, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_btnOptions.Name = "m_btnOptions";
			this.m_btnOptions.Size = new System.Drawing.Size(33, 22);
			this.m_btnOptions.TabIndex = 1;
			this.m_btnOptions.Text = "\\/";
			this.m_btnOptions.UseVisualStyleBackColor = true;
			this.m_btnOptions.Click += new System.EventHandler(this.m_btnOptions_Click);
			// 
			// m_panelSearche
			// 
			this.m_panelSearche.Controls.Add(this.m_txtBoxCoordonnee);
			this.m_panelSearche.Controls.Add(this.m_btnOptions);
			this.m_panelSearche.Controls.Add(this.m_btnSearche);
			this.m_panelSearche.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_panelSearche.Location = new System.Drawing.Point(0, 0);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelSearche, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_panelSearche.Name = "m_panelSearche";
			this.m_panelSearche.Size = new System.Drawing.Size(369, 26);
			this.m_panelSearche.TabIndex = 5;
			// 
			// m_panelOptions
			// 
			this.m_panelOptions.Controls.Add(this.m_lblCritere);
			this.m_panelOptions.Controls.Add(this.m_chklstCriteres);
			this.m_panelOptions.Controls.Add(this.m_chkAfficherResultat);
			this.m_panelOptions.Controls.Add(this.m_chkNavigAutoToOnetResult);
			this.m_panelOptions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_panelOptions.Location = new System.Drawing.Point(0, 26);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelOptions, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_panelOptions.Name = "m_panelOptions";
			this.m_panelOptions.Size = new System.Drawing.Size(369, 125);
			this.m_panelOptions.TabIndex = 6;
			// 
			// m_chkAfficherResultat
			// 
			this.m_chkAfficherResultat.AutoSize = true;
			this.m_chkAfficherResultat.Checked = true;
			this.m_chkAfficherResultat.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_chkAfficherResultat.Location = new System.Drawing.Point(6, 3);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkAfficherResultat, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_chkAfficherResultat.Name = "m_chkAfficherResultat";
			this.m_chkAfficherResultat.Size = new System.Drawing.Size(119, 17);
			this.m_chkAfficherResultat.TabIndex = 5;
			this.m_chkAfficherResultat.Text = "Display results|1166";
			this.m_chkAfficherResultat.UseVisualStyleBackColor = true;
			this.m_chkAfficherResultat.CheckedChanged += new System.EventHandler(this.m_chkAfficherResultat_CheckedChanged);
			// 
			// m_chkNavigAutoToOnetResult
			// 
			this.m_chkNavigAutoToOnetResult.AutoSize = true;
			this.m_chkNavigAutoToOnetResult.Checked = true;
			this.m_chkNavigAutoToOnetResult.CheckState = System.Windows.Forms.CheckState.Checked;
			this.m_chkNavigAutoToOnetResult.Location = new System.Drawing.Point(6, 21);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkNavigAutoToOnetResult, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_chkNavigAutoToOnetResult.Name = "m_chkNavigAutoToOnetResult";
			this.m_chkNavigAutoToOnetResult.Size = new System.Drawing.Size(199, 17);
			this.m_chkNavigAutoToOnetResult.TabIndex = 5;
			this.m_chkNavigAutoToOnetResult.Text = "Automaticaly navigate for 1 result|830";
			this.m_chkNavigAutoToOnetResult.UseVisualStyleBackColor = true;
			this.m_chkNavigAutoToOnetResult.CheckedChanged += new System.EventHandler(this.m_chkNavigAutoToOnetResult_CheckedChanged);
			// 
			// CControlFindIObjetACoordonnees
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.m_panelOptions);
			this.Controls.Add(this.m_panelSearche);
			this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
			this.Name = "CControlFindIObjetACoordonnees";
			this.Size = new System.Drawing.Size(369, 151);
			this.Load += new System.EventHandler(this.CControlFindIObjetACoordonnees_Load);
			this.m_panelSearche.ResumeLayout(false);
			this.m_panelSearche.PerformLayout();
			this.m_panelOptions.ResumeLayout(false);
			this.m_panelOptions.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private sc2i.win32.common.C2iTextBox m_txtBoxCoordonnee;
		private System.Windows.Forms.Button m_btnSearche;
		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private System.Windows.Forms.ToolTip m_tooltip;
		private System.Windows.Forms.Timer m_timerVerification;
		private System.Windows.Forms.Label m_lblCritere;
		private System.Windows.Forms.CheckedListBox m_chklstCriteres;
		private System.Windows.Forms.Button m_btnOptions;
		private System.Windows.Forms.Panel m_panelSearche;
		private System.Windows.Forms.Panel m_panelOptions;
        private System.Windows.Forms.CheckBox m_chkNavigAutoToOnetResult;
        private System.Windows.Forms.CheckBox m_chkAfficherResultat;
	}
}
