using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text;

using sc2i.win32.navigation;
using sc2i.common;
using sc2i.data;
using sc2i.multitiers.client;
using sc2i.win32.data;

using timos.data;
using timos.data.preventives;
using sc2i.win32.common;

using spv.data.SNMP;
using spv.data;
using timos.process;
using sc2i.data.dynamic;
using sc2i.win32.data.navigation;        // Pour le test snmp uniquement

namespace spv.win32
{
	/// <summary>
	/// Description résumée de CFormMenuOrganisation.
	/// </summary>
	[DynamicForm("Supervision")]
	public class CFormMenuOrganisation : CFormMaxiSansMenu, IFormNavigable
	{
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre3;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox m_chkSuiviDates;
        private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre5;
        private Label label5;
        private LinkLabel m_lnkAlarmesEnCours;
        private LinkLabel m_lnkParamSysteme;
        private C2iPanelOmbre m_panTypesModels;
        private Label labelTypesModels;
        private LinkLabel m_lnkMibs;
        private LinkLabel m_lnkFamillesMibs;
        private C2iPanelOmbre c2iPanelOmbre1;
        private Label label1;
        private LinkLabel m_linkAlarmColor;
        private LinkLabel m_lnkAlarmCauses;
        private LinkLabel linkLabel1;
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
            this.m_lnkParamSysteme = new System.Windows.Forms.LinkLabel();
            this.c2iPanelOmbre5 = new sc2i.win32.common.C2iPanelOmbre();
            this.label5 = new System.Windows.Forms.Label();
            this.m_lnkAlarmesEnCours = new System.Windows.Forms.LinkLabel();
            this.m_panTypesModels = new sc2i.win32.common.C2iPanelOmbre();
            this.m_lnkMibs = new System.Windows.Forms.LinkLabel();
            this.m_lnkFamillesMibs = new System.Windows.Forms.LinkLabel();
            this.labelTypesModels = new System.Windows.Forms.Label();
            this.c2iPanelOmbre1 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_linkAlarmColor = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.m_lnkAlarmCauses = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.c2iPanelOmbre3.SuspendLayout();
            this.c2iPanelOmbre5.SuspendLayout();
            this.m_panTypesModels.SuspendLayout();
            this.c2iPanelOmbre1.SuspendLayout();
            this.SuspendLayout();
            // 
            // c2iPanelOmbre3
            // 
            this.c2iPanelOmbre3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.c2iPanelOmbre3.Controls.Add(this.m_chkSuiviDates);
            this.c2iPanelOmbre3.Controls.Add(this.label4);
            this.c2iPanelOmbre3.Location = new System.Drawing.Point(10, 10);
            this.c2iPanelOmbre3.LockEdition = false;
            this.c2iPanelOmbre3.Name = "c2iPanelOmbre3";
            this.c2iPanelOmbre3.Size = new System.Drawing.Size(184, 108);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iPanelOmbre3.TabIndex = 11;
            // 
            // m_chkSuiviDates
            // 
            this.m_chkSuiviDates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_chkSuiviDates.ForeColor = System.Drawing.Color.Maroon;
            this.m_chkSuiviDates.Location = new System.Drawing.Point(16, 32);
            this.m_chkSuiviDates.Name = "m_chkSuiviDates";
            this.m_chkSuiviDates.Size = new System.Drawing.Size(104, 24);
            this.m_extStyle.SetStyleBackColor(this.m_chkSuiviDates, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkSuiviDates, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkSuiviDates.TabIndex = 5;
            this.m_chkSuiviDates.Text = "Suivi des dates";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 4;
            this.label4.Text = "Divers";
            // 
            // m_lnkParamSysteme
            // 
            this.m_lnkParamSysteme.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkParamSysteme.ForeColor = System.Drawing.Color.Black;
            this.m_lnkParamSysteme.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkParamSysteme.LinkColor = System.Drawing.Color.Black;
            this.m_lnkParamSysteme.Location = new System.Drawing.Point(8, 128);
            this.m_lnkParamSysteme.Name = "m_lnkParamSysteme";
            this.m_lnkParamSysteme.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkParamSysteme, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkParamSysteme, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkParamSysteme.TabIndex = 9;
            this.m_lnkParamSysteme.TabStop = true;
            this.m_lnkParamSysteme.Text = "System parameters|30012";
            this.m_lnkParamSysteme.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkParamSysteme_LinkClicked);
            // 
            // c2iPanelOmbre5
            // 
            this.c2iPanelOmbre5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre5.Controls.Add(this.label5);
            this.c2iPanelOmbre5.Controls.Add(this.m_lnkAlarmesEnCours);
            this.c2iPanelOmbre5.Location = new System.Drawing.Point(299, 12);
            this.c2iPanelOmbre5.LockEdition = false;
            this.c2iPanelOmbre5.Name = "c2iPanelOmbre5";
            this.c2iPanelOmbre5.Size = new System.Drawing.Size(261, 201);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre5, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iPanelOmbre5.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.SteelBlue;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Beige;
            this.label5.Location = new System.Drawing.Point(4, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(237, 23);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTitrePanel);
            this.label5.TabIndex = 4;
            this.label5.Text = "Consultation|60013";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lnkAlarmesEnCours
            // 
            this.m_lnkAlarmesEnCours.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkAlarmesEnCours.ForeColor = System.Drawing.Color.Black;
            this.m_lnkAlarmesEnCours.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkAlarmesEnCours.LinkColor = System.Drawing.Color.Black;
            this.m_lnkAlarmesEnCours.Location = new System.Drawing.Point(6, 50);
            this.m_lnkAlarmesEnCours.Name = "m_lnkAlarmesEnCours";
            this.m_lnkAlarmesEnCours.Size = new System.Drawing.Size(191, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAlarmesEnCours, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAlarmesEnCours, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAlarmesEnCours.TabIndex = 15;
            this.m_lnkAlarmesEnCours.TabStop = true;
            this.m_lnkAlarmesEnCours.Text = "Current alarms consultations|60008";
            this.m_lnkAlarmesEnCours.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkAlarmesEnCours_LinkClicked);
            // 
            // m_panTypesModels
            // 
            this.m_panTypesModels.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panTypesModels.Controls.Add(this.linkLabel1);
            this.m_panTypesModels.Controls.Add(this.m_lnkMibs);
            this.m_panTypesModels.Controls.Add(this.m_lnkFamillesMibs);
            this.m_panTypesModels.Controls.Add(this.labelTypesModels);
            this.m_panTypesModels.Location = new System.Drawing.Point(18, 12);
            this.m_panTypesModels.LockEdition = false;
            this.m_panTypesModels.Name = "m_panTypesModels";
            this.m_panTypesModels.Size = new System.Drawing.Size(261, 201);
            this.m_extStyle.SetStyleBackColor(this.m_panTypesModels, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panTypesModels, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panTypesModels.TabIndex = 15;
            // 
            // m_lnkMibs
            // 
            this.m_lnkMibs.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkMibs.ForeColor = System.Drawing.Color.Black;
            this.m_lnkMibs.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkMibs.LinkColor = System.Drawing.Color.Black;
            this.m_lnkMibs.Location = new System.Drawing.Point(8, 73);
            this.m_lnkMibs.Name = "m_lnkMibs";
            this.m_lnkMibs.Size = new System.Drawing.Size(100, 17);
            this.m_extStyle.SetStyleBackColor(this.m_lnkMibs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkMibs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkMibs.TabIndex = 4;
            this.m_lnkMibs.TabStop = true;
            this.m_lnkMibs.Text = "MIBS|50017";
            this.m_lnkMibs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lstMIBS_LinkClicked);
            // 
            // m_lnkFamillesMibs
            // 
            this.m_lnkFamillesMibs.AutoSize = true;
            this.m_lnkFamillesMibs.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkFamillesMibs.LinkColor = System.Drawing.Color.Black;
            this.m_lnkFamillesMibs.Location = new System.Drawing.Point(8, 50);
            this.m_lnkFamillesMibs.Name = "m_lnkFamillesMibs";
            this.m_lnkFamillesMibs.Size = new System.Drawing.Size(98, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkFamillesMibs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkFamillesMibs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkFamillesMibs.TabIndex = 6;
            this.m_lnkFamillesMibs.TabStop = true;
            this.m_lnkFamillesMibs.Text = "Mibs families|50062";
            this.m_lnkFamillesMibs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkFamillesMibs_LinkClicked);
            // 
            // labelTypesModels
            // 
            this.labelTypesModels.BackColor = System.Drawing.Color.SteelBlue;
            this.labelTypesModels.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelTypesModels.ForeColor = System.Drawing.Color.Beige;
            this.labelTypesModels.Location = new System.Drawing.Point(4, 4);
            this.labelTypesModels.Name = "labelTypesModels";
            this.labelTypesModels.Size = new System.Drawing.Size(237, 23);
            this.m_extStyle.SetStyleBackColor(this.labelTypesModels, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.labelTypesModels, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.labelTypesModels.TabIndex = 3;
            this.labelTypesModels.Text = "Types and Models|50016";
            // 
            // c2iPanelOmbre1
            // 
            this.c2iPanelOmbre1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre1.Controls.Add(this.m_linkAlarmColor);
            this.c2iPanelOmbre1.Controls.Add(this.label1);
            this.c2iPanelOmbre1.Controls.Add(this.m_lnkParamSysteme);
            this.c2iPanelOmbre1.Controls.Add(this.m_lnkAlarmCauses);
            this.c2iPanelOmbre1.Location = new System.Drawing.Point(18, 229);
            this.c2iPanelOmbre1.LockEdition = false;
            this.c2iPanelOmbre1.Name = "c2iPanelOmbre1";
            this.c2iPanelOmbre1.Size = new System.Drawing.Size(261, 201);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iPanelOmbre1.TabIndex = 16;
            // 
            // m_linkAlarmColor
            // 
            this.m_linkAlarmColor.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_linkAlarmColor.ForeColor = System.Drawing.Color.Black;
            this.m_linkAlarmColor.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_linkAlarmColor.LinkColor = System.Drawing.Color.Black;
            this.m_linkAlarmColor.Location = new System.Drawing.Point(8, 42);
            this.m_linkAlarmColor.Name = "m_linkAlarmColor";
            this.m_linkAlarmColor.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_linkAlarmColor, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_linkAlarmColor, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_linkAlarmColor.TabIndex = 15;
            this.m_linkAlarmColor.TabStop = true;
            this.m_linkAlarmColor.Text = "Alarm colors|60056";
            this.m_linkAlarmColor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_linkAlarmColor_LinkClicked);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Beige;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 23);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTitrePanel);
            this.label1.TabIndex = 4;
            this.label1.Text = "Parameters|60058";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lnkAlarmCauses
            // 
            this.m_lnkAlarmCauses.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkAlarmCauses.ForeColor = System.Drawing.Color.Black;
            this.m_lnkAlarmCauses.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkAlarmCauses.LinkColor = System.Drawing.Color.Black;
            this.m_lnkAlarmCauses.Location = new System.Drawing.Point(8, 67);
            this.m_lnkAlarmCauses.Name = "m_lnkAlarmCauses";
            this.m_lnkAlarmCauses.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAlarmCauses, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAlarmCauses, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAlarmCauses.TabIndex = 15;
            this.m_lnkAlarmCauses.TabStop = true;
            this.m_lnkAlarmCauses.Text = "Alarm causes|10020";
            this.m_lnkAlarmCauses.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkAlarmCauses_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(11, 94);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(58, 13);
            this.m_extStyle.SetStyleBackColor(this.linkLabel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.linkLabel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "test SNMP";
            this.linkLabel1.Visible = false;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // CFormMenuOrganisation
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(593, 529);
            this.Controls.Add(this.m_panTypesModels);
            this.Controls.Add(this.c2iPanelOmbre5);
            this.Controls.Add(this.c2iPanelOmbre1);
            this.Name = "CFormMenuOrganisation";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondFenetre);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "CFormMenuOrganisation";
            this.Load += new System.EventHandler(this.CFormMenuOrganisation_Load);
            this.Activated += new System.EventHandler(this.CFormMenuOrganisation_Activated);
            this.Enter += new System.EventHandler(this.CFormMenuOrganisation_Enter);
            this.c2iPanelOmbre3.ResumeLayout(false);
            this.c2iPanelOmbre3.PerformLayout();
            this.c2iPanelOmbre5.ResumeLayout(false);
            this.c2iPanelOmbre5.PerformLayout();
            this.m_panTypesModels.ResumeLayout(false);
            this.m_panTypesModels.PerformLayout();
            this.c2iPanelOmbre1.ResumeLayout(false);
            this.c2iPanelOmbre1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void CFormMenuOrganisation_Load(object sender, System.EventArgs e)
		{
            CSc2iWin32DataNavigation.Navigateur.TitreFenetreEnCours = I.T("Supervision Menu|10001");
        }


