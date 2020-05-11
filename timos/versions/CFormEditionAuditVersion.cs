using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using sc2i.common;
using sc2i.data;
using sc2i.data.dynamic;
using sc2i.expression;
using sc2i.win32.common;
using sc2i.win32.navigation;
using sc2i.win32.data;
using sc2i.win32.data.navigation;
using sc2i.win32.data.dynamic;
using sc2i.process;

using timos;
using timos.data;
using timos.data.version;

namespace timos.version
{
    [sc2i.win32.data.navigation.ObjectEditeur(typeof(CAuditVersion))]
    public class CFormEditionAuditVersion : CFormEditionStdTimos, IFormNavigable
	{
		///Indique que le contexte de donnée contient un nouvel audit, 
		///Il ne faut donc pas afficher les données trouvées dans la
		///base, mais uniquement les données nouvelles dans la liste
		///des modifications
		private bool m_bHasNewAuditInContexteDonnee = false;

		#region Designer generated code

		private System.Windows.Forms.Label label1;
        private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre m_panOmbre;
		private Label m_lblLabel;
		private Panel m_panTop;
		private Panel m_panGauche;
		private CReducteurControle m_reducteurTop;
		private Label m_lblDescription;
		private C2iTextBox m_txtDescription;
		private Label m_lblVersionSource;
		private Label m_lblTypeAudit;
		private Label m_lblVersionCible;
		private C2iTextBoxSelectionne m_selectTypeAudit;
		private Button m_btnAuditer;
		private Label m_lblDateAudit;
		private CheckBox m_chkAuditDetaille;
		private CPanelListeSpeedStandard m_panelOperations;
		private sc2i.win32.data.navigation.CCtrlUpDownListeSpeed m_ctrlMD;
		private C2iTextBoxSelectionne m_txtSelectVersionCible;
		private C2iTextBoxSelectionne m_txtSelectVersionSource;
		private CheckBox m_chkUtiliserFormule;
		private C2iTabControl m_tabControl;
		private Crownwood.Magic.Controls.TabPage pageAudit;
		private Crownwood.Magic.Controls.TabPage pageNavigation;
		private CControlParcourResultatAudit m_ctrlParcourAuditVersion;
		private CheckBox m_chkShowNullAddingOperation;
		private CheckBox m_chkShowDeletedObjectFieldValue;
        private System.ComponentModel.IContainer components = null;



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
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionAuditVersion));
            sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn3 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn4 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn5 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn6 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn7 = new sc2i.win32.common.GLColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.m_panOmbre = new sc2i.win32.common.C2iPanelOmbre();
            this.m_panTop = new System.Windows.Forms.Panel();
            this.m_panGauche = new System.Windows.Forms.Panel();
            this.m_chkShowDeletedObjectFieldValue = new System.Windows.Forms.CheckBox();
            this.m_txtSelectVersionSource = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_txtSelectVersionCible = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_chkShowNullAddingOperation = new System.Windows.Forms.CheckBox();
            this.m_chkUtiliserFormule = new System.Windows.Forms.CheckBox();
            this.m_chkAuditDetaille = new System.Windows.Forms.CheckBox();
            this.m_btnAuditer = new System.Windows.Forms.Button();
            this.m_selectTypeAudit = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_txtDescription = new sc2i.win32.common.C2iTextBox();
            this.m_lblVersionSource = new System.Windows.Forms.Label();
            this.m_lblTypeAudit = new System.Windows.Forms.Label();
            this.m_lblDateAudit = new System.Windows.Forms.Label();
            this.m_lblDescription = new System.Windows.Forms.Label();
            this.m_lblLabel = new System.Windows.Forms.Label();
            this.m_lblVersionCible = new System.Windows.Forms.Label();
            this.m_reducteurTop = new sc2i.win32.common.CReducteurControle();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.pageAudit = new Crownwood.Magic.Controls.TabPage();
            this.m_ctrlMD = new sc2i.win32.data.navigation.CCtrlUpDownListeSpeed();
            this.m_panelOperations = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.pageNavigation = new Crownwood.Magic.Controls.TabPage();
            this.m_ctrlParcourAuditVersion = new timos.version.CControlParcourResultatAudit();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            this.m_panOmbre.SuspendLayout();
            this.m_panTop.SuspendLayout();
            this.m_panGauche.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.pageAudit.SuspendLayout();
            this.pageNavigation.SuspendLayout();
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
            this.m_extStyle.SetStyleBackColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelCle
            // 
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(830, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnHistorique
            // 
            this.m_extStyle.SetStyleBackColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label1, "");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4002;
            this.label1.Text = "Label|50";
            // 
            // m_txtLibelle
            // 
            this.m_txtLibelle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_txtLibelle.Location = new System.Drawing.Point(104, 8);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(681, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Label]|30324";
            // 
            // m_panOmbre
            // 
            this.m_panOmbre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panOmbre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panOmbre.Controls.Add(this.m_panTop);
            this.m_panOmbre.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panOmbre, "");
            this.m_panOmbre.Location = new System.Drawing.Point(8, 52);
            this.m_panOmbre.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panOmbre, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panOmbre, "");
            this.m_panOmbre.Name = "m_panOmbre";
            this.m_panOmbre.Size = new System.Drawing.Size(810, 198);
            this.m_extStyle.SetStyleBackColor(this.m_panOmbre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panOmbre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panOmbre.TabIndex = 0;
            // 
            // m_panTop
            // 
            this.m_panTop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panTop.Controls.Add(this.m_panGauche);
            this.m_extLinkField.SetLinkField(this.m_panTop, "");
            this.m_panTop.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panTop, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panTop, "");
            this.m_panTop.Name = "m_panTop";
            this.m_panTop.Size = new System.Drawing.Size(795, 181);
            this.m_extStyle.SetStyleBackColor(this.m_panTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panTop.TabIndex = 4011;
            // 
            // m_panGauche
            // 
            this.m_panGauche.Controls.Add(this.m_chkShowDeletedObjectFieldValue);
            this.m_panGauche.Controls.Add(this.m_txtSelectVersionSource);
            this.m_panGauche.Controls.Add(this.m_txtSelectVersionCible);
            this.m_panGauche.Controls.Add(this.m_chkShowNullAddingOperation);
            this.m_panGauche.Controls.Add(this.m_chkUtiliserFormule);
            this.m_panGauche.Controls.Add(this.m_chkAuditDetaille);
            this.m_panGauche.Controls.Add(this.m_btnAuditer);
            this.m_panGauche.Controls.Add(this.m_selectTypeAudit);
            this.m_panGauche.Controls.Add(this.m_txtDescription);
            this.m_panGauche.Controls.Add(this.m_txtLibelle);
            this.m_panGauche.Controls.Add(this.m_lblVersionSource);
            this.m_panGauche.Controls.Add(this.m_lblTypeAudit);
            this.m_panGauche.Controls.Add(this.m_lblDateAudit);
            this.m_panGauche.Controls.Add(this.m_lblDescription);
            this.m_panGauche.Controls.Add(this.m_lblLabel);
            this.m_panGauche.Controls.Add(this.m_lblVersionCible);
            this.m_panGauche.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panGauche, "");
            this.m_panGauche.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panGauche, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panGauche, "");
            this.m_panGauche.Name = "m_panGauche";
            this.m_panGauche.Size = new System.Drawing.Size(795, 181);
            this.m_extStyle.SetStyleBackColor(this.m_panGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panGauche.TabIndex = 4021;
            // 
            // m_chkShowDeletedObjectFieldValue
            // 
            this.m_chkShowDeletedObjectFieldValue.AutoSize = true;
            this.m_chkShowDeletedObjectFieldValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_chkShowDeletedObjectFieldValue.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_chkShowDeletedObjectFieldValue, "ShowEachDeletedObjetFields");
            this.m_chkShowDeletedObjectFieldValue.Location = new System.Drawing.Point(419, 137);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkShowDeletedObjectFieldValue, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkShowDeletedObjectFieldValue, "");
            this.m_chkShowDeletedObjectFieldValue.Name = "m_chkShowDeletedObjectFieldValue";
            this.m_chkShowDeletedObjectFieldValue.Size = new System.Drawing.Size(157, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkShowDeletedObjectFieldValue, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_chkShowDeletedObjectFieldValue, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_chkShowDeletedObjectFieldValue.TabIndex = 4020;
            this.m_chkShowDeletedObjectFieldValue.Text = "Show deleted values|20029";
            this.m_chkShowDeletedObjectFieldValue.UseVisualStyleBackColor = false;
            // 
            // m_txtSelectVersionSource
            // 
            this.m_txtSelectVersionSource.ElementSelectionne = null;
            this.m_txtSelectVersionSource.FonctionTextNull = null;
            this.m_txtSelectVersionSource.HasLink = true;
            this.m_extLinkField.SetLinkField(this.m_txtSelectVersionSource, "");
            this.m_txtSelectVersionSource.Location = new System.Drawing.Point(104, 136);
            this.m_txtSelectVersionSource.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectVersionSource, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtSelectVersionSource, "");
            this.m_txtSelectVersionSource.Name = "m_txtSelectVersionSource";
            this.m_txtSelectVersionSource.SelectedObject = null;
            this.m_txtSelectVersionSource.Size = new System.Drawing.Size(309, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtSelectVersionSource, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSelectVersionSource, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectVersionSource.TabIndex = 4019;
            this.m_txtSelectVersionSource.TextNull = I.T("Base version|1406");
            this.m_txtSelectVersionSource.ElementSelectionneChanged += new System.EventHandler(this.m_txtSelectVersionSource_ElementSelectionneChanged);
            // 
            // m_txtSelectVersionCible
            // 
            this.m_txtSelectVersionCible.ElementSelectionne = null;
            this.m_txtSelectVersionCible.FonctionTextNull = null;
            this.m_txtSelectVersionCible.HasLink = true;
            this.m_extLinkField.SetLinkField(this.m_txtSelectVersionCible, "");
            this.m_txtSelectVersionCible.Location = new System.Drawing.Point(104, 110);
            this.m_txtSelectVersionCible.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectVersionCible, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtSelectVersionCible, "");
            this.m_txtSelectVersionCible.Name = "m_txtSelectVersionCible";
            this.m_txtSelectVersionCible.SelectedObject = null;
            this.m_txtSelectVersionCible.Size = new System.Drawing.Size(309, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtSelectVersionCible, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSelectVersionCible, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectVersionCible.TabIndex = 4019;
            this.m_txtSelectVersionCible.TextNull = I.T("Base version|1406");
            this.m_txtSelectVersionCible.ElementSelectionneChanged += new System.EventHandler(this.m_txtSelectVersionCible_ElementSelectionneChanged);
            // 
            // m_chkShowNullAddingOperation
            // 
            this.m_chkShowNullAddingOperation.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkShowNullAddingOperation, "");
            this.m_chkShowNullAddingOperation.Location = new System.Drawing.Point(419, 120);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkShowNullAddingOperation, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkShowNullAddingOperation, "");
            this.m_chkShowNullAddingOperation.Name = "m_chkShowNullAddingOperation";
            this.m_chkShowNullAddingOperation.Size = new System.Drawing.Size(190, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkShowNullAddingOperation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkShowNullAddingOperation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkShowNullAddingOperation.TabIndex = 4018;
            this.m_chkShowNullAddingOperation.Text = "Show Null Adding Operations|1443";
            this.m_chkShowNullAddingOperation.UseVisualStyleBackColor = true;
            this.m_chkShowNullAddingOperation.CheckedChanged += new System.EventHandler(this.m_chkUtiliserFormule_CheckedChanged);
            // 
            // m_chkUtiliserFormule
            // 
            this.m_chkUtiliserFormule.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkUtiliserFormule, "");
            this.m_chkUtiliserFormule.Location = new System.Drawing.Point(419, 103);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkUtiliserFormule, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkUtiliserFormule, "");
            this.m_chkUtiliserFormule.Name = "m_chkUtiliserFormule";
            this.m_chkUtiliserFormule.Size = new System.Drawing.Size(147, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkUtiliserFormule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkUtiliserFormule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkUtiliserFormule.TabIndex = 4018;
            this.m_chkUtiliserFormule.Text = "Mapping by Formula|1415";
            this.m_chkUtiliserFormule.UseVisualStyleBackColor = true;
            this.m_chkUtiliserFormule.CheckedChanged += new System.EventHandler(this.m_chkUtiliserFormule_CheckedChanged);
            // 
            // m_chkAuditDetaille
            // 
            this.m_chkAuditDetaille.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkAuditDetaille, "");
            this.m_chkAuditDetaille.Location = new System.Drawing.Point(419, 87);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkAuditDetaille, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkAuditDetaille, "");
            this.m_chkAuditDetaille.Name = "m_chkAuditDetaille";
            this.m_chkAuditDetaille.Size = new System.Drawing.Size(118, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkAuditDetaille, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkAuditDetaille, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkAuditDetaille.TabIndex = 4018;
            this.m_chkAuditDetaille.Text = "Detailed Audit|1410";
            this.m_chkAuditDetaille.UseVisualStyleBackColor = true;
            this.m_chkAuditDetaille.CheckedChanged += new System.EventHandler(this.m_chkAuditDetaille_CheckedChanged);
            // 
            // m_btnAuditer
            // 
            this.m_btnAuditer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.m_extLinkField.SetLinkField(this.m_btnAuditer, "");
            this.m_btnAuditer.Location = new System.Drawing.Point(645, 85);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAuditer, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnAuditer, "");
            this.m_btnAuditer.Name = "m_btnAuditer";
            this.m_btnAuditer.Size = new System.Drawing.Size(140, 73);
            this.m_extStyle.SetStyleBackColor(this.m_btnAuditer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAuditer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAuditer.TabIndex = 4017;
            this.m_btnAuditer.Text = "Run Audit|1411";
            this.m_btnAuditer.UseVisualStyleBackColor = false;
            this.m_btnAuditer.Click += new System.EventHandler(this.m_btnAuditer_Click);
            // 
            // m_selectTypeAudit
            // 
            this.m_selectTypeAudit.ElementSelectionne = null;
            this.m_selectTypeAudit.FonctionTextNull = null;
            this.m_selectTypeAudit.HasLink = true;
            this.m_extLinkField.SetLinkField(this.m_selectTypeAudit, "");
            this.m_selectTypeAudit.Location = new System.Drawing.Point(104, 84);
            this.m_selectTypeAudit.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_selectTypeAudit, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_selectTypeAudit, "");
            this.m_selectTypeAudit.Name = "m_selectTypeAudit";
            this.m_selectTypeAudit.SelectedObject = null;
            this.m_selectTypeAudit.Size = new System.Drawing.Size(309, 21);
            this.m_extStyle.SetStyleBackColor(this.m_selectTypeAudit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_selectTypeAudit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectTypeAudit.TabIndex = 4016;
            this.m_selectTypeAudit.TextNull = "";
            // 
            // m_txtDescription
            // 
            this.m_txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_txtDescription, "Description");
            this.m_txtDescription.Location = new System.Drawing.Point(104, 34);
            this.m_txtDescription.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtDescription, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtDescription, "");
            this.m_txtDescription.Multiline = true;
            this.m_txtDescription.Name = "m_txtDescription";
            this.m_txtDescription.Size = new System.Drawing.Size(681, 44);
            this.m_extStyle.SetStyleBackColor(this.m_txtDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtDescription.TabIndex = 0;
            this.m_txtDescription.Text = "[Description]";
            // 
            // m_lblVersionSource
            // 
            this.m_extLinkField.SetLinkField(this.m_lblVersionSource, "");
            this.m_lblVersionSource.Location = new System.Drawing.Point(4, 140);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblVersionSource, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblVersionSource, "");
            this.m_lblVersionSource.Name = "m_lblVersionSource";
            this.m_lblVersionSource.Size = new System.Drawing.Size(114, 17);
            this.m_extStyle.SetStyleBackColor(this.m_lblVersionSource, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblVersionSource, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblVersionSource.TabIndex = 4005;
            this.m_lblVersionSource.Text = "Source Version|1408";
            // 
            // m_lblTypeAudit
            // 
            this.m_extLinkField.SetLinkField(this.m_lblTypeAudit, "");
            this.m_lblTypeAudit.Location = new System.Drawing.Point(3, 88);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblTypeAudit, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblTypeAudit, "");
            this.m_lblTypeAudit.Name = "m_lblTypeAudit";
            this.m_lblTypeAudit.Size = new System.Drawing.Size(86, 17);
            this.m_extStyle.SetStyleBackColor(this.m_lblTypeAudit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblTypeAudit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblTypeAudit.TabIndex = 4005;
            this.m_lblTypeAudit.Text = "Audit type|1409";
            // 
            // m_lblDateAudit
            // 
            this.m_extLinkField.SetLinkField(this.m_lblDateAudit, "");
            this.m_lblDateAudit.Location = new System.Drawing.Point(104, 164);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblDateAudit, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblDateAudit, "");
            this.m_lblDateAudit.Name = "m_lblDateAudit";
            this.m_lblDateAudit.Size = new System.Drawing.Size(264, 17);
            this.m_extStyle.SetStyleBackColor(this.m_lblDateAudit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblDateAudit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblDateAudit.TabIndex = 4005;
            // 
            // m_lblDescription
            // 
            this.m_extLinkField.SetLinkField(this.m_lblDescription, "");
            this.m_lblDescription.Location = new System.Drawing.Point(4, 37);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblDescription, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblDescription, "");
            this.m_lblDescription.Name = "m_lblDescription";
            this.m_lblDescription.Size = new System.Drawing.Size(86, 17);
            this.m_extStyle.SetStyleBackColor(this.m_lblDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblDescription.TabIndex = 4005;
            this.m_lblDescription.Text = "Description|41";
            // 
            // m_lblLabel
            // 
            this.m_extLinkField.SetLinkField(this.m_lblLabel, "");
            this.m_lblLabel.Location = new System.Drawing.Point(4, 11);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblLabel, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblLabel, "");
            this.m_lblLabel.Name = "m_lblLabel";
            this.m_lblLabel.Size = new System.Drawing.Size(66, 17);
            this.m_extStyle.SetStyleBackColor(this.m_lblLabel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblLabel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblLabel.TabIndex = 4005;
            this.m_lblLabel.Text = "Label|50";
            // 
            // m_lblVersionCible
            // 
            this.m_extLinkField.SetLinkField(this.m_lblVersionCible, "");
            this.m_lblVersionCible.Location = new System.Drawing.Point(3, 114);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblVersionCible, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblVersionCible, "");
            this.m_lblVersionCible.Name = "m_lblVersionCible";
            this.m_lblVersionCible.Size = new System.Drawing.Size(105, 17);
            this.m_extStyle.SetStyleBackColor(this.m_lblVersionCible, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblVersionCible, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblVersionCible.TabIndex = 4005;
            this.m_lblVersionCible.Text = "Target Version|1407";
            // 
            // m_reducteurTop
            // 
            this.m_reducteurTop.ControleAgrandit = this.m_tabControl;
            this.m_reducteurTop.ControleAVoir = this.m_txtLibelle;
            this.m_reducteurTop.ControleReduit = this.m_panOmbre;
            this.m_extLinkField.SetLinkField(this.m_reducteurTop, "");
            this.m_reducteurTop.Location = new System.Drawing.Point(409, 48);
            this.m_reducteurTop.MargeControle = 16;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_reducteurTop, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_reducteurTop.ModePositionnement = sc2i.win32.common.CReducteurControle.EModePositionnement.Haut;
            this.m_extModulesAssociator.SetModules(this.m_reducteurTop, "");
            this.m_reducteurTop.Name = "m_reducteurTop";
            this.m_reducteurTop.Size = new System.Drawing.Size(9, 8);
            this.m_extStyle.SetStyleBackColor(this.m_reducteurTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_reducteurTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_reducteurTop.TabIndex = 4012;
            this.m_reducteurTop.TailleReduite = 32;
            // 
            // m_tabControl
            // 
            this.m_tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_tabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_tabControl.BoldSelectedPage = true;
            this.m_tabControl.ControlBottomOffset = 16;
            this.m_tabControl.ControlRightOffset = 16;
            this.m_tabControl.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_tabControl, "");
            this.m_tabControl.Location = new System.Drawing.Point(8, 256);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.pageAudit;
            this.m_tabControl.Size = new System.Drawing.Size(810, 269);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabControl.TabIndex = 4012;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.pageAudit,
            this.pageNavigation});
            // 
            // pageAudit
            // 
            this.pageAudit.Controls.Add(this.m_ctrlMD);
            this.pageAudit.Controls.Add(this.m_panelOperations);
            this.m_extLinkField.SetLinkField(this.pageAudit, "");
            this.pageAudit.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pageAudit, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pageAudit, "");
            this.pageAudit.Name = "pageAudit";
            this.pageAudit.Size = new System.Drawing.Size(794, 228);
            this.m_extStyle.SetStyleBackColor(this.pageAudit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pageAudit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pageAudit.TabIndex = 10;
            this.pageAudit.Title = "Audit Result|1427";
            // 
            // m_ctrlMD
            // 
            this.m_ctrlMD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_ctrlMD, "");
            this.m_ctrlMD.ListeSpeedGeree = this.m_panelOperations;
            this.m_ctrlMD.Location = new System.Drawing.Point(740, 204);
            this.m_ctrlMD.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_ctrlMD, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_ctrlMD, "");
            this.m_ctrlMD.Name = "m_ctrlMD";
            this.m_ctrlMD.ProprieteNumero = "NumeroOrdre";
            this.m_ctrlMD.Size = new System.Drawing.Size(51, 21);
            this.m_extStyle.SetStyleBackColor(this.m_ctrlMD, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_ctrlMD, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ctrlMD.TabIndex = 4011;
            // 
            // m_panelOperations
            // 
            this.m_panelOperations.AllowArbre = true;
            this.m_panelOperations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelOperations.BoutonAjouterVisible = false;
            this.m_panelOperations.BoutonModifierVisible = false;
            glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "colOrdre";
            glColumn1.Propriete = "NumeroOrdre";
            glColumn1.Text = "Order|782";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 40;
            glColumn2.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn2.ActiveControlItems")));
            glColumn2.BackColor = System.Drawing.Color.Transparent;
            glColumn2.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn2.ForColor = System.Drawing.Color.Black;
            glColumn2.ImageIndex = -1;
            glColumn2.IsCheckColumn = false;
            glColumn2.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn2.Name = "colOperation";
            glColumn2.Propriete = "TypeOperation.Libelle";
            glColumn2.Text = "Operation|592";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 100;
            glColumn3.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn3.ActiveControlItems")));
            glColumn3.BackColor = System.Drawing.Color.Transparent;
            glColumn3.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn3.ForColor = System.Drawing.Color.Black;
            glColumn3.ImageIndex = -1;
            glColumn3.IsCheckColumn = false;
            glColumn3.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn3.Name = "colTypeElement";
            glColumn3.Propriete = "VersionObjet.TypeElementConvivial";
            glColumn3.Text = "Element type|1412";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn3.Width = 100;
            glColumn4.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn4.ActiveControlItems")));
            glColumn4.BackColor = System.Drawing.Color.Transparent;
            glColumn4.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn4.ForColor = System.Drawing.Color.Black;
            glColumn4.ImageIndex = -1;
            glColumn4.IsCheckColumn = false;
            glColumn4.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn4.Name = "colCle";
            glColumn4.Propriete = "VersionObjet.Cle";
            glColumn4.Text = "Key|43";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn4.Width = 100;
            glColumn5.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn5.ActiveControlItems")));
            glColumn5.BackColor = System.Drawing.Color.Transparent;
            glColumn5.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn5.ForColor = System.Drawing.Color.Black;
            glColumn5.ImageIndex = -1;
            glColumn5.IsCheckColumn = false;
            glColumn5.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn5.Name = "colChamp";
            glColumn5.Propriete = "NomChampConvivial";
            glColumn5.Text = "Field|85";
            glColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn5.Width = 100;
            glColumn6.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn6.ActiveControlItems")));
            glColumn6.BackColor = System.Drawing.Color.Transparent;
            glColumn6.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn6.ForColor = System.Drawing.Color.Black;
            glColumn6.ImageIndex = -1;
            glColumn6.IsCheckColumn = false;
            glColumn6.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn6.Name = "colValeurSource";
            glColumn6.Propriete = "ValChampSourceString";
            glColumn6.Text = "Source value|1413";
            glColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn6.Width = 200;
            glColumn7.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn7.ActiveControlItems")));
            glColumn7.BackColor = System.Drawing.Color.Transparent;
            glColumn7.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn7.ForColor = System.Drawing.Color.Black;
            glColumn7.ImageIndex = -1;
            glColumn7.IsCheckColumn = false;
            glColumn7.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn7.Name = "colValeurCible";
            glColumn7.Propriete = "ValChampCibleString";
            glColumn7.Text = "Target value|1414";
            glColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn7.Width = 200;
            this.m_panelOperations.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1,
            glColumn2,
            glColumn3,
            glColumn4,
            glColumn5,
            glColumn6,
            glColumn7});
            this.m_panelOperations.ContexteUtilisation = "";
            this.m_panelOperations.ControlFiltreStandard = null;
            this.m_panelOperations.ElementSelectionne = null;
            this.m_panelOperations.EnableCustomisation = true;
            this.m_panelOperations.FiltreDeBase = null;
            this.m_panelOperations.FiltreDeBaseEnAjout = false;
            this.m_panelOperations.FiltrePrefere = null;
            this.m_panelOperations.FiltreRapide = null;
            this.m_extLinkField.SetLinkField(this.m_panelOperations, "");
            this.m_panelOperations.ListeObjets = null;
            this.m_panelOperations.Location = new System.Drawing.Point(3, 3);
            this.m_panelOperations.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelOperations, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelOperations.ModeQuickSearch = false;
            this.m_panelOperations.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_panelOperations, "");
            this.m_panelOperations.MultiSelect = false;
            this.m_panelOperations.Name = "m_panelOperations";
            this.m_panelOperations.Navigateur = null;
            this.m_panelOperations.ProprieteObjetAEditer = null;
            this.m_panelOperations.QuickSearchText = "";
            this.m_panelOperations.Size = new System.Drawing.Size(788, 195);
            this.m_extStyle.SetStyleBackColor(this.m_panelOperations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelOperations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelOperations.TabIndex = 0;
            this.m_panelOperations.TrierAuClicSurEnteteColonne = false;
            // 
            // pageNavigation
            // 
            this.pageNavigation.Controls.Add(this.m_ctrlParcourAuditVersion);
            this.m_extLinkField.SetLinkField(this.pageNavigation, "");
            this.pageNavigation.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pageNavigation, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pageNavigation, "");
            this.pageNavigation.Name = "pageNavigation";
            this.pageNavigation.Selected = false;
            this.pageNavigation.Size = new System.Drawing.Size(794, 228);
            this.m_extStyle.SetStyleBackColor(this.pageNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pageNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pageNavigation.TabIndex = 11;
            this.pageNavigation.Title = "Browse...|1428";
            // 
            // m_ctrlParcourAuditVersion
            // 
            this.m_ctrlParcourAuditVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_ctrlParcourAuditVersion, "");
            this.m_ctrlParcourAuditVersion.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_ctrlParcourAuditVersion, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_ctrlParcourAuditVersion, "");
            this.m_ctrlParcourAuditVersion.Name = "m_ctrlParcourAuditVersion";
            this.m_ctrlParcourAuditVersion.Size = new System.Drawing.Size(794, 228);
            this.m_extStyle.SetStyleBackColor(this.m_ctrlParcourAuditVersion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_ctrlParcourAuditVersion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ctrlParcourAuditVersion.TabIndex = 0;
            // 
            // CFormEditionAuditVersion
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.m_reducteurTop);
            this.Controls.Add(this.m_panOmbre);
            this.Controls.Add(this.m_tabControl);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionAuditVersion";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Controls.SetChildIndex(this.m_tabControl, 0);
            this.Controls.SetChildIndex(this.m_panOmbre, 0);
            this.Controls.SetChildIndex(this.m_reducteurTop, 0);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            this.m_panOmbre.ResumeLayout(false);
            this.m_panOmbre.PerformLayout();
            this.m_panTop.ResumeLayout(false);
            this.m_panGauche.ResumeLayout(false);
            this.m_panGauche.PerformLayout();
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.pageAudit.ResumeLayout(false);
            this.pageNavigation.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		

	
		#endregion

		public CFormEditionAuditVersion()
            : base()
        {
            InitializeComponent();
        }
        //-------------------------------------------------------------------------
		public CFormEditionAuditVersion(CAuditVersion audit)
			: base(audit)
        {
            InitializeComponent();
        }
        //-------------------------------------------------------------------------
		public CFormEditionAuditVersion(CAuditVersion audit, CListeObjetsDonnees liste)
			: base(audit, liste)
        {
            InitializeComponent();
		}


		private bool m_bModeArchive = false;

		private bool m_bInitialise;
		//--------------------------------------------------------------------------------------
		private CAuditVersion Audit
        {
			get 
            {
				return (CAuditVersion)ObjetEdite; 
            }
		}

		private bool EnEdition
		{
			get
			{
				return m_gestionnaireModeEdition.ModeEdition;
			}
		}
		public static string GetTextNullVersionBase()
		{
			return I.T("Base version|1406");
		}

		private CFiltreData m_filtreVArchive = new CFiltreData(CVersionDonnees.c_champTypeVersion + " <> @1", (int)CTypeVersion.TypeVersion.Archive);
		//-------------------------------------------------------------------------
        protected override CResultAErreur MyInitChamps()
        {
			m_bInitialise = false;
            CResultAErreur result = base.MyInitChamps();

			m_bHasNewAuditInContexteDonnee = false;

			m_txtSelectVersionCible.FonctionTextNull = GetTextNullVersionBase;
			m_txtSelectVersionSource.FonctionTextNull = GetTextNullVersionBase;

			AffecterTitre(I.T( "Audit @1 for version|1400", Audit.Libelle));


			m_bModeArchive = Audit.IsArchive;

			//m_btnAuditer.Enabled = false;
			//m_txtSelectVersionSource.Enabled = false;

			m_chkAuditDetaille.Checked = Audit.AuditDetaille;
			m_chkUtiliserFormule.Checked = Audit.MappageParFormule;
			m_chkShowNullAddingOperation.Checked = Audit.ShowNullAddingOperations;
			
			//ActualiserChksBox();
			InitTypesAudit();
			InitVersionCible();
			InitDateAudit();
			InitPanelOperations();

			m_ctrlParcourAuditVersion.Init(Audit);

			bool bModeEdition = m_gestionnaireModeEdition.ModeEdition;

			m_btnAuditer.Visible = !m_bModeArchive && bModeEdition;
			m_chkAuditDetaille.Enabled = !m_bModeArchive && bModeEdition;
			m_chkUtiliserFormule.Enabled = !m_bModeArchive && bModeEdition;
			m_chkShowDeletedObjectFieldValue.Enabled = !m_bModeArchive && bModeEdition;
			m_chkShowNullAddingOperation.Enabled = !m_bModeArchive && bModeEdition;
			m_txtSelectVersionSource.Enabled = !m_bModeArchive && bModeEdition;
			m_txtSelectVersionCible.Enabled = !m_bModeArchive && bModeEdition;
			m_selectTypeAudit.Enabled = !m_bModeArchive && bModeEdition;

			m_bInitialise = true;
            return result;
		}
		protected override CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = base.MAJ_Champs();

			if (!m_bModeArchive)
			{
				Audit.TypeAudit = (CTypeAuditVersion)m_selectTypeAudit.ElementSelectionne;
				Audit.AuditDetaille = m_chkAuditDetaille.Checked;
				Audit.MappageParFormule = m_chkUtiliserFormule.Checked;
				Audit.ShowNullAddingOperations = m_chkShowNullAddingOperation.Checked;
				Audit.VersionCible = (CVersionDonnees)m_txtSelectVersionCible.ElementSelectionne;
				if (Audit.VersionCible != null)
					Audit.NomVersionCible = Audit.VersionCible.Libelle;
				Audit.VersionSource = (CVersionDonnees)m_txtSelectVersionSource.ElementSelectionne;
				if (Audit.VersionSource != null)
					Audit.NomVersionSource = Audit.VersionSource.Libelle;
			}
			return result;
		}

		private void InitTypesAudit()
		{
			m_selectTypeAudit.Init<CTypeAuditVersion>(
                "Libelle", 
                true);
			m_selectTypeAudit.ElementSelectionne = Audit.TypeAudit;
		}
		private void InitVersionSource()
		{
			if (m_bModeArchive)
			{
				m_txtSelectVersionSource.Text = Audit.NomVersionSource;
				return;
			}
			if (!m_chkUtiliserFormule.Checked)
			{
				CVersionDonnees vParente = null;
				if (VersionCible != null)
					vParente = VersionCible.VersionParente;
				string strIDs = "";
				CVersionDonnees versionSel = null;
				while (vParente != null)
				{
					if (Audit.VersionSource != null &&
						Audit.VersionSource.Id == vParente.Id)
						versionSel = Audit.VersionSource;
					strIDs += vParente.Id + ",";
					vParente = vParente.VersionParente;
				}
                CFiltreData filtre = null;
				if (strIDs != "")
				{
					strIDs = strIDs.Substring(0, strIDs.Length - 1);
					filtre = new CFiltreData(CVersionDonnees.c_champId + " in(" + strIDs + ")");
					m_txtSelectVersionSource.InitAvecFiltreDeBase<CVersionDonnees>("Libelle", filtre, true);
				}
				else
				{
                    filtre = new CFiltreDataImpossible();
					m_txtSelectVersionSource.InitAvecFiltreDeBase<CVersionDonnees>("Libelle", filtre, true);
				}
				m_txtSelectVersionSource.ElementSelectionne = versionSel;
			}
			else
			{
				//Toutes versions possibles
				CFiltreData filtre = null;
				filtre = new CFiltreData(CVersionDonnees.c_champTypeVersion + " = @1", (int)CTypeVersion.TypeVersion.Previsionnelle);
				m_txtSelectVersionSource.InitAvecFiltreDeBase<CVersionDonnees>("Libelle", filtre, true);
				m_txtSelectVersionSource.ElementSelectionne = Audit.VersionSource;
			}
		}
		private void InitVersionCible()
		{
			if (m_bModeArchive)
			{
				m_txtSelectVersionCible.Text = Audit.NomVersionCible;
				InitVersionSource();
				return;
			}
			CFiltreData filtre = new CFiltreData(CVersionDonnees.c_champTypeVersion + " = @1", (int)CTypeVersion.TypeVersion.Previsionnelle);
			m_txtSelectVersionCible.InitAvecFiltreDeBase<CVersionDonnees>("Libelle", filtre, true);
			m_txtSelectVersionCible.ElementSelectionne = Audit.VersionCible;
			InitVersionSource();
		}
		private CVersionDonnees VersionSource
		{
			get
			{
				return m_txtSelectVersionSource.ElementSelectionne == null ? null : (CVersionDonnees)m_txtSelectVersionSource.ElementSelectionne;
			}
		}
		private CVersionDonnees VersionCible
		{
			get
			{
				return m_txtSelectVersionCible.ElementSelectionne == null ? null : (CVersionDonnees)m_txtSelectVersionCible.ElementSelectionne;
			}
		}

	

		//EVENEMENTS
		private void m_btnAuditer_Click(object sender, EventArgs e)
		{
			Audit.VersionSource = VersionSource;
			Audit.VersionCible = VersionCible;
			Audit.AuditDetaille = m_chkAuditDetaille.Checked;
			Audit.MappageParFormule = m_chkUtiliserFormule.Checked;
			Audit.ShowNullAddingOperations = m_chkShowNullAddingOperation.Checked;
			Audit.ShowEachDeletedObjetFields = m_chkShowDeletedObjectFieldValue.Checked;
			Audit.TypeAudit = (CTypeAuditVersion)m_selectTypeAudit.ElementSelectionne;
			using (CWaitCursor waiter = new CWaitCursor())
			{
				CResultAErreur result = Audit.Auditer();
				if (!result)
				{
					CFormAlerte.Afficher(result.Erreur);
					return;
				}
				m_bHasNewAuditInContexteDonnee = true;
				InitPanelOperations();
			}
			InitDateAudit();
			m_ctrlParcourAuditVersion.ActualiserAffichage();
		}
		private void InitDateAudit()
		{
			if (Audit.DateRealisationAudit.HasValue)
				m_lblDateAudit.Text = I.T("Audit executed the @1|1401", Audit.DateRealisationAudit.Value.ToShortDateString());
			else
				m_lblDateAudit.Text = I.T("Audit to execute|1402");
		}

		private void m_txtSelectVersionCible_ElementSelectionneChanged(object sender, EventArgs e)
		{
			InitVersionSource();
			ChangementParametrage();
		}
		private void m_txtSelectVersionSource_ElementSelectionneChanged(object sender, EventArgs e)
		{
			ChangementParametrage();
		}


		private void m_chkAuditDetaille_CheckedChanged(object sender, EventArgs e)
		{

			ChangementParametrage();
		}
		private void m_chkUtiliserFormule_CheckedChanged(object sender, EventArgs e)
		{
			
			ChangementParametrage();
			if (m_bInitialise)
			{
				Audit.VersionSource = (CVersionDonnees)m_txtSelectVersionSource.ElementSelectionne;
				InitVersionSource();
			}
		}

		private void ChangementParametrage()
		{
			if (m_bInitialise)
			{
				Audit.DateRealisationAudit = null;
				InitDateAudit();
				ActualiserChksBox();
			}
		}
		private void ActualiserChksBox()
		{
			m_chkAuditDetaille.Enabled = !m_chkUtiliserFormule.Checked && m_gestionnaireModeEdition.ModeEdition;
			if(!m_chkAuditDetaille.Enabled)
			{
				bool bOldValue = m_bInitialise;
				m_bInitialise = false;
				m_chkAuditDetaille.Checked = false;
				m_bInitialise = bOldValue;
			}
		}

		private void InitPanelOperations()
		{
			bool bModeContexteLocal = false;
			if (m_gestionnaireModeEdition.ModeEdition)
			{
				if ( m_bHasNewAuditInContexteDonnee )
				{
					//Il y a des éléments non sauvegardés, donc l'audit vient d'être fait.
					//On ne peut donc pas filtrer, puisque les filtres sont des filtres avancés
					//et qu'ils ont besoin de la base de données pour fonctionner
					//interdit les filtres et remplit
					//La liste avec les modifications contenus dans le contexte
					m_panelOperations.BoutonFiltrerVisible = false;
					CListeObjetsDonnees listeOperations = new CListeObjetsDonnees(
						Audit.ContexteDonnee, 
						typeof(CAuditVersionObjetOperation));
					listeOperations.Filtre = new CFiltreData(
						CAuditVersionObjetOperation.c_champId + "<0");
					listeOperations.InterditLectureInDB = true;
					listeOperations.PreserveChanges = true;
					listeOperations.Tri = CAuditVersionObjetOperation.c_champNumOrdre;
					m_panelOperations.InitFromListeObjets(
						listeOperations, typeof(CAuditVersionObjetOperation), null, null, "");
					//Il faut remplir la grille sans timer car sinon,
					//La liste associée à la grille est la liste qui pointe sur les
					//anciens objets. en sortie de cette fonction, la glacial list du
					//m_panelOperations se redessine, et il recharge les anciens éléments
					//qui ont étés supprimés !
					m_panelOperations.RemplirGrilleSansTimer();
					bModeContexteLocal = true;
				}
			}
			if ( !bModeContexteLocal )
			{
				//Autoriser les filtres
				CFiltreData filtre = new CFiltreDataAvance(
					CAuditVersionObjetOperation.c_nomTable,
					CAuditVersionObjet.c_nomTable + "." +
					CAuditVersion.c_champId + "=@1",
					Audit.Id);
				CListeObjetsDonnees listeOperations = new CListeObjetsDonnees(Audit.ContexteDonnee, typeof(CAuditVersionObjetOperation), filtre);
				m_panelOperations.BoutonFiltrerVisible = true;
				listeOperations.RemplissageProgressif = true;
				listeOperations.Tri = CAuditVersionObjetOperation.c_champNumOrdre;
				m_panelOperations.InitFromListeObjets(
					listeOperations, typeof(CAuditVersionObjetOperation),
					null,
					null,
					"");
			}
			
			/*auditsObjets.ReadDependances("Datas");
			CListeObjetsDonnees listeTmp = auditsObjets.GetDependances("Datas");
			listeTmp.InterditLectureInDB = true;
			int nNb = listeTmp.Count;
			listeTmp.Tri = CAuditVersionObjetOperation.c_champNumOrdre;
			listeTmp.InterditLectureInDB = true;
			m_panelOperations.InitFromListeObjets(
				listeTmp,
				typeof(CAuditVersionObjetOperation),
				null,
				null,
				"");*/
			m_panelOperations.RemplirGrille();
		}
	}
}

