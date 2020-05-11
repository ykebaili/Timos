namespace timos
{
    partial class CFormSelectionNouveauLien
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
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormSelectionNouveauLien));
            this.m_panelListeLiensExistants = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_btnExistant = new System.Windows.Forms.RadioButton();
            this.m_btnCreerNouveau = new System.Windows.Forms.RadioButton();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_btnAnnuler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_panelListeLiensExistants
            // 
            this.m_panelListeLiensExistants.AllowArbre = true;
            this.m_panelListeLiensExistants.AllowCustomisation = true;
            this.m_panelListeLiensExistants.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelListeLiensExistants.BoutonAjouterVisible = false;
            this.m_panelListeLiensExistants.BoutonExporterVisible = false;
            this.m_panelListeLiensExistants.BoutonFiltrerVisible = false;
            this.m_panelListeLiensExistants.BoutonModifierVisible = false;
            this.m_panelListeLiensExistants.BoutonSupprimerVisible = false;
            glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "Label";
            glColumn1.Propriete = "Libelle";
            glColumn1.Text = "Label|50";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 100;
            this.m_panelListeLiensExistants.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1});
            this.m_panelListeLiensExistants.ContexteUtilisation = "";
            this.m_panelListeLiensExistants.ControlFiltreStandard = null;
            this.m_panelListeLiensExistants.ElementSelectionne = null;
            this.m_panelListeLiensExistants.EnableCustomisation = true;
            this.m_panelListeLiensExistants.FiltreDeBase = null;
            this.m_panelListeLiensExistants.FiltreDeBaseEnAjout = false;
            this.m_panelListeLiensExistants.FiltrePrefere = null;
            this.m_panelListeLiensExistants.FiltreRapide = null;
            this.m_panelListeLiensExistants.ListeObjets = null;
            this.m_panelListeLiensExistants.Location = new System.Drawing.Point(-1, 70);
            this.m_panelListeLiensExistants.LockEdition = true;
            this.m_panelListeLiensExistants.ModeQuickSearch = false;
            this.m_panelListeLiensExistants.ModeSelection = false;
            this.m_panelListeLiensExistants.MultiSelect = false;
            this.m_panelListeLiensExistants.Name = "m_panelListeLiensExistants";
            this.m_panelListeLiensExistants.Navigateur = null;
            this.m_panelListeLiensExistants.ProprieteObjetAEditer = null;
            this.m_panelListeLiensExistants.QuickSearchText = "";
            this.m_panelListeLiensExistants.Size = new System.Drawing.Size(714, 298);
            this.m_panelListeLiensExistants.TabIndex = 0;
            this.m_panelListeLiensExistants.TrierAuClicSurEnteteColonne = true;
            this.m_panelListeLiensExistants.OnObjetDoubleClick += new System.EventHandler(this.m_panelListeLiensExistants_OnObjetDoubleClick);
            // 
            // m_btnExistant
            // 
            this.m_btnExistant.AutoSize = true;
            this.m_btnExistant.Checked = true;
            this.m_btnExistant.Location = new System.Drawing.Point(29, 36);
            this.m_btnExistant.Name = "m_btnExistant";
            this.m_btnExistant.Size = new System.Drawing.Size(159, 17);
            this.m_btnExistant.TabIndex = 1;
            this.m_btnExistant.TabStop = true;
            this.m_btnExistant.Text = "Select an existing link|30402";
            this.m_btnExistant.UseVisualStyleBackColor = true;
            this.m_btnExistant.CheckedChanged += new System.EventHandler(this.m_btnExistant_CheckedChanged);
            // 
            // m_btnCreerNouveau
            // 
            this.m_btnCreerNouveau.AutoSize = true;
            this.m_btnCreerNouveau.Location = new System.Drawing.Point(29, 404);
            this.m_btnCreerNouveau.Name = "m_btnCreerNouveau";
            this.m_btnCreerNouveau.Size = new System.Drawing.Size(139, 17);
            this.m_btnCreerNouveau.TabIndex = 2;
            this.m_btnCreerNouveau.TabStop = true;
            this.m_btnCreerNouveau.Text = "Create a new link|30403";
            this.m_btnCreerNouveau.UseVisualStyleBackColor = true;
            this.m_btnCreerNouveau.CheckedChanged += new System.EventHandler(this.m_btnCreerNouveau_CheckedChanged);
            // 
            // m_btnOk
            // 
            this.m_btnOk.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnOk.ForeColor = System.Drawing.Color.White;
            this.m_btnOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btnOk.Image")));
            this.m_btnOk.Location = new System.Drawing.Point(308, 494);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(40, 40);
            this.m_btnOk.TabIndex = 4016;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnAnnuler.ForeColor = System.Drawing.Color.White;
            this.m_btnAnnuler.Image = ((System.Drawing.Image)(resources.GetObject("m_btnAnnuler.Image")));
            this.m_btnAnnuler.Location = new System.Drawing.Point(366, 494);
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(40, 40);
            this.m_btnAnnuler.TabIndex = 4017;
            this.m_btnAnnuler.Click += new System.EventHandler(this.m_btnAnnuler_Click);
            // 
            // CFormSelectionNouveauLien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(725, 546);
            this.Controls.Add(this.m_btnOk);
            this.Controls.Add(this.m_btnAnnuler);
            this.Controls.Add(this.m_btnCreerNouveau);
            this.Controls.Add(this.m_btnExistant);
            this.Controls.Add(this.m_panelListeLiensExistants);
            this.Name = "CFormSelectionNouveauLien";
            this.Text = "Add a new link|30401";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private sc2i.win32.data.navigation.CPanelListeSpeedStandard m_panelListeLiensExistants;
        private System.Windows.Forms.RadioButton m_btnExistant;
        private System.Windows.Forms.RadioButton m_btnCreerNouveau;
        private System.Windows.Forms.Button m_btnOk;
        private System.Windows.Forms.Button m_btnAnnuler;
    }
}