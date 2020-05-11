using sc2i.common;

namespace timos
{
	partial class CFormDeplacerEquipement
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
            this.m_exStyle = new sc2i.win32.common.CExtStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.m_radioSite = new System.Windows.Forms.RadioButton();
            this.m_radioStock = new System.Windows.Forms.RadioButton();
            this.m_selectSite = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_panelSite = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.m_cmbEquipement = new sc2i.win32.data.navigation.CComboBoxArbreObjetDonneesHierarchique();
            this.m_panelStock = new System.Windows.Forms.Panel();
            this.m_selectStock = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_btnAnnuler = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtInfo = new System.Windows.Forms.TextBox();
            this.m_selectUser = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_dtMouvement = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_selectActeur = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_radioActeur = new System.Windows.Forms.RadioButton();
            this.m_panbtn = new System.Windows.Forms.Panel();
            this.m_editCoordonnee = new timos.coordonnees.CControlEditeCoordonnee();
            this.m_panelCoordonnee = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.m_extModulesAssociator = new timos.CExtModulesAssociator();
            this.label7 = new System.Windows.Forms.Label();
            this.m_cmbEquipementStock = new sc2i.win32.data.navigation.CComboBoxArbreObjetDonneesHierarchique();
            this.m_panelSite.SuspendLayout();
            this.m_panelStock.SuspendLayout();
            this.panel1.SuspendLayout();
            this.m_panbtn.SuspendLayout();
            this.m_panelCoordonnee.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 86);
            this.m_extModulesAssociator.SetModules(this.label1, "");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.m_exStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 0;
            this.label1.Text = "Move to|242";
            // 
            // m_radioSite
            // 
            this.m_radioSite.AutoSize = true;
            this.m_radioSite.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_radioSite.Location = new System.Drawing.Point(15, 102);
            this.m_extModulesAssociator.SetModules(this.m_radioSite, "");
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
            this.m_radioStock.AutoSize = true;
            this.m_radioStock.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_radioStock.Location = new System.Drawing.Point(15, 159);
            this.m_extModulesAssociator.SetModules(this.m_radioStock, "ASTOCK");
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
            this.m_selectSite.FonctionTextNull = null;
            this.m_selectSite.HasLink = true;
            this.m_selectSite.Location = new System.Drawing.Point(3, 3);
            this.m_selectSite.LockEdition = false;
            this.m_extModulesAssociator.SetModules(this.m_selectSite, "");
            this.m_selectSite.Name = "m_selectSite";
            this.m_selectSite.SelectedObject = null;
            this.m_selectSite.Size = new System.Drawing.Size(514, 21);
            this.m_exStyle.SetStyleBackColor(this.m_selectSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_selectSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectSite.TabIndex = 3;
            this.m_selectSite.TextNull = "";
            this.m_selectSite.ElementSelectionneChanged += new System.EventHandler(this.m_txtSelectSite_ElementSelectionneChanged);
            // 
            // m_panelSite
            // 
            this.m_panelSite.Controls.Add(this.label2);
            this.m_panelSite.Controls.Add(this.m_cmbEquipement);
            this.m_panelSite.Controls.Add(this.m_selectSite);
            this.m_panelSite.Location = new System.Drawing.Point(102, 102);
            this.m_extModulesAssociator.SetModules(this.m_panelSite, "");
            this.m_panelSite.Name = "m_panelSite";
            this.m_panelSite.Size = new System.Drawing.Size(520, 56);
            this.m_exStyle.SetStyleBackColor(this.m_panelSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_panelSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelSite.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 34);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.m_exStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 5;
            this.label2.Text = "Equipment|235";
            // 
            // m_cmbEquipement
            // 
            this.m_cmbEquipement.BackColor = System.Drawing.Color.White;
            this.m_cmbEquipement.ElementSelectionne = null;
            this.m_cmbEquipement.Location = new System.Drawing.Point(86, 30);
            this.m_cmbEquipement.LockEdition = false;
            this.m_extModulesAssociator.SetModules(this.m_cmbEquipement, "");
            this.m_cmbEquipement.Name = "m_cmbEquipement";
            this.m_cmbEquipement.NullAutorise = false;
            this.m_cmbEquipement.Size = new System.Drawing.Size(431, 21);
            this.m_exStyle.SetStyleBackColor(this.m_cmbEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_cmbEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbEquipement.TabIndex = 4;
            this.m_cmbEquipement.TextNull = "[None]";
            this.m_cmbEquipement.ElementSelectionneChanged += new System.EventHandler(this.m_cmbEquipement_ElementSelectionneChanged);
            // 
            // m_panelStock
            // 
            this.m_panelStock.Controls.Add(this.label7);
            this.m_panelStock.Controls.Add(this.m_cmbEquipementStock);
            this.m_panelStock.Controls.Add(this.m_selectStock);
            this.m_panelStock.Location = new System.Drawing.Point(102, 159);
            this.m_extModulesAssociator.SetModules(this.m_panelStock, "ASTOCK");
            this.m_panelStock.Name = "m_panelStock";
            this.m_panelStock.Size = new System.Drawing.Size(520, 56);
            this.m_exStyle.SetStyleBackColor(this.m_panelStock, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_panelStock, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelStock.TabIndex = 5;
            // 
            // m_selectStock
            // 
            this.m_selectStock.ElementSelectionne = null;
            this.m_selectStock.FonctionTextNull = null;
            this.m_selectStock.HasLink = true;
            this.m_selectStock.Location = new System.Drawing.Point(3, 3);
            this.m_selectStock.LockEdition = false;
            this.m_extModulesAssociator.SetModules(this.m_selectStock, "");
            this.m_selectStock.Name = "m_selectStock";
            this.m_selectStock.SelectedObject = null;
            this.m_selectStock.Size = new System.Drawing.Size(514, 21);
            this.m_exStyle.SetStyleBackColor(this.m_selectStock, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_selectStock, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectStock.TabIndex = 4;
            this.m_selectStock.TextNull = "";
            this.m_selectStock.ElementSelectionneChanged += new System.EventHandler(this.m_selectStock_ElementSelectionneChanged);
            // 
            // m_btnOk
            // 
            this.m_btnOk.Location = new System.Drawing.Point(213, 3);
            this.m_extModulesAssociator.SetModules(this.m_btnOk, "");
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(75, 23);
            this.m_exStyle.SetStyleBackColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnOk.TabIndex = 6;
            this.m_btnOk.Text = "Ok|10";
            this.m_btnOk.UseVisualStyleBackColor = true;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnAnnuler.Location = new System.Drawing.Point(327, 3);
            this.m_extModulesAssociator.SetModules(this.m_btnAnnuler, "");
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(75, 23);
            this.m_exStyle.SetStyleBackColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAnnuler.TabIndex = 7;
            this.m_btnAnnuler.Text = "Cancel|11";
            this.m_btnAnnuler.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 13);
            this.m_exStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 8;
            this.label3.Text = "Movement information|244";
            // 
            // m_txtInfo
            // 
            this.m_txtInfo.Location = new System.Drawing.Point(140, 6);
            this.m_extModulesAssociator.SetModules(this.m_txtInfo, "");
            this.m_txtInfo.Name = "m_txtInfo";
            this.m_txtInfo.Size = new System.Drawing.Size(479, 20);
            this.m_exStyle.SetStyleBackColor(this.m_txtInfo, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_txtInfo, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtInfo.TabIndex = 0;
            // 
            // m_selectUser
            // 
            this.m_selectUser.ElementSelectionne = null;
            this.m_selectUser.FonctionTextNull = null;
            this.m_selectUser.HasLink = true;
            this.m_selectUser.Location = new System.Drawing.Point(140, 32);
            this.m_selectUser.LockEdition = false;
            this.m_extModulesAssociator.SetModules(this.m_selectUser, "");
            this.m_selectUser.Name = "m_selectUser";
            this.m_selectUser.SelectedObject = null;
            this.m_selectUser.Size = new System.Drawing.Size(476, 21);
            this.m_exStyle.SetStyleBackColor(this.m_selectUser, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_selectUser, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectUser.TabIndex = 1;
            this.m_selectUser.TextNull = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 36);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.m_exStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 11;
            this.label4.Text = "User|245";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 62);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.m_exStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 12;
            this.label5.Text = "Date|246";
            // 
            // m_dtMouvement
            // 
            this.m_dtMouvement.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.m_dtMouvement.Location = new System.Drawing.Point(140, 58);
            this.m_extModulesAssociator.SetModules(this.m_dtMouvement, "");
            this.m_dtMouvement.Name = "m_dtMouvement";
            this.m_dtMouvement.Size = new System.Drawing.Size(93, 20);
            this.m_exStyle.SetStyleBackColor(this.m_dtMouvement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_dtMouvement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_dtMouvement.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_selectActeur);
            this.panel1.Location = new System.Drawing.Point(102, 221);
            this.m_extModulesAssociator.SetModules(this.panel1, "");
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(520, 32);
            this.m_exStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 14;
            // 
            // m_selectActeur
            // 
            this.m_selectActeur.ElementSelectionne = null;
            this.m_selectActeur.FonctionTextNull = null;
            this.m_selectActeur.HasLink = true;
            this.m_selectActeur.Location = new System.Drawing.Point(3, 3);
            this.m_selectActeur.LockEdition = false;
            this.m_extModulesAssociator.SetModules(this.m_selectActeur, "");
            this.m_selectActeur.Name = "m_selectActeur";
            this.m_selectActeur.SelectedObject = null;
            this.m_selectActeur.Size = new System.Drawing.Size(514, 21);
            this.m_exStyle.SetStyleBackColor(this.m_selectActeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_selectActeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectActeur.TabIndex = 4;
            this.m_selectActeur.TextNull = "";
            this.m_selectActeur.ElementSelectionneChanged += new System.EventHandler(this.m_selectActeur_ElementSelectionneChanged);
            // 
            // m_radioActeur
            // 
            this.m_radioActeur.AutoSize = true;
            this.m_radioActeur.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_radioActeur.Location = new System.Drawing.Point(15, 221);
            this.m_extModulesAssociator.SetModules(this.m_radioActeur, "");
            this.m_radioActeur.Name = "m_radioActeur";
            this.m_radioActeur.Size = new System.Drawing.Size(92, 17);
            this.m_exStyle.SetStyleBackColor(this.m_radioActeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_radioActeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_radioActeur.TabIndex = 13;
            this.m_radioActeur.TabStop = true;
            this.m_radioActeur.Text = "A Member|317";
            this.m_radioActeur.UseVisualStyleBackColor = true;
            // 
            // m_panbtn
            // 
            this.m_panbtn.Controls.Add(this.m_btnOk);
            this.m_panbtn.Controls.Add(this.m_btnAnnuler);
            this.m_panbtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_panbtn.Location = new System.Drawing.Point(0, 293);
            this.m_extModulesAssociator.SetModules(this.m_panbtn, "");
            this.m_panbtn.Name = "m_panbtn";
            this.m_panbtn.Size = new System.Drawing.Size(633, 27);
            this.m_exStyle.SetStyleBackColor(this.m_panbtn, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_panbtn, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panbtn.TabIndex = 16;
            // 
            // m_editCoordonnee
            // 
            this.m_editCoordonnee.Coordonnee = "";
            this.m_editCoordonnee.Location = new System.Drawing.Point(90, 3);
            this.m_editCoordonnee.LockEdition = false;
            this.m_extModulesAssociator.SetModules(this.m_editCoordonnee, "");
            this.m_editCoordonnee.Name = "m_editCoordonnee";
            this.m_editCoordonnee.Size = new System.Drawing.Size(511, 22);
            this.m_exStyle.SetStyleBackColor(this.m_editCoordonnee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_editCoordonnee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_editCoordonnee.TabIndex = 17;
            // 
            // m_panelCoordonnee
            // 
            this.m_panelCoordonnee.Controls.Add(this.label6);
            this.m_panelCoordonnee.Controls.Add(this.m_editCoordonnee);
            this.m_panelCoordonnee.Location = new System.Drawing.Point(15, 259);
            this.m_extModulesAssociator.SetModules(this.m_panelCoordonnee, "");
            this.m_panelCoordonnee.Name = "m_panelCoordonnee";
            this.m_panelCoordonnee.Size = new System.Drawing.Size(607, 28);
            this.m_exStyle.SetStyleBackColor(this.m_panelCoordonnee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_panelCoordonnee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelCoordonnee.TabIndex = 18;
            this.m_panelCoordonnee.Visible = false;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(4, 6);
            this.m_extModulesAssociator.SetModules(this.label6, "");
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 18);
            this.m_exStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 19;
            this.label6.Text = "Coordinate|446";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 34);
            this.m_extModulesAssociator.SetModules(this.label7, "");
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.m_exStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 7;
            this.label7.Text = "Equipment|235";
            // 
            // m_cmbEquipementStock
            // 
            this.m_cmbEquipementStock.BackColor = System.Drawing.Color.White;
            this.m_cmbEquipementStock.ElementSelectionne = null;
            this.m_cmbEquipementStock.Location = new System.Drawing.Point(86, 30);
            this.m_cmbEquipementStock.LockEdition = false;
            this.m_extModulesAssociator.SetModules(this.m_cmbEquipementStock, "");
            this.m_cmbEquipementStock.Name = "m_cmbEquipementStock";
            this.m_cmbEquipementStock.NullAutorise = false;
            this.m_cmbEquipementStock.Size = new System.Drawing.Size(431, 21);
            this.m_exStyle.SetStyleBackColor(this.m_cmbEquipementStock, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_cmbEquipementStock, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbEquipementStock.TabIndex = 6;
            this.m_cmbEquipementStock.TextNull = "[None]";
            this.m_cmbEquipementStock.ElementSelectionneChanged += new System.EventHandler(this.m_cmbEquipementStock_ElementSelectionneChanged);
            // 
            // CFormDeplacerEquipement
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(633, 320);
            this.Controls.Add(this.m_panelCoordonnee);
            this.Controls.Add(this.m_panbtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_radioActeur);
            this.Controls.Add(this.m_dtMouvement);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_selectUser);
            this.Controls.Add(this.m_txtInfo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_panelStock);
            this.Controls.Add(this.m_panelSite);
            this.Controls.Add(this.m_radioStock);
            this.Controls.Add(this.m_radioSite);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormDeplacerEquipement";
            this.m_exStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_exStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.Text = "Move equipment|241";
            this.Load += new System.EventHandler(this.CFormDeplacerEquipement_Load);
            this.m_panelSite.ResumeLayout(false);
            this.m_panelSite.PerformLayout();
            this.m_panelStock.ResumeLayout(false);
            this.m_panelStock.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.m_panbtn.ResumeLayout(false);
            this.m_panelCoordonnee.ResumeLayout(false);
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
		private sc2i.win32.data.navigation.CComboBoxArbreObjetDonneesHierarchique m_cmbEquipement;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel m_panelStock;
		private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_selectStock;
		private System.Windows.Forms.Button m_btnOk;
		private System.Windows.Forms.Button m_btnAnnuler;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox m_txtInfo;
		private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_selectUser;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DateTimePicker m_dtMouvement;
		private System.Windows.Forms.Panel panel1;
		private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_selectActeur;
		private System.Windows.Forms.RadioButton m_radioActeur;
		private System.Windows.Forms.Panel m_panbtn;
		private timos.coordonnees.CControlEditeCoordonnee m_editCoordonnee;
		private System.Windows.Forms.Panel m_panelCoordonnee;
		private System.Windows.Forms.Label label6;
		private CExtModulesAssociator m_extModulesAssociator;
        private System.Windows.Forms.Label label7;
        private sc2i.win32.data.navigation.CComboBoxArbreObjetDonneesHierarchique m_cmbEquipementStock;
	}
}