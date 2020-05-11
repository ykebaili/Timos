namespace TimosInventory
{
    partial class CFormWaiting
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
            this.m_lblMessage = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.m_bkWork = new System.ComponentModel.BackgroundWorker();
            this.m_lblTime = new System.Windows.Forms.Label();
            this.m_timerSecs = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.m_lblMessage);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.m_lblTime);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(281, 46);
            this.panel1.TabIndex = 1;
            // 
            // m_lblMessage
            // 
            this.m_lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblMessage.Location = new System.Drawing.Point(43, 0);
            this.m_lblMessage.Name = "m_lblMessage";
            this.m_lblMessage.Size = new System.Drawing.Size(203, 42);
            this.m_lblMessage.TabIndex = 1;
            this.m_lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::TimosInventory.Properties.Resources.loading_spinner;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // m_bkWork
            // 
            this.m_bkWork.WorkerReportsProgress = true;
            this.m_bkWork.DoWork += new System.ComponentModel.DoWorkEventHandler(this.m_bkWork_DoWork);
            this.m_bkWork.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.m_bkWork_RunWorkerCompleted);
            this.m_bkWork.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.m_bkWork_ProgressChanged);
            // 
            // m_lblTime
            // 
            this.m_lblTime.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_lblTime.Location = new System.Drawing.Point(246, 0);
            this.m_lblTime.Name = "m_lblTime";
            this.m_lblTime.Size = new System.Drawing.Size(31, 42);
            this.m_lblTime.TabIndex = 2;
            this.m_lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_timerSecs
            // 
            this.m_timerSecs.Enabled = true;
            this.m_timerSecs.Interval = 1000;
            this.m_timerSecs.Tick += new System.EventHandler(this.m_timerSecs_Tick);
            // 
            // CFormWaiting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 46);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CFormWaiting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CFormWaiting";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.CFormWaiting_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label m_lblMessage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker m_bkWork;
        private System.Windows.Forms.Label m_lblTime;
        private System.Windows.Forms.Timer m_timerSecs;
    }
}