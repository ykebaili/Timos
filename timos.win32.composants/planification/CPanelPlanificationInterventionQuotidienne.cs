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
	public class CPanelPlanificationInterventionQuotidienne : CPanelPlanficationIntervention
	{
		private System.Windows.Forms.Label label18;
		private sc2i.win32.common.C2iNumericUpDown m_numUpEcartJours;
		private System.Windows.Forms.Label label1;
		private System.ComponentModel.IContainer components = null;

		public CPanelPlanificationInterventionQuotidienne()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();

			// TODO : ajoutez les initialisations après l'appel à InitializeComponent
		}

		public static void Autoexec()
		{
			CPanelPlanficationIntervention.RegisterPanelPlanification ( typeof(CPlanificationTacheQuotidienne),
				typeof(CPanelPlanificationInterventionQuotidienne) );
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
			this.label18 = new System.Windows.Forms.Label();
			this.m_numUpEcartJours = new sc2i.win32.common.C2iNumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.m_numUpEcartJours)).BeginInit();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.m_extLinkField.SetLinkField(this.label18, "");
			this.label18.Location = new System.Drawing.Point(16, 24);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label18, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label18.Name = "label2";
			this.label18.Size = new System.Drawing.Size(64, 16);
			this.label18.TabIndex = 2;
			this.label18.Text = "Every|30014";
			this.label18.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// m_numUpEcartJours
			// 
			this.m_numUpEcartJours.DoubleValue = 1;
			this.m_numUpEcartJours.IntValue = 1;
			this.m_extLinkField.SetLinkField(this.m_numUpEcartJours, "EcartJours");
			this.m_numUpEcartJours.Location = new System.Drawing.Point(88, 24);
			this.m_numUpEcartJours.LockEdition = false;
			this.m_numUpEcartJours.Maximum = new System.Decimal(new int[] {
																			  100000,
																			  0,
																			  0,
																			  0});
			this.m_numUpEcartJours.Minimum = new System.Decimal(new int[] {
																			  1,
																			  0,
																			  0,
																			  0});
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_numUpEcartJours, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_numUpEcartJours.Name = "m_numUpEcartJours";
			this.m_numUpEcartJours.Size = new System.Drawing.Size(40, 20);
			this.m_numUpEcartJours.TabIndex = 4;
			this.m_numUpEcartJours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_numUpEcartJours.ThousandsSeparator = true;
			this.m_numUpEcartJours.Value = new System.Decimal(new int[] {
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
			this.label1.Size = new System.Drawing.Size(40, 16);
			this.label1.TabIndex = 5;
			this.label1.Text = "Jour(s)";
			// 
			// CPanelPlanificationInterventionQuotidienne
			// 
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_numUpEcartJours);
			this.Controls.Add(this.label18);
			this.m_extLinkField.SetLinkField(this, "");
			this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
			this.Name = "CPanelPlanificationInterventionQuotidienne";
			this.Size = new System.Drawing.Size(168, 48);
			this.Load += new System.EventHandler(this.CPanelPlanificationInterventionQuotidienne_Load);
			this.Controls.SetChildIndex(this.label18, 0);
			this.Controls.SetChildIndex(this.m_numUpEcartJours, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			((System.ComponentModel.ISupportInitialize)(this.m_numUpEcartJours)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void CPanelPlanificationInterventionQuotidienne_Load(object sender, System.EventArgs e)
		{
		
		}



	}
}

