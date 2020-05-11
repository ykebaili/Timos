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
using timos.acteurs;
using sc2i.common.unites;

namespace timos
{
    [sc2i.win32.data.navigation.ObjectEditeur(typeof(CChampCustom))]
    public class CFormEditionChampCustom : CFormEditionStdTimos, IFormNavigable
    {
        private sc2i.win32.expression.CControleEditeFormule m_txtFormule = null;
        private string m_strLastCode = "";
        private Hashtable m_hashtableValeurs = new Hashtable();
        private System.Windows.Forms.Label label1;
        private C2iTextBox m_txtNom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private sc2i.win32.expression.CControleEditeFormule m_txtValeurDefaut;
        private sc2i.win32.common.C2iTextBox m_txtDescription;
        private sc2i.win32.common.C2iComboBox m_cmbType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.DataGrid m_gridValeursChampsCustom;
        private System.ComponentModel.IContainer components = null;

        private const string c_strColValeur = "ValChampCustom";
        private const string c_strColIndex = "Ind";
        private const string c_strColValeurAffichee = "Valeur affichée";
        private System.Windows.Forms.Label label6;
        private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre1;
        private sc2i.win32.common.CComboboxAutoFilled m_cmbRoleChamp;
        private System.Windows.Forms.Panel m_panelFond;
        private System.Windows.Forms.Panel m_panelDonnees;
        private sc2i.win32.expression.CControlAideFormule m_wndAide;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private sc2i.win32.common.C2iTextBox m_txtTexteErreur;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox m_txtTest;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button m_btnTest;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label3;
        private sc2i.win32.common.C2iTextBox c2iTextBox1;
        private System.Windows.Forms.Label label12;
        private sc2i.win32.common.C2iTextBox c2iTextBox2;
        private sc2i.win32.common.C2iTabControl m_tabControl;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private Crownwood.Magic.Controls.TabPage tabPage2;
        private sc2i.win32.common.ListViewAutoFilled m_wndListeReadOnly;
        private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn1;
        private sc2i.win32.common.ListViewAutoFilled m_wndListeMasquer;
        private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn2;
        private sc2i.win32.expression.CControleEditeFormule m_txtFormuleValidation;
        private Panel m_panelConteneurParametresChamp;
        private Panel m_panelParamClassiques;
        private sc2i.win32.data.dynamic.CPanelEditFiltreDynamique m_panelFiltre;
        private Panel m_panelPourObjetDonnee;
        private Label label16;
        private C2iTextBox c2iTextBox3;
        private Label label8;
        private C2iComboBox m_cmbCategorie;
        private LinkLabel m_lnkSousRoles;
        private ContextMenuStrip m_menuAutresUtilisations;
        private Panel m_panelUnite;
        private Label label14;
        private Label label15;
        private CComboboxAutoFilled m_cmbSelectClasseUnite;
        private C2iTextBox m_txtFormatUnite;
        private const string c_strColValeurStockee = "Valeur stockée";

