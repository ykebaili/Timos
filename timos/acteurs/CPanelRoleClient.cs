using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using timos.data;
using timos.acteurs;

using sc2i.common;
using sc2i.multitiers.client;
using sc2i.workflow;
using sc2i.data;
using sc2i.win32.common;
using sc2i.win32.data.navigation;

namespace timos
{
	public class CPanelRoleClient : CPanelRole
	{
		#region Designer generated code
		private System.Windows.Forms.PictureBox m_imageCle;
		private System.Windows.Forms.Label m_lblId;
		private System.Windows.Forms.Panel m_panelId;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn1;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn2;
		protected sc2i.win32.common.CExtStyle m_ExtStyle;
		private CPanelListeSpeedStandard m_panelListeContrats;
		private sc2i.win32.common.C2iTabControl m_tabControl;
		private Crownwood.Magic.Controls.TabPage m_pageContrats;
		private sc2i.win32.common.CGestionnaireTabControl m_gestionnaireTabControl;
		private Crownwood.Magic.Controls.TabPage m_pageTickets;
		private CPanelListeSpeedStandard m_panelListeTickets;
		private CExtModulesAssociator m_extModulesAssociator;
		private System.ComponentModel.IContainer components = null;

		

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

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPanelRoleClient));
			sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
			sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
			this.m_imageCle = new System.Windows.Forms.PictureBox();
			this.m_lblId = new System.Windows.Forms.Label();
			this.listViewAutoFilledColumn2 = new sc2i.win32.common.ListViewAutoFilledColumn();
			this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
			this.m_panelId = new System.Windows.Forms.Panel();
			this.m_ExtStyle = new sc2i.win32.common.CExtStyle();
			this.m_panelListeContrats = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
			this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
			this.m_pageTickets = new Crownwood.Magic.Controls.TabPage();
			this.m_panelListeTickets = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
			this.m_pageContrats = new Crownwood.Magic.Controls.TabPage();
			this.m_gestionnaireTabControl = new sc2i.win32.common.CGestionnaireTabControl();
			this.m_extModulesAssociator = new timos.CExtModulesAssociator();
			((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
			this.m_panelId.SuspendLayout();
			this.m_tabControl.SuspendLayout();
			this.m_pageTickets.SuspendLayout();
			this.m_pageContrats.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gestionnaireModeEdition
			// 
			this.m_gestionnaireModeEdition.ModeEditionChanged += new System.EventHandler(this.m_gestionnaireModeEdition_ModeEditionChanged);
			// 
			// m_imageCle
			// 
			this.m_imageCle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_imageCle.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_imageCle.Image = ((System.Drawing.Image)(resources.GetObject("m_imageCle.Image")));
			this.m_extLinkField.SetLinkField(this.m_imageCle, "");
			this.m_imageCle.Location = new System.Drawing.Point(46, 4);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_imageCle, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this.m_imageCle, "");
			this.m_imageCle.Name = "m_imageCle";
			this.m_imageCle.Size = new System.Drawing.Size(16, 15);
			this.m_imageCle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.m_ExtStyle.SetStyleBackColor(this.m_imageCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_ExtStyle.SetStyleForeColor(this.m_imageCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_imageCle.TabIndex = 4002;
			this.m_imageCle.TabStop = false;
			this.m_imageCle.Click += new System.EventHandler(this.m_imageCle_Click);
			// 
			// m_lblId
			// 
			this.m_lblId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_extLinkField.SetLinkField(this.m_lblId, "Id");
			this.m_lblId.Location = new System.Drawing.Point(-2, 4);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblId, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this.m_lblId, "");
			this.m_lblId.Name = "m_lblId";
			this.m_lblId.Size = new System.Drawing.Size(48, 16);
			this.m_ExtStyle.SetStyleBackColor(this.m_lblId, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_ExtStyle.SetStyleForeColor(this.m_lblId, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_lblId.TabIndex = 4003;
			this.m_lblId.Text = "[Id]";
			this.m_lblId.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.m_lblId.Visible = false;
			// 
			// listViewAutoFilledColumn2
			// 
			this.listViewAutoFilledColumn2.Field = "Libelle";
			this.listViewAutoFilledColumn2.PrecisionWidth = 0;
			this.listViewAutoFilledColumn2.ProportionnalSize = false;
            this.listViewAutoFilledColumn2.Text = "Label|50";
			this.listViewAutoFilledColumn2.Visible = true;
			this.listViewAutoFilledColumn2.Width = 300;
			// 
			// listViewAutoFilledColumn1
			// 
			this.listViewAutoFilledColumn1.Field = "Acteur.Nom";
			this.listViewAutoFilledColumn1.PrecisionWidth = 0;
			this.listViewAutoFilledColumn1.ProportionnalSize = false;
			this.listViewAutoFilledColumn1.Text = "Acteur";
			this.listViewAutoFilledColumn1.Visible = true;
			this.listViewAutoFilledColumn1.Width = 360;
			// 
			// m_panelId
			// 
			this.m_panelId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_panelId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
			this.m_panelId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_panelId.Controls.Add(this.m_lblId);
			this.m_panelId.Controls.Add(this.m_imageCle);
			this.m_panelId.ForeColor = System.Drawing.Color.Black;
			this.m_extLinkField.SetLinkField(this.m_panelId, "");
			this.m_panelId.Location = new System.Drawing.Point(541, 0);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelId, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this.m_panelId, "");
			this.m_panelId.Name = "m_panelId";
			this.m_panelId.Size = new System.Drawing.Size(64, 24);
			this.m_ExtStyle.SetStyleBackColor(this.m_panelId, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
			this.m_ExtStyle.SetStyleForeColor(this.m_panelId, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
			this.m_panelId.TabIndex = 4005;
			// 
			// m_panelListeContrats
			// 
			this.m_panelListeContrats.AllowArbre = false;
			glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
			glColumn1.BackColor = System.Drawing.Color.Transparent;
			glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
			glColumn1.ForColor = System.Drawing.Color.Black;
			glColumn1.ImageIndex = -1;
			glColumn1.IsCheckColumn = false;
			glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
			glColumn1.Name = "colRessourceLibelle";
			glColumn1.Propriete = "Libelle";
			glColumn1.Text = "Label|50";
			glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
			glColumn1.Width = 100;
			this.m_panelListeContrats.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1});
			this.m_panelListeContrats.ContexteUtilisation = "";
			this.m_panelListeContrats.ControlFiltreStandard = null;
			this.m_panelListeContrats.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_panelListeContrats.ElementSelectionne = null;
			this.m_panelListeContrats.EnableCustomisation = true;
			this.m_panelListeContrats.FiltreDeBase = null;
			this.m_panelListeContrats.FiltreDeBaseEnAjout = false;
			this.m_panelListeContrats.FiltrePrefere = null;
			this.m_panelListeContrats.FiltreRapide = null;
			this.m_extLinkField.SetLinkField(this.m_panelListeContrats, "");
			this.m_panelListeContrats.ListeObjets = null;
			this.m_panelListeContrats.Location = new System.Drawing.Point(0, 0);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelListeContrats, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
			this.m_panelListeContrats.ModeQuickSearch = false;
			this.m_panelListeContrats.ModeSelection = false;
			this.m_extModulesAssociator.SetModules(this.m_panelListeContrats, "");
			this.m_panelListeContrats.MultiSelect = false;
			this.m_panelListeContrats.Name = "m_panelListeContrats";
			this.m_panelListeContrats.Navigateur = null;
			this.m_panelListeContrats.ProprieteObjetAEditer = null;
			this.m_panelListeContrats.QuickSearchText = "";
			this.m_panelListeContrats.Size = new System.Drawing.Size(608, 199);
			this.m_ExtStyle.SetStyleBackColor(this.m_panelListeContrats, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_ExtStyle.SetStyleForeColor(this.m_panelListeContrats, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_panelListeContrats.TabIndex = 4004;
			this.m_panelListeContrats.TrierAuClicSurEnteteColonne = true;
			// 
			// m_tabControl
			// 
			this.m_tabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
			this.m_tabControl.BoldSelectedPage = true;
			this.m_tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_tabControl.IDEPixelArea = false;
			this.m_extLinkField.SetLinkField(this.m_tabControl, "");
			this.m_tabControl.Location = new System.Drawing.Point(0, 0);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
			this.m_tabControl.Name = "m_tabControl";
			this.m_tabControl.Ombre = false;
			this.m_tabControl.PositionTop = true;
			this.m_tabControl.SelectedIndex = 0;
			this.m_tabControl.SelectedTab = this.m_pageContrats;
			this.m_tabControl.Size = new System.Drawing.Size(608, 224);
			this.m_ExtStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_ExtStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_tabControl.TabIndex = 4006;
			this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageContrats,
            this.m_pageTickets});
			// 
			// m_pageTickets
			// 
			this.m_pageTickets.Controls.Add(this.m_panelListeTickets);
			this.m_extLinkField.SetLinkField(this.m_pageTickets, "");
			this.m_pageTickets.Location = new System.Drawing.Point(0, 25);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageTickets, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this.m_pageTickets, "AINTER_CORR");
			this.m_pageTickets.Name = "m_pageTickets";
			this.m_pageTickets.Selected = false;
			this.m_pageTickets.Size = new System.Drawing.Size(608, 199);
			this.m_ExtStyle.SetStyleBackColor(this.m_pageTickets, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_ExtStyle.SetStyleForeColor(this.m_pageTickets, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_pageTickets.TabIndex = 11;
			this.m_pageTickets.Title = "Related Tickets|659";
			// 
			// m_panelListeTickets
			// 
			this.m_panelListeTickets.AllowArbre = false;
			glColumn2.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn2.ActiveControlItems")));
			glColumn2.BackColor = System.Drawing.Color.Transparent;
			glColumn2.ControlType = sc2i.win32.common.ColumnControlTypes.None;
			glColumn2.ForColor = System.Drawing.Color.Black;
			glColumn2.ImageIndex = -1;
			glColumn2.IsCheckColumn = false;
			glColumn2.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
			glColumn2.Name = "colRessourceLibelle";
			glColumn2.Propriete = "Libelle";
			glColumn2.Text = "Label|50";
			glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
			glColumn2.Width = 100;
			this.m_panelListeTickets.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn2});
			this.m_panelListeTickets.ContexteUtilisation = "";
			this.m_panelListeTickets.ControlFiltreStandard = null;
			this.m_panelListeTickets.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_panelListeTickets.ElementSelectionne = null;
			this.m_panelListeTickets.EnableCustomisation = true;
			this.m_panelListeTickets.FiltreDeBase = null;
			this.m_panelListeTickets.FiltreDeBaseEnAjout = false;
			this.m_panelListeTickets.FiltrePrefere = null;
			this.m_panelListeTickets.FiltreRapide = null;
			this.m_extLinkField.SetLinkField(this.m_panelListeTickets, "");
			this.m_panelListeTickets.ListeObjets = null;
			this.m_panelListeTickets.Location = new System.Drawing.Point(0, 0);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelListeTickets, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
			this.m_panelListeTickets.ModeQuickSearch = false;
			this.m_panelListeTickets.ModeSelection = false;
			this.m_extModulesAssociator.SetModules(this.m_panelListeTickets, "");
			this.m_panelListeTickets.MultiSelect = false;
			this.m_panelListeTickets.Name = "m_panelListeTickets";
			this.m_panelListeTickets.Navigateur = null;
			this.m_panelListeTickets.ProprieteObjetAEditer = null;
			this.m_panelListeTickets.QuickSearchText = "";
			this.m_panelListeTickets.Size = new System.Drawing.Size(608, 199);
			this.m_ExtStyle.SetStyleBackColor(this.m_panelListeTickets, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_ExtStyle.SetStyleForeColor(this.m_panelListeTickets, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_panelListeTickets.TabIndex = 4005;
			this.m_panelListeTickets.TrierAuClicSurEnteteColonne = true;
			// 
			// m_pageContrats
			// 
			this.m_pageContrats.Controls.Add(this.m_panelListeContrats);
			this.m_extLinkField.SetLinkField(this.m_pageContrats, "");
			this.m_pageContrats.Location = new System.Drawing.Point(0, 25);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageContrats, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this.m_pageContrats, "");
			this.m_pageContrats.Name = "m_pageContrats";
			this.m_pageContrats.Size = new System.Drawing.Size(608, 199);
			this.m_ExtStyle.SetStyleBackColor(this.m_pageContrats, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_ExtStyle.SetStyleForeColor(this.m_pageContrats, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_pageContrats.TabIndex = 10;
			this.m_pageContrats.Title = "Contracts|640";
			// 
			// m_gestionnaireTabControl
			// 
			this.m_gestionnaireTabControl.TabControl = this.m_tabControl;
			this.m_gestionnaireTabControl.OnInitPage += new sc2i.win32.common.EventOnPageHandler(this.m_gestionnaireTabControl_OnInitPage);
			this.m_gestionnaireTabControl.OnMajChampsPage += new sc2i.win32.common.EventOnPageHandler(this.m_gestionnaireTabControl_OnMajChampsPage);
			// 
			// CPanelRoleClient
			// 
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
			this.Controls.Add(this.m_panelId);
			this.Controls.Add(this.m_tabControl);
			this.ForeColor = System.Drawing.Color.Black;
			this.m_extLinkField.SetLinkField(this, "");
			this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this, "");
			this.Name = "CPanelRoleClient";
			this.Size = new System.Drawing.Size(608, 224);
			this.m_ExtStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
			this.m_ExtStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
			this.Load += new System.EventHandler(this.CPanelRoleUtilisateur_Load);
			((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
			this.m_panelId.ResumeLayout(false);
			this.m_panelId.PerformLayout();
			this.m_tabControl.ResumeLayout(false);
			this.m_tabControl.PerformLayout();
			this.m_pageTickets.ResumeLayout(false);
			this.m_pageContrats.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public CPanelRoleClient(CDonneesActeurClient Client)
			: base(Client)
		{
			InitializeComponent();
			m_extModulesAssociator.AppliquerConfiguration(CTimosApp.ConfigurationModules);
		}

		/// /////////// /////////// /////////// /////////// /////////// ////////
		private CDonneesActeurClient Client
		{
			get
			{
				return (CDonneesActeurClient)ObjetEdite;
			}
		}

		/// /////////// /////////// /////////// /////////// /////////// ////////
		private void CPanelRoleUtilisateur_Load(object sender, System.EventArgs e)
		{
			InitChamps();

			m_gestionnaireTabControl.ForceInitPageActive();

			

		}

		/// /////////// /////////// /////////// /////////// /////////// ////////
		private void m_gestionnaireModeEdition_ModeEditionChanged(object sender, System.EventArgs e)
		{
			
		}		

		/// /////////// /////////// /////////// /////////// /////////// ////////
		public override CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = CResultAErreur.True;
			if ( ObjetEdite == null )
				return result;
			result = base.MAJ_Champs();
			return result;
		}

		private void m_imageCle_Click(object sender, System.EventArgs e)
		{
			m_lblId.Visible = !m_lblId.Visible;
		}

		//-------------------------------------------------------------------------
		public override CRoleActeur RoleAssocie
		{
			get
			{
				return CRoleActeur.GetRole(CDonneesActeurClient.c_codeRole);
			}
		}



		private CResultAErreur m_gestionnaireTabControl_OnInitPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			using (CWaitCursor waiter = new CWaitCursor())
			{
				if(page == m_pageContrats)
				{
					//Initialisation des contrats
					m_panelListeContrats.InitFromListeObjets(
					Client.Contrats,
					typeof(CContrat),
					typeof(CFormEditionContrat),
					Client,
					"Client");
				}
				else if (page == m_pageTickets)
				{
					//Initialisation des Tickets
					m_panelListeTickets.InitFromListeObjets(
					Client.Tickets,
					typeof(CTicket),
					typeof(CFormEditionTicket),
					Client,
					"Client");
				}
			}

			return result;
		}
		private CResultAErreur m_gestionnaireTabControl_OnMajChampsPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			if (page == m_pageContrats)
			{ 
			}

			return result;
		}


	}
}

