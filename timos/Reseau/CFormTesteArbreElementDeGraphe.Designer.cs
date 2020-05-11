namespace timos.Reseau
{
    partial class CFormTesteArbreElementDeGraphe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_arbre = new System.Windows.Forms.TreeView();
            this.m_panelDroite = new System.Windows.Forms.Panel();
            this.m_lblNode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtCoeff = new sc2i.win32.common.C2iTextBoxNumerique();
            this.m_btnAppliquer = new System.Windows.Forms.Button();
            this.m_panelDroite.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_arbre
            // 
            this.m_arbre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_arbre.HideSelection = false;
            this.m_arbre.Location = new System.Drawing.Point(0, 0);
            this.m_arbre.Name = "m_arbre";
            this.m_arbre.Size = new System.Drawing.Size(434, 319);
            this.m_arbre.TabIndex = 0;
            this.m_arbre.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_arbre_AfterSelect);
            // 
            // m_panelDroite
            // 
            this.m_panelDroite.Controls.Add(this.m_btnAppliquer);
            this.m_panelDroite.Controls.Add(this.m_txtCoeff);
            this.m_panelDroite.Controls.Add(this.label1);
            this.m_panelDroite.Controls.Add(this.m_lblNode);
            this.m_panelDroite.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_panelDroite.Location = new System.Drawing.Point(0, 319);
            this.m_panelDroite.Name = "m_panelDroite";
            this.m_panelDroite.Size = new System.Drawing.Size(434, 64);
            this.m_panelDroite.TabIndex = 1;
            // 
            // m_lblNode
            // 
            this.m_lblNode.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_lblNode.Location = new System.Drawing.Point(0, 0);
            this.m_lblNode.Name = "m_lblNode";
            this.m_lblNode.Size = new System.Drawing.Size(434, 30);
            this.m_lblNode.TabIndex = 0;
            this.m_lblNode.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Coef";
            // 
            // m_txtCoeff
            // 
            this.m_txtCoeff.Arrondi = 2;
            this.m_txtCoeff.DecimalAutorise = true;
            this.m_txtCoeff.IntValue = 0;
            this.m_txtCoeff.Location = new System.Drawing.Point(41, 31);
            this.m_txtCoeff.LockEdition = false;
            this.m_txtCoeff.Name = "m_txtCoeff";
            this.m_txtCoeff.NullAutorise = false;
            this.m_txtCoeff.SelectAllOnEnter = true;
            this.m_txtCoeff.Size = new System.Drawing.Size(60, 20);
            this.m_txtCoeff.TabIndex = 2;
            // 
            // m_btnAppliquer
            // 
            this.m_btnAppliquer.Location = new System.Drawing.Point(107, 29);
            this.m_btnAppliquer.Name = "m_btnAppliquer";
            this.m_btnAppliquer.Size = new System.Drawing.Size(75, 23);
            this.m_btnAppliquer.TabIndex = 3;
            this.m_btnAppliquer.Text = "Appliquer";
            this.m_btnAppliquer.UseVisualStyleBackColor = true;
            this.m_btnAppliquer.Click += new System.EventHandler(this.m_btnAppliquer_Click);
            // 
            // CFormTesteArbreElementDeGraphe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(434, 383);
            this.Controls.Add(this.m_arbre);
            this.Controls.Add(this.m_panelDroite);
            this.Name = "CFormTesteArbreElementDeGraphe";
            this.Text = "CFormTesteArbreElementDeGraphe";
            this.m_panelDroite.ResumeLayout(false);
            this.m_panelDroite.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView m_arbre;
        private System.Windows.Forms.Panel m_panelDroite;
        private System.Windows.Forms.Button m_btnAppliquer;
        private sc2i.win32.common.C2iTextBoxNumerique m_txtCoeff;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label m_lblNode;
    }
}