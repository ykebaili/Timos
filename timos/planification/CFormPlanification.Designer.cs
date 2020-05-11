namespace timos
{
	partial class CFormPlanification
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormPlanification));
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtSelectElementAInterventions = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_panelMilieu = new sc2i.win32.common.C2iPanel(this.components);
            this.m_controlPlanning = new timos.win32.composants.CControlePlanning();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_panelPreplanif = new sc2i.win32.common.C2iPanel(this.components);
            this.m_panelHaut = new sc2i.win32.common.C2iPanel(this.components);
            this.m_radioRessources = new System.Windows.Forms.RadioButton();
            this.m_radioIntervenants = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.m_panelBas = new sc2i.win32.common.C2iPanel(this.components);
            this.m_btnIntervenant = new System.Windows.Forms.Button();
            this.m_btnValider = new System.Windows.Forms.Button();
            this.m_btnAjouter = new System.Windows.Forms.Button();
            this.m_panelMilieu.SuspendLayout();
            this.m_panelHaut.SuspendLayout();
            this.m_panelBas.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Plan an Intervention for|1013";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtSelectElementAInterventions
            // 
            this.m_txtSelectElementAInterventions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtSelectElementAInterventions.ElementSelectionne = null;
            this.m_txtSelectElementAInterventions.HasLink = true;
            this.m_txtSelectElementAInterventions.Location = new System.Drawing.Point(170, 0);
            this.m_txtSelectElementAInterventions.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectElementAInterventions, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtSelectElementAInterventions.Name = "m_txtSelectElementAInterventions";
            this.m_txtSelectElementAInterventions.SelectedObject = null;
            this.m_txtSelectElementAInterventions.Size = new System.Drawing.Size(620, 21);
            this.m_txtSelectElementAInterventions.TabIndex = 2;
            this.m_txtSelectElementAInterventions.OnSelectedObjectChanged += new System.EventHandler(this.m_txtSelectElementAInterventions_OnSelectedObjectChanged);
            // 
            // m_panelMilieu
            // 
            this.m_panelMilieu.Controls.Add(this.m_controlPlanning);
            this.m_panelMilieu.Controls.Add(this.splitter1);
            this.m_panelMilieu.Controls.Add(this.m_panelPreplanif);
            this.m_panelMilieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelMilieu.Location = new System.Drawing.Point(0, 50);
            this.m_panelMilieu.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelMilieu, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelMilieu.Name = "m_panelMilieu";
            this.m_panelMilieu.Size = new System.Drawing.Size(804, 305);
            this.m_panelMilieu.TabIndex = 3;
            // 
            // m_controlPlanning
            // 
            this.m_controlPlanning.AutoTooltip = true;
            this.m_controlPlanning.BaseAffichee = null;
            this.m_controlPlanning.DateDebut = new System.DateTime(2007, 8, 1, 0, 0, 0, 0);
            this.m_controlPlanning.DateFin = new System.DateTime(2007, 8, 5, 0, 0, 0, 0);
            this.m_controlPlanning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_controlPlanning.ElementAInterventionSelectionne = null;
            this.m_controlPlanning.EnableAffichageDatesEnBas = true;
            this.m_controlPlanning.Location = new System.Drawing.Point(170, 0);
            this.m_controlPlanning.LockEdition = false;
            this.m_controlPlanning.MasquerEntetesLignes = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_controlPlanning, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_controlPlanning.Name = "m_controlPlanning";
            this.m_controlPlanning.Size = new System.Drawing.Size(634, 305);
            this.m_controlPlanning.TabIndex = 0;
            this.m_controlPlanning.TypeRessourcesAAffecter = typeof(timos.acteurs.CActeur);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(167, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitter1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 305);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // m_panelPreplanif
            // 
            this.m_panelPreplanif.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelPreplanif.Location = new System.Drawing.Point(0, 0);
            this.m_panelPreplanif.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelPreplanif, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelPreplanif.Name = "m_panelPreplanif";
            this.m_panelPreplanif.Size = new System.Drawing.Size(167, 305);
            this.m_panelPreplanif.TabIndex = 1;
            // 
            // m_panelHaut
            // 
            this.m_panelHaut.Controls.Add(this.m_radioRessources);
            this.m_panelHaut.Controls.Add(this.m_radioIntervenants);
            this.m_panelHaut.Controls.Add(this.label2);
            this.m_panelHaut.Controls.Add(this.label1);
            this.m_panelHaut.Controls.Add(this.m_txtSelectElementAInterventions);
            this.m_panelHaut.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelHaut.Location = new System.Drawing.Point(0, 0);
            this.m_panelHaut.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelHaut, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelHaut.Name = "m_panelHaut";
            this.m_panelHaut.Size = new System.Drawing.Size(804, 50);
            this.m_panelHaut.TabIndex = 4;
            // 
            // m_radioRessources
            // 
            this.m_radioRessources.AutoSize = true;
            this.m_radioRessources.Location = new System.Drawing.Point(281, 28);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_radioRessources, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_radioRessources.Name = "m_radioRessources";
            this.m_radioRessources.Size = new System.Drawing.Size(96, 17);
            this.m_radioRessources.TabIndex = 5;
            this.m_radioRessources.TabStop = true;
            this.m_radioRessources.Text = "Resources|254";
            this.m_radioRessources.UseVisualStyleBackColor = true;
            this.m_radioRessources.CheckedChanged += new System.EventHandler(this.m_radioRessources_CheckedChanged);
            // 
            // m_radioIntervenants
            // 
            this.m_radioIntervenants.AutoSize = true;
            this.m_radioIntervenants.Location = new System.Drawing.Point(170, 28);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_radioIntervenants, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_radioIntervenants.Name = "m_radioIntervenants";
            this.m_radioIntervenants.Size = new System.Drawing.Size(91, 17);
            this.m_radioIntervenants.TabIndex = 4;
            this.m_radioIntervenants.TabStop = true;
            this.m_radioIntervenants.Text = "Opetators|387";
            this.m_radioIntervenants.UseVisualStyleBackColor = true;
            this.m_radioIntervenants.CheckedChanged += new System.EventHandler(this.m_radioIntervenants_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Allocation mode|1014";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_panelBas
            // 
            this.m_panelBas.Controls.Add(this.m_btnIntervenant);
            this.m_panelBas.Controls.Add(this.m_btnValider);
            this.m_panelBas.Controls.Add(this.m_btnAjouter);
            this.m_panelBas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_panelBas.Location = new System.Drawing.Point(0, 355);
            this.m_panelBas.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelBas, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelBas.Name = "m_panelBas";
            this.m_panelBas.Size = new System.Drawing.Size(804, 44);
            this.m_panelBas.TabIndex = 5;
            // 
            // m_btnIntervenant
            // 
            this.m_btnIntervenant.Location = new System.Drawing.Point(156, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnIntervenant, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnIntervenant.Name = "m_btnIntervenant";
            this.m_btnIntervenant.Size = new System.Drawing.Size(75, 23);
            this.m_btnIntervenant.TabIndex = 2;
            this.m_btnIntervenant.Text = "Operator|388";
            this.m_btnIntervenant.UseVisualStyleBackColor = true;
            this.m_btnIntervenant.Click += new System.EventHandler(this.m_btnIntervenant_Click);
            // 
            // m_btnValider
            // 
            this.m_btnValider.Location = new System.Drawing.Point(512, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnValider, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnValider.Name = "m_btnValider";
            this.m_btnValider.Size = new System.Drawing.Size(75, 23);
            this.m_btnValider.TabIndex = 1;
            this.m_btnValider.Text = "Validate|23";
            this.m_btnValider.UseVisualStyleBackColor = true;
            this.m_btnValider.Click += new System.EventHandler(this.m_btnValider_Click);
            // 
            // m_btnAjouter
            // 
            this.m_btnAjouter.Location = new System.Drawing.Point(13, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAjouter, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnAjouter.Name = "m_btnAjouter";
            this.m_btnAjouter.Size = new System.Drawing.Size(75, 23);
            this.m_btnAjouter.TabIndex = 0;
            this.m_btnAjouter.Text = "Add|22";
            this.m_btnAjouter.UseVisualStyleBackColor = true;
            this.m_btnAjouter.Click += new System.EventHandler(this.m_btnAjouter_Click);
            // 
            // CFormPlanification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(804, 399);
            this.Controls.Add(this.m_panelMilieu);
            this.Controls.Add(this.m_panelBas);
            this.Controls.Add(this.m_panelHaut);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CFormPlanification";
            this.Text = "Planning|563";
            this.Load += new System.EventHandler(this.CFormPlanification_Load);
            this.m_panelMilieu.ResumeLayout(false);
            this.m_panelHaut.ResumeLayout(false);
            this.m_panelHaut.PerformLayout();
            this.m_panelBas.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private timos.win32.composants.CControlePlanning m_controlPlanning;
		private System.Windows.Forms.Label label1;
		private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_txtSelectElementAInterventions;
		private sc2i.win32.common.C2iPanel m_panelMilieu;
		private System.Windows.Forms.Splitter splitter1;
		private sc2i.win32.common.C2iPanel m_panelPreplanif;
		private sc2i.win32.common.C2iPanel m_panelHaut;
		private sc2i.win32.common.C2iPanel m_panelBas;
		private System.Windows.Forms.Button m_btnAjouter;
		private System.Windows.Forms.Button m_btnValider;
		private System.Windows.Forms.Button m_btnIntervenant;
		private System.Windows.Forms.RadioButton m_radioRessources;
		private System.Windows.Forms.RadioButton m_radioIntervenants;
		private System.Windows.Forms.Label label2;
	}
}
