using sc2i.common;

namespace timos.Parametrage.ConsultationHierarchique
{
	partial class CPanelEditConsultationHierarchique
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
            this.m_arbre = new System.Windows.Forms.TreeView();
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_panelEdition = new sc2i.win32.common.C2iPanel(this.components);
            this.m_menuArbre = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_menuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuSupprimer = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuArbre.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_arbre
            // 
            this.m_arbre.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_arbre.HideSelection = false;
            this.m_arbre.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_arbre, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_arbre.Name = "m_arbre";
            this.m_arbre.Size = new System.Drawing.Size(187, 265);
            this.m_arbre.TabIndex = 0;
            this.m_arbre.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_arbre_MouseUp);
            this.m_arbre.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_arbre_AfterSelect);
            this.m_arbre.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.m_arbre_NodeMouseClick);
            // 
            // m_panelEdition
            // 
            this.m_panelEdition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelEdition.Location = new System.Drawing.Point(187, 0);
            this.m_panelEdition.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_panelEdition, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelEdition.Name = "m_panelEdition";
            this.m_panelEdition.Size = new System.Drawing.Size(214, 265);
            this.m_panelEdition.TabIndex = 1;
            // 
            // m_menuArbre
            // 
            this.m_menuArbre.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_menuAdd,
            this.m_menuSupprimer});
            this.m_extModeEdition.SetModeEdition(this.m_menuArbre, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_menuArbre.Name = "m_menuArbre";
            this.m_menuArbre.Size = new System.Drawing.Size(159, 48);
            // 
            // m_menuAdd
            // 
            this.m_menuAdd.Name = "m_menuAdd";
            this.m_menuAdd.Size = new System.Drawing.Size(158, 22);
            this.m_menuAdd.Text = "Add|20085";
            // 
            // m_menuSupprimer
            // 
            this.m_menuSupprimer.Name = "m_menuSupprimer";
            this.m_menuSupprimer.Size = new System.Drawing.Size(158, 22);
            this.m_menuSupprimer.Text = "Remove|20089";
            this.m_menuSupprimer.Click += new System.EventHandler(this.m_menuSupprimer_Click);
            // 
            // CPanelEditConsultationHierarchique
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_panelEdition);
            this.Controls.Add(this.m_arbre);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CPanelEditConsultationHierarchique";
            this.Size = new System.Drawing.Size(401, 265);
            this.m_menuArbre.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TreeView m_arbre;
		private sc2i.win32.common.CExtModeEdition m_extModeEdition;
		private sc2i.win32.common.C2iPanel m_panelEdition;
		private System.Windows.Forms.ContextMenuStrip m_menuArbre;
        private System.Windows.Forms.ToolStripMenuItem m_menuAdd;
		private System.Windows.Forms.ToolStripMenuItem m_menuSupprimer;
	}
}
