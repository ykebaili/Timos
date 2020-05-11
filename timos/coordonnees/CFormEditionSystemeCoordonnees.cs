using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using timos.data;

using sc2i.common;
using sc2i.process;
using sc2i.data.dynamic;
using sc2i.data;
using sc2i.win32.data;
using sc2i.win32.common;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;

namespace timos
{
    [sc2i.win32.data.navigation.ObjectEditeur(typeof(CSystemeCoordonnees))]
    public class CFormEditionSystemeCoordonnees : CFormEditionStdTimos, IFormNavigable
	{
		#region Designer generated code

		private System.Windows.Forms.Label label1;
        private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
		private Label m_lblLabel;
		private Panel m_panelNumerotation;
		private Label m_lblPosition;
		private ListViewAutoFilled m_wndListeFormatNumerotation;
		private ListViewAutoFilledColumn listViewAutoFilledColumn4;
		private CWndLinkStd m_lnkAjouterNumerotation;
		private C2iTextBox m_txtPrefix;
		private Label m_lblPrefix;
		private Label m_lblNumerotation;
		private Label m_lblLabel2;
		private C2iTextBox m_txtLibelle2;
		private CGestionnaireEditionSousObjetDonnee m_gestionnaireEditionRelationSysCoorFormatNum;
		private CExtLinkField m_lnkEditionRelationSysCoorFormatNum;
		private CComboBoxLinkListeObjetsDonnees m_cmbFormatNumerotation;
		private CWndLinkStd m_lnkSupprimerFournisseur;
		private Label m_lblPositionCurrent;
		private CComboBoxLinkListeObjetsDonnees m_cmbUnite;
		private Label m_lblUnite;
		private CCtrlUpDownListView m_ctrlMD;
		private ListViewAutoFilledColumn listViewAutoFilledColumn1;
        private Panel panel1;
        private Panel panel2;
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
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_lblLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_cmbFormatNumerotation = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.m_lblNumerotation = new System.Windows.Forms.Label();
            this.m_lnkAjouterNumerotation = new sc2i.win32.common.CWndLinkStd();
            this.m_wndListeFormatNumerotation = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn4 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_panelNumerotation = new System.Windows.Forms.Panel();
            this.m_cmbUnite = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.m_txtPrefix = new sc2i.win32.common.C2iTextBox();
            this.m_lblPrefix = new System.Windows.Forms.Label();
            this.m_lblPositionCurrent = new System.Windows.Forms.Label();
            this.m_lblPosition = new System.Windows.Forms.Label();
            this.m_lblUnite = new System.Windows.Forms.Label();
            this.m_lblLabel2 = new System.Windows.Forms.Label();
            this.m_txtLibelle2 = new sc2i.win32.common.C2iTextBox();
            this.m_ctrlMD = new sc2i.win32.common.CCtrlUpDownListView();
            this.m_lnkSupprimerFournisseur = new sc2i.win32.common.CWndLinkStd();
            this.m_gestionnaireEditionRelationSysCoorFormatNum = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.m_lnkEditionRelationSysCoorFormatNum = new sc2i.win32.common.CExtLinkField();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.m_panelNumerotation.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnAnnulerModifications
            // 
            this.m_extLinkField.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_lnkEditionRelationSysCoorFormatNum.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAnnulerModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnValiderModifications
            // 
            this.m_extLinkField.SetLinkField(this.m_btnValiderModifications, "");
            this.m_lnkEditionRelationSysCoorFormatNum.SetLinkField(this.m_btnValiderModifications, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnValiderModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnSupprimerObjet
            // 
            this.m_extLinkField.SetLinkField(this.m_btnSupprimerObjet, "");
            this.m_lnkEditionRelationSysCoorFormatNum.SetLinkField(this.m_btnSupprimerObjet, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnSupprimerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnEditerObjet
            // 
            this.m_extLinkField.SetLinkField(this.m_btnEditerObjet, "");
            this.m_lnkEditionRelationSysCoorFormatNum.SetLinkField(this.m_btnEditerObjet, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnEditerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelNavigation
            // 
            this.m_extLinkField.SetLinkField(this.m_panelNavigation, "");
            this.m_lnkEditionRelationSysCoorFormatNum.SetLinkField(this.m_panelNavigation, "");
            this.m_panelNavigation.Location = new System.Drawing.Point(694, 0);
            this.m_extStyle.SetStyleBackColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelCle
            // 
            this.m_extLinkField.SetLinkField(this.m_panelCle, "");
            this.m_lnkEditionRelationSysCoorFormatNum.SetLinkField(this.m_panelCle, "");
            this.m_panelCle.Location = new System.Drawing.Point(610, 0);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_extLinkField.SetLinkField(this.m_panelMenu, "");
            this.m_lnkEditionRelationSysCoorFormatNum.SetLinkField(this.m_panelMenu, "");
            this.m_panelMenu.Size = new System.Drawing.Size(830, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnHistorique
            // 
            this.m_extLinkField.SetLinkField(this.m_btnHistorique, "");
            this.m_lnkEditionRelationSysCoorFormatNum.SetLinkField(this.m_btnHistorique, "");
            this.m_extStyle.SetStyleBackColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.m_lnkEditionRelationSysCoorFormatNum.SetLinkField(this.label1, "");
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
            this.m_lnkEditionRelationSysCoorFormatNum.SetLinkField(this.m_txtLibelle, "");
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_txtLibelle.Location = new System.Drawing.Point(99, 8);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(212, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Label]|30324";
            // 
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.panel1);
            this.c2iPanelOmbre4.Controls.Add(this.panel2);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.m_lnkEditionRelationSysCoorFormatNum.SetLinkField(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(8, 52);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(667, 340);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_lblLabel);
            this.panel1.Controls.Add(this.m_txtLibelle);
            this.m_extLinkField.SetLinkField(this.panel1, "");
            this.m_lnkEditionRelationSysCoorFormatNum.SetLinkField(this.panel1, "");
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel1, "");
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(517, 43);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 4011;
            // 
            // m_lblLabel
            // 
            this.m_extLinkField.SetLinkField(this.m_lblLabel, "");
            this.m_lnkEditionRelationSysCoorFormatNum.SetLinkField(this.m_lblLabel, "");
            this.m_lblLabel.Location = new System.Drawing.Point(15, 11);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblLabel, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblLabel, "");
            this.m_lblLabel.Name = "m_lblLabel";
            this.m_lblLabel.Size = new System.Drawing.Size(78, 14);
            this.m_extStyle.SetStyleBackColor(this.m_lblLabel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblLabel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblLabel.TabIndex = 4005;
            this.m_lblLabel.Text = "Label|50";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.m_cmbFormatNumerotation);
            this.panel2.Controls.Add(this.m_lblNumerotation);
            this.panel2.Controls.Add(this.m_lnkAjouterNumerotation);
            this.panel2.Controls.Add(this.m_wndListeFormatNumerotation);
            this.panel2.Controls.Add(this.m_panelNumerotation);
            this.panel2.Controls.Add(this.m_ctrlMD);
            this.panel2.Controls.Add(this.m_lnkSupprimerFournisseur);
            this.m_extLinkField.SetLinkField(this.panel2, "");
            this.m_lnkEditionRelationSysCoorFormatNum.SetLinkField(this.panel2, "");
            this.panel2.Location = new System.Drawing.Point(4, 52);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel2, "");
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(643, 268);
            this.m_extStyle.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel2.TabIndex = 4012;
            // 
            // m_cmbFormatNumerotation
            // 
            this.m_cmbFormatNumerotation.ComportementLinkStd = true;
            this.m_cmbFormatNumerotation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbFormatNumerotation.ElementSelectionne = null;
            this.m_cmbFormatNumerotation.FormattingEnabled = true;
            this.m_cmbFormatNumerotation.IsLink = false;
            this.m_lnkEditionRelationSysCoorFormatNum.SetLinkField(this.m_cmbFormatNumerotation, "");
            this.m_extLinkField.SetLinkField(this.m_cmbFormatNumerotation, "");
            this.m_cmbFormatNumerotation.LinkProperty = "";
            this.m_cmbFormatNumerotation.ListDonnees = null;
            this.m_cmbFormatNumerotation.Location = new System.Drawing.Point(98, 8);
            this.m_cmbFormatNumerotation.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbFormatNumerotation, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbFormatNumerotation, "");
            this.m_cmbFormatNumerotation.Name = "m_cmbFormatNumerotation";
            this.m_cmbFormatNumerotation.NullAutorise = false;
            this.m_cmbFormatNumerotation.ProprieteAffichee = null;
            this.m_cmbFormatNumerotation.ProprieteParentListeObjets = null;
            this.m_cmbFormatNumerotation.SelectionneurParent = null;
            this.m_cmbFormatNumerotation.Size = new System.Drawing.Size(212, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbFormatNumerotation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbFormatNumerotation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbFormatNumerotation.TabIndex = 4008;
            this.m_cmbFormatNumerotation.TextNull = I.T("(empty)|30195");
            this.m_cmbFormatNumerotation.Tri = true;
            this.m_cmbFormatNumerotation.TypeFormEdition = null;
            // 
            // m_lblNumerotation
            // 
            this.m_extLinkField.SetLinkField(this.m_lblNumerotation, "");
            this.m_lnkEditionRelationSysCoorFormatNum.SetLinkField(this.m_lblNumerotation, "");
            this.m_lblNumerotation.Location = new System.Drawing.Point(14, 11);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblNumerotation, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblNumerotation, "");
            this.m_lblNumerotation.Name = "m_lblNumerotation";
            this.m_lblNumerotation.Size = new System.Drawing.Size(78, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblNumerotation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblNumerotation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblNumerotation.TabIndex = 4005;
            this.m_lblNumerotation.Text = "Numbering|453";
            // 
            // m_lnkAjouterNumerotation
            // 
            this.m_lnkAjouterNumerotation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAjouterNumerotation.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkEditionRelationSysCoorFormatNum.SetLinkField(this.m_lnkAjouterNumerotation, "");
            this.m_extLinkField.SetLinkField(this.m_lnkAjouterNumerotation, "");
            this.m_lnkAjouterNumerotation.Location = new System.Drawing.Point(98, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAjouterNumerotation, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAjouterNumerotation, "");
            this.m_lnkAjouterNumerotation.Name = "m_lnkAjouterNumerotation";
            this.m_lnkAjouterNumerotation.Size = new System.Drawing.Size(104, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAjouterNumerotation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAjouterNumerotation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAjouterNumerotation.TabIndex = 4007;
            this.m_lnkAjouterNumerotation.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAjouterNumerotation.LinkClicked += new System.EventHandler(this.m_lnkAjouterNumerotation_LinkClicked);
            // 
            // m_wndListeFormatNumerotation
            // 
            this.m_wndListeFormatNumerotation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_wndListeFormatNumerotation.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn1,
            this.listViewAutoFilledColumn4});
            this.m_wndListeFormatNumerotation.EnableCustomisation = true;
            this.m_wndListeFormatNumerotation.FullRowSelect = true;
            this.m_wndListeFormatNumerotation.HideSelection = false;
            this.m_lnkEditionRelationSysCoorFormatNum.SetLinkField(this.m_wndListeFormatNumerotation, "");
            this.m_extLinkField.SetLinkField(this.m_wndListeFormatNumerotation, "");
            this.m_wndListeFormatNumerotation.Location = new System.Drawing.Point(12, 54);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeFormatNumerotation, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndListeFormatNumerotation, "");
            this.m_wndListeFormatNumerotation.MultiSelect = false;
            this.m_wndListeFormatNumerotation.Name = "m_wndListeFormatNumerotation";
            this.m_wndListeFormatNumerotation.Size = new System.Drawing.Size(298, 180);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeFormatNumerotation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeFormatNumerotation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeFormatNumerotation.TabIndex = 4006;
            this.m_wndListeFormatNumerotation.UseCompatibleStateImageBehavior = false;
            this.m_wndListeFormatNumerotation.View = System.Windows.Forms.View.Details;
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "Libelle";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Label|50";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 156;
            // 
            // listViewAutoFilledColumn4
            // 
            this.listViewAutoFilledColumn4.Field = "FormatNumerotation.Libelle";
            this.listViewAutoFilledColumn4.PrecisionWidth = 0;
            this.listViewAutoFilledColumn4.ProportionnalSize = false;
            this.listViewAutoFilledColumn4.Text = "Type|54";
            this.listViewAutoFilledColumn4.Visible = true;
            this.listViewAutoFilledColumn4.Width = 122;
            // 
            // m_panelNumerotation
            // 
            this.m_panelNumerotation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelNumerotation.Controls.Add(this.m_cmbUnite);
            this.m_panelNumerotation.Controls.Add(this.m_txtPrefix);
            this.m_panelNumerotation.Controls.Add(this.m_lblPrefix);
            this.m_panelNumerotation.Controls.Add(this.m_lblPositionCurrent);
            this.m_panelNumerotation.Controls.Add(this.m_lblPosition);
            this.m_panelNumerotation.Controls.Add(this.m_lblUnite);
            this.m_panelNumerotation.Controls.Add(this.m_lblLabel2);
            this.m_panelNumerotation.Controls.Add(this.m_txtLibelle2);
            this.m_extLinkField.SetLinkField(this.m_panelNumerotation, "");
            this.m_lnkEditionRelationSysCoorFormatNum.SetLinkField(this.m_panelNumerotation, "");
            this.m_panelNumerotation.Location = new System.Drawing.Point(316, 57);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelNumerotation, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelNumerotation, "");
            this.m_panelNumerotation.Name = "m_panelNumerotation";
            this.m_panelNumerotation.Size = new System.Drawing.Size(322, 177);
            this.m_extStyle.SetStyleBackColor(this.m_panelNumerotation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelNumerotation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelNumerotation.TabIndex = 4008;
            this.m_panelNumerotation.Visible = false;
            // 
            // m_cmbUnite
            // 
            this.m_cmbUnite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbUnite.ComportementLinkStd = true;
            this.m_cmbUnite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbUnite.ElementSelectionne = null;
            this.m_cmbUnite.FormattingEnabled = true;
            this.m_cmbUnite.IsLink = false;
            this.m_lnkEditionRelationSysCoorFormatNum.SetLinkField(this.m_cmbUnite, "Unite");
            this.m_extLinkField.SetLinkField(this.m_cmbUnite, "");
            this.m_cmbUnite.LinkProperty = "";
            this.m_cmbUnite.ListDonnees = null;
            this.m_cmbUnite.Location = new System.Drawing.Point(105, 38);
            this.m_cmbUnite.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbUnite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbUnite, "");
            this.m_cmbUnite.Name = "m_cmbUnite";
            this.m_cmbUnite.NullAutorise = false;
            this.m_cmbUnite.ProprieteAffichee = null;
            this.m_cmbUnite.ProprieteParentListeObjets = null;
            this.m_cmbUnite.SelectionneurParent = null;
            this.m_cmbUnite.Size = new System.Drawing.Size(202, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbUnite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbUnite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbUnite.TabIndex = 4009;
            this.m_cmbUnite.TextNull = I.T("(empty)|30195");
            this.m_cmbUnite.Tri = true;
            this.m_cmbUnite.TypeFormEdition = null;
            // 
            // m_txtPrefix
            // 
            this.m_txtPrefix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lnkEditionRelationSysCoorFormatNum.SetLinkField(this.m_txtPrefix, "Prefixes");
            this.m_extLinkField.SetLinkField(this.m_txtPrefix, "");
            this.m_txtPrefix.Location = new System.Drawing.Point(105, 63);
            this.m_txtPrefix.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtPrefix, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtPrefix, "");
            this.m_txtPrefix.Name = "m_txtPrefix";
            this.m_txtPrefix.Size = new System.Drawing.Size(202, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtPrefix, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtPrefix, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtPrefix.TabIndex = 2;
            this.m_txtPrefix.Text = "[Prefixes]";
            // 
            // m_lblPrefix
            // 
            this.m_extLinkField.SetLinkField(this.m_lblPrefix, "");
            this.m_lnkEditionRelationSysCoorFormatNum.SetLinkField(this.m_lblPrefix, "");
            this.m_lblPrefix.Location = new System.Drawing.Point(12, 66);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblPrefix, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblPrefix, "");
            this.m_lblPrefix.Name = "m_lblPrefix";
            this.m_lblPrefix.Size = new System.Drawing.Size(100, 23);
            this.m_extStyle.SetStyleBackColor(this.m_lblPrefix, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblPrefix, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblPrefix.TabIndex = 1;
            this.m_lblPrefix.Text = "Prefixes|454";
            // 
            // m_lblPositionCurrent
            // 
            this.m_lblPositionCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.m_lblPositionCurrent, "");
            this.m_lnkEditionRelationSysCoorFormatNum.SetLinkField(this.m_lblPositionCurrent, "Position");
            this.m_lblPositionCurrent.Location = new System.Drawing.Point(102, 92);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblPositionCurrent, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblPositionCurrent, "");
            this.m_lblPositionCurrent.Name = "m_lblPositionCurrent";
            this.m_lblPositionCurrent.Size = new System.Drawing.Size(86, 23);
            this.m_extStyle.SetStyleBackColor(this.m_lblPositionCurrent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblPositionCurrent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblPositionCurrent.TabIndex = 1;
            this.m_lblPositionCurrent.Text = "[Position]";
            // 
            // m_lblPosition
            // 
            this.m_extLinkField.SetLinkField(this.m_lblPosition, "");
            this.m_lnkEditionRelationSysCoorFormatNum.SetLinkField(this.m_lblPosition, "");
            this.m_lblPosition.Location = new System.Drawing.Point(12, 94);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblPosition, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblPosition, "");
            this.m_lblPosition.Name = "m_lblPosition";
            this.m_lblPosition.Size = new System.Drawing.Size(100, 23);
            this.m_extStyle.SetStyleBackColor(this.m_lblPosition, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblPosition, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblPosition.TabIndex = 1;
            this.m_lblPosition.Text = "Position|455";
            // 
            // m_lblUnite
            // 
            this.m_lblUnite.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lblUnite, "");
            this.m_lnkEditionRelationSysCoorFormatNum.SetLinkField(this.m_lblUnite, "");
            this.m_lblUnite.Location = new System.Drawing.Point(12, 41);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblUnite, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblUnite, "");
            this.m_lblUnite.Name = "m_lblUnite";
            this.m_lblUnite.Size = new System.Drawing.Size(46, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblUnite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblUnite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblUnite.TabIndex = 4005;
            this.m_lblUnite.Text = "Unit|444";
            // 
            // m_lblLabel2
            // 
            this.m_lblLabel2.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lblLabel2, "");
            this.m_lnkEditionRelationSysCoorFormatNum.SetLinkField(this.m_lblLabel2, "");
            this.m_lblLabel2.Location = new System.Drawing.Point(12, 16);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblLabel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblLabel2, "");
            this.m_lblLabel2.Name = "m_lblLabel2";
            this.m_lblLabel2.Size = new System.Drawing.Size(47, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblLabel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblLabel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblLabel2.TabIndex = 4005;
            this.m_lblLabel2.Text = "Label|50";
            // 
            // m_txtLibelle2
            // 
            this.m_txtLibelle2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lnkEditionRelationSysCoorFormatNum.SetLinkField(this.m_txtLibelle2, "Libelle");
            this.m_extLinkField.SetLinkField(this.m_txtLibelle2, "");
            this.m_txtLibelle2.Location = new System.Drawing.Point(105, 13);
            this.m_txtLibelle2.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle2, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle2, "");
            this.m_txtLibelle2.Name = "m_txtLibelle2";
            this.m_txtLibelle2.Size = new System.Drawing.Size(202, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle2.TabIndex = 0;
            this.m_txtLibelle2.Text = "[Label]|30324";
            // 
            // m_ctrlMD
            // 
            this.m_ctrlMD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_extLinkField.SetLinkField(this.m_ctrlMD, "");
            this.m_lnkEditionRelationSysCoorFormatNum.SetLinkField(this.m_ctrlMD, "");
            this.m_ctrlMD.ListeGeree = this.m_wndListeFormatNumerotation;
            this.m_ctrlMD.Location = new System.Drawing.Point(259, 237);
            this.m_ctrlMD.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_ctrlMD, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_ctrlMD, "");
            this.m_ctrlMD.Name = "m_ctrlMD";
            this.m_ctrlMD.ProprieteNumero = "Position";
            this.m_ctrlMD.Size = new System.Drawing.Size(51, 21);
            this.m_extStyle.SetStyleBackColor(this.m_ctrlMD, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_ctrlMD, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ctrlMD.TabIndex = 4010;
            this.m_ctrlMD.ApresRenumeration += new System.EventHandler(this.m_ctrlMD_ApresRenumeration);
            // 
            // m_lnkSupprimerFournisseur
            // 
            this.m_lnkSupprimerFournisseur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkSupprimerFournisseur.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkSupprimerFournisseur.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkEditionRelationSysCoorFormatNum.SetLinkField(this.m_lnkSupprimerFournisseur, "");
            this.m_extLinkField.SetLinkField(this.m_lnkSupprimerFournisseur, "");
            this.m_lnkSupprimerFournisseur.Location = new System.Drawing.Point(12, 237);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkSupprimerFournisseur, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkSupprimerFournisseur, "");
            this.m_lnkSupprimerFournisseur.Name = "m_lnkSupprimerFournisseur";
            this.m_lnkSupprimerFournisseur.Size = new System.Drawing.Size(104, 20);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSupprimerFournisseur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSupprimerFournisseur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSupprimerFournisseur.TabIndex = 4009;
            this.m_lnkSupprimerFournisseur.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkSupprimerFournisseur.LinkClicked += new System.EventHandler(this.m_lnkSupprimerFormatNumerotation_LinkClicked);
            // 
            // m_gestionnaireEditionRelationSysCoorFormatNum
            // 
            this.m_gestionnaireEditionRelationSysCoorFormatNum.ListeAssociee = this.m_wndListeFormatNumerotation;
            this.m_gestionnaireEditionRelationSysCoorFormatNum.ObjetEdite = null;
            this.m_gestionnaireEditionRelationSysCoorFormatNum.InitChamp += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireEditionRelationSysCoorFormatNum_InitChamp);
            this.m_gestionnaireEditionRelationSysCoorFormatNum.MAJ_Champs += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireEditionRelationSysCoorFormatNum_MAJ_Champs);
            // 
            // CFormEditionSystemeCoordonnees
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_lnkEditionRelationSysCoorFormatNum.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionSystemeCoordonnees";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre4, 0);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            this.c2iPanelOmbre4.ResumeLayout(false);
            this.c2iPanelOmbre4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.m_panelNumerotation.ResumeLayout(false);
            this.m_panelNumerotation.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		public CFormEditionSystemeCoordonnees()
            : base()
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }
        //-------------------------------------------------------------------------
        public CFormEditionSystemeCoordonnees(CSystemeCoordonnees FormatNumerotation)
            : base(FormatNumerotation)
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }
        //-------------------------------------------------------------------------
        public CFormEditionSystemeCoordonnees(CSystemeCoordonnees FormatNumerotation, CListeObjetsDonnees liste)
            : base(FormatNumerotation, liste)
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
		}

        //-------------------------------------------------------------------------
        private CSystemeCoordonnees SystemeCoordonnees
        {
            get { return (CSystemeCoordonnees)ObjetEdite; }
		}
		
        //-------------------------------------------------------------------------
        protected override CResultAErreur MyInitChamps()
        {
            CResultAErreur result = base.MyInitChamps();
            AffecterTitre(I.T("Coordinate System|430" + SystemeCoordonnees.Libelle));


			//Chargement des formats de numérotations
			CListeObjetsDonnees lstFormatNum = new CListeObjetsDonnees(SystemeCoordonnees.ContexteDonnee, typeof(CFormatNumerotation));
			m_cmbFormatNumerotation.Init(lstFormatNum, "Libelle",typeof(CFormEditionFormatNumerotation), true);

			m_gestionnaireEditionRelationSysCoorFormatNum.ObjetEdite = SystemeCoordonnees.RelationFormatsNumerotation;

			//Chargement des unites disponibles
			CListeObjetsDonnees lstUnite = new CListeObjetsDonnees(SystemeCoordonnees.ContexteDonnee, typeof(CUniteCoordonnee));
			m_cmbUnite.Init(lstUnite, "Libelle", typeof(CFormEditionUniteCoordonnee), true);


            return result;
        }

		//-------------------------------------------------------------------------
		protected override CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = base.MAJ_Champs();

			if (result)
				result = m_gestionnaireEditionRelationSysCoorFormatNum.ValideModifs();
			return result;
		}


		/// <summary>
		/// Initialise les champs au moment de l'édition
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void m_gestionnaireEditionRelationSysCoorFormatNum_InitChamp(object sender, CObjetDonneeResultEventArgs args)
		{
			if (args.Objet == null)
			{
				m_panelNumerotation.Visible = false;
				return;
			}
			CRelationSystemeCoordonnees_FormatNumerotation rel = (CRelationSystemeCoordonnees_FormatNumerotation)args.Objet;
			
			//m_lblPositionCurrent.Text = rel.Position.ToString();
			m_panelNumerotation.Visible = true;

			m_cmbFormatNumerotation.ElementSelectionne = rel.FormatNumerotation;
			m_cmbUnite.ElementSelectionne = rel.Unite;

			m_lnkEditionRelationSysCoorFormatNum.FillDialogFromObjet(args.Objet);

		}

		private void m_gestionnaireEditionRelationSysCoorFormatNum_MAJ_Champs(object sender, CObjetDonneeResultEventArgs args)
		{
			if (args.Objet != null)
			{
				CResultAErreur result = m_lnkEditionRelationSysCoorFormatNum.FillObjetFromDialog(args.Objet);
				if (!result)
				{
					args.Result = result;
					return;
				}
			}
		}


		//Ajout Item
		private void m_lnkAjouterNumerotation_LinkClicked(object sender, EventArgs e)
		{
			if (m_cmbFormatNumerotation.ElementSelectionne == null)
			{
				CFormAlerte.Afficher(I.T( "Select a Numbering Format to add|1164"), EFormAlerteType.Exclamation);
				return;
			}
            
			CRelationSystemeCoordonnees_FormatNumerotation rel = new CRelationSystemeCoordonnees_FormatNumerotation(SystemeCoordonnees.ContexteDonnee);
			rel.CreateNewInCurrentContexte();
			rel.FormatNumerotation = (CFormatNumerotation)m_cmbFormatNumerotation.ElementSelectionne;
			rel.SystemeDeCoordonnees = SystemeCoordonnees;
			rel.Position = m_wndListeFormatNumerotation.Items.Count;
            
			ListViewItem item = new ListViewItem();
			m_wndListeFormatNumerotation.Items.Add(item);
			m_wndListeFormatNumerotation.UpdateItemWithObject(item, rel);
			foreach (ListViewItem itemSel in m_wndListeFormatNumerotation.SelectedItems)
				itemSel.Selected = false;
			item.Selected = true;
		}


		//Suppression Item
		private void m_lnkSupprimerFormatNumerotation_LinkClicked(object sender, EventArgs e)
		{
			if (m_wndListeFormatNumerotation.SelectedItems.Count != 1)
				return;

			CRelationSystemeCoordonnees_FormatNumerotation rel = (CRelationSystemeCoordonnees_FormatNumerotation)m_wndListeFormatNumerotation.SelectedItems[0].Tag;
			int pos = rel.Position;
			m_gestionnaireEditionRelationSysCoorFormatNum.SetObjetEnCoursToNull();
			CResultAErreur result = rel.Delete();
			if (!result)
			{
				CFormAlerte.Afficher(result.Erreur);
				return;
			}
			
			//On met à jour les positions des éléments restant
			if (m_wndListeFormatNumerotation.SelectedItems.Count == 1)
			{
				if (m_wndListeFormatNumerotation.SelectedItems[0] != null)
					m_wndListeFormatNumerotation.SelectedItems[0].Remove();

				while (pos <= m_wndListeFormatNumerotation.Items.Count - 1)
				{
					CRelationSystemeCoordonnees_FormatNumerotation reltmp = (CRelationSystemeCoordonnees_FormatNumerotation)m_wndListeFormatNumerotation.Items[pos].Tag;
					reltmp.Position = pos;
					pos++;
				}
			}
		}


		private void m_ctrlMD_ApresRenumeration(object sender, EventArgs e)
		{
			if (m_wndListeFormatNumerotation.SelectedItems.Count != 1)
				return;

			CRelationSystemeCoordonnees_FormatNumerotation rel = (CRelationSystemeCoordonnees_FormatNumerotation)m_wndListeFormatNumerotation.SelectedItems[0].Tag;
			m_lblPositionCurrent.Text = rel.Position.ToString();
		}



    }
}

