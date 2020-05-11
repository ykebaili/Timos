namespace spv.win32
{
    partial class CExtenderFormTypeqSnmpTables
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
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CExtenderFormTypeqSnmpTables));
            this.m_PanelTypeSnmpTables = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.SuspendLayout();
            // 
            // m_PanelTypeSnmpTables
            // 
            this.m_PanelTypeSnmpTables.AllowArbre = true;
            this.m_PanelTypeSnmpTables.AllowCustomisation = true;
            this.m_PanelTypeSnmpTables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "Name";
            glColumn1.Propriete = "Libelle";
            glColumn1.Text = "Libelle";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 100;
            this.m_PanelTypeSnmpTables.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1});
            this.m_PanelTypeSnmpTables.ContexteUtilisation = "";
            this.m_PanelTypeSnmpTables.ControlFiltreStandard = null;
            this.m_PanelTypeSnmpTables.ElementSelectionne = null;
            this.m_PanelTypeSnmpTables.EnableCustomisation = true;
            this.m_PanelTypeSnmpTables.FiltreDeBase = null;
            this.m_PanelTypeSnmpTables.FiltreDeBaseEnAjout = false;
            this.m_PanelTypeSnmpTables.FiltrePrefere = null;
            this.m_PanelTypeSnmpTables.FiltreRapide = null;
            this.m_PanelTypeSnmpTables.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_PanelTypeSnmpTables, "");
            this.m_PanelTypeSnmpTables.ListeObjets = null;
            this.m_PanelTypeSnmpTables.Location = new System.Drawing.Point(3, 12);
            this.m_PanelTypeSnmpTables.LockEdition = true;
            this.m_extModeEdition.SetModeEdition(this.m_PanelTypeSnmpTables, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_PanelTypeSnmpTables.ModeQuickSearch = false;
            this.m_PanelTypeSnmpTables.ModeSelection = false;
            this.m_PanelTypeSnmpTables.MultiSelect = false;
            this.m_PanelTypeSnmpTables.Name = "m_PanelTypeSnmpTables";
            this.m_PanelTypeSnmpTables.Navigateur = null;
            this.m_PanelTypeSnmpTables.ProprieteObjetAEditer = null;
            this.m_PanelTypeSnmpTables.QuickSearchText = "";
            this.m_PanelTypeSnmpTables.Size = new System.Drawing.Size(807, 378);
            this.m_extStyle.SetStyleBackColor(this.m_PanelTypeSnmpTables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_PanelTypeSnmpTables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_PanelTypeSnmpTables.TabIndex = 16;
            this.m_PanelTypeSnmpTables.TrierAuClicSurEnteteColonne = true;
            // 
            // CExtenderFormTypeqSnmpTables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.m_PanelTypeSnmpTables);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CExtenderFormTypeqSnmpTables";
            this.Size = new System.Drawing.Size(827, 405);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.data.navigation.CPanelListeSpeedStandard m_PanelTypeSnmpTables;

    }
}
