namespace timos
{
	partial class CFormRemplacerEquipement
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

		#region Code généré par le Concepteur Windows Form

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.m_exStyle = new sc2i.win32.common.CExtStyle();
			this.label1 = new System.Windows.Forms.Label();
			this.m_radioSite = new System.Windows.Forms.RadioButton();
			this.m_radioStock = new System.Windows.Forms.RadioButton();
			this.m_selectSite = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
			this.m_panelSite = new System.Windows.Forms.Panel();
			this.m_panelStock = new System.Windows.Forms.Panel();
			this.m_selectStock = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
			this.m_btnOk = new System.Windows.Forms.Button();
			this.m_btnAnnuler = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.m_txtInfo = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.m_selectActeur = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
			this.m_radioActeur = new System.Windows.Forms.RadioButton();
			this.m_panbtn = new System.Windows.Forms.Panel();
			this.m_btnAnnulerCeRemplacement = new System.Windows.Forms.Button();
			this.m_gbInfoRemplace = new System.Windows.Forms.GroupBox();
			this.m_lnkCoordonnee = new System.Windows.Forms.LinkLabel();
			this.m_selectTypeEquipementRemplace = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
			this.m_selectEquipementRemplace = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.m_lblSite = new System.Windows.Forms.Label();
			this.m_gbInfoRemplacant = new System.Windows.Forms.GroupBox();
			this.m_selectEquipementRemplacant = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.m_dtRemplacement = new sc2i.win32.common.C2iDateTimePicker();
			this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
			this.m_panelGlobal = new sc2i.win32.common.C2iPanel(this.components);
			this.m_panelSearchReplaced = new sc2i.win32.common.C2iPanel(this.components);
			this.m_panelSerialReplaced = new sc2i.win32.common.C2iPanel(this.components);
			this.label7 = new System.Windows.Forms.Label();
			this.m_txtSerialNumber = new sc2i.win32.common.C2iTextBox();
			this.m_cmbSelectProfil = new sc2i.win32.data.CComboBoxListeObjetsDonnees();
			this.m_ctrlFindCoordonnee = new timos.coordonnees.CControlFindIObjetACoordonnees();
			this.m_panelSite.SuspendLayout();
			this.m_panelStock.SuspendLayout();
			this.panel1.SuspendLayout();
			this.m_panbtn.SuspendLayout();
			this.m_gbInfoRemplace.SuspendLayout();
			this.m_gbInfoRemplacant.SuspendLayout();
			this.m_panelGlobal.SuspendLayout();
			this.m_panelSearchReplaced.SuspendLayout();
			this.m_panelSerialReplaced.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 106);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(201, 13);
			this.m_exStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label1.TabIndex = 0;
			this.label1.Text = "Move to|242";
			// 
			// m_radioSite
			// 
			this.m_radioSite.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.m_radioSite.Location = new System.Drawing.Point(13, 126);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_radioSite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_radioSite.Name = "m_radioSite";
			this.m_radioSite.Size = new System.Drawing.Size(70, 17);
			this.m_exStyle.SetStyleBackColor(this.m_radioSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_radioSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_radioSite.TabIndex = 1;
			this.m_radioSite.TabStop = true;
			this.m_radioSite.Text = "A site|233";
			this.m_radioSite.UseVisualStyleBackColor = true;
			this.m_radioSite.CheckedChanged += new System.EventHandler(this.m_radioSite_CheckedChanged);
			// 
			// m_radioStock
			// 
			this.m_radioStock.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.m_radioStock.Location = new System.Drawing.Point(13, 155);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_radioStock, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_radioStock.Name = "m_radioStock";
			this.m_radioStock.Size = new System.Drawing.Size(80, 17);
			this.m_exStyle.SetStyleBackColor(this.m_radioStock, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_radioStock, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_radioStock.TabIndex = 2;
			this.m_radioStock.TabStop = true;
			this.m_radioStock.Text = "A stock|234";
			this.m_radioStock.UseVisualStyleBackColor = true;
			this.m_radioStock.CheckedChanged += new System.EventHandler(this.m_radioStock_CheckedChanged);
			// 
			// m_selectSite
			// 
			this.m_selectSite.ElementSelectionne = null;
			this.m_selectSite.HasLink = true;
			this.m_selectSite.Location = new System.Drawing.Point(15, 3);
			this.m_selectSite.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_selectSite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_selectSite.Name = "m_selectSite";
			this.m_selectSite.SelectedObject = null;
			this.m_selectSite.Size = new System.Drawing.Size(502, 21);
			this.m_exStyle.SetStyleBackColor(this.m_selectSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_selectSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_selectSite.TabIndex = 0;
			this.m_selectSite.ElementSelectionneChanged += new System.EventHandler(this.m_txtSelectSite_ElementSelectionneChanged);
			// 
			// m_panelSite
			// 
			this.m_panelSite.Controls.Add(this.m_selectSite);
			this.m_panelSite.Location = new System.Drawing.Point(105, 122);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelSite, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_panelSite.Name = "m_panelSite";
			this.m_panelSite.Size = new System.Drawing.Size(520, 29);
			this.m_exStyle.SetStyleBackColor(this.m_panelSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_panelSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_panelSite.TabIndex = 4;
			// 
			// m_panelStock
			// 
			this.m_panelStock.Controls.Add(this.m_selectStock);
			this.m_panelStock.Location = new System.Drawing.Point(105, 150);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelStock, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_panelStock.Name = "m_panelStock";
			this.m_panelStock.Size = new System.Drawing.Size(520, 32);
			this.m_exStyle.SetStyleBackColor(this.m_panelStock, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_panelStock, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_panelStock.TabIndex = 5;
			// 
			// m_selectStock
			// 
			this.m_selectStock.ElementSelectionne = null;
			this.m_selectStock.HasLink = true;
			this.m_selectStock.Location = new System.Drawing.Point(15, 3);
			this.m_selectStock.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_selectStock, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_selectStock.Name = "m_selectStock";
			this.m_selectStock.SelectedObject = null;
			this.m_selectStock.Size = new System.Drawing.Size(502, 21);
			this.m_exStyle.SetStyleBackColor(this.m_selectStock, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_selectStock, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_selectStock.TabIndex = 4;
			this.m_selectStock.ElementSelectionneChanged += new System.EventHandler(this.m_selectStock_ElementSelectionneChanged);
			// 
			// m_btnOk
			// 
			this.m_btnOk.Location = new System.Drawing.Point(213, 2);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnOk, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_btnOk.Name = "m_btnOk";
			this.m_btnOk.Size = new System.Drawing.Size(75, 23);
			this.m_exStyle.SetStyleBackColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_btnOk.TabIndex = 9;
			this.m_btnOk.Text = "Ok|10";
			this.m_btnOk.UseVisualStyleBackColor = true;
			this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
			// 
			// m_btnAnnuler
			// 
			this.m_btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnAnnuler.Location = new System.Drawing.Point(320, 2);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAnnuler, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_btnAnnuler.Name = "m_btnAnnuler";
			this.m_btnAnnuler.Size = new System.Drawing.Size(75, 23);
			this.m_exStyle.SetStyleBackColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_btnAnnuler.TabIndex = 10;
			this.m_btnAnnuler.Text = "Cancel|11";
			this.m_btnAnnuler.UseVisualStyleBackColor = true;
			this.m_btnAnnuler.Click += new System.EventHandler(this.m_btnAnnuler_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(7, 23);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(148, 13);
			this.m_exStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label3.TabIndex = 8;
			this.label3.Text = "Replacement information|538";
			// 
			// m_txtInfo
			// 
			this.m_txtInfo.Location = new System.Drawing.Point(178, 20);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtInfo, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_txtInfo.Name = "m_txtInfo";
			this.m_txtInfo.Size = new System.Drawing.Size(445, 20);
			this.m_exStyle.SetStyleBackColor(this.m_txtInfo, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_txtInfo, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_txtInfo.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.m_selectActeur);
			this.panel1.Location = new System.Drawing.Point(105, 181);
			this.m_gestionnaireModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(520, 32);
			this.m_exStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.panel1.TabIndex = 6;
			// 
			// m_selectActeur
			// 
			this.m_selectActeur.ElementSelectionne = null;
			this.m_selectActeur.HasLink = true;
			this.m_selectActeur.Location = new System.Drawing.Point(15, 3);
			this.m_selectActeur.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_selectActeur, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_selectActeur.Name = "m_selectActeur";
			this.m_selectActeur.SelectedObject = null;
			this.m_selectActeur.Size = new System.Drawing.Size(502, 21);
			this.m_exStyle.SetStyleBackColor(this.m_selectActeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_selectActeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_selectActeur.TabIndex = 4;
			this.m_selectActeur.ElementSelectionneChanged += new System.EventHandler(this.m_selectActeur_ElementSelectionneChanged);
			// 
			// m_radioActeur
			// 
			this.m_radioActeur.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.m_radioActeur.Location = new System.Drawing.Point(13, 184);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_radioActeur, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_radioActeur.Name = "m_radioActeur";
			this.m_radioActeur.Size = new System.Drawing.Size(91, 17);
			this.m_exStyle.SetStyleBackColor(this.m_radioActeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_radioActeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_radioActeur.TabIndex = 3;
			this.m_radioActeur.TabStop = true;
			this.m_radioActeur.Text = "A Member|317";
			this.m_radioActeur.UseVisualStyleBackColor = true;
			// 
			// m_panbtn
			// 
			this.m_panbtn.Controls.Add(this.m_btnAnnulerCeRemplacement);
			this.m_panbtn.Controls.Add(this.m_btnOk);
			this.m_panbtn.Controls.Add(this.m_btnAnnuler);
			this.m_panbtn.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.m_panbtn.Location = new System.Drawing.Point(0, 370);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panbtn, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_panbtn.Name = "m_panbtn";
			this.m_panbtn.Size = new System.Drawing.Size(637, 27);
			this.m_exStyle.SetStyleBackColor(this.m_panbtn, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_panbtn, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_panbtn.TabIndex = 4;
			// 
			// m_btnAnnulerCeRemplacement
			// 
			this.m_btnAnnulerCeRemplacement.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnAnnulerCeRemplacement.Location = new System.Drawing.Point(427, 2);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAnnulerCeRemplacement, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_btnAnnulerCeRemplacement.Name = "m_btnAnnulerCeRemplacement";
			this.m_btnAnnulerCeRemplacement.Size = new System.Drawing.Size(193, 23);
			this.m_exStyle.SetStyleBackColor(this.m_btnAnnulerCeRemplacement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_btnAnnulerCeRemplacement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_btnAnnulerCeRemplacement.TabIndex = 11;
			this.m_btnAnnulerCeRemplacement.Text = "Cancel and remove  replacement|541";
			this.m_btnAnnulerCeRemplacement.UseVisualStyleBackColor = true;
			this.m_btnAnnulerCeRemplacement.Click += new System.EventHandler(this.m_btnAnnulerCeRemplacement_Click);
			// 
			// m_gbInfoRemplace
			// 
			this.m_gbInfoRemplace.Controls.Add(this.m_panelSerialReplaced);
			this.m_gbInfoRemplace.Controls.Add(this.m_panelSearchReplaced);
			this.m_gbInfoRemplace.Controls.Add(this.m_radioSite);
			this.m_gbInfoRemplace.Controls.Add(this.panel1);
			this.m_gbInfoRemplace.Controls.Add(this.m_radioStock);
			this.m_gbInfoRemplace.Controls.Add(this.m_radioActeur);
			this.m_gbInfoRemplace.Controls.Add(this.m_panelSite);
			this.m_gbInfoRemplace.Controls.Add(this.m_panelStock);
			this.m_gbInfoRemplace.Controls.Add(this.label1);
			this.m_gbInfoRemplace.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_gbInfoRemplace.Location = new System.Drawing.Point(0, 0);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_gbInfoRemplace, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_gbInfoRemplace.Name = "m_gbInfoRemplace";
			this.m_gbInfoRemplace.Size = new System.Drawing.Size(634, 216);
			this.m_exStyle.SetStyleBackColor(this.m_gbInfoRemplace, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_gbInfoRemplace, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_gbInfoRemplace.TabIndex = 2;
			this.m_gbInfoRemplace.TabStop = false;
			this.m_gbInfoRemplace.Text = "Replaced equipment|539";
			// 
			// m_lnkCoordonnee
			// 
			this.m_lnkCoordonnee.Location = new System.Drawing.Point(508, 33);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkCoordonnee, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_lnkCoordonnee.Name = "m_lnkCoordonnee";
			this.m_lnkCoordonnee.Size = new System.Drawing.Size(114, 17);
			this.m_exStyle.SetStyleBackColor(this.m_lnkCoordonnee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_lnkCoordonnee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_lnkCoordonnee.TabIndex = 16;
			this.m_lnkCoordonnee.TabStop = true;
			this.m_lnkCoordonnee.Text = "Search by coordinate|1162";
			this.m_lnkCoordonnee.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkCoordonnee_LinkClicked);
			// 
			// m_selectTypeEquipementRemplace
			// 
			this.m_selectTypeEquipementRemplace.ElementSelectionne = null;
			this.m_selectTypeEquipementRemplace.HasLink = true;
			this.m_selectTypeEquipementRemplace.Location = new System.Drawing.Point(120, 5);
			this.m_selectTypeEquipementRemplace.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_selectTypeEquipementRemplace, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_selectTypeEquipementRemplace.Name = "m_selectTypeEquipementRemplace";
			this.m_selectTypeEquipementRemplace.SelectedObject = null;
			this.m_selectTypeEquipementRemplace.Size = new System.Drawing.Size(505, 21);
			this.m_exStyle.SetStyleBackColor(this.m_selectTypeEquipementRemplace, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_selectTypeEquipementRemplace, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_selectTypeEquipementRemplace.TabIndex = 0;
			this.m_selectTypeEquipementRemplace.ElementSelectionneChanged += new System.EventHandler(this.m_selectTypeEquipementRemplace_ElementSelectionneChanged);
			// 
			// m_selectEquipementRemplace
			// 
			this.m_selectEquipementRemplace.ElementSelectionne = null;
			this.m_selectEquipementRemplace.HasLink = true;
			this.m_selectEquipementRemplace.Location = new System.Drawing.Point(120, 29);
			this.m_selectEquipementRemplace.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_selectEquipementRemplace, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_selectEquipementRemplace.Name = "m_selectEquipementRemplace";
			this.m_selectEquipementRemplace.SelectedObject = null;
			this.m_selectEquipementRemplace.Size = new System.Drawing.Size(382, 21);
			this.m_exStyle.SetStyleBackColor(this.m_selectEquipementRemplace, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_selectEquipementRemplace, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_selectEquipementRemplace.TabIndex = 0;
			this.m_selectEquipementRemplace.ElementSelectionneChanged += new System.EventHandler(this.m_selectEquipementRemplace_ElementSelectionneChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 7);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(108, 17);
			this.m_exStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label2.TabIndex = 15;
			this.label2.Text = "Equipment Type|194";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 33);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(96, 13);
			this.m_exStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label4.TabIndex = 15;
			this.label4.Text = "Equipment|195";
			// 
			// m_lblSite
			// 
			this.m_lblSite.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblSite.ForeColor = System.Drawing.Color.Beige;
			this.m_lblSite.Location = new System.Drawing.Point(0, 0);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblSite, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_lblSite.Name = "m_lblSite";
			this.m_lblSite.Size = new System.Drawing.Size(633, 20);
			this.m_exStyle.SetStyleBackColor(this.m_lblSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_lblSite, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTitrePanel);
			this.m_lblSite.TabIndex = 18;
			this.m_lblSite.Text = "SITE|546";
			this.m_lblSite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_gbInfoRemplacant
			// 
			this.m_gbInfoRemplacant.Controls.Add(this.m_cmbSelectProfil);
			this.m_gbInfoRemplacant.Controls.Add(this.m_selectEquipementRemplacant);
			this.m_gbInfoRemplacant.Controls.Add(this.label6);
			this.m_gbInfoRemplacant.Controls.Add(this.label5);
			this.m_gbInfoRemplacant.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_gbInfoRemplacant.Location = new System.Drawing.Point(0, 216);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_gbInfoRemplacant, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_gbInfoRemplacant.Name = "m_gbInfoRemplacant";
			this.m_gbInfoRemplacant.Size = new System.Drawing.Size(634, 77);
			this.m_exStyle.SetStyleBackColor(this.m_gbInfoRemplacant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_gbInfoRemplacant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_gbInfoRemplacant.TabIndex = 3;
			this.m_gbInfoRemplacant.TabStop = false;
			this.m_gbInfoRemplacant.Text = "Replaced by|540";
			// 
			// m_selectEquipementRemplacant
			// 
			this.m_selectEquipementRemplacant.ElementSelectionne = null;
			this.m_selectEquipementRemplacant.HasLink = true;
			this.m_selectEquipementRemplacant.Location = new System.Drawing.Point(148, 44);
			this.m_selectEquipementRemplacant.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_selectEquipementRemplacant, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_selectEquipementRemplacant.Name = "m_selectEquipementRemplacant";
			this.m_selectEquipementRemplacant.SelectedObject = null;
			this.m_selectEquipementRemplacant.Size = new System.Drawing.Size(478, 21);
			this.m_exStyle.SetStyleBackColor(this.m_selectEquipementRemplacant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_selectEquipementRemplacant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_selectEquipementRemplacant.TabIndex = 18;
			this.m_selectEquipementRemplacant.ElementSelectionneChanged += new System.EventHandler(this.m_selectEquipementRemplacant_ElementSelectionneChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(6, 18);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(156, 14);
			this.m_exStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label6.TabIndex = 17;
			this.label6.Text = "Pre-filter with Profile|1163";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(6, 46);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(97, 17);
			this.m_exStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label5.TabIndex = 17;
			this.label5.Text = "Equipment|195";
			// 
			// m_dtRemplacement
			// 
			this.m_dtRemplacement.CustomFormat = "dd/MM/yyyy HH:mm";
			this.m_dtRemplacement.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dtRemplacement.Location = new System.Drawing.Point(178, 42);
			this.m_dtRemplacement.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_dtRemplacement, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_dtRemplacement.Name = "m_dtRemplacement";
			this.m_dtRemplacement.Size = new System.Drawing.Size(121, 20);
			this.m_exStyle.SetStyleBackColor(this.m_dtRemplacement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_dtRemplacement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_dtRemplacement.TabIndex = 1;
			this.m_dtRemplacement.Value = new System.DateTime(2003, 4, 2, 9, 17, 49, 526);
			// 
			// m_gestionnaireModeEdition
			// 
			this.m_gestionnaireModeEdition.ModeEdition = true;
			// 
			// m_panelGlobal
			// 
			this.m_panelGlobal.Controls.Add(this.m_gbInfoRemplacant);
			this.m_panelGlobal.Controls.Add(this.m_gbInfoRemplace);
			this.m_panelGlobal.Location = new System.Drawing.Point(3, 60);
			this.m_panelGlobal.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelGlobal, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_panelGlobal.Name = "m_panelGlobal";
			this.m_panelGlobal.Size = new System.Drawing.Size(634, 306);
			this.m_exStyle.SetStyleBackColor(this.m_panelGlobal, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_panelGlobal, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_panelGlobal.TabIndex = 19;
			// 
			// m_panelSearchReplaced
			// 
			this.m_panelSearchReplaced.Controls.Add(this.label2);
			this.m_panelSearchReplaced.Controls.Add(this.m_ctrlFindCoordonnee);
			this.m_panelSearchReplaced.Controls.Add(this.label4);
			this.m_panelSearchReplaced.Controls.Add(this.m_lnkCoordonnee);
			this.m_panelSearchReplaced.Controls.Add(this.m_selectEquipementRemplace);
			this.m_panelSearchReplaced.Controls.Add(this.m_selectTypeEquipementRemplace);
			this.m_panelSearchReplaced.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_panelSearchReplaced.Location = new System.Drawing.Point(3, 16);
			this.m_panelSearchReplaced.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelSearchReplaced, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_panelSearchReplaced.Name = "m_panelSearchReplaced";
			this.m_panelSearchReplaced.Size = new System.Drawing.Size(628, 81);
			this.m_exStyle.SetStyleBackColor(this.m_panelSearchReplaced, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_panelSearchReplaced, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_panelSearchReplaced.TabIndex = 17;
			// 
			// m_panelSerialReplaced
			// 
			this.m_panelSerialReplaced.Controls.Add(this.m_txtSerialNumber);
			this.m_panelSerialReplaced.Controls.Add(this.label7);
			this.m_panelSerialReplaced.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_panelSerialReplaced.Location = new System.Drawing.Point(3, 97);
			this.m_panelSerialReplaced.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelSerialReplaced, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_panelSerialReplaced.Name = "m_panelSerialReplaced";
			this.m_panelSerialReplaced.Size = new System.Drawing.Size(628, 23);
			this.m_exStyle.SetStyleBackColor(this.m_panelSerialReplaced, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_panelSerialReplaced, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_panelSerialReplaced.TabIndex = 18;
			this.m_panelSerialReplaced.Visible = false;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(7, 3);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(96, 13);
			this.m_exStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label7.TabIndex = 16;
			this.label7.Text = "Serial number|223";
			// 
			// m_txtSerialNumber
			// 
			this.m_txtSerialNumber.Location = new System.Drawing.Point(120, 2);
			this.m_txtSerialNumber.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSerialNumber, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_txtSerialNumber.Name = "m_txtSerialNumber";
			this.m_txtSerialNumber.Size = new System.Drawing.Size(382, 20);
			this.m_exStyle.SetStyleBackColor(this.m_txtSerialNumber, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_txtSerialNumber, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_txtSerialNumber.TabIndex = 17;
			// 
			// m_cmbSelectProfil
			// 
			this.m_cmbSelectProfil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cmbSelectProfil.ElementSelectionne = null;
			this.m_cmbSelectProfil.FormattingEnabled = true;
			this.m_cmbSelectProfil.IsLink = false;
			this.m_cmbSelectProfil.ListDonnees = null;
			this.m_cmbSelectProfil.Location = new System.Drawing.Point(148, 11);
			this.m_cmbSelectProfil.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbSelectProfil, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_cmbSelectProfil.Name = "m_cmbSelectProfil";
			this.m_cmbSelectProfil.NullAutorise = true;
			this.m_cmbSelectProfil.ProprieteAffichee = null;
			this.m_cmbSelectProfil.ProprieteParentListeObjets = null;
			this.m_cmbSelectProfil.SelectionneurParent = null;
			this.m_cmbSelectProfil.Size = new System.Drawing.Size(429, 21);
			this.m_exStyle.SetStyleBackColor(this.m_cmbSelectProfil, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_cmbSelectProfil, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_cmbSelectProfil.TabIndex = 19;
			this.m_cmbSelectProfil.TextNull = "";
			this.m_cmbSelectProfil.Tri = true;
			this.m_cmbSelectProfil.SelectedValueChanged += new System.EventHandler(this.m_cmbSelectProfil_SelectedValueChanged);
			// 
			// m_ctrlFindCoordonnee
			// 
			this.m_ctrlFindCoordonnee.AfficherListeResultat = false;
			this.m_ctrlFindCoordonnee.BoutonDeRechercheVisible = true;
			this.m_ctrlFindCoordonnee.BoutonOptionsVisible = false;
			this.m_ctrlFindCoordonnee.CriteresRecherche = timos.data.EObjetACoordonnee.Equipement;
			this.m_ctrlFindCoordonnee.Location = new System.Drawing.Point(214, 53);
			this.m_ctrlFindCoordonnee.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_ctrlFindCoordonnee, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_ctrlFindCoordonnee.Name = "m_ctrlFindCoordonnee";
			this.m_ctrlFindCoordonnee.NaviguerAutomatiquementVersResultatUnique = false;
			this.m_ctrlFindCoordonnee.OptionsAfficheesAuLancement = false;
			this.m_ctrlFindCoordonnee.Size = new System.Drawing.Size(406, 26);
			this.m_exStyle.SetStyleBackColor(this.m_ctrlFindCoordonnee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_ctrlFindCoordonnee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_ctrlFindCoordonnee.TabIndex = 0;
			this.m_ctrlFindCoordonnee.OnButonSearcheClick += new System.EventHandler(this.m_ctrlFindCoordonnee_OnButonSearcheClick);
			// 
			// CFormRemplacerEquipement
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(637, 397);
			this.Controls.Add(this.m_panelGlobal);
			this.Controls.Add(this.m_dtRemplacement);
			this.Controls.Add(this.m_lblSite);
			this.Controls.Add(this.m_panbtn);
			this.Controls.Add(this.m_txtInfo);
			this.Controls.Add(this.label3);
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
			this.Name = "CFormRemplacerEquipement";
			this.m_exStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
			this.m_exStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
			this.Text = "Equipment replacement|542";
			this.Load += new System.EventHandler(this.CFormRemplacerEquipement_Load);
			this.m_panelSite.ResumeLayout(false);
			this.m_panelStock.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.m_panbtn.ResumeLayout(false);
			this.m_gbInfoRemplace.ResumeLayout(false);
			this.m_gbInfoRemplacant.ResumeLayout(false);
			this.m_panelGlobal.ResumeLayout(false);
			this.m_panelSearchReplaced.ResumeLayout(false);
			this.m_panelSerialReplaced.ResumeLayout(false);
			this.m_panelSerialReplaced.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private sc2i.win32.common.CExtStyle m_exStyle;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton m_radioSite;
		private System.Windows.Forms.RadioButton m_radioStock;
		private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_selectSite;
		private System.Windows.Forms.Panel m_panelSite;
		private System.Windows.Forms.Panel m_panelStock;
		private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_selectStock;
		private System.Windows.Forms.Button m_btnOk;
		private System.Windows.Forms.Button m_btnAnnuler;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox m_txtInfo;
		private System.Windows.Forms.Panel panel1;
		private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_selectActeur;
		private System.Windows.Forms.RadioButton m_radioActeur;
		private System.Windows.Forms.Panel m_panbtn;
		private System.Windows.Forms.GroupBox m_gbInfoRemplace;
		private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_selectEquipementRemplace;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label m_lblSite;
		private System.Windows.Forms.GroupBox m_gbInfoRemplacant;
		private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_selectEquipementRemplacant;
		private System.Windows.Forms.Label label5;
		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private sc2i.win32.common.C2iDateTimePicker m_dtRemplacement;
        private System.Windows.Forms.Button m_btnAnnulerCeRemplacement;
        private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_selectTypeEquipementRemplace;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel m_lnkCoordonnee;
        private System.Windows.Forms.Label label6;
		private timos.coordonnees.CControlFindIObjetACoordonnees m_ctrlFindCoordonnee;
		private sc2i.win32.common.C2iPanel m_panelGlobal;
		private sc2i.win32.common.C2iPanel m_panelSerialReplaced;
		private sc2i.win32.common.C2iPanel m_panelSearchReplaced;
		private System.Windows.Forms.Label label7;
		private sc2i.win32.common.C2iTextBox m_txtSerialNumber;
		private sc2i.win32.data.CComboBoxListeObjetsDonnees m_cmbSelectProfil;
	}
}
