using System;
using System.Collections;
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
using sc2i.documents;
using sc2i.process;
using sc2i.custom;
using sc2i.win32.data.dynamic;
using CrystalDecisions.CrystalReports.Engine;
using sc2i.multitiers.client;
using timos.data;
using sc2i.common.inventaire;

using System.Collections.Generic;
using sc2i.expression;
using sc2i.data.dynamic.Expressions;
using sc2i.data.dynamic.NommageEntite;
using sc2i.data.dynamic.Macro;
using timos.macro;
using timos.projet.besoin;
using timos.data.projet.besoin;
using timos.Controles;
using timos.securite;


namespace timos
{

	public class CFormEditionStdTimos : sc2i.win32.data.navigation.CFormEditionStandard, IFormNavigable
	{
		private System.Windows.Forms.ImageList m_imagesPostIt;
		private System.Windows.Forms.PictureBox m_btnPostIts;
		private System.Windows.Forms.ContextMenu m_menuPostIts;
		private System.Windows.Forms.MenuItem m_menuNouvellePostIt;
		private System.Windows.Forms.Button m_btnImportDonnees;
		private System.Windows.Forms.Button m_btnExportDonnee;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ImageList m_imagesGED;
		private System.Windows.Forms.Timer m_timerClignotant;
		private System.ComponentModel.IContainer components = null;
        
		private bool m_bHasGed = false;
		private bool m_bHasDossiers = false;
		private System.Windows.Forms.PictureBox m_btnGED;
		private bool m_bHasNotes = false;
		private System.Windows.Forms.PictureBox m_btnActions;
		private System.Windows.Forms.ContextMenuStrip m_menuActions;
		private System.Windows.Forms.ToolTip m_tooltip;
		private System.Windows.Forms.PictureBox m_btnImprimer;
		private System.Windows.Forms.ContextMenu m_menuImpression;
		private System.Windows.Forms.MenuItem m_menuImpressionEcran;
        private System.Windows.Forms.MenuItem m_menuImpressionEtat;
		private System.Windows.Forms.PictureBox m_btnDossiers;
		private System.Windows.Forms.ImageList m_imagesDossiers;
        private Timer m_timerInitChampAfterRunEvent;
        protected CExtModulesAssociator m_extModulesAssociator;
        private Panel m_panelContientSatisfaction;
        private CControlePourResumeSatisfaction m_ctrlResumeSatisfaction;
		private bool m_bBasculeClignotant = false;

