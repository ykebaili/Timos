namespace timos.macro
{
    partial class CFormEditionMacro
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
            this.m_panelMacro = new timos.macro.CControleEditeMacro();
            this.SuspendLayout();
            // 
            // m_panelMacro
            // 
            this.m_panelMacro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelMacro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelMacro.ForeColor = System.Drawing.Color.Black;
            this.m_panelMacro.Location = new System.Drawing.Point(0, 0);
            this.m_panelMacro.LockEdition = false;
            this.m_panelMacro.Name = "m_panelMacro";
            this.m_panelMacro.Size = new System.Drawing.Size(672, 378);
            this.m_panelMacro.TabIndex = 0;
            this.m_panelMacro.Load += new System.EventHandler(this.m_panelMacro_Load);
            // 
            // CFormEditionMacro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 378);
            this.Controls.Add(this.m_panelMacro);
            this.Name = "CFormEditionMacro";
            this.Text = "CFormEditionMacro";
            this.ResumeLayout(false);

        }

        #endregion

        private CControleEditeMacro m_panelMacro;
    }
}