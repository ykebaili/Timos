namespace timos.process.workflow
{
    partial class CPanelDessineWorkflowEnCours
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
            sc2i.win32.common.CGrilleEditeurObjetGraphique cGrilleEditeurObjetGraphique2 = new sc2i.win32.common.CGrilleEditeurObjetGraphique();
            sc2i.win32.common.CProfilEditeurObjetGraphique cProfilEditeurObjetGraphique2 = new sc2i.win32.common.CProfilEditeurObjetGraphique();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_btnUpLevel = new System.Windows.Forms.Button();
            this.m_trackZoom = new System.Windows.Forms.TrackBar();
            this.m_lblZoom = new System.Windows.Forms.Label();
            this.m_panelWorkflow = new timos.process.workflow.CControleDessinWorkflowEnCours();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_trackZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_btnUpLevel);
            this.panel1.Controls.Add(this.m_trackZoom);
            this.panel1.Controls.Add(this.m_lblZoom);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 325);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(548, 35);
            this.panel1.TabIndex = 0;
            // 
            // m_btnUpLevel
            // 
            this.m_btnUpLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnUpLevel.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnUpLevel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnUpLevel.Image = global::timos.Properties.Resources._1346547808_arrow_up;
            this.m_btnUpLevel.Location = new System.Drawing.Point(0, 0);
            this.m_btnUpLevel.Name = "m_btnUpLevel";
            this.m_btnUpLevel.Size = new System.Drawing.Size(45, 35);
            this.m_btnUpLevel.TabIndex = 3;
            this.m_btnUpLevel.UseVisualStyleBackColor = true;
            this.m_btnUpLevel.Click += new System.EventHandler(this.m_btnUpLevel_Click);
            // 
            // m_trackZoom
            // 
            this.m_trackZoom.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_trackZoom.Location = new System.Drawing.Point(415, 0);
            this.m_trackZoom.Maximum = 30;
            this.m_trackZoom.Minimum = 1;
            this.m_trackZoom.Name = "m_trackZoom";
            this.m_trackZoom.Size = new System.Drawing.Size(104, 35);
            this.m_trackZoom.TabIndex = 1;
            this.m_trackZoom.Value = 1;
            this.m_trackZoom.ValueChanged += new System.EventHandler(this.m_trackZoom_ValueChanged);
            // 
            // m_lblZoom
            // 
            this.m_lblZoom.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_lblZoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblZoom.Location = new System.Drawing.Point(519, 0);
            this.m_lblZoom.Name = "m_lblZoom";
            this.m_lblZoom.Size = new System.Drawing.Size(29, 35);
            this.m_lblZoom.TabIndex = 2;
            this.m_lblZoom.Text = "x1";
            this.m_lblZoom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_panelWorkflow
            // 
            this.m_panelWorkflow.AllowDrop = true;
            this.m_panelWorkflow.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.m_panelWorkflow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelWorkflow.Echelle = 1F;
            this.m_panelWorkflow.EffetAjoutSuppression = false;
            this.m_panelWorkflow.EffetFonduMenu = true;
            this.m_panelWorkflow.EnDeplacement = false;
            this.m_panelWorkflow.FormesDesPoignees = sc2i.win32.common.EFormePoignee.Carre;
            cGrilleEditeurObjetGraphique2.Couleur = System.Drawing.Color.LightGray;
            cGrilleEditeurObjetGraphique2.HauteurCarreau = 20;
            cGrilleEditeurObjetGraphique2.LargeurCarreau = 20;
            cGrilleEditeurObjetGraphique2.Representation = sc2i.win32.common.ERepresentationGrille.LignesContinues;
            cGrilleEditeurObjetGraphique2.TailleCarreau = new System.Drawing.Size(20, 20);
            this.m_panelWorkflow.GrilleAlignement = cGrilleEditeurObjetGraphique2;
            this.m_panelWorkflow.HauteurMinimaleDesObjets = 10;
            this.m_panelWorkflow.HistorisationActive = true;
            this.m_panelWorkflow.LargeurMinimaleDesObjets = 10;
            this.m_panelWorkflow.Location = new System.Drawing.Point(0, 0);
            this.m_panelWorkflow.LockEdition = true;
            this.m_panelWorkflow.Marge = 10;
            this.m_panelWorkflow.MaxZoom = 6F;
            this.m_panelWorkflow.MinZoom = 0.2F;
            this.m_panelWorkflow.ModeAffichageGrille = sc2i.win32.common.EModeAffichageGrille.AuDeplacement;
            this.m_panelWorkflow.ModeRepresentationGrille = sc2i.win32.common.ERepresentationGrille.LignesContinues;
            this.m_panelWorkflow.ModeSouris = sc2i.win32.common.CPanelEditionObjetGraphique.EModeSouris.Selection;
            this.m_panelWorkflow.ModeSourisCustom = sc2i.win32.process.workflow.CControlEditeWorkflow.EModeSourisCustom.LienWorkflow;
            this.m_panelWorkflow.Name = "m_panelWorkflow";
            this.m_panelWorkflow.NoClipboard = false;
            this.m_panelWorkflow.NoDelete = false;
            this.m_panelWorkflow.NoDoubleClick = false;
            this.m_panelWorkflow.NombreHistorisation = 10;
            this.m_panelWorkflow.NoMenu = false;
            this.m_panelWorkflow.ObjetEdite = null;
            cProfilEditeurObjetGraphique2.FormeDesPoignees = sc2i.win32.common.EFormePoignee.Carre;
            cProfilEditeurObjetGraphique2.Grille = cGrilleEditeurObjetGraphique2;
            cProfilEditeurObjetGraphique2.HistorisationActive = true;
            cProfilEditeurObjetGraphique2.Marge = 10;
            cProfilEditeurObjetGraphique2.ModeAffichageGrille = sc2i.win32.common.EModeAffichageGrille.AuDeplacement;
            cProfilEditeurObjetGraphique2.NombreHistorisation = 10;
            cProfilEditeurObjetGraphique2.ToujoursAlignerSurLaGrille = false;
            this.m_panelWorkflow.Profil = cProfilEditeurObjetGraphique2;
            this.m_panelWorkflow.RefreshSelectionChanged = true;
            this.m_panelWorkflow.SelectionVisible = true;
            this.m_panelWorkflow.Size = new System.Drawing.Size(548, 325);
            this.m_panelWorkflow.TabIndex = 1;
            this.m_panelWorkflow.ToujoursAlignerSelonLesControles = true;
            this.m_panelWorkflow.ToujoursAlignerSurLaGrille = false;
            this.m_panelWorkflow.EchelleChanged += new System.EventHandler(this.m_panelWorkflow_EchelleChanged);
            this.m_panelWorkflow.WorkflowAfficheChanged += new System.EventHandler(this.m_panelWorkflow_WorkflowEditeChanged);
            // 
            // CPanelDessineWorkflowEnCours
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_panelWorkflow);
            this.Controls.Add(this.panel1);
            this.Name = "CPanelDessineWorkflowEnCours";
            this.Size = new System.Drawing.Size(548, 360);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_trackZoom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar m_trackZoom;
        private System.Windows.Forms.Label m_lblZoom;
        private CControleDessinWorkflowEnCours m_panelWorkflow;
        private System.Windows.Forms.Button m_btnUpLevel;
    }
}
