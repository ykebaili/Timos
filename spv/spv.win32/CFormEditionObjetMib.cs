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
using spv.data;
using System.Collections.Generic;
using timos.data;


namespace spv.win32
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CSpvMibmodule))]
	public class CFormEditionObjetMib: CFormEditionStandard, IFormNavigable
	{
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtNomUtilisateur;
        private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
        private Label label9;
        private System.ComponentModel.IContainer components = null;
        private Label label3;
        private C2iTextBox m_txtNomOfficiel;
        private Label label4;
        private C2iTextBox m_txtOID;
        private Label label5;
        private C2iTextBox m_txtNumeroEntreprise;
        private Label label6;
        private C2iTextBox m_txtDateCompilation;
        private Label label7;
        private C2iTextBox m_txtCommentaire;
        private CheckBox m_chkVisibleOnEquipment;
        private Label label2;
        private C2iTextBox m_txtNumeroTrap;
        private Label label8;
        private C2iTextBox m_txtNumeroLigneEnFichier;
        private Label label10;
        private C2iTextBox m_txtUnites;
        private Label label11;
        private C2iTextBox m_txtContraintes;
        private Label label12;
        private C2iTextBox m_txtDroitsAcces;
        private Label label13;
        private C2iTextBox m_txtValeurParDefaut;
        private Label label14;
        private C2iTextBox m_txtEtat;
        private Label label15;
        private C2iTextBox m_txtCompositionIndex;
        private Label label16;
        private Label label17;
        private C2iTextBox m_txtInformation;
        private Label label18;
        private Label label19;
        private C2iTextBox m_txtMibsImportees;
        private C2iTextBox m_txtInformationsAffichage;
        private Label label20;
        private ListViewAutoFilledColumn Code;
        private ColumnHeader Libelle;
        private ListViewAutoFilled m_listeCodes;
        private ListViewAutoFilledColumn listViewAutoFilledColumn2;
        private ListViewAutoFilledColumn listViewAutoFilledColumn3;
        private C2iTextBox m_txtColonnesAjoutees;
        private ListViewAutoFilledColumn listViewAutoFilledColumn1;

        public CFormEditionObjetMib()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionObjetMib(CSpvMibobj mibobj)
            : base(mibobj)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
        public CFormEditionObjetMib(CSpvMibobj mibobj, CListeObjetsDonnees liste)
            : base(mibobj, liste)
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
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtNomUtilisateur = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_txtColonnesAjoutees = new sc2i.win32.common.C2iTextBox();
            this.m_txtInformationsAffichage = new sc2i.win32.common.C2iTextBox();
            this.m_txtMibsImportees = new sc2i.win32.common.C2iTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.m_listeCodes = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn2 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn3 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_txtInformation = new sc2i.win32.common.C2iTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.m_txtCompositionIndex = new sc2i.win32.common.C2iTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.m_txtEtat = new sc2i.win32.common.C2iTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.m_txtValeurParDefaut = new sc2i.win32.common.C2iTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.m_txtDroitsAcces = new sc2i.win32.common.C2iTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.m_txtContraintes = new sc2i.win32.common.C2iTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.m_txtUnites = new sc2i.win32.common.C2iTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.m_txtNumeroLigneEnFichier = new sc2i.win32.common.C2iTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.m_txtNumeroTrap = new sc2i.win32.common.C2iTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.m_chkVisibleOnEquipment = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.m_txtCommentaire = new sc2i.win32.common.C2iTextBox();
            this.m_txtNomOfficiel = new sc2i.win32.common.C2iTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txtOID = new sc2i.win32.common.C2iTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtDateCompilation = new sc2i.win32.common.C2iTextBox();
            this.m_txtNumeroEntreprise = new sc2i.win32.common.C2iTextBox();
            this.Code = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.Libelle = new System.Windows.Forms.ColumnHeader();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
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
            this.m_btnSupprimerObjet.Visible = false;
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
            this.m_panelNavigation.Location = new System.Drawing.Point(758, 0);
            this.m_panelNavigation.Size = new System.Drawing.Size(153, 34);
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
            this.m_btnAjout.Visible = false;
            // 
            // m_lblId
            // 
            this.m_extStyle.SetStyleBackColor(this.m_lblId, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblId, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelCle
            // 
            this.m_panelCle.Location = new System.Drawing.Point(671, 0);
            this.m_panelCle.Size = new System.Drawing.Size(87, 34);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.m_panelMenu.Size = new System.Drawing.Size(911, 34);
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
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4002;
            this.label1.Text = "Label|3";
            // 
            // m_txtNomUtilisateur
            // 
            this.m_extLinkField.SetLinkField(this.m_txtNomUtilisateur, "NomObjetUtilisateur");
            this.m_txtNomUtilisateur.Location = new System.Drawing.Point(179, 11);
            this.m_txtNomUtilisateur.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtNomUtilisateur, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtNomUtilisateur.Name = "m_txtNomUtilisateur";
            this.m_txtNomUtilisateur.Size = new System.Drawing.Size(324, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtNomUtilisateur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtNomUtilisateur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtNomUtilisateur.TabIndex = 0;
            this.m_txtNomUtilisateur.Text = "[NomObjetUtilisateur]";
            // 
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.m_txtColonnesAjoutees);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtInformationsAffichage);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtMibsImportees);
            this.c2iPanelOmbre4.Controls.Add(this.label19);
            this.c2iPanelOmbre4.Controls.Add(this.label20);
            this.c2iPanelOmbre4.Controls.Add(this.label18);
            this.c2iPanelOmbre4.Controls.Add(this.label17);
            this.c2iPanelOmbre4.Controls.Add(this.m_listeCodes);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtInformation);
            this.c2iPanelOmbre4.Controls.Add(this.label16);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtCompositionIndex);
            this.c2iPanelOmbre4.Controls.Add(this.label15);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtEtat);
            this.c2iPanelOmbre4.Controls.Add(this.label14);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtValeurParDefaut);
            this.c2iPanelOmbre4.Controls.Add(this.label13);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtDroitsAcces);
            this.c2iPanelOmbre4.Controls.Add(this.label12);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtContraintes);
            this.c2iPanelOmbre4.Controls.Add(this.label11);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtUnites);
            this.c2iPanelOmbre4.Controls.Add(this.label10);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtNumeroLigneEnFichier);
            this.c2iPanelOmbre4.Controls.Add(this.label8);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtNumeroTrap);
            this.c2iPanelOmbre4.Controls.Add(this.label2);
            this.c2iPanelOmbre4.Controls.Add(this.label9);
            this.c2iPanelOmbre4.Controls.Add(this.m_chkVisibleOnEquipment);
            this.c2iPanelOmbre4.Controls.Add(this.label7);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtNomUtilisateur);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtCommentaire);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtNomOfficiel);
            this.c2iPanelOmbre4.Controls.Add(this.label3);
            this.c2iPanelOmbre4.Controls.Add(this.label4);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtOID);
            this.c2iPanelOmbre4.Controls.Add(this.label6);
            this.c2iPanelOmbre4.Controls.Add(this.label5);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtDateCompilation);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtNumeroEntreprise);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(12, 40);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(746, 656);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // m_txtColonnesAjoutees
            // 
            this.m_extLinkField.SetLinkField(this.m_txtColonnesAjoutees, "ColonnesAjoutees");
            this.m_txtColonnesAjoutees.Location = new System.Drawing.Point(509, 330);
            this.m_txtColonnesAjoutees.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtColonnesAjoutees, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtColonnesAjoutees.Name = "m_txtColonnesAjoutees";
            this.m_txtColonnesAjoutees.Size = new System.Drawing.Size(186, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtColonnesAjoutees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtColonnesAjoutees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtColonnesAjoutees.TabIndex = 4045;
            this.m_txtColonnesAjoutees.Text = "[ColonnesAjoutees]";
            // 
            // m_txtInformationsAffichage
            // 
            this.m_extLinkField.SetLinkField(this.m_txtInformationsAffichage, "InformationsAffichage");
            this.m_txtInformationsAffichage.Location = new System.Drawing.Point(368, 479);
            this.m_txtInformationsAffichage.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtInformationsAffichage, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtInformationsAffichage.Name = "m_txtInformationsAffichage";
            this.m_txtInformationsAffichage.Size = new System.Drawing.Size(327, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtInformationsAffichage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtInformationsAffichage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtInformationsAffichage.TabIndex = 4042;
            this.m_txtInformationsAffichage.Text = "[InformationsAffichage]";
            // 
            // m_txtMibsImportees
            // 
            this.m_extLinkField.SetLinkField(this.m_txtMibsImportees, "MibsImportees");
            this.m_txtMibsImportees.Location = new System.Drawing.Point(13, 479);
            this.m_txtMibsImportees.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtMibsImportees, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtMibsImportees.Name = "m_txtMibsImportees";
            this.m_txtMibsImportees.Size = new System.Drawing.Size(321, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtMibsImportees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtMibsImportees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtMibsImportees.TabIndex = 4041;
            this.m_txtMibsImportees.Text = "[MibsImportees]";
            // 
            // label19
            // 
            this.m_extLinkField.SetLinkField(this.label19, "");
            this.label19.Location = new System.Drawing.Point(365, 463);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label19, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(211, 23);
            this.m_extStyle.SetStyleBackColor(this.label19, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label19, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label19.TabIndex = 4040;
            this.label19.Text = "Display informations|50045";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label20, "");
            this.label20.Location = new System.Drawing.Point(12, 513);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label20, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(69, 13);
            this.m_extStyle.SetStyleBackColor(this.label20, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label20, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label20.TabIndex = 4043;
            this.label20.Text = "Codes|50050";
            // 
            // label18
            // 
            this.m_extLinkField.SetLinkField(this.label18, "");
            this.label18.Location = new System.Drawing.Point(10, 463);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label18, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(211, 23);
            this.m_extStyle.SetStyleBackColor(this.label18, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label18, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label18.TabIndex = 4039;
            this.label18.Text = "Related informations|50044";
            // 
            // label17
            // 
            this.m_extLinkField.SetLinkField(this.label17, "");
            this.label17.Location = new System.Drawing.Point(10, 367);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label17, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(211, 23);
            this.m_extStyle.SetStyleBackColor(this.label17, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label17, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label17.TabIndex = 4037;
            this.label17.Text = "Description|50049";
            // 
            // m_listeCodes
            // 
            this.m_listeCodes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn2,
            this.listViewAutoFilledColumn3});
            this.m_listeCodes.EnableCustomisation = true;
            this.m_listeCodes.FullRowSelect = true;
            this.m_extLinkField.SetLinkField(this.m_listeCodes, "");
            this.m_listeCodes.Location = new System.Drawing.Point(13, 529);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_listeCodes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_listeCodes.MultiSelect = false;
            this.m_listeCodes.Name = "m_listeCodes";
            this.m_listeCodes.Size = new System.Drawing.Size(321, 97);
            this.m_extStyle.SetStyleBackColor(this.m_listeCodes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_listeCodes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_listeCodes.TabIndex = 4044;
            this.m_listeCodes.UseCompatibleStateImageBehavior = false;
            this.m_listeCodes.View = System.Windows.Forms.View.Details;
            // 
            // listViewAutoFilledColumn2
            // 
            this.listViewAutoFilledColumn2.Field = "Code";
            this.listViewAutoFilledColumn2.PrecisionWidth = 0;
            this.listViewAutoFilledColumn2.ProportionnalSize = false;
            this.listViewAutoFilledColumn2.Text = "Code|50051";
            this.listViewAutoFilledColumn2.Visible = true;
            this.listViewAutoFilledColumn2.Width = 61;
            // 
            // listViewAutoFilledColumn3
            // 
            this.listViewAutoFilledColumn3.Field = "NomOfficiel";
            this.listViewAutoFilledColumn3.PrecisionWidth = 0;
            this.listViewAutoFilledColumn3.ProportionnalSize = false;
            this.listViewAutoFilledColumn3.Text = "Label|3";
            this.listViewAutoFilledColumn3.Visible = true;
            this.listViewAutoFilledColumn3.Width = 235;
            // 
            // m_txtInformation
            // 
            this.m_txtInformation.AcceptsReturn = true;
            this.m_extLinkField.SetLinkField(this.m_txtInformation, "Information");
            this.m_txtInformation.Location = new System.Drawing.Point(13, 392);
            this.m_txtInformation.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtInformation, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtInformation.Multiline = true;
            this.m_txtInformation.Name = "m_txtInformation";
            this.m_txtInformation.Size = new System.Drawing.Size(682, 62);
            this.m_extStyle.SetStyleBackColor(this.m_txtInformation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtInformation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtInformation.TabIndex = 4038;
            this.m_txtInformation.Text = "[Information]";
            // 
            // label16
            // 
            this.m_extLinkField.SetLinkField(this.label16, "");
            this.label16.Location = new System.Drawing.Point(365, 333);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label16, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(114, 23);
            this.m_extStyle.SetStyleBackColor(this.label16, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label16, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label16.TabIndex = 4035;
            this.label16.Text = "Added columns|50042";
            // 
            // m_txtCompositionIndex
            // 
            this.m_extLinkField.SetLinkField(this.m_txtCompositionIndex, "CompositionIndex");
            this.m_txtCompositionIndex.Location = new System.Drawing.Point(148, 330);
            this.m_txtCompositionIndex.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtCompositionIndex, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtCompositionIndex.Name = "m_txtCompositionIndex";
            this.m_txtCompositionIndex.Size = new System.Drawing.Size(186, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtCompositionIndex, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtCompositionIndex, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtCompositionIndex.TabIndex = 4034;
            this.m_txtCompositionIndex.Text = "[CompositionIndex]";
            // 
            // label15
            // 
            this.m_extLinkField.SetLinkField(this.label15, "");
            this.label15.Location = new System.Drawing.Point(10, 333);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label15, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(130, 23);
            this.m_extStyle.SetStyleBackColor(this.label15, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label15, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label15.TabIndex = 4033;
            this.label15.Text = "Index (if table)|50041";
            // 
            // m_txtEtat
            // 
            this.m_extLinkField.SetLinkField(this.m_txtEtat, "Etat");
            this.m_txtEtat.Location = new System.Drawing.Point(509, 298);
            this.m_txtEtat.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtEtat, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtEtat.Name = "m_txtEtat";
            this.m_txtEtat.Size = new System.Drawing.Size(186, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtEtat, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtEtat, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtEtat.TabIndex = 4032;
            this.m_txtEtat.Text = "[Etat]";
            // 
            // label14
            // 
            this.m_extLinkField.SetLinkField(this.label14, "");
            this.label14.Location = new System.Drawing.Point(365, 301);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label14, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(114, 23);
            this.m_extStyle.SetStyleBackColor(this.label14, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label14, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label14.TabIndex = 4031;
            this.label14.Text = "Status|50040";
            // 
            // m_txtValeurParDefaut
            // 
            this.m_extLinkField.SetLinkField(this.m_txtValeurParDefaut, "ValeurParDefaut");
            this.m_txtValeurParDefaut.Location = new System.Drawing.Point(148, 298);
            this.m_txtValeurParDefaut.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtValeurParDefaut, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtValeurParDefaut.Name = "m_txtValeurParDefaut";
            this.m_txtValeurParDefaut.Size = new System.Drawing.Size(186, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtValeurParDefaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtValeurParDefaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtValeurParDefaut.TabIndex = 4030;
            this.m_txtValeurParDefaut.Text = "[ValeurParDefaut]";
            // 
            // label13
            // 
            this.m_extLinkField.SetLinkField(this.label13, "");
            this.label13.Location = new System.Drawing.Point(10, 301);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label13, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(130, 23);
            this.m_extStyle.SetStyleBackColor(this.label13, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label13, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label13.TabIndex = 4029;
            this.label13.Text = "Default value|50039";
            // 
            // m_txtDroitsAcces
            // 
            this.m_extLinkField.SetLinkField(this.m_txtDroitsAcces, "DroitsAcces");
            this.m_txtDroitsAcces.Location = new System.Drawing.Point(509, 266);
            this.m_txtDroitsAcces.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtDroitsAcces, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtDroitsAcces.Name = "m_txtDroitsAcces";
            this.m_txtDroitsAcces.Size = new System.Drawing.Size(186, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtDroitsAcces, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtDroitsAcces, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtDroitsAcces.TabIndex = 4028;
            this.m_txtDroitsAcces.Text = "[DroitsAcces]";
            // 
            // label12
            // 
            this.m_extLinkField.SetLinkField(this.label12, "");
            this.label12.Location = new System.Drawing.Point(365, 269);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label12, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(114, 23);
            this.m_extStyle.SetStyleBackColor(this.label12, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label12, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label12.TabIndex = 4027;
            this.label12.Text = "Access rights|50038";
            // 
            // m_txtContraintes
            // 
            this.m_extLinkField.SetLinkField(this.m_txtContraintes, "Contraintes");
            this.m_txtContraintes.Location = new System.Drawing.Point(148, 266);
            this.m_txtContraintes.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtContraintes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtContraintes.Name = "m_txtContraintes";
            this.m_txtContraintes.Size = new System.Drawing.Size(186, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtContraintes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtContraintes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtContraintes.TabIndex = 4026;
            this.m_txtContraintes.Text = "[Contraintes]";
            // 
            // label11
            // 
            this.m_extLinkField.SetLinkField(this.label11, "");
            this.label11.Location = new System.Drawing.Point(10, 269);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label11, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(149, 23);
            this.m_extStyle.SetStyleBackColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label11.TabIndex = 4025;
            this.label11.Text = "Constraints|50037";
            // 
            // m_txtUnites
            // 
            this.m_extLinkField.SetLinkField(this.m_txtUnites, "Unites");
            this.m_txtUnites.Location = new System.Drawing.Point(540, 234);
            this.m_txtUnites.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtUnites, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtUnites.Name = "m_txtUnites";
            this.m_txtUnites.Size = new System.Drawing.Size(155, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtUnites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtUnites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtUnites.TabIndex = 4024;
            this.m_txtUnites.Text = "[Unites]";
            // 
            // label10
            // 
            this.m_extLinkField.SetLinkField(this.label10, "");
            this.label10.Location = new System.Drawing.Point(365, 237);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label10, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 23);
            this.m_extStyle.SetStyleBackColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label10.TabIndex = 4023;
            this.label10.Text = "Units|50036";
            // 
            // m_txtNumeroLigneEnFichier
            // 
            this.m_extLinkField.SetLinkField(this.m_txtNumeroLigneEnFichier, "");
            this.m_txtNumeroLigneEnFichier.Location = new System.Drawing.Point(179, 172);
            this.m_txtNumeroLigneEnFichier.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtNumeroLigneEnFichier, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtNumeroLigneEnFichier.Name = "m_txtNumeroLigneEnFichier";
            this.m_txtNumeroLigneEnFichier.Size = new System.Drawing.Size(155, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtNumeroLigneEnFichier, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtNumeroLigneEnFichier, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtNumeroLigneEnFichier.TabIndex = 4022;
            // 
            // label8
            // 
            this.m_extLinkField.SetLinkField(this.label8, "");
            this.label8.Location = new System.Drawing.Point(10, 175);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label8, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 17);
            this.m_extStyle.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 4021;
            this.label8.Text = "Defined in file line|50035";
            // 
            // m_txtNumeroTrap
            // 
            this.m_extLinkField.SetLinkField(this.m_txtNumeroTrap, "");
            this.m_txtNumeroTrap.Location = new System.Drawing.Point(540, 205);
            this.m_txtNumeroTrap.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtNumeroTrap, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtNumeroTrap.Name = "m_txtNumeroTrap";
            this.m_txtNumeroTrap.Size = new System.Drawing.Size(155, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtNumeroTrap, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtNumeroTrap, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtNumeroTrap.TabIndex = 4020;
            // 
            // label2
            // 
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(365, 208);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 17);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4019;
            this.label2.Text = "Trap number (if trap)|50034";
            // 
            // label9
            // 
            this.m_extLinkField.SetLinkField(this.label9, "");
            this.label9.Location = new System.Drawing.Point(10, 13);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label9, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 23);
            this.m_extStyle.SetStyleBackColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label9.TabIndex = 4006;
            this.label9.Text = "Label|3";
            // 
            // m_chkVisibleOnEquipment
            // 
            this.m_chkVisibleOnEquipment.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkVisibleOnEquipment, "");
            this.m_chkVisibleOnEquipment.Location = new System.Drawing.Point(530, 13);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkVisibleOnEquipment, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkVisibleOnEquipment.Name = "m_chkVisibleOnEquipment";
            this.m_chkVisibleOnEquipment.Size = new System.Drawing.Size(160, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkVisibleOnEquipment, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkVisibleOnEquipment, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkVisibleOnEquipment.TabIndex = 4018;
            this.m_chkVisibleOnEquipment.Text = "Visible on equipments|50030";
            this.m_chkVisibleOnEquipment.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.m_extLinkField.SetLinkField(this.label7, "");
            this.label7.Location = new System.Drawing.Point(10, 40);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(211, 23);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 4016;
            this.label7.Text = "Comment|132";
            // 
            // m_txtCommentaire
            // 
            this.m_txtCommentaire.AcceptsReturn = true;
            this.m_extLinkField.SetLinkField(this.m_txtCommentaire, "Commentaire");
            this.m_txtCommentaire.Location = new System.Drawing.Point(13, 66);
            this.m_txtCommentaire.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtCommentaire, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtCommentaire.Multiline = true;
            this.m_txtCommentaire.Name = "m_txtCommentaire";
            this.m_txtCommentaire.Size = new System.Drawing.Size(682, 30);
            this.m_extStyle.SetStyleBackColor(this.m_txtCommentaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtCommentaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtCommentaire.TabIndex = 4017;
            this.m_txtCommentaire.Text = "[Commentaire]";
            // 
            // m_txtNomOfficiel
            // 
            this.m_extLinkField.SetLinkField(this.m_txtNomOfficiel, "NomObjetOfficiel");
            this.m_txtNomOfficiel.Location = new System.Drawing.Point(179, 110);
            this.m_txtNomOfficiel.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtNomOfficiel, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtNomOfficiel.Name = "m_txtNomOfficiel";
            this.m_txtNomOfficiel.Size = new System.Drawing.Size(435, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtNomOfficiel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtNomOfficiel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtNomOfficiel.TabIndex = 4009;
            this.m_txtNomOfficiel.Text = "[NomObjetOfficiel]";
            // 
            // label3
            // 
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(10, 113);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 23);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4008;
            this.label3.Text = "SNMP  name|50031";
            // 
            // label4
            // 
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.label4.Location = new System.Drawing.Point(10, 142);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 17);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 4010;
            this.label4.Text = "OID|137";
            // 
            // m_txtOID
            // 
            this.m_extLinkField.SetLinkField(this.m_txtOID, "OidObjet");
            this.m_txtOID.Location = new System.Drawing.Point(179, 139);
            this.m_txtOID.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtOID, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtOID.Name = "m_txtOID";
            this.m_txtOID.Size = new System.Drawing.Size(435, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtOID, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtOID, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtOID.TabIndex = 4011;
            this.m_txtOID.Text = "[OidObjet]";
            // 
            // label6
            // 
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.label6.Location = new System.Drawing.Point(10, 237);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 23);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 4014;
            this.label6.Text = "SNMP type|50033";
            // 
            // label5
            // 
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.label5.Location = new System.Drawing.Point(10, 208);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 23);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 4012;
            this.label5.Text = "Enterprise number|50032";
            // 
            // m_txtDateCompilation
            // 
            this.m_extLinkField.SetLinkField(this.m_txtDateCompilation, "TypeSnmp");
            this.m_txtDateCompilation.Location = new System.Drawing.Point(179, 234);
            this.m_txtDateCompilation.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtDateCompilation, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtDateCompilation.Name = "m_txtDateCompilation";
            this.m_txtDateCompilation.Size = new System.Drawing.Size(155, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtDateCompilation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtDateCompilation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtDateCompilation.TabIndex = 4015;
            this.m_txtDateCompilation.Text = "[TypeSnmp]";
            // 
            // m_txtNumeroEntreprise
            // 
            this.m_extLinkField.SetLinkField(this.m_txtNumeroEntreprise, "NumeroEntreprise");
            this.m_txtNumeroEntreprise.Location = new System.Drawing.Point(179, 205);
            this.m_txtNumeroEntreprise.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtNumeroEntreprise, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtNumeroEntreprise.Name = "m_txtNumeroEntreprise";
            this.m_txtNumeroEntreprise.Size = new System.Drawing.Size(155, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtNumeroEntreprise, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtNumeroEntreprise, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtNumeroEntreprise.TabIndex = 4013;
            this.m_txtNumeroEntreprise.Text = "[NumeroEntreprise]";
            // 
            // Code
            // 
            this.Code.Field = "";
            this.Code.PrecisionWidth = 0;
            this.Code.ProportionnalSize = false;
            this.Code.Text = "Code|50051";
            this.Code.Visible = true;
            this.Code.Width = 75;
            // 
            // Libelle
            // 
            this.Libelle.Text = "Label|3";
            this.Libelle.Width = 163;
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "AlarmCause";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Alarme cause(s)|135";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 250;
            // 
            // CFormEditionObjetMib
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.BoutonAjouterVisible = false;
            this.BoutonSupprimerVisible = false;
            this.ClientSize = new System.Drawing.Size(913, 743);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CFormEditionObjetMib";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
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
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
        protected CSpvMibobj ObjetMib
		{
			get
			{
				return (CSpvMibobj)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
        protected override CResultAErreur InitChamps()
		{
			CResultAErreur result = base.InitChamps();
			if (!result)
				return result;

            AffecterTitre(I.T("MIB object|10011"));

            m_txtNumeroLigneEnFichier.Text = ObjetMib.NumeroLigneEnFichier.ToString();
            m_txtNumeroTrap.Text = ObjetMib.NumeroTrap.ToString();
            m_chkVisibleOnEquipment.Checked = (ObjetMib.Visibilite > 0) ? true : false;
            InitListeCodes();
            
			return result;
		}


		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();
			if (!result)
				return result;

            ObjetMib.NumeroLigneEnFichier = Convert.ToInt32(m_txtNumeroLigneEnFichier.Text);
            ObjetMib.NumeroTrap = Convert.ToInt32(m_txtNumeroTrap.Text);
            ObjetMib.Visibilite = m_chkVisibleOnEquipment.Checked ? 1 : 0;

           	return result;
        }


        private void InitListeCodes()
        {
            m_listeCodes.Items.Clear();

            foreach (CSpvMibenum mibEnum in ObjetMib.SpvMibenums)
            {
                ListViewItem item = new ListViewItem();
                m_listeCodes.Items.Add(item);
                m_listeCodes.UpdateItemWithObject(item, mibEnum);
            }
        }
	}
}

