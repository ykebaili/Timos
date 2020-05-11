namespace timos
{
	partial class CFormMapTypeTable
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
            this.m_panDown = new System.Windows.Forms.Panel();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_btnAnnuler = new System.Windows.Forms.Button();
            this.m_ctrlEditMappage = new timos.CControlEditMappage();
            this.m_panDown.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panDown
            // 
            this.m_panDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panDown.Controls.Add(this.m_btnOk);
            this.m_panDown.Controls.Add(this.m_btnAnnuler);
            this.m_panDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_panDown.Location = new System.Drawing.Point(0, 173);
            this.m_panDown.Name = "m_panDown";
            this.m_panDown.Size = new System.Drawing.Size(689, 32);
            this.m_panDown.TabIndex = 3;
            // 
            // m_btnOk
            // 
            this.m_btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnOk.Location = new System.Drawing.Point(3, 5);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(75, 21);
            this.m_btnOk.TabIndex = 1;
            this.m_btnOk.Text = "Ok|10";
            this.m_btnOk.UseVisualStyleBackColor = true;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnAnnuler.Location = new System.Drawing.Point(609, 5);
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(75, 21);
            this.m_btnAnnuler.TabIndex = 1;
            this.m_btnAnnuler.Text = "Cancel|11";
            this.m_btnAnnuler.UseVisualStyleBackColor = true;
            this.m_btnAnnuler.Click += new System.EventHandler(this.m_btnAnnuler_Click);
            // 
            // m_ctrlEditMappage
            // 
            this.m_ctrlEditMappage.AutoScroll = true;
            this.m_ctrlEditMappage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_ctrlEditMappage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_ctrlEditMappage.Location = new System.Drawing.Point(0, 0);
            this.m_ctrlEditMappage.Name = "m_ctrlEditMappage";
            this.m_ctrlEditMappage.Size = new System.Drawing.Size(689, 173);
            this.m_ctrlEditMappage.TabIndex = 4;
            // 
            // CFormMapTypeTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(689, 205);
            this.ControlBox = false;
            this.Controls.Add(this.m_ctrlEditMappage);
            this.Controls.Add(this.m_panDown);
            this.Name = "CFormMapTypeTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mapping|30259";
            this.m_panDown.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel m_panDown;
		private System.Windows.Forms.Button m_btnOk;
		private System.Windows.Forms.Button m_btnAnnuler;
		private CControlEditMappage m_ctrlEditMappage;
	}
}