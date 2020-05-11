namespace futurocom.win32.sig
{
    partial class CFormEditConfigWndMapView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.c2iTabControl1 = new sc2i.win32.common.C2iTabControl(this.components);
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.panel9 = new System.Windows.Forms.Panel();
            this.m_txtFormuleKeepState = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.m_rbtnHybride = new System.Windows.Forms.RadioButton();
            this.m_rbtnAerial = new System.Windows.Forms.RadioButton();
            this.m_rbtnViewMap = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.m_chkPreserveMapMode = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.m_txtFormuleZoom = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.label3 = new System.Windows.Forms.Label();
            this.m_chkPreserveZoom = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_txtFormuleLongitude = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_txtFormuleLatitude = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.label1 = new System.Windows.Forms.Label();
            this.m_chkPreserveCenter = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.m_panelOptionsCalque = new System.Windows.Forms.Panel();
            this.m_wndListeValeursVariables = new sc2i.win32.expression.CControlEditListeFormulesNommees();
            this.m_lblTitreOptions = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel7 = new System.Windows.Forms.Panel();
            this.m_wndListeCalques = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.m_chkPreserveLayers = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_btnAnnuler = new System.Windows.Forms.Button();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.c2iTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.m_panelOptionsCalque.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // c2iTabControl1
            // 
            this.c2iTabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iTabControl1.BoldSelectedPage = true;
            this.c2iTabControl1.ControlBottomOffset = 16;
            this.c2iTabControl1.ControlRightOffset = 16;
            this.c2iTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c2iTabControl1.ForeColor = System.Drawing.Color.Black;
            this.c2iTabControl1.IDEPixelArea = false;
            this.c2iTabControl1.Location = new System.Drawing.Point(0, 0);
            this.c2iTabControl1.Name = "c2iTabControl1";
            this.c2iTabControl1.Ombre = true;
            this.c2iTabControl1.PositionTop = true;
            this.c2iTabControl1.SelectedIndex = 0;
            this.c2iTabControl1.SelectedTab = this.tabPage1;
            this.c2iTabControl1.Size = new System.Drawing.Size(612, 336);
            this.m_extStyle.SetStyleBackColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iTabControl1.TabIndex = 0;
            this.c2iTabControl1.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2});
            this.c2iTabControl1.TextColor = System.Drawing.Color.Black;
            this.c2iTabControl1.SelectionChanged += new System.EventHandler(this.c2iTabControl1_SelectionChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.panel5);
            this.tabPage1.Controls.Add(this.panel4);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(596, 295);
            this.m_extStyle.SetStyleBackColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage1.TabIndex = 10;
            this.tabPage1.Title = "View|20019";
            this.tabPage1.PropertyChanged += new Crownwood.Magic.Controls.TabPage.PropChangeHandler(this.tabPage1_PropertyChanged);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.m_txtFormuleKeepState);
            this.panel9.Controls.Add(this.label9);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 159);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(596, 21);
            this.m_extStyle.SetStyleBackColor(this.panel9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel9.TabIndex = 7;
            // 
            // m_txtFormuleKeepState
            // 
            this.m_txtFormuleKeepState.AllowGraphic = true;
            this.m_txtFormuleKeepState.AllowNullFormula = false;
            this.m_txtFormuleKeepState.AllowSaisieTexte = true;
            this.m_txtFormuleKeepState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtFormuleKeepState.Formule = null;
            this.m_txtFormuleKeepState.Location = new System.Drawing.Point(144, 0);
            this.m_txtFormuleKeepState.LockEdition = false;
            this.m_txtFormuleKeepState.LockZoneTexte = false;
            this.m_txtFormuleKeepState.Name = "m_txtFormuleKeepState";
            this.m_txtFormuleKeepState.Size = new System.Drawing.Size(452, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtFormuleKeepState, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFormuleKeepState, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleKeepState.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Left;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 21);
            this.m_extStyle.SetStyleBackColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label9.TabIndex = 0;
            this.label9.Text = "Keep state key|20034";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(0, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(596, 24);
            this.m_extStyle.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 6;
            this.label8.Text = "Keep state|20033";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.m_chkPreserveMapMode);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 111);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(596, 24);
            this.m_extStyle.SetStyleBackColor(this.panel5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel5.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.m_rbtnHybride);
            this.panel6.Controls.Add(this.m_rbtnAerial);
            this.panel6.Controls.Add(this.m_rbtnViewMap);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(144, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(452, 24);
            this.m_extStyle.SetStyleBackColor(this.panel6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel6.TabIndex = 1;
            // 
            // m_rbtnHybride
            // 
            this.m_rbtnHybride.AutoSize = true;
            this.m_rbtnHybride.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_rbtnHybride.Location = new System.Drawing.Point(165, 0);
            this.m_rbtnHybride.Name = "m_rbtnHybride";
            this.m_rbtnHybride.Size = new System.Drawing.Size(90, 24);
            this.m_extStyle.SetStyleBackColor(this.m_rbtnHybride, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_rbtnHybride, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_rbtnHybride.TabIndex = 2;
            this.m_rbtnHybride.TabStop = true;
            this.m_rbtnHybride.Text = "Hybrid|20029";
            this.m_rbtnHybride.UseVisualStyleBackColor = true;
            // 
            // m_rbtnAerial
            // 
            this.m_rbtnAerial.AutoSize = true;
            this.m_rbtnAerial.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_rbtnAerial.Location = new System.Drawing.Point(79, 0);
            this.m_rbtnAerial.Name = "m_rbtnAerial";
            this.m_rbtnAerial.Size = new System.Drawing.Size(86, 24);
            this.m_extStyle.SetStyleBackColor(this.m_rbtnAerial, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_rbtnAerial, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_rbtnAerial.TabIndex = 1;
            this.m_rbtnAerial.TabStop = true;
            this.m_rbtnAerial.Text = "Aerial|20028";
            this.m_rbtnAerial.UseVisualStyleBackColor = true;
            // 
            // m_rbtnViewMap
            // 
            this.m_rbtnViewMap.AutoSize = true;
            this.m_rbtnViewMap.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_rbtnViewMap.Location = new System.Drawing.Point(0, 0);
            this.m_rbtnViewMap.Name = "m_rbtnViewMap";
            this.m_rbtnViewMap.Size = new System.Drawing.Size(79, 24);
            this.m_extStyle.SetStyleBackColor(this.m_rbtnViewMap, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_rbtnViewMap, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_rbtnViewMap.TabIndex = 0;
            this.m_rbtnViewMap.TabStop = true;
            this.m_rbtnViewMap.Text = "Map|20027";
            this.m_rbtnViewMap.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(26, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 24);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 0;
            this.label4.Text = "Display|20026";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_chkPreserveMapMode
            // 
            this.m_chkPreserveMapMode.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_chkPreserveMapMode.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_chkPreserveMapMode.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.m_chkPreserveMapMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_chkPreserveMapMode.Image = global::futurocom.win32.sig.Resource.save;
            this.m_chkPreserveMapMode.Location = new System.Drawing.Point(0, 0);
            this.m_chkPreserveMapMode.Name = "m_chkPreserveMapMode";
            this.m_chkPreserveMapMode.Size = new System.Drawing.Size(26, 24);
            this.m_extStyle.SetStyleBackColor(this.m_chkPreserveMapMode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkPreserveMapMode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkPreserveMapMode.TabIndex = 4;
            this.m_chkPreserveMapMode.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.m_txtFormuleZoom);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.m_chkPreserveZoom);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 90);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(596, 21);
            this.m_extStyle.SetStyleBackColor(this.panel4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel4.TabIndex = 2;
            // 
            // m_txtFormuleZoom
            // 
            this.m_txtFormuleZoom.AllowGraphic = true;
            this.m_txtFormuleZoom.AllowNullFormula = false;
            this.m_txtFormuleZoom.AllowSaisieTexte = true;
            this.m_txtFormuleZoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtFormuleZoom.Formule = null;
            this.m_txtFormuleZoom.Location = new System.Drawing.Point(144, 0);
            this.m_txtFormuleZoom.LockEdition = false;
            this.m_txtFormuleZoom.LockZoneTexte = false;
            this.m_txtFormuleZoom.Name = "m_txtFormuleZoom";
            this.m_txtFormuleZoom.Size = new System.Drawing.Size(452, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtFormuleZoom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFormuleZoom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleZoom.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(26, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 21);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 0;
            this.label3.Text = "Zoom factor|200025";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_chkPreserveZoom
            // 
            this.m_chkPreserveZoom.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_chkPreserveZoom.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_chkPreserveZoom.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.m_chkPreserveZoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_chkPreserveZoom.Image = global::futurocom.win32.sig.Resource.save;
            this.m_chkPreserveZoom.Location = new System.Drawing.Point(0, 0);
            this.m_chkPreserveZoom.Name = "m_chkPreserveZoom";
            this.m_chkPreserveZoom.Size = new System.Drawing.Size(26, 21);
            this.m_extStyle.SetStyleBackColor(this.m_chkPreserveZoom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkPreserveZoom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkPreserveZoom.TabIndex = 3;
            this.m_chkPreserveZoom.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(0, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(596, 24);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 5;
            this.label6.Text = "Display options|20024";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.m_txtFormuleLongitude);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 45);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(596, 21);
            this.m_extStyle.SetStyleBackColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel3.TabIndex = 1;
            // 
            // m_txtFormuleLongitude
            // 
            this.m_txtFormuleLongitude.AllowGraphic = true;
            this.m_txtFormuleLongitude.AllowNullFormula = false;
            this.m_txtFormuleLongitude.AllowSaisieTexte = true;
            this.m_txtFormuleLongitude.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtFormuleLongitude.Formule = null;
            this.m_txtFormuleLongitude.Location = new System.Drawing.Point(144, 0);
            this.m_txtFormuleLongitude.LockEdition = false;
            this.m_txtFormuleLongitude.LockZoneTexte = false;
            this.m_txtFormuleLongitude.Name = "m_txtFormuleLongitude";
            this.m_txtFormuleLongitude.Size = new System.Drawing.Size(452, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtFormuleLongitude, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFormuleLongitude, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleLongitude.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 21);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 0;
            this.label2.Text = "Longitude|20021";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_txtFormuleLatitude);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.m_chkPreserveCenter);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(596, 21);
            this.m_extStyle.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel2.TabIndex = 0;
            // 
            // m_txtFormuleLatitude
            // 
            this.m_txtFormuleLatitude.AllowGraphic = true;
            this.m_txtFormuleLatitude.AllowNullFormula = false;
            this.m_txtFormuleLatitude.AllowSaisieTexte = true;
            this.m_txtFormuleLatitude.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtFormuleLatitude.Formule = null;
            this.m_txtFormuleLatitude.Location = new System.Drawing.Point(144, 0);
            this.m_txtFormuleLatitude.LockEdition = false;
            this.m_txtFormuleLatitude.LockZoneTexte = false;
            this.m_txtFormuleLatitude.Name = "m_txtFormuleLatitude";
            this.m_txtFormuleLatitude.Size = new System.Drawing.Size(452, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtFormuleLatitude, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFormuleLatitude, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleLatitude.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(26, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 21);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 0;
            this.label1.Text = "Latitude|20021";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_chkPreserveCenter
            // 
            this.m_chkPreserveCenter.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_chkPreserveCenter.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_chkPreserveCenter.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.m_chkPreserveCenter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_chkPreserveCenter.Image = global::futurocom.win32.sig.Resource.save;
            this.m_chkPreserveCenter.Location = new System.Drawing.Point(0, 0);
            this.m_chkPreserveCenter.Name = "m_chkPreserveCenter";
            this.m_chkPreserveCenter.Size = new System.Drawing.Size(26, 21);
            this.m_extStyle.SetStyleBackColor(this.m_chkPreserveCenter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkPreserveCenter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkPreserveCenter.TabIndex = 2;
            this.m_chkPreserveCenter.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(596, 24);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 4;
            this.label5.Text = "Map center|20023";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.m_panelOptionsCalque);
            this.tabPage2.Controls.Add(this.splitter1);
            this.tabPage2.Controls.Add(this.panel7);
            this.tabPage2.Location = new System.Drawing.Point(0, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(596, 295);
            this.m_extStyle.SetStyleBackColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage2.TabIndex = 11;
            this.tabPage2.Title = "Layers|20020";
            // 
            // m_panelOptionsCalque
            // 
            this.m_panelOptionsCalque.Controls.Add(this.m_wndListeValeursVariables);
            this.m_panelOptionsCalque.Controls.Add(this.m_lblTitreOptions);
            this.m_panelOptionsCalque.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelOptionsCalque.Location = new System.Drawing.Point(203, 0);
            this.m_panelOptionsCalque.Name = "m_panelOptionsCalque";
            this.m_panelOptionsCalque.Size = new System.Drawing.Size(393, 295);
            this.m_extStyle.SetStyleBackColor(this.m_panelOptionsCalque, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelOptionsCalque, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelOptionsCalque.TabIndex = 1;
            this.m_panelOptionsCalque.Visible = false;
            // 
            // m_wndListeValeursVariables
            // 
            this.m_wndListeValeursVariables.AutoScroll = true;
            this.m_wndListeValeursVariables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeValeursVariables.HasDeleteButton = false;
            this.m_wndListeValeursVariables.HasHadButton = false;
            this.m_wndListeValeursVariables.HeaderTextForFormula = "";
            this.m_wndListeValeursVariables.HeaderTextForName = "";
            this.m_wndListeValeursVariables.HideNomFormule = false;
            this.m_wndListeValeursVariables.Location = new System.Drawing.Point(0, 23);
            this.m_wndListeValeursVariables.LockEdition = false;
            this.m_wndListeValeursVariables.Name = "m_wndListeValeursVariables";
            this.m_wndListeValeursVariables.Size = new System.Drawing.Size(393, 272);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeValeursVariables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeValeursVariables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeValeursVariables.TabIndex = 2;
            this.m_wndListeValeursVariables.TypeFormuleNomme = typeof(sc2i.expression.CFormuleNommee);
            // 
            // m_lblTitreOptions
            // 
            this.m_lblTitreOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.m_lblTitreOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_lblTitreOptions.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblTitreOptions.ForeColor = System.Drawing.Color.White;
            this.m_lblTitreOptions.Location = new System.Drawing.Point(0, 0);
            this.m_lblTitreOptions.Name = "m_lblTitreOptions";
            this.m_lblTitreOptions.Size = new System.Drawing.Size(393, 23);
            this.m_extStyle.SetStyleBackColor(this.m_lblTitreOptions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblTitreOptions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblTitreOptions.TabIndex = 1;
            this.m_lblTitreOptions.Text = "Layer options|20031";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(200, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 295);
            this.m_extStyle.SetStyleBackColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.m_wndListeCalques);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(200, 295);
            this.m_extStyle.SetStyleBackColor(this.panel7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel7.TabIndex = 0;
            // 
            // m_wndListeCalques
            // 
            this.m_wndListeCalques.CheckBoxes = true;
            this.m_wndListeCalques.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.m_wndListeCalques.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeCalques.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_wndListeCalques.HideSelection = false;
            this.m_wndListeCalques.Location = new System.Drawing.Point(0, 27);
            this.m_wndListeCalques.MultiSelect = false;
            this.m_wndListeCalques.Name = "m_wndListeCalques";
            this.m_wndListeCalques.Size = new System.Drawing.Size(200, 268);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeCalques, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeCalques, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeCalques.TabIndex = 1;
            this.m_wndListeCalques.UseCompatibleStateImageBehavior = false;
            this.m_wndListeCalques.View = System.Windows.Forms.View.Details;
            this.m_wndListeCalques.SelectedIndexChanged += new System.EventHandler(this.m_wndListeCalques_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 381;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.label7);
            this.panel8.Controls.Add(this.m_chkPreserveLayers);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(200, 27);
            this.m_extStyle.SetStyleBackColor(this.panel8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel8.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(26, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(174, 27);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 0;
            this.label7.Text = "Layers|20030";
            // 
            // m_chkPreserveLayers
            // 
            this.m_chkPreserveLayers.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_chkPreserveLayers.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_chkPreserveLayers.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.m_chkPreserveLayers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_chkPreserveLayers.Image = global::futurocom.win32.sig.Resource.save;
            this.m_chkPreserveLayers.Location = new System.Drawing.Point(0, 0);
            this.m_chkPreserveLayers.Name = "m_chkPreserveLayers";
            this.m_chkPreserveLayers.Size = new System.Drawing.Size(26, 27);
            this.m_extStyle.SetStyleBackColor(this.m_chkPreserveLayers, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkPreserveLayers, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkPreserveLayers.TabIndex = 4;
            this.m_chkPreserveLayers.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_btnAnnuler);
            this.panel1.Controls.Add(this.m_btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 336);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(612, 40);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 1;
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnAnnuler.ForeColor = System.Drawing.Color.White;
            this.m_btnAnnuler.Image = global::futurocom.win32.sig.Resource.cancel;
            this.m_btnAnnuler.Location = new System.Drawing.Point(313, 0);
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(40, 40);
            this.m_extStyle.SetStyleBackColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAnnuler.TabIndex = 5;
            this.m_btnAnnuler.Click += new System.EventHandler(this.m_btnAnnuler_Click);
            // 
            // m_btnOk
            // 
            this.m_btnOk.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnOk.ForeColor = System.Drawing.Color.White;
            this.m_btnOk.Image = global::futurocom.win32.sig.Resource.check;
            this.m_btnOk.Location = new System.Drawing.Point(259, 0);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(40, 40);
            this.m_extStyle.SetStyleBackColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnOk.TabIndex = 4;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            // 
            // CFormEditConfigWndMapView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 376);
            this.Controls.Add(this.c2iTabControl1);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "CFormEditConfigWndMapView";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondFenetre);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTexteFenetre);
            this.Text = "Map setup|20018";
            this.Load += new System.EventHandler(this.CFormEditConfigWndMapView_Load);
            this.c2iTabControl1.ResumeLayout(false);
            this.c2iTabControl1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.m_panelOptionsCalque.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.CExtStyle m_extStyle;
        private sc2i.win32.common.C2iTabControl c2iTabControl1;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private Crownwood.Magic.Controls.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleLongitude;
        private System.Windows.Forms.Label label2;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleLatitude;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.RadioButton m_rbtnViewMap;
        private System.Windows.Forms.RadioButton m_rbtnHybride;
        private System.Windows.Forms.RadioButton m_rbtnAerial;
        private System.Windows.Forms.Panel m_panelOptionsCalque;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label m_lblTitreOptions;
        private System.Windows.Forms.ListView m_wndListeCalques;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private sc2i.win32.expression.CControlEditListeFormulesNommees m_wndListeValeursVariables;
        private System.Windows.Forms.Button m_btnAnnuler;
        private System.Windows.Forms.Button m_btnOk;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleZoom;
        private System.Windows.Forms.CheckBox m_chkPreserveCenter;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.CheckBox m_chkPreserveLayers;
        private System.Windows.Forms.CheckBox m_chkPreserveMapMode;
        private System.Windows.Forms.CheckBox m_chkPreserveZoom;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel9;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleKeepState;
        private System.Windows.Forms.Label label9;
    }
}