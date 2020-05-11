namespace ImportDocsMyanmar
{
    partial class CFormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_btnLoad = new System.Windows.Forms.Button();
            this.m_btnSave = new System.Windows.Forms.Button();
            this.m_btnBrowse = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_wndListeFichiers = new System.Windows.Forms.ListView();
            this.m_colNom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.m_colSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.m_colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.m_imagesFichiers = new System.Windows.Forms.ImageList(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_arbre = new System.Windows.Forms.TreeView();
            this.m_menuArbre = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_menuImporterRepertoire = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuCancelImport = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuClearImportInformations = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_btnSearch = new System.Windows.Forms.Button();
            this.m_chkShowErrors = new System.Windows.Forms.CheckBox();
            this.m_chkHideDirsWithoutFiles = new System.Windows.Forms.CheckBox();
            this.m_panelInfo = new System.Windows.Forms.Panel();
            this.m_txtErreur = new System.Windows.Forms.TextBox();
            this.m_imageErreur = new System.Windows.Forms.PictureBox();
            this.m_lblTitreErreur = new System.Windows.Forms.Label();
            this.m_progressBar = new System.Windows.Forms.ProgressBar();
            this.m_btnSummary = new System.Windows.Forms.Button();
            this.m_btnLogs = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.m_menuArbre.SuspendLayout();
            this.panel3.SuspendLayout();
            this.m_panelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageErreur)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_btnLoad);
            this.panel1.Controls.Add(this.m_btnSave);
            this.panel1.Controls.Add(this.m_btnBrowse);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(575, 29);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // m_btnLoad
            // 
            this.m_btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnLoad.Location = new System.Drawing.Point(470, 3);
            this.m_btnLoad.Name = "m_btnLoad";
            this.m_btnLoad.Size = new System.Drawing.Size(75, 23);
            this.m_btnLoad.TabIndex = 2;
            this.m_btnLoad.Text = "Load";
            this.m_btnLoad.UseVisualStyleBackColor = true;
            this.m_btnLoad.Click += new System.EventHandler(this.m_btnLoad_Click);
            // 
            // m_btnSave
            // 
            this.m_btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnSave.Location = new System.Drawing.Point(389, 3);
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Size = new System.Drawing.Size(75, 23);
            this.m_btnSave.TabIndex = 1;
            this.m_btnSave.Text = "Save";
            this.m_btnSave.UseVisualStyleBackColor = true;
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // m_btnBrowse
            // 
            this.m_btnBrowse.Location = new System.Drawing.Point(3, 3);
            this.m_btnBrowse.Name = "m_btnBrowse";
            this.m_btnBrowse.Size = new System.Drawing.Size(104, 23);
            this.m_btnBrowse.TabIndex = 0;
            this.m_btnBrowse.Text = "Browse directory";
            this.m_btnBrowse.UseVisualStyleBackColor = true;
            this.m_btnBrowse.Click += new System.EventHandler(this.m_btnBrowse_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_wndListeFichiers);
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Controls.Add(this.m_arbre);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 52);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(575, 345);
            this.panel2.TabIndex = 2;
            // 
            // m_wndListeFichiers
            // 
            this.m_wndListeFichiers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_colNom,
            this.m_colSize,
            this.m_colDate});
            this.m_wndListeFichiers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeFichiers.HideSelection = false;
            this.m_wndListeFichiers.Location = new System.Drawing.Point(275, 0);
            this.m_wndListeFichiers.MultiSelect = false;
            this.m_wndListeFichiers.Name = "m_wndListeFichiers";
            this.m_wndListeFichiers.Size = new System.Drawing.Size(300, 345);
            this.m_wndListeFichiers.StateImageList = this.m_imagesFichiers;
            this.m_wndListeFichiers.TabIndex = 3;
            this.m_wndListeFichiers.UseCompatibleStateImageBehavior = false;
            this.m_wndListeFichiers.View = System.Windows.Forms.View.Details;
            this.m_wndListeFichiers.SelectedIndexChanged += new System.EventHandler(this.m_wndListeFichiers_SelectedIndexChanged);
            this.m_wndListeFichiers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.m_wndListeFichiers_MouseDoubleClick);
            // 
            // m_colNom
            // 
            this.m_colNom.Text = "File name";
            this.m_colNom.Width = 300;
            // 
            // m_colSize
            // 
            this.m_colSize.Text = "Size";
            // 
            // m_colDate
            // 
            this.m_colDate.Text = "Last write";
            this.m_colDate.Width = 120;
            // 
            // m_imagesFichiers
            // 
            this.m_imagesFichiers.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imagesFichiers.ImageStream")));
            this.m_imagesFichiers.TransparentColor = System.Drawing.Color.Transparent;
            this.m_imagesFichiers.Images.SetKeyName(0, "1409078269_Folder.png");
            this.m_imagesFichiers.Images.SetKeyName(1, "1409078317_12.File-16.png");
            this.m_imagesFichiers.Images.SetKeyName(2, "FolderOK.png");
            this.m_imagesFichiers.Images.SetKeyName(3, "FileOk.png");
            this.m_imagesFichiers.Images.SetKeyName(4, "FolderError.png");
            this.m_imagesFichiers.Images.SetKeyName(5, "FileError.png");
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(272, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 345);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // m_arbre
            // 
            this.m_arbre.ContextMenuStrip = this.m_menuArbre;
            this.m_arbre.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_arbre.HideSelection = false;
            this.m_arbre.ImageIndex = 0;
            this.m_arbre.ImageList = this.m_imagesFichiers;
            this.m_arbre.Location = new System.Drawing.Point(0, 0);
            this.m_arbre.Name = "m_arbre";
            this.m_arbre.SelectedImageIndex = 0;
            this.m_arbre.Size = new System.Drawing.Size(272, 345);
            this.m_arbre.TabIndex = 2;
            this.m_arbre.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.m_arbre_BeforeExpand);
            this.m_arbre.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_arbre_AfterSelect);
            this.m_arbre.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.m_arbre_NodeMouseClick);
            this.m_arbre.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_arbre_MouseDown);
            // 
            // m_menuArbre
            // 
            this.m_menuArbre.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_menuImporterRepertoire,
            this.m_menuCancelImport,
            this.m_menuClearImportInformations});
            this.m_menuArbre.Name = "m_menuArbre";
            this.m_menuArbre.Size = new System.Drawing.Size(212, 70);
            this.m_menuArbre.Opening += new System.ComponentModel.CancelEventHandler(this.m_menuArbre_Opening);
            // 
            // m_menuImporterRepertoire
            // 
            this.m_menuImporterRepertoire.Name = "m_menuImporterRepertoire";
            this.m_menuImporterRepertoire.Size = new System.Drawing.Size(211, 22);
            this.m_menuImporterRepertoire.Text = "Import folder";
            this.m_menuImporterRepertoire.Click += new System.EventHandler(this.m_menuImporterRepertoire_Click);
            // 
            // m_menuCancelImport
            // 
            this.m_menuCancelImport.Name = "m_menuCancelImport";
            this.m_menuCancelImport.Size = new System.Drawing.Size(211, 22);
            this.m_menuCancelImport.Text = "Cancel Import";
            this.m_menuCancelImport.Click += new System.EventHandler(this.m_menuCancelImport_Click);
            // 
            // m_menuClearImportInformations
            // 
            this.m_menuClearImportInformations.Name = "m_menuClearImportInformations";
            this.m_menuClearImportInformations.Size = new System.Drawing.Size(211, 22);
            this.m_menuClearImportInformations.Text = "Clear import informations";
            this.m_menuClearImportInformations.Click += new System.EventHandler(this.m_menuClearImportInformations_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.m_btnLogs);
            this.panel3.Controls.Add(this.m_btnSummary);
            this.panel3.Controls.Add(this.m_btnSearch);
            this.panel3.Controls.Add(this.m_chkShowErrors);
            this.panel3.Controls.Add(this.m_chkHideDirsWithoutFiles);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(575, 23);
            this.panel3.TabIndex = 5;
            // 
            // m_btnSearch
            // 
            this.m_btnSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnSearch.Image = global::ImportDocsMyanmar.Properties.Resources.search;
            this.m_btnSearch.Location = new System.Drawing.Point(549, 0);
            this.m_btnSearch.Name = "m_btnSearch";
            this.m_btnSearch.Size = new System.Drawing.Size(26, 23);
            this.m_btnSearch.TabIndex = 2;
            this.m_btnSearch.UseVisualStyleBackColor = true;
            this.m_btnSearch.Click += new System.EventHandler(this.m_btnSearch_Click);
            // 
            // m_chkShowErrors
            // 
            this.m_chkShowErrors.AutoSize = true;
            this.m_chkShowErrors.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_chkShowErrors.Location = new System.Drawing.Point(157, 0);
            this.m_chkShowErrors.Name = "m_chkShowErrors";
            this.m_chkShowErrors.Size = new System.Drawing.Size(104, 23);
            this.m_chkShowErrors.TabIndex = 1;
            this.m_chkShowErrors.Text = "Show errors only";
            this.m_chkShowErrors.UseVisualStyleBackColor = true;
            this.m_chkShowErrors.CheckedChanged += new System.EventHandler(this.m_chkShowErrors_CheckedChanged);
            // 
            // m_chkHideDirsWithoutFiles
            // 
            this.m_chkHideDirsWithoutFiles.AutoSize = true;
            this.m_chkHideDirsWithoutFiles.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_chkHideDirsWithoutFiles.Location = new System.Drawing.Point(0, 0);
            this.m_chkHideDirsWithoutFiles.Name = "m_chkHideDirsWithoutFiles";
            this.m_chkHideDirsWithoutFiles.Size = new System.Drawing.Size(157, 23);
            this.m_chkHideDirsWithoutFiles.TabIndex = 0;
            this.m_chkHideDirsWithoutFiles.Text = "Hide directories without files";
            this.m_chkHideDirsWithoutFiles.UseVisualStyleBackColor = true;
            this.m_chkHideDirsWithoutFiles.CheckedChanged += new System.EventHandler(this.m_chkHideDirsWithoutFiles_CheckedChanged);
            // 
            // m_panelInfo
            // 
            this.m_panelInfo.Controls.Add(this.m_txtErreur);
            this.m_panelInfo.Controls.Add(this.m_imageErreur);
            this.m_panelInfo.Controls.Add(this.m_lblTitreErreur);
            this.m_panelInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_panelInfo.Location = new System.Drawing.Point(0, 397);
            this.m_panelInfo.Name = "m_panelInfo";
            this.m_panelInfo.Size = new System.Drawing.Size(575, 66);
            this.m_panelInfo.TabIndex = 5;
            // 
            // m_txtErreur
            // 
            this.m_txtErreur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtErreur.Location = new System.Drawing.Point(53, 13);
            this.m_txtErreur.Multiline = true;
            this.m_txtErreur.Name = "m_txtErreur";
            this.m_txtErreur.ReadOnly = true;
            this.m_txtErreur.Size = new System.Drawing.Size(522, 53);
            this.m_txtErreur.TabIndex = 1;
            // 
            // m_imageErreur
            // 
            this.m_imageErreur.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_imageErreur.Location = new System.Drawing.Point(0, 13);
            this.m_imageErreur.Name = "m_imageErreur";
            this.m_imageErreur.Size = new System.Drawing.Size(53, 53);
            this.m_imageErreur.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_imageErreur.TabIndex = 0;
            this.m_imageErreur.TabStop = false;
            // 
            // m_lblTitreErreur
            // 
            this.m_lblTitreErreur.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_lblTitreErreur.Location = new System.Drawing.Point(0, 0);
            this.m_lblTitreErreur.Name = "m_lblTitreErreur";
            this.m_lblTitreErreur.Size = new System.Drawing.Size(575, 13);
            this.m_lblTitreErreur.TabIndex = 2;
            // 
            // m_progressBar
            // 
            this.m_progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_progressBar.Location = new System.Drawing.Point(0, 463);
            this.m_progressBar.Name = "m_progressBar";
            this.m_progressBar.Size = new System.Drawing.Size(575, 23);
            this.m_progressBar.TabIndex = 3;
            this.m_progressBar.Visible = false;
            // 
            // m_btnSummary
            // 
            this.m_btnSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnSummary.Location = new System.Drawing.Point(468, -1);
            this.m_btnSummary.Name = "m_btnSummary";
            this.m_btnSummary.Size = new System.Drawing.Size(75, 23);
            this.m_btnSummary.TabIndex = 2;
            this.m_btnSummary.Text = "Summary";
            this.m_btnSummary.UseVisualStyleBackColor = true;
            this.m_btnSummary.Click += new System.EventHandler(this.m_btnSummary_Click);
            // 
            // m_btnLogs
            // 
            this.m_btnLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnLogs.Location = new System.Drawing.Point(387, -1);
            this.m_btnLogs.Name = "m_btnLogs";
            this.m_btnLogs.Size = new System.Drawing.Size(75, 23);
            this.m_btnLogs.TabIndex = 3;
            this.m_btnLogs.Text = "Logs";
            this.m_btnLogs.UseVisualStyleBackColor = true;
            this.m_btnLogs.Click += new System.EventHandler(this.m_btnLogs_Click);
            // 
            // CFormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 486);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_panelInfo);
            this.Controls.Add(this.m_progressBar);
            this.Name = "CFormMain";
            this.Text = "File external explorer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.m_menuArbre.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.m_panelInfo.ResumeLayout(false);
            this.m_panelInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageErreur)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button m_btnBrowse;
        private System.Windows.Forms.Button m_btnLoad;
        private System.Windows.Forms.Button m_btnSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView m_wndListeFichiers;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TreeView m_arbre;
        private System.Windows.Forms.ImageList m_imagesFichiers;
        private System.Windows.Forms.ColumnHeader m_colNom;
        private System.Windows.Forms.ColumnHeader m_colSize;
        private System.Windows.Forms.ColumnHeader m_colDate;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox m_chkHideDirsWithoutFiles;
        private System.Windows.Forms.ContextMenuStrip m_menuArbre;
        private System.Windows.Forms.ToolStripMenuItem m_menuImporterRepertoire;
        private System.Windows.Forms.Panel m_panelInfo;
        private System.Windows.Forms.TextBox m_txtErreur;
        private System.Windows.Forms.PictureBox m_imageErreur;
        private System.Windows.Forms.Label m_lblTitreErreur;
        private System.Windows.Forms.ToolStripMenuItem m_menuCancelImport;
        private System.Windows.Forms.ProgressBar m_progressBar;
        private System.Windows.Forms.CheckBox m_chkShowErrors;
        private System.Windows.Forms.ToolStripMenuItem m_menuClearImportInformations;
        private System.Windows.Forms.Button m_btnSearch;
        private System.Windows.Forms.Button m_btnSummary;
        private System.Windows.Forms.Button m_btnLogs;
    }
}

