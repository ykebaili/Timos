using sc2i.common;

namespace timos.coordonnees
{
	partial class CControlEditionObjetAOccupation
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.m_exStyle = new sc2i.win32.common.CExtStyle();
            this.m_panelHeritage = new System.Windows.Forms.Panel();
            this.m_radioPropre = new System.Windows.Forms.RadioButton();
            this.m_radioHerite = new System.Windows.Forms.RadioButton();
            this.m_panelParametrage = new sc2i.win32.common.C2iPanel(this.components);
            this.m_cmbUnite = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.m_txtNbUnites = new sc2i.win32.common.C2iTextBoxNumerique();
            this.label2 = new System.Windows.Forms.Label();
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.panel1.SuspendLayout();
            this.m_panelHeritage.SuspendLayout();
            this.m_panelParametrage.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(345, 19);
            this.m_exStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Beige;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 16);
            this.m_exStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 0;
            this.label1.Text = "Occupation|520";
            // 
            // m_panelHeritage
            // 
            this.m_panelHeritage.Controls.Add(this.m_radioPropre);
            this.m_panelHeritage.Controls.Add(this.m_radioHerite);
            this.m_panelHeritage.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelHeritage.Location = new System.Drawing.Point(0, 19);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelHeritage, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelHeritage.Name = "m_panelHeritage";
            this.m_panelHeritage.Size = new System.Drawing.Size(345, 20);
            this.m_exStyle.SetStyleBackColor(this.m_panelHeritage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_panelHeritage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelHeritage.TabIndex = 9;
            // 
            // m_radioPropre
            // 
            this.m_radioPropre.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_radioPropre.Location = new System.Drawing.Point(185, -1);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_radioPropre, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_radioPropre.Name = "m_radioPropre";
            this.m_radioPropre.Size = new System.Drawing.Size(150, 16);
            this.m_exStyle.SetStyleBackColor(this.m_radioPropre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_radioPropre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_radioPropre.TabIndex = 1;
            this.m_radioPropre.TabStop = true;
            this.m_radioPropre.Text = "Defines occupation|517";
            this.m_radioPropre.UseVisualStyleBackColor = true;
            this.m_radioPropre.CheckedChanged += new System.EventHandler(this.m_radioPropre_CheckedChanged);
            // 
            // m_radioHerite
            // 
            this.m_radioHerite.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_radioHerite.Location = new System.Drawing.Point(29, 1);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_radioHerite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_radioHerite.Name = "m_radioHerite";
            this.m_radioHerite.Size = new System.Drawing.Size(150, 16);
            this.m_exStyle.SetStyleBackColor(this.m_radioHerite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_radioHerite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_radioHerite.TabIndex = 0;
            this.m_radioHerite.TabStop = true;
            this.m_radioHerite.Text = "Inherits occupation|527";
            this.m_radioHerite.UseVisualStyleBackColor = true;
            this.m_radioHerite.CheckedChanged += new System.EventHandler(this.m_radioHerite_CheckedChanged);
            // 
            // m_panelParametrage
            // 
            this.m_panelParametrage.Controls.Add(this.m_cmbUnite);
            this.m_panelParametrage.Controls.Add(this.m_txtNbUnites);
            this.m_panelParametrage.Controls.Add(this.label2);
            this.m_panelParametrage.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelParametrage.Location = new System.Drawing.Point(0, 39);
            this.m_panelParametrage.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelParametrage, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelParametrage.Name = "m_panelParametrage";
            this.m_panelParametrage.Size = new System.Drawing.Size(345, 24);
            this.m_exStyle.SetStyleBackColor(this.m_panelParametrage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_panelParametrage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelParametrage.TabIndex = 10;
            // 
            // m_cmbUnite
            // 
            this.m_cmbUnite.ComportementLinkStd = true;
            this.m_cmbUnite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbUnite.ElementSelectionne = null;
            this.m_cmbUnite.FormattingEnabled = true;
            this.m_cmbUnite.IsLink = false;
            this.m_cmbUnite.LinkProperty = "";
            this.m_cmbUnite.ListDonnees = null;
            this.m_cmbUnite.Location = new System.Drawing.Point(156, 1);
            this.m_cmbUnite.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbUnite, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_cmbUnite.Name = "m_cmbUnite";
            this.m_cmbUnite.NullAutorise = false;
            this.m_cmbUnite.ProprieteAffichee = null;
            this.m_cmbUnite.ProprieteParentListeObjets = null;
            this.m_cmbUnite.SelectionneurParent = null;
            this.m_cmbUnite.Size = new System.Drawing.Size(182, 21);
            this.m_exStyle.SetStyleBackColor(this.m_cmbUnite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_cmbUnite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbUnite.TabIndex = 2;
            this.m_cmbUnite.TextNull = I.T("(empty)|30195");
            this.m_cmbUnite.Tri = true;
            this.m_cmbUnite.TypeFormEdition = null;
            this.m_cmbUnite.SelectionChangeCommitted += new System.EventHandler(this.m_cmbUnite_SelectionChangeCommitted);
            // 
            // m_txtNbUnites
            // 
            this.m_txtNbUnites.Arrondi = 0;
            this.m_txtNbUnites.DecimalAutorise = false;
            this.m_txtNbUnites.DoubleValue = null;
            this.m_txtNbUnites.IntValue = null;
            this.m_txtNbUnites.Location = new System.Drawing.Point(109, 1);
            this.m_txtNbUnites.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtNbUnites, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtNbUnites.Name = "m_txtNbUnites";
            this.m_txtNbUnites.NullAutorise = true;
            this.m_txtNbUnites.SelectAllOnEnter = true;
            this.m_txtNbUnites.Size = new System.Drawing.Size(44, 20);
            this.m_exStyle.SetStyleBackColor(this.m_txtNbUnites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_txtNbUnites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtNbUnites.TabIndex = 1;
            this.m_txtNbUnites.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtNbUnites.TextChanged += new System.EventHandler(this.m_txtNbUnites_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 4);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.m_exStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 0;
            this.label2.Text = "Occupies|518";
            // 
            // CControlEditionObjetAOccupation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_panelParametrage);
            this.Controls.Add(this.m_panelHeritage);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControlEditionObjetAOccupation";
            this.Size = new System.Drawing.Size(345, 63);
            this.m_exStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_exStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.panel1.ResumeLayout(false);
            this.m_panelHeritage.ResumeLayout(false);
            this.m_panelParametrage.ResumeLayout(false);
            this.m_panelParametrage.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.CExtStyle m_exStyle;
		private System.Windows.Forms.Panel m_panelHeritage;
		private System.Windows.Forms.RadioButton m_radioPropre;
		private System.Windows.Forms.RadioButton m_radioHerite;
		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private sc2i.win32.common.C2iPanel m_panelParametrage;
		private System.Windows.Forms.Label label2;
		private sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees m_cmbUnite;
		private sc2i.win32.common.C2iTextBoxNumerique m_txtNbUnites;
	}
}
