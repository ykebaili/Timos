namespace TestServicWebWSDL
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtURL = new System.Windows.Forms.TextBox();
            this.m_txtUser = new System.Windows.Forms.TextBox();
            this.m_txtMdp = new System.Windows.Forms.TextBox();
            this.m_btnConnexion = new System.Windows.Forms.Button();
            this.m_txtReponse = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_btnChangeKeys = new System.Windows.Forms.Button();
            this.m_btnChange = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL service SM9";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Utilisateur";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mot de passe";
            // 
            // m_txtURL
            // 
            this.m_txtURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtURL.Location = new System.Drawing.Point(132, 20);
            this.m_txtURL.Name = "m_txtURL";
            this.m_txtURL.Size = new System.Drawing.Size(588, 20);
            this.m_txtURL.TabIndex = 1;
            this.m_txtURL.Text = "https://sslc.tunisiana.com/SM/7/ws";
            // 
            // m_txtUser
            // 
            this.m_txtUser.Location = new System.Drawing.Point(132, 52);
            this.m_txtUser.Name = "m_txtUser";
            this.m_txtUser.Size = new System.Drawing.Size(136, 20);
            this.m_txtUser.TabIndex = 1;
            this.m_txtUser.Text = "timos";
            // 
            // m_txtMdp
            // 
            this.m_txtMdp.Location = new System.Drawing.Point(132, 82);
            this.m_txtMdp.Name = "m_txtMdp";
            this.m_txtMdp.Size = new System.Drawing.Size(136, 20);
            this.m_txtMdp.TabIndex = 1;
            this.m_txtMdp.Text = "timos";
            // 
            // m_btnConnexion
            // 
            this.m_btnConnexion.Location = new System.Drawing.Point(326, 51);
            this.m_btnConnexion.Name = "m_btnConnexion";
            this.m_btnConnexion.Size = new System.Drawing.Size(238, 23);
            this.m_btnConnexion.TabIndex = 2;
            this.m_btnConnexion.Text = "Change List";
            this.m_btnConnexion.UseVisualStyleBackColor = true;
            this.m_btnConnexion.Click += new System.EventHandler(this.m_btnConnexion_Click);
            // 
            // m_txtReponse
            // 
            this.m_txtReponse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtReponse.Location = new System.Drawing.Point(24, 178);
            this.m_txtReponse.Multiline = true;
            this.m_txtReponse.Name = "m_txtReponse";
            this.m_txtReponse.Size = new System.Drawing.Size(696, 262);
            this.m_txtReponse.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Réponses XML";
            // 
            // m_btnChangeKeys
            // 
            this.m_btnChangeKeys.Location = new System.Drawing.Point(326, 81);
            this.m_btnChangeKeys.Name = "m_btnChangeKeys";
            this.m_btnChangeKeys.Size = new System.Drawing.Size(238, 23);
            this.m_btnChangeKeys.TabIndex = 2;
            this.m_btnChangeKeys.Text = "Change Keys";
            this.m_btnChangeKeys.UseVisualStyleBackColor = true;
            this.m_btnChangeKeys.Click += new System.EventHandler(this.m_btnChangeKeys_Click);
            // 
            // m_btnChange
            // 
            this.m_btnChange.Location = new System.Drawing.Point(326, 110);
            this.m_btnChange.Name = "m_btnChange";
            this.m_btnChange.Size = new System.Drawing.Size(238, 23);
            this.m_btnChange.TabIndex = 2;
            this.m_btnChange.Text = "Get Change";
            this.m_btnChange.UseVisualStyleBackColor = true;
            this.m_btnChange.Click += new System.EventHandler(this.m_btnChange_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 452);
            this.Controls.Add(this.m_txtReponse);
            this.Controls.Add(this.m_btnChange);
            this.Controls.Add(this.m_btnChangeKeys);
            this.Controls.Add(this.m_btnConnexion);
            this.Controls.Add(this.m_txtMdp);
            this.Controls.Add(this.m_txtUser);
            this.Controls.Add(this.m_txtURL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Test Web Service SM9";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox m_txtURL;
        private System.Windows.Forms.TextBox m_txtUser;
        private System.Windows.Forms.TextBox m_txtMdp;
        private System.Windows.Forms.Button m_btnConnexion;
        private System.Windows.Forms.TextBox m_txtReponse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button m_btnChangeKeys;
        private System.Windows.Forms.Button m_btnChange;
    }
}

