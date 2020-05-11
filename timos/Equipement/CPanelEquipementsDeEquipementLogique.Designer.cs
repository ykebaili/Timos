using sc2i.common;

namespace timos.Equipement
{
	partial class CPanelEquipementsDeEquipementLogique
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
            sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
            this.m_extLinkField = new sc2i.win32.common.CExtLinkField();
            this.m_panelHaut = new System.Windows.Forms.Panel();
            this.m_lnkLinkToEquipement = new System.Windows.Forms.LinkLabel();
            this.m_lnkCreateNewEquipement = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.m_panelMonoEquipement = new System.Windows.Forms.Panel();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageFiche = new Crownwood.Magic.Controls.TabPage();
            this.m_panelFormulaire = new sc2i.win32.data.dynamic.CPanelChampsCustom();
            this.m_pageCoordonnees = new Crownwood.Magic.Controls.TabPage();
            this.m_panelCoordonnees = new sc2i.win32.common.C2iPanel(this.components);
            this.Label234 = new System.Windows.Forms.Label();
            this.m_controleCoordonnee = new timos.coordonnees.CControlEditeCoordonnee();
            this.m_panelOccupation = new timos.coordonnees.CControlEditionObjetAOccupation();
            this.m_panelParametrage = new sc2i.win32.common.C2iPanel(this.components);
            this.m_lnkSupprimerLien = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.m_cmbStatut = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.m_lnkDetailEquipement = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.m_selectTypeEquipement = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.label1 = new System.Windows.Forms.Label();
            this.c2iTextBox1 = new sc2i.win32.common.C2iTextBox();
            this.m_panelListeEquipements = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.m_extModulesAssociator = new timos.CExtModulesAssociator();
            this.m_panelHaut.SuspendLayout();
            this.m_panelMonoEquipement.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.m_pageFiche.SuspendLayout();
            this.m_pageCoordonnees.SuspendLayout();
            this.m_panelCoordonnees.SuspendLayout();
            this.m_panelOccupation.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelHaut
            // 
            this.m_panelHaut.Controls.Add(this.m_lnkLinkToEquipement);
            this.m_panelHaut.Controls.Add(this.m_lnkCreateNewEquipement);
            this.m_panelHaut.Controls.Add(this.label2);
            this.m_panelHaut.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.m_panelHaut, "");
            this.m_panelHaut.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelHaut, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelHaut, "");
            this.m_panelHaut.Name = "m_panelHaut";
            this.m_panelHaut.Size = new System.Drawing.Size(701, 29);
            this.m_extStyle.SetStyleBackColor(this.m_panelHaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelHaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelHaut.TabIndex = 0;
            // 
            // m_lnkLinkToEquipement
            // 
            this.m_lnkLinkToEquipement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lnkLinkToEquipement.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.m_extLinkField.SetLinkField(this.m_lnkLinkToEquipement, "");
            this.m_lnkLinkToEquipement.Location = new System.Drawing.Point(478, 8);
            this.m_extModeEdition.SetModeEdition(this.m_lnkLinkToEquipement, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkLinkToEquipement, "");
            this.m_lnkLinkToEquipement.Name = "m_lnkLinkToEquipement";
            this.m_lnkLinkToEquipement.Size = new System.Drawing.Size(213, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkLinkToEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkLinkToEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkLinkToEquipement.TabIndex = 11;
            this.m_lnkLinkToEquipement.TabStop = true;
            this.m_lnkLinkToEquipement.Text = "Link to existing Equipment|20074";
            this.m_lnkLinkToEquipement.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkLinkToEquipement_LinkClicked);
            // 
            // m_lnkCreateNewEquipement
            // 
            this.m_lnkCreateNewEquipement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lnkCreateNewEquipement.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.m_extLinkField.SetLinkField(this.m_lnkCreateNewEquipement, "");
            this.m_lnkCreateNewEquipement.Location = new System.Drawing.Point(295, 8);
            this.m_extModeEdition.SetModeEdition(this.m_lnkCreateNewEquipement, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkCreateNewEquipement, "");
            this.m_lnkCreateNewEquipement.Name = "m_lnkCreateNewEquipement";
            this.m_lnkCreateNewEquipement.Size = new System.Drawing.Size(177, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkCreateNewEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkCreateNewEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkCreateNewEquipement.TabIndex = 12;
            this.m_lnkCreateNewEquipement.TabStop = true;
            this.m_lnkCreateNewEquipement.Text = "Create Equipment|20075";
            this.m_lnkCreateNewEquipement.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkCreateNewEquipement_LinkClicked);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Beige;
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(267, 29);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 6;
            this.label2.Text = "Equipment Association|20073";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_panelMonoEquipement
            // 
            this.m_panelMonoEquipement.Controls.Add(this.m_tabControl);
            this.m_panelMonoEquipement.Controls.Add(this.m_lnkSupprimerLien);
            this.m_panelMonoEquipement.Controls.Add(this.label4);
            this.m_panelMonoEquipement.Controls.Add(this.m_cmbStatut);
            this.m_panelMonoEquipement.Controls.Add(this.m_lnkDetailEquipement);
            this.m_panelMonoEquipement.Controls.Add(this.label3);
            this.m_panelMonoEquipement.Controls.Add(this.m_selectTypeEquipement);
            this.m_panelMonoEquipement.Controls.Add(this.label1);
            this.m_panelMonoEquipement.Controls.Add(this.c2iTextBox1);
            this.m_panelMonoEquipement.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.m_panelMonoEquipement, "");
            this.m_panelMonoEquipement.Location = new System.Drawing.Point(0, 29);
            this.m_extModeEdition.SetModeEdition(this.m_panelMonoEquipement, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelMonoEquipement, "");
            this.m_panelMonoEquipement.Name = "m_panelMonoEquipement";
            this.m_panelMonoEquipement.Size = new System.Drawing.Size(701, 284);
            this.m_extStyle.SetStyleBackColor(this.m_panelMonoEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMonoEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelMonoEquipement.TabIndex = 1;
            // 
            // m_tabControl
            // 
            this.m_tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_tabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_tabControl.BoldSelectedPage = true;
            this.m_tabControl.ForeColor = System.Drawing.Color.Black;
            this.m_tabControl.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_tabControl, "");
            this.m_tabControl.Location = new System.Drawing.Point(0, 79);
            this.m_extModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = false;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.m_pageFiche;
            this.m_tabControl.Size = new System.Drawing.Size(701, 205);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4028;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageFiche,
            this.m_pageCoordonnees});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageFiche
            // 
            this.m_pageFiche.Controls.Add(this.m_panelFormulaire);
            this.m_extLinkField.SetLinkField(this.m_pageFiche, "");
            this.m_pageFiche.Location = new System.Drawing.Point(0, 25);
            this.m_extModeEdition.SetModeEdition(this.m_pageFiche, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageFiche, "");
            this.m_pageFiche.Name = "m_pageFiche";
            this.m_pageFiche.Size = new System.Drawing.Size(701, 180);
            this.m_extStyle.SetStyleBackColor(this.m_pageFiche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageFiche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageFiche.TabIndex = 10;
            this.m_pageFiche.Title = "Form|60";
            // 
            // m_panelFormulaire
            // 
            this.m_panelFormulaire.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelFormulaire.BoldSelectedPage = true;
            this.m_panelFormulaire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelFormulaire.ElementEdite = null;
            this.m_panelFormulaire.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_panelFormulaire, "");
            this.m_panelFormulaire.Location = new System.Drawing.Point(0, 0);
            this.m_panelFormulaire.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_panelFormulaire, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelFormulaire, "");
            this.m_panelFormulaire.Name = "m_panelFormulaire";
            this.m_panelFormulaire.Ombre = false;
            this.m_panelFormulaire.PositionTop = true;
            this.m_panelFormulaire.Size = new System.Drawing.Size(701, 180);
            this.m_extStyle.SetStyleBackColor(this.m_panelFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelFormulaire.TabIndex = 4023;
            // 
            // m_pageCoordonnees
            // 
            this.m_pageCoordonnees.Controls.Add(this.m_panelCoordonnees);
            this.m_pageCoordonnees.Controls.Add(this.m_panelOccupation);
            this.m_extLinkField.SetLinkField(this.m_pageCoordonnees, "");
            this.m_pageCoordonnees.Location = new System.Drawing.Point(0, 25);
            this.m_extModeEdition.SetModeEdition(this.m_pageCoordonnees, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_pageCoordonnees, "");
            this.m_pageCoordonnees.Name = "m_pageCoordonnees";
            this.m_pageCoordonnees.Selected = false;
            this.m_pageCoordonnees.Size = new System.Drawing.Size(701, 180);
            this.m_extStyle.SetStyleBackColor(this.m_pageCoordonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageCoordonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageCoordonnees.TabIndex = 11;
            this.m_pageCoordonnees.Title = "Coordinates|20083";
            // 
            // m_panelCoordonnees
            // 
            this.m_panelCoordonnees.Controls.Add(this.Label234);
            this.m_panelCoordonnees.Controls.Add(this.m_controleCoordonnee);
            this.m_extLinkField.SetLinkField(this.m_panelCoordonnees, "");
            this.m_panelCoordonnees.Location = new System.Drawing.Point(8, 106);
            this.m_panelCoordonnees.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_panelCoordonnees, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelCoordonnees, "ASYS_COOR");
            this.m_panelCoordonnees.Name = "m_panelCoordonnees";
            this.m_panelCoordonnees.Size = new System.Drawing.Size(334, 41);
            this.m_extStyle.SetStyleBackColor(this.m_panelCoordonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCoordonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelCoordonnees.TabIndex = 4028;
            // 
            // Label234
            // 
            this.m_extLinkField.SetLinkField(this.Label234, "");
            this.Label234.Location = new System.Drawing.Point(6, 4);
            this.m_extModeEdition.SetModeEdition(this.Label234, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.Label234, "");
            this.Label234.Name = "Label234";
            this.Label234.Size = new System.Drawing.Size(107, 21);
            this.m_extStyle.SetStyleBackColor(this.Label234, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.Label234, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Label234.TabIndex = 4025;
            this.Label234.Text = "Coordinate|446";
            // 
            // m_controleCoordonnee
            // 
            this.m_controleCoordonnee.Coordonnee = "";
            this.m_extLinkField.SetLinkField(this.m_controleCoordonnee, "");
            this.m_controleCoordonnee.Location = new System.Drawing.Point(123, 4);
            this.m_controleCoordonnee.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_controleCoordonnee, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_controleCoordonnee, "");
            this.m_controleCoordonnee.Name = "m_controleCoordonnee";
            this.m_controleCoordonnee.Size = new System.Drawing.Size(206, 21);
            this.m_extStyle.SetStyleBackColor(this.m_controleCoordonnee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_controleCoordonnee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_controleCoordonnee.TabIndex = 4024;
            // 
            // m_panelOccupation
            // 
            this.m_panelOccupation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelOccupation.Controls.Add(this.m_panelParametrage);
            this.m_panelOccupation.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panelOccupation, "");
            this.m_panelOccupation.Location = new System.Drawing.Point(8, 3);
            this.m_panelOccupation.LockEdition = true;
            this.m_extModeEdition.SetModeEdition(this.m_panelOccupation, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelOccupation, "ASYS_COOR");
            this.m_panelOccupation.Name = "m_panelOccupation";
            this.m_panelOccupation.Size = new System.Drawing.Size(356, 97);
            this.m_extStyle.SetStyleBackColor(this.m_panelOccupation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelOccupation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelOccupation.TabIndex = 4027;
            // 
            // m_panelParametrage
            // 
            this.m_panelParametrage.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.m_panelParametrage, "");
            this.m_panelParametrage.Location = new System.Drawing.Point(0, 0);
            this.m_panelParametrage.LockEdition = true;
            this.m_extModeEdition.SetModeEdition(this.m_panelParametrage, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelParametrage, "");
            this.m_panelParametrage.Name = "m_panelParametrage";
            this.m_panelParametrage.Size = new System.Drawing.Size(356, 24);
            this.m_extStyle.SetStyleBackColor(this.m_panelParametrage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelParametrage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelParametrage.TabIndex = 10;
            // 
            // m_lnkSupprimerLien
            // 
            this.m_extLinkField.SetLinkField(this.m_lnkSupprimerLien, "");
            this.m_lnkSupprimerLien.Location = new System.Drawing.Point(417, 36);
            this.m_extModeEdition.SetModeEdition(this.m_lnkSupprimerLien, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkSupprimerLien, "");
            this.m_lnkSupprimerLien.Name = "m_lnkSupprimerLien";
            this.m_lnkSupprimerLien.Size = new System.Drawing.Size(235, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSupprimerLien, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSupprimerLien, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSupprimerLien.TabIndex = 4027;
            this.m_lnkSupprimerLien.TabStop = true;
            this.m_lnkSupprimerLien.Text = "Unlink equipment|20082";
            this.m_lnkSupprimerLien.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkSupprimerLien_LinkClicked);
            // 
            // label4
            // 
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.label4.Location = new System.Drawing.Point(5, 55);
            this.m_extModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 18);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 4025;
            this.label4.Text = "Equipment Status|230";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cmbStatut
            // 
            this.m_cmbStatut.ComportementLinkStd = true;
            this.m_cmbStatut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbStatut.ElementSelectionne = null;
            this.m_cmbStatut.FormattingEnabled = true;
            this.m_cmbStatut.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbStatut, "");
            this.m_cmbStatut.LinkProperty = "";
            this.m_cmbStatut.ListDonnees = null;
            this.m_cmbStatut.Location = new System.Drawing.Point(160, 54);
            this.m_cmbStatut.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_cmbStatut, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbStatut, "");
            this.m_cmbStatut.Name = "m_cmbStatut";
            this.m_cmbStatut.NullAutorise = false;
            this.m_cmbStatut.ProprieteAffichee = null;
            this.m_cmbStatut.ProprieteParentListeObjets = null;
            this.m_cmbStatut.SelectionneurParent = null;
            this.m_cmbStatut.Size = new System.Drawing.Size(247, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbStatut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbStatut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbStatut.TabIndex = 4026;
            this.m_cmbStatut.TextNull = "(empty)";
            this.m_cmbStatut.Tri = true;
            this.m_cmbStatut.TypeFormEdition = null;
            // 
            // m_lnkDetailEquipement
            // 
            this.m_extLinkField.SetLinkField(this.m_lnkDetailEquipement, "");
            this.m_lnkDetailEquipement.Location = new System.Drawing.Point(416, 12);
            this.m_extModeEdition.SetModeEdition(this.m_lnkDetailEquipement, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkDetailEquipement, "");
            this.m_lnkDetailEquipement.Name = "m_lnkDetailEquipement";
            this.m_lnkDetailEquipement.Size = new System.Drawing.Size(236, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkDetailEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkDetailEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkDetailEquipement.TabIndex = 4024;
            this.m_lnkDetailEquipement.TabStop = true;
            this.m_lnkDetailEquipement.Text = "Equipment details|20078";
            this.m_lnkDetailEquipement.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkDetailEquipement_LinkClicked);
            // 
            // label3
            // 
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(5, 33);
            this.m_extModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 17);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4021;
            this.label3.Text = "Equipment type|20077";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_selectTypeEquipement
            // 
            this.m_selectTypeEquipement.ElementSelectionne = null;
            this.m_selectTypeEquipement.FonctionTextNull = null;
            this.m_selectTypeEquipement.HasLink = true;
            this.m_extLinkField.SetLinkField(this.m_selectTypeEquipement, "");
            this.m_selectTypeEquipement.Location = new System.Drawing.Point(160, 31);
            this.m_selectTypeEquipement.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_selectTypeEquipement, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_selectTypeEquipement, "");
            this.m_selectTypeEquipement.Name = "m_selectTypeEquipement";
            this.m_selectTypeEquipement.SelectedObject = null;
            this.m_selectTypeEquipement.Size = new System.Drawing.Size(247, 21);
            this.m_extStyle.SetStyleBackColor(this.m_selectTypeEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_selectTypeEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectTypeEquipement.TabIndex = 4022;
            this.m_selectTypeEquipement.TextNull = "";
            // 
            // label1
            // 
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.label1.Location = new System.Drawing.Point(5, 10);
            this.m_extModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label1, "");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 20);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4020;
            this.label1.Text = "Serial Number|223";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c2iTextBox1
            // 
            this.m_extLinkField.SetLinkField(this.c2iTextBox1, "NumSerie");
            this.c2iTextBox1.Location = new System.Drawing.Point(160, 9);
            this.c2iTextBox1.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.c2iTextBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBox1, "");
            this.c2iTextBox1.Name = "c2iTextBox1";
            this.c2iTextBox1.Size = new System.Drawing.Size(247, 20);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox1.TabIndex = 4019;
            this.c2iTextBox1.Text = "[NumSerie]";
            // 
            // m_panelListeEquipements
            // 
            this.m_panelListeEquipements.AllowArbre = true;
            this.m_panelListeEquipements.AllowCustomisation = true;
            glColumn2.ActiveControlItems = null;
            glColumn2.BackColor = System.Drawing.Color.Transparent;
            glColumn2.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn2.ForColor = System.Drawing.Color.Black;
            glColumn2.ImageIndex = -1;
            glColumn2.IsCheckColumn = false;
            glColumn2.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn2.Name = "Name";
            glColumn2.Propriete = "Libelle";
            glColumn2.Text = "Label";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 150;
            this.m_panelListeEquipements.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn2});
            this.m_panelListeEquipements.ContexteUtilisation = "";
            this.m_panelListeEquipements.ControlFiltreStandard = null;
            this.m_panelListeEquipements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelListeEquipements.ElementSelectionne = null;
            this.m_panelListeEquipements.EnableCustomisation = true;
            this.m_panelListeEquipements.FiltreDeBase = null;
            this.m_panelListeEquipements.FiltreDeBaseEnAjout = false;
            this.m_panelListeEquipements.FiltrePrefere = null;
            this.m_panelListeEquipements.FiltreRapide = null;
            this.m_panelListeEquipements.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panelListeEquipements, "");
            this.m_panelListeEquipements.ListeObjets = null;
            this.m_panelListeEquipements.Location = new System.Drawing.Point(0, 313);
            this.m_panelListeEquipements.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_panelListeEquipements, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelListeEquipements.ModeQuickSearch = false;
            this.m_panelListeEquipements.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_panelListeEquipements, "");
            this.m_panelListeEquipements.MultiSelect = false;
            this.m_panelListeEquipements.Name = "m_panelListeEquipements";
            this.m_panelListeEquipements.Navigateur = null;
            this.m_panelListeEquipements.ProprieteObjetAEditer = null;
            this.m_panelListeEquipements.QuickSearchText = "";
            this.m_panelListeEquipements.Size = new System.Drawing.Size(701, 98);
            this.m_extStyle.SetStyleBackColor(this.m_panelListeEquipements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListeEquipements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelListeEquipements.TabIndex = 0;
            this.m_panelListeEquipements.TrierAuClicSurEnteteColonne = true;
            this.m_panelListeEquipements.UseCheckBoxes = false;
            // 
            // CPanelEquipementsDeEquipementLogique
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_panelListeEquipements);
            this.Controls.Add(this.m_panelMonoEquipement);
            this.Controls.Add(this.m_panelHaut);
            this.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CPanelEquipementsDeEquipementLogique";
            this.Size = new System.Drawing.Size(701, 411);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelHaut.ResumeLayout(false);
            this.m_panelMonoEquipement.ResumeLayout(false);
            this.m_panelMonoEquipement.PerformLayout();
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.m_pageFiche.ResumeLayout(false);
            this.m_pageCoordonnees.ResumeLayout(false);
            this.m_panelCoordonnees.ResumeLayout(false);
            this.m_panelOccupation.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private sc2i.win32.common.CExtLinkField m_extLinkField;
		private sc2i.win32.common.CExtModeEdition m_extModeEdition;
		private sc2i.win32.common.CExtStyle m_extStyle;
		private System.Windows.Forms.Panel m_panelHaut;
		private System.Windows.Forms.Panel m_panelMonoEquipement;
		private sc2i.win32.data.navigation.CPanelListeSpeedStandard m_panelListeEquipements;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel m_lnkCreateNewEquipement;
		private System.Windows.Forms.LinkLabel m_lnkLinkToEquipement;
		private System.Windows.Forms.LinkLabel m_lnkDetailEquipement;
		private sc2i.win32.data.dynamic.CPanelChampsCustom m_panelFormulaire;
		private System.Windows.Forms.Label label3;
		private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_selectTypeEquipement;
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox c2iTextBox1;
		private System.Windows.Forms.Label label4;
		private sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees m_cmbStatut;
		private System.Windows.Forms.LinkLabel m_lnkSupprimerLien;
		private sc2i.win32.common.C2iTabControl m_tabControl;
		private Crownwood.Magic.Controls.TabPage m_pageCoordonnees;
		private Crownwood.Magic.Controls.TabPage m_pageFiche;
		private CExtModulesAssociator m_extModulesAssociator;
		private sc2i.win32.common.C2iPanel m_panelCoordonnees;
		private System.Windows.Forms.Label Label234;
		private timos.coordonnees.CControlEditeCoordonnee m_controleCoordonnee;
		private timos.coordonnees.CControlEditionObjetAOccupation m_panelOccupation;
        private sc2i.win32.common.C2iPanel m_panelParametrage;
	}
}
