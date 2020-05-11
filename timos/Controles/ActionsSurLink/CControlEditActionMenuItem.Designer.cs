namespace timos.Controles.ActionsSurLink
{
    partial class CControlEditActionMenuItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CControlEditActionMenuItem));
            this.m_imageLinkOk = new System.Windows.Forms.PictureBox();
            this.m_lnkActionSurMenuItem = new System.Windows.Forms.LinkLabel();
            this.m_wndFormuleCondition = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.m_numMenuItemSort = new sc2i.win32.common.C2iTextBoxNumerique();
            this.m_txtMenuItemLabel = new sc2i.win32.common.C2iTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtFormuleLibelle = new sc2i.win32.expression.CTextBoxZoomFormule();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageLinkOk)).BeginInit();
            this.SuspendLayout();
            // 
            // m_imageLinkOk
            // 
            this.m_imageLinkOk.Image = ((System.Drawing.Image)(resources.GetObject("m_imageLinkOk.Image")));
            this.m_imageLinkOk.Location = new System.Drawing.Point(70, 141);
            this.m_imageLinkOk.Name = "m_imageLinkOk";
            this.m_imageLinkOk.Size = new System.Drawing.Size(16, 16);
            this.m_imageLinkOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.m_imageLinkOk.TabIndex = 20;
            this.m_imageLinkOk.TabStop = false;
            this.m_imageLinkOk.Visible = false;
            // 
            // m_lnkActionSurMenuItem
            // 
            this.m_lnkActionSurMenuItem.AutoSize = true;
            this.m_lnkActionSurMenuItem.Location = new System.Drawing.Point(92, 141);
            this.m_lnkActionSurMenuItem.Name = "m_lnkActionSurMenuItem";
            this.m_lnkActionSurMenuItem.Size = new System.Drawing.Size(69, 13);
            this.m_lnkActionSurMenuItem.TabIndex = 40;
            this.m_lnkActionSurMenuItem.TabStop = true;
            this.m_lnkActionSurMenuItem.Text = "Action|10406";
            this.m_lnkActionSurMenuItem.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkActionSurMenuItem_LinkClicked);
            // 
            // m_wndFormuleCondition
            // 
            this.m_wndFormuleCondition.AllowGraphic = true;
            this.m_wndFormuleCondition.AllowNullFormula = true;
            this.m_wndFormuleCondition.AllowSaisieTexte = true;
            this.m_wndFormuleCondition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_wndFormuleCondition.Formule = null;
            this.m_wndFormuleCondition.Location = new System.Drawing.Point(95, 104);
            this.m_wndFormuleCondition.LockEdition = false;
            this.m_wndFormuleCondition.LockZoneTexte = false;
            this.m_wndFormuleCondition.Name = "m_wndFormuleCondition";
            this.m_wndFormuleCondition.Size = new System.Drawing.Size(255, 22);
            this.m_wndFormuleCondition.TabIndex = 30;
            // 
            // m_numMenuItemSort
            // 
            this.m_numMenuItemSort.Arrondi = 0;
            this.m_numMenuItemSort.DecimalAutorise = true;
            this.m_numMenuItemSort.EmptyText = "";
            this.m_numMenuItemSort.IntValue = 0;
            this.m_numMenuItemSort.Location = new System.Drawing.Point(95, 13);
            this.m_numMenuItemSort.LockEdition = false;
            this.m_numMenuItemSort.Name = "m_numMenuItemSort";
            this.m_numMenuItemSort.NullAutorise = false;
            this.m_numMenuItemSort.SelectAllOnEnter = true;
            this.m_numMenuItemSort.SeparateurMilliers = "";
            this.m_numMenuItemSort.Size = new System.Drawing.Size(100, 20);
            this.m_numMenuItemSort.TabIndex = 0;
            this.m_numMenuItemSort.Text = "0";
            // 
            // m_txtMenuItemLabel
            // 
            this.m_txtMenuItemLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtMenuItemLabel.EmptyText = "";
            this.m_txtMenuItemLabel.Location = new System.Drawing.Point(95, 50);
            this.m_txtMenuItemLabel.LockEdition = false;
            this.m_txtMenuItemLabel.Name = "m_txtMenuItemLabel";
            this.m_txtMenuItemLabel.Size = new System.Drawing.Size(255, 20);
            this.m_txtMenuItemLabel.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 23);
            this.label4.TabIndex = 13;
            this.label4.Text = "Condition|10407";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 14;
            this.label2.Text = "Label|50";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 15;
            this.label1.Text = "Sort number|10405";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 23);
            this.label3.TabIndex = 13;
            this.label3.Text = "Menu text|20901";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtFormuleLibelle
            // 
            this.m_txtFormuleLibelle.AllowGraphic = true;
            this.m_txtFormuleLibelle.AllowNullFormula = true;
            this.m_txtFormuleLibelle.AllowSaisieTexte = true;
            this.m_txtFormuleLibelle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormuleLibelle.Formule = null;
            this.m_txtFormuleLibelle.Location = new System.Drawing.Point(95, 76);
            this.m_txtFormuleLibelle.LockEdition = false;
            this.m_txtFormuleLibelle.LockZoneTexte = false;
            this.m_txtFormuleLibelle.Name = "m_txtFormuleLibelle";
            this.m_txtFormuleLibelle.Size = new System.Drawing.Size(255, 22);
            this.m_txtFormuleLibelle.TabIndex = 20;
            // 
            // CControlEditActionMenuItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_imageLinkOk);
            this.Controls.Add(this.m_lnkActionSurMenuItem);
            this.Controls.Add(this.m_txtFormuleLibelle);
            this.Controls.Add(this.m_wndFormuleCondition);
            this.Controls.Add(this.m_numMenuItemSort);
            this.Controls.Add(this.m_txtMenuItemLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CControlEditActionMenuItem";
            this.Size = new System.Drawing.Size(363, 174);
            ((System.ComponentModel.ISupportInitialize)(this.m_imageLinkOk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox m_imageLinkOk;
        private System.Windows.Forms.LinkLabel m_lnkActionSurMenuItem;
        private sc2i.win32.expression.CTextBoxZoomFormule m_wndFormuleCondition;
        private sc2i.win32.common.C2iTextBoxNumerique m_numMenuItemSort;
        private sc2i.win32.common.C2iTextBox m_txtMenuItemLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleLibelle;
    }
}
