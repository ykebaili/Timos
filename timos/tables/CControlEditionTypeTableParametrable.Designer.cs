namespace timos
{
	partial class CControlEditionTypeTableParametrable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CControlEditionTypeTableParametrable));
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_TabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageColonnes = new Crownwood.Magic.Controls.TabPage();
            this.m_lnkAjouter = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkSupprimer = new sc2i.win32.common.CWndLinkStd();
            this.m_ctrlMD = new sc2i.win32.common.CCtrlUpDownListView();
            this.m_wndColonnes = new sc2i.win32.common.ListViewAutoFilled();
            this.m_lvColsLabel = ((sc2i.win32.common.ListViewAutoFilledColumn)(new sc2i.win32.common.ListViewAutoFilledColumn()));
            this.m_lvColsType = ((sc2i.win32.common.ListViewAutoFilledColumn)(new sc2i.win32.common.ListViewAutoFilledColumn()));
            this.m_panelCol = new System.Windows.Forms.Panel();
            this.m_ctrlEditCol = new timos.CControlEditionColonneTableParametrable();
            this.m_pageClePrimaire = new Crownwood.Magic.Controls.TabPage();
            this.m_cmbPk = new System.Windows.Forms.ComboBox();
            this.m_lnkAddPk = new sc2i.win32.common.CWndLinkStd();
            this.m_lvPks = new sc2i.win32.common.ListViewAutoFilled();
            this.m_lvPksColLabel = ((sc2i.win32.common.ListViewAutoFilledColumn)(new sc2i.win32.common.ListViewAutoFilledColumn()));
            this.m_lnkRemovePk = new sc2i.win32.common.CWndLinkStd();
            this.m_nudPk = new sc2i.win32.common.CCtrlUpDownListView();
            this.m_pageChampsCustom = new Crownwood.Magic.Controls.TabPage();
            this.m_panelEditChamps = new timos.win32.composants.CPanelEditDefinisseurChampsCustom();
            this.m_pageTypesEquipements = new Crownwood.Magic.Controls.TabPage();
            this.m_typesEquipementsSelec = new sc2i.win32.data.navigation.CPanelListeRelationSelection();
            this.m_colLabelTypeEquipement = ((sc2i.win32.common.ListViewAutoFilledColumn)(new sc2i.win32.common.ListViewAutoFilledColumn()));
            this.m_pageTypesSites = new Crownwood.Magic.Controls.TabPage();
            this.m_typesSitesSelec = new sc2i.win32.data.navigation.CPanelListeRelationSelection();
            this.m_colLabelTypeSite = ((sc2i.win32.common.ListViewAutoFilledColumn)(new sc2i.win32.common.ListViewAutoFilledColumn()));
            this.m_txtNom = new System.Windows.Forms.TextBox();
            this.m_lblNom = new System.Windows.Forms.Label();
            this.m_panOmbre = new sc2i.win32.common.C2iPanelOmbre();
            this.m_panTop = new System.Windows.Forms.Panel();
            this.m_gestionnaireColonnes = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.m_extFieldCol = new sc2i.win32.common.CExtLinkField();
            this.m_gestionnaireTabControl = new sc2i.win32.common.CGestionnaireTabControl();
            this.m_pageFormulaires = new Crownwood.Magic.Controls.TabPage();
            this.m_panelChamps = new sc2i.win32.data.dynamic.CPanelChampsCustom();
            this.m_TabControl.SuspendLayout();
            this.m_pageColonnes.SuspendLayout();
            this.m_panelCol.SuspendLayout();
            this.m_pageClePrimaire.SuspendLayout();
            this.m_pageChampsCustom.SuspendLayout();
            this.m_pageTypesEquipements.SuspendLayout();
            this.m_pageTypesSites.SuspendLayout();
            this.m_panOmbre.SuspendLayout();
            this.m_panTop.SuspendLayout();
            this.m_pageFormulaires.SuspendLayout();
            this.SuspendLayout();
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
            this.m_extFieldCol.SetLinkField(this.m_TabControl, "");
            this.m_extFieldCol.SetLinkFieldAutoUpdate(this.m_TabControl, false);
            this.m_TabControl.Location = new System.Drawing.Point(6, 70);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_TabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_TabControl.Name = "m_TabControl";
            this.m_TabControl.Ombre = true;
            this.m_TabControl.PositionTop = true;
            this.m_TabControl.SelectedIndex = 0;
            this.m_TabControl.SelectedTab = this.m_pageFormulaires;
            this.m_TabControl.Size = new System.Drawing.Size(678, 396);
            this.m_TabControl.TabIndex = 4014;
            this.m_TabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageFormulaires,
            this.m_pageColonnes,
            this.m_pageClePrimaire,
            this.m_pageChampsCustom,
            this.m_pageTypesEquipements,
            this.m_pageTypesSites});
            this.m_TabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageColonnes
            // 
            this.m_pageColonnes.Controls.Add(this.m_lnkAjouter);
            this.m_pageColonnes.Controls.Add(this.m_lnkSupprimer);
            this.m_pageColonnes.Controls.Add(this.m_ctrlMD);
            this.m_pageColonnes.Controls.Add(this.m_wndColonnes);
            this.m_pageColonnes.Controls.Add(this.m_panelCol);
            this.m_extFieldCol.SetLinkField(this.m_pageColonnes, "");
            this.m_extFieldCol.SetLinkFieldAutoUpdate(this.m_pageColonnes, false);
            this.m_pageColonnes.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageColonnes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_pageColonnes.Name = "m_pageColonnes";
            this.m_pageColonnes.Selected = false;
            this.m_pageColonnes.Size = new System.Drawing.Size(662, 355);
            this.m_pageColonnes.TabIndex = 13;
            this.m_pageColonnes.Title = "Columns|1165";
            // 
            // m_lnkAjouter
            // 
            this.m_lnkAjouter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAjouter.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_lnkAjouter.CustomImage")));
            this.m_lnkAjouter.CustomText = "Add";
            this.m_lnkAjouter.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extFieldCol.SetLinkField(this.m_lnkAjouter, "");
            this.m_extFieldCol.SetLinkFieldAutoUpdate(this.m_lnkAjouter, false);
            this.m_lnkAjouter.Location = new System.Drawing.Point(3, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAjouter, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkAjouter.Name = "m_lnkAjouter";
            this.m_lnkAjouter.ShortMode = false;
            this.m_lnkAjouter.Size = new System.Drawing.Size(104, 16);
            this.m_lnkAjouter.TabIndex = 4007;
            this.m_lnkAjouter.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAjouter.LinkClicked += new System.EventHandler(this.m_lnkAjouter_LinkClicked);
            // 
            // m_lnkSupprimer
            // 
            this.m_lnkSupprimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkSupprimer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkSupprimer.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_lnkSupprimer.CustomImage")));
            this.m_lnkSupprimer.CustomText = "Remove";
            this.m_lnkSupprimer.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extFieldCol.SetLinkField(this.m_lnkSupprimer, "");
            this.m_extFieldCol.SetLinkFieldAutoUpdate(this.m_lnkSupprimer, false);
            this.m_lnkSupprimer.Location = new System.Drawing.Point(3, 331);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkSupprimer, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkSupprimer.Name = "m_lnkSupprimer";
            this.m_lnkSupprimer.ShortMode = false;
            this.m_lnkSupprimer.Size = new System.Drawing.Size(104, 20);
            this.m_lnkSupprimer.TabIndex = 4009;
            this.m_lnkSupprimer.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkSupprimer.LinkClicked += new System.EventHandler(this.m_lnkSupprimer_LinkClicked);
            // 
            // m_ctrlMD
            // 
            this.m_ctrlMD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extFieldCol.SetLinkField(this.m_ctrlMD, "");
            this.m_extFieldCol.SetLinkFieldAutoUpdate(this.m_ctrlMD, false);
            this.m_ctrlMD.ListeGeree = this.m_wndColonnes;
            this.m_ctrlMD.Location = new System.Drawing.Point(342, 330);
            this.m_ctrlMD.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_ctrlMD, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_ctrlMD.Name = "m_ctrlMD";
            this.m_ctrlMD.ProprieteNumero = "Position";
            this.m_ctrlMD.Size = new System.Drawing.Size(51, 21);
            this.m_ctrlMD.TabIndex = 4010;
            // 
            // m_wndColonnes
            // 
            this.m_wndColonnes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_wndColonnes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_lvColsLabel,
            this.m_lvColsType});
            this.m_wndColonnes.EnableCustomisation = true;
            this.m_wndColonnes.FullRowSelect = true;
            this.m_wndColonnes.GridLines = true;
            this.m_wndColonnes.HideSelection = false;
            this.m_extFieldCol.SetLinkField(this.m_wndColonnes, "");
            this.m_extFieldCol.SetLinkFieldAutoUpdate(this.m_wndColonnes, false);
            this.m_wndColonnes.Location = new System.Drawing.Point(3, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndColonnes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_wndColonnes.MultiSelect = false;
            this.m_wndColonnes.Name = "m_wndColonnes";
            this.m_wndColonnes.Size = new System.Drawing.Size(390, 300);
            this.m_wndColonnes.TabIndex = 4006;
            this.m_wndColonnes.UseCompatibleStateImageBehavior = false;
            this.m_wndColonnes.View = System.Windows.Forms.View.Details;
            // 
            // m_lvColsLabel
            // 
            this.m_lvColsLabel.Field = "Libelle";
            this.m_lvColsLabel.PrecisionWidth = 0D;
            this.m_lvColsLabel.ProportionnalSize = false;
            this.m_lvColsLabel.Text = "Label|50";
            this.m_lvColsLabel.Visible = true;
            this.m_lvColsLabel.Width = 120;
            // 
            // m_lvColsType
            // 
            this.m_lvColsType.Field = "TypeDonneeChamp.Libelle";
            this.m_lvColsType.PrecisionWidth = 0D;
            this.m_lvColsType.ProportionnalSize = false;
            this.m_lvColsType.Text = "Type|54";
            this.m_lvColsType.Visible = true;
            this.m_lvColsType.Width = 110;
            // 
            // m_panelCol
            // 
            this.m_panelCol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelCol.Controls.Add(this.m_ctrlEditCol);
            this.m_extFieldCol.SetLinkField(this.m_panelCol, "");
            this.m_extFieldCol.SetLinkFieldAutoUpdate(this.m_panelCol, false);
            this.m_panelCol.Location = new System.Drawing.Point(413, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelCol, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelCol.Name = "m_panelCol";
            this.m_panelCol.Size = new System.Drawing.Size(246, 300);
            this.m_panelCol.TabIndex = 4008;
            // 
            // m_ctrlEditCol
            // 
            this.m_ctrlEditCol.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extFieldCol.SetLinkField(this.m_ctrlEditCol, "");
            this.m_extFieldCol.SetLinkFieldAutoUpdate(this.m_ctrlEditCol, false);
            this.m_ctrlEditCol.Location = new System.Drawing.Point(3, 3);
            this.m_ctrlEditCol.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_ctrlEditCol, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_ctrlEditCol.Name = "m_ctrlEditCol";
            this.m_ctrlEditCol.Size = new System.Drawing.Size(240, 285);
            this.m_ctrlEditCol.TabIndex = 0;
            // 
            // m_pageClePrimaire
            // 
            this.m_pageClePrimaire.Controls.Add(this.m_cmbPk);
            this.m_pageClePrimaire.Controls.Add(this.m_lnkAddPk);
            this.m_pageClePrimaire.Controls.Add(this.m_lvPks);
            this.m_pageClePrimaire.Controls.Add(this.m_lnkRemovePk);
            this.m_pageClePrimaire.Controls.Add(this.m_nudPk);
            this.m_extFieldCol.SetLinkField(this.m_pageClePrimaire, "");
            this.m_extFieldCol.SetLinkFieldAutoUpdate(this.m_pageClePrimaire, false);
            this.m_pageClePrimaire.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageClePrimaire, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_pageClePrimaire.Name = "m_pageClePrimaire";
            this.m_pageClePrimaire.Selected = false;
            this.m_pageClePrimaire.Size = new System.Drawing.Size(662, 355);
            this.m_pageClePrimaire.TabIndex = 16;
            this.m_pageClePrimaire.Title = "Primary Key|1287";
            // 
            // m_cmbPk
            // 
            this.m_cmbPk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbPk.FormattingEnabled = true;
            this.m_extFieldCol.SetLinkField(this.m_cmbPk, "");
            this.m_extFieldCol.SetLinkFieldAutoUpdate(this.m_cmbPk, false);
            this.m_cmbPk.Location = new System.Drawing.Point(6, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbPk, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbPk.Name = "m_cmbPk";
            this.m_cmbPk.Size = new System.Drawing.Size(182, 23);
            this.m_cmbPk.TabIndex = 4015;
            // 
            // m_lnkAddPk
            // 
            this.m_lnkAddPk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAddPk.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_lnkAddPk.CustomImage")));
            this.m_lnkAddPk.CustomText = "Add";
            this.m_lnkAddPk.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extFieldCol.SetLinkField(this.m_lnkAddPk, "");
            this.m_extFieldCol.SetLinkFieldAutoUpdate(this.m_lnkAddPk, false);
            this.m_lnkAddPk.Location = new System.Drawing.Point(194, 6);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAddPk, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkAddPk.Name = "m_lnkAddPk";
            this.m_lnkAddPk.ShortMode = false;
            this.m_lnkAddPk.Size = new System.Drawing.Size(104, 16);
            this.m_lnkAddPk.TabIndex = 4012;
            this.m_lnkAddPk.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAddPk.LinkClicked += new System.EventHandler(this.m_lnkAddPk_LinkClicked);
            // 
            // m_lvPks
            // 
            this.m_lvPks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lvPks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_lvPksColLabel});
            this.m_lvPks.EnableCustomisation = true;
            this.m_lvPks.FullRowSelect = true;
            this.m_lvPks.GridLines = true;
            this.m_lvPks.HideSelection = false;
            this.m_extFieldCol.SetLinkField(this.m_lvPks, "");
            this.m_extFieldCol.SetLinkFieldAutoUpdate(this.m_lvPks, false);
            this.m_lvPks.Location = new System.Drawing.Point(6, 26);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lvPks, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lvPks.MultiSelect = false;
            this.m_lvPks.Name = "m_lvPks";
            this.m_lvPks.Size = new System.Drawing.Size(498, 300);
            this.m_lvPks.TabIndex = 4011;
            this.m_lvPks.UseCompatibleStateImageBehavior = false;
            this.m_lvPks.View = System.Windows.Forms.View.Details;
            // 
            // m_lvPksColLabel
            // 
            this.m_lvPksColLabel.Field = "Libelle";
            this.m_lvPksColLabel.PrecisionWidth = 0D;
            this.m_lvPksColLabel.ProportionnalSize = false;
            this.m_lvPksColLabel.Text = "Label|50";
            this.m_lvPksColLabel.Visible = true;
            this.m_lvPksColLabel.Width = 200;
            // 
            // m_lnkRemovePk
            // 
            this.m_lnkRemovePk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkRemovePk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkRemovePk.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_lnkRemovePk.CustomImage")));
            this.m_lnkRemovePk.CustomText = "Remove";
            this.m_lnkRemovePk.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extFieldCol.SetLinkField(this.m_lnkRemovePk, "");
            this.m_extFieldCol.SetLinkFieldAutoUpdate(this.m_lnkRemovePk, false);
            this.m_lnkRemovePk.Location = new System.Drawing.Point(6, 332);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkRemovePk, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkRemovePk.Name = "m_lnkRemovePk";
            this.m_lnkRemovePk.ShortMode = false;
            this.m_lnkRemovePk.Size = new System.Drawing.Size(104, 20);
            this.m_lnkRemovePk.TabIndex = 4013;
            this.m_lnkRemovePk.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkRemovePk.LinkClicked += new System.EventHandler(this.m_lnkRemovePk_LinkClicked);
            // 
            // m_nudPk
            // 
            this.m_nudPk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extFieldCol.SetLinkField(this.m_nudPk, "");
            this.m_extFieldCol.SetLinkFieldAutoUpdate(this.m_nudPk, false);
            this.m_nudPk.ListeGeree = this.m_lvPks;
            this.m_nudPk.Location = new System.Drawing.Point(453, 331);
            this.m_nudPk.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_nudPk, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_nudPk.Name = "m_nudPk";
            this.m_nudPk.ProprieteNumero = "PrimaryKeyPosition";
            this.m_nudPk.Size = new System.Drawing.Size(51, 21);
            this.m_nudPk.TabIndex = 4014;
            // 
            // m_pageChampsCustom
            // 
            this.m_pageChampsCustom.Controls.Add(this.m_panelEditChamps);
            this.m_extFieldCol.SetLinkField(this.m_pageChampsCustom, "");
            this.m_extFieldCol.SetLinkFieldAutoUpdate(this.m_pageChampsCustom, false);
            this.m_pageChampsCustom.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageChampsCustom, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_pageChampsCustom.Name = "m_pageChampsCustom";
            this.m_pageChampsCustom.Selected = false;
            this.m_pageChampsCustom.Size = new System.Drawing.Size(662, 355);
            this.m_pageChampsCustom.TabIndex = 17;
            this.m_pageChampsCustom.Title = "Custom Fields|198";
            // 
            // m_panelEditChamps
            // 
            this.m_panelEditChamps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelEditChamps.AvecAffectationDirecteDeChamps = false;
            this.m_extFieldCol.SetLinkField(this.m_panelEditChamps, "");
            this.m_extFieldCol.SetLinkFieldAutoUpdate(this.m_panelEditChamps, false);
            this.m_panelEditChamps.Location = new System.Drawing.Point(2, 3);
            this.m_panelEditChamps.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEditChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelEditChamps.Name = "m_panelEditChamps";
            this.m_panelEditChamps.Size = new System.Drawing.Size(657, 349);
            this.m_panelEditChamps.TabIndex = 2;
            // 
            // m_pageTypesEquipements
            // 
            this.m_pageTypesEquipements.Controls.Add(this.m_typesEquipementsSelec);
            this.m_extFieldCol.SetLinkField(this.m_pageTypesEquipements, "");
            this.m_extFieldCol.SetLinkFieldAutoUpdate(this.m_pageTypesEquipements, false);
            this.m_pageTypesEquipements.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageTypesEquipements, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_pageTypesEquipements.Name = "m_pageTypesEquipements";
            this.m_pageTypesEquipements.Selected = false;
            this.m_pageTypesEquipements.Size = new System.Drawing.Size(662, 355);
            this.m_pageTypesEquipements.TabIndex = 14;
            this.m_pageTypesEquipements.Title = "Equipments Types associated|1243";
            // 
            // m_typesEquipementsSelec
            // 
            this.m_typesEquipementsSelec.Columns.AddRange(new sc2i.win32.common.ListViewAutoFilledColumn[] {
            this.m_colLabelTypeEquipement});
            this.m_typesEquipementsSelec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_typesEquipementsSelec.EnableCustomisation = true;
            this.m_typesEquipementsSelec.ExclusionParException = false;
            this.m_extFieldCol.SetLinkField(this.m_typesEquipementsSelec, "");
            this.m_extFieldCol.SetLinkFieldAutoUpdate(this.m_typesEquipementsSelec, false);
            this.m_typesEquipementsSelec.Location = new System.Drawing.Point(0, 0);
            this.m_typesEquipementsSelec.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_typesEquipementsSelec, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_typesEquipementsSelec.Name = "m_typesEquipementsSelec";
            this.m_typesEquipementsSelec.Size = new System.Drawing.Size(662, 355);
            this.m_typesEquipementsSelec.TabIndex = 3;
            // 
            // m_colLabelTypeEquipement
            // 
            this.m_colLabelTypeEquipement.Field = "Libelle";
            this.m_colLabelTypeEquipement.PrecisionWidth = 3062D;
            this.m_colLabelTypeEquipement.ProportionnalSize = true;
            this.m_colLabelTypeEquipement.Text = "Label|50";
            this.m_colLabelTypeEquipement.Visible = true;
            this.m_colLabelTypeEquipement.Width = 3062;
            // 
            // m_pageTypesSites
            // 
            this.m_pageTypesSites.Controls.Add(this.m_typesSitesSelec);
            this.m_extFieldCol.SetLinkField(this.m_pageTypesSites, "");
            this.m_extFieldCol.SetLinkFieldAutoUpdate(this.m_pageTypesSites, false);
            this.m_pageTypesSites.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageTypesSites, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_pageTypesSites.Name = "m_pageTypesSites";
            this.m_pageTypesSites.Selected = false;
            this.m_pageTypesSites.Size = new System.Drawing.Size(662, 355);
            this.m_pageTypesSites.TabIndex = 15;
            this.m_pageTypesSites.Title = "Associated Site Types |1244";
            // 
            // m_typesSitesSelec
            // 
            this.m_typesSitesSelec.Columns.AddRange(new sc2i.win32.common.ListViewAutoFilledColumn[] {
            this.m_colLabelTypeSite});
            this.m_typesSitesSelec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_typesSitesSelec.EnableCustomisation = true;
            this.m_typesSitesSelec.ExclusionParException = false;
            this.m_extFieldCol.SetLinkField(this.m_typesSitesSelec, "");
            this.m_extFieldCol.SetLinkFieldAutoUpdate(this.m_typesSitesSelec, false);
            this.m_typesSitesSelec.Location = new System.Drawing.Point(0, 0);
            this.m_typesSitesSelec.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_typesSitesSelec, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_typesSitesSelec.Name = "m_typesSitesSelec";
            this.m_typesSitesSelec.Size = new System.Drawing.Size(662, 355);
            this.m_typesSitesSelec.TabIndex = 2;
            // 
            // m_colLabelTypeSite
            // 
            this.m_colLabelTypeSite.Field = "Libelle";
            this.m_colLabelTypeSite.PrecisionWidth = 3062D;
            this.m_colLabelTypeSite.ProportionnalSize = true;
            this.m_colLabelTypeSite.Text = "Label|50";
            this.m_colLabelTypeSite.Visible = true;
            this.m_colLabelTypeSite.Width = 3062;
            // 
            // m_txtNom
            // 
            this.m_txtNom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extFieldCol.SetLinkField(this.m_txtNom, "Libelle");
            this.m_extFieldCol.SetLinkFieldAutoUpdate(this.m_txtNom, true);
            this.m_txtNom.Location = new System.Drawing.Point(58, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtNom, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtNom.Name = "m_txtNom";
            this.m_txtNom.Size = new System.Drawing.Size(313, 20);
            this.m_txtNom.TabIndex = 4;
            this.m_txtNom.Text = "[Libelle]";
            // 
            // m_lblNom
            // 
            this.m_extFieldCol.SetLinkField(this.m_lblNom, "");
            this.m_extFieldCol.SetLinkFieldAutoUpdate(this.m_lblNom, false);
            this.m_lblNom.Location = new System.Drawing.Point(4, 10);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblNom, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblNom.Name = "m_lblNom";
            this.m_lblNom.Size = new System.Drawing.Size(152, 13);
            this.m_lblNom.TabIndex = 3;
            this.m_lblNom.Text = "Label|50";
            // 
            // m_panOmbre
            // 
            this.m_panOmbre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panOmbre.Controls.Add(this.m_panTop);
            this.m_panOmbre.ForeColor = System.Drawing.Color.Black;
            this.m_extFieldCol.SetLinkField(this.m_panOmbre, "");
            this.m_extFieldCol.SetLinkFieldAutoUpdate(this.m_panOmbre, false);
            this.m_panOmbre.Location = new System.Drawing.Point(3, 3);
            this.m_panOmbre.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panOmbre, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panOmbre.Name = "m_panOmbre";
            this.m_panOmbre.Size = new System.Drawing.Size(425, 61);
            this.m_panOmbre.TabIndex = 4014;
            // 
            // m_panTop
            // 
            this.m_panTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panTop.Controls.Add(this.m_txtNom);
            this.m_panTop.Controls.Add(this.m_lblNom);
            this.m_extFieldCol.SetLinkField(this.m_panTop, "");
            this.m_extFieldCol.SetLinkFieldAutoUpdate(this.m_panTop, false);
            this.m_panTop.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panTop, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panTop.Name = "m_panTop";
            this.m_panTop.Size = new System.Drawing.Size(410, 128);
            this.m_panTop.TabIndex = 4011;
            // 
            // m_gestionnaireColonnes
            // 
            this.m_gestionnaireColonnes.ListeAssociee = this.m_wndColonnes;
            this.m_gestionnaireColonnes.ObjetEdite = null;
            this.m_gestionnaireColonnes.InitChamp += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireColonnes_InitChamp);
            this.m_gestionnaireColonnes.MAJ_Champs += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireColonnes_MAJ_Champs);
            // 
            // m_extFieldCol
            // 
            this.m_extFieldCol.SourceTypeString = "";
            // 
            // m_gestionnaireTabControl
            // 
            this.m_gestionnaireTabControl.TabControl = this.m_TabControl;
            this.m_gestionnaireTabControl.OnInitPage += new sc2i.win32.common.EventOnPageHandler(this.m_gestionnaireTabControl_OnInitPage);
            this.m_gestionnaireTabControl.OnMajChampsPage += new sc2i.win32.common.EventOnPageHandler(this.m_gestionnaireTabControl_OnMajChampsPage);
            // 
            // m_pageFormulaires
            // 
            this.m_pageFormulaires.Controls.Add(this.m_panelChamps);
            this.m_extFieldCol.SetLinkField(this.m_pageFormulaires, "");
            this.m_extFieldCol.SetLinkFieldAutoUpdate(this.m_pageFormulaires, true);
            this.m_pageFormulaires.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageFormulaires, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_pageFormulaires.Name = "m_pageFormulaires";
            this.m_pageFormulaires.Size = new System.Drawing.Size(662, 355);
            this.m_pageFormulaires.TabIndex = 18;
            this.m_pageFormulaires.Title = "Form|60";
            // 
            // m_panelChamps
            // 
            this.m_panelChamps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelChamps.BoldSelectedPage = true;
            this.m_panelChamps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelChamps.ElementEdite = null;
            this.m_panelChamps.ForeColor = System.Drawing.Color.Black;
            this.m_panelChamps.IDEPixelArea = false;
            this.m_extFieldCol.SetLinkField(this.m_panelChamps, "");
            this.m_extFieldCol.SetLinkFieldAutoUpdate(this.m_panelChamps, true);
            this.m_panelChamps.Location = new System.Drawing.Point(0, 0);
            this.m_panelChamps.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelChamps.Name = "m_panelChamps";
            this.m_panelChamps.Ombre = false;
            this.m_panelChamps.PositionTop = true;
            this.m_panelChamps.Size = new System.Drawing.Size(662, 355);
            this.m_panelChamps.TabIndex = 4;
            this.m_panelChamps.TextColor = System.Drawing.Color.Black;
            // 
            // CControlEditionTypeTableParametrable
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_TabControl);
            this.Controls.Add(this.m_panOmbre);
            this.m_extFieldCol.SetLinkField(this, "");
            this.m_extFieldCol.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControlEditionTypeTableParametrable";
            this.Size = new System.Drawing.Size(687, 469);
            this.m_TabControl.ResumeLayout(false);
            this.m_TabControl.PerformLayout();
            this.m_pageColonnes.ResumeLayout(false);
            this.m_panelCol.ResumeLayout(false);
            this.m_pageClePrimaire.ResumeLayout(false);
            this.m_pageChampsCustom.ResumeLayout(false);
            this.m_pageTypesEquipements.ResumeLayout(false);
            this.m_pageTypesSites.ResumeLayout(false);
            this.m_panOmbre.ResumeLayout(false);
            this.m_panOmbre.PerformLayout();
            this.m_panTop.ResumeLayout(false);
            this.m_panTop.PerformLayout();
            this.m_pageFormulaires.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private sc2i.win32.common.CWndLinkStd m_lnkAjouter;
		private sc2i.win32.common.ListViewAutoFilled m_wndColonnes;
		private sc2i.win32.common.ListViewAutoFilledColumn m_lvColsLabel;
		private sc2i.win32.common.ListViewAutoFilledColumn m_lvColsType;
		private System.Windows.Forms.Panel m_panelCol;
		private sc2i.win32.common.CCtrlUpDownListView m_ctrlMD;
		private sc2i.win32.common.CWndLinkStd m_lnkSupprimer;
		private System.Windows.Forms.TextBox m_txtNom;
		private System.Windows.Forms.Label m_lblNom;
		private CControlEditionColonneTableParametrable m_ctrlEditCol;
		private sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee m_gestionnaireColonnes;
		private sc2i.win32.common.CExtLinkField m_extFieldCol;
		private sc2i.win32.common.C2iTabControl m_TabControl;
		private Crownwood.Magic.Controls.TabPage m_pageColonnes;
		private Crownwood.Magic.Controls.TabPage m_pageTypesEquipements;
		private Crownwood.Magic.Controls.TabPage m_pageTypesSites;
		private sc2i.win32.common.C2iPanelOmbre m_panOmbre;
		private System.Windows.Forms.Panel m_panTop;
		private sc2i.win32.data.navigation.CPanelListeRelationSelection m_typesSitesSelec;
		private sc2i.win32.data.navigation.CPanelListeRelationSelection m_typesEquipementsSelec;
		private sc2i.win32.common.ListViewAutoFilledColumn m_colLabelTypeEquipement;
		private sc2i.win32.common.ListViewAutoFilledColumn m_colLabelTypeSite;
		private Crownwood.Magic.Controls.TabPage m_pageClePrimaire;
		private System.Windows.Forms.ComboBox m_cmbPk;
		private sc2i.win32.common.CWndLinkStd m_lnkAddPk;
		private sc2i.win32.common.ListViewAutoFilled m_lvPks;
		private sc2i.win32.common.ListViewAutoFilledColumn m_lvPksColLabel;
		private sc2i.win32.common.CWndLinkStd m_lnkRemovePk;
		private sc2i.win32.common.CCtrlUpDownListView m_nudPk;
		private Crownwood.Magic.Controls.TabPage m_pageChampsCustom;
		private timos.win32.composants.CPanelEditDefinisseurChampsCustom m_panelEditChamps;
		private sc2i.win32.common.CGestionnaireTabControl m_gestionnaireTabControl;
        private Crownwood.Magic.Controls.TabPage m_pageFormulaires;
        private sc2i.win32.data.dynamic.CPanelChampsCustom m_panelChamps;
	}
}
