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
using timos.securite;
using sc2i.workflow;
using timos.Properties;

namespace timos
{
	/// <summary>
	/// Description résumée de CFormMenuOrganisation.
	/// </summary>
	[DynamicForm("Organisation")]
	public class CFormMenuOrganisation : CFormMaxiSansMenu, IFormNavigable
	{
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre3;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox m_chkSuiviDates;
		private sc2i.win32.common.C2iPanelOmbre m_panSecurite;
		private LinkLabel m_lnkTypeEntiteOrganisationnelle;
		private LinkLabel m_lnkEntiteOrganisationnelle;
		private LinkLabel m_lnkGroupeRestriction;
		private Label m_lblSecurite;
        private LinkLabel m_lnkProfilsUtilisateurs;
        private Panel m_panSecurite_2;
        private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre5;
        private Label label5;
        private LinkLabel linkLabel2;
        private LinkLabel m_lnkGroupesActeurs;
        private LinkLabel m_lnkTypeActiviteActeur;
        private LinkLabel m_lnkSuiviActiviteActeurs;
        private LinkLabel m_lnkCivilites;
        private LinkLabel m_lnkActiviteActeurResume;
        private CExtModulesAssociator m_extModuleAssociator;
        private LinkLabel m_lnkSessionManager;
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CFormMenuOrganisation()
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
            this.m_panSecurite = new sc2i.win32.common.C2iPanelOmbre();
            this.m_panSecurite_2 = new System.Windows.Forms.Panel();
            this.m_lblSecurite = new System.Windows.Forms.Label();
            this.m_lnkGroupeRestriction = new System.Windows.Forms.LinkLabel();
            this.m_lnkEntiteOrganisationnelle = new System.Windows.Forms.LinkLabel();
            this.m_lnkTypeEntiteOrganisationnelle = new System.Windows.Forms.LinkLabel();
            this.m_lnkProfilsUtilisateurs = new System.Windows.Forms.LinkLabel();
            this.c2iPanelOmbre5 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_lnkSessionManager = new System.Windows.Forms.LinkLabel();
            this.m_lnkCivilites = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.m_lnkGroupesActeurs = new System.Windows.Forms.LinkLabel();
            this.m_lnkTypeActiviteActeur = new System.Windows.Forms.LinkLabel();
            this.m_lnkSuiviActiviteActeurs = new System.Windows.Forms.LinkLabel();
            this.m_lnkActiviteActeurResume = new System.Windows.Forms.LinkLabel();
            this.m_extModuleAssociator = new timos.CExtModulesAssociator();
            this.c2iPanelOmbre3.SuspendLayout();
            this.m_panSecurite.SuspendLayout();
            this.m_panSecurite_2.SuspendLayout();
            this.c2iPanelOmbre5.SuspendLayout();
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
            // m_panSecurite
            // 
            this.m_panSecurite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panSecurite.Controls.Add(this.m_panSecurite_2);
            this.m_panSecurite.ForeColor = System.Drawing.Color.Black;
            this.m_panSecurite.Location = new System.Drawing.Point(18, 12);
            this.m_panSecurite.LockEdition = false;
            this.m_extModuleAssociator.SetModules(this.m_panSecurite, "");
            this.m_panSecurite.Name = "m_panSecurite";
            this.m_panSecurite.Size = new System.Drawing.Size(261, 157);
            this.m_extStyle.SetStyleBackColor(this.m_panSecurite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panSecurite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panSecurite.TabIndex = 12;
            // 
            // m_panSecurite_2
            // 
            this.m_panSecurite_2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panSecurite_2.Controls.Add(this.m_lblSecurite);
            this.m_panSecurite_2.Controls.Add(this.m_lnkGroupeRestriction);
            this.m_panSecurite_2.Controls.Add(this.m_lnkEntiteOrganisationnelle);
            this.m_panSecurite_2.Controls.Add(this.m_lnkTypeEntiteOrganisationnelle);
            this.m_panSecurite_2.Controls.Add(this.m_lnkProfilsUtilisateurs);
            this.m_panSecurite_2.Location = new System.Drawing.Point(0, 0);
            this.m_extModuleAssociator.SetModules(this.m_panSecurite_2, "");
            this.m_panSecurite_2.Name = "m_panSecurite_2";
            this.m_panSecurite_2.Size = new System.Drawing.Size(245, 141);
            this.m_extStyle.SetStyleBackColor(this.m_panSecurite_2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panSecurite_2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panSecurite_2.TabIndex = 11;
            // 
            // m_lblSecurite
            // 
            this.m_lblSecurite.BackColor = System.Drawing.Color.SteelBlue;
            this.m_lblSecurite.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblSecurite.ForeColor = System.Drawing.Color.Beige;
            this.m_lblSecurite.Location = new System.Drawing.Point(4, 4);
            this.m_extModuleAssociator.SetModules(this.m_lblSecurite, "");
            this.m_lblSecurite.Name = "m_lblSecurite";
            this.m_lblSecurite.Size = new System.Drawing.Size(237, 23);
            this.m_extStyle.SetStyleBackColor(this.m_lblSecurite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblSecurite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblSecurite.TabIndex = 4;
            this.m_lblSecurite.Text = "Security|130";
            this.m_lblSecurite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lnkGroupeRestriction
            // 
            this.m_lnkGroupeRestriction.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkGroupeRestriction.ForeColor = System.Drawing.Color.Black;
            this.m_lnkGroupeRestriction.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkGroupeRestriction.LinkColor = System.Drawing.Color.Black;
            this.m_lnkGroupeRestriction.Location = new System.Drawing.Point(8, 77);
            this.m_extModuleAssociator.SetModules(this.m_lnkGroupeRestriction, "");
            this.m_lnkGroupeRestriction.Name = "m_lnkGroupeRestriction";
            this.m_lnkGroupeRestriction.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkGroupeRestriction, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkGroupeRestriction, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkGroupeRestriction.TabIndex = 7;
            this.m_lnkGroupeRestriction.TabStop = true;
            this.m_lnkGroupeRestriction.Text = "Restrictions|133";
            this.m_lnkGroupeRestriction.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkGroupeRestriction_LinkClicked);
            // 
            // m_lnkEntiteOrganisationnelle
            // 
            this.m_lnkEntiteOrganisationnelle.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkEntiteOrganisationnelle.ForeColor = System.Drawing.Color.Black;
            this.m_lnkEntiteOrganisationnelle.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkEntiteOrganisationnelle.LinkColor = System.Drawing.Color.Black;
            this.m_lnkEntiteOrganisationnelle.Location = new System.Drawing.Point(8, 53);
            this.m_extModuleAssociator.SetModules(this.m_lnkEntiteOrganisationnelle, "");
            this.m_lnkEntiteOrganisationnelle.Name = "m_lnkEntiteOrganisationnelle";
            this.m_lnkEntiteOrganisationnelle.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkEntiteOrganisationnelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkEntiteOrganisationnelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkEntiteOrganisationnelle.TabIndex = 0;
            this.m_lnkEntiteOrganisationnelle.TabStop = true;
            this.m_lnkEntiteOrganisationnelle.Text = "Organizational Entities|132";
            this.m_lnkEntiteOrganisationnelle.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkEntiteOrganisationnelle_LinkClicked);
            // 
            // m_lnkTypeEntiteOrganisationnelle
            // 
            this.m_lnkTypeEntiteOrganisationnelle.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkTypeEntiteOrganisationnelle.ForeColor = System.Drawing.Color.Black;
            this.m_lnkTypeEntiteOrganisationnelle.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkTypeEntiteOrganisationnelle.LinkColor = System.Drawing.Color.Black;
            this.m_lnkTypeEntiteOrganisationnelle.Location = new System.Drawing.Point(8, 35);
            this.m_extModuleAssociator.SetModules(this.m_lnkTypeEntiteOrganisationnelle, "");
            this.m_lnkTypeEntiteOrganisationnelle.Name = "m_lnkTypeEntiteOrganisationnelle";
            this.m_lnkTypeEntiteOrganisationnelle.Size = new System.Drawing.Size(184, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTypeEntiteOrganisationnelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTypeEntiteOrganisationnelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTypeEntiteOrganisationnelle.TabIndex = 6;
            this.m_lnkTypeEntiteOrganisationnelle.TabStop = true;
            this.m_lnkTypeEntiteOrganisationnelle.Text = "Organizational Entity Type|131";
            this.m_lnkTypeEntiteOrganisationnelle.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTypeEntiteOrganisationnelle_LinkClicked);
            // 
            // m_lnkProfilsUtilisateurs
            // 
            this.m_lnkProfilsUtilisateurs.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkProfilsUtilisateurs.ForeColor = System.Drawing.Color.Black;
            this.m_lnkProfilsUtilisateurs.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkProfilsUtilisateurs.LinkColor = System.Drawing.Color.Black;
            this.m_lnkProfilsUtilisateurs.Location = new System.Drawing.Point(8, 96);
            this.m_extModuleAssociator.SetModules(this.m_lnkProfilsUtilisateurs, "");
            this.m_lnkProfilsUtilisateurs.Name = "m_lnkProfilsUtilisateurs";
            this.m_lnkProfilsUtilisateurs.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkProfilsUtilisateurs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkProfilsUtilisateurs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkProfilsUtilisateurs.TabIndex = 8;
            this.m_lnkProfilsUtilisateurs.TabStop = true;
            this.m_lnkProfilsUtilisateurs.Text = "User profiles|138";
            this.m_lnkProfilsUtilisateurs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkProfilsUtilisateurs_LinkClicked);
            // 
            // c2iPanelOmbre5
            // 
            this.c2iPanelOmbre5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre5.Controls.Add(this.m_lnkCivilites);
            this.c2iPanelOmbre5.Controls.Add(this.label5);
            this.c2iPanelOmbre5.Controls.Add(this.linkLabel2);
            this.c2iPanelOmbre5.Controls.Add(this.m_lnkSessionManager);
            this.c2iPanelOmbre5.Controls.Add(this.m_lnkGroupesActeurs);
            this.c2iPanelOmbre5.Controls.Add(this.m_lnkTypeActiviteActeur);
            this.c2iPanelOmbre5.Controls.Add(this.m_lnkSuiviActiviteActeurs);
            this.c2iPanelOmbre5.Controls.Add(this.m_lnkActiviteActeurResume);
            this.c2iPanelOmbre5.Location = new System.Drawing.Point(18, 188);
            this.c2iPanelOmbre5.LockEdition = false;
            this.m_extModuleAssociator.SetModules(this.c2iPanelOmbre5, "");
            this.c2iPanelOmbre5.Name = "c2iPanelOmbre5";
            this.c2iPanelOmbre5.Size = new System.Drawing.Size(261, 220);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre5, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iPanelOmbre5.TabIndex = 14;
            // 
            // m_lnkSessionManager
            // 
            this.m_lnkSessionManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_lnkSessionManager.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkSessionManager.ForeColor = System.Drawing.Color.Black;
            this.m_lnkSessionManager.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkSessionManager.LinkColor = System.Drawing.Color.Black;
            this.m_lnkSessionManager.Location = new System.Drawing.Point(8, 188);
            this.m_extModuleAssociator.SetModules(this.m_lnkSessionManager, "");
            this.m_lnkSessionManager.Name = "m_lnkSessionManager";
            this.m_lnkSessionManager.Size = new System.Drawing.Size(191, 14);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSessionManager, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSessionManager, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSessionManager.TabIndex = 16;
            this.m_lnkSessionManager.TabStop = true;
            this.m_lnkSessionManager.Text = "Session manager|20497";
            this.m_lnkSessionManager.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkSessionManager_LinkClicked);
            // 
            // m_lnkCivilites
            // 
            this.m_lnkCivilites.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkCivilites.ForeColor = System.Drawing.Color.Black;
            this.m_lnkCivilites.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkCivilites.LinkColor = System.Drawing.Color.Black;
            this.m_lnkCivilites.Location = new System.Drawing.Point(8, 40);
            this.m_extModuleAssociator.SetModules(this.m_lnkCivilites, "");
            this.m_lnkCivilites.Name = "m_lnkCivilites";
            this.m_lnkCivilites.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkCivilites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkCivilites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkCivilites.TabIndex = 15;
            this.m_lnkCivilites.TabStop = true;
            this.m_lnkCivilites.Text = "Civilities|720";
            this.m_lnkCivilites.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkCivilites_LinkClicked);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.SteelBlue;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Beige;
            this.label5.Location = new System.Drawing.Point(4, 4);
            this.m_extModuleAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(237, 23);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTitrePanel);
            this.label5.TabIndex = 4;
            this.label5.Text = "Members management|735";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // linkLabel2
            // 
            this.linkLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.linkLabel2.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.linkLabel2.ForeColor = System.Drawing.Color.Black;
            this.linkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel2.LinkColor = System.Drawing.Color.Black;
            this.linkLabel2.Location = new System.Drawing.Point(8, 57);
            this.m_extModuleAssociator.SetModules(this.linkLabel2, "");
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.linkLabel2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.linkLabel2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.linkLabel2.TabIndex = 7;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Members|736";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // m_lnkGroupesActeurs
            // 
            this.m_lnkGroupesActeurs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_lnkGroupesActeurs.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkGroupesActeurs.ForeColor = System.Drawing.Color.Black;
            this.m_lnkGroupesActeurs.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkGroupesActeurs.LinkColor = System.Drawing.Color.Black;
            this.m_lnkGroupesActeurs.Location = new System.Drawing.Point(8, 74);
            this.m_extModuleAssociator.SetModules(this.m_lnkGroupesActeurs, "");
            this.m_lnkGroupesActeurs.Name = "m_lnkGroupesActeurs";
            this.m_lnkGroupesActeurs.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkGroupesActeurs, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_lnkGroupesActeurs, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_lnkGroupesActeurs.TabIndex = 8;
            this.m_lnkGroupesActeurs.TabStop = true;
            this.m_lnkGroupesActeurs.Text = "Members Groups|737";
            this.m_lnkGroupesActeurs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkGroupesActeurs_LinkClicked);
            // 
            // m_lnkTypeActiviteActeur
            // 
            this.m_lnkTypeActiviteActeur.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_lnkTypeActiviteActeur.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkTypeActiviteActeur.ForeColor = System.Drawing.Color.Black;
            this.m_lnkTypeActiviteActeur.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkTypeActiviteActeur.LinkColor = System.Drawing.Color.Black;
            this.m_lnkTypeActiviteActeur.Location = new System.Drawing.Point(8, 108);
            this.m_extModuleAssociator.SetModules(this.m_lnkTypeActiviteActeur, "ASUIV_ACT");
            this.m_lnkTypeActiviteActeur.Name = "m_lnkTypeActiviteActeur";
            this.m_lnkTypeActiviteActeur.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTypeActiviteActeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTypeActiviteActeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTypeActiviteActeur.TabIndex = 8;
            this.m_lnkTypeActiviteActeur.TabStop = true;
            this.m_lnkTypeActiviteActeur.Text = "Members Activity Types|738";
            this.m_lnkTypeActiviteActeur.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTypeActiviteActeur_LinkClicked);
            // 
            // m_lnkSuiviActiviteActeurs
            // 
            this.m_lnkSuiviActiviteActeurs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_lnkSuiviActiviteActeurs.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkSuiviActiviteActeurs.ForeColor = System.Drawing.Color.Black;
            this.m_lnkSuiviActiviteActeurs.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkSuiviActiviteActeurs.LinkColor = System.Drawing.Color.Black;
            this.m_lnkSuiviActiviteActeurs.Location = new System.Drawing.Point(8, 126);
            this.m_extModuleAssociator.SetModules(this.m_lnkSuiviActiviteActeurs, "ASUIV_ACT");
            this.m_lnkSuiviActiviteActeurs.Name = "m_lnkSuiviActiviteActeurs";
            this.m_lnkSuiviActiviteActeurs.Size = new System.Drawing.Size(191, 14);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSuiviActiviteActeurs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSuiviActiviteActeurs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSuiviActiviteActeurs.TabIndex = 8;
            this.m_lnkSuiviActiviteActeurs.TabStop = true;
            this.m_lnkSuiviActiviteActeurs.Text = "Members Activity Follow-up|739";
            this.m_lnkSuiviActiviteActeurs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkSuiviActiviteActeurs_LinkClicked);
            // 
            // m_lnkActiviteActeurResume
            // 
            this.m_lnkActiviteActeurResume.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_lnkActiviteActeurResume.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkActiviteActeurResume.ForeColor = System.Drawing.Color.Black;
            this.m_lnkActiviteActeurResume.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkActiviteActeurResume.LinkColor = System.Drawing.Color.Black;
            this.m_lnkActiviteActeurResume.Location = new System.Drawing.Point(8, 146);
            this.m_extModuleAssociator.SetModules(this.m_lnkActiviteActeurResume, "ASUIV_ACT");
            this.m_lnkActiviteActeurResume.Name = "m_lnkActiviteActeurResume";
            this.m_lnkActiviteActeurResume.Size = new System.Drawing.Size(191, 14);
            this.m_extStyle.SetStyleBackColor(this.m_lnkActiviteActeurResume, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkActiviteActeurResume, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkActiviteActeurResume.TabIndex = 8;
            this.m_lnkActiviteActeurResume.TabStop = true;
            this.m_lnkActiviteActeurResume.Text = "Member Activity ( summary)|20000";
            this.m_lnkActiviteActeurResume.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkActiviteActeurResume_LinkClicked);
            // 
            // CFormMenuOrganisation
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(593, 459);
            this.Controls.Add(this.c2iPanelOmbre5);
            this.Controls.Add(this.m_panSecurite);
            this.m_extModuleAssociator.SetModules(this, "");
            this.Name = "CFormMenuOrganisation";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondFenetre);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "CFormMenuOrganisation";
            this.Load += new System.EventHandler(this.CFormMenuOrganisation_Load);
            this.Activated += new System.EventHandler(this.CFormMenuOrganisation_Activated);
            this.Enter += new System.EventHandler(this.CFormMenuOrganisation_Enter);
            this.c2iPanelOmbre3.ResumeLayout(false);
            this.c2iPanelOmbre3.PerformLayout();
            this.m_panSecurite.ResumeLayout(false);
            this.m_panSecurite.PerformLayout();
            this.m_panSecurite_2.ResumeLayout(false);
            this.c2iPanelOmbre5.ResumeLayout(false);
            this.c2iPanelOmbre5.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void CFormMenuOrganisation_Load(object sender, System.EventArgs e)
		{
            m_extModuleAssociator.AppliquerConfiguration(CTimosApp.ConfigurationModules);
            try
            {
                m_lnkSessionManager.Visible = CTimosApp.SessionClient.GetInfoUtilisateur().GetDonneeDroit(CDroitDeBase.c_droitBaseGestionSessions) != null;
            }
            catch { }

        }


		#region Membres de IFormNavigable

        public event ContexteFormEventHandler AfterGetContexte;
        public event ContexteFormEventHandler AfterInitFromContexte;

        public CContexteFormNavigable GetContexte()
        {
            CContexteFormNavigable contexte = new CContexteFormNavigable(GetType());
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
			// TODO : ajoutez l'implémentation de CFormMenuOrganisation.System.IDisposable.Dispose
		}

		#endregion



		private void CFormMenuOrganisation_Enter(object sender, System.EventArgs e)
		{
			CTimosApp.Titre = I.T( "Organisation|4");
		}

		

		private void CFormMenuOrganisation_Activated(object sender, System.EventArgs e)
		{
		}



        //****************************************************************************
        // Sécurité
        //****************************************************************************

        private void m_lnkTypeEntiteOrganisationnelle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeTypeEntiteOrganisationnelle());
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

 
        //****************************************************************************
        // Gestion des Acteurs
        //****************************************************************************
        private void m_lnkCivilites_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeCivilites());
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeActeurs());
        }

        private void m_lnkGroupesActeurs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeGroupesActeurs());
        }

        private void m_lnkTypeActiviteActeur_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeTypeActiviteActeur());
        }

        private void m_lnkSuiviActiviteActeurs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeActiviteActeurs());
        }

        private void m_lnkActiviteActeurResume_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeActiviteActeurResume());
        }

        private void m_lnkSessionManager_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CFormConsoleSuivi.GererSessions();
        }

        public string GetTitle()
        {
            return I.T("Organisation|4");
        }

        public Image GetImage()
        {
            return Resources.organisation;
        }

	}
}

