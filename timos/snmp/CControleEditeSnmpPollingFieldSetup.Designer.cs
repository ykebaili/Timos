namespace timos.snmp
{
    partial class CControleEditeSnmpPollingFieldSetup
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
            this.m_selectField = new sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtFormulePoll = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.m_lblFormulePoll = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_lblFormuleEntite = new System.Windows.Forms.Label();
            this.m_txtFormuleEntite = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_selectField
            // 
            this.m_selectField.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_selectField.ElementSelectionne = null;
            this.m_selectField.FonctionTextNull = null;
            this.m_selectField.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_selectField.Location = new System.Drawing.Point(0, 0);
            this.m_selectField.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_selectField, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_selectField.Name = "m_selectField";
            this.m_selectField.SelectedObject = null;
            this.m_selectField.SelectionLength = 0;
            this.m_selectField.SelectionStart = 0;
            this.m_selectField.Size = new System.Drawing.Size(181, 50);
            this.m_selectField.SpecificImage = null;
            this.m_selectField.TabIndex = 0;
            this.m_selectField.TextNull = "";
            this.m_selectField.UseIntellisense = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(0, 50);
            this.m_extModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(512, 1);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // m_txtFormulePoll
            // 
            this.m_txtFormulePoll.AllowGraphic = true;
            this.m_txtFormulePoll.AllowNullFormula = false;
            this.m_txtFormulePoll.AllowSaisieTexte = true;
            this.m_txtFormulePoll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtFormulePoll.Formule = null;
            this.m_txtFormulePoll.Location = new System.Drawing.Point(112, 0);
            this.m_txtFormulePoll.LockEdition = false;
            this.m_txtFormulePoll.LockZoneTexte = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtFormulePoll, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtFormulePoll.Name = "m_txtFormulePoll";
            this.m_txtFormulePoll.Size = new System.Drawing.Size(219, 24);
            this.m_txtFormulePoll.TabIndex = 2;
            // 
            // m_lblFormulePoll
            // 
            this.m_lblFormulePoll.BackColor = System.Drawing.Color.White;
            this.m_lblFormulePoll.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblFormulePoll.Location = new System.Drawing.Point(137, 11);
            this.m_extModeEdition.SetModeEdition(this.m_lblFormulePoll, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblFormulePoll.Name = "m_lblFormulePoll";
            this.m_lblFormulePoll.Size = new System.Drawing.Size(35, 13);
            this.m_lblFormulePoll.TabIndex = 3;
            this.m_lblFormulePoll.Text = "Formule";
            this.m_lblFormulePoll.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(181, 0);
            this.m_extModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(331, 50);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_lblFormulePoll);
            this.panel2.Controls.Add(this.m_txtFormulePoll);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.m_extModeEdition.SetModeEdition(this.panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(331, 24);
            this.panel2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Polling formula|20898";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.m_lblFormuleEntite);
            this.panel3.Controls.Add(this.m_txtFormuleEntite);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.panel3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(331, 24);
            this.panel3.TabIndex = 1;
            // 
            // m_lblFormuleEntite
            // 
            this.m_lblFormuleEntite.BackColor = System.Drawing.Color.White;
            this.m_lblFormuleEntite.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblFormuleEntite.Location = new System.Drawing.Point(137, 11);
            this.m_extModeEdition.SetModeEdition(this.m_lblFormuleEntite, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblFormuleEntite.Name = "m_lblFormuleEntite";
            this.m_lblFormuleEntite.Size = new System.Drawing.Size(35, 13);
            this.m_lblFormuleEntite.TabIndex = 3;
            this.m_lblFormuleEntite.Text = "Formule";
            this.m_lblFormuleEntite.Visible = false;
            // 
            // m_txtFormuleEntite
            // 
            this.m_txtFormuleEntite.AllowGraphic = true;
            this.m_txtFormuleEntite.AllowNullFormula = false;
            this.m_txtFormuleEntite.AllowSaisieTexte = true;
            this.m_txtFormuleEntite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtFormuleEntite.Formule = null;
            this.m_txtFormuleEntite.Location = new System.Drawing.Point(112, 0);
            this.m_txtFormuleEntite.LockEdition = false;
            this.m_txtFormuleEntite.LockZoneTexte = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtFormuleEntite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtFormuleEntite.Name = "m_txtFormuleEntite";
            this.m_txtFormuleEntite.Size = new System.Drawing.Size(219, 24);
            this.m_txtFormuleEntite.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "Entity Id|20899";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CControleEditeSnmpPollingFieldSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_selectField);
            this.Controls.Add(this.label1);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleEditeSnmpPollingFieldSetup";
            this.Size = new System.Drawing.Size(512, 51);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide m_selectField;
        private System.Windows.Forms.Label label1;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormulePoll;
        private System.Windows.Forms.Label m_lblFormulePoll;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label m_lblFormuleEntite;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleEntite;
        private System.Windows.Forms.Label label4;
    }
}
