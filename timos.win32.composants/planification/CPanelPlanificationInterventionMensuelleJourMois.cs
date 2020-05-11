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
	public class CPanelPlanificationInterventionMensuelleJourMois : CPanelPlanficationIntervention
	{
		private System.Windows.Forms.Label label101;
		private sc2i.win32.common.C2iNumericUpDown m_numUpEcartMois;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private sc2i.win32.common.C2iNumericUpDown c2iNumericUpDown1;
		private System.Windows.Forms.Label label4;
		private System.ComponentModel.IContainer components = null;

		public CPanelPlanificationInterventionMensuelleJourMois()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();

			// TODO : ajoutez les initialisations après l'appel à InitializeComponent
		}

		public static void Autoexec()
		{
			CPanelPlanficationIntervention.RegisterPanelPlanification ( typeof(CPlanificationTacheMensuelleJourMois),
				typeof(CPanelPlanificationInterventionMensuelleJourMois) );
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
            this.label101 = new System.Windows.Forms.Label();
            this.m_numUpEcartMois = new sc2i.win32.common.C2iNumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.c2iNumericUpDown1 = new sc2i.win32.common.C2iNumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.m_numUpEcartMois)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c2iNumericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.m_extLinkField.SetLinkField(this.label2, "");
            // 
            // label101
            // 
            this.m_extLinkField.SetLinkField(this.label101, "");
            this.label101.Location = new System.Drawing.Point(3, 48);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label101, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(77, 16);
            this.label101.TabIndex = 2;
            this.label101.Text = "Every |30014";
            this.label101.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_numUpEcartMois
            // 
            this.m_numUpEcartMois.DoubleValue = 1;
            this.m_numUpEcartMois.IntValue = 1;
            this.m_extLinkField.SetLinkField(this.m_numUpEcartMois, "EcartMois");
            this.m_numUpEcartMois.Location = new System.Drawing.Point(88, 48);
            this.m_numUpEcartMois.LockEdition = false;
            this.m_numUpEcartMois.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.m_numUpEcartMois.Minimum = new decimal(new int[] {
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
            this.m_numUpEcartMois.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.label1.Location = new System.Drawing.Point(128, 24);
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
            this.label3.Text = "Each|30016";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // c2iNumericUpDown1
            // 
            this.c2iNumericUpDown1.DoubleValue = 1;
            this.c2iNumericUpDown1.IntValue = 1;
            this.m_extLinkField.SetLinkField(this.c2iNumericUpDown1, "NumJour");
            this.c2iNumericUpDown1.Location = new System.Drawing.Point(88, 24);
            this.c2iNumericUpDown1.LockEdition = false;
            this.c2iNumericUpDown1.Maximum = new decimal(new int[] {
            31,
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
            this.c2iNumericUpDown1.Size = new System.Drawing.Size(40, 20);
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
            this.label4.Location = new System.Drawing.Point(128, 48);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Month|30017";
            // 
            // CPanelPlanificationInterventionMensuelleJourMois
            // 
            this.Controls.Add(this.label4);
            this.Controls.Add(this.c2iNumericUpDown1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_numUpEcartMois);
            this.Controls.Add(this.label101);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CPanelPlanificationInterventionMensuelleJourMois";
            this.Size = new System.Drawing.Size(200, 72);
            this.Load += new System.EventHandler(this.CPanelPlanificationInterventionMensuelleJourMois_Load);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label101, 0);
            this.Controls.SetChildIndex(this.m_numUpEcartMois, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.c2iNumericUpDown1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            ((System.ComponentModel.ISupportInitialize)(this.m_numUpEcartMois)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c2iNumericUpDown1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void CPanelPlanificationInterventionMensuelleJourMois_Load(object sender, System.EventArgs e)
		{
		
		}



	}
}

