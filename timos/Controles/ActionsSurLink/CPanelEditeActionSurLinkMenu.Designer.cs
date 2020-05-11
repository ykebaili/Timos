namespace timos.Controles.ActionsSurLink
{
    partial class CPanelEditeActionSurLinkMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPanelEditeActionSurLinkMenu));
            this.m_wndListeMenuItems = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn2 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.m_panelDetailsItem = new System.Windows.Forms.Panel();
            this.m_panelAddRemove = new System.Windows.Forms.Panel();
            this.m_lnkRemoveMenuItem = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkAddMenuItem = new sc2i.win32.common.CWndLinkStd();
            this.m_splitContainer = new System.Windows.Forms.SplitContainer();
            this.m_panelAddRemove.SuspendLayout();
            this.m_splitContainer.Panel1.SuspendLayout();
            this.m_splitContainer.Panel2.SuspendLayout();
            this.m_splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_wndListeMenuItems
            // 
            this.m_wndListeMenuItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn1,
            this.listViewAutoFilledColumn2});
            this.m_wndListeMenuItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeMenuItems.EnableCustomisation = true;
            this.m_wndListeMenuItems.FullRowSelect = true;
            this.m_wndListeMenuItems.Location = new System.Drawing.Point(0, 44);
            this.m_wndListeMenuItems.MultiSelect = false;
            this.m_wndListeMenuItems.Name = "m_wndListeMenuItems";
            this.m_wndListeMenuItems.Size = new System.Drawing.Size(236, 258);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeMenuItems, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeMenuItems, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeMenuItems.TabIndex = 1;
            this.m_wndListeMenuItems.UseCompatibleStateImageBehavior = false;
            this.m_wndListeMenuItems.View = System.Windows.Forms.View.Details;
            this.m_wndListeMenuItems.SelectedIndexChanged += new System.EventHandler(this.m_wndListeMenuItems_SelectedIndexChanged);
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "NumeroOrdre";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Sort Num|10409";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 65;
            // 
            // listViewAutoFilledColumn2
            // 
            this.listViewAutoFilledColumn2.Field = "Libelle";
            this.listViewAutoFilledColumn2.PrecisionWidth = 0;
            this.listViewAutoFilledColumn2.ProportionnalSize = false;
            this.listViewAutoFilledColumn2.Text = "Label|50";
            this.listViewAutoFilledColumn2.Visible = true;
            this.listViewAutoFilledColumn2.Width = 193;
            // 
            // m_panelDetailsItem
            // 
            this.m_panelDetailsItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelDetailsItem.Location = new System.Drawing.Point(0, 0);
            this.m_panelDetailsItem.Name = "m_panelDetailsItem";
            this.m_panelDetailsItem.Size = new System.Drawing.Size(408, 302);
            this.m_extStyle.SetStyleBackColor(this.m_panelDetailsItem, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelDetailsItem, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelDetailsItem.TabIndex = 3;
            // 
            // m_panelAddRemove
            // 
            this.m_panelAddRemove.Controls.Add(this.m_lnkRemoveMenuItem);
            this.m_panelAddRemove.Controls.Add(this.m_lnkAddMenuItem);
            this.m_panelAddRemove.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelAddRemove.Location = new System.Drawing.Point(0, 0);
            this.m_panelAddRemove.Name = "m_panelAddRemove";
            this.m_panelAddRemove.Size = new System.Drawing.Size(236, 44);
            this.m_extStyle.SetStyleBackColor(this.m_panelAddRemove, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelAddRemove, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelAddRemove.TabIndex = 4;
            // 
            // m_lnkRemoveMenuItem
            // 
            this.m_lnkRemoveMenuItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkRemoveMenuItem.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_lnkRemoveMenuItem.CustomImage")));
            this.m_lnkRemoveMenuItem.CustomText = "Remove";
            this.m_lnkRemoveMenuItem.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkRemoveMenuItem.Location = new System.Drawing.Point(110, 14);
            this.m_lnkRemoveMenuItem.Name = "m_lnkRemoveMenuItem";
            this.m_lnkRemoveMenuItem.ShortMode = false;
            this.m_lnkRemoveMenuItem.Size = new System.Drawing.Size(102, 24);
            this.m_extStyle.SetStyleBackColor(this.m_lnkRemoveMenuItem, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkRemoveMenuItem, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkRemoveMenuItem.TabIndex = 0;
            this.m_lnkRemoveMenuItem.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkRemoveMenuItem.LinkClicked += new System.EventHandler(this.m_lnkRemoveMenuItem_LinkClicked);
            // 
            // m_lnkAddMenuItem
            // 
            this.m_lnkAddMenuItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAddMenuItem.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_lnkAddMenuItem.CustomImage")));
            this.m_lnkAddMenuItem.CustomText = "Add";
            this.m_lnkAddMenuItem.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkAddMenuItem.Location = new System.Drawing.Point(3, 14);
            this.m_lnkAddMenuItem.Name = "m_lnkAddMenuItem";
            this.m_lnkAddMenuItem.ShortMode = false;
            this.m_lnkAddMenuItem.Size = new System.Drawing.Size(101, 24);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAddMenuItem, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAddMenuItem, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAddMenuItem.TabIndex = 0;
            this.m_lnkAddMenuItem.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAddMenuItem.LinkClicked += new System.EventHandler(this.m_lnkAddMenuItem_LinkClicked);
            // 
            // m_splitContainer
            // 
            this.m_splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_splitContainer.Location = new System.Drawing.Point(0, 0);
            this.m_splitContainer.Name = "m_splitContainer";
            // 
            // m_splitContainer.Panel1
            // 
            this.m_splitContainer.Panel1.Controls.Add(this.m_wndListeMenuItems);
            this.m_splitContainer.Panel1.Controls.Add(this.m_panelAddRemove);
            this.m_extStyle.SetStyleBackColor(this.m_splitContainer.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainer.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_splitContainer.Panel2
            // 
            this.m_splitContainer.Panel2.Controls.Add(this.m_panelDetailsItem);
            this.m_extStyle.SetStyleBackColor(this.m_splitContainer.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainer.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_splitContainer.Size = new System.Drawing.Size(648, 302);
            this.m_splitContainer.SplitterDistance = 236;
            this.m_extStyle.SetStyleBackColor(this.m_splitContainer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_splitContainer.TabIndex = 5;
            // 
            // CPanelEditeActionSurLinkMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.m_splitContainer);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "CPanelEditeActionSurLinkMenu";
            this.Size = new System.Drawing.Size(648, 302);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelAddRemove.ResumeLayout(false);
            this.m_splitContainer.Panel1.ResumeLayout(false);
            this.m_splitContainer.Panel2.ResumeLayout(false);
            this.m_splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.ListViewAutoFilled m_wndListeMenuItems;
        private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn2;
        private sc2i.win32.common.CExtStyle m_extStyle;
        private System.Windows.Forms.Panel m_panelDetailsItem;
        private System.Windows.Forms.Panel m_panelAddRemove;
        private System.Windows.Forms.SplitContainer m_splitContainer;
        private sc2i.win32.common.CWndLinkStd m_lnkRemoveMenuItem;
        private sc2i.win32.common.CWndLinkStd m_lnkAddMenuItem;
        private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn1;
    }
}
