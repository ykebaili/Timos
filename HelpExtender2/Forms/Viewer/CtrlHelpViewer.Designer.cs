namespace HelpExtender
{
	partial class CtrlHelpViewer
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
			this.splitConteneur = new System.Windows.Forms.SplitContainer();
			this.viewerHtml = new HelpExtender.WebViewerEx();
			this.pan_annexe = new System.Windows.Forms.Panel();
			this.pan_titreannexes = new System.Windows.Forms.Panel();
			this.btn_masquerannexe = new System.Windows.Forms.Button();
			this.lbl_titreAnnexes = new System.Windows.Forms.Label();
			this.lv_annexes = new System.Windows.Forms.ListView();
			this.col_titre = new System.Windows.Forms.ColumnHeader();
			this.col_type = new System.Windows.Forms.ColumnHeader();
			this.col_designation = new System.Windows.Forms.ColumnHeader();
			this.splitConteneur.Panel2.SuspendLayout();
			this.splitConteneur.SuspendLayout();
			this.pan_annexe.SuspendLayout();
			this.pan_titreannexes.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitConteneur
			// 
			this.splitConteneur.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitConteneur.Location = new System.Drawing.Point(0, 0);
			this.splitConteneur.Name = "splitConteneur";
			this.splitConteneur.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitConteneur.Panel2
			// 
			this.splitConteneur.Panel2.Controls.Add(this.pan_annexe);
			this.splitConteneur.Size = new System.Drawing.Size(349, 345);
			this.splitConteneur.SplitterDistance = 150;
			this.splitConteneur.TabIndex = 1;
			// 
			// viewerHtml
			// 
			this.viewerHtml.Dock = System.Windows.Forms.DockStyle.Fill;
			this.viewerHtml.LiensVersHelpActifs = true;
			this.viewerHtml.Location = new System.Drawing.Point(0, 0);
			this.viewerHtml.MinimumSize = new System.Drawing.Size(20, 20);
			this.viewerHtml.Name = "viewerHtml";
			this.viewerHtml.Size = new System.Drawing.Size(349, 345);
			this.viewerHtml.TabIndex = 0;
			this.viewerHtml.ClickLienVersAide += new HelpExtender.EvenementNavigationVersAide(this.viewerHtml_ClickLienVersAide);
			// 
			// pan_annexe
			// 
			this.pan_annexe.Controls.Add(this.pan_titreannexes);
			this.pan_annexe.Controls.Add(this.lv_annexes);
			this.pan_annexe.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pan_annexe.Location = new System.Drawing.Point(0, 0);
			this.pan_annexe.Name = "pan_annexe";
			this.pan_annexe.Size = new System.Drawing.Size(349, 191);
			this.pan_annexe.TabIndex = 1;
			// 
			// pan_titreannexes
			// 
			this.pan_titreannexes.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.pan_titreannexes.Controls.Add(this.btn_masquerannexe);
			this.pan_titreannexes.Controls.Add(this.lbl_titreAnnexes);
			this.pan_titreannexes.Dock = System.Windows.Forms.DockStyle.Top;
			this.pan_titreannexes.Location = new System.Drawing.Point(0, 0);
			this.pan_titreannexes.Name = "pan_titreannexes";
			this.pan_titreannexes.Size = new System.Drawing.Size(349, 25);
			this.pan_titreannexes.TabIndex = 0;
			// 
			// btn_masquerannexe
			// 
			this.btn_masquerannexe.Location = new System.Drawing.Point(320, 3);
			this.btn_masquerannexe.Name = "btn_masquerannexe";
			this.btn_masquerannexe.Size = new System.Drawing.Size(26, 19);
			this.btn_masquerannexe.TabIndex = 1;
			this.btn_masquerannexe.Text = "/\\";
			this.btn_masquerannexe.UseVisualStyleBackColor = true;
			this.btn_masquerannexe.Click += new System.EventHandler(this.btn_masquerannexe_Click);
			// 
			// lbl_titreAnnexes
			// 
			this.lbl_titreAnnexes.AutoSize = true;
			this.lbl_titreAnnexes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_titreAnnexes.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.lbl_titreAnnexes.Location = new System.Drawing.Point(3, 2);
			this.lbl_titreAnnexes.Name = "lbl_titreAnnexes";
			this.lbl_titreAnnexes.Size = new System.Drawing.Size(126, 20);
			this.lbl_titreAnnexes.TabIndex = 0;
			this.lbl_titreAnnexes.Text = "Aides annexes";
			// 
			// lv_annexes
			// 
			this.lv_annexes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_titre,
            this.col_type,
            this.col_designation});
			this.lv_annexes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lv_annexes.FullRowSelect = true;
			this.lv_annexes.GridLines = true;
			this.lv_annexes.Location = new System.Drawing.Point(0, 0);
			this.lv_annexes.Name = "lv_annexes";
			this.lv_annexes.Size = new System.Drawing.Size(349, 191);
			this.lv_annexes.TabIndex = 1;
			this.lv_annexes.UseCompatibleStateImageBehavior = false;
			this.lv_annexes.View = System.Windows.Forms.View.Details;
			this.lv_annexes.SelectedIndexChanged += new System.EventHandler(this.lv_annexes_SelectedIndexChanged);
			// 
			// col_titre
			// 
			this.col_titre.Text = "Titre";
			// 
			// col_type
			// 
			this.col_type.Text = "Type";
			// 
			// col_designation
			// 
			this.col_designation.Text = "Désignation";
			this.col_designation.Width = 150;
			// 
			// CtrlHelpViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.viewerHtml);
			this.Controls.Add(this.splitConteneur);
			this.Name = "CtrlHelpViewer";
			this.Size = new System.Drawing.Size(349, 345);
			this.splitConteneur.Panel2.ResumeLayout(false);
			this.splitConteneur.ResumeLayout(false);
			this.pan_annexe.ResumeLayout(false);
			this.pan_titreannexes.ResumeLayout(false);
			this.pan_titreannexes.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private WebViewerEx viewerHtml;
		private System.Windows.Forms.SplitContainer splitConteneur;
		private System.Windows.Forms.ListView lv_annexes;
		private System.Windows.Forms.Panel pan_titreannexes;
		private System.Windows.Forms.ColumnHeader col_titre;
		private System.Windows.Forms.ColumnHeader col_type;
		private System.Windows.Forms.ColumnHeader col_designation;
		private System.Windows.Forms.Label lbl_titreAnnexes;
		private System.Windows.Forms.Button btn_masquerannexe;
		private System.Windows.Forms.Panel pan_annexe;
	}
}
