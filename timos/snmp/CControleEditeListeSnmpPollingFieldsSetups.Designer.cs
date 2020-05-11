namespace timos.snmp
{
    partial class CControleEditeListeSnmpPollingFieldsSetups
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CControleEditeListeSnmpPollingFieldsSetups));
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_btnDelete = new sc2i.win32.common.CWndLinkStd();
            this.m_btnAddSetup = new sc2i.win32.common.CWndLinkStd();
            this.m_wndListeSetups = new sc2i.win32.common.customizableList.CCustomizableList();
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_btnDelete);
            this.panel1.Controls.Add(this.m_btnAddSetup);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(428, 20);
            this.panel1.TabIndex = 0;
            // 
            // m_btnDelete
            // 
            this.m_btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnDelete.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_btnDelete.CustomImage")));
            this.m_btnDelete.CustomText = "Remove";
            this.m_btnDelete.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnDelete.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_btnDelete.Location = new System.Drawing.Point(93, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnDelete, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnDelete.Name = "m_btnDelete";
            this.m_btnDelete.ShortMode = false;
            this.m_btnDelete.Size = new System.Drawing.Size(93, 20);
            this.m_btnDelete.TabIndex = 1;
            this.m_btnDelete.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_btnDelete.LinkClicked += new System.EventHandler(this.m_btnDelete_LinkClicked);
            // 
            // m_btnAddSetup
            // 
            this.m_btnAddSetup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnAddSetup.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_btnAddSetup.CustomImage")));
            this.m_btnAddSetup.CustomText = "Add";
            this.m_btnAddSetup.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnAddSetup.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_btnAddSetup.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnAddSetup, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnAddSetup.Name = "m_btnAddSetup";
            this.m_btnAddSetup.ShortMode = false;
            this.m_btnAddSetup.Size = new System.Drawing.Size(93, 20);
            this.m_btnAddSetup.TabIndex = 0;
            this.m_btnAddSetup.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_btnAddSetup.LinkClicked += new System.EventHandler(this.m_btnAddSetup_LinkClicked);
            // 
            // m_wndListeSetups
            // 
            this.m_wndListeSetups.CurrentItemIndex = null;
            this.m_wndListeSetups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeSetups.ItemControl = null;
            this.m_wndListeSetups.Items = new sc2i.win32.common.customizableList.CCustomizableListItem[0];
            this.m_wndListeSetups.Location = new System.Drawing.Point(0, 20);
            this.m_wndListeSetups.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_wndListeSetups, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_wndListeSetups.Name = "m_wndListeSetups";
            this.m_wndListeSetups.Size = new System.Drawing.Size(428, 178);
            this.m_wndListeSetups.TabIndex = 1;
            // 
            // CControleEditeListeSnmpPollingFields
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_wndListeSetups);
            this.Controls.Add(this.panel1);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleEditeListeSnmpPollingFields";
            this.Size = new System.Drawing.Size(428, 198);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private sc2i.win32.common.CWndLinkStd m_btnDelete;
        private sc2i.win32.common.CWndLinkStd m_btnAddSetup;
        private sc2i.win32.common.customizableList.CCustomizableList m_wndListeSetups;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
    }
}
