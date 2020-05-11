namespace spv.win32
{
    partial class CExtendeurFormListeTypeAccesAlarmes
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
            this.m_gridSiteSPV = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // m_gridSiteSPV
            // 
            this.m_gridSiteSPV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_gridSiteSPV, "");
            this.m_gridSiteSPV.Location = new System.Drawing.Point(3, 3);
            this.m_extModeEdition.SetModeEdition(this.m_gridSiteSPV, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_gridSiteSPV.Name = "m_gridSiteSPV";
            this.m_gridSiteSPV.Size = new System.Drawing.Size(397, 256);
            this.m_extStyle.SetStyleBackColor(this.m_gridSiteSPV, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_gridSiteSPV, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_gridSiteSPV.TabIndex = 1;
            // 
            // CExtendeurFormSite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_gridSiteSPV);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CExtendeurFormSite";
            this.Size = new System.Drawing.Size(623, 467);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.PropertyGrid m_gridSiteSPV;
	}
}
