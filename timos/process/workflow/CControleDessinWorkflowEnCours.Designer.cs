namespace timos.process.workflow
{
    partial class CControleDessinWorkflowEnCours
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
            sc2i.win32.common.CGrilleEditeurObjetGraphique cGrilleEditeurObjetGraphique2 = new sc2i.win32.common.CGrilleEditeurObjetGraphique();
            sc2i.win32.common.CProfilEditeurObjetGraphique cProfilEditeurObjetGraphique2 = new sc2i.win32.common.CProfilEditeurObjetGraphique();
            this.m_menuEtapeDessin = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_menuAfficheDetailEtape = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuAfficheDetailWorkflow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_menuEditAffectations = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuSendNotifications = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuStartStep = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuAnnulerEtape = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuEndStep = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuActionEtape = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuCreateStep = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuEtapeDessin.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_menuEtapeDessin
            // 
            this.m_menuEtapeDessin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_menuAfficheDetailEtape,
            this.m_menuAfficheDetailWorkflow,
            this.toolStripMenuItem1,
            this.m_menuEditAffectations,
            this.m_menuSendNotifications,
            this.m_menuCreateStep,
            this.m_menuStartStep,
            this.m_menuAnnulerEtape,
            this.m_menuEndStep,
            this.m_menuActionEtape});
            this.m_menuEtapeDessin.Name = "m_menuEtapeDessin";
            this.m_menuEtapeDessin.Size = new System.Drawing.Size(238, 230);
            this.m_menuEtapeDessin.Opening += new System.ComponentModel.CancelEventHandler(this.m_menuEtapeDessin_Opening);
            // 
            // m_menuAfficheDetailEtape
            // 
            this.m_menuAfficheDetailEtape.Name = "m_menuAfficheDetailEtape";
            this.m_menuAfficheDetailEtape.Size = new System.Drawing.Size(237, 22);
            this.m_menuAfficheDetailEtape.Text = "Show step|20577";
            this.m_menuAfficheDetailEtape.Click += new System.EventHandler(this.m_menuAfficheDetailEtape_Click);
            // 
            // m_menuAfficheDetailWorkflow
            // 
            this.m_menuAfficheDetailWorkflow.Name = "m_menuAfficheDetailWorkflow";
            this.m_menuAfficheDetailWorkflow.Size = new System.Drawing.Size(237, 22);
            this.m_menuAfficheDetailWorkflow.Text = "Show workflow|20578";
            this.m_menuAfficheDetailWorkflow.Click += new System.EventHandler(this.m_menuAfficheDetailWorkflow_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(234, 6);
            // 
            // m_menuEditAffectations
            // 
            this.m_menuEditAffectations.Name = "m_menuEditAffectations";
            this.m_menuEditAffectations.Size = new System.Drawing.Size(237, 22);
            this.m_menuEditAffectations.Text = "Edit assignments|20580";
            this.m_menuEditAffectations.Click += new System.EventHandler(this.m_menuEditAffectations_Click);
            // 
            // m_menuSendNotifications
            // 
            this.m_menuSendNotifications.Name = "m_menuSendNotifications";
            this.m_menuSendNotifications.Size = new System.Drawing.Size(237, 22);
            this.m_menuSendNotifications.Text = "Send notifications|20581";
            this.m_menuSendNotifications.Click += new System.EventHandler(this.m_menuSendNotifications_Click);
            // 
            // m_menuStartStep
            // 
            this.m_menuStartStep.Name = "m_menuStartStep";
            this.m_menuStartStep.Size = new System.Drawing.Size(237, 22);
            this.m_menuStartStep.Text = "Start / Restart|20579";
            this.m_menuStartStep.Click += new System.EventHandler(this.m_menuStartStep_Click);
            // 
            // m_menuAnnulerEtape
            // 
            this.m_menuAnnulerEtape.Name = "m_menuAnnulerEtape";
            this.m_menuAnnulerEtape.Size = new System.Drawing.Size(237, 22);
            this.m_menuAnnulerEtape.Text = "Cancel|20680";
            this.m_menuAnnulerEtape.Click += new System.EventHandler(this.m_menuAnnulerEtape_Click);
            // 
            // m_menuEndStep
            // 
            this.m_menuEndStep.Name = "m_menuEndStep";
            this.m_menuEndStep.Size = new System.Drawing.Size(237, 22);
            this.m_menuEndStep.Text = "End|20831";
            this.m_menuEndStep.Click += new System.EventHandler(this.m_menuEndStep_Click);
            // 
            // m_menuActionEtape
            // 
            this.m_menuActionEtape.Name = "m_menuActionEtape";
            this.m_menuActionEtape.Size = new System.Drawing.Size(237, 22);
            this.m_menuActionEtape.Text = "Action|20832";
            // 
            // m_menuCreateStep
            // 
            this.m_menuCreateStep.Name = "m_menuCreateStep";
            this.m_menuCreateStep.Size = new System.Drawing.Size(237, 22);
            this.m_menuCreateStep.Text = "Create step (don\'t start)|20833";
            this.m_menuCreateStep.Click += new System.EventHandler(this.m_menuCreateStep_Click);
            // 
            // CControleDessinWorkflowEnCours
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            cGrilleEditeurObjetGraphique2.Couleur = System.Drawing.Color.LightGray;
            cGrilleEditeurObjetGraphique2.HauteurCarreau = 20;
            cGrilleEditeurObjetGraphique2.LargeurCarreau = 20;
            cGrilleEditeurObjetGraphique2.Representation = sc2i.win32.common.ERepresentationGrille.LignesContinues;
            cGrilleEditeurObjetGraphique2.TailleCarreau = new System.Drawing.Size(20, 20);
            this.GrilleAlignement = cGrilleEditeurObjetGraphique2;
            this.Name = "CControleDessinWorkflowEnCours";
            cProfilEditeurObjetGraphique2.FormeDesPoignees = sc2i.win32.common.EFormePoignee.Carre;
            cProfilEditeurObjetGraphique2.Grille = cGrilleEditeurObjetGraphique2;
            cProfilEditeurObjetGraphique2.HistorisationActive = true;
            cProfilEditeurObjetGraphique2.Marge = 10;
            cProfilEditeurObjetGraphique2.ModeAffichageGrille = sc2i.win32.common.EModeAffichageGrille.AuDeplacement;
            cProfilEditeurObjetGraphique2.NombreHistorisation = 10;
            cProfilEditeurObjetGraphique2.ToujoursAlignerSurLaGrille = false;
            this.Profil = cProfilEditeurObjetGraphique2;
            this.DoubleClicSurElement += new System.EventHandler(this.CControleDessinWorkflowEnCours_DoubleClicSurElement);
            this.m_menuEtapeDessin.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip m_menuEtapeDessin;
        private System.Windows.Forms.ToolStripMenuItem m_menuAfficheDetailEtape;
        private System.Windows.Forms.ToolStripMenuItem m_menuAfficheDetailWorkflow;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem m_menuStartStep;
        private System.Windows.Forms.ToolStripMenuItem m_menuEditAffectations;
        private System.Windows.Forms.ToolStripMenuItem m_menuSendNotifications;
        private System.Windows.Forms.ToolStripMenuItem m_menuAnnulerEtape;
        private System.Windows.Forms.ToolStripMenuItem m_menuEndStep;
        private System.Windows.Forms.ToolStripMenuItem m_menuActionEtape;
        private System.Windows.Forms.ToolStripMenuItem m_menuCreateStep;
    }
}
