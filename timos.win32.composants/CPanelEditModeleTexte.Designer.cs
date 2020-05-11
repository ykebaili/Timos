namespace timos.win32.composants
{
	partial class CPanelEditModeleTexte
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
			this.m_exLinkField = new sc2i.win32.common.CExtLinkField();
			this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
			this.label4 = new System.Windows.Forms.Label();
			this.c2iNumericUpDown2 = new sc2i.win32.common.C2iNumericUpDown();
			this.c2iNumericUpDown1 = new sc2i.win32.common.C2iNumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.m_cmbTypeElements = new sc2i.win32.common.C2iComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.c2iPanelOmbre1 = new sc2i.win32.common.C2iPanelOmbre();
			this.m_panelModele = new timos.win32.composants.RichEdit.CPanelRichEditor();
			this.m_btnSelectElementTest = new System.Windows.Forms.Button();
			this.m_btnTest = new System.Windows.Forms.Button();
			this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
			this.m_exStyle = new sc2i.win32.common.CExtStyle();
			this.c2iPanelOmbre4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.c2iNumericUpDown2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.c2iNumericUpDown1)).BeginInit();
			this.c2iPanelOmbre1.SuspendLayout();
			this.SuspendLayout();
			// 
			// c2iPanelOmbre4
			// 
			this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
			this.c2iPanelOmbre4.Controls.Add(this.label4);
			this.c2iPanelOmbre4.Controls.Add(this.c2iNumericUpDown2);
			this.c2iPanelOmbre4.Controls.Add(this.c2iNumericUpDown1);
			this.c2iPanelOmbre4.Controls.Add(this.label3);
			this.c2iPanelOmbre4.Controls.Add(this.m_cmbTypeElements);
			this.c2iPanelOmbre4.Controls.Add(this.label1);
			this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
			this.c2iPanelOmbre4.Controls.Add(this.label2);
			this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
			this.m_exLinkField.SetLinkField(this.c2iPanelOmbre4, "");
			this.c2iPanelOmbre4.Location = new System.Drawing.Point(1, 1);
			this.c2iPanelOmbre4.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
			this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
			this.c2iPanelOmbre4.Size = new System.Drawing.Size(528, 96);
			this.m_exStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
			this.m_exStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
			this.c2iPanelOmbre4.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.m_exLinkField.SetLinkField(this.label4, "");
			this.label4.Location = new System.Drawing.Point(186, 62);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(14, 13);
			this.m_exStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label4.TabIndex = 4008;
			this.label4.Text = "X";
			// 
			// c2iNumericUpDown2
			// 
			this.c2iNumericUpDown2.DoubleValue = 20;
			this.c2iNumericUpDown2.IntValue = 20;
			this.m_exLinkField.SetLinkField(this.c2iNumericUpDown2, "Hauteur");
			this.c2iNumericUpDown2.Location = new System.Drawing.Point(206, 60);
			this.c2iNumericUpDown2.LockEdition = false;
			this.c2iNumericUpDown2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.c2iNumericUpDown2.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.m_gestionnaireModeEdition.SetModeEdition(this.c2iNumericUpDown2, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.c2iNumericUpDown2.Name = "c2iNumericUpDown2";
			this.c2iNumericUpDown2.Size = new System.Drawing.Size(48, 20);
			this.m_exStyle.SetStyleBackColor(this.c2iNumericUpDown2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.c2iNumericUpDown2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.c2iNumericUpDown2.TabIndex = 4007;
			this.c2iNumericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.c2iNumericUpDown2.ThousandsSeparator = true;
			this.c2iNumericUpDown2.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
			// 
			// c2iNumericUpDown1
			// 
			this.c2iNumericUpDown1.DoubleValue = 20;
			this.c2iNumericUpDown1.IntValue = 20;
			this.m_exLinkField.SetLinkField(this.c2iNumericUpDown1, "Largeur");
			this.c2iNumericUpDown1.Location = new System.Drawing.Point(132, 60);
			this.c2iNumericUpDown1.LockEdition = false;
			this.c2iNumericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.c2iNumericUpDown1.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.m_gestionnaireModeEdition.SetModeEdition(this.c2iNumericUpDown1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.c2iNumericUpDown1.Name = "c2iNumericUpDown1";
			this.c2iNumericUpDown1.Size = new System.Drawing.Size(48, 20);
			this.m_exStyle.SetStyleBackColor(this.c2iNumericUpDown1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.c2iNumericUpDown1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.c2iNumericUpDown1.TabIndex = 4006;
			this.c2iNumericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.c2iNumericUpDown1.ThousandsSeparator = true;
			this.c2iNumericUpDown1.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
			// 
			// label3
			// 
			this.m_exLinkField.SetLinkField(this.label3, "");
			this.label3.Location = new System.Drawing.Point(16, 62);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(118, 13);
			this.m_exStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label3.TabIndex = 4005;
			this.label3.Text = "Default size|475";
			// 
			// m_cmbTypeElements
			// 
			this.m_cmbTypeElements.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_cmbTypeElements.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cmbTypeElements.IsLink = false;
			this.m_exLinkField.SetLinkField(this.m_cmbTypeElements, "");
			this.m_cmbTypeElements.Location = new System.Drawing.Point(133, 33);
			this.m_cmbTypeElements.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbTypeElements, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_cmbTypeElements.Name = "m_cmbTypeElements";
			this.m_cmbTypeElements.Size = new System.Drawing.Size(372, 21);
			this.m_exStyle.SetStyleBackColor(this.m_cmbTypeElements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_cmbTypeElements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_cmbTypeElements.TabIndex = 4004;
			this.m_cmbTypeElements.SelectionChangeCommitted += new System.EventHandler(this.m_cmbTypeElements_SelectionChangeCommitted);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.m_exLinkField.SetLinkField(this.label1, "");
			this.label1.Location = new System.Drawing.Point(16, 12);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 13);
			this.m_exStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label1.TabIndex = 4002;
			this.label1.Text = "Label|50";
			// 
			// m_txtLibelle
			// 
			this.m_exLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
			this.m_txtLibelle.Location = new System.Drawing.Point(132, 8);
			this.m_txtLibelle.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_txtLibelle.Name = "m_txtLibelle";
			this.m_txtLibelle.Size = new System.Drawing.Size(373, 20);
			this.m_exStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_txtLibelle.TabIndex = 0;
			this.m_txtLibelle.Text = "[Libelle]";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.m_exLinkField.SetLinkField(this.label2, "");
			this.label2.Location = new System.Drawing.Point(16, 33);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(93, 13);
			this.m_exStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label2.TabIndex = 4003;
			this.label2.Text = "Elements type|472";
			// 
			// c2iPanelOmbre1
			// 
			this.c2iPanelOmbre1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.c2iPanelOmbre1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
			this.c2iPanelOmbre1.Controls.Add(this.m_panelModele);
			this.c2iPanelOmbre1.Controls.Add(this.m_btnSelectElementTest);
			this.c2iPanelOmbre1.Controls.Add(this.m_btnTest);
			this.c2iPanelOmbre1.ForeColor = System.Drawing.Color.Black;
			this.m_exLinkField.SetLinkField(this.c2iPanelOmbre1, "");
			this.c2iPanelOmbre1.Location = new System.Drawing.Point(0, 103);
			this.c2iPanelOmbre1.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre1, sc2i.win32.common.TypeModeEdition.Autonome);
			this.c2iPanelOmbre1.Name = "c2iPanelOmbre1";
			this.c2iPanelOmbre1.Size = new System.Drawing.Size(591, 314);
			this.m_exStyle.SetStyleBackColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
			this.m_exStyle.SetStyleForeColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
			this.c2iPanelOmbre1.TabIndex = 2;
			// 
			// m_panelModele
			// 
			this.m_panelModele.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_exLinkField.SetLinkField(this.m_panelModele, "");
			this.m_panelModele.Location = new System.Drawing.Point(3, 3);
			this.m_panelModele.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelModele, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_panelModele.Name = "m_panelModele";
			this.m_panelModele.Size = new System.Drawing.Size(571, 260);
			this.m_exStyle.SetStyleBackColor(this.m_panelModele, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_panelModele, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_panelModele.TabIndex = 16;
			this.m_panelModele.TextBackColor = System.Drawing.SystemColors.Window;
			this.m_panelModele.TextBoxData = new byte[] {
        ((byte)(123)),
        ((byte)(92)),
        ((byte)(114)),
        ((byte)(116)),
        ((byte)(102)),
        ((byte)(49)),
        ((byte)(92)),
        ((byte)(97)),
        ((byte)(110)),
        ((byte)(115)),
        ((byte)(105)),
        ((byte)(92)),
        ((byte)(97)),
        ((byte)(110)),
        ((byte)(115)),
        ((byte)(105)),
        ((byte)(99)),
        ((byte)(112)),
        ((byte)(103)),
        ((byte)(49)),
        ((byte)(50)),
        ((byte)(53)),
        ((byte)(50)),
        ((byte)(92)),
        ((byte)(100)),
        ((byte)(101)),
        ((byte)(102)),
        ((byte)(102)),
        ((byte)(48)),
        ((byte)(92)),
        ((byte)(100)),
        ((byte)(101)),
        ((byte)(102)),
        ((byte)(108)),
        ((byte)(97)),
        ((byte)(110)),
        ((byte)(103)),
        ((byte)(49)),
        ((byte)(48)),
        ((byte)(51)),
        ((byte)(54)),
        ((byte)(123)),
        ((byte)(92)),
        ((byte)(102)),
        ((byte)(111)),
        ((byte)(110)),
        ((byte)(116)),
        ((byte)(116)),
        ((byte)(98)),
        ((byte)(108)),
        ((byte)(123)),
        ((byte)(92)),
        ((byte)(102)),
        ((byte)(48)),
        ((byte)(92)),
        ((byte)(102)),
        ((byte)(110)),
        ((byte)(105)),
        ((byte)(108)),
        ((byte)(92)),
        ((byte)(102)),
        ((byte)(99)),
        ((byte)(104)),
        ((byte)(97)),
        ((byte)(114)),
        ((byte)(115)),
        ((byte)(101)),
        ((byte)(116)),
        ((byte)(48)),
        ((byte)(32)),
        ((byte)(77)),
        ((byte)(105)),
        ((byte)(99)),
        ((byte)(114)),
        ((byte)(111)),
        ((byte)(115)),
        ((byte)(111)),
        ((byte)(102)),
        ((byte)(116)),
        ((byte)(32)),
        ((byte)(83)),
        ((byte)(97)),
        ((byte)(110)),
        ((byte)(115)),
        ((byte)(32)),
        ((byte)(83)),
        ((byte)(101)),
        ((byte)(114)),
        ((byte)(105)),
        ((byte)(102)),
        ((byte)(59)),
        ((byte)(125)),
        ((byte)(125)),
        ((byte)(13)),
        ((byte)(10)),
        ((byte)(92)),
        ((byte)(118)),
        ((byte)(105)),
        ((byte)(101)),
        ((byte)(119)),
        ((byte)(107)),
        ((byte)(105)),
        ((byte)(110)),
        ((byte)(100)),
        ((byte)(52)),
        ((byte)(92)),
        ((byte)(117)),
        ((byte)(99)),
        ((byte)(49)),
        ((byte)(92)),
        ((byte)(112)),
        ((byte)(97)),
        ((byte)(114)),
        ((byte)(100)),
        ((byte)(92)),
        ((byte)(102)),
        ((byte)(48)),
        ((byte)(92)),
        ((byte)(102)),
        ((byte)(115)),
        ((byte)(49)),
        ((byte)(55)),
        ((byte)(92)),
        ((byte)(112)),
        ((byte)(97)),
        ((byte)(114)),
        ((byte)(13)),
        ((byte)(10)),
        ((byte)(125)),
        ((byte)(13)),
        ((byte)(10)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0))};
			// 
			// m_btnSelectElementTest
			// 
			this.m_btnSelectElementTest.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_btnSelectElementTest.BackColor = System.Drawing.SystemColors.Control;
			this.m_exLinkField.SetLinkField(this.m_btnSelectElementTest, "");
			this.m_btnSelectElementTest.Location = new System.Drawing.Point(65, 269);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnSelectElementTest, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_btnSelectElementTest.Name = "m_btnSelectElementTest";
			this.m_btnSelectElementTest.Size = new System.Drawing.Size(224, 24);
			this.m_exStyle.SetStyleBackColor(this.m_btnSelectElementTest, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_btnSelectElementTest, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_btnSelectElementTest.TabIndex = 15;
			this.m_btnSelectElementTest.Text = "Selectionner un élément pour le test";
			this.m_btnSelectElementTest.UseVisualStyleBackColor = false;
			this.m_btnSelectElementTest.Click += new System.EventHandler(this.m_btnSelectElementTest_Click);
			// 
			// m_btnTest
			// 
			this.m_btnTest.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.m_btnTest.BackColor = System.Drawing.SystemColors.Control;
			this.m_exLinkField.SetLinkField(this.m_btnTest, "");
			this.m_btnTest.Location = new System.Drawing.Point(297, 269);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnTest, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_btnTest.Name = "m_btnTest";
			this.m_btnTest.Size = new System.Drawing.Size(224, 24);
			this.m_exStyle.SetStyleBackColor(this.m_btnTest, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_btnTest, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_btnTest.TabIndex = 14;
			this.m_btnTest.Text = "Tester";
			this.m_btnTest.UseVisualStyleBackColor = false;
			this.m_btnTest.Click += new System.EventHandler(this.m_btnTest_Click);
			// 
			// CPanelEditModeleTexte
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.c2iPanelOmbre1);
			this.Controls.Add(this.c2iPanelOmbre4);
			this.m_exLinkField.SetLinkField(this, "");
			this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
			this.Name = "CPanelEditModeleTexte";
			this.Size = new System.Drawing.Size(591, 420);
			this.m_exStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondFenetre);
			this.m_exStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.c2iPanelOmbre4.ResumeLayout(false);
			this.c2iPanelOmbre4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.c2iNumericUpDown2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.c2iNumericUpDown1)).EndInit();
			this.c2iPanelOmbre1.ResumeLayout(false);
			this.c2iPanelOmbre1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private sc2i.win32.common.CExtLinkField m_exLinkField;
		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private sc2i.win32.common.CExtStyle m_exStyle;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
		private System.Windows.Forms.Label label4;
		private sc2i.win32.common.C2iNumericUpDown c2iNumericUpDown2;
		private sc2i.win32.common.C2iNumericUpDown c2iNumericUpDown1;
		private System.Windows.Forms.Label label3;
		private sc2i.win32.common.C2iComboBox m_cmbTypeElements;
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private System.Windows.Forms.Label label2;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre1;
		private timos.win32.composants.RichEdit.CPanelRichEditor m_panelModele;
		private System.Windows.Forms.Button m_btnSelectElementTest;
		private System.Windows.Forms.Button m_btnTest;
	}
}
