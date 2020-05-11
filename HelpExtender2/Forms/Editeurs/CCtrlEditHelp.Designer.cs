namespace HelpExtender
{
	partial class CCtrlEditHelp
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
			LibereRessourceFichierLocales();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CCtrlEditHelp));
            this.pan_typeliaison = new System.Windows.Forms.Panel();
            this.ctrl_selectLiaison = new HelpExtender.CCtrlSelectLiaison();
            this.pan_infos = new System.Windows.Forms.Panel();
            this.lbl_designation = new System.Windows.Forms.Label();
            this.txt_designation = new System.Windows.Forms.TextBox();
            this.m_timerRefreshDockStyle = new System.Windows.Forms.Timer(this.components);
            this.m_panelInfos = new sc2i.win32.common.C2iPanel(this.components);
            this.m_txtID = new sc2i.win32.common.C2iTextBox();
            this.lbl_id = new System.Windows.Forms.Label();
            this.m_txtNomCourt = new System.Windows.Forms.TextBox();
            this.lbl_nomcourt = new System.Windows.Forms.Label();
            this.lbl_titre = new System.Windows.Forms.Label();
            this.m_txtTitre = new System.Windows.Forms.TextBox();
            this.pan_tooltip = new System.Windows.Forms.Panel();
            this.m_chkAidePopup = new System.Windows.Forms.CheckBox();
            this.pan_Popup = new System.Windows.Forms.Panel();
            this.m_numUpSizeY = new System.Windows.Forms.NumericUpDown();
            this.m_numUpSizeX = new System.Windows.Forms.NumericUpDown();
            this.lbl_taillepopup = new System.Windows.Forms.Label();
            this.lbl_x = new System.Windows.Forms.Label();
            this.m_tabControl = new System.Windows.Forms.TabControl();
            this.m_tbp_contenu = new System.Windows.Forms.TabPage();
            this.m_htmlEditor = new WinHTMLEditorControl.winHTMLEditorControl();
            this.m_comboExStyles = new System.Windows.Forms.ToolStripComboBox();
            this.m_btnAddControlImage = new System.Windows.Forms.ToolStripButton();
            this.m_btnAddImage = new System.Windows.Forms.ToolStripButton();
            this.m_btnAddLink = new System.Windows.Forms.ToolStripButton();
            this.m_tbp_HTML = new System.Windows.Forms.TabPage();
            this.m_txtHtml = new System.Windows.Forms.TextBox();
            this.m_tbp_references = new System.Windows.Forms.TabPage();
            this.m_lnkSupprimer = new System.Windows.Forms.LinkLabel();
            this.m_lnkAjouter = new System.Windows.Forms.LinkLabel();
            this.lv_voiraussi = new System.Windows.Forms.ListView();
            this.col_voiraussi_titre = new System.Windows.Forms.ColumnHeader();
            this.col_voiraussi_nom = new System.Windows.Forms.ColumnHeader();
            this.col_voiraussi_type = new System.Windows.Forms.ColumnHeader();
            this.m_tbp_fichiers = new System.Windows.Forms.TabPage();
            this.chk_hide = new System.Windows.Forms.CheckBox();
            this.lnk_suppFile = new System.Windows.Forms.LinkLabel();
            this.lnk_addFile = new System.Windows.Forms.LinkLabel();
            this.lv_fichiers = new System.Windows.Forms.ListView();
            this.col_nom = new System.Windows.Forms.ColumnHeader();
            this.col_type = new System.Windows.Forms.ColumnHeader();
            this.col_ext = new System.Windows.Forms.ColumnHeader();
            this.col_masquer = new System.Windows.Forms.ColumnHeader();
            this.ctrl_openFile = new System.Windows.Forms.OpenFileDialog();
            this.m_btnTest = new System.Windows.Forms.ToolStripButton();
            this.pan_typeliaison.SuspendLayout();
            this.pan_infos.SuspendLayout();
            this.m_panelInfos.SuspendLayout();
            this.pan_tooltip.SuspendLayout();
            this.pan_Popup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_numUpSizeY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numUpSizeX)).BeginInit();
            this.m_tabControl.SuspendLayout();
            this.m_tbp_contenu.SuspendLayout();
            this.m_htmlEditor.SuspendLayout();
            this.m_tbp_HTML.SuspendLayout();
            this.m_tbp_references.SuspendLayout();
            this.m_tbp_fichiers.SuspendLayout();
            this.SuspendLayout();
            // 
            // pan_typeliaison
            // 
            this.pan_typeliaison.Controls.Add(this.ctrl_selectLiaison);
            this.pan_typeliaison.Dock = System.Windows.Forms.DockStyle.Top;
            this.pan_typeliaison.Location = new System.Drawing.Point(0, 31);
            this.pan_typeliaison.Name = "pan_typeliaison";
            this.pan_typeliaison.Size = new System.Drawing.Size(661, 31);
            this.pan_typeliaison.TabIndex = 0;
            // 
            // ctrl_selectLiaison
            // 
            this.ctrl_selectLiaison.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrl_selectLiaison.Liaison = HelpExtender.ETypeLiaisonAide.Control;
            this.ctrl_selectLiaison.Location = new System.Drawing.Point(0, 0);
            this.ctrl_selectLiaison.Name = "ctrl_selectLiaison";
            this.ctrl_selectLiaison.Size = new System.Drawing.Size(661, 31);
            this.ctrl_selectLiaison.TabIndex = 0;
            this.ctrl_selectLiaison.ChangementTypeLiaison += new System.EventHandler(this.ctrl_selectLiaison_ChangementTypeLiaison);
            // 
            // pan_infos
            // 
            this.pan_infos.Controls.Add(this.lbl_designation);
            this.pan_infos.Controls.Add(this.txt_designation);
            this.pan_infos.Dock = System.Windows.Forms.DockStyle.Top;
            this.pan_infos.Location = new System.Drawing.Point(0, 0);
            this.pan_infos.Name = "pan_infos";
            this.pan_infos.Size = new System.Drawing.Size(661, 31);
            this.pan_infos.TabIndex = 0;
            // 
            // lbl_designation
            // 
            this.lbl_designation.AutoSize = true;
            this.lbl_designation.Location = new System.Drawing.Point(3, 7);
            this.lbl_designation.Name = "lbl_designation";
            this.lbl_designation.Size = new System.Drawing.Size(98, 13);
            this.lbl_designation.TabIndex = 0;
            this.lbl_designation.Text = "Designation |30000";
            // 
            // txt_designation
            // 
            this.txt_designation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_designation.Enabled = false;
            this.txt_designation.Location = new System.Drawing.Point(104, 4);
            this.txt_designation.Name = "txt_designation";
            this.txt_designation.Size = new System.Drawing.Size(554, 20);
            this.txt_designation.TabIndex = 1;
            // 
            // m_timerRefreshDockStyle
            // 
            this.m_timerRefreshDockStyle.Interval = 500;
            this.m_timerRefreshDockStyle.Tick += new System.EventHandler(this.m_timerRefreshDockStyle_Tick);
            // 
            // m_panelInfos
            // 
            this.m_panelInfos.Controls.Add(this.m_txtID);
            this.m_panelInfos.Controls.Add(this.lbl_id);
            this.m_panelInfos.Controls.Add(this.m_txtNomCourt);
            this.m_panelInfos.Controls.Add(this.lbl_nomcourt);
            this.m_panelInfos.Controls.Add(this.lbl_titre);
            this.m_panelInfos.Controls.Add(this.m_txtTitre);
            this.m_panelInfos.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelInfos.Location = new System.Drawing.Point(0, 62);
            this.m_panelInfos.LockEdition = false;
            this.m_panelInfos.Name = "m_panelInfos";
            this.m_panelInfos.Size = new System.Drawing.Size(661, 59);
            this.m_panelInfos.TabIndex = 2;
            // 
            // m_txtID
            // 
            this.m_txtID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtID.Location = new System.Drawing.Point(326, 28);
            this.m_txtID.LockEdition = false;
            this.m_txtID.Name = "m_txtID";
            this.m_txtID.Size = new System.Drawing.Size(332, 20);
            this.m_txtID.TabIndex = 8;
            this.m_txtID.Visible = false;
            this.m_txtID.TextChanged += new System.EventHandler(this.m_txtID_TextChanged);
            // 
            // lbl_id
            // 
            this.lbl_id.Location = new System.Drawing.Point(302, 31);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(19, 16);
            this.lbl_id.TabIndex = 7;
            this.lbl_id.Text = "Id";
            this.lbl_id.Visible = false;
            // 
            // m_txtNomCourt
            // 
            this.m_txtNomCourt.Location = new System.Drawing.Point(65, 28);
            this.m_txtNomCourt.MaxLength = 50;
            this.m_txtNomCourt.Name = "m_txtNomCourt";
            this.m_txtNomCourt.Size = new System.Drawing.Size(231, 20);
            this.m_txtNomCourt.TabIndex = 1;
            this.m_txtNomCourt.TextChanged += new System.EventHandler(this.m_txtNomCourt_TextChanged);
            // 
            // lbl_nomcourt
            // 
            this.lbl_nomcourt.Location = new System.Drawing.Point(4, 32);
            this.lbl_nomcourt.Name = "lbl_nomcourt";
            this.lbl_nomcourt.Size = new System.Drawing.Size(55, 16);
            this.lbl_nomcourt.TabIndex = 5;
            this.lbl_nomcourt.Text = "Name|30003";
            // 
            // lbl_titre
            // 
            this.lbl_titre.Location = new System.Drawing.Point(4, 9);
            this.lbl_titre.Name = "lbl_titre";
            this.lbl_titre.Size = new System.Drawing.Size(55, 16);
            this.lbl_titre.TabIndex = 1;
            this.lbl_titre.Text = "Title|30002";
            // 
            // m_txtTitre
            // 
            this.m_txtTitre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtTitre.Location = new System.Drawing.Point(65, 5);
            this.m_txtTitre.Name = "m_txtTitre";
            this.m_txtTitre.Size = new System.Drawing.Size(593, 20);
            this.m_txtTitre.TabIndex = 0;
            this.m_txtTitre.TextChanged += new System.EventHandler(this.m_txtTitre_TextChanged);
            // 
            // pan_tooltip
            // 
            this.pan_tooltip.Controls.Add(this.m_chkAidePopup);
            this.pan_tooltip.Controls.Add(this.pan_Popup);
            this.pan_tooltip.Dock = System.Windows.Forms.DockStyle.Top;
            this.pan_tooltip.Location = new System.Drawing.Point(0, 121);
            this.pan_tooltip.Name = "pan_tooltip";
            this.pan_tooltip.Size = new System.Drawing.Size(661, 33);
            this.pan_tooltip.TabIndex = 10;
            // 
            // m_chkAidePopup
            // 
            this.m_chkAidePopup.AutoSize = true;
            this.m_chkAidePopup.Location = new System.Drawing.Point(12, 7);
            this.m_chkAidePopup.Name = "m_chkAidePopup";
            this.m_chkAidePopup.Size = new System.Drawing.Size(207, 17);
            this.m_chkAidePopup.TabIndex = 3;
            this.m_chkAidePopup.Text = "The help will appear as a tooltip|30004";
            this.m_chkAidePopup.UseVisualStyleBackColor = true;
            this.m_chkAidePopup.CheckedChanged += new System.EventHandler(this.m_chkAidePopup_CheckedChanged);
            // 
            // pan_Popup
            // 
            this.pan_Popup.Controls.Add(this.m_numUpSizeY);
            this.pan_Popup.Controls.Add(this.m_numUpSizeX);
            this.pan_Popup.Controls.Add(this.lbl_taillepopup);
            this.pan_Popup.Controls.Add(this.lbl_x);
            this.pan_Popup.Dock = System.Windows.Forms.DockStyle.Right;
            this.pan_Popup.Location = new System.Drawing.Point(459, 0);
            this.pan_Popup.Name = "pan_Popup";
            this.pan_Popup.Size = new System.Drawing.Size(202, 33);
            this.pan_Popup.TabIndex = 6;
            // 
            // m_numUpSizeY
            // 
            this.m_numUpSizeY.Location = new System.Drawing.Point(147, 4);
            this.m_numUpSizeY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.m_numUpSizeY.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.m_numUpSizeY.Name = "m_numUpSizeY";
            this.m_numUpSizeY.Size = new System.Drawing.Size(50, 20);
            this.m_numUpSizeY.TabIndex = 2;
            this.m_numUpSizeY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_numUpSizeY.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.m_numUpSizeY.ValueChanged += new System.EventHandler(this.m_numUpSizeX_ValueChanged);
            // 
            // m_numUpSizeX
            // 
            this.m_numUpSizeX.Location = new System.Drawing.Point(73, 4);
            this.m_numUpSizeX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.m_numUpSizeX.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.m_numUpSizeX.Name = "m_numUpSizeX";
            this.m_numUpSizeX.Size = new System.Drawing.Size(50, 20);
            this.m_numUpSizeX.TabIndex = 1;
            this.m_numUpSizeX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_numUpSizeX.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.m_numUpSizeX.ValueChanged += new System.EventHandler(this.m_numUpSizeX_ValueChanged);
            // 
            // lbl_taillepopup
            // 
            this.lbl_taillepopup.AutoSize = true;
            this.lbl_taillepopup.Location = new System.Drawing.Point(3, 8);
            this.lbl_taillepopup.Name = "lbl_taillepopup";
            this.lbl_taillepopup.Size = new System.Drawing.Size(96, 13);
            this.lbl_taillepopup.TabIndex = 0;
            this.lbl_taillepopup.Text = "Popup Size|30005 ";
            // 
            // lbl_x
            // 
            this.lbl_x.AutoSize = true;
            this.lbl_x.Location = new System.Drawing.Point(129, 8);
            this.lbl_x.Name = "lbl_x";
            this.lbl_x.Size = new System.Drawing.Size(12, 13);
            this.lbl_x.TabIndex = 3;
            this.lbl_x.Text = "x";
            // 
            // m_tabControl
            // 
            this.m_tabControl.Controls.Add(this.m_tbp_contenu);
            this.m_tabControl.Controls.Add(this.m_tbp_HTML);
            this.m_tabControl.Controls.Add(this.m_tbp_references);
            this.m_tabControl.Controls.Add(this.m_tbp_fichiers);
            this.m_tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tabControl.Location = new System.Drawing.Point(0, 154);
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.Size = new System.Drawing.Size(661, 276);
            this.m_tabControl.TabIndex = 11;
            this.m_tabControl.SelectedIndexChanged += new System.EventHandler(this.m_tabControl_SelectedIndexChanged);
            // 
            // m_tbp_contenu
            // 
            this.m_tbp_contenu.Controls.Add(this.m_htmlEditor);
            this.m_tbp_contenu.Location = new System.Drawing.Point(4, 22);
            this.m_tbp_contenu.Name = "m_tbp_contenu";
            this.m_tbp_contenu.Padding = new System.Windows.Forms.Padding(3);
            this.m_tbp_contenu.Size = new System.Drawing.Size(653, 250);
            this.m_tbp_contenu.TabIndex = 0;
            this.m_tbp_contenu.Text = "Help|30006";
            this.m_tbp_contenu.UseVisualStyleBackColor = true;
            // 
            // m_htmlEditor
            // 
            this.m_htmlEditor.AccessibleDescription = "";
            this.m_htmlEditor.AccessibleName = "";
            this.m_htmlEditor.AccessibleRole = System.Windows.Forms.AccessibleRole.Alert;
            this.m_htmlEditor.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.m_htmlEditor.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.m_htmlEditor.BackgroundImagePath = "";
            this.m_htmlEditor.BodyColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_htmlEditor.BodyHtml = null;
            this.m_htmlEditor.BodyText = null;
            this.m_htmlEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // m_htmlEditor.WinHTMLEditorToolStrip1
            // 
            this.m_htmlEditor.EditorToolStripFirst.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.m_htmlEditor.EditorToolStripFirst.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_comboExStyles});
            this.m_htmlEditor.EditorToolStripFirst.Location = new System.Drawing.Point(0, 0);
            this.m_htmlEditor.EditorToolStripFirst.Name = "WinHTMLEditorToolStrip1";
            this.m_htmlEditor.EditorToolStripFirst.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.m_htmlEditor.EditorToolStripFirst.Size = new System.Drawing.Size(647, 29);
            this.m_htmlEditor.EditorToolStripFirst.TabIndex = 2;
            this.m_htmlEditor.EditorToolStripFirst.Text = "toolStrip1";
            // 
            // m_htmlEditor.WinHTMLEditorToolStrip2
            // 
            this.m_htmlEditor.EditorToolStripSecond.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_btnAddControlImage,
            this.m_btnAddImage,
            this.m_btnAddLink});
            this.m_htmlEditor.EditorToolStripSecond.Location = new System.Drawing.Point(0, 29);
            this.m_htmlEditor.EditorToolStripSecond.Name = "WinHTMLEditorToolStrip2";
            this.m_htmlEditor.EditorToolStripSecond.Size = new System.Drawing.Size(647, 29);
            this.m_htmlEditor.EditorToolStripSecond.TabIndex = 3;
            this.m_htmlEditor.EditorToolStripSecond.Text = "toolStrip2";
            this.m_htmlEditor.EnterKeyResponse = WinHTMLEditorControl.winHTMLEditorControl.EnteryKeyResponses.LineBreak;
            this.m_htmlEditor.HtmlAttributeValueQuoted = false;
            this.m_htmlEditor.LanguageCulture = null;
            this.m_htmlEditor.LicenseKey = "B32F-479C-E028-6A45-186F-E23A-DFF2-8625-6180-5F69-D91C-CCB3  ";
            this.m_htmlEditor.Location = new System.Drawing.Point(3, 3);
            this.m_htmlEditor.Name = "m_htmlEditor";
            this.m_htmlEditor.ReadOnly = false;
            this.m_htmlEditor.Size = new System.Drawing.Size(647, 244);
            this.m_htmlEditor.TabIndex = 0;
            this.m_htmlEditor.ToolbarConfigXML = resources.GetString("m_htmlEditor.ToolbarConfigXML");
            // 
            // m_comboExStyles
            // 
            this.m_comboExStyles.Name = "m_comboExStyles";
            this.m_comboExStyles.Size = new System.Drawing.Size(121, 29);
            // 
            // m_btnAddControlImage
            // 
            this.m_btnAddControlImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_btnAddControlImage.Image = ((System.Drawing.Image)(resources.GetObject("m_btnAddControlImage.Image")));
            this.m_btnAddControlImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_btnAddControlImage.Name = "m_btnAddControlImage";
            this.m_btnAddControlImage.Size = new System.Drawing.Size(23, 26);
            this.m_btnAddControlImage.Text = "Add control image";
            this.m_btnAddControlImage.Click += new System.EventHandler(this.m_btnAddControlImage_Click);
            // 
            // m_btnAddImage
            // 
            this.m_btnAddImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_btnAddImage.Image = ((System.Drawing.Image)(resources.GetObject("m_btnAddImage.Image")));
            this.m_btnAddImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_btnAddImage.Name = "m_btnAddImage";
            this.m_btnAddImage.Size = new System.Drawing.Size(23, 26);
            this.m_btnAddImage.Text = "toolStripButton1";
            this.m_btnAddImage.Click += new System.EventHandler(this.m_btnAddImage_Click);
            // 
            // m_btnAddLink
            // 
            this.m_btnAddLink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_btnAddLink.Image = ((System.Drawing.Image)(resources.GetObject("m_btnAddLink.Image")));
            this.m_btnAddLink.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_btnAddLink.Name = "m_btnAddLink";
            this.m_btnAddLink.Size = new System.Drawing.Size(23, 26);
            this.m_btnAddLink.Text = "Insert link";
            this.m_btnAddLink.Click += new System.EventHandler(this.m_btnAddLink_Click);
            // 
            // m_tbp_HTML
            // 
            this.m_tbp_HTML.Controls.Add(this.m_txtHtml);
            this.m_tbp_HTML.Location = new System.Drawing.Point(4, 22);
            this.m_tbp_HTML.Name = "m_tbp_HTML";
            this.m_tbp_HTML.Size = new System.Drawing.Size(653, 250);
            this.m_tbp_HTML.TabIndex = 3;
            this.m_tbp_HTML.Text = "HTML Code|30007";
            this.m_tbp_HTML.UseVisualStyleBackColor = true;
            // 
            // m_txtHtml
            // 
            this.m_txtHtml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtHtml.Location = new System.Drawing.Point(0, 0);
            this.m_txtHtml.Multiline = true;
            this.m_txtHtml.Name = "m_txtHtml";
            this.m_txtHtml.Size = new System.Drawing.Size(653, 250);
            this.m_txtHtml.TabIndex = 0;
            // 
            // m_tbp_references
            // 
            this.m_tbp_references.Controls.Add(this.m_lnkSupprimer);
            this.m_tbp_references.Controls.Add(this.m_lnkAjouter);
            this.m_tbp_references.Controls.Add(this.lv_voiraussi);
            this.m_tbp_references.Location = new System.Drawing.Point(4, 22);
            this.m_tbp_references.Name = "m_tbp_references";
            this.m_tbp_references.Padding = new System.Windows.Forms.Padding(3);
            this.m_tbp_references.Size = new System.Drawing.Size(653, 250);
            this.m_tbp_references.TabIndex = 1;
            this.m_tbp_references.Text = "See Also|30008";
            this.m_tbp_references.UseVisualStyleBackColor = true;
            // 
            // m_lnkSupprimer
            // 
            this.m_lnkSupprimer.AutoSize = true;
            this.m_lnkSupprimer.Location = new System.Drawing.Point(72, 7);
            this.m_lnkSupprimer.Name = "m_lnkSupprimer";
            this.m_lnkSupprimer.Size = new System.Drawing.Size(70, 13);
            this.m_lnkSupprimer.TabIndex = 2;
            this.m_lnkSupprimer.TabStop = true;
            this.m_lnkSupprimer.Text = "Delete|30011";
            this.m_lnkSupprimer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkSupprimer_LinkClicked);
            // 
            // m_lnkAjouter
            // 
            this.m_lnkAjouter.AutoSize = true;
            this.m_lnkAjouter.Location = new System.Drawing.Point(9, 7);
            this.m_lnkAjouter.Name = "m_lnkAjouter";
            this.m_lnkAjouter.Size = new System.Drawing.Size(67, 13);
            this.m_lnkAjouter.TabIndex = 1;
            this.m_lnkAjouter.TabStop = true;
            this.m_lnkAjouter.Text = "Add...|30010";
            this.m_lnkAjouter.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkAjouter_LinkClicked);
            // 
            // lv_voiraussi
            // 
            this.lv_voiraussi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lv_voiraussi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_voiraussi_titre,
            this.col_voiraussi_nom,
            this.col_voiraussi_type});
            this.lv_voiraussi.FullRowSelect = true;
            this.lv_voiraussi.GridLines = true;
            this.lv_voiraussi.Location = new System.Drawing.Point(3, 27);
            this.lv_voiraussi.MultiSelect = false;
            this.lv_voiraussi.Name = "lv_voiraussi";
            this.lv_voiraussi.Size = new System.Drawing.Size(644, 184);
            this.lv_voiraussi.TabIndex = 0;
            this.lv_voiraussi.UseCompatibleStateImageBehavior = false;
            this.lv_voiraussi.View = System.Windows.Forms.View.Details;
            // 
            // col_voiraussi_titre
            // 
            this.col_voiraussi_titre.Text = "Title|30002";
            this.col_voiraussi_titre.Width = 200;
            // 
            // col_voiraussi_nom
            // 
            this.col_voiraussi_nom.Text = "Name|30003";
            this.col_voiraussi_nom.Width = 100;
            // 
            // col_voiraussi_type
            // 
            this.col_voiraussi_type.Text = "Type|30012";
            this.col_voiraussi_type.Width = 100;
            // 
            // m_tbp_fichiers
            // 
            this.m_tbp_fichiers.Controls.Add(this.chk_hide);
            this.m_tbp_fichiers.Controls.Add(this.lnk_suppFile);
            this.m_tbp_fichiers.Controls.Add(this.lnk_addFile);
            this.m_tbp_fichiers.Controls.Add(this.lv_fichiers);
            this.m_tbp_fichiers.Location = new System.Drawing.Point(4, 22);
            this.m_tbp_fichiers.Name = "m_tbp_fichiers";
            this.m_tbp_fichiers.Padding = new System.Windows.Forms.Padding(3);
            this.m_tbp_fichiers.Size = new System.Drawing.Size(653, 250);
            this.m_tbp_fichiers.TabIndex = 2;
            this.m_tbp_fichiers.Text = "Associated files|30009";
            this.m_tbp_fichiers.UseVisualStyleBackColor = true;
            // 
            // chk_hide
            // 
            this.chk_hide.AutoSize = true;
            this.chk_hide.Location = new System.Drawing.Point(13, 283);
            this.chk_hide.Name = "chk_hide";
            this.chk_hide.Size = new System.Drawing.Size(142, 17);
            this.chk_hide.TabIndex = 6;
            this.chk_hide.Text = "Masquer pour l\'utilisateur";
            this.chk_hide.UseVisualStyleBackColor = true;
            this.chk_hide.CheckedChanged += new System.EventHandler(this.chk_hide_CheckedChanged);
            // 
            // lnk_suppFile
            // 
            this.lnk_suppFile.AutoSize = true;
            this.lnk_suppFile.Location = new System.Drawing.Point(128, 7);
            this.lnk_suppFile.Name = "lnk_suppFile";
            this.lnk_suppFile.Size = new System.Drawing.Size(70, 13);
            this.lnk_suppFile.TabIndex = 5;
            this.lnk_suppFile.TabStop = true;
            this.lnk_suppFile.Text = "Delete|30011";
            this.lnk_suppFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_suppFile_LinkClicked);
            // 
            // lnk_addFile
            // 
            this.lnk_addFile.AutoSize = true;
            this.lnk_addFile.Location = new System.Drawing.Point(10, 7);
            this.lnk_addFile.Name = "lnk_addFile";
            this.lnk_addFile.Size = new System.Drawing.Size(58, 13);
            this.lnk_addFile.TabIndex = 4;
            this.lnk_addFile.TabStop = true;
            this.lnk_addFile.Text = "Add|30010";
            this.lnk_addFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_addFile_LinkClicked);
            // 
            // lv_fichiers
            // 
            this.lv_fichiers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lv_fichiers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_nom,
            this.col_type,
            this.col_ext,
            this.col_masquer});
            this.lv_fichiers.FullRowSelect = true;
            this.lv_fichiers.GridLines = true;
            this.lv_fichiers.Location = new System.Drawing.Point(4, 27);
            this.lv_fichiers.MultiSelect = false;
            this.lv_fichiers.Name = "lv_fichiers";
            this.lv_fichiers.Size = new System.Drawing.Size(644, 141);
            this.lv_fichiers.TabIndex = 3;
            this.lv_fichiers.UseCompatibleStateImageBehavior = false;
            this.lv_fichiers.View = System.Windows.Forms.View.Details;
            this.lv_fichiers.SelectedIndexChanged += new System.EventHandler(this.lv_fichiers_SelectedIndexChanged);
            // 
            // col_nom
            // 
            this.col_nom.Text = "Name|30003";
            this.col_nom.Width = 200;
            // 
            // col_type
            // 
            this.col_type.Text = "Type|30012";
            this.col_type.Width = 100;
            // 
            // col_ext
            // 
            this.col_ext.Text = "Extension|30013";
            // 
            // col_masquer
            // 
            this.col_masquer.Text = "Masked|30014";
            // 
            // ctrl_openFile
            // 
            this.ctrl_openFile.FileName = "Choisissez un fichier à lier à votre document";
            // 
            // m_btnTest
            // 
            this.m_btnTest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_btnTest.Image = ((System.Drawing.Image)(resources.GetObject("m_btnTest.Image")));
            this.m_btnTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_btnTest.Name = "m_btnTest";
            this.m_btnTest.Size = new System.Drawing.Size(23, 26);
            this.m_btnTest.Text = "toolStripButton1";
            // 
            // CCtrlEditHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.pan_tooltip);
            this.Controls.Add(this.m_panelInfos);
            this.Controls.Add(this.pan_typeliaison);
            this.Controls.Add(this.pan_infos);
            this.Name = "CCtrlEditHelp";
            this.Size = new System.Drawing.Size(661, 430);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CCtrlEditHelp_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CCtrlEditHelp_MouseUp);
            this.pan_typeliaison.ResumeLayout(false);
            this.pan_infos.ResumeLayout(false);
            this.pan_infos.PerformLayout();
            this.m_panelInfos.ResumeLayout(false);
            this.m_panelInfos.PerformLayout();
            this.pan_tooltip.ResumeLayout(false);
            this.pan_tooltip.PerformLayout();
            this.pan_Popup.ResumeLayout(false);
            this.pan_Popup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_numUpSizeY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numUpSizeX)).EndInit();
            this.m_tabControl.ResumeLayout(false);
            this.m_tbp_contenu.ResumeLayout(false);
            this.m_htmlEditor.ResumeLayout(false);
            this.m_htmlEditor.PerformLayout();
            this.m_tbp_HTML.ResumeLayout(false);
            this.m_tbp_HTML.PerformLayout();
            this.m_tbp_references.ResumeLayout(false);
            this.m_tbp_references.PerformLayout();
            this.m_tbp_fichiers.ResumeLayout(false);
            this.m_tbp_fichiers.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pan_typeliaison;
		private System.Windows.Forms.Panel pan_infos;
		private System.Windows.Forms.TextBox txt_designation;
		private System.Windows.Forms.Label lbl_designation;
		private CCtrlSelectLiaison ctrl_selectLiaison;
		private System.Windows.Forms.Timer m_timerRefreshDockStyle;
		private sc2i.win32.common.C2iPanel m_panelInfos;
		private sc2i.win32.common.C2iTextBox m_txtID;
		private System.Windows.Forms.Label lbl_id;
		private System.Windows.Forms.TextBox m_txtNomCourt;
		private System.Windows.Forms.Label lbl_nomcourt;
		private System.Windows.Forms.Label lbl_titre;
		private System.Windows.Forms.TextBox m_txtTitre;
		private System.Windows.Forms.Panel pan_tooltip;
		private System.Windows.Forms.CheckBox m_chkAidePopup;
		private System.Windows.Forms.Panel pan_Popup;
		private System.Windows.Forms.NumericUpDown m_numUpSizeY;
		private System.Windows.Forms.NumericUpDown m_numUpSizeX;
		private System.Windows.Forms.Label lbl_taillepopup;
		private System.Windows.Forms.Label lbl_x;
		private System.Windows.Forms.TabControl m_tabControl;
		private System.Windows.Forms.TabPage m_tbp_contenu;
		private System.Windows.Forms.TabPage m_tbp_references;
		private System.Windows.Forms.LinkLabel m_lnkSupprimer;
		private System.Windows.Forms.LinkLabel m_lnkAjouter;
		private System.Windows.Forms.ListView lv_voiraussi;
		private System.Windows.Forms.ColumnHeader col_voiraussi_nom;
		private System.Windows.Forms.ColumnHeader col_voiraussi_type;
		private System.Windows.Forms.TabPage m_tbp_fichiers;
		private System.Windows.Forms.LinkLabel lnk_suppFile;
		private System.Windows.Forms.LinkLabel lnk_addFile;
		private System.Windows.Forms.ListView lv_fichiers;
		private System.Windows.Forms.ColumnHeader col_nom;
		private System.Windows.Forms.ColumnHeader col_type;
		private System.Windows.Forms.CheckBox chk_hide;
		private System.Windows.Forms.ColumnHeader col_ext;
		private System.Windows.Forms.OpenFileDialog ctrl_openFile;
		private System.Windows.Forms.ColumnHeader col_masquer;
		private System.Windows.Forms.ColumnHeader col_voiraussi_titre;
		//private winHTMLEditorControl.winHTMLEditorControl m_htmlEditor;
		private System.Windows.Forms.ToolStripButton m_btnAddLink;
		private System.Windows.Forms.TabPage m_tbp_HTML;
		private System.Windows.Forms.TextBox m_txtHtml;
		private System.Windows.Forms.ToolStripButton m_btnAddImage;
		private System.Windows.Forms.ToolStripButton m_btnAddControlImage;
		private WinHTMLEditorControl.winHTMLEditorControl m_htmlEditor;
		private System.Windows.Forms.ToolStripComboBox m_comboExStyles;
		private System.Windows.Forms.ToolStripButton m_btnTest;
	}
}
