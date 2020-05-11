namespace HelpExtender
{
	partial class CCtrlEditHelpsLies
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
            this.pan_cmds = new System.Windows.Forms.Panel();
            this.btn_supp = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.pan_eles = new System.Windows.Forms.Panel();
            this.lv_eles = new System.Windows.Forms.ListView();
            this.col_titre = new System.Windows.Forms.ColumnHeader();
            this.col_type = new System.Windows.Forms.ColumnHeader();
            this.col_designation = new System.Windows.Forms.ColumnHeader();
            this.pan_cmds.SuspendLayout();
            this.pan_eles.SuspendLayout();
            this.SuspendLayout();
            // 
            // pan_cmds
            // 
            this.pan_cmds.Controls.Add(this.btn_supp);
            this.pan_cmds.Controls.Add(this.btn_add);
            this.pan_cmds.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pan_cmds.Location = new System.Drawing.Point(0, 208);
            this.pan_cmds.Name = "pan_cmds";
            this.pan_cmds.Size = new System.Drawing.Size(324, 28);
            this.pan_cmds.TabIndex = 0;
            // 
            // btn_supp
            // 
            this.btn_supp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_supp.Location = new System.Drawing.Point(246, 3);
            this.btn_supp.Name = "btn_supp";
            this.btn_supp.Size = new System.Drawing.Size(75, 23);
            this.btn_supp.TabIndex = 0;
            this.btn_supp.Text = "Cancel|30011";
            this.btn_supp.UseVisualStyleBackColor = true;
            this.btn_supp.Click += new System.EventHandler(this.btn_supp_Click);
            // 
            // btn_add
            // 
            this.btn_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_add.Location = new System.Drawing.Point(3, 3);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 0;
            this.btn_add.Text = "Add|30010";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // pan_eles
            // 
            this.pan_eles.Controls.Add(this.lv_eles);
            this.pan_eles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_eles.Location = new System.Drawing.Point(0, 0);
            this.pan_eles.Name = "pan_eles";
            this.pan_eles.Size = new System.Drawing.Size(324, 208);
            this.pan_eles.TabIndex = 0;
            // 
            // lv_eles
            // 
            this.lv_eles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_titre,
            this.col_type,
            this.col_designation});
            this.lv_eles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_eles.FullRowSelect = true;
            this.lv_eles.GridLines = true;
            this.lv_eles.Location = new System.Drawing.Point(0, 0);
            this.lv_eles.Name = "lv_eles";
            this.lv_eles.Size = new System.Drawing.Size(324, 208);
            this.lv_eles.TabIndex = 0;
            this.lv_eles.UseCompatibleStateImageBehavior = false;
            this.lv_eles.View = System.Windows.Forms.View.Details;
            this.lv_eles.DoubleClick += new System.EventHandler(this.lv_eles_DoubleClick);
            this.lv_eles.SelectedIndexChanged += new System.EventHandler(this.lv_eles_SelectedIndexChanged);
            this.lv_eles.Click += new System.EventHandler(this.lv_eles_Click);
            // 
            // col_titre
            // 
            this.col_titre.Text = "Title|30002";
            // 
            // col_type
            // 
            this.col_type.Text = "Type|30012";
            // 
            // col_designation
            // 
            this.col_designation.Text = "Designation|30035";
            this.col_designation.Width = 200;
            // 
            // CCtrlEditHelpsLies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pan_eles);
            this.Controls.Add(this.pan_cmds);
            this.Name = "CCtrlEditHelpsLies";
            this.Size = new System.Drawing.Size(324, 236);
            this.pan_cmds.ResumeLayout(false);
            this.pan_eles.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pan_cmds;
		private System.Windows.Forms.Panel pan_eles;
		private System.Windows.Forms.Button btn_supp;
		private System.Windows.Forms.Button btn_add;
		private System.Windows.Forms.ListView lv_eles;
		private System.Windows.Forms.ColumnHeader col_titre;
		private System.Windows.Forms.ColumnHeader col_type;
		private System.Windows.Forms.ColumnHeader col_designation;
	}
}
