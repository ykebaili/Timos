using System.Windows.Forms;
namespace timos.Reseau
{
    partial class CFormEditCParametreRepresentationSymbole
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
                foreach (Control ctrl in m_listeControlesFormule)
                    ctrl.Dispose();
                m_listeControlesFormule.Clear();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditCParametreRepresentationSymbole));
            this.m_panelEditeurSymbole = new timos.CPanelEditeurSymbole();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_btnAnnuler = new System.Windows.Forms.Button();
            this.m_panelBas = new System.Windows.Forms.Panel();
            this.m_panelFormules = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.cExtStyle1 = new sc2i.win32.common.CExtStyle();
            this.m_panelDroite = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.m_panelBas.SuspendLayout();
            this.m_panelDroite.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelEditeurSymbole
            // 
            this.m_panelEditeurSymbole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelEditeurSymbole.Location = new System.Drawing.Point(0, 0);
            this.m_panelEditeurSymbole.Name = "m_panelEditeurSymbole";
            this.m_panelEditeurSymbole.Size = new System.Drawing.Size(640, 388);
            this.cExtStyle1.SetStyleBackColor(this.m_panelEditeurSymbole, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_panelEditeurSymbole, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEditeurSymbole.SymboleEdite = null;
            this.m_panelEditeurSymbole.TabIndex = 4019;
            this.m_panelEditeurSymbole.TypeEdite = null;
            this.m_panelEditeurSymbole.SelectionChanged += new System.EventHandler(this.m_panelEditeurSymbole_SelectionChanged);
            // 
            // m_btnOk
            // 
            this.m_btnOk.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnOk.ForeColor = System.Drawing.Color.White;
            this.m_btnOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btnOk.Image")));
            this.m_btnOk.Location = new System.Drawing.Point(374, 3);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(40, 40);
            this.cExtStyle1.SetStyleBackColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnOk.TabIndex = 4017;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnAnnuler.ForeColor = System.Drawing.Color.White;
            this.m_btnAnnuler.Image = ((System.Drawing.Image)(resources.GetObject("m_btnAnnuler.Image")));
            this.m_btnAnnuler.Location = new System.Drawing.Point(429, 3);
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(40, 40);
            this.cExtStyle1.SetStyleBackColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAnnuler.TabIndex = 4018;
            this.m_btnAnnuler.Click += new System.EventHandler(this.m_btnAnnuler_Click);
            // 
            // m_panelBas
            // 
            this.m_panelBas.Controls.Add(this.m_btnOk);
            this.m_panelBas.Controls.Add(this.m_btnAnnuler);
            this.m_panelBas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_panelBas.Location = new System.Drawing.Point(0, 388);
            this.m_panelBas.Name = "m_panelBas";
            this.m_panelBas.Size = new System.Drawing.Size(843, 52);
            this.cExtStyle1.SetStyleBackColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelBas.TabIndex = 4020;
            // 
            // m_panelFormules
            // 
            this.m_panelFormules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelFormules.Location = new System.Drawing.Point(0, 13);
            this.m_panelFormules.Name = "m_panelFormules";
            this.m_panelFormules.Size = new System.Drawing.Size(200, 375);
            this.cExtStyle1.SetStyleBackColor(this.m_panelFormules, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_panelFormules, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelFormules.TabIndex = 4021;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(640, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 388);
            this.cExtStyle1.SetStyleBackColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitter1.TabIndex = 4022;
            this.splitter1.TabStop = false;
            // 
            // m_panelDroite
            // 
            this.m_panelDroite.Controls.Add(this.m_panelFormules);
            this.m_panelDroite.Controls.Add(this.label1);
            this.m_panelDroite.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_panelDroite.Location = new System.Drawing.Point(643, 0);
            this.m_panelDroite.Name = "m_panelDroite";
            this.m_panelDroite.Size = new System.Drawing.Size(200, 388);
            this.cExtStyle1.SetStyleBackColor(this.m_panelDroite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_panelDroite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelDroite.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 13);
            this.cExtStyle1.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dynamic fields|20054";
            // 
            // CFormEditCParametreRepresentationSymbole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(843, 440);
            this.Controls.Add(this.m_panelEditeurSymbole);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.m_panelDroite);
            this.Controls.Add(this.m_panelBas);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "CFormEditCParametreRepresentationSymbole";
            this.cExtStyle1.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.cExtStyle1.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.Text = "Dynamic symbol|20055";
            this.Load += new System.EventHandler(this.CFormEditCParametreRepresentationSymbole_Load);
            this.m_panelBas.ResumeLayout(false);
            this.m_panelDroite.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CPanelEditeurSymbole m_panelEditeurSymbole;
        private System.Windows.Forms.Button m_btnOk;
        private System.Windows.Forms.Button m_btnAnnuler;
        private System.Windows.Forms.Panel m_panelBas;
        private System.Windows.Forms.Panel m_panelFormules;
        private sc2i.win32.common.CExtStyle cExtStyle1;
        private System.Windows.Forms.Splitter splitter1;
        private Panel m_panelDroite;
        private Label label1;
    }
}