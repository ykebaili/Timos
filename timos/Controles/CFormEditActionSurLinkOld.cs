using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing.Design;

using sc2i.process;
using sc2i.data.dynamic;
using sc2i.common;
using sc2i.data;
using sc2i.win32.data;
using sc2i.custom;
using sc2i.win32.data.navigation;
using sc2i.win32.expression;

using sc2i.formulaire;
using sc2i.expression;
using sc2i.win32.common;
using sc2i.formulaire.win32;
using timos.Controles.ActionsSurLink;

namespace timos
{
	/// <summary>
	/// Description résumée de CFormEditActionSurLinkOld.
	/// </summary>
	[AutoExec("Autoexec")]
	public class CFormEditActionSurLinkOld : System.Windows.Forms.Form
	{
        /// <summary>
        /// Représente un paramètre de Formulaire standard pour l'édition
        /// </summary>
        private class CWndParametreEnEdition
        {
            private CInfoParametreDynamicForm m_infoParametre;
            private C2iExpression m_expressions;

            public CWndParametreEnEdition(CInfoParametreDynamicForm info, C2iExpression exp)
            {
                m_infoParametre = info;
                m_expressions = exp;

            }

            public CInfoParametreDynamicForm InfoParametre
            {
                get { return m_infoParametre; }
                set { m_infoParametre = value; }
            }

            public C2iExpression Expression
            {
                get { return m_expressions; }
                set { m_expressions = value; }
            }


        }


		private sc2i.win32.expression.CControleEditeFormule m_txtFormule = null;
        private CObjetPourSousProprietes m_objetPourSousProprietes = null;
		private CFiltreDynamique m_filtreEdite = null;
		private CActionSur2iLink m_actionEditee = null;
		private CActionSur2iLink m_actionOriginale = null;
		private System.Windows.Forms.RadioButton m_chkAction;
		private System.Windows.Forms.RadioButton m_chkListe;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button m_btnAnnuler;
		private System.Windows.Forms.Button m_btnOk;
		private System.Windows.Forms.RadioButton m_chkFormulaire;
		private System.Windows.Forms.Panel m_panelComplet;
		private System.Windows.Forms.Label label1;
		private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_selectionneurProcess;
		private System.Windows.Forms.Panel m_panelAction;
		private System.Windows.Forms.Panel m_panelListeEntites;
		private System.Windows.Forms.Panel m_panelFormulaire;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RadioButton m_chkFormulairePersonnalisé;
		private sc2i.win32.common.CComboboxAutoFilled m_cmbFormulaireStandard;
		private System.Windows.Forms.Panel m_panelFormulaireCustom;
		private sc2i.win32.common.CComboboxAutoFilled m_cmbFormulaireCustom;
		private System.Windows.Forms.TextBox m_txtContexteFormulaire;
		private System.Windows.Forms.Label label5;
		private sc2i.win32.common.C2iTabControl m_tabPageListe;
		private Crownwood.Magic.Controls.TabPage tabPage1;
		private Crownwood.Magic.Controls.TabPage tabPage2;
		private sc2i.win32.data.dynamic.CPanelEditFiltreDynamique m_panelEditFiltre;
		private sc2i.win32.common.C2iTabControl c2iTabControl1;
		private System.ComponentModel.IContainer components;
		private sc2i.win32.expression.CControleEditeFormule m_txtTitreListe;
		private System.Windows.Forms.Label label6;
		private sc2i.win32.expression.CControleEditeFormule m_txtContexteListe;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel2;
		private sc2i.win32.expression.CControlAideFormule m_wndAide;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_selectionneurEvenementManuel;
		private System.Windows.Forms.Panel m_panelEvenementManuel;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label9;
		private sc2i.win32.expression.CControleEditeFormule cControleEditeFormule1;
		private System.Windows.Forms.Label label10;
		private sc2i.win32.expression.CControleEditeFormule cControleEditeFormule2;
		private System.Windows.Forms.Splitter splitter2;
		private sc2i.win32.expression.CControlAideFormule cControlAideFormule1;
		private Crownwood.Magic.Controls.TabPage tabPage4;
		private sc2i.win32.data.dynamic.CPanelEditFiltreDynamique cPanelEditFiltreDynamique1;
		private sc2i.win32.common.C2iTabControl c2iTabControl3;
		private sc2i.win32.common.C2iTabControl c2iTabControl4;
		private Crownwood.Magic.Controls.TabPage tabPage3;
		private sc2i.win32.common.C2iTabControl m_panelActionAfficherEntite;
		private Crownwood.Magic.Controls.TabPage tabPage6;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label label11;
		private sc2i.win32.expression.CControleEditeFormule m_txtFormuleTitreAfficheEntite;
		private System.Windows.Forms.Label label12;
		private sc2i.win32.expression.CControleEditeFormule m_txtFormuleContexteEntite;
		private Crownwood.Magic.Controls.TabPage tabPage7;
		private System.Windows.Forms.Panel m_panelAfficherEntite;
		private sc2i.win32.expression.CControlAideFormule m_wndAideFormuleAfficherEntite;
		private System.Windows.Forms.Splitter splitter3;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.RadioButton m_chkAfficherEntite;
		private sc2i.win32.expression.CControleEditeFormule m_txtFormuleEntite;
        protected sc2i.win32.common.CExtStyle m_ExtStyle1;
        private ListViewAutoFilledColumn listViewAutoFilledColumn1;
        private SplitContainer m_splitContainer1;
        private SplitContainer m_splitContainer2;
        private ListViewAutoFilled m_wndListeParametres;
        private ListViewAutoFilledColumn listViewAutoFilledColumn2;
        private Label label13;
        private Label m_lblNomParametre;
        private Label label15;
        private sc2i.win32.expression.CControleEditeFormule m_txtFormuleParametre;
        private sc2i.win32.expression.CControlAideFormule m_wndAideFormuleParametre;
        private Label m_lblDescriptionParametre;
        private SplitContainer m_splitContainerInfosParam;
        private Panel m_panelParametresFormulaire;
		private CheckBox m_chkHideProgress;
        private Label label16;
        private TextBox m_txtCodeFormulaireEdition;
        private Label label17;
        private CControlEditListeFormulesNommees m_panelParametresAction;
        private LinkLabel m_lnkAffectations;
        private Panel panel5;
        private Panel panel6;
        private Label label18;
        private LinkLabel m_lnkEditActionDetailSpecifique;
        private RadioButton m_rbtnActionDetailSpecifique;
        private RadioButton m_rbtnActionDetailEditElement;
        private Panel panel7;
        private Panel panel8;
        private Label label19;
        private CheckBox m_chkListeAvecAjouter;
        private CheckBox m_chkListeAvecDetail;
        private CheckBox m_chkListeAvecRemove;
        private LinkLabel m_lnkFiltreSpecifique;
        private PictureBox m_imgFiltreSpecifiqueOnList;
        private LinkLabel m_lnkOptionsFiltre;
		private System.Windows.Forms.Label label3;

