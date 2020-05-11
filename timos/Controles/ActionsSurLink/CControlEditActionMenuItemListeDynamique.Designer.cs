namespace timos.Controles.ActionsSurLink
{
    partial class CControlEditActionMenuItemListeDynamique
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CControlEditActionMenuItemListeDynamique));
            this.m_imageLinkOk = new System.Windows.Forms.PictureBox();
            this.m_lnkActionSurMenuItem = new System.Windows.Forms.LinkLabel();
            this.m_wndFormuleCondition = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.m_numMenuItemSort = new sc2i.win32.common.C2iTextBoxNumerique();
            this.m_txtMenuItemLabel = new sc2i.win32.common.C2iTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtFormuleListeSource = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtFormuleItemLibelle = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.label5 = new System.Windows.Forms.Label();
            this.m_panelItem = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageLinkOk)).BeginInit();
            this.m_panelItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_imageLinkOk
            // 
            this.m_imageLinkOk.Image = ((System.Drawing.Image)(resources.GetObject("m_imageLinkOk.Image")));
            this.m_imageLinkOk.Location = new System.Drawing.Point(91, 31);
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
            this.m_lnkActionSurMenuItem.Location = new System.Drawing.Point(113, 31);
            this.m_lnkActionSurMenuItem.Name = "m_lnkActionSurMenuItem";
            this.m_lnkActionSurMenuItem.Size = new System.Drawing.Size(69, 13);
            this.m_lnkActionSurMenuItem.TabIndex = 19;
            this.m_lnkActionSurMenuItem.TabStop = true;
            this.m_lnkActionSurMenuItem.Text = "Action|10406";
            this.m_lnkActionSurMenuItem.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkActionSurMenuItem_LinkClicked);
            // 
            // m_wndFormuleCondition
            // 
            this.m_wndFormuleCondition.AllowGraphic = true;
            this.m_wndFormuleCondition.AllowNullFormula = false;
            this.m_wndFormuleCondition.AllowSaisieTexte = true;
            this.m_wndFormuleCondition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_wndFormuleCondition.Formule = null;
            this.m_wndFormuleCondition.Location = new System.Drawing.Point(95, 89);
            this.m_wndFormuleCondition.LockEdition = false;
            this.m_wndFormuleCondition.LockZoneTexte = false;
            this.m_wndFormuleCondition.Name = "m_wndFormuleCondition";
            this.m_wndFormuleCondition.Size = new System.Drawing.Size(262, 22);
            this.m_wndFormuleCondition.TabIndex = 18;
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
            this.m_numMenuItemSort.TabIndex = 17;
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
            this.m_txtMenuItemLabel.Size = new System.Drawing.Size(262, 20);
            this.m_txtMenuItemLabel.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(7, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 23);
            this.label4.TabIndex = 13;
            this.label4.Text = "Condition|10407";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 49);
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
            // m_txtFormuleListeSource
            // 
            this.m_txtFormuleListeSource.AllowGraphic = true;
            this.m_txtFormuleListeSource.AllowNullFormula = false;
            this.m_txtFormuleListeSource.AllowSaisieTexte = true;
            this.m_txtFormuleListeSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormuleListeSource.Formule = null;
            this.m_txtFormuleListeSource.Location = new System.Drawing.Point(95, 135);
            this.m_txtFormuleListeSource.LockEdition = false;
            this.m_txtFormuleListeSource.LockZoneTexte = false;
            this.m_txtFormuleListeSource.Name = "m_txtFormuleListeSource";
            this.m_txtFormuleListeSource.Size = new System.Drawing.Size(262, 21);
            this.m_txtFormuleListeSource.TabIndex = 22;
            this.m_txtFormuleListeSource.Leave += new System.EventHandler(this.m_txtFormuleListeSource_Leave);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(10, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 22);
            this.label3.TabIndex = 21;
            this.label3.Text = "Source list|20863";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtFormuleItemLibelle
            // 
            this.m_txtFormuleItemLibelle.AllowGraphic = true;
            this.m_txtFormuleItemLibelle.AllowNullFormula = false;
            this.m_txtFormuleItemLibelle.AllowSaisieTexte = true;
            this.m_txtFormuleItemLibelle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormuleItemLibelle.Formule = null;
            this.m_txtFormuleItemLibelle.Location = new System.Drawing.Point(93, 2);
            this.m_txtFormuleItemLibelle.LockEdition = false;
            this.m_txtFormuleItemLibelle.LockZoneTexte = false;
            this.m_txtFormuleItemLibelle.Name = "m_txtFormuleItemLibelle";
            this.m_txtFormuleItemLibelle.Size = new System.Drawing.Size(258, 22);
            this.m_txtFormuleItemLibelle.TabIndex = 24;
            this.m_txtFormuleItemLibelle.Enter += new System.EventHandler(this.m_txtFormuleItemLibelle_Enter);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 23);
            this.label5.TabIndex = 23;
            this.label5.Text = "Item label|20864";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_panelItem
            // 
            this.m_panelItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_panelItem.Controls.Add(this.label5);
            this.m_panelItem.Controls.Add(this.m_txtFormuleItemLibelle);
            this.m_panelItem.Controls.Add(this.m_lnkActionSurMenuItem);
            this.m_panelItem.Controls.Add(this.m_imageLinkOk);
            this.m_panelItem.Location = new System.Drawing.Point(0, 162);
            this.m_panelItem.Name = "m_panelItem";
            this.m_panelItem.Size = new System.Drawing.Size(360, 54);
            this.m_panelItem.TabIndex = 25;
            // 
            // CControlEditActionMenuItemListeDynamique
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_panelItem);
            this.Controls.Add(this.m_txtFormuleListeSource);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_wndFormuleCondition);
            this.Controls.Add(this.m_numMenuItemSort);
            this.Controls.Add(this.m_txtMenuItemLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CControlEditActionMenuItemListeDynamique";
            this.Size = new System.Drawing.Size(363, 222);
            ((System.ComponentModel.ISupportInitialize)(this.m_imageLinkOk)).EndInit();
            this.m_panelItem.ResumeLayout(false);
            this.m_panelItem.PerformLayout();
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
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleListeSource;
        private System.Windows.Forms.Label label3;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleItemLibelle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel m_panelItem;
    }
}
