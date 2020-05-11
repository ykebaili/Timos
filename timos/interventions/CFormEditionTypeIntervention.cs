using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using sc2i.data.dynamic;
using sc2i.data;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.common;
using sc2i.win32.data;
using sc2i.win32.common;

using timos.securite;
using timos.data;
using timos.acteurs;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CTypeIntervention))]
	public class CFormEditionTypeIntervention : CFormEditionStdTimos, IFormNavigable
	{
		private CParametreRemplissageActiviteParIntervention m_parametreRemplissageActivite = null;
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
		private sc2i.win32.common.C2iTabControl m_tabControl;
		private Crownwood.Magic.Controls.TabPage m_pageChampsCustom;
		private Label label2;
		private C2iTextBox c2iTextBox1;
		private Label label3;
        private C2iTextBox c2iTextBox2;
		private Label label4;
		private C2iTextBoxNumerique c2iTextBoxNumerique1;
        private Label label5;
		private timos.win32.composants.CPanelEditDefinisseurChampsCustom m_panelEditChamps;
		private Crownwood.Magic.Controls.TabPage m_pageOperations;
		private Label lbl_ope;
		private C2iTextBoxSelectionne m_selectOperation;
		private CGestionnaireEditionSousObjetDonnee m_gestionnaireOperations;
		private CExtLinkField m_linkOperation;
		private Panel m_panelOperation;
		private Label m_lblTypeOperation;
		private CWndLinkStd m_lnkRemoveOperation;
		private ListViewAutoFilled m_wndListeOperations;
		private ListViewAutoFilledColumn listViewAutoFilledColumn4;
		private ListViewAutoFilledColumn listViewAutoFilledColumn1;
		private CWndLinkStd m_lnkAddOperation;
		private CheckBox m_chkTypeOperationOptional;
		private sc2i.win32.common.CCtrlUpDownListView m_controlMonteDescendre;
		private Crownwood.Magic.Controls.TabPage m_pageContraintes;
		private CPanelListeSpeedStandard m_panelListeContraintes;
		private Crownwood.Magic.Controls.TabPage m_pageIntervenants;
		private Panel m_panelProfilIntervenant;
		private Label label7;
		private CWndLinkStd m_btnRemoveProfilIntervenant;
		private ListViewAutoFilled m_wndListeProfilsIntervenants;
		private ListViewAutoFilledColumn listViewAutoFilledColumn3;
		private CWndLinkStd m_btnAddProfilIntervenant;
		private Label label8;
		private C2iTextBoxSelectionne m_txtSelectProfilIntervenant;
		private Label label9;
		private CExtLinkField m_linkProfilIntervenant;
		private CGestionnaireEditionSousObjetDonnee m_gestionnaireProfilsIntervenants;
		private C2iTextBox c2iTextBox3;
		private ListViewAutoFilledColumn listViewAutoFilledColumn2;
		private Label label10;
        private C2iTextBoxSelectionne m_txtSelectProfil2;
		private Label label11;
		private CComboBoxLinkListeObjetsDonnees m_cmbProfilRessourceDefaut;
		private Crownwood.Magic.Controls.TabPage m_pageContactsPoss;
		private CControlEditionTypeElementAContacts m_ctrlProfilsActeursPossibles;
		private Crownwood.Magic.Controls.TabPage m_pagePlanif;
		private Label label13;
		private Label lbl_profilpreplan;
		private CComboBoxLinkListeObjetsDonnees m_cmbProfilPlanifieur;
		private CComboBoxLinkListeObjetsDonnees m_cmbProfilPrePlanifieur;
        private Crownwood.Magic.Controls.TabPage m_pageEvenements;
        private CPanelDefinisseurEvenements m_panelDefinisseurEvenements;
		private PictureBox pictureBox5;
		private LinkLabel m_lnkParametrerActivite;
		private CComboBoxLinkListeObjetsDonnees m_cmbTypeActivite;
		private Label label15;
        private Label lbl_activite;
        private SplitContainer m_splitContainer1;
        private sc2i.win32.data.dynamic.CPanelEditFiltreDynamique m_editFiltreDynamiqueIntervenants;
        private C2iTabControl m_tab;
        private C2iTabControl c2iTabControl1;
        private C2iTabControl c2iTabControl2;
        private Label label6;
        private CheckBox m_chkMultiple;
        private CheckBox checkBox1;
        private Crownwood.Magic.Controls.TabPage m_pageFormulaires;
        private sc2i.win32.data.dynamic.CPanelChampsCustom m_panelChamps;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionTypeIntervention()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionTypeIntervention(CTypeIntervention TypeIntervention)
			:base(TypeIntervention)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionTypeIntervention(CTypeIntervention TypeIntervention, CListeObjetsDonnees liste)
			:base(TypeIntervention, liste)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionTypeIntervention));
            sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.c2iTextBox2 = new sc2i.win32.common.C2iTextBox();
            this.c2iTextBox1 = new sc2i.win32.common.C2iTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.c2iTextBoxNumerique1 = new sc2i.win32.common.C2iTextBoxNumerique();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageIntervenants = new Crownwood.Magic.Controls.TabPage();
            this.m_splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_btnRemoveProfilIntervenant = new sc2i.win32.common.CWndLinkStd();
            this.m_btnAddProfilIntervenant = new sc2i.win32.common.CWndLinkStd();
            this.m_panelProfilIntervenant = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.m_chkMultiple = new System.Windows.Forms.CheckBox();
            this.m_txtSelectProfil2 = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.label10 = new System.Windows.Forms.Label();
            this.c2iTextBox3 = new sc2i.win32.common.C2iTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.m_wndListeProfilsIntervenants = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn3 = ((sc2i.win32.common.ListViewAutoFilledColumn)(new sc2i.win32.common.ListViewAutoFilledColumn()));
            this.listViewAutoFilledColumn2 = ((sc2i.win32.common.ListViewAutoFilledColumn)(new sc2i.win32.common.ListViewAutoFilledColumn()));
            this.m_txtSelectProfilIntervenant = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_editFiltreDynamiqueIntervenants = new sc2i.win32.data.dynamic.CPanelEditFiltreDynamique();
            this.m_tab = new sc2i.win32.common.C2iTabControl(this.components);
            this.c2iTabControl1 = new sc2i.win32.common.C2iTabControl(this.components);
            this.c2iTabControl2 = new sc2i.win32.common.C2iTabControl(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.m_pageOperations = new Crownwood.Magic.Controls.TabPage();
            this.m_selectOperation = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_controlMonteDescendre = new sc2i.win32.common.CCtrlUpDownListView();
            this.m_wndListeOperations = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn4 = ((sc2i.win32.common.ListViewAutoFilledColumn)(new sc2i.win32.common.ListViewAutoFilledColumn()));
            this.listViewAutoFilledColumn1 = ((sc2i.win32.common.ListViewAutoFilledColumn)(new sc2i.win32.common.ListViewAutoFilledColumn()));
            this.m_panelOperation = new System.Windows.Forms.Panel();
            this.m_chkTypeOperationOptional = new System.Windows.Forms.CheckBox();
            this.m_lblTypeOperation = new System.Windows.Forms.Label();
            this.m_lnkRemoveOperation = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkAddOperation = new sc2i.win32.common.CWndLinkStd();
            this.lbl_ope = new System.Windows.Forms.Label();
            this.m_pageContraintes = new Crownwood.Magic.Controls.TabPage();
            this.m_cmbProfilRessourceDefaut = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.label11 = new System.Windows.Forms.Label();
            this.m_panelListeContraintes = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_pageChampsCustom = new Crownwood.Magic.Controls.TabPage();
            this.m_panelEditChamps = new timos.win32.composants.CPanelEditDefinisseurChampsCustom();
            this.m_pageContactsPoss = new Crownwood.Magic.Controls.TabPage();
            this.m_ctrlProfilsActeursPossibles = new timos.acteurs.CControlEditionTypeElementAContacts();
            this.m_pagePlanif = new Crownwood.Magic.Controls.TabPage();
            this.m_lnkParametrerActivite = new System.Windows.Forms.LinkLabel();
            this.m_cmbTypeActivite = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.label15 = new System.Windows.Forms.Label();
            this.lbl_activite = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.m_cmbProfilPlanifieur = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.m_cmbProfilPrePlanifieur = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.label13 = new System.Windows.Forms.Label();
            this.lbl_profilpreplan = new System.Windows.Forms.Label();
            this.m_pageEvenements = new Crownwood.Magic.Controls.TabPage();
            this.m_panelDefinisseurEvenements = new timos.CPanelDefinisseurEvenements();
            this.m_gestionnaireOperations = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.m_linkOperation = new sc2i.win32.common.CExtLinkField();
            this.m_linkProfilIntervenant = new sc2i.win32.common.CExtLinkField();
            this.m_gestionnaireProfilsIntervenants = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.m_pageFormulaires = new Crownwood.Magic.Controls.TabPage();
            this.m_panelChamps = new sc2i.win32.data.dynamic.CPanelChampsCustom();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.m_pageIntervenants.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_splitContainer1)).BeginInit();
            this.m_splitContainer1.Panel1.SuspendLayout();
            this.m_splitContainer1.Panel2.SuspendLayout();
            this.m_splitContainer1.SuspendLayout();
            this.m_panelProfilIntervenant.SuspendLayout();
            this.m_editFiltreDynamiqueIntervenants.SuspendLayout();
            this.m_pageOperations.SuspendLayout();
            this.m_panelOperation.SuspendLayout();
            this.m_pageContraintes.SuspendLayout();
            this.m_pageChampsCustom.SuspendLayout();
            this.m_pageContactsPoss.SuspendLayout();
            this.m_pagePlanif.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.m_pageEvenements.SuspendLayout();
            this.m_pageFormulaires.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnAnnulerModifications
            // 
            this.m_linkOperation.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_extLinkField.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_linkProfilIntervenant.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_btnAnnulerModifications, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_btnAnnulerModifications, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnAnnulerModifications, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAnnulerModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnValiderModifications
            // 
            this.m_linkOperation.SetLinkField(this.m_btnValiderModifications, "");
            this.m_extLinkField.SetLinkField(this.m_btnValiderModifications, "");
            this.m_linkProfilIntervenant.SetLinkField(this.m_btnValiderModifications, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_btnValiderModifications, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_btnValiderModifications, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnValiderModifications, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnValiderModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnSupprimerObjet
            // 
            this.m_linkOperation.SetLinkField(this.m_btnSupprimerObjet, "");
            this.m_extLinkField.SetLinkField(this.m_btnSupprimerObjet, "");
            this.m_linkProfilIntervenant.SetLinkField(this.m_btnSupprimerObjet, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_btnSupprimerObjet, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_btnSupprimerObjet, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnSupprimerObjet, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnSupprimerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnEditerObjet
            // 
            this.m_linkOperation.SetLinkField(this.m_btnEditerObjet, "");
            this.m_extLinkField.SetLinkField(this.m_btnEditerObjet, "");
            this.m_linkProfilIntervenant.SetLinkField(this.m_btnEditerObjet, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_btnEditerObjet, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_btnEditerObjet, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnEditerObjet, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnEditerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelNavigation
            // 
            this.m_linkOperation.SetLinkField(this.m_panelNavigation, "");
            this.m_extLinkField.SetLinkField(this.m_panelNavigation, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelNavigation, true);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_panelNavigation, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelNavigation, false);
            this.m_panelNavigation.Location = new System.Drawing.Point(623, 0);
            this.m_panelNavigation.Size = new System.Drawing.Size(175, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_lblNbListes
            // 
            this.m_linkOperation.SetLinkField(this.m_lblNbListes, "");
            this.m_extLinkField.SetLinkField(this.m_lblNbListes, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblNbListes, true);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_lblNbListes, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblNbListes, false);
            this.m_extStyle.SetStyleBackColor(this.m_lblNbListes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblNbListes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnPrecedent
            // 
            this.m_linkOperation.SetLinkField(this.m_btnPrecedent, "");
            this.m_extLinkField.SetLinkField(this.m_btnPrecedent, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnPrecedent, true);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_btnPrecedent, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnPrecedent, false);
            this.m_extStyle.SetStyleBackColor(this.m_btnPrecedent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnPrecedent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnSuivant
            // 
            this.m_linkOperation.SetLinkField(this.m_btnSuivant, "");
            this.m_extLinkField.SetLinkField(this.m_btnSuivant, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnSuivant, true);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_btnSuivant, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnSuivant, false);
            this.m_extStyle.SetStyleBackColor(this.m_btnSuivant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSuivant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnAjout
            // 
            this.m_linkOperation.SetLinkField(this.m_btnAjout, "");
            this.m_extLinkField.SetLinkField(this.m_btnAjout, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnAjout, true);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_btnAjout, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnAjout, false);
            this.m_extStyle.SetStyleBackColor(this.m_btnAjout, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAjout, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_lblId
            // 
            this.m_extLinkField.SetLinkField(this.m_lblId, "");
            this.m_linkOperation.SetLinkField(this.m_lblId, "");
            this.m_extLinkField.SetLinkField(this.m_lblId, "");
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_lblId, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblId, false);
            this.m_extStyle.SetStyleBackColor(this.m_lblId, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblId, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelCle
            // 
            this.m_linkOperation.SetLinkField(this.m_panelCle, "");
            this.m_extLinkField.SetLinkField(this.m_panelCle, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelCle, true);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_panelCle, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelCle, false);
            this.m_panelCle.Location = new System.Drawing.Point(536, 0);
            this.m_panelCle.Size = new System.Drawing.Size(87, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_linkOperation.SetLinkField(this.m_panelMenu, "");
            this.m_extLinkField.SetLinkField(this.m_panelMenu, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelMenu, true);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_panelMenu, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelMenu, false);
            this.m_panelMenu.Size = new System.Drawing.Size(830, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnHistorique
            // 
            this.m_extLinkField.SetLinkField(this.m_btnHistorique, "");
            this.m_linkOperation.SetLinkField(this.m_btnHistorique, "");
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_btnHistorique, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnHistorique, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnHistorique, true);
            this.m_extStyle.SetStyleBackColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_imageCle
            // 
            this.m_extLinkField.SetLinkField(this.m_imageCle, "");
            this.m_linkOperation.SetLinkField(this.m_imageCle, "");
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_imageCle, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_imageCle, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_imageCle, true);
            this.m_extStyle.SetStyleBackColor(this.m_imageCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_imageCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnChercherObjet
            // 
            this.m_extLinkField.SetLinkField(this.m_btnChercherObjet, "");
            this.m_linkOperation.SetLinkField(this.m_btnChercherObjet, "");
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_btnChercherObjet, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnChercherObjet, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnChercherObjet, true);
            this.m_extStyle.SetStyleBackColor(this.m_btnChercherObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnChercherObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // label1
            // 
            this.m_linkProfilIntervenant.SetLinkField(this.label1, "");
            this.m_linkOperation.SetLinkField(this.label1, "");
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.label1, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.label1, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label1, false);
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label1, "");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4002;
            this.label1.Text = "Label|50";
            // 
            // m_txtLibelle
            // 
            this.m_txtLibelle.EmptyText = "";
            this.m_linkOperation.SetLinkField(this.m_txtLibelle, "");
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_linkProfilIntervenant.SetLinkField(this.m_txtLibelle, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtLibelle, true);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_txtLibelle, false);
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_txtLibelle, false);
            this.m_txtLibelle.Location = new System.Drawing.Point(76, 8);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(412, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Libelle]";
            // 
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.c2iTextBox2);
            this.c2iPanelOmbre4.Controls.Add(this.c2iTextBox1);
            this.c2iPanelOmbre4.Controls.Add(this.label3);
            this.c2iPanelOmbre4.Controls.Add(this.c2iTextBoxNumerique1);
            this.c2iPanelOmbre4.Controls.Add(this.label5);
            this.c2iPanelOmbre4.Controls.Add(this.label1);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.Controls.Add(this.label2);
            this.c2iPanelOmbre4.Controls.Add(this.label4);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.m_linkOperation.SetLinkField(this.c2iPanelOmbre4, "");
            this.m_linkProfilIntervenant.SetLinkField(this.c2iPanelOmbre4, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.c2iPanelOmbre4, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iPanelOmbre4, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.c2iPanelOmbre4, false);
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(8, 30);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(822, 80);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // c2iTextBox2
            // 
            this.c2iTextBox2.EmptyText = "";
            this.m_linkOperation.SetLinkField(this.c2iTextBox2, "");
            this.m_extLinkField.SetLinkField(this.c2iTextBox2, "Memomnique");
            this.m_linkProfilIntervenant.SetLinkField(this.c2iTextBox2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iTextBox2, true);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.c2iTextBox2, false);
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.c2iTextBox2, false);
            this.c2iTextBox2.Location = new System.Drawing.Point(318, 31);
            this.c2iTextBox2.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox2, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBox2, "");
            this.c2iTextBox2.Name = "c2iTextBox2";
            this.c2iTextBox2.Size = new System.Drawing.Size(170, 20);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox2.TabIndex = 2;
            this.c2iTextBox2.Text = "[Memomnique]";
            // 
            // c2iTextBox1
            // 
            this.c2iTextBox1.EmptyText = "";
            this.m_linkOperation.SetLinkField(this.c2iTextBox1, "");
            this.m_extLinkField.SetLinkField(this.c2iTextBox1, "Code");
            this.m_linkProfilIntervenant.SetLinkField(this.c2iTextBox1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iTextBox1, true);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.c2iTextBox1, false);
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.c2iTextBox1, false);
            this.c2iTextBox1.Location = new System.Drawing.Point(76, 31);
            this.c2iTextBox1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBox1, "");
            this.c2iTextBox1.Name = "c2iTextBox1";
            this.c2iTextBox1.Size = new System.Drawing.Size(120, 20);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox1.TabIndex = 1;
            this.c2iTextBox1.Text = "[Code]";
            // 
            // label3
            // 
            this.m_linkProfilIntervenant.SetLinkField(this.label3, "");
            this.m_linkOperation.SetLinkField(this.label3, "");
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.label3, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.label3, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label3, false);
            this.label3.Location = new System.Drawing.Point(217, 35);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4005;
            this.label3.Text = "Mnemonic |336";
            // 
            // c2iTextBoxNumerique1
            // 
            this.c2iTextBoxNumerique1.Arrondi = 2;
            this.c2iTextBoxNumerique1.DecimalAutorise = false;
            this.c2iTextBoxNumerique1.EmptyText = "";
            this.c2iTextBoxNumerique1.IntValue = 0;
            this.m_linkOperation.SetLinkField(this.c2iTextBoxNumerique1, "");
            this.m_extLinkField.SetLinkField(this.c2iTextBoxNumerique1, "DureeStandardHeures");
            this.m_linkProfilIntervenant.SetLinkField(this.c2iTextBoxNumerique1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iTextBoxNumerique1, true);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.c2iTextBoxNumerique1, false);
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.c2iTextBoxNumerique1, false);
            this.c2iTextBoxNumerique1.Location = new System.Drawing.Point(608, 31);
            this.c2iTextBoxNumerique1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBoxNumerique1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBoxNumerique1, "");
            this.c2iTextBoxNumerique1.Name = "c2iTextBoxNumerique1";
            this.c2iTextBoxNumerique1.NullAutorise = false;
            this.c2iTextBoxNumerique1.SelectAllOnEnter = true;
            this.c2iTextBoxNumerique1.SeparateurMilliers = "";
            this.c2iTextBoxNumerique1.Size = new System.Drawing.Size(69, 20);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBoxNumerique1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBoxNumerique1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBoxNumerique1.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.m_linkProfilIntervenant.SetLinkField(this.label5, "");
            this.m_linkOperation.SetLinkField(this.label5, "");
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.label5, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.label5, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label5, false);
            this.label5.Location = new System.Drawing.Point(683, 35);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 2;
            this.label5.Text = "Hour(s)|343";
            // 
            // label2
            // 
            this.m_linkProfilIntervenant.SetLinkField(this.label2, "");
            this.m_linkOperation.SetLinkField(this.label2, "");
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.label2, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.label2, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label2, false);
            this.label2.Location = new System.Drawing.Point(10, 35);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4003;
            this.label2.Text = "Code|335";
            // 
            // label4
            // 
            this.m_linkProfilIntervenant.SetLinkField(this.label4, "");
            this.m_linkOperation.SetLinkField(this.label4, "");
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.label4, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.label4, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label4, false);
            this.label4.Location = new System.Drawing.Point(507, 35);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 0;
            this.label4.Text = "Standard duration|340";
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
            this.m_tabControl.ForeColor = System.Drawing.Color.Black;
            this.m_tabControl.IDEPixelArea = false;
            this.m_linkProfilIntervenant.SetLinkField(this.m_tabControl, "");
            this.m_linkOperation.SetLinkField(this.m_tabControl, "");
            this.m_extLinkField.SetLinkField(this.m_tabControl, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_tabControl, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_tabControl, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_tabControl, false);
            this.m_tabControl.Location = new System.Drawing.Point(8, 116);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.m_pageFormulaires;
            this.m_tabControl.Size = new System.Drawing.Size(822, 444);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabControl.TabIndex = 4004;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageFormulaires,
            this.m_pageOperations,
            this.m_pageIntervenants,
            this.m_pageContraintes,
            this.m_pageChampsCustom,
            this.m_pageContactsPoss,
            this.m_pagePlanif,
            this.m_pageEvenements});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            this.m_tabControl.SelectionChanged += new System.EventHandler(this.c2iTabControl1_SelectionChanged);
            // 
            // m_pageIntervenants
            // 
            this.m_pageIntervenants.Controls.Add(this.m_splitContainer1);
            this.m_extLinkField.SetLinkField(this.m_pageIntervenants, "");
            this.m_linkOperation.SetLinkField(this.m_pageIntervenants, "");
            this.m_linkProfilIntervenant.SetLinkField(this.m_pageIntervenants, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_pageIntervenants, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageIntervenants, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_pageIntervenants, false);
            this.m_pageIntervenants.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageIntervenants, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageIntervenants, "");
            this.m_pageIntervenants.Name = "m_pageIntervenants";
            this.m_pageIntervenants.Selected = false;
            this.m_pageIntervenants.Size = new System.Drawing.Size(806, 403);
            this.m_extStyle.SetStyleBackColor(this.m_pageIntervenants, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageIntervenants, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageIntervenants.TabIndex = 14;
            this.m_pageIntervenants.Title = "Operators|387";
            // 
            // m_splitContainer1
            // 
            this.m_splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_linkOperation.SetLinkField(this.m_splitContainer1, "");
            this.m_linkProfilIntervenant.SetLinkField(this.m_splitContainer1, "");
            this.m_extLinkField.SetLinkField(this.m_splitContainer1, "");
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_splitContainer1, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_splitContainer1, false);
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_splitContainer1, false);
            this.m_splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_splitContainer1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_splitContainer1, "");
            this.m_splitContainer1.Name = "m_splitContainer1";
            this.m_splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // m_splitContainer1.Panel1
            // 
            this.m_splitContainer1.Panel1.Controls.Add(this.m_btnRemoveProfilIntervenant);
            this.m_splitContainer1.Panel1.Controls.Add(this.m_btnAddProfilIntervenant);
            this.m_splitContainer1.Panel1.Controls.Add(this.m_panelProfilIntervenant);
            this.m_splitContainer1.Panel1.Controls.Add(this.label8);
            this.m_splitContainer1.Panel1.Controls.Add(this.m_wndListeProfilsIntervenants);
            this.m_splitContainer1.Panel1.Controls.Add(this.m_txtSelectProfilIntervenant);
            this.m_extLinkField.SetLinkField(this.m_splitContainer1.Panel1, "");
            this.m_linkOperation.SetLinkField(this.m_splitContainer1.Panel1, "");
            this.m_linkProfilIntervenant.SetLinkField(this.m_splitContainer1.Panel1, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_splitContainer1.Panel1, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_splitContainer1.Panel1, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_splitContainer1.Panel1, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_splitContainer1.Panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_splitContainer1.Panel1, "");
            this.m_extStyle.SetStyleBackColor(this.m_splitContainer1.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainer1.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_splitContainer1.Panel2
            // 
            this.m_splitContainer1.Panel2.Controls.Add(this.m_editFiltreDynamiqueIntervenants);
            this.m_splitContainer1.Panel2.Controls.Add(this.label6);
            this.m_extLinkField.SetLinkField(this.m_splitContainer1.Panel2, "");
            this.m_linkOperation.SetLinkField(this.m_splitContainer1.Panel2, "");
            this.m_linkProfilIntervenant.SetLinkField(this.m_splitContainer1.Panel2, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_splitContainer1.Panel2, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_splitContainer1.Panel2, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_splitContainer1.Panel2, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_splitContainer1.Panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_splitContainer1.Panel2, "");
            this.m_extStyle.SetStyleBackColor(this.m_splitContainer1.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainer1.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_splitContainer1.Size = new System.Drawing.Size(806, 403);
            this.m_splitContainer1.SplitterDistance = 201;
            this.m_extStyle.SetStyleBackColor(this.m_splitContainer1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainer1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_splitContainer1.TabIndex = 15;
            // 
            // m_btnRemoveProfilIntervenant
            // 
            this.m_btnRemoveProfilIntervenant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnRemoveProfilIntervenant.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnRemoveProfilIntervenant.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_btnRemoveProfilIntervenant.CustomImage")));
            this.m_btnRemoveProfilIntervenant.CustomText = "Remove";
            this.m_btnRemoveProfilIntervenant.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_linkOperation.SetLinkField(this.m_btnRemoveProfilIntervenant, "");
            this.m_extLinkField.SetLinkField(this.m_btnRemoveProfilIntervenant, "");
            this.m_linkProfilIntervenant.SetLinkField(this.m_btnRemoveProfilIntervenant, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_btnRemoveProfilIntervenant, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_btnRemoveProfilIntervenant, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnRemoveProfilIntervenant, false);
            this.m_btnRemoveProfilIntervenant.Location = new System.Drawing.Point(6, 173);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnRemoveProfilIntervenant, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnRemoveProfilIntervenant, "");
            this.m_btnRemoveProfilIntervenant.Name = "m_btnRemoveProfilIntervenant";
            this.m_btnRemoveProfilIntervenant.ShortMode = false;
            this.m_btnRemoveProfilIntervenant.Size = new System.Drawing.Size(104, 20);
            this.m_extStyle.SetStyleBackColor(this.m_btnRemoveProfilIntervenant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnRemoveProfilIntervenant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnRemoveProfilIntervenant.TabIndex = 13;
            this.m_btnRemoveProfilIntervenant.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_btnRemoveProfilIntervenant.LinkClicked += new System.EventHandler(this.m_btnRemoveProfilIntervenant_LinkClicked);
            // 
            // m_btnAddProfilIntervenant
            // 
            this.m_btnAddProfilIntervenant.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnAddProfilIntervenant.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_btnAddProfilIntervenant.CustomImage")));
            this.m_btnAddProfilIntervenant.CustomText = "Add";
            this.m_btnAddProfilIntervenant.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_linkOperation.SetLinkField(this.m_btnAddProfilIntervenant, "");
            this.m_extLinkField.SetLinkField(this.m_btnAddProfilIntervenant, "");
            this.m_linkProfilIntervenant.SetLinkField(this.m_btnAddProfilIntervenant, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_btnAddProfilIntervenant, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_btnAddProfilIntervenant, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnAddProfilIntervenant, false);
            this.m_btnAddProfilIntervenant.Location = new System.Drawing.Point(106, 23);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAddProfilIntervenant, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnAddProfilIntervenant, "");
            this.m_btnAddProfilIntervenant.Name = "m_btnAddProfilIntervenant";
            this.m_btnAddProfilIntervenant.ShortMode = false;
            this.m_btnAddProfilIntervenant.Size = new System.Drawing.Size(104, 20);
            this.m_extStyle.SetStyleBackColor(this.m_btnAddProfilIntervenant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAddProfilIntervenant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAddProfilIntervenant.TabIndex = 12;
            this.m_btnAddProfilIntervenant.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_btnAddProfilIntervenant.LinkClicked += new System.EventHandler(this.m_btnAddProfilIntervenant_LinkClicked);
            // 
            // m_panelProfilIntervenant
            // 
            this.m_panelProfilIntervenant.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelProfilIntervenant.Controls.Add(this.checkBox1);
            this.m_panelProfilIntervenant.Controls.Add(this.m_chkMultiple);
            this.m_panelProfilIntervenant.Controls.Add(this.m_txtSelectProfil2);
            this.m_panelProfilIntervenant.Controls.Add(this.label10);
            this.m_panelProfilIntervenant.Controls.Add(this.c2iTextBox3);
            this.m_panelProfilIntervenant.Controls.Add(this.label9);
            this.m_panelProfilIntervenant.Controls.Add(this.label7);
            this.m_linkProfilIntervenant.SetLinkField(this.m_panelProfilIntervenant, "");
            this.m_linkOperation.SetLinkField(this.m_panelProfilIntervenant, "");
            this.m_extLinkField.SetLinkField(this.m_panelProfilIntervenant, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_panelProfilIntervenant, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_panelProfilIntervenant, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelProfilIntervenant, false);
            this.m_panelProfilIntervenant.Location = new System.Drawing.Point(312, 34);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelProfilIntervenant, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelProfilIntervenant, "");
            this.m_panelProfilIntervenant.Name = "m_panelProfilIntervenant";
            this.m_panelProfilIntervenant.Size = new System.Drawing.Size(487, 137);
            this.m_extStyle.SetStyleBackColor(this.m_panelProfilIntervenant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelProfilIntervenant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelProfilIntervenant.TabIndex = 14;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.m_linkProfilIntervenant.SetLinkField(this.checkBox1, "AfficherManquantDansPlanning");
            this.m_linkOperation.SetLinkField(this.checkBox1, "");
            this.m_extLinkField.SetLinkField(this.checkBox1, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.checkBox1, true);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.checkBox1, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.checkBox1, false);
            this.checkBox1.Location = new System.Drawing.Point(86, 107);
            this.m_gestionnaireModeEdition.SetModeEdition(this.checkBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.checkBox1, "");
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(243, 19);
            this.m_extStyle.SetStyleBackColor(this.checkBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.checkBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Show if empty in planning window|20650";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // m_chkMultiple
            // 
            this.m_chkMultiple.AutoSize = true;
            this.m_linkProfilIntervenant.SetLinkField(this.m_chkMultiple, "IsMultiple");
            this.m_linkOperation.SetLinkField(this.m_chkMultiple, "");
            this.m_extLinkField.SetLinkField(this.m_chkMultiple, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_chkMultiple, true);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_chkMultiple, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_chkMultiple, false);
            this.m_chkMultiple.Location = new System.Drawing.Point(86, 88);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkMultiple, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkMultiple, "");
            this.m_chkMultiple.Name = "m_chkMultiple";
            this.m_chkMultiple.Size = new System.Drawing.Size(136, 19);
            this.m_extStyle.SetStyleBackColor(this.m_chkMultiple, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkMultiple, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkMultiple.TabIndex = 11;
            this.m_chkMultiple.Text = "Allow multiple|20649";
            this.m_chkMultiple.UseVisualStyleBackColor = true;
            // 
            // m_txtSelectProfil2
            // 
            this.m_txtSelectProfil2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtSelectProfil2.ElementSelectionne = null;
            this.m_txtSelectProfil2.FonctionTextNull = null;
            this.m_txtSelectProfil2.HasLink = true;
            this.m_txtSelectProfil2.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_extLinkField.SetLinkField(this.m_txtSelectProfil2, "");
            this.m_linkOperation.SetLinkField(this.m_txtSelectProfil2, "");
            this.m_linkProfilIntervenant.SetLinkField(this.m_txtSelectProfil2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtSelectProfil2, false);
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_txtSelectProfil2, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_txtSelectProfil2, false);
            this.m_txtSelectProfil2.Location = new System.Drawing.Point(86, 60);
            this.m_txtSelectProfil2.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectProfil2, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtSelectProfil2, "");
            this.m_txtSelectProfil2.Name = "m_txtSelectProfil2";
            this.m_txtSelectProfil2.SelectedObject = null;
            this.m_txtSelectProfil2.Size = new System.Drawing.Size(395, 21);
            this.m_txtSelectProfil2.SpecificImage = null;
            this.m_extStyle.SetStyleBackColor(this.m_txtSelectProfil2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSelectProfil2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectProfil2.TabIndex = 10;
            this.m_txtSelectProfil2.TextNull = "";
            // 
            // label10
            // 
            this.m_linkProfilIntervenant.SetLinkField(this.label10, "");
            this.m_linkOperation.SetLinkField(this.label10, "");
            this.m_extLinkField.SetLinkField(this.label10, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.label10, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.label10, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label10, false);
            this.label10.Location = new System.Drawing.Point(6, 58);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label10, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label10, "");
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 23);
            this.m_extStyle.SetStyleBackColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label10.TabIndex = 3;
            this.label10.Text = "Profile|416";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c2iTextBox3
            // 
            this.c2iTextBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iTextBox3.EmptyText = "";
            this.m_linkOperation.SetLinkField(this.c2iTextBox3, "");
            this.m_extLinkField.SetLinkField(this.c2iTextBox3, "");
            this.m_linkProfilIntervenant.SetLinkField(this.c2iTextBox3, "Libelle");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iTextBox3, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.c2iTextBox3, false);
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.c2iTextBox3, true);
            this.c2iTextBox3.Location = new System.Drawing.Point(86, 26);
            this.c2iTextBox3.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iTextBox3, "");
            this.c2iTextBox3.Name = "c2iTextBox3";
            this.c2iTextBox3.Size = new System.Drawing.Size(398, 23);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox3.TabIndex = 2;
            this.c2iTextBox3.Text = "[Libelle]";
            // 
            // label9
            // 
            this.m_linkProfilIntervenant.SetLinkField(this.label9, "");
            this.m_linkOperation.SetLinkField(this.label9, "");
            this.m_extLinkField.SetLinkField(this.label9, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.label9, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.label9, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label9, false);
            this.label9.Location = new System.Drawing.Point(4, 26);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label9, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label9, "");
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 23);
            this.m_extStyle.SetStyleBackColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label9.TabIndex = 1;
            this.label9.Text = "Label|50";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_linkProfilIntervenant.SetLinkField(this.label7, "ProfilIntervenant.Libelle");
            this.m_linkOperation.SetLinkField(this.label7, "");
            this.m_extLinkField.SetLinkField(this.label7, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.label7, true);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.label7, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label7, false);
            this.label7.Location = new System.Drawing.Point(3, 6);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label7, "");
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(481, 16);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 0;
            this.label7.Text = "[ProfilIntervenant.Libelle]";
            // 
            // label8
            // 
            this.m_linkProfilIntervenant.SetLinkField(this.label8, "");
            this.m_linkOperation.SetLinkField(this.label8, "");
            this.m_extLinkField.SetLinkField(this.label8, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.label8, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.label8, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label8, false);
            this.label8.Location = new System.Drawing.Point(-1, 4);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label8, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label8, "");
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 13);
            this.m_extStyle.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 10;
            this.label8.Text = "Operator|388";
            // 
            // m_wndListeProfilsIntervenants
            // 
            this.m_wndListeProfilsIntervenants.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.m_wndListeProfilsIntervenants.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn3,
            this.listViewAutoFilledColumn2});
            this.m_wndListeProfilsIntervenants.EnableCustomisation = true;
            this.m_wndListeProfilsIntervenants.FullRowSelect = true;
            this.m_wndListeProfilsIntervenants.HideSelection = false;
            this.m_linkOperation.SetLinkField(this.m_wndListeProfilsIntervenants, "");
            this.m_extLinkField.SetLinkField(this.m_wndListeProfilsIntervenants, "");
            this.m_linkProfilIntervenant.SetLinkField(this.m_wndListeProfilsIntervenants, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_wndListeProfilsIntervenants, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_wndListeProfilsIntervenants, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_wndListeProfilsIntervenants, false);
            this.m_wndListeProfilsIntervenants.Location = new System.Drawing.Point(6, 45);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeProfilsIntervenants, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndListeProfilsIntervenants, "");
            this.m_wndListeProfilsIntervenants.MultiSelect = false;
            this.m_wndListeProfilsIntervenants.Name = "m_wndListeProfilsIntervenants";
            this.m_wndListeProfilsIntervenants.Size = new System.Drawing.Size(297, 126);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeProfilsIntervenants, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeProfilsIntervenants, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeProfilsIntervenants.TabIndex = 11;
            this.m_wndListeProfilsIntervenants.UseCompatibleStateImageBehavior = false;
            this.m_wndListeProfilsIntervenants.View = System.Windows.Forms.View.Details;
            // 
            // listViewAutoFilledColumn3
            // 
            this.listViewAutoFilledColumn3.Field = "Libelle";
            this.listViewAutoFilledColumn3.PrecisionWidth = 0D;
            this.listViewAutoFilledColumn3.ProportionnalSize = false;
            this.listViewAutoFilledColumn3.Text = "Label|50";
            this.listViewAutoFilledColumn3.Visible = true;
            this.listViewAutoFilledColumn3.Width = 130;
            // 
            // listViewAutoFilledColumn2
            // 
            this.listViewAutoFilledColumn2.Field = "ProfilIntervenant.Libelle";
            this.listViewAutoFilledColumn2.PrecisionWidth = 0D;
            this.listViewAutoFilledColumn2.ProportionnalSize = false;
            this.listViewAutoFilledColumn2.Text = "Profile|141";
            this.listViewAutoFilledColumn2.Visible = true;
            this.listViewAutoFilledColumn2.Width = 120;
            // 
            // m_txtSelectProfilIntervenant
            // 
            this.m_txtSelectProfilIntervenant.ElementSelectionne = null;
            this.m_txtSelectProfilIntervenant.FonctionTextNull = null;
            this.m_txtSelectProfilIntervenant.HasLink = true;
            this.m_txtSelectProfilIntervenant.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_extLinkField.SetLinkField(this.m_txtSelectProfilIntervenant, "");
            this.m_linkOperation.SetLinkField(this.m_txtSelectProfilIntervenant, "");
            this.m_linkProfilIntervenant.SetLinkField(this.m_txtSelectProfilIntervenant, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtSelectProfilIntervenant, false);
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_txtSelectProfilIntervenant, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_txtSelectProfilIntervenant, false);
            this.m_txtSelectProfilIntervenant.Location = new System.Drawing.Point(106, 2);
            this.m_txtSelectProfilIntervenant.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectProfilIntervenant, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtSelectProfilIntervenant, "");
            this.m_txtSelectProfilIntervenant.Name = "m_txtSelectProfilIntervenant";
            this.m_txtSelectProfilIntervenant.SelectedObject = null;
            this.m_txtSelectProfilIntervenant.Size = new System.Drawing.Size(293, 21);
            this.m_txtSelectProfilIntervenant.SpecificImage = null;
            this.m_extStyle.SetStyleBackColor(this.m_txtSelectProfilIntervenant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSelectProfilIntervenant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectProfilIntervenant.TabIndex = 9;
            this.m_txtSelectProfilIntervenant.TextNull = "";
            // 
            // m_editFiltreDynamiqueIntervenants
            // 
            this.m_editFiltreDynamiqueIntervenants.BackColor = System.Drawing.Color.White;
            this.m_editFiltreDynamiqueIntervenants.Controls.Add(this.m_tab);
            this.m_editFiltreDynamiqueIntervenants.Controls.Add(this.c2iTabControl1);
            this.m_editFiltreDynamiqueIntervenants.Controls.Add(this.c2iTabControl2);
            this.m_editFiltreDynamiqueIntervenants.DefinitionRacineDeChampsFiltres = null;
            this.m_editFiltreDynamiqueIntervenants.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_editFiltreDynamiqueIntervenants.FiltreDynamique = null;
            this.m_extLinkField.SetLinkField(this.m_editFiltreDynamiqueIntervenants, "");
            this.m_linkOperation.SetLinkField(this.m_editFiltreDynamiqueIntervenants, "");
            this.m_linkProfilIntervenant.SetLinkField(this.m_editFiltreDynamiqueIntervenants, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_editFiltreDynamiqueIntervenants, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_editFiltreDynamiqueIntervenants, false);
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_editFiltreDynamiqueIntervenants, false);
            this.m_editFiltreDynamiqueIntervenants.Location = new System.Drawing.Point(0, 24);
            this.m_editFiltreDynamiqueIntervenants.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_editFiltreDynamiqueIntervenants, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_editFiltreDynamiqueIntervenants.ModeFiltreExpression = false;
            this.m_editFiltreDynamiqueIntervenants.ModeSansType = true;
            this.m_extModulesAssociator.SetModules(this.m_editFiltreDynamiqueIntervenants, "");
            this.m_editFiltreDynamiqueIntervenants.Name = "m_editFiltreDynamiqueIntervenants";
            this.m_editFiltreDynamiqueIntervenants.Size = new System.Drawing.Size(802, 170);
            this.m_extStyle.SetStyleBackColor(this.m_editFiltreDynamiqueIntervenants, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_editFiltreDynamiqueIntervenants, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_editFiltreDynamiqueIntervenants.TabIndex = 4006;
            // 
            // m_tab
            // 
            this.m_tab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_tab.BoldSelectedPage = true;
            this.m_tab.ControlBottomOffset = 16;
            this.m_tab.ControlRightOffset = 16;
            this.m_tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tab.IDEPixelArea = false;
            this.m_linkProfilIntervenant.SetLinkField(this.m_tab, "");
            this.m_linkOperation.SetLinkField(this.m_tab, "");
            this.m_extLinkField.SetLinkField(this.m_tab, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_tab, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_tab, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_tab, false);
            this.m_tab.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tab, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tab, "");
            this.m_tab.Name = "m_tab";
            this.m_tab.Ombre = true;
            this.m_tab.PositionTop = true;
            this.m_tab.Size = new System.Drawing.Size(802, 170);
            this.m_extStyle.SetStyleBackColor(this.m_tab, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tab, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tab.TabIndex = 2;
            // 
            // c2iTabControl1
            // 
            this.c2iTabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iTabControl1.BoldSelectedPage = true;
            this.c2iTabControl1.ControlBottomOffset = 16;
            this.c2iTabControl1.ControlRightOffset = 16;
            this.c2iTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c2iTabControl1.IDEPixelArea = false;
            this.m_linkProfilIntervenant.SetLinkField(this.c2iTabControl1, "");
            this.m_linkOperation.SetLinkField(this.c2iTabControl1, "");
            this.m_extLinkField.SetLinkField(this.c2iTabControl1, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.c2iTabControl1, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.c2iTabControl1, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iTabControl1, false);
            this.c2iTabControl1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTabControl1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iTabControl1, "");
            this.c2iTabControl1.Name = "c2iTabControl1";
            this.c2iTabControl1.Ombre = true;
            this.c2iTabControl1.PositionTop = true;
            this.c2iTabControl1.Size = new System.Drawing.Size(802, 170);
            this.m_extStyle.SetStyleBackColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTabControl1.TabIndex = 2;
            // 
            // c2iTabControl2
            // 
            this.c2iTabControl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iTabControl2.BoldSelectedPage = true;
            this.c2iTabControl2.ControlBottomOffset = 16;
            this.c2iTabControl2.ControlRightOffset = 16;
            this.c2iTabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c2iTabControl2.IDEPixelArea = false;
            this.m_linkProfilIntervenant.SetLinkField(this.c2iTabControl2, "");
            this.m_linkOperation.SetLinkField(this.c2iTabControl2, "");
            this.m_extLinkField.SetLinkField(this.c2iTabControl2, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.c2iTabControl2, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.c2iTabControl2, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iTabControl2, false);
            this.c2iTabControl2.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTabControl2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iTabControl2, "");
            this.c2iTabControl2.Name = "c2iTabControl2";
            this.c2iTabControl2.Ombre = true;
            this.c2iTabControl2.PositionTop = true;
            this.c2iTabControl2.Size = new System.Drawing.Size(802, 170);
            this.m_extStyle.SetStyleBackColor(this.c2iTabControl2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTabControl2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTabControl2.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_linkProfilIntervenant.SetLinkField(this.label6, "");
            this.m_linkOperation.SetLinkField(this.label6, "");
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.label6, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.label6, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label6, false);
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label6, "");
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(802, 24);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 4005;
            this.label6.Text = "Default operators filter|10036";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_pageOperations
            // 
            this.m_pageOperations.Controls.Add(this.m_selectOperation);
            this.m_pageOperations.Controls.Add(this.m_controlMonteDescendre);
            this.m_pageOperations.Controls.Add(this.m_panelOperation);
            this.m_pageOperations.Controls.Add(this.m_lnkRemoveOperation);
            this.m_pageOperations.Controls.Add(this.m_wndListeOperations);
            this.m_pageOperations.Controls.Add(this.m_lnkAddOperation);
            this.m_pageOperations.Controls.Add(this.lbl_ope);
            this.m_extLinkField.SetLinkField(this.m_pageOperations, "");
            this.m_linkOperation.SetLinkField(this.m_pageOperations, "");
            this.m_linkProfilIntervenant.SetLinkField(this.m_pageOperations, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_pageOperations, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageOperations, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_pageOperations, false);
            this.m_pageOperations.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageOperations, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageOperations, "");
            this.m_pageOperations.Name = "m_pageOperations";
            this.m_pageOperations.Selected = false;
            this.m_pageOperations.Size = new System.Drawing.Size(806, 403);
            this.m_extStyle.SetStyleBackColor(this.m_pageOperations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageOperations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageOperations.TabIndex = 12;
            this.m_pageOperations.Title = "Operations|593";
            // 
            // m_selectOperation
            // 
            this.m_selectOperation.ElementSelectionne = null;
            this.m_selectOperation.FonctionTextNull = null;
            this.m_selectOperation.HasLink = true;
            this.m_selectOperation.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_extLinkField.SetLinkField(this.m_selectOperation, "");
            this.m_linkOperation.SetLinkField(this.m_selectOperation, "");
            this.m_linkProfilIntervenant.SetLinkField(this.m_selectOperation, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_selectOperation, false);
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_selectOperation, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_selectOperation, false);
            this.m_selectOperation.Location = new System.Drawing.Point(83, 9);
            this.m_selectOperation.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_selectOperation, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_selectOperation, "");
            this.m_selectOperation.Name = "m_selectOperation";
            this.m_selectOperation.SelectedObject = null;
            this.m_selectOperation.Size = new System.Drawing.Size(293, 21);
            this.m_selectOperation.SpecificImage = null;
            this.m_extStyle.SetStyleBackColor(this.m_selectOperation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_selectOperation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectOperation.TabIndex = 0;
            this.m_selectOperation.TextNull = "";
            // 
            // m_controlMonteDescendre
            // 
            this.m_controlMonteDescendre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_linkOperation.SetLinkField(this.m_controlMonteDescendre, "");
            this.m_extLinkField.SetLinkField(this.m_controlMonteDescendre, "");
            this.m_linkProfilIntervenant.SetLinkField(this.m_controlMonteDescendre, "");
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_controlMonteDescendre, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_controlMonteDescendre, false);
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_controlMonteDescendre, false);
            this.m_controlMonteDescendre.ListeGeree = this.m_wndListeOperations;
            this.m_controlMonteDescendre.Location = new System.Drawing.Point(255, 379);
            this.m_controlMonteDescendre.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_controlMonteDescendre, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_controlMonteDescendre, "");
            this.m_controlMonteDescendre.Name = "m_controlMonteDescendre";
            this.m_controlMonteDescendre.ProprieteNumero = "Index";
            this.m_controlMonteDescendre.Size = new System.Drawing.Size(51, 20);
            this.m_extStyle.SetStyleBackColor(this.m_controlMonteDescendre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_controlMonteDescendre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_controlMonteDescendre.TabIndex = 9;
            // 
            // m_wndListeOperations
            // 
            this.m_wndListeOperations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.m_wndListeOperations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn4,
            this.listViewAutoFilledColumn1});
            this.m_wndListeOperations.EnableCustomisation = true;
            this.m_wndListeOperations.FullRowSelect = true;
            this.m_wndListeOperations.HideSelection = false;
            this.m_linkOperation.SetLinkField(this.m_wndListeOperations, "");
            this.m_extLinkField.SetLinkField(this.m_wndListeOperations, "");
            this.m_linkProfilIntervenant.SetLinkField(this.m_wndListeOperations, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_wndListeOperations, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_wndListeOperations, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_wndListeOperations, false);
            this.m_wndListeOperations.Location = new System.Drawing.Point(9, 53);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeOperations, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndListeOperations, "");
            this.m_wndListeOperations.MultiSelect = false;
            this.m_wndListeOperations.Name = "m_wndListeOperations";
            this.m_wndListeOperations.Size = new System.Drawing.Size(297, 324);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeOperations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeOperations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeOperations.TabIndex = 5;
            this.m_wndListeOperations.UseCompatibleStateImageBehavior = false;
            this.m_wndListeOperations.View = System.Windows.Forms.View.Details;
            // 
            // listViewAutoFilledColumn4
            // 
            this.listViewAutoFilledColumn4.Field = "TypeOperation.Code";
            this.listViewAutoFilledColumn4.PrecisionWidth = 0D;
            this.listViewAutoFilledColumn4.ProportionnalSize = false;
            this.listViewAutoFilledColumn4.Text = "Code|369";
            this.listViewAutoFilledColumn4.Visible = true;
            this.listViewAutoFilledColumn4.Width = 70;
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "TypeOperation.Libelle";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0D;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Label|50";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 200;
            // 
            // m_panelOperation
            // 
            this.m_panelOperation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelOperation.Controls.Add(this.m_chkTypeOperationOptional);
            this.m_panelOperation.Controls.Add(this.m_lblTypeOperation);
            this.m_linkProfilIntervenant.SetLinkField(this.m_panelOperation, "");
            this.m_linkOperation.SetLinkField(this.m_panelOperation, "");
            this.m_extLinkField.SetLinkField(this.m_panelOperation, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_panelOperation, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_panelOperation, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelOperation, false);
            this.m_panelOperation.Location = new System.Drawing.Point(319, 53);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelOperation, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelOperation, "");
            this.m_panelOperation.Name = "m_panelOperation";
            this.m_panelOperation.Size = new System.Drawing.Size(472, 324);
            this.m_extStyle.SetStyleBackColor(this.m_panelOperation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelOperation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelOperation.TabIndex = 8;
            // 
            // m_chkTypeOperationOptional
            // 
            this.m_chkTypeOperationOptional.AutoSize = true;
            this.m_linkProfilIntervenant.SetLinkField(this.m_chkTypeOperationOptional, "");
            this.m_linkOperation.SetLinkField(this.m_chkTypeOperationOptional, "Optionnel");
            this.m_extLinkField.SetLinkField(this.m_chkTypeOperationOptional, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_chkTypeOperationOptional, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_chkTypeOperationOptional, true);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_chkTypeOperationOptional, false);
            this.m_chkTypeOperationOptional.Location = new System.Drawing.Point(6, 26);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkTypeOperationOptional, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkTypeOperationOptional, "");
            this.m_chkTypeOperationOptional.Name = "m_chkTypeOperationOptional";
            this.m_chkTypeOperationOptional.Size = new System.Drawing.Size(93, 19);
            this.m_extStyle.SetStyleBackColor(this.m_chkTypeOperationOptional, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkTypeOperationOptional, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkTypeOperationOptional.TabIndex = 1;
            this.m_chkTypeOperationOptional.Text = "Optional|370";
            this.m_chkTypeOperationOptional.UseVisualStyleBackColor = true;
            // 
            // m_lblTypeOperation
            // 
            this.m_lblTypeOperation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblTypeOperation.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_linkProfilIntervenant.SetLinkField(this.m_lblTypeOperation, "");
            this.m_linkOperation.SetLinkField(this.m_lblTypeOperation, "TypeOperation.Libelle");
            this.m_extLinkField.SetLinkField(this.m_lblTypeOperation, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_lblTypeOperation, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_lblTypeOperation, true);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblTypeOperation, false);
            this.m_lblTypeOperation.Location = new System.Drawing.Point(3, 6);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblTypeOperation, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblTypeOperation, "");
            this.m_lblTypeOperation.Name = "m_lblTypeOperation";
            this.m_lblTypeOperation.Size = new System.Drawing.Size(466, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lblTypeOperation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblTypeOperation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblTypeOperation.TabIndex = 0;
            this.m_lblTypeOperation.Text = "[TypeOperation.Libelle]";
            // 
            // m_lnkRemoveOperation
            // 
            this.m_lnkRemoveOperation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkRemoveOperation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkRemoveOperation.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_lnkRemoveOperation.CustomImage")));
            this.m_lnkRemoveOperation.CustomText = "Remove";
            this.m_lnkRemoveOperation.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_linkOperation.SetLinkField(this.m_lnkRemoveOperation, "");
            this.m_extLinkField.SetLinkField(this.m_lnkRemoveOperation, "");
            this.m_linkProfilIntervenant.SetLinkField(this.m_lnkRemoveOperation, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_lnkRemoveOperation, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_lnkRemoveOperation, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkRemoveOperation, false);
            this.m_lnkRemoveOperation.Location = new System.Drawing.Point(7, 380);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkRemoveOperation, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkRemoveOperation, "");
            this.m_lnkRemoveOperation.Name = "m_lnkRemoveOperation";
            this.m_lnkRemoveOperation.ShortMode = false;
            this.m_lnkRemoveOperation.Size = new System.Drawing.Size(104, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkRemoveOperation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkRemoveOperation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkRemoveOperation.TabIndex = 7;
            this.m_lnkRemoveOperation.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkRemoveOperation.LinkClicked += new System.EventHandler(this.m_lnkRemoveOperation_LinkClicked);
            // 
            // m_lnkAddOperation
            // 
            this.m_lnkAddOperation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAddOperation.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_lnkAddOperation.CustomImage")));
            this.m_lnkAddOperation.CustomText = "Add";
            this.m_lnkAddOperation.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_linkOperation.SetLinkField(this.m_lnkAddOperation, "");
            this.m_extLinkField.SetLinkField(this.m_lnkAddOperation, "");
            this.m_linkProfilIntervenant.SetLinkField(this.m_lnkAddOperation, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_lnkAddOperation, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_lnkAddOperation, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkAddOperation, false);
            this.m_lnkAddOperation.Location = new System.Drawing.Point(83, 34);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAddOperation, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAddOperation, "");
            this.m_lnkAddOperation.Name = "m_lnkAddOperation";
            this.m_lnkAddOperation.ShortMode = false;
            this.m_lnkAddOperation.Size = new System.Drawing.Size(104, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAddOperation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAddOperation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAddOperation.TabIndex = 6;
            this.m_lnkAddOperation.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAddOperation.LinkClicked += new System.EventHandler(this.m_lnkAddOperation_LinkClicked);
            // 
            // lbl_ope
            // 
            this.m_linkProfilIntervenant.SetLinkField(this.lbl_ope, "");
            this.m_linkOperation.SetLinkField(this.lbl_ope, "");
            this.m_extLinkField.SetLinkField(this.lbl_ope, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.lbl_ope, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.lbl_ope, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.lbl_ope, false);
            this.lbl_ope.Location = new System.Drawing.Point(4, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_ope, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.lbl_ope, "");
            this.lbl_ope.Name = "lbl_ope";
            this.lbl_ope.Size = new System.Drawing.Size(86, 18);
            this.m_extStyle.SetStyleBackColor(this.lbl_ope, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.lbl_ope, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_ope.TabIndex = 1;
            this.lbl_ope.Text = "Operation|592";
            // 
            // m_pageContraintes
            // 
            this.m_pageContraintes.Controls.Add(this.m_cmbProfilRessourceDefaut);
            this.m_pageContraintes.Controls.Add(this.label11);
            this.m_pageContraintes.Controls.Add(this.m_panelListeContraintes);
            this.m_extLinkField.SetLinkField(this.m_pageContraintes, "");
            this.m_linkOperation.SetLinkField(this.m_pageContraintes, "");
            this.m_linkProfilIntervenant.SetLinkField(this.m_pageContraintes, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_pageContraintes, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageContraintes, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_pageContraintes, false);
            this.m_pageContraintes.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageContraintes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageContraintes, "");
            this.m_pageContraintes.Name = "m_pageContraintes";
            this.m_pageContraintes.Selected = false;
            this.m_pageContraintes.Size = new System.Drawing.Size(806, 403);
            this.m_extStyle.SetStyleBackColor(this.m_pageContraintes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageContraintes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageContraintes.TabIndex = 13;
            this.m_pageContraintes.Title = "Constraints|255";
            // 
            // m_cmbProfilRessourceDefaut
            // 
            this.m_cmbProfilRessourceDefaut.ComportementLinkStd = true;
            this.m_cmbProfilRessourceDefaut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbProfilRessourceDefaut.ElementSelectionne = null;
            this.m_cmbProfilRessourceDefaut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbProfilRessourceDefaut.FormattingEnabled = true;
            this.m_cmbProfilRessourceDefaut.IsLink = false;
            this.m_linkOperation.SetLinkField(this.m_cmbProfilRessourceDefaut, "");
            this.m_extLinkField.SetLinkField(this.m_cmbProfilRessourceDefaut, "");
            this.m_linkProfilIntervenant.SetLinkField(this.m_cmbProfilRessourceDefaut, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbProfilRessourceDefaut, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_cmbProfilRessourceDefaut, false);
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_cmbProfilRessourceDefaut, false);
            this.m_cmbProfilRessourceDefaut.LinkProperty = "";
            this.m_cmbProfilRessourceDefaut.ListDonnees = null;
            this.m_cmbProfilRessourceDefaut.Location = new System.Drawing.Point(171, 4);
            this.m_cmbProfilRessourceDefaut.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbProfilRessourceDefaut, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbProfilRessourceDefaut, "");
            this.m_cmbProfilRessourceDefaut.Name = "m_cmbProfilRessourceDefaut";
            this.m_cmbProfilRessourceDefaut.NullAutorise = true;
            this.m_cmbProfilRessourceDefaut.ProprieteAffichee = null;
            this.m_cmbProfilRessourceDefaut.ProprieteParentListeObjets = null;
            this.m_cmbProfilRessourceDefaut.SelectionneurParent = null;
            this.m_cmbProfilRessourceDefaut.Size = new System.Drawing.Size(375, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbProfilRessourceDefaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbProfilRessourceDefaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbProfilRessourceDefaut.TabIndex = 3;
            this.m_cmbProfilRessourceDefaut.TextNull = "(none)";
            this.m_cmbProfilRessourceDefaut.Tri = true;
            this.m_cmbProfilRessourceDefaut.TypeFormEdition = null;
            // 
            // label11
            // 
            this.m_linkProfilIntervenant.SetLinkField(this.label11, "");
            this.m_linkOperation.SetLinkField(this.label11, "");
            this.m_extLinkField.SetLinkField(this.label11, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.label11, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.label11, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label11, false);
            this.label11.Location = new System.Drawing.Point(4, 7);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label11, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label11, "");
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(161, 15);
            this.m_extStyle.SetStyleBackColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label11.TabIndex = 2;
            this.label11.Text = "Default resource profile|468";
            // 
            // m_panelListeContraintes
            // 
            this.m_panelListeContraintes.AffectationsPourNouveauxElements = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("m_panelListeContraintes.AffectationsPourNouveauxElements")));
            this.m_panelListeContraintes.AllowArbre = true;
            this.m_panelListeContraintes.AllowCustomisation = true;
            this.m_panelListeContraintes.AllowSerializePreferences = true;
            this.m_panelListeContraintes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            glColumn2.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn2.ActiveControlItems")));
            glColumn2.BackColor = System.Drawing.Color.Transparent;
            glColumn2.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn2.ForColor = System.Drawing.Color.Black;
            glColumn2.ImageIndex = -1;
            glColumn2.IsCheckColumn = false;
            glColumn2.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn2.Name = "ColumnLabel";
            glColumn2.Propriete = "Libelle";
            glColumn2.Text = "Label|50";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 300;
            this.m_panelListeContraintes.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn2});
            this.m_panelListeContraintes.ContexteUtilisation = "";
            this.m_panelListeContraintes.ControlFiltreStandard = null;
            this.m_panelListeContraintes.ElementSelectionne = null;
            this.m_panelListeContraintes.EnableCustomisation = true;
            this.m_panelListeContraintes.FiltreDeBase = null;
            this.m_panelListeContraintes.FiltreDeBaseEnAjout = false;
            this.m_panelListeContraintes.FiltrePrefere = null;
            this.m_panelListeContraintes.FiltreRapide = null;
            this.m_panelListeContraintes.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panelListeContraintes, "");
            this.m_linkOperation.SetLinkField(this.m_panelListeContraintes, "");
            this.m_linkProfilIntervenant.SetLinkField(this.m_panelListeContraintes, "");
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_panelListeContraintes, false);
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_panelListeContraintes, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelListeContraintes, false);
            this.m_panelListeContraintes.ListeObjets = null;
            this.m_panelListeContraintes.Location = new System.Drawing.Point(0, 31);
            this.m_panelListeContraintes.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelListeContraintes, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelListeContraintes.ModeQuickSearch = false;
            this.m_panelListeContraintes.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_panelListeContraintes, "");
            this.m_panelListeContraintes.MultiSelect = false;
            this.m_panelListeContraintes.Name = "m_panelListeContraintes";
            this.m_panelListeContraintes.Navigateur = null;
            this.m_panelListeContraintes.ObjetReferencePourAffectationsInitiales = null;
            this.m_panelListeContraintes.ProprieteObjetAEditer = null;
            this.m_panelListeContraintes.QuickSearchText = "";
            this.m_panelListeContraintes.ShortIcons = false;
            this.m_panelListeContraintes.Size = new System.Drawing.Size(806, 372);
            this.m_extStyle.SetStyleBackColor(this.m_panelListeContraintes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListeContraintes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelListeContraintes.TabIndex = 1;
            this.m_panelListeContraintes.TrierAuClicSurEnteteColonne = true;
            this.m_panelListeContraintes.UseCheckBoxes = false;
            // 
            // m_pageChampsCustom
            // 
            this.m_pageChampsCustom.Controls.Add(this.m_panelEditChamps);
            this.m_extLinkField.SetLinkField(this.m_pageChampsCustom, "");
            this.m_linkOperation.SetLinkField(this.m_pageChampsCustom, "");
            this.m_linkProfilIntervenant.SetLinkField(this.m_pageChampsCustom, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_pageChampsCustom, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageChampsCustom, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_pageChampsCustom, false);
            this.m_pageChampsCustom.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageChampsCustom, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageChampsCustom, "");
            this.m_pageChampsCustom.Name = "m_pageChampsCustom";
            this.m_pageChampsCustom.Selected = false;
            this.m_pageChampsCustom.Size = new System.Drawing.Size(806, 403);
            this.m_extStyle.SetStyleBackColor(this.m_pageChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageChampsCustom.TabIndex = 11;
            this.m_pageChampsCustom.Title = "Custom fields|198";
            // 
            // m_panelEditChamps
            // 
            this.m_panelEditChamps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelEditChamps.AvecAffectationDirecteDeChamps = false;
            this.m_extLinkField.SetLinkField(this.m_panelEditChamps, "");
            this.m_linkOperation.SetLinkField(this.m_panelEditChamps, "");
            this.m_linkProfilIntervenant.SetLinkField(this.m_panelEditChamps, "");
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_panelEditChamps, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelEditChamps, false);
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_panelEditChamps, false);
            this.m_panelEditChamps.Location = new System.Drawing.Point(0, 0);
            this.m_panelEditChamps.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEditChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelEditChamps, "");
            this.m_panelEditChamps.Name = "m_panelEditChamps";
            this.m_panelEditChamps.Size = new System.Drawing.Size(806, 407);
            this.m_extStyle.SetStyleBackColor(this.m_panelEditChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEditChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEditChamps.TabIndex = 1;
            // 
            // m_pageContactsPoss
            // 
            this.m_pageContactsPoss.Controls.Add(this.m_ctrlProfilsActeursPossibles);
            this.m_extLinkField.SetLinkField(this.m_pageContactsPoss, "");
            this.m_linkOperation.SetLinkField(this.m_pageContactsPoss, "");
            this.m_linkProfilIntervenant.SetLinkField(this.m_pageContactsPoss, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_pageContactsPoss, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageContactsPoss, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_pageContactsPoss, false);
            this.m_pageContactsPoss.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageContactsPoss, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageContactsPoss, "");
            this.m_pageContactsPoss.Name = "m_pageContactsPoss";
            this.m_pageContactsPoss.Selected = false;
            this.m_pageContactsPoss.Size = new System.Drawing.Size(806, 403);
            this.m_extStyle.SetStyleBackColor(this.m_pageContactsPoss, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageContactsPoss, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageContactsPoss.TabIndex = 15;
            this.m_pageContactsPoss.Title = "Possible contacts|594";
            // 
            // m_ctrlProfilsActeursPossibles
            // 
            this.m_ctrlProfilsActeursPossibles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_ctrlProfilsActeursPossibles, "");
            this.m_linkOperation.SetLinkField(this.m_ctrlProfilsActeursPossibles, "");
            this.m_linkProfilIntervenant.SetLinkField(this.m_ctrlProfilsActeursPossibles, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_ctrlProfilsActeursPossibles, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_ctrlProfilsActeursPossibles, false);
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_ctrlProfilsActeursPossibles, false);
            this.m_ctrlProfilsActeursPossibles.Location = new System.Drawing.Point(0, 0);
            this.m_ctrlProfilsActeursPossibles.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_ctrlProfilsActeursPossibles, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_ctrlProfilsActeursPossibles, "");
            this.m_ctrlProfilsActeursPossibles.Name = "m_ctrlProfilsActeursPossibles";
            this.m_ctrlProfilsActeursPossibles.Size = new System.Drawing.Size(806, 403);
            this.m_extStyle.SetStyleBackColor(this.m_ctrlProfilsActeursPossibles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_ctrlProfilsActeursPossibles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ctrlProfilsActeursPossibles.TabIndex = 1;
            // 
            // m_pagePlanif
            // 
            this.m_pagePlanif.Controls.Add(this.m_lnkParametrerActivite);
            this.m_pagePlanif.Controls.Add(this.m_cmbTypeActivite);
            this.m_pagePlanif.Controls.Add(this.label15);
            this.m_pagePlanif.Controls.Add(this.lbl_activite);
            this.m_pagePlanif.Controls.Add(this.pictureBox5);
            this.m_pagePlanif.Controls.Add(this.m_cmbProfilPlanifieur);
            this.m_pagePlanif.Controls.Add(this.m_cmbProfilPrePlanifieur);
            this.m_pagePlanif.Controls.Add(this.label13);
            this.m_pagePlanif.Controls.Add(this.lbl_profilpreplan);
            this.m_extLinkField.SetLinkField(this.m_pagePlanif, "");
            this.m_linkOperation.SetLinkField(this.m_pagePlanif, "");
            this.m_linkProfilIntervenant.SetLinkField(this.m_pagePlanif, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_pagePlanif, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pagePlanif, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_pagePlanif, false);
            this.m_pagePlanif.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pagePlanif, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pagePlanif, "");
            this.m_pagePlanif.Name = "m_pagePlanif";
            this.m_pagePlanif.Selected = false;
            this.m_pagePlanif.Size = new System.Drawing.Size(806, 403);
            this.m_extStyle.SetStyleBackColor(this.m_pagePlanif, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pagePlanif, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pagePlanif.TabIndex = 16;
            this.m_pagePlanif.Title = "Planning/follow-up|595";
            // 
            // m_lnkParametrerActivite
            // 
            this.m_linkOperation.SetLinkField(this.m_lnkParametrerActivite, "");
            this.m_extLinkField.SetLinkField(this.m_lnkParametrerActivite, "");
            this.m_linkProfilIntervenant.SetLinkField(this.m_lnkParametrerActivite, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_lnkParametrerActivite, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkParametrerActivite, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_lnkParametrerActivite, false);
            this.m_lnkParametrerActivite.Location = new System.Drawing.Point(176, 135);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkParametrerActivite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkParametrerActivite, "");
            this.m_lnkParametrerActivite.Name = "m_lnkParametrerActivite";
            this.m_lnkParametrerActivite.Size = new System.Drawing.Size(121, 14);
            this.m_extStyle.SetStyleBackColor(this.m_lnkParametrerActivite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkParametrerActivite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkParametrerActivite.TabIndex = 20;
            this.m_lnkParametrerActivite.TabStop = true;
            this.m_lnkParametrerActivite.Text = "Setup|600";
            this.m_lnkParametrerActivite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkParametrerActivite_LinkClicked);
            // 
            // m_cmbTypeActivite
            // 
            this.m_cmbTypeActivite.ComportementLinkStd = true;
            this.m_cmbTypeActivite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTypeActivite.ElementSelectionne = null;
            this.m_cmbTypeActivite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbTypeActivite.FormattingEnabled = true;
            this.m_cmbTypeActivite.IsLink = false;
            this.m_linkOperation.SetLinkField(this.m_cmbTypeActivite, "");
            this.m_extLinkField.SetLinkField(this.m_cmbTypeActivite, "");
            this.m_linkProfilIntervenant.SetLinkField(this.m_cmbTypeActivite, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbTypeActivite, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_cmbTypeActivite, false);
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_cmbTypeActivite, false);
            this.m_cmbTypeActivite.LinkProperty = "";
            this.m_cmbTypeActivite.ListDonnees = null;
            this.m_cmbTypeActivite.Location = new System.Drawing.Point(179, 111);
            this.m_cmbTypeActivite.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbTypeActivite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbTypeActivite, "");
            this.m_cmbTypeActivite.Name = "m_cmbTypeActivite";
            this.m_cmbTypeActivite.NullAutorise = true;
            this.m_cmbTypeActivite.ProprieteAffichee = null;
            this.m_cmbTypeActivite.ProprieteParentListeObjets = null;
            this.m_cmbTypeActivite.SelectionneurParent = null;
            this.m_cmbTypeActivite.Size = new System.Drawing.Size(360, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbTypeActivite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbTypeActivite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbTypeActivite.TabIndex = 19;
            this.m_cmbTypeActivite.TextNull = "(None)";
            this.m_cmbTypeActivite.Tri = true;
            this.m_cmbTypeActivite.TypeFormEdition = null;
            this.m_cmbTypeActivite.SelectionChangeCommitted += new System.EventHandler(this.m_cmbTypeActivite_SelectionChangeCommitted);
            // 
            // label15
            // 
            this.m_linkProfilIntervenant.SetLinkField(this.label15, "");
            this.m_linkOperation.SetLinkField(this.label15, "");
            this.m_extLinkField.SetLinkField(this.label15, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.label15, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.label15, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label15, false);
            this.label15.Location = new System.Drawing.Point(20, 114);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label15, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label15, "");
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(153, 18);
            this.m_extStyle.SetStyleBackColor(this.label15, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label15, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label15.TabIndex = 18;
            this.label15.Text = "Activity Type associated|599";
            // 
            // lbl_activite
            // 
            this.lbl_activite.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_linkProfilIntervenant.SetLinkField(this.lbl_activite, "");
            this.m_linkOperation.SetLinkField(this.lbl_activite, "");
            this.m_extLinkField.SetLinkField(this.lbl_activite, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.lbl_activite, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.lbl_activite, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.lbl_activite, false);
            this.lbl_activite.Location = new System.Drawing.Point(19, 83);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_activite, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.lbl_activite, "");
            this.lbl_activite.Name = "lbl_activite";
            this.lbl_activite.Size = new System.Drawing.Size(145, 23);
            this.m_extStyle.SetStyleBackColor(this.lbl_activite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.lbl_activite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_activite.TabIndex = 18;
            this.lbl_activite.Text = "Activity|598";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox5.BackColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.pictureBox5, "");
            this.m_linkOperation.SetLinkField(this.pictureBox5, "");
            this.m_linkProfilIntervenant.SetLinkField(this.pictureBox5, "");
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.pictureBox5, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.pictureBox5, false);
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.pictureBox5, false);
            this.pictureBox5.Location = new System.Drawing.Point(19, 75);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pictureBox5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pictureBox5, "");
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(767, 1);
            this.m_extStyle.SetStyleBackColor(this.pictureBox5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pictureBox5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pictureBox5.TabIndex = 17;
            this.pictureBox5.TabStop = false;
            // 
            // m_cmbProfilPlanifieur
            // 
            this.m_cmbProfilPlanifieur.ComportementLinkStd = true;
            this.m_cmbProfilPlanifieur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbProfilPlanifieur.ElementSelectionne = null;
            this.m_cmbProfilPlanifieur.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbProfilPlanifieur.FormattingEnabled = true;
            this.m_cmbProfilPlanifieur.IsLink = false;
            this.m_linkOperation.SetLinkField(this.m_cmbProfilPlanifieur, "");
            this.m_extLinkField.SetLinkField(this.m_cmbProfilPlanifieur, "");
            this.m_linkProfilIntervenant.SetLinkField(this.m_cmbProfilPlanifieur, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbProfilPlanifieur, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_cmbProfilPlanifieur, false);
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_cmbProfilPlanifieur, false);
            this.m_cmbProfilPlanifieur.LinkProperty = "";
            this.m_cmbProfilPlanifieur.ListDonnees = null;
            this.m_cmbProfilPlanifieur.Location = new System.Drawing.Point(202, 41);
            this.m_cmbProfilPlanifieur.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbProfilPlanifieur, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbProfilPlanifieur, "");
            this.m_cmbProfilPlanifieur.Name = "m_cmbProfilPlanifieur";
            this.m_cmbProfilPlanifieur.NullAutorise = true;
            this.m_cmbProfilPlanifieur.ProprieteAffichee = null;
            this.m_cmbProfilPlanifieur.ProprieteParentListeObjets = null;
            this.m_cmbProfilPlanifieur.SelectionneurParent = null;
            this.m_cmbProfilPlanifieur.Size = new System.Drawing.Size(364, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbProfilPlanifieur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbProfilPlanifieur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbProfilPlanifieur.TabIndex = 16;
            this.m_cmbProfilPlanifieur.TextNull = "(All users)";
            this.m_cmbProfilPlanifieur.Tri = true;
            this.m_cmbProfilPlanifieur.TypeFormEdition = null;
            // 
            // m_cmbProfilPrePlanifieur
            // 
            this.m_cmbProfilPrePlanifieur.ComportementLinkStd = true;
            this.m_cmbProfilPrePlanifieur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbProfilPrePlanifieur.ElementSelectionne = null;
            this.m_cmbProfilPrePlanifieur.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbProfilPrePlanifieur.FormattingEnabled = true;
            this.m_cmbProfilPrePlanifieur.IsLink = false;
            this.m_linkOperation.SetLinkField(this.m_cmbProfilPrePlanifieur, "");
            this.m_extLinkField.SetLinkField(this.m_cmbProfilPrePlanifieur, "");
            this.m_linkProfilIntervenant.SetLinkField(this.m_cmbProfilPrePlanifieur, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbProfilPrePlanifieur, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_cmbProfilPrePlanifieur, false);
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_cmbProfilPrePlanifieur, false);
            this.m_cmbProfilPrePlanifieur.LinkProperty = "";
            this.m_cmbProfilPrePlanifieur.ListDonnees = null;
            this.m_cmbProfilPrePlanifieur.Location = new System.Drawing.Point(202, 9);
            this.m_cmbProfilPrePlanifieur.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbProfilPrePlanifieur, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbProfilPrePlanifieur, "");
            this.m_cmbProfilPrePlanifieur.Name = "m_cmbProfilPrePlanifieur";
            this.m_cmbProfilPrePlanifieur.NullAutorise = true;
            this.m_cmbProfilPrePlanifieur.ProprieteAffichee = null;
            this.m_cmbProfilPrePlanifieur.ProprieteParentListeObjets = null;
            this.m_cmbProfilPrePlanifieur.SelectionneurParent = null;
            this.m_cmbProfilPrePlanifieur.Size = new System.Drawing.Size(364, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbProfilPrePlanifieur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbProfilPrePlanifieur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbProfilPrePlanifieur.TabIndex = 15;
            this.m_cmbProfilPrePlanifieur.TextNull = "(All users)";
            this.m_cmbProfilPrePlanifieur.Tri = true;
            this.m_cmbProfilPrePlanifieur.TypeFormEdition = null;
            // 
            // label13
            // 
            this.m_linkProfilIntervenant.SetLinkField(this.label13, "");
            this.m_linkOperation.SetLinkField(this.label13, "");
            this.m_extLinkField.SetLinkField(this.label13, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.label13, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.label13, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label13, false);
            this.label13.Location = new System.Drawing.Point(16, 44);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label13, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label13, "");
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(127, 18);
            this.m_extStyle.SetStyleBackColor(this.label13, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label13, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label13.TabIndex = 14;
            this.label13.Text = "Planifier profile|597";
            // 
            // lbl_profilpreplan
            // 
            this.m_linkProfilIntervenant.SetLinkField(this.lbl_profilpreplan, "");
            this.m_linkOperation.SetLinkField(this.lbl_profilpreplan, "");
            this.m_extLinkField.SetLinkField(this.lbl_profilpreplan, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.lbl_profilpreplan, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.lbl_profilpreplan, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.lbl_profilpreplan, false);
            this.lbl_profilpreplan.Location = new System.Drawing.Point(16, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_profilpreplan, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.lbl_profilpreplan, "");
            this.lbl_profilpreplan.Name = "lbl_profilpreplan";
            this.lbl_profilpreplan.Size = new System.Drawing.Size(164, 13);
            this.m_extStyle.SetStyleBackColor(this.lbl_profilpreplan, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.lbl_profilpreplan, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_profilpreplan.TabIndex = 12;
            this.lbl_profilpreplan.Text = "Pre-planifier profile|596";
            // 
            // m_pageEvenements
            // 
            this.m_pageEvenements.Controls.Add(this.m_panelDefinisseurEvenements);
            this.m_extLinkField.SetLinkField(this.m_pageEvenements, "");
            this.m_linkOperation.SetLinkField(this.m_pageEvenements, "");
            this.m_linkProfilIntervenant.SetLinkField(this.m_pageEvenements, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_pageEvenements, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageEvenements, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_pageEvenements, false);
            this.m_pageEvenements.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageEvenements, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageEvenements, "");
            this.m_pageEvenements.Name = "m_pageEvenements";
            this.m_pageEvenements.Selected = false;
            this.m_pageEvenements.Size = new System.Drawing.Size(806, 403);
            this.m_extStyle.SetStyleBackColor(this.m_pageEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageEvenements.TabIndex = 17;
            this.m_pageEvenements.Title = "Events|184";
            // 
            // m_panelDefinisseurEvenements
            // 
            this.m_panelDefinisseurEvenements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelDefinisseurEvenements, "");
            this.m_linkOperation.SetLinkField(this.m_panelDefinisseurEvenements, "");
            this.m_linkProfilIntervenant.SetLinkField(this.m_panelDefinisseurEvenements, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelDefinisseurEvenements, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_panelDefinisseurEvenements, false);
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_panelDefinisseurEvenements, false);
            this.m_panelDefinisseurEvenements.Location = new System.Drawing.Point(0, 0);
            this.m_panelDefinisseurEvenements.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelDefinisseurEvenements, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelDefinisseurEvenements, "");
            this.m_panelDefinisseurEvenements.Name = "m_panelDefinisseurEvenements";
            this.m_panelDefinisseurEvenements.Size = new System.Drawing.Size(806, 403);
            this.m_extStyle.SetStyleBackColor(this.m_panelDefinisseurEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelDefinisseurEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelDefinisseurEvenements.TabIndex = 0;
            // 
            // m_gestionnaireOperations
            // 
            this.m_gestionnaireOperations.ListeAssociee = this.m_wndListeOperations;
            this.m_gestionnaireOperations.ObjetEdite = null;
            this.m_gestionnaireOperations.InitChamp += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireOperations_InitChamp);
            this.m_gestionnaireOperations.MAJ_Champs += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireOperations_MAJ_Champs);
            // 
            // m_linkOperation
            // 
            this.m_linkOperation.SourceTypeString = "";
            // 
            // m_linkProfilIntervenant
            // 
            this.m_linkProfilIntervenant.SourceTypeString = "";
            // 
            // m_gestionnaireProfilsIntervenants
            // 
            this.m_gestionnaireProfilsIntervenants.ListeAssociee = this.m_wndListeProfilsIntervenants;
            this.m_gestionnaireProfilsIntervenants.ObjetEdite = null;
            this.m_gestionnaireProfilsIntervenants.InitChamp += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireProfilsIntervenants_InitChamp);
            this.m_gestionnaireProfilsIntervenants.MAJ_Champs += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireProfilsIntervenants_MAJ_Champs);
            // 
            // m_pageFormulaires
            // 
            this.m_pageFormulaires.Controls.Add(this.m_panelChamps);
            this.m_extLinkField.SetLinkField(this.m_pageFormulaires, "");
            this.m_linkOperation.SetLinkField(this.m_pageFormulaires, "");
            this.m_linkProfilIntervenant.SetLinkField(this.m_pageFormulaires, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_pageFormulaires, true);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageFormulaires, true);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_pageFormulaires, true);
            this.m_pageFormulaires.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageFormulaires, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageFormulaires, "");
            this.m_pageFormulaires.Name = "m_pageFormulaires";
            this.m_pageFormulaires.Size = new System.Drawing.Size(806, 403);
            this.m_extStyle.SetStyleBackColor(this.m_pageFormulaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageFormulaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageFormulaires.TabIndex = 18;
            this.m_pageFormulaires.Title = "Form|60";
            // 
            // m_panelChamps
            // 
            this.m_panelChamps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelChamps.BoldSelectedPage = true;
            this.m_panelChamps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelChamps.ElementEdite = null;
            this.m_panelChamps.ForeColor = System.Drawing.Color.Black;
            this.m_panelChamps.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_panelChamps, "");
            this.m_linkOperation.SetLinkField(this.m_panelChamps, "");
            this.m_linkProfilIntervenant.SetLinkField(this.m_panelChamps, "");
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this.m_panelChamps, true);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelChamps, false);
            this.m_linkOperation.SetLinkFieldAutoUpdate(this.m_panelChamps, true);
            this.m_panelChamps.Location = new System.Drawing.Point(0, 0);
            this.m_panelChamps.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelChamps, "");
            this.m_panelChamps.Name = "m_panelChamps";
            this.m_panelChamps.Ombre = false;
            this.m_panelChamps.PositionTop = true;
            this.m_panelChamps.Size = new System.Drawing.Size(806, 403);
            this.m_extStyle.SetStyleBackColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelChamps.TabIndex = 4;
            this.m_panelChamps.TextColor = System.Drawing.Color.Black;
            // 
            // CFormEditionTypeIntervention
            // 
            this.AffectationsPourNouvelElement = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("$this.AffectationsPourNouvelElement")));
            this.ClientSize = new System.Drawing.Size(830, 559);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_linkOperation.SetLinkField(this, "");
            this.m_extLinkField.SetLinkField(this, "");
            this.m_linkProfilIntervenant.SetLinkField(this, "");
            this.m_linkOperation.SetLinkFieldAutoUpdate(this, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_linkProfilIntervenant.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionTypeIntervention";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_tabControl;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionTypeIntervention_OnInitPage);
            this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionTypeIntervention_OnMajChampsPage);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre4, 0);
            this.Controls.SetChildIndex(this.m_tabControl, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.c2iPanelOmbre4.ResumeLayout(false);
            this.c2iPanelOmbre4.PerformLayout();
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.m_pageIntervenants.ResumeLayout(false);
            this.m_splitContainer1.Panel1.ResumeLayout(false);
            this.m_splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_splitContainer1)).EndInit();
            this.m_splitContainer1.ResumeLayout(false);
            this.m_panelProfilIntervenant.ResumeLayout(false);
            this.m_panelProfilIntervenant.PerformLayout();
            this.m_editFiltreDynamiqueIntervenants.ResumeLayout(false);
            this.m_pageOperations.ResumeLayout(false);
            this.m_panelOperation.ResumeLayout(false);
            this.m_panelOperation.PerformLayout();
            this.m_pageContraintes.ResumeLayout(false);
            this.m_pageChampsCustom.ResumeLayout(false);
            this.m_pageContactsPoss.ResumeLayout(false);
            this.m_pagePlanif.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.m_pageEvenements.ResumeLayout(false);
            this.m_pageFormulaires.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CTypeIntervention TypeIntervention
		{
			get
			{
				return (CTypeIntervention)ObjetEdite;
			}
		}

		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
			m_panelProfilIntervenant.Visible = false;
			AffecterTitre(I.T( "Intervention Type|333") + " " + TypeIntervention.Libelle);
            //m_tabControl.SelectedTab = m_pageOperations;
            InitFiltreDynamiqueIntervenants();

            // Visibilité de l'onglet Formulaires
            bool bHasFormulaires = false;
            foreach (IDefinisseurChampCustom def in TypeIntervention.DefinisseursDeChamps)
            {
                if (def.RelationsFormulaires.Length > 0)
                {
                    bHasFormulaires = true;
                    break;
                }
            }
            if (!bHasFormulaires)
            {
                if (m_tabControl.TabPages.Contains(m_pageFormulaires))
                    m_tabControl.TabPages.Remove(m_pageFormulaires);
            }
            else
            {
                if (!m_tabControl.TabPages.Contains(m_pageFormulaires))
                    m_tabControl.TabPages.Insert(0, m_pageFormulaires);
            }
			

			return result;
		}

        //-------------------------------------------------------------------------
        private void InitFiltreDynamiqueIntervenants()
        {
            CFiltreDynamique filtre = TypeIntervention.FiltreDynamiqueIntervenants;
            if (filtre != null)
                m_editFiltreDynamiqueIntervenants.InitSansVariables(filtre);
            else
                m_editFiltreDynamiqueIntervenants.InitSansVariables(new CFiltreDynamique(TypeIntervention.ContexteDonnee));

            m_editFiltreDynamiqueIntervenants.FiltreDynamique.TypeElements = typeof(CActeur);

            m_editFiltreDynamiqueIntervenants.ModeSansType = true;
            m_editFiltreDynamiqueIntervenants.MasquerFormulaire(true);
        }

		//-------------------------------------------------------------------------
		protected override CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = base.MAJ_Champs();
            if (!result)
                return result;

            if (m_editFiltreDynamiqueIntervenants.FiltreDynamique != null &&
            m_editFiltreDynamiqueIntervenants.FiltreDynamique.ComposantPrincipal != null)
                TypeIntervention.FiltreDynamiqueIntervenants = m_editFiltreDynamiqueIntervenants.FiltreDynamique;
            else
                TypeIntervention.FiltreDynamiqueIntervenants = null;


			return result;
		}

		//-------------------------------------------------------------------------
		private void m_panelListeActions_Load(object sender, System.EventArgs e)
		{
		
		}

		//-------------------------------------------------------------------------
		private void UpdateVisibilites()
		{

            //if ( m_radioComplexe.Checked )
            //{
            //    if ( m_tabControl.TabPages.Contains ( m_pageContraintes ) )
            //        m_tabControl.TabPages.Remove ( m_pageContraintes );
            //    if ( m_tabControl.TabPages.Contains ( m_pageIntervenants ) )
            //        m_tabControl.TabPages.Remove ( m_pageIntervenants ) ;
            //    if ( m_tabControl.TabPages.Contains ( m_pageOperations ) )
            //        m_tabControl.TabPages.Remove ( m_pageOperations );
            //}
            //else
            //{
            //    if ( !m_tabControl.TabPages.Contains( m_pageOperations ) )
            //        m_tabControl.TabPages.Insert ( 1, m_pageOperations );
            //    if ( !m_tabControl.TabPages.Contains ( m_pageIntervenants ) )
            //        m_tabControl.TabPages.Insert ( 2, m_pageIntervenants );
            //    if ( !m_tabControl.TabPages.Contains ( m_pageContraintes ) )
            //        m_tabControl.TabPages.Insert ( 3, m_pageContraintes );
            //}

		}


		private void c2iTabControl1_SelectionChanged(object sender, EventArgs e)
		{

		}

		//----------------------------------------------------------------------
		private void m_lnkAddOperation_LinkClicked(object sender, EventArgs e)
		{
			if (m_selectOperation.ElementSelectionne == null)
			{
				CFormAlerte.Afficher(I.T( "Select the operation type to add|371"), EFormAlerteType.Exclamation);
				return;
			}

			CTypeOperation tpOperation = (CTypeOperation)m_selectOperation.ElementSelectionne;

			CListeObjetsDonnees listeExistants = TypeIntervention.RelationsTypesOperations;
            int index = listeExistants.Count;
			listeExistants.Filtre = new CFiltreData(CTypeOperation.c_champId + "=@1",
				tpOperation.Id);
			if (listeExistants.Count != 0)
			{
				CFormAlerte.Afficher(I.T( "Can not add this operation type|372"), EFormAlerteType.Erreur);
				return;
			}
			m_selectOperation.ElementSelectionne = null;
			CTypeIntervention_TypeOperation rel = new CTypeIntervention_TypeOperation(TypeIntervention.ContexteDonnee);
			rel.CreateNewInCurrentContexte();
			rel.TypeIntervention = TypeIntervention;
			rel.TypeOperation = tpOperation;
            rel.Index = index;

			ListViewItem item = new ListViewItem();
			m_wndListeOperations.Items.Add(item);
			m_wndListeOperations.UpdateItemWithObject(item, rel);
			foreach (ListViewItem itemSel in m_wndListeOperations.SelectedItems)
				itemSel.Selected = false;
			item.Selected = true;
			InitSelectTypeOperation();
		}

		//----------------------------------------------------------------------
		private void m_lnkRemoveOperation_LinkClicked(object sender, EventArgs e)
		{
			if (m_wndListeOperations.SelectedItems.Count != 1)
				return;

			CTypeIntervention_TypeOperation rel = (CTypeIntervention_TypeOperation)m_wndListeOperations.SelectedItems[0].Tag;

			m_gestionnaireOperations.SetObjetEnCoursToNull();
			CResultAErreur result = rel.Delete();
			if (!result)
			{
				CFormAlerte.Afficher(result.Erreur);
				return;
			}

			if (m_wndListeOperations.SelectedItems.Count == 1)
			{
				if (m_wndListeOperations.SelectedItems[0] != null)
					m_wndListeOperations.SelectedItems[0].Remove();
			}
			InitSelectTypeOperation();
		}

		//----------------------------------------------------------------------
		private void InitSelectTypeOperation()
		{
            List<string> listIds = new List<string>();            
			string strIds = "";
			foreach (CTypeIntervention_TypeOperation rel in TypeIntervention.RelationsTypesOperations)
			{
                listIds.Add(rel.TypeOperation.Id.ToString());
			}
			CFiltreData filtre = null;
			if (listIds.Count > 0)
			{
                strIds = String.Join(",", listIds.ToArray());
				filtre = new CFiltreData(CTypeOperation.c_champId + " not in (" +
					strIds + ")");
			}
			m_selectOperation.InitAvecFiltreDeBase<CTypeOperation>(
				"Libelle",
				filtre,
                true);
		}

		//------------------------------------------------------------------------
		private void m_gestionnaireOperations_InitChamp(object sender, CObjetDonneeResultEventArgs args)
		{
			if (args.Objet == null)
				m_panelOperation.Visible = false;
			else
			{
				m_panelOperation.Visible = true;
				args.Result = m_linkOperation.FillDialogFromObjet(args.Objet);
			}
			
		}

		//------------------------------------------------------------------------
		private void m_gestionnaireOperations_MAJ_Champs(object sender, CObjetDonneeResultEventArgs args)
		{
			if (m_gestionnaireModeEdition.ModeEdition)
			{
				args.Result = m_linkOperation.FillObjetFromDialog(args.Objet);
			}

		}

		//------------------------------------------------------------------------
		private void m_gestionnaireProfilsIntervenants_InitChamp(object sender, CObjetDonneeResultEventArgs args)
		{
			if (args.Objet == null)
				m_panelProfilIntervenant.Visible = false;
			else
			{
				m_panelProfilIntervenant.Visible = true;
				args.Result = m_linkProfilIntervenant.FillDialogFromObjet(args.Objet);
				m_txtSelectProfil2.ElementSelectionne = ((CTypeIntervention_ProfilIntervenant)args.Objet).ProfilIntervenant;

			}
		}
		//------------------------------------------------------------------------
		private void m_gestionnaireProfilsIntervenants_MAJ_Champs(object sender, CObjetDonneeResultEventArgs args)
		{
			if (m_gestionnaireModeEdition.ModeEdition)
			{
				args.Result = m_linkProfilIntervenant.FillObjetFromDialog(args.Objet);
				if (m_txtSelectProfil2.ElementSelectionne is CProfilElement)
					((CTypeIntervention_ProfilIntervenant)args.Objet).ProfilIntervenant = (CProfilElement)m_txtSelectProfil2.ElementSelectionne;
			}
		}

		//----------------------------------------------------------------------
		private void InitSelectProfilIntervenant()
		{

			CFiltreData filtre = null;
			filtre = new CFiltreData ( CProfilElement.c_champTypeElements+"=@1 and "+
				CProfilElement.c_champTypeSource+"=@2",
				typeof(timos.acteurs.CActeur).ToString(),
				typeof ( CIntervention ).ToString() );
			m_txtSelectProfilIntervenant.InitAvecFiltreDeBase<CProfilElement>(
				"Libelle",
				filtre,
				true);
			m_txtSelectProfil2.Init<CProfilElement>(
				"Libelle", 
                true);
		}

		//----------------------------------------------------------------------
		private void m_btnAddProfilIntervenant_LinkClicked(object sender, EventArgs e)
		{
			if (m_txtSelectProfilIntervenant.ElementSelectionne == null)
			{
				CFormAlerte.Afficher(I.T( "Select the operator profil to add|390"), EFormAlerteType.Exclamation);
				return;
			}

			CProfilElement profil = (CProfilElement)m_txtSelectProfilIntervenant.ElementSelectionne;

			m_txtSelectProfilIntervenant.ElementSelectionne = null;
			CTypeIntervention_ProfilIntervenant rel = new CTypeIntervention_ProfilIntervenant(TypeIntervention.ContexteDonnee);
			rel.CreateNewInCurrentContexte();
			rel.TypeIntervention = TypeIntervention;
			rel.ProfilIntervenant = profil;

			ListViewItem item = new ListViewItem();
			m_wndListeProfilsIntervenants.Items.Add(item);
			m_wndListeProfilsIntervenants.UpdateItemWithObject(item, rel);
			foreach (ListViewItem itemSel in m_wndListeProfilsIntervenants.SelectedItems)
				itemSel.Selected = false;
			item.Selected = true;
			//InitSelectProfilIntervenant();
		}

		//----------------------------------------------------------------------
		private void m_btnRemoveProfilIntervenant_LinkClicked(object sender, EventArgs e)
		{
			if (m_wndListeProfilsIntervenants.SelectedItems.Count != 1)
				return;

			CTypeIntervention_ProfilIntervenant rel = (CTypeIntervention_ProfilIntervenant)m_wndListeProfilsIntervenants.SelectedItems[0].Tag;

			m_gestionnaireProfilsIntervenants.SetObjetEnCoursToNull();
			CResultAErreur result = rel.Delete();
			if (!result)
			{
				CFormAlerte.Afficher(result.Erreur);
				return;
			}

			if (m_wndListeProfilsIntervenants.SelectedItems.Count == 1)
			{
				if (m_wndListeProfilsIntervenants.SelectedItems[0] != null)
					m_wndListeProfilsIntervenants.SelectedItems[0].Remove();
			}
			//InitSelectProfilIntervenant();
		}

		//--------------------------------------------------------------------
		private void m_cmbTypeActivite_SelectionChangeCommitted(object sender, EventArgs e)
		{
			TypeIntervention.TypeActiviteActeur = (CTypeActiviteActeur)m_cmbTypeActivite.ElementSelectionne;
			m_lnkParametrerActivite.Visible = m_cmbTypeActivite.ElementSelectionne != null;
		}

		private void m_lnkParametrerActivite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (m_cmbTypeActivite.ElementSelectionne == null)
				return;
			CFormEditeParametrageRemplissageTypeActivite.EditeParametre(
				ref m_parametreRemplissageActivite,
				(CTypeActiviteActeur)m_cmbTypeActivite.ElementSelectionne);
		}

		//--------------------------------------------------------------------
		private CResultAErreur CFormEditionTypeIntervention_OnInitPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			using(CWaitCursor waiter = new CWaitCursor())
			{
                if (page == m_pageFormulaires)
                {
                    m_panelChamps.ElementEdite = TypeIntervention;
                }
				if (page == m_pageChampsCustom)
				{
					m_panelEditChamps.InitPanel(
					TypeIntervention,
					typeof(CFormListeChampsCustom),
					typeof(CFormListeFormulaires));
				}
				else if (page == m_pageContactsPoss)
				{
					m_ctrlProfilsActeursPossibles.Init(TypeIntervention);
				}
				else if (page == m_pageContraintes)
				{
					m_panelListeContraintes.InitFromListeObjets(
						TypeIntervention.Contraintes,
						typeof(CContrainte),
						typeof(CFormEditionContrainte),
						TypeIntervention,
						"TypeIntervention");

					CListeObjetsDonnees listeProfils = new CListeObjetsDonnees(TypeIntervention.ContexteDonnee, typeof(CProfilElement));
					listeProfils.Filtre = new CFiltreData(
						CProfilElement.c_champTypeElements + "=@1 and " +
						CProfilElement.c_champTypeSource + "=@2",
						typeof(CRessourceMaterielle).ToString(),
						typeof(CIntervention).ToString());

					m_cmbProfilRessourceDefaut.Init(
						listeProfils,
						"Libelle",
						false);

					m_cmbProfilRessourceDefaut.ElementSelectionne = TypeIntervention.ProfilRessourceDefaut;
				}
				else if (page == m_pageEvenements)
				{
					m_panelDefinisseurEvenements.InitChamps(TypeIntervention);
				}
				else if (page == m_pageIntervenants)
				{
					m_gestionnaireProfilsIntervenants.ObjetEdite = TypeIntervention.RelationsProfilsIntervenants;
					InitSelectProfilIntervenant();
				}
				else if (page == m_pageOperations)
				{
					m_gestionnaireOperations.ObjetEdite = TypeIntervention.RelationsTypesOperations;
					InitSelectTypeOperation();
				}
				else if (page == m_pagePlanif)
				{
					CFiltreData filtreProfil = new CFiltreData(
						CProfilElement.c_champTypeElements + "=@1 and " +
						CProfilElement.c_champTypeSource + "=@2",
						typeof(CDonneesActeurUtilisateur).ToString(),
						typeof(CIntervention).ToString());

					CListeObjetsDonnees listeProfilsPlan = new CListeObjetsDonnees(TypeIntervention.ContexteDonnee, typeof(CProfilElement));
					listeProfilsPlan.Filtre = filtreProfil;
					m_cmbProfilPrePlanifieur.Init(
						listeProfilsPlan,
						"Libelle",
						false);
					m_cmbProfilPrePlanifieur.ElementSelectionne = TypeIntervention.ProfilPreplanifieur;

					m_cmbProfilPlanifieur.Init(
						listeProfilsPlan,
						"Libelle",
						false);
					m_cmbProfilPlanifieur.ElementSelectionne = TypeIntervention.ProfilPlanifieur;

					m_cmbTypeActivite.Init(
						typeof(CTypeActiviteActeur),
						"Libelle",
						false);
					m_cmbTypeActivite.ElementSelectionne = TypeIntervention.TypeActiviteActeur;
					m_lnkParametrerActivite.Visible = m_cmbTypeActivite.ElementSelectionne != null;
					m_parametreRemplissageActivite = TypeIntervention.ParametreRemplissageActivite;
				}
			}

			return result;
		}
		private CResultAErreur CFormEditionTypeIntervention_OnMajChampsPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;

            if (page == m_pageFormulaires)
            {
                result = m_panelChamps.MAJ_Champs();
            }
			if (page == m_pageChampsCustom)
			{
				result = m_panelEditChamps.MAJ_Champs();
			}
			else if (page == m_pageContactsPoss)
			{
				result = m_ctrlProfilsActeursPossibles.MAJ_Champs();
			}
			else if (page == m_pageContraintes)
			{
				TypeIntervention.ProfilRessourceDefaut = (CProfilElement)m_cmbProfilRessourceDefaut.ElementSelectionne;
			}
			else if (page == m_pageEvenements)
			{
				result = m_panelDefinisseurEvenements.MAJ_Champs();
			}
			else if (page == m_pageIntervenants)
			{
				result = m_gestionnaireProfilsIntervenants.ValideModifs();
			}
			else if (page == m_pageOperations)
			{
				result = m_gestionnaireOperations.ValideModifs();
			}
			else if (page == m_pagePlanif)
			{
				TypeIntervention.TypeActiviteActeur = (CTypeActiviteActeur)m_cmbTypeActivite.ElementSelectionne;
				if (TypeIntervention.TypeActiviteActeur != null)
					TypeIntervention.ParametreRemplissageActivite = m_parametreRemplissageActivite;
				else
					TypeIntervention.ParametreRemplissageActivite = null;

				TypeIntervention.ProfilPreplanifieur = (CProfilElement)m_cmbProfilPrePlanifieur.ElementSelectionne;
				TypeIntervention.ProfilPlanifieur = (CProfilElement)m_cmbProfilPlanifieur.ElementSelectionne;
			}
			return result;
		}
	}
}

