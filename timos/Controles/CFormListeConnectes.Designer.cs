namespace timos
{
	partial class CFormListeConnectes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormListeConnectes));
            this.c2iPanelOmbre1 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_wndListeUsers = new System.Windows.Forms.ListView();
            this.m_colonneUser = new System.Windows.Forms.ColumnHeader();
            this.m_images = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cExtStyle1 = new sc2i.win32.common.CExtStyle();
            this.c2iPanelOmbre1.SuspendLayout();
            this.SuspendLayout();
            // 
            // c2iPanelOmbre1
            // 
            this.c2iPanelOmbre1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre1.Controls.Add(this.m_wndListeUsers);
            this.c2iPanelOmbre1.Controls.Add(this.label1);
            this.c2iPanelOmbre1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c2iPanelOmbre1.ForeColor = System.Drawing.Color.Black;
            this.c2iPanelOmbre1.Location = new System.Drawing.Point(0, 0);
            this.c2iPanelOmbre1.LockEdition = false;
            this.c2iPanelOmbre1.Name = "c2iPanelOmbre1";
            this.c2iPanelOmbre1.Size = new System.Drawing.Size(220, 267);
            this.cExtStyle1.SetStyleBackColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.cExtStyle1.SetStyleForeColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre1.TabIndex = 0;
            // 
            // m_wndListeUsers
            // 
            this.m_wndListeUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_wndListeUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_wndListeUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_colonneUser});
            this.m_wndListeUsers.ForeColor = System.Drawing.Color.Black;
            this.m_wndListeUsers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_wndListeUsers.Location = new System.Drawing.Point(0, 23);
            this.m_wndListeUsers.Name = "m_wndListeUsers";
            this.m_wndListeUsers.Size = new System.Drawing.Size(208, 232);
            this.m_wndListeUsers.SmallImageList = this.m_images;
            this.cExtStyle1.SetStyleBackColor(this.m_wndListeUsers, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.cExtStyle1.SetStyleForeColor(this.m_wndListeUsers, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_wndListeUsers.TabIndex = 3;
            this.m_wndListeUsers.UseCompatibleStateImageBehavior = false;
            this.m_wndListeUsers.View = System.Windows.Forms.View.Details;
            this.m_wndListeUsers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.m_wndListeUsers_MouseDoubleClick);
            // 
            // m_colonneUser
            // 
            this.m_colonneUser.Width = 152;
            // 
            // m_images
            // 
            this.m_images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_images.ImageStream")));
            this.m_images.TransparentColor = System.Drawing.Color.Transparent;
            this.m_images.Images.SetKeyName(0, "messenger.bmp");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 20);
            this.cExtStyle1.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4;
            this.label1.Text = "Connected Users|815";
            // 
            // CFormListeConnectes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(220, 267);
            this.Controls.Add(this.c2iPanelOmbre1);
            this.Name = "CFormListeConnectes";
            this.cExtStyle1.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "CFormListeConnectes";
            this.Load += new System.EventHandler(this.CFormListeConnectes_Load);
            this.c2iPanelOmbre1.ResumeLayout(false);
            this.c2iPanelOmbre1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre1;
		private sc2i.win32.common.CExtStyle cExtStyle1;
		private System.Windows.Forms.ImageList m_images;
		private System.Windows.Forms.ListView m_wndListeUsers;
		private System.Windows.Forms.ColumnHeader m_colonneUser;
		private System.Windows.Forms.Label label1;
	}
}