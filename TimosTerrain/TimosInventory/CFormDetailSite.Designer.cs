using sc2i.win32.common;
namespace TimosInventory
{
    partial class CFormDetailSite
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
            this.m_lblNomSite = new System.Windows.Forms.Label();
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.panel1 = new sc2i.win32.common.C2iPanelOmbre();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_btnStartSurvey = new System.Windows.Forms.Button();
            this.m_arbreEquipements = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.m_btnQuitter = new System.Windows.Forms.Button();
            this.m_wndListeSites = new TimosInventory.CListViewTablette();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_lblNomSite
            // 
            this.m_lblNomSite.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_lblNomSite.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblNomSite.Location = new System.Drawing.Point(0, 0);
            this.m_lblNomSite.Name = "m_lblNomSite";
            this.m_lblNomSite.Size = new System.Drawing.Size(629, 24);
            this.m_extStyle.SetStyleBackColor(this.m_lblNomSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblNomSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblNomSite.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.m_wndListeSites);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.LockEdition = false;
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(242, 376);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 23);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 7;
            this.label1.Text = "Children sites|20018";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.m_btnQuitter);
            this.panel2.Controls.Add(this.m_arbreEquipements);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.m_btnStartSurvey);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(242, 24);
            this.panel2.LockEdition = false;
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(387, 376);
            this.m_extStyle.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.panel2.TabIndex = 2;
            // 
            // m_btnStartSurvey
            // 
            this.m_btnStartSurvey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnStartSurvey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.m_btnStartSurvey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.m_btnStartSurvey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.m_btnStartSurvey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnStartSurvey.Location = new System.Drawing.Point(2, 315);
            this.m_btnStartSurvey.Name = "m_btnStartSurvey";
            this.m_btnStartSurvey.Size = new System.Drawing.Size(236, 40);
            this.m_extStyle.SetStyleBackColor(this.m_btnStartSurvey, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnStartSurvey, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnStartSurvey.TabIndex = 10;
            this.m_btnStartSurvey.Text = "Start survey|20021";
            this.m_btnStartSurvey.UseVisualStyleBackColor = false;
            this.m_btnStartSurvey.Click += new System.EventHandler(this.m_btnStartSurvey_Click);
            // 
            // m_arbreEquipements
            // 
            this.m_arbreEquipements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_arbreEquipements.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_arbreEquipements.Location = new System.Drawing.Point(0, 26);
            this.m_arbreEquipements.Name = "m_arbreEquipements";
            this.m_arbreEquipements.Size = new System.Drawing.Size(370, 286);
            this.m_extStyle.SetStyleBackColor(this.m_arbreEquipements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_arbreEquipements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_arbreEquipements.TabIndex = 9;
            this.m_arbreEquipements.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.m_arbreEquipements_BeforeExpand);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(370, 23);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 8;
            this.label2.Text = "Equipments|20019";
            // 
            // m_btnQuitter
            // 
            this.m_btnQuitter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnQuitter.Image = global::TimosInventory.Properties.Resources.Icone_quitter_32;
            this.m_btnQuitter.Location = new System.Drawing.Point(298, 310);
            this.m_btnQuitter.Name = "m_btnQuitter";
            this.m_btnQuitter.Size = new System.Drawing.Size(72, 50);
            this.m_extStyle.SetStyleBackColor(this.m_btnQuitter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnQuitter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnQuitter.TabIndex = 11;
            this.m_btnQuitter.UseVisualStyleBackColor = true;
            this.m_btnQuitter.Click += new System.EventHandler(this.m_btnQuitter_Click);
            // 
            // m_wndListeSites
            // 
            this.m_wndListeSites.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_wndListeSites.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_wndListeSites.ForeColor = System.Drawing.Color.Blue;
            this.m_wndListeSites.FullRowSelect = true;
            this.m_wndListeSites.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_wndListeSites.ItemsColor = System.Drawing.Color.White;
            this.m_wndListeSites.Location = new System.Drawing.Point(0, 26);
            this.m_wndListeSites.MultiSelect = false;
            this.m_wndListeSites.Name = "m_wndListeSites";
            this.m_wndListeSites.OwnerDraw = true;
            this.m_wndListeSites.Size = new System.Drawing.Size(226, 325);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeSites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeSites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeSites.TabIndex = 6;
            this.m_wndListeSites.UseCompatibleStateImageBehavior = false;
            this.m_wndListeSites.View = System.Windows.Forms.View.Details;
            this.m_wndListeSites.Click += new System.EventHandler(this.m_wndListeSites_Click);
            // 
            // CFormDetailSite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 400);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_lblNomSite);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "CFormDetailSite";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondFenetre);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTexteFenetre);
            this.Text = "Site details|20017";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CFormDetailSite_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label m_lblNomSite;
        private sc2i.win32.common.CExtStyle m_extStyle;
        private C2iPanelOmbre panel1;
        private CListViewTablette m_wndListeSites;
        private System.Windows.Forms.Label label1;
        private C2iPanelOmbre panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView m_arbreEquipements;
        private System.Windows.Forms.Button m_btnStartSurvey;
        private System.Windows.Forms.Button m_btnQuitter;
    }
}