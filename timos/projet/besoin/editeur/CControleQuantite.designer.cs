namespace timos.projet.besoin
{
    partial class CControleQuantite
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
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.m_txtQuantite = new sc2i.win32.common.C2iTextBoxNumerique();
            this.m_btnDelete = new System.Windows.Forms.PictureBox();
            this.m_picMarge = new System.Windows.Forms.PictureBox();
            this.m_picQte = new System.Windows.Forms.PictureBox();
            this.m_btnEdit = new System.Windows.Forms.PictureBox();
            this.m_menuDetail = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_menuElements = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picMarge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picQte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnEdit)).BeginInit();
            this.m_menuDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_txtLibelle
            // 
            this.m_txtLibelle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtLibelle.EmptyText = "";
            this.m_txtLibelle.Location = new System.Drawing.Point(75, 0);
            this.m_txtLibelle.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(169, 20);
            this.m_txtLibelle.TabIndex = 2;
            this.m_txtLibelle.TextChanged += new System.EventHandler(this.textChanged);
            // 
            // m_txtQuantite
            // 
            this.m_txtQuantite.Arrondi = 4;
            this.m_txtQuantite.DecimalAutorise = true;
            this.m_txtQuantite.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_txtQuantite.EmptyText = "";
            this.m_txtQuantite.IntValue = 0;
            this.m_txtQuantite.Location = new System.Drawing.Point(33, 0);
            this.m_txtQuantite.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtQuantite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtQuantite.Name = "m_txtQuantite";
            this.m_txtQuantite.NullAutorise = false;
            this.m_txtQuantite.SelectAllOnEnter = true;
            this.m_txtQuantite.SeparateurMilliers = "";
            this.m_txtQuantite.Size = new System.Drawing.Size(42, 20);
            this.m_txtQuantite.TabIndex = 1;
            this.m_txtQuantite.Text = "0";
            this.m_txtQuantite.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtQuantite.TextChanged += new System.EventHandler(this.textChanged);
            this.m_txtQuantite.Validated += new System.EventHandler(this.m_txtQuantite_Validated);
            // 
            // m_btnDelete
            // 
            this.m_btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.m_btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnDelete.Image = global::timos.Properties.Resources.delete;
            this.m_btnDelete.Location = new System.Drawing.Point(264, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnDelete, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnDelete.Name = "m_btnDelete";
            this.m_btnDelete.Size = new System.Drawing.Size(20, 20);
            this.m_btnDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_btnDelete.TabIndex = 9;
            this.m_btnDelete.TabStop = false;
            this.m_btnDelete.Click += new System.EventHandler(this.m_btnDelete_Click);
            // 
            // m_picMarge
            // 
            this.m_picMarge.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_picMarge.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_picMarge, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_picMarge.Name = "m_picMarge";
            this.m_picMarge.Size = new System.Drawing.Size(13, 20);
            this.m_picMarge.TabIndex = 10;
            this.m_picMarge.TabStop = false;
            // 
            // m_picQte
            // 
            this.m_picQte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_picQte.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_picQte.Image = global::timos.Properties.Resources.quantity;
            this.m_picQte.Location = new System.Drawing.Point(13, 0);
            this.m_extModeEdition.SetModeEdition(this.m_picQte, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_picQte.Name = "m_picQte";
            this.m_picQte.Size = new System.Drawing.Size(20, 20);
            this.m_picQte.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_picQte.TabIndex = 11;
            this.m_picQte.TabStop = false;
            this.m_picQte.MouseMove += new System.Windows.Forms.MouseEventHandler(this.m_imageQte_MouseMove);
            this.m_picQte.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_imageQte_MouseDown);
            // 
            // m_btnEdit
            // 
            this.m_btnEdit.BackColor = System.Drawing.Color.Transparent;
            this.m_btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnEdit.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnEdit.Image = global::timos.Properties.Resources.edit;
            this.m_btnEdit.Location = new System.Drawing.Point(244, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnEdit, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnEdit.Name = "m_btnEdit";
            this.m_btnEdit.Size = new System.Drawing.Size(20, 20);
            this.m_btnEdit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_btnEdit.TabIndex = 12;
            this.m_btnEdit.TabStop = false;
            this.m_btnEdit.Paint += new System.Windows.Forms.PaintEventHandler(this.m_btnEdit_Paint);
            this.m_btnEdit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_btnEdit_MouseUp);
            // 
            // m_menuDetail
            // 
            this.m_menuDetail.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_menuElements});
            this.m_extModeEdition.SetModeEdition(this.m_menuDetail, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_menuDetail.Name = "m_menuDetail";
            this.m_menuDetail.Size = new System.Drawing.Size(163, 26);
            this.m_menuDetail.Opening += new System.ComponentModel.CancelEventHandler(this.m_menuDetail_Opening);
            // 
            // m_menuElements
            // 
            this.m_menuElements.Name = "m_menuElements";
            this.m_menuElements.Size = new System.Drawing.Size(162, 22);
            this.m_menuElements.Text = "Elements|20639";
            // 
            // CControleQuantite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.m_txtLibelle);
            this.Controls.Add(this.m_btnEdit);
            this.Controls.Add(this.m_txtQuantite);
            this.Controls.Add(this.m_btnDelete);
            this.Controls.Add(this.m_picQte);
            this.Controls.Add(this.m_picMarge);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleQuantite";
            this.Size = new System.Drawing.Size(284, 20);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picMarge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picQte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnEdit)).EndInit();
            this.m_menuDetail.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private sc2i.win32.common.C2iTextBox m_txtLibelle;
        private sc2i.win32.common.C2iTextBoxNumerique m_txtQuantite;
        private System.Windows.Forms.PictureBox m_btnDelete;
        private System.Windows.Forms.PictureBox m_picMarge;
        private System.Windows.Forms.PictureBox m_picQte;
        private System.Windows.Forms.PictureBox m_btnEdit;
        private System.Windows.Forms.ContextMenuStrip m_menuDetail;
        private System.Windows.Forms.ToolStripMenuItem m_menuElements;
    }
}
