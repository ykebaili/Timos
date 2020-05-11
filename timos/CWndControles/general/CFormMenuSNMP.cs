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
using timos.supervision;
using timos.snmp;
using futurocom.snmp.Proxy;

namespace timos
{
	/// <summary>
	/// Description résumée de CFormMenuSupervision.
	/// </summary>
	[DynamicForm("Snmp & Supervision")]
	public class CFormMenuSupervision : CFormMaxiSansMenu, IFormNavigable
	{
		#region Code généré par le Concepteur Windows Form

		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre3;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox m_chkSuiviDates;
        private CExtModulesAssociator m_extModuleAssociator;
        private Panel panel1;
        private Label label2;
        private LinkLabel m_lnkMibs;
        private Panel panel2;
        private Label label1;
        private LinkLabel m_lnkTypesAlarmes;
        private LinkLabel m_lnkTypeAgentSNMP;
        private LinkLabel m_lnkAgentsSnmp;
        private C2iPanelOmbre m_panelSNMP;
        private C2iPanelOmbre m_panelSupervision;
        private C2iPanelOmbre m_panelProxyConf;
        private Panel panel3;
        private Label label3;
        private LinkLabel m_lnkSnmpProxy;
        private LinkLabel m_lnkSeverite;
        private LinkLabel m_lnkParametresAffichageListeAlarmes;
        private LinkLabel m_lnkListeAlarmes;
        private LinkLabel m_lnkParametragesFiltrageAlarmes;
        private LinkLabel m_lnkCategoriesMasquage;
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_lnkAgentsSnmp = new System.Windows.Forms.LinkLabel();
            this.m_lnkTypeAgentSNMP = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.m_lnkMibs = new System.Windows.Forms.LinkLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.m_lnkSeverite = new System.Windows.Forms.LinkLabel();
            this.m_lnkListeAlarmes = new System.Windows.Forms.LinkLabel();
            this.m_lnkParametragesFiltrageAlarmes = new System.Windows.Forms.LinkLabel();
            this.m_lnkParametresAffichageListeAlarmes = new System.Windows.Forms.LinkLabel();
            this.m_lnkTypesAlarmes = new System.Windows.Forms.LinkLabel();
            this.m_panelSNMP = new sc2i.win32.common.C2iPanelOmbre();
            this.m_panelSupervision = new sc2i.win32.common.C2iPanelOmbre();
            this.m_panelProxyConf = new sc2i.win32.common.C2iPanelOmbre();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.m_lnkSnmpProxy = new System.Windows.Forms.LinkLabel();
            this.m_extModuleAssociator = new timos.CExtModulesAssociator();
            this.m_lnkCategoriesMasquage = new System.Windows.Forms.LinkLabel();
            this.c2iPanelOmbre3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.m_panelSNMP.SuspendLayout();
            this.m_panelSupervision.SuspendLayout();
            this.m_panelProxyConf.SuspendLayout();
            this.panel3.SuspendLayout();
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
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.m_lnkAgentsSnmp);
            this.panel1.Controls.Add(this.m_lnkTypeAgentSNMP);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.m_lnkMibs);
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.m_extModuleAssociator.SetModules(this.panel1, "");
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 197);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 21;
            // 
            // m_lnkAgentsSnmp
            // 
            this.m_lnkAgentsSnmp.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkAgentsSnmp.ForeColor = System.Drawing.Color.Black;
            this.m_lnkAgentsSnmp.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkAgentsSnmp.LinkColor = System.Drawing.Color.Black;
            this.m_lnkAgentsSnmp.Location = new System.Drawing.Point(14, 89);
            this.m_extModuleAssociator.SetModules(this.m_lnkAgentsSnmp, "");
            this.m_lnkAgentsSnmp.Name = "m_lnkAgentsSnmp";
            this.m_lnkAgentsSnmp.Size = new System.Drawing.Size(172, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAgentsSnmp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAgentsSnmp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAgentsSnmp.TabIndex = 12;
            this.m_lnkAgentsSnmp.TabStop = true;
            this.m_lnkAgentsSnmp.Text = "Snmp agent |20310";
            this.m_lnkAgentsSnmp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkAgentsSnmp_LinkClicked);
            // 
            // m_lnkTypeAgentSNMP
            // 
            this.m_lnkTypeAgentSNMP.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkTypeAgentSNMP.ForeColor = System.Drawing.Color.Black;
            this.m_lnkTypeAgentSNMP.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkTypeAgentSNMP.LinkColor = System.Drawing.Color.Black;
            this.m_lnkTypeAgentSNMP.Location = new System.Drawing.Point(14, 62);
            this.m_extModuleAssociator.SetModules(this.m_lnkTypeAgentSNMP, "CPARAM_SNMP");
            this.m_lnkTypeAgentSNMP.Name = "m_lnkTypeAgentSNMP";
            this.m_lnkTypeAgentSNMP.Size = new System.Drawing.Size(172, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTypeAgentSNMP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTypeAgentSNMP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTypeAgentSNMP.TabIndex = 11;
            this.m_lnkTypeAgentSNMP.TabStop = true;
            this.m_lnkTypeAgentSNMP.Text = "Snmp agent types|20278";
            this.m_lnkTypeAgentSNMP.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTypeAgentSNMP_LinkClicked);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Beige;
            this.label2.Location = new System.Drawing.Point(6, 4);
            this.m_extModuleAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 22);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4;
            this.label2.Text = "SNMP|20252";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lnkMibs
            // 
            this.m_lnkMibs.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkMibs.ForeColor = System.Drawing.Color.Black;
            this.m_lnkMibs.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkMibs.LinkColor = System.Drawing.Color.Black;
            this.m_lnkMibs.Location = new System.Drawing.Point(14, 43);
            this.m_extModuleAssociator.SetModules(this.m_lnkMibs, "CPARAM_SNMP");
            this.m_lnkMibs.Name = "m_lnkMibs";
            this.m_lnkMibs.Size = new System.Drawing.Size(172, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkMibs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkMibs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkMibs.TabIndex = 10;
            this.m_lnkMibs.TabStop = true;
            this.m_lnkMibs.Text = "Mibs|20253";
            this.m_lnkMibs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkMibs_LinkClicked);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.m_lnkSeverite);
            this.panel2.Controls.Add(this.m_lnkListeAlarmes);
            this.panel2.Controls.Add(this.m_lnkCategoriesMasquage);
            this.panel2.Controls.Add(this.m_lnkParametragesFiltrageAlarmes);
            this.panel2.Controls.Add(this.m_lnkParametresAffichageListeAlarmes);
            this.panel2.Controls.Add(this.m_lnkTypesAlarmes);
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.m_extModuleAssociator.SetModules(this.panel2, "");
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(223, 195);
            this.m_extStyle.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel2.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Beige;
            this.label1.Location = new System.Drawing.Point(6, 4);
            this.m_extModuleAssociator.SetModules(this.label1, "");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 22);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4;
            this.label1.Text = "Supervision|10285";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lnkSeverite
            // 
            this.m_lnkSeverite.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkSeverite.ForeColor = System.Drawing.Color.Black;
            this.m_lnkSeverite.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkSeverite.LinkColor = System.Drawing.Color.Black;
            this.m_lnkSeverite.Location = new System.Drawing.Point(14, 88);
            this.m_extModuleAssociator.SetModules(this.m_lnkSeverite, "CPARAM_SUPERVISION");
            this.m_lnkSeverite.Name = "m_lnkSeverite";
            this.m_lnkSeverite.Size = new System.Drawing.Size(172, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSeverite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSeverite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSeverite.TabIndex = 10;
            this.m_lnkSeverite.TabStop = true;
            this.m_lnkSeverite.Text = "Alarm Severity|10214";
            this.m_lnkSeverite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkSeverite_LinkClicked);
            // 
            // m_lnkListeAlarmes
            // 
            this.m_lnkListeAlarmes.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkListeAlarmes.ForeColor = System.Drawing.Color.Black;
            this.m_lnkListeAlarmes.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkListeAlarmes.LinkColor = System.Drawing.Color.Black;
            this.m_lnkListeAlarmes.Location = new System.Drawing.Point(14, 40);
            this.m_extModuleAssociator.SetModules(this.m_lnkListeAlarmes, "");
            this.m_lnkListeAlarmes.Name = "m_lnkListeAlarmes";
            this.m_lnkListeAlarmes.Size = new System.Drawing.Size(172, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkListeAlarmes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkListeAlarmes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkListeAlarmes.TabIndex = 10;
            this.m_lnkListeAlarmes.TabStop = true;
            this.m_lnkListeAlarmes.Text = "Alarm List|10251";
            this.m_lnkListeAlarmes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkListeAlarmes_LinkClicked);
            // 
            // m_lnkParametragesFiltrageAlarmes
            // 
            this.m_lnkParametragesFiltrageAlarmes.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkParametragesFiltrageAlarmes.ForeColor = System.Drawing.Color.Black;
            this.m_lnkParametragesFiltrageAlarmes.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkParametragesFiltrageAlarmes.LinkColor = System.Drawing.Color.Black;
            this.m_lnkParametragesFiltrageAlarmes.Location = new System.Drawing.Point(14, 148);
            this.m_extModuleAssociator.SetModules(this.m_lnkParametragesFiltrageAlarmes, "");
            this.m_lnkParametragesFiltrageAlarmes.Name = "m_lnkParametragesFiltrageAlarmes";
            this.m_lnkParametragesFiltrageAlarmes.Size = new System.Drawing.Size(172, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkParametragesFiltrageAlarmes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkParametragesFiltrageAlarmes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkParametragesFiltrageAlarmes.TabIndex = 10;
            this.m_lnkParametragesFiltrageAlarmes.TabStop = true;
            this.m_lnkParametragesFiltrageAlarmes.Text = "Alarm Filtering Settings|10299";
            this.m_lnkParametragesFiltrageAlarmes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkParametragesFiltrageAlarmes_LinkClicked);
            // 
            // m_lnkParametresAffichageListeAlarmes
            // 
            this.m_lnkParametresAffichageListeAlarmes.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkParametresAffichageListeAlarmes.ForeColor = System.Drawing.Color.Black;
            this.m_lnkParametresAffichageListeAlarmes.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkParametresAffichageListeAlarmes.LinkColor = System.Drawing.Color.Black;
            this.m_lnkParametresAffichageListeAlarmes.Location = new System.Drawing.Point(14, 117);
            this.m_extModuleAssociator.SetModules(this.m_lnkParametresAffichageListeAlarmes, "");
            this.m_lnkParametresAffichageListeAlarmes.Name = "m_lnkParametresAffichageListeAlarmes";
            this.m_lnkParametresAffichageListeAlarmes.Size = new System.Drawing.Size(172, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkParametresAffichageListeAlarmes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkParametresAffichageListeAlarmes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkParametresAffichageListeAlarmes.TabIndex = 10;
            this.m_lnkParametresAffichageListeAlarmes.TabStop = true;
            this.m_lnkParametresAffichageListeAlarmes.Text = "Alarm Display Settings|10225";
            this.m_lnkParametresAffichageListeAlarmes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkParametrageAffichageAlarmes_LinkClicked);
            // 
            // m_lnkTypesAlarmes
            // 
            this.m_lnkTypesAlarmes.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkTypesAlarmes.ForeColor = System.Drawing.Color.Black;
            this.m_lnkTypesAlarmes.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkTypesAlarmes.LinkColor = System.Drawing.Color.Black;
            this.m_lnkTypesAlarmes.Location = new System.Drawing.Point(14, 69);
            this.m_extModuleAssociator.SetModules(this.m_lnkTypesAlarmes, "CPARAM_SUPERVISION");
            this.m_lnkTypesAlarmes.Name = "m_lnkTypesAlarmes";
            this.m_lnkTypesAlarmes.Size = new System.Drawing.Size(172, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTypesAlarmes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTypesAlarmes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTypesAlarmes.TabIndex = 10;
            this.m_lnkTypesAlarmes.TabStop = true;
            this.m_lnkTypesAlarmes.Text = "Alarm Types|10258";
            this.m_lnkTypesAlarmes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTypesAlarmes_LinkClicked);
            // 
            // m_panelSNMP
            // 
            this.m_panelSNMP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelSNMP.Controls.Add(this.panel1);
            this.m_panelSNMP.ForeColor = System.Drawing.Color.Black;
            this.m_panelSNMP.Location = new System.Drawing.Point(12, 16);
            this.m_panelSNMP.LockEdition = false;
            this.m_extModuleAssociator.SetModules(this.m_panelSNMP, "ASNMP");
            this.m_panelSNMP.Name = "m_panelSNMP";
            this.m_panelSNMP.Size = new System.Drawing.Size(243, 214);
            this.m_extStyle.SetStyleBackColor(this.m_panelSNMP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelSNMP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelSNMP.TabIndex = 23;
            // 
            // m_panelSupervision
            // 
            this.m_panelSupervision.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelSupervision.Controls.Add(this.panel2);
            this.m_panelSupervision.ForeColor = System.Drawing.Color.Black;
            this.m_panelSupervision.Location = new System.Drawing.Point(273, 16);
            this.m_panelSupervision.LockEdition = false;
            this.m_extModuleAssociator.SetModules(this.m_panelSupervision, "ASUPERVISION");
            this.m_panelSupervision.Name = "m_panelSupervision";
            this.m_panelSupervision.Size = new System.Drawing.Size(243, 214);
            this.m_extStyle.SetStyleBackColor(this.m_panelSupervision, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelSupervision, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelSupervision.TabIndex = 23;
            // 
            // m_panelProxyConf
            // 
            this.m_panelProxyConf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelProxyConf.Controls.Add(this.panel3);
            this.m_panelProxyConf.ForeColor = System.Drawing.Color.Black;
            this.m_panelProxyConf.Location = new System.Drawing.Point(12, 236);
            this.m_panelProxyConf.LockEdition = false;
            this.m_extModuleAssociator.SetModules(this.m_panelProxyConf, "ASNMP");
            this.m_panelProxyConf.Name = "m_panelProxyConf";
            this.m_panelProxyConf.Size = new System.Drawing.Size(243, 214);
            this.m_extStyle.SetStyleBackColor(this.m_panelProxyConf, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelProxyConf, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelProxyConf.TabIndex = 23;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.m_lnkSnmpProxy);
            this.panel3.ForeColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.m_extModuleAssociator.SetModules(this.panel3, "");
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(223, 195);
            this.m_extStyle.SetStyleBackColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel3.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.SteelBlue;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Beige;
            this.label3.Location = new System.Drawing.Point(6, 4);
            this.m_extModuleAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 22);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4;
            this.label3.Text = "Proxy Configuration|10116";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lnkSnmpProxy
            // 
            this.m_lnkSnmpProxy.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkSnmpProxy.ForeColor = System.Drawing.Color.Black;
            this.m_lnkSnmpProxy.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkSnmpProxy.LinkColor = System.Drawing.Color.Black;
            this.m_lnkSnmpProxy.Location = new System.Drawing.Point(14, 43);
            this.m_extModuleAssociator.SetModules(this.m_lnkSnmpProxy, "CPARAM_SNMP");
            this.m_lnkSnmpProxy.Name = "m_lnkSnmpProxy";
            this.m_lnkSnmpProxy.Size = new System.Drawing.Size(200, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSnmpProxy, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSnmpProxy, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSnmpProxy.TabIndex = 10;
            this.m_lnkSnmpProxy.TabStop = true;
            this.m_lnkSnmpProxy.Text = "SNMP Proxy|10114";
            this.m_lnkSnmpProxy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkSnmpProxy_LinkClicked);
            // 
            // m_lnkCategoriesMasquage
            // 
            this.m_lnkCategoriesMasquage.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkCategoriesMasquage.ForeColor = System.Drawing.Color.Black;
            this.m_lnkCategoriesMasquage.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkCategoriesMasquage.LinkColor = System.Drawing.Color.Black;
            this.m_lnkCategoriesMasquage.Location = new System.Drawing.Point(14, 167);
            this.m_extModuleAssociator.SetModules(this.m_lnkCategoriesMasquage, "");
            this.m_lnkCategoriesMasquage.Name = "m_lnkCategoriesMasquage";
            this.m_lnkCategoriesMasquage.Size = new System.Drawing.Size(172, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkCategoriesMasquage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkCategoriesMasquage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkCategoriesMasquage.TabIndex = 10;
            this.m_lnkCategoriesMasquage.TabStop = true;
            this.m_lnkCategoriesMasquage.Text = "Masking Categories|10304";
            this.m_lnkCategoriesMasquage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkCategoriesMasquage_LinkClicked);
            // 
            // CFormMenuSupervision
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(635, 492);
            this.Controls.Add(this.m_panelProxyConf);
            this.Controls.Add(this.m_panelSupervision);
            this.Controls.Add(this.m_panelSNMP);
            this.m_extModuleAssociator.SetModules(this, "");
            this.Name = "CFormMenuSupervision";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondFenetre);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "CFormMenuSupervision";
            this.Load += new System.EventHandler(this.CFormMenuSupervision_Load);
            this.Activated += new System.EventHandler(this.CFormMenuSupervision_Activated);
            this.Enter += new System.EventHandler(this.CFormMenuSupervision_Enter);
            this.c2iPanelOmbre3.ResumeLayout(false);
            this.c2iPanelOmbre3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.m_panelSNMP.ResumeLayout(false);
            this.m_panelSNMP.PerformLayout();
            this.m_panelSupervision.ResumeLayout(false);
            this.m_panelSupervision.PerformLayout();
            this.m_panelProxyConf.ResumeLayout(false);
            this.m_panelProxyConf.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		public CFormMenuSupervision()
		{
			InitializeComponent();
		}



		private void CFormMenuSupervision_Load(object sender, System.EventArgs e)
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
			// TODO : ajoutez l'implémentation de CFormMenuSupervision.System.IDisposable.Dispose
		}

		#endregion



		private void CFormMenuSupervision_Enter(object sender, System.EventArgs e)
		{
			CTimosApp.Titre = I.T("SNMP and Supervision|10287");
		}

		

		private void CFormMenuSupervision_Activated(object sender, System.EventArgs e)
		{
		}

        private void m_lnkMibs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeSnmpMibs());
        }

        private void m_lnkTypesAlarmes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeTypeAlarmes());
        }

        private void m_lnkTypeAgentSNMP_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeTypeAgentSnmps());
        }

        private void m_lnkAgentsSnmp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeAgentSnmps());
        }

        private void m_lnkSnmpProxy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeProxySnmp());
        }

        // Test à supprimer
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CPlageIP plage1 = new CPlageIP(new System.Net.IPAddress(new byte[] { 172, 16, 1, 13 }), 7);
            MessageBox.Show("Mask = " + plage1.MaskComplet.ToString());

            bool bResult = plage1.Match(new System.Net.IPAddress(new Byte[] { 172, 16, 1, 20 }));

            MessageBox.Show("Routage = " + bResult.ToString());

        }

        private void m_lnkSeverite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeSeveriteAlarme());
        }

        private void m_lnkParametrageAffichageAlarmes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeParametrageAffichageAlarmes());
        }

        private void m_lnkListeAlarmes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeAlarmes());
        }

        private void m_lnkParametragesFiltrageAlarmes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeParametrageFiltrageAlarmes());
        }

        private void m_lnkCategoriesMasquage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeCategorieMasquageAlarme());
        }

 
    
    }

}

