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
	public class CPanelPlanificationInterventionMensuelleJourSemaine : CPanelPlanficationIntervention
	{
		private System.Windows.Forms.Label label16;
		private sc2i.win32.common.C2iNumericUpDown m_numUpEcartMois;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private sc2i.win32.common.C2iComboBox m_cmbNumJour;
		private sc2i.win32.common.C2iComboBox m_cmbJourSemaine;
		private System.ComponentModel.IContainer components = null;

		public CPanelPlanificationInterventionMensuelleJourSemaine()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();

			// TODO : ajoutez les initialisations après l'appel à InitializeComponent
		}

		public static void Autoexec()
		{
			CPanelPlanficationIntervention.RegisterPanelPlanification ( typeof(CPlanificationTacheMensuelleJourSemaine),
				typeof(CPanelPlanificationInterventionMensuelleJourSemaine) );
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

		#region Code généré par le concepteur
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.label16 = new System.Windows.Forms.Label();
			this.m_numUpEcartMois = new sc2i.win32.common.C2iNumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.m_cmbNumJour = new sc2i.win32.common.C2iComboBox();
			this.m_cmbJourSemaine = new sc2i.win32.common.C2iComboBox();
			((System.ComponentModel.ISupportInitialize)(this.m_numUpEcartMois)).BeginInit();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.m_extLinkField.SetLinkField(this.label16, "");
			this.label16.Location = new System.Drawing.Point(16, 48);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label16, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label16.Name = "label2";
			this.label16.Size = new System.Drawing.Size(64, 16);
			this.label16.TabIndex = 2;
			this.label16.Text = "Every|30014";
			this.label16.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// m_numUpEcartMois
			// 
			this.m_numUpEcartMois.DoubleValue = 1;
			this.m_numUpEcartMois.IntValue = 1;
			this.m_extLinkField.SetLinkField(this.m_numUpEcartMois, "EcartMois");
			this.m_numUpEcartMois.Location = new System.Drawing.Point(88, 48);
			this.m_numUpEcartMois.LockEdition = false;
			this.m_numUpEcartMois.Maximum = new System.Decimal(new int[] {
																			 100000,
																			 0,
																			 0,
																			 0});
			this.m_numUpEcartMois.Minimum = new System.Decimal(new int[] {
																			 1,
																			 0,
																			 0,
																			 0});
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_numUpEcartMois, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_numUpEcartMois.Name = "m_numUpEcartMois";
			this.m_numUpEcartMois.Size = new System.Drawing.Size(40, 20);
			this.m_numUpEcartMois.TabIndex = 4;
			this.m_numUpEcartMois.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_numUpEcartMois.ThousandsSeparator = true;
			this.m_numUpEcartMois.Value = new System.Decimal(new int[] {
																		   1,
																		   0,
																		   0,
																		   0});
			// 
			// label1
			// 
			this.m_extLinkField.SetLinkField(this.label1, "");
			this.label1.Location = new System.Drawing.Point(264, 24);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 16);
			this.label1.TabIndex = 5;
			this.label1.Text = "of the month|30015";
			// 
			// label3
			// 
			this.m_extLinkField.SetLinkField(this.label3, "");
			this.label3.Location = new System.Drawing.Point(16, 24);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 6;
			this.label3.Text = "Every|30014";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label4
			// 
			this.m_extLinkField.SetLinkField(this.label4, "");
			this.label4.Location = new System.Drawing.Point(128, 48);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 16);
			this.label4.TabIndex = 8;
			this.label4.Text = "Month|30017";
			// 
			// m_cmbNumJour
			// 
			this.m_cmbNumJour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cmbNumJour.IsLink = false;
			this.m_cmbNumJour.Items.AddRange(new object[] {
															  I.T("First|30018"),
															  I.T("Second|30019"),
															  I.T("Third|30020"),
															  I.T("Fourth|30021"),
															  I.T("Last|30022")});
			this.m_extLinkField.SetLinkField(this.m_cmbNumJour, "");
			this.m_cmbNumJour.Location = new System.Drawing.Point(88, 24);
			this.m_cmbNumJour.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbNumJour, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_cmbNumJour.Name = "m_cmbNumJour";
			this.m_cmbNumJour.Size = new System.Drawing.Size(88, 21);
			this.m_cmbNumJour.TabIndex = 9;
			// 
			// m_cmbJourSemaine
			// 
			this.m_cmbJourSemaine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cmbJourSemaine.IsLink = false;
            this.m_cmbJourSemaine.Items.AddRange(new object[] {
																  I.T("Monday|30023"),
																  I.T("Tuesday|30024"),
                                                                  I.T("Wednesday|30025"),
                                                                  I.T("Thursday|30026"),
                                                                  I.T("Friday|30027"),
                                                                  I.T("Saturday|30028"),
                                                                  I.T("Sunday|30029")});
																  
			this.m_extLinkField.SetLinkField(this.m_cmbJourSemaine, "");
			this.m_cmbJourSemaine.Location = new System.Drawing.Point(176, 24);
			this.m_cmbJourSemaine.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbJourSemaine, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_cmbJourSemaine.Name = "m_cmbJourSemaine";
			this.m_cmbJourSemaine.Size = new System.Drawing.Size(88, 21);
			this.m_cmbJourSemaine.TabIndex = 10;
			// 
			// CPanelPlanificationInterventionMensuelleJourSemaine
			// 
			this.Controls.Add(this.m_cmbJourSemaine);
			this.Controls.Add(this.m_cmbNumJour);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_numUpEcartMois);
			this.Controls.Add(this.label16);
			this.m_extLinkField.SetLinkField(this, "");
			this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
			this.Name = "CPanelPlanificationInterventionMensuelleJourSemaine";
			this.Size = new System.Drawing.Size(312, 72);
			this.Load += new System.EventHandler(this.CPanelPlanificationInterventionMensuelleJourSemaine_Load);
			this.Controls.SetChildIndex(this.label16, 0);
			this.Controls.SetChildIndex(this.m_numUpEcartMois, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.m_cmbNumJour, 0);
			this.Controls.SetChildIndex(this.m_cmbJourSemaine, 0);
			((System.ComponentModel.ISupportInitialize)(this.m_numUpEcartMois)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void CPanelPlanificationInterventionMensuelleJourSemaine_Load(object sender, System.EventArgs e)
		{
		
		}

        public override void InitChamps(CPlanificationTache planification)
		{
			base.InitChamps (planification);
			CPlanificationTacheMensuelleJourSemaine plj = (CPlanificationTacheMensuelleJourSemaine)planification;
			if ( plj.NumeroJour > 0 && plj.NumeroJour < 6 )
				m_cmbNumJour.SelectedIndex = plj.NumeroJour-1;
			int nDay = (int)plj.JourSemaine;
			nDay = (nDay+6)%7;
			m_cmbJourSemaine.SelectedIndex = nDay;
		}


		public override CResultAErreur MajChamps()
		{
			CResultAErreur result = base.MajChamps ();
			CPlanificationTacheMensuelleJourSemaine plj = (CPlanificationTacheMensuelleJourSemaine)Planification;
			plj.NumeroJour = m_cmbNumJour.SelectedIndex+1;
			int nDay = m_cmbJourSemaine.SelectedIndex;
			nDay = (nDay+8)%7;
			plj.JourSemaine = (DayOfWeek)nDay;
			return result;
		}




	}
}

