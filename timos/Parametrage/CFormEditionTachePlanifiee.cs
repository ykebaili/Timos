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
using sc2i.process;


namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CTachePlanifiee))]
	public class CFormEditionTachePlanifiee : CFormEditionStdTimos, IFormNavigable
	{
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
		private System.Windows.Forms.Label label2;
		private sc2i.win32.common.C2iTextBox c2iTextBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label m_lblProchaineExecution;
		private System.Windows.Forms.LinkLabel m_lnkReplanifier;
		private System.Windows.Forms.CheckBox m_chkBloquer;
		private sc2i.win32.common.C2iTabControl m_tabControl;
		private Crownwood.Magic.Controls.TabPage tabPage1;
		private Crownwood.Magic.Controls.TabPage tabPage2;
		private System.Windows.Forms.LinkLabel m_lnkExecuter;
		private timos.win32.composants.CEditeurParametrePlanificationIntervention m_panelPlanification;
		private sc2i.win32.data.navigation.CPanelListeRelationSelection m_panelProcess;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private sc2i.win32.data.navigation.CPanelListeRelationSelection m_panelTypesDonnees;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn1;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn2;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionTachePlanifiee()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionTachePlanifiee(CTachePlanifiee TachePlanifiee)
			:base(TachePlanifiee)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionTachePlanifiee(CTachePlanifiee TachePlanifiee, CListeObjetsDonnees liste)
			:base(TachePlanifiee, liste)
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
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_chkBloquer = new System.Windows.Forms.CheckBox();
            this.c2iTextBox1 = new sc2i.win32.common.C2iTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_lblProchaineExecution = new System.Windows.Forms.Label();
            this.m_lnkReplanifier = new System.Windows.Forms.LinkLabel();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.m_panelPlanification = new timos.win32.composants.CEditeurParametrePlanificationIntervention();
            this.m_lnkExecuter = new System.Windows.Forms.LinkLabel();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.m_panelTypesDonnees = new sc2i.win32.data.navigation.CPanelListeRelationSelection();
            this.listViewAutoFilledColumn2 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.m_panelProcess = new sc2i.win32.data.navigation.CPanelListeRelationSelection();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.c2iPanelOmbre4.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(830, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.label1.Location = new System.Drawing.Point(8, 11);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
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
            this.m_txtLibelle.Location = new System.Drawing.Point(104, 8);
            this.m_txtLibelle.LockEdition = false;
            this.m_txtLibelle.MaxLength = 128;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(280, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Label]|30324";
            // 
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.m_chkBloquer);
            this.c2iPanelOmbre4.Controls.Add(this.c2iTextBox1);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.Controls.Add(this.label1);
            this.c2iPanelOmbre4.Controls.Add(this.label2);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(8, 52);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(648, 108);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // m_chkBloquer
            // 
            this.m_extLinkField.SetLinkField(this.m_chkBloquer, "Bloquer");
            this.m_chkBloquer.Location = new System.Drawing.Point(392, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkBloquer, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkBloquer.Name = "m_chkBloquer";
            this.m_chkBloquer.Size = new System.Drawing.Size(232, 16);
            this.m_extStyle.SetStyleBackColor(this.m_chkBloquer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkBloquer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkBloquer.TabIndex = 4005;
            this.m_chkBloquer.Text = "Disable this Task|929";
            // 
            // c2iTextBox1
            // 
            this.m_extLinkField.SetLinkField(this.c2iTextBox1, "Commentaires");
            this.c2iTextBox1.Location = new System.Drawing.Point(104, 32);
            this.c2iTextBox1.LockEdition = false;
            this.c2iTextBox1.MaxLength = 128;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.c2iTextBox1.Multiline = true;
            this.c2iTextBox1.Name = "c2iTextBox1";
            this.c2iTextBox1.Size = new System.Drawing.Size(520, 56);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox1.TabIndex = 4004;
            this.c2iTextBox1.Text = "[Commentaires]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(8, 35);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4003;
            this.label2.Text = "Comment|51";
            // 
            // label4
            // 
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.label4.Location = new System.Drawing.Point(8, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 16);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 4;
            this.label4.Text = "Next execution|931";
            // 
            // m_lblProchaineExecution
            // 
            this.m_lblProchaineExecution.BackColor = System.Drawing.Color.White;
            this.m_lblProchaineExecution.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_extLinkField.SetLinkField(this.m_lblProchaineExecution, "");
            this.m_lblProchaineExecution.Location = new System.Drawing.Point(120, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblProchaineExecution, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblProchaineExecution.Name = "m_lblProchaineExecution";
            this.m_lblProchaineExecution.Size = new System.Drawing.Size(122, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lblProchaineExecution, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblProchaineExecution, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblProchaineExecution.TabIndex = 5;
            this.m_lblProchaineExecution.Text = "-";
            // 
            // m_lnkReplanifier
            // 
            this.m_extLinkField.SetLinkField(this.m_lnkReplanifier, "");
            this.m_lnkReplanifier.Location = new System.Drawing.Point(268, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkReplanifier, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkReplanifier.Name = "m_lnkReplanifier";
            this.m_lnkReplanifier.Size = new System.Drawing.Size(100, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkReplanifier, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkReplanifier, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkReplanifier.TabIndex = 6;
            this.m_lnkReplanifier.TabStop = true;
            this.m_lnkReplanifier.Text = "Re-plan|932";
            this.m_lnkReplanifier.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkReplanifier_LinkClicked);
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
            this.m_tabControl.Location = new System.Drawing.Point(8, 160);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 1;
            this.m_tabControl.SelectedTab = this.tabPage2;
            this.m_tabControl.Size = new System.Drawing.Size(814, 366);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4005;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_panelPlanification);
            this.tabPage1.Controls.Add(this.m_lnkExecuter);
            this.tabPage1.Controls.Add(this.m_lblProchaineExecution);
            this.tabPage1.Controls.Add(this.m_lnkReplanifier);
            this.tabPage1.Controls.Add(this.label4);
            this.m_extLinkField.SetLinkField(this.tabPage1, "");
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(798, 325);
            this.m_extStyle.SetStyleBackColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage1.TabIndex = 10;
            this.tabPage1.Title = "Planning|563";
            // 
            // m_panelPlanification
            // 
            this.m_panelPlanification.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_panelPlanification, "");
            this.m_panelPlanification.Location = new System.Drawing.Point(8, 24);
            this.m_panelPlanification.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelPlanification, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelPlanification.Name = "m_panelPlanification";
            this.m_panelPlanification.Size = new System.Drawing.Size(790, 302);
            this.m_extStyle.SetStyleBackColor(this.m_panelPlanification, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelPlanification, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelPlanification.TabIndex = 8;
            // 
            // m_lnkExecuter
            // 
            this.m_extLinkField.SetLinkField(this.m_lnkExecuter, "");
            this.m_lnkExecuter.Location = new System.Drawing.Point(389, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkExecuter, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_lnkExecuter.Name = "m_lnkExecuter";
            this.m_lnkExecuter.Size = new System.Drawing.Size(112, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkExecuter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkExecuter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkExecuter.TabIndex = 7;
            this.m_lnkExecuter.TabStop = true;
            this.m_lnkExecuter.Text = "Execute now|933";
            this.m_lnkExecuter.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkExecuter_LinkClicked);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.m_panelTypesDonnees);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.m_panelProcess);
            this.m_extLinkField.SetLinkField(this.tabPage2, "");
            this.tabPage2.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(798, 325);
            this.m_extStyle.SetStyleBackColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage2.TabIndex = 11;
            this.tabPage2.Title = "Tasks|930";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.label5.Location = new System.Drawing.Point(360, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(177, 16);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 4022;
            this.label5.Text = "Data to calculate|935";
            // 
            // m_panelTypesDonnees
            // 
            this.m_panelTypesDonnees.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_panelTypesDonnees.Columns.AddRange(new sc2i.win32.common.ListViewAutoFilledColumn[] {
            this.listViewAutoFilledColumn2});
            this.m_panelTypesDonnees.EnableCustomisation = true;
            this.m_panelTypesDonnees.ExclusionParException = false;
            this.m_extLinkField.SetLinkField(this.m_panelTypesDonnees, "");
            this.m_panelTypesDonnees.Location = new System.Drawing.Point(352, 24);
            this.m_panelTypesDonnees.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelTypesDonnees, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelTypesDonnees.Name = "m_panelTypesDonnees";
            this.m_panelTypesDonnees.Size = new System.Drawing.Size(272, 286);
            this.m_extStyle.SetStyleBackColor(this.m_panelTypesDonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelTypesDonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelTypesDonnees.TabIndex = 4021;
            // 
            // listViewAutoFilledColumn2
            // 
            this.listViewAutoFilledColumn2.Field = "Libelle";
            this.listViewAutoFilledColumn2.PrecisionWidth = 0;
            this.listViewAutoFilledColumn2.ProportionnalSize = false;
            this.listViewAutoFilledColumn2.Text = "Label|50";
            this.listViewAutoFilledColumn2.Visible = true;
            this.listViewAutoFilledColumn2.Width = 240;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(16, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 16);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4020;
            this.label3.Text = "Actions to trigger|934";
            // 
            // m_panelProcess
            // 
            this.m_panelProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_panelProcess.Columns.AddRange(new sc2i.win32.common.ListViewAutoFilledColumn[] {
            this.listViewAutoFilledColumn1});
            this.m_panelProcess.EnableCustomisation = true;
            this.m_panelProcess.ExclusionParException = false;
            this.m_extLinkField.SetLinkField(this.m_panelProcess, "");
            this.m_panelProcess.Location = new System.Drawing.Point(8, 24);
            this.m_panelProcess.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelProcess, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelProcess.Name = "m_panelProcess";
            this.m_panelProcess.Size = new System.Drawing.Size(272, 286);
            this.m_extStyle.SetStyleBackColor(this.m_panelProcess, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelProcess, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelProcess.TabIndex = 4019;
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "Libelle";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Label|50";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 240;
            // 
            // CFormEditionTachePlanifiee
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CFormEditionTachePlanifiee";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre4, 0);
            this.Controls.SetChildIndex(this.m_tabControl, 0);
            this.c2iPanelOmbre4.ResumeLayout(false);
            this.c2iPanelOmbre4.PerformLayout();
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CTachePlanifiee TachePlanifiee
		{
			get
			{
				return (CTachePlanifiee)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
			AffecterTitre(I.T("Planned task |30234 ") + TachePlanifiee.Libelle);
			CListeObjetsDonnees listeProcess = new CListeObjetsDonnees ( TachePlanifiee.ContexteDonnee,
				typeof(CProcessInDb) );
			listeProcess.Filtre = new CFiltreData ( CProcessInDb.c_champTypeCible+"=@1 or "+
				CProcessInDb.c_champTypeCible +" is null",
				"" );
			m_panelProcess.Init ( 
				listeProcess,
				TachePlanifiee.RelationsProcess,
				TachePlanifiee,
                "TachePlanifiee",
				"Process");
			m_panelTypesDonnees.Init(
				new CListeObjetsDonnees(TachePlanifiee.ContexteDonnee, typeof(CTypeDonneeCumulee)),
				TachePlanifiee.RelationsTypesDonneesCumulees,
				TachePlanifiee,
				"TachePlanifiee",
				"TypeDonneeCumulee");
			m_panelProcess.RemplirGrille();
			m_panelPlanification.Init ( TachePlanifiee.ParametrePlanification );
			UpdateDateProchaineExecution();
			return result;
		}

		//-------------------------------------------------------------------------
		protected override CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = base.MAJ_Champs();
			if ( result )
				m_panelTypesDonnees.ApplyModifs();
			if ( result )
				m_panelProcess.ApplyModifs();
			if ( result )
			{
				result = m_panelPlanification.ValideDonnees();
				if ( result )
					TachePlanifiee.ParametrePlanification = m_panelPlanification.ParametrePlanification;
			}
			return result;
		}

		private void m_lnkReplanifier_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			CDateTimeEx dt = null;
			if ( !m_gestionnaireModeEdition.ModeEdition )
				dt = TachePlanifiee.ParametrePlanification.GetNextOccurence ( DateTime.Now, true );
			else
			{
				m_panelPlanification.ValideDonnees();
				dt = m_panelPlanification.ParametrePlanification.GetNextOccurence ( DateTime.Now, true );
			}
			if ( dt != null )
			{
				if ( CFormAlerte.Afficher(I.T("Plan execution on |30235")+dt.DateTimeValue.ToString("g"),
					EFormAlerteType.Question)== DialogResult.Yes )
				{
					if ( !m_gestionnaireModeEdition.ModeEdition )
						TachePlanifiee.BeginEdit();
					TachePlanifiee.DateProchaineExecution = dt;
					if(  !m_gestionnaireModeEdition.ModeEdition )
					{
						CResultAErreur result = TachePlanifiee.CommitEdit();
						if ( !result )
						{
							CFormAlerte.Afficher(result.Erreur);
							return;
						}
					}
				}
				UpdateDateProchaineExecution();
			}
		}

		//////////////////////////////////////////////////////
		private void UpdateDateProchaineExecution()
		{
			if ( TachePlanifiee.DateProchaineExecution == null )
				m_lblProchaineExecution.Text = "-";
			else
				m_lblProchaineExecution.Text = TachePlanifiee.DateProchaineExecution.DateTimeValue.ToString("g");
		}

		//////////////////////////////////////////////////////
		private void StartAction()
		{
			CResultAErreur result = TachePlanifiee.ExecuteTache ( CFormProgressTimos.Indicateur );
			if ( !result )
			{
				result.EmpileErreur(I.T("Error during planned task execution|30236"));
				CFormAlerte.Afficher ( result.Erreur );
			}
		}

		//////////////////////////////////////////////////////
		private void m_lnkExecuter_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			CFormProgressTimos.StartThreadWithProgress ( I.T("Planned task |30234")+TachePlanifiee.Libelle, new System.Threading.ThreadStart ( StartAction ), false );
		}

	}
}

