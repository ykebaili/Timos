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

using sc2i.workflow;
using timos.data.supervision;
using futurocom.supervision.alarmes;
using futurocom.supervision;
using sc2i.expression;
using sc2i.win32.expression;
using System.Collections.Generic;
using sc2i.documents;
using System.IO;
using timos.supervision;
using sc2i.formulaire;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CParametrageAffichageListeAlarmes))]
	public class CFormEditionParametrageAffichageListeAlarmes : CFormEditionStdTimos, IFormNavigable
	{
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
        private C2iTextBox c2iTextBox1;
        private Label label2;
        private C2iTabControl m_tabControl;
        private Crownwood.Magic.Controls.TabPage m_pageColonnes;
        private Label label6;
        private Crownwood.Magic.Controls.TabPage m_pageGeneral;
        private NumericUpDown m_numHauteurLigne;
        private Label label4;
        private GroupBox groupBox1;
        private NumericUpDown m_numLargeurEnteteLigne;
        private Label label3;
        private Label label5;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleFiltre;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleOnNewAlarme;
        private Label label7;
        private Label label9;
        private Label label8;
        private sc2i.win32.expression.CControlSelectColorByFormule m_selectItemBackColor;
        private sc2i.win32.expression.CControlSelectColorByFormule m_selectItemForeColor;
        private Label label11;
        private Label label10;
        private NumericUpDown m_numDureePersistance;
        private Label label12;
        private Label label13;
        private Label label14;
        private ErrorProvider m_errorProvider;
        private Panel m_panelTotal;
        private Panel m_panelInfoColonne;
        private Button m_btnSelectFont;
        private Label m_lblPoliceEnteteCol;
        private Label label17;
        private Button m_btnNoTextColor;
        private PictureBox m_picTextColorEnteteCol;
        private Label label18;
        private Button m_btnNoBackgroundColor;
        private PictureBox m_picBackColorEnteteCol;
        private Label label19;
        private CTextBoxZoomFormule m_txtFormuleColonne;
        private NumericUpDown m_numLargeurColonne;
        private Label label20;
        private Label label21;
        private TextBox m_txtTitreColonne;
        private Label label22;
        private Panel m_panelGauche;
        private Button m_btnBas;
        private Button m_btnHaut;
        private CWndLinkStd m_btnRemoveColonne;
        private CWndLinkStd m_btnAddColonne;
        private ListBox m_wndListeColonnes;
        private GroupBox groupBox2;
        private NumericUpDown m_numHauteurEnteteCol;
        private Label label15;
        private Button m_btnParcourirFichierSon;
        private C2iTextBox m_txtNomFichierSon;
        private LinkLabel m_lnkPlaySound;
        private Button m_btnSupprimerFichierSon;
        private Button m_btnAfficherAlarmes;
        private PictureBox m_imageLink;
        private LinkLabel m_lnkAction;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionParametrageAffichageListeAlarmes()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionParametrageAffichageListeAlarmes(CParametrageAffichageListeAlarmes civilite)
			:base(civilite)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionParametrageAffichageListeAlarmes(CParametrageAffichageListeAlarmes civilite, CListeObjetsDonnees liste)
			:base(civilite, liste)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionParametrageAffichageListeAlarmes));
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_btnAfficherAlarmes = new System.Windows.Forms.Button();
            this.c2iTextBox1 = new sc2i.win32.common.C2iTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageColonnes = new Crownwood.Magic.Controls.TabPage();
            this.m_numHauteurEnteteCol = new System.Windows.Forms.NumericUpDown();
            this.m_panelTotal = new System.Windows.Forms.Panel();
            this.m_panelInfoColonne = new System.Windows.Forms.Panel();
            this.m_imageLink = new System.Windows.Forms.PictureBox();
            this.m_lnkAction = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_picBackColorEnteteCol = new System.Windows.Forms.PictureBox();
            this.m_btnSelectFont = new System.Windows.Forms.Button();
            this.m_btnNoBackgroundColor = new System.Windows.Forms.Button();
            this.m_lblPoliceEnteteCol = new System.Windows.Forms.Label();
            this.m_picTextColorEnteteCol = new System.Windows.Forms.PictureBox();
            this.label17 = new System.Windows.Forms.Label();
            this.m_btnNoTextColor = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.m_txtFormuleColonne = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.m_numLargeurColonne = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.m_txtTitreColonne = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.m_panelGauche = new System.Windows.Forms.Panel();
            this.m_btnBas = new System.Windows.Forms.Button();
            this.m_btnHaut = new System.Windows.Forms.Button();
            this.m_btnRemoveColonne = new sc2i.win32.common.CWndLinkStd();
            this.m_btnAddColonne = new sc2i.win32.common.CWndLinkStd();
            this.m_wndListeColonnes = new System.Windows.Forms.ListBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_pageGeneral = new Crownwood.Magic.Controls.TabPage();
            this.m_lnkPlaySound = new System.Windows.Forms.LinkLabel();
            this.m_btnSupprimerFichierSon = new System.Windows.Forms.Button();
            this.m_btnParcourirFichierSon = new System.Windows.Forms.Button();
            this.m_txtNomFichierSon = new sc2i.win32.common.C2iTextBox();
            this.m_numDureePersistance = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.m_txtFormuleOnNewAlarme = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.label7 = new System.Windows.Forms.Label();
            this.m_txtFormuleFiltre = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_selectItemBackColor = new sc2i.win32.expression.CControlSelectColorByFormule();
            this.m_selectItemForeColor = new sc2i.win32.expression.CControlSelectColorByFormule();
            this.label9 = new System.Windows.Forms.Label();
            this.m_numLargeurEnteteLigne = new System.Windows.Forms.NumericUpDown();
            this.m_numHauteurLigne = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.m_pageColonnes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_numHauteurEnteteCol)).BeginInit();
            this.m_panelTotal.SuspendLayout();
            this.m_panelInfoColonne.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageLink)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_picBackColorEnteteCol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picTextColorEnteteCol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numLargeurColonne)).BeginInit();
            this.m_panelGauche.SuspendLayout();
            this.m_pageGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_numDureePersistance)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_numLargeurEnteteLigne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numHauteurLigne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_errorProvider)).BeginInit();
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
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label1, "");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4002;
            this.label1.Text = "Label |50";
            // 
            // m_txtLibelle
            // 
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_txtLibelle.Location = new System.Drawing.Point(132, 8);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(356, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Libelle]";
            // 
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.m_btnAfficherAlarmes);
            this.c2iPanelOmbre4.Controls.Add(this.label1);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.Controls.Add(this.c2iTextBox1);
            this.c2iPanelOmbre4.Controls.Add(this.label2);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(8, 52);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(537, 92);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // m_btnAfficherAlarmes
            // 
            this.m_btnAfficherAlarmes.BackColor = System.Drawing.Color.Transparent;
            this.m_btnAfficherAlarmes.FlatAppearance.BorderSize = 0;
            this.m_btnAfficherAlarmes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_btnAfficherAlarmes.ForeColor = System.Drawing.Color.Blue;
            this.m_extLinkField.SetLinkField(this.m_btnAfficherAlarmes, "");
            this.m_btnAfficherAlarmes.Location = new System.Drawing.Point(398, 33);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAfficherAlarmes, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnAfficherAlarmes, "");
            this.m_btnAfficherAlarmes.Name = "m_btnAfficherAlarmes";
            this.m_btnAfficherAlarmes.Size = new System.Drawing.Size(90, 22);
            this.m_extStyle.SetStyleBackColor(this.m_btnAfficherAlarmes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAfficherAlarmes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAfficherAlarmes.TabIndex = 4003;
            this.m_btnAfficherAlarmes.Text = "Display|10247";
            this.m_btnAfficherAlarmes.UseVisualStyleBackColor = false;
            this.m_btnAfficherAlarmes.Click += new System.EventHandler(this.m_btnAfficherAlarmes_Click);
            // 
            // c2iTextBox1
            // 
            this.m_extLinkField.SetLinkField(this.c2iTextBox1, "Code");
            this.c2iTextBox1.Location = new System.Drawing.Point(132, 34);
            this.c2iTextBox1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBox1, "");
            this.c2iTextBox1.Name = "c2iTextBox1";
            this.c2iTextBox1.Size = new System.Drawing.Size(256, 20);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox1.TabIndex = 0;
            this.c2iTextBox1.Text = "[Code]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(16, 38);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4002;
            this.label2.Text = "Code|231";
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
            this.m_tabControl.SelectedTab = this.m_pageGeneral;
            this.m_tabControl.Size = new System.Drawing.Size(819, 413);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4005;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageGeneral,
            this.m_pageColonnes});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageColonnes
            // 
            this.m_pageColonnes.Controls.Add(this.m_numHauteurEnteteCol);
            this.m_pageColonnes.Controls.Add(this.m_panelTotal);
            this.m_pageColonnes.Controls.Add(this.label15);
            this.m_pageColonnes.Controls.Add(this.label6);
            this.m_extLinkField.SetLinkField(this.m_pageColonnes, "");
            this.m_pageColonnes.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageColonnes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageColonnes, "");
            this.m_pageColonnes.Name = "m_pageColonnes";
            this.m_pageColonnes.Selected = false;
            this.m_pageColonnes.Size = new System.Drawing.Size(803, 372);
            this.m_extStyle.SetStyleBackColor(this.m_pageColonnes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageColonnes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageColonnes.TabIndex = 11;
            this.m_pageColonnes.Title = "Columns Setting|10227";
            // 
            // m_numHauteurEnteteCol
            // 
            this.m_extLinkField.SetLinkField(this.m_numHauteurEnteteCol, "");
            this.m_numHauteurEnteteCol.Location = new System.Drawing.Point(530, 13);
            this.m_numHauteurEnteteCol.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_numHauteurEnteteCol, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_numHauteurEnteteCol, "");
            this.m_numHauteurEnteteCol.Name = "m_numHauteurEnteteCol";
            this.m_numHauteurEnteteCol.Size = new System.Drawing.Size(66, 23);
            this.m_extStyle.SetStyleBackColor(this.m_numHauteurEnteteCol, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_numHauteurEnteteCol, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_numHauteurEnteteCol.TabIndex = 21;
            // 
            // m_panelTotal
            // 
            this.m_panelTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panelTotal.Controls.Add(this.m_panelInfoColonne);
            this.m_panelTotal.Controls.Add(this.m_panelGauche);
            this.m_extLinkField.SetLinkField(this.m_panelTotal, "");
            this.m_panelTotal.Location = new System.Drawing.Point(19, 46);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelTotal, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelTotal, "");
            this.m_panelTotal.Name = "m_panelTotal";
            this.m_panelTotal.Size = new System.Drawing.Size(751, 309);
            this.m_extStyle.SetStyleBackColor(this.m_panelTotal, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelTotal, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelTotal.TabIndex = 5;
            // 
            // m_panelInfoColonne
            // 
            this.m_panelInfoColonne.Controls.Add(this.m_imageLink);
            this.m_panelInfoColonne.Controls.Add(this.m_lnkAction);
            this.m_panelInfoColonne.Controls.Add(this.groupBox2);
            this.m_panelInfoColonne.Controls.Add(this.m_txtFormuleColonne);
            this.m_panelInfoColonne.Controls.Add(this.m_numLargeurColonne);
            this.m_panelInfoColonne.Controls.Add(this.label20);
            this.m_panelInfoColonne.Controls.Add(this.label21);
            this.m_panelInfoColonne.Controls.Add(this.m_txtTitreColonne);
            this.m_panelInfoColonne.Controls.Add(this.label22);
            this.m_extLinkField.SetLinkField(this.m_panelInfoColonne, "");
            this.m_panelInfoColonne.Location = new System.Drawing.Point(248, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelInfoColonne, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelInfoColonne, "");
            this.m_panelInfoColonne.Name = "m_panelInfoColonne";
            this.m_panelInfoColonne.Size = new System.Drawing.Size(447, 262);
            this.m_extStyle.SetStyleBackColor(this.m_panelInfoColonne, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelInfoColonne, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelInfoColonne.TabIndex = 3;
            this.m_panelInfoColonne.Visible = false;
            // 
            // m_imageLink
            // 
            this.m_imageLink.Image = ((System.Drawing.Image)(resources.GetObject("m_imageLink.Image")));
            this.m_extLinkField.SetLinkField(this.m_imageLink, "");
            this.m_imageLink.Location = new System.Drawing.Point(26, 233);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_imageLink, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_imageLink, "");
            this.m_imageLink.Name = "m_imageLink";
            this.m_imageLink.Size = new System.Drawing.Size(16, 16);
            this.m_imageLink.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.m_extStyle.SetStyleBackColor(this.m_imageLink, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_imageLink, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_imageLink.TabIndex = 24;
            this.m_imageLink.TabStop = false;
            // 
            // m_lnkAction
            // 
            this.m_lnkAction.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lnkAction, "");
            this.m_lnkAction.Location = new System.Drawing.Point(43, 234);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAction, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkAction, "");
            this.m_lnkAction.Name = "m_lnkAction";
            this.m_lnkAction.Size = new System.Drawing.Size(98, 15);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAction, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAction, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAction.TabIndex = 23;
            this.m_lnkAction.TabStop = true;
            this.m_lnkAction.Text = "Link action|10271";
            this.m_lnkAction.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkAction_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_picBackColorEnteteCol);
            this.groupBox2.Controls.Add(this.m_btnSelectFont);
            this.groupBox2.Controls.Add(this.m_btnNoBackgroundColor);
            this.groupBox2.Controls.Add(this.m_lblPoliceEnteteCol);
            this.groupBox2.Controls.Add(this.m_picTextColorEnteteCol);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.m_btnNoTextColor);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label18);
            this.m_extLinkField.SetLinkField(this.groupBox2, "");
            this.groupBox2.Location = new System.Drawing.Point(6, 94);
            this.m_gestionnaireModeEdition.SetModeEdition(this.groupBox2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.groupBox2, "");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(433, 126);
            this.m_extStyle.SetStyleBackColor(this.groupBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.groupBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Column Header|10241";
            // 
            // m_picBackColorEnteteCol
            // 
            this.m_picBackColorEnteteCol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_picBackColorEnteteCol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_extLinkField.SetLinkField(this.m_picBackColorEnteteCol, "");
            this.m_picBackColorEnteteCol.Location = new System.Drawing.Point(108, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_picBackColorEnteteCol, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_picBackColorEnteteCol, "");
            this.m_picBackColorEnteteCol.Name = "m_picBackColorEnteteCol";
            this.m_picBackColorEnteteCol.Size = new System.Drawing.Size(51, 20);
            this.m_extStyle.SetStyleBackColor(this.m_picBackColorEnteteCol, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_picBackColorEnteteCol, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_picBackColorEnteteCol.TabIndex = 11;
            this.m_picBackColorEnteteCol.TabStop = false;
            this.m_picBackColorEnteteCol.Click += new System.EventHandler(this.m_picBkColor_Click);
            // 
            // m_btnSelectFont
            // 
            this.m_extLinkField.SetLinkField(this.m_btnSelectFont, "");
            this.m_btnSelectFont.Location = new System.Drawing.Point(399, 75);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnSelectFont, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnSelectFont, "");
            this.m_btnSelectFont.Name = "m_btnSelectFont";
            this.m_btnSelectFont.Size = new System.Drawing.Size(24, 24);
            this.m_extStyle.SetStyleBackColor(this.m_btnSelectFont, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSelectFont, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnSelectFont.TabIndex = 19;
            this.m_btnSelectFont.Text = "...";
            this.m_btnSelectFont.UseVisualStyleBackColor = true;
            this.m_btnSelectFont.Click += new System.EventHandler(this.m_btnSelectFont_Click);
            // 
            // m_btnNoBackgroundColor
            // 
            this.m_extLinkField.SetLinkField(this.m_btnNoBackgroundColor, "");
            this.m_btnNoBackgroundColor.Location = new System.Drawing.Point(161, 23);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnNoBackgroundColor, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnNoBackgroundColor, "");
            this.m_btnNoBackgroundColor.Name = "m_btnNoBackgroundColor";
            this.m_btnNoBackgroundColor.Size = new System.Drawing.Size(24, 24);
            this.m_extStyle.SetStyleBackColor(this.m_btnNoBackgroundColor, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnNoBackgroundColor, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnNoBackgroundColor.TabIndex = 12;
            this.m_btnNoBackgroundColor.Text = "x";
            this.m_btnNoBackgroundColor.UseVisualStyleBackColor = true;
            this.m_btnNoBackgroundColor.Click += new System.EventHandler(this.m_btnNoBackgroundColor_Click);
            // 
            // m_lblPoliceEnteteCol
            // 
            this.m_lblPoliceEnteteCol.BackColor = System.Drawing.Color.White;
            this.m_lblPoliceEnteteCol.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblPoliceEnteteCol.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.m_lblPoliceEnteteCol, "");
            this.m_lblPoliceEnteteCol.Location = new System.Drawing.Point(108, 75);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblPoliceEnteteCol, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblPoliceEnteteCol, "");
            this.m_lblPoliceEnteteCol.Name = "m_lblPoliceEnteteCol";
            this.m_lblPoliceEnteteCol.Size = new System.Drawing.Size(289, 23);
            this.m_extStyle.SetStyleBackColor(this.m_lblPoliceEnteteCol, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblPoliceEnteteCol, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblPoliceEnteteCol.TabIndex = 17;
            // 
            // m_picTextColorEnteteCol
            // 
            this.m_picTextColorEnteteCol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_picTextColorEnteteCol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_extLinkField.SetLinkField(this.m_picTextColorEnteteCol, "");
            this.m_picTextColorEnteteCol.Location = new System.Drawing.Point(108, 48);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_picTextColorEnteteCol, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_picTextColorEnteteCol, "");
            this.m_picTextColorEnteteCol.Name = "m_picTextColorEnteteCol";
            this.m_picTextColorEnteteCol.Size = new System.Drawing.Size(51, 20);
            this.m_extStyle.SetStyleBackColor(this.m_picTextColorEnteteCol, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_picTextColorEnteteCol, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_picTextColorEnteteCol.TabIndex = 14;
            this.m_picTextColorEnteteCol.TabStop = false;
            this.m_picTextColorEnteteCol.Click += new System.EventHandler(this.m_picTextColor_Click);
            // 
            // label17
            // 
            this.m_extLinkField.SetLinkField(this.label17, "");
            this.label17.Location = new System.Drawing.Point(6, 79);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label17, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label17, "");
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(137, 15);
            this.m_extStyle.SetStyleBackColor(this.label17, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label17, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label17.TabIndex = 16;
            this.label17.Text = "Text Font|10244";
            // 
            // m_btnNoTextColor
            // 
            this.m_extLinkField.SetLinkField(this.m_btnNoTextColor, "");
            this.m_btnNoTextColor.Location = new System.Drawing.Point(161, 46);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnNoTextColor, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnNoTextColor, "");
            this.m_btnNoTextColor.Name = "m_btnNoTextColor";
            this.m_btnNoTextColor.Size = new System.Drawing.Size(24, 24);
            this.m_extStyle.SetStyleBackColor(this.m_btnNoTextColor, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnNoTextColor, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnNoTextColor.TabIndex = 15;
            this.m_btnNoTextColor.Text = "x";
            this.m_btnNoTextColor.UseVisualStyleBackColor = true;
            this.m_btnNoTextColor.Click += new System.EventHandler(this.m_btnNoTextColor_Click);
            // 
            // label19
            // 
            this.m_extLinkField.SetLinkField(this.label19, "");
            this.label19.Location = new System.Drawing.Point(6, 28);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label19, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label19, "");
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(137, 15);
            this.m_extStyle.SetStyleBackColor(this.label19, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label19, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label19.TabIndex = 10;
            this.label19.Text = "Back Color|10242";
            // 
            // label18
            // 
            this.m_extLinkField.SetLinkField(this.label18, "");
            this.label18.Location = new System.Drawing.Point(6, 51);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label18, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label18, "");
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(118, 15);
            this.m_extStyle.SetStyleBackColor(this.label18, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label18, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label18.TabIndex = 13;
            this.label18.Text = "Text Color|10243";
            // 
            // m_txtFormuleColonne
            // 
            this.m_txtFormuleColonne.AllowGraphic = true;
            this.m_txtFormuleColonne.AllowSaisieTexte = true;
            this.m_txtFormuleColonne.Formule = null;
            this.m_extLinkField.SetLinkField(this.m_txtFormuleColonne, "");
            this.m_txtFormuleColonne.Location = new System.Drawing.Point(105, 33);
            this.m_txtFormuleColonne.LockEdition = false;
            this.m_txtFormuleColonne.LockZoneTexte = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtFormuleColonne, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtFormuleColonne, "");
            this.m_txtFormuleColonne.Name = "m_txtFormuleColonne";
            this.m_txtFormuleColonne.Size = new System.Drawing.Size(334, 24);
            this.m_extStyle.SetStyleBackColor(this.m_txtFormuleColonne, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFormuleColonne, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleColonne.TabIndex = 6;
            // 
            // m_numLargeurColonne
            // 
            this.m_extLinkField.SetLinkField(this.m_numLargeurColonne, "");
            this.m_numLargeurColonne.Location = new System.Drawing.Point(105, 60);
            this.m_numLargeurColonne.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_numLargeurColonne, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_numLargeurColonne, "");
            this.m_numLargeurColonne.Name = "m_numLargeurColonne";
            this.m_numLargeurColonne.Size = new System.Drawing.Size(66, 23);
            this.m_extStyle.SetStyleBackColor(this.m_numLargeurColonne, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_numLargeurColonne, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_numLargeurColonne.TabIndex = 5;
            // 
            // label20
            // 
            this.m_extLinkField.SetLinkField(this.label20, "");
            this.label20.Location = new System.Drawing.Point(3, 63);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label20, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label20, "");
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(118, 15);
            this.m_extStyle.SetStyleBackColor(this.label20, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label20, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label20.TabIndex = 4;
            this.label20.Text = "Width|10239";
            // 
            // label21
            // 
            this.m_extLinkField.SetLinkField(this.label21, "");
            this.label21.Location = new System.Drawing.Point(3, 35);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label21, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label21, "");
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(126, 15);
            this.m_extStyle.SetStyleBackColor(this.label21, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label21, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label21.TabIndex = 2;
            this.label21.Text = "Content|10238";
            // 
            // m_txtTitreColonne
            // 
            this.m_txtTitreColonne.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_txtTitreColonne, "");
            this.m_txtTitreColonne.Location = new System.Drawing.Point(105, 7);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtTitreColonne, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtTitreColonne, "");
            this.m_txtTitreColonne.Name = "m_txtTitreColonne";
            this.m_txtTitreColonne.Size = new System.Drawing.Size(334, 23);
            this.m_extStyle.SetStyleBackColor(this.m_txtTitreColonne, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtTitreColonne, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtTitreColonne.TabIndex = 1;
            // 
            // label22
            // 
            this.m_extLinkField.SetLinkField(this.label22, "");
            this.label22.Location = new System.Drawing.Point(3, 11);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label22, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label22, "");
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(104, 15);
            this.m_extStyle.SetStyleBackColor(this.label22, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label22, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label22.TabIndex = 0;
            this.label22.Text = "Title|10237";
            // 
            // m_panelGauche
            // 
            this.m_panelGauche.Controls.Add(this.m_btnBas);
            this.m_panelGauche.Controls.Add(this.m_btnHaut);
            this.m_panelGauche.Controls.Add(this.m_btnRemoveColonne);
            this.m_panelGauche.Controls.Add(this.m_btnAddColonne);
            this.m_panelGauche.Controls.Add(this.m_wndListeColonnes);
            this.m_panelGauche.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.m_panelGauche, "");
            this.m_panelGauche.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelGauche, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelGauche, "");
            this.m_panelGauche.Name = "m_panelGauche";
            this.m_panelGauche.Size = new System.Drawing.Size(233, 307);
            this.m_extStyle.SetStyleBackColor(this.m_panelGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelGauche.TabIndex = 2;
            // 
            // m_btnBas
            // 
            this.m_btnBas.Image = ((System.Drawing.Image)(resources.GetObject("m_btnBas.Image")));
            this.m_extLinkField.SetLinkField(this.m_btnBas, "");
            this.m_btnBas.Location = new System.Drawing.Point(173, 252);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnBas, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnBas, "");
            this.m_btnBas.Name = "m_btnBas";
            this.m_btnBas.Size = new System.Drawing.Size(27, 22);
            this.m_extStyle.SetStyleBackColor(this.m_btnBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnBas.TabIndex = 6;
            this.m_btnBas.UseVisualStyleBackColor = true;
            this.m_btnBas.Click += new System.EventHandler(this.m_btnBas_Click);
            // 
            // m_btnHaut
            // 
            this.m_btnHaut.Image = ((System.Drawing.Image)(resources.GetObject("m_btnHaut.Image")));
            this.m_extLinkField.SetLinkField(this.m_btnHaut, "");
            this.m_btnHaut.Location = new System.Drawing.Point(199, 252);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnHaut, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnHaut, "");
            this.m_btnHaut.Name = "m_btnHaut";
            this.m_btnHaut.Size = new System.Drawing.Size(27, 22);
            this.m_extStyle.SetStyleBackColor(this.m_btnHaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnHaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnHaut.TabIndex = 5;
            this.m_btnHaut.UseVisualStyleBackColor = true;
            this.m_btnHaut.Click += new System.EventHandler(this.m_btnHaut_Click);
            // 
            // m_btnRemoveColonne
            // 
            this.m_btnRemoveColonne.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnRemoveColonne.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_btnRemoveColonne, "");
            this.m_btnRemoveColonne.Location = new System.Drawing.Point(95, 6);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnRemoveColonne, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnRemoveColonne, "");
            this.m_btnRemoveColonne.Name = "m_btnRemoveColonne";
            this.m_btnRemoveColonne.Size = new System.Drawing.Size(78, 22);
            this.m_extStyle.SetStyleBackColor(this.m_btnRemoveColonne, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnRemoveColonne, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnRemoveColonne.TabIndex = 4;
            this.m_btnRemoveColonne.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_btnRemoveColonne.LinkClicked += new System.EventHandler(this.m_btnRemove_LinkClicked);
            // 
            // m_btnAddColonne
            // 
            this.m_btnAddColonne.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnAddColonne.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_btnAddColonne, "");
            this.m_btnAddColonne.Location = new System.Drawing.Point(4, 6);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAddColonne, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnAddColonne, "");
            this.m_btnAddColonne.Name = "m_btnAddColonne";
            this.m_btnAddColonne.Size = new System.Drawing.Size(78, 22);
            this.m_extStyle.SetStyleBackColor(this.m_btnAddColonne, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAddColonne, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAddColonne.TabIndex = 3;
            this.m_btnAddColonne.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_btnAddColonne.LinkClicked += new System.EventHandler(this.m_btnAdd_LinkClicked);
            // 
            // m_wndListeColonnes
            // 
            this.m_wndListeColonnes.FormattingEnabled = true;
            this.m_wndListeColonnes.ItemHeight = 15;
            this.m_extLinkField.SetLinkField(this.m_wndListeColonnes, "");
            this.m_wndListeColonnes.Location = new System.Drawing.Point(3, 29);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeColonnes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndListeColonnes, "");
            this.m_wndListeColonnes.Name = "m_wndListeColonnes";
            this.m_wndListeColonnes.Size = new System.Drawing.Size(224, 214);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeColonnes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeColonnes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeColonnes.TabIndex = 3;
            this.m_wndListeColonnes.SelectedIndexChanged += new System.EventHandler(this.m_wndListeColonnes_SelectedIndexChanged);
            // 
            // label15
            // 
            this.m_extLinkField.SetLinkField(this.label15, "");
            this.label15.Location = new System.Drawing.Point(428, 16);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label15, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label15, "");
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(118, 15);
            this.m_extStyle.SetStyleBackColor(this.label15, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label15, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label15.TabIndex = 20;
            this.label15.Text = "Header Height|10240";
            // 
            // label6
            // 
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.label6.Location = new System.Drawing.Point(16, 16);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label6, "");
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(622, 27);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 2;
            this.label6.Text = "Following Columns will be displayed on Current Alarms List|10236";
            // 
            // m_pageGeneral
            // 
            this.m_pageGeneral.Controls.Add(this.m_lnkPlaySound);
            this.m_pageGeneral.Controls.Add(this.m_btnSupprimerFichierSon);
            this.m_pageGeneral.Controls.Add(this.m_btnParcourirFichierSon);
            this.m_pageGeneral.Controls.Add(this.m_txtNomFichierSon);
            this.m_pageGeneral.Controls.Add(this.m_numDureePersistance);
            this.m_pageGeneral.Controls.Add(this.label12);
            this.m_pageGeneral.Controls.Add(this.label14);
            this.m_pageGeneral.Controls.Add(this.label13);
            this.m_pageGeneral.Controls.Add(this.m_txtFormuleOnNewAlarme);
            this.m_pageGeneral.Controls.Add(this.label7);
            this.m_pageGeneral.Controls.Add(this.m_txtFormuleFiltre);
            this.m_pageGeneral.Controls.Add(this.groupBox1);
            this.m_pageGeneral.Controls.Add(this.label5);
            this.m_extLinkField.SetLinkField(this.m_pageGeneral, "");
            this.m_pageGeneral.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageGeneral, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageGeneral, "");
            this.m_pageGeneral.Name = "m_pageGeneral";
            this.m_pageGeneral.Size = new System.Drawing.Size(803, 372);
            this.m_extStyle.SetStyleBackColor(this.m_pageGeneral, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageGeneral, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageGeneral.TabIndex = 10;
            this.m_pageGeneral.Title = "General setting|10226";
            // 
            // m_lnkPlaySound
            // 
            this.m_extLinkField.SetLinkField(this.m_lnkPlaySound, "");
            this.m_lnkPlaySound.Location = new System.Drawing.Point(620, 36);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkPlaySound, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkPlaySound, "");
            this.m_lnkPlaySound.Name = "m_lnkPlaySound";
            this.m_lnkPlaySound.Size = new System.Drawing.Size(106, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lnkPlaySound, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkPlaySound, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkPlaySound.TabIndex = 11;
            this.m_lnkPlaySound.TabStop = true;
            this.m_lnkPlaySound.Text = "Play sound|10263";
            this.m_lnkPlaySound.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_lnkPlaySound.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkPlaySound_LinkClicked);
            // 
            // m_btnSupprimerFichierSon
            // 
            this.m_extLinkField.SetLinkField(this.m_btnSupprimerFichierSon, "");
            this.m_btnSupprimerFichierSon.Location = new System.Drawing.Point(750, 10);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnSupprimerFichierSon, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnSupprimerFichierSon, "");
            this.m_btnSupprimerFichierSon.Name = "m_btnSupprimerFichierSon";
            this.m_btnSupprimerFichierSon.Size = new System.Drawing.Size(24, 24);
            this.m_extStyle.SetStyleBackColor(this.m_btnSupprimerFichierSon, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSupprimerFichierSon, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnSupprimerFichierSon.TabIndex = 10;
            this.m_btnSupprimerFichierSon.Text = "x";
            this.m_btnSupprimerFichierSon.UseVisualStyleBackColor = true;
            this.m_btnSupprimerFichierSon.Click += new System.EventHandler(this.m_btnSupprimerFichierSon_Click);
            // 
            // m_btnParcourirFichierSon
            // 
            this.m_extLinkField.SetLinkField(this.m_btnParcourirFichierSon, "");
            this.m_btnParcourirFichierSon.Location = new System.Drawing.Point(727, 10);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnParcourirFichierSon, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnParcourirFichierSon, "");
            this.m_btnParcourirFichierSon.Name = "m_btnParcourirFichierSon";
            this.m_btnParcourirFichierSon.Size = new System.Drawing.Size(24, 24);
            this.m_extStyle.SetStyleBackColor(this.m_btnParcourirFichierSon, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnParcourirFichierSon, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnParcourirFichierSon.TabIndex = 10;
            this.m_btnParcourirFichierSon.Text = "...";
            this.m_btnParcourirFichierSon.UseVisualStyleBackColor = true;
            this.m_btnParcourirFichierSon.Click += new System.EventHandler(this.m_btnParcourirFichierSon_Click);
            // 
            // m_txtNomFichierSon
            // 
            this.m_extLinkField.SetLinkField(this.m_txtNomFichierSon, "");
            this.m_txtNomFichierSon.Location = new System.Drawing.Point(481, 10);
            this.m_txtNomFichierSon.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtNomFichierSon, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_txtNomFichierSon, "");
            this.m_txtNomFichierSon.Name = "m_txtNomFichierSon";
            this.m_txtNomFichierSon.Size = new System.Drawing.Size(245, 23);
            this.m_extStyle.SetStyleBackColor(this.m_txtNomFichierSon, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtNomFichierSon, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtNomFichierSon.TabIndex = 0;
            // 
            // m_numDureePersistance
            // 
            this.m_extLinkField.SetLinkField(this.m_numDureePersistance, "");
            this.m_numDureePersistance.Location = new System.Drawing.Point(240, 10);
            this.m_numDureePersistance.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_numDureePersistance, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_numDureePersistance, "");
            this.m_numDureePersistance.Name = "m_numDureePersistance";
            this.m_numDureePersistance.Size = new System.Drawing.Size(72, 23);
            this.m_extStyle.SetStyleBackColor(this.m_numDureePersistance, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_numDureePersistance, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_numDureePersistance.TabIndex = 9;
            // 
            // label12
            // 
            this.m_extLinkField.SetLinkField(this.label12, "");
            this.label12.Location = new System.Drawing.Point(315, 11);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label12, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label12, "");
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 20);
            this.m_extStyle.SetStyleBackColor(this.label12, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label12, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label12.TabIndex = 8;
            this.label12.Text = "minutes";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.m_extLinkField.SetLinkField(this.label14, "");
            this.label14.Location = new System.Drawing.Point(390, 11);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label14, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label14, "");
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(141, 20);
            this.m_extStyle.SetStyleBackColor(this.label14, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label14, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label14.TabIndex = 7;
            this.label14.Text = "Sound File|10234";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.m_extLinkField.SetLinkField(this.label13, "");
            this.label13.Location = new System.Drawing.Point(29, 11);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label13, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label13, "");
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(242, 20);
            this.m_extStyle.SetStyleBackColor(this.label13, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label13, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label13.TabIndex = 7;
            this.label13.Text = "Cleard Alarms Persistence delay|10233";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtFormuleOnNewAlarme
            // 
            this.m_txtFormuleOnNewAlarme.AllowGraphic = true;
            this.m_txtFormuleOnNewAlarme.AllowSaisieTexte = true;
            this.m_txtFormuleOnNewAlarme.Formule = null;
            this.m_extLinkField.SetLinkField(this.m_txtFormuleOnNewAlarme, "");
            this.m_txtFormuleOnNewAlarme.Location = new System.Drawing.Point(240, 121);
            this.m_txtFormuleOnNewAlarme.LockEdition = false;
            this.m_txtFormuleOnNewAlarme.LockZoneTexte = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtFormuleOnNewAlarme, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtFormuleOnNewAlarme, "");
            this.m_txtFormuleOnNewAlarme.Name = "m_txtFormuleOnNewAlarme";
            this.m_txtFormuleOnNewAlarme.Size = new System.Drawing.Size(543, 45);
            this.m_extStyle.SetStyleBackColor(this.m_txtFormuleOnNewAlarme, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFormuleOnNewAlarme, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleOnNewAlarme.TabIndex = 6;
            // 
            // label7
            // 
            this.m_extLinkField.SetLinkField(this.label7, "");
            this.label7.Location = new System.Drawing.Point(29, 121);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label7, "");
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(213, 45);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 5;
            this.label7.Text = "Event On New Alarm Formula|10232";
            // 
            // m_txtFormuleFiltre
            // 
            this.m_txtFormuleFiltre.AllowGraphic = true;
            this.m_txtFormuleFiltre.AllowSaisieTexte = true;
            this.m_txtFormuleFiltre.Formule = null;
            this.m_extLinkField.SetLinkField(this.m_txtFormuleFiltre, "");
            this.m_txtFormuleFiltre.Location = new System.Drawing.Point(240, 63);
            this.m_txtFormuleFiltre.LockEdition = false;
            this.m_txtFormuleFiltre.LockZoneTexte = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtFormuleFiltre, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtFormuleFiltre, "");
            this.m_txtFormuleFiltre.Name = "m_txtFormuleFiltre";
            this.m_txtFormuleFiltre.Size = new System.Drawing.Size(543, 45);
            this.m_extStyle.SetStyleBackColor(this.m_txtFormuleFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFormuleFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleFiltre.TabIndex = 4;
            this.m_txtFormuleFiltre.OnChangeTexteFormule += new System.EventHandler(this.m_txtFormuleFiltre_OnChangeTexteFormule);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_selectItemBackColor);
            this.groupBox1.Controls.Add(this.m_selectItemForeColor);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.m_numLargeurEnteteLigne);
            this.groupBox1.Controls.Add(this.m_numHauteurLigne);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.groupBox1, "");
            this.groupBox1.Location = new System.Drawing.Point(19, 184);
            this.m_gestionnaireModeEdition.SetModeEdition(this.groupBox1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.groupBox1, "");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(533, 160);
            this.m_extStyle.SetStyleBackColor(this.groupBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.groupBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lines Configuration|10230";
            // 
            // m_selectItemBackColor
            // 
            this.m_extLinkField.SetLinkField(this.m_selectItemBackColor, "");
            this.m_selectItemBackColor.Location = new System.Drawing.Point(169, 110);
            this.m_selectItemBackColor.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_selectItemBackColor, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_selectItemBackColor, "");
            this.m_selectItemBackColor.Name = "m_selectItemBackColor";
            this.m_selectItemBackColor.SelectedColor = System.Drawing.Color.White;
            this.m_selectItemBackColor.Size = new System.Drawing.Size(320, 22);
            this.m_extStyle.SetStyleBackColor(this.m_selectItemBackColor, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_selectItemBackColor, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectItemBackColor.TabIndex = 5;
            // 
            // m_selectItemForeColor
            // 
            this.m_extLinkField.SetLinkField(this.m_selectItemForeColor, "");
            this.m_selectItemForeColor.Location = new System.Drawing.Point(169, 80);
            this.m_selectItemForeColor.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_selectItemForeColor, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_selectItemForeColor, "");
            this.m_selectItemForeColor.Name = "m_selectItemForeColor";
            this.m_selectItemForeColor.SelectedColor = System.Drawing.Color.White;
            this.m_selectItemForeColor.Size = new System.Drawing.Size(320, 22);
            this.m_extStyle.SetStyleBackColor(this.m_selectItemForeColor, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_selectItemForeColor, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectItemForeColor.TabIndex = 4;
            // 
            // label9
            // 
            this.m_extLinkField.SetLinkField(this.label9, "");
            this.label9.Location = new System.Drawing.Point(27, 111);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label9, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label9, "");
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(173, 20);
            this.m_extStyle.SetStyleBackColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label9.TabIndex = 3;
            this.label9.Text = "Item Back Color|10233";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_numLargeurEnteteLigne
            // 
            this.m_extLinkField.SetLinkField(this.m_numLargeurEnteteLigne, "");
            this.m_numLargeurEnteteLigne.Location = new System.Drawing.Point(169, 51);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_numLargeurEnteteLigne, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_numLargeurEnteteLigne, "");
            this.m_numLargeurEnteteLigne.Name = "m_numLargeurEnteteLigne";
            this.m_numLargeurEnteteLigne.Size = new System.Drawing.Size(72, 23);
            this.m_extStyle.SetStyleBackColor(this.m_numLargeurEnteteLigne, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_numLargeurEnteteLigne, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_numLargeurEnteteLigne.TabIndex = 2;
            // 
            // m_numHauteurLigne
            // 
            this.m_extLinkField.SetLinkField(this.m_numHauteurLigne, "");
            this.m_numHauteurLigne.Location = new System.Drawing.Point(169, 25);
            this.m_numHauteurLigne.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.m_numHauteurLigne.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_numHauteurLigne, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_numHauteurLigne, "");
            this.m_numHauteurLigne.Name = "m_numHauteurLigne";
            this.m_numHauteurLigne.Size = new System.Drawing.Size(72, 23);
            this.m_extStyle.SetStyleBackColor(this.m_numHauteurLigne, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_numHauteurLigne, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_numHauteurLigne.TabIndex = 2;
            this.m_numHauteurLigne.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.label4.Location = new System.Drawing.Point(27, 24);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 20);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 1;
            this.label4.Text = "Item Height|10228";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.m_extLinkField.SetLinkField(this.label11, "");
            this.label11.Location = new System.Drawing.Point(242, 52);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label11, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label11, "");
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 20);
            this.m_extStyle.SetStyleBackColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label11.TabIndex = 1;
            this.label11.Text = "(0 ... 100)";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.m_extLinkField.SetLinkField(this.label10, "");
            this.label10.Location = new System.Drawing.Point(242, 27);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label10, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label10, "");
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 20);
            this.m_extStyle.SetStyleBackColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label10.TabIndex = 1;
            this.label10.Text = "(10 ... 50)";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.m_extLinkField.SetLinkField(this.label8, "");
            this.label8.Location = new System.Drawing.Point(27, 81);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label8, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label8, "");
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(173, 20);
            this.m_extStyle.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 1;
            this.label8.Text = "Item Fore Color|10232";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(27, 50);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 20);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 1;
            this.label3.Text = "Header Width|10229";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.label5.Location = new System.Drawing.Point(29, 63);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(213, 45);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 1;
            this.label5.Text = "Display Filter Formula|10231";
            // 
            // m_errorProvider
            // 
            this.m_errorProvider.ContainerControl = this;
            // 
            // CFormEditionParametrageAffichageListeAlarmes
            // 
            this.ClientSize = new System.Drawing.Size(830, 569);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionParametrageAffichageListeAlarmes";
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
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.c2iPanelOmbre4.ResumeLayout(false);
            this.c2iPanelOmbre4.PerformLayout();
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.m_pageColonnes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_numHauteurEnteteCol)).EndInit();
            this.m_panelTotal.ResumeLayout(false);
            this.m_panelInfoColonne.ResumeLayout(false);
            this.m_panelInfoColonne.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageLink)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_picBackColorEnteteCol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picTextColorEnteteCol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numLargeurColonne)).EndInit();
            this.m_panelGauche.ResumeLayout(false);
            this.m_pageGeneral.ResumeLayout(false);
            this.m_pageGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_numDureePersistance)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_numLargeurEnteteLigne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numHauteurLigne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_errorProvider)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
		
        //-------------------------------------------------------------------------
		private CParametrageAffichageListeAlarmes ParametrageAffichageListeAlarmes
		{
			get
			{
				return (CParametrageAffichageListeAlarmes)ObjetEdite;
			}
		}

        private CParametreAffichageListeAlarmes m_parametreEdite;
        //-------------------------------------------------------------------------
        protected override CResultAErreur MyInitChamps()
        {
            CResultAErreur result = base.MyInitChamps();
            AffecterTitre(I.T("Alarm Display Setting @1|10224", ParametrageAffichageListeAlarmes.Libelle));

            m_parametreEdite = ParametrageAffichageListeAlarmes.ParametreAffichageAlarmes;

            if (ParametrageAffichageListeAlarmes.DocumentFichierSon != null)
            {
                m_txtNomFichierSon.Text = ParametrageAffichageListeAlarmes.DocumentFichierSon.Libelle;
                m_lnkPlaySound.Enabled = true;
            }
            else
            {
                m_txtNomFichierSon.Text = "";
                m_lnkPlaySound.Enabled = false;
            }
            m_txtNomFichierSon.LockEdition = true;

            if (m_parametreEdite == null)
                m_parametreEdite = CParametreAffichageListeAlarmes.ParametreParDefaut;

            m_numHauteurLigne.Value = m_parametreEdite.HauteurLigne;
            m_numLargeurEnteteLigne.Value = m_parametreEdite.LargeurEnteteLigne;
            m_numDureePersistance.Value = m_parametreEdite.DureePersistanceAlarmesRetombees;
            m_numHauteurEnteteCol.Value = m_parametreEdite.HauteurEnteteColonne;

            CFournisseurGeneriqueProprietesDynamiques fournisseur = new CFournisseurGeneriqueProprietesDynamiques();

            m_txtFormuleFiltre.Init(fournisseur, typeof(CLocalAlarme));
            m_txtFormuleOnNewAlarme.Init(fournisseur, typeof(CLocalAlarme));
            m_selectItemForeColor.Init(fournisseur, typeof(CLocalAlarme));
            m_selectItemBackColor.Init(fournisseur, typeof(CLocalAlarme));
            m_txtFormuleColonne.Init(fournisseur, typeof(CLocalAlarme));

            m_txtFormuleFiltre.Formule = m_parametreEdite.FormuleFiltre;
            m_txtFormuleOnNewAlarme.Formule = m_parametreEdite.FormuleOnNewAlarme;
            m_selectItemForeColor.FormuleCouleur = m_parametreEdite.FormuleItemForeColor;
            m_selectItemBackColor.FormuleCouleur = m_parametreEdite.FormuleItemBackColor;

            // Gestion des Colonnes
            FillListeColonnes();

            return result;
        }

		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();

            result = ValideDocumentSonnerie();


            if (m_parametreEdite != null)
            {
                m_parametreEdite.HauteurLigne = (int) m_numHauteurLigne.Value;
                m_parametreEdite.LargeurEnteteLigne = (int)m_numLargeurEnteteLigne.Value;
                m_parametreEdite.DureePersistanceAlarmesRetombees = (int)m_numDureePersistance.Value;
                m_parametreEdite.HauteurEnteteColonne = (int)m_numHauteurEnteteCol.Value;

                m_parametreEdite.FormuleFiltre = m_txtFormuleFiltre.Formule;
                m_parametreEdite.FormuleOnNewAlarme = m_txtFormuleOnNewAlarme.Formule;
                m_parametreEdite.FormuleItemForeColor = m_selectItemForeColor.FormuleCouleur;
                m_parametreEdite.FormuleItemBackColor = m_selectItemBackColor.FormuleCouleur;

                // Traitement des Colonnes
                ValideModifs();
                List<CColonneAlarmeAffichee> lstColonnes = new List<CColonneAlarmeAffichee>();
                foreach (CColonneAlarmeAffichee col in m_wndListeColonnes.Items)
                    lstColonnes.Add(col);

                m_parametreEdite.Colonnes = lstColonnes;
            }
            
            ParametrageAffichageListeAlarmes.ParametreAffichageAlarmes = m_parametreEdite;

            return result;
        }

        //-------------------------------------------------------------------------
        private CResultAErreur ValideDocumentSonnerie()
        {
            CResultAErreur result = CResultAErreur.True;

            if (File.Exists(m_strNomFichierSonLocal))
            {
                CDocumentGED doc = ParametrageAffichageListeAlarmes.DocumentFichierSon;
                CProxyGED proxy = new CProxyGED(ParametrageAffichageListeAlarmes.ContexteDonnee.IdSession,
                    doc == null ? null : doc.ReferenceDoc);
                proxy.AttacheToLocal(m_strNomFichierSonLocal);
                result = proxy.UpdateGed();
                if (result)
                {
                    if (doc == null)
                    {
                        doc = new CDocumentGED(ParametrageAffichageListeAlarmes.ContexteDonnee);
                        doc.CreateNewInCurrentContexte();
                        doc.DateCreation = DateTime.Now;
                    }
                    doc.Libelle = GetNomFichierSeul(m_strNomFichierSonLocal);
                    doc.Descriptif = I.T("Sound file for @1|10264", ParametrageAffichageListeAlarmes.Libelle);
                    doc.ReferenceDoc = (CReferenceDocument)result.Data;
                    doc.DateMAJ = DateTime.Now;
                    doc.NumVersion++;
                    doc.IsFichierSysteme = true;
                    ParametrageAffichageListeAlarmes.DocumentFichierSon = doc;
                }
            }
            else if (m_strNomFichierSonLocal.Trim() == string.Empty)
            {
                // Supprimer le document de GED
                CDocumentGED doc = ParametrageAffichageListeAlarmes.DocumentFichierSon;
                if (doc != null)
                {
                    ParametrageAffichageListeAlarmes.DocumentFichierSon = null;
                    doc.Delete();
                }
            }
            return result;
        }

        //-------------------------------------------------------------------------
        private string GetNomFichierSeul(string strNomComplet)
        {
            int nIndex = strNomComplet.LastIndexOf('\\');
            return strNomComplet.Substring(nIndex + 1, strNomComplet.Length - nIndex - 1);
        }

        //-------------------------------------------------------------------------
        private void m_txtFormuleFiltre_OnChangeTexteFormule(object sender, EventArgs e)
        {
            CTextBoxZoomFormule textBoxFormule = sender as CTextBoxZoomFormule;
            if(textBoxFormule != null)
            {
                C2iExpression formule = textBoxFormule.Formule;
                if (formule != null && typeof(bool).IsAssignableFrom(formule.TypeDonnee.TypeDotNetNatif))
                    m_errorProvider.SetError(textBoxFormule, "");
                else
                    m_errorProvider.SetError(textBoxFormule, I.T("Formula return Type must be a Boolean value|10235"));
            }
        }

        //----------------------------------------------------------------------------
        private void FillListeColonnes()
        {
            if (m_parametreEdite != null)
            {
                m_wndListeColonnes.BeginUpdate();
                m_wndListeColonnes.Items.Clear();
                foreach (CColonneAlarmeAffichee col in m_parametreEdite.Colonnes)
                {
                    m_wndListeColonnes.Items.Add(col);
                }
                m_wndListeColonnes.EndUpdate();
            }
        }


        //----------------------------------------------------
        private void m_btnRemove_LinkClicked(object sender, EventArgs e)
        {
            if (m_wndListeColonnes.SelectedItems.Count == 1 &&
                m_wndListeColonnes.SelectedIndex >= 0)
            {
                CColonneAlarmeAffichee col = (CColonneAlarmeAffichee)m_wndListeColonnes.Items[m_wndListeColonnes.SelectedIndex];
                
                if (CFormAlerte.Afficher(I.T("Remove the column @1 ?|10245", col.Title),
                    EFormAlerteType.Question) == DialogResult.Yes)
                {
                    m_wndListeColonnes.Items.RemoveAt(m_wndListeColonnes.SelectedIndex);
                }
            }
        }

        //------------------------------------------------------
        private void m_btnAdd_LinkClicked(object sender, EventArgs e)
        {
            ValideModifs();
            CColonneAlarmeAffichee col = new CColonneAlarmeAffichee();
            col.Title = I.T("New column|10246");
            int nIndex = m_wndListeColonnes.Items.Add(col);
            m_wndListeColonnes.SelectedIndex = nIndex;
        }

        //------------------------------------------------------
        private void m_btnBas_Click(object sender, EventArgs e)
        {
            int nIndex = m_wndListeColonnes.SelectedIndex;
            if (nIndex >= 0 && nIndex < m_wndListeColonnes.Items.Count - 1)
            {
                object item = m_wndListeColonnes.Items[nIndex];
                m_wndListeColonnes.Items.RemoveAt(nIndex);
                m_wndListeColonnes.Items.Insert(nIndex + 1, item);
                m_wndListeColonnes.SelectedIndex = nIndex + 1;
            }
        }

        //------------------------------------------------------
        private void m_btnHaut_Click(object sender, EventArgs e)
        {
            int nIndex = m_wndListeColonnes.SelectedIndex;
            if (nIndex >= 1)
            {
                object item = m_wndListeColonnes.Items[nIndex];
                m_wndListeColonnes.Items.RemoveAt(nIndex);
                m_wndListeColonnes.Items.Insert(nIndex - 1, item);
                m_wndListeColonnes.SelectedIndex = nIndex - 1;
            }
        }

        //------------------------------------------------------
        CColonneAlarmeAffichee m_colonneAffichee = null;
        private void ValideModifs()
        {
            if (m_colonneAffichee != null)
            {
                m_colonneAffichee.Title = m_txtTitreColonne.Text;
                m_colonneAffichee.Width = (int)m_numLargeurColonne.Value;
                m_colonneAffichee.FormuleDonnee = m_txtFormuleColonne.Formule;
                m_colonneAffichee.BackColor = m_picBackColorEnteteCol.BackColor;
                m_colonneAffichee.TextColor = m_picTextColorEnteteCol.BackColor;
                m_colonneAffichee.Font = m_lblPoliceEnteteCol.Font;

                RefreshListe();
            }
        }

        //------------------------------------------------------
        private bool m_bIsRefreshing = false;
        private void RefreshListe()
        {
            m_bIsRefreshing = true;
            m_wndListeColonnes.BeginUpdate();
            for (int nCol = 0; nCol < m_wndListeColonnes.Items.Count; nCol++)
            {
                CColonneAlarmeAffichee col = (CColonneAlarmeAffichee)m_wndListeColonnes.Items[nCol];
                m_wndListeColonnes.Items[nCol] = "...";
                m_wndListeColonnes.Items[nCol] = col;
            }
            m_wndListeColonnes.EndUpdate();
            m_bIsRefreshing = false;
        }

        //------------------------------------------------------
        private void AfficheColonne(CColonneAlarmeAffichee colonne)
        {
            ValideModifs();
            m_colonneAffichee = colonne;
            if (colonne == null)
            {
                m_panelInfoColonne.Visible = false;
            }
            else
            {
                m_panelInfoColonne.Visible = true;
                m_txtTitreColonne.Text = colonne.Title;
                m_numLargeurColonne.Value = colonne.Width;
                m_txtFormuleColonne.Formule = colonne.FormuleDonnee;
                m_picBackColorEnteteCol.BackColor = colonne.BackColor;
                m_picTextColorEnteteCol.BackColor = colonne.TextColor;
                if (colonne.Font != null)
                {
                    m_lblPoliceEnteteCol.Font = colonne.Font;
                    m_lblPoliceEnteteCol.Text = colonne.Font.ToString();
                }
                else
                    m_lblPoliceEnteteCol.Text = "";

                m_imageLink.Visible = colonne.ActionSurLink != null;
            }
        }

        //-------------------------------------------------------------------------------
        private void m_wndListeColonnes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_wndListeColonnes.SelectedIndex >= 0 && !m_bIsRefreshing)
            {
                AfficheColonne((CColonneAlarmeAffichee)m_wndListeColonnes.Items[m_wndListeColonnes.SelectedIndex]);
            }
        }

        //-------------------------------------------------------------------------------
        private void m_picBkColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = Color.FromArgb(255, m_picBackColorEnteteCol.BackColor);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                m_picBackColorEnteteCol.BackColor = dlg.Color;
            }
        }

        private void m_btnNoBackgroundColor_Click(object sender, EventArgs e)
        {
            m_picBackColorEnteteCol.BackColor = Color.Transparent;
            
        }

        private void m_picTextColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = Color.FromArgb(255, m_picTextColorEnteteCol.BackColor);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                m_picTextColorEnteteCol.BackColor = dlg.Color;
                
            }
        }

        private void m_btnNoTextColor_Click(object sender, EventArgs e)
        {
            m_picTextColorEnteteCol.BackColor = Color.Transparent;
            
        }

        private void m_btnSelectFont_Click(object sender, EventArgs e)
        {
            FontDialog dlg = new FontDialog();
            if (m_lblPoliceEnteteCol.Font != null)
                dlg.Font = m_lblPoliceEnteteCol.Font;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                m_lblPoliceEnteteCol.Font = dlg.Font;
                m_lblPoliceEnteteCol.Text = dlg.Font.ToString();
            }
        }

        //---------------------------------------------------------------------------
        private string m_strNomFichierSonLocal = "";
        private void m_btnParcourirFichierSon_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dlg.Filter = "Sound files (*.wav)|*.wav";
                m_strNomFichierSonLocal = dlg.FileName;
                m_txtNomFichierSon.Text = GetNomFichierSeul(m_strNomFichierSonLocal);
                if(ValideDocumentSonnerie())
                    m_lnkPlaySound.Enabled = true;
            }
        }

        //---------------------------------------------------------------------------
        private void m_btnSupprimerFichierSon_Click(object sender, EventArgs e)
        {
            m_strNomFichierSonLocal = string.Empty;
            m_txtNomFichierSon.Text = m_strNomFichierSonLocal;
            ValideDocumentSonnerie();
            m_lnkPlaySound.Enabled = false;
        }

        //---------------------------------------------------------------------------
        Timer m_timerTestSonnerie = null;
        int? m_nIdSonnerieEnCours = 0;
        private void m_lnkPlaySound_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CDocumentGED docSonnerie = ParametrageAffichageListeAlarmes.DocumentFichierSon;
            if (docSonnerie != null && docSonnerie.ReferenceDoc != null)
            {
                m_timerTestSonnerie = new Timer();
                m_timerTestSonnerie.Interval = 3000;
                m_timerTestSonnerie.Tick += new EventHandler(m_timerTestSonnerie_Tick);
                CProxyGED proxySonnerie = new CProxyGED(ParametrageAffichageListeAlarmes.ContexteDonnee.IdSession, docSonnerie.ReferenceDoc);
                if (proxySonnerie != null && proxySonnerie.CopieFichierEnLocal())
                {
                    string strFichier = proxySonnerie.NomFichierLocal;

                    m_timerTestSonnerie.Start();
                    int? nIdSonnerie = CSoundPlayer.StartSound(strFichier);
                    if (nIdSonnerie != null)
                        m_nIdSonnerieEnCours = nIdSonnerie;
                }
            }

        }

        //---------------------------------------------------------------------------
        void m_timerTestSonnerie_Tick(object sender, EventArgs e)
        {
            if (m_timerTestSonnerie != null)
            {
                m_timerTestSonnerie.Stop();
                if (m_nIdSonnerieEnCours != null)
                    CSoundPlayer.StopSound(m_nIdSonnerieEnCours.Value);
                m_nIdSonnerieEnCours = null;

                m_timerTestSonnerie.Dispose();
                m_timerTestSonnerie = null;
            }
        }

        //---------------------------------------------------------------------------
        private void m_btnAfficherAlarmes_Click(object sender, EventArgs e)
        {
            if (ParametrageAffichageListeAlarmes != null)
            {
                CFormConsultationAlarmesEnCours.AfficheAlarmes(
                    CFournisseurAlarmesPourAffichage.GetAlarmesAAfficher(
                        CTimosApp.SessionClient.IdSession),
                        ParametrageAffichageListeAlarmes,
                        CTimosApp.Navigateur);

            }
        }

        //---------------------------------------------------------------------------
        private void m_lnkAction_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CActionSur2iLink action = m_colonneAffichee.ActionSurLink;
            CActionSur2iLinkEditor.EditeAction(ref action, typeof(CLocalAlarme));
            m_imageLink.Visible = action != null;
            m_colonneAffichee.ActionSurLink = action;
        }

	}
}

