using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Windows.Forms;
using sc2i.data.dynamic;
using sc2i.data;
using sc2i.win32.navigation;
using sc2i.common;
using sc2i.win32.data;
using sc2i.win32.common;
using sc2i.expression;
using sc2i.win32.data.dynamic;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CChampCalcule))]
	public class CFormEditionChampCalcule : CFormEditionStdTimos, IFormNavigable
	{
		private Hashtable m_hashtableValeurs = new Hashtable();
		private System.Windows.Forms.Label label1;
		private C2iTextBox m_txtNom;
		private System.Windows.Forms.Label label3;
		private sc2i.win32.common.C2iTextBox m_txtDescription;
		private System.ComponentModel.IContainer components = null;

		private CObjetDonnee m_objetTest = null;

		private const string c_strColValeur = "ValChampCalcule";
		private const string c_strColValeurAffichee = "Valeur affichée";
		private System.Windows.Forms.Label label6;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre1;
		private System.Windows.Forms.Panel m_panelFond;
		private System.Windows.Forms.Panel m_panelDonnees;
		private sc2i.win32.expression.CControlAideFormule m_wndAide;
		private System.Windows.Forms.Splitter splitter1;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre3;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button m_btnTest;
		private System.Windows.Forms.Button m_btnSelectElementTest;
		private const string c_strColValeurStockee = "Valeur stockée";
		private sc2i.win32.expression.CControleEditeFormule m_txtFormule;
		private C2iComboSelectDynamicClass m_cmbTypeElement;
        private LinkLabel m_lnkTest;
        private C2iComboBox m_cmbCategorie;
        private Label label2;
		private bool m_bComboRemplissageInitialized = false;

		//-------------------------------------------------------------------------
		public CFormEditionChampCalcule()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionChampCalcule(CChampCalcule ChampCalcule)
			:base(ChampCalcule)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionChampCalcule(CChampCalcule ChampCalcule ,CListeObjetsDonnees liste)
			:base(ChampCalcule, liste)
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
		//-------------------------------------------------------------------------
		#region Designer generated code
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionChampCalcule));
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtNom = new sc2i.win32.common.C2iTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtDescription = new sc2i.win32.common.C2iTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.c2iPanelOmbre1 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_cmbTypeElement = new sc2i.win32.common.C2iComboSelectDynamicClass(this.components);
            this.m_panelFond = new System.Windows.Forms.Panel();
            this.m_panelDonnees = new System.Windows.Forms.Panel();
            this.c2iPanelOmbre3 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_txtFormule = new sc2i.win32.expression.CControleEditeFormule();
            this.m_btnSelectElementTest = new System.Windows.Forms.Button();
            this.m_btnTest = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.m_lnkTest = new System.Windows.Forms.LinkLabel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_wndAide = new sc2i.win32.expression.CControlAideFormule();
            this.m_cmbCategorie = new sc2i.win32.common.C2iComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre1.SuspendLayout();
            this.m_panelFond.SuspendLayout();
            this.m_panelDonnees.SuspendLayout();
            this.c2iPanelOmbre3.SuspendLayout();
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
            this.m_panelNavigation.Location = new System.Drawing.Point(617, 0);
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
            this.m_panelCle.Location = new System.Drawing.Point(509, 0);
            this.m_panelCle.Size = new System.Drawing.Size(108, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(792, 28);
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
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label1, "");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 7;
            this.label1.Text = "Name|82";
            // 
            // m_txtNom
            // 
            this.m_txtNom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtNom.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtNom, "Nom");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtNom, true);
            this.m_txtNom.Location = new System.Drawing.Point(88, 8);
            this.m_txtNom.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtNom, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtNom, "");
            this.m_txtNom.Name = "m_txtNom";
            this.m_txtNom.Size = new System.Drawing.Size(323, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtNom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtNom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtNom.TabIndex = 0;
            this.m_txtNom.Text = "[Nom]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label3, false);
            this.label3.Location = new System.Drawing.Point(8, 59);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 11;
            this.label3.Text = "Description|655";
            // 
            // m_txtDescription
            // 
            this.m_txtDescription.AcceptsReturn = true;
            this.m_txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtDescription.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtDescription, "Description");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtDescription, true);
            this.m_txtDescription.Location = new System.Drawing.Point(88, 54);
            this.m_txtDescription.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtDescription, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtDescription, "");
            this.m_txtDescription.Multiline = true;
            this.m_txtDescription.Name = "m_txtDescription";
            this.m_txtDescription.Size = new System.Drawing.Size(323, 48);
            this.m_extStyle.SetStyleBackColor(this.m_txtDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtDescription.TabIndex = 2;
            this.m_txtDescription.Text = "[Description]";
            // 
            // label6
            // 
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label6, false);
            this.label6.Location = new System.Drawing.Point(8, 108);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label6, "");
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 23);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 4001;
            this.label6.Text = "Application|893";
            // 
            // c2iPanelOmbre1
            // 
            this.c2iPanelOmbre1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iPanelOmbre1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre1.Controls.Add(this.m_cmbCategorie);
            this.c2iPanelOmbre1.Controls.Add(this.label2);
            this.c2iPanelOmbre1.Controls.Add(this.m_cmbTypeElement);
            this.c2iPanelOmbre1.Controls.Add(this.label1);
            this.c2iPanelOmbre1.Controls.Add(this.m_txtNom);
            this.c2iPanelOmbre1.Controls.Add(this.m_txtDescription);
            this.c2iPanelOmbre1.Controls.Add(this.label6);
            this.c2iPanelOmbre1.Controls.Add(this.label3);
            this.c2iPanelOmbre1.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iPanelOmbre1, false);
            this.c2iPanelOmbre1.Location = new System.Drawing.Point(8, 8);
            this.c2iPanelOmbre1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre1, "");
            this.c2iPanelOmbre1.Name = "c2iPanelOmbre1";
            this.c2iPanelOmbre1.Size = new System.Drawing.Size(443, 146);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre1.TabIndex = 0;
            // 
            // m_cmbTypeElement
            // 
            this.m_cmbTypeElement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbTypeElement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTypeElement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbTypeElement.FormattingEnabled = true;
            this.m_cmbTypeElement.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbTypeElement, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbTypeElement, false);
            this.m_cmbTypeElement.Location = new System.Drawing.Point(88, 105);
            this.m_cmbTypeElement.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbTypeElement, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbTypeElement, "");
            this.m_cmbTypeElement.Name = "m_cmbTypeElement";
            this.m_cmbTypeElement.Size = new System.Drawing.Size(323, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbTypeElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbTypeElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbTypeElement.TabIndex = 3;
            this.m_cmbTypeElement.TypeSelectionne = null;
            this.m_cmbTypeElement.SelectedIndexChanged += new System.EventHandler(this.m_cmbTypeElements_SelectedIndexChanged);
            // 
            // m_panelFond
            // 
            this.m_panelFond.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelFond.Controls.Add(this.m_panelDonnees);
            this.m_panelFond.Controls.Add(this.splitter1);
            this.m_panelFond.Controls.Add(this.m_wndAide);
            this.m_extLinkField.SetLinkField(this.m_panelFond, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelFond, false);
            this.m_panelFond.Location = new System.Drawing.Point(8, 48);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelFond, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelFond, "");
            this.m_panelFond.Name = "m_panelFond";
            this.m_panelFond.Size = new System.Drawing.Size(776, 408);
            this.m_extStyle.SetStyleBackColor(this.m_panelFond, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelFond, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelFond.TabIndex = 4001;
            // 
            // m_panelDonnees
            // 
            this.m_panelDonnees.Controls.Add(this.c2iPanelOmbre3);
            this.m_panelDonnees.Controls.Add(this.c2iPanelOmbre1);
            this.m_panelDonnees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelDonnees, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelDonnees, false);
            this.m_panelDonnees.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelDonnees, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelDonnees, "");
            this.m_panelDonnees.Name = "m_panelDonnees";
            this.m_panelDonnees.Size = new System.Drawing.Size(569, 408);
            this.m_extStyle.SetStyleBackColor(this.m_panelDonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelDonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelDonnees.TabIndex = 2;
            // 
            // c2iPanelOmbre3
            // 
            this.c2iPanelOmbre3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iPanelOmbre3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre3.Controls.Add(this.m_txtFormule);
            this.c2iPanelOmbre3.Controls.Add(this.m_btnSelectElementTest);
            this.c2iPanelOmbre3.Controls.Add(this.m_btnTest);
            this.c2iPanelOmbre3.Controls.Add(this.label8);
            this.c2iPanelOmbre3.Controls.Add(this.m_lnkTest);
            this.c2iPanelOmbre3.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre3, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iPanelOmbre3, false);
            this.c2iPanelOmbre3.Location = new System.Drawing.Point(8, 160);
            this.c2iPanelOmbre3.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre3, "");
            this.c2iPanelOmbre3.Name = "c2iPanelOmbre3";
            this.c2iPanelOmbre3.Size = new System.Drawing.Size(553, 245);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre3, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre3, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre3.TabIndex = 1;
            // 
            // m_txtFormule
            // 
            this.m_txtFormule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormule.BackColor = System.Drawing.Color.White;
            this.m_txtFormule.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtFormule.Formule = null;
            this.m_extLinkField.SetLinkField(this.m_txtFormule, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtFormule, false);
            this.m_txtFormule.Location = new System.Drawing.Point(8, 24);
            this.m_txtFormule.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtFormule, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtFormule, "");
            this.m_txtFormule.Name = "m_txtFormule";
            this.m_txtFormule.Size = new System.Drawing.Size(522, 168);
            this.m_extStyle.SetStyleBackColor(this.m_txtFormule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFormule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormule.TabIndex = 0;
            // 
            // m_btnSelectElementTest
            // 
            this.m_btnSelectElementTest.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.m_btnSelectElementTest.BackColor = System.Drawing.SystemColors.Control;
            this.m_extLinkField.SetLinkField(this.m_btnSelectElementTest, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnSelectElementTest, false);
            this.m_btnSelectElementTest.Location = new System.Drawing.Point(40, 197);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnSelectElementTest, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnSelectElementTest, "");
            this.m_btnSelectElementTest.Name = "m_btnSelectElementTest";
            this.m_btnSelectElementTest.Size = new System.Drawing.Size(224, 24);
            this.m_extStyle.SetStyleBackColor(this.m_btnSelectElementTest, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSelectElementTest, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnSelectElementTest.TabIndex = 1;
            this.m_btnSelectElementTest.Text = "Select an element to test|894";
            this.m_btnSelectElementTest.UseVisualStyleBackColor = false;
            this.m_btnSelectElementTest.Click += new System.EventHandler(this.m_btnSelectElementTest_Click);
            // 
            // m_btnTest
            // 
            this.m_btnTest.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.m_btnTest.BackColor = System.Drawing.SystemColors.Control;
            this.m_extLinkField.SetLinkField(this.m_btnTest, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnTest, false);
            this.m_btnTest.Location = new System.Drawing.Point(272, 197);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnTest, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnTest, "");
            this.m_btnTest.Name = "m_btnTest";
            this.m_btnTest.Size = new System.Drawing.Size(224, 24);
            this.m_extStyle.SetStyleBackColor(this.m_btnTest, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnTest, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnTest.TabIndex = 2;
            this.m_btnTest.Text = "Test|895";
            this.m_btnTest.UseVisualStyleBackColor = false;
            this.m_btnTest.Click += new System.EventHandler(this.m_btnTest_Click);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label8, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label8, false);
            this.label8.Location = new System.Drawing.Point(8, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label8, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label8, "");
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 16);
            this.m_extStyle.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 3;
            this.label8.Text = "Formula|582";
            // 
            // m_lnkTest
            // 
            this.m_lnkTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkTest.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lnkTest, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkTest, false);
            this.m_lnkTest.Location = new System.Drawing.Point(8, 203);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkTest, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkTest, "");
            this.m_lnkTest.Name = "m_lnkTest";
            this.m_lnkTest.Size = new System.Drawing.Size(16, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTest, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTest, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTest.TabIndex = 4;
            this.m_lnkTest.TabStop = true;
            this.m_lnkTest.Text = "...";
            this.m_lnkTest.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTest_LinkClicked);
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_extLinkField.SetLinkField(this.splitter1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.splitter1, false);
            this.splitter1.Location = new System.Drawing.Point(569, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitter1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitter1, "");
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 408);
            this.m_extStyle.SetStyleBackColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // m_wndAide
            // 
            this.m_wndAide.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_wndAide.FournisseurProprietes = null;
            this.m_extLinkField.SetLinkField(this.m_wndAide, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_wndAide, false);
            this.m_wndAide.Location = new System.Drawing.Point(574, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndAide, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndAide, "");
            this.m_wndAide.Name = "m_wndAide";
            this.m_wndAide.ObjetInterroge = null;
            this.m_wndAide.SendIdChamps = false;
            this.m_wndAide.Size = new System.Drawing.Size(202, 408);
            this.m_extStyle.SetStyleBackColor(this.m_wndAide, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndAide, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndAide.TabIndex = 3;
            this.m_wndAide.OnSendCommande += new sc2i.win32.expression.SendCommande(this.m_wndAide_OnSendCommande);
            // 
            // m_cmbCategorie
            // 
            this.m_cmbCategorie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbCategorie.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbCategorie, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbCategorie, false);
            this.m_cmbCategorie.Location = new System.Drawing.Point(88, 30);
            this.m_cmbCategorie.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbCategorie, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbCategorie, "");
            this.m_cmbCategorie.Name = "m_cmbCategorie";
            this.m_cmbCategorie.Size = new System.Drawing.Size(216, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbCategorie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbCategorie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbCategorie.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label2, false);
            this.label2.Location = new System.Drawing.Point(8, 33);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4009;
            this.label2.Text = "Folder|20043";
            // 
            // CFormEditionChampCalcule
            // 
            this.AffectationsPourNouvelElement = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("$this.AffectationsPourNouvelElement")));
            this.ClientSize = new System.Drawing.Size(792, 456);
            this.Controls.Add(this.m_panelFond);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionChampCalcule";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Load += new System.EventHandler(this.CFormEditionChampCalcule_Load);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.m_panelFond, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.c2iPanelOmbre1.ResumeLayout(false);
            this.c2iPanelOmbre1.PerformLayout();
            this.m_panelFond.ResumeLayout(false);
            this.m_panelDonnees.ResumeLayout(false);
            this.c2iPanelOmbre3.ResumeLayout(false);
            this.c2iPanelOmbre3.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		
		//-------------------------------------------------------------------------
		protected CChampCalcule Champ
		{
			get
			{
				return (CChampCalcule)ObjetEdite;
			}
		}

		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps() 
		{
            CResultAErreur result = base.MyInitChamps();
			m_txtFormule.Text = Champ.Formule.GetString();
            InitComboTypes(false);
            InitComboCategories();
            m_cmbCategorie.Text = Champ.Categorie;
			return result;
		}

        //-------------------------------------------------------------------------
        private bool m_bCmbComboCategoriesInit = false;
        private void InitComboCategories()
        {
            if (m_bCmbComboCategoriesInit)
                return;
            m_cmbCategorie.BeginUpdate();
            m_cmbCategorie.Items.Clear();
            foreach (string strChaine in CChampCustom.GetListeRubriques(Champ.ContexteDonnee))
                m_cmbCategorie.Items.Add(strChaine);
            m_cmbCategorie.EndUpdate();
            m_bCmbComboCategoriesInit = true;

        }

		//-------------------------------------------------------------------------
		protected void InitComboTypes ( bool bForcerRemplissage )
		{
			if (!m_bComboRemplissageInitialized || bForcerRemplissage)
			{
				m_cmbTypeElement.InitSurAttributs(typeof(TableAttribute));
				/*ArrayList classes = new ArrayList(DynamicClassAttribute.GetAllDynamicClass(typeof(sc2i.data.TableAttribute)));
                classes.Insert(0, new CInfoClasseDynamique(typeof(DBNull), "(Aucun)"));
                m_oldcmbTypeElements.DataSource = null;
				m_oldcmbTypeElements.DataSource = classes;
				m_oldcmbTypeElements.ValueMember = "Classe";
				m_oldcmbTypeElements.DisplayMember = "Nom";*/

				m_bComboRemplissageInitialized = true;
			}
			if ( Champ.TypeObjets != null )
				m_cmbTypeElement.TypeSelectionne = Champ.TypeObjets;
			m_wndAide.ObjetInterroge = Champ.TypeObjets;
			m_txtFormule.Init(m_wndAide.FournisseurProprietes, m_wndAide.ObjetInterroge);
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MAJ_Champs() 
		{
			CResultAErreur result = base.MAJ_Champs();
			if (result)
			{
				if (m_cmbTypeElement.TypeSelectionne == null)
				{
                    result.EmpileErreur(I.T("Select a destination object type|30213"));
                }
				else
					Champ.TypeObjets = m_cmbTypeElement.TypeSelectionne;

				result = MAJ_FormuleInChamp();
                Champ.Categorie = m_cmbCategorie.Text;
			}
			return result;
		}
		//-------------------------------------------------------------------------
		private void CFormEditionChampCalcule_Load(object sender, System.EventArgs e)
		{
			m_wndAide.FournisseurProprietes = new CFournisseurPropDynStd(true);
		}
		//-------------------------------------------------------------------------
		private void m_wndAide_OnSendCommande(string strCommande, int nPosCurseur)
		{
			m_wndAide.InsereInTextBox ( m_txtFormule.TextBox, nPosCurseur, strCommande );
		}
		//-------------------------------------------------------------------------
		private CResultAErreur MAJ_FormuleInChamp()
		{
			CResultAErreur result = CResultAErreur.True;
			if ( m_cmbTypeElement.TypeSelectionne == null )
			{
				result.EmpileErreur(I.T("Select an object type|30214"));
				return result;
			}
			Type tp = m_cmbTypeElement.TypeSelectionne;
			CContexteAnalyse2iExpression ctx = new CContexteAnalyse2iExpression(new CFournisseurPropDynStd(true), tp);
			CAnalyseurSyntaxiqueExpression analyseur = new CAnalyseurSyntaxiqueExpression(ctx);
			result = analyseur.AnalyseChaine(m_txtFormule.Text);
			if ( result )
				Champ.Formule = (C2iExpression)result.Data;
			else
				result.EmpileErreur(I.T("Formula error|1422"));
			return result;
		}

		private void m_btnTest_Click(object sender, System.EventArgs e)
		{
			CResultAErreur result = MAJ_Champs();
			if ( !result )
			{
				CFormAlerte.Afficher ( result.Erreur );
				return;
			}
			if ( m_objetTest == null )
			{
				if ( !SelectObjetTest() )
					return;
			}
			if ( m_objetTest == null )
				return;
			if ( !result )
			{
				CFormAlerte.Afficher(result.Erreur);
				return;
			}
			CContexteEvaluationExpression contexte = new CContexteEvaluationExpression(m_objetTest );
			result = Champ.Formule.Eval ( contexte );
			if ( !result )
			{
				CFormAlerte.Afficher ( result.Erreur );
				return;
			}
			if ( result.Data == null )
				CFormAlerte.Afficher("null", EFormAlerteType.Exclamation);
			else
				CFormAlerte.Afficher(result.Data.ToString(), EFormAlerteType.Exclamation);
		}

		//-------------------------------------------------------------------------
		private bool SelectObjetTest()
		{
			if ( m_cmbTypeElement.TypeSelectionne != null )
			{
				CObjetDonnee objet = CFormSelectUnObjetDonnee.SelectObjetDonnee ( 
                    I.T("Select an element for test|20735"),
                    m_cmbTypeElement.TypeSelectionne );
				if ( objet != null )
					m_objetTest = objet;
				return objet != null;
			}
			return false;
		}

		private void m_btnSelectElementTest_Click(object sender, System.EventArgs e)
		{
			SelectObjetTest();
		}

		private void m_cmbTypeElements_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( m_cmbTypeElement.TypeSelectionne != null)
			{
				m_wndAide.ObjetInterroge = m_cmbTypeElement.TypeSelectionne;
				m_txtFormule.Init(m_wndAide.FournisseurProprietes, m_wndAide.ObjetInterroge);
			}
		}

        private void m_lnkTest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            C2iExpression formule = m_txtFormule.Formule;
            if (formule == null)
                return;
            CArbreDefinitionsDynamiques arbre = new CArbreDefinitionsDynamiques(null);
            formule.GetArbreProprietesAccedees(arbre);

            string strChaine = "";
            foreach (CArbreDefinitionsDynamiques sa in arbre.SousArbres)
                AddToChaine(sa, 1, ref strChaine);
            Clipboard.SetDataObject(strChaine);
            MessageBox.Show(strChaine);
            int n = arbre.SousArbres.Length;
        }

        private void AddToChaine(CArbreDefinitionsDynamiques arbre, int nNiveau, ref string strChaine)
        {
            strChaine += "\r\n";
            for (int n = 0; n <= nNiveau; n++)
                strChaine += "\t";
            strChaine += arbre.DefinitionPropriete.NomPropriete;
            foreach (CArbreDefinitionsDynamiques sa in arbre.SousArbres)
                AddToChaine(sa, nNiveau + 1, ref strChaine);
        }
		//-------------------------------------------------------------------------
	}
}

