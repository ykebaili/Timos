using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using sc2i.workflow;
using sc2i.data.dynamic;
using sc2i.data;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.common;
using sc2i.win32.data;
using sc2i.win32.common;
using sc2i.custom;
using sc2i.formulaire;

using timos.acteurs;
using timos.securite;
using System.IO;
using System.Drawing.Imaging;
using timos.Controles.ActionsSurLink;
using System.Collections.Generic;

namespace timos
{
    [sc2i.win32.data.navigation.ObjectEditeur(typeof(CMenuCustom))]
    public class CFormEditionMenuCustom : CFormEditionStdTimos, IFormNavigable
    {
        private CMenuCustom m_menuEdite = null;
        private sc2i.win32.common.C2iPanelOmbre m_panelArbreMenu;
        private sc2i.win32.common.C2iPanelOmbre m_panelDetailMenu;
        private sc2i.win32.data.CArbreObjetsDonneesHierarchiques m_arbre;
        private System.Windows.Forms.Label label1;
        private sc2i.win32.common.C2iTextBox m_txtLibelle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label m_lblAction;
        private System.Windows.Forms.Button m_btnAction;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private sc2i.win32.common.CWndLinkStd m_lnkAjouterGroupe;
        private System.Windows.Forms.ListView m_wndListeGroupes;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private sc2i.win32.data.CComboBoxListeObjetsDonnees m_cmbGroupes;
        private sc2i.win32.common.CWndLinkStd m_lnkSupprimerGroupe;
        private System.Windows.Forms.ContextMenu m_menuArbre;
        private System.Windows.Forms.MenuItem m_menuAjouterSousMenu;
        private System.Windows.Forms.MenuItem m_menuSupprimerSousMenu;
        private System.Windows.Forms.Label label4;
        private sc2i.win32.common.C2iNumericUpDown m_txtIndice;
        private Label label5;
        private SplitContainer splitContainer1;
        private ListView m_wndListeProfils;
        private ColumnHeader columnHeader2;
        private CComboBoxListeObjetsDonnees m_cmbProfils;
        private Label label6;
        private CWndLinkStd m_lnkAjouterProfil;
        private CWndLinkStd m_lnkSupprimerProfil;
        private C2iPanelOmbre c2iPanelOmbre1;
        private Label label7;
        private C2iPictureBox m_picCustomLogo;
        private Label label8;
        private System.ComponentModel.IContainer components = null;

