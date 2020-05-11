namespace timos
{
    partial class CPanelEditRelationTypeContrainteTypeRessource
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
            this.m_listeRelations = new sc2i.win32.common.ListViewAutoFilled();
            this.columnLibelle = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_panelElement = new System.Windows.Forms.Panel();
            this.m_lnkSupprimer = new sc2i.win32.common.CWndLinkStd();
            this.m_extLinkField = new sc2i.win32.common.CExtLinkField();
            this.m_GestionnaireEditionRelation = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.SuspendLayout();
            // 
            // m_listeRelations
            // 
            this.m_listeRelations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_listeRelations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnLibelle});
            this.m_listeRelations.EnableCustomisation = true;
            this.m_listeRelations.FullRowSelect = true;
            this.m_listeRelations.HideSelection = false;
            this.m_extLinkField.SetLinkField(this.m_listeRelations, "");
            this.m_listeRelations.Location = new System.Drawing.Point(0, 0);
            this.m_listeRelations.MultiSelect = false;
            this.m_listeRelations.Name = "m_listeRelations";
            this.m_listeRelations.Size = new System.Drawing.Size(378, 259);
            this.m_listeRelations.TabIndex = 6;
            this.m_listeRelations.UseCompatibleStateImageBehavior = false;
            this.m_listeRelations.View = System.Windows.Forms.View.Details;
            // 
            // columnLibelle
            // 
            this.columnLibelle.Field = "";
            this.columnLibelle.PrecisionWidth = 0;
            this.columnLibelle.ProportionnalSize = false;
            this.columnLibelle.Text = "Label|50";
            this.columnLibelle.Visible = true;
            this.columnLibelle.Width = 334;
            // 
            // m_panelElement
            // 
            this.m_panelElement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_panelElement, "");
            this.m_panelElement.Location = new System.Drawing.Point(384, 0);
            this.m_panelElement.Name = "m_panelElement";
            this.m_panelElement.Size = new System.Drawing.Size(198, 259);
            this.m_panelElement.TabIndex = 7;
            // 
            // m_lnkSupprimer
            // 
            this.m_lnkSupprimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkSupprimer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkSupprimer.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkSupprimer, "");
            this.m_lnkSupprimer.Location = new System.Drawing.Point(0, 262);
            this.m_lnkSupprimer.Name = "m_lnkSupprimer";
            this.m_lnkSupprimer.Size = new System.Drawing.Size(104, 21);
            this.m_lnkSupprimer.TabIndex = 8;
            this.m_lnkSupprimer.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkSupprimer.LinkClicked += new System.EventHandler(this.m_lnkSupprimer_LinkClicked);
            // 
            // m_GestionnaireEditionRelation
            // 
            this.m_GestionnaireEditionRelation.ListeAssociee = this.m_listeRelations;
            this.m_GestionnaireEditionRelation.ObjetEdite = null;
            this.m_GestionnaireEditionRelation.InitChamp += new sc2i.data.ObjetDonneeResultEventHandler(this.m_GestionnaireEditionRelation_InitChamp);
            this.m_GestionnaireEditionRelation.MAJ_Champs += new sc2i.data.ObjetDonneeResultEventHandler(this.m_GestionnaireEditionRelation_MAJ_Champs);
            // 
            // CPanelEditRelationTypeContrainteTypeRessource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_lnkSupprimer);
            this.Controls.Add(this.m_panelElement);
            this.Controls.Add(this.m_listeRelations);
            this.m_extLinkField.SetLinkField(this, "");
            this.Name = "CPanelEditRelationTypeContrainteTypeRessource";
            this.Size = new System.Drawing.Size(586, 289);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.ListViewAutoFilled m_listeRelations;
        private sc2i.win32.common.ListViewAutoFilledColumn columnLibelle;
        private System.Windows.Forms.Panel m_panelElement;
        private sc2i.win32.common.CWndLinkStd m_lnkSupprimer;
        private sc2i.win32.common.CExtLinkField m_extLinkField;
        private sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee m_GestionnaireEditionRelation;
    }
}
