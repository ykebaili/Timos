namespace spv.win32
{
	partial class CExtendeurFormTypeEquipement
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
            this.m_gridSiteSPV = new System.Windows.Forms.PropertyGrid();
            this.labelDomainIP = new System.Windows.Forms.Label();
            this.labelCommunity = new System.Windows.Forms.Label();
            this.labelMediation = new System.Windows.Forms.Label();
            this.labelExDomainIP = new System.Windows.Forms.Label();
            this.labelExCommunity = new System.Windows.Forms.Label();
            this.c2iTextBoxDomainIP = new sc2i.win32.common.C2iTextBox();
            this.c2iTextBoxCommunity = new sc2i.win32.common.C2iTextBox();
            this.c2iTextBoxMediation = new sc2i.win32.common.C2iTextBox();
            this.DomainsList = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // m_gridSiteSPV
            // 
            this.m_gridSiteSPV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_gridSiteSPV, "");
            this.m_gridSiteSPV.Location = new System.Drawing.Point(3, 146);
            this.m_extModeEdition.SetModeEdition(this.m_gridSiteSPV, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_gridSiteSPV.Name = "m_gridSiteSPV";
            this.m_gridSiteSPV.Size = new System.Drawing.Size(397, 143);
            this.m_extStyle.SetStyleBackColor(this.m_gridSiteSPV, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_gridSiteSPV, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_gridSiteSPV.TabIndex = 1;
            // 
            // labelDomainIP
            // 
            this.labelDomainIP.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.labelDomainIP, "");
            this.labelDomainIP.Location = new System.Drawing.Point(15, 32);
            this.m_extModeEdition.SetModeEdition(this.labelDomainIP, sc2i.win32.common.TypeModeEdition.Autonome);
            this.labelDomainIP.Name = "labelDomainIP";
            this.labelDomainIP.Size = new System.Drawing.Size(56, 13);
            this.m_extStyle.SetStyleBackColor(this.labelDomainIP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.labelDomainIP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.labelDomainIP.TabIndex = 4;
            this.labelDomainIP.Text = "Domain IP";
            // 
            // labelCommunity
            // 
            this.labelCommunity.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.labelCommunity, "");
            this.labelCommunity.Location = new System.Drawing.Point(15, 71);
            this.m_extModeEdition.SetModeEdition(this.labelCommunity, sc2i.win32.common.TypeModeEdition.Autonome);
            this.labelCommunity.Name = "labelCommunity";
            this.labelCommunity.Size = new System.Drawing.Size(58, 13);
            this.m_extStyle.SetStyleBackColor(this.labelCommunity, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.labelCommunity, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.labelCommunity.TabIndex = 5;
            this.labelCommunity.Text = "Community";
            // 
            // labelMediation
            // 
            this.labelMediation.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.labelMediation, "");
            this.labelMediation.Location = new System.Drawing.Point(15, 111);
            this.m_extModeEdition.SetModeEdition(this.labelMediation, sc2i.win32.common.TypeModeEdition.Autonome);
            this.labelMediation.Name = "labelMediation";
            this.labelMediation.Size = new System.Drawing.Size(53, 13);
            this.m_extStyle.SetStyleBackColor(this.labelMediation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.labelMediation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.labelMediation.TabIndex = 7;
            this.labelMediation.Text = "Mediation";
            // 
            // labelExDomainIP
            // 
            this.labelExDomainIP.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.labelExDomainIP, "");
            this.labelExDomainIP.Location = new System.Drawing.Point(337, 39);
            this.m_extModeEdition.SetModeEdition(this.labelExDomainIP, sc2i.win32.common.TypeModeEdition.Autonome);
            this.labelExDomainIP.Name = "labelExDomainIP";
            this.labelExDomainIP.Size = new System.Drawing.Size(129, 13);
            this.m_extStyle.SetStyleBackColor(this.labelExDomainIP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.labelExDomainIP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.labelExDomainIP.TabIndex = 8;
            this.labelExDomainIP.Text = "(ex. 193.7.49.[1-10]), etc..";
            // 
            // labelExCommunity
            // 
            this.labelExCommunity.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.labelExCommunity, "");
            this.labelExCommunity.Location = new System.Drawing.Point(337, 78);
            this.m_extModeEdition.SetModeEdition(this.labelExCommunity, sc2i.win32.common.TypeModeEdition.Autonome);
            this.labelExCommunity.Name = "labelExCommunity";
            this.labelExCommunity.Size = new System.Drawing.Size(58, 13);
            this.m_extStyle.SetStyleBackColor(this.labelExCommunity, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.labelExCommunity, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.labelExCommunity.TabIndex = 9;
            this.labelExCommunity.Text = "(ex. public)";
            // 
            // c2iTextBoxDomainIP
            // 
            this.m_extLinkField.SetLinkField(this.c2iTextBoxDomainIP, "SiteDomaineIP");
            this.c2iTextBoxDomainIP.Location = new System.Drawing.Point(122, 32);
            this.c2iTextBoxDomainIP.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.c2iTextBoxDomainIP, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.c2iTextBoxDomainIP.Name = "c2iTextBoxDomainIP";
            this.c2iTextBoxDomainIP.Size = new System.Drawing.Size(176, 20);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBoxDomainIP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBoxDomainIP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBoxDomainIP.TabIndex = 2;
            this.c2iTextBoxDomainIP.Text = "[SiteDomaineIP]";
            // 
            // c2iTextBoxCommunity
            // 
            this.m_extLinkField.SetLinkField(this.c2iTextBoxCommunity, "SiteCmnte");
            this.c2iTextBoxCommunity.Location = new System.Drawing.Point(122, 71);
            this.c2iTextBoxCommunity.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.c2iTextBoxCommunity, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.c2iTextBoxCommunity.Name = "c2iTextBoxCommunity";
            this.c2iTextBoxCommunity.Size = new System.Drawing.Size(176, 20);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBoxCommunity, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBoxCommunity, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBoxCommunity.TabIndex = 10;
            this.c2iTextBoxCommunity.Text = "[SiteCmnte]";
            // 
            // c2iTextBoxMediation
            // 
            this.m_extLinkField.SetLinkField(this.c2iTextBoxMediation, "SiteEmName");
            this.c2iTextBoxMediation.Location = new System.Drawing.Point(122, 111);
            this.c2iTextBoxMediation.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.c2iTextBoxMediation, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.c2iTextBoxMediation.Name = "c2iTextBoxMediation";
            this.c2iTextBoxMediation.Size = new System.Drawing.Size(176, 20);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBoxMediation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBoxMediation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBoxMediation.TabIndex = 11;
            this.c2iTextBoxMediation.Text = "[SiteEmName]";
            // 
            // DomainsList
            // 
            this.DomainsList.FormattingEnabled = true;
            this.m_extLinkField.SetLinkField(this.DomainsList, "");
            this.DomainsList.Location = new System.Drawing.Point(18, 308);
            this.m_extModeEdition.SetModeEdition(this.DomainsList, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.DomainsList.Name = "DomainsList";
            this.DomainsList.Size = new System.Drawing.Size(172, 94);
            this.m_extStyle.SetStyleBackColor(this.DomainsList, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.DomainsList, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.DomainsList.TabIndex = 13;
            this.DomainsList.ThreeDCheckBoxes = true;
            // 
            // CExtendeurFormSite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DomainsList);
            this.Controls.Add(this.c2iTextBoxMediation);
            this.Controls.Add(this.c2iTextBoxCommunity);
            this.Controls.Add(this.labelExCommunity);
            this.Controls.Add(this.labelExDomainIP);
            this.Controls.Add(this.labelMediation);
            this.Controls.Add(this.labelCommunity);
            this.Controls.Add(this.labelDomainIP);
            this.Controls.Add(this.c2iTextBoxDomainIP);
            this.Controls.Add(this.m_gridSiteSPV);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CExtendeurFormSite";
            this.Size = new System.Drawing.Size(623, 467);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.PropertyGrid m_gridSiteSPV;
        private System.Windows.Forms.Label labelDomainIP;
        private System.Windows.Forms.Label labelCommunity;
        private System.Windows.Forms.Label labelMediation;
        private System.Windows.Forms.Label labelExDomainIP;
        private System.Windows.Forms.Label labelExCommunity;
        private sc2i.win32.common.C2iTextBox c2iTextBoxDomainIP;
        private sc2i.win32.common.C2iTextBox c2iTextBoxCommunity;
        private sc2i.win32.common.C2iTextBox c2iTextBoxMediation;
        private System.Windows.Forms.CheckedListBox DomainsList;
	}
}
