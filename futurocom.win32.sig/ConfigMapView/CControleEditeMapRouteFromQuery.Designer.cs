namespace futurocom.win32.sig
{
    partial class CControleEditeMapRouteFromQuery
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
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.m_panelQuery = new futurocom.win32.easyquery.CEditeurEasyQuery();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.m_txtDistancePoint = new sc2i.win32.common.C2iTextBoxNumerique();
            this.label6 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.m_cmbLabel = new sc2i.win32.common.C2iComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.m_cmbGroupBy = new sc2i.win32.common.C2iComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_cmbLongitude = new sc2i.win32.common.C2iComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_cmbLatitude = new sc2i.win32.common.C2iComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_cmbTable = new sc2i.win32.common.C2iComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.m_tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_tabControl
            // 
            this.m_tabControl.BoldSelectedPage = true;
            this.m_tabControl.ControlBottomOffset = 16;
            this.m_tabControl.ControlRightOffset = 16;
            this.m_tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tabControl.IDEPixelArea = false;
            this.m_tabControl.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.tabPage1;
            this.m_tabControl.Size = new System.Drawing.Size(565, 388);
            this.m_tabControl.TabIndex = 0;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2});
            this.m_tabControl.SelectionChanged += new System.EventHandler(this.m_tabControl_SelectionChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_panelQuery);
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.m_extModeEdition.SetModeEdition(this.tabPage1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Selected = false;
            this.tabPage1.Size = new System.Drawing.Size(549, 347);
            this.tabPage1.TabIndex = 10;
            this.tabPage1.Title = "Query|20035";
            // 
            // m_panelQuery
            // 
            this.m_panelQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelQuery.Location = new System.Drawing.Point(0, 0);
            this.m_panelQuery.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_panelQuery, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelQuery.Name = "m_panelQuery";
            this.m_panelQuery.Size = new System.Drawing.Size(549, 347);
            this.m_panelQuery.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel6);
            this.tabPage2.Controls.Add(this.panel5);
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.panel8);
            this.tabPage2.Controls.Add(this.panel7);
            this.tabPage2.Location = new System.Drawing.Point(0, 25);
            this.m_extModeEdition.SetModeEdition(this.tabPage2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(549, 347);
            this.tabPage2.TabIndex = 11;
            this.tabPage2.Title = "Path parameters|20026";
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.label7);
            this.panel6.Controls.Add(this.m_txtDistancePoint);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 148);
            this.m_extModeEdition.SetModeEdition(this.panel6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(549, 23);
            this.panel6.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Location = new System.Drawing.Point(221, 0);
            this.m_extModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 21);
            this.label7.TabIndex = 2;
            this.label7.Text = "m";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtDistancePoint
            // 
            this.m_txtDistancePoint.Arrondi = 0;
            this.m_txtDistancePoint.DecimalAutorise = true;
            this.m_txtDistancePoint.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_txtDistancePoint.EmptyText = "";
            this.m_txtDistancePoint.IntValue = 0;
            this.m_txtDistancePoint.Location = new System.Drawing.Point(150, 0);
            this.m_txtDistancePoint.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtDistancePoint, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtDistancePoint.Name = "m_txtDistancePoint";
            this.m_txtDistancePoint.NullAutorise = false;
            this.m_txtDistancePoint.SelectAllOnEnter = true;
            this.m_txtDistancePoint.SeparateurMilliers = "";
            this.m_txtDistancePoint.Size = new System.Drawing.Size(71, 21);
            this.m_txtDistancePoint.TabIndex = 1;
            this.m_txtDistancePoint.Text = "0";
            this.m_txtDistancePoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 21);
            this.label6.TabIndex = 0;
            this.label6.Text = "Min. distance|20042";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.m_cmbLabel);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 125);
            this.m_extModeEdition.SetModeEdition(this.panel5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(549, 23);
            this.panel5.TabIndex = 5;
            // 
            // m_cmbLabel
            // 
            this.m_cmbLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_cmbLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbLabel.FormattingEnabled = true;
            this.m_cmbLabel.IsLink = false;
            this.m_cmbLabel.Location = new System.Drawing.Point(150, 0);
            this.m_cmbLabel.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_cmbLabel, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbLabel.Name = "m_cmbLabel";
            this.m_cmbLabel.Size = new System.Drawing.Size(270, 24);
            this.m_cmbLabel.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "Label[20041";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.m_cmbGroupBy);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 102);
            this.m_extModeEdition.SetModeEdition(this.panel4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(549, 23);
            this.panel4.TabIndex = 4;
            // 
            // m_cmbGroupBy
            // 
            this.m_cmbGroupBy.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_cmbGroupBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbGroupBy.FormattingEnabled = true;
            this.m_cmbGroupBy.IsLink = false;
            this.m_cmbGroupBy.Location = new System.Drawing.Point(150, 0);
            this.m_cmbGroupBy.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_cmbGroupBy, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbGroupBy.Name = "m_cmbGroupBy";
            this.m_cmbGroupBy.Size = new System.Drawing.Size(270, 24);
            this.m_cmbGroupBy.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "Group by|20040";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.m_cmbLongitude);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 79);
            this.m_extModeEdition.SetModeEdition(this.panel3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(549, 23);
            this.panel3.TabIndex = 3;
            // 
            // m_cmbLongitude
            // 
            this.m_cmbLongitude.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_cmbLongitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbLongitude.FormattingEnabled = true;
            this.m_cmbLongitude.IsLink = false;
            this.m_cmbLongitude.Location = new System.Drawing.Point(150, 0);
            this.m_cmbLongitude.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_cmbLongitude, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbLongitude.Name = "m_cmbLongitude";
            this.m_cmbLongitude.Size = new System.Drawing.Size(270, 24);
            this.m_cmbLongitude.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "Longitude field|20039";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.m_cmbLatitude);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 56);
            this.m_extModeEdition.SetModeEdition(this.panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(549, 23);
            this.panel2.TabIndex = 2;
            // 
            // m_cmbLatitude
            // 
            this.m_cmbLatitude.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_cmbLatitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbLatitude.FormattingEnabled = true;
            this.m_cmbLatitude.IsLink = false;
            this.m_cmbLatitude.Location = new System.Drawing.Point(150, 0);
            this.m_cmbLatitude.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_cmbLatitude, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbLatitude.Name = "m_cmbLatitude";
            this.m_cmbLatitude.Size = new System.Drawing.Size(270, 24);
            this.m_cmbLatitude.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Latitude field|20038";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.m_cmbTable);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.m_extModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(549, 23);
            this.panel1.TabIndex = 1;
            // 
            // m_cmbTable
            // 
            this.m_cmbTable.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_cmbTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbTable.FormattingEnabled = true;
            this.m_cmbTable.IsLink = false;
            this.m_cmbTable.Location = new System.Drawing.Point(150, 0);
            this.m_cmbTable.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_cmbTable, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbTable.Name = "m_cmbTable";
            this.m_cmbTable.Size = new System.Drawing.Size(270, 24);
            this.m_cmbTable.TabIndex = 1;
            this.m_cmbTable.SelectionChangeCommitted += new System.EventHandler(this.m_cmbTable_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source table|20037";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.m_txtLibelle);
            this.panel7.Controls.Add(this.label8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.panel7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(549, 23);
            this.panel7.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.label8, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(150, 21);
            this.label8.TabIndex = 1;
            this.label8.Text = "Label|20003";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtLibelle
            // 
            this.m_txtLibelle.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_txtLibelle.EmptyText = "";
            this.m_txtLibelle.Location = new System.Drawing.Point(150, 0);
            this.m_txtLibelle.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(270, 21);
            this.m_txtLibelle.TabIndex = 2;
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 23);
            this.m_extModeEdition.SetModeEdition(this.panel8, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(549, 10);
            this.panel8.TabIndex = 13;
            // 
            // CControleEditeMapRouteFromQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_tabControl);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleEditeMapRouteFromQuery";
            this.Size = new System.Drawing.Size(565, 388);
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
        private sc2i.win32.common.C2iTabControl m_tabControl;
        private Crownwood.Magic.Controls.TabPage tabPage2;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private futurocom.win32.easyquery.CEditeurEasyQuery m_panelQuery;
        private System.Windows.Forms.Panel panel5;
        private sc2i.win32.common.C2iComboBox m_cmbLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private sc2i.win32.common.C2iComboBox m_cmbGroupBy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private sc2i.win32.common.C2iComboBox m_cmbLongitude;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private sc2i.win32.common.C2iComboBox m_cmbLatitude;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private sc2i.win32.common.C2iComboBox m_cmbTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel6;
        private sc2i.win32.common.C2iTextBoxNumerique m_txtDistancePoint;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel8;
        private sc2i.win32.common.C2iTextBox m_txtLibelle;
    }
}
