namespace timos
{
	partial class CPanEditWndLienDeProjet
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
			this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
			this.m_lblElementA = new System.Windows.Forms.Label();
			this.m_lblElementB = new System.Windows.Forms.Label();
			this.m_lblDescripElementA = new System.Windows.Forms.Label();
			this.m_lblDescripElementB = new System.Windows.Forms.Label();
			this.m_lblAttacheA = new System.Windows.Forms.Label();
			this.m_lblTolerance = new System.Windows.Forms.Label();
			this.m_lblFormule = new System.Windows.Forms.Label();
			this.m_wndFormule = new sc2i.win32.expression.CTextBoxZoomFormule();
			this.m_panAno = new System.Windows.Forms.Panel();
			this.m_ctrlAnomalies = new timos.CCtrlViewAnomaliesAIElementDeProjet();
			this.m_panTitreAnomalies = new System.Windows.Forms.Panel();
			this.m_lblTitreAnomalies = new System.Windows.Forms.Label();
			this.m_panEditLien = new System.Windows.Forms.Panel();
			this.m_txtTolerance = new sc2i.win32.common.C2iTextBoxNumerique();
			this.m_chkNoTol = new System.Windows.Forms.CheckBox();
			this.m_txtTypeLiaison = new System.Windows.Forms.TextBox();
			this.m_panAttacheA = new System.Windows.Forms.Panel();
			this.m_rbtFinA = new System.Windows.Forms.RadioButton();
			this.m_rbtDebutA = new System.Windows.Forms.RadioButton();
			this.m_panAttacheB = new System.Windows.Forms.Panel();
			this.m_rbtFinB = new System.Windows.Forms.RadioButton();
			this.m_rbtDebutB = new System.Windows.Forms.RadioButton();
			this.m_lblAttacheB = new System.Windows.Forms.Label();
			this.m_tooltip = new System.Windows.Forms.ToolTip(this.components);
			this.m_extLinkField = new sc2i.win32.common.CExtLinkField();
			this.m_panAno.SuspendLayout();
			this.m_panTitreAnomalies.SuspendLayout();
			this.m_panEditLien.SuspendLayout();
			this.m_panAttacheA.SuspendLayout();
			this.m_panAttacheB.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_lblElementA
			// 
			this.m_extLinkField.SetLinkField(this.m_lblElementA, "");
			this.m_lblElementA.Location = new System.Drawing.Point(1, 5);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblElementA, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_lblElementA.Name = "m_lblElementA";
			this.m_lblElementA.Size = new System.Drawing.Size(85, 17);
			this.m_lblElementA.TabIndex = 1;
			this.m_lblElementA.Text = "Element A|1246";
			// 
			// m_lblElementB
			// 
			this.m_extLinkField.SetLinkField(this.m_lblElementB, "");
			this.m_lblElementB.Location = new System.Drawing.Point(1, 28);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblElementB, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_lblElementB.Name = "m_lblElementB";
			this.m_lblElementB.Size = new System.Drawing.Size(85, 17);
			this.m_lblElementB.TabIndex = 1;
			this.m_lblElementB.Text = "Element B|1247";
			// 
			// m_lblDescripElementA
			// 
			this.m_lblDescripElementA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_extLinkField.SetLinkField(this.m_lblDescripElementA, "ElementA.DescriptionElement");
			this.m_lblDescripElementA.Location = new System.Drawing.Point(92, 5);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblDescripElementA, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_lblDescripElementA.Name = "m_lblDescripElementA";
			this.m_lblDescripElementA.Size = new System.Drawing.Size(165, 17);
			this.m_lblDescripElementA.TabIndex = 1;
			this.m_lblDescripElementA.Text = "[ElementA.DescriptionElement]";
			// 
			// m_lblDescripElementB
			// 
			this.m_lblDescripElementB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_extLinkField.SetLinkField(this.m_lblDescripElementB, "ElementB.DescriptionElement");
			this.m_lblDescripElementB.Location = new System.Drawing.Point(92, 28);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblDescripElementB, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_lblDescripElementB.Name = "m_lblDescripElementB";
			this.m_lblDescripElementB.Size = new System.Drawing.Size(165, 17);
			this.m_lblDescripElementB.TabIndex = 1;
			this.m_lblDescripElementB.Text = "[ElementB.DescriptionElement]";
			// 
			// m_lblAttacheA
			// 
			this.m_extLinkField.SetLinkField(this.m_lblAttacheA, "");
			this.m_lblAttacheA.Location = new System.Drawing.Point(1, 54);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblAttacheA, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_lblAttacheA.Name = "m_lblAttacheA";
			this.m_lblAttacheA.Size = new System.Drawing.Size(127, 18);
			this.m_lblAttacheA.TabIndex = 1;
			this.m_lblAttacheA.Text = "Link A|1263";
			// 
			// m_lblTolerance
			// 
			this.m_extLinkField.SetLinkField(this.m_lblTolerance, "");
			this.m_lblTolerance.Location = new System.Drawing.Point(1, 145);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblTolerance, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_lblTolerance.Name = "m_lblTolerance";
			this.m_lblTolerance.Size = new System.Drawing.Size(85, 17);
			this.m_lblTolerance.TabIndex = 1;
			this.m_lblTolerance.Text = "Tolerance|1249";
			// 
			// m_lblFormule
			// 
			this.m_lblFormule.AutoSize = true;
			this.m_extLinkField.SetLinkField(this.m_lblFormule, "");
			this.m_lblFormule.Location = new System.Drawing.Point(6, 170);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblFormule, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_lblFormule.Name = "m_lblFormule";
			this.m_lblFormule.Size = new System.Drawing.Size(101, 13);
			this.m_lblFormule.TabIndex = 7;
			this.m_lblFormule.Text = "Start condition|1250";
			// 
			// m_wndFormule
			// 
			this.m_wndFormule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_wndFormule.Formule = null;
			this.m_extLinkField.SetLinkField(this.m_wndFormule, "");
			this.m_wndFormule.Location = new System.Drawing.Point(9, 186);
			this.m_wndFormule.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndFormule, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_wndFormule.Name = "m_wndFormule";
			this.m_wndFormule.Size = new System.Drawing.Size(251, 23);
			this.m_wndFormule.TabIndex = 6;
			// 
			// m_panAno
			// 
			this.m_panAno.Controls.Add(this.m_ctrlAnomalies);
			this.m_panAno.Controls.Add(this.m_panTitreAnomalies);
			this.m_panAno.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_extLinkField.SetLinkField(this.m_panAno, "");
			this.m_panAno.Location = new System.Drawing.Point(0, 217);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panAno, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_panAno.Name = "m_panAno";
			this.m_panAno.Size = new System.Drawing.Size(265, 129);
			this.m_panAno.TabIndex = 4029;
			// 
			// m_ctrlAnomalies
			// 
			this.m_ctrlAnomalies.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_extLinkField.SetLinkField(this.m_ctrlAnomalies, "");
			this.m_ctrlAnomalies.Location = new System.Drawing.Point(0, 23);
			this.m_ctrlAnomalies.LockEdition = true;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_ctrlAnomalies, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_ctrlAnomalies.Name = "m_ctrlAnomalies";
			this.m_ctrlAnomalies.Size = new System.Drawing.Size(265, 106);
			this.m_ctrlAnomalies.TabIndex = 0;
			// 
			// m_panTitreAnomalies
			// 
			this.m_panTitreAnomalies.Controls.Add(this.m_lblTitreAnomalies);
			this.m_panTitreAnomalies.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_extLinkField.SetLinkField(this.m_panTitreAnomalies, "");
			this.m_panTitreAnomalies.Location = new System.Drawing.Point(0, 0);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panTitreAnomalies, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_panTitreAnomalies.Name = "m_panTitreAnomalies";
			this.m_panTitreAnomalies.Size = new System.Drawing.Size(265, 23);
			this.m_panTitreAnomalies.TabIndex = 1;
			// 
			// m_lblTitreAnomalies
			// 
			this.m_lblTitreAnomalies.ForeColor = System.Drawing.Color.Black;
			this.m_extLinkField.SetLinkField(this.m_lblTitreAnomalies, "");
			this.m_lblTitreAnomalies.Location = new System.Drawing.Point(6, 6);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblTitreAnomalies, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_lblTitreAnomalies.Name = "m_lblTitreAnomalies";
			this.m_lblTitreAnomalies.Size = new System.Drawing.Size(131, 14);
			this.m_lblTitreAnomalies.TabIndex = 4023;
			this.m_lblTitreAnomalies.Text = "Warnings :|1245";
			// 
			// m_panEditLien
			// 
			this.m_panEditLien.Controls.Add(this.m_txtTolerance);
			this.m_panEditLien.Controls.Add(this.m_chkNoTol);
			this.m_panEditLien.Controls.Add(this.m_txtTypeLiaison);
			this.m_panEditLien.Controls.Add(this.m_panAttacheA);
			this.m_panEditLien.Controls.Add(this.m_panAttacheB);
			this.m_panEditLien.Controls.Add(this.m_lblFormule);
			this.m_panEditLien.Controls.Add(this.m_wndFormule);
			this.m_panEditLien.Controls.Add(this.m_lblTolerance);
			this.m_panEditLien.Controls.Add(this.m_lblAttacheB);
			this.m_panEditLien.Controls.Add(this.m_lblAttacheA);
			this.m_panEditLien.Controls.Add(this.m_lblElementB);
			this.m_panEditLien.Controls.Add(this.m_lblDescripElementB);
			this.m_panEditLien.Controls.Add(this.m_lblDescripElementA);
			this.m_panEditLien.Controls.Add(this.m_lblElementA);
			this.m_panEditLien.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_extLinkField.SetLinkField(this.m_panEditLien, "");
			this.m_panEditLien.Location = new System.Drawing.Point(0, 0);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panEditLien, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_panEditLien.Name = "m_panEditLien";
			this.m_panEditLien.Size = new System.Drawing.Size(265, 217);
			this.m_panEditLien.TabIndex = 4030;
			// 
			// m_txtTolerance
			// 
			this.m_txtTolerance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtTolerance.Arrondi = 2;
			this.m_txtTolerance.DecimalAutorise = true;
			this.m_txtTolerance.DoubleValue = double.NaN;
			this.m_txtTolerance.IntValue = null;
			this.m_extLinkField.SetLinkField(this.m_txtTolerance, "");
			this.m_txtTolerance.Location = new System.Drawing.Point(112, 143);
			this.m_txtTolerance.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtTolerance, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_txtTolerance.Name = "m_txtTolerance";
			this.m_txtTolerance.NullAutorise = true;
			this.m_txtTolerance.SelectAllOnEnter = true;
			this.m_txtTolerance.Size = new System.Drawing.Size(134, 20);
			this.m_txtTolerance.TabIndex = 11;
			// 
			// m_chkNoTol
			// 
			this.m_chkNoTol.AutoSize = true;
			this.m_extLinkField.SetLinkField(this.m_chkNoTol, "");
			this.m_chkNoTol.Location = new System.Drawing.Point(95, 145);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkNoTol, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_chkNoTol.Name = "m_chkNoTol";
			this.m_chkNoTol.Size = new System.Drawing.Size(72, 17);
			this.m_chkNoTol.TabIndex = 12;
			this.m_chkNoTol.Text = "None|148";
			this.m_chkNoTol.UseVisualStyleBackColor = true;
			this.m_chkNoTol.CheckedChanged += new System.EventHandler(this.m_chkNoTol_CheckedChanged);
			// 
			// m_txtTypeLiaison
			// 
			this.m_txtTypeLiaison.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtTypeLiaison.BackColor = System.Drawing.SystemColors.Control;
			this.m_txtTypeLiaison.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_extLinkField.SetLinkField(this.m_txtTypeLiaison, "");
			this.m_txtTypeLiaison.Location = new System.Drawing.Point(3, 110);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtTypeLiaison, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_txtTypeLiaison.Multiline = true;
			this.m_txtTypeLiaison.Name = "m_txtTypeLiaison";
			this.m_txtTypeLiaison.Size = new System.Drawing.Size(257, 23);
			this.m_txtTypeLiaison.TabIndex = 10;
			// 
			// m_panAttacheA
			// 
			this.m_panAttacheA.Controls.Add(this.m_rbtFinA);
			this.m_panAttacheA.Controls.Add(this.m_rbtDebutA);
			this.m_extLinkField.SetLinkField(this.m_panAttacheA, "");
			this.m_panAttacheA.Location = new System.Drawing.Point(95, 48);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panAttacheA, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_panAttacheA.Name = "m_panAttacheA";
			this.m_panAttacheA.Size = new System.Drawing.Size(151, 27);
			this.m_panAttacheA.TabIndex = 9;
			// 
			// m_rbtFinA
			// 
			this.m_rbtFinA.AutoSize = true;
			this.m_extLinkField.SetLinkField(this.m_rbtFinA, "");
			this.m_rbtFinA.Location = new System.Drawing.Point(79, 4);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_rbtFinA, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_rbtFinA.Name = "m_rbtFinA";
			this.m_rbtFinA.Size = new System.Drawing.Size(64, 17);
			this.m_rbtFinA.TabIndex = 8;
			this.m_rbtFinA.Text = "End|574";
			this.m_rbtFinA.UseVisualStyleBackColor = true;
			this.m_rbtFinA.CheckedChanged += new System.EventHandler(this.ChangementAttacheA);
			// 
			// m_rbtDebutA
			// 
			this.m_rbtDebutA.AutoSize = true;
			this.m_extLinkField.SetLinkField(this.m_rbtDebutA, "");
			this.m_rbtDebutA.Location = new System.Drawing.Point(3, 4);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_rbtDebutA, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_rbtDebutA.Name = "m_rbtDebutA";
			this.m_rbtDebutA.Size = new System.Drawing.Size(67, 17);
			this.m_rbtDebutA.TabIndex = 8;
			this.m_rbtDebutA.Text = "Start|571";
			this.m_rbtDebutA.UseVisualStyleBackColor = true;
			this.m_rbtDebutA.CheckedChanged += new System.EventHandler(this.ChangementAttacheA);
			// 
			// m_panAttacheB
			// 
			this.m_panAttacheB.Controls.Add(this.m_rbtFinB);
			this.m_panAttacheB.Controls.Add(this.m_rbtDebutB);
			this.m_extLinkField.SetLinkField(this.m_panAttacheB, "");
			this.m_panAttacheB.Location = new System.Drawing.Point(95, 77);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panAttacheB, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_panAttacheB.Name = "m_panAttacheB";
			this.m_panAttacheB.Size = new System.Drawing.Size(151, 27);
			this.m_panAttacheB.TabIndex = 9;
			// 
			// m_rbtFinB
			// 
			this.m_rbtFinB.AutoSize = true;
			this.m_extLinkField.SetLinkField(this.m_rbtFinB, "");
			this.m_rbtFinB.Location = new System.Drawing.Point(79, 4);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_rbtFinB, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_rbtFinB.Name = "m_rbtFinB";
			this.m_rbtFinB.Size = new System.Drawing.Size(64, 17);
			this.m_rbtFinB.TabIndex = 8;
			this.m_rbtFinB.Text = "End|574";
			this.m_rbtFinB.UseVisualStyleBackColor = true;
			this.m_rbtFinB.CheckedChanged += new System.EventHandler(this.ChangementAttacheB);
			// 
			// m_rbtDebutB
			// 
			this.m_rbtDebutB.AutoSize = true;
			this.m_extLinkField.SetLinkField(this.m_rbtDebutB, "");
			this.m_rbtDebutB.Location = new System.Drawing.Point(3, 4);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_rbtDebutB, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_rbtDebutB.Name = "m_rbtDebutB";
			this.m_rbtDebutB.Size = new System.Drawing.Size(67, 17);
			this.m_rbtDebutB.TabIndex = 8;
			this.m_rbtDebutB.Text = "Start|571";
			this.m_rbtDebutB.UseVisualStyleBackColor = true;
			this.m_rbtDebutB.CheckedChanged += new System.EventHandler(this.ChangementAttacheB);
			// 
			// m_lblAttacheB
			// 
			this.m_extLinkField.SetLinkField(this.m_lblAttacheB, "");
			this.m_lblAttacheB.Location = new System.Drawing.Point(1, 83);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblAttacheB, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_lblAttacheB.Name = "m_lblAttacheB";
			this.m_lblAttacheB.Size = new System.Drawing.Size(127, 18);
			this.m_lblAttacheB.TabIndex = 1;
			this.m_lblAttacheB.Text = "Link B|1264";
			// 
			// CPanEditWndLienDeProjet
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.m_panAno);
			this.Controls.Add(this.m_panEditLien);
			this.m_extLinkField.SetLinkField(this, "");
			this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
			this.Name = "CPanEditWndLienDeProjet";
			this.Size = new System.Drawing.Size(265, 346);
			this.m_panAno.ResumeLayout(false);
			this.m_panTitreAnomalies.ResumeLayout(false);
			this.m_panEditLien.ResumeLayout(false);
			this.m_panEditLien.PerformLayout();
			this.m_panAttacheA.ResumeLayout(false);
			this.m_panAttacheA.PerformLayout();
			this.m_panAttacheB.ResumeLayout(false);
			this.m_panAttacheB.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private System.Windows.Forms.ToolTip m_tooltip;
		private sc2i.win32.common.CExtLinkField m_extLinkField;
		private System.Windows.Forms.Label m_lblElementA;
		private System.Windows.Forms.Label m_lblElementB;
		private System.Windows.Forms.Label m_lblDescripElementA;
		private System.Windows.Forms.Label m_lblDescripElementB;
		private System.Windows.Forms.Label m_lblAttacheA;
		private System.Windows.Forms.Label m_lblTolerance;
		private System.Windows.Forms.Label m_lblFormule;
		private sc2i.win32.expression.CTextBoxZoomFormule m_wndFormule;
		private System.Windows.Forms.Panel m_panAno;
		private CCtrlViewAnomaliesAIElementDeProjet m_ctrlAnomalies;
		private System.Windows.Forms.Panel m_panTitreAnomalies;
		private System.Windows.Forms.Label m_lblTitreAnomalies;
		private System.Windows.Forms.Panel m_panEditLien;
		private System.Windows.Forms.Label m_lblAttacheB;
		private System.Windows.Forms.Panel m_panAttacheA;
		private System.Windows.Forms.RadioButton m_rbtFinA;
		private System.Windows.Forms.RadioButton m_rbtDebutA;
		private System.Windows.Forms.Panel m_panAttacheB;
		private System.Windows.Forms.RadioButton m_rbtFinB;
		private System.Windows.Forms.RadioButton m_rbtDebutB;
		private System.Windows.Forms.TextBox m_txtTypeLiaison;
		private sc2i.win32.common.C2iTextBoxNumerique m_txtTolerance;
		private System.Windows.Forms.CheckBox m_chkNoTol;
	}
}
