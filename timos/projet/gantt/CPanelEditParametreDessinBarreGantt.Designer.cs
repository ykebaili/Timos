namespace timos.projet.gantt
{
    partial class CPanelEditParametreDessinBarreGantt
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_selectCouleurProgression = new sc2i.win32.expression.CControlSelectColorByFormule();
            this.m_selectCouleurFond2 = new sc2i.win32.expression.CControlSelectColorByFormule();
            this.m_selectCouleurFond1 = new sc2i.win32.expression.CControlSelectColorByFormule();
            this.m_selectCouleurTexte = new sc2i.win32.expression.CControlSelectColorByFormule();
            this.m_txtFormuleTexteZone = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.m_panelIcones = new timos.projet.gantt.CPanelEditParametresIconeGantt();
            this.m_selectCouleurTerminee = new sc2i.win32.expression.CControlSelectColorByFormule();
            this.label7 = new System.Windows.Forms.Label();
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
            this.label3.Location = new System.Drawing.Point(3, 164);
            this.m_extModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Icons setting|10064";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 58);
            this.m_extModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 22);
            this.label4.TabIndex = 1;
            this.label4.Text = "Back color 1|10065";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 86);
            this.m_extModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 22);
            this.label5.TabIndex = 1;
            this.label5.Text = "Back color 2|10066";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 114);
            this.m_extModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 22);
            this.label6.TabIndex = 1;
            this.label6.Text = "Progress color|10067";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_selectCouleurProgression
            // 
            this.m_selectCouleurProgression.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_selectCouleurProgression.Location = new System.Drawing.Point(148, 114);
            this.m_selectCouleurProgression.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_selectCouleurProgression, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_selectCouleurProgression.Name = "m_selectCouleurProgression";
            this.m_selectCouleurProgression.SelectedColor = System.Drawing.Color.White;
            this.m_selectCouleurProgression.Size = new System.Drawing.Size(401, 22);
            this.m_selectCouleurProgression.TabIndex = 3;
            // 
            // m_selectCouleurFond2
            // 
            this.m_selectCouleurFond2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_selectCouleurFond2.Location = new System.Drawing.Point(148, 86);
            this.m_selectCouleurFond2.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_selectCouleurFond2, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_selectCouleurFond2.Name = "m_selectCouleurFond2";
            this.m_selectCouleurFond2.SelectedColor = System.Drawing.Color.White;
            this.m_selectCouleurFond2.Size = new System.Drawing.Size(401, 22);
            this.m_selectCouleurFond2.TabIndex = 3;
            // 
            // m_selectCouleurFond1
            // 
            this.m_selectCouleurFond1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_selectCouleurFond1.Location = new System.Drawing.Point(148, 58);
            this.m_selectCouleurFond1.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_selectCouleurFond1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_selectCouleurFond1.Name = "m_selectCouleurFond1";
            this.m_selectCouleurFond1.SelectedColor = System.Drawing.Color.White;
            this.m_selectCouleurFond1.Size = new System.Drawing.Size(401, 22);
            this.m_selectCouleurFond1.TabIndex = 3;
            // 
            // m_selectCouleurTexte
            // 
            this.m_selectCouleurTexte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_selectCouleurTexte.Location = new System.Drawing.Point(148, 30);
            this.m_selectCouleurTexte.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_selectCouleurTexte, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_selectCouleurTexte.Name = "m_selectCouleurTexte";
            this.m_selectCouleurTexte.SelectedColor = System.Drawing.Color.White;
            this.m_selectCouleurTexte.Size = new System.Drawing.Size(401, 22);
            this.m_selectCouleurTexte.TabIndex = 3;
            // 
            // m_txtFormuleTexteZone
            // 
            this.m_txtFormuleTexteZone.AllowGraphic = true;
            this.m_txtFormuleTexteZone.AllowNullFormula = false;
            this.m_txtFormuleTexteZone.AllowSaisieTexte = true;
            this.m_txtFormuleTexteZone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormuleTexteZone.Formule = null;
            this.m_txtFormuleTexteZone.Location = new System.Drawing.Point(148, 3);
            this.m_txtFormuleTexteZone.LockEdition = false;
            this.m_txtFormuleTexteZone.LockZoneTexte = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtFormuleTexteZone, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtFormuleTexteZone.Name = "m_txtFormuleTexteZone";
            this.m_txtFormuleTexteZone.Size = new System.Drawing.Size(401, 22);
            this.m_txtFormuleTexteZone.TabIndex = 0;
            // 
            // m_panelIcones
            // 
            this.m_panelIcones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelIcones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panelIcones.Location = new System.Drawing.Point(6, 190);
            this.m_panelIcones.LockEdition = true;
            this.m_extModeEdition.SetModeEdition(this.m_panelIcones, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelIcones.Name = "m_panelIcones";
            this.m_panelIcones.Size = new System.Drawing.Size(543, 190);
            this.m_panelIcones.TabIndex = 4;
            // 
            // m_selectCouleurTerminee
            // 
            this.m_selectCouleurTerminee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_selectCouleurTerminee.Location = new System.Drawing.Point(148, 142);
            this.m_selectCouleurTerminee.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_selectCouleurTerminee, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_selectCouleurTerminee.Name = "m_selectCouleurTerminee";
            this.m_selectCouleurTerminee.SelectedColor = System.Drawing.Color.White;
            this.m_selectCouleurTerminee.Size = new System.Drawing.Size(401, 22);
            this.m_selectCouleurTerminee.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(3, 142);
            this.m_extModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 22);
            this.label7.TabIndex = 5;
            this.label7.Text = "Ended color|20752";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CPanelEditParametreDessinBarreGantt
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_selectCouleurTerminee);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.m_panelIcones);
            this.Controls.Add(this.m_selectCouleurProgression);
            this.Controls.Add(this.m_selectCouleurFond2);
            this.Controls.Add(this.m_selectCouleurFond1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.m_selectCouleurTexte);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.m_txtFormuleTexteZone);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CPanelEditParametreDessinBarreGantt";
            this.Size = new System.Drawing.Size(552, 383);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleTexteZone;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
        private sc2i.win32.expression.CControlSelectColorByFormule m_selectCouleurTexte;
        private System.Windows.Forms.Label label4;
        private sc2i.win32.expression.CControlSelectColorByFormule m_selectCouleurFond1;
        private System.Windows.Forms.Label label5;
        private sc2i.win32.expression.CControlSelectColorByFormule m_selectCouleurFond2;
        private System.Windows.Forms.Label label6;
        private sc2i.win32.expression.CControlSelectColorByFormule m_selectCouleurProgression;
        private CPanelEditParametresIconeGantt m_panelIcones;
        private sc2i.win32.expression.CControlSelectColorByFormule m_selectCouleurTerminee;
        private System.Windows.Forms.Label label7;
    }
}
