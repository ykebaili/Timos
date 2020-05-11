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

using timos.data;
using sc2i.win32.common;
using sc2i.win32.data.dynamic.StructureImport;
using timos.Parametrage.ConsultationHierarchique;
using timos.Parametrage;
using sc2i.win32.data.dynamic.formulesglobale;
using sc2i.win32.data.dynamic.unites;
using timos.process.workflow;
using timos.macro;
using timos.Properties;

namespace timos
{
	/// <summary>
	/// Description résumée de CFormMenuConfiguration.
	/// </summary>
	[DynamicForm("Configuration")]
	public class CFormMenuConfiguration : CFormMaxiSansMenu, IFormNavigable
	{
		#region Code généré par le Concepteur Windows Form

		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre3;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox m_chkSuiviDates;
        private sc2i.win32.common.C2iPanelOmbre m_panStructureDonnees;
        private Panel m_panStructureDonnees_2;
        private Label m_lblStructureDonnees;
        private LinkLabel m_lnkTableParametrable;
        private LinkLabel m_lnkTypeTable;
        private LinkLabel m_lnkStructuresExport;
        private LinkLabel m_lnkVariables;
        private LinkLabel m_lnkChampsCalcules;
        private LinkLabel m_lnkChamps;
        private LinkLabel m_lnkTypeDonneeCumulee;
        private sc2i.win32.common.C2iPanelOmbre m_panProcess;
        private Panel m_panProcess_2;
        private Label m_lblProcess;
        private LinkLabel m_lnkComportements;
        private LinkLabel m_lnkTachesPlanifiees;
        private LinkLabel m_lnkEvenements;
        private LinkLabel m_lnkProcess;
        private LinkLabel m_lnkGroupesParametrage;
        private sc2i.win32.common.C2iPanelOmbre m_panInterface;
        private Panel m_panInterface_2;
        private Label m_lblInterface;
        private LinkLabel m_lnkListes;
        private LinkLabel m_lnkFiltres;
        private LinkLabel m_lnkFormulaires;
        private LinkLabel m_lnkModelesDeTexte;
        private sc2i.win32.common.C2iPanelOmbre m_panDivers;
        private Panel m_panDivers_2;
        private Label m_lblDivers;
        private LinkLabel m_lnkGrilles;
        private LinkLabel m_lnkCategoriesRapports;
        private LinkLabel m_lnkCategorieGED;
        private LinkLabel m_lnkModeleDeRapport;
        private LinkLabel m_lnkGED;
		private LinkLabel m_lnkTypesCaracteristiques;
        private CExtModulesAssociator m_extModuleAssociator;
        private LinkLabel m_lblFavouriteForm;
		private LinkLabel m_lnkConsultationsHierarchiques;
        private LinkLabel m_lknkFiltreRapide;
        private LinkLabel m_lnkModulesParametrage;
        private LinkLabel m_lnkNavigationGED;
        private Panel m_panTools_2;
        private Label label1;
        private LinkLabel m_lnkImporterDonnees;
        private C2iPanelOmbre m_panTools;
        private LinkLabel m_lnkNommageEntite;
        private Panel panel1;
        private Label label2;
        private LinkLabel m_lnkMibs;
        private LinkLabel m_lnkSequences;
        private LinkLabel m_lnkFormulesGlobales;
        private LinkLabel m_linkComptesMail;
        private LinkLabel m_lnkDossiersMail;
        private LinkLabel m_lnkGestionDesUnites;
        private LinkLabel m_lnkTypesWorkflows;
        private LinkLabel m_lnkWorkflows;
        private LinkLabel m_lnkEtapesWorkflow;
        private LinkLabel m_lnkMacros;
        private LinkLabel m_lnkEasyQueries;
        private LinkLabel m_lnkConfigurationsCartes;
        private LinkLabel m_lnkFonctionsDynamiques;


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
            this.m_panStructureDonnees = new sc2i.win32.common.C2iPanelOmbre();
            this.m_panStructureDonnees_2 = new System.Windows.Forms.Panel();
            this.m_lnkEasyQueries = new System.Windows.Forms.LinkLabel();
            this.m_lnkTypesCaracteristiques = new System.Windows.Forms.LinkLabel();
            this.m_lblStructureDonnees = new System.Windows.Forms.Label();
            this.m_lnkTableParametrable = new System.Windows.Forms.LinkLabel();
            this.m_lnkTypeTable = new System.Windows.Forms.LinkLabel();
            this.m_lnkStructuresExport = new System.Windows.Forms.LinkLabel();
            this.m_lnkVariables = new System.Windows.Forms.LinkLabel();
            this.m_lnkChampsCalcules = new System.Windows.Forms.LinkLabel();
            this.m_lnkChamps = new System.Windows.Forms.LinkLabel();
            this.m_lnkTypeDonneeCumulee = new System.Windows.Forms.LinkLabel();
            this.m_lnkModulesParametrage = new System.Windows.Forms.LinkLabel();
            this.m_panProcess = new sc2i.win32.common.C2iPanelOmbre();
            this.m_panProcess_2 = new System.Windows.Forms.Panel();
            this.m_lnkMacros = new System.Windows.Forms.LinkLabel();
            this.m_lnkEtapesWorkflow = new System.Windows.Forms.LinkLabel();
            this.m_lnkWorkflows = new System.Windows.Forms.LinkLabel();
            this.m_lnkTypesWorkflows = new System.Windows.Forms.LinkLabel();
            this.m_lblProcess = new System.Windows.Forms.Label();
            this.m_lnkComportements = new System.Windows.Forms.LinkLabel();
            this.m_lnkTachesPlanifiees = new System.Windows.Forms.LinkLabel();
            this.m_lnkEvenements = new System.Windows.Forms.LinkLabel();
            this.m_lnkProcess = new System.Windows.Forms.LinkLabel();
            this.m_lnkGroupesParametrage = new System.Windows.Forms.LinkLabel();
            this.m_panInterface = new sc2i.win32.common.C2iPanelOmbre();
            this.m_panInterface_2 = new System.Windows.Forms.Panel();
            this.m_lnkConfigurationsCartes = new System.Windows.Forms.LinkLabel();
            this.m_lknkFiltreRapide = new System.Windows.Forms.LinkLabel();
            this.m_lnkConsultationsHierarchiques = new System.Windows.Forms.LinkLabel();
            this.m_lblInterface = new System.Windows.Forms.Label();
            this.m_lnkListes = new System.Windows.Forms.LinkLabel();
            this.m_lnkFiltres = new System.Windows.Forms.LinkLabel();
            this.m_lblFavouriteForm = new System.Windows.Forms.LinkLabel();
            this.m_lnkFormulaires = new System.Windows.Forms.LinkLabel();
            this.m_lnkModelesDeTexte = new System.Windows.Forms.LinkLabel();
            this.m_panDivers = new sc2i.win32.common.C2iPanelOmbre();
            this.m_panDivers_2 = new System.Windows.Forms.Panel();
            this.m_lblDivers = new System.Windows.Forms.Label();
            this.m_lnkCategoriesRapports = new System.Windows.Forms.LinkLabel();
            this.m_lnkNavigationGED = new System.Windows.Forms.LinkLabel();
            this.m_lnkGED = new System.Windows.Forms.LinkLabel();
            this.m_lnkCategorieGED = new System.Windows.Forms.LinkLabel();
            this.m_lnkDossiersMail = new System.Windows.Forms.LinkLabel();
            this.m_linkComptesMail = new System.Windows.Forms.LinkLabel();
            this.m_lnkModeleDeRapport = new System.Windows.Forms.LinkLabel();
            this.m_lnkSequences = new System.Windows.Forms.LinkLabel();
            this.m_lnkGrilles = new System.Windows.Forms.LinkLabel();
            this.m_panTools_2 = new System.Windows.Forms.Panel();
            this.m_lnkGestionDesUnites = new System.Windows.Forms.LinkLabel();
            this.m_lnkFormulesGlobales = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.m_lnkImporterDonnees = new System.Windows.Forms.LinkLabel();
            this.m_lnkNommageEntite = new System.Windows.Forms.LinkLabel();
            this.m_panTools = new sc2i.win32.common.C2iPanelOmbre();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.m_lnkMibs = new System.Windows.Forms.LinkLabel();
            this.m_extModuleAssociator = new timos.CExtModulesAssociator();
            this.m_lnkFonctionsDynamiques = new System.Windows.Forms.LinkLabel();
            this.c2iPanelOmbre3.SuspendLayout();
            this.m_panStructureDonnees.SuspendLayout();
            this.m_panStructureDonnees_2.SuspendLayout();
            this.m_panProcess.SuspendLayout();
            this.m_panProcess_2.SuspendLayout();
            this.m_panInterface.SuspendLayout();
            this.m_panInterface_2.SuspendLayout();
            this.m_panDivers.SuspendLayout();
            this.m_panDivers_2.SuspendLayout();
            this.m_panTools_2.SuspendLayout();
            this.m_panTools.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.m_chkSuiviDates.Text = "Date reporting";
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
            this.label4.Text = "Miscellaneous";
            // 
            // m_panStructureDonnees
            // 
            this.m_panStructureDonnees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panStructureDonnees.Controls.Add(this.m_panStructureDonnees_2);
            this.m_panStructureDonnees.ForeColor = System.Drawing.Color.Black;
            this.m_panStructureDonnees.Location = new System.Drawing.Point(12, 12);
            this.m_panStructureDonnees.LockEdition = false;
            this.m_extModuleAssociator.SetModules(this.m_panStructureDonnees, "");
            this.m_panStructureDonnees.Name = "m_panStructureDonnees";
            this.m_panStructureDonnees.Size = new System.Drawing.Size(233, 250);
            this.m_extStyle.SetStyleBackColor(this.m_panStructureDonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panStructureDonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panStructureDonnees.TabIndex = 11;
            // 
            // m_panStructureDonnees_2
            // 
            this.m_panStructureDonnees_2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panStructureDonnees_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panStructureDonnees_2.Controls.Add(this.m_lnkEasyQueries);
            this.m_panStructureDonnees_2.Controls.Add(this.m_lnkTypesCaracteristiques);
            this.m_panStructureDonnees_2.Controls.Add(this.m_lblStructureDonnees);
            this.m_panStructureDonnees_2.Controls.Add(this.m_lnkTableParametrable);
            this.m_panStructureDonnees_2.Controls.Add(this.m_lnkTypeTable);
            this.m_panStructureDonnees_2.Controls.Add(this.m_lnkStructuresExport);
            this.m_panStructureDonnees_2.Controls.Add(this.m_lnkVariables);
            this.m_panStructureDonnees_2.Controls.Add(this.m_lnkFonctionsDynamiques);
            this.m_panStructureDonnees_2.Controls.Add(this.m_lnkChampsCalcules);
            this.m_panStructureDonnees_2.Controls.Add(this.m_lnkChamps);
            this.m_panStructureDonnees_2.Controls.Add(this.m_lnkTypeDonneeCumulee);
            this.m_panStructureDonnees_2.ForeColor = System.Drawing.Color.Black;
            this.m_panStructureDonnees_2.Location = new System.Drawing.Point(0, 0);
            this.m_extModuleAssociator.SetModules(this.m_panStructureDonnees_2, "");
            this.m_panStructureDonnees_2.Name = "m_panStructureDonnees_2";
            this.m_panStructureDonnees_2.Size = new System.Drawing.Size(217, 234);
            this.m_extStyle.SetStyleBackColor(this.m_panStructureDonnees_2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panStructureDonnees_2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panStructureDonnees_2.TabIndex = 11;
            // 
            // m_lnkEasyQueries
            // 
            this.m_lnkEasyQueries.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkEasyQueries.ForeColor = System.Drawing.Color.Black;
            this.m_lnkEasyQueries.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkEasyQueries.LinkColor = System.Drawing.Color.Black;
            this.m_lnkEasyQueries.Location = new System.Drawing.Point(12, 137);
            this.m_extModuleAssociator.SetModules(this.m_lnkEasyQueries, "");
            this.m_lnkEasyQueries.Name = "m_lnkEasyQueries";
            this.m_lnkEasyQueries.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkEasyQueries, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkEasyQueries, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkEasyQueries.TabIndex = 11;
            this.m_lnkEasyQueries.TabStop = true;
            this.m_lnkEasyQueries.Text = "Stored queries|20757";
            this.m_lnkEasyQueries.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkEasyQueries_LinkClicked);
            // 
            // m_lnkTypesCaracteristiques
            // 
            this.m_lnkTypesCaracteristiques.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkTypesCaracteristiques.ForeColor = System.Drawing.Color.Black;
            this.m_lnkTypesCaracteristiques.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkTypesCaracteristiques.LinkColor = System.Drawing.Color.Black;
            this.m_lnkTypesCaracteristiques.Location = new System.Drawing.Point(12, 96);
            this.m_extModuleAssociator.SetModules(this.m_lnkTypesCaracteristiques, "");
            this.m_lnkTypesCaracteristiques.Name = "m_lnkTypesCaracteristiques";
            this.m_lnkTypesCaracteristiques.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTypesCaracteristiques, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTypesCaracteristiques, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTypesCaracteristiques.TabIndex = 10;
            this.m_lnkTypesCaracteristiques.TabStop = true;
            this.m_lnkTypesCaracteristiques.Text = "Characteristic types|20040";
            this.m_lnkTypesCaracteristiques.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTypesCaracteristiques_LinkClicked);
            // 
            // m_lblStructureDonnees
            // 
            this.m_lblStructureDonnees.BackColor = System.Drawing.Color.SteelBlue;
            this.m_lblStructureDonnees.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblStructureDonnees.ForeColor = System.Drawing.Color.Beige;
            this.m_lblStructureDonnees.Location = new System.Drawing.Point(4, 4);
            this.m_extModuleAssociator.SetModules(this.m_lblStructureDonnees, "");
            this.m_lblStructureDonnees.Name = "m_lblStructureDonnees";
            this.m_lblStructureDonnees.Size = new System.Drawing.Size(206, 22);
            this.m_extStyle.SetStyleBackColor(this.m_lblStructureDonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblStructureDonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblStructureDonnees.TabIndex = 4;
            this.m_lblStructureDonnees.Text = "Data structures|100";
            this.m_lblStructureDonnees.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lnkTableParametrable
            // 
            this.m_lnkTableParametrable.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkTableParametrable.ForeColor = System.Drawing.Color.Black;
            this.m_lnkTableParametrable.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkTableParametrable.LinkColor = System.Drawing.Color.Black;
            this.m_lnkTableParametrable.Location = new System.Drawing.Point(12, 188);
            this.m_extModuleAssociator.SetModules(this.m_lnkTableParametrable, "ATABLES_PARAM");
            this.m_lnkTableParametrable.Name = "m_lnkTableParametrable";
            this.m_lnkTableParametrable.Size = new System.Drawing.Size(182, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTableParametrable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTableParametrable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTableParametrable.TabIndex = 8;
            this.m_lnkTableParametrable.TabStop = true;
            this.m_lnkTableParametrable.Text = "Custom Tables|1195";
            this.m_lnkTableParametrable.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTableParametrable_LinkClicked);
            // 
            // m_lnkTypeTable
            // 
            this.m_lnkTypeTable.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkTypeTable.ForeColor = System.Drawing.Color.Black;
            this.m_lnkTypeTable.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkTypeTable.LinkColor = System.Drawing.Color.Black;
            this.m_lnkTypeTable.Location = new System.Drawing.Point(12, 172);
            this.m_extModuleAssociator.SetModules(this.m_lnkTypeTable, "ATABLES_PARAM");
            this.m_lnkTypeTable.Name = "m_lnkTypeTable";
            this.m_lnkTypeTable.Size = new System.Drawing.Size(182, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTypeTable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTypeTable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTypeTable.TabIndex = 8;
            this.m_lnkTypeTable.TabStop = true;
            this.m_lnkTypeTable.Text = "Custom table Types|1194";
            this.m_lnkTypeTable.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTypeTable_LinkClicked);
            // 
            // m_lnkStructuresExport
            // 
            this.m_lnkStructuresExport.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkStructuresExport.ForeColor = System.Drawing.Color.Black;
            this.m_lnkStructuresExport.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkStructuresExport.LinkColor = System.Drawing.Color.Black;
            this.m_lnkStructuresExport.Location = new System.Drawing.Point(12, 122);
            this.m_extModuleAssociator.SetModules(this.m_lnkStructuresExport, "");
            this.m_lnkStructuresExport.Name = "m_lnkStructuresExport";
            this.m_lnkStructuresExport.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkStructuresExport, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkStructuresExport, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkStructuresExport.TabIndex = 8;
            this.m_lnkStructuresExport.TabStop = true;
            this.m_lnkStructuresExport.Text = "Export structures|104";
            this.m_lnkStructuresExport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkStructuresExport_LinkClicked);
            // 
            // m_lnkVariables
            // 
            this.m_lnkVariables.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkVariables.ForeColor = System.Drawing.Color.Black;
            this.m_lnkVariables.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkVariables.LinkColor = System.Drawing.Color.Black;
            this.m_lnkVariables.Location = new System.Drawing.Point(12, 81);
            this.m_extModuleAssociator.SetModules(this.m_lnkVariables, "");
            this.m_lnkVariables.Name = "m_lnkVariables";
            this.m_lnkVariables.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkVariables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkVariables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkVariables.TabIndex = 7;
            this.m_lnkVariables.TabStop = true;
            this.m_lnkVariables.Text = "Variables|103";
            this.m_lnkVariables.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkVariables_LinkClicked);
            // 
            // m_lnkChampsCalcules
            // 
            this.m_lnkChampsCalcules.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkChampsCalcules.ForeColor = System.Drawing.Color.Black;
            this.m_lnkChampsCalcules.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkChampsCalcules.LinkColor = System.Drawing.Color.Black;
            this.m_lnkChampsCalcules.Location = new System.Drawing.Point(12, 51);
            this.m_extModuleAssociator.SetModules(this.m_lnkChampsCalcules, "");
            this.m_lnkChampsCalcules.Name = "m_lnkChampsCalcules";
            this.m_lnkChampsCalcules.Size = new System.Drawing.Size(144, 11);
            this.m_extStyle.SetStyleBackColor(this.m_lnkChampsCalcules, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkChampsCalcules, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkChampsCalcules.TabIndex = 0;
            this.m_lnkChampsCalcules.TabStop = true;
            this.m_lnkChampsCalcules.Text = "Calculated fields|102";
            this.m_lnkChampsCalcules.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkChampsCalcules_LinkClicked);
            // 
            // m_lnkChamps
            // 
            this.m_lnkChamps.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkChamps.ForeColor = System.Drawing.Color.Black;
            this.m_lnkChamps.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkChamps.LinkColor = System.Drawing.Color.Black;
            this.m_lnkChamps.Location = new System.Drawing.Point(12, 35);
            this.m_extModuleAssociator.SetModules(this.m_lnkChamps, "");
            this.m_lnkChamps.Name = "m_lnkChamps";
            this.m_lnkChamps.Size = new System.Drawing.Size(144, 11);
            this.m_extStyle.SetStyleBackColor(this.m_lnkChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkChamps.TabIndex = 6;
            this.m_lnkChamps.TabStop = true;
            this.m_lnkChamps.Text = "Custom fields|101";
            this.m_lnkChamps.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkChamps_LinkClicked);
            // 
            // m_lnkTypeDonneeCumulee
            // 
            this.m_lnkTypeDonneeCumulee.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkTypeDonneeCumulee.ForeColor = System.Drawing.Color.Black;
            this.m_lnkTypeDonneeCumulee.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkTypeDonneeCumulee.LinkColor = System.Drawing.Color.Black;
            this.m_lnkTypeDonneeCumulee.Location = new System.Drawing.Point(12, 152);
            this.m_extModuleAssociator.SetModules(this.m_lnkTypeDonneeCumulee, "");
            this.m_lnkTypeDonneeCumulee.Name = "m_lnkTypeDonneeCumulee";
            this.m_lnkTypeDonneeCumulee.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTypeDonneeCumulee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTypeDonneeCumulee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTypeDonneeCumulee.TabIndex = 9;
            this.m_lnkTypeDonneeCumulee.TabStop = true;
            this.m_lnkTypeDonneeCumulee.Text = "Precalculated data|181";
            this.m_lnkTypeDonneeCumulee.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTypeDonneeCumulee_LinkClicked);
            // 
            // m_lnkModulesParametrage
            // 
            this.m_lnkModulesParametrage.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkModulesParametrage.ForeColor = System.Drawing.Color.Black;
            this.m_lnkModulesParametrage.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkModulesParametrage.LinkColor = System.Drawing.Color.Black;
            this.m_lnkModulesParametrage.Location = new System.Drawing.Point(14, 80);
            this.m_extModuleAssociator.SetModules(this.m_lnkModulesParametrage, "");
            this.m_lnkModulesParametrage.Name = "m_lnkModulesParametrage";
            this.m_lnkModulesParametrage.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkModulesParametrage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkModulesParametrage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkModulesParametrage.TabIndex = 6;
            this.m_lnkModulesParametrage.TabStop = true;
            this.m_lnkModulesParametrage.Text = "Setting Modules|10039";
            this.m_lnkModulesParametrage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkModulesParametrage_LinkClicked);
            // 
            // m_panProcess
            // 
            this.m_panProcess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panProcess.Controls.Add(this.m_panProcess_2);
            this.m_panProcess.Location = new System.Drawing.Point(278, 12);
            this.m_panProcess.LockEdition = false;
            this.m_extModuleAssociator.SetModules(this.m_panProcess, "");
            this.m_panProcess.Name = "m_panProcess";
            this.m_panProcess.Size = new System.Drawing.Size(233, 250);
            this.m_extStyle.SetStyleBackColor(this.m_panProcess, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panProcess, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panProcess.TabIndex = 15;
            // 
            // m_panProcess_2
            // 
            this.m_panProcess_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panProcess_2.Controls.Add(this.m_lnkMacros);
            this.m_panProcess_2.Controls.Add(this.m_lnkEtapesWorkflow);
            this.m_panProcess_2.Controls.Add(this.m_lnkWorkflows);
            this.m_panProcess_2.Controls.Add(this.m_lnkTypesWorkflows);
            this.m_panProcess_2.Controls.Add(this.m_lblProcess);
            this.m_panProcess_2.Controls.Add(this.m_lnkComportements);
            this.m_panProcess_2.Controls.Add(this.m_lnkTachesPlanifiees);
            this.m_panProcess_2.Controls.Add(this.m_lnkEvenements);
            this.m_panProcess_2.Controls.Add(this.m_lnkProcess);
            this.m_panProcess_2.Controls.Add(this.m_lnkGroupesParametrage);
            this.m_panProcess_2.ForeColor = System.Drawing.Color.Black;
            this.m_panProcess_2.Location = new System.Drawing.Point(0, 0);
            this.m_extModuleAssociator.SetModules(this.m_panProcess_2, "");
            this.m_panProcess_2.Name = "m_panProcess_2";
            this.m_panProcess_2.Size = new System.Drawing.Size(217, 232);
            this.m_extStyle.SetStyleBackColor(this.m_panProcess_2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panProcess_2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panProcess_2.TabIndex = 11;
            // 
            // m_lnkMacros
            // 
            this.m_lnkMacros.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkMacros.ForeColor = System.Drawing.Color.Black;
            this.m_lnkMacros.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkMacros.LinkColor = System.Drawing.Color.Black;
            this.m_lnkMacros.Location = new System.Drawing.Point(14, 121);
            this.m_extModuleAssociator.SetModules(this.m_lnkMacros, "");
            this.m_lnkMacros.Name = "m_lnkMacros";
            this.m_lnkMacros.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkMacros, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkMacros, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkMacros.TabIndex = 14;
            this.m_lnkMacros.TabStop = true;
            this.m_lnkMacros.Text = "Macros|20643";
            this.m_lnkMacros.Visible = false;
            this.m_lnkMacros.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkMacros_LinkClicked);
            // 
            // m_lnkEtapesWorkflow
            // 
            this.m_lnkEtapesWorkflow.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkEtapesWorkflow.ForeColor = System.Drawing.Color.Black;
            this.m_lnkEtapesWorkflow.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkEtapesWorkflow.LinkColor = System.Drawing.Color.Black;
            this.m_lnkEtapesWorkflow.Location = new System.Drawing.Point(14, 199);
            this.m_extModuleAssociator.SetModules(this.m_lnkEtapesWorkflow, "AWORKFLOW");
            this.m_lnkEtapesWorkflow.Name = "m_lnkEtapesWorkflow";
            this.m_lnkEtapesWorkflow.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkEtapesWorkflow, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkEtapesWorkflow, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkEtapesWorkflow.TabIndex = 13;
            this.m_lnkEtapesWorkflow.TabStop = true;
            this.m_lnkEtapesWorkflow.Text = "Workflows steps|20615";
            this.m_lnkEtapesWorkflow.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkEtapesWorkflow_LinkClicked);
            // 
            // m_lnkWorkflows
            // 
            this.m_lnkWorkflows.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkWorkflows.ForeColor = System.Drawing.Color.Black;
            this.m_lnkWorkflows.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkWorkflows.LinkColor = System.Drawing.Color.Black;
            this.m_lnkWorkflows.Location = new System.Drawing.Point(14, 184);
            this.m_extModuleAssociator.SetModules(this.m_lnkWorkflows, "AWORKFLOW");
            this.m_lnkWorkflows.Name = "m_lnkWorkflows";
            this.m_lnkWorkflows.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkWorkflows, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkWorkflows, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkWorkflows.TabIndex = 12;
            this.m_lnkWorkflows.TabStop = true;
            this.m_lnkWorkflows.Text = "Workflows|20555";
            this.m_lnkWorkflows.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkWorkflows_LinkClicked);
            // 
            // m_lnkTypesWorkflows
            // 
            this.m_lnkTypesWorkflows.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkTypesWorkflows.ForeColor = System.Drawing.Color.Black;
            this.m_lnkTypesWorkflows.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkTypesWorkflows.LinkColor = System.Drawing.Color.Black;
            this.m_lnkTypesWorkflows.Location = new System.Drawing.Point(14, 168);
            this.m_extModuleAssociator.SetModules(this.m_lnkTypesWorkflows, "AWORKFLOW;CTYPE_WORKFLOW");
            this.m_lnkTypesWorkflows.Name = "m_lnkTypesWorkflows";
            this.m_lnkTypesWorkflows.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTypesWorkflows, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTypesWorkflows, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTypesWorkflows.TabIndex = 11;
            this.m_lnkTypesWorkflows.TabStop = true;
            this.m_lnkTypesWorkflows.Text = "Workflow types|20628";
            this.m_lnkTypesWorkflows.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTypesWorkflows_LinkClicked);
            // 
            // m_lblProcess
            // 
            this.m_lblProcess.BackColor = System.Drawing.Color.SteelBlue;
            this.m_lblProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblProcess.ForeColor = System.Drawing.Color.Beige;
            this.m_lblProcess.Location = new System.Drawing.Point(4, 4);
            this.m_extModuleAssociator.SetModules(this.m_lblProcess, "");
            this.m_lblProcess.Name = "m_lblProcess";
            this.m_lblProcess.Size = new System.Drawing.Size(208, 22);
            this.m_extStyle.SetStyleBackColor(this.m_lblProcess, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblProcess, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblProcess.TabIndex = 4;
            this.m_lblProcess.Text = "Process|721";
            this.m_lblProcess.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lnkComportements
            // 
            this.m_lnkComportements.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkComportements.ForeColor = System.Drawing.Color.Black;
            this.m_lnkComportements.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkComportements.LinkColor = System.Drawing.Color.Black;
            this.m_lnkComportements.Location = new System.Drawing.Point(14, 61);
            this.m_extModuleAssociator.SetModules(this.m_lnkComportements, "");
            this.m_lnkComportements.Name = "m_lnkComportements";
            this.m_lnkComportements.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkComportements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkComportements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkComportements.TabIndex = 8;
            this.m_lnkComportements.TabStop = true;
            this.m_lnkComportements.Text = "Behaviours|184";
            this.m_lnkComportements.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkComportements_LinkClicked);
            // 
            // m_lnkTachesPlanifiees
            // 
            this.m_lnkTachesPlanifiees.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkTachesPlanifiees.ForeColor = System.Drawing.Color.Black;
            this.m_lnkTachesPlanifiees.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkTachesPlanifiees.LinkColor = System.Drawing.Color.Black;
            this.m_lnkTachesPlanifiees.Location = new System.Drawing.Point(14, 142);
            this.m_extModuleAssociator.SetModules(this.m_lnkTachesPlanifiees, "");
            this.m_lnkTachesPlanifiees.Name = "m_lnkTachesPlanifiees";
            this.m_lnkTachesPlanifiees.Size = new System.Drawing.Size(163, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTachesPlanifiees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTachesPlanifiees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTachesPlanifiees.TabIndex = 9;
            this.m_lnkTachesPlanifiees.TabStop = true;
            this.m_lnkTachesPlanifiees.Text = "Planned tasks|185";
            this.m_lnkTachesPlanifiees.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTachesPlanifiees_LinkClicked);
            // 
            // m_lnkEvenements
            // 
            this.m_lnkEvenements.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkEvenements.ForeColor = System.Drawing.Color.Black;
            this.m_lnkEvenements.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkEvenements.LinkColor = System.Drawing.Color.Black;
            this.m_lnkEvenements.Location = new System.Drawing.Point(14, 102);
            this.m_extModuleAssociator.SetModules(this.m_lnkEvenements, "");
            this.m_lnkEvenements.Name = "m_lnkEvenements";
            this.m_lnkEvenements.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkEvenements.TabIndex = 7;
            this.m_lnkEvenements.TabStop = true;
            this.m_lnkEvenements.Text = "Events|183";
            this.m_lnkEvenements.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkEvenements_LinkClicked);
            // 
            // m_lnkProcess
            // 
            this.m_lnkProcess.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkProcess.ForeColor = System.Drawing.Color.Black;
            this.m_lnkProcess.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkProcess.LinkColor = System.Drawing.Color.Black;
            this.m_lnkProcess.Location = new System.Drawing.Point(14, 84);
            this.m_extModuleAssociator.SetModules(this.m_lnkProcess, "");
            this.m_lnkProcess.Name = "m_lnkProcess";
            this.m_lnkProcess.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkProcess, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkProcess, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkProcess.TabIndex = 6;
            this.m_lnkProcess.TabStop = true;
            this.m_lnkProcess.Text = "Process|182";
            this.m_lnkProcess.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkProcess_LinkClicked);
            // 
            // m_lnkGroupesParametrage
            // 
            this.m_lnkGroupesParametrage.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkGroupesParametrage.ForeColor = System.Drawing.Color.Black;
            this.m_lnkGroupesParametrage.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkGroupesParametrage.LinkColor = System.Drawing.Color.Black;
            this.m_lnkGroupesParametrage.Location = new System.Drawing.Point(14, 43);
            this.m_extModuleAssociator.SetModules(this.m_lnkGroupesParametrage, "");
            this.m_lnkGroupesParametrage.Name = "m_lnkGroupesParametrage";
            this.m_lnkGroupesParametrage.Size = new System.Drawing.Size(172, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkGroupesParametrage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkGroupesParametrage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkGroupesParametrage.TabIndex = 10;
            this.m_lnkGroupesParametrage.TabStop = true;
            this.m_lnkGroupesParametrage.Text = "Setup groups|186";
            this.m_lnkGroupesParametrage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkGroupesParametrage_LinkClicked);
            // 
            // m_panInterface
            // 
            this.m_panInterface.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panInterface.Controls.Add(this.m_panInterface_2);
            this.m_panInterface.Location = new System.Drawing.Point(12, 268);
            this.m_panInterface.LockEdition = false;
            this.m_extModuleAssociator.SetModules(this.m_panInterface, "");
            this.m_panInterface.Name = "m_panInterface";
            this.m_panInterface.Size = new System.Drawing.Size(233, 234);
            this.m_extStyle.SetStyleBackColor(this.m_panInterface, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panInterface, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panInterface.TabIndex = 16;
            // 
            // m_panInterface_2
            // 
            this.m_panInterface_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panInterface_2.Controls.Add(this.m_lnkConfigurationsCartes);
            this.m_panInterface_2.Controls.Add(this.m_lknkFiltreRapide);
            this.m_panInterface_2.Controls.Add(this.m_lnkConsultationsHierarchiques);
            this.m_panInterface_2.Controls.Add(this.m_lblInterface);
            this.m_panInterface_2.Controls.Add(this.m_lnkListes);
            this.m_panInterface_2.Controls.Add(this.m_lnkFiltres);
            this.m_panInterface_2.Controls.Add(this.m_lblFavouriteForm);
            this.m_panInterface_2.Controls.Add(this.m_lnkFormulaires);
            this.m_panInterface_2.Controls.Add(this.m_lnkModelesDeTexte);
            this.m_panInterface_2.ForeColor = System.Drawing.Color.Black;
            this.m_panInterface_2.Location = new System.Drawing.Point(0, 0);
            this.m_extModuleAssociator.SetModules(this.m_panInterface_2, "");
            this.m_panInterface_2.Name = "m_panInterface_2";
            this.m_panInterface_2.Size = new System.Drawing.Size(217, 218);
            this.m_extStyle.SetStyleBackColor(this.m_panInterface_2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panInterface_2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panInterface_2.TabIndex = 11;
            // 
            // m_lnkConfigurationsCartes
            // 
            this.m_lnkConfigurationsCartes.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkConfigurationsCartes.ForeColor = System.Drawing.Color.Black;
            this.m_lnkConfigurationsCartes.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkConfigurationsCartes.LinkColor = System.Drawing.Color.Black;
            this.m_lnkConfigurationsCartes.Location = new System.Drawing.Point(12, 183);
            this.m_extModuleAssociator.SetModules(this.m_lnkConfigurationsCartes, "");
            this.m_lnkConfigurationsCartes.Name = "m_lnkConfigurationsCartes";
            this.m_lnkConfigurationsCartes.Size = new System.Drawing.Size(198, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lnkConfigurationsCartes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkConfigurationsCartes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkConfigurationsCartes.TabIndex = 13;
            this.m_lnkConfigurationsCartes.TabStop = true;
            this.m_lnkConfigurationsCartes.Text = "Maps setups|20840";
            this.m_lnkConfigurationsCartes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkConfigurationsCartes_LinkClicked);
            // 
            // m_lknkFiltreRapide
            // 
            this.m_lknkFiltreRapide.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lknkFiltreRapide.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lknkFiltreRapide.LinkColor = System.Drawing.Color.Black;
            this.m_lknkFiltreRapide.Location = new System.Drawing.Point(12, 95);
            this.m_extModuleAssociator.SetModules(this.m_lknkFiltreRapide, "");
            this.m_lknkFiltreRapide.Name = "m_lknkFiltreRapide";
            this.m_lknkFiltreRapide.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lknkFiltreRapide, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lknkFiltreRapide, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lknkFiltreRapide.TabIndex = 12;
            this.m_lknkFiltreRapide.TabStop = true;
            this.m_lknkFiltreRapide.Text = "Easy search filter|20108";
            this.m_lknkFiltreRapide.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lknkFiltreRapide_LinkClicked);
            // 
            // m_lnkConsultationsHierarchiques
            // 
            this.m_lnkConsultationsHierarchiques.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkConsultationsHierarchiques.ForeColor = System.Drawing.Color.Black;
            this.m_lnkConsultationsHierarchiques.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkConsultationsHierarchiques.LinkColor = System.Drawing.Color.Black;
            this.m_lnkConsultationsHierarchiques.Location = new System.Drawing.Point(12, 165);
            this.m_extModuleAssociator.SetModules(this.m_lnkConsultationsHierarchiques, "");
            this.m_lnkConsultationsHierarchiques.Name = "m_lnkConsultationsHierarchiques";
            this.m_lnkConsultationsHierarchiques.Size = new System.Drawing.Size(198, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lnkConsultationsHierarchiques, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkConsultationsHierarchiques, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkConsultationsHierarchiques.TabIndex = 11;
            this.m_lnkConsultationsHierarchiques.TabStop = true;
            this.m_lnkConsultationsHierarchiques.Text = "Hierarchical consultations|20090";
            this.m_lnkConsultationsHierarchiques.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkConsultationsHierarchiques_LinkClicked);
            // 
            // m_lblInterface
            // 
            this.m_lblInterface.BackColor = System.Drawing.Color.SteelBlue;
            this.m_lblInterface.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblInterface.ForeColor = System.Drawing.Color.Beige;
            this.m_lblInterface.Location = new System.Drawing.Point(4, 4);
            this.m_extModuleAssociator.SetModules(this.m_lblInterface, "");
            this.m_lblInterface.Name = "m_lblInterface";
            this.m_lblInterface.Size = new System.Drawing.Size(206, 22);
            this.m_extStyle.SetStyleBackColor(this.m_lblInterface, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblInterface, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblInterface.TabIndex = 4;
            this.m_lblInterface.Text = "Interface|105";
            this.m_lblInterface.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lnkListes
            // 
            this.m_lnkListes.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkListes.ForeColor = System.Drawing.Color.Black;
            this.m_lnkListes.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkListes.LinkColor = System.Drawing.Color.Black;
            this.m_lnkListes.Location = new System.Drawing.Point(12, 117);
            this.m_extModuleAssociator.SetModules(this.m_lnkListes, "");
            this.m_lnkListes.Name = "m_lnkListes";
            this.m_lnkListes.Size = new System.Drawing.Size(144, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lnkListes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkListes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkListes.TabIndex = 7;
            this.m_lnkListes.TabStop = true;
            this.m_lnkListes.Text = "Predefined lists|108";
            this.m_lnkListes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkListes_LinkClicked);
            // 
            // m_lnkFiltres
            // 
            this.m_lnkFiltres.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkFiltres.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkFiltres.LinkColor = System.Drawing.Color.Black;
            this.m_lnkFiltres.Location = new System.Drawing.Point(12, 79);
            this.m_extModuleAssociator.SetModules(this.m_lnkFiltres, "");
            this.m_lnkFiltres.Name = "m_lnkFiltres";
            this.m_lnkFiltres.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkFiltres, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkFiltres, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkFiltres.TabIndex = 0;
            this.m_lnkFiltres.TabStop = true;
            this.m_lnkFiltres.Text = "Custom filters|107";
            this.m_lnkFiltres.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkFiltres_LinkClicked);
            // 
            // m_lblFavouriteForm
            // 
            this.m_lblFavouriteForm.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lblFavouriteForm.ForeColor = System.Drawing.Color.Black;
            this.m_lblFavouriteForm.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lblFavouriteForm.LinkColor = System.Drawing.Color.Black;
            this.m_lblFavouriteForm.Location = new System.Drawing.Point(12, 57);
            this.m_extModuleAssociator.SetModules(this.m_lblFavouriteForm, "");
            this.m_lblFavouriteForm.Name = "m_lblFavouriteForm";
            this.m_lblFavouriteForm.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lblFavouriteForm, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblFavouriteForm, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblFavouriteForm.TabIndex = 6;
            this.m_lblFavouriteForm.TabStop = true;
            this.m_lblFavouriteForm.Text = "Favourite forms|10024";
            this.m_lblFavouriteForm.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lblFavouriteForm_LinkClicked);
            // 
            // m_lnkFormulaires
            // 
            this.m_lnkFormulaires.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkFormulaires.ForeColor = System.Drawing.Color.Black;
            this.m_lnkFormulaires.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkFormulaires.LinkColor = System.Drawing.Color.Black;
            this.m_lnkFormulaires.Location = new System.Drawing.Point(12, 40);
            this.m_extModuleAssociator.SetModules(this.m_lnkFormulaires, "");
            this.m_lnkFormulaires.Name = "m_lnkFormulaires";
            this.m_lnkFormulaires.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkFormulaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkFormulaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkFormulaires.TabIndex = 6;
            this.m_lnkFormulaires.TabStop = true;
            this.m_lnkFormulaires.Text = "Custom forms|106";
            this.m_lnkFormulaires.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkFormulaires_LinkClicked);
            // 
            // m_lnkModelesDeTexte
            // 
            this.m_lnkModelesDeTexte.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkModelesDeTexte.ForeColor = System.Drawing.Color.Black;
            this.m_lnkModelesDeTexte.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkModelesDeTexte.LinkColor = System.Drawing.Color.Black;
            this.m_lnkModelesDeTexte.Location = new System.Drawing.Point(12, 135);
            this.m_extModuleAssociator.SetModules(this.m_lnkModelesDeTexte, "");
            this.m_lnkModelesDeTexte.Name = "m_lnkModelesDeTexte";
            this.m_lnkModelesDeTexte.Size = new System.Drawing.Size(144, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lnkModelesDeTexte, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkModelesDeTexte, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkModelesDeTexte.TabIndex = 8;
            this.m_lnkModelesDeTexte.TabStop = true;
            this.m_lnkModelesDeTexte.Text = "Text models|474";
            this.m_lnkModelesDeTexte.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkModelesDeTexte_LinkClicked);
            // 
            // m_panDivers
            // 
            this.m_panDivers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panDivers.Controls.Add(this.m_panDivers_2);
            this.m_panDivers.Location = new System.Drawing.Point(278, 268);
            this.m_panDivers.LockEdition = false;
            this.m_extModuleAssociator.SetModules(this.m_panDivers, "");
            this.m_panDivers.Name = "m_panDivers";
            this.m_panDivers.Size = new System.Drawing.Size(233, 234);
            this.m_extStyle.SetStyleBackColor(this.m_panDivers, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panDivers, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panDivers.TabIndex = 17;
            // 
            // m_panDivers_2
            // 
            this.m_panDivers_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panDivers_2.Controls.Add(this.m_lblDivers);
            this.m_panDivers_2.Controls.Add(this.m_lnkCategoriesRapports);
            this.m_panDivers_2.Controls.Add(this.m_lnkNavigationGED);
            this.m_panDivers_2.Controls.Add(this.m_lnkGED);
            this.m_panDivers_2.Controls.Add(this.m_lnkCategorieGED);
            this.m_panDivers_2.Controls.Add(this.m_lnkDossiersMail);
            this.m_panDivers_2.Controls.Add(this.m_linkComptesMail);
            this.m_panDivers_2.Controls.Add(this.m_lnkModeleDeRapport);
            this.m_panDivers_2.ForeColor = System.Drawing.Color.Black;
            this.m_panDivers_2.Location = new System.Drawing.Point(0, 0);
            this.m_extModuleAssociator.SetModules(this.m_panDivers_2, "");
            this.m_panDivers_2.Name = "m_panDivers_2";
            this.m_panDivers_2.Size = new System.Drawing.Size(217, 218);
            this.m_extStyle.SetStyleBackColor(this.m_panDivers_2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panDivers_2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panDivers_2.TabIndex = 11;
            // 
            // m_lblDivers
            // 
            this.m_lblDivers.BackColor = System.Drawing.Color.SteelBlue;
            this.m_lblDivers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblDivers.ForeColor = System.Drawing.Color.Beige;
            this.m_lblDivers.Location = new System.Drawing.Point(4, 4);
            this.m_extModuleAssociator.SetModules(this.m_lblDivers, "");
            this.m_lblDivers.Name = "m_lblDivers";
            this.m_lblDivers.Size = new System.Drawing.Size(208, 22);
            this.m_extStyle.SetStyleBackColor(this.m_lblDivers, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblDivers, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblDivers.TabIndex = 4;
            this.m_lblDivers.Text = "Miscellaneous|55";
            this.m_lblDivers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lnkCategoriesRapports
            // 
            this.m_lnkCategoriesRapports.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkCategoriesRapports.ForeColor = System.Drawing.Color.Black;
            this.m_lnkCategoriesRapports.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkCategoriesRapports.LinkColor = System.Drawing.Color.Black;
            this.m_lnkCategoriesRapports.Location = new System.Drawing.Point(14, 106);
            this.m_extModuleAssociator.SetModules(this.m_lnkCategoriesRapports, "");
            this.m_lnkCategoriesRapports.Name = "m_lnkCategoriesRapports";
            this.m_lnkCategoriesRapports.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkCategoriesRapports, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkCategoriesRapports, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkCategoriesRapports.TabIndex = 12;
            this.m_lnkCategoriesRapports.TabStop = true;
            this.m_lnkCategoriesRapports.Text = "Report category|307";
            this.m_lnkCategoriesRapports.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkCategoriesRapports_LinkClicked);
            // 
            // m_lnkNavigationGED
            // 
            this.m_lnkNavigationGED.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkNavigationGED.ForeColor = System.Drawing.Color.Black;
            this.m_lnkNavigationGED.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkNavigationGED.LinkColor = System.Drawing.Color.Black;
            this.m_lnkNavigationGED.Location = new System.Drawing.Point(14, 77);
            this.m_extModuleAssociator.SetModules(this.m_lnkNavigationGED, "");
            this.m_lnkNavigationGED.Name = "m_lnkNavigationGED";
            this.m_lnkNavigationGED.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkNavigationGED, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkNavigationGED, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkNavigationGED.TabIndex = 9;
            this.m_lnkNavigationGED.TabStop = true;
            this.m_lnkNavigationGED.Text = "EDM Navigation|10101";
            this.m_lnkNavigationGED.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkNavigationGED_LinkClicked);
            // 
            // m_lnkGED
            // 
            this.m_lnkGED.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkGED.ForeColor = System.Drawing.Color.Black;
            this.m_lnkGED.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkGED.LinkColor = System.Drawing.Color.Black;
            this.m_lnkGED.Location = new System.Drawing.Point(14, 57);
            this.m_extModuleAssociator.SetModules(this.m_lnkGED, "");
            this.m_lnkGED.Name = "m_lnkGED";
            this.m_lnkGED.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkGED, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkGED, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkGED.TabIndex = 9;
            this.m_lnkGED.TabStop = true;
            this.m_lnkGED.Text = "EDM Documents|1424";
            this.m_lnkGED.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkGED_LinkClicked);
            // 
            // m_lnkCategorieGED
            // 
            this.m_lnkCategorieGED.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkCategorieGED.ForeColor = System.Drawing.Color.Black;
            this.m_lnkCategorieGED.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkCategorieGED.LinkColor = System.Drawing.Color.Black;
            this.m_lnkCategorieGED.Location = new System.Drawing.Point(14, 40);
            this.m_extModuleAssociator.SetModules(this.m_lnkCategorieGED, "");
            this.m_lnkCategorieGED.Name = "m_lnkCategorieGED";
            this.m_lnkCategorieGED.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkCategorieGED, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkCategorieGED, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkCategorieGED.TabIndex = 9;
            this.m_lnkCategorieGED.TabStop = true;
            this.m_lnkCategorieGED.Text = "EDM Category|176";
            this.m_lnkCategorieGED.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkCategorieGED_LinkClicked);
            // 
            // m_lnkDossiersMail
            // 
            this.m_lnkDossiersMail.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkDossiersMail.ForeColor = System.Drawing.Color.Black;
            this.m_lnkDossiersMail.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkDossiersMail.LinkColor = System.Drawing.Color.Black;
            this.m_lnkDossiersMail.Location = new System.Drawing.Point(14, 156);
            this.m_extModuleAssociator.SetModules(this.m_lnkDossiersMail, "");
            this.m_lnkDossiersMail.Name = "m_lnkDossiersMail";
            this.m_lnkDossiersMail.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkDossiersMail, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkDossiersMail, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkDossiersMail.TabIndex = 13;
            this.m_lnkDossiersMail.TabStop = true;
            this.m_lnkDossiersMail.Text = "Mail Folders|10366";
            this.m_lnkDossiersMail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkDossiersMail_LinkClicked);
            // 
            // m_linkComptesMail
            // 
            this.m_linkComptesMail.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_linkComptesMail.ForeColor = System.Drawing.Color.Black;
            this.m_linkComptesMail.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_linkComptesMail.LinkColor = System.Drawing.Color.Black;
            this.m_linkComptesMail.Location = new System.Drawing.Point(14, 176);
            this.m_extModuleAssociator.SetModules(this.m_linkComptesMail, "");
            this.m_linkComptesMail.Name = "m_linkComptesMail";
            this.m_linkComptesMail.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_linkComptesMail, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_linkComptesMail, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_linkComptesMail.TabIndex = 13;
            this.m_linkComptesMail.TabStop = true;
            this.m_linkComptesMail.Text = "Mail Accounts|10353";
            this.m_linkComptesMail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_linkComptesMail_LinkClicked);
            // 
            // m_lnkModeleDeRapport
            // 
            this.m_lnkModeleDeRapport.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkModeleDeRapport.ForeColor = System.Drawing.Color.Black;
            this.m_lnkModeleDeRapport.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkModeleDeRapport.LinkColor = System.Drawing.Color.Black;
            this.m_lnkModeleDeRapport.Location = new System.Drawing.Point(14, 124);
            this.m_extModuleAssociator.SetModules(this.m_lnkModeleDeRapport, "");
            this.m_lnkModeleDeRapport.Name = "m_lnkModeleDeRapport";
            this.m_lnkModeleDeRapport.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkModeleDeRapport, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkModeleDeRapport, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkModeleDeRapport.TabIndex = 13;
            this.m_lnkModeleDeRapport.TabStop = true;
            this.m_lnkModeleDeRapport.Text = "Reports models|462";
            this.m_lnkModeleDeRapport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkModeleDeRapport_LinkClicked);
            // 
            // m_lnkSequences
            // 
            this.m_lnkSequences.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkSequences.ForeColor = System.Drawing.Color.Black;
            this.m_lnkSequences.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkSequences.LinkColor = System.Drawing.Color.Black;
            this.m_lnkSequences.Location = new System.Drawing.Point(14, 168);
            this.m_extModuleAssociator.SetModules(this.m_lnkSequences, "");
            this.m_lnkSequences.Name = "m_lnkSequences";
            this.m_lnkSequences.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSequences, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSequences, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSequences.TabIndex = 11;
            this.m_lnkSequences.TabStop = true;
            this.m_lnkSequences.Text = "Sequences|20490";
            this.m_lnkSequences.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkSequences_LinkClicked);
            // 
            // m_lnkGrilles
            // 
            this.m_lnkGrilles.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkGrilles.ForeColor = System.Drawing.Color.Black;
            this.m_lnkGrilles.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkGrilles.LinkColor = System.Drawing.Color.Black;
            this.m_lnkGrilles.Location = new System.Drawing.Point(14, 153);
            this.m_extModuleAssociator.SetModules(this.m_lnkGrilles, "");
            this.m_lnkGrilles.Name = "m_lnkGrilles";
            this.m_lnkGrilles.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkGrilles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkGrilles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkGrilles.TabIndex = 10;
            this.m_lnkGrilles.TabStop = true;
            this.m_lnkGrilles.Text = "Grids|178";
            this.m_lnkGrilles.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkGrilles_LinkClicked);
            // 
            // m_panTools_2
            // 
            this.m_panTools_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panTools_2.Controls.Add(this.m_lnkGestionDesUnites);
            this.m_panTools_2.Controls.Add(this.m_lnkSequences);
            this.m_panTools_2.Controls.Add(this.m_lnkFormulesGlobales);
            this.m_panTools_2.Controls.Add(this.label1);
            this.m_panTools_2.Controls.Add(this.m_lnkGrilles);
            this.m_panTools_2.Controls.Add(this.m_lnkImporterDonnees);
            this.m_panTools_2.Controls.Add(this.m_lnkNommageEntite);
            this.m_panTools_2.Controls.Add(this.m_lnkModulesParametrage);
            this.m_panTools_2.ForeColor = System.Drawing.Color.Black;
            this.m_panTools_2.Location = new System.Drawing.Point(0, 0);
            this.m_extModuleAssociator.SetModules(this.m_panTools_2, "");
            this.m_panTools_2.Name = "m_panTools_2";
            this.m_panTools_2.Size = new System.Drawing.Size(217, 232);
            this.m_extStyle.SetStyleBackColor(this.m_panTools_2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panTools_2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panTools_2.TabIndex = 18;
            // 
            // m_lnkGestionDesUnites
            // 
            this.m_lnkGestionDesUnites.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkGestionDesUnites.ForeColor = System.Drawing.Color.Black;
            this.m_lnkGestionDesUnites.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkGestionDesUnites.LinkColor = System.Drawing.Color.Black;
            this.m_lnkGestionDesUnites.Location = new System.Drawing.Point(14, 184);
            this.m_extModuleAssociator.SetModules(this.m_lnkGestionDesUnites, "");
            this.m_lnkGestionDesUnites.Name = "m_lnkGestionDesUnites";
            this.m_lnkGestionDesUnites.Size = new System.Drawing.Size(198, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkGestionDesUnites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkGestionDesUnites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkGestionDesUnites.TabIndex = 12;
            this.m_lnkGestionDesUnites.TabStop = true;
            this.m_lnkGestionDesUnites.Text = "Units management|20496";
            this.m_lnkGestionDesUnites.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkGestionDesUnites_LinkClicked);
            // 
            // m_lnkFormulesGlobales
            // 
            this.m_lnkFormulesGlobales.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkFormulesGlobales.ForeColor = System.Drawing.Color.Black;
            this.m_lnkFormulesGlobales.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkFormulesGlobales.LinkColor = System.Drawing.Color.Black;
            this.m_lnkFormulesGlobales.Location = new System.Drawing.Point(14, 122);
            this.m_extModuleAssociator.SetModules(this.m_lnkFormulesGlobales, "");
            this.m_lnkFormulesGlobales.Name = "m_lnkFormulesGlobales";
            this.m_lnkFormulesGlobales.Size = new System.Drawing.Size(198, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkFormulesGlobales, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkFormulesGlobales, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkFormulesGlobales.TabIndex = 11;
            this.m_lnkFormulesGlobales.TabStop = true;
            this.m_lnkFormulesGlobales.Text = "Setup formulas|20494";
            this.m_lnkFormulesGlobales.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkFormulesGlobales_LinkClicked);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Beige;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.m_extModuleAssociator.SetModules(this.label1, "");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 22);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tools|20193";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lnkImporterDonnees
            // 
            this.m_lnkImporterDonnees.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkImporterDonnees.ForeColor = System.Drawing.Color.Black;
            this.m_lnkImporterDonnees.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkImporterDonnees.LinkColor = System.Drawing.Color.Black;
            this.m_lnkImporterDonnees.Location = new System.Drawing.Point(14, 43);
            this.m_extModuleAssociator.SetModules(this.m_lnkImporterDonnees, "");
            this.m_lnkImporterDonnees.Name = "m_lnkImporterDonnees";
            this.m_lnkImporterDonnees.Size = new System.Drawing.Size(172, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkImporterDonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkImporterDonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkImporterDonnees.TabIndex = 10;
            this.m_lnkImporterDonnees.TabStop = true;
            this.m_lnkImporterDonnees.Text = "Import data|20194";
            this.m_lnkImporterDonnees.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkImporterDonnees_LinkClicked);
            // 
            // m_lnkNommageEntite
            // 
            this.m_lnkNommageEntite.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkNommageEntite.ForeColor = System.Drawing.Color.Black;
            this.m_lnkNommageEntite.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkNommageEntite.LinkColor = System.Drawing.Color.Black;
            this.m_lnkNommageEntite.Location = new System.Drawing.Point(14, 100);
            this.m_extModuleAssociator.SetModules(this.m_lnkNommageEntite, "");
            this.m_lnkNommageEntite.Name = "m_lnkNommageEntite";
            this.m_lnkNommageEntite.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkNommageEntite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkNommageEntite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkNommageEntite.TabIndex = 6;
            this.m_lnkNommageEntite.TabStop = true;
            this.m_lnkNommageEntite.Text = "Entity Naming|10111";
            this.m_lnkNommageEntite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkNommageEntite_LinkClicked);
            // 
            // m_panTools
            // 
            this.m_panTools.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panTools.Controls.Add(this.m_panTools_2);
            this.m_panTools.Location = new System.Drawing.Point(537, 12);
            this.m_panTools.LockEdition = false;
            this.m_extModuleAssociator.SetModules(this.m_panTools, "");
            this.m_panTools.Name = "m_panTools";
            this.m_panTools.Size = new System.Drawing.Size(233, 250);
            this.m_extStyle.SetStyleBackColor(this.m_panTools, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panTools, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panTools.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.m_lnkMibs);
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(537, 268);
            this.m_extModuleAssociator.SetModules(this.panel1, "ASNMP");
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(217, 218);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 20;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Beige;
            this.label2.Location = new System.Drawing.Point(4, 4);
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
            this.m_extModuleAssociator.SetModules(this.m_lnkMibs, "");
            this.m_lnkMibs.Name = "m_lnkMibs";
            this.m_lnkMibs.Size = new System.Drawing.Size(172, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkMibs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkMibs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkMibs.TabIndex = 10;
            this.m_lnkMibs.TabStop = true;
            this.m_lnkMibs.Text = "Mibs|20253";
            this.m_lnkMibs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkMibs_LinkClicked);
            // 
            // m_lnkFonctionsDynamiques
            // 
            this.m_lnkFonctionsDynamiques.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkFonctionsDynamiques.ForeColor = System.Drawing.Color.Black;
            this.m_lnkFonctionsDynamiques.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkFonctionsDynamiques.LinkColor = System.Drawing.Color.Black;
            this.m_lnkFonctionsDynamiques.Location = new System.Drawing.Point(12, 67);
            this.m_extModuleAssociator.SetModules(this.m_lnkFonctionsDynamiques, "");
            this.m_lnkFonctionsDynamiques.Name = "m_lnkFonctionsDynamiques";
            this.m_lnkFonctionsDynamiques.Size = new System.Drawing.Size(144, 14);
            this.m_extStyle.SetStyleBackColor(this.m_lnkFonctionsDynamiques, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkFonctionsDynamiques, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkFonctionsDynamiques.TabIndex = 0;
            this.m_lnkFonctionsDynamiques.TabStop = true;
            this.m_lnkFonctionsDynamiques.Text = "Dynamic functions|20842";
            this.m_lnkFonctionsDynamiques.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkFonctionsDynamiques_LinkClicked);
            // 
            // CFormMenuConfiguration
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(803, 514);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_panTools);
            this.Controls.Add(this.m_panDivers);
            this.Controls.Add(this.m_panInterface);
            this.Controls.Add(this.m_panProcess);
            this.Controls.Add(this.m_panStructureDonnees);
            this.m_extModuleAssociator.SetModules(this, "");
            this.Name = "CFormMenuConfiguration";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondFenetre);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "CFormMenuConfiguration";
            this.Load += new System.EventHandler(this.CFormMenuConfiguration_Load);
            this.Activated += new System.EventHandler(this.CFormMenuConfiguration_Activated);
            this.Enter += new System.EventHandler(this.CFormMenuConfiguration_Enter);
            this.c2iPanelOmbre3.ResumeLayout(false);
            this.c2iPanelOmbre3.PerformLayout();
            this.m_panStructureDonnees.ResumeLayout(false);
            this.m_panStructureDonnees.PerformLayout();
            this.m_panStructureDonnees_2.ResumeLayout(false);
            this.m_panProcess.ResumeLayout(false);
            this.m_panProcess.PerformLayout();
            this.m_panProcess_2.ResumeLayout(false);
            this.m_panInterface.ResumeLayout(false);
            this.m_panInterface.PerformLayout();
            this.m_panInterface_2.ResumeLayout(false);
            this.m_panDivers.ResumeLayout(false);
            this.m_panDivers.PerformLayout();
            this.m_panDivers_2.ResumeLayout(false);
            this.m_panTools_2.ResumeLayout(false);
            this.m_panTools.ResumeLayout(false);
            this.m_panTools.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		public CFormMenuConfiguration()
		{
			InitializeComponent();
		}



		private void CFormMenuConfiguration_Load(object sender, System.EventArgs e)
		{
            m_extModuleAssociator.AppliquerConfiguration(CTimosApp.ConfigurationModules);

            try
            {
                IInfoUtilisateur info = CTimosApp.SessionClient.GetInfoUtilisateur();
                m_lnkImporterDonnees.Visible = info.GetDonneeDroit(CDroitDeBaseSC2I.c_droitImport) != null;
            }
            catch
            {
            }
#if DEBUG
            m_lnkMacros.Visible=  true;
#endif
            
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
			// TODO : ajoutez l'implémentation de CFormMenuConfiguration.System.IDisposable.Dispose
		}

		#endregion



		private void CFormMenuConfiguration_Enter(object sender, System.EventArgs e)
		{
			CTimosApp.Titre = I.T("Configuration|7");
		}

		

		private void CFormMenuConfiguration_Activated(object sender, System.EventArgs e)
		{
		}

        //*************************************************************************************
        // Strustures de données
        //*************************************************************************************
        
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

        private void m_lnkTypeDonneeCumulee_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeTypesDonneesCumulees());
        }

        private void m_lnkTypeTable_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeTypeTableParametrable());
        }

        private void m_lnkTableParametrable_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeTableParametrable());
        }
      

        //*************************************************************************************
        // Process
        //*************************************************************************************

        private void m_lnkGroupesParametrage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeGroupesParametrage());
        }

        private void m_lnkComportements_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeComportementsGeneriques());
        }

        private void m_lnkProcess_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeProcess());
        }

        private void m_lnkEvenements_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeEvenements());
        }

        private void m_lnkTachesPlanifiees_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeTachesPlanifiees());
        }


        //*************************************************************************************
        // Interfaces
        //*************************************************************************************

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

        private void m_lnkModelesDeTexte_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeModeleTexte());
        }

        //*************************************************************************************
        // Divers
        //*************************************************************************************
 
        private void m_lnkCategorieGED_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeCategoriesGED());
        }

        private void m_lnkGED_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeDocumentsGED());
        }

        private void m_lnkCategoriesRapports_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeCategoriesRapportCrystal());
        }

        private void m_lnkModeleDeRapport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeRapportsCrystal());
        }

        private void m_lnkGrilles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeGrilleGeneriques());
        }

		private void m_lnkTypesCaracteristiques_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeTypesCaracteristiques());
        }



        private void m_lblFavouriteForm_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormEditionPreferenceTypeForm());
        }

		private void m_lnkConsultationsHierarchiques_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTimosApp.Navigateur.AffichePage(new CFormListeConsultationsHierarchiques());
		}

        private void m_lknkFiltreRapide_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormEditionPreferenceFiltreRapide());
        }

        private void m_lnkModulesParametrage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CFormEditModulesParametrage.EditModules();
        }

        private void m_lnkNavigationGED_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormNavigationGED());
        }

        private void m_lnkImporterDonnees_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CAssistantImporterDonnees.ImporterDonnees();
        }

        private void m_lnkNommageEntite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeNommageEntite());
        }

        private void m_lnkMibs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeSnmpMibs());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void m_lnkSequences_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeSequenceNumerotation());
        }

        private void m_lnkFormulesGlobales_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CFormEditeFormulesGlobales.EditeFormulesGlobales();
        }

        private void m_linkComptesMail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeCompteMail());
        }

        private void m_lnkDossiersMail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeDossierMail());
        }

        private void m_lnkGestionDesUnites_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CFormGestionUnites.GererLesUnites();
        }

        private void m_lnkWorkflows_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeWorkflows());
        }

        private void m_lnkTypesWorkflows_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeTypeWorkflow());
        }

        private void m_lnkEtapesWorkflow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeEtapesWorkflow());
        }

        private void m_lnkMacros_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CFormGestionDesMacros.ShowMacros();
        }

        public string GetTitle()
        {
            return I.T("Configuration|7"); 
        }

        public Image GetImage()
        {
            return Resources.configuration;
        }

        private void m_lnkEasyQueries_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeEasyQueryInDbs());
        }

        private void m_lnkConfigurationsCartes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeConfigMapDataBase());
        }

        private void m_lnkFonctionsDynamiques_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeFonctionsDynamiquesInDb());
        }
   
    }

}

