namespace timos.commandes
{
    partial class CControleEditeLotValorisation
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
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.c2iDateTimePicker1 = new sc2i.win32.common.C2iDateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_tabPages = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageValorisations = new Crownwood.Magic.Controls.TabPage();
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.m_extLinkField = new sc2i.win32.common.CExtLinkField();
            this.m_ctrlValorisations = new timos.commandes.CControleEditeValorisations();
            this.m_panelLignes = new sc2i.win32.common.C2iPanel(this.components);
            this.m_panelTop = new sc2i.win32.common.C2iPanel(this.components);
            this.c2iPanelOmbre4.SuspendLayout();
            this.m_tabPages.SuspendLayout();
            this.m_pageValorisations.SuspendLayout();
            this.m_ctrlValorisations.SuspendLayout();
            this.SuspendLayout();
            // 
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.c2iDateTimePicker1);
            this.c2iPanelOmbre4.Controls.Add(this.label1);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.Controls.Add(this.label2);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iPanelOmbre4, false);
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(3, 3);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(503, 78);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 1;
            // 
            // c2iDateTimePicker1
            // 
            this.c2iDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.m_extLinkField.SetLinkField(this.c2iDateTimePicker1, "DateLot");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iDateTimePicker1, true);
            this.c2iDateTimePicker1.Location = new System.Drawing.Point(132, 35);
            this.c2iDateTimePicker1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iDateTimePicker1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.c2iDateTimePicker1.Name = "c2iDateTimePicker1";
            this.c2iDateTimePicker1.Size = new System.Drawing.Size(87, 20);
            this.m_extStyle.SetStyleBackColor(this.c2iDateTimePicker1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iDateTimePicker1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iDateTimePicker1.TabIndex = 4003;
            this.c2iDateTimePicker1.Value = new System.DateTime(2011, 9, 19, 15, 50, 26, 718);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label1, false);
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4002;
            this.label1.Text = "Label|50";
            // 
            // m_txtLibelle
            // 
            this.m_txtLibelle.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtLibelle, true);
            this.m_txtLibelle.Location = new System.Drawing.Point(132, 8);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(280, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Libelle]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label2, false);
            this.label2.Location = new System.Drawing.Point(16, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4002;
            this.label2.Text = "Date|20429";
            // 
            // m_tabPages
            // 
            this.m_tabPages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_tabPages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_tabPages.BoldSelectedPage = true;
            this.m_tabPages.ControlBottomOffset = 16;
            this.m_tabPages.ControlRightOffset = 16;
            this.m_tabPages.ForeColor = System.Drawing.Color.Black;
            this.m_tabPages.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_tabPages, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_tabPages, false);
            this.m_tabPages.Location = new System.Drawing.Point(3, 75);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabPages, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_tabPages.Name = "m_tabPages";
            this.m_tabPages.Ombre = true;
            this.m_tabPages.PositionTop = true;
            this.m_tabPages.SelectedIndex = 0;
            this.m_tabPages.SelectedTab = this.m_pageValorisations;
            this.m_tabPages.Size = new System.Drawing.Size(610, 286);
            this.m_extStyle.SetStyleBackColor(this.m_tabPages, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabPages, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabPages.TabIndex = 4005;
            this.m_tabPages.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageValorisations});
            this.m_tabPages.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageValorisations
            // 
            this.m_pageValorisations.Controls.Add(this.m_ctrlValorisations);
            this.m_extLinkField.SetLinkField(this.m_pageValorisations, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageValorisations, false);
            this.m_pageValorisations.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageValorisations, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_pageValorisations.Name = "m_pageValorisations";
            this.m_pageValorisations.Size = new System.Drawing.Size(594, 245);
            this.m_extStyle.SetStyleBackColor(this.m_pageValorisations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageValorisations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageValorisations.TabIndex = 10;
            this.m_pageValorisations.Title = "Valuations|20428";
            // 
            // m_extLinkField
            // 
            this.m_extLinkField.SourceTypeString = "";
            // 
            // m_ctrlValorisations
            // 
            this.m_ctrlValorisations.Controls.Add(this.m_panelLignes);
            this.m_ctrlValorisations.Controls.Add(this.m_panelTop);
            this.m_ctrlValorisations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_ctrlValorisations, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_ctrlValorisations, false);
            this.m_ctrlValorisations.Location = new System.Drawing.Point(0, 0);
            this.m_ctrlValorisations.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_ctrlValorisations, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_ctrlValorisations.Name = "m_ctrlValorisations";
            this.m_ctrlValorisations.Size = new System.Drawing.Size(594, 245);
            this.m_extStyle.SetStyleBackColor(this.m_ctrlValorisations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_ctrlValorisations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ctrlValorisations.TabIndex = 0;
            // 
            // m_panelLignes
            // 
            this.m_panelLignes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelLignes, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelLignes, false);
            this.m_panelLignes.Location = new System.Drawing.Point(0, 31);
            this.m_panelLignes.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelLignes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelLignes.Name = "m_panelLignes";
            this.m_panelLignes.Size = new System.Drawing.Size(594, 214);
            this.m_extStyle.SetStyleBackColor(this.m_panelLignes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelLignes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelLignes.TabIndex = 1;
            // 
            // m_panelTop
            // 
            this.m_panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.m_panelTop, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelTop, false);
            this.m_panelTop.Location = new System.Drawing.Point(0, 0);
            this.m_panelTop.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelTop, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelTop.Name = "m_panelTop";
            this.m_panelTop.Size = new System.Drawing.Size(594, 31);
            this.m_extStyle.SetStyleBackColor(this.m_panelTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelTop.TabIndex = 0;
            // 
            // CControleEditeLotValorisation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_tabPages);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleEditeLotValorisation";
            this.Size = new System.Drawing.Size(613, 361);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondFenetre);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTexteFenetre);
            this.c2iPanelOmbre4.ResumeLayout(false);
            this.c2iPanelOmbre4.PerformLayout();
            this.m_tabPages.ResumeLayout(false);
            this.m_tabPages.PerformLayout();
            this.m_pageValorisations.ResumeLayout(false);
            this.m_ctrlValorisations.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
        private sc2i.win32.common.CExtStyle m_extStyle;
        private sc2i.win32.common.CExtLinkField m_extLinkField;
        private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
        private sc2i.win32.common.C2iDateTimePicker c2iDateTimePicker1;
        private System.Windows.Forms.Label label1;
        private sc2i.win32.common.C2iTextBox m_txtLibelle;
        private System.Windows.Forms.Label label2;
        private sc2i.win32.common.C2iTabControl m_tabPages;
        private Crownwood.Magic.Controls.TabPage m_pageValorisations;
        private CControleEditeValorisations m_ctrlValorisations;
        private sc2i.win32.common.C2iPanel m_panelLignes;
        private sc2i.win32.common.C2iPanel m_panelTop;
    }
}
