namespace timos.Reseau
{
    partial class CPanelEditionSchemaReseau
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        /// 


        private System.Windows.Forms.ToolStripMenuItem m_mnu_itm_properties = null;
        private System.Windows.Forms.ToolStripMenuItem m_mnu_itm_Cablage = null;
        private System.Windows.Forms.ToolStripMenuItem m_mnu_itm_edit_points = null;
        private System.Windows.Forms.ToolStripMenuItem m_mnu_itm_action = null;
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
            this.SuspendLayout();
            // 
            // CPanelEditionSchemaReseau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            cGrilleEditeurObjetGraphique2.Couleur = System.Drawing.Color.LightGray;
            cGrilleEditeurObjetGraphique2.HauteurCarreau = 20;
            cGrilleEditeurObjetGraphique2.LargeurCarreau = 20;
            cGrilleEditeurObjetGraphique2.Representation = sc2i.win32.common.ERepresentationGrille.LignesContinues;
            cGrilleEditeurObjetGraphique2.TailleCarreau = new System.Drawing.Size(20, 20);
            this.GrilleAlignement = cGrilleEditeurObjetGraphique2;
            this.ModeRepresentationGrille = sc2i.win32.common.ERepresentationGrille.LignesContinues;
            this.Name = "CPanelEditionSchemaReseau";
            cProfilEditeurObjetGraphique2.FormeDesPoignees = sc2i.win32.common.EFormePoignee.Carre;
            cProfilEditeurObjetGraphique2.Grille = cGrilleEditeurObjetGraphique2;
            cProfilEditeurObjetGraphique2.HistorisationActive = true;
            cProfilEditeurObjetGraphique2.Marge = 10;
            cProfilEditeurObjetGraphique2.ModeAffichageGrille = sc2i.win32.common.EModeAffichageGrille.AuDeplacement;
            cProfilEditeurObjetGraphique2.NombreHistorisation = 10;
            cProfilEditeurObjetGraphique2.ToujoursAlignerSurLaGrille = false;
            this.Profil = cProfilEditeurObjetGraphique2;
            this.Size = new System.Drawing.Size(582, 350);
            this.ToujoursAlignerSurLaGrille = false;
            this.DoubleClick += new System.EventHandler(this.CPanelEditionSchemaReseau_DoubleClick);
            this.SelectionChanged += new System.EventHandler(this.CPanelEditionSchemaReseau_SelectionChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CPanelEditionSchemaReseau_KeyDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CPanelEditionSchemaReseau_MouseMove);
            this.BeforeDeleteElement += new sc2i.win32.common.EventHandlerPanelEditionGraphiqueSuppression(this.CPanelEditionSchemaReseau_BeforeDeleteElement);
            this.AfterRemoveObjetGraphique += new System.EventHandler(this.CPanelEditionSchemaReseau_AfterRemoveObjetGraphique);
            this.AfterAddElements += new sc2i.win32.common.EventHandlerPanelEditionGraphiqueSuppression(this.CPanelEditionSchemaReseau_AfterAddElements);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
