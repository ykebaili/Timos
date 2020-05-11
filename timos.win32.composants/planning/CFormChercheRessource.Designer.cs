using sc2i.common;


namespace timos.win32.composants
{
	partial class CFormChercheRessource
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormChercheRessource));
            this.m_panelTotal = new sc2i.win32.common.C2iPanel(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_arbre = new System.Windows.Forms.TreeView();
            this.m_imagesEmplacements = new System.Windows.Forms.ImageList(this.components);
            this.m_panelDispo = new System.Windows.Forms.Panel();
            this.m_controlPlanning = new timos.win32.composants.CControlePlanning();
            this.m_panelFiltre = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cmbProfilRessource = new sc2i.win32.data.CComboBoxListeObjetsDonnees();
            this.m_panelEntete = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.m_lblContrainte = new System.Windows.Forms.Label();
            this.m_exStyle = new sc2i.win32.common.CExtStyle();
            this.m_timerUpdatePlanning = new System.Windows.Forms.Timer(this.components);
            this.m_panelBas = new System.Windows.Forms.Panel();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_panelTotal.SuspendLayout();
            this.m_panelDispo.SuspendLayout();
            this.m_panelFiltre.SuspendLayout();
            this.m_panelEntete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.m_panelBas.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelTotal
            // 
            this.m_panelTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_panelTotal.Controls.Add(this.splitter1);
            this.m_panelTotal.Controls.Add(this.m_arbre);
            this.m_panelTotal.Controls.Add(this.m_panelDispo);
            this.m_panelTotal.Controls.Add(this.m_panelFiltre);
            this.m_panelTotal.Controls.Add(this.m_panelEntete);
            this.m_panelTotal.Controls.Add(this.m_panelBas);
            this.m_panelTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelTotal.ForeColor = System.Drawing.Color.Black;
            this.m_panelTotal.Location = new System.Drawing.Point(0, 0);
            this.m_panelTotal.LockEdition = false;
            this.m_panelTotal.Name = "m_panelTotal";
            this.m_panelTotal.Size = new System.Drawing.Size(673, 303);
            this.m_exStyle.SetStyleBackColor(this.m_panelTotal, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_exStyle.SetStyleForeColor(this.m_panelTotal, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelTotal.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 197);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(669, 3);
            this.m_exStyle.SetStyleBackColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // m_arbre
            // 
            this.m_arbre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_arbre.ImageIndex = 0;
            this.m_arbre.ImageList = this.m_imagesEmplacements;
            this.m_arbre.Location = new System.Drawing.Point(0, 45);
            this.m_arbre.Name = "m_arbre";
            this.m_arbre.SelectedImageIndex = 0;
            this.m_arbre.Size = new System.Drawing.Size(669, 155);
            this.m_exStyle.SetStyleBackColor(this.m_arbre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_arbre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_arbre.TabIndex = 2;
            this.m_arbre.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.m_arbre_NodeMouseDoubleClick);
            this.m_arbre.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_arbre_AfterSelect);
            // 
            // m_imagesEmplacements
            // 
            this.m_imagesEmplacements.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imagesEmplacements.ImageStream")));
            this.m_imagesEmplacements.TransparentColor = System.Drawing.Color.Transparent;
            this.m_imagesEmplacements.Images.SetKeyName(0, "site.bmp");
            this.m_imagesEmplacements.Images.SetKeyName(1, "user.gif");
            this.m_imagesEmplacements.Images.SetKeyName(2, "ressourcematerielle.bmp");
            // 
            // m_panelDispo
            // 
            this.m_panelDispo.Controls.Add(this.m_controlPlanning);
            this.m_panelDispo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_panelDispo.Location = new System.Drawing.Point(0, 200);
            this.m_panelDispo.Name = "m_panelDispo";
            this.m_panelDispo.Size = new System.Drawing.Size(669, 61);
            this.m_exStyle.SetStyleBackColor(this.m_panelDispo, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_panelDispo, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelDispo.TabIndex = 6;
            this.m_panelDispo.Visible = false;
            this.m_panelDispo.Paint += new System.Windows.Forms.PaintEventHandler(this.m_panelDispo_Paint);
            // 
            // m_controlPlanning
            // 
            this.m_controlPlanning.AutoTooltip = false;
            this.m_controlPlanning.BaseAffichee = null;
            this.m_controlPlanning.DateDebut = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.m_controlPlanning.DateFin = new System.DateTime(1900, 1, 2, 0, 0, 0, 0);
            this.m_controlPlanning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_controlPlanning.ElementAInterventionSelectionne = null;
            this.m_controlPlanning.EnableAffichageDatesEnBas = true;
            this.m_controlPlanning.Location = new System.Drawing.Point(0, 0);
            this.m_controlPlanning.LockEdition = true;
            this.m_controlPlanning.MasquerEntetesLignes = false;
            this.m_controlPlanning.Name = "m_controlPlanning";
            this.m_controlPlanning.Size = new System.Drawing.Size(669, 61);
            this.m_exStyle.SetStyleBackColor(this.m_controlPlanning, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_controlPlanning, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_controlPlanning.TabIndex = 0;
            this.m_controlPlanning.TypeRessourcesAAffecter = typeof(timos.acteurs.CActeur);
            // 
            // m_panelFiltre
            // 
            this.m_panelFiltre.Controls.Add(this.label1);
            this.m_panelFiltre.Controls.Add(this.m_cmbProfilRessource);
            this.m_panelFiltre.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelFiltre.Location = new System.Drawing.Point(0, 22);
            this.m_panelFiltre.Name = "m_panelFiltre";
            this.m_panelFiltre.Size = new System.Drawing.Size(669, 23);
            this.m_exStyle.SetStyleBackColor(this.m_panelFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_panelFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelFiltre.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.m_exStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4;
            this.label1.Text = "Find|704";
            // 
            // m_cmbProfilRessource
            // 
            this.m_cmbProfilRessource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbProfilRessource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbProfilRessource.ElementSelectionne = null;
            this.m_cmbProfilRessource.FormattingEnabled = true;
            this.m_cmbProfilRessource.IsLink = false;
            this.m_cmbProfilRessource.ListDonnees = null;
            this.m_cmbProfilRessource.Location = new System.Drawing.Point(76, 0);
            this.m_cmbProfilRessource.LockEdition = false;
            this.m_cmbProfilRessource.Name = "m_cmbProfilRessource";
            this.m_cmbProfilRessource.NullAutorise = false;
            this.m_cmbProfilRessource.ProprieteAffichee = null;
            this.m_cmbProfilRessource.ProprieteParentListeObjets = null;
            this.m_cmbProfilRessource.SelectionneurParent = null;
            this.m_cmbProfilRessource.Size = new System.Drawing.Size(593, 21);
            this.m_exStyle.SetStyleBackColor(this.m_cmbProfilRessource, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_cmbProfilRessource, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbProfilRessource.TabIndex = 3;
            this.m_cmbProfilRessource.TextNull = "(Empty)";
            this.m_cmbProfilRessource.Tri = true;
            this.m_cmbProfilRessource.SelectionChangeCommitted += new System.EventHandler(this.m_cmbProfilRessource_SelectionChangeCommitted);
            // 
            // m_panelEntete
            // 
            this.m_panelEntete.Controls.Add(this.pictureBox1);
            this.m_panelEntete.Controls.Add(this.m_lblContrainte);
            this.m_panelEntete.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelEntete.Location = new System.Drawing.Point(0, 0);
            this.m_panelEntete.Name = "m_panelEntete";
            this.m_panelEntete.Size = new System.Drawing.Size(669, 22);
            this.m_exStyle.SetStyleBackColor(this.m_panelEntete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_panelEntete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEntete.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_exStyle.SetStyleBackColor(this.pictureBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.pictureBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // m_lblContrainte
            // 
            this.m_lblContrainte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblContrainte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblContrainte.ForeColor = System.Drawing.Color.Beige;
            this.m_lblContrainte.Location = new System.Drawing.Point(20, 0);
            this.m_lblContrainte.Name = "m_lblContrainte";
            this.m_lblContrainte.Size = new System.Drawing.Size(649, 19);
            this.m_exStyle.SetStyleBackColor(this.m_lblContrainte, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_lblContrainte, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTitrePanel);
            this.m_lblContrainte.TabIndex = 0;
            this.m_lblContrainte.Text = "Constraint|703";
            // 
            // m_timerUpdatePlanning
            // 
            this.m_timerUpdatePlanning.Tick += new System.EventHandler(this.m_timerUpdatePlanning_Tick);
            // 
            // m_panelBas
            // 
            this.m_panelBas.Controls.Add(this.m_btnOk);
            this.m_panelBas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_panelBas.Location = new System.Drawing.Point(0, 261);
            this.m_panelBas.Name = "m_panelBas";
            this.m_panelBas.Size = new System.Drawing.Size(669, 38);
            this.m_exStyle.SetStyleBackColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelBas.TabIndex = 8;
            this.m_panelBas.Visible = false;
            // 
            // m_btnOk
            // 
            this.m_btnOk.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnOk.ForeColor = System.Drawing.Color.White;
            this.m_btnOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btnOk.Image")));
            this.m_btnOk.Location = new System.Drawing.Point(285, 0);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(99, 39);
            this.m_exStyle.SetStyleBackColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnOk.TabIndex = 3;
            // 
            // CFormChercheRessource
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(673, 303);
            this.Controls.Add(this.m_panelTotal);
            this.Name = "CFormChercheRessource";
            this.m_exStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "CFormChercheRessource";
            this.Leave += new System.EventHandler(this.CFormChercheRessource_Leave);
            this.Load += new System.EventHandler(this.CFormChercheRessource_Load);
            this.m_panelTotal.ResumeLayout(false);
            this.m_panelDispo.ResumeLayout(false);
            this.m_panelFiltre.ResumeLayout(false);
            this.m_panelEntete.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.m_panelBas.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private sc2i.win32.common.C2iPanel m_panelTotal;
		private sc2i.win32.common.CExtStyle m_exStyle;
		private System.Windows.Forms.TreeView m_arbre;
		private System.Windows.Forms.Panel m_panelEntete;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label m_lblContrainte;
		private System.Windows.Forms.ImageList m_imagesEmplacements;
		private System.Windows.Forms.Label label1;
		private sc2i.win32.data.CComboBoxListeObjetsDonnees m_cmbProfilRessource;
		private System.Windows.Forms.Panel m_panelDispo;
		private System.Windows.Forms.Panel m_panelFiltre;
		private System.Windows.Forms.Splitter splitter1;
		private timos.win32.composants.CControlePlanning m_controlPlanning;
		private System.Windows.Forms.Timer m_timerUpdatePlanning;
        private System.Windows.Forms.Panel m_panelBas;
        private System.Windows.Forms.Button m_btnOk;
	}
}
