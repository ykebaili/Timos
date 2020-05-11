namespace timos.tables
{
	partial class CCtrlEditListeColonneFilter
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
			this.m_panElements = new System.Windows.Forms.Panel();
			this.m_panChks = new System.Windows.Forms.Panel();
			this.m_panBtns = new System.Windows.Forms.Panel();
			this.m_btnSupprimer = new System.Windows.Forms.Button();
			this.m_btnAjouter = new System.Windows.Forms.Button();
			this.m_panBtns.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_panElements
			// 
			this.m_panElements.AutoScroll = true;
			this.m_panElements.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_panElements.Location = new System.Drawing.Point(24, 0);
			this.m_panElements.Name = "m_panElements";
			this.m_panElements.Size = new System.Drawing.Size(277, 146);
			this.m_panElements.TabIndex = 0;
			// 
			// m_panChks
			// 
			this.m_panChks.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_panChks.Location = new System.Drawing.Point(0, 0);
			this.m_panChks.Name = "m_panChks";
			this.m_panChks.Size = new System.Drawing.Size(24, 146);
			this.m_panChks.TabIndex = 0;
			// 
			// m_panBtns
			// 
			this.m_panBtns.Controls.Add(this.m_btnSupprimer);
			this.m_panBtns.Controls.Add(this.m_btnAjouter);
			this.m_panBtns.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.m_panBtns.Location = new System.Drawing.Point(0, 146);
			this.m_panBtns.Name = "m_panBtns";
			this.m_panBtns.Size = new System.Drawing.Size(301, 30);
			this.m_panBtns.TabIndex = 0;
			// 
			// m_btnSupprimer
			// 
			this.m_btnSupprimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btnSupprimer.Location = new System.Drawing.Point(234, 4);
			this.m_btnSupprimer.Name = "m_btnSupprimer";
			this.m_btnSupprimer.Size = new System.Drawing.Size(64, 23);
			this.m_btnSupprimer.TabIndex = 0;
			this.m_btnSupprimer.Text = "Delete|18";
			this.m_btnSupprimer.UseVisualStyleBackColor = true;
			this.m_btnSupprimer.Click += new System.EventHandler(this.m_btnSupprimer_Click);
			// 
			// m_btnAjouter
			// 
			this.m_btnAjouter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_btnAjouter.Location = new System.Drawing.Point(3, 4);
			this.m_btnAjouter.Name = "m_btnAjouter";
			this.m_btnAjouter.Size = new System.Drawing.Size(48, 23);
			this.m_btnAjouter.TabIndex = 0;
			this.m_btnAjouter.Text = "Add|22";
			this.m_btnAjouter.UseVisualStyleBackColor = true;
			this.m_btnAjouter.Click += new System.EventHandler(this.m_btnAjouter_Click);
			// 
			// CCtrlEditListeColonneFilter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.m_panElements);
			this.Controls.Add(this.m_panChks);
			this.Controls.Add(this.m_panBtns);
			this.Name = "CCtrlEditListeColonneFilter";
			this.Size = new System.Drawing.Size(301, 176);
			this.m_panBtns.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel m_panElements;
		private System.Windows.Forms.Panel m_panBtns;
		private System.Windows.Forms.Button m_btnSupprimer;
		private System.Windows.Forms.Button m_btnAjouter;
		private System.Windows.Forms.Panel m_panChks;
	}
}
