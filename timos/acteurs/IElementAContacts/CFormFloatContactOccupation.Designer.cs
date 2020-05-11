namespace timos.acteurs
{
	partial class CFormFloatContactOccupation
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
            this.m_controlPlanning = new timos.win32.composants.CControlePlanning();
            this.m_panOmbre.SuspendLayout();
            this.m_panConteneur.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panOmbre
            // 
            this.m_panOmbre.Controls.Add(this.m_panConteneur);
            this.m_panOmbre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panOmbre.Location = new System.Drawing.Point(0, 0);
            this.m_panOmbre.LockEdition = false;
            this.m_panOmbre.Name = "m_panOmbre";
            this.m_panOmbre.Size = new System.Drawing.Size(481, 84);
            this.m_panOmbre.TabIndex = 2;
            // 
            // m_panConteneur
            // 
            this.m_panConteneur.Controls.Add(this.m_controlPlanning);
            this.m_panConteneur.Location = new System.Drawing.Point(0, 0);
            this.m_panConteneur.Name = "m_panConteneur";
            this.m_panConteneur.Size = new System.Drawing.Size(465, 65);
            this.m_panConteneur.TabIndex = 3;
            // 
            // m_controlPlanning
            // 
            this.m_controlPlanning.AutoTooltip = false;
            this.m_controlPlanning.BaseAffichee = null;
            this.m_controlPlanning.DateDebut = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.m_controlPlanning.DateFin = new System.DateTime(1900, 1, 2, 0, 0, 0, 0);
            this.m_controlPlanning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_controlPlanning.ElementAInterventionSelectionne = null;
            this.m_controlPlanning.EnableAffichageDatesEnBas = true;
            this.m_controlPlanning.Location = new System.Drawing.Point(0, 0);
            this.m_controlPlanning.LockEdition = true;
            this.m_controlPlanning.MasquerEntetesLignes = false;
            this.m_controlPlanning.Name = "m_controlPlanning";
            this.m_controlPlanning.Size = new System.Drawing.Size(465, 65);
            this.m_controlPlanning.TabIndex = 0;
            this.m_controlPlanning.TypeRessourcesAAffecter = typeof(timos.acteurs.CActeur);
            // 
            // CFormFloatContactOccupation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(481, 84);
            this.Controls.Add(this.m_panOmbre);
            this.Name = "CFormFloatContactOccupation";
            this.Text = "CFormFloatOccupationActeur";
            this.Load += new System.EventHandler(this.CFormFloatContactsPhase_Load);
            this.m_panOmbre.ResumeLayout(false);
            this.m_panOmbre.PerformLayout();
            this.m_panConteneur.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private sc2i.win32.common.C2iPanelOmbre m_panOmbre;
		private System.Windows.Forms.Panel m_panConteneur;
		private timos.win32.composants.CControlePlanning m_controlPlanning;
	}
}