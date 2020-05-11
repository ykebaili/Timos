namespace timos.version
{
	partial class CControlListeOperationsSurCAVO
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
            this.m_btnFiltresChamp = new System.Windows.Forms.Button();
            this.m_lstChamps = new sc2i.win32.common.ListViewAutoFilled();
            this.colNomChamp = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.colTypeChamp = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.colTypeDonnee = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_scTop = new System.Windows.Forms.SplitContainer();
            this.m_lstTypeOperations = new sc2i.win32.common.ListViewAutoFilled();
            this.colTypeOperation = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_dgvViewer = new timos.CDataGridViewAControlesVivants();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.m_scTop.Panel1.SuspendLayout();
            this.m_scTop.Panel2.SuspendLayout();
            this.m_scTop.SuspendLayout();
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
            this.colEntiteDescription.Text = "Element Description|30274";
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
            this.colOperation.Text = "Operation Type|30275";
            this.colOperation.Visible = true;
            this.colOperation.Width = 135;
            // 
            // colChamp
            // 
            this.colChamp.Field = "";
            this.colChamp.PrecisionWidth = 135.25;
            this.colChamp.ProportionnalSize = true;
            this.colChamp.Text = "Field|85";
            this.colChamp.Visible = true;
            this.colChamp.Width = 135;
            // 
            // colValSource
            // 
            this.colValSource.Field = "";
            this.colValSource.PrecisionWidth = 135.25;
            this.colValSource.ProportionnalSize = true;
            this.colValSource.Text = "Source Value|1413";
            this.colValSource.Visible = true;
            this.colValSource.Width = 135;
            // 
            // colValCible
            // 
            this.colValCible.Field = "";
            this.colValCible.PrecisionWidth = 135.25;
            this.colValCible.ProportionnalSize = true;
            this.colValCible.Text = "Target Value|1414";
            this.colValCible.Visible = true;
            this.colValCible.Width = 135;
            // 
            // m_btnFiltresChamp
            // 
            this.m_btnFiltresChamp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnFiltresChamp.Location = new System.Drawing.Point(422, 2);
            this.m_btnFiltresChamp.Name = "m_btnFiltresChamp";
            this.m_btnFiltresChamp.Size = new System.Drawing.Size(24, 23);
            this.m_btnFiltresChamp.TabIndex = 4028;
            this.m_btnFiltresChamp.UseVisualStyleBackColor = true;
            this.m_btnFiltresChamp.Click += new System.EventHandler(this.m_btnFiltresChamp_Click);
            // 
            // m_lstChamps
            // 
            this.m_lstChamps.BackColor = System.Drawing.SystemColors.Info;
            this.m_lstChamps.CheckBoxes = true;
            this.m_lstChamps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNomChamp,
            this.colTypeChamp,
            this.colTypeDonnee});
            this.m_lstChamps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lstChamps.EnableCustomisation = true;
            this.m_lstChamps.FullRowSelect = true;
            this.m_lstChamps.GridLines = true;
            this.m_lstChamps.Location = new System.Drawing.Point(0, 0);
            this.m_lstChamps.Name = "m_lstChamps";
            this.m_lstChamps.Size = new System.Drawing.Size(297, 25);
            this.m_lstChamps.TabIndex = 0;
            this.m_lstChamps.UseCompatibleStateImageBehavior = false;
            this.m_lstChamps.View = System.Windows.Forms.View.Details;
            this.m_lstChamps.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.m_lstChamps_ItemChecked);
            // 
            // colNomChamp
            // 
            this.colNomChamp.Field = "";
            this.colNomChamp.PrecisionWidth = 100;
            this.colNomChamp.ProportionnalSize = false;
            this.colNomChamp.Text = "Field|85";
            this.colNomChamp.Visible = true;
            this.colNomChamp.Width = 100;
            // 
            // colTypeChamp
            // 
            this.colTypeChamp.Field = "";
            this.colTypeChamp.PrecisionWidth = 100;
            this.colTypeChamp.ProportionnalSize = false;
            this.colTypeChamp.Text = "Field type|30287";
            this.colTypeChamp.Visible = true;
            this.colTypeChamp.Width = 100;
            // 
            // colTypeDonnee
            // 
            this.colTypeDonnee.Field = "";
            this.colTypeDonnee.PrecisionWidth = 100;
            this.colTypeDonnee.ProportionnalSize = false;
            this.colTypeDonnee.Text = "Data type|30288";
            this.colTypeDonnee.Visible = true;
            this.colTypeDonnee.Width = 100;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m_scTop);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_dgvViewer);
            this.splitContainer1.Panel2.Controls.Add(this.m_btnFiltresChamp);
            this.splitContainer1.Size = new System.Drawing.Size(449, 245);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 0;
            // 
            // m_scTop
            // 
            this.m_scTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_scTop.Location = new System.Drawing.Point(0, 0);
            this.m_scTop.Name = "m_scTop";
            // 
            // m_scTop.Panel1
            // 
            this.m_scTop.Panel1.Controls.Add(this.m_lstTypeOperations);
            // 
            // m_scTop.Panel2
            // 
            this.m_scTop.Panel2.Controls.Add(this.m_lstChamps);
            this.m_scTop.Size = new System.Drawing.Size(449, 25);
            this.m_scTop.SplitterDistance = 148;
            this.m_scTop.TabIndex = 1;
            this.m_scTop.Visible = false;
            // 
            // m_lstTypeOperations
            // 
            this.m_lstTypeOperations.BackColor = System.Drawing.SystemColors.Info;
            this.m_lstTypeOperations.CheckBoxes = true;
            this.m_lstTypeOperations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTypeOperation});
            this.m_lstTypeOperations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lstTypeOperations.EnableCustomisation = true;
            this.m_lstTypeOperations.FullRowSelect = true;
            this.m_lstTypeOperations.GridLines = true;
            this.m_lstTypeOperations.Location = new System.Drawing.Point(0, 0);
            this.m_lstTypeOperations.Name = "m_lstTypeOperations";
            this.m_lstTypeOperations.Size = new System.Drawing.Size(148, 25);
            this.m_lstTypeOperations.TabIndex = 0;
            this.m_lstTypeOperations.UseCompatibleStateImageBehavior = false;
            this.m_lstTypeOperations.View = System.Windows.Forms.View.Details;
            this.m_lstTypeOperations.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.m_lstChamps_ItemChecked);
            // 
            // colTypeOperation
            // 
            this.colTypeOperation.Field = "";
            this.colTypeOperation.PrecisionWidth = 0;
            this.colTypeOperation.ProportionnalSize = false;
            this.colTypeOperation.Text = "Operation Types|30286";
            this.colTypeOperation.Visible = true;
            this.colTypeOperation.Width = 120;
            // 
            // m_dgvViewer
            // 
            this.m_dgvViewer.ControlesToujoursVivant = true;
            this.m_dgvViewer.CouleurGrille = System.Drawing.SystemColors.ControlDark;
            this.m_dgvViewer.DataSource = null;
            this.m_dgvViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgvViewer.EnteteLigneVisible = false;
            this.m_dgvViewer.FactoryControlVivant = null;
            this.m_dgvViewer.LargeurEnteteLigne = 41;
            this.m_dgvViewer.LectureSeule = true;
            this.m_dgvViewer.Location = new System.Drawing.Point(0, 0);
            this.m_dgvViewer.ModeHauteurDesColonnes = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvViewer.ModeLargeurDesColonnes = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.m_dgvViewer.Name = "m_dgvViewer";
            this.m_dgvViewer.Size = new System.Drawing.Size(449, 216);
            this.m_dgvViewer.TabIndex = 4030;
            this.m_dgvViewer.InitialisationCellule += new timos.FirstCellBuildNeedAType(this.m_dgvViewer_InitialisationCellule);
            // 
            // CControlListeOperationsSurCAVO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.splitContainer1);
            this.Name = "CControlListeOperationsSurCAVO";
            this.Size = new System.Drawing.Size(449, 245);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.m_scTop.Panel1.ResumeLayout(false);
            this.m_scTop.Panel2.ResumeLayout(false);
            this.m_scTop.ResumeLayout(false);
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
		private System.Windows.Forms.Button m_btnFiltresChamp;
		private sc2i.win32.common.ListViewAutoFilled m_lstChamps;
		private sc2i.win32.common.ListViewAutoFilledColumn colNomChamp;
		private sc2i.win32.common.ListViewAutoFilledColumn colTypeChamp;
		private sc2i.win32.common.ListViewAutoFilledColumn colTypeDonnee;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer m_scTop;
		private sc2i.win32.common.ListViewAutoFilled m_lstTypeOperations;
		private sc2i.win32.common.ListViewAutoFilledColumn colTypeOperation;
		private CDataGridViewAControlesVivants m_dgvViewer;

	}
}
