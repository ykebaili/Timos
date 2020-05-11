using sc2i.win32.common.customizableList;
namespace timos.interventions
{
    partial class CControleAffecteIntervenantsDeProfil
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
            this.m_lblProfil = new System.Windows.Forms.Label();
            this.m_wndListeIntervenants = new sc2i.win32.common.customizableList.CCustomizableList();
            this.m_lnkAdd = new sc2i.win32.common.CWndLinkStd();
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_lblProfil
            // 
            this.m_lblProfil.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lblProfil.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lblProfil, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblProfil.Name = "m_lblProfil";
            this.m_lblProfil.Size = new System.Drawing.Size(162, 23);
            this.m_lblProfil.TabIndex = 1;
            this.m_lblProfil.Text = "Profile label|556";
            this.m_lblProfil.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_wndListeIntervenants
            // 
            this.m_wndListeIntervenants.CurrentItemIndex = null;
            this.m_wndListeIntervenants.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeIntervenants.ItemControl = null;
            this.m_wndListeIntervenants.Items = new sc2i.win32.common.customizableList.CCustomizableListItem[0];
            this.m_wndListeIntervenants.Location = new System.Drawing.Point(187, 0);
            this.m_wndListeIntervenants.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_wndListeIntervenants, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_wndListeIntervenants.Name = "m_wndListeIntervenants";
            this.m_wndListeIntervenants.Size = new System.Drawing.Size(173, 23);
            this.m_wndListeIntervenants.TabIndex = 2;
            // 
            // m_lnkAdd
            // 
            this.m_lnkAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAdd.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_lnkAdd.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkAdd.Location = new System.Drawing.Point(162, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lnkAdd, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkAdd.Name = "m_lnkAdd";
            this.m_lnkAdd.Size = new System.Drawing.Size(25, 23);
            this.m_lnkAdd.TabIndex = 0;
            this.m_lnkAdd.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAdd.LinkClicked += new System.EventHandler(this.m_lnkAdd_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_lblProfil);
            this.panel1.Controls.Add(this.m_lnkAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(187, 20);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(187, 23);
            this.panel2.TabIndex = 4;
            // 
            // CControleAffecteIntervenantsDeProfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_wndListeIntervenants);
            this.Controls.Add(this.panel2);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleAffecteIntervenantsDeProfil";
            this.Size = new System.Drawing.Size(360, 23);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label m_lblProfil;
        private CCustomizableList m_wndListeIntervenants;
        private sc2i.win32.common.CWndLinkStd m_lnkAdd;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
