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

using timos.acteurs;
using sc2i.workflow;
using timos.data;
using timos.Parametrage.sequences;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CSequenceNumerotation))]
	public class CFormEditionSequenceNumerotation : CFormEditionStdTimos, IFormNavigable
	{
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
        private C2iTabControl m_tabControl;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private Label label2;
        private Label label3;
        private C2iComboSelectDynamicClass m_cmbTypeSource;
        private CComboBoxListeObjetsDonnees m_cmbTypeNumerotation;
        private Label label4;
        private Label label5;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleCle;
        private C2iTextBoxNumerique m_txtStartIndex;
        private Crownwood.Magic.Controls.TabPage m_pageValeurs;
        private Panel m_panelValeurs;
        private Panel panel1;
        private Label label6;
        private Label label7;
        private CControleValeursSequence m_lstValeurs;
        private Panel panel2;
        private Label label8;
        private PictureBox pictureBox6;
        private PictureBox pictureBox5;
        private Button m_btnUnlock;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionSequenceNumerotation()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionSequenceNumerotation(CSequenceNumerotation SequenceNumerotation)
			:base(SequenceNumerotation)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionSequenceNumerotation(CSequenceNumerotation SequenceNumerotation, CListeObjetsDonnees liste)
			:base(SequenceNumerotation, liste)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionSequenceNumerotation));
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageValeurs = new Crownwood.Magic.Controls.TabPage();
            this.m_panelValeurs = new System.Windows.Forms.Panel();
            this.m_lstValeurs = new timos.Parametrage.sequences.CControleValeursSequence();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.m_txtFormuleCle = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.m_txtStartIndex = new sc2i.win32.common.C2iTextBoxNumerique();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_cmbTypeNumerotation = new sc2i.win32.data.CComboBoxListeObjetsDonnees();
            this.label3 = new System.Windows.Forms.Label();
            this.m_cmbTypeSource = new sc2i.win32.common.C2iComboSelectDynamicClass(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.m_btnUnlock = new System.Windows.Forms.Button();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.m_pageValeurs.SuspendLayout();
            this.m_panelValeurs.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
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
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label1, false);
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
            this.m_txtLibelle.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtLibelle, true);
            this.m_txtLibelle.Location = new System.Drawing.Point(132, 8);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(280, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Libelle]";
            // 
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.label1);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iPanelOmbre4, false);
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(8, 52);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(440, 56);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
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
            this.m_tabControl.Location = new System.Drawing.Point(8, 103);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 1;
            this.m_tabControl.SelectedTab = this.m_pageValeurs;
            this.m_tabControl.Size = new System.Drawing.Size(822, 415);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4004;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.m_pageValeurs});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageValeurs
            // 
            this.m_pageValeurs.Controls.Add(this.m_panelValeurs);
            this.m_pageValeurs.Controls.Add(this.panel2);
            this.m_extLinkField.SetLinkField(this.m_pageValeurs, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageValeurs, false);
            this.m_pageValeurs.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageValeurs, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageValeurs, "");
            this.m_pageValeurs.Name = "m_pageValeurs";
            this.m_pageValeurs.Size = new System.Drawing.Size(806, 374);
            this.m_extStyle.SetStyleBackColor(this.m_pageValeurs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageValeurs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageValeurs.TabIndex = 11;
            this.m_pageValeurs.Title = "Values|20835";
            // 
            // m_panelValeurs
            // 
            this.m_panelValeurs.Controls.Add(this.m_lstValeurs);
            this.m_panelValeurs.Controls.Add(this.panel1);
            this.m_panelValeurs.Controls.Add(this.m_btnUnlock);
            this.m_panelValeurs.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.m_panelValeurs, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelValeurs, false);
            this.m_panelValeurs.Location = new System.Drawing.Point(0, 37);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelValeurs, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelValeurs, "");
            this.m_panelValeurs.Name = "m_panelValeurs";
            this.m_panelValeurs.Size = new System.Drawing.Size(232, 337);
            this.m_extStyle.SetStyleBackColor(this.m_panelValeurs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelValeurs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelValeurs.TabIndex = 0;
            // 
            // m_lstValeurs
            // 
            this.m_lstValeurs.CurrentItemIndex = null;
            this.m_lstValeurs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lstValeurs.Items = new sc2i.win32.common.customizableList.CCustomizableListItem[0];
            this.m_extLinkField.SetLinkField(this.m_lstValeurs, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lstValeurs, false);
            this.m_lstValeurs.Location = new System.Drawing.Point(0, 47);
            this.m_lstValeurs.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lstValeurs, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lstValeurs, "");
            this.m_lstValeurs.Name = "m_lstValeurs";
            this.m_lstValeurs.Size = new System.Drawing.Size(232, 290);
            this.m_extStyle.SetStyleBackColor(this.m_lstValeurs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lstValeurs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lstValeurs.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.panel1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.panel1, false);
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel1, "");
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(232, 24);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label6, false);
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label6, "");
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 24);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 0;
            this.label6.Text = "Key|20836";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Dock = System.Windows.Forms.DockStyle.Right;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.m_extLinkField.SetLinkField(this.label7, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label7, false);
            this.label7.Location = new System.Drawing.Point(132, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label7, "");
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 24);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 1;
            this.label7.Text = "Last value|20837";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_txtFormuleCle);
            this.tabPage1.Controls.Add(this.m_txtStartIndex);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.m_cmbTypeNumerotation);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.m_cmbTypeSource);
            this.tabPage1.Controls.Add(this.label2);
            this.m_extLinkField.SetLinkField(this.tabPage1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.tabPage1, false);
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tabPage1, "");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Selected = false;
            this.tabPage1.Size = new System.Drawing.Size(806, 374);
            this.m_extStyle.SetStyleBackColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage1.TabIndex = 10;
            this.tabPage1.Title = "Setup|20485";
            // 
            // m_txtFormuleCle
            // 
            this.m_txtFormuleCle.AllowGraphic = true;
            this.m_txtFormuleCle.AllowNullFormula = false;
            this.m_txtFormuleCle.AllowSaisieTexte = true;
            this.m_txtFormuleCle.Formule = null;
            this.m_extLinkField.SetLinkField(this.m_txtFormuleCle, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtFormuleCle, false);
            this.m_txtFormuleCle.Location = new System.Drawing.Point(150, 87);
            this.m_txtFormuleCle.LockEdition = false;
            this.m_txtFormuleCle.LockZoneTexte = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtFormuleCle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtFormuleCle, "");
            this.m_txtFormuleCle.Name = "m_txtFormuleCle";
            this.m_txtFormuleCle.Size = new System.Drawing.Size(345, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtFormuleCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFormuleCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleCle.TabIndex = 3;
            // 
            // m_txtStartIndex
            // 
            this.m_txtStartIndex.Arrondi = 0;
            this.m_txtStartIndex.DecimalAutorise = false;
            this.m_txtStartIndex.EmptyText = "";
            this.m_txtStartIndex.IntValue = 0;
            this.m_extLinkField.SetLinkField(this.m_txtStartIndex, "ValeurDepart");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtStartIndex, true);
            this.m_txtStartIndex.Location = new System.Drawing.Point(150, 32);
            this.m_txtStartIndex.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtStartIndex, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtStartIndex, "");
            this.m_txtStartIndex.Name = "m_txtStartIndex";
            this.m_txtStartIndex.NullAutorise = false;
            this.m_txtStartIndex.SelectAllOnEnter = true;
            this.m_txtStartIndex.SeparateurMilliers = "";
            this.m_txtStartIndex.Size = new System.Drawing.Size(100, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtStartIndex, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtStartIndex, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtStartIndex.TabIndex = 1;
            this.m_txtStartIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label5, false);
            this.label5.Location = new System.Drawing.Point(16, 35);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 21);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 5;
            this.label5.Text = "Start index|20488";
            // 
            // label4
            // 
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label4, false);
            this.label4.Location = new System.Drawing.Point(16, 87);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 21);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 4;
            this.label4.Text = "Key formula|20487";
            // 
            // m_cmbTypeNumerotation
            // 
            this.m_cmbTypeNumerotation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTypeNumerotation.ElementSelectionne = null;
            this.m_cmbTypeNumerotation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbTypeNumerotation.FormattingEnabled = true;
            this.m_cmbTypeNumerotation.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbTypeNumerotation, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbTypeNumerotation, false);
            this.m_cmbTypeNumerotation.ListDonnees = null;
            this.m_cmbTypeNumerotation.Location = new System.Drawing.Point(150, 5);
            this.m_cmbTypeNumerotation.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbTypeNumerotation, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbTypeNumerotation, "");
            this.m_cmbTypeNumerotation.Name = "m_cmbTypeNumerotation";
            this.m_cmbTypeNumerotation.NullAutorise = false;
            this.m_cmbTypeNumerotation.ProprieteAffichee = null;
            this.m_cmbTypeNumerotation.ProprieteParentListeObjets = null;
            this.m_cmbTypeNumerotation.SelectionneurParent = null;
            this.m_cmbTypeNumerotation.Size = new System.Drawing.Size(347, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbTypeNumerotation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbTypeNumerotation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbTypeNumerotation.TabIndex = 0;
            this.m_cmbTypeNumerotation.TextNull = "(empty)";
            this.m_cmbTypeNumerotation.Tri = true;
            // 
            // label3
            // 
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label3, false);
            this.label3.Location = new System.Drawing.Point(16, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 21);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 2;
            this.label3.Text = "Numbering type|20489";
            // 
            // m_cmbTypeSource
            // 
            this.m_cmbTypeSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTypeSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbTypeSource.FormattingEnabled = true;
            this.m_cmbTypeSource.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbTypeSource, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbTypeSource, false);
            this.m_cmbTypeSource.Location = new System.Drawing.Point(150, 59);
            this.m_cmbTypeSource.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbTypeSource, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbTypeSource, "");
            this.m_cmbTypeSource.Name = "m_cmbTypeSource";
            this.m_cmbTypeSource.Size = new System.Drawing.Size(345, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbTypeSource, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbTypeSource, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbTypeSource.TabIndex = 2;
            this.m_cmbTypeSource.TypeSelectionne = null;
            this.m_cmbTypeSource.SelectionChangeCommitted += new System.EventHandler(this.m_cmbTypeSource_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label2, false);
            this.label2.Location = new System.Drawing.Point(16, 62);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 21);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 0;
            this.label2.Text = "Source type|20486";
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.label8, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label8, true);
            this.label8.Location = new System.Drawing.Point(24, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label8, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label8, "");
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(758, 37);
            this.m_extStyle.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 1;
            this.label8.Text = "WARNING : Manually changing sequence value may cause objects identification probl" +
                "ems in many case. You should use this solution only if you understand the conseq" +
                "uences of this action|20838";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.pictureBox6);
            this.panel2.Controls.Add(this.pictureBox5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.panel2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.panel2, true);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel2, "");
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(806, 37);
            this.m_extStyle.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel2.TabIndex = 2;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox5.Image = global::timos.Properties.Resources.alerte;
            this.m_extLinkField.SetLinkField(this.pictureBox5, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.pictureBox5, true);
            this.pictureBox5.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pictureBox5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pictureBox5, "");
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(24, 37);
            this.m_extStyle.SetStyleBackColor(this.pictureBox5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pictureBox5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pictureBox5.TabIndex = 2;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox6.Image = global::timos.Properties.Resources.alerte;
            this.m_extLinkField.SetLinkField(this.pictureBox6, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.pictureBox6, false);
            this.pictureBox6.Location = new System.Drawing.Point(782, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pictureBox6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pictureBox6, "");
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(24, 37);
            this.m_extStyle.SetStyleBackColor(this.pictureBox6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pictureBox6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pictureBox6.TabIndex = 3;
            this.pictureBox6.TabStop = false;
            // 
            // m_btnUnlock
            // 
            this.m_btnUnlock.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.m_btnUnlock, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnUnlock, true);
            this.m_btnUnlock.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnUnlock, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_btnUnlock, "");
            this.m_btnUnlock.Name = "m_btnUnlock";
            this.m_btnUnlock.Size = new System.Drawing.Size(232, 23);
            this.m_extStyle.SetStyleBackColor(this.m_btnUnlock, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnUnlock, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnUnlock.TabIndex = 2;
            this.m_btnUnlock.Text = "Unlock modification|20839";
            this.m_btnUnlock.UseVisualStyleBackColor = true;
            this.m_btnUnlock.Visible = false;
            this.m_btnUnlock.Click += new System.EventHandler(this.m_btnUnlock_Click);
            // 
            // CFormEditionSequenceNumerotation
            // 
            this.AffectationsPourNouvelElement = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("$this.AffectationsPourNouvelElement")));
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionSequenceNumerotation";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_tabControl;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionSequenceNumerotation_OnInitPage);
            this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionSequenceNumerotation_OnMajChampsPage);
            this.OnChangeModeEdition += new System.EventHandler(this.CFormEditionSequenceNumerotation_OnChangeModeEdition);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre4, 0);
            this.Controls.SetChildIndex(this.m_tabControl, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.c2iPanelOmbre4.ResumeLayout(false);
            this.c2iPanelOmbre4.PerformLayout();
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.m_pageValeurs.ResumeLayout(false);
            this.m_panelValeurs.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CSequenceNumerotation SequenceNumerotation
		{
			get
			{
				return (CSequenceNumerotation)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
			AffecterTitre(I.T( "Numbering sequence @1|20484",SequenceNumerotation.Libelle));
            m_cmbTypeNumerotation.Init(
                typeof(CFormatNumerotation),
                "Libelle",
                false);
            m_cmbTypeNumerotation.ElementSelectionne = SequenceNumerotation.FormatNumerotation;
            m_cmbTypeSource.Init();
            m_cmbTypeSource.TypeSelectionne = SequenceNumerotation.TypeSource;
            m_txtFormuleCle.Init ( new CFournisseurPropDynStd(),
                m_cmbTypeSource.TypeSelectionne);
            m_txtFormuleCle.Formule = SequenceNumerotation.FormuleCle;
			return result;
		}
		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();
            if (!result)
                return result;
            SequenceNumerotation.FormatNumerotation = m_cmbTypeNumerotation.ElementSelectionne as CFormatNumerotation;
            SequenceNumerotation.FormuleCle = m_txtFormuleCle.Formule;
            SequenceNumerotation.TypeSource = m_cmbTypeSource.TypeSelectionne;
            if (SequenceNumerotation.FormuleCle == null)
            {
                if (!m_txtFormuleCle.ResultAnalyse)
                    result.EmpileErreur(m_txtFormuleCle.ResultAnalyse.Erreur);
            }
            return result;
        }

        //-------------------------------------------------------------------------
        private void m_cmbTypeSource_SelectionChangeCommitted(object sender, EventArgs e)
        {
            m_txtFormuleCle.Init(new CFournisseurPropDynStd(),
                m_cmbTypeSource.TypeSelectionne);
        }

        //-------------------------------------------------------------------------
        private CResultAErreur CFormEditionSequenceNumerotation_OnInitPage(object page)
        {
            CResultAErreur result = CResultAErreur.True;
            if (page == m_pageValeurs)
            {
                m_lstValeurs.Init(SequenceNumerotation);
            }
            return result;
        }

        //-------------------------------------------------------------------------
        private CResultAErreur CFormEditionSequenceNumerotation_OnMajChampsPage(object page)
        {
            CResultAErreur result = CResultAErreur.True;
            if (page == m_pageValeurs)
            {
                result = m_lstValeurs.MajChamps();
            }
            return result;
        }

        private void CFormEditionSequenceNumerotation_OnChangeModeEdition(object sender, EventArgs e)
        {
            m_btnUnlock.Visible = m_gestionnaireModeEdition.ModeEdition;
            if (!m_gestionnaireModeEdition.ModeEdition)
                m_lstValeurs.LockEdition = true;
        }

        private void m_btnUnlock_Click(object sender, EventArgs e)
        {
            DialogResult res = CFormAlerte.Afficher(I.T("WARNING : Manually changing sequence value may cause objects identification problems in many case. You should use this solution only if you understand the consequences of this action|20838"),
                EFormAlerteBoutons.OkAbandonner,
                EFormAlerteType.Exclamation);
            if ( res == DialogResult.OK )
            {
                if (m_gestionnaireModeEdition.ModeEdition)
                    m_lstValeurs.LockEdition = false;
                m_btnUnlock.Visible = false;
            }
        }
	}
}

