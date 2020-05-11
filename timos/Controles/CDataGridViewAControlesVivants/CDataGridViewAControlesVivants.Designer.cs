namespace timos
{
	partial class CDataGridViewAControlesVivants
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
			this.m_pan = new System.Windows.Forms.Panel();
			this.m_dgv = new System.Windows.Forms.DataGridView();
			this.m_pan.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_dgv)).BeginInit();
			this.SuspendLayout();
			// 
			// m_pan
			// 
			this.m_pan.Controls.Add(this.m_dgv);
			this.m_pan.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_pan.Location = new System.Drawing.Point(0, 0);
			this.m_pan.Name = "m_pan";
			this.m_pan.Size = new System.Drawing.Size(422, 223);
			this.m_pan.TabIndex = 4027;
			// 
			// m_dgv
			// 
			this.m_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.m_dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_dgv.Location = new System.Drawing.Point(0, 0);
			this.m_dgv.Name = "m_dgv";
			this.m_dgv.RowHeadersVisible = false;
			this.m_dgv.Size = new System.Drawing.Size(422, 223);
			this.m_dgv.TabIndex = 0;
			this.m_dgv.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgv_CellMouseLeave);
			this.m_dgv.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.m_dgv_CellPainting);
			this.m_dgv.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgv_CellMouseEnter);
			this.m_dgv.MouseLeave += new System.EventHandler(this.m_dgv_MouseLeave);
			this.m_dgv.DataSourceChanged += new System.EventHandler(this.m_dgv_DataSourceChanged);
			// 
			// CDataGridViewAControlesVivants
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.m_pan);
			this.Name = "CDataGridViewAControlesVivants";
			this.Size = new System.Drawing.Size(422, 223);
			this.m_pan.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_dgv)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel m_pan;
		private System.Windows.Forms.DataGridView m_dgv;

	}
}
