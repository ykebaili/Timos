using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Windows.Forms;
using sc2i.data.dynamic;
using sc2i.data;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.common;
using sc2i.win32.data;
using sc2i.win32.common;
using sc2i.process;

using sc2i.workflow;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CTypeEntreeAgenda))]
	public class CFormEditionTypeEntreeAgenda : CFormEditionStdTimos, IFormNavigable
	{		
		
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.ListViewAutoFilled m_listViewRelationsComptabilites;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn8;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre1;
		private System.Windows.Forms.Label label2;
		private sc2i.win32.common.C2iTextBox c2iTextBox1;
		private timos.win32.composants.CPanelEditDefinisseurChampsCustom m_panelDefinisseurChamps;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre3;
		private System.ComponentModel.IContainer components = null;

		private const string c_champCodeEtat = "CODE_ETAT";
		private Crownwood.Magic.Controls.TabPage m_pageElementsLies;
		private Crownwood.Magic.Controls.TabPage m_pageFormulairesEtChamps;
		private System.Windows.Forms.LinkLabel m_lnkSupprimerLienElement;
		private sc2i.win32.common.C2iComboBox m_cmbTypeElementsAAgenda;
		private System.Windows.Forms.LinkLabel m_lnkAjoutLienElement;
		private System.Windows.Forms.Panel m_panelLienElement;
		private System.Windows.Forms.Label label3;
		private sc2i.win32.common.C2iTextBox m_txtLibelleLien;
		private System.Windows.Forms.CheckBox m_chkLienObligatoire;
		private sc2i.win32.common.ListViewAutoFilled m_listViewRelationElement;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn1;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn5;
		private sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee m_gestionnaireEditionRelationLien;
		private sc2i.win32.common.C2iTabControl m_tab;
		private Crownwood.Magic.Controls.TabPage m_tabPageToRemove;
		private Crownwood.Magic.Controls.TabPage m_pageEvenements;
		private sc2i.win32.common.C2iTextBox m_txtCode;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.LinkLabel m_lnkRoles;
		private sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees m_cmbRoles;
		private System.Windows.Forms.PictureBox m_wndImageRole;
		private System.Windows.Forms.Label label6;
		private sc2i.win32.data.dynamic.CPanelEditFiltreDynamique m_panelFiltre;
		private sc2i.win32.common.C2iTabControl c2iTabControl1;
		private System.Windows.Forms.CheckBox m_chkEtatAuto;
		private System.Windows.Forms.CheckBox m_chkMasquer;
		private timos.CPanelDefinisseurEvenements m_panelEvenements;
		private System.Windows.Forms.CheckBox m_chkSuppressionAutomatique;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.CheckBox m_chkLienMaitre;
		private System.Windows.Forms.CheckBox m_chkDroitModification;
		private System.Windows.Forms.CheckBox m_chkMultiple;
        private CheckBox checkBox1;
		private const string c_champLibelleEtat = "LIBELLE_ETAT";

		public CFormEditionTypeEntreeAgenda()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionTypeEntreeAgenda(CTypeEntreeAgenda typeEntree)
			:base(typeEntree)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionTypeEntreeAgenda(CTypeEntreeAgenda typeEntree, CListeObjetsDonnees liste)
			:base(typeEntree, liste)
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
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.m_listViewRelationsComptabilites = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn8 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.c2iPanelOmbre1 = new sc2i.win32.common.C2iPanelOmbre();
            this.c2iTextBox1 = new sc2i.win32.common.C2iTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_panelDefinisseurChamps = new timos.win32.composants.CPanelEditDefinisseurChampsCustom();
            this.c2iPanelOmbre3 = new sc2i.win32.common.C2iPanelOmbre();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.m_chkEtatAuto = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_tab = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageEvenements = new Crownwood.Magic.Controls.TabPage();
            this.m_panelEvenements = new timos.CPanelDefinisseurEvenements();
            this.m_tabPageToRemove = new Crownwood.Magic.Controls.TabPage();
            this.m_pageElementsLies = new Crownwood.Magic.Controls.TabPage();
            this.m_listViewRelationElement = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn5 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_panelLienElement = new System.Windows.Forms.Panel();
            this.m_chkMultiple = new System.Windows.Forms.CheckBox();
            this.m_chkDroitModification = new System.Windows.Forms.CheckBox();
            this.m_chkLienMaitre = new System.Windows.Forms.CheckBox();
            this.m_chkSuppressionAutomatique = new System.Windows.Forms.CheckBox();
            this.m_chkMasquer = new System.Windows.Forms.CheckBox();
            this.m_panelFiltre = new sc2i.win32.data.dynamic.CPanelEditFiltreDynamique();
            this.c2iTabControl1 = new sc2i.win32.common.C2iTabControl(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.m_wndImageRole = new System.Windows.Forms.PictureBox();
            this.m_cmbRoles = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.m_lnkRoles = new System.Windows.Forms.LinkLabel();
            this.m_txtCode = new sc2i.win32.common.C2iTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_chkLienObligatoire = new System.Windows.Forms.CheckBox();
            this.m_txtLibelleLien = new sc2i.win32.common.C2iTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_lnkAjoutLienElement = new System.Windows.Forms.LinkLabel();
            this.m_lnkSupprimerLienElement = new System.Windows.Forms.LinkLabel();
            this.m_cmbTypeElementsAAgenda = new sc2i.win32.common.C2iComboBox();
            this.m_pageFormulairesEtChamps = new Crownwood.Magic.Controls.TabPage();
            this.m_gestionnaireEditionRelationLien = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre1.SuspendLayout();
            this.c2iPanelOmbre3.SuspendLayout();
            this.m_tab.SuspendLayout();
            this.m_pageEvenements.SuspendLayout();
            this.m_pageElementsLies.SuspendLayout();
            this.m_panelLienElement.SuspendLayout();
            this.m_panelFiltre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_wndImageRole)).BeginInit();
            this.m_pageFormulairesEtChamps.SuspendLayout();
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
            this.label1.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.label1.Location = new System.Drawing.Point(4, 11);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label1, "");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 61;
            this.label1.Text = "Label|50";
            // 
            // m_txtLibelle
            // 
            this.m_txtLibelle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_txtLibelle.Location = new System.Drawing.Point(88, 8);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(522, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 2;
            this.m_txtLibelle.Text = "[Libelle]";
            // 
            // m_listViewRelationsComptabilites
            // 
            this.m_listViewRelationsComptabilites.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_listViewRelationsComptabilites.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn8});
            this.m_listViewRelationsComptabilites.EnableCustomisation = true;
            this.m_listViewRelationsComptabilites.FullRowSelect = true;
            this.m_listViewRelationsComptabilites.HideSelection = false;
            this.m_extLinkField.SetLinkField(this.m_listViewRelationsComptabilites, "");
            this.m_listViewRelationsComptabilites.Location = new System.Drawing.Point(8, 40);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_listViewRelationsComptabilites, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_listViewRelationsComptabilites, "");
            this.m_listViewRelationsComptabilites.Name = "m_listViewRelationsComptabilites";
            this.m_listViewRelationsComptabilites.Size = new System.Drawing.Size(360, 208);
            this.m_extStyle.SetStyleBackColor(this.m_listViewRelationsComptabilites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_listViewRelationsComptabilites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_listViewRelationsComptabilites.TabIndex = 3;
            this.m_listViewRelationsComptabilites.UseCompatibleStateImageBehavior = false;
            this.m_listViewRelationsComptabilites.View = System.Windows.Forms.View.Details;
            // 
            // listViewAutoFilledColumn8
            // 
            this.listViewAutoFilledColumn8.Field = "Comptabilite.Libelle";
            this.listViewAutoFilledColumn8.PrecisionWidth = 0;
            this.listViewAutoFilledColumn8.ProportionnalSize = false;
            this.listViewAutoFilledColumn8.Text = "Comptabilité.Libellé";
            this.listViewAutoFilledColumn8.Visible = true;
            this.listViewAutoFilledColumn8.Width = 300;
            // 
            // c2iPanelOmbre1
            // 
            this.c2iPanelOmbre1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iPanelOmbre1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre1.Controls.Add(this.c2iTextBox1);
            this.c2iPanelOmbre1.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre1.Controls.Add(this.label1);
            this.c2iPanelOmbre1.Controls.Add(this.label2);
            this.c2iPanelOmbre1.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre1, "");
            this.c2iPanelOmbre1.Location = new System.Drawing.Point(8, 40);
            this.c2iPanelOmbre1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre1, "");
            this.c2iPanelOmbre1.Name = "c2iPanelOmbre1";
            this.c2iPanelOmbre1.Size = new System.Drawing.Size(634, 136);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre1.TabIndex = 0;
            // 
            // c2iTextBox1
            // 
            this.c2iTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.c2iTextBox1, "Description");
            this.c2iTextBox1.Location = new System.Drawing.Point(88, 40);
            this.c2iTextBox1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBox1, "");
            this.c2iTextBox1.Multiline = true;
            this.c2iTextBox1.Name = "c2iTextBox1";
            this.c2iTextBox1.Size = new System.Drawing.Size(522, 72);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox1.TabIndex = 63;
            this.c2iTextBox1.Text = "[Description]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(4, 43);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 62;
            this.label2.Text = "Description|41";
            // 
            // m_panelDefinisseurChamps
            // 
            this.m_panelDefinisseurChamps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelDefinisseurChamps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelDefinisseurChamps.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panelDefinisseurChamps, "");
            this.m_panelDefinisseurChamps.Location = new System.Drawing.Point(0, 0);
            this.m_panelDefinisseurChamps.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelDefinisseurChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelDefinisseurChamps, "");
            this.m_panelDefinisseurChamps.Name = "m_panelDefinisseurChamps";
            this.m_panelDefinisseurChamps.Size = new System.Drawing.Size(806, 314);
            this.m_extStyle.SetStyleBackColor(this.m_panelDefinisseurChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panelDefinisseurChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelDefinisseurChamps.TabIndex = 3;
            // 
            // c2iPanelOmbre3
            // 
            this.c2iPanelOmbre3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iPanelOmbre3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre3.Controls.Add(this.checkBox1);
            this.c2iPanelOmbre3.Controls.Add(this.checkBox2);
            this.c2iPanelOmbre3.Controls.Add(this.m_chkEtatAuto);
            this.c2iPanelOmbre3.Controls.Add(this.label4);
            this.c2iPanelOmbre3.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre3, "");
            this.c2iPanelOmbre3.Location = new System.Drawing.Point(642, 40);
            this.c2iPanelOmbre3.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre3, "");
            this.c2iPanelOmbre3.Name = "c2iPanelOmbre3";
            this.c2iPanelOmbre3.Size = new System.Drawing.Size(184, 136);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre3, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre3, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre3.TabIndex = 4002;
            // 
            // checkBox2
            // 
            this.m_extLinkField.SetLinkField(this.checkBox2, "IsTache");
            this.checkBox2.Location = new System.Drawing.Point(8, 79);
            this.m_gestionnaireModeEdition.SetModeEdition(this.checkBox2, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.checkBox2, "");
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(152, 24);
            this.m_extStyle.SetStyleBackColor(this.checkBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.checkBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.checkBox2.TabIndex = 62;
            this.checkBox2.Text = "Task|20151";
            // 
            // m_chkEtatAuto
            // 
            this.m_extLinkField.SetLinkField(this.m_chkEtatAuto, "EtatAuto");
            this.m_chkEtatAuto.Location = new System.Drawing.Point(8, 24);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkEtatAuto, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkEtatAuto, "");
            this.m_chkEtatAuto.Name = "m_chkEtatAuto";
            this.m_chkEtatAuto.Size = new System.Drawing.Size(152, 32);
            this.m_extStyle.SetStyleBackColor(this.m_chkEtatAuto, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkEtatAuto, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkEtatAuto.TabIndex = 6;
            this.m_chkEtatAuto.Text = "Automatic state management|964";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.label4.Location = new System.Drawing.Point(8, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 16);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 61;
            this.label4.Text = "Options|56";
            // 
            // m_tab
            // 
            this.m_tab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_tab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_tab.BoldSelectedPage = true;
            this.m_tab.ControlBottomOffset = 16;
            this.m_tab.ControlRightOffset = 16;
            this.m_tab.ForeColor = System.Drawing.Color.Black;
            this.m_tab.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_tab, "");
            this.m_tab.Location = new System.Drawing.Point(8, 176);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tab, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tab, "");
            this.m_tab.Name = "m_tab";
            this.m_tab.Ombre = true;
            this.m_tab.PositionTop = true;
            this.m_tab.SelectedIndex = 0;
            this.m_tab.SelectedTab = this.m_tabPageToRemove;
            this.m_tab.Size = new System.Drawing.Size(822, 354);
            this.m_extStyle.SetStyleBackColor(this.m_tab, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tab, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tab.TabIndex = 4003;
            this.m_tab.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_tabPageToRemove,
            this.m_pageElementsLies,
            this.m_pageFormulairesEtChamps,
            this.m_pageEvenements});
            this.m_tab.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageEvenements
            // 
            this.m_pageEvenements.Controls.Add(this.m_panelEvenements);
            this.m_extLinkField.SetLinkField(this.m_pageEvenements, "");
            this.m_pageEvenements.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageEvenements, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageEvenements, "");
            this.m_pageEvenements.Name = "m_pageEvenements";
            this.m_pageEvenements.Selected = false;
            this.m_pageEvenements.Size = new System.Drawing.Size(806, 313);
            this.m_extStyle.SetStyleBackColor(this.m_pageEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageEvenements.TabIndex = 10;
            this.m_pageEvenements.Title = "Events|183";
            // 
            // m_panelEvenements
            // 
            this.m_panelEvenements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelEvenements, "");
            this.m_panelEvenements.Location = new System.Drawing.Point(0, 0);
            this.m_panelEvenements.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEvenements, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelEvenements, "");
            this.m_panelEvenements.Name = "m_panelEvenements";
            this.m_panelEvenements.Size = new System.Drawing.Size(806, 313);
            this.m_extStyle.SetStyleBackColor(this.m_panelEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEvenements.TabIndex = 0;
            // 
            // m_tabPageToRemove
            // 
            this.m_extLinkField.SetLinkField(this.m_tabPageToRemove, "");
            this.m_tabPageToRemove.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabPageToRemove, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabPageToRemove, "");
            this.m_tabPageToRemove.Name = "m_tabPageToRemove";
            this.m_tabPageToRemove.Size = new System.Drawing.Size(806, 313);
            this.m_extStyle.SetStyleBackColor(this.m_tabPageToRemove, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabPageToRemove, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabPageToRemove.TabIndex = 2;
            // 
            // m_pageElementsLies
            // 
            this.m_pageElementsLies.Controls.Add(this.m_listViewRelationElement);
            this.m_pageElementsLies.Controls.Add(this.m_panelLienElement);
            this.m_pageElementsLies.Controls.Add(this.m_lnkAjoutLienElement);
            this.m_pageElementsLies.Controls.Add(this.m_lnkSupprimerLienElement);
            this.m_pageElementsLies.Controls.Add(this.m_cmbTypeElementsAAgenda);
            this.m_extLinkField.SetLinkField(this.m_pageElementsLies, "");
            this.m_pageElementsLies.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageElementsLies, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageElementsLies, "");
            this.m_pageElementsLies.Name = "m_pageElementsLies";
            this.m_pageElementsLies.Selected = false;
            this.m_pageElementsLies.Size = new System.Drawing.Size(806, 313);
            this.m_extStyle.SetStyleBackColor(this.m_pageElementsLies, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageElementsLies, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageElementsLies.TabIndex = 0;
            this.m_pageElementsLies.Title = "Linked elements|954";
            // 
            // m_listViewRelationElement
            // 
            this.m_listViewRelationElement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_listViewRelationElement.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn1,
            this.listViewAutoFilledColumn5});
            this.m_listViewRelationElement.EnableCustomisation = false;
            this.m_listViewRelationElement.FullRowSelect = true;
            this.m_listViewRelationElement.HideSelection = false;
            this.m_extLinkField.SetLinkField(this.m_listViewRelationElement, "");
            this.m_listViewRelationElement.Location = new System.Drawing.Point(8, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_listViewRelationElement, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_listViewRelationElement, "");
            this.m_listViewRelationElement.MultiSelect = false;
            this.m_listViewRelationElement.Name = "m_listViewRelationElement";
            this.m_listViewRelationElement.Size = new System.Drawing.Size(376, 274);
            this.m_extStyle.SetStyleBackColor(this.m_listViewRelationElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_listViewRelationElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_listViewRelationElement.TabIndex = 14;
            this.m_listViewRelationElement.UseCompatibleStateImageBehavior = false;
            this.m_listViewRelationElement.View = System.Windows.Forms.View.Details;
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "Libelle";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Label|50";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 203;
            // 
            // listViewAutoFilledColumn5
            // 
            this.listViewAutoFilledColumn5.Field = "TypeElementsConvivial";
            this.listViewAutoFilledColumn5.PrecisionWidth = 0;
            this.listViewAutoFilledColumn5.ProportionnalSize = false;
            this.listViewAutoFilledColumn5.Text = "Type|54";
            this.listViewAutoFilledColumn5.Visible = true;
            this.listViewAutoFilledColumn5.Width = 156;
            // 
            // m_panelLienElement
            // 
            this.m_panelLienElement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelLienElement.Controls.Add(this.m_chkMultiple);
            this.m_panelLienElement.Controls.Add(this.m_chkDroitModification);
            this.m_panelLienElement.Controls.Add(this.m_chkLienMaitre);
            this.m_panelLienElement.Controls.Add(this.m_chkSuppressionAutomatique);
            this.m_panelLienElement.Controls.Add(this.m_chkMasquer);
            this.m_panelLienElement.Controls.Add(this.m_panelFiltre);
            this.m_panelLienElement.Controls.Add(this.label6);
            this.m_panelLienElement.Controls.Add(this.m_wndImageRole);
            this.m_panelLienElement.Controls.Add(this.m_cmbRoles);
            this.m_panelLienElement.Controls.Add(this.m_lnkRoles);
            this.m_panelLienElement.Controls.Add(this.m_txtCode);
            this.m_panelLienElement.Controls.Add(this.label5);
            this.m_panelLienElement.Controls.Add(this.m_chkLienObligatoire);
            this.m_panelLienElement.Controls.Add(this.m_txtLibelleLien);
            this.m_panelLienElement.Controls.Add(this.label3);
            this.m_extLinkField.SetLinkField(this.m_panelLienElement, "");
            this.m_panelLienElement.Location = new System.Drawing.Point(392, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelLienElement, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelLienElement, "");
            this.m_panelLienElement.Name = "m_panelLienElement";
            this.m_panelLienElement.Size = new System.Drawing.Size(406, 298);
            this.m_extStyle.SetStyleBackColor(this.m_panelLienElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelLienElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelLienElement.TabIndex = 13;
            this.m_panelLienElement.Visible = false;
            // 
            // m_chkMultiple
            // 
            this.m_extLinkField.SetLinkField(this.m_chkMultiple, "");
            this.m_chkMultiple.Location = new System.Drawing.Point(261, 88);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkMultiple, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkMultiple, "");
            this.m_chkMultiple.Name = "m_chkMultiple";
            this.m_chkMultiple.Size = new System.Drawing.Size(96, 16);
            this.m_extStyle.SetStyleBackColor(this.m_chkMultiple, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkMultiple, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkMultiple.TabIndex = 13;
            this.m_chkMultiple.Text = "Multiple|971";
            // 
            // m_chkDroitModification
            // 
            this.m_extLinkField.SetLinkField(this.m_chkDroitModification, "");
            this.m_chkDroitModification.Location = new System.Drawing.Point(261, 72);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkDroitModification, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkDroitModification, "");
            this.m_chkDroitModification.Name = "m_chkDroitModification";
            this.m_chkDroitModification.Size = new System.Drawing.Size(137, 16);
            this.m_extStyle.SetStyleBackColor(this.m_chkDroitModification, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkDroitModification, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkDroitModification.TabIndex = 12;
            this.m_chkDroitModification.Text = "Modification right|969";
            this.m_chkDroitModification.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // m_chkLienMaitre
            // 
            this.m_extLinkField.SetLinkField(this.m_chkLienMaitre, "");
            this.m_chkLienMaitre.Location = new System.Drawing.Point(143, 72);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkLienMaitre, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkLienMaitre, "");
            this.m_chkLienMaitre.Name = "m_chkLienMaitre";
            this.m_chkLienMaitre.Size = new System.Drawing.Size(104, 16);
            this.m_extStyle.SetStyleBackColor(this.m_chkLienMaitre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkLienMaitre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkLienMaitre.TabIndex = 11;
            this.m_chkLienMaitre.Text = "Master link|968";
            // 
            // m_chkSuppressionAutomatique
            // 
            this.m_extLinkField.SetLinkField(this.m_chkSuppressionAutomatique, "Masquer");
            this.m_chkSuppressionAutomatique.Location = new System.Drawing.Point(143, 88);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkSuppressionAutomatique, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkSuppressionAutomatique, "");
            this.m_chkSuppressionAutomatique.Name = "m_chkSuppressionAutomatique";
            this.m_chkSuppressionAutomatique.Size = new System.Drawing.Size(123, 16);
            this.m_extStyle.SetStyleBackColor(this.m_chkSuppressionAutomatique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkSuppressionAutomatique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkSuppressionAutomatique.TabIndex = 10;
            this.m_chkSuppressionAutomatique.Text = "Auto remove|970";
            // 
            // m_chkMasquer
            // 
            this.m_extLinkField.SetLinkField(this.m_chkMasquer, "Masquer");
            this.m_chkMasquer.Location = new System.Drawing.Point(8, 88);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkMasquer, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkMasquer, "");
            this.m_chkMasquer.Name = "m_chkMasquer";
            this.m_chkMasquer.Size = new System.Drawing.Size(93, 16);
            this.m_extStyle.SetStyleBackColor(this.m_chkMasquer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkMasquer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkMasquer.TabIndex = 3;
            this.m_chkMasquer.Text = "Hide|967";
            // 
            // m_panelFiltre
            // 
            this.m_panelFiltre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelFiltre.BackColor = System.Drawing.Color.White;
            this.m_panelFiltre.Controls.Add(this.c2iTabControl1);
            this.m_panelFiltre.DefinitionRacineDeChampsFiltres = null;
            this.m_panelFiltre.FiltreDynamique = null;
            this.m_extLinkField.SetLinkField(this.m_panelFiltre, "");
            this.m_panelFiltre.Location = new System.Drawing.Point(0, 144);
            this.m_panelFiltre.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelFiltre, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelFiltre.ModeFiltreExpression = false;
            this.m_panelFiltre.ModeSansType = true;
            this.m_extModulesAssociator.SetModules(this.m_panelFiltre, "");
            this.m_panelFiltre.Name = "m_panelFiltre";
            this.m_panelFiltre.Size = new System.Drawing.Size(406, 154);
            this.m_extStyle.SetStyleBackColor(this.m_panelFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelFiltre.TabIndex = 5;
            // 
            // c2iTabControl1
            // 
            this.c2iTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iTabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(184)))));
            this.c2iTabControl1.BoldSelectedPage = true;
            this.c2iTabControl1.ControlBottomOffset = 16;
            this.c2iTabControl1.ControlRightOffset = 16;
            this.c2iTabControl1.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.c2iTabControl1, "");
            this.c2iTabControl1.Location = new System.Drawing.Point(0, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTabControl1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iTabControl1, "");
            this.c2iTabControl1.Name = "c2iTabControl1";
            this.c2iTabControl1.Ombre = true;
            this.c2iTabControl1.PositionTop = true;
            this.c2iTabControl1.Size = new System.Drawing.Size(406, 106);
            this.m_extStyle.SetStyleBackColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTabControl1.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.label6.Location = new System.Drawing.Point(8, 128);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label6, "");
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(210, 13);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 9;
            this.label6.Text = "Elements filtering|972";
            // 
            // m_wndImageRole
            // 
            this.m_extLinkField.SetLinkField(this.m_wndImageRole, "");
            this.m_wndImageRole.Location = new System.Drawing.Point(48, 106);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndImageRole, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndImageRole, "");
            this.m_wndImageRole.Name = "m_wndImageRole";
            this.m_wndImageRole.Size = new System.Drawing.Size(16, 16);
            this.m_wndImageRole.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_extStyle.SetStyleBackColor(this.m_wndImageRole, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndImageRole, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndImageRole.TabIndex = 8;
            this.m_wndImageRole.TabStop = false;
            // 
            // m_cmbRoles
            // 
            this.m_cmbRoles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbRoles.ComportementLinkStd = true;
            this.m_cmbRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbRoles.ElementSelectionne = null;
            this.m_cmbRoles.IsLink = true;
            this.m_extLinkField.SetLinkField(this.m_cmbRoles, "");
            this.m_cmbRoles.LinkProperty = "";
            this.m_cmbRoles.ListDonnees = null;
            this.m_cmbRoles.Location = new System.Drawing.Point(64, 104);
            this.m_cmbRoles.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbRoles, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbRoles, "");
            this.m_cmbRoles.Name = "m_cmbRoles";
            this.m_cmbRoles.NullAutorise = true;
            this.m_cmbRoles.ProprieteAffichee = null;
            this.m_cmbRoles.ProprieteParentListeObjets = null;
            this.m_cmbRoles.SelectionneurParent = null;
            this.m_cmbRoles.Size = new System.Drawing.Size(334, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbRoles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbRoles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbRoles.TabIndex = 4;
            this.m_cmbRoles.TextNull = "(None)";
            this.m_cmbRoles.Tri = true;
            this.m_cmbRoles.TypeFormEdition = null;
            this.m_cmbRoles.SelectedIndexChanged += new System.EventHandler(this.m_cmbRoles_SelectedIndexChanged);
            // 
            // m_lnkRoles
            // 
            this.m_extLinkField.SetLinkField(this.m_lnkRoles, "");
            this.m_lnkRoles.Location = new System.Drawing.Point(7, 106);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkRoles, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkRoles, "");
            this.m_lnkRoles.Name = "m_lnkRoles";
            this.m_lnkRoles.Size = new System.Drawing.Size(40, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkRoles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkRoles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkRoles.TabIndex = 6;
            this.m_lnkRoles.TabStop = true;
            this.m_lnkRoles.Text = "Role|42";
            this.m_lnkRoles.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkRoles_LinkClicked);
            // 
            // m_txtCode
            // 
            this.m_txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_txtCode, "");
            this.m_txtCode.Location = new System.Drawing.Point(81, 48);
            this.m_txtCode.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtCode, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtCode, "");
            this.m_txtCode.Name = "m_txtCode";
            this.m_txtCode.Size = new System.Drawing.Size(317, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtCode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtCode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtCode.TabIndex = 1;
            this.m_txtCode.Text = "c2iTextBox2";
            // 
            // label5
            // 
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.label5.Location = new System.Drawing.Point(8, 50);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 19);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 4;
            this.label5.Text = "Link code|959";
            // 
            // m_chkLienObligatoire
            // 
            this.m_chkLienObligatoire.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_chkLienObligatoire, "");
            this.m_chkLienObligatoire.Location = new System.Drawing.Point(8, 72);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkLienObligatoire, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkLienObligatoire, "");
            this.m_chkLienObligatoire.Name = "m_chkLienObligatoire";
            this.m_chkLienObligatoire.Size = new System.Drawing.Size(137, 16);
            this.m_extStyle.SetStyleBackColor(this.m_chkLienObligatoire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkLienObligatoire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkLienObligatoire.TabIndex = 2;
            this.m_chkLienObligatoire.Text = "Link is mandatory|966";
            // 
            // m_txtLibelleLien
            // 
            this.m_txtLibelleLien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_txtLibelleLien, "");
            this.m_txtLibelleLien.Location = new System.Drawing.Point(8, 24);
            this.m_txtLibelleLien.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelleLien, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelleLien, "");
            this.m_txtLibelleLien.Name = "m_txtLibelleLien";
            this.m_txtLibelleLien.Size = new System.Drawing.Size(390, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelleLien, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelleLien, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelleLien.TabIndex = 0;
            this.m_txtLibelleLien.Text = "c2iTextBox2";
            // 
            // label3
            // 
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(8, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(320, 16);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 0;
            this.label3.Text = "Link label|958";
            // 
            // m_lnkAjoutLienElement
            // 
            this.m_lnkAjoutLienElement.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lnkAjoutLienElement, "");
            this.m_lnkAjoutLienElement.Location = new System.Drawing.Point(11, 11);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAjoutLienElement, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAjoutLienElement, "");
            this.m_lnkAjoutLienElement.Name = "m_lnkAjoutLienElement";
            this.m_lnkAjoutLienElement.Size = new System.Drawing.Size(114, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAjoutLienElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAjoutLienElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAjoutLienElement.TabIndex = 10;
            this.m_lnkAjoutLienElement.TabStop = true;
            this.m_lnkAjoutLienElement.Text = "Add element type|957";
            this.m_lnkAjoutLienElement.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkAjoutLienElement_LinkClicked);
            // 
            // m_lnkSupprimerLienElement
            // 
            this.m_extLinkField.SetLinkField(this.m_lnkSupprimerLienElement, "");
            this.m_lnkSupprimerLienElement.Location = new System.Drawing.Point(336, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkSupprimerLienElement, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkSupprimerLienElement, "");
            this.m_lnkSupprimerLienElement.Name = "m_lnkSupprimerLienElement";
            this.m_lnkSupprimerLienElement.Size = new System.Drawing.Size(56, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSupprimerLienElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSupprimerLienElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSupprimerLienElement.TabIndex = 12;
            this.m_lnkSupprimerLienElement.TabStop = true;
            this.m_lnkSupprimerLienElement.Text = "Remove|18";
            this.m_lnkSupprimerLienElement.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkSupprimerLienElement_LinkClicked);
            // 
            // m_cmbTypeElementsAAgenda
            // 
            this.m_cmbTypeElementsAAgenda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTypeElementsAAgenda.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbTypeElementsAAgenda, "");
            this.m_cmbTypeElementsAAgenda.Location = new System.Drawing.Point(140, 8);
            this.m_cmbTypeElementsAAgenda.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbTypeElementsAAgenda, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbTypeElementsAAgenda, "");
            this.m_cmbTypeElementsAAgenda.Name = "m_cmbTypeElementsAAgenda";
            this.m_cmbTypeElementsAAgenda.Size = new System.Drawing.Size(188, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbTypeElementsAAgenda, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbTypeElementsAAgenda, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbTypeElementsAAgenda.TabIndex = 11;
            // 
            // m_pageFormulairesEtChamps
            // 
            this.m_pageFormulairesEtChamps.Controls.Add(this.m_panelDefinisseurChamps);
            this.m_extLinkField.SetLinkField(this.m_pageFormulairesEtChamps, "");
            this.m_pageFormulairesEtChamps.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageFormulairesEtChamps, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageFormulairesEtChamps, "");
            this.m_pageFormulairesEtChamps.Name = "m_pageFormulairesEtChamps";
            this.m_pageFormulairesEtChamps.Selected = false;
            this.m_pageFormulairesEtChamps.Size = new System.Drawing.Size(806, 313);
            this.m_extStyle.SetStyleBackColor(this.m_pageFormulairesEtChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageFormulairesEtChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageFormulairesEtChamps.TabIndex = 1;
            this.m_pageFormulairesEtChamps.Title = "Fields and Forms|955";
            // 
            // m_gestionnaireEditionRelationLien
            // 
            this.m_gestionnaireEditionRelationLien.ListeAssociee = this.m_listViewRelationElement;
            this.m_gestionnaireEditionRelationLien.ObjetEdite = null;
            this.m_gestionnaireEditionRelationLien.InitChamp += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireEditionRelationLien_InitChamp);
            this.m_gestionnaireEditionRelationLien.MAJ_Champs += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireEditionRelationLien_MAJ_Champs);
            // 
            // checkBox1
            // 
            this.m_extLinkField.SetLinkField(this.checkBox1, "DroitsLimites");
            this.checkBox1.Location = new System.Drawing.Point(8, 52);
            this.m_gestionnaireModeEdition.SetModeEdition(this.checkBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.checkBox1, "");
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(152, 24);
            this.m_extStyle.SetStyleBackColor(this.checkBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.checkBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.checkBox1.TabIndex = 63;
            this.checkBox1.Text = "Restrict Rights|965";
            // 
            // CFormEditionTypeEntreeAgenda
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.m_tab);
            this.Controls.Add(this.c2iPanelOmbre3);
            this.Controls.Add(this.c2iPanelOmbre1);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionTypeEntreeAgenda";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Load += new System.EventHandler(this.CFormEditionTypeEntreeAgenda_Load);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre1, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre3, 0);
            this.Controls.SetChildIndex(this.m_tab, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.c2iPanelOmbre1.ResumeLayout(false);
            this.c2iPanelOmbre1.PerformLayout();
            this.c2iPanelOmbre3.ResumeLayout(false);
            this.c2iPanelOmbre3.PerformLayout();
            this.m_tab.ResumeLayout(false);
            this.m_tab.PerformLayout();
            this.m_pageEvenements.ResumeLayout(false);
            this.m_pageElementsLies.ResumeLayout(false);
            this.m_pageElementsLies.PerformLayout();
            this.m_panelLienElement.ResumeLayout(false);
            this.m_panelLienElement.PerformLayout();
            this.m_panelFiltre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_wndImageRole)).EndInit();
            this.m_pageFormulairesEtChamps.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CTypeEntreeAgenda TypeEntree
		{
			get
			{
				return (CTypeEntreeAgenda)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		private void InitPanelChampsCustom()
		{
			m_panelDefinisseurChamps.InitPanel
				(
				TypeEntree,
				typeof(CFormListeChampsCustom),
				typeof(CFormListeFormulaires) );
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
			InitComboTypesLiensPossibles(false);
            CResultAErreur result = base.MyInitChamps();

			
			
			AffecterTitre(I.T("Agenda entry type |30237") + TypeEntree.Libelle);


			m_panelDefinisseurChamps.InitPanel( TypeEntree, 
				typeof(CFormListeChampsCustom),
				typeof(CFormListeFormulaires) );

			m_panelEvenements.InitChamps ( TypeEntree );

			m_gestionnaireEditionRelationLien.ObjetEdite = TypeEntree.RelationsTypeElementsAAgenda;
			
			return result;
			
		}

	

				
		//-------------------------------------------------------------------------
		private void m_lnkNewChampCustom_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			CChampCustom champ = new CChampCustom(CSc2iWin32DataClient.ContexteCourant);
			champ.CreateNew();
			CFormEditionChampCustom frm = new CFormEditionChampCustom(champ);
			CSc2iWin32DataNavigation.Navigateur.AffichePage( frm );
		}
		
		//------------------------------------------------------------------------
		protected override CResultAErreur MAJ_Champs() 
		{
			CResultAErreur result = base.MAJ_Champs();
			if (!result)
				return result;

			m_gestionnaireEditionRelationLien.ValideModifs();
			
			result = m_panelDefinisseurChamps.MAJ_Champs();

			if ( result )
				result = m_panelEvenements.MAJ_Champs();

			return result;
		}

		private void CFormEditionTypeEntreeAgenda_Load(object sender, System.EventArgs e)
		{
			if ( m_tab.TabPages.Count > 0 && m_tab.TabPages[0] == m_tabPageToRemove )
				m_tab.TabPages.RemoveAt(0);
		}

		/// <summary>
		/// ///////////////////////////////////////////////////
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void m_gestionnaireEditionRelationLien_InitChamp(object sender, sc2i.data.CObjetDonneeResultEventArgs args)
		{
			CRelationTypeEntreeAgenda_TypeElementAAgenda relation = (CRelationTypeEntreeAgenda_TypeElementAAgenda)args.Objet;
			if ( relation == null )
			{
				m_panelLienElement.Visible = false;
				return;
			}
			m_panelLienElement.Visible = true;
			m_txtLibelleLien.Text = relation.Libelle;
			m_txtCode.Text = relation.Code;
			m_chkLienObligatoire.Checked = relation.Obligatoire;
			m_chkLienMaitre.Checked = relation.LienMaitre;
			m_chkMasquer.Checked = relation.Masquer;
			m_chkDroitModification.Checked = relation.DroitModification;
			m_chkMultiple.Checked = relation.Multiple;
			m_chkSuppressionAutomatique.Checked = relation.SuppressionAutomatique;

			CFiltreDynamique filtre = relation.FiltreDynamiqueAssocie;
			if ( filtre == null )
				filtre = new CFiltreDynamique(relation.ContexteDonnee);
			filtre.TypeElements = relation.TypeElements;
			m_panelFiltre.InitSansVariables ( filtre );

			InitComboRoles ( relation );

			

		}


		/// ///////////////////////////////////////////////////
		private void InitComboRoles ( CRelationTypeEntreeAgenda_TypeElementAAgenda relation )
		{
			if ( relation == null )
				return;
			CListeObjetsDonnees liste = new CListeObjetsDonnees(TypeEntree.ContexteDonnee, 
				typeof(CRoleSurEntreeAgenda));
			m_cmbRoles.Init ( liste, "Libelle", typeof(CFormEditionRoleSurEntreeAgenda), true);
			m_cmbRoles.ElementSelectionne = relation.Role;
			ShowImageRole();
		}

		/// ///////////////////////////////////////////////////
		private void m_gestionnaireEditionRelationLien_MAJ_Champs(object sender, sc2i.data.CObjetDonneeResultEventArgs args)
		{
			CRelationTypeEntreeAgenda_TypeElementAAgenda relation = (CRelationTypeEntreeAgenda_TypeElementAAgenda)args.Objet;
			if ( relation == null || !EtatEdition)
			{
				m_panelLienElement.Visible = false;
				return;
			}
			relation.Libelle = m_txtLibelleLien.Text;
			relation.Code = m_txtCode.Text;
			relation.Obligatoire = m_chkLienObligatoire.Checked;
			relation.LienMaitre = m_chkLienMaitre.Checked;
			relation.DroitModification = m_chkDroitModification.Checked;
			relation.Multiple = m_chkMultiple.Checked;
			relation.Masquer = m_chkMasquer.Checked;
			relation.SuppressionAutomatique = m_chkSuppressionAutomatique.Checked;
			relation.Role = (CRoleSurEntreeAgenda)m_cmbRoles.ElementSelectionne;
			
			CFiltreDynamique filtre = m_panelFiltre.FiltreDynamique;
			if ( filtre.ComposantPrincipal != null )
				relation.FiltreDynamiqueAssocie = filtre;
			else
				relation.FiltreDynamiqueAssocie = null;

			m_panelLienElement.Visible = true;
		}
		
		//-------------------------------------------------------------------------
		private void InitComboTypesLiensPossibles ( bool bForcer )
		{
			if ( m_cmbTypeElementsAAgenda.Items.Count == 0 || bForcer )
			{
				ArrayList lst = new ArrayList();
				foreach ( CInfoClasseDynamique info in DynamicClassAttribute.GetAllDynamicClass() )
					if ( typeof(CObjetDonneeAIdNumerique).IsAssignableFrom(info.Classe) )
					{
						lst.Add ( info );
					}
                lst.Insert(0, new CInfoClasseDynamique(typeof(DBNull), I.T("(None)|30291")));
                m_cmbTypeElementsAAgenda.DataSource = null;
				m_cmbTypeElementsAAgenda.DataSource = lst;
				m_cmbTypeElementsAAgenda.ValueMember = "Classe";
				m_cmbTypeElementsAAgenda.DisplayMember = "Nom";
			}
		}

		//-------------------------------------------------------------------------
		private void m_lnkAjoutLienElement_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			CRelationTypeEntreeAgenda_TypeElementAAgenda relation = new CRelationTypeEntreeAgenda_TypeElementAAgenda ( TypeEntree.ContexteDonnee );
			relation.CreateNewInCurrentContexte();
			relation.TypeEntree = TypeEntree;
			relation.TypeElements = (Type)m_cmbTypeElementsAAgenda.SelectedValue;
			if (relation.TypeElements == typeof(DBNull))
				relation.TypeElements = null;
			ListViewItem item = new ListViewItem();
			m_listViewRelationElement.Items.Add ( item );
			m_listViewRelationElement.UpdateItemWithObject(item, relation);
			foreach ( ListViewItem itemSel in m_listViewRelationElement.SelectedItems )
				itemSel.Selected = false;
			item.Selected = true;
		}

		//-------------------------------------------------------------------------
		private void m_lnkSupprimerLienElement_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			if (m_listViewRelationElement.SelectedItems.Count != 1)
				return;

			CRelationTypeEntreeAgenda_TypeElementAAgenda relation = (CRelationTypeEntreeAgenda_TypeElementAAgenda)m_listViewRelationElement.SelectedItems[0].Tag;
			
			m_gestionnaireEditionRelationLien.SetObjetEnCoursToNull();
			CResultAErreur result = relation.Delete();
			if(!result)
			{
				CFormAlerte.Afficher(result.Erreur);
				return;
			}

			if (m_listViewRelationElement.SelectedItems[0]!=null)
				m_listViewRelationElement.SelectedItems[0].Remove();
		}



		private void m_lnkRoles_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			CFormNavigateurPopup.Show ( new CFormListeFiltresDynamiques() );
			InitComboRoles ( (CRelationTypeEntreeAgenda_TypeElementAAgenda)m_gestionnaireEditionRelationLien.ObjetEnCours);
		}

		/// ///////////////////////////////////////
		private void m_cmbRoles_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ShowImageRole();
		}

		/// ///////////////////////////////////////
		private void ShowImageRole()
		{
			if ( m_cmbRoles.SelectedValue is CRoleSurEntreeAgenda )
			{
				try
				{
					m_wndImageRole.Image = ((CRoleSurEntreeAgenda)m_cmbRoles.SelectedValue).Image;
				}
				catch{}
			}
			else
				m_wndImageRole.Image = null;
		}

		private void checkBox3_CheckedChanged(object sender, System.EventArgs e)
		{

        }

	}
}

