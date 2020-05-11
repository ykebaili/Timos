namespace timos.projet.gantt
{
    partial class CPanelEditParametreDessinGantt
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_selectColeurTexte = new sc2i.win32.expression.CControlSelectColorByFormule();
            this.m_txtFormuleTexteZone = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.m_panelIcones = new timos.projet.gantt.CPanelEditParametresIconeGantt();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.m_extModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Text formula|10060";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 30);
            this.m_extModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Text color|10061";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 53);
            this.m_extModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Icons setting|10064";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_selectColeurTexte
            // 
            this.m_selectColeurTexte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_selectColeurTexte.FormuleCouleur = null;
            this.m_selectColeurTexte.Location = new System.Drawing.Point(148, 30);
            this.m_selectColeurTexte.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_selectColeurTexte, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_selectColeurTexte.Name = "m_selectColeurTexte";
            this.m_selectColeurTexte.SelectedColor = System.Drawing.Color.White;
            this.m_selectColeurTexte.Size = new System.Drawing.Size(349, 22);
            this.m_selectColeurTexte.TabIndex = 3;
            // 
            // m_txtFormuleTexteZone
            // 
            this.m_txtFormuleTexteZone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormuleTexteZone.Formule = null;
            this.m_txtFormuleTexteZone.Location = new System.Drawing.Point(148, 3);
            this.m_txtFormuleTexteZone.LockEdition = false;
            this.m_txtFormuleTexteZone.LockZoneTexte = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtFormuleTexteZone, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtFormuleTexteZone.Name = "m_txtFormuleTexteZone";
            this.m_txtFormuleTexteZone.Size = new System.Drawing.Size(349, 22);
            this.m_txtFormuleTexteZone.TabIndex = 0;
            // 
            // m_panelIcones
            // 
            this.m_panelIcones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelIcones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panelIcones.Location = new System.Drawing.Point(6, 76);
            this.m_panelIcones.LockEdition = true;
            this.m_extModeEdition.SetModeEdition(this.m_panelIcones, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelIcones.Name = "m_panelIcones";
            this.m_panelIcones.Size = new System.Drawing.Size(491, 309);
            this.m_panelIcones.TabIndex = 4;
            // 
            // CPanelEditParametreDessinGantt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_panelIcones);
            this.Controls.Add(this.m_selectColeurTexte);
            this.Controls.Add(this.m_txtFormuleTexteZone);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CPanelEditParametreDessinGantt";
            this.Size = new System.Drawing.Size(500, 388);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleTexteZone;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
        private sc2i.win32.expression.CControlSelectColorByFormule m_selectColeurTexte;
        private CPanelEditParametresIconeGantt m_panelIcones;
    }
}
