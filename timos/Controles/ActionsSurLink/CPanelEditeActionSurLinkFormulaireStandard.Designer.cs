namespace timos.Controles.ActionsSurLink
{
    partial class CPanelEditeActionSurLinkFormulaireStandard
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
            this.m_panelFormulaire = new System.Windows.Forms.Panel();
            this.m_panelParametresFormulaire = new System.Windows.Forms.Panel();
            this.m_splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.m_wndListeParametres = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn2 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.label13 = new System.Windows.Forms.Label();
            this.m_splitContainerInfosParam = new System.Windows.Forms.SplitContainer();
            this.m_lblNomParametre = new System.Windows.Forms.Label();
            this.m_txtFormuleParametre = new sc2i.win32.expression.CControleEditeFormule();
            this.label15 = new System.Windows.Forms.Label();
            this.m_lblDescriptionParametre = new System.Windows.Forms.Label();
            this.m_txtContexteFormulaire = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_cmbFormulaireStandard = new sc2i.win32.common.CComboboxAutoFilled();
            this.label2 = new System.Windows.Forms.Label();
            this.m_wndAideFormuleParametre = new sc2i.win32.expression.CControlAideFormule();
            this.m_panelFormulaire.SuspendLayout();
            this.m_panelParametresFormulaire.SuspendLayout();
            this.m_splitContainer1.Panel1.SuspendLayout();
            this.m_splitContainer1.Panel2.SuspendLayout();
            this.m_splitContainer1.SuspendLayout();
            this.m_splitContainer2.Panel1.SuspendLayout();
            this.m_splitContainer2.Panel2.SuspendLayout();
            this.m_splitContainer2.SuspendLayout();
            this.m_splitContainerInfosParam.Panel1.SuspendLayout();
            this.m_splitContainerInfosParam.Panel2.SuspendLayout();
            this.m_splitContainerInfosParam.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelFormulaire
            // 
            this.m_panelFormulaire.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelFormulaire.Controls.Add(this.m_panelParametresFormulaire);
            this.m_panelFormulaire.Controls.Add(this.m_txtContexteFormulaire);
            this.m_panelFormulaire.Controls.Add(this.label5);
            this.m_panelFormulaire.Controls.Add(this.m_cmbFormulaireStandard);
            this.m_panelFormulaire.Controls.Add(this.label2);
            this.m_panelFormulaire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelFormulaire.ForeColor = System.Drawing.Color.Black;
            this.m_panelFormulaire.Location = new System.Drawing.Point(0, 0);
            this.m_panelFormulaire.Name = "m_panelFormulaire";
            this.m_panelFormulaire.Size = new System.Drawing.Size(702, 381);
            this.m_panelFormulaire.TabIndex = 6;
            // 
            // m_panelParametresFormulaire
            // 
            this.m_panelParametresFormulaire.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelParametresFormulaire.Controls.Add(this.m_splitContainer1);
            this.m_panelParametresFormulaire.Location = new System.Drawing.Point(0, 55);
            this.m_panelParametresFormulaire.Name = "m_panelParametresFormulaire";
            this.m_panelParametresFormulaire.Size = new System.Drawing.Size(702, 323);
            this.m_panelParametresFormulaire.TabIndex = 11;
            // 
            // m_splitContainer1
            // 
            this.m_splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.m_splitContainer1.Name = "m_splitContainer1";
            // 
            // m_splitContainer1.Panel1
            // 
            this.m_splitContainer1.Panel1.Controls.Add(this.m_splitContainer2);
            // 
            // m_splitContainer1.Panel2
            // 
            this.m_splitContainer1.Panel2.Controls.Add(this.m_wndAideFormuleParametre);
            this.m_splitContainer1.Size = new System.Drawing.Size(702, 323);
            this.m_splitContainer1.SplitterDistance = 478;
            this.m_splitContainer1.TabIndex = 10;
            // 
            // m_splitContainer2
            // 
            this.m_splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.m_splitContainer2.Name = "m_splitContainer2";
            // 
            // m_splitContainer2.Panel1
            // 
            this.m_splitContainer2.Panel1.Controls.Add(this.m_wndListeParametres);
            this.m_splitContainer2.Panel1.Controls.Add(this.label13);
            // 
            // m_splitContainer2.Panel2
            // 
            this.m_splitContainer2.Panel2.Controls.Add(this.m_splitContainerInfosParam);
            this.m_splitContainer2.Size = new System.Drawing.Size(476, 321);
            this.m_splitContainer2.SplitterDistance = 198;
            this.m_splitContainer2.TabIndex = 5;
            // 
            // m_wndListeParametres
            // 
            this.m_wndListeParametres.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn2});
            this.m_wndListeParametres.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeParametres.EnableCustomisation = true;
            this.m_wndListeParametres.FullRowSelect = true;
            this.m_wndListeParametres.Location = new System.Drawing.Point(0, 0);
            this.m_wndListeParametres.MultiSelect = false;
            this.m_wndListeParametres.Name = "m_wndListeParametres";
            this.m_wndListeParametres.Size = new System.Drawing.Size(198, 321);
            this.m_wndListeParametres.TabIndex = 0;
            this.m_wndListeParametres.UseCompatibleStateImageBehavior = false;
            this.m_wndListeParametres.View = System.Windows.Forms.View.Details;
            this.m_wndListeParametres.SelectedIndexChanged += new System.EventHandler(this.m_wndListeParametres_SelectedIndexChanged);
            // 
            // listViewAutoFilledColumn2
            // 
            this.listViewAutoFilledColumn2.Field = "InfoParametre.Nom";
            this.listViewAutoFilledColumn2.PrecisionWidth = 0;
            this.listViewAutoFilledColumn2.ProportionnalSize = false;
            this.listViewAutoFilledColumn2.Text = "Name|82";
            this.listViewAutoFilledColumn2.Visible = true;
            this.listViewAutoFilledColumn2.Width = 176;
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(198, 321);
            this.label13.TabIndex = 4;
            this.label13.Text = "Form Parameters|10008";
            // 
            // m_splitContainerInfosParam
            // 
            this.m_splitContainerInfosParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_splitContainerInfosParam.Location = new System.Drawing.Point(0, 0);
            this.m_splitContainerInfosParam.Name = "m_splitContainerInfosParam";
            this.m_splitContainerInfosParam.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // m_splitContainerInfosParam.Panel1
            // 
            this.m_splitContainerInfosParam.Panel1.Controls.Add(this.m_txtFormuleParametre);
            this.m_splitContainerInfosParam.Panel1.Controls.Add(this.label15);
            this.m_splitContainerInfosParam.Panel1.Controls.Add(this.m_lblNomParametre);
            // 
            // m_splitContainerInfosParam.Panel2
            // 
            this.m_splitContainerInfosParam.Panel2.Controls.Add(this.m_lblDescriptionParametre);
            this.m_splitContainerInfosParam.Size = new System.Drawing.Size(274, 321);
            this.m_splitContainerInfosParam.SplitterDistance = 147;
            this.m_splitContainerInfosParam.TabIndex = 4;
            // 
            // m_lblNomParametre
            // 
            this.m_lblNomParametre.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_lblNomParametre.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblNomParametre.Location = new System.Drawing.Point(0, 0);
            this.m_lblNomParametre.Name = "m_lblNomParametre";
            this.m_lblNomParametre.Size = new System.Drawing.Size(274, 22);
            this.m_lblNomParametre.TabIndex = 3;
            this.m_lblNomParametre.Text = "Parameter Name";
            // 
            // m_txtFormuleParametre
            // 
            this.m_txtFormuleParametre.BackColor = System.Drawing.Color.White;
            this.m_txtFormuleParametre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtFormuleParametre.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtFormuleParametre.Formule = null;
            this.m_txtFormuleParametre.Location = new System.Drawing.Point(0, 40);
            this.m_txtFormuleParametre.LockEdition = false;
            this.m_txtFormuleParametre.Name = "m_txtFormuleParametre";
            this.m_txtFormuleParametre.Size = new System.Drawing.Size(274, 107);
            this.m_txtFormuleParametre.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.Dock = System.Windows.Forms.DockStyle.Top;
            this.label15.Location = new System.Drawing.Point(0, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(274, 18);
            this.label15.TabIndex = 2;
            this.label15.Text = "Parameter Value|10009";
            // 
            // m_lblDescriptionParametre
            // 
            this.m_lblDescriptionParametre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.m_lblDescriptionParametre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblDescriptionParametre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lblDescriptionParametre.Location = new System.Drawing.Point(0, 0);
            this.m_lblDescriptionParametre.Name = "m_lblDescriptionParametre";
            this.m_lblDescriptionParametre.Size = new System.Drawing.Size(274, 170);
            this.m_lblDescriptionParametre.TabIndex = 2;
            this.m_lblDescriptionParametre.Text = "Parameter description";
            // 
            // m_txtContexteFormulaire
            // 
            this.m_txtContexteFormulaire.Location = new System.Drawing.Point(133, 29);
            this.m_txtContexteFormulaire.Name = "m_txtContexteFormulaire";
            this.m_txtContexteFormulaire.Size = new System.Drawing.Size(419, 20);
            this.m_txtContexteFormulaire.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Form context|812";
            // 
            // m_cmbFormulaireStandard
            // 
            this.m_cmbFormulaireStandard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbFormulaireStandard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbFormulaireStandard.IsLink = false;
            this.m_cmbFormulaireStandard.ListDonnees = null;
            this.m_cmbFormulaireStandard.Location = new System.Drawing.Point(133, 5);
            this.m_cmbFormulaireStandard.LockEdition = false;
            this.m_cmbFormulaireStandard.Name = "m_cmbFormulaireStandard";
            this.m_cmbFormulaireStandard.NullAutorise = true;
            this.m_cmbFormulaireStandard.ProprieteAffichee = "Nom";
            this.m_cmbFormulaireStandard.Size = new System.Drawing.Size(419, 21);
            this.m_cmbFormulaireStandard.TabIndex = 3;
            this.m_cmbFormulaireStandard.TextNull = "(none)";
            this.m_cmbFormulaireStandard.Tri = true;
            this.m_cmbFormulaireStandard.SelectionChangeCommitted += new System.EventHandler(this.m_cmbFormulaireStandard_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Form|555";
            // 
            // m_wndAideFormuleParametre
            // 
            this.m_wndAideFormuleParametre.BackColor = System.Drawing.Color.White;
            this.m_wndAideFormuleParametre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndAideFormuleParametre.FournisseurProprietes = null;
            this.m_wndAideFormuleParametre.Location = new System.Drawing.Point(0, 0);
            this.m_wndAideFormuleParametre.Name = "m_wndAideFormuleParametre";
            this.m_wndAideFormuleParametre.ObjetInterroge = null;
            this.m_wndAideFormuleParametre.SendIdChamps = false;
            this.m_wndAideFormuleParametre.Size = new System.Drawing.Size(218, 321);
            this.m_wndAideFormuleParametre.TabIndex = 7;
            this.m_wndAideFormuleParametre.OnSendCommande += new sc2i.win32.expression.SendCommande(this.m_wndAideFormuleParametre_OnSendCommande);
            // 
            // CPanelEditeActionSurLinkFormulaireStandard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_panelFormulaire);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "CPanelEditeActionSurLinkFormulaireStandard";
            this.Size = new System.Drawing.Size(702, 381);
            this.Load += new System.EventHandler(this.CPanelEditeActionSurLinkFormulaireStandard_Load);
            this.m_panelFormulaire.ResumeLayout(false);
            this.m_panelFormulaire.PerformLayout();
            this.m_panelParametresFormulaire.ResumeLayout(false);
            this.m_splitContainer1.Panel1.ResumeLayout(false);
            this.m_splitContainer1.Panel2.ResumeLayout(false);
            this.m_splitContainer1.ResumeLayout(false);
            this.m_splitContainer2.Panel1.ResumeLayout(false);
            this.m_splitContainer2.Panel2.ResumeLayout(false);
            this.m_splitContainer2.ResumeLayout(false);
            this.m_splitContainerInfosParam.Panel1.ResumeLayout(false);
            this.m_splitContainerInfosParam.Panel2.ResumeLayout(false);
            this.m_splitContainerInfosParam.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel m_panelFormulaire;
        private System.Windows.Forms.Panel m_panelParametresFormulaire;
        private System.Windows.Forms.SplitContainer m_splitContainer1;
        private System.Windows.Forms.SplitContainer m_splitContainer2;
        private sc2i.win32.common.ListViewAutoFilled m_wndListeParametres;
        private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.SplitContainer m_splitContainerInfosParam;
        private System.Windows.Forms.Label m_lblNomParametre;
        private sc2i.win32.expression.CControleEditeFormule m_txtFormuleParametre;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label m_lblDescriptionParametre;
        private System.Windows.Forms.TextBox m_txtContexteFormulaire;
        private System.Windows.Forms.Label label5;
        private sc2i.win32.common.CComboboxAutoFilled m_cmbFormulaireStandard;
        private System.Windows.Forms.Label label2;
        private sc2i.win32.expression.CControlAideFormule m_wndAideFormuleParametre;

    }
}
