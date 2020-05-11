namespace timos.tables
{
	partial class CFormEditColonneFilter
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

		#region Code généré par le Concepteur Windows Form

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.m_panCtrls = new sc2i.win32.common.C2iPanel(this.components);
			this.m_ctrl = new timos.tables.CCtrlEditColonneFilter();
			this.m_panBtns = new System.Windows.Forms.Panel();
			this.m_btnOk = new System.Windows.Forms.Button();
			this.m_panCtrls.SuspendLayout();
			this.m_panBtns.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_panCtrls
			// 
			this.m_panCtrls.Controls.Add(this.m_ctrl);
			this.m_panCtrls.Controls.Add(this.m_panBtns);
			this.m_panCtrls.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_panCtrls.Location = new System.Drawing.Point(0, 0);
			this.m_panCtrls.LockEdition = false;
			this.m_panCtrls.Name = "m_panCtrls";
			this.m_panCtrls.Size = new System.Drawing.Size(471, 278);
			this.m_panCtrls.TabIndex = 0;
			// 
			// m_ctrl
			// 
			this.m_ctrl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_ctrl.Location = new System.Drawing.Point(0, 0);
			this.m_ctrl.Name = "m_ctrl";
			this.m_ctrl.Size = new System.Drawing.Size(471, 245);
			this.m_ctrl.TabIndex = 0;
			// 
			// m_panBtns
			// 
			this.m_panBtns.Controls.Add(this.m_btnOk);
			this.m_panBtns.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.m_panBtns.Location = new System.Drawing.Point(0, 245);
			this.m_panBtns.Name = "m_panBtns";
			this.m_panBtns.Size = new System.Drawing.Size(471, 33);
			this.m_panBtns.TabIndex = 1;
			// 
			// m_btnOk
			// 
			this.m_btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.m_btnOk.Location = new System.Drawing.Point(194, 6);
			this.m_btnOk.Name = "m_btnOk";
			this.m_btnOk.Size = new System.Drawing.Size(75, 23);
			this.m_btnOk.TabIndex = 0;
			this.m_btnOk.Text = "Ok|10";
			this.m_btnOk.UseVisualStyleBackColor = true;
			this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
			// 
			// CFormEditColonneFilter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(471, 278);
			this.ControlBox = false;
			this.Controls.Add(this.m_panCtrls);
			this.Name = "CFormEditColonneFilter";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Filter edition...|1191";
			this.Load += new System.EventHandler(this.CFormEditColonneFilter_Load);
			this.m_panCtrls.ResumeLayout(false);
			this.m_panBtns.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private sc2i.win32.common.C2iPanel m_panCtrls;
		private CCtrlEditColonneFilter m_ctrl;
		private System.Windows.Forms.Panel m_panBtns;
		private System.Windows.Forms.Button m_btnOk;
	}
}