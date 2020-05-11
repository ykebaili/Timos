namespace timos.process.workflow
{
    partial class CFormEditionBlocWorkflowProjet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionBlocWorkflowProjet));
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.c2iPanelOmbre1 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_txtSelectWorkflow = new sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_btnAnnuler = new System.Windows.Forms.Button();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_lnkAffectations = new System.Windows.Forms.LinkLabel();
            this.m_cmbProjectField = new sc2i.win32.data.CComboBoxListeObjetsDonnees();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtSelectTypeProjet = new sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageProjet = new Crownwood.Magic.Controls.TabPage();
            this.m_txtFormuleGanttId = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.label4 = new System.Windows.Forms.Label();
            this.m_tooltip = new sc2i.win32.common.CToolTipTraductible(this.components);
            this.m_chkGererIterations = new System.Windows.Forms.CheckBox();
            this.c2iPanelOmbre1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.m_pageProjet.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 16);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 1;
            this.label1.Text = "Workflow|20563";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // c2iPanelOmbre1
            // 
            this.c2iPanelOmbre1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre1.Controls.Add(this.label1);
            this.c2iPanelOmbre1.Controls.Add(this.m_txtSelectWorkflow);
            this.c2iPanelOmbre1.Dock = System.Windows.Forms.DockStyle.Top;
            this.c2iPanelOmbre1.ForeColor = System.Drawing.Color.Black;
            this.c2iPanelOmbre1.Location = new System.Drawing.Point(0, 0);
            this.c2iPanelOmbre1.LockEdition = false;
            this.c2iPanelOmbre1.Name = "c2iPanelOmbre1";
            this.c2iPanelOmbre1.Size = new System.Drawing.Size(725, 49);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre1.TabIndex = 3;
            // 
            // m_txtSelectWorkflow
            // 
            this.m_txtSelectWorkflow.ElementSelectionne = null;
            this.m_txtSelectWorkflow.FonctionTextNull = null;
            this.m_txtSelectWorkflow.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_txtSelectWorkflow.Location = new System.Drawing.Point(189, 6);
            this.m_txtSelectWorkflow.LockEdition = false;
            this.m_txtSelectWorkflow.Name = "m_txtSelectWorkflow";
            this.m_txtSelectWorkflow.SelectedObject = null;
            this.m_txtSelectWorkflow.SelectionLength = 0;
            this.m_txtSelectWorkflow.SelectionStart = 0;
            this.m_txtSelectWorkflow.Size = new System.Drawing.Size(502, 25);
            this.m_txtSelectWorkflow.SpecificImage = null;
            this.m_extStyle.SetStyleBackColor(this.m_txtSelectWorkflow, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSelectWorkflow, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectWorkflow.TabIndex = 1;
            this.m_txtSelectWorkflow.TextNull = "";
            this.m_txtSelectWorkflow.UseIntellisense = true;
            this.m_txtSelectWorkflow.Load += new System.EventHandler(this.CFormEditionBlocWorkflowProjet_Load);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_btnAnnuler);
            this.panel1.Controls.Add(this.m_btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 381);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(725, 48);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 4;
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnAnnuler.ForeColor = System.Drawing.Color.White;
            this.m_btnAnnuler.Image = ((System.Drawing.Image)(resources.GetObject("m_btnAnnuler.Image")));
            this.m_btnAnnuler.Location = new System.Drawing.Point(369, 2);
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(40, 40);
            this.m_extStyle.SetStyleBackColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAnnuler.TabIndex = 3;
            this.m_btnAnnuler.Click += new System.EventHandler(this.m_btnAnnuler_Click);
            // 
            // m_btnOk
            // 
            this.m_btnOk.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnOk.ForeColor = System.Drawing.Color.White;
            this.m_btnOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btnOk.Image")));
            this.m_btnOk.Location = new System.Drawing.Point(315, 2);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(40, 40);
            this.m_extStyle.SetStyleBackColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnOk.TabIndex = 2;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            // 
            // m_lnkAffectationsCreation
            // 
            this.m_lnkAffectations.AutoSize = true;
            this.m_lnkAffectations.Location = new System.Drawing.Point(186, 124);
            this.m_lnkAffectations.Name = "m_lnkAffectationsCreation";
            this.m_lnkAffectations.Size = new System.Drawing.Size(131, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAffectations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAffectations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAffectations.TabIndex = 3;
            this.m_lnkAffectations.TabStop = true;
            this.m_lnkAffectations.Text = "Project intialization (creation and start)|20568";
            this.m_lnkAffectations.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkAffectationsCreation_LinkClicked);
            // 
            // m_cmbProjectField
            // 
            this.m_cmbProjectField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbProjectField.ElementSelectionne = null;
            this.m_cmbProjectField.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbProjectField.FormattingEnabled = true;
            this.m_cmbProjectField.IsLink = false;
            this.m_cmbProjectField.ListDonnees = null;
            this.m_cmbProjectField.Location = new System.Drawing.Point(186, 38);
            this.m_cmbProjectField.LockEdition = false;
            this.m_cmbProjectField.Name = "m_cmbProjectField";
            this.m_cmbProjectField.NullAutorise = false;
            this.m_cmbProjectField.ProprieteAffichee = null;
            this.m_cmbProjectField.ProprieteParentListeObjets = null;
            this.m_cmbProjectField.SelectionneurParent = null;
            this.m_cmbProjectField.Size = new System.Drawing.Size(320, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbProjectField, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbProjectField, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbProjectField.TabIndex = 2;
            this.m_cmbProjectField.TextNull = "(empty)";
            this.m_tooltip.SetToolTip(this.m_cmbProjectField, "Select here the workflow field that will store associated project in the workflow" +
                    "|20567");
            this.m_cmbProjectField.Tri = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 16);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 1;
            this.label3.Text = "Project field|20566";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 16);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 1;
            this.label2.Text = "Project type|20565";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtSelectTypeProjet
            // 
            this.m_txtSelectTypeProjet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtSelectTypeProjet.ElementSelectionne = null;
            this.m_txtSelectTypeProjet.FonctionTextNull = null;
            this.m_txtSelectTypeProjet.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_txtSelectTypeProjet.Location = new System.Drawing.Point(186, 6);
            this.m_txtSelectTypeProjet.LockEdition = false;
            this.m_txtSelectTypeProjet.Name = "m_txtSelectTypeProjet";
            this.m_txtSelectTypeProjet.SelectedObject = null;
            this.m_txtSelectTypeProjet.SelectionLength = 0;
            this.m_txtSelectTypeProjet.SelectionStart = 0;
            this.m_txtSelectTypeProjet.Size = new System.Drawing.Size(502, 25);
            this.m_txtSelectTypeProjet.SpecificImage = null;
            this.m_extStyle.SetStyleBackColor(this.m_txtSelectTypeProjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSelectTypeProjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectTypeProjet.TabIndex = 1;
            this.m_txtSelectTypeProjet.TextNull = "";
            this.m_txtSelectTypeProjet.UseIntellisense = true;
            this.m_txtSelectTypeProjet.Load += new System.EventHandler(this.CFormEditionBlocWorkflowProjet_Load);
            // 
            // m_tabControl
            // 
            this.m_tabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_tabControl.BoldSelectedPage = true;
            this.m_tabControl.ControlBottomOffset = 16;
            this.m_tabControl.ControlRightOffset = 16;
            this.m_tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tabControl.ForeColor = System.Drawing.Color.Black;
            this.m_tabControl.IDEPixelArea = false;
            this.m_tabControl.Location = new System.Drawing.Point(0, 49);
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.m_pageProjet;
            this.m_tabControl.Size = new System.Drawing.Size(725, 332);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 5;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageProjet});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageProjet
            // 
            this.m_pageProjet.Controls.Add(this.m_chkGererIterations);
            this.m_pageProjet.Controls.Add(this.m_txtFormuleGanttId);
            this.m_pageProjet.Controls.Add(this.label2);
            this.m_pageProjet.Controls.Add(this.m_lnkAffectations);
            this.m_pageProjet.Controls.Add(this.m_txtSelectTypeProjet);
            this.m_pageProjet.Controls.Add(this.m_cmbProjectField);
            this.m_pageProjet.Controls.Add(this.label4);
            this.m_pageProjet.Controls.Add(this.label3);
            this.m_pageProjet.Location = new System.Drawing.Point(0, 25);
            this.m_pageProjet.Name = "m_pageProjet";
            this.m_pageProjet.Size = new System.Drawing.Size(709, 291);
            this.m_extStyle.SetStyleBackColor(this.m_pageProjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageProjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageProjet.TabIndex = 10;
            this.m_pageProjet.Title = "Project detail|20564";
            // 
            // m_txtFormuleGanttId
            // 
            this.m_txtFormuleGanttId.AllowGraphic = true;
            this.m_txtFormuleGanttId.AllowNullFormula = false;
            this.m_txtFormuleGanttId.AllowSaisieTexte = true;
            this.m_txtFormuleGanttId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormuleGanttId.Formule = null;
            this.m_txtFormuleGanttId.Location = new System.Drawing.Point(186, 72);
            this.m_txtFormuleGanttId.LockEdition = false;
            this.m_txtFormuleGanttId.LockZoneTexte = false;
            this.m_txtFormuleGanttId.Name = "m_txtFormuleGanttId";
            this.m_txtFormuleGanttId.Size = new System.Drawing.Size(502, 38);
            this.m_extStyle.SetStyleBackColor(this.m_txtFormuleGanttId, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFormuleGanttId, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleGanttId.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(9, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 16);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 1;
            this.label4.Text = "Project Key|20569";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_chkGererIterations
            // 
            this.m_chkGererIterations.AutoSize = true;
            this.m_chkGererIterations.Location = new System.Drawing.Point(189, 145);
            this.m_chkGererIterations.Name = "m_chkGererIterations";
            this.m_chkGererIterations.Size = new System.Drawing.Size(150, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkGererIterations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkGererIterations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkGererIterations.TabIndex = 5;
            this.m_chkGererIterations.Text = "Manager iterations|20767";
            this.m_chkGererIterations.UseVisualStyleBackColor = true;
            // 
            // CFormEditionBlocWorkflowProjet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 429);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.c2iPanelOmbre1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "CFormEditionBlocWorkflowProjet";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondFenetre);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTexteFenetre);
            this.Text = "Project workflow|20562";
            this.c2iPanelOmbre1.ResumeLayout(false);
            this.c2iPanelOmbre1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.m_pageProjet.ResumeLayout(false);
            this.m_pageProjet.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.CExtStyle m_extStyle;
        private System.Windows.Forms.Label label1;
        private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button m_btnAnnuler;
        private System.Windows.Forms.Button m_btnOk;
        private sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide m_txtSelectWorkflow;
        private System.Windows.Forms.Label label2;
        private sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide m_txtSelectTypeProjet;
        private System.Windows.Forms.Label label3;
        private sc2i.win32.data.CComboBoxListeObjetsDonnees m_cmbProjectField;
        private sc2i.win32.common.CToolTipTraductible m_tooltip;
        private System.Windows.Forms.LinkLabel m_lnkAffectations;
        private sc2i.win32.common.C2iTabControl m_tabControl;
        private Crownwood.Magic.Controls.TabPage m_pageProjet;
        private System.Windows.Forms.Label label4;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleGanttId;
        private System.Windows.Forms.CheckBox m_chkGererIterations;
    }
}