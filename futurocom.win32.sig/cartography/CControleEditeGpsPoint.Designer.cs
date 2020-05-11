namespace futurocom.win32.sig.cartography
{
    partial class CControleEditeGpsPoint
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
            this.m_panelPointType = new System.Windows.Forms.Panel();
            this.m_cmbMarkerType = new sc2i.win32.common.CComboboxAutoFilled();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_chkPermanentTooltip = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_txtLatitude = new sc2i.win32.common.C2iTextBoxNumeriqueAvecUnite();
            this.label2 = new System.Windows.Forms.Label();
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.panel4 = new System.Windows.Forms.Panel();
            this.m_txtLongitude = new sc2i.win32.common.C2iTextBoxNumeriqueAvecUnite();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.m_txtTypePoint = new sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide();
            this.label7 = new System.Windows.Forms.Label();
            this.m_panelPointType.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelPointType
            // 
            this.m_panelPointType.Controls.Add(this.m_cmbMarkerType);
            this.m_panelPointType.Controls.Add(this.label3);
            this.m_panelPointType.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelPointType.Location = new System.Drawing.Point(0, 77);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelPointType, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelPointType.Name = "m_panelPointType";
            this.m_panelPointType.Size = new System.Drawing.Size(216, 27);
            this.m_panelPointType.TabIndex = 10;
            // 
            // m_cmbMarkerType
            // 
            this.m_cmbMarkerType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_cmbMarkerType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbMarkerType.FormattingEnabled = true;
            this.m_cmbMarkerType.IsLink = false;
            this.m_cmbMarkerType.ListDonnees = null;
            this.m_cmbMarkerType.Location = new System.Drawing.Point(76, 0);
            this.m_cmbMarkerType.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbMarkerType, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbMarkerType.Name = "m_cmbMarkerType";
            this.m_cmbMarkerType.NullAutorise = false;
            this.m_cmbMarkerType.ProprieteAffichee = null;
            this.m_cmbMarkerType.Size = new System.Drawing.Size(140, 21);
            this.m_cmbMarkerType.TabIndex = 4;
            this.m_cmbMarkerType.Text = "(empty)";
            this.m_cmbMarkerType.TextNull = "(empty)";
            this.m_cmbMarkerType.Tri = true;
            this.m_cmbMarkerType.SelectionChangeCommitted += new System.EventHandler(this.m_cmbMarkerType_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 27);
            this.label3.TabIndex = 3;
            this.label3.Text = "Icon|20006";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_chkPermanentTooltip);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 104);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(216, 27);
            this.panel2.TabIndex = 20;
            // 
            // m_chkPermanentTooltip
            // 
            this.m_chkPermanentTooltip.AutoSize = true;
            this.m_chkPermanentTooltip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_chkPermanentTooltip.Location = new System.Drawing.Point(76, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkPermanentTooltip, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkPermanentTooltip.Name = "m_chkPermanentTooltip";
            this.m_chkPermanentTooltip.Size = new System.Drawing.Size(140, 27);
            this.m_chkPermanentTooltip.TabIndex = 0;
            this.m_chkPermanentTooltip.Text = "Permanent tooltip|20051";
            this.m_chkPermanentTooltip.UseVisualStyleBackColor = true;
            this.m_chkPermanentTooltip.CheckedChanged += new System.EventHandler(this.m_chkPermanentTooltip_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 27);
            this.label1.TabIndex = 4;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.m_txtLatitude);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 131);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(216, 27);
            this.panel3.TabIndex = 30;
            // 
            // m_txtLatitude
            // 
            this.m_txtLatitude.AllowNoUnit = false;
            this.m_txtLatitude.DefaultFormat = "";
            this.m_txtLatitude.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtLatitude.EmptyText = "";
            this.m_txtLatitude.Location = new System.Drawing.Point(76, 0);
            this.m_txtLatitude.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLatitude, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtLatitude.Name = "m_txtLatitude";
            this.m_txtLatitude.Size = new System.Drawing.Size(140, 20);
            this.m_txtLatitude.TabIndex = 4;
            this.m_txtLatitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtLatitude.UnitValue = null;
            this.m_txtLatitude.UseValueFormat = false;
            this.m_txtLatitude.Validated += new System.EventHandler(this.m_txtLatitude_Validated);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "Latitude|20022";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.m_txtLongitude);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 158);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(216, 27);
            this.panel4.TabIndex = 40;
            // 
            // m_txtLongitude
            // 
            this.m_txtLongitude.AllowNoUnit = false;
            this.m_txtLongitude.DefaultFormat = "";
            this.m_txtLongitude.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtLongitude.EmptyText = "";
            this.m_txtLongitude.Location = new System.Drawing.Point(76, 0);
            this.m_txtLongitude.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLongitude, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtLongitude.Name = "m_txtLongitude";
            this.m_txtLongitude.Size = new System.Drawing.Size(140, 20);
            this.m_txtLongitude.TabIndex = 4;
            this.m_txtLongitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtLongitude.UnitValue = null;
            this.m_txtLongitude.UseValueFormat = false;
            this.m_txtLongitude.Validated += new System.EventHandler(this.m_txtLongitude_Validated);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 27);
            this.label4.TabIndex = 3;
            this.label4.Text = "Longitude|20021";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.m_txtLibelle);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 23);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(216, 27);
            this.panel5.TabIndex = 0;
            // 
            // m_txtLibelle
            // 
            this.m_txtLibelle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtLibelle.EmptyText = "";
            this.m_txtLibelle.Location = new System.Drawing.Point(76, 0);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(140, 20);
            this.m_txtLibelle.TabIndex = 4;
            this.m_txtLibelle.Validated += new System.EventHandler(this.m_txtLibelle_Validated);
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 27);
            this.label5.TabIndex = 3;
            this.label5.Text = "Text|20052";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(216, 23);
            this.label6.TabIndex = 41;
            this.label6.Text = "Point|20059";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.m_txtTypePoint);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 50);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(216, 27);
            this.panel6.TabIndex = 42;
            // 
            // m_txtTypePoint
            // 
            this.m_txtTypePoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtTypePoint.ElementSelectionne = null;
            this.m_txtTypePoint.FonctionTextNull = null;
            this.m_txtTypePoint.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_txtTypePoint.Location = new System.Drawing.Point(76, 0);
            this.m_txtTypePoint.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtTypePoint, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtTypePoint.Name = "m_txtTypePoint";
            this.m_txtTypePoint.SelectedObject = null;
            this.m_txtTypePoint.SelectionLength = 0;
            this.m_txtTypePoint.SelectionStart = 0;
            this.m_txtTypePoint.Size = new System.Drawing.Size(140, 27);
            this.m_txtTypePoint.SpecificImage = null;
            this.m_txtTypePoint.TabIndex = 6;
            this.m_txtTypePoint.TextNull = "";
            this.m_txtTypePoint.UseIntellisense = true;
            this.m_txtTypePoint.ElementSelectionneChanged += new System.EventHandler(this.m_txtTypePoint_ElementSelectionneChanged);
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 27);
            this.label7.TabIndex = 3;
            this.label7.Text = "Point type|20065";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CControleEditeGpsPoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.m_panelPointType);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.label6);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleEditeGpsPoint";
            this.Size = new System.Drawing.Size(216, 190);
            this.m_panelPointType.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel m_panelPointType;
        private sc2i.win32.common.CComboboxAutoFilled m_cmbMarkerType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox m_chkPermanentTooltip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
        private sc2i.win32.common.C2iTextBoxNumeriqueAvecUnite m_txtLatitude;
        private System.Windows.Forms.Panel panel4;
        private sc2i.win32.common.C2iTextBoxNumeriqueAvecUnite m_txtLongitude;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label5;
        private sc2i.win32.common.C2iTextBox m_txtLibelle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label7;
        private sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide m_txtTypePoint;
    }
}
