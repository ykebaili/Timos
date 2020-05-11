using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;


using sc2i.data;
using sc2i.data.dynamic;
using sc2i.common;
using sc2i.win32.common;
using sc2i.win32.data;
using sc2i.win32.data.navigation;
using sc2i.multitiers.client;


using timos.data;
using timos.data.preventives;

namespace timos.preventives
{
	/// <summary>
	/// Description résumée de CControleDecoupage.
	/// </summary>
	public class CControleDecoupage : System.Windows.Forms.UserControl
	{
		#region Code généré par le Concepteur de composants
		private C2iComboBox m_cmbPeriodicite;
		private C2iTextBoxNumerique m_tbnNbPeriode;
		private DateTimePicker m_ctrlDateDebut;
		private Label m_lblDecoupage;
		private Label m_lblDateStart;
		private DateTimePicker m_ctrlDateLimite;
		private Label m_lblDateLimite;
		private Panel m_panStartDate;
		private Panel m_panEndDate;
		private Panel m_panCut;
		private System.ComponentModel.IContainer components = null;


		/// <summary> 
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		/// <summary> 
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.m_cmbPeriodicite = new sc2i.win32.common.C2iComboBox();
			this.m_tbnNbPeriode = new sc2i.win32.common.C2iTextBoxNumerique();
			this.m_ctrlDateDebut = new System.Windows.Forms.DateTimePicker();
			this.m_lblDecoupage = new System.Windows.Forms.Label();
			this.m_lblDateStart = new System.Windows.Forms.Label();
			this.m_ctrlDateLimite = new System.Windows.Forms.DateTimePicker();
			this.m_lblDateLimite = new System.Windows.Forms.Label();
			this.m_panStartDate = new System.Windows.Forms.Panel();
			this.m_panEndDate = new System.Windows.Forms.Panel();
			this.m_panCut = new System.Windows.Forms.Panel();
			this.m_panStartDate.SuspendLayout();
			this.m_panEndDate.SuspendLayout();
			this.m_panCut.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_cmbPeriodicite
			// 
			this.m_cmbPeriodicite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_cmbPeriodicite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cmbPeriodicite.FormattingEnabled = true;
			this.m_cmbPeriodicite.IsLink = false;
			this.m_cmbPeriodicite.Location = new System.Drawing.Point(150, 4);
			this.m_cmbPeriodicite.LockEdition = false;
			this.m_cmbPeriodicite.Name = "m_cmbPeriodicite";
			this.m_cmbPeriodicite.Size = new System.Drawing.Size(125, 21);
			this.m_cmbPeriodicite.TabIndex = 4020;
			this.m_cmbPeriodicite.SelectionChangeCommitted += new System.EventHandler(this.m_cmbPeriodicite_SelectionChangeCommitted);
			// 
			// m_tbnNbPeriode
			// 
			this.m_tbnNbPeriode.Arrondi = 0;
			this.m_tbnNbPeriode.DecimalAutorise = false;
			this.m_tbnNbPeriode.DoubleValue = 0;
			this.m_tbnNbPeriode.IntValue = 0;
			this.m_tbnNbPeriode.Location = new System.Drawing.Point(101, 4);
			this.m_tbnNbPeriode.LockEdition = false;
			this.m_tbnNbPeriode.Name = "m_tbnNbPeriode";
			this.m_tbnNbPeriode.NullAutorise = false;
			this.m_tbnNbPeriode.SelectAllOnEnter = true;
			this.m_tbnNbPeriode.Size = new System.Drawing.Size(43, 20);
			this.m_tbnNbPeriode.TabIndex = 4019;
			this.m_tbnNbPeriode.Text = "0";
			this.m_tbnNbPeriode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.m_tbnNbPeriode.TextChanged += new System.EventHandler(this.m_tbnNbPeriode_TextChanged);
			// 
			// m_ctrlDateDebut
			// 
			this.m_ctrlDateDebut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.m_ctrlDateDebut.Location = new System.Drawing.Point(104, 3);
			this.m_ctrlDateDebut.Name = "m_ctrlDateDebut";
			this.m_ctrlDateDebut.Size = new System.Drawing.Size(94, 20);
			this.m_ctrlDateDebut.TabIndex = 4021;
			this.m_ctrlDateDebut.ValueChanged += new System.EventHandler(this.m_ctrlDateDebut_ValueChanged);
			// 
			// m_lblDecoupage
			// 
			this.m_lblDecoupage.Location = new System.Drawing.Point(3, 3);
			this.m_lblDecoupage.Name = "m_lblDecoupage";
			this.m_lblDecoupage.Size = new System.Drawing.Size(140, 21);
			this.m_lblDecoupage.TabIndex = 4017;
			this.m_lblDecoupage.Text = "Cut all them|1304";
			this.m_lblDecoupage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lblDateStart
			// 
			this.m_lblDateStart.Location = new System.Drawing.Point(3, 3);
			this.m_lblDateStart.Name = "m_lblDateStart";
			this.m_lblDateStart.Size = new System.Drawing.Size(99, 21);
			this.m_lblDateStart.TabIndex = 4016;
			this.m_lblDateStart.Text = "Start Date|610";
			this.m_lblDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_ctrlDateLimite
			// 
			this.m_ctrlDateLimite.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.m_ctrlDateLimite.Location = new System.Drawing.Point(104, 3);
			this.m_ctrlDateLimite.Name = "m_ctrlDateLimite";
			this.m_ctrlDateLimite.Size = new System.Drawing.Size(94, 20);
			this.m_ctrlDateLimite.TabIndex = 4022;
			this.m_ctrlDateLimite.ValueChanged += new System.EventHandler(this.m_ctrlDateLimite_ValueChanged);
			// 
			// m_lblDateLimite
			// 
			this.m_lblDateLimite.Location = new System.Drawing.Point(3, 3);
			this.m_lblDateLimite.Name = "m_lblDateLimite";
			this.m_lblDateLimite.Size = new System.Drawing.Size(99, 21);
			this.m_lblDateLimite.TabIndex = 4018;
			this.m_lblDateLimite.Text = "Deadline|1149";
			this.m_lblDateLimite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_panStartDate
			// 
			this.m_panStartDate.Controls.Add(this.m_lblDateStart);
			this.m_panStartDate.Controls.Add(this.m_ctrlDateDebut);
			this.m_panStartDate.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_panStartDate.Location = new System.Drawing.Point(0, 0);
			this.m_panStartDate.Name = "m_panStartDate";
			this.m_panStartDate.Size = new System.Drawing.Size(201, 29);
			this.m_panStartDate.TabIndex = 4023;
			// 
			// m_panEndDate
			// 
			this.m_panEndDate.Controls.Add(this.m_lblDateLimite);
			this.m_panEndDate.Controls.Add(this.m_ctrlDateLimite);
			this.m_panEndDate.Dock = System.Windows.Forms.DockStyle.Right;
			this.m_panEndDate.Location = new System.Drawing.Point(479, 0);
			this.m_panEndDate.Name = "m_panEndDate";
			this.m_panEndDate.Size = new System.Drawing.Size(201, 29);
			this.m_panEndDate.TabIndex = 4024;
			// 
			// m_panCut
			// 
			this.m_panCut.Controls.Add(this.m_tbnNbPeriode);
			this.m_panCut.Controls.Add(this.m_lblDecoupage);
			this.m_panCut.Controls.Add(this.m_cmbPeriodicite);
			this.m_panCut.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_panCut.Location = new System.Drawing.Point(201, 0);
			this.m_panCut.Name = "m_panCut";
			this.m_panCut.Size = new System.Drawing.Size(278, 29);
			this.m_panCut.TabIndex = 4025;
			// 
			// CControleDecoupage
			// 
			this.Controls.Add(this.m_panCut);
			this.Controls.Add(this.m_panEndDate);
			this.Controls.Add(this.m_panStartDate);
			this.Name = "CControleDecoupage";
			this.Size = new System.Drawing.Size(680, 29);
			this.m_panStartDate.ResumeLayout(false);
			this.m_panEndDate.ResumeLayout(false);
			this.m_panCut.ResumeLayout(false);
			this.m_panCut.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion



