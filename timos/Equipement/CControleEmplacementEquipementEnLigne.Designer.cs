namespace timos.Equipement
{
    partial class CControleEmplacementEquipementEnLigne
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
            this.m_selectEmplacement = new sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide();
            this.m_cmbEquipement = new sc2i.win32.data.navigation.CComboBoxArbreObjetDonneesHierarchique();
            this.m_cmbTypeEmplacement = new sc2i.win32.common.C2iComboSelectDynamicClass(this.components);
            this.c2iPanel1 = new sc2i.win32.common.C2iPanel(this.components);
            this.m_lblPlaceType = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_lblEmplacement = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.c2iPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_selectEmplacement
            // 
            this.m_selectEmplacement.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_selectEmplacement.ElementSelectionne = null;
            this.m_selectEmplacement.Location = new System.Drawing.Point(0, 23);
            this.m_selectEmplacement.LockEdition = false;
            this.m_selectEmplacement.Name = "m_selectEmplacement";
            this.m_selectEmplacement.SelectedObject = null;
            this.m_selectEmplacement.SelectionLength = 0;
            this.m_selectEmplacement.SelectionStart = 0;
            this.m_selectEmplacement.Size = new System.Drawing.Size(289, 20);
            this.m_selectEmplacement.TabIndex = 0;
            this.m_selectEmplacement.OnSelectedObjectChanged += new System.EventHandler(this.m_selectEmplacement_OnSelectedObjectChanged);
            // 
            // m_cmbEquipement
            // 
            this.m_cmbEquipement.AutoriserFilsDeAutorises = true;
            this.m_cmbEquipement.BackColor = System.Drawing.Color.White;
            this.m_cmbEquipement.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_cmbEquipement.ElementSelectionne = null;
            this.m_cmbEquipement.Location = new System.Drawing.Point(0, 23);
            this.m_cmbEquipement.LockEdition = false;
            this.m_cmbEquipement.Name = "m_cmbEquipement";
            this.m_cmbEquipement.NullAutorise = false;
            this.m_cmbEquipement.Size = new System.Drawing.Size(200, 21);
            this.m_cmbEquipement.TabIndex = 5;
            this.m_cmbEquipement.TextNull = "[None]";
            // 
            // m_cmbTypeEmplacement
            // 
            this.m_cmbTypeEmplacement.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_cmbTypeEmplacement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTypeEmplacement.FormattingEnabled = true;
            this.m_cmbTypeEmplacement.IsLink = false;
            this.m_cmbTypeEmplacement.Location = new System.Drawing.Point(0, 23);
            this.m_cmbTypeEmplacement.LockEdition = false;
            this.m_cmbTypeEmplacement.Name = "m_cmbTypeEmplacement";
            this.m_cmbTypeEmplacement.Size = new System.Drawing.Size(134, 21);
            this.m_cmbTypeEmplacement.TabIndex = 6;
            this.m_cmbTypeEmplacement.TypeSelectionne = null;
            this.m_cmbTypeEmplacement.SelectionChangeCommitted += new System.EventHandler(this.m_cmbTypeEmplacement_SelectionChangeCommitted);
            // 
            // c2iPanel1
            // 
            this.c2iPanel1.Controls.Add(this.m_cmbTypeEmplacement);
            this.c2iPanel1.Controls.Add(this.m_lblPlaceType);
            this.c2iPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.c2iPanel1.Location = new System.Drawing.Point(0, 0);
            this.c2iPanel1.LockEdition = false;
            this.c2iPanel1.Name = "c2iPanel1";
            this.c2iPanel1.Size = new System.Drawing.Size(134, 47);
            this.c2iPanel1.TabIndex = 7;
            // 
            // m_lblPlaceType
            // 
            this.m_lblPlaceType.BackColor = System.Drawing.Color.White;
            this.m_lblPlaceType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblPlaceType.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_lblPlaceType.Location = new System.Drawing.Point(0, 0);
            this.m_lblPlaceType.Name = "m_lblPlaceType";
            this.m_lblPlaceType.Size = new System.Drawing.Size(134, 23);
            this.m_lblPlaceType.TabIndex = 0;
            this.m_lblPlaceType.Text = "Place type|20424";
            this.m_lblPlaceType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_selectEmplacement);
            this.panel1.Controls.Add(this.m_lblEmplacement);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(134, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 47);
            this.panel1.TabIndex = 8;
            // 
            // m_lblEmplacement
            // 
            this.m_lblEmplacement.BackColor = System.Drawing.Color.White;
            this.m_lblEmplacement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblEmplacement.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_lblEmplacement.Location = new System.Drawing.Point(0, 0);
            this.m_lblEmplacement.Name = "m_lblEmplacement";
            this.m_lblEmplacement.Size = new System.Drawing.Size(289, 23);
            this.m_lblEmplacement.TabIndex = 1;
            this.m_lblEmplacement.Text = "Place|20425";
            this.m_lblEmplacement.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_cmbEquipement);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(423, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 47);
            this.panel2.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Parent equipment|40426";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CControleEmplacementEquipementEnLigne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.c2iPanel1);
            this.Controls.Add(this.panel2);
            this.Name = "CControleEmplacementEquipementEnLigne";
            this.Size = new System.Drawing.Size(623, 47);
            this.c2iPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide m_selectEmplacement;
        private sc2i.win32.data.navigation.CComboBoxArbreObjetDonneesHierarchique m_cmbEquipement;
        private sc2i.win32.common.C2iComboSelectDynamicClass m_cmbTypeEmplacement;
        private sc2i.win32.common.C2iPanel c2iPanel1;
        private System.Windows.Forms.Label m_lblPlaceType;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label m_lblEmplacement;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
    }
}
