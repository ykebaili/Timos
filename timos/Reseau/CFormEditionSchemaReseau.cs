using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using sc2i.data.dynamic;
using sc2i.data;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.common;
using sc2i.win32.data;
using sc2i.win32.common;

using timos.data;
using timos.securite;
using timos.data.reseau.graphe;
using timos.data.reseau.arbre_operationnel;
using timos.Reseau;
using timos.supervision.vueanimee;

namespace timos
{
    [sc2i.win32.data.navigation.ObjectEditeur(typeof(CSchemaReseau))]
    public class CFormEditionSchemaReseau : CFormEditionStdTimos, IFormNavigable
    {
        #region Designer generated code

        private System.Windows.Forms.Label label1;
        private sc2i.win32.common.C2iTextBox m_txtLibelle;
        private sc2i.win32.common.C2iPanelOmbre m_panelTop;
        private Label m_lblLabel;
        private System.ComponentModel.IContainer components = null;
        private sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee m_gestionnaireTypeSupporte;

        private Label label2;
        private C2iTabControl m_tabControl;
        private Crownwood.Magic.Controls.TabPage m_pageChamps;
        private Crownwood.Magic.Controls.TabPage m_pageSchema;
        private Crownwood.Magic.Controls.TabPage m_pageSymbole;
        private CPanelSymboleElement m_panelSymbole;
        private CheckBox m_chkSymboleImage;
        private sc2i.win32.data.dynamic.CPanelChampsCustom m_panelChamps;
        private timos.Reseau.CEditeurSchemaReseau m_editeurSchema;
        private C2iTextBoxSelectionne m_cmbTypeSchemaReseau;
        private CCtrlSauvegardeProfilDesigner m_ctrlSavProfilDesigner;
        private CReducteurControle cReducteurControle1;
        private Label m_lblInfoSchema;
        private Crownwood.Magic.Controls.TabPage m_pageEos;
        private CPanelAffectationEO m_panelEOS;
        private Label label3;
        private C2iComboBox m_cmbModeOperationnel;
        private LinkLabel m_lnkSuperviser;
        private Label label4;
        private Label label5;
        private C2iTextBoxNumerique c2iTextBoxNumerique1;
        private sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee m_gestionnaireTypeEstSupporte;

