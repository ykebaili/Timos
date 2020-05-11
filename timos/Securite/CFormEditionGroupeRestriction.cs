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
using sc2i.multitiers.client;

using timos.securite;
using timos.acteurs;
using sc2i.workflow;
using sc2i.expression;
using System.Collections.Generic;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CGroupeRestrictionSurType))]
    public class CFormEditionGroupeRestriction : CFormEditionStdTimos, IFormNavigable
	{
		CRestrictionUtilisateurSurType m_restrictionAffichee = null;
		ArrayList m_listeRestrictions = new ArrayList();
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
		private System.Windows.Forms.Label label2;
		private sc2i.win32.common.C2iTextBox c2iTextBox1;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre1;
        private System.Windows.Forms.ColumnHeader m_colType;
		private sc2i.win32.common.C2iPanel m_panelDetailRestriction;
		private System.Windows.Forms.ListView m_wndListeChamps;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ImageList m_imagesDroits;
		private System.Windows.Forms.Panel m_panelLegende;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.ListView m_wndListeRestrictions;
		private System.Windows.Forms.Label m_lblType;
		private System.Windows.Forms.PictureBox m_imageRestrictionGlobale;
		private System.Windows.Forms.Label m_lblRestrictionGlobale;
		private System.Windows.Forms.PictureBox m_imageNoAdd;
		private System.Windows.Forms.PictureBox m_imageNoDelete;
		private System.Windows.Forms.CheckBox m_chkSurcharge;
		private System.Windows.Forms.Label label6;
		private sc2i.win32.common.C2iNumericUpDown m_nPriorite;
		private CheckBox m_chkAnnulerInfs;
        private C2iTextBoxNumerique m_txtSeuilAnnulation;
        private DataGrid m_gridExceptions;
        private LinkLabel m_lnkClearAll;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionGroupeRestriction()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionGroupeRestriction(CGroupeRestrictionSurType groupeRestriction)
			:base(groupeRestriction)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionGroupeRestriction(CGroupeRestrictionSurType groupeRestriction, CListeObjetsDonnees liste)
			:base(groupeRestriction, liste)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionGroupeRestriction));
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.c2iTextBox1 = new sc2i.win32.common.C2iTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_chkAnnulerInfs = new System.Windows.Forms.CheckBox();
            this.m_txtSeuilAnnulation = new sc2i.win32.common.C2iTextBoxNumerique();
            this.c2iPanelOmbre1 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_lnkClearAll = new System.Windows.Forms.LinkLabel();
            this.m_panelDetailRestriction = new sc2i.win32.common.C2iPanel(this.components);
            this.m_gridExceptions = new System.Windows.Forms.DataGrid();
            this.m_nPriorite = new sc2i.win32.common.C2iNumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.m_imageNoDelete = new System.Windows.Forms.PictureBox();
            this.m_imageNoAdd = new System.Windows.Forms.PictureBox();
            this.m_lblRestrictionGlobale = new System.Windows.Forms.Label();
            this.m_imageRestrictionGlobale = new System.Windows.Forms.PictureBox();
            this.m_lblType = new System.Windows.Forms.Label();
            this.m_wndListeChamps = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.m_imagesDroits = new System.Windows.Forms.ImageList(this.components);
            this.m_panelLegende = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_chkSurcharge = new System.Windows.Forms.CheckBox();
            this.m_wndListeRestrictions = new System.Windows.Forms.ListView();
            this.m_colType = new System.Windows.Forms.ColumnHeader();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.c2iPanelOmbre1.SuspendLayout();
            this.m_panelDetailRestriction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_gridExceptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nPriorite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageNoDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageNoAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageRestrictionGlobale)).BeginInit();
            this.m_panelLegende.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.m_panelCle.Location = new System.Drawing.Point(568, 0);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label1, false);
            this.label1.Location = new System.Drawing.Point(7, 12);
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
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtLibelle, true);
            this.m_txtLibelle.Location = new System.Drawing.Point(89, 8);
            this.m_txtLibelle.LockEdition = false;
            this.m_txtLibelle.MaxLength = 255;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(336, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Libelle]";
            // 
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.c2iTextBox1);
            this.c2iPanelOmbre4.Controls.Add(this.label2);
            this.c2iPanelOmbre4.Controls.Add(this.m_chkAnnulerInfs);
            this.c2iPanelOmbre4.Controls.Add(this.label1);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtSeuilAnnulation);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iPanelOmbre4, false);
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(8, 52);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(603, 124);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // c2iTextBox1
            // 
            this.c2iTextBox1.AcceptsReturn = true;
            this.m_extLinkField.SetLinkField(this.c2iTextBox1, "Descriptif");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iTextBox1, true);
            this.c2iTextBox1.Location = new System.Drawing.Point(89, 40);
            this.c2iTextBox1.LockEdition = false;
            this.c2iTextBox1.MaxLength = 1024;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBox1, "");
            this.c2iTextBox1.Multiline = true;
            this.c2iTextBox1.Name = "c2iTextBox1";
            this.c2iTextBox1.Size = new System.Drawing.Size(336, 38);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox1.TabIndex = 4004;
            this.c2iTextBox1.Text = "[Descriptif]";
            // 
            // label2
            // 
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label2, false);
            this.label2.Location = new System.Drawing.Point(7, 40);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 24);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4003;
            this.label2.Text = "Description|655";
            // 
            // m_chkAnnulerInfs
            // 
            this.m_chkAnnulerInfs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_extLinkField.SetLinkField(this.m_chkAnnulerInfs, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_chkAnnulerInfs, false);
            this.m_chkAnnulerInfs.Location = new System.Drawing.Point(89, 84);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkAnnulerInfs, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkAnnulerInfs, "");
            this.m_chkAnnulerInfs.Name = "m_chkAnnulerInfs";
            this.m_chkAnnulerInfs.Size = new System.Drawing.Size(208, 19);
            this.m_extStyle.SetStyleBackColor(this.m_chkAnnulerInfs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkAnnulerInfs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkAnnulerInfs.TabIndex = 4005;
            this.m_chkAnnulerInfs.Text = "Cancel restriction lower than|1084";
            this.m_chkAnnulerInfs.UseVisualStyleBackColor = true;
            // 
            // m_txtSeuilAnnulation
            // 
            this.m_txtSeuilAnnulation.Arrondi = 0;
            this.m_txtSeuilAnnulation.DecimalAutorise = false;
            this.m_txtSeuilAnnulation.IntValue = 0;
            this.m_extLinkField.SetLinkField(this.m_txtSeuilAnnulation, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtSeuilAnnulation, false);
            this.m_txtSeuilAnnulation.Location = new System.Drawing.Point(331, 83);
            this.m_txtSeuilAnnulation.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSeuilAnnulation, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtSeuilAnnulation, "");
            this.m_txtSeuilAnnulation.Name = "m_txtSeuilAnnulation";
            this.m_txtSeuilAnnulation.NullAutorise = false;
            this.m_txtSeuilAnnulation.SelectAllOnEnter = true;
            this.m_txtSeuilAnnulation.SeparateurMilliers = "";
            this.m_txtSeuilAnnulation.Size = new System.Drawing.Size(48, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtSeuilAnnulation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSeuilAnnulation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSeuilAnnulation.TabIndex = 4006;
            this.m_txtSeuilAnnulation.Text = "0";
            this.m_txtSeuilAnnulation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // c2iPanelOmbre1
            // 
            this.c2iPanelOmbre1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iPanelOmbre1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre1.Controls.Add(this.m_lnkClearAll);
            this.c2iPanelOmbre1.Controls.Add(this.m_panelDetailRestriction);
            this.c2iPanelOmbre1.Controls.Add(this.m_wndListeRestrictions);
            this.c2iPanelOmbre1.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iPanelOmbre1, false);
            this.c2iPanelOmbre1.Location = new System.Drawing.Point(8, 176);
            this.c2iPanelOmbre1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre1, "");
            this.c2iPanelOmbre1.Name = "c2iPanelOmbre1";
            this.c2iPanelOmbre1.Size = new System.Drawing.Size(814, 358);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre1.TabIndex = 4004;
            // 
            // m_lnkClearAll
            // 
            this.m_lnkClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkClearAll.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lnkClearAll, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkClearAll, false);
            this.m_lnkClearAll.Location = new System.Drawing.Point(7, 318);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkClearAll, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkClearAll, "");
            this.m_lnkClearAll.Name = "m_lnkClearAll";
            this.m_lnkClearAll.Size = new System.Drawing.Size(76, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkClearAll, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkClearAll, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkClearAll.TabIndex = 4014;
            this.m_lnkClearAll.TabStop = true;
            this.m_lnkClearAll.Text = "Clear all|20545";
            this.m_lnkClearAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkClearAll_LinkClicked);
            // 
            // m_panelDetailRestriction
            // 
            this.m_panelDetailRestriction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelDetailRestriction.Controls.Add(this.m_gridExceptions);
            this.m_panelDetailRestriction.Controls.Add(this.m_nPriorite);
            this.m_panelDetailRestriction.Controls.Add(this.label6);
            this.m_panelDetailRestriction.Controls.Add(this.m_imageNoDelete);
            this.m_panelDetailRestriction.Controls.Add(this.m_imageNoAdd);
            this.m_panelDetailRestriction.Controls.Add(this.m_lblRestrictionGlobale);
            this.m_panelDetailRestriction.Controls.Add(this.m_imageRestrictionGlobale);
            this.m_panelDetailRestriction.Controls.Add(this.m_lblType);
            this.m_panelDetailRestriction.Controls.Add(this.m_wndListeChamps);
            this.m_panelDetailRestriction.Controls.Add(this.m_panelLegende);
            this.m_panelDetailRestriction.Controls.Add(this.m_chkSurcharge);
            this.m_extLinkField.SetLinkField(this.m_panelDetailRestriction, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelDetailRestriction, false);
            this.m_panelDetailRestriction.Location = new System.Drawing.Point(320, 0);
            this.m_panelDetailRestriction.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelDetailRestriction, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelDetailRestriction, "");
            this.m_panelDetailRestriction.Name = "m_panelDetailRestriction";
            this.m_panelDetailRestriction.Size = new System.Drawing.Size(478, 342);
            this.m_extStyle.SetStyleBackColor(this.m_panelDetailRestriction, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelDetailRestriction, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelDetailRestriction.TabIndex = 8;
            // 
            // m_gridExceptions
            // 
            this.m_gridExceptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_gridExceptions.BackgroundColor = System.Drawing.Color.White;
            this.m_gridExceptions.CaptionVisible = false;
            this.m_gridExceptions.DataMember = "";
            this.m_gridExceptions.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.m_extLinkField.SetLinkField(this.m_gridExceptions, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_gridExceptions, false);
            this.m_gridExceptions.Location = new System.Drawing.Point(310, 80);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_gridExceptions, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_gridExceptions, "");
            this.m_gridExceptions.Name = "m_gridExceptions";
            this.m_gridExceptions.PreferredRowHeight = 20;
            this.m_gridExceptions.RowHeadersVisible = false;
            this.m_gridExceptions.Size = new System.Drawing.Size(165, 230);
            this.m_extStyle.SetStyleBackColor(this.m_gridExceptions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_gridExceptions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_gridExceptions.TabIndex = 4013;
            // 
            // m_nPriorite
            // 
            this.m_nPriorite.DoubleValue = 0;
            this.m_nPriorite.IntValue = 0;
            this.m_extLinkField.SetLinkField(this.m_nPriorite, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_nPriorite, false);
            this.m_nPriorite.Location = new System.Drawing.Point(119, 57);
            this.m_nPriorite.LockEdition = false;
            this.m_nPriorite.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_nPriorite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_nPriorite, "");
            this.m_nPriorite.Name = "m_nPriorite";
            this.m_nPriorite.Size = new System.Drawing.Size(80, 20);
            this.m_extStyle.SetStyleBackColor(this.m_nPriorite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_nPriorite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_nPriorite.TabIndex = 4012;
            this.m_nPriorite.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_nPriorite.ThousandsSeparator = true;
            this.m_nPriorite.ValueChanged += new System.EventHandler(this.m_nPriorite_ValueChanged);
            this.m_nPriorite.Validated += new System.EventHandler(this.m_nPriorite_Validated);
            // 
            // label6
            // 
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label6, false);
            this.label6.Location = new System.Drawing.Point(8, 59);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label6, "");
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 16);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 4011;
            this.label6.Text = "Priority level|1087";
            // 
            // m_imageNoDelete
            // 
            this.m_imageNoDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_extLinkField.SetLinkField(this.m_imageNoDelete, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_imageNoDelete, false);
            this.m_imageNoDelete.Location = new System.Drawing.Point(40, 24);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_imageNoDelete, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_imageNoDelete, "");
            this.m_imageNoDelete.Name = "m_imageNoDelete";
            this.m_imageNoDelete.Size = new System.Drawing.Size(16, 16);
            this.m_imageNoDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_extStyle.SetStyleBackColor(this.m_imageNoDelete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_imageNoDelete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_imageNoDelete.TabIndex = 4010;
            this.m_imageNoDelete.TabStop = false;
            this.m_imageNoDelete.Click += new System.EventHandler(this.m_imageNoDelete_Click);
            // 
            // m_imageNoAdd
            // 
            this.m_imageNoAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_extLinkField.SetLinkField(this.m_imageNoAdd, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_imageNoAdd, false);
            this.m_imageNoAdd.Location = new System.Drawing.Point(24, 24);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_imageNoAdd, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_imageNoAdd, "");
            this.m_imageNoAdd.Name = "m_imageNoAdd";
            this.m_imageNoAdd.Size = new System.Drawing.Size(16, 16);
            this.m_imageNoAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_extStyle.SetStyleBackColor(this.m_imageNoAdd, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_imageNoAdd, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_imageNoAdd.TabIndex = 4009;
            this.m_imageNoAdd.TabStop = false;
            this.m_imageNoAdd.Click += new System.EventHandler(this.m_imageNoAdd_Click);
            // 
            // m_lblRestrictionGlobale
            // 
            this.m_lblRestrictionGlobale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_lblRestrictionGlobale, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblRestrictionGlobale, false);
            this.m_lblRestrictionGlobale.Location = new System.Drawing.Point(64, 24);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblRestrictionGlobale, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblRestrictionGlobale, "");
            this.m_lblRestrictionGlobale.Name = "m_lblRestrictionGlobale";
            this.m_lblRestrictionGlobale.Size = new System.Drawing.Size(406, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lblRestrictionGlobale, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblRestrictionGlobale, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblRestrictionGlobale.TabIndex = 4008;
            this.m_lblRestrictionGlobale.Text = "[]";
            // 
            // m_imageRestrictionGlobale
            // 
            this.m_imageRestrictionGlobale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_extLinkField.SetLinkField(this.m_imageRestrictionGlobale, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_imageRestrictionGlobale, false);
            this.m_imageRestrictionGlobale.Location = new System.Drawing.Point(8, 24);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_imageRestrictionGlobale, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_imageRestrictionGlobale, "");
            this.m_imageRestrictionGlobale.Name = "m_imageRestrictionGlobale";
            this.m_imageRestrictionGlobale.Size = new System.Drawing.Size(16, 16);
            this.m_imageRestrictionGlobale.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_extStyle.SetStyleBackColor(this.m_imageRestrictionGlobale, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_imageRestrictionGlobale, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_imageRestrictionGlobale.TabIndex = 4007;
            this.m_imageRestrictionGlobale.TabStop = false;
            this.m_imageRestrictionGlobale.Click += new System.EventHandler(this.m_imageRestrictionGlobale_Click);
            // 
            // m_lblType
            // 
            this.m_extLinkField.SetLinkField(this.m_lblType, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblType, false);
            this.m_lblType.Location = new System.Drawing.Point(8, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblType, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblType, "");
            this.m_lblType.Name = "m_lblType";
            this.m_lblType.Size = new System.Drawing.Size(296, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lblType, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblType, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblType.TabIndex = 4006;
            // 
            // m_wndListeChamps
            // 
            this.m_wndListeChamps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_wndListeChamps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.m_extLinkField.SetLinkField(this.m_wndListeChamps, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_wndListeChamps, false);
            this.m_wndListeChamps.Location = new System.Drawing.Point(8, 80);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_wndListeChamps, "");
            this.m_wndListeChamps.Name = "m_wndListeChamps";
            this.m_wndListeChamps.Size = new System.Drawing.Size(296, 230);
            this.m_wndListeChamps.SmallImageList = this.m_imagesDroits;
            this.m_extStyle.SetStyleBackColor(this.m_wndListeChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeChamps.TabIndex = 1;
            this.m_wndListeChamps.UseCompatibleStateImageBehavior = false;
            this.m_wndListeChamps.View = System.Windows.Forms.View.Details;
            this.m_wndListeChamps.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_wndListeChamps_KeyDown);
            this.m_wndListeChamps.Click += new System.EventHandler(this.m_wndListeChamps_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Field|85";
            this.columnHeader1.Width = 279;
            // 
            // m_imagesDroits
            // 
            this.m_imagesDroits.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imagesDroits.ImageStream")));
            this.m_imagesDroits.TransparentColor = System.Drawing.Color.Transparent;
            this.m_imagesDroits.Images.SetKeyName(0, "");
            this.m_imagesDroits.Images.SetKeyName(1, "");
            this.m_imagesDroits.Images.SetKeyName(2, "");
            this.m_imagesDroits.Images.SetKeyName(3, "");
            this.m_imagesDroits.Images.SetKeyName(4, "");
            this.m_imagesDroits.Images.SetKeyName(5, "");
            this.m_imagesDroits.Images.SetKeyName(6, "");
            // 
            // m_panelLegende
            // 
            this.m_panelLegende.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_panelLegende.Controls.Add(this.label5);
            this.m_panelLegende.Controls.Add(this.label4);
            this.m_panelLegende.Controls.Add(this.label3);
            this.m_extLinkField.SetLinkField(this.m_panelLegende, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelLegende, false);
            this.m_panelLegende.Location = new System.Drawing.Point(8, 318);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelLegende, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelLegende, "");
            this.m_panelLegende.Name = "m_panelLegende";
            this.m_panelLegende.Size = new System.Drawing.Size(296, 16);
            this.m_extStyle.SetStyleBackColor(this.m_panelLegende, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelLegende, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelLegende.TabIndex = 4005;
            // 
            // label5
            // 
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label5, false);
            this.label5.Location = new System.Drawing.Point(217, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 5;
            this.label5.Text = "Hiden|1090";
            // 
            // label4
            // 
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label4, false);
            this.label4.Location = new System.Drawing.Point(111, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 16);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 3;
            this.label4.Text = "Read only|1089";
            // 
            // label3
            // 
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label3, false);
            this.label3.Location = new System.Drawing.Point(16, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 1;
            this.label3.Text = "Read/Write|1088";
            // 
            // m_chkSurcharge
            // 
            this.m_extLinkField.SetLinkField(this.m_chkSurcharge, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_chkSurcharge, false);
            this.m_chkSurcharge.Location = new System.Drawing.Point(8, 40);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkSurcharge, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkSurcharge, "");
            this.m_chkSurcharge.Name = "m_chkSurcharge";
            this.m_chkSurcharge.Size = new System.Drawing.Size(357, 19);
            this.m_extStyle.SetStyleBackColor(this.m_chkSurcharge, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkSurcharge, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkSurcharge.TabIndex = 4005;
            this.m_chkSurcharge.Text = "This restriction cancels the lower priority restrictions|1086";
            this.m_chkSurcharge.CheckedChanged += new System.EventHandler(this.m_chkSurcharge_CheckedChanged);
            // 
            // m_wndListeRestrictions
            // 
            this.m_wndListeRestrictions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_wndListeRestrictions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_colType});
            this.m_wndListeRestrictions.HideSelection = false;
            this.m_extLinkField.SetLinkField(this.m_wndListeRestrictions, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_wndListeRestrictions, false);
            this.m_wndListeRestrictions.Location = new System.Drawing.Point(8, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeRestrictions, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndListeRestrictions, "");
            this.m_wndListeRestrictions.MultiSelect = false;
            this.m_wndListeRestrictions.Name = "m_wndListeRestrictions";
            this.m_wndListeRestrictions.Size = new System.Drawing.Size(296, 310);
            this.m_wndListeRestrictions.SmallImageList = this.m_imagesDroits;
            this.m_extStyle.SetStyleBackColor(this.m_wndListeRestrictions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeRestrictions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeRestrictions.TabIndex = 3;
            this.m_wndListeRestrictions.UseCompatibleStateImageBehavior = false;
            this.m_wndListeRestrictions.View = System.Windows.Forms.View.Details;
            this.m_wndListeRestrictions.SelectedIndexChanged += new System.EventHandler(this.m_wndListeRestrictions_SelectedIndexChanged);
            this.m_wndListeRestrictions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_wndListeRestrictions_KeyDown);
            // 
            // m_colType
            // 
            this.m_colType.Text = "Object type|1085";
            this.m_colType.Width = 279;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.m_extLinkField.SetLinkField(this.pictureBox3, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.pictureBox3, false);
            this.pictureBox3.Location = new System.Drawing.Point(136, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pictureBox3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pictureBox3, "");
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(16, 16);
            this.m_extStyle.SetStyleBackColor(this.pictureBox3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pictureBox3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.m_extLinkField.SetLinkField(this.pictureBox2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.pictureBox2, false);
            this.pictureBox2.Location = new System.Drawing.Point(80, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pictureBox2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pictureBox2, "");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.m_extStyle.SetStyleBackColor(this.pictureBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pictureBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.m_extLinkField.SetLinkField(this.pictureBox1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.pictureBox1, false);
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pictureBox1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pictureBox1, "");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.m_extStyle.SetStyleBackColor(this.pictureBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pictureBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // CFormEditionGroupeRestriction
            // 
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.c2iPanelOmbre1);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionGroupeRestriction";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre4, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre1, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.c2iPanelOmbre4.ResumeLayout(false);
            this.c2iPanelOmbre4.PerformLayout();
            this.c2iPanelOmbre1.ResumeLayout(false);
            this.c2iPanelOmbre1.PerformLayout();
            this.m_panelDetailRestriction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_gridExceptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_nPriorite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageNoDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageNoAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageRestrictionGlobale)).EndInit();
            this.m_panelLegende.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CGroupeRestrictionSurType GroupeRestriction
		{
			get
			{
				return (CGroupeRestrictionSurType)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
			AffecterTitre(I.T("Restriction group @1|30267", GroupeRestriction.Libelle));

			m_listeRestrictions = new ArrayList();
			
			CInfoClasseDynamique[] classes = DynamicClassAttribute.GetAllDynamicClass ( );
			CListeRestrictionsUtilisateurSurType restrictions = GroupeRestriction.ListeRestrictions;
			ArrayList lst = new ArrayList();
			foreach ( CInfoClasseDynamique classe in classes )
			{
				CRestrictionUtilisateurSurType rest = restrictions.GetRestriction ( classe.Classe );
				if ( this.EtatEdition || rest.HasRestrictions )
					m_listeRestrictions.Add ( rest );
			}

			FillListeRestrictions();

			ShowInfosOnCurrentRestriction();

			m_chkAnnulerInfs.Checked = GroupeRestriction.SeuilAnnulationPriorites != null;
			if (GroupeRestriction.SeuilAnnulationPriorites != null)
				m_txtSeuilAnnulation.IntValue = (int)GroupeRestriction.SeuilAnnulationPriorites;
			else
				m_txtSeuilAnnulation.Text = "";
				
			
			return result;
		}

		//-------------------------------------------------------------------------
		protected override CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = base.MAJ_Champs();
			ValideRestrictionEnCours();
			CListeRestrictionsUtilisateurSurType liste = new CListeRestrictionsUtilisateurSurType();
			foreach ( ListViewItem item in m_wndListeRestrictions.Items )
			{
				CRestrictionUtilisateurSurType rest = (CRestrictionUtilisateurSurType)item.Tag;
				if ( rest.HasRestrictions)
				{
					liste.AddRestriction ( rest );
				}
			}
			if (m_chkAnnulerInfs.Checked)
				GroupeRestriction.SeuilAnnulationPriorites = m_txtSeuilAnnulation.IntValue;
			else
				GroupeRestriction.SeuilAnnulationPriorites = null;

			GroupeRestriction.ListeRestrictions = liste;

			return result;
		}


		
		
		//-------------------------------------------------------------------------
		private void FillListeRestrictions()
		{
			Type tpSel = null;
			if ( m_wndListeRestrictions.SelectedItems.Count == 1 )
				tpSel = ((CRestrictionUtilisateurSurType)m_wndListeRestrictions.SelectedItems[0].Tag).TypeAssocie;
            m_wndListeChamps.BeginUpdate();
			m_wndListeRestrictions.Items.Clear();
            
			ListViewItem selected = null;
			foreach ( CRestrictionUtilisateurSurType restriction in m_listeRestrictions )
			{
				ListViewItem item = new ListViewItem();
				FillItemRestriction ( item, restriction );
				m_wndListeRestrictions.Items.Add ( item );
				if ( restriction.TypeAssocie == tpSel )
					selected = item;
			}
			if ( selected != null )
			{
				selected.EnsureVisible();
				selected.Selected = true;
				ShowInfosOnCurrentRestriction();
			}
            m_wndListeChamps.EndUpdate();
		}

		//-------------------------------------------------------------------------
		private void FillItemRestriction ( ListViewItem item, CRestrictionUtilisateurSurType restriction )
		{
			item.Text = DynamicClassAttribute.GetNomConvivial ( restriction.TypeAssocie );
			item.Tag = restriction;
			item.ImageIndex = GetIndexImage ( restriction.RestrictionUtilisateur );
		}

		//-------------------------------------------------------------------------
		private void ValideRestrictionEnCours()
		{
			if ( m_restrictionAffichee == null )
				return;
			foreach ( ListViewItem item in m_wndListeChamps.Items )
			{
				string strProp = (string)item.Tag;
				ERestriction rest = ERestriction.Aucune;
				if ( item.ImageIndex == 1 )
					rest = ERestriction.ReadOnly;
				if ( item.ImageIndex == 2 )
					rest = ERestriction.Hide;
				m_restrictionAffichee.SetRestrictionLocale ( strProp, rest );
			}
			ListViewItem itemToModify = GetItemForType ( m_restrictionAffichee.TypeAssocie );
			if ( itemToModify != null )
			{
				FillItemRestriction ( itemToModify, m_restrictionAffichee );
			}
            DataTable table = m_gridExceptions.DataSource as DataTable;
            if (table != null)
            {
                List<string> lst = new List<string>();
                foreach (DataRow row in table.Rows)
                    lst.Add(row[0].ToString());
                m_restrictionAffichee.ContextesException = lst.ToArray();
            }
		}

		//-------------------------------------------------------------------------
		private void ShowInfosOnCurrentRestriction()
		{
			ValideRestrictionEnCours();
			if ( m_wndListeRestrictions.SelectedItems.Count == 0 )
			{
				m_restrictionAffichee = null;
				m_panelDetailRestriction.Visible = false;
				return;
			}
           
			CRestrictionUtilisateurSurType restriction = (CRestrictionUtilisateurSurType)m_wndListeRestrictions.SelectedItems[0].Tag;
			m_restrictionAffichee = restriction;
			m_panelDetailRestriction.Visible = true;
			m_lblType.Text = DynamicClassAttribute.GetNomConvivial ( restriction.TypeAssocie );
			FillListeChamps ( restriction );
			RefreshRestrictionGlobale();
		}
                
		//-------------------------------------------------------------------------
		private void FillListeChamps ( CRestrictionUtilisateurSurType restriction )
		{
			m_wndListeChamps.Items.Clear();
			CInfoStructureDynamique info =  CInfoStructureDynamique.GetStructure ( restriction.TypeAssocie, 0 );
			foreach ( CInfoChampDynamique champ in info.Champs )
			{
                string strTmp = "";
                CDefinitionProprieteDynamique def = CConvertisseurInfoStructureDynamiqueToDefinitionChamp.GetDefinitionProprieteDynamique(champ.NomPropriete, ref strTmp);
                //Uniquement les propriétés "classiques"
                //voir CTimosApp.GetStructure
                if (def != null && typeof(CDefinitionProprieteDynamiqueDotNet).IsAssignableFrom(def.GetType() ))
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = champ.NomChamp;
                    item.Tag = def.NomProprieteSansCleTypeChamp;
                    item.ImageIndex = GetIndexImage(restriction.GetRestriction(def.NomProprieteSansCleTypeChamp));
                    m_wndListeChamps.Items.Add(item);
                }
			}
			if (typeof(IElementAChamps).IsAssignableFrom(restriction.TypeAssocie))
			{
				CRoleChampCustom role = CRoleChampCustom.GetRoleForType(restriction.TypeAssocie);
				if (role != null)
				{
                    CListeObjetsDonnees listeChampsCustom = CChampCustom.GetListeChampsForRole(GroupeRestriction.ContexteDonnee,
                        role.CodeRole);
					foreach (CChampCustom champ in listeChampsCustom)
					{
						ListViewItem item = new ListViewItem();
						item.Text = champ.Nom;
						item.Tag = champ.CleRestriction;
						item.ImageIndex = GetIndexImage(restriction.GetRestriction(champ.CleRestriction));
						m_wndListeChamps.Items.Add(item);
					}

					CListeObjetsDonnees listeFormulaires = new CListeObjetsDonnees(GroupeRestriction.ContexteDonnee, typeof(CFormulaire));
                    listeFormulaires.Filtre = CFormulaire.GetFiltreFormulairesForRole(role.CodeRole);
					//listeFormulaires.Filtre = new CFiltreData(CFormulaire.c_champCodeRole + "=@1", role.CodeRole);
					foreach (CFormulaire formulaire in listeFormulaires)
					{
						ListViewItem item = new ListViewItem();
						item.Text = "{" + formulaire.Libelle + "}";
						item.Tag = formulaire.CleRestriction;
						item.ImageIndex = GetIndexImage(restriction.GetRestriction(formulaire.CleRestriction));
						m_wndListeChamps.Items.Add(item);
					}
				}
			}
		}

		//-------------------------------------------------------------------------
		private void m_wndListeChamps_Click(object sender, System.EventArgs e)
		{
			Point pt = m_wndListeChamps.PointToClient ( new Point ( MousePosition.X, MousePosition.Y ) );
			if ( pt.X < 20 && pt.X > 0 )
			{
				ListViewItem item = m_wndListeChamps.GetItemAt ( pt.X, pt.Y );
				if ( item != null )
					item.ImageIndex = (item.ImageIndex+1)%3;
				if ( m_wndListeChamps.SelectedItems.Count > 1 )
				{
					foreach ( ListViewItem itemSel in m_wndListeChamps.SelectedItems )
						itemSel.ImageIndex = item.ImageIndex;
				}
			}
		}

		//-------------------------------------------------------------------------
		private ListViewItem GetItemForType ( Type tp )
		{
			foreach ( ListViewItem item in m_wndListeRestrictions.Items )
			{
				if ( ((CRestrictionUtilisateurSurType)item.Tag).TypeAssocie == tp )
					return item;
			}
			return null;
		}

		
		//-------------------------------------------------------------------------
		private void m_wndListeRestrictions_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ShowInfosOnCurrentRestriction();
		}

		//-------------------------------------------------------------------------
		private void m_imageRestrictionGlobale_Click(object sender, System.EventArgs e)
		{
			RotateDroitRestrictionSelectionnee();
		}

		//-------------------------------------------------------------------------
		private void RotateDroitRestrictionSelectionnee()
		{
			if ( m_restrictionAffichee == null )
				return;
			if ( m_restrictionAffichee.CanModifyType() )
				m_restrictionAffichee.RestrictionUtilisateur = ERestriction.ReadOnly;
			else if ( m_restrictionAffichee.CanShowType() )
				m_restrictionAffichee.RestrictionUtilisateur = ERestriction.Hide;
			else
				m_restrictionAffichee.RestrictionUtilisateur = ERestriction.Aucune;
			RefreshRestrictionGlobale();
		}



		//-------------------------------------------------------------------------
		private void RefreshRestrictionGlobale()
		{
			if ( m_restrictionAffichee == null )
				return;
			m_chkSurcharge.Checked = m_restrictionAffichee.SurchageComplete;
			m_nPriorite.IntValue = m_restrictionAffichee.Priorite;
            m_imageRestrictionGlobale.Image = GetImage(m_restrictionAffichee.RestrictionUtilisateur);
            m_lblRestrictionGlobale.Text = GetLibelleRestriction(m_restrictionAffichee.RestrictionUtilisateur);

            if ((m_restrictionAffichee.RestrictionUtilisateur & ERestriction.NoCreate) == ERestriction.NoCreate)
				m_imageNoAdd.Image = m_imagesDroits.Images[4];
			else
				m_imageNoAdd.Image = m_imagesDroits.Images[3];
			
			if ( (m_restrictionAffichee.RestrictionUtilisateur & ERestriction.NoDelete ) == ERestriction.NoDelete )
				m_imageNoDelete.Image = m_imagesDroits.Images[6];
			else
				m_imageNoDelete.Image = m_imagesDroits.Images[5];

			if ( m_wndListeRestrictions.SelectedItems.Count ==1 && 
				((CRestrictionUtilisateurSurType)m_wndListeRestrictions.SelectedItems[0].Tag).TypeAssocie ==
				m_restrictionAffichee.TypeAssocie )
				FillItemRestriction ( m_wndListeRestrictions.SelectedItems[0], m_restrictionAffichee );

            DataTable table = new DataTable("EXCEPTIONS");
            table.Columns.Add("TEXT");
            foreach (string strException in m_restrictionAffichee.ContextesException)
            {
                DataRow row = table.NewRow();
                row[0] = strException;
                table.Rows.Add(row);
            }
            if (m_gridExceptions.TableStyles[table.TableName] == null)
            {
                DataGridTableStyle tableStyle = new DataGridTableStyle();
                tableStyle.MappingName = table.TableName;

                DataGridTextBoxColumn colStyleValue = new DataGridTextBoxColumn();
                colStyleValue.MappingName = "TEXT";
                colStyleValue.HeaderText = I.T("Exceptions|20141");
                colStyleValue.Width = m_gridExceptions.Width -30;
                colStyleValue.ReadOnly = false;

                tableStyle.RowHeadersVisible = true;

                tableStyle.GridColumnStyles.AddRange(new DataGridColumnStyle[] { colStyleValue });

                m_gridExceptions.TableStyles.Add(tableStyle);
            }

            table.DefaultView.AllowNew = true;
            table.DefaultView.AllowDelete = true;

            m_gridExceptions.DataSource = table;
            m_gridExceptions.ReadOnly = !EtatEdition;
		}

		//-------------------------------------------------------------------------
		private int GetIndexImage ( ERestriction rest )
		{
			if ( (rest & ERestriction.Hide )== ERestriction.Hide )
				return 2;
			if ( (rest & ERestriction.ReadOnly) == ERestriction.ReadOnly )
				return 1;
			return 0;
		}

		//-------------------------------------------------------------------------
		private Image GetImage ( ERestriction rest )
		{
			return m_imagesDroits.Images[GetIndexImage(rest)];
		}

		//-------------------------------------------------------------------------
		private string GetLibelleRestriction ( ERestriction rest )
		{
			if ( (rest & ERestriction.Hide )== ERestriction.Hide )
				return I.T("Mask|967");
			if ( (rest & ERestriction.ReadOnly ) == ERestriction.ReadOnly)
				return I.T("Read only|30968");
			string strLibelle = I.T("Read/Write|30269");
			if ( (rest & ERestriction.NoCreate ) != ERestriction.NoCreate)
				strLibelle += I.T("Create|30270");
			if ( (rest & ERestriction.NoDelete ) != ERestriction.NoDelete )
				strLibelle += I.T("Delete|30271");
			return strLibelle;
		}

		//-------------------------------------------------------------------------
		private void m_imageNoAdd_Click(object sender, System.EventArgs e)
		{
			InverseFlagRestriction ( ERestriction.NoCreate );
		}

		//-------------------------------------------------------------------------
		private void InverseFlagRestriction ( ERestriction restriction )
		{
			if ( m_restrictionAffichee == null )
				return;
			if ( (m_restrictionAffichee.RestrictionUtilisateur & restriction )==restriction )
				m_restrictionAffichee.RestrictionUtilisateur -= (int)restriction;
			else
				m_restrictionAffichee.RestrictionUtilisateur += (int)restriction;
			RefreshRestrictionGlobale();
		}

		//-------------------------------------------------------------------------
		private void m_imageNoDelete_Click(object sender, System.EventArgs e)
		{
			InverseFlagRestriction ( ERestriction.NoDelete );
		}

		private void m_wndListeRestrictions_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if ( e.KeyCode == Keys.Space && m_gestionnaireModeEdition.ModeEdition )
			{
				if ( m_restrictionAffichee != null )
				{
					RotateDroitRestrictionSelectionnee();
					RefreshRestrictionGlobale();
				}
			}
		}

		/// <summary>
		/// //////////////////////////////////////////////////////////////
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void m_chkSurcharge_CheckedChanged(object sender, System.EventArgs e)
		{
			m_restrictionAffichee.SurchageComplete = m_chkSurcharge.Checked;
		}

		//////////////////////////////////////////////////////////////
		private void m_nPriorite_ValueChanged(object sender, System.EventArgs e)
		{
			m_restrictionAffichee.Priorite = m_nPriorite.IntValue;
		}

		//////////////////////////////////////////////////////////////
		private void m_nPriorite_Validated(object sender, System.EventArgs e)
		{
			m_restrictionAffichee.Priorite = m_nPriorite.IntValue;
		}

        private void m_wndListeChamps_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && m_gestionnaireModeEdition.ModeEdition)
            {
                foreach ( ListViewItem item in m_wndListeChamps.SelectedItems )
                {
                    string strTag = item.Tag.ToString();
                    item.ImageIndex = (item.ImageIndex + 1) % 3;
                }
            }
        }


        private void m_lnkClearAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show(I.T("Clear all restrictions ?|20546"),
                I.T("Confirmation|20"),
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                m_listeRestrictions = new ArrayList();
                m_restrictionAffichee = null;
                CInfoClasseDynamique[] classes = DynamicClassAttribute.GetAllDynamicClass();
                foreach (CInfoClasseDynamique classe in classes)
                {
                    CRestrictionUtilisateurSurType rest = new CRestrictionUtilisateurSurType(classe.Classe);
                    m_listeRestrictions.Add(rest);
                }
                FillListeRestrictions();
            }

        }
			
					
				
	}
}

