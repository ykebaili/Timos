namespace timos.version
{
	partial class CControlTypeOperationAuditVersion
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
            this.colNomType = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.colEntiteDescription = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.colEntiteType = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.colOperation = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.colChamp = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.colValSource = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.colValCible = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_lbl = new System.Windows.Forms.Label();
            this.m_panIco = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // colNomType
            // 
            this.colNomType.Field = "";
            this.colNomType.PrecisionWidth = 158;
            this.colNomType.ProportionnalSize = true;
            this.colNomType.Text = "Label|50";
            this.colNomType.Visible = true;
            this.colNomType.Width = 158;
            // 
            // colEntiteDescription
            // 
            this.colEntiteDescription.Field = "";
            this.colEntiteDescription.PrecisionWidth = 105.5;
            this.colEntiteDescription.ProportionnalSize = true;
            this.colEntiteDescription.Text = "Description Element";
            this.colEntiteDescription.Visible = true;
            this.colEntiteDescription.Width = 105;
            // 
            // colEntiteType
            // 
            this.colEntiteType.Field = "";
            this.colEntiteType.PrecisionWidth = 105.5;
            this.colEntiteType.ProportionnalSize = true;
            this.colEntiteType.Text = "Type|30284";
            this.colEntiteType.Visible = true;
            this.colEntiteType.Width = 105;
            // 
            // colOperation
            // 
            this.colOperation.Field = "";
            this.colOperation.PrecisionWidth = 135.25;
            this.colOperation.ProportionnalSize = true;
            this.colOperation.Text = "Type Opération";
            this.colOperation.Visible = true;
            this.colOperation.Width = 135;
            // 
            // colChamp
            // 
            this.colChamp.Field = "";
            this.colChamp.PrecisionWidth = 135.25;
            this.colChamp.ProportionnalSize = true;
            this.colChamp.Text = "Champ";
            this.colChamp.Visible = true;
            this.colChamp.Width = 135;
            // 
            // colValSource
            // 
            this.colValSource.Field = "";
            this.colValSource.PrecisionWidth = 135.25;
            this.colValSource.ProportionnalSize = true;
            this.colValSource.Text = "Valeur Source";
            this.colValSource.Visible = true;
            this.colValSource.Width = 135;
            // 
            // colValCible
            // 
            this.colValCible.Field = "";
            this.colValCible.PrecisionWidth = 135.25;
            this.colValCible.ProportionnalSize = true;
            this.colValCible.Text = "Valeur Cible";
            this.colValCible.Visible = true;
            this.colValCible.Width = 135;
            // 
            // m_lbl
            // 
            this.m_lbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lbl.Location = new System.Drawing.Point(28, 0);
            this.m_lbl.Name = "m_lbl";
            this.m_lbl.Size = new System.Drawing.Size(57, 47);
            this.m_lbl.TabIndex = 0;
            this.m_lbl.Text = "Op type|882";
            this.m_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_panIco
            // 
            this.m_panIco.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_panIco.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panIco.Location = new System.Drawing.Point(0, 0);
            this.m_panIco.Name = "m_panIco";
            this.m_panIco.Size = new System.Drawing.Size(28, 47);
            this.m_panIco.TabIndex = 1;
            // 
            // CControlTypeOperationAuditVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_lbl);
            this.Controls.Add(this.m_panIco);
            this.Name = "CControlTypeOperationAuditVersion";
            this.Size = new System.Drawing.Size(85, 47);
            this.ResumeLayout(false);

		}

		#endregion

		private sc2i.win32.common.ListViewAutoFilledColumn colNomType;
		private sc2i.win32.common.ListViewAutoFilledColumn colEntiteDescription;
		private sc2i.win32.common.ListViewAutoFilledColumn colEntiteType;
		private sc2i.win32.common.ListViewAutoFilledColumn colOperation;
		private sc2i.win32.common.ListViewAutoFilledColumn colChamp;
		private sc2i.win32.common.ListViewAutoFilledColumn colValSource;
		private sc2i.win32.common.ListViewAutoFilledColumn colValCible;
		private System.Windows.Forms.Label m_lbl;
		private System.Windows.Forms.Panel m_panIco;

	}
}
