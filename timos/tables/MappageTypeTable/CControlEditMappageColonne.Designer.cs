namespace timos
{
	partial class CControlEditMappageColonne
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
			this.m_panKey = new System.Windows.Forms.Panel();
			this.m_lblTitreKey = new System.Windows.Forms.Label();
			this.m_panObligatoire = new System.Windows.Forms.Panel();
			this.m_lblTitreNull = new System.Windows.Forms.Label();
			this.m_splitterObligatoire = new System.Windows.Forms.Splitter();
			this.m_panType = new System.Windows.Forms.Panel();
			this.m_lblType = new System.Windows.Forms.Label();
			this.m_lblTitreType = new System.Windows.Forms.Label();
			this.m_splitterType = new System.Windows.Forms.Splitter();
			this.m_splitterKey = new System.Windows.Forms.Splitter();
			this.m_panNom = new System.Windows.Forms.Panel();
			this.m_cmbNom = new System.Windows.Forms.ComboBox();
			this.m_lblNom = new System.Windows.Forms.Label();
			this.m_lblTitreNom = new System.Windows.Forms.Label();
			this.m_panValeur = new System.Windows.Forms.Panel();
			this.m_chkNull = new System.Windows.Forms.CheckBox();
			this.m_ctrlEditVal = new timos.tables.CCtrlEditSelonType();
			this.m_lblTitreValeur = new System.Windows.Forms.Label();
			this.m_panInfo = new System.Windows.Forms.Panel();
			this.m_splitterNom = new System.Windows.Forms.Splitter();
			this.m_panKey.SuspendLayout();
			this.m_panObligatoire.SuspendLayout();
			this.m_panType.SuspendLayout();
			this.m_panNom.SuspendLayout();
			this.m_panValeur.SuspendLayout();
			this.m_panInfo.SuspendLayout();
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
			// m_panKey
			// 
			this.m_panKey.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.m_panKey.Controls.Add(this.m_lblTitreKey);
			this.m_panKey.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_panKey.Location = new System.Drawing.Point(0, 0);
			this.m_panKey.Name = "m_panKey";
			this.m_panKey.Size = new System.Drawing.Size(28, 25);
			this.m_panKey.TabIndex = 1;
			// 
			// m_lblTitreKey
			// 
			this.m_lblTitreKey.BackColor = System.Drawing.Color.Moccasin;
			this.m_lblTitreKey.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lblTitreKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblTitreKey.Location = new System.Drawing.Point(0, 0);
			this.m_lblTitreKey.Name = "m_lblTitreKey";
			this.m_lblTitreKey.Size = new System.Drawing.Size(28, 25);
			this.m_lblTitreKey.TabIndex = 0;
			this.m_lblTitreKey.Text = "Key|43";
			this.m_lblTitreKey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.m_lblTitreKey.Visible = false;
			// 
			// m_panObligatoire
			// 
			this.m_panObligatoire.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.m_panObligatoire.Controls.Add(this.m_lblTitreNull);
			this.m_panObligatoire.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_panObligatoire.Location = new System.Drawing.Point(29, 0);
			this.m_panObligatoire.Name = "m_panObligatoire";
			this.m_panObligatoire.Size = new System.Drawing.Size(29, 25);
			this.m_panObligatoire.TabIndex = 2;
			// 
			// m_lblTitreNull
			// 
			this.m_lblTitreNull.BackColor = System.Drawing.Color.Moccasin;
			this.m_lblTitreNull.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lblTitreNull.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblTitreNull.Location = new System.Drawing.Point(0, 0);
			this.m_lblTitreNull.Name = "m_lblTitreNull";
			this.m_lblTitreNull.Size = new System.Drawing.Size(29, 25);
			this.m_lblTitreNull.TabIndex = 1;
			this.m_lblTitreNull.Text = "Is Null|96";
			this.m_lblTitreNull.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.m_lblTitreNull.Visible = false;
			// 
			// m_splitterObligatoire
			// 
			this.m_splitterObligatoire.BackColor = System.Drawing.SystemColors.ControlText;
			this.m_splitterObligatoire.Enabled = false;
			this.m_splitterObligatoire.Location = new System.Drawing.Point(58, 0);
			this.m_splitterObligatoire.Name = "m_splitterObligatoire";
			this.m_splitterObligatoire.Size = new System.Drawing.Size(1, 25);
			this.m_splitterObligatoire.TabIndex = 3;
			this.m_splitterObligatoire.TabStop = false;
			// 
			// m_panType
			// 
			this.m_panType.Controls.Add(this.m_lblType);
			this.m_panType.Controls.Add(this.m_lblTitreType);
			this.m_panType.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_panType.Location = new System.Drawing.Point(59, 0);
			this.m_panType.Name = "m_panType";
			this.m_panType.Size = new System.Drawing.Size(79, 25);
			this.m_panType.TabIndex = 5;
			// 
			// m_lblType
			// 
			this.m_lblType.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lblType.Location = new System.Drawing.Point(0, 0);
			this.m_lblType.Name = "m_lblType";
			this.m_lblType.Size = new System.Drawing.Size(79, 25);
			this.m_lblType.TabIndex = 0;
			this.m_lblType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_lblTitreType
			// 
			this.m_lblTitreType.BackColor = System.Drawing.Color.Moccasin;
			this.m_lblTitreType.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lblTitreType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblTitreType.Location = new System.Drawing.Point(0, 0);
			this.m_lblTitreType.Name = "m_lblTitreType";
			this.m_lblTitreType.Size = new System.Drawing.Size(79, 25);
			this.m_lblTitreType.TabIndex = 2;
			this.m_lblTitreType.Text = "Type|54";
			this.m_lblTitreType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.m_lblTitreType.Visible = false;
			// 
			// m_splitterType
			// 
			this.m_splitterType.BackColor = System.Drawing.SystemColors.ControlText;
			this.m_splitterType.Enabled = false;
			this.m_splitterType.Location = new System.Drawing.Point(138, 0);
			this.m_splitterType.Name = "m_splitterType";
			this.m_splitterType.Size = new System.Drawing.Size(1, 25);
			this.m_splitterType.TabIndex = 3;
			this.m_splitterType.TabStop = false;
			// 
			// m_splitterKey
			// 
			this.m_splitterKey.BackColor = System.Drawing.SystemColors.ControlText;
			this.m_splitterKey.Enabled = false;
			this.m_splitterKey.Location = new System.Drawing.Point(28, 0);
			this.m_splitterKey.Name = "m_splitterKey";
			this.m_splitterKey.Size = new System.Drawing.Size(1, 25);
			this.m_splitterKey.TabIndex = 6;
			this.m_splitterKey.TabStop = false;
			// 
			// m_panNom
			// 
			this.m_panNom.Controls.Add(this.m_cmbNom);
			this.m_panNom.Controls.Add(this.m_lblNom);
			this.m_panNom.Controls.Add(this.m_lblTitreNom);
			this.m_panNom.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_panNom.Location = new System.Drawing.Point(139, 0);
			this.m_panNom.Name = "m_panNom";
			this.m_panNom.Size = new System.Drawing.Size(152, 25);
			this.m_panNom.TabIndex = 7;
			// 
			// m_cmbNom
			// 
			this.m_cmbNom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_cmbNom.DisplayMember = "Libelle";
			this.m_cmbNom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cmbNom.FormattingEnabled = true;
			this.m_cmbNom.Location = new System.Drawing.Point(6, 3);
			this.m_cmbNom.Name = "m_cmbNom";
			this.m_cmbNom.Size = new System.Drawing.Size(140, 21);
			this.m_cmbNom.TabIndex = 0;
			this.m_cmbNom.SelectionChangeCommitted += new System.EventHandler(this.m_cmbNom_SelectionChangeCommitted);
			// 
			// m_lblNom
			// 
			this.m_lblNom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lblNom.Location = new System.Drawing.Point(0, 0);
			this.m_lblNom.Name = "m_lblNom";
			this.m_lblNom.Size = new System.Drawing.Size(152, 25);
			this.m_lblNom.TabIndex = 1;
			this.m_lblNom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_lblTitreNom
			// 
			this.m_lblTitreNom.BackColor = System.Drawing.Color.Moccasin;
			this.m_lblTitreNom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lblTitreNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblTitreNom.Location = new System.Drawing.Point(0, 0);
			this.m_lblTitreNom.Name = "m_lblTitreNom";
			this.m_lblTitreNom.Size = new System.Drawing.Size(152, 25);
			this.m_lblTitreNom.TabIndex = 3;
			this.m_lblTitreNom.Text = "Name|50";
			this.m_lblTitreNom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.m_lblTitreNom.Visible = false;
			// 
			// m_panValeur
			// 
			this.m_panValeur.Controls.Add(this.m_chkNull);
			this.m_panValeur.Controls.Add(this.m_ctrlEditVal);
			this.m_panValeur.Controls.Add(this.m_lblTitreValeur);
			this.m_panValeur.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_panValeur.Location = new System.Drawing.Point(292, 0);
			this.m_panValeur.Name = "m_panValeur";
			this.m_panValeur.Size = new System.Drawing.Size(198, 25);
			this.m_panValeur.TabIndex = 8;
			// 
			// m_chkNull
			// 
			this.m_chkNull.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_chkNull.Location = new System.Drawing.Point(0, 0);
			this.m_chkNull.Name = "m_chkNull";
			this.m_chkNull.Size = new System.Drawing.Size(15, 25);
			this.m_chkNull.TabIndex = 5;
			this.m_chkNull.Text = "Is Null|96";
			this.m_chkNull.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.m_chkNull.UseVisualStyleBackColor = true;
			this.m_chkNull.CheckedChanged += new System.EventHandler(this.m_chkNull_CheckedChanged);
			// 
			// m_ctrlEditVal
			// 
			this.m_ctrlEditVal.DefaultValue = "";
			this.m_ctrlEditVal.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_ctrlEditVal.EditingControlDataGridView = null;
			this.m_ctrlEditVal.EditingControlFormattedValue = null;
			this.m_ctrlEditVal.EditingControlRowIndex = 0;
			this.m_ctrlEditVal.EditingControlValueChanged = false;
			this.m_ctrlEditVal.Location = new System.Drawing.Point(0, 0);
			this.m_ctrlEditVal.Name = "m_ctrlEditVal";
			this.m_ctrlEditVal.Size = new System.Drawing.Size(198, 25);
			this.m_ctrlEditVal.TabIndex = 0;
			this.m_ctrlEditVal.Valeur = null;
			// 
			// m_lblTitreValeur
			// 
			this.m_lblTitreValeur.BackColor = System.Drawing.Color.Moccasin;
			this.m_lblTitreValeur.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lblTitreValeur.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblTitreValeur.Location = new System.Drawing.Point(0, 0);
			this.m_lblTitreValeur.Name = "m_lblTitreValeur";
			this.m_lblTitreValeur.Size = new System.Drawing.Size(198, 25);
			this.m_lblTitreValeur.TabIndex = 4;
			this.m_lblTitreValeur.Text = "Default Value|900";
			this.m_lblTitreValeur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.m_lblTitreValeur.Visible = false;
			// 
			// m_panInfo
			// 
			this.m_panInfo.Controls.Add(this.m_panType);
			this.m_panInfo.Controls.Add(this.m_splitterObligatoire);
			this.m_panInfo.Controls.Add(this.m_panObligatoire);
			this.m_panInfo.Controls.Add(this.m_splitterKey);
			this.m_panInfo.Controls.Add(this.m_panKey);
			this.m_panInfo.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_panInfo.Location = new System.Drawing.Point(0, 0);
			this.m_panInfo.Name = "m_panInfo";
			this.m_panInfo.Size = new System.Drawing.Size(138, 25);
			this.m_panInfo.TabIndex = 1;
			// 
			// m_splitterNom
			// 
			this.m_splitterNom.BackColor = System.Drawing.SystemColors.ControlText;
			this.m_splitterNom.Enabled = false;
			this.m_splitterNom.Location = new System.Drawing.Point(291, 0);
			this.m_splitterNom.Name = "m_splitterNom";
			this.m_splitterNom.Size = new System.Drawing.Size(1, 25);
			this.m_splitterNom.TabIndex = 8;
			this.m_splitterNom.TabStop = false;
			// 
			// CControlEditMappageColonne
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.m_panValeur);
			this.Controls.Add(this.m_splitterNom);
			this.Controls.Add(this.m_panNom);
			this.Controls.Add(this.m_splitterType);
			this.Controls.Add(this.m_panInfo);
			this.Name = "CControlEditMappageColonne";
			this.Size = new System.Drawing.Size(490, 25);
			this.m_panKey.ResumeLayout(false);
			this.m_panObligatoire.ResumeLayout(false);
			this.m_panType.ResumeLayout(false);
			this.m_panNom.ResumeLayout(false);
			this.m_panValeur.ResumeLayout(false);
			this.m_panInfo.ResumeLayout(false);
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
		private System.Windows.Forms.Panel m_panKey;
		private System.Windows.Forms.Panel m_panObligatoire;
		private System.Windows.Forms.Splitter m_splitterObligatoire;
		private System.Windows.Forms.Panel m_panType;
		private System.Windows.Forms.Splitter m_splitterType;
		private System.Windows.Forms.Splitter m_splitterKey;
		private System.Windows.Forms.Panel m_panNom;
		private System.Windows.Forms.ComboBox m_cmbNom;
		private System.Windows.Forms.Panel m_panValeur;
		private timos.tables.CCtrlEditSelonType m_ctrlEditVal;
		private System.Windows.Forms.Label m_lblNom;
		private System.Windows.Forms.Label m_lblType;
		private System.Windows.Forms.Panel m_panInfo;
		private System.Windows.Forms.Splitter m_splitterNom;
		private System.Windows.Forms.Label m_lblTitreKey;
		private System.Windows.Forms.Label m_lblTitreNull;
		private System.Windows.Forms.Label m_lblTitreType;
		private System.Windows.Forms.Label m_lblTitreNom;
		private System.Windows.Forms.Label m_lblTitreValeur;
		private System.Windows.Forms.CheckBox m_chkNull;

	}
}
