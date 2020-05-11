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

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CTypeStock))]
	public class CFormEditionTypeStock : CFormEditionStdTimos, IFormNavigable
	{
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre m_panTop;
        private C2iTabControl m_tabControl;
        private Crownwood.Magic.Controls.TabPage m_pageTypesEqpt;
        private Panel m_panelTypeEqpt;
        private C2iTextBoxNumerique m_txtNumStockOptimal;
        private GroupBox groupBox1;
        private C2iTextBoxNumerique m_txtNumStockCritique;
        private C2iTextBoxNumerique m_txtNumStockAlerte;
        private Label label7;
        private Label label13;
        private Label label12;
        private Label label10;
        private ListViewAutoFilled m_listeTypesEquipements;
        private ListViewAutoFilledColumn listViewAutoFilledColumn5;
        private C2iTextBoxSelectionne m_txtSelectTypeEquipement;
        private Label label11;
        private CWndLinkStd m_lnkAddTypeEquipement;
        private CWndLinkStd m_lnkSupprimeTypeEquipement;
        private CGestionnaireEditionSousObjetDonnee m_gestionnaireEditionRelTypeEquipement;
        private CExtLinkField m_linkFieldTypeEqpt;
        private Crownwood.Magic.Controls.TabPage m_pageDefinissionFiches;
        private timos.win32.composants.CPanelEditDefinisseurChampsCustom m_panelDefinisseurChamps;
        private Crownwood.Magic.Controls.TabPage m_pageFormulaires;
        private sc2i.win32.data.dynamic.CPanelChampsCustom m_panelChamps;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionTypeStock()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionTypeStock(CTypeStock TypeStock)
			:base(TypeStock)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionTypeStock(CTypeStock TypeStock, CListeObjetsDonnees liste)
			:base(TypeStock, liste)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionTypeStock));
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.m_panTop = new sc2i.win32.common.C2iPanelOmbre();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageTypesEqpt = new Crownwood.Magic.Controls.TabPage();
            this.m_lnkSupprimeTypeEquipement = new sc2i.win32.common.CWndLinkStd();
            this.m_panelTypeEqpt = new System.Windows.Forms.Panel();
            this.m_txtNumStockOptimal = new sc2i.win32.common.C2iTextBoxNumerique();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_txtNumStockCritique = new sc2i.win32.common.C2iTextBoxNumerique();
            this.m_txtNumStockAlerte = new sc2i.win32.common.C2iTextBoxNumerique();
            this.label7 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.m_listeTypesEquipements = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn5 = ((sc2i.win32.common.ListViewAutoFilledColumn)(new sc2i.win32.common.ListViewAutoFilledColumn()));
            this.m_txtSelectTypeEquipement = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.label11 = new System.Windows.Forms.Label();
            this.m_lnkAddTypeEquipement = new sc2i.win32.common.CWndLinkStd();
            this.m_pageDefinissionFiches = new Crownwood.Magic.Controls.TabPage();
            this.m_panelDefinisseurChamps = new timos.win32.composants.CPanelEditDefinisseurChampsCustom();
            this.m_gestionnaireEditionRelTypeEquipement = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.m_linkFieldTypeEqpt = new sc2i.win32.common.CExtLinkField();
            this.m_pageFormulaires = new Crownwood.Magic.Controls.TabPage();
            this.m_panelChamps = new sc2i.win32.data.dynamic.CPanelChampsCustom();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.m_panTop.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.m_pageTypesEqpt.SuspendLayout();
            this.m_panelTypeEqpt.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.m_pageDefinissionFiches.SuspendLayout();
            this.m_pageFormulaires.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnAnnulerModifications
            // 
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_extLinkField.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnAnnulerModifications, false);
            this.m_linkFieldTypeEqpt.SetLinkFieldAutoUpdate(this.m_btnAnnulerModifications, true);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAnnulerModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnValiderModifications
            // 
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_btnValiderModifications, "");
            this.m_extLinkField.SetLinkField(this.m_btnValiderModifications, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnValiderModifications, false);
            this.m_linkFieldTypeEqpt.SetLinkFieldAutoUpdate(this.m_btnValiderModifications, true);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnValiderModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnSupprimerObjet
            // 
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_btnSupprimerObjet, "");
            this.m_extLinkField.SetLinkField(this.m_btnSupprimerObjet, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnSupprimerObjet, false);
            this.m_linkFieldTypeEqpt.SetLinkFieldAutoUpdate(this.m_btnSupprimerObjet, true);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnSupprimerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnEditerObjet
            // 
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_btnEditerObjet, "");
            this.m_extLinkField.SetLinkField(this.m_btnEditerObjet, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnEditerObjet, false);
            this.m_linkFieldTypeEqpt.SetLinkFieldAutoUpdate(this.m_btnEditerObjet, true);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnEditerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelNavigation
            // 
            this.m_extLinkField.SetLinkField(this.m_panelNavigation, "");
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_panelNavigation, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelNavigation, false);
            this.m_linkFieldTypeEqpt.SetLinkFieldAutoUpdate(this.m_panelNavigation, true);
            this.m_panelNavigation.Location = new System.Drawing.Point(623, 0);
            this.m_panelNavigation.Size = new System.Drawing.Size(175, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_lblNbListes
            // 
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_lblNbListes, "");
            this.m_extLinkField.SetLinkField(this.m_lblNbListes, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblNbListes, false);
            this.m_linkFieldTypeEqpt.SetLinkFieldAutoUpdate(this.m_lblNbListes, true);
            this.m_extStyle.SetStyleBackColor(this.m_lblNbListes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblNbListes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnPrecedent
            // 
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_btnPrecedent, "");
            this.m_extLinkField.SetLinkField(this.m_btnPrecedent, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnPrecedent, false);
            this.m_linkFieldTypeEqpt.SetLinkFieldAutoUpdate(this.m_btnPrecedent, true);
            this.m_extStyle.SetStyleBackColor(this.m_btnPrecedent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnPrecedent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnSuivant
            // 
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_btnSuivant, "");
            this.m_extLinkField.SetLinkField(this.m_btnSuivant, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnSuivant, false);
            this.m_linkFieldTypeEqpt.SetLinkFieldAutoUpdate(this.m_btnSuivant, true);
            this.m_extStyle.SetStyleBackColor(this.m_btnSuivant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSuivant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnAjout
            // 
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_btnAjout, "");
            this.m_extLinkField.SetLinkField(this.m_btnAjout, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnAjout, false);
            this.m_linkFieldTypeEqpt.SetLinkFieldAutoUpdate(this.m_btnAjout, true);
            this.m_extStyle.SetStyleBackColor(this.m_btnAjout, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAjout, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_lblId
            // 
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_lblId, "");
            this.m_extLinkField.SetLinkField(this.m_lblId, "Id");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblId, true);
            this.m_linkFieldTypeEqpt.SetLinkFieldAutoUpdate(this.m_lblId, true);
            this.m_extStyle.SetStyleBackColor(this.m_lblId, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblId, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelCle
            // 
            this.m_extLinkField.SetLinkField(this.m_panelCle, "");
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_panelCle, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelCle, false);
            this.m_linkFieldTypeEqpt.SetLinkFieldAutoUpdate(this.m_panelCle, true);
            this.m_panelCle.Location = new System.Drawing.Point(515, 0);
            this.m_panelCle.Size = new System.Drawing.Size(108, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_extLinkField.SetLinkField(this.m_panelMenu, "");
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_panelMenu, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelMenu, false);
            this.m_linkFieldTypeEqpt.SetLinkFieldAutoUpdate(this.m_panelMenu, false);
            this.m_panelMenu.Size = new System.Drawing.Size(830, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnHistorique
            // 
            this.m_extLinkField.SetLinkField(this.m_btnHistorique, "");
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_btnHistorique, "");
            this.m_linkFieldTypeEqpt.SetLinkFieldAutoUpdate(this.m_btnHistorique, true);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnHistorique, false);
            this.m_extStyle.SetStyleBackColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_imageCle
            // 
            this.m_extLinkField.SetLinkField(this.m_imageCle, "");
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_imageCle, "");
            this.m_linkFieldTypeEqpt.SetLinkFieldAutoUpdate(this.m_imageCle, true);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_imageCle, false);
            this.m_extStyle.SetStyleBackColor(this.m_imageCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_imageCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnChercherObjet
            // 
            this.m_extLinkField.SetLinkField(this.m_btnChercherObjet, "");
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_btnChercherObjet, "");
            this.m_linkFieldTypeEqpt.SetLinkFieldAutoUpdate(this.m_btnChercherObjet, true);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnChercherObjet, false);
            this.m_extStyle.SetStyleBackColor(this.m_btnChercherObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnChercherObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.m_linkFieldTypeEqpt.SetLinkField(this.label1, "");
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label1, false);
            this.m_linkFieldTypeEqpt.SetLinkFieldAutoUpdate(this.label1, false);
            this.label1.Location = new System.Drawing.Point(16, 12);
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
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_txtLibelle, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtLibelle, true);
            this.m_linkFieldTypeEqpt.SetLinkFieldAutoUpdate(this.m_txtLibelle, false);
            this.m_txtLibelle.Location = new System.Drawing.Point(104, 8);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(308, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Libelle]";
            // 
            // m_panTop
            // 
            this.m_panTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panTop.Controls.Add(this.label1);
            this.m_panTop.Controls.Add(this.m_txtLibelle);
            this.m_panTop.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panTop, "");
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_panTop, "");
            this.m_linkFieldTypeEqpt.SetLinkFieldAutoUpdate(this.m_panTop, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panTop, false);
            this.m_panTop.Location = new System.Drawing.Point(8, 52);
            this.m_panTop.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panTop, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panTop, "");
            this.m_panTop.Name = "m_panTop";
            this.m_panTop.Size = new System.Drawing.Size(440, 56);
            this.m_extStyle.SetStyleBackColor(this.m_panTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panTop.TabIndex = 0;
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
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_tabControl, "");
            this.m_extLinkField.SetLinkField(this.m_tabControl, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_tabControl, false);
            this.m_linkFieldTypeEqpt.SetLinkFieldAutoUpdate(this.m_tabControl, false);
            this.m_tabControl.Location = new System.Drawing.Point(8, 114);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.m_pageFormulaires;
            this.m_tabControl.Size = new System.Drawing.Size(822, 405);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4004;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageFormulaires,
            this.m_pageTypesEqpt,
            this.m_pageDefinissionFiches});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageTypesEqpt
            // 
            this.m_pageTypesEqpt.Controls.Add(this.m_lnkSupprimeTypeEquipement);
            this.m_pageTypesEqpt.Controls.Add(this.m_panelTypeEqpt);
            this.m_pageTypesEqpt.Controls.Add(this.m_listeTypesEquipements);
            this.m_pageTypesEqpt.Controls.Add(this.m_txtSelectTypeEquipement);
            this.m_pageTypesEqpt.Controls.Add(this.label11);
            this.m_pageTypesEqpt.Controls.Add(this.m_lnkAddTypeEquipement);
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_pageTypesEqpt, "");
            this.m_extLinkField.SetLinkField(this.m_pageTypesEqpt, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageTypesEqpt, false);
            this.m_linkFieldTypeEqpt.SetLinkFieldAutoUpdate(this.m_pageTypesEqpt, false);
            this.m_pageTypesEqpt.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageTypesEqpt, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageTypesEqpt, "");
            this.m_pageTypesEqpt.Name = "m_pageTypesEqpt";
            this.m_pageTypesEqpt.Selected = false;
            this.m_pageTypesEqpt.Size = new System.Drawing.Size(806, 364);
            this.m_extStyle.SetStyleBackColor(this.m_pageTypesEqpt, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageTypesEqpt, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageTypesEqpt.TabIndex = 10;
            this.m_pageTypesEqpt.Title = "Equipment type behavior|751";
            // 
            // m_lnkSupprimeTypeEquipement
            // 
            this.m_lnkSupprimeTypeEquipement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkSupprimeTypeEquipement.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkSupprimeTypeEquipement.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_lnkSupprimeTypeEquipement.CustomImage")));
            this.m_lnkSupprimeTypeEquipement.CustomText = "Remove";
            this.m_lnkSupprimeTypeEquipement.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkSupprimeTypeEquipement, "");
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_lnkSupprimeTypeEquipement, "");
            this.m_linkFieldTypeEqpt.SetLinkFieldAutoUpdate(this.m_lnkSupprimeTypeEquipement, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkSupprimeTypeEquipement, false);
            this.m_lnkSupprimeTypeEquipement.Location = new System.Drawing.Point(19, 333);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkSupprimeTypeEquipement, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkSupprimeTypeEquipement, "");
            this.m_lnkSupprimeTypeEquipement.Name = "m_lnkSupprimeTypeEquipement";
            this.m_lnkSupprimeTypeEquipement.ShortMode = false;
            this.m_lnkSupprimeTypeEquipement.Size = new System.Drawing.Size(104, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSupprimeTypeEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSupprimeTypeEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSupprimeTypeEquipement.TabIndex = 15;
            this.m_lnkSupprimeTypeEquipement.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkSupprimeTypeEquipement.LinkClicked += new System.EventHandler(this.m_lnkSupprimeTypeEquipement_LinkClicked);
            // 
            // m_panelTypeEqpt
            // 
            this.m_panelTypeEqpt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelTypeEqpt.Controls.Add(this.m_txtNumStockOptimal);
            this.m_panelTypeEqpt.Controls.Add(this.groupBox1);
            this.m_panelTypeEqpt.Controls.Add(this.label12);
            this.m_panelTypeEqpt.Controls.Add(this.label10);
            this.m_extLinkField.SetLinkField(this.m_panelTypeEqpt, "");
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_panelTypeEqpt, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelTypeEqpt, false);
            this.m_linkFieldTypeEqpt.SetLinkFieldAutoUpdate(this.m_panelTypeEqpt, false);
            this.m_panelTypeEqpt.Location = new System.Drawing.Point(612, 10);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelTypeEqpt, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelTypeEqpt, "");
            this.m_panelTypeEqpt.Name = "m_panelTypeEqpt";
            this.m_panelTypeEqpt.Size = new System.Drawing.Size(178, 334);
            this.m_extStyle.SetStyleBackColor(this.m_panelTypeEqpt, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelTypeEqpt, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelTypeEqpt.TabIndex = 14;
            this.m_panelTypeEqpt.Visible = false;
            // 
            // m_txtNumStockOptimal
            // 
            this.m_txtNumStockOptimal.Arrondi = 0;
            this.m_txtNumStockOptimal.DecimalAutorise = false;
            this.m_txtNumStockOptimal.DoubleValue = null;
            this.m_txtNumStockOptimal.EmptyText = "";
            this.m_txtNumStockOptimal.IntValue = null;
            this.m_extLinkField.SetLinkField(this.m_txtNumStockOptimal, "");
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_txtNumStockOptimal, "StockOptimal");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtNumStockOptimal, false);
            this.m_linkFieldTypeEqpt.SetLinkFieldAutoUpdate(this.m_txtNumStockOptimal, true);
            this.m_txtNumStockOptimal.Location = new System.Drawing.Point(100, 103);
            this.m_txtNumStockOptimal.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtNumStockOptimal, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtNumStockOptimal, "");
            this.m_txtNumStockOptimal.Name = "m_txtNumStockOptimal";
            this.m_txtNumStockOptimal.NullAutorise = true;
            this.m_txtNumStockOptimal.SelectAllOnEnter = true;
            this.m_txtNumStockOptimal.SeparateurMilliers = "";
            this.m_txtNumStockOptimal.Size = new System.Drawing.Size(68, 23);
            this.m_extStyle.SetStyleBackColor(this.m_txtNumStockOptimal, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtNumStockOptimal, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtNumStockOptimal.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.m_txtNumStockCritique);
            this.groupBox1.Controls.Add(this.m_txtNumStockAlerte);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label13);
            this.m_linkFieldTypeEqpt.SetLinkField(this.groupBox1, "");
            this.m_extLinkField.SetLinkField(this.groupBox1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.groupBox1, false);
            this.m_linkFieldTypeEqpt.SetLinkFieldAutoUpdate(this.groupBox1, false);
            this.groupBox1.Location = new System.Drawing.Point(0, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.groupBox1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.groupBox1, "");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(175, 71);
            this.m_extStyle.SetStyleBackColor(this.groupBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.groupBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Alerts|213";
            // 
            // m_txtNumStockCritique
            // 
            this.m_txtNumStockCritique.Arrondi = 0;
            this.m_txtNumStockCritique.DecimalAutorise = false;
            this.m_txtNumStockCritique.DoubleValue = null;
            this.m_txtNumStockCritique.EmptyText = "";
            this.m_txtNumStockCritique.IntValue = null;
            this.m_extLinkField.SetLinkField(this.m_txtNumStockCritique, "");
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_txtNumStockCritique, "StockCritique");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtNumStockCritique, false);
            this.m_linkFieldTypeEqpt.SetLinkFieldAutoUpdate(this.m_txtNumStockCritique, true);
            this.m_txtNumStockCritique.Location = new System.Drawing.Point(100, 40);
            this.m_txtNumStockCritique.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtNumStockCritique, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtNumStockCritique, "");
            this.m_txtNumStockCritique.Name = "m_txtNumStockCritique";
            this.m_txtNumStockCritique.NullAutorise = true;
            this.m_txtNumStockCritique.SelectAllOnEnter = true;
            this.m_txtNumStockCritique.SeparateurMilliers = "";
            this.m_txtNumStockCritique.Size = new System.Drawing.Size(68, 23);
            this.m_extStyle.SetStyleBackColor(this.m_txtNumStockCritique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtNumStockCritique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtNumStockCritique.TabIndex = 5;
            // 
            // m_txtNumStockAlerte
            // 
            this.m_txtNumStockAlerte.Arrondi = 0;
            this.m_txtNumStockAlerte.DecimalAutorise = false;
            this.m_txtNumStockAlerte.DoubleValue = null;
            this.m_txtNumStockAlerte.EmptyText = "";
            this.m_txtNumStockAlerte.IntValue = null;
            this.m_extLinkField.SetLinkField(this.m_txtNumStockAlerte, "");
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_txtNumStockAlerte, "StockAlerte");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtNumStockAlerte, false);
            this.m_linkFieldTypeEqpt.SetLinkFieldAutoUpdate(this.m_txtNumStockAlerte, true);
            this.m_txtNumStockAlerte.Location = new System.Drawing.Point(100, 17);
            this.m_txtNumStockAlerte.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtNumStockAlerte, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtNumStockAlerte, "");
            this.m_txtNumStockAlerte.Name = "m_txtNumStockAlerte";
            this.m_txtNumStockAlerte.NullAutorise = true;
            this.m_txtNumStockAlerte.SelectAllOnEnter = true;
            this.m_txtNumStockAlerte.SeparateurMilliers = "";
            this.m_txtNumStockAlerte.Size = new System.Drawing.Size(68, 23);
            this.m_extStyle.SetStyleBackColor(this.m_txtNumStockAlerte, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtNumStockAlerte, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtNumStockAlerte.TabIndex = 4;
            // 
            // label7
            // 
            this.m_linkFieldTypeEqpt.SetLinkField(this.label7, "");
            this.m_extLinkField.SetLinkField(this.label7, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label7, false);
            this.m_linkFieldTypeEqpt.SetLinkFieldAutoUpdate(this.label7, false);
            this.label7.Location = new System.Drawing.Point(6, 20);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label7, "");
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 17);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 1;
            this.label7.Text = "Alert threshold|210";
            // 
            // label13
            // 
            this.m_linkFieldTypeEqpt.SetLinkField(this.label13, "");
            this.m_extLinkField.SetLinkField(this.label13, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label13, false);
            this.m_linkFieldTypeEqpt.SetLinkFieldAutoUpdate(this.label13, false);
            this.label13.Location = new System.Drawing.Point(6, 43);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label13, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label13, "");
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 18);
            this.m_extStyle.SetStyleBackColor(this.label13, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label13, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label13.TabIndex = 3;
            this.label13.Text = "Critical threshold|211";
            // 
            // label12
            // 
            this.m_linkFieldTypeEqpt.SetLinkField(this.label12, "");
            this.m_extLinkField.SetLinkField(this.label12, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label12, false);
            this.m_linkFieldTypeEqpt.SetLinkFieldAutoUpdate(this.label12, false);
            this.label12.Location = new System.Drawing.Point(6, 106);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label12, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label12, "");
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 18);
            this.m_extStyle.SetStyleBackColor(this.label12, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label12, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label12.TabIndex = 2;
            this.label12.Text = "Optimal threshold|212";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_linkFieldTypeEqpt.SetLinkField(this.label10, "TypeEquipement.Libelle");
            this.m_extLinkField.SetLinkField(this.label10, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label10, false);
            this.m_linkFieldTypeEqpt.SetLinkFieldAutoUpdate(this.label10, true);
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label10, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label10, "");
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(178, 29);
            this.m_extStyle.SetStyleBackColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label10.TabIndex = 0;
            this.label10.Text = "[TypeEquipement.Libelle]";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_listeTypesEquipements
            // 
            this.m_listeTypesEquipements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_listeTypesEquipements.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn5});
            this.m_listeTypesEquipements.EnableCustomisation = true;
            this.m_listeTypesEquipements.FullRowSelect = true;
            this.m_listeTypesEquipements.HideSelection = false;
            this.m_extLinkField.SetLinkField(this.m_listeTypesEquipements, "");
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_listeTypesEquipements, "");
            this.m_linkFieldTypeEqpt.SetLinkFieldAutoUpdate(this.m_listeTypesEquipements, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_listeTypesEquipements, false);
            this.m_listeTypesEquipements.Location = new System.Drawing.Point(19, 59);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_listeTypesEquipements, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_listeTypesEquipements, "");
            this.m_listeTypesEquipements.MultiSelect = false;
            this.m_listeTypesEquipements.Name = "m_listeTypesEquipements";
            this.m_listeTypesEquipements.Size = new System.Drawing.Size(587, 268);
            this.m_extStyle.SetStyleBackColor(this.m_listeTypesEquipements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_listeTypesEquipements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_listeTypesEquipements.TabIndex = 12;
            this.m_listeTypesEquipements.UseCompatibleStateImageBehavior = false;
            this.m_listeTypesEquipements.View = System.Windows.Forms.View.Details;
            // 
            // listViewAutoFilledColumn5
            // 
            this.listViewAutoFilledColumn5.Field = "TypeEquipement.Libelle";
            this.listViewAutoFilledColumn5.PrecisionWidth = 0D;
            this.listViewAutoFilledColumn5.ProportionnalSize = false;
            this.listViewAutoFilledColumn5.Text = "Label|50";
            this.listViewAutoFilledColumn5.Visible = true;
            this.listViewAutoFilledColumn5.Width = 200;
            // 
            // m_txtSelectTypeEquipement
            // 
            this.m_txtSelectTypeEquipement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtSelectTypeEquipement.ElementSelectionne = null;
            this.m_txtSelectTypeEquipement.FonctionTextNull = null;
            this.m_txtSelectTypeEquipement.HasLink = true;
            this.m_txtSelectTypeEquipement.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_extLinkField.SetLinkField(this.m_txtSelectTypeEquipement, "");
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_txtSelectTypeEquipement, "");
            this.m_linkFieldTypeEqpt.SetLinkFieldAutoUpdate(this.m_txtSelectTypeEquipement, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtSelectTypeEquipement, false);
            this.m_txtSelectTypeEquipement.Location = new System.Drawing.Point(140, 10);
            this.m_txtSelectTypeEquipement.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectTypeEquipement, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtSelectTypeEquipement, "");
            this.m_txtSelectTypeEquipement.Name = "m_txtSelectTypeEquipement";
            this.m_txtSelectTypeEquipement.SelectedObject = null;
            this.m_txtSelectTypeEquipement.Size = new System.Drawing.Size(466, 21);
            this.m_txtSelectTypeEquipement.SpecificImage = null;
            this.m_extStyle.SetStyleBackColor(this.m_txtSelectTypeEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSelectTypeEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectTypeEquipement.TabIndex = 11;
            this.m_txtSelectTypeEquipement.TextNull = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.m_linkFieldTypeEqpt.SetLinkField(this.label11, "");
            this.m_extLinkField.SetLinkField(this.label11, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label11, false);
            this.m_linkFieldTypeEqpt.SetLinkFieldAutoUpdate(this.label11, false);
            this.label11.Location = new System.Drawing.Point(16, 14);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label11, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label11, "");
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 15);
            this.m_extStyle.SetStyleBackColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label11.TabIndex = 10;
            this.label11.Text = "Equipment type|194";
            // 
            // m_lnkAddTypeEquipement
            // 
            this.m_lnkAddTypeEquipement.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAddTypeEquipement.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_lnkAddTypeEquipement.CustomImage")));
            this.m_lnkAddTypeEquipement.CustomText = "Add";
            this.m_lnkAddTypeEquipement.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkAddTypeEquipement, "");
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_lnkAddTypeEquipement, "");
            this.m_linkFieldTypeEqpt.SetLinkFieldAutoUpdate(this.m_lnkAddTypeEquipement, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkAddTypeEquipement, false);
            this.m_lnkAddTypeEquipement.Location = new System.Drawing.Point(140, 37);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAddTypeEquipement, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAddTypeEquipement, "");
            this.m_lnkAddTypeEquipement.Name = "m_lnkAddTypeEquipement";
            this.m_lnkAddTypeEquipement.ShortMode = false;
            this.m_lnkAddTypeEquipement.Size = new System.Drawing.Size(104, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAddTypeEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAddTypeEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAddTypeEquipement.TabIndex = 13;
            this.m_lnkAddTypeEquipement.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAddTypeEquipement.LinkClicked += new System.EventHandler(this.m_lnkAddTypeEquipement_LinkClicked);
            // 
            // m_pageDefinissionFiches
            // 
            this.m_pageDefinissionFiches.Controls.Add(this.m_panelDefinisseurChamps);
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_pageDefinissionFiches, "");
            this.m_extLinkField.SetLinkField(this.m_pageDefinissionFiches, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageDefinissionFiches, false);
            this.m_linkFieldTypeEqpt.SetLinkFieldAutoUpdate(this.m_pageDefinissionFiches, false);
            this.m_pageDefinissionFiches.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageDefinissionFiches, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageDefinissionFiches, "");
            this.m_pageDefinissionFiches.Name = "m_pageDefinissionFiches";
            this.m_pageDefinissionFiches.Selected = false;
            this.m_pageDefinissionFiches.Size = new System.Drawing.Size(806, 364);
            this.m_extStyle.SetStyleBackColor(this.m_pageDefinissionFiches, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageDefinissionFiches, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageDefinissionFiches.TabIndex = 11;
            this.m_pageDefinissionFiches.Title = "Custom Forms|99";
            // 
            // m_panelDefinisseurChamps
            // 
            this.m_panelDefinisseurChamps.AvecAffectationDirecteDeChamps = false;
            this.m_panelDefinisseurChamps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_panelDefinisseurChamps, "");
            this.m_extLinkField.SetLinkField(this.m_panelDefinisseurChamps, "");
            this.m_linkFieldTypeEqpt.SetLinkFieldAutoUpdate(this.m_panelDefinisseurChamps, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelDefinisseurChamps, false);
            this.m_panelDefinisseurChamps.Location = new System.Drawing.Point(0, 0);
            this.m_panelDefinisseurChamps.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelDefinisseurChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelDefinisseurChamps, "");
            this.m_panelDefinisseurChamps.Name = "m_panelDefinisseurChamps";
            this.m_panelDefinisseurChamps.Size = new System.Drawing.Size(806, 364);
            this.m_extStyle.SetStyleBackColor(this.m_panelDefinisseurChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelDefinisseurChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelDefinisseurChamps.TabIndex = 2;
            // 
            // m_gestionnaireEditionRelTypeEquipement
            // 
            this.m_gestionnaireEditionRelTypeEquipement.ListeAssociee = this.m_listeTypesEquipements;
            this.m_gestionnaireEditionRelTypeEquipement.ObjetEdite = null;
            this.m_gestionnaireEditionRelTypeEquipement.InitChamp += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireEditionRelTypeEquipement_InitChamp);
            this.m_gestionnaireEditionRelTypeEquipement.MAJ_Champs += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireEditionRelTypeEquipement_MAJ_Champs);
            // 
            // m_linkFieldTypeEqpt
            // 
            this.m_linkFieldTypeEqpt.SourceTypeString = "";
            // 
            // m_pageFormulaires
            // 
            this.m_pageFormulaires.Controls.Add(this.m_panelChamps);
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_pageFormulaires, "");
            this.m_extLinkField.SetLinkField(this.m_pageFormulaires, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageFormulaires, true);
            this.m_linkFieldTypeEqpt.SetLinkFieldAutoUpdate(this.m_pageFormulaires, true);
            this.m_pageFormulaires.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageFormulaires, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageFormulaires, "");
            this.m_pageFormulaires.Name = "m_pageFormulaires";
            this.m_pageFormulaires.Size = new System.Drawing.Size(806, 364);
            this.m_extStyle.SetStyleBackColor(this.m_pageFormulaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageFormulaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageFormulaires.TabIndex = 12;
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
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_panelChamps, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelChamps, false);
            this.m_linkFieldTypeEqpt.SetLinkFieldAutoUpdate(this.m_panelChamps, true);
            this.m_panelChamps.Location = new System.Drawing.Point(0, 0);
            this.m_panelChamps.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelChamps, "");
            this.m_panelChamps.Name = "m_panelChamps";
            this.m_panelChamps.Ombre = false;
            this.m_panelChamps.PositionTop = true;
            this.m_panelChamps.Size = new System.Drawing.Size(806, 364);
            this.m_extStyle.SetStyleBackColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelChamps.TabIndex = 4;
            this.m_panelChamps.TextColor = System.Drawing.Color.Black;
            // 
            // CFormEditionTypeStock
            // 
            this.AffectationsPourNouvelElement = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("$this.AffectationsPourNouvelElement")));
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.m_panTop);
            this.m_linkFieldTypeEqpt.SetLinkField(this, "");
            this.m_extLinkField.SetLinkField(this, "");
            this.m_linkFieldTypeEqpt.SetLinkFieldAutoUpdate(this, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionTypeStock";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_tabControl;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionTypeStock_OnInitPage);
            this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionTypeStock_OnMajChampsPage);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.m_panTop, 0);
            this.Controls.SetChildIndex(this.m_tabControl, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.m_panTop.ResumeLayout(false);
            this.m_panTop.PerformLayout();
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.m_pageTypesEqpt.ResumeLayout(false);
            this.m_pageTypesEqpt.PerformLayout();
            this.m_panelTypeEqpt.ResumeLayout(false);
            this.m_panelTypeEqpt.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.m_pageDefinissionFiches.ResumeLayout(false);
            this.m_pageFormulaires.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CTypeStock TypeStock
		{
			get
			{
				return (CTypeStock)ObjetEdite;
			}
		}

		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
			AffecterTitre(I.T( "Stock Type|207")+" "+ TypeStock.Libelle);

            // Visibilité de l'onglet Formulaires
            bool bHasFormulaires = false;
            foreach (IDefinisseurChampCustom def in TypeStock.DefinisseursDeChamps)
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
        private void InitSelectTypeEquipement()
        {
            m_txtSelectTypeEquipement.Init<CTypeEquipement>(
                "Libelle",
                false);
        }

        //-------------------------------------------------------------------------
        private void InitListeTypesEquipements()
        {
            m_listeTypesEquipements.Items.Clear();

            foreach (CRelationTypeEquipement_TypeStock rel in TypeStock.RelationsTypesEquipements)
            {
                ListViewItem item = new ListViewItem();
                m_listeTypesEquipements.Items.Add(item);
                m_listeTypesEquipements.UpdateItemWithObject(item, rel);
            }
        }

		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();

            return result;
        }

        //-------------------------------------------------------------------------
        private void m_gestionnaireEditionRelTypeEquipement_InitChamp(object sender, CObjetDonneeResultEventArgs args)
        {
            if (args.Objet == null)
            {
                m_panelTypeEqpt.Visible = false;
                return;
            }
            m_panelTypeEqpt.Visible = true;
            m_linkFieldTypeEqpt.FillDialogFromObjet(args.Objet);

        }

        //-------------------------------------------------------------------------
        private void m_gestionnaireEditionRelTypeEquipement_MAJ_Champs(object sender, CObjetDonneeResultEventArgs args)
        {
            if (args.Objet != null)
            {
                CResultAErreur result = m_linkFieldTypeEqpt.FillObjetFromDialog(args.Objet);
                if (!result)
                {
                    args.Result = result;
                    return;
                }
            }

        }

        //-------------------------------------------------------------------------
        private void m_lnkAddTypeEquipement_LinkClicked(object sender, EventArgs e)
        {
            if (m_txtSelectTypeEquipement.ElementSelectionne == null)
            {
                return;
            }
            CTypeEquipement typeEqpt = (CTypeEquipement)m_txtSelectTypeEquipement.ElementSelectionne;
            CListeObjetsDonnees listeExistants = TypeStock.RelationsTypesEquipements;
            listeExistants.Filtre = new CFiltreData(
                CTypeEquipement.c_champId + "=@1",
                typeEqpt.Id);

            if (listeExistants.Count != 0)
            {
                CFormAlerte.Afficher(I.T( "Ce type d'équipement est déjà dans la liste"), EFormAlerteType.Erreur);
                return;
            }
            m_txtSelectTypeEquipement.ElementSelectionne = null;
            
            CRelationTypeEquipement_TypeStock rel = new CRelationTypeEquipement_TypeStock(TypeStock.ContexteDonnee);
            rel.CreateNewInCurrentContexte();
            rel.TypeEquipement = typeEqpt;
            rel.TypeStock = TypeStock;

            InitListeTypesEquipements();
            InitSelectTypeEquipement();
        }

        //-------------------------------------------------------------------------
        private void m_lnkSupprimeTypeEquipement_LinkClicked(object sender, EventArgs e)
        {
            if (m_listeTypesEquipements.SelectedItems.Count != 1)
                return;

            CRelationTypeEquipement_TypeStock rel = (CRelationTypeEquipement_TypeStock)m_listeTypesEquipements.SelectedItems[0].Tag;

            m_gestionnaireEditionRelTypeEquipement.SetObjetEnCoursToNull();
            CResultAErreur result = rel.Delete();
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
                return;
            }

            if (m_listeTypesEquipements.SelectedItems.Count == 1)
            {
                if (m_listeTypesEquipements.SelectedItems[0] != null)
                    m_listeTypesEquipements.SelectedItems[0].Remove();
            }

            InitSelectTypeEquipement();
        }

		private CResultAErreur CFormEditionTypeStock_OnInitPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			using (CWaitCursor waiter = new CWaitCursor())
			{
                if (page == m_pageFormulaires)
                {
                    m_panelChamps.ElementEdite = TypeStock;
                }
				else if (page == m_pageDefinissionFiches)
				{
					m_panelDefinisseurChamps.InitPanel(
					 TypeStock,
					 typeof(CFormListeChampsCustom),
					 typeof(CFormListeFormulaires));
				}
				else if (page == m_pageTypesEqpt)
				{
					m_gestionnaireEditionRelTypeEquipement.ObjetEdite = TypeStock.RelationsTypesEquipements;
					InitSelectTypeEquipement();
					InitListeTypesEquipements();

					m_panelTypeEqpt.Visible = m_gestionnaireEditionRelTypeEquipement.ObjetEnCours is CRelationTypeEquipement_TypeStock;
				}
			}
			return result;
		}

		private CResultAErreur CFormEditionTypeStock_OnMajChampsPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;

            if (page == m_pageFormulaires)
            {
                result = m_panelChamps.MAJ_Champs();
            }
			else if (page == m_pageDefinissionFiches)
			{
				result = m_panelDefinisseurChamps.MAJ_Champs();
			}
			else if (page == m_pageTypesEqpt)
			{
				result = m_gestionnaireEditionRelTypeEquipement.ValideModifs();
			}
			return result;

		}
	}
}

