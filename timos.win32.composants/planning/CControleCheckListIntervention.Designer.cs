namespace timos.win32.composants.planning
{
	partial class CControleCheckListIntervention
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
            this.m_panelCheckList = new System.Windows.Forms.Panel();
            this.m_wndListeContraintesFixes = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_panelContraintesFixes = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_panelContraintesFixes.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelCheckList
            // 
            this.m_panelCheckList.AutoScroll = true;
            this.m_panelCheckList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelCheckList.Location = new System.Drawing.Point(0, 95);
            this.m_panelCheckList.Name = "m_panelCheckList";
            this.m_panelCheckList.Size = new System.Drawing.Size(353, 112);
            this.m_panelCheckList.TabIndex = 0;
            // 
            // m_wndListeContraintesFixes
            // 
            this.m_wndListeContraintesFixes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeContraintesFixes.FormattingEnabled = true;
            this.m_wndListeContraintesFixes.Location = new System.Drawing.Point(0, 13);
            this.m_wndListeContraintesFixes.Name = "m_wndListeContraintesFixes";
            this.m_wndListeContraintesFixes.Size = new System.Drawing.Size(353, 56);
            this.m_wndListeContraintesFixes.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(353, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Operators must satisfy following constraints|698";
            // 
            // m_panelContraintesFixes
            // 
            this.m_panelContraintesFixes.Controls.Add(this.m_wndListeContraintesFixes);
            this.m_panelContraintesFixes.Controls.Add(this.label1);
            this.m_panelContraintesFixes.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelContraintesFixes.Location = new System.Drawing.Point(0, 0);
            this.m_panelContraintesFixes.Name = "m_panelContraintesFixes";
            this.m_panelContraintesFixes.Size = new System.Drawing.Size(353, 76);
            this.m_panelContraintesFixes.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(353, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Check List|699";
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Black;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 76);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(353, 3);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // CControleCheckListIntervention
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_panelCheckList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.m_panelContraintesFixes);
            this.Name = "CControleCheckListIntervention";
            this.Size = new System.Drawing.Size(353, 207);
            this.m_panelContraintesFixes.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel m_panelCheckList;
		private System.Windows.Forms.ListBox m_wndListeContraintesFixes;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel m_panelContraintesFixes;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Splitter splitter1;
	}
}