		public CFormEditActionSurLinkOld()
		{
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			InitializeComponent();

			//
			// TODO : ajoutez le code du constructeur après l'appel à InitializeComponent
			//
		}

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
			}
			base.Dispose( disposing );
		}

		#region Code généré par le Concepteur Windows Form
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditActionSurLinkOld));
            this.m_chkAction = new System.Windows.Forms.RadioButton();
            this.m_chkListe = new System.Windows.Forms.RadioButton();
            this.m_panelComplet = new System.Windows.Forms.Panel();
            this.m_panelListeEntites = new System.Windows.Forms.Panel();
            this.m_tabPageListe = new sc2i.win32.common.C2iTabControl(this.components);
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.m_panelEditFiltre = new sc2i.win32.data.dynamic.CPanelEditFiltreDynamique();
            this.c2iTabControl1 = new sc2i.win32.common.C2iTabControl(this.components);
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_lnkOptionsFiltre = new System.Windows.Forms.LinkLabel();
            this.m_imgFiltreSpecifiqueOnList = new System.Windows.Forms.PictureBox();
            this.m_lnkFiltreSpecifique = new System.Windows.Forms.LinkLabel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.m_lnkEditActionDetailSpecifique = new System.Windows.Forms.LinkLabel();
            this.m_rbtnActionDetailSpecifique = new System.Windows.Forms.RadioButton();
            this.m_rbtnActionDetailEditElement = new System.Windows.Forms.RadioButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.m_lnkAffectations = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.m_txtTitreListe = new sc2i.win32.expression.CControleEditeFormule();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txtContexteListe = new sc2i.win32.expression.CControleEditeFormule();
            this.panel7 = new System.Windows.Forms.Panel();
            this.m_chkListeAvecDetail = new System.Windows.Forms.CheckBox();
            this.m_chkListeAvecRemove = new System.Windows.Forms.CheckBox();
            this.m_chkListeAvecAjouter = new System.Windows.Forms.CheckBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_wndAide = new sc2i.win32.expression.CControlAideFormule();
            this.m_panelAction = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.m_panelParametresAction = new sc2i.win32.expression.CControlEditListeFormulesNommees();
            this.m_chkHideProgress = new System.Windows.Forms.CheckBox();
            this.m_panelEvenementManuel = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.m_selectionneurEvenementManuel = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.label1 = new System.Windows.Forms.Label();
            this.m_selectionneurProcess = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_panelAfficherEntite = new System.Windows.Forms.Panel();
            this.m_panelActionAfficherEntite = new sc2i.win32.common.C2iTabControl(this.components);
            this.tabPage7 = new Crownwood.Magic.Controls.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.m_txtFormuleEntite = new sc2i.win32.expression.CControleEditeFormule();
            this.tabPage6 = new Crownwood.Magic.Controls.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.m_txtCodeFormulaireEdition = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.m_txtFormuleTitreAfficheEntite = new sc2i.win32.expression.CControleEditeFormule();
            this.label16 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.m_txtFormuleContexteEntite = new sc2i.win32.expression.CControleEditeFormule();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.m_wndAideFormuleAfficherEntite = new sc2i.win32.expression.CControlAideFormule();
            this.m_panelFormulaireCustom = new System.Windows.Forms.Panel();
            this.m_cmbFormulaireCustom = new sc2i.win32.common.CComboboxAutoFilled();
            this.label3 = new System.Windows.Forms.Label();
            this.m_panelFormulaire = new System.Windows.Forms.Panel();
            this.m_panelParametresFormulaire = new System.Windows.Forms.Panel();
            this.m_splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.m_wndListeParametres = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn2 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.label13 = new System.Windows.Forms.Label();
            this.m_splitContainerInfosParam = new System.Windows.Forms.SplitContainer();
            this.m_lblNomParametre = new System.Windows.Forms.Label();
            this.m_txtFormuleParametre = new sc2i.win32.expression.CControleEditeFormule();
            this.label15 = new System.Windows.Forms.Label();
            this.m_lblDescriptionParametre = new System.Windows.Forms.Label();
            this.m_wndAideFormuleParametre = new sc2i.win32.expression.CControlAideFormule();
            this.m_txtContexteFormulaire = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_cmbFormulaireStandard = new sc2i.win32.common.CComboboxAutoFilled();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_btnAnnuler = new System.Windows.Forms.Button();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_chkFormulaire = new System.Windows.Forms.RadioButton();
            this.m_chkFormulairePersonnalisé = new System.Windows.Forms.RadioButton();
            this.m_chkAfficherEntite = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.cControleEditeFormule1 = new sc2i.win32.expression.CControleEditeFormule();
            this.label10 = new System.Windows.Forms.Label();
            this.cControleEditeFormule2 = new sc2i.win32.expression.CControleEditeFormule();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.cControlAideFormule1 = new sc2i.win32.expression.CControlAideFormule();
            this.tabPage4 = new Crownwood.Magic.Controls.TabPage();
            this.cPanelEditFiltreDynamique1 = new sc2i.win32.data.dynamic.CPanelEditFiltreDynamique();
            this.c2iTabControl3 = new sc2i.win32.common.C2iTabControl(this.components);
            this.c2iTabControl4 = new sc2i.win32.common.C2iTabControl(this.components);
            this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
            this.m_ExtStyle1 = new sc2i.win32.common.CExtStyle();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_panelComplet.SuspendLayout();
            this.m_panelListeEntites.SuspendLayout();
            this.m_tabPageListe.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.m_panelEditFiltre.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_imgFiltreSpecifiqueOnList)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.m_panelAction.SuspendLayout();
            this.m_panelEvenementManuel.SuspendLayout();
            this.m_panelAfficherEntite.SuspendLayout();
            this.m_panelActionAfficherEntite.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.m_panelFormulaireCustom.SuspendLayout();
            this.m_panelFormulaire.SuspendLayout();
            this.m_panelParametresFormulaire.SuspendLayout();
            this.m_splitContainer1.Panel1.SuspendLayout();
            this.m_splitContainer1.Panel2.SuspendLayout();
            this.m_splitContainer1.SuspendLayout();
            this.m_splitContainer2.Panel1.SuspendLayout();
            this.m_splitContainer2.Panel2.SuspendLayout();
            this.m_splitContainer2.SuspendLayout();
            this.m_splitContainerInfosParam.Panel1.SuspendLayout();
            this.m_splitContainerInfosParam.Panel2.SuspendLayout();
            this.m_splitContainerInfosParam.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.cPanelEditFiltreDynamique1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_chkAction
            // 
            this.m_chkAction.Location = new System.Drawing.Point(8, 8);
            this.m_chkAction.Name = "m_chkAction";
            this.m_chkAction.Size = new System.Drawing.Size(163, 18);
            this.m_ExtStyle1.SetStyleBackColor(this.m_chkAction, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_chkAction, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkAction.TabIndex = 1;
            this.m_chkAction.Text = "Execute an Action|154";
            this.m_chkAction.CheckedChanged += new System.EventHandler(this.m_chkFormulaire_CheckedChanged);
            // 
            // m_chkListe
            // 
            this.m_chkListe.Location = new System.Drawing.Point(158, 8);
            this.m_chkListe.Name = "m_chkListe";
            this.m_chkListe.Size = new System.Drawing.Size(182, 16);
            this.m_ExtStyle1.SetStyleBackColor(this.m_chkListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_chkListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkListe.TabIndex = 2;
            this.m_chkListe.Text = "Display entity list|155";
            this.m_chkListe.CheckedChanged += new System.EventHandler(this.m_chkFormulaire_CheckedChanged);
            // 
            // m_panelComplet
            // 
            this.m_panelComplet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelComplet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelComplet.Controls.Add(this.m_panelListeEntites);
            this.m_panelComplet.Controls.Add(this.m_panelAction);
            this.m_panelComplet.Controls.Add(this.m_panelFormulaire);
            this.m_panelComplet.Controls.Add(this.m_panelAfficherEntite);
            this.m_panelComplet.Controls.Add(this.m_panelFormulaireCustom);
            this.m_panelComplet.ForeColor = System.Drawing.Color.Black;
            this.m_panelComplet.Location = new System.Drawing.Point(5, 32);
            this.m_panelComplet.Name = "m_panelComplet";
            this.m_panelComplet.Size = new System.Drawing.Size(824, 476);
            this.m_ExtStyle1.SetStyleBackColor(this.m_panelComplet, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_ExtStyle1.SetStyleForeColor(this.m_panelComplet, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelComplet.TabIndex = 3;
            // 
            // m_panelListeEntites
            // 
            this.m_panelListeEntites.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelListeEntites.Controls.Add(this.m_tabPageListe);
            this.m_panelListeEntites.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelListeEntites.ForeColor = System.Drawing.Color.Black;
            this.m_panelListeEntites.Location = new System.Drawing.Point(0, 1088);
            this.m_panelListeEntites.Name = "m_panelListeEntites";
            this.m_panelListeEntites.Size = new System.Drawing.Size(824, 476);
            this.m_ExtStyle1.SetStyleBackColor(this.m_panelListeEntites, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_ExtStyle1.SetStyleForeColor(this.m_panelListeEntites, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelListeEntites.TabIndex = 4;
            // 
            // m_tabPageListe
            // 
            this.m_tabPageListe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_tabPageListe.BoldSelectedPage = true;
            this.m_tabPageListe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tabPageListe.ForeColor = System.Drawing.Color.Black;
            this.m_tabPageListe.IDEPixelArea = false;
            this.m_tabPageListe.Location = new System.Drawing.Point(0, 0);
            this.m_tabPageListe.Name = "m_tabPageListe";
            this.m_tabPageListe.Ombre = false;
            this.m_tabPageListe.PositionTop = true;
            this.m_tabPageListe.SelectedIndex = 0;
            this.m_tabPageListe.SelectedTab = this.tabPage1;
            this.m_tabPageListe.Size = new System.Drawing.Size(824, 476);
            this.m_ExtStyle1.SetStyleBackColor(this.m_tabPageListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_tabPageListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabPageListe.TabIndex = 5;
            this.m_tabPageListe.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2});
            this.m_tabPageListe.TextColor = System.Drawing.Color.Black;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_panelEditFiltre);
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(824, 451);
            this.m_ExtStyle1.SetStyleBackColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage1.TabIndex = 10;
            this.tabPage1.Title = "Filtre";
            // 
            // m_panelEditFiltre
            // 
            this.m_panelEditFiltre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelEditFiltre.BackColor = System.Drawing.Color.White;
            this.m_panelEditFiltre.Controls.Add(this.c2iTabControl1);
            this.m_panelEditFiltre.DefinitionRacineDeChampsFiltres = null;
            this.m_panelEditFiltre.FiltreDynamique = null;
            this.m_panelEditFiltre.Location = new System.Drawing.Point(0, 0);
            this.m_panelEditFiltre.LockEdition = false;
            this.m_panelEditFiltre.ModeFiltreExpression = false;
            this.m_panelEditFiltre.ModeSansType = false;
            this.m_panelEditFiltre.Name = "m_panelEditFiltre";
            this.m_panelEditFiltre.Size = new System.Drawing.Size(824, 451);
            this.m_ExtStyle1.SetStyleBackColor(this.m_panelEditFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_panelEditFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEditFiltre.TabIndex = 1;
            // 
            // c2iTabControl1
            // 
            this.c2iTabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(184)))));
            this.c2iTabControl1.BoldSelectedPage = true;
            this.c2iTabControl1.ControlBottomOffset = 16;
            this.c2iTabControl1.ControlRightOffset = 16;
            this.c2iTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c2iTabControl1.IDEPixelArea = false;
            this.c2iTabControl1.Location = new System.Drawing.Point(0, 0);
            this.c2iTabControl1.Name = "c2iTabControl1";
            this.c2iTabControl1.Ombre = true;
            this.c2iTabControl1.PositionTop = true;
            this.c2iTabControl1.Size = new System.Drawing.Size(824, 451);
            this.m_ExtStyle1.SetStyleBackColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTabControl1.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.splitter1);
            this.tabPage2.Controls.Add(this.m_wndAide);
            this.tabPage2.Location = new System.Drawing.Point(0, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(824, 451);
            this.m_ExtStyle1.SetStyleBackColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage2.TabIndex = 11;
            this.tabPage2.Title = "Options de la page";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_lnkOptionsFiltre);
            this.panel2.Controls.Add(this.m_imgFiltreSpecifiqueOnList);
            this.panel2.Controls.Add(this.m_lnkFiltreSpecifique);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.m_lnkAffectations);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.m_txtTitreListe);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.m_txtContexteListe);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(589, 451);
            this.m_ExtStyle1.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel2.TabIndex = 9;
            // 
            // m_lnkOptionsFiltre
            // 
            this.m_lnkOptionsFiltre.AutoSize = true;
            this.m_lnkOptionsFiltre.Location = new System.Drawing.Point(51, 39);
            this.m_lnkOptionsFiltre.Name = "m_lnkOptionsFiltre";
            this.m_lnkOptionsFiltre.Size = new System.Drawing.Size(103, 13);
            this.m_ExtStyle1.SetStyleBackColor(this.m_lnkOptionsFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_lnkOptionsFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkOptionsFiltre.TabIndex = 15;
            this.m_lnkOptionsFiltre.TabStop = true;
            this.m_lnkOptionsFiltre.Text = "Filter options|20828";
            this.m_lnkOptionsFiltre.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkOptionsFiltre_LinkClicked);
            // 
            // m_imgFiltreSpecifiqueOnList
            // 
            this.m_imgFiltreSpecifiqueOnList.Image = global::timos.Properties.Resources.filtre;
            this.m_imgFiltreSpecifiqueOnList.Location = new System.Drawing.Point(11, 24);
            this.m_imgFiltreSpecifiqueOnList.Name = "m_imgFiltreSpecifiqueOnList";
            this.m_imgFiltreSpecifiqueOnList.Size = new System.Drawing.Size(16, 15);
            this.m_imgFiltreSpecifiqueOnList.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.m_ExtStyle1.SetStyleBackColor(this.m_imgFiltreSpecifiqueOnList, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_imgFiltreSpecifiqueOnList, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_imgFiltreSpecifiqueOnList.TabIndex = 14;
            this.m_imgFiltreSpecifiqueOnList.TabStop = false;
            // 
            // m_lnkFiltreSpecifique
            // 
            this.m_lnkFiltreSpecifique.AutoSize = true;
            this.m_lnkFiltreSpecifique.Location = new System.Drawing.Point(28, 25);
            this.m_lnkFiltreSpecifique.Name = "m_lnkFiltreSpecifique";
            this.m_lnkFiltreSpecifique.Size = new System.Drawing.Size(122, 13);
            this.m_ExtStyle1.SetStyleBackColor(this.m_lnkFiltreSpecifique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_lnkFiltreSpecifique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkFiltreSpecifique.TabIndex = 13;
            this.m_lnkFiltreSpecifique.TabStop = true;
            this.m_lnkFiltreSpecifique.Text = "Use specific filter|20826";
            this.m_lnkFiltreSpecifique.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkFiltreSpecifique_LinkClicked);
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.m_lnkEditActionDetailSpecifique);
            this.panel5.Controls.Add(this.m_rbtnActionDetailSpecifique);
            this.panel5.Controls.Add(this.m_rbtnActionDetailEditElement);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Location = new System.Drawing.Point(360, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(229, 58);
            this.m_ExtStyle1.SetStyleBackColor(this.panel5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.panel5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel5.TabIndex = 11;
            // 
            // m_lnkEditActionDetailSpecifique
            // 
            this.m_lnkEditActionDetailSpecifique.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkEditActionDetailSpecifique.Location = new System.Drawing.Point(95, 37);
            this.m_lnkEditActionDetailSpecifique.Name = "m_lnkEditActionDetailSpecifique";
            this.m_lnkEditActionDetailSpecifique.Size = new System.Drawing.Size(53, 21);
            this.m_ExtStyle1.SetStyleBackColor(this.m_lnkEditActionDetailSpecifique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_lnkEditActionDetailSpecifique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkEditActionDetailSpecifique.TabIndex = 3;
            this.m_lnkEditActionDetailSpecifique.TabStop = true;
            this.m_lnkEditActionDetailSpecifique.Text = "...";
            this.m_lnkEditActionDetailSpecifique.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lnkEditActionDetailSpecifique.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkEditActionDetailSpecifique_LinkClicked);
            // 
            // m_rbtnActionDetailSpecifique
            // 
            this.m_rbtnActionDetailSpecifique.AutoSize = true;
            this.m_rbtnActionDetailSpecifique.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_rbtnActionDetailSpecifique.Location = new System.Drawing.Point(0, 37);
            this.m_rbtnActionDetailSpecifique.Name = "m_rbtnActionDetailSpecifique";
            this.m_rbtnActionDetailSpecifique.Size = new System.Drawing.Size(95, 21);
            this.m_ExtStyle1.SetStyleBackColor(this.m_rbtnActionDetailSpecifique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_rbtnActionDetailSpecifique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_rbtnActionDetailSpecifique.TabIndex = 2;
            this.m_rbtnActionDetailSpecifique.TabStop = true;
            this.m_rbtnActionDetailSpecifique.Text = "Specific|20804";
            this.m_rbtnActionDetailSpecifique.UseVisualStyleBackColor = true;
            this.m_rbtnActionDetailSpecifique.CheckedChanged += new System.EventHandler(this.m_rbtnActionDetailSpecifique_CheckedChanged);
            // 
            // m_rbtnActionDetailEditElement
            // 
            this.m_rbtnActionDetailEditElement.AutoSize = true;
            this.m_rbtnActionDetailEditElement.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_rbtnActionDetailEditElement.Location = new System.Drawing.Point(0, 20);
            this.m_rbtnActionDetailEditElement.Name = "m_rbtnActionDetailEditElement";
            this.m_rbtnActionDetailEditElement.Size = new System.Drawing.Size(229, 17);
            this.m_ExtStyle1.SetStyleBackColor(this.m_rbtnActionDetailEditElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_rbtnActionDetailEditElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_rbtnActionDetailEditElement.TabIndex = 1;
            this.m_rbtnActionDetailEditElement.TabStop = true;
            this.m_rbtnActionDetailEditElement.Text = "Edit elementy|20803";
            this.m_rbtnActionDetailEditElement.UseVisualStyleBackColor = true;
            this.m_rbtnActionDetailEditElement.CheckedChanged += new System.EventHandler(this.m_rbtnActionDetailEditElement_CheckedChanged);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel6.Controls.Add(this.label18);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.ForeColor = System.Drawing.Color.White;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(229, 20);
            this.m_ExtStyle1.SetStyleBackColor(this.panel6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.panel6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel6.TabIndex = 0;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Dock = System.Windows.Forms.DockStyle.Left;
            this.label18.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(0, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(173, 19);
            this.m_ExtStyle1.SetStyleBackColor(this.label18, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.label18, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label18.TabIndex = 0;
            this.label18.Text = "Detail action|20802";
            // 
            // m_lnkAffectations
            // 
            this.m_lnkAffectations.AutoSize = true;
            this.m_lnkAffectations.Location = new System.Drawing.Point(8, 8);
            this.m_lnkAffectations.Name = "m_lnkAffectations";
            this.m_lnkAffectations.Size = new System.Drawing.Size(170, 13);
            this.m_ExtStyle1.SetStyleBackColor(this.m_lnkAffectations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_lnkAffectations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAffectations.TabIndex = 10;
            this.m_lnkAffectations.TabStop = true;
            this.m_lnkAffectations.Text = "New elements assignments|20689";
            this.m_lnkAffectations.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkAffectations_LinkClicked);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 18);
            this.m_ExtStyle1.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 7;
            this.label6.Text = "Titre";
            // 
            // m_txtTitreListe
            // 
            this.m_txtTitreListe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtTitreListe.BackColor = System.Drawing.Color.White;
            this.m_txtTitreListe.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtTitreListe.Formule = null;
            this.m_txtTitreListe.Location = new System.Drawing.Point(8, 74);
            this.m_txtTitreListe.LockEdition = false;
            this.m_txtTitreListe.Name = "m_txtTitreListe";
            this.m_txtTitreListe.Size = new System.Drawing.Size(573, 263);
            this.m_ExtStyle1.SetStyleBackColor(this.m_txtTitreListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_txtTitreListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtTitreListe.TabIndex = 8;
            this.m_txtTitreListe.Enter += new System.EventHandler(this.m_txtFormule_Enter);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Location = new System.Drawing.Point(8, 344);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 19);
            this.m_ExtStyle1.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 5;
            this.label4.Text = "Contexte du formulaire";
            // 
            // m_txtContexteListe
            // 
            this.m_txtContexteListe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtContexteListe.BackColor = System.Drawing.Color.White;
            this.m_txtContexteListe.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtContexteListe.Formule = null;
            this.m_txtContexteListe.Location = new System.Drawing.Point(8, 362);
            this.m_txtContexteListe.LockEdition = false;
            this.m_txtContexteListe.Name = "m_txtContexteListe";
            this.m_txtContexteListe.Size = new System.Drawing.Size(576, 74);
            this.m_ExtStyle1.SetStyleBackColor(this.m_txtContexteListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_txtContexteListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtContexteListe.TabIndex = 9;
            this.m_txtContexteListe.Enter += new System.EventHandler(this.m_txtFormule_Enter);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.m_chkListeAvecDetail);
            this.panel7.Controls.Add(this.m_chkListeAvecRemove);
            this.panel7.Controls.Add(this.m_chkListeAvecAjouter);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Location = new System.Drawing.Point(214, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(137, 67);
            this.m_ExtStyle1.SetStyleBackColor(this.panel7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.panel7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel7.TabIndex = 12;
            // 
            // m_chkListeAvecDetail
            // 
            this.m_chkListeAvecDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_chkListeAvecDetail.Location = new System.Drawing.Point(0, 52);
            this.m_chkListeAvecDetail.Name = "m_chkListeAvecDetail";
            this.m_chkListeAvecDetail.Size = new System.Drawing.Size(137, 16);
            this.m_ExtStyle1.SetStyleBackColor(this.m_chkListeAvecDetail, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_chkListeAvecDetail, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkListeAvecDetail.TabIndex = 4;
            this.m_chkListeAvecDetail.Text = "Detail|20808";
            this.m_chkListeAvecDetail.UseVisualStyleBackColor = true;
            // 
            // m_chkListeAvecRemove
            // 
            this.m_chkListeAvecRemove.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_chkListeAvecRemove.Location = new System.Drawing.Point(0, 36);
            this.m_chkListeAvecRemove.Name = "m_chkListeAvecRemove";
            this.m_chkListeAvecRemove.Size = new System.Drawing.Size(137, 16);
            this.m_ExtStyle1.SetStyleBackColor(this.m_chkListeAvecRemove, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_chkListeAvecRemove, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkListeAvecRemove.TabIndex = 3;
            this.m_chkListeAvecRemove.Text = "Remove|20807";
            this.m_chkListeAvecRemove.UseVisualStyleBackColor = true;
            // 
            // m_chkListeAvecAjouter
            // 
            this.m_chkListeAvecAjouter.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_chkListeAvecAjouter.Location = new System.Drawing.Point(0, 20);
            this.m_chkListeAvecAjouter.Name = "m_chkListeAvecAjouter";
            this.m_chkListeAvecAjouter.Size = new System.Drawing.Size(137, 16);
            this.m_ExtStyle1.SetStyleBackColor(this.m_chkListeAvecAjouter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_chkListeAvecAjouter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkListeAvecAjouter.TabIndex = 2;
            this.m_chkListeAvecAjouter.Text = "Add|20806";
            this.m_chkListeAvecAjouter.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel8.Controls.Add(this.label19);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.ForeColor = System.Drawing.Color.White;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(137, 20);
            this.m_ExtStyle1.SetStyleBackColor(this.panel8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.panel8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel8.TabIndex = 1;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Dock = System.Windows.Forms.DockStyle.Left;
            this.label19.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(0, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(132, 19);
            this.m_ExtStyle1.SetStyleBackColor(this.label19, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.label19, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label19.TabIndex = 0;
            this.label19.Text = "Buttons|20802";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(589, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 451);
            this.m_ExtStyle1.SetStyleBackColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitter1.TabIndex = 11;
            this.splitter1.TabStop = false;
            // 
            // m_wndAide
            // 
            this.m_wndAide.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_wndAide.FournisseurProprietes = null;
            this.m_wndAide.Location = new System.Drawing.Point(592, 0);
            this.m_wndAide.Name = "m_wndAide";
            this.m_wndAide.ObjetInterroge = null;
            this.m_wndAide.SendIdChamps = false;
            this.m_wndAide.Size = new System.Drawing.Size(232, 451);
            this.m_ExtStyle1.SetStyleBackColor(this.m_wndAide, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_wndAide, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndAide.TabIndex = 10;
            this.m_wndAide.OnSendCommande += new sc2i.win32.expression.SendCommande(this.m_wndAide_OnSendCommande);
            // 
            // m_panelAction
            // 
            this.m_panelAction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelAction.Controls.Add(this.label17);
            this.m_panelAction.Controls.Add(this.m_panelParametresAction);
            this.m_panelAction.Controls.Add(this.m_chkHideProgress);
            this.m_panelAction.Controls.Add(this.m_panelEvenementManuel);
            this.m_panelAction.Controls.Add(this.label1);
            this.m_panelAction.Controls.Add(this.m_selectionneurProcess);
            this.m_panelAction.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelAction.ForeColor = System.Drawing.Color.Black;
            this.m_panelAction.Location = new System.Drawing.Point(0, 756);
            this.m_panelAction.Name = "m_panelAction";
            this.m_panelAction.Size = new System.Drawing.Size(824, 332);
            this.m_ExtStyle1.SetStyleBackColor(this.m_panelAction, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_ExtStyle1.SetStyleForeColor(this.m_panelAction, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelAction.TabIndex = 3;
            this.m_panelAction.Paint += new System.Windows.Forms.PaintEventHandler(this.m_panelAction_Paint);
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(8, 106);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(181, 16);
            this.m_ExtStyle1.SetStyleBackColor(this.label17, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.label17, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label17.TabIndex = 7;
            this.label17.Text = "Action parameters|20127";
            // 
            // m_panelParametresAction
            // 
            this.m_panelParametresAction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelParametresAction.AutoScroll = true;
            this.m_panelParametresAction.HasDeleteButton = true;
            this.m_panelParametresAction.HasHadButton = true;
            this.m_panelParametresAction.HeaderTextForFormula = "";
            this.m_panelParametresAction.HeaderTextForName = "";
            this.m_panelParametresAction.HideNomFormule = false;
            this.m_panelParametresAction.Location = new System.Drawing.Point(7, 119);
            this.m_panelParametresAction.LockEdition = false;
            this.m_panelParametresAction.Name = "m_panelParametresAction";
            this.m_panelParametresAction.Size = new System.Drawing.Size(814, 205);
            this.m_ExtStyle1.SetStyleBackColor(this.m_panelParametresAction, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_panelParametresAction, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelParametresAction.TabIndex = 6;
            this.m_panelParametresAction.TypeFormuleNomme = typeof(sc2i.expression.CFormuleNommee);
            // 
            // m_chkHideProgress
            // 
            this.m_chkHideProgress.AutoSize = true;
            this.m_chkHideProgress.Location = new System.Drawing.Point(11, 86);
            this.m_chkHideProgress.Name = "m_chkHideProgress";
            this.m_chkHideProgress.Size = new System.Drawing.Size(141, 17);
            this.m_ExtStyle1.SetStyleBackColor(this.m_chkHideProgress, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_chkHideProgress, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkHideProgress.TabIndex = 5;
            this.m_chkHideProgress.Text = "Hide progress bar|20034";
            this.m_chkHideProgress.UseVisualStyleBackColor = true;
            // 
            // m_panelEvenementManuel
            // 
            this.m_panelEvenementManuel.Controls.Add(this.label7);
            this.m_panelEvenementManuel.Controls.Add(this.label8);
            this.m_panelEvenementManuel.Controls.Add(this.m_selectionneurEvenementManuel);
            this.m_panelEvenementManuel.Location = new System.Drawing.Point(8, 32);
            this.m_panelEvenementManuel.Name = "m_panelEvenementManuel";
            this.m_panelEvenementManuel.Size = new System.Drawing.Size(640, 48);
            this.m_ExtStyle1.SetStyleBackColor(this.m_panelEvenementManuel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_panelEvenementManuel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEvenementManuel.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(24, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.m_ExtStyle1.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 1;
            this.label7.Text = "or|63";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(0, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 24);
            this.m_ExtStyle1.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 3;
            this.label8.Text = "Manual Event|813";
            // 
            // m_selectionneurEvenementManuel
            // 
            this.m_selectionneurEvenementManuel.ElementSelectionne = null;
            this.m_selectionneurEvenementManuel.FonctionTextNull = null;
            this.m_selectionneurEvenementManuel.HasLink = true;
            this.m_selectionneurEvenementManuel.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_selectionneurEvenementManuel.Location = new System.Drawing.Point(125, 16);
            this.m_selectionneurEvenementManuel.LockEdition = false;
            this.m_selectionneurEvenementManuel.Name = "m_selectionneurEvenementManuel";
            this.m_selectionneurEvenementManuel.SelectedObject = null;
            this.m_selectionneurEvenementManuel.Size = new System.Drawing.Size(419, 24);
            this.m_selectionneurEvenementManuel.SpecificImage = null;
            this.m_ExtStyle1.SetStyleBackColor(this.m_selectionneurEvenementManuel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_selectionneurEvenementManuel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectionneurEvenementManuel.TabIndex = 2;
            this.m_selectionneurEvenementManuel.TextNull = "";
            this.m_selectionneurEvenementManuel.ElementSelectionneChanged += new System.EventHandler(this.m_selectionneurEvenementManuel_OnChangeSelection);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.m_ExtStyle1.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 1;
            this.label1.Text = "Action|162";
            // 
            // m_selectionneurProcess
            // 
            this.m_selectionneurProcess.ElementSelectionne = null;
            this.m_selectionneurProcess.FonctionTextNull = null;
            this.m_selectionneurProcess.HasLink = true;
            this.m_selectionneurProcess.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_selectionneurProcess.Location = new System.Drawing.Point(133, 9);
            this.m_selectionneurProcess.LockEdition = false;
            this.m_selectionneurProcess.Name = "m_selectionneurProcess";
            this.m_selectionneurProcess.SelectedObject = null;
            this.m_selectionneurProcess.Size = new System.Drawing.Size(419, 24);
            this.m_selectionneurProcess.SpecificImage = null;
            this.m_ExtStyle1.SetStyleBackColor(this.m_selectionneurProcess, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_selectionneurProcess, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectionneurProcess.TabIndex = 0;
            this.m_selectionneurProcess.TextNull = "";
            this.m_selectionneurProcess.ElementSelectionneChanged += new System.EventHandler(this.m_selectionneurProcess_OnChangeSelection);
            // 
            // m_panelAfficherEntite
            // 
            this.m_panelAfficherEntite.Controls.Add(this.m_panelActionAfficherEntite);
            this.m_panelAfficherEntite.Controls.Add(this.splitter3);
            this.m_panelAfficherEntite.Controls.Add(this.m_wndAideFormuleAfficherEntite);
            this.m_panelAfficherEntite.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelAfficherEntite.Location = new System.Drawing.Point(0, 43);
            this.m_panelAfficherEntite.Name = "m_panelAfficherEntite";
            this.m_panelAfficherEntite.Size = new System.Drawing.Size(824, 372);
            this.m_ExtStyle1.SetStyleBackColor(this.m_panelAfficherEntite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_panelAfficherEntite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelAfficherEntite.TabIndex = 8;
            // 
            // m_panelActionAfficherEntite
            // 
            this.m_panelActionAfficherEntite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelActionAfficherEntite.BoldSelectedPage = true;
            this.m_panelActionAfficherEntite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelActionAfficherEntite.ForeColor = System.Drawing.Color.Black;
            this.m_panelActionAfficherEntite.IDEPixelArea = false;
            this.m_panelActionAfficherEntite.Location = new System.Drawing.Point(0, 0);
            this.m_panelActionAfficherEntite.Name = "m_panelActionAfficherEntite";
            this.m_panelActionAfficherEntite.Ombre = false;
            this.m_panelActionAfficherEntite.PositionTop = true;
            this.m_panelActionAfficherEntite.SelectedIndex = 0;
            this.m_panelActionAfficherEntite.SelectedTab = this.tabPage7;
            this.m_panelActionAfficherEntite.Size = new System.Drawing.Size(612, 372);
            this.m_ExtStyle1.SetStyleBackColor(this.m_panelActionAfficherEntite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_panelActionAfficherEntite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelActionAfficherEntite.TabIndex = 7;
            this.m_panelActionAfficherEntite.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage7,
            this.tabPage6});
            this.m_panelActionAfficherEntite.TextColor = System.Drawing.Color.Black;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.label14);
            this.tabPage7.Controls.Add(this.m_txtFormuleEntite);
            this.tabPage7.Location = new System.Drawing.Point(0, 25);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(612, 347);
            this.m_ExtStyle1.SetStyleBackColor(this.tabPage7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.tabPage7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage7.TabIndex = 12;
            this.tabPage7.Title = "Entity|159";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(8, 8);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(136, 16);
            this.m_ExtStyle1.SetStyleBackColor(this.label14, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.label14, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label14.TabIndex = 10;
            this.label14.Text = "Entity to edit|161";
            // 
            // m_txtFormuleEntite
            // 
            this.m_txtFormuleEntite.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormuleEntite.BackColor = System.Drawing.Color.White;
            this.m_txtFormuleEntite.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtFormuleEntite.Formule = null;
            this.m_txtFormuleEntite.Location = new System.Drawing.Point(8, 24);
            this.m_txtFormuleEntite.LockEdition = false;
            this.m_txtFormuleEntite.Name = "m_txtFormuleEntite";
            this.m_txtFormuleEntite.Size = new System.Drawing.Size(596, 317);
            this.m_ExtStyle1.SetStyleBackColor(this.m_txtFormuleEntite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_txtFormuleEntite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleEntite.TabIndex = 9;
            this.m_txtFormuleEntite.Enter += new System.EventHandler(this.m_txtFormule_Enter);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.panel4);
            this.tabPage6.Location = new System.Drawing.Point(0, 25);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Selected = false;
            this.tabPage6.Size = new System.Drawing.Size(612, 347);
            this.m_ExtStyle1.SetStyleBackColor(this.tabPage6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.tabPage6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage6.TabIndex = 11;
            this.tabPage6.Title = "Page options|160";
            this.tabPage6.Visible = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.m_txtCodeFormulaireEdition);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.m_txtFormuleTitreAfficheEntite);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.m_txtFormuleContexteEntite);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(612, 347);
            this.m_ExtStyle1.SetStyleBackColor(this.panel4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.panel4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel4.TabIndex = 9;
            // 
            // m_txtCodeFormulaireEdition
            // 
            this.m_txtCodeFormulaireEdition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtCodeFormulaireEdition.Location = new System.Drawing.Point(8, 307);
            this.m_txtCodeFormulaireEdition.Name = "m_txtCodeFormulaireEdition";
            this.m_txtCodeFormulaireEdition.Size = new System.Drawing.Size(596, 21);
            this.m_ExtStyle1.SetStyleBackColor(this.m_txtCodeFormulaireEdition, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_txtCodeFormulaireEdition, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtCodeFormulaireEdition.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(8, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(374, 16);
            this.m_ExtStyle1.SetStyleBackColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label11.TabIndex = 7;
            this.label11.Text = "Form title|1055";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtFormuleTitreAfficheEntite
            // 
            this.m_txtFormuleTitreAfficheEntite.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormuleTitreAfficheEntite.BackColor = System.Drawing.Color.White;
            this.m_txtFormuleTitreAfficheEntite.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtFormuleTitreAfficheEntite.Formule = null;
            this.m_txtFormuleTitreAfficheEntite.Location = new System.Drawing.Point(8, 24);
            this.m_txtFormuleTitreAfficheEntite.LockEdition = false;
            this.m_txtFormuleTitreAfficheEntite.Name = "m_txtFormuleTitreAfficheEntite";
            this.m_txtFormuleTitreAfficheEntite.Size = new System.Drawing.Size(596, 347);
            this.m_ExtStyle1.SetStyleBackColor(this.m_txtFormuleTitreAfficheEntite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_txtFormuleTitreAfficheEntite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleTitreAfficheEntite.TabIndex = 8;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.Location = new System.Drawing.Point(8, 283);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(520, 23);
            this.m_ExtStyle1.SetStyleBackColor(this.label16, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.label16, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label16.TabIndex = 5;
            this.label16.Text = "Form code (leave empty for default system form)|10027";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.Location = new System.Drawing.Point(8, 180);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(327, 23);
            this.m_ExtStyle1.SetStyleBackColor(this.label12, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.label12, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label12.TabIndex = 5;
            this.label12.Text = "Form context|812";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtFormuleContexteEntite
            // 
            this.m_txtFormuleContexteEntite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormuleContexteEntite.BackColor = System.Drawing.Color.White;
            this.m_txtFormuleContexteEntite.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtFormuleContexteEntite.Formule = null;
            this.m_txtFormuleContexteEntite.Location = new System.Drawing.Point(8, 203);
            this.m_txtFormuleContexteEntite.LockEdition = false;
            this.m_txtFormuleContexteEntite.Name = "m_txtFormuleContexteEntite";
            this.m_txtFormuleContexteEntite.Size = new System.Drawing.Size(596, 72);
            this.m_ExtStyle1.SetStyleBackColor(this.m_txtFormuleContexteEntite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_txtFormuleContexteEntite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleContexteEntite.TabIndex = 9;
            // 
            // splitter3
            // 
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter3.Location = new System.Drawing.Point(612, 0);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(3, 372);
            this.m_ExtStyle1.SetStyleBackColor(this.splitter3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.splitter3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitter3.TabIndex = 12;
            this.splitter3.TabStop = false;
            // 
            // m_wndAideFormuleAfficherEntite
            // 
            this.m_wndAideFormuleAfficherEntite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_wndAideFormuleAfficherEntite.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_wndAideFormuleAfficherEntite.ForeColor = System.Drawing.Color.Black;
            this.m_wndAideFormuleAfficherEntite.FournisseurProprietes = null;
            this.m_wndAideFormuleAfficherEntite.Location = new System.Drawing.Point(615, 0);
            this.m_wndAideFormuleAfficherEntite.Name = "m_wndAideFormuleAfficherEntite";
            this.m_wndAideFormuleAfficherEntite.ObjetInterroge = null;
            this.m_wndAideFormuleAfficherEntite.SendIdChamps = false;
            this.m_wndAideFormuleAfficherEntite.Size = new System.Drawing.Size(209, 372);
            this.m_ExtStyle1.SetStyleBackColor(this.m_wndAideFormuleAfficherEntite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_wndAideFormuleAfficherEntite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndAideFormuleAfficherEntite.TabIndex = 11;
            this.m_wndAideFormuleAfficherEntite.OnSendCommande += new sc2i.win32.expression.SendCommande(this.m_wndAideFormuleAfficherEntite_OnSendCommande);
            // 
            // m_panelFormulaireCustom
            // 
            this.m_panelFormulaireCustom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelFormulaireCustom.Controls.Add(this.m_cmbFormulaireCustom);
            this.m_panelFormulaireCustom.Controls.Add(this.label3);
            this.m_panelFormulaireCustom.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelFormulaireCustom.ForeColor = System.Drawing.Color.Black;
            this.m_panelFormulaireCustom.Location = new System.Drawing.Point(0, 0);
            this.m_panelFormulaireCustom.Name = "m_panelFormulaireCustom";
            this.m_panelFormulaireCustom.Size = new System.Drawing.Size(824, 43);
            this.m_ExtStyle1.SetStyleBackColor(this.m_panelFormulaireCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_ExtStyle1.SetStyleForeColor(this.m_panelFormulaireCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelFormulaireCustom.TabIndex = 6;
            // 
            // m_cmbFormulaireCustom
            // 
            this.m_cmbFormulaireCustom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbFormulaireCustom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbFormulaireCustom.IsLink = false;
            this.m_cmbFormulaireCustom.ListDonnees = null;
            this.m_cmbFormulaireCustom.Location = new System.Drawing.Point(133, 7);
            this.m_cmbFormulaireCustom.LockEdition = false;
            this.m_cmbFormulaireCustom.Name = "m_cmbFormulaireCustom";
            this.m_cmbFormulaireCustom.NullAutorise = true;
            this.m_cmbFormulaireCustom.ProprieteAffichee = "Libelle";
            this.m_cmbFormulaireCustom.Size = new System.Drawing.Size(419, 21);
            this.m_ExtStyle1.SetStyleBackColor(this.m_cmbFormulaireCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_cmbFormulaireCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbFormulaireCustom.TabIndex = 3;
            this.m_cmbFormulaireCustom.TextNull = "(none)";
            this.m_cmbFormulaireCustom.Tri = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.m_ExtStyle1.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 2;
            this.label3.Text = "Form|555";
            // 
            // m_panelFormulaire
            // 
            this.m_panelFormulaire.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelFormulaire.Controls.Add(this.m_panelParametresFormulaire);
            this.m_panelFormulaire.Controls.Add(this.m_txtContexteFormulaire);
            this.m_panelFormulaire.Controls.Add(this.label5);
            this.m_panelFormulaire.Controls.Add(this.m_cmbFormulaireStandard);
            this.m_panelFormulaire.Controls.Add(this.label2);
            this.m_panelFormulaire.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelFormulaire.ForeColor = System.Drawing.Color.Black;
            this.m_panelFormulaire.Location = new System.Drawing.Point(0, 415);
            this.m_panelFormulaire.Name = "m_panelFormulaire";
            this.m_panelFormulaire.Size = new System.Drawing.Size(824, 341);
            this.m_ExtStyle1.SetStyleBackColor(this.m_panelFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_ExtStyle1.SetStyleForeColor(this.m_panelFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelFormulaire.TabIndex = 5;
            // 
            // m_panelParametresFormulaire
            // 
            this.m_panelParametresFormulaire.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelParametresFormulaire.Controls.Add(this.m_splitContainer1);
            this.m_panelParametresFormulaire.Location = new System.Drawing.Point(0, 55);
            this.m_panelParametresFormulaire.Name = "m_panelParametresFormulaire";
            this.m_panelParametresFormulaire.Size = new System.Drawing.Size(815, 300);
            this.m_ExtStyle1.SetStyleBackColor(this.m_panelParametresFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_panelParametresFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelParametresFormulaire.TabIndex = 11;
            // 
            // m_splitContainer1
            // 
            this.m_splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.m_splitContainer1.Name = "m_splitContainer1";
            // 
            // m_splitContainer1.Panel1
            // 
            this.m_splitContainer1.Panel1.Controls.Add(this.m_splitContainer2);
            this.m_ExtStyle1.SetStyleBackColor(this.m_splitContainer1.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_splitContainer1.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_splitContainer1.Panel2
            // 
            this.m_splitContainer1.Panel2.Controls.Add(this.m_wndAideFormuleParametre);
            this.m_ExtStyle1.SetStyleBackColor(this.m_splitContainer1.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_splitContainer1.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_splitContainer1.Size = new System.Drawing.Size(815, 300);
            this.m_splitContainer1.SplitterDistance = 555;
            this.m_ExtStyle1.SetStyleBackColor(this.m_splitContainer1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_splitContainer1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_splitContainer1.TabIndex = 10;
            // 
            // m_splitContainer2
            // 
            this.m_splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.m_splitContainer2.Name = "m_splitContainer2";
            // 
            // m_splitContainer2.Panel1
            // 
            this.m_splitContainer2.Panel1.Controls.Add(this.m_wndListeParametres);
            this.m_splitContainer2.Panel1.Controls.Add(this.label13);
            this.m_ExtStyle1.SetStyleBackColor(this.m_splitContainer2.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_splitContainer2.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_splitContainer2.Panel2
            // 
            this.m_splitContainer2.Panel2.Controls.Add(this.m_splitContainerInfosParam);
            this.m_ExtStyle1.SetStyleBackColor(this.m_splitContainer2.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_splitContainer2.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_splitContainer2.Size = new System.Drawing.Size(553, 298);
            this.m_splitContainer2.SplitterDistance = 231;
            this.m_ExtStyle1.SetStyleBackColor(this.m_splitContainer2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_splitContainer2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_splitContainer2.TabIndex = 5;
            // 
            // m_wndListeParametres
            // 
            this.m_wndListeParametres.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_wndListeParametres.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn2});
            this.m_wndListeParametres.EnableCustomisation = true;
            this.m_wndListeParametres.FullRowSelect = true;
            this.m_wndListeParametres.Location = new System.Drawing.Point(7, 28);
            this.m_wndListeParametres.MultiSelect = false;
            this.m_wndListeParametres.Name = "m_wndListeParametres";
            this.m_wndListeParametres.Size = new System.Drawing.Size(221, 298);
            this.m_ExtStyle1.SetStyleBackColor(this.m_wndListeParametres, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_wndListeParametres, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeParametres.TabIndex = 0;
            this.m_wndListeParametres.UseCompatibleStateImageBehavior = false;
            this.m_wndListeParametres.View = System.Windows.Forms.View.Details;
            this.m_wndListeParametres.SelectedIndexChanged += new System.EventHandler(this.m_wndListeParametres_SelectedIndexChanged);
            // 
            // listViewAutoFilledColumn2
            // 
            this.listViewAutoFilledColumn2.Field = "InfoParametre.Nom";
            this.listViewAutoFilledColumn2.PrecisionWidth = 0;
            this.listViewAutoFilledColumn2.ProportionnalSize = false;
            this.listViewAutoFilledColumn2.Text = "Name|82";
            this.listViewAutoFilledColumn2.Visible = true;
            this.listViewAutoFilledColumn2.Width = 176;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(7, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(221, 16);
            this.m_ExtStyle1.SetStyleBackColor(this.label13, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.label13, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label13.TabIndex = 4;
            this.label13.Text = "Form Parameters|10008";
            // 
            // m_splitContainerInfosParam
            // 
            this.m_splitContainerInfosParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_splitContainerInfosParam.Location = new System.Drawing.Point(0, 0);
            this.m_splitContainerInfosParam.Name = "m_splitContainerInfosParam";
            this.m_splitContainerInfosParam.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // m_splitContainerInfosParam.Panel1
            // 
            this.m_splitContainerInfosParam.Panel1.Controls.Add(this.m_lblNomParametre);
            this.m_splitContainerInfosParam.Panel1.Controls.Add(this.m_txtFormuleParametre);
            this.m_splitContainerInfosParam.Panel1.Controls.Add(this.label15);
            this.m_ExtStyle1.SetStyleBackColor(this.m_splitContainerInfosParam.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_splitContainerInfosParam.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_splitContainerInfosParam.Panel2
            // 
            this.m_splitContainerInfosParam.Panel2.Controls.Add(this.m_lblDescriptionParametre);
            this.m_ExtStyle1.SetStyleBackColor(this.m_splitContainerInfosParam.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_splitContainerInfosParam.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_splitContainerInfosParam.Size = new System.Drawing.Size(318, 298);
            this.m_splitContainerInfosParam.SplitterDistance = 137;
            this.m_ExtStyle1.SetStyleBackColor(this.m_splitContainerInfosParam, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_splitContainerInfosParam, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_splitContainerInfosParam.TabIndex = 4;
            // 
            // m_lblNomParametre
            // 
            this.m_lblNomParametre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblNomParametre.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblNomParametre.Location = new System.Drawing.Point(4, 6);
            this.m_lblNomParametre.Name = "m_lblNomParametre";
            this.m_lblNomParametre.Size = new System.Drawing.Size(309, 16);
            this.m_ExtStyle1.SetStyleBackColor(this.m_lblNomParametre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_lblNomParametre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblNomParametre.TabIndex = 3;
            this.m_lblNomParametre.Text = "Parameter Name";
            // 
            // m_txtFormuleParametre
            // 
            this.m_txtFormuleParametre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormuleParametre.BackColor = System.Drawing.Color.White;
            this.m_txtFormuleParametre.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtFormuleParametre.Formule = null;
            this.m_txtFormuleParametre.Location = new System.Drawing.Point(3, 44);
            this.m_txtFormuleParametre.LockEdition = false;
            this.m_txtFormuleParametre.Name = "m_txtFormuleParametre";
            this.m_txtFormuleParametre.Size = new System.Drawing.Size(310, 90);
            this.m_ExtStyle1.SetStyleBackColor(this.m_txtFormuleParametre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_txtFormuleParametre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleParametre.TabIndex = 1;
            this.m_txtFormuleParametre.Enter += new System.EventHandler(this.m_txtFormuleParametre_Enter);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(4, 26);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(216, 16);
            this.m_ExtStyle1.SetStyleBackColor(this.label15, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.label15, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label15.TabIndex = 2;
            this.label15.Text = "Parameter Value|10009";
            // 
            // m_lblDescriptionParametre
            // 
            this.m_lblDescriptionParametre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblDescriptionParametre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.m_lblDescriptionParametre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblDescriptionParametre.Location = new System.Drawing.Point(3, 2);
            this.m_lblDescriptionParametre.Name = "m_lblDescriptionParametre";
            this.m_lblDescriptionParametre.Size = new System.Drawing.Size(310, 150);
            this.m_ExtStyle1.SetStyleBackColor(this.m_lblDescriptionParametre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_lblDescriptionParametre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblDescriptionParametre.TabIndex = 2;
            this.m_lblDescriptionParametre.Text = "Parameter description";
            // 
            // m_wndAideFormuleParametre
            // 
            this.m_wndAideFormuleParametre.BackColor = System.Drawing.Color.White;
            this.m_wndAideFormuleParametre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndAideFormuleParametre.FournisseurProprietes = null;
            this.m_wndAideFormuleParametre.Location = new System.Drawing.Point(0, 0);
            this.m_wndAideFormuleParametre.Name = "m_wndAideFormuleParametre";
            this.m_wndAideFormuleParametre.ObjetInterroge = null;
            this.m_wndAideFormuleParametre.SendIdChamps = false;
            this.m_wndAideFormuleParametre.Size = new System.Drawing.Size(254, 298);
            this.m_ExtStyle1.SetStyleBackColor(this.m_wndAideFormuleParametre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_wndAideFormuleParametre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndAideFormuleParametre.TabIndex = 7;
            this.m_wndAideFormuleParametre.OnSendCommande += new sc2i.win32.expression.SendCommande(this.m_wndAideFormuleParametre_OnSendCommande);
            // 
            // m_txtContexteFormulaire
            // 
            this.m_txtContexteFormulaire.Location = new System.Drawing.Point(133, 29);
            this.m_txtContexteFormulaire.Name = "m_txtContexteFormulaire";
            this.m_txtContexteFormulaire.Size = new System.Drawing.Size(419, 20);
            this.m_ExtStyle1.SetStyleBackColor(this.m_txtContexteFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_txtContexteFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtContexteFormulaire.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 20);
            this.m_ExtStyle1.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 4;
            this.label5.Text = "Form context|812";
            // 
            // m_cmbFormulaireStandard
            // 
            this.m_cmbFormulaireStandard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbFormulaireStandard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbFormulaireStandard.IsLink = false;
            this.m_cmbFormulaireStandard.ListDonnees = null;
            this.m_cmbFormulaireStandard.Location = new System.Drawing.Point(133, 5);
            this.m_cmbFormulaireStandard.LockEdition = false;
            this.m_cmbFormulaireStandard.Name = "m_cmbFormulaireStandard";
            this.m_cmbFormulaireStandard.NullAutorise = true;
            this.m_cmbFormulaireStandard.ProprieteAffichee = "Nom";
            this.m_cmbFormulaireStandard.Size = new System.Drawing.Size(419, 21);
            this.m_ExtStyle1.SetStyleBackColor(this.m_cmbFormulaireStandard, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_cmbFormulaireStandard, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbFormulaireStandard.TabIndex = 3;
            this.m_cmbFormulaireStandard.TextNull = "(none)";
            this.m_cmbFormulaireStandard.Tri = true;
            this.m_cmbFormulaireStandard.SelectionChangeCommitted += new System.EventHandler(this.m_cmbFormulaireStandard_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.m_ExtStyle1.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 2;
            this.label2.Text = "Form|555";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_btnAnnuler);
            this.panel1.Controls.Add(this.m_btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 514);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(832, 48);
            this.m_ExtStyle1.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 4;
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnAnnuler.ForeColor = System.Drawing.Color.White;
            this.m_btnAnnuler.Image = ((System.Drawing.Image)(resources.GetObject("m_btnAnnuler.Image")));
            this.m_btnAnnuler.Location = new System.Drawing.Point(423, 2);
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(40, 40);
            this.m_ExtStyle1.SetStyleBackColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAnnuler.TabIndex = 3;
            // 
            // m_btnOk
            // 
            this.m_btnOk.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnOk.ForeColor = System.Drawing.Color.White;
            this.m_btnOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btnOk.Image")));
            this.m_btnOk.Location = new System.Drawing.Point(369, 2);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(40, 40);
            this.m_ExtStyle1.SetStyleBackColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnOk.TabIndex = 2;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            // 
            // m_chkFormulaire
            // 
            this.m_chkFormulaire.Location = new System.Drawing.Point(494, 8);
            this.m_chkFormulaire.Name = "m_chkFormulaire";
            this.m_chkFormulaire.Size = new System.Drawing.Size(141, 16);
            this.m_ExtStyle1.SetStyleBackColor(this.m_chkFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_chkFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkFormulaire.TabIndex = 5;
            this.m_chkFormulaire.Text = "Standard form|157";
            this.m_chkFormulaire.CheckedChanged += new System.EventHandler(this.m_chkFormulaire_CheckedChanged);
            // 
            // m_chkFormulairePersonnalisé
            // 
            this.m_chkFormulairePersonnalisé.Location = new System.Drawing.Point(647, 8);
            this.m_chkFormulairePersonnalisé.Name = "m_chkFormulairePersonnalisé";
            this.m_chkFormulairePersonnalisé.Size = new System.Drawing.Size(163, 16);
            this.m_ExtStyle1.SetStyleBackColor(this.m_chkFormulairePersonnalisé, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_chkFormulairePersonnalisé, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkFormulairePersonnalisé.TabIndex = 6;
            this.m_chkFormulairePersonnalisé.Text = "Custom form|158";
            this.m_chkFormulairePersonnalisé.CheckedChanged += new System.EventHandler(this.m_chkFormulaire_CheckedChanged);
            // 
            // m_chkAfficherEntite
            // 
            this.m_chkAfficherEntite.Location = new System.Drawing.Point(333, 8);
            this.m_chkAfficherEntite.Name = "m_chkAfficherEntite";
            this.m_chkAfficherEntite.Size = new System.Drawing.Size(155, 18);
            this.m_ExtStyle1.SetStyleBackColor(this.m_chkAfficherEntite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.m_chkAfficherEntite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkAfficherEntite.TabIndex = 7;
            this.m_chkAfficherEntite.Text = "Display one entity|156";
            this.m_chkAfficherEntite.CheckedChanged += new System.EventHandler(this.m_chkAfficherEntite_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(184)))));
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.cControleEditeFormule1);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.cControleEditeFormule2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(461, 279);
            this.m_ExtStyle1.SetStyleBackColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel3.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(8, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 16);
            this.m_ExtStyle1.SetStyleBackColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label9.TabIndex = 7;
            this.label9.Text = "Titre";
            // 
            // cControleEditeFormule1
            // 
            this.cControleEditeFormule1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cControleEditeFormule1.BackColor = System.Drawing.Color.White;
            this.cControleEditeFormule1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cControleEditeFormule1.Formule = null;
            this.cControleEditeFormule1.Location = new System.Drawing.Point(8, 24);
            this.cControleEditeFormule1.LockEdition = false;
            this.cControleEditeFormule1.Name = "cControleEditeFormule1";
            this.cControleEditeFormule1.Size = new System.Drawing.Size(445, 143);
            this.m_ExtStyle1.SetStyleBackColor(this.cControleEditeFormule1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.cControleEditeFormule1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cControleEditeFormule1.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.Location = new System.Drawing.Point(8, 168);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 23);
            this.m_ExtStyle1.SetStyleBackColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label10.TabIndex = 5;
            this.label10.Text = "Contexte du formulaire";
            // 
            // cControleEditeFormule2
            // 
            this.cControleEditeFormule2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cControleEditeFormule2.BackColor = System.Drawing.Color.White;
            this.cControleEditeFormule2.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cControleEditeFormule2.Formule = null;
            this.cControleEditeFormule2.Location = new System.Drawing.Point(8, 192);
            this.cControleEditeFormule2.LockEdition = false;
            this.cControleEditeFormule2.Name = "cControleEditeFormule2";
            this.cControleEditeFormule2.Size = new System.Drawing.Size(448, 72);
            this.m_ExtStyle1.SetStyleBackColor(this.cControleEditeFormule2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.cControleEditeFormule2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cControleEditeFormule2.TabIndex = 9;
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(184)))));
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.splitter2.Location = new System.Drawing.Point(461, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 279);
            this.m_ExtStyle1.SetStyleBackColor(this.splitter2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.splitter2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitter2.TabIndex = 11;
            this.splitter2.TabStop = false;
            // 
            // cControlAideFormule1
            // 
            this.cControlAideFormule1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(184)))));
            this.cControlAideFormule1.Dock = System.Windows.Forms.DockStyle.Right;
            this.cControlAideFormule1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.cControlAideFormule1.FournisseurProprietes = null;
            this.cControlAideFormule1.Location = new System.Drawing.Point(464, 0);
            this.cControlAideFormule1.Name = "cControlAideFormule1";
            this.cControlAideFormule1.ObjetInterroge = null;
            this.cControlAideFormule1.SendIdChamps = false;
            this.cControlAideFormule1.Size = new System.Drawing.Size(232, 279);
            this.m_ExtStyle1.SetStyleBackColor(this.cControlAideFormule1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.cControlAideFormule1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cControlAideFormule1.TabIndex = 10;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(184)))));
            this.tabPage4.Controls.Add(this.panel3);
            this.tabPage4.Controls.Add(this.splitter2);
            this.tabPage4.Controls.Add(this.cControlAideFormule1);
            this.tabPage4.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.tabPage4.Location = new System.Drawing.Point(0, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Selected = false;
            this.tabPage4.Size = new System.Drawing.Size(696, 279);
            this.m_ExtStyle1.SetStyleBackColor(this.tabPage4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.tabPage4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage4.TabIndex = 11;
            this.tabPage4.Title = "Options de la page";
            this.tabPage4.Visible = false;
            // 
            // cPanelEditFiltreDynamique1
            // 
            this.cPanelEditFiltreDynamique1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cPanelEditFiltreDynamique1.BackColor = System.Drawing.Color.White;
            this.cPanelEditFiltreDynamique1.Controls.Add(this.c2iTabControl3);
            this.cPanelEditFiltreDynamique1.Controls.Add(this.c2iTabControl4);
            this.cPanelEditFiltreDynamique1.DefinitionRacineDeChampsFiltres = null;
            this.cPanelEditFiltreDynamique1.FiltreDynamique = null;
            this.cPanelEditFiltreDynamique1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.cPanelEditFiltreDynamique1.Location = new System.Drawing.Point(0, 0);
            this.cPanelEditFiltreDynamique1.LockEdition = false;
            this.cPanelEditFiltreDynamique1.ModeFiltreExpression = false;
            this.cPanelEditFiltreDynamique1.ModeSansType = false;
            this.cPanelEditFiltreDynamique1.Name = "cPanelEditFiltreDynamique1";
            this.cPanelEditFiltreDynamique1.Size = new System.Drawing.Size(696, 280);
            this.m_ExtStyle1.SetStyleBackColor(this.cPanelEditFiltreDynamique1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.cPanelEditFiltreDynamique1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cPanelEditFiltreDynamique1.TabIndex = 1;
            // 
            // c2iTabControl3
            // 
            this.c2iTabControl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(184)))));
            this.c2iTabControl3.BoldSelectedPage = true;
            this.c2iTabControl3.ControlBottomOffset = 16;
            this.c2iTabControl3.ControlRightOffset = 16;
            this.c2iTabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c2iTabControl3.IDEPixelArea = false;
            this.c2iTabControl3.Location = new System.Drawing.Point(0, 0);
            this.c2iTabControl3.Name = "c2iTabControl3";
            this.c2iTabControl3.Ombre = true;
            this.c2iTabControl3.PositionTop = true;
            this.c2iTabControl3.Size = new System.Drawing.Size(696, 280);
            this.m_ExtStyle1.SetStyleBackColor(this.c2iTabControl3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.c2iTabControl3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTabControl3.TabIndex = 2;
            // 
            // c2iTabControl4
            // 
            this.c2iTabControl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(184)))));
            this.c2iTabControl4.BoldSelectedPage = true;
            this.c2iTabControl4.ControlBottomOffset = 16;
            this.c2iTabControl4.ControlRightOffset = 16;
            this.c2iTabControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c2iTabControl4.IDEPixelArea = false;
            this.c2iTabControl4.Location = new System.Drawing.Point(0, 0);
            this.c2iTabControl4.Name = "c2iTabControl4";
            this.c2iTabControl4.Ombre = true;
            this.c2iTabControl4.PositionTop = true;
            this.c2iTabControl4.Size = new System.Drawing.Size(696, 280);
            this.m_ExtStyle1.SetStyleBackColor(this.c2iTabControl4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.c2iTabControl4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTabControl4.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(184)))));
            this.tabPage3.Controls.Add(this.cPanelEditFiltreDynamique1);
            this.tabPage3.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.tabPage3.Location = new System.Drawing.Point(0, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Selected = false;
            this.tabPage3.Size = new System.Drawing.Size(696, 279);
            this.m_ExtStyle1.SetStyleBackColor(this.tabPage3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this.tabPage3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage3.TabIndex = 10;
            this.tabPage3.Title = "Filtre";
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "Nom";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Name|164";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 176;
            // 
            // CFormEditActionSurLinkOld
            // 
            this.AcceptButton = this.m_btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.m_btnAnnuler;
            this.ClientSize = new System.Drawing.Size(832, 562);
            this.Controls.Add(this.m_chkAfficherEntite);
            this.Controls.Add(this.m_chkFormulairePersonnalisé);
            this.Controls.Add(this.m_chkFormulaire);
            this.Controls.Add(this.m_chkListe);
            this.Controls.Add(this.m_chkAction);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_panelComplet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CFormEditActionSurLinkOld";
            this.m_ExtStyle1.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle1.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "Action to execute|153";
            this.Load += new System.EventHandler(this.CFormEditActionSurLinkOld_Load);
            this.m_panelComplet.ResumeLayout(false);
            this.m_panelListeEntites.ResumeLayout(false);
            this.m_tabPageListe.ResumeLayout(false);
            this.m_tabPageListe.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.m_panelEditFiltre.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_imgFiltreSpecifiqueOnList)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.m_panelAction.ResumeLayout(false);
            this.m_panelAction.PerformLayout();
            this.m_panelEvenementManuel.ResumeLayout(false);
            this.m_panelAfficherEntite.ResumeLayout(false);
            this.m_panelActionAfficherEntite.ResumeLayout(false);
            this.m_panelActionAfficherEntite.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.m_panelFormulaireCustom.ResumeLayout(false);
            this.m_panelFormulaire.ResumeLayout(false);
            this.m_panelFormulaire.PerformLayout();
            this.m_panelParametresFormulaire.ResumeLayout(false);
            this.m_splitContainer1.Panel1.ResumeLayout(false);
            this.m_splitContainer1.Panel2.ResumeLayout(false);
            this.m_splitContainer1.ResumeLayout(false);
            this.m_splitContainer2.Panel1.ResumeLayout(false);
            this.m_splitContainer2.Panel2.ResumeLayout(false);
            this.m_splitContainer2.ResumeLayout(false);
            this.m_splitContainerInfosParam.Panel1.ResumeLayout(false);
            this.m_splitContainerInfosParam.Panel2.ResumeLayout(false);
            this.m_splitContainerInfosParam.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.cPanelEditFiltreDynamique1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

		}


        
		#endregion

		public static void Autoexec()
		{
		}

		/// //////////////////////////////////////////
        public CObjetPourSousProprietes ObjetPourSousProprietes
        {
            get
            {
                return m_objetPourSousProprietes;
            }
            set
            {
                m_objetPourSousProprietes = value;
            }
        }

		private void CFormEditActionSurLinkOld_Load(object sender, System.EventArgs e)
		{
			sc2i.win32.common.CWin32Traducteur.Translate ( this );
			SetTexteFormule ( m_txtTitreListe );
			m_chkAction.Checked=  m_actionEditee is CActionSur2iLinkExecuterProcess;
			m_chkListe.Checked = m_actionEditee is CActionSur2iLinkAfficherListe;
			m_chkFormulaire.Checked = m_actionEditee is CActionSur2iLinkAfficherFormulaire;
			m_chkFormulairePersonnalisé.Checked = m_actionEditee is CActionSur2iLinkAfficheFormulaireCustom;
			m_chkAfficherEntite.Checked = m_actionEditee is CActionSur2iLinkAfficherEntite;

            m_splitContainerInfosParam.Visible = false;
			ArrayList lstForms = new ArrayList();
			//Cherche tous les formulaires connus
			foreach ( Assembly ass in CGestionnaireAssemblies.GetAssemblies() )
			{
				foreach ( Type tp in ass.GetTypes() )
				{
					if ( !tp.IsAbstract && tp.IsSubclassOf ( typeof(System.Windows.Forms.Form) ) )
					{
						string strLibelle = "";
						object[] attribs = tp.GetCustomAttributes ( typeof(ObjectListeur), true);
						if ( attribs.Length > 0 )
						{
							Type tpListe = ((ObjectListeur)attribs[0]).TypeListe;
							strLibelle = "Liste de "+DynamicClassAttribute.GetNomConvivial ( tpListe );
						}
						else
						{
							attribs = tp.GetCustomAttributes ( typeof(DynamicFormAttribute), true );
							if ( attribs.Length > 0 )
							{
								strLibelle = ((DynamicFormAttribute)attribs[0]).Libelle;
							}
						}
						if ( strLibelle != "" )
						{
							CInfoClasseDynamique info = new CInfoClasseDynamique ( tp, strLibelle );
							lstForms.Add ( info );
						}
					}
				}
			}
			m_cmbFormulaireStandard.ProprieteAffichee = "Nom";
			m_cmbFormulaireStandard.ListDonnees = lstForms;
            m_cmbFormulaireStandard.AssureRemplissage();
			if ( m_actionEditee is CActionSur2iLinkAfficherFormulaire )
			{
                Type tp = ((CActionSur2iLinkAfficherFormulaire)m_actionEditee).TypeFormulaire;
                if (tp != null)
                {
                    object[] attribs = tp.GetCustomAttributes(typeof(DynamicFormAttribute), true);
                    if (attribs.Length > 0)
                    {
                        string strLibelle = ((DynamicFormAttribute)attribs[0]).Libelle;
                        int ndx = 0;
                        foreach (CInfoClasseDynamique info in m_cmbFormulaireStandard.ListDonnees)
                        {
                            if (info.Nom == strLibelle)
                            {
                                m_cmbFormulaireStandard.SelectedValue = info;
                                break;
                            }
                            ndx++;
                        }
                    }
                }
			}

			CListeObjetsDonnees listeFormulaires = new CListeObjetsDonnees ( CSc2iWin32DataClient.ContexteCourant, typeof(CFormulaire) );
            listeFormulaires.Filtre = new CFiltreData(
                CFormulaire.c_champCodeRole + " is null ");
                //CFormulaire.c_champTypeElementEdite + " is null");
			if ( m_objetPourSousProprietes != null && m_objetPourSousProprietes.TypeAnalyse != null)
			{
				//CRoleChampCustom role = CRoleChampCustom.GetRoleForType ( m_typeEdite );
                //if ( role != null )
                //{
					//listeFormulaires.Filtre.Filtre += " or "+CFormulaire.c_champCodeRole+"=@1";
					//listeFormulaires.Filtre.Parametres.Add ( role.CodeRole );
                    listeFormulaires.Filtre.Filtre += " or " + CFormulaire.c_champTypeElementEdite + "=@1";
                    listeFormulaires.Filtre.Parametres.Add(m_objetPourSousProprietes.TypeAnalyse.ToString());
                //}
			}
			m_cmbFormulaireCustom.Fill ( listeFormulaires, "Libelle", true );

			UpdateVisuel();
		}

		/// ///////////////////////////////////////////////////////
		private void SetTexteFormule ( sc2i.win32.expression.CControleEditeFormule txt )
		{
			if ( m_txtFormule != null )
				m_txtFormule.BackColor = Color.White;
			m_txtFormule = txt;
			m_txtFormule.BackColor = Color.LightGreen;
		}

		/// ///////////////////////////////////////////////////////
		private void UpdateVisuel()
		{
			if ( m_chkAction.Checked )
			{
				if ( !(m_actionEditee is CActionSur2iLinkExecuterProcess) )
				{
					if ( m_actionOriginale is CActionSur2iLinkExecuterProcess )
						m_actionEditee = m_actionOriginale;
					else
						m_actionEditee = new CActionSur2iLinkExecuterProcess();
				}
                CActionSur2iLinkExecuterProcess actionProcess = m_actionEditee as CActionSur2iLinkExecuterProcess;
                CFiltreData filtre = null;
                if (m_objetPourSousProprietes == null || m_objetPourSousProprietes.TypeAnalyse == null)
                    filtre = new CFiltreData(CProcessInDb.c_champTypeCible + "=@1", "");
                else
                {
                    filtre = new CFiltreData(CProcessInDb.c_champTypeCible + "=@1 or " +
                        CProcessInDb.c_champTypeCible + "=@2 or "+
                    CProcessInDb.c_champTypeCible+"=@3", 
                    "", 
                    m_objetPourSousProprietes.TypeAnalyse.ToString(),
                    typeof(CObjetDonneeAIdNumerique).ToString());
                }
				
				m_selectionneurProcess.InitAvecFiltreDeBase<CProcessInDb>( "Libelle", filtre,true);
				CProcessInDb process = new CProcessInDb ( CSc2iWin32DataClient.ContexteCourant );
                CProcess processPourParametres = null;
				if ( process.ReadIfExists ( ((CActionSur2iLinkExecuterProcess)m_actionEditee).IdProcessInDb ))
                {
				    m_selectionneurProcess.ElementSelectionne = process;
                    processPourParametres = process.Process;
                }

				
				if ( m_objetPourSousProprietes != null && m_objetPourSousProprietes.TypeAnalyse != null)
				{
					m_panelEvenementManuel.Visible = true;
                    CFiltreData filtreDeBase = new CFiltreData(
                        CEvenement.c_champTypeEvenement + "=@1 and " +
                        CEvenement.c_champTypeCible + "=@2",
                        (int)TypeEvenement.Manuel,
                        m_objetPourSousProprietes.TypeAnalyse.ToString());

					m_selectionneurEvenementManuel.InitAvecFiltreDeBase<CEvenement> ( 
						"Libelle",
                        filtreDeBase, true);
						
					CEvenement evt = new CEvenement ( CSc2iWin32DataClient.ContexteCourant );
					if ( evt.ReadIfExists ( ((CActionSur2iLinkExecuterProcess)m_actionEditee).IdEvenement ))
                    {
						m_selectionneurEvenementManuel.ElementSelectionne = evt;
                        processPourParametres = null;
                    }
				}
				else
				{
					m_panelEvenementManuel.Visible = false;
					m_selectionneurEvenementManuel.ElementSelectionne = null;
				}
				m_chkHideProgress.Checked = ((CActionSur2iLinkExecuterProcess)m_actionEditee).MasquerProgressProcess;
                InitListeFormulesParametres(processPourParametres, actionProcess);
			}
			if ( m_chkListe.Checked )
			{
				if ( m_filtreEdite == null )
				{
					if ( !(m_actionEditee is CActionSur2iLinkAfficherListe) )
					{
						if ( m_actionOriginale is CActionSur2iLinkAfficherListe )
							m_actionEditee = m_actionOriginale;
						else
							m_actionEditee = new CActionSur2iLinkAfficherListe();
					}
					CActionSur2iLinkAfficherListe actionListe = ((CActionSur2iLinkAfficherListe)m_actionEditee);
					m_filtreEdite = actionListe.Filtre;
					if ( m_filtreEdite == null )
						m_filtreEdite = new CFiltreDynamique();
/*					if (m_filtreEdite.TypeElements == null && m_typeEdite != null )
						m_filtreEdite.TypeElements = m_typeEdite;*/
					m_filtreEdite = (CFiltreDynamique)m_filtreEdite.Clone();
                    if (m_objetPourSousProprietes != null)
                        CActionSur2iLinkAfficherListe.AssureVariableElementCible(m_filtreEdite, m_objetPourSousProprietes);
					m_panelEditFiltre.Init(m_filtreEdite );
					m_panelEditFiltre.MasquerFormulaire (true);
					m_wndAide.FournisseurProprietes = new CFournisseurPropDynStd(true);
					m_wndAide.ObjetInterroge = m_objetPourSousProprietes;

					m_txtContexteListe.Init(m_wndAide.FournisseurProprietes, m_wndAide.ObjetInterroge);
					m_txtTitreListe.Init(m_wndAide.FournisseurProprietes, m_wndAide.ObjetInterroge);
					if ( actionListe.FormuleContexte != null )
						m_txtContexteListe.Text = actionListe.FormuleContexte.GetString();
					else
						m_txtContexteListe.Text = "";
					if ( actionListe.FormuleTitre != null )
						m_txtTitreListe.Text = actionListe.FormuleTitre.GetString();
					else
						m_txtTitreListe.Text = "";
                    m_rbtnActionDetailEditElement.Checked = actionListe.ActionSurDetail == null;
                    m_rbtnActionDetailSpecifique.Checked = !m_rbtnActionDetailEditElement.Checked;
                    m_chkListeAvecAjouter.Checked = actionListe.ShowBoutonAjouter;
                    m_chkListeAvecDetail.Checked = actionListe.ShowBoutonDetail;
                    m_chkListeAvecRemove.Checked = actionListe.ShowBoutonSupprimer;
                    m_imgFiltreSpecifiqueOnList.Visible = actionListe.IdFiltreDynamiqueAUtiliser >= 0;
                    m_lnkOptionsFiltre.Visible = actionListe.IdFiltreDynamiqueAUtiliser >= 0;
				}
			}
            // Formulaire standard
			if ( m_chkFormulaire.Checked )
			{
				if ( !(m_actionEditee is CActionSur2iLinkAfficherFormulaire) )
				{
					if ( m_actionOriginale is CActionSur2iLinkAfficherFormulaire )
						m_actionEditee = m_actionOriginale;
					else
						m_actionEditee = new CActionSur2iLinkAfficherFormulaire();
				}
				Type tp = ((CActionSur2iLinkAfficherFormulaire)m_actionEditee).TypeFormulaire;
                // Init combo Type formulaire
				m_cmbFormulaireStandard.SelectedValue = new CInfoClasseDynamique ( tp,"");
				// Init Contexte du formulaire
                m_txtContexteFormulaire.Text = ((CActionSur2iLinkAfficherFormulaire)m_actionEditee).ContexteForm;
                // Init la liste des Paramètres du Formulaire
                UpdateListeParametresFormulaire(tp);

                m_wndAideFormuleParametre.FournisseurProprietes = new CFournisseurPropDynStd(true);
				m_wndAideFormuleParametre.ObjetInterroge = m_objetPourSousProprietes;
				m_txtFormuleEntite.Init(m_wndAideFormuleParametre.FournisseurProprietes, m_wndAideFormuleParametre.ObjetInterroge);
                
			}
            // Formulaire prsonnalisé
			if ( m_chkFormulairePersonnalisé.Checked )
			{
				if ( !(m_actionEditee is CActionSur2iLinkAfficheFormulaireCustom ))
					if ( m_actionOriginale is CActionSur2iLinkAfficheFormulaireCustom )
						m_actionEditee = m_actionOriginale;
					else
						m_actionEditee = new CActionSur2iLinkAfficheFormulaireCustom();
				CFormulaire formulaire = new CFormulaire ( CSc2iWin32DataClient.ContexteCourant );
				if ( formulaire.ReadIfExists ( ((CActionSur2iLinkAfficheFormulaireCustom)m_actionEditee).IdFormulaireInDb ))
					m_cmbFormulaireCustom.SelectedValue = formulaire;
			}
            // Afficher une Entité
			if ( m_chkAfficherEntite.Checked )
			{
				if ( !(m_actionEditee is CActionSur2iLinkAfficherEntite) )
					if ( m_actionOriginale is CActionSur2iLinkAfficherEntite )
						m_actionEditee = m_actionOriginale;
					else
						m_actionEditee = new CActionSur2iLinkAfficherEntite();
				CActionSur2iLinkAfficherEntite actionEntite = (CActionSur2iLinkAfficherEntite)m_actionEditee;
				m_txtFormuleEntite.Formule = actionEntite.FormuleElement;
				m_txtFormuleContexteEntite.Formule = actionEntite.FormuleContexte;
				m_txtFormuleTitreAfficheEntite.Formule = actionEntite.FormuleTitre;
                m_txtCodeFormulaireEdition.Text = actionEntite.CodeFormulaire;
				m_wndAideFormuleAfficherEntite.FournisseurProprietes = new CFournisseurPropDynStd(true);
				m_wndAideFormuleAfficherEntite.ObjetInterroge = m_objetPourSousProprietes;

                m_txtFormuleEntite.Init(m_wndAideFormuleAfficherEntite.FournisseurProprietes, m_wndAideFormuleAfficherEntite.ObjetInterroge);
                m_txtFormuleContexteEntite.Init(m_wndAideFormuleAfficherEntite.FournisseurProprietes, m_wndAideFormuleAfficherEntite.ObjetInterroge);
                m_txtFormuleTitreAfficheEntite.Init(m_wndAideFormuleAfficherEntite.FournisseurProprietes, m_wndAideFormuleAfficherEntite.ObjetInterroge);
			}

			
				
			m_panelListeEntites.Visible = m_chkListe.Checked;
			m_panelAction.Visible = m_chkAction.Checked;
			m_panelFormulaire.Visible = m_chkFormulaire.Checked;
			m_panelFormulaireCustom.Visible = m_chkFormulairePersonnalisé.Checked;
			m_panelAfficherEntite.Visible = m_chkAfficherEntite.Checked;
			foreach ( Control ctrl in m_panelComplet.Controls )
			{
				if ( ctrl is Panel )
				{
					if ( ctrl.Visible )
						ctrl.Dock = DockStyle.Fill;
					else
						ctrl.Dock = DockStyle.Top;
				}
			}
		}

        /////////////////////////////////////////////////////////////////////////////////
        private void InitListeFormulesParametres ( CProcess process, CActionSur2iLinkExecuterProcess action )
        {
            if (process == null)
            {
                m_panelParametresAction.Visible = false;
                return;
            }
            m_panelParametresAction.Visible = true;
            Dictionary<string, CFormuleNommee> dicFormulesCreees = new Dictionary<string, CFormuleNommee>();
            if (action != null)
            {
                foreach (CFormuleNommee formule in action.FormulesPourParametres)
                    dicFormulesCreees[formule.Libelle] = formule;
            }
            List<CFormuleNommee> lst = new List<CFormuleNommee>();
            if ( process != null )
            {
                foreach ( IVariableDynamique variable in process.ListeVariables )
                {
                    if (variable.IsChoixUtilisateur())
                    {
                        CFormuleNommee formuleAffectee = null;
                        if (dicFormulesCreees.TryGetValue(variable.Nom, out formuleAffectee))
                            lst.Add(formuleAffectee);
                        else
                            lst.Add(new CFormuleNommee(variable.Nom, null));
                    }
                }
            }
            m_panelParametresAction.Init(lst.ToArray(), m_objetPourSousProprietes, new CFournisseurGeneriqueProprietesDynamiques());

        }


    		/// ///////////////////////////////////////////////////////
		private void m_chkFormulaire_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateVisuel();
		}

		/// ///////////////////////////////////////////////////////
		private void m_btnOk_Click(object sender, System.EventArgs e)
		{
            // Action ou Evenement manuel
			if ( m_chkAction.Checked )
			{
				if ( m_selectionneurProcess.ElementSelectionne is CProcessInDb )
				{
					((CActionSur2iLinkExecuterProcess)m_actionEditee).IdProcessInDb = ((CProcessInDb) m_selectionneurProcess.ElementSelectionne).Id;

				}
				else if ( m_selectionneurEvenementManuel.ElementSelectionne is CEvenement )
				{
					((CActionSur2iLinkExecuterProcess)m_actionEditee).IdEvenement = ((CEvenement)m_selectionneurEvenementManuel.ElementSelectionne).Id;
				}
				else
				{
					CFormAlerte.Afficher("Sélectionnez l'action à executer", EFormAlerteType.Exclamation);
					return;
				}
                ((CActionSur2iLinkExecuterProcess)m_actionEditee).MasquerProgressProcess = m_chkHideProgress.Checked; 
                ((CActionSur2iLinkExecuterProcess)m_actionEditee).FormulesPourParametres = m_panelParametresAction.GetFormules();
			}
            // Affiche une Liste
			else if ( m_chkListe.Checked )
			{
				CActionSur2iLinkAfficherListe actionListe = (CActionSur2iLinkAfficherListe)m_actionEditee;
				actionListe.Filtre = m_panelEditFiltre.FiltreDynamique;
				CAnalyseurSyntaxiqueExpression analyseur = new CAnalyseurSyntaxiqueExpression (
					new CContexteAnalyse2iExpression ( new CFournisseurPropDynStd(), m_objetPourSousProprietes));
				CResultAErreur result = CResultAErreur.True;
				if ( m_txtContexteListe.Text.Trim() != "" )
				{
					result = analyseur.AnalyseChaine ( m_txtContexteListe.Text );
					if ( result )
						actionListe.FormuleContexte = (C2iExpression)result.Data;
					else
						result.EmpileErreur("Erreur dans la formule de contexte de formulaire");
				}
				else
					actionListe.FormuleContexte = null;
				if (result )
				{
					if ( m_txtTitreListe.Text.Trim() != "" )
					{
						result = analyseur.AnalyseChaine ( m_txtTitreListe.Text );
						if ( result )
							actionListe.FormuleTitre = (C2iExpression)result.Data;
						else
							result.EmpileErreur("Erreur dans la formule de titre de formulaire");
					}
				}
				else
					actionListe.FormuleTitre = null;
				if ( !result )
				{
					CFormAlerte.Afficher ( result.Erreur );
					return;
				}
                if (m_rbtnActionDetailEditElement.Checked)
                    actionListe.ActionSurDetail = null;
                actionListe.ShowBoutonSupprimer = m_chkListeAvecRemove.Checked;
                actionListe.ShowBoutonDetail = m_chkListeAvecDetail.Checked;
                actionListe.ShowBoutonAjouter = m_chkListeAvecAjouter.Checked;
			}
            // Affiche une entité
			else if ( m_chkAfficherEntite.Checked )
			{
				CResultAErreur result =  CResultAErreur.True;
				CActionSur2iLinkAfficherEntite actionEntite = (CActionSur2iLinkAfficherEntite)m_actionEditee;
				actionEntite.FormuleElement = m_txtFormuleEntite.Formule;
				if ( actionEntite.FormuleElement == null )
				{
					if ( m_txtFormuleEntite.Text.Trim() ==  "" )
					{
						result.EmpileErreur("Indiquez une entité à éditer");
					}
					else
					{
						result.Erreur += m_txtFormuleEntite.ResultAnalyse.Erreur;
						result.EmpileErreur("Erreur dans la formule d'entité à éditer");
					}
				}
				else if ( !typeof ( CObjetDonnee ).IsAssignableFrom(actionEntite.FormuleElement.TypeDonnee.TypeDotNetNatif) )
				{
					result.EmpileErreur("La formule d'entité à éditer ne retourne pas une entité");
				}
				actionEntite.FormuleTitre = m_txtFormuleTitreAfficheEntite.Formule;
				actionEntite.FormuleContexte = m_txtFormuleContexteEntite.Formule;
                actionEntite.CodeFormulaire = m_txtCodeFormulaireEdition.Text;
				if ( actionEntite.FormuleTitre == null && m_txtFormuleTitreAfficheEntite.Text.Trim() != "" )
				{
					result.Erreur += m_txtFormuleTitreAfficheEntite.ResultAnalyse.Erreur;
					result.EmpileErreur("Erreur dans la formule de titre");
				}
				if ( actionEntite.FormuleContexte == null && m_txtFormuleContexteEntite.Text.Trim() != "" )
				{
					result.Erreur += m_txtFormuleContexteEntite.ResultAnalyse.Erreur;
					result.EmpileErreur("Erreur dans la formule de contexte");
				}
				if ( !result )
				{
					CFormAlerte.Afficher ( result.Erreur );
					return;
				}

			}
            // Affiche un formulaire
			else if ( m_chkFormulaire.Checked )
			{
                CResultAErreur result = CResultAErreur.True;
				if ( !(m_cmbFormulaireStandard.SelectedValue is CInfoClasseDynamique ))
				{
					CFormAlerte.Afficher(I.T("Please select a standard Frorm|10010"), EFormAlerteType.Exclamation);
					return;
				}
                // MAJ du Type du Formulaire
				((CActionSur2iLinkAfficherFormulaire)m_actionEditee).TypeFormulaire = ((CInfoClasseDynamique)m_cmbFormulaireStandard.SelectedValue).Classe;
                // MAJ du Contexte du Formulaire
				((CActionSur2iLinkAfficherFormulaire)m_actionEditee).ContexteForm = m_txtContexteFormulaire.Text.Trim();
                // MAJ des Parametres du Formulaire
                result = OnChangeParametreEnCoursEdition();
                if (!result)
                {
                    CFormAlerte.Afficher(result.Erreur);
                    return;
                }

                Dictionary<string, C2iExpression> nouveauDico = new Dictionary<string, C2iExpression>();
                foreach (CWndParametreEnEdition param in m_listeParametresEnEdition)
                {
                    if (param.InfoParametre != null)
                        nouveauDico.Add(param.InfoParametre.Nom, param.Expression);
                }
                ((CActionSur2iLinkAfficherFormulaire)m_actionEditee).Parametres = nouveauDico;


			}
			else if ( m_chkFormulairePersonnalisé.Checked )
			{
				if ( !(m_cmbFormulaireCustom.SelectedValue is CFormulaire ))
				{
                    CFormAlerte.Afficher(I.T("Please select a standard Frorm|10010"), EFormAlerteType.Exclamation);
					return;
				}
				((CActionSur2iLinkAfficheFormulaireCustom)m_actionEditee).IdFormulaireInDb = ((CFormulaire)m_cmbFormulaireCustom.SelectedValue).Id;
			}

			DialogResult = DialogResult.OK;
			Close();
		}

		/// ///////////////////////////////////////////////////////
		public CActionSur2iLink ActionOriginale
		{
			get
			{
				return m_actionOriginale;
			}
			set
			{
				m_actionOriginale = value;
			}
		}

		/// ///////////////////////////////////////////////////////
		public CActionSur2iLink ActionEditee
		{
			get
			{
				return m_actionEditee;
			}
			set
			{
				m_actionEditee = value;
			}
		}

		/// ///////////////////////////////////////////
		public void EditeAction ( ref CActionSur2iLink action )
		{
			if ( action == null )
				action = new CActionSur2iLinkAfficherFormulaire();
			ActionOriginale = (CActionSur2iLink)action;
			ActionEditee = ActionOriginale;
			if ( ShowDialog() == DialogResult.OK )
				action =  ActionEditee;
		}

		private void m_wndAide_OnSendCommande(string strCommande, int nPosCurseur)
		{
			if ( m_txtFormule != null )
				m_wndAide.InsereInTextBox ( m_txtFormule, nPosCurseur, strCommande );
		}

		private void m_txtFormule_Enter(object sender, System.EventArgs e)
		{
			this.SetTexteFormule ( (sc2i.win32.expression.CControleEditeFormule)sender );
		}

		private void m_panelAction_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}

		private void m_selectionneurProcess_OnChangeSelection(object sender, System.EventArgs e)
		{
            if (m_selectionneurProcess.ElementSelectionne != null)
            {
                m_selectionneurEvenementManuel.ElementSelectionne = null;
                CProcessInDb process = m_selectionneurProcess.ElementSelectionne as CProcessInDb;
                if (process != null)
                    InitListeFormulesParametres(process.Process, m_actionEditee as CActionSur2iLinkExecuterProcess);
                else
                    InitListeFormulesParametres(null, null);
            }
            
		}

		private void m_selectionneurEvenementManuel_OnChangeSelection(object sender, System.EventArgs e)
		{
            if (m_selectionneurEvenementManuel.ElementSelectionne != null)
            {
                m_selectionneurProcess.ElementSelectionne = null;
                InitListeFormulesParametres(null, m_actionEditee as CActionSur2iLinkExecuterProcess);
            }
		}

        private void m_chkAfficherEntite_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisuel();
        }

        private void m_wndAideFormuleAfficherEntite_OnSendCommande(string strCommande, int nPosCurseur)
        {
            m_wndAideFormuleAfficherEntite.InsereInTextBox(m_txtFormuleEntite, nPosCurseur, strCommande);
        }

        //--------------------------------------------------------------------------------
        CWndParametreEnEdition m_paramEnCoursEdition = null;
        private void m_wndListeParametres_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Affiche les infos du paramètre sélectionné
            if (m_bListeParamsRemplie)
            {
                CResultAErreur result = OnChangeParametreEnCoursEdition();
                if (!result)
                    CFormAlerte.Afficher(result.Erreur);
            }
        }

        //--------------------------------------------------------------------------------
        private CResultAErreur OnChangeParametreEnCoursEdition()
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_paramEnCoursEdition != null)
            {
                if (m_txtFormuleParametre.Text.Trim() != "")
                {
                    result = GetFormule(m_txtFormuleParametre);
                    if (!result)
                    {
                        return result;
                    }
                    m_paramEnCoursEdition.Expression = (C2iExpression)result.Data;
                }
                else
                    m_paramEnCoursEdition.Expression = null;

            }
            if (m_wndListeParametres.SelectedItems.Count != 1)
            {
                m_paramEnCoursEdition = null;
                m_splitContainerInfosParam.Visible = false;
                return result;
            }

            m_splitContainerInfosParam.Visible = true;
            // Initialise l'édition du paramètre sélectionné
            m_paramEnCoursEdition = (CWndParametreEnEdition)m_wndListeParametres.SelectedItems[0].Tag;
            m_lblNomParametre.Text = m_paramEnCoursEdition.InfoParametre != null ? m_paramEnCoursEdition.InfoParametre.Nom : "";
            m_lblDescriptionParametre.Text = m_paramEnCoursEdition.InfoParametre != null ? m_paramEnCoursEdition.InfoParametre.Description : "";
            C2iExpression expression = (C2iExpression)m_paramEnCoursEdition.Expression;
            m_txtFormuleParametre.Text = expression == null ? "" : expression.GetString();

            return result;
        }

        //--------------------------------------------------------------------------------
        private CResultAErreur GetFormule(CControleEditeFormule textBox)
        {
            CResultAErreur result = CResultAErreur.True;
            CContexteAnalyse2iExpression contexte = new CContexteAnalyse2iExpression(
                m_wndAideFormuleParametre.FournisseurProprietes ,
                m_objetPourSousProprietes);
            CAnalyseurSyntaxiqueExpression analyseur = new CAnalyseurSyntaxiqueExpression(contexte);
            result = analyseur.AnalyseChaine(textBox.Text);
            return result;
        }

        //--------------------------------------------------------------------------------
        private void m_txtFormuleParametre_Enter(object sender, EventArgs e)
        {
            SetTexteFormule((CControleEditeFormule)sender);
        }

        //--------------------------------------------------------------------------------
        private void m_wndAideFormuleParametre_OnSendCommande(string strCommande, int nPosCurseur)
        {
            if (m_txtFormule != null)
                m_wndAideFormuleParametre.InsereInTextBox(m_txtFormule, nPosCurseur, strCommande);
        }

        //--------------------------------------------------------------------------------
        private void m_cmbFormulaireStandard_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CInfoClasseDynamique infoClasse = m_cmbFormulaireStandard.SelectedValue as CInfoClasseDynamique;
            if (infoClasse != null)
            {
                Type tpFormulaire = infoClasse.Classe;
                UpdateListeParametresFormulaire(tpFormulaire);
            }
        }

        //-----------------------------------------------------------------
        // Met à jour la liste des paramètres disponibles
        private List<CWndParametreEnEdition> m_listeParametresEnEdition = new List<CWndParametreEnEdition>();
        private bool m_bListeParamsRemplie = false;
        private void UpdateListeParametresFormulaire(Type typeForm)
        {
            m_bListeParamsRemplie = false;
            
            m_panelParametresFormulaire.SuspendDrawing();
            m_panelParametresFormulaire.Visible = false;
            if (typeForm != null)
            {
                object[] formAttribs = typeForm.GetCustomAttributes(typeof(DynamicFormAttribute), true);
                if (formAttribs.Length > 0)
                {
                    string strNomMethodeGetInfosParametres = ((DynamicFormAttribute)formAttribs[0]).NomMethodeGetInfosParametres;
                    if (strNomMethodeGetInfosParametres != "")
                    {
                        MethodInfo infoMethode = typeForm.GetMethod(strNomMethodeGetInfosParametres);
                        if (infoMethode != null && infoMethode.IsStatic)
                        {
                            // Récupère la liste des Informations sur les pramètres nécessaire du formulaire
                            CInfoParametreDynamicForm[] infos = (CInfoParametreDynamicForm[]) infoMethode.Invoke(null, null);
                            if (infos.Length > 0)
                            {
                                C2iExpression exp = null;
                                Dictionary<string, C2iExpression> dicoParamsAction = ((CActionSur2iLinkAfficherFormulaire)m_actionEditee).Parametres;
                                // Remplie la liste des paramètres en édition avec les formules à partir de l'action
                                m_listeParametresEnEdition.Clear();
                                foreach (CInfoParametreDynamicForm info in infos)
                                {
                                    if (dicoParamsAction.TryGetValue(info.Nom, out exp))
                                    {
                                        m_listeParametresEnEdition.Add(new CWndParametreEnEdition(info, exp));
                                    }
                                    else
                                        m_listeParametresEnEdition.Add(new CWndParametreEnEdition(info, null));
                                }

                                m_panelParametresFormulaire.Visible = true;
                                m_wndListeParametres.Remplir(m_listeParametresEnEdition);
                                m_bListeParamsRemplie = true;
                            }
                        }
                    }

                }

            }

            m_panelParametresFormulaire.ResumeDrawing();
        }

        public static CActionSur2iLink EditeAction(CActionSur2iLink action, CObjetPourSousProprietes objetPourSousProp)
        {
            CFormEditActionSurLinkOld form = new CFormEditActionSurLinkOld();
            form.ActionEditee = action;
            form.m_objetPourSousProprietes = objetPourSousProp;
            if (form.ShowDialog() == DialogResult.OK)
                action = form.ActionEditee;
            form.Dispose();
            return action;
        }





        private void m_lnkAffectations_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CActionSur2iLinkAfficherListe actionLst = m_actionEditee as CActionSur2iLinkAfficherListe;
            if (actionLst != null && m_panelEditFiltre.FiltreDynamique != null)
            {
                List<CAffectationsProprietes> lstAffectations = new List<CAffectationsProprietes>();
                lstAffectations.AddRange(actionLst.Affectations);
                lstAffectations = CFormEditProprieteAffectationsProprietes.EditeLesAffectations(lstAffectations,
                    m_objetPourSousProprietes != null?m_objetPourSousProprietes.TypeAnalyse:null,
                    m_panelEditFiltre.FiltreDynamique.TypeElements,
                    new CFournisseurPropDynStd());
                actionLst.Affectations = lstAffectations;
            }
        }

        private void m_rbtnActionDetailEditElement_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisuelListeDetailAction();
        }

        private void m_rbtnActionDetailSpecifique_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisuelListeDetailAction();
        }

        private void UpdateVisuelListeDetailAction()
        {
            m_lnkEditActionDetailSpecifique.Visible = m_rbtnActionDetailSpecifique.Checked;
        }

        void m_lnkEditActionDetailSpecifique_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CActionSur2iLinkAfficherListe actionListe = ActionEditee as CActionSur2iLinkAfficherListe;
            if (actionListe != null && actionListe.Filtre != null && actionListe.Filtre.TypeElements != null)
            {
                CActionSur2iLink actionSpec = actionListe.ActionSurDetail;
                actionSpec = CFormEditActionSurLinkOld.EditeAction(actionSpec, actionListe.Filtre.TypeElements);
                if (actionSpec != null)
                    actionListe.ActionSurDetail = actionSpec;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void m_lnkFiltreSpecifique_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CActionSur2iLinkAfficherListe actionListe = ActionEditee as CActionSur2iLinkAfficherListe;
            if (actionListe != null && actionListe.Filtre != null && actionListe.Filtre.TypeElements != null)
            {
                ContextMenuStrip menuFiltre = new ContextMenuStrip();
                CListeObjetDonneeGenerique<CFiltreDynamiqueInDb> lstFiltres = new CListeObjetDonneeGenerique<CFiltreDynamiqueInDb>(CContexteDonneeSysteme.GetInstance());
                lstFiltres.Filtre = new CFiltreData(CFiltreDynamiqueInDb.c_champTypeElements + "=@1",
                    actionListe.Filtre.TypeElements.ToString());
                ToolStripMenuItem itemFiltreSpecifique = new ToolStripMenuItem(I.T("No specific filter|20827"));
                itemFiltreSpecifique.Tag = -1;
                itemFiltreSpecifique.Click += new EventHandler(itemFiltreSpecifique_Click);
                menuFiltre.Items.Add(itemFiltreSpecifique);
                itemFiltreSpecifique.Checked = actionListe.IdFiltreDynamiqueAUtiliser ==-1;
                foreach (CFiltreDynamiqueInDb filtre in lstFiltres)
                {
                    itemFiltreSpecifique = new ToolStripMenuItem(filtre.Libelle);
                    itemFiltreSpecifique.Tag = filtre.Id;
                    itemFiltreSpecifique.Checked = actionListe.IdFiltreDynamiqueAUtiliser == filtre.Id;
                    itemFiltreSpecifique.Click +=new EventHandler(itemFiltreSpecifique_Click);
                    menuFiltre.Items.Add(itemFiltreSpecifique);
                }
                menuFiltre.Show(m_lnkFiltreSpecifique, new Point(0, m_lnkFiltreSpecifique.Height));
            }
        }

        //------------------------------------------------------------------
        void itemFiltreSpecifique_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null && item.Tag is int)
            {
                CActionSur2iLinkAfficherListe actionListe = ActionEditee as CActionSur2iLinkAfficherListe;
                if (actionListe != null)
                {
                    actionListe.IdFiltreDynamiqueAUtiliser = (int)item.Tag;
                    m_imgFiltreSpecifiqueOnList.Visible = ((int)item.Tag) >= 0;
                    m_lnkOptionsFiltre.Visible = m_imgFiltreSpecifiqueOnList.Visible;
                }
            }
        }

        void m_lnkOptionsFiltre_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CActionSur2iLinkAfficherListe actionListe = ActionEditee as CActionSur2iLinkAfficherListe;
            if (actionListe != null)
            {
                CFiltreDynamiqueInDb filtre = new CFiltreDynamiqueInDb(CContexteDonneeSysteme.GetInstance());
                if (filtre.ReadIfExists(actionListe.IdFiltreDynamiqueAUtiliser))
                {
                    CFiltreDynamique filtreDyn = filtre.Filtre;
                    if (filtreDyn != null)
                    {
                        List<CFormuleNommee> lst = new List<CFormuleNommee>();
                        foreach (IVariableDynamique variable in filtreDyn.ListeVariables)
                        {
                            CFormuleNommee formule = new CFormuleNommee(variable.Nom, null);
                            formule.Id = variable.Id.ToString();
                            foreach (CFormuleNommee formuleEx in actionListe.ValeursVariablesFiltre)
                            {
                                if (formuleEx.Id == variable.Id.ToString())
                                    formule.Formule = formuleEx.Formule;
                            }
                            lst.Add(formule);
                        }
                        CFormuleNommee[] formules = lst.ToArray();
                        if (CFormEditeListeFormulesNommees.EditeFormules(ref formules, m_objetPourSousProprietes))
                        {
                            lst = new List<CFormuleNommee>();
                            foreach (CFormuleNommee formule in formules)
                            {
                                if (formule.Formule != null)
                                    lst.Add(formule);
                            }
                            actionListe.ValeursVariablesFiltre = lst.ToArray();
                        }
                    }
                }
            }
        }


        
	}


    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// 
    /// </summary>
	[AutoExec("Autoexec")]
	public class CEditeurActionSur2iLink : sc2i.formulaire.IEditeurActionSur2iLink
	{
        private CObjetPourSousProprietes m_objetPourSousProprietes = null;

		//---------------------------------------
		public CEditeurActionSur2iLink()
		{
		}

		//---------------------------------------
		public static void Autoexec()
		{
			CActionSur2iLinkEditor.SetTypeEditeur(typeof(CEditeurActionSur2iLink));
		}

		//---------------------------------------
		public CEditeurActionSur2iLink(CObjetPourSousProprietes objetEdite)
		{
            m_objetPourSousProprietes = objetEdite;
		}

		//---------------------------------------
		public Type TypeEdite
		{
			get
			{
				return m_objetPourSousProprietes.TypeAnalyse;
			}
		}

        //---------------------------------------
        public CObjetPourSousProprietes ObjetEdite
        {
            get
            {
                return m_objetPourSousProprietes;
            }
            set
            {
                m_objetPourSousProprietes = value;
            }
        }

		//---------------------------------------
		public void EditeAction(ref CActionSur2iLink action)
		{
            action = CFormEditActionSurLink.EditeAction(action, m_objetPourSousProprietes);
			
		}
	}


	
}
