namespace HelpExtender
{
	partial class CFormMenu
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
            this.m_ctrl_editMenu = new HelpExtender.CCtrlEditMenu();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_btnExporter = new System.Windows.Forms.Button();
            this.m_btnFermer = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_ctrl_editMenu
            // 
            this.m_ctrl_editMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_ctrl_editMenu.Location = new System.Drawing.Point(0, 0);
            this.m_ctrl_editMenu.Name = "m_ctrl_editMenu";
            this.m_ctrl_editMenu.Size = new System.Drawing.Size(564, 381);
            this.m_ctrl_editMenu.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_btnExporter);
            this.panel1.Controls.Add(this.m_btnFermer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 381);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(564, 29);
            this.panel1.TabIndex = 2;
            // 
            // m_btnExporter
            // 
            this.m_btnExporter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnExporter.Location = new System.Drawing.Point(486, 3);
            this.m_btnExporter.Name = "m_btnExporter";
            this.m_btnExporter.Size = new System.Drawing.Size(75, 23);
            this.m_btnExporter.TabIndex = 1;
            this.m_btnExporter.Text = "Exporter";
            this.m_btnExporter.UseVisualStyleBackColor = true;
            this.m_btnExporter.Click += new System.EventHandler(this.m_btnExporter_Click);
            // 
            // m_btnFermer
            // 
            this.m_btnFermer.Location = new System.Drawing.Point(245, 4);
            this.m_btnFermer.Name = "m_btnFermer";
            this.m_btnFermer.Size = new System.Drawing.Size(75, 23);
            this.m_btnFermer.TabIndex = 0;
            this.m_btnFermer.Text = "Fermer";
            this.m_btnFermer.UseVisualStyleBackColor = true;
            this.m_btnFermer.Click += new System.EventHandler(this.m_btnFermer_Click);
            // 
            // CFormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(564, 410);
            this.Controls.Add(this.m_ctrl_editMenu);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CFormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Document architecture...|30042";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CFormMenu_FormClosing);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private CCtrlEditMenu m_ctrl_editMenu;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button m_btnFermer;
		private System.Windows.Forms.Button m_btnExporter;
	}
}