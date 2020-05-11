namespace timos.tables
{
	partial class CFormZoomText
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
			this.m_txtZoom = new System.Windows.Forms.TextBox();
			this.m_lnkFermer = new System.Windows.Forms.LinkLabel();
			this.m_lnkOk = new System.Windows.Forms.LinkLabel();
			this.m_panelBas = new System.Windows.Forms.Panel();
			this.m_panelBas.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_txtZoom
			// 
			this.m_txtZoom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_txtZoom.Location = new System.Drawing.Point(0, 0);
			this.m_txtZoom.Multiline = true;
			this.m_txtZoom.Name = "m_txtZoom";
			this.m_txtZoom.ReadOnly = true;
			this.m_txtZoom.Size = new System.Drawing.Size(407, 275);
			this.m_txtZoom.TabIndex = 0;
			// 
			// m_lnkFermer
			// 
			this.m_lnkFermer.AutoSize = true;
			this.m_lnkFermer.Location = new System.Drawing.Point(357, 0);
			this.m_lnkFermer.Name = "m_lnkFermer";
			this.m_lnkFermer.Size = new System.Drawing.Size(47, 13);
			this.m_lnkFermer.TabIndex = 1;
			this.m_lnkFermer.TabStop = true;
			this.m_lnkFermer.Text = "Close|12";
			this.m_lnkFermer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.m_lnkFermer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkFermer_LinkClicked);
			// 
			// m_lnkOk
			// 
			this.m_lnkOk.AutoSize = true;
			this.m_lnkOk.Location = new System.Drawing.Point(182, 0);
			this.m_lnkOk.Name = "m_lnkOk";
			this.m_lnkOk.Size = new System.Drawing.Size(35, 13);
			this.m_lnkOk.TabIndex = 2;
			this.m_lnkOk.TabStop = true;
			this.m_lnkOk.Text = "Ok|10";
			this.m_lnkOk.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkOk_LinkClicked);
			// 
			// m_panelBas
			// 
			this.m_panelBas.Controls.Add(this.m_lnkFermer);
			this.m_panelBas.Controls.Add(this.m_lnkOk);
			this.m_panelBas.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.m_panelBas.Location = new System.Drawing.Point(0, 259);
			this.m_panelBas.Name = "m_panelBas";
			this.m_panelBas.Size = new System.Drawing.Size(407, 16);
			this.m_panelBas.TabIndex = 3;
			// 
			// CFormZoomText
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(407, 275);
			this.Controls.Add(this.m_panelBas);
			this.Controls.Add(this.m_txtZoom);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "CFormZoomText";
			this.Load += new System.EventHandler(this.CFormZoomText_Load);
			this.m_panelBas.ResumeLayout(false);
			this.m_panelBas.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox m_txtZoom;
		private System.Windows.Forms.LinkLabel m_lnkFermer;
		private System.Windows.Forms.LinkLabel m_lnkOk;
		private System.Windows.Forms.Panel m_panelBas;
	}
}