namespace spv.win32
{
	partial class CExtendeurFormEquipementDoneesSNMP
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_btnTableValues = new System.Windows.Forms.Button();
            this.m_lstTables = new spv.win32.CListeViewOptimiseeParLigne();
            this.m_lstTableVariables = new spv.win32.CListeViewOptimiseeParLigne();
            this.m_listSnmpValues = new spv.win32.CListeViewOptimiseeParLigne();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.m_extModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 1;
            this.label1.Text = "SNMP Variables|60069";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(3, 306);
            this.m_extModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 2;
            this.label2.Text = "SNMP table(s)|60070";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(338, 306);
            this.m_extModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 13);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 5;
            this.label3.Text = "SNMP table variables|60071";
            // 
            // m_btnTableValues
            // 
            this.m_extLinkField.SetLinkField(this.m_btnTableValues, "");
            this.m_btnTableValues.Location = new System.Drawing.Point(253, 428);
            this.m_extModeEdition.SetModeEdition(this.m_btnTableValues, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnTableValues.Name = "m_btnTableValues";
            this.m_btnTableValues.Size = new System.Drawing.Size(75, 23);
            this.m_extStyle.SetStyleBackColor(this.m_btnTableValues, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnTableValues, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnTableValues.TabIndex = 7;
            this.m_btnTableValues.Text = "Variables|60072";
            this.m_btnTableValues.UseVisualStyleBackColor = true;
            this.m_btnTableValues.Click += new System.EventHandler(this.m_btnTableValues_Click);
            // 
            // m_lstTables
            // 
            this.m_lstTables.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lstTables.FullRowSelect = true;
            this.m_lstTables.GridLines = true;
            this.m_lstTables.HideSelection = false;
            this.m_lstTables.LabelWrap = false;
            this.m_extLinkField.SetLinkField(this.m_lstTables, "");
            this.m_lstTables.Location = new System.Drawing.Point(3, 336);
            this.m_extModeEdition.SetModeEdition(this.m_lstTables, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lstTables.Name = "m_lstTables";
            this.m_lstTables.Size = new System.Drawing.Size(240, 247);
            this.m_extStyle.SetStyleBackColor(this.m_lstTables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lstTables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lstTables.TabIndex = 6;
            this.m_lstTables.UseCompatibleStateImageBehavior = false;
            this.m_lstTables.View = System.Windows.Forms.View.Details;
            this.m_lstTables.VirtualListSize = 150;
            this.m_lstTables.VirtualMode = true;
            this.m_lstTables.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.m_lstTables_MouseDoubleClick);
            // 
            // m_lstTableVariables
            // 
            this.m_lstTableVariables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lstTableVariables.FullRowSelect = true;
            this.m_lstTableVariables.GridLines = true;
            this.m_lstTableVariables.HideSelection = false;
            this.m_extLinkField.SetLinkField(this.m_lstTableVariables, "");
            this.m_lstTableVariables.Location = new System.Drawing.Point(338, 336);
            this.m_extModeEdition.SetModeEdition(this.m_lstTableVariables, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lstTableVariables.Name = "m_lstTableVariables";
            this.m_lstTableVariables.Size = new System.Drawing.Size(512, 247);
            this.m_extStyle.SetStyleBackColor(this.m_lstTableVariables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lstTableVariables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lstTableVariables.TabIndex = 4;
            this.m_lstTableVariables.UseCompatibleStateImageBehavior = false;
            this.m_lstTableVariables.View = System.Windows.Forms.View.Details;
            this.m_lstTableVariables.VirtualListSize = 150;
            this.m_lstTableVariables.VirtualMode = true;
            // 
            // m_listSnmpValues
            // 
            this.m_listSnmpValues.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_listSnmpValues.FullRowSelect = true;
            this.m_listSnmpValues.GridLines = true;
            this.m_listSnmpValues.HideSelection = false;
            this.m_extLinkField.SetLinkField(this.m_listSnmpValues, "");
            this.m_listSnmpValues.Location = new System.Drawing.Point(3, 36);
            this.m_extModeEdition.SetModeEdition(this.m_listSnmpValues, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_listSnmpValues.Name = "m_listSnmpValues";
            this.m_listSnmpValues.Size = new System.Drawing.Size(848, 253);
            this.m_extStyle.SetStyleBackColor(this.m_listSnmpValues, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_listSnmpValues, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_listSnmpValues.TabIndex = 0;
            this.m_listSnmpValues.UseCompatibleStateImageBehavior = false;
            this.m_listSnmpValues.View = System.Windows.Forms.View.Details;
            this.m_listSnmpValues.VirtualListSize = 150;
            this.m_listSnmpValues.VirtualMode = true;
            this.m_listSnmpValues.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.m_listSnmpValues_MouseDoubleClick);
            // 
            // CExtendeurFormEquipementDoneesSNMP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_btnTableValues);
            this.Controls.Add(this.m_lstTables);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_lstTableVariables);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_listSnmpValues);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CExtendeurFormEquipementDoneesSNMP";
            this.Size = new System.Drawing.Size(871, 599);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private CListeViewOptimiseeParLigne m_listSnmpValues;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private CListeViewOptimiseeParLigne m_lstTableVariables;
        private System.Windows.Forms.Label label3;
        private CListeViewOptimiseeParLigne m_lstTables;
        private System.Windows.Forms.Button m_btnTableValues;


    }
}
