namespace spv.win32
{
    partial class CExtendeurFormChampCustom
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
            this.m_panelSNMP = new sc2i.win32.common.C2iPanel(this.components);
            this.m_lblVariable = new System.Windows.Forms.Label();
            this.m_btnSelectOID = new System.Windows.Forms.Button();
            this.m_txtFormuleIndex = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.m_txtOID = new sc2i.win32.common.C2iTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_panelTopologie = new sc2i.win32.common.C2iPanel(this.components);
            this.m_tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.m_chkGetOnly = new System.Windows.Forms.CheckBox();
            this.m_panelSNMP.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelSNMP
            // 
            this.m_panelSNMP.Controls.Add(this.m_chkGetOnly);
            this.m_panelSNMP.Controls.Add(this.m_lblVariable);
            this.m_panelSNMP.Controls.Add(this.m_btnSelectOID);
            this.m_panelSNMP.Controls.Add(this.m_txtFormuleIndex);
            this.m_panelSNMP.Controls.Add(this.m_txtOID);
            this.m_panelSNMP.Controls.Add(this.label2);
            this.m_panelSNMP.Controls.Add(this.label1);
            this.m_panelSNMP.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.m_panelSNMP, "");
            this.m_panelSNMP.Location = new System.Drawing.Point(0, 0);
            this.m_panelSNMP.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_panelSNMP, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelSNMP.Name = "m_panelSNMP";
            this.m_panelSNMP.Size = new System.Drawing.Size(446, 120);
            this.m_extStyle.SetStyleBackColor(this.m_panelSNMP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelSNMP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelSNMP.TabIndex = 0;
            // 
            // m_lblVariable
            // 
            this.m_lblVariable.BackColor = System.Drawing.Color.White;
            this.m_lblVariable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_extLinkField.SetLinkField(this.m_lblVariable, "");
            this.m_lblVariable.Location = new System.Drawing.Point(90, 27);
            this.m_extModeEdition.SetModeEdition(this.m_lblVariable, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblVariable.Name = "m_lblVariable";
            this.m_lblVariable.Size = new System.Drawing.Size(306, 19);
            this.m_extStyle.SetStyleBackColor(this.m_lblVariable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblVariable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblVariable.TabIndex = 5;
            // 
            // m_btnSelectOID
            // 
            this.m_extLinkField.SetLinkField(this.m_btnSelectOID, "");
            this.m_btnSelectOID.Location = new System.Drawing.Point(369, 7);
            this.m_extModeEdition.SetModeEdition(this.m_btnSelectOID, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnSelectOID.Name = "m_btnSelectOID";
            this.m_btnSelectOID.Size = new System.Drawing.Size(26, 20);
            this.m_extStyle.SetStyleBackColor(this.m_btnSelectOID, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSelectOID, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnSelectOID.TabIndex = 4;
            this.m_btnSelectOID.Text = "...";
            this.m_btnSelectOID.UseVisualStyleBackColor = true;
            this.m_btnSelectOID.Click += new System.EventHandler(this.m_btnSelectOID_Click);
            // 
            // m_txtFormuleIndex
            // 
            this.m_txtFormuleIndex.Formule = null;
            this.m_extLinkField.SetLinkField(this.m_txtFormuleIndex, "");
            this.m_txtFormuleIndex.Location = new System.Drawing.Point(90, 49);
            this.m_txtFormuleIndex.LockEdition = false;
            this.m_txtFormuleIndex.LockZoneTexte = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtFormuleIndex, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtFormuleIndex.Name = "m_txtFormuleIndex";
            this.m_txtFormuleIndex.Size = new System.Drawing.Size(306, 19);
            this.m_extStyle.SetStyleBackColor(this.m_txtFormuleIndex, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFormuleIndex, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleIndex.TabIndex = 3;
            // 
            // m_txtOID
            // 
            this.m_extLinkField.SetLinkField(this.m_txtOID, "OID");
            this.m_txtOID.Location = new System.Drawing.Point(90, 7);
            this.m_txtOID.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtOID, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtOID.Name = "m_txtOID";
            this.m_txtOID.Size = new System.Drawing.Size(283, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtOID, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtOID, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtOID.TabIndex = 2;
            this.m_txtOID.Text = "[OID]";
            this.m_txtOID.TextChanged += new System.EventHandler(this.m_txtOID_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(6, 54);
            this.m_extModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 1;
            this.label2.Text = "Index|20007";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.m_extModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 0;
            this.label1.Text = "OID|20006";
            // 
            // m_panelTopologie
            // 
            this.m_panelTopologie.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.m_panelTopologie, "");
            this.m_panelTopologie.Location = new System.Drawing.Point(0, 120);
            this.m_panelTopologie.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_panelTopologie, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelTopologie.Name = "m_panelTopologie";
            this.m_panelTopologie.Size = new System.Drawing.Size(446, 100);
            this.m_extStyle.SetStyleBackColor(this.m_panelTopologie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelTopologie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelTopologie.TabIndex = 1;
            // 
            // m_chkGetOnly
            // 
            this.m_chkGetOnly.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkGetOnly, "GetOnly");
            this.m_chkGetOnly.Location = new System.Drawing.Point(90, 74);
            this.m_extModeEdition.SetModeEdition(this.m_chkGetOnly, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkGetOnly.Name = "m_chkGetOnly";
            this.m_chkGetOnly.Size = new System.Drawing.Size(97, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkGetOnly, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkGetOnly, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkGetOnly.TabIndex = 6;
            this.m_chkGetOnly.Text = "Get only|20013";
            this.m_chkGetOnly.UseVisualStyleBackColor = true;
            // 
            // CExtendeurFormChampCustom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.m_panelTopologie);
            this.Controls.Add(this.m_panelSNMP);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CExtendeurFormChampCustom";
            this.Size = new System.Drawing.Size(446, 283);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.OnChangementSurObjet += new sc2i.win32.data.navigation.EventOnChangementDonnee(this.CExtendeurFormChampCustom_OnChangementSurObjet);
            this.m_panelSNMP.ResumeLayout(false);
            this.m_panelSNMP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.C2iPanel m_panelSNMP;
        private sc2i.win32.common.C2iPanel m_panelTopologie;
        private System.Windows.Forms.Label label1;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleIndex;
        private sc2i.win32.common.C2iTextBox m_txtOID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button m_btnSelectOID;
        private System.Windows.Forms.Label m_lblVariable;
        private System.Windows.Forms.ToolTip m_tooltip;
        private System.Windows.Forms.CheckBox m_chkGetOnly;



    }
}
