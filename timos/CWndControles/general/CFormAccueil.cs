using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text;

using sc2i.win32.navigation;
using sc2i.common;
using sc2i.data;
using sc2i.multitiers.client;
using sc2i.win32.data;
using sc2i.workflow;

using timos.data;
using timos.securite;
using timos.acteurs;
using sc2i.win32.common;

namespace timos
{
	/// <summary>
	/// Description résumée de CFormAccueil.
	/// </summary>
	[DynamicForm("Test")]
	public class CFormAccueil : CFormMaxiSansMenu, IFormNavigable
	{
		private System.Windows.Forms.Panel panel1;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.LinkLabel linkLabel3;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox m_chkSuiviDates;
		private System.Windows.Forms.LinkLabel m_lnkEnseignes;
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre5;
		private System.Windows.Forms.LinkLabel m_lnkRestrictions;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.LinkLabel m_lnkFiltres;
		private System.Windows.Forms.LinkLabel m_lnkUtilisateurs;
		private System.Windows.Forms.PictureBox pictureBox2;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre2;
		private System.Windows.Forms.Label label3;
		private sc2i.win32.common.C2iPanelOmbre m_panelX;
		private System.Windows.Forms.LinkLabel m_lnkFamilles;
		private System.Windows.Forms.Label label2;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.LinkLabel m_lnkReceptionsColis;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.LinkLabel m_lnkGroupesActeurs;
		private LinkLabel m_lnkTypeEO;
        private LinkLabel m_lnkEntiteOrganisationnelle;
        protected sc2i.win32.common.CToolTipTraductible m_ToolTipTraductible1;
        private LinkLabel linkLabel2;
        private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre6;
        private LinkLabel linkLabel4;
        private Label label8;
        private LinkLabel linkLabel5;
        private LinkLabel m_lnkInterventions;
        private IContainer components;

