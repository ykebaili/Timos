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
using timos.data.workflow.gantt;
using timos.data;
using timos.data.projet.gantt;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CParametrageGantt))]
	public class CFormEditionParametrageGantt : CFormEditionStdTimos, IFormNavigable
	{
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
        private C2iTabControl c2iTabControl1;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private Crownwood.Magic.Controls.TabPage tabPage2;
        private sc2i.win32.data.dynamic.CPanelEditFiltreDynamique m_panelFiltre;
        private timos.projet.gantt.CPanelEditGroupeGantt m_panelEditGroupe;
        private Panel m_panelCreateRacine;
        private LinkLabel m_lnkCreateRoot;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionParametrageGantt()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
            m_panelFiltre.MasquerFormulaire(true);
		}
		//-------------------------------------------------------------------------
		public CFormEditionParametrageGantt(CParametrageGantt ParametrageGantt)
			:base(ParametrageGantt)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
            m_panelFiltre.MasquerFormulaire(true);
		}
		//-------------------------------------------------------------------------
		public CFormEditionParametrageGantt(CParametrageGantt ParametrageGantt, CListeObjetsDonnees liste)
			:base(ParametrageGantt, liste)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
            m_panelFiltre.MasquerFormulaire(true);
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
            this.c2iTabControl1 = new sc2i.win32.common.C2iTabControl(this.components);
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.m_panelEditGroupe = new timos.projet.gantt.CPanelEditGroupeGantt();
            this.m_panelCreateRacine = new System.Windows.Forms.Panel();
            this.m_lnkCreateRoot = new System.Windows.Forms.LinkLabel();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.m_panelFiltre = new sc2i.win32.data.dynamic.CPanelEditFiltreDynamique();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.c2iTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.m_panelCreateRacine.SuspendLayout();
            this.tabPage2.SuspendLayout();
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
            // c2iTabControl1
            // 
            this.c2iTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iTabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iTabControl1.BoldSelectedPage = true;
            this.c2iTabControl1.ControlBottomOffset = 16;
            this.c2iTabControl1.ControlRightOffset = 16;
            this.c2iTabControl1.ForeColor = System.Drawing.Color.Black;
            this.c2iTabControl1.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.c2iTabControl1, "");
            this.c2iTabControl1.Location = new System.Drawing.Point(11, 114);
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTabControl1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iTabControl1, "");
            this.c2iTabControl1.Name = "c2iTabControl1";
            this.c2iTabControl1.Ombre = true;
            this.c2iTabControl1.PositionTop = true;
            this.c2iTabControl1.SelectedIndex = 0;
            this.c2iTabControl1.SelectedTab = this.tabPage1;
            this.c2iTabControl1.Size = new System.Drawing.Size(819, 413);
            this.m_extStyle.SetStyleBackColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iTabControl1.TabIndex = 4004;
            this.c2iTabControl1.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2});
            this.c2iTabControl1.TextColor = System.Drawing.Color.Black;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_panelEditGroupe);
            this.tabPage1.Controls.Add(this.m_panelCreateRacine);
            this.m_extLinkField.SetLinkField(this.tabPage1, "");
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tabPage1, "");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(803, 372);
            this.m_extStyle.SetStyleBackColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage1.TabIndex = 10;
            this.tabPage1.Title = "Gantt tree|20161";
            // 
            // m_panelEditGroupe
            // 
            this.m_panelEditGroupe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelEditGroupe, "");
            this.m_panelEditGroupe.Location = new System.Drawing.Point(0, 26);
            this.m_panelEditGroupe.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEditGroupe, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelEditGroupe, "");
            this.m_panelEditGroupe.Name = "m_panelEditGroupe";
            this.m_panelEditGroupe.Size = new System.Drawing.Size(803, 346);
            this.m_extStyle.SetStyleBackColor(this.m_panelEditGroupe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEditGroupe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEditGroupe.TabIndex = 0;
            this.m_panelEditGroupe.DeleteFilsEventHandler += new System.EventHandler(this.m_panelEditGroupe_DeleteFilsEventHandler);
            // 
            // m_panelCreateRacine
            // 
            this.m_panelCreateRacine.Controls.Add(this.m_lnkCreateRoot);
            this.m_panelCreateRacine.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.m_panelCreateRacine, "");
            this.m_panelCreateRacine.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelCreateRacine, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelCreateRacine, "");
            this.m_panelCreateRacine.Name = "m_panelCreateRacine";
            this.m_panelCreateRacine.Size = new System.Drawing.Size(803, 26);
            this.m_extStyle.SetStyleBackColor(this.m_panelCreateRacine, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCreateRacine, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelCreateRacine.TabIndex = 1;
            // 
            // m_lnkCreateRoot
            // 
            this.m_lnkCreateRoot.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lnkCreateRoot, "");
            this.m_lnkCreateRoot.Location = new System.Drawing.Point(6, 5);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkCreateRoot, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkCreateRoot, "");
            this.m_lnkCreateRoot.Name = "m_lnkCreateRoot";
            this.m_lnkCreateRoot.Size = new System.Drawing.Size(122, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkCreateRoot, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkCreateRoot, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkCreateRoot.TabIndex = 0;
            this.m_lnkCreateRoot.TabStop = true;
            this.m_lnkCreateRoot.Text = "Create root level|20167";
            this.m_lnkCreateRoot.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkCreateRoot_LinkClicked);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.m_panelFiltre);
            this.m_extLinkField.SetLinkField(this.tabPage2, "");
            this.tabPage2.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tabPage2, "");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(803, 372);
            this.m_extStyle.SetStyleBackColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage2.TabIndex = 11;
            this.tabPage2.Title = "Projects filter|20162";
            // 
            // m_panelFiltre
            // 
            this.m_panelFiltre.BackColor = System.Drawing.Color.White;
            this.m_panelFiltre.DefinitionRacineDeChampsFiltres = null;
            this.m_panelFiltre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelFiltre.FiltreDynamique = null;
            this.m_extLinkField.SetLinkField(this.m_panelFiltre, "");
            this.m_panelFiltre.Location = new System.Drawing.Point(0, 0);
            this.m_panelFiltre.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelFiltre, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelFiltre.ModeFiltreExpression = false;
            this.m_panelFiltre.ModeSansType = true;
            this.m_extModulesAssociator.SetModules(this.m_panelFiltre, "");
            this.m_panelFiltre.Name = "m_panelFiltre";
            this.m_panelFiltre.Size = new System.Drawing.Size(803, 372);
            this.m_extStyle.SetStyleBackColor(this.m_panelFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelFiltre.TabIndex = 0;
            // 
            // CFormEditionParametrageGantt
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.c2iTabControl1);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionParametrageGantt";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre4, 0);
            this.Controls.SetChildIndex(this.c2iTabControl1, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.c2iPanelOmbre4.ResumeLayout(false);
            this.c2iPanelOmbre4.PerformLayout();
            this.c2iTabControl1.ResumeLayout(false);
            this.c2iTabControl1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.m_panelCreateRacine.ResumeLayout(false);
            this.m_panelCreateRacine.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CParametrageGantt ParametrageGantt
		{
			get
			{
				return (CParametrageGantt)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
			AffecterTitre(I.T( "Gantt setting @1|20160", ParametrageGantt.Libelle));
            CFiltreDynamique filtre = ParametrageGantt.FiltreElements;
            if (filtre == null)
            {
                filtre = new CFiltreDynamique(ParametrageGantt.ContexteDonnee);
                filtre.TypeElements = typeof(CProjet);
            }
            m_panelFiltre.Init(filtre);
            UpdateGroupes();
			return result;
		}

        //-------------------------------------------------------------------------
        private void UpdateGroupes()
        {
            if (ParametrageGantt.GroupeRacine == null)
            {
                m_panelCreateRacine.Visible = true;
                m_panelEditGroupe.Visible = false;
            }
            else
            {
                m_panelCreateRacine.Visible = false;
                m_panelEditGroupe.Visible = true;
                m_panelEditGroupe.Init(ParametrageGantt.GroupeRacine);
            }
        }

		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();
            if (!result)
                return result;
            ParametrageGantt.FiltreElements = m_panelFiltre.FiltreDynamique;
            if (ParametrageGantt.GroupeRacine != null)
            {
                result = m_panelEditGroupe.MajChamps();
            }
            if (!result)
                return result;
            ParametrageGantt.GroupeRacine = m_panelEditGroupe.Parametre;

            return result;
        }

        private void m_panelEditGroupe_DeleteFilsEventHandler(object sender, EventArgs e)
        {
            ParametrageGantt.GroupeRacine = null;
            UpdateGroupes();
        }

        private void m_lnkCreateRoot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ParametrageGantt.GroupeRacine == null)
            {
                ParametrageGantt.GroupeRacine = new CParametreNiveauArbreGanttGroupe();
                UpdateGroupes();
            }
        }
	}
}

