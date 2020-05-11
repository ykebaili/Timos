namespace timos
{
	partial class CCtrlEditFiltersAnomaliesProjet
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
            this.m_chkPrePlannification = new System.Windows.Forms.CheckBox();
            this.m_chkPlannification = new System.Windows.Forms.CheckBox();
            this.m_chkContraintes = new System.Windows.Forms.CheckBox();
            this.m_chkBoucles = new System.Windows.Forms.CheckBox();
            this.m_chkInclurePrjsFils = new System.Windows.Forms.CheckBox();
            this.m_gbIgnorerAnos = new System.Windows.Forms.GroupBox();
            this.m_gbIgnorerAnos.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_chkPrePlannification
            // 
            this.m_chkPrePlannification.AutoSize = true;
            this.m_chkPrePlannification.Location = new System.Drawing.Point(6, 23);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkPrePlannification, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_chkPrePlannification.Name = "m_chkPrePlannification";
            this.m_chkPrePlannification.Size = new System.Drawing.Size(169, 17);
            this.m_chkPrePlannification.TabIndex = 0;
            this.m_chkPrePlannification.Text = "Incomplete Pre -planning|1268";
            this.m_chkPrePlannification.UseVisualStyleBackColor = true;
            this.m_chkPrePlannification.CheckedChanged += new System.EventHandler(this.m_chkPrePlannification_CheckedChanged);
            // 
            // m_chkPlannification
            // 
            this.m_chkPlannification.AutoSize = true;
            this.m_chkPlannification.Location = new System.Drawing.Point(6, 46);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkPlannification, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_chkPlannification.Name = "m_chkPlannification";
            this.m_chkPlannification.Size = new System.Drawing.Size(148, 17);
            this.m_chkPlannification.TabIndex = 1;
            this.m_chkPlannification.Text = "Incomplete Planning|1269";
            this.m_chkPlannification.UseVisualStyleBackColor = true;
            this.m_chkPlannification.CheckedChanged += new System.EventHandler(this.m_chkPlannification_CheckedChanged);
            // 
            // m_chkContraintes
            // 
            this.m_chkContraintes.AutoSize = true;
            this.m_chkContraintes.Location = new System.Drawing.Point(6, 69);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkContraintes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_chkContraintes.Name = "m_chkContraintes";
            this.m_chkContraintes.Size = new System.Drawing.Size(158, 17);
            this.m_chkContraintes.TabIndex = 2;
            this.m_chkContraintes.Text = "Date constraints errors|1270";
            this.m_chkContraintes.UseVisualStyleBackColor = true;
            this.m_chkContraintes.CheckedChanged += new System.EventHandler(this.m_chkContraintes_CheckedChanged);
            // 
            // m_chkBoucles
            // 
            this.m_chkBoucles.AutoSize = true;
            this.m_chkBoucles.Location = new System.Drawing.Point(6, 92);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkBoucles, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_chkBoucles.Name = "m_chkBoucles";
            this.m_chkBoucles.Size = new System.Drawing.Size(81, 17);
            this.m_chkBoucles.TabIndex = 3;
            this.m_chkBoucles.Text = "Loops|1271";
            this.m_chkBoucles.UseVisualStyleBackColor = true;
            this.m_chkBoucles.CheckedChanged += new System.EventHandler(this.m_chkBoucles_CheckedChanged);
            // 
            // m_chkInclurePrjsFils
            // 
            this.m_chkInclurePrjsFils.AutoSize = true;
            this.m_chkInclurePrjsFils.Location = new System.Drawing.Point(9, 124);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkInclurePrjsFils, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_chkInclurePrjsFils.Name = "m_chkInclurePrjsFils";
            this.m_chkInclurePrjsFils.Size = new System.Drawing.Size(152, 17);
            this.m_chkInclurePrjsFils.TabIndex = 1;
            this.m_chkInclurePrjsFils.Text = "Include child projects|1272";
            this.m_chkInclurePrjsFils.UseVisualStyleBackColor = true;
            this.m_chkInclurePrjsFils.CheckedChanged += new System.EventHandler(this.m_chkInclurePrjsFils_CheckedChanged);
            // 
            // m_gbIgnorerAnos
            // 
            this.m_gbIgnorerAnos.Controls.Add(this.m_chkPrePlannification);
            this.m_gbIgnorerAnos.Controls.Add(this.m_chkPlannification);
            this.m_gbIgnorerAnos.Controls.Add(this.m_chkContraintes);
            this.m_gbIgnorerAnos.Controls.Add(this.m_chkBoucles);
            this.m_gbIgnorerAnos.Location = new System.Drawing.Point(3, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_gbIgnorerAnos, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_gbIgnorerAnos.Name = "m_gbIgnorerAnos";
            this.m_gbIgnorerAnos.Size = new System.Drawing.Size(200, 115);
            this.m_gbIgnorerAnos.TabIndex = 0;
            this.m_gbIgnorerAnos.TabStop = false;
            this.m_gbIgnorerAnos.Text = "Ignore the following anomalies |1267";
            // 
            // CCtrlEditFiltersAnomaliesProjet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_gbIgnorerAnos);
            this.Controls.Add(this.m_chkInclurePrjsFils);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CCtrlEditFiltersAnomaliesProjet";
            this.Size = new System.Drawing.Size(206, 148);
            this.m_gbIgnorerAnos.ResumeLayout(false);
            this.m_gbIgnorerAnos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private System.Windows.Forms.CheckBox m_chkPrePlannification;
		private System.Windows.Forms.CheckBox m_chkPlannification;
		private System.Windows.Forms.CheckBox m_chkContraintes;
		private System.Windows.Forms.CheckBox m_chkBoucles;
		private System.Windows.Forms.CheckBox m_chkInclurePrjsFils;
		private System.Windows.Forms.GroupBox m_gbIgnorerAnos;
	}
}
