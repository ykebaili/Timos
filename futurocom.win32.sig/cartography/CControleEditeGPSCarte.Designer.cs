namespace futurocom.win32.sig.cartography
{
    partial class CControleEditeGPSCarte
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

                if (m_curseurCreateLine != null)
                    m_curseurCreateLine.Dispose();
                m_curseurCreateLine = null;

                if (m_curseurCreatePoint != null)
                    m_curseurCreatePoint.Dispose();
                m_curseurCreatePoint = null;
                
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CControleEditeGPSCarte));
            this.m_wndMap = new sc2i.win32.common.CVEarthCtrl();
            this.m_panelDroite = new System.Windows.Forms.Panel();
            this.m_arbreCartographie = new System.Windows.Forms.TreeView();
            this.m_imagesArbre = new System.Windows.Forms.ImageList(this.components);
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.m_panelPropriétés = new sc2i.win32.common.C2iPanel(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_menuItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_menuDeleteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuAddAPoint = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuDeletePoint = new System.Windows.Forms.ToolStripMenuItem();
            this.m_btnAjoutLigne = new System.Windows.Forms.RadioButton();
            this.m_btnAjoutPoint = new System.Windows.Forms.RadioButton();
            this.m_btnModeSouris = new System.Windows.Forms.RadioButton();
            this.m_btnPhoto = new System.Windows.Forms.Button();
            this.m_panelDroite.SuspendLayout();
            this.panel1.SuspendLayout();
            this.m_menuItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_wndMap
            // 
            this.m_wndMap.CaptureOnMapWindow = false;
            this.m_wndMap.CenterLatitude = 0D;
            this.m_wndMap.CenterLongitude = 0D;
            this.m_wndMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndMap.Location = new System.Drawing.Point(0, 0);
            this.m_wndMap.MapStyle = sc2i.win32.common.EMapStyle.Road;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndMap, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_wndMap.Name = "m_wndMap";
            this.m_wndMap.ShowMarkerOnClick = false;
            this.m_wndMap.Size = new System.Drawing.Size(567, 466);
            this.m_wndMap.TabIndex = 0;
            this.m_wndMap.Zoom = 10D;
            this.m_wndMap.OnEarthMouseUp += new sc2i.win32.common.EarthMouseEventHandler(this.m_wndMap_OnEarthMouseUp);
            this.m_wndMap.OnEarthMouseDown += new sc2i.win32.common.EarthMouseEventHandler(this.m_wndMap_OnEarthMouseDown);
            this.m_wndMap.OnEarthMouseMove += new sc2i.win32.common.EarthMouseEventHandler(this.m_wndMap_OnEarthMouseMove);
            this.m_wndMap.MapItemClicked += new sc2i.win32.common.MapItemClickEventHandler(this.m_wndMap_MapItemClicked);
            // 
            // m_panelDroite
            // 
            this.m_panelDroite.Controls.Add(this.m_arbreCartographie);
            this.m_panelDroite.Controls.Add(this.splitter2);
            this.m_panelDroite.Controls.Add(this.m_panelPropriétés);
            this.m_panelDroite.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_panelDroite.Location = new System.Drawing.Point(570, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelDroite, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelDroite.Name = "m_panelDroite";
            this.m_panelDroite.Size = new System.Drawing.Size(234, 466);
            this.m_panelDroite.TabIndex = 1;
            // 
            // m_arbreCartographie
            // 
            this.m_arbreCartographie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_arbreCartographie.HideSelection = false;
            this.m_arbreCartographie.ImageIndex = 0;
            this.m_arbreCartographie.ImageList = this.m_imagesArbre;
            this.m_arbreCartographie.LabelEdit = true;
            this.m_arbreCartographie.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_arbreCartographie, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_arbreCartographie.Name = "m_arbreCartographie";
            this.m_arbreCartographie.SelectedImageIndex = 0;
            this.m_arbreCartographie.Size = new System.Drawing.Size(234, 270);
            this.m_arbreCartographie.TabIndex = 0;
            this.m_arbreCartographie.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.m_arbreCartographie_BeforeLabelEdit);
            this.m_arbreCartographie.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.m_arbreCartographie_AfterLabelEdit);
            this.m_arbreCartographie.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.m_arbreCartographie_BeforeSelect);
            // 
            // m_imagesArbre
            // 
            this.m_imagesArbre.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imagesArbre.ImageStream")));
            this.m_imagesArbre.TransparentColor = System.Drawing.Color.Transparent;
            this.m_imagesArbre.Images.SetKeyName(0, "IconeCartex16.png");
            this.m_imagesArbre.Images.SetKeyName(1, "IconePointx16.png");
            this.m_imagesArbre.Images.SetKeyName(2, "iconLine.png");
            this.m_imagesArbre.Images.SetKeyName(3, "iconSegment.png");
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Location = new System.Drawing.Point(0, 270);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitter2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(234, 3);
            this.splitter2.TabIndex = 1;
            this.splitter2.TabStop = false;
            // 
            // m_panelPropriétés
            // 
            this.m_panelPropriétés.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_panelPropriétés.Location = new System.Drawing.Point(0, 273);
            this.m_panelPropriétés.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelPropriétés, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelPropriétés.Name = "m_panelPropriétés";
            this.m_panelPropriétés.Size = new System.Drawing.Size(234, 193);
            this.m_panelPropriétés.TabIndex = 2;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(567, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitter1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 466);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // m_gestionnaireModeEdition
            // 
            this.m_gestionnaireModeEdition.ModeEdition = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_btnPhoto);
            this.panel1.Controls.Add(this.m_btnAjoutLigne);
            this.panel1.Controls.Add(this.m_btnAjoutPoint);
            this.panel1.Controls.Add(this.m_btnModeSouris);
            this.panel1.Location = new System.Drawing.Point(175, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(326, 30);
            this.panel1.TabIndex = 3;
            // 
            // m_menuItem
            // 
            this.m_menuItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_menuDeleteItem,
            this.m_menuAddAPoint,
            this.m_menuDeletePoint});
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_menuItem, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_menuItem.Name = "m_menuItem";
            this.m_menuItem.Size = new System.Drawing.Size(172, 70);
            this.m_menuItem.Opening += new System.ComponentModel.CancelEventHandler(this.m_menuItem_Opening);
            // 
            // m_menuDeleteItem
            // 
            this.m_menuDeleteItem.Name = "m_menuDeleteItem";
            this.m_menuDeleteItem.Size = new System.Drawing.Size(171, 22);
            this.m_menuDeleteItem.Text = "Delete item|20054";
            this.m_menuDeleteItem.Click += new System.EventHandler(this.m_menuDeleteItem_Click);
            // 
            // m_menuAddAPoint
            // 
            this.m_menuAddAPoint.Name = "m_menuAddAPoint";
            this.m_menuAddAPoint.Size = new System.Drawing.Size(171, 22);
            this.m_menuAddAPoint.Text = "Add point|20063";
            this.m_menuAddAPoint.Click += new System.EventHandler(this.m_menuAddAPoint_Click);
            // 
            // m_menuDeletePoint
            // 
            this.m_menuDeletePoint.Name = "m_menuDeletePoint";
            this.m_menuDeletePoint.Size = new System.Drawing.Size(171, 22);
            this.m_menuDeletePoint.Text = "Delete point|20064";
            this.m_menuDeletePoint.Click += new System.EventHandler(this.m_menuDeletePoint_Click);
            // 
            // m_btnAjoutLigne
            // 
            this.m_btnAjoutLigne.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_btnAjoutLigne.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnAjoutLigne.Image = global::futurocom.win32.sig.Resource.IconAddLine;
            this.m_btnAjoutLigne.Location = new System.Drawing.Point(64, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAjoutLigne, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnAjoutLigne.Name = "m_btnAjoutLigne";
            this.m_btnAjoutLigne.Size = new System.Drawing.Size(32, 30);
            this.m_btnAjoutLigne.TabIndex = 1;
            this.m_btnAjoutLigne.TabStop = true;
            this.m_btnAjoutLigne.UseVisualStyleBackColor = true;
            this.m_btnAjoutLigne.CheckedChanged += new System.EventHandler(this.m_btnAjoutLigne_CheckedChanged);
            // 
            // m_btnAjoutPoint
            // 
            this.m_btnAjoutPoint.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_btnAjoutPoint.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnAjoutPoint.Image = global::futurocom.win32.sig.Resource.IconeAddPointx16;
            this.m_btnAjoutPoint.Location = new System.Drawing.Point(32, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAjoutPoint, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnAjoutPoint.Name = "m_btnAjoutPoint";
            this.m_btnAjoutPoint.Size = new System.Drawing.Size(32, 30);
            this.m_btnAjoutPoint.TabIndex = 0;
            this.m_btnAjoutPoint.TabStop = true;
            this.m_btnAjoutPoint.UseVisualStyleBackColor = true;
            this.m_btnAjoutPoint.CheckedChanged += new System.EventHandler(this.m_btnAjoutPoint_CheckedChanged);
            // 
            // m_btnModeSouris
            // 
            this.m_btnModeSouris.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_btnModeSouris.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnModeSouris.Image = global::futurocom.win32.sig.Resource.icon_souris;
            this.m_btnModeSouris.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnModeSouris, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnModeSouris.Name = "m_btnModeSouris";
            this.m_btnModeSouris.Size = new System.Drawing.Size(32, 30);
            this.m_btnModeSouris.TabIndex = 2;
            this.m_btnModeSouris.TabStop = true;
            this.m_btnModeSouris.UseVisualStyleBackColor = true;
            this.m_btnModeSouris.CheckedChanged += new System.EventHandler(this.m_btnModeSouris_CheckedChanged);
            // 
            // m_btnPhoto
            // 
            this.m_btnPhoto.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnPhoto.Image = global::futurocom.win32.sig.Resource.AppareilPhoto;
            this.m_btnPhoto.Location = new System.Drawing.Point(292, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnPhoto, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnPhoto.Name = "m_btnPhoto";
            this.m_btnPhoto.Size = new System.Drawing.Size(34, 30);
            this.m_btnPhoto.TabIndex = 3;
            this.m_btnPhoto.UseVisualStyleBackColor = true;
            this.m_btnPhoto.Click += new System.EventHandler(this.m_btnPhoto_Click);
            // 
            // CControleEditeGPSCarte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_wndMap);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.m_panelDroite);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleEditeGPSCarte";
            this.Size = new System.Drawing.Size(804, 466);
            this.m_panelDroite.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.m_menuItem.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.CVEarthCtrl m_wndMap;
        private System.Windows.Forms.Panel m_panelDroite;
        private System.Windows.Forms.Splitter splitter1;
        private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
        private System.Windows.Forms.TreeView m_arbreCartographie;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.ImageList m_imagesArbre;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton m_btnAjoutPoint;
        private System.Windows.Forms.RadioButton m_btnAjoutLigne;
        private System.Windows.Forms.RadioButton m_btnModeSouris;
        private sc2i.win32.common.C2iPanel m_panelPropriétés;
        private System.Windows.Forms.ContextMenuStrip m_menuItem;
        private System.Windows.Forms.ToolStripMenuItem m_menuDeleteItem;
        private System.Windows.Forms.ToolStripMenuItem m_menuAddAPoint;
        private System.Windows.Forms.ToolStripMenuItem m_menuDeletePoint;
        private System.Windows.Forms.Button m_btnPhoto;
    }
}
