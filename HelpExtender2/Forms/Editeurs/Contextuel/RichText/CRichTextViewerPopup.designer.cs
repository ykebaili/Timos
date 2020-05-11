namespace HelpExtender
{
	partial class CRichTextViewerPopup
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
			this.m_btnCancel = new System.Windows.Forms.Button();
			this.m_richText = new HelpExtender.RichTextBoxEx();
			this.SuspendLayout();
			// 
			// m_btnCancel
			// 
			this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnCancel.Location = new System.Drawing.Point(46, 32);
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Size = new System.Drawing.Size(75, 23);
			this.m_btnCancel.TabIndex = 0;
			this.m_btnCancel.Text = "button1";
			this.m_btnCancel.UseVisualStyleBackColor = true;
			// 
			// m_richText
			// 
			this.m_richText.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_richText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_richText.Location = new System.Drawing.Point(0, 0);
			this.m_richText.Name = "m_richText";
			this.m_richText.Size = new System.Drawing.Size(168, 107);
			this.m_richText.TabIndex = 1;
			this.m_richText.Text = "";
			this.m_richText.Leave += new System.EventHandler(this.CRichTextViewerPopup_Leave);
			this.m_richText.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.m_richText_LinkClicked);
			this.m_richText.MouseMove += new System.Windows.Forms.MouseEventHandler(this.m_richText_MouseMove);
			this.m_richText.Click += new System.EventHandler(this.m_richText_Click);
			// 
			// CRichTextViewerPopup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(168, 107);
			this.Controls.Add(this.m_richText);
			this.Controls.Add(this.m_btnCancel);
			this.Name = "CRichTextViewerPopup";
			this.ShowIcon = false;
			this.Text = "CRichTextViewerPopup";
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CRichTextViewerPopup_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.m_richText_MouseMove);
			this.Leave += new System.EventHandler(this.CRichTextViewerPopup_Leave);
			this.ResumeLayout(false);

		}

		#endregion

		private RichTextBoxEx m_richText;
		private System.Windows.Forms.Button m_btnCancel;
	}
}