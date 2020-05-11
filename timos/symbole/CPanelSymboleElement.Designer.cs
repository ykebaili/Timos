namespace timos
{
    partial class CPanelSymboleElement
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
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_radioSymboleType = new System.Windows.Forms.RadioButton();
            this.m_cmbSymboleBib = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_radioSymboleBib = new System.Windows.Forms.RadioButton();
            this.m_linkEditSymbole = new sc2i.win32.common.C2iLink(this.components);
            this.m_radioSymbolePropre = new System.Windows.Forms.RadioButton();
            this.m_controleDessin = new timos.CControlDessinSymbole();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m_radioSymboleType);
            this.splitContainer1.Panel1.Controls.Add(this.m_cmbSymboleBib);
            this.splitContainer1.Panel1.Controls.Add(this.m_radioSymboleBib);
            this.splitContainer1.Panel1.Controls.Add(this.m_linkEditSymbole);
            this.splitContainer1.Panel1.Controls.Add(this.m_radioSymbolePropre);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1.Panel1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_controleDessin);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1.Panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.splitContainer1.Size = new System.Drawing.Size(621, 155);
            this.splitContainer1.SplitterDistance = 449;
            this.splitContainer1.TabIndex = 4029;
            // 
            // m_radioSymboleType
            // 
            this.m_radioSymboleType.AutoSize = true;
            this.m_radioSymboleType.Location = new System.Drawing.Point(14, 84);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_radioSymboleType, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_radioSymboleType.Name = "m_radioSymboleType";
            this.m_radioSymboleType.Size = new System.Drawing.Size(118, 17);
            this.m_radioSymboleType.TabIndex = 4032;
            this.m_radioSymboleType.TabStop = true;
            this.m_radioSymboleType.Text = "Type Symbol|30037";
            this.m_radioSymboleType.UseVisualStyleBackColor = true;
            this.m_radioSymboleType.CheckedChanged += new System.EventHandler(this.m_radioSymboleType_CheckedChanged_1);
            // 
            // m_cmbSymboleBib
            // 
            this.m_cmbSymboleBib.ElementSelectionne = null;
            this.m_cmbSymboleBib.FonctionTextNull = null;
            this.m_cmbSymboleBib.HasLink = true;
            this.m_cmbSymboleBib.Location = new System.Drawing.Point(165, 12);
            this.m_cmbSymboleBib.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbSymboleBib, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbSymboleBib.Name = "m_cmbSymboleBib";
            this.m_cmbSymboleBib.SelectedObject = null;
            this.m_cmbSymboleBib.Size = new System.Drawing.Size(232, 21);
            this.m_cmbSymboleBib.TabIndex = 4031;
            this.m_cmbSymboleBib.TextNull = "";
            this.m_cmbSymboleBib.ElementSelectionneChanged += new System.EventHandler(this.m_cmbSymboleBib_ElementSelectionneChanged_1);
            // 
            // m_radioSymboleBib
            // 
            this.m_radioSymboleBib.AutoSize = true;
            this.m_radioSymboleBib.Location = new System.Drawing.Point(14, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_radioSymboleBib, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_radioSymboleBib.Name = "m_radioSymboleBib";
            this.m_radioSymboleBib.Size = new System.Drawing.Size(125, 17);
            this.m_radioSymboleBib.TabIndex = 4028;
            this.m_radioSymboleBib.TabStop = true;
            this.m_radioSymboleBib.Text = "Library Symbol|30025";
            this.m_radioSymboleBib.UseVisualStyleBackColor = true;
            this.m_radioSymboleBib.CheckedChanged += new System.EventHandler(this.m_radioSymboleBib_CheckedChanged_1);
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
            this.m_linkEditSymbole.Location = new System.Drawing.Point(165, 49);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_linkEditSymbole, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_linkEditSymbole.Name = "m_linkEditSymbole";
            this.m_linkEditSymbole.Size = new System.Drawing.Size(125, 13);
            this.m_linkEditSymbole.TabIndex = 4030;
            this.m_linkEditSymbole.TabStop = true;
            this.m_linkEditSymbole.Text = "Edit proper symbol|30342";
            this.m_linkEditSymbole.LinkClicked += new System.EventHandler(this.m_linkEditSymbole_LinkClicked_1);
            // 
            // m_radioSymbolePropre
            // 
            this.m_radioSymbolePropre.AutoSize = true;
            this.m_radioSymbolePropre.Location = new System.Drawing.Point(14, 49);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_radioSymbolePropre, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_radioSymbolePropre.Name = "m_radioSymbolePropre";
            this.m_radioSymbolePropre.Size = new System.Drawing.Size(125, 17);
            this.m_radioSymbolePropre.TabIndex = 4029;
            this.m_radioSymbolePropre.TabStop = true;
            this.m_radioSymbolePropre.Text = "Proper Symbol|30034";
            this.m_radioSymbolePropre.UseVisualStyleBackColor = true;
            this.m_radioSymbolePropre.CheckedChanged += new System.EventHandler(this.m_radioSymbolePropre_CheckedChanged_1);
            // 
            // m_controleDessin
            // 
            this.m_controleDessin.AutoScroll = true;
            this.m_controleDessin.BackColor = System.Drawing.Color.White;
            this.m_controleDessin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_controleDessin.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_controleDessin, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_controleDessin.Name = "m_controleDessin";
            this.m_controleDessin.Size = new System.Drawing.Size(165, 152);
            this.m_controleDessin.TabIndex = 4029;
            // 
            // CPanelSymboleElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.splitContainer1);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CPanelSymboleElement";
            this.Size = new System.Drawing.Size(627, 161);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RadioButton m_radioSymboleType;
        private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_cmbSymboleBib;
        private System.Windows.Forms.RadioButton m_radioSymboleBib;
        private sc2i.win32.common.C2iLink m_linkEditSymbole;
        private System.Windows.Forms.RadioButton m_radioSymbolePropre;
        private CControlDessinSymbole m_controleDessin;
    }
}
