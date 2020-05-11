namespace ImportDocsMyanmar
{
    partial class CFormSearchFiles
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
            m_instance = null;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtDirPattern = new System.Windows.Forms.TextBox();
            this.m_txtFilePattern = new System.Windows.Forms.TextBox();
            this.m_btnFindNext = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "File pattern";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Directory pattern";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtDirPattern
            // 
            this.m_txtDirPattern.Location = new System.Drawing.Point(132, 13);
            this.m_txtDirPattern.Name = "m_txtDirPattern";
            this.m_txtDirPattern.Size = new System.Drawing.Size(180, 20);
            this.m_txtDirPattern.TabIndex = 1;
            // 
            // m_txtFilePattern
            // 
            this.m_txtFilePattern.Location = new System.Drawing.Point(132, 46);
            this.m_txtFilePattern.Name = "m_txtFilePattern";
            this.m_txtFilePattern.Size = new System.Drawing.Size(180, 20);
            this.m_txtFilePattern.TabIndex = 2;
            // 
            // m_btnFindNext
            // 
            this.m_btnFindNext.Location = new System.Drawing.Point(170, 72);
            this.m_btnFindNext.Name = "m_btnFindNext";
            this.m_btnFindNext.Size = new System.Drawing.Size(142, 23);
            this.m_btnFindNext.TabIndex = 3;
            this.m_btnFindNext.Text = "Find next occurence";
            this.m_btnFindNext.UseVisualStyleBackColor = true;
            this.m_btnFindNext.Click += new System.EventHandler(this.m_btnFindNext_Click);
            // 
            // CFormSearchFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 106);
            this.Controls.Add(this.m_btnFindNext);
            this.Controls.Add(this.m_txtFilePattern);
            this.Controls.Add(this.m_txtDirPattern);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CFormSearchFiles";
            this.Text = "Search files";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox m_txtDirPattern;
        private System.Windows.Forms.TextBox m_txtFilePattern;
        private System.Windows.Forms.Button m_btnFindNext;
    }
}