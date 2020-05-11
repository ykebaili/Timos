namespace timos
{
	partial class CPanIEditeurWndElementDeProjet
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
			this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
			this.m_panTitre = new System.Windows.Forms.Panel();
			this.m_lblTitre = new System.Windows.Forms.Label();
			this.m_editeurIntervention = new timos.CPanEditWndIntervention();
			this.m_editeurProjet = new timos.CPanEditWndProjetBrique();
			this.m_editeurLienDeProjet = new timos.CPanEditWndLienDeProjet();
			this.m_tooltip = new System.Windows.Forms.ToolTip(this.components);
			this.m_panTitre.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_panTitre
			// 
			this.m_panTitre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_panTitre.Controls.Add(this.m_lblTitre);
			this.m_panTitre.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_panTitre.Location = new System.Drawing.Point(0, 0);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panTitre, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_panTitre.Name = "m_panTitre";
			this.m_panTitre.Size = new System.Drawing.Size(649, 41);
			this.m_panTitre.TabIndex = 0;
			// 
			// m_lblTitre
			// 
			this.m_lblTitre.AutoSize = true;
			this.m_lblTitre.Location = new System.Drawing.Point(3, 17);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblTitre, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_lblTitre.Name = "m_lblTitre";
			this.m_lblTitre.Size = new System.Drawing.Size(45, 13);
			this.m_lblTitre.TabIndex = 0;
			this.m_lblTitre.Text = "TITLE :|30266";
			// 
			// m_editeurIntervention
			// 
			this.m_editeurIntervention.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_editeurIntervention.Location = new System.Drawing.Point(214, 47);
			this.m_editeurIntervention.LockEdition = true;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_editeurIntervention, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_editeurIntervention.Name = "m_editeurIntervention";
			this.m_editeurIntervention.Size = new System.Drawing.Size(225, 275);
			this.m_editeurIntervention.TabIndex = 4;
			this.m_editeurIntervention.Visible = false;
			this.m_editeurIntervention.ProprieteModifiee += new System.EventHandler(this.m_editeurProjet_ProprieteModifiee);
			this.m_editeurIntervention.OnClickProprietes += new System.EventHandler(this.m_editeur_OnClickPropriete);
			// 
			// m_editeurProjet
			// 
			this.m_editeurProjet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_editeurProjet.Location = new System.Drawing.Point(3, 47);
			this.m_editeurProjet.LockEdition = true;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_editeurProjet, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_editeurProjet.Name = "m_editeurProjet";
			this.m_editeurProjet.Size = new System.Drawing.Size(205, 275);
			this.m_editeurProjet.TabIndex = 3;
			this.m_editeurProjet.Visible = false;
			this.m_editeurProjet.ProprieteModifiee += new System.EventHandler(this.m_editeurProjet_ProprieteModifiee);
			this.m_editeurProjet.OnClickProprietes += new System.EventHandler(this.m_editeur_OnClickPropriete);
			// 
			// m_editeurLienDeProjet
			// 
			this.m_editeurLienDeProjet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_editeurLienDeProjet.Location = new System.Drawing.Point(445, 47);
			this.m_editeurLienDeProjet.LockEdition = true;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_editeurLienDeProjet, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_editeurLienDeProjet.Name = "m_editeurLienDeProjet";
			this.m_editeurLienDeProjet.Size = new System.Drawing.Size(192, 275);
			this.m_editeurLienDeProjet.TabIndex = 2;
			this.m_editeurLienDeProjet.Visible = false;
			this.m_editeurLienDeProjet.ProprieteModifiee += new System.EventHandler(this.m_editeurProjet_ProprieteModifiee);
			// 
			// CPanIEditeurWndElementDeProjet
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.m_editeurIntervention);
			this.Controls.Add(this.m_editeurProjet);
			this.Controls.Add(this.m_editeurLienDeProjet);
			this.Controls.Add(this.m_panTitre);
			this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
			this.Name = "CPanIEditeurWndElementDeProjet";
			this.Size = new System.Drawing.Size(649, 342);
			this.m_panTitre.ResumeLayout(false);
			this.m_panTitre.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private System.Windows.Forms.ToolTip m_tooltip;
		private System.Windows.Forms.Panel m_panTitre;
		private CPanEditWndLienDeProjet m_editeurLienDeProjet;
		private CPanEditWndProjetBrique m_editeurProjet;
		private System.Windows.Forms.Label m_lblTitre;
		private CPanEditWndIntervention m_editeurIntervention;
	}
}
