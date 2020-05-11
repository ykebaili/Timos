namespace HelpExtender
{
	partial class CFormEditLink
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
            this.m_btnAnnuler = new System.Windows.Forms.Button();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLinkText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_lblLinkTo = new System.Windows.Forms.Label();
            this.m_lnkLinkTo = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.Location = new System.Drawing.Point(171, 77);
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(75, 23);
            this.m_btnAnnuler.TabIndex = 3;
            this.m_btnAnnuler.Text = "Cancel|11";
            this.m_btnAnnuler.UseVisualStyleBackColor = true;
            this.m_btnAnnuler.Click += new System.EventHandler(this.m_btnAnnuler_Click);
            // 
            // m_btnOk
            // 
            this.m_btnOk.Location = new System.Drawing.Point(53, 77);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(75, 23);
            this.m_btnOk.TabIndex = 2;
            this.m_btnOk.Text = "Ok|10";
            this.m_btnOk.UseVisualStyleBackColor = true;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Link text|30027";
            // 
            // m_txtLinkText
            // 
            this.m_txtLinkText.Location = new System.Drawing.Point(58, 13);
            this.m_txtLinkText.Name = "m_txtLinkText";
            this.m_txtLinkText.Size = new System.Drawing.Size(222, 20);
            this.m_txtLinkText.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Link to|30028";
            // 
            // m_lblLinkTo
            // 
            this.m_lblLinkTo.BackColor = System.Drawing.Color.White;
            this.m_lblLinkTo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblLinkTo.Location = new System.Drawing.Point(58, 43);
            this.m_lblLinkTo.Name = "m_lblLinkTo";
            this.m_lblLinkTo.Size = new System.Drawing.Size(206, 20);
            this.m_lblLinkTo.TabIndex = 7;
            // 
            // m_lnkLinkTo
            // 
            this.m_lnkLinkTo.AutoSize = true;
            this.m_lnkLinkTo.Location = new System.Drawing.Point(271, 49);
            this.m_lnkLinkTo.Name = "m_lnkLinkTo";
            this.m_lnkLinkTo.Size = new System.Drawing.Size(16, 13);
            this.m_lnkLinkTo.TabIndex = 8;
            this.m_lnkLinkTo.TabStop = true;
            this.m_lnkLinkTo.Text = "...";
            this.m_lnkLinkTo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkLinkTo_LinkClicked);
            // 
            // CFormEditLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(292, 112);
            this.ControlBox = false;
            this.Controls.Add(this.m_lnkLinkTo);
            this.Controls.Add(this.m_lblLinkTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_txtLinkText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_btnAnnuler);
            this.Controls.Add(this.m_btnOk);
            this.Name = "CFormEditLink";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Link properties|30026";
            this.Load += new System.EventHandler(this.CFormEditLink_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button m_btnAnnuler;
		private System.Windows.Forms.Button m_btnOk;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox m_txtLinkText;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label m_lblLinkTo;
		private System.Windows.Forms.LinkLabel m_lnkLinkTo;
	}
}