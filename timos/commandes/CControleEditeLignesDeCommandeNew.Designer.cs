using sc2i.win32.common.customizableList;
namespace timos.commandes
{
    partial class CControleEditeLignesDeCommandeNew
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
            this.m_panelDragBesoin = new System.Windows.Forms.Panel();
            this.m_picDragBesoin = new System.Windows.Forms.PictureBox();
            this.m_lnkAddLine = new sc2i.win32.common.CWndLinkStd();
            this.m_wndListeCommandes = new sc2i.win32.common.customizableList.CCustomizableList();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_pictOrderLine = new System.Windows.Forms.PictureBox();
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_panelTop.SuspendLayout();
            this.m_panelDragBesoin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_picDragBesoin)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_pictOrderLine)).BeginInit();
            this.SuspendLayout();
            // 
            // m_panelTop
            // 
            this.m_panelTop.Controls.Add(this.m_panelDragBesoin);
            this.m_panelTop.Controls.Add(this.m_lnkAddLine);
            this.m_panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelTop.Location = new System.Drawing.Point(0, 0);
            this.m_panelTop.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_panelTop, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelTop.Name = "m_panelTop";
            this.m_panelTop.Size = new System.Drawing.Size(884, 23);
            this.m_panelTop.TabIndex = 1;
            // 
            // m_panelDragBesoin
            // 
            this.m_panelDragBesoin.AllowDrop = true;
            this.m_panelDragBesoin.Controls.Add(this.m_picDragBesoin);
            this.m_panelDragBesoin.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_panelDragBesoin.Location = new System.Drawing.Point(859, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelDragBesoin, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelDragBesoin.Name = "m_panelDragBesoin";
            this.m_panelDragBesoin.Size = new System.Drawing.Size(25, 23);
            this.m_panelDragBesoin.TabIndex = 2;
            this.m_panelDragBesoin.DragDrop += new System.Windows.Forms.DragEventHandler(this.m_picDragBesoin_DragDrop);
            this.m_panelDragBesoin.DragEnter += new System.Windows.Forms.DragEventHandler(this.m_picDragBesoin_DragEnter);
            // 
            // m_picDragBesoin
            // 
            this.m_picDragBesoin.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_picDragBesoin.Image = global::timos.Properties.Resources.PuzzleFem20;
            this.m_picDragBesoin.Location = new System.Drawing.Point(2, 0);
            this.m_extModeEdition.SetModeEdition(this.m_picDragBesoin, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_picDragBesoin.Name = "m_picDragBesoin";
            this.m_picDragBesoin.Size = new System.Drawing.Size(23, 23);
            this.m_picDragBesoin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_picDragBesoin.TabIndex = 1;
            this.m_picDragBesoin.TabStop = false;
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
            // m_wndListeCommandes
            // 
            this.m_wndListeCommandes.AllowDrop = true;
            this.m_wndListeCommandes.CurrentItemIndex = null;
            this.m_wndListeCommandes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeCommandes.ItemControl = null;
            this.m_wndListeCommandes.Items = new sc2i.win32.common.customizableList.CCustomizableListItem[0];
            this.m_wndListeCommandes.Location = new System.Drawing.Point(0, 47);
            this.m_wndListeCommandes.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_wndListeCommandes, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_wndListeCommandes.Name = "m_wndListeCommandes";
            this.m_wndListeCommandes.Size = new System.Drawing.Size(884, 213);
            this.m_wndListeCommandes.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.m_pictOrderLine);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.m_extModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(884, 24);
            this.panel1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(475, 0);
            this.m_extModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Label|50";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Dock = System.Windows.Forms.DockStyle.Right;
            this.label6.Location = new System.Drawing.Point(659, 0);
            this.m_extModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 24);
            this.label6.TabIndex = 5;
            this.label6.Text = "Reference|20397";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(268, 0);
            this.m_extModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Reference|20397";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Dock = System.Windows.Forms.DockStyle.Right;
            this.label4.Location = new System.Drawing.Point(760, 0);
            this.m_extModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Quantity|20398";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Dock = System.Windows.Forms.DockStyle.Right;
            this.label5.Location = new System.Drawing.Point(826, 0);
            this.m_extModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 24);
            this.label5.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(22, 0);
            this.m_extModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Equipment type|20396";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_pictOrderLine
            // 
            this.m_pictOrderLine.BackColor = System.Drawing.Color.White;
            this.m_pictOrderLine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_pictOrderLine.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_pictOrderLine.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_pictOrderLine, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_pictOrderLine.Name = "m_pictOrderLine";
            this.m_pictOrderLine.Size = new System.Drawing.Size(22, 24);
            this.m_pictOrderLine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_pictOrderLine.TabIndex = 9;
            this.m_pictOrderLine.TabStop = false;
            // 
            // CControleEditeLignesDeCommandeNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_wndListeCommandes);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_panelTop);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleEditeLignesDeCommandeNew";
            this.Size = new System.Drawing.Size(884, 260);
            this.m_panelTop.ResumeLayout(false);
            this.m_panelDragBesoin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_picDragBesoin)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_pictOrderLine)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.C2iPanel m_panelTop;
        private sc2i.win32.common.CWndLinkStd m_lnkAddLine;
        private CCustomizableList m_wndListeCommandes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
        private System.Windows.Forms.PictureBox m_pictOrderLine;
        private System.Windows.Forms.PictureBox m_picDragBesoin;
        private System.Windows.Forms.Panel m_panelDragBesoin;
    }
}
