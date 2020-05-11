namespace futurocom.win32.sig
{
    partial class CWndSigMapView
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        private bool m_bStateSerialized = false;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                if (!m_bStateSerialized)
                {
                    SaveStateInRegistre();
                    m_bStateSerialized = true;
                }
                components.Dispose();
                if (m_mapDatabase != null)
                    m_mapDatabase.Dispose();
                m_mapDatabase = null;
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
            this.m_btnCalques = new System.Windows.Forms.Button();
            this.m_menuCalques = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // m_btnCalques
            // 
            this.m_btnCalques.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnCalques.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnCalques.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.m_btnCalques.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.m_btnCalques.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnCalques.Image = global::futurocom.win32.sig.Resource.MapSetup;
            this.m_btnCalques.Location = new System.Drawing.Point(352, 0);
            this.m_btnCalques.Name = "m_btnCalques";
            this.m_btnCalques.Size = new System.Drawing.Size(29, 29);
            this.m_btnCalques.TabIndex = 1;
            this.m_btnCalques.UseVisualStyleBackColor = true;
            this.m_btnCalques.Click += new System.EventHandler(this.m_btnCalques_Click);
            // 
            // m_menuCalques
            // 
            this.m_menuCalques.Name = "m_menuCalques";
            this.m_menuCalques.Size = new System.Drawing.Size(61, 4);
            this.m_menuCalques.Opening += new System.ComponentModel.CancelEventHandler(this.m_menuCalques_Opening);
            // 
            // CWndSigMapView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_btnCalques);
            this.Name = "CWndSigMapView";
            this.Size = new System.Drawing.Size(381, 315);
            this.Controls.SetChildIndex(this.m_btnCalques, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_btnCalques;
        private System.Windows.Forms.ContextMenuStrip m_menuCalques;
    }
}
