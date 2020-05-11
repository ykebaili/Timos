namespace timos
{
	partial class CControlEditMappage
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
            this.m_spc = new System.Windows.Forms.SplitContainer();
            this.m_lblTitre1 = new System.Windows.Forms.Label();
            this.m_lblTitre2 = new System.Windows.Forms.Label();
            this.m_spc.Panel1.SuspendLayout();
            this.m_spc.Panel2.SuspendLayout();
            this.m_spc.SuspendLayout();
            this.SuspendLayout();
            // 
            // colNomType
            // 
            this.colNomType.Field = "";
            this.colNomType.PrecisionWidth = 158;
            this.colNomType.ProportionnalSize = true;
            this.colNomType.Text = "Name|50";
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
            // m_spc
            // 
            this.m_spc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_spc.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_spc.Location = new System.Drawing.Point(0, 0);
            this.m_spc.Name = "m_spc";
            // 
            // m_spc.Panel1
            // 
            this.m_spc.Panel1.Controls.Add(this.m_lblTitre1);
            // 
            // m_spc.Panel2
            // 
            this.m_spc.Panel2.Controls.Add(this.m_lblTitre2);
            this.m_spc.Size = new System.Drawing.Size(347, 288);
            this.m_spc.SplitterDistance = 143;
            this.m_spc.TabIndex = 0;
            // 
            // m_lblTitre1
            // 
            this.m_lblTitre1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.m_lblTitre1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblTitre1.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_lblTitre1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblTitre1.Location = new System.Drawing.Point(0, 0);
            this.m_lblTitre1.Name = "m_lblTitre1";
            this.m_lblTitre1.Size = new System.Drawing.Size(141, 23);
            this.m_lblTitre1.TabIndex = 1;
            this.m_lblTitre1.Text = "Source columns|30013";
            this.m_lblTitre1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_lblTitre2
            // 
            this.m_lblTitre2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.m_lblTitre2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblTitre2.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_lblTitre2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblTitre2.Location = new System.Drawing.Point(0, 0);
            this.m_lblTitre2.Name = "m_lblTitre2";
            this.m_lblTitre2.Size = new System.Drawing.Size(198, 23);
            this.m_lblTitre2.TabIndex = 0;
            this.m_lblTitre2.Text = "Target columns|30014";
            this.m_lblTitre2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CControlEditMappage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.Controls.Add(this.m_spc);
            this.Name = "CControlEditMappage";
            this.Size = new System.Drawing.Size(347, 288);
            this.m_spc.Panel1.ResumeLayout(false);
            this.m_spc.Panel2.ResumeLayout(false);
            this.m_spc.ResumeLayout(false);
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
		private System.Windows.Forms.SplitContainer m_spc;
		private System.Windows.Forms.Label m_lblTitre1;
		private System.Windows.Forms.Label m_lblTitre2;

	}
}
