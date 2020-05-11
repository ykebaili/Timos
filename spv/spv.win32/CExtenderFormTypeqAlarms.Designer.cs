namespace spv.win32
{
    partial class CExtenderFormTypeqAlarms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CExtenderFormTypeqAlarms));
            sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
            this.m_PanelTypeAccessAlarm = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.SuspendLayout();
            // 
            // m_PanelTypeAccessAlarm
            // 
            this.m_PanelTypeAccessAlarm.AllowArbre = true;
            this.m_PanelTypeAccessAlarm.AllowCustomisation = true;
            this.m_PanelTypeAccessAlarm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
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
            glColumn1.Propriete = "NomAcces";
            glColumn1.Text = "Libelle";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 100;
            glColumn2.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn2.ActiveControlItems")));
            glColumn2.BackColor = System.Drawing.Color.Transparent;
            glColumn2.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn2.ForColor = System.Drawing.Color.Black;
            glColumn2.ImageIndex = -1;
            glColumn2.IsCheckColumn = false;
            glColumn2.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn2.Name = "Type";
            glColumn2.Propriete = "CategorieAccesAlarme.Libelle";
            glColumn2.Text = "Type";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 100;
            this.m_PanelTypeAccessAlarm.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1,
            glColumn2});
            this.m_PanelTypeAccessAlarm.ContexteUtilisation = "";
            this.m_PanelTypeAccessAlarm.ControlFiltreStandard = null;
            this.m_PanelTypeAccessAlarm.ElementSelectionne = null;
            this.m_PanelTypeAccessAlarm.EnableCustomisation = true;
            this.m_PanelTypeAccessAlarm.FiltreDeBase = null;
            this.m_PanelTypeAccessAlarm.FiltreDeBaseEnAjout = false;
            this.m_PanelTypeAccessAlarm.FiltrePrefere = null;
            this.m_PanelTypeAccessAlarm.FiltreRapide = null;
            this.m_PanelTypeAccessAlarm.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_PanelTypeAccessAlarm, "");
            this.m_PanelTypeAccessAlarm.ListeObjets = null;
            this.m_PanelTypeAccessAlarm.Location = new System.Drawing.Point(3, 12);
            this.m_PanelTypeAccessAlarm.LockEdition = true;
            this.m_extModeEdition.SetModeEdition(this.m_PanelTypeAccessAlarm, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_PanelTypeAccessAlarm.ModeQuickSearch = false;
            this.m_PanelTypeAccessAlarm.ModeSelection = true;
            this.m_PanelTypeAccessAlarm.MultiSelect = false;
            this.m_PanelTypeAccessAlarm.Name = "m_PanelTypeAccessAlarm";
            this.m_PanelTypeAccessAlarm.Navigateur = null;
            this.m_PanelTypeAccessAlarm.ProprieteObjetAEditer = null;
            this.m_PanelTypeAccessAlarm.QuickSearchText = "";
            this.m_PanelTypeAccessAlarm.Size = new System.Drawing.Size(807, 378);
            this.m_extStyle.SetStyleBackColor(this.m_PanelTypeAccessAlarm, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_PanelTypeAccessAlarm, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_PanelTypeAccessAlarm.TabIndex = 16;
            this.m_PanelTypeAccessAlarm.TrierAuClicSurEnteteColonne = true;
            // 
            // CExtenderFormTypeqAlarms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.m_PanelTypeAccessAlarm);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CExtenderFormTypeqAlarms";
            this.Size = new System.Drawing.Size(827, 405);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.data.navigation.CPanelListeSpeedStandard m_PanelTypeAccessAlarm;

    }
}
