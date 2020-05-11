namespace timos.win32.composants
{
	partial class CRichTextViewer
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
            this.m_txtBox = new System.Windows.Forms.RichTextBox();
            this.m_timerDemarrage = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // m_txtBox
            // 
            this.m_txtBox.BackColor = System.Drawing.Color.White;
            this.m_txtBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtBox.Location = new System.Drawing.Point(0, 0);
            this.m_txtBox.Name = "m_txtBox";
            this.m_txtBox.ReadOnly = true;
            this.m_txtBox.Size = new System.Drawing.Size(218, 146);
            this.m_txtBox.TabIndex = 0;
            this.m_txtBox.Text = "";
            // 
            // m_timerDemarrage
            // 
            this.m_timerDemarrage.Tick += new System.EventHandler(this.m_timerDemarrage_Tick);
            // 
            // CRichTextViewer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.m_txtBox);
            this.Name = "CRichTextViewer";
            this.Size = new System.Drawing.Size(218, 146);
            this.Load += new System.EventHandler(this.CRichTextViewer_Load);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RichTextBox m_txtBox;
		private System.Windows.Forms.Timer m_timerDemarrage;
	}
}
