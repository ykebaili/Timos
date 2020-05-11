namespace timos.supervision
{
    partial class CControleTableauAlarmesEnCours
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CControleTableauAlarmesEnCours));
            this.m_splitContainer = new System.Windows.Forms.SplitContainer();
            this.m_treeListViewAlarmes = new timos.supervision.CTreeListViewAlarmes(this.components);
            this.m_imageList = new System.Windows.Forms.ImageList(this.components);
            this.m_explorateur = new sc2i.win32.expression.CExplorateurObjets();
            this.m_splitContainer.Panel1.SuspendLayout();
            this.m_splitContainer.Panel2.SuspendLayout();
            this.m_splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_treeListViewAlarmes)).BeginInit();
            this.SuspendLayout();
            // 
            // m_splitContainer
            // 
            this.m_splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_splitContainer.Location = new System.Drawing.Point(0, 0);
            this.m_splitContainer.Name = "m_splitContainer";
            // 
            // m_splitContainer.Panel1
            // 
            this.m_splitContainer.Panel1.Controls.Add(this.m_treeListViewAlarmes);
            // 
            // m_splitContainer.Panel2
            // 
            this.m_splitContainer.Panel2.Controls.Add(this.m_explorateur);
            this.m_splitContainer.Size = new System.Drawing.Size(717, 354);
            this.m_splitContainer.SplitterDistance = 530;
            this.m_splitContainer.TabIndex = 1;
            // 
            // m_treeListViewAlarmes
            // 
            this.m_treeListViewAlarmes.BackColor = System.Drawing.Color.White;
            this.m_treeListViewAlarmes.ColumnsOptions.HeaderHeight = 22;
            this.m_treeListViewAlarmes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_treeListViewAlarmes.Images = this.m_imageList;
            this.m_treeListViewAlarmes.Location = new System.Drawing.Point(0, 0);
            this.m_treeListViewAlarmes.Name = "m_treeListViewAlarmes";
            this.m_treeListViewAlarmes.Size = new System.Drawing.Size(528, 352);
            this.m_treeListViewAlarmes.TabIndex = 1;
            this.m_treeListViewAlarmes.Text = "cTreeListViewAlarmes1";
            this.m_treeListViewAlarmes.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_treeListViewAlarmes_AfterSelect);
            // 
            // m_imageList
            // 
            this.m_imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imageList.ImageStream")));
            this.m_imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.m_imageList.Images.SetKeyName(0, "1249545095_mail__arrow.png");
            this.m_imageList.Images.SetKeyName(1, "1266489279_exclamation.png");
            this.m_imageList.Images.SetKeyName(2, "status_unknown.png");
            this.m_imageList.Images.SetKeyName(3, "Action.png");
            // 
            // m_explorateur
            // 
            this.m_explorateur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_explorateur.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.m_explorateur.Location = new System.Drawing.Point(0, 0);
            this.m_explorateur.Name = "m_explorateur";
            this.m_explorateur.Size = new System.Drawing.Size(181, 352);
            this.m_explorateur.TabIndex = 0;
            // 
            // CControleTableauAlarmesEnCours
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.m_splitContainer);
            this.Name = "CControleTableauAlarmesEnCours";
            this.Size = new System.Drawing.Size(717, 354);
            this.Load += new System.EventHandler(this.CControleTableauAlarmesEnCours_Load);
            this.m_splitContainer.Panel1.ResumeLayout(false);
            this.m_splitContainer.Panel2.ResumeLayout(false);
            this.m_splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_treeListViewAlarmes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer m_splitContainer;
        private CTreeListViewAlarmes m_treeListViewAlarmes;
        private System.Windows.Forms.ImageList m_imageList;
        private sc2i.win32.expression.CExplorateurObjets m_explorateur;
    }
}
