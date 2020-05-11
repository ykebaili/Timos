using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using sc2i.data.dynamic;
using sc2i.data;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.common;
using sc2i.win32.data;
using sc2i.win32.common;
using sc2i.expression;



using timos.data;
using sc2i.win32.data.dynamic;

namespace timos
{
    [sc2i.win32.data.navigation.ObjectEditeur(typeof(CModeleEtiquetteSchema))]
    public class CFormEditionModeleEtiquetteSchema : CFormEditionStdTimos, IFormNavigable
    {
        private Hashtable m_hashtableValeurs = new Hashtable();
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.IContainer components = null;

        private CObjetDonnee m_objetTest = null;

        private const string c_strColValeur = "ValModeleEtiquette";
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
        private C2iTextBox m_txtLibelle;
        private bool m_bComboRemplissageInitialized = false;

        //-------------------------------------------------------------------------
        public CFormEditionModeleEtiquetteSchema()
            : base()
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }
        //-------------------------------------------------------------------------
        public CFormEditionModeleEtiquetteSchema(CModeleEtiquetteSchema ModeleEtiquetteSchema)
            : base(ModeleEtiquetteSchema)
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }
        //-------------------------------------------------------------------------
        public CFormEditionModeleEtiquetteSchema(CModeleEtiquetteSchema ModeleEtiquetteSchema, CListeObjetsDonnees liste)
            : base(ModeleEtiquetteSchema, liste)
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
            this.label1 = new System.Windows.Forms.Label();
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
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_wndAide = new sc2i.win32.expression.CControlAideFormule();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            this.c2iPanelOmbre1.SuspendLayout();
            this.m_panelFond.SuspendLayout();
            this.m_panelDonnees.SuspendLayout();
            this.c2iPanelOmbre3.SuspendLayout();
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
            this.m_panelCle.Location = new System.Drawing.Point(530, 0);
            this.m_panelCle.Size = new System.Drawing.Size(87, 28);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.label1.Location = new System.Drawing.Point(15, 11);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label1, "");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 7;
            this.label1.Text = "Label|50";
            // 
            // label6
            // 
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.label6.Location = new System.Drawing.Point(5, 48);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label6, "");
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 23);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 4001;
            this.label6.Text = "Type|30284";
            // 
            // c2iPanelOmbre1
            // 
            this.c2iPanelOmbre1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iPanelOmbre1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre1.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre1.Controls.Add(this.label1);
            this.c2iPanelOmbre1.Controls.Add(this.m_cmbTypeElement);
            this.c2iPanelOmbre1.Controls.Add(this.label6);
            this.c2iPanelOmbre1.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre1, "");
            this.c2iPanelOmbre1.Location = new System.Drawing.Point(8, 8);
            this.c2iPanelOmbre1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre1, "");
            this.c2iPanelOmbre1.Name = "c2iPanelOmbre1";
            this.c2iPanelOmbre1.Size = new System.Drawing.Size(476, 96);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre1.TabIndex = 0;
            // 
            // m_cmbTypeElement
            // 
            this.m_cmbTypeElement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbTypeElement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTypeElement.FormattingEnabled = true;
            this.m_cmbTypeElement.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbTypeElement, "");
            this.m_cmbTypeElement.Location = new System.Drawing.Point(88, 45);
            this.m_cmbTypeElement.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbTypeElement, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbTypeElement, "");
            this.m_cmbTypeElement.Name = "m_cmbTypeElement";
            this.m_cmbTypeElement.Size = new System.Drawing.Size(356, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbTypeElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbTypeElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbTypeElement.TabIndex = 2;
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
            this.c2iPanelOmbre3.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre3, "");
            this.c2iPanelOmbre3.Location = new System.Drawing.Point(8, 99);
            this.c2iPanelOmbre3.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre3, "");
            this.c2iPanelOmbre3.Name = "c2iPanelOmbre3";
            this.c2iPanelOmbre3.Size = new System.Drawing.Size(553, 306);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre3, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre3, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre3.TabIndex = 2;
            // 
            // m_txtFormule
            // 
            this.m_txtFormule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormule.BackColor = System.Drawing.Color.White;
            this.m_txtFormule.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtFormule.Formule = null;
            this.m_extLinkField.SetLinkField(this.m_txtFormule, "");
            this.m_txtFormule.Location = new System.Drawing.Point(8, 24);
            this.m_txtFormule.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtFormule, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtFormule, "");
            this.m_txtFormule.Name = "m_txtFormule";
            this.m_txtFormule.Size = new System.Drawing.Size(522, 210);
            this.m_extStyle.SetStyleBackColor(this.m_txtFormule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFormule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormule.TabIndex = 0;
            // 
            // m_btnSelectElementTest
            // 
            this.m_btnSelectElementTest.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.m_btnSelectElementTest.BackColor = System.Drawing.SystemColors.Control;
            this.m_extLinkField.SetLinkField(this.m_btnSelectElementTest, "");
            this.m_btnSelectElementTest.Location = new System.Drawing.Point(40, 258);
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
            this.m_btnTest.Location = new System.Drawing.Point(272, 258);
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
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_extLinkField.SetLinkField(this.splitter1, "");
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
            this.m_txtLibelle.Size = new System.Drawing.Size(356, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 4002;
            this.m_txtLibelle.Text = "[Libelle]";
            // 
            // CFormEditionModeleEtiquetteSchema
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(792, 456);
            this.Controls.Add(this.m_panelFond);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionModeleEtiquetteSchema";
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
        protected CModeleEtiquetteSchema ModeleEtiquetteSchema
        {
            get
            {
                return (CModeleEtiquetteSchema)ObjetEdite;
            }
        }

        //-------------------------------------------------------------------------
        protected override CResultAErreur MyInitChamps()
        {
            CResultAErreur result = base.MyInitChamps();
            m_txtFormule.Text = ModeleEtiquetteSchema.Formule.GetString();
            InitComboTypes(true);
            return result;
        }

        //-------------------------------------------------------------------------
        protected void InitComboTypes(bool bForcerRemplissage)
        {
            if (!m_bComboRemplissageInitialized || bForcerRemplissage)
            {
                
               

                    

                List<CInfoClasseDynamique> lstInfo = new List<CInfoClasseDynamique>();


                if (m_cmbTypeElement.Items.Count == 0)
                {

                    foreach (CInfoClasseDynamique info in DynamicClassAttribute.GetAllDynamicClass())
                    {
                        if (typeof(IElementDeSchemaReseau).IsAssignableFrom(info.Classe))
                        {
                            lstInfo.Add(info);
                        }

                    }
                    m_cmbTypeElement.Init(lstInfo.ToArray());

                }
              
                m_bComboRemplissageInitialized = true;
            }
            if (ModeleEtiquetteSchema.TypeCible != null)
                m_cmbTypeElement.TypeSelectionne = ModeleEtiquetteSchema.TypeCible;
            m_wndAide.ObjetInterroge = ModeleEtiquetteSchema.TypeCible;
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
                    ModeleEtiquetteSchema.TypeCible = m_cmbTypeElement.TypeSelectionne;

                result = MAJ_FormuleInChamp();
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
            m_wndAide.InsereInTextBox(m_txtFormule.TextBox, nPosCurseur, strCommande);
        }
        //-------------------------------------------------------------------------
        private CResultAErreur MAJ_FormuleInChamp()
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_cmbTypeElement.TypeSelectionne == null)
            {
                result.EmpileErreur(I.T("Select an object type|30214"));
                return result;
            }
            Type tp = m_cmbTypeElement.TypeSelectionne;
            CContexteAnalyse2iExpression ctx = new CContexteAnalyse2iExpression(new CFournisseurPropDynStd(true), tp);
            CAnalyseurSyntaxiqueExpression analyseur = new CAnalyseurSyntaxiqueExpression(ctx);
            result = analyseur.AnalyseChaine(m_txtFormule.Text);
            if (result)
                ModeleEtiquetteSchema.Formule = (C2iExpression)result.Data;
            else
                result.EmpileErreur(I.T("Formula error|1422"));
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
            if (m_objetTest == null)
            {
                if (!SelectObjetTest())
                    return;
            }
            if (m_objetTest == null)
                return;
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
                return;
            }
            CContexteEvaluationExpression contexte = new CContexteEvaluationExpression(m_objetTest);
            result = ModeleEtiquetteSchema.Formule.Eval(contexte);
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
                return;
            }
            if (result.Data == null)
                CFormAlerte.Afficher("null", EFormAlerteType.Exclamation);
            else
                CFormAlerte.Afficher(result.Data.ToString(), EFormAlerteType.Exclamation);
        }

        //-------------------------------------------------------------------------
        private bool SelectObjetTest()
        {
            if (m_cmbTypeElement.TypeSelectionne != null)
            {
                CObjetDonnee objet = CFormSelectUnObjetDonnee.SelectObjetDonnee(
                    I.T("Select an element for test|20735"),
                    m_cmbTypeElement.TypeSelectionne);
                if (objet != null)
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
            if (m_cmbTypeElement.TypeSelectionne != null)
            {
                m_wndAide.ObjetInterroge = m_cmbTypeElement.TypeSelectionne;
                m_txtFormule.Init(m_wndAide.FournisseurProprietes, m_wndAide.ObjetInterroge);
            }
        }
        //-------------------------------------------------------------------------
    }
}