        public CFormEditionMenuCustom()
            : base()
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }
        //-------------------------------------------------------------------------
        public CFormEditionMenuCustom(CMenuCustom MenuCustom)
            : base(MenuCustom)
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }
        //-------------------------------------------------------------------------
        public CFormEditionMenuCustom(CMenuCustom MenuCustom, CListeObjetsDonnees liste)
            : base(MenuCustom, liste)
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

        #region Designer generated code
        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionMenuCustom));
            this.m_panelArbreMenu = new sc2i.win32.common.C2iPanelOmbre();
            this.m_arbre = new sc2i.win32.data.CArbreObjetsDonneesHierarchiques();
            this.m_panelDetailMenu = new sc2i.win32.common.C2iPanelOmbre();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_wndListeGroupes = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.m_cmbGroupes = new sc2i.win32.data.CComboBoxListeObjetsDonnees();
            this.label3 = new System.Windows.Forms.Label();
            this.m_lnkAjouterGroupe = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkSupprimerGroupe = new sc2i.win32.common.CWndLinkStd();
            this.m_wndListeProfils = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.m_cmbProfils = new sc2i.win32.data.CComboBoxListeObjetsDonnees();
            this.label6 = new System.Windows.Forms.Label();
            this.m_lnkAjouterProfil = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkSupprimerProfil = new sc2i.win32.common.CWndLinkStd();
            this.m_txtIndice = new sc2i.win32.common.C2iNumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.m_btnAction = new System.Windows.Forms.Button();
            this.m_lblAction = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_menuArbre = new System.Windows.Forms.ContextMenu();
            this.m_menuAjouterSousMenu = new System.Windows.Forms.MenuItem();
            this.m_menuSupprimerSousMenu = new System.Windows.Forms.MenuItem();
            this.c2iPanelOmbre1 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_picCustomLogo = new sc2i.win32.common.C2iPictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.m_panelArbreMenu.SuspendLayout();
            this.m_panelDetailMenu.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_txtIndice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.c2iPanelOmbre1.SuspendLayout();
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
            this.m_panelNavigation.Location = new System.Drawing.Point(630, 0);
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
            this.m_panelCle.Location = new System.Drawing.Point(522, 0);
            this.m_panelCle.Size = new System.Drawing.Size(108, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(805, 28);
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
            // m_panelArbreMenu
            // 
            this.m_panelArbreMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_panelArbreMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelArbreMenu.Controls.Add(this.m_arbre);
            this.m_panelArbreMenu.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panelArbreMenu, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelArbreMenu, false);
            this.m_panelArbreMenu.Location = new System.Drawing.Point(8, 136);
            this.m_panelArbreMenu.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelArbreMenu, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelArbreMenu, "");
            this.m_panelArbreMenu.Name = "m_panelArbreMenu";
            this.m_panelArbreMenu.Size = new System.Drawing.Size(316, 411);
            this.m_extStyle.SetStyleBackColor(this.m_panelArbreMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panelArbreMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelArbreMenu.TabIndex = 0;
            // 
            // m_arbre
            // 
            this.m_arbre.AddRootForAll = false;
            this.m_arbre.AllowDrop = true;
            this.m_arbre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_arbre.AutoriserFilsDesAutorises = true;
            this.m_arbre.ElementSelectionne = null;
            this.m_arbre.ElementsSelectionnes = new sc2i.data.CObjetDonnee[0];
            this.m_arbre.ForeColorNonSelectionnable = System.Drawing.Color.DarkGray;
            this.m_extLinkField.SetLinkField(this.m_arbre, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_arbre, false);
            this.m_arbre.Location = new System.Drawing.Point(4, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_arbre, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_arbre, "");
            this.m_arbre.Name = "m_arbre";
            this.m_arbre.RootLabel = "Root";
            this.m_arbre.Size = new System.Drawing.Size(292, 383);
            this.m_extStyle.SetStyleBackColor(this.m_arbre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_arbre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_arbre.TabIndex = 3;
            this.m_arbre.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_arbre_MouseUp);
            this.m_arbre.DragDrop += new System.Windows.Forms.DragEventHandler(this.m_arbre_DragDrop);
            this.m_arbre.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_arbre_AfterSelect);
            this.m_arbre.DragEnter += new System.Windows.Forms.DragEventHandler(this.m_arbre_DragEnter);
            this.m_arbre.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.m_arbre_ItemDrag);
            this.m_arbre.DragOver += new System.Windows.Forms.DragEventHandler(this.m_arbre_DragOver);
            // 
            // m_panelDetailMenu
            // 
            this.m_panelDetailMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelDetailMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelDetailMenu.Controls.Add(this.splitContainer1);
            this.m_panelDetailMenu.Controls.Add(this.m_txtIndice);
            this.m_panelDetailMenu.Controls.Add(this.label4);
            this.m_panelDetailMenu.Controls.Add(this.m_btnAction);
            this.m_panelDetailMenu.Controls.Add(this.m_lblAction);
            this.m_panelDetailMenu.Controls.Add(this.m_txtLibelle);
            this.m_panelDetailMenu.Controls.Add(this.label2);
            this.m_panelDetailMenu.Controls.Add(this.label5);
            this.m_panelDetailMenu.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panelDetailMenu, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelDetailMenu, false);
            this.m_panelDetailMenu.Location = new System.Drawing.Point(332, 136);
            this.m_panelDetailMenu.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelDetailMenu, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelDetailMenu, "");
            this.m_panelDetailMenu.Name = "m_panelDetailMenu";
            this.m_panelDetailMenu.Size = new System.Drawing.Size(473, 411);
            this.m_extStyle.SetStyleBackColor(this.m_panelDetailMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panelDetailMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelDetailMenu.TabIndex = 3;
            this.m_panelDetailMenu.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_extLinkField.SetLinkField(this.splitContainer1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.splitContainer1, false);
            this.splitContainer1.Location = new System.Drawing.Point(3, 88);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitContainer1, "");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m_wndListeGroupes);
            this.splitContainer1.Panel1.Controls.Add(this.m_cmbGroupes);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.m_lnkAjouterGroupe);
            this.splitContainer1.Panel1.Controls.Add(this.m_lnkSupprimerGroupe);
            this.m_extLinkField.SetLinkField(this.splitContainer1.Panel1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.splitContainer1.Panel1, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1.Panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitContainer1.Panel1, "");
            this.m_extStyle.SetStyleBackColor(this.splitContainer1.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer1.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_wndListeProfils);
            this.splitContainer1.Panel2.Controls.Add(this.m_cmbProfils);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.m_lnkAjouterProfil);
            this.splitContainer1.Panel2.Controls.Add(this.m_lnkSupprimerProfil);
            this.m_extLinkField.SetLinkField(this.splitContainer1.Panel2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.splitContainer1.Panel2, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1.Panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitContainer1.Panel2, "");
            this.m_extStyle.SetStyleBackColor(this.splitContainer1.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer1.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitContainer1.Size = new System.Drawing.Size(446, 303);
            this.splitContainer1.SplitterDistance = 221;
            this.m_extStyle.SetStyleBackColor(this.splitContainer1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitContainer1.TabIndex = 15;
            // 
            // m_wndListeGroupes
            // 
            this.m_wndListeGroupes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_wndListeGroupes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.m_extLinkField.SetLinkField(this.m_wndListeGroupes, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_wndListeGroupes, false);
            this.m_wndListeGroupes.Location = new System.Drawing.Point(3, 75);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeGroupes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndListeGroupes, "");
            this.m_wndListeGroupes.MultiSelect = false;
            this.m_wndListeGroupes.Name = "m_wndListeGroupes";
            this.m_wndListeGroupes.Size = new System.Drawing.Size(212, 221);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeGroupes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeGroupes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeGroupes.TabIndex = 6;
            this.m_wndListeGroupes.UseCompatibleStateImageBehavior = false;
            this.m_wndListeGroupes.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Group|165";
            this.columnHeader1.Width = 500;
            // 
            // m_cmbGroupes
            // 
            this.m_cmbGroupes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbGroupes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbGroupes.ElementSelectionne = null;
            this.m_cmbGroupes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbGroupes.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbGroupes, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbGroupes, false);
            this.m_cmbGroupes.ListDonnees = null;
            this.m_cmbGroupes.Location = new System.Drawing.Point(6, 20);
            this.m_cmbGroupes.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbGroupes, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbGroupes, "");
            this.m_cmbGroupes.Name = "m_cmbGroupes";
            this.m_cmbGroupes.NullAutorise = false;
            this.m_cmbGroupes.ProprieteAffichee = null;
            this.m_cmbGroupes.ProprieteParentListeObjets = null;
            this.m_cmbGroupes.SelectionneurParent = null;
            this.m_cmbGroupes.Size = new System.Drawing.Size(204, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbGroupes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbGroupes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbGroupes.TabIndex = 3;
            this.m_cmbGroupes.TextNull = "(empty)";
            this.m_cmbGroupes.Tri = true;
            // 
            // label3
            // 
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label3, false);
            this.label3.Location = new System.Drawing.Point(6, 4);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(216, 16);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 8;
            this.label3.Text = "Groups allowed to use this menu|30289";
            // 
            // m_lnkAjouterGroupe
            // 
            this.m_lnkAjouterGroupe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAjouterGroupe.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkAjouterGroupe, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkAjouterGroupe, false);
            this.m_lnkAjouterGroupe.Location = new System.Drawing.Point(9, 47);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAjouterGroupe, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAjouterGroupe, "");
            this.m_lnkAjouterGroupe.Name = "m_lnkAjouterGroupe";
            this.m_lnkAjouterGroupe.ShortMode = false;
            this.m_lnkAjouterGroupe.Size = new System.Drawing.Size(81, 22);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAjouterGroupe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAjouterGroupe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAjouterGroupe.TabIndex = 4;
            this.m_lnkAjouterGroupe.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAjouterGroupe.LinkClicked += new System.EventHandler(this.m_lnkAjouter_LinkClicked);
            // 
            // m_lnkSupprimerGroupe
            // 
            this.m_lnkSupprimerGroupe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkSupprimerGroupe.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkSupprimerGroupe, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkSupprimerGroupe, false);
            this.m_lnkSupprimerGroupe.Location = new System.Drawing.Point(96, 47);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkSupprimerGroupe, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkSupprimerGroupe, "");
            this.m_lnkSupprimerGroupe.Name = "m_lnkSupprimerGroupe";
            this.m_lnkSupprimerGroupe.ShortMode = false;
            this.m_lnkSupprimerGroupe.Size = new System.Drawing.Size(81, 22);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSupprimerGroupe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSupprimerGroupe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSupprimerGroupe.TabIndex = 5;
            this.m_lnkSupprimerGroupe.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkSupprimerGroupe.LinkClicked += new System.EventHandler(this.m_lnkDelete_LinkClicked);
            // 
            // m_wndListeProfils
            // 
            this.m_wndListeProfils.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_wndListeProfils.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.m_extLinkField.SetLinkField(this.m_wndListeProfils, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_wndListeProfils, false);
            this.m_wndListeProfils.Location = new System.Drawing.Point(-1, 74);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeProfils, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndListeProfils, "");
            this.m_wndListeProfils.MultiSelect = false;
            this.m_wndListeProfils.Name = "m_wndListeProfils";
            this.m_wndListeProfils.Size = new System.Drawing.Size(212, 221);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeProfils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeProfils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeProfils.TabIndex = 12;
            this.m_wndListeProfils.UseCompatibleStateImageBehavior = false;
            this.m_wndListeProfils.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Profile|416";
            this.columnHeader2.Width = 500;
            // 
            // m_cmbProfils
            // 
            this.m_cmbProfils.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbProfils.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbProfils.ElementSelectionne = null;
            this.m_cmbProfils.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbProfils.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbProfils, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbProfils, false);
            this.m_cmbProfils.ListDonnees = null;
            this.m_cmbProfils.Location = new System.Drawing.Point(2, 19);
            this.m_cmbProfils.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbProfils, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbProfils, "");
            this.m_cmbProfils.Name = "m_cmbProfils";
            this.m_cmbProfils.NullAutorise = false;
            this.m_cmbProfils.ProprieteAffichee = null;
            this.m_cmbProfils.ProprieteParentListeObjets = null;
            this.m_cmbProfils.SelectionneurParent = null;
            this.m_cmbProfils.Size = new System.Drawing.Size(204, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbProfils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbProfils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbProfils.TabIndex = 9;
            this.m_cmbProfils.TextNull = "(empty)";
            this.m_cmbProfils.Tri = true;
            // 
            // label6
            // 
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label6, false);
            this.label6.Location = new System.Drawing.Point(2, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label6, "");
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(216, 16);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 13;
            this.label6.Text = "Profiles allowed to use this Menu|10330";
            // 
            // m_lnkAjouterProfil
            // 
            this.m_lnkAjouterProfil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAjouterProfil.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkAjouterProfil, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkAjouterProfil, false);
            this.m_lnkAjouterProfil.Location = new System.Drawing.Point(5, 46);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAjouterProfil, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAjouterProfil, "");
            this.m_lnkAjouterProfil.Name = "m_lnkAjouterProfil";
            this.m_lnkAjouterProfil.ShortMode = false;
            this.m_lnkAjouterProfil.Size = new System.Drawing.Size(81, 22);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAjouterProfil, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAjouterProfil, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAjouterProfil.TabIndex = 10;
            this.m_lnkAjouterProfil.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAjouterProfil.LinkClicked += new System.EventHandler(this.m_lnkAjouterProfil_LinkClicked);
            // 
            // m_lnkSupprimerProfil
            // 
            this.m_lnkSupprimerProfil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkSupprimerProfil.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkSupprimerProfil, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkSupprimerProfil, false);
            this.m_lnkSupprimerProfil.Location = new System.Drawing.Point(92, 46);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkSupprimerProfil, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkSupprimerProfil, "");
            this.m_lnkSupprimerProfil.Name = "m_lnkSupprimerProfil";
            this.m_lnkSupprimerProfil.ShortMode = false;
            this.m_lnkSupprimerProfil.Size = new System.Drawing.Size(81, 22);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSupprimerProfil, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSupprimerProfil, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSupprimerProfil.TabIndex = 11;
            this.m_lnkSupprimerProfil.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkSupprimerProfil.LinkClicked += new System.EventHandler(this.m_lnkSupprimerProfil_LinkClicked);
            // 
            // m_txtIndice
            // 
            this.m_txtIndice.DoubleValue = 0;
            this.m_txtIndice.IntValue = 0;
            this.m_extLinkField.SetLinkField(this.m_txtIndice, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtIndice, false);
            this.m_txtIndice.Location = new System.Drawing.Point(96, 56);
            this.m_txtIndice.LockEdition = false;
            this.m_txtIndice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtIndice, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtIndice, "");
            this.m_txtIndice.Name = "m_txtIndice";
            this.m_txtIndice.Size = new System.Drawing.Size(64, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtIndice, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtIndice, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtIndice.TabIndex = 2;
            this.m_txtIndice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtIndice.ThousandsSeparator = true;
            // 
            // label4
            // 
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label4, false);
            this.label4.Location = new System.Drawing.Point(8, 58);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 14;
            this.label4.Text = "Position|163";
            // 
            // m_btnAction
            // 
            this.m_btnAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_btnAction, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnAction, false);
            this.m_btnAction.Location = new System.Drawing.Point(425, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAction, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnAction, "");
            this.m_btnAction.Name = "m_btnAction";
            this.m_btnAction.Size = new System.Drawing.Size(24, 20);
            this.m_extStyle.SetStyleBackColor(this.m_btnAction, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAction, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAction.TabIndex = 1;
            this.m_btnAction.Text = "...";
            this.m_btnAction.Click += new System.EventHandler(this.m_btnAction_Click);
            // 
            // m_lblAction
            // 
            this.m_lblAction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblAction.BackColor = System.Drawing.Color.White;
            this.m_lblAction.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_extLinkField.SetLinkField(this.m_lblAction, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblAction, false);
            this.m_lblAction.Location = new System.Drawing.Point(96, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblAction, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblAction, "");
            this.m_lblAction.Name = "m_lblAction";
            this.m_lblAction.Size = new System.Drawing.Size(329, 20);
            this.m_extStyle.SetStyleBackColor(this.m_lblAction, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblAction, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblAction.TabIndex = 6;
            this.m_lblAction.Text = "label3";
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
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(329, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "c2iTextBox1";
            // 
            // label2
            // 
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label2, false);
            this.label2.Location = new System.Drawing.Point(8, 33);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 5;
            this.label2.Text = "Action|162";
            // 
            // label5
            // 
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label5, false);
            this.label5.Location = new System.Drawing.Point(8, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 5;
            this.label5.Text = "Label|50";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.pictureBox1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.pictureBox1, false);
            this.pictureBox1.Location = new System.Drawing.Point(8, 80);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pictureBox1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pictureBox1, "");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(352, 1);
            this.m_extStyle.SetStyleBackColor(this.pictureBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pictureBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label1, false);
            this.label1.Location = new System.Drawing.Point(8, 10);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.label1, "");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 3;
            this.label1.Text = "Label|50";
            // 
            // m_menuArbre
            // 
            this.m_menuArbre.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.m_menuAjouterSousMenu,
            this.m_menuSupprimerSousMenu});
            // 
            // m_menuAjouterSousMenu
            // 
            this.m_menuAjouterSousMenu.Index = 0;
            this.m_menuAjouterSousMenu.Text = "Ajouter";
            this.m_menuAjouterSousMenu.Click += new System.EventHandler(this.m_menuAjouterSousMenu_Click);
            // 
            // m_menuSupprimerSousMenu
            // 
            this.m_menuSupprimerSousMenu.Index = 1;
            this.m_menuSupprimerSousMenu.Text = "Supprimer";
            this.m_menuSupprimerSousMenu.Click += new System.EventHandler(this.m_menuSupprimerSousMenu_Click);
            // 
            // c2iPanelOmbre1
            // 
            this.c2iPanelOmbre1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre1.Controls.Add(this.m_picCustomLogo);
            this.c2iPanelOmbre1.Controls.Add(this.label7);
            this.c2iPanelOmbre1.Controls.Add(this.label8);
            this.c2iPanelOmbre1.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iPanelOmbre1, false);
            this.c2iPanelOmbre1.Location = new System.Drawing.Point(8, 43);
            this.c2iPanelOmbre1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre1, "");
            this.c2iPanelOmbre1.Name = "c2iPanelOmbre1";
            this.c2iPanelOmbre1.Size = new System.Drawing.Size(464, 89);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre1.TabIndex = 4004;
            // 
            // m_picCustomLogo
            // 
            this.m_picCustomLogo.BackColor = System.Drawing.Color.White;
            this.m_picCustomLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_picCustomLogo.Image = global::timos.Properties.Resources.logo_2;
            this.m_extLinkField.SetLinkField(this.m_picCustomLogo, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_picCustomLogo, false);
            this.m_picCustomLogo.Location = new System.Drawing.Point(233, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_picCustomLogo, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_picCustomLogo, "");
            this.m_picCustomLogo.Name = "m_picCustomLogo";
            this.m_picCustomLogo.Size = new System.Drawing.Size(187, 67);
            this.m_extStyle.SetStyleBackColor(this.m_picCustomLogo, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_picCustomLogo, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_picCustomLogo.TabIndex = 6;
            this.m_picCustomLogo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.m_picCustomLogo_MouseClick);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label7, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label7, false);
            this.label7.Location = new System.Drawing.Point(6, 5);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label7, "");
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(226, 24);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 5;
            this.label7.Text = "Use a custom Logo|10401";
            // 
            // label8
            // 
            this.m_extLinkField.SetLinkField(this.label8, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label8, false);
            this.label8.Location = new System.Drawing.Point(7, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label8, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label8, "");
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(234, 16);
            this.m_extStyle.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 5;
            this.label8.Text = "Clic on the image to load a new logo|10402";
            // 
            // CFormEditionMenuCustom
            // 
            this.AffectationsPourNouvelElement = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("$this.AffectationsPourNouvelElement")));
            this.ClientSize = new System.Drawing.Size(805, 551);
            this.Controls.Add(this.c2iPanelOmbre1);
            this.Controls.Add(this.m_panelDetailMenu);
            this.Controls.Add(this.m_panelArbreMenu);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionMenuCustom";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CFormEditionMenuCustom_MouseUp);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.m_panelArbreMenu, 0);
            this.Controls.SetChildIndex(this.m_panelDetailMenu, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre1, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.m_panelArbreMenu.ResumeLayout(false);
            this.m_panelArbreMenu.PerformLayout();
            this.m_panelDetailMenu.ResumeLayout(false);
            this.m_panelDetailMenu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_txtIndice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.c2iPanelOmbre1.ResumeLayout(false);
            this.c2iPanelOmbre1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        //-------------------------------------------------------------------------
        private CMenuCustom MenuCustom
        {
            get
            {
                return (CMenuCustom)ObjetEdite;
            }
        }

        private CMenuCustom m_lastSelectedMenu;
        public const string c_strCleCustomLogoRegistre = "CUSTOM_LOGO";
        //-----------------------------------------------------------
        protected override CResultAErreur MyInitChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            if (!result)
                return result;


            BoutonAjouterVisible = false;

            CDataBaseRegistrePourClient registreTimos = new CDataBaseRegistrePourClient(MenuCustom.ContexteDonnee.IdSession);
            byte[] dataLogo = registreTimos.GetValeurBlob(c_strCleCustomLogoRegistre);
            if (dataLogo != null)
            {
                MemoryStream stream = new MemoryStream(dataLogo);
                try
                {
                    Image logoCustom = Image.FromStream(stream);
                    m_picCustomLogo.Image = logoCustom;
                    stream.Close();
                }
                catch { }
                finally
                {
                    stream.Close();
                }
            }

            m_cmbGroupes.Init(typeof(CGroupeActeur), "Libelle", false);
            m_cmbProfils.Init(typeof(CProfilUtilisateur), "Libelle", false);

            m_arbre.Init(MenuCustom, "ListeMenusFils", CMenuCustom.c_champIdMenuParent, "Libelle", null);

            if (m_lastSelectedMenu != null)
                m_arbre.SelectedNode = m_arbre.GetNodeFor(m_lastSelectedMenu);

            AffecterTitre("Menu " + MenuCustom.Libelle);
            return result;
        }

        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();

            if (m_imgNewCustomLogoToSave != null)
            {
                CDataBaseRegistrePourClient registre = new CDataBaseRegistrePourClient(MenuCustom.ContexteDonnee.IdSession);
                MemoryStream stream = new MemoryStream();
                try
                {
                    m_imgNewCustomLogoToSave.Save(stream, ImageFormat.Png);
                    result = registre.SetValeurBlob(c_strCleCustomLogoRegistre, stream.ToArray());
                }
                catch { }
                finally
                {
                    stream.Close();
                }
            }

            ValideMenuEdite();
            return result;
        }


        //-------------------------------------------------------------------------
        private void ValideMenuEdite()
        {
            if (m_gestionnaireModeEdition.ModeEdition)
            {
                if (m_menuEdite != null)
                {
                    m_menuEdite.Libelle = m_txtLibelle.Text;
                    // Gestion des groupes
                    //TESTDBKEYOK
                    List<CDbKey> lstKeys = new List<CDbKey>();
                    foreach (ListViewItem item in m_wndListeGroupes.Items)
                    {
                        CDbKey key = item.Tag as CDbKey;
                        if (key != null)
                            lstKeys.Add(key);
                    }
                    m_menuEdite.KeysGroupes = lstKeys.ToArray();
                    
                    // Gestion des Profils
                    lstKeys = new List<CDbKey>();
                    foreach (ListViewItem item in m_wndListeProfils.Items)
                    {
                        CDbKey key = item.Tag as CDbKey;
                        if (key != null)
                            lstKeys.Add(key);
                    }
                    m_menuEdite.KeysProfils = lstKeys.ToArray();

                    TreeNode node = m_arbre.GetNodeFor(m_menuEdite);
                    if (node != null)
                        node.Text = m_menuEdite.Libelle;
                    m_menuEdite.NumMenu = m_txtIndice.IntValue;
                }
            }
        }

        //-------------------------------------------------------------------------
        private void m_arbre_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            ValideMenuEdite();
            m_menuEdite = (CMenuCustom)m_arbre.GetObjetInNode(e.Node);
            if (m_menuEdite == null)
            {
                m_panelDetailMenu.Visible = false;
                return;
            }
            m_lastSelectedMenu = m_menuEdite;
            m_panelDetailMenu.Visible = true;
            m_txtLibelle.Text = m_menuEdite.Libelle;
            if (m_menuEdite.ListeMenusFils.Count == 0)
            {
                m_btnAction.Enabled = m_gestionnaireModeEdition.ModeEdition;
                CActionSur2iLink action = m_menuEdite.Action;
                if (action != null)
                    m_lblAction.Text = action.ToString();
                else
                    m_lblAction.Text = "-";
            }
            else
            {
                m_lblAction.Text = "";
                m_btnAction.Enabled = false;
            }
            m_txtIndice.IntValue = m_menuEdite.NumMenu;
            // Initialisation des Groupes
            m_wndListeGroupes.Items.Clear();
            foreach (CDbKey keyGroupe in m_menuEdite.KeysGroupes)
            {
                CGroupeActeur groupe = new CGroupeActeur(MenuCustom.ContexteDonnee);
                if (groupe.ReadIfExists(keyGroupe))
                {
                    ListViewItem item = new ListViewItem(groupe.Libelle);
                    //TESTDBKEYOK
                    item.Tag = groupe.DbKey;
                    m_wndListeGroupes.Items.Add(item);
                }
            }

            // Initialisation des Profils
            m_wndListeProfils.Items.Clear();
            foreach (CDbKey keyProfil in m_menuEdite.KeysProfils)
            {
                CProfilUtilisateur profil = new CProfilUtilisateur(MenuCustom.ContexteDonnee);
                if (profil.ReadIfExists(keyProfil))
                {
                    ListViewItem item = new ListViewItem(profil.Libelle);
                    item.Tag = profil.Id;
                    m_wndListeProfils.Items.Add(item);
                }
            }

        }

        //-------------------------------------------------------------------------//-------------------------------------------------------------------------
        private void m_lnkAjouter_LinkClicked(object sender, System.EventArgs e)
        {
            if (m_cmbGroupes.ElementSelectionne is CGroupeActeur)
            {
                CGroupeActeur groupe = (CGroupeActeur)m_cmbGroupes.ElementSelectionne;
                //Vérifie que le groupe n'est pas déjà dans la liste
                foreach (ListViewItem item in m_wndListeGroupes.Items)
                {
                    if ((CDbKey)item.Tag == groupe.DbKey)
                    {
                        CFormAlerte.Afficher(I.T("Already added|30095"), EFormAlerteType.Erreur);
                        return;
                    }
                }
                ListViewItem newItem = new ListViewItem(groupe.Libelle);
                newItem.Tag = groupe.DbKey;
                m_wndListeGroupes.Items.Add(newItem);
            }
        }

        //-------------------------------------------------------------------------
        private void m_lnkDelete_LinkClicked(object sender, System.EventArgs e)
        {
            if (m_wndListeGroupes.SelectedItems.Count > 0)
            {
                m_wndListeGroupes.Items.Remove(m_wndListeGroupes.SelectedItems[0]);
            }
        }

        //-------------------------------------------------------------------------
        private void m_menuAjouterSousMenu_Click(object sender, System.EventArgs e)
        {
            if (!m_gestionnaireModeEdition.ModeEdition)
                return;
            TreeNode node = m_arbre.SelectedNode;
            if (node == null)
                return;
            CMenuCustom menu = (CMenuCustom)m_arbre.GetObjetInNode(node);
            CMenuCustom newMenu = new CMenuCustom(MenuCustom.ContexteDonnee);
            newMenu.CreateNewInCurrentContexte();
            newMenu.Libelle = "Nouveau";
            newMenu.NumMenu = menu.ListeMenusFils.Count + 1;
            newMenu.MenuParent = menu;
            TreeNode newNode = new TreeNode();
            m_arbre.FillNode(newNode, newMenu);
            node.Nodes.Add(newNode);
            m_arbre.SelectedNode = node;
        }

        //-------------------------------------------------------------------------
        private void m_menuSupprimerSousMenu_Click(object sender, System.EventArgs e)
        {
            if (!m_gestionnaireModeEdition.ModeEdition)
                return;
            TreeNode node = m_arbre.SelectedNode;
            if (node == null)
                return;
            if (node.Parent == null)
            {
                CFormAlerte.Afficher(I.T("Impossible to delete the menu|30096"), EFormAlerteType.Erreur);
                return;
            }
            CMenuCustom menu = (CMenuCustom)m_arbre.GetObjetInNode(node);
            if (CFormAlerte.Afficher(I.T("Do you want do delete the menu @1 and all its child menus ?|30097", menu.Libelle), EFormAlerteType.Question) == DialogResult.Yes)
            {
                node.Parent.Nodes.Remove(node);
                menu.Delete();
            }
        }

        private void m_arbre_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!m_gestionnaireModeEdition.ModeEdition)
                return;
            if (e.Button == MouseButtons.Right)
            {
                TreeNode node = m_arbre.GetNodeAt(e.X, e.Y);
                if (node == null)
                    return;
                m_arbre.SelectedNode = node;
                m_menuArbre.Show(m_arbre, new Point(e.X, e.Y));
            }
        }

        private void m_btnAction_Click(object sender, System.EventArgs e)
        {
            CActionSur2iLink action = CFormEditActionSurLink.EditeAction(m_menuEdite.Action, null);
            if (action != null)
            {
                m_menuEdite.Action = action;
                m_lblAction.Text = m_menuEdite.Action == null ? "-" : m_menuEdite.Action.ToString();
            }
            /*CFormEditActionSurLink form = new CFormEditActionSurLink();
            form.ActionOriginale = m_menuEdite.Action;
            form.ActionEditee = m_menuEdite.Action;
            if (form.ShowDialog() == DialogResult.OK)
            {
                m_menuEdite.Action = form.ActionEditee;
                m_lblAction.Text = m_menuEdite.Action == null ? "-" : m_menuEdite.Action.ToString();
            }*/
        }

        //-------------------------------------------------------------------------
        private void m_arbre_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (m_gestionnaireModeEdition.ModeEdition)
            {
                TreeNode node = (TreeNode)e.Item;

                if (node != null)
                    DoDragDrop(node, DragDropEffects.None | DragDropEffects.Move);
            }
        }

        //-------------------------------------------------------------------------
        private void m_arbre_DragDrop(object sender, DragEventArgs e)
        {
            CMenuCustom menuDestination = null;

            Point pt = new Point(e.X, e.Y);
            pt = m_arbre.PointToClient(pt);
            TreeNode nodeDestination = m_arbre.GetNodeAt(pt);
            if (nodeDestination != null)
            {
                // Identifier le Module de paramétrage Sur lequel on a fait le Drop
                menuDestination = (CMenuCustom)m_arbre.GetObjetInNode(nodeDestination);
                if (menuDestination != null)
                {
                    TreeNode nodeSource = e.Data.GetData(typeof(TreeNode)) as TreeNode;
                    if (nodeSource != null)
                    {
                        TreeNode parent = nodeDestination;
                        while (parent != null)
                        {
                            if (parent == nodeSource)
                                return;
                            parent = parent.Parent;
                        }


                        CMenuCustom menuAdeplacer = (CMenuCustom)m_arbre.GetObjetInNode(nodeSource);
                        if (menuAdeplacer != null && menuAdeplacer != menuDestination)
                        {
                            menuAdeplacer.MenuParent = menuDestination;
                            m_lastSelectedMenu = menuAdeplacer;
                            InitChamps();
                        }

                    }
                }
            }


        }

        //-------------------------------------------------------------------------
        private void m_arbre_DragOver(object sender, DragEventArgs e)
        {
            if (m_gestionnaireModeEdition.ModeEdition && e.Data.GetData(typeof(TreeNode)) is TreeNode)
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        //-------------------------------------------------------------------------
        private void m_arbre_DragEnter(object sender, DragEventArgs e)
        {
            if (m_gestionnaireModeEdition.ModeEdition && e.Data.GetData(typeof(TreeNode)) is TreeNode)
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void CFormEditionMenuCustom_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void m_lnkAjouterProfil_LinkClicked(object sender, EventArgs e)
        {
            CProfilUtilisateur profil = m_cmbProfils.ElementSelectionne as CProfilUtilisateur;
            if (profil != null)
            {
                //Vérifie que le groupe n'est pas déjà dans la liste
                foreach (ListViewItem item in m_wndListeProfils.Items)
                {
                    if ((CDbKey)item.Tag == profil.DbKey)
                    {
                        CFormAlerte.Afficher(I.T("Already added|30095"), EFormAlerteType.Erreur);
                        return;
                    }
                }
                ListViewItem newItem = new ListViewItem(profil.Libelle);
                newItem.Tag = profil.DbKey;
                m_wndListeProfils.Items.Add(newItem);
            }
        }

        private void m_lnkSupprimerProfil_LinkClicked(object sender, EventArgs e)
        {
            if (m_wndListeProfils.SelectedItems.Count > 0)
            {
                m_wndListeProfils.Items.Remove(m_wndListeProfils.SelectedItems[0]);
            }
        }

        private Image m_imgNewCustomLogoToSave = null;
        private void m_picCustomLogo_MouseClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.tiff;*.tif;*.gif";

            if (ModeEdition && dlg.ShowDialog() == DialogResult.OK)
            {
                string strNomFichier = dlg.FileName;
                try
                {
                    Image logo = Image.FromFile(strNomFichier);
                    if (logo != null)
                    {
                        m_imgNewCustomLogoToSave = logo;
                        m_picCustomLogo.Image = logo;
                    }
                }
                catch (Exception ex)
                {
                    CFormAlerte.Afficher(ex.Message);
                }

            }
        }

    }
}

