namespace futurocom.win32.snmp
{
    partial class CWndMibBrowser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CWndMibBrowser));
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_panelViewer = new System.Windows.Forms.Panel();
            this.m_panelNavigation = new System.Windows.Forms.Panel();
            this.m_lblType = new System.Windows.Forms.Label();
            this.m_btnParametres = new System.Windows.Forms.Button();
            this.m_boutonNext = new System.Windows.Forms.Button();
            this.m_boutonPrevious = new System.Windows.Forms.Button();
            this.m_panelDroite = new System.Windows.Forms.Panel();
            this.m_panelLeft = new System.Windows.Forms.Panel();
            this.m_splitterListe = new System.Windows.Forms.Splitter();
            this.m_mibTree = new SnmpTest.CMibTree();
            this.m_menuArbre = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_menuParcourir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_menuGetFromArbre = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuWalk = new System.Windows.Forms.ToolStripMenuItem();
            this.m_mnuVoirTable = new System.Windows.Forms.ToolStripMenuItem();
            this.m_slideListe = new sc2i.win32.common.CSlidingZone();
            this.m_wndListe = new futurocom.win32.snmp.CMibList();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelDroite.SuspendLayout();
            this.m_panelLeft.SuspendLayout();
            this.m_menuArbre.SuspendLayout();
            this.m_slideListe.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(377, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 288);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // m_panelViewer
            // 
            this.m_panelViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelViewer.Location = new System.Drawing.Point(0, 31);
            this.m_panelViewer.Name = "m_panelViewer";
            this.m_panelViewer.Size = new System.Drawing.Size(163, 257);
            this.m_panelViewer.TabIndex = 2;
            // 
            // m_panelNavigation
            // 
            this.m_panelNavigation.Controls.Add(this.m_lblType);
            this.m_panelNavigation.Controls.Add(this.m_btnParametres);
            this.m_panelNavigation.Controls.Add(this.m_boutonNext);
            this.m_panelNavigation.Controls.Add(this.m_boutonPrevious);
            this.m_panelNavigation.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelNavigation.Location = new System.Drawing.Point(0, 0);
            this.m_panelNavigation.Name = "m_panelNavigation";
            this.m_panelNavigation.Size = new System.Drawing.Size(163, 31);
            this.m_panelNavigation.TabIndex = 3;
            // 
            // m_lblType
            // 
            this.m_lblType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblType.Location = new System.Drawing.Point(70, 0);
            this.m_lblType.Name = "m_lblType";
            this.m_lblType.Size = new System.Drawing.Size(58, 31);
            this.m_lblType.TabIndex = 2;
            this.m_lblType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_btnParametres
            // 
            this.m_btnParametres.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnParametres.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_btnParametres.Image = global::futurocom.win32.snmp.Properties.Resources.Settings;
            this.m_btnParametres.Location = new System.Drawing.Point(128, 0);
            this.m_btnParametres.Name = "m_btnParametres";
            this.m_btnParametres.Size = new System.Drawing.Size(35, 31);
            this.m_btnParametres.TabIndex = 3;
            this.m_btnParametres.UseVisualStyleBackColor = true;
            this.m_btnParametres.Click += new System.EventHandler(this.m_btnParametres_Click);
            // 
            // m_boutonNext
            // 
            this.m_boutonNext.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_boutonNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_boutonNext.Image = ((System.Drawing.Image)(resources.GetObject("m_boutonNext.Image")));
            this.m_boutonNext.Location = new System.Drawing.Point(35, 0);
            this.m_boutonNext.Name = "m_boutonNext";
            this.m_boutonNext.Size = new System.Drawing.Size(35, 31);
            this.m_boutonNext.TabIndex = 1;
            this.m_boutonNext.UseVisualStyleBackColor = true;
            this.m_boutonNext.Click += new System.EventHandler(this.m_boutonNext_Click);
            // 
            // m_boutonPrevious
            // 
            this.m_boutonPrevious.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_boutonPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_boutonPrevious.Image = ((System.Drawing.Image)(resources.GetObject("m_boutonPrevious.Image")));
            this.m_boutonPrevious.Location = new System.Drawing.Point(0, 0);
            this.m_boutonPrevious.Name = "m_boutonPrevious";
            this.m_boutonPrevious.Size = new System.Drawing.Size(35, 31);
            this.m_boutonPrevious.TabIndex = 0;
            this.m_boutonPrevious.UseVisualStyleBackColor = true;
            this.m_boutonPrevious.Click += new System.EventHandler(this.m_boutonPrevious_Click);
            // 
            // m_panelDroite
            // 
            this.m_panelDroite.Controls.Add(this.m_panelViewer);
            this.m_panelDroite.Controls.Add(this.m_panelNavigation);
            this.m_panelDroite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelDroite.Location = new System.Drawing.Point(380, 0);
            this.m_panelDroite.Name = "m_panelDroite";
            this.m_panelDroite.Size = new System.Drawing.Size(163, 288);
            this.m_panelDroite.TabIndex = 4;
            // 
            // m_panelLeft
            // 
            this.m_panelLeft.Controls.Add(this.m_splitterListe);
            this.m_panelLeft.Controls.Add(this.m_mibTree);
            this.m_panelLeft.Controls.Add(this.m_slideListe);
            this.m_panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelLeft.Location = new System.Drawing.Point(0, 0);
            this.m_panelLeft.Name = "m_panelLeft";
            this.m_panelLeft.Size = new System.Drawing.Size(377, 288);
            this.m_panelLeft.TabIndex = 5;
            // 
            // m_splitterListe
            // 
            this.m_splitterListe.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_splitterListe.Enabled = false;
            this.m_splitterListe.Location = new System.Drawing.Point(0, 28);
            this.m_splitterListe.Name = "m_splitterListe";
            this.m_splitterListe.Size = new System.Drawing.Size(377, 3);
            this.m_splitterListe.TabIndex = 1;
            this.m_splitterListe.TabStop = false;
            // 
            // m_mibTree
            // 
            this.m_mibTree.ContextMenuStrip = this.m_menuArbre;
            this.m_mibTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_mibTree.HideSelection = false;
            this.m_mibTree.ImageIndex = 0;
            this.m_mibTree.Location = new System.Drawing.Point(0, 0);
            this.m_mibTree.Name = "m_mibTree";
            this.m_mibTree.SelectedImageIndex = 0;
            this.m_mibTree.Size = new System.Drawing.Size(377, 31);
            this.m_mibTree.TabIndex = 0;
            this.m_mibTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_mibTree_AfterSelect);
            this.m_mibTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.m_mibTree_NodeMouseClick);
            // 
            // m_menuArbre
            // 
            this.m_menuArbre.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_menuParcourir,
            this.toolStripMenuItem1,
            this.m_menuGetFromArbre,
            this.m_menuWalk,
            this.m_mnuVoirTable});
            this.m_menuArbre.Name = "m_menuArbre";
            this.m_menuArbre.Size = new System.Drawing.Size(182, 98);
            this.m_menuArbre.Text = "Browse|20022";
            this.m_menuArbre.Opening += new System.ComponentModel.CancelEventHandler(this.m_menuArbre_Opening);
            // 
            // m_menuParcourir
            // 
            this.m_menuParcourir.Name = "m_menuParcourir";
            this.m_menuParcourir.Size = new System.Drawing.Size(181, 22);
            this.m_menuParcourir.Text = "List elements|20022";
            this.m_menuParcourir.Click += new System.EventHandler(this.m_menuParcourir_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(178, 6);
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // m_menuGetFromArbre
            // 
            this.m_menuGetFromArbre.Name = "m_menuGetFromArbre";
            this.m_menuGetFromArbre.Size = new System.Drawing.Size(181, 22);
            this.m_menuGetFromArbre.Text = "Get";
            this.m_menuGetFromArbre.Click += new System.EventHandler(this.m_menuGetFromArbre_Click);
            // 
            // m_menuWalk
            // 
            this.m_menuWalk.Name = "m_menuWalk";
            this.m_menuWalk.Size = new System.Drawing.Size(181, 22);
            this.m_menuWalk.Text = "Walk";
            this.m_menuWalk.Click += new System.EventHandler(this.m_menuWalk_Click);
            // 
            // m_mnuVoirTable
            // 
            this.m_mnuVoirTable.Name = "m_mnuVoirTable";
            this.m_mnuVoirTable.Size = new System.Drawing.Size(181, 22);
            this.m_mnuVoirTable.Text = "See table|20044";
            this.m_mnuVoirTable.Click += new System.EventHandler(this.m_mnuVoirTable_Click);
            // 
            // m_slideListe
            // 
            this.m_slideListe.AllowDrop = true;
            this.m_slideListe.Controls.Add(this.m_wndListe);
            this.m_slideListe.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_slideListe.ExtendedSize = 250;
            this.m_slideListe.IsCollapse = false;
            this.m_slideListe.Location = new System.Drawing.Point(0, 31);
            this.m_slideListe.LockEdition = false;
            this.m_slideListe.Name = "m_slideListe";
            this.m_slideListe.Size = new System.Drawing.Size(377, 257);
            this.m_slideListe.TabIndex = 0;
            this.m_slideListe.TitleAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_slideListe.TitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(255)))));
            this.m_slideListe.TitleBackColorGradient = System.Drawing.Color.White;
            this.m_slideListe.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_slideListe.TitleHeight = 18;
            this.m_slideListe.TitleText = "List|20023";
            this.m_slideListe.OnCollapseChange += new System.EventHandler(this.m_slideListe_OnCollapseChange);
            // 
            // m_wndListe
            // 
            this.m_wndListe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListe.Location = new System.Drawing.Point(0, 18);
            this.m_wndListe.MibNavigator = null;
            this.m_wndListe.Name = "m_wndListe";
            this.m_wndListe.Size = new System.Drawing.Size(377, 239);
            this.m_wndListe.TabIndex = 1;
            this.m_wndListe.Load += new System.EventHandler(this.m_wndListe_Load);
            // 
            // CWndMibBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_panelDroite);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.m_panelLeft);
            this.Name = "CWndMibBrowser";
            this.Size = new System.Drawing.Size(543, 288);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelDroite.ResumeLayout(false);
            this.m_panelLeft.ResumeLayout(false);
            this.m_menuArbre.ResumeLayout(false);
            this.m_slideListe.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SnmpTest.CMibTree m_mibTree;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel m_panelViewer;
        private System.Windows.Forms.Panel m_panelNavigation;
        private System.Windows.Forms.Button m_boutonPrevious;
        private System.Windows.Forms.Panel m_panelDroite;
        private System.Windows.Forms.Button m_boutonNext;
        private System.Windows.Forms.Panel m_panelLeft;
        private CMibList m_wndListe;
        private System.Windows.Forms.ContextMenuStrip m_menuArbre;
        private System.Windows.Forms.ToolStripMenuItem m_menuParcourir;
        private sc2i.win32.common.CSlidingZone m_slideListe;
        private System.Windows.Forms.Splitter m_splitterListe;
        private System.Windows.Forms.Label m_lblType;
        private System.Windows.Forms.Button m_btnParametres;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem m_menuGetFromArbre;
        private System.Windows.Forms.ToolStripMenuItem m_menuWalk;
        private System.Windows.Forms.ToolStripMenuItem m_mnuVoirTable;
    }
}
