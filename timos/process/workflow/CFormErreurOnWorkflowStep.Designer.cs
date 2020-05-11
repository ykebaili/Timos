namespace timos.process.workflow
{
    partial class CFormErreurOnWorkflowStep
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
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.m_lblMessage = new System.Windows.Forms.Label();
            this.m_btnDoNothing = new System.Windows.Forms.Button();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_btnTerminer = new System.Windows.Forms.Button();
            this.m_btnError = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::timos.Properties.Resources.warning;
            this.pictureBox1.Location = new System.Drawing.Point(5, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 36);
            this.m_extStyle.SetStyleBackColor(this.pictureBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pictureBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // m_lblMessage
            // 
            this.m_lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblMessage.Location = new System.Drawing.Point(43, 4);
            this.m_lblMessage.Name = "m_lblMessage";
            this.m_lblMessage.Size = new System.Drawing.Size(337, 127);
            this.m_extStyle.SetStyleBackColor(this.m_lblMessage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblMessage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblMessage.TabIndex = 1;
            this.m_lblMessage.Text = "An error occured";
            this.m_lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_btnDoNothing
            // 
            this.m_btnDoNothing.BackColor = System.Drawing.SystemColors.Control;
            this.m_btnDoNothing.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.m_btnDoNothing.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.m_btnDoNothing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnDoNothing.Location = new System.Drawing.Point(1, 134);
            this.m_btnDoNothing.Name = "m_btnDoNothing";
            this.m_btnDoNothing.Size = new System.Drawing.Size(94, 43);
            this.m_extStyle.SetStyleBackColor(this.m_btnDoNothing, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnDoNothing, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnDoNothing.TabIndex = 2;
            this.m_btnDoNothing.Text = "Do nothing|20762";
            this.m_btnDoNothing.UseVisualStyleBackColor = false;
            this.m_btnDoNothing.Click += new System.EventHandler(this.m_btnDoNothing_Click);
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.m_btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.m_btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.m_btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnCancel.Location = new System.Drawing.Point(96, 134);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(94, 43);
            this.m_extStyle.SetStyleBackColor(this.m_btnCancel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnCancel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnCancel.TabIndex = 3;
            this.m_btnCancel.Text = "Cancel execution|20763";
            this.m_btnCancel.UseVisualStyleBackColor = false;
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // m_btnTerminer
            // 
            this.m_btnTerminer.BackColor = System.Drawing.SystemColors.Control;
            this.m_btnTerminer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.m_btnTerminer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.m_btnTerminer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnTerminer.Location = new System.Drawing.Point(191, 134);
            this.m_btnTerminer.Name = "m_btnTerminer";
            this.m_btnTerminer.Size = new System.Drawing.Size(94, 43);
            this.m_extStyle.SetStyleBackColor(this.m_btnTerminer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnTerminer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnTerminer.TabIndex = 4;
            this.m_btnTerminer.Text = "End execution|20764";
            this.m_btnTerminer.UseVisualStyleBackColor = false;
            this.m_btnTerminer.Click += new System.EventHandler(this.m_btnTerminer_Click);
            // 
            // m_btnError
            // 
            this.m_btnError.BackColor = System.Drawing.SystemColors.Control;
            this.m_btnError.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.m_btnError.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.m_btnError.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnError.Location = new System.Drawing.Point(286, 134);
            this.m_btnError.Name = "m_btnError";
            this.m_btnError.Size = new System.Drawing.Size(94, 43);
            this.m_extStyle.SetStyleBackColor(this.m_btnError, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnError, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnError.TabIndex = 5;
            this.m_btnError.Text = "End with error|20764";
            this.m_btnError.UseVisualStyleBackColor = false;
            this.m_btnError.Click += new System.EventHandler(this.m_btnError_Click);
            // 
            // CFormErreurOnWorkflowStep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 178);
            this.ControlBox = false;
            this.Controls.Add(this.m_btnError);
            this.Controls.Add(this.m_btnTerminer);
            this.Controls.Add(this.m_btnCancel);
            this.Controls.Add(this.m_btnDoNothing);
            this.Controls.Add(this.m_lblMessage);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CFormErreurOnWorkflowStep";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondFenetre);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTexteFenetre);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.CExtStyle m_extStyle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label m_lblMessage;
        private System.Windows.Forms.Button m_btnDoNothing;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.Button m_btnTerminer;
        private System.Windows.Forms.Button m_btnError;
    }
}