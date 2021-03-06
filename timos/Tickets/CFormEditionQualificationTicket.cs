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
using sc2i.win32.data.dynamic;

using timos.data;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CQualificationTicket))]
	public class CFormEditionQualificationTicket : CFormEditionStdTimos, IFormNavigable
	{
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
        private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
		private Label m_lblLibelle;
		private C2iTabControl m_TabControl;
        private CArbreObjetHierarchique m_ArbreHierarchique;
        private Label m_lblHerite;
        private Crownwood.Magic.Controls.TabPage pageQualifFils;
        private CPanelListeSpeedStandard m_PanelQualifFils;
		private C2iLink m_lnkParent;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionQualificationTicket()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
        public CFormEditionQualificationTicket(CQualificationTicket site)
            : base(site)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
        public CFormEditionQualificationTicket(CQualificationTicket site, CListeObjetsDonnees liste)
            : base(site, liste)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		/// <summary>
		/// Nettoyage des ressources utilis�es.
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
		/// M�thode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette m�thode avec l'�diteur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionQualificationTicket));
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_ArbreHierarchique = new CArbreObjetHierarchique();
            this.m_lnkParent = new sc2i.win32.common.C2iLink(this.components);
            this.m_lblHerite = new System.Windows.Forms.Label();
            this.m_lblLibelle = new System.Windows.Forms.Label();
            this.m_TabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.pageQualifFils = new Crownwood.Magic.Controls.TabPage();
            this.m_PanelQualifFils = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.c2iPanelOmbre4.SuspendLayout();
            this.m_TabControl.SuspendLayout();
            this.pageQualifFils.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(668, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4002;
            this.label1.Text = "Site type label:|170";
            // 
            // m_txtLibelle
            // 
            this.m_txtLibelle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_txtLibelle.Location = new System.Drawing.Point(137, 104);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(323, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Label]|30324";
            // 
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.m_ArbreHierarchique);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.Controls.Add(this.m_lnkParent);
            this.c2iPanelOmbre4.Controls.Add(this.m_lblHerite);
            this.c2iPanelOmbre4.Controls.Add(this.m_lblLibelle);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(12, 43);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(592, 178);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // m_ArbreHierarchique
            // 
            this.m_ArbreHierarchique.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ArbreHierarchique.AutoriseReaffectation = true;
            this.m_ArbreHierarchique.BackColor = System.Drawing.Color.White;
            this.m_extLinkField.SetLinkField(this.m_ArbreHierarchique, "");
            this.m_ArbreHierarchique.Location = new System.Drawing.Point(3, 3);
            this.m_ArbreHierarchique.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_ArbreHierarchique, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_ArbreHierarchique.Name = "m_ArbreHierarchique";
            this.m_ArbreHierarchique.Size = new System.Drawing.Size(570, 91);
            this.m_extStyle.SetStyleBackColor(this.m_ArbreHierarchique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_ArbreHierarchique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ArbreHierarchique.TabIndex = 4007;
            // 
            // m_lnkParent
            // 
            this.m_lnkParent.AutoSize = true;
            this.m_lnkParent.ClickEnabled = true;
            this.m_lnkParent.ColorLabel = System.Drawing.SystemColors.ControlText;
            this.m_lnkParent.ColorLinkDisabled = System.Drawing.Color.Blue;
            this.m_lnkParent.ColorLinkEnabled = System.Drawing.Color.Blue;
            this.m_lnkParent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkParent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.m_lnkParent.ForeColor = System.Drawing.Color.Blue;
            this.m_extLinkField.SetLinkField(this.m_lnkParent, "");
            this.m_lnkParent.Location = new System.Drawing.Point(134, 131);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkParent, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkParent.Name = "m_lnkParent";
            this.m_lnkParent.Size = new System.Drawing.Size(38, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkParent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkParent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkParent.TabIndex = 4009;
            this.m_lnkParent.Text = "Parent";
            this.m_lnkParent.LinkClicked += new System.EventHandler(this.m_lnkParent_LinkClicked);
            // 
            // m_lblHerite
            // 
            this.m_lblHerite.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lblHerite, "");
            this.m_lblHerite.Location = new System.Drawing.Point(10, 131);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblHerite, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblHerite.Name = "m_lblHerite";
            this.m_lblHerite.Size = new System.Drawing.Size(85, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblHerite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblHerite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblHerite.TabIndex = 4008;
            this.m_lblHerite.Text = "Inherit from|478 :";
            // 
            // m_lblLibelle
            // 
            this.m_lblLibelle.AutoSize = true;
            this.m_lblLibelle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_lblLibelle.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_lblLibelle, "");
            this.m_lblLibelle.Location = new System.Drawing.Point(10, 107);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblLibelle, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblLibelle.Name = "m_lblLibelle";
            this.m_lblLibelle.Size = new System.Drawing.Size(114, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_lblLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTexteFenetre);
            this.m_lblLibelle.TabIndex = 4005;
            this.m_lblLibelle.Text = "Qualification Label|477";
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
            this.m_TabControl.ForeColor = System.Drawing.Color.Black;
            this.m_TabControl.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_TabControl, "");
            this.m_TabControl.Location = new System.Drawing.Point(12, 227);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_TabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_TabControl.Name = "m_TabControl";
            this.m_TabControl.Ombre = true;
            this.m_TabControl.PositionTop = true;
            this.m_TabControl.SelectedIndex = 0;
            this.m_TabControl.SelectedTab = this.pageQualifFils;
            this.m_TabControl.Size = new System.Drawing.Size(656, 304);
            this.m_extStyle.SetStyleBackColor(this.m_TabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_TabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_TabControl.TabIndex = 4004;
            this.m_TabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.pageQualifFils});
            this.m_TabControl.TextColor = System.Drawing.Color.Black;
            // 
            // pageQualifFils
            // 
            this.pageQualifFils.Controls.Add(this.m_PanelQualifFils);
            this.m_extLinkField.SetLinkField(this.pageQualifFils, "");
            this.pageQualifFils.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pageQualifFils, sc2i.win32.common.TypeModeEdition.Autonome);
            this.pageQualifFils.Name = "pageQualifFils";
            this.pageQualifFils.Size = new System.Drawing.Size(640, 263);
            this.m_extStyle.SetStyleBackColor(this.pageQualifFils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pageQualifFils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pageQualifFils.TabIndex = 10;
            this.pageQualifFils.Title = "Child Qualifications|476";
            // 
            // m_PanelQualifFils
            // 
            this.m_PanelQualifFils.AllowArbre = true;
            this.m_PanelQualifFils.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "Libelle";
            glColumn1.Propriete = "Libelle";
            glColumn1.Text = "Label|50";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 300;
            this.m_PanelQualifFils.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1});
            this.m_PanelQualifFils.ContexteUtilisation = "";
            this.m_PanelQualifFils.ControlFiltreStandard = null;
            this.m_PanelQualifFils.EnableCustomisation = true;
            this.m_PanelQualifFils.FiltreDeBase = null;
            this.m_PanelQualifFils.FiltreDeBaseEnAjout = false;
            this.m_PanelQualifFils.FiltrePrefere = null;
            this.m_PanelQualifFils.FiltreRapide = null;
            this.m_extLinkField.SetLinkField(this.m_PanelQualifFils, "");
            this.m_PanelQualifFils.ListeObjets = null;
            this.m_PanelQualifFils.Location = new System.Drawing.Point(3, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_PanelQualifFils, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_PanelQualifFils.ModeQuickSearch = false;
            this.m_PanelQualifFils.ModeSelection = false;
            this.m_PanelQualifFils.MultiSelect = false;
            this.m_PanelQualifFils.Name = "m_PanelQualifFils";
            this.m_PanelQualifFils.Navigateur = null;
            this.m_PanelQualifFils.ProprieteObjetAEditer = null;
            this.m_PanelQualifFils.QuickSearchText = "";
            this.m_PanelQualifFils.Size = new System.Drawing.Size(634, 257);
            this.m_extStyle.SetStyleBackColor(this.m_PanelQualifFils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_PanelQualifFils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_PanelQualifFils.TabIndex = 0;
            // 
            // CFormEditionQualificationTicket
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(668, 537);
            this.Controls.Add(this.m_TabControl);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CFormEditionQualificationTicket";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre4, 0);
            this.Controls.SetChildIndex(this.m_TabControl, 0);
            this.c2iPanelOmbre4.ResumeLayout(false);
            this.c2iPanelOmbre4.PerformLayout();
            this.m_TabControl.ResumeLayout(false);
            this.m_TabControl.PerformLayout();
            this.pageQualifFils.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CQualificationTicket QualifTicket
		{
			get { return (CQualificationTicket)ObjetEdite; }
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();

			AffecterTitre(I.T("Qualification|464")+": " + QualifTicket.Libelle);

			//On met � jour les �l�ments
			m_extLinkField.FillObjetFromDialog(QualifTicket);

            // Initialise l'affichage de l'arbre hi�rarchique
            m_ArbreHierarchique.AfficheHierarchie(QualifTicket);
            

			//On identifi le parent
            if (QualifTicket.QualificationTicketParent != null)
			{
				m_lnkParent.ClickEnabled = true;
                m_lnkParent.Text = QualifTicket.QualificationTicketParent.Libelle;
			}
			else
			{
				m_lnkParent.ClickEnabled = false;
				m_lnkParent.Text = I.T( "None|148");
			}

            m_PanelQualifFils.InitFromListeObjets(
                QualifTicket.QualificationTicketFils,
                typeof(CQualificationTicket),
                typeof(CFormEditionQualificationTicket),
                QualifTicket,
                "QualificationTicketParent");

			
          	return result;
		}


		//---------------------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();
            if (!result) return result;


            m_extLinkField.FillDialogFromObjet(QualifTicket);

            return result;
        }


		private void m_lnkParent_LinkClicked(object sender, EventArgs e)
		{
			if (m_lnkParent.Text != "" && QualifTicket.ObjetParent != null)
			{
				IFormNavigable iformnav = (IFormNavigable)QualifTicket.ObjetParent;
				CTimosApp.Navigateur.AffichePage(iformnav);
			}
		}



	}
}

