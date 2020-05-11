using sc2i.common;

namespace timos
{
	partial class CPanEditWndIntervention
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
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_btnProprietes = new System.Windows.Forms.Button();
            this.m_lblLabel = new System.Windows.Forms.Label();
            this.m_txtLabel = new sc2i.win32.common.C2iTextBox();
            this.m_lblDateDebut = new System.Windows.Forms.Label();
            this.m_lblDateFin = new System.Windows.Forms.Label();
            this.lbl_inter = new System.Windows.Forms.Label();
            this.m_panAno = new System.Windows.Forms.Panel();
            this.m_ctrlAnomalies = new timos.CCtrlViewAnomaliesAIElementDeProjet();
            this.m_panTitreAnomalies = new System.Windows.Forms.Panel();
            this.m_lblTitreAnomalies = new System.Windows.Forms.Label();
            this.m_panInter = new System.Windows.Forms.Panel();
            this.m_lblDateEnd = new System.Windows.Forms.Label();
            this.m_lblDateStart = new System.Windows.Forms.Label();
            this.m_selectTypeInter = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_ctrlState = new timos.CCtrlViewStateIElementPlanifiable();
            this.m_dtpDateDebutPre = new sc2i.win32.common.C2iDateTimeExPicker();
            this.m_lblPrePlanStart = new System.Windows.Forms.Label();
            this.m_dtpDateFinPre = new sc2i.win32.common.C2iDateTimeExPicker();
            this.m_lblPrePlanEnd = new System.Windows.Forms.Label();
            this.m_lblState = new System.Windows.Forms.Label();
            this.m_extLinkField = new sc2i.win32.common.CExtLinkField();
            this.m_panAno.SuspendLayout();
            this.m_panTitreAnomalies.SuspendLayout();
            this.m_panInter.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnProprietes
            // 
            this.m_btnProprietes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_btnProprietes, "");
            this.m_btnProprietes.Location = new System.Drawing.Point(234, 196);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnProprietes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnProprietes.Name = "m_btnProprietes";
            this.m_btnProprietes.Size = new System.Drawing.Size(75, 23);
            this.m_btnProprietes.TabIndex = 0;
            this.m_btnProprietes.Text = "Properties|1234";
            this.m_btnProprietes.UseVisualStyleBackColor = true;
            this.m_btnProprietes.Click += new System.EventHandler(this.m_btnProprietes_Click);
            // 
            // m_lblLabel
            // 
            this.m_extLinkField.SetLinkField(this.m_lblLabel, "");
            this.m_lblLabel.Location = new System.Drawing.Point(2, 6);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblLabel, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblLabel.Name = "m_lblLabel";
            this.m_lblLabel.Size = new System.Drawing.Size(65, 16);
            this.m_lblLabel.TabIndex = 1;
            this.m_lblLabel.Text = "Label|50";
            // 
            // m_txtLabel
            // 
            this.m_txtLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_txtLabel, "Libelle");
            this.m_txtLabel.Location = new System.Drawing.Point(79, 3);
            this.m_txtLabel.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLabel, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtLabel.Name = "m_txtLabel";
            this.m_txtLabel.Size = new System.Drawing.Size(230, 20);
            this.m_txtLabel.TabIndex = 2;
            this.m_txtLabel.Text = "[Label]|30324";
            // 
            // m_lblDateDebut
            // 
            this.m_lblDateDebut.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_lblDateDebut, "");
            this.m_lblDateDebut.Location = new System.Drawing.Point(3, 111);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblDateDebut, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblDateDebut.Name = "m_lblDateDebut";
            this.m_lblDateDebut.Size = new System.Drawing.Size(137, 17);
            this.m_lblDateDebut.TabIndex = 4026;
            this.m_lblDateDebut.Text = "Planned start date|1230";
            // 
            // m_lblDateFin
            // 
            this.m_lblDateFin.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_lblDateFin, "");
            this.m_lblDateFin.Location = new System.Drawing.Point(3, 138);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblDateFin, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblDateFin.Name = "m_lblDateFin";
            this.m_lblDateFin.Size = new System.Drawing.Size(137, 17);
            this.m_lblDateFin.TabIndex = 4027;
            this.m_lblDateFin.Text = "Planned end date|1231";
            // 
            // lbl_inter
            // 
            this.m_extLinkField.SetLinkField(this.lbl_inter, "");
            this.lbl_inter.Location = new System.Drawing.Point(0, 30);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_inter, sc2i.win32.common.TypeModeEdition.Autonome);
            this.lbl_inter.Name = "lbl_inter";
            this.lbl_inter.Size = new System.Drawing.Size(80, 18);
            this.lbl_inter.TabIndex = 4030;
            this.lbl_inter.Text = "Intervention|561";
            // 
            // m_panAno
            // 
            this.m_panAno.Controls.Add(this.m_ctrlAnomalies);
            this.m_panAno.Controls.Add(this.m_panTitreAnomalies);
            this.m_panAno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panAno, "");
            this.m_panAno.Location = new System.Drawing.Point(0, 229);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panAno, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panAno.Name = "m_panAno";
            this.m_panAno.Size = new System.Drawing.Size(313, 173);
            this.m_panAno.TabIndex = 4032;
            // 
            // m_ctrlAnomalies
            // 
            this.m_ctrlAnomalies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_ctrlAnomalies, "");
            this.m_ctrlAnomalies.Location = new System.Drawing.Point(0, 23);
            this.m_ctrlAnomalies.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_ctrlAnomalies, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_ctrlAnomalies.Name = "m_ctrlAnomalies";
            this.m_ctrlAnomalies.Size = new System.Drawing.Size(313, 150);
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
            this.m_panTitreAnomalies.Size = new System.Drawing.Size(313, 23);
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
            // m_panInter
            // 
            this.m_panInter.Controls.Add(this.m_lblDateEnd);
            this.m_panInter.Controls.Add(this.m_lblDateStart);
            this.m_panInter.Controls.Add(this.m_selectTypeInter);
            this.m_panInter.Controls.Add(this.m_ctrlState);
            this.m_panInter.Controls.Add(this.m_lblLabel);
            this.m_panInter.Controls.Add(this.m_btnProprietes);
            this.m_panInter.Controls.Add(this.m_txtLabel);
            this.m_panInter.Controls.Add(this.m_dtpDateDebutPre);
            this.m_panInter.Controls.Add(this.m_lblPrePlanStart);
            this.m_panInter.Controls.Add(this.m_dtpDateFinPre);
            this.m_panInter.Controls.Add(this.m_lblDateDebut);
            this.m_panInter.Controls.Add(this.m_lblPrePlanEnd);
            this.m_panInter.Controls.Add(this.m_lblState);
            this.m_panInter.Controls.Add(this.m_lblDateFin);
            this.m_panInter.Controls.Add(this.lbl_inter);
            this.m_panInter.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.m_panInter, "");
            this.m_panInter.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panInter, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panInter.Name = "m_panInter";
            this.m_panInter.Size = new System.Drawing.Size(313, 229);
            this.m_panInter.TabIndex = 4033;
            // 
            // m_lblDateEnd
            // 
            this.m_extLinkField.SetLinkField(this.m_lblDateEnd, "");
            this.m_lblDateEnd.Location = new System.Drawing.Point(123, 138);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblDateEnd, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblDateEnd.Name = "m_lblDateEnd";
            this.m_lblDateEnd.Size = new System.Drawing.Size(186, 23);
            this.m_lblDateEnd.TabIndex = 4034;
            // 
            // m_lblDateStart
            // 
            this.m_extLinkField.SetLinkField(this.m_lblDateStart, "");
            this.m_lblDateStart.Location = new System.Drawing.Point(123, 111);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblDateStart, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblDateStart.Name = "m_lblDateStart";
            this.m_lblDateStart.Size = new System.Drawing.Size(186, 23);
            this.m_lblDateStart.TabIndex = 4034;
            // 
            // m_selectTypeInter
            // 
            this.m_selectTypeInter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_selectTypeInter.ElementSelectionne = null;
            this.m_selectTypeInter.Enabled = false;
            this.m_selectTypeInter.FonctionTextNull = null;
            this.m_selectTypeInter.HasLink = true;
            this.m_extLinkField.SetLinkField(this.m_selectTypeInter, "");
            this.m_selectTypeInter.Location = new System.Drawing.Point(79, 27);
            this.m_selectTypeInter.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_selectTypeInter, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_selectTypeInter.Name = "m_selectTypeInter";
            this.m_selectTypeInter.SelectedObject = null;
            this.m_selectTypeInter.Size = new System.Drawing.Size(231, 21);
            this.m_selectTypeInter.TabIndex = 4033;
            this.m_selectTypeInter.TextNull = "";
            // 
            // m_ctrlState
            // 
            this.m_ctrlState.Enabled = false;
            this.m_extLinkField.SetLinkField(this.m_ctrlState, "");
            this.m_ctrlState.Location = new System.Drawing.Point(126, 167);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_ctrlState, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_ctrlState.Name = "m_ctrlState";
            this.m_ctrlState.Size = new System.Drawing.Size(183, 23);
            this.m_ctrlState.TabIndex = 4032;
            // 
            // m_dtpDateDebutPre
            // 
            this.m_dtpDateDebutPre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_dtpDateDebutPre.Checked = true;
            this.m_dtpDateDebutPre.CustomFormat = null;
            this.m_dtpDateDebutPre.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.m_extLinkField.SetLinkField(this.m_dtpDateDebutPre, "");
            this.m_dtpDateDebutPre.Location = new System.Drawing.Point(149, 56);
            this.m_dtpDateDebutPre.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_dtpDateDebutPre, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_dtpDateDebutPre.Name = "m_dtpDateDebutPre";
            this.m_dtpDateDebutPre.Size = new System.Drawing.Size(124, 20);
            this.m_dtpDateDebutPre.TabIndex = 4028;
            this.m_dtpDateDebutPre.TextNull = I.T("None|148");
            this.m_dtpDateDebutPre.Value.DateTimeValue = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpDateDebutPre.OnValueChange += new System.EventHandler(this.m_dtpDateDebut_OnValueChange);
            // 
            // m_lblPrePlanStart
            // 
            this.m_lblPrePlanStart.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_lblPrePlanStart, "");
            this.m_lblPrePlanStart.Location = new System.Drawing.Point(3, 59);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblPrePlanStart, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblPrePlanStart.Name = "m_lblPrePlanStart";
            this.m_lblPrePlanStart.Size = new System.Drawing.Size(152, 17);
            this.m_lblPrePlanStart.TabIndex = 4026;
            this.m_lblPrePlanStart.Text = "Pre-planned start date|30264";
            // 
            // m_dtpDateFinPre
            // 
            this.m_dtpDateFinPre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_dtpDateFinPre.Checked = true;
            this.m_dtpDateFinPre.CustomFormat = null;
            this.m_dtpDateFinPre.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.m_extLinkField.SetLinkField(this.m_dtpDateFinPre, "");
            this.m_dtpDateFinPre.Location = new System.Drawing.Point(149, 83);
            this.m_dtpDateFinPre.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_dtpDateFinPre, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_dtpDateFinPre.Name = "m_dtpDateFinPre";
            this.m_dtpDateFinPre.Size = new System.Drawing.Size(124, 20);
            this.m_dtpDateFinPre.TabIndex = 4029;
            this.m_dtpDateFinPre.TextNull = I.T("None|148");
            this.m_dtpDateFinPre.Value.DateTimeValue = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpDateFinPre.OnValueChange += new System.EventHandler(this.m_dtpDateFin_OnValueChange);
            // 
            // m_lblPrePlanEnd
            // 
            this.m_lblPrePlanEnd.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_lblPrePlanEnd, "");
            this.m_lblPrePlanEnd.Location = new System.Drawing.Point(3, 86);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblPrePlanEnd, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblPrePlanEnd.Name = "m_lblPrePlanEnd";
            this.m_lblPrePlanEnd.Size = new System.Drawing.Size(155, 17);
            this.m_lblPrePlanEnd.TabIndex = 4027;
            this.m_lblPrePlanEnd.Text = "Pre-planned end date|30265";
            // 
            // m_lblState
            // 
            this.m_lblState.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_lblState, "");
            this.m_lblState.Location = new System.Drawing.Point(3, 170);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblState, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblState.Name = "m_lblState";
            this.m_lblState.Size = new System.Drawing.Size(137, 17);
            this.m_lblState.TabIndex = 4027;
            this.m_lblState.Text = "State|57";
            // 
            // CPanEditWndIntervention
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_panAno);
            this.Controls.Add(this.m_panInter);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CPanEditWndIntervention";
            this.Size = new System.Drawing.Size(313, 402);
            this.m_panAno.ResumeLayout(false);
            this.m_panTitreAnomalies.ResumeLayout(false);
            this.m_panInter.ResumeLayout(false);
            this.m_panInter.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private sc2i.win32.common.CExtLinkField m_extLinkField;
		private System.Windows.Forms.Button m_btnProprietes;
		private System.Windows.Forms.Label m_lblLabel;
		private sc2i.win32.common.C2iTextBox m_txtLabel;
		private System.Windows.Forms.Label m_lblDateDebut;
		private System.Windows.Forms.Label m_lblDateFin;
		private System.Windows.Forms.Label lbl_inter;
		private System.Windows.Forms.Panel m_panAno;
		private CCtrlViewAnomaliesAIElementDeProjet m_ctrlAnomalies;
		private System.Windows.Forms.Panel m_panTitreAnomalies;
		private System.Windows.Forms.Label m_lblTitreAnomalies;
		private System.Windows.Forms.Panel m_panInter;
		private CCtrlViewStateIElementPlanifiable m_ctrlState;
		private sc2i.win32.common.C2iDateTimeExPicker m_dtpDateDebutPre;
		private System.Windows.Forms.Label m_lblPrePlanStart;
		private System.Windows.Forms.Label m_lblPrePlanEnd;
		private System.Windows.Forms.Label m_lblState;
		private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_selectTypeInter;
		private System.Windows.Forms.Label m_lblDateEnd;
		private System.Windows.Forms.Label m_lblDateStart;
		private sc2i.win32.common.C2iDateTimeExPicker m_dtpDateFinPre;
	}
}
