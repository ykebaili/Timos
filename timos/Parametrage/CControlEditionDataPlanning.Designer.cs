namespace timos
{
    partial class CControlEditionDataPlanning
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
            this.m_panel1 = new sc2i.win32.common.C2iPanel(this.components);
            this.m_txtSelectElement = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_toolTipTraductible = new sc2i.win32.common.CToolTipTraductible(this.components);
            this.m_panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panel1
            // 
            this.m_panel1.Controls.Add(this.m_txtSelectElement);
            this.m_panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panel1.Location = new System.Drawing.Point(0, 0);
            this.m_panel1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panel1.Name = "m_panel1";
            this.m_panel1.Size = new System.Drawing.Size(191, 24);
            this.m_panel1.TabIndex = 0;
            // 
            // m_txtSelectElement
            // 
            this.m_txtSelectElement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtSelectElement.ElementSelectionne = null;
            this.m_txtSelectElement.FonctionTextNull = null;
            this.m_txtSelectElement.HasLink = true;
            this.m_txtSelectElement.Location = new System.Drawing.Point(0, 0);
            this.m_txtSelectElement.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectElement, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtSelectElement.Name = "m_txtSelectElement";
            this.m_txtSelectElement.SelectedObject = null;
            this.m_txtSelectElement.Size = new System.Drawing.Size(190, 22);
            this.m_txtSelectElement.TabIndex = 0;
            this.m_txtSelectElement.TextNull = "";
            this.m_txtSelectElement.ElementSelectionneChanged += new System.EventHandler(this.m_selectElement_ElementSelectionneChanged);
            // 
            // CControlEditionDataPlanning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_panel1);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControlEditionDataPlanning";
            this.Size = new System.Drawing.Size(191, 24);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CControlEditionDataPlanning_KeyPress);
            this.m_panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
        private sc2i.win32.common.CToolTipTraductible m_toolTipTraductible;
        private sc2i.win32.common.C2iPanel m_panel1;
        private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_txtSelectElement;
    }
}
