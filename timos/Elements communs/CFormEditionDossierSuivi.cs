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
using timos.acteurs;
using timos.win32.composants;
using sc2i.win32.data.dynamic;
using sc2i.expression;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CDossierSuivi))]
	public class CFormEditionDossierSuivi : CFormEditionStdTimos, IFormNavigable
	{
		public CObjetDonneeAIdNumerique m_objetAuquelAttacher = null;
		//Table CRelationTypeDossier_TypeElement->Control
		private Hashtable m_tableDossierSuivisLiens = new Hashtable();
		private ArrayList m_listeControlesLiens = new ArrayList();

		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private System.Windows.Forms.Label label2;
		private sc2i.win32.common.C2iDateTimePicker m_dtDebut;
		private System.Windows.Forms.Label label7;
		private sc2i.win32.common.C2iPanel m_panelLiensElements;
		private sc2i.win32.data.dynamic.CPanelChampsCustom m_panelChamps;
		private sc2i.win32.common.C2iTextBox m_txtCommentaires;
		private Crownwood.Magic.Controls.TabPage m_pageReference;
		private System.Windows.Forms.Label m_lblElementSuivi;
		private Crownwood.Magic.Controls.TabPage m_pageInfosComplementaires;
		private System.Windows.Forms.Label label5;
		private sc2i.win32.common.C2iTextBox c2iTextBox1;
		private sc2i.win32.common.C2iTabControl m_tabControl;
		private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_txtSelectionneElementSuivi;
		private System.Windows.Forms.LinkLabel m_lnkFermerOuvrir;
		private Crownwood.Magic.Controls.TabPage m_pageCommentaires;
		private Crownwood.Magic.Controls.TabPage m_pageAgenda;
		private timos.win32.composants.CcontrolAgenda m_controlAgenda;
		private System.Windows.Forms.Panel m_panelElementSuivi;
		private System.Windows.Forms.Panel panel1;
		private sc2i.win32.common.C2iPanelOmbre m_panelCartouche;
		private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label m_lblDossierParent;
        private System.Windows.Forms.LinkLabel m_lnkDossierPrincipal;

		public CFormEditionDossierSuivi()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionDossierSuivi(CDossierSuivi DossierSuivi)
			:base(DossierSuivi)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
			if ( DossierSuivi != null && DossierSuivi.TypeDossier != null )
				ContexteUtilisation = "TYPE_DOSSIER"+DossierSuivi.TypeDossier.Id.ToString();
		}
		//-------------------------------------------------------------------------
		public CFormEditionDossierSuivi(CDossierSuivi DossierSuivi, CListeObjetsDonnees liste)
			:base(DossierSuivi, liste)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
			if ( DossierSuivi != null && DossierSuivi.TypeDossier != null )
				ContexteUtilisation = "TYPE_DOSSIER"+DossierSuivi.TypeDossier.Id.ToString();
		}

		//-------------------------------------------------------------------------
		public CObjetDonneeAIdNumerique ObjetAuquelAttacher
		{
			get
			{
				return m_objetAuquelAttacher;
			}
			set
			{
				m_objetAuquelAttacher = value;
			}
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionDossierSuivi));
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.m_panelCartouche = new sc2i.win32.common.C2iPanelOmbre();
            this.m_panelElementSuivi = new System.Windows.Forms.Panel();
            this.m_lblElementSuivi = new System.Windows.Forms.Label();
            this.m_txtSelectionneElementSuivi = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_lnkFermerOuvrir = new System.Windows.Forms.LinkLabel();
            this.m_dtDebut = new sc2i.win32.common.C2iDateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.m_lblDossierParent = new System.Windows.Forms.Label();
            this.m_lnkDossierPrincipal = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.m_panelLiensElements = new sc2i.win32.common.C2iPanel(this.components);
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageInfosComplementaires = new Crownwood.Magic.Controls.TabPage();
            this.c2iTextBox1 = new sc2i.win32.common.C2iTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_panelChamps = new sc2i.win32.data.dynamic.CPanelChampsCustom();
            this.m_pageAgenda = new Crownwood.Magic.Controls.TabPage();
            this.m_controlAgenda = new timos.win32.composants.CcontrolAgenda();
            this.m_pageCommentaires = new Crownwood.Magic.Controls.TabPage();
            this.m_txtCommentaires = new sc2i.win32.common.C2iTextBox();
            this.m_pageReference = new Crownwood.Magic.Controls.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.m_panelCartouche.SuspendLayout();
            this.m_panelElementSuivi.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.m_pageInfosComplementaires.SuspendLayout();
            this.m_pageAgenda.SuspendLayout();
            this.m_pageCommentaires.SuspendLayout();
            this.m_pageReference.SuspendLayout();
            this.panel1.SuspendLayout();
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
            // m_panelNavigation
            // 
            this.m_panelNavigation.Location = new System.Drawing.Point(569, 0);
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
            this.m_panelCle.Location = new System.Drawing.Point(461, 0);
            this.m_panelCle.Size = new System.Drawing.Size(108, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(744, 28);
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
            this.label1.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label1, false);
            this.label1.Location = new System.Drawing.Point(8, 12);
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
            this.m_txtLibelle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtLibelle.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtLibelle, false);
            this.m_txtLibelle.Location = new System.Drawing.Point(96, 8);
            this.m_txtLibelle.LockEdition = false;
            this.m_txtLibelle.MaxLength = 255;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(200, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Libelle]";
            // 
            // m_panelCartouche
            // 
            this.m_panelCartouche.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelCartouche.Controls.Add(this.m_panelElementSuivi);
            this.m_panelCartouche.Controls.Add(this.m_lnkFermerOuvrir);
            this.m_panelCartouche.Controls.Add(this.m_dtDebut);
            this.m_panelCartouche.Controls.Add(this.label2);
            this.m_panelCartouche.Controls.Add(this.label1);
            this.m_panelCartouche.Controls.Add(this.m_txtLibelle);
            this.m_panelCartouche.Controls.Add(this.m_lblDossierParent);
            this.m_panelCartouche.Controls.Add(this.m_lnkDossierPrincipal);
            this.m_panelCartouche.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelCartouche.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panelCartouche, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelCartouche, false);
            this.m_panelCartouche.Location = new System.Drawing.Point(0, 0);
            this.m_panelCartouche.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelCartouche, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelCartouche, "");
            this.m_panelCartouche.Name = "m_panelCartouche";
            this.m_panelCartouche.Size = new System.Drawing.Size(736, 96);
            this.m_extStyle.SetStyleBackColor(this.m_panelCartouche, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panelCartouche, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelCartouche.TabIndex = 0;
            // 
            // m_panelElementSuivi
            // 
            this.m_panelElementSuivi.Controls.Add(this.m_lblElementSuivi);
            this.m_panelElementSuivi.Controls.Add(this.m_txtSelectionneElementSuivi);
            this.m_extLinkField.SetLinkField(this.m_panelElementSuivi, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelElementSuivi, false);
            this.m_panelElementSuivi.Location = new System.Drawing.Point(0, 56);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelElementSuivi, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelElementSuivi, "");
            this.m_panelElementSuivi.Name = "m_panelElementSuivi";
            this.m_panelElementSuivi.Size = new System.Drawing.Size(720, 24);
            this.m_extStyle.SetStyleBackColor(this.m_panelElementSuivi, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelElementSuivi, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelElementSuivi.TabIndex = 4018;
            // 
            // m_lblElementSuivi
            // 
            this.m_extLinkField.SetLinkField(this.m_lblElementSuivi, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblElementSuivi, false);
            this.m_lblElementSuivi.Location = new System.Drawing.Point(8, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblElementSuivi, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblElementSuivi, "");
            this.m_lblElementSuivi.Name = "m_lblElementSuivi";
            this.m_lblElementSuivi.Size = new System.Drawing.Size(72, 23);
            this.m_extStyle.SetStyleBackColor(this.m_lblElementSuivi, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblElementSuivi, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblElementSuivi.TabIndex = 4013;
            this.m_lblElementSuivi.Text = "Managed element|30132";
            this.m_lblElementSuivi.Click += new System.EventHandler(this.label3_Click);
            // 
            // m_txtSelectionneElementSuivi
            // 
            this.m_txtSelectionneElementSuivi.ElementSelectionne = null;
            this.m_txtSelectionneElementSuivi.FonctionTextNull = null;
            this.m_txtSelectionneElementSuivi.HasLink = true;
            this.m_txtSelectionneElementSuivi.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_extLinkField.SetLinkField(this.m_txtSelectionneElementSuivi, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtSelectionneElementSuivi, false);
            this.m_txtSelectionneElementSuivi.Location = new System.Drawing.Point(96, 0);
            this.m_txtSelectionneElementSuivi.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectionneElementSuivi, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtSelectionneElementSuivi, "");
            this.m_txtSelectionneElementSuivi.Name = "m_txtSelectionneElementSuivi";
            this.m_txtSelectionneElementSuivi.SelectedObject = null;
            this.m_txtSelectionneElementSuivi.Size = new System.Drawing.Size(616, 21);
            this.m_txtSelectionneElementSuivi.SpecificImage = null;
            this.m_extStyle.SetStyleBackColor(this.m_txtSelectionneElementSuivi, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSelectionneElementSuivi, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectionneElementSuivi.TabIndex = 4016;
            this.m_txtSelectionneElementSuivi.TextNull = "";
            // 
            // m_lnkFermerOuvrir
            // 
            this.m_extLinkField.SetLinkField(this.m_lnkFermerOuvrir, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkFermerOuvrir, false);
            this.m_lnkFermerOuvrir.Location = new System.Drawing.Point(200, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkFermerOuvrir, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkFermerOuvrir, "");
            this.m_lnkFermerOuvrir.Name = "m_lnkFermerOuvrir";
            this.m_lnkFermerOuvrir.Size = new System.Drawing.Size(150, 23);
            this.m_extStyle.SetStyleBackColor(this.m_lnkFermerOuvrir, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkFermerOuvrir, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkFermerOuvrir.TabIndex = 4017;
            this.m_lnkFermerOuvrir.TabStop = true;
            this.m_lnkFermerOuvrir.Text = "Close this workbook|30133";
            this.m_lnkFermerOuvrir.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkFermerOuvrir_LinkClicked);
            // 
            // m_dtDebut
            // 
            this.m_dtDebut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.m_extLinkField.SetLinkField(this.m_dtDebut, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_dtDebut, false);
            this.m_dtDebut.Location = new System.Drawing.Point(96, 32);
            this.m_dtDebut.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_dtDebut, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_dtDebut, "");
            this.m_dtDebut.Name = "m_dtDebut";
            this.m_dtDebut.Size = new System.Drawing.Size(88, 20);
            this.m_extStyle.SetStyleBackColor(this.m_dtDebut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_dtDebut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_dtDebut.TabIndex = 1;
            this.m_dtDebut.Value = new System.DateTime(2003, 4, 2, 9, 17, 49, 526);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label2, false);
            this.label2.Location = new System.Drawing.Point(8, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4004;
            this.label2.Text = "Opening date|30131";
            // 
            // m_lblDossierParent
            // 
            this.m_extLinkField.SetLinkField(this.m_lblDossierParent, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblDossierParent, false);
            this.m_lblDossierParent.Location = new System.Drawing.Point(360, 34);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblDossierParent, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblDossierParent, "");
            this.m_lblDossierParent.Name = "m_lblDossierParent";
            this.m_lblDossierParent.Size = new System.Drawing.Size(103, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblDossierParent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblDossierParent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblDossierParent.TabIndex = 68;
            this.m_lblDossierParent.Text = "Main Workbook|952";
            // 
            // m_lnkDossierPrincipal
            // 
            this.m_lnkDossierPrincipal.BackColor = System.Drawing.Color.White;
            this.m_lnkDossierPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_extLinkField.SetLinkField(this.m_lnkDossierPrincipal, "DossierParent.Libelle");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkDossierPrincipal, true);
            this.m_lnkDossierPrincipal.Location = new System.Drawing.Point(464, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkDossierPrincipal, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkDossierPrincipal, "");
            this.m_lnkDossierPrincipal.Name = "m_lnkDossierPrincipal";
            this.m_lnkDossierPrincipal.Size = new System.Drawing.Size(200, 20);
            this.m_extStyle.SetStyleBackColor(this.m_lnkDossierPrincipal, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkDossierPrincipal, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkDossierPrincipal.TabIndex = 69;
            this.m_lnkDossierPrincipal.TabStop = true;
            this.m_lnkDossierPrincipal.Text = "[DossierParent.Libelle]";
            this.m_lnkDossierPrincipal.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkDossierPrincipal_LinkClicked);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label7, "TypeDossier.Libelle");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label7, true);
            this.label7.Location = new System.Drawing.Point(8, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label7, "");
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(640, 24);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 4002;
            this.label7.Text = "[TypeDossier.Libelle]";
            // 
            // m_panelLiensElements
            // 
            this.m_panelLiensElements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelLiensElements.AutoScroll = true;
            this.m_extLinkField.SetLinkField(this.m_panelLiensElements, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelLiensElements, false);
            this.m_panelLiensElements.Location = new System.Drawing.Point(0, 0);
            this.m_panelLiensElements.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelLiensElements, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelLiensElements, "");
            this.m_panelLiensElements.Name = "m_panelLiensElements";
            this.m_panelLiensElements.Size = new System.Drawing.Size(720, 312);
            this.m_extStyle.SetStyleBackColor(this.m_panelLiensElements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelLiensElements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelLiensElements.TabIndex = 4014;
            // 
            // m_tabControl
            // 
            this.m_tabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_tabControl.BoldSelectedPage = true;
            this.m_tabControl.ControlBottomOffset = 16;
            this.m_tabControl.ControlRightOffset = 16;
            this.m_tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tabControl.ForeColor = System.Drawing.Color.Black;
            this.m_tabControl.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_tabControl, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_tabControl, false);
            this.m_tabControl.Location = new System.Drawing.Point(0, 96);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.m_pageInfosComplementaires;
            this.m_tabControl.Size = new System.Drawing.Size(736, 352);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4004;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageInfosComplementaires,
            this.m_pageAgenda,
            this.m_pageCommentaires,
            this.m_pageReference});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageInfosComplementaires
            // 
            this.m_pageInfosComplementaires.Controls.Add(this.c2iTextBox1);
            this.m_pageInfosComplementaires.Controls.Add(this.label5);
            this.m_pageInfosComplementaires.Controls.Add(this.m_panelChamps);
            this.m_extLinkField.SetLinkField(this.m_pageInfosComplementaires, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageInfosComplementaires, false);
            this.m_pageInfosComplementaires.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageInfosComplementaires, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageInfosComplementaires, "");
            this.m_pageInfosComplementaires.Name = "m_pageInfosComplementaires";
            this.m_pageInfosComplementaires.Size = new System.Drawing.Size(720, 311);
            this.m_extStyle.SetStyleBackColor(this.m_pageInfosComplementaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageInfosComplementaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageInfosComplementaires.TabIndex = 11;
            this.m_pageInfosComplementaires.Title = "Additional information|1156";
            // 
            // c2iTextBox1
            // 
            this.c2iTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.c2iTextBox1.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.c2iTextBox1, "Cle");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iTextBox1, true);
            this.c2iTextBox1.Location = new System.Drawing.Point(32, 288);
            this.c2iTextBox1.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iTextBox1, "");
            this.c2iTextBox1.Name = "c2iTextBox1";
            this.c2iTextBox1.Size = new System.Drawing.Size(248, 21);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox1.TabIndex = 4004;
            this.c2iTextBox1.Text = "[Cle]";
            this.c2iTextBox1.Visible = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label5, false);
            this.label5.Location = new System.Drawing.Point(0, 290);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 4003;
            this.label5.Text = "Key|43";
            this.label5.Visible = false;
            // 
            // m_panelChamps
            // 
            this.m_panelChamps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelChamps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(184)))));
            this.m_panelChamps.BoldSelectedPage = true;
            this.m_panelChamps.ElementEdite = null;
            this.m_panelChamps.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_panelChamps, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelChamps, false);
            this.m_panelChamps.Location = new System.Drawing.Point(0, -1);
            this.m_panelChamps.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelChamps, "");
            this.m_panelChamps.Name = "m_panelChamps";
            this.m_panelChamps.Ombre = false;
            this.m_panelChamps.PositionTop = true;
            this.m_panelChamps.Size = new System.Drawing.Size(720, 289);
            this.m_extStyle.SetStyleBackColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelChamps.TabIndex = 7;
            // 
            // m_pageAgenda
            // 
            this.m_pageAgenda.Controls.Add(this.m_controlAgenda);
            this.m_extLinkField.SetLinkField(this.m_pageAgenda, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageAgenda, false);
            this.m_pageAgenda.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageAgenda, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageAgenda, "");
            this.m_pageAgenda.Name = "m_pageAgenda";
            this.m_pageAgenda.Selected = false;
            this.m_pageAgenda.Size = new System.Drawing.Size(720, 311);
            this.m_extStyle.SetStyleBackColor(this.m_pageAgenda, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageAgenda, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageAgenda.TabIndex = 14;
            this.m_pageAgenda.Title = "Agenda|80";
            // 
            // m_controlAgenda
            // 
            this.m_controlAgenda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_controlAgenda.DateEnCours = new System.DateTime(2013, 8, 20, 16, 1, 22, 127);
            this.m_extLinkField.SetLinkField(this.m_controlAgenda, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_controlAgenda, false);
            this.m_controlAgenda.Location = new System.Drawing.Point(2, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_controlAgenda, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_controlAgenda, "");
            this.m_controlAgenda.Name = "m_controlAgenda";
            this.m_controlAgenda.Size = new System.Drawing.Size(716, 312);
            this.m_extStyle.SetStyleBackColor(this.m_controlAgenda, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_controlAgenda, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_controlAgenda.TabIndex = 2;
            this.m_controlAgenda.OnAfficherEntreeAgenda += new timos.win32.composants.DemandeAffichageEntreeAgendaEventHandler(this.m_controlAgenda_OnAfficherEntreeAgenda);
            // 
            // m_pageCommentaires
            // 
            this.m_pageCommentaires.Controls.Add(this.m_txtCommentaires);
            this.m_extLinkField.SetLinkField(this.m_pageCommentaires, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageCommentaires, false);
            this.m_pageCommentaires.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageCommentaires, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageCommentaires, "");
            this.m_pageCommentaires.Name = "m_pageCommentaires";
            this.m_pageCommentaires.Selected = false;
            this.m_pageCommentaires.Size = new System.Drawing.Size(720, 311);
            this.m_extStyle.SetStyleBackColor(this.m_pageCommentaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageCommentaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageCommentaires.TabIndex = 10;
            this.m_pageCommentaires.Title = "Comments|51";
            // 
            // m_txtCommentaires
            // 
            this.m_txtCommentaires.AcceptsReturn = true;
            this.m_txtCommentaires.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtCommentaires.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtCommentaires, "Commentaires");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtCommentaires, true);
            this.m_txtCommentaires.Location = new System.Drawing.Point(8, 8);
            this.m_txtCommentaires.LockEdition = false;
            this.m_txtCommentaires.MaxLength = 2048;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtCommentaires, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtCommentaires, "");
            this.m_txtCommentaires.Multiline = true;
            this.m_txtCommentaires.Name = "m_txtCommentaires";
            this.m_txtCommentaires.Size = new System.Drawing.Size(704, 296);
            this.m_extStyle.SetStyleBackColor(this.m_txtCommentaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtCommentaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtCommentaires.TabIndex = 0;
            this.m_txtCommentaires.Text = "[Commentaires]";
            // 
            // m_pageReference
            // 
            this.m_pageReference.Controls.Add(this.m_panelLiensElements);
            this.m_extLinkField.SetLinkField(this.m_pageReference, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageReference, false);
            this.m_pageReference.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageReference, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageReference, "");
            this.m_pageReference.Name = "m_pageReference";
            this.m_pageReference.Selected = false;
            this.m_pageReference.Size = new System.Drawing.Size(720, 311);
            this.m_extStyle.SetStyleBackColor(this.m_pageReference, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageReference, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageReference.TabIndex = 12;
            this.m_pageReference.Title = "Links|84";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.m_tabControl);
            this.panel1.Controls.Add(this.m_panelCartouche);
            this.m_extLinkField.SetLinkField(this.panel1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.panel1, false);
            this.panel1.Location = new System.Drawing.Point(8, 56);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel1, "");
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(736, 448);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 4005;
            // 
            // CFormEditionDossierSuivi
            // 
            this.AffectationsPourNouvelElement = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("$this.AffectationsPourNouvelElement")));
            this.ClientSize = new System.Drawing.Size(744, 504);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionDossierSuivi";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Load += new System.EventHandler(this.CFormEditionDossierSuivi_Load);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.m_panelCartouche.ResumeLayout(false);
            this.m_panelCartouche.PerformLayout();
            this.m_panelElementSuivi.ResumeLayout(false);
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.m_pageInfosComplementaires.ResumeLayout(false);
            this.m_pageInfosComplementaires.PerformLayout();
            this.m_pageAgenda.ResumeLayout(false);
            this.m_pageCommentaires.ResumeLayout(false);
            this.m_pageCommentaires.PerformLayout();
            this.m_pageReference.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion
		//-------------------------------------------------------------------------
		private CDossierSuivi DossierSuivi
		{
			get
			{
				return (CDossierSuivi)ObjetEdite;
			}
		}

		//PanelListeSpeedStandard->Id de type de dossier
		private Hashtable m_tablePanelToIdTypeDossier = new Hashtable();
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
			this.ConsultationOnly = !DossierSuivi.EstOuvert;

            m_lnkFermerOuvrir.Text = DossierSuivi.EstOuvert ? I.T( "Close this Workbook|853") : I.T( "This Workbook is closed|854");
            m_lnkFermerOuvrir.Enabled = DossierSuivi.EstOuvert && !m_gestionnaireModeEdition.ModeEdition;

            m_lblDossierParent.Visible = DossierSuivi.DossierParent != null;
            m_lnkDossierPrincipal.Visible = DossierSuivi.DossierParent != null;

			if ( DossierSuivi.IsNew() && DossierSuivi.TypeDossier == null )
			{
				CFiltreData filtre = new CFiltreData();
				if ( DossierSuivi.DossierParent != null )
					filtre = new CFiltreData ( CTypeDossierSuivi.c_champTypeDossierParent+"=@1",
						DossierSuivi.DossierParent.TypeDossier.Id );
				else
					filtre = new CFiltreDataAvance ( 
						CTypeDossierSuivi.c_nomTable,
						"hasno("+CTypeDossierSuivi.c_champTypeDossierParent+")");
				if ( DossierSuivi.ElementSuivi != null )
					filtre = CFiltreData.GetAndFiltre ( filtre,
						new CFiltreData ( CTypeDossierSuivi.c_champTypeSuivi+"=@1",
						DossierSuivi.ElementSuivi.GetType().ToString() ) );
                CListeObjetsDonnees listeTypes = new CListeObjetsDonnees(DossierSuivi.ContexteDonnee, typeof(CTypeDossierSuivi));
				listeTypes.Filtre =  filtre;

                if (listeTypes.CountNoLoad == 1)
                    DossierSuivi.TypeDossier = (CTypeDossierSuivi)listeTypes[0];
                else
                {
                    DossierSuivi.TypeDossier = (CTypeDossierSuivi)sc2i.win32.data.dynamic.CFormSelectUnObjetDonnee.SelectObjetDonnee(
                        I.T("Select a workbook type|20736"),
                        typeof(CTypeDossierSuivi),
                        filtre,
                        "Libelle");
                    if (DossierSuivi.TypeDossier == null)
                    {
                        //if (!Navigateur.AffichePagePrecedente())
                        //    Navigateur.AffichePageAccueil();
                        return CResultAErreur.False;
                    }
                }
			}
            
			if ( DossierSuivi.TypeDossier.TypeSuivi != null )
			{
				m_panelElementSuivi.Visible = true;

                m_lblElementSuivi.Text = DynamicClassAttribute.GetNomConvivial(DossierSuivi.TypeDossier.TypeSuivi);

				if ( DossierSuivi.IsNew() && DossierSuivi.ElementSuivi==null && ObjetAuquelAttacher != null && ObjetAuquelAttacher.GetType() == DossierSuivi.TypeDossier.TypeSuivi )
					DossierSuivi.ElementSuivi = ObjetAuquelAttacher;

				Type tpFormListe = CFormFinder.GetTypeFormToList ( DossierSuivi.TypeDossier.TypeSuivi );
				//Type tpFormEdit = CFormFinder.GetTypeFormToEdit ( DossierSuivi.TypeDossier.TypeSuivi );

				CFiltreData filtreElement = DossierSuivi.GetFiltreDataElementSuivi();

				//Si un seul élément suivi possible, on l'utilise
				if ( DossierSuivi.ElementSuivi == null )
				{
					CListeObjetsDonnees listeElements = new CListeObjetsDonnees ( DossierSuivi.ContexteDonnee, DossierSuivi.TypeDossier.TypeSuivi );
                    if ( filtreElement.Parametres.Count > 0 )
					    filtreElement.Parametres[0]="%";
					listeElements.Filtre = filtreElement;
					if ( listeElements.CountNoLoad == 1 )
						DossierSuivi.ElementSuivi = (CObjetDonneeAIdNumerique)listeElements[0];
				}

                m_txtSelectionneElementSuivi.InitForSelectAvecFiltreDeBase(
                    DossierSuivi.TypeDossier.TypeSuivi,
                    "DescriptionElement", 
                    filtreElement, 
                    true);
				m_txtSelectionneElementSuivi.ElementSelectionne = DossierSuivi.ElementSuivi;
			}
			else
				m_panelElementSuivi.Visible = false;

			m_panelCartouche.Visible = !DossierSuivi.TypeDossier.MasquerCartoucheSurEdition;
            if (m_panelCartouche.Visible)
            {
                m_txtLibelle.Text = DossierSuivi.Libelle;
                m_dtDebut.Value = DossierSuivi.DateOuverture;
            }



            CResultAErreur result = base.MyInitChamps();
			AffecterTitre(I.T( "Workbook|855") +" "+ DossierSuivi.Libelle);

			InitListeLiens();

			m_panelChamps.ElementEdite = DossierSuivi;

			ObjetAuquelAttacher = DossierSuivi.ElementSuivi;

			/*m_panelSousDossiers.InitFromListeObjets ( 
				DossierSuivi.DossiersFils,
				typeof ( CDossierSuivi ),
				typeof ( CFormEditionDossierSuivi ),
				DossierSuivi,
				"DossierParent");

			
			if ( DossierSuivi.TypeDossier.TypesDossiersFils.Count == 0 )
			{
				if ( m_tabControl.TabPages.Contains ( m_pageSousDossiers ) )
					m_tabControl.TabPages.Remove ( m_pageSousDossiers );
			}
			else
				if ( !m_tabControl.TabPages.Contains ( m_pageSousDossiers ) )
				m_tabControl.TabPages.Add ( m_pageSousDossiers );*/


			ArrayList lst = new ArrayList(m_tabControl.TabPages );
			//m_tablePanelToIdTypeDossier.Clear();
			foreach ( Crownwood.Magic.Controls.TabPage page in lst )
			{
				if ( page.Tag is int )
				{
					m_tabControl.TabPages.Remove ( page );
					page.Dispose();
				}
			}

			m_tabControl.TabPages.Clear();

			



			m_controlAgenda.SetElementAAgenda ( DossierSuivi );


			//Masque automatiquement les onglets à masquer
			if ( !m_panelChamps.IsEmpty() )
			{
				AfficheOnglet ( m_pageInfosComplementaires );
				m_pageInfosComplementaires.Title = m_panelChamps.Titre;
			}

			if ( !DossierSuivi.TypeDossier.MasquerAgenda )
				AfficheOnglet ( m_pageAgenda );
			AfficheOnglet ( m_pageCommentaires );

			if ( DossierSuivi.TypeDossier.TypesRelationsToElement.Count > 0 )
				AfficheOnglet ( m_pageReference );



            foreach (CTypeDossierSuivi typeDossier in DossierSuivi.TypeDossier.TypesDossiersFils)
            {
                bool bAddFormulaire = !typeDossier.UnSeulParParent;
                CDossierSuivi sousDossier = null;
                if (!bAddFormulaire)
                {
                    if (typeDossier.UnSeulParParent && typeDossier.FormulaireResume != null)
                    {
                        //Trouve le dossier unique
                        CListeObjetsDonnees lstFils = DossierSuivi.DossiersFils;
                        lstFils.Filtre = new CFiltreData(CTypeDossierSuivi.c_champId + "=@1",
                            typeDossier.Id);
                        if (lstFils.Count > 0)
                            sousDossier = lstFils[0] as CDossierSuivi;
                    }
                    bAddFormulaire = sousDossier != null;
                }

                if (bAddFormulaire)
                {
                    Crownwood.Magic.Controls.TabPage pageSousType = new Crownwood.Magic.Controls.TabPage(typeDossier.Libelle);
                    pageSousType.Tag = typeDossier.Id;
                    m_tabControl.TabPages.Add(pageSousType);
                    if (!typeDossier.UnSeulParParent)
                    {
                        CPanelListeSpeedStandard panelTmp = new CPanelListeSpeedStandard();
                        panelTmp.Name = "m_panelListeSousDossiers";
                        pageSousType.Controls.Add(panelTmp);

                        GLColumn col = new GLColumn();
                        col.Propriete = "ElementSuivi.DescriptionElement";
                        col.Text = I.T("Label|50");
                        col.Width = 500;
                        panelTmp.Columns.Add(col);
                        panelTmp.ContexteUtilisation = ContexteUtilisation + "_" + typeDossier.Id;
                        panelTmp.Dock = System.Windows.Forms.DockStyle.Fill;
                        //m_gestionnaireModeEdition.SetModeEdition(panelTmp, TypeModeEdition.DisableSurEdition);
                        panelTmp.Enabled = !m_gestionnaireModeEdition.ModeEdition;
                        panelTmp.EnableCustomisation = true;
                        CFiltreData filtre = new CFiltreData(
                            CDossierSuivi.c_champIdDossierParent + "=@1 and " +
                            CTypeDossierSuivi.c_champId + "=@2",
                            DossierSuivi.Id,
                            typeDossier.Id);
                        CListeObjetsDonnees listeSousDossiers = new CListeObjetsDonnees(DossierSuivi.ContexteDonnee, typeof(CDossierSuivi), filtre);
                        panelTmp.InitFromListeObjets(
                            listeSousDossiers,
                            typeof(CDossierSuivi),
                            typeof(CFormEditionDossierSuivi),
                            DossierSuivi,
                            "DossierParent");
                        panelTmp.OnNewObjetDonnee += new OnNewObjetDonneeEventHandler(panelSousDossier_OnNewObjetDonnee);
                        m_tablePanelToIdTypeDossier[panelTmp] = typeDossier.Id;
                    }
                    else
                    {
                        CPanelResumeSousDossier panel = new CPanelResumeSousDossier();
                        pageSousType.Controls.Add(panel);
                        panel.Dock = DockStyle.Fill;
                        m_gestionnaireModeEdition.SetModeEdition(panel, TypeModeEdition.EnableSurEdition);
                        panel.Init(sousDossier);
                        panel.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
                    }
                }
            }

			
			return result;
		}

        private void panelSousDossier_OnNewObjetDonnee(object sender, CObjetDonnee objet, ref bool bCancel)
        {
            if (bCancel)
                return;
			if ( objet is CDossierSuivi )
			{
				object idType = m_tablePanelToIdTypeDossier[sender];
				if ( idType is int )
				{
					CTypeDossierSuivi typeDossier = new CTypeDossierSuivi ( objet.ContexteDonnee );
					if ( typeDossier.ReadIfExists ( (int)idType ) )
						((CDossierSuivi)objet).TypeDossier = typeDossier;
				}
			}

		}

		//-------------------------------------------------------------------------
		private void AfficheOnglet ( Crownwood.Magic.Controls.TabPage page )
		{
			if ( !m_tabControl.TabPages.Contains ( page ) )
				m_tabControl.TabPages.Add ( page );
		}

		//-------------------------------------------------------------------------
		private void MasqueOnglet ( Crownwood.Magic.Controls.TabPage page )
		{
			if ( m_tabControl.TabPages.Contains ( page ) )
				m_tabControl.TabPages.Remove ( page );
		}

		//-------------------------------------------------------------------------
		protected override CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = base.MAJ_Champs();
			result = m_panelChamps.MAJ_Champs();
			if (!result )
				return result;
            
            if(DossierSuivi.TypeDossier != null)
            {
                Type typeSuivi = DossierSuivi.TypeDossier.TypeSuivi;
                if(m_txtSelectionneElementSuivi.ElementSelectionne != null &&
                    m_txtSelectionneElementSuivi.ElementSelectionne.GetType().Equals(typeSuivi))
                    DossierSuivi.ElementSuivi = (CObjetDonneeAIdNumerique)m_txtSelectionneElementSuivi.ElementSelectionne;
                else
                    DossierSuivi.ElementSuivi = null;
                if (!DossierSuivi.TypeDossier.MasquerCartoucheSurEdition)
                {
                    DossierSuivi.Libelle = m_txtLibelle.Text;
                    DossierSuivi.DateOuverture = m_dtDebut.Value;
                }
            }


			CListeObjetsDonnees liste = DossierSuivi.RelationsElements;
			foreach ( CRelationTypeDossierSuivi_TypeElement param in m_tableDossierSuivisLiens.Keys )
			{
				C2iTextBoxSelectionne control = (C2iTextBoxSelectionne)m_tableDossierSuivisLiens[param];
				CRelationDossierSuivi_Element relationToSet =  null;
				foreach ( CRelationDossierSuivi_Element rel in liste )
				{
					if ( rel.RelationParametre_TypeElement.Id == param.Id )
					{
						relationToSet = rel;
						break;
					}
				}
				if ( control.ElementSelectionne == null && relationToSet != null )
					relationToSet.Delete();
				if ( control.ElementSelectionne != null )
				{
					if ( relationToSet == null )
					{
						relationToSet = new CRelationDossierSuivi_Element ( DossierSuivi.ContexteDonnee );
						relationToSet.CreateNewInCurrentContexte();
						relationToSet.DossierSuivi = DossierSuivi;
						relationToSet.RelationParametre_TypeElement = param;
					}
					relationToSet.ElementLie = (CObjetDonneeAIdNumerique)control.ElementSelectionne;
				}
			}

            foreach ( Crownwood.Magic.Controls.TabPage page in m_tabControl.TabPages )
            {
                if ( page.Controls.Count == 1 && 
                    page.Controls[0] is CPanelResumeSousDossier )
                {
                    CPanelResumeSousDossier panel = page.Controls[0] as CPanelResumeSousDossier;
                    result = panel.MajChamps();
                    if ( !result )
                        return result;
                }
            }

			
			return result;
		}


		//-------------------------------------------------------------------------
		private void InitListeLiens()
		{
			foreach ( Control ctrl in m_listeControlesLiens )
			{
				ctrl.Hide();
				ctrl.Dispose();
			}
			m_tableDossierSuivisLiens = new Hashtable();
			m_listeControlesLiens = new ArrayList();
			int nY = 0;
			CListeObjetsDonnees listeRelationsToElements = DossierSuivi.RelationsElements;
			foreach ( CRelationTypeDossierSuivi_TypeElement relation in 
				DossierSuivi.TypeDossier.RelationsTypesElements )
			{
				/*Label lbl = new Label ();
				lbl.Parent = m_panelLiensElements;
				lbl.Left = 0;
				lbl.Top = nY;
				lbl.Width = Math.Min ( 200, m_panelLiensElements.Width/3 );
				lbl.CreateControl();
				lbl.Text = relation.Libelle;
				m_listeControlesLiens.Add ( lbl );
				C2iTextBoxSelectionne panel = new C2iTextBoxSelectionne();
				panel.Parent = m_panelLiensElements;
				panel.Left = lbl.Right;
				panel.Top = nY;
				panel.Width = m_panelLiensElements.Width-lbl.Width;
				panel.Anchor = AnchorStyles.Left|AnchorStyles.Top|AnchorStyles.Right;
				nY += panel.Height;
				panel.HasLink = true;
				panel.CreateControl();
				panel.Visible = true;
				CFiltreData filtre = CFournisseurFiltreRapide.GetFiltreRapideForType ( relation.TypeElements );
				filtre = CFiltreData.GetAndFiltre ( filtre, relation.FiltreDataAssocie );
				panel.Init ( CFormFinder.GetTypeFormToList ( relation.TypeElements ),
					CFormFinder.GetTypeFormToEdit ( relation.TypeElements ),
					"DescriptionElement",
					filtre,
					false );
				m_gestionnaireModeEdition.SetModeEdition ( panel, TypeModeEdition.EnableSurEdition );
				panel.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
				foreach ( CRelationDossierSuivi_Element relationEntree in
					listeRelationsToElements )
				{
					if ( relationEntree.RelationParametre_TypeElement.Id == 
						relation.Id )
						panel.ElementSelectionne = relationEntree.ElementLie;
				}
				m_tableDossierSuivisLiens[relation] = panel;*/
				CPanelSelectLienToElement panel = new CPanelSelectLienToElement();
				panel.Parent = m_panelLiensElements;
				
				panel.Left = 0;
				panel.Top = nY;
				panel.Width = m_panelLiensElements.Width;
				panel.Anchor = AnchorStyles.Left|AnchorStyles.Top|AnchorStyles.Right;
				nY += panel.Height;
				panel.CreateControl();
				panel.Visible = true;
				m_gestionnaireModeEdition.SetModeEdition ( panel, TypeModeEdition.EnableSurEdition );
				panel.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
				panel.Init ( relation, DossierSuivi );
				m_listeControlesLiens.Add ( panel );
			}

		}

		//-------------------------------------------------------------------------
		private void CFormEditionDossierSuivi_Load(object sender, System.EventArgs e)
		{
		}

		//-------------------------------------------------------------------------		
		private void m_lnkElementSuivi_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			//Type tp = CFormFinder.GetTypeFormToEdit ( DossierSuivi.ElementSuivi.GetType() );
            CReferenceTypeForm refTypeForm = CFormFinder.GetRefFormToEdit(DossierSuivi.ElementSuivi.GetType());


            try
			{
                //if ( tp.IsSubclassOf(typeof(CFormEditionStandard)) )
                //{
                //    CFormEditionStandard frm = (CFormEditionStandard)Activator.CreateInstance ( tp, new object[]{DossierSuivi.ElementSuivi});
                //    CTimosApp.Navigateur.AffichePage ( frm );
                //    return;
                //}
                if (refTypeForm != null)
                {
                    CFormEditionStandard form = refTypeForm.GetForm(DossierSuivi.ElementSuivi as CObjetDonneeAIdNumeriqueAuto) as CFormEditionStandard;
                    if (form != null)
                        CTimosApp.Navigateur.AffichePage(form);
                }

			}
			catch{}
			CFormAlerte.Afficher(I.T("Not available|917"), EFormAlerteType.Erreur);

		}

		private void label3_Click(object sender, System.EventArgs e)
		{
		
		}

		//----------------------------------------------------------------------------------
		private void m_lnkFermerOuvrir_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			if ( this.EtatEdition )
				return;
			CDossierSuivi dossier = DossierSuivi;
            if (dossier.EstOuvert)
            {
                dossier.BeginEdit();
                dossier.EstOuvert = false;
                CResultAErreur result = dossier.CommitEdit();
                if (!result)
                {
                    CFormAlerte.Afficher(result.Erreur);
                    return;
                }
                InitChamps();
            }
		
		}

		//----------------------------------------------------------------------------------
		private void m_controlAgenda_OnAfficherEntreeAgenda(IEntreeAgenda entree)
		{
			if ( entree is CEntreeAgenda)
				CTimosApp.Navigateur.AffichePage(new CFormEditionEntreeAgenda((CEntreeAgenda)entree));
			else
				CFormAlerte.Afficher(I.T("This entry cannot be edited|856"), EFormAlerteType.Erreur);
		}


        //----------------------------------------------------------------------------------
        void m_lnkDossierPrincipal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(DossierSuivi.DossierParent != null)
                CTimosApp.Navigateur.AffichePage(new CFormEditionDossierSuivi(DossierSuivi.DossierParent));
        }

	}
}

