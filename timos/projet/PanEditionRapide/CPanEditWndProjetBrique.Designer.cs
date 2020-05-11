using sc2i.common;

namespace timos
{
	partial class CPanEditWndProjetBrique
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPanEditWndProjetBrique));
			this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
			this.m_selectTypeProjet = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
			this.m_lblTypeTable = new System.Windows.Forms.Label();
			this.m_lblProject = new System.Windows.Forms.Label();
			this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
			this.m_dtpDateFin = new sc2i.win32.common.C2iDateTimeExPicker();
			this.m_lblDateDebut = new System.Windows.Forms.Label();
			this.m_lblDateFin = new System.Windows.Forms.Label();
			this.m_btnProprietes = new System.Windows.Forms.Button();
			this.m_panProjet = new System.Windows.Forms.Panel();
			this.m_dtpDateDebut = new sc2i.win32.common.C2iDateTimeExPicker();
			this.m_panAno = new System.Windows.Forms.Panel();
			this.m_ctrlAnomalies = new timos.CCtrlViewAnomaliesAIElementDeProjet();
			this.m_panTitreAnomalies = new System.Windows.Forms.Panel();
			this.m_lblTitreAnomalies = new System.Windows.Forms.Label();
			this.m_tooltip = new System.Windows.Forms.ToolTip(this.components);
			this.m_extLinkField = new sc2i.win32.common.CExtLinkField();
			this.m_ctrlState = new timos.CCtrlViewStateIElementPlanifiable();
			this.m_lblState = new System.Windows.Forms.Label();
			this.m_panProjet.SuspendLayout();
			this.m_panAno.SuspendLayout();
			this.m_panTitreAnomalies.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_selectTypeProjet
			// 
			this.m_selectTypeProjet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_selectTypeProjet.ElementSelectionne = null;
			this.m_selectTypeProjet.Enabled = false;
			this.m_selectTypeProjet.HasLink = true;
			this.m_extLinkField.SetLinkField(this.m_selectTypeProjet, "");
			this.m_selectTypeProjet.Location = new System.Drawing.Point(129, 29);
			this.m_selectTypeProjet.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_selectTypeProjet, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_selectTypeProjet.Name = "m_selectTypeProjet";
			this.m_selectTypeProjet.SelectedObject = null;
			this.m_selectTypeProjet.Size = new System.Drawing.Size(231, 21);
			this.m_selectTypeProjet.TabIndex = 4021;
			this.m_selectTypeProjet.ElementSelectionneChanged += new System.EventHandler(this.m_selectTypeProjet_ElementSelectionneChanged);
			// 
			// m_lblTypeTable
			// 
			this.m_extLinkField.SetLinkField(this.m_lblTypeTable, "");
			this.m_lblTypeTable.Location = new System.Drawing.Point(6, 33);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblTypeTable, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_lblTypeTable.Name = "m_lblTypeTable";
			this.m_lblTypeTable.Size = new System.Drawing.Size(117, 13);
			this.m_lblTypeTable.TabIndex = 4020;
			this.m_lblTypeTable.Text = "Project Type|1215";
			// 
			// m_lblProject
			// 
			this.m_lblProject.ForeColor = System.Drawing.Color.Black;
			this.m_extLinkField.SetLinkField(this.m_lblProject, "");
			this.m_lblProject.Location = new System.Drawing.Point(6, 6);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblProject, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_lblProject.Name = "m_lblProject";
			this.m_lblProject.Size = new System.Drawing.Size(108, 17);
			this.m_lblProject.TabIndex = 4019;
			this.m_lblProject.Text = "Project label |745";
			// 
			// m_txtLibelle
			// 
			this.m_txtLibelle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
			this.m_txtLibelle.Location = new System.Drawing.Point(129, 3);
			this.m_txtLibelle.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_txtLibelle.Name = "m_txtLibelle";
			this.m_txtLibelle.Size = new System.Drawing.Size(231, 20);
			this.m_txtLibelle.TabIndex = 4018;
			this.m_txtLibelle.Text = "[Label]|30324";
			// 
			// m_dtpDateFin
			// 
			this.m_dtpDateFin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_dtpDateFin.Checked = true;
			this.m_dtpDateFin.CustomFormat = null;
			this.m_dtpDateFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.m_extLinkField.SetLinkField(this.m_dtpDateFin, "");
			this.m_dtpDateFin.Location = new System.Drawing.Point(129, 83);
			this.m_dtpDateFin.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_dtpDateFin, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_dtpDateFin.Name = "m_dtpDateFin";
			this.m_dtpDateFin.Size = new System.Drawing.Size(231, 20);
			this.m_dtpDateFin.TabIndex = 4025;
            this.m_dtpDateFin.TextNull = I.T("None|148");
			this.m_dtpDateFin.Value = ((sc2i.common.CDateTimeEx)(resources.GetObject("m_dtpDateFin.Value")));
			this.m_dtpDateFin.OnValueChange += new System.EventHandler(this.m_dtpDateFin_OnValueChange);
			// 
			// m_lblDateDebut
			// 
			this.m_lblDateDebut.ForeColor = System.Drawing.Color.Black;
			this.m_extLinkField.SetLinkField(this.m_lblDateDebut, "");
			this.m_lblDateDebut.Location = new System.Drawing.Point(6, 59);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblDateDebut, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_lblDateDebut.Name = "m_lblDateDebut";
			this.m_lblDateDebut.Size = new System.Drawing.Size(131, 17);
			this.m_lblDateDebut.TabIndex = 4022;
			this.m_lblDateDebut.Text = "Planned start date|1230";
			// 
			// m_lblDateFin
			// 
			this.m_lblDateFin.ForeColor = System.Drawing.Color.Black;
			this.m_extLinkField.SetLinkField(this.m_lblDateFin, "");
			this.m_lblDateFin.Location = new System.Drawing.Point(6, 86);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblDateFin, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_lblDateFin.Name = "m_lblDateFin";
			this.m_lblDateFin.Size = new System.Drawing.Size(131, 17);
			this.m_lblDateFin.TabIndex = 4023;
			this.m_lblDateFin.Text = "Planned end date|1231";
			// 
			// m_btnProprietes
			// 
			this.m_btnProprietes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_extLinkField.SetLinkField(this.m_btnProprietes, "");
			this.m_btnProprietes.Location = new System.Drawing.Point(285, 135);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnProprietes, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_btnProprietes.Name = "m_btnProprietes";
			this.m_btnProprietes.Size = new System.Drawing.Size(75, 23);
			this.m_btnProprietes.TabIndex = 4026;
			this.m_btnProprietes.Text = "Properties|1234";
			this.m_btnProprietes.UseVisualStyleBackColor = true;
			this.m_btnProprietes.Click += new System.EventHandler(this.m_btnProprietes_Click);
			// 
			// m_panProjet
			// 
			this.m_panProjet.Controls.Add(this.m_ctrlState);
			this.m_panProjet.Controls.Add(this.m_lblState);
			this.m_panProjet.Controls.Add(this.m_dtpDateDebut);
			this.m_panProjet.Controls.Add(this.m_lblProject);
			this.m_panProjet.Controls.Add(this.m_btnProprietes);
			this.m_panProjet.Controls.Add(this.m_txtLibelle);
			this.m_panProjet.Controls.Add(this.m_lblTypeTable);
			this.m_panProjet.Controls.Add(this.m_dtpDateFin);
			this.m_panProjet.Controls.Add(this.m_selectTypeProjet);
			this.m_panProjet.Controls.Add(this.m_lblDateDebut);
			this.m_panProjet.Controls.Add(this.m_lblDateFin);
			this.m_panProjet.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_extLinkField.SetLinkField(this.m_panProjet, "");
			this.m_panProjet.Location = new System.Drawing.Point(0, 0);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panProjet, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_panProjet.Name = "m_panProjet";
			this.m_panProjet.Size = new System.Drawing.Size(363, 164);
			this.m_panProjet.TabIndex = 4027;
			// 
			// m_dtpDateDebut
			// 
			this.m_dtpDateDebut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_dtpDateDebut.Checked = true;
			this.m_dtpDateDebut.CustomFormat = null;
			this.m_dtpDateDebut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.m_extLinkField.SetLinkField(this.m_dtpDateDebut, "");
			this.m_dtpDateDebut.Location = new System.Drawing.Point(129, 57);
			this.m_dtpDateDebut.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_dtpDateDebut, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_dtpDateDebut.Name = "m_dtpDateDebut";
			this.m_dtpDateDebut.Size = new System.Drawing.Size(231, 20);
			this.m_dtpDateDebut.TabIndex = 4027;
            this.m_dtpDateDebut.TextNull = I.T("None|148");
			this.m_dtpDateDebut.Value = ((sc2i.common.CDateTimeEx)(resources.GetObject("m_dtpDateDebut.Value")));
			this.m_dtpDateDebut.OnValueChange += new System.EventHandler(this.m_dtpDateDebut_OnValueChange);
			// 
			// m_panAno
			// 
			this.m_panAno.Controls.Add(this.m_ctrlAnomalies);
			this.m_panAno.Controls.Add(this.m_panTitreAnomalies);
			this.m_panAno.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_extLinkField.SetLinkField(this.m_panAno, "");
			this.m_panAno.Location = new System.Drawing.Point(0, 164);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panAno, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_panAno.Name = "m_panAno";
			this.m_panAno.Size = new System.Drawing.Size(363, 158);
			this.m_panAno.TabIndex = 4028;
			// 
			// m_ctrlAnomalies
			// 
			this.m_ctrlAnomalies.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_extLinkField.SetLinkField(this.m_ctrlAnomalies, "");
			this.m_ctrlAnomalies.Location = new System.Drawing.Point(0, 23);
			this.m_ctrlAnomalies.LockEdition = true;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_ctrlAnomalies, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_ctrlAnomalies.Name = "m_ctrlAnomalies";
			this.m_ctrlAnomalies.Size = new System.Drawing.Size(363, 135);
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
			this.m_panTitreAnomalies.Size = new System.Drawing.Size(363, 23);
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
			// m_ctrlState
			// 
			this.m_ctrlState.Enabled = false;
			this.m_extLinkField.SetLinkField(this.m_ctrlState, "");
			this.m_ctrlState.Location = new System.Drawing.Point(129, 106);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_ctrlState, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_ctrlState.Name = "m_ctrlState";
			this.m_ctrlState.Size = new System.Drawing.Size(183, 23);
			this.m_ctrlState.TabIndex = 4034;
			// 
			// m_lblState
			// 
			this.m_lblState.ForeColor = System.Drawing.Color.Black;
			this.m_extLinkField.SetLinkField(this.m_lblState, "");
			this.m_lblState.Location = new System.Drawing.Point(6, 109);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblState, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_lblState.Name = "m_lblState";
			this.m_lblState.Size = new System.Drawing.Size(137, 17);
			this.m_lblState.TabIndex = 4033;
			this.m_lblState.Text = "State|57";
			// 
			// CPanEditWndProjetBrique
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.m_panAno);
			this.Controls.Add(this.m_panProjet);
			this.m_extLinkField.SetLinkField(this, "");
			this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
			this.Name = "CPanEditWndProjetBrique";
			this.Size = new System.Drawing.Size(363, 322);
			this.m_panProjet.ResumeLayout(false);
			this.m_panProjet.PerformLayout();
			this.m_panAno.ResumeLayout(false);
			this.m_panTitreAnomalies.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private System.Windows.Forms.ToolTip m_tooltip;
		private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_selectTypeProjet;
		private System.Windows.Forms.Label m_lblTypeTable;
		private System.Windows.Forms.Label m_lblProject;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.CExtLinkField m_extLinkField;
		private sc2i.win32.common.C2iDateTimeExPicker m_dtpDateFin;
		private System.Windows.Forms.Label m_lblDateDebut;
		private System.Windows.Forms.Label m_lblDateFin;
		private System.Windows.Forms.Button m_btnProprietes;
		private System.Windows.Forms.Panel m_panProjet;
		private System.Windows.Forms.Panel m_panAno;
		private CCtrlViewAnomaliesAIElementDeProjet m_ctrlAnomalies;
		private System.Windows.Forms.Panel m_panTitreAnomalies;
		private System.Windows.Forms.Label m_lblTitreAnomalies;
		private sc2i.win32.common.C2iDateTimeExPicker m_dtpDateDebut;
		private CCtrlViewStateIElementPlanifiable m_ctrlState;
		private System.Windows.Forms.Label m_lblState;
	}
}
