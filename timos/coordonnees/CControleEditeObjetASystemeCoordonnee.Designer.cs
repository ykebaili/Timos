using sc2i.common;

namespace timos
{
	partial class CControleEditeObjetASystemeCoordonnee
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
            this.label1 = new System.Windows.Forms.Label();
            this.m_cmbSystemeCoordonnees = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.m_panelParametrage = new System.Windows.Forms.Panel();
            this.m_panelParametrageNiveaux = new sc2i.win32.common.C2iPanel(this.components);
            this.m_panelHeritage = new System.Windows.Forms.Panel();
            this.m_radioPropre = new System.Windows.Forms.RadioButton();
            this.m_radioHerite = new System.Windows.Forms.RadioButton();
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_panelParametrage.SuspendLayout();
            this.m_panelHeritage.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Coordinate system|531";
            // 
            // m_cmbSystemeCoordonnees
            // 
            this.m_cmbSystemeCoordonnees.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbSystemeCoordonnees.ComportementLinkStd = true;
            this.m_cmbSystemeCoordonnees.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbSystemeCoordonnees.ElementSelectionne = null;
            this.m_cmbSystemeCoordonnees.FormattingEnabled = true;
            this.m_cmbSystemeCoordonnees.IsLink = false;
            this.m_cmbSystemeCoordonnees.LinkProperty = "";
            this.m_cmbSystemeCoordonnees.ListDonnees = null;
            this.m_cmbSystemeCoordonnees.Location = new System.Drawing.Point(161, 7);
            this.m_cmbSystemeCoordonnees.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbSystemeCoordonnees, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbSystemeCoordonnees.Name = "m_cmbSystemeCoordonnees";
            this.m_cmbSystemeCoordonnees.NullAutorise = false;
            this.m_cmbSystemeCoordonnees.ProprieteAffichee = null;
            this.m_cmbSystemeCoordonnees.ProprieteParentListeObjets = null;
            this.m_cmbSystemeCoordonnees.SelectionneurParent = null;
            this.m_cmbSystemeCoordonnees.Size = new System.Drawing.Size(295, 21);
            this.m_cmbSystemeCoordonnees.TabIndex = 1;
            this.m_cmbSystemeCoordonnees.TextNull = I.T("(empty)|30195");
            this.m_cmbSystemeCoordonnees.Tri = true;
            this.m_cmbSystemeCoordonnees.TypeFormEdition = null;
            this.m_cmbSystemeCoordonnees.SelectionChangeCommitted += new System.EventHandler(this.m_cmbSystemeCoordonnees_SelectionChangeCommitted);
            // 
            // m_panelParametrage
            // 
            this.m_panelParametrage.Controls.Add(this.m_panelParametrageNiveaux);
            this.m_panelParametrage.Controls.Add(this.m_cmbSystemeCoordonnees);
            this.m_panelParametrage.Controls.Add(this.label1);
            this.m_panelParametrage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelParametrage.Location = new System.Drawing.Point(0, 26);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelParametrage, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelParametrage.Name = "m_panelParametrage";
            this.m_panelParametrage.Size = new System.Drawing.Size(459, 237);
            this.m_panelParametrage.TabIndex = 3;
            // 
            // m_panelParametrageNiveaux
            // 
            this.m_panelParametrageNiveaux.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelParametrageNiveaux.AutoScroll = true;
            this.m_panelParametrageNiveaux.Location = new System.Drawing.Point(3, 34);
            this.m_panelParametrageNiveaux.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelParametrageNiveaux, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelParametrageNiveaux.Name = "m_panelParametrageNiveaux";
            this.m_panelParametrageNiveaux.Size = new System.Drawing.Size(456, 200);
            this.m_panelParametrageNiveaux.TabIndex = 2;
            // 
            // m_panelHeritage
            // 
            this.m_panelHeritage.Controls.Add(this.m_radioPropre);
            this.m_panelHeritage.Controls.Add(this.m_radioHerite);
            this.m_panelHeritage.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelHeritage.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelHeritage, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelHeritage.Name = "m_panelHeritage";
            this.m_panelHeritage.Size = new System.Drawing.Size(459, 26);
            this.m_panelHeritage.TabIndex = 4;
            // 
            // m_radioPropre
            // 
            this.m_radioPropre.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_radioPropre.Location = new System.Drawing.Point(243, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_radioPropre, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_radioPropre.Name = "m_radioPropre";
            this.m_radioPropre.Size = new System.Drawing.Size(216, 24);
            this.m_radioPropre.TabIndex = 1;
            this.m_radioPropre.TabStop = true;
            this.m_radioPropre.Text = "Defines coordinate system|835";
            this.m_radioPropre.UseVisualStyleBackColor = true;
            this.m_radioPropre.CheckedChanged += new System.EventHandler(this.m_radioPropre_CheckedChanged);
            // 
            // m_radioHerite
            // 
            this.m_radioHerite.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_radioHerite.Location = new System.Drawing.Point(6, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_radioHerite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_radioHerite.Name = "m_radioHerite";
            this.m_radioHerite.Size = new System.Drawing.Size(217, 24);
            this.m_radioHerite.TabIndex = 0;
            this.m_radioHerite.TabStop = true;
            this.m_radioHerite.Text = "Inherits coordinate system|834";
            this.m_radioHerite.UseVisualStyleBackColor = true;
            this.m_radioHerite.CheckedChanged += new System.EventHandler(this.m_radioHerite_CheckedChanged);
            // 
            // CControleEditeObjetASystemeCoordonnee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_panelParametrage);
            this.Controls.Add(this.m_panelHeritage);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleEditeObjetASystemeCoordonnee";
            this.Size = new System.Drawing.Size(459, 263);
            this.m_panelParametrage.ResumeLayout(false);
            this.m_panelHeritage.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees m_cmbSystemeCoordonnees;
		private System.Windows.Forms.Panel m_panelParametrage;
		private System.Windows.Forms.Panel m_panelHeritage;
		private System.Windows.Forms.RadioButton m_radioPropre;
		private System.Windows.Forms.RadioButton m_radioHerite;
		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private sc2i.win32.common.C2iPanel m_panelParametrageNiveaux;
	}
}
