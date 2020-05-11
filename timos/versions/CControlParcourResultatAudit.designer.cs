using sc2i.common;


namespace timos.version
{
	partial class CControlParcourResultatAudit
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
			this.m_txtSelectVersionSource = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
			this.m_txtSelectVersionCible = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
			this.m_lblVersionSource = new System.Windows.Forms.Label();
			this.m_lblVersionCible = new System.Windows.Forms.Label();
			this.m_lstTypes = new sc2i.win32.common.ListViewAutoFilled();
			this.colNomType = new sc2i.win32.common.ListViewAutoFilledColumn();
			this.m_lblTypes = new System.Windows.Forms.Label();
			this.m_lstEntities = new sc2i.win32.common.ListViewAutoFilled();
			this.colEntiteDescription = new sc2i.win32.common.ListViewAutoFilledColumn();
			this.colEntiteType = new sc2i.win32.common.ListViewAutoFilledColumn();
			this.colOperation = new sc2i.win32.common.ListViewAutoFilledColumn();
			this.colChamp = new sc2i.win32.common.ListViewAutoFilledColumn();
			this.colValSource = new sc2i.win32.common.ListViewAutoFilledColumn();
			this.colValCible = new sc2i.win32.common.ListViewAutoFilledColumn();
			this.m_lblObjets = new System.Windows.Forms.Label();
			this.m_lblOperations = new System.Windows.Forms.Label();
			this.m_sc1 = new System.Windows.Forms.SplitContainer();
			this.m_ctrlOperations = new timos.version.CControlListeOperationsSurCAVO();
			this.m_panVersions = new System.Windows.Forms.Panel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.m_sc1.Panel1.SuspendLayout();
			this.m_sc1.Panel2.SuspendLayout();
			this.m_sc1.SuspendLayout();
			this.m_panVersions.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_txtSelectVersionSource
			// 
			this.m_txtSelectVersionSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtSelectVersionSource.ElementSelectionne = null;
			this.m_txtSelectVersionSource.FonctionTextNull = null;
			this.m_txtSelectVersionSource.HasLink = true;
			this.m_txtSelectVersionSource.Location = new System.Drawing.Point(104, 31);
			this.m_txtSelectVersionSource.LockEdition = false;
			this.m_txtSelectVersionSource.Name = "m_txtSelectVersionSource";
			this.m_txtSelectVersionSource.SelectedObject = null;
			this.m_txtSelectVersionSource.Size = new System.Drawing.Size(315, 21);
			this.m_txtSelectVersionSource.TabIndex = 4022;
			this.m_txtSelectVersionSource.TextNull = I.T("Base version|1406");
			this.m_txtSelectVersionSource.ElementSelectionneChanged += new System.EventHandler(this.m_txtSelectVersionSource_ElementSelectionneChanged);
			// 
			// m_txtSelectVersionCible
			// 
			this.m_txtSelectVersionCible.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtSelectVersionCible.ElementSelectionne = null;
			this.m_txtSelectVersionCible.FonctionTextNull = null;
			this.m_txtSelectVersionCible.HasLink = true;
			this.m_txtSelectVersionCible.Location = new System.Drawing.Point(104, 5);
			this.m_txtSelectVersionCible.LockEdition = false;
			this.m_txtSelectVersionCible.Name = "m_txtSelectVersionCible";
			this.m_txtSelectVersionCible.SelectedObject = null;
			this.m_txtSelectVersionCible.Size = new System.Drawing.Size(315, 21);
			this.m_txtSelectVersionCible.TabIndex = 4023;
			this.m_txtSelectVersionCible.TextNull = "Base version|1406";
			this.m_txtSelectVersionCible.ElementSelectionneChanged += new System.EventHandler(this.m_txtSelectVersionCible_ElementSelectionneChanged);
			// 
			// m_lblVersionSource
			// 
			this.m_lblVersionSource.Location = new System.Drawing.Point(4, 35);
			this.m_lblVersionSource.Name = "m_lblVersionSource";
			this.m_lblVersionSource.Size = new System.Drawing.Size(114, 17);
			this.m_lblVersionSource.TabIndex = 4020;
			this.m_lblVersionSource.Text = "Source Version|1408";
			// 
			// m_lblVersionCible
			// 
			this.m_lblVersionCible.Location = new System.Drawing.Point(3, 9);
			this.m_lblVersionCible.Name = "m_lblVersionCible";
			this.m_lblVersionCible.Size = new System.Drawing.Size(105, 17);
			this.m_lblVersionCible.TabIndex = 4021;
			this.m_lblVersionCible.Text = "Target Version|1407";
			// 
			// m_lstTypes
			// 
			this.m_lstTypes.CheckBoxes = true;
			this.m_lstTypes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNomType});
			this.m_lstTypes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lstTypes.EnableCustomisation = true;
			this.m_lstTypes.FullRowSelect = true;
			this.m_lstTypes.GridLines = true;
			this.m_lstTypes.Location = new System.Drawing.Point(0, 17);
			this.m_lstTypes.Name = "m_lstTypes";
			this.m_lstTypes.Size = new System.Drawing.Size(140, 34);
			this.m_lstTypes.TabIndex = 4025;
			this.m_lstTypes.UseCompatibleStateImageBehavior = false;
			this.m_lstTypes.View = System.Windows.Forms.View.Details;
			this.m_lstTypes.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.m_lstTypes_ItemChecked);
			// 
			// colNomType
			// 
			this.colNomType.Field = "";
			this.colNomType.PrecisionWidth = 234;
			this.colNomType.ProportionnalSize = true;
			this.colNomType.Text = "Label|50";
			this.colNomType.Visible = true;
			this.colNomType.Width = 234;
			// 
			// m_lblTypes
			// 
			this.m_lblTypes.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lblTypes.Location = new System.Drawing.Point(0, 0);
			this.m_lblTypes.Name = "m_lblTypes";
			this.m_lblTypes.Size = new System.Drawing.Size(140, 17);
			this.m_lblTypes.TabIndex = 4020;
			this.m_lblTypes.Text = "Types|44";
			// 
			// m_lstEntities
			// 
			this.m_lstEntities.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colEntiteDescription,
            this.colEntiteType});
			this.m_lstEntities.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lstEntities.EnableCustomisation = true;
			this.m_lstEntities.FullRowSelect = true;
			this.m_lstEntities.GridLines = true;
			this.m_lstEntities.Location = new System.Drawing.Point(0, 17);
			this.m_lstEntities.Name = "m_lstEntities";
			this.m_lstEntities.Size = new System.Drawing.Size(278, 34);
			this.m_lstEntities.TabIndex = 4025;
			this.m_lstEntities.UseCompatibleStateImageBehavior = false;
			this.m_lstEntities.View = System.Windows.Forms.View.Details;
			this.m_lstEntities.SelectedIndexChanged += new System.EventHandler(this.m_lstEntities_SelectedIndexChanged);
			// 
			// colEntiteDescription
			// 
			this.colEntiteDescription.Field = "";
			this.colEntiteDescription.PrecisionWidth = 340;
			this.colEntiteDescription.ProportionnalSize = true;
			this.colEntiteDescription.Text = "Element Description|41";
			this.colEntiteDescription.Visible = true;
			this.colEntiteDescription.Width = 340;
			// 
			// colEntiteType
			// 
			this.colEntiteType.Field = "";
			this.colEntiteType.PrecisionWidth = 140.5;
			this.colEntiteType.ProportionnalSize = true;
			this.colEntiteType.Text = "Type|30282";
			this.colEntiteType.Visible = true;
			this.colEntiteType.Width = 140;
			// 
			// colOperation
			// 
			this.colOperation.Field = "";
			this.colOperation.PrecisionWidth = 110.25;
			this.colOperation.ProportionnalSize = true;
			this.colOperation.Text = "Operation Type|30275";
			this.colOperation.Visible = true;
			this.colOperation.Width = 110;
			// 
			// colChamp
			// 
			this.colChamp.Field = "";
			this.colChamp.PrecisionWidth = 110.25;
			this.colChamp.ProportionnalSize = true;
			this.colChamp.Text = "Field|85";
			this.colChamp.Visible = true;
			this.colChamp.Width = 110;
			// 
			// colValSource
			// 
			this.colValSource.Field = "";
			this.colValSource.PrecisionWidth = 110.25;
			this.colValSource.ProportionnalSize = true;
            this.colValSource.Text = "Source Value|1413";
			this.colValSource.Visible = true;
			this.colValSource.Width = 110;
			// 
			// colValCible
			// 
			this.colValCible.Field = "";
			this.colValCible.PrecisionWidth = 110.25;
			this.colValCible.ProportionnalSize = true;
			this.colValCible.Text = "Target Value|1414";
			this.colValCible.Visible = true;
			this.colValCible.Width = 110;
			// 
			// m_lblObjets
			// 
			this.m_lblObjets.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lblObjets.Location = new System.Drawing.Point(0, 0);
			this.m_lblObjets.Name = "m_lblObjets";
			this.m_lblObjets.Size = new System.Drawing.Size(278, 17);
			this.m_lblObjets.TabIndex = 4020;
			this.m_lblObjets.Text = "Entities|923";
			// 
			// m_lblOperations
			// 
			this.m_lblOperations.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lblOperations.Location = new System.Drawing.Point(0, 0);
			this.m_lblOperations.Name = "m_lblOperations";
			this.m_lblOperations.Size = new System.Drawing.Size(422, 17);
			this.m_lblOperations.TabIndex = 4020;
			this.m_lblOperations.Text = "Operations|1124";
			// 
			// m_sc1
			// 
			this.m_sc1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_sc1.Location = new System.Drawing.Point(0, 0);
			this.m_sc1.Name = "m_sc1";
			// 
			// m_sc1.Panel1
			// 
			this.m_sc1.Panel1.Controls.Add(this.m_lstTypes);
			this.m_sc1.Panel1.Controls.Add(this.m_lblTypes);
			// 
			// m_sc1.Panel2
			// 
			this.m_sc1.Panel2.Controls.Add(this.m_lstEntities);
			this.m_sc1.Panel2.Controls.Add(this.m_lblObjets);
			this.m_sc1.Size = new System.Drawing.Size(422, 51);
			this.m_sc1.SplitterDistance = 140;
			this.m_sc1.TabIndex = 4026;
			// 
			// m_ctrlOperations
			// 
			this.m_ctrlOperations.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_ctrlOperations.Location = new System.Drawing.Point(0, 17);
			this.m_ctrlOperations.Name = "m_ctrlOperations";
			this.m_ctrlOperations.Size = new System.Drawing.Size(422, 86);
			this.m_ctrlOperations.TabIndex = 4026;
			// 
			// m_panVersions
			// 
			this.m_panVersions.Controls.Add(this.m_txtSelectVersionSource);
			this.m_panVersions.Controls.Add(this.m_txtSelectVersionCible);
			this.m_panVersions.Controls.Add(this.m_lblVersionCible);
			this.m_panVersions.Controls.Add(this.m_lblVersionSource);
			this.m_panVersions.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_panVersions.Location = new System.Drawing.Point(0, 0);
			this.m_panVersions.Name = "m_panVersions";
			this.m_panVersions.Size = new System.Drawing.Size(422, 65);
			this.m_panVersions.TabIndex = 4027;
			this.m_panVersions.Visible = false;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 65);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.m_sc1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.m_ctrlOperations);
			this.splitContainer1.Panel2.Controls.Add(this.m_lblOperations);
			this.splitContainer1.Size = new System.Drawing.Size(422, 158);
			this.splitContainer1.SplitterDistance = 51;
			this.splitContainer1.TabIndex = 4026;
			// 
			// CControlParcourResultatAudit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.m_panVersions);
			this.Name = "CControlParcourResultatAudit";
			this.Size = new System.Drawing.Size(422, 223);
			this.m_sc1.Panel1.ResumeLayout(false);
			this.m_sc1.Panel2.ResumeLayout(false);
			this.m_sc1.ResumeLayout(false);
			this.m_panVersions.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_txtSelectVersionSource;
		private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_txtSelectVersionCible;
		private System.Windows.Forms.Label m_lblVersionSource;
		private System.Windows.Forms.Label m_lblVersionCible;
		private sc2i.win32.common.ListViewAutoFilled m_lstTypes;
		private System.Windows.Forms.Label m_lblTypes;
		private sc2i.win32.common.ListViewAutoFilled m_lstEntities;
		private System.Windows.Forms.Label m_lblObjets;
		private System.Windows.Forms.Label m_lblOperations;
		private System.Windows.Forms.SplitContainer m_sc1;
		private System.Windows.Forms.Panel m_panVersions;
		private sc2i.win32.common.ListViewAutoFilledColumn colNomType;
		private sc2i.win32.common.ListViewAutoFilledColumn colEntiteDescription;
		private sc2i.win32.common.ListViewAutoFilledColumn colEntiteType;
		private sc2i.win32.common.ListViewAutoFilledColumn colOperation;
		private sc2i.win32.common.ListViewAutoFilledColumn colChamp;
		private sc2i.win32.common.ListViewAutoFilledColumn colValSource;
		private sc2i.win32.common.ListViewAutoFilledColumn colValCible;
		private CControlListeOperationsSurCAVO m_ctrlOperations;
		private System.Windows.Forms.SplitContainer splitContainer1;

	}
}