		public CFormAccueil()
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.c2iPanelOmbre5 = new sc2i.win32.common.C2iPanelOmbre();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.m_lnkUtilisateurs = new System.Windows.Forms.LinkLabel();
            this.m_lnkRestrictions = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.m_lnkFiltres = new System.Windows.Forms.LinkLabel();
            this.c2iPanelOmbre3 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_chkSuiviDates = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_lnkEnseignes = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.c2iPanelOmbre2 = new sc2i.win32.common.C2iPanelOmbre();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.m_lnkGroupesActeurs = new System.Windows.Forms.LinkLabel();
            this.m_lnkEntiteOrganisationnelle = new System.Windows.Forms.LinkLabel();
            this.m_lnkTypeEO = new System.Windows.Forms.LinkLabel();
            this.m_panelX = new sc2i.win32.common.C2iPanelOmbre();
            this.m_lnkInterventions = new System.Windows.Forms.LinkLabel();
            this.m_lnkFamilles = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.c2iPanelOmbre1 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_lnkReceptionsColis = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.m_ToolTipTraductible1 = new sc2i.win32.common.CToolTipTraductible(this.components);
            this.c2iPanelOmbre6 = new sc2i.win32.common.C2iPanelOmbre();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.c2iPanelOmbre5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.c2iPanelOmbre3.SuspendLayout();
            this.c2iPanelOmbre4.SuspendLayout();
            this.c2iPanelOmbre2.SuspendLayout();
            this.m_panelX.SuspendLayout();
            this.c2iPanelOmbre1.SuspendLayout();
            this.c2iPanelOmbre6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.c2iPanelOmbre5);
            this.panel1.Location = new System.Drawing.Point(614, 415);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 176);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 8;
            // 
            // c2iPanelOmbre5
            // 
            this.c2iPanelOmbre5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iPanelOmbre5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(212)))), ((int)(((byte)(89)))));
            this.c2iPanelOmbre5.Controls.Add(this.pictureBox2);
            this.c2iPanelOmbre5.Controls.Add(this.m_lnkUtilisateurs);
            this.c2iPanelOmbre5.Controls.Add(this.m_lnkRestrictions);
            this.c2iPanelOmbre5.Controls.Add(this.label6);
            this.c2iPanelOmbre5.Controls.Add(this.m_lnkFiltres);
            this.c2iPanelOmbre5.Location = new System.Drawing.Point(8, 48);
            this.c2iPanelOmbre5.LockEdition = false;
            this.c2iPanelOmbre5.Name = "c2iPanelOmbre5";
            this.c2iPanelOmbre5.Size = new System.Drawing.Size(184, 120);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iPanelOmbre5.TabIndex = 7;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.Location = new System.Drawing.Point(8, 56);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(152, 1);
            this.m_extStyle.SetStyleBackColor(this.pictureBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pictureBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // m_lnkUtilisateurs
            // 
            this.m_lnkUtilisateurs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(212)))), ((int)(((byte)(89)))));
            this.m_lnkUtilisateurs.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkUtilisateurs.LinkColor = System.Drawing.Color.Black;
            this.m_lnkUtilisateurs.Location = new System.Drawing.Point(8, 64);
            this.m_lnkUtilisateurs.Name = "m_lnkUtilisateurs";
            this.m_lnkUtilisateurs.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkUtilisateurs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkUtilisateurs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkUtilisateurs.TabIndex = 7;
            this.m_lnkUtilisateurs.TabStop = true;
            this.m_lnkUtilisateurs.Text = "Users|30171";
            this.m_lnkUtilisateurs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkUtilisateurs_LinkClicked);
            // 
            // m_lnkRestrictions
            // 
            this.m_lnkRestrictions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(212)))), ((int)(((byte)(89)))));
            this.m_lnkRestrictions.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkRestrictions.LinkColor = System.Drawing.Color.Black;
            this.m_lnkRestrictions.Location = new System.Drawing.Point(8, 80);
            this.m_lnkRestrictions.Name = "m_lnkRestrictions";
            this.m_lnkRestrictions.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkRestrictions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkRestrictions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkRestrictions.TabIndex = 6;
            this.m_lnkRestrictions.TabStop = true;
            this.m_lnkRestrictions.Text = "User groups|30172";
            this.m_lnkRestrictions.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkRestrictions_LinkClicked);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 23);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 4;
            this.label6.Text = "Administration|715";
            // 
            // m_lnkFiltres
            // 
            this.m_lnkFiltres.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(212)))), ((int)(((byte)(89)))));
            this.m_lnkFiltres.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkFiltres.LinkColor = System.Drawing.Color.Black;
            this.m_lnkFiltres.Location = new System.Drawing.Point(8, 32);
            this.m_lnkFiltres.Name = "m_lnkFiltres";
            this.m_lnkFiltres.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkFiltres, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkFiltres, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkFiltres.TabIndex = 5;
            this.m_lnkFiltres.TabStop = true;
            this.m_lnkFiltres.Text = "Filters|30170";
            this.m_lnkFiltres.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkFiltres_LinkClicked);
            // 
            // c2iPanelOmbre3
            // 
            this.c2iPanelOmbre3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.c2iPanelOmbre3.Controls.Add(this.m_chkSuiviDates);
            this.c2iPanelOmbre3.Controls.Add(this.label4);
            this.c2iPanelOmbre3.Location = new System.Drawing.Point(8, 304);
            this.c2iPanelOmbre3.LockEdition = false;
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
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(212)))), ((int)(((byte)(89)))));
            this.c2iPanelOmbre4.Controls.Add(this.m_lnkEnseignes);
            this.c2iPanelOmbre4.Controls.Add(this.label5);
            this.c2iPanelOmbre4.Controls.Add(this.linkLabel3);
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(395, 146);
            this.c2iPanelOmbre4.LockEdition = false;
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(184, 116);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iPanelOmbre4.TabIndex = 9;
            // 
            // m_lnkEnseignes
            // 
            this.m_lnkEnseignes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(212)))), ((int)(((byte)(89)))));
            this.m_lnkEnseignes.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkEnseignes.LinkColor = System.Drawing.Color.Black;
            this.m_lnkEnseignes.Location = new System.Drawing.Point(8, 32);
            this.m_lnkEnseignes.Name = "m_lnkEnseignes";
            this.m_lnkEnseignes.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkEnseignes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkEnseignes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkEnseignes.TabIndex = 6;
            this.m_lnkEnseignes.TabStop = true;
            this.m_lnkEnseignes.Text = "Nameplates|30169";
            this.m_lnkEnseignes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkEnseignes_LinkClicked);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(8, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 4;
            this.label5.Text = "Shops|30168";
            // 
            // linkLabel3
            // 
            this.linkLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(212)))), ((int)(((byte)(89)))));
            this.linkLabel3.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.linkLabel3.LinkColor = System.Drawing.Color.Black;
            this.linkLabel3.Location = new System.Drawing.Point(8, 48);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.linkLabel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.linkLabel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.linkLabel3.TabIndex = 0;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Shops|30168";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 48);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 11;
            this.label1.Text = "Test page|30163";
            // 
            // c2iPanelOmbre2
            // 
            this.c2iPanelOmbre2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre2.Controls.Add(this.label3);
            this.c2iPanelOmbre2.Controls.Add(this.linkLabel1);
            this.c2iPanelOmbre2.Controls.Add(this.linkLabel2);
            this.c2iPanelOmbre2.Controls.Add(this.m_lnkGroupesActeurs);
            this.c2iPanelOmbre2.Controls.Add(this.m_lnkEntiteOrganisationnelle);
            this.c2iPanelOmbre2.Controls.Add(this.m_lnkTypeEO);
            this.c2iPanelOmbre2.Location = new System.Drawing.Point(16, 99);
            this.c2iPanelOmbre2.LockEdition = false;
            this.c2iPanelOmbre2.Name = "c2iPanelOmbre2";
            this.c2iPanelOmbre2.Size = new System.Drawing.Size(184, 182);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iPanelOmbre2.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Beige;
            this.label3.Location = new System.Drawing.Point(8, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 23);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTitrePanel);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tests|30164";
            // 
            // linkLabel1
            // 
            this.linkLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.linkLabel1.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.linkLabel1.ForeColor = System.Drawing.Color.Black;
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(8, 31);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.linkLabel1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.linkLabel1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Members|736";
            this.m_ToolTipTraductible1.SetToolTip(this.linkLabel1, "Gestion des acteurs|300");
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.linkLabel2.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.linkLabel2.ForeColor = System.Drawing.Color.Black;
            this.linkLabel2.LinkColor = System.Drawing.Color.Black;
            this.linkLabel2.Location = new System.Drawing.Point(8, 72);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.linkLabel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.linkLabel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.linkLabel2.TabIndex = 7;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Contracts|640";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // m_lnkGroupesActeurs
            // 
            this.m_lnkGroupesActeurs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_lnkGroupesActeurs.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkGroupesActeurs.ForeColor = System.Drawing.Color.Black;
            this.m_lnkGroupesActeurs.LinkColor = System.Drawing.Color.Black;
            this.m_lnkGroupesActeurs.Location = new System.Drawing.Point(8, 47);
            this.m_lnkGroupesActeurs.Name = "m_lnkGroupesActeurs";
            this.m_lnkGroupesActeurs.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkGroupesActeurs, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_lnkGroupesActeurs, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_lnkGroupesActeurs.TabIndex = 8;
            this.m_lnkGroupesActeurs.TabStop = true;
            this.m_lnkGroupesActeurs.Text = "Members Groups|737";
            this.m_lnkGroupesActeurs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkContacts_LinkClicked);
            // 
            // m_lnkEntiteOrganisationnelle
            // 
            this.m_lnkEntiteOrganisationnelle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_lnkEntiteOrganisationnelle.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkEntiteOrganisationnelle.ForeColor = System.Drawing.Color.Black;
            this.m_lnkEntiteOrganisationnelle.LinkColor = System.Drawing.Color.Black;
            this.m_lnkEntiteOrganisationnelle.Location = new System.Drawing.Point(8, 114);
            this.m_lnkEntiteOrganisationnelle.Name = "m_lnkEntiteOrganisationnelle";
            this.m_lnkEntiteOrganisationnelle.Size = new System.Drawing.Size(144, 28);
            this.m_extStyle.SetStyleBackColor(this.m_lnkEntiteOrganisationnelle, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_lnkEntiteOrganisationnelle, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_lnkEntiteOrganisationnelle.TabIndex = 10;
            this.m_lnkEntiteOrganisationnelle.TabStop = true;
            this.m_lnkEntiteOrganisationnelle.Text = "Organisational Entities|132";
            this.m_lnkEntiteOrganisationnelle.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkEntiteOrganisationnelle_LinkClicked);
            // 
            // m_lnkTypeEO
            // 
            this.m_lnkTypeEO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_lnkTypeEO.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkTypeEO.ForeColor = System.Drawing.Color.Black;
            this.m_lnkTypeEO.LinkColor = System.Drawing.Color.Black;
            this.m_lnkTypeEO.Location = new System.Drawing.Point(8, 98);
            this.m_lnkTypeEO.Name = "m_lnkTypeEO";
            this.m_lnkTypeEO.Size = new System.Drawing.Size(160, 40);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTypeEO, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTypeEO, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_lnkTypeEO.TabIndex = 9;
            this.m_lnkTypeEO.TabStop = true;
            this.m_lnkTypeEO.Text = "Organisational Entity Type|131";
            this.m_lnkTypeEO.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTypeEO_LinkClicked);
            // 
            // m_panelX
            // 
            this.m_panelX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(212)))), ((int)(((byte)(89)))));
            this.m_panelX.Controls.Add(this.m_lnkInterventions);
            this.m_panelX.Controls.Add(this.m_lnkFamilles);
            this.m_panelX.Controls.Add(this.label2);
            this.m_panelX.Location = new System.Drawing.Point(208, 99);
            this.m_panelX.LockEdition = false;
            this.m_panelX.Name = "m_panelX";
            this.m_panelX.Size = new System.Drawing.Size(184, 88);
            this.m_extStyle.SetStyleBackColor(this.m_panelX, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelX, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelX.TabIndex = 10;
            // 
            // m_lnkInterventions
            // 
            this.m_lnkInterventions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(212)))), ((int)(((byte)(89)))));
            this.m_lnkInterventions.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkInterventions.LinkColor = System.Drawing.Color.Black;
            this.m_lnkInterventions.Location = new System.Drawing.Point(8, 48);
            this.m_lnkInterventions.Name = "m_lnkInterventions";
            this.m_lnkInterventions.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkInterventions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkInterventions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkInterventions.TabIndex = 7;
            this.m_lnkInterventions.TabStop = true;
            this.m_lnkInterventions.Text = "Tasks|938";
            this.m_lnkInterventions.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkInterventions_LinkClicked);
            // 
            // m_lnkFamilles
            // 
            this.m_lnkFamilles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(212)))), ((int)(((byte)(89)))));
            this.m_lnkFamilles.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkFamilles.LinkColor = System.Drawing.Color.Black;
            this.m_lnkFamilles.Location = new System.Drawing.Point(8, 32);
            this.m_lnkFamilles.Name = "m_lnkFamilles";
            this.m_lnkFamilles.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkFamilles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkFamilles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkFamilles.TabIndex = 6;
            this.m_lnkFamilles.TabStop = true;
            this.m_lnkFamilles.Text = "Test|30113";
            this.m_lnkFamilles.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkFamilles_LinkClicked);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tasks|930";
            // 
            // c2iPanelOmbre1
            // 
            this.c2iPanelOmbre1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.c2iPanelOmbre1.Controls.Add(this.m_lnkReceptionsColis);
            this.c2iPanelOmbre1.Controls.Add(this.label7);
            this.c2iPanelOmbre1.Location = new System.Drawing.Point(208, 193);
            this.c2iPanelOmbre1.LockEdition = false;
            this.c2iPanelOmbre1.Name = "c2iPanelOmbre1";
            this.c2iPanelOmbre1.Size = new System.Drawing.Size(184, 88);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iPanelOmbre1.TabIndex = 11;
            // 
            // m_lnkReceptionsColis
            // 
            this.m_lnkReceptionsColis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.m_lnkReceptionsColis.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkReceptionsColis.LinkColor = System.Drawing.Color.Black;
            this.m_lnkReceptionsColis.Location = new System.Drawing.Point(8, 32);
            this.m_lnkReceptionsColis.Name = "m_lnkReceptionsColis";
            this.m_lnkReceptionsColis.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkReceptionsColis, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkReceptionsColis, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkReceptionsColis.TabIndex = 6;
            this.m_lnkReceptionsColis.TabStop = true;
            this.m_lnkReceptionsColis.Text = "Parcel receptions|30166";
            this.m_lnkReceptionsColis.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkReceptionsColis_LinkClicked);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(8, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 4;
            this.label7.Text = "Receptions|30165";
            // 
            // c2iPanelOmbre6
            // 
            this.c2iPanelOmbre6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre6.Controls.Add(this.linkLabel4);
            this.c2iPanelOmbre6.Controls.Add(this.label8);
            this.c2iPanelOmbre6.Controls.Add(this.linkLabel5);
            this.c2iPanelOmbre6.ForeColor = System.Drawing.Color.Black;
            this.c2iPanelOmbre6.Location = new System.Drawing.Point(398, 58);
            this.c2iPanelOmbre6.LockEdition = false;
            this.c2iPanelOmbre6.Name = "c2iPanelOmbre6";
            this.c2iPanelOmbre6.Size = new System.Drawing.Size(184, 88);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre6, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre6, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre6.TabIndex = 11;
            // 
            // linkLabel4
            // 
            this.linkLabel4.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.linkLabel4.LinkColor = System.Drawing.Color.Black;
            this.linkLabel4.Location = new System.Drawing.Point(8, 32);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.linkLabel4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.linkLabel4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.linkLabel4.TabIndex = 6;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "New Ticket|10028";
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(8, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.m_extStyle.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 4;
            this.label8.Text = "Tickets|30167";
            // 
            // linkLabel5
            // 
            this.linkLabel5.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.linkLabel5.LinkColor = System.Drawing.Color.Black;
            this.linkLabel5.Location = new System.Drawing.Point(8, 48);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.linkLabel5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.linkLabel5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.linkLabel5.TabIndex = 6;
            this.linkLabel5.TabStop = true;
            this.linkLabel5.Text = "Ticket List|730";
            this.linkLabel5.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel5_LinkClicked);
            // 
            // CFormAccueil
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(826, 603);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.c2iPanelOmbre2);
            this.Controls.Add(this.m_panelX);
            this.Controls.Add(this.c2iPanelOmbre6);
            this.Controls.Add(this.c2iPanelOmbre1);
            this.Name = "CFormAccueil";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "CFormAccueil";
            this.Enter += new System.EventHandler(this.CFormAccueil_Enter);
            this.Activated += new System.EventHandler(this.CFormAccueil_Activated);
            this.Load += new System.EventHandler(this.CFormAccueil_Load);
            this.panel1.ResumeLayout(false);
            this.c2iPanelOmbre5.ResumeLayout(false);
            this.c2iPanelOmbre5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.c2iPanelOmbre3.ResumeLayout(false);
            this.c2iPanelOmbre3.PerformLayout();
            this.c2iPanelOmbre4.ResumeLayout(false);
            this.c2iPanelOmbre4.PerformLayout();
            this.c2iPanelOmbre2.ResumeLayout(false);
            this.c2iPanelOmbre2.PerformLayout();
            this.m_panelX.ResumeLayout(false);
            this.m_panelX.PerformLayout();
            this.c2iPanelOmbre1.ResumeLayout(false);
            this.c2iPanelOmbre1.PerformLayout();
            this.c2iPanelOmbre6.ResumeLayout(false);
            this.c2iPanelOmbre6.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void CFormAccueil_Load(object sender, System.EventArgs e)
		{
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
			// TODO : ajoutez l'implémentation de CFormAccueil.System.IDisposable.Dispose
		}

		#endregion



		private void CFormAccueil_Enter(object sender, System.EventArgs e)
		{
			CTimosApp.Titre = I.T("Home|714");
        }

		

		private void CFormAccueil_Activated(object sender, System.EventArgs e)
		{
		}

		private void m_lnkUtilisateurs_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
		}

		private void m_lnkFiltres_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage ( new CFormListeFiltresDynamiques() );
		}

		private void m_lnkEnseignes_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			using ( CContexteDonnee  contexte = new CContexteDonnee(CTimosApp.SessionClient.IdSession, true, false) )
			{
				CListeObjetsDonnees  liste = new CListeObjetsDonnees ( contexte, typeof ( CEntiteOrganisationnelle ) );
				Random rnd = new Random();
				for (int nNumero = 0; nNumero < 10000; nNumero++)
				{
					int nNbEOs = rnd.Next(liste.Count - 1);
					//CTestSecurite test = new CTestSecurite(contexte);
					//test.CreateNewInCurrentContexte();
					//test.Libelle = "Test n°" + nNumero;
					StringBuilder builder = new StringBuilder();
					for (int nEO = 0; nEO < nNbEOs; nEO++)
					{
						int nNumEO = rnd.Next(liste.Count - 1);
						CEntiteOrganisationnelle entite = (CEntiteOrganisationnelle)liste[nNumEO];
						builder.Append("~");
						builder.Append(entite.CodeSystemeComplet);
					}
					//test.EOs = builder.ToString();
				}
				contexte.SaveAll(true);
			}
		}

		private void m_lnkRestrictions_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			//CTimosApp.Navigateur.AffichePage ( new CFormListeGroupesRestrictions() );
		}

		private void m_lnkCampagnesReleves_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			//CTimosApp.Navigateur.AffichePage (new CFormListeCampagneReleves() );
		}

		private void m_lnkFamilles_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			CFormPlanification form = new CFormPlanification();
			form.Show();
		}

		private void m_lnkReceptionsColis_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			//CTimosApp.Navigateur.AffichePage ( new CFormListeReceptionColis() );
		}

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage ( new CFormListeActeurs() );
		}

		private void m_lnkContacts_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage ( new CFormListeGroupesActeurs()) ;
		}

		private void m_lnkTypeEO_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeTypeEntiteOrganisationnelle());
		}

		private void m_lnkEntiteOrganisationnelle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeEntiteOrganisationnelle());
		}

        private void m_linkLabelTypeSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeTypeSite());
        }

        private void m_linkLabelSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeSite());

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeContrat());
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CFormTestEditionNouveauTicket form = new CFormTestEditionNouveauTicket();
            form.Init();
            form.Show();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeTicket());

        }

		private void m_lnkInterventions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeInterventions());
		}

      

	}

}

