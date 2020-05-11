using sc2i.win32.common.customizableList;
namespace timos
{
    partial class CFormNotificationPopup
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
            this.m_panelContenu = new sc2i.win32.common.customizableList.CCustomizableList();
            this.m_panelTop = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_picFut = new System.Windows.Forms.PictureBox();
            this.m_picClose = new System.Windows.Forms.PictureBox();
            this.m_timer = new System.Windows.Forms.Timer(this.components);
            this.m_lblGauche = new System.Windows.Forms.Label();
            this.m_lblDroite = new System.Windows.Forms.Label();
            this.m_lblBas = new System.Windows.Forms.Label();
            this.m_panelTop.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_picFut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picClose)).BeginInit();
            this.SuspendLayout();
            // 
            // m_panelContenu
            // 
            this.m_panelContenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.m_panelContenu.CurrentItemIndex = null;
            this.m_panelContenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelContenu.ItemControl = null;
            this.m_panelContenu.Items = new sc2i.win32.common.customizableList.CCustomizableListItem[0];
            this.m_panelContenu.Location = new System.Drawing.Point(2, 24);
            this.m_panelContenu.LockEdition = false;
            this.m_panelContenu.Name = "m_panelContenu";
            this.m_panelContenu.Size = new System.Drawing.Size(283, 128);
            this.m_panelContenu.TabIndex = 0;
            // 
            // m_panelTop
            // 
            this.m_panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(108)))), ((int)(((byte)(0)))));
            this.m_panelTop.BackgroundImage = global::timos.Properties.Resources.Fond_dégradé_orange;
            this.m_panelTop.Controls.Add(this.panel1);
            this.m_panelTop.Controls.Add(this.m_picClose);
            this.m_panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelTop.Location = new System.Drawing.Point(0, 0);
            this.m_panelTop.Name = "m_panelTop";
            this.m_panelTop.Size = new System.Drawing.Size(287, 24);
            this.m_panelTop.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.m_picFut);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(89, 24);
            this.panel1.TabIndex = 2;
            // 
            // m_picFut
            // 
            this.m_picFut.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_picFut.BackColor = System.Drawing.Color.Transparent;
            this.m_picFut.Image = global::timos.Properties.Resources.timos_logo_texte;
            this.m_picFut.Location = new System.Drawing.Point(9, 2);
            this.m_picFut.Name = "m_picFut";
            this.m_picFut.Size = new System.Drawing.Size(70, 20);
            this.m_picFut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_picFut.TabIndex = 0;
            this.m_picFut.TabStop = false;
            this.m_picFut.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_picFut_MouseUp);
            // 
            // m_picClose
            // 
            this.m_picClose.BackColor = System.Drawing.Color.Transparent;
            this.m_picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_picClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_picClose.Image = global::timos.Properties.Resources.miniclose;
            this.m_picClose.Location = new System.Drawing.Point(252, 0);
            this.m_picClose.Name = "m_picClose";
            this.m_picClose.Size = new System.Drawing.Size(35, 24);
            this.m_picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_picClose.TabIndex = 1;
            this.m_picClose.TabStop = false;
            this.m_picClose.Click += new System.EventHandler(this.m_picClose_Click);
            // 
            // m_timer
            // 
            this.m_timer.Enabled = true;
            this.m_timer.Interval = 1000;
            this.m_timer.Tick += new System.EventHandler(this.m_timer_Tick);
            // 
            // m_lblGauche
            // 
            this.m_lblGauche.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(108)))), ((int)(((byte)(0)))));
            this.m_lblGauche.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lblGauche.Location = new System.Drawing.Point(0, 24);
            this.m_lblGauche.Name = "m_lblGauche";
            this.m_lblGauche.Size = new System.Drawing.Size(2, 130);
            this.m_lblGauche.TabIndex = 2;
            // 
            // m_lblDroite
            // 
            this.m_lblDroite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(108)))), ((int)(((byte)(0)))));
            this.m_lblDroite.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_lblDroite.Location = new System.Drawing.Point(285, 24);
            this.m_lblDroite.Name = "m_lblDroite";
            this.m_lblDroite.Size = new System.Drawing.Size(2, 130);
            this.m_lblDroite.TabIndex = 3;
            // 
            // m_lblBas
            // 
            this.m_lblBas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(108)))), ((int)(((byte)(0)))));
            this.m_lblBas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_lblBas.Location = new System.Drawing.Point(2, 152);
            this.m_lblBas.Name = "m_lblBas";
            this.m_lblBas.Size = new System.Drawing.Size(283, 2);
            this.m_lblBas.TabIndex = 4;
            // 
            // CFormNotificationPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 154);
            this.Controls.Add(this.m_panelContenu);
            this.Controls.Add(this.m_lblBas);
            this.Controls.Add(this.m_lblDroite);
            this.Controls.Add(this.m_lblGauche);
            this.Controls.Add(this.m_panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CFormNotificationPopup";
            this.Text = "CFormNotificationPopup";
            this.TopMost = true;
            this.m_panelTop.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_picFut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CCustomizableList m_panelContenu;
        private System.Windows.Forms.Panel m_panelTop;
        private System.Windows.Forms.PictureBox m_picFut;
        private System.Windows.Forms.PictureBox m_picClose;
        private System.Windows.Forms.Timer m_timer;
        private System.Windows.Forms.Label m_lblGauche;
        private System.Windows.Forms.Label m_lblDroite;
        private System.Windows.Forms.Label m_lblBas;
        private System.Windows.Forms.Panel panel1;
    }
}