using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using sc2i.win32.navigation;
using sc2i.common;
using timos.data;
using sc2i.data;
using sc2i.multitiers.client;
using sc2i.win32.data;
using timos.version;
using sc2i.win32.common;

namespace timos
{
	/// <summary>
	/// Description résumée de CFormMenuIngenierie.
	/// </summary>
	[DynamicForm("Ingenierie")]
	public class CFormMenuIngenierie : CFormMaxiSansMenu, IFormNavigable
	{
		#region Code généré par le Concepteur Windows Form

		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre3;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox m_chkSuiviDates;
        private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre1;
        private Panel panel3;
        private Label label1;
        private LinkLabel m_lnkAuditVersion;
        private LinkLabel m_lnkTypeAuditVersion;
        private LinkLabel m_lnkVersions;
        private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre2;
        private Panel panel1;
        private Label label2;
        private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
        private Panel panel2;
        private Label label3;
        private LinkLabel m_lnkDossiers;
        private LinkLabel m_lnkTypeDossier;
        private LinkLabel m_lnkProjet;
        private LinkLabel m_lnkTypeProjet;
		private LinkLabel m_lnkCategoriesDeVersions;
        private CExtModulesAssociator m_extModuleAssociator;
        private LinkLabel m_lnkParametragesGantt;
        private LinkLabel m_lnkParametragesDessinGant;
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;
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
            this.c2iPanelOmbre3 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_chkSuiviDates = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.c2iPanelOmbre1 = new sc2i.win32.common.C2iPanelOmbre();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_lnkCategoriesDeVersions = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.m_lnkAuditVersion = new System.Windows.Forms.LinkLabel();
            this.m_lnkTypeAuditVersion = new System.Windows.Forms.LinkLabel();
            this.m_lnkVersions = new System.Windows.Forms.LinkLabel();
            this.c2iPanelOmbre2 = new sc2i.win32.common.C2iPanelOmbre();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_lnkDossiers = new System.Windows.Forms.LinkLabel();
            this.m_lnkTypeDossier = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_lnkParametragesDessinGant = new System.Windows.Forms.LinkLabel();
            this.m_lnkParametragesGantt = new System.Windows.Forms.LinkLabel();
            this.m_lnkProjet = new System.Windows.Forms.LinkLabel();
            this.m_lnkTypeProjet = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.m_extModuleAssociator = new timos.CExtModulesAssociator();
            this.c2iPanelOmbre3.SuspendLayout();
            this.c2iPanelOmbre1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.c2iPanelOmbre2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.c2iPanelOmbre4.SuspendLayout();
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
            // c2iPanelOmbre1
            // 
            this.c2iPanelOmbre1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre1.Controls.Add(this.panel3);
            this.c2iPanelOmbre1.Location = new System.Drawing.Point(12, 238);
            this.c2iPanelOmbre1.LockEdition = false;
            this.m_extModuleAssociator.SetModules(this.c2iPanelOmbre1, "AINGE_REFERENTIEL");
            this.c2iPanelOmbre1.Name = "c2iPanelOmbre1";
            this.c2iPanelOmbre1.Size = new System.Drawing.Size(252, 156);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iPanelOmbre1.TabIndex = 15;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.m_lnkCategoriesDeVersions);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.m_lnkAuditVersion);
            this.panel3.Controls.Add(this.m_lnkTypeAuditVersion);
            this.panel3.Controls.Add(this.m_lnkVersions);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.m_extModuleAssociator.SetModules(this.panel3, "");
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(231, 140);
            this.m_extStyle.SetStyleBackColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel3.TabIndex = 11;
            // 
            // m_lnkCategoriesDeVersions
            // 
            this.m_lnkCategoriesDeVersions.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkCategoriesDeVersions.ForeColor = System.Drawing.Color.Black;
            this.m_lnkCategoriesDeVersions.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkCategoriesDeVersions.LinkColor = System.Drawing.Color.Black;
            this.m_lnkCategoriesDeVersions.Location = new System.Drawing.Point(10, 55);
            this.m_extModuleAssociator.SetModules(this.m_lnkCategoriesDeVersions, "");
            this.m_lnkCategoriesDeVersions.Name = "m_lnkCategoriesDeVersions";
            this.m_lnkCategoriesDeVersions.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkCategoriesDeVersions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkCategoriesDeVersions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkCategoriesDeVersions.TabIndex = 7;
            this.m_lnkCategoriesDeVersions.TabStop = true;
            this.m_lnkCategoriesDeVersions.Text = "Versions categories|20038";
            this.m_lnkCategoriesDeVersions.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkCategoriesDeVersions_LinkClicked);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Beige;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.m_extModuleAssociator.SetModules(this.label1, "");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 23);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4;
            this.label1.Text = "Versions|1328";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lnkAuditVersion
            // 
            this.m_lnkAuditVersion.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkAuditVersion.ForeColor = System.Drawing.Color.Black;
            this.m_lnkAuditVersion.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkAuditVersion.LinkColor = System.Drawing.Color.Black;
            this.m_lnkAuditVersion.Location = new System.Drawing.Point(10, 103);
            this.m_extModuleAssociator.SetModules(this.m_lnkAuditVersion, "");
            this.m_lnkAuditVersion.Name = "m_lnkAuditVersion";
            this.m_lnkAuditVersion.Size = new System.Drawing.Size(134, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAuditVersion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAuditVersion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAuditVersion.TabIndex = 6;
            this.m_lnkAuditVersion.TabStop = true;
            this.m_lnkAuditVersion.Text = "Audit|1277";
            this.m_lnkAuditVersion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkAuditVersion_LinkClicked);
            // 
            // m_lnkTypeAuditVersion
            // 
            this.m_lnkTypeAuditVersion.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkTypeAuditVersion.ForeColor = System.Drawing.Color.Black;
            this.m_lnkTypeAuditVersion.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkTypeAuditVersion.LinkColor = System.Drawing.Color.Black;
            this.m_lnkTypeAuditVersion.Location = new System.Drawing.Point(10, 83);
            this.m_extModuleAssociator.SetModules(this.m_lnkTypeAuditVersion, "");
            this.m_lnkTypeAuditVersion.Name = "m_lnkTypeAuditVersion";
            this.m_lnkTypeAuditVersion.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTypeAuditVersion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTypeAuditVersion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTypeAuditVersion.TabIndex = 6;
            this.m_lnkTypeAuditVersion.TabStop = true;
            this.m_lnkTypeAuditVersion.Text = "Audit Types|1395";
            this.m_lnkTypeAuditVersion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTypeAuditVersion_LinkClicked);
            // 
            // m_lnkVersions
            // 
            this.m_lnkVersions.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkVersions.ForeColor = System.Drawing.Color.Black;
            this.m_lnkVersions.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkVersions.LinkColor = System.Drawing.Color.Black;
            this.m_lnkVersions.Location = new System.Drawing.Point(10, 39);
            this.m_extModuleAssociator.SetModules(this.m_lnkVersions, "");
            this.m_lnkVersions.Name = "m_lnkVersions";
            this.m_lnkVersions.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkVersions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkVersions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkVersions.TabIndex = 6;
            this.m_lnkVersions.TabStop = true;
            this.m_lnkVersions.Text = "Versions|1328";
            this.m_lnkVersions.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkVersions_LinkClicked);
            // 
            // c2iPanelOmbre2
            // 
            this.c2iPanelOmbre2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre2.Controls.Add(this.panel1);
            this.c2iPanelOmbre2.Location = new System.Drawing.Point(12, 12);
            this.c2iPanelOmbre2.LockEdition = false;
            this.m_extModuleAssociator.SetModules(this.c2iPanelOmbre2, "");
            this.c2iPanelOmbre2.Name = "c2iPanelOmbre2";
            this.c2iPanelOmbre2.Size = new System.Drawing.Size(252, 164);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iPanelOmbre2.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.m_lnkDossiers);
            this.panel1.Controls.Add(this.m_lnkTypeDossier);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.m_extModuleAssociator.SetModules(this.panel1, "");
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(231, 148);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 11;
            // 
            // m_lnkDossiers
            // 
            this.m_lnkDossiers.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkDossiers.ForeColor = System.Drawing.Color.Black;
            this.m_lnkDossiers.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkDossiers.LinkColor = System.Drawing.Color.Black;
            this.m_lnkDossiers.Location = new System.Drawing.Point(10, 66);
            this.m_extModuleAssociator.SetModules(this.m_lnkDossiers, "");
            this.m_lnkDossiers.Name = "m_lnkDossiers";
            this.m_lnkDossiers.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkDossiers, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkDossiers, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkDossiers.TabIndex = 9;
            this.m_lnkDossiers.TabStop = true;
            this.m_lnkDossiers.Text = "Workbooks|727";
            this.m_lnkDossiers.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkDossiers_LinkClicked);
            // 
            // m_lnkTypeDossier
            // 
            this.m_lnkTypeDossier.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkTypeDossier.ForeColor = System.Drawing.Color.Black;
            this.m_lnkTypeDossier.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkTypeDossier.LinkColor = System.Drawing.Color.Black;
            this.m_lnkTypeDossier.Location = new System.Drawing.Point(10, 45);
            this.m_extModuleAssociator.SetModules(this.m_lnkTypeDossier, "");
            this.m_lnkTypeDossier.Name = "m_lnkTypeDossier";
            this.m_lnkTypeDossier.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTypeDossier, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTypeDossier, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTypeDossier.TabIndex = 8;
            this.m_lnkTypeDossier.TabStop = true;
            this.m_lnkTypeDossier.Text = "Workbook Types|726";
            this.m_lnkTypeDossier.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTypeDossier_LinkClicked);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Beige;
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.m_extModuleAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 23);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4;
            this.label2.Text = "Workbooks|727";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.panel2);
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(296, 12);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_extModuleAssociator.SetModules(this.c2iPanelOmbre4, "AINGE_PROJET");
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(252, 164);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iPanelOmbre4.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.m_lnkParametragesDessinGant);
            this.panel2.Controls.Add(this.m_lnkParametragesGantt);
            this.panel2.Controls.Add(this.m_lnkProjet);
            this.panel2.Controls.Add(this.m_lnkTypeProjet);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.m_extModuleAssociator.SetModules(this.panel2, "");
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(231, 148);
            this.m_extStyle.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel2.TabIndex = 11;
            // 
            // m_lnkParametragesDessinGant
            // 
            this.m_lnkParametragesDessinGant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_lnkParametragesDessinGant.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkParametragesDessinGant.ForeColor = System.Drawing.Color.Black;
            this.m_lnkParametragesDessinGant.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkParametragesDessinGant.LinkColor = System.Drawing.Color.Black;
            this.m_lnkParametragesDessinGant.Location = new System.Drawing.Point(14, 115);
            this.m_extModuleAssociator.SetModules(this.m_lnkParametragesDessinGant, "");
            this.m_lnkParametragesDessinGant.Name = "m_lnkParametragesDessinGant";
            this.m_lnkParametragesDessinGant.Size = new System.Drawing.Size(191, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkParametragesDessinGant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkParametragesDessinGant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkParametragesDessinGant.TabIndex = 15;
            this.m_lnkParametragesDessinGant.TabStop = true;
            this.m_lnkParametragesDessinGant.Text = "Gantt drawing settings|10056";
            this.m_lnkParametragesDessinGant.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkParametragesDessinGant_LinkClicked);
            // 
            // m_lnkParametragesGantt
            // 
            this.m_lnkParametragesGantt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_lnkParametragesGantt.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkParametragesGantt.ForeColor = System.Drawing.Color.Black;
            this.m_lnkParametragesGantt.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkParametragesGantt.LinkColor = System.Drawing.Color.Black;
            this.m_lnkParametragesGantt.Location = new System.Drawing.Point(14, 95);
            this.m_extModuleAssociator.SetModules(this.m_lnkParametragesGantt, "");
            this.m_lnkParametragesGantt.Name = "m_lnkParametragesGantt";
            this.m_lnkParametragesGantt.Size = new System.Drawing.Size(191, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkParametragesGantt, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkParametragesGantt, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkParametragesGantt.TabIndex = 15;
            this.m_lnkParametragesGantt.TabStop = true;
            this.m_lnkParametragesGantt.Text = "Gantt view settings|20159";
            this.m_lnkParametragesGantt.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkParametragesGantt_LinkClicked);
            // 
            // m_lnkProjet
            // 
            this.m_lnkProjet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_lnkProjet.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkProjet.ForeColor = System.Drawing.Color.Black;
            this.m_lnkProjet.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkProjet.LinkColor = System.Drawing.Color.Black;
            this.m_lnkProjet.Location = new System.Drawing.Point(14, 63);
            this.m_extModuleAssociator.SetModules(this.m_lnkProjet, "");
            this.m_lnkProjet.Name = "m_lnkProjet";
            this.m_lnkProjet.Size = new System.Drawing.Size(134, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkProjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkProjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkProjet.TabIndex = 14;
            this.m_lnkProjet.TabStop = true;
            this.m_lnkProjet.Text = "Projects|741";
            this.m_lnkProjet.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkProjet_LinkClicked);
            // 
            // m_lnkTypeProjet
            // 
            this.m_lnkTypeProjet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_lnkTypeProjet.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkTypeProjet.ForeColor = System.Drawing.Color.Black;
            this.m_lnkTypeProjet.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkTypeProjet.LinkColor = System.Drawing.Color.Black;
            this.m_lnkTypeProjet.Location = new System.Drawing.Point(14, 42);
            this.m_extModuleAssociator.SetModules(this.m_lnkTypeProjet, "");
            this.m_lnkTypeProjet.Name = "m_lnkTypeProjet";
            this.m_lnkTypeProjet.Size = new System.Drawing.Size(134, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTypeProjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTypeProjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTypeProjet.TabIndex = 13;
            this.m_lnkTypeProjet.TabStop = true;
            this.m_lnkTypeProjet.Text = "Project Types|1297";
            this.m_lnkTypeProjet.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTypeProjet_LinkClicked);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.SteelBlue;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Beige;
            this.label3.Location = new System.Drawing.Point(4, 4);
            this.m_extModuleAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(231, 23);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4;
            this.label3.Text = "Projects|741";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CFormMenuIngenierie
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(635, 447);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.Controls.Add(this.c2iPanelOmbre2);
            this.Controls.Add(this.c2iPanelOmbre1);
            this.m_extModuleAssociator.SetModules(this, "");
            this.Name = "CFormMenuIngenierie";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondFenetre);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "CFormMenuIngenierie";
            this.Load += new System.EventHandler(this.CFormMenuIngenierie_Load);
            this.Activated += new System.EventHandler(this.CFormMenuIngenierie_Activated);
            this.Enter += new System.EventHandler(this.CFormMenuIngenierie_Enter);
            this.c2iPanelOmbre3.ResumeLayout(false);
            this.c2iPanelOmbre3.PerformLayout();
            this.c2iPanelOmbre1.ResumeLayout(false);
            this.c2iPanelOmbre1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.c2iPanelOmbre2.ResumeLayout(false);
            this.c2iPanelOmbre2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.c2iPanelOmbre4.ResumeLayout(false);
            this.c2iPanelOmbre4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		public CFormMenuIngenierie()
		{
			InitializeComponent();
		}



		private void CFormMenuIngenierie_Load(object sender, System.EventArgs e)
		{
            m_extModuleAssociator.AppliquerConfiguration(CTimosApp.ConfigurationModules);
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
			// TODO : ajoutez l'implémentation de CFormMenuIngenierie.System.IDisposable.Dispose
		}

		#endregion



		private void CFormMenuIngenierie_Enter(object sender, System.EventArgs e)
		{
			CTimosApp.Titre = I.T("Engeneering|6");
		}

		

		private void CFormMenuIngenierie_Activated(object sender, System.EventArgs e)
		{
		}

        //*************************************************************************************
        // Versions
        //*************************************************************************************
 
        private void m_lnkVersions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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


        
        //*************************************************************************************
        // Projets
        //*************************************************************************************
        private void m_lnkTypeProjet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeTypeProjet());
        }

        private void m_lnkProjet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeProjet());
        }

        //*************************************************************************************
        // Dossiers
        //*************************************************************************************

        private void m_lnkTypeDossier_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeTypesDossierSuivi());
        }

        private void m_lnkDossiers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeDossierSuivi());
        }

		private void m_lnkCategoriesDeVersions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeCategoriesVersionsDonnees());
		}

        private void m_lnkParametragesGantt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeParametrageGantts());
        }

        private void m_lnkParametragesDessinGant_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeParametragesDessinGantt());
        }

 
    
    }

}

