namespace timos.Elements_communs
{
    partial class CControlGED
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CControlGED));
            sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
            this.m_panelConsultationHierarchique = new sc2i.win32.common.C2iPanel(this.components);
            this.m_arbreConsultation = new timos.Parametrage.ConsultationHierarchique.CArbreConsultationHierarchique();
            this.m_panelTopLeft = new sc2i.win32.common.C2iPanel(this.components);
            this.m_cmbArbreHierarchique = new sc2i.win32.data.CComboBoxListeObjetsDonnees();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_arbreCategories = new sc2i.win32.data.CArbreObjetsDonneesHierarchiques();
            this.m_panelCategories = new System.Windows.Forms.Panel();
            this.m_panelBottomCategories = new System.Windows.Forms.Panel();
            this.m_chkToutesCategories = new System.Windows.Forms.CheckBox();
            this.m_panelTopCategories = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.m_panelHaut = new System.Windows.Forms.Panel();
            this.m_panelBas = new System.Windows.Forms.Panel();
            this.m_chkTousDocuments = new System.Windows.Forms.CheckBox();
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_panelInfoSelectionEnCours = new System.Windows.Forms.Panel();
            this.m_lnkDissocierElementEnCours = new System.Windows.Forms.LinkLabel();
            this.m_labelElementSelectionne = new System.Windows.Forms.Label();
            this.m_panelListDocumentsGED = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_lblInfoDragDrop = new System.Windows.Forms.Label();
            this.m_panelModeStockage = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.m_cmbModeStockage = new sc2i.win32.common.CComboboxAutoFilled();
            this.m_tooltipTraductible = new sc2i.win32.common.CToolTipTraductible(this.components);
            this.m_lblDragExisting = new System.Windows.Forms.Label();
            this.m_panelConsultationHierarchique.SuspendLayout();
            this.m_panelTopLeft.SuspendLayout();
            this.m_panelCategories.SuspendLayout();
            this.m_panelBottomCategories.SuspendLayout();
            this.m_panelTopCategories.SuspendLayout();
            this.m_panelBas.SuspendLayout();
            this.m_panelInfoSelectionEnCours.SuspendLayout();
            this.m_panelModeStockage.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelConsultationHierarchique
            // 
            this.m_panelConsultationHierarchique.Controls.Add(this.m_arbreConsultation);
            this.m_panelConsultationHierarchique.Controls.Add(this.m_panelTopLeft);
            this.m_panelConsultationHierarchique.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelConsultationHierarchique.Location = new System.Drawing.Point(0, 45);
            this.m_panelConsultationHierarchique.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelConsultationHierarchique, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelConsultationHierarchique.Name = "m_panelConsultationHierarchique";
            this.m_panelConsultationHierarchique.Size = new System.Drawing.Size(193, 382);
            this.m_panelConsultationHierarchique.TabIndex = 1;
            // 
            // m_arbreConsultation
            // 
            this.m_arbreConsultation.AllowDrop = true;
            this.m_arbreConsultation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_arbreConsultation.HideSelection = false;
            this.m_arbreConsultation.ImageIndex = 0;
            this.m_arbreConsultation.Location = new System.Drawing.Point(0, 31);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_arbreConsultation, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_arbreConsultation.Name = "m_arbreConsultation";
            this.m_arbreConsultation.SelectedImageIndex = 0;
            this.m_arbreConsultation.Size = new System.Drawing.Size(193, 351);
            this.m_arbreConsultation.TabIndex = 0;
            this.m_arbreConsultation.DragLeave += new System.EventHandler(this.m_arbreConsultation_DragLeave);
            this.m_arbreConsultation.DragDrop += new System.Windows.Forms.DragEventHandler(this.m_arbreConsultation_DragDrop);
            this.m_arbreConsultation.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_arbreConsultation_AfterSelect);
            this.m_arbreConsultation.DragEnter += new System.Windows.Forms.DragEventHandler(this.m_arbreConsultation_DragEnter);
            this.m_arbreConsultation.DragOver += new System.Windows.Forms.DragEventHandler(this.m_arbreConsultation_DragOver);
            // 
            // m_panelTopLeft
            // 
            this.m_panelTopLeft.Controls.Add(this.m_cmbArbreHierarchique);
            this.m_panelTopLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelTopLeft.Location = new System.Drawing.Point(0, 0);
            this.m_panelTopLeft.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelTopLeft, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelTopLeft.Name = "m_panelTopLeft";
            this.m_panelTopLeft.Size = new System.Drawing.Size(193, 31);
            this.m_panelTopLeft.TabIndex = 1;
            // 
            // m_cmbArbreHierarchique
            // 
            this.m_cmbArbreHierarchique.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbArbreHierarchique.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbArbreHierarchique.ElementSelectionne = null;
            this.m_cmbArbreHierarchique.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbArbreHierarchique.FormattingEnabled = true;
            this.m_cmbArbreHierarchique.IsLink = false;
            this.m_cmbArbreHierarchique.ListDonnees = null;
            this.m_cmbArbreHierarchique.Location = new System.Drawing.Point(3, 5);
            this.m_cmbArbreHierarchique.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbArbreHierarchique, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_cmbArbreHierarchique.Name = "m_cmbArbreHierarchique";
            this.m_cmbArbreHierarchique.NullAutorise = false;
            this.m_cmbArbreHierarchique.ProprieteAffichee = null;
            this.m_cmbArbreHierarchique.ProprieteParentListeObjets = null;
            this.m_cmbArbreHierarchique.SelectionneurParent = null;
            this.m_cmbArbreHierarchique.Size = new System.Drawing.Size(187, 21);
            this.m_cmbArbreHierarchique.TabIndex = 0;
            this.m_cmbArbreHierarchique.TextNull = "(empty)";
            this.m_cmbArbreHierarchique.Tri = true;
            this.m_cmbArbreHierarchique.SelectedValueChanged += new System.EventHandler(this.m_cmbArbreHierarchique_SelectedValueChanged);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(193, 45);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitter1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 382);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // m_arbreCategories
            // 
            this.m_arbreCategories.AddRootForAll = false;
            this.m_arbreCategories.AllowDrop = true;
            this.m_arbreCategories.AutoriserFilsDesAutorises = true;
            this.m_arbreCategories.CheckBoxes = true;
            this.m_arbreCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_arbreCategories.ElementSelectionne = null;
            this.m_arbreCategories.ElementsSelectionnes = new sc2i.data.CObjetDonnee[0];
            this.m_arbreCategories.ForeColorNonSelectionnable = System.Drawing.Color.DarkGray;
            this.m_arbreCategories.HideSelection = false;
            this.m_arbreCategories.Location = new System.Drawing.Point(0, 31);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_arbreCategories, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_arbreCategories.Name = "m_arbreCategories";
            this.m_arbreCategories.RootLabel = "Root";
            this.m_arbreCategories.Size = new System.Drawing.Size(230, 322);
            this.m_arbreCategories.TabIndex = 4016;
            this.m_arbreCategories.DragLeave += new System.EventHandler(this.m_arbreCategories_DragLeave);
            this.m_arbreCategories.DragDrop += new System.Windows.Forms.DragEventHandler(this.m_arbreCategories_DragDrop);
            this.m_arbreCategories.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_arbreCategories_AfterSelect);
            this.m_arbreCategories.DragEnter += new System.Windows.Forms.DragEventHandler(this.m_arbreCategories_DragEnter);
            this.m_arbreCategories.DragOver += new System.Windows.Forms.DragEventHandler(this.m_arbreCategories_DragOver);
            // 
            // m_panelCategories
            // 
            this.m_panelCategories.Controls.Add(this.m_arbreCategories);
            this.m_panelCategories.Controls.Add(this.m_panelBottomCategories);
            this.m_panelCategories.Controls.Add(this.m_panelTopCategories);
            this.m_panelCategories.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelCategories.Location = new System.Drawing.Point(198, 45);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelCategories, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelCategories.Name = "m_panelCategories";
            this.m_panelCategories.Size = new System.Drawing.Size(230, 382);
            this.m_panelCategories.TabIndex = 4017;
            // 
            // m_panelBottomCategories
            // 
            this.m_panelBottomCategories.Controls.Add(this.m_chkToutesCategories);
            this.m_panelBottomCategories.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_panelBottomCategories.Location = new System.Drawing.Point(0, 353);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelBottomCategories, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelBottomCategories.Name = "m_panelBottomCategories";
            this.m_panelBottomCategories.Size = new System.Drawing.Size(230, 29);
            this.m_panelBottomCategories.TabIndex = 4019;
            // 
            // m_chkToutesCategories
            // 
            this.m_chkToutesCategories.Checked = true;
            this.m_chkToutesCategories.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkToutesCategories.Location = new System.Drawing.Point(6, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkToutesCategories, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_chkToutesCategories.Name = "m_chkToutesCategories";
            this.m_chkToutesCategories.Size = new System.Drawing.Size(200, 24);
            this.m_chkToutesCategories.TabIndex = 0;
            this.m_chkToutesCategories.Text = "Display all Categories|10102";
            this.m_chkToutesCategories.UseVisualStyleBackColor = true;
            this.m_chkToutesCategories.CheckedChanged += new System.EventHandler(this.m_chkToutesCategories_CheckedChanged);
            // 
            // m_panelTopCategories
            // 
            this.m_panelTopCategories.Controls.Add(this.label1);
            this.m_panelTopCategories.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelTopCategories.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelTopCategories, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelTopCategories.Name = "m_panelTopCategories";
            this.m_panelTopCategories.Size = new System.Drawing.Size(230, 31);
            this.m_panelTopCategories.TabIndex = 4018;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 10);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 17);
            this.label1.TabIndex = 4017;
            this.label1.Text = "EDM Categories|848";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(428, 45);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitter2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(5, 382);
            this.splitter2.TabIndex = 4018;
            this.splitter2.TabStop = false;
            // 
            // m_panelHaut
            // 
            this.m_panelHaut.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelHaut.Location = new System.Drawing.Point(0, 35);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelHaut, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelHaut.Name = "m_panelHaut";
            this.m_panelHaut.Size = new System.Drawing.Size(962, 10);
            this.m_panelHaut.TabIndex = 4020;
            // 
            // m_panelBas
            // 
            this.m_panelBas.Controls.Add(this.m_chkTousDocuments);
            this.m_panelBas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_panelBas.Location = new System.Drawing.Point(0, 427);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelBas, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelBas.Name = "m_panelBas";
            this.m_panelBas.Size = new System.Drawing.Size(962, 22);
            this.m_panelBas.TabIndex = 4021;
            // 
            // m_chkTousDocuments
            // 
            this.m_chkTousDocuments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_chkTousDocuments.Checked = true;
            this.m_chkTousDocuments.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkTousDocuments.Location = new System.Drawing.Point(815, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkTousDocuments, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_chkTousDocuments.Name = "m_chkTousDocuments";
            this.m_chkTousDocuments.Size = new System.Drawing.Size(144, 16);
            this.m_chkTousDocuments.TabIndex = 0;
            this.m_chkTousDocuments.Text = "All documents|863";
            this.m_chkTousDocuments.UseVisualStyleBackColor = true;
            this.m_chkTousDocuments.CheckedChanged += new System.EventHandler(this.m_chkTousDocuments_CheckedChanged);
            // 
            // m_panelInfoSelectionEnCours
            // 
            this.m_panelInfoSelectionEnCours.Controls.Add(this.m_lblDragExisting);
            this.m_panelInfoSelectionEnCours.Controls.Add(this.m_lnkDissocierElementEnCours);
            this.m_panelInfoSelectionEnCours.Controls.Add(this.m_labelElementSelectionne);
            this.m_panelInfoSelectionEnCours.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelInfoSelectionEnCours.Location = new System.Drawing.Point(433, 45);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelInfoSelectionEnCours, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelInfoSelectionEnCours.Name = "m_panelInfoSelectionEnCours";
            this.m_panelInfoSelectionEnCours.Size = new System.Drawing.Size(529, 31);
            this.m_panelInfoSelectionEnCours.TabIndex = 4023;
            // 
            // m_lnkDissocierElementEnCours
            // 
            this.m_lnkDissocierElementEnCours.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lnkDissocierElementEnCours.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_lnkDissocierElementEnCours.Location = new System.Drawing.Point(437, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkDissocierElementEnCours, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lnkDissocierElementEnCours.Name = "m_lnkDissocierElementEnCours";
            this.m_lnkDissocierElementEnCours.Size = new System.Drawing.Size(92, 31);
            this.m_lnkDissocierElementEnCours.TabIndex = 1;
            this.m_lnkDissocierElementEnCours.TabStop = true;
            this.m_lnkDissocierElementEnCours.Text = "Dissociate|10333";
            this.m_lnkDissocierElementEnCours.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_lnkDissocierElementEnCours.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkDissocierElementEnCours_LinkClicked);
            // 
            // m_labelElementSelectionne
            // 
            this.m_labelElementSelectionne.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_labelElementSelectionne.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_labelElementSelectionne.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_labelElementSelectionne, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_labelElementSelectionne.Name = "m_labelElementSelectionne";
            this.m_labelElementSelectionne.Size = new System.Drawing.Size(325, 31);
            this.m_labelElementSelectionne.TabIndex = 0;
            this.m_labelElementSelectionne.Text = "Documents for : Selected element";
            this.m_labelElementSelectionne.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_panelListDocumentsGED
            // 
            this.m_panelListDocumentsGED.AffectationsPourNouveauxElements = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("m_panelListDocumentsGED.AffectationsPourNouveauxElements")));
            this.m_panelListDocumentsGED.AllowArbre = true;
            this.m_panelListDocumentsGED.AllowCustomisation = true;
            this.m_panelListDocumentsGED.AllowDrop = true;
            this.m_panelListDocumentsGED.AllowSerializePreferences = true;
            glColumn2.ActiveControlItems = null;
            glColumn2.BackColor = System.Drawing.Color.Transparent;
            glColumn2.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn2.ForColor = System.Drawing.Color.Black;
            glColumn2.ImageIndex = -1;
            glColumn2.IsCheckColumn = false;
            glColumn2.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn2.Name = "m_colLibelle";
            glColumn2.Propriete = "Libelle";
            glColumn2.Text = "Label|50";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 100;
            this.m_panelListDocumentsGED.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn2});
            this.m_panelListDocumentsGED.ContexteUtilisation = "";
            this.m_panelListDocumentsGED.ControlFiltreStandard = null;
            this.m_panelListDocumentsGED.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelListDocumentsGED.ElementSelectionne = null;
            this.m_panelListDocumentsGED.EnableCustomisation = true;
            this.m_panelListDocumentsGED.FiltreDeBase = null;
            this.m_panelListDocumentsGED.FiltreDeBaseEnAjout = false;
            this.m_panelListDocumentsGED.FiltrePrefere = null;
            this.m_panelListDocumentsGED.FiltreRapide = null;
            this.m_panelListDocumentsGED.HasImages = false;
            this.m_panelListDocumentsGED.ListeObjets = null;
            this.m_panelListDocumentsGED.Location = new System.Drawing.Point(433, 76);
            this.m_panelListDocumentsGED.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelListDocumentsGED, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelListDocumentsGED.ModeQuickSearch = false;
            this.m_panelListDocumentsGED.ModeSelection = false;
            this.m_panelListDocumentsGED.MultiSelect = true;
            this.m_panelListDocumentsGED.Name = "m_panelListDocumentsGED";
            this.m_panelListDocumentsGED.Navigateur = null;
            this.m_panelListDocumentsGED.ObjetReferencePourAffectationsInitiales = null;
            this.m_panelListDocumentsGED.ProprieteObjetAEditer = null;
            this.m_panelListDocumentsGED.QuickSearchText = "";
            this.m_panelListDocumentsGED.ShortIcons = false;
            this.m_panelListDocumentsGED.Size = new System.Drawing.Size(529, 322);
            this.m_panelListDocumentsGED.TabIndex = 4022;
            this.m_panelListDocumentsGED.TrierAuClicSurEnteteColonne = true;
            this.m_panelListDocumentsGED.UseCheckBoxes = false;
            this.m_panelListDocumentsGED.DragLeave += new System.EventHandler(this.m_panelListDocumentsGED_DragLeave);
            this.m_panelListDocumentsGED.DragDrop += new System.Windows.Forms.DragEventHandler(this.m_panelListDocumentsGED_DragDrop);
            this.m_panelListDocumentsGED.DragEnter += new System.Windows.Forms.DragEventHandler(this.m_panelListDocumentsGED_DragEnter);
            this.m_panelListDocumentsGED.AfterCreateFormEdition += new sc2i.win32.data.navigation.AfterCreateFormEditionEventHandler(this.m_panelListDocumentsGED_AfterCreateFormEdition);
            // 
            // m_lblInfoDragDrop
            // 
            this.m_lblInfoDragDrop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.m_lblInfoDragDrop.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_lblInfoDragDrop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblInfoDragDrop.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblInfoDragDrop, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblInfoDragDrop.Name = "m_lblInfoDragDrop";
            this.m_lblInfoDragDrop.Size = new System.Drawing.Size(962, 35);
            this.m_lblInfoDragDrop.TabIndex = 4024;
            this.m_lblInfoDragDrop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.m_lblInfoDragDrop.Visible = false;
            // 
            // m_panelModeStockage
            // 
            this.m_panelModeStockage.Controls.Add(this.label11);
            this.m_panelModeStockage.Controls.Add(this.m_cmbModeStockage);
            this.m_panelModeStockage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_panelModeStockage.Location = new System.Drawing.Point(433, 398);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelModeStockage, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelModeStockage.Name = "m_panelModeStockage";
            this.m_panelModeStockage.Size = new System.Drawing.Size(529, 29);
            this.m_panelModeStockage.TabIndex = 4025;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(6, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label11, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 13);
            this.label11.TabIndex = 4025;
            this.label11.Text = "Storage|20112";
            // 
            // m_cmbModeStockage
            // 
            this.m_cmbModeStockage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbModeStockage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbModeStockage.FormattingEnabled = true;
            this.m_cmbModeStockage.IsLink = false;
            this.m_cmbModeStockage.ListDonnees = null;
            this.m_cmbModeStockage.Location = new System.Drawing.Point(98, 5);
            this.m_cmbModeStockage.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbModeStockage, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_cmbModeStockage.Name = "m_cmbModeStockage";
            this.m_cmbModeStockage.NullAutorise = false;
            this.m_cmbModeStockage.ProprieteAffichee = null;
            this.m_cmbModeStockage.Size = new System.Drawing.Size(216, 21);
            this.m_cmbModeStockage.TabIndex = 4026;
            this.m_cmbModeStockage.TextNull = "(empty)";
            this.m_cmbModeStockage.Tri = true;
            // 
            // m_lblDragExisting
            // 
            this.m_lblDragExisting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblDragExisting.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_lblDragExisting.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblDragExisting.Location = new System.Drawing.Point(324, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblDragExisting, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblDragExisting.Name = "m_lblDragExisting";
            this.m_lblDragExisting.Size = new System.Drawing.Size(113, 31);
            this.m_lblDragExisting.TabIndex = 2;
            this.m_lblDragExisting.AllowDrop = true;
            this.m_lblDragExisting.Text = "Drag existing document here to associate";
            this.m_lblDragExisting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.m_lblDragExisting.DragDrop += new System.Windows.Forms.DragEventHandler(this.m_lblDragExisting_DragDrop);
            this.m_lblDragExisting.DragEnter += new System.Windows.Forms.DragEventHandler(this.m_lblDragExisting_DragEnter);
            // 
            // CControlGED
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_panelListDocumentsGED);
            this.Controls.Add(this.m_panelModeStockage);
            this.Controls.Add(this.m_panelInfoSelectionEnCours);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.m_panelCategories);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.m_panelConsultationHierarchique);
            this.Controls.Add(this.m_panelHaut);
            this.Controls.Add(this.m_panelBas);
            this.Controls.Add(this.m_lblInfoDragDrop);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControlGED";
            this.Size = new System.Drawing.Size(962, 449);
            this.m_panelConsultationHierarchique.ResumeLayout(false);
            this.m_panelTopLeft.ResumeLayout(false);
            this.m_panelCategories.ResumeLayout(false);
            this.m_panelBottomCategories.ResumeLayout(false);
            this.m_panelTopCategories.ResumeLayout(false);
            this.m_panelBas.ResumeLayout(false);
            this.m_panelInfoSelectionEnCours.ResumeLayout(false);
            this.m_panelModeStockage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.C2iPanel m_panelConsultationHierarchique;
        private timos.Parametrage.ConsultationHierarchique.CArbreConsultationHierarchique m_arbreConsultation;
        private sc2i.win32.common.C2iPanel m_panelTopLeft;
        private sc2i.win32.data.CComboBoxListeObjetsDonnees m_cmbArbreHierarchique;
        private System.Windows.Forms.Splitter splitter1;
        private sc2i.win32.data.CArbreObjetsDonneesHierarchiques m_arbreCategories;
        private System.Windows.Forms.Panel m_panelCategories;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel m_panelHaut;
        private System.Windows.Forms.Panel m_panelBas;
        private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
        private sc2i.win32.common.CToolTipTraductible m_tooltipTraductible;
        private sc2i.win32.data.navigation.CPanelListeSpeedStandard m_panelListDocumentsGED;
        private System.Windows.Forms.CheckBox m_chkTousDocuments;
        private System.Windows.Forms.Panel m_panelInfoSelectionEnCours;
        private System.Windows.Forms.Label m_labelElementSelectionne;
        private System.Windows.Forms.Panel m_panelTopCategories;
        private System.Windows.Forms.Panel m_panelBottomCategories;
        private System.Windows.Forms.CheckBox m_chkToutesCategories;
        private System.Windows.Forms.Label m_lblInfoDragDrop;
        private System.Windows.Forms.Panel m_panelModeStockage;
        private System.Windows.Forms.Label label11;
        private sc2i.win32.common.CComboboxAutoFilled m_cmbModeStockage;
        private System.Windows.Forms.LinkLabel m_lnkDissocierElementEnCours;
        private System.Windows.Forms.Label m_lblDragExisting;
    }
}