		#region Membres de IFormNavigable

		public CContexteFormNavigable GetContexte()
		{
			return new CContexteFormNavigable ( GetType() );
		}

	
		public bool QueryClose()
		{
			return true;
		}

		public sc2i.common.CResultAErreur InitFromContexte(CContexteFormNavigable contexte)
		{
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
			
		}

		

		private void CFormMenuOrganisation_Activated(object sender, System.EventArgs e)
		{
		}



        //****************************************************************************
        // Sécurité
		//****************************************************************************

        private void m_lnkEntiteOrganisationnelle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void m_lnkGroupeRestriction_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void m_lnkProfilsUtilisateurs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

 
        //****************************************************************************
        // Gestion des Acteurs
        //****************************************************************************
        private void m_lnkAlarmesEnCours_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          Navigateur.AffichePage(new CFormListeConsultationAlarmesEnCours());
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void m_lnkGroupesActeurs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void m_lnkTypeActiviteActeur_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void m_lnkSuiviActiviteActeurs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void m_lnkActiviteActeurResume_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

		private void m_lnkTypesAccesAlarm_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Navigateur.AffichePage(new CFormListeTypesAccesAlarmes());
		}

        private void m_lnkParamSysteme_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Navigateur.AffichePage(new CFormListeParamSysteme());
        }

        private void m_lstCablageAccessAlarm_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Navigateur.AffichePage(new CFormListeAcces_Accesc());
        }

        private void m_lstMIBS_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Navigateur.AffichePage(new CFormListeModulesMib());
        }

        private void m_lnkFamillesMibs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Navigateur.AffichePage(new CFormListeFamillesModulesMib());
        }

        private void m_linkAlarmColor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Navigateur.AffichePage(new CFormListeAlarmColor());
        }

        private void m_lnkAlarmCauses_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Navigateur.AffichePage(new CFormListeCauseAlarme());
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Requête sur SNMPv2-MIB (MIBMODULE_ID = 2 au moment du test)
            CRequeteSNMPVariable reqVar = new CRequeteSNMPVariable("192.168.94.95", "public", 2, "sysName");
            //CRequeteSNMPDansTable reqVar = new CRequeteSNMPDansTable("192.0.22.17", "public", 456, "ipAddrTable", "ipAdEntAddr", -1);
            //CSessionClient session = CSessionClient.CreateInstance();
            //session.OpenSession(new CAuthentificationSessionServer());
            using (CContexteDonnee ctx = new CContexteDonnee(CSc2iWin32DataClient.ContexteCourant.IdSession, true, false))
            {
                CResultAErreur result;

                string strValeur = "vir-xl-dev2008";
                
                result = reqVar.SetValueSNMP(ctx, strValeur);
                if (!result)
                    MessageBox.Show(result.MessageErreur);
                else
                {
                    result = reqVar.GetValueSNMP(ctx);
                    MessageBox.Show(result.Data.ToString());
                }

                // Test GetNext
                /*
                result = reqVar.GetNextValueSNMP(ctx);
                Hashtable var = (Hashtable)result.Data;
                MessageBox.Show("Type variable " + var["type"] +
                                " valeur variable " + var["value"] +
                                " oid variable " + var["oid"]);
                 */


                // Test GetTable
                /*
                List<CVariableSNMPResultat> liste;
                result = reqVar.GetTableSNMP(ctx);
                if (result)
                    liste = (List<CVariableSNMPResultat>)result.Data;
                 */
            }

        }


	}
}

