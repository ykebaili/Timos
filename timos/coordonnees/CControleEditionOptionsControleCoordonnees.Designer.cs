namespace timos
{
	partial class CControleEditionOptionsControleCoordonnees
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
            this.m_chkNonObligatoire = new System.Windows.Forms.CheckBox();
            this.m_chkPasDeTestUnite = new System.Windows.Forms.CheckBox();
            this.m_chkIgnorerOccupation = new System.Windows.Forms.CheckBox();
            this.m_chkIgnorerDispo = new System.Windows.Forms.CheckBox();
            this.m_panelHeritage = new System.Windows.Forms.Panel();
            this.m_radioPropre = new System.Windows.Forms.RadioButton();
            this.m_radioHerite = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.m_panelParametrage = new sc2i.win32.common.C2iPanel(this.components);
            this.m_chkIgnoreSites = new System.Windows.Forms.CheckBox();
            this.m_chkIgnoreEquipements = new System.Windows.Forms.CheckBox();
            this.m_chkIgnoreStocks = new System.Windows.Forms.CheckBox();
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_panelHeritage.SuspendLayout();
            this.panel1.SuspendLayout();
            this.m_panelParametrage.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_chkNonObligatoire
            // 
            this.m_chkNonObligatoire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_chkNonObligatoire.Location = new System.Drawing.Point(3, 1);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkNonObligatoire, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_chkNonObligatoire.Name = "m_chkNonObligatoire";
            this.m_chkNonObligatoire.Size = new System.Drawing.Size(210, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkNonObligatoire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkNonObligatoire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkNonObligatoire.TabIndex = 0;
            this.m_chkNonObligatoire.Text = "Accept child without coordinate|510";
            this.m_chkNonObligatoire.UseVisualStyleBackColor = true;
            // 
            // m_chkPasDeTestUnite
            // 
            this.m_chkPasDeTestUnite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_chkPasDeTestUnite.Location = new System.Drawing.Point(3, 16);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkPasDeTestUnite, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_chkPasDeTestUnite.Name = "m_chkPasDeTestUnite";
            this.m_chkPasDeTestUnite.Size = new System.Drawing.Size(210, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkPasDeTestUnite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkPasDeTestUnite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkPasDeTestUnite.TabIndex = 1;
            this.m_chkPasDeTestUnite.Text = "Ignore child unit|511";
            this.m_chkPasDeTestUnite.UseVisualStyleBackColor = true;
            // 
            // m_chkIgnorerOccupation
            // 
            this.m_chkIgnorerOccupation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_chkIgnorerOccupation.Location = new System.Drawing.Point(219, 16);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkIgnorerOccupation, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_chkIgnorerOccupation.Name = "m_chkIgnorerOccupation";
            this.m_chkIgnorerOccupation.Size = new System.Drawing.Size(189, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkIgnorerOccupation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkIgnorerOccupation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkIgnorerOccupation.TabIndex = 2;
            this.m_chkIgnorerOccupation.Text = "Ignore child occupation (use 1)|512";
            this.m_chkIgnorerOccupation.UseVisualStyleBackColor = true;
            // 
            // m_chkIgnorerDispo
            // 
            this.m_chkIgnorerDispo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_chkIgnorerDispo.Location = new System.Drawing.Point(219, 1);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkIgnorerDispo, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_chkIgnorerDispo.Name = "m_chkIgnorerDispo";
            this.m_chkIgnorerDispo.Size = new System.Drawing.Size(239, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkIgnorerDispo, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkIgnorerDispo, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkIgnorerDispo.TabIndex = 3;
            this.m_chkIgnorerDispo.Text = "Several child entities can use the same coordinate|513";
            this.m_chkIgnorerDispo.UseVisualStyleBackColor = true;
            // 
            // m_panelHeritage
            // 
            this.m_panelHeritage.Controls.Add(this.m_radioPropre);
            this.m_panelHeritage.Controls.Add(this.m_radioHerite);
            this.m_panelHeritage.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelHeritage.Location = new System.Drawing.Point(0, 20);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelHeritage, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelHeritage.Name = "m_panelHeritage";
            this.m_panelHeritage.Size = new System.Drawing.Size(489, 20);
            this.m_extStyle.SetStyleBackColor(this.m_panelHeritage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelHeritage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelHeritage.TabIndex = 5;
            // 
            // m_radioPropre
            // 
            this.m_radioPropre.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_radioPropre.Location = new System.Drawing.Point(248, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_radioPropre, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_radioPropre.Name = "m_radioPropre";
            this.m_radioPropre.Size = new System.Drawing.Size(195, 20);
            this.m_extStyle.SetStyleBackColor(this.m_radioPropre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_radioPropre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_radioPropre.TabIndex = 1;
            this.m_radioPropre.TabStop = true;
            this.m_radioPropre.Text = "Define control options|516";
            this.m_radioPropre.UseVisualStyleBackColor = true;
            this.m_radioPropre.CheckedChanged += new System.EventHandler(this.m_radioPropre_CheckedChanged);
            // 
            // m_radioHerite
            // 
            this.m_radioHerite.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_radioHerite.Location = new System.Drawing.Point(6, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_radioHerite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_radioHerite.Name = "m_radioHerite";
            this.m_radioHerite.Size = new System.Drawing.Size(195, 20);
            this.m_extStyle.SetStyleBackColor(this.m_radioHerite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_radioHerite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_radioHerite.TabIndex = 0;
            this.m_radioHerite.TabStop = true;
            this.m_radioHerite.Text = "Inherit control options|515";
            this.m_radioHerite.UseVisualStyleBackColor = true;
            this.m_radioHerite.CheckedChanged += new System.EventHandler(this.m_radioHerite_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(489, 20);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 16);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTitrePanel);
            this.label1.TabIndex = 0;
            this.label1.Text = "Child coordinate control options|514";
            // 
            // m_panelParametrage
            // 
            this.m_panelParametrage.Controls.Add(this.m_chkIgnoreSites);
            this.m_panelParametrage.Controls.Add(this.m_chkIgnoreEquipements);
            this.m_panelParametrage.Controls.Add(this.m_chkIgnoreStocks);
            this.m_panelParametrage.Controls.Add(this.m_chkNonObligatoire);
            this.m_panelParametrage.Controls.Add(this.m_chkPasDeTestUnite);
            this.m_panelParametrage.Controls.Add(this.m_chkIgnorerOccupation);
            this.m_panelParametrage.Controls.Add(this.m_chkIgnorerDispo);
            this.m_panelParametrage.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelParametrage.Location = new System.Drawing.Point(0, 40);
            this.m_panelParametrage.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelParametrage, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelParametrage.Name = "m_panelParametrage";
            this.m_panelParametrage.Size = new System.Drawing.Size(489, 50);
            this.m_extStyle.SetStyleBackColor(this.m_panelParametrage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelParametrage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelParametrage.TabIndex = 8;
            // 
            // m_chkIgnoreSites
            // 
            this.m_chkIgnoreSites.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_chkIgnoreSites.Location = new System.Drawing.Point(308, 31);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkIgnoreSites, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_chkIgnoreSites.Name = "m_chkIgnoreSites";
            this.m_chkIgnoreSites.Size = new System.Drawing.Size(137, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkIgnoreSites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkIgnoreSites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkIgnoreSites.TabIndex = 6;
            this.m_chkIgnoreSites.Text = "Ignore sites|20463";
            this.m_chkIgnoreSites.UseVisualStyleBackColor = true;
            // 
            // m_chkIgnoreEquipements
            // 
            this.m_chkIgnoreEquipements.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_chkIgnoreEquipements.Location = new System.Drawing.Point(3, 31);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkIgnoreEquipements, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_chkIgnoreEquipements.Name = "m_chkIgnoreEquipements";
            this.m_chkIgnoreEquipements.Size = new System.Drawing.Size(156, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkIgnoreEquipements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkIgnoreEquipements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkIgnoreEquipements.TabIndex = 4;
            this.m_chkIgnoreEquipements.Text = "Ignore equipments|20461";
            this.m_chkIgnoreEquipements.UseVisualStyleBackColor = true;
            // 
            // m_chkIgnoreStocks
            // 
            this.m_chkIgnoreStocks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_chkIgnoreStocks.Location = new System.Drawing.Point(165, 31);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkIgnoreStocks, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_chkIgnoreStocks.Name = "m_chkIgnoreStocks";
            this.m_chkIgnoreStocks.Size = new System.Drawing.Size(137, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkIgnoreStocks, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkIgnoreStocks, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkIgnoreStocks.TabIndex = 5;
            this.m_chkIgnoreStocks.Text = "Ignore stocks|20462";
            this.m_chkIgnoreStocks.UseVisualStyleBackColor = true;
            // 
            // CControleEditionOptionsControleCoordonnees
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_panelParametrage);
            this.Controls.Add(this.m_panelHeritage);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleEditionOptionsControleCoordonnees";
            this.Size = new System.Drawing.Size(489, 93);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelHeritage.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.m_panelParametrage.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.CheckBox m_chkNonObligatoire;
		private System.Windows.Forms.CheckBox m_chkPasDeTestUnite;
		private System.Windows.Forms.CheckBox m_chkIgnorerOccupation;
		private System.Windows.Forms.CheckBox m_chkIgnorerDispo;
		private System.Windows.Forms.Panel m_panelHeritage;
		private System.Windows.Forms.RadioButton m_radioPropre;
		private System.Windows.Forms.RadioButton m_radioHerite;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.CExtStyle m_extStyle;
		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private sc2i.win32.common.C2iPanel m_panelParametrage;
        private System.Windows.Forms.CheckBox m_chkIgnoreEquipements;
        private System.Windows.Forms.CheckBox m_chkIgnoreStocks;
        private System.Windows.Forms.CheckBox m_chkIgnoreSites;
	}
}
