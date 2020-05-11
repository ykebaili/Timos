namespace timos.win32.composants
{
	partial class CFormCheckListPopup
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
			this.cExtStyle1 = new sc2i.win32.common.CExtStyle();
			this.c2iPanelOmbre1 = new sc2i.win32.common.C2iPanelOmbre();
			this.m_panelCheckList = new timos.win32.composants.planning.CControleCheckListIntervention();
			this.m_btnOk = new System.Windows.Forms.Button();
			this.c2iPanelOmbre1.SuspendLayout();
			this.SuspendLayout();
			// 
			// c2iPanelOmbre1
			// 
			this.c2iPanelOmbre1.Controls.Add(this.m_btnOk);
			this.c2iPanelOmbre1.Controls.Add(this.m_panelCheckList);
			this.c2iPanelOmbre1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.c2iPanelOmbre1.Location = new System.Drawing.Point(0, 0);
			this.c2iPanelOmbre1.LockEdition = false;
			this.c2iPanelOmbre1.Name = "c2iPanelOmbre1";
			this.c2iPanelOmbre1.Size = new System.Drawing.Size(334, 254);
			this.cExtStyle1.SetStyleBackColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.cExtStyle1.SetStyleForeColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.c2iPanelOmbre1.TabIndex = 0;
			// 
			// m_panelCheckList
			// 
			this.m_panelCheckList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_panelCheckList.Location = new System.Drawing.Point(0, 0);
			this.m_panelCheckList.LockEdition = false;
			this.m_panelCheckList.Name = "m_panelCheckList";
			this.m_panelCheckList.Size = new System.Drawing.Size(322, 207);
			this.cExtStyle1.SetStyleBackColor(this.m_panelCheckList, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.cExtStyle1.SetStyleForeColor(this.m_panelCheckList, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_panelCheckList.TabIndex = 3;
			// 
			// m_btnOk
			// 
			this.m_btnOk.Location = new System.Drawing.Point(130, 214);
			this.m_btnOk.Name = "m_btnOk";
			this.m_btnOk.Size = new System.Drawing.Size(75, 23);
			this.cExtStyle1.SetStyleBackColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.cExtStyle1.SetStyleForeColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_btnOk.TabIndex = 4;
			this.m_btnOk.Text = "Ok|10";
			this.m_btnOk.UseVisualStyleBackColor = true;
			this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
			// 
			// CFormCheckListPopup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(334, 254);
			this.Controls.Add(this.c2iPanelOmbre1);
			this.ForeColor = System.Drawing.Color.Black;
			this.Name = "CFormCheckListPopup";
			this.cExtStyle1.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
			this.cExtStyle1.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
			this.Text = "CFormCheckListPopup";
			this.c2iPanelOmbre1.ResumeLayout(false);
			this.c2iPanelOmbre1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private sc2i.win32.common.CExtStyle cExtStyle1;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre1;
		private System.Windows.Forms.Button m_btnOk;
		private timos.win32.composants.planning.CControleCheckListIntervention m_panelCheckList;
	}
}