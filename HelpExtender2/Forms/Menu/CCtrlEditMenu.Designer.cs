namespace HelpExtender
{
	partial class CCtrlEditMenu
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
            this.m_arbreMenu = new System.Windows.Forms.TreeView();
            this.pan_menu = new System.Windows.Forms.Panel();
            this.pan_cmds = new System.Windows.Forms.Panel();
            this.btn_down = new System.Windows.Forms.Button();
            this.btn_up = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.pan_edit = new System.Windows.Forms.Panel();
            this.m_btnNoHelpLiee = new System.Windows.Forms.Button();
            this.m_btnSelectHelp = new System.Windows.Forms.Button();
            this.m_lblHelpLiee = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_descrip = new System.Windows.Forms.TextBox();
            this.txt_nom = new System.Windows.Forms.TextBox();
            this.lbl_descrip = new System.Windows.Forms.Label();
            this.lbl_nom = new System.Windows.Forms.Label();
            this.m_menuArbre = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_menuAjouter = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuSupprimer = new System.Windows.Forms.ToolStripMenuItem();
            this.pan_menu.SuspendLayout();
            this.pan_cmds.SuspendLayout();
            this.pan_edit.SuspendLayout();
            this.m_menuArbre.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_arbreMenu
            // 
            this.m_arbreMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_arbreMenu.HideSelection = false;
            this.m_arbreMenu.Location = new System.Drawing.Point(0, 0);
            this.m_arbreMenu.Name = "m_arbreMenu";
            this.m_arbreMenu.Size = new System.Drawing.Size(308, 312);
            this.m_arbreMenu.TabIndex = 0;
            this.m_arbreMenu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_menu_AfterSelect);
            this.m_arbreMenu.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.m_arbreMenu_NodeMouseClick);
            this.m_arbreMenu.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.m_arbreMenu_AfterExpand);
            // 
            // pan_menu
            // 
            this.pan_menu.Controls.Add(this.m_arbreMenu);
            this.pan_menu.Controls.Add(this.pan_cmds);
            this.pan_menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pan_menu.Location = new System.Drawing.Point(0, 0);
            this.pan_menu.Name = "pan_menu";
            this.pan_menu.Size = new System.Drawing.Size(308, 340);
            this.pan_menu.TabIndex = 1;
            // 
            // pan_cmds
            // 
            this.pan_cmds.Controls.Add(this.btn_down);
            this.pan_cmds.Controls.Add(this.btn_up);
            this.pan_cmds.Controls.Add(this.btn_add);
            this.pan_cmds.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pan_cmds.Location = new System.Drawing.Point(0, 312);
            this.pan_cmds.Name = "pan_cmds";
            this.pan_cmds.Size = new System.Drawing.Size(308, 28);
            this.pan_cmds.TabIndex = 3;
            // 
            // btn_down
            // 
            this.btn_down.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_down.Location = new System.Drawing.Point(155, 3);
            this.btn_down.Name = "btn_down";
            this.btn_down.Size = new System.Drawing.Size(33, 23);
            this.btn_down.TabIndex = 0;
            this.btn_down.Text = "\\/";
            this.btn_down.UseVisualStyleBackColor = true;
            this.btn_down.Click += new System.EventHandler(this.btn_down_Click);
            // 
            // btn_up
            // 
            this.btn_up.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_up.Location = new System.Drawing.Point(116, 3);
            this.btn_up.Name = "btn_up";
            this.btn_up.Size = new System.Drawing.Size(33, 23);
            this.btn_up.TabIndex = 0;
            this.btn_up.Text = "/\\";
            this.btn_up.UseVisualStyleBackColor = true;
            this.btn_up.Click += new System.EventHandler(this.btn_up_Click);
            // 
            // btn_add
            // 
            this.btn_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_add.Location = new System.Drawing.Point(3, 3);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 0;
            this.btn_add.Text = "Ajouter";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // pan_edit
            // 
            this.pan_edit.Controls.Add(this.m_btnNoHelpLiee);
            this.pan_edit.Controls.Add(this.m_btnSelectHelp);
            this.pan_edit.Controls.Add(this.m_lblHelpLiee);
            this.pan_edit.Controls.Add(this.label1);
            this.pan_edit.Controls.Add(this.txt_descrip);
            this.pan_edit.Controls.Add(this.txt_nom);
            this.pan_edit.Controls.Add(this.lbl_descrip);
            this.pan_edit.Controls.Add(this.lbl_nom);
            this.pan_edit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_edit.Location = new System.Drawing.Point(308, 0);
            this.pan_edit.Name = "pan_edit";
            this.pan_edit.Size = new System.Drawing.Size(268, 340);
            this.pan_edit.TabIndex = 2;
            // 
            // m_btnNoHelpLiee
            // 
            this.m_btnNoHelpLiee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnNoHelpLiee.Location = new System.Drawing.Point(247, 169);
            this.m_btnNoHelpLiee.Name = "m_btnNoHelpLiee";
            this.m_btnNoHelpLiee.Size = new System.Drawing.Size(18, 28);
            this.m_btnNoHelpLiee.TabIndex = 6;
            this.m_btnNoHelpLiee.Text = "x";
            this.m_btnNoHelpLiee.UseVisualStyleBackColor = true;
            this.m_btnNoHelpLiee.Click += new System.EventHandler(this.m_btnNoHelpLiee_Click);
            // 
            // m_btnSelectHelp
            // 
            this.m_btnSelectHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnSelectHelp.Location = new System.Drawing.Point(232, 169);
            this.m_btnSelectHelp.Name = "m_btnSelectHelp";
            this.m_btnSelectHelp.Size = new System.Drawing.Size(18, 28);
            this.m_btnSelectHelp.TabIndex = 5;
            this.m_btnSelectHelp.Text = "...";
            this.m_btnSelectHelp.UseVisualStyleBackColor = true;
            this.m_btnSelectHelp.Click += new System.EventHandler(this.m_btnSelectHelp_Click);
            // 
            // m_lblHelpLiee
            // 
            this.m_lblHelpLiee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblHelpLiee.BackColor = System.Drawing.Color.White;
            this.m_lblHelpLiee.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblHelpLiee.Location = new System.Drawing.Point(9, 169);
            this.m_lblHelpLiee.Name = "m_lblHelpLiee";
            this.m_lblHelpLiee.Size = new System.Drawing.Size(223, 28);
            this.m_lblHelpLiee.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Linked Document |30038";
            // 
            // txt_descrip
            // 
            this.txt_descrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_descrip.Location = new System.Drawing.Point(6, 53);
            this.txt_descrip.Multiline = true;
            this.txt_descrip.Name = "txt_descrip";
            this.txt_descrip.Size = new System.Drawing.Size(259, 87);
            this.txt_descrip.TabIndex = 2;
            this.txt_descrip.Validated += new System.EventHandler(this.txt_descrip_Validated);
            // 
            // txt_nom
            // 
            this.txt_nom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_nom.Location = new System.Drawing.Point(76, 9);
            this.txt_nom.Name = "txt_nom";
            this.txt_nom.Size = new System.Drawing.Size(189, 20);
            this.txt_nom.TabIndex = 2;
            this.txt_nom.Validated += new System.EventHandler(this.txt_nom_Validated);
            // 
            // lbl_descrip
            // 
            this.lbl_descrip.AutoSize = true;
            this.lbl_descrip.Location = new System.Drawing.Point(6, 37);
            this.lbl_descrip.Name = "lbl_descrip";
            this.lbl_descrip.Size = new System.Drawing.Size(95, 13);
            this.lbl_descrip.TabIndex = 1;
            this.lbl_descrip.Text = "Description |30037";
            // 
            // lbl_nom
            // 
            this.lbl_nom.AutoSize = true;
            this.lbl_nom.Location = new System.Drawing.Point(6, 12);
            this.lbl_nom.Name = "lbl_nom";
            this.lbl_nom.Size = new System.Drawing.Size(95, 13);
            this.lbl_nom.TabIndex = 1;
            this.lbl_nom.Text = "Menu name|30036";
            // 
            // m_menuArbre
            // 
            this.m_menuArbre.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_menuAjouter,
            this.m_menuSupprimer});
            this.m_menuArbre.Name = "m_menuArbre";
            this.m_menuArbre.Size = new System.Drawing.Size(134, 48);
            // 
            // m_menuAjouter
            // 
            this.m_menuAjouter.Name = "m_menuAjouter";
            this.m_menuAjouter.Size = new System.Drawing.Size(133, 22);
            this.m_menuAjouter.Text = "&Ajouter";
            this.m_menuAjouter.Click += new System.EventHandler(this.m_menuAjouter_Click);
            // 
            // m_menuSupprimer
            // 
            this.m_menuSupprimer.Name = "m_menuSupprimer";
            this.m_menuSupprimer.Size = new System.Drawing.Size(133, 22);
            this.m_menuSupprimer.Text = "&Supprimer";
            this.m_menuSupprimer.Click += new System.EventHandler(this.m_menuSupprimer_Click);
            // 
            // CCtrlEditMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pan_edit);
            this.Controls.Add(this.pan_menu);
            this.Name = "CCtrlEditMenu";
            this.Size = new System.Drawing.Size(576, 340);
            this.pan_menu.ResumeLayout(false);
            this.pan_cmds.ResumeLayout(false);
            this.pan_edit.ResumeLayout(false);
            this.pan_edit.PerformLayout();
            this.m_menuArbre.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TreeView m_arbreMenu;
		private System.Windows.Forms.Panel pan_menu;
		private System.Windows.Forms.Panel pan_edit;
		private System.Windows.Forms.Panel pan_cmds;
		private System.Windows.Forms.Button btn_add;
		private System.Windows.Forms.Button btn_down;
		private System.Windows.Forms.Button btn_up;
		private System.Windows.Forms.TextBox txt_nom;
		private System.Windows.Forms.Label lbl_descrip;
		private System.Windows.Forms.Label lbl_nom;
		private System.Windows.Forms.TextBox txt_descrip;
		private System.Windows.Forms.Button m_btnNoHelpLiee;
		private System.Windows.Forms.Button m_btnSelectHelp;
		private System.Windows.Forms.Label m_lblHelpLiee;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ContextMenuStrip m_menuArbre;
		private System.Windows.Forms.ToolStripMenuItem m_menuAjouter;
		private System.Windows.Forms.ToolStripMenuItem m_menuSupprimer;
	}
}