        //-------------------------------------------------------------------------
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
            this.components = new System.ComponentModel.Container();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.m_panelTop = new sc2i.win32.common.C2iPanelOmbre();
            this.m_lnkSuperviser = new System.Windows.Forms.LinkLabel();
            this.m_cmbModeOperationnel = new sc2i.win32.common.C2iComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_lblLabel = new System.Windows.Forms.Label();
            this.m_lblInfoSchema = new System.Windows.Forms.Label();
            this.m_cmbTypeSchemaReseau = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.label1 = new System.Windows.Forms.Label();
            this.m_gestionnaireTypeSupporte = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.m_gestionnaireTypeEstSupporte = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageChamps = new Crownwood.Magic.Controls.TabPage();
            this.m_panelChamps = new sc2i.win32.data.dynamic.CPanelChampsCustom();
            this.m_pageSchema = new Crownwood.Magic.Controls.TabPage();
            this.m_editeurSchema = new timos.Reseau.CEditeurSchemaReseau();
            this.m_pageEos = new Crownwood.Magic.Controls.TabPage();
            this.m_panelEOS = new timos.CPanelAffectationEO();
            this.m_pageSymbole = new Crownwood.Magic.Controls.TabPage();
            this.m_chkSymboleImage = new System.Windows.Forms.CheckBox();
            this.m_panelSymbole = new timos.CPanelSymboleElement();
            this.m_ctrlSavProfilDesigner = new timos.CCtrlSauvegardeProfilDesigner();
            this.cReducteurControle1 = new sc2i.win32.common.CReducteurControle();
            this.label4 = new System.Windows.Forms.Label();
            this.c2iTextBoxNumerique1 = new sc2i.win32.common.C2iTextBoxNumerique();
            this.label5 = new System.Windows.Forms.Label();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.m_panelTop.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.m_pageChamps.SuspendLayout();
            this.m_pageSchema.SuspendLayout();
            this.m_pageEos.SuspendLayout();
            this.m_pageSymbole.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnAnnulerModifications
            // 
            this.m_extLinkField.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAnnulerModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnValiderModifications
            // 
            this.m_extLinkField.SetLinkField(this.m_btnValiderModifications, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnValiderModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnSupprimerObjet
            // 
            this.m_extLinkField.SetLinkField(this.m_btnSupprimerObjet, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnSupprimerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnEditerObjet
            // 
            this.m_extLinkField.SetLinkField(this.m_btnEditerObjet, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnEditerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelNavigation
            // 
            this.m_panelNavigation.Location = new System.Drawing.Point(677, 0);
            this.m_panelNavigation.Size = new System.Drawing.Size(153, 34);
            this.m_extStyle.SetStyleBackColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_lblNbListes
            // 
            this.m_extStyle.SetStyleBackColor(this.m_lblNbListes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblNbListes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnPrecedent
            // 
            this.m_extStyle.SetStyleBackColor(this.m_btnPrecedent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnPrecedent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnSuivant
            // 
            this.m_extStyle.SetStyleBackColor(this.m_btnSuivant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSuivant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnAjout
            // 
            this.m_extStyle.SetStyleBackColor(this.m_btnAjout, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAjout, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_lblId
            // 
            this.m_extStyle.SetStyleBackColor(this.m_lblId, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblId, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelCle
            // 
            this.m_panelCle.Location = new System.Drawing.Point(590, 0);
            this.m_panelCle.Size = new System.Drawing.Size(87, 34);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(830, 34);
            this.m_extStyle.SetStyleBackColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnHistorique
            // 
            this.m_extStyle.SetStyleBackColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_imageCle
            // 
            this.m_extStyle.SetStyleBackColor(this.m_imageCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_imageCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnChercherObjet
            // 
            this.m_extStyle.SetStyleBackColor(this.m_btnChercherObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnChercherObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_txtLibelle
            // 
            this.m_txtLibelle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_txtLibelle.Location = new System.Drawing.Point(148, 8);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(518, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Libelle]";
            // 
            // m_panelTop
            // 
            this.m_panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelTop.Controls.Add(this.m_lnkSuperviser);
            this.m_panelTop.Controls.Add(this.m_cmbModeOperationnel);
            this.m_panelTop.Controls.Add(this.label3);
            this.m_panelTop.Controls.Add(this.label2);
            this.m_panelTop.Controls.Add(this.m_lblLabel);
            this.m_panelTop.Controls.Add(this.m_txtLibelle);
            this.m_panelTop.Controls.Add(this.m_lblInfoSchema);
            this.m_panelTop.Controls.Add(this.m_cmbTypeSchemaReseau);
            this.m_panelTop.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panelTop, "");
            this.m_panelTop.Location = new System.Drawing.Point(12, 43);
            this.m_panelTop.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelTop, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelTop, "");
            this.m_panelTop.Name = "m_panelTop";
            this.m_panelTop.Size = new System.Drawing.Size(699, 101);
            this.m_extStyle.SetStyleBackColor(this.m_panelTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelTop.TabIndex = 0;
            // 
            // m_lnkSuperviser
            // 
            this.m_lnkSuperviser.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lnkSuperviser, "");
            this.m_lnkSuperviser.Location = new System.Drawing.Point(345, 65);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkSuperviser, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkSuperviser, "ASUPERVISION");
            this.m_lnkSuperviser.Name = "m_lnkSuperviser";
            this.m_lnkSuperviser.Size = new System.Drawing.Size(89, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSuperviser, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSuperviser, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSuperviser.TabIndex = 4011;
            this.m_lnkSuperviser.TabStop = true;
            this.m_lnkSuperviser.Text = "Superviser|20364";
            this.m_lnkSuperviser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkSuperviser_LinkClicked);
            // 
            // m_cmbModeOperationnel
            // 
            this.m_cmbModeOperationnel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbModeOperationnel.FormattingEnabled = true;
            this.m_cmbModeOperationnel.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbModeOperationnel, "");
            this.m_cmbModeOperationnel.Location = new System.Drawing.Point(148, 58);
            this.m_cmbModeOperationnel.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbModeOperationnel, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbModeOperationnel, "");
            this.m_cmbModeOperationnel.Name = "m_cmbModeOperationnel";
            this.m_cmbModeOperationnel.Size = new System.Drawing.Size(154, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbModeOperationnel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbModeOperationnel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbModeOperationnel.TabIndex = 4010;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(3, 62);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 13);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4009;
            this.label3.Text = "Operationnal mode|20150";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(8, 38);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4006;
            this.label2.Text = "Type|54";
            // 
            // m_lblLabel
            // 
            this.m_lblLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_lblLabel.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_lblLabel, "");
            this.m_lblLabel.Location = new System.Drawing.Point(8, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblLabel, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblLabel, "");
            this.m_lblLabel.Name = "m_lblLabel";
            this.m_lblLabel.Size = new System.Drawing.Size(99, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblLabel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblLabel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblLabel.TabIndex = 4005;
            this.m_lblLabel.Text = "Label|50";
            // 
            // m_lblInfoSchema
            // 
            this.m_extLinkField.SetLinkField(this.m_lblInfoSchema, "");
            this.m_lblInfoSchema.Location = new System.Drawing.Point(308, 58);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblInfoSchema, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblInfoSchema, "");
            this.m_lblInfoSchema.Name = "m_lblInfoSchema";
            this.m_lblInfoSchema.Size = new System.Drawing.Size(358, 23);
            this.m_extStyle.SetStyleBackColor(this.m_lblInfoSchema, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblInfoSchema, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblInfoSchema.TabIndex = 4008;
            // 
            // m_cmbTypeSchemaReseau
            // 
            this.m_cmbTypeSchemaReseau.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbTypeSchemaReseau.ElementSelectionne = null;
            this.m_cmbTypeSchemaReseau.FonctionTextNull = null;
            this.m_cmbTypeSchemaReseau.HasLink = true;
            this.m_extLinkField.SetLinkField(this.m_cmbTypeSchemaReseau, "");
            this.m_cmbTypeSchemaReseau.Location = new System.Drawing.Point(148, 34);
            this.m_cmbTypeSchemaReseau.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbTypeSchemaReseau, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbTypeSchemaReseau, "");
            this.m_cmbTypeSchemaReseau.Name = "m_cmbTypeSchemaReseau";
            this.m_cmbTypeSchemaReseau.SelectedObject = null;
            this.m_cmbTypeSchemaReseau.Size = new System.Drawing.Size(518, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbTypeSchemaReseau, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbTypeSchemaReseau, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbTypeSchemaReseau.TabIndex = 4007;
            this.m_cmbTypeSchemaReseau.TextNull = "";
            this.m_cmbTypeSchemaReseau.ElementSelectionneChanged += new System.EventHandler(this.m_cmbTypeSchemaReseau_ElementSelectionneChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label1, "");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4002;
            this.label1.Text = "Site type label:|170";
            // 
            // m_gestionnaireTypeSupporte
            // 
            this.m_gestionnaireTypeSupporte.ObjetEdite = null;
            // 
            // m_gestionnaireTypeEstSupporte
            // 
            this.m_gestionnaireTypeEstSupporte.ObjetEdite = null;
            // 
            // m_tabControl
            // 
            this.m_tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_tabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.m_tabControl.BoldSelectedPage = true;
            this.m_tabControl.ControlBottomOffset = 16;
            this.m_tabControl.ControlRightOffset = 16;
            this.m_tabControl.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_tabControl, "");
            this.m_tabControl.Location = new System.Drawing.Point(12, 147);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 3;
            this.m_tabControl.SelectedTab = this.m_pageSymbole;
            this.m_tabControl.Size = new System.Drawing.Size(818, 320);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabControl.TabIndex = 4004;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageChamps,
            this.m_pageSchema,
            this.m_pageEos,
            this.m_pageSymbole});
            // 
            // m_pageChamps
            // 
            this.m_pageChamps.Controls.Add(this.m_panelChamps);
            this.m_extLinkField.SetLinkField(this.m_pageChamps, "");
            this.m_pageChamps.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageChamps, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageChamps, "");
            this.m_pageChamps.Name = "m_pageChamps";
            this.m_pageChamps.Selected = false;
            this.m_pageChamps.Size = new System.Drawing.Size(802, 279);
            this.m_extStyle.SetStyleBackColor(this.m_pageChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageChamps.TabIndex = 12;
            this.m_pageChamps.Title = "Form|555";
            // 
            // m_panelChamps
            // 
            this.m_panelChamps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelChamps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.m_panelChamps.BoldSelectedPage = true;
            this.m_panelChamps.ControlBottomOffset = 16;
            this.m_panelChamps.ControlRightOffset = 16;
            this.m_panelChamps.ElementEdite = null;
            this.m_panelChamps.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_panelChamps, "");
            this.m_panelChamps.Location = new System.Drawing.Point(3, 3);
            this.m_panelChamps.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelChamps, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelChamps, "");
            this.m_panelChamps.Name = "m_panelChamps";
            this.m_panelChamps.Ombre = true;
            this.m_panelChamps.PositionTop = true;
            this.m_panelChamps.Size = new System.Drawing.Size(801, 273);
            this.m_extStyle.SetStyleBackColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelChamps.TabIndex = 1;
            // 
            // m_pageSchema
            // 
            this.m_pageSchema.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_pageSchema.Controls.Add(this.m_editeurSchema);
            this.m_extLinkField.SetLinkField(this.m_pageSchema, "");
            this.m_pageSchema.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageSchema, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageSchema, "");
            this.m_pageSchema.Name = "m_pageSchema";
            this.m_pageSchema.Selected = false;
            this.m_pageSchema.Size = new System.Drawing.Size(802, 279);
            this.m_extStyle.SetStyleBackColor(this.m_pageSchema, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageSchema, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageSchema.TabIndex = 10;
            this.m_pageSchema.Title = "Diagram|30389";
            // 
            // m_editeurSchema
            // 
            this.m_editeurSchema.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_editeurSchema, "");
            this.m_editeurSchema.Location = new System.Drawing.Point(3, 3);
            this.m_editeurSchema.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_editeurSchema, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_editeurSchema, "");
            this.m_editeurSchema.Name = "m_editeurSchema";
            this.m_editeurSchema.Size = new System.Drawing.Size(799, 247);
            this.m_extStyle.SetStyleBackColor(this.m_editeurSchema, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_editeurSchema, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_editeurSchema.TabIndex = 0;
            // 
            // m_pageEos
            // 
            this.m_pageEos.Controls.Add(this.m_panelEOS);
            this.m_extLinkField.SetLinkField(this.m_pageEos, "");
            this.m_pageEos.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageEos, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageEos, "");
            this.m_pageEos.Name = "m_pageEos";
            this.m_pageEos.Selected = false;
            this.m_pageEos.Size = new System.Drawing.Size(802, 279);
            this.m_extStyle.SetStyleBackColor(this.m_pageEos, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageEos, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageEos.TabIndex = 13;
            this.m_pageEos.Title = "Organizational entities|53";
            // 
            // m_panelEOS
            // 
            this.m_panelEOS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelEOS, "");
            this.m_panelEOS.Location = new System.Drawing.Point(0, 0);
            this.m_panelEOS.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEOS, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelEOS, "");
            this.m_panelEOS.Name = "m_panelEOS";
            this.m_panelEOS.Size = new System.Drawing.Size(802, 279);
            this.m_extStyle.SetStyleBackColor(this.m_panelEOS, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEOS, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEOS.TabIndex = 1;
            // 
            // m_pageSymbole
            // 
            this.m_pageSymbole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_pageSymbole.Controls.Add(this.label5);
            this.m_pageSymbole.Controls.Add(this.c2iTextBoxNumerique1);
            this.m_pageSymbole.Controls.Add(this.label4);
            this.m_pageSymbole.Controls.Add(this.m_chkSymboleImage);
            this.m_pageSymbole.Controls.Add(this.m_panelSymbole);
            this.m_extLinkField.SetLinkField(this.m_pageSymbole, "");
            this.m_pageSymbole.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageSymbole, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageSymbole, "");
            this.m_pageSymbole.Name = "m_pageSymbole";
            this.m_pageSymbole.Size = new System.Drawing.Size(802, 279);
            this.m_extStyle.SetStyleBackColor(this.m_pageSymbole, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageSymbole, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageSymbole.TabIndex = 11;
            this.m_pageSymbole.Title = "Misc.|55";
            // 
            // m_chkSymboleImage
            // 
            this.m_chkSymboleImage.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkSymboleImage, "");
            this.m_chkSymboleImage.Location = new System.Drawing.Point(11, 37);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkSymboleImage, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkSymboleImage, "");
            this.m_chkSymboleImage.Name = "m_chkSymboleImage";
            this.m_chkSymboleImage.Size = new System.Drawing.Size(251, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkSymboleImage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkSymboleImage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkSymboleImage.TabIndex = 1;
            this.m_chkSymboleImage.Text = "Use reduced diagram image as a symbol|30390";
            this.m_chkSymboleImage.UseVisualStyleBackColor = true;
            this.m_chkSymboleImage.CheckedChanged += new System.EventHandler(this.m_chkSymboleImage_CheckedChanged);
            // 
            // m_panelSymbole
            // 
            this.m_panelSymbole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_panelSymbole, "");
            this.m_panelSymbole.Location = new System.Drawing.Point(11, 70);
            this.m_panelSymbole.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelSymbole, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelSymbole, "");
            this.m_panelSymbole.Name = "m_panelSymbole";
            this.m_panelSymbole.Size = new System.Drawing.Size(743, 206);
            this.m_extStyle.SetStyleBackColor(this.m_panelSymbole, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelSymbole, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelSymbole.TabIndex = 0;
            // 
            // m_ctrlSavProfilDesigner
            // 
            this.m_ctrlSavProfilDesigner.Designer = this.m_editeurSchema.Editeur;
            this.m_ctrlSavProfilDesigner.Formulaire = this;
            // 
            // cReducteurControle1
            // 
            this.cReducteurControle1.ControleAgrandit = this.m_tabControl;
            this.cReducteurControle1.ControleAVoir = null;
            this.cReducteurControle1.ControleReduit = this.m_panelTop;
            this.m_extLinkField.SetLinkField(this.cReducteurControle1, "");
            this.cReducteurControle1.Location = new System.Drawing.Point(357, 39);
            this.cReducteurControle1.MargeControle = 5;
            this.m_gestionnaireModeEdition.SetModeEdition(this.cReducteurControle1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.cReducteurControle1.ModePositionnement = sc2i.win32.common.CReducteurControle.EModePositionnement.Haut;
            this.m_extModulesAssociator.SetModules(this.cReducteurControle1, "");
            this.cReducteurControle1.Name = "cReducteurControle1";
            this.cReducteurControle1.Size = new System.Drawing.Size(9, 8);
            this.m_extStyle.SetStyleBackColor(this.cReducteurControle1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.cReducteurControle1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cReducteurControle1.TabIndex = 4005;
            this.cReducteurControle1.TailleReduite = 32;
            // 
            // label4
            // 
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.label4.Location = new System.Drawing.Point(11, 14);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 20);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 2;
            this.label4.Text = "Snmp refresh delay|20480";
            // 
            // c2iTextBoxNumerique1
            // 
            this.c2iTextBoxNumerique1.Arrondi = 0;
            this.c2iTextBoxNumerique1.DecimalAutorise = false;
            this.c2iTextBoxNumerique1.IntValue = 0;
            this.m_extLinkField.SetLinkField(this.c2iTextBoxNumerique1, "DelaiUpdateSnmpSecondes");
            this.c2iTextBoxNumerique1.Location = new System.Drawing.Point(148, 10);
            this.c2iTextBoxNumerique1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBoxNumerique1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBoxNumerique1, "");
            this.c2iTextBoxNumerique1.Name = "c2iTextBoxNumerique1";
            this.c2iTextBoxNumerique1.NullAutorise = false;
            this.c2iTextBoxNumerique1.SelectAllOnEnter = true;
            this.c2iTextBoxNumerique1.Size = new System.Drawing.Size(65, 21);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBoxNumerique1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBoxNumerique1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBoxNumerique1.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.label5.Location = new System.Drawing.Point(216, 14);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 13);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 4;
            this.label5.Text = "s";
            // 
            // CFormEditionSchemaReseau
            // 
            this.ClientSize = new System.Drawing.Size(830, 479);
            this.Controls.Add(this.cReducteurControle1);
            this.Controls.Add(this.m_panelTop);
            this.Controls.Add(this.m_tabControl);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionSchemaReseau";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_tabControl;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionSchemaReseau_OnInitPage);
            this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionSchemaReseau_OnMajChampsPage);
            this.Controls.SetChildIndex(this.m_tabControl, 0);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.m_panelTop, 0);
            this.Controls.SetChildIndex(this.cReducteurControle1, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.m_panelTop.ResumeLayout(false);
            this.m_panelTop.PerformLayout();
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.m_pageChamps.ResumeLayout(false);
            this.m_pageSchema.ResumeLayout(false);
            this.m_pageEos.ResumeLayout(false);
            this.m_pageSymbole.ResumeLayout(false);
            this.m_pageSymbole.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        public CFormEditionSchemaReseau()
            : base()
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }
        //-------------------------------------------------------------------------
        public CFormEditionSchemaReseau(CSchemaReseau type_lien)
            : base(type_lien)
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }
        //-------------------------------------------------------------------------
        public CFormEditionSchemaReseau(CSchemaReseau type_lien, CListeObjetsDonnees liste)
            : base(type_lien, liste)
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }

        //-------------------------------------------------------------------------
        private CSchemaReseau SchemaReseau
        {
            get { return (CSchemaReseau)ObjetEdite; }
        }
        //-------------------------------------------------------------------------
        protected override CResultAErreur MyInitChamps()
        {
            CResultAErreur result = base.MyInitChamps();
            if (!result)
                return result;

            AffecterTitre(SchemaReseau.DescriptionElement);
            
            m_cmbTypeSchemaReseau.Init<CTypeSchemaReseau>(
                "Libelle",
                false);

            string strType;
            string strId;
            string strIdParent;
            if(SchemaReseau.TypeSchemaReseau!=null)
                 strType = SchemaReseau.TypeSchemaReseau.Libelle.ToString();
             if (SchemaReseau != null)
                 strId = SchemaReseau.Id.ToString();
             if (SchemaReseau.SchemaParent != null)
                 strIdParent = SchemaReseau.SchemaParent.Id.ToString();
            m_cmbTypeSchemaReseau.ElementSelectionne = SchemaReseau.TypeSchemaReseau;

            m_chkSymboleImage.Checked = SchemaReseau.UtiliseImageReduite;

            m_cmbModeOperationnel.FillWithEnumALibelle(typeof(CModeOperationnelSchema));
            m_cmbModeOperationnel.SelectedValue = SchemaReseau.CodeModeOperationnel;

            string strInfo = "";
            if (SchemaReseau.SchemaParent != null)
                strInfo = I.T("Schema parent : @1|20134", SchemaReseau.SchemaParent.Libelle);
            if ( SchemaReseau.SiteApparenance != null )
                strInfo = I.T("In Site : @1|20135", SchemaReseau.SiteApparenance.Libelle);
            m_lblInfoSchema.Text = strInfo;

            return result;
        }


        //-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result=CResultAErreur.True;

            result = base.MAJ_Champs();

            SchemaReseau.UtiliseImageReduite=m_chkSymboleImage.Checked;
            SchemaReseau.TypeSchemaReseau = (CTypeSchemaReseau)m_cmbTypeSchemaReseau.ElementSelectionne;

            if (m_cmbModeOperationnel.SelectedValue is int)
                SchemaReseau.CodeModeOperationnel = (int)m_cmbModeOperationnel.SelectedValue;
            return result;
        }



     

        //-------------------------------------------------------------------------
           private CResultAErreur CFormEditionSchemaReseau_OnInitPage(object page)
           {
              CResultAErreur result = CResultAErreur.True;

               if(page == m_pageSchema)
               {
                   C2iSchemaReseau schema = SchemaReseau.GetSchema(ModeEdition);
                 
                   m_editeurSchema.Init(schema, SchemaReseau);

               }
               else if(page==m_pageChamps)
               {
                   InitPanelChamps();
               }
               else if (page == m_pageSymbole)
               {
                   result = m_panelSymbole.InitChamps(SchemaReseau, SchemaReseau.TypeSchemaReseau);
               }
               else if (page == m_pageEos)
               {
                   m_panelEOS.Init(SchemaReseau);
               }
               return result;
        
        
           }
   

        //------------------------------------------------------------------------------------
        private void InitPanelChamps()
        {
            // Initialise le panel des champs personalisés (custom)
			DisplayOrHidePanelChamps();


            if ( m_tabControl.TabPages.Contains ( m_pageChamps ) )
                 m_panelChamps.ElementEdite = SchemaReseau;
        
        }


        //------------------------------------------------------------------------------------
        	private void DisplayOrHidePanelChamps()
            {
                if (SchemaReseau.GetFormulaires().Length == 0)
                {
                    if (m_tabControl.TabPages.Contains(m_pageChamps))
                        m_tabControl.TabPages.Remove(m_pageChamps);
                }
                else
                {
                    if (!m_tabControl.TabPages.Contains(m_pageChamps))
                        m_tabControl.TabPages.Insert(0, m_pageChamps);
                }
            }

        //-------------------------------------------------------------------------
        private CResultAErreur CFormEditionSchemaReseau_OnMajChampsPage(object page)
        {
            CResultAErreur result = CResultAErreur.True;

            if (page == m_pageChamps)
                result = m_panelChamps.MAJ_Champs();

            else if (page == m_pageSymbole)
            {
                result = m_panelSymbole.MAJ_Champs();
            }
            else if (page == m_pageEos)
                result = m_panelEOS.MajChamps();
            else if (page == m_pageSchema)
            {

                C2iSchemaReseau schema = m_editeurSchema.ObjetDeSchema as C2iSchemaReseau;
                SchemaReseau.SetSchema(schema);
            }

            return result;
        }

 



        private void m_cmbTypeSchemaReseau_ElementSelectionneChanged(object sender, EventArgs e)
        {
            SchemaReseau.TypeSchemaReseau = (CTypeSchemaReseau)m_cmbTypeSchemaReseau.ElementSelectionne;

            InitPanelChamps();

            m_panelSymbole.InitChamps(SchemaReseau, SchemaReseau.TypeSchemaReseau);

            DeclencheEvenementChangementDonnee(CTypeSchemaReseau.c_champId);
              
        }

        private void m_chkSymboleImage_CheckedChanged(object sender, EventArgs e)
        {
            SchemaReseau.UtiliseImageReduite = m_chkSymboleImage.Checked;

            m_panelSymbole.InitChamps(SchemaReseau, SchemaReseau.TypeSchemaReseau);
        }

        private void m_lnkSuperviser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CFormSupervisionSchema.Superviser(SchemaReseau, Navigateur);
        }

    }
}

