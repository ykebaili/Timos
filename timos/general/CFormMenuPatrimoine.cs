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
using sc2i.win32.common;
using timos.commandes;
using timos.coordonnees;
using timos.Properties;

namespace timos
{
	/// <summary>
	/// Description résumée de CFormMenuPatrimoine.
	/// </summary>
    [DynamicForm("Patrimoine")]
    public class CFormMenuPatrimoine : CFormMaxiSansMenu, IFormNavigable
    {
        #region Code généré par le Concepteur Windows Form

        private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox m_chkSuiviDates;
        private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre2;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.LinkLabel m_lnkFamilles;
        private System.Windows.Forms.LinkLabel m_lnkTypeEquipement;
        private System.Windows.Forms.LinkLabel m_lnkEquipement;
        private LinkLabel m_lnkStocks;
        private LinkLabel linkLabel1;
        private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre1;
        private LinkLabel m_lnkTypeSite;
        private Label label1;
        private LinkLabel m_lnkSites;
        private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
        private Label label2;
        private LinkLabel m_lnkTypeCle;
        private LinkLabel m_lnkCles;
        private LinkLabel m_lnkTypesCiontrainteAcces;
        private LinkLabel m_linkContrainte;
        private sc2i.win32.common.C2iPanelOmbre m_panCoor;
        private Panel m_panCoor_2;
        private Label m_lblCoor;
        private LinkLabel m_lnkSystemeCoordonnees;
        private LinkLabel m_lnkFormatsNumerotation;
        private LinkLabel m_lnkUnite;
        private LinkLabel m_lnkStatutsEquipement;
        private CExtModulesAssociator m_extModuleAssociator;
        private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre5;
        private LinkLabel m_lnkFonctions;
        private Label label5;
        private C2iPanelOmbre c2iPanelOmbre6;
        private LinkLabel m_lnkTypeLienReseau;
        private Label label6;
        private LinkLabel m_lnkLienReseau;
        private LinkLabel m_lnkSymbolesDeBibliotheque;
        private LinkLabel m_lnkFamilleSymboles;
        private LinkLabel m_lnkSchemaReseau;
        private LinkLabel m_lnkTypeSchemaReseau;
        private LinkLabel m_lnkModeleEtiquette;
        private LinkLabel m_lnkParametreSchemasDynamiques;
        private LinkLabel m_lnkTypesPorts;
        private C2iPanelOmbre c2iPanelOmbre7;
        private Label label7;
        private LinkLabel m_lnksCommandes;
        private LinkLabel m_lnkTypesCommandes;
        private LinkLabel m_lnkLivraisons;
        private LinkLabel m_lnkTypesLivraison;
        private LinkLabel m_lnkLotsValorisation;
        private LinkLabel m_lnkOptionsGeneralesCoord;
        private C2iPanelOmbre m_panelConsommables;
        private Label label8;
        private LinkLabel m_lnkTypeConsommables;
        private LinkLabel m_lnkLotConsommable;
        private LinkLabel m_lnkRelevesSite;
        private LinkLabel m_lnkCartesGPS;
        private LinkLabel m_lnkTypesLignesGPS;
        private LinkLabel m_lnkTypesPointsGPS;
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
            this.c2iPanelOmbre2 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_lnkTypesPorts = new System.Windows.Forms.LinkLabel();
            this.m_lnkTypeEquipement = new System.Windows.Forms.LinkLabel();
            this.m_lnkEquipement = new System.Windows.Forms.LinkLabel();
            this.m_lnkFamilles = new System.Windows.Forms.LinkLabel();
            this.m_lnkStatutsEquipement = new System.Windows.Forms.LinkLabel();
            this.m_lnkFonctions = new System.Windows.Forms.LinkLabel();
            this.Label3 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.m_lnkStocks = new System.Windows.Forms.LinkLabel();
            this.c2iPanelOmbre1 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_lnkRelevesSite = new System.Windows.Forms.LinkLabel();
            this.m_lnkTypeSite = new System.Windows.Forms.LinkLabel();
            this.m_lnkSites = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.label2 = new System.Windows.Forms.Label();
            this.m_linkContrainte = new System.Windows.Forms.LinkLabel();
            this.m_lnkTypesCiontrainteAcces = new System.Windows.Forms.LinkLabel();
            this.m_lnkCles = new System.Windows.Forms.LinkLabel();
            this.m_lnkTypeCle = new System.Windows.Forms.LinkLabel();
            this.m_panCoor = new sc2i.win32.common.C2iPanelOmbre();
            this.m_panCoor_2 = new System.Windows.Forms.Panel();
            this.m_lnkOptionsGeneralesCoord = new System.Windows.Forms.LinkLabel();
            this.m_lblCoor = new System.Windows.Forms.Label();
            this.m_lnkSystemeCoordonnees = new System.Windows.Forms.LinkLabel();
            this.m_lnkFormatsNumerotation = new System.Windows.Forms.LinkLabel();
            this.m_lnkUnite = new System.Windows.Forms.LinkLabel();
            this.m_extModuleAssociator = new timos.CExtModulesAssociator();
            this.c2iPanelOmbre5 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_lnkTypesLignesGPS = new System.Windows.Forms.LinkLabel();
            this.m_lnkCartesGPS = new System.Windows.Forms.LinkLabel();
            this.m_lnkParametreSchemasDynamiques = new System.Windows.Forms.LinkLabel();
            this.m_lnkSymbolesDeBibliotheque = new System.Windows.Forms.LinkLabel();
            this.m_lnkFamilleSymboles = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.c2iPanelOmbre6 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_lnkModeleEtiquette = new System.Windows.Forms.LinkLabel();
            this.m_lnkTypeSchemaReseau = new System.Windows.Forms.LinkLabel();
            this.m_lnkLienReseau = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.m_lnkTypeLienReseau = new System.Windows.Forms.LinkLabel();
            this.m_lnkSchemaReseau = new System.Windows.Forms.LinkLabel();
            this.c2iPanelOmbre7 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_lnkLotsValorisation = new System.Windows.Forms.LinkLabel();
            this.m_lnkTypesLivraison = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.m_lnksCommandes = new System.Windows.Forms.LinkLabel();
            this.m_lnkTypesCommandes = new System.Windows.Forms.LinkLabel();
            this.m_lnkLivraisons = new System.Windows.Forms.LinkLabel();
            this.m_panelConsommables = new sc2i.win32.common.C2iPanelOmbre();
            this.label8 = new System.Windows.Forms.Label();
            this.m_lnkTypeConsommables = new System.Windows.Forms.LinkLabel();
            this.m_lnkLotConsommable = new System.Windows.Forms.LinkLabel();
            this.m_lnkTypesPointsGPS = new System.Windows.Forms.LinkLabel();
            this.c2iPanelOmbre3.SuspendLayout();
            this.c2iPanelOmbre2.SuspendLayout();
            this.c2iPanelOmbre1.SuspendLayout();
            this.c2iPanelOmbre4.SuspendLayout();
            this.m_panCoor.SuspendLayout();
            this.m_panCoor_2.SuspendLayout();
            this.c2iPanelOmbre5.SuspendLayout();
            this.c2iPanelOmbre6.SuspendLayout();
            this.c2iPanelOmbre7.SuspendLayout();
            this.m_panelConsommables.SuspendLayout();
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
            // c2iPanelOmbre2
            // 
            this.c2iPanelOmbre2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre2.Controls.Add(this.m_lnkTypesPorts);
            this.c2iPanelOmbre2.Controls.Add(this.m_lnkTypeEquipement);
            this.c2iPanelOmbre2.Controls.Add(this.m_lnkEquipement);
            this.c2iPanelOmbre2.Controls.Add(this.m_lnkFamilles);
            this.c2iPanelOmbre2.Controls.Add(this.m_lnkStatutsEquipement);
            this.c2iPanelOmbre2.Controls.Add(this.m_lnkFonctions);
            this.c2iPanelOmbre2.Controls.Add(this.Label3);
            this.c2iPanelOmbre2.ForeColor = System.Drawing.Color.Black;
            this.c2iPanelOmbre2.Location = new System.Drawing.Point(12, 176);
            this.c2iPanelOmbre2.LockEdition = false;
            this.m_extModuleAssociator.SetModules(this.c2iPanelOmbre2, "");
            this.c2iPanelOmbre2.Name = "c2iPanelOmbre2";
            this.c2iPanelOmbre2.Size = new System.Drawing.Size(234, 168);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre2.TabIndex = 10;
            // 
            // m_lnkTypesPorts
            // 
            this.m_lnkTypesPorts.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkTypesPorts.ForeColor = System.Drawing.Color.Black;
            this.m_lnkTypesPorts.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkTypesPorts.LinkColor = System.Drawing.Color.Black;
            this.m_lnkTypesPorts.Location = new System.Drawing.Point(8, 131);
            this.m_extModuleAssociator.SetModules(this.m_lnkTypesPorts, "");
            this.m_lnkTypesPorts.Name = "m_lnkTypesPorts";
            this.m_lnkTypesPorts.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTypesPorts, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTypesPorts, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTypesPorts.TabIndex = 13;
            this.m_lnkTypesPorts.TabStop = true;
            this.m_lnkTypesPorts.Text = "Port types|50003";
            this.m_lnkTypesPorts.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTypesPorts_LinkClicked);
            // 
            // m_lnkTypeEquipement
            // 
            this.m_lnkTypeEquipement.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkTypeEquipement.ForeColor = System.Drawing.Color.Black;
            this.m_lnkTypeEquipement.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkTypeEquipement.LinkColor = System.Drawing.Color.Black;
            this.m_lnkTypeEquipement.Location = new System.Drawing.Point(8, 55);
            this.m_extModuleAssociator.SetModules(this.m_lnkTypeEquipement, "");
            this.m_lnkTypeEquipement.Name = "m_lnkTypeEquipement";
            this.m_lnkTypeEquipement.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTypeEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTypeEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTypeEquipement.TabIndex = 0;
            this.m_lnkTypeEquipement.TabStop = true;
            this.m_lnkTypeEquipement.Text = "Equipment Types|191";
            this.m_lnkTypeEquipement.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTypeEquipement_LinkClicked);
            // 
            // m_lnkEquipement
            // 
            this.m_lnkEquipement.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkEquipement.ForeColor = System.Drawing.Color.Black;
            this.m_lnkEquipement.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkEquipement.LinkColor = System.Drawing.Color.Black;
            this.m_lnkEquipement.Location = new System.Drawing.Point(8, 76);
            this.m_extModuleAssociator.SetModules(this.m_lnkEquipement, "");
            this.m_lnkEquipement.Name = "m_lnkEquipement";
            this.m_lnkEquipement.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkEquipement.TabIndex = 7;
            this.m_lnkEquipement.TabStop = true;
            this.m_lnkEquipement.Text = "Equipements|192";
            this.m_lnkEquipement.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkEquipement_LinkClicked);
            // 
            // m_lnkFamilles
            // 
            this.m_lnkFamilles.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkFamilles.ForeColor = System.Drawing.Color.Black;
            this.m_lnkFamilles.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkFamilles.LinkColor = System.Drawing.Color.Black;
            this.m_lnkFamilles.Location = new System.Drawing.Point(8, 38);
            this.m_extModuleAssociator.SetModules(this.m_lnkFamilles, "");
            this.m_lnkFamilles.Name = "m_lnkFamilles";
            this.m_lnkFamilles.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkFamilles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkFamilles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkFamilles.TabIndex = 6;
            this.m_lnkFamilles.TabStop = true;
            this.m_lnkFamilles.Text = "Equipment Family|190";
            this.m_lnkFamilles.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkFamilles_LinkClicked);
            // 
            // m_lnkStatutsEquipement
            // 
            this.m_lnkStatutsEquipement.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkStatutsEquipement.ForeColor = System.Drawing.Color.Black;
            this.m_lnkStatutsEquipement.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkStatutsEquipement.LinkColor = System.Drawing.Color.Black;
            this.m_lnkStatutsEquipement.Location = new System.Drawing.Point(8, 113);
            this.m_extModuleAssociator.SetModules(this.m_lnkStatutsEquipement, "");
            this.m_lnkStatutsEquipement.Name = "m_lnkStatutsEquipement";
            this.m_lnkStatutsEquipement.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkStatutsEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkStatutsEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkStatutsEquipement.TabIndex = 12;
            this.m_lnkStatutsEquipement.TabStop = true;
            this.m_lnkStatutsEquipement.Text = "Equipment status|229";
            this.m_lnkStatutsEquipement.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkStatutsEquipement_LinkClicked);
            // 
            // m_lnkFonctions
            // 
            this.m_lnkFonctions.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkFonctions.ForeColor = System.Drawing.Color.Black;
            this.m_lnkFonctions.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkFonctions.LinkColor = System.Drawing.Color.Black;
            this.m_lnkFonctions.Location = new System.Drawing.Point(8, 94);
            this.m_extModuleAssociator.SetModules(this.m_lnkFonctions, "");
            this.m_lnkFonctions.Name = "m_lnkFonctions";
            this.m_lnkFonctions.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkFonctions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkFonctions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkFonctions.TabIndex = 7;
            this.m_lnkFonctions.TabStop = true;
            this.m_lnkFonctions.Text = "Logical equipments|20049";
            this.m_lnkFonctions.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkFonctions_LinkClicked);
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.Color.SteelBlue;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Beige;
            this.Label3.Location = new System.Drawing.Point(4, 4);
            this.m_extModuleAssociator.SetModules(this.Label3, "");
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(210, 23);
            this.m_extStyle.SetStyleBackColor(this.Label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.Label3, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTitrePanel);
            this.Label3.TabIndex = 4;
            this.Label3.Text = "Equipment|195";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // linkLabel1
            // 
            this.linkLabel1.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.linkLabel1.ForeColor = System.Drawing.Color.Black;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(8, 80);
            this.m_extModuleAssociator.SetModules(this.linkLabel1, "ASTOCK");
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.linkLabel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.linkLabel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Stock types|207";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // m_lnkStocks
            // 
            this.m_lnkStocks.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkStocks.ForeColor = System.Drawing.Color.Black;
            this.m_lnkStocks.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkStocks.LinkColor = System.Drawing.Color.Black;
            this.m_lnkStocks.Location = new System.Drawing.Point(8, 99);
            this.m_extModuleAssociator.SetModules(this.m_lnkStocks, "ASTOCK");
            this.m_lnkStocks.Name = "m_lnkStocks";
            this.m_lnkStocks.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkStocks, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkStocks, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkStocks.TabIndex = 6;
            this.m_lnkStocks.TabStop = true;
            this.m_lnkStocks.Text = "Stocks|205";
            this.m_lnkStocks.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkStocks_LinkClicked);
            // 
            // c2iPanelOmbre1
            // 
            this.c2iPanelOmbre1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre1.Controls.Add(this.m_lnkRelevesSite);
            this.c2iPanelOmbre1.Controls.Add(this.m_lnkTypeSite);
            this.c2iPanelOmbre1.Controls.Add(this.m_lnkSites);
            this.c2iPanelOmbre1.Controls.Add(this.label1);
            this.c2iPanelOmbre1.Controls.Add(this.linkLabel1);
            this.c2iPanelOmbre1.Controls.Add(this.m_lnkStocks);
            this.c2iPanelOmbre1.ForeColor = System.Drawing.Color.Black;
            this.c2iPanelOmbre1.Location = new System.Drawing.Point(12, 12);
            this.c2iPanelOmbre1.LockEdition = false;
            this.m_extModuleAssociator.SetModules(this.c2iPanelOmbre1, "");
            this.c2iPanelOmbre1.Name = "c2iPanelOmbre1";
            this.c2iPanelOmbre1.Size = new System.Drawing.Size(234, 158);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre1.TabIndex = 11;
            // 
            // m_lnkRelevesSite
            // 
            this.m_lnkRelevesSite.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkRelevesSite.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lnkRelevesSite.ForeColor = System.Drawing.Color.Black;
            this.m_lnkRelevesSite.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkRelevesSite.LinkColor = System.Drawing.Color.Black;
            this.m_lnkRelevesSite.Location = new System.Drawing.Point(115, 58);
            this.m_extModuleAssociator.SetModules(this.m_lnkRelevesSite, "ASITE_SURVEY");
            this.m_lnkRelevesSite.Name = "m_lnkRelevesSite";
            this.m_lnkRelevesSite.Size = new System.Drawing.Size(86, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkRelevesSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkRelevesSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkRelevesSite.TabIndex = 9;
            this.m_lnkRelevesSite.TabStop = true;
            this.m_lnkRelevesSite.Text = "Surveys|20775";
            this.m_lnkRelevesSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkRelevesSite_LinkClicked);
            // 
            // m_lnkTypeSite
            // 
            this.m_lnkTypeSite.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkTypeSite.ForeColor = System.Drawing.Color.Black;
            this.m_lnkTypeSite.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkTypeSite.LinkColor = System.Drawing.Color.Black;
            this.m_lnkTypeSite.Location = new System.Drawing.Point(8, 39);
            this.m_extModuleAssociator.SetModules(this.m_lnkTypeSite, "");
            this.m_lnkTypeSite.Name = "m_lnkTypeSite";
            this.m_lnkTypeSite.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTypeSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTypeSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTypeSite.TabIndex = 8;
            this.m_lnkTypeSite.TabStop = true;
            this.m_lnkTypeSite.Text = "Sites types|226";
            this.m_lnkTypeSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m__LinkClicked);
            // 
            // m_lnkSites
            // 
            this.m_lnkSites.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkSites.ForeColor = System.Drawing.Color.Black;
            this.m_lnkSites.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkSites.LinkColor = System.Drawing.Color.Black;
            this.m_lnkSites.Location = new System.Drawing.Point(8, 58);
            this.m_extModuleAssociator.SetModules(this.m_lnkSites, "");
            this.m_lnkSites.Name = "m_lnkSites";
            this.m_lnkSites.Size = new System.Drawing.Size(86, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSites.TabIndex = 6;
            this.m_lnkSites.TabStop = true;
            this.m_lnkSites.Text = "Sites|227";
            this.m_lnkSites.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkSites_LinkClicked);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Beige;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.m_extModuleAssociator.SetModules(this.label1, "");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 23);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTitrePanel);
            this.label1.TabIndex = 4;
            this.label1.Text = "Site|225";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.label2);
            this.c2iPanelOmbre4.Controls.Add(this.m_linkContrainte);
            this.c2iPanelOmbre4.Controls.Add(this.m_lnkTypesCiontrainteAcces);
            this.c2iPanelOmbre4.Controls.Add(this.m_lnkCles);
            this.c2iPanelOmbre4.Controls.Add(this.m_lnkTypeCle);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(292, 12);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_extModuleAssociator.SetModules(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(261, 158);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Beige;
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.m_extModuleAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(236, 20);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 3;
            this.label2.Text = "Constraints and Resources|313";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_linkContrainte
            // 
            this.m_linkContrainte.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_linkContrainte.LinkColor = System.Drawing.Color.Black;
            this.m_linkContrainte.Location = new System.Drawing.Point(8, 98);
            this.m_extModuleAssociator.SetModules(this.m_linkContrainte, "");
            this.m_linkContrainte.Name = "m_linkContrainte";
            this.m_linkContrainte.Size = new System.Drawing.Size(79, 13);
            this.m_extStyle.SetStyleBackColor(this.m_linkContrainte, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_linkContrainte, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_linkContrainte.TabIndex = 4;
            this.m_linkContrainte.TabStop = true;
            this.m_linkContrainte.Text = "Constraints|255";
            this.m_linkContrainte.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_linkContrainte_LinkClicked);
            // 
            // m_lnkTypesCiontrainteAcces
            // 
            this.m_lnkTypesCiontrainteAcces.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkTypesCiontrainteAcces.LinkColor = System.Drawing.Color.Black;
            this.m_lnkTypesCiontrainteAcces.Location = new System.Drawing.Point(8, 80);
            this.m_extModuleAssociator.SetModules(this.m_lnkTypesCiontrainteAcces, "CTYPE_CONTRAINTE");
            this.m_lnkTypesCiontrainteAcces.Name = "m_lnkTypesCiontrainteAcces";
            this.m_lnkTypesCiontrainteAcces.Size = new System.Drawing.Size(106, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTypesCiontrainteAcces, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTypesCiontrainteAcces, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTypesCiontrainteAcces.TabIndex = 4;
            this.m_lnkTypesCiontrainteAcces.TabStop = true;
            this.m_lnkTypesCiontrainteAcces.Text = "Constraints Type|259";
            this.m_lnkTypesCiontrainteAcces.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTypesCiontrainteAcces_LinkClicked);
            // 
            // m_lnkCles
            // 
            this.m_lnkCles.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkCles.LinkColor = System.Drawing.Color.Black;
            this.m_lnkCles.Location = new System.Drawing.Point(8, 52);
            this.m_extModuleAssociator.SetModules(this.m_lnkCles, "");
            this.m_lnkCles.Name = "m_lnkCles";
            this.m_lnkCles.Size = new System.Drawing.Size(78, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkCles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkCles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkCles.TabIndex = 5;
            this.m_lnkCles.TabStop = true;
            this.m_lnkCles.Text = "Resources|254";
            this.m_lnkCles.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkCles_LinkClicked);
            // 
            // m_lnkTypeCle
            // 
            this.m_lnkTypeCle.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkTypeCle.LinkColor = System.Drawing.Color.Black;
            this.m_lnkTypeCle.Location = new System.Drawing.Point(8, 33);
            this.m_extModuleAssociator.SetModules(this.m_lnkTypeCle, "CTYPE_RESSOURCE");
            this.m_lnkTypeCle.Name = "m_lnkTypeCle";
            this.m_lnkTypeCle.Size = new System.Drawing.Size(110, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTypeCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTypeCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTypeCle.TabIndex = 4;
            this.m_lnkTypeCle.TabStop = true;
            this.m_lnkTypeCle.Text = "Resources Types|251";
            this.m_lnkTypeCle.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTypeCle_LinkClicked);
            // 
            // m_panCoor
            // 
            this.m_panCoor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panCoor.Controls.Add(this.m_panCoor_2);
            this.m_panCoor.Location = new System.Drawing.Point(292, 176);
            this.m_panCoor.LockEdition = false;
            this.m_extModuleAssociator.SetModules(this.m_panCoor, "ASYS_COOR");
            this.m_panCoor.Name = "m_panCoor";
            this.m_panCoor.Size = new System.Drawing.Size(261, 168);
            this.m_extStyle.SetStyleBackColor(this.m_panCoor, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panCoor, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panCoor.TabIndex = 14;
            // 
            // m_panCoor_2
            // 
            this.m_panCoor_2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panCoor_2.Controls.Add(this.m_lnkOptionsGeneralesCoord);
            this.m_panCoor_2.Controls.Add(this.m_lblCoor);
            this.m_panCoor_2.Controls.Add(this.m_lnkSystemeCoordonnees);
            this.m_panCoor_2.Controls.Add(this.m_lnkFormatsNumerotation);
            this.m_panCoor_2.Controls.Add(this.m_lnkUnite);
            this.m_panCoor_2.Location = new System.Drawing.Point(0, 0);
            this.m_extModuleAssociator.SetModules(this.m_panCoor_2, "");
            this.m_panCoor_2.Name = "m_panCoor_2";
            this.m_panCoor_2.Size = new System.Drawing.Size(245, 146);
            this.m_extStyle.SetStyleBackColor(this.m_panCoor_2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panCoor_2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panCoor_2.TabIndex = 11;
            // 
            // m_lnkOptionsGeneralesCoord
            // 
            this.m_lnkOptionsGeneralesCoord.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkOptionsGeneralesCoord.ForeColor = System.Drawing.Color.Black;
            this.m_lnkOptionsGeneralesCoord.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkOptionsGeneralesCoord.LinkColor = System.Drawing.Color.Black;
            this.m_lnkOptionsGeneralesCoord.Location = new System.Drawing.Point(8, 34);
            this.m_extModuleAssociator.SetModules(this.m_lnkOptionsGeneralesCoord, "");
            this.m_lnkOptionsGeneralesCoord.Name = "m_lnkOptionsGeneralesCoord";
            this.m_lnkOptionsGeneralesCoord.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkOptionsGeneralesCoord, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkOptionsGeneralesCoord, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkOptionsGeneralesCoord.TabIndex = 13;
            this.m_lnkOptionsGeneralesCoord.TabStop = true;
            this.m_lnkOptionsGeneralesCoord.Text = "General options|20471";
            this.m_lnkOptionsGeneralesCoord.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkOptionsGeneralesCoord_LinkClicked);
            // 
            // m_lblCoor
            // 
            this.m_lblCoor.BackColor = System.Drawing.Color.SteelBlue;
            this.m_lblCoor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblCoor.ForeColor = System.Drawing.Color.Beige;
            this.m_lblCoor.Location = new System.Drawing.Point(4, 4);
            this.m_extModuleAssociator.SetModules(this.m_lblCoor, "");
            this.m_lblCoor.Name = "m_lblCoor";
            this.m_lblCoor.Size = new System.Drawing.Size(236, 23);
            this.m_extStyle.SetStyleBackColor(this.m_lblCoor, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblCoor, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblCoor.TabIndex = 4;
            this.m_lblCoor.Text = "Coordinates System|430";
            this.m_lblCoor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lnkSystemeCoordonnees
            // 
            this.m_lnkSystemeCoordonnees.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkSystemeCoordonnees.ForeColor = System.Drawing.Color.Black;
            this.m_lnkSystemeCoordonnees.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkSystemeCoordonnees.LinkColor = System.Drawing.Color.Black;
            this.m_lnkSystemeCoordonnees.Location = new System.Drawing.Point(8, 102);
            this.m_extModuleAssociator.SetModules(this.m_lnkSystemeCoordonnees, "");
            this.m_lnkSystemeCoordonnees.Name = "m_lnkSystemeCoordonnees";
            this.m_lnkSystemeCoordonnees.Size = new System.Drawing.Size(166, 14);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSystemeCoordonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSystemeCoordonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSystemeCoordonnees.TabIndex = 12;
            this.m_lnkSystemeCoordonnees.TabStop = true;
            this.m_lnkSystemeCoordonnees.Text = "Coordinates Systems|524";
            this.m_lnkSystemeCoordonnees.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkSystemeCoordonnees_LinkClicked);
            // 
            // m_lnkFormatsNumerotation
            // 
            this.m_lnkFormatsNumerotation.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkFormatsNumerotation.ForeColor = System.Drawing.Color.Black;
            this.m_lnkFormatsNumerotation.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkFormatsNumerotation.LinkColor = System.Drawing.Color.Black;
            this.m_lnkFormatsNumerotation.Location = new System.Drawing.Point(8, 79);
            this.m_extModuleAssociator.SetModules(this.m_lnkFormatsNumerotation, "");
            this.m_lnkFormatsNumerotation.Name = "m_lnkFormatsNumerotation";
            this.m_lnkFormatsNumerotation.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkFormatsNumerotation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkFormatsNumerotation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkFormatsNumerotation.TabIndex = 12;
            this.m_lnkFormatsNumerotation.TabStop = true;
            this.m_lnkFormatsNumerotation.Text = "Numbering Formats|525";
            this.m_lnkFormatsNumerotation.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkFormatsNumerotation_LinkClicked);
            // 
            // m_lnkUnite
            // 
            this.m_lnkUnite.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkUnite.ForeColor = System.Drawing.Color.Black;
            this.m_lnkUnite.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkUnite.LinkColor = System.Drawing.Color.Black;
            this.m_lnkUnite.Location = new System.Drawing.Point(8, 56);
            this.m_extModuleAssociator.SetModules(this.m_lnkUnite, "");
            this.m_lnkUnite.Name = "m_lnkUnite";
            this.m_lnkUnite.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkUnite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkUnite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkUnite.TabIndex = 6;
            this.m_lnkUnite.TabStop = true;
            this.m_lnkUnite.Text = "Units|429";
            this.m_lnkUnite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkUnite_LinkClicked);
            // 
            // c2iPanelOmbre5
            // 
            this.c2iPanelOmbre5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre5.Controls.Add(this.m_lnkTypesPointsGPS);
            this.c2iPanelOmbre5.Controls.Add(this.m_lnkTypesLignesGPS);
            this.c2iPanelOmbre5.Controls.Add(this.m_lnkCartesGPS);
            this.c2iPanelOmbre5.Controls.Add(this.m_lnkParametreSchemasDynamiques);
            this.c2iPanelOmbre5.Controls.Add(this.m_lnkSymbolesDeBibliotheque);
            this.c2iPanelOmbre5.Controls.Add(this.m_lnkFamilleSymboles);
            this.c2iPanelOmbre5.Controls.Add(this.label5);
            this.c2iPanelOmbre5.ForeColor = System.Drawing.Color.Black;
            this.c2iPanelOmbre5.Location = new System.Drawing.Point(12, 343);
            this.c2iPanelOmbre5.LockEdition = false;
            this.m_extModuleAssociator.SetModules(this.c2iPanelOmbre5, "");
            this.c2iPanelOmbre5.Name = "c2iPanelOmbre5";
            this.c2iPanelOmbre5.Size = new System.Drawing.Size(234, 160);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre5, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre5, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre5.TabIndex = 13;
            // 
            // m_lnkTypesLignesGPS
            // 
            this.m_lnkTypesLignesGPS.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkTypesLignesGPS.ForeColor = System.Drawing.Color.Black;
            this.m_lnkTypesLignesGPS.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkTypesLignesGPS.LinkColor = System.Drawing.Color.Black;
            this.m_lnkTypesLignesGPS.Location = new System.Drawing.Point(8, 108);
            this.m_extModuleAssociator.SetModules(this.m_lnkTypesLignesGPS, "");
            this.m_lnkTypesLignesGPS.Name = "m_lnkTypesLignesGPS";
            this.m_lnkTypesLignesGPS.Size = new System.Drawing.Size(193, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTypesLignesGPS, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTypesLignesGPS, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTypesLignesGPS.TabIndex = 15;
            this.m_lnkTypesLignesGPS.TabStop = true;
            this.m_lnkTypesLignesGPS.Text = "GPS line types|20910";
            this.m_lnkTypesLignesGPS.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTypesLignesGPS_LinkClicked);
            // 
            // m_lnkCartesGPS
            // 
            this.m_lnkCartesGPS.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkCartesGPS.ForeColor = System.Drawing.Color.Black;
            this.m_lnkCartesGPS.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkCartesGPS.LinkColor = System.Drawing.Color.Black;
            this.m_lnkCartesGPS.Location = new System.Drawing.Point(8, 92);
            this.m_extModuleAssociator.SetModules(this.m_lnkCartesGPS, "");
            this.m_lnkCartesGPS.Name = "m_lnkCartesGPS";
            this.m_lnkCartesGPS.Size = new System.Drawing.Size(193, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lnkCartesGPS, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkCartesGPS, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkCartesGPS.TabIndex = 14;
            this.m_lnkCartesGPS.TabStop = true;
            this.m_lnkCartesGPS.Text = "GPS maps|20903";
            this.m_lnkCartesGPS.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkCartesGPS_LinkClicked);
            // 
            // m_lnkParametreSchemasDynamiques
            // 
            this.m_lnkParametreSchemasDynamiques.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkParametreSchemasDynamiques.ForeColor = System.Drawing.Color.Black;
            this.m_lnkParametreSchemasDynamiques.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkParametreSchemasDynamiques.LinkColor = System.Drawing.Color.Black;
            this.m_lnkParametreSchemasDynamiques.Location = new System.Drawing.Point(8, 70);
            this.m_extModuleAssociator.SetModules(this.m_lnkParametreSchemasDynamiques, "");
            this.m_lnkParametreSchemasDynamiques.Name = "m_lnkParametreSchemasDynamiques";
            this.m_lnkParametreSchemasDynamiques.Size = new System.Drawing.Size(236, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lnkParametreSchemasDynamiques, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkParametreSchemasDynamiques, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkParametreSchemasDynamiques.TabIndex = 13;
            this.m_lnkParametreSchemasDynamiques.TabStop = true;
            this.m_lnkParametreSchemasDynamiques.Text = "Dynamic network diagram views|20152";
            this.m_lnkParametreSchemasDynamiques.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkParametreSchemasDynamiques_LinkClicked);
            // 
            // m_lnkSymbolesDeBibliotheque
            // 
            this.m_lnkSymbolesDeBibliotheque.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkSymbolesDeBibliotheque.ForeColor = System.Drawing.Color.Black;
            this.m_lnkSymbolesDeBibliotheque.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkSymbolesDeBibliotheque.LinkColor = System.Drawing.Color.Black;
            this.m_lnkSymbolesDeBibliotheque.Location = new System.Drawing.Point(8, 51);
            this.m_extModuleAssociator.SetModules(this.m_lnkSymbolesDeBibliotheque, "");
            this.m_lnkSymbolesDeBibliotheque.Name = "m_lnkSymbolesDeBibliotheque";
            this.m_lnkSymbolesDeBibliotheque.Size = new System.Drawing.Size(144, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSymbolesDeBibliotheque, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSymbolesDeBibliotheque, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSymbolesDeBibliotheque.TabIndex = 12;
            this.m_lnkSymbolesDeBibliotheque.TabStop = true;
            this.m_lnkSymbolesDeBibliotheque.Text = "Library symbols|30028";
            this.m_lnkSymbolesDeBibliotheque.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkSymbolesDeBibliotheque_LinkClicked);
            // 
            // m_lnkFamilleSymboles
            // 
            this.m_lnkFamilleSymboles.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkFamilleSymboles.ForeColor = System.Drawing.Color.Black;
            this.m_lnkFamilleSymboles.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkFamilleSymboles.LinkColor = System.Drawing.Color.Black;
            this.m_lnkFamilleSymboles.Location = new System.Drawing.Point(8, 32);
            this.m_extModuleAssociator.SetModules(this.m_lnkFamilleSymboles, "");
            this.m_lnkFamilleSymboles.Name = "m_lnkFamilleSymboles";
            this.m_lnkFamilleSymboles.Size = new System.Drawing.Size(144, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lnkFamilleSymboles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkFamilleSymboles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkFamilleSymboles.TabIndex = 11;
            this.m_lnkFamilleSymboles.TabStop = true;
            this.m_lnkFamilleSymboles.Text = "Symbol families|30027";
            this.m_lnkFamilleSymboles.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkFamilleSymboles_LinkClicked);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.SteelBlue;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Beige;
            this.label5.Location = new System.Drawing.Point(4, 4);
            this.m_extModuleAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(210, 23);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTitrePanel);
            this.label5.TabIndex = 4;
            this.label5.Text = "Symbols|20046";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c2iPanelOmbre6
            // 
            this.c2iPanelOmbre6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre6.Controls.Add(this.m_lnkModeleEtiquette);
            this.c2iPanelOmbre6.Controls.Add(this.m_lnkTypeSchemaReseau);
            this.c2iPanelOmbre6.Controls.Add(this.m_lnkLienReseau);
            this.c2iPanelOmbre6.Controls.Add(this.label6);
            this.c2iPanelOmbre6.Controls.Add(this.m_lnkTypeLienReseau);
            this.c2iPanelOmbre6.Controls.Add(this.m_lnkSchemaReseau);
            this.c2iPanelOmbre6.ForeColor = System.Drawing.Color.Black;
            this.c2iPanelOmbre6.Location = new System.Drawing.Point(292, 343);
            this.c2iPanelOmbre6.LockEdition = false;
            this.m_extModuleAssociator.SetModules(this.c2iPanelOmbre6, "ALIAISONS");
            this.c2iPanelOmbre6.Name = "c2iPanelOmbre6";
            this.c2iPanelOmbre6.Size = new System.Drawing.Size(261, 160);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre6, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre6, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre6.TabIndex = 15;
            // 
            // m_lnkModeleEtiquette
            // 
            this.m_lnkModeleEtiquette.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkModeleEtiquette.ForeColor = System.Drawing.Color.Black;
            this.m_lnkModeleEtiquette.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkModeleEtiquette.LinkColor = System.Drawing.Color.Black;
            this.m_lnkModeleEtiquette.Location = new System.Drawing.Point(8, 116);
            this.m_extModuleAssociator.SetModules(this.m_lnkModeleEtiquette, "");
            this.m_lnkModeleEtiquette.Name = "m_lnkModeleEtiquette";
            this.m_lnkModeleEtiquette.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkModeleEtiquette, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkModeleEtiquette, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkModeleEtiquette.TabIndex = 8;
            this.m_lnkModeleEtiquette.TabStop = true;
            this.m_lnkModeleEtiquette.Text = "Diagram Label Models|30405";
            this.m_lnkModeleEtiquette.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkModeleEtiquette_LinkClicked);
            // 
            // m_lnkTypeSchemaReseau
            // 
            this.m_lnkTypeSchemaReseau.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkTypeSchemaReseau.ForeColor = System.Drawing.Color.Black;
            this.m_lnkTypeSchemaReseau.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkTypeSchemaReseau.LinkColor = System.Drawing.Color.Black;
            this.m_lnkTypeSchemaReseau.Location = new System.Drawing.Point(8, 75);
            this.m_extModuleAssociator.SetModules(this.m_lnkTypeSchemaReseau, "CLIAISONS");
            this.m_lnkTypeSchemaReseau.Name = "m_lnkTypeSchemaReseau";
            this.m_lnkTypeSchemaReseau.Size = new System.Drawing.Size(166, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTypeSchemaReseau, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTypeSchemaReseau, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTypeSchemaReseau.TabIndex = 7;
            this.m_lnkTypeSchemaReseau.TabStop = true;
            this.m_lnkTypeSchemaReseau.Text = "Network diagram types|30388";
            this.m_lnkTypeSchemaReseau.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTypeSchemaReseau_LinkClicked);
            // 
            // m_lnkLienReseau
            // 
            this.m_lnkLienReseau.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkLienReseau.ForeColor = System.Drawing.Color.Black;
            this.m_lnkLienReseau.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkLienReseau.LinkColor = System.Drawing.Color.Black;
            this.m_lnkLienReseau.Location = new System.Drawing.Point(8, 54);
            this.m_extModuleAssociator.SetModules(this.m_lnkLienReseau, "");
            this.m_lnkLienReseau.Name = "m_lnkLienReseau";
            this.m_lnkLienReseau.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkLienReseau, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkLienReseau, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkLienReseau.TabIndex = 5;
            this.m_lnkLienReseau.TabStop = true;
            this.m_lnkLienReseau.Text = "Network links|30348";
            this.m_lnkLienReseau.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkLienReseau_LinkClicked);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.BackColor = System.Drawing.Color.SteelBlue;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Beige;
            this.label6.Location = new System.Drawing.Point(4, 4);
            this.m_extModuleAssociator.SetModules(this.label6, "");
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(236, 23);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTitrePanel);
            this.label6.TabIndex = 4;
            this.label6.Text = "Network|30347";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lnkTypeLienReseau
            // 
            this.m_lnkTypeLienReseau.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkTypeLienReseau.ForeColor = System.Drawing.Color.Black;
            this.m_lnkTypeLienReseau.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkTypeLienReseau.LinkColor = System.Drawing.Color.Black;
            this.m_lnkTypeLienReseau.Location = new System.Drawing.Point(8, 38);
            this.m_extModuleAssociator.SetModules(this.m_lnkTypeLienReseau, "CLIAISONS");
            this.m_lnkTypeLienReseau.Name = "m_lnkTypeLienReseau";
            this.m_lnkTypeLienReseau.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTypeLienReseau, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTypeLienReseau, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTypeLienReseau.TabIndex = 0;
            this.m_lnkTypeLienReseau.TabStop = true;
            this.m_lnkTypeLienReseau.Text = "Network link types|30343";
            this.m_lnkTypeLienReseau.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTypeLienReseau_LinkClicked);
            // 
            // m_lnkSchemaReseau
            // 
            this.m_lnkSchemaReseau.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkSchemaReseau.ForeColor = System.Drawing.Color.Black;
            this.m_lnkSchemaReseau.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkSchemaReseau.LinkColor = System.Drawing.Color.Black;
            this.m_lnkSchemaReseau.Location = new System.Drawing.Point(8, 92);
            this.m_extModuleAssociator.SetModules(this.m_lnkSchemaReseau, "");
            this.m_lnkSchemaReseau.Name = "m_lnkSchemaReseau";
            this.m_lnkSchemaReseau.Size = new System.Drawing.Size(144, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSchemaReseau, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSchemaReseau, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSchemaReseau.TabIndex = 6;
            this.m_lnkSchemaReseau.TabStop = true;
            this.m_lnkSchemaReseau.Text = "Network Diagram|20101";
            this.m_lnkSchemaReseau.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkSchemaReseau_LinkClicked);
            // 
            // c2iPanelOmbre7
            // 
            this.c2iPanelOmbre7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre7.Controls.Add(this.m_lnkLotsValorisation);
            this.c2iPanelOmbre7.Controls.Add(this.m_lnkTypesLivraison);
            this.c2iPanelOmbre7.Controls.Add(this.label7);
            this.c2iPanelOmbre7.Controls.Add(this.m_lnksCommandes);
            this.c2iPanelOmbre7.Controls.Add(this.m_lnkTypesCommandes);
            this.c2iPanelOmbre7.Controls.Add(this.m_lnkLivraisons);
            this.c2iPanelOmbre7.ForeColor = System.Drawing.Color.Black;
            this.c2iPanelOmbre7.Location = new System.Drawing.Point(600, 12);
            this.c2iPanelOmbre7.LockEdition = false;
            this.m_extModuleAssociator.SetModules(this.c2iPanelOmbre7, "");
            this.c2iPanelOmbre7.Name = "c2iPanelOmbre7";
            this.c2iPanelOmbre7.Size = new System.Drawing.Size(261, 158);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre7, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre7, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre7.TabIndex = 13;
            // 
            // m_lnkLotsValorisation
            // 
            this.m_lnkLotsValorisation.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkLotsValorisation.LinkColor = System.Drawing.Color.Black;
            this.m_lnkLotsValorisation.Location = new System.Drawing.Point(8, 122);
            this.m_extModuleAssociator.SetModules(this.m_lnkLotsValorisation, "ASTOCK");
            this.m_lnkLotsValorisation.Name = "m_lnkLotsValorisation";
            this.m_lnkLotsValorisation.Size = new System.Drawing.Size(144, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkLotsValorisation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkLotsValorisation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkLotsValorisation.TabIndex = 11;
            this.m_lnkLotsValorisation.TabStop = true;
            this.m_lnkLotsValorisation.Text = "Valuation lots|20450";
            this.m_lnkLotsValorisation.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkLotsValorisation_LinkClicked);
            // 
            // m_lnkTypesLivraison
            // 
            this.m_lnkTypesLivraison.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkTypesLivraison.LinkColor = System.Drawing.Color.Black;
            this.m_lnkTypesLivraison.Location = new System.Drawing.Point(8, 52);
            this.m_extModuleAssociator.SetModules(this.m_lnkTypesLivraison, "ASTOCK");
            this.m_lnkTypesLivraison.Name = "m_lnkTypesLivraison";
            this.m_lnkTypesLivraison.Size = new System.Drawing.Size(144, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTypesLivraison, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTypesLivraison, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTypesLivraison.TabIndex = 10;
            this.m_lnkTypesLivraison.TabStop = true;
            this.m_lnkTypesLivraison.Text = "Deliveries Types|20421";
            this.m_lnkTypesLivraison.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTypesLivraison_LinkClicked);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.SteelBlue;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Beige;
            this.label7.Location = new System.Drawing.Point(4, 4);
            this.m_extModuleAssociator.SetModules(this.label7, "");
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(236, 20);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 3;
            this.label7.Text = "Stock|20404";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lnksCommandes
            // 
            this.m_lnksCommandes.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnksCommandes.LinkColor = System.Drawing.Color.Black;
            this.m_lnksCommandes.Location = new System.Drawing.Point(8, 80);
            this.m_extModuleAssociator.SetModules(this.m_lnksCommandes, "ASTOCK");
            this.m_lnksCommandes.Name = "m_lnksCommandes";
            this.m_lnksCommandes.Size = new System.Drawing.Size(144, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnksCommandes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnksCommandes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnksCommandes.TabIndex = 4;
            this.m_lnksCommandes.TabStop = true;
            this.m_lnksCommandes.Text = "Orders|20406";
            this.m_lnksCommandes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnksCommandes_LinkClicked);
            // 
            // m_lnkTypesCommandes
            // 
            this.m_lnkTypesCommandes.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkTypesCommandes.LinkColor = System.Drawing.Color.Black;
            this.m_lnkTypesCommandes.Location = new System.Drawing.Point(8, 33);
            this.m_extModuleAssociator.SetModules(this.m_lnkTypesCommandes, "ASTOCK");
            this.m_lnkTypesCommandes.Name = "m_lnkTypesCommandes";
            this.m_lnkTypesCommandes.Size = new System.Drawing.Size(144, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTypesCommandes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTypesCommandes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTypesCommandes.TabIndex = 4;
            this.m_lnkTypesCommandes.TabStop = true;
            this.m_lnkTypesCommandes.Text = "Orders Types|20405";
            this.m_lnkTypesCommandes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTypesCommandes_LinkClicked);
            // 
            // m_lnkLivraisons
            // 
            this.m_lnkLivraisons.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkLivraisons.LinkColor = System.Drawing.Color.Black;
            this.m_lnkLivraisons.Location = new System.Drawing.Point(8, 98);
            this.m_extModuleAssociator.SetModules(this.m_lnkLivraisons, "ASTOCK");
            this.m_lnkLivraisons.Name = "m_lnkLivraisons";
            this.m_lnkLivraisons.Size = new System.Drawing.Size(144, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkLivraisons, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkLivraisons, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkLivraisons.TabIndex = 4;
            this.m_lnkLivraisons.TabStop = true;
            this.m_lnkLivraisons.Text = "Deliveries|20407";
            this.m_lnkLivraisons.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkLivraisons_LinkClicked);
            // 
            // m_panelConsommables
            // 
            this.m_panelConsommables.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelConsommables.Controls.Add(this.label8);
            this.m_panelConsommables.Controls.Add(this.m_lnkTypeConsommables);
            this.m_panelConsommables.Controls.Add(this.m_lnkLotConsommable);
            this.m_panelConsommables.ForeColor = System.Drawing.Color.Black;
            this.m_panelConsommables.Location = new System.Drawing.Point(600, 186);
            this.m_panelConsommables.LockEdition = false;
            this.m_extModuleAssociator.SetModules(this.m_panelConsommables, "");
            this.m_panelConsommables.Name = "m_panelConsommables";
            this.m_panelConsommables.Size = new System.Drawing.Size(261, 158);
            this.m_extStyle.SetStyleBackColor(this.m_panelConsommables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelConsommables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelConsommables.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.SteelBlue;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Beige;
            this.label8.Location = new System.Drawing.Point(4, 4);
            this.m_extModuleAssociator.SetModules(this.label8, "");
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(236, 20);
            this.m_extStyle.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 3;
            this.label8.Text = "Consumables|10373";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lnkTypeConsommables
            // 
            this.m_lnkTypeConsommables.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkTypeConsommables.LinkColor = System.Drawing.Color.Black;
            this.m_lnkTypeConsommables.Location = new System.Drawing.Point(8, 38);
            this.m_extModuleAssociator.SetModules(this.m_lnkTypeConsommables, "ASTOCK");
            this.m_lnkTypeConsommables.Name = "m_lnkTypeConsommables";
            this.m_lnkTypeConsommables.Size = new System.Drawing.Size(158, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTypeConsommables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTypeConsommables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTypeConsommables.TabIndex = 4;
            this.m_lnkTypeConsommables.TabStop = true;
            this.m_lnkTypeConsommables.Text = "Consumables Type|10384";
            this.m_lnkTypeConsommables.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTypeConsommables_LinkClicked);
            // 
            // m_lnkLotConsommable
            // 
            this.m_lnkLotConsommable.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkLotConsommable.LinkColor = System.Drawing.Color.Black;
            this.m_lnkLotConsommable.Location = new System.Drawing.Point(8, 58);
            this.m_extModuleAssociator.SetModules(this.m_lnkLotConsommable, "");
            this.m_lnkLotConsommable.Name = "m_lnkLotConsommable";
            this.m_lnkLotConsommable.Size = new System.Drawing.Size(158, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkLotConsommable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkLotConsommable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkLotConsommable.TabIndex = 4;
            this.m_lnkLotConsommable.TabStop = true;
            this.m_lnkLotConsommable.Text = "Consumables Lot|10385";
            this.m_lnkLotConsommable.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkLotConsommable_LinkClicked);
            // 
            // m_lnkTypesPointsGPS
            // 
            this.m_lnkTypesPointsGPS.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_lnkTypesPointsGPS.ForeColor = System.Drawing.Color.Black;
            this.m_lnkTypesPointsGPS.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkTypesPointsGPS.LinkColor = System.Drawing.Color.Black;
            this.m_lnkTypesPointsGPS.Location = new System.Drawing.Point(8, 127);
            this.m_extModuleAssociator.SetModules(this.m_lnkTypesPointsGPS, "");
            this.m_lnkTypesPointsGPS.Name = "m_lnkTypesPointsGPS";
            this.m_lnkTypesPointsGPS.Size = new System.Drawing.Size(193, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTypesPointsGPS, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTypesPointsGPS, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTypesPointsGPS.TabIndex = 16;
            this.m_lnkTypesPointsGPS.TabStop = true;
            this.m_lnkTypesPointsGPS.Text = "GPS point type|20911";
            this.m_lnkTypesPointsGPS.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTypesPointsGPS_LinkClicked);
            // 
            // CFormMenuPatrimoine
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(881, 505);
            this.Controls.Add(this.m_panelConsommables);
            this.Controls.Add(this.c2iPanelOmbre7);
            this.Controls.Add(this.c2iPanelOmbre6);
            this.Controls.Add(this.m_panCoor);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.Controls.Add(this.c2iPanelOmbre1);
            this.Controls.Add(this.c2iPanelOmbre5);
            this.Controls.Add(this.c2iPanelOmbre2);
            this.m_extModuleAssociator.SetModules(this, "");
            this.Name = "CFormMenuPatrimoine";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondFenetre);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "CFormMenuPatrimoine";
            this.Activated += new System.EventHandler(this.CFormMenuPatrimoine_Activated);
            this.Load += new System.EventHandler(this.CFormMenuPatrimoine_Load);
            this.Enter += new System.EventHandler(this.CFormMenuPatrimoine_Enter);
            this.c2iPanelOmbre3.ResumeLayout(false);
            this.c2iPanelOmbre3.PerformLayout();
            this.c2iPanelOmbre2.ResumeLayout(false);
            this.c2iPanelOmbre2.PerformLayout();
            this.c2iPanelOmbre1.ResumeLayout(false);
            this.c2iPanelOmbre1.PerformLayout();
            this.c2iPanelOmbre4.ResumeLayout(false);
            this.c2iPanelOmbre4.PerformLayout();
            this.m_panCoor.ResumeLayout(false);
            this.m_panCoor.PerformLayout();
            this.m_panCoor_2.ResumeLayout(false);
            this.c2iPanelOmbre5.ResumeLayout(false);
            this.c2iPanelOmbre5.PerformLayout();
            this.c2iPanelOmbre6.ResumeLayout(false);
            this.c2iPanelOmbre6.PerformLayout();
            this.c2iPanelOmbre7.ResumeLayout(false);
            this.c2iPanelOmbre7.PerformLayout();
            this.m_panelConsommables.ResumeLayout(false);
            this.m_panelConsommables.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        public CFormMenuPatrimoine()
        {
            InitializeComponent();

        }



        private void CFormMenuPatrimoine_Load(object sender, System.EventArgs e)
        {
            m_extModuleAssociator.AppliquerConfiguration(CTimosApp.ConfigurationModules);
            try
            {
                IInfoUtilisateur info = CTimosApp.SessionClient.GetInfoUtilisateur();
                m_lnkOptionsGeneralesCoord.Visible = info.GetDonneeDroit(CDroitDeBaseSC2I.c_droitAdministration) != null;
            }
            catch
            {
            }
            
        }

        #region Membres de IFormNavigable
        public event ContexteFormEventHandler AfterGetContexte;
        public event ContexteFormEventHandler AfterInitFromContexte;
        public CContexteFormNavigable GetContexte()
        {
            CContexteFormNavigable contexte =new CContexteFormNavigable(GetType());
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
            // TODO : ajoutez l'implémentation de CFormMenuPatrimoine.System.IDisposable.Dispose
        }

        #endregion



        private void CFormMenuPatrimoine_Enter(object sender, System.EventArgs e)
        {
            CTimosApp.Titre = I.T("Assets management|1");
        }





        private void CFormMenuPatrimoine_Activated(object sender, System.EventArgs e)
        {
        }

        //*************************************************************************************
        // Sites
        //*************************************************************************************

        private void m__LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeTypeSite());
        }

        private void m_lnkSites_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeSite());
        }

        //*************************************************************************************
        // Equipements
        //*************************************************************************************
        private void m_lnkFamilles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeFamillesEquipement());
        }

        private void m_lnkTypeEquipement_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeTypesEquipements());
        }

        private void m_lnkEquipement_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeEquipements());
        }

        private void m_lnkStocks_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeStocks());
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeTypesStocks());
        }

        private void m_lnkStatutsEquipement_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeStatutEquipement());
        }


        //*************************************************************************************
        // Contraintes Ressources
        //*************************************************************************************

        private void m_lnkTypeCle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeTypeRessource());
        }

        private void m_lnkCles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeRessource());
        }

        private void m_lnkTypesCiontrainteAcces_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeTypeContrainte());
        }

        private void m_linkContrainte_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeContrainte());
        }


        //*************************************************************************************
        // Système de coordonnées
        //*************************************************************************************

        private void m_lnkUnite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeUniteCoordonnee());
        }

        private void m_lnkFormatsNumerotation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeFormatNumerotation());
        }

        private void m_lnkSystemeCoordonnees_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeSystemeCoordonnees());
        }

        //------------------------------------------------------------------------------
        private void m_lnkFonctions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeEquipementsLogiques());
        }

        private void m_lnkTypeLienReseau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeTypeLienReseau());
        }

        private void m_lnkLienReseau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeLienReseau());
        }

        private void m_lnkFamilleSymboles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeFamilleSymbole());
        }

        private void m_lnkSymbolesDeBibliotheque_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeSymboleDeBibliotheque());
        }

        private void m_lnkSchemaReseau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeSchemaReseau());
        }

        private void m_lnkTypeSchemaReseau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeTypeSchemaReseau());
        }

        private void m_lnkModeleEtiquette_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeModeleEtiquetteSchema());
        }

        private void m_lnkParametreSchemasDynamiques_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeParametreVueSchemaDynamique());
        }

        private void m_lnkTypesPorts_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeTypesPorts());
        }

        private void m_lnkTypesCommandes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeTypeCommandes());
        }

        private void m_lnksCommandes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeCommandes());
        }

        private void m_lnkTypesLivraison_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeTypeLivraisonEquipements());
        }

        private void m_lnkLivraisons_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeLivraisonEquipements());
        }

        private void m_lnkLotsValorisation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeLotValorisations());
        }

        private void m_lnkOptionsGeneralesCoord_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CFormEditionOptionsGeneralesCoordonnees frm = new CFormEditionOptionsGeneralesCoordonnees();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void m_lnkTypeConsommables_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeTypeConsommable());
        }

        private void m_lnkLotConsommable_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeLotConsommable());
        }

        public virtual string GetTitle()
        {
            return I.T("Assets management|1"); 
        }

        public virtual Image GetImage()
        {
            return Resources.patrimoine;
        }

        private void m_lnkRelevesSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeReleveSite());
        }

        private void m_lnkCartesGPS_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormListeGPSCartes());
        }

        private void m_lnkTypesLignesGPS_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichagePageSansHistorique(new CFormListeGpsTypeLignes());
        }

        private void m_lnkTypesPointsGPS_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichagePageSansHistorique(new CFormListeGpsTypePoints());
        }


    }



}

