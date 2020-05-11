namespace timos.process.workflow
{
    partial class CPanelEtapeWorkflowFormulaire
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
            this.components = new System.ComponentModel.Container();
            this.m_panelTotal = new System.Windows.Forms.Panel();
            this.m_panelFormulalire = new sc2i.formulaire.win32.editor.CPanelFormulaireSurElement();
            this.m_panelBas = new System.Windows.Forms.Panel();
            this.m_imageFleche = new System.Windows.Forms.PictureBox();
            this.m_panelInstructions = new System.Windows.Forms.Panel();
            this.m_lblInstructions = new sc2i.win32.common.C2iLabel();
            this.m_imageInstructions = new sc2i.win32.common.C2iPictureBox();
            this.m_panelTop = new System.Windows.Forms.Panel();
            this.m_btnActions = new System.Windows.Forms.Button();
            this.m_lblNomEtape = new System.Windows.Forms.Label();
            this.m_btnTerminer = new System.Windows.Forms.Button();
            this.m_btnAnnuler = new System.Windows.Forms.Button();
            this.m_imageTask1 = new System.Windows.Forms.PictureBox();
            this.m_timerClignotant = new System.Windows.Forms.Timer(this.components);
            this.m_menuActions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_panelTotal.SuspendLayout();
            this.m_panelBas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageFleche)).BeginInit();
            this.m_panelInstructions.SuspendLayout();
            this.m_panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageTask1)).BeginInit();
            this.SuspendLayout();
            // 
            // m_panelTotal
            // 
            this.m_panelTotal.BackColor = System.Drawing.Color.White;
            this.m_panelTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panelTotal.Controls.Add(this.m_panelFormulalire);
            this.m_panelTotal.Controls.Add(this.m_panelBas);
            this.m_panelTotal.Controls.Add(this.m_panelInstructions);
            this.m_panelTotal.Controls.Add(this.m_panelTop);
            this.m_panelTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelTotal.Location = new System.Drawing.Point(0, 0);
            this.m_panelTotal.Name = "m_panelTotal";
            this.m_panelTotal.Size = new System.Drawing.Size(556, 231);
            this.m_panelTotal.TabIndex = 0;
            // 
            // m_panelFormulalire
            // 
            this.m_panelFormulalire.AutoScroll = true;
            this.m_panelFormulalire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelFormulalire.ElementEdite = null;
            this.m_panelFormulalire.Location = new System.Drawing.Point(0, 109);
            this.m_panelFormulalire.LockEdition = false;
            this.m_panelFormulalire.Name = "m_panelFormulalire";
            this.m_panelFormulalire.Size = new System.Drawing.Size(554, 104);
            this.m_panelFormulalire.TabIndex = 5;
            // 
            // m_panelBas
            // 
            this.m_panelBas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(108)))), ((int)(((byte)(0)))));
            this.m_panelBas.Controls.Add(this.m_imageFleche);
            this.m_panelBas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_panelBas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_panelBas.Location = new System.Drawing.Point(0, 213);
            this.m_panelBas.Name = "m_panelBas";
            this.m_panelBas.Size = new System.Drawing.Size(554, 16);
            this.m_panelBas.TabIndex = 7;
            // 
            // m_imageFleche
            // 
            this.m_imageFleche.BackColor = System.Drawing.Color.Transparent;
            this.m_imageFleche.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_imageFleche.Image = global::timos.Properties.Resources.discretUp;
            this.m_imageFleche.Location = new System.Drawing.Point(0, 0);
            this.m_imageFleche.Name = "m_imageFleche";
            this.m_imageFleche.Size = new System.Drawing.Size(554, 16);
            this.m_imageFleche.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_imageFleche.TabIndex = 0;
            this.m_imageFleche.TabStop = false;
            this.m_imageFleche.Click += new System.EventHandler(this.m_panelBas_Click);
            // 
            // m_panelInstructions
            // 
            this.m_panelInstructions.Controls.Add(this.m_lblInstructions);
            this.m_panelInstructions.Controls.Add(this.m_imageInstructions);
            this.m_panelInstructions.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelInstructions.Location = new System.Drawing.Point(0, 48);
            this.m_panelInstructions.Name = "m_panelInstructions";
            this.m_panelInstructions.Size = new System.Drawing.Size(554, 61);
            this.m_panelInstructions.TabIndex = 4;
            // 
            // m_lblInstructions
            // 
            this.m_lblInstructions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lblInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblInstructions.Location = new System.Drawing.Point(65, 0);
            this.m_lblInstructions.LockEdition = true;
            this.m_lblInstructions.Name = "m_lblInstructions";
            this.m_lblInstructions.Size = new System.Drawing.Size(489, 61);
            this.m_lblInstructions.TabIndex = 2;
            this.m_lblInstructions.Text = "Instructions ici";
            // 
            // m_imageInstructions
            // 
            this.m_imageInstructions.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_imageInstructions.Image = global::timos.Properties.Resources.ImgInfo;
            this.m_imageInstructions.Location = new System.Drawing.Point(0, 0);
            this.m_imageInstructions.Name = "m_imageInstructions";
            this.m_imageInstructions.Size = new System.Drawing.Size(65, 61);
            this.m_imageInstructions.TabIndex = 1;
            this.m_imageInstructions.Click += new System.EventHandler(this.m_imageInstructions_Click);
            // 
            // m_panelTop
            // 
            this.m_panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(108)))), ((int)(((byte)(0)))));
            this.m_panelTop.Controls.Add(this.m_btnActions);
            this.m_panelTop.Controls.Add(this.m_lblNomEtape);
            this.m_panelTop.Controls.Add(this.m_btnTerminer);
            this.m_panelTop.Controls.Add(this.m_btnAnnuler);
            this.m_panelTop.Controls.Add(this.m_imageTask1);
            this.m_panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelTop.Location = new System.Drawing.Point(0, 0);
            this.m_panelTop.Name = "m_panelTop";
            this.m_panelTop.Size = new System.Drawing.Size(554, 48);
            this.m_panelTop.TabIndex = 6;
            // 
            // m_btnActions
            // 
            this.m_btnActions.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnActions.Image = global::timos.Properties.Resources.applications;
            this.m_btnActions.Location = new System.Drawing.Point(410, 0);
            this.m_btnActions.Name = "m_btnActions";
            this.m_btnActions.Size = new System.Drawing.Size(48, 48);
            this.m_btnActions.TabIndex = 6;
            this.m_btnActions.UseVisualStyleBackColor = true;
            this.m_btnActions.Click += new System.EventHandler(this.m_btnActions_Click);
            // 
            // m_lblNomEtape
            // 
            this.m_lblNomEtape.BackColor = System.Drawing.Color.Transparent;
            this.m_lblNomEtape.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lblNomEtape.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblNomEtape.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.m_lblNomEtape.Location = new System.Drawing.Point(43, 0);
            this.m_lblNomEtape.Name = "m_lblNomEtape";
            this.m_lblNomEtape.Size = new System.Drawing.Size(415, 48);
            this.m_lblNomEtape.TabIndex = 2;
            this.m_lblNomEtape.Text = "Etape";
            this.m_lblNomEtape.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_btnTerminer
            // 
            this.m_btnTerminer.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnTerminer.Image = global::timos.Properties.Resources.check;
            this.m_btnTerminer.Location = new System.Drawing.Point(458, 0);
            this.m_btnTerminer.Name = "m_btnTerminer";
            this.m_btnTerminer.Size = new System.Drawing.Size(48, 48);
            this.m_btnTerminer.TabIndex = 0;
            this.m_btnTerminer.UseVisualStyleBackColor = true;
            this.m_btnTerminer.Click += new System.EventHandler(this.m_btnTerminer_Click);
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnAnnuler.Image = global::timos.Properties.Resources._1347551266_gnome_session_logout;
            this.m_btnAnnuler.Location = new System.Drawing.Point(506, 0);
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(48, 48);
            this.m_btnAnnuler.TabIndex = 0;
            this.m_btnAnnuler.UseVisualStyleBackColor = true;
            this.m_btnAnnuler.Click += new System.EventHandler(this.m_btnAnnuler_Click);
            // 
            // m_imageTask1
            // 
            this.m_imageTask1.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_imageTask1.Image = global::timos.Properties.Resources._1346738948_task;
            this.m_imageTask1.Location = new System.Drawing.Point(0, 0);
            this.m_imageTask1.Name = "m_imageTask1";
            this.m_imageTask1.Size = new System.Drawing.Size(43, 48);
            this.m_imageTask1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_imageTask1.TabIndex = 5;
            this.m_imageTask1.TabStop = false;
            // 
            // m_timerClignotant
            // 
            this.m_timerClignotant.Enabled = true;
            this.m_timerClignotant.Interval = 50;
            this.m_timerClignotant.Tick += new System.EventHandler(this.m_timerClignotant_Tick);
            // 
            // m_menuActions
            // 
            this.m_menuActions.Name = "m_menuActions";
            this.m_menuActions.Size = new System.Drawing.Size(153, 26);
            // 
            // CPanelEtapeWorkflowFormulaire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_panelTotal);
            this.Name = "CPanelEtapeWorkflowFormulaire";
            this.Size = new System.Drawing.Size(556, 231);
            this.m_panelTotal.ResumeLayout(false);
            this.m_panelBas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_imageFleche)).EndInit();
            this.m_panelInstructions.ResumeLayout(false);
            this.m_panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_imageTask1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel m_panelTotal;
        private System.Windows.Forms.Label m_lblNomEtape;
        private System.Windows.Forms.Button m_btnTerminer;
        private System.Windows.Forms.Button m_btnAnnuler;
        private sc2i.formulaire.win32.editor.CPanelFormulaireSurElement m_panelFormulalire;
        private System.Windows.Forms.Panel m_panelInstructions;
        private System.Windows.Forms.Panel m_panelTop;
        private System.Windows.Forms.Panel m_panelBas;
        private System.Windows.Forms.PictureBox m_imageTask1;
        private System.Windows.Forms.Timer m_timerClignotant;
        private sc2i.win32.common.C2iPictureBox m_imageInstructions;
        private sc2i.win32.common.C2iLabel m_lblInstructions;
        private System.Windows.Forms.PictureBox m_imageFleche;
        private System.Windows.Forms.Button m_btnActions;
        private System.Windows.Forms.ContextMenuStrip m_menuActions;
    }
}
