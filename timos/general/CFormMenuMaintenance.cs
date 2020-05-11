using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using sc2i.win32.navigation;
using sc2i.common;
using sc2i.data;
using sc2i.multitiers.client;
using sc2i.win32.data;

using timos.version;
using timos.preventives;
using timos.data;
using timos.data.preventives;
using sc2i.win32.common;
using timos.Properties;

namespace timos
{
	/// <summary>
	/// Description résumée de CFormMenuMaintenance.
	/// </summary>
	[DynamicForm("Maintenance")]
	public class CFormMenuMaintenance : CFormMaxiSansMenu, IFormNavigable
	{
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre3;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox m_chkSuiviDates;
		private sc2i.win32.common.C2iPanelOmbre m_panDossier;
		private LinkLabel linkLabel1;
        private LinkLabel linkLabel2;
        private Label m_lblDossiers;
        private LinkLabel m_lnkCalendars;
		private sc2i.win32.common.C2iPanelOmbre m_panInterTicket;
		private LinkLabel m_lnkTypesInterventions;
        private Label m_lblInterTicket;
        private LinkLabel m_lnkTypesOperation;
        private LinkLabel m_lnkHoraireJournalier;
        private LinkLabel m_lnkTypeOccupationH;
        private LinkLabel m_lnkQualificationsAppel;
        private LinkLabel linkLabel4;
        private LinkLabel linkLabel5;
        private LinkLabel linkLabel6;
        private LinkLabel linkLabel7;
        private LinkLabel linkLabel8;
		private LinkLabel m_lnkTypePhaseTicket;
        private LinkLabel linkLabel9;
		private LinkLabel m_lnkProfilElement;
        private Panel m_panInterTicket_2;
        private Panel m_panDossier_2;
        private LinkLabel m_lnkListeInterventions;
        private LinkLabel m_lnkListesOperations;
        private LinkLabel linkLabel11;
        private LinkLabel linkLabel12;
        private LinkLabel m_lnkTableauPlanning;
        private LinkLabel m_lnkTypeTableauPlanning;
        private LinkLabel m_lnkTypesPreventives;
        private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre1;
        private Panel panel1;
        private Label label1;
        private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre2;
        private Panel panel2;
        private Label label2;
        private LinkLabel linkLabel3;
        private CExtModulesAssociator m_extModuleAssociator;
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CFormMenuMaintenance()
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
            this.c2iPanelOmbre3 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_chkSuiviDates = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_panDossier = new sc2i.win32.common.C2iPanelOmbre();
            this.m_panDossier_2 = new System.Windows.Forms.Panel();
            this.m_lblDossiers = new System.Windows.Forms.Label();
            this.m_lnkTypeOccupationH = new System.Windows.Forms.LinkLabel();
            this.m_lnkHoraireJournalier = new System.Windows.Forms.LinkLabel();
            this.m_lnkCalendars = new System.Windows.Forms.LinkLabel();
            this.m_lnkTypeTableauPlanning = new System.Windows.Forms.LinkLabel();
            this.m_lnkTableauPlanning = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.m_panInterTicket = new sc2i.win32.common.C2iPanelOmbre();
            this.m_panInterTicket_2 = new System.Windows.Forms.Panel();
            this.m_lnkTypesPreventives = new System.Windows.Forms.LinkLabel();
            this.m_lblInterTicket = new System.Windows.Forms.Label();
            this.m_lnkListeInterventions = new System.Windows.Forms.LinkLabel();
            this.m_lnkProfilElement = new System.Windows.Forms.LinkLabel();
            this.m_lnkListesOperations = new System.Windows.Forms.LinkLabel();
            this.m_lnkTypesOperation = new System.Windows.Forms.LinkLabel();
            this.m_lnkTypesInterventions = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel12 = new System.Windows.Forms.LinkLabel();
            this.linkLabel11 = new System.Windows.Forms.LinkLabel();
            this.linkLabel7 = new System.Windows.Forms.LinkLabel();
            this.linkLabel9 = new System.Windows.Forms.LinkLabel();
            this.m_lnkQualificationsAppel = new System.Windows.Forms.LinkLabel();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.linkLabel8 = new System.Windows.Forms.LinkLabel();
            this.m_lnkTypePhaseTicket = new System.Windows.Forms.LinkLabel();
            this.linkLabel6 = new System.Windows.Forms.LinkLabel();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.c2iPanelOmbre1 = new sc2i.win32.common.C2iPanelOmbre();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.c2iPanelOmbre2 = new sc2i.win32.common.C2iPanelOmbre();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.m_extModuleAssociator = new timos.CExtModulesAssociator();
            this.c2iPanelOmbre3.SuspendLayout();
            this.m_panDossier.SuspendLayout();
            this.m_panDossier_2.SuspendLayout();
            this.m_panInterTicket.SuspendLayout();
            this.m_panInterTicket_2.SuspendLayout();
            this.c2iPanelOmbre1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.c2iPanelOmbre2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // c2iPanelOmbre3
            // 
            this.c2iPanelOmbre3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.c2iPanelOmbre3.Controls.Add(this.m_chkSuiviDates);
            this.c2iPanelOmbre3.Controls.Add(this.label4);
            this.c2iPanelOmbre3.Location = new System.Drawing.Point(10, 10);
            this.c2iPanelOmbre3.LockEdition = false;
            this.m_extModuleAssociator.SetModules(this.c2iPanelOmbre3, "");
            this.c2iPanelOmbre3.Name = "c2iPanelOmbre3";
            this.c2iPanelOmbre3.Size = new System.Drawing.Size(184, 88);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iPanelOmbre3.TabIndex = 11;
            // 
            // m_chkSuiviDates
            // 
            this.m_chkSuiviDates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_chkSuiviDates.ForeColor = System.Drawing.Color.Maroon;
            this.m_chkSuiviDates.Location = new System.Drawing.Point(16, 32);
            this.m_extModuleAssociator.SetModules(this.m_chkSuiviDates, "");
            this.m_chkSuiviDates.Name = "m_chkSuiviDates";
            this.m_chkSuiviDates.Size = new System.Drawing.Size(104, 24);
            this.m_extStyle.SetStyleBackColor(this.m_chkSuiviDates, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkSuiviDates, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkSuiviDates.TabIndex = 5;
            this.m_chkSuiviDates.Text = "Date reporting|30174";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 8);
            this.m_extModuleAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 4;
            this.label4.Text = "Miscellaneous|30175";
            // 
            // m_panDossier
            // 
            this.m_panDossier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panDossier.Controls.Add(this.m_panDossier_2);
            this.m_panDossier.Location = new System.Drawing.Point(347, 188);
            this.m_panDossier.LockEdition = false;
            this.m_extModuleAssociator.SetModules(this.m_panDossier, "");
            this.m_panDossier.Name = "m_panDossier";
            this.m_panDossier.Size = new System.Drawing.Size(228, 232);
            this.m_extStyle.SetStyleBackColor(this.m_panDossier, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panDossier, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panDossier.TabIndex = 12;
            // 
            // m_panDossier_2
            // 
            this.m_panDossier_2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panDossier_2.Controls.Add(this.m_lblDossiers);
            this.m_panDossier_2.Controls.Add(this.m_lnkTypeOccupationH);
            this.m_panDossier_2.Controls.Add(this.m_lnkHoraireJournalier);
            this.m_panDossier_2.Controls.Add(this.m_lnkCalendars);
            this.m_panDossier_2.Controls.Add(this.m_lnkTypeTableauPlanning);
            this.m_panDossier_2.Controls.Add(this.m_lnkTableauPlanning);
            this.m_panDossier_2.Controls.Add(this.linkLabel1);
            this.m_panDossier_2.Controls.Add(this.linkLabel2);
            this.m_panDossier_2.Location = new System.Drawing.Point(0, 0);
            this.m_extModuleAssociator.SetModules(this.m_panDossier_2, "");
            this.m_panDossier_2.Name = "m_panDossier_2";
            this.m_panDossier_2.Size = new System.Drawing.Size(212, 212);
            this.m_extStyle.SetStyleBackColor(this.m_panDossier_2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panDossier_2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panDossier_2.TabIndex = 11;
            // 
            // m_lblDossiers
            // 
            this.m_lblDossiers.BackColor = System.Drawing.Color.SteelBlue;
            this.m_lblDossiers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblDossiers.ForeColor = System.Drawing.Color.Beige;
            this.m_lblDossiers.Location = new System.Drawing.Point(4, 4);
            this.m_extModuleAssociator.SetModules(this.m_lblDossiers, "");
            this.m_lblDossiers.Name = "m_lblDossiers";
            this.m_lblDossiers.Size = new System.Drawing.Size(205, 23);
            this.m_extStyle.SetStyleBackColor(this.m_lblDossiers, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblDossiers, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblDossiers.TabIndex = 4;
            this.m_lblDossiers.Text = "Planning features|722";
            this.m_lblDossiers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lnkTypeOccupationH
            // 
            this.m_lnkTypeOccupationH.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkTypeOccupationH.ForeColor = System.Drawing.Color.Black;
            this.m_lnkTypeOccupationH.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkTypeOccupationH.LinkColor = System.Drawing.Color.Black;
            this.m_lnkTypeOccupationH.Location = new System.Drawing.Point(12, 81);
            this.m_extModuleAssociator.SetModules(this.m_lnkTypeOccupationH, "");
            this.m_lnkTypeOccupationH.Name = "m_lnkTypeOccupationH";
            this.m_lnkTypeOccupationH.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTypeOccupationH, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTypeOccupationH, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTypeOccupationH.TabIndex = 11;
            this.m_lnkTypeOccupationH.TabStop = true;
            this.m_lnkTypeOccupationH.Text = "Occupation Types|725";
            this.m_lnkTypeOccupationH.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTypeOccupationH_LinkClicked);
            // 
            // m_lnkHoraireJournalier
            // 
            this.m_lnkHoraireJournalier.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkHoraireJournalier.ForeColor = System.Drawing.Color.Black;
            this.m_lnkHoraireJournalier.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkHoraireJournalier.LinkColor = System.Drawing.Color.Black;
            this.m_lnkHoraireJournalier.Location = new System.Drawing.Point(12, 97);
            this.m_extModuleAssociator.SetModules(this.m_lnkHoraireJournalier, "");
            this.m_lnkHoraireJournalier.Name = "m_lnkHoraireJournalier";
            this.m_lnkHoraireJournalier.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkHoraireJournalier, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkHoraireJournalier, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkHoraireJournalier.TabIndex = 11;
            this.m_lnkHoraireJournalier.TabStop = true;
            this.m_lnkHoraireJournalier.Text = "Daily schedules|399";
            this.m_lnkHoraireJournalier.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkHoraireJournalier_LinkClicked);
            // 
            // m_lnkCalendars
            // 
            this.m_lnkCalendars.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkCalendars.ForeColor = System.Drawing.Color.Black;
            this.m_lnkCalendars.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkCalendars.LinkColor = System.Drawing.Color.Black;
            this.m_lnkCalendars.Location = new System.Drawing.Point(12, 113);
            this.m_extModuleAssociator.SetModules(this.m_lnkCalendars, "");
            this.m_lnkCalendars.Name = "m_lnkCalendars";
            this.m_lnkCalendars.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkCalendars, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkCalendars, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkCalendars.TabIndex = 11;
            this.m_lnkCalendars.TabStop = true;
            this.m_lnkCalendars.Text = "Calendars|188";
            this.m_lnkCalendars.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkCalendars_LinkClicked);
            // 
            // m_lnkTypeTableauPlanning
            // 
            this.m_lnkTypeTableauPlanning.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkTypeTableauPlanning.ForeColor = System.Drawing.Color.Black;
            this.m_lnkTypeTableauPlanning.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkTypeTableauPlanning.LinkColor = System.Drawing.Color.Black;
            this.m_lnkTypeTableauPlanning.Location = new System.Drawing.Point(12, 158);
            this.m_extModuleAssociator.SetModules(this.m_lnkTypeTableauPlanning, "");
            this.m_lnkTypeTableauPlanning.Name = "m_lnkTypeTableauPlanning";
            this.m_lnkTypeTableauPlanning.Size = new System.Drawing.Size(166, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTypeTableauPlanning, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTypeTableauPlanning, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTypeTableauPlanning.TabIndex = 7;
            this.m_lnkTypeTableauPlanning.TabStop = true;
            this.m_lnkTypeTableauPlanning.Text = "Schedule Tables Types|1201";
            this.m_lnkTypeTableauPlanning.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTypeTableauPlanning_LinkClicked);
            // 
            // m_lnkTableauPlanning
            // 
            this.m_lnkTableauPlanning.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkTableauPlanning.ForeColor = System.Drawing.Color.Black;
            this.m_lnkTableauPlanning.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkTableauPlanning.LinkColor = System.Drawing.Color.Black;
            this.m_lnkTableauPlanning.Location = new System.Drawing.Point(12, 174);
            this.m_extModuleAssociator.SetModules(this.m_lnkTableauPlanning, "");
            this.m_lnkTableauPlanning.Name = "m_lnkTableauPlanning";
            this.m_lnkTableauPlanning.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTableauPlanning, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTableauPlanning, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTableauPlanning.TabIndex = 7;
            this.m_lnkTableauPlanning.TabStop = true;
            this.m_lnkTableauPlanning.Text = "Schedule Tables|1169";
            this.m_lnkTableauPlanning.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTableauPlanning_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.linkLabel1.ForeColor = System.Drawing.Color.Black;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(12, 40);
            this.m_extModuleAssociator.SetModules(this.linkLabel1, "");
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.linkLabel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.linkLabel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Diary entry Types|723";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.linkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel2.LinkColor = System.Drawing.Color.Black;
            this.linkLabel2.Location = new System.Drawing.Point(12, 56);
            this.m_extModuleAssociator.SetModules(this.linkLabel2, "");
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.linkLabel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.linkLabel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.linkLabel2.TabIndex = 0;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Diary entry Roles|724";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // m_panInterTicket
            // 
            this.m_panInterTicket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panInterTicket.Controls.Add(this.m_panInterTicket_2);
            this.m_panInterTicket.Location = new System.Drawing.Point(12, 12);
            this.m_panInterTicket.LockEdition = false;
            this.m_extModuleAssociator.SetModules(this.m_panInterTicket, "AINTER_CORR;AINTER_PREV;AINGE_PROJET");
            this.m_panInterTicket.Name = "m_panInterTicket";
            this.m_panInterTicket.Size = new System.Drawing.Size(281, 223);
            this.m_extStyle.SetStyleBackColor(this.m_panInterTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panInterTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panInterTicket.TabIndex = 13;
            // 
            // m_panInterTicket_2
            // 
            this.m_panInterTicket_2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panInterTicket_2.Controls.Add(this.m_lnkTypesPreventives);
            this.m_panInterTicket_2.Controls.Add(this.m_lblInterTicket);
            this.m_panInterTicket_2.Controls.Add(this.m_lnkListeInterventions);
            this.m_panInterTicket_2.Controls.Add(this.m_lnkProfilElement);
            this.m_panInterTicket_2.Controls.Add(this.m_lnkListesOperations);
            this.m_panInterTicket_2.Controls.Add(this.m_lnkTypesOperation);
            this.m_panInterTicket_2.Controls.Add(this.m_lnkTypesInterventions);
            this.m_panInterTicket_2.Controls.Add(this.linkLabel3);
            this.m_panInterTicket_2.Location = new System.Drawing.Point(0, 0);
            this.m_extModuleAssociator.SetModules(this.m_panInterTicket_2, "");
            this.m_panInterTicket_2.Name = "m_panInterTicket_2";
            this.m_panInterTicket_2.Size = new System.Drawing.Size(262, 207);
            this.m_extStyle.SetStyleBackColor(this.m_panInterTicket_2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panInterTicket_2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panInterTicket_2.TabIndex = 12;
            // 
            // m_lnkTypesPreventives
            // 
            this.m_lnkTypesPreventives.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_lnkTypesPreventives.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkTypesPreventives.ForeColor = System.Drawing.Color.Black;
            this.m_lnkTypesPreventives.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkTypesPreventives.LinkColor = System.Drawing.Color.Black;
            this.m_lnkTypesPreventives.Location = new System.Drawing.Point(14, 175);
            this.m_extModuleAssociator.SetModules(this.m_lnkTypesPreventives, "");
            this.m_lnkTypesPreventives.Name = "m_lnkTypesPreventives";
            this.m_lnkTypesPreventives.Size = new System.Drawing.Size(188, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTypesPreventives, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTypesPreventives, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTypesPreventives.TabIndex = 12;
            this.m_lnkTypesPreventives.TabStop = true;
            this.m_lnkTypesPreventives.Text = "Planning|1396";
            this.m_lnkTypesPreventives.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTypesPreventives_LinkClicked);
            // 
            // m_lblInterTicket
            // 
            this.m_lblInterTicket.BackColor = System.Drawing.Color.SteelBlue;
            this.m_lblInterTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblInterTicket.ForeColor = System.Drawing.Color.Beige;
            this.m_lblInterTicket.Location = new System.Drawing.Point(4, 4);
            this.m_extModuleAssociator.SetModules(this.m_lblInterTicket, "");
            this.m_lblInterTicket.Name = "m_lblInterTicket";
            this.m_lblInterTicket.Size = new System.Drawing.Size(252, 23);
            this.m_extStyle.SetStyleBackColor(this.m_lblInterTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblInterTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblInterTicket.TabIndex = 4;
            this.m_lblInterTicket.Text = "Interventions and Operations|728";
            this.m_lblInterTicket.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lnkListeInterventions
            // 
            this.m_lnkListeInterventions.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkListeInterventions.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkListeInterventions.LinkColor = System.Drawing.Color.Black;
            this.m_lnkListeInterventions.Location = new System.Drawing.Point(14, 57);
            this.m_extModuleAssociator.SetModules(this.m_lnkListeInterventions, "");
            this.m_lnkListeInterventions.Name = "m_lnkListeInterventions";
            this.m_lnkListeInterventions.Size = new System.Drawing.Size(188, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkListeInterventions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkListeInterventions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkListeInterventions.TabIndex = 10;
            this.m_lnkListeInterventions.TabStop = true;
            this.m_lnkListeInterventions.Text = "Interventions list|731";
            this.m_lnkListeInterventions.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkListeInterventions_LinkClicked);
            // 
            // m_lnkProfilElement
            // 
            this.m_lnkProfilElement.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkProfilElement.ForeColor = System.Drawing.Color.Black;
            this.m_lnkProfilElement.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkProfilElement.LinkColor = System.Drawing.Color.Black;
            this.m_lnkProfilElement.Location = new System.Drawing.Point(14, 159);
            this.m_extModuleAssociator.SetModules(this.m_lnkProfilElement, "");
            this.m_lnkProfilElement.Name = "m_lnkProfilElement";
            this.m_lnkProfilElement.Size = new System.Drawing.Size(188, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkProfilElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkProfilElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkProfilElement.TabIndex = 11;
            this.m_lnkProfilElement.TabStop = true;
            this.m_lnkProfilElement.Text = "Profiles|729";
            this.m_lnkProfilElement.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkProfilElement_LinkClicked);
            // 
            // m_lnkListesOperations
            // 
            this.m_lnkListesOperations.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkListesOperations.ForeColor = System.Drawing.Color.Black;
            this.m_lnkListesOperations.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkListesOperations.LinkColor = System.Drawing.Color.Black;
            this.m_lnkListesOperations.Location = new System.Drawing.Point(14, 102);
            this.m_extModuleAssociator.SetModules(this.m_lnkListesOperations, "");
            this.m_lnkListesOperations.Name = "m_lnkListesOperations";
            this.m_lnkListesOperations.Size = new System.Drawing.Size(188, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkListesOperations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkListesOperations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkListesOperations.TabIndex = 7;
            this.m_lnkListesOperations.TabStop = true;
            this.m_lnkListesOperations.Text = "Operations Lists|1127";
            this.m_lnkListesOperations.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkListesOperations_LinkClicked);
            // 
            // m_lnkTypesOperation
            // 
            this.m_lnkTypesOperation.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkTypesOperation.ForeColor = System.Drawing.Color.Black;
            this.m_lnkTypesOperation.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkTypesOperation.LinkColor = System.Drawing.Color.Black;
            this.m_lnkTypesOperation.Location = new System.Drawing.Point(14, 85);
            this.m_extModuleAssociator.SetModules(this.m_lnkTypesOperation, "");
            this.m_lnkTypesOperation.Name = "m_lnkTypesOperation";
            this.m_lnkTypesOperation.Size = new System.Drawing.Size(188, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTypesOperation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTypesOperation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTypesOperation.TabIndex = 7;
            this.m_lnkTypesOperation.TabStop = true;
            this.m_lnkTypesOperation.Text = "Operation types|322";
            this.m_lnkTypesOperation.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTypesOperation_LinkClicked);
            // 
            // m_lnkTypesInterventions
            // 
            this.m_lnkTypesInterventions.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkTypesInterventions.ForeColor = System.Drawing.Color.Black;
            this.m_lnkTypesInterventions.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkTypesInterventions.LinkColor = System.Drawing.Color.Black;
            this.m_lnkTypesInterventions.Location = new System.Drawing.Point(15, 39);
            this.m_extModuleAssociator.SetModules(this.m_lnkTypesInterventions, "");
            this.m_lnkTypesInterventions.Name = "m_lnkTypesInterventions";
            this.m_lnkTypesInterventions.Size = new System.Drawing.Size(188, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTypesInterventions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTypesInterventions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTypesInterventions.TabIndex = 6;
            this.m_lnkTypesInterventions.TabStop = true;
            this.m_lnkTypesInterventions.Text = "Intervention types|332";
            this.m_lnkTypesInterventions.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTypesInterventions_LinkClicked);
            // 
            // linkLabel3
            // 
            this.linkLabel3.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.linkLabel3.ForeColor = System.Drawing.Color.Black;
            this.linkLabel3.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel3.LinkColor = System.Drawing.Color.Black;
            this.linkLabel3.Location = new System.Drawing.Point(14, 120);
            this.m_extModuleAssociator.SetModules(this.linkLabel3, "");
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(188, 16);
            this.m_extStyle.SetStyleBackColor(this.linkLabel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.linkLabel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.linkLabel3.TabIndex = 8;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Freezing Causes|733";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel8_LinkClicked);
            // 
            // linkLabel12
            // 
            this.linkLabel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.linkLabel12.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.linkLabel12.ForeColor = System.Drawing.Color.Black;
            this.linkLabel12.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel12.LinkColor = System.Drawing.Color.Black;
            this.linkLabel12.Location = new System.Drawing.Point(12, 39);
            this.m_extModuleAssociator.SetModules(this.linkLabel12, "");
            this.linkLabel12.Name = "linkLabel12";
            this.linkLabel12.Size = new System.Drawing.Size(134, 16);
            this.m_extStyle.SetStyleBackColor(this.linkLabel12, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.linkLabel12, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.linkLabel12.TabIndex = 12;
            this.linkLabel12.TabStop = true;
            this.linkLabel12.Text = "Contracts Types|1129";
            this.linkLabel12.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel12_LinkClicked);
            // 
            // linkLabel11
            // 
            this.linkLabel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.linkLabel11.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.linkLabel11.ForeColor = System.Drawing.Color.Black;
            this.linkLabel11.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel11.LinkColor = System.Drawing.Color.Black;
            this.linkLabel11.Location = new System.Drawing.Point(12, 57);
            this.m_extModuleAssociator.SetModules(this.linkLabel11, "");
            this.linkLabel11.Name = "linkLabel11";
            this.linkLabel11.Size = new System.Drawing.Size(134, 16);
            this.m_extStyle.SetStyleBackColor(this.linkLabel11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.linkLabel11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.linkLabel11.TabIndex = 12;
            this.linkLabel11.TabStop = true;
            this.linkLabel11.Text = "Contracts|640";
            this.linkLabel11.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel11_LinkClicked);
            // 
            // linkLabel7
            // 
            this.linkLabel7.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.linkLabel7.ForeColor = System.Drawing.Color.Black;
            this.linkLabel7.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel7.LinkColor = System.Drawing.Color.Black;
            this.linkLabel7.Location = new System.Drawing.Point(12, 135);
            this.m_extModuleAssociator.SetModules(this.linkLabel7, "");
            this.linkLabel7.Name = "linkLabel7";
            this.linkLabel7.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.linkLabel7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.linkLabel7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.linkLabel7.TabIndex = 8;
            this.linkLabel7.TabStop = true;
            this.linkLabel7.Text = "Ticket closing states|734";
            this.linkLabel7.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel7_LinkClicked);
            // 
            // linkLabel9
            // 
            this.linkLabel9.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.linkLabel9.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel9.LinkColor = System.Drawing.Color.Black;
            this.linkLabel9.Location = new System.Drawing.Point(12, 55);
            this.m_extModuleAssociator.SetModules(this.linkLabel9, "");
            this.linkLabel9.Name = "linkLabel9";
            this.linkLabel9.Size = new System.Drawing.Size(186, 16);
            this.m_extStyle.SetStyleBackColor(this.linkLabel9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.linkLabel9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.linkLabel9.TabIndex = 10;
            this.linkLabel9.TabStop = true;
            this.linkLabel9.Text = "Ticket list|730";
            this.linkLabel9.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel9_LinkClicked);
            // 
            // m_lnkQualificationsAppel
            // 
            this.m_lnkQualificationsAppel.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkQualificationsAppel.ForeColor = System.Drawing.Color.Black;
            this.m_lnkQualificationsAppel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkQualificationsAppel.LinkColor = System.Drawing.Color.Black;
            this.m_lnkQualificationsAppel.Location = new System.Drawing.Point(12, 116);
            this.m_extModuleAssociator.SetModules(this.m_lnkQualificationsAppel, "");
            this.m_lnkQualificationsAppel.Name = "m_lnkQualificationsAppel";
            this.m_lnkQualificationsAppel.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkQualificationsAppel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkQualificationsAppel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkQualificationsAppel.TabIndex = 8;
            this.m_lnkQualificationsAppel.TabStop = true;
            this.m_lnkQualificationsAppel.Text = "Ticket Qualifications|480";
            this.m_lnkQualificationsAppel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkQualificationsAppel_LinkClicked);
            // 
            // linkLabel4
            // 
            this.linkLabel4.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.linkLabel4.ForeColor = System.Drawing.Color.Black;
            this.linkLabel4.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel4.LinkColor = System.Drawing.Color.Black;
            this.linkLabel4.Location = new System.Drawing.Point(12, 39);
            this.m_extModuleAssociator.SetModules(this.linkLabel4, "");
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.linkLabel4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.linkLabel4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.linkLabel4.TabIndex = 8;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "Ticket Types|483";
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // linkLabel8
            // 
            this.linkLabel8.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.linkLabel8.ForeColor = System.Drawing.Color.Black;
            this.linkLabel8.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel8.LinkColor = System.Drawing.Color.Black;
            this.linkLabel8.Location = new System.Drawing.Point(12, 187);
            this.m_extModuleAssociator.SetModules(this.linkLabel8, "");
            this.linkLabel8.Name = "linkLabel8";
            this.linkLabel8.Size = new System.Drawing.Size(198, 16);
            this.m_extStyle.SetStyleBackColor(this.linkLabel8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.linkLabel8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.linkLabel8.TabIndex = 8;
            this.linkLabel8.TabStop = true;
            this.linkLabel8.Text = "Freezing Causes|733";
            this.linkLabel8.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel8_LinkClicked);
            // 
            // m_lnkTypePhaseTicket
            // 
            this.m_lnkTypePhaseTicket.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkTypePhaseTicket.ForeColor = System.Drawing.Color.Black;
            this.m_lnkTypePhaseTicket.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkTypePhaseTicket.LinkColor = System.Drawing.Color.Black;
            this.m_lnkTypePhaseTicket.Location = new System.Drawing.Point(12, 171);
            this.m_extModuleAssociator.SetModules(this.m_lnkTypePhaseTicket, "");
            this.m_lnkTypePhaseTicket.Name = "m_lnkTypePhaseTicket";
            this.m_lnkTypePhaseTicket.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTypePhaseTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTypePhaseTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTypePhaseTicket.TabIndex = 8;
            this.m_lnkTypePhaseTicket.TabStop = true;
            this.m_lnkTypePhaseTicket.Text = "Phases Type|732";
            this.m_lnkTypePhaseTicket.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTypePhaseTicket_LinkClicked);
            // 
            // linkLabel6
            // 
            this.linkLabel6.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.linkLabel6.ForeColor = System.Drawing.Color.Black;
            this.linkLabel6.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel6.LinkColor = System.Drawing.Color.Black;
            this.linkLabel6.Location = new System.Drawing.Point(12, 100);
            this.m_extModuleAssociator.SetModules(this.linkLabel6, "");
            this.linkLabel6.Name = "linkLabel6";
            this.linkLabel6.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.linkLabel6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.linkLabel6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.linkLabel6.TabIndex = 8;
            this.linkLabel6.TabStop = true;
            this.linkLabel6.Text = "Ticket Urgency|504";
            this.linkLabel6.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel6_LinkClicked);
            // 
            // linkLabel5
            // 
            this.linkLabel5.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.linkLabel5.ForeColor = System.Drawing.Color.Black;
            this.linkLabel5.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel5.LinkColor = System.Drawing.Color.Black;
            this.linkLabel5.Location = new System.Drawing.Point(12, 84);
            this.m_extModuleAssociator.SetModules(this.linkLabel5, "");
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.linkLabel5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.linkLabel5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.linkLabel5.TabIndex = 8;
            this.linkLabel5.TabStop = true;
            this.linkLabel5.Text = "Ticket Origins|500";
            this.linkLabel5.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel5_LinkClicked);
            // 
            // c2iPanelOmbre1
            // 
            this.c2iPanelOmbre1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre1.Controls.Add(this.panel1);
            this.c2iPanelOmbre1.Location = new System.Drawing.Point(12, 257);
            this.c2iPanelOmbre1.LockEdition = false;
            this.m_extModuleAssociator.SetModules(this.c2iPanelOmbre1, "AINTER_CORR");
            this.c2iPanelOmbre1.Name = "c2iPanelOmbre1";
            this.c2iPanelOmbre1.Size = new System.Drawing.Size(281, 255);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iPanelOmbre1.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.linkLabel9);
            this.panel1.Controls.Add(this.linkLabel4);
            this.panel1.Controls.Add(this.linkLabel5);
            this.panel1.Controls.Add(this.linkLabel7);
            this.panel1.Controls.Add(this.linkLabel6);
            this.panel1.Controls.Add(this.m_lnkQualificationsAppel);
            this.panel1.Controls.Add(this.m_lnkTypePhaseTicket);
            this.panel1.Controls.Add(this.linkLabel8);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.m_extModuleAssociator.SetModules(this.panel1, "");
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(259, 230);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Beige;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.m_extModuleAssociator.SetModules(this.label1, "");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 23);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tickets and Phases|1423";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c2iPanelOmbre2
            // 
            this.c2iPanelOmbre2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre2.Controls.Add(this.panel2);
            this.c2iPanelOmbre2.Location = new System.Drawing.Point(347, 12);
            this.c2iPanelOmbre2.LockEdition = false;
            this.m_extModuleAssociator.SetModules(this.c2iPanelOmbre2, "AINTER_PREV;AINTER_CORR;AINGE_PROJET");
            this.c2iPanelOmbre2.Name = "c2iPanelOmbre2";
            this.c2iPanelOmbre2.Size = new System.Drawing.Size(228, 164);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iPanelOmbre2.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.linkLabel12);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.linkLabel11);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.m_extModuleAssociator.SetModules(this.panel2, "");
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(212, 145);
            this.m_extStyle.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel2.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Beige;
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.m_extModuleAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 23);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4;
            this.label2.Text = "Contracts|640";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CFormMenuMaintenance
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(758, 546);
            this.Controls.Add(this.c2iPanelOmbre1);
            this.Controls.Add(this.m_panInterTicket);
            this.Controls.Add(this.c2iPanelOmbre2);
            this.Controls.Add(this.m_panDossier);
            this.m_extModuleAssociator.SetModules(this, "");
            this.Name = "CFormMenuMaintenance";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondFenetre);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "CFormMenuMaintenance";
            this.Load += new System.EventHandler(this.CFormMenuMaintenance_Load);
            this.Activated += new System.EventHandler(this.CFormMenuMaintenance_Activated);
            this.Enter += new System.EventHandler(this.CFormMenuMaintenance_Enter);
            this.c2iPanelOmbre3.ResumeLayout(false);
            this.c2iPanelOmbre3.PerformLayout();
            this.m_panDossier.ResumeLayout(false);
            this.m_panDossier.PerformLayout();
            this.m_panDossier_2.ResumeLayout(false);
            this.m_panInterTicket.ResumeLayout(false);
            this.m_panInterTicket.PerformLayout();
            this.m_panInterTicket_2.ResumeLayout(false);
            this.c2iPanelOmbre1.ResumeLayout(false);
            this.c2iPanelOmbre1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.c2iPanelOmbre2.ResumeLayout(false);
            this.c2iPanelOmbre2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void CFormMenuMaintenance_Load(object sender, System.EventArgs e)
		{
            m_extModuleAssociator.AppliquerConfiguration(CTimosApp.ConfigurationModules);
        }


		#region Membres de IFormNavigable
        public event ContexteFormEventHandler AfterGetContexte;
        public event ContexteFormEventHandler AfterInitFromContexte;

		public CContexteFormNavigable GetContexte()
		{
            CContexteFormNavigable contexte = new CContexteFormNavigable ( GetType() );
            if (AfterGetContexte != null)
                AfterGetContexte(this, contexte);
            return contexte;
		}

	
		public bool QueryClose()
		{
			return true;
		}

		public sc2i.common.CResultAErreur InitFromContexte(CContexteFormNavigable contexte)
		{
            if (AfterInitFromContexte != null)
                AfterInitFromContexte(this, contexte);
			return CResultAErreur.True;
		}
        //------------------------------------------------------------------
        public CResultAErreur Actualiser()
        {
            return InitFromContexte(GetContexte());
        }

		#endregion

		#region Membres de IDisposable

		void System.IDisposable.Dispose()
		{
			// TODO : ajoutez l'implémentation de CFormMenuMaintenance.System.IDisposable.Dispose
		}

		#endregion



		private void CFormMenuMaintenance_Enter(object sender, System.EventArgs e)
		{
			CTimosApp.Titre = I.T( "Maintenance|8");
		}

		

		private void CFormMenuMaintenance_Activated(object sender, System.EventArgs e)
		{
		}




		private void m_lnkChamps_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeChampsCustom());
		}

		private void m_lnkChampsCalcules_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeChampsCalcules());
		}

		private void m_lnkVariables_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeVariableSurObjets());
		}

		private void m_lnkStructuresExport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeStructuresDonnees());
		}

		private void m_lnkFormulaires_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeFormulaires());
		}

		private void m_lnkFiltres_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeFiltresDynamiques());
		}

		private void m_lnkListes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeListesEntites());
		}

		private void m_lnkTypeEntiteOrganisationnelle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage ( new CFormListeTypeEntiteOrganisationnelle() ) ;
		}

		private void m_lnkEntiteOrganisationnelle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeEntiteOrganisationnelle());
		}

		private void m_lnkGroupeRestriction_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeGroupesRestrictions());
		}

		private void m_lnkProfilsUtilisateurs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeProfilUtilisateurs());
		}

		private void m_lnkTypeDossier_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeTypesDossierSuivi());
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeTypesEntreesAgenda());
		}

		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeRolesSurEntreeAgenda());
		}

		private void m_lnkCategorieGED_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeCategoriesGED());
		}

		private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeGrilleGeneriques());
		}

		private void m_lnkTypeDonneeCumulee_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeTypesDonneesCumulees());
		}

		private void m_lnkProcess_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeProcess());
		}

		private void m_lnkEvenements_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeEvenements());
		}

		private void m_lnkComportements_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeComportementsGeneriques());
		}

		private void m_lnkInterventionsPlanifiees_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeTachesPlanifiees());
		}

		private void m_lnkGroupesParametrage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeGroupesParametrage());
		}

		private void m_lnkCalendars_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeCalendriers());
		}

		private void m_lnkStatutsEquipement_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeStatutEquipement());
		}
        
		private void m_lnkTypesInterventions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeTypeIntervention());
		}

		private void m_lnkTypesOperation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeTypeOperation());
		}

		private void m_lnkProfilsIntervenants_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
		}


        private void m_lnkHoraireJournalier_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeHoraireJournalier());
        }

        private void m_lnkTypeOccupationH_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage ( new CFormListeTypeOccupationHoraire () ) ;
        }

		private void m_lnkCategoriesRapports_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage ( new CFormListeCategoriesRapportCrystal () );
		}

		private void m_lnkModeleDeRapport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage ( new CFormListeRapportsCrystal () );
		}

		private void m_lnkQualificationsAppel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage ( new CFormListeQualificationTicket () );
		}

		private void m_lnkProfilDeRessource_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
		}

		private void m_lnkModelesDeTexte_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeModeleTexte());
		}

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeTypeTickets());
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeOriginesTickets());
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeUrgencesTickets());
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeEtatCloture());
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeCauseGel());
        }

		private void m_lnkTypePhaseTicket_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeTypePhaseTicket());
		}

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeTicket());
        }

        private void m_lnkActeurs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeActeurs());
        }

        private void m_lnkGroupesActeurs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeGroupesActeurs());
        }

        private void m_lnkContrats_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeContrat());
        }

		private void m_lnkProfilElement_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeProfilElement());
		}

        private void m_lnkListeInterventions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeInterventions());
        }

        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeDossierSuivi());
        }

		private void m_lnkCivilites_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeCivilites());
		}

        private void m_lnkListesOperations_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeListeOperations());
        }

        private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeTypeContrat());
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeContrat());
        }

		private void m_lnkTypeTable_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeTypeTableParametrable());
		}

		private void m_lnkTableParametrable_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeTableParametrable());
		}

        private void m_lnkTableauPlanning_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeInstanceTableauPlanning());
        }

        private void m_lnkTypeTableauPlanning_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeTypeTableauPlannings());
        }

		private void m_lnkTypeProjet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeTypeProjet());
		}

		private void m_lnkProjet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeProjet());
		}

		private void m_lnkTypesPreventives_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormEditionPreventive());
		}

		private void m_lnkVersionsPrevisionnelles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeVersionDonneess());
		}

		private void m_lnkTypeAuditVersion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeTypeAuditVersion());
		}

		private void m_lnkAuditVersion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeAuditVersion());
		}

        public string GetTitle()
        {
            return I.T("Maintenance|8");
        }

        public Image GetImage()
        {
            return Resources.maintenance;
        }


	}
}

