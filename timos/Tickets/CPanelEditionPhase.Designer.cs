namespace timos
{
    partial class CPanelEditionPhase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPanelEditionPhase));
            sc2i.win32.common.GLColumn glColumn9 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn10 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn11 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn12 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn13 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn14 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn15 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn16 = new sc2i.win32.common.GLColumn();
            this.m_panelEnTete = new sc2i.win32.common.C2iPanel(this.components);
            this.m_lblTypePhaseEnCours = new System.Windows.Forms.Label();
            this.m_lblMessageEntete = new System.Windows.Forms.Label();
            this.m_lnkQuiAppeler = new System.Windows.Forms.LinkLabel();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_tabPageInfos = new Crownwood.Magic.Controls.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_panelConteneurNotes = new System.Windows.Forms.Panel();
            this.m_ctrlSaisiesOperations = new timos.CControleSaisiesOperations();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.m_panelFormulaireSurTypePhase = new sc2i.formulaire.win32.editor.CPanelFormulaireSurElement();
            this.m_controlSaisieInfosCloture = new timos.CControlSaisieInfosCloture();
            this.m_tabPageInterventions = new Crownwood.Magic.Controls.TabPage();
            this.m_panelBtnAjouter = new sc2i.win32.common.C2iPanelFondDegradeStd();
            this.m_lnkAjouterIntervention = new sc2i.win32.common.CWndLinkStd();
            this.m_chkAfficherQueLesIntersDeLaPhase = new System.Windows.Forms.CheckBox();
            this.m_panelListeInterventions = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_tabPageGel = new Crownwood.Magic.Controls.TabPage();
            this.m_panelInfoGel = new timos.interventions.CPanelInfoGel();
            this.col_date = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.col_utilisateur = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.col_synthese = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_extLinkField = new sc2i.win32.common.CExtLinkField();
            this.m_toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.m_panelEnTete.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.m_tabPageInfos.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.m_panelConteneurNotes.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.m_tabPageInterventions.SuspendLayout();
            this.m_panelBtnAjouter.SuspendLayout();
            this.m_tabPageGel.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelEnTete
            // 
            this.m_panelEnTete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelEnTete.Controls.Add(this.m_lblTypePhaseEnCours);
            this.m_panelEnTete.Controls.Add(this.m_lblMessageEntete);
            this.m_panelEnTete.Controls.Add(this.m_lnkQuiAppeler);
            this.m_panelEnTete.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelEnTete.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panelEnTete, "");
            this.m_panelEnTete.Location = new System.Drawing.Point(0, 0);
            this.m_panelEnTete.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEnTete, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelEnTete.Name = "m_panelEnTete";
            this.m_panelEnTete.Size = new System.Drawing.Size(784, 26);
            this.m_extStyle.SetStyleBackColor(this.m_panelEnTete, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panelEnTete, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelEnTete.TabIndex = 0;
            // 
            // m_lblTypePhaseEnCours
            // 
            this.m_lblTypePhaseEnCours.AutoSize = true;
            this.m_lblTypePhaseEnCours.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblTypePhaseEnCours.ForeColor = System.Drawing.Color.DarkRed;
            this.m_extLinkField.SetLinkField(this.m_lblTypePhaseEnCours, "Libelle");
            this.m_lblTypePhaseEnCours.Location = new System.Drawing.Point(3, 4);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblTypePhaseEnCours, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblTypePhaseEnCours.Name = "m_lblTypePhaseEnCours";
            this.m_lblTypePhaseEnCours.Size = new System.Drawing.Size(101, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lblTypePhaseEnCours, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblTypePhaseEnCours, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblTypePhaseEnCours.TabIndex = 5;
            this.m_lblTypePhaseEnCours.Text = "[Label]|30263";
            // 
            // m_lblMessageEntete
            // 
            this.m_lblMessageEntete.AutoSize = true;
            this.m_lblMessageEntete.ForeColor = System.Drawing.Color.Red;
            this.m_extLinkField.SetLinkField(this.m_lblMessageEntete, "");
            this.m_lblMessageEntete.Location = new System.Drawing.Point(231, 7);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblMessageEntete, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblMessageEntete.Name = "m_lblMessageEntete";
            this.m_lblMessageEntete.Size = new System.Drawing.Size(236, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblMessageEntete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblMessageEntete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblMessageEntete.TabIndex = 5;
            this.m_lblMessageEntete.Text = "You do not have the rights to edit this Phase|532";
            // 
            // m_lnkQuiAppeler
            // 
            this.m_lnkQuiAppeler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lnkQuiAppeler.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lnkQuiAppeler, "");
            this.m_lnkQuiAppeler.Location = new System.Drawing.Point(675, 7);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkQuiAppeler, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lnkQuiAppeler.Name = "m_lnkQuiAppeler";
            this.m_lnkQuiAppeler.Size = new System.Drawing.Size(96, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkQuiAppeler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkQuiAppeler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkQuiAppeler.TabIndex = 7;
            this.m_lnkQuiAppeler.TabStop = true;
            this.m_lnkQuiAppeler.Text = "Persons to call|536";
            this.m_lnkQuiAppeler.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkQuiAppeler_LinkClicked);
            // 
            // m_tabControl
            // 
            this.m_tabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_tabControl.BoldSelectedPage = true;
            this.m_tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tabControl.ForeColor = System.Drawing.Color.Black;
            this.m_tabControl.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_tabControl, "");
            this.m_tabControl.Location = new System.Drawing.Point(0, 26);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = false;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 2;
            this.m_tabControl.SelectedTab = this.m_tabPageGel;
            this.m_tabControl.Size = new System.Drawing.Size(784, 333);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 1;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_tabPageInfos,
            this.m_tabPageInterventions,
            this.m_tabPageGel});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_tabPageInfos
            // 
            this.m_tabPageInfos.Controls.Add(this.splitContainer1);
            this.m_extLinkField.SetLinkField(this.m_tabPageInfos, "");
            this.m_tabPageInfos.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabPageInfos, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_tabPageInfos.Name = "m_tabPageInfos";
            this.m_tabPageInfos.Size = new System.Drawing.Size(784, 308);
            this.m_extStyle.SetStyleBackColor(this.m_tabPageInfos, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabPageInfos, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabPageInfos.TabIndex = 10;
            this.m_tabPageInfos.Title = "Information|119";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.splitContainer1, "");
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m_panelConteneurNotes);
            this.m_extLinkField.SetLinkField(this.splitContainer1.Panel1, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1.Panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.splitContainer1.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer1.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.m_extLinkField.SetLinkField(this.splitContainer1.Panel2, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1.Panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.splitContainer1.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer1.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitContainer1.Size = new System.Drawing.Size(784, 308);
            this.splitContainer1.SplitterDistance = 156;
            this.m_extStyle.SetStyleBackColor(this.splitContainer1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitContainer1.TabIndex = 10;
            // 
            // m_panelConteneurNotes
            // 
            this.m_panelConteneurNotes.Controls.Add(this.m_ctrlSaisiesOperations);
            this.m_panelConteneurNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelConteneurNotes, "");
            this.m_panelConteneurNotes.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelConteneurNotes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelConteneurNotes.Name = "m_panelConteneurNotes";
            this.m_panelConteneurNotes.Size = new System.Drawing.Size(780, 152);
            this.m_extStyle.SetStyleBackColor(this.m_panelConteneurNotes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelConteneurNotes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelConteneurNotes.TabIndex = 10;
            // 
            // m_ctrlSaisiesOperations
            // 
            this.m_ctrlSaisiesOperations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_ctrlSaisiesOperations, "");
            this.m_ctrlSaisiesOperations.Location = new System.Drawing.Point(0, 0);
            this.m_ctrlSaisiesOperations.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_ctrlSaisiesOperations, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_ctrlSaisiesOperations.Name = "m_ctrlSaisiesOperations";
            this.m_ctrlSaisiesOperations.PanelEnteteVisible = false;
            this.m_ctrlSaisiesOperations.Size = new System.Drawing.Size(780, 152);
            this.m_extStyle.SetStyleBackColor(this.m_ctrlSaisiesOperations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_ctrlSaisiesOperations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ctrlSaisiesOperations.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.splitContainer2, "");
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.m_panelFormulaireSurTypePhase);
            this.m_extLinkField.SetLinkField(this.splitContainer2.Panel1, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer2.Panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.splitContainer2.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer2.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.m_controlSaisieInfosCloture);
            this.m_extLinkField.SetLinkField(this.splitContainer2.Panel2, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer2.Panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.splitContainer2.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer2.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitContainer2.Size = new System.Drawing.Size(784, 148);
            this.splitContainer2.SplitterDistance = 386;
            this.m_extStyle.SetStyleBackColor(this.splitContainer2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitContainer2.TabIndex = 2;
            // 
            // m_panelFormulaireSurTypePhase
            // 
            this.m_panelFormulaireSurTypePhase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelFormulaireSurTypePhase.ElementEdite = null;
            this.m_extLinkField.SetLinkField(this.m_panelFormulaireSurTypePhase, "");
            this.m_panelFormulaireSurTypePhase.Location = new System.Drawing.Point(0, 0);
            this.m_panelFormulaireSurTypePhase.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelFormulaireSurTypePhase, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelFormulaireSurTypePhase.Name = "m_panelFormulaireSurTypePhase";
            this.m_panelFormulaireSurTypePhase.Size = new System.Drawing.Size(382, 144);
            this.m_extStyle.SetStyleBackColor(this.m_panelFormulaireSurTypePhase, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelFormulaireSurTypePhase, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelFormulaireSurTypePhase.TabIndex = 1;
            // 
            // m_controlSaisieInfosCloture
            // 
            this.m_controlSaisieInfosCloture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_controlSaisieInfosCloture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_controlSaisieInfosCloture.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_controlSaisieInfosCloture, "");
            this.m_controlSaisieInfosCloture.Location = new System.Drawing.Point(0, 0);
            this.m_controlSaisieInfosCloture.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_controlSaisieInfosCloture, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_controlSaisieInfosCloture.Name = "m_controlSaisieInfosCloture";
            this.m_controlSaisieInfosCloture.Size = new System.Drawing.Size(390, 144);
            this.m_extStyle.SetStyleBackColor(this.m_controlSaisieInfosCloture, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_controlSaisieInfosCloture, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_controlSaisieInfosCloture.TabIndex = 2;
            // 
            // m_tabPageInterventions
            // 
            this.m_tabPageInterventions.Controls.Add(this.m_panelBtnAjouter);
            this.m_tabPageInterventions.Controls.Add(this.m_chkAfficherQueLesIntersDeLaPhase);
            this.m_tabPageInterventions.Controls.Add(this.m_panelListeInterventions);
            this.m_extLinkField.SetLinkField(this.m_tabPageInterventions, "");
            this.m_tabPageInterventions.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabPageInterventions, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_tabPageInterventions.Name = "m_tabPageInterventions";
            this.m_tabPageInterventions.Selected = false;
            this.m_tabPageInterventions.Size = new System.Drawing.Size(784, 308);
            this.m_extStyle.SetStyleBackColor(this.m_tabPageInterventions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabPageInterventions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabPageInterventions.TabIndex = 12;
            this.m_tabPageInterventions.Title = "Interventions|344";
            // 
            // m_panelBtnAjouter
            // 
            this.m_panelBtnAjouter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_panelBtnAjouter.BackgroundImage")));
            this.m_panelBtnAjouter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_panelBtnAjouter.Controls.Add(this.m_lnkAjouterIntervention);
            this.m_extLinkField.SetLinkField(this.m_panelBtnAjouter, "");
            this.m_panelBtnAjouter.Location = new System.Drawing.Point(96, 4);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelBtnAjouter, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelBtnAjouter.Name = "m_panelBtnAjouter";
            this.m_panelBtnAjouter.Size = new System.Drawing.Size(101, 24);
            this.m_extStyle.SetStyleBackColor(this.m_panelBtnAjouter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelBtnAjouter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelBtnAjouter.TabIndex = 3;
            // 
            // m_lnkAjouterIntervention
            // 
            this.m_lnkAjouterIntervention.BackColor = System.Drawing.Color.Transparent;
            this.m_lnkAjouterIntervention.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAjouterIntervention.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lnkAjouterIntervention.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkAjouterIntervention, "");
            this.m_lnkAjouterIntervention.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAjouterIntervention, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkAjouterIntervention.Name = "m_lnkAjouterIntervention";
            this.m_lnkAjouterIntervention.Size = new System.Drawing.Size(101, 24);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAjouterIntervention, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAjouterIntervention, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAjouterIntervention.TabIndex = 1;
            this.m_lnkAjouterIntervention.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAjouterIntervention.LinkClicked += new System.EventHandler(this.m_lnkAjouterIntervention_LinkClicked);
            // 
            // m_chkAfficherQueLesIntersDeLaPhase
            // 
            this.m_chkAfficherQueLesIntersDeLaPhase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_chkAfficherQueLesIntersDeLaPhase.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkAfficherQueLesIntersDeLaPhase, "");
            this.m_chkAfficherQueLesIntersDeLaPhase.Location = new System.Drawing.Point(6, 288);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkAfficherQueLesIntersDeLaPhase, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_chkAfficherQueLesIntersDeLaPhase.Name = "m_chkAfficherQueLesIntersDeLaPhase";
            this.m_chkAfficherQueLesIntersDeLaPhase.Size = new System.Drawing.Size(253, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkAfficherQueLesIntersDeLaPhase, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkAfficherQueLesIntersDeLaPhase, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkAfficherQueLesIntersDeLaPhase.TabIndex = 2;
            this.m_chkAfficherQueLesIntersDeLaPhase.Text = "Display only current phase interventions|10012";
            this.m_chkAfficherQueLesIntersDeLaPhase.UseVisualStyleBackColor = true;
            this.m_chkAfficherQueLesIntersDeLaPhase.CheckedChanged += new System.EventHandler(this.m_chkAfficherQueLesIntersDeLaPhase_CheckedChanged);
            // 
            // m_panelListeInterventions
            // 
            this.m_panelListeInterventions.AllowArbre = false;
            this.m_panelListeInterventions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelListeInterventions.BoutonAjouterVisible = false;
            this.m_panelListeInterventions.BoutonExporterVisible = false;
            this.m_panelListeInterventions.BoutonSupprimerVisible = false;
            glColumn9.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn9.ActiveControlItems")));
            glColumn9.BackColor = System.Drawing.Color.Transparent;
            glColumn9.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn9.ForColor = System.Drawing.Color.Black;
            glColumn9.ImageIndex = -1;
            glColumn9.IsCheckColumn = false;
            glColumn9.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn9.Name = "TypeIntervention";
            glColumn9.Propriete = "TypeIntervention.Libelle";
            glColumn9.Text = "Type d\'intervention";
            glColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn9.Width = 100;
            glColumn10.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn10.ActiveControlItems")));
            glColumn10.BackColor = System.Drawing.Color.Transparent;
            glColumn10.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn10.ForColor = System.Drawing.Color.Black;
            glColumn10.ImageIndex = -1;
            glColumn10.IsCheckColumn = false;
            glColumn10.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn10.Name = "Site";
            glColumn10.Propriete = "ElementLiePrincipal.Libelle";
            glColumn10.Text = "Site";
            glColumn10.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn10.Width = 100;
            glColumn11.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn11.ActiveControlItems")));
            glColumn11.BackColor = System.Drawing.Color.Transparent;
            glColumn11.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn11.ForColor = System.Drawing.Color.Black;
            glColumn11.ImageIndex = -1;
            glColumn11.IsCheckColumn = false;
            glColumn11.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn11.Name = "UserPrePlanifieur";
            glColumn11.Propriete = "UserPrePlanifieur.Acteur.IdentiteComplete";
            glColumn11.Text = "Pré-planifieur";
            glColumn11.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn11.Width = 100;
            glColumn12.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn12.ActiveControlItems")));
            glColumn12.BackColor = System.Drawing.Color.Transparent;
            glColumn12.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn12.ForColor = System.Drawing.Color.Black;
            glColumn12.ImageIndex = -1;
            glColumn12.IsCheckColumn = false;
            glColumn12.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn12.Name = "DateDebutPrePlanifie";
            glColumn12.Propriete = "DateDebutPrePlanifieToString";
            glColumn12.Text = "Date début pré-planifiée";
            glColumn12.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn12.Width = 100;
            glColumn13.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn13.ActiveControlItems")));
            glColumn13.BackColor = System.Drawing.Color.Transparent;
            glColumn13.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn13.ForColor = System.Drawing.Color.Black;
            glColumn13.ImageIndex = -1;
            glColumn13.IsCheckColumn = false;
            glColumn13.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn13.Name = "DateFinPreplanifie";
            glColumn13.Propriete = "DateFinPrePlanifieToString";
            glColumn13.Text = "Date fin pré-planifiée";
            glColumn13.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn13.Width = 100;
            glColumn14.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn14.ActiveControlItems")));
            glColumn14.BackColor = System.Drawing.Color.Transparent;
            glColumn14.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn14.ForColor = System.Drawing.Color.Black;
            glColumn14.ImageIndex = -1;
            glColumn14.IsCheckColumn = false;
            glColumn14.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn14.Name = "UserPlanifieur";
            glColumn14.Propriete = "UserPlanifieur.Acteur.IdentiteComplete";
            glColumn14.Text = "Planifieur";
            glColumn14.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn14.Width = 100;
            glColumn15.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn15.ActiveControlItems")));
            glColumn15.BackColor = System.Drawing.Color.Transparent;
            glColumn15.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn15.ForColor = System.Drawing.Color.Black;
            glColumn15.ImageIndex = -1;
            glColumn15.IsCheckColumn = false;
            glColumn15.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn15.Name = "DateDebutPlanifie";
            glColumn15.Propriete = "DateDebutPlanifieToString";
            glColumn15.Text = "Date début planifiée";
            glColumn15.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn15.Width = 100;
            glColumn16.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn16.ActiveControlItems")));
            glColumn16.BackColor = System.Drawing.Color.Transparent;
            glColumn16.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn16.ForColor = System.Drawing.Color.Black;
            glColumn16.ImageIndex = -1;
            glColumn16.IsCheckColumn = false;
            glColumn16.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn16.Name = "DateFinPlanifie";
            glColumn16.Propriete = "DateFinPlanifieToString";
            glColumn16.Text = "Date fin planifiée";
            glColumn16.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn16.Width = 100;
            this.m_panelListeInterventions.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn9,
            glColumn10,
            glColumn11,
            glColumn12,
            glColumn13,
            glColumn14,
            glColumn15,
            glColumn16});
            this.m_panelListeInterventions.ContexteUtilisation = "";
            this.m_panelListeInterventions.ControlFiltreStandard = null;
            this.m_panelListeInterventions.ElementSelectionne = null;
            this.m_panelListeInterventions.EnableCustomisation = true;
            this.m_panelListeInterventions.FiltreDeBase = null;
            this.m_panelListeInterventions.FiltreDeBaseEnAjout = false;
            this.m_panelListeInterventions.FiltrePrefere = null;
            this.m_panelListeInterventions.FiltreRapide = null;
            this.m_extLinkField.SetLinkField(this.m_panelListeInterventions, "");
            this.m_panelListeInterventions.ListeObjets = null;
            this.m_panelListeInterventions.Location = new System.Drawing.Point(3, 3);
            this.m_panelListeInterventions.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelListeInterventions, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelListeInterventions.ModeQuickSearch = false;
            this.m_panelListeInterventions.ModeSelection = false;
            this.m_panelListeInterventions.MultiSelect = false;
            this.m_panelListeInterventions.Name = "m_panelListeInterventions";
            this.m_panelListeInterventions.Navigateur = null;
            this.m_panelListeInterventions.ProprieteObjetAEditer = null;
            this.m_panelListeInterventions.QuickSearchText = "";
            this.m_panelListeInterventions.Size = new System.Drawing.Size(778, 280);
            this.m_extStyle.SetStyleBackColor(this.m_panelListeInterventions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListeInterventions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelListeInterventions.TabIndex = 0;
            this.m_panelListeInterventions.TrierAuClicSurEnteteColonne = true;
            // 
            // m_tabPageGel
            // 
            this.m_tabPageGel.Controls.Add(this.m_panelInfoGel);
            this.m_extLinkField.SetLinkField(this.m_tabPageGel, "");
            this.m_tabPageGel.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabPageGel, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_tabPageGel.Name = "m_tabPageGel";
            this.m_tabPageGel.Size = new System.Drawing.Size(784, 308);
            this.m_extStyle.SetStyleBackColor(this.m_tabPageGel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabPageGel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabPageGel.TabIndex = 11;
            this.m_tabPageGel.Title = "Freezing|644";
            // 
            // m_panelInfoGel
            // 
            this.m_extLinkField.SetLinkField(this.m_panelInfoGel, "");
            this.m_panelInfoGel.Location = new System.Drawing.Point(3, 3);
            this.m_panelInfoGel.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelInfoGel, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelInfoGel.Name = "m_panelInfoGel";
            this.m_panelInfoGel.Size = new System.Drawing.Size(778, 302);
            this.m_extStyle.SetStyleBackColor(this.m_panelInfoGel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelInfoGel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelInfoGel.TabIndex = 0;
            this.m_panelInfoGel.OnChangeEtatGel += new System.EventHandler(this.m_panelInfoGel_OnChangeEtatGel);
            // 
            // col_date
            // 
            this.col_date.Field = "DateToString";
            this.col_date.PrecisionWidth = 0;
            this.col_date.ProportionnalSize = false;
            this.col_date.Text = "Date|246";
            this.col_date.Visible = true;
            this.col_date.Width = 104;
            // 
            // col_utilisateur
            // 
            this.col_utilisateur.Field = "ActeurUtilisateur.Acteur.IdentiteComplete";
            this.col_utilisateur.PrecisionWidth = 0;
            this.col_utilisateur.ProportionnalSize = false;
            this.col_utilisateur.Text = "User|646";
            this.col_utilisateur.Visible = true;
            this.col_utilisateur.Width = 113;
            // 
            // col_synthese
            // 
            this.col_synthese.Field = "Texte";
            this.col_synthese.PrecisionWidth = 0;
            this.col_synthese.ProportionnalSize = false;
            this.col_synthese.Text = "Synthesis|645";
            this.col_synthese.Visible = true;
            this.col_synthese.Width = 501;
            // 
            // CPanelEditionPhase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.m_panelEnTete);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CPanelEditionPhase";
            this.Size = new System.Drawing.Size(784, 359);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEnTete.ResumeLayout(false);
            this.m_panelEnTete.PerformLayout();
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.m_tabPageInfos.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.m_panelConteneurNotes.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.m_tabPageInterventions.ResumeLayout(false);
            this.m_tabPageInterventions.PerformLayout();
            this.m_panelBtnAjouter.ResumeLayout(false);
            this.m_tabPageGel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.C2iPanel m_panelEnTete;
        private sc2i.win32.common.C2iTabControl m_tabControl;
        private sc2i.win32.common.CExtLinkField m_extLinkField;
        protected sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
        private sc2i.win32.common.CExtStyle m_extStyle;
        private Crownwood.Magic.Controls.TabPage m_tabPageInfos;
        private Crownwood.Magic.Controls.TabPage m_tabPageGel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private sc2i.formulaire.win32.editor.CPanelFormulaireSurElement m_panelFormulaireSurTypePhase;
        private Crownwood.Magic.Controls.TabPage m_tabPageInterventions;
		private timos.interventions.CPanelInfoGel m_panelInfoGel;
		private System.Windows.Forms.LinkLabel m_lnkQuiAppeler;
        private sc2i.win32.common.CWndLinkStd m_lnkAjouterIntervention;
        private sc2i.win32.data.navigation.CPanelListeSpeedStandard m_panelListeInterventions;
        private CControlSaisieInfosCloture m_controlSaisieInfosCloture;
        private System.Windows.Forms.Panel m_panelConteneurNotes;
        private System.Windows.Forms.Label m_lblTypePhaseEnCours;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private sc2i.win32.common.ListViewAutoFilledColumn col_date;
        private sc2i.win32.common.ListViewAutoFilledColumn col_utilisateur;
        private sc2i.win32.common.ListViewAutoFilledColumn col_synthese;
        private System.Windows.Forms.ToolTip m_toolTip;
        private System.Windows.Forms.Label m_lblMessageEntete;
        private System.Windows.Forms.CheckBox m_chkAfficherQueLesIntersDeLaPhase;
        private sc2i.win32.common.C2iPanelFondDegradeStd m_panelBtnAjouter;
        private CControleSaisiesOperations m_ctrlSaisiesOperations;
    }
}
