namespace timos
{
	partial class CControleEditionNiveauParametrage
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
            this.m_panelEntete = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_panelData = new System.Windows.Forms.Panel();
            this.m_lblUnite = new System.Windows.Forms.Label();
            this.m_lblEndAt = new System.Windows.Forms.Label();
            this.m_numUpSize = new sc2i.win32.common.C2iNumericUpDown();
            this.m_txtStartAt = new sc2i.win32.common.C2iTextBox();
            this.m_lblLibelle = new System.Windows.Forms.Label();
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.m_panelEntete.SuspendLayout();
            this.m_panelData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_numUpSize)).BeginInit();
            this.SuspendLayout();
            // 
            // m_panelEntete
            // 
            this.m_panelEntete.Controls.Add(this.label1);
            this.m_panelEntete.Controls.Add(this.label2);
            this.m_panelEntete.Controls.Add(this.label3);
            this.m_panelEntete.Controls.Add(this.label4);
            this.m_panelEntete.Controls.Add(this.label5);
            this.m_panelEntete.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelEntete.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEntete, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelEntete.Name = "m_panelEntete";
            this.m_panelEntete.Size = new System.Drawing.Size(489, 21);
            this.m_panelEntete.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Dock = System.Windows.Forms.DockStyle.Right;
            this.label5.Location = new System.Drawing.Point(429, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "Unit|840";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Dock = System.Windows.Forms.DockStyle.Right;
            this.label4.Location = new System.Drawing.Point(349, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "End at|839";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(269, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Size|838";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(189, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Start at|837";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Level|836";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_panelData
            // 
            this.m_panelData.Controls.Add(this.m_lblLibelle);
            this.m_panelData.Controls.Add(this.m_txtStartAt);
            this.m_panelData.Controls.Add(this.m_numUpSize);
            this.m_panelData.Controls.Add(this.m_lblEndAt);
            this.m_panelData.Controls.Add(this.m_lblUnite);
            this.m_panelData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelData.Location = new System.Drawing.Point(0, 21);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelData, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelData.Name = "m_panelData";
            this.m_panelData.Size = new System.Drawing.Size(489, 21);
            this.m_panelData.TabIndex = 1;
            // 
            // m_lblUnite
            // 
            this.m_lblUnite.BackColor = System.Drawing.Color.White;
            this.m_lblUnite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblUnite.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_lblUnite.Location = new System.Drawing.Point(429, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblUnite, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblUnite.Name = "m_lblUnite";
            this.m_lblUnite.Size = new System.Drawing.Size(60, 21);
            this.m_lblUnite.TabIndex = 5;
            this.m_lblUnite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_lblEndAt
            // 
            this.m_lblEndAt.BackColor = System.Drawing.Color.White;
            this.m_lblEndAt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblEndAt.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_lblEndAt.Location = new System.Drawing.Point(349, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblEndAt, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblEndAt.Name = "m_lblEndAt";
            this.m_lblEndAt.Size = new System.Drawing.Size(80, 21);
            this.m_lblEndAt.TabIndex = 4;
            this.m_lblEndAt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_numUpSize
            // 
            this.m_numUpSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_numUpSize.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_numUpSize.DoubleValue = 0;
            this.m_numUpSize.IntValue = 0;
            this.m_numUpSize.Location = new System.Drawing.Point(269, 0);
            this.m_numUpSize.LockEdition = false;
            this.m_numUpSize.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_numUpSize, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_numUpSize.Name = "m_numUpSize";
            this.m_numUpSize.Size = new System.Drawing.Size(80, 20);
            this.m_numUpSize.TabIndex = 3;
            this.m_numUpSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_numUpSize.ThousandsSeparator = true;
            this.m_numUpSize.ValueChanged += new System.EventHandler(this.m_numUpSize_ValueChanged);
            // 
            // m_txtStartAt
            // 
            this.m_txtStartAt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtStartAt.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_txtStartAt.Location = new System.Drawing.Point(189, 0);
            this.m_txtStartAt.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtStartAt, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtStartAt.Name = "m_txtStartAt";
            this.m_txtStartAt.Size = new System.Drawing.Size(80, 20);
            this.m_txtStartAt.TabIndex = 2;
            this.m_txtStartAt.TextChanged += new System.EventHandler(this.m_txtStartAt_TextChanged);
            // 
            // m_lblLibelle
            // 
            this.m_lblLibelle.BackColor = System.Drawing.Color.White;
            this.m_lblLibelle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblLibelle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lblLibelle.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblLibelle, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblLibelle.Name = "m_lblLibelle";
            this.m_lblLibelle.Size = new System.Drawing.Size(189, 21);
            this.m_lblLibelle.TabIndex = 1;
            this.m_lblLibelle.Text = "Level";
            this.m_lblLibelle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CControleEditionNiveauParametrage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_panelData);
            this.Controls.Add(this.m_panelEntete);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleEditionNiveauParametrage";
            this.Size = new System.Drawing.Size(489, 42);
            this.Load += new System.EventHandler(this.CControleEditionNiveauParametrage_Load);
            this.m_panelEntete.ResumeLayout(false);
            this.m_panelData.ResumeLayout(false);
            this.m_panelData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_numUpSize)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel m_panelEntete;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private System.Windows.Forms.Panel m_panelData;
		private sc2i.win32.common.C2iTextBox m_txtStartAt;
		private System.Windows.Forms.Label m_lblLibelle;
		private System.Windows.Forms.Label m_lblEndAt;
		private sc2i.win32.common.C2iNumericUpDown m_numUpSize;
		private System.Windows.Forms.Label m_lblUnite;
		private System.Windows.Forms.ToolTip m_tooltip;
	}
}
