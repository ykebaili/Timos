namespace TimosWebApp
{
    partial class CFormTimosWebApp
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_panelFooter = new System.Windows.Forms.Panel();
            this.m_txtOutput = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.m_panelBody = new System.Windows.Forms.Panel();
            this.m_cmbSelectAction = new sc2i.win32.common.CComboboxAutoFilled();
            this.m_btnReachURL = new System.Windows.Forms.Button();
            this.m_txtURL = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_splitterFooter = new System.Windows.Forms.Splitter();
            this.m_panelVariables = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.m_btnStartAction = new System.Windows.Forms.Button();
            this.m_btnClearOutput = new System.Windows.Forms.Button();
            this.m_btnOpenConfig = new System.Windows.Forms.Button();
            this.m_btnSaveConfig = new System.Windows.Forms.Button();
            this.m_panelHeader = new System.Windows.Forms.Panel();
            this.m_panelFooter.SuspendLayout();
            this.panel1.SuspendLayout();
            this.m_panelBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelFooter
            // 
            this.m_panelFooter.Controls.Add(this.m_txtOutput);
            this.m_panelFooter.Controls.Add(this.panel1);
            this.m_panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_panelFooter.Location = new System.Drawing.Point(0, 456);
            this.m_panelFooter.Name = "m_panelFooter";
            this.m_panelFooter.Size = new System.Drawing.Size(643, 94);
            this.m_panelFooter.TabIndex = 1;
            // 
            // m_txtOutput
            // 
            this.m_txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtOutput.Location = new System.Drawing.Point(0, 20);
            this.m_txtOutput.Multiline = true;
            this.m_txtOutput.Name = "m_txtOutput";
            this.m_txtOutput.ReadOnly = true;
            this.m_txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.m_txtOutput.Size = new System.Drawing.Size(643, 74);
            this.m_txtOutput.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.m_btnClearOutput);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(643, 20);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Output";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_panelBody
            // 
            this.m_panelBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.m_panelBody.Controls.Add(this.m_btnOpenConfig);
            this.m_panelBody.Controls.Add(this.m_btnSaveConfig);
            this.m_panelBody.Controls.Add(this.m_panelVariables);
            this.m_panelBody.Controls.Add(this.m_cmbSelectAction);
            this.m_panelBody.Controls.Add(this.m_btnStartAction);
            this.m_panelBody.Controls.Add(this.m_btnReachURL);
            this.m_panelBody.Controls.Add(this.m_txtURL);
            this.m_panelBody.Controls.Add(this.label4);
            this.m_panelBody.Controls.Add(this.label3);
            this.m_panelBody.Controls.Add(this.label1);
            this.m_panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelBody.Location = new System.Drawing.Point(0, 64);
            this.m_panelBody.Name = "m_panelBody";
            this.m_panelBody.Size = new System.Drawing.Size(643, 387);
            this.m_panelBody.TabIndex = 2;
            // 
            // m_cmbSelectAction
            // 
            this.m_cmbSelectAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbSelectAction.FormattingEnabled = true;
            this.m_cmbSelectAction.IsLink = false;
            this.m_cmbSelectAction.ListDonnees = null;
            this.m_cmbSelectAction.Location = new System.Drawing.Point(164, 78);
            this.m_cmbSelectAction.LockEdition = false;
            this.m_cmbSelectAction.Name = "m_cmbSelectAction";
            this.m_cmbSelectAction.NullAutorise = false;
            this.m_cmbSelectAction.ProprieteAffichee = null;
            this.m_cmbSelectAction.Size = new System.Drawing.Size(384, 21);
            this.m_cmbSelectAction.TabIndex = 3;
            this.m_cmbSelectAction.Text = "(empty)";
            this.m_cmbSelectAction.TextNull = "(empty)";
            this.m_cmbSelectAction.Tri = true;
            this.m_cmbSelectAction.SelectionChangeCommitted += new System.EventHandler(this.m_cmbSelectAction_SelectionChangeCommitted);
            // 
            // m_btnReachURL
            // 
            this.m_btnReachURL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnReachURL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.m_btnReachURL.FlatAppearance.BorderSize = 0;
            this.m_btnReachURL.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_btnReachURL.Location = new System.Drawing.Point(555, 48);
            this.m_btnReachURL.Name = "m_btnReachURL";
            this.m_btnReachURL.Size = new System.Drawing.Size(75, 23);
            this.m_btnReachURL.TabIndex = 2;
            this.m_btnReachURL.Text = "Go to WS";
            this.m_btnReachURL.UseVisualStyleBackColor = false;
            this.m_btnReachURL.Click += new System.EventHandler(this.m_btnReachURL_Click);
            // 
            // m_txtURL
            // 
            this.m_txtURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtURL.Location = new System.Drawing.Point(164, 49);
            this.m_txtURL.Name = "m_txtURL";
            this.m_txtURL.Size = new System.Drawing.Size(384, 20);
            this.m_txtURL.TabIndex = 1;
            this.m_txtURL.Text = "http://localhost/TimosWeb/TimosActionService.asmx";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(30, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Select Action";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(30, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Timos Web Service URL";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_splitterFooter
            // 
            this.m_splitterFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_splitterFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_splitterFooter.Location = new System.Drawing.Point(0, 451);
            this.m_splitterFooter.Name = "m_splitterFooter";
            this.m_splitterFooter.Size = new System.Drawing.Size(643, 5);
            this.m_splitterFooter.TabIndex = 1;
            this.m_splitterFooter.TabStop = false;
            // 
            // m_panelVariables
            // 
            this.m_panelVariables.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_panelVariables.AutoScroll = true;
            this.m_panelVariables.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panelVariables.Location = new System.Drawing.Point(164, 118);
            this.m_panelVariables.Name = "m_panelVariables";
            this.m_panelVariables.Size = new System.Drawing.Size(384, 220);
            this.m_panelVariables.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(30, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "List of Variables";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_btnStartAction
            // 
            this.m_btnStartAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnStartAction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.m_btnStartAction.FlatAppearance.BorderSize = 0;
            this.m_btnStartAction.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_btnStartAction.Location = new System.Drawing.Point(342, 358);
            this.m_btnStartAction.Name = "m_btnStartAction";
            this.m_btnStartAction.Size = new System.Drawing.Size(206, 23);
            this.m_btnStartAction.TabIndex = 2;
            this.m_btnStartAction.Text = "Start Action";
            this.m_btnStartAction.UseVisualStyleBackColor = false;
            this.m_btnStartAction.Click += new System.EventHandler(this.m_btnStartAction_Click);
            // 
            // m_btnClearOutput
            // 
            this.m_btnClearOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.m_btnClearOutput.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnClearOutput.FlatAppearance.BorderSize = 0;
            this.m_btnClearOutput.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_btnClearOutput.Location = new System.Drawing.Point(579, 0);
            this.m_btnClearOutput.Name = "m_btnClearOutput";
            this.m_btnClearOutput.Size = new System.Drawing.Size(64, 20);
            this.m_btnClearOutput.TabIndex = 3;
            this.m_btnClearOutput.Text = "Clear";
            this.m_btnClearOutput.UseVisualStyleBackColor = false;
            this.m_btnClearOutput.Click += new System.EventHandler(this.m_btnClearOutput_Click);
            // 
            // m_btnOpenConfig
            // 
            this.m_btnOpenConfig.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.m_btnOpenConfig.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.m_btnOpenConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnOpenConfig.Image = global::TimosWebApp.Properties.Resources.folder_open;
            this.m_btnOpenConfig.Location = new System.Drawing.Point(8, 6);
            this.m_btnOpenConfig.Name = "m_btnOpenConfig";
            this.m_btnOpenConfig.Size = new System.Drawing.Size(32, 32);
            this.m_btnOpenConfig.TabIndex = 5;
            this.m_btnOpenConfig.UseVisualStyleBackColor = true;
            this.m_btnOpenConfig.Click += new System.EventHandler(this.m_btnOpenConfig_Click);
            // 
            // m_btnSaveConfig
            // 
            this.m_btnSaveConfig.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.m_btnSaveConfig.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.m_btnSaveConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnSaveConfig.Image = global::TimosWebApp.Properties.Resources.save_24x24;
            this.m_btnSaveConfig.Location = new System.Drawing.Point(47, 6);
            this.m_btnSaveConfig.Name = "m_btnSaveConfig";
            this.m_btnSaveConfig.Size = new System.Drawing.Size(32, 32);
            this.m_btnSaveConfig.TabIndex = 5;
            this.m_btnSaveConfig.UseVisualStyleBackColor = true;
            this.m_btnSaveConfig.Click += new System.EventHandler(this.m_btnSaveConfig_Click);
            // 
            // m_panelHeader
            // 
            this.m_panelHeader.BackColor = System.Drawing.Color.White;
            this.m_panelHeader.BackgroundImage = global::TimosWebApp.Properties.Resources.TimosWebApp;
            this.m_panelHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.m_panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelHeader.Location = new System.Drawing.Point(0, 0);
            this.m_panelHeader.Name = "m_panelHeader";
            this.m_panelHeader.Size = new System.Drawing.Size(643, 64);
            this.m_panelHeader.TabIndex = 0;
            // 
            // CFormTimosWebApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(643, 550);
            this.Controls.Add(this.m_panelBody);
            this.Controls.Add(this.m_splitterFooter);
            this.Controls.Add(this.m_panelFooter);
            this.Controls.Add(this.m_panelHeader);
            this.Name = "CFormTimosWebApp";
            this.Text = "Timos Web Process Application";
            this.m_panelFooter.ResumeLayout(false);
            this.m_panelFooter.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.m_panelBody.ResumeLayout(false);
            this.m_panelBody.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel m_panelHeader;
        private System.Windows.Forms.Panel m_panelFooter;
        private System.Windows.Forms.Panel m_panelBody;
        private System.Windows.Forms.TextBox m_txtURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button m_btnReachURL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Splitter m_splitterFooter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox m_txtOutput;
        private sc2i.win32.common.CComboboxAutoFilled m_cmbSelectAction;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel m_panelVariables;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button m_btnStartAction;
        private System.Windows.Forms.Button m_btnClearOutput;
        private System.Windows.Forms.Button m_btnSaveConfig;
        private System.Windows.Forms.Button m_btnOpenConfig;
    }
}

