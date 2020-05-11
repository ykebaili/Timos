namespace timos
{
	partial class CPanelAffectationEO
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
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_arbre = new sc2i.win32.data.CArbreObjetsDonneesHierarchiques();
            this.m_panelChamps = new sc2i.formulaire.win32.editor.CPanelFormulaireSurElement();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_arbreHeritage = new System.Windows.Forms.TreeView();
            this.m_panelHeritage = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.m_panelEOsPropres = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.m_panelHeritage.SuspendLayout();
            this.m_panelEOsPropres.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_arbre
            // 
            this.m_arbre.CheckBoxes = true;
            this.m_arbre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_arbre.ElementSelectionne = null;
            this.m_arbre.ElementsSelectionnes = new sc2i.data.CObjetDonnee[0];
            this.m_arbre.ForeColorNonSelectionnable = System.Drawing.Color.DarkGray;
            this.m_arbre.Location = new System.Drawing.Point(0, 18);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_arbre, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_arbre.Name = "m_arbre";
            this.m_arbre.Size = new System.Drawing.Size(323, 299);
            this.m_arbre.TabIndex = 0;
            this.m_arbre.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.m_arbre_AfterCheck);
            this.m_arbre.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_arbre_AfterSelect);
            this.m_arbre.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.m_arbre_BeforeCheck);
            // 
            // m_panelChamps
            // 
            this.m_panelChamps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelChamps.ElementEdite = null;
            this.m_panelChamps.Location = new System.Drawing.Point(566, 0);
            this.m_panelChamps.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelChamps.Name = "m_panelChamps";
            this.m_panelChamps.Size = new System.Drawing.Size(106, 317);
            this.m_panelChamps.TabIndex = 1;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(233, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitter1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 317);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // m_arbreHeritage
            // 
            this.m_arbreHeritage.CheckBoxes = true;
            this.m_arbreHeritage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_arbreHeritage.Location = new System.Drawing.Point(0, 18);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_arbreHeritage, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_arbreHeritage.Name = "m_arbreHeritage";
            this.m_arbreHeritage.Size = new System.Drawing.Size(233, 299);
            this.m_arbreHeritage.TabIndex = 3;
            this.m_arbreHeritage.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.m_arbreHeritage_BeforeCheck);
            // 
            // m_panelHeritage
            // 
            this.m_panelHeritage.Controls.Add(this.m_arbreHeritage);
            this.m_panelHeritage.Controls.Add(this.label1);
            this.m_panelHeritage.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelHeritage.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelHeritage, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelHeritage.Name = "m_panelHeritage";
            this.m_panelHeritage.Size = new System.Drawing.Size(233, 317);
            this.m_panelHeritage.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Inherited Organizational Entities|10096";
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(561, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitter2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(5, 317);
            this.splitter2.TabIndex = 5;
            this.splitter2.TabStop = false;
            // 
            // m_panelEOsPropres
            // 
            this.m_panelEOsPropres.Controls.Add(this.m_arbre);
            this.m_panelEOsPropres.Controls.Add(this.label2);
            this.m_panelEOsPropres.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelEOsPropres.Location = new System.Drawing.Point(238, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEOsPropres, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelEOsPropres.Name = "m_panelEOsPropres";
            this.m_panelEOsPropres.Size = new System.Drawing.Size(323, 317);
            this.m_panelEOsPropres.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(323, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Proper Organizational Entities|10097";
            // 
            // CPanelAffectationEO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_panelChamps);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.m_panelEOsPropres);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.m_panelHeritage);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CPanelAffectationEO";
            this.Size = new System.Drawing.Size(672, 317);
            this.m_panelHeritage.ResumeLayout(false);
            this.m_panelEOsPropres.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private sc2i.win32.data.CArbreObjetsDonneesHierarchiques m_arbre;
		private sc2i.formulaire.win32.editor.CPanelFormulaireSurElement m_panelChamps;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.TreeView m_arbreHeritage;
		private System.Windows.Forms.Panel m_panelHeritage;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel m_panelEOsPropres;
        private System.Windows.Forms.Label label2;
	}
}
