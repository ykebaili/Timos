namespace timos
{
    partial class CFormTestFiltreFormule
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
            this.components = new System.ComponentModel.Container();
            this.m_panelFiltre = new sc2i.win32.data.dynamic.CPanelEditFiltreDynamique();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_btnTester = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelFiltre
            // 
            this.m_panelFiltre.BackColor = System.Drawing.Color.White;
            this.m_panelFiltre.DefinitionRacineDeChampsFiltres = null;
            this.m_panelFiltre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelFiltre.FiltreDynamique = null;
            this.m_panelFiltre.Location = new System.Drawing.Point(0, 0);
            this.m_panelFiltre.LockEdition = false;
            this.m_panelFiltre.ModeFiltreExpression = false;
            this.m_panelFiltre.ModeSansType = false;
            this.m_panelFiltre.Name = "m_panelFiltre";
            this.m_panelFiltre.Size = new System.Drawing.Size(639, 275);
            this.m_panelFiltre.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_btnTester);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 275);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(639, 100);
            this.panel1.TabIndex = 1;
            // 
            // m_btnTester
            // 
            this.m_btnTester.Location = new System.Drawing.Point(3, 6);
            this.m_btnTester.Name = "m_btnTester";
            this.m_btnTester.Size = new System.Drawing.Size(75, 23);
            this.m_btnTester.TabIndex = 0;
            this.m_btnTester.Text = "Tester";
            this.m_btnTester.UseVisualStyleBackColor = true;
            this.m_btnTester.Click += new System.EventHandler(this.m_btnTester_Click);
            // 
            // CFormTestFiltreFormule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(639, 375);
            this.Controls.Add(this.m_panelFiltre);
            this.Controls.Add(this.panel1);
            this.Name = "CFormTestFiltreFormule";
            this.Text = "CFormTestFiltreFormule";
            this.Load += new System.EventHandler(this.CFormTestFiltreFormule_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.data.dynamic.CPanelEditFiltreDynamique m_panelFiltre;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button m_btnTester;
    }
}