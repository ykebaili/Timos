namespace spv.win32
{
    partial class CExtendeurFormSchemaReseau
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
            this.components = new System.ComponentModel.Container();
            this.m_panelService = new sc2i.win32.common.C2iPanel(this.components);
            this.m_cmbClient = new sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide();
            this.label1 = new System.Windows.Forms.Label();
            this.m_lnkSuperviser = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_btnTestArbre = new System.Windows.Forms.Button();
            this.m_lnkHistoriqueEvenements = new System.Windows.Forms.LinkLabel();
            this.m_panelService.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelService
            // 
            this.m_panelService.Controls.Add(this.m_cmbClient);
            this.m_panelService.Controls.Add(this.label1);
            this.m_panelService.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.m_panelService, "");
            this.m_panelService.Location = new System.Drawing.Point(0, 64);
            this.m_panelService.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_panelService, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelService.Name = "m_panelService";
            this.m_panelService.Size = new System.Drawing.Size(504, 100);
            this.m_extStyle.SetStyleBackColor(this.m_panelService, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelService, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelService.TabIndex = 0;
            // 
            // m_cmbClient
            // 
            this.m_cmbClient.ElementSelectionne = null;
            this.m_extLinkField.SetLinkField(this.m_cmbClient, "");
            this.m_cmbClient.Location = new System.Drawing.Point(109, 3);
            this.m_cmbClient.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_cmbClient, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_cmbClient.Name = "m_cmbClient";
            this.m_cmbClient.SelectedObject = null;
            this.m_cmbClient.Size = new System.Drawing.Size(334, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbClient, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbClient, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbClient.TabIndex = 1;
            // 
            // label1
            // 
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.label1.Location = new System.Drawing.Point(10, 6);
            this.m_extModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 23);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer|20005";
            // 
            // m_lnkSuperviser
            // 
            this.m_lnkSuperviser.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lnkSuperviser, "");
            this.m_lnkSuperviser.Location = new System.Drawing.Point(10, 12);
            this.m_extModeEdition.SetModeEdition(this.m_lnkSuperviser, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_lnkSuperviser.Name = "m_lnkSuperviser";
            this.m_lnkSuperviser.Size = new System.Drawing.Size(161, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSuperviser, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSuperviser, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSuperviser.TabIndex = 2;
            this.m_lnkSuperviser.TabStop = true;
            this.m_lnkSuperviser.Text = "Show supervision window|20015";
            this.m_lnkSuperviser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkSuperviser_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_btnTestArbre);
            this.panel1.Controls.Add(this.m_lnkHistoriqueEvenements);
            this.panel1.Controls.Add(this.m_lnkSuperviser);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.panel1, "");
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(504, 64);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 3;
            // 
            // m_btnTestArbre
            // 
            this.m_extLinkField.SetLinkField(this.m_btnTestArbre, "");
            this.m_btnTestArbre.Location = new System.Drawing.Point(382, 12);
            this.m_extModeEdition.SetModeEdition(this.m_btnTestArbre, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnTestArbre.Name = "m_btnTestArbre";
            this.m_btnTestArbre.Size = new System.Drawing.Size(75, 23);
            this.m_extStyle.SetStyleBackColor(this.m_btnTestArbre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnTestArbre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnTestArbre.TabIndex = 4;
            this.m_btnTestArbre.Text = "test arbre";
            this.m_btnTestArbre.UseVisualStyleBackColor = true;
            this.m_btnTestArbre.Visible = false;
            this.m_btnTestArbre.Click += new System.EventHandler(this.m_btnTestArbre_Click);
            // 
            // m_lnkHistoriqueEvenements
            // 
            this.m_lnkHistoriqueEvenements.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lnkHistoriqueEvenements, "");
            this.m_lnkHistoriqueEvenements.Location = new System.Drawing.Point(10, 34);
            this.m_extModeEdition.SetModeEdition(this.m_lnkHistoriqueEvenements, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_lnkHistoriqueEvenements.Name = "m_lnkHistoriqueEvenements";
            this.m_lnkHistoriqueEvenements.Size = new System.Drawing.Size(129, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkHistoriqueEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkHistoriqueEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkHistoriqueEvenements.TabIndex = 3;
            this.m_lnkHistoriqueEvenements.TabStop = true;
            this.m_lnkHistoriqueEvenements.Text = "Show event history|20024";
            this.m_lnkHistoriqueEvenements.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkHistoriqueEvenements_LinkClicked);
            // 
            // CExtendeurFormSchemaReseau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.m_panelService);
            this.Controls.Add(this.panel1);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CExtendeurFormSchemaReseau";
            this.Size = new System.Drawing.Size(504, 358);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.OnChangementSurObjet += new sc2i.win32.data.navigation.EventOnChangementDonnee(this.CExtendeurFormSchemaReseau_OnChangementSurObjet);
            this.m_panelService.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.C2iPanel m_panelService;
        private System.Windows.Forms.Label label1;
        private sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide m_cmbClient;
        private System.Windows.Forms.LinkLabel m_lnkSuperviser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel m_lnkHistoriqueEvenements;
        private System.Windows.Forms.Button m_btnTestArbre;



    }
}
