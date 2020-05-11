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
	public class CPanelPlanificationInterventionFrequente : CPanelPlanficationIntervention
	{
		private System.Windows.Forms.Label label3;
		private sc2i.win32.common.C2iNumericUpDown m_wndEcart;
		private System.Windows.Forms.ListView m_wndListeJours;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private Label label5;
		private sc2i.win32.common.C2iComboBox m_cmbUnite;
		private sc2i.win32.common.CWndSaisieHeure m_wndHeureFin;
		private System.ComponentModel.IContainer components = null;

		public CPanelPlanificationInterventionFrequente()
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
			CPanelPlanficationIntervention.RegisterPanelPlanification ( typeof(CPlanificationTacheFrequente),
				typeof(CPanelPlanificationInterventionFrequente) );
		}

		#region Code généré par le concepteur
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Monday|130");
			System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Tuesday|131");
			System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Wednesday|132");
			System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Thursday|133");
			System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("Friday|134");
			System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("Saturday|135");
			System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("Sunday|136");
			this.label3 = new System.Windows.Forms.Label();
			this.m_wndEcart = new sc2i.win32.common.C2iNumericUpDown();
			this.m_wndListeJours = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.label5 = new System.Windows.Forms.Label();
			this.m_cmbUnite = new sc2i.win32.common.C2iComboBox();
			this.m_wndHeureFin = new sc2i.win32.common.CWndSaisieHeure();
			((System.ComponentModel.ISupportInitialize)(this.m_wndEcart)).BeginInit();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.m_extLinkField.SetLinkField(this.label2, "");
			this.label2.Location = new System.Drawing.Point(0, 2);
			this.label2.Text = "From|126";
			// 
			// label3
			// 
			this.m_extLinkField.SetLinkField(this.label3, "");
			this.label3.Location = new System.Drawing.Point(222, 1);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 17);
			this.label3.TabIndex = 6;
			this.label3.Text = "Each|128";
			// 
			// m_wndEcart
			// 
			this.m_wndEcart.DoubleValue = 1;
			this.m_wndEcart.IntValue = 1;
			this.m_extLinkField.SetLinkField(this.m_wndEcart, "EcartSemaine");
			this.m_wndEcart.Location = new System.Drawing.Point(289, 0);
			this.m_wndEcart.LockEdition = false;
			this.m_wndEcart.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
			this.m_wndEcart.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndEcart, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_wndEcart.Name = "m_wndEcart";
			this.m_wndEcart.Size = new System.Drawing.Size(42, 20);
			this.m_wndEcart.TabIndex = 7;
			this.m_wndEcart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_wndEcart.ThousandsSeparator = true;
			this.m_wndEcart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
			this.m_wndListeJours.Location = new System.Drawing.Point(49, 24);
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
			// label5
			// 
			this.m_extLinkField.SetLinkField(this.label5, "");
			this.label5.Location = new System.Drawing.Point(137, 2);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(23, 16);
			this.label5.TabIndex = 10;
			this.label5.Text = "To|127";
			// 
			// m_cmbUnite
			// 
			this.m_cmbUnite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cmbUnite.IsLink = false;
			this.m_extLinkField.SetLinkField(this.m_cmbUnite, "");
			this.m_cmbUnite.Location = new System.Drawing.Point(332, 0);
			this.m_cmbUnite.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbUnite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_cmbUnite.Name = "m_cmbUnite";
			this.m_cmbUnite.Size = new System.Drawing.Size(97, 21);
			this.m_cmbUnite.TabIndex = 4003;
			// 
			// m_wndHeureFin
			// 
			this.m_extLinkField.SetLinkField(this.m_wndHeureFin, "");
			this.m_wndHeureFin.Location = new System.Drawing.Point(162, 0);
			this.m_wndHeureFin.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndHeureFin, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_wndHeureFin.Name = "m_wndHeureFin";
			this.m_wndHeureFin.NullAutorise = false;
			this.m_wndHeureFin.SaisieDuree = true;
			this.m_wndHeureFin.Size = new System.Drawing.Size(40, 20);
			this.m_wndHeureFin.TabIndex = 4004;
			this.m_wndHeureFin.ValeurHeure = 18.5;
			// 
			// CPanelPlanificationInterventionFrequente
			// 
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Controls.Add(this.m_wndHeureFin);
			this.Controls.Add(this.m_cmbUnite);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.m_wndListeJours);
			this.Controls.Add(this.m_wndEcart);
			this.Controls.Add(this.label3);
			this.m_extLinkField.SetLinkField(this, "");
			this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
			this.Name = "CPanelPlanificationInterventionFrequente";
			this.Size = new System.Drawing.Size(429, 80);
			this.BackColorChanged += new System.EventHandler(this.CPanelPlanificationInterventionFrequente_BackColorChanged);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.m_wndEcart, 0);
			this.Controls.SetChildIndex(this.m_wndListeJours, 0);
			this.Controls.SetChildIndex(this.label5, 0);
			this.Controls.SetChildIndex(this.m_cmbUnite, 0);
			this.Controls.SetChildIndex(this.m_wndHeureFin, 0);
			((System.ComponentModel.ISupportInitialize)(this.m_wndEcart)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
		public override void InitChamps(CPlanificationTache planification)
		{
			CUtilSurEnum.CCoupleEnumLibelle[] couples = CUtilSurEnum.GetCouplesFromEnum(typeof(CPlanificationTacheFrequente.EUniteTemps));
			m_cmbUnite.DataSource = couples;
			m_cmbUnite.DisplayMember = "Libelle";
			m_cmbUnite.ValueMember = "Valeur";
			base.InitChamps (planification);
			CPlanificationTacheFrequente plFreq = (CPlanificationTacheFrequente)planification;
			for ( int n = 0; n<7; n++ )
			{
				if ( (plFreq.JoursExecution & CUtilDate.GetJourBinaireForBaseLundi(n)) != 0 )
					m_wndListeJours.Items[n].Checked = true;
				else
					m_wndListeJours.Items[n].Checked = false;
			}
			int nIndex = 0;
			foreach (CUtilSurEnum.CCoupleEnumLibelle couple in couples)
			{
				if (couple.Valeur == (int)plFreq.Unite)
					m_cmbUnite.SelectedIndex = nIndex;
				nIndex++;
			}
			m_wndHeureFin.ValeurHeure = plFreq.HeureFin;
			m_wndEcart.DoubleValue = plFreq.Ecart;

			foreach (ListViewItem item in m_wndListeJours.Items)
				item.Text = I.TT(GetType(), item.Text);
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
			CPlanificationTacheFrequente plFreq = (CPlanificationTacheFrequente)Planification;
			plFreq.JoursExecution = jrs;
			if (m_wndHeureFin.ValeurHeure == null)
				m_wndHeureFin.ValeurHeure = 23;
			plFreq.HeureFin = (double)m_wndHeureFin.ValeurHeure;
			plFreq.Ecart = m_wndEcart.IntValue;
			plFreq.Unite = (CPlanificationTacheFrequente.EUniteTemps)m_cmbUnite.SelectedValue;
			
			return result;
		}

		private void label4_Click(object sender, System.EventArgs e)
		{
		
		}

		private void CPanelPlanificationInterventionFrequente_BackColorChanged(object sender, System.EventArgs e)
		{
			m_wndListeJours.BackColor = BackColor;
		}


	}
}

