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
using timos.data.projet.besoin;
using timos.projet.besoin;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CPhaseSpecifications))]
	public class CFormEditionPhaseSpecifications : CFormEditionStdTimos, IFormNavigable
	{
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
        private C2iTabControl m_tabControl;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private CControleListeBesoins m_wndListeBesoins;
        private LinkLabel m_lnkProjet;
        private CheckBox m_chkTemplate;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionPhaseSpecifications()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionPhaseSpecifications(CPhaseSpecifications PhaseSpecifications)
			:base(PhaseSpecifications)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionPhaseSpecifications(CPhaseSpecifications PhaseSpecifications, CListeObjetsDonnees liste)
			:base(PhaseSpecifications, liste)
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
            this.m_lnkProjet = new System.Windows.Forms.LinkLabel();
            this.m_chkTemplate = new System.Windows.Forms.CheckBox();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.m_wndListeBesoins = new timos.projet.besoin.CControleListeBesoins();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
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
            // m_extLinkField
            // 
            this.m_extLinkField.SourceTypeString = "timos.data.projet.besoin.CPhaseSpecifications";
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
            this.m_txtLibelle.Size = new System.Drawing.Size(484, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Libelle]";
            // 
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.m_lnkProjet);
            this.c2iPanelOmbre4.Controls.Add(this.label1);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.Controls.Add(this.m_chkTemplate);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iPanelOmbre4, false);
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(8, 52);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(641, 64);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // m_lnkProjet
            // 
            this.m_extLinkField.SetLinkField(this.m_lnkProjet, "Projet.Libelle");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkProjet, true);
            this.m_lnkProjet.Location = new System.Drawing.Point(132, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkProjet, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkProjet, "");
            this.m_lnkProjet.Name = "m_lnkProjet";
            this.m_lnkProjet.Size = new System.Drawing.Size(484, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lnkProjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkProjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkProjet.TabIndex = 4003;
            this.m_lnkProjet.TabStop = true;
            this.m_lnkProjet.Text = "[Projet.Libelle]";
            this.m_lnkProjet.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkProjet_LinkClicked);
            // 
            // m_chkTemplate
            // 
            this.m_chkTemplate.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkTemplate, "UseAsTemplate");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_chkTemplate, true);
            this.m_chkTemplate.Location = new System.Drawing.Point(19, 31);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkTemplate, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkTemplate, "");
            this.m_chkTemplate.Name = "m_chkTemplate";
            this.m_chkTemplate.Size = new System.Drawing.Size(134, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkTemplate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkTemplate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkTemplate.TabIndex = 4004;
            this.m_chkTemplate.Text = "Use as template|20642";
            this.m_chkTemplate.UseVisualStyleBackColor = true;
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
            this.m_tabControl.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_tabControl, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_tabControl, false);
            this.m_tabControl.Location = new System.Drawing.Point(8, 114);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.tabPage1;
            this.m_tabControl.Size = new System.Drawing.Size(822, 417);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabControl.TabIndex = 4004;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1});
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_wndListeBesoins);
            this.m_extLinkField.SetLinkField(this.tabPage1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.tabPage1, false);
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tabPage1, "");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(806, 376);
            this.m_extStyle.SetStyleBackColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage1.TabIndex = 10;
            this.tabPage1.Title = "Detail|20595";
            // 
            // m_wndListeBesoins
            // 
            this.m_wndListeBesoins.BackColor = System.Drawing.Color.White;
            this.m_wndListeBesoins.CurrentItemIndex = null;
            this.m_wndListeBesoins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeBesoins.Items = new sc2i.win32.common.customizableList.CCustomizableListItem[0];
            this.m_extLinkField.SetLinkField(this.m_wndListeBesoins, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_wndListeBesoins, false);
            this.m_wndListeBesoins.Location = new System.Drawing.Point(0, 0);
            this.m_wndListeBesoins.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeBesoins, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_wndListeBesoins, "");
            this.m_wndListeBesoins.Name = "m_wndListeBesoins";
            this.m_wndListeBesoins.Size = new System.Drawing.Size(806, 376);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeBesoins, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeBesoins, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeBesoins.TabIndex = 0;
            // 
            // CFormEditionPhaseSpecifications
            // 
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionPhaseSpecifications";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Load += new System.EventHandler(this.CFormEditionPhaseSpecifications_Load);
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
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CPhaseSpecifications PhaseSpecifications
		{
			get
			{
				return (CPhaseSpecifications)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
			AffecterTitre(I.T( "Needs specifications @1|20594", PhaseSpecifications.Libelle));
            m_wndListeBesoins.Init(PhaseSpecifications);
            m_lnkProjet.Visible = PhaseSpecifications.Projet != null;
            m_chkTemplate.Visible = PhaseSpecifications.Projet == null;
			return result;
		}
		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = CResultAErreur.True;
            result = m_wndListeBesoins.MajChamps();
            return base.MAJ_Champs();
        }

        private void m_btnAddBesoin_LinkClicked(object sender, EventArgs e)
        {
            if (PhaseSpecifications != null && m_gestionnaireModeEdition.ModeEdition)
            {
                CBesoin besoin = new CBesoin(PhaseSpecifications.ContexteDonnee);
                besoin.CreateNewInCurrentContexte();
                besoin.PhaseSpecifications = PhaseSpecifications;
                CItemBesoin itemParent = null;
                if (m_wndListeBesoins.Items.Length > 0)
                {
                    itemParent = m_wndListeBesoins.Items[m_wndListeBesoins.Items.Length - 1] as CItemBesoin;
                    if (itemParent != null && itemParent.Besoin != null)
                        besoin.BesoinParent = itemParent.Besoin.BesoinParent;
                }
                CItemBesoin item = new CItemBesoin(besoin, itemParent);
                m_wndListeBesoins.AddItem(item, true);
                m_wndListeBesoins.CurrentItemIndex = item.Index;
            }
        }

        private void m_pictureMap_Click(object sender, EventArgs e)
        {
            CFormMapBesoinsPopup.Show(this, PhaseSpecifications);
        }

        private void m_lnkProjet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (PhaseSpecifications.Projet != null && Navigateur != null)
            {
                CObjetDonnee objet = PhaseSpecifications.Projet.GetObjetInContexte(CSc2iWin32DataClient.ContexteCourant);
                Navigateur.EditeElement(PhaseSpecifications.Projet, false, "");
            }
        }

        private void CFormEditionPhaseSpecifications_Load(object sender, EventArgs e)
        {
        }

        private void m_picExtraireListe_Click(object sender, EventArgs e)
        {
            CFormListeExtraite.ShowListe(
                PhaseSpecifications.Libelle,
                PhaseSpecifications.Besoins,
                null,
                "PHASE_SPECS");
        }
	}
}

