namespace spv.win32
{
    partial class CExtenderFormSitePrestation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CExtenderFormSitePrestation));
            this.m_panelListePrestations = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_PanelPrestations = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.SuspendLayout();
            // 
            // m_panelListePrestations
            // 
            this.m_panelListePrestations.AllowArbre = true;
            this.m_panelListePrestations.AllowCustomisation = true;
            this.m_panelListePrestations.ContexteUtilisation = "";
            this.m_panelListePrestations.ControlFiltreStandard = null;
            this.m_panelListePrestations.ElementSelectionne = null;
            this.m_panelListePrestations.EnableCustomisation = true;
            this.m_panelListePrestations.FiltreDeBase = null;
            this.m_panelListePrestations.FiltreDeBaseEnAjout = false;
            this.m_panelListePrestations.FiltrePrefere = null;
            this.m_panelListePrestations.FiltreRapide = null;
            this.m_panelListePrestations.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panelListePrestations, "");
            this.m_panelListePrestations.ListeObjets = null;
            this.m_panelListePrestations.Location = new System.Drawing.Point(3, 19);
            this.m_panelListePrestations.LockEdition = true;
            this.m_extModeEdition.SetModeEdition(this.m_panelListePrestations, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelListePrestations.ModeQuickSearch = false;
            this.m_panelListePrestations.ModeSelection = false;
            this.m_panelListePrestations.MultiSelect = false;
            this.m_panelListePrestations.Name = "m_panelListePrestations";
            this.m_panelListePrestations.Navigateur = null;
            this.m_panelListePrestations.ProprieteObjetAEditer = null;
            this.m_panelListePrestations.QuickSearchText = "";
            this.m_panelListePrestations.Size = new System.Drawing.Size(696, 310);
            this.m_extStyle.SetStyleBackColor(this.m_panelListePrestations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListePrestations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelListePrestations.TabIndex = 0;
            this.m_panelListePrestations.TrierAuClicSurEnteteColonne = true;
            // 
            // m_PanelPrestations
            // 
            this.m_PanelPrestations.AllowArbre = true;
            this.m_PanelPrestations.AllowCustomisation = true;
            this.m_PanelPrestations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_PanelPrestations.BoutonAjouterVisible = false;
            this.m_PanelPrestations.BoutonExporterVisible = false;
            this.m_PanelPrestations.BoutonSupprimerVisible = false;
            glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "Name";
            glColumn1.Propriete = "Libelle";
            glColumn1.Text = "Label|3";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 100;
            this.m_PanelPrestations.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1});
            this.m_PanelPrestations.ContexteUtilisation = "";
            this.m_PanelPrestations.ControlFiltreStandard = null;
            this.m_PanelPrestations.ElementSelectionne = null;
            this.m_PanelPrestations.EnableCustomisation = true;
            this.m_PanelPrestations.FiltreDeBase = null;
            this.m_PanelPrestations.FiltreDeBaseEnAjout = false;
            this.m_PanelPrestations.FiltrePrefere = null;
            this.m_PanelPrestations.FiltreRapide = null;
            this.m_PanelPrestations.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_PanelPrestations, "");
            this.m_PanelPrestations.ListeObjets = null;
            this.m_PanelPrestations.Location = new System.Drawing.Point(3, 3);
            this.m_PanelPrestations.LockEdition = true;
            this.m_extModeEdition.SetModeEdition(this.m_PanelPrestations, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_PanelPrestations.ModeQuickSearch = false;
            this.m_PanelPrestations.ModeSelection = true;
            this.m_PanelPrestations.MultiSelect = false;
            this.m_PanelPrestations.Name = "m_PanelPrestations";
            this.m_PanelPrestations.Navigateur = null;
            this.m_PanelPrestations.ProprieteObjetAEditer = null;
            this.m_PanelPrestations.QuickSearchText = "";
            this.m_PanelPrestations.Size = new System.Drawing.Size(621, 325);
            this.m_extStyle.SetStyleBackColor(this.m_PanelPrestations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_PanelPrestations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_PanelPrestations.TabIndex = 16;
            this.m_PanelPrestations.TrierAuClicSurEnteteColonne = true;
            // 
            // CExtenderFormSitePrestation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.m_PanelPrestations);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CExtenderFormSitePrestation";
            this.Size = new System.Drawing.Size(627, 382);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.data.navigation.CPanelListeSpeedStandard m_panelListePrestations;
        private sc2i.win32.data.navigation.CPanelListeSpeedStandard m_PanelPrestations;
    }
}
