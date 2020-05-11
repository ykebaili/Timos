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
using sc2i.workflow;
using sc2i.expression;

using timos.acteurs;
using timos.securite;
using timos.data;
using System.Collections.Generic;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CTypePhase))]
	public class CFormEditionTypePhaseTicket : CFormEditionStdTimos, IFormNavigable
	{

		#region Designer generated code

		private CFournisseurPropDynStd m_fournisseurPropDyn = new CFournisseurPropDynStd(true);
        private C2iPanelOmbre m_panelOmbre1;
        private C2iTextBox m_txtLibelle;
        private Label lbl_label;
        private C2iTabControl m_tabControl;
        private Crownwood.Magic.Controls.TabPage m_tabPageOptions;
		private CComboBoxListeObjetsDonnees m_cmbxSelectFormulaire;
        private Label lbl_optinstrucformpers;
		private Crownwood.Magic.Controls.TabPage m_tabPageTypeIntervention;
		private ListViewAutoFilledColumn listViewAutoFilledColumn1;
		private ListViewAutoFilledColumn listViewAutoFilledColumn4;
		private CheckBox m_chkTtesInter;
		private CPanelListeRelationSelection m_ctrlRelTypeIntervention;
		private ListViewAutoFilledColumn listViewAutoFilledColumn2;
		private Crownwood.Magic.Controls.TabPage m_tabPageContactsPossibles;
		private CControlEditionTypeElementAContacts m_ctrlProfilsContactsPossibles;
        private ListViewAutoFilledColumn listViewAutoFilledColumn3;
        private Label label7;
        private SplitContainer splitContainer1;
        private Label lbl_formuleconditionform;
        private sc2i.win32.expression.CTextBoxZoomFormule m_wndFormule;
        private CComboBoxListeObjetsDonnees m_cmbxSelectProfilResponsableTicket;
        private Label label6;
        private Crownwood.Magic.Controls.TabPage m_tabPageEvenements;
        private CPanelDefinisseurEvenements m_panelDefinisseurEvenements;
        private Crownwood.Magic.Controls.TabPage m_pageOperations;
        private C2iTextBoxSelectionne m_selectOperation;
        private CCtrlUpDownListView m_controlMonteDescendre;
        private ListViewAutoFilled m_wndListeOperations;
        private ListViewAutoFilledColumn listViewAutoFilledColumn5;
        private ListViewAutoFilledColumn listViewAutoFilledColumn6;
        private CWndLinkStd m_lnkRemoveOperation;
        private CWndLinkStd m_lnkAddOperation;
        private Label lbl_ope;
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
            this.m_panelOmbre1 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.lbl_label = new System.Windows.Forms.Label();
            this.m_chkTtesInter = new System.Windows.Forms.CheckBox();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageOperations = new Crownwood.Magic.Controls.TabPage();
            this.m_selectOperation = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_controlMonteDescendre = new sc2i.win32.common.CCtrlUpDownListView();
            this.m_wndListeOperations = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn5 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn6 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_lnkRemoveOperation = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkAddOperation = new sc2i.win32.common.CWndLinkStd();
            this.lbl_ope = new System.Windows.Forms.Label();
            this.m_tabPageOptions = new Crownwood.Magic.Controls.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_cmbxSelectProfilResponsableTicket = new sc2i.win32.data.CComboBoxListeObjetsDonnees();
            this.lbl_optinstrucformpers = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_formuleconditionform = new System.Windows.Forms.Label();
            this.m_cmbxSelectFormulaire = new sc2i.win32.data.CComboBoxListeObjetsDonnees();
            this.m_wndFormule = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.m_tabPageTypeIntervention = new Crownwood.Magic.Controls.TabPage();
            this.m_ctrlRelTypeIntervention = new sc2i.win32.data.navigation.CPanelListeRelationSelection();
            this.listViewAutoFilledColumn2 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.m_tabPageContactsPossibles = new Crownwood.Magic.Controls.TabPage();
            this.m_ctrlProfilsContactsPossibles = new timos.acteurs.CControlEditionTypeElementAContacts();
            this.m_tabPageEvenements = new Crownwood.Magic.Controls.TabPage();
            this.m_panelDefinisseurEvenements = new timos.CPanelDefinisseurEvenements();
            this.listViewAutoFilledColumn3 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn4 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            this.m_panelOmbre1.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.m_pageOperations.SuspendLayout();
            this.m_tabPageOptions.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.m_tabPageTypeIntervention.SuspendLayout();
            this.m_tabPageContactsPossibles.SuspendLayout();
            this.m_tabPageEvenements.SuspendLayout();
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
            this.m_panelNavigation.Location = new System.Drawing.Point(724, 0);
            this.m_extStyle.SetStyleBackColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelCle
            // 
            this.m_panelCle.Location = new System.Drawing.Point(610, 0);
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
            // m_panelOmbre1
            // 
            this.m_panelOmbre1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelOmbre1.Controls.Add(this.m_txtLibelle);
            this.m_panelOmbre1.Controls.Add(this.lbl_label);
            this.m_panelOmbre1.Controls.Add(this.m_chkTtesInter);
            this.m_panelOmbre1.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panelOmbre1, "");
            this.m_panelOmbre1.Location = new System.Drawing.Point(10, 46);
            this.m_panelOmbre1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelOmbre1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelOmbre1, "");
            this.m_panelOmbre1.Name = "m_panelOmbre1";
            this.m_panelOmbre1.Size = new System.Drawing.Size(648, 84);
            this.m_extStyle.SetStyleBackColor(this.m_panelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelOmbre1.TabIndex = 4004;
            // 
            // m_txtLibelle
            // 
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_txtLibelle.Location = new System.Drawing.Point(210, 13);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(340, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 3;
            this.m_txtLibelle.Text = "[Label]|30324";
            // 
            // lbl_label
            // 
            this.m_extLinkField.SetLinkField(this.lbl_label, "");
            this.lbl_label.Location = new System.Drawing.Point(20, 16);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_label, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.lbl_label, "");
            this.lbl_label.Name = "lbl_label";
            this.lbl_label.Size = new System.Drawing.Size(184, 13);
            this.m_extStyle.SetStyleBackColor(this.lbl_label, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.lbl_label, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_label.TabIndex = 4;
            this.lbl_label.Text = "Phase Type Label|633";
            // 
            // m_chkTtesInter
            // 
            this.m_chkTtesInter.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkTtesInter, "");
            this.m_chkTtesInter.Location = new System.Drawing.Point(19, 38);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkTtesInter, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkTtesInter, "");
            this.m_chkTtesInter.Name = "m_chkTtesInter";
            this.m_chkTtesInter.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.m_chkTtesInter.Size = new System.Drawing.Size(144, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkTtesInter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkTtesInter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkTtesInter.TabIndex = 6;
            this.m_chkTtesInter.Text = "All Intervention types|634";
            this.m_chkTtesInter.UseVisualStyleBackColor = true;
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
            this.m_extLinkField.SetLinkField(this.m_tabControl, "");
            this.m_tabControl.Location = new System.Drawing.Point(12, 136);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 4;
            this.m_tabControl.SelectedTab = this.m_tabPageEvenements;
            this.m_tabControl.Size = new System.Drawing.Size(808, 393);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4005;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageOperations,
            this.m_tabPageOptions,
            this.m_tabPageTypeIntervention,
            this.m_tabPageContactsPossibles,
            this.m_tabPageEvenements});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageOperations
            // 
            this.m_pageOperations.Controls.Add(this.m_selectOperation);
            this.m_pageOperations.Controls.Add(this.m_controlMonteDescendre);
            this.m_pageOperations.Controls.Add(this.m_lnkRemoveOperation);
            this.m_pageOperations.Controls.Add(this.m_wndListeOperations);
            this.m_pageOperations.Controls.Add(this.m_lnkAddOperation);
            this.m_pageOperations.Controls.Add(this.lbl_ope);
            this.m_extLinkField.SetLinkField(this.m_pageOperations, "");
            this.m_pageOperations.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageOperations, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageOperations, "");
            this.m_pageOperations.Name = "m_pageOperations";
            this.m_pageOperations.Selected = false;
            this.m_pageOperations.Size = new System.Drawing.Size(792, 352);
            this.m_extStyle.SetStyleBackColor(this.m_pageOperations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageOperations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageOperations.TabIndex = 14;
            this.m_pageOperations.Title = "Operations|593";
            // 
            // m_selectOperation
            // 
            this.m_selectOperation.ElementSelectionne = null;
            this.m_selectOperation.FonctionTextNull = null;
            this.m_selectOperation.HasLink = true;
            this.m_extLinkField.SetLinkField(this.m_selectOperation, "");
            this.m_selectOperation.Location = new System.Drawing.Point(91, 11);
            this.m_selectOperation.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_selectOperation, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_selectOperation, "");
            this.m_selectOperation.Name = "m_selectOperation";
            this.m_selectOperation.SelectedObject = null;
            this.m_selectOperation.Size = new System.Drawing.Size(301, 21);
            this.m_extStyle.SetStyleBackColor(this.m_selectOperation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_selectOperation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectOperation.TabIndex = 10;
            this.m_selectOperation.TextNull = "";
            // 
            // m_controlMonteDescendre
            // 
            this.m_controlMonteDescendre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_extLinkField.SetLinkField(this.m_controlMonteDescendre, "");
            this.m_controlMonteDescendre.ListeGeree = this.m_wndListeOperations;
            this.m_controlMonteDescendre.Location = new System.Drawing.Point(341, 324);
            this.m_controlMonteDescendre.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_controlMonteDescendre, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_controlMonteDescendre, "");
            this.m_controlMonteDescendre.Name = "m_controlMonteDescendre";
            this.m_controlMonteDescendre.ProprieteNumero = "Index";
            this.m_controlMonteDescendre.Size = new System.Drawing.Size(51, 20);
            this.m_extStyle.SetStyleBackColor(this.m_controlMonteDescendre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_controlMonteDescendre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_controlMonteDescendre.TabIndex = 15;
            // 
            // m_wndListeOperations
            // 
            this.m_wndListeOperations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_wndListeOperations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn5,
            this.listViewAutoFilledColumn6});
            this.m_wndListeOperations.EnableCustomisation = true;
            this.m_wndListeOperations.FullRowSelect = true;
            this.m_wndListeOperations.HideSelection = false;
            this.m_extLinkField.SetLinkField(this.m_wndListeOperations, "");
            this.m_wndListeOperations.Location = new System.Drawing.Point(17, 55);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeOperations, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndListeOperations, "");
            this.m_wndListeOperations.MultiSelect = false;
            this.m_wndListeOperations.Name = "m_wndListeOperations";
            this.m_wndListeOperations.Size = new System.Drawing.Size(375, 266);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeOperations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeOperations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeOperations.TabIndex = 12;
            this.m_wndListeOperations.UseCompatibleStateImageBehavior = false;
            this.m_wndListeOperations.View = System.Windows.Forms.View.Details;
            // 
            // listViewAutoFilledColumn5
            // 
            this.listViewAutoFilledColumn5.Field = "TypeOperation.Code";
            this.listViewAutoFilledColumn5.PrecisionWidth = 0;
            this.listViewAutoFilledColumn5.ProportionnalSize = false;
            this.listViewAutoFilledColumn5.Text = "Code|369";
            this.listViewAutoFilledColumn5.Visible = true;
            this.listViewAutoFilledColumn5.Width = 70;
            // 
            // listViewAutoFilledColumn6
            // 
            this.listViewAutoFilledColumn6.Field = "TypeOperation.Libelle";
            this.listViewAutoFilledColumn6.PrecisionWidth = 0;
            this.listViewAutoFilledColumn6.ProportionnalSize = false;
            this.listViewAutoFilledColumn6.Text = "Label|50";
            this.listViewAutoFilledColumn6.Visible = true;
            this.listViewAutoFilledColumn6.Width = 200;
            // 
            // m_lnkRemoveOperation
            // 
            this.m_lnkRemoveOperation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkRemoveOperation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkRemoveOperation.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkRemoveOperation, "");
            this.m_lnkRemoveOperation.Location = new System.Drawing.Point(15, 324);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkRemoveOperation, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkRemoveOperation, "");
            this.m_lnkRemoveOperation.Name = "m_lnkRemoveOperation";
            this.m_lnkRemoveOperation.Size = new System.Drawing.Size(104, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkRemoveOperation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkRemoveOperation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkRemoveOperation.TabIndex = 14;
            this.m_lnkRemoveOperation.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkRemoveOperation.LinkClicked += new System.EventHandler(this.m_lnkRemoveOperation_LinkClicked);
            // 
            // m_lnkAddOperation
            // 
            this.m_lnkAddOperation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAddOperation.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkAddOperation, "");
            this.m_lnkAddOperation.Location = new System.Drawing.Point(91, 36);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAddOperation, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAddOperation, "");
            this.m_lnkAddOperation.Name = "m_lnkAddOperation";
            this.m_lnkAddOperation.Size = new System.Drawing.Size(104, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAddOperation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAddOperation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAddOperation.TabIndex = 13;
            this.m_lnkAddOperation.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAddOperation.LinkClicked += new System.EventHandler(this.m_lnkAddOperation_LinkClicked);
            // 
            // lbl_ope
            // 
            this.m_extLinkField.SetLinkField(this.lbl_ope, "");
            this.lbl_ope.Location = new System.Drawing.Point(12, 14);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_ope, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.lbl_ope, "");
            this.lbl_ope.Name = "lbl_ope";
            this.lbl_ope.Size = new System.Drawing.Size(86, 18);
            this.m_extStyle.SetStyleBackColor(this.lbl_ope, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.lbl_ope, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_ope.TabIndex = 11;
            this.lbl_ope.Text = "Operation|592";
            // 
            // m_tabPageOptions
            // 
            this.m_tabPageOptions.Controls.Add(this.splitContainer1);
            this.m_extLinkField.SetLinkField(this.m_tabPageOptions, "");
            this.m_tabPageOptions.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabPageOptions, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabPageOptions, "");
            this.m_tabPageOptions.Name = "m_tabPageOptions";
            this.m_tabPageOptions.Selected = false;
            this.m_tabPageOptions.Size = new System.Drawing.Size(792, 352);
            this.m_extStyle.SetStyleBackColor(this.m_tabPageOptions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabPageOptions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabPageOptions.TabIndex = 10;
            this.m_tabPageOptions.Title = "Options|56";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.splitContainer1, "");
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitContainer1, "");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m_cmbxSelectProfilResponsableTicket);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_optinstrucformpers);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_formuleconditionform);
            this.splitContainer1.Panel1.Controls.Add(this.m_cmbxSelectFormulaire);
            this.splitContainer1.Panel1.Controls.Add(this.m_wndFormule);
            this.m_extLinkField.SetLinkField(this.splitContainer1.Panel1, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1.Panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitContainer1.Panel1, "");
            this.m_extStyle.SetStyleBackColor(this.splitContainer1.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer1.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // splitContainer1.Panel2
            // 
            this.m_extLinkField.SetLinkField(this.splitContainer1.Panel2, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1.Panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitContainer1.Panel2, "");
            this.m_extStyle.SetStyleBackColor(this.splitContainer1.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer1.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitContainer1.Size = new System.Drawing.Size(792, 352);
            this.splitContainer1.SplitterDistance = 472;
            this.m_extStyle.SetStyleBackColor(this.splitContainer1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitContainer1.TabIndex = 6;
            // 
            // m_cmbxSelectProfilResponsableTicket
            // 
            this.m_cmbxSelectProfilResponsableTicket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbxSelectProfilResponsableTicket.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbxSelectProfilResponsableTicket.ElementSelectionne = null;
            this.m_cmbxSelectProfilResponsableTicket.FormattingEnabled = true;
            this.m_cmbxSelectProfilResponsableTicket.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbxSelectProfilResponsableTicket, "");
            this.m_cmbxSelectProfilResponsableTicket.ListDonnees = null;
            this.m_cmbxSelectProfilResponsableTicket.Location = new System.Drawing.Point(15, 173);
            this.m_cmbxSelectProfilResponsableTicket.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbxSelectProfilResponsableTicket, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbxSelectProfilResponsableTicket, "");
            this.m_cmbxSelectProfilResponsableTicket.Name = "m_cmbxSelectProfilResponsableTicket";
            this.m_cmbxSelectProfilResponsableTicket.NullAutorise = true;
            this.m_cmbxSelectProfilResponsableTicket.ProprieteAffichee = null;
            this.m_cmbxSelectProfilResponsableTicket.ProprieteParentListeObjets = null;
            this.m_cmbxSelectProfilResponsableTicket.SelectionneurParent = null;
            this.m_cmbxSelectProfilResponsableTicket.Size = new System.Drawing.Size(420, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbxSelectProfilResponsableTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbxSelectProfilResponsableTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbxSelectProfilResponsableTicket.TabIndex = 8;
            this.m_cmbxSelectProfilResponsableTicket.TextNull = I.T("(none)|30921");
            this.m_cmbxSelectProfilResponsableTicket.Tri = true;
            // 
            // lbl_optinstrucformpers
            // 
            this.m_extLinkField.SetLinkField(this.lbl_optinstrucformpers, "");
            this.lbl_optinstrucformpers.Location = new System.Drawing.Point(11, 21);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_optinstrucformpers, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.lbl_optinstrucformpers, "");
            this.lbl_optinstrucformpers.Name = "lbl_optinstrucformpers";
            this.lbl_optinstrucformpers.Size = new System.Drawing.Size(424, 20);
            this.m_extStyle.SetStyleBackColor(this.lbl_optinstrucformpers, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.lbl_optinstrucformpers, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_optinstrucformpers.TabIndex = 4;
            this.lbl_optinstrucformpers.Text = "Select the custom form to display while editing the phases of this type|636";
            // 
            // label6
            // 
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.label6.Location = new System.Drawing.Point(12, 153);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label6, "");
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(400, 17);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 7;
            this.label6.Text = "Profile of users allowed to manage phases of this type|638";
            // 
            // lbl_formuleconditionform
            // 
            this.m_extLinkField.SetLinkField(this.lbl_formuleconditionform, "");
            this.lbl_formuleconditionform.Location = new System.Drawing.Point(12, 83);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_formuleconditionform, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.lbl_formuleconditionform, "");
            this.lbl_formuleconditionform.Name = "lbl_formuleconditionform";
            this.lbl_formuleconditionform.Size = new System.Drawing.Size(416, 13);
            this.m_extStyle.SetStyleBackColor(this.lbl_formuleconditionform, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.lbl_formuleconditionform, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_formuleconditionform.TabIndex = 7;
            this.lbl_formuleconditionform.Text = "Phase exit condition formula|637";
            // 
            // m_cmbxSelectFormulaire
            // 
            this.m_cmbxSelectFormulaire.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbxSelectFormulaire.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbxSelectFormulaire.ElementSelectionne = null;
            this.m_cmbxSelectFormulaire.FormattingEnabled = true;
            this.m_cmbxSelectFormulaire.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbxSelectFormulaire, "");
            this.m_cmbxSelectFormulaire.ListDonnees = null;
            this.m_cmbxSelectFormulaire.Location = new System.Drawing.Point(14, 44);
            this.m_cmbxSelectFormulaire.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbxSelectFormulaire, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbxSelectFormulaire, "");
            this.m_cmbxSelectFormulaire.Name = "m_cmbxSelectFormulaire";
            this.m_cmbxSelectFormulaire.NullAutorise = true;
            this.m_cmbxSelectFormulaire.ProprieteAffichee = null;
            this.m_cmbxSelectFormulaire.ProprieteParentListeObjets = null;
            this.m_cmbxSelectFormulaire.SelectionneurParent = null;
            this.m_cmbxSelectFormulaire.Size = new System.Drawing.Size(421, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbxSelectFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbxSelectFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbxSelectFormulaire.TabIndex = 0;
            this.m_cmbxSelectFormulaire.TextNull = I.T("(None)|30291");
            this.m_cmbxSelectFormulaire.Tri = true;
            this.m_cmbxSelectFormulaire.SelectionChangeCommitted += new System.EventHandler(this.m_cmbxSelectFormulaire_SelectionChangeCommitted);
            // 
            // m_wndFormule
            // 
            this.m_wndFormule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_wndFormule.Formule = null;
            this.m_extLinkField.SetLinkField(this.m_wndFormule, "");
            this.m_wndFormule.Location = new System.Drawing.Point(14, 99);
            this.m_wndFormule.LockEdition = false;
            this.m_wndFormule.LockZoneTexte = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndFormule, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_wndFormule, "");
            this.m_wndFormule.Name = "m_wndFormule";
            this.m_wndFormule.Size = new System.Drawing.Size(421, 23);
            this.m_extStyle.SetStyleBackColor(this.m_wndFormule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndFormule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndFormule.TabIndex = 6;
            // 
            // m_tabPageTypeIntervention
            // 
            this.m_tabPageTypeIntervention.Controls.Add(this.m_ctrlRelTypeIntervention);
            this.m_tabPageTypeIntervention.Controls.Add(this.label7);
            this.m_extLinkField.SetLinkField(this.m_tabPageTypeIntervention, "");
            this.m_tabPageTypeIntervention.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabPageTypeIntervention, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabPageTypeIntervention, "");
            this.m_tabPageTypeIntervention.Name = "m_tabPageTypeIntervention";
            this.m_tabPageTypeIntervention.Selected = false;
            this.m_tabPageTypeIntervention.Size = new System.Drawing.Size(792, 352);
            this.m_extStyle.SetStyleBackColor(this.m_tabPageTypeIntervention, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabPageTypeIntervention, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabPageTypeIntervention.TabIndex = 11;
            this.m_tabPageTypeIntervention.Title = "Associated intervention types|635";
            // 
            // m_ctrlRelTypeIntervention
            // 
            this.m_ctrlRelTypeIntervention.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ctrlRelTypeIntervention.Columns.AddRange(new sc2i.win32.common.ListViewAutoFilledColumn[] {
            this.listViewAutoFilledColumn2});
            this.m_ctrlRelTypeIntervention.EnableCustomisation = true;
            this.m_ctrlRelTypeIntervention.ExclusionParException = false;
            this.m_extLinkField.SetLinkField(this.m_ctrlRelTypeIntervention, "");
            this.m_ctrlRelTypeIntervention.Location = new System.Drawing.Point(26, 25);
            this.m_ctrlRelTypeIntervention.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_ctrlRelTypeIntervention, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_ctrlRelTypeIntervention, "");
            this.m_ctrlRelTypeIntervention.Name = "m_ctrlRelTypeIntervention";
            this.m_ctrlRelTypeIntervention.Size = new System.Drawing.Size(747, 311);
            this.m_extStyle.SetStyleBackColor(this.m_ctrlRelTypeIntervention, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_ctrlRelTypeIntervention, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ctrlRelTypeIntervention.TabIndex = 4020;
            // 
            // listViewAutoFilledColumn2
            // 
            this.listViewAutoFilledColumn2.Field = "Libelle";
            this.listViewAutoFilledColumn2.PrecisionWidth = 0;
            this.listViewAutoFilledColumn2.ProportionnalSize = false;
            this.listViewAutoFilledColumn2.Text = "Label|50";
            this.listViewAutoFilledColumn2.Visible = true;
            this.listViewAutoFilledColumn2.Width = 200;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label7, "");
            this.label7.Location = new System.Drawing.Point(33, 9);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label7, "");
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(299, 13);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 4;
            this.label7.Text = "Select possible Interventions Types on this Phase Type|1217";
            // 
            // m_tabPageContactsPossibles
            // 
            this.m_tabPageContactsPossibles.Controls.Add(this.m_ctrlProfilsContactsPossibles);
            this.m_extLinkField.SetLinkField(this.m_tabPageContactsPossibles, "");
            this.m_tabPageContactsPossibles.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabPageContactsPossibles, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabPageContactsPossibles, "");
            this.m_tabPageContactsPossibles.Name = "m_tabPageContactsPossibles";
            this.m_tabPageContactsPossibles.Selected = false;
            this.m_tabPageContactsPossibles.Size = new System.Drawing.Size(792, 352);
            this.m_extStyle.SetStyleBackColor(this.m_tabPageContactsPossibles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabPageContactsPossibles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabPageContactsPossibles.TabIndex = 12;
            this.m_tabPageContactsPossibles.Title = "Possible contacts|594";
            // 
            // m_ctrlProfilsContactsPossibles
            // 
            this.m_ctrlProfilsContactsPossibles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_ctrlProfilsContactsPossibles, "");
            this.m_ctrlProfilsContactsPossibles.Location = new System.Drawing.Point(0, 0);
            this.m_ctrlProfilsContactsPossibles.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_ctrlProfilsContactsPossibles, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_ctrlProfilsContactsPossibles, "");
            this.m_ctrlProfilsContactsPossibles.Name = "m_ctrlProfilsContactsPossibles";
            this.m_ctrlProfilsContactsPossibles.Size = new System.Drawing.Size(792, 352);
            this.m_extStyle.SetStyleBackColor(this.m_ctrlProfilsContactsPossibles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_ctrlProfilsContactsPossibles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ctrlProfilsContactsPossibles.TabIndex = 0;
            // 
            // m_tabPageEvenements
            // 
            this.m_tabPageEvenements.Controls.Add(this.m_panelDefinisseurEvenements);
            this.m_extLinkField.SetLinkField(this.m_tabPageEvenements, "");
            this.m_tabPageEvenements.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabPageEvenements, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabPageEvenements, "");
            this.m_tabPageEvenements.Name = "m_tabPageEvenements";
            this.m_tabPageEvenements.Size = new System.Drawing.Size(792, 352);
            this.m_extStyle.SetStyleBackColor(this.m_tabPageEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabPageEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabPageEvenements.TabIndex = 13;
            this.m_tabPageEvenements.Title = "Events|183";
            // 
            // m_panelDefinisseurEvenements
            // 
            this.m_panelDefinisseurEvenements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelDefinisseurEvenements, "");
            this.m_panelDefinisseurEvenements.Location = new System.Drawing.Point(0, 0);
            this.m_panelDefinisseurEvenements.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelDefinisseurEvenements, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelDefinisseurEvenements, "");
            this.m_panelDefinisseurEvenements.Name = "m_panelDefinisseurEvenements";
            this.m_panelDefinisseurEvenements.Size = new System.Drawing.Size(792, 352);
            this.m_extStyle.SetStyleBackColor(this.m_panelDefinisseurEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelDefinisseurEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelDefinisseurEvenements.TabIndex = 1;
            // 
            // listViewAutoFilledColumn3
            // 
            this.listViewAutoFilledColumn3.Field = "Nom";
            this.listViewAutoFilledColumn3.PrecisionWidth = 0;
            this.listViewAutoFilledColumn3.ProportionnalSize = false;
            this.listViewAutoFilledColumn3.Text = "Group label|1218";
            this.listViewAutoFilledColumn3.Visible = true;
            this.listViewAutoFilledColumn3.Width = 397;
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "Libelle";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Label|50";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 120;
            // 
            // listViewAutoFilledColumn4
            // 
            this.listViewAutoFilledColumn4.Field = "FormatNumerotation.Libelle";
            this.listViewAutoFilledColumn4.PrecisionWidth = 0;
            this.listViewAutoFilledColumn4.ProportionnalSize = false;
            this.listViewAutoFilledColumn4.Text = "Type|54";
            this.listViewAutoFilledColumn4.Visible = true;
            this.listViewAutoFilledColumn4.Width = 110;
            // 
            // CFormEditionTypePhaseTicket
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.m_panelOmbre1);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionTypePhaseTicket";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.m_panelOmbre1, 0);
            this.Controls.SetChildIndex(this.m_tabControl, 0);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            this.m_panelOmbre1.ResumeLayout(false);
            this.m_panelOmbre1.PerformLayout();
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.m_pageOperations.ResumeLayout(false);
            this.m_tabPageOptions.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.m_tabPageTypeIntervention.ResumeLayout(false);
            this.m_tabPageTypeIntervention.PerformLayout();
            this.m_tabPageContactsPossibles.ResumeLayout(false);
            this.m_tabPageEvenements.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		public CFormEditionTypePhaseTicket()
			: base()
		{
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionTypePhaseTicket(CTypePhase typephase)
			: base(typephase)
		{
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionTypePhaseTicket(CTypePhase typephase, CListeObjetsDonnees liste)
			: base(typephase, liste)
		{
			InitializeComponent();
		}

		//-------------------------------------------------------------------------
		private CTypePhase TypePhaseTicket
		{
			get
			{
				return (CTypePhase)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
			AffecterTitre(I.T( "Ticket Phase type|1112") + " :" + TypePhaseTicket.Libelle);

            InitSelectTypeOperation();

            CListeObjetsDonnees listeFormulaires = new CListeObjetsDonnees(TypePhaseTicket.ContexteDonnee, typeof(CFormulaire));

            listeFormulaires.Filtre = CFormulaire.GetFiltreFormulairesForRole(TypePhaseTicket.RoleChampCustomDesElementsAChamp.CodeRole);
                /*new CFiltreData(
                CFormulaire.c_champCodeRole + "=@1",
                TypePhaseTicket.RoleChampCustomDesElementsAChamp.CodeRole);*/

            m_cmbxSelectFormulaire.Init(
                listeFormulaires,
                "Libelle",
                true);

			//Chargement du formulaire
            m_cmbxSelectFormulaire.ElementSelectionne = TypePhaseTicket.Formulaire;

			//Chargement de l'option toutes intervention
			m_chkTtesInter.Checked = TypePhaseTicket.ToutesInterventions;


			//Chargement des Types d'Interventions possibles
			CListeObjetsDonnees lstTypeIntervention = new CListeObjetsDonnees(TypePhaseTicket.ContexteDonnee, typeof(CTypeIntervention));
			m_ctrlRelTypeIntervention.Init(
                lstTypeIntervention, 
                TypePhaseTicket.RelationTypesIntervention,
                TypePhaseTicket, 
                "TypePhase",
                "TypeIntervention");


			//Chargement des contacts possibles
			m_ctrlProfilsContactsPossibles.Init(TypePhaseTicket);

            //InitApercuFormulaire();

            // Formule de condition de sortie de phase
            m_wndFormule.Init(m_fournisseurPropDyn, typeof(CPhaseTicket));
            m_wndFormule.Formule = TypePhaseTicket.FormuleConditionSortie;

            InitComboSelectProfilResponsable();
            m_cmbxSelectProfilResponsableTicket.ElementSelectionne = TypePhaseTicket.ProfilResponsableTicket;

            m_panelDefinisseurEvenements.InitChamps(TypePhaseTicket);

            // Init la liste des opératins liées
            m_wndListeOperations.Items.Clear();
            foreach (CTypePhase_TypeOperation rel in TypePhaseTicket.RelationsTypesOperations)
            {
                ListViewItem item = new ListViewItem();
                m_wndListeOperations.Items.Add(item);
                m_wndListeOperations.UpdateItemWithObject(item, rel);
                foreach (ListViewItem itemSel in m_wndListeOperations.SelectedItems)
                    itemSel.Selected = false;

            }

            return result;
		}

        //-------------------------------------------------------------------------
        private void InitComboSelectProfilResponsable()
        {
            CListeObjetsDonnees liste = new CListeObjetsDonnees(TypePhaseTicket.ContexteDonnee, typeof(CProfilElement));

            string strTypeSource = (typeof(CPhaseTicket)).ToString();
            string strTypeElement = (typeof(CDonneesActeurUtilisateur)).ToString();

            CFiltreData filtre = new CFiltreData(
                CProfilElement.c_champTypeSource + " = @1 " + " and " +
                CProfilElement.c_champTypeElements + " = @2",
                strTypeSource,
                strTypeElement);

            liste.Filtre = filtre;
            m_cmbxSelectProfilResponsableTicket.Init(liste, "Libelle", true);

        }

		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();

            TypePhaseTicket.ToutesInterventions = m_chkTtesInter.Checked;
            TypePhaseTicket.FormuleConditionSortie = m_wndFormule.Formule;
            TypePhaseTicket.ProfilResponsableTicket = (CProfilElement)m_cmbxSelectProfilResponsableTicket.ElementSelectionne;

            if (result)
                TypePhaseTicket.Formulaire = (CFormulaire)m_cmbxSelectFormulaire.ElementSelectionne;
			if (result)
				result = m_ctrlProfilsContactsPossibles.MAJ_Champs();
			if (result)
				m_ctrlRelTypeIntervention.ApplyModifs();
            if (result)
                m_panelDefinisseurEvenements.MAJ_Champs();

            return result;
        }

        //-------------------------------------------------------------------------
        private void m_cmbxSelectFormulaire_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //MAJ_Champs();
            //InitApercuFormulaire();
        }

        //-------------------------------------------------------------------------
        private void InitApercuFormulaire()
        {
            // Uniquement pour faire un aperçu du Formulaire
            //if (TypePhaseTicket.Formulaire != null)
            //{
            //    m_panelFormulaireSurOrigine.Visible = true;
            //    m_panelFormulaireSurOrigine.InitPanel(
            //        TypePhaseTicket.Formulaire.Formulaire,
            //        null);
            //}
            //else
            //    m_panelFormulaireSurOrigine.Visible = false;

        }

        //----------------------------------------------------------------------
        private void m_lnkAddOperation_LinkClicked(object sender, EventArgs e)
        {
            if (m_selectOperation.ElementSelectionne == null)
            {
                CFormAlerte.Afficher(I.T("Select the operation type to add|371"), EFormAlerteType.Exclamation);
                return;
            }

            CTypeOperation tpOperation = (CTypeOperation)m_selectOperation.ElementSelectionne;

            CListeObjetsDonnees listeExistants = TypePhaseTicket.RelationsTypesOperations;
            int index = listeExistants.Count;
            listeExistants.Filtre = new CFiltreData(
                CTypeOperation.c_champId + "=@1",
                tpOperation.Id);
            if (listeExistants.Count != 0)
            {
                CFormAlerte.Afficher(I.T("Cannot add this operation type|372"), EFormAlerteType.Erreur);
                return;
            }
            m_selectOperation.ElementSelectionne = null;
            CTypePhase_TypeOperation rel = new CTypePhase_TypeOperation(TypePhaseTicket.ContexteDonnee);
            rel.CreateNewInCurrentContexte();
            rel.TypePhase = TypePhaseTicket;
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

            CTypePhase_TypeOperation rel = (CTypePhase_TypeOperation)m_wndListeOperations.SelectedItems[0].Tag;

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
            foreach (CTypePhase_TypeOperation rel in TypePhaseTicket.RelationsTypesOperations)
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
	}
}

