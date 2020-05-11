namespace timos.tables
{
	partial class CCtrlEditColonneFilterTest
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
            this.split = new System.Windows.Forms.SplitContainer();
            this.m_panBorder1 = new System.Windows.Forms.Panel();
            this.m_cmbOperator = new sc2i.win32.common.C2iComboBox();
            this.m_panBorder2 = new System.Windows.Forms.Panel();
            this.m_ctrlEdit = new timos.tables.CCtrlEditSelonType();
            this.split.Panel1.SuspendLayout();
            this.split.Panel2.SuspendLayout();
            this.split.SuspendLayout();
            this.m_panBorder1.SuspendLayout();
            this.m_panBorder2.SuspendLayout();
            this.SuspendLayout();
            // 
            // split
            // 
            this.split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split.IsSplitterFixed = true;
            this.split.Location = new System.Drawing.Point(0, 0);
            this.split.Name = "split";
            // 
            // split.Panel1
            // 
            this.split.Panel1.Controls.Add(this.m_panBorder1);
            // 
            // split.Panel2
            // 
            this.split.Panel2.Controls.Add(this.m_panBorder2);
            this.split.Size = new System.Drawing.Size(402, 20);
            this.split.SplitterDistance = 200;
            this.split.SplitterWidth = 2;
            this.split.TabIndex = 1;
            // 
            // m_panBorder1
            // 
            this.m_panBorder1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panBorder1.Controls.Add(this.m_cmbOperator);
            this.m_panBorder1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panBorder1.Location = new System.Drawing.Point(0, 0);
            this.m_panBorder1.Name = "m_panBorder1";
            this.m_panBorder1.Size = new System.Drawing.Size(200, 20);
            this.m_panBorder1.TabIndex = 1;
            // 
            // m_cmbOperator
            // 
            this.m_cmbOperator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_cmbOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbOperator.FormattingEnabled = true;
            this.m_cmbOperator.IsLink = false;
            this.m_cmbOperator.Location = new System.Drawing.Point(0, 0);
            this.m_cmbOperator.LockEdition = false;
            this.m_cmbOperator.Name = "m_cmbOperator";
            this.m_cmbOperator.Size = new System.Drawing.Size(198, 21);
            this.m_cmbOperator.TabIndex = 0;
            this.m_cmbOperator.SelectionChangeCommitted += new System.EventHandler(this.m_cmbOperator_SelectionChangeCommitted);
            // 
            // m_panBorder2
            // 
            this.m_panBorder2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panBorder2.Controls.Add(this.m_ctrlEdit);
            this.m_panBorder2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panBorder2.Location = new System.Drawing.Point(0, 0);
            this.m_panBorder2.Name = "m_panBorder2";
            this.m_panBorder2.Size = new System.Drawing.Size(200, 20);
            this.m_panBorder2.TabIndex = 1;
            // 
            // m_ctrlEdit
            // 
            this.m_ctrlEdit.DefaultValue = "";
            this.m_ctrlEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_ctrlEdit.EditingControlDataGridView = null;
            this.m_ctrlEdit.EditingControlFormattedValue = null;
            this.m_ctrlEdit.EditingControlRowIndex = 0;
            this.m_ctrlEdit.EditingControlValueChanged = false;
            this.m_ctrlEdit.Location = new System.Drawing.Point(0, 0);
            this.m_ctrlEdit.Name = "m_ctrlEdit";
            this.m_ctrlEdit.Size = new System.Drawing.Size(198, 18);
            this.m_ctrlEdit.TabIndex = 0;
            this.m_ctrlEdit.Valeur = null;
            this.m_ctrlEdit.ChangementValeur += new System.EventHandler(this.m_ctrlEdit_ChangementValeur);
            // 
            // CCtrlEditColonneFilterTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.split);
            this.Name = "CCtrlEditColonneFilterTest";
            this.Size = new System.Drawing.Size(402, 20);
            this.split.Panel1.ResumeLayout(false);
            this.split.Panel2.ResumeLayout(false);
            this.split.ResumeLayout(false);
            this.m_panBorder1.ResumeLayout(false);
            this.m_panBorder2.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer split;
		private System.Windows.Forms.Panel m_panBorder1;
		private sc2i.win32.common.C2iComboBox m_cmbOperator;
		private System.Windows.Forms.Panel m_panBorder2;
		private CCtrlEditSelonType m_ctrlEdit;

	}
}
