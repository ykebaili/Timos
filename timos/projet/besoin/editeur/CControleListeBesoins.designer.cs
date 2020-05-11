namespace timos.projet.besoin
{
    partial class CControleListeBesoins
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CControleListeBesoins));
            this.m_panelTop = new System.Windows.Forms.Panel();
            this.m_picRecalculer = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_btnAddBesoin = new sc2i.win32.common.CWndLinkStd();
            this.label2 = new System.Windows.Forms.Label();
            this.m_picExtraireListe = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_pictureMap = new System.Windows.Forms.PictureBox();
            this.m_panelModes = new System.Windows.Forms.Panel();
            this.m_btnModeSuivi = new System.Windows.Forms.RadioButton();
            this.m_btnModeConception = new System.Windows.Forms.RadioButton();
            this.m_btnModeSansCout = new System.Windows.Forms.RadioButton();
            this.m_picFillBesoin = new System.Windows.Forms.PictureBox();
            this.m_panelResumeElementACout = new timos.projet.besoin.CcontroleResumeElementACout();
            this.m_tooltip = new sc2i.win32.common.CToolTipTraductible(this.components);
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_panelDessin.SuspendLayout();
            this.m_panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_picRecalculer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picExtraireListe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_pictureMap)).BeginInit();
            this.m_panelModes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_picFillBesoin)).BeginInit();
            this.SuspendLayout();
            // 
            // m_panelDessin
            // 
            this.m_panelDessin.Controls.Add(this.m_picFillBesoin);
            this.m_panelDessin.Location = new System.Drawing.Point(0, 45);
            this.m_extModeEdition.SetModeEdition(this.m_panelDessin, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelDessin.Size = new System.Drawing.Size(688, 197);
            // 
            // m_panelTop
            // 
            this.m_panelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panelTop.Controls.Add(this.m_picRecalculer);
            this.m_panelTop.Controls.Add(this.label3);
            this.m_panelTop.Controls.Add(this.m_btnAddBesoin);
            this.m_panelTop.Controls.Add(this.label2);
            this.m_panelTop.Controls.Add(this.m_picExtraireListe);
            this.m_panelTop.Controls.Add(this.label1);
            this.m_panelTop.Controls.Add(this.m_pictureMap);
            this.m_panelTop.Controls.Add(this.m_panelModes);
            this.m_panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelTop.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelTop, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelTop.Name = "m_panelTop";
            this.m_panelTop.Size = new System.Drawing.Size(688, 22);
            this.m_panelTop.TabIndex = 1;
            // 
            // m_picRecalculer
            // 
            this.m_picRecalculer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_picRecalculer.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_picRecalculer.Image = global::timos.Properties.Resources.Calculatrice;
            this.m_picRecalculer.Location = new System.Drawing.Point(600, 0);
            this.m_extModeEdition.SetModeEdition(this.m_picRecalculer, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_picRecalculer.Name = "m_picRecalculer";
            this.m_picRecalculer.Size = new System.Drawing.Size(22, 20);
            this.m_picRecalculer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_picRecalculer.TabIndex = 10;
            this.m_picRecalculer.TabStop = false;
            this.m_tooltip.SetToolTip(this.m_picRecalculer, "Calculate costs|20697");
            this.m_picRecalculer.Click += new System.EventHandler(this.m_picRecalculer_Click);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(622, 0);
            this.m_extModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 20);
            this.label3.TabIndex = 9;
            // 
            // m_btnAddBesoin
            // 
            this.m_btnAddBesoin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnAddBesoin.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnAddBesoin.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_btnAddBesoin.Location = new System.Drawing.Point(104, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnAddBesoin, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnAddBesoin.Name = "m_btnAddBesoin";
            this.m_btnAddBesoin.ShortMode = false;
            this.m_btnAddBesoin.Size = new System.Drawing.Size(83, 20);
            this.m_btnAddBesoin.TabIndex = 6;
            this.m_tooltip.SetToolTip(this.m_btnAddBesoin, "Add new need|20700");
            this.m_btnAddBesoin.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_btnAddBesoin.LinkClicked += new System.EventHandler(this.m_btnAddBesoin_LinkClicked);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(94, 0);
            this.m_extModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 20);
            this.label2.TabIndex = 7;
            // 
            // m_picExtraireListe
            // 
            this.m_picExtraireListe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_picExtraireListe.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_picExtraireListe.Image = global::timos.Properties.Resources.Extract_List;
            this.m_picExtraireListe.Location = new System.Drawing.Point(632, 0);
            this.m_extModeEdition.SetModeEdition(this.m_picExtraireListe, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_picExtraireListe.Name = "m_picExtraireListe";
            this.m_picExtraireListe.Size = new System.Drawing.Size(22, 20);
            this.m_picExtraireListe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_picExtraireListe.TabIndex = 4;
            this.m_picExtraireListe.TabStop = false;
            this.m_tooltip.SetToolTip(this.m_picExtraireListe, "Extract list|20698");
            this.m_picExtraireListe.Click += new System.EventHandler(this.m_picExtraireListe_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(654, 0);
            this.m_extModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 20);
            this.label1.TabIndex = 5;
            // 
            // m_pictureMap
            // 
            this.m_pictureMap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_pictureMap.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_pictureMap.Image = global::timos.Properties.Resources.sitemap;
            this.m_pictureMap.Location = new System.Drawing.Point(664, 0);
            this.m_extModeEdition.SetModeEdition(this.m_pictureMap, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_pictureMap.Name = "m_pictureMap";
            this.m_pictureMap.Size = new System.Drawing.Size(22, 20);
            this.m_pictureMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_pictureMap.TabIndex = 3;
            this.m_pictureMap.TabStop = false;
            this.m_tooltip.SetToolTip(this.m_pictureMap, "Display map|20699");
            this.m_pictureMap.Click += new System.EventHandler(this.m_pictureMap_Click);
            // 
            // m_panelModes
            // 
            this.m_panelModes.Controls.Add(this.m_btnModeSuivi);
            this.m_panelModes.Controls.Add(this.m_btnModeConception);
            this.m_panelModes.Controls.Add(this.m_btnModeSansCout);
            this.m_panelModes.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelModes.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelModes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelModes.Name = "m_panelModes";
            this.m_panelModes.Size = new System.Drawing.Size(94, 20);
            this.m_panelModes.TabIndex = 8;
            // 
            // m_btnModeSuivi
            // 
            this.m_btnModeSuivi.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_btnModeSuivi.AutoSize = true;
            this.m_btnModeSuivi.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnModeSuivi.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.m_btnModeSuivi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_btnModeSuivi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.m_btnModeSuivi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnModeSuivi.Image = global::timos.Properties.Resources.monitoring;
            this.m_btnModeSuivi.Location = new System.Drawing.Point(47, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnModeSuivi, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnModeSuivi.Name = "m_btnModeSuivi";
            this.m_btnModeSuivi.Size = new System.Drawing.Size(24, 20);
            this.m_btnModeSuivi.TabIndex = 2;
            this.m_tooltip.SetToolTip(this.m_btnModeSuivi, "Monitor costs|20696");
            this.m_btnModeSuivi.UseVisualStyleBackColor = true;
            this.m_btnModeSuivi.CheckedChanged += new System.EventHandler(this.m_btnModeSuivi_CheckedChanged);
            // 
            // m_btnModeConception
            // 
            this.m_btnModeConception.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_btnModeConception.AutoSize = true;
            this.m_btnModeConception.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnModeConception.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.m_btnModeConception.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_btnModeConception.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.m_btnModeConception.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnModeConception.Image = global::timos.Properties.Resources.money;
            this.m_btnModeConception.Location = new System.Drawing.Point(23, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnModeConception, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnModeConception.Name = "m_btnModeConception";
            this.m_btnModeConception.Size = new System.Drawing.Size(24, 20);
            this.m_btnModeConception.TabIndex = 1;
            this.m_tooltip.SetToolTip(this.m_btnModeConception, "Enter data with costs|20695");
            this.m_btnModeConception.UseVisualStyleBackColor = true;
            this.m_btnModeConception.CheckedChanged += new System.EventHandler(this.m_btnModeConception_CheckedChanged);
            // 
            // m_btnModeSansCout
            // 
            this.m_btnModeSansCout.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_btnModeSansCout.AutoSize = true;
            this.m_btnModeSansCout.Checked = true;
            this.m_btnModeSansCout.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnModeSansCout.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.m_btnModeSansCout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_btnModeSansCout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.m_btnModeSansCout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnModeSansCout.Image = global::timos.Properties.Resources.modify;
            this.m_btnModeSansCout.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnModeSansCout, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnModeSansCout.Name = "m_btnModeSansCout";
            this.m_btnModeSansCout.Size = new System.Drawing.Size(23, 20);
            this.m_btnModeSansCout.TabIndex = 0;
            this.m_btnModeSansCout.TabStop = true;
            this.m_tooltip.SetToolTip(this.m_btnModeSansCout, "Enter data without costs|20694");
            this.m_btnModeSansCout.UseVisualStyleBackColor = true;
            this.m_btnModeSansCout.CheckedChanged += new System.EventHandler(this.m_btnModeSansCout_CheckedChanged);
            // 
            // m_picFillBesoin
            // 
            this.m_picFillBesoin.Image = ((System.Drawing.Image)(resources.GetObject("m_picFillBesoin.Image")));
            this.m_picFillBesoin.Location = new System.Drawing.Point(89, 97);
            this.m_extModeEdition.SetModeEdition(this.m_picFillBesoin, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_picFillBesoin.Name = "m_picFillBesoin";
            this.m_picFillBesoin.Size = new System.Drawing.Size(71, 20);
            this.m_picFillBesoin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_picFillBesoin.TabIndex = 0;
            this.m_picFillBesoin.TabStop = false;
            this.m_picFillBesoin.Visible = false;
            // 
            // m_panelResumeElementACout
            // 
            this.m_panelResumeElementACout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panelResumeElementACout.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelResumeElementACout.Location = new System.Drawing.Point(0, 22);
            this.m_panelResumeElementACout.LockEdition = true;
            this.m_extModeEdition.SetModeEdition(this.m_panelResumeElementACout, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelResumeElementACout.Name = "m_panelResumeElementACout";
            this.m_panelResumeElementACout.Size = new System.Drawing.Size(688, 23);
            this.m_panelResumeElementACout.TabIndex = 1;
            // 
            // CControleListeBesoins
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_panelResumeElementACout);
            this.Controls.Add(this.m_panelTop);
            this.Items = new sc2i.win32.common.customizableList.CCustomizableListItem[0];
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleListeBesoins";
            this.Size = new System.Drawing.Size(688, 242);
            this.Load += new System.EventHandler(this.CControleListeBesoins_Load);
            this.Controls.SetChildIndex(this.m_panelTop, 0);
            this.Controls.SetChildIndex(this.m_panelResumeElementACout, 0);
            this.Controls.SetChildIndex(this.m_panelDessin, 0);
            this.m_panelDessin.ResumeLayout(false);
            this.m_panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_picRecalculer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picExtraireListe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_pictureMap)).EndInit();
            this.m_panelModes.ResumeLayout(false);
            this.m_panelModes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_picFillBesoin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox m_picFillBesoin;
        private System.Windows.Forms.Panel m_panelTop;
        private System.Windows.Forms.PictureBox m_picExtraireListe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox m_pictureMap;
        private sc2i.win32.common.CWndLinkStd m_btnAddBesoin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel m_panelModes;
        private System.Windows.Forms.RadioButton m_btnModeSansCout;
        private System.Windows.Forms.RadioButton m_btnModeConception;
        private System.Windows.Forms.RadioButton m_btnModeSuivi;
        private CcontroleResumeElementACout m_panelResumeElementACout;
        private System.Windows.Forms.PictureBox m_picRecalculer;
        private System.Windows.Forms.Label label3;
        private sc2i.win32.common.CToolTipTraductible m_tooltip;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;

    }
}
