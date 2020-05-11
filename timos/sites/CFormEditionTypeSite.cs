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

using timos.data;
using timos.securite;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CTypeSite))]
	public class CFormEditionTypeSite : CFormEditionStdTimos, IFormNavigable
	{
		#region Designer generated code

        private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
        private C2iTabControl m_TabControl;
        private C2iTextBox m_TextComment;
        private Label m_lblLabel;
        private Crownwood.Magic.Controls.TabPage pageDependences;
        private CPanelListeRelationSelection m_panelTypeContenu;
        private ListViewAutoFilledColumn listViewAutoFilledColumn1;
        private Crownwood.Magic.Controls.TabPage pageChampsCustom;
        private timos.win32.composants.CPanelEditDefinisseurChampsCustom m_panelEditChamps;
        private CPanelListeRelationSelection m_panelTypeContenant;
        private ListViewAutoFilledColumn listViewAutoFilledColumn2;
        private Label m_labelGauche;
        private Label m_labelDroite;
        private SplitContainer m_splitContainer;
		private Crownwood.Magic.Controls.TabPage pageOptions;
		private CControleEditeObjetASystemeCoordonnee m_panelSystemeCoordonnees;
        private CheckBox m_chkParentObligatoire;
        private Crownwood.Magic.Controls.TabPage pageContraintes;
        private CPanelListeSpeedStandard m_panelListeContraintes;
		private Crownwood.Magic.Controls.TabPage pageEOs;
		private CPanelAffectationEO m_panelEOS;
		private Label m_lblTypeEOCoor;
		private CComboBoxLinkListeObjetsDonnees m_cmbTypeEntitesNivZero;
		private Crownwood.Magic.Controls.TabPage pageTypesTableParametrables;
		private CPanelListeRelationSelection m_tableParametrablesLstSelec;
        private ListViewAutoFilledColumn listViewAutoFilledColumn3;
        private SplitContainer m_PanelSplitContainer;
        private CPanelSymboleElement m_panelSymbole;
        private Label label2;
        private Crownwood.Magic.Controls.TabPage pageFormulaires;
        private sc2i.win32.data.dynamic.CPanelChampsCustom m_panelChamps;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionTypeSite));
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_TextComment = new sc2i.win32.common.C2iTextBox();
            this.m_lblLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_chkParentObligatoire = new System.Windows.Forms.CheckBox();
            this.m_TabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.pageDependences = new Crownwood.Magic.Controls.TabPage();
            this.m_splitContainer = new System.Windows.Forms.SplitContainer();
            this.m_labelGauche = new System.Windows.Forms.Label();
            this.m_panelTypeContenu = new sc2i.win32.data.navigation.CPanelListeRelationSelection();
            this.listViewAutoFilledColumn1 = ((sc2i.win32.common.ListViewAutoFilledColumn)(new sc2i.win32.common.ListViewAutoFilledColumn()));
            this.m_labelDroite = new System.Windows.Forms.Label();
            this.m_panelTypeContenant = new sc2i.win32.data.navigation.CPanelListeRelationSelection();
            this.listViewAutoFilledColumn2 = ((sc2i.win32.common.ListViewAutoFilledColumn)(new sc2i.win32.common.ListViewAutoFilledColumn()));
            this.pageEOs = new Crownwood.Magic.Controls.TabPage();
            this.m_panelEOS = new timos.CPanelAffectationEO();
            this.pageChampsCustom = new Crownwood.Magic.Controls.TabPage();
            this.m_panelEditChamps = new timos.win32.composants.CPanelEditDefinisseurChampsCustom();
            this.pageOptions = new Crownwood.Magic.Controls.TabPage();
            this.m_PanelSplitContainer = new System.Windows.Forms.SplitContainer();
            this.m_panelSystemeCoordonnees = new timos.CControleEditeObjetASystemeCoordonnee();
            this.m_panelSymbole = new timos.CPanelSymboleElement();
            this.m_cmbTypeEntitesNivZero = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.m_lblTypeEOCoor = new System.Windows.Forms.Label();
            this.pageContraintes = new Crownwood.Magic.Controls.TabPage();
            this.m_panelListeContraintes = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.pageTypesTableParametrables = new Crownwood.Magic.Controls.TabPage();
            this.m_tableParametrablesLstSelec = new sc2i.win32.data.navigation.CPanelListeRelationSelection();
            this.listViewAutoFilledColumn3 = ((sc2i.win32.common.ListViewAutoFilledColumn)(new sc2i.win32.common.ListViewAutoFilledColumn()));
            this.label1 = new System.Windows.Forms.Label();
            this.pageFormulaires = new Crownwood.Magic.Controls.TabPage();
            this.m_panelChamps = new sc2i.win32.data.dynamic.CPanelChampsCustom();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.m_TabControl.SuspendLayout();
            this.pageDependences.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_splitContainer)).BeginInit();
            this.m_splitContainer.Panel1.SuspendLayout();
            this.m_splitContainer.Panel2.SuspendLayout();
            this.m_splitContainer.SuspendLayout();
            this.pageEOs.SuspendLayout();
            this.pageChampsCustom.SuspendLayout();
            this.pageOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_PanelSplitContainer)).BeginInit();
            this.m_PanelSplitContainer.Panel1.SuspendLayout();
            this.m_PanelSplitContainer.Panel2.SuspendLayout();
            this.m_PanelSplitContainer.SuspendLayout();
            this.pageContraintes.SuspendLayout();
            this.pageTypesTableParametrables.SuspendLayout();
            this.pageFormulaires.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnAnnulerModifications
            // 
            this.m_extLinkField.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnAnnulerModifications, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAnnulerModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnValiderModifications
            // 
            this.m_extLinkField.SetLinkField(this.m_btnValiderModifications, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnValiderModifications, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnValiderModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnSupprimerObjet
            // 
            this.m_extLinkField.SetLinkField(this.m_btnSupprimerObjet, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnSupprimerObjet, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnSupprimerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnEditerObjet
            // 
            this.m_extLinkField.SetLinkField(this.m_btnEditerObjet, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnEditerObjet, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnEditerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_extLinkField
            // 
            this.m_extLinkField.SourceTypeString = "timos.data.CTypeSite";
            // 
            // m_panelNavigation
            // 
            this.m_panelNavigation.Location = new System.Drawing.Point(645, 0);
            this.m_panelNavigation.Size = new System.Drawing.Size(153, 28);
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
            this.m_panelCle.Location = new System.Drawing.Point(558, 0);
            this.m_panelCle.Size = new System.Drawing.Size(87, 28);
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
            this.m_txtLibelle.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtLibelle, true);
            this.m_txtLibelle.Location = new System.Drawing.Point(148, 8);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(382, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Libelle]";
            // 
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.m_TextComment);
            this.c2iPanelOmbre4.Controls.Add(this.m_lblLabel);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.Controls.Add(this.label2);
            this.c2iPanelOmbre4.Controls.Add(this.m_chkParentObligatoire);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iPanelOmbre4, false);
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(12, 43);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(638, 125);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // m_TextComment
            // 
            this.m_TextComment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_TextComment.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_TextComment, "Commentaire");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_TextComment, true);
            this.m_TextComment.Location = new System.Drawing.Point(148, 49);
            this.m_TextComment.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_TextComment, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_TextComment, "");
            this.m_TextComment.Multiline = true;
            this.m_TextComment.Name = "m_TextComment";
            this.m_TextComment.Size = new System.Drawing.Size(382, 52);
            this.m_extStyle.SetStyleBackColor(this.m_TextComment, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_TextComment, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_TextComment.TabIndex = 0;
            this.m_TextComment.Text = "[Commentaire]";
            // 
            // m_lblLabel
            // 
            this.m_lblLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_lblLabel.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_lblLabel, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblLabel, false);
            this.m_lblLabel.Location = new System.Drawing.Point(8, 11);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblLabel, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblLabel, "");
            this.m_lblLabel.Name = "m_lblLabel";
            this.m_lblLabel.Size = new System.Drawing.Size(99, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblLabel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblLabel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblLabel.TabIndex = 4005;
            this.m_lblLabel.Text = "Site type label: |170";
            // 
            // label2
            // 
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label2, false);
            this.label2.Location = new System.Drawing.Point(8, 53);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 23);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4007;
            this.label2.Text = "Comments|51";
            // 
            // m_chkParentObligatoire
            // 
            this.m_chkParentObligatoire.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkParentObligatoire, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_chkParentObligatoire, false);
            this.m_chkParentObligatoire.Location = new System.Drawing.Point(148, 31);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkParentObligatoire, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkParentObligatoire, "");
            this.m_chkParentObligatoire.Name = "m_chkParentObligatoire";
            this.m_chkParentObligatoire.Size = new System.Drawing.Size(236, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkParentObligatoire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkParentObligatoire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkParentObligatoire.TabIndex = 4006;
            this.m_chkParentObligatoire.Text = "Sites of this type must have a parent site|746";
            this.m_chkParentObligatoire.UseVisualStyleBackColor = true;
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
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_TabControl, false);
            this.m_TabControl.Location = new System.Drawing.Point(12, 174);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_TabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_TabControl, "");
            this.m_TabControl.Name = "m_TabControl";
            this.m_TabControl.Ombre = true;
            this.m_TabControl.PositionTop = true;
            this.m_TabControl.SelectedIndex = 0;
            this.m_TabControl.SelectedTab = this.pageFormulaires;
            this.m_TabControl.Size = new System.Drawing.Size(818, 366);
            this.m_extStyle.SetStyleBackColor(this.m_TabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_TabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_TabControl.TabIndex = 4004;
            this.m_TabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.pageFormulaires,
            this.pageDependences,
            this.pageEOs,
            this.pageChampsCustom,
            this.pageOptions,
            this.pageContraintes,
            this.pageTypesTableParametrables});
            this.m_TabControl.TextColor = System.Drawing.Color.Black;
            // 
            // pageDependences
            // 
            this.pageDependences.Controls.Add(this.m_splitContainer);
            this.m_extLinkField.SetLinkField(this.pageDependences, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.pageDependences, false);
            this.pageDependences.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pageDependences, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pageDependences, "");
            this.pageDependences.Name = "pageDependences";
            this.pageDependences.Selected = false;
            this.pageDependences.Size = new System.Drawing.Size(802, 325);
            this.m_extStyle.SetStyleBackColor(this.pageDependences, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pageDependences, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pageDependences.TabIndex = 11;
            this.pageDependences.Title = "Dependencies|236";
            // 
            // m_splitContainer
            // 
            this.m_splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_splitContainer, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_splitContainer, false);
            this.m_splitContainer.Location = new System.Drawing.Point(3, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_splitContainer, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_splitContainer, "");
            this.m_splitContainer.Name = "m_splitContainer";
            // 
            // m_splitContainer.Panel1
            // 
            this.m_splitContainer.Panel1.Controls.Add(this.m_labelGauche);
            this.m_splitContainer.Panel1.Controls.Add(this.m_panelTypeContenu);
            this.m_extLinkField.SetLinkField(this.m_splitContainer.Panel1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_splitContainer.Panel1, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_splitContainer.Panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_splitContainer.Panel1, "");
            this.m_extStyle.SetStyleBackColor(this.m_splitContainer.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainer.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_splitContainer.Panel2
            // 
            this.m_splitContainer.Panel2.Controls.Add(this.m_labelDroite);
            this.m_splitContainer.Panel2.Controls.Add(this.m_panelTypeContenant);
            this.m_extLinkField.SetLinkField(this.m_splitContainer.Panel2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_splitContainer.Panel2, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_splitContainer.Panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_splitContainer.Panel2, "");
            this.m_extStyle.SetStyleBackColor(this.m_splitContainer.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainer.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_splitContainer.Size = new System.Drawing.Size(796, 319);
            this.m_splitContainer.SplitterDistance = 396;
            this.m_extStyle.SetStyleBackColor(this.m_splitContainer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_splitContainer.TabIndex = 3;
            // 
            // m_labelGauche
            // 
            this.m_labelGauche.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_labelGauche, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_labelGauche, false);
            this.m_labelGauche.Location = new System.Drawing.Point(18, 16);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_labelGauche, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_labelGauche, "");
            this.m_labelGauche.Name = "m_labelGauche";
            this.m_labelGauche.Size = new System.Drawing.Size(91, 15);
            this.m_extStyle.SetStyleBackColor(this.m_labelGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_labelGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_labelGauche.TabIndex = 2;
            this.m_labelGauche.Text = "Can include|237";
            // 
            // m_panelTypeContenu
            // 
            this.m_panelTypeContenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelTypeContenu.Columns.AddRange(new sc2i.win32.common.ListViewAutoFilledColumn[] {
            this.listViewAutoFilledColumn1});
            this.m_panelTypeContenu.EnableCustomisation = true;
            this.m_panelTypeContenu.ExclusionParException = false;
            this.m_extLinkField.SetLinkField(this.m_panelTypeContenu, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelTypeContenu, false);
            this.m_panelTypeContenu.Location = new System.Drawing.Point(10, 32);
            this.m_panelTypeContenu.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelTypeContenu, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelTypeContenu, "");
            this.m_panelTypeContenu.Name = "m_panelTypeContenu";
            this.m_panelTypeContenu.Size = new System.Drawing.Size(383, 280);
            this.m_extStyle.SetStyleBackColor(this.m_panelTypeContenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelTypeContenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelTypeContenu.TabIndex = 0;
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "Libelle";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0D;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Label|50";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 175;
            // 
            // m_labelDroite
            // 
            this.m_labelDroite.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_labelDroite, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_labelDroite, false);
            this.m_labelDroite.Location = new System.Drawing.Point(12, 16);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_labelDroite, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_labelDroite, "");
            this.m_labelDroite.Name = "m_labelDroite";
            this.m_labelDroite.Size = new System.Drawing.Size(111, 15);
            this.m_extStyle.SetStyleBackColor(this.m_labelDroite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_labelDroite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_labelDroite.TabIndex = 2;
            this.m_labelDroite.Text = "Can be incuded|238";
            // 
            // m_panelTypeContenant
            // 
            this.m_panelTypeContenant.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelTypeContenant.Columns.AddRange(new sc2i.win32.common.ListViewAutoFilledColumn[] {
            this.listViewAutoFilledColumn2});
            this.m_panelTypeContenant.EnableCustomisation = true;
            this.m_panelTypeContenant.ExclusionParException = false;
            this.m_extLinkField.SetLinkField(this.m_panelTypeContenant, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelTypeContenant, false);
            this.m_panelTypeContenant.Location = new System.Drawing.Point(3, 32);
            this.m_panelTypeContenant.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelTypeContenant, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelTypeContenant, "");
            this.m_panelTypeContenant.Name = "m_panelTypeContenant";
            this.m_panelTypeContenant.Size = new System.Drawing.Size(390, 280);
            this.m_extStyle.SetStyleBackColor(this.m_panelTypeContenant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelTypeContenant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelTypeContenant.TabIndex = 1;
            // 
            // listViewAutoFilledColumn2
            // 
            this.listViewAutoFilledColumn2.Field = "Libelle";
            this.listViewAutoFilledColumn2.PrecisionWidth = 0D;
            this.listViewAutoFilledColumn2.ProportionnalSize = false;
            this.listViewAutoFilledColumn2.Text = "Label|50";
            this.listViewAutoFilledColumn2.Visible = true;
            this.listViewAutoFilledColumn2.Width = 172;
            // 
            // pageEOs
            // 
            this.pageEOs.Controls.Add(this.m_panelEOS);
            this.m_extLinkField.SetLinkField(this.pageEOs, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.pageEOs, false);
            this.pageEOs.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pageEOs, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pageEOs, "CEO");
            this.pageEOs.Name = "pageEOs";
            this.pageEOs.Selected = false;
            this.pageEOs.Size = new System.Drawing.Size(802, 325);
            this.m_extStyle.SetStyleBackColor(this.pageEOs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pageEOs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pageEOs.TabIndex = 15;
            this.pageEOs.Title = "Organizational entities|53";
            // 
            // m_panelEOS
            // 
            this.m_panelEOS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelEOS, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelEOS, false);
            this.m_panelEOS.Location = new System.Drawing.Point(0, 0);
            this.m_panelEOS.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEOS, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelEOS, "");
            this.m_panelEOS.Name = "m_panelEOS";
            this.m_panelEOS.Size = new System.Drawing.Size(802, 325);
            this.m_extStyle.SetStyleBackColor(this.m_panelEOS, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEOS, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEOS.TabIndex = 1;
            // 
            // pageChampsCustom
            // 
            this.pageChampsCustom.Controls.Add(this.m_panelEditChamps);
            this.m_extLinkField.SetLinkField(this.pageChampsCustom, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.pageChampsCustom, false);
            this.pageChampsCustom.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pageChampsCustom, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pageChampsCustom, "");
            this.pageChampsCustom.Name = "pageChampsCustom";
            this.pageChampsCustom.Selected = false;
            this.pageChampsCustom.Size = new System.Drawing.Size(802, 325);
            this.m_extStyle.SetStyleBackColor(this.pageChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pageChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pageChampsCustom.TabIndex = 12;
            this.pageChampsCustom.Title = "Custom fields|198";
            // 
            // m_panelEditChamps
            // 
            this.m_panelEditChamps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelEditChamps.AvecAffectationDirecteDeChamps = false;
            this.m_extLinkField.SetLinkField(this.m_panelEditChamps, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelEditChamps, false);
            this.m_panelEditChamps.Location = new System.Drawing.Point(3, 3);
            this.m_panelEditChamps.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEditChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelEditChamps, "");
            this.m_panelEditChamps.Name = "m_panelEditChamps";
            this.m_panelEditChamps.Size = new System.Drawing.Size(796, 322);
            this.m_extStyle.SetStyleBackColor(this.m_panelEditChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEditChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEditChamps.TabIndex = 0;
            // 
            // pageOptions
            // 
            this.pageOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pageOptions.Controls.Add(this.m_PanelSplitContainer);
            this.pageOptions.Controls.Add(this.m_cmbTypeEntitesNivZero);
            this.pageOptions.Controls.Add(this.m_lblTypeEOCoor);
            this.m_extLinkField.SetLinkField(this.pageOptions, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.pageOptions, false);
            this.pageOptions.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pageOptions, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pageOptions, "ASYS_COOR");
            this.pageOptions.Name = "pageOptions";
            this.pageOptions.Selected = false;
            this.pageOptions.Size = new System.Drawing.Size(802, 325);
            this.m_extStyle.SetStyleBackColor(this.pageOptions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pageOptions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pageOptions.TabIndex = 13;
            this.pageOptions.Title = "Options|30036";
            // 
            // m_PanelSplitContainer
            // 
            this.m_PanelSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_PanelSplitContainer, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_PanelSplitContainer, false);
            this.m_PanelSplitContainer.Location = new System.Drawing.Point(3, 35);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_PanelSplitContainer, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_PanelSplitContainer, "");
            this.m_PanelSplitContainer.Name = "m_PanelSplitContainer";
            this.m_PanelSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // m_PanelSplitContainer.Panel1
            // 
            this.m_PanelSplitContainer.Panel1.Controls.Add(this.m_panelSystemeCoordonnees);
            this.m_extLinkField.SetLinkField(this.m_PanelSplitContainer.Panel1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_PanelSplitContainer.Panel1, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_PanelSplitContainer.Panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_PanelSplitContainer.Panel1, "");
            this.m_extStyle.SetStyleBackColor(this.m_PanelSplitContainer.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_PanelSplitContainer.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_PanelSplitContainer.Panel2
            // 
            this.m_PanelSplitContainer.Panel2.Controls.Add(this.m_panelSymbole);
            this.m_extLinkField.SetLinkField(this.m_PanelSplitContainer.Panel2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_PanelSplitContainer.Panel2, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_PanelSplitContainer.Panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_PanelSplitContainer.Panel2, "");
            this.m_extStyle.SetStyleBackColor(this.m_PanelSplitContainer.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_PanelSplitContainer.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_PanelSplitContainer.Size = new System.Drawing.Size(785, 165);
            this.m_PanelSplitContainer.SplitterDistance = 94;
            this.m_extStyle.SetStyleBackColor(this.m_PanelSplitContainer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_PanelSplitContainer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_PanelSplitContainer.TabIndex = 4012;
            // 
            // m_panelSystemeCoordonnees
            // 
            this.m_panelSystemeCoordonnees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelSystemeCoordonnees, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelSystemeCoordonnees, false);
            this.m_panelSystemeCoordonnees.Location = new System.Drawing.Point(0, 0);
            this.m_panelSystemeCoordonnees.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelSystemeCoordonnees, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelSystemeCoordonnees, "");
            this.m_panelSystemeCoordonnees.Name = "m_panelSystemeCoordonnees";
            this.m_panelSystemeCoordonnees.Size = new System.Drawing.Size(785, 94);
            this.m_extStyle.SetStyleBackColor(this.m_panelSystemeCoordonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelSystemeCoordonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelSystemeCoordonnees.TabIndex = 0;
            // 
            // m_panelSymbole
            // 
            this.m_panelSymbole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelSymbole, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelSymbole, false);
            this.m_panelSymbole.Location = new System.Drawing.Point(0, 0);
            this.m_panelSymbole.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelSymbole, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelSymbole, "");
            this.m_panelSymbole.Name = "m_panelSymbole";
            this.m_panelSymbole.Size = new System.Drawing.Size(785, 67);
            this.m_extStyle.SetStyleBackColor(this.m_panelSymbole, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelSymbole, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelSymbole.TabIndex = 0;
            // 
            // m_cmbTypeEntitesNivZero
            // 
            this.m_cmbTypeEntitesNivZero.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbTypeEntitesNivZero.ComportementLinkStd = true;
            this.m_cmbTypeEntitesNivZero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTypeEntitesNivZero.ElementSelectionne = null;
            this.m_cmbTypeEntitesNivZero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbTypeEntitesNivZero.FormattingEnabled = true;
            this.m_cmbTypeEntitesNivZero.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbTypeEntitesNivZero, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbTypeEntitesNivZero, false);
            this.m_cmbTypeEntitesNivZero.LinkProperty = "";
            this.m_cmbTypeEntitesNivZero.ListDonnees = null;
            this.m_cmbTypeEntitesNivZero.Location = new System.Drawing.Point(229, 8);
            this.m_cmbTypeEntitesNivZero.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbTypeEntitesNivZero, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbTypeEntitesNivZero, "");
            this.m_cmbTypeEntitesNivZero.Name = "m_cmbTypeEntitesNivZero";
            this.m_cmbTypeEntitesNivZero.NullAutorise = true;
            this.m_cmbTypeEntitesNivZero.ProprieteAffichee = null;
            this.m_cmbTypeEntitesNivZero.ProprieteParentListeObjets = null;
            this.m_cmbTypeEntitesNivZero.SelectionneurParent = null;
            this.m_cmbTypeEntitesNivZero.Size = new System.Drawing.Size(278, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbTypeEntitesNivZero, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbTypeEntitesNivZero, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbTypeEntitesNivZero.TabIndex = 4010;
            this.m_cmbTypeEntitesNivZero.TextNull = "(empty)";
            this.m_cmbTypeEntitesNivZero.Tri = true;
            this.m_cmbTypeEntitesNivZero.TypeFormEdition = null;
            // 
            // m_lblTypeEOCoor
            // 
            this.m_lblTypeEOCoor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_lblTypeEOCoor.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_lblTypeEOCoor, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblTypeEOCoor, false);
            this.m_lblTypeEOCoor.Location = new System.Drawing.Point(13, 11);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblTypeEOCoor, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblTypeEOCoor, "");
            this.m_lblTypeEOCoor.Name = "m_lblTypeEOCoor";
            this.m_lblTypeEOCoor.Size = new System.Drawing.Size(215, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lblTypeEOCoor, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblTypeEOCoor, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblTypeEOCoor.TabIndex = 4005;
            this.m_lblTypeEOCoor.Text = "OE Type providing Coordinates|747";
            // 
            // pageContraintes
            // 
            this.pageContraintes.Controls.Add(this.m_panelListeContraintes);
            this.m_extLinkField.SetLinkField(this.pageContraintes, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.pageContraintes, false);
            this.pageContraintes.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pageContraintes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pageContraintes, "");
            this.pageContraintes.Name = "pageContraintes";
            this.pageContraintes.Selected = false;
            this.pageContraintes.Size = new System.Drawing.Size(802, 325);
            this.m_extStyle.SetStyleBackColor(this.pageContraintes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pageContraintes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pageContraintes.TabIndex = 14;
            this.pageContraintes.Title = "Constraints|255";
            // 
            // m_panelListeContraintes
            // 
            this.m_panelListeContraintes.AffectationsPourNouveauxElements = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("m_panelListeContraintes.AffectationsPourNouveauxElements")));
            this.m_panelListeContraintes.AllowArbre = true;
            this.m_panelListeContraintes.AllowCustomisation = true;
            this.m_panelListeContraintes.AllowSerializePreferences = true;
            glColumn1.ActiveControlItems = null;
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "ColumnLabel";
            glColumn1.Propriete = "Libelle";
            glColumn1.Text = "Label|50";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 300;
            this.m_panelListeContraintes.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1});
            this.m_panelListeContraintes.ContexteUtilisation = "";
            this.m_panelListeContraintes.ControlFiltreStandard = null;
            this.m_panelListeContraintes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelListeContraintes.ElementSelectionne = null;
            this.m_panelListeContraintes.EnableCustomisation = true;
            this.m_panelListeContraintes.FiltreDeBase = null;
            this.m_panelListeContraintes.FiltreDeBaseEnAjout = false;
            this.m_panelListeContraintes.FiltrePrefere = null;
            this.m_panelListeContraintes.FiltreRapide = null;
            this.m_panelListeContraintes.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panelListeContraintes, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelListeContraintes, false);
            this.m_panelListeContraintes.ListeObjets = null;
            this.m_panelListeContraintes.Location = new System.Drawing.Point(0, 0);
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
            this.m_panelListeContraintes.Size = new System.Drawing.Size(802, 325);
            this.m_extStyle.SetStyleBackColor(this.m_panelListeContraintes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListeContraintes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelListeContraintes.TabIndex = 1;
            this.m_panelListeContraintes.TrierAuClicSurEnteteColonne = true;
            this.m_panelListeContraintes.UseCheckBoxes = false;
            // 
            // pageTypesTableParametrables
            // 
            this.pageTypesTableParametrables.Controls.Add(this.m_tableParametrablesLstSelec);
            this.m_extLinkField.SetLinkField(this.pageTypesTableParametrables, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.pageTypesTableParametrables, false);
            this.pageTypesTableParametrables.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pageTypesTableParametrables, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pageTypesTableParametrables, "ATABLES_PARAM;CTYPES_TABLES");
            this.pageTypesTableParametrables.Name = "pageTypesTableParametrables";
            this.pageTypesTableParametrables.Selected = false;
            this.pageTypesTableParametrables.Size = new System.Drawing.Size(802, 325);
            this.m_extStyle.SetStyleBackColor(this.pageTypesTableParametrables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pageTypesTableParametrables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pageTypesTableParametrables.TabIndex = 16;
            this.pageTypesTableParametrables.Title = "Custom Table Types|1194";
            // 
            // m_tableParametrablesLstSelec
            // 
            this.m_tableParametrablesLstSelec.Columns.AddRange(new sc2i.win32.common.ListViewAutoFilledColumn[] {
            this.listViewAutoFilledColumn3});
            this.m_tableParametrablesLstSelec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tableParametrablesLstSelec.EnableCustomisation = true;
            this.m_tableParametrablesLstSelec.ExclusionParException = false;
            this.m_extLinkField.SetLinkField(this.m_tableParametrablesLstSelec, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_tableParametrablesLstSelec, false);
            this.m_tableParametrablesLstSelec.Location = new System.Drawing.Point(0, 0);
            this.m_tableParametrablesLstSelec.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tableParametrablesLstSelec, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_tableParametrablesLstSelec, "");
            this.m_tableParametrablesLstSelec.Name = "m_tableParametrablesLstSelec";
            this.m_tableParametrablesLstSelec.Size = new System.Drawing.Size(802, 325);
            this.m_extStyle.SetStyleBackColor(this.m_tableParametrablesLstSelec, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tableParametrablesLstSelec, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tableParametrablesLstSelec.TabIndex = 1;
            // 
            // listViewAutoFilledColumn3
            // 
            this.listViewAutoFilledColumn3.Field = "Libelle";
            this.listViewAutoFilledColumn3.PrecisionWidth = 10152D;
            this.listViewAutoFilledColumn3.ProportionnalSize = true;
            this.listViewAutoFilledColumn3.Text = "Label|50";
            this.listViewAutoFilledColumn3.Visible = true;
            this.listViewAutoFilledColumn3.Width = 10152;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label1, false);
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
            // pageFormulaires
            // 
            this.pageFormulaires.Controls.Add(this.m_panelChamps);
            this.m_extLinkField.SetLinkField(this.pageFormulaires, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.pageFormulaires, true);
            this.pageFormulaires.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pageFormulaires, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pageFormulaires, "");
            this.pageFormulaires.Name = "pageFormulaires";
            this.pageFormulaires.Size = new System.Drawing.Size(802, 325);
            this.m_extStyle.SetStyleBackColor(this.pageFormulaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pageFormulaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pageFormulaires.TabIndex = 17;
            this.pageFormulaires.Title = "Form|60";
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
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelChamps, false);
            this.m_panelChamps.Location = new System.Drawing.Point(0, 0);
            this.m_panelChamps.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelChamps, "");
            this.m_panelChamps.Name = "m_panelChamps";
            this.m_panelChamps.Ombre = false;
            this.m_panelChamps.PositionTop = true;
            this.m_panelChamps.Size = new System.Drawing.Size(802, 325);
            this.m_extStyle.SetStyleBackColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelChamps.TabIndex = 3;
            this.m_panelChamps.TextColor = System.Drawing.Color.Black;
            // 
            // CFormEditionTypeSite
            // 
            this.AffectationsPourNouvelElement = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("$this.AffectationsPourNouvelElement")));
            this.ClientSize = new System.Drawing.Size(830, 552);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.Controls.Add(this.m_TabControl);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionTypeSite";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_TabControl;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionTypeSite_OnInitPage);
            this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionTypeSite_OnMajChampsPage);
            this.Load += new System.EventHandler(this.CFormEditionTypeSite_Load);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.m_TabControl, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre4, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.c2iPanelOmbre4.ResumeLayout(false);
            this.c2iPanelOmbre4.PerformLayout();
            this.m_TabControl.ResumeLayout(false);
            this.m_TabControl.PerformLayout();
            this.pageDependences.ResumeLayout(false);
            this.m_splitContainer.Panel1.ResumeLayout(false);
            this.m_splitContainer.Panel1.PerformLayout();
            this.m_splitContainer.Panel2.ResumeLayout(false);
            this.m_splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_splitContainer)).EndInit();
            this.m_splitContainer.ResumeLayout(false);
            this.pageEOs.ResumeLayout(false);
            this.pageChampsCustom.ResumeLayout(false);
            this.pageOptions.ResumeLayout(false);
            this.m_PanelSplitContainer.Panel1.ResumeLayout(false);
            this.m_PanelSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_PanelSplitContainer)).EndInit();
            this.m_PanelSplitContainer.ResumeLayout(false);
            this.pageContraintes.ResumeLayout(false);
            this.pageTypesTableParametrables.ResumeLayout(false);
            this.pageFormulaires.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		public CFormEditionTypeSite()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
        public CFormEditionTypeSite(CTypeSite type_site)
            : base(type_site)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
        public CFormEditionTypeSite(CTypeSite type_site, CListeObjetsDonnees liste)
            : base(type_site, liste)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}

		//-------------------------------------------------------------------------
		private CTypeSite TypeSite
		{
			get	{ return (CTypeSite)ObjetEdite;	}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
            if (!result) return result;

			AffecterTitre(I.T("Site Type: |172") + TypeSite.Libelle);
            m_chkParentObligatoire.Checked = TypeSite.ParentObligatoire;

            // Visibilité de l'onglet Formulaires
            bool bHasFormulaires = false;
            foreach (IDefinisseurChampCustom def in TypeSite.DefinisseursDeChamps)
            {
                if (def.RelationsFormulaires.Length > 0)
                {
                    bHasFormulaires = true;
                    break;
                }
            }
            if (!bHasFormulaires)
            {
                if (m_TabControl.TabPages.Contains(pageFormulaires))
                    m_TabControl.TabPages.Remove(pageFormulaires);
            }
            else
            {
                if (!m_TabControl.TabPages.Contains(pageFormulaires))
                    m_TabControl.TabPages.Insert(0, pageFormulaires);
            }
			
            return result;
		}


        //-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
                    
            CResultAErreur result = base.MAJ_Champs();
            if (!result) return result;
 		
            TypeSite.ParentObligatoire = m_chkParentObligatoire.Checked;

            return result;
        }

        //-------------------------------------------------------------------------
        private CResultAErreur CFormEditionTypeSite_OnInitPage(object page)
        {
            CResultAErreur result = CResultAErreur.True;

            if (page == pageDependences)
            {
                // Filtre la liste des Types possibles pour ne pas afficher le Type en cours de création
                CListeObjetsDonnees liste_type = new CListeObjetsDonnees(TypeSite.ContexteDonnee, typeof(CTypeSite));
                liste_type.Filtre = new CFiltreData(CTypeSite.c_champId + " >= 0");

                m_panelTypeContenu.Init(
                    liste_type,
                    TypeSite.RelationTypesContenus,
                    TypeSite,
                    "TypeSiteContenant",
                    "TypeSiteContenu");
                m_panelTypeContenu.RemplirGrille();

                m_panelTypeContenant.Init(
                    liste_type,
                    TypeSite.RelationTypesContenants,
                    TypeSite,
                    "TypeSiteContenu",
                    "TypeSiteContenant");
                m_panelTypeContenant.RemplirGrille();
            }

            if (page == pageEOs)
            {
                //Initialisation du panel EOs
                m_panelEOS.Init(TypeSite);
            }
            if (page == pageChampsCustom)
            {
                m_panelEditChamps.InitPanel(
                    TypeSite,
                    typeof(CFormListeChampsCustom),
                    typeof(CFormListeFormulaires));
            }
            if (page == pageOptions)
            {
                //Chargement des Types d'entites organisationnelles de niveau 0
                CListeObjetsDonnees lstEntites = new CListeObjetsDonnees(TypeSite.ContexteDonnee, typeof(CTypeEntiteOrganisationnelle));
                lstEntites.Filtre = new CFiltreData(CTypeEntiteOrganisationnelle.c_champIdParent + " is null");
                m_cmbTypeEntitesNivZero.Init(lstEntites, "Libelle", typeof(CFormEditionTypeEntiteOrganisationnelle), true);
                m_cmbTypeEntitesNivZero.ElementSelectionne = TypeSite.TypeEntiteOrganisationnelleDeCoordonnee;

                m_panelSystemeCoordonnees.Init(TypeSite);
                m_panelSymbole.InitChamps(TypeSite,null);
            }
            if (page == pageContraintes)
            {
                m_panelListeContraintes.InitFromListeObjets(
                    TypeSite.Contraintes,
                    typeof(CContrainte),
                    typeof(CFormEditionContrainte),
                    TypeSite,
                    "TypeSite");
            }
            if (page == pageTypesTableParametrables)
            {
                m_tableParametrablesLstSelec.Init(
                    new CListeObjetsDonnees(TypeSite.ContexteDonnee, typeof(CTypeTableParametrable)),
                    TypeSite.RelationsTypesTableParametrables,
                    TypeSite,
                    "TypeSite",
                    "TypeTableParametrable");
                m_tableParametrablesLstSelec.RemplirGrille();
            }
            if (page == pageFormulaires)
            {
                m_panelChamps.ElementEdite = TypeSite;
            }

            return result;
        }

        //-------------------------------------------------------------------------
        private CResultAErreur CFormEditionTypeSite_OnMajChampsPage(object page)
        {
            CResultAErreur result = CResultAErreur.True;

            if (page == pageDependences)
            {
                m_panelTypeContenu.ApplyModifs();
                m_panelTypeContenant.ApplyModifs();
            }
            if (page == pageEOs)
            {
				result = m_panelEOS.MajChamps();
            }
            if (page == pageChampsCustom)
            {
                result = m_panelEditChamps.MAJ_Champs();
            }
            if (page == pageOptions)
            {
                TypeSite.TypeEntiteOrganisationnelleDeCoordonnee = (CTypeEntiteOrganisationnelle)m_cmbTypeEntitesNivZero.ElementSelectionne;
                result = m_panelSystemeCoordonnees.MajChamps();
                m_panelSymbole.MAJ_Champs();
            }
            if (page == pageContraintes)
            {
            }
            if (page == pageTypesTableParametrables)
            {
                m_tableParametrablesLstSelec.ApplyModifs();
            }
            if (page == pageFormulaires)
                result = m_panelChamps.MAJ_Champs();

            return result;
        }

        private void CFormEditionTypeSite_Load(object sender, EventArgs e)
        {
            m_extModulesAssociator.AppliquerConfiguration(CTimosApp.ConfigurationModules);
        }

  /*      private void m_radioSymboleBib_CheckedChanged(object sender, EventArgs e)
        {
            m_cmbSymboleBib.Enabled = true;
            InitSymbolesBibliotheque();
            m_linkEditSymbole.Enabled = false;
        }

        private void m_radioSymbolePropre_CheckedChanged(object sender, EventArgs e)
        {
            m_cmbSymboleBib.Enabled = false;
            m_cmbSymboleBib.ElementSelectionne = null;
            m_linkEditSymbole.Enabled = true;
        }

        private void m_linkEditSymbole_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (m_radioSymbolePropre.Checked)
            {

                if (TypeSite.SymbolePropre == null)
                {
                    TypeSite.SymboleDeBibliotheque = null;
                    CSymbole sym = new CSymbole(TypeSite.ContexteDonnee);
                    sym.CreateNewInCurrentContexte();
                    TypeSite.SymbolePropre = sym;


                }

                C2iSymbole symboleEdite = CFormEditeurSymbolePopup.EditeSymbole(TypeSite.SymbolePropre.Symbole, typeof(CSite));

                if (symboleEdite != null)
                    TypeSite.SymbolePropre.Symbole = symboleEdite;





            }
        }


        */
	}
}

