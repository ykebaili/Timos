namespace futurocom.win32.sig
{
    partial class CControleEditeMapLineDessin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_lblFormuleTooltip = new System.Windows.Forms.Label();
            this.m_txtFormuleTooltip = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.label1 = new System.Windows.Forms.Label();
            this.m_chkPermanent = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_txtFormuleCondition = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.m_lblFormuleCondition = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.panel5 = new System.Windows.Forms.Panel();
            this.m_picDragDrop = new System.Windows.Forms.PictureBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.m_btnDelete = new System.Windows.Forms.PictureBox();
            this.m_selectLineColor = new sc2i.win32.common.C2iColorSelect();
            this.m_wndLineWidth = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_picDragDrop)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_wndLineWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_lblFormuleTooltip);
            this.panel1.Controls.Add(this.m_txtFormuleTooltip);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.m_chkPermanent);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(26, 0);
            this.m_extModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(357, 25);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 0;
            // 
            // m_lblFormuleTooltip
            // 
            this.m_lblFormuleTooltip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.m_lblFormuleTooltip.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblFormuleTooltip.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_lblFormuleTooltip.Location = new System.Drawing.Point(98, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lblFormuleTooltip, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblFormuleTooltip.Name = "m_lblFormuleTooltip";
            this.m_lblFormuleTooltip.Size = new System.Drawing.Size(196, 23);
            this.m_extStyle.SetStyleBackColor(this.m_lblFormuleTooltip, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblFormuleTooltip, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblFormuleTooltip.TabIndex = 2;
            this.m_lblFormuleTooltip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblFormuleTooltip.Visible = false;
            // 
            // m_txtFormuleTooltip
            // 
            this.m_txtFormuleTooltip.AllowGraphic = true;
            this.m_txtFormuleTooltip.AllowNullFormula = false;
            this.m_txtFormuleTooltip.AllowSaisieTexte = true;
            this.m_txtFormuleTooltip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtFormuleTooltip.Formule = null;
            this.m_txtFormuleTooltip.Location = new System.Drawing.Point(98, 0);
            this.m_txtFormuleTooltip.LockEdition = false;
            this.m_txtFormuleTooltip.LockZoneTexte = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtFormuleTooltip, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtFormuleTooltip.Name = "m_txtFormuleTooltip";
            this.m_txtFormuleTooltip.Size = new System.Drawing.Size(196, 25);
            this.m_extStyle.SetStyleBackColor(this.m_txtFormuleTooltip, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFormuleTooltip, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleTooltip.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 25);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tooltip|20004";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_chkPermanent
            // 
            this.m_chkPermanent.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_chkPermanent.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_chkPermanent.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.m_chkPermanent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_chkPermanent.Location = new System.Drawing.Point(294, 0);
            this.m_extModeEdition.SetModeEdition(this.m_chkPermanent, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkPermanent.Name = "m_chkPermanent";
            this.m_chkPermanent.Size = new System.Drawing.Size(63, 25);
            this.m_extStyle.SetStyleBackColor(this.m_chkPermanent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkPermanent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkPermanent.TabIndex = 0;
            this.m_chkPermanent.Text = "Always|20032";
            this.m_chkPermanent.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_txtFormuleCondition);
            this.panel2.Controls.Add(this.m_lblFormuleCondition);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(26, 25);
            this.m_extModeEdition.SetModeEdition(this.panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(357, 25);
            this.m_extStyle.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel2.TabIndex = 1;
            // 
            // m_txtFormuleCondition
            // 
            this.m_txtFormuleCondition.AllowGraphic = true;
            this.m_txtFormuleCondition.AllowNullFormula = false;
            this.m_txtFormuleCondition.AllowSaisieTexte = true;
            this.m_txtFormuleCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtFormuleCondition.Formule = null;
            this.m_txtFormuleCondition.Location = new System.Drawing.Point(98, 23);
            this.m_txtFormuleCondition.LockEdition = false;
            this.m_txtFormuleCondition.LockZoneTexte = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtFormuleCondition, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtFormuleCondition.Name = "m_txtFormuleCondition";
            this.m_txtFormuleCondition.Size = new System.Drawing.Size(259, 2);
            this.m_extStyle.SetStyleBackColor(this.m_txtFormuleCondition, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFormuleCondition, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleCondition.TabIndex = 1;
            // 
            // m_lblFormuleCondition
            // 
            this.m_lblFormuleCondition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.m_lblFormuleCondition.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblFormuleCondition.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_lblFormuleCondition.Location = new System.Drawing.Point(98, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lblFormuleCondition, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblFormuleCondition.Name = "m_lblFormuleCondition";
            this.m_lblFormuleCondition.Size = new System.Drawing.Size(259, 23);
            this.m_extStyle.SetStyleBackColor(this.m_lblFormuleCondition, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblFormuleCondition, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblFormuleCondition.TabIndex = 3;
            this.m_lblFormuleCondition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblFormuleCondition.Visible = false;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 25);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 0;
            this.label2.Text = "Condition|20005";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.m_wndLineWidth);
            this.panel3.Controls.Add(this.m_selectLineColor);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(26, 50);
            this.m_extModeEdition.SetModeEdition(this.panel3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(357, 22);
            this.m_extStyle.SetStyleBackColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel3.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 22);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 1;
            this.label3.Text = "Line|20047";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.Location = new System.Drawing.Point(26, 80);
            this.m_extModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(357, 1);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.m_picDragDrop);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.panel5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(26, 81);
            this.m_extStyle.SetStyleBackColor(this.panel5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel5.TabIndex = 2;
            // 
            // m_picDragDrop
            // 
            this.m_picDragDrop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_picDragDrop.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_picDragDrop.Image = global::futurocom.win32.sig.Resource.Pushpin;
            this.m_picDragDrop.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_picDragDrop, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_picDragDrop.Name = "m_picDragDrop";
            this.m_picDragDrop.Size = new System.Drawing.Size(26, 44);
            this.m_extStyle.SetStyleBackColor(this.m_picDragDrop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_picDragDrop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_picDragDrop.TabIndex = 0;
            this.m_picDragDrop.TabStop = false;
            this.m_picDragDrop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_picDragDrop_MouseDown);
            this.m_picDragDrop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.m_picDragDrop_MouseMove);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.m_btnDelete);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(383, 0);
            this.m_extModeEdition.SetModeEdition(this.panel6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(26, 81);
            this.m_extStyle.SetStyleBackColor(this.panel6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel6.TabIndex = 4;
            // 
            // m_btnDelete
            // 
            this.m_btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnDelete.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_btnDelete.Image = global::futurocom.win32.sig.Resource.delete;
            this.m_btnDelete.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnDelete, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnDelete.Name = "m_btnDelete";
            this.m_btnDelete.Size = new System.Drawing.Size(26, 22);
            this.m_btnDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_extStyle.SetStyleBackColor(this.m_btnDelete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnDelete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnDelete.TabIndex = 0;
            this.m_btnDelete.TabStop = false;
            this.m_btnDelete.Click += new System.EventHandler(this.m_btnDelete_Click);
            // 
            // m_selectLineColor
            // 
            this.m_selectLineColor.BackColor = System.Drawing.Color.White;
            this.m_selectLineColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_selectLineColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_selectLineColor.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_selectLineColor.Location = new System.Drawing.Point(98, 0);
            this.m_selectLineColor.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_selectLineColor, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_selectLineColor.Name = "m_selectLineColor";
            this.m_selectLineColor.SelectedColor = System.Drawing.Color.White;
            this.m_selectLineColor.Size = new System.Drawing.Size(56, 22);
            this.m_extStyle.SetStyleBackColor(this.m_selectLineColor, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_selectLineColor, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectLineColor.TabIndex = 0;
            // 
            // m_wndLineWidth
            // 
            this.m_wndLineWidth.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_wndLineWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_wndLineWidth.Location = new System.Drawing.Point(154, 0);
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
            this.m_extModeEdition.SetModeEdition(this.m_wndLineWidth, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_wndLineWidth.Name = "m_wndLineWidth";
            this.m_wndLineWidth.Size = new System.Drawing.Size(65, 22);
            this.m_extStyle.SetStyleBackColor(this.m_wndLineWidth, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndLineWidth, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndLineWidth.TabIndex = 2;
            this.m_wndLineWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(219, 0);
            this.m_extModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 22);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 5;
            this.label5.Text = "Pixels|20048";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CControleEditeMapLineDessin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(254)))));
            this.ColorInactive = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel6);
            this.ForeColor = System.Drawing.Color.Black;
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleEditeMapLineDessin";
            this.Size = new System.Drawing.Size(409, 81);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_picDragDrop)).EndInit();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_wndLineWidth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleTooltip;
        private System.Windows.Forms.Panel panel2;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleCondition;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private sc2i.win32.common.CExtStyle m_extStyle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox m_picDragDrop;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.PictureBox m_btnDelete;
        private System.Windows.Forms.Label m_lblFormuleTooltip;
        private System.Windows.Forms.Label m_lblFormuleCondition;
        private System.Windows.Forms.CheckBox m_chkPermanent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown m_wndLineWidth;
        private sc2i.win32.common.C2iColorSelect m_selectLineColor;
    }
}
