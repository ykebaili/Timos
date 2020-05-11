namespace spv.win32
{
	partial class CExtendeurFormSite
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
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CExtendeurFormSite));
            sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn3 = new sc2i.win32.common.GLColumn();
            this.labelDomainIP = new System.Windows.Forms.Label();
            this.labelCommunity = new System.Windows.Forms.Label();
            this.labelMediation = new System.Windows.Forms.Label();
            this.labelExDomainIP = new System.Windows.Forms.Label();
            this.labelExCommunity = new System.Windows.Forms.Label();
            this.m_txtBoxDomaineIp = new sc2i.win32.common.C2iTextBox();
            this.m_txtBoxCommunity = new sc2i.win32.common.C2iTextBox();
            this.m_txtBoxMediation = new sc2i.win32.common.C2iTextBox();
            this.m_CablageAccesAlarm = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_PanelTypeAccessAlarm = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_buttonStartAlarm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelDomainIP
            // 
            this.labelDomainIP.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.labelDomainIP, "");
            this.labelDomainIP.Location = new System.Drawing.Point(23, 16);
            this.m_extModeEdition.SetModeEdition(this.labelDomainIP, sc2i.win32.common.TypeModeEdition.Autonome);
            this.labelDomainIP.Name = "labelDomainIP";
            this.labelDomainIP.Size = new System.Drawing.Size(70, 13);
            this.m_extStyle.SetStyleBackColor(this.labelDomainIP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.labelDomainIP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.labelDomainIP.TabIndex = 4;
            this.labelDomainIP.Text = "Domain IP|10";
            // 
            // labelCommunity
            // 
            this.labelCommunity.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.labelCommunity, "");
            this.labelCommunity.Location = new System.Drawing.Point(23, 42);
            this.m_extModeEdition.SetModeEdition(this.labelCommunity, sc2i.win32.common.TypeModeEdition.Autonome);
            this.labelCommunity.Name = "labelCommunity";
            this.labelCommunity.Size = new System.Drawing.Size(106, 13);
            this.m_extStyle.SetStyleBackColor(this.labelCommunity, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.labelCommunity, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.labelCommunity.TabIndex = 5;
            this.labelCommunity.Text = "SNMP Community|11";
            // 
            // labelMediation
            // 
            this.labelMediation.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.labelMediation, "");
            this.labelMediation.Location = new System.Drawing.Point(23, 68);
            this.m_extModeEdition.SetModeEdition(this.labelMediation, sc2i.win32.common.TypeModeEdition.Autonome);
            this.labelMediation.Name = "labelMediation";
            this.labelMediation.Size = new System.Drawing.Size(67, 13);
            this.m_extStyle.SetStyleBackColor(this.labelMediation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.labelMediation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.labelMediation.TabIndex = 7;
            this.labelMediation.Text = "Mediation|12";
            // 
            // labelExDomainIP
            // 
            this.labelExDomainIP.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.labelExDomainIP, "");
            this.labelExDomainIP.Location = new System.Drawing.Point(370, 22);
            this.m_extModeEdition.SetModeEdition(this.labelExDomainIP, sc2i.win32.common.TypeModeEdition.Autonome);
            this.labelExDomainIP.Name = "labelExDomainIP";
            this.labelExDomainIP.Size = new System.Drawing.Size(146, 13);
            this.m_extStyle.SetStyleBackColor(this.labelExDomainIP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.labelExDomainIP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.labelExDomainIP.TabIndex = 8;
            this.labelExDomainIP.Text = "(ex. 193.7.49.[1-10]), etc...|14";
            // 
            // labelExCommunity
            // 
            this.labelExCommunity.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.labelExCommunity, "");
            this.labelExCommunity.Location = new System.Drawing.Point(370, 48);
            this.m_extModeEdition.SetModeEdition(this.labelExCommunity, sc2i.win32.common.TypeModeEdition.Autonome);
            this.labelExCommunity.Name = "labelExCommunity";
            this.labelExCommunity.Size = new System.Drawing.Size(72, 13);
            this.m_extStyle.SetStyleBackColor(this.labelExCommunity, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.labelExCommunity, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.labelExCommunity.TabIndex = 9;
            this.labelExCommunity.Text = "(ex. public)|13";
            // 
            // m_txtBoxDomaineIp
            // 
            this.m_extLinkField.SetLinkField(this.m_txtBoxDomaineIp, "");
            this.m_txtBoxDomaineIp.Location = new System.Drawing.Point(130, 16);
            this.m_txtBoxDomaineIp.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtBoxDomaineIp, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtBoxDomaineIp.Name = "m_txtBoxDomaineIp";
            this.m_txtBoxDomaineIp.Size = new System.Drawing.Size(234, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtBoxDomaineIp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtBoxDomaineIp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtBoxDomaineIp.TabIndex = 3;
            this.m_txtBoxDomaineIp.Text = "[SiteDomaineIP]";
            // 
            // m_txtBoxCommunity
            // 
            this.m_extLinkField.SetLinkField(this.m_txtBoxCommunity, "");
            this.m_txtBoxCommunity.Location = new System.Drawing.Point(130, 42);
            this.m_txtBoxCommunity.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtBoxCommunity, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtBoxCommunity.Name = "m_txtBoxCommunity";
            this.m_txtBoxCommunity.Size = new System.Drawing.Size(234, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtBoxCommunity, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtBoxCommunity, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtBoxCommunity.TabIndex = 10;
            this.m_txtBoxCommunity.Text = "[SiteCmnte]";
            // 
            // m_txtBoxMediation
            // 
            this.m_extLinkField.SetLinkField(this.m_txtBoxMediation, "");
            this.m_txtBoxMediation.Location = new System.Drawing.Point(130, 68);
            this.m_txtBoxMediation.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtBoxMediation, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtBoxMediation.Name = "m_txtBoxMediation";
            this.m_txtBoxMediation.Size = new System.Drawing.Size(234, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtBoxMediation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtBoxMediation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtBoxMediation.TabIndex = 11;
            this.m_txtBoxMediation.Text = "[SiteEmName]";
            // 
            // m_CablageAccesAlarm
            // 
            this.m_CablageAccesAlarm.AllowArbre = true;
            this.m_CablageAccesAlarm.AllowCustomisation = true;
            this.m_CablageAccesAlarm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "AccesSortie";
            glColumn1.Propriete = "AccesAlarmeOne.NomAcces";
            glColumn1.Text = "Label|3";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 100;
            this.m_CablageAccesAlarm.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1});
            this.m_CablageAccesAlarm.ContexteUtilisation = "";
            this.m_CablageAccesAlarm.ControlFiltreStandard = null;
            this.m_CablageAccesAlarm.ElementSelectionne = null;
            this.m_CablageAccesAlarm.EnableCustomisation = true;
            this.m_CablageAccesAlarm.FiltreDeBase = null;
            this.m_CablageAccesAlarm.FiltreDeBaseEnAjout = false;
            this.m_CablageAccesAlarm.FiltrePrefere = null;
            this.m_CablageAccesAlarm.FiltreRapide = null;
            this.m_CablageAccesAlarm.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_CablageAccesAlarm, "");
            this.m_CablageAccesAlarm.ListeObjets = null;
            this.m_CablageAccesAlarm.Location = new System.Drawing.Point(10, 346);
            this.m_CablageAccesAlarm.LockEdition = true;
            this.m_extModeEdition.SetModeEdition(this.m_CablageAccesAlarm, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_CablageAccesAlarm.ModeQuickSearch = false;
            this.m_CablageAccesAlarm.ModeSelection = false;
            this.m_CablageAccesAlarm.MultiSelect = false;
            this.m_CablageAccesAlarm.Name = "m_CablageAccesAlarm";
            this.m_CablageAccesAlarm.Navigateur = null;
            this.m_CablageAccesAlarm.ProprieteObjetAEditer = null;
            this.m_CablageAccesAlarm.QuickSearchText = "";
            this.m_CablageAccesAlarm.Size = new System.Drawing.Size(725, 177);
            this.m_extStyle.SetStyleBackColor(this.m_CablageAccesAlarm, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_CablageAccesAlarm, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_CablageAccesAlarm.TabIndex = 19;
            this.m_CablageAccesAlarm.TrierAuClicSurEnteteColonne = true;
            this.m_CablageAccesAlarm.UseCheckBoxes = false;
            // 
            // m_PanelTypeAccessAlarm
            // 
            this.m_PanelTypeAccessAlarm.AllowArbre = true;
            this.m_PanelTypeAccessAlarm.AllowCustomisation = true;
            this.m_PanelTypeAccessAlarm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            glColumn2.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn2.ActiveControlItems")));
            glColumn2.BackColor = System.Drawing.Color.Transparent;
            glColumn2.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn2.ForColor = System.Drawing.Color.Black;
            glColumn2.ImageIndex = -1;
            glColumn2.IsCheckColumn = false;
            glColumn2.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn2.Name = "Name";
            glColumn2.Propriete = "NomAcces";
            glColumn2.Text = "Label|3";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 100;
            glColumn3.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn3.ActiveControlItems")));
            glColumn3.BackColor = System.Drawing.Color.Transparent;
            glColumn3.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn3.ForColor = System.Drawing.Color.Black;
            glColumn3.ImageIndex = -1;
            glColumn3.IsCheckColumn = false;
            glColumn3.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn3.Name = "Type";
            glColumn3.Propriete = "CategorieAccesAlarme.Libelle";
            glColumn3.Text = "Access type|4";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn3.Width = 100;
            this.m_PanelTypeAccessAlarm.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn2,
            glColumn3});
            this.m_PanelTypeAccessAlarm.ContexteUtilisation = "";
            this.m_PanelTypeAccessAlarm.ControlFiltreStandard = null;
            this.m_PanelTypeAccessAlarm.ElementSelectionne = null;
            this.m_PanelTypeAccessAlarm.EnableCustomisation = true;
            this.m_PanelTypeAccessAlarm.FiltreDeBase = null;
            this.m_PanelTypeAccessAlarm.FiltreDeBaseEnAjout = false;
            this.m_PanelTypeAccessAlarm.FiltrePrefere = null;
            this.m_PanelTypeAccessAlarm.FiltreRapide = null;
            this.m_PanelTypeAccessAlarm.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_PanelTypeAccessAlarm, "");
            this.m_PanelTypeAccessAlarm.ListeObjets = null;
            this.m_PanelTypeAccessAlarm.Location = new System.Drawing.Point(10, 124);
            this.m_PanelTypeAccessAlarm.LockEdition = true;
            this.m_extModeEdition.SetModeEdition(this.m_PanelTypeAccessAlarm, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_PanelTypeAccessAlarm.ModeQuickSearch = false;
            this.m_PanelTypeAccessAlarm.ModeSelection = false;
            this.m_PanelTypeAccessAlarm.MultiSelect = false;
            this.m_PanelTypeAccessAlarm.Name = "m_PanelTypeAccessAlarm";
            this.m_PanelTypeAccessAlarm.Navigateur = null;
            this.m_PanelTypeAccessAlarm.ProprieteObjetAEditer = null;
            this.m_PanelTypeAccessAlarm.QuickSearchText = "";
            this.m_PanelTypeAccessAlarm.Size = new System.Drawing.Size(725, 177);
            this.m_extStyle.SetStyleBackColor(this.m_PanelTypeAccessAlarm, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_PanelTypeAccessAlarm, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_PanelTypeAccessAlarm.TabIndex = 15;
            this.m_PanelTypeAccessAlarm.TrierAuClicSurEnteteColonne = true;
            this.m_PanelTypeAccessAlarm.UseCheckBoxes = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(10, 96);
            this.m_extModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 25);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 21;
            this.label3.Text = "Alarm access|100";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.label1.Location = new System.Drawing.Point(10, 319);
            this.m_extModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 25);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 22;
            this.label1.Text = "Alarm access loop wiring|101";
            // 
            // m_buttonStartAlarm
            // 
            this.m_buttonStartAlarm.BackColor = System.Drawing.Color.LightSteelBlue;
            this.m_buttonStartAlarm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_buttonStartAlarm.ForeColor = System.Drawing.Color.MediumBlue;
            this.m_extLinkField.SetLinkField(this.m_buttonStartAlarm, "");
            this.m_buttonStartAlarm.Location = new System.Drawing.Point(392, 346);
            this.m_extModeEdition.SetModeEdition(this.m_buttonStartAlarm, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_buttonStartAlarm.Name = "m_buttonStartAlarm";
            this.m_buttonStartAlarm.Size = new System.Drawing.Size(101, 23);
            this.m_extStyle.SetStyleBackColor(this.m_buttonStartAlarm, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_buttonStartAlarm, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_buttonStartAlarm.TabIndex = 23;
            this.m_buttonStartAlarm.Text = "Start alarm|50068";
            this.m_buttonStartAlarm.UseVisualStyleBackColor = false;
            this.m_buttonStartAlarm.Click += new System.EventHandler(this.m_buttonStartAlarm_Click);
            // 
            // CExtendeurFormSite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.m_buttonStartAlarm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_CablageAccesAlarm);
            this.Controls.Add(this.m_PanelTypeAccessAlarm);
            this.Controls.Add(this.m_txtBoxMediation);
            this.Controls.Add(this.m_txtBoxCommunity);
            this.Controls.Add(this.labelExCommunity);
            this.Controls.Add(this.labelExDomainIP);
            this.Controls.Add(this.labelMediation);
            this.Controls.Add(this.labelCommunity);
            this.Controls.Add(this.labelDomainIP);
            this.Controls.Add(this.m_txtBoxDomaineIp);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CExtendeurFormSite";
            this.Size = new System.Drawing.Size(749, 546);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelDomainIP;
        private System.Windows.Forms.Label labelCommunity;
        private System.Windows.Forms.Label labelMediation;
        private System.Windows.Forms.Label labelExDomainIP;
        private System.Windows.Forms.Label labelExCommunity;
        private sc2i.win32.common.C2iTextBox m_txtBoxDomaineIp;
        private sc2i.win32.common.C2iTextBox m_txtBoxCommunity;
        private sc2i.win32.common.C2iTextBox m_txtBoxMediation;
        private sc2i.win32.data.navigation.CPanelListeSpeedStandard m_PanelTypeAccessAlarm;
        private sc2i.win32.data.navigation.CPanelListeSpeedStandard m_CablageAccesAlarm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button m_buttonStartAlarm;
	}
}
