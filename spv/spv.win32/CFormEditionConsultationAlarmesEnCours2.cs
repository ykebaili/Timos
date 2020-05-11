using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

using sc2i.data.dynamic;
using sc2i.data;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.common;
using sc2i.win32.data;
using sc2i.win32.common;
using sc2i.expression;
using spv.data.ConsultationAlarmes;
using sc2i.win32.data.dynamic;
using sc2i.formulaire.win32;
using sc2i.documents;

using spv.data;

namespace spv.win32
{
    [sc2i.win32.data.navigation.ObjectEditeur(typeof(CConsultationAlarmesEnCoursInDb))]
    public class CFormEditionConsultationAlarmesEnCours2 : CFormEditionStandard, IFormNavigable
    {
        private string m_strNomFichierLocal;                   // Nom local du fichier sonnerie
        private System.Windows.Forms.Label label1;
        private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
        private Label label9;
        private C2iTextBox m_txtNomParam;
        private Label label2;
        private Label label3;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleFiltre;
        private C2iTextBoxNumerique m_txtDelaiMasquage;
        private Button m_buttonParcourir;
        private C2iTextBox m_txtFichierSonnerie;
        private C2iTabControl m_TabControl;
        private Crownwood.Magic.Controls.TabPage m_pageColonnes;
        private Crownwood.Magic.Controls.TabPage m_pageEMail;
        private CPanelListeSpeedStandard m_panelEmails;
        private CheckBox m_chkActiver;
        private CPanelListChampsExport m_PanelListChampsExport;
        private System.ComponentModel.IContainer components = null;
        public CFormEditionConsultationAlarmesEnCours2()
            : base()
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }
        //-------------------------------------------------------------------------
        public CFormEditionConsultationAlarmesEnCours2(CConsultationAlarmesEnCoursInDb param)
            : base(param)
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }
        //-------------------------------------------------------------------------
        public CFormEditionConsultationAlarmesEnCours2(CConsultationAlarmesEnCoursInDb param, CListeObjetsDonnees liste)
            : base(param, liste)
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
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionConsultationAlarmesEnCours2));
            this.label1 = new System.Windows.Forms.Label();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_txtDelaiMasquage = new sc2i.win32.common.C2iTextBoxNumerique();
            this.label3 = new System.Windows.Forms.Label();
            this.m_buttonParcourir = new System.Windows.Forms.Button();
            this.m_txtFichierSonnerie = new sc2i.win32.common.C2iTextBox();
            this.m_txtFormuleFiltre = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.m_txtNomParam = new sc2i.win32.common.C2iTextBox();
            this.m_TabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageColonnes = new Crownwood.Magic.Controls.TabPage();
            this.m_PanelListChampsExport = new spv.win32.CPanelListChampsExport();
            this.m_pageEMail = new Crownwood.Magic.Controls.TabPage();
            this.m_chkActiver = new System.Windows.Forms.CheckBox();
            this.m_panelEmails = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.m_TabControl.SuspendLayout();
            this.m_pageColonnes.SuspendLayout();
            this.m_pageEMail.SuspendLayout();
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
            this.m_panelNavigation.Location = new System.Drawing.Point(700, 0);
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
            // 
            // m_lblId
            // 
            this.m_extStyle.SetStyleBackColor(this.m_lblId, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblId, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelCle
            // 
            this.m_panelCle.Location = new System.Drawing.Point(613, 0);
            this.m_panelCle.Size = new System.Drawing.Size(87, 34);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.m_panelMenu.Size = new System.Drawing.Size(853, 34);
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
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.m_txtDelaiMasquage);
            this.c2iPanelOmbre4.Controls.Add(this.label3);
            this.c2iPanelOmbre4.Controls.Add(this.m_buttonParcourir);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtFichierSonnerie);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtFormuleFiltre);
            this.c2iPanelOmbre4.Controls.Add(this.label2);
            this.c2iPanelOmbre4.Controls.Add(this.label9);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtNomParam);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(12, 56);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(829, 192);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // m_txtDelaiMasquage
            // 
            this.m_txtDelaiMasquage.Arrondi = 0;
            this.m_txtDelaiMasquage.DecimalAutorise = true;
            this.m_txtDelaiMasquage.IntValue = 0;
            this.m_extLinkField.SetLinkField(this.m_txtDelaiMasquage, "DelaiMasquageTerminnees");
            this.m_txtDelaiMasquage.Location = new System.Drawing.Point(128, 136);
            this.m_txtDelaiMasquage.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtDelaiMasquage, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtDelaiMasquage.Name = "m_txtDelaiMasquage";
            this.m_txtDelaiMasquage.NullAutorise = false;
            this.m_txtDelaiMasquage.SelectAllOnEnter = true;
            this.m_txtDelaiMasquage.Size = new System.Drawing.Size(100, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtDelaiMasquage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtDelaiMasquage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtDelaiMasquage.TabIndex = 4011;
            // 
            // label3
            // 
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(3, 139);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 23);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4010;
            this.label3.Text = "Hide delay|20001";
            // 
            // m_buttonParcourir
            // 
            this.m_extLinkField.SetLinkField(this.m_buttonParcourir, "");
            this.m_buttonParcourir.Location = new System.Drawing.Point(243, 134);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_buttonParcourir, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_buttonParcourir.Name = "m_buttonParcourir";
            this.m_buttonParcourir.Size = new System.Drawing.Size(138, 23);
            this.m_extStyle.SetStyleBackColor(this.m_buttonParcourir, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_buttonParcourir, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_buttonParcourir.TabIndex = 4019;
            this.m_buttonParcourir.Text = "Search sound file|50064";
            this.m_buttonParcourir.UseVisualStyleBackColor = true;
            this.m_buttonParcourir.Click += new System.EventHandler(this.m_buttonParcourir_Click);
            // 
            // m_txtFichierSonnerie
            // 
            this.m_txtFichierSonnerie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_txtFichierSonnerie, "SoundFile");
            this.m_txtFichierSonnerie.Location = new System.Drawing.Point(387, 136);
            this.m_txtFichierSonnerie.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtFichierSonnerie, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtFichierSonnerie.Name = "m_txtFichierSonnerie";
            this.m_txtFichierSonnerie.Size = new System.Drawing.Size(392, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtFichierSonnerie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFichierSonnerie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFichierSonnerie.TabIndex = 4018;
            this.m_txtFichierSonnerie.Text = "[SoundFile]";
            // 
            // m_txtFormuleFiltre
            // 
            this.m_txtFormuleFiltre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormuleFiltre.Formule = null;
            this.m_extLinkField.SetLinkField(this.m_txtFormuleFiltre, "");
            this.m_txtFormuleFiltre.Location = new System.Drawing.Point(128, 41);
            this.m_txtFormuleFiltre.LockEdition = false;
            this.m_txtFormuleFiltre.LockZoneTexte = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtFormuleFiltre, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtFormuleFiltre.Name = "m_txtFormuleFiltre";
            this.m_txtFormuleFiltre.Size = new System.Drawing.Size(678, 84);
            this.m_extStyle.SetStyleBackColor(this.m_txtFormuleFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFormuleFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleFiltre.TabIndex = 4009;
            // 
            // label2
            // 
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(3, 48);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 23);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4008;
            this.label2.Text = "Filter formula|20000";
            // 
            // label9
            // 
            this.m_extLinkField.SetLinkField(this.label9, "");
            this.label9.Location = new System.Drawing.Point(3, 11);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label9, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 23);
            this.m_extStyle.SetStyleBackColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label9.TabIndex = 4006;
            this.label9.Text = "Name|134";
            // 
            // m_txtNomParam
            // 
            this.m_txtNomParam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_txtNomParam, "Libelle");
            this.m_txtNomParam.Location = new System.Drawing.Point(128, 8);
            this.m_txtNomParam.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtNomParam, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtNomParam.Name = "m_txtNomParam";
            this.m_txtNomParam.Size = new System.Drawing.Size(651, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtNomParam, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtNomParam, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtNomParam.TabIndex = 4007;
            this.m_txtNomParam.Text = "[Libelle]";
            // 
            // m_TabControl
            // 
            this.m_TabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_TabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_TabControl.BoldSelectedPage = true;
            this.m_TabControl.ControlBottomOffset = 16;
            this.m_TabControl.ControlRightOffset = 16;
            this.m_TabControl.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_TabControl, "");
            this.m_TabControl.Location = new System.Drawing.Point(12, 254);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_TabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_TabControl.Name = "m_TabControl";
            this.m_TabControl.Ombre = true;
            this.m_TabControl.PositionTop = true;
            this.m_TabControl.SelectedIndex = 1;
            this.m_TabControl.SelectedTab = this.m_pageEMail;
            this.m_TabControl.Size = new System.Drawing.Size(829, 286);
            this.m_extStyle.SetStyleBackColor(this.m_TabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_TabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_TabControl.TabIndex = 4004;
            this.m_TabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageColonnes,
            this.m_pageEMail});
            // 
            // m_pageColonnes
            // 
            this.m_pageColonnes.Controls.Add(this.m_PanelListChampsExport);
            this.m_extLinkField.SetLinkField(this.m_pageColonnes, "");
            this.m_pageColonnes.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageColonnes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_pageColonnes.Name = "m_pageColonnes";
            this.m_pageColonnes.Selected = false;
            this.m_pageColonnes.Size = new System.Drawing.Size(813, 245);
            this.m_extStyle.SetStyleBackColor(this.m_pageColonnes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageColonnes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageColonnes.TabIndex = 10;
            this.m_pageColonnes.Title = "Data to display|60019";
            // 
            // m_PanelListChampsExport
            // 
            this.m_PanelListChampsExport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_PanelListChampsExport, "");
            this.m_PanelListChampsExport.Location = new System.Drawing.Point(6, 3);
            this.m_PanelListChampsExport.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_PanelListChampsExport, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_PanelListChampsExport.Name = "m_PanelListChampsExport";
            this.m_PanelListChampsExport.Size = new System.Drawing.Size(613, 239);
            this.m_extStyle.SetStyleBackColor(this.m_PanelListChampsExport, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_PanelListChampsExport, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_PanelListChampsExport.TabIndex = 0;
            // 
            // m_pageEMail
            // 
            this.m_pageEMail.Controls.Add(this.m_chkActiver);
            this.m_pageEMail.Controls.Add(this.m_panelEmails);
            this.m_extLinkField.SetLinkField(this.m_pageEMail, "");
            this.m_pageEMail.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageEMail, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_pageEMail.Name = "m_pageEMail";
            this.m_pageEMail.Size = new System.Drawing.Size(813, 245);
            this.m_extStyle.SetStyleBackColor(this.m_pageEMail, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageEMail, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageEMail.TabIndex = 11;
            this.m_pageEMail.Title = "Mailing list|60060";
            // 
            // m_chkActiver
            // 
            this.m_chkActiver.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkActiver, "");
            this.m_chkActiver.Location = new System.Drawing.Point(14, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkActiver, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkActiver.Name = "m_chkActiver";
            this.m_chkActiver.Size = new System.Drawing.Size(100, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkActiver, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkActiver, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkActiver.TabIndex = 1;
            this.m_chkActiver.Text = "Activate|60061";
            this.m_chkActiver.UseVisualStyleBackColor = true;
            // 
            // m_panelEmails
            // 
            this.m_panelEmails.AllowArbre = true;
            this.m_panelEmails.AllowCustomisation = true;
            this.m_panelEmails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "Email";
            glColumn1.Propriete = "Email";
            glColumn1.Text = "Email";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 100;
            this.m_panelEmails.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1});
            this.m_panelEmails.ContexteUtilisation = "";
            this.m_panelEmails.ControlFiltreStandard = null;
            this.m_panelEmails.ElementSelectionne = null;
            this.m_panelEmails.EnableCustomisation = true;
            this.m_panelEmails.FiltreDeBase = null;
            this.m_panelEmails.FiltreDeBaseEnAjout = false;
            this.m_panelEmails.FiltrePrefere = null;
            this.m_panelEmails.FiltreRapide = null;
            this.m_panelEmails.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panelEmails, "");
            this.m_panelEmails.ListeObjets = null;
            this.m_panelEmails.Location = new System.Drawing.Point(4, 35);
            this.m_panelEmails.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEmails, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelEmails.ModeQuickSearch = false;
            this.m_panelEmails.ModeSelection = false;
            this.m_panelEmails.MultiSelect = false;
            this.m_panelEmails.Name = "m_panelEmails";
            this.m_panelEmails.Navigateur = null;
            this.m_panelEmails.ProprieteObjetAEditer = null;
            this.m_panelEmails.QuickSearchText = "";
            this.m_panelEmails.Size = new System.Drawing.Size(803, 207);
            this.m_extStyle.SetStyleBackColor(this.m_panelEmails, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEmails, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEmails.TabIndex = 0;
            this.m_panelEmails.TrierAuClicSurEnteteColonne = true;
            // 
            // CFormEditionConsultationAlarmesEnCours2
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(853, 552);
            this.Controls.Add(this.m_TabControl);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CFormEditionConsultationAlarmesEnCours2";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre4, 0);
            this.Controls.SetChildIndex(this.m_TabControl, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.c2iPanelOmbre4.ResumeLayout(false);
            this.c2iPanelOmbre4.PerformLayout();
            this.m_TabControl.ResumeLayout(false);
            this.m_TabControl.PerformLayout();
            this.m_pageColonnes.ResumeLayout(false);
            this.m_pageEMail.ResumeLayout(false);
            this.m_pageEMail.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        //-------------------------------------------------------------------------
        protected CConsultationAlarmesEnCoursInDb Consultation
        {
            get
            {
                return (CConsultationAlarmesEnCoursInDb)ObjetEdite;
            }
        }
        //-------------------------------------------------------------------------
        protected override CResultAErreur InitChamps()
        {
            CResultAErreur result = base.InitChamps();

            AffecterTitre(I.T("Current alarms consultation @1|30013",Consultation.Libelle));

            CConsultationAlarmesEnCours parametre = Consultation.Parametres;

            m_txtDelaiMasquage.Text = parametre.DelaiMasquageTerminnees.ToString();

            m_txtFormuleFiltre.Init(new CFournisseurGeneriqueProprietesDynamiques(),
                typeof(CInfoAlarmeAffichee));
            m_txtFormuleFiltre.Formule = parametre.FormuleFiltre;

            List<C2iChampExport> tmpListe = new List<C2iChampExport>();
            foreach (C2iChampExport champ in parametre.ListeColonnes)
                tmpListe.Add(champ);

            //m_PanelListChampsExport.InitChamps(tmpListe, typeof(C2iChampExport));
            m_PanelListChampsExport.InitChamps(tmpListe, typeof(CInfoAlarmeAffichee), null);

            m_chkActiver.Checked = Consultation.ActiverEMail;

            CListeObjetsDonnees list = Consultation.Emails;
            int nb = list.Count;

            m_panelEmails.InitFromListeObjets(Consultation.Emails,
                typeof(CParamlArmEC_EMail),
                typeof(CFormEditionEmail),
                Consultation,
                "ConsultationAlarmesEnCours");

            return result;
        }
        //-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();
            if (!result)
                return result;

            CConsultationAlarmesEnCours param = Consultation.Parametres;
            param.FormuleFiltre = m_txtFormuleFiltre.Formule;
            m_PanelListChampsExport.MajChamps();
            param.ListeColonnes = m_PanelListChampsExport.ListeChamps;
            param.DelaiMasquageTerminnees = (m_txtDelaiMasquage.Text.Length>0)? Convert.ToInt32(m_txtDelaiMasquage.Text) :0;
            Consultation.Parametres = param;

            if (File.Exists(m_strNomFichierLocal))
            {
                Consultation.SoundFile = m_txtFichierSonnerie.Text;
                CDocumentGED doc = Consultation.DocumentGEDSoundFile;
                CProxyGED proxy = new CProxyGED(Consultation.ContexteDonnee.IdSession,
                    doc == null ? null : doc.ReferenceDoc);
                proxy.AttacheToLocal(Consultation.SoundFile);
                result = proxy.UpdateGed();
                if (result)
                {
                    if (doc == null)
                    {
                        doc = new CDocumentGED(Consultation.ContexteDonnee);
                        doc.CreateNewInCurrentContexte();
                        doc.Descriptif = "";
                        doc.DateCreation = DateTime.Now;
                        Consultation.DocumentGEDSoundFile = doc;
                    }
                    doc.Libelle = I.T("Alarm sound file|50065");
                    doc.ReferenceDoc = (CReferenceDocument)result.Data;
                    doc.DateMAJ = DateTime.Now;
                    doc.NumVersion++;
                    doc.IsFichierSysteme = true;
                    Consultation.DocumentGEDSoundFile = doc;
                }
            }

            Consultation.ActiverEMail = m_chkActiver.Checked;

            return result;
        }

        private void m_buttonParcourir_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                m_strNomFichierLocal = dlg.FileName;
                m_txtFichierSonnerie.Text = dlg.FileName;
            }
        }
    }
}

