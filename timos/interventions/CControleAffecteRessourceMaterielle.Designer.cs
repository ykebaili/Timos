namespace timos.interventions
{
	partial class CControleAffecteRessourceMaterielle
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
            this.m_lblContrainte = new System.Windows.Forms.Label();
            this.m_txtSelectRessourceMaterielle = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_lnkAffectationRapide = new System.Windows.Forms.LinkLabel();
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.SuspendLayout();
            // 
            // m_lblContrainte
            // 
            this.m_lblContrainte.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lblContrainte.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblContrainte, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblContrainte.Name = "m_lblContrainte";
            this.m_lblContrainte.Size = new System.Drawing.Size(138, 22);
            this.m_lblContrainte.TabIndex = 0;
            this.m_lblContrainte.Text = "Profile label|556";
            this.m_lblContrainte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtSelectRessourceMaterielle
            // 
            this.m_txtSelectRessourceMaterielle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtSelectRessourceMaterielle.ElementSelectionne = null;
            this.m_txtSelectRessourceMaterielle.FonctionTextNull = null;
            this.m_txtSelectRessourceMaterielle.HasLink = true;
            this.m_txtSelectRessourceMaterielle.Location = new System.Drawing.Point(138, 0);
            this.m_txtSelectRessourceMaterielle.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectRessourceMaterielle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtSelectRessourceMaterielle.Name = "m_txtSelectRessourceMaterielle";
            this.m_txtSelectRessourceMaterielle.SelectedObject = null;
            this.m_txtSelectRessourceMaterielle.Size = new System.Drawing.Size(251, 22);
            this.m_txtSelectRessourceMaterielle.TabIndex = 1;
            this.m_txtSelectRessourceMaterielle.TextNull = "";
            this.m_txtSelectRessourceMaterielle.ElementSelectionneChanged += new System.EventHandler(this.m_txtSelectRessourceMaterielle_ElementSelectionneChanged);
            // 
            // m_lnkAffectationRapide
            // 
            this.m_lnkAffectationRapide.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_lnkAffectationRapide.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkAffectationRapide.Location = new System.Drawing.Point(389, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAffectationRapide, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkAffectationRapide.Name = "m_lnkAffectationRapide";
            this.m_lnkAffectationRapide.Size = new System.Drawing.Size(55, 22);
            this.m_lnkAffectationRapide.TabIndex = 2;
            this.m_lnkAffectationRapide.TabStop = true;
            this.m_lnkAffectationRapide.Text = "Help|70";
            this.m_lnkAffectationRapide.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lnkAffectationRapide.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkAffectationRapide_LinkClicked);
            // 
            // CControleAffecteRessourceMaterielle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_txtSelectRessourceMaterielle);
            this.Controls.Add(this.m_lnkAffectationRapide);
            this.Controls.Add(this.m_lblContrainte);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleAffecteRessourceMaterielle";
            this.Size = new System.Drawing.Size(444, 22);
            this.Load += new System.EventHandler(this.CControleAffecteRessourceMaterielle_Load);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label m_lblContrainte;
		private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_txtSelectRessourceMaterielle;
		private System.Windows.Forms.LinkLabel m_lnkAffectationRapide;
		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
	}
}
