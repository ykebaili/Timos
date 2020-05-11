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

using timos.preventives;
using timos.acteurs;
using timos.data;
using timos.data.preventives;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CListeOperations))]
	public class CFormEditionListeOperations : CFormEditionStdTimos, IFormNavigable
	{
		private System.Windows.Forms.Label lbl_label;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
        private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
        private C2iTabControl c2iTabControl1;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private Label label3;
        private ListViewAutoFilledColumn listViewAutoFilledColumn1;
        private ListViewAutoFilledColumn listViewAutoFilledColumn2;
        private ListViewAutoFilledColumn listViewAutoFilledColumn3;
        private ListViewAutoFilledColumn listViewAutoFilledColumn4;
        private CGestionnaireEditionSousObjetDonnee m_gestionnaireTypeOperation;
        private CControlePrevisionsOperations m_controlOperations;
        private C2iPanel c2iPanel1;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionListeOperations()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionListeOperations(CListeOperations contrat)
            : base(contrat)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
        public CFormEditionListeOperations(CListeOperations contrat, CListeObjetsDonnees liste)
            : base(contrat, liste)
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
			this.lbl_label = new System.Windows.Forms.Label();
			this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
			this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
			this.c2iTabControl1 = new sc2i.win32.common.C2iTabControl(this.components);
			this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
			this.c2iPanel1 = new sc2i.win32.common.C2iPanel(this.components);
			this.m_controlOperations = new timos.preventives.CControlePrevisionsOperations();
			this.label3 = new System.Windows.Forms.Label();
			this.listViewAutoFilledColumn2 = new sc2i.win32.common.ListViewAutoFilledColumn();
			this.listViewAutoFilledColumn3 = new sc2i.win32.common.ListViewAutoFilledColumn();
			this.listViewAutoFilledColumn4 = new sc2i.win32.common.ListViewAutoFilledColumn();
			this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
			this.m_gestionnaireTypeOperation = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
			this.m_panelMenu.SuspendLayout();
			this.c2iPanelOmbre4.SuspendLayout();
			this.c2iTabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.c2iPanel1.SuspendLayout();
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
			// m_panelMenu
			// 
			this.m_panelMenu.Size = new System.Drawing.Size(830, 28);
			this.m_extStyle.SetStyleBackColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			// 
			// lbl_label
			// 
			this.m_extLinkField.SetLinkField(this.lbl_label, "");
			this.lbl_label.Location = new System.Drawing.Point(16, 12);
			this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_label, sc2i.win32.common.TypeModeEdition.Autonome);
			this.lbl_label.Name = "lbl_label";
			this.lbl_label.Size = new System.Drawing.Size(112, 16);
			this.m_extStyle.SetStyleBackColor(this.lbl_label, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.lbl_label, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.lbl_label.TabIndex = 4002;
			this.lbl_label.Text = "List label|1125";
			// 
			// m_txtLibelle
			// 
			this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
			this.m_txtLibelle.Location = new System.Drawing.Point(132, 8);
			this.m_txtLibelle.LockEdition = false;
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
			this.c2iPanelOmbre4.Controls.Add(this.lbl_label);
			this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
			this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
			this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
			this.c2iPanelOmbre4.Location = new System.Drawing.Point(8, 52);
			this.c2iPanelOmbre4.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
			this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
			this.c2iPanelOmbre4.Size = new System.Drawing.Size(592, 64);
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
			this.c2iTabControl1.HideTabsMode = Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;
			this.c2iTabControl1.IDEPixelArea = false;
			this.m_extLinkField.SetLinkField(this.c2iTabControl1, "");
			this.c2iTabControl1.Location = new System.Drawing.Point(8, 122);
			this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTabControl1, sc2i.win32.common.TypeModeEdition.Autonome);
			this.c2iTabControl1.Name = "c2iTabControl1";
			this.c2iTabControl1.Ombre = true;
			this.c2iTabControl1.PositionTop = true;
			this.c2iTabControl1.SelectedIndex = 0;
			this.c2iTabControl1.SelectedTab = this.tabPage1;
			this.c2iTabControl1.Size = new System.Drawing.Size(810, 396);
			this.m_extStyle.SetStyleBackColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
			this.m_extStyle.SetStyleForeColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
			this.c2iTabControl1.TabIndex = 4004;
			this.c2iTabControl1.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1});
			this.c2iTabControl1.TextColor = System.Drawing.Color.Black;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.c2iPanel1);
			this.tabPage1.Controls.Add(this.label3);
			this.m_extLinkField.SetLinkField(this.tabPage1, "");
			this.tabPage1.Location = new System.Drawing.Point(0, 0);
			this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage1, sc2i.win32.common.TypeModeEdition.Autonome);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(794, 380);
			this.m_extStyle.SetStyleBackColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.tabPage1.TabIndex = 10;
			// 
			// c2iPanel1
			// 
			this.c2iPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.c2iPanel1.Controls.Add(this.m_controlOperations);
			this.m_extLinkField.SetLinkField(this.c2iPanel1, "");
			this.c2iPanel1.Location = new System.Drawing.Point(19, 36);
			this.c2iPanel1.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanel1, sc2i.win32.common.TypeModeEdition.Autonome);
			this.c2iPanel1.Name = "c2iPanel1";
			this.c2iPanel1.Size = new System.Drawing.Size(760, 328);
			this.m_extStyle.SetStyleBackColor(this.c2iPanel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.c2iPanel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.c2iPanel1.TabIndex = 4005;
			// 
			// m_controlOperations
			// 
			this.m_controlOperations.ControlActif = null;
			this.m_controlOperations.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_extLinkField.SetLinkField(this.m_controlOperations, "");
			this.m_controlOperations.Location = new System.Drawing.Point(0, 0);
			this.m_controlOperations.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_controlOperations, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_controlOperations.Name = "m_controlOperations";
			this.m_controlOperations.Size = new System.Drawing.Size(760, 328);
			this.m_extStyle.SetStyleBackColor(this.m_controlOperations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_controlOperations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_controlOperations.TabIndex = 4004;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.m_extLinkField.SetLinkField(this.label3, "");
			this.label3.Location = new System.Drawing.Point(16, 17);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(143, 13);
			this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label3.TabIndex = 4003;
			this.label3.Text = "Associated Operations|1126";
			// 
			// listViewAutoFilledColumn2
			// 
			this.listViewAutoFilledColumn2.Field = "TypeOperation.Code";
			this.listViewAutoFilledColumn2.PrecisionWidth = 0;
			this.listViewAutoFilledColumn2.ProportionnalSize = false;
			this.listViewAutoFilledColumn2.Text = "Code|40";
			this.listViewAutoFilledColumn2.Visible = true;
			this.listViewAutoFilledColumn2.Width = 120;
			// 
			// listViewAutoFilledColumn3
			// 
			this.listViewAutoFilledColumn3.Field = "TypeOperation.Libelle";
			this.listViewAutoFilledColumn3.PrecisionWidth = 0;
			this.listViewAutoFilledColumn3.ProportionnalSize = false;
			this.listViewAutoFilledColumn3.Text = "Label|50";
			this.listViewAutoFilledColumn3.Visible = true;
			this.listViewAutoFilledColumn3.Width = 191;
			// 
			// listViewAutoFilledColumn4
			// 
			this.listViewAutoFilledColumn4.Field = "TypeOperation.DureeStandardHeures";
			this.listViewAutoFilledColumn4.PrecisionWidth = 0;
			this.listViewAutoFilledColumn4.ProportionnalSize = false;
			this.listViewAutoFilledColumn4.Text = "Standard duration|340";
			this.listViewAutoFilledColumn4.Visible = true;
			this.listViewAutoFilledColumn4.Width = 123;
			// 
			// listViewAutoFilledColumn1
			// 
			this.listViewAutoFilledColumn1.Field = "Libelle";
			this.listViewAutoFilledColumn1.PrecisionWidth = 0;
			this.listViewAutoFilledColumn1.ProportionnalSize = false;
			this.listViewAutoFilledColumn1.Text = "Label|50";
			this.listViewAutoFilledColumn1.Visible = true;
			this.listViewAutoFilledColumn1.Width = 428;
			// 
			// m_gestionnaireTypeOperation
			// 
			this.m_gestionnaireTypeOperation.ObjetEdite = null;
			// 
			// CFormEditionListeOperations
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(830, 530);
			this.Controls.Add(this.c2iTabControl1);
			this.Controls.Add(this.c2iPanelOmbre4);
			this.m_extLinkField.SetLinkField(this, "");
			this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
			this.Name = "CFormEditionListeOperations";
			this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.Controls.SetChildIndex(this.m_panelMenu, 0);
			this.Controls.SetChildIndex(this.c2iPanelOmbre4, 0);
			this.Controls.SetChildIndex(this.c2iTabControl1, 0);
			this.m_panelMenu.ResumeLayout(false);
			this.c2iPanelOmbre4.ResumeLayout(false);
			this.c2iPanelOmbre4.PerformLayout();
			this.c2iTabControl1.ResumeLayout(false);
			this.c2iTabControl1.PerformLayout();
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.c2iPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CListeOperations ListeOperations
		{
			get
			{
				return (CListeOperations)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
			AffecterTitre(I.T( "Operations List|1124") + ListeOperations.Libelle);

            m_controlOperations.Init(ListeOperations);
            m_controlOperations.Visible = true;
            m_controlOperations.BringToFront();
            m_controlOperations.Focus();
            

			return result;
		}
        
        //-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();

            result = m_controlOperations.Maj_Champs();

            return result;
        }


    }
}

