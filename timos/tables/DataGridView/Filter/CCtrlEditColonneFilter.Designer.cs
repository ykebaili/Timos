namespace timos.tables
{
	partial class CCtrlEditColonneFilter
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CCtrlEditColonneFilter));
			this.m_ctrlOU = new timos.tables.CCtrlEditListeColonneFilter();
			this.m_panOu = new System.Windows.Forms.Panel();
			this.m_lblOu = new System.Windows.Forms.Label();
			this.m_ctrlET = new timos.tables.CCtrlEditListeColonneFilter();
			this.m_panEt = new System.Windows.Forms.Panel();
			this.m_lblConditions = new System.Windows.Forms.Label();
			this.m_panG = new System.Windows.Forms.Panel();
			this.m_panD = new System.Windows.Forms.Panel();
			this.m_panOu.SuspendLayout();
			this.m_panEt.SuspendLayout();
			this.m_panG.SuspendLayout();
			this.m_panD.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_ctrlOU
			// 
			this.m_ctrlOU.AjoutPossible = true;
			this.m_ctrlOU.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_ctrlOU.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_ctrlOU.ElementsSelectionnes = ((System.Collections.Generic.List<timos.tables.CDataGridViewColonneFilterComponent>)(resources.GetObject("m_ctrlOU.ElementsSelectionnes")));
			this.m_ctrlOU.Location = new System.Drawing.Point(0, 22);
			this.m_ctrlOU.Name = "m_ctrlOU";
			this.m_ctrlOU.SelectionMultiple = false;
			this.m_ctrlOU.SelectionPossible = true;
			this.m_ctrlOU.Size = new System.Drawing.Size(124, 227);
			this.m_ctrlOU.TabIndex = 2;
			this.m_ctrlOU.ChangementSelection += new System.EventHandler(this.m_ctrlOU_ChangementSelection);
			this.m_ctrlOU.SuppressionElement += new timos.tables.EventHandlerCtrlEditListeColonneFilter(this.m_ctrlOU_SuppressionElement);
			this.m_ctrlOU.AjoutElement += new System.EventHandler(m_ctrlOU_AjoutElement);
			// 
			// m_panOu
			// 
			this.m_panOu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_panOu.Controls.Add(this.m_lblOu);
			this.m_panOu.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_panOu.Location = new System.Drawing.Point(0, 0);
			this.m_panOu.Name = "m_panOu";
			this.m_panOu.Size = new System.Drawing.Size(124, 22);
			this.m_panOu.TabIndex = 1;
			// 
			// m_lblOu
			// 
			this.m_lblOu.Location = new System.Drawing.Point(3, 5);
			this.m_lblOu.Name = "m_lblOu";
			this.m_lblOu.Size = new System.Drawing.Size(114, 15);
			this.m_lblOu.TabIndex = 0;
			this.m_lblOu.Text = "Cases|1188";
			// 
			// m_ctrlET
			// 
			this.m_ctrlET.AjoutPossible = true;
			this.m_ctrlET.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_ctrlET.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_ctrlET.ElementsSelectionnes = ((System.Collections.Generic.List<timos.tables.CDataGridViewColonneFilterComponent>)(resources.GetObject("m_ctrlET.ElementsSelectionnes")));
			this.m_ctrlET.Location = new System.Drawing.Point(0, 22);
			this.m_ctrlET.Name = "m_ctrlET";
			this.m_ctrlET.SelectionMultiple = false;
			this.m_ctrlET.SelectionPossible = true;
			this.m_ctrlET.Size = new System.Drawing.Size(290, 227);
			this.m_ctrlET.TabIndex = 2;
			// 
			// m_panEt
			// 
			this.m_panEt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_panEt.Controls.Add(this.m_lblConditions);
			this.m_panEt.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_panEt.Location = new System.Drawing.Point(0, 0);
			this.m_panEt.Name = "m_panEt";
			this.m_panEt.Size = new System.Drawing.Size(290, 22);
			this.m_panEt.TabIndex = 1;
			// 
			// m_lblConditions
			// 
			this.m_lblConditions.Location = new System.Drawing.Point(3, 5);
			this.m_lblConditions.Name = "m_lblConditions";
			this.m_lblConditions.Size = new System.Drawing.Size(126, 13);
			this.m_lblConditions.TabIndex = 0;
			this.m_lblConditions.Text = "Conditions|1189";
			// 
			// m_panG
			// 
			this.m_panG.Controls.Add(this.m_ctrlOU);
			this.m_panG.Controls.Add(this.m_panOu);
			this.m_panG.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_panG.Location = new System.Drawing.Point(0, 0);
			this.m_panG.Name = "m_panG";
			this.m_panG.Size = new System.Drawing.Size(124, 249);
			this.m_panG.TabIndex = 3;
			// 
			// m_panD
			// 
			this.m_panD.Controls.Add(this.m_ctrlET);
			this.m_panD.Controls.Add(this.m_panEt);
			this.m_panD.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_panD.Location = new System.Drawing.Point(124, 0);
			this.m_panD.Name = "m_panD";
			this.m_panD.Size = new System.Drawing.Size(290, 249);
			this.m_panD.TabIndex = 3;
			// 
			// CCtrlEditColonneFilter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.m_panD);
			this.Controls.Add(this.m_panG);
			this.Name = "CCtrlEditColonneFilter";
			this.Size = new System.Drawing.Size(414, 249);
			this.m_panOu.ResumeLayout(false);
			this.m_panEt.ResumeLayout(false);
			this.m_panG.ResumeLayout(false);
			this.m_panD.ResumeLayout(false);
			this.ResumeLayout(false);

		}





		#endregion

		private System.Windows.Forms.Panel m_panOu;
		private System.Windows.Forms.Panel m_panEt;
		private System.Windows.Forms.Label m_lblOu;
		private System.Windows.Forms.Label m_lblConditions;
		private CCtrlEditListeColonneFilter m_ctrlOU;
		private CCtrlEditListeColonneFilter m_ctrlET;
		private System.Windows.Forms.Panel m_panG;
		private System.Windows.Forms.Panel m_panD;
	}
}
