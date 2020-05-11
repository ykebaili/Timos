namespace timos
{
    partial class CFormSelectionModeleEtiquette
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormSelectionModeleEtiquette));
            this.m_panelListeModeleEtiquettes = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_btnAnnuler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_panelListeModeleEtiquettes
            // 
            this.m_panelListeModeleEtiquettes.AllowArbre = true;
            this.m_panelListeModeleEtiquettes.AllowCustomisation = true;
            this.m_panelListeModeleEtiquettes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelListeModeleEtiquettes.BoutonAjouterVisible = false;
            this.m_panelListeModeleEtiquettes.BoutonExporterVisible = false;
            this.m_panelListeModeleEtiquettes.BoutonFiltrerVisible = false;
            this.m_panelListeModeleEtiquettes.BoutonModifierVisible = false;
            this.m_panelListeModeleEtiquettes.BoutonSupprimerVisible = false;
            glColumn1.ActiveControlItems = null;
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
            this.m_panelListeModeleEtiquettes.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1});
            this.m_panelListeModeleEtiquettes.ContexteUtilisation = "";
            this.m_panelListeModeleEtiquettes.ControlFiltreStandard = null;
            this.m_panelListeModeleEtiquettes.ElementSelectionne = null;
            this.m_panelListeModeleEtiquettes.EnableCustomisation = true;
            this.m_panelListeModeleEtiquettes.FiltreDeBase = null;
            this.m_panelListeModeleEtiquettes.FiltreDeBaseEnAjout = false;
            this.m_panelListeModeleEtiquettes.FiltrePrefere = null;
            this.m_panelListeModeleEtiquettes.FiltreRapide = null;
            this.m_panelListeModeleEtiquettes.ListeObjets = null;
            this.m_panelListeModeleEtiquettes.Location = new System.Drawing.Point(-1, 12);
            this.m_panelListeModeleEtiquettes.LockEdition = true;
            this.m_panelListeModeleEtiquettes.ModeQuickSearch = false;
            this.m_panelListeModeleEtiquettes.ModeSelection = false;
            this.m_panelListeModeleEtiquettes.MultiSelect = false;
            this.m_panelListeModeleEtiquettes.Name = "m_panelListeModeleEtiquettes";
            this.m_panelListeModeleEtiquettes.Navigateur = null;
            this.m_panelListeModeleEtiquettes.ProprieteObjetAEditer = null;
            this.m_panelListeModeleEtiquettes.QuickSearchText = "";
            this.m_panelListeModeleEtiquettes.Size = new System.Drawing.Size(728, 356);
            this.m_panelListeModeleEtiquettes.TabIndex = 0;
            this.m_panelListeModeleEtiquettes.TrierAuClicSurEnteteColonne = true;
            // 
            // m_btnOk
            // 
            this.m_btnOk.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnOk.ForeColor = System.Drawing.Color.White;
            this.m_btnOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btnOk.Image")));
            this.m_btnOk.Location = new System.Drawing.Point(294, 395);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(40, 40);
            this.m_btnOk.TabIndex = 4017;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnAnnuler.ForeColor = System.Drawing.Color.White;
            this.m_btnAnnuler.Image = ((System.Drawing.Image)(resources.GetObject("m_btnAnnuler.Image")));
            this.m_btnAnnuler.Location = new System.Drawing.Point(364, 395);
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(40, 40);
            this.m_btnAnnuler.TabIndex = 4018;
            this.m_btnAnnuler.Click += new System.EventHandler(this.m_btnAnnuler_Click);
            // 
            // CFormSelectionModeleEtiquette
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(725, 447);
            this.Controls.Add(this.m_btnAnnuler);
            this.Controls.Add(this.m_btnOk);
            this.Controls.Add(this.m_panelListeModeleEtiquettes);
            this.Name = "CFormSelectionModeleEtiquette";
            this.Text = "Network label models|30405";
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.data.navigation.CPanelListeSpeedStandard m_panelListeModeleEtiquettes;
        private System.Windows.Forms.Button m_btnOk;
        private System.Windows.Forms.Button m_btnAnnuler;
    }
}