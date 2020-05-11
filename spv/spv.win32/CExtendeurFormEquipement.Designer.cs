namespace spv.win32
{
	partial class CExtendeurFormEquipement
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
            this.labeIPAddress = new System.Windows.Forms.Label();
            this.labelSnmpIndex = new System.Windows.Forms.Label();
            this.labelEquiptTypeRefSnmp = new System.Windows.Forms.Label();
            this.labelSnmpCommunity = new System.Windows.Forms.Label();
            this.labelMediationEquipment = new System.Windows.Forms.Label();
            this.m_txtBoxIPAddress = new sc2i.win32.common.C2iTextBox();
            this.m_txtBoxSnmpIndex = new sc2i.win32.common.C2iTextBox();
            this.m_txtBoxEquiptTypeSnmpReference = new sc2i.win32.common.C2iTextBox();
            this.m_txtBoxSnmpCommunity = new sc2i.win32.common.C2iTextBox();
            this.m_txtBoxMediationEquipment = new sc2i.win32.common.C2iTextBox();
            this.m_chkToSurv = new System.Windows.Forms.CheckBox();
            this.m_chkToRediscover = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // labeIPAddress
            // 
            this.labeIPAddress.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.labeIPAddress, "");
            this.labeIPAddress.Location = new System.Drawing.Point(31, 36);
            this.m_extModeEdition.SetModeEdition(this.labeIPAddress, sc2i.win32.common.TypeModeEdition.Autonome);
            this.labeIPAddress.Name = "labeIPAddress";
            this.labeIPAddress.Size = new System.Drawing.Size(72, 13);
            this.m_extStyle.SetStyleBackColor(this.labeIPAddress, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.labeIPAddress, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.labeIPAddress.TabIndex = 0;
            this.labeIPAddress.Text = "IP Address|27";
            // 
            // labelSnmpIndex
            // 
            this.labelSnmpIndex.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.labelSnmpIndex, "");
            this.labelSnmpIndex.Location = new System.Drawing.Point(31, 75);
            this.m_extModeEdition.SetModeEdition(this.labelSnmpIndex, sc2i.win32.common.TypeModeEdition.Autonome);
            this.labelSnmpIndex.Name = "labelSnmpIndex";
            this.labelSnmpIndex.Size = new System.Drawing.Size(81, 13);
            this.m_extStyle.SetStyleBackColor(this.labelSnmpIndex, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.labelSnmpIndex, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.labelSnmpIndex.TabIndex = 1;
            this.labelSnmpIndex.Text = "SNMP Index|28";
            // 
            // labelEquiptTypeRefSnmp
            // 
            this.labelEquiptTypeRefSnmp.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.labelEquiptTypeRefSnmp, "");
            this.labelEquiptTypeRefSnmp.Location = new System.Drawing.Point(31, 114);
            this.m_extModeEdition.SetModeEdition(this.labelEquiptTypeRefSnmp, sc2i.win32.common.TypeModeEdition.Autonome);
            this.labelEquiptTypeRefSnmp.Name = "labelEquiptTypeRefSnmp";
            this.labelEquiptTypeRefSnmp.Size = new System.Drawing.Size(176, 13);
            this.m_extStyle.SetStyleBackColor(this.labelEquiptTypeRefSnmp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.labelEquiptTypeRefSnmp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.labelEquiptTypeRefSnmp.TabIndex = 2;
            this.labelEquiptTypeRefSnmp.Text = "Equipment type SNMP reference|29";
            // 
            // labelSnmpCommunity
            // 
            this.labelSnmpCommunity.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.labelSnmpCommunity, "");
            this.labelSnmpCommunity.Location = new System.Drawing.Point(31, 153);
            this.m_extModeEdition.SetModeEdition(this.labelSnmpCommunity, sc2i.win32.common.TypeModeEdition.Autonome);
            this.labelSnmpCommunity.Name = "labelSnmpCommunity";
            this.labelSnmpCommunity.Size = new System.Drawing.Size(106, 13);
            this.m_extStyle.SetStyleBackColor(this.labelSnmpCommunity, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.labelSnmpCommunity, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.labelSnmpCommunity.TabIndex = 3;
            this.labelSnmpCommunity.Text = "SNMP Community|30";
            // 
            // labelMediationEquipment
            // 
            this.labelMediationEquipment.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.labelMediationEquipment, "");
            this.labelMediationEquipment.Location = new System.Drawing.Point(31, 192);
            this.m_extModeEdition.SetModeEdition(this.labelMediationEquipment, sc2i.win32.common.TypeModeEdition.Autonome);
            this.labelMediationEquipment.Name = "labelMediationEquipment";
            this.labelMediationEquipment.Size = new System.Drawing.Size(119, 13);
            this.m_extStyle.SetStyleBackColor(this.labelMediationEquipment, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.labelMediationEquipment, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.labelMediationEquipment.TabIndex = 4;
            this.labelMediationEquipment.Text = "Mediation equipment|31";
            // 
            // m_txtBoxIPAddress
            // 
            this.m_extLinkField.SetLinkField(this.m_txtBoxIPAddress, "");
            this.m_txtBoxIPAddress.Location = new System.Drawing.Point(225, 33);
            this.m_txtBoxIPAddress.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtBoxIPAddress, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtBoxIPAddress.Name = "m_txtBoxIPAddress";
            this.m_txtBoxIPAddress.Size = new System.Drawing.Size(176, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtBoxIPAddress, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtBoxIPAddress, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtBoxIPAddress.TabIndex = 10;
            this.m_txtBoxIPAddress.Text = "[IPAddress]";
            // 
            // m_txtBoxSnmpIndex
            // 
            this.m_extLinkField.SetLinkField(this.m_txtBoxSnmpIndex, "");
            this.m_txtBoxSnmpIndex.Location = new System.Drawing.Point(225, 72);
            this.m_txtBoxSnmpIndex.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtBoxSnmpIndex, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtBoxSnmpIndex.Name = "m_txtBoxSnmpIndex";
            this.m_txtBoxSnmpIndex.Size = new System.Drawing.Size(268, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtBoxSnmpIndex, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtBoxSnmpIndex, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtBoxSnmpIndex.TabIndex = 11;
            this.m_txtBoxSnmpIndex.Text = "[SnmpIndex]";
            // 
            // m_txtBoxEquiptTypeSnmpReference
            // 
            this.m_extLinkField.SetLinkField(this.m_txtBoxEquiptTypeSnmpReference, "");
            this.m_txtBoxEquiptTypeSnmpReference.Location = new System.Drawing.Point(225, 111);
            this.m_txtBoxEquiptTypeSnmpReference.LockEdition = true;
            this.m_extModeEdition.SetModeEdition(this.m_txtBoxEquiptTypeSnmpReference, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtBoxEquiptTypeSnmpReference.Name = "m_txtBoxEquiptTypeSnmpReference";
            this.m_txtBoxEquiptTypeSnmpReference.Size = new System.Drawing.Size(268, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtBoxEquiptTypeSnmpReference, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtBoxEquiptTypeSnmpReference, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtBoxEquiptTypeSnmpReference.TabIndex = 12;
            this.m_txtBoxEquiptTypeSnmpReference.Text = "[EquipmentTypeSnmpReference]";
            // 
            // m_txtBoxSnmpCommunity
            // 
            this.m_extLinkField.SetLinkField(this.m_txtBoxSnmpCommunity, "");
            this.m_txtBoxSnmpCommunity.Location = new System.Drawing.Point(225, 150);
            this.m_txtBoxSnmpCommunity.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtBoxSnmpCommunity, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtBoxSnmpCommunity.Name = "m_txtBoxSnmpCommunity";
            this.m_txtBoxSnmpCommunity.Size = new System.Drawing.Size(268, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtBoxSnmpCommunity, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtBoxSnmpCommunity, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtBoxSnmpCommunity.TabIndex = 13;
            this.m_txtBoxSnmpCommunity.Text = "[SnmpCommunity]";
            // 
            // m_txtBoxMediationEquipment
            // 
            this.m_extLinkField.SetLinkField(this.m_txtBoxMediationEquipment, "");
            this.m_txtBoxMediationEquipment.Location = new System.Drawing.Point(225, 189);
            this.m_txtBoxMediationEquipment.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtBoxMediationEquipment, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtBoxMediationEquipment.Name = "m_txtBoxMediationEquipment";
            this.m_txtBoxMediationEquipment.Size = new System.Drawing.Size(268, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtBoxMediationEquipment, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtBoxMediationEquipment, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtBoxMediationEquipment.TabIndex = 14;
            this.m_txtBoxMediationEquipment.Text = "[MediationEquipment]";
            // 
            // m_chkToSurv
            // 
            this.m_chkToSurv.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkToSurv, "");
            this.m_chkToSurv.Location = new System.Drawing.Point(34, 239);
            this.m_extModeEdition.SetModeEdition(this.m_chkToSurv, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkToSurv.Name = "m_chkToSurv";
            this.m_chkToSurv.Size = new System.Drawing.Size(90, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkToSurv, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkToSurv, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkToSurv.TabIndex = 15;
            this.m_chkToSurv.Text = "To monitor|26";
            this.m_chkToSurv.UseVisualStyleBackColor = true;
            // 
            // m_chkToRediscover
            // 
            this.m_chkToRediscover.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkToRediscover, "");
            this.m_chkToRediscover.Location = new System.Drawing.Point(34, 282);
            this.m_extModeEdition.SetModeEdition(this.m_chkToRediscover, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkToRediscover.Name = "m_chkToRediscover";
            this.m_chkToRediscover.Size = new System.Drawing.Size(160, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkToRediscover, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkToRediscover, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkToRediscover.TabIndex = 16;
            this.m_chkToRediscover.Text = "To rediscover periodically|32";
            this.m_chkToRediscover.UseVisualStyleBackColor = true;
            // 
            // CExtendeurFormEquipement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_chkToRediscover);
            this.Controls.Add(this.m_chkToSurv);
            this.Controls.Add(this.m_txtBoxMediationEquipment);
            this.Controls.Add(this.m_txtBoxSnmpCommunity);
            this.Controls.Add(this.m_txtBoxEquiptTypeSnmpReference);
            this.Controls.Add(this.m_txtBoxSnmpIndex);
            this.Controls.Add(this.m_txtBoxIPAddress);
            this.Controls.Add(this.labelMediationEquipment);
            this.Controls.Add(this.labelSnmpCommunity);
            this.Controls.Add(this.labelEquiptTypeRefSnmp);
            this.Controls.Add(this.labelSnmpIndex);
            this.Controls.Add(this.labeIPAddress);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CExtendeurFormEquipement";
            this.Size = new System.Drawing.Size(511, 322);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.Label labeIPAddress;
        private System.Windows.Forms.Label labelSnmpIndex;
        private System.Windows.Forms.Label labelEquiptTypeRefSnmp;
        private System.Windows.Forms.Label labelSnmpCommunity;
        private System.Windows.Forms.Label labelMediationEquipment;
        private sc2i.win32.common.C2iTextBox m_txtBoxIPAddress;
        private sc2i.win32.common.C2iTextBox m_txtBoxSnmpIndex;
        private sc2i.win32.common.C2iTextBox m_txtBoxEquiptTypeSnmpReference;
        private sc2i.win32.common.C2iTextBox m_txtBoxSnmpCommunity;
        private sc2i.win32.common.C2iTextBox m_txtBoxMediationEquipment;
        private System.Windows.Forms.CheckBox m_chkToSurv;
        private System.Windows.Forms.CheckBox m_chkToRediscover;

    }
}