        //-------------------------------------------------------------------------
        public CFormEditionChampCustom()
            : base()
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }
        //-------------------------------------------------------------------------
        public CFormEditionChampCustom(CChampCustom champCustom)
            : base(champCustom)
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }
        //-------------------------------------------------------------------------
        public CFormEditionChampCustom(CChampCustom champCustom, CListeObjetsDonnees liste)
            : base(champCustom, liste)
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }
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
        //-------------------------------------------------------------------------
        #region Designer generated code
        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionChampCustom));
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtNom = new sc2i.win32.common.C2iTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtValeurDefaut = new sc2i.win32.expression.CControleEditeFormule();
            this.m_txtDescription = new sc2i.win32.common.C2iTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_cmbType = new sc2i.win32.common.C2iComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.m_gridValeursChampsCustom = new System.Windows.Forms.DataGrid();
            this.label6 = new System.Windows.Forms.Label();
            this.c2iPanelOmbre1 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_cmbCategorie = new sc2i.win32.common.C2iComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.c2iTextBox2 = new sc2i.win32.common.C2iTextBox();
            this.m_lnkSousRoles = new System.Windows.Forms.LinkLabel();
            this.c2iTextBox1 = new sc2i.win32.common.C2iTextBox();
            this.m_cmbRoleChamp = new sc2i.win32.common.CComboboxAutoFilled();
            this.label12 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.m_panelFond = new System.Windows.Forms.Panel();
            this.m_panelDonnees = new System.Windows.Forms.Panel();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.m_panelConteneurParametresChamp = new System.Windows.Forms.Panel();
            this.m_panelPourObjetDonnee = new System.Windows.Forms.Panel();
            this.c2iTextBox3 = new sc2i.win32.common.C2iTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.m_panelFiltre = new sc2i.win32.data.dynamic.CPanelEditFiltreDynamique();
            this.m_panelParamClassiques = new System.Windows.Forms.Panel();
            this.m_panelUnite = new System.Windows.Forms.Panel();
            this.m_txtFormatUnite = new sc2i.win32.common.C2iTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.m_cmbSelectClasseUnite = new sc2i.win32.common.CComboboxAutoFilled();
            this.label14 = new System.Windows.Forms.Label();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.m_btnTest = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.m_txtFormuleValidation = new sc2i.win32.expression.CControleEditeFormule();
            this.label9 = new System.Windows.Forms.Label();
            this.m_txtTest = new System.Windows.Forms.TextBox();
            this.m_txtTexteErreur = new sc2i.win32.common.C2iTextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_wndAide = new sc2i.win32.expression.CControlAideFormule();
            this.m_wndListeMasquer = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn2 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_wndListeReadOnly = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_menuAutresUtilisations = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_gridValeursChampsCustom)).BeginInit();
            this.c2iPanelOmbre1.SuspendLayout();
            this.m_panelFond.SuspendLayout();
            this.m_panelDonnees.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.m_panelConteneurParametresChamp.SuspendLayout();
            this.m_panelPourObjetDonnee.SuspendLayout();
            this.m_panelParamClassiques.SuspendLayout();
            this.m_panelUnite.SuspendLayout();
            this.tabPage2.SuspendLayout();
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
            this.label1.Location = new System.Drawing.Point(6, 11);
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
            this.m_txtNom.Size = new System.Drawing.Size(439, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtNom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtNom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtNom.TabIndex = 0;
            this.m_txtNom.Text = "[Nom]";
            // 
            // label2
            // 
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label2, false);
            this.label2.Location = new System.Drawing.Point(3, 27);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 9;
            this.label2.Text = "Default value|900";
            // 
            // m_txtValeurDefaut
            // 
            this.m_txtValeurDefaut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtValeurDefaut.BackColor = System.Drawing.Color.White;
            this.m_txtValeurDefaut.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtValeurDefaut.Formule = null;
            this.m_extLinkField.SetLinkField(this.m_txtValeurDefaut, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtValeurDefaut, false);
            this.m_txtValeurDefaut.Location = new System.Drawing.Point(118, 27);
            this.m_txtValeurDefaut.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtValeurDefaut, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtValeurDefaut, "");
            this.m_txtValeurDefaut.Name = "m_txtValeurDefaut";
            this.m_txtValeurDefaut.Size = new System.Drawing.Size(457, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtValeurDefaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtValeurDefaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtValeurDefaut.TabIndex = 3;
            this.m_txtValeurDefaut.Enter += new System.EventHandler(this.TxtFormule_Enter);
            // 
            // m_txtDescription
            // 
            this.m_txtDescription.AcceptsReturn = true;
            this.m_txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtDescription.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtDescription, "Description");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtDescription, true);
            this.m_txtDescription.Location = new System.Drawing.Point(88, 102);
            this.m_txtDescription.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtDescription, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtDescription, "");
            this.m_txtDescription.Multiline = true;
            this.m_txtDescription.Name = "m_txtDescription";
            this.m_txtDescription.Size = new System.Drawing.Size(464, 39);
            this.m_extStyle.SetStyleBackColor(this.m_txtDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtDescription.TabIndex = 4;
            this.m_txtDescription.Text = "[Description]";
            // 
            // label4
            // 
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label4, false);
            this.label4.Location = new System.Drawing.Point(9, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 12;
            this.label4.Text = "Type|54";
            // 
            // m_cmbType
            // 
            this.m_cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbType.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbType, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbType, false);
            this.m_cmbType.Location = new System.Drawing.Point(88, 3);
            this.m_cmbType.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbType, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbType, "");
            this.m_cmbType.Name = "m_cmbType";
            this.m_cmbType.Size = new System.Drawing.Size(216, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbType, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbType, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbType.TabIndex = 0;
            this.m_cmbType.SelectionChangeCommitted += new System.EventHandler(this.m_cmbType_SelectedValueChanged);
            // 
            // label5
            // 
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label5, false);
            this.label5.Location = new System.Drawing.Point(3, 5);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 19);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 16;
            this.label5.Text = "Precision|899";
            // 
            // numericUpDown1
            // 
            this.m_extLinkField.SetLinkField(this.numericUpDown1, "Precision");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.numericUpDown1, true);
            this.numericUpDown1.Location = new System.Drawing.Point(118, 3);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.m_gestionnaireModeEdition.SetModeEdition(this.numericUpDown1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.numericUpDown1, "");
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(40, 21);
            this.m_extStyle.SetStyleBackColor(this.numericUpDown1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.numericUpDown1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // m_gridValeursChampsCustom
            // 
            this.m_gridValeursChampsCustom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_gridValeursChampsCustom.BackgroundColor = System.Drawing.Color.White;
            this.m_gridValeursChampsCustom.CaptionVisible = false;
            this.m_gridValeursChampsCustom.DataMember = "";
            this.m_gridValeursChampsCustom.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.m_extLinkField.SetLinkField(this.m_gridValeursChampsCustom, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_gridValeursChampsCustom, false);
            this.m_gridValeursChampsCustom.Location = new System.Drawing.Point(3, 65);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_gridValeursChampsCustom, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_gridValeursChampsCustom, "");
            this.m_gridValeursChampsCustom.Name = "m_gridValeursChampsCustom";
            this.m_gridValeursChampsCustom.PreferredRowHeight = 20;
            this.m_gridValeursChampsCustom.RowHeadersVisible = false;
            this.m_gridValeursChampsCustom.Size = new System.Drawing.Size(492, 30);
            this.m_extStyle.SetStyleBackColor(this.m_gridValeursChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_gridValeursChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_gridValeursChampsCustom.TabIndex = 5;
            // 
            // label6
            // 
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label6, false);
            this.label6.Location = new System.Drawing.Point(6, 147);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label6, "");
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 23);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 4001;
            this.label6.Text = "Purpose|898";
            // 
            // c2iPanelOmbre1
            // 
            this.c2iPanelOmbre1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iPanelOmbre1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre1.Controls.Add(this.m_cmbCategorie);
            this.c2iPanelOmbre1.Controls.Add(this.label8);
            this.c2iPanelOmbre1.Controls.Add(this.c2iTextBox2);
            this.c2iPanelOmbre1.Controls.Add(this.m_lnkSousRoles);
            this.c2iPanelOmbre1.Controls.Add(this.c2iTextBox1);
            this.c2iPanelOmbre1.Controls.Add(this.m_cmbRoleChamp);
            this.c2iPanelOmbre1.Controls.Add(this.label12);
            this.c2iPanelOmbre1.Controls.Add(this.m_txtNom);
            this.c2iPanelOmbre1.Controls.Add(this.label3);
            this.c2iPanelOmbre1.Controls.Add(this.m_txtDescription);
            this.c2iPanelOmbre1.Controls.Add(this.label1);
            this.c2iPanelOmbre1.Controls.Add(this.label6);
            this.c2iPanelOmbre1.Controls.Add(this.label13);
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iPanelOmbre1, false);
            this.c2iPanelOmbre1.Location = new System.Drawing.Point(8, 8);
            this.c2iPanelOmbre1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre1, "");
            this.c2iPanelOmbre1.Name = "c2iPanelOmbre1";
            this.c2iPanelOmbre1.Size = new System.Drawing.Size(584, 184);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iPanelOmbre1.TabIndex = 0;
            // 
            // m_cmbCategorie
            // 
            this.m_cmbCategorie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbCategorie.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbCategorie, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbCategorie, false);
            this.m_cmbCategorie.Location = new System.Drawing.Point(88, 80);
            this.m_cmbCategorie.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbCategorie, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbCategorie, "");
            this.m_cmbCategorie.Name = "m_cmbCategorie";
            this.m_cmbCategorie.Size = new System.Drawing.Size(216, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbCategorie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbCategorie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbCategorie.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label8, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label8, false);
            this.label8.Location = new System.Drawing.Point(6, 83);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label8, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label8, "");
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.m_extStyle.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 4007;
            this.label8.Text = "Folder|20043";
            // 
            // c2iTextBox2
            // 
            this.c2iTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iTextBox2.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.c2iTextBox2, "LibelleCourt");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iTextBox2, true);
            this.c2iTextBox2.Location = new System.Drawing.Point(88, 56);
            this.c2iTextBox2.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox2, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBox2, "");
            this.c2iTextBox2.Name = "c2iTextBox2";
            this.c2iTextBox2.Size = new System.Drawing.Size(320, 20);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox2.TabIndex = 2;
            this.c2iTextBox2.Text = "[LibelleCourt]";
            // 
            // m_lnkSousRoles
            // 
            this.m_lnkSousRoles.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lnkSousRoles, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkSousRoles, false);
            this.m_lnkSousRoles.Location = new System.Drawing.Point(346, 147);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkSousRoles, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkSousRoles, "");
            this.m_lnkSousRoles.Name = "m_lnkSousRoles";
            this.m_lnkSousRoles.Size = new System.Drawing.Size(104, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSousRoles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSousRoles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSousRoles.TabIndex = 4008;
            this.m_lnkSousRoles.TabStop = true;
            this.m_lnkSousRoles.Text = "Sub purposes|20586";
            this.m_lnkSousRoles.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkSousRoles_LinkClicked);
            // 
            // c2iTextBox1
            // 
            this.c2iTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iTextBox1.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.c2iTextBox1, "LibelleConvivial");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iTextBox1, true);
            this.c2iTextBox1.Location = new System.Drawing.Point(88, 32);
            this.c2iTextBox1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBox1, "");
            this.c2iTextBox1.Name = "c2iTextBox1";
            this.c2iTextBox1.Size = new System.Drawing.Size(464, 20);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox1.TabIndex = 1;
            this.c2iTextBox1.Text = "[LibelleConvivial]";
            // 
            // m_cmbRoleChamp
            // 
            this.m_cmbRoleChamp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbRoleChamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbRoleChamp.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbRoleChamp, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbRoleChamp, false);
            this.m_cmbRoleChamp.ListDonnees = null;
            this.m_cmbRoleChamp.Location = new System.Drawing.Point(88, 144);
            this.m_cmbRoleChamp.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbRoleChamp, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbRoleChamp, "");
            this.m_cmbRoleChamp.Name = "m_cmbRoleChamp";
            this.m_cmbRoleChamp.NullAutorise = false;
            this.m_cmbRoleChamp.ProprieteAffichee = "Libelle";
            this.m_cmbRoleChamp.Size = new System.Drawing.Size(252, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbRoleChamp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbRoleChamp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbRoleChamp.TabIndex = 5;
            this.m_cmbRoleChamp.TextNull = "(empty)";
            this.m_cmbRoleChamp.Tri = true;
            this.m_cmbRoleChamp.SelectedValueChanged += new System.EventHandler(this.m_cmbRoleChamp_SelectedValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label12, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label12, false);
            this.label12.Location = new System.Drawing.Point(6, 59);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label12, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label12, "");
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 13);
            this.m_extStyle.SetStyleBackColor(this.label12, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label12, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label12.TabIndex = 4005;
            this.label12.Text = "Short label|897";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label3, false);
            this.label3.Location = new System.Drawing.Point(6, 35);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4003;
            this.label3.Text = "Long label|896";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label13, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label13, false);
            this.label13.Location = new System.Drawing.Point(7, 105);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label13, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label13, "");
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 13);
            this.m_extStyle.SetStyleBackColor(this.label13, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label13, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label13.TabIndex = 11;
            this.label13.Text = "Description|655";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label7, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label7, false);
            this.label7.Location = new System.Drawing.Point(1, 50);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label7, "");
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(169, 12);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 17;
            this.label7.Text = "Possible values|1262";
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
            this.m_panelFond.Size = new System.Drawing.Size(814, 482);
            this.m_extStyle.SetStyleBackColor(this.m_panelFond, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelFond, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelFond.TabIndex = 4001;
            // 
            // m_panelDonnees
            // 
            this.m_panelDonnees.Controls.Add(this.m_tabControl);
            this.m_panelDonnees.Controls.Add(this.c2iPanelOmbre1);
            this.m_panelDonnees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelDonnees, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelDonnees, false);
            this.m_panelDonnees.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelDonnees, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelDonnees, "");
            this.m_panelDonnees.Name = "m_panelDonnees";
            this.m_panelDonnees.Size = new System.Drawing.Size(613, 482);
            this.m_extStyle.SetStyleBackColor(this.m_panelDonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelDonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelDonnees.TabIndex = 2;
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
            this.m_extLinkField.SetLinkField(this.m_tabControl, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_tabControl, false);
            this.m_tabControl.Location = new System.Drawing.Point(8, 198);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.tabPage1;
            this.m_tabControl.Size = new System.Drawing.Size(600, 284);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4004;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_panelConteneurParametresChamp);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.m_cmbType);
            this.m_extLinkField.SetLinkField(this.tabPage1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.tabPage1, false);
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tabPage1, "");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(584, 243);
            this.m_extStyle.SetStyleBackColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage1.TabIndex = 10;
            this.tabPage1.Title = "Type|54";
            // 
            // m_panelConteneurParametresChamp
            // 
            this.m_panelConteneurParametresChamp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelConteneurParametresChamp.Controls.Add(this.m_panelPourObjetDonnee);
            this.m_panelConteneurParametresChamp.Controls.Add(this.m_panelParamClassiques);
            this.m_extLinkField.SetLinkField(this.m_panelConteneurParametresChamp, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelConteneurParametresChamp, false);
            this.m_panelConteneurParametresChamp.Location = new System.Drawing.Point(3, 35);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelConteneurParametresChamp, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelConteneurParametresChamp, "");
            this.m_panelConteneurParametresChamp.Name = "m_panelConteneurParametresChamp";
            this.m_panelConteneurParametresChamp.Size = new System.Drawing.Size(578, 192);
            this.m_extStyle.SetStyleBackColor(this.m_panelConteneurParametresChamp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelConteneurParametresChamp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelConteneurParametresChamp.TabIndex = 18;
            // 
            // m_panelPourObjetDonnee
            // 
            this.m_panelPourObjetDonnee.Controls.Add(this.c2iTextBox3);
            this.m_panelPourObjetDonnee.Controls.Add(this.label16);
            this.m_panelPourObjetDonnee.Controls.Add(this.m_panelFiltre);
            this.m_extLinkField.SetLinkField(this.m_panelPourObjetDonnee, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelPourObjetDonnee, false);
            this.m_panelPourObjetDonnee.Location = new System.Drawing.Point(103, 117);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelPourObjetDonnee, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelPourObjetDonnee, "");
            this.m_panelPourObjetDonnee.Name = "m_panelPourObjetDonnee";
            this.m_panelPourObjetDonnee.Size = new System.Drawing.Size(407, 141);
            this.m_extStyle.SetStyleBackColor(this.m_panelPourObjetDonnee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelPourObjetDonnee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelPourObjetDonnee.TabIndex = 19;
            // 
            // c2iTextBox3
            // 
            this.c2iTextBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iTextBox3.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.c2iTextBox3, "LibellePourObjetParent");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iTextBox3, true);
            this.c2iTextBox3.Location = new System.Drawing.Point(111, 1);
            this.c2iTextBox3.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox3, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBox3, "");
            this.c2iTextBox3.Name = "c2iTextBox3";
            this.c2iTextBox3.Size = new System.Drawing.Size(284, 21);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox3.TabIndex = 3;
            this.c2iTextBox3.Text = "[LibellePourObjetParent]";
            // 
            // label16
            // 
            this.m_extLinkField.SetLinkField(this.label16, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label16, false);
            this.label16.Location = new System.Drawing.Point(3, 4);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label16, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label16, "");
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(129, 18);
            this.m_extStyle.SetStyleBackColor(this.label16, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label16, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label16.TabIndex = 2;
            this.label16.Text = "Label for parent|312";
            // 
            // m_panelFiltre
            // 
            this.m_panelFiltre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelFiltre.BackColor = System.Drawing.Color.White;
            this.m_panelFiltre.DefinitionRacineDeChampsFiltres = null;
            this.m_panelFiltre.FiltreDynamique = null;
            this.m_extLinkField.SetLinkField(this.m_panelFiltre, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelFiltre, false);
            this.m_panelFiltre.Location = new System.Drawing.Point(0, 25);
            this.m_panelFiltre.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelFiltre, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelFiltre.ModeFiltreExpression = false;
            this.m_panelFiltre.ModeSansType = false;
            this.m_extModulesAssociator.SetModules(this.m_panelFiltre, "");
            this.m_panelFiltre.Name = "m_panelFiltre";
            this.m_panelFiltre.Size = new System.Drawing.Size(407, 166);
            this.m_extStyle.SetStyleBackColor(this.m_panelFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelFiltre.TabIndex = 1;
            this.m_panelFiltre.OnChangeTypeElements += new sc2i.win32.data.dynamic.ChangeTypeElementsEventHandler(this.m_panelFiltre_OnChangeTypeElements);
            // 
            // m_panelParamClassiques
            // 
            this.m_panelParamClassiques.Controls.Add(this.m_panelUnite);
            this.m_panelParamClassiques.Controls.Add(this.m_txtValeurDefaut);
            this.m_panelParamClassiques.Controls.Add(this.label7);
            this.m_panelParamClassiques.Controls.Add(this.label5);
            this.m_panelParamClassiques.Controls.Add(this.m_gridValeursChampsCustom);
            this.m_panelParamClassiques.Controls.Add(this.numericUpDown1);
            this.m_panelParamClassiques.Controls.Add(this.label2);
            this.m_extLinkField.SetLinkField(this.m_panelParamClassiques, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelParamClassiques, false);
            this.m_panelParamClassiques.Location = new System.Drawing.Point(3, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelParamClassiques, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelParamClassiques, "");
            this.m_panelParamClassiques.Name = "m_panelParamClassiques";
            this.m_panelParamClassiques.Size = new System.Drawing.Size(588, 98);
            this.m_extStyle.SetStyleBackColor(this.m_panelParamClassiques, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelParamClassiques, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelParamClassiques.TabIndex = 0;
            // 
            // m_panelUnite
            // 
            this.m_panelUnite.Controls.Add(this.m_txtFormatUnite);
            this.m_panelUnite.Controls.Add(this.label15);
            this.m_panelUnite.Controls.Add(this.m_cmbSelectClasseUnite);
            this.m_panelUnite.Controls.Add(this.label14);
            this.m_extLinkField.SetLinkField(this.m_panelUnite, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelUnite, false);
            this.m_panelUnite.Location = new System.Drawing.Point(165, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelUnite, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelUnite, "");
            this.m_panelUnite.Name = "m_panelUnite";
            this.m_panelUnite.Size = new System.Drawing.Size(407, 21);
            this.m_extStyle.SetStyleBackColor(this.m_panelUnite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelUnite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelUnite.TabIndex = 18;
            // 
            // m_txtFormatUnite
            // 
            this.m_txtFormatUnite.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtFormatUnite, "FormatAffichageUnite");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtFormatUnite, true);
            this.m_txtFormatUnite.Location = new System.Drawing.Point(312, 0);
            this.m_txtFormatUnite.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtFormatUnite, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_txtFormatUnite, "");
            this.m_txtFormatUnite.Name = "m_txtFormatUnite";
            this.m_txtFormatUnite.Size = new System.Drawing.Size(92, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtFormatUnite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFormatUnite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormatUnite.TabIndex = 22;
            this.m_txtFormatUnite.Text = "[FormatAffichageUnite]";
            // 
            // label15
            // 
            this.m_extLinkField.SetLinkField(this.label15, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label15, false);
            this.label15.Location = new System.Drawing.Point(216, 2);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label15, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label15, "");
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 19);
            this.m_extStyle.SetStyleBackColor(this.label15, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label15, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label15.TabIndex = 21;
            this.label15.Text = "Display format|20588";
            // 
            // m_cmbSelectClasseUnite
            // 
            this.m_cmbSelectClasseUnite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbSelectClasseUnite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbSelectClasseUnite.FormattingEnabled = true;
            this.m_cmbSelectClasseUnite.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbSelectClasseUnite, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbSelectClasseUnite, false);
            this.m_cmbSelectClasseUnite.ListDonnees = null;
            this.m_cmbSelectClasseUnite.Location = new System.Drawing.Point(93, 0);
            this.m_cmbSelectClasseUnite.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbSelectClasseUnite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbSelectClasseUnite, "");
            this.m_cmbSelectClasseUnite.Name = "m_cmbSelectClasseUnite";
            this.m_cmbSelectClasseUnite.NullAutorise = true;
            this.m_cmbSelectClasseUnite.ProprieteAffichee = null;
            this.m_cmbSelectClasseUnite.Size = new System.Drawing.Size(121, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbSelectClasseUnite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbSelectClasseUnite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbSelectClasseUnite.TabIndex = 20;
            this.m_cmbSelectClasseUnite.TextNull = "(empty)";
            this.m_cmbSelectClasseUnite.Tri = true;
            // 
            // label14
            // 
            this.m_extLinkField.SetLinkField(this.label14, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label14, false);
            this.label14.Location = new System.Drawing.Point(3, 2);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label14, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label14, "");
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 19);
            this.m_extStyle.SetStyleBackColor(this.label14, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label14, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label14.TabIndex = 19;
            this.label14.Text = "Unit type|20587";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.m_btnTest);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.m_txtFormuleValidation);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.m_txtTest);
            this.tabPage2.Controls.Add(this.m_txtTexteErreur);
            this.m_extLinkField.SetLinkField(this.tabPage2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.tabPage2, false);
            this.tabPage2.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tabPage2, "");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(584, 243);
            this.m_extStyle.SetStyleBackColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage2.TabIndex = 11;
            this.tabPage2.Title = "Validation|16";
            // 
            // m_btnTest
            // 
            this.m_btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnTest.BackColor = System.Drawing.SystemColors.Control;
            this.m_extLinkField.SetLinkField(this.m_btnTest, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnTest, false);
            this.m_btnTest.Location = new System.Drawing.Point(392, 212);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnTest, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnTest, "");
            this.m_btnTest.Name = "m_btnTest";
            this.m_btnTest.Size = new System.Drawing.Size(73, 21);
            this.m_extStyle.SetStyleBackColor(this.m_btnTest, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnTest, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnTest.TabIndex = 10;
            this.m_btnTest.Text = "Test|895";
            this.m_btnTest.UseVisualStyleBackColor = false;
            this.m_btnTest.Click += new System.EventHandler(this.m_btnTest_Click);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_extLinkField.SetLinkField(this.label10, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label10, false);
            this.label10.Location = new System.Drawing.Point(15, 137);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label10, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label10, "");
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 16);
            this.m_extStyle.SetStyleBackColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label10.TabIndex = 6;
            this.label10.Text = "Error message|902";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_extLinkField.SetLinkField(this.label11, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label11, false);
            this.label11.Location = new System.Drawing.Point(15, 215);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label11, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label11, "");
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 16);
            this.m_extStyle.SetStyleBackColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label11.TabIndex = 9;
            this.label11.Text = "Test|895";
            // 
            // m_txtFormuleValidation
            // 
            this.m_txtFormuleValidation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormuleValidation.BackColor = System.Drawing.Color.White;
            this.m_txtFormuleValidation.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtFormuleValidation.Formule = null;
            this.m_extLinkField.SetLinkField(this.m_txtFormuleValidation, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtFormuleValidation, false);
            this.m_txtFormuleValidation.Location = new System.Drawing.Point(16, 28);
            this.m_txtFormuleValidation.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtFormuleValidation, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtFormuleValidation, "");
            this.m_txtFormuleValidation.Name = "m_txtFormuleValidation";
            this.m_txtFormuleValidation.Size = new System.Drawing.Size(560, 93);
            this.m_extStyle.SetStyleBackColor(this.m_txtFormuleValidation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFormuleValidation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleValidation.TabIndex = 5;
            this.m_txtFormuleValidation.Enter += new System.EventHandler(this.TxtFormule_Enter);
            // 
            // label9
            // 
            this.m_extLinkField.SetLinkField(this.label9, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label9, false);
            this.label9.Location = new System.Drawing.Point(16, 9);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label9, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label9, "");
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(140, 16);
            this.m_extStyle.SetStyleBackColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label9.TabIndex = 4;
            this.label9.Text = "Validation formula|901";
            // 
            // m_txtTest
            // 
            this.m_txtTest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_txtTest, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtTest, false);
            this.m_txtTest.Location = new System.Drawing.Point(80, 212);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtTest, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtTest, "");
            this.m_txtTest.Name = "m_txtTest";
            this.m_txtTest.Size = new System.Drawing.Size(304, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtTest, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtTest, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtTest.TabIndex = 8;
            // 
            // m_txtTexteErreur
            // 
            this.m_txtTexteErreur.AcceptsReturn = true;
            this.m_txtTexteErreur.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtTexteErreur.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtTexteErreur, "TexteErreurFormat");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtTexteErreur, true);
            this.m_txtTexteErreur.Location = new System.Drawing.Point(16, 156);
            this.m_txtTexteErreur.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtTexteErreur, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtTexteErreur, "");
            this.m_txtTexteErreur.Multiline = true;
            this.m_txtTexteErreur.Name = "m_txtTexteErreur";
            this.m_txtTexteErreur.Size = new System.Drawing.Size(449, 48);
            this.m_extStyle.SetStyleBackColor(this.m_txtTexteErreur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtTexteErreur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtTexteErreur.TabIndex = 7;
            this.m_txtTexteErreur.Text = "[TexteErreurFormat]";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_extLinkField.SetLinkField(this.splitter1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.splitter1, false);
            this.splitter1.Location = new System.Drawing.Point(613, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitter1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitter1, "");
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1, 482);
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
            this.m_wndAide.Location = new System.Drawing.Point(614, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndAide, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndAide, "");
            this.m_wndAide.Name = "m_wndAide";
            this.m_wndAide.ObjetInterroge = null;
            this.m_wndAide.SendIdChamps = false;
            this.m_wndAide.Size = new System.Drawing.Size(200, 482);
            this.m_extStyle.SetStyleBackColor(this.m_wndAide, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndAide, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndAide.TabIndex = 3;
            this.m_wndAide.OnSendCommande += new sc2i.win32.expression.SendCommande(this.m_wndAide_OnSendCommande);
            // 
            // m_wndListeMasquer
            // 
            this.m_wndListeMasquer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_wndListeMasquer.CheckBoxes = true;
            this.m_wndListeMasquer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn2});
            this.m_wndListeMasquer.EnableCustomisation = true;
            this.m_wndListeMasquer.FullRowSelect = true;
            this.m_wndListeMasquer.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_extLinkField.SetLinkField(this.m_wndListeMasquer, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_wndListeMasquer, false);
            this.m_wndListeMasquer.Location = new System.Drawing.Point(272, 24);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeMasquer, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_wndListeMasquer, "");
            this.m_wndListeMasquer.MultiSelect = false;
            this.m_wndListeMasquer.Name = "m_wndListeMasquer";
            this.m_wndListeMasquer.Size = new System.Drawing.Size(216, 212);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeMasquer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeMasquer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeMasquer.TabIndex = 3;
            this.m_wndListeMasquer.UseCompatibleStateImageBehavior = false;
            this.m_wndListeMasquer.View = System.Windows.Forms.View.Details;
            // 
            // listViewAutoFilledColumn2
            // 
            this.listViewAutoFilledColumn2.Field = "Libelle";
            this.listViewAutoFilledColumn2.PrecisionWidth = 0;
            this.listViewAutoFilledColumn2.ProportionnalSize = false;
            this.listViewAutoFilledColumn2.Text = "Label|50";
            this.listViewAutoFilledColumn2.Visible = true;
            this.listViewAutoFilledColumn2.Width = 200;
            // 
            // m_wndListeReadOnly
            // 
            this.m_wndListeReadOnly.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_wndListeReadOnly.CheckBoxes = true;
            this.m_wndListeReadOnly.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn1});
            this.m_wndListeReadOnly.EnableCustomisation = true;
            this.m_wndListeReadOnly.FullRowSelect = true;
            this.m_wndListeReadOnly.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_extLinkField.SetLinkField(this.m_wndListeReadOnly, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_wndListeReadOnly, false);
            this.m_wndListeReadOnly.Location = new System.Drawing.Point(8, 24);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeReadOnly, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_wndListeReadOnly, "");
            this.m_wndListeReadOnly.MultiSelect = false;
            this.m_wndListeReadOnly.Name = "m_wndListeReadOnly";
            this.m_wndListeReadOnly.Size = new System.Drawing.Size(216, 212);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeReadOnly, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeReadOnly, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeReadOnly.TabIndex = 2;
            this.m_wndListeReadOnly.UseCompatibleStateImageBehavior = false;
            this.m_wndListeReadOnly.View = System.Windows.Forms.View.Details;
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "Libelle";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Label|50";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 200;
            // 
            // m_menuAutresUtilisations
            // 
            this.m_extLinkField.SetLinkField(this.m_menuAutresUtilisations, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_menuAutresUtilisations, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_menuAutresUtilisations, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_menuAutresUtilisations, "");
            this.m_menuAutresUtilisations.Name = "m_menuAutresUtilisations";
            this.m_menuAutresUtilisations.Size = new System.Drawing.Size(153, 26);
            this.m_extStyle.SetStyleBackColor(this.m_menuAutresUtilisations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_menuAutresUtilisations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // CFormEditionChampCustom
            // 
            this.AffectationsPourNouvelElement = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("$this.AffectationsPourNouvelElement")));
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.m_panelFond);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionChampCustom";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_tabControl;
            this.Load += new System.EventHandler(this.CFormEditionChampCustom_Load);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.m_panelFond, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_gridValeursChampsCustom)).EndInit();
            this.c2iPanelOmbre1.ResumeLayout(false);
            this.c2iPanelOmbre1.PerformLayout();
            this.m_panelFond.ResumeLayout(false);
            this.m_panelDonnees.ResumeLayout(false);
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.m_panelConteneurParametresChamp.ResumeLayout(false);
            this.m_panelPourObjetDonnee.ResumeLayout(false);
            this.m_panelPourObjetDonnee.PerformLayout();
            this.m_panelParamClassiques.ResumeLayout(false);
            this.m_panelUnite.ResumeLayout(false);
            this.m_panelUnite.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        //-------------------------------------------------------------------------
        private void InitPanel()
        {
            CChampCustom champ = (CChampCustom)ObjetEdite;

            IList liste = champ.ListeValeurs;

            DataTable table = new DataTable(CValeurChampCustom.c_nomTable);
            table.Columns.Add(c_strColValeur, typeof(CValeurChampCustom));
            table.Columns.Add(c_strColIndex, typeof(int));
            table.Columns.Add(c_strColValeurStockee, typeof(string));
            table.Columns.Add(c_strColValeurAffichee, typeof(string));

            m_hashtableValeurs.Clear();
            foreach (object obj in liste)
            {
                CValeurChampCustom val = (CValeurChampCustom)obj;
                DataRow row = table.NewRow();
                row[c_strColValeur] = val;
                row[c_strColIndex] = val.Index;
                row[c_strColValeurStockee] = val.Value;
                row[c_strColValeurAffichee] = val.Display;

                m_hashtableValeurs[val] = val;
                table.Rows.Add(row);
            }

            if (m_gridValeursChampsCustom.TableStyles[CValeurChampCustom.c_nomTable] == null)
            {
                DataGridTableStyle tableStyle = new DataGridTableStyle();
                tableStyle.MappingName = CValeurChampCustom.c_nomTable;

                DataGridTextBoxColumn colStyleIndex = new DataGridTextBoxColumn();
                colStyleIndex.MappingName = c_strColIndex;
                colStyleIndex.HeaderText = I.T("Index|20491");
                colStyleIndex.Width = 40;
                colStyleIndex.ReadOnly = false;

                DataGridTextBoxColumn colStyleValue = new DataGridTextBoxColumn();
                colStyleValue.MappingName = c_strColValeurStockee;
                colStyleValue.HeaderText = I.T("Stored value|20492");
                colStyleValue.Width = m_gridValeursChampsCustom.Width * 1 / 3;
                colStyleValue.ReadOnly = false;

                DataGridTextBoxColumn colStyleDisplay = new DataGridTextBoxColumn();
                colStyleDisplay.MappingName = c_strColValeurAffichee;
                colStyleDisplay.HeaderText = I.T("Displayed value|20493");
                colStyleDisplay.Width = m_gridValeursChampsCustom.Width * 1 / 3;
                colStyleDisplay.ReadOnly = false;

                tableStyle.RowHeadersVisible = true;

                tableStyle.GridColumnStyles.AddRange(new DataGridColumnStyle[] { colStyleIndex, colStyleValue, colStyleDisplay });

                m_gridValeursChampsCustom.TableStyles.Add(tableStyle);
            }

            table.DefaultView.AllowNew = true;
            table.DefaultView.AllowDelete = true;

            m_gridValeursChampsCustom.DataSource = table;
            m_gridValeursChampsCustom.ReadOnly = !EtatEdition;

            this.AfterPassageEnEdition += new ObjetDonneeEventHandler(AutoriseModifChampsCustom);
        }
        //-------------------------------------------------------------------------
        private void AutoriseModifChampsCustom(object sender, CObjetDonneeEventArgs e)
        {
            m_gridValeursChampsCustom.ReadOnly = !EtatEdition;
        }
        //-------------------------------------------------------------------------
        private void ValideModifValeursChampsCustom()
        {
            CChampCustom champ = (CChampCustom)ObjetEdite;

            Hashtable m_hashtableValeursDansGrid = new Hashtable();

            foreach (DataRow row in ((DataTable)m_gridValeursChampsCustom.DataSource).Rows)
            {
                if ((row[c_strColValeur] is System.DBNull))
                {
                    CValeurChampCustom val = new CValeurChampCustom(champ.ContexteDonnee);
                    val.CreateNewInCurrentContexte();
                    val.ChampCustom = champ;
                    try
                    {
                        val.Index = (int)row[c_strColIndex];
                    }
                    catch { }
                    val.Value = (string)row[c_strColValeurStockee];
                    val.Display = (string)row[c_strColValeurAffichee];
                    row[c_strColValeur] = val;
                }
                m_hashtableValeursDansGrid[(CValeurChampCustom)row[c_strColValeur]] = row;
            }

            foreach (CValeurChampCustom valeur in m_hashtableValeurs.Values)
            {
                if (!m_hashtableValeursDansGrid.ContainsKey(valeur))
                    valeur.Delete();
                else
                {
                    DataRow row = (DataRow)m_hashtableValeursDansGrid[valeur];
                    try
                    {
                        valeur.Index = (int)row[c_strColIndex];
                    }
                    catch { }
                    valeur.Value = (string)row[c_strColValeurStockee];
                    valeur.Display = (string)row[c_strColValeurAffichee];
                    valeur.ChampCustom = champ;
                }
            }
        }

        //-------------------------------------------------------------------------
        protected CChampCustom Champ
        {
            get
            {
                return (CChampCustom)ObjetEdite;
            }
        }

        //-------------------------------------------------------------------------
        protected override CResultAErreur MyInitChamps()
        {
            CResultAErreur result = base.MyInitChamps();
            if (Champ.CodeRole != "")
                m_strLastCode = Champ.CodeRole;
            else
                Champ.CodeRole = m_strLastCode;
            //if ( Champ.ValeurParDefaut == null )
            AffecterTitre(I.T("Custom field|30215") + " " + Champ.Nom);
            if (result)
            {
                InitPanel();
                m_cmbType.Items.Clear();
                m_cmbType.Items.AddRange(CChampCustom.TypePossibles);
                m_cmbType.SelectedItem = ((CChampCustom)ObjetEdite).TypeDonneeChamp;

                m_cmbRoleChamp.ListDonnees = CRoleChampCustom.Roles;
                m_cmbRoleChamp.SelectedValue = Champ.Role;
                m_txtFormuleValidation.Text = Champ.FormuleValidation.GetString();

                if (Champ.FormuleValeurParDefaut != null)
                    m_txtValeurDefaut.Text = Champ.FormuleValeurParDefaut.GetString();
                else
                    m_txtValeurDefaut.Text = "";

                m_cmbSelectClasseUnite.ListDonnees = CGestionnaireUnites.Classes;
                m_cmbSelectClasseUnite.ProprieteAffichee = "Libelle";
                m_cmbSelectClasseUnite.SelectedValue = Champ.ClasseUnite;
                
            }
            CFiltreDynamique filtre = Champ.FiltreObjetDonnee;
            if (filtre == null)
                filtre = new CFiltreDynamique(Champ.ContexteDonnee);

            CRoleChampCustom role = Champ.Role;
            if (role != null)
                CCreateur2iFormulaire.AssureVariableElementCible(filtre, role.TypeAssocie);
            m_panelFiltre.Init(filtre);


            CListeObjetsDonnees listeRestrictions = new CListeObjetsDonnees(Champ.ContexteDonnee, typeof(CRestrictionChampCustom));
            m_wndListeMasquer.Remplir(listeRestrictions);
            m_wndListeReadOnly.Remplir(listeRestrictions);

            foreach (ListViewItem item in m_wndListeMasquer.Items)
            {
                CRestrictionChampCustom rest = (CRestrictionChampCustom)item.Tag;
                if ((Champ.RestrictionsMasquer & (int)Math.Pow(2, rest.ValeurFlag)) != 0)
                    item.Checked = true;
                else
                    item.Checked = false;
            }

            foreach (ListViewItem item in m_wndListeReadOnly.Items)
            {
                CRestrictionChampCustom rest = (CRestrictionChampCustom)item.Tag;
                if ((Champ.RestrictionsReadOnly & (int)Math.Pow(2, rest.ValeurFlag)) != 0)
                    item.Checked = true;
                else
                    item.Checked = false;
            }

            UpdatePanelParametres();
            UpdatePrecision();
            UpdatePanelUnite();

            InitComboCategories();
            m_cmbCategorie.Text = Champ.Categorie;

            RefreshVisuSousRoles();

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
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();
            if (result)
            {
                ((CChampCustom)ObjetEdite).TypeDonneeChamp = (C2iTypeDonnee)m_cmbType.SelectedItem;
                Champ.Role = (CRoleChampCustom)m_cmbRoleChamp.SelectedValue;

                ValideModifValeursChampsCustom();



                try
                {
                    if (m_txtValeurDefaut.Text != "")
                    {
                        CContexteAnalyse2iExpression ctx = new CContexteAnalyse2iExpression(new CFournisseurPropDynStd(true), typeof(string));
                        CAnalyseurSyntaxiqueExpression analyseur = new CAnalyseurSyntaxiqueExpression(ctx);
                        result = analyseur.AnalyseChaine(m_txtValeurDefaut.Text);
                        if (!result)
                        {
                            result.EmpileErreur(I.T("Default value formula is incorrect|30216"));
                            return result;
                        }
                        Champ.FormuleValeurParDefaut = (C2iExpression)result.Data;
                    }
                    else
                        Champ.FormuleValeurParDefaut = null;
                }
                catch
                {
                    result.EmpileErreur(I.T("Incorrect default value|30217"));
                }
                int nRest = 0;
                foreach (ListViewItem item in m_wndListeReadOnly.Items)
                {
                    if (item.Checked)
                    {
                        CRestrictionChampCustom rest = (CRestrictionChampCustom)item.Tag;
                        nRest |= (int)Math.Pow(2, rest.ValeurFlag);
                    }
                }
                Champ.RestrictionsReadOnly = nRest;

                nRest = 0;
                foreach (ListViewItem item in m_wndListeMasquer.Items)
                {
                    if (item.Checked)
                    {
                        CRestrictionChampCustom rest = (CRestrictionChampCustom)item.Tag;
                        nRest |= (int)Math.Pow(2, rest.ValeurFlag);
                    }
                }
                Champ.RestrictionsMasquer = nRest;

                if (Champ.TypeDonneeChamp.TypeDonnee == TypeDonnee.tObjetDonneeAIdNumeriqueAuto)
                    Champ.FiltreObjetDonnee = m_panelFiltre.FiltreDynamique;
            }
            if (result)
                result = MAJ_FormuleInChamp();
            Champ.Categorie = m_cmbCategorie.Text;
            if (Champ.TypeDonneeChamp.TypeDonnee == TypeDonnee.tDouble)
            {
                Champ.ClasseUnite = m_cmbSelectClasseUnite.SelectedValue as IClasseUnite;
            }
            else
                Champ.ClasseUnite = null;
            return result;
        }

        //-------------------------------------------------------------------------
        private void UpdatePrecision()
        {
            if (m_cmbType.SelectedItem is C2iTypeDonnee)
            {
                C2iTypeDonnee type = (C2iTypeDonnee)m_cmbType.SelectedItem;
                switch (type.TypeDonnee)
                {
                    case TypeDonnee.tDouble:
                        numericUpDown1.Maximum = 10;
                        label5.Text = I.T("Precision|899");
                        numericUpDown1.Visible = true;
                        label5.Visible = true;
                        break;
                    case TypeDonnee.tString:
                        numericUpDown1.Maximum = 4000;
                        label5.Text = I.T("Max length|1399");
                        numericUpDown1.Visible = true;
                        label5.Visible = true;
                        break;
                    default:
                        numericUpDown1.Visible = false;
                        label5.Visible = false;
                        break;
                }
            }
        }

        //-------------------------------------------------------------------------
        private void UpdatePanelUnite()
        {
            C2iTypeDonnee typeDonnee = m_cmbType.SelectedItem as C2iTypeDonnee;
            if ( typeDonnee != null )
            {
                m_panelUnite.Visible = typeDonnee.TypeDonnee == TypeDonnee.tDouble;
            }
        }




        //-------------------------------------------------------------------------
        private void CFormEditionChampCustom_Load(object sender, System.EventArgs e)
        {
            m_wndAide.FournisseurProprietes = new CFournisseurPropDynStd(true);
            m_wndAide.ObjetInterroge = typeof(CObjetForTestValeurChampCustomString);
            m_txtFormuleValidation.Init(m_wndAide.FournisseurProprietes, m_wndAide.ObjetInterroge);
            m_txtValeurDefaut.Init(m_wndAide.FournisseurProprietes, m_wndAide.ObjetInterroge);
            TxtFormule_Enter(m_txtValeurDefaut, new EventArgs());

        }
        //-------------------------------------------------------------------------
        private void m_wndAide_OnSendCommande(string strCommande, int nPosCurseur)
        {
            m_wndAide.InsereInTextBox(m_txtFormule, nPosCurseur, strCommande);
        }
        //-------------------------------------------------------------------------
        private CResultAErreur MAJ_FormuleInChamp()
        {
            CResultAErreur result = CResultAErreur.True;
            object obj = CObjetForTestValeurChampCustom.GetNewFor(Champ, null);
            IFournisseurProprietesDynamiques fournisseur = null;
            if (obj is IFournisseurProprietesDynamiques)
                fournisseur = (IFournisseurProprietesDynamiques)obj;
            else
                fournisseur = new CFournisseurPropDynStd(true);
            CContexteAnalyse2iExpression ctx = new CContexteAnalyse2iExpression(fournisseur, obj.GetType());
            CAnalyseurSyntaxiqueExpression analyseur = new CAnalyseurSyntaxiqueExpression(ctx);
            result = analyseur.AnalyseChaine(m_txtFormuleValidation.Text);
            if (result)
                Champ.FormuleValidation = (C2iExpression)result.Data;
            else
                result.EmpileErreur(I.T("Validation formula error|30217"));
            return result;
        }

        private void m_btnTest_Click(object sender, System.EventArgs e)
        {
            CResultAErreur result = MAJ_Champs();
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
                return;
            }
            result = Champ.IsCorrectValue(Champ.TypeDonneeChamp.ObjectToType(m_txtTest.Text, Champ.ContexteDonnee));
            if (!result)
                CFormAlerte.Afficher(result.Erreur);
        }


        //-------------------------------------------------------------------------
        private void TxtFormule_Enter(object sender, System.EventArgs e)
        {
            if (sender is sc2i.win32.expression.CControleEditeFormule)
            {
                if (m_txtFormule != null)
                    m_txtFormule.BackColor = Color.White;
                m_txtFormule = (sc2i.win32.expression.CControleEditeFormule)sender;
                m_txtFormule.BackColor = Color.LightGreen;
            }
        }

        //-------------------------------------------------------------------------
        private void m_cmbType_SelectedValueChanged(object sender, EventArgs e)
        {
            // On veut changer le type du champ

            UpdatePanelParametres();
            UpdatePrecision();
            UpdatePanelUnite();
        }


        //-------------------------------------------------------------------------
        private void UpdatePanelParametres()
        {
            C2iTypeDonnee type = (C2iTypeDonnee)m_cmbType.SelectedItem;
            if (type.TypeDonnee == TypeDonnee.tObjetDonneeAIdNumeriqueAuto)
            {
                m_panelParamClassiques.Visible = false;
                m_panelPourObjetDonnee.Visible = true;
                m_panelPourObjetDonnee.Dock = DockStyle.Fill;
            }
            else
            {
                m_panelPourObjetDonnee.Visible = false;
                m_panelParamClassiques.Visible = true;
                m_panelParamClassiques.Dock = DockStyle.Fill;
            }
        }

        //-------------------------------------------------------------------
        private void m_cmbRoleChamp_SelectedValueChanged(object sender, EventArgs e)
        {
            CRoleChampCustom role = (CRoleChampCustom)m_cmbRoleChamp.SelectedValue;
            if (role != null)
            {
                CFiltreDynamique filtre = m_panelFiltre.FiltreDynamique;
                if (filtre != null)
                    CCreateur2iFormulaire.AssureVariableElementCible(filtre, role.TypeAssocie);
                Champ.Role = role;
                DeclencheEvenementChangementDonnee(CChampCustom.c_champCodeRole);
            }
        }

        void m_panelFiltre_OnChangeTypeElements(object sender, Type typeSelectionne)
        {
            OnChangeTypes();
        }

        private void OnChangeTypes()
        {
            if (m_cmbType.SelectedItem is C2iTypeDonnee)
            {
                C2iTypeDonnee typeDonnee = (C2iTypeDonnee)m_cmbType.SelectedItem;
                Type typeObjetDonnee = null;
                if (m_panelFiltre.FiltreDynamique != null)
                    typeObjetDonnee = m_panelFiltre.FiltreDynamique.TypeElements;
                object objetTest = CObjetForTestValeurChampCustom.GetNewForTypeDonnee(typeDonnee.TypeDonnee, typeObjetDonnee, null);
                IFournisseurProprietesDynamiques fournisseur = null;
                if (objetTest is IFournisseurProprietesDynamiques)
                    fournisseur = (IFournisseurProprietesDynamiques)objetTest;
                else
                    fournisseur = new CFournisseurPropDynStd(true);
                if (objetTest == null)
                    return;
                m_wndAide.FournisseurProprietes = fournisseur;
                m_wndAide.ObjetInterroge = objetTest.GetType();
                m_txtFormuleValidation.Init(m_wndAide.FournisseurProprietes, m_wndAide.ObjetInterroge);
                m_txtValeurDefaut.Init(m_wndAide.FournisseurProprietes, m_wndAide.ObjetInterroge);
                TxtFormule_Enter(m_txtValeurDefaut, new EventArgs());
            }
        }

        //----------------------------------------------------------------------------------------
        private void m_lnkSousRoles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            m_menuAutresUtilisations.Items.Clear();
            foreach (CRoleChampCustom role in CRoleChampCustom.Roles)
            {
                if (Champ.HasRoleSecondaire(role.CodeRole) || m_gestionnaireModeEdition.ModeEdition)
                {
                    ToolStripMenuItem itemRole = new ToolStripMenuItem(role.Libelle);
                    itemRole.Tag = role.CodeRole;
                    itemRole.Checked = Champ.HasRoleSecondaire(role.CodeRole);
                    itemRole.Enabled = m_gestionnaireModeEdition.ModeEdition;
                    itemRole.Click += new EventHandler(itemRole_Click);
                    m_menuAutresUtilisations.Items.Add(itemRole);
                }
            }
            m_menuAutresUtilisations.Show(m_lnkSousRoles, new Point(0, m_lnkSousRoles.Height));
        }

        //----------------------------------------------------------------------------------------
        private void itemRole_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            string strCode = item != null ? item.Tag as string : null;
            if (strCode != null)
            {
                if (!item.Checked)
                    Champ.AddRoleSecondaire(strCode);
                else
                    Champ.RemoveRoleSecondaire(strCode);
                RefreshVisuSousRoles();
            }
        }

        //----------------------------------------------------------------------------------------
        private void RefreshVisuSousRoles()
        {
            if (Champ.CodesRolesSecondaires.Length > 0)
            {
                m_lnkSousRoles.Text = I.T("Sub purposes|20586") + " (" + Champ.CodesRolesSecondaires.Length + ")";
            }
            else
                m_lnkSousRoles.Text = I.T("Sub purposes|20586");
        }

    }
}

