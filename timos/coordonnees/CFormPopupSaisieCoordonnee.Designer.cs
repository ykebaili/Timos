namespace timos.coordonnees
{
	partial class CFormPopupSaisieCoordonnee
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
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.m_lblParent = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_panelData = new System.Windows.Forms.Panel();
            this.m_lblSystemeCoordonnees = new System.Windows.Forms.Label();
            this.m_panelBas = new System.Windows.Forms.Panel();
            this.m_lblErreur = new System.Windows.Forms.Label();
            this.m_panelBoutons = new System.Windows.Forms.Panel();
            this.m_btnAnnuler = new System.Windows.Forms.Button();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_timerVerif = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.m_panelBas.SuspendLayout();
            this.m_panelBoutons.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_lblParent
            // 
            this.m_lblParent.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_lblParent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblParent.ForeColor = System.Drawing.Color.Beige;
            this.m_lblParent.Location = new System.Drawing.Point(0, 0);
            this.m_lblParent.Name = "m_lblParent";
            this.m_lblParent.Size = new System.Drawing.Size(518, 23);
            this.m_extStyle.SetStyleBackColor(this.m_lblParent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblParent, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTitrePanel);
            this.m_lblParent.TabIndex = 0;
            this.m_lblParent.Text = "TITLE|842";
            this.m_lblParent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.m_panelData);
            this.panel1.Controls.Add(this.m_lblSystemeCoordonnees);
            this.panel1.Controls.Add(this.m_panelBas);
            this.panel1.Controls.Add(this.m_lblParent);
            this.panel1.Controls.Add(this.m_panelBoutons);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(522, 197);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 1;
            // 
            // m_panelData
            // 
            this.m_panelData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelData.Location = new System.Drawing.Point(0, 36);
            this.m_panelData.Name = "m_panelData";
            this.m_panelData.Size = new System.Drawing.Size(518, 78);
            this.m_extStyle.SetStyleBackColor(this.m_panelData, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelData, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelData.TabIndex = 1;
            // 
            // m_lblSystemeCoordonnees
            // 
            this.m_lblSystemeCoordonnees.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_lblSystemeCoordonnees.Location = new System.Drawing.Point(0, 23);
            this.m_lblSystemeCoordonnees.Name = "m_lblSystemeCoordonnees";
            this.m_lblSystemeCoordonnees.Size = new System.Drawing.Size(518, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblSystemeCoordonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblSystemeCoordonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblSystemeCoordonnees.TabIndex = 4;
            this.m_lblSystemeCoordonnees.Text = "Coordinate system|531";
            this.m_lblSystemeCoordonnees.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_panelBas
            // 
            this.m_panelBas.Controls.Add(this.m_lblErreur);
            this.m_panelBas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_panelBas.Location = new System.Drawing.Point(0, 114);
            this.m_panelBas.Name = "m_panelBas";
            this.m_panelBas.Size = new System.Drawing.Size(518, 47);
            this.m_extStyle.SetStyleBackColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelBas.TabIndex = 2;
            // 
            // m_lblErreur
            // 
            this.m_lblErreur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lblErreur.Location = new System.Drawing.Point(0, 0);
            this.m_lblErreur.Name = "m_lblErreur";
            this.m_lblErreur.Size = new System.Drawing.Size(518, 47);
            this.m_extStyle.SetStyleBackColor(this.m_lblErreur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblErreur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblErreur.TabIndex = 0;
            // 
            // m_panelBoutons
            // 
            this.m_panelBoutons.Controls.Add(this.m_btnAnnuler);
            this.m_panelBoutons.Controls.Add(this.m_btnOk);
            this.m_panelBoutons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_panelBoutons.Location = new System.Drawing.Point(0, 161);
            this.m_panelBoutons.Name = "m_panelBoutons";
            this.m_panelBoutons.Size = new System.Drawing.Size(518, 32);
            this.m_extStyle.SetStyleBackColor(this.m_panelBoutons, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelBoutons, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelBoutons.TabIndex = 3;
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnAnnuler.Location = new System.Drawing.Point(267, 4);
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(74, 25);
            this.m_extStyle.SetStyleBackColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAnnuler.TabIndex = 1;
            this.m_btnAnnuler.Text = "Cancel|11";
            this.m_btnAnnuler.UseVisualStyleBackColor = true;
            // 
            // m_btnOk
            // 
            this.m_btnOk.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnOk.Location = new System.Drawing.Point(178, 4);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(74, 25);
            this.m_extStyle.SetStyleBackColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnOk.TabIndex = 0;
            this.m_btnOk.Text = "Ok|10";
            this.m_btnOk.UseVisualStyleBackColor = true;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            // 
            // m_timerVerif
            // 
            this.m_timerVerif.Interval = 200;
            this.m_timerVerif.Tick += new System.EventHandler(this.m_timerVerif_Tick);
            // 
            // CFormPopupSaisieCoordonnee
            // 
            this.AcceptButton = this.m_btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.m_btnAnnuler;
            this.ClientSize = new System.Drawing.Size(522, 197);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CFormPopupSaisieCoordonnee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.Text = "CFormPopupSaisieCoordonnee";
            this.Load += new System.EventHandler(this.CFormPopupSaisieCoordonnee_Load);
            this.panel1.ResumeLayout(false);
            this.m_panelBas.ResumeLayout(false);
            this.m_panelBoutons.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private sc2i.win32.common.CExtStyle m_extStyle;
		private System.Windows.Forms.Label m_lblParent;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel m_panelData;
		private System.Windows.Forms.Panel m_panelBas;
		private System.Windows.Forms.Label m_lblErreur;
		private System.Windows.Forms.Panel m_panelBoutons;
		private System.Windows.Forms.Button m_btnAnnuler;
		private System.Windows.Forms.Button m_btnOk;
		private System.Windows.Forms.Timer m_timerVerif;
		private System.Windows.Forms.Label m_lblSystemeCoordonnees;
	}
}