using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Windows.Forms;
using sc2i.workflow;
using sc2i.data.dynamic;
using sc2i.data;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.common;
using sc2i.win32.data;
using sc2i.win32.common;
using timos.win32.composants;


namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CCalendrier))]
	public class CFormEditionCalendrier : CFormEditionStdTimos, IFormNavigable
	{
		// Variables membres privées
        private CJourStyle m_styleJourDefaut = new CJourStyle ( Color.Black, Color.White );
		private CJourStyle m_styleJourParticulier = new CJourStyle ( Color.White, Color.DarkRed );
		private CJourStyle m_styleSansHoraire = new CJourStyle(Color.White, Color.Black);
		private DateTime m_dateEnCours = DateTime.Now;
        private List<DateTime> m_lstDatesEnCours = new List<DateTime>();
        private CCalendrier_JourParticulier m_jourParticulierEnCours = null;
        private bool m_bIsInitializing = false;
        private bool m_bMultiSelectionHomogene = false;
		
        private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtCode;
		private System.Windows.Forms.Label label2;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre2;
		private System.Windows.Forms.Panel m_panelSingleJPSetup;
        private System.Windows.Forms.Label m_lblDatePrecise;
		private System.Windows.Forms.Panel m_panelDatePrecise;
		private System.Windows.Forms.RadioButton m_radDatePreciseDefaut;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.RadioButton m_radMoisDefaut;
        private System.Windows.Forms.Label m_lblTousLesMois;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.RadioButton m_radAnDefaut;
        private System.Windows.Forms.Label m_lblTousLesAns;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label m_lblJoursSemaine;
        private System.Windows.Forms.Label label3;
		private sc2i.win32.common.C2iTabControl c2iTabControl1;
		private Crownwood.Magic.Controls.TabPage tabPage1;
		private Crownwood.Magic.Controls.TabPage tabPage2;
		private sc2i.win32.data.navigation.CPanelListeSpeedStandard m_wndPanelTous;
		private sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees m_cmbCalendrierBase;
		private System.Windows.Forms.Panel panel4;
		private timos.win32.composants.CPanelCalendrierAnnee m_wndCalendrier;
        private CComboBoxLinkListeObjetsDonnees m_cmbxSelectHoraireDefaut;
        private RadioButton m_radDatePreciseException;
        private RadioButton m_radMoisException;
        private RadioButton m_radAnException;
        private ListViewAutoFilledColumn m_colJoursSemaine;
        private RadioButton m_radJourSemaineException;
        private RadioButton m_radJourSemaineDefaut;
        private Button m_btnEditJ;
        private Button m_btnEditJM;
        private Button m_btnEditJMA;
        private Button m_btnEditJS;
        private Panel m_panelEditExceptions;
        private CControlEditElementATrancheHoraire m_controlEditJourParticulier;
        private CComboBoxLinkListeObjetsDonnees m_cmbxSelectTypeOccupationHoraire;
        private Label label4;
        private CComboBoxLinkListeObjetsDonnees m_cmbxSelectHoraireException;
        private Label label6;
        private Label label7;
        private CToolTipTraductible m_toolTipTraductible;
        private Label m_lblExceptionEdite;
        private Label label8;
        private LinkLabel m_lnkModifierJourParticulier;
        private Panel panel5;
        private Button m_btnEditMultiJP;
        private RadioButton m_radMultiSelectionException;
        private RadioButton m_radMultiSelectionDefaut;
        private Label m_lblMultiSelection;
        private Panel m_panelMultiJPSetup;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionCalendrier()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionCalendrier(CCalendrier calendrier)
			:base(calendrier)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionCalendrier(CCalendrier calendrier, CListeObjetsDonnees liste)
			:base(calendrier, liste)
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
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionCalendrier));
            sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn3 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn4 = new sc2i.win32.common.GLColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtCode = new sc2i.win32.common.C2iTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre2 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_cmbCalendrierBase = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.label3 = new System.Windows.Forms.Label();
            this.m_cmbxSelectHoraireDefaut = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.label4 = new System.Windows.Forms.Label();
            this.m_cmbxSelectTypeOccupationHoraire = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.label5 = new System.Windows.Forms.Label();
            this.m_lblJoursSemaine = new System.Windows.Forms.Label();
            this.m_panelSingleJPSetup = new System.Windows.Forms.Panel();
            this.m_btnEditJ = new System.Windows.Forms.Button();
            this.m_btnEditJM = new System.Windows.Forms.Button();
            this.m_btnEditJMA = new System.Windows.Forms.Button();
            this.m_btnEditJS = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_radAnException = new System.Windows.Forms.RadioButton();
            this.m_radAnDefaut = new System.Windows.Forms.RadioButton();
            this.m_lblTousLesAns = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.m_radJourSemaineException = new System.Windows.Forms.RadioButton();
            this.m_radJourSemaineDefaut = new System.Windows.Forms.RadioButton();
            this.m_panelDatePrecise = new System.Windows.Forms.Panel();
            this.m_radDatePreciseException = new System.Windows.Forms.RadioButton();
            this.m_radDatePreciseDefaut = new System.Windows.Forms.RadioButton();
            this.m_lblDatePrecise = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_radMoisException = new System.Windows.Forms.RadioButton();
            this.m_radMoisDefaut = new System.Windows.Forms.RadioButton();
            this.m_lblTousLesMois = new System.Windows.Forms.Label();
            this.c2iTabControl1 = new sc2i.win32.common.C2iTabControl(this.components);
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.m_panelMultiJPSetup = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.m_btnEditMultiJP = new System.Windows.Forms.Button();
            this.m_radMultiSelectionException = new System.Windows.Forms.RadioButton();
            this.m_radMultiSelectionDefaut = new System.Windows.Forms.RadioButton();
            this.m_lblMultiSelection = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.m_panelEditExceptions = new System.Windows.Forms.Panel();
            this.m_lnkModifierJourParticulier = new System.Windows.Forms.LinkLabel();
            this.m_lblExceptionEdite = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.m_controlEditJourParticulier = new timos.CControlEditElementATrancheHoraire();
            this.m_cmbxSelectHoraireException = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.label6 = new System.Windows.Forms.Label();
            this.m_wndCalendrier = new timos.win32.composants.CPanelCalendrierAnnee();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.m_wndPanelTous = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_colJoursSemaine = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_toolTipTraductible = new sc2i.win32.common.CToolTipTraductible(this.components);
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre2.SuspendLayout();
            this.m_panelSingleJPSetup.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.m_panelDatePrecise.SuspendLayout();
            this.panel2.SuspendLayout();
            this.c2iTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.m_panelMultiJPSetup.SuspendLayout();
            this.panel5.SuspendLayout();
            this.m_panelEditExceptions.SuspendLayout();
            this.tabPage2.SuspendLayout();
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
            this.m_panelNavigation.Location = new System.Drawing.Point(655, 0);
            this.m_panelNavigation.Size = new System.Drawing.Size(175, 28);
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
            this.m_panelCle.Location = new System.Drawing.Point(547, 0);
            this.m_panelCle.Size = new System.Drawing.Size(108, 28);
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
            // label1
            // 
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label1, "");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4002;
            this.label1.Text = "Code |231";
            // 
            // m_txtCode
            // 
            this.m_extLinkField.SetLinkField(this.m_txtCode, "Code");
            this.m_txtCode.Location = new System.Drawing.Point(93, 4);
            this.m_txtCode.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtCode, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtCode, "");
            this.m_txtCode.Name = "m_txtCode";
            this.m_txtCode.Size = new System.Drawing.Size(240, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtCode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtCode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtCode.TabIndex = 0;
            this.m_txtCode.Text = "[Code]";
            // 
            // label2
            // 
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(8, 26);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4004;
            this.label2.Text = "Label|50";
            // 
            // m_txtLibelle
            // 
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_txtLibelle.Location = new System.Drawing.Point(93, 23);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(240, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 1;
            this.m_txtLibelle.Text = "[Libelle]";
            // 
            // c2iPanelOmbre2
            // 
            this.c2iPanelOmbre2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre2.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre2.Controls.Add(this.m_cmbCalendrierBase);
            this.c2iPanelOmbre2.Controls.Add(this.m_txtCode);
            this.c2iPanelOmbre2.Controls.Add(this.label1);
            this.c2iPanelOmbre2.Controls.Add(this.label3);
            this.c2iPanelOmbre2.Controls.Add(this.m_cmbxSelectHoraireDefaut);
            this.c2iPanelOmbre2.Controls.Add(this.label2);
            this.c2iPanelOmbre2.Controls.Add(this.label4);
            this.c2iPanelOmbre2.Controls.Add(this.m_cmbxSelectTypeOccupationHoraire);
            this.c2iPanelOmbre2.Controls.Add(this.label5);
            this.c2iPanelOmbre2.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre2, "");
            this.c2iPanelOmbre2.Location = new System.Drawing.Point(8, 31);
            this.c2iPanelOmbre2.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre2, "");
            this.c2iPanelOmbre2.Name = "c2iPanelOmbre2";
            this.c2iPanelOmbre2.Size = new System.Drawing.Size(822, 85);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre2.TabIndex = 0;
            // 
            // m_cmbCalendrierBase
            // 
            this.m_cmbCalendrierBase.ComportementLinkStd = true;
            this.m_cmbCalendrierBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbCalendrierBase.ElementSelectionne = null;
            this.m_cmbCalendrierBase.IsLink = true;
            this.m_extLinkField.SetLinkField(this.m_cmbCalendrierBase, "");
            this.m_cmbCalendrierBase.LinkProperty = "";
            this.m_cmbCalendrierBase.ListDonnees = null;
            this.m_cmbCalendrierBase.Location = new System.Drawing.Point(93, 42);
            this.m_cmbCalendrierBase.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbCalendrierBase, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbCalendrierBase, "");
            this.m_cmbCalendrierBase.Name = "m_cmbCalendrierBase";
            this.m_cmbCalendrierBase.NullAutorise = true;
            this.m_cmbCalendrierBase.ProprieteAffichee = null;
            this.m_cmbCalendrierBase.ProprieteParentListeObjets = "";
            this.m_cmbCalendrierBase.SelectionneurParent = null;
            this.m_cmbCalendrierBase.Size = new System.Drawing.Size(240, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbCalendrierBase, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbCalendrierBase, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbCalendrierBase.TabIndex = 3;
            this.m_cmbCalendrierBase.TextNull = "(none)";
            this.m_cmbCalendrierBase.Tri = true;
            this.m_cmbCalendrierBase.TypeFormEdition = null;
            this.m_cmbCalendrierBase.SelectedValueChanged += new System.EventHandler(this.m_cmbCalendrier_SelectedValueChanged);
            // 
            // label3
            // 
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(8, 45);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 18);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4007;
            this.label3.Text = "Based on|890";
            // 
            // m_cmbxSelectHoraireDefaut
            // 
            this.m_cmbxSelectHoraireDefaut.ComportementLinkStd = true;
            this.m_cmbxSelectHoraireDefaut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbxSelectHoraireDefaut.ElementSelectionne = null;
            this.m_cmbxSelectHoraireDefaut.IsLink = true;
            this.m_extLinkField.SetLinkField(this.m_cmbxSelectHoraireDefaut, "");
            this.m_cmbxSelectHoraireDefaut.LinkProperty = "";
            this.m_cmbxSelectHoraireDefaut.ListDonnees = null;
            this.m_cmbxSelectHoraireDefaut.Location = new System.Drawing.Point(513, 3);
            this.m_cmbxSelectHoraireDefaut.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbxSelectHoraireDefaut, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbxSelectHoraireDefaut, "");
            this.m_cmbxSelectHoraireDefaut.Name = "m_cmbxSelectHoraireDefaut";
            this.m_cmbxSelectHoraireDefaut.NullAutorise = true;
            this.m_cmbxSelectHoraireDefaut.ProprieteAffichee = null;
            this.m_cmbxSelectHoraireDefaut.ProprieteParentListeObjets = "";
            this.m_cmbxSelectHoraireDefaut.SelectionneurParent = null;
            this.m_cmbxSelectHoraireDefaut.Size = new System.Drawing.Size(231, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbxSelectHoraireDefaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbxSelectHoraireDefaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbxSelectHoraireDefaut.TabIndex = 3;
            this.m_cmbxSelectHoraireDefaut.TextNull = "(none)";
            this.m_cmbxSelectHoraireDefaut.Tri = true;
            this.m_cmbxSelectHoraireDefaut.TypeFormEdition = null;
            this.m_cmbxSelectHoraireDefaut.SelectedValueChanged += new System.EventHandler(this.m_cmbxSelectHoraireDefaut_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.label4.Location = new System.Drawing.Point(351, 26);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 13);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 4006;
            this.label4.Text = "Default Occupation Type|411";
            // 
            // m_cmbxSelectTypeOccupationHoraire
            // 
            this.m_cmbxSelectTypeOccupationHoraire.BackColor = System.Drawing.Color.White;
            this.m_cmbxSelectTypeOccupationHoraire.ComportementLinkStd = true;
            this.m_cmbxSelectTypeOccupationHoraire.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbxSelectTypeOccupationHoraire.ElementSelectionne = null;
            this.m_cmbxSelectTypeOccupationHoraire.IsLink = true;
            this.m_extLinkField.SetLinkField(this.m_cmbxSelectTypeOccupationHoraire, "");
            this.m_cmbxSelectTypeOccupationHoraire.LinkProperty = "";
            this.m_cmbxSelectTypeOccupationHoraire.ListDonnees = null;
            this.m_cmbxSelectTypeOccupationHoraire.Location = new System.Drawing.Point(513, 23);
            this.m_cmbxSelectTypeOccupationHoraire.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbxSelectTypeOccupationHoraire, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbxSelectTypeOccupationHoraire, "");
            this.m_cmbxSelectTypeOccupationHoraire.Name = "m_cmbxSelectTypeOccupationHoraire";
            this.m_cmbxSelectTypeOccupationHoraire.NullAutorise = true;
            this.m_cmbxSelectTypeOccupationHoraire.ProprieteAffichee = null;
            this.m_cmbxSelectTypeOccupationHoraire.ProprieteParentListeObjets = "";
            this.m_cmbxSelectTypeOccupationHoraire.SelectionneurParent = null;
            this.m_cmbxSelectTypeOccupationHoraire.Size = new System.Drawing.Size(231, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbxSelectTypeOccupationHoraire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbxSelectTypeOccupationHoraire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbxSelectTypeOccupationHoraire.TabIndex = 3;
            this.m_cmbxSelectTypeOccupationHoraire.TextNull = "(none)";
            this.m_cmbxSelectTypeOccupationHoraire.Tri = true;
            this.m_cmbxSelectTypeOccupationHoraire.TypeFormEdition = null;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.label5.Location = new System.Drawing.Point(351, 7);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 13);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 4006;
            this.label5.Text = "Default Daily Schedule|404";
            // 
            // m_lblJoursSemaine
            // 
            this.m_lblJoursSemaine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblJoursSemaine.BackColor = System.Drawing.Color.DarkGreen;
            this.m_lblJoursSemaine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblJoursSemaine.ForeColor = System.Drawing.Color.White;
            this.m_extLinkField.SetLinkField(this.m_lblJoursSemaine, "");
            this.m_lblJoursSemaine.Location = new System.Drawing.Point(-1, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblJoursSemaine, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblJoursSemaine, "");
            this.m_lblJoursSemaine.Name = "m_lblJoursSemaine";
            this.m_lblJoursSemaine.Size = new System.Drawing.Size(134, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lblJoursSemaine, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblJoursSemaine, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblJoursSemaine.TabIndex = 6;
            this.m_lblJoursSemaine.Text = "Every|30326";
            // 
            // m_panelSingleJPSetup
            // 
            this.m_panelSingleJPSetup.BackColor = System.Drawing.Color.White;
            this.m_panelSingleJPSetup.Controls.Add(this.m_btnEditJ);
            this.m_panelSingleJPSetup.Controls.Add(this.m_btnEditJM);
            this.m_panelSingleJPSetup.Controls.Add(this.m_btnEditJMA);
            this.m_panelSingleJPSetup.Controls.Add(this.m_btnEditJS);
            this.m_panelSingleJPSetup.Controls.Add(this.panel3);
            this.m_panelSingleJPSetup.Controls.Add(this.panel4);
            this.m_panelSingleJPSetup.Controls.Add(this.m_panelDatePrecise);
            this.m_panelSingleJPSetup.Controls.Add(this.panel2);
            this.m_extLinkField.SetLinkField(this.m_panelSingleJPSetup, "");
            this.m_panelSingleJPSetup.Location = new System.Drawing.Point(296, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelSingleJPSetup, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelSingleJPSetup, "");
            this.m_panelSingleJPSetup.Name = "m_panelSingleJPSetup";
            this.m_panelSingleJPSetup.Size = new System.Drawing.Size(148, 285);
            this.m_extStyle.SetStyleBackColor(this.m_panelSingleJPSetup, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelSingleJPSetup, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelSingleJPSetup.TabIndex = 2;
            // 
            // m_btnEditJ
            // 
            this.m_btnEditJ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_btnEditJ, "");
            this.m_btnEditJ.Location = new System.Drawing.Point(128, 213);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnEditJ, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_btnEditJ, "");
            this.m_btnEditJ.Name = "m_btnEditJ";
            this.m_btnEditJ.Size = new System.Drawing.Size(18, 66);
            this.m_extStyle.SetStyleBackColor(this.m_btnEditJ, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnEditJ, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnEditJ.TabIndex = 10;
            this.m_btnEditJ.Text = ">";
            this.m_toolTipTraductible.SetToolTip(this.m_btnEditJ, "Edit Exception|422");
            this.m_btnEditJ.UseVisualStyleBackColor = true;
            this.m_btnEditJ.Click += new System.EventHandler(this.m_btnEditJ_Click);
            // 
            // m_btnEditJM
            // 
            this.m_btnEditJM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_btnEditJM, "");
            this.m_btnEditJM.Location = new System.Drawing.Point(128, 145);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnEditJM, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_btnEditJM, "");
            this.m_btnEditJM.Name = "m_btnEditJM";
            this.m_btnEditJM.Size = new System.Drawing.Size(18, 66);
            this.m_extStyle.SetStyleBackColor(this.m_btnEditJM, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnEditJM, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnEditJM.TabIndex = 10;
            this.m_btnEditJM.Text = ">";
            this.m_toolTipTraductible.SetToolTip(this.m_btnEditJM, "Edit Exception|422");
            this.m_btnEditJM.UseVisualStyleBackColor = true;
            this.m_btnEditJM.Click += new System.EventHandler(this.m_btnEditJM_Click);
            // 
            // m_btnEditJMA
            // 
            this.m_btnEditJMA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_btnEditJMA, "");
            this.m_btnEditJMA.Location = new System.Drawing.Point(128, 77);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnEditJMA, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_btnEditJMA, "");
            this.m_btnEditJMA.Name = "m_btnEditJMA";
            this.m_btnEditJMA.Size = new System.Drawing.Size(18, 66);
            this.m_extStyle.SetStyleBackColor(this.m_btnEditJMA, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnEditJMA, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnEditJMA.TabIndex = 10;
            this.m_btnEditJMA.Text = ">";
            this.m_toolTipTraductible.SetToolTip(this.m_btnEditJMA, "Edit Exception|422");
            this.m_btnEditJMA.UseVisualStyleBackColor = true;
            this.m_btnEditJMA.Click += new System.EventHandler(this.m_btnEditJMA_Click);
            // 
            // m_btnEditJS
            // 
            this.m_btnEditJS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_btnEditJS, "");
            this.m_btnEditJS.Location = new System.Drawing.Point(128, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnEditJS, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_btnEditJS, "");
            this.m_btnEditJS.Name = "m_btnEditJS";
            this.m_btnEditJS.Size = new System.Drawing.Size(18, 66);
            this.m_extStyle.SetStyleBackColor(this.m_btnEditJS, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnEditJS, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnEditJS.TabIndex = 10;
            this.m_btnEditJS.Text = ">";
            this.m_toolTipTraductible.SetToolTip(this.m_btnEditJS, "Edit Exception|422");
            this.m_btnEditJS.UseVisualStyleBackColor = true;
            this.m_btnEditJS.Click += new System.EventHandler(this.m_btnEditJS_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.m_radAnException);
            this.panel3.Controls.Add(this.m_radAnDefaut);
            this.panel3.Controls.Add(this.m_lblTousLesAns);
            this.m_extLinkField.SetLinkField(this.panel3, "");
            this.panel3.Location = new System.Drawing.Point(2, 146);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel3, "");
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(143, 64);
            this.m_extStyle.SetStyleBackColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel3.TabIndex = 2;
            // 
            // m_radAnException
            // 
            this.m_radAnException.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_radAnException, "");
            this.m_radAnException.Location = new System.Drawing.Point(8, 39);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_radAnException, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_radAnException, "");
            this.m_radAnException.Name = "m_radAnException";
            this.m_radAnException.Size = new System.Drawing.Size(94, 17);
            this.m_extStyle.SetStyleBackColor(this.m_radAnException, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_radAnException, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_radAnException.TabIndex = 1;
            this.m_radAnException.TabStop = true;
            this.m_radAnException.Text = "Exception|427";
            this.m_radAnException.UseVisualStyleBackColor = true;
            // 
            // m_radAnDefaut
            // 
            this.m_extLinkField.SetLinkField(this.m_radAnDefaut, "");
            this.m_radAnDefaut.Location = new System.Drawing.Point(8, 20);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_radAnDefaut, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_radAnDefaut, "");
            this.m_radAnDefaut.Name = "m_radAnDefaut";
            this.m_radAnDefaut.Size = new System.Drawing.Size(132, 18);
            this.m_extStyle.SetStyleBackColor(this.m_radAnDefaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_radAnDefaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_radAnDefaut.TabIndex = 0;
            this.m_radAnDefaut.Text = "Default schedule|426";
            this.m_radAnDefaut.CheckedChanged += new System.EventHandler(this.OnChangeSomethingNeedRefresh);
            // 
            // m_lblTousLesAns
            // 
            this.m_lblTousLesAns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblTousLesAns.BackColor = System.Drawing.Color.DarkGreen;
            this.m_lblTousLesAns.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblTousLesAns.ForeColor = System.Drawing.Color.White;
            this.m_extLinkField.SetLinkField(this.m_lblTousLesAns, "");
            this.m_lblTousLesAns.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblTousLesAns, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblTousLesAns, "");
            this.m_lblTousLesAns.Name = "m_lblTousLesAns";
            this.m_lblTousLesAns.Size = new System.Drawing.Size(134, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lblTousLesAns, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblTousLesAns, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblTousLesAns.TabIndex = 0;
            this.m_lblTousLesAns.Text = "Every dd/mm|30210";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.m_radJourSemaineException);
            this.panel4.Controls.Add(this.m_radJourSemaineDefaut);
            this.panel4.Controls.Add(this.m_lblJoursSemaine);
            this.m_extLinkField.SetLinkField(this.panel4, "");
            this.panel4.Location = new System.Drawing.Point(2, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel4, "");
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(143, 66);
            this.m_extStyle.SetStyleBackColor(this.panel4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel4.TabIndex = 8;
            // 
            // m_radJourSemaineException
            // 
            this.m_radJourSemaineException.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_radJourSemaineException, "");
            this.m_radJourSemaineException.Location = new System.Drawing.Point(7, 41);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_radJourSemaineException, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_radJourSemaineException, "");
            this.m_radJourSemaineException.Name = "m_radJourSemaineException";
            this.m_radJourSemaineException.Size = new System.Drawing.Size(94, 17);
            this.m_extStyle.SetStyleBackColor(this.m_radJourSemaineException, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_radJourSemaineException, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_radJourSemaineException.TabIndex = 1;
            this.m_radJourSemaineException.TabStop = true;
            this.m_radJourSemaineException.Text = "Exception|427";
            this.m_radJourSemaineException.UseVisualStyleBackColor = true;
            // 
            // m_radJourSemaineDefaut
            // 
            this.m_extLinkField.SetLinkField(this.m_radJourSemaineDefaut, "");
            this.m_radJourSemaineDefaut.Location = new System.Drawing.Point(7, 22);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_radJourSemaineDefaut, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_radJourSemaineDefaut, "");
            this.m_radJourSemaineDefaut.Name = "m_radJourSemaineDefaut";
            this.m_radJourSemaineDefaut.Size = new System.Drawing.Size(132, 18);
            this.m_extStyle.SetStyleBackColor(this.m_radJourSemaineDefaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_radJourSemaineDefaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_radJourSemaineDefaut.TabIndex = 0;
            this.m_radJourSemaineDefaut.Text = "Default schedule|426";
            this.m_radJourSemaineDefaut.CheckedChanged += new System.EventHandler(this.OnChangeSomethingNeedRefresh);
            // 
            // m_panelDatePrecise
            // 
            this.m_panelDatePrecise.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelDatePrecise.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panelDatePrecise.Controls.Add(this.m_radDatePreciseException);
            this.m_panelDatePrecise.Controls.Add(this.m_radDatePreciseDefaut);
            this.m_panelDatePrecise.Controls.Add(this.m_lblDatePrecise);
            this.m_extLinkField.SetLinkField(this.m_panelDatePrecise, "");
            this.m_panelDatePrecise.Location = new System.Drawing.Point(2, 78);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelDatePrecise, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelDatePrecise, "");
            this.m_panelDatePrecise.Name = "m_panelDatePrecise";
            this.m_panelDatePrecise.Size = new System.Drawing.Size(143, 64);
            this.m_extStyle.SetStyleBackColor(this.m_panelDatePrecise, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelDatePrecise, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelDatePrecise.TabIndex = 0;
            // 
            // m_radDatePreciseException
            // 
            this.m_radDatePreciseException.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_radDatePreciseException, "");
            this.m_radDatePreciseException.Location = new System.Drawing.Point(8, 39);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_radDatePreciseException, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_radDatePreciseException, "");
            this.m_radDatePreciseException.Name = "m_radDatePreciseException";
            this.m_radDatePreciseException.Size = new System.Drawing.Size(94, 17);
            this.m_extStyle.SetStyleBackColor(this.m_radDatePreciseException, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_radDatePreciseException, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_radDatePreciseException.TabIndex = 1;
            this.m_radDatePreciseException.TabStop = true;
            this.m_radDatePreciseException.Text = "Exception|427";
            this.m_radDatePreciseException.UseVisualStyleBackColor = true;
            // 
            // m_radDatePreciseDefaut
            // 
            this.m_extLinkField.SetLinkField(this.m_radDatePreciseDefaut, "");
            this.m_radDatePreciseDefaut.Location = new System.Drawing.Point(8, 20);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_radDatePreciseDefaut, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_radDatePreciseDefaut, "");
            this.m_radDatePreciseDefaut.Name = "m_radDatePreciseDefaut";
            this.m_radDatePreciseDefaut.Size = new System.Drawing.Size(132, 18);
            this.m_extStyle.SetStyleBackColor(this.m_radDatePreciseDefaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_radDatePreciseDefaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_radDatePreciseDefaut.TabIndex = 0;
            this.m_radDatePreciseDefaut.Text = "Default schedule|426";
            this.m_radDatePreciseDefaut.CheckedChanged += new System.EventHandler(this.OnChangeSomethingNeedRefresh);
            // 
            // m_lblDatePrecise
            // 
            this.m_lblDatePrecise.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblDatePrecise.BackColor = System.Drawing.Color.DarkGreen;
            this.m_lblDatePrecise.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblDatePrecise.ForeColor = System.Drawing.Color.White;
            this.m_extLinkField.SetLinkField(this.m_lblDatePrecise, "");
            this.m_lblDatePrecise.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblDatePrecise, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblDatePrecise, "");
            this.m_lblDatePrecise.Name = "m_lblDatePrecise";
            this.m_lblDatePrecise.Size = new System.Drawing.Size(134, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lblDatePrecise, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblDatePrecise, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblDatePrecise.TabIndex = 0;
            this.m_lblDatePrecise.Text = "Date dd/mm/yy|30209";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.m_radMoisException);
            this.panel2.Controls.Add(this.m_radMoisDefaut);
            this.panel2.Controls.Add(this.m_lblTousLesMois);
            this.m_extLinkField.SetLinkField(this.panel2, "");
            this.panel2.Location = new System.Drawing.Point(2, 214);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel2, "");
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(143, 64);
            this.m_extStyle.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel2.TabIndex = 1;
            // 
            // m_radMoisException
            // 
            this.m_radMoisException.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_radMoisException, "");
            this.m_radMoisException.Location = new System.Drawing.Point(8, 39);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_radMoisException, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_radMoisException, "");
            this.m_radMoisException.Name = "m_radMoisException";
            this.m_radMoisException.Size = new System.Drawing.Size(94, 17);
            this.m_extStyle.SetStyleBackColor(this.m_radMoisException, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_radMoisException, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_radMoisException.TabIndex = 1;
            this.m_radMoisException.TabStop = true;
            this.m_radMoisException.Text = "Exception|427";
            this.m_radMoisException.UseVisualStyleBackColor = true;
            // 
            // m_radMoisDefaut
            // 
            this.m_extLinkField.SetLinkField(this.m_radMoisDefaut, "");
            this.m_radMoisDefaut.Location = new System.Drawing.Point(8, 20);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_radMoisDefaut, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_radMoisDefaut, "");
            this.m_radMoisDefaut.Name = "m_radMoisDefaut";
            this.m_radMoisDefaut.Size = new System.Drawing.Size(132, 18);
            this.m_extStyle.SetStyleBackColor(this.m_radMoisDefaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_radMoisDefaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_radMoisDefaut.TabIndex = 0;
            this.m_radMoisDefaut.Text = "Default schedule|426";
            this.m_radMoisDefaut.CheckedChanged += new System.EventHandler(this.OnChangeSomethingNeedRefresh);
            // 
            // m_lblTousLesMois
            // 
            this.m_lblTousLesMois.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblTousLesMois.BackColor = System.Drawing.Color.DarkGreen;
            this.m_lblTousLesMois.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblTousLesMois.ForeColor = System.Drawing.Color.White;
            this.m_extLinkField.SetLinkField(this.m_lblTousLesMois, "");
            this.m_lblTousLesMois.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblTousLesMois, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblTousLesMois, "");
            this.m_lblTousLesMois.Name = "m_lblTousLesMois";
            this.m_lblTousLesMois.Size = new System.Drawing.Size(134, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lblTousLesMois, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblTousLesMois, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblTousLesMois.TabIndex = 0;
            this.m_lblTousLesMois.Text = "Every dd|30211";
            // 
            // c2iTabControl1
            // 
            this.c2iTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iTabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iTabControl1.BoldSelectedPage = true;
            this.c2iTabControl1.ControlBottomOffset = 16;
            this.c2iTabControl1.ControlRightOffset = 16;
            this.c2iTabControl1.ForeColor = System.Drawing.Color.Black;
            this.c2iTabControl1.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.c2iTabControl1, "");
            this.c2iTabControl1.Location = new System.Drawing.Point(8, 118);
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTabControl1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iTabControl1, "");
            this.c2iTabControl1.Name = "c2iTabControl1";
            this.c2iTabControl1.Ombre = true;
            this.c2iTabControl1.PositionTop = true;
            this.c2iTabControl1.SelectedIndex = 0;
            this.c2iTabControl1.SelectedTab = this.tabPage1;
            this.c2iTabControl1.Size = new System.Drawing.Size(822, 423);
            this.m_extStyle.SetStyleBackColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iTabControl1.TabIndex = 4004;
            this.c2iTabControl1.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2});
            this.c2iTabControl1.TextColor = System.Drawing.Color.Black;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_panelMultiJPSetup);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.m_panelEditExceptions);
            this.tabPage1.Controls.Add(this.m_wndCalendrier);
            this.tabPage1.Controls.Add(this.m_panelSingleJPSetup);
            this.m_extLinkField.SetLinkField(this.tabPage1, "");
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tabPage1, "");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(806, 382);
            this.m_extStyle.SetStyleBackColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage1.TabIndex = 10;
            this.tabPage1.Title = "Calendar view|407";
            // 
            // m_panelMultiJPSetup
            // 
            this.m_panelMultiJPSetup.BackColor = System.Drawing.Color.White;
            this.m_panelMultiJPSetup.Controls.Add(this.panel5);
            this.m_extLinkField.SetLinkField(this.m_panelMultiJPSetup, "");
            this.m_panelMultiJPSetup.Location = new System.Drawing.Point(296, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelMultiJPSetup, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelMultiJPSetup, "");
            this.m_panelMultiJPSetup.Name = "m_panelMultiJPSetup";
            this.m_panelMultiJPSetup.Size = new System.Drawing.Size(148, 80);
            this.m_extStyle.SetStyleBackColor(this.m_panelMultiJPSetup, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMultiJPSetup, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelMultiJPSetup.TabIndex = 12;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.m_btnEditMultiJP);
            this.panel5.Controls.Add(this.m_radMultiSelectionException);
            this.panel5.Controls.Add(this.m_radMultiSelectionDefaut);
            this.panel5.Controls.Add(this.m_lblMultiSelection);
            this.m_extLinkField.SetLinkField(this.panel5, "");
            this.panel5.Location = new System.Drawing.Point(3, 6);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel5, "");
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(142, 68);
            this.m_extStyle.SetStyleBackColor(this.panel5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel5.TabIndex = 0;
            // 
            // m_btnEditMultiJP
            // 
            this.m_btnEditMultiJP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_btnEditMultiJP, "");
            this.m_btnEditMultiJP.Location = new System.Drawing.Point(122, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnEditMultiJP, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_btnEditMultiJP, "");
            this.m_btnEditMultiJP.Name = "m_btnEditMultiJP";
            this.m_btnEditMultiJP.Size = new System.Drawing.Size(18, 66);
            this.m_extStyle.SetStyleBackColor(this.m_btnEditMultiJP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnEditMultiJP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnEditMultiJP.TabIndex = 10;
            this.m_btnEditMultiJP.Text = ">";
            this.m_btnEditMultiJP.UseVisualStyleBackColor = true;
            this.m_btnEditMultiJP.Click += new System.EventHandler(this.m_btnEditMultiJP_Click);
            // 
            // m_radMultiSelectionException
            // 
            this.m_radMultiSelectionException.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_radMultiSelectionException, "");
            this.m_radMultiSelectionException.Location = new System.Drawing.Point(8, 39);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_radMultiSelectionException, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_radMultiSelectionException, "");
            this.m_radMultiSelectionException.Name = "m_radMultiSelectionException";
            this.m_radMultiSelectionException.Size = new System.Drawing.Size(94, 17);
            this.m_extStyle.SetStyleBackColor(this.m_radMultiSelectionException, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_radMultiSelectionException, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_radMultiSelectionException.TabIndex = 1;
            this.m_radMultiSelectionException.TabStop = true;
            this.m_radMultiSelectionException.Text = "Exception|427";
            this.m_radMultiSelectionException.UseVisualStyleBackColor = true;
            // 
            // m_radMultiSelectionDefaut
            // 
            this.m_extLinkField.SetLinkField(this.m_radMultiSelectionDefaut, "");
            this.m_radMultiSelectionDefaut.Location = new System.Drawing.Point(8, 20);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_radMultiSelectionDefaut, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_radMultiSelectionDefaut, "");
            this.m_radMultiSelectionDefaut.Name = "m_radMultiSelectionDefaut";
            this.m_radMultiSelectionDefaut.Size = new System.Drawing.Size(132, 18);
            this.m_extStyle.SetStyleBackColor(this.m_radMultiSelectionDefaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_radMultiSelectionDefaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_radMultiSelectionDefaut.TabIndex = 0;
            this.m_radMultiSelectionDefaut.Text = "Default schedule|426";
            this.m_radMultiSelectionDefaut.CheckedChanged += new System.EventHandler(this.OnChangeSomethingNeedRefresh);
            // 
            // m_lblMultiSelection
            // 
            this.m_lblMultiSelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblMultiSelection.BackColor = System.Drawing.Color.DarkGreen;
            this.m_lblMultiSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblMultiSelection.ForeColor = System.Drawing.Color.White;
            this.m_extLinkField.SetLinkField(this.m_lblMultiSelection, "");
            this.m_lblMultiSelection.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblMultiSelection, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblMultiSelection, "");
            this.m_lblMultiSelection.Name = "m_lblMultiSelection";
            this.m_lblMultiSelection.Size = new System.Drawing.Size(133, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lblMultiSelection, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblMultiSelection, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblMultiSelection.TabIndex = 0;
            this.m_lblMultiSelection.Text = "Multi selection|428";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label7, "");
            this.label7.Location = new System.Drawing.Point(295, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label7, "");
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 13);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 11;
            this.label7.Text = "Exceptions setup|415";
            // 
            // m_panelEditExceptions
            // 
            this.m_panelEditExceptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelEditExceptions.Controls.Add(this.m_lnkModifierJourParticulier);
            this.m_panelEditExceptions.Controls.Add(this.m_lblExceptionEdite);
            this.m_panelEditExceptions.Controls.Add(this.label8);
            this.m_panelEditExceptions.Controls.Add(this.m_controlEditJourParticulier);
            this.m_panelEditExceptions.Controls.Add(this.m_cmbxSelectHoraireException);
            this.m_panelEditExceptions.Controls.Add(this.label6);
            this.m_extLinkField.SetLinkField(this.m_panelEditExceptions, "");
            this.m_panelEditExceptions.Location = new System.Drawing.Point(444, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEditExceptions, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelEditExceptions, "");
            this.m_panelEditExceptions.Name = "m_panelEditExceptions";
            this.m_panelEditExceptions.Size = new System.Drawing.Size(362, 375);
            this.m_extStyle.SetStyleBackColor(this.m_panelEditExceptions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEditExceptions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEditExceptions.TabIndex = 10;
            this.m_panelEditExceptions.Leave += new System.EventHandler(this.m_panelEditExceptions_Leave);
            // 
            // m_lnkModifierJourParticulier
            // 
            this.m_extLinkField.SetLinkField(this.m_lnkModifierJourParticulier, "");
            this.m_lnkModifierJourParticulier.Location = new System.Drawing.Point(6, 93);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkModifierJourParticulier, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkModifierJourParticulier, "");
            this.m_lnkModifierJourParticulier.Name = "m_lnkModifierJourParticulier";
            this.m_lnkModifierJourParticulier.Size = new System.Drawing.Size(322, 22);
            this.m_extStyle.SetStyleBackColor(this.m_lnkModifierJourParticulier, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkModifierJourParticulier, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkModifierJourParticulier.TabIndex = 4008;
            this.m_lnkModifierJourParticulier.TabStop = true;
            this.m_lnkModifierJourParticulier.Text = "Modify time slots of associated daily schedule|423";
            this.m_lnkModifierJourParticulier.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkModifierJourParticulier_LinkClicked);
            // 
            // m_lblExceptionEdite
            // 
            this.m_lblExceptionEdite.AutoSize = true;
            this.m_lblExceptionEdite.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.m_lblExceptionEdite, "");
            this.m_lblExceptionEdite.Location = new System.Drawing.Point(181, 4);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblExceptionEdite, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblExceptionEdite, "");
            this.m_lblExceptionEdite.Name = "m_lblExceptionEdite";
            this.m_lblExceptionEdite.Size = new System.Drawing.Size(26, 23);
            this.m_extStyle.SetStyleBackColor(this.m_lblExceptionEdite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblExceptionEdite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblExceptionEdite.TabIndex = 4007;
            this.m_lblExceptionEdite.Text = "\"\"";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label8, "");
            this.label8.Location = new System.Drawing.Point(2, 4);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label8, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label8, "");
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 23);
            this.m_extStyle.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 4007;
            this.label8.Text = "Exception|420";
            // 
            // m_controlEditJourParticulier
            // 
            this.m_controlEditJourParticulier.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_controlEditJourParticulier, "");
            this.m_controlEditJourParticulier.Location = new System.Drawing.Point(0, 62);
            this.m_controlEditJourParticulier.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_controlEditJourParticulier, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_controlEditJourParticulier, "");
            this.m_controlEditJourParticulier.Name = "m_controlEditJourParticulier";
            this.m_controlEditJourParticulier.Size = new System.Drawing.Size(356, 313);
            this.m_extStyle.SetStyleBackColor(this.m_controlEditJourParticulier, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_controlEditJourParticulier, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_controlEditJourParticulier.TabIndex = 0;
            // 
            // m_cmbxSelectHoraireException
            // 
            this.m_cmbxSelectHoraireException.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbxSelectHoraireException.ComportementLinkStd = true;
            this.m_cmbxSelectHoraireException.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbxSelectHoraireException.ElementSelectionne = null;
            this.m_cmbxSelectHoraireException.IsLink = true;
            this.m_extLinkField.SetLinkField(this.m_cmbxSelectHoraireException, "");
            this.m_cmbxSelectHoraireException.LinkProperty = "";
            this.m_cmbxSelectHoraireException.ListDonnees = null;
            this.m_cmbxSelectHoraireException.Location = new System.Drawing.Point(158, 35);
            this.m_cmbxSelectHoraireException.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbxSelectHoraireException, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbxSelectHoraireException, "");
            this.m_cmbxSelectHoraireException.Name = "m_cmbxSelectHoraireException";
            this.m_cmbxSelectHoraireException.NullAutorise = true;
            this.m_cmbxSelectHoraireException.ProprieteAffichee = null;
            this.m_cmbxSelectHoraireException.ProprieteParentListeObjets = "";
            this.m_cmbxSelectHoraireException.SelectionneurParent = null;
            this.m_cmbxSelectHoraireException.Size = new System.Drawing.Size(176, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbxSelectHoraireException, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbxSelectHoraireException, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbxSelectHoraireException.TabIndex = 3;
            this.m_cmbxSelectHoraireException.TextNull = "(none)";
            this.m_cmbxSelectHoraireException.Tri = true;
            this.m_cmbxSelectHoraireException.TypeFormEdition = null;
            this.m_cmbxSelectHoraireException.SelectionChangeCommitted += new System.EventHandler(this.m_cmbxSelectHoraireException_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.label6.Location = new System.Drawing.Point(3, 38);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label6, "");
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 4006;
            this.label6.Text = "Daily Schedule|400";
            // 
            // m_wndCalendrier
            // 
            this.m_wndCalendrier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_wndCalendrier.BackColor = System.Drawing.Color.White;
            this.m_wndCalendrier.Colonnes = 3;
            this.m_wndCalendrier.DateSelectionnee = new System.DateTime(2004, 6, 2, 16, 52, 16, 999);
            this.m_extLinkField.SetLinkField(this.m_wndCalendrier, "");
            this.m_wndCalendrier.Location = new System.Drawing.Point(4, 4);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndCalendrier, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndCalendrier, "");
            this.m_wndCalendrier.Name = "m_wndCalendrier";
            this.m_wndCalendrier.Size = new System.Drawing.Size(290, 375);
            this.m_extStyle.SetStyleBackColor(this.m_wndCalendrier, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndCalendrier, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndCalendrier.TabIndex = 9;
            this.m_wndCalendrier.OnSelectedDateChanged += new System.EventHandler(this.m_wndCalendrier_OnSelectedDateChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.m_wndPanelTous);
            this.m_extLinkField.SetLinkField(this.tabPage2, "");
            this.tabPage2.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tabPage2, "");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(806, 382);
            this.m_extStyle.SetStyleBackColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage2.TabIndex = 11;
            this.tabPage2.Title = "All Exceptions|408";
            // 
            // m_wndPanelTous
            // 
            this.m_wndPanelTous.AllowArbre = true;
            this.m_wndPanelTous.AllowCustomisation = true;
            this.m_wndPanelTous.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_wndPanelTous.BoutonAjouterVisible = false;
            this.m_wndPanelTous.BoutonModifierVisible = false;
            glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "Name";
            glColumn1.Propriete = "Annee";
            glColumn1.Text = "Year|30327";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 50;
            glColumn2.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn2.ActiveControlItems")));
            glColumn2.BackColor = System.Drawing.Color.Transparent;
            glColumn2.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn2.ForColor = System.Drawing.Color.Black;
            glColumn2.ImageIndex = -1;
            glColumn2.IsCheckColumn = false;
            glColumn2.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn2.Name = "Namex";
            glColumn2.Propriete = "Mois";
            glColumn2.Text = "Month|1317";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 100;
            glColumn3.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn3.ActiveControlItems")));
            glColumn3.BackColor = System.Drawing.Color.Transparent;
            glColumn3.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn3.ForColor = System.Drawing.Color.Black;
            glColumn3.ImageIndex = -1;
            glColumn3.IsCheckColumn = false;
            glColumn3.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn3.Name = "Namexx";
            glColumn3.Propriete = "Jour";
            glColumn3.Text = "Day|1318";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn3.Width = 50;
            glColumn4.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn4.ActiveControlItems")));
            glColumn4.BackColor = System.Drawing.Color.Transparent;
            glColumn4.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn4.ForColor = System.Drawing.Color.Black;
            glColumn4.ImageIndex = -1;
            glColumn4.IsCheckColumn = false;
            glColumn4.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn4.Name = "Namexxx";
            glColumn4.Propriete = "JourSemaineNom";
            glColumn4.Text = "Day of the Week|30328";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn4.Width = 200;
            this.m_wndPanelTous.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1,
            glColumn2,
            glColumn3,
            glColumn4});
            this.m_wndPanelTous.ContexteUtilisation = "";
            this.m_wndPanelTous.ControlFiltreStandard = null;
            this.m_wndPanelTous.ElementSelectionne = null;
            this.m_wndPanelTous.EnableCustomisation = true;
            this.m_wndPanelTous.FiltreDeBase = null;
            this.m_wndPanelTous.FiltreDeBaseEnAjout = false;
            this.m_wndPanelTous.FiltrePrefere = null;
            this.m_wndPanelTous.FiltreRapide = null;
            this.m_wndPanelTous.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_wndPanelTous, "");
            this.m_wndPanelTous.ListeObjets = null;
            this.m_wndPanelTous.Location = new System.Drawing.Point(0, 0);
            this.m_wndPanelTous.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndPanelTous, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_wndPanelTous.ModeQuickSearch = false;
            this.m_wndPanelTous.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_wndPanelTous, "");
            this.m_wndPanelTous.MultiSelect = false;
            this.m_wndPanelTous.Name = "m_wndPanelTous";
            this.m_wndPanelTous.Navigateur = null;
            this.m_wndPanelTous.ProprieteObjetAEditer = null;
            this.m_wndPanelTous.QuickSearchText = "";
            this.m_wndPanelTous.Size = new System.Drawing.Size(803, 373);
            this.m_extStyle.SetStyleBackColor(this.m_wndPanelTous, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndPanelTous, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndPanelTous.TabIndex = 0;
            this.m_wndPanelTous.TrierAuClicSurEnteteColonne = true;
            this.m_wndPanelTous.UseCheckBoxes = false;
            // 
            // m_colJoursSemaine
            // 
            this.m_colJoursSemaine.Field = "";
            this.m_colJoursSemaine.PrecisionWidth = 0;
            this.m_colJoursSemaine.ProportionnalSize = false;
            this.m_colJoursSemaine.Visible = true;
            this.m_colJoursSemaine.Width = 120;
            // 
            // CFormEditionCalendrier
            // 
            this.ClientSize = new System.Drawing.Size(830, 540);
            this.Controls.Add(this.c2iTabControl1);
            this.Controls.Add(this.c2iPanelOmbre2);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionCalendrier";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Load += new System.EventHandler(this.CFormEditionCalendrier_Load);
            this.BeforeValideModification += new sc2i.data.ObjetDonneeCancelEventHandler(this.CFormEditionCalendrier_BeforeValideModification);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre2, 0);
            this.Controls.SetChildIndex(this.c2iTabControl1, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.c2iPanelOmbre2.ResumeLayout(false);
            this.c2iPanelOmbre2.PerformLayout();
            this.m_panelSingleJPSetup.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.m_panelDatePrecise.ResumeLayout(false);
            this.m_panelDatePrecise.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.c2iTabControl1.ResumeLayout(false);
            this.c2iTabControl1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.m_panelMultiJPSetup.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.m_panelEditExceptions.ResumeLayout(false);
            this.m_panelEditExceptions.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CCalendrier Calendrier
		{
			get
			{
				return (CCalendrier)ObjetEdite;
			}
		}
		
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
			m_bIsInitializing = true;
            CResultAErreur result = base.MyInitChamps();
			// Init le titre
            string strLib = Calendrier.Libelle;
            if (Calendrier.Acteur != null)
            {
                strLib = Calendrier.Acteur.IdentiteComplete;
                m_txtLibelle.LockEdition = true;
            }
            else
                m_txtLibelle.LockEdition = !m_gestionnaireModeEdition.ModeEdition;

			AffecterTitre(I.T ( "Calendar|187")+" "+strLib);
            
            // Init la combo de sélection du calendrier de base
			InitComboCalendrierBase();
            
			// Init la combo de sélection de l'Horaire par défaut
            InitComboHoraireDefaut();
            InitComboHoraireException();
            InitComboTypeOccupationHoraire();


			AfficheDateEnCours();

			if (m_jourParticulierEnCours == null || !m_jourParticulierEnCours.IsValide())
			{
				m_panelEditExceptions.Visible = false;
				m_jourParticulierEnCours = null;
				//m_cmbxSelectHoraireException.ElementSelectionne = m_jourParticulierEnCours.HoraireJournalier;
				//InitEditionJourParticulier(m_jourParticulierEnCours);
			}
			else
			{
				m_jourParticulierEnCours = (CCalendrier_JourParticulier)m_jourParticulierEnCours.GetObjetInContexte(Calendrier.ContexteDonnee);
				InitEditionJourParticulier(m_jourParticulierEnCours);
			}

            InitCalendrier();

			m_bIsInitializing = false;
			return result;
		}
        //--------------------------------------------------------------------------------------------
        private void InitPanelsSingleMultiJP()
        {
            m_panelMultiJPSetup.Visible = (m_lstDatesEnCours.Count > 1);
            m_panelSingleJPSetup.Visible = !m_panelMultiJPSetup.Visible;
        }

        //--------------------------------------------------------------------------------------------
        private void InitComboHoraireDefaut()
        {
            m_cmbxSelectHoraireDefaut.Init(typeof(CHoraireJournalier), "Libelle", typeof(CFormEditionHoraireJournalier), true);
            m_cmbxSelectHoraireDefaut.ElementSelectionne = Calendrier.HoraireParDefaut;
            m_cmbxSelectHoraireDefaut.NullAutorise = false;
        }

        //--------------------------------------------------------------------------------------------
        private void InitComboTypeOccupationHoraire()
        {
			CListeObjetsDonnees listeOcc = new CListeObjetsDonnees(ObjetEdite.ContexteDonnee, typeof(CTypeOccupationHoraire));
			listeOcc.Filtre = new CFiltreData(CTypeOccupationHoraire.c_champSurCalendrier + "=@1", true);
            m_cmbxSelectTypeOccupationHoraire.Init(listeOcc, "Libelle", true);
            m_cmbxSelectTypeOccupationHoraire.NullAutorise = true;
            m_cmbxSelectTypeOccupationHoraire.TextNull = I.T("Default|30330");
            m_cmbxSelectTypeOccupationHoraire.ElementSelectionne = Calendrier.TypeOccupationHoraire;

        }

        //--------------------------------------------------------------------------------------------
        private void InitComboHoraireException()
        {
            m_cmbxSelectHoraireException.Init(typeof(CHoraireJournalier), "Libelle", typeof(CFormEditionHoraireJournalier), true);
            m_cmbxSelectHoraireException.NullAutorise = true;
            m_cmbxSelectHoraireException.TextNull = I.T("None|148");
        }

        //-------------------------------------------------------------------------
        private void InitComboCalendrierBase()
        {
            CFiltreData filtre = null;
            string strIds = "";
            foreach (CCalendrier calendrier in Calendrier.GetListeCalendriersDependants())
                strIds += calendrier.Id.ToString() + ",";
            if (strIds.Length > 0)
            {
                strIds = strIds.Substring(0, strIds.Length - 1);
                filtre = new CFiltreDataAvance(CCalendrier.c_nomTable,
					CCalendrier.c_champId + " not in (" +
                    strIds + ") and hasno("+
					timos.acteurs.CActeur.c_champId+")");
            }
            m_cmbCalendrierBase.Init(typeof(CCalendrier), filtre, "Libelle", typeof(CFormEditionCalendrier), true);
            m_cmbCalendrierBase.ElementSelectionne = Calendrier.CalendrierDeBase;
        }

		//-------------------------------------------------------------------------
		protected override CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = base.MAJ_Champs();
			if ( !result )
				return result;

            Calendrier.CalendrierDeBase = (CCalendrier)m_cmbCalendrierBase.ElementSelectionne;
            Calendrier.HoraireParDefaut = (CHoraireJournalier)m_cmbxSelectHoraireDefaut.ElementSelectionne;
            Calendrier.TypeOccupationHoraire = (CTypeOccupationHoraire)m_cmbxSelectTypeOccupationHoraire.ElementSelectionne;

			return result;
		}


		//-------------------------------------------------------------------------
		private void InitCalendrier(  )
		{
			m_wndCalendrier.ResetStyles();
			CTypeOccupationHoraire typeOcc = Calendrier.TypeOccupationHoraireAppliquee;
			if (typeOcc != null)
				m_wndCalendrier.DefaultStyle = GetStyleJour(typeOcc);
			else
				m_wndCalendrier.DefaultStyle = Calendrier.HoraireParDefaut!=null?m_styleJourDefaut:m_styleJourParticulier;
			
            InitCalendrier ( Calendrier );
			
            m_wndPanelTous.InitFromListeObjets ( 
				Calendrier.JoursParticuliersListe,
				typeof(CCalendrier_JourParticulier),
				null,
				null,
				"" );
			m_wndCalendrier.Refresh();
		}

        //-------------------------------------------------------------------------
        private void m_wndCalendrier_OnSelectedDateChanged(object sender, System.EventArgs e)
		{
            m_jourParticulierEnCours = null;
			m_panelEditExceptions.Visible = false;
            if (!m_bIsInitializing)
			{
				AfficheDateEnCours();
			}
            
		}

        //-------------------------------------------------------------------------
        private void CFormEditionCalendrier_Load(object sender, System.EventArgs e)
		{
		}

        //-------------------------------------------------------------------------
        private void m_cmbCalendrier_SelectedValueChanged(object sender, System.EventArgs e)
		{
			if ( !m_bIsInitializing )
			{
				if ( m_cmbCalendrierBase.SelectedValue is CCalendrier )
					Calendrier.CalendrierDeBase = (CCalendrier)m_cmbCalendrierBase.SelectedValue;
				else
					Calendrier.CalendrierDeBase = null;
				InitCalendrier();
			}
		}

        //-------------------------------------------------------------------------
        private void m_cmbxSelectHoraireDefaut_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!m_bIsInitializing)
            {
                if (m_cmbxSelectHoraireDefaut.SelectedValue is CHoraireJournalier)
                    Calendrier.HoraireParDefaut = (CHoraireJournalier)m_cmbxSelectHoraireDefaut.SelectedValue;
                else
                    Calendrier.HoraireParDefaut = null;
                InitCalendrier();
            }
        }


		//-----------------------------------------------------------------------------------
        private void AfficheDateEnCours()
		{
			m_bIsInitializing = true;
            m_lstDatesEnCours = m_wndCalendrier.DatesSelectionneesListe;

            m_jpDatePrecise = null;
            m_jpTousLesMois = null;
            m_jpTousLesAns = null;
            m_jpTousLesJourSemaine = null;
            m_jpMultiSelection.Clear();

            // Affiche ou masque les panels en fonction de la sélection de jours
            InitPanelsSingleMultiJP();
            //m_panelEditExceptions.Visible = false;

			int nNbJoursPart = 0;
			CCalendrier_JourParticulier jourToutSeul = null;

            if (m_lstDatesEnCours.Count == 1)
            {
                CCalendrier_JourParticulier exception = new CCalendrier_JourParticulier(Calendrier.ContexteDonnee);
                m_dateEnCours = m_wndCalendrier.DatesSelectionneesListe[0];

                // Traitement si single selection
                m_lblJoursSemaine.Text = I.T( "Every|412") + " " + CUtilDate.GetNomJour(m_dateEnCours.DayOfWeek, false);
                m_lblDatePrecise.Text = I.T( "The|413") + " " + m_dateEnCours.ToString("d");
                m_lblTousLesAns.Text = I.T( "Every|412") + " " + m_dateEnCours.Day.ToString("00") + "/" + m_dateEnCours.Month.ToString("00");
                m_lblTousLesMois.Text = I.T( "Every|412") + " " + m_dateEnCours.Day + " " + I.T( "of the month|414");


				exception = new CCalendrier_JourParticulier(Calendrier.ContexteDonnee);
                // Vérifie s'il existe une exception "jour/mois/année" sur le jour du calendrier sélectionné
                if (exception.ReadIfExists(new CFiltreData(
                    CCalendrier_JourParticulier.c_champAnnee + "=@1 and " +
                    CCalendrier_JourParticulier.c_champMois + "=@2 and " +
                    CCalendrier_JourParticulier.c_champJour + "=@3 and " +
                    CCalendrier.c_champId + "=@4",
                    m_dateEnCours.Year,
                    m_dateEnCours.Month,
                    m_dateEnCours.Day,
                    Calendrier.Id), false))
                {
                    m_radDatePreciseException.Checked = true;
                    m_jpDatePrecise = exception;
					nNbJoursPart++;
					jourToutSeul = exception;
                }
                else
                {
                    m_radDatePreciseDefaut.Checked = true;
                }

				exception = new CCalendrier_JourParticulier(Calendrier.ContexteDonnee);
                // Vérifie s'il existe une exception "jour/mois" sur le jour du calendrier sélectionné
                if (exception.ReadIfExists(new CFiltreData(
                    CCalendrier_JourParticulier.c_champAnnee + " is null and " +
                    CCalendrier_JourParticulier.c_champMois + "=@1 and " +
                    CCalendrier_JourParticulier.c_champJour + "=@2 and " +
                    CCalendrier.c_champId + "=@3",
                    m_dateEnCours.Month,
                    m_dateEnCours.Day,
                    Calendrier.Id), false))
                {
                    m_radAnException.Checked = true;
                    m_jpTousLesAns = exception;
					nNbJoursPart++;
					jourToutSeul = exception;
                }
                else
                {
                    m_radAnDefaut.Checked = true;
                }

				exception = new CCalendrier_JourParticulier(Calendrier.ContexteDonnee);
                // Vérifie s'il existe une exception "jour du mois" sur le jour du calendrier sélectionné
                if (exception.ReadIfExists(new CFiltreData(
                    CCalendrier_JourParticulier.c_champAnnee + " is null and " +
                    CCalendrier_JourParticulier.c_champMois + " is null and " +
                    CCalendrier_JourParticulier.c_champJour + "=@1 and " +
                    CCalendrier.c_champId + "=@2",
                    m_dateEnCours.Day,
                    Calendrier.Id), false))
                {
                    m_radMoisException.Checked = true;
                    m_jpTousLesMois = exception;
					nNbJoursPart++;
					jourToutSeul = exception;
                }
                else
                {
                    m_radMoisDefaut.Checked = true;
                }

				exception = new CCalendrier_JourParticulier(Calendrier.ContexteDonnee);
                // Vérifie s'il existe une exception "jour de semaine" sur le jour du calendrier sélectionné
                if (exception.ReadIfExists(new CFiltreData(
                    CCalendrier_JourParticulier.c_champAnnee + " is null and " +
                    CCalendrier_JourParticulier.c_champMois + " is null and " +
                    CCalendrier_JourParticulier.c_champJour + " is null and " +
                    CCalendrier_JourParticulier.c_champJourSemaine + "=@1 and " +
                    CCalendrier.c_champId + "=@2",
                    (int)CUtilDate.GetJourBinaireFor(m_dateEnCours.DayOfWeek),
                    Calendrier.Id), false))
                {
                    m_radJourSemaineException.Checked = true;
                    m_jpTousLesJourSemaine = exception;
					nNbJoursPart++;
					jourToutSeul = exception;
                }
                else
                    m_radJourSemaineDefaut.Checked = true;

				if (nNbJoursPart == 1 && jourToutSeul != null)
				{
					InitEditionJourParticulier(jourToutSeul);
					m_panelEditExceptions.Visible = true;
				}
            }
            else
            {
                // Traitement si multi sélection
                m_bMultiSelectionHomogene = true;

                // Vérifie s'il existe une exception "jour/mois/année" sur le premier jour sélectionné
                foreach (DateTime date in m_lstDatesEnCours)
                {
                    CCalendrier_JourParticulier exception = new CCalendrier_JourParticulier(Calendrier.ContexteDonnee);
                    // Vérifie s'il existe une exception "jour/mois/année" sur les autres jours sélectionnés
                    if (exception.ReadIfExists(new CFiltreData(
                        CCalendrier_JourParticulier.c_champAnnee + "=@1 and " +
                        CCalendrier_JourParticulier.c_champMois + "=@2 and " +
                        CCalendrier_JourParticulier.c_champJour + "=@3 and " +
                        CCalendrier.c_champId + "=@4",
                        date.Year,
                        date.Month,
                        date.Day,
                        Calendrier.Id), false))
                    {
                        m_jpMultiSelection.Add(exception);
                    }      
                }

                
                if (m_jpMultiSelection.Count == m_lstDatesEnCours.Count)
                {
                    m_bMultiSelectionHomogene = true;
                    m_radMultiSelectionException.Checked = true;
                    for (int i = 0; i < m_jpMultiSelection.Count; i++)
                    {
                        if (i > 0)
                        {
                            if (!m_jpMultiSelection[i].HasSameProperties(m_jpMultiSelection[0]))
                            {
                                m_bMultiSelectionHomogene = false;
                                break;
                            }
                        }
                    }
					if ( m_bMultiSelectionHomogene && m_jpMultiSelection.Count > 0)
						InitEditionJourParticulier(m_jpMultiSelection[0]);
                }
                else if (m_jpMultiSelection.Count == 0)
                {
                    m_bMultiSelectionHomogene = true;
                    m_radMultiSelectionDefaut.Checked = true;
                }
                else
                {
                    m_bMultiSelectionHomogene = false;
                    m_radMultiSelectionException.Checked = true;
                }

            }
			m_bIsInitializing = false;
		}
        
        //-------------------------------------------------------------------------------------------
		CCalendrier_JourParticulier m_jpDatePrecise,
                                    m_jpTousLesMois,
                                    m_jpTousLesAns,
                                    m_jpTousLesJourSemaine;

        List<CCalendrier_JourParticulier> m_jpMultiSelection = new List<CCalendrier_JourParticulier>();

		private void MajDateEnCours()
		{
			if ( !m_gestionnaireModeEdition.ModeEdition )
				return ;

			bool bHasChange = false;

            if (m_lstDatesEnCours.Count == 1)
            {
                m_dateEnCours = m_wndCalendrier.DatesSelectionneesListe[0];

                if (!m_radDatePreciseDefaut.Checked)
                {
                    if (m_jpDatePrecise == null)
                    {
                        m_jpDatePrecise = new CCalendrier_JourParticulier(Calendrier.ContexteDonnee);
                        m_jpDatePrecise.CreateNewInCurrentContexte();
                        m_jpDatePrecise.Calendrier = Calendrier;
                        m_jpDatePrecise.Jour = m_dateEnCours.Day;
                        m_jpDatePrecise.Mois = m_dateEnCours.Month;
                        m_jpDatePrecise.Annee = m_dateEnCours.Year;
                        m_jpDatePrecise.JourSemaine = 0;
                        bHasChange = true;
                        m_btnEditJMA_Click(m_btnEditJMA, new EventArgs());
                    }
                }
                else
                {
                    if (m_jpDatePrecise != null && m_jpDatePrecise.IsValide())
                    {
                        if (m_jpDatePrecise == m_jourParticulierEnCours)
                            m_jourParticulierEnCours = null;
                        m_jpDatePrecise.Delete();
                        m_jpDatePrecise = null;
                        InitEditionJourParticulier(null);
                        bHasChange = true;
                    }
                }

                if (!m_radMoisDefaut.Checked)
                {
                    if (m_jpTousLesMois == null)
                    {
                        m_jpTousLesMois = new CCalendrier_JourParticulier(Calendrier.ContexteDonnee);
                        m_jpTousLesMois.CreateNewInCurrentContexte();
                        m_jpTousLesMois.Calendrier = Calendrier;
                        m_jpTousLesMois.Jour = m_dateEnCours.Day;
                        m_jpTousLesMois.Mois = null;
                        m_jpTousLesMois.Annee = null;
                        m_jpTousLesMois.JourSemaine = 0;
                        bHasChange = true;
                        m_btnEditJ_Click(m_btnEditJ, new EventArgs());
                    }
                }
                else
                {
                    if (m_jpTousLesMois != null && m_jpTousLesMois.IsValide())
                    {
                        if (m_jpTousLesMois == m_jourParticulierEnCours)
                            m_jourParticulierEnCours = null;
                        m_jpTousLesMois.Delete();
                        InitEditionJourParticulier(null);
                        m_jpTousLesMois = null;
                        bHasChange = true;
                    }
                }

                if (!m_radAnDefaut.Checked)
                {
                    if (m_jpTousLesAns == null)
                    {
                        m_jpTousLesAns = new CCalendrier_JourParticulier(Calendrier.ContexteDonnee);
                        m_jpTousLesAns.CreateNewInCurrentContexte();
                        m_jpTousLesAns.Calendrier = Calendrier;
                        m_jpTousLesAns.Jour = m_dateEnCours.Day;
                        m_jpTousLesAns.Mois = m_dateEnCours.Month;
                        m_jpTousLesAns.Annee = null;
                        m_jpTousLesAns.JourSemaine = 0;
                        bHasChange = true;
                        m_btnEditJM_Click(m_btnEditJM, new EventArgs());
                    }
                }
                else
                {
                    if (m_jpTousLesAns != null && m_jpTousLesAns.IsValide())
                    {
                        if (m_jpTousLesAns == m_jourParticulierEnCours)
                            m_jourParticulierEnCours = null;
                        m_jpTousLesAns.Delete();
                        InitEditionJourParticulier(null);
                        m_jpTousLesAns = null;
                        bHasChange = true;
                    }
                }

                if (!m_radJourSemaineDefaut.Checked)
                {
                    if (m_jpTousLesJourSemaine == null)
                    {
                        m_jpTousLesJourSemaine = new CCalendrier_JourParticulier(Calendrier.ContexteDonnee);
                        m_jpTousLesJourSemaine.CreateNewInCurrentContexte();
                        m_jpTousLesJourSemaine.Calendrier = Calendrier;
                        m_jpTousLesJourSemaine.Jour = null;
                        m_jpTousLesJourSemaine.Mois = null;
                        m_jpTousLesJourSemaine.Annee = null;
                        m_jpTousLesJourSemaine.JourSemaine = CUtilDate.GetJourBinaireFor(m_dateEnCours.DayOfWeek);
                        bHasChange = true;
                        m_btnEditJS_Click(m_btnEditJS, new EventArgs());
                    }
                }
                else
                {
                    if (m_jpTousLesJourSemaine != null && m_jpTousLesJourSemaine.IsValide())
                    {
                        if (m_jpTousLesJourSemaine == m_jourParticulierEnCours)
                            m_jourParticulierEnCours = null;
                        m_jpTousLesJourSemaine.Delete();
                        InitEditionJourParticulier(null);
                        m_jpTousLesJourSemaine = null;
                        bHasChange = true;
                    }
                }


            }
            else
            {
                // Multi sélection gérée ici
                if (!m_radMultiSelectionDefaut.Checked)
                {
                    if (m_jpMultiSelection.Count == 0)
                    {
                        bHasChange = true;
                        m_btnEditMultiJP_Click(m_btnEditJMA, new EventArgs());
                    }
                }
                else // btn radio défaut checked
                {
                    if (m_jpMultiSelection.Count != 0)
                    {
                        // Supprimer tous les JP de type "jour/mois/année" sur chaque date sélectionnée
                        if(m_jourParticulierEnCours == m_jpMultiSelection[0])
                            m_jourParticulierEnCours = null;
                        CObjetDonneeAIdNumerique.Delete(m_jpMultiSelection.ToArray());
                        InitEditionJourParticulier(null);
                        m_jpMultiSelection.Clear();
                        bHasChange = true;
                    }
                }
            }

            if ( bHasChange )
				InitCalendrier();
			
		}


		//--------------------------------------------------------------
		private Color GetCouleurVisibleSur(Color c)
		{
			int nMoy = (c.R + c.B + c.G) / 3;
			if (nMoy < 128)
				return Color.White;
			else
				return Color.Black;
		}

		//--------------------------------------------------------------
		private CJourStyle GetStyleJour ( CTypeOccupationHoraire occupation)
		{
			Color c = Color.FromArgb ( occupation.Couleur );
			return new CJourStyle ( GetCouleurVisibleSur ( c ),c );
		}


		//-------------------------------------------------------------------------
		private void InitCalendrier ( CCalendrier calendrier )
		{
			if ( calendrier.CalendrierDeBase != null )
				InitCalendrier ( calendrier.CalendrierDeBase );

			foreach ( CCalendrier_JourParticulier jourParticulier in calendrier.JoursParticuliersListe )
			{
				AppliqueJourParticulier(jourParticulier);
			}
		
		}

		//-------------------------------------------------------------------------
		private void OnChangeSomethingNeedRefresh ( object obj, EventArgs args )
		{
            m_btnEditJS.Enabled = !m_radJourSemaineDefaut.Checked;
            m_btnEditJMA.Enabled = !m_radDatePreciseDefaut.Checked;
            m_btnEditJM.Enabled = !m_radAnDefaut.Checked;
            m_btnEditJ.Enabled = !m_radMoisDefaut.Checked;
            m_btnEditMultiJP.Enabled = !m_radMultiSelectionDefaut.Checked;


            if (m_btnEditJS.Enabled) m_lblJoursSemaine.BackColor = Color.DarkRed;
            else m_lblJoursSemaine.BackColor = Color.DarkGreen;

            if (m_btnEditJMA.Enabled) m_lblDatePrecise.BackColor = Color.DarkRed;
            else m_lblDatePrecise.BackColor = Color.DarkGreen;

            if (m_btnEditJM.Enabled) m_lblTousLesAns.BackColor = Color.DarkRed;
            else m_lblTousLesAns.BackColor = Color.DarkGreen;

            if (m_btnEditJ.Enabled) m_lblTousLesMois.BackColor = Color.DarkRed;
            else m_lblTousLesMois.BackColor = Color.DarkGreen;

            if (m_btnEditMultiJP.Enabled) m_lblMultiSelection.BackColor = Color.DarkRed;
            else m_lblMultiSelection.BackColor = Color.DarkGreen;

			if ( !m_bIsInitializing )
			{
				MajDateEnCours();
				InitCalendrier();
            }
		}


        //-------------------------------------------------------------------------
        private void m_btnEditJS_Click(object sender, EventArgs e)
        {
            if (m_jpTousLesJourSemaine != null && m_jpTousLesJourSemaine.IsValide())
            {
                // Init champs
                InitEditionJourParticulier(m_jpTousLesJourSemaine);
            }

        }


        //-------------------------------------------------------------------------
        private void m_btnEditJMA_Click(object sender, EventArgs e)
        {
            if (m_jpDatePrecise != null && m_jpDatePrecise.IsValide())
            {
                // Init champs
               InitEditionJourParticulier(m_jpDatePrecise);
            }
        }

        //-------------------------------------------------------------------------
        private void m_btnEditJM_Click(object sender, EventArgs e)
        {
            if (m_jpTousLesAns != null && m_jpTousLesAns.IsValide())
            {
				// Init champs
                InitEditionJourParticulier(m_jpTousLesAns);
            }

        }


        //-------------------------------------------------------------------------
        private void m_btnEditJ_Click(object sender, EventArgs e)
        {
            if (m_jpTousLesMois != null && m_jpTousLesMois.IsValide())
            {
				// Init champs
                InitEditionJourParticulier(m_jpTousLesMois);
            }
        }

        //-------------------------------------------------------------------------
        private void m_btnEditMultiJP_Click(object sender, EventArgs e)
        {
            if (m_gestionnaireModeEdition.ModeEdition)
            {
                if (!m_bMultiSelectionHomogene)
                {
                    if (ConfirmerMultiEdition())
                    {
                        CObjetDonneeAIdNumerique.Delete(m_jpMultiSelection.ToArray());
                        m_jpMultiSelection.Clear();
                    }
                    else
                        return;
                }
                if (m_jpMultiSelection.Count == 0)
                {
                    foreach (DateTime date in m_lstDatesEnCours)
                    {
                        CCalendrier_JourParticulier newJP = new CCalendrier_JourParticulier(Calendrier.ContexteDonnee);
                        newJP.CreateNewInCurrentContexte();
                        newJP.Calendrier = Calendrier;
                        newJP.Jour = date.Day;
                        newJP.Mois = date.Month;
                        newJP.Annee = date.Year;
                        newJP.JourSemaine = 0;
                        
                        m_jpMultiSelection.Add(newJP);
                    }
                }

            }
            // Init champs
            //m_cmbxSelectHoraireException.ElementSelectionne = m_jpMultiSelection[0].HoraireJournalier;
            if ( m_jpMultiSelection.Count > 0 )
				InitEditionJourParticulier(m_jpMultiSelection[0]);
            InitCalendrier();
       }

       //-------------------------------------------------------------------------
       private bool ConfirmerMultiEdition()
       {
            if (!m_bMultiSelectionHomogene)
            {
				DialogResult reponse = CFormAlerte.Afficher(I.T(
					"There are diferent Exceptions defined on the selecterd dates|424") + "\n" +
					I.T("Do you want to continue?|425"), EFormAlerteType.Question);

                if (reponse == DialogResult.No)
                    return false;

            }
            return true;
        }

        //-------------------------------------------------------------------------
        private void InitEditionJourParticulier(CCalendrier_JourParticulier jp)
        {
            if (jp != null)
            {
                m_jourParticulierEnCours = jp;

                if (jp.HoraireJournalier == null)
                {
                    m_lnkModifierJourParticulier.Visible = false;
                    m_controlEditJourParticulier.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
                    m_controlEditJourParticulier.InitChamps(jp);

                }
                else
                {
                    m_lnkModifierJourParticulier.Visible = true;
                    m_controlEditJourParticulier.LockEdition = true;
                    m_controlEditJourParticulier.InitChamps(jp.HoraireJournalier);
                }


                m_cmbxSelectHoraireException.ElementSelectionne = jp.HoraireJournalier;
                m_panelEditExceptions.Visible = true;
                m_panelEditExceptions.Focus();
                m_lblExceptionEdite.Text = jp.Libelle;
            }
            else
            {
                m_panelEditExceptions.Visible = false;
            }
			
        }

        //-------------------------------------------------------------------------
        private void m_panelEditExceptions_Leave(object sender, EventArgs e)
        {
            EnregistrerModifsJourParticulier();
            //m_panelEditExceptions.Visible = false;

        }

        //-------------------------------------------------------------------------
        private void EnregistrerModifsJourParticulier()
        {
            if (m_jourParticulierEnCours != null)
            {
                if (m_jourParticulierEnCours.Row.Row.RowState != DataRowState.Deleted)
                {
                    m_jourParticulierEnCours.HoraireJournalier = (CHoraireJournalier)m_cmbxSelectHoraireException.ElementSelectionne;
                    m_controlEditJourParticulier.MAJ_Champs();
                }
                if (m_jpMultiSelection.Count != 0)
                {
                    int nb = m_jourParticulierEnCours.TranchesHorairesListe.Count;
                    for (int i=0; i<m_jpMultiSelection.Count; i++)
                    {
                        m_jpMultiSelection[i].ApplySameProperties(m_jourParticulierEnCours);
						AppliqueJourParticulier ( m_jpMultiSelection[i] );
                    }
                }
				else
					AppliqueJourParticulier(m_jourParticulierEnCours);
				m_wndCalendrier.Refresh();
            }
        }

		//-------------------------------------------------------------------------
		private void AppliqueJourParticulier(CCalendrier_JourParticulier jourParticulier)
		{
			CJourStyle styleDefault = m_styleJourParticulier;
			if (Calendrier.TypeOccupationHoraireAppliquee != null)
				styleDefault = GetStyleJour(Calendrier.TypeOccupationHoraireAppliquee);
			CJourStyle style = styleDefault;
			if (jourParticulier.HoraireJournalier == null &&
				jourParticulier.TranchesHorairesListe.Count == 0 && 
				jourParticulier.TypeOccupationHoraire == null)
				style = m_styleSansHoraire;
			else
			{
				if (jourParticulier.TypeOccupationHoraireAppliquee != null)
					style = GetStyleJour(jourParticulier.TypeOccupationHoraireAppliquee);
			}

			if (jourParticulier.Annee == null)
			{
				if (jourParticulier.Mois == null)
				{
					if (jourParticulier.Jour == null)
					{
						//m_wndCalendrier.SetStyleJourMois(-1, m_styleJourDefaut);

						if (jourParticulier.JourSemaine != JoursBinaires.Aucun)
						{
							m_wndCalendrier.SetStyleJourSemaine(
								CUtilDate.GetDayOfWeekFor(jourParticulier.JourSemaine),
								style);
						}
					}
					else
					{
						m_wndCalendrier.SetStyleJourMois((int)jourParticulier.Jour, style);
					}
				}
				else
				{
					m_wndCalendrier.SetStyleJourAn((int)jourParticulier.Jour, (int)jourParticulier.Mois, style);
				}
			}
			else
			{
				m_wndCalendrier.SetStyleJour(new DateTime((int)jourParticulier.Annee, (int)jourParticulier.Mois, (int)jourParticulier.Jour), style);
			}
		}

        //-------------------------------------------------------------------------
        private void m_cmbxSelectHoraireException_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Si un horaire journalier est sélectionné, on supprim toutes les relations directes
            // avec les tranches horaires du jour particulier
            if (m_jourParticulierEnCours != null)
                m_jourParticulierEnCours.HoraireJournalier =
                    (CHoraireJournalier)m_cmbxSelectHoraireException.ElementSelectionne;

            if (m_cmbxSelectHoraireException.ElementSelectionne != null)
            {
                if (m_jourParticulierEnCours != null && m_jourParticulierEnCours.IsValide())
                {

                    foreach (CHoraireJournalier_Tranche tranche in m_jourParticulierEnCours.TranchesHorairesListe.ToArrayList())
                    {
                        if(tranche != null && tranche.IsValide())
                            tranche.Delete();
                    }
               }
            }

            InitEditionJourParticulier(m_jourParticulierEnCours);
        }

        //-------------------------------------------------------------------------
        private void m_lnkModifierJourParticulier_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (m_jourParticulierEnCours != null)
            {
                if (m_jourParticulierEnCours.HoraireJournalier != null)
                {
                    // Copie toutes les tranches horaires de l'Horaire Journalier vers le Jour particullier
                    foreach (CHoraireJournalier_Tranche tranche in m_jourParticulierEnCours.HoraireJournalier.TranchesHorairesListe)
                    {
                        CHoraireJournalier_Tranche newTranche = new CHoraireJournalier_Tranche(Calendrier.ContexteDonnee);
                        newTranche.CreateNewInCurrentContexte();
                        newTranche.JourParticulier = m_jourParticulierEnCours;
                        newTranche.HeureDebut = tranche.HeureDebut;
                        newTranche.HeureFin = tranche.HeureFin;
                        newTranche.TypeOccupationHoraire = tranche.TypeOccupationHoraire;
                    }
                    // Copie le type d'occupation horaire
                    m_jourParticulierEnCours.TypeOccupationHoraire = 
                        m_jourParticulierEnCours.HoraireJournalier.TypeOccupationHoraire;
					m_jourParticulierEnCours.HoraireJournalier = null;
                    m_cmbxSelectHoraireException.ElementSelectionne = null;
					InitEditionJourParticulier(m_jourParticulierEnCours);
                }
            }
        }

        //-------------------------------------------------------------------------
        private void CFormEditionCalendrier_BeforeValideModification(object sender, CObjetDonneeCancelEventArgs args)
        {
            EnregistrerModifsJourParticulier();
        }



	}
}

