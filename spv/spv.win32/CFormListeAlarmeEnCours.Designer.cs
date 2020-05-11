namespace spv.win32
{
    partial class CFormListeAlarmeEnCours
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private int c_nTimeClignote = 1000;     // 1/2 période de clignotement du voyant alarme en ms

        // Base de contrôle de la retombée des alarmes en nb de c_nTimeClignote
        private int c_nBaseControleRetombee;
        private int nNbTimeClignote = 0;        // Nb de c_nTimeClignote passés

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
            if (m_recepteurNotifications != null)
                m_recepteurNotifications.Dispose();
            m_recepteurNotifications = null;
            if (m_proxySonnerie != null)
                m_proxySonnerie.Dispose();

            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_btnMaskAdmin = new System.Windows.Forms.Button();
            this.m_btnMaskBri = new System.Windows.Forms.Button();
            this.m_btnFrequente = new System.Windows.Forms.Button();
            this.m_btnMaskedOnCreation = new System.Windows.Forms.Button();
            this.m_timerVoyant = new System.Windows.Forms.Timer(this.components);
            this.m_LabelCompteur = new System.Windows.Forms.Label();
            this.m_lstViewRetombe = new spv.win32.CListViewAlarmes();
            this.m_lstViewEnCours = new spv.win32.CListViewAlarmes();
            this.m_btnAlarme = new System.Windows.Forms.Button();
            this.m_splitContainer = new System.Windows.Forms.SplitContainer();
            this.m_splitContainer.Panel1.SuspendLayout();
            this.m_splitContainer.Panel2.SuspendLayout();
            this.m_splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(297, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Current alarms|60014";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(297, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cleared alarms|60015";
            // 
            // m_btnMaskAdmin
            // 
            this.m_btnMaskAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnMaskAdmin.Location = new System.Drawing.Point(1, 481);
            this.m_btnMaskAdmin.Name = "m_btnMaskAdmin";
            this.m_btnMaskAdmin.Size = new System.Drawing.Size(223, 26);
            this.m_btnMaskAdmin.TabIndex = 4;
            this.m_btnMaskAdmin.Text = "Alarmes masked by Administrator :|60016";
            this.m_btnMaskAdmin.UseVisualStyleBackColor = true;
            this.m_btnMaskAdmin.Click += new System.EventHandler(this.m_btnMaskAdmin_Click);
            // 
            // m_btnMaskBri
            // 
            this.m_btnMaskBri.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnMaskBri.Location = new System.Drawing.Point(226, 481);
            this.m_btnMaskBri.Name = "m_btnMaskBri";
            this.m_btnMaskBri.Size = new System.Drawing.Size(223, 26);
            this.m_btnMaskBri.TabIndex = 5;
            this.m_btnMaskBri.Text = "Alarmes masked by Operating agent :|60017";
            this.m_btnMaskBri.UseVisualStyleBackColor = true;
            this.m_btnMaskBri.Click += new System.EventHandler(this.m_btnMaskBri_Click);
            // 
            // m_btnFrequente
            // 
            this.m_btnFrequente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnFrequente.Location = new System.Drawing.Point(451, 481);
            this.m_btnFrequente.Name = "m_btnFrequente";
            this.m_btnFrequente.Size = new System.Drawing.Size(223, 26);
            this.m_btnFrequente.TabIndex = 6;
            this.m_btnFrequente.Text = "Current frequent alarms :|60018";
            this.m_btnFrequente.UseVisualStyleBackColor = true;
            this.m_btnFrequente.Click += new System.EventHandler(this.m_btnFrequente_Click);
            // 
            // m_btnMaskedOnCreation
            // 
            this.m_btnMaskedOnCreation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnMaskedOnCreation.Location = new System.Drawing.Point(676, 481);
            this.m_btnMaskedOnCreation.Name = "m_btnMaskedOnCreation";
            this.m_btnMaskedOnCreation.Size = new System.Drawing.Size(223, 26);
            this.m_btnMaskedOnCreation.TabIndex = 7;
            this.m_btnMaskedOnCreation.Text = "Alarmes masked on creation : |60075";
            this.m_btnMaskedOnCreation.UseVisualStyleBackColor = true;
            this.m_btnMaskedOnCreation.Click += new System.EventHandler(this.m_btnMaskedOnCreation_Click);
            // 
            // m_timerVoyant
            // 
            this.m_timerVoyant.Interval = 1000;
            this.m_timerVoyant.Tick += new System.EventHandler(this.m_timerVoyant_Tick_1);
            // 
            // m_LabelCompteur
            // 
            this.m_LabelCompteur.AutoSize = true;
            this.m_LabelCompteur.Location = new System.Drawing.Point(40, 12);
            this.m_LabelCompteur.MinimumSize = new System.Drawing.Size(30, 0);
            this.m_LabelCompteur.Name = "m_LabelCompteur";
            this.m_LabelCompteur.Size = new System.Drawing.Size(30, 13);
            this.m_LabelCompteur.TabIndex = 9;
            this.m_LabelCompteur.Text = "0";
            this.m_LabelCompteur.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_lstViewRetombe
            // 
            this.m_lstViewRetombe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lstViewRetombe.FullRowSelect = true;
            this.m_lstViewRetombe.Location = new System.Drawing.Point(1, 27);
            this.m_lstViewRetombe.Name = "m_lstViewRetombe";
            this.m_lstViewRetombe.Size = new System.Drawing.Size(886, 140);
            this.m_lstViewRetombe.TabIndex = 1;
            this.m_lstViewRetombe.UseCompatibleStateImageBehavior = false;
            this.m_lstViewRetombe.View = System.Windows.Forms.View.Details;
            this.m_lstViewRetombe.VirtualListSize = 150;
            this.m_lstViewRetombe.VirtualMode = true;
            // 
            // m_lstViewEnCours
            // 
            this.m_lstViewEnCours.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lstViewEnCours.FullRowSelect = true;
            this.m_lstViewEnCours.Location = new System.Drawing.Point(-2, 25);
            this.m_lstViewEnCours.Name = "m_lstViewEnCours";
            this.m_lstViewEnCours.Size = new System.Drawing.Size(889, 224);
            this.m_lstViewEnCours.TabIndex = 0;
            this.m_lstViewEnCours.UseCompatibleStateImageBehavior = false;
            this.m_lstViewEnCours.View = System.Windows.Forms.View.Details;
            this.m_lstViewEnCours.VirtualListSize = 150;
            this.m_lstViewEnCours.VirtualMode = true;
            // 
            // m_btnAlarme
            // 
            this.m_btnAlarme.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnAlarme.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_btnAlarme.Image = global::spv.win32.Properties.Resources.IndicateurAlarmRepos;
            this.m_btnAlarme.Location = new System.Drawing.Point(4, 3);
            this.m_btnAlarme.Name = "m_btnAlarme";
            this.m_btnAlarme.Size = new System.Drawing.Size(33, 33);
            this.m_btnAlarme.TabIndex = 10;
            this.m_btnAlarme.UseVisualStyleBackColor = true;
            this.m_btnAlarme.Click += new System.EventHandler(this.m_btnAlarme_Click);
            // 
            // m_splitContainer
            // 
            this.m_splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_splitContainer.Location = new System.Drawing.Point(1, 39);
            this.m_splitContainer.Name = "m_splitContainer";
            this.m_splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // m_splitContainer.Panel1
            // 
            this.m_splitContainer.Panel1.Controls.Add(this.label1);
            this.m_splitContainer.Panel1.Controls.Add(this.m_lstViewEnCours);
            // 
            // m_splitContainer.Panel2
            // 
            this.m_splitContainer.Panel2.Controls.Add(this.label2);
            this.m_splitContainer.Panel2.Controls.Add(this.m_lstViewRetombe);
            this.m_splitContainer.Size = new System.Drawing.Size(895, 436);
            this.m_splitContainer.SplitterDistance = 256;
            this.m_splitContainer.TabIndex = 11;
            // 
            // CFormListeAlarmeEnCours
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(902, 512);
            this.Controls.Add(this.m_splitContainer);
            this.Controls.Add(this.m_LabelCompteur);
            this.Controls.Add(this.m_btnMaskedOnCreation);
            this.Controls.Add(this.m_btnFrequente);
            this.Controls.Add(this.m_btnMaskBri);
            this.Controls.Add(this.m_btnMaskAdmin);
            this.Controls.Add(this.m_btnAlarme);
            this.Name = "CFormListeAlarmeEnCours";
            this.Text = "Alarms";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CFormListeAlarmeEnCours_FormClosing);
            this.m_splitContainer.Panel1.ResumeLayout(false);
            this.m_splitContainer.Panel1.PerformLayout();
            this.m_splitContainer.Panel2.ResumeLayout(false);
            this.m_splitContainer.Panel2.PerformLayout();
            this.m_splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

   //     private System.Windows.Forms.ListView m_lstViewEnCours;
  //      private System.Windows.Forms.ListView m_lstViewRetombe;
        private CListViewAlarmes m_lstViewEnCours;
        private CListViewAlarmes m_lstViewRetombe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button m_btnMaskAdmin;
        private System.Windows.Forms.Button m_btnMaskBri;
        private System.Windows.Forms.Button m_btnFrequente;
        private System.Windows.Forms.Button m_btnMaskedOnCreation;
        private System.Windows.Forms.Timer m_timerVoyant;
        private System.Windows.Forms.Label m_LabelCompteur;
        private System.Windows.Forms.Button m_btnAlarme;
        private System.Windows.Forms.SplitContainer m_splitContainer;
    }
}
