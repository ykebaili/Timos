namespace spv.win32
{
    partial class CExtendeurFormTypeSchemaReseau
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
            this.m_chkSuperviser = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // m_chkSuperviser
            // 
            this.m_chkSuperviser.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkSuperviser, "");
            this.m_chkSuperviser.Location = new System.Drawing.Point(3, 3);
            this.m_extModeEdition.SetModeEdition(this.m_chkSuperviser, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkSuperviser.Name = "m_chkSuperviser";
            this.m_chkSuperviser.Size = new System.Drawing.Size(183, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkSuperviser, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkSuperviser, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkSuperviser.TabIndex = 0;
            this.m_chkSuperviser.Text = "Supervise as a service|20003";
            this.m_chkSuperviser.UseVisualStyleBackColor = true;
            this.m_chkSuperviser.CheckedChanged += new System.EventHandler(this.m_chkSuperviser_CheckedChanged);
            // 
            // CExtendeurFormTypeSchemaReseau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.m_chkSuperviser);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CExtendeurFormTypeSchemaReseau";
            this.Size = new System.Drawing.Size(446, 283);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox m_chkSuperviser;


    }
}
