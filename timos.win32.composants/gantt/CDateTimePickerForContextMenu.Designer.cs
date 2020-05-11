namespace timos.win32.composants
{
    partial class CDateTimePickerForContextMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CDateTimePickerForContextMenu));
            this.m_dtStart = new sc2i.win32.common.C2iDateTimePicker();
            this.m_label1 = new System.Windows.Forms.Label();
            this.m_dtEnd = new sc2i.win32.common.C2iDateTimePicker();
            this.m_label2 = new System.Windows.Forms.Label();
            this.m_btnLinkDates = new System.Windows.Forms.Button();
            this.m_btnValiderModifications = new System.Windows.Forms.Button();
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.SuspendLayout();
            // 
            // m_dtStart
            // 
            this.m_dtStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_dtStart.CustomFormat = "dd/MM/yyyy HH:mm";
            this.m_dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtStart.Location = new System.Drawing.Point(102, 1);
            this.m_dtStart.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_dtStart, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_dtStart.Name = "m_dtStart";
            this.m_dtStart.Size = new System.Drawing.Size(122, 20);
            this.m_dtStart.TabIndex = 3;
            this.m_dtStart.Value = new System.DateTime(2010, 9, 22, 16, 57, 35, 667);
            this.m_dtStart.ValueChanged += new System.EventHandler(this.m_dtStart_OnValueChange);
            // 
            // m_label1
            // 
            this.m_label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_label1.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_label1.Name = "m_label1";
            this.m_label1.Size = new System.Drawing.Size(113, 20);
            this.m_label1.TabIndex = 4;
            this.m_label1.Text = "Start|20009";
            this.m_label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_dtEnd
            // 
            this.m_dtEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_dtEnd.CustomFormat = "dd/MM/yyyy HH:mm";
            this.m_dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtEnd.Location = new System.Drawing.Point(102, 22);
            this.m_dtEnd.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_dtEnd, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_dtEnd.Name = "m_dtEnd";
            this.m_dtEnd.Size = new System.Drawing.Size(122, 20);
            this.m_dtEnd.TabIndex = 5;
            this.m_dtEnd.Value = new System.DateTime(2010, 9, 22, 16, 57, 35, 667);
            this.m_dtEnd.ValueChanged += new System.EventHandler(this.m_dtEnd_ValueChanged);
            // 
            // m_label2
            // 
            this.m_label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_label2.Location = new System.Drawing.Point(0, 20);
            this.m_extModeEdition.SetModeEdition(this.m_label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_label2.Name = "m_label2";
            this.m_label2.Size = new System.Drawing.Size(113, 20);
            this.m_label2.TabIndex = 6;
            this.m_label2.Text = "End|20010";
            this.m_label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_btnLinkDates
            // 
            this.m_btnLinkDates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnLinkDates.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnLinkDates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnLinkDates.Image = global::timos.win32.composants.Properties.Resources.chainefermee;
            this.m_btnLinkDates.Location = new System.Drawing.Point(225, 9);
            this.m_extModeEdition.SetModeEdition(this.m_btnLinkDates, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnLinkDates.Name = "m_btnLinkDates";
            this.m_btnLinkDates.Size = new System.Drawing.Size(13, 23);
            this.m_btnLinkDates.TabIndex = 7;
            this.m_btnLinkDates.UseVisualStyleBackColor = true;
            this.m_btnLinkDates.Click += new System.EventHandler(this.m_btnLinkDates_Click);
            // 
            // m_btnValiderModifications
            // 
            this.m_btnValiderModifications.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnValiderModifications.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnValiderModifications.ForeColor = System.Drawing.Color.White;
            this.m_btnValiderModifications.Image = ((System.Drawing.Image)(resources.GetObject("m_btnValiderModifications.Image")));
            this.m_btnValiderModifications.Location = new System.Drawing.Point(241, 4);
            this.m_extModeEdition.SetModeEdition(this.m_btnValiderModifications, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnValiderModifications.Name = "m_btnValiderModifications";
            this.m_btnValiderModifications.Size = new System.Drawing.Size(32, 32);
            this.m_btnValiderModifications.TabIndex = 8;
            this.m_btnValiderModifications.TabStop = false;
            this.m_btnValiderModifications.Click += new System.EventHandler(this.m_btnValiderModifications_Click);
            // 
            // CDateTimePickerForContextMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_btnValiderModifications);
            this.Controls.Add(this.m_dtEnd);
            this.Controls.Add(this.m_label2);
            this.Controls.Add(this.m_dtStart);
            this.Controls.Add(this.m_label1);
            this.Controls.Add(this.m_btnLinkDates);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CDateTimePickerForContextMenu";
            this.Size = new System.Drawing.Size(276, 43);
            this.Load += new System.EventHandler(this.CDateTimePickerForContextMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.C2iDateTimePicker m_dtStart;
        private System.Windows.Forms.Label m_label1;
        private sc2i.win32.common.C2iDateTimePicker m_dtEnd;
        private System.Windows.Forms.Label m_label2;
        private System.Windows.Forms.Button m_btnLinkDates;
        protected System.Windows.Forms.Button m_btnValiderModifications;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
    }
}
