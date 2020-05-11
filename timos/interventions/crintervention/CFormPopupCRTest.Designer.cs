namespace timos.interventions.crintervention
{
    partial class CFormPopupCRTest
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
            this.m_panelCR = new timos.interventions.crintervention.CEditeurOperations();
            this.SuspendLayout();
            // 
            // m_panelCR
            // 
            this.m_panelCR.CurrentItemIndex = null;
            this.m_panelCR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelCR.Items = new sc2i.win32.common.customizableList.CCustomizableListItem[0];
            this.m_panelCR.Location = new System.Drawing.Point(0, 0);
            this.m_panelCR.LockEdition = false;
            this.m_panelCR.Name = "m_panelCR";
            this.m_panelCR.Size = new System.Drawing.Size(695, 386);
            this.m_panelCR.TabIndex = 0;
            // 
            // CFormPopupCRTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 386);
            this.Controls.Add(this.m_panelCR);
            this.Name = "CFormPopupCRTest";
            this.Text = "CFormPopupCRTest";
            this.Load += new System.EventHandler(this.CFormPopupCRTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CEditeurOperations m_panelCR;
    }
}