namespace futurocom.win32.snmp
{
    partial class CMibList
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
            this.m_wndListe = new System.Windows.Forms.ListView();
            this.m_colName = new System.Windows.Forms.ColumnHeader();
            this.m_colType = new System.Windows.Forms.ColumnHeader();
            this.m_imageList = new System.Windows.Forms.ImageList(this.components);
            this.m_slidingFiltre = new sc2i.win32.common.CSlidingZone();
            this.m_wndListeTypes = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_timerOnChangeFiltre = new System.Windows.Forms.Timer(this.components);
            this.m_chkRecursive = new System.Windows.Forms.CheckBox();
            this.m_txtPath = new sc2i.win32.common.C2iTextBox();
            this.m_panelDecaleFiltre = new System.Windows.Forms.Panel();
            this.m_panelListe = new System.Windows.Forms.Panel();
            this.m_panelTitre = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.m_menuListeTypes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_mnuOnlyThis = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuExceptThis = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuSepChecks = new System.Windows.Forms.ToolStripSeparator();
            this.m_mnuAll = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuNone = new System.Windows.Forms.ToolStripMenuItem();
            this.m_slidingFiltre.SuspendLayout();
            this.m_panelListe.SuspendLayout();
            this.m_panelTitre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.m_menuListeTypes.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_wndListe
            // 
            this.m_wndListe.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_colName,
            this.m_colType});
            this.m_wndListe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListe.Location = new System.Drawing.Point(0, 18);
            this.m_wndListe.MultiSelect = false;
            this.m_wndListe.Name = "m_wndListe";
            this.m_wndListe.ShowItemToolTips = true;
            this.m_wndListe.Size = new System.Drawing.Size(253, 273);
            this.m_wndListe.SmallImageList = this.m_imageList;
            this.m_wndListe.TabIndex = 1;
            this.m_wndListe.UseCompatibleStateImageBehavior = false;
            this.m_wndListe.View = System.Windows.Forms.View.Details;
            this.m_wndListe.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.m_wndListe_MouseDoubleClick);
            this.m_wndListe.SelectedIndexChanged += new System.EventHandler(this.m_wndListe_SelectedIndexChanged);
            this.m_wndListe.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.m_wndListe_ColumnClick);
            // 
            // m_colName
            // 
            this.m_colName.Text = "Name|20018";
            this.m_colName.Width = 134;
            // 
            // m_colType
            // 
            this.m_colType.Text = "Type|20019";
            this.m_colType.Width = 96;
            // 
            // m_imageList
            // 
            this.m_imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.m_imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.m_imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // m_slidingFiltre
            // 
            this.m_slidingFiltre.AllowDrop = true;
            this.m_slidingFiltre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_slidingFiltre.Controls.Add(this.m_wndListeTypes);
            this.m_slidingFiltre.Controls.Add(this.label2);
            this.m_slidingFiltre.Controls.Add(this.m_txtName);
            this.m_slidingFiltre.Controls.Add(this.label1);
            this.m_slidingFiltre.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_slidingFiltre.ExtendedSize = 198;
            this.m_slidingFiltre.IsCollapse = false;
            this.m_slidingFiltre.Location = new System.Drawing.Point(0, 37);
            this.m_slidingFiltre.LockEdition = false;
            this.m_slidingFiltre.Name = "m_slidingFiltre";
            this.m_slidingFiltre.Size = new System.Drawing.Size(253, 198);
            this.m_slidingFiltre.TabIndex = 2;
            this.m_slidingFiltre.TitleAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_slidingFiltre.TitleBackColor = System.Drawing.Color.White;
            this.m_slidingFiltre.TitleBackColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(255)))));
            this.m_slidingFiltre.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_slidingFiltre.TitleHeight = 18;
            this.m_slidingFiltre.TitleText = "Filter|20020";
            this.m_slidingFiltre.Load += new System.EventHandler(this.m_slidingFiltre_Load);
            // 
            // m_wndListeTypes
            // 
            this.m_wndListeTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_wndListeTypes.CheckBoxes = true;
            this.m_wndListeTypes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.m_wndListeTypes.ContextMenuStrip = this.m_menuListeTypes;
            this.m_wndListeTypes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_wndListeTypes.Location = new System.Drawing.Point(69, 41);
            this.m_wndListeTypes.Name = "m_wndListeTypes";
            this.m_wndListeTypes.Size = new System.Drawing.Size(179, 140);
            this.m_wndListeTypes.SmallImageList = this.m_imageList;
            this.m_wndListeTypes.TabIndex = 4;
            this.m_wndListeTypes.UseCompatibleStateImageBehavior = false;
            this.m_wndListeTypes.View = System.Windows.Forms.View.Details;
            this.m_wndListeTypes.MouseClick += new System.Windows.Forms.MouseEventHandler(this.m_wndListeTypes_MouseClick);
            this.m_wndListeTypes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.m_wndListeTypes_ItemCheck);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 120;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Type|20019";
            // 
            // m_txtName
            // 
            this.m_txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtName.Location = new System.Drawing.Point(69, 20);
            this.m_txtName.Name = "m_txtName";
            this.m_txtName.Size = new System.Drawing.Size(179, 20);
            this.m_txtName.TabIndex = 2;
            this.m_txtName.TextChanged += new System.EventHandler(this.m_txtName_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name|20018";
            // 
            // m_timerOnChangeFiltre
            // 
            this.m_timerOnChangeFiltre.Interval = 500;
            this.m_timerOnChangeFiltre.Tick += new System.EventHandler(this.m_timerOnChangeFiltre_Tick);
            // 
            // m_chkRecursive
            // 
            this.m_chkRecursive.AutoSize = true;
            this.m_chkRecursive.Checked = true;
            this.m_chkRecursive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkRecursive.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_chkRecursive.Location = new System.Drawing.Point(0, 20);
            this.m_chkRecursive.Name = "m_chkRecursive";
            this.m_chkRecursive.Size = new System.Drawing.Size(253, 17);
            this.m_chkRecursive.TabIndex = 5;
            this.m_chkRecursive.Text = "Recursive|20021";
            this.m_chkRecursive.UseVisualStyleBackColor = true;
            this.m_chkRecursive.Visible = false;
            this.m_chkRecursive.CheckedChanged += new System.EventHandler(this.m_chkRecursive_CheckedChanged);
            // 
            // m_txtPath
            // 
            this.m_txtPath.BackColor = System.Drawing.SystemColors.Control;
            this.m_txtPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_txtPath.Location = new System.Drawing.Point(0, 0);
            this.m_txtPath.LockEdition = true;
            this.m_txtPath.Name = "m_txtPath";
            this.m_txtPath.Size = new System.Drawing.Size(229, 20);
            this.m_txtPath.TabIndex = 6;
            this.m_txtPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // m_panelDecaleFiltre
            // 
            this.m_panelDecaleFiltre.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelDecaleFiltre.Location = new System.Drawing.Point(0, 0);
            this.m_panelDecaleFiltre.Name = "m_panelDecaleFiltre";
            this.m_panelDecaleFiltre.Size = new System.Drawing.Size(253, 18);
            this.m_panelDecaleFiltre.TabIndex = 7;
            // 
            // m_panelListe
            // 
            this.m_panelListe.Controls.Add(this.m_wndListe);
            this.m_panelListe.Controls.Add(this.m_panelDecaleFiltre);
            this.m_panelListe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelListe.Location = new System.Drawing.Point(0, 37);
            this.m_panelListe.Name = "m_panelListe";
            this.m_panelListe.Size = new System.Drawing.Size(253, 291);
            this.m_panelListe.TabIndex = 8;
            // 
            // m_panelTitre
            // 
            this.m_panelTitre.Controls.Add(this.m_txtPath);
            this.m_panelTitre.Controls.Add(this.pictureBox1);
            this.m_panelTitre.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelTitre.Location = new System.Drawing.Point(0, 0);
            this.m_panelTitre.Name = "m_panelTitre";
            this.m_panelTitre.Size = new System.Drawing.Size(253, 20);
            this.m_panelTitre.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = global::futurocom.win32.snmp.Properties.Resources.syncList;
            this.pictureBox1.Location = new System.Drawing.Point(229, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // m_menuListeTypes
            // 
            this.m_menuListeTypes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_mnuOnlyThis,
            this.m_mnuExceptThis,
            this.m_mnuSepChecks,
            this.m_mnuAll,
            this.m_mnuNone});
            this.m_menuListeTypes.Name = "m_menuListeTypes";
            this.m_menuListeTypes.Size = new System.Drawing.Size(218, 98);
            this.m_menuListeTypes.Opening += new System.ComponentModel.CancelEventHandler(this.m_menuListeTypes_Opening);
            // 
            // m_mnuOnlyThis
            // 
            this.m_mnuOnlyThis.Name = "m_mnuOnlyThis";
            this.m_mnuOnlyThis.Size = new System.Drawing.Size(217, 22);
            this.m_mnuOnlyThis.Text = "Check this only|20024";
            this.m_mnuOnlyThis.Click += new System.EventHandler(this.m_mnuOnlyThis_Click);
            // 
            // m_mnuExceptThis
            // 
            this.m_mnuExceptThis.Name = "m_mnuExceptThis";
            this.m_mnuExceptThis.Size = new System.Drawing.Size(217, 22);
            this.m_mnuExceptThis.Text = "Check all except this|20025";
            this.m_mnuExceptThis.Click += new System.EventHandler(this.m_mnuExceptThis_Click);
            // 
            // m_mnuSepChecks
            // 
            this.m_mnuSepChecks.Name = "m_mnuSepChecks";
            this.m_mnuSepChecks.Size = new System.Drawing.Size(214, 6);
            // 
            // m_mnuAll
            // 
            this.m_mnuAll.Name = "m_mnuAll";
            this.m_mnuAll.Size = new System.Drawing.Size(217, 22);
            this.m_mnuAll.Text = "Check all|20026";
            this.m_mnuAll.Click += new System.EventHandler(this.m_mnuAll_Click);
            // 
            // m_mnuNone
            // 
            this.m_mnuNone.Name = "m_mnuNone";
            this.m_mnuNone.Size = new System.Drawing.Size(217, 22);
            this.m_mnuNone.Text = "Check none|20027";
            this.m_mnuNone.Click += new System.EventHandler(this.m_mnuNone_Click);
            // 
            // CMibList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_slidingFiltre);
            this.Controls.Add(this.m_panelListe);
            this.Controls.Add(this.m_chkRecursive);
            this.Controls.Add(this.m_panelTitre);
            this.Name = "CMibList";
            this.Size = new System.Drawing.Size(253, 328);
            this.m_slidingFiltre.ResumeLayout(false);
            this.m_slidingFiltre.PerformLayout();
            this.m_panelListe.ResumeLayout(false);
            this.m_panelTitre.ResumeLayout(false);
            this.m_panelTitre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.m_menuListeTypes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView m_wndListe;
        private System.Windows.Forms.ColumnHeader m_colName;
        private System.Windows.Forms.ColumnHeader m_colType;
        private sc2i.win32.common.CSlidingZone m_slidingFiltre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox m_txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView m_wndListeTypes;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Timer m_timerOnChangeFiltre;
        private System.Windows.Forms.CheckBox m_chkRecursive;
        private sc2i.win32.common.C2iTextBox m_txtPath;
        private System.Windows.Forms.Panel m_panelDecaleFiltre;
        private System.Windows.Forms.Panel m_panelListe;
        private System.Windows.Forms.ImageList m_imageList;
        private System.Windows.Forms.Panel m_panelTitre;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip m_menuListeTypes;
        private System.Windows.Forms.ToolStripMenuItem m_mnuOnlyThis;
        private System.Windows.Forms.ToolStripMenuItem m_mnuExceptThis;
        private System.Windows.Forms.ToolStripSeparator m_mnuSepChecks;
        private System.Windows.Forms.ToolStripMenuItem m_mnuAll;
        private System.Windows.Forms.ToolStripMenuItem m_mnuNone;
    }
}
