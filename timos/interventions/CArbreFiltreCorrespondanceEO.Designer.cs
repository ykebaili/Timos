namespace timos.interventions
{
	partial class CArbreFiltreCorrespondanceEO
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CArbreFiltreCorrespondanceEO));
			this.m_arbreEO = new System.Windows.Forms.TreeView();
			this.m_menuArbreEO = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.m_menuFillesSeulement = new System.Windows.Forms.ToolStripMenuItem();
			this.m_menuParentsSeulement = new System.Windows.Forms.ToolStripMenuItem();
			this.m_menuEgaliteStricte = new System.Windows.Forms.ToolStripMenuItem();
			this.m_menuBrancheComplete = new System.Windows.Forms.ToolStripMenuItem();
			this.m_imagesArbre = new System.Windows.Forms.ImageList(this.components);
			this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
			this.m_menuArbreEO.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_arbreEO
			// 
			this.m_arbreEO.CheckBoxes = true;
			this.m_arbreEO.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_arbreEO.ImageIndex = 0;
			this.m_arbreEO.ImageList = this.m_imagesArbre;
			this.m_arbreEO.Location = new System.Drawing.Point(0, 0);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_arbreEO, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_arbreEO.Name = "m_arbreEO";
			this.m_arbreEO.SelectedImageIndex = 0;
			this.m_arbreEO.Size = new System.Drawing.Size(349, 271);
			this.m_arbreEO.TabIndex = 6;
			this.m_arbreEO.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.m_arbreEO_AfterCheck);
			this.m_arbreEO.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.m_arbreEO_BeforeCheck);
			this.m_arbreEO.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.m_arbreEO_NodeMouseClick);
			// 
			// m_menuArbreEO
			// 
			this.m_menuArbreEO.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_menuFillesSeulement,
            this.m_menuParentsSeulement,
            this.m_menuEgaliteStricte,
            this.m_menuBrancheComplete});
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_menuArbreEO, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_menuArbreEO.Name = "m_menuArbreEO";
			this.m_menuArbreEO.Size = new System.Drawing.Size(182, 92);
			// 
			// m_menuFillesSeulement
			// 
			this.m_menuFillesSeulement.Name = "m_menuFillesSeulement";
			this.m_menuFillesSeulement.Size = new System.Drawing.Size(181, 22);
			this.m_menuFillesSeulement.Text = "Filles uniquement";
			this.m_menuFillesSeulement.Click += new System.EventHandler(this.m_menuFillesSeulement_Click);
			// 
			// m_menuParentsSeulement
			// 
			this.m_menuParentsSeulement.Name = "m_menuParentsSeulement";
			this.m_menuParentsSeulement.Size = new System.Drawing.Size(181, 22);
			this.m_menuParentsSeulement.Text = "Parents uniquement";
			this.m_menuParentsSeulement.Click += new System.EventHandler(this.m_menuParentsSeulement_Click);
			// 
			// m_menuEgaliteStricte
			// 
			this.m_menuEgaliteStricte.Name = "m_menuEgaliteStricte";
			this.m_menuEgaliteStricte.Size = new System.Drawing.Size(181, 22);
			this.m_menuEgaliteStricte.Text = "Egalité stricte";
			this.m_menuEgaliteStricte.Click += new System.EventHandler(this.m_menuEgaliteStricte_Click);
			// 
			// m_menuBrancheComplete
			// 
			this.m_menuBrancheComplete.Name = "m_menuBrancheComplete";
			this.m_menuBrancheComplete.Size = new System.Drawing.Size(181, 22);
			this.m_menuBrancheComplete.Text = "Branche complète";
			this.m_menuBrancheComplete.Click += new System.EventHandler(this.m_menuBrancheComplete_Click);
			// 
			// m_imagesArbre
			// 
			this.m_imagesArbre.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imagesArbre.ImageStream")));
			this.m_imagesArbre.TransparentColor = System.Drawing.Color.Transparent;
			this.m_imagesArbre.Images.SetKeyName(0, "vide.bmp");
			this.m_imagesArbre.Images.SetKeyName(1, "childsonly.bmp");
			this.m_imagesArbre.Images.SetKeyName(2, "parentsOnly.bmp");
			this.m_imagesArbre.Images.SetKeyName(3, "egalitearbre.bmp");
			this.m_imagesArbre.Images.SetKeyName(4, "branchecomplete.bmp");
			// 
			// CArbreFiltreCorrespondanceEO
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.m_arbreEO);
			this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
			this.Name = "CArbreFiltreCorrespondanceEO";
			this.Size = new System.Drawing.Size(349, 271);
			this.m_menuArbreEO.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TreeView m_arbreEO;
		private System.Windows.Forms.ContextMenuStrip m_menuArbreEO;
		private System.Windows.Forms.ToolStripMenuItem m_menuFillesSeulement;
		private System.Windows.Forms.ToolStripMenuItem m_menuParentsSeulement;
		private System.Windows.Forms.ToolStripMenuItem m_menuEgaliteStricte;
		private System.Windows.Forms.ToolStripMenuItem m_menuBrancheComplete;
		private System.Windows.Forms.ImageList m_imagesArbre;
		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
	}
}
