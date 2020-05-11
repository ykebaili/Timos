using sc2i.common;

namespace timos.win32.composants
{
	partial class CFormChercheIntervenant
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormChercheIntervenant));
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
            this.m_panelTotal = new sc2i.win32.common.C2iPanel(this.components);
            this.m_listeIntervenants = new sc2i.win32.common.GlacialList();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_panelDispo = new System.Windows.Forms.Panel();
            this.m_panelFiltre = new System.Windows.Forms.Panel();
            this.m_btnfiltrer = new System.Windows.Forms.Button();
            this.m_txtFiltrer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cmbProfil = new sc2i.win32.data.CComboBoxListeObjetsDonnees();
            this.m_panelEntete = new System.Windows.Forms.Panel();
            this.m_picActeur = new System.Windows.Forms.PictureBox();
            this.m_lblProfil = new System.Windows.Forms.Label();
            this.m_panelBas = new System.Windows.Forms.Panel();
            this.m_imagesEmplacements = new System.Windows.Forms.ImageList(this.components);
            this.m_exStyle = new sc2i.win32.common.CExtStyle();
            this.m_timerUpdatePlanning = new System.Windows.Forms.Timer(this.components);
            this.m_lnkAffecter = new System.Windows.Forms.LinkLabel();
            this.m_lnkDisplay = new System.Windows.Forms.LinkLabel();
            this.m_controlPlanning = new timos.win32.composants.CControlePlanning();
            this.m_panelTotal.SuspendLayout();
            this.m_panelDispo.SuspendLayout();
            this.m_panelFiltre.SuspendLayout();
            this.m_panelEntete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_picActeur)).BeginInit();
            this.m_panelBas.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelTotal
            // 
            this.m_panelTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_panelTotal.Controls.Add(this.m_listeIntervenants);
            this.m_panelTotal.Controls.Add(this.splitter1);
            this.m_panelTotal.Controls.Add(this.m_panelDispo);
            this.m_panelTotal.Controls.Add(this.m_panelFiltre);
            this.m_panelTotal.Controls.Add(this.m_panelEntete);
            this.m_panelTotal.Controls.Add(this.m_panelBas);
            this.m_panelTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelTotal.ForeColor = System.Drawing.Color.Black;
            this.m_panelTotal.Location = new System.Drawing.Point(0, 0);
            this.m_panelTotal.LockEdition = false;
            this.m_panelTotal.Name = "m_panelTotal";
            this.m_panelTotal.Size = new System.Drawing.Size(609, 360);
            this.m_exStyle.SetStyleBackColor(this.m_panelTotal, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_exStyle.SetStyleForeColor(this.m_panelTotal, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelTotal.TabIndex = 0;
            // 
            // m_listeIntervenants
            // 
            this.m_listeIntervenants.AllowColumnResize = true;
            this.m_listeIntervenants.AllowMultiselect = false;
            this.m_listeIntervenants.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.m_listeIntervenants.AlternatingColors = false;
            this.m_listeIntervenants.AutoHeight = true;
            this.m_listeIntervenants.AutoSort = true;
            this.m_listeIntervenants.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.m_listeIntervenants.CanChangeActivationCheckBoxes = false;
            this.m_listeIntervenants.CheckBoxes = false;
            this.m_listeIntervenants.CheckedItems = ((System.Collections.ArrayList)(resources.GetObject("m_listeIntervenants.CheckedItems")));
            glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "Column1";
            glColumn1.Propriete = "Nom";
            glColumn1.Text = "Column";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 295;
            glColumn2.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn2.ActiveControlItems")));
            glColumn2.BackColor = System.Drawing.Color.Transparent;
            glColumn2.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn2.ForColor = System.Drawing.Color.Black;
            glColumn2.ImageIndex = -1;
            glColumn2.IsCheckColumn = false;
            glColumn2.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn2.Name = "Column1x";
            glColumn2.Propriete = "Prenom";
            glColumn2.Text = "Column";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 200;
            this.m_listeIntervenants.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1,
            glColumn2});
            this.m_listeIntervenants.ContexteUtilisation = "";
            this.m_listeIntervenants.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_listeIntervenants.EnableCustomisation = true;
            this.m_listeIntervenants.FocusedItem = null;
            this.m_listeIntervenants.FullRowSelect = true;
            this.m_listeIntervenants.GLGridLines = sc2i.win32.common.GLGridStyles.gridSolid;
            this.m_listeIntervenants.GridColor = System.Drawing.Color.Gray;
            this.m_listeIntervenants.HasImages = false;
            this.m_listeIntervenants.HeaderHeight = 0;
            this.m_listeIntervenants.HeaderStyle = sc2i.win32.common.GLHeaderStyles.Normal;
            this.m_listeIntervenants.HeaderTextColor = System.Drawing.Color.Black;
            this.m_listeIntervenants.HeaderTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.m_listeIntervenants.HeaderVisible = false;
            this.m_listeIntervenants.HeaderWordWrap = false;
            this.m_listeIntervenants.HotColumnIndex = -1;
            this.m_listeIntervenants.HotItemIndex = -1;
            this.m_listeIntervenants.HotTracking = false;
            this.m_listeIntervenants.HotTrackingColor = System.Drawing.Color.LightGray;
            this.m_listeIntervenants.ImageList = null;
            this.m_listeIntervenants.ItemHeight = 17;
            this.m_listeIntervenants.ItemWordWrap = false;
            this.m_listeIntervenants.ListeSource = null;
            this.m_listeIntervenants.Location = new System.Drawing.Point(0, 68);
            this.m_listeIntervenants.MaxHeight = 17;
            this.m_listeIntervenants.Name = "m_listeIntervenants";
            this.m_listeIntervenants.SelectedTextColor = System.Drawing.Color.White;
            this.m_listeIntervenants.SelectionColor = System.Drawing.Color.DarkBlue;
            this.m_listeIntervenants.ShowBorder = true;
            this.m_listeIntervenants.ShowFocusRect = true;
            this.m_listeIntervenants.Size = new System.Drawing.Size(605, 186);
            this.m_listeIntervenants.SortIndex = 0;
            this.m_exStyle.SetStyleBackColor(this.m_listeIntervenants, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_listeIntervenants, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_listeIntervenants.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.m_listeIntervenants.TabIndex = 8;
            this.m_listeIntervenants.Text = "glacialList1";
            this.m_listeIntervenants.TrierAuClicSurEnteteColonne = true;
            this.m_listeIntervenants.DoubleClick += new System.EventHandler(this.m_listeIntervenants_DoubleClick);
            this.m_listeIntervenants.CheckedChange += new sc2i.win32.common.GlacialListCheckedChangeEventHandler(this.m_listeIntervenants_CheckedChange);
            this.m_listeIntervenants.OnChangeSelection += new System.EventHandler(this.m_listeIntervenants_OnChangeSelection);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 254);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(605, 3);
            this.m_exStyle.SetStyleBackColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // m_panelDispo
            // 
            this.m_panelDispo.Controls.Add(this.m_controlPlanning);
            this.m_panelDispo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_panelDispo.Location = new System.Drawing.Point(0, 257);
            this.m_panelDispo.Name = "m_panelDispo";
            this.m_panelDispo.Size = new System.Drawing.Size(605, 61);
            this.m_exStyle.SetStyleBackColor(this.m_panelDispo, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_panelDispo, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelDispo.TabIndex = 6;
            this.m_panelDispo.Visible = false;
            this.m_panelDispo.Paint += new System.Windows.Forms.PaintEventHandler(this.m_panelDispo_Paint);
            // 
            // m_panelFiltre
            // 
            this.m_panelFiltre.Controls.Add(this.m_btnfiltrer);
            this.m_panelFiltre.Controls.Add(this.m_txtFiltrer);
            this.m_panelFiltre.Controls.Add(this.label1);
            this.m_panelFiltre.Controls.Add(this.m_cmbProfil);
            this.m_panelFiltre.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelFiltre.Location = new System.Drawing.Point(0, 22);
            this.m_panelFiltre.Name = "m_panelFiltre";
            this.m_panelFiltre.Size = new System.Drawing.Size(605, 46);
            this.m_exStyle.SetStyleBackColor(this.m_panelFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_panelFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelFiltre.TabIndex = 5;
            // 
            // m_btnfiltrer
            // 
            this.m_btnfiltrer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_btnfiltrer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_btnfiltrer.Image = ((System.Drawing.Image)(resources.GetObject("m_btnfiltrer.Image")));
            this.m_btnfiltrer.Location = new System.Drawing.Point(288, 23);
            this.m_btnfiltrer.Name = "m_btnfiltrer";
            this.m_btnfiltrer.Size = new System.Drawing.Size(24, 20);
            this.m_exStyle.SetStyleBackColor(this.m_btnfiltrer, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_exStyle.SetStyleForeColor(this.m_btnfiltrer, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_btnfiltrer.TabIndex = 6;
            this.m_btnfiltrer.Text = "button1";
            this.m_btnfiltrer.UseVisualStyleBackColor = false;
            this.m_btnfiltrer.Click += new System.EventHandler(this.m_btnfiltrer_Click);
            // 
            // m_txtFiltrer
            // 
            this.m_txtFiltrer.Location = new System.Drawing.Point(82, 23);
            this.m_txtFiltrer.Name = "m_txtFiltrer";
            this.m_txtFiltrer.Size = new System.Drawing.Size(207, 20);
            this.m_exStyle.SetStyleBackColor(this.m_txtFiltrer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_txtFiltrer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFiltrer.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 18);
            this.m_exStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4;
            this.label1.Text = "Find|704";
            // 
            // m_cmbProfil
            // 
            this.m_cmbProfil.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbProfil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbProfil.ElementSelectionne = null;
            this.m_cmbProfil.FormattingEnabled = true;
            this.m_cmbProfil.IsLink = false;
            this.m_cmbProfil.ListDonnees = null;
            this.m_cmbProfil.Location = new System.Drawing.Point(82, 0);
            this.m_cmbProfil.LockEdition = false;
            this.m_cmbProfil.Name = "m_cmbProfil";
            this.m_cmbProfil.NullAutorise = true;
            this.m_cmbProfil.ProprieteAffichee = null;
            this.m_cmbProfil.ProprieteParentListeObjets = null;
            this.m_cmbProfil.SelectionneurParent = null;
            this.m_cmbProfil.Size = new System.Drawing.Size(523, 21);
            this.m_exStyle.SetStyleBackColor(this.m_cmbProfil, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_cmbProfil, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbProfil.TabIndex = 3;
            this.m_cmbProfil.TextNull = "(Profile defined by the Intervention)";
            this.m_cmbProfil.Tri = true;
            this.m_cmbProfil.SelectionChangeCommitted += new System.EventHandler(this.m_cmbProfilRessource_SelectionChangeCommitted);
            // 
            // m_panelEntete
            // 
            this.m_panelEntete.Controls.Add(this.m_picActeur);
            this.m_panelEntete.Controls.Add(this.m_lblProfil);
            this.m_panelEntete.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelEntete.Location = new System.Drawing.Point(0, 0);
            this.m_panelEntete.Name = "m_panelEntete";
            this.m_panelEntete.Size = new System.Drawing.Size(605, 22);
            this.m_exStyle.SetStyleBackColor(this.m_panelEntete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_panelEntete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEntete.TabIndex = 1;
            // 
            // m_picActeur
            // 
            this.m_picActeur.Image = ((System.Drawing.Image)(resources.GetObject("m_picActeur.Image")));
            this.m_picActeur.Location = new System.Drawing.Point(0, 0);
            this.m_picActeur.Name = "m_picActeur";
            this.m_picActeur.Size = new System.Drawing.Size(20, 20);
            this.m_picActeur.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_exStyle.SetStyleBackColor(this.m_picActeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_picActeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_picActeur.TabIndex = 2;
            this.m_picActeur.TabStop = false;
            // 
            // m_lblProfil
            // 
            this.m_lblProfil.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblProfil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblProfil.ForeColor = System.Drawing.Color.Beige;
            this.m_lblProfil.Location = new System.Drawing.Point(20, 0);
            this.m_lblProfil.Name = "m_lblProfil";
            this.m_lblProfil.Size = new System.Drawing.Size(585, 19);
            this.m_exStyle.SetStyleBackColor(this.m_lblProfil, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_lblProfil, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTitrePanel);
            this.m_lblProfil.TabIndex = 0;
            this.m_lblProfil.Text = "Constraint|703";
            // 
            // m_panelBas
            // 
            this.m_panelBas.BackColor = System.Drawing.Color.White;
            this.m_panelBas.Controls.Add(this.m_lnkDisplay);
            this.m_panelBas.Controls.Add(this.m_lnkAffecter);
            this.m_panelBas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_panelBas.Location = new System.Drawing.Point(0, 318);
            this.m_panelBas.Name = "m_panelBas";
            this.m_panelBas.Size = new System.Drawing.Size(605, 38);
            this.m_exStyle.SetStyleBackColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelBas.TabIndex = 9;
            this.m_panelBas.Visible = false;
            // 
            // m_imagesEmplacements
            // 
            this.m_imagesEmplacements.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imagesEmplacements.ImageStream")));
            this.m_imagesEmplacements.TransparentColor = System.Drawing.Color.Transparent;
            this.m_imagesEmplacements.Images.SetKeyName(0, "site.bmp");
            this.m_imagesEmplacements.Images.SetKeyName(1, "user.gif");
            // 
            // m_timerUpdatePlanning
            // 
            this.m_timerUpdatePlanning.Tick += new System.EventHandler(this.m_timerUpdatePlanning_Tick);
            // 
            // m_lnkAffecter
            // 
            this.m_lnkAffecter.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkAffecter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lnkAffecter.Location = new System.Drawing.Point(0, 0);
            this.m_lnkAffecter.Name = "m_lnkAffecter";
            this.m_lnkAffecter.Size = new System.Drawing.Size(257, 38);
            this.m_exStyle.SetStyleBackColor(this.m_lnkAffecter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_lnkAffecter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAffecter.TabIndex = 4;
            this.m_lnkAffecter.TabStop = true;
            this.m_lnkAffecter.Text = "Affect";
            this.m_lnkAffecter.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkAffecter_LinkClicked);
            // 
            // m_lnkDisplay
            // 
            this.m_lnkDisplay.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_lnkDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lnkDisplay.Location = new System.Drawing.Point(348, 0);
            this.m_lnkDisplay.Name = "m_lnkDisplay";
            this.m_lnkDisplay.Size = new System.Drawing.Size(257, 38);
            this.m_exStyle.SetStyleBackColor(this.m_lnkDisplay, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_lnkDisplay, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkDisplay.TabIndex = 5;
            this.m_lnkDisplay.TabStop = true;
            this.m_lnkDisplay.Text = "Display";
            this.m_lnkDisplay.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkDisplay_LinkClicked);
            // 
            // m_controlPlanning
            // 
            this.m_controlPlanning.AutoTooltip = false;
            this.m_controlPlanning.BaseAffichee = null;
            this.m_controlPlanning.DateDebut = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.m_controlPlanning.DateFin = new System.DateTime(1900, 1, 2, 0, 0, 0, 0);
            this.m_controlPlanning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_controlPlanning.ElementAInterventionSelectionne = null;
            this.m_controlPlanning.EnableAffichageDatesEnBas = true;
            this.m_controlPlanning.HauteurLigne = 26;
            this.m_controlPlanning.Location = new System.Drawing.Point(0, 0);
            this.m_controlPlanning.LockEdition = true;
            this.m_controlPlanning.MasquerEntetesLignes = false;
            this.m_controlPlanning.Name = "m_controlPlanning";
            this.m_controlPlanning.Size = new System.Drawing.Size(605, 61);
            this.m_exStyle.SetStyleBackColor(this.m_controlPlanning, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_controlPlanning, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_controlPlanning.TabIndex = 0;
            this.m_controlPlanning.TypeRessourcesAAffecter = typeof(timos.acteurs.CActeur);
            // 
            // CFormChercheIntervenant
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(609, 360);
            this.Controls.Add(this.m_panelTotal);
            this.Name = "CFormChercheIntervenant";
            this.m_exStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "CFormChercheRessource";
            this.Leave += new System.EventHandler(this.CFormChercheIntervenant_Leave);
            this.Load += new System.EventHandler(this.CFormChercheIntervenant_Load);
            this.m_panelTotal.ResumeLayout(false);
            this.m_panelDispo.ResumeLayout(false);
            this.m_panelFiltre.ResumeLayout(false);
            this.m_panelFiltre.PerformLayout();
            this.m_panelEntete.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_picActeur)).EndInit();
            this.m_panelBas.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private sc2i.win32.common.C2iPanel m_panelTotal;
		private sc2i.win32.common.CExtStyle m_exStyle;
		private System.Windows.Forms.Panel m_panelEntete;
		private System.Windows.Forms.PictureBox m_picActeur;
		private System.Windows.Forms.Label m_lblProfil;
		private System.Windows.Forms.ImageList m_imagesEmplacements;
		private System.Windows.Forms.Label label1;
		private sc2i.win32.data.CComboBoxListeObjetsDonnees m_cmbProfil;
		private System.Windows.Forms.Panel m_panelDispo;
		private System.Windows.Forms.Panel m_panelFiltre;
		private System.Windows.Forms.Splitter splitter1;
		private timos.win32.composants.CControlePlanning m_controlPlanning;
		private System.Windows.Forms.Timer m_timerUpdatePlanning;
		private sc2i.win32.common.GlacialList m_listeIntervenants;
		private System.Windows.Forms.Button m_btnfiltrer;
		private System.Windows.Forms.TextBox m_txtFiltrer;
        private System.Windows.Forms.Panel m_panelBas;
        private System.Windows.Forms.LinkLabel m_lnkDisplay;
        private System.Windows.Forms.LinkLabel m_lnkAffecter;
	}
}