using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using sc2i.common;
using sc2i.common.planification;

namespace timos.win32.composants
{
	[AutoExec("Autoexec")]
	public class CPanelPlanificationInterventionHebdomadaire : CPanelPlanficationIntervention
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private sc2i.win32.common.C2iNumericUpDown c2iNumericUpDown1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ListView m_wndListeJours;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.ComponentModel.IContainer components = null;

		public CPanelPlanificationInterventionHebdomadaire()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();

			// TODO : ajoutez les initialisations après l'appel à InitializeComponent
		}

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		public static void Autoexec()
		{
			CPanelPlanficationIntervention.RegisterPanelPlanification ( typeof(CPlanificationTacheHebdomadaire),
				typeof(CPanelPlanificationInterventionHebdomadaire) );
		}

		#region Code généré par le concepteur
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Lundi");
			System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Mardi");
			System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Mercredi");
			System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Jeudi");
			System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("Vendredi");
			System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("Samedi");
			System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("Dimanche");
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.c2iNumericUpDown1 = new sc2i.win32.common.C2iNumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.m_wndListeJours = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			((System.ComponentModel.ISupportInitialize)(this.c2iNumericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.m_extLinkField.SetLinkField(this.label2, "");
			// 
			// label1
			// 
			this.m_extLinkField.SetLinkField(this.label1, "");
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(24, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "the|30011";
			// 
			// label3
			// 
			this.m_extLinkField.SetLinkField(this.label3, "");
			this.label3.Location = new System.Drawing.Point(176, 2);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 17);
			this.label3.TabIndex = 6;
			this.label3.Text = "every|30012";
			// 
			// c2iNumericUpDown1
			// 
			this.c2iNumericUpDown1.DoubleValue = 1;
			this.c2iNumericUpDown1.IntValue = 1;
			this.m_extLinkField.SetLinkField(this.c2iNumericUpDown1, "EcartSemaine");
			this.c2iNumericUpDown1.Location = new System.Drawing.Point(232, 0);
			this.c2iNumericUpDown1.LockEdition = false;
			this.c2iNumericUpDown1.Maximum = new decimal(new int[] {
            104,
            0,
            0,
            0});
			this.c2iNumericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.m_gestionnaireModeEdition.SetModeEdition(this.c2iNumericUpDown1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.c2iNumericUpDown1.Name = "c2iNumericUpDown1";
			this.c2iNumericUpDown1.Size = new System.Drawing.Size(48, 20);
			this.c2iNumericUpDown1.TabIndex = 7;
			this.c2iNumericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.c2iNumericUpDown1.ThousandsSeparator = true;
			this.c2iNumericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label4
			// 
			this.m_extLinkField.SetLinkField(this.label4, "");
			this.label4.Location = new System.Drawing.Point(280, 2);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 17);
			this.label4.TabIndex = 8;
			this.label4.Text = "weeks|30013";
			this.label4.Click += new System.EventHandler(this.label4_Click);
			// 
			// m_wndListeJours
			// 
			this.m_wndListeJours.BackColor = System.Drawing.SystemColors.Control;
			this.m_wndListeJours.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_wndListeJours.CheckBoxes = true;
			this.m_wndListeJours.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
			this.m_wndListeJours.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			listViewItem1.StateImageIndex = 0;
			listViewItem2.StateImageIndex = 0;
			listViewItem3.StateImageIndex = 0;
			listViewItem4.StateImageIndex = 0;
			listViewItem5.StateImageIndex = 0;
			listViewItem6.StateImageIndex = 0;
			listViewItem7.StateImageIndex = 0;
			this.m_wndListeJours.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7});
			this.m_extLinkField.SetLinkField(this.m_wndListeJours, "");
			this.m_wndListeJours.Location = new System.Drawing.Point(48, 24);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeJours, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_wndListeJours.Name = "m_wndListeJours";
			this.m_wndListeJours.Size = new System.Drawing.Size(288, 72);
			this.m_wndListeJours.TabIndex = 9;
			this.m_wndListeJours.UseCompatibleStateImageBehavior = false;
			this.m_wndListeJours.View = System.Windows.Forms.View.List;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Width = 80;
			// 
			// CPanelPlanificationInterventionHebdomadaire
			// 
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Controls.Add(this.m_wndListeJours);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.c2iNumericUpDown1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.m_extLinkField.SetLinkField(this, "");
			this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
			this.Name = "CPanelPlanificationInterventionHebdomadaire";
			this.Size = new System.Drawing.Size(344, 80);
			this.BackColorChanged += new System.EventHandler(this.CPanelPlanificationInterventionHebdomadaire_BackColorChanged);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.c2iNumericUpDown1, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.m_wndListeJours, 0);
			((System.ComponentModel.ISupportInitialize)(this.c2iNumericUpDown1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
		public override void InitChamps(CPlanificationTache planification)
		{
			base.InitChamps (planification);
			CPlanificationTacheHebdomadaire plHe = (CPlanificationTacheHebdomadaire)planification;
			for ( int n = 0; n<7; n++ )
			{
				if ( (plHe.JoursExecution & CUtilDate.GetJourBinaireForBaseLundi(n)) != 0 )
					m_wndListeJours.Items[n].Checked = true;
				else
					m_wndListeJours.Items[n].Checked = false;
			}
		}

		public override CResultAErreur MajChamps()
		{
			CResultAErreur result = base.MajChamps ();
			if ( !result )
				return result;
			JoursBinaires jrs = JoursBinaires.Aucun;
			for ( int n = 0; n < 7; n++ )
				if ( m_wndListeJours.Items[n].Checked )
					jrs |= CUtilDate.GetJourBinaireForBaseLundi(n);
			((CPlanificationTacheHebdomadaire)Planification).JoursExecution = jrs;
			return result;
		}

		private void label4_Click(object sender, System.EventArgs e)
		{
		
		}

		private void CPanelPlanificationInterventionHebdomadaire_BackColorChanged(object sender, System.EventArgs e)
		{
			m_wndListeJours.BackColor = BackColor;
		}


	}
}

