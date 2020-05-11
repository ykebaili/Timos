namespace TimosInventory
{
    partial class CFormPreparerBaseTravail
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormPreparerBaseTravail));
            this.m_arbreSites = new System.Windows.Forms.TreeView();
            this.m_imagesArbre = new System.Windows.Forms.ImageList(this.components);
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.m_wndListeSelectionnes = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_btnCreerBase = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_panelWorkInProgress = new System.Windows.Forms.Panel();
            this.m_btnConnect = new System.Windows.Forms.Button();
            this.m_btnQuitter = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_arbreSites
            // 
            this.m_arbreSites.CheckBoxes = true;
            this.m_arbreSites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_arbreSites.ImageIndex = 0;
            this.m_arbreSites.ImageList = this.m_imagesArbre;
            this.m_arbreSites.Location = new System.Drawing.Point(0, 33);
            this.m_arbreSites.Name = "m_arbreSites";
            this.m_arbreSites.SelectedImageIndex = 0;
            this.m_arbreSites.Size = new System.Drawing.Size(386, 323);
            this.m_extStyle.SetStyleBackColor(this.m_arbreSites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_arbreSites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_arbreSites.TabIndex = 0;
            this.m_arbreSites.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.m_arbreSites_AfterCheck);
            this.m_arbreSites.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.m_arbreSites_BeforeExpand);
            this.m_arbreSites.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.m_arbreSites_BeforeCheck);
            // 
            // m_imagesArbre
            // 
            this.m_imagesArbre.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imagesArbre.ImageStream")));
            this.m_imagesArbre.TransparentColor = System.Drawing.Color.Transparent;
            this.m_imagesArbre.Images.SetKeyName(0, "CSite.png");
            // 
            // m_wndListeSelectionnes
            // 
            this.m_wndListeSelectionnes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeSelectionnes.Location = new System.Drawing.Point(0, 26);
            this.m_wndListeSelectionnes.Name = "m_wndListeSelectionnes";
            this.m_wndListeSelectionnes.Size = new System.Drawing.Size(200, 297);
            this.m_wndListeSelectionnes.SmallImageList = this.m_imagesArbre;
            this.m_extStyle.SetStyleBackColor(this.m_wndListeSelectionnes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeSelectionnes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeSelectionnes.TabIndex = 2;
            this.m_wndListeSelectionnes.UseCompatibleStateImageBehavior = false;
            this.m_wndListeSelectionnes.View = System.Windows.Forms.View.SmallIcon;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.m_wndListeSelectionnes);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(386, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 323);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 26);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 3;
            this.label1.Text = "Your selection|20002";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.m_btnQuitter);
            this.panel2.Controls.Add(this.m_btnCreerBase);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(0, 356);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(586, 60);
            this.m_extStyle.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondFenetre);
            this.m_extStyle.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTexteFenetre);
            this.panel2.TabIndex = 4;
            // 
            // m_btnCreerBase
            // 
            this.m_btnCreerBase.Location = new System.Drawing.Point(12, 7);
            this.m_btnCreerBase.Name = "m_btnCreerBase";
            this.m_btnCreerBase.Size = new System.Drawing.Size(105, 41);
            this.m_extStyle.SetStyleBackColor(this.m_btnCreerBase, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnCreerBase, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnCreerBase.TabIndex = 0;
            this.m_btnCreerBase.Text = "Import datas|20003";
            this.m_btnCreerBase.UseVisualStyleBackColor = true;
            this.m_btnCreerBase.Click += new System.EventHandler(this.m_btnCreerBase_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.m_panelWorkInProgress);
            this.panel3.Controls.Add(this.m_btnConnect);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.ForeColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(586, 33);
            this.m_extStyle.SetStyleBackColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.panel3.TabIndex = 5;
            // 
            // m_panelWorkInProgress
            // 
            this.m_panelWorkInProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelWorkInProgress.Location = new System.Drawing.Point(36, 0);
            this.m_panelWorkInProgress.Name = "m_panelWorkInProgress";
            this.m_panelWorkInProgress.Size = new System.Drawing.Size(550, 33);
            this.m_extStyle.SetStyleBackColor(this.m_panelWorkInProgress, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelWorkInProgress, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelWorkInProgress.TabIndex = 2;
            // 
            // m_btnConnect
            // 
            this.m_btnConnect.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnConnect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.m_btnConnect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.m_btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnConnect.Image = global::TimosInventory.Properties.Resources.Refresh;
            this.m_btnConnect.Location = new System.Drawing.Point(0, 0);
            this.m_btnConnect.Name = "m_btnConnect";
            this.m_btnConnect.Size = new System.Drawing.Size(36, 33);
            this.m_extStyle.SetStyleBackColor(this.m_btnConnect, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnConnect, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnConnect.TabIndex = 0;
            this.m_btnConnect.UseVisualStyleBackColor = true;
            this.m_btnConnect.Click += new System.EventHandler(this.m_btnConnect_Click_1);
            // 
            // m_btnQuitter
            // 
            this.m_btnQuitter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnQuitter.Image = global::TimosInventory.Properties.Resources.Icone_quitter_32;
            this.m_btnQuitter.Location = new System.Drawing.Point(502, 6);
            this.m_btnQuitter.Name = "m_btnQuitter";
            this.m_btnQuitter.Size = new System.Drawing.Size(72, 50);
            this.m_extStyle.SetStyleBackColor(this.m_btnQuitter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnQuitter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnQuitter.TabIndex = 2;
            this.m_btnQuitter.UseVisualStyleBackColor = true;
            this.m_btnQuitter.Click += new System.EventHandler(this.m_btnQuitter_Click);
            // 
            // CFormPreparerBaseTravail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 416);
            this.Controls.Add(this.m_arbreSites);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Name = "CFormPreparerBaseTravail";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "Prepare work database|20000";
            this.Load += new System.EventHandler(this.CFormPreparerBaseTravail_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.CExtStyle m_extStyle;
        private System.Windows.Forms.TreeView m_arbreSites;
        private System.Windows.Forms.ImageList m_imagesArbre;
        private System.Windows.Forms.ListView m_wndListeSelectionnes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button m_btnCreerBase;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button m_btnConnect;
        private System.Windows.Forms.Panel m_panelWorkInProgress;
        private System.Windows.Forms.Button m_btnQuitter;
    }
}