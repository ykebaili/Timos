namespace futurocom.win32.sig.cartography
{
    partial class CControleEditeGpsSegment
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
            this.m_panelColor = new System.Windows.Forms.Panel();
            this.m_selectLineColor = new sc2i.win32.common.C2iColorSelect();
            this.label3 = new System.Windows.Forms.Label();
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
            this.m_panelWidth = new System.Windows.Forms.Panel();
            this.m_wndLineWidth = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.m_txtTypeLigne = new sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide();
            this.label7 = new System.Windows.Forms.Label();
            this.m_panelColor.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.m_panelWidth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_wndLineWidth)).BeginInit();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelColor
            // 
            this.m_panelColor.Controls.Add(this.m_selectLineColor);
            this.m_panelColor.Controls.Add(this.label3);
            this.m_panelColor.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelColor.Location = new System.Drawing.Point(0, 77);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelColor, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelColor.Name = "m_panelColor";
            this.m_panelColor.Size = new System.Drawing.Size(216, 27);
            this.m_panelColor.TabIndex = 10;
            // 
            // m_selectLineColor
            // 
            this.m_selectLineColor.BackColor = System.Drawing.Color.White;
            this.m_selectLineColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_selectLineColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_selectLineColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_selectLineColor.Location = new System.Drawing.Point(76, 0);
            this.m_selectLineColor.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_selectLineColor, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_selectLineColor.Name = "m_selectLineColor";
            this.m_selectLineColor.SelectedColor = System.Drawing.Color.White;
            this.m_selectLineColor.Size = new System.Drawing.Size(140, 27);
            this.m_selectLineColor.TabIndex = 4;
            this.m_selectLineColor.OnChangeSelectedColor += new System.EventHandler(this.m_selectLineColor_OnChangeSelectedColor);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 27);
            this.label3.TabIndex = 3;
            this.label3.Text = "Color|20060";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.label6.Text = "Segment|20062";
            // 
            // m_panelWidth
            // 
            this.m_panelWidth.Controls.Add(this.m_wndLineWidth);
            this.m_panelWidth.Controls.Add(this.label1);
            this.m_panelWidth.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelWidth.Location = new System.Drawing.Point(0, 104);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelWidth, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelWidth.Name = "m_panelWidth";
            this.m_panelWidth.Size = new System.Drawing.Size(216, 27);
            this.m_panelWidth.TabIndex = 20;
            // 
            // m_wndLineWidth
            // 
            this.m_wndLineWidth.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_wndLineWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_wndLineWidth.Location = new System.Drawing.Point(76, 0);
            this.m_wndLineWidth.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.m_wndLineWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndLineWidth, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_wndLineWidth.Name = "m_wndLineWidth";
            this.m_wndLineWidth.Size = new System.Drawing.Size(65, 22);
            this.m_wndLineWidth.TabIndex = 4;
            this.m_wndLineWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_wndLineWidth.Validated += new System.EventHandler(this.m_wndLineWidth_Validated);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "Width|20061";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.m_txtTypeLigne);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 50);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(216, 27);
            this.panel6.TabIndex = 5;
            // 
            // m_txtTypeLigne
            // 
            this.m_txtTypeLigne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtTypeLigne.ElementSelectionne = null;
            this.m_txtTypeLigne.FonctionTextNull = null;
            this.m_txtTypeLigne.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_txtTypeLigne.Location = new System.Drawing.Point(76, 0);
            this.m_txtTypeLigne.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtTypeLigne, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtTypeLigne.Name = "m_txtTypeLigne";
            this.m_txtTypeLigne.SelectedObject = null;
            this.m_txtTypeLigne.SelectionLength = 0;
            this.m_txtTypeLigne.SelectionStart = 0;
            this.m_txtTypeLigne.Size = new System.Drawing.Size(140, 27);
            this.m_txtTypeLigne.SpecificImage = null;
            this.m_txtTypeLigne.TabIndex = 5;
            this.m_txtTypeLigne.TextNull = "";
            this.m_txtTypeLigne.UseIntellisense = true;
            this.m_txtTypeLigne.OnSelectedObjectChanged += new System.EventHandler(this.m_txtTypeLigne_OnSelectedObjectChanged);
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 27);
            this.label7.TabIndex = 3;
            this.label7.Text = "Line type|20065";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CControleEditeGpsSegment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.m_panelWidth);
            this.Controls.Add(this.m_panelColor);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.label6);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleEditeGpsSegment";
            this.Size = new System.Drawing.Size(216, 193);
            this.m_panelColor.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.m_panelWidth.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_wndLineWidth)).EndInit();
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel m_panelColor;
        private System.Windows.Forms.Label label3;
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
        private sc2i.win32.common.C2iColorSelect m_selectLineColor;
        private System.Windows.Forms.Panel m_panelWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown m_wndLineWidth;
        private System.Windows.Forms.Panel panel6;
        private sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide m_txtTypeLigne;
        private System.Windows.Forms.Label label7;
    }
}
