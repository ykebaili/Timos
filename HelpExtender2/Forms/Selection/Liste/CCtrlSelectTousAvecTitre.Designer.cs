namespace HelpExtender
{
	partial class CCtrlSelectTousAvecTitre
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
            this.pan_lst = new System.Windows.Forms.Panel();
            this.lv_hlps = new System.Windows.Forms.ListView();
            this.col_titre = new System.Windows.Forms.ColumnHeader();
            this.col_nomcour = new System.Windows.Forms.ColumnHeader();
            this.col_type = new System.Windows.Forms.ColumnHeader();
            this.pan_titre = new System.Windows.Forms.Panel();
            this.lbl_titre = new System.Windows.Forms.Label();
            this.txt_titre = new System.Windows.Forms.TextBox();
            this.pan_opts = new System.Windows.Forms.Panel();
            this.lbl_optrecherche = new System.Windows.Forms.Label();
            this.cmb_optrecherche = new System.Windows.Forms.ComboBox();
            this.chk_casesensitive = new System.Windows.Forms.CheckBox();
            this.m_timer = new System.Windows.Forms.Timer(this.components);
            this.pan_lst.SuspendLayout();
            this.pan_titre.SuspendLayout();
            this.pan_opts.SuspendLayout();
            this.SuspendLayout();
            // 
            // pan_lst
            // 
            this.pan_lst.Controls.Add(this.lv_hlps);
            this.pan_lst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_lst.Location = new System.Drawing.Point(0, 84);
            this.pan_lst.Name = "pan_lst";
            this.pan_lst.Size = new System.Drawing.Size(340, 176);
            this.pan_lst.TabIndex = 0;
            // 
            // lv_hlps
            // 
            this.lv_hlps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_titre,
            this.col_nomcour,
            this.col_type});
            this.lv_hlps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_hlps.FullRowSelect = true;
            this.lv_hlps.GridLines = true;
            this.lv_hlps.Location = new System.Drawing.Point(0, 0);
            this.lv_hlps.Name = "lv_hlps";
            this.lv_hlps.Size = new System.Drawing.Size(340, 176);
            this.lv_hlps.TabIndex = 0;
            this.lv_hlps.UseCompatibleStateImageBehavior = false;
            this.lv_hlps.View = System.Windows.Forms.View.Details;
            this.lv_hlps.DoubleClick += new System.EventHandler(this.lv_hlps_MouseClick);
            this.lv_hlps.SelectedIndexChanged += new System.EventHandler(this.lv_hlps_SelectedIndexChanged);
            this.lv_hlps.Click += new System.EventHandler(this.lv_hlps_Click);
            // 
            // col_titre
            // 
            this.col_titre.Text = "Title|30002";
            this.col_titre.Width = 150;
            // 
            // col_nomcour
            // 
            this.col_nomcour.Text = "Short name|30047";
            this.col_nomcour.Width = 100;
            // 
            // col_type
            // 
            this.col_type.Text = "Type|30012";
            // 
            // pan_titre
            // 
            this.pan_titre.Controls.Add(this.txt_titre);
            this.pan_titre.Controls.Add(this.lbl_titre);
            this.pan_titre.Dock = System.Windows.Forms.DockStyle.Top;
            this.pan_titre.Location = new System.Drawing.Point(0, 0);
            this.pan_titre.Name = "pan_titre";
            this.pan_titre.Size = new System.Drawing.Size(340, 28);
            this.pan_titre.TabIndex = 0;
            // 
            // lbl_titre
            // 
            this.lbl_titre.AutoSize = true;
            this.lbl_titre.Location = new System.Drawing.Point(3, 7);
            this.lbl_titre.Name = "lbl_titre";
            this.lbl_titre.Size = new System.Drawing.Size(59, 13);
            this.lbl_titre.TabIndex = 1;
            this.lbl_titre.Text = "Title|30002";
            // 
            // txt_titre
            // 
            this.txt_titre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_titre.Location = new System.Drawing.Point(37, 4);
            this.txt_titre.Name = "txt_titre";
            this.txt_titre.Size = new System.Drawing.Size(298, 20);
            this.txt_titre.TabIndex = 0;
            this.txt_titre.TextChanged += new System.EventHandler(this.txt_titre_TextChanged);
            // 
            // pan_opts
            // 
            this.pan_opts.Controls.Add(this.cmb_optrecherche);
            this.pan_opts.Controls.Add(this.chk_casesensitive);
            this.pan_opts.Controls.Add(this.lbl_optrecherche);
            this.pan_opts.Dock = System.Windows.Forms.DockStyle.Top;
            this.pan_opts.Location = new System.Drawing.Point(0, 28);
            this.pan_opts.Name = "pan_opts";
            this.pan_opts.Size = new System.Drawing.Size(340, 56);
            this.pan_opts.TabIndex = 1;
            // 
            // lbl_optrecherche
            // 
            this.lbl_optrecherche.AutoSize = true;
            this.lbl_optrecherche.Location = new System.Drawing.Point(3, 32);
            this.lbl_optrecherche.Name = "lbl_optrecherche";
            this.lbl_optrecherche.Size = new System.Drawing.Size(94, 13);
            this.lbl_optrecherche.TabIndex = 1;
            this.lbl_optrecherche.Text = "Test criteria|30046";
            // 
            // cmb_optrecherche
            // 
            this.cmb_optrecherche.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_optrecherche.FormattingEnabled = true;
            this.cmb_optrecherche.Location = new System.Drawing.Point(81, 29);
            this.cmb_optrecherche.Name = "cmb_optrecherche";
            this.cmb_optrecherche.Size = new System.Drawing.Size(254, 21);
            this.cmb_optrecherche.TabIndex = 1;
            this.cmb_optrecherche.SelectionChangeCommitted += new System.EventHandler(this.txt_titre_TextChanged);
            // 
            // chk_casesensitive
            // 
            this.chk_casesensitive.AutoSize = true;
            this.chk_casesensitive.Location = new System.Drawing.Point(6, 9);
            this.chk_casesensitive.Name = "chk_casesensitive";
            this.chk_casesensitive.Size = new System.Drawing.Size(126, 17);
            this.chk_casesensitive.TabIndex = 0;
            this.chk_casesensitive.Text = "Case sensitive|30045";
            this.chk_casesensitive.UseVisualStyleBackColor = true;
            this.chk_casesensitive.CheckedChanged += new System.EventHandler(this.txt_titre_TextChanged);
            // 
            // m_timer
            // 
            this.m_timer.Tick += new System.EventHandler(this.m_timer_Tick);
            // 
            // CCtrlSelectTousAvecTitre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pan_lst);
            this.Controls.Add(this.pan_opts);
            this.Controls.Add(this.pan_titre);
            this.Name = "CCtrlSelectTousAvecTitre";
            this.Size = new System.Drawing.Size(340, 260);
            this.pan_lst.ResumeLayout(false);
            this.pan_titre.ResumeLayout(false);
            this.pan_titre.PerformLayout();
            this.pan_opts.ResumeLayout(false);
            this.pan_opts.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pan_lst;
		private System.Windows.Forms.Panel pan_titre;
		private System.Windows.Forms.Label lbl_titre;
		private System.Windows.Forms.TextBox txt_titre;
		private System.Windows.Forms.ListView lv_hlps;
		private System.Windows.Forms.ColumnHeader col_titre;
		private System.Windows.Forms.ColumnHeader col_nomcour;
		private System.Windows.Forms.ColumnHeader col_type;
		private System.Windows.Forms.Panel pan_opts;
		private System.Windows.Forms.Timer m_timer;
		private System.Windows.Forms.ComboBox cmb_optrecherche;
		private System.Windows.Forms.CheckBox chk_casesensitive;
		private System.Windows.Forms.Label lbl_optrecherche;
	}
}
