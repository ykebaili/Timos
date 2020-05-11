namespace TestSnmp
{
    partial class CFormParametrageSupervision
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_btnSave = new System.Windows.Forms.Button();
            this.m_btnLoad = new System.Windows.Forms.Button();
            this.m_panelSupervision = new futurocom.win32.snmp.alarmes.CControleEditeBaseSupervision();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_btnSave);
            this.panel1.Controls.Add(this.m_btnLoad);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(649, 31);
            this.panel1.TabIndex = 1;
            // 
            // m_btnSave
            // 
            this.m_btnSave.Location = new System.Drawing.Point(102, 3);
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Size = new System.Drawing.Size(75, 23);
            this.m_btnSave.TabIndex = 3;
            this.m_btnSave.Text = "Save";
            this.m_btnSave.UseVisualStyleBackColor = true;
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // m_btnLoad
            // 
            this.m_btnLoad.Location = new System.Drawing.Point(3, 3);
            this.m_btnLoad.Name = "m_btnLoad";
            this.m_btnLoad.Size = new System.Drawing.Size(75, 23);
            this.m_btnLoad.TabIndex = 2;
            this.m_btnLoad.Text = "Load";
            this.m_btnLoad.UseVisualStyleBackColor = true;
            this.m_btnLoad.Click += new System.EventHandler(this.m_btnLoad_Click);
            // 
            // m_panelSupervision
            // 
            this.m_panelSupervision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelSupervision.Location = new System.Drawing.Point(0, 31);
            this.m_panelSupervision.Name = "m_panelSupervision";
            this.m_panelSupervision.Size = new System.Drawing.Size(649, 333);
            this.m_panelSupervision.TabIndex = 0;
            // 
            // CFormParametrageSupervision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 364);
            this.Controls.Add(this.m_panelSupervision);
            this.Controls.Add(this.panel1);
            this.Name = "CFormParametrageSupervision";
            this.Text = "Parametrage de la supervision";
            this.Load += new System.EventHandler(this.CFormParametrageSupervision_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private futurocom.win32.snmp.alarmes.CControleEditeBaseSupervision m_panelSupervision;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button m_btnSave;
        private System.Windows.Forms.Button m_btnLoad;
    }
}