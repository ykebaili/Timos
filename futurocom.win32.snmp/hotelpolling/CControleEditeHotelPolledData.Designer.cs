namespace futurocom.win32.snmp.hotelpolling
{
    partial class CControleEditeHotelPolledData
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
            this.m_txtFormule = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.m_lblFormule = new System.Windows.Forms.Label();
            this.m_txtHotelTable = new sc2i.win32.common.C2iTextBox();
            this.m_txtHotelField = new sc2i.win32.common.C2iTextBox();
            this.m_txtEntityId = new sc2i.win32.common.C2iTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_txtFormule
            // 
            this.m_txtFormule.AllowGraphic = true;
            this.m_txtFormule.AllowNullFormula = true;
            this.m_txtFormule.AllowSaisieTexte = true;
            this.m_txtFormule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtFormule.Formule = null;
            this.m_txtFormule.Location = new System.Drawing.Point(360, 0);
            this.m_txtFormule.LockEdition = false;
            this.m_txtFormule.LockZoneTexte = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtFormule, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtFormule.Name = "m_txtFormule";
            this.m_txtFormule.Size = new System.Drawing.Size(124, 22);
            this.m_txtFormule.TabIndex = 1;
            // 
            // m_lblFormule
            // 
            this.m_lblFormule.BackColor = System.Drawing.Color.White;
            this.m_lblFormule.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblFormule.Location = new System.Drawing.Point(186, 4);
            this.m_extModeEdition.SetModeEdition(this.m_lblFormule, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblFormule.Name = "m_lblFormule";
            this.m_lblFormule.Size = new System.Drawing.Size(100, 23);
            this.m_lblFormule.TabIndex = 2;
            this.m_lblFormule.Text = "label1";
            // 
            // m_txtHotelTable
            // 
            this.m_txtHotelTable.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_txtHotelTable.EmptyText = "";
            this.m_txtHotelTable.Location = new System.Drawing.Point(0, 0);
            this.m_txtHotelTable.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtHotelTable, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtHotelTable.Name = "m_txtHotelTable";
            this.m_txtHotelTable.Size = new System.Drawing.Size(120, 20);
            this.m_txtHotelTable.TabIndex = 3;
            // 
            // m_txtHotelField
            // 
            this.m_txtHotelField.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_txtHotelField.EmptyText = "";
            this.m_txtHotelField.Location = new System.Drawing.Point(120, 0);
            this.m_txtHotelField.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtHotelField, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtHotelField.Name = "m_txtHotelField";
            this.m_txtHotelField.Size = new System.Drawing.Size(120, 20);
            this.m_txtHotelField.TabIndex = 4;
            // 
            // m_txtEntityId
            // 
            this.m_txtEntityId.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_txtEntityId.EmptyText = "";
            this.m_txtEntityId.Location = new System.Drawing.Point(240, 0);
            this.m_txtEntityId.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtEntityId, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtEntityId.Name = "m_txtEntityId";
            this.m_txtEntityId.Size = new System.Drawing.Size(120, 20);
            this.m_txtEntityId.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(0, 22);
            this.m_extModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(484, 1);
            this.label1.TabIndex = 6;
            // 
            // CControleEditeHotelPolledData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_lblFormule);
            this.Controls.Add(this.m_txtFormule);
            this.Controls.Add(this.m_txtEntityId);
            this.Controls.Add(this.m_txtHotelField);
            this.Controls.Add(this.m_txtHotelTable);
            this.Controls.Add(this.label1);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleEditeHotelPolledData";
            this.Size = new System.Drawing.Size(484, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormule;
        private System.Windows.Forms.Label m_lblFormule;
        private sc2i.win32.common.C2iTextBox m_txtHotelTable;
        private sc2i.win32.common.C2iTextBox m_txtHotelField;
        private sc2i.win32.common.C2iTextBox m_txtEntityId;
        private System.Windows.Forms.Label label1;
    }
}
