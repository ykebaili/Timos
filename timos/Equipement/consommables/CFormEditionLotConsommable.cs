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

using timos.data;
using timos.Equipement;
using timos.data.equipement.consommables;

namespace timos
{
    [sc2i.win32.data.navigation.ObjectEditeur(typeof(CLotConsommable))]
    public class CFormEditionLotConsommable : CFormEditionStdTimos, IFormNavigable
    {
        private sc2i.win32.common.C2iPanelOmbre m_panTop;
        private C2iTabControl m_tabControl;
        private ListViewAutoFilledColumn listViewAutoFilledColumn5;
        private Crownwood.Magic.Controls.TabPage m_pagePrporietes;
        private C2iTextBox m_txtCode;
        private Label m_labelCode;
        private Label label3;
        private C2iTextBoxSelectionne m_txtSelectTypeConsommable;
        private sc2i.win32.data.dynamic.CPanelChampsCustom m_panelChamps;
        private Label label2;
        private C2iTextBoxNumerique m_numNombreInitial;
        private Label m_lblUnite;
        private System.ComponentModel.IContainer components = null;

        public CFormEditionLotConsommable()
            : base()
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }
        //-------------------------------------------------------------------------
        public CFormEditionLotConsommable(CLotConsommable LotConsommable)
            : base(LotConsommable)
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }
        //-------------------------------------------------------------------------
        public CFormEditionLotConsommable(CLotConsommable LotConsommable, CListeObjetsDonnees liste)
            : base(LotConsommable, liste)
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
            this.components = new System.ComponentModel.Container();
            this.m_panTop = new sc2i.win32.common.C2iPanelOmbre();
            this.m_txtSelectTypeConsommable = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.label3 = new System.Windows.Forms.Label();
            this.m_labelCode = new System.Windows.Forms.Label();
            this.m_numNombreInitial = new sc2i.win32.common.C2iTextBoxNumerique();
            this.m_txtCode = new sc2i.win32.common.C2iTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_lblUnite = new System.Windows.Forms.Label();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pagePrporietes = new Crownwood.Magic.Controls.TabPage();
            this.m_panelChamps = new sc2i.win32.data.dynamic.CPanelChampsCustom();
            this.listViewAutoFilledColumn5 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.m_panTop.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.m_pagePrporietes.SuspendLayout();
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
            this.m_panelNavigation.Location = new System.Drawing.Point(667, 0);
            this.m_panelNavigation.Size = new System.Drawing.Size(153, 28);
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
            this.m_panelCle.Location = new System.Drawing.Point(580, 0);
            this.m_panelCle.Size = new System.Drawing.Size(87, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(820, 28);
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
            // m_panTop
            // 
            this.m_panTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panTop.Controls.Add(this.m_txtSelectTypeConsommable);
            this.m_panTop.Controls.Add(this.label3);
            this.m_panTop.Controls.Add(this.m_labelCode);
            this.m_panTop.Controls.Add(this.m_numNombreInitial);
            this.m_panTop.Controls.Add(this.m_txtCode);
            this.m_panTop.Controls.Add(this.label2);
            this.m_panTop.Controls.Add(this.m_lblUnite);
            this.m_panTop.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panTop, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panTop, false);
            this.m_panTop.Location = new System.Drawing.Point(8, 52);
            this.m_panTop.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panTop, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panTop, "");
            this.m_panTop.Name = "m_panTop";
            this.m_panTop.Size = new System.Drawing.Size(498, 100);
            this.m_extStyle.SetStyleBackColor(this.m_panTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panTop.TabIndex = 0;
            // 
            // m_txtSelectTypeConsommable
            // 
            this.m_txtSelectTypeConsommable.ElementSelectionne = null;
            this.m_txtSelectTypeConsommable.FonctionTextNull = null;
            this.m_txtSelectTypeConsommable.HasLink = true;
            this.m_extLinkField.SetLinkField(this.m_txtSelectTypeConsommable, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtSelectTypeConsommable, false);
            this.m_txtSelectTypeConsommable.Location = new System.Drawing.Point(164, 33);
            this.m_txtSelectTypeConsommable.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectTypeConsommable, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtSelectTypeConsommable, "");
            this.m_txtSelectTypeConsommable.Name = "m_txtSelectTypeConsommable";
            this.m_txtSelectTypeConsommable.SelectedObject = null;
            this.m_txtSelectTypeConsommable.Size = new System.Drawing.Size(309, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtSelectTypeConsommable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSelectTypeConsommable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectTypeConsommable.TabIndex = 2;
            this.m_txtSelectTypeConsommable.TextNull = "(empty)";
            this.m_txtSelectTypeConsommable.ElementSelectionneChanged += new System.EventHandler(this.m_cmbTypeConsommable_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label3, false);
            this.label3.Location = new System.Drawing.Point(20, 37);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 13);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4004;
            this.label3.Text = "Consumable type|10384";
            // 
            // m_labelCode
            // 
            this.m_extLinkField.SetLinkField(this.m_labelCode, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_labelCode, false);
            this.m_labelCode.Location = new System.Drawing.Point(20, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_labelCode, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_labelCode, "");
            this.m_labelCode.Name = "m_labelCode";
            this.m_labelCode.Size = new System.Drawing.Size(134, 13);
            this.m_extStyle.SetStyleBackColor(this.m_labelCode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_labelCode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_labelCode.TabIndex = 4004;
            this.m_labelCode.Text = "Lot Reference|10383";
            // 
            // m_numNombreInitial
            // 
            this.m_numNombreInitial.Arrondi = 0;
            this.m_numNombreInitial.DecimalAutorise = true;
            this.m_numNombreInitial.EmptyText = "";
            this.m_numNombreInitial.IntValue = 0;
            this.m_extLinkField.SetLinkField(this.m_numNombreInitial, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_numNombreInitial, false);
            this.m_numNombreInitial.Location = new System.Drawing.Point(164, 58);
            this.m_numNombreInitial.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_numNombreInitial, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_numNombreInitial, "");
            this.m_numNombreInitial.Name = "m_numNombreInitial";
            this.m_numNombreInitial.NullAutorise = false;
            this.m_numNombreInitial.SelectAllOnEnter = true;
            this.m_numNombreInitial.SeparateurMilliers = "";
            this.m_numNombreInitial.Size = new System.Drawing.Size(100, 20);
            this.m_extStyle.SetStyleBackColor(this.m_numNombreInitial, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_numNombreInitial, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_numNombreInitial.TabIndex = 4005;
            this.m_numNombreInitial.Text = "0";
            // 
            // m_txtCode
            // 
            this.m_txtCode.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtCode, "Reference");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtCode, true);
            this.m_txtCode.Location = new System.Drawing.Point(164, 9);
            this.m_txtCode.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtCode, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtCode, "");
            this.m_txtCode.Name = "m_txtCode";
            this.m_txtCode.Size = new System.Drawing.Size(309, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtCode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtCode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtCode.TabIndex = 1;
            this.m_txtCode.Text = "[Reference]";
            // 
            // label2
            // 
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label2, false);
            this.label2.Location = new System.Drawing.Point(20, 60);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 16);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4004;
            this.label2.Text = "Initial Count|10387";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblUnite
            // 
            this.m_extLinkField.SetLinkField(this.m_lblUnite, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblUnite, false);
            this.m_lblUnite.Location = new System.Drawing.Point(266, 60);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblUnite, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblUnite, "");
            this.m_lblUnite.Name = "m_lblUnite";
            this.m_lblUnite.Size = new System.Drawing.Size(207, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lblUnite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblUnite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblUnite.TabIndex = 4004;
            this.m_lblUnite.Text = "Libellé de l\'unité (dynamique)";
            this.m_lblUnite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.m_tabControl.Location = new System.Drawing.Point(8, 158);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.m_pagePrporietes;
            this.m_tabControl.Size = new System.Drawing.Size(812, 361);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4004;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pagePrporietes});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_pagePrporietes
            // 
            this.m_pagePrporietes.Controls.Add(this.m_panelChamps);
            this.m_extLinkField.SetLinkField(this.m_pagePrporietes, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pagePrporietes, false);
            this.m_pagePrporietes.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pagePrporietes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pagePrporietes, "");
            this.m_pagePrporietes.Name = "m_pagePrporietes";
            this.m_pagePrporietes.Size = new System.Drawing.Size(796, 320);
            this.m_extStyle.SetStyleBackColor(this.m_pagePrporietes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pagePrporietes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pagePrporietes.TabIndex = 10;
            this.m_pagePrporietes.Title = "Properties|1234";
            // 
            // m_panelChamps
            // 
            this.m_panelChamps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelChamps.BoldSelectedPage = true;
            this.m_panelChamps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelChamps.ElementEdite = null;
            this.m_panelChamps.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_panelChamps, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelChamps, false);
            this.m_panelChamps.Location = new System.Drawing.Point(0, 0);
            this.m_panelChamps.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelChamps, "");
            this.m_panelChamps.Name = "m_panelChamps";
            this.m_panelChamps.Ombre = false;
            this.m_panelChamps.PositionTop = true;
            this.m_panelChamps.Size = new System.Drawing.Size(796, 320);
            this.m_extStyle.SetStyleBackColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelChamps.TabIndex = 9;
            // 
            // listViewAutoFilledColumn5
            // 
            this.listViewAutoFilledColumn5.Field = "TypeEquipement.Libelle";
            this.listViewAutoFilledColumn5.PrecisionWidth = 0;
            this.listViewAutoFilledColumn5.ProportionnalSize = false;
            this.listViewAutoFilledColumn5.Text = "Label|50";
            this.listViewAutoFilledColumn5.Visible = true;
            this.listViewAutoFilledColumn5.Width = 200;
            // 
            // CFormEditionLotConsommable
            // 
            this.ClientSize = new System.Drawing.Size(820, 530);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.m_panTop);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionLotConsommable";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_tabControl;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionLotConsommable_OnInitPage);
            this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionLotConsommable_OnMajChampsPage);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.m_panTop, 0);
            this.Controls.SetChildIndex(this.m_tabControl, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.m_panTop.ResumeLayout(false);
            this.m_panTop.PerformLayout();
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.m_pagePrporietes.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
        //-------------------------------------------------------------------------
        private CLotConsommable LotConsommable
        {
            get
            {
                return (CLotConsommable)ObjetEdite;
            }
        }

        //-------------------------------------------------------------------------
        protected override CResultAErreur MyInitChamps()
        {
            CResultAErreur result = base.MyInitChamps();
            AffecterTitre(I.T("Consumable Lot|10385") + " " + LotConsommable.Reference);

            CFiltreData filtre = new CFiltreData(CTypeConsommable.c_champGestionParLot + "=@1", true);

            m_txtSelectTypeConsommable.InitAvecFiltreDeBase<CTypeConsommable>(
                "Libelle", 
                filtre,
                    true);
            if (LotConsommable != null)
            {
                if (!LotConsommable.IsNew())
                    m_txtSelectTypeConsommable.ElementSelectionne = LotConsommable.TypeConsommable;
                else
                    LotConsommable.TypeConsommable = m_txtSelectTypeConsommable.ElementSelectionne as CTypeConsommable;
                if (LotConsommable.TypeConsommable != null)
                    m_lblUnite.Text = LotConsommable.TypeConsommable.UniteString;
                else
                    m_lblUnite.Text = "";
            }
            DisplayOrHidePanelChamps();

            return result;
        }

        //------------------------------------------------------------------------------------
        private void DisplayOrHidePanelChamps()
        {
            if (LotConsommable.GetFormulaires().Length == 0)
            {
                if (m_tabControl.TabPages.Contains(m_pagePrporietes))
                {
                    if (m_tabControl.TabPages.Count == 1)
                        m_tabControl.Visible = false;
                    else
                        m_tabControl.TabPages.Remove(m_pagePrporietes);
                }
            }
            else
            {
                m_tabControl.Visible = true;
                if (!m_tabControl.TabPages.Contains(m_pagePrporietes))
                    m_tabControl.TabPages.Insert(0, m_pagePrporietes);
            }
        }

        

        //-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();

            if (LotConsommable != null)
            {
                LotConsommable.TypeConsommable = m_txtSelectTypeConsommable.ElementSelectionne as CTypeConsommable;
            }

            return result;
        }

        //-------------------------------------------------------------------------
        private CResultAErreur CFormEditionLotConsommable_OnInitPage(object page)
        {
            CResultAErreur result = CResultAErreur.True;

            if (page == m_pagePrporietes)
            {
                m_panelChamps.ElementEdite = LotConsommable;
            }

            return result;
        }

        //-------------------------------------------------------------------------
        private CResultAErreur CFormEditionLotConsommable_OnMajChampsPage(object page)
        {
            CResultAErreur result = CResultAErreur.True;

            if (page == m_pagePrporietes)
            {
                m_panelChamps.MAJ_Champs();
            }

            return result;
        }

        //-------------------------------------------------------------------------
        private void m_cmbTypeConsommable_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LotConsommable.TypeConsommable = m_txtSelectTypeConsommable.ElementSelectionne as CTypeConsommable;
            DisplayOrHidePanelChamps();
            m_panelChamps.ElementEdite = LotConsommable;
        }
    
    }
}

