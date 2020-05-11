namespace TimosDataServeur
{
	partial class CtrlProgressBarDataBaseElement
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
            this.m_lblTitre = new System.Windows.Forms.Label();
            this.m_panTitre = new System.Windows.Forms.Panel();
            this.m_panProgress = new System.Windows.Forms.Panel();
            this.m_ctrlProgressBar = new TimosDataServeur.CtrlProgressBarTimos();
            this.m_panNbs = new System.Windows.Forms.Panel();
            this.m_lblNbs = new System.Windows.Forms.Label();
            this.m_panPourCent = new System.Windows.Forms.Panel();
            this.m_lblPourCent = new System.Windows.Forms.Label();
            this.m_panOp = new System.Windows.Forms.Panel();
            this.m_lblOp = new System.Windows.Forms.Label();
            this.m_panTitre.SuspendLayout();
            this.m_panProgress.SuspendLayout();
            this.m_panNbs.SuspendLayout();
            this.m_panPourCent.SuspendLayout();
            this.m_panOp.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_lblTitre
            // 
            this.m_lblTitre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lblTitre.Location = new System.Drawing.Point(0, 0);
            this.m_lblTitre.Name = "m_lblTitre";
            this.m_lblTitre.Size = new System.Drawing.Size(238, 26);
            this.m_lblTitre.TabIndex = 0;
            this.m_lblTitre.Text = "title";
            this.m_lblTitre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_panTitre
            // 
            this.m_panTitre.Controls.Add(this.m_lblTitre);
            this.m_panTitre.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panTitre.Location = new System.Drawing.Point(0, 0);
            this.m_panTitre.Name = "m_panTitre";
            this.m_panTitre.Size = new System.Drawing.Size(238, 26);
            this.m_panTitre.TabIndex = 2;
            // 
            // m_panProgress
            // 
            this.m_panProgress.Controls.Add(this.m_ctrlProgressBar);
            this.m_panProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panProgress.Location = new System.Drawing.Point(238, 0);
            this.m_panProgress.Name = "m_panProgress";
            this.m_panProgress.Size = new System.Drawing.Size(342, 26);
            this.m_panProgress.TabIndex = 3;
            // 
            // m_ctrlProgressBar
            // 
            this.m_ctrlProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ctrlProgressBar.BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.m_ctrlProgressBar.BorderColor = System.Drawing.Color.Black;
            this.m_ctrlProgressBar.FillStyle = TimosDataServeur.CtrlProgressBarTimos.FillStyles.Solid;
            this.m_ctrlProgressBar.Location = new System.Drawing.Point(3, 3);
            this.m_ctrlProgressBar.Maximum = 100;
            this.m_ctrlProgressBar.Minimum = 0;
            this.m_ctrlProgressBar.Name = "m_ctrlProgressBar";
            this.m_ctrlProgressBar.Size = new System.Drawing.Size(336, 20);
            this.m_ctrlProgressBar.Step = 10;
            this.m_ctrlProgressBar.TabIndex = 1;
            this.m_ctrlProgressBar.Value = 0;
            // 
            // m_panNbs
            // 
            this.m_panNbs.Controls.Add(this.m_lblNbs);
            this.m_panNbs.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_panNbs.Location = new System.Drawing.Point(625, 0);
            this.m_panNbs.Name = "m_panNbs";
            this.m_panNbs.Size = new System.Drawing.Size(58, 26);
            this.m_panNbs.TabIndex = 2;
            // 
            // m_lblNbs
            // 
            this.m_lblNbs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lblNbs.Location = new System.Drawing.Point(0, 0);
            this.m_lblNbs.Name = "m_lblNbs";
            this.m_lblNbs.Size = new System.Drawing.Size(58, 26);
            this.m_lblNbs.TabIndex = 0;
            this.m_lblNbs.Text = "%";
            this.m_lblNbs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_panPourCent
            // 
            this.m_panPourCent.Controls.Add(this.m_lblPourCent);
            this.m_panPourCent.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_panPourCent.Location = new System.Drawing.Point(580, 0);
            this.m_panPourCent.Name = "m_panPourCent";
            this.m_panPourCent.Size = new System.Drawing.Size(45, 26);
            this.m_panPourCent.TabIndex = 2;
            // 
            // m_lblPourCent
            // 
            this.m_lblPourCent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lblPourCent.Location = new System.Drawing.Point(0, 0);
            this.m_lblPourCent.Name = "m_lblPourCent";
            this.m_lblPourCent.Size = new System.Drawing.Size(45, 26);
            this.m_lblPourCent.TabIndex = 0;
            this.m_lblPourCent.Text = "n/n";
            this.m_lblPourCent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_panOp
            // 
            this.m_panOp.Controls.Add(this.m_lblOp);
            this.m_panOp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_panOp.Location = new System.Drawing.Point(0, 26);
            this.m_panOp.Name = "m_panOp";
            this.m_panOp.Size = new System.Drawing.Size(683, 15);
            this.m_panOp.TabIndex = 1;
            // 
            // m_lblOp
            // 
            this.m_lblOp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lblOp.Location = new System.Drawing.Point(0, 0);
            this.m_lblOp.Name = "m_lblOp";
            this.m_lblOp.Size = new System.Drawing.Size(683, 15);
            this.m_lblOp.TabIndex = 0;
            this.m_lblOp.Text = "operation";
            this.m_lblOp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CtrlProgressBarDataBaseElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_panProgress);
            this.Controls.Add(this.m_panPourCent);
            this.Controls.Add(this.m_panNbs);
            this.Controls.Add(this.m_panTitre);
            this.Controls.Add(this.m_panOp);
            this.Name = "CtrlProgressBarDataBaseElement";
            this.Size = new System.Drawing.Size(683, 41);
            this.m_panTitre.ResumeLayout(false);
            this.m_panProgress.ResumeLayout(false);
            this.m_panNbs.ResumeLayout(false);
            this.m_panPourCent.ResumeLayout(false);
            this.m_panOp.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label m_lblTitre;
		private CtrlProgressBarTimos m_ctrlProgressBar;
		private System.Windows.Forms.Panel m_panTitre;
		private System.Windows.Forms.Panel m_panProgress;
		private System.Windows.Forms.Panel m_panNbs;
		private System.Windows.Forms.Label m_lblNbs;
		private System.Windows.Forms.Panel m_panPourCent;
		private System.Windows.Forms.Label m_lblPourCent;
		private System.Windows.Forms.Panel m_panOp;
		private System.Windows.Forms.Label m_lblOp;
	}
}
