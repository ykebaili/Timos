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

using timos;

namespace timos
{
    [sc2i.win32.data.navigation.ObjectEditeur(typeof(CSymboleDeBibliotheque))]
    public class CFormEditionSymboleDeBibliotheque : CFormEditionStdTimos, IFormNavigable
    {
        private System.Windows.Forms.Label label1;
        private sc2i.win32.common.C2iTextBox m_txtLibelle;
        private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
        private Label label2;
        private C2iTextBoxSelectionne m_cmbFamille;
        private Label label3;
        private C2iTabControl m_tabControl;
        private Crownwood.Magic.Controls.TabPage m_pageSymbole;
        // private sc2i.formulaire.win32.editor.CPanelListe2iWnd m_listeControles;
        private Label m_labelTypeCible;
        private C2iComboBox m_cmbxTypeCible;
        private CPanelEditeurSymbole m_panelEditeurSymbole;
        private LinkLabel m_linkAjusterFond;
        private LinkLabel m_linkAjusteFond;
        private CheckBox m_chkParDefaut;
        private CCtrlSauvegardeProfilDesigner m_ctrlSavProfilDesigner;
        private System.ComponentModel.IContainer components = null;

        public CFormEditionSymboleDeBibliotheque()
            : base()
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
            MyInit();
        }
        //-------------------------------------------------------------------------
        public CFormEditionSymboleDeBibliotheque(CSymboleDeBibliotheque symbole)
            : base(symbole)
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
            MyInit();
        }
        //-------------------------------------------------------------------------
        public CFormEditionSymboleDeBibliotheque(CSymboleDeBibliotheque symbole, CListeObjetsDonnees liste)
            : base(symbole, liste)
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
            MyInit();
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
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_labelTypeCible = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_chkParDefaut = new System.Windows.Forms.CheckBox();
            this.m_cmbxTypeCible = new sc2i.win32.common.C2iComboBox();
            this.m_cmbFamille = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageSymbole = new Crownwood.Magic.Controls.TabPage();
            this.m_linkAjusteFond = new System.Windows.Forms.LinkLabel();
            this.m_linkAjusterFond = new System.Windows.Forms.LinkLabel();
            this.m_panelEditeurSymbole = new timos.CPanelEditeurSymbole();
            this.m_ctrlSavProfilDesigner = new timos.CCtrlSauvegardeProfilDesigner();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.m_pageSymbole.SuspendLayout();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.label1.Location = new System.Drawing.Point(16, 12);
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
            this.m_txtLibelle.Location = new System.Drawing.Point(112, 7);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(333, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Libelle]";
            // 
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.m_labelTypeCible);
            this.c2iPanelOmbre4.Controls.Add(this.label3);
            this.c2iPanelOmbre4.Controls.Add(this.label2);
            this.c2iPanelOmbre4.Controls.Add(this.m_chkParDefaut);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.Controls.Add(this.m_cmbxTypeCible);
            this.c2iPanelOmbre4.Controls.Add(this.m_cmbFamille);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(8, 52);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(670, 100);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // m_labelTypeCible
            // 
            this.m_labelTypeCible.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_labelTypeCible, "");
            this.m_labelTypeCible.Location = new System.Drawing.Point(2, 62);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_labelTypeCible, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_labelTypeCible, "");
            this.m_labelTypeCible.Name = "m_labelTypeCible";
            this.m_labelTypeCible.Size = new System.Drawing.Size(93, 13);
            this.m_extStyle.SetStyleBackColor(this.m_labelTypeCible, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_labelTypeCible, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_labelTypeCible.TabIndex = 4008;
            this.m_labelTypeCible.Text = "Target type|30030";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(23, 11);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4006;
            this.label3.Text = "Label|50";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(4, 36);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4004;
            this.label2.Text = "Symbol family|30021";
            // 
            // m_chkParDefaut
            // 
            this.m_chkParDefaut.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkParDefaut, "");
            this.m_chkParDefaut.Location = new System.Drawing.Point(401, 61);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkParDefaut, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkParDefaut, "");
            this.m_chkParDefaut.Name = "m_chkParDefaut";
            this.m_chkParDefaut.Size = new System.Drawing.Size(161, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkParDefaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkParDefaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkParDefaut.TabIndex = 4009;
            this.m_chkParDefaut.Text = "Use as default symbol|20099";
            this.m_chkParDefaut.UseVisualStyleBackColor = true;
            // 
            // m_cmbxTypeCible
            // 
            this.m_cmbxTypeCible.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbxTypeCible.FormattingEnabled = true;
            this.m_cmbxTypeCible.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbxTypeCible, "");
            this.m_cmbxTypeCible.Location = new System.Drawing.Point(112, 59);
            this.m_cmbxTypeCible.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbxTypeCible, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbxTypeCible, "");
            this.m_cmbxTypeCible.Name = "m_cmbxTypeCible";
            this.m_cmbxTypeCible.Size = new System.Drawing.Size(284, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbxTypeCible, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbxTypeCible, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbxTypeCible.TabIndex = 4007;
            this.m_cmbxTypeCible.SelectionChangeCommitted += new System.EventHandler(this.m_cmbxTypeCible_SelectionChangeCommitted);
            // 
            // m_cmbFamille
            // 
            this.m_cmbFamille.ElementSelectionne = null;
            this.m_cmbFamille.FonctionTextNull = null;
            this.m_cmbFamille.HasLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbFamille, "Famille.Libelle");
            this.m_cmbFamille.Location = new System.Drawing.Point(112, 32);
            this.m_cmbFamille.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbFamille, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbFamille, "");
            this.m_cmbFamille.Name = "m_cmbFamille";
            this.m_cmbFamille.SelectedObject = null;
            this.m_cmbFamille.Size = new System.Drawing.Size(333, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbFamille, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbFamille, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbFamille.TabIndex = 4005;
            this.m_cmbFamille.TextNull = "";
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
            this.m_tabControl.Location = new System.Drawing.Point(8, 147);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.m_pageSymbole;
            this.m_tabControl.Size = new System.Drawing.Size(806, 411);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4005;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageSymbole});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageSymbole
            // 
            this.m_pageSymbole.Controls.Add(this.m_linkAjusteFond);
            this.m_pageSymbole.Controls.Add(this.m_linkAjusterFond);
            this.m_pageSymbole.Controls.Add(this.m_panelEditeurSymbole);
            this.m_extLinkField.SetLinkField(this.m_pageSymbole, "");
            this.m_pageSymbole.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageSymbole, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageSymbole, "");
            this.m_pageSymbole.Name = "m_pageSymbole";
            this.m_pageSymbole.Size = new System.Drawing.Size(790, 370);
            this.m_extStyle.SetStyleBackColor(this.m_pageSymbole, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageSymbole, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageSymbole.TabIndex = 10;
            this.m_pageSymbole.Title = "Symbol|30029";
            // 
            // m_linkAjusteFond
            // 
            this.m_linkAjusteFond.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_extLinkField.SetLinkField(this.m_linkAjusteFond, "");
            this.m_linkAjusteFond.Location = new System.Drawing.Point(0, 332);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_linkAjusteFond, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_linkAjusteFond, "");
            this.m_linkAjusteFond.Name = "m_linkAjusteFond";
            this.m_linkAjusteFond.Size = new System.Drawing.Size(170, 25);
            this.m_extStyle.SetStyleBackColor(this.m_linkAjusteFond, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_linkAjusteFond, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_linkAjusteFond.TabIndex = 2;
            this.m_linkAjusteFond.TabStop = true;
            this.m_linkAjusteFond.Text = "Adjust background size|30350";
            this.m_linkAjusteFond.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_linkAjusteFond_LinkClicked);
            // 
            // m_linkAjusterFond
            // 
            this.m_linkAjusterFond.AutoSize = true;
            this.m_linkAjusterFond.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_extLinkField.SetLinkField(this.m_linkAjusterFond, "");
            this.m_linkAjusterFond.Location = new System.Drawing.Point(0, 357);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_linkAjusterFond, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_linkAjusterFond, "");
            this.m_linkAjusterFond.Name = "m_linkAjusterFond";
            this.m_linkAjusterFond.Size = new System.Drawing.Size(118, 13);
            this.m_extStyle.SetStyleBackColor(this.m_linkAjusterFond, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_linkAjusterFond, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_linkAjusterFond.TabIndex = 1;
            this.m_linkAjusterFond.TabStop = true;
            this.m_linkAjusterFond.Text = "Adjust background size";
            // 
            // m_panelEditeurSymbole
            // 
            this.m_panelEditeurSymbole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_panelEditeurSymbole, "");
            this.m_panelEditeurSymbole.Location = new System.Drawing.Point(-8, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEditeurSymbole, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelEditeurSymbole, "");
            this.m_panelEditeurSymbole.Name = "m_panelEditeurSymbole";
            this.m_panelEditeurSymbole.Size = new System.Drawing.Size(798, 316);
            this.m_extStyle.SetStyleBackColor(this.m_panelEditeurSymbole, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEditeurSymbole, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEditeurSymbole.SymboleEdite = null;
            this.m_panelEditeurSymbole.TabIndex = 0;
            this.m_panelEditeurSymbole.TypeEdite = null;
            // 
            // m_ctrlSavProfilDesigner
            // 
            this.m_ctrlSavProfilDesigner.Designer = this.m_panelEditeurSymbole.Editeur;
            this.m_ctrlSavProfilDesigner.Formulaire = this;
            // 
            // CFormEditionSymboleDeBibliotheque
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionSymboleDeBibliotheque";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre4, 0);
            this.Controls.SetChildIndex(this.m_tabControl, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            this.c2iPanelOmbre4.ResumeLayout(false);
            this.c2iPanelOmbre4.PerformLayout();
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.m_pageSymbole.ResumeLayout(false);
            this.m_pageSymbole.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        //-------------------------------------------------------------------------
        private CSymboleDeBibliotheque SymboleDeBibliotheque
        {
            get
            {
                return (CSymboleDeBibliotheque)ObjetEdite;
            }
        }


        public void MyInit()
        {

       
        }

        //-------------------------------------------------------------------------
        protected override CResultAErreur MyInitChamps()
        {
            m_chkParDefaut.Checked = false;
            m_chkParDefaut.Visible = !SymboleDeBibliotheque.IsNew();
            InitFamilles();
            InitComboTypeCible();
            AffecterTitre(I.T("Library symbol |30025") + SymboleDeBibliotheque.Libelle);
            CResultAErreur result = base.MyInitChamps();
            C2iSymbole symb = new C2iSymbole();
            symb.BackColor = Color.White;
            Type typeEdite = null;
            if (result)
            {
                m_cmbxTypeCible.SelectedValue = SymboleDeBibliotheque.TypeCible;
                if (m_cmbxTypeCible.SelectedValue != null)
                {
                    typeEdite = (Type)m_cmbxTypeCible.SelectedValue;
                }
                if (SymboleDeBibliotheque != null)
                {
                    if (SymboleDeBibliotheque.Symbole != null)
                    {
                        if (SymboleDeBibliotheque.Symbole.Symbole != null)
                        {

                            symb = SymboleDeBibliotheque.Symbole.Symbole;
                        }
                    }
                }
                m_panelEditeurSymbole.Init(symb, typeEdite, false);
            }
            if (SymboleDeBibliotheque.Symbole != null)
            {
                m_chkParDefaut.Checked = CSymbole.GetIdSymboleParDefaut(SymboleDeBibliotheque.TypeCible, SymboleDeBibliotheque.ContexteDonnee) == SymboleDeBibliotheque.Symbole.Id;
            }

            return result;


        }
       

        private void InitComboTypeCible()
        {
            
           List<CInfoClasseDynamique> lstTypes = new List<CInfoClasseDynamique>();
           
            if(m_cmbxTypeCible.Items.Count ==0)
            {
                
                foreach (CInfoClasseDynamique info in DynamicClassAttribute.GetAllDynamicClass())
                
                if(typeof(IElementASymbolePourDessin).IsAssignableFrom(info.Classe))
                {
                    lstTypes.Add(info);                   
                }
                 lstTypes.Insert(0, new CInfoClasseDynamique(typeof(DBNull), I.T("No target type|30333")));      
                 m_cmbxTypeCible.DataSource = lstTypes;
                 m_cmbxTypeCible.ValueMember = "Classe";
                 m_cmbxTypeCible.DisplayMember = "Nom";
                     
            }
           

		
        }
        //-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            if (SymboleDeBibliotheque != null)
            {
                if (m_cmbFamille.ElementSelectionne != null)
                    SymboleDeBibliotheque.Famille = (CFamilleSymbole)m_cmbFamille.ElementSelectionne;
                SymboleDeBibliotheque.TypeCible = (Type)m_cmbxTypeCible.SelectedValue;

                if (SymboleDeBibliotheque.Symbole == null)
                {
                    // Symbole.Symbole = new CSymbole(Symbole.ContexteDonnee);


                    CSymbole sym = new CSymbole(SymboleDeBibliotheque.ContexteDonnee);
                    sym.CreateNewInCurrentContexte();
                    SymboleDeBibliotheque.Symbole = sym;

                }
                SymboleDeBibliotheque.Symbole.Symbole = (C2iSymbole)m_panelEditeurSymbole.SymboleEdite;
                if (!SymboleDeBibliotheque.IsNew() && m_chkParDefaut.Checked)
                    CSymbole.SetSymboleParDefaut(SymboleDeBibliotheque.TypeCible, SymboleDeBibliotheque.Symbole);
            }

            return base.MAJ_Champs();
        }

        private void InitFamilles()
        {

            m_cmbFamille.Init<CFamilleSymbole>(
                "Libelle",
                false);

            if (SymboleDeBibliotheque != null)
                m_cmbFamille.ElementSelectionne = SymboleDeBibliotheque.Famille;

        }


        private void m_cmbxTypeCible_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (SymboleDeBibliotheque != null)
            {
                Type tp = m_cmbxTypeCible.SelectedValue as Type;
                m_panelEditeurSymbole.TypeEdite = tp;
                if (tp != null)
                {
                    if (SymboleDeBibliotheque.Symbole != null)
                    {
                        m_chkParDefaut.Checked = CSymbole.GetIdSymboleParDefaut(tp, SymboleDeBibliotheque.ContexteDonnee) == SymboleDeBibliotheque.Symbole.Id;
                    }
                    m_chkParDefaut.Visible = !SymboleDeBibliotheque.IsNew();
                }
                else
                    m_chkParDefaut.Visible = false;
            }
        }

        private void m_linkAjusteFond_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            m_panelEditeurSymbole.AjusterFond();
        }


      
        
    }



}

