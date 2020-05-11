namespace timos.version
{
	partial class CControlChampCustom
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
			this.m_pan = new System.Windows.Forms.Panel();
			this.m_lnk = new System.Windows.Forms.LinkLabel();
			this.m_pan.SuspendLayout();
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
			// m_pan
			// 
			this.m_pan.Controls.Add(this.m_lnk);
			this.m_pan.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_pan.Location = new System.Drawing.Point(0, 0);
			this.m_pan.Name = "m_pan";
			this.m_pan.Size = new System.Drawing.Size(180, 74);
			this.m_pan.TabIndex = 4027;
			// 
			// m_lnk
			// 
			this.m_lnk.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lnk.Location = new System.Drawing.Point(0, 0);
			this.m_lnk.Name = "m_lnk";
			this.m_lnk.Size = new System.Drawing.Size(180, 74);
			this.m_lnk.TabIndex = 0;
			this.m_lnk.TabStop = true;
			this.m_lnk.Text = "linkLabel1";
			this.m_lnk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.m_lnk.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnk_LinkClicked);
			// 
			// CControlChampCustom
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.m_pan);
			this.Name = "CControlChampCustom";
			this.Size = new System.Drawing.Size(180, 74);
			this.m_pan.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel m_pan;
		private sc2i.win32.common.ListViewAutoFilledColumn colNomType;
		private sc2i.win32.common.ListViewAutoFilledColumn colEntiteDescription;
		private sc2i.win32.common.ListViewAutoFilledColumn colEntiteType;
		private sc2i.win32.common.ListViewAutoFilledColumn colOperation;
		private sc2i.win32.common.ListViewAutoFilledColumn colChamp;
		private sc2i.win32.common.ListViewAutoFilledColumn colValSource;
		private sc2i.win32.common.ListViewAutoFilledColumn colValCible;
		private System.Windows.Forms.LinkLabel m_lnk;

	}
}
