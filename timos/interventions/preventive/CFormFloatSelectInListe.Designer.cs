namespace timos.preventives
{
	partial class CFormFloatSelectInListe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormFloatSelectInListe));
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            this.m_panOmbre = new sc2i.win32.common.C2iPanelOmbre();
            this.m_panConteneur = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_panelFiltreEtOutils = new System.Windows.Forms.Panel();
            this.m_panelFiltre = new System.Windows.Forms.Panel();
            this.m_panelFiltreStd = new sc2i.win32.data.navigation.CPanelFiltreFormListStd();
            this.m_panelOutilsFiltre = new System.Windows.Forms.Panel();
            this.m_btnAppliquer = new System.Windows.Forms.Button();
            this.m_btnListeFiltres = new System.Windows.Forms.Button();
            this.m_glst = new sc2i.win32.common.GlacialList();
            this.m_panDown = new System.Windows.Forms.Panel();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_panTop = new System.Windows.Forms.Panel();
            this.m_lnkFiltrer = new sc2i.win32.common.CWndLinkStd();
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.m_menuFiltres = new System.Windows.Forms.ContextMenu();
            this.m_panOmbre.SuspendLayout();
            this.m_panConteneur.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.m_panelFiltreEtOutils.SuspendLayout();
            this.m_panelFiltre.SuspendLayout();
            this.m_panelOutilsFiltre.SuspendLayout();
            this.m_panDown.SuspendLayout();
            this.m_panTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panOmbre
            // 
            this.m_panOmbre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panOmbre.Controls.Add(this.m_panConteneur);
            this.m_panOmbre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panOmbre.ForeColor = System.Drawing.Color.Black;
            this.m_panOmbre.Location = new System.Drawing.Point(0, 0);
            this.m_panOmbre.LockEdition = false;
            this.m_panOmbre.Name = "m_panOmbre";
            this.m_panOmbre.Size = new System.Drawing.Size(469, 412);
            this.m_extStyle.SetStyleBackColor(this.m_panOmbre, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panOmbre, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panOmbre.TabIndex = 2;
            // 
            // m_panConteneur
            // 
            this.m_panConteneur.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panConteneur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panConteneur.Controls.Add(this.splitContainer1);
            this.m_panConteneur.Controls.Add(this.m_panDown);
            this.m_panConteneur.Controls.Add(this.m_panTop);
            this.m_panConteneur.Location = new System.Drawing.Point(0, 0);
            this.m_panConteneur.Name = "m_panConteneur";
            this.m_panConteneur.Size = new System.Drawing.Size(453, 396);
            this.m_extStyle.SetStyleBackColor(this.m_panConteneur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panConteneur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panConteneur.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 19);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m_panelFiltreEtOutils);
            this.m_extStyle.SetStyleBackColor(this.splitContainer1.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer1.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_glst);
            this.m_extStyle.SetStyleBackColor(this.splitContainer1.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer1.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitContainer1.Size = new System.Drawing.Size(451, 347);
            this.splitContainer1.SplitterDistance = 73;
            this.m_extStyle.SetStyleBackColor(this.splitContainer1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitContainer1.TabIndex = 2;
            // 
            // m_panelFiltreEtOutils
            // 
            this.m_panelFiltreEtOutils.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_panelFiltreEtOutils.Controls.Add(this.m_panelFiltre);
            this.m_panelFiltreEtOutils.Controls.Add(this.m_panelOutilsFiltre);
            this.m_panelFiltreEtOutils.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelFiltreEtOutils.Location = new System.Drawing.Point(0, 0);
            this.m_panelFiltreEtOutils.Name = "m_panelFiltreEtOutils";
            this.m_panelFiltreEtOutils.Size = new System.Drawing.Size(451, 73);
            this.m_extStyle.SetStyleBackColor(this.m_panelFiltreEtOutils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelFiltreEtOutils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelFiltreEtOutils.TabIndex = 12;
            this.m_panelFiltreEtOutils.Visible = false;
            // 
            // m_panelFiltre
            // 
            this.m_panelFiltre.AutoScroll = true;
            this.m_panelFiltre.Controls.Add(this.m_panelFiltreStd);
            this.m_panelFiltre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelFiltre.Location = new System.Drawing.Point(32, 0);
            this.m_panelFiltre.Name = "m_panelFiltre";
            this.m_panelFiltre.Size = new System.Drawing.Size(415, 69);
            this.m_extStyle.SetStyleBackColor(this.m_panelFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelFiltre.TabIndex = 4;
            // 
            // m_panelFiltreStd
            // 
            this.m_panelFiltreStd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelFiltreStd.Filtre = null;
            this.m_panelFiltreStd.Location = new System.Drawing.Point(0, 0);
            this.m_panelFiltreStd.Name = "m_panelFiltreStd";
            this.m_panelFiltreStd.Size = new System.Drawing.Size(415, 69);
            this.m_extStyle.SetStyleBackColor(this.m_panelFiltreStd, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelFiltreStd, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelFiltreStd.TabIndex = 1;
            // 
            // m_panelOutilsFiltre
            // 
            this.m_panelOutilsFiltre.Controls.Add(this.m_btnAppliquer);
            this.m_panelOutilsFiltre.Controls.Add(this.m_btnListeFiltres);
            this.m_panelOutilsFiltre.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelOutilsFiltre.Location = new System.Drawing.Point(0, 0);
            this.m_panelOutilsFiltre.Name = "m_panelOutilsFiltre";
            this.m_panelOutilsFiltre.Size = new System.Drawing.Size(32, 69);
            this.m_extStyle.SetStyleBackColor(this.m_panelOutilsFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelOutilsFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelOutilsFiltre.TabIndex = 5;
            // 
            // m_btnAppliquer
            // 
            this.m_btnAppliquer.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_btnAppliquer.Image = ((System.Drawing.Image)(resources.GetObject("m_btnAppliquer.Image")));
            this.m_btnAppliquer.Location = new System.Drawing.Point(0, 28);
            this.m_btnAppliquer.Name = "m_btnAppliquer";
            this.m_btnAppliquer.Size = new System.Drawing.Size(32, 28);
            this.m_extStyle.SetStyleBackColor(this.m_btnAppliquer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAppliquer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAppliquer.TabIndex = 7;
            this.m_btnAppliquer.Click += new System.EventHandler(this.m_btnAppliquer_Click_1);
            // 
            // m_btnListeFiltres
            // 
            this.m_btnListeFiltres.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_btnListeFiltres.Image = ((System.Drawing.Image)(resources.GetObject("m_btnListeFiltres.Image")));
            this.m_btnListeFiltres.Location = new System.Drawing.Point(0, 0);
            this.m_btnListeFiltres.Name = "m_btnListeFiltres";
            this.m_btnListeFiltres.Size = new System.Drawing.Size(32, 28);
            this.m_extStyle.SetStyleBackColor(this.m_btnListeFiltres, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnListeFiltres, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnListeFiltres.TabIndex = 6;
            this.m_btnListeFiltres.Click += new System.EventHandler(this.m_btnListeFiltres_Click);
            // 
            // m_glst
            // 
            this.m_glst.AllowColumnResize = true;
            this.m_glst.AllowMultiselect = false;
            this.m_glst.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.m_glst.AlternatingColors = false;
            this.m_glst.AutoHeight = true;
            this.m_glst.AutoSort = true;
            this.m_glst.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.m_glst.CanChangeActivationCheckBoxes = false;
            this.m_glst.CheckBoxes = false;
            glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "m_colDescription";
            glColumn1.Propriete = "DescriptionElement";
            glColumn1.Text = "Description|41";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 200;
            this.m_glst.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1});
            this.m_glst.ContexteUtilisation = "";
            this.m_glst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_glst.EnableCustomisation = true;
            this.m_glst.FocusedItem = null;
            this.m_glst.FullRowSelect = true;
            this.m_glst.GLGridLines = sc2i.win32.common.GLGridStyles.gridSolid;
            this.m_glst.GridColor = System.Drawing.SystemColors.ControlLight;
            this.m_glst.HeaderHeight = 22;
            this.m_glst.HeaderStyle = sc2i.win32.common.GLHeaderStyles.Normal;
            this.m_glst.HeaderTextColor = System.Drawing.Color.Black;
            this.m_glst.HeaderTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.m_glst.HeaderVisible = true;
            this.m_glst.HeaderWordWrap = false;
            this.m_glst.HotColumnIndex = -1;
            this.m_glst.HotItemIndex = -1;
            this.m_glst.HotTracking = false;
            this.m_glst.HotTrackingColor = System.Drawing.Color.LightGray;
            this.m_glst.ImageList = null;
            this.m_glst.ItemHeight = 17;
            this.m_glst.ItemWordWrap = false;
            this.m_glst.ListeSource = null;
            this.m_glst.Location = new System.Drawing.Point(0, 0);
            this.m_glst.MaxHeight = 17;
            this.m_glst.Name = "m_glst";
            this.m_glst.SelectedTextColor = System.Drawing.Color.White;
            this.m_glst.SelectionColor = System.Drawing.Color.DarkBlue;
            this.m_glst.ShowBorder = true;
            this.m_glst.ShowFocusRect = true;
            this.m_glst.Size = new System.Drawing.Size(451, 270);
            this.m_glst.SortIndex = 0;
            this.m_extStyle.SetStyleBackColor(this.m_glst, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_glst, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_glst.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.m_glst.TabIndex = 1;
            this.m_glst.Text = "glacialList1";
            this.m_glst.TrierAuClicSurEnteteColonne = true;
            this.m_glst.CheckedChange += new sc2i.win32.common.GlacialListCheckedChangeEventHandler(this.m_glst_CheckedChange);
            // 
            // m_panDown
            // 
            this.m_panDown.Controls.Add(this.m_btnCancel);
            this.m_panDown.Controls.Add(this.m_btnOk);
            this.m_panDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_panDown.Location = new System.Drawing.Point(0, 366);
            this.m_panDown.Name = "m_panDown";
            this.m_panDown.Size = new System.Drawing.Size(451, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panDown, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panDown, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panDown.TabIndex = 14;
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnCancel.Location = new System.Drawing.Point(373, 3);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(75, 23);
            this.m_extStyle.SetStyleBackColor(this.m_btnCancel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnCancel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnCancel.TabIndex = 1;
            this.m_btnCancel.Text = "Cancel|11";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // m_btnOk
            // 
            this.m_btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnOk.Location = new System.Drawing.Point(3, 3);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(75, 23);
            this.m_extStyle.SetStyleBackColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnOk.TabIndex = 1;
            this.m_btnOk.Text = "Ok|10";
            this.m_btnOk.UseVisualStyleBackColor = true;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            // 
            // m_panTop
            // 
            this.m_panTop.Controls.Add(this.m_lnkFiltrer);
            this.m_panTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panTop.Location = new System.Drawing.Point(0, 0);
            this.m_panTop.Name = "m_panTop";
            this.m_panTop.Size = new System.Drawing.Size(451, 19);
            this.m_extStyle.SetStyleBackColor(this.m_panTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panTop.TabIndex = 13;
            // 
            // m_lnkFiltrer
            // 
            this.m_lnkFiltrer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkFiltrer.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkFiltrer.Location = new System.Drawing.Point(3, 1);
            this.m_lnkFiltrer.Name = "m_lnkFiltrer";
            this.m_lnkFiltrer.Size = new System.Drawing.Size(59, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkFiltrer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkFiltrer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkFiltrer.TabIndex = 11;
            this.m_lnkFiltrer.TypeLien = sc2i.win32.common.TypeLinkStd.Filtre;
            this.m_lnkFiltrer.LinkClicked += new System.EventHandler(this.m_lnkFiltrer_LinkClicked);
            // 
            // CFormFloatSelectInListe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.m_btnCancel;
            this.ClientSize = new System.Drawing.Size(469, 412);
            this.ControlBox = false;
            this.Controls.Add(this.m_panOmbre);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CFormFloatSelectInListe";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "";
            this.m_panOmbre.ResumeLayout(false);
            this.m_panOmbre.PerformLayout();
            this.m_panConteneur.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.m_panelFiltreEtOutils.ResumeLayout(false);
            this.m_panelFiltre.ResumeLayout(false);
            this.m_panelOutilsFiltre.ResumeLayout(false);
            this.m_panDown.ResumeLayout(false);
            this.m_panTop.ResumeLayout(false);
            this.ResumeLayout(false);

		}

	

		#endregion

		private sc2i.win32.common.C2iPanelOmbre m_panOmbre;
		private System.Windows.Forms.Panel m_panConteneur;
		private sc2i.win32.common.CExtStyle m_extStyle;
		private System.Windows.Forms.Button m_btnCancel;
		private System.Windows.Forms.Button m_btnOk;
		protected sc2i.win32.common.CWndLinkStd m_lnkFiltrer;
		private System.Windows.Forms.Panel m_panDown;
		private System.Windows.Forms.Panel m_panelFiltreEtOutils;
		private System.Windows.Forms.Panel m_panelFiltre;
		private sc2i.win32.data.navigation.CPanelFiltreFormListStd m_panelFiltreStd;
		private System.Windows.Forms.Panel m_panelOutilsFiltre;
		private System.Windows.Forms.Button m_btnAppliquer;
		private System.Windows.Forms.Button m_btnListeFiltres;
		private System.Windows.Forms.Panel m_panTop;
		private System.Windows.Forms.ContextMenu m_menuFiltres;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private sc2i.win32.common.GlacialList m_glst;
	}
}