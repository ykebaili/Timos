namespace HelpExtender
{
	partial class CWebViewerPopup
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
			this.m_webViewer = new HelpExtender.WebViewerEx();
			this.SuspendLayout();
			// 
			// m_webViewer
			// 
			this.m_webViewer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_webViewer.Location = new System.Drawing.Point(0, 0);
			this.m_webViewer.Name = "m_webViewer";
			this.m_webViewer.Size = new System.Drawing.Size(168, 107);
			this.m_webViewer.TabIndex = 1;
			// 
			// CWebViewerPopup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(168, 107);
			this.Controls.Add(this.m_webViewer);
			this.Name = "CWebViewerPopup";
			this.ShowIcon = false;
			this.Text = "CWebViewerPopup";
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(CWebViewerPopup_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(CWebViewerPopup_MouseMove);
			this.Leave += new System.EventHandler(CWebViewerPopup_Leave);
			this.ResumeLayout(false);
		}

		#endregion

		private WebViewerEx m_webViewer;
	}
}