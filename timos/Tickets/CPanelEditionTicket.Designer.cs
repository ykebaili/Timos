using sc2i.common;



namespace timos
{
    partial class CPanelEditionTicket
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
            sc2i.win32.common.GLColumn glColumn5 = new sc2i.win32.common.GLColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPanelEditionTicket));
            sc2i.win32.common.GLColumn glColumn6 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn7 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn8 = new sc2i.win32.common.GLColumn();
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_tabPageResolution = new Crownwood.Magic.Controls.TabPage();
            this.m_splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.m_lnkPhaseSuivante = new System.Windows.Forms.LinkLabel();
            this.m_panelCacherListePhases = new System.Windows.Forms.Panel();
            this.m_listePhases = new sc2i.win32.common.CListLink();
            this.m_lblListeEtapes = new System.Windows.Forms.Label();
            this.m_lnkCloreTicket = new System.Windows.Forms.LinkLabel();
            this.m_panelEditionPhase = new timos.CPanelEditionPhase();
            this.m_tabPageDetail = new Crownwood.Magic.Controls.TabPage();
            this.m_splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.m_gbDtails = new System.Windows.Forms.GroupBox();
            this.m_cmbxSelectOrigineTicket = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.m_cmbxSelectTypeTicket = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.m_cmbxSelectUrgence = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.lbl_origine = new System.Windows.Forms.Label();
            this.m_cmbxSelectContrat = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.lbl_urgence = new System.Windows.Forms.Label();
            this.m_txtSelectClient = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.lbl_client = new System.Windows.Forms.Label();
            this.lbl_contrat = new System.Windows.Forms.Label();
            this.lbl_typeticket = new System.Windows.Forms.Label();
            this.m_panelFormulaireSurOrigine = new sc2i.formulaire.win32.editor.CPanelFormulaireSurElement();
            this.m_panelChampsCustom = new sc2i.win32.data.dynamic.CPanelChampsCustom();
            this.m_gbDescription = new System.Windows.Forms.GroupBox();
            this.m_txtDescription = new sc2i.win32.common.C2iTextBox();
            this.m_btnDetailEtapeSuivante = new System.Windows.Forms.Button();
            this.m_tabPageSites = new Crownwood.Magic.Controls.TabPage();
            this.m_controlEditionEntitesLiees = new timos.CControlEditionEntitesLiees();
            this.m_btnSitesEtapeSuivant = new System.Windows.Forms.Button();
            this.m_tabPageTicketsLies = new Crownwood.Magic.Controls.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_controlEditDependances = new timos.CControlEditionDependancesTicket();
            this.m_tabPageHistorique = new Crownwood.Magic.Controls.TabPage();
            this.m_panelListeHistorique = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_gbInfosGenerales = new System.Windows.Forms.GroupBox();
            this.m_lblEtatCloture = new System.Windows.Forms.Label();
            this.m_lblDateOuverture = new System.Windows.Forms.Label();
            this.m_lblDateCloture = new System.Windows.Forms.Label();
            this.m_lblPhaseEncours = new System.Windows.Forms.Label();
            this.m_lblResponsable = new System.Windows.Forms.Label();
            this.m_lblAuteurTicket = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_ticket = new System.Windows.Forms.Label();
            this.m_panelEntete = new sc2i.win32.common.C2iPanelOmbre();
            this.m_panelTitre = new sc2i.win32.common.C2iPanel(this.components);
            this.m_btnAfficheInfosEntete = new System.Windows.Forms.Button();
            this.m_lblEtatToString = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_lblNumeroTicket = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn3 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn6 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn7 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_toolTipTraductible = new sc2i.win32.common.CToolTipTraductible(this.components);
            this.m_extLinkField = new sc2i.win32.common.CExtLinkField();
            this.listViewAutoFilledColumn2 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn4 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn5 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn8 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_tabControl.SuspendLayout();
            this.m_tabPageResolution.SuspendLayout();
            this.m_splitContainer3.Panel1.SuspendLayout();
            this.m_splitContainer3.Panel2.SuspendLayout();
            this.m_splitContainer3.SuspendLayout();
            this.m_panelCacherListePhases.SuspendLayout();
            this.m_tabPageDetail.SuspendLayout();
            this.m_splitContainer2.Panel1.SuspendLayout();
            this.m_splitContainer2.Panel2.SuspendLayout();
            this.m_splitContainer2.SuspendLayout();
            this.m_gbDtails.SuspendLayout();
            this.m_gbDescription.SuspendLayout();
            this.m_tabPageSites.SuspendLayout();
            this.m_tabPageTicketsLies.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.m_tabPageHistorique.SuspendLayout();
            this.m_gbInfosGenerales.SuspendLayout();
            this.m_panelEntete.SuspendLayout();
            this.m_panelTitre.SuspendLayout();
            this.SuspendLayout();
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
            this.m_tabControl.Location = new System.Drawing.Point(0, 99);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.m_tabPageDetail;
            this.m_tabControl.Size = new System.Drawing.Size(830, 441);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 1;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_tabPageDetail,
            this.m_tabPageSites,
            this.m_tabPageResolution,
            this.m_tabPageTicketsLies,
            this.m_tabPageHistorique});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_tabPageResolution
            // 
            this.m_tabPageResolution.Controls.Add(this.m_splitContainer3);
            this.m_extLinkField.SetLinkField(this.m_tabPageResolution, "");
            this.m_tabPageResolution.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabPageResolution, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_tabPageResolution.Name = "m_tabPageResolution";
            this.m_tabPageResolution.Selected = false;
            this.m_tabPageResolution.Size = new System.Drawing.Size(814, 400);
            this.m_extStyle.SetStyleBackColor(this.m_tabPageResolution, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabPageResolution, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabPageResolution.TabIndex = 15;
            this.m_tabPageResolution.Title = "Resolving process|658";
            // 
            // m_splitContainer3
            // 
            this.m_splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_splitContainer3, "");
            this.m_splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_splitContainer3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_splitContainer3.Name = "m_splitContainer3";
            // 
            // m_splitContainer3.Panel1
            // 
            this.m_splitContainer3.Panel1.Controls.Add(this.m_lnkPhaseSuivante);
            this.m_splitContainer3.Panel1.Controls.Add(this.m_panelCacherListePhases);
            this.m_splitContainer3.Panel1.Controls.Add(this.m_lnkCloreTicket);
            this.m_extLinkField.SetLinkField(this.m_splitContainer3.Panel1, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_splitContainer3.Panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_splitContainer3.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainer3.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_splitContainer3.Panel2
            // 
            this.m_splitContainer3.Panel2.Controls.Add(this.m_panelEditionPhase);
            this.m_extLinkField.SetLinkField(this.m_splitContainer3.Panel2, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_splitContainer3.Panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_splitContainer3.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainer3.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_splitContainer3.Size = new System.Drawing.Size(814, 400);
            this.m_splitContainer3.SplitterDistance = 138;
            this.m_extStyle.SetStyleBackColor(this.m_splitContainer3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainer3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_splitContainer3.TabIndex = 18;
            // 
            // m_lnkPhaseSuivante
            // 
            this.m_lnkPhaseSuivante.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.m_lnkPhaseSuivante, "");
            this.m_lnkPhaseSuivante.Location = new System.Drawing.Point(3, 2);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkPhaseSuivante, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkPhaseSuivante.Name = "m_lnkPhaseSuivante";
            this.m_lnkPhaseSuivante.Size = new System.Drawing.Size(141, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lnkPhaseSuivante, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkPhaseSuivante, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkPhaseSuivante.TabIndex = 15;
            this.m_lnkPhaseSuivante.TabStop = true;
            this.m_lnkPhaseSuivante.Text = "Next Phase...|673";
            this.m_lnkPhaseSuivante.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkPhaseSuivante_LinkClicked);
            // 
            // m_panelCacherListePhases
            // 
            this.m_panelCacherListePhases.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelCacherListePhases.Controls.Add(this.m_listePhases);
            this.m_panelCacherListePhases.Controls.Add(this.m_lblListeEtapes);
            this.m_extLinkField.SetLinkField(this.m_panelCacherListePhases, "");
            this.m_panelCacherListePhases.Location = new System.Drawing.Point(3, 104);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelCacherListePhases, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelCacherListePhases.Name = "m_panelCacherListePhases";
            this.m_panelCacherListePhases.Size = new System.Drawing.Size(132, 293);
            this.m_extStyle.SetStyleBackColor(this.m_panelCacherListePhases, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCacherListePhases, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelCacherListePhases.TabIndex = 17;
            // 
            // m_listePhases
            // 
            this.m_listePhases.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_listePhases.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_listePhases.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_listePhases.ColorActive = System.Drawing.Color.Red;
            this.m_listePhases.ColorDesactive = System.Drawing.Color.Blue;
            this.m_listePhases.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.m_listePhases.ForeColor = System.Drawing.Color.Black;
            this.m_listePhases.FullRowSelect = true;
            this.m_listePhases.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_extLinkField.SetLinkField(this.m_listePhases, "");
            this.m_listePhases.Location = new System.Drawing.Point(3, 20);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_listePhases, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_listePhases.MultiSelect = false;
            this.m_listePhases.Name = "m_listePhases";
            this.m_listePhases.Size = new System.Drawing.Size(126, 244);
            this.m_extStyle.SetStyleBackColor(this.m_listePhases, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_listePhases, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_listePhases.TabIndex = 14;
            this.m_listePhases.UseCompatibleStateImageBehavior = false;
            this.m_listePhases.View = System.Windows.Forms.View.Details;
            this.m_listePhases.ItemClick += new sc2i.win32.common.ListLinkItemClickEventHandler(this.m_listePhases_ItemClick);
            // 
            // m_lblListeEtapes
            // 
            this.m_extLinkField.SetLinkField(this.m_lblListeEtapes, "");
            this.m_lblListeEtapes.Location = new System.Drawing.Point(3, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblListeEtapes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblListeEtapes.Name = "m_lblListeEtapes";
            this.m_lblListeEtapes.Size = new System.Drawing.Size(141, 17);
            this.m_extStyle.SetStyleBackColor(this.m_lblListeEtapes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblListeEtapes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblListeEtapes.TabIndex = 11;
            this.m_lblListeEtapes.Text = "Resolving Phases list|667";
            // 
            // m_lnkCloreTicket
            // 
            this.m_lnkCloreTicket.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.m_lnkCloreTicket, "");
            this.m_lnkCloreTicket.Location = new System.Drawing.Point(3, 20);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkCloreTicket, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkCloreTicket.Name = "m_lnkCloreTicket";
            this.m_lnkCloreTicket.Size = new System.Drawing.Size(141, 20);
            this.m_extStyle.SetStyleBackColor(this.m_lnkCloreTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkCloreTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkCloreTicket.TabIndex = 15;
            this.m_lnkCloreTicket.TabStop = true;
            this.m_lnkCloreTicket.Text = "Close Ticket...|674";
            this.m_lnkCloreTicket.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkCloreTicket_LinkClicked);
            // 
            // m_panelEditionPhase
            // 
            this.m_panelEditionPhase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelEditionPhase, "");
            this.m_panelEditionPhase.Location = new System.Drawing.Point(0, 0);
            this.m_panelEditionPhase.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEditionPhase, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelEditionPhase.Name = "m_panelEditionPhase";
            this.m_panelEditionPhase.Size = new System.Drawing.Size(672, 400);
            this.m_extStyle.SetStyleBackColor(this.m_panelEditionPhase, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEditionPhase, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEditionPhase.TabIndex = 1;
            this.m_panelEditionPhase.OnDebutPhase += new System.EventHandler(this.m_panelEditionPhase_OnDebutPhase);
            this.m_panelEditionPhase.OnChangeEtatGel += new System.EventHandler(this.m_panelEditionPhase_OnChangeEtatGel);
            // 
            // m_tabPageDetail
            // 
            this.m_tabPageDetail.Controls.Add(this.m_splitContainer2);
            this.m_tabPageDetail.Controls.Add(this.m_btnDetailEtapeSuivante);
            this.m_extLinkField.SetLinkField(this.m_tabPageDetail, "");
            this.m_tabPageDetail.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabPageDetail, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_tabPageDetail.Name = "m_tabPageDetail";
            this.m_tabPageDetail.Size = new System.Drawing.Size(814, 400);
            this.m_extStyle.SetStyleBackColor(this.m_tabPageDetail, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabPageDetail, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabPageDetail.TabIndex = 10;
            this.m_tabPageDetail.Title = "Details|656";
            // 
            // m_splitContainer2
            // 
            this.m_splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_extLinkField.SetLinkField(this.m_splitContainer2, "");
            this.m_splitContainer2.Location = new System.Drawing.Point(4, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_splitContainer2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_splitContainer2.Name = "m_splitContainer2";
            // 
            // m_splitContainer2.Panel1
            // 
            this.m_splitContainer2.Panel1.Controls.Add(this.m_gbDtails);
            this.m_splitContainer2.Panel1.Controls.Add(this.m_panelFormulaireSurOrigine);
            this.m_extLinkField.SetLinkField(this.m_splitContainer2.Panel1, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_splitContainer2.Panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_splitContainer2.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainer2.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_splitContainer2.Panel2
            // 
            this.m_splitContainer2.Panel2.Controls.Add(this.m_panelChampsCustom);
            this.m_splitContainer2.Panel2.Controls.Add(this.m_gbDescription);
            this.m_extLinkField.SetLinkField(this.m_splitContainer2.Panel2, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_splitContainer2.Panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_splitContainer2.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainer2.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_splitContainer2.Size = new System.Drawing.Size(802, 362);
            this.m_splitContainer2.SplitterDistance = 396;
            this.m_extStyle.SetStyleBackColor(this.m_splitContainer2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainer2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_splitContainer2.TabIndex = 1;
            // 
            // m_gbDtails
            // 
            this.m_gbDtails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_gbDtails.Controls.Add(this.m_cmbxSelectOrigineTicket);
            this.m_gbDtails.Controls.Add(this.m_cmbxSelectTypeTicket);
            this.m_gbDtails.Controls.Add(this.m_cmbxSelectUrgence);
            this.m_gbDtails.Controls.Add(this.lbl_origine);
            this.m_gbDtails.Controls.Add(this.m_cmbxSelectContrat);
            this.m_gbDtails.Controls.Add(this.lbl_urgence);
            this.m_gbDtails.Controls.Add(this.m_txtSelectClient);
            this.m_gbDtails.Controls.Add(this.lbl_client);
            this.m_gbDtails.Controls.Add(this.lbl_contrat);
            this.m_gbDtails.Controls.Add(this.lbl_typeticket);
            this.m_extLinkField.SetLinkField(this.m_gbDtails, "");
            this.m_gbDtails.Location = new System.Drawing.Point(3, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_gbDtails, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_gbDtails.Name = "m_gbDtails";
            this.m_gbDtails.Size = new System.Drawing.Size(386, 119);
            this.m_extStyle.SetStyleBackColor(this.m_gbDtails, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_gbDtails, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_gbDtails.TabIndex = 0;
            this.m_gbDtails.TabStop = false;
            this.m_gbDtails.Text = "Details|337";
            // 
            // m_cmbxSelectOrigineTicket
            // 
            this.m_cmbxSelectOrigineTicket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbxSelectOrigineTicket.ComportementLinkStd = true;
            this.m_cmbxSelectOrigineTicket.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbxSelectOrigineTicket.ElementSelectionne = null;
            this.m_cmbxSelectOrigineTicket.FormattingEnabled = true;
            this.m_cmbxSelectOrigineTicket.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbxSelectOrigineTicket, "");
            this.m_cmbxSelectOrigineTicket.LinkProperty = "";
            this.m_cmbxSelectOrigineTicket.ListDonnees = null;
            this.m_cmbxSelectOrigineTicket.Location = new System.Drawing.Point(91, 93);
            this.m_cmbxSelectOrigineTicket.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbxSelectOrigineTicket, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbxSelectOrigineTicket.Name = "m_cmbxSelectOrigineTicket";
            this.m_cmbxSelectOrigineTicket.NullAutorise = false;
            this.m_cmbxSelectOrigineTicket.ProprieteAffichee = null;
            this.m_cmbxSelectOrigineTicket.ProprieteParentListeObjets = null;
            this.m_cmbxSelectOrigineTicket.SelectionneurParent = null;
            this.m_cmbxSelectOrigineTicket.Size = new System.Drawing.Size(242, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbxSelectOrigineTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbxSelectOrigineTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbxSelectOrigineTicket.TabIndex = 4;
            this.m_cmbxSelectOrigineTicket.TextNull = I.T("(empty)|30195");
            this.m_cmbxSelectOrigineTicket.Tri = true;
            this.m_cmbxSelectOrigineTicket.TypeFormEdition = null;
            this.m_cmbxSelectOrigineTicket.SelectionChangeCommitted += new System.EventHandler(this.m_cmbxSelectOrigineTicket_SelectionChangeCommitted);
            // 
            // m_cmbxSelectTypeTicket
            // 
            this.m_cmbxSelectTypeTicket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbxSelectTypeTicket.ComportementLinkStd = true;
            this.m_cmbxSelectTypeTicket.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbxSelectTypeTicket.ElementSelectionne = null;
            this.m_cmbxSelectTypeTicket.FormattingEnabled = true;
            this.m_cmbxSelectTypeTicket.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbxSelectTypeTicket, "");
            this.m_cmbxSelectTypeTicket.LinkProperty = "";
            this.m_cmbxSelectTypeTicket.ListDonnees = null;
            this.m_cmbxSelectTypeTicket.Location = new System.Drawing.Point(91, 53);
            this.m_cmbxSelectTypeTicket.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbxSelectTypeTicket, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbxSelectTypeTicket.Name = "m_cmbxSelectTypeTicket";
            this.m_cmbxSelectTypeTicket.NullAutorise = false;
            this.m_cmbxSelectTypeTicket.ProprieteAffichee = null;
            this.m_cmbxSelectTypeTicket.ProprieteParentListeObjets = null;
            this.m_cmbxSelectTypeTicket.SelectionneurParent = null;
            this.m_cmbxSelectTypeTicket.Size = new System.Drawing.Size(242, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbxSelectTypeTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbxSelectTypeTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbxSelectTypeTicket.TabIndex = 2;
            this.m_cmbxSelectTypeTicket.TextNull = I.T("(empty)|30195");
            this.m_cmbxSelectTypeTicket.Tri = true;
            this.m_cmbxSelectTypeTicket.TypeFormEdition = null;
            this.m_cmbxSelectTypeTicket.SelectionChangeCommitted += new System.EventHandler(this.m_cmbxSelectTypeTicket_SelectionChangeCommitted);
            // 
            // m_cmbxSelectUrgence
            // 
            this.m_cmbxSelectUrgence.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbxSelectUrgence.ComportementLinkStd = true;
            this.m_cmbxSelectUrgence.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbxSelectUrgence.ElementSelectionne = null;
            this.m_cmbxSelectUrgence.FormattingEnabled = true;
            this.m_cmbxSelectUrgence.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbxSelectUrgence, "");
            this.m_cmbxSelectUrgence.LinkProperty = "";
            this.m_cmbxSelectUrgence.ListDonnees = null;
            this.m_cmbxSelectUrgence.Location = new System.Drawing.Point(91, 73);
            this.m_cmbxSelectUrgence.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbxSelectUrgence, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbxSelectUrgence.Name = "m_cmbxSelectUrgence";
            this.m_cmbxSelectUrgence.NullAutorise = false;
            this.m_cmbxSelectUrgence.ProprieteAffichee = null;
            this.m_cmbxSelectUrgence.ProprieteParentListeObjets = null;
            this.m_cmbxSelectUrgence.SelectionneurParent = null;
            this.m_cmbxSelectUrgence.Size = new System.Drawing.Size(242, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbxSelectUrgence, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbxSelectUrgence, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbxSelectUrgence.TabIndex = 3;
            this.m_cmbxSelectUrgence.TextNull = I.T("(empty)|30195");
            this.m_cmbxSelectUrgence.Tri = true;
            this.m_cmbxSelectUrgence.TypeFormEdition = null;
            // 
            // lbl_origine
            // 
            this.lbl_origine.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.lbl_origine, "");
            this.lbl_origine.Location = new System.Drawing.Point(4, 96);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_origine, sc2i.win32.common.TypeModeEdition.Autonome);
            this.lbl_origine.Name = "lbl_origine";
            this.lbl_origine.Size = new System.Drawing.Size(86, 13);
            this.m_extStyle.SetStyleBackColor(this.lbl_origine, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.lbl_origine, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_origine.TabIndex = 0;
            this.lbl_origine.Text = "Origin|654";
            // 
            // m_cmbxSelectContrat
            // 
            this.m_cmbxSelectContrat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbxSelectContrat.ComportementLinkStd = true;
            this.m_cmbxSelectContrat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbxSelectContrat.ElementSelectionne = null;
            this.m_cmbxSelectContrat.FormattingEnabled = true;
            this.m_cmbxSelectContrat.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbxSelectContrat, "");
            this.m_cmbxSelectContrat.LinkProperty = "";
            this.m_cmbxSelectContrat.ListDonnees = null;
            this.m_cmbxSelectContrat.Location = new System.Drawing.Point(91, 33);
            this.m_cmbxSelectContrat.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbxSelectContrat, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbxSelectContrat.Name = "m_cmbxSelectContrat";
            this.m_cmbxSelectContrat.NullAutorise = false;
            this.m_cmbxSelectContrat.ProprieteAffichee = null;
            this.m_cmbxSelectContrat.ProprieteParentListeObjets = null;
            this.m_cmbxSelectContrat.SelectionneurParent = null;
            this.m_cmbxSelectContrat.Size = new System.Drawing.Size(242, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbxSelectContrat, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbxSelectContrat, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbxSelectContrat.TabIndex = 1;
            this.m_cmbxSelectContrat.TextNull = "";
            this.m_cmbxSelectContrat.Tri = true;
            this.m_cmbxSelectContrat.TypeFormEdition = null;
            this.m_cmbxSelectContrat.SelectionChangeCommitted += new System.EventHandler(this.m_cmbxSelectContrat_SelectionChangeCommitted);
            // 
            // lbl_urgence
            // 
            this.m_extLinkField.SetLinkField(this.lbl_urgence, "");
            this.lbl_urgence.Location = new System.Drawing.Point(4, 76);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_urgence, sc2i.win32.common.TypeModeEdition.Autonome);
            this.lbl_urgence.Name = "lbl_urgence";
            this.lbl_urgence.Size = new System.Drawing.Size(86, 16);
            this.m_extStyle.SetStyleBackColor(this.lbl_urgence, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.lbl_urgence, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_urgence.TabIndex = 1;
            this.lbl_urgence.Text = "Urgency|653";
            // 
            // m_txtSelectClient
            // 
            this.m_txtSelectClient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtSelectClient.ElementSelectionne = null;
            this.m_txtSelectClient.FonctionTextNull = null;
            this.m_txtSelectClient.HasLink = false;
            this.m_extLinkField.SetLinkField(this.m_txtSelectClient, "");
            this.m_txtSelectClient.Location = new System.Drawing.Point(91, 13);
            this.m_txtSelectClient.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectClient, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtSelectClient.Name = "m_txtSelectClient";
            this.m_txtSelectClient.SelectedObject = null;
            this.m_txtSelectClient.Size = new System.Drawing.Size(290, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtSelectClient, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSelectClient, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectClient.TabIndex = 0;
            this.m_txtSelectClient.TextNull = "";
            this.m_txtSelectClient.ElementSelectionneChanged += new System.EventHandler(this.m_txtSelectActeurClient_ElementSelectionneChanged);
            // 
            // lbl_client
            // 
            this.m_extLinkField.SetLinkField(this.lbl_client, "");
            this.lbl_client.Location = new System.Drawing.Point(4, 16);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_client, sc2i.win32.common.TypeModeEdition.Autonome);
            this.lbl_client.Name = "lbl_client";
            this.lbl_client.Size = new System.Drawing.Size(86, 16);
            this.m_extStyle.SetStyleBackColor(this.lbl_client, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.lbl_client, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_client.TabIndex = 1;
            this.lbl_client.Text = "Customer|650";
            // 
            // lbl_contrat
            // 
            this.m_extLinkField.SetLinkField(this.lbl_contrat, "");
            this.lbl_contrat.Location = new System.Drawing.Point(4, 36);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_contrat, sc2i.win32.common.TypeModeEdition.Autonome);
            this.lbl_contrat.Name = "lbl_contrat";
            this.lbl_contrat.Size = new System.Drawing.Size(86, 16);
            this.m_extStyle.SetStyleBackColor(this.lbl_contrat, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.lbl_contrat, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_contrat.TabIndex = 1;
            this.lbl_contrat.Text = "Contract|651";
            // 
            // lbl_typeticket
            // 
            this.lbl_typeticket.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.lbl_typeticket, "");
            this.lbl_typeticket.Location = new System.Drawing.Point(4, 56);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_typeticket, sc2i.win32.common.TypeModeEdition.Autonome);
            this.lbl_typeticket.Name = "lbl_typeticket";
            this.lbl_typeticket.Size = new System.Drawing.Size(86, 16);
            this.m_extStyle.SetStyleBackColor(this.lbl_typeticket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.lbl_typeticket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_typeticket.TabIndex = 0;
            this.lbl_typeticket.Text = "Ticket Type|652";
            // 
            // m_panelFormulaireSurOrigine
            // 
            this.m_panelFormulaireSurOrigine.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelFormulaireSurOrigine.ElementEdite = null;
            this.m_extLinkField.SetLinkField(this.m_panelFormulaireSurOrigine, "");
            this.m_panelFormulaireSurOrigine.Location = new System.Drawing.Point(3, 126);
            this.m_panelFormulaireSurOrigine.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelFormulaireSurOrigine, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelFormulaireSurOrigine.Name = "m_panelFormulaireSurOrigine";
            this.m_panelFormulaireSurOrigine.Size = new System.Drawing.Size(386, 229);
            this.m_extStyle.SetStyleBackColor(this.m_panelFormulaireSurOrigine, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelFormulaireSurOrigine, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelFormulaireSurOrigine.TabIndex = 6;
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
            this.m_extLinkField.SetLinkField(this.m_panelChampsCustom, "");
            this.m_panelChampsCustom.Location = new System.Drawing.Point(6, 126);
            this.m_panelChampsCustom.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelChampsCustom, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelChampsCustom.Name = "m_panelChampsCustom";
            this.m_panelChampsCustom.Ombre = false;
            this.m_panelChampsCustom.PositionTop = true;
            this.m_panelChampsCustom.Size = new System.Drawing.Size(386, 229);
            this.m_extStyle.SetStyleBackColor(this.m_panelChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panelChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelChampsCustom.TabIndex = 6;
            this.m_panelChampsCustom.TextColor = System.Drawing.Color.Black;
            // 
            // m_gbDescription
            // 
            this.m_gbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_gbDescription.Controls.Add(this.m_txtDescription);
            this.m_extLinkField.SetLinkField(this.m_gbDescription, "");
            this.m_gbDescription.Location = new System.Drawing.Point(3, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_gbDescription, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_gbDescription.Name = "m_gbDescription";
            this.m_gbDescription.Size = new System.Drawing.Size(392, 119);
            this.m_extStyle.SetStyleBackColor(this.m_gbDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_gbDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_gbDescription.TabIndex = 0;
            this.m_gbDescription.TabStop = false;
            this.m_gbDescription.Text = "General description|655";
            // 
            // m_txtDescription
            // 
            this.m_txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_txtDescription, "DescriptionGenerale");
            this.m_txtDescription.Location = new System.Drawing.Point(3, 17);
            this.m_txtDescription.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtDescription, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtDescription.Multiline = true;
            this.m_txtDescription.Name = "m_txtDescription";
            this.m_txtDescription.Size = new System.Drawing.Size(386, 99);
            this.m_extStyle.SetStyleBackColor(this.m_txtDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtDescription.TabIndex = 0;
            this.m_txtDescription.Text = "[DescriptionGenerale]";
            // 
            // m_btnDetailEtapeSuivante
            // 
            this.m_btnDetailEtapeSuivante.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnDetailEtapeSuivante.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.m_btnDetailEtapeSuivante, "");
            this.m_btnDetailEtapeSuivante.Location = new System.Drawing.Point(667, 371);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnDetailEtapeSuivante, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnDetailEtapeSuivante.Name = "m_btnDetailEtapeSuivante";
            this.m_btnDetailEtapeSuivante.Size = new System.Drawing.Size(139, 23);
            this.m_extStyle.SetStyleBackColor(this.m_btnDetailEtapeSuivante, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnDetailEtapeSuivante, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnDetailEtapeSuivante.TabIndex = 2;
            this.m_btnDetailEtapeSuivante.Text = "Next step >>|672";
            this.m_btnDetailEtapeSuivante.UseVisualStyleBackColor = true;
            this.m_btnDetailEtapeSuivante.Click += new System.EventHandler(this.m_btnDetailEtapeSuivante_Click);
            // 
            // m_tabPageSites
            // 
            this.m_tabPageSites.Controls.Add(this.m_controlEditionEntitesLiees);
            this.m_tabPageSites.Controls.Add(this.m_btnSitesEtapeSuivant);
            this.m_extLinkField.SetLinkField(this.m_tabPageSites, "");
            this.m_tabPageSites.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabPageSites, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_tabPageSites.Name = "m_tabPageSites";
            this.m_tabPageSites.Selected = false;
            this.m_tabPageSites.Size = new System.Drawing.Size(814, 400);
            this.m_extStyle.SetStyleBackColor(this.m_tabPageSites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabPageSites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabPageSites.TabIndex = 16;
            this.m_tabPageSites.Title = "Dependent objects|657";
            // 
            // m_controlEditionEntitesLiees
            // 
            this.m_controlEditionEntitesLiees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_controlEditionEntitesLiees, "");
            this.m_controlEditionEntitesLiees.Location = new System.Drawing.Point(3, 3);
            this.m_controlEditionEntitesLiees.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_controlEditionEntitesLiees, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_controlEditionEntitesLiees.Name = "m_controlEditionEntitesLiees";
            this.m_controlEditionEntitesLiees.Size = new System.Drawing.Size(808, 358);
            this.m_extStyle.SetStyleBackColor(this.m_controlEditionEntitesLiees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_controlEditionEntitesLiees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_controlEditionEntitesLiees.TabIndex = 4;
            // 
            // m_btnSitesEtapeSuivant
            // 
            this.m_btnSitesEtapeSuivant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnSitesEtapeSuivant.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.m_btnSitesEtapeSuivant, "");
            this.m_btnSitesEtapeSuivant.Location = new System.Drawing.Point(667, 371);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnSitesEtapeSuivant, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnSitesEtapeSuivant.Name = "m_btnSitesEtapeSuivant";
            this.m_btnSitesEtapeSuivant.Size = new System.Drawing.Size(139, 23);
            this.m_extStyle.SetStyleBackColor(this.m_btnSitesEtapeSuivant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSitesEtapeSuivant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnSitesEtapeSuivant.TabIndex = 3;
            this.m_btnSitesEtapeSuivant.Text = "Next step >>|672";
            this.m_btnSitesEtapeSuivant.UseVisualStyleBackColor = true;
            this.m_btnSitesEtapeSuivant.Click += new System.EventHandler(this.m_btnSitesEtapeSuivant_Click);
            // 
            // m_tabPageTicketsLies
            // 
            this.m_tabPageTicketsLies.Controls.Add(this.splitContainer1);
            this.m_extLinkField.SetLinkField(this.m_tabPageTicketsLies, "");
            this.m_tabPageTicketsLies.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabPageTicketsLies, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_tabPageTicketsLies.Name = "m_tabPageTicketsLies";
            this.m_tabPageTicketsLies.Selected = false;
            this.m_tabPageTicketsLies.Size = new System.Drawing.Size(814, 400);
            this.m_extStyle.SetStyleBackColor(this.m_tabPageTicketsLies, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabPageTicketsLies, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabPageTicketsLies.TabIndex = 11;
            this.m_tabPageTicketsLies.Title = "Dependent Tickets|659";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.splitContainer1, "");
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m_controlEditDependances);
            this.m_extLinkField.SetLinkField(this.splitContainer1.Panel1, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1.Panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.splitContainer1.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer1.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // splitContainer1.Panel2
            // 
            this.m_extLinkField.SetLinkField(this.splitContainer1.Panel2, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1.Panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.splitContainer1.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer1.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitContainer1.Size = new System.Drawing.Size(814, 400);
            this.splitContainer1.SplitterDistance = 550;
            this.m_extStyle.SetStyleBackColor(this.splitContainer1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitContainer1.TabIndex = 2;
            // 
            // m_controlEditDependances
            // 
            this.m_controlEditDependances.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_controlEditDependances, "");
            this.m_controlEditDependances.Location = new System.Drawing.Point(3, 3);
            this.m_controlEditDependances.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_controlEditDependances, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_controlEditDependances.Name = "m_controlEditDependances";
            this.m_controlEditDependances.Size = new System.Drawing.Size(544, 393);
            this.m_extStyle.SetStyleBackColor(this.m_controlEditDependances, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_controlEditDependances, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_controlEditDependances.TabIndex = 1;
            // 
            // m_tabPageHistorique
            // 
            this.m_tabPageHistorique.Controls.Add(this.m_panelListeHistorique);
            this.m_extLinkField.SetLinkField(this.m_tabPageHistorique, "");
            this.m_tabPageHistorique.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabPageHistorique, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_tabPageHistorique.Name = "m_tabPageHistorique";
            this.m_tabPageHistorique.Selected = false;
            this.m_tabPageHistorique.Size = new System.Drawing.Size(814, 400);
            this.m_extStyle.SetStyleBackColor(this.m_tabPageHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabPageHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabPageHistorique.TabIndex = 12;
            this.m_tabPageHistorique.Title = "History|660";
            // 
            // m_panelListeHistorique
            // 
            this.m_panelListeHistorique.AllowArbre = false;
            this.m_panelListeHistorique.BoutonAjouterVisible = false;
            this.m_panelListeHistorique.BoutonExporterVisible = false;
            this.m_panelListeHistorique.BoutonModifierVisible = false;
            this.m_panelListeHistorique.BoutonSupprimerVisible = false;
            glColumn5.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn5.ActiveControlItems")));
            glColumn5.BackColor = System.Drawing.Color.Transparent;
            glColumn5.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn5.ForColor = System.Drawing.Color.Black;
            glColumn5.ImageIndex = -1;
            glColumn5.IsCheckColumn = false;
            glColumn5.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn5.Name = "Date";
            glColumn5.Propriete = "DateToString";
            glColumn5.Text = "Date";
            glColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn5.Width = 100;
            glColumn6.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn6.ActiveControlItems")));
            glColumn6.BackColor = System.Drawing.Color.Transparent;
            glColumn6.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn6.ForColor = System.Drawing.Color.Black;
            glColumn6.ImageIndex = -1;
            glColumn6.IsCheckColumn = false;
            glColumn6.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn6.Name = "Utilisateur";
            glColumn6.Propriete = "ActeurUtilisateur.Acteur.IdentiteComplete";
            glColumn6.Text = "Utilisateur";
            glColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn6.Width = 100;
            glColumn7.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn7.ActiveControlItems")));
            glColumn7.BackColor = System.Drawing.Color.Transparent;
            glColumn7.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn7.ForColor = System.Drawing.Color.Black;
            glColumn7.ImageIndex = -1;
            glColumn7.IsCheckColumn = false;
            glColumn7.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn7.Name = "Phase";
            glColumn7.Propriete = "PhaseTicket.Libelle";
            glColumn7.Text = "Phase en cours";
            glColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn7.Width = 100;
            glColumn8.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn8.ActiveControlItems")));
            glColumn8.BackColor = System.Drawing.Color.Transparent;
            glColumn8.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn8.ForColor = System.Drawing.Color.Black;
            glColumn8.ImageIndex = -1;
            glColumn8.IsCheckColumn = false;
            glColumn8.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn8.Name = "Info";
            glColumn8.Propriete = "Info";
            glColumn8.Text = "Infos";
            glColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn8.Width = 100;
            this.m_panelListeHistorique.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn5,
            glColumn6,
            glColumn7,
            glColumn8});
            this.m_panelListeHistorique.ContexteUtilisation = "";
            this.m_panelListeHistorique.ControlFiltreStandard = null;
            this.m_panelListeHistorique.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelListeHistorique.ElementSelectionne = null;
            this.m_panelListeHistorique.EnableCustomisation = true;
            this.m_panelListeHistorique.FiltreDeBase = null;
            this.m_panelListeHistorique.FiltreDeBaseEnAjout = false;
            this.m_panelListeHistorique.FiltrePrefere = null;
            this.m_panelListeHistorique.FiltreRapide = null;
            this.m_extLinkField.SetLinkField(this.m_panelListeHistorique, "");
            this.m_panelListeHistorique.ListeObjets = null;
            this.m_panelListeHistorique.Location = new System.Drawing.Point(0, 0);
            this.m_panelListeHistorique.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelListeHistorique, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelListeHistorique.ModeQuickSearch = false;
            this.m_panelListeHistorique.ModeSelection = false;
            this.m_panelListeHistorique.MultiSelect = false;
            this.m_panelListeHistorique.Name = "m_panelListeHistorique";
            this.m_panelListeHistorique.Navigateur = null;
            this.m_panelListeHistorique.ProprieteObjetAEditer = null;
            this.m_panelListeHistorique.QuickSearchText = "";
            this.m_panelListeHistorique.Size = new System.Drawing.Size(814, 400);
            this.m_extStyle.SetStyleBackColor(this.m_panelListeHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListeHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelListeHistorique.TabIndex = 0;
            this.m_panelListeHistorique.TrierAuClicSurEnteteColonne = true;
            // 
            // m_gbInfosGenerales
            // 
            this.m_gbInfosGenerales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_gbInfosGenerales.Controls.Add(this.m_lblEtatCloture);
            this.m_gbInfosGenerales.Controls.Add(this.m_lblDateOuverture);
            this.m_gbInfosGenerales.Controls.Add(this.m_lblDateCloture);
            this.m_gbInfosGenerales.Controls.Add(this.m_lblPhaseEncours);
            this.m_gbInfosGenerales.Controls.Add(this.m_lblResponsable);
            this.m_gbInfosGenerales.Controls.Add(this.m_lblAuteurTicket);
            this.m_gbInfosGenerales.Controls.Add(this.label12);
            this.m_gbInfosGenerales.Controls.Add(this.label25);
            this.m_gbInfosGenerales.Controls.Add(this.label11);
            this.m_gbInfosGenerales.Controls.Add(this.label8);
            this.m_gbInfosGenerales.Controls.Add(this.label1);
            this.m_gbInfosGenerales.Controls.Add(this.label4);
            this.m_extLinkField.SetLinkField(this.m_gbInfosGenerales, "");
            this.m_gbInfosGenerales.Location = new System.Drawing.Point(7, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_gbInfosGenerales, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_gbInfosGenerales.Name = "m_gbInfosGenerales";
            this.m_gbInfosGenerales.Size = new System.Drawing.Size(799, 50);
            this.m_extStyle.SetStyleBackColor(this.m_gbInfosGenerales, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_gbInfosGenerales, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_gbInfosGenerales.TabIndex = 0;
            this.m_gbInfosGenerales.TabStop = false;
            this.m_gbInfosGenerales.Text = "General information|661";
            // 
            // m_lblEtatCloture
            // 
            this.m_lblEtatCloture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblEtatCloture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_extLinkField.SetLinkField(this.m_lblEtatCloture, "");
            this.m_lblEtatCloture.Location = new System.Drawing.Point(671, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblEtatCloture, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblEtatCloture.Name = "m_lblEtatCloture";
            this.m_lblEtatCloture.Size = new System.Drawing.Size(118, 15);
            this.m_extStyle.SetStyleBackColor(this.m_lblEtatCloture, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblEtatCloture, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblEtatCloture.TabIndex = 12;
            // 
            // m_lblDateOuverture
            // 
            this.m_lblDateOuverture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_extLinkField.SetLinkField(this.m_lblDateOuverture, "");
            this.m_lblDateOuverture.Location = new System.Drawing.Point(93, 13);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblDateOuverture, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblDateOuverture.Name = "m_lblDateOuverture";
            this.m_lblDateOuverture.Size = new System.Drawing.Size(118, 15);
            this.m_extStyle.SetStyleBackColor(this.m_lblDateOuverture, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblDateOuverture, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblDateOuverture.TabIndex = 12;
            // 
            // m_lblDateCloture
            // 
            this.m_lblDateCloture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblDateCloture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_extLinkField.SetLinkField(this.m_lblDateCloture, "");
            this.m_lblDateCloture.Location = new System.Drawing.Point(671, 13);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblDateCloture, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblDateCloture.Name = "m_lblDateCloture";
            this.m_lblDateCloture.Size = new System.Drawing.Size(118, 15);
            this.m_extStyle.SetStyleBackColor(this.m_lblDateCloture, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblDateCloture, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblDateCloture.TabIndex = 12;
            // 
            // m_lblPhaseEncours
            // 
            this.m_lblPhaseEncours.AutoSize = true;
            this.m_lblPhaseEncours.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_extLinkField.SetLinkField(this.m_lblPhaseEncours, "PhaseEnCours.Libelle");
            this.m_lblPhaseEncours.Location = new System.Drawing.Point(365, 13);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblPhaseEncours, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblPhaseEncours.Name = "m_lblPhaseEncours";
            this.m_lblPhaseEncours.Size = new System.Drawing.Size(118, 15);
            this.m_extStyle.SetStyleBackColor(this.m_lblPhaseEncours, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblPhaseEncours, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblPhaseEncours.TabIndex = 13;
            this.m_lblPhaseEncours.Text = "[PhaseEnCours.Libelle]";
            // 
            // m_lblResponsable
            // 
            this.m_lblResponsable.AutoSize = true;
            this.m_lblResponsable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_extLinkField.SetLinkField(this.m_lblResponsable, "Responsable.Acteur.IdentiteComplete");
            this.m_lblResponsable.Location = new System.Drawing.Point(365, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblResponsable, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblResponsable.Name = "m_lblResponsable";
            this.m_lblResponsable.Size = new System.Drawing.Size(193, 15);
            this.m_extStyle.SetStyleBackColor(this.m_lblResponsable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblResponsable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblResponsable.TabIndex = 13;
            this.m_lblResponsable.Text = "[Responsable.Acteur.IdentiteComplete]";
            // 
            // m_lblAuteurTicket
            // 
            this.m_lblAuteurTicket.AutoSize = true;
            this.m_lblAuteurTicket.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_extLinkField.SetLinkField(this.m_lblAuteurTicket, "Auteur.Acteur.IdentiteComplete");
            this.m_lblAuteurTicket.Location = new System.Drawing.Point(93, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblAuteurTicket, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblAuteurTicket.Name = "m_lblAuteurTicket";
            this.m_lblAuteurTicket.Size = new System.Drawing.Size(162, 15);
            this.m_extStyle.SetStyleBackColor(this.m_lblAuteurTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblAuteurTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblAuteurTicket.TabIndex = 13;
            this.m_lblAuteurTicket.Text = "[Auteur.Acteur.IdentiteComplete]";
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.Color.DarkRed;
            this.m_extLinkField.SetLinkField(this.label12, "");
            this.label12.Location = new System.Drawing.Point(259, 14);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label12, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(128, 13);
            this.m_extStyle.SetStyleBackColor(this.label12, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label12, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label12.TabIndex = 13;
            this.label12.Text = "Current Phase|664";
            // 
            // label25
            // 
            this.label25.ForeColor = System.Drawing.Color.DarkRed;
            this.m_extLinkField.SetLinkField(this.label25, "");
            this.label25.Location = new System.Drawing.Point(262, 33);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label25, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(102, 13);
            this.m_extStyle.SetStyleBackColor(this.label25, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label25, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label25.TabIndex = 13;
            this.label25.Text = "Assigned to|665";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.ForeColor = System.Drawing.Color.DarkRed;
            this.m_extLinkField.SetLinkField(this.label11, "");
            this.label11.Location = new System.Drawing.Point(578, 14);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label11, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 13);
            this.m_extStyle.SetStyleBackColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label11.TabIndex = 0;
            this.label11.Text = "Closing Date|670";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.ForeColor = System.Drawing.Color.DarkRed;
            this.m_extLinkField.SetLinkField(this.label8, "");
            this.label8.Location = new System.Drawing.Point(578, 33);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label8, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 13);
            this.m_extStyle.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 0;
            this.label8.Text = "Closing state|671";
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 14);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 0;
            this.label1.Text = "Opening date|662";
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.label4.Location = new System.Drawing.Point(6, 33);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 14);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 0;
            this.label4.Text = "Opened by |663";
            // 
            // lbl_ticket
            // 
            this.lbl_ticket.AutoSize = true;
            this.lbl_ticket.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_ticket.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ticket.ForeColor = System.Drawing.Color.DarkRed;
            this.m_extLinkField.SetLinkField(this.lbl_ticket, "");
            this.lbl_ticket.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_ticket, sc2i.win32.common.TypeModeEdition.Autonome);
            this.lbl_ticket.Name = "lbl_ticket";
            this.lbl_ticket.Size = new System.Drawing.Size(124, 24);
            this.m_extStyle.SetStyleBackColor(this.lbl_ticket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.lbl_ticket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_ticket.TabIndex = 0;
            this.lbl_ticket.Text = "Ticket No. |666";
            // 
            // m_panelEntete
            // 
            this.m_panelEntete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelEntete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelEntete.Controls.Add(this.m_panelTitre);
            this.m_panelEntete.Controls.Add(this.m_gbInfosGenerales);
            this.m_panelEntete.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panelEntete, "");
            this.m_panelEntete.Location = new System.Drawing.Point(0, 1);
            this.m_panelEntete.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEntete, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelEntete.Name = "m_panelEntete";
            this.m_panelEntete.Size = new System.Drawing.Size(830, 100);
            this.m_extStyle.SetStyleBackColor(this.m_panelEntete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEntete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEntete.TabIndex = 2;
            // 
            // m_panelTitre
            // 
            this.m_panelTitre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelTitre.Controls.Add(this.m_btnAfficheInfosEntete);
            this.m_panelTitre.Controls.Add(this.m_lblEtatToString);
            this.m_panelTitre.Controls.Add(this.label2);
            this.m_panelTitre.Controls.Add(this.m_lblNumeroTicket);
            this.m_panelTitre.Controls.Add(this.lbl_ticket);
            this.m_extLinkField.SetLinkField(this.m_panelTitre, "");
            this.m_panelTitre.Location = new System.Drawing.Point(7, 2);
            this.m_panelTitre.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelTitre, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelTitre.Name = "m_panelTitre";
            this.m_panelTitre.Size = new System.Drawing.Size(799, 24);
            this.m_extStyle.SetStyleBackColor(this.m_panelTitre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelTitre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelTitre.TabIndex = 4;
            // 
            // m_btnAfficheInfosEntete
            // 
            this.m_btnAfficheInfosEntete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnAfficheInfosEntete.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.m_btnAfficheInfosEntete, "");
            this.m_btnAfficheInfosEntete.Location = new System.Drawing.Point(774, 0);
            this.m_btnAfficheInfosEntete.Margin = new System.Windows.Forms.Padding(0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAfficheInfosEntete, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnAfficheInfosEntete.Name = "m_btnAfficheInfosEntete";
            this.m_btnAfficheInfosEntete.Size = new System.Drawing.Size(25, 20);
            this.m_extStyle.SetStyleBackColor(this.m_btnAfficheInfosEntete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAfficheInfosEntete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAfficheInfosEntete.TabIndex = 3;
            this.m_btnAfficheInfosEntete.Text = "/\\";
            this.m_btnAfficheInfosEntete.UseVisualStyleBackColor = true;
            this.m_btnAfficheInfosEntete.Click += new System.EventHandler(this.m_btnAfficheInfosEntete_Click);
            // 
            // m_lblEtatToString
            // 
            this.m_lblEtatToString.AutoSize = true;
            this.m_lblEtatToString.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lblEtatToString.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblEtatToString.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_lblEtatToString, "EtatToString");
            this.m_lblEtatToString.Location = new System.Drawing.Point(239, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblEtatToString, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblEtatToString.Name = "m_lblEtatToString";
            this.m_lblEtatToString.Size = new System.Drawing.Size(122, 24);
            this.m_extStyle.SetStyleBackColor(this.m_lblEtatToString, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblEtatToString, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblEtatToString.TabIndex = 0;
            this.m_lblEtatToString.Text = "[EtatToString]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(213, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 24);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 0;
            this.label2.Text = " - ";
            // 
            // m_lblNumeroTicket
            // 
            this.m_lblNumeroTicket.AutoSize = true;
            this.m_lblNumeroTicket.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lblNumeroTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblNumeroTicket.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_lblNumeroTicket, "Numero");
            this.m_lblNumeroTicket.Location = new System.Drawing.Point(124, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblNumeroTicket, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblNumeroTicket.Name = "m_lblNumeroTicket";
            this.m_lblNumeroTicket.Size = new System.Drawing.Size(89, 24);
            this.m_extStyle.SetStyleBackColor(this.m_lblNumeroTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblNumeroTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblNumeroTicket.TabIndex = 0;
            this.m_lblNumeroTicket.Text = "[Numero]";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.label20, "");
            this.label20.Location = new System.Drawing.Point(138, 105);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label20, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(80, 13);
            this.m_extStyle.SetStyleBackColor(this.label20, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label20, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label20.TabIndex = 0;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.label18, "");
            this.label18.Location = new System.Drawing.Point(161, 76);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label18, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(58, 13);
            this.m_extStyle.SetStyleBackColor(this.label18, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label18, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label18.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.label5.Location = new System.Drawing.Point(7, 40);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 13);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 0;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.label19, "");
            this.label19.Location = new System.Drawing.Point(7, 127);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label19, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 13);
            this.m_extStyle.SetStyleBackColor(this.label19, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label19, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label19.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.label15, "");
            this.label15.Location = new System.Drawing.Point(7, 20);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label15, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(211, 13);
            this.m_extStyle.SetStyleBackColor(this.label15, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label15, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label15.TabIndex = 0;
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "TypePhase.Libelle";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Phase";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 105;
            // 
            // listViewAutoFilledColumn3
            // 
            this.listViewAutoFilledColumn3.Field = "DateDebutToString";
            this.listViewAutoFilledColumn3.PrecisionWidth = 0;
            this.listViewAutoFilledColumn3.ProportionnalSize = false;
            this.listViewAutoFilledColumn3.Text = "Date début";
            this.listViewAutoFilledColumn3.Visible = true;
            this.listViewAutoFilledColumn3.Width = 99;
            // 
            // listViewAutoFilledColumn6
            // 
            this.listViewAutoFilledColumn6.Field = "DateFinToString";
            this.listViewAutoFilledColumn6.PrecisionWidth = 0;
            this.listViewAutoFilledColumn6.ProportionnalSize = false;
            this.listViewAutoFilledColumn6.Text = "Date fin";
            this.listViewAutoFilledColumn6.Visible = true;
            this.listViewAutoFilledColumn6.Width = 92;
            // 
            // listViewAutoFilledColumn7
            // 
            this.listViewAutoFilledColumn7.Field = "InfosPhase";
            this.listViewAutoFilledColumn7.PrecisionWidth = 0;
            this.listViewAutoFilledColumn7.ProportionnalSize = false;
            this.listViewAutoFilledColumn7.Text = "Infos";
            this.listViewAutoFilledColumn7.Visible = true;
            this.listViewAutoFilledColumn7.Width = 298;
            // 
            // listViewAutoFilledColumn2
            // 
            this.listViewAutoFilledColumn2.DisplayIndex = 1;
            this.listViewAutoFilledColumn2.Field = "DateDebutToString";
            this.listViewAutoFilledColumn2.PrecisionWidth = 0;
            this.listViewAutoFilledColumn2.ProportionnalSize = false;
            this.listViewAutoFilledColumn2.Text = "Date début";
            this.listViewAutoFilledColumn2.Visible = true;
            this.listViewAutoFilledColumn2.Width = 120;
            // 
            // listViewAutoFilledColumn4
            // 
            this.listViewAutoFilledColumn4.Field = "DateFinToString";
            this.listViewAutoFilledColumn4.PrecisionWidth = 0;
            this.listViewAutoFilledColumn4.ProportionnalSize = false;
            this.listViewAutoFilledColumn4.Text = "Date fin";
            this.listViewAutoFilledColumn4.Visible = true;
            this.listViewAutoFilledColumn4.Width = 120;
            // 
            // listViewAutoFilledColumn5
            // 
            this.listViewAutoFilledColumn5.Field = "InfosPhase";
            this.listViewAutoFilledColumn5.PrecisionWidth = 0;
            this.listViewAutoFilledColumn5.ProportionnalSize = false;
            this.listViewAutoFilledColumn5.Text = "Infos";
            this.listViewAutoFilledColumn5.Visible = true;
            this.listViewAutoFilledColumn5.Width = 120;
            // 
            // listViewAutoFilledColumn8
            // 
            this.listViewAutoFilledColumn8.Field = "TypePhase";
            this.listViewAutoFilledColumn8.PrecisionWidth = 0;
            this.listViewAutoFilledColumn8.ProportionnalSize = false;
            this.listViewAutoFilledColumn8.Text = "Liste des Phases";
            this.listViewAutoFilledColumn8.Visible = true;
            this.listViewAutoFilledColumn8.Width = 171;
            // 
            // CPanelEditionTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_panelEntete);
            this.Controls.Add(this.m_tabControl);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CPanelEditionTicket";
            this.Size = new System.Drawing.Size(830, 540);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.m_tabPageResolution.ResumeLayout(false);
            this.m_splitContainer3.Panel1.ResumeLayout(false);
            this.m_splitContainer3.Panel2.ResumeLayout(false);
            this.m_splitContainer3.ResumeLayout(false);
            this.m_panelCacherListePhases.ResumeLayout(false);
            this.m_tabPageDetail.ResumeLayout(false);
            this.m_splitContainer2.Panel1.ResumeLayout(false);
            this.m_splitContainer2.Panel2.ResumeLayout(false);
            this.m_splitContainer2.ResumeLayout(false);
            this.m_gbDtails.ResumeLayout(false);
            this.m_gbDescription.ResumeLayout(false);
            this.m_gbDescription.PerformLayout();
            this.m_tabPageSites.ResumeLayout(false);
            this.m_tabPageTicketsLies.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.m_tabPageHistorique.ResumeLayout(false);
            this.m_gbInfosGenerales.ResumeLayout(false);
            this.m_gbInfosGenerales.PerformLayout();
            this.m_panelEntete.ResumeLayout(false);
            this.m_panelEntete.PerformLayout();
            this.m_panelTitre.ResumeLayout(false);
            this.m_panelTitre.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.CExtStyle m_extStyle;
        private sc2i.win32.common.C2iTabControl m_tabControl;
        private Crownwood.Magic.Controls.TabPage m_tabPageDetail;
        private System.Windows.Forms.GroupBox m_gbInfosGenerales;
        private System.Windows.Forms.SplitContainer m_splitContainer2;
        private System.Windows.Forms.GroupBox m_gbDtails;
        private System.Windows.Forms.GroupBox m_gbDescription;
        private Crownwood.Magic.Controls.TabPage m_tabPageTicketsLies;
        private Crownwood.Magic.Controls.TabPage m_tabPageHistorique;
        private System.Windows.Forms.Label lbl_ticket;
        private sc2i.win32.common.CToolTipTraductible m_toolTipTraductible;
        private sc2i.win32.common.C2iTextBox m_txtDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_client;
        private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_txtSelectClient;
        private System.Windows.Forms.Label lbl_typeticket;
        private System.Windows.Forms.Label label8;
        private sc2i.win32.common.C2iPanelOmbre m_panelEntete;
        private sc2i.win32.common.CExtLinkField m_extLinkField;
        private System.Windows.Forms.Label m_lblNumeroTicket;
        private System.Windows.Forms.Label m_lblEtatToString;
        private System.Windows.Forms.Label lbl_origine;
        private System.Windows.Forms.Label label11;
        private sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees m_cmbxSelectTypeTicket;
        private sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees m_cmbxSelectOrigineTicket;
        private sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees m_cmbxSelectContrat;
        private System.Windows.Forms.Label lbl_contrat;
        private sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees m_cmbxSelectUrgence;
        private System.Windows.Forms.Label lbl_urgence;
        private sc2i.win32.data.dynamic.CPanelChampsCustom m_panelChampsCustom;
        protected sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
        private sc2i.formulaire.win32.editor.CPanelFormulaireSurElement m_panelFormulaireSurOrigine;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn1;
        private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn2;
        private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn3;
        private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn4;
        private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn5;
        private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn6;
        private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn7;
        private timos.CControlEditionDependancesTicket m_controlEditDependances;
        private System.Windows.Forms.Label label25;
        private Crownwood.Magic.Controls.TabPage m_tabPageResolution;
        private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn8;
        private CPanelEditionPhase m_panelEditionPhase;
        private sc2i.win32.common.CListLink m_listePhases;
        private System.Windows.Forms.Label m_lblListeEtapes;
        private System.Windows.Forms.LinkLabel m_lnkPhaseSuivante;
        private System.Windows.Forms.Button m_btnDetailEtapeSuivante;
        private Crownwood.Magic.Controls.TabPage m_tabPageSites;
        private System.Windows.Forms.Button m_btnSitesEtapeSuivant;
        private CControlEditionEntitesLiees m_controlEditionEntitesLiees;
        private System.Windows.Forms.Panel m_panelCacherListePhases;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label m_lblAuteurTicket;
        private sc2i.win32.data.navigation.CPanelListeSpeedStandard m_panelListeHistorique;
        private System.Windows.Forms.Label m_lblDateCloture;
        private System.Windows.Forms.Label m_lblEtatCloture;
        private System.Windows.Forms.Label m_lblDateOuverture;
        private System.Windows.Forms.Label m_lblResponsable;
        private System.Windows.Forms.Label m_lblPhaseEncours;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.LinkLabel m_lnkCloreTicket;
        private System.Windows.Forms.Button m_btnAfficheInfosEntete;
        private sc2i.win32.common.C2iPanel m_panelTitre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer m_splitContainer3;
    }
}
