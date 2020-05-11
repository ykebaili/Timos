namespace timos.commandes
{
    partial class CControleEditeValorisationEquipement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CControleEditeValorisationEquipement));
            this.m_panelData = new System.Windows.Forms.Panel();
            this.m_selectTypeEquipement = new sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide();
            this.m_txtQuantite = new sc2i.win32.common.C2iTextBoxNumeriqueAvecUnite();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtValeur = new sc2i.win32.common.C2iTextBoxNumerique();
            this.m_panelPoubelle = new System.Windows.Forms.Panel();
            this.m_btnPoubelle = new System.Windows.Forms.PictureBox();
            this.m_panelData.SuspendLayout();
            this.m_panelPoubelle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnPoubelle)).BeginInit();
            this.SuspendLayout();
            // 
            // m_panelData
            // 
            this.m_panelData.Controls.Add(this.m_selectTypeEquipement);
            this.m_panelData.Controls.Add(this.m_txtQuantite);
            this.m_panelData.Controls.Add(this.label1);
            this.m_panelData.Controls.Add(this.m_txtValeur);
            this.m_panelData.Controls.Add(this.m_panelPoubelle);
            this.m_panelData.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelData.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelData, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelData.Name = "m_panelData";
            this.m_panelData.Size = new System.Drawing.Size(439, 22);
            this.m_panelData.TabIndex = 2;
            // 
            // m_selectTypeEquipement
            // 
            this.m_selectTypeEquipement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_selectTypeEquipement.ElementSelectionne = null;
            this.m_selectTypeEquipement.FonctionTextNull = null;
            this.m_selectTypeEquipement.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_selectTypeEquipement.Location = new System.Drawing.Point(0, 0);
            this.m_selectTypeEquipement.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_selectTypeEquipement, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_selectTypeEquipement.Name = "m_selectTypeEquipement";
            this.m_selectTypeEquipement.SelectedObject = null;
            this.m_selectTypeEquipement.SelectionLength = 0;
            this.m_selectTypeEquipement.SelectionStart = 0;
            this.m_selectTypeEquipement.Size = new System.Drawing.Size(230, 22);
            this.m_selectTypeEquipement.SpecificImage = null;
            this.m_selectTypeEquipement.TabIndex = 0;
            this.m_selectTypeEquipement.TextNull = "";
            this.m_selectTypeEquipement.UseIntellisense = true;
            this.m_selectTypeEquipement.ElementSelectionneChanged += new System.EventHandler(this.m_selectTypeEquipement_ElementSelectionneChanged);
            // 
            // m_txtQuantite
            // 
            this.m_txtQuantite.AllowNoUnit = false;
            this.m_txtQuantite.DefaultFormat = "";
            this.m_txtQuantite.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_txtQuantite.EmptyText = "";
            this.m_txtQuantite.Location = new System.Drawing.Point(230, 0);
            this.m_txtQuantite.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtQuantite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtQuantite.Name = "m_txtQuantite";
            this.m_txtQuantite.Size = new System.Drawing.Size(100, 20);
            this.m_txtQuantite.TabIndex = 1;
            this.m_txtQuantite.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtQuantite.UnitValue = null;
            this.m_txtQuantite.UseValueFormat = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(330, 0);
            this.m_extModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 22);
            this.label1.TabIndex = 12;
            // 
            // m_txtValeur
            // 
            this.m_txtValeur.Arrondi = 4;
            this.m_txtValeur.DecimalAutorise = true;
            this.m_txtValeur.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_txtValeur.DoubleValue = null;
            this.m_txtValeur.EmptyText = "";
            this.m_txtValeur.IntValue = null;
            this.m_txtValeur.Location = new System.Drawing.Point(351, 0);
            this.m_txtValeur.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtValeur, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtValeur.Name = "m_txtValeur";
            this.m_txtValeur.NullAutorise = true;
            this.m_txtValeur.SelectAllOnEnter = true;
            this.m_txtValeur.SeparateurMilliers = "";
            this.m_txtValeur.Size = new System.Drawing.Size(66, 20);
            this.m_txtValeur.TabIndex = 2;
            this.m_txtValeur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // m_panelPoubelle
            // 
            this.m_panelPoubelle.BackColor = System.Drawing.Color.White;
            this.m_panelPoubelle.Controls.Add(this.m_btnPoubelle);
            this.m_panelPoubelle.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_panelPoubelle.Location = new System.Drawing.Point(417, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelPoubelle, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelPoubelle.Name = "m_panelPoubelle";
            this.m_panelPoubelle.Size = new System.Drawing.Size(22, 22);
            this.m_panelPoubelle.TabIndex = 10;
            // 
            // m_btnPoubelle
            // 
            this.m_btnPoubelle.BackColor = System.Drawing.Color.White;
            this.m_btnPoubelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnPoubelle.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnPoubelle.Image = ((System.Drawing.Image)(resources.GetObject("m_btnPoubelle.Image")));
            this.m_btnPoubelle.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnPoubelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnPoubelle.Name = "m_btnPoubelle";
            this.m_btnPoubelle.Size = new System.Drawing.Size(16, 22);
            this.m_btnPoubelle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_btnPoubelle.TabIndex = 6;
            this.m_btnPoubelle.TabStop = false;
            this.m_btnPoubelle.Click += new System.EventHandler(this.m_btnPoubelle_Click);
            // 
            // CControleEditeValorisationEquipement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_panelData);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleEditeValorisationEquipement";
            this.Size = new System.Drawing.Size(439, 21);
            this.m_panelData.ResumeLayout(false);
            this.m_panelData.PerformLayout();
            this.m_panelPoubelle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnPoubelle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel m_panelData;
        private sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide m_selectTypeEquipement;
        private sc2i.win32.common.C2iTextBoxNumerique m_txtValeur;
        private System.Windows.Forms.Panel m_panelPoubelle;
        private System.Windows.Forms.PictureBox m_btnPoubelle;
        private sc2i.win32.common.C2iTextBoxNumeriqueAvecUnite m_txtQuantite;
        private System.Windows.Forms.Label label1;
    }
}
