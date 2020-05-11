using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using sc2i.workflow;
using sc2i.common;
using sc2i.common.planification;

namespace timos
{
	/// <summary>
	/// Description résumée de CFormParametresEntreeAgendaCyclique.
	/// </summary>
	public class CFormParametresEntreeAgendaCyclique : System.Windows.Forms.Form
	{
		private CEntreeAgenda m_entree = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button m_btnValiderModifications;
		private System.Windows.Forms.Button m_btnAnnulerModifications;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DateTimePicker m_dateDebut;
		private System.Windows.Forms.NumericUpDown m_nDureeJours;
		private System.Windows.Forms.NumericUpDown m_nDureeHeures;
		private System.Windows.Forms.NumericUpDown m_nDureeMinutes;
		private sc2i.win32.common.C2iDateTimeExPicker m_dateFin;
		private System.Windows.Forms.CheckBox m_chkSansHoraire;
		private System.Windows.Forms.Panel m_panelHoraires;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre1;
		private timos.win32.composants.CEditeurPlanificationIntervention m_panelPlanif;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre2;
		private System.Windows.Forms.Label label7;
		private sc2i.win32.common.GlacialList m_wndListeExclusions;
		private System.Windows.Forms.DateTimePicker m_dateDesactivation;
		private sc2i.win32.common.CWndLinkStd m_lnkAjouter;
        private sc2i.win32.common.CWndLinkStd m_lnkSupprimer;
        protected internal sc2i.win32.common.CExtStyle m_ExtStyle;
        private IContainer components;

