namespace timos.version
{
	partial class CControlListeVersions
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
			sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CControlListeVersions));
			sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
			this.m_panelListeVersions = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.SuspendLayout();
			// 
			// m_panelListeVersions
			// 
			this.m_panelListeVersions.AllowArbre = true;
			this.m_panelListeVersions.BoutonAjouterVisible = false;
			this.m_panelListeVersions.BoutonSupprimerVisible = false;
			glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
			glColumn1.BackColor = System.Drawing.Color.Transparent;
			glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
			glColumn1.ForColor = System.Drawing.Color.Black;
			glColumn1.ImageIndex = -1;
			glColumn1.IsCheckColumn = false;
			glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
			glColumn1.Name = "Name";
			glColumn1.Propriete = "Date";
			glColumn1.Text = "Date|246";
			glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
			glColumn1.Width = 100;
			glColumn2.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn2.ActiveControlItems")));
			glColumn2.BackColor = System.Drawing.Color.Transparent;
			glColumn2.ControlType = sc2i.win32.common.ColumnControlTypes.None;
			glColumn2.ForColor = System.Drawing.Color.Black;
			glColumn2.ImageIndex = -1;
			glColumn2.IsCheckColumn = false;
			glColumn2.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
			glColumn2.Name = "Name";
			glColumn2.Propriete = "Libelle";
			glColumn2.Text = "Label|50";
			glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
			glColumn2.Width = 300;
			this.m_panelListeVersions.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1,
            glColumn2});
			this.m_panelListeVersions.ContexteUtilisation = "";
			this.m_panelListeVersions.ControlFiltreStandard = null;
			this.m_panelListeVersions.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_panelListeVersions.EnableCustomisation = true;
			this.m_panelListeVersions.FiltreDeBase = null;
			this.m_panelListeVersions.FiltreDeBaseEnAjout = false;
			this.m_panelListeVersions.FiltrePrefere = null;
			this.m_panelListeVersions.FiltreRapide = null;
			this.m_panelListeVersions.ListeObjets = null;
			this.m_panelListeVersions.Location = new System.Drawing.Point(0, 0);
			this.m_panelListeVersions.ModeQuickSearch = false;
			this.m_panelListeVersions.ModeSelection = false;
			this.m_panelListeVersions.MultiSelect = false;
			this.m_panelListeVersions.Name = "m_panelListeVersions";
			this.m_panelListeVersions.Navigateur = null;
			this.m_panelListeVersions.ProprieteObjetAEditer = null;
			this.m_panelListeVersions.QuickSearchText = "";
			this.m_panelListeVersions.Size = new System.Drawing.Size(257, 212);
			this.m_panelListeVersions.TabIndex = 0;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(257, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 212);
			this.splitter1.TabIndex = 1;
			this.splitter1.TabStop = false;
			// 
			// CControlListeVersions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.m_panelListeVersions);
			this.Name = "CControlListeVersions";
			this.Size = new System.Drawing.Size(492, 212);
			this.ResumeLayout(false);

		}

		#endregion

		private sc2i.win32.data.navigation.CPanelListeSpeedStandard m_panelListeVersions;
		private System.Windows.Forms.Splitter splitter1;
	}
}
