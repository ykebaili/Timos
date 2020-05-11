namespace timos
{
	partial class CCtrlViewAnomaliesAIElementDeProjet
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
			this.m_lvAnos = new System.Windows.Forms.ListView();
			this.m_colIco = new System.Windows.Forms.ColumnHeader();
			this.m_colErr = new System.Windows.Forms.ColumnHeader();
			this.m_chkIgnorer = new System.Windows.Forms.CheckBox();
			this.m_btnIgnorer = new System.Windows.Forms.Button();
			this.m_panIgnorer = new System.Windows.Forms.Panel();
			this.m_panIgnorer.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_lvAnos
			// 
			this.m_lvAnos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_colIco,
            this.m_colErr});
			this.m_lvAnos.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lvAnos.FullRowSelect = true;
			this.m_lvAnos.Location = new System.Drawing.Point(0, 0);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_lvAnos, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_lvAnos.Name = "m_lvAnos";
			this.m_lvAnos.Size = new System.Drawing.Size(313, 115);
			this.m_lvAnos.TabIndex = 0;
			this.m_lvAnos.UseCompatibleStateImageBehavior = false;
			this.m_lvAnos.View = System.Windows.Forms.View.Details;
			this.m_lvAnos.SelectedIndexChanged += new System.EventHandler(this.m_lvAnos_SelectedIndexChanged);
			// 
			// m_colIco
			// 
			this.m_colIco.Text = "";
			this.m_colIco.Width = 25;
			// 
			// m_colErr
			// 
			this.m_colErr.Text = "Error|30";
			this.m_colErr.Width = 250;
			// 
			// m_chkIgnorer
			// 
			this.m_chkIgnorer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_chkIgnorer.AutoSize = true;
			this.m_chkIgnorer.Location = new System.Drawing.Point(3, 8);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkIgnorer, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_chkIgnorer.Name = "m_chkIgnorer";
			this.m_chkIgnorer.Size = new System.Drawing.Size(146, 17);
			this.m_chkIgnorer.TabIndex = 1;
			this.m_chkIgnorer.Text = "Show ignored errors|1265";
			this.m_chkIgnorer.UseVisualStyleBackColor = true;
			this.m_chkIgnorer.CheckedChanged += new System.EventHandler(this.m_chkIgnorer_CheckedChanged);
			// 
			// m_btnIgnorer
			// 
			this.m_btnIgnorer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btnIgnorer.Location = new System.Drawing.Point(235, 4);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnIgnorer, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_btnIgnorer.Name = "m_btnIgnorer";
			this.m_btnIgnorer.Size = new System.Drawing.Size(75, 23);
			this.m_btnIgnorer.TabIndex = 2;
			this.m_btnIgnorer.Text = "Ignore|31";
			this.m_btnIgnorer.UseVisualStyleBackColor = true;
			this.m_btnIgnorer.Visible = false;
			this.m_btnIgnorer.Click += new System.EventHandler(this.m_btnIgnorer_Click);
			// 
			// m_panIgnorer
			// 
			this.m_panIgnorer.Controls.Add(this.m_btnIgnorer);
			this.m_panIgnorer.Controls.Add(this.m_chkIgnorer);
			this.m_panIgnorer.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.m_panIgnorer.Location = new System.Drawing.Point(0, 115);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panIgnorer, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_panIgnorer.Name = "m_panIgnorer";
			this.m_panIgnorer.Size = new System.Drawing.Size(313, 30);
			this.m_panIgnorer.TabIndex = 3;
			// 
			// CCtrlViewAnomaliesAIElementDeProjet
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.m_lvAnos);
			this.Controls.Add(this.m_panIgnorer);
			this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
			this.Name = "CCtrlViewAnomaliesAIElementDeProjet";
			this.Size = new System.Drawing.Size(313, 145);
			this.m_panIgnorer.ResumeLayout(false);
			this.m_panIgnorer.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private System.Windows.Forms.ListView m_lvAnos;
		private System.Windows.Forms.ColumnHeader m_colIco;
		private System.Windows.Forms.ColumnHeader m_colErr;
		private System.Windows.Forms.CheckBox m_chkIgnorer;
		private System.Windows.Forms.Button m_btnIgnorer;
		private System.Windows.Forms.Panel m_panIgnorer;
	}
}