		public CControleDecoupage()
		{
			InitializeComponent();
		}

		public void Initialiser(CDecoupage decoupage)
		{
			m_bInitialise = false;
			m_bSkipEveChangement = true;
			if (m_cmbPeriodicite.Items.Count == 0)
				InitComboPeriodicite();

			m_decoupage = decoupage;
			
			if (m_decoupage == null || !m_decoupage.Valide)
			{
				DateTime dtStart = DateTime.Now.Date;
				DateTime dtEnd = dtStart.AddYears(1);
				m_decoupage = new CDecoupage(dtStart, dtEnd, 3, EEchelleTemps.Mois, true, EEchelleTemps.Jour);
				if (ChangementDecoupage != null)
					ChangementDecoupage(Decoupage);
			}

			MAJAffichageSansNotificationModification();
			
			m_bInitialise = true;
			m_bSkipEveChangement = false;
		}

		public void MAJAffichageSansNotificationModification()
		{
			m_bSkipEveChangement = true;
			m_cmbPeriodicite.SelectedValue = (int)Decoupage.Periodicite;
			m_tbnNbPeriode.IntValue = Decoupage.NombrePeriode;
			m_ctrlDateDebut.Value = Decoupage.DateDebut;
			m_ctrlDateLimite.Value = Decoupage.DateFinSelonTranches;
			m_bSkipEveChangement = false;
		}


