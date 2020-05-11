namespace timos.interventions
{
    partial class CControleEditePeriodes
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
            this.m_panelInfoSite = new System.Windows.Forms.Panel();
            this.m_gridHistorique = new System.Windows.Forms.DataGridView();
            this.m_lblTypeTicket = new System.Windows.Forms.Label();
            this.m_lblSite = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.m_panelFiltre = new System.Windows.Forms.Panel();
            this.m_dtFiltre = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.m_panelTypeTicketHeader = new System.Windows.Forms.PictureBox();
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_grid = new timos.interventions.CDataGridViewCopyPaste();
            this.m_lnkChangePeriode = new System.Windows.Forms.LinkLabel();
            this.m_panelInfoSite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_gridHistorique)).BeginInit();
            this.m_panelFiltre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_panelTypeTicketHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // m_panelInfoSite
            // 
            this.m_panelInfoSite.Controls.Add(this.m_gridHistorique);
            this.m_panelInfoSite.Controls.Add(this.m_lblTypeTicket);
            this.m_panelInfoSite.Controls.Add(this.m_lblSite);
            this.m_panelInfoSite.Controls.Add(this.label3);
            this.m_panelInfoSite.Controls.Add(this.label2);
            this.m_panelInfoSite.Controls.Add(this.Label12);
            this.m_panelInfoSite.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_panelInfoSite.Location = new System.Drawing.Point(383, 26);
            this.m_extModeEdition.SetModeEdition(this.m_panelInfoSite, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelInfoSite.Name = "m_panelInfoSite";
            this.m_panelInfoSite.Size = new System.Drawing.Size(185, 340);
            this.m_panelInfoSite.TabIndex = 1;
            // 
            // m_gridHistorique
            // 
            this.m_gridHistorique.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_gridHistorique.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_gridHistorique.Location = new System.Drawing.Point(7, 99);
            this.m_extModeEdition.SetModeEdition(this.m_gridHistorique, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_gridHistorique.Name = "m_gridHistorique";
            this.m_gridHistorique.RowHeadersVisible = false;
            this.m_gridHistorique.Size = new System.Drawing.Size(172, 238);
            this.m_gridHistorique.TabIndex = 5;
            this.m_gridHistorique.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_gridHistorique_CellValueChanged);
            // 
            // m_lblTypeTicket
            // 
            this.m_lblTypeTicket.BackColor = System.Drawing.Color.White;
            this.m_lblTypeTicket.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblTypeTicket.Location = new System.Drawing.Point(7, 80);
            this.m_extModeEdition.SetModeEdition(this.m_lblTypeTicket, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblTypeTicket.Name = "m_lblTypeTicket";
            this.m_lblTypeTicket.Size = new System.Drawing.Size(172, 16);
            this.m_lblTypeTicket.TabIndex = 4;
            this.m_lblTypeTicket.Text = "label4";
            this.m_lblTypeTicket.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblSite
            // 
            this.m_lblSite.BackColor = System.Drawing.Color.White;
            this.m_lblSite.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblSite.Location = new System.Drawing.Point(6, 40);
            this.m_extModeEdition.SetModeEdition(this.m_lblSite, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblSite.Name = "m_lblSite";
            this.m_lblSite.Size = new System.Drawing.Size(173, 16);
            this.m_lblSite.TabIndex = 3;
            this.m_lblSite.Text = "label4";
            this.m_lblSite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 64);
            this.m_extModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Type de ticket|20234";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 3);
            this.m_extModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Period history|20232";
            // 
            // Label12
            // 
            this.Label12.Location = new System.Drawing.Point(6, 24);
            this.m_extModeEdition.SetModeEdition(this.Label12, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(104, 16);
            this.Label12.TabIndex = 0;
            this.Label12.Text = "Site|20233";
            this.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_panelFiltre
            // 
            this.m_panelFiltre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.m_panelFiltre.Controls.Add(this.m_lnkChangePeriode);
            this.m_panelFiltre.Controls.Add(this.m_dtFiltre);
            this.m_panelFiltre.Controls.Add(this.label1);
            this.m_panelFiltre.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelFiltre.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelFiltre, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelFiltre.Name = "m_panelFiltre";
            this.m_panelFiltre.Size = new System.Drawing.Size(568, 26);
            this.m_panelFiltre.TabIndex = 3;
            // 
            // m_dtFiltre
            // 
            this.m_dtFiltre.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.m_dtFiltre.Location = new System.Drawing.Point(176, 0);
            this.m_extModeEdition.SetModeEdition(this.m_dtFiltre, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_dtFiltre.Name = "m_dtFiltre";
            this.m_dtFiltre.Size = new System.Drawing.Size(85, 20);
            this.m_dtFiltre.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 3);
            this.m_extModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Show periods for|20232";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_panelTypeTicketHeader
            // 
            this.m_panelTypeTicketHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelTypeTicketHeader.Location = new System.Drawing.Point(0, 26);
            this.m_extModeEdition.SetModeEdition(this.m_panelTypeTicketHeader, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelTypeTicketHeader.Name = "m_panelTypeTicketHeader";
            this.m_panelTypeTicketHeader.Size = new System.Drawing.Size(383, 19);
            this.m_panelTypeTicketHeader.TabIndex = 5;
            this.m_panelTypeTicketHeader.TabStop = false;
            this.m_panelTypeTicketHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.m_panelTypeTicketHeader_Paint);
            // 
            // m_grid
            // 
            this.m_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_grid.Location = new System.Drawing.Point(0, 45);
            this.m_grid.LockEdition = true;
            this.m_extModeEdition.SetModeEdition(this.m_grid, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_grid.Name = "m_grid";
            this.m_grid.ReadOnly = true;
            this.m_grid.Size = new System.Drawing.Size(383, 321);
            this.m_grid.TabIndex = 0;
            this.m_grid.Scroll += new System.Windows.Forms.ScrollEventHandler(this.m_grid_Scroll);
            this.m_grid.CurrentCellChanged += new System.EventHandler(this.m_grid_CurrentCellChanged);
            this.m_grid.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.m_grid_ColumnWidthChanged);
            // 
            // m_lnkChangePeriode
            // 
            this.m_lnkChangePeriode.AutoSize = true;
            this.m_lnkChangePeriode.Location = new System.Drawing.Point(267, 3);
            this.m_extModeEdition.SetModeEdition(this.m_lnkChangePeriode, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lnkChangePeriode.Name = "m_lnkChangePeriode";
            this.m_lnkChangePeriode.Size = new System.Drawing.Size(65, 13);
            this.m_lnkChangePeriode.TabIndex = 2;
            this.m_lnkChangePeriode.TabStop = true;
            this.m_lnkChangePeriode.Text = "Apply|20241";
            this.m_lnkChangePeriode.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkChangePeriode_LinkClicked);
            // 
            // CControleEditePeriodes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_grid);
            this.Controls.Add(this.m_panelTypeTicketHeader);
            this.Controls.Add(this.m_panelInfoSite);
            this.Controls.Add(this.m_panelFiltre);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleEditePeriodes";
            this.Size = new System.Drawing.Size(568, 366);
            this.m_panelInfoSite.ResumeLayout(false);
            this.m_panelInfoSite.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_gridHistorique)).EndInit();
            this.m_panelFiltre.ResumeLayout(false);
            this.m_panelFiltre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_panelTypeTicketHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CDataGridViewCopyPaste m_grid;
        private System.Windows.Forms.Panel m_panelInfoSite;
        private System.Windows.Forms.Label Label12;
        private System.Windows.Forms.Panel m_panelFiltre;
        private System.Windows.Forms.DateTimePicker m_dtFiltre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label m_lblSite;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView m_gridHistorique;
        private System.Windows.Forms.Label m_lblTypeTicket;
        private System.Windows.Forms.PictureBox m_panelTypeTicketHeader;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
        private System.Windows.Forms.LinkLabel m_lnkChangePeriode;
    }
}
