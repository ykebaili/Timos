namespace futurocom.win32.sig
{
    partial class CControleEditeMapsItemsDessins
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_btnAddItem = new sc2i.win32.common.CWndLinkStd();
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelDessin
            // 
            this.m_panelDessin.Location = new System.Drawing.Point(0, 22);
            this.m_extModeEdition.SetModeEdition(this.m_panelDessin, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelDessin.Size = new System.Drawing.Size(450, 233);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_btnAddItem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 22);
            this.panel1.TabIndex = 0;
            // 
            // m_btnAddItem
            // 
            this.m_btnAddItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnAddItem.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnAddItem.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_btnAddItem.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnAddItem, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnAddItem.Name = "m_btnAddItem";
            this.m_btnAddItem.ShortMode = false;
            this.m_btnAddItem.Size = new System.Drawing.Size(112, 22);
            this.m_btnAddItem.TabIndex = 0;
            this.m_btnAddItem.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_btnAddItem.LinkClicked += new System.EventHandler(this.m_btnAddItem_LinkClicked);
            // 
            // CControleEditeMapsItemsDessins
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Items = new sc2i.win32.common.customizableList.CCustomizableListItem[0];
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleEditeMapsItemsDessins";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.m_panelDessin, 0);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private sc2i.win32.common.CWndLinkStd m_btnAddItem;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;

    }
}
