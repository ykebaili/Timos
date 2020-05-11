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
using sc2i.common.planification;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CEntreeAgenda))]
	public class CFormEditionEntreeAgenda : CFormEditionStdTimos, IFormNavigable
	{
		private ArrayList m_listeControlesLiens = new ArrayList();

		private CTypeEntreeAgenda m_lastTypeEntree =  null;

		private CFormatteurTextBoxMasque m_formatteurHeure = new CFormatteurTextBoxMasque("##:##");
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
		private System.Windows.Forms.Label label2;
		private sc2i.win32.common.C2iDateTimePicker m_dtDebut;
		private System.Windows.Forms.Label label3;
		private sc2i.win32.common.C2iPanel m_panelHeure;
		private System.Windows.Forms.CheckBox m_chkSansHoraire;
		private sc2i.win32.common.C2iDateTimePicker m_dtFin;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private sc2i.win32.common.CComboboxAutoFilled m_cmbEtat;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private sc2i.win32.common.C2iPanel m_panelLiensElements;
		private sc2i.win32.common.C2iTabControl c2iTabControl1;
		private Crownwood.Magic.Controls.TabPage tabPage1;
		private Crownwood.Magic.Controls.TabPage tabPage2;
		private sc2i.win32.data.dynamic.CPanelChampsCustom m_panelChamps;
		private sc2i.win32.common.C2iTextBox m_txtCommentaires;
		private System.Windows.Forms.CheckBox m_chkEtatAutomatique;
		private sc2i.win32.common.C2iComboBox m_txtHeureDebut;
		private sc2i.win32.common.C2iComboBox m_txtHeureFin;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.Panel m_panelEntreeNonCyclique;
		private Crownwood.Magic.Controls.TabPage tabPage3;
		private System.Windows.Forms.Panel m_panelCyclique;
		private System.Windows.Forms.Label m_labelInfoCyclique;
		private System.Windows.Forms.Button m_btnNonCyclique;
		private System.Windows.Forms.Button m_btnCyclique;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.LinkLabel m_lnkModifierParametres;
		private System.Windows.Forms.Panel m_panelRappel;
		private System.Windows.Forms.CheckBox m_chkRappel;
		private sc2i.win32.common.C2iNumericUpDown m_numUpRappel;
		private System.Windows.Forms.Label label9;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionEntreeAgenda()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionEntreeAgenda(CEntreeAgenda entree)
			:base(entree)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionEntreeAgenda(CEntreeAgenda entree, CListeObjetsDonnees liste)
			:base(entree, liste)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionEntreeAgenda));
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.m_chkEtatAutomatique = new System.Windows.Forms.CheckBox();
            this.m_cmbEtat = new sc2i.win32.common.CComboboxAutoFilled();
            this.m_panelEntreeNonCyclique = new System.Windows.Forms.Panel();
            this.m_panelRappel = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.m_numUpRappel = new sc2i.win32.common.C2iNumericUpDown();
            this.m_chkRappel = new System.Windows.Forms.CheckBox();
            this.m_btnCyclique = new System.Windows.Forms.Button();
            this.m_chkSansHoraire = new System.Windows.Forms.CheckBox();
            this.m_dtDebut = new sc2i.win32.common.C2iDateTimePicker();
            this.m_panelHeure = new sc2i.win32.common.C2iPanel(this.components);
            this.m_txtHeureFin = new sc2i.win32.common.C2iComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtHeureDebut = new sc2i.win32.common.C2iComboBox();
            this.m_dtFin = new sc2i.win32.common.C2iDateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_panelCyclique = new System.Windows.Forms.Panel();
            this.m_lnkModifierParametres = new System.Windows.Forms.LinkLabel();
            this.label10 = new System.Windows.Forms.Label();
            this.m_btnNonCyclique = new System.Windows.Forms.Button();
            this.m_labelInfoCyclique = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.m_panelLiensElements = new sc2i.win32.common.C2iPanel(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.c2iTabControl1 = new sc2i.win32.common.C2iTabControl(this.components);
            this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.m_txtCommentaires = new sc2i.win32.common.C2iTextBox();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.m_panelChamps = new sc2i.win32.data.dynamic.CPanelChampsCustom();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.m_panelEntreeNonCyclique.SuspendLayout();
            this.m_panelRappel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_numUpRappel)).BeginInit();
            this.m_panelHeure.SuspendLayout();
            this.m_panelCyclique.SuspendLayout();
            this.c2iTabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
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
            this.m_panelNavigation.Location = new System.Drawing.Point(694, 0);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label1, "");
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
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_txtLibelle.Location = new System.Drawing.Point(72, 8);
            this.m_txtLibelle.LockEdition = false;
            this.m_txtLibelle.MaxLength = 255;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(726, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Label]|30324";
            // 
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.checkBox2);
            this.c2iPanelOmbre4.Controls.Add(this.m_chkEtatAutomatique);
            this.c2iPanelOmbre4.Controls.Add(this.m_cmbEtat);
            this.c2iPanelOmbre4.Controls.Add(this.label1);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.Controls.Add(this.m_panelEntreeNonCyclique);
            this.c2iPanelOmbre4.Controls.Add(this.label6);
            this.c2iPanelOmbre4.Controls.Add(this.m_panelCyclique);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(8, 56);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(822, 120);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.checkBox2, "EntreePrivee");
            this.checkBox2.Location = new System.Drawing.Point(614, 80);
            this.m_gestionnaireModeEdition.SetModeEdition(this.checkBox2, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.checkBox2, "");
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(104, 16);
            this.m_extStyle.SetStyleBackColor(this.checkBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.checkBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.checkBox2.TabIndex = 4015;
            this.checkBox2.Text = "Private entry|860";
            // 
            // m_chkEtatAutomatique
            // 
            this.m_chkEtatAutomatique.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_chkEtatAutomatique, "EtatAuto");
            this.m_chkEtatAutomatique.Location = new System.Drawing.Point(614, 64);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkEtatAutomatique, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkEtatAutomatique, "");
            this.m_chkEtatAutomatique.Name = "m_chkEtatAutomatique";
            this.m_chkEtatAutomatique.Size = new System.Drawing.Size(184, 16);
            this.m_extStyle.SetStyleBackColor(this.m_chkEtatAutomatique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkEtatAutomatique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkEtatAutomatique.TabIndex = 4013;
            this.m_chkEtatAutomatique.Text = "Automatic state management|859";
            this.m_chkEtatAutomatique.CheckedChanged += new System.EventHandler(this.m_chkEtatAutomatique_CheckedChanged);
            // 
            // m_cmbEtat
            // 
            this.m_cmbEtat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbEtat.BackColor = System.Drawing.Color.White;
            this.m_cmbEtat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbEtat.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbEtat, "Etat");
            this.m_cmbEtat.ListDonnees = null;
            this.m_cmbEtat.Location = new System.Drawing.Point(614, 40);
            this.m_cmbEtat.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbEtat, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbEtat, "");
            this.m_cmbEtat.Name = "m_cmbEtat";
            this.m_cmbEtat.NullAutorise = false;
            this.m_cmbEtat.ProprieteAffichee = "Libelle";
            this.m_cmbEtat.Size = new System.Drawing.Size(184, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbEtat, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbEtat, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbEtat.TabIndex = 4012;
            this.m_cmbEtat.TextNull = I.T("(empty)|30195");
            this.m_cmbEtat.Tri = true;
            this.m_cmbEtat.SelectedIndexChanged += new System.EventHandler(this.m_cmbEtat_SelectedIndexChanged);
            // 
            // m_panelEntreeNonCyclique
            // 
            this.m_panelEntreeNonCyclique.Controls.Add(this.m_panelRappel);
            this.m_panelEntreeNonCyclique.Controls.Add(this.m_btnCyclique);
            this.m_panelEntreeNonCyclique.Controls.Add(this.m_chkSansHoraire);
            this.m_panelEntreeNonCyclique.Controls.Add(this.m_dtDebut);
            this.m_panelEntreeNonCyclique.Controls.Add(this.m_panelHeure);
            this.m_panelEntreeNonCyclique.Controls.Add(this.m_dtFin);
            this.m_panelEntreeNonCyclique.Controls.Add(this.label4);
            this.m_panelEntreeNonCyclique.Controls.Add(this.label2);
            this.m_extLinkField.SetLinkField(this.m_panelEntreeNonCyclique, "");
            this.m_panelEntreeNonCyclique.Location = new System.Drawing.Point(0, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEntreeNonCyclique, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelEntreeNonCyclique, "");
            this.m_panelEntreeNonCyclique.Name = "m_panelEntreeNonCyclique";
            this.m_panelEntreeNonCyclique.Size = new System.Drawing.Size(408, 64);
            this.m_extStyle.SetStyleBackColor(this.m_panelEntreeNonCyclique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEntreeNonCyclique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEntreeNonCyclique.TabIndex = 4016;
            // 
            // m_panelRappel
            // 
            this.m_panelRappel.Controls.Add(this.label9);
            this.m_panelRappel.Controls.Add(this.m_numUpRappel);
            this.m_panelRappel.Controls.Add(this.m_chkRappel);
            this.m_extLinkField.SetLinkField(this.m_panelRappel, "");
            this.m_panelRappel.Location = new System.Drawing.Point(256, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelRappel, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelRappel, "");
            this.m_panelRappel.Name = "m_panelRappel";
            this.m_panelRappel.Size = new System.Drawing.Size(144, 24);
            this.m_extStyle.SetStyleBackColor(this.m_panelRappel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelRappel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelRappel.TabIndex = 4016;
            // 
            // label9
            // 
            this.m_extLinkField.SetLinkField(this.label9, "");
            this.label9.Location = new System.Drawing.Point(120, 4);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label9, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label9, "");
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 16);
            this.m_extStyle.SetStyleBackColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label9.TabIndex = 7;
            this.label9.Text = "Min.";
            this.label9.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // m_numUpRappel
            // 
            this.m_numUpRappel.DoubleValue = 0;
            this.m_numUpRappel.IntValue = 0;
            this.m_extLinkField.SetLinkField(this.m_numUpRappel, "");
            this.m_numUpRappel.Location = new System.Drawing.Point(72, 2);
            this.m_numUpRappel.LockEdition = false;
            this.m_numUpRappel.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_numUpRappel, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_numUpRappel, "");
            this.m_numUpRappel.Name = "m_numUpRappel";
            this.m_numUpRappel.Size = new System.Drawing.Size(48, 20);
            this.m_extStyle.SetStyleBackColor(this.m_numUpRappel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_numUpRappel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_numUpRappel.TabIndex = 6;
            this.m_numUpRappel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_numUpRappel.ThousandsSeparator = true;
            // 
            // m_chkRappel
            // 
            this.m_extLinkField.SetLinkField(this.m_chkRappel, "");
            this.m_chkRappel.Location = new System.Drawing.Point(8, 4);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkRappel, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkRappel, "");
            this.m_chkRappel.Name = "m_chkRappel";
            this.m_chkRappel.Size = new System.Drawing.Size(64, 16);
            this.m_extStyle.SetStyleBackColor(this.m_chkRappel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkRappel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkRappel.TabIndex = 5;
            this.m_chkRappel.Text = "Remind|858";
            this.m_chkRappel.CheckedChanged += new System.EventHandler(this.m_chkRappel_CheckedChanged);
            // 
            // m_btnCyclique
            // 
            this.m_btnCyclique.Image = ((System.Drawing.Image)(resources.GetObject("m_btnCyclique.Image")));
            this.m_extLinkField.SetLinkField(this.m_btnCyclique, "");
            this.m_btnCyclique.Location = new System.Drawing.Point(376, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnCyclique, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnCyclique, "");
            this.m_btnCyclique.Name = "m_btnCyclique";
            this.m_btnCyclique.Size = new System.Drawing.Size(32, 23);
            this.m_extStyle.SetStyleBackColor(this.m_btnCyclique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnCyclique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnCyclique.TabIndex = 4015;
            this.m_btnCyclique.Click += new System.EventHandler(this.m_btnCyclique_Click);
            // 
            // m_chkSansHoraire
            // 
            this.m_extLinkField.SetLinkField(this.m_chkSansHoraire, "SansHoraire");
            this.m_chkSansHoraire.Location = new System.Drawing.Point(264, 10);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkSansHoraire, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkSansHoraire, "");
            this.m_chkSansHoraire.Name = "m_chkSansHoraire";
            this.m_chkSansHoraire.Size = new System.Drawing.Size(106, 16);
            this.m_extStyle.SetStyleBackColor(this.m_chkSansHoraire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkSansHoraire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkSansHoraire.TabIndex = 4;
            this.m_chkSansHoraire.Text = "Without time|857";
            this.m_chkSansHoraire.CheckedChanged += new System.EventHandler(this.m_chkSansHoraire_CheckedChanged);
            // 
            // m_dtDebut
            // 
            this.m_dtDebut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.m_extLinkField.SetLinkField(this.m_dtDebut, "");
            this.m_dtDebut.Location = new System.Drawing.Point(72, 8);
            this.m_dtDebut.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_dtDebut, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_dtDebut, "");
            this.m_dtDebut.Name = "m_dtDebut";
            this.m_dtDebut.Size = new System.Drawing.Size(88, 20);
            this.m_extStyle.SetStyleBackColor(this.m_dtDebut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_dtDebut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_dtDebut.TabIndex = 1;
            this.m_dtDebut.Value = new System.DateTime(2003, 4, 2, 9, 17, 49, 526);
            this.m_dtDebut.Validated += new System.EventHandler(this.m_dtDebut_Validated);
            // 
            // m_panelHeure
            // 
            this.m_panelHeure.Controls.Add(this.m_txtHeureFin);
            this.m_panelHeure.Controls.Add(this.label5);
            this.m_panelHeure.Controls.Add(this.label3);
            this.m_panelHeure.Controls.Add(this.m_txtHeureDebut);
            this.m_extLinkField.SetLinkField(this.m_panelHeure, "");
            this.m_panelHeure.Location = new System.Drawing.Point(168, 8);
            this.m_panelHeure.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelHeure, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelHeure, "");
            this.m_panelHeure.Name = "m_panelHeure";
            this.m_panelHeure.Size = new System.Drawing.Size(80, 48);
            this.m_extStyle.SetStyleBackColor(this.m_panelHeure, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelHeure, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelHeure.TabIndex = 3;
            // 
            // m_txtHeureFin
            // 
            this.m_txtHeureFin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_txtHeureFin.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_txtHeureFin, "");
            this.m_txtHeureFin.Location = new System.Drawing.Point(24, 24);
            this.m_txtHeureFin.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtHeureFin, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtHeureFin, "");
            this.m_txtHeureFin.Name = "m_txtHeureFin";
            this.m_txtHeureFin.Size = new System.Drawing.Size(56, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtHeureFin, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtHeureFin, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtHeureFin.TabIndex = 4015;
            // 
            // label5
            // 
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.label5.Location = new System.Drawing.Point(8, 26);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 16);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 4008;
            this.label5.Text = "at|65";
            // 
            // label3
            // 
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(8, 2);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 16);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4006;
            this.label3.Text = "at|65";
            // 
            // m_txtHeureDebut
            // 
            this.m_txtHeureDebut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_txtHeureDebut.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_txtHeureDebut, "");
            this.m_txtHeureDebut.Location = new System.Drawing.Point(24, 0);
            this.m_txtHeureDebut.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtHeureDebut, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtHeureDebut, "");
            this.m_txtHeureDebut.Name = "m_txtHeureDebut";
            this.m_txtHeureDebut.Size = new System.Drawing.Size(56, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtHeureDebut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtHeureDebut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtHeureDebut.TabIndex = 4014;
            this.m_txtHeureDebut.Validated += new System.EventHandler(this.m_txtHeureValidated);
            // 
            // m_dtFin
            // 
            this.m_dtFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.m_extLinkField.SetLinkField(this.m_dtFin, "");
            this.m_dtFin.Location = new System.Drawing.Point(72, 32);
            this.m_dtFin.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_dtFin, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_dtFin, "");
            this.m_dtFin.Name = "m_dtFin";
            this.m_dtFin.Size = new System.Drawing.Size(88, 20);
            this.m_extStyle.SetStyleBackColor(this.m_dtFin, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_dtFin, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_dtFin.TabIndex = 2;
            this.m_dtFin.Value = new System.DateTime(2003, 4, 2, 9, 17, 49, 526);
            this.m_dtFin.Validated += new System.EventHandler(this.m_dtFin_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.label4.Location = new System.Drawing.Point(8, 35);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 4010;
            this.label4.Text = "End|574";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(8, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4004;
            this.label2.Text = "Start|571";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.label6.Location = new System.Drawing.Point(549, 43);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label6, "");
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 15);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 4011;
            this.label6.Text = "State|57";
            // 
            // m_panelCyclique
            // 
            this.m_panelCyclique.Controls.Add(this.m_lnkModifierParametres);
            this.m_panelCyclique.Controls.Add(this.label10);
            this.m_panelCyclique.Controls.Add(this.m_btnNonCyclique);
            this.m_panelCyclique.Controls.Add(this.m_labelInfoCyclique);
            this.m_extLinkField.SetLinkField(this.m_panelCyclique, "");
            this.m_panelCyclique.Location = new System.Drawing.Point(0, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelCyclique, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelCyclique, "");
            this.m_panelCyclique.Name = "m_panelCyclique";
            this.m_panelCyclique.Size = new System.Drawing.Size(408, 72);
            this.m_extStyle.SetStyleBackColor(this.m_panelCyclique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCyclique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelCyclique.TabIndex = 4017;
            // 
            // m_lnkModifierParametres
            // 
            this.m_lnkModifierParametres.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_lnkModifierParametres, "");
            this.m_lnkModifierParametres.Location = new System.Drawing.Point(272, 48);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkModifierParametres, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkModifierParametres, "");
            this.m_lnkModifierParametres.Name = "m_lnkModifierParametres";
            this.m_lnkModifierParametres.Size = new System.Drawing.Size(128, 23);
            this.m_extStyle.SetStyleBackColor(this.m_lnkModifierParametres, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkModifierParametres, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkModifierParametres.TabIndex = 4020;
            this.m_lnkModifierParametres.TabStop = true;
            this.m_lnkModifierParametres.Text = "Modifier les paramètres";
            this.m_lnkModifierParametres.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.m_lnkModifierParametres.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkModifierParametres_LinkClicked);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label10, "");
            this.label10.Location = new System.Drawing.Point(8, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label10, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label10, "");
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 23);
            this.m_extStyle.SetStyleBackColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label10.TabIndex = 4015;
            this.label10.Text = "Entrée cyclique";
            // 
            // m_btnNonCyclique
            // 
            this.m_btnNonCyclique.Image = ((System.Drawing.Image)(resources.GetObject("m_btnNonCyclique.Image")));
            this.m_extLinkField.SetLinkField(this.m_btnNonCyclique, "");
            this.m_btnNonCyclique.Location = new System.Drawing.Point(376, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnNonCyclique, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnNonCyclique, "");
            this.m_btnNonCyclique.Name = "m_btnNonCyclique";
            this.m_btnNonCyclique.Size = new System.Drawing.Size(32, 23);
            this.m_extStyle.SetStyleBackColor(this.m_btnNonCyclique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnNonCyclique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnNonCyclique.TabIndex = 4014;
            this.m_btnNonCyclique.Click += new System.EventHandler(this.m_btnNonCyclique_Click);
            // 
            // m_labelInfoCyclique
            // 
            this.m_extLinkField.SetLinkField(this.m_labelInfoCyclique, "");
            this.m_labelInfoCyclique.Location = new System.Drawing.Point(16, 24);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_labelInfoCyclique, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_labelInfoCyclique, "");
            this.m_labelInfoCyclique.Name = "m_labelInfoCyclique";
            this.m_labelInfoCyclique.Size = new System.Drawing.Size(392, 24);
            this.m_extStyle.SetStyleBackColor(this.m_labelInfoCyclique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_labelInfoCyclique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_labelInfoCyclique.TabIndex = 4013;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label7, "TypeEntree.Libelle");
            this.label7.Location = new System.Drawing.Point(8, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label7, "");
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(640, 24);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 4002;
            this.label7.Text = "[TypeEntree.Libelle]";
            // 
            // m_panelLiensElements
            // 
            this.m_panelLiensElements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelLiensElements.AutoScroll = true;
            this.m_extLinkField.SetLinkField(this.m_panelLiensElements, "");
            this.m_panelLiensElements.Location = new System.Drawing.Point(11, 24);
            this.m_panelLiensElements.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelLiensElements, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelLiensElements, "");
            this.m_panelLiensElements.Name = "m_panelLiensElements";
            this.m_panelLiensElements.Size = new System.Drawing.Size(795, 282);
            this.m_extStyle.SetStyleBackColor(this.m_panelLiensElements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelLiensElements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelLiensElements.TabIndex = 4014;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label8, "");
            this.label8.Location = new System.Drawing.Point(8, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label8, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label8, "");
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 13);
            this.m_extStyle.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 4013;
            this.label8.Text = "Linked elements|861";
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
            this.c2iTabControl1.Location = new System.Drawing.Point(8, 176);
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTabControl1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iTabControl1, "");
            this.c2iTabControl1.Name = "c2iTabControl1";
            this.c2iTabControl1.Ombre = true;
            this.c2iTabControl1.PositionTop = true;
            this.c2iTabControl1.SelectedIndex = 2;
            this.c2iTabControl1.SelectedTab = this.tabPage2;
            this.c2iTabControl1.Size = new System.Drawing.Size(822, 354);
            this.m_extStyle.SetStyleBackColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iTabControl1.TabIndex = 4004;
            this.c2iTabControl1.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage3,
            this.tabPage1,
            this.tabPage2});
            this.c2iTabControl1.TextColor = System.Drawing.Color.Black;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.m_panelLiensElements);
            this.tabPage3.Controls.Add(this.label8);
            this.m_extLinkField.SetLinkField(this.tabPage3, "");
            this.tabPage3.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tabPage3, "");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Selected = false;
            this.tabPage3.Size = new System.Drawing.Size(806, 313);
            this.m_extStyle.SetStyleBackColor(this.tabPage3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage3.TabIndex = 12;
            this.tabPage3.Title = "Links|84";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_txtCommentaires);
            this.m_extLinkField.SetLinkField(this.tabPage1, "");
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tabPage1, "");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Selected = false;
            this.tabPage1.Size = new System.Drawing.Size(806, 313);
            this.m_extStyle.SetStyleBackColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage1.TabIndex = 10;
            this.tabPage1.Title = "Comments|51";
            // 
            // m_txtCommentaires
            // 
            this.m_txtCommentaires.AcceptsReturn = true;
            this.m_txtCommentaires.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_txtCommentaires, "Commentaires");
            this.m_txtCommentaires.Location = new System.Drawing.Point(8, 8);
            this.m_txtCommentaires.LockEdition = false;
            this.m_txtCommentaires.MaxLength = 2048;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtCommentaires, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtCommentaires, "");
            this.m_txtCommentaires.Multiline = true;
            this.m_txtCommentaires.Name = "m_txtCommentaires";
            this.m_txtCommentaires.Size = new System.Drawing.Size(790, 298);
            this.m_extStyle.SetStyleBackColor(this.m_txtCommentaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtCommentaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtCommentaires.TabIndex = 0;
            this.m_txtCommentaires.Text = "[Commentaires]";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.m_panelChamps);
            this.m_extLinkField.SetLinkField(this.tabPage2, "");
            this.tabPage2.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tabPage2, "");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(806, 313);
            this.m_extStyle.SetStyleBackColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage2.TabIndex = 11;
            this.tabPage2.Title = "Form|60";
            // 
            // m_panelChamps
            // 
            this.m_panelChamps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelChamps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelChamps.BoldSelectedPage = true;
            this.m_panelChamps.ElementEdite = null;
            this.m_panelChamps.ForeColor = System.Drawing.Color.Black;
            this.m_panelChamps.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_panelChamps, "");
            this.m_panelChamps.Location = new System.Drawing.Point(0, -1);
            this.m_panelChamps.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelChamps, "");
            this.m_panelChamps.Name = "m_panelChamps";
            this.m_panelChamps.Ombre = false;
            this.m_panelChamps.PositionTop = true;
            this.m_panelChamps.Size = new System.Drawing.Size(806, 314);
            this.m_extStyle.SetStyleBackColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelChamps.TabIndex = 7;
            this.m_panelChamps.TextColor = System.Drawing.Color.Black;
            // 
            // CFormEditionEntreeAgenda
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.c2iTabControl1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionEntreeAgenda";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Load += new System.EventHandler(this.CFormEditionEntreeAgenda_Load);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre4, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.c2iTabControl1, 0);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            this.c2iPanelOmbre4.ResumeLayout(false);
            this.c2iPanelOmbre4.PerformLayout();
            this.m_panelEntreeNonCyclique.ResumeLayout(false);
            this.m_panelEntreeNonCyclique.PerformLayout();
            this.m_panelRappel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_numUpRappel)).EndInit();
            this.m_panelHeure.ResumeLayout(false);
            this.m_panelCyclique.ResumeLayout(false);
            this.c2iTabControl1.ResumeLayout(false);
            this.c2iTabControl1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CEntreeAgenda EntreeAgenda
		{
			get
			{
				return (CEntreeAgenda)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
			InitComboEtats ( );
            CResultAErreur result = base.MyInitChamps();
			AffecterTitre(I.T("Diary entry|30134") + EntreeAgenda.Libelle);

			if ( m_lastTypeEntree != null && EntreeAgenda.TypeEntree == null )
				EntreeAgenda.TypeEntree = m_lastTypeEntree;
			m_lastTypeEntree = EntreeAgenda.TypeEntree;

			m_dtDebut.Value = EntreeAgenda.DateDebut;
			m_dtFin.Value = EntreeAgenda.DateFin;
			m_txtHeureDebut.Text = EntreeAgenda.DateDebut.Hour.ToString().PadLeft(2,'0')+":"+EntreeAgenda.DateDebut.Minute.ToString().PadLeft(2,'0');
			m_txtHeureFin.Text = EntreeAgenda.DateFin.Hour.ToString().PadLeft(2,'0')+":"+EntreeAgenda.DateFin.Minute.ToString().PadLeft(2,'0');

			InitListeLiens();

			UpdatePanelHeure();

			if ( EntreeAgenda.MinutesRappel < 0 )
			{
				m_chkRappel.Checked = false;
				m_numUpRappel.IntValue = 0;
			}
			else
			{
				m_chkRappel.Checked = true;
				m_numUpRappel.IntValue = EntreeAgenda.MinutesRappel;
			}


			m_panelChamps.ElementEdite = EntreeAgenda;

			m_panelCyclique.Visible = EntreeAgenda.IsCyclique;
			m_panelEntreeNonCyclique.Visible = !EntreeAgenda.IsCyclique;
			if ( EntreeAgenda.IsCyclique )
				UpdateCyclique();

			return result;
		}

		private CResultAErreur VerifieHeure ( string strHeure, ref int nHeure, ref int nMin )
		{
			CResultAErreur result = CResultAErreur.True;
			if ( strHeure.IndexOf(":") < 0 )
				strHeure += ":0";
			string[] strTime = strHeure.Split(':');
			try
			{
				nHeure = Int32.Parse(strTime[0]);
				nMin = Int32.Parse ( strTime[1] );
			}
			catch
			{
				result.EmpileErreur(I.T("Invalid hour|30135"));
			}
			if ( nHeure < 0 || nHeure > 23 || nMin < 0 || nMin > 59 )
			{
                result.EmpileErreur(I.T("Invalid hour|30135"));
			}
			return result;
		}

		//-------------------------------------------------------------------------
		protected override CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = base.MAJ_Champs();
			EntreeAgenda.IsCyclique = m_panelCyclique.Visible;
			if ( m_chkSansHoraire.Checked || m_panelCyclique.Visible )
			{
				EntreeAgenda.DateDebut = m_dtDebut.Value;
				EntreeAgenda.DateFin = m_dtFin.Value;
				EntreeAgenda.MinutesRappel = -1;
			}
			else
			{
				int nHeure = 0, nMin = 0;
				result = VerifieHeure ( m_txtHeureDebut.Text, ref nHeure, ref nMin );
				if ( !result )
					return result;
				DateTime dt = new DateTime ( m_dtDebut.Value.Year, m_dtDebut.Value.Month,m_dtDebut.Value.Day,
					nHeure, nMin, 0 );
				EntreeAgenda.DateDebut = dt;


				result = VerifieHeure ( m_txtHeureFin.Text, ref nHeure, ref nMin );
				if ( !result )
					return result;
				dt = new DateTime ( m_dtFin.Value.Year, m_dtFin.Value.Month, m_dtFin.Value.Day,
					nHeure, nMin, 0 );
				EntreeAgenda.DateFin = dt;

				EntreeAgenda.MinutesRappel = m_chkRappel.Checked?m_numUpRappel.IntValue:-1;
			}
			result = m_panelChamps.MAJ_Champs();
			if (!result )
				return result;

			CListeObjetsDonnees liste = EntreeAgenda.RelationsElementsAgenda;
			foreach ( CPanelSelectLienToElement panel in m_listeControlesLiens )
			{
				CRelationEntreeAgenda_ElementAAgenda relationToSet =  null;
				foreach ( CRelationEntreeAgenda_ElementAAgenda rel in liste )
				{
					if ( rel.RelationTypeEntree_TypeElement.Id == panel.TypeRelation.Id )
					{
						relationToSet = rel;
						break;
					}
				}
				/*if ( panel.ElementSelectionne == null && relationToSet != null )
					relationToSet.Delete();
				if ( panel.ElementSelectionne != null )
				{
					if ( relationToSet == null )
					{
						relationToSet = new CRelationEntreeAgenda_ElementAAgenda ( EntreeAgenda.ContexteDonnee );
						relationToSet.CreateNewInCurrentContexte();
						relationToSet.EntreeAgenda = EntreeAgenda;
						relationToSet.RelationTypeEntree_TypeElement = panel.TypeRelation;
					}
					relationToSet.ElementLie = panel.ElementSelectionne;
				}*/
			}
			UpdateAspectEtat();

			return result;
		}


		/// <summary>
		/// ///////////////////////////////////
		/// </summary>
		private void UpdatePanelHeure()
		{
			if ( m_chkSansHoraire.Checked )
			{
				m_panelHeure.Visible = false;
				m_panelRappel.Visible = false;
			}
			else
			{
				m_panelHeure.Visible = true;
				m_panelRappel.Visible = true;
			}
		}

		//-------------------------------------------------------------------------
		private void InitListeLiens()
		{
			foreach ( Control ctrl in m_listeControlesLiens )
			{
				ctrl.Hide();
				ctrl.Dispose();
			}
			m_listeControlesLiens = new ArrayList();
			int nY = 0;
			CListeObjetsDonnees listeRelationsToElements = EntreeAgenda.RelationsElementsAgenda;
			foreach ( CRelationTypeEntreeAgenda_TypeElementAAgenda relation in 
				EntreeAgenda.TypeEntree.RelationsTypeElementsAAgenda )
			{
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
				panel.Init ( relation, EntreeAgenda );
				m_listeControlesLiens.Add ( panel );
			}

		}

		//-------------------------------------------------------------------------
		private void CFormEditionEntreeAgenda_Load(object sender, System.EventArgs e)
		{
			for ( int nH = 0; nH < 24; nH++ )
				for ( int nM = 0; nM < 60; nM+=30 )
				{
					string strTxt = nH.ToString().PadLeft(2,'0')+":"+nM.ToString().PadLeft(2,'0');
					m_txtHeureDebut.Items.Add ( strTxt );
					m_txtHeureFin.Items.Add ( strTxt );
				}
			m_formatteurHeure.AttachTo ( m_txtHeureDebut );
			m_formatteurHeure.AttachTo ( m_txtHeureFin );
		}
		
		//-------------------------------------------------------------------------
		private void InitComboEtats()
		{
			ArrayList lstEtats = new ArrayList();
			foreach ( CEtatEntreeAgenda etat in CEtatEntreeAgenda.Etats )
			{
				lstEtats.Add ( etat );
			}
			m_cmbEtat.ListDonnees = lstEtats;
		}

		private void m_chkSansHoraire_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdatePanelHeure();
		}


		/// /////////////////////////////////////////////////////////////////////////
		private void m_dtDebut_Validated(object sender, System.EventArgs e)
		{
			if ( m_dtFin.Value < m_dtDebut.Value )
				m_dtFin.Value = m_dtDebut.Value;
		}

		/// /////////////////////////////////////////////////////////////////////////
		private void m_dtFin_Validated(object sender, System.EventArgs e)
		{
			if ( m_dtDebut.Value > m_dtFin.Value )
				m_dtDebut.Value = m_dtFin.Value;
		}

		/// /////////////////////////////////////////////////////////////////////////
		private void m_txtHeureFin_Validated(object sender, System.EventArgs e)
		{
		
		}

		/// /////////////////////////////////////////////////////////////////////////
		private void UpdateAspectEtat()
		{
			if ( m_chkEtatAutomatique.Checked )
			{
				m_gestionnaireModeEdition.SetModeEdition ( m_cmbEtat, TypeModeEdition.Autonome );
				m_cmbEtat.LockEdition = true;
			}
			else
			{
				m_gestionnaireModeEdition.SetModeEdition ( m_cmbEtat, TypeModeEdition.EnableSurEdition );
				m_cmbEtat.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
			}
			Color couleurFond = Color.White, couleurText = Color.Black;
			CCouleursForEntreeAgenda.GetCouleursFor ( EntreeAgenda, ref couleurFond, ref couleurText );
			m_cmbEtat.BackColor = couleurFond;
			m_cmbEtat.ForeColor = couleurText;
		}

		/// /////////////////////////////////////////////////////////////////////////
		private void m_chkEtatAutomatique_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateAspectEtat();
		}

		/// /////////////////////////////////////////////////////////////////////////
		private void m_cmbEtat_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			UpdateAspectEtat();
		}

		private void m_txtHeureValidated(object sender, System.EventArgs e)
		{
			ComboBox box = (ComboBox)sender;
			int nHeure = 0, nMin = 0;
			if ( VerifieHeure ( box.Text, ref nHeure, ref nMin ) )
				box.Text = nHeure.ToString().PadLeft(2,'0')+":"+nMin.ToString().PadLeft(2,'0');
		}

		private void m_btnNonCyclique_Click(object sender, System.EventArgs e)
		{
			m_panelCyclique.Visible = false;
			m_panelEntreeNonCyclique.Visible = true;
		}

		private void m_btnCyclique_Click(object sender, System.EventArgs e)
		{
			m_panelCyclique.Visible = true;
			m_panelEntreeNonCyclique.Visible = false;
			if ( EntreeAgenda.PlanificationCyclique == null )
				EditerParametresCyclique();
		}

		private void UpdateCyclique()
		{
			CPlanificationTache planif = EntreeAgenda.PlanificationCyclique;
			if ( planif != null )
				m_labelInfoCyclique.Text = planif.GetLibelle();
		}

		private void m_lnkModifierParametres_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			EditerParametresCyclique();
		}

		private void EditerParametresCyclique()
		{
			/*if ( CFormParametresEntreeAgendaCyclique.EditeEntree ( EntreeAgenda ) )
			{
				m_dtDebut.Value = EntreeAgenda.DateDebut;
				m_dtFin.Value = EntreeAgenda.DateFin;
				m_chkSansHoraire.Checked = EntreeAgenda.SansHoraire;
				UpdateCyclique();
			}*/
		}

		private void m_chkRappel_CheckedChanged(object sender, System.EventArgs e)
		{
			m_numUpRappel.Enabled = m_chkRappel.Checked;
		}

	}
}

