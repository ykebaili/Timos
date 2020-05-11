using sc2i.common;


namespace timos
{
	partial class CControleSelectFormulaireParType
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
            this.m_lblType = new System.Windows.Forms.Label();
            this.m_comboFormulaire = new sc2i.win32.data.CComboBoxListeObjetsDonnees();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // m_lblType
            // 
            this.m_lblType.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lblType.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblType, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblType.Name = "m_lblType";
            this.m_lblType.Size = new System.Drawing.Size(182, 22);
            this.m_lblType.TabIndex = 0;
            this.m_lblType.Text = "label1";
            // 
            // m_comboFormulaire
            // 
            this.m_comboFormulaire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_comboFormulaire.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comboFormulaire.ElementSelectionne = null;
            this.m_comboFormulaire.FormattingEnabled = true;
            this.m_comboFormulaire.IsLink = false;
            this.m_comboFormulaire.ListDonnees = null;
            this.m_comboFormulaire.Location = new System.Drawing.Point(182, 0);
            this.m_comboFormulaire.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_comboFormulaire, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_comboFormulaire.Name = "m_comboFormulaire";
            this.m_comboFormulaire.NullAutorise = true;
            this.m_comboFormulaire.ProprieteAffichee = null;
            this.m_comboFormulaire.ProprieteParentListeObjets = null;
            this.m_comboFormulaire.SelectionneurParent = null;
            this.m_comboFormulaire.Size = new System.Drawing.Size(266, 21);
            this.m_comboFormulaire.TabIndex = 1;
            this.m_comboFormulaire.TextNull = "(none)";
            this.m_comboFormulaire.Tri = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox1.Location = new System.Drawing.Point(0, 22);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pictureBox1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(448, 1);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // CControleSelectFormulaireParType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_comboFormulaire);
            this.Controls.Add(this.m_lblType);
            this.Controls.Add(this.pictureBox1);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleSelectFormulaireParType";
            this.Size = new System.Drawing.Size(448, 23);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label m_lblType;
		private sc2i.win32.data.CComboBoxListeObjetsDonnees m_comboFormulaire;
		private System.Windows.Forms.PictureBox pictureBox1;
		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
	}
}
