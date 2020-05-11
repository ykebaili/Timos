namespace timos.coordonnees
{
	partial class CFormFloatResultIObjetACoordonnees
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
            this.m_panOmbre = new sc2i.win32.common.C2iPanelOmbre();
            this.m_panConteneur = new System.Windows.Forms.Panel();
            this.lv_results = new System.Windows.Forms.ListView();
            this.col_typeResults = new System.Windows.Forms.ColumnHeader();
            this.col_descrip = new System.Windows.Forms.ColumnHeader();
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.m_panOmbre.SuspendLayout();
            this.m_panConteneur.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panOmbre
            // 
            this.m_panOmbre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panOmbre.Controls.Add(this.m_panConteneur);
            this.m_panOmbre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panOmbre.ForeColor = System.Drawing.Color.Black;
            this.m_panOmbre.Location = new System.Drawing.Point(0, 0);
            this.m_panOmbre.LockEdition = false;
            this.m_panOmbre.Name = "m_panOmbre";
            this.m_panOmbre.Size = new System.Drawing.Size(293, 155);
            this.m_extStyle.SetStyleBackColor(this.m_panOmbre, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panOmbre, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panOmbre.TabIndex = 2;
            // 
            // m_panConteneur
            // 
            this.m_panConteneur.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panConteneur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panConteneur.Controls.Add(this.lv_results);
            this.m_panConteneur.Location = new System.Drawing.Point(0, 0);
            this.m_panConteneur.Name = "m_panConteneur";
            this.m_panConteneur.Size = new System.Drawing.Size(277, 139);
            this.m_extStyle.SetStyleBackColor(this.m_panConteneur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panConteneur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panConteneur.TabIndex = 3;
            // 
            // lv_results
            // 
            this.lv_results.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_typeResults,
            this.col_descrip});
            this.lv_results.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_results.FullRowSelect = true;
            this.lv_results.Location = new System.Drawing.Point(0, 0);
            this.lv_results.Name = "lv_results";
            this.lv_results.Size = new System.Drawing.Size(275, 137);
            this.m_extStyle.SetStyleBackColor(this.lv_results, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.lv_results, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lv_results.TabIndex = 2;
            this.lv_results.UseCompatibleStateImageBehavior = false;
            this.lv_results.View = System.Windows.Forms.View.Details;
            this.lv_results.DoubleClick += new System.EventHandler(this.lv_results_DoubleClick);
            // 
            // col_typeResults
            // 
            this.col_typeResults.Text = "Result Type|832";
            this.col_typeResults.Width = 100;
            // 
            // col_descrip
            // 
            this.col_descrip.Text = "Description|833";
            this.col_descrip.Width = 170;
            // 
            // CFormFloatResultIObjetACoordonnees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(293, 155);
            this.Controls.Add(this.m_panOmbre);
            this.Name = "CFormFloatResultIObjetACoordonnees";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "CFormFloatContactsPhase";
            this.Load += new System.EventHandler(this.CFormFloatResultIObjetACoordonnees_Load);
            this.m_panOmbre.ResumeLayout(false);
            this.m_panOmbre.PerformLayout();
            this.m_panConteneur.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private sc2i.win32.common.C2iPanelOmbre m_panOmbre;
		private System.Windows.Forms.Panel m_panConteneur;
		private sc2i.win32.common.CExtStyle m_extStyle;
		private System.Windows.Forms.ListView lv_results;
		private System.Windows.Forms.ColumnHeader col_typeResults;
		private System.Windows.Forms.ColumnHeader col_descrip;
	}
}