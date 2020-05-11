namespace timos
{
    partial class CPanelSymboleType
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
            this.m_panelDessin = new sc2i.win32.common.C2iPanel(this.components);
            this.m_labelSymbole = new System.Windows.Forms.Label();
            this.m_cmbSymboleBib = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_linkEditSymbole = new sc2i.win32.common.C2iLink(this.components);
            this.m_radioSymbolePropre = new System.Windows.Forms.RadioButton();
            this.m_radioSymboleBib = new System.Windows.Forms.RadioButton();
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.SuspendLayout();
            // 
            // m_panelDessin
            // 
            this.m_panelDessin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelDessin.Location = new System.Drawing.Point(475, 3);
            this.m_panelDessin.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelDessin, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelDessin.Name = "m_panelDessin";
            this.m_panelDessin.Size = new System.Drawing.Size(155, 153);
            this.m_panelDessin.TabIndex = 4019;
            this.m_panelDessin.Paint += new System.Windows.Forms.PaintEventHandler(this.m_panelDessin_Paint);
            // 
            // m_labelSymbole
            // 
            this.m_labelSymbole.AutoSize = true;
            this.m_labelSymbole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_labelSymbole.Location = new System.Drawing.Point(69, 18);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_labelSymbole, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_labelSymbole.Name = "m_labelSymbole";
            this.m_labelSymbole.Size = new System.Drawing.Size(123, 20);
            this.m_labelSymbole.TabIndex = 4020;
            this.m_labelSymbole.Text = "Symbol|30029";
            // 
            // m_cmbSymboleBib
            // 
            this.m_cmbSymboleBib.ElementSelectionne = null;
            this.m_cmbSymboleBib.FonctionTextNull = null;
            this.m_cmbSymboleBib.HasLink = false;
            this.m_cmbSymboleBib.Location = new System.Drawing.Point(162, 82);
            this.m_cmbSymboleBib.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbSymboleBib, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbSymboleBib.Name = "m_cmbSymboleBib";
            this.m_cmbSymboleBib.SelectedObject = null;
            this.m_cmbSymboleBib.Size = new System.Drawing.Size(294, 21);
            this.m_cmbSymboleBib.TabIndex = 4024;
            this.m_cmbSymboleBib.TextNull = "";
            this.m_cmbSymboleBib.ElementSelectionneChanged += new System.EventHandler(this.m_cmbSymboleBib_ElementSelectionneChanged_1);
            // 
            // m_linkEditSymbole
            // 
            this.m_linkEditSymbole.AutoSize = true;
            this.m_linkEditSymbole.ClickEnabled = true;
            this.m_linkEditSymbole.ColorLabel = System.Drawing.SystemColors.ControlText;
            this.m_linkEditSymbole.ColorLinkDisabled = System.Drawing.Color.Blue;
            this.m_linkEditSymbole.ColorLinkEnabled = System.Drawing.Color.Blue;
            this.m_linkEditSymbole.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_linkEditSymbole.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.m_linkEditSymbole.ForeColor = System.Drawing.Color.Blue;
            this.m_linkEditSymbole.Location = new System.Drawing.Point(193, 121);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_linkEditSymbole, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_linkEditSymbole.Name = "m_linkEditSymbole";
            this.m_linkEditSymbole.Size = new System.Drawing.Size(125, 13);
            this.m_linkEditSymbole.TabIndex = 4023;
            this.m_linkEditSymbole.TabStop = true;
            this.m_linkEditSymbole.Text = "Edit proper symbol|30342";
            this.m_linkEditSymbole.LinkClicked += new System.EventHandler(this.m_linkEditSymbole_LinkClicked);
            // 
            // m_radioSymbolePropre
            // 
            this.m_radioSymbolePropre.AutoSize = true;
            this.m_radioSymbolePropre.Location = new System.Drawing.Point(12, 121);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_radioSymbolePropre, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_radioSymbolePropre.Name = "m_radioSymbolePropre";
            this.m_radioSymbolePropre.Size = new System.Drawing.Size(125, 17);
            this.m_radioSymbolePropre.TabIndex = 4022;
            this.m_radioSymbolePropre.TabStop = true;
            this.m_radioSymbolePropre.Text = "Proper Symbol|30034";
            this.m_radioSymbolePropre.UseVisualStyleBackColor = true;
            this.m_radioSymbolePropre.CheckedChanged += new System.EventHandler(this.m_radioSymbolePropre_CheckedChanged_1);
            // 
            // m_radioSymboleBib
            // 
            this.m_radioSymboleBib.AutoSize = true;
            this.m_radioSymboleBib.Location = new System.Drawing.Point(12, 82);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_radioSymboleBib, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_radioSymboleBib.Name = "m_radioSymboleBib";
            this.m_radioSymboleBib.Size = new System.Drawing.Size(125, 17);
            this.m_radioSymboleBib.TabIndex = 4021;
            this.m_radioSymboleBib.TabStop = true;
            this.m_radioSymboleBib.Text = "Library Symbol|30025";
            this.m_radioSymboleBib.UseVisualStyleBackColor = true;
            this.m_radioSymboleBib.CheckedChanged += new System.EventHandler(this.m_radioSymboleBib_CheckedChanged_1);
            // 
            // CPanelSymboleType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_cmbSymboleBib);
            this.Controls.Add(this.m_linkEditSymbole);
            this.Controls.Add(this.m_radioSymbolePropre);
            this.Controls.Add(this.m_radioSymboleBib);
            this.Controls.Add(this.m_labelSymbole);
            this.Controls.Add(this.m_panelDessin);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CPanelSymboleType";
            this.Size = new System.Drawing.Size(633, 159);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
        private sc2i.win32.common.C2iPanel m_panelDessin;
        private System.Windows.Forms.Label m_labelSymbole;
        private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_cmbSymboleBib;
        private sc2i.win32.common.C2iLink m_linkEditSymbole;
        private System.Windows.Forms.RadioButton m_radioSymbolePropre;
        private System.Windows.Forms.RadioButton m_radioSymboleBib;
    }
}
