using System;
using System.Collections;
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
using timos.win32.composants;

using timos.acteurs;

using timos.data;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CContrainte))]
	public class CFormEditionContrainte : CFormEditionStdTimos, IFormNavigable
	{
		#region Designer generated code

		private System.Windows.Forms.Label m_lblLibelle;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre m_panTop;
        private C2iTabControl m_TabControl;
        private Label m_lblTypeCont;
        private Crownwood.Magic.Controls.TabPage m_pageRessources;
        private Crownwood.Magic.Controls.TabPage m_pageChampsCustom;
        private sc2i.win32.data.dynamic.CPanelChampsCustom m_panelChampsCustom;
        private C2iTextBox m_txtInformations;
        private C2iTextBoxSelectionne m_txtFiltreListeRessource;
        private ListViewAutoFilled m_listeRelationsRessources;
        private ListViewAutoFilledColumn colLibelle;
        private CWndLinkStd m_WndLinkSuppr;
        private CWndLinkStd m_wndLinkAjout;
        private Label m_lblSelect;
        private LinkLabel m_linkNewRessource;
        private Label lbl_descrip;
        private CComboBoxArbreObjetDonneesHierarchique m_cmbxTypeContrainte;
        private Label lbl_contrainterelativea;
        private LinkLabel m_lnkEmplacement;
        private Crownwood.Magic.Controls.TabPage m_pageAttributs;
        private CComboBoxListeObjetsDonnees m_cmbxSelectAttributTypeCont;
        private CWndLinkStd m_lnkSupprimerAttribut;
        private Label label4;
        private C2iTextBox m_txtAttributLibre;
        private CWndLinkStd m_lnkAjouterAttributTypeCont;
        private CWndLinkStd m_lnkAjouterAttribut;
        private Label m_lblSaisie;
        private ListViewAutoFilled m_listeAttributs;
        private ListViewAutoFilledColumn m_listeAttributsColonne1;
        private Label label5;
        private Panel m_panelEditionAttribut;
        private Label label6;
        private C2iTextBox m_txtModifierAttributLibelle;
        private CExtLinkField m_extLinkEditionAttribut;
        private CGestionnaireEditionSousObjetDonnee m_gestionnaireEditionAttribut;
        private LinkLabel m_lnkToutesRessourcesLevant;
		private LinkLabel linkLabel1;
		private CheckBox m_chkCheckList;
		private CReducteurControle m_reducteurPanTop;
		private System.ComponentModel.IContainer components = null;

	
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

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.m_lblLibelle = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.m_panTop = new sc2i.win32.common.C2iPanelOmbre();
            this.m_chkCheckList = new System.Windows.Forms.CheckBox();
            this.m_txtInformations = new sc2i.win32.common.C2iTextBox();
            this.m_cmbxTypeContrainte = new sc2i.win32.data.navigation.CComboBoxArbreObjetDonneesHierarchique();
            this.m_lblTypeCont = new System.Windows.Forms.Label();
            this.m_lnkEmplacement = new System.Windows.Forms.LinkLabel();
            this.lbl_descrip = new System.Windows.Forms.Label();
            this.lbl_contrainterelativea = new System.Windows.Forms.Label();
            this.m_TabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageChampsCustom = new Crownwood.Magic.Controls.TabPage();
            this.m_panelChampsCustom = new sc2i.win32.data.dynamic.CPanelChampsCustom();
            this.m_pageAttributs = new Crownwood.Magic.Controls.TabPage();
            this.m_panelEditionAttribut = new System.Windows.Forms.Panel();
            this.m_txtModifierAttributLibelle = new sc2i.win32.common.C2iTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_listeAttributs = new sc2i.win32.common.ListViewAutoFilled();
            this.m_listeAttributsColonne1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_cmbxSelectAttributTypeCont = new sc2i.win32.data.CComboBoxListeObjetsDonnees();
            this.m_lnkSupprimerAttribut = new sc2i.win32.common.CWndLinkStd();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txtAttributLibre = new sc2i.win32.common.C2iTextBox();
            this.m_lnkAjouterAttributTypeCont = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkAjouterAttribut = new sc2i.win32.common.CWndLinkStd();
            this.m_lblSaisie = new System.Windows.Forms.Label();
            this.m_pageRessources = new Crownwood.Magic.Controls.TabPage();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.m_lnkToutesRessourcesLevant = new System.Windows.Forms.LinkLabel();
            this.m_linkNewRessource = new System.Windows.Forms.LinkLabel();
            this.m_lblSelect = new System.Windows.Forms.Label();
            this.m_WndLinkSuppr = new sc2i.win32.common.CWndLinkStd();
            this.m_wndLinkAjout = new sc2i.win32.common.CWndLinkStd();
            this.m_listeRelationsRessources = new sc2i.win32.common.ListViewAutoFilled();
            this.colLibelle = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_txtFiltreListeRessource = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_gestionnaireEditionAttribut = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.m_extLinkEditionAttribut = new sc2i.win32.common.CExtLinkField();
            this.m_reducteurPanTop = new sc2i.win32.common.CReducteurControle();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            this.m_panTop.SuspendLayout();
            this.m_TabControl.SuspendLayout();
            this.m_pageChampsCustom.SuspendLayout();
            this.m_pageAttributs.SuspendLayout();
            this.m_panelEditionAttribut.SuspendLayout();
            this.m_pageRessources.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnAnnulerModifications
            // 
            this.m_extLinkEditionAttribut.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_extLinkField.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAnnulerModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnValiderModifications
            // 
            this.m_extLinkEditionAttribut.SetLinkField(this.m_btnValiderModifications, "");
            this.m_extLinkField.SetLinkField(this.m_btnValiderModifications, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnValiderModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnSupprimerObjet
            // 
            this.m_extLinkEditionAttribut.SetLinkField(this.m_btnSupprimerObjet, "");
            this.m_extLinkField.SetLinkField(this.m_btnSupprimerObjet, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnSupprimerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnEditerObjet
            // 
            this.m_extLinkEditionAttribut.SetLinkField(this.m_btnEditerObjet, "");
            this.m_extLinkField.SetLinkField(this.m_btnEditerObjet, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnEditerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelNavigation
            // 
            this.m_extLinkField.SetLinkField(this.m_panelNavigation, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_panelNavigation, "");
            this.m_panelNavigation.Location = new System.Drawing.Point(694, 0);
            this.m_extStyle.SetStyleBackColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelCle
            // 
            this.m_extLinkField.SetLinkField(this.m_panelCle, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_panelCle, "");
            this.m_panelCle.Location = new System.Drawing.Point(610, 0);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_extLinkField.SetLinkField(this.m_panelMenu, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_panelMenu, "");
            this.m_panelMenu.Size = new System.Drawing.Size(830, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnHistorique
            // 
            this.m_extLinkEditionAttribut.SetLinkField(this.m_btnHistorique, "");
            this.m_extLinkField.SetLinkField(this.m_btnHistorique, "");
            this.m_extStyle.SetStyleBackColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_lblLibelle
            // 
            this.m_extLinkField.SetLinkField(this.m_lblLibelle, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_lblLibelle, "");
            this.m_lblLibelle.Location = new System.Drawing.Point(16, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblLibelle, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblLibelle.Name = "m_lblLibelle";
            this.m_lblLibelle.Size = new System.Drawing.Size(154, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lblLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblLibelle.TabIndex = 4002;
            this.m_lblLibelle.Text = "Constraint label|260";
            // 
            // m_txtLibelle
            // 
            this.m_txtLibelle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_txtLibelle, "");
            this.m_txtLibelle.Location = new System.Drawing.Point(176, 8);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(463, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Label]|30324";
            // 
            // m_panTop
            // 
            this.m_panTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panTop.Controls.Add(this.m_chkCheckList);
            this.m_panTop.Controls.Add(this.m_txtInformations);
            this.m_panTop.Controls.Add(this.m_lblLibelle);
            this.m_panTop.Controls.Add(this.m_txtLibelle);
            this.m_panTop.Controls.Add(this.m_cmbxTypeContrainte);
            this.m_panTop.Controls.Add(this.m_lblTypeCont);
            this.m_panTop.Controls.Add(this.m_lnkEmplacement);
            this.m_panTop.Controls.Add(this.lbl_descrip);
            this.m_panTop.Controls.Add(this.lbl_contrainterelativea);
            this.m_panTop.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkEditionAttribut.SetLinkField(this.m_panTop, "");
            this.m_extLinkField.SetLinkField(this.m_panTop, "");
            this.m_panTop.Location = new System.Drawing.Point(8, 52);
            this.m_panTop.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panTop, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panTop.Name = "m_panTop";
            this.m_panTop.Size = new System.Drawing.Size(679, 176);
            this.m_extStyle.SetStyleBackColor(this.m_panTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panTop.TabIndex = 0;
            // 
            // m_chkCheckList
            // 
            this.m_chkCheckList.AutoSize = true;
            this.m_chkCheckList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_extLinkEditionAttribut.SetLinkField(this.m_chkCheckList, "");
            this.m_extLinkField.SetLinkField(this.m_chkCheckList, "");
            this.m_chkCheckList.Location = new System.Drawing.Point(173, 140);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkCheckList, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkCheckList.Name = "m_chkCheckList";
            this.m_chkCheckList.Size = new System.Drawing.Size(193, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkCheckList, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkCheckList, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkCheckList.TabIndex = 4008;
            this.m_chkCheckList.Text = "Show on Intervention Check list|804";
            this.m_chkCheckList.ThreeState = true;
            this.m_chkCheckList.UseVisualStyleBackColor = true;
            this.m_chkCheckList.CheckStateChanged += new System.EventHandler(this.m_chkCheckList_CheckStateChanged);
            // 
            // m_txtInformations
            // 
            this.m_txtInformations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_txtInformations, "Informations");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_txtInformations, "");
            this.m_txtInformations.Location = new System.Drawing.Point(173, 84);
            this.m_txtInformations.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtInformations, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtInformations.Multiline = true;
            this.m_txtInformations.Name = "m_txtInformations";
            this.m_txtInformations.Size = new System.Drawing.Size(466, 50);
            this.m_extStyle.SetStyleBackColor(this.m_txtInformations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtInformations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtInformations.TabIndex = 0;
            this.m_txtInformations.Text = "[Informations]";
            // 
            // m_cmbxTypeContrainte
            // 
            this.m_cmbxTypeContrainte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbxTypeContrainte.BackColor = System.Drawing.Color.White;
            this.m_cmbxTypeContrainte.ElementSelectionne = null;
            this.m_extLinkField.SetLinkField(this.m_cmbxTypeContrainte, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_cmbxTypeContrainte, "");
            this.m_cmbxTypeContrainte.Location = new System.Drawing.Point(176, 34);
            this.m_cmbxTypeContrainte.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbxTypeContrainte, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbxTypeContrainte.Name = "m_cmbxTypeContrainte";
            this.m_cmbxTypeContrainte.NullAutorise = false;
            this.m_cmbxTypeContrainte.Size = new System.Drawing.Size(463, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbxTypeContrainte, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbxTypeContrainte, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbxTypeContrainte.TabIndex = 4005;
            this.m_cmbxTypeContrainte.TextNull = I.T("[None]|30290");
            this.m_cmbxTypeContrainte.ElementSelectionneChanged += new System.EventHandler(this.m_cmbxTypeContrainte_ElementSelectionneChanged);
            // 
            // m_lblTypeCont
            // 
            this.m_extLinkField.SetLinkField(this.m_lblTypeCont, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_lblTypeCont, "");
            this.m_lblTypeCont.Location = new System.Drawing.Point(16, 38);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblTypeCont, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblTypeCont.Name = "m_lblTypeCont";
            this.m_lblTypeCont.Size = new System.Drawing.Size(154, 17);
            this.m_extStyle.SetStyleBackColor(this.m_lblTypeCont, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblTypeCont, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblTypeCont.TabIndex = 4004;
            this.m_lblTypeCont.Text = "Constraint Type|258";
            // 
            // m_lnkEmplacement
            // 
            this.m_lnkEmplacement.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lnkEmplacement, "Emplacement.DescriptionElement");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_lnkEmplacement, "");
            this.m_lnkEmplacement.Location = new System.Drawing.Point(173, 64);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkEmplacement, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lnkEmplacement.Name = "m_lnkEmplacement";
            this.m_lnkEmplacement.Size = new System.Drawing.Size(171, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkEmplacement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkEmplacement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkEmplacement.TabIndex = 4007;
            this.m_lnkEmplacement.TabStop = true;
            this.m_lnkEmplacement.Text = "[Emplacement.DescriptionElement]";
            this.m_lnkEmplacement.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkEmplacement_LinkClicked);
            // 
            // lbl_descrip
            // 
            this.m_extLinkField.SetLinkField(this.lbl_descrip, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.lbl_descrip, "");
            this.lbl_descrip.Location = new System.Drawing.Point(16, 87);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_descrip, sc2i.win32.common.TypeModeEdition.Autonome);
            this.lbl_descrip.Name = "lbl_descrip";
            this.lbl_descrip.Size = new System.Drawing.Size(151, 13);
            this.m_extStyle.SetStyleBackColor(this.lbl_descrip, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.lbl_descrip, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_descrip.TabIndex = 4007;
            this.lbl_descrip.Text = "Constraint description|289";
            // 
            // lbl_contrainterelativea
            // 
            this.m_extLinkField.SetLinkField(this.lbl_contrainterelativea, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.lbl_contrainterelativea, "");
            this.lbl_contrainterelativea.Location = new System.Drawing.Point(16, 64);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_contrainterelativea, sc2i.win32.common.TypeModeEdition.Autonome);
            this.lbl_contrainterelativea.Name = "lbl_contrainterelativea";
            this.lbl_contrainterelativea.Size = new System.Drawing.Size(154, 13);
            this.m_extStyle.SetStyleBackColor(this.lbl_contrainterelativea, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.lbl_contrainterelativea, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_contrainterelativea.TabIndex = 4006;
            this.lbl_contrainterelativea.Text = "Constraint related to :|803";
            // 
            // m_TabControl
            // 
            this.m_TabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_TabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_TabControl.BoldSelectedPage = true;
            this.m_TabControl.ControlBottomOffset = 16;
            this.m_TabControl.ControlRightOffset = 16;
            this.m_TabControl.ForeColor = System.Drawing.Color.Black;
            this.m_TabControl.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_TabControl, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_TabControl, "");
            this.m_TabControl.Location = new System.Drawing.Point(8, 234);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_TabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_TabControl.Name = "m_TabControl";
            this.m_TabControl.Ombre = true;
            this.m_TabControl.PositionTop = true;
            this.m_TabControl.SelectedIndex = 2;
            this.m_TabControl.SelectedTab = this.m_pageRessources;
            this.m_TabControl.Size = new System.Drawing.Size(810, 284);
            this.m_extStyle.SetStyleBackColor(this.m_TabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_TabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_TabControl.TabIndex = 4004;
            this.m_TabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageChampsCustom,
            this.m_pageAttributs,
            this.m_pageRessources});
            this.m_TabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageChampsCustom
            // 
            this.m_pageChampsCustom.Controls.Add(this.m_panelChampsCustom);
            this.m_extLinkEditionAttribut.SetLinkField(this.m_pageChampsCustom, "");
            this.m_extLinkField.SetLinkField(this.m_pageChampsCustom, "");
            this.m_pageChampsCustom.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageChampsCustom, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_pageChampsCustom.Name = "m_pageChampsCustom";
            this.m_pageChampsCustom.Selected = false;
            this.m_pageChampsCustom.Size = new System.Drawing.Size(794, 243);
            this.m_extStyle.SetStyleBackColor(this.m_pageChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageChampsCustom.TabIndex = 12;
            this.m_pageChampsCustom.Title = "Form|60";
            // 
            // m_panelChampsCustom
            // 
            this.m_panelChampsCustom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelChampsCustom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelChampsCustom.BoldSelectedPage = true;
            this.m_panelChampsCustom.ElementEdite = null;
            this.m_panelChampsCustom.ForeColor = System.Drawing.Color.Black;
            this.m_panelChampsCustom.IDEPixelArea = false;
            this.m_extLinkEditionAttribut.SetLinkField(this.m_panelChampsCustom, "");
            this.m_extLinkField.SetLinkField(this.m_panelChampsCustom, "");
            this.m_panelChampsCustom.Location = new System.Drawing.Point(4, 3);
            this.m_panelChampsCustom.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelChampsCustom, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelChampsCustom.Name = "m_panelChampsCustom";
            this.m_panelChampsCustom.Ombre = false;
            this.m_panelChampsCustom.PositionTop = true;
            this.m_panelChampsCustom.Size = new System.Drawing.Size(778, 229);
            this.m_extStyle.SetStyleBackColor(this.m_panelChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panelChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelChampsCustom.TabIndex = 0;
            this.m_panelChampsCustom.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageAttributs
            // 
            this.m_pageAttributs.Controls.Add(this.m_panelEditionAttribut);
            this.m_pageAttributs.Controls.Add(this.label5);
            this.m_pageAttributs.Controls.Add(this.m_listeAttributs);
            this.m_pageAttributs.Controls.Add(this.m_cmbxSelectAttributTypeCont);
            this.m_pageAttributs.Controls.Add(this.m_lnkSupprimerAttribut);
            this.m_pageAttributs.Controls.Add(this.label4);
            this.m_pageAttributs.Controls.Add(this.m_txtAttributLibre);
            this.m_pageAttributs.Controls.Add(this.m_lnkAjouterAttributTypeCont);
            this.m_pageAttributs.Controls.Add(this.m_lnkAjouterAttribut);
            this.m_pageAttributs.Controls.Add(this.m_lblSaisie);
            this.m_extLinkEditionAttribut.SetLinkField(this.m_pageAttributs, "");
            this.m_extLinkField.SetLinkField(this.m_pageAttributs, "");
            this.m_pageAttributs.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageAttributs, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_pageAttributs.Name = "m_pageAttributs";
            this.m_pageAttributs.Selected = false;
            this.m_pageAttributs.Size = new System.Drawing.Size(794, 243);
            this.m_extStyle.SetStyleBackColor(this.m_pageAttributs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageAttributs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageAttributs.TabIndex = 10;
            this.m_pageAttributs.Title = "Attribute management|280";
            // 
            // m_panelEditionAttribut
            // 
            this.m_panelEditionAttribut.Controls.Add(this.m_txtModifierAttributLibelle);
            this.m_panelEditionAttribut.Controls.Add(this.label6);
            this.m_extLinkField.SetLinkField(this.m_panelEditionAttribut, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_panelEditionAttribut, "");
            this.m_panelEditionAttribut.Location = new System.Drawing.Point(375, 105);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEditionAttribut, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelEditionAttribut.Name = "m_panelEditionAttribut";
            this.m_panelEditionAttribut.Size = new System.Drawing.Size(276, 129);
            this.m_extStyle.SetStyleBackColor(this.m_panelEditionAttribut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEditionAttribut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEditionAttribut.TabIndex = 4017;
            // 
            // m_txtModifierAttributLibelle
            // 
            this.m_extLinkField.SetLinkField(this.m_txtModifierAttributLibelle, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_txtModifierAttributLibelle, "Libelle");
            this.m_txtModifierAttributLibelle.Location = new System.Drawing.Point(8, 26);
            this.m_txtModifierAttributLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtModifierAttributLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtModifierAttributLibelle.Name = "m_txtModifierAttributLibelle";
            this.m_txtModifierAttributLibelle.Size = new System.Drawing.Size(252, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtModifierAttributLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtModifierAttributLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtModifierAttributLibelle.TabIndex = 2;
            this.m_txtModifierAttributLibelle.Text = "[Label]|30324";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.label6, "");
            this.label6.Location = new System.Drawing.Point(5, 10);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 13);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 0;
            this.label6.Text = "Edit Attribute Label|375";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.label5, "");
            this.label5.Location = new System.Drawing.Point(25, 86);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 4016;
            this.label5.Text = "Attribute List|374";
            // 
            // m_listeAttributs
            // 
            this.m_listeAttributs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_listeAttributs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_listeAttributsColonne1});
            this.m_listeAttributs.EnableCustomisation = true;
            this.m_listeAttributs.FullRowSelect = true;
            this.m_listeAttributs.HideSelection = false;
            this.m_extLinkEditionAttribut.SetLinkField(this.m_listeAttributs, "");
            this.m_extLinkField.SetLinkField(this.m_listeAttributs, "");
            this.m_listeAttributs.Location = new System.Drawing.Point(23, 102);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_listeAttributs, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_listeAttributs.MultiSelect = false;
            this.m_listeAttributs.Name = "m_listeAttributs";
            this.m_listeAttributs.Size = new System.Drawing.Size(334, 94);
            this.m_extStyle.SetStyleBackColor(this.m_listeAttributs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_listeAttributs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_listeAttributs.TabIndex = 4015;
            this.m_listeAttributs.UseCompatibleStateImageBehavior = false;
            this.m_listeAttributs.View = System.Windows.Forms.View.Details;
            // 
            // m_listeAttributsColonne1
            // 
            this.m_listeAttributsColonne1.Field = "AttributString";
            this.m_listeAttributsColonne1.PrecisionWidth = 0;
            this.m_listeAttributsColonne1.ProportionnalSize = false;
            this.m_listeAttributsColonne1.Text = "Label|50";
            this.m_listeAttributsColonne1.Visible = true;
            this.m_listeAttributsColonne1.Width = 508;
            // 
            // m_cmbxSelectAttributTypeCont
            // 
            this.m_cmbxSelectAttributTypeCont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbxSelectAttributTypeCont.ElementSelectionne = null;
            this.m_cmbxSelectAttributTypeCont.FormattingEnabled = true;
            this.m_cmbxSelectAttributTypeCont.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbxSelectAttributTypeCont, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_cmbxSelectAttributTypeCont, "");
            this.m_cmbxSelectAttributTypeCont.ListDonnees = null;
            this.m_cmbxSelectAttributTypeCont.Location = new System.Drawing.Point(320, 30);
            this.m_cmbxSelectAttributTypeCont.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbxSelectAttributTypeCont, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbxSelectAttributTypeCont.Name = "m_cmbxSelectAttributTypeCont";
            this.m_cmbxSelectAttributTypeCont.NullAutorise = false;
            this.m_cmbxSelectAttributTypeCont.ProprieteAffichee = null;
            this.m_cmbxSelectAttributTypeCont.ProprieteParentListeObjets = null;
            this.m_cmbxSelectAttributTypeCont.SelectionneurParent = null;
            this.m_cmbxSelectAttributTypeCont.Size = new System.Drawing.Size(271, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbxSelectAttributTypeCont, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbxSelectAttributTypeCont, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbxSelectAttributTypeCont.TabIndex = 4014;
            this.m_cmbxSelectAttributTypeCont.TextNull = I.T("(empty)|30195");
            this.m_cmbxSelectAttributTypeCont.Tri = true;
            // 
            // m_lnkSupprimerAttribut
            // 
            this.m_lnkSupprimerAttribut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkSupprimerAttribut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkSupprimerAttribut.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkEditionAttribut.SetLinkField(this.m_lnkSupprimerAttribut, "");
            this.m_extLinkField.SetLinkField(this.m_lnkSupprimerAttribut, "");
            this.m_lnkSupprimerAttribut.Location = new System.Drawing.Point(19, 207);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkSupprimerAttribut, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkSupprimerAttribut.Name = "m_lnkSupprimerAttribut";
            this.m_lnkSupprimerAttribut.Size = new System.Drawing.Size(100, 21);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSupprimerAttribut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSupprimerAttribut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSupprimerAttribut.TabIndex = 4010;
            this.m_lnkSupprimerAttribut.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkSupprimerAttribut.LinkClicked += new System.EventHandler(this.m_lnkSupprimer_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.label4, "");
            this.label4.Location = new System.Drawing.Point(317, 14);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 13);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 4007;
            this.label4.Text = "Select Attributes from list|357";
            // 
            // m_txtAttributLibre
            // 
            this.m_extLinkField.SetLinkField(this.m_txtAttributLibre, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_txtAttributLibre, "");
            this.m_txtAttributLibre.Location = new System.Drawing.Point(23, 30);
            this.m_txtAttributLibre.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtAttributLibre, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtAttributLibre.Name = "m_txtAttributLibre";
            this.m_txtAttributLibre.Size = new System.Drawing.Size(253, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtAttributLibre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtAttributLibre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtAttributLibre.TabIndex = 4012;
            // 
            // m_lnkAjouterAttributTypeCont
            // 
            this.m_lnkAjouterAttributTypeCont.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAjouterAttributTypeCont.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkEditionAttribut.SetLinkField(this.m_lnkAjouterAttributTypeCont, "");
            this.m_extLinkField.SetLinkField(this.m_lnkAjouterAttributTypeCont, "");
            this.m_lnkAjouterAttributTypeCont.Location = new System.Drawing.Point(320, 57);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAjouterAttributTypeCont, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkAjouterAttributTypeCont.Name = "m_lnkAjouterAttributTypeCont";
            this.m_lnkAjouterAttributTypeCont.Size = new System.Drawing.Size(100, 21);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAjouterAttributTypeCont, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAjouterAttributTypeCont, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAjouterAttributTypeCont.TabIndex = 4009;
            this.m_lnkAjouterAttributTypeCont.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAjouterAttributTypeCont.LinkClicked += new System.EventHandler(this.m_lnkAjouterAttributTypeCont_LinkClicked);
            // 
            // m_lnkAjouterAttribut
            // 
            this.m_lnkAjouterAttribut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAjouterAttribut.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkEditionAttribut.SetLinkField(this.m_lnkAjouterAttribut, "");
            this.m_extLinkField.SetLinkField(this.m_lnkAjouterAttribut, "");
            this.m_lnkAjouterAttribut.Location = new System.Drawing.Point(23, 57);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAjouterAttribut, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkAjouterAttribut.Name = "m_lnkAjouterAttribut";
            this.m_lnkAjouterAttribut.Size = new System.Drawing.Size(100, 21);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAjouterAttribut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAjouterAttribut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAjouterAttribut.TabIndex = 4009;
            this.m_lnkAjouterAttribut.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAjouterAttribut.LinkClicked += new System.EventHandler(this.m_lnkAjouter_LinkClicked);
            // 
            // m_lblSaisie
            // 
            this.m_lblSaisie.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lblSaisie, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_lblSaisie, "");
            this.m_lblSaisie.Location = new System.Drawing.Point(25, 14);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblSaisie, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblSaisie.Name = "m_lblSaisie";
            this.m_lblSaisie.Size = new System.Drawing.Size(141, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblSaisie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblSaisie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblSaisie.TabIndex = 4007;
            this.m_lblSaisie.Text = "Enter new free Attribute|282";
            // 
            // m_pageRessources
            // 
            this.m_pageRessources.Controls.Add(this.linkLabel1);
            this.m_pageRessources.Controls.Add(this.m_lnkToutesRessourcesLevant);
            this.m_pageRessources.Controls.Add(this.m_linkNewRessource);
            this.m_pageRessources.Controls.Add(this.m_lblSelect);
            this.m_pageRessources.Controls.Add(this.m_WndLinkSuppr);
            this.m_pageRessources.Controls.Add(this.m_wndLinkAjout);
            this.m_pageRessources.Controls.Add(this.m_listeRelationsRessources);
            this.m_pageRessources.Controls.Add(this.m_txtFiltreListeRessource);
            this.m_extLinkEditionAttribut.SetLinkField(this.m_pageRessources, "");
            this.m_extLinkField.SetLinkField(this.m_pageRessources, "");
            this.m_pageRessources.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageRessources, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_pageRessources.Name = "m_pageRessources";
            this.m_pageRessources.Size = new System.Drawing.Size(794, 243);
            this.m_extStyle.SetStyleBackColor(this.m_pageRessources, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageRessources, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageRessources.TabIndex = 11;
            this.m_pageRessources.Title = "Resources management|263";
            // 
            // linkLabel1
            // 
            this.m_extLinkField.SetLinkField(this.linkLabel1, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.linkLabel1, "");
            this.linkLabel1.Location = new System.Drawing.Point(205, 50);
            this.m_gestionnaireModeEdition.SetModeEdition(this.linkLabel1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(243, 13);
            this.m_extStyle.SetStyleBackColor(this.linkLabel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.linkLabel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Does this Resource raise the Constraint ?|1225";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // m_lnkToutesRessourcesLevant
            // 
            this.m_extLinkField.SetLinkField(this.m_lnkToutesRessourcesLevant, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_lnkToutesRessourcesLevant, "");
            this.m_lnkToutesRessourcesLevant.Location = new System.Drawing.Point(525, 50);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkToutesRessourcesLevant, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lnkToutesRessourcesLevant.Name = "m_lnkToutesRessourcesLevant";
            this.m_lnkToutesRessourcesLevant.Size = new System.Drawing.Size(201, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkToutesRessourcesLevant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkToutesRessourcesLevant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkToutesRessourcesLevant.TabIndex = 6;
            this.m_lnkToutesRessourcesLevant.TabStop = true;
            this.m_lnkToutesRessourcesLevant.Text = "Find a Resource|805";
            this.m_lnkToutesRessourcesLevant.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkToutesRessourcesLevant_LinkClicked);
            // 
            // m_linkNewRessource
            // 
            this.m_extLinkField.SetLinkField(this.m_linkNewRessource, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_linkNewRessource, "");
            this.m_linkNewRessource.Location = new System.Drawing.Point(525, 30);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_linkNewRessource, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_linkNewRessource.Name = "m_linkNewRessource";
            this.m_linkNewRessource.Size = new System.Drawing.Size(187, 13);
            this.m_extStyle.SetStyleBackColor(this.m_linkNewRessource, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_linkNewRessource, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_linkNewRessource.TabIndex = 5;
            this.m_linkNewRessource.TabStop = true;
            this.m_linkNewRessource.Text = "Create new Resource|277";
            this.m_linkNewRessource.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_linkNewRessource_LinkClicked);
            // 
            // m_lblSelect
            // 
            this.m_extLinkField.SetLinkField(this.m_lblSelect, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_lblSelect, "");
            this.m_lblSelect.Location = new System.Drawing.Point(12, 2);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblSelect, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblSelect.Name = "m_lblSelect";
            this.m_lblSelect.Size = new System.Drawing.Size(212, 17);
            this.m_extStyle.SetStyleBackColor(this.m_lblSelect, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblSelect, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblSelect.TabIndex = 4;
            this.m_lblSelect.Text = "Select Resource to add|273";
            // 
            // m_WndLinkSuppr
            // 
            this.m_WndLinkSuppr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_WndLinkSuppr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_WndLinkSuppr.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkEditionAttribut.SetLinkField(this.m_WndLinkSuppr, "");
            this.m_extLinkField.SetLinkField(this.m_WndLinkSuppr, "");
            this.m_WndLinkSuppr.Location = new System.Drawing.Point(15, 212);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_WndLinkSuppr, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_WndLinkSuppr.Name = "m_WndLinkSuppr";
            this.m_WndLinkSuppr.Size = new System.Drawing.Size(104, 21);
            this.m_extStyle.SetStyleBackColor(this.m_WndLinkSuppr, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_WndLinkSuppr, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_WndLinkSuppr.TabIndex = 3;
            this.m_WndLinkSuppr.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_WndLinkSuppr.LinkClicked += new System.EventHandler(this.m_WndLinkSuppr_LinkClicked);
            // 
            // m_wndLinkAjout
            // 
            this.m_wndLinkAjout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_wndLinkAjout.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkEditionAttribut.SetLinkField(this.m_wndLinkAjout, "");
            this.m_extLinkField.SetLinkField(this.m_wndLinkAjout, "");
            this.m_wndLinkAjout.Location = new System.Drawing.Point(65, 47);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndLinkAjout, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_wndLinkAjout.Name = "m_wndLinkAjout";
            this.m_wndLinkAjout.Size = new System.Drawing.Size(104, 21);
            this.m_extStyle.SetStyleBackColor(this.m_wndLinkAjout, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndLinkAjout, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndLinkAjout.TabIndex = 2;
            this.m_wndLinkAjout.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_wndLinkAjout.LinkClicked += new System.EventHandler(this.m_wndLinkAjout_LinkClicked);
            // 
            // m_listeRelationsRessources
            // 
            this.m_listeRelationsRessources.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_listeRelationsRessources.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colLibelle});
            this.m_listeRelationsRessources.EnableCustomisation = true;
            this.m_listeRelationsRessources.FullRowSelect = true;
            this.m_extLinkEditionAttribut.SetLinkField(this.m_listeRelationsRessources, "");
            this.m_extLinkField.SetLinkField(this.m_listeRelationsRessources, "");
            this.m_listeRelationsRessources.Location = new System.Drawing.Point(15, 72);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_listeRelationsRessources, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_listeRelationsRessources.MultiSelect = false;
            this.m_listeRelationsRessources.Name = "m_listeRelationsRessources";
            this.m_listeRelationsRessources.Size = new System.Drawing.Size(480, 137);
            this.m_extStyle.SetStyleBackColor(this.m_listeRelationsRessources, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_listeRelationsRessources, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_listeRelationsRessources.TabIndex = 1;
            this.m_listeRelationsRessources.UseCompatibleStateImageBehavior = false;
            this.m_listeRelationsRessources.View = System.Windows.Forms.View.Details;
            // 
            // colLibelle
            // 
            this.colLibelle.Field = "Ressource.Libelle";
            this.colLibelle.PrecisionWidth = 0;
            this.colLibelle.ProportionnalSize = false;
            this.colLibelle.Text = "Label|50";
            this.colLibelle.Visible = true;
            this.colLibelle.Width = 120;
            // 
            // m_txtFiltreListeRessource
            // 
            this.m_txtFiltreListeRessource.ElementSelectionne = null;
            this.m_txtFiltreListeRessource.FonctionTextNull = null;
            this.m_txtFiltreListeRessource.HasLink = true;
            this.m_extLinkEditionAttribut.SetLinkField(this.m_txtFiltreListeRessource, "");
            this.m_extLinkField.SetLinkField(this.m_txtFiltreListeRessource, "");
            this.m_txtFiltreListeRessource.Location = new System.Drawing.Point(65, 22);
            this.m_txtFiltreListeRessource.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtFiltreListeRessource, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtFiltreListeRessource.Name = "m_txtFiltreListeRessource";
            this.m_txtFiltreListeRessource.SelectedObject = null;
            this.m_txtFiltreListeRessource.Size = new System.Drawing.Size(430, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtFiltreListeRessource, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFiltreListeRessource, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFiltreListeRessource.TabIndex = 0;
            this.m_txtFiltreListeRessource.TextNull = "";
            // 
            // m_gestionnaireEditionAttribut
            // 
            this.m_gestionnaireEditionAttribut.ListeAssociee = this.m_listeAttributs;
            this.m_gestionnaireEditionAttribut.ObjetEdite = null;
            this.m_gestionnaireEditionAttribut.InitChamp += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireEditionAttribut_InitChamp);
            this.m_gestionnaireEditionAttribut.MAJ_Champs += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireEditionAttribut_MAJ_Champs);
            // 
            // m_reducteurPanTop
            // 
            this.m_reducteurPanTop.ControleAgrandit = this.m_TabControl;
            this.m_reducteurPanTop.ControleAVoir = this.m_txtLibelle;
            this.m_reducteurPanTop.ControleReduit = this.m_panTop;
            this.m_extLinkEditionAttribut.SetLinkField(this.m_reducteurPanTop, "");
            this.m_extLinkField.SetLinkField(this.m_reducteurPanTop, "");
            this.m_reducteurPanTop.Location = new System.Drawing.Point(343, 48);
            this.m_reducteurPanTop.MargeControle = 16;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_reducteurPanTop, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_reducteurPanTop.ModePositionnement = sc2i.win32.common.CReducteurControle.EModePositionnement.Haut;
            this.m_reducteurPanTop.Name = "m_reducteurPanTop";
            this.m_reducteurPanTop.Size = new System.Drawing.Size(9, 8);
            this.m_extStyle.SetStyleBackColor(this.m_reducteurPanTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_reducteurPanTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_reducteurPanTop.TabIndex = 4005;
            this.m_reducteurPanTop.TailleReduite = 32;
            // 
            // CFormEditionContrainte
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.m_reducteurPanTop);
            this.Controls.Add(this.m_TabControl);
            this.Controls.Add(this.m_panTop);
            this.m_extLinkEditionAttribut.SetLinkField(this, "");
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CFormEditionContrainte";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_TabControl;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionContrainte_OnInitPage);
            this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionContrainte_OnMajChampsPage);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.m_panTop, 0);
            this.Controls.SetChildIndex(this.m_TabControl, 0);
            this.Controls.SetChildIndex(this.m_reducteurPanTop, 0);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            this.m_panTop.ResumeLayout(false);
            this.m_panTop.PerformLayout();
            this.m_TabControl.ResumeLayout(false);
            this.m_TabControl.PerformLayout();
            this.m_pageChampsCustom.ResumeLayout(false);
            this.m_pageAttributs.ResumeLayout(false);
            this.m_pageAttributs.PerformLayout();
            this.m_panelEditionAttribut.ResumeLayout(false);
            this.m_panelEditionAttribut.PerformLayout();
            this.m_pageRessources.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		void m_chkCheckList_CheckStateChanged(object sender, EventArgs e)
		{
			if (m_chkCheckList.CheckState == CheckState.Indeterminate)
				m_chkCheckList.Text = I.T("On check list : depends on constraint type|30046");
			else
				m_chkCheckList.Text = I.T("On check list|30047");
		}
		#endregion


		public CFormEditionContrainte()
			: base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionContrainte(CContrainte cont)
			: base(cont)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionContrainte(CContrainte cont, CListeObjetsDonnees liste)
			: base(cont, liste)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		
		//-------------------------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
        private CContrainte Contrainte
		{
			get
			{
				return (CContrainte)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
            if (!result) return result;

			AffecterTitre(I.T( "Constraint|256") + ": " + Contrainte.Libelle);

            // Récupère la liste des types de contrainte existants
            CListeObjetsDonnees liste_types = new CListeObjetsDonnees(Contrainte.ContexteDonnee, typeof(CTypeContrainte));

            // Initialise la liste des type de containte dns la combo
            m_cmbxTypeContrainte.Init(
                typeof(CTypeContrainte),
                "TypesContraintesFils",
                CTypeContrainte.c_champIdParent,
                "Libelle",
                typeof(CFormEditionTypeContrainte),
                null,
                null);
            m_cmbxTypeContrainte.ElementSelectionne = Contrainte.TypeContrainte;

            // Interdit le changement de type de contrainte s'il y a des attributs liés au type
            bool bEditionComboType = true;
            foreach (CAttributContrainte attr in Contrainte.AttributsListe)
                if (attr.AttributTypeContrainte != null)
                {
                    bEditionComboType = false;
                    break;
                }

            // Interdit le changement de type de contraite s'il y a des ressourcesmiés
            if (Contrainte.RelationRessourceListe.Count != 0 || !bEditionComboType)
                m_cmbxTypeContrainte.LockEdition = true;
            else 
				m_cmbxTypeContrainte.LockEdition = !m_gestionnaireModeEdition.ModeEdition;

			if (Contrainte.IsInCheckListPropre == null)
			{
				m_chkCheckList.Checked = Contrainte.TypeContrainte == null ? false : Contrainte.TypeContrainte.IsInCheckList;
				m_chkCheckList.CheckState = CheckState.Indeterminate;
			}
			else
				m_chkCheckList.Checked = (bool)Contrainte.IsInCheckListPropre;
            

            return result;
		}
        //--------------------------------------------------------------------------------------
        private void InitOngletAttributs()
        {
            if (Contrainte.TypeContrainte != null)
            {
                if (!Contrainte.TypeContrainte.OptionChoixAttributDansListe &&
                    !Contrainte.TypeContrainte.OptionChoixAttributLibre)
                {
                    int index = m_TabControl.TabPages.IndexOf(m_pageAttributs);
                    if (index >= 0)
                        m_TabControl.TabPages.RemoveAt(index);
                }
                else
                    if(!m_TabControl.Contains(m_pageAttributs))
                        m_TabControl.TabPages.Insert(0, m_pageAttributs);
            }
        }


        //--------------------------------------------------------------------------------------
        private void InitSelectAttributTypeContrainte()
        {
            CListeObjetsDonnees liste = new CListeObjetsDonnees(Contrainte.ContexteDonnee, typeof(CAttributTypeContrainte));

            if (Contrainte.TypeContrainte == null)
            {
                if (m_cmbxTypeContrainte.ElementSelectionne != null)
                    MAJ_Champs();
                else
                    return;
            }
        
            CAttributTypeContrainte[] tousLesAttributs = Contrainte.TypeContrainte.GetTousLesAttributsTypeContrainte();
            string strFiltreIds = "";
            foreach (CAttributTypeContrainte att in tousLesAttributs)
            {
                strFiltreIds += att.Id;
                strFiltreIds += ",";
            }
			if (strFiltreIds.Length != 0)
			{
				strFiltreIds = strFiltreIds.Substring(0, (strFiltreIds.Length) - 1);
				liste.Filtre = new CFiltreData(CAttributTypeContrainte.c_champId + " in (" + strFiltreIds + ")");
			}
            m_cmbxSelectAttributTypeCont.Init(liste, "Libelle", true);
        
            // Gestion des options du type de contrainte
            if (!Contrainte.TypeContrainte.OptionChoixAttributDansListe)
            {
                m_cmbxSelectAttributTypeCont.LockEdition = true;
                m_lnkAjouterAttributTypeCont.Enabled = false;
            }
            else
            {
                m_cmbxSelectAttributTypeCont.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
                m_lnkAjouterAttributTypeCont.Enabled = m_gestionnaireModeEdition.ModeEdition;
            }
            if (!Contrainte.TypeContrainte.OptionChoixAttributLibre)
            {
                m_txtAttributLibre.LockEdition = true;
                m_lnkAjouterAttribut.Enabled = false;
            }
            else
            {
                m_txtAttributLibre.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
                m_lnkAjouterAttribut.Enabled = m_gestionnaireModeEdition.ModeEdition;
            }

        }

        //--------------------------------------------------------------------------------------
		private void InitListeAttributs()
		{
			m_listeAttributs.Items.Clear();

			foreach (CAttributContrainte att in Contrainte.AttributsListe)
			{
				ListViewItem item = new ListViewItem();
				m_listeAttributs.Items.Add(item);
				m_listeAttributs.UpdateItemWithObject(item, att);
			}
			foreach (ListViewItem itemSel in m_listeAttributs.Items)
				itemSel.Selected = false;
		}


        //------------------------------------------------------------------------------------
        private void InitListeRessources()
        {
            // Vide la liste
            m_listeRelationsRessources.Items.Clear();

            // Init la liste des relations avec les clés
            foreach (CRelationContrainte_Ressource rel in Contrainte.RelationRessourceListe)
            {
                ListViewItem item = new ListViewItem();
                m_listeRelationsRessources.Items.Add(item);
                m_listeRelationsRessources.UpdateItemWithObject(item, rel);
            }
            foreach (ListViewItem itemSel in m_listeRelationsRessources.Items)
                itemSel.Selected = false;
        }
        
        //------------------------------------------------------------------------------------
        private void InitSelectRessource()
        {

            CFiltreData filtre = null;
            // Filtre la liste de clés possibles (dont le type correspond au type de contrainte)

            string strIds = "";

            if (Contrainte.TypeContrainte != null)
            {
                foreach (CTypeRessource typeRes in Contrainte.TypeContrainte.GetTousLesTypesRessources())
                {
                    strIds += typeRes.Id + ",";
                }
                if (strIds.Length > 0)
                {
                    strIds = strIds.Substring(0, strIds.Length - 1);
                    filtre = new CFiltreData(CTypeRessource.c_champId + " in (" + strIds + ")");
                }
            }
            
            m_txtFiltreListeRessource.InitAvecFiltreDeBase<CRessourceMaterielle>("Libelle", filtre, true);
            
           
        }

 		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();
            if (!result) return result;

            Contrainte.TypeContrainte = (CTypeContrainte)m_cmbxTypeContrainte.ElementSelectionne;

			if (Contrainte.Libelle.Trim() == "" &&
				Contrainte.TypeContrainte != null)
				Contrainte.Libelle = Contrainte.TypeContrainte.Libelle;

			if (m_chkCheckList.CheckState == CheckState.Indeterminate)
				Contrainte.IsInCheckListPropre = null;
			else
				Contrainte.IsInCheckListPropre = m_chkCheckList.Checked;

            return result;
        }

        //------------------------------------------------------------------------------------------------
        private void m_wndLinkAjout_LinkClicked(object sender, EventArgs e)
        {
            if (m_txtFiltreListeRessource.ElementSelectionne == null)
            {
                CFormAlerte.Afficher(I.T( "Select Resource to add|274"));
                return;
            }
            CRessourceMaterielle res = (CRessourceMaterielle) m_txtFiltreListeRessource.ElementSelectionne;

            //Vérifie la liste des relations existantes
            CListeObjetsDonnees listeExistant = Contrainte.RelationRessourceListe;
            listeExistant.Filtre = new CFiltreData(CRessourceMaterielle.c_champId + " = @1", res.Id);
            if(listeExistant.Count != 0)
            {
				CFormAlerte.Afficher(I.T("This Resource is already in the list|275"), EFormAlerteType.Erreur);
                return;
            }

            m_txtFiltreListeRessource.ElementSelectionne = null;

            CRelationContrainte_Ressource rel = new CRelationContrainte_Ressource(Contrainte.ContexteDonnee);
            rel.CreateNewInCurrentContexte();
            rel.Contrainte = Contrainte;
            rel.Ressource = res;

            MAJ_Champs();
            CResultAErreur result = rel.VerifieDonnees(true);
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
                rel.Delete();
                return;
            }

            // MAJ affichage liste relations
            ListViewItem item = new ListViewItem();
            m_listeRelationsRessources.Items.Add(item);
            m_listeRelationsRessources.UpdateItemWithObject(item, rel);
            foreach (ListViewItem itemSel in m_listeRelationsRessources.SelectedItems)
				itemSel.Selected = false;
			item.Selected = true;
			
            InitSelectRessource();

        }

        //------------------------------------------------------------------------------------------------
        private void m_WndLinkSuppr_LinkClicked(object sender, EventArgs e)
        {
            if(m_listeRelationsRessources.SelectedItems.Count == 0)
            {
                CFormAlerte.Afficher(I.T( "Select Resource from the list to remove|276"));
                return;
            }

            CRelationContrainte_Ressource rel = (CRelationContrainte_Ressource)m_listeRelationsRessources.SelectedItems[0].Tag;
            CResultAErreur result = rel.Delete();
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
                return;
            }

            if (m_listeRelationsRessources.SelectedItems.Count == 1 && m_listeRelationsRessources.SelectedItems[0] != null)
            {
                m_listeRelationsRessources.SelectedItems[0].Remove();
            }

        }
        
        //------------------------------------------------------------------------------------------------
        private void m_linkNewRessource_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            // Créé une nouvelle instance de l'objet CRessource
            CRessourceMaterielle res = new CRessourceMaterielle(Contrainte.ContexteDonnee);
            // Créé la clé dans un nouveau contexte de données
            res.CreateNew();

			//Valeurs par défaut
            res.Libelle = m_txtLibelle.Text;
			if (m_cmbxTypeContrainte.ElementSelectionne is CTypeContrainte)
			{
				CTypeRessource[] types = ((CTypeContrainte)m_cmbxTypeContrainte.ElementSelectionne).GetTousLesTypesRessources();
				if (types.Length > 0)
					res.TypeRessource = types[0];
			}

            // Créé une nouvelle relation dans le contexte de la clé
            CRelationContrainte_Ressource rel = new CRelationContrainte_Ressource(res.ContexteDonnee);
            rel.CreateNewInCurrentContexte();
            // Initialise la relation
            rel.Contrainte = Contrainte;
            rel.Ressource = res;

            // Ouvre le formulaire d'édition de la clé
            CFormEditionRessource form = new CFormEditionRessource(res);
            form.AfterValideModification += new ObjetDonneeEventHandler(form_AfterValideModification);
            // Filtrer la liste des Types
            string strIds = "";
            foreach (CTypeRessource typeRes in Contrainte.TypeContrainte.GetTousLesTypesRessources())
                strIds += typeRes.Id + ",";
            if (strIds.Length > 0)
            {
                strIds = strIds.Substring(0, strIds.Length - 1);
                form.FiltreListeType = new CFiltreData(CTypeRessource.c_champId + " in (" + strIds + ")");
            }
            CTimosApp.Navigateur.AffichePage(form);

        }

        //------------------------------------------------------------------------------------------------
        void form_AfterValideModification(object sender, CObjetDonneeEventArgs args)
        {
            CTimosApp.Navigateur.AffichePagePrecedente();
        }

        //------------------------------------------------------------------------------------------------
        private void m_lnkEmplacement_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            IPossesseurContrainte emplacement = Contrainte.Emplacement;
			if (emplacement != null)
			{
				//Type tp = CFormFinder.GetTypeFormToEdit(emplacement.GetType());
                CReferenceTypeForm refTypeForm = CFormFinder.GetRefFormToEdit(emplacement.GetType());
                try
				{
					//CTimosApp.Navigateur.AffichePage((IFormNavigable)Activator.CreateInstance(tp, new object[] { emplacement }));
                    CTimosApp.Navigateur.AffichePage(refTypeForm.GetForm((CObjetDonneeAIdNumeriqueAuto)emplacement) as CFormEditionStandard);
                }
				catch
				{ }
			}
		}

        //------------------------------------------------------------------------------------------------
        private void m_lnkAjouter_LinkClicked(object sender, EventArgs e)
        {
            if (m_txtAttributLibre.Text == "")
            {
                CFormAlerte.Afficher(I.T( "Enter attribute label to add|348"), EFormAlerteType.Exclamation);
                return;
            }
            string strLbl = m_txtAttributLibre.Text;
            CListeObjetsDonnees listeExistant = Contrainte.AttributsListe;
            listeExistant.Filtre = new CFiltreData(CAttributContrainte.c_champLibelle + " = @1", strLbl);
            if(listeExistant.Count != 0)
            {
				CFormAlerte.Afficher(I.T("This attribute is already in the list|349"), EFormAlerteType.Erreur);
                return;
            }
            m_txtAttributLibre.Text = "";

            CAttributContrainte newAttribut = new CAttributContrainte(Contrainte.ContexteDonnee);
            newAttribut.CreateNewInCurrentContexte();
            newAttribut.Contrainte = Contrainte;
            newAttribut.Libelle = strLbl;
            newAttribut.AttributTypeContrainte = null;

            // Mise à jour de la liste
            ListViewItem item = new ListViewItem();
            m_listeAttributs.Items.Add(item);
            m_listeAttributs.UpdateItemWithObject(item, newAttribut);
            

        }

        //------------------------------------------------------------------------------------------------
        private void m_lnkSupprimer_LinkClicked(object sender, EventArgs e)
        {
            if (m_listeAttributs.SelectedItems.Count != 1)
                return;

            CAttributContrainte att = (CAttributContrainte)m_listeAttributs.SelectedItems[0].Tag;
            CResultAErreur result = att.Delete();
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
                return;
            }

            if (m_listeAttributs.SelectedItems.Count == 1 && m_listeAttributs.SelectedItems[0] != null)
            {
                m_listeAttributs.SelectedItems[0].Remove();
            }

        }

        //------------------------------------------------------------------------------------------------
        private void m_lnkAjouterAttributTypeCont_LinkClicked(object sender, EventArgs e)
        {
            if (m_cmbxSelectAttributTypeCont.ElementSelectionne == null)
            {
                CFormAlerte.Afficher(I.T( "Select attribute to add|359"), EFormAlerteType.Erreur);
                return;
            }
            CAttributTypeContrainte selAttrib = (CAttributTypeContrainte) m_cmbxSelectAttributTypeCont.ElementSelectionne;
            CListeObjetsDonnees listeExistant = Contrainte.AttributsListe;
            listeExistant.Filtre = new CFiltreData(CAttributTypeContrainte.c_champId + " = @1", selAttrib.Id);
            if (listeExistant.Count != 0)
            {
                CFormAlerte.Afficher(I.T( "This attribute is already in the list|349"), EFormAlerteType.Erreur);
                return;
            }

            CAttributContrainte newAttribut = new CAttributContrainte(Contrainte.ContexteDonnee);
            newAttribut.CreateNewInCurrentContexte();
            newAttribut.Contrainte = Contrainte;
            newAttribut.AttributTypeContrainte = selAttrib;
            newAttribut.Libelle = "";

            // Mise à jour de la liste
            ListViewItem item = new ListViewItem();
            m_listeAttributs.Items.Add(item);
            m_listeAttributs.UpdateItemWithObject(item, newAttribut);
            

        }

        //------------------------------------------------------------------------------------------------
        private void m_cmbxTypeContrainte_ElementSelectionneChanged(object sender, EventArgs e)
        {
            if (m_cmbxTypeContrainte.ElementSelectionne != null)
                Contrainte.TypeContrainte = (CTypeContrainte)m_cmbxTypeContrainte.ElementSelectionne;

            InitOngletAttributs();
            InitSelectAttributTypeContrainte();
            InitSelectRessource();
            m_panelChampsCustom.ElementEdite = Contrainte;
        }

        //------------------------------------------------------------------------------------------------
        private void m_gestionnaireEditionAttribut_InitChamp(object sender, CObjetDonneeResultEventArgs args)
        {

            if (args.Objet == null)
            {
                m_panelEditionAttribut.Visible = false;
                return;
            }
            CAttributContrainte attribut = (CAttributContrainte)args.Objet;
            if (attribut.AttributTypeContrainte == null)
            {
                m_panelEditionAttribut.Visible = true;
                m_extLinkEditionAttribut.FillDialogFromObjet(args.Objet);
            }

        }

        private void m_gestionnaireEditionAttribut_MAJ_Champs(object sender, CObjetDonneeResultEventArgs args)
        {
            if (args.Objet != null)
            {
                CResultAErreur result = m_extLinkEditionAttribut.FillObjetFromDialog(args.Objet);
                if (!result)
                {
                    args.Result = result;
                    return;
                }
            }
 
        }

        private void m_lnkToutesRessourcesLevant_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           /* string strToutesRessources = "TOUTES LES RESSOURCES LEVANT LA CONTRAINTE:\n";

            foreach (CRessourceMaterielle res in Contrainte.GetToutesLesRessourcesLevant(null))
            {
                strToutesRessources += res.Libelle;
                strToutesRessources += "\n";
            }
            
            MessageBox.Show(strToutesRessources);*/
			CFormChercheRessource.FindRessource(null, Contrainte, null);

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (m_txtFiltreListeRessource.ElementSelectionne != null)
            {
                CRessourceMaterielle res = (CRessourceMaterielle)m_txtFiltreListeRessource.ElementSelectionne;
                if(Contrainte.IsRessourceLevant(res))
                    CFormAlerte.Afficher("OUI");
                else
					CFormAlerte.Afficher("NON");
            }
        }

		private CResultAErreur CFormEditionContrainte_OnInitPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			using (CWaitCursor waiter = new CWaitCursor())
			{
				if (page == m_pageChampsCustom)
				{
					// Initialise les champs custom
					m_panelChampsCustom.ElementEdite = Contrainte;
					if (Contrainte.GetFormulaires().Length == 0)
					{
						if (m_TabControl.TabPages.Contains(m_pageChampsCustom))
							m_TabControl.TabPages.Remove(m_pageChampsCustom);
					}
					else
					{
						if (!m_TabControl.TabPages.Contains(m_pageChampsCustom))
							m_TabControl.TabPages.Insert(0, m_pageChampsCustom);
					}
          
				}
				else if (page == m_pageAttributs)
				{
					// Init page Attributs
					m_gestionnaireEditionAttribut.ObjetEdite = Contrainte.AttributsListe;
					m_panelEditionAttribut.Visible = false;
					InitOngletAttributs();
					InitListeAttributs();
					InitSelectAttributTypeContrainte();


				}
				else if (page == m_pageRessources)
				{
					// Init page ressources
					InitListeRessources();
					InitSelectRessource();

				}
			}
			return result;
		}

		private CResultAErreur CFormEditionContrainte_OnMajChampsPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			if (page == m_pageChampsCustom)
			{
				result = m_panelChampsCustom.MAJ_Champs();
			}
			else if (page == m_pageAttributs)
			{
				result = m_gestionnaireEditionAttribut.ValideModifs();
			}
			//else if (page == m_pageRessources)
			//{
			//}

			return result;

		}


	}
}

