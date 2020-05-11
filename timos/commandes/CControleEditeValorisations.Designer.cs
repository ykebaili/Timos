using sc2i.win32.common.customizableList;
namespace timos.commandes
{
    partial class CControleEditeValorisations
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
            this.m_panelTop = new sc2i.win32.common.C2iPanel(this.components);
            this.m_lnkAddLine = new sc2i.win32.common.CWndLinkStd();
            this.m_listeLignes = new sc2i.win32.common.customizableList.CCustomizableList();
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_panelTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelTop
            // 
            this.m_panelTop.Controls.Add(this.m_lnkAddLine);
            this.m_panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelTop.Location = new System.Drawing.Point(0, 0);
            this.m_panelTop.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_panelTop, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelTop.Name = "m_panelTop";
            this.m_panelTop.Size = new System.Drawing.Size(647, 23);
            this.m_panelTop.TabIndex = 0;
            // 
            // m_lnkAddLine
            // 
            this.m_lnkAddLine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAddLine.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkAddLine.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkAddLine.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lnkAddLine, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkAddLine.Name = "m_lnkAddLine";
            this.m_lnkAddLine.Size = new System.Drawing.Size(112, 23);
            this.m_lnkAddLine.TabIndex = 0;
            this.m_lnkAddLine.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAddLine.LinkClicked += new System.EventHandler(this.m_lnkAddLine_LinkClicked);
            // 
            // m_listeLignes
            // 
            this.m_listeLignes.CurrentItemIndex = null;
            this.m_listeLignes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_listeLignes.ItemControl = null;
            this.m_listeLignes.Items = new sc2i.win32.common.customizableList.CCustomizableListItem[0];
            this.m_listeLignes.Location = new System.Drawing.Point(0, 47);
            this.m_extModeEdition.SetModeEdition(this.m_listeLignes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_listeLignes.Name = "m_listeLignes";
            this.m_listeLignes.Size = new System.Drawing.Size(647, 263);
            this.m_listeLignes.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.m_extModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(647, 24);
            this.panel1.TabIndex = 2;
            this.panel1.Visible = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Dock = System.Windows.Forms.DockStyle.Right;
            this.label4.Location = new System.Drawing.Point(529, 0);
            this.m_extModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Value|20451";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Dock = System.Windows.Forms.DockStyle.Right;
            this.label5.Location = new System.Drawing.Point(595, 0);
            this.m_extModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 24);
            this.label5.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(647, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Equipment type|20396";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CControleEditeValorisations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_listeLignes);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_panelTop);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleEditeValorisations";
            this.Size = new System.Drawing.Size(647, 310);
            this.m_panelTop.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.C2iPanel m_panelTop;
        private sc2i.win32.common.CWndLinkStd m_lnkAddLine;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
        private CCustomizableList m_listeLignes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
    }
}
