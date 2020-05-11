using sc2i.win32.common;
namespace timos.supervision
{
    partial class CFormConsultationAlarmesEnCours
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
            if (m_recepteurNotifications != null)
            {
                m_recepteurNotifications.Dispose();
                m_recepteurNotifications = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormConsultationAlarmesEnCours));
            this.m_btnStopSonnerie = new System.Windows.Forms.Button();
            this.m_imagesBoutons32x32 = new System.Windows.Forms.ImageList(this.components);
            this.m_splitContainer = new System.Windows.Forms.SplitContainer();
            this.m_tableauAlarmesEnCours = new timos.supervision.CControleTableauAlarmesEnCours();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.m_tableauAlarmesRetombees = new timos.supervision.CControleTableauAlarmesEnCours();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.m_panelTop = new System.Windows.Forms.Panel();
            this.m_lblCompteurNouvellesAlarmes = new System.Windows.Forms.Label();
            this.m_chkAlwaysOnTop = new System.Windows.Forms.CheckBox();
            this.m_imagesBoutons16x16 = new System.Windows.Forms.ImageList(this.components);
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.m_toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_btnAficherMasque = new System.Windows.Forms.ToolStripDropDownButton();
            this.m_splitContainer.Panel1.SuspendLayout();
            this.m_splitContainer.Panel2.SuspendLayout();
            this.m_splitContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.m_panelTop.SuspendLayout();
            this.m_toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnStopSonnerie
            // 
            this.m_btnStopSonnerie.BackColor = System.Drawing.Color.Transparent;
            this.m_btnStopSonnerie.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.m_btnStopSonnerie.FlatAppearance.BorderSize = 0;
            this.m_btnStopSonnerie.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_btnStopSonnerie.ImageIndex = 0;
            this.m_btnStopSonnerie.ImageList = this.m_imagesBoutons32x32;
            this.m_btnStopSonnerie.Location = new System.Drawing.Point(12, 1);
            this.m_btnStopSonnerie.Name = "m_btnStopSonnerie";
            this.m_btnStopSonnerie.Size = new System.Drawing.Size(32, 31);
            this.m_extStyle.SetStyleBackColor(this.m_btnStopSonnerie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnStopSonnerie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnStopSonnerie.TabIndex = 1;
            this.m_btnStopSonnerie.UseVisualStyleBackColor = false;
            this.m_btnStopSonnerie.Click += new System.EventHandler(this.m_btnStopSonnerie_Click);
            // 
            // m_imagesBoutons32x32
            // 
            this.m_imagesBoutons32x32.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imagesBoutons32x32.ImageStream")));
            this.m_imagesBoutons32x32.TransparentColor = System.Drawing.Color.Transparent;
            this.m_imagesBoutons32x32.Images.SetKeyName(0, "bell_yellow_32x32.png");
            this.m_imagesBoutons32x32.Images.SetKeyName(1, "bell_disabled_yellow_32x32.png");
            // 
            // m_splitContainer
            // 
            this.m_splitContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_splitContainer.ForeColor = System.Drawing.Color.Black;
            this.m_splitContainer.Location = new System.Drawing.Point(0, 57);
            this.m_splitContainer.Name = "m_splitContainer";
            this.m_splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // m_splitContainer.Panel1
            // 
            this.m_splitContainer.Panel1.Controls.Add(this.m_tableauAlarmesEnCours);
            this.m_splitContainer.Panel1.Controls.Add(this.panel1);
            this.m_extStyle.SetStyleBackColor(this.m_splitContainer.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainer.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_splitContainer.Panel2
            // 
            this.m_splitContainer.Panel2.Controls.Add(this.m_tableauAlarmesRetombees);
            this.m_splitContainer.Panel2.Controls.Add(this.panel2);
            this.m_extStyle.SetStyleBackColor(this.m_splitContainer.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainer.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_splitContainer.Size = new System.Drawing.Size(770, 429);
            this.m_splitContainer.SplitterDistance = 232;
            this.m_extStyle.SetStyleBackColor(this.m_splitContainer, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainer, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_splitContainer.TabIndex = 2;
            // 
            // m_tableauAlarmesEnCours
            // 
            this.m_tableauAlarmesEnCours.BackColor = System.Drawing.Color.Transparent;
            this.m_tableauAlarmesEnCours.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tableauAlarmesEnCours.Location = new System.Drawing.Point(0, 34);
            this.m_tableauAlarmesEnCours.Name = "m_tableauAlarmesEnCours";
            this.m_tableauAlarmesEnCours.Size = new System.Drawing.Size(768, 196);
            this.m_extStyle.SetStyleBackColor(this.m_tableauAlarmesEnCours, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tableauAlarmesEnCours, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tableauAlarmesEnCours.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(768, 34);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(11, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(337, 23);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current Alarms|10221";
            // 
            // m_tableauAlarmesRetombees
            // 
            this.m_tableauAlarmesRetombees.BackColor = System.Drawing.Color.Transparent;
            this.m_tableauAlarmesRetombees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tableauAlarmesRetombees.Location = new System.Drawing.Point(0, 34);
            this.m_tableauAlarmesRetombees.Name = "m_tableauAlarmesRetombees";
            this.m_tableauAlarmesRetombees.Size = new System.Drawing.Size(768, 157);
            this.m_extStyle.SetStyleBackColor(this.m_tableauAlarmesRetombees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tableauAlarmesRetombees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tableauAlarmesRetombees.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(768, 34);
            this.m_extStyle.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(11, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(337, 23);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cleared Alarms|10222";
            // 
            // m_panelTop
            // 
            this.m_panelTop.BackgroundImage = global::timos.Properties.Resources.Fond_barre_navigation_3;
            this.m_panelTop.Controls.Add(this.m_lblCompteurNouvellesAlarmes);
            this.m_panelTop.Controls.Add(this.m_chkAlwaysOnTop);
            this.m_panelTop.Controls.Add(this.m_btnStopSonnerie);
            this.m_panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelTop.Location = new System.Drawing.Point(0, 0);
            this.m_panelTop.Name = "m_panelTop";
            this.m_panelTop.Size = new System.Drawing.Size(770, 32);
            this.m_extStyle.SetStyleBackColor(this.m_panelTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelTop.TabIndex = 3;
            // 
            // m_lblCompteurNouvellesAlarmes
            // 
            this.m_lblCompteurNouvellesAlarmes.AutoSize = true;
            this.m_lblCompteurNouvellesAlarmes.BackColor = System.Drawing.Color.Transparent;
            this.m_lblCompteurNouvellesAlarmes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblCompteurNouvellesAlarmes.ForeColor = System.Drawing.Color.Gold;
            this.m_lblCompteurNouvellesAlarmes.Location = new System.Drawing.Point(48, 5);
            this.m_lblCompteurNouvellesAlarmes.Name = "m_lblCompteurNouvellesAlarmes";
            this.m_lblCompteurNouvellesAlarmes.Size = new System.Drawing.Size(20, 24);
            this.m_extStyle.SetStyleBackColor(this.m_lblCompteurNouvellesAlarmes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblCompteurNouvellesAlarmes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblCompteurNouvellesAlarmes.TabIndex = 3;
            this.m_lblCompteurNouvellesAlarmes.Text = "3";
            // 
            // m_chkAlwaysOnTop
            // 
            this.m_chkAlwaysOnTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_chkAlwaysOnTop.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_chkAlwaysOnTop.BackColor = System.Drawing.Color.Transparent;
            this.m_chkAlwaysOnTop.FlatAppearance.BorderSize = 0;
            this.m_chkAlwaysOnTop.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.m_chkAlwaysOnTop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.m_chkAlwaysOnTop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(190)))));
            this.m_chkAlwaysOnTop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkAlwaysOnTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_chkAlwaysOnTop.ForeColor = System.Drawing.Color.White;
            this.m_chkAlwaysOnTop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_chkAlwaysOnTop.ImageIndex = 0;
            this.m_chkAlwaysOnTop.ImageList = this.m_imagesBoutons16x16;
            this.m_chkAlwaysOnTop.Location = new System.Drawing.Point(628, 5);
            this.m_chkAlwaysOnTop.Name = "m_chkAlwaysOnTop";
            this.m_chkAlwaysOnTop.Size = new System.Drawing.Size(130, 24);
            this.m_extStyle.SetStyleBackColor(this.m_chkAlwaysOnTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkAlwaysOnTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkAlwaysOnTop.TabIndex = 2;
            this.m_chkAlwaysOnTop.Text = "Always visible|10248";
            this.m_chkAlwaysOnTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.m_chkAlwaysOnTop.UseVisualStyleBackColor = false;
            this.m_chkAlwaysOnTop.CheckedChanged += new System.EventHandler(this.m_chkAlwaysOnTop_CheckedChanged);
            // 
            // m_imagesBoutons16x16
            // 
            this.m_imagesBoutons16x16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imagesBoutons16x16.ImageStream")));
            this.m_imagesBoutons16x16.TransparentColor = System.Drawing.Color.Transparent;
            this.m_imagesBoutons16x16.Images.SetKeyName(0, "pin-yellow_16x16.png");
            this.m_imagesBoutons16x16.Images.SetKeyName(1, "pin-yellow_vertical_16x16.png");
            // 
            // m_txtLibelle
            // 
            this.m_txtLibelle.Location = new System.Drawing.Point(132, 8);
            this.m_txtLibelle.LockEdition = false;
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(280, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Libelle]";
            // 
            // m_toolStrip
            // 
            this.m_toolStrip.BackColor = System.Drawing.SystemColors.MenuBar;
            this.m_toolStrip.BackgroundImage = global::timos.Properties.Resources.fond_menu_liste_3;
            this.m_toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.m_toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.m_btnAficherMasque});
            this.m_toolStrip.Location = new System.Drawing.Point(0, 32);
            this.m_toolStrip.Name = "m_toolStrip";
            this.m_toolStrip.Size = new System.Drawing.Size(770, 25);
            this.m_extStyle.SetStyleBackColor(this.m_toolStrip, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_toolStrip, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_toolStrip.TabIndex = 4;
            this.m_toolStrip.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(110, 22);
            this.toolStripLabel1.Text = "Quick Filter|10315";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // m_btnAficherMasque
            // 
            this.m_btnAficherMasque.AutoSize = true;
            this.m_btnAficherMasque.Image = global::timos.Properties.Resources.add;
            this.m_btnAficherMasque.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_btnAficherMasque.Name = "m_btnAficherMasque";
            this.m_btnAficherMasque.Size = new System.Drawing.Size(150, 22);
            this.m_btnAficherMasque.Text = "Masked Alarms|10312";
            this.m_btnAficherMasque.ToolTipText = "Show Alarms masked from specified level";
            this.m_btnAficherMasque.Click += new System.EventHandler(this.m_btnAficherMasque_Click);
            // 
            // CFormConsultationAlarmesEnCours
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(770, 486);
            this.Controls.Add(this.m_splitContainer);
            this.Controls.Add(this.m_toolStrip);
            this.Controls.Add(this.m_panelTop);
            this.Name = "CFormConsultationAlarmesEnCours";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "Timos - Alarm Board|10220";
            this.Load += new System.EventHandler(this.CFormConsultationAlarmesEnCours_Load);
            this.m_splitContainer.Panel1.ResumeLayout(false);
            this.m_splitContainer.Panel2.ResumeLayout(false);
            this.m_splitContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.m_panelTop.ResumeLayout(false);
            this.m_panelTop.PerformLayout();
            this.m_toolStrip.ResumeLayout(false);
            this.m_toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_btnStopSonnerie;
        private CControleTableauAlarmesEnCours m_tableauAlarmesEnCours;
        private System.Windows.Forms.SplitContainer m_splitContainer;
        private System.Windows.Forms.Panel m_panelTop;
        private sc2i.win32.common.C2iTextBox m_txtLibelle;
        private CExtStyle m_extStyle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private CControleTableauAlarmesEnCours m_tableauAlarmesRetombees;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox m_chkAlwaysOnTop;
        private System.Windows.Forms.ImageList m_imagesBoutons16x16;
        private System.Windows.Forms.Label m_lblCompteurNouvellesAlarmes;
        private System.Windows.Forms.ImageList m_imagesBoutons32x32;
        private System.Windows.Forms.ToolStrip m_toolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton m_btnAficherMasque;
    }
}