		public CFormParametresEntreeAgendaCyclique()
		{
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			InitializeComponent();

			//
			// TODO : ajoutez le code du constructeur après l'appel à InitializeComponent
			//
		}

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Code généré par le Concepteur Windows Form
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormParametresEntreeAgendaCyclique));
            sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_dateDebut = new System.Windows.Forms.DateTimePicker();
            this.m_nDureeJours = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_nDureeHeures = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.m_nDureeMinutes = new System.Windows.Forms.NumericUpDown();
            this.m_btnValiderModifications = new System.Windows.Forms.Button();
            this.m_btnAnnulerModifications = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_dateFin = new sc2i.win32.common.C2iDateTimeExPicker();
            this.m_chkSansHoraire = new System.Windows.Forms.CheckBox();
            this.m_panelHoraires = new System.Windows.Forms.Panel();
            this.c2iPanelOmbre1 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_panelPlanif = new timos.win32.composants.CEditeurPlanificationIntervention();
            this.c2iPanelOmbre2 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_lnkSupprimer = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkAjouter = new sc2i.win32.common.CWndLinkStd();
            this.m_dateDesactivation = new System.Windows.Forms.DateTimePicker();
            this.m_wndListeExclusions = new sc2i.win32.common.GlacialList();
            this.label7 = new System.Windows.Forms.Label();
            this.m_ExtStyle = new sc2i.win32.common.CExtStyle();
            ((System.ComponentModel.ISupportInitialize)(this.m_nDureeJours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nDureeHeures)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nDureeMinutes)).BeginInit();
            this.panel1.SuspendLayout();
            this.m_panelHoraires.SuspendLayout();
            this.c2iPanelOmbre1.SuspendLayout();
            this.c2iPanelOmbre2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 21);
            this.m_ExtStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 1;
            this.label1.Text = "From|871";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(176, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.m_ExtStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 2;
            this.label2.Text = "To|872";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 23);
            this.m_ExtStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 3;
            this.label3.Text = "Duration|873";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_dateDebut
            // 
            this.m_dateDebut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.m_dateDebut.Location = new System.Drawing.Point(80, 104);
            this.m_dateDebut.Name = "m_dateDebut";
            this.m_dateDebut.Size = new System.Drawing.Size(88, 20);
            this.m_ExtStyle.SetStyleBackColor(this.m_dateDebut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_dateDebut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_dateDebut.TabIndex = 4;
            // 
            // m_nDureeJours
            // 
            this.m_nDureeJours.Location = new System.Drawing.Point(56, 128);
            this.m_nDureeJours.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.m_nDureeJours.Name = "m_nDureeJours";
            this.m_nDureeJours.Size = new System.Drawing.Size(48, 20);
            this.m_ExtStyle.SetStyleBackColor(this.m_nDureeJours, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_nDureeJours, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_nDureeJours.TabIndex = 6;
            this.m_nDureeJours.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(107, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 23);
            this.m_ExtStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 7;
            this.label4.Text = "Days|874";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(50, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 23);
            this.m_ExtStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 9;
            this.label5.Text = "Hours|875";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_nDureeHeures
            // 
            this.m_nDureeHeures.Location = new System.Drawing.Point(0, 0);
            this.m_nDureeHeures.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.m_nDureeHeures.Name = "m_nDureeHeures";
            this.m_nDureeHeures.Size = new System.Drawing.Size(48, 20);
            this.m_ExtStyle.SetStyleBackColor(this.m_nDureeHeures, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_nDureeHeures, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_nDureeHeures.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(152, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 23);
            this.m_ExtStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 11;
            this.label6.Text = "Minutes|876";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_nDureeMinutes
            // 
            this.m_nDureeMinutes.Location = new System.Drawing.Point(104, 0);
            this.m_nDureeMinutes.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.m_nDureeMinutes.Name = "m_nDureeMinutes";
            this.m_nDureeMinutes.Size = new System.Drawing.Size(48, 20);
            this.m_ExtStyle.SetStyleBackColor(this.m_nDureeMinutes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_nDureeMinutes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_nDureeMinutes.TabIndex = 10;
            // 
            // m_btnValiderModifications
            // 
            this.m_btnValiderModifications.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnValiderModifications.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnValiderModifications.ForeColor = System.Drawing.Color.White;
            this.m_btnValiderModifications.Image = ((System.Drawing.Image)(resources.GetObject("m_btnValiderModifications.Image")));
            this.m_btnValiderModifications.Location = new System.Drawing.Point(152, 0);
            this.m_btnValiderModifications.Name = "m_btnValiderModifications";
            this.m_btnValiderModifications.Size = new System.Drawing.Size(40, 40);
            this.m_ExtStyle.SetStyleBackColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnValiderModifications.TabIndex = 4016;
            this.m_btnValiderModifications.TabStop = false;
            this.m_btnValiderModifications.Click += new System.EventHandler(this.m_btnValiderModifications_Click);
            // 
            // m_btnAnnulerModifications
            // 
            this.m_btnAnnulerModifications.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnAnnulerModifications.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnAnnulerModifications.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnAnnulerModifications.ForeColor = System.Drawing.Color.White;
            this.m_btnAnnulerModifications.Image = ((System.Drawing.Image)(resources.GetObject("m_btnAnnulerModifications.Image")));
            this.m_btnAnnulerModifications.Location = new System.Drawing.Point(208, 0);
            this.m_btnAnnulerModifications.Name = "m_btnAnnulerModifications";
            this.m_btnAnnulerModifications.Size = new System.Drawing.Size(40, 40);
            this.m_ExtStyle.SetStyleBackColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAnnulerModifications.TabIndex = 4017;
            this.m_btnAnnulerModifications.TabStop = false;
            this.m_btnAnnulerModifications.Click += new System.EventHandler(this.m_btnAnnulerModifications_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.m_btnValiderModifications);
            this.panel1.Controls.Add(this.m_btnAnnulerModifications);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 376);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(470, 58);
            this.m_ExtStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 4018;
            // 
            // m_dateFin
            // 
            this.m_dateFin.BackColor = System.Drawing.Color.Transparent;
            this.m_dateFin.Checked = false;
            this.m_dateFin.CustomFormat = null;
            this.m_dateFin.ForeColor = System.Drawing.Color.Black;
            this.m_dateFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.m_dateFin.Location = new System.Drawing.Point(237, 104);
            this.m_dateFin.LockEdition = false;
            this.m_dateFin.Name = "m_dateFin";
            this.m_dateFin.Size = new System.Drawing.Size(159, 20);
            this.m_ExtStyle.SetStyleBackColor(this.m_dateFin, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_dateFin, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_dateFin.TabIndex = 4019;
            this.m_dateFin.TextNull = I.T("None|148");
            this.m_dateFin.Value = null;
            this.m_dateFin.Load += new System.EventHandler(this.m_dateFin_Load);
            // 
            // m_chkSansHoraire
            // 
            this.m_chkSansHoraire.Location = new System.Drawing.Point(168, 128);
            this.m_chkSansHoraire.Name = "m_chkSansHoraire";
            this.m_chkSansHoraire.Size = new System.Drawing.Size(144, 16);
            this.m_ExtStyle.SetStyleBackColor(this.m_chkSansHoraire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_chkSansHoraire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkSansHoraire.TabIndex = 4020;
            this.m_chkSansHoraire.Text = "Without time|857";
            this.m_chkSansHoraire.CheckedChanged += new System.EventHandler(this.m_chkSansHoraire_CheckedChanged);
            // 
            // m_panelHoraires
            // 
            this.m_panelHoraires.Controls.Add(this.label6);
            this.m_panelHoraires.Controls.Add(this.m_nDureeMinutes);
            this.m_panelHoraires.Controls.Add(this.label5);
            this.m_panelHoraires.Controls.Add(this.m_nDureeHeures);
            this.m_panelHoraires.Location = new System.Drawing.Point(168, 144);
            this.m_panelHoraires.Name = "m_panelHoraires";
            this.m_panelHoraires.Size = new System.Drawing.Size(272, 24);
            this.m_ExtStyle.SetStyleBackColor(this.m_panelHoraires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_panelHoraires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelHoraires.TabIndex = 4021;
            // 
            // c2iPanelOmbre1
            // 
            this.c2iPanelOmbre1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre1.Controls.Add(this.m_panelHoraires);
            this.c2iPanelOmbre1.Controls.Add(this.m_dateDebut);
            this.c2iPanelOmbre1.Controls.Add(this.m_chkSansHoraire);
            this.c2iPanelOmbre1.Controls.Add(this.label3);
            this.c2iPanelOmbre1.Controls.Add(this.label1);
            this.c2iPanelOmbre1.Controls.Add(this.m_nDureeJours);
            this.c2iPanelOmbre1.Controls.Add(this.label4);
            this.c2iPanelOmbre1.Controls.Add(this.m_panelPlanif);
            this.c2iPanelOmbre1.Controls.Add(this.m_dateFin);
            this.c2iPanelOmbre1.Controls.Add(this.label2);
            this.c2iPanelOmbre1.ForeColor = System.Drawing.Color.Black;
            this.c2iPanelOmbre1.Location = new System.Drawing.Point(8, 8);
            this.c2iPanelOmbre1.LockEdition = false;
            this.c2iPanelOmbre1.Name = "c2iPanelOmbre1";
            this.c2iPanelOmbre1.Size = new System.Drawing.Size(455, 184);
            this.m_ExtStyle.SetStyleBackColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_ExtStyle.SetStyleForeColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre1.TabIndex = 4023;
            // 
            // m_panelPlanif
            // 
            this.m_panelPlanif.Location = new System.Drawing.Point(0, 0);
            this.m_panelPlanif.LockEdition = false;
            this.m_panelPlanif.Name = "m_panelPlanif";
            this.m_panelPlanif.Size = new System.Drawing.Size(440, 56);
            this.m_ExtStyle.SetStyleBackColor(this.m_panelPlanif, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_panelPlanif, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelPlanif.TabIndex = 4022;
            // 
            // c2iPanelOmbre2
            // 
            this.c2iPanelOmbre2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre2.Controls.Add(this.m_lnkSupprimer);
            this.c2iPanelOmbre2.Controls.Add(this.m_lnkAjouter);
            this.c2iPanelOmbre2.Controls.Add(this.m_wndListeExclusions);
            this.c2iPanelOmbre2.Controls.Add(this.label7);
            this.c2iPanelOmbre2.Controls.Add(this.m_dateDesactivation);
            this.c2iPanelOmbre2.ForeColor = System.Drawing.Color.Black;
            this.c2iPanelOmbre2.Location = new System.Drawing.Point(8, 192);
            this.c2iPanelOmbre2.LockEdition = false;
            this.c2iPanelOmbre2.Name = "c2iPanelOmbre2";
            this.c2iPanelOmbre2.Size = new System.Drawing.Size(456, 168);
            this.m_ExtStyle.SetStyleBackColor(this.c2iPanelOmbre2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_ExtStyle.SetStyleForeColor(this.c2iPanelOmbre2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre2.TabIndex = 4024;
            // 
            // m_lnkSupprimer
            // 
            this.m_lnkSupprimer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkSupprimer.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkSupprimer.Location = new System.Drawing.Point(192, 32);
            this.m_lnkSupprimer.Name = "m_lnkSupprimer";
            this.m_lnkSupprimer.Size = new System.Drawing.Size(80, 16);
            this.m_ExtStyle.SetStyleBackColor(this.m_lnkSupprimer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_lnkSupprimer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSupprimer.TabIndex = 8;
            this.m_lnkSupprimer.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkSupprimer.LinkClicked += new System.EventHandler(this.m_lnkSupprimer_LinkClicked);
            // 
            // m_lnkAjouter
            // 
            this.m_lnkAjouter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAjouter.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkAjouter.Location = new System.Drawing.Point(192, 8);
            this.m_lnkAjouter.Name = "m_lnkAjouter";
            this.m_lnkAjouter.Size = new System.Drawing.Size(56, 16);
            this.m_ExtStyle.SetStyleBackColor(this.m_lnkAjouter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_lnkAjouter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAjouter.TabIndex = 7;
            this.m_lnkAjouter.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAjouter.LinkClicked += new System.EventHandler(this.m_lnkAjouter_LinkClicked);
            // 
            // m_dateDesactivation
            // 
            this.m_dateDesactivation.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.m_dateDesactivation.Location = new System.Drawing.Point(272, 8);
            this.m_dateDesactivation.Name = "m_dateDesactivation";
            this.m_dateDesactivation.Size = new System.Drawing.Size(88, 20);
            this.m_ExtStyle.SetStyleBackColor(this.m_dateDesactivation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_dateDesactivation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_dateDesactivation.TabIndex = 5;
            // 
            // m_wndListeExclusions
            // 
            this.m_wndListeExclusions.AllowColumnResize = true;
            this.m_wndListeExclusions.AllowMultiselect = false;
            this.m_wndListeExclusions.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.m_wndListeExclusions.AlternatingColors = false;
            this.m_wndListeExclusions.AutoHeight = true;
            this.m_wndListeExclusions.AutoSort = true;
            this.m_wndListeExclusions.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.m_wndListeExclusions.CanChangeActivationCheckBoxes = false;
            this.m_wndListeExclusions.CheckBoxes = false;
            glColumn2.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn2.ActiveControlItems")));
            glColumn2.BackColor = System.Drawing.Color.Transparent;
            glColumn2.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn2.ForColor = System.Drawing.Color.Black;
            glColumn2.ImageIndex = -1;
            glColumn2.IsCheckColumn = false;
            glColumn2.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn2.Name = "Column1";
            glColumn2.Propriete = "Date";
            glColumn2.Text = "Date";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            glColumn2.Width = 100;
            this.m_wndListeExclusions.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn2});
            this.m_wndListeExclusions.ContexteUtilisation = "";
            this.m_wndListeExclusions.EnableCustomisation = false;
            this.m_wndListeExclusions.FocusedItem = null;
            this.m_wndListeExclusions.FullRowSelect = true;
            this.m_wndListeExclusions.GLGridLines = sc2i.win32.common.GLGridStyles.gridNone;
            this.m_wndListeExclusions.GridColor = System.Drawing.Color.Gray;
            this.m_wndListeExclusions.HeaderHeight = 0;
            this.m_wndListeExclusions.HeaderStyle = sc2i.win32.common.GLHeaderStyles.Normal;
            this.m_wndListeExclusions.HeaderTextColor = System.Drawing.Color.Black;
            this.m_wndListeExclusions.HeaderVisible = false;
            this.m_wndListeExclusions.HeaderWordWrap = false;
            this.m_wndListeExclusions.HotColumnIndex = -1;
            this.m_wndListeExclusions.HotItemIndex = -1;
            this.m_wndListeExclusions.HotTracking = false;
            this.m_wndListeExclusions.HotTrackingColor = System.Drawing.Color.LightGray;
            this.m_wndListeExclusions.ImageList = null;
            this.m_wndListeExclusions.ItemHeight = 17;
            this.m_wndListeExclusions.ItemWordWrap = false;
            this.m_wndListeExclusions.ListeSource = null;
            this.m_wndListeExclusions.Location = new System.Drawing.Point(72, 8);
            this.m_wndListeExclusions.MaxHeight = 17;
            this.m_wndListeExclusions.Name = "m_wndListeExclusions";
            this.m_wndListeExclusions.SelectedTextColor = System.Drawing.Color.White;
            this.m_wndListeExclusions.SelectionColor = System.Drawing.Color.DarkBlue;
            this.m_wndListeExclusions.ShowBorder = true;
            this.m_wndListeExclusions.ShowFocusRect = false;
            this.m_wndListeExclusions.Size = new System.Drawing.Size(120, 134);
            this.m_wndListeExclusions.SortIndex = 0;
            this.m_ExtStyle.SetStyleBackColor(this.m_wndListeExclusions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_wndListeExclusions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeExclusions.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.m_wndListeExclusions.TabIndex = 4;
            this.m_wndListeExclusions.Text = "glacialList1";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 23);
            this.m_ExtStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 3;
            this.label7.Text = "Exclusions|877";
            // 
            // CFormParametresEntreeAgendaCyclique
            // 
            this.AcceptButton = this.m_btnValiderModifications;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.m_btnAnnulerModifications;
            this.ClientSize = new System.Drawing.Size(470, 434);
            this.ControlBox = false;
            this.Controls.Add(this.c2iPanelOmbre2);
            this.Controls.Add(this.c2iPanelOmbre1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CFormParametresEntreeAgendaCyclique";
            this.m_ExtStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "Cyclic entry|870";
            this.Load += new System.EventHandler(this.CFormParametresEntreeAgendaCyclique_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_nDureeJours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nDureeHeures)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nDureeMinutes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.m_panelHoraires.ResumeLayout(false);
            this.c2iPanelOmbre1.ResumeLayout(false);
            this.c2iPanelOmbre1.PerformLayout();
            this.c2iPanelOmbre2.ResumeLayout(false);
            this.c2iPanelOmbre2.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		public static bool EditeEntree ( CEntreeAgenda entree )
		{
			CFormParametresEntreeAgendaCyclique form = new CFormParametresEntreeAgendaCyclique();
			form.m_entree = entree;
			bool bResult = form.ShowDialog() == DialogResult.OK;
			form.Dispose();
			return bResult;
		}

		/// /////////////////////////////////////////////////////////////////
		private void CFormParametresEntreeAgendaCyclique_Load(object sender, System.EventArgs e)
		{
			CPlanificationTache planif = m_entree.PlanificationCyclique;
			if ( planif == null )
			{
				CPlanificationTacheHebdomadaire ph = new CPlanificationTacheHebdomadaire();
				planif = ph;
				
				ph.JoursExecution = CUtilDate.GetJourBinaireFor ( m_entree.DateDebut.DayOfWeek );
				ph.Heure = m_entree.DateDebut.Hour;
				ph.EcartSemaine = 1;
			}
			m_panelPlanif.Init ( planif );
			m_dateDebut.Value = m_entree.DateDebut;
			m_dateFin.Value = m_entree.DateFinCyclique;
			TimeSpan sp = m_entree.DateFin - m_entree.DateDebut;
			m_chkSansHoraire.Checked = m_entree.SansHoraire;
			if ( !m_entree.SansHoraire )
				m_nDureeJours.Value = (int)sp.TotalDays;
			else
				m_nDureeJours.Value = (int)(sp.TotalDays+.999999999);

			m_nDureeHeures.Value = (int)sp.Hours;
			m_nDureeMinutes.Value = (int)sp.Minutes;
			m_wndListeExclusions.ListeSource = m_entree.Desactivations;
			
		}

		private void m_btnAnnulerModifications_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void m_btnValiderModifications_Click(object sender, System.EventArgs e)
		{
			if ( m_panelPlanif.Planification == null )
				return;
			m_panelPlanif.ValideDonnees();
			CPlanificationTache planif = m_panelPlanif.Planification;
			if ( m_chkSansHoraire.Checked )
				planif.Heure = 0;
			m_entree.PlanificationCyclique = planif;
			
			int nHeure = (int)planif.Heure;
			int nMin = (int)((planif.Heure-nHeure)*100);
			m_entree.DateDebut = new DateTime ( m_dateDebut.Value.Year,
				m_dateDebut.Value.Month,
				m_dateDebut.Value.Day,
				nHeure,
				nMin,
				0);
			DateTime dt = m_entree.DateDebut;
			if ( !m_chkSansHoraire.Checked )
			{
				dt = dt.AddDays ( (int)m_nDureeJours.Value );
				dt = dt.AddHours ( (int)m_nDureeHeures.Value );
				dt = dt.AddMinutes ( (int)m_nDureeMinutes.Value );
			}
			else
				dt = dt.AddDays ( (int)m_nDureeJours.Value-1);
			m_entree.DateFin = dt;
			m_entree.DateFinCyclique = m_dateFin.Value;
			m_entree.SansHoraire = m_chkSansHoraire.Checked;
			DialogResult = DialogResult.OK;
			m_entree.NettoieDesactivations();
			Close();
		}

		/// /////////////////////////////////////////////////////////////
		private void m_lnkAjouter_LinkClicked(object sender, System.EventArgs e)
		{
			foreach ( CDesctivationEntreeAgendaCyclique desac in m_entree.Desactivations )
			{
				if ( desac.Date == m_dateDesactivation.Value.Date )
					return;
			}
			CDesctivationEntreeAgendaCyclique desacNew = new CDesctivationEntreeAgendaCyclique(m_entree.ContexteDonnee);
			desacNew.EntreeAgenda = m_entree;
			desacNew.Date = m_dateDesactivation.Value;
			m_wndListeExclusions.ListeSource = null;
			m_wndListeExclusions.ListeSource = m_entree.Desactivations;
			m_wndListeExclusions.Refresh();
		}

		/// /////////////////////////////////////////////////////////////////
		private void m_lnkSupprimer_LinkClicked(object sender, System.EventArgs e)
		{
			ArrayList lst = new ArrayList(m_wndListeExclusions.SelectedItems);
			foreach ( CDesctivationEntreeAgendaCyclique desactivation in lst )
				desactivation.Delete();
			m_wndListeExclusions.ListeSource = m_entree.Desactivations;
			m_wndListeExclusions.Refresh();
		}

		private void m_chkSansHoraire_CheckedChanged(object sender, System.EventArgs e)
		{
			m_panelHoraires.Visible = !m_chkSansHoraire.Checked;
			if ( m_chkSansHoraire.Checked )
				m_nDureeJours.Minimum = 1;
			else
				m_nDureeJours.Minimum = 0;
        }

        private void m_dateFin_Load(object sender, EventArgs e)
        {

        }

		/// /////////////////////////////////////////////////////////////////
		
	}
}