		public CFormEditionStdTimos()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionStdTimos(CObjetDonneeAIdNumeriqueAuto objet)
			:base(objet)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionStdTimos(CObjetDonneeAIdNumeriqueAuto objet, CListeObjetsDonnees liste)
			:base(objet, liste)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionStdTimos));
            this.m_imagesPostIt = new System.Windows.Forms.ImageList(this.components);
            this.m_btnPostIts = new System.Windows.Forms.PictureBox();
            this.m_menuPostIts = new System.Windows.Forms.ContextMenu();
            this.m_menuNouvellePostIt = new System.Windows.Forms.MenuItem();
            this.m_btnImportDonnees = new System.Windows.Forms.Button();
            this.m_btnExportDonnee = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.m_btnGED = new System.Windows.Forms.PictureBox();
            this.m_imagesGED = new System.Windows.Forms.ImageList(this.components);
            this.m_timerClignotant = new System.Windows.Forms.Timer(this.components);
            this.m_btnActions = new System.Windows.Forms.PictureBox();
            this.m_menuActions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.m_btnImprimer = new System.Windows.Forms.PictureBox();
            this.m_btnDossiers = new System.Windows.Forms.PictureBox();
            this.m_menuImpression = new System.Windows.Forms.ContextMenu();
            this.m_menuImpressionEcran = new System.Windows.Forms.MenuItem();
            this.m_menuImpressionEtat = new System.Windows.Forms.MenuItem();
            this.m_imagesDossiers = new System.Windows.Forms.ImageList(this.components);
            this.m_timerInitChampAfterRunEvent = new System.Windows.Forms.Timer(this.components);
            this.m_extModulesAssociator = new timos.CExtModulesAssociator();
            this.m_panelContientSatisfaction = new System.Windows.Forms.Panel();
            this.m_ctrlResumeSatisfaction = new timos.projet.besoin.CControlePourResumeSatisfaction();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnPostIts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnGED)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnActions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnImprimer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnDossiers)).BeginInit();
            this.m_panelContientSatisfaction.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnAnnulerModifications
            // 
            this.m_extLinkField.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnAnnulerModifications, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAnnulerModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_btnAnnulerModifications, "");
            this.m_extStyle.SetStyleBackColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnValiderModifications
            // 
            this.m_extLinkField.SetLinkField(this.m_btnValiderModifications, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnValiderModifications, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnValiderModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_btnValiderModifications, "");
            this.m_extStyle.SetStyleBackColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnSupprimerObjet
            // 
            this.m_extLinkField.SetLinkField(this.m_btnSupprimerObjet, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnSupprimerObjet, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnSupprimerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_btnSupprimerObjet, "");
            this.m_extStyle.SetStyleBackColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnEditerObjet
            // 
            this.m_extLinkField.SetLinkField(this.m_btnEditerObjet, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnEditerObjet, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnEditerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_btnEditerObjet, "");
            this.m_extStyle.SetStyleBackColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelNavigation
            // 
            this.m_panelNavigation.Location = new System.Drawing.Point(618, 0);
            this.m_extModulesAssociator.SetModules(this.m_panelNavigation, "");
            this.m_extStyle.SetStyleBackColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_lblNbListes
            // 
            this.m_extModulesAssociator.SetModules(this.m_lblNbListes, "");
            this.m_extStyle.SetStyleBackColor(this.m_lblNbListes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblNbListes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnPrecedent
            // 
            this.m_extModulesAssociator.SetModules(this.m_btnPrecedent, "");
            this.m_extStyle.SetStyleBackColor(this.m_btnPrecedent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnPrecedent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnSuivant
            // 
            this.m_extModulesAssociator.SetModules(this.m_btnSuivant, "");
            this.m_extStyle.SetStyleBackColor(this.m_btnSuivant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSuivant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnAjout
            // 
            this.m_extModulesAssociator.SetModules(this.m_btnAjout, "");
            this.m_extStyle.SetStyleBackColor(this.m_btnAjout, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAjout, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_lblId
            // 
            this.m_extModulesAssociator.SetModules(this.m_lblId, "");
            this.m_extStyle.SetStyleBackColor(this.m_lblId, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblId, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelCle
            // 
            this.m_panelCle.Location = new System.Drawing.Point(510, 0);
            this.m_extModulesAssociator.SetModules(this.m_panelCle, "");
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Controls.Add(this.m_panelContientSatisfaction);
            this.m_panelMenu.Controls.Add(this.m_btnDossiers);
            this.m_panelMenu.Controls.Add(this.m_btnImprimer);
            this.m_panelMenu.Controls.Add(this.m_btnActions);
            this.m_panelMenu.Controls.Add(this.m_btnGED);
            this.m_panelMenu.Controls.Add(this.m_btnPostIts);
            this.m_extModulesAssociator.SetModules(this.m_panelMenu, "");
            this.m_panelMenu.Size = new System.Drawing.Size(793, 32);
            this.m_extStyle.SetStyleBackColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelMenu.Controls.SetChildIndex(this.m_btnAjout, 0);
            this.m_panelMenu.Controls.SetChildIndex(this.m_panelNavigation, 0);
            this.m_panelMenu.Controls.SetChildIndex(this.m_panelCle, 0);
            this.m_panelMenu.Controls.SetChildIndex(this.m_btnAnnulerModifications, 0);
            this.m_panelMenu.Controls.SetChildIndex(this.m_btnValiderModifications, 0);
            this.m_panelMenu.Controls.SetChildIndex(this.m_btnSupprimerObjet, 0);
            this.m_panelMenu.Controls.SetChildIndex(this.m_btnEditerObjet, 0);
            this.m_panelMenu.Controls.SetChildIndex(this.m_btnPostIts, 0);
            this.m_panelMenu.Controls.SetChildIndex(this.m_btnGED, 0);
            this.m_panelMenu.Controls.SetChildIndex(this.m_btnActions, 0);
            this.m_panelMenu.Controls.SetChildIndex(this.m_btnImprimer, 0);
            this.m_panelMenu.Controls.SetChildIndex(this.m_btnDossiers, 0);
            this.m_panelMenu.Controls.SetChildIndex(this.m_panelContientSatisfaction, 0);
            // 
            // m_btnHistorique
            // 
            this.m_extModulesAssociator.SetModules(this.m_btnHistorique, "");
            this.m_extStyle.SetStyleBackColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_imageCle
            // 
            this.m_extModulesAssociator.SetModules(this.m_imageCle, "");
            this.m_extStyle.SetStyleBackColor(this.m_imageCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_imageCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnChercherObjet
            // 
            this.m_extModulesAssociator.SetModules(this.m_btnChercherObjet, "");
            this.m_extStyle.SetStyleBackColor(this.m_btnChercherObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnChercherObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_imagesPostIt
            // 
            this.m_imagesPostIt.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imagesPostIt.ImageStream")));
            this.m_imagesPostIt.TransparentColor = System.Drawing.Color.Empty;
            this.m_imagesPostIt.Images.SetKeyName(0, "note 0.png");
            this.m_imagesPostIt.Images.SetKeyName(1, "note 1.png");
            // 
            // m_btnPostIts
            // 
            this.m_btnPostIts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnPostIts.Image = global::timos.Properties.Resources.note_01;
            this.m_extLinkField.SetLinkField(this.m_btnPostIts, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnPostIts, false);
            this.m_btnPostIts.Location = new System.Drawing.Point(380, 1);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnPostIts, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnPostIts, "");
            this.m_btnPostIts.Name = "m_btnPostIts";
            this.m_btnPostIts.Size = new System.Drawing.Size(24, 28);
            this.m_btnPostIts.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_extStyle.SetStyleBackColor(this.m_btnPostIts, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnPostIts, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnPostIts.TabIndex = 4001;
            this.m_btnPostIts.TabStop = false;
            this.m_tooltip.SetToolTip(this.m_btnPostIts, "Notes");
            this.m_btnPostIts.Visible = false;
            this.m_btnPostIts.Click += new System.EventHandler(this.m_btnPostIts_Click);
            // 
            // m_menuPostIts
            // 
            this.m_menuPostIts.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.m_menuNouvellePostIt});
            // 
            // m_menuNouvellePostIt
            // 
            this.m_menuNouvellePostIt.Index = 0;
            this.m_menuNouvellePostIt.Text = "<<New note>>|30098";
            this.m_menuNouvellePostIt.Click += new System.EventHandler(this.m_menuNouvellePostIt_Click);
            // 
            // m_btnImportDonnees
            // 
            this.m_extLinkField.SetLinkField(this.m_btnImportDonnees, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnImportDonnees, false);
            this.m_btnImportDonnees.Location = new System.Drawing.Point(536, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnImportDonnees, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_btnImportDonnees, "");
            this.m_btnImportDonnees.Name = "m_btnImportDonnees";
            this.m_btnImportDonnees.Size = new System.Drawing.Size(24, 16);
            this.m_extStyle.SetStyleBackColor(this.m_btnImportDonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnImportDonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnImportDonnees.TabIndex = 4001;
            this.m_btnImportDonnees.TabStop = false;
            this.m_btnImportDonnees.Text = "Object &Import |30099";
            this.m_btnImportDonnees.Click += new System.EventHandler(this.m_btnImportDonnees_Click);
            // 
            // m_btnExportDonnee
            // 
            this.m_extLinkField.SetLinkField(this.m_btnExportDonnee, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnExportDonnee, false);
            this.m_btnExportDonnee.Location = new System.Drawing.Point(560, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnExportDonnee, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_btnExportDonnee, "");
            this.m_btnExportDonnee.Name = "m_btnExportDonnee";
            this.m_btnExportDonnee.Size = new System.Drawing.Size(24, 16);
            this.m_extStyle.SetStyleBackColor(this.m_btnExportDonnee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnExportDonnee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnExportDonnee.TabIndex = 4002;
            this.m_btnExportDonnee.TabStop = false;
            this.m_btnExportDonnee.Text = "Object &Export |30100";
            this.m_btnExportDonnee.Click += new System.EventHandler(this.m_btnExportDonnee_Click);
            // 
            // label1
            // 
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label1, false);
            this.label1.Location = new System.Drawing.Point(88, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label1, "");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(336, 24);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4003;
            this.label1.Text = "There is two hidden buttons over there for data import and export shortcuts|166";
            this.label1.Visible = false;
            // 
            // m_btnGED
            // 
            this.m_btnGED.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnGED.Image = global::timos.Properties.Resources.document;
            this.m_extLinkField.SetLinkField(this.m_btnGED, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnGED, false);
            this.m_btnGED.Location = new System.Drawing.Point(409, 1);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnGED, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnGED, "");
            this.m_btnGED.Name = "m_btnGED";
            this.m_btnGED.Size = new System.Drawing.Size(24, 28);
            this.m_btnGED.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_extStyle.SetStyleBackColor(this.m_btnGED, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnGED, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnGED.TabIndex = 4002;
            this.m_btnGED.TabStop = false;
            this.m_tooltip.SetToolTip(this.m_btnGED, "EDM documents");
            this.m_btnGED.Visible = false;
            this.m_btnGED.Click += new System.EventHandler(this.m_btnGED_Click);
            // 
            // m_imagesGED
            // 
            this.m_imagesGED.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imagesGED.ImageStream")));
            this.m_imagesGED.TransparentColor = System.Drawing.Color.Empty;
            this.m_imagesGED.Images.SetKeyName(0, "document.png");
            this.m_imagesGED.Images.SetKeyName(1, "liste.png");
            // 
            // m_timerClignotant
            // 
            this.m_timerClignotant.Interval = 500;
            this.m_timerClignotant.Tick += new System.EventHandler(this.m_timerClignotant_Tick);
            // 
            // m_btnActions
            // 
            this.m_btnActions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnActions.Image = global::timos.Properties.Resources.Action;
            this.m_extLinkField.SetLinkField(this.m_btnActions, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnActions, false);
            this.m_btnActions.Location = new System.Drawing.Point(270, 1);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnActions, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnActions, "");
            this.m_btnActions.Name = "m_btnActions";
            this.m_btnActions.Size = new System.Drawing.Size(28, 28);
            this.m_btnActions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_extStyle.SetStyleBackColor(this.m_btnActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnActions.TabIndex = 4003;
            this.m_btnActions.TabStop = false;
            this.m_tooltip.SetToolTip(this.m_btnActions, "Actions");
            this.m_btnActions.Click += new System.EventHandler(this.m_btnActions_Click);
            // 
            // m_menuActions
            // 
            this.m_extLinkField.SetLinkField(this.m_menuActions, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_menuActions, true);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_menuActions, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_menuActions, "");
            this.m_menuActions.Name = "m_menuActions";
            this.m_menuActions.Size = new System.Drawing.Size(61, 4);
            this.m_extStyle.SetStyleBackColor(this.m_menuActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_menuActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnImprimer
            // 
            this.m_btnImprimer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnImprimer.Image = global::timos.Properties.Resources.printer;
            this.m_extLinkField.SetLinkField(this.m_btnImprimer, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnImprimer, false);
            this.m_btnImprimer.Location = new System.Drawing.Point(304, 1);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnImprimer, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_btnImprimer, "");
            this.m_btnImprimer.Name = "m_btnImprimer";
            this.m_btnImprimer.Size = new System.Drawing.Size(24, 28);
            this.m_btnImprimer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_extStyle.SetStyleBackColor(this.m_btnImprimer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnImprimer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnImprimer.TabIndex = 4005;
            this.m_btnImprimer.TabStop = false;
            this.m_tooltip.SetToolTip(this.m_btnImprimer, "Print");
            this.m_btnImprimer.Click += new System.EventHandler(this.m_btnImprimer_Click);
            // 
            // m_btnDossiers
            // 
            this.m_btnDossiers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnDossiers.Image = global::timos.Properties.Resources.folder;
            this.m_extLinkField.SetLinkField(this.m_btnDossiers, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnDossiers, false);
            this.m_btnDossiers.Location = new System.Drawing.Point(439, 1);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnDossiers, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_btnDossiers, "");
            this.m_btnDossiers.Name = "m_btnDossiers";
            this.m_btnDossiers.Size = new System.Drawing.Size(28, 28);
            this.m_btnDossiers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_extStyle.SetStyleBackColor(this.m_btnDossiers, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnDossiers, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnDossiers.TabIndex = 4007;
            this.m_btnDossiers.TabStop = false;
            this.m_tooltip.SetToolTip(this.m_btnDossiers, "Worbooks");
            this.m_btnDossiers.Click += new System.EventHandler(this.m_btnDossiers_Click);
            // 
            // m_menuImpression
            // 
            this.m_menuImpression.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.m_menuImpressionEcran,
            this.m_menuImpressionEtat});
            // 
            // m_menuImpressionEcran
            // 
            this.m_menuImpressionEcran.Index = 0;
            this.m_menuImpressionEcran.Text = "Print screen|30104";
            this.m_menuImpressionEcran.Click += new System.EventHandler(this.m_menuImpressionEcran_Click);
            // 
            // m_menuImpressionEtat
            // 
            this.m_menuImpressionEtat.Index = 1;
            this.m_menuImpressionEtat.Text = "State|30105";
            // 
            // m_imagesDossiers
            // 
            this.m_imagesDossiers.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imagesDossiers.ImageStream")));
            this.m_imagesDossiers.TransparentColor = System.Drawing.Color.Empty;
            this.m_imagesDossiers.Images.SetKeyName(0, "folder.png");
            this.m_imagesDossiers.Images.SetKeyName(1, "folder_open.png");
            // 
            // m_timerInitChampAfterRunEvent
            // 
            this.m_timerInitChampAfterRunEvent.Interval = 1500;
            this.m_timerInitChampAfterRunEvent.Tick += new System.EventHandler(this.m_timerInitChampAfterRunEvent_Tick);
            // 
            // m_panelContientSatisfaction
            // 
            this.m_panelContientSatisfaction.Controls.Add(this.m_ctrlResumeSatisfaction);
            this.m_panelContientSatisfaction.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_extLinkField.SetLinkField(this.m_panelContientSatisfaction, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelContientSatisfaction, false);
            this.m_panelContientSatisfaction.Location = new System.Drawing.Point(473, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelContientSatisfaction, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelContientSatisfaction, "");
            this.m_panelContientSatisfaction.Name = "m_panelContientSatisfaction";
            this.m_panelContientSatisfaction.Size = new System.Drawing.Size(37, 32);
            this.m_extStyle.SetStyleBackColor(this.m_panelContientSatisfaction, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelContientSatisfaction, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelContientSatisfaction.TabIndex = 4009;
            this.m_panelContientSatisfaction.Visible = false;
            // 
            // m_ctrlResumeSatisfaction
            // 
            this.m_ctrlResumeSatisfaction.AllowDrop = true;
            this.m_extLinkField.SetLinkField(this.m_ctrlResumeSatisfaction, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_ctrlResumeSatisfaction, false);
            this.m_ctrlResumeSatisfaction.Location = new System.Drawing.Point(4, 2);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_ctrlResumeSatisfaction, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_ctrlResumeSatisfaction, "");
            this.m_ctrlResumeSatisfaction.Name = "m_ctrlResumeSatisfaction";
            this.m_ctrlResumeSatisfaction.Size = new System.Drawing.Size(28, 28);
            this.m_extStyle.SetStyleBackColor(this.m_ctrlResumeSatisfaction, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_ctrlResumeSatisfaction, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ctrlResumeSatisfaction.TabIndex = 0;
            // 
            // CFormEditionStdTimos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(793, 400);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_btnImportDonnees);
            this.Controls.Add(this.m_btnExportDonnee);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionStdTimos";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.ObjetEditeChanged += new System.EventHandler(this.CFormEditionStdTimos_ObjetEditeChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.CFormEditionStdTimos_Closing);
            this.Load += new System.EventHandler(this.CFormEditionStdTimos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CFormEditionStdTimos_KeyDown);
            this.Controls.SetChildIndex(this.m_btnExportDonnee, 0);
            this.Controls.SetChildIndex(this.m_btnImportDonnees, 0);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnPostIts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnGED)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnActions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnImprimer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnDossiers)).EndInit();
            this.m_panelContientSatisfaction.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion


		//-------------------------------------------------------------------------
		private CListeObjetsDonnees ListePostIt
		{
			get
			{
				CListeObjetsDonnees liste = new CListeObjetsDonnees ( CSc2iWin32DataClient.ContexteCourant, typeof(CPostIt) );
				liste.Filtre = new CFiltreData ( 
					"("+CPostIt.c_champDateFin+">@1 or "+CPostIt.c_champDateFin+" is null) and "+
					CPostIt.c_champTypeElementLie+"=@2 and "+
					CPostIt.c_champIdElement+"=@3",
					DateTime.Now,
					ObjetEdite.GetType().ToString(),
					ObjetEdite.Id);
				return liste;
			}
		}


		//-------------------------------------------------------------------------
		private CListeObjetsDonnees ListeGed 
		{
			get
			{
				CListeObjetsDonnees liste = CDocumentGED.GetListeDocumentsForElement ( ObjetEdite );
				return liste;
			}
		}

		//-------------------------------------------------------------------------
		private CListeObjetsDonnees ListeDossiers 
		{
			get
			{
				CListeObjetsDonnees liste = CDossierSuivi.GetListeDossiersForElement ( ObjetEdite );
				return liste;
			}
		}

		private delegate void InitBoutonsClignotantsDelegate();

		private void InitBoutonsClignotants()
		{
#if DEBUG
            //m_btnTestInventaire.Visible = true;
#endif
            if (ObjetEdite == null || ObjetEdite.IsNew())
            {
                m_btnPostIts.Visible = false;
                m_btnGED.Visible = false;
                m_btnActions.Visible = false;
            }
            else
            {
                m_btnPostIts.Visible = true;
                m_btnGED.Visible = true;
                m_btnActions.Visible = true;
                m_bHasNotes = false;

                try
                {
                    if (ListePostIt.CountNoLoad > 0)
                    {
                        m_bHasNotes = true;
                        ShowPostIts();
                    }
                    m_bHasGed = false;
                    if (ListeGed.CountNoLoad > 0)
                        m_bHasGed = true;
                    m_bHasDossiers = false;
                    if (ListeDossiers.CountNoLoad > 0)
                        m_bHasDossiers = true;

                    //S'il n'existe aucun type de dossier pour le type de l'élément, le bouton
                    //AJoute est masqué.
                    CListeObjetsDonnees liste = new CListeObjetsDonnees(CSc2iWin32DataClient.ContexteCourant, typeof(CTypeDossierSuivi));
                    liste.Filtre = new CFiltreData(CTypeDossierSuivi.c_champTypeSuivi + "=@1",
                        ObjetEdite.GetType().ToString());
                    bool bHasDossiers = false;
                    foreach (CTypeDossierSuivi typeDossier in liste)
                    {
                        if (typeDossier.FiltreDynamiqueElementsSuivisPossibles == null)
                        {
                            bHasDossiers = true;
                            break;
                        }

                        CResultAErreur resultFiltre = typeDossier.FiltreDynamiqueElementsSuivisPossibles.GetFiltreData();
                        if (!resultFiltre)
                        {
                            bHasDossiers = true;
                            break;
                        }
                        CFiltreData filtre = CFiltreData.GetAndFiltre((CFiltreData)resultFiltre.Data, new CFiltreData(ObjetEdite.GetChampId() + "=@1", ObjetEdite.Id));
                        CListeObjetsDonnees lstPoubelle = new CListeObjetsDonnees(ObjetEdite.ContexteDonnee, ObjetEdite.GetType(), filtre);
                        if (lstPoubelle.Count != 0)
                        {
                            bHasDossiers = true;
                            break;
                        }
                    }
                    m_btnDossiers.Visible = bHasDossiers;
                    m_lastObjet = ObjetEdite;

                    
                

                }
                catch { }
            }
            

            m_btnGED.Image = m_imagesGED.Images[m_bHasGed ? 1 : 0];
            m_btnDossiers.Image = m_imagesDossiers.Images[m_bHasDossiers ? 1 : 0];
            m_btnPostIts.Image = m_imagesPostIt.Images[m_bHasNotes ? 1 : 0];

		    if ( m_bHasGed || m_bHasNotes || m_bHasDossiers)
			    m_timerClignotant.Enabled = true;;
		}
		
		//-------------------------------------------------------------------------
		private CObjetDonnee m_lastObjet = null;
		protected override CResultAErreur MyInitChamps()
		{
            if (GetObjetEdite() != null)
            {
                CListeRestrictionsUtilisateurSurType restrictions = CDroitEditionType.GetDroits(GetObjetEdite());
                AddRestrictionComplementaire("RESTRICTION_EDITION", restrictions, false);
            }

            if (!ModeEdition && ObjetEdite.ContexteDonnee.ContextePrincipal != null && !ObjetEdite.IsNew() &&
                CTimosApp.Navigateur == CFormMain.GetInstance())
            {
                CResultAErreur result = CResultAErreur.True;
                result.EmpileErreur(I.T("Timos has detected an inconsistency in the data context manager, you may lose the work that can be done after this message. We recommend that you close Timos and re-ouvir. Thank you to share this information with Futurocom and indicate the circumstances that led you to this message.|20741"));
                CFormAlerte.Afficher(result.Erreur);
            }
            if (CTimosApp.SessionClient.IsInTransaction() && CTimosApp.Navigateur == CFormMain.GetInstance())
            {
                CResultAErreur result = CResultAErreur.True;
                result.EmpileErreur(I.T("Timos has detected an inconsistency in the transaction manager, you may lose the work that can be done after this message. We recommend that you close Timos and re-ouvir. Thank you to share this information with Futurocom and indicate the circumstances that led you to this message.|20742"));
                CFormAlerte.Afficher(result.Erreur);
            }
                
            using (CWaitCursor waiter = new CWaitCursor())
            {
                CResultAErreur result = base.MyInitChamps();
                if (result)
                {
                    if (IsHandleCreated && !ObjetEdite.Equals(m_lastObjet))
                        BeginInvoke(new InitBoutonsClignotantsDelegate(InitBoutonsClignotants));

                }
                ISatisfactionBesoin satisfaction = ObjetEdite as ISatisfactionBesoin;
                m_panelContientSatisfaction.Visible = satisfaction != null;
                if (satisfaction != null)
                    m_ctrlResumeSatisfaction.Init(satisfaction, m_gestionnaireModeEdition.ModeEdition);
                return result;
            }
		}

		//-------------------------------------------------------------------------
		private void ShowPostIts()
		{
			foreach ( CPostIt postIt in ListePostIt )
			{
				bool bShouldAffiche = true;
				foreach ( Control ctrl in Controls )
				{
					if ( ctrl is CWndPostit && ((CWndPostit)ctrl).PostIt.Id == postIt.Id )
					{
						bShouldAffiche = false;
						break;
					}
				}
				if ( bShouldAffiche )
					CWndPostit.ShowPostIt ( this, postIt, false );
			}
		}

		private class CMenuItemPostIt : MenuItem
		{
			public readonly CPostIt PostIt;

			public CMenuItemPostIt (CPostIt postit )
				:base ( postit.Titre )
			{
				PostIt = postit;
			}
            
		}
		//-------------------------------------------------------------------------
		private void m_btnPostIts_Click(object sender, System.EventArgs e)
		{
			for ( int nItem = m_menuPostIts.MenuItems.Count-1; nItem >= 1; nItem-- )
				m_menuPostIts.MenuItems.RemoveAt ( nItem );
			foreach ( CPostIt postIt in ListePostIt )
			{
				CMenuItemPostIt menuItem = new CMenuItemPostIt ( postIt );
				m_menuPostIts.MenuItems.Add ( menuItem );
				menuItem.Click += new EventHandler ( OnClickMenuPostIts );
			}
			m_menuPostIts.Show ( m_btnPostIts, new Point ( 0, m_btnPostIts.Height ) );
		}

		//-------------------------------------------------------------------------
		private void OnClickMenuPostIts ( object sender, EventArgs args )
		{
			if ( sender is CMenuItemPostIt )
			{
				CPostIt postit = ((CMenuItemPostIt)sender).PostIt;
				foreach ( Control control in Controls )
				{
					if ( control is CWndPostit && ((CWndPostit)control).PostIt.Id == postit.Id )
					{
						control.BringToFront();
						control.Focus();
						return;
					}
				}
				CWndPostit.ShowPostIt ( this, postit, true );
			}
		}

		//-------------------------------------------------------------------------
		private void CFormEditionStdTimos_ObjetEditeChanged(object sender, System.EventArgs e)
		{
			foreach ( Control ctrl in Controls )
			{
				if ( ctrl is CWndPostit && (((CWndPostit)ctrl).PostIt.IdElementLie != ObjetEdite.Id ||
					ObjetEdite == null ))
				{
					((CWndPostit)ctrl).Close();
				}
			}
		}

		//-------------------------------------------------------------------------
		private void m_menuNouvellePostIt_Click(object sender, System.EventArgs e)
		{
			if ( ObjetEdite == null )
				return;
			CPostIt postit = new CPostIt ( CSc2iWin32DataClient.ContexteCourant );
			postit.CreateNew();
			postit.Titre = I.T("New note|30106");
			postit.ElementLie = ObjetEdite;
			CWndPostit.ShowPostIt (	this, postit, true );
		}

		//-------------------------------------------------------------------------
		private void CFormEditionStdTimos_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			foreach ( Control control in Controls )
			{
				if ( control is CWndPostit )
					((CWndPostit)control).AssureSauvegarde();
			}
		}


		//-------------------------------------------------------------------------
		private void m_btnExportDonnee_Click(object sender, System.EventArgs e)
		{
            if ((ModifierKeys & Keys.Alt) != Keys.Alt)
                return;
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Title = I.T("Object export|30107");
			dlg.Filter = "SC2I Object|*.2iExportObjet";
            //dlg.FileName = ObjetEdite.DescriptionElement + ".2iExportObjet";
			if ( dlg.ShowDialog() == DialogResult.OK )
			{
				CResultAErreur result = CResultAErreur.True;
				try
				{
					DataSet ds = new DataSet();
					result = new CValiseImportExport().CreateValise ( ObjetEdite, ds );
					if ( result )
					{
						ds.WriteXml ( dlg.FileName, XmlWriteMode.WriteSchema );
					}
				}
				catch ( Exception exe )
				{
					result.EmpileErreur ( new CErreurException ( exe ) );
				}
				if ( !result )
					CFormAlerte.Afficher ( result.Erreur );
			}
		}

		//-------------------------------------------------------------------------
		private void m_btnImportDonnees_Click(object sender, System.EventArgs e)
		{
            if ((ModifierKeys & Keys.Alt) != Keys.Alt)
                return;
			if ( !m_gestionnaireModeEdition.ModeEdition )
				return;
			if ( CFormAlerte.Afficher(I.T("Import an object ?|30108"), EFormAlerteType.Question) == DialogResult.No )
				return;
			CResultAErreur result = CResultAErreur.True;
			OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "SC2I Object|*.2iExportObjet";
			if ( dlg.ShowDialog() != DialogResult.OK )
				return;
			DataSet ds = new DataSet();
			try
			{
				ds.ReadXml ( dlg.FileName, XmlReadMode.ReadSchema );
			}
			catch ( Exception exe )
			{
				result.EmpileErreur ( new CErreurException ( exe ) );
			}
			if ( !result )
			{
				CFormAlerte.Afficher ( result.Erreur );
				return;
			}
			if ( ! CFormImportObjetDonnee.Importe ( ObjetEdite, ds ) )
			{
				OnClickAnnuler();
			}
			else
				InitChamps();
		}

		//-------------------------------------------------------------------------
		private void m_timerClignotant_Tick(object sender, System.EventArgs e)
		{
			m_timerClignotant.Stop();

          
            m_bBasculeClignotant = !m_bBasculeClignotant;
            //if ( m_bHasGed )
            //    m_btnGED.Image = m_imagesGED.Images[m_bBasculeClignotant?1:0];
			if ( m_bHasNotes )
				m_btnPostIts.Image = m_imagesPostIt.Images[m_bBasculeClignotant?1:0];
            //if ( m_bHasDossiers )
            //    m_btnDossiers.Image = m_imagesDossiers.Images[m_bBasculeClignotant?1:0];
			
            //if ( m_bBasculeClignotant )
            //    m_timerClignotant.Interval = 200;
            //else
            m_timerClignotant.Interval = 500;
            
			m_timerClignotant.Start();
				
		}

		//-------------------------------------------------------------------------
		private void m_btnGED_Click(object sender, System.EventArgs e)
		{
			CTimosApp.Navigateur.AffichePage ( new CFormNavigationGED ( ObjetEdite ) );
		}

		private class CMenuItemDeclencheur : MenuItem
		{
			public readonly IDeclencheurAction Declencheur;
			public CMenuItemDeclencheur ( IDeclencheurAction declencheur )
			{
				Declencheur = declencheur;
				Text = declencheur.Libelle;
			}
		}

        private class CMenuItemMacros : MenuItem
        {
            public readonly CMacro Macro;

            public CMenuItemMacros(CMacro macro)
                : base(macro.Libelle)
            {
                Macro = macro;
            }
        }

		//-------------------------------------------------------------------------
		private void m_btnActions_Click(object sender, System.EventArgs e)
		{
            CUtilMenuActionSurElement.InitMenuActions(ObjetEdite, m_menuActions.Items, new MenuActionEventHandler(MenuDeclencheurClick));
			/*m_menuActions.MenuItems.Clear();
			IDeclencheurAction[] declencheurs = CRecuperateurDeclencheursActions.GetActionsManuelles ( ObjetEdite, true );
            if (declencheurs.Length != 0)
            {

                foreach (IDeclencheurAction declencheur in declencheurs)
                {
                    string strMenu = "";
                    if (declencheur is IDeclencheurActionManuelle)
                        strMenu = ((IDeclencheurActionManuelle)declencheur).MenuManuel;
                    string[] strMenus = strMenu.Split('/');
                    Menu.MenuItemCollection listeSousMenus = m_menuActions.MenuItems;
                    if (strMenus.Length > 0)
                    {
                        foreach (string strSousMenu in strMenus)
                        {
                            if (strSousMenu.Trim().Length > 0)
                            {
                                MenuItem sousMenu = null;
                                foreach (MenuItem item in listeSousMenus)
                                    if (item.Text == strSousMenu)
                                    {
                                        sousMenu = item;
                                        break;
                                    }
                                if (sousMenu == null)
                                {
                                    sousMenu = new MenuItem(strSousMenu);
                                    listeSousMenus.Add(sousMenu);
                                }
                                listeSousMenus = sousMenu.MenuItems;
                            }
                        }
                    }
                    CMenuItemDeclencheur itemAction = new CMenuItemDeclencheur(declencheur);
                    itemAction.Click += new EventHandler(MenuDeclencheurClick);
                    listeSousMenus.Add(itemAction);
                }
            }*/
            /*foreach (CMacro macro in CListeMacros.GetMacrosOn(ObjetEdite.GetType()))
            {
                CMenuItemMacros item = new CMenuItemMacros(macro);
                item.Click += new EventHandler(item_Macro_Click);
                m_menuActions.Items.Add(item);
            }*/
			m_menuActions.Show ( m_btnActions, new Point ( 0, m_btnActions.Height ) );
		}

		//-------------------------------------------------------------------------
        private void item_Macro_Click(object sender, EventArgs e)
        {
            CMenuItemMacros menuMacro = sender as CMenuItemMacros;
            if (menuMacro != null)
            {
                CObjetDonnee obj = ObjetEdite;
                obj.BeginEdit();
                CContexteExecutionMacro ctxExec = new CContexteExecutionMacro(obj);
                CResultAErreur result = menuMacro.Macro.Execute(ctxExec);
                if (!result)
                {
                    obj.CancelEdit();
                    CFormAlerte.Afficher(result.Erreur);
                }
                else
                {
                    result = obj.CommitEdit();
                    if (!result)
                    {
                        obj.CancelEdit();
                        CFormAlerte.Afficher(result.Erreur);
                    }
                    InitChamps();
                }
            }
        }
        void MenuDeclencheurClick(IDeclencheurAction declencheur, CObjetDonneeAIdNumerique objetAction)
        {
            CResultAErreur result = CFormExecuteProcess.RunEvent(declencheur, objetAction, false);
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
            }
            else
            {
                //sc2i.common.CAppeleurFonctionAvecDelai.CallFonctionAvecDelai(this, "PublicInitChamps", 1500);
                // Cette modification corrige le bug de plantage aléatoire de l'appli suite à l'execution d'un process
                m_timerInitChampAfterRunEvent.Start();
            }

        }

        //-----------------------------------------------------------------------------
        private void m_timerInitChampAfterRunEvent_Tick(object sender, EventArgs e)
        {
            try
            {
                m_timerInitChampAfterRunEvent.Stop();
                PublicInitChamps();
            }
            catch { }
        }

        //-----------------------------------------------------------------------------
        public void PublicInitChamps()
		{
			InitChamps();
		}

		

		private void CFormEditionStdTimos_Load(object sender, System.EventArgs e)
		{
            if (DesignMode)
                return;

			CCustomiseurFenetresStandard.BrancheSurFenetre ( this );

            // Applique la configuration des cotroles de la forme en fonction des restrictions
            m_extModulesAssociator.AppliquerConfiguration(CTimosApp.ConfigurationModules);
            if (CTimosApp.SessionClient.GetInfoUtilisateur().GetDonneeDroit(
                CDroitDeBaseSC2I.c_droitAdministration) != null)
            {
                m_btnExportDonnee.Enabled = true;
                m_btnImportDonnees.Enabled = true;
            }
            else
            {
                m_btnExportDonnee.Enabled = false;
                m_btnImportDonnees.Enabled = false;
            }
		}

		private void m_btnControles_Click(object sender, System.EventArgs e)
		{
			//CTimosApp.Navigateur.AffichePage ( new CFormListeControles ( ObjetEdite ) );
		}

		private void m_menuImpressionEcran_Click(object sender, System.EventArgs e)
		{
			PrintScreen();
		}

		private void PrintScreen()
		{
			CScreenPrinter.PrintWindow(this);
		}

		private class CMenuItemEtat : MenuItem
		{
			public C2iRapportCrystal Rapport;

			public CMenuItemEtat  ( C2iRapportCrystal rapport )
			{
				Rapport = rapport;
				Text = rapport.Libelle;
			}
		}


		/// ///////////////////////////////////////////////////////////////
		private void m_btnImprimer_Click(object sender, System.EventArgs e)
		{
			if ( m_menuImpression.MenuItems.Contains ( m_menuImpressionEtat ) && m_menuImpressionEtat.MenuItems.Count == 0)
			{
				CListeObjetsDonnees liste = new CListeObjetsDonnees ( ObjetEdite.ContexteDonnee, typeof( C2iRapportCrystal ) );
				liste.Filtre = new CFiltreData ( C2iRapportCrystal.c_champTypeObjet+"=@1",
					ObjetEdite.GetType().ToString() );
				foreach (C2iRapportCrystal rapport in liste )
				{
					CMenuItemEtat menuEtat = new CMenuItemEtat ( rapport );
					menuEtat.Click +=new EventHandler(menuEtat_Click);
					m_menuImpressionEtat.MenuItems.Add ( menuEtat );
				}
			}
			if ( m_menuImpressionEtat.MenuItems.Count == 0 )
			{
				try
				{
					//m_menuImpressionEtat.Parent.MenuItems.Remove ( m_menuImpressionEtat );
					PrintScreen();
				}
				catch
				{
				}

				return;
			}
			m_menuImpression.Show ( m_btnImprimer, new Point ( 0, m_btnImprimer.Height ) );
		}


		/// ///////////////////////////////////////////////////////////////
		private void menuEtat_Click(object sender, EventArgs e)
		{
			if ( m_gestionnaireModeEdition.ModeEdition )
			{
				CFormAlerte.Afficher(I.T("Validate or cancel modifications before printing|30109"), EFormAlerteType.Exclamation);
				return;
			}
			if ( sender is CMenuItemEtat )
			{
				CResultAErreur result = CResultAErreur.True;
				C2iRapportCrystal rapport = ((CMenuItemEtat)sender).Rapport;
				try
				{
					using ( CWaitCursor waiter = new CWaitCursor() )
					{
						CListeObjetsDonnees liste = new CListeObjetsDonnees ( ObjetEdite.ContexteDonnee, ObjetEdite.GetType() );
						liste.Filtre = new CFiltreData ( ObjetEdite.GetChampId()+"=@1", 
							ObjetEdite.Id );
						CFichierLocalTemporaire fichierTemp = new CFichierLocalTemporaire("rpt");
						result = rapport.CreateReport(liste, fichierTemp );
						if ( result )
						{
							ReportDocument doc = (ReportDocument)result.Data;
							if ( CTimosApp.SessionClient.ConfigurationsImpression.NomImprimanteSurClient != "" )
								doc.PrintOptions.PrinterName = CTimosApp.SessionClient.ConfigurationsImpression.NomImprimanteSurClient;
							doc.PrintToPrinter(1, false, 0, 2000);
							doc.Dispose();
							fichierTemp.Dispose();
						}

					}
				}
				catch ( Exception exp )
				{
					result.EmpileErreur ( new CErreurException(exp));
				}
				if ( !result )
				{
					result.EmpileErreur(I.T("Printing error|30110"));
					CFormAlerte.Afficher ( result.Erreur );
				}
			}
		}

		/// ////////////////////////////////////////////
		private void m_btnDossiers_Click(object sender, System.EventArgs e)
		{
			CTimosApp.Navigateur.AffichePage ( new CFormListeDossierSuivi ( ObjetEdite ) );
		}


        //---------------------------------------------------------------------------------
        private void CFormEditionStdTimos_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F9:
                    if (CTimosApp.SessionClient.GetInfoUtilisateur().GetDonneeDroit(
                CDroitDeBaseSC2I.c_droitAdministration) != null)
                    {
                        e.Handled = true;
                        CFormFormuleRapide.EditerFormule(ObjetEdite);
                    }
                    break;
            }
        }

        private void m_btnTestInventaire_Click(object sender, EventArgs e)
        {
            //CInventaire inventaire = CCalculeurInventaire.GetInventaire(ObjetEdite,
            //    new CFournisseurInventaireObjetDonneeLies(CFournisseurInventaireObjetDonneeLies.EModeInventaireObjetDonneeLies.Parents |
            //        CFournisseurInventaireObjetDonneeLies.EModeInventaireObjetDonneeLies.FilsCompositions));

            //IEnumerable<object> lst = inventaire.GetObjects();

            /*CInventaire inventaireFormules = CCalculeurInventaire.GetInventaire(
                ObjetEdite,
                new List<Type>() { typeof(Form), typeof(Control) }, // Types à ne pas explorer
                new CFournisseurInventaireObjetGenerique<CAction>(),
                new CFournisseurInventaireObjetDonneeLies(ObjetEdite.ContexteDonnee, CFournisseurInventaireObjetDonneeLies.EModeInventaireObjetDonneeLies.Aucuns));

            IEnumerable<object> lstInventaire = inventaireFormules.GetObjects(false);
            IEnumerable<object> lstHorsInventaire = inventaireFormules.GetObjects(true);

            DataSet dsResult = new DataSet("RESULT INVENTAIRE");
            DataTable dtInventaire = new DataTable("Objets Inventoriés");
            DataTable dtHorsInventaire = new DataTable("Objets Hors Inventaire");

            dtInventaire.Columns.AddRange(new DataColumn[] { new DataColumn("Nom objet"), new DataColumn("type objet") });
            dtHorsInventaire.Columns.AddRange(new DataColumn[] { new DataColumn("Nom objet"), new DataColumn("type objet") });

            foreach (object item in lstInventaire)
            {
                dtInventaire.Rows.Add(item.ToString(), item.GetType());
            }
            dsResult.Tables.Add(dtInventaire);

            foreach (object item in lstHorsInventaire)
            {
                dtHorsInventaire.Rows.Add(item.ToString(), item.GetType());
            }
            dsResult.Tables.Add(dtHorsInventaire);
            CFormVisualisationDataSet.AfficheDonnees(dsResult);*/

        }

       
	}
}

