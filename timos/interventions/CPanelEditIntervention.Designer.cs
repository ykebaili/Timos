using sc2i.common;

namespace timos.interventions
{
	partial class CPanelEditIntervention
	{
		/// <summary> 
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Nettoyage des ressources utilisées.
		/// </summary>
		/// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
				if (m_listeControles.Count != 0)
				{
					foreach (CControleSaisiesOperations ctrl in m_listeControles)
						ctrl.Dispose();
				}
				m_listeControles.Clear();
			}
			base.Dispose(disposing);
		}

		#region Code généré par le Concepteur de composants

		/// <summary> 
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.m_extModulesAssociator = new timos.CExtModulesAssociator();
            this.c2iPanelOmbre1 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_panelLienTicket = new System.Windows.Forms.Panel();
            this.m_lnkTicket = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.m_selectSite = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.lbl_inter = new System.Windows.Forms.Label();
            this.m_lnkChangeElement = new System.Windows.Forms.LinkLabel();
            this.m_cmbTypeIntervention = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.m_lnkElementAIntervention = new System.Windows.Forms.LinkLabel();
            this.m_lnkQuiAppeler = new System.Windows.Forms.LinkLabel();
            this.c2iTextBox1 = new sc2i.win32.common.C2iTextBox();
            this.lbl_label = new System.Windows.Forms.Label();
            this.lbl_interon = new System.Windows.Forms.Label();
            this.m_panelDescriptionTicket = new System.Windows.Forms.Panel();
            this.m_lblDescriptionTicket = new System.Windows.Forms.Label();
            this.lbl_tkt = new System.Windows.Forms.Label();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.tb_planification = new Crownwood.Magic.Controls.TabPage();
            this.m_panelPlanification = new sc2i.win32.common.C2iPanel(this.components);
            this.m_wndDureePrevue = new sc2i.win32.common.C2iTextBoxNumeriqueAvecUnite();
            this.label15 = new System.Windows.Forms.Label();
            this.m_lblDureeprevue = new System.Windows.Forms.Label();
            this.m_panelFraction = new System.Windows.Forms.Panel();
            this.m_dtFin = new sc2i.win32.common.C2iDateTimePicker();
            this.m_dtDebut = new sc2i.win32.common.C2iDateTimePicker();
            this.lbl_finplanifiee = new System.Windows.Forms.Label();
            this.lbl_debutplanifie = new System.Windows.Forms.Label();
            this.m_btnDeletePlanification = new sc2i.win32.common.CWndLinkStd();
            this.m_btnAddPlanification = new sc2i.win32.common.CWndLinkStd();
            this.m_wndListeFractions = new sc2i.win32.common.ListViewAutoFilled();
            this.col_start = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.col_end = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.m_txtSelectPlanificateur = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.lbl_managepar = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gb_preplan = new System.Windows.Forms.GroupBox();
            this.m_lnkPlanningGrid = new System.Windows.Forms.LinkLabel();
            this.m_panelPreplanification = new sc2i.win32.common.C2iPanel(this.components);
            this.m_dtDebutPreplanifier = new sc2i.win32.common.C2iDateTimeExPicker();
            this.lbl_etle = new System.Windows.Forms.Label();
            this.m_dtFinPreplanification = new sc2i.win32.common.C2iDateTimeExPicker();
            this.lbl_planif = new System.Windows.Forms.Label();
            this.m_txtSelectPreplanificateur = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.lbl_gereepar = new System.Windows.Forms.Label();
            this.tb_operations = new Crownwood.Magic.Controls.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.m_lstListeOperations = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.c2iPanel3 = new sc2i.win32.common.C2iPanel(this.components);
            this.m_lnkAjouterListeOp = new sc2i.win32.common.CWndLinkStd();
            this.m_txtSelectListeOperation = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_panelRemoveBtn = new sc2i.win32.common.C2iPanel(this.components);
            this.m_lnkSupprimerListeOp = new sc2i.win32.common.CWndLinkStd();
            this.label1 = new System.Windows.Forms.Label();
            this.m_panelOperationsPrev = new sc2i.win32.common.C2iPanel(this.components);
            this.m_panelVersion = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtSelectVersionLiee = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_lnkEditerModificationsPrevisionnelles = new System.Windows.Forms.LinkLabel();
            this.m_panelEnteteOperationsPrev = new sc2i.win32.common.C2iPanel(this.components);
            this.m_panelInfosListeOp = new sc2i.win32.common.C2iPanel(this.components);
            this.m_lnkCreerOperationsDeListe = new System.Windows.Forms.LinkLabel();
            this.m_txtLabelListeOp = new sc2i.win32.common.C2iTextBox();
            this.m_lnkAddOperation = new System.Windows.Forms.LinkLabel();
            this.c2iPanel2 = new sc2i.win32.common.C2iPanel(this.components);
            this.m_txtDescriptionInter = new sc2i.win32.common.C2iTextBox();
            this.tb_checklist = new Crownwood.Magic.Controls.TabPage();
            this.m_panelCheckList = new timos.win32.composants.planning.CControleCheckListIntervention();
            this.tb_ressources = new Crownwood.Magic.Controls.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_panelIntervenants = new timos.interventions.CPanelAffecteIntervenants();
            this.label11 = new System.Windows.Forms.Label();
            this.m_panelRessourcesMaterielles = new sc2i.win32.common.C2iPanel(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.tb_realisation = new Crownwood.Magic.Controls.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.c2iPanel1 = new sc2i.win32.common.C2iPanel(this.components);
            this.m_panelCRs = new sc2i.win32.common.C2iPanel(this.components);
            this.m_panelEnteteRealisation = new sc2i.win32.common.C2iPanel(this.components);
            this.m_panelNavigation = new System.Windows.Forms.Panel();
            this.m_lnkPremierePage = new System.Windows.Forms.LinkLabel();
            this.m_lnkPrecedent = new System.Windows.Forms.LinkLabel();
            this.m_lnkSuivant = new System.Windows.Forms.LinkLabel();
            this.m_lnkDernierePage = new System.Windows.Forms.LinkLabel();
            this.m_lblPageSurNbPages = new System.Windows.Forms.Label();
            this.m_lnkAjouterCR = new System.Windows.Forms.LinkLabel();
            this.m_panelInfoGel = new timos.interventions.CPanelInfoGel();
            this.tb_fiche = new Crownwood.Magic.Controls.TabPage();
            this.m_panelChampsCustom = new sc2i.win32.data.dynamic.CPanelChampsCustom();
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_exLinkField = new sc2i.win32.common.CExtLinkField();
            this.m_exStyle = new sc2i.win32.common.CExtStyle();
            this.m_editeurFraction = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.m_imagesOnglets = new System.Windows.Forms.ImageList(this.components);
            this.m_gestionnaireEditionListeOp = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.m_extLinkListeOperations = new sc2i.win32.common.CExtLinkField();
            this.m_gestionnaireTabControl = new sc2i.win32.common.CGestionnaireTabControl();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txtNbOperateursPrévus = new sc2i.win32.common.C2iNumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtTauxHorairePrévu = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.c2iPanelOmbre1.SuspendLayout();
            this.m_panelLienTicket.SuspendLayout();
            this.m_panelDescriptionTicket.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.tb_planification.SuspendLayout();
            this.m_panelPlanification.SuspendLayout();
            this.m_panelFraction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gb_preplan.SuspendLayout();
            this.m_panelPreplanification.SuspendLayout();
            this.tb_operations.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.c2iPanel3.SuspendLayout();
            this.m_panelRemoveBtn.SuspendLayout();
            this.m_panelVersion.SuspendLayout();
            this.m_panelEnteteOperationsPrev.SuspendLayout();
            this.m_panelInfosListeOp.SuspendLayout();
            this.c2iPanel2.SuspendLayout();
            this.tb_checklist.SuspendLayout();
            this.tb_ressources.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tb_realisation.SuspendLayout();
            this.panel1.SuspendLayout();
            this.c2iPanel1.SuspendLayout();
            this.m_panelEnteteRealisation.SuspendLayout();
            this.m_panelNavigation.SuspendLayout();
            this.tb_fiche.SuspendLayout();
            this.SuspendLayout();
            // 
            // c2iPanelOmbre1
            // 
            this.c2iPanelOmbre1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre1.Controls.Add(this.m_panelLienTicket);
            this.c2iPanelOmbre1.Controls.Add(this.m_selectSite);
            this.c2iPanelOmbre1.Controls.Add(this.lbl_inter);
            this.c2iPanelOmbre1.Controls.Add(this.m_lnkChangeElement);
            this.c2iPanelOmbre1.Controls.Add(this.m_cmbTypeIntervention);
            this.c2iPanelOmbre1.Controls.Add(this.m_lnkElementAIntervention);
            this.c2iPanelOmbre1.Controls.Add(this.m_lnkQuiAppeler);
            this.c2iPanelOmbre1.Controls.Add(this.c2iTextBox1);
            this.c2iPanelOmbre1.Controls.Add(this.lbl_label);
            this.c2iPanelOmbre1.Controls.Add(this.lbl_interon);
            this.c2iPanelOmbre1.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkListeOperations.SetLinkField(this.c2iPanelOmbre1, "");
            this.m_exLinkField.SetLinkField(this.c2iPanelOmbre1, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.c2iPanelOmbre1, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.c2iPanelOmbre1, false);
            this.c2iPanelOmbre1.Location = new System.Drawing.Point(0, 0);
            this.c2iPanelOmbre1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre1, "");
            this.c2iPanelOmbre1.Name = "c2iPanelOmbre1";
            this.c2iPanelOmbre1.Size = new System.Drawing.Size(731, 75);
            this.m_exStyle.SetStyleBackColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_exStyle.SetStyleForeColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTexteFenetre);
            this.c2iPanelOmbre1.TabIndex = 0;
            // 
            // m_panelLienTicket
            // 
            this.m_panelLienTicket.Controls.Add(this.m_lnkTicket);
            this.m_panelLienTicket.Controls.Add(this.label2);
            this.m_extLinkListeOperations.SetLinkField(this.m_panelLienTicket, "");
            this.m_exLinkField.SetLinkField(this.m_panelLienTicket, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_panelLienTicket, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_panelLienTicket, false);
            this.m_panelLienTicket.Location = new System.Drawing.Point(333, 31);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelLienTicket, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelLienTicket, "");
            this.m_panelLienTicket.Name = "m_panelLienTicket";
            this.m_panelLienTicket.Size = new System.Drawing.Size(226, 21);
            this.m_exStyle.SetStyleBackColor(this.m_panelLienTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_panelLienTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelLienTicket.TabIndex = 4017;
            // 
            // m_lnkTicket
            // 
            this.m_extLinkListeOperations.SetLinkField(this.m_lnkTicket, "");
            this.m_exLinkField.SetLinkField(this.m_lnkTicket, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_lnkTicket, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_lnkTicket, false);
            this.m_lnkTicket.Location = new System.Drawing.Point(86, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkTicket, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkTicket, "");
            this.m_lnkTicket.Name = "m_lnkTicket";
            this.m_lnkTicket.Size = new System.Drawing.Size(133, 15);
            this.m_exStyle.SetStyleBackColor(this.m_lnkTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_lnkTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTicket.TabIndex = 11;
            this.m_lnkTicket.TabStop = true;
            this.m_lnkTicket.Text = "ticket number";
            this.m_lnkTicket.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTicket_LinkClicked);
            // 
            // label2
            // 
            this.m_extLinkListeOperations.SetLinkField(this.label2, "");
            this.m_exLinkField.SetLinkField(this.label2, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.label2, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.label2, false);
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.m_exStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 12;
            this.label2.Text = "Ticket|573";
            // 
            // m_selectSite
            // 
            this.m_selectSite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_selectSite.ElementSelectionne = null;
            this.m_selectSite.FonctionTextNull = null;
            this.m_selectSite.HasLink = true;
            this.m_selectSite.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_extLinkListeOperations.SetLinkField(this.m_selectSite, "");
            this.m_exLinkField.SetLinkField(this.m_selectSite, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_selectSite, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_selectSite, false);
            this.m_selectSite.Location = new System.Drawing.Point(401, 8);
            this.m_selectSite.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_selectSite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_selectSite, "");
            this.m_selectSite.Name = "m_selectSite";
            this.m_selectSite.SelectedObject = null;
            this.m_selectSite.Size = new System.Drawing.Size(308, 21);
            this.m_selectSite.SpecificImage = null;
            this.m_exStyle.SetStyleBackColor(this.m_selectSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_selectSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectSite.TabIndex = 4016;
            this.m_selectSite.TextNull = "";
            this.m_selectSite.ElementSelectionneChanged += new System.EventHandler(this.m_selectSite_ElementSelectionneChanged);
            // 
            // lbl_inter
            // 
            this.m_extLinkListeOperations.SetLinkField(this.lbl_inter, "");
            this.m_exLinkField.SetLinkField(this.lbl_inter, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.lbl_inter, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.lbl_inter, false);
            this.lbl_inter.Location = new System.Drawing.Point(6, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_inter, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.lbl_inter, "");
            this.lbl_inter.Name = "lbl_inter";
            this.lbl_inter.Size = new System.Drawing.Size(80, 18);
            this.m_exStyle.SetStyleBackColor(this.lbl_inter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.lbl_inter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_inter.TabIndex = 3;
            this.lbl_inter.Text = "Intervention|561";
            // 
            // m_lnkChangeElement
            // 
            this.m_lnkChangeElement.AutoSize = true;
            this.m_exLinkField.SetLinkField(this.m_lnkChangeElement, "");
            this.m_extLinkListeOperations.SetLinkField(this.m_lnkChangeElement, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_lnkChangeElement, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_lnkChangeElement, false);
            this.m_lnkChangeElement.Location = new System.Drawing.Point(676, 11);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkChangeElement, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkChangeElement, "");
            this.m_lnkChangeElement.Name = "m_lnkChangeElement";
            this.m_lnkChangeElement.Size = new System.Drawing.Size(16, 13);
            this.m_exStyle.SetStyleBackColor(this.m_lnkChangeElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_lnkChangeElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkChangeElement.TabIndex = 7;
            this.m_lnkChangeElement.TabStop = true;
            this.m_lnkChangeElement.Text = "...";
            this.m_lnkChangeElement.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkChangeElement_LinkClicked);
            // 
            // m_cmbTypeIntervention
            // 
            this.m_cmbTypeIntervention.ComportementLinkStd = true;
            this.m_cmbTypeIntervention.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTypeIntervention.ElementSelectionne = null;
            this.m_cmbTypeIntervention.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbTypeIntervention.FormattingEnabled = true;
            this.m_cmbTypeIntervention.IsLink = false;
            this.m_extLinkListeOperations.SetLinkField(this.m_cmbTypeIntervention, "");
            this.m_exLinkField.SetLinkField(this.m_cmbTypeIntervention, "");
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_cmbTypeIntervention, false);
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_cmbTypeIntervention, false);
            this.m_cmbTypeIntervention.LinkProperty = "";
            this.m_cmbTypeIntervention.ListDonnees = null;
            this.m_cmbTypeIntervention.Location = new System.Drawing.Point(92, 7);
            this.m_cmbTypeIntervention.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbTypeIntervention, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbTypeIntervention, "");
            this.m_cmbTypeIntervention.Name = "m_cmbTypeIntervention";
            this.m_cmbTypeIntervention.NullAutorise = false;
            this.m_cmbTypeIntervention.ProprieteAffichee = null;
            this.m_cmbTypeIntervention.ProprieteParentListeObjets = null;
            this.m_cmbTypeIntervention.SelectionneurParent = null;
            this.m_cmbTypeIntervention.Size = new System.Drawing.Size(235, 21);
            this.m_exStyle.SetStyleBackColor(this.m_cmbTypeIntervention, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_cmbTypeIntervention, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbTypeIntervention.TabIndex = 4;
            this.m_cmbTypeIntervention.TextNull = "(empty)";
            this.m_cmbTypeIntervention.Tri = true;
            this.m_cmbTypeIntervention.TypeFormEdition = null;
            this.m_cmbTypeIntervention.SelectionChangeCommitted += new System.EventHandler(this.m_cmbTypeIntervention_SelectionChangeCommitted);
            // 
            // m_lnkElementAIntervention
            // 
            this.m_lnkElementAIntervention.BackColor = System.Drawing.Color.White;
            this.m_lnkElementAIntervention.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_exLinkField.SetLinkField(this.m_lnkElementAIntervention, "");
            this.m_extLinkListeOperations.SetLinkField(this.m_lnkElementAIntervention, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_lnkElementAIntervention, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_lnkElementAIntervention, false);
            this.m_lnkElementAIntervention.Location = new System.Drawing.Point(401, 7);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkElementAIntervention, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkElementAIntervention, "");
            this.m_lnkElementAIntervention.Name = "m_lnkElementAIntervention";
            this.m_lnkElementAIntervention.Size = new System.Drawing.Size(263, 21);
            this.m_exStyle.SetStyleBackColor(this.m_lnkElementAIntervention, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_lnkElementAIntervention, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkElementAIntervention.TabIndex = 6;
            this.m_lnkElementAIntervention.TabStop = true;
            this.m_lnkElementAIntervention.Text = "linkLabel1";
            this.m_lnkElementAIntervention.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lnkElementAIntervention.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkElementAIntervention_LinkClicked);
            // 
            // m_lnkQuiAppeler
            // 
            this.m_lnkQuiAppeler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_exLinkField.SetLinkField(this.m_lnkQuiAppeler, "");
            this.m_extLinkListeOperations.SetLinkField(this.m_lnkQuiAppeler, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_lnkQuiAppeler, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_lnkQuiAppeler, false);
            this.m_lnkQuiAppeler.Location = new System.Drawing.Point(582, 35);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkQuiAppeler, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkQuiAppeler, "");
            this.m_lnkQuiAppeler.Name = "m_lnkQuiAppeler";
            this.m_lnkQuiAppeler.Size = new System.Drawing.Size(126, 18);
            this.m_exStyle.SetStyleBackColor(this.m_lnkQuiAppeler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_lnkQuiAppeler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkQuiAppeler.TabIndex = 8;
            this.m_lnkQuiAppeler.TabStop = true;
            this.m_lnkQuiAppeler.Text = "Contacts|536";
            this.m_lnkQuiAppeler.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkQuiAppeler_LinkClicked);
            // 
            // c2iTextBox1
            // 
            this.c2iTextBox1.EmptyText = "";
            this.m_exLinkField.SetLinkField(this.c2iTextBox1, "Libelle");
            this.m_extLinkListeOperations.SetLinkField(this.c2iTextBox1, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.c2iTextBox1, true);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.c2iTextBox1, false);
            this.c2iTextBox1.Location = new System.Drawing.Point(92, 33);
            this.c2iTextBox1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBox1, "");
            this.c2iTextBox1.Name = "c2iTextBox1";
            this.c2iTextBox1.Size = new System.Drawing.Size(235, 20);
            this.m_exStyle.SetStyleBackColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox1.TabIndex = 9;
            this.c2iTextBox1.Text = "[Libelle]";
            // 
            // lbl_label
            // 
            this.m_extLinkListeOperations.SetLinkField(this.lbl_label, "");
            this.m_exLinkField.SetLinkField(this.lbl_label, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.lbl_label, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.lbl_label, false);
            this.lbl_label.Location = new System.Drawing.Point(6, 34);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_label, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.lbl_label, "");
            this.lbl_label.Name = "lbl_label";
            this.lbl_label.Size = new System.Drawing.Size(55, 18);
            this.m_exStyle.SetStyleBackColor(this.lbl_label, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.lbl_label, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_label.TabIndex = 10;
            this.lbl_label.Text = "Label|50";
            // 
            // lbl_interon
            // 
            this.m_extLinkListeOperations.SetLinkField(this.lbl_interon, "");
            this.m_exLinkField.SetLinkField(this.lbl_interon, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.lbl_interon, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.lbl_interon, false);
            this.lbl_interon.Location = new System.Drawing.Point(337, 9);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_interon, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.lbl_interon, "");
            this.lbl_interon.Name = "lbl_interon";
            this.lbl_interon.Size = new System.Drawing.Size(58, 19);
            this.m_exStyle.SetStyleBackColor(this.lbl_interon, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.lbl_interon, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_interon.TabIndex = 5;
            this.lbl_interon.Text = "Site|175";
            // 
            // m_panelDescriptionTicket
            // 
            this.m_panelDescriptionTicket.Controls.Add(this.m_lblDescriptionTicket);
            this.m_panelDescriptionTicket.Controls.Add(this.lbl_tkt);
            this.m_panelDescriptionTicket.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkListeOperations.SetLinkField(this.m_panelDescriptionTicket, "");
            this.m_exLinkField.SetLinkField(this.m_panelDescriptionTicket, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_panelDescriptionTicket, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_panelDescriptionTicket, false);
            this.m_panelDescriptionTicket.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelDescriptionTicket, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelDescriptionTicket, "");
            this.m_panelDescriptionTicket.Name = "m_panelDescriptionTicket";
            this.m_panelDescriptionTicket.Size = new System.Drawing.Size(799, 66);
            this.m_exStyle.SetStyleBackColor(this.m_panelDescriptionTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_panelDescriptionTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelDescriptionTicket.TabIndex = 12;
            // 
            // m_lblDescriptionTicket
            // 
            this.m_lblDescriptionTicket.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblDescriptionTicket.BackColor = System.Drawing.Color.White;
            this.m_lblDescriptionTicket.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_extLinkListeOperations.SetLinkField(this.m_lblDescriptionTicket, "");
            this.m_exLinkField.SetLinkField(this.m_lblDescriptionTicket, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_lblDescriptionTicket, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_lblDescriptionTicket, false);
            this.m_lblDescriptionTicket.Location = new System.Drawing.Point(8, 20);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblDescriptionTicket, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblDescriptionTicket, "");
            this.m_lblDescriptionTicket.Name = "m_lblDescriptionTicket";
            this.m_lblDescriptionTicket.Size = new System.Drawing.Size(775, 45);
            this.m_exStyle.SetStyleBackColor(this.m_lblDescriptionTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_lblDescriptionTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblDescriptionTicket.TabIndex = 13;
            // 
            // lbl_tkt
            // 
            this.m_extLinkListeOperations.SetLinkField(this.lbl_tkt, "");
            this.m_exLinkField.SetLinkField(this.lbl_tkt, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.lbl_tkt, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.lbl_tkt, false);
            this.lbl_tkt.Location = new System.Drawing.Point(5, 5);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_tkt, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.lbl_tkt, "");
            this.lbl_tkt.Name = "lbl_tkt";
            this.lbl_tkt.Size = new System.Drawing.Size(202, 15);
            this.m_exStyle.SetStyleBackColor(this.lbl_tkt, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.lbl_tkt, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_tkt.TabIndex = 12;
            this.lbl_tkt.Text = "Ticket description|1255";
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
            this.m_extLinkListeOperations.SetLinkField(this.m_tabControl, "");
            this.m_exLinkField.SetLinkField(this.m_tabControl, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_tabControl, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_tabControl, false);
            this.m_tabControl.Location = new System.Drawing.Point(3, 81);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.tb_planification;
            this.m_tabControl.Size = new System.Drawing.Size(815, 439);
            this.m_exStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_exStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 1;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tb_planification,
            this.tb_operations,
            this.tb_checklist,
            this.tb_ressources,
            this.tb_realisation,
            this.tb_fiche});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            this.m_tabControl.SelectionChanged += new System.EventHandler(this.m_tabControl_SelectionChanged);
            // 
            // tb_planification
            // 
            this.tb_planification.Controls.Add(this.m_panelPlanification);
            this.tb_planification.Controls.Add(this.label8);
            this.tb_planification.Controls.Add(this.m_txtSelectPlanificateur);
            this.tb_planification.Controls.Add(this.lbl_managepar);
            this.tb_planification.Controls.Add(this.label6);
            this.tb_planification.Controls.Add(this.pictureBox1);
            this.tb_planification.Controls.Add(this.gb_preplan);
            this.m_exLinkField.SetLinkField(this.tb_planification, "");
            this.m_extLinkListeOperations.SetLinkField(this.tb_planification, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.tb_planification, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.tb_planification, false);
            this.tb_planification.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tb_planification, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tb_planification, "");
            this.tb_planification.Name = "tb_planification";
            this.tb_planification.Size = new System.Drawing.Size(799, 398);
            this.m_exStyle.SetStyleBackColor(this.tb_planification, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.tb_planification, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tb_planification.TabIndex = 10;
            this.tb_planification.Title = "Planning|563";
            // 
            // m_panelPlanification
            // 
            this.m_panelPlanification.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_panelPlanification.Controls.Add(this.m_txtTauxHorairePrévu);
            this.m_panelPlanification.Controls.Add(this.label5);
            this.m_panelPlanification.Controls.Add(this.m_txtNbOperateursPrévus);
            this.m_panelPlanification.Controls.Add(this.label4);
            this.m_panelPlanification.Controls.Add(this.m_wndDureePrevue);
            this.m_panelPlanification.Controls.Add(this.label15);
            this.m_panelPlanification.Controls.Add(this.m_lblDureeprevue);
            this.m_panelPlanification.Controls.Add(this.m_panelFraction);
            this.m_panelPlanification.Controls.Add(this.m_btnDeletePlanification);
            this.m_panelPlanification.Controls.Add(this.m_btnAddPlanification);
            this.m_panelPlanification.Controls.Add(this.m_wndListeFractions);
            this.m_extLinkListeOperations.SetLinkField(this.m_panelPlanification, "");
            this.m_exLinkField.SetLinkField(this.m_panelPlanification, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_panelPlanification, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_panelPlanification, false);
            this.m_panelPlanification.Location = new System.Drawing.Point(12, 112);
            this.m_panelPlanification.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelPlanification, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelPlanification, "");
            this.m_panelPlanification.Name = "m_panelPlanification";
            this.m_panelPlanification.Size = new System.Drawing.Size(666, 283);
            this.m_exStyle.SetStyleBackColor(this.m_panelPlanification, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_panelPlanification, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelPlanification.TabIndex = 14;
            // 
            // m_wndDureePrevue
            // 
            this.m_exLinkField.SetLinkField(this.m_wndDureePrevue, "");
            this.m_extLinkListeOperations.SetLinkField(this.m_wndDureePrevue, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_wndDureePrevue, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_wndDureePrevue, false);
            this.m_wndDureePrevue.Location = new System.Drawing.Point(420, 5);
            this.m_wndDureePrevue.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndDureePrevue, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_wndDureePrevue, "");
            this.m_wndDureePrevue.Name = "m_wndDureePrevue";
            this.m_wndDureePrevue.Size = new System.Drawing.Size(89, 21);
            this.m_exStyle.SetStyleBackColor(this.m_wndDureePrevue, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_wndDureePrevue, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndDureePrevue.TabIndex = 4014;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.m_extLinkListeOperations.SetLinkField(this.label15, "");
            this.m_exLinkField.SetLinkField(this.label15, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.label15, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.label15, false);
            this.label15.Location = new System.Drawing.Point(515, 9);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label15, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label15, "");
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(14, 13);
            this.m_exStyle.SetStyleBackColor(this.label15, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label15, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label15.TabIndex = 4013;
            this.label15.Text = "H";
            this.label15.Visible = false;
            // 
            // m_lblDureeprevue
            // 
            this.m_extLinkListeOperations.SetLinkField(this.m_lblDureeprevue, "");
            this.m_exLinkField.SetLinkField(this.m_lblDureeprevue, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_lblDureeprevue, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_lblDureeprevue, false);
            this.m_lblDureeprevue.Location = new System.Drawing.Point(268, 7);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblDureeprevue, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblDureeprevue, "");
            this.m_lblDureeprevue.Name = "m_lblDureeprevue";
            this.m_lblDureeprevue.Size = new System.Drawing.Size(153, 19);
            this.m_exStyle.SetStyleBackColor(this.m_lblDureeprevue, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_lblDureeprevue, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblDureeprevue.TabIndex = 4011;
            this.m_lblDureeprevue.Text = "Estimated duration|570";
            // 
            // m_panelFraction
            // 
            this.m_panelFraction.Controls.Add(this.m_dtFin);
            this.m_panelFraction.Controls.Add(this.m_dtDebut);
            this.m_panelFraction.Controls.Add(this.lbl_finplanifiee);
            this.m_panelFraction.Controls.Add(this.lbl_debutplanifie);
            this.m_extLinkListeOperations.SetLinkField(this.m_panelFraction, "");
            this.m_exLinkField.SetLinkField(this.m_panelFraction, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_panelFraction, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_panelFraction, false);
            this.m_panelFraction.Location = new System.Drawing.Point(271, 96);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelFraction, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelFraction, "");
            this.m_panelFraction.Name = "m_panelFraction";
            this.m_panelFraction.Size = new System.Drawing.Size(282, 114);
            this.m_exStyle.SetStyleBackColor(this.m_panelFraction, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_panelFraction, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelFraction.TabIndex = 4010;
            // 
            // m_dtFin
            // 
            this.m_dtFin.CustomFormat = "dd/MM/yyyy HH:mm";
            this.m_dtFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_extLinkListeOperations.SetLinkField(this.m_dtFin, "");
            this.m_exLinkField.SetLinkField(this.m_dtFin, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_dtFin, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_dtFin, false);
            this.m_dtFin.Location = new System.Drawing.Point(129, 29);
            this.m_dtFin.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_dtFin, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_dtFin, "");
            this.m_dtFin.Name = "m_dtFin";
            this.m_dtFin.Size = new System.Drawing.Size(126, 21);
            this.m_exStyle.SetStyleBackColor(this.m_dtFin, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_dtFin, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_dtFin.TabIndex = 2;
            this.m_dtFin.Value = new System.DateTime(2003, 4, 2, 9, 17, 49, 526);
            // 
            // m_dtDebut
            // 
            this.m_dtDebut.CustomFormat = "dd/MM/yyyy HH:mm";
            this.m_dtDebut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_extLinkListeOperations.SetLinkField(this.m_dtDebut, "");
            this.m_exLinkField.SetLinkField(this.m_dtDebut, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_dtDebut, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_dtDebut, false);
            this.m_dtDebut.Location = new System.Drawing.Point(129, 6);
            this.m_dtDebut.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_dtDebut, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_dtDebut, "");
            this.m_dtDebut.Name = "m_dtDebut";
            this.m_dtDebut.Size = new System.Drawing.Size(126, 21);
            this.m_exStyle.SetStyleBackColor(this.m_dtDebut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_dtDebut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_dtDebut.TabIndex = 2;
            this.m_dtDebut.Value = new System.DateTime(2008, 5, 16, 0, 0, 0, 0);
            // 
            // lbl_finplanifiee
            // 
            this.m_extLinkListeOperations.SetLinkField(this.lbl_finplanifiee, "");
            this.m_exLinkField.SetLinkField(this.lbl_finplanifiee, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.lbl_finplanifiee, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.lbl_finplanifiee, false);
            this.lbl_finplanifiee.Location = new System.Drawing.Point(3, 33);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_finplanifiee, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.lbl_finplanifiee, "");
            this.lbl_finplanifiee.Name = "lbl_finplanifiee";
            this.lbl_finplanifiee.Size = new System.Drawing.Size(120, 17);
            this.m_exStyle.SetStyleBackColor(this.lbl_finplanifiee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.lbl_finplanifiee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_finplanifiee.TabIndex = 1;
            this.lbl_finplanifiee.Text = "Planned end date|572";
            // 
            // lbl_debutplanifie
            // 
            this.m_extLinkListeOperations.SetLinkField(this.lbl_debutplanifie, "");
            this.m_exLinkField.SetLinkField(this.lbl_debutplanifie, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.lbl_debutplanifie, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.lbl_debutplanifie, false);
            this.lbl_debutplanifie.Location = new System.Drawing.Point(3, 10);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_debutplanifie, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.lbl_debutplanifie, "");
            this.lbl_debutplanifie.Name = "lbl_debutplanifie";
            this.lbl_debutplanifie.Size = new System.Drawing.Size(120, 17);
            this.m_exStyle.SetStyleBackColor(this.lbl_debutplanifie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.lbl_debutplanifie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_debutplanifie.TabIndex = 0;
            this.lbl_debutplanifie.Text = "Planned start date|575";
            // 
            // m_btnDeletePlanification
            // 
            this.m_btnDeletePlanification.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnDeletePlanification.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_exLinkField.SetLinkField(this.m_btnDeletePlanification, "");
            this.m_extLinkListeOperations.SetLinkField(this.m_btnDeletePlanification, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_btnDeletePlanification, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_btnDeletePlanification, false);
            this.m_btnDeletePlanification.Location = new System.Drawing.Point(105, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnDeletePlanification, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnDeletePlanification, "");
            this.m_btnDeletePlanification.Name = "m_btnDeletePlanification";
            this.m_btnDeletePlanification.ShortMode = false;
            this.m_btnDeletePlanification.Size = new System.Drawing.Size(100, 21);
            this.m_exStyle.SetStyleBackColor(this.m_btnDeletePlanification, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_btnDeletePlanification, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnDeletePlanification.TabIndex = 4009;
            this.m_btnDeletePlanification.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_btnDeletePlanification.LinkClicked += new System.EventHandler(this.m_btnDeletePlanification_LinkClicked);
            // 
            // m_btnAddPlanification
            // 
            this.m_btnAddPlanification.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnAddPlanification.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkListeOperations.SetLinkField(this.m_btnAddPlanification, "");
            this.m_exLinkField.SetLinkField(this.m_btnAddPlanification, "");
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_btnAddPlanification, false);
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_btnAddPlanification, false);
            this.m_btnAddPlanification.Location = new System.Drawing.Point(3, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAddPlanification, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnAddPlanification, "");
            this.m_btnAddPlanification.Name = "m_btnAddPlanification";
            this.m_btnAddPlanification.ShortMode = false;
            this.m_btnAddPlanification.Size = new System.Drawing.Size(100, 21);
            this.m_exStyle.SetStyleBackColor(this.m_btnAddPlanification, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_btnAddPlanification, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAddPlanification.TabIndex = 4008;
            this.m_btnAddPlanification.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_btnAddPlanification.LinkClicked += new System.EventHandler(this.m_btnAddPlanification_LinkClicked);
            // 
            // m_wndListeFractions
            // 
            this.m_wndListeFractions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_wndListeFractions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_start,
            this.col_end});
            this.m_wndListeFractions.EnableCustomisation = true;
            this.m_wndListeFractions.FullRowSelect = true;
            this.m_wndListeFractions.HideSelection = false;
            this.m_exLinkField.SetLinkField(this.m_wndListeFractions, "");
            this.m_extLinkListeOperations.SetLinkField(this.m_wndListeFractions, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_wndListeFractions, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_wndListeFractions, false);
            this.m_wndListeFractions.Location = new System.Drawing.Point(3, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeFractions, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndListeFractions, "");
            this.m_wndListeFractions.MultiSelect = false;
            this.m_wndListeFractions.Name = "m_wndListeFractions";
            this.m_wndListeFractions.Size = new System.Drawing.Size(262, 230);
            this.m_exStyle.SetStyleBackColor(this.m_wndListeFractions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_wndListeFractions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeFractions.TabIndex = 4007;
            this.m_wndListeFractions.UseCompatibleStateImageBehavior = false;
            this.m_wndListeFractions.View = System.Windows.Forms.View.Details;
            // 
            // col_start
            // 
            this.col_start.Field = "DebutPlanifieString";
            this.col_start.PrecisionWidth = 0;
            this.col_start.ProportionnalSize = false;
            this.col_start.Text = "Start|571";
            this.col_start.Visible = true;
            this.col_start.Width = 120;
            // 
            // col_end
            // 
            this.col_end.Field = "FinPlanifieeString";
            this.col_end.PrecisionWidth = 0;
            this.col_end.ProportionnalSize = false;
            this.col_end.Text = "End|574";
            this.col_end.Visible = true;
            this.col_end.Width = 120;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.m_extLinkListeOperations.SetLinkField(this.label8, "");
            this.m_exLinkField.SetLinkField(this.label8, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.label8, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.label8, false);
            this.label8.Location = new System.Drawing.Point(9, 119);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label8, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label8, "");
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.m_exStyle.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 10;
            // 
            // m_txtSelectPlanificateur
            // 
            this.m_txtSelectPlanificateur.ElementSelectionne = null;
            this.m_txtSelectPlanificateur.FonctionTextNull = null;
            this.m_txtSelectPlanificateur.HasLink = true;
            this.m_txtSelectPlanificateur.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_extLinkListeOperations.SetLinkField(this.m_txtSelectPlanificateur, "");
            this.m_exLinkField.SetLinkField(this.m_txtSelectPlanificateur, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_txtSelectPlanificateur, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_txtSelectPlanificateur, false);
            this.m_txtSelectPlanificateur.Location = new System.Drawing.Point(201, 85);
            this.m_txtSelectPlanificateur.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectPlanificateur, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtSelectPlanificateur, "");
            this.m_txtSelectPlanificateur.Name = "m_txtSelectPlanificateur";
            this.m_txtSelectPlanificateur.SelectedObject = null;
            this.m_txtSelectPlanificateur.Size = new System.Drawing.Size(346, 21);
            this.m_txtSelectPlanificateur.SpecificImage = null;
            this.m_exStyle.SetStyleBackColor(this.m_txtSelectPlanificateur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_txtSelectPlanificateur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectPlanificateur.TabIndex = 9;
            this.m_txtSelectPlanificateur.TextNull = "";
            this.m_txtSelectPlanificateur.ElementSelectionneChanged += new System.EventHandler(this.m_txtSelectPlanificateur_ElementSelectionneChanged);
            // 
            // lbl_managepar
            // 
            this.m_extLinkListeOperations.SetLinkField(this.lbl_managepar, "");
            this.m_exLinkField.SetLinkField(this.lbl_managepar, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.lbl_managepar, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.lbl_managepar, false);
            this.lbl_managepar.Location = new System.Drawing.Point(111, 89);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_managepar, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.lbl_managepar, "");
            this.lbl_managepar.Name = "lbl_managepar";
            this.lbl_managepar.Size = new System.Drawing.Size(94, 17);
            this.m_exStyle.SetStyleBackColor(this.lbl_managepar, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.lbl_managepar, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_managepar.TabIndex = 8;
            this.lbl_managepar.Text = "Managed by|567";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Beige;
            this.m_extLinkListeOperations.SetLinkField(this.label6, "");
            this.m_exLinkField.SetLinkField(this.label6, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.label6, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.label6, false);
            this.label6.Location = new System.Drawing.Point(9, 86);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label6, "");
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 16);
            this.m_exStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTitrePanel);
            this.label6.TabIndex = 2;
            this.label6.Text = "Planning|563";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.m_extLinkListeOperations.SetLinkField(this.pictureBox1, "");
            this.m_exLinkField.SetLinkField(this.pictureBox1, "");
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.pictureBox1, false);
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.pictureBox1, false);
            this.pictureBox1.Location = new System.Drawing.Point(3, 82);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pictureBox1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pictureBox1, "");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(793, 1);
            this.m_exStyle.SetStyleBackColor(this.pictureBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.pictureBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // gb_preplan
            // 
            this.gb_preplan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_preplan.Controls.Add(this.m_lnkPlanningGrid);
            this.gb_preplan.Controls.Add(this.m_panelPreplanification);
            this.gb_preplan.Controls.Add(this.lbl_planif);
            this.gb_preplan.Controls.Add(this.m_txtSelectPreplanificateur);
            this.gb_preplan.Controls.Add(this.lbl_gereepar);
            this.gb_preplan.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkListeOperations.SetLinkField(this.gb_preplan, "");
            this.m_exLinkField.SetLinkField(this.gb_preplan, "");
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.gb_preplan, false);
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.gb_preplan, false);
            this.gb_preplan.Location = new System.Drawing.Point(9, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.gb_preplan, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.gb_preplan, "");
            this.gb_preplan.Name = "gb_preplan";
            this.gb_preplan.Size = new System.Drawing.Size(776, 73);
            this.m_exStyle.SetStyleBackColor(this.gb_preplan, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.gb_preplan, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.gb_preplan.TabIndex = 0;
            this.gb_preplan.TabStop = false;
            this.gb_preplan.Text = "Pre-planning|566";
            // 
            // m_lnkPlanningGrid
            // 
            this.m_exLinkField.SetLinkField(this.m_lnkPlanningGrid, "");
            this.m_extLinkListeOperations.SetLinkField(this.m_lnkPlanningGrid, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_lnkPlanningGrid, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_lnkPlanningGrid, false);
            this.m_lnkPlanningGrid.Location = new System.Drawing.Point(508, 21);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkPlanningGrid, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkPlanningGrid, "");
            this.m_lnkPlanningGrid.Name = "m_lnkPlanningGrid";
            this.m_lnkPlanningGrid.Size = new System.Drawing.Size(133, 15);
            this.m_exStyle.SetStyleBackColor(this.m_lnkPlanningGrid, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_lnkPlanningGrid, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkPlanningGrid.TabIndex = 12;
            this.m_lnkPlanningGrid.TabStop = true;
            this.m_lnkPlanningGrid.Text = "Planning grid|744";
            this.m_lnkPlanningGrid.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkPlanningGrid_LinkClicked);
            // 
            // m_panelPreplanification
            // 
            this.m_panelPreplanification.Controls.Add(this.m_dtDebutPreplanifier);
            this.m_panelPreplanification.Controls.Add(this.lbl_etle);
            this.m_panelPreplanification.Controls.Add(this.m_dtFinPreplanification);
            this.m_extLinkListeOperations.SetLinkField(this.m_panelPreplanification, "");
            this.m_exLinkField.SetLinkField(this.m_panelPreplanification, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_panelPreplanification, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_panelPreplanification, false);
            this.m_panelPreplanification.Location = new System.Drawing.Point(247, 47);
            this.m_panelPreplanification.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelPreplanification, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelPreplanification, "");
            this.m_panelPreplanification.Name = "m_panelPreplanification";
            this.m_panelPreplanification.Size = new System.Drawing.Size(437, 19);
            this.m_exStyle.SetStyleBackColor(this.m_panelPreplanification, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_panelPreplanification, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelPreplanification.TabIndex = 13;
            // 
            // m_dtDebutPreplanifier
            // 
            this.m_dtDebutPreplanifier.Checked = false;
            this.m_dtDebutPreplanifier.CustomFormat = null;
            this.m_dtDebutPreplanifier.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.m_exLinkField.SetLinkField(this.m_dtDebutPreplanifier, "");
            this.m_extLinkListeOperations.SetLinkField(this.m_dtDebutPreplanifier, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_dtDebutPreplanifier, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_dtDebutPreplanifier, false);
            this.m_dtDebutPreplanifier.Location = new System.Drawing.Point(19, 0);
            this.m_dtDebutPreplanifier.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_dtDebutPreplanifier, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_dtDebutPreplanifier, "");
            this.m_dtDebutPreplanifier.Name = "m_dtDebutPreplanifier";
            this.m_dtDebutPreplanifier.Size = new System.Drawing.Size(96, 20);
            this.m_exStyle.SetStyleBackColor(this.m_dtDebutPreplanifier, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_dtDebutPreplanifier, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_dtDebutPreplanifier.TabIndex = 9;
            this.m_dtDebutPreplanifier.TextNull = "None";
            // 
            // lbl_etle
            // 
            this.m_extLinkListeOperations.SetLinkField(this.lbl_etle, "");
            this.m_exLinkField.SetLinkField(this.lbl_etle, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.lbl_etle, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.lbl_etle, false);
            this.lbl_etle.Location = new System.Drawing.Point(121, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_etle, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.lbl_etle, "");
            this.lbl_etle.Name = "lbl_etle";
            this.lbl_etle.Size = new System.Drawing.Size(42, 13);
            this.m_exStyle.SetStyleBackColor(this.lbl_etle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.lbl_etle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_etle.TabIndex = 12;
            this.lbl_etle.Text = "and|569";
            // 
            // m_dtFinPreplanification
            // 
            this.m_dtFinPreplanification.Checked = false;
            this.m_dtFinPreplanification.CustomFormat = null;
            this.m_dtFinPreplanification.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.m_exLinkField.SetLinkField(this.m_dtFinPreplanification, "");
            this.m_extLinkListeOperations.SetLinkField(this.m_dtFinPreplanification, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_dtFinPreplanification, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_dtFinPreplanification, false);
            this.m_dtFinPreplanification.Location = new System.Drawing.Point(169, 0);
            this.m_dtFinPreplanification.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_dtFinPreplanification, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_dtFinPreplanification, "");
            this.m_dtFinPreplanification.Name = "m_dtFinPreplanification";
            this.m_dtFinPreplanification.Size = new System.Drawing.Size(96, 20);
            this.m_exStyle.SetStyleBackColor(this.m_dtFinPreplanification, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_dtFinPreplanification, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_dtFinPreplanification.TabIndex = 11;
            this.m_dtFinPreplanification.TextNull = "None";
            // 
            // lbl_planif
            // 
            this.m_extLinkListeOperations.SetLinkField(this.lbl_planif, "");
            this.m_exLinkField.SetLinkField(this.lbl_planif, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.lbl_planif, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.lbl_planif, false);
            this.lbl_planif.Location = new System.Drawing.Point(6, 49);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_planif, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.lbl_planif, "");
            this.lbl_planif.Name = "lbl_planif";
            this.lbl_planif.Size = new System.Drawing.Size(252, 14);
            this.m_exStyle.SetStyleBackColor(this.lbl_planif, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.lbl_planif, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_planif.TabIndex = 10;
            this.lbl_planif.Text = "This intervention will be planned between|568";
            this.lbl_planif.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtSelectPreplanificateur
            // 
            this.m_txtSelectPreplanificateur.ElementSelectionne = null;
            this.m_txtSelectPreplanificateur.FonctionTextNull = null;
            this.m_txtSelectPreplanificateur.HasLink = true;
            this.m_txtSelectPreplanificateur.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_extLinkListeOperations.SetLinkField(this.m_txtSelectPreplanificateur, "");
            this.m_exLinkField.SetLinkField(this.m_txtSelectPreplanificateur, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_txtSelectPreplanificateur, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_txtSelectPreplanificateur, false);
            this.m_txtSelectPreplanificateur.Location = new System.Drawing.Point(109, 17);
            this.m_txtSelectPreplanificateur.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectPreplanificateur, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtSelectPreplanificateur, "");
            this.m_txtSelectPreplanificateur.Name = "m_txtSelectPreplanificateur";
            this.m_txtSelectPreplanificateur.SelectedObject = null;
            this.m_txtSelectPreplanificateur.Size = new System.Drawing.Size(375, 21);
            this.m_txtSelectPreplanificateur.SpecificImage = null;
            this.m_exStyle.SetStyleBackColor(this.m_txtSelectPreplanificateur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_txtSelectPreplanificateur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectPreplanificateur.TabIndex = 8;
            this.m_txtSelectPreplanificateur.TextNull = "";
            this.m_txtSelectPreplanificateur.ElementSelectionneChanged += new System.EventHandler(this.m_txtSelectPreplanificateur_ElementSelectionneChanged);
            // 
            // lbl_gereepar
            // 
            this.m_extLinkListeOperations.SetLinkField(this.lbl_gereepar, "");
            this.m_exLinkField.SetLinkField(this.lbl_gereepar, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.lbl_gereepar, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.lbl_gereepar, false);
            this.lbl_gereepar.Location = new System.Drawing.Point(6, 21);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_gereepar, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.lbl_gereepar, "");
            this.lbl_gereepar.Name = "lbl_gereepar";
            this.lbl_gereepar.Size = new System.Drawing.Size(97, 17);
            this.m_exStyle.SetStyleBackColor(this.lbl_gereepar, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.lbl_gereepar, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_gereepar.TabIndex = 7;
            this.lbl_gereepar.Text = "Managed by|567";
            // 
            // tb_operations
            // 
            this.tb_operations.Controls.Add(this.splitContainer2);
            this.tb_operations.Controls.Add(this.c2iPanel2);
            this.tb_operations.Controls.Add(this.m_panelDescriptionTicket);
            this.m_exLinkField.SetLinkField(this.tb_operations, "");
            this.m_extLinkListeOperations.SetLinkField(this.tb_operations, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.tb_operations, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.tb_operations, false);
            this.tb_operations.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tb_operations, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tb_operations, "");
            this.tb_operations.Name = "tb_operations";
            this.tb_operations.Selected = false;
            this.tb_operations.Size = new System.Drawing.Size(799, 398);
            this.m_exStyle.SetStyleBackColor(this.tb_operations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.tb_operations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tb_operations.TabIndex = 15;
            this.tb_operations.Title = "Operations|593";
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkListeOperations.SetLinkField(this.splitContainer2, "");
            this.m_exLinkField.SetLinkField(this.splitContainer2, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.splitContainer2, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.splitContainer2, false);
            this.splitContainer2.Location = new System.Drawing.Point(0, 116);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitContainer2, "");
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.m_lstListeOperations);
            this.splitContainer2.Panel1.Controls.Add(this.c2iPanel3);
            this.splitContainer2.Panel1.Controls.Add(this.m_panelRemoveBtn);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.m_exLinkField.SetLinkField(this.splitContainer2.Panel1, "");
            this.m_extLinkListeOperations.SetLinkField(this.splitContainer2.Panel1, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.splitContainer2.Panel1, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.splitContainer2.Panel1, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer2.Panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitContainer2.Panel1, "");
            this.m_exStyle.SetStyleBackColor(this.splitContainer2.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.splitContainer2.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.m_panelOperationsPrev);
            this.splitContainer2.Panel2.Controls.Add(this.m_panelVersion);
            this.splitContainer2.Panel2.Controls.Add(this.m_panelEnteteOperationsPrev);
            this.m_exLinkField.SetLinkField(this.splitContainer2.Panel2, "");
            this.m_extLinkListeOperations.SetLinkField(this.splitContainer2.Panel2, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.splitContainer2.Panel2, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.splitContainer2.Panel2, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer2.Panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitContainer2.Panel2, "");
            this.m_exStyle.SetStyleBackColor(this.splitContainer2.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.splitContainer2.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitContainer2.Size = new System.Drawing.Size(799, 282);
            this.splitContainer2.SplitterDistance = 208;
            this.m_exStyle.SetStyleBackColor(this.splitContainer2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.splitContainer2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitContainer2.TabIndex = 13;
            // 
            // m_lstListeOperations
            // 
            this.m_lstListeOperations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn1});
            this.m_lstListeOperations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lstListeOperations.EnableCustomisation = true;
            this.m_lstListeOperations.FullRowSelect = true;
            this.m_lstListeOperations.HideSelection = false;
            this.m_exLinkField.SetLinkField(this.m_lstListeOperations, "");
            this.m_extLinkListeOperations.SetLinkField(this.m_lstListeOperations, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_lstListeOperations, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_lstListeOperations, false);
            this.m_lstListeOperations.Location = new System.Drawing.Point(0, 69);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lstListeOperations, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lstListeOperations, "");
            this.m_lstListeOperations.MultiSelect = false;
            this.m_lstListeOperations.Name = "m_lstListeOperations";
            this.m_lstListeOperations.Size = new System.Drawing.Size(204, 176);
            this.m_exStyle.SetStyleBackColor(this.m_lstListeOperations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_lstListeOperations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lstListeOperations.TabIndex = 14;
            this.m_lstListeOperations.UseCompatibleStateImageBehavior = false;
            this.m_lstListeOperations.View = System.Windows.Forms.View.Details;
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "Libelle";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Label|50";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 184;
            // 
            // c2iPanel3
            // 
            this.c2iPanel3.Controls.Add(this.m_lnkAjouterListeOp);
            this.c2iPanel3.Controls.Add(this.m_txtSelectListeOperation);
            this.c2iPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkListeOperations.SetLinkField(this.c2iPanel3, "");
            this.m_exLinkField.SetLinkField(this.c2iPanel3, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.c2iPanel3, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.c2iPanel3, false);
            this.c2iPanel3.Location = new System.Drawing.Point(0, 13);
            this.c2iPanel3.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanel3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanel3, "");
            this.c2iPanel3.Name = "c2iPanel3";
            this.c2iPanel3.Size = new System.Drawing.Size(204, 56);
            this.m_exStyle.SetStyleBackColor(this.c2iPanel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.c2iPanel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iPanel3.TabIndex = 15;
            // 
            // m_lnkAjouterListeOp
            // 
            this.m_lnkAjouterListeOp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAjouterListeOp.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_exLinkField.SetLinkField(this.m_lnkAjouterListeOp, "");
            this.m_extLinkListeOperations.SetLinkField(this.m_lnkAjouterListeOp, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_lnkAjouterListeOp, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_lnkAjouterListeOp, false);
            this.m_lnkAjouterListeOp.Location = new System.Drawing.Point(6, 30);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAjouterListeOp, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAjouterListeOp, "");
            this.m_lnkAjouterListeOp.Name = "m_lnkAjouterListeOp";
            this.m_lnkAjouterListeOp.ShortMode = false;
            this.m_lnkAjouterListeOp.Size = new System.Drawing.Size(104, 21);
            this.m_exStyle.SetStyleBackColor(this.m_lnkAjouterListeOp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_lnkAjouterListeOp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAjouterListeOp.TabIndex = 0;
            this.m_lnkAjouterListeOp.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAjouterListeOp.LinkClicked += new System.EventHandler(this.m_lnkAjouterListeOp_LinkClicked);
            // 
            // m_txtSelectListeOperation
            // 
            this.m_txtSelectListeOperation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtSelectListeOperation.ElementSelectionne = null;
            this.m_txtSelectListeOperation.FonctionTextNull = null;
            this.m_txtSelectListeOperation.HasLink = true;
            this.m_txtSelectListeOperation.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_extLinkListeOperations.SetLinkField(this.m_txtSelectListeOperation, "");
            this.m_exLinkField.SetLinkField(this.m_txtSelectListeOperation, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_txtSelectListeOperation, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_txtSelectListeOperation, false);
            this.m_txtSelectListeOperation.Location = new System.Drawing.Point(4, 4);
            this.m_txtSelectListeOperation.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectListeOperation, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtSelectListeOperation, "");
            this.m_txtSelectListeOperation.Name = "m_txtSelectListeOperation";
            this.m_txtSelectListeOperation.SelectedObject = null;
            this.m_txtSelectListeOperation.Size = new System.Drawing.Size(195, 21);
            this.m_txtSelectListeOperation.SpecificImage = null;
            this.m_exStyle.SetStyleBackColor(this.m_txtSelectListeOperation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_txtSelectListeOperation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectListeOperation.TabIndex = 0;
            this.m_txtSelectListeOperation.TextNull = "";
            // 
            // m_panelRemoveBtn
            // 
            this.m_panelRemoveBtn.Controls.Add(this.m_lnkSupprimerListeOp);
            this.m_panelRemoveBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_extLinkListeOperations.SetLinkField(this.m_panelRemoveBtn, "");
            this.m_exLinkField.SetLinkField(this.m_panelRemoveBtn, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_panelRemoveBtn, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_panelRemoveBtn, false);
            this.m_panelRemoveBtn.Location = new System.Drawing.Point(0, 245);
            this.m_panelRemoveBtn.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelRemoveBtn, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelRemoveBtn, "");
            this.m_panelRemoveBtn.Name = "m_panelRemoveBtn";
            this.m_panelRemoveBtn.Size = new System.Drawing.Size(204, 33);
            this.m_exStyle.SetStyleBackColor(this.m_panelRemoveBtn, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_panelRemoveBtn, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelRemoveBtn.TabIndex = 13;
            // 
            // m_lnkSupprimerListeOp
            // 
            this.m_lnkSupprimerListeOp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkSupprimerListeOp.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_exLinkField.SetLinkField(this.m_lnkSupprimerListeOp, "");
            this.m_extLinkListeOperations.SetLinkField(this.m_lnkSupprimerListeOp, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_lnkSupprimerListeOp, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_lnkSupprimerListeOp, false);
            this.m_lnkSupprimerListeOp.Location = new System.Drawing.Point(4, 4);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkSupprimerListeOp, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkSupprimerListeOp, "");
            this.m_lnkSupprimerListeOp.Name = "m_lnkSupprimerListeOp";
            this.m_lnkSupprimerListeOp.ShortMode = false;
            this.m_lnkSupprimerListeOp.Size = new System.Drawing.Size(104, 21);
            this.m_exStyle.SetStyleBackColor(this.m_lnkSupprimerListeOp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_lnkSupprimerListeOp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSupprimerListeOp.TabIndex = 0;
            this.m_lnkSupprimerListeOp.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkSupprimerListeOp.LinkClicked += new System.EventHandler(this.m_lnkSupprimerListeOp_LinkClicked);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkListeOperations.SetLinkField(this.label1, "");
            this.m_exLinkField.SetLinkField(this.label1, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.label1, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.label1, false);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label1, "");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 13);
            this.m_exStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 12;
            this.label1.Text = "Add Operations lists to be planned|1158";
            // 
            // m_panelOperationsPrev
            // 
            this.m_panelOperationsPrev.AutoScroll = true;
            this.m_panelOperationsPrev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkListeOperations.SetLinkField(this.m_panelOperationsPrev, "");
            this.m_exLinkField.SetLinkField(this.m_panelOperationsPrev, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_panelOperationsPrev, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_panelOperationsPrev, false);
            this.m_panelOperationsPrev.Location = new System.Drawing.Point(0, 69);
            this.m_panelOperationsPrev.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelOperationsPrev, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelOperationsPrev, "");
            this.m_panelOperationsPrev.Name = "m_panelOperationsPrev";
            this.m_panelOperationsPrev.Size = new System.Drawing.Size(583, 209);
            this.m_exStyle.SetStyleBackColor(this.m_panelOperationsPrev, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_panelOperationsPrev, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelOperationsPrev.TabIndex = 3;
            // 
            // m_panelVersion
            // 
            this.m_panelVersion.Controls.Add(this.label3);
            this.m_panelVersion.Controls.Add(this.m_txtSelectVersionLiee);
            this.m_panelVersion.Controls.Add(this.m_lnkEditerModificationsPrevisionnelles);
            this.m_panelVersion.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkListeOperations.SetLinkField(this.m_panelVersion, "");
            this.m_exLinkField.SetLinkField(this.m_panelVersion, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_panelVersion, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_panelVersion, false);
            this.m_panelVersion.Location = new System.Drawing.Point(0, 26);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelVersion, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelVersion, "AINGE_REFERENTIEL");
            this.m_panelVersion.Name = "m_panelVersion";
            this.m_panelVersion.Size = new System.Drawing.Size(583, 43);
            this.m_exStyle.SetStyleBackColor(this.m_panelVersion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_panelVersion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelVersion.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.m_extLinkListeOperations.SetLinkField(this.label3, "");
            this.m_exLinkField.SetLinkField(this.label3, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.label3, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.label3, false);
            this.label3.Location = new System.Drawing.Point(6, 20);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 13);
            this.m_exStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4018;
            this.label3.Text = "Associated data version|1366";
            // 
            // m_txtSelectVersionLiee
            // 
            this.m_txtSelectVersionLiee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtSelectVersionLiee.ElementSelectionne = null;
            this.m_txtSelectVersionLiee.FonctionTextNull = null;
            this.m_txtSelectVersionLiee.HasLink = true;
            this.m_txtSelectVersionLiee.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_extLinkListeOperations.SetLinkField(this.m_txtSelectVersionLiee, "");
            this.m_exLinkField.SetLinkField(this.m_txtSelectVersionLiee, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_txtSelectVersionLiee, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_txtSelectVersionLiee, false);
            this.m_txtSelectVersionLiee.Location = new System.Drawing.Point(175, 19);
            this.m_txtSelectVersionLiee.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectVersionLiee, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtSelectVersionLiee, "");
            this.m_txtSelectVersionLiee.Name = "m_txtSelectVersionLiee";
            this.m_txtSelectVersionLiee.SelectedObject = null;
            this.m_txtSelectVersionLiee.Size = new System.Drawing.Size(405, 21);
            this.m_txtSelectVersionLiee.SpecificImage = null;
            this.m_exStyle.SetStyleBackColor(this.m_txtSelectVersionLiee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_txtSelectVersionLiee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectVersionLiee.TabIndex = 4017;
            this.m_txtSelectVersionLiee.TextNull = "";
            this.m_txtSelectVersionLiee.OnSelectedObjectChanged += new System.EventHandler(this.m_txtSelectVersionLiee_OnSelectedObjectChanged);
            // 
            // m_lnkEditerModificationsPrevisionnelles
            // 
            this.m_exLinkField.SetLinkField(this.m_lnkEditerModificationsPrevisionnelles, "");
            this.m_extLinkListeOperations.SetLinkField(this.m_lnkEditerModificationsPrevisionnelles, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_lnkEditerModificationsPrevisionnelles, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_lnkEditerModificationsPrevisionnelles, false);
            this.m_lnkEditerModificationsPrevisionnelles.Location = new System.Drawing.Point(3, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkEditerModificationsPrevisionnelles, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkEditerModificationsPrevisionnelles, "");
            this.m_lnkEditerModificationsPrevisionnelles.Name = "m_lnkEditerModificationsPrevisionnelles";
            this.m_lnkEditerModificationsPrevisionnelles.Size = new System.Drawing.Size(275, 13);
            this.m_exStyle.SetStyleBackColor(this.m_lnkEditerModificationsPrevisionnelles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_lnkEditerModificationsPrevisionnelles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkEditerModificationsPrevisionnelles.TabIndex = 1;
            this.m_lnkEditerModificationsPrevisionnelles.TabStop = true;
            this.m_lnkEditerModificationsPrevisionnelles.Text = "Edit planned modifications|1350";
            this.m_lnkEditerModificationsPrevisionnelles.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkEditerModificationsPrevisionnelles_LinkClicked);
            // 
            // m_panelEnteteOperationsPrev
            // 
            this.m_panelEnteteOperationsPrev.Controls.Add(this.m_panelInfosListeOp);
            this.m_panelEnteteOperationsPrev.Controls.Add(this.m_lnkAddOperation);
            this.m_panelEnteteOperationsPrev.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkListeOperations.SetLinkField(this.m_panelEnteteOperationsPrev, "");
            this.m_exLinkField.SetLinkField(this.m_panelEnteteOperationsPrev, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_panelEnteteOperationsPrev, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_panelEnteteOperationsPrev, false);
            this.m_panelEnteteOperationsPrev.Location = new System.Drawing.Point(0, 0);
            this.m_panelEnteteOperationsPrev.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEnteteOperationsPrev, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelEnteteOperationsPrev, "");
            this.m_panelEnteteOperationsPrev.Name = "m_panelEnteteOperationsPrev";
            this.m_panelEnteteOperationsPrev.Size = new System.Drawing.Size(583, 26);
            this.m_exStyle.SetStyleBackColor(this.m_panelEnteteOperationsPrev, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_panelEnteteOperationsPrev, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEnteteOperationsPrev.TabIndex = 4;
            // 
            // m_panelInfosListeOp
            // 
            this.m_panelInfosListeOp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelInfosListeOp.Controls.Add(this.m_lnkCreerOperationsDeListe);
            this.m_panelInfosListeOp.Controls.Add(this.m_txtLabelListeOp);
            this.m_extLinkListeOperations.SetLinkField(this.m_panelInfosListeOp, "");
            this.m_exLinkField.SetLinkField(this.m_panelInfosListeOp, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_panelInfosListeOp, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_panelInfosListeOp, false);
            this.m_panelInfosListeOp.Location = new System.Drawing.Point(3, 4);
            this.m_panelInfosListeOp.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelInfosListeOp, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelInfosListeOp, "");
            this.m_panelInfosListeOp.Name = "m_panelInfosListeOp";
            this.m_panelInfosListeOp.Size = new System.Drawing.Size(392, 20);
            this.m_exStyle.SetStyleBackColor(this.m_panelInfosListeOp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_panelInfosListeOp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelInfosListeOp.TabIndex = 1;
            // 
            // m_lnkCreerOperationsDeListe
            // 
            this.m_exLinkField.SetLinkField(this.m_lnkCreerOperationsDeListe, "");
            this.m_extLinkListeOperations.SetLinkField(this.m_lnkCreerOperationsDeListe, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_lnkCreerOperationsDeListe, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_lnkCreerOperationsDeListe, false);
            this.m_lnkCreerOperationsDeListe.Location = new System.Drawing.Point(3, 2);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkCreerOperationsDeListe, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkCreerOperationsDeListe, "");
            this.m_lnkCreerOperationsDeListe.Name = "m_lnkCreerOperationsDeListe";
            this.m_lnkCreerOperationsDeListe.Size = new System.Drawing.Size(223, 17);
            this.m_exStyle.SetStyleBackColor(this.m_lnkCreerOperationsDeListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_lnkCreerOperationsDeListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkCreerOperationsDeListe.TabIndex = 0;
            this.m_lnkCreerOperationsDeListe.TabStop = true;
            this.m_lnkCreerOperationsDeListe.Text = "Planify Operations from this list|1157";
            this.m_lnkCreerOperationsDeListe.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkCreerOperationsDeListe_LinkClicked);
            // 
            // m_txtLabelListeOp
            // 
            this.m_txtLabelListeOp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtLabelListeOp.EmptyText = "";
            this.m_exLinkField.SetLinkField(this.m_txtLabelListeOp, "");
            this.m_extLinkListeOperations.SetLinkField(this.m_txtLabelListeOp, "Libelle");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_txtLabelListeOp, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_txtLabelListeOp, true);
            this.m_txtLabelListeOp.Location = new System.Drawing.Point(232, -1);
            this.m_txtLabelListeOp.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLabelListeOp, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_txtLabelListeOp, "");
            this.m_txtLabelListeOp.Name = "m_txtLabelListeOp";
            this.m_txtLabelListeOp.Size = new System.Drawing.Size(157, 21);
            this.m_exStyle.SetStyleBackColor(this.m_txtLabelListeOp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_txtLabelListeOp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLabelListeOp.TabIndex = 11;
            this.m_txtLabelListeOp.Text = "[Libelle]";
            // 
            // m_lnkAddOperation
            // 
            this.m_lnkAddOperation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_exLinkField.SetLinkField(this.m_lnkAddOperation, "");
            this.m_extLinkListeOperations.SetLinkField(this.m_lnkAddOperation, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_lnkAddOperation, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_lnkAddOperation, false);
            this.m_lnkAddOperation.Location = new System.Drawing.Point(415, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAddOperation, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAddOperation, "");
            this.m_lnkAddOperation.Name = "m_lnkAddOperation";
            this.m_lnkAddOperation.Size = new System.Drawing.Size(165, 13);
            this.m_exStyle.SetStyleBackColor(this.m_lnkAddOperation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_lnkAddOperation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAddOperation.TabIndex = 0;
            this.m_lnkAddOperation.TabStop = true;
            this.m_lnkAddOperation.Text = "Add planned Operations|1153";
            this.m_lnkAddOperation.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkAddOperation_LinkClicked);
            // 
            // c2iPanel2
            // 
            this.c2iPanel2.Controls.Add(this.m_txtDescriptionInter);
            this.c2iPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkListeOperations.SetLinkField(this.c2iPanel2, "");
            this.m_exLinkField.SetLinkField(this.c2iPanel2, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.c2iPanel2, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.c2iPanel2, false);
            this.c2iPanel2.Location = new System.Drawing.Point(0, 66);
            this.c2iPanel2.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanel2, "");
            this.c2iPanel2.Name = "c2iPanel2";
            this.c2iPanel2.Size = new System.Drawing.Size(799, 50);
            this.m_exStyle.SetStyleBackColor(this.c2iPanel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.c2iPanel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iPanel2.TabIndex = 6;
            // 
            // m_txtDescriptionInter
            // 
            this.m_txtDescriptionInter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtDescriptionInter.EmptyText = "";
            this.m_exLinkField.SetLinkField(this.m_txtDescriptionInter, "Description");
            this.m_extLinkListeOperations.SetLinkField(this.m_txtDescriptionInter, "");
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_txtDescriptionInter, false);
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_txtDescriptionInter, true);
            this.m_txtDescriptionInter.Location = new System.Drawing.Point(8, 3);
            this.m_txtDescriptionInter.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtDescriptionInter, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtDescriptionInter, "");
            this.m_txtDescriptionInter.Multiline = true;
            this.m_txtDescriptionInter.Name = "m_txtDescriptionInter";
            this.m_txtDescriptionInter.Size = new System.Drawing.Size(775, 40);
            this.m_exStyle.SetStyleBackColor(this.m_txtDescriptionInter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_txtDescriptionInter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtDescriptionInter.TabIndex = 5;
            this.m_txtDescriptionInter.Text = "[Description]";
            // 
            // tb_checklist
            // 
            this.tb_checklist.Controls.Add(this.m_panelCheckList);
            this.m_exLinkField.SetLinkField(this.tb_checklist, "");
            this.m_extLinkListeOperations.SetLinkField(this.tb_checklist, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.tb_checklist, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.tb_checklist, false);
            this.tb_checklist.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tb_checklist, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tb_checklist, "");
            this.tb_checklist.Name = "tb_checklist";
            this.tb_checklist.Selected = false;
            this.tb_checklist.Size = new System.Drawing.Size(799, 398);
            this.m_exStyle.SetStyleBackColor(this.tb_checklist, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.tb_checklist, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tb_checklist.TabIndex = 14;
            this.tb_checklist.Title = "Check List|562";
            // 
            // m_panelCheckList
            // 
            this.m_panelCheckList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_exLinkField.SetLinkField(this.m_panelCheckList, "");
            this.m_extLinkListeOperations.SetLinkField(this.m_panelCheckList, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_panelCheckList, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_panelCheckList, false);
            this.m_panelCheckList.Location = new System.Drawing.Point(3, 3);
            this.m_panelCheckList.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelCheckList, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelCheckList, "");
            this.m_panelCheckList.Name = "m_panelCheckList";
            this.m_panelCheckList.Size = new System.Drawing.Size(781, 382);
            this.m_exStyle.SetStyleBackColor(this.m_panelCheckList, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_panelCheckList, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelCheckList.TabIndex = 0;
            // 
            // tb_ressources
            // 
            this.tb_ressources.Controls.Add(this.splitContainer1);
            this.m_exLinkField.SetLinkField(this.tb_ressources, "");
            this.m_extLinkListeOperations.SetLinkField(this.tb_ressources, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.tb_ressources, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.tb_ressources, false);
            this.tb_ressources.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tb_ressources, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tb_ressources, "");
            this.tb_ressources.Name = "tb_ressources";
            this.tb_ressources.Selected = false;
            this.tb_ressources.Size = new System.Drawing.Size(799, 398);
            this.m_exStyle.SetStyleBackColor(this.tb_ressources, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.tb_ressources, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tb_ressources.TabIndex = 12;
            this.tb_ressources.Title = "Resources|254";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkListeOperations.SetLinkField(this.splitContainer1, "");
            this.m_exLinkField.SetLinkField(this.splitContainer1, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.splitContainer1, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.splitContainer1, false);
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitContainer1, "");
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m_panelIntervenants);
            this.splitContainer1.Panel1.Controls.Add(this.label11);
            this.m_extLinkListeOperations.SetLinkField(this.splitContainer1.Panel1, "");
            this.m_exLinkField.SetLinkField(this.splitContainer1.Panel1, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.splitContainer1.Panel1, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.splitContainer1.Panel1, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1.Panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitContainer1.Panel1, "");
            this.m_exStyle.SetStyleBackColor(this.splitContainer1.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.splitContainer1.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_panelRessourcesMaterielles);
            this.splitContainer1.Panel2.Controls.Add(this.label12);
            this.m_exLinkField.SetLinkField(this.splitContainer1.Panel2, "");
            this.m_extLinkListeOperations.SetLinkField(this.splitContainer1.Panel2, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.splitContainer1.Panel2, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.splitContainer1.Panel2, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1.Panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitContainer1.Panel2, "");
            this.m_exStyle.SetStyleBackColor(this.splitContainer1.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.splitContainer1.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitContainer1.Size = new System.Drawing.Size(799, 398);
            this.splitContainer1.SplitterDistance = 171;
            this.m_exStyle.SetStyleBackColor(this.splitContainer1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.splitContainer1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitContainer1.TabIndex = 0;
            // 
            // m_panelIntervenants
            // 
            this.m_panelIntervenants.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkListeOperations.SetLinkField(this.m_panelIntervenants, "");
            this.m_exLinkField.SetLinkField(this.m_panelIntervenants, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_panelIntervenants, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_panelIntervenants, false);
            this.m_panelIntervenants.Location = new System.Drawing.Point(0, 17);
            this.m_panelIntervenants.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelIntervenants, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelIntervenants, "");
            this.m_panelIntervenants.Name = "m_panelIntervenants";
            this.m_panelIntervenants.Size = new System.Drawing.Size(795, 150);
            this.m_exStyle.SetStyleBackColor(this.m_panelIntervenants, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_panelIntervenants, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelIntervenants.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Beige;
            this.m_extLinkListeOperations.SetLinkField(this.label11, "");
            this.m_exLinkField.SetLinkField(this.label11, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.label11, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.label11, false);
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label11, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label11, "");
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(795, 17);
            this.m_exStyle.SetStyleBackColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTitrePanel);
            this.label11.TabIndex = 1;
            this.label11.Text = "Operators|707";
            // 
            // m_panelRessourcesMaterielles
            // 
            this.m_panelRessourcesMaterielles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkListeOperations.SetLinkField(this.m_panelRessourcesMaterielles, "");
            this.m_exLinkField.SetLinkField(this.m_panelRessourcesMaterielles, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_panelRessourcesMaterielles, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_panelRessourcesMaterielles, false);
            this.m_panelRessourcesMaterielles.Location = new System.Drawing.Point(0, 17);
            this.m_panelRessourcesMaterielles.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelRessourcesMaterielles, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelRessourcesMaterielles, "");
            this.m_panelRessourcesMaterielles.Name = "m_panelRessourcesMaterielles";
            this.m_panelRessourcesMaterielles.Size = new System.Drawing.Size(795, 202);
            this.m_exStyle.SetStyleBackColor(this.m_panelRessourcesMaterielles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_panelRessourcesMaterielles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelRessourcesMaterielles.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Beige;
            this.m_extLinkListeOperations.SetLinkField(this.label12, "");
            this.m_exLinkField.SetLinkField(this.label12, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.label12, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.label12, false);
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label12, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label12, "");
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(795, 17);
            this.m_exStyle.SetStyleBackColor(this.label12, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label12, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTitrePanel);
            this.label12.TabIndex = 2;
            this.label12.Text = "Physical Resources|708";
            // 
            // tb_realisation
            // 
            this.tb_realisation.Controls.Add(this.panel1);
            this.m_exLinkField.SetLinkField(this.tb_realisation, "");
            this.m_extLinkListeOperations.SetLinkField(this.tb_realisation, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.tb_realisation, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.tb_realisation, false);
            this.tb_realisation.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tb_realisation, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tb_realisation, "");
            this.tb_realisation.Name = "tb_realisation";
            this.tb_realisation.Selected = false;
            this.tb_realisation.Size = new System.Drawing.Size(799, 398);
            this.m_exStyle.SetStyleBackColor(this.tb_realisation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.tb_realisation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tb_realisation.TabIndex = 13;
            this.tb_realisation.Title = "Realization|565";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.c2iPanel1);
            this.panel1.Controls.Add(this.m_panelInfoGel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkListeOperations.SetLinkField(this.panel1, "");
            this.m_exLinkField.SetLinkField(this.panel1, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.panel1, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.panel1, false);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel1, "");
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(799, 398);
            this.m_exStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 1;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Black;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_extLinkListeOperations.SetLinkField(this.splitter1, "");
            this.m_exLinkField.SetLinkField(this.splitter1, "");
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.splitter1, false);
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.splitter1, false);
            this.splitter1.Location = new System.Drawing.Point(0, 209);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitter1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitter1, "");
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(799, 3);
            this.m_exStyle.SetStyleBackColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // c2iPanel1
            // 
            this.c2iPanel1.Controls.Add(this.m_panelCRs);
            this.c2iPanel1.Controls.Add(this.m_panelEnteteRealisation);
            this.c2iPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkListeOperations.SetLinkField(this.c2iPanel1, "");
            this.m_exLinkField.SetLinkField(this.c2iPanel1, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.c2iPanel1, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.c2iPanel1, false);
            this.c2iPanel1.Location = new System.Drawing.Point(0, 0);
            this.c2iPanel1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanel1, "");
            this.c2iPanel1.Name = "c2iPanel1";
            this.c2iPanel1.Size = new System.Drawing.Size(799, 212);
            this.m_exStyle.SetStyleBackColor(this.c2iPanel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.c2iPanel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iPanel1.TabIndex = 2;
            // 
            // m_panelCRs
            // 
            this.m_panelCRs.AutoScroll = true;
            this.m_panelCRs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkListeOperations.SetLinkField(this.m_panelCRs, "");
            this.m_exLinkField.SetLinkField(this.m_panelCRs, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_panelCRs, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_panelCRs, false);
            this.m_panelCRs.Location = new System.Drawing.Point(0, 24);
            this.m_panelCRs.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelCRs, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelCRs, "");
            this.m_panelCRs.Name = "m_panelCRs";
            this.m_panelCRs.Size = new System.Drawing.Size(799, 188);
            this.m_exStyle.SetStyleBackColor(this.m_panelCRs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_panelCRs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelCRs.TabIndex = 1;
            // 
            // m_panelEnteteRealisation
            // 
            this.m_panelEnteteRealisation.Controls.Add(this.m_panelNavigation);
            this.m_panelEnteteRealisation.Controls.Add(this.m_lnkAjouterCR);
            this.m_panelEnteteRealisation.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkListeOperations.SetLinkField(this.m_panelEnteteRealisation, "");
            this.m_exLinkField.SetLinkField(this.m_panelEnteteRealisation, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_panelEnteteRealisation, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_panelEnteteRealisation, false);
            this.m_panelEnteteRealisation.Location = new System.Drawing.Point(0, 0);
            this.m_panelEnteteRealisation.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEnteteRealisation, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelEnteteRealisation, "");
            this.m_panelEnteteRealisation.Name = "m_panelEnteteRealisation";
            this.m_panelEnteteRealisation.Size = new System.Drawing.Size(799, 24);
            this.m_exStyle.SetStyleBackColor(this.m_panelEnteteRealisation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_panelEnteteRealisation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEnteteRealisation.TabIndex = 0;
            // 
            // m_panelNavigation
            // 
            this.m_panelNavigation.Controls.Add(this.m_lnkPremierePage);
            this.m_panelNavigation.Controls.Add(this.m_lnkPrecedent);
            this.m_panelNavigation.Controls.Add(this.m_lnkSuivant);
            this.m_panelNavigation.Controls.Add(this.m_lnkDernierePage);
            this.m_panelNavigation.Controls.Add(this.m_lblPageSurNbPages);
            this.m_panelNavigation.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_extLinkListeOperations.SetLinkField(this.m_panelNavigation, "");
            this.m_exLinkField.SetLinkField(this.m_panelNavigation, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_panelNavigation, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_panelNavigation, false);
            this.m_panelNavigation.Location = new System.Drawing.Point(566, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelNavigation, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelNavigation, "");
            this.m_panelNavigation.Name = "m_panelNavigation";
            this.m_panelNavigation.Size = new System.Drawing.Size(233, 24);
            this.m_exStyle.SetStyleBackColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelNavigation.TabIndex = 3;
            // 
            // m_lnkPremierePage
            // 
            this.m_lnkPremierePage.AutoSize = true;
            this.m_exLinkField.SetLinkField(this.m_lnkPremierePage, "");
            this.m_extLinkListeOperations.SetLinkField(this.m_lnkPremierePage, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_lnkPremierePage, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_lnkPremierePage, false);
            this.m_lnkPremierePage.Location = new System.Drawing.Point(36, 6);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkPremierePage, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkPremierePage, "");
            this.m_lnkPremierePage.Name = "m_lnkPremierePage";
            this.m_lnkPremierePage.Size = new System.Drawing.Size(23, 13);
            this.m_exStyle.SetStyleBackColor(this.m_lnkPremierePage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_lnkPremierePage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkPremierePage.TabIndex = 1;
            this.m_lnkPremierePage.TabStop = true;
            this.m_lnkPremierePage.Text = "<<";
            this.m_lnkPremierePage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkPremierePage_LinkClicked);
            // 
            // m_lnkPrecedent
            // 
            this.m_lnkPrecedent.AutoSize = true;
            this.m_exLinkField.SetLinkField(this.m_lnkPrecedent, "");
            this.m_extLinkListeOperations.SetLinkField(this.m_lnkPrecedent, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_lnkPrecedent, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_lnkPrecedent, false);
            this.m_lnkPrecedent.Location = new System.Drawing.Point(69, 6);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkPrecedent, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkPrecedent, "");
            this.m_lnkPrecedent.Name = "m_lnkPrecedent";
            this.m_lnkPrecedent.Size = new System.Drawing.Size(15, 13);
            this.m_exStyle.SetStyleBackColor(this.m_lnkPrecedent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_lnkPrecedent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkPrecedent.TabIndex = 1;
            this.m_lnkPrecedent.TabStop = true;
            this.m_lnkPrecedent.Text = "<";
            this.m_lnkPrecedent.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkPrecedent_LinkClicked);
            // 
            // m_lnkSuivant
            // 
            this.m_lnkSuivant.AutoSize = true;
            this.m_exLinkField.SetLinkField(this.m_lnkSuivant, "");
            this.m_extLinkListeOperations.SetLinkField(this.m_lnkSuivant, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_lnkSuivant, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_lnkSuivant, false);
            this.m_lnkSuivant.Location = new System.Drawing.Point(144, 6);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkSuivant, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkSuivant, "");
            this.m_lnkSuivant.Name = "m_lnkSuivant";
            this.m_lnkSuivant.Size = new System.Drawing.Size(15, 13);
            this.m_exStyle.SetStyleBackColor(this.m_lnkSuivant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_lnkSuivant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSuivant.TabIndex = 1;
            this.m_lnkSuivant.TabStop = true;
            this.m_lnkSuivant.Text = ">";
            this.m_lnkSuivant.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkSuivant_LinkClicked);
            // 
            // m_lnkDernierePage
            // 
            this.m_lnkDernierePage.AutoSize = true;
            this.m_exLinkField.SetLinkField(this.m_lnkDernierePage, "");
            this.m_extLinkListeOperations.SetLinkField(this.m_lnkDernierePage, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_lnkDernierePage, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_lnkDernierePage, false);
            this.m_lnkDernierePage.Location = new System.Drawing.Point(165, 6);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkDernierePage, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkDernierePage, "");
            this.m_lnkDernierePage.Name = "m_lnkDernierePage";
            this.m_lnkDernierePage.Size = new System.Drawing.Size(23, 13);
            this.m_exStyle.SetStyleBackColor(this.m_lnkDernierePage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_lnkDernierePage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkDernierePage.TabIndex = 1;
            this.m_lnkDernierePage.TabStop = true;
            this.m_lnkDernierePage.Text = ">>";
            this.m_lnkDernierePage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkDernierePage_LinkClicked);
            // 
            // m_lblPageSurNbPages
            // 
            this.m_lblPageSurNbPages.AutoSize = true;
            this.m_extLinkListeOperations.SetLinkField(this.m_lblPageSurNbPages, "");
            this.m_exLinkField.SetLinkField(this.m_lblPageSurNbPages, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_lblPageSurNbPages, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_lblPageSurNbPages, false);
            this.m_lblPageSurNbPages.Location = new System.Drawing.Point(90, 6);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblPageSurNbPages, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblPageSurNbPages, "");
            this.m_lblPageSurNbPages.Name = "m_lblPageSurNbPages";
            this.m_lblPageSurNbPages.Size = new System.Drawing.Size(35, 13);
            this.m_exStyle.SetStyleBackColor(this.m_lblPageSurNbPages, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_lblPageSurNbPages, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblPageSurNbPages.TabIndex = 2;
            this.m_lblPageSurNbPages.Text = "label1";
            // 
            // m_lnkAjouterCR
            // 
            this.m_lnkAjouterCR.AutoSize = true;
            this.m_exLinkField.SetLinkField(this.m_lnkAjouterCR, "");
            this.m_extLinkListeOperations.SetLinkField(this.m_lnkAjouterCR, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_lnkAjouterCR, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_lnkAjouterCR, false);
            this.m_lnkAjouterCR.Location = new System.Drawing.Point(0, 6);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAjouterCR, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAjouterCR, "");
            this.m_lnkAjouterCR.Name = "m_lnkAjouterCR";
            this.m_lnkAjouterCR.Size = new System.Drawing.Size(90, 13);
            this.m_exStyle.SetStyleBackColor(this.m_lnkAjouterCR, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_lnkAjouterCR, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAjouterCR.TabIndex = 0;
            this.m_lnkAjouterCR.TabStop = true;
            this.m_lnkAjouterCR.Text = "Add a report|709";
            this.m_lnkAjouterCR.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkAjouterCR_LinkClicked);
            // 
            // m_panelInfoGel
            // 
            this.m_panelInfoGel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_exLinkField.SetLinkField(this.m_panelInfoGel, "");
            this.m_extLinkListeOperations.SetLinkField(this.m_panelInfoGel, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_panelInfoGel, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_panelInfoGel, false);
            this.m_panelInfoGel.Location = new System.Drawing.Point(0, 212);
            this.m_panelInfoGel.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelInfoGel, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelInfoGel, "");
            this.m_panelInfoGel.Name = "m_panelInfoGel";
            this.m_panelInfoGel.Size = new System.Drawing.Size(799, 186);
            this.m_exStyle.SetStyleBackColor(this.m_panelInfoGel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_panelInfoGel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelInfoGel.TabIndex = 1;
            // 
            // tb_fiche
            // 
            this.tb_fiche.Controls.Add(this.m_panelChampsCustom);
            this.m_exLinkField.SetLinkField(this.tb_fiche, "");
            this.m_extLinkListeOperations.SetLinkField(this.tb_fiche, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.tb_fiche, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.tb_fiche, false);
            this.tb_fiche.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tb_fiche, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tb_fiche, "");
            this.tb_fiche.Name = "tb_fiche";
            this.tb_fiche.Selected = false;
            this.tb_fiche.Size = new System.Drawing.Size(799, 398);
            this.m_exStyle.SetStyleBackColor(this.tb_fiche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.tb_fiche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tb_fiche.TabIndex = 11;
            this.tb_fiche.Title = "Form|60";
            // 
            // m_panelChampsCustom
            // 
            this.m_panelChampsCustom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelChampsCustom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelChampsCustom.BoldSelectedPage = true;
            this.m_panelChampsCustom.ElementEdite = null;
            this.m_panelChampsCustom.ForeColor = System.Drawing.Color.Black;
            this.m_panelChampsCustom.IDEPixelArea = false;
            this.m_extLinkListeOperations.SetLinkField(this.m_panelChampsCustom, "");
            this.m_exLinkField.SetLinkField(this.m_panelChampsCustom, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_panelChampsCustom, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_panelChampsCustom, false);
            this.m_panelChampsCustom.Location = new System.Drawing.Point(4, 3);
            this.m_panelChampsCustom.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelChampsCustom, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelChampsCustom, "");
            this.m_panelChampsCustom.Name = "m_panelChampsCustom";
            this.m_panelChampsCustom.Ombre = false;
            this.m_panelChampsCustom.PositionTop = true;
            this.m_panelChampsCustom.Size = new System.Drawing.Size(792, 392);
            this.m_exStyle.SetStyleBackColor(this.m_panelChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_panelChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelChampsCustom.TabIndex = 1;
            this.m_panelChampsCustom.TextColor = System.Drawing.Color.Black;
            // 
            // m_exLinkField
            // 
            this.m_exLinkField.SourceTypeString = "";
            // 
            // m_editeurFraction
            // 
            this.m_editeurFraction.ListeAssociee = this.m_wndListeFractions;
            this.m_editeurFraction.ObjetEdite = null;
            this.m_editeurFraction.InitChamp += new sc2i.data.ObjetDonneeResultEventHandler(this.m_editeurFraction_InitChamp);
            this.m_editeurFraction.MAJ_Champs += new sc2i.data.ObjetDonneeResultEventHandler(this.m_editeurFraction_MAJ_Champs);
            // 
            // m_imagesOnglets
            // 
            this.m_imagesOnglets.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.m_imagesOnglets.ImageSize = new System.Drawing.Size(16, 16);
            this.m_imagesOnglets.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // m_gestionnaireEditionListeOp
            // 
            this.m_gestionnaireEditionListeOp.ListeAssociee = this.m_lstListeOperations;
            this.m_gestionnaireEditionListeOp.ObjetEdite = null;
            this.m_gestionnaireEditionListeOp.InitChamp += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireEditionListeOp_InitChamp);
            this.m_gestionnaireEditionListeOp.MAJ_Champs += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireEditionListeOp_MAJ_Champs);
            // 
            // m_extLinkListeOperations
            // 
            this.m_extLinkListeOperations.SourceTypeString = "";
            // 
            // m_gestionnaireTabControl
            // 
            this.m_gestionnaireTabControl.TabControl = this.m_tabControl;
            this.m_gestionnaireTabControl.OnInitPage += new sc2i.win32.common.EventOnPageHandler(this.m_gestionnaireTabControl_OnInitPage);
            this.m_gestionnaireTabControl.OnMajChampsPage += new sc2i.win32.common.EventOnPageHandler(this.m_gestionnaireTabControl_OnMajChampsPage);
            // 
            // label4
            // 
            this.m_extLinkListeOperations.SetLinkField(this.label4, "");
            this.m_exLinkField.SetLinkField(this.label4, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.label4, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.label4, false);
            this.label4.Location = new System.Drawing.Point(268, 30);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 19);
            this.m_exStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 4015;
            this.label4.Text = "Provided operators|20709";
            // 
            // m_txtNbOperateursPrévus
            // 
            this.m_extLinkListeOperations.SetLinkField(this.m_txtNbOperateursPrévus, "");
            this.m_exLinkField.SetLinkField(this.m_txtNbOperateursPrévus, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_txtNbOperateursPrévus, true);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_txtNbOperateursPrévus, true);
            this.m_txtNbOperateursPrévus.Location = new System.Drawing.Point(420, 28);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtNbOperateursPrévus, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtNbOperateursPrévus, "");
            this.m_txtNbOperateursPrévus.Name = "m_txtNbOperateursPrévus";
            this.m_txtNbOperateursPrévus.Size = new System.Drawing.Size(89, 21);
            this.m_exStyle.SetStyleBackColor(this.m_txtNbOperateursPrévus, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_txtNbOperateursPrévus, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtNbOperateursPrévus.TabIndex = 4016;
            // 
            // label5
            // 
            this.m_extLinkListeOperations.SetLinkField(this.label5, "");
            this.m_exLinkField.SetLinkField(this.label5, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.label5, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.label5, false);
            this.label5.Location = new System.Drawing.Point(268, 50);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 19);
            this.m_exStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 4017;
            this.label5.Text = "Hourly rate|20710";
            // 
            // m_txtTauxHorairePrévu
            // 
            this.m_txtTauxHorairePrévu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtTauxHorairePrévu.ElementSelectionne = null;
            this.m_txtTauxHorairePrévu.FonctionTextNull = null;
            this.m_txtTauxHorairePrévu.HasLink = true;
            this.m_txtTauxHorairePrévu.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_extLinkListeOperations.SetLinkField(this.m_txtTauxHorairePrévu, "");
            this.m_exLinkField.SetLinkField(this.m_txtTauxHorairePrévu, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this.m_txtTauxHorairePrévu, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this.m_txtTauxHorairePrévu, false);
            this.m_txtTauxHorairePrévu.Location = new System.Drawing.Point(420, 50);
            this.m_txtTauxHorairePrévu.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtTauxHorairePrévu, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtTauxHorairePrévu, "");
            this.m_txtTauxHorairePrévu.Name = "m_txtTauxHorairePrévu";
            this.m_txtTauxHorairePrévu.SelectedObject = null;
            this.m_txtTauxHorairePrévu.Size = new System.Drawing.Size(243, 21);
            this.m_txtTauxHorairePrévu.SpecificImage = null;
            this.m_exStyle.SetStyleBackColor(this.m_txtTauxHorairePrévu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_txtTauxHorairePrévu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtTauxHorairePrévu.TabIndex = 4018;
            this.m_txtTauxHorairePrévu.TextNull = "";
            // 
            // CPanelEditIntervention
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.c2iPanelOmbre1);
            this.ForeColor = System.Drawing.Color.Black;
            this.m_exLinkField.SetLinkField(this, "");
            this.m_extLinkListeOperations.SetLinkField(this, "");
            this.m_exLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_extLinkListeOperations.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CPanelEditIntervention";
            this.Size = new System.Drawing.Size(818, 520);
            this.m_exStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondFenetre);
            this.m_exStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTexteFenetre);
            this.c2iPanelOmbre1.ResumeLayout(false);
            this.c2iPanelOmbre1.PerformLayout();
            this.m_panelLienTicket.ResumeLayout(false);
            this.m_panelDescriptionTicket.ResumeLayout(false);
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.tb_planification.ResumeLayout(false);
            this.tb_planification.PerformLayout();
            this.m_panelPlanification.ResumeLayout(false);
            this.m_panelPlanification.PerformLayout();
            this.m_panelFraction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gb_preplan.ResumeLayout(false);
            this.m_panelPreplanification.ResumeLayout(false);
            this.tb_operations.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.c2iPanel3.ResumeLayout(false);
            this.m_panelRemoveBtn.ResumeLayout(false);
            this.m_panelVersion.ResumeLayout(false);
            this.m_panelVersion.PerformLayout();
            this.m_panelEnteteOperationsPrev.ResumeLayout(false);
            this.m_panelInfosListeOp.ResumeLayout(false);
            this.m_panelInfosListeOp.PerformLayout();
            this.c2iPanel2.ResumeLayout(false);
            this.c2iPanel2.PerformLayout();
            this.tb_checklist.ResumeLayout(false);
            this.tb_ressources.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tb_realisation.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.c2iPanel1.ResumeLayout(false);
            this.m_panelEnteteRealisation.ResumeLayout(false);
            this.m_panelEnteteRealisation.PerformLayout();
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelNavigation.PerformLayout();
            this.tb_fiche.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private CExtModulesAssociator m_extModulesAssociator;
        private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private sc2i.win32.common.CExtLinkField m_exLinkField;
		private sc2i.win32.common.CExtStyle m_exStyle;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre1;
		private System.Windows.Forms.Label lbl_inter;
		private sc2i.win32.common.C2iTabControl m_tabControl;
		private Crownwood.Magic.Controls.TabPage tb_planification;
		private System.Windows.Forms.Label lbl_interon;
		private sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees m_cmbTypeIntervention;
		private System.Windows.Forms.GroupBox gb_preplan;
		private System.Windows.Forms.LinkLabel m_lnkElementAIntervention;
		private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_txtSelectPreplanificateur;
		private System.Windows.Forms.Label lbl_gereepar;
		private sc2i.win32.common.C2iDateTimeExPicker m_dtFinPreplanification;
		private System.Windows.Forms.Label lbl_planif;
		private sc2i.win32.common.C2iDateTimeExPicker m_dtDebutPreplanifier;
		private System.Windows.Forms.Label lbl_etle;
		private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_txtSelectPlanificateur;
		private System.Windows.Forms.Label lbl_managepar;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label8;
		private sc2i.win32.common.ListViewAutoFilled m_wndListeFractions;
		private sc2i.win32.common.ListViewAutoFilledColumn col_start;
		private sc2i.win32.common.ListViewAutoFilledColumn col_end;
		private System.Windows.Forms.LinkLabel m_lnkChangeElement;
		private Crownwood.Magic.Controls.TabPage tb_fiche;
		private sc2i.win32.data.dynamic.CPanelChampsCustom m_panelChampsCustom;
		private System.Windows.Forms.Panel m_panelFraction;
		private sc2i.win32.common.C2iDateTimePicker m_dtFin;
		private sc2i.win32.common.C2iDateTimePicker m_dtDebut;
		private System.Windows.Forms.Label lbl_finplanifiee;
		private System.Windows.Forms.Label lbl_debutplanifie;
		private sc2i.win32.common.CWndLinkStd m_btnDeletePlanification;
		private sc2i.win32.common.CWndLinkStd m_btnAddPlanification;
		private sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee m_editeurFraction;
		private Crownwood.Magic.Controls.TabPage tb_ressources;
        private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Label label11;
		private sc2i.win32.common.C2iPanel m_panelRessourcesMaterielles;
		private System.Windows.Forms.Label label12;
		private Crownwood.Magic.Controls.TabPage tb_realisation;
		private System.Windows.Forms.ImageList m_imagesOnglets;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Splitter splitter1;
		private sc2i.win32.common.C2iPanel c2iPanel1;
		private sc2i.win32.common.C2iPanel m_panelEnteteRealisation;
		private System.Windows.Forms.LinkLabel m_lnkAjouterCR;
		private CPanelInfoGel m_panelInfoGel;
		private sc2i.win32.common.C2iPanel m_panelCRs;
		private System.Windows.Forms.LinkLabel m_lnkQuiAppeler;
		private sc2i.win32.common.C2iPanel m_panelPlanification;
		private sc2i.win32.common.C2iPanel m_panelPreplanification;
		private System.Windows.Forms.Label lbl_label;
		private sc2i.win32.common.C2iTextBox c2iTextBox1;
		private System.Windows.Forms.Label m_lblDureeprevue;
		private System.Windows.Forms.LinkLabel m_lnkTicket;
		private System.Windows.Forms.Panel m_panelDescriptionTicket;
		private System.Windows.Forms.Label lbl_tkt;
		private System.Windows.Forms.Label label15;
        private sc2i.win32.common.C2iTextBoxNumeriqueAvecUnite m_wndDureePrevue;
		private Crownwood.Magic.Controls.TabPage tb_checklist;
		private timos.win32.composants.planning.CControleCheckListIntervention m_panelCheckList;
        private Crownwood.Magic.Controls.TabPage tb_operations;
        private sc2i.win32.common.C2iPanel m_panelEnteteOperationsPrev;
        private System.Windows.Forms.LinkLabel m_lnkAddOperation;
        private sc2i.win32.common.C2iPanel m_panelOperationsPrev;
        private System.Windows.Forms.Label m_lblDescriptionTicket;
        private sc2i.win32.common.C2iTextBox m_txtDescriptionInter;
        private sc2i.win32.common.C2iPanel c2iPanel2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_txtSelectListeOperation;
        private System.Windows.Forms.LinkLabel m_lnkCreerOperationsDeListe;
        private System.Windows.Forms.Label label1;
        private sc2i.win32.common.ListViewAutoFilled m_lstListeOperations;
        private sc2i.win32.common.C2iPanel m_panelRemoveBtn;
        private sc2i.win32.common.CWndLinkStd m_lnkSupprimerListeOp;
        private sc2i.win32.common.C2iPanel c2iPanel3;
        private sc2i.win32.common.CWndLinkStd m_lnkAjouterListeOp;
        private sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee m_gestionnaireEditionListeOp;
        private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn1;
        private sc2i.win32.common.C2iTextBox m_txtLabelListeOp;
        private sc2i.win32.common.CExtLinkField m_extLinkListeOperations;
        private sc2i.win32.common.C2iPanel m_panelInfosListeOp;
        private System.Windows.Forms.Label label2;
		private sc2i.win32.common.CGestionnaireTabControl m_gestionnaireTabControl;
		private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_selectSite;
        private System.Windows.Forms.Panel m_panelLienTicket;
		private System.Windows.Forms.Panel m_panelVersion;
		private System.Windows.Forms.LinkLabel m_lnkEditerModificationsPrevisionnelles;
		private System.Windows.Forms.Label label3;
		private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_txtSelectVersionLiee;
        private System.Windows.Forms.Panel m_panelNavigation;
        private System.Windows.Forms.Label m_lblPageSurNbPages;
        private System.Windows.Forms.LinkLabel m_lnkPremierePage;
        private System.Windows.Forms.LinkLabel m_lnkDernierePage;
        private System.Windows.Forms.LinkLabel m_lnkPrecedent;
        private System.Windows.Forms.LinkLabel m_lnkSuivant;
        private CPanelAffecteIntervenants m_panelIntervenants;
        private System.Windows.Forms.LinkLabel m_lnkPlanningGrid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private sc2i.win32.common.C2iNumericUpDown m_txtNbOperateursPrévus;
        private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_txtTauxHorairePrévu;
	}
}
