namespace timos.Controles
{
	partial class CControleUsersMessagesInstantanes
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CControleUsersMessagesInstantanes));
			this.m_wndListeUsers = new System.Windows.Forms.ListView();
			this.m_colonneUser = new System.Windows.Forms.ColumnHeader();
			this.m_images = new System.Windows.Forms.ImageList(this.components);
			this.SuspendLayout();
			// 
			// m_wndListeUsers
			// 
			this.m_wndListeUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_colonneUser});
			this.m_wndListeUsers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_wndListeUsers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_wndListeUsers.Location = new System.Drawing.Point(0, 0);
			this.m_wndListeUsers.Name = "m_wndListeUsers";
			this.m_wndListeUsers.Size = new System.Drawing.Size(192, 308);
			this.m_wndListeUsers.SmallImageList = this.m_images;
			this.m_wndListeUsers.TabIndex = 0;
			this.m_wndListeUsers.UseCompatibleStateImageBehavior = false;
			this.m_wndListeUsers.View = System.Windows.Forms.View.Details;
			this.m_wndListeUsers.SizeChanged += new System.EventHandler(this.m_wndListeUsers_SizeChanged);
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
			// CControleUsersMessagesInstantanes
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.m_wndListeUsers);
			this.Name = "CControleUsersMessagesInstantanes";
			this.Size = new System.Drawing.Size(192, 308);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView m_wndListeUsers;
		private System.Windows.Forms.ColumnHeader m_colonneUser;
		private System.Windows.Forms.ImageList m_images;
	}
}
