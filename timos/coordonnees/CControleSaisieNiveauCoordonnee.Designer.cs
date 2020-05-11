namespace timos.coordonnees
{
	partial class CControleSaisieNiveauCoordonnee
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
            this.m_lblLibelle = new System.Windows.Forms.Label();
            this.m_lblUnite = new System.Windows.Forms.Label();
            this.m_lblAide = new System.Windows.Forms.Label();
            this.m_tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.m_txtValeur = new sc2i.win32.common.IntellisenseTextBox();
            this.SuspendLayout();
            // 
            // m_lblLibelle
            // 
            this.m_lblLibelle.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lblLibelle.Location = new System.Drawing.Point(0, 0);
            this.m_lblLibelle.Name = "m_lblLibelle";
            this.m_lblLibelle.Size = new System.Drawing.Size(125, 20);
            this.m_lblLibelle.TabIndex = 0;
            this.m_lblLibelle.Text = "Label|50";
            this.m_lblLibelle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblUnite
            // 
            this.m_lblUnite.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lblUnite.Location = new System.Drawing.Point(226, 0);
            this.m_lblUnite.Name = "m_lblUnite";
            this.m_lblUnite.Size = new System.Drawing.Size(97, 20);
            this.m_lblUnite.TabIndex = 2;
            this.m_lblUnite.Text = "Unit|444";
            this.m_lblUnite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblAide
            // 
            this.m_lblAide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lblAide.Location = new System.Drawing.Point(323, 0);
            this.m_lblAide.Name = "m_lblAide";
            this.m_lblAide.Size = new System.Drawing.Size(136, 20);
            this.m_lblAide.TabIndex = 3;
            this.m_lblAide.Text = "Information|52";
            this.m_lblAide.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtValeur
            // 
            this.m_txtValeur.AcceptReturn = true;
            this.m_txtValeur.Arbre = null;
            this.m_txtValeur.AvecBouton = false;
            this.m_txtValeur.DisableIntellisense = false;
            this.m_txtValeur.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_txtValeur.Location = new System.Drawing.Point(125, 0);
            this.m_txtValeur.LockEdition = false;
            this.m_txtValeur.Name = "m_txtValeur";
            this.m_txtValeur.SeparateursPrincipaux = ";.\r\t\n,()[]{}";
            this.m_txtValeur.SeparateursSecondaires = " \r\t\n";
            this.m_txtValeur.Size = new System.Drawing.Size(101, 20);
            this.m_txtValeur.TabIndex = 5;
            // 
            // CControleSaisieNiveauCoordonnee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_lblAide);
            this.Controls.Add(this.m_lblUnite);
            this.Controls.Add(this.m_txtValeur);
            this.Controls.Add(this.m_lblLibelle);
            this.Name = "CControleSaisieNiveauCoordonnee";
            this.Size = new System.Drawing.Size(459, 20);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label m_lblLibelle;
		private System.Windows.Forms.Label m_lblUnite;
		private System.Windows.Forms.Label m_lblAide;
		private System.Windows.Forms.ToolTip m_tooltip;
		private sc2i.win32.common.IntellisenseTextBox m_txtValeur;
	}
}
