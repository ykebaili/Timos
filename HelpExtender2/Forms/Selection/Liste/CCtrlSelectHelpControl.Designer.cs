namespace HelpExtender
{
	partial class CCtrlSelectHelpControl
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
			this.lv_ = new System.Windows.Forms.ListView();
			this.pan_ctrls = new System.Windows.Forms.Panel();
			this.tv_ctrls = new System.Windows.Forms.TreeView();
			this.pan_ctrls.SuspendLayout();
			this.SuspendLayout();
			// 
			// lv_
			// 
			this.lv_.FullRowSelect = true;
			this.lv_.GridLines = true;
			this.lv_.Location = new System.Drawing.Point(281, 116);
			this.lv_.Name = "lv_";
			this.lv_.Size = new System.Drawing.Size(152, 124);
			this.lv_.TabIndex = 0;
			this.lv_.UseCompatibleStateImageBehavior = false;
			this.lv_.View = System.Windows.Forms.View.Details;
			// 
			// pan_ctrls
			// 
			this.pan_ctrls.Controls.Add(this.tv_ctrls);
			this.pan_ctrls.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pan_ctrls.Location = new System.Drawing.Point(0, 0);
			this.pan_ctrls.Name = "pan_ctrls";
			this.pan_ctrls.Size = new System.Drawing.Size(436, 243);
			this.pan_ctrls.TabIndex = 1;
			// 
			// tv_ctrls
			// 
			this.tv_ctrls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tv_ctrls.Location = new System.Drawing.Point(3, 3);
			this.tv_ctrls.Name = "tv_ctrls";
			this.tv_ctrls.Size = new System.Drawing.Size(430, 237);
			this.tv_ctrls.TabIndex = 0;
			this.tv_ctrls.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tv_ctrls_NodeMouseDoubleClick);
			this.tv_ctrls.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_ctrls_AfterSelect);
			// 
			// CCtrlSelectHelpControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.pan_ctrls);
			this.Controls.Add(this.lv_);
			this.Name = "CCtrlSelectHelpControl";
			this.Size = new System.Drawing.Size(436, 243);
			this.pan_ctrls.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView lv_;
		private System.Windows.Forms.Panel pan_ctrls;
		private System.Windows.Forms.TreeView tv_ctrls;
	}
}
