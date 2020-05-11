namespace HelpExtender
{
	partial class CFormEditHelp
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
			this.pan_down = new System.Windows.Forms.Panel();
			this.m_btnAnnuler = new System.Windows.Forms.Button();
			this.m_btnOk = new System.Windows.Forms.Button();
			this.mnu = new System.Windows.Forms.MenuStrip();
			this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.documentIndividuelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ouvrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.supprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.enregistrerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fermerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.langueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stylesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editeur = new HelpExtender.CCtrlEditHelp();
			this.pan_down.SuspendLayout();
			this.mnu.SuspendLayout();
			this.SuspendLayout();
			// 
			// pan_down
			// 
			this.pan_down.Controls.Add(this.m_btnAnnuler);
			this.pan_down.Controls.Add(this.m_btnOk);
			this.pan_down.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pan_down.Location = new System.Drawing.Point(0, 487);
			this.pan_down.Name = "pan_down";
			this.pan_down.Size = new System.Drawing.Size(646, 34);
			this.pan_down.TabIndex = 2;
			// 
			// m_btnAnnuler
			// 
			this.m_btnAnnuler.Location = new System.Drawing.Point(559, 5);
			this.m_btnAnnuler.Name = "m_btnAnnuler";
			this.m_btnAnnuler.Size = new System.Drawing.Size(75, 23);
			this.m_btnAnnuler.TabIndex = 2;
			this.m_btnAnnuler.Text = "Cancel|11";
			this.m_btnAnnuler.UseVisualStyleBackColor = true;
			this.m_btnAnnuler.Click += new System.EventHandler(this.m_btnAnnuler_Click);
			// 
			// m_btnOk
			// 
			this.m_btnOk.Location = new System.Drawing.Point(12, 5);
			this.m_btnOk.Name = "m_btnOk";
			this.m_btnOk.Size = new System.Drawing.Size(75, 23);
			this.m_btnOk.TabIndex = 1;
			this.m_btnOk.Text = "Ok|10";
			this.m_btnOk.UseVisualStyleBackColor = true;
			this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
			// 
			// mnu
			// 
			this.mnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.optionsToolStripMenuItem});
			this.mnu.Location = new System.Drawing.Point(0, 0);
			this.mnu.Name = "mnu";
			this.mnu.Size = new System.Drawing.Size(646, 24);
			this.mnu.TabIndex = 4;
			this.mnu.Text = "menuStrip1";
			// 
			// fichierToolStripMenuItem
			// 
			this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.ouvrirToolStripMenuItem,
            this.toolStripSeparator1,
            this.supprimerToolStripMenuItem,
            this.toolStripSeparator2,
            this.enregistrerToolStripMenuItem,
            this.fermerToolStripMenuItem});
			this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
			this.fichierToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
			this.fichierToolStripMenuItem.Text = "File|30017";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.documentIndividuelToolStripMenuItem});
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(138, 22);
			this.toolStripMenuItem1.Text = "New|30018";
			// 
			// documentIndividuelToolStripMenuItem
			// 
			this.documentIndividuelToolStripMenuItem.Name = "documentIndividuelToolStripMenuItem";
			this.documentIndividuelToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.documentIndividuelToolStripMenuItem.Text = "Individual document|30019";
			this.documentIndividuelToolStripMenuItem.Click += new System.EventHandler(this.documentIndividuelToolStripMenuItem_Click);
			// 
			// ouvrirToolStripMenuItem
			// 
			this.ouvrirToolStripMenuItem.Name = "ouvrirToolStripMenuItem";
			this.ouvrirToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.ouvrirToolStripMenuItem.Text = "Open...|30020";
			this.ouvrirToolStripMenuItem.Click += new System.EventHandler(this.ouvrirToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(135, 6);
			// 
			// supprimerToolStripMenuItem
			// 
			this.supprimerToolStripMenuItem.Name = "supprimerToolStripMenuItem";
			this.supprimerToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.supprimerToolStripMenuItem.Text = "Delete|30011";
			this.supprimerToolStripMenuItem.Click += new System.EventHandler(this.supprimerToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(135, 6);
			// 
			// enregistrerToolStripMenuItem
			// 
			this.enregistrerToolStripMenuItem.Name = "enregistrerToolStripMenuItem";
			this.enregistrerToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.enregistrerToolStripMenuItem.Text = "Save|30021";
			this.enregistrerToolStripMenuItem.Click += new System.EventHandler(this.enregistrerToolStripMenuItem_Click);
			// 
			// fermerToolStripMenuItem
			// 
			this.fermerToolStripMenuItem.Name = "fermerToolStripMenuItem";
			this.fermerToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.fermerToolStripMenuItem.Text = "Close|30022";
			this.fermerToolStripMenuItem.Click += new System.EventHandler(this.fermerToolStripMenuItem_Click);
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.langueToolStripMenuItem,
            this.stylesToolStripMenuItem});
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
			this.optionsToolStripMenuItem.Text = "Options|30023";
			// 
			// langueToolStripMenuItem
			// 
			this.langueToolStripMenuItem.Name = "langueToolStripMenuItem";
			this.langueToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.langueToolStripMenuItem.Text = "Language|30024";
			// 
			// stylesToolStripMenuItem
			// 
			this.stylesToolStripMenuItem.Name = "stylesToolStripMenuItem";
			this.stylesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.stylesToolStripMenuItem.Text = "Styles|30025";
			this.stylesToolStripMenuItem.Click += new System.EventHandler(this.stylesToolStripMenuItem_Click);
			// 
			// editeur
			// 
			this.editeur.Dock = System.Windows.Forms.DockStyle.Fill;
			this.editeur.Location = new System.Drawing.Point(0, 0);
			this.editeur.Name = "editeur";
			this.editeur.Size = new System.Drawing.Size(646, 487);
			this.editeur.TabIndex = 0;
			// 
			// CFormEditHelp
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(646, 521);
			this.Controls.Add(this.mnu);
			this.Controls.Add(this.editeur);
			this.Controls.Add(this.pan_down);
			this.Name = "CFormEditHelp";
			this.Text = "Help|30006";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CFormEditHelp_FormClosing);
			this.pan_down.ResumeLayout(false);
			this.mnu.ResumeLayout(false);
			this.mnu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel pan_down;
		private System.Windows.Forms.Button m_btnAnnuler;
		private System.Windows.Forms.Button m_btnOk;
		private CCtrlEditHelp editeur;
		private System.Windows.Forms.MenuStrip mnu;
		private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem documentIndividuelToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem enregistrerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fermerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem langueToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stylesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ouvrirToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem supprimerToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
	}
}