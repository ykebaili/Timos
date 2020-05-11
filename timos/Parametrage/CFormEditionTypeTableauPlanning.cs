using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using sc2i.workflow;
using sc2i.data.dynamic;
using sc2i.data;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.common;
using sc2i.win32.data;
using sc2i.win32.common;

using timos.win32.composants;
using timos.data;
using timos.securite;
using timos.acteurs;
using timos.tables;
using sc2i.expression;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CTypeTableauPlanning))]
	public class CFormEditionTypeTableauPlanning : CFormEditionStdTimos, IFormNavigable
	{

		private IElementAVariablesDynamiques m_elementPourFormules = CTypeTableauPlanning_TrancheHoraire.ElementPourEvaluerLaFormuleConditionnelle;

        // Variables membres privées
		private System.Windows.Forms.Label label2;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
        private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre2;
        private sc2i.win32.common.C2iTabControl m_tabControl;
        private ListViewAutoFilledColumn m_colJoursSemaine;
        private CToolTipTraductible m_toolTipTraductible;
        private Crownwood.Magic.Controls.TabPage m_tabPageParametres;
        private Label label3;
        private SplitContainer splitContainer2;
        private Label label5;
        private C2iComboBox m_cmbTypeLigne;
        private C2iComboBox m_cmbTypeData;
        private sc2i.win32.data.dynamic.CPanelEditFiltreDynamique m_editFiltreDynamiqueLigne;
        private sc2i.win32.data.dynamic.CPanelEditFiltreDynamique m_editFiltreDynamiqueData;
        private C2iTabControl c2iTabControl1;
        private C2iTabControl m_tab;
        private Crownwood.Magic.Controls.TabPage m_tabPageTranchesHoraires;
        private Label label4;
        private CWndLinkStd m_lnkSupprimerTranche;
        private CWndLinkStd m_lnkAjouterTranche;
        private ListViewAutoFilled m_lstTranchesHoraires;
        private CGestionnaireEditionSousObjetDonnee m_gestionnaireEditionTranches;
        private ListViewAutoFilledColumn listViewAutoFilledColumn1;
        private ListViewAutoFilledColumn listViewAutoFilledColumn2;
        private C2iPanel m_panelEditionTrancheHoraire;
        private sc2i.win32.expression.CTextBoxZoomFormule m_wndFormule;
        private Label label8;
        private Label label6;
        private Label label7;
        private C2iDateTimePicker m_timePickerHeureFin;
        private C2iDateTimePicker m_timePickerHeureDebut;
        private C2iTextBox m_txtLibelleTranche;
        private Label label9;
        private ListViewAutoFilledColumn listViewAutoFilledColumn3;
        private C2iTextBox m_txtLabelPremiereColonne;
        private Label label10;
        private Label label12;
        private CComboBoxListeObjetsDonnees m_cmbxSelectTypeOccupationHpourTranche;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionTypeTableauPlanning()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionTypeTableauPlanning(CTypeTableauPlanning tableau)
            : base(tableau)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
        public CFormEditionTypeTableauPlanning(CTypeTableauPlanning tableau, CListeObjetsDonnees liste)
            : base(tableau, liste)
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
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre2 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_tabPageTranchesHoraires = new Crownwood.Magic.Controls.TabPage();
            this.m_lnkSupprimerTranche = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkAjouterTranche = new sc2i.win32.common.CWndLinkStd();
            this.m_lstTranchesHoraires = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn3 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn2 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_panelEditionTrancheHoraire = new sc2i.win32.common.C2iPanel(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.m_wndFormule = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_txtLibelleTranche = new sc2i.win32.common.C2iTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.m_timePickerHeureFin = new sc2i.win32.common.C2iDateTimePicker();
            this.m_timePickerHeureDebut = new sc2i.win32.common.C2iDateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_tabPageParametres = new Crownwood.Magic.Controls.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.m_editFiltreDynamiqueLigne = new sc2i.win32.data.dynamic.CPanelEditFiltreDynamique();
            this.m_cmbTypeLigne = new sc2i.win32.common.C2iComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_editFiltreDynamiqueData = new sc2i.win32.data.dynamic.CPanelEditFiltreDynamique();
            this.c2iTabControl1 = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_tab = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_cmbTypeData = new sc2i.win32.common.C2iComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtLabelPremiereColonne = new sc2i.win32.common.C2iTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.m_colJoursSemaine = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_toolTipTraductible = new sc2i.win32.common.CToolTipTraductible(this.components);
            this.m_gestionnaireEditionTranches = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.m_cmbxSelectTypeOccupationHpourTranche = new sc2i.win32.data.CComboBoxListeObjetsDonnees();
            this.c2iPanelOmbre2.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.m_tabPageTranchesHoraires.SuspendLayout();
            this.m_panelEditionTrancheHoraire.SuspendLayout();
            this.m_tabPageParametres.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.m_editFiltreDynamiqueData.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(830, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // label2
            // 
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(8, 11);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4004;
            this.label2.Text = "Label|50";
            // 
            // m_txtLibelle
            // 
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_txtLibelle.Location = new System.Drawing.Point(93, 8);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(240, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 1;
            this.m_txtLibelle.Text = "[Label]|30324";
            // 
            // c2iPanelOmbre2
            // 
            this.c2iPanelOmbre2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre2.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre2.Controls.Add(this.label2);
            this.c2iPanelOmbre2.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre2, "");
            this.c2iPanelOmbre2.Location = new System.Drawing.Point(8, 31);
            this.c2iPanelOmbre2.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.c2iPanelOmbre2.Name = "c2iPanelOmbre2";
            this.c2iPanelOmbre2.Size = new System.Drawing.Size(537, 68);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre2.TabIndex = 0;
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
            this.m_tabControl.Location = new System.Drawing.Point(8, 105);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 1;
            this.m_tabControl.SelectedTab = this.m_tabPageTranchesHoraires;
            this.m_tabControl.Size = new System.Drawing.Size(822, 436);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabControl.TabIndex = 4004;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_tabPageParametres,
            this.m_tabPageTranchesHoraires});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_tabPageTranchesHoraires
            // 
            this.m_tabPageTranchesHoraires.Controls.Add(this.m_lnkSupprimerTranche);
            this.m_tabPageTranchesHoraires.Controls.Add(this.m_lnkAjouterTranche);
            this.m_tabPageTranchesHoraires.Controls.Add(this.m_lstTranchesHoraires);
            this.m_tabPageTranchesHoraires.Controls.Add(this.m_panelEditionTrancheHoraire);
            this.m_tabPageTranchesHoraires.Controls.Add(this.label4);
            this.m_extLinkField.SetLinkField(this.m_tabPageTranchesHoraires, "");
            this.m_tabPageTranchesHoraires.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabPageTranchesHoraires, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_tabPageTranchesHoraires.Name = "m_tabPageTranchesHoraires";
            this.m_tabPageTranchesHoraires.Size = new System.Drawing.Size(806, 395);
            this.m_extStyle.SetStyleBackColor(this.m_tabPageTranchesHoraires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabPageTranchesHoraires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabPageTranchesHoraires.TabIndex = 12;
            this.m_tabPageTranchesHoraires.Title = "Time slots|1175";
            // 
            // m_lnkSupprimerTranche
            // 
            this.m_lnkSupprimerTranche.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkSupprimerTranche.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkSupprimerTranche.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkSupprimerTranche, "");
            this.m_lnkSupprimerTranche.Location = new System.Drawing.Point(11, 356);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkSupprimerTranche, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkSupprimerTranche.Name = "m_lnkSupprimerTranche";
            this.m_lnkSupprimerTranche.Size = new System.Drawing.Size(104, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSupprimerTranche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSupprimerTranche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSupprimerTranche.TabIndex = 4006;
            this.m_lnkSupprimerTranche.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkSupprimerTranche.LinkClicked += new System.EventHandler(this.m_lnkSupprimerTranche_LinkClicked);
            // 
            // m_lnkAjouterTranche
            // 
            this.m_lnkAjouterTranche.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAjouterTranche.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkAjouterTranche, "");
            this.m_lnkAjouterTranche.Location = new System.Drawing.Point(11, 28);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAjouterTranche, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkAjouterTranche.Name = "m_lnkAjouterTranche";
            this.m_lnkAjouterTranche.Size = new System.Drawing.Size(104, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAjouterTranche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAjouterTranche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAjouterTranche.TabIndex = 4006;
            this.m_lnkAjouterTranche.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAjouterTranche.LinkClicked += new System.EventHandler(this.m_lnkAjouterTranche_LinkClicked);
            // 
            // m_lstTranchesHoraires
            // 
            this.m_lstTranchesHoraires.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lstTranchesHoraires.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn3,
            this.listViewAutoFilledColumn1,
            this.listViewAutoFilledColumn2});
            this.m_lstTranchesHoraires.EnableCustomisation = true;
            this.m_lstTranchesHoraires.FullRowSelect = true;
            this.m_lstTranchesHoraires.HideSelection = false;
            this.m_extLinkField.SetLinkField(this.m_lstTranchesHoraires, "");
            this.m_lstTranchesHoraires.Location = new System.Drawing.Point(11, 50);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lstTranchesHoraires, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lstTranchesHoraires.MultiSelect = false;
            this.m_lstTranchesHoraires.Name = "m_lstTranchesHoraires";
            this.m_lstTranchesHoraires.Size = new System.Drawing.Size(351, 299);
            this.m_extStyle.SetStyleBackColor(this.m_lstTranchesHoraires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lstTranchesHoraires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lstTranchesHoraires.TabIndex = 4005;
            this.m_lstTranchesHoraires.UseCompatibleStateImageBehavior = false;
            this.m_lstTranchesHoraires.View = System.Windows.Forms.View.Details;
            // 
            // listViewAutoFilledColumn3
            // 
            this.listViewAutoFilledColumn3.Field = "Libelle";
            this.listViewAutoFilledColumn3.PrecisionWidth = 0;
            this.listViewAutoFilledColumn3.ProportionnalSize = false;
            this.listViewAutoFilledColumn3.Text = "Label|50";
            this.listViewAutoFilledColumn3.Visible = true;
            this.listViewAutoFilledColumn3.Width = 114;
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "TrancheHoraire.HeureDebutString";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Start time|401";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 120;
            // 
            // listViewAutoFilledColumn2
            // 
            this.listViewAutoFilledColumn2.Field = "TrancheHoraire.HeureFinString";
            this.listViewAutoFilledColumn2.PrecisionWidth = 0;
            this.listViewAutoFilledColumn2.ProportionnalSize = false;
            this.listViewAutoFilledColumn2.Text = "End time|402";
            this.listViewAutoFilledColumn2.Visible = true;
            this.listViewAutoFilledColumn2.Width = 120;
            // 
            // m_panelEditionTrancheHoraire
            // 
            this.m_panelEditionTrancheHoraire.Controls.Add(this.m_cmbxSelectTypeOccupationHpourTranche);
            this.m_panelEditionTrancheHoraire.Controls.Add(this.label12);
            this.m_panelEditionTrancheHoraire.Controls.Add(this.m_wndFormule);
            this.m_panelEditionTrancheHoraire.Controls.Add(this.label8);
            this.m_panelEditionTrancheHoraire.Controls.Add(this.label6);
            this.m_panelEditionTrancheHoraire.Controls.Add(this.m_txtLibelleTranche);
            this.m_panelEditionTrancheHoraire.Controls.Add(this.label7);
            this.m_panelEditionTrancheHoraire.Controls.Add(this.m_timePickerHeureFin);
            this.m_panelEditionTrancheHoraire.Controls.Add(this.m_timePickerHeureDebut);
            this.m_panelEditionTrancheHoraire.Controls.Add(this.label9);
            this.m_extLinkField.SetLinkField(this.m_panelEditionTrancheHoraire, "");
            this.m_panelEditionTrancheHoraire.Location = new System.Drawing.Point(368, 50);
            this.m_panelEditionTrancheHoraire.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEditionTrancheHoraire, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelEditionTrancheHoraire.Name = "m_panelEditionTrancheHoraire";
            this.m_panelEditionTrancheHoraire.Size = new System.Drawing.Size(402, 322);
            this.m_extStyle.SetStyleBackColor(this.m_panelEditionTrancheHoraire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEditionTrancheHoraire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEditionTrancheHoraire.TabIndex = 4004;
            // 
            // label12
            // 
            this.m_extLinkField.SetLinkField(this.label12, "");
            this.label12.Location = new System.Drawing.Point(12, 51);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label12, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(125, 18);
            this.m_extStyle.SetStyleBackColor(this.label12, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label12, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label12.TabIndex = 4005;
            this.label12.Text = "Occupation type|409";
            // 
            // m_wndFormule
            // 
            this.m_wndFormule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_wndFormule.Formule = null;
            this.m_extLinkField.SetLinkField(this.m_wndFormule, "");
            this.m_wndFormule.Location = new System.Drawing.Point(12, 145);
            this.m_wndFormule.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndFormule, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_wndFormule.Name = "m_wndFormule";
            this.m_wndFormule.Size = new System.Drawing.Size(378, 23);
            this.m_extStyle.SetStyleBackColor(this.m_wndFormule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndFormule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndFormule.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label8, "");
            this.label8.Location = new System.Drawing.Point(12, 129);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label8, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 13);
            this.m_extStyle.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 15;
            this.label8.Text = "Condition formula|1176";
            // 
            // label6
            // 
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.label6.Location = new System.Drawing.Point(12, 104);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 15;
            this.label6.Text = "End Time|402";
            // 
            // m_txtLibelleTranche
            // 
            this.m_extLinkField.SetLinkField(this.m_txtLibelleTranche, "");
            this.m_txtLibelleTranche.Location = new System.Drawing.Point(139, 20);
            this.m_txtLibelleTranche.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelleTranche, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtLibelleTranche.Name = "m_txtLibelleTranche";
            this.m_txtLibelleTranche.Size = new System.Drawing.Size(214, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelleTranche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelleTranche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelleTranche.TabIndex = 1;
            this.m_txtLibelleTranche.Text = "[Label]|30324";
            // 
            // label7
            // 
            this.m_extLinkField.SetLinkField(this.label7, "");
            this.label7.Location = new System.Drawing.Point(12, 79);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 16;
            this.label7.Text = "Start Time|401";
            // 
            // m_timePickerHeureFin
            // 
            this.m_timePickerHeureFin.CustomFormat = "HH:mm";
            this.m_timePickerHeureFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_timePickerHeureFin.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.m_extLinkField.SetLinkField(this.m_timePickerHeureFin, "");
            this.m_timePickerHeureFin.Location = new System.Drawing.Point(139, 100);
            this.m_timePickerHeureFin.LockEdition = false;
            this.m_timePickerHeureFin.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_timePickerHeureFin, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_timePickerHeureFin.Name = "m_timePickerHeureFin";
            this.m_timePickerHeureFin.ShowUpDown = true;
            this.m_timePickerHeureFin.Size = new System.Drawing.Size(75, 21);
            this.m_extStyle.SetStyleBackColor(this.m_timePickerHeureFin, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_timePickerHeureFin, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_timePickerHeureFin.TabIndex = 14;
            this.m_timePickerHeureFin.Value = new System.DateTime(2003, 4, 2, 9, 17, 49, 526);
            // 
            // m_timePickerHeureDebut
            // 
            this.m_timePickerHeureDebut.CustomFormat = "HH:mm";
            this.m_timePickerHeureDebut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_extLinkField.SetLinkField(this.m_timePickerHeureDebut, "");
            this.m_timePickerHeureDebut.Location = new System.Drawing.Point(139, 75);
            this.m_timePickerHeureDebut.LockEdition = false;
            this.m_timePickerHeureDebut.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_timePickerHeureDebut, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_timePickerHeureDebut.Name = "m_timePickerHeureDebut";
            this.m_timePickerHeureDebut.ShowUpDown = true;
            this.m_timePickerHeureDebut.Size = new System.Drawing.Size(75, 21);
            this.m_extStyle.SetStyleBackColor(this.m_timePickerHeureDebut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_timePickerHeureDebut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_timePickerHeureDebut.TabIndex = 13;
            this.m_timePickerHeureDebut.Value = new System.DateTime(2003, 4, 2, 9, 17, 49, 526);
            // 
            // label9
            // 
            this.m_extLinkField.SetLinkField(this.label9, "");
            this.label9.Location = new System.Drawing.Point(12, 23);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label9, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 15);
            this.m_extStyle.SetStyleBackColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label9.TabIndex = 4004;
            this.label9.Text = "Label|50";
            // 
            // label4
            // 
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.label4.Location = new System.Drawing.Point(8, 6);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 18);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 4003;
            this.label4.Text = "Daily time slots management|403";
            // 
            // m_tabPageParametres
            // 
            this.m_tabPageParametres.Controls.Add(this.splitContainer2);
            this.m_tabPageParametres.Controls.Add(this.m_txtLabelPremiereColonne);
            this.m_tabPageParametres.Controls.Add(this.label10);
            this.m_extLinkField.SetLinkField(this.m_tabPageParametres, "");
            this.m_tabPageParametres.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabPageParametres, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_tabPageParametres.Name = "m_tabPageParametres";
            this.m_tabPageParametres.Selected = false;
            this.m_tabPageParametres.Size = new System.Drawing.Size(806, 395);
            this.m_extStyle.SetStyleBackColor(this.m_tabPageParametres, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabPageParametres, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabPageParametres.TabIndex = 11;
            this.m_tabPageParametres.Title = "Setup|1172";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_extLinkField.SetLinkField(this.splitContainer2, "");
            this.splitContainer2.Location = new System.Drawing.Point(0, 28);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.m_editFiltreDynamiqueLigne);
            this.splitContainer2.Panel1.Controls.Add(this.m_cmbTypeLigne);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.m_extLinkField.SetLinkField(this.splitContainer2.Panel1, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer2.Panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.splitContainer2.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer2.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.m_editFiltreDynamiqueData);
            this.splitContainer2.Panel2.Controls.Add(this.m_cmbTypeData);
            this.splitContainer2.Panel2.Controls.Add(this.label5);
            this.m_extLinkField.SetLinkField(this.splitContainer2.Panel2, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer2.Panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.splitContainer2.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer2.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitContainer2.Size = new System.Drawing.Size(806, 367);
            this.splitContainer2.SplitterDistance = 178;
            this.m_extStyle.SetStyleBackColor(this.splitContainer2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitContainer2.TabIndex = 4003;
            // 
            // m_editFiltreDynamiqueLigne
            // 
            this.m_editFiltreDynamiqueLigne.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_editFiltreDynamiqueLigne.BackColor = System.Drawing.Color.White;
            this.m_editFiltreDynamiqueLigne.DefinitionRacineDeChampsFiltres = null;
            this.m_editFiltreDynamiqueLigne.FiltreDynamique = null;
            this.m_extLinkField.SetLinkField(this.m_editFiltreDynamiqueLigne, "");
            this.m_editFiltreDynamiqueLigne.Location = new System.Drawing.Point(-2, 27);
            this.m_editFiltreDynamiqueLigne.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_editFiltreDynamiqueLigne, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_editFiltreDynamiqueLigne.ModeSansType = true;
            this.m_editFiltreDynamiqueLigne.Name = "m_editFiltreDynamiqueLigne";
            this.m_editFiltreDynamiqueLigne.Size = new System.Drawing.Size(801, 144);
            this.m_extStyle.SetStyleBackColor(this.m_editFiltreDynamiqueLigne, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_editFiltreDynamiqueLigne, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_editFiltreDynamiqueLigne.TabIndex = 4004;
            // 
            // m_cmbTypeLigne
            // 
            this.m_cmbTypeLigne.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbTypeLigne.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTypeLigne.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbTypeLigne, "");
            this.m_cmbTypeLigne.Location = new System.Drawing.Point(204, 3);
            this.m_cmbTypeLigne.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbTypeLigne, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbTypeLigne.Name = "m_cmbTypeLigne";
            this.m_cmbTypeLigne.Size = new System.Drawing.Size(564, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbTypeLigne, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbTypeLigne, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbTypeLigne.TabIndex = 4003;
            this.m_cmbTypeLigne.SelectionChangeCommitted += new System.EventHandler(this.m_cmbTypeLigne_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(0, 6);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 18);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4002;
            this.label3.Text = "Elements type in row entries |1173";
            // 
            // m_editFiltreDynamiqueData
            // 
            this.m_editFiltreDynamiqueData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_editFiltreDynamiqueData.BackColor = System.Drawing.Color.White;
            this.m_editFiltreDynamiqueData.Controls.Add(this.c2iTabControl1);
            this.m_editFiltreDynamiqueData.Controls.Add(this.m_tab);
            this.m_editFiltreDynamiqueData.DefinitionRacineDeChampsFiltres = null;
            this.m_editFiltreDynamiqueData.FiltreDynamique = null;
            this.m_extLinkField.SetLinkField(this.m_editFiltreDynamiqueData, "");
            this.m_editFiltreDynamiqueData.Location = new System.Drawing.Point(0, 27);
            this.m_editFiltreDynamiqueData.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_editFiltreDynamiqueData, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_editFiltreDynamiqueData.ModeSansType = true;
            this.m_editFiltreDynamiqueData.Name = "m_editFiltreDynamiqueData";
            this.m_editFiltreDynamiqueData.Size = new System.Drawing.Size(801, 151);
            this.m_extStyle.SetStyleBackColor(this.m_editFiltreDynamiqueData, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_editFiltreDynamiqueData, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_editFiltreDynamiqueData.TabIndex = 4004;
            // 
            // c2iTabControl1
            // 
            this.c2iTabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iTabControl1.BoldSelectedPage = true;
            this.c2iTabControl1.ControlBottomOffset = 16;
            this.c2iTabControl1.ControlRightOffset = 16;
            this.c2iTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c2iTabControl1.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.c2iTabControl1, "");
            this.c2iTabControl1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTabControl1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.c2iTabControl1.Name = "c2iTabControl1";
            this.c2iTabControl1.Ombre = true;
            this.c2iTabControl1.PositionTop = true;
            this.c2iTabControl1.Size = new System.Drawing.Size(801, 151);
            this.m_extStyle.SetStyleBackColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTabControl1.TabIndex = 2;
            // 
            // m_tab
            // 
            this.m_tab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_tab.BoldSelectedPage = true;
            this.m_tab.ControlBottomOffset = 16;
            this.m_tab.ControlRightOffset = 16;
            this.m_tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tab.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_tab, "");
            this.m_tab.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tab, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_tab.Name = "m_tab";
            this.m_tab.Ombre = true;
            this.m_tab.PositionTop = true;
            this.m_tab.Size = new System.Drawing.Size(801, 151);
            this.m_extStyle.SetStyleBackColor(this.m_tab, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tab, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tab.TabIndex = 2;
            // 
            // m_cmbTypeData
            // 
            this.m_cmbTypeData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbTypeData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTypeData.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbTypeData, "");
            this.m_cmbTypeData.Location = new System.Drawing.Point(204, 3);
            this.m_cmbTypeData.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbTypeData, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbTypeData.Name = "m_cmbTypeData";
            this.m_cmbTypeData.Size = new System.Drawing.Size(564, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbTypeData, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbTypeData, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbTypeData.TabIndex = 4003;
            this.m_cmbTypeData.SelectionChangeCommitted += new System.EventHandler(this.m_cmbTypeData_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.label5.Location = new System.Drawing.Point(1, 6);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 18);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 4002;
            this.label5.Text = "Data type in table cells|1174";
            // 
            // m_txtLabelPremiereColonne
            // 
            this.m_extLinkField.SetLinkField(this.m_txtLabelPremiereColonne, "NomPremiereColonne");
            this.m_txtLabelPremiereColonne.Location = new System.Drawing.Point(206, 6);
            this.m_txtLabelPremiereColonne.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLabelPremiereColonne, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtLabelPremiereColonne.Name = "m_txtLabelPremiereColonne";
            this.m_txtLabelPremiereColonne.Size = new System.Drawing.Size(564, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtLabelPremiereColonne, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLabelPremiereColonne, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLabelPremiereColonne.TabIndex = 1;
            this.m_txtLabelPremiereColonne.Text = "[NomPremiereColonne]";
            // 
            // label10
            // 
            this.m_extLinkField.SetLinkField(this.label10, "");
            this.label10.Location = new System.Drawing.Point(5, 9);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label10, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(195, 16);
            this.m_extStyle.SetStyleBackColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label10.TabIndex = 4004;
            this.label10.Text = "First column header|1210";
            // 
            // m_colJoursSemaine
            // 
            this.m_colJoursSemaine.Field = "";
            this.m_colJoursSemaine.PrecisionWidth = 0;
            this.m_colJoursSemaine.ProportionnalSize = false;
            this.m_colJoursSemaine.Visible = true;
            this.m_colJoursSemaine.Width = 120;
            // 
            // m_gestionnaireEditionTranches
            // 
            this.m_gestionnaireEditionTranches.ListeAssociee = this.m_lstTranchesHoraires;
            this.m_gestionnaireEditionTranches.ObjetEdite = null;
            this.m_gestionnaireEditionTranches.InitChamp += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireEditionTranches_InitChamp);
            this.m_gestionnaireEditionTranches.MAJ_Champs += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireEditionTranches_MAJ_Champs);
            // 
            // m_cmbxSelectTypeOccupationHpourTranche
            // 
            this.m_cmbxSelectTypeOccupationHpourTranche.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbxSelectTypeOccupationHpourTranche.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbxSelectTypeOccupationHpourTranche.ElementSelectionne = null;
            this.m_cmbxSelectTypeOccupationHpourTranche.FormattingEnabled = true;
            this.m_cmbxSelectTypeOccupationHpourTranche.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbxSelectTypeOccupationHpourTranche, "");
            this.m_cmbxSelectTypeOccupationHpourTranche.ListDonnees = null;
            this.m_cmbxSelectTypeOccupationHpourTranche.Location = new System.Drawing.Point(139, 48);
            this.m_cmbxSelectTypeOccupationHpourTranche.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbxSelectTypeOccupationHpourTranche, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbxSelectTypeOccupationHpourTranche.Name = "m_cmbxSelectTypeOccupationHpourTranche";
            this.m_cmbxSelectTypeOccupationHpourTranche.NullAutorise = true;
            this.m_cmbxSelectTypeOccupationHpourTranche.ProprieteAffichee = null;
            this.m_cmbxSelectTypeOccupationHpourTranche.ProprieteParentListeObjets = null;
            this.m_cmbxSelectTypeOccupationHpourTranche.SelectionneurParent = null;
            this.m_cmbxSelectTypeOccupationHpourTranche.Size = new System.Drawing.Size(214, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbxSelectTypeOccupationHpourTranche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbxSelectTypeOccupationHpourTranche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbxSelectTypeOccupationHpourTranche.TabIndex = 4007;
            this.m_cmbxSelectTypeOccupationHpourTranche.TextNull = I.T("(None)|30291");
            this.m_cmbxSelectTypeOccupationHpourTranche.Tri = true;
            // 
            // CFormEditionTypeTableauPlanning
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(830, 540);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.c2iPanelOmbre2);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CFormEditionTypeTableauPlanning";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre2, 0);
            this.Controls.SetChildIndex(this.m_tabControl, 0);
            this.c2iPanelOmbre2.ResumeLayout(false);
            this.c2iPanelOmbre2.PerformLayout();
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.m_tabPageTranchesHoraires.ResumeLayout(false);
            this.m_panelEditionTrancheHoraire.ResumeLayout(false);
            this.m_panelEditionTrancheHoraire.PerformLayout();
            this.m_tabPageParametres.ResumeLayout(false);
            this.m_tabPageParametres.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.m_editFiltreDynamiqueData.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CTypeTableauPlanning TypeTableauPlanning
		{
			get
			{ 
				return (CTypeTableauPlanning)ObjetEdite;
			}
		}
		
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();

            InitTypeElementsLigne(false);
            InitTypeElementsData(false);
            InitFiltreDynamiqueLigne();
            InitFiltreDynamiqueData();

            if (TypeTableauPlanning.TypeElementsLigne != null)
                m_cmbTypeLigne.SelectedValue = TypeTableauPlanning.TypeElementsLigne;
            else
                m_cmbTypeLigne.SelectedValue = typeof(DBNull);

            if (TypeTableauPlanning.TypeElementsData != null)
                m_cmbTypeData.SelectedValue = TypeTableauPlanning.TypeElementsData;
            else
                m_cmbTypeData.SelectedValue = typeof(DBNull);

            
            m_gestionnaireEditionTranches.ObjetEdite = TypeTableauPlanning.RelationsTranchesHoraires;
            m_panelEditionTrancheHoraire.Visible = m_gestionnaireEditionTranches.ObjetEnCours != null;

            CListeObjetsDonnees listeOccupations = new CListeObjetsDonnees(TypeTableauPlanning.ContexteDonnee, typeof(CTypeOccupationHoraire));
            m_cmbxSelectTypeOccupationHpourTranche.Init(listeOccupations, "Libelle", true);
            m_cmbxSelectTypeOccupationHpourTranche.NullAutorise = true;
            m_cmbxSelectTypeOccupationHpourTranche.TextNull = I.T("(None)|30291");


			return result;
		}

        //-------------------------------------------------------------------------
        private void InitFiltreDynamiqueLigne()
        {
            CFiltreDynamique filtre = TypeTableauPlanning.FiltreDynamiqueElementsLigne;
            if (filtre != null)
                m_editFiltreDynamiqueLigne.InitSansVariables(filtre);
            else
                m_editFiltreDynamiqueLigne.InitSansVariables(new CFiltreDynamique(TypeTableauPlanning.ContexteDonnee));

            if (m_editFiltreDynamiqueLigne.FiltreDynamique != null)
                m_editFiltreDynamiqueLigne.FiltreDynamique.TypeElements = (Type) m_cmbTypeLigne.SelectedValue;

            m_editFiltreDynamiqueLigne.ModeSansType = true;
            m_editFiltreDynamiqueLigne.MasquerFormulaire(true);
            
        }

        //-------------------------------------------------------------------------
        private void InitFiltreDynamiqueData()
        {
            CFiltreDynamique filtre = TypeTableauPlanning.FiltreDynamiqueElementsData;
            if (filtre != null)
                m_editFiltreDynamiqueData.InitSansVariables(filtre);
            else
                m_editFiltreDynamiqueData.InitSansVariables(new CFiltreDynamique(TypeTableauPlanning.ContexteDonnee));

            if (m_editFiltreDynamiqueData.FiltreDynamique != null)
                m_editFiltreDynamiqueData.FiltreDynamique.TypeElements = (Type)m_cmbTypeData.SelectedValue;

            m_editFiltreDynamiqueData.ModeSansType = true;
            m_editFiltreDynamiqueData.MasquerFormulaire(true);
        }

        //-------------------------------------------------------------------------
        private void InitTypeElementsData(bool bForcer)
        {
            if (m_cmbTypeData.Items.Count == 0 || bForcer)
            {
                ArrayList lst = new ArrayList();

                //foreach (CInfoClasseDynamique info in DynamicClassAttribute.GetAllDynamicClass(typeof(sc2i.data.TableAttribute)))
                //{
                //    if (typeof(CObjetDonneeAIdNumeriqueAuto).IsAssignableFrom(info.Classe))
                //    {
                //        lst.Add(info);
                //    }
                //}
                lst.Add(new CInfoClasseDynamique(typeof(CActeur), DynamicClassAttribute.GetNomConvivial(typeof(CActeur))));
                lst.Insert(0, new CInfoClasseDynamique(typeof(DBNull), I.T("(None)|30291")));
                m_cmbTypeData.DataSource = null;
                m_cmbTypeData.DataSource = lst;
                m_cmbTypeData.ValueMember = "Classe";
                m_cmbTypeData.DisplayMember = "Nom";
            }

        }

        //-------------------------------------------------------------------------
        private void InitTypeElementsLigne(bool bForcer)
        {
            if (m_cmbTypeLigne.Items.Count == 0 || bForcer)
            {
                ArrayList lst = new ArrayList();

                //foreach (CInfoClasseDynamique info in DynamicClassAttribute.GetAllDynamicClass(typeof(sc2i.data.TableAttribute)))
                //{
                //    if (typeof(CObjetDonneeAIdNumeriqueAuto).IsAssignableFrom(info.Classe))
                //    {
                //        lst.Add(info);
                //    }
                //}
                lst.Add(new CInfoClasseDynamique(typeof(CEntiteOrganisationnelle), DynamicClassAttribute.GetNomConvivial(typeof(CEntiteOrganisationnelle))));
                lst.Insert(0, new CInfoClasseDynamique(typeof(DBNull), I.T("(None)|30291")));
                m_cmbTypeLigne.DataSource = null;
                m_cmbTypeLigne.DataSource = lst;
                m_cmbTypeLigne.ValueMember = "Classe";
                m_cmbTypeLigne.DisplayMember = "Nom";
            }
        }
 

		//-------------------------------------------------------------------------
		protected override CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = base.MAJ_Champs();
			if ( !result )
				return result;

            if (m_cmbTypeLigne.SelectedValue is Type)
            {
                Type tp = (Type)m_cmbTypeLigne.SelectedValue;
                if (tp != typeof(DBNull))
                    TypeTableauPlanning.TypeElementsLigne = (Type)m_cmbTypeLigne.SelectedValue;
                else
                    TypeTableauPlanning.TypeElementsLigne = null;
            }
            else
                TypeTableauPlanning.TypeElementsLigne = null;

            if (m_cmbTypeData.SelectedValue is Type)
            {
                Type tp = (Type)m_cmbTypeData.SelectedValue;
                if (tp != typeof(DBNull))
                    TypeTableauPlanning.TypeElementsData = (Type)m_cmbTypeData.SelectedValue;
                else
                    TypeTableauPlanning.TypeElementsData = null;
            }
            else
                TypeTableauPlanning.TypeElementsData = null;


            if (m_editFiltreDynamiqueLigne.FiltreDynamique != null &&
                m_editFiltreDynamiqueLigne.FiltreDynamique.ComposantPrincipal != null)
                TypeTableauPlanning.FiltreDynamiqueElementsLigne = m_editFiltreDynamiqueLigne.FiltreDynamique;
            else
                TypeTableauPlanning.FiltreDynamiqueElementsLigne = null;

            if (m_editFiltreDynamiqueData.FiltreDynamique != null &&
                m_editFiltreDynamiqueData.FiltreDynamique.ComposantPrincipal != null)
                TypeTableauPlanning.FiltreDynamiqueElementsData = m_editFiltreDynamiqueData.FiltreDynamique;
            else
                TypeTableauPlanning.FiltreDynamiqueElementsData = null;


            m_gestionnaireEditionTranches.ValideModifs();

            
            // Vérifie les Tranches horaires
            foreach (CTypeTableauPlanning_TrancheHoraire rel in TypeTableauPlanning.RelationsTranchesHoraires)
            {
                result = rel.VerifieDonnees(false);
            }

			return result;
		}

        //----------------------------------------------------------------------------
        private void m_gestionnaireEditionTranches_InitChamp(object sender, CObjetDonneeResultEventArgs args)
        {
            if (args.Objet == null)
            {
                m_panelEditionTrancheHoraire.Visible = false;
                return;
            }
            m_panelEditionTrancheHoraire.Visible = true;

            CTypeTableauPlanning_TrancheHoraire rel = (CTypeTableauPlanning_TrancheHoraire)args.Objet;
            CHoraireJournalier_Tranche tranche = rel.TrancheHoraire;
            if (tranche != null)
            {

                int heure = (int)tranche.HeureDebut / 60;
                int minute = tranche.HeureDebut % 60;
                DateTime heureDebut = new DateTime(2000, 1, 1, heure, minute, 0);
                m_timePickerHeureDebut.Value = heureDebut;

                heure = (int)tranche.HeureFin / 60;
                minute = tranche.HeureFin % 60;
                DateTime heureFin = new DateTime(2000, 1, 1, heure, minute, 0);
                m_timePickerHeureFin.Value = heureFin;
                m_cmbxSelectTypeOccupationHpourTranche.ElementSelectionne = tranche.TypeOccupationHoraire;
            }
            m_txtLibelleTranche.Text = rel.Libelle;
            m_wndFormule.Init(m_elementPourFormules, typeof(IElementAVariablesDynamiques));
            m_wndFormule.Formule = rel.FormuleConditionnelle;
        }

        //----------------------------------------------------------------------------
        private void m_gestionnaireEditionTranches_MAJ_Champs(object sender, CObjetDonneeResultEventArgs args)
        {
            if (args.Objet != null && args.Objet.IsValide())
            {
                CTypeTableauPlanning_TrancheHoraire rel = (CTypeTableauPlanning_TrancheHoraire)args.Objet;
                CHoraireJournalier_Tranche tranche = rel.TrancheHoraire;

                if (tranche != null)
                {
                    DateTime heureDebut = m_timePickerHeureDebut.Value;
                    tranche.HeureDebut = heureDebut.Hour * 60 + heureDebut.Minute;

                    DateTime heureFin = m_timePickerHeureFin.Value;
                    tranche.HeureFin = heureFin.Hour * 60 + heureFin.Minute;
                    tranche.TypeOccupationHoraire = (CTypeOccupationHoraire)m_cmbxSelectTypeOccupationHpourTranche.ElementSelectionne;

                    CResultAErreur result = tranche.VerifieDonnees(true);
                    args.Result = result;
                }
                rel.Libelle = m_txtLibelleTranche.Text;
                rel.FormuleConditionnelle = m_wndFormule.Formule;
            }

        }

        //----------------------------------------------------------------------------
        private void m_lnkAjouterTranche_LinkClicked(object sender, EventArgs e)
        {
            m_gestionnaireEditionTranches.ValideModifs();

            CTypeTableauPlanning_TrancheHoraire rel = new CTypeTableauPlanning_TrancheHoraire(TypeTableauPlanning.ContexteDonnee);
            rel.CreateNewInCurrentContexte();
            rel.TypeTableauPlanning = TypeTableauPlanning;
            CHoraireJournalier_Tranche tranche = new CHoraireJournalier_Tranche(TypeTableauPlanning.ContexteDonnee);
            tranche.CreateNewInCurrentContexte();
            tranche.HeureDebut = 0;
            tranche.HeureFin = 0;
            rel.TrancheHoraire = tranche;

            ListViewItem item = new ListViewItem();
            m_lstTranchesHoraires.Items.Add(item);
            m_lstTranchesHoraires.UpdateItemWithObject(item, rel);
            item.Selected = true;

        }

        //----------------------------------------------------------------------------
        private void m_lnkSupprimerTranche_LinkClicked(object sender, EventArgs e)
        {
            if (m_lstTranchesHoraires.SelectedItems.Count != 1)
                return;

            CTypeTableauPlanning_TrancheHoraire rel = (CTypeTableauPlanning_TrancheHoraire) m_lstTranchesHoraires.SelectedItems[0].Tag;
            CHoraireJournalier_Tranche tranche = rel.TrancheHoraire;

            CResultAErreur result = rel.Delete();
            if (result)
                result = tranche.Delete();

            if (m_lstTranchesHoraires.SelectedItems.Count == 1)
            {
                if (m_lstTranchesHoraires.SelectedItems[0] != null)
                    m_lstTranchesHoraires.SelectedItems[0].Remove();
            }

        }

        //----------------------------------------------------------------------------
        private void m_cmbTypeLigne_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (m_cmbTypeLigne.SelectedValue is Type && m_cmbTypeLigne.SelectedValue != typeof(DBNull))
            {
                Type tp = (Type)m_cmbTypeLigne.SelectedValue;
                if (tp != null)
                {
                    m_editFiltreDynamiqueLigne.Visible = true;
                    if (m_editFiltreDynamiqueLigne.FiltreDynamique != null)
                        m_editFiltreDynamiqueLigne.FiltreDynamique.TypeElements = tp;
                }
                else
                    m_editFiltreDynamiqueLigne.Visible = false;
                
            }
        }

        //----------------------------------------------------------------------------
        private void m_cmbTypeData_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (m_cmbTypeData.SelectedValue is Type && m_cmbTypeData.SelectedValue != typeof(DBNull))
            {
                Type tp = (Type)m_cmbTypeData.SelectedValue;
                if (tp != null)
                {
                    m_editFiltreDynamiqueData.Visible = true;
                    if (m_editFiltreDynamiqueData.FiltreDynamique != null)
                        m_editFiltreDynamiqueData.FiltreDynamique.TypeElements = tp;
                }
                else
                    m_editFiltreDynamiqueData.Visible = false;

            }
        }

 
	}
}

