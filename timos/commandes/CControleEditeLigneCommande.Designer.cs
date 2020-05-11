namespace timos.commandes
{
    partial class CControleEditeLigneCommande
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CControleEditeLigneCommande));
            this.label1 = new System.Windows.Forms.Label();
            this.m_panelTop = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_panelData = new System.Windows.Forms.Panel();
            this.m_txtTexte = new sc2i.win32.common.C2iTextBox();
            this.m_txtReference = new sc2i.win32.common.C2iTextBox();
            this.m_txtQte = new sc2i.win32.common.C2iTextBoxNumerique();
            this.m_panelPoubelle = new System.Windows.Forms.Panel();
            this.m_btnInsert = new System.Windows.Forms.PictureBox();
            this.m_btnAdd = new System.Windows.Forms.PictureBox();
            this.m_btnPoubelle = new System.Windows.Forms.PictureBox();
            this.m_btnLigneSuivante = new System.Windows.Forms.Button();
            this.m_txtSelectReference = new sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide();
            this.m_selectTypeEquipement = new sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide();
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_panelTop.SuspendLayout();
            this.m_panelData.SuspendLayout();
            this.m_panelPoubelle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnInsert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnPoubelle)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Equipment type|20396";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_panelTop
            // 
            this.m_panelTop.Controls.Add(this.label3);
            this.m_panelTop.Controls.Add(this.label6);
            this.m_panelTop.Controls.Add(this.label2);
            this.m_panelTop.Controls.Add(this.label4);
            this.m_panelTop.Controls.Add(this.label5);
            this.m_panelTop.Controls.Add(this.label1);
            this.m_panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelTop.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelTop, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelTop.Name = "m_panelTop";
            this.m_panelTop.Size = new System.Drawing.Size(862, 24);
            this.m_panelTop.TabIndex = 1;
            this.m_panelTop.Visible = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(453, 0);
            this.m_extModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Label|50";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Dock = System.Windows.Forms.DockStyle.Right;
            this.label6.Location = new System.Drawing.Point(637, 0);
            this.m_extModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 24);
            this.label6.TabIndex = 5;
            this.label6.Text = "Reference|20397";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(246, 0);
            this.m_extModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Reference|20397";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Dock = System.Windows.Forms.DockStyle.Right;
            this.label4.Location = new System.Drawing.Point(738, 0);
            this.m_extModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Quantity|20398";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Dock = System.Windows.Forms.DockStyle.Right;
            this.label5.Location = new System.Drawing.Point(804, 0);
            this.m_extModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 24);
            this.label5.TabIndex = 4;
            // 
            // m_panelData
            // 
            this.m_panelData.Controls.Add(this.m_txtTexte);
            this.m_panelData.Controls.Add(this.m_txtReference);
            this.m_panelData.Controls.Add(this.m_txtQte);
            this.m_panelData.Controls.Add(this.m_panelPoubelle);
            this.m_panelData.Controls.Add(this.m_btnLigneSuivante);
            this.m_panelData.Controls.Add(this.m_txtSelectReference);
            this.m_panelData.Controls.Add(this.m_selectTypeEquipement);
            this.m_panelData.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelData.Location = new System.Drawing.Point(0, 24);
            this.m_extModeEdition.SetModeEdition(this.m_panelData, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelData.Name = "m_panelData";
            this.m_panelData.Size = new System.Drawing.Size(862, 22);
            this.m_panelData.TabIndex = 2;
            // 
            // m_txtTexte
            // 
            this.m_txtTexte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtTexte.EmptyText = "";
            this.m_txtTexte.Location = new System.Drawing.Point(453, 0);
            this.m_txtTexte.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtTexte, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtTexte.Name = "m_txtTexte";
            this.m_txtTexte.Size = new System.Drawing.Size(184, 20);
            this.m_txtTexte.TabIndex = 2;
            // 
            // m_txtReference
            // 
            this.m_txtReference.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_txtReference.EmptyText = "";
            this.m_txtReference.Location = new System.Drawing.Point(637, 0);
            this.m_txtReference.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtReference, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtReference.Name = "m_txtReference";
            this.m_txtReference.Size = new System.Drawing.Size(101, 20);
            this.m_txtReference.TabIndex = 3;
            // 
            // m_txtQte
            // 
            this.m_txtQte.Arrondi = 4;
            this.m_txtQte.DecimalAutorise = true;
            this.m_txtQte.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_txtQte.DoubleValue = null;
            this.m_txtQte.EmptyText = "";
            this.m_txtQte.IntValue = null;
            this.m_txtQte.Location = new System.Drawing.Point(738, 0);
            this.m_txtQte.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtQte, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtQte.Name = "m_txtQte";
            this.m_txtQte.NullAutorise = true;
            this.m_txtQte.SelectAllOnEnter = true;
            this.m_txtQte.SeparateurMilliers = "";
            this.m_txtQte.Size = new System.Drawing.Size(66, 20);
            this.m_txtQte.TabIndex = 4;
            this.m_txtQte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // m_panelPoubelle
            // 
            this.m_panelPoubelle.BackColor = System.Drawing.Color.White;
            this.m_panelPoubelle.Controls.Add(this.m_btnInsert);
            this.m_panelPoubelle.Controls.Add(this.m_btnAdd);
            this.m_panelPoubelle.Controls.Add(this.m_btnPoubelle);
            this.m_panelPoubelle.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_panelPoubelle.Location = new System.Drawing.Point(804, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelPoubelle, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelPoubelle.Name = "m_panelPoubelle";
            this.m_panelPoubelle.Size = new System.Drawing.Size(34, 22);
            this.m_panelPoubelle.TabIndex = 10;
            // 
            // m_btnInsert
            // 
            this.m_btnInsert.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.m_btnInsert.BackColor = System.Drawing.Color.Lime;
            this.m_btnInsert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnInsert.Image = ((System.Drawing.Image)(resources.GetObject("m_btnInsert.Image")));
            this.m_btnInsert.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnInsert, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnInsert.Name = "m_btnInsert";
            this.m_btnInsert.Size = new System.Drawing.Size(16, 12);
            this.m_btnInsert.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_btnInsert.TabIndex = 7;
            this.m_btnInsert.TabStop = false;
            this.m_btnInsert.Click += new System.EventHandler(this.m_btnInsert_Click);
            // 
            // m_btnAdd
            // 
            this.m_btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.m_btnAdd.BackColor = System.Drawing.Color.Aqua;
            this.m_btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("m_btnAdd.Image")));
            this.m_btnAdd.Location = new System.Drawing.Point(0, 10);
            this.m_extModeEdition.SetModeEdition(this.m_btnAdd, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnAdd.Name = "m_btnAdd";
            this.m_btnAdd.Size = new System.Drawing.Size(16, 12);
            this.m_btnAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_btnAdd.TabIndex = 8;
            this.m_btnAdd.TabStop = false;
            this.m_btnAdd.Click += new System.EventHandler(this.m_btnAdd_Click);
            // 
            // m_btnPoubelle
            // 
            this.m_btnPoubelle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.m_btnPoubelle.BackColor = System.Drawing.Color.White;
            this.m_btnPoubelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnPoubelle.Image = ((System.Drawing.Image)(resources.GetObject("m_btnPoubelle.Image")));
            this.m_btnPoubelle.Location = new System.Drawing.Point(16, -1);
            this.m_extModeEdition.SetModeEdition(this.m_btnPoubelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnPoubelle.Name = "m_btnPoubelle";
            this.m_btnPoubelle.Size = new System.Drawing.Size(16, 24);
            this.m_btnPoubelle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_btnPoubelle.TabIndex = 6;
            this.m_btnPoubelle.TabStop = false;
            this.m_btnPoubelle.Click += new System.EventHandler(this.m_btnPoubelle_Click);
            // 
            // m_btnLigneSuivante
            // 
            this.m_btnLigneSuivante.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnLigneSuivante.Image = ((System.Drawing.Image)(resources.GetObject("m_btnLigneSuivante.Image")));
            this.m_btnLigneSuivante.Location = new System.Drawing.Point(838, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnLigneSuivante, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnLigneSuivante.Name = "m_btnLigneSuivante";
            this.m_btnLigneSuivante.Size = new System.Drawing.Size(24, 22);
            this.m_btnLigneSuivante.TabIndex = 5;
            this.m_btnLigneSuivante.UseVisualStyleBackColor = true;
            this.m_btnLigneSuivante.Click += new System.EventHandler(this.m_btnLigneSuivante_Click);
            // 
            // m_txtSelectReference
            // 
            this.m_txtSelectReference.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_txtSelectReference.ElementSelectionne = null;
            this.m_txtSelectReference.Location = new System.Drawing.Point(246, 0);
            this.m_txtSelectReference.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtSelectReference, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtSelectReference.Name = "m_txtSelectReference";
            this.m_txtSelectReference.SelectedObject = null;
            this.m_txtSelectReference.SelectionLength = 0;
            this.m_txtSelectReference.SelectionStart = 0;
            this.m_txtSelectReference.Size = new System.Drawing.Size(207, 22);
            this.m_txtSelectReference.TabIndex = 1;
            this.m_txtSelectReference.OnSelectedObjectChanged += new System.EventHandler(this.m_txtSelectReference_OnSelectedObjectChanged);
            // 
            // m_selectTypeEquipement
            // 
            this.m_selectTypeEquipement.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_selectTypeEquipement.ElementSelectionne = null;
            this.m_selectTypeEquipement.Location = new System.Drawing.Point(0, 0);
            this.m_selectTypeEquipement.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_selectTypeEquipement, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_selectTypeEquipement.Name = "m_selectTypeEquipement";
            this.m_selectTypeEquipement.SelectedObject = null;
            this.m_selectTypeEquipement.SelectionLength = 0;
            this.m_selectTypeEquipement.SelectionStart = 0;
            this.m_selectTypeEquipement.Size = new System.Drawing.Size(246, 22);
            this.m_selectTypeEquipement.TabIndex = 0;
            this.m_selectTypeEquipement.OnSelectedObjectChanged += new System.EventHandler(this.m_selectTypeEquipement_OnSelectedObjectChanged);
            // 
            // CControleEditeLigneCommande
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_panelData);
            this.Controls.Add(this.m_panelTop);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleEditeLigneCommande";
            this.Size = new System.Drawing.Size(862, 46);
            this.m_panelTop.ResumeLayout(false);
            this.m_panelData.ResumeLayout(false);
            this.m_panelData.PerformLayout();
            this.m_panelPoubelle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnInsert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnPoubelle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel m_panelTop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel m_panelData;
        private sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide m_txtSelectReference;
        private sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide m_selectTypeEquipement;
        private sc2i.win32.common.C2iTextBoxNumerique m_txtQte;
        private sc2i.win32.common.C2iTextBox m_txtTexte;
        private System.Windows.Forms.Panel m_panelPoubelle;
        private System.Windows.Forms.PictureBox m_btnInsert;
        private System.Windows.Forms.PictureBox m_btnAdd;
        private System.Windows.Forms.PictureBox m_btnPoubelle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button m_btnLigneSuivante;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
        private System.Windows.Forms.Label label6;
        private sc2i.win32.common.C2iTextBox m_txtReference;
    }
}