		private bool m_bInitialise = false;

		private CDecoupage m_decoupage;
		public CDecoupage Decoupage
		{
			get
			{
				return m_decoupage;
			}
		}


		public event EveChangementPeriodicite ChangementDecoupage;

		
		private void InitComboPeriodicite()
		{
			m_cmbPeriodicite.FillWithEnumALibelle(typeof(CEchelleTemps));
			m_cmbPeriodicite.SelectedValue = new CEchelleTemps(EEchelleTemps.Annee).CodeInt;
		}

		//Evenements
		private void m_cmbPeriodicite_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (m_bSkipEveChangement || !m_bInitialise)
				return;
			m_decoupage.Periodicite = (EEchelleTemps)m_cmbPeriodicite.SelectedValue;
			SetModifie();
		}
		private bool m_bSkipEveChangement;
		private void m_ctrlDateDebut_ValueChanged(object sender, EventArgs e)
		{
			if (m_bSkipEveChangement || !m_bInitialise)
				return;
			
			m_decoupage.DateDebut = m_ctrlDateDebut.Value;

			SetModifie();
		}
		private void m_ctrlDateLimite_ValueChanged(object sender, EventArgs e)
		{
			if(m_bSkipEveChangement || !m_bInitialise)
				return;
			m_decoupage.DateFin = m_ctrlDateLimite.Value;
			SetModifie();
		}
		private void m_tbnNbPeriode_TextChanged(object sender, EventArgs e)
		{
			if (m_bSkipEveChangement || !m_bInitialise)
				return;

			if (m_tbnNbPeriode.IntValue.HasValue && m_tbnNbPeriode.IntValue.Value != 0)
			{
				m_decoupage.NombrePeriode = m_tbnNbPeriode.IntValue.Value;
				
				SetModifie();
			}
			if (m_tbnNbPeriode.IntValue.Value < 1)
				m_tbnNbPeriode.IntValue = 1;

		}

		private void SetModifie()
		{
			if (ChangementDecoupage != null)
				ChangementDecoupage(m_decoupage);
		}

	}
	public delegate void EveChangementPeriodicite (CDecoupage decoupage);
}
