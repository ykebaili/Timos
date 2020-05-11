using timos.projet.besoin.map;
namespace timos.projet.besoin
{
    partial class CFormMapBesoinsPopup
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
            this.m_panelMap = new CControleMapBesoin();
            this.m_panelTop = new System.Windows.Forms.Panel();
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.SuspendLayout();
            // 
            // m_panelMap
            // 
            this.m_panelMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelMap.ForeColor = System.Drawing.Color.Black;
            this.m_panelMap.Location = new System.Drawing.Point(0, 21);
            this.m_panelMap.Name = "m_panelMap";
            this.m_panelMap.Size = new System.Drawing.Size(595, 334);
            this.m_extStyle.SetStyleBackColor(this.m_panelMap, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panelMap, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelMap.TabIndex = 0;
            // 
            // m_panelTop
            // 
            this.m_panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelTop.ForeColor = System.Drawing.Color.Black;
            this.m_panelTop.Location = new System.Drawing.Point(0, 0);
            this.m_panelTop.Name = "m_panelTop";
            this.m_panelTop.Size = new System.Drawing.Size(595, 21);
            this.m_extStyle.SetStyleBackColor(this.m_panelTop, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panelTop, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelTop.TabIndex = 1;
            // 
            // CFormMapBesoinPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 355);
            this.Controls.Add(this.m_panelMap);
            this.Controls.Add(this.m_panelTop);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "CFormMapBesoinPopup";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondFenetre);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTexteFenetre);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CFormMapBesoinPopup_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private CControleMapBesoin m_panelMap;
        private sc2i.win32.common.CExtStyle m_extStyle;
        private System.Windows.Forms.Panel m_panelTop;
    }
}