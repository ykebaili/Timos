namespace timos
{
    partial class CWndListeObjetsHierarchiques
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
            sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CWndListeObjetsHierarchiques));
            this.m_panelListeTests = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_panelVueListe = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.m_btnGoNiveau = new System.Windows.Forms.Button();
            this.m_numUpNiveau = new sc2i.win32.common.C2iNumericUpDown();
            this.m_panelArbre = new System.Windows.Forms.Panel();
            this.m_btnSupprimer = new sc2i.win32.common.CWndLinkStd();
            this.m_btnDetail = new sc2i.win32.common.CWndLinkStd();
            this.m_btnAjouter = new sc2i.win32.common.CWndLinkStd();
            this.m_arbre = new System.Windows.Forms.TreeView();
            this.m_chkVueArbre = new System.Windows.Forms.RadioButton();
            this.m_chkVueListe = new System.Windows.Forms.RadioButton();
            this.m_panelVueListe.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_numUpNiveau)).BeginInit();
            this.m_panelArbre.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelListeTests
            // 
            this.m_panelListeTests.AllowArbre = true;
            glColumn2.ActiveControlItems = null;
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
            glColumn2.Width = 500;
            this.m_panelListeTests.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn2});
            this.m_panelListeTests.ContexteUtilisation = "";
            this.m_panelListeTests.ControlFiltreStandard = null;
            this.m_panelListeTests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelListeTests.EnableCustomisation = true;
            this.m_panelListeTests.FiltreDeBase = null;
            this.m_panelListeTests.FiltreDeBaseEnAjout = false;
            this.m_panelListeTests.FiltrePrefere = null;
            this.m_panelListeTests.FiltreRapide = null;
            this.m_panelListeTests.ListeObjets = null;
            this.m_panelListeTests.Location = new System.Drawing.Point(0, 0);
            this.m_panelListeTests.ModeQuickSearch = false;
            this.m_panelListeTests.ModeSelection = false;
            this.m_panelListeTests.MultiSelect = true;
            this.m_panelListeTests.Name = "m_panelListeTests";
            this.m_panelListeTests.Navigateur = null;
            this.m_panelListeTests.ProprieteObjetAEditer = null;
            this.m_panelListeTests.QuickSearchText = "";
            this.m_panelListeTests.Size = new System.Drawing.Size(609, 245);
            this.m_panelListeTests.TabIndex = 17;
            // 
            // m_panelVueListe
            // 
            this.m_panelVueListe.Controls.Add(this.panel1);
            this.m_panelVueListe.Controls.Add(this.m_panelListeTests);
            this.m_panelVueListe.Location = new System.Drawing.Point(80, 47);
            this.m_panelVueListe.Name = "m_panelVueListe";
            this.m_panelVueListe.Size = new System.Drawing.Size(609, 245);
            this.m_panelVueListe.TabIndex = 18;
            this.m_panelVueListe.Paint += new System.Windows.Forms.PaintEventHandler(this.m_panelVueListe_Paint);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.m_btnGoNiveau);
            this.panel1.Controls.Add(this.m_numUpNiveau);
            this.panel1.Location = new System.Drawing.Point(358, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(251, 21);
            this.panel1.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Display until the level|823";
            // 
            // m_btnGoNiveau
            // 
            this.m_btnGoNiveau.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_btnGoNiveau.Location = new System.Drawing.Point(217, 0);
            this.m_btnGoNiveau.Name = "m_btnGoNiveau";
            this.m_btnGoNiveau.Size = new System.Drawing.Size(31, 21);
            this.m_btnGoNiveau.TabIndex = 22;
            this.m_btnGoNiveau.Text = "Go|13";
            this.m_btnGoNiveau.UseVisualStyleBackColor = true;
            this.m_btnGoNiveau.Click += new System.EventHandler(this.m_btnGoNiveau_Click);
            // 
            // m_numUpNiveau
            // 
            this.m_numUpNiveau.DoubleValue = 1;
            this.m_numUpNiveau.IntValue = 1;
            this.m_numUpNiveau.Location = new System.Drawing.Point(152, 0);
            this.m_numUpNiveau.LockEdition = false;
            this.m_numUpNiveau.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.m_numUpNiveau.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_numUpNiveau.Name = "m_numUpNiveau";
            this.m_numUpNiveau.Size = new System.Drawing.Size(59, 20);
            this.m_numUpNiveau.TabIndex = 21;
            this.m_numUpNiveau.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_numUpNiveau.ThousandsSeparator = true;
            this.m_numUpNiveau.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // m_panelArbre
            // 
            this.m_panelArbre.Controls.Add(this.m_btnSupprimer);
            this.m_panelArbre.Controls.Add(this.m_btnDetail);
            this.m_panelArbre.Controls.Add(this.m_btnAjouter);
            this.m_panelArbre.Controls.Add(this.m_arbre);
            this.m_panelArbre.Location = new System.Drawing.Point(13, 142);
            this.m_panelArbre.Name = "m_panelArbre";
            this.m_panelArbre.Size = new System.Drawing.Size(534, 284);
            this.m_panelArbre.TabIndex = 19;
            // 
            // m_btnSupprimer
            // 
            this.m_btnSupprimer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnSupprimer.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_btnSupprimer.Location = new System.Drawing.Point(226, 15);
            this.m_btnSupprimer.Name = "m_btnSupprimer";
            this.m_btnSupprimer.Size = new System.Drawing.Size(75, 16);
            this.m_btnSupprimer.TabIndex = 3;
            this.m_btnSupprimer.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_btnSupprimer.LinkClicked += new System.EventHandler(this.m_btnSupprimer_LinkClicked);
            // 
            // m_btnDetail
            // 
            this.m_btnDetail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnDetail.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_btnDetail.Location = new System.Drawing.Point(160, 15);
            this.m_btnDetail.Name = "m_btnDetail";
            this.m_btnDetail.Size = new System.Drawing.Size(75, 16);
            this.m_btnDetail.TabIndex = 2;
            this.m_btnDetail.TypeLien = sc2i.win32.common.TypeLinkStd.Modification;
            this.m_btnDetail.LinkClicked += new System.EventHandler(this.m_btnDetail_LinkClicked);
            // 
            // m_btnAjouter
            // 
            this.m_btnAjouter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnAjouter.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_btnAjouter.Location = new System.Drawing.Point(95, 15);
            this.m_btnAjouter.Name = "m_btnAjouter";
            this.m_btnAjouter.Size = new System.Drawing.Size(75, 16);
            this.m_btnAjouter.TabIndex = 1;
            this.m_btnAjouter.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_btnAjouter.LinkClicked += new System.EventHandler(this.m_btnAjouter_LinkClicked);
            // 
            // m_arbre
            // 
            this.m_arbre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_arbre.HideSelection = false;
            this.m_arbre.Location = new System.Drawing.Point(3, 37);
            this.m_arbre.Name = "m_arbre";
            this.m_arbre.Size = new System.Drawing.Size(528, 248);
            this.m_arbre.TabIndex = 0;
            this.m_arbre.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.m_arbre_BeforeExpand);
            this.m_arbre.DoubleClick += new System.EventHandler(this.m_arbre_DoubleClick);
            this.m_arbre.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_arbre_AfterSelect);
            // 
            // m_chkVueArbre
            // 
            this.m_chkVueArbre.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_chkVueArbre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.m_chkVueArbre.Image = ((System.Drawing.Image)(resources.GetObject("m_chkVueArbre.Image")));
            this.m_chkVueArbre.Location = new System.Drawing.Point(0, 0);
            this.m_chkVueArbre.Name = "m_chkVueArbre";
            this.m_chkVueArbre.Size = new System.Drawing.Size(24, 24);
            this.m_chkVueArbre.TabIndex = 3;
            this.m_chkVueArbre.UseVisualStyleBackColor = false;
            this.m_chkVueArbre.CheckedChanged += new System.EventHandler(this.m_chkVueArbre_CheckedChanged);
            // 
            // m_chkVueListe
            // 
            this.m_chkVueListe.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_chkVueListe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.m_chkVueListe.Image = ((System.Drawing.Image)(resources.GetObject("m_chkVueListe.Image")));
            this.m_chkVueListe.Location = new System.Drawing.Point(30, 0);
            this.m_chkVueListe.Name = "m_chkVueListe";
            this.m_chkVueListe.Size = new System.Drawing.Size(24, 24);
            this.m_chkVueListe.TabIndex = 0;
            this.m_chkVueListe.UseVisualStyleBackColor = false;
            this.m_chkVueListe.CheckedChanged += new System.EventHandler(this.m_chkVueListe_CheckedChanged);
            // 
            // CWndListeObjetsHierarchiques
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.m_panelArbre);
            this.Controls.Add(this.m_chkVueArbre);
            this.Controls.Add(this.m_chkVueListe);
            this.Controls.Add(this.m_panelVueListe);
            this.Name = "CWndListeObjetsHierarchiques";
            this.Size = new System.Drawing.Size(710, 457);
            this.m_panelVueListe.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_numUpNiveau)).EndInit();
            this.m_panelArbre.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.data.navigation.CPanelListeSpeedStandard m_panelListeTests;
        private System.Windows.Forms.Panel m_panelVueListe;
        private System.Windows.Forms.Button m_btnGoNiveau;
        private sc2i.win32.common.C2iNumericUpDown m_numUpNiveau;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel m_panelArbre;
        private System.Windows.Forms.TreeView m_arbre;
        private sc2i.win32.common.CWndLinkStd m_btnSupprimer;
        private sc2i.win32.common.CWndLinkStd m_btnDetail;
        private sc2i.win32.common.CWndLinkStd m_btnAjouter;
        private System.Windows.Forms.RadioButton m_chkVueListe;
        private System.Windows.Forms.RadioButton m_chkVueArbre;
    }
}
