namespace futurocom.win32.snmp
{
    partial class CPanelPoolingSetup
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
            this.cExtStyle1 = new sc2i.win32.common.CExtStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.m_cmbTypesDonnees = new sc2i.win32.common.CComboboxAutoFilled();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_txtFrequence = new sc2i.win32.common.C2iTextBoxNumeriqueAvecUnite();
            this.label3 = new System.Windows.Forms.Label();
            this.m_wndListeChamps = new sc2i.win32.common.customizableList.CCustomizableList();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 21);
            this.cExtStyle1.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data type|20126";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtLibelle
            // 
            this.m_txtLibelle.EmptyText = "";
            this.m_txtLibelle.Location = new System.Drawing.Point(136, 7);
            this.m_txtLibelle.LockEdition = false;
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(323, 20);
            this.cExtStyle1.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 1;
            // 
            // m_cmbTypesDonnees
            // 
            this.m_cmbTypesDonnees.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbTypesDonnees.FormattingEnabled = true;
            this.m_cmbTypesDonnees.IsLink = false;
            this.m_cmbTypesDonnees.ListDonnees = null;
            this.m_cmbTypesDonnees.Location = new System.Drawing.Point(136, 29);
            this.m_cmbTypesDonnees.LockEdition = false;
            this.m_cmbTypesDonnees.Name = "m_cmbTypesDonnees";
            this.m_cmbTypesDonnees.NullAutorise = false;
            this.m_cmbTypesDonnees.ProprieteAffichee = null;
            this.m_cmbTypesDonnees.Size = new System.Drawing.Size(323, 21);
            this.cExtStyle1.SetStyleBackColor(this.m_cmbTypesDonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_cmbTypesDonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbTypesDonnees.TabIndex = 2;
            this.m_cmbTypesDonnees.Text = "(empty)";
            this.m_cmbTypesDonnees.TextNull = "(empty)";
            this.m_cmbTypesDonnees.Tri = true;
            this.m_cmbTypesDonnees.SelectionChangeCommitted += new System.EventHandler(this.m_cmbTypesDonnees_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 23);
            this.cExtStyle1.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 0;
            this.label2.Text = "Libellé|20125";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_txtFrequence);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.m_cmbTypesDonnees);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.m_txtLibelle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(585, 71);
            this.cExtStyle1.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 3;
            // 
            // m_txtFrequence
            // 
            this.m_txtFrequence.AllowNoUnit = false;
            this.m_txtFrequence.DefaultFormat = "h min s";
            this.m_txtFrequence.EmptyText = "h min s";
            this.m_txtFrequence.Location = new System.Drawing.Point(136, 50);
            this.m_txtFrequence.LockEdition = false;
            this.m_txtFrequence.Name = "m_txtFrequence";
            this.m_txtFrequence.Size = new System.Drawing.Size(134, 20);
            this.cExtStyle1.SetStyleBackColor(this.m_txtFrequence, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_txtFrequence, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFrequence.TabIndex = 3;
            this.m_txtFrequence.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtFrequence.UnitValue = null;
            this.m_txtFrequence.UseValueFormat = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 21);
            this.cExtStyle1.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 0;
            this.label3.Text = "Polling frequency|20130";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_wndListeChamps
            // 
            this.m_wndListeChamps.CurrentItemIndex = null;
            this.m_wndListeChamps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeChamps.ItemControl = null;
            this.m_wndListeChamps.Items = new sc2i.win32.common.customizableList.CCustomizableListItem[0];
            this.m_wndListeChamps.Location = new System.Drawing.Point(0, 71);
            this.m_wndListeChamps.LockEdition = false;
            this.m_wndListeChamps.Name = "m_wndListeChamps";
            this.m_wndListeChamps.Size = new System.Drawing.Size(585, 279);
            this.cExtStyle1.SetStyleBackColor(this.m_wndListeChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_wndListeChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeChamps.TabIndex = 4;
            // 
            // CPanelPoolingSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_wndListeChamps);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "CPanelPoolingSetup";
            this.Size = new System.Drawing.Size(585, 350);
            this.cExtStyle1.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.cExtStyle1.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.CExtStyle cExtStyle1;
        private System.Windows.Forms.Label label1;
        private sc2i.win32.common.C2iTextBox m_txtLibelle;
        private sc2i.win32.common.CComboboxAutoFilled m_cmbTypesDonnees;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private sc2i.win32.common.customizableList.CCustomizableList m_wndListeChamps;
        private System.Windows.Forms.Label label3;
        private sc2i.win32.common.C2iTextBoxNumeriqueAvecUnite m_txtFrequence;
    }
}
