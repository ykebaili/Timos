namespace timos.Reseau
{
    partial class CControleEditionSchemaReseauSimple
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CControleEditionSchemaReseauSimple));
            sc2i.win32.common.CGrilleEditeurObjetGraphique cGrilleEditeurObjetGraphique1 = new sc2i.win32.common.CGrilleEditeurObjetGraphique();
            sc2i.win32.common.CProfilEditeurObjetGraphique cProfilEditeurObjetGraphique1 = new sc2i.win32.common.CProfilEditeurObjetGraphique();
            this.m_tooltipTraductible = new sc2i.win32.common.CToolTipTraductible(this.components);
            this.m_btnModeZoom = new System.Windows.Forms.RadioButton();
            this.m_btnModeSelection = new System.Windows.Forms.RadioButton();
            this.m_panelSchema = new timos.Reseau.CPanelEditionSchemaReseau();
            this.m_panelOutils = new System.Windows.Forms.Panel();
            this.m_panelOutils.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnModeZoom
            // 
            this.m_btnModeZoom.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_btnModeZoom.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnModeZoom.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_btnModeZoom.Image = ((System.Drawing.Image)(resources.GetObject("m_btnModeZoom.Image")));
            this.m_btnModeZoom.Location = new System.Drawing.Point(30, 0);
            this.m_btnModeZoom.Name = "m_btnModeZoom";
            this.m_btnModeZoom.Size = new System.Drawing.Size(30, 30);
            this.m_btnModeZoom.TabIndex = 4;
            this.m_tooltipTraductible.SetToolTip(this.m_btnModeZoom, "Zoom|30393");
            this.m_btnModeZoom.UseVisualStyleBackColor = true;
            this.m_btnModeZoom.CheckedChanged += new System.EventHandler(this.m_btnModeZoom_CheckedChanged);
            // 
            // m_btnModeSelection
            // 
            this.m_btnModeSelection.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_btnModeSelection.Checked = true;
            this.m_btnModeSelection.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnModeSelection.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_btnModeSelection.Image = ((System.Drawing.Image)(resources.GetObject("m_btnModeSelection.Image")));
            this.m_btnModeSelection.Location = new System.Drawing.Point(0, 0);
            this.m_btnModeSelection.Name = "m_btnModeSelection";
            this.m_btnModeSelection.Size = new System.Drawing.Size(30, 30);
            this.m_btnModeSelection.TabIndex = 3;
            this.m_btnModeSelection.TabStop = true;
            this.m_tooltipTraductible.SetToolTip(this.m_btnModeSelection, "Select|30392");
            this.m_btnModeSelection.UseVisualStyleBackColor = true;
            this.m_btnModeSelection.CheckedChanged += new System.EventHandler(this.m_btnModeSelection_CheckedChanged);
            // 
            // m_panelSchema
            // 
            this.m_panelSchema.AllowDrop = true;
            this.m_panelSchema.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.m_panelSchema.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelSchema.Echelle = 1F;
            this.m_panelSchema.Editeur = null;
            this.m_panelSchema.EffetAjoutSuppression = false;
            this.m_panelSchema.EffetFonduMenu = true;
            this.m_panelSchema.EnDeplacement = false;
            this.m_panelSchema.FormesDesPoignees = sc2i.win32.common.EFormePoignee.Carre;
            cGrilleEditeurObjetGraphique1.Couleur = System.Drawing.Color.LightGray;
            cGrilleEditeurObjetGraphique1.HauteurCarreau = 20;
            cGrilleEditeurObjetGraphique1.LargeurCarreau = 20;
            cGrilleEditeurObjetGraphique1.Representation = sc2i.win32.common.ERepresentationGrille.LignesContinues;
            cGrilleEditeurObjetGraphique1.TailleCarreau = new System.Drawing.Size(20, 20);
            this.m_panelSchema.GrilleAlignement = cGrilleEditeurObjetGraphique1;
            this.m_panelSchema.HauteurMinimaleDesObjets = 10;
            this.m_panelSchema.HistorisationActive = true;
            this.m_panelSchema.LargeurMinimaleDesObjets = 10;
            this.m_panelSchema.LienReseauEdite = null;
            this.m_panelSchema.Location = new System.Drawing.Point(0, 30);
            this.m_panelSchema.LockEdition = false;
            this.m_panelSchema.Marge = 10;
            this.m_panelSchema.ModeAffichageGrille = sc2i.win32.common.EModeAffichageGrille.AuDeplacement;
            this.m_panelSchema.ModeEdition = timos.Reseau.EModeEditeurSchema.Selection;
            this.m_panelSchema.ModeRepresentationGrille = sc2i.win32.common.ERepresentationGrille.LignesContinues;
            this.m_panelSchema.ModeSouris = sc2i.win32.common.CPanelEditionObjetGraphique.EModeSouris.Selection;
            this.m_panelSchema.Name = "m_panelSchema";
            this.m_panelSchema.NoClipboard = false;
            this.m_panelSchema.NoDelete = false;
            this.m_panelSchema.NoDoubleClick = false;
            this.m_panelSchema.NombreHistorisation = 10;
            this.m_panelSchema.NoMenu = false;
            this.m_panelSchema.ObjetEdite = null;
            this.m_panelSchema.ObjetSchemaReseau = null;
            this.m_panelSchema.ParametreDynamique = null;
            cProfilEditeurObjetGraphique1.FormeDesPoignees = sc2i.win32.common.EFormePoignee.Carre;
            cProfilEditeurObjetGraphique1.Grille = cGrilleEditeurObjetGraphique1;
            cProfilEditeurObjetGraphique1.HistorisationActive = true;
            cProfilEditeurObjetGraphique1.Marge = 10;
            cProfilEditeurObjetGraphique1.ModeAffichageGrille = sc2i.win32.common.EModeAffichageGrille.AuDeplacement;
            cProfilEditeurObjetGraphique1.NombreHistorisation = 10;
            cProfilEditeurObjetGraphique1.ToujoursAlignerSurLaGrille = false;
            this.m_panelSchema.Profil = cProfilEditeurObjetGraphique1;
            this.m_panelSchema.RefreshSelectionChanged = true;
            this.m_panelSchema.SchemaReseau = null;
            this.m_panelSchema.SelectionVisible = true;
            this.m_panelSchema.Size = new System.Drawing.Size(555, 334);
            this.m_panelSchema.TabIndex = 5;
            this.m_panelSchema.ToujoursAlignerSelonLesControles = true;
            this.m_panelSchema.ToujoursAlignerSurLaGrille = false;
            // 
            // m_panelOutils
            // 
            this.m_panelOutils.Controls.Add(this.m_btnModeZoom);
            this.m_panelOutils.Controls.Add(this.m_btnModeSelection);
            this.m_panelOutils.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelOutils.Location = new System.Drawing.Point(0, 0);
            this.m_panelOutils.Name = "m_panelOutils";
            this.m_panelOutils.Size = new System.Drawing.Size(555, 30);
            this.m_panelOutils.TabIndex = 6;
            // 
            // CControleEditionSchemaReseauSimple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_panelSchema);
            this.Controls.Add(this.m_panelOutils);
            this.Name = "CControleEditionSchemaReseauSimple";
            this.Size = new System.Drawing.Size(555, 364);
            this.m_panelOutils.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.CToolTipTraductible m_tooltipTraductible;
        private System.Windows.Forms.RadioButton m_btnModeZoom;
        private System.Windows.Forms.RadioButton m_btnModeSelection;
        private CPanelEditionSchemaReseau m_panelSchema;
        private System.Windows.Forms.Panel m_panelOutils;
    }
}
