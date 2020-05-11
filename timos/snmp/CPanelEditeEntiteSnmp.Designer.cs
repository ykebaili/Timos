using sc2i.win32.common;
using System.Windows.Forms;
using System.Drawing;
using sc2i.win32.data.navigation;
using sc2i.win32.data.dynamic;
namespace timos.snmp
{
    partial class CPanelEditeEntiteSnmp
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
            this.m_panelElementSupervise = new sc2i.win32.common.C2iPanel(this.components);
            this.m_selectElementSupervise = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_lblElementSupervise = new System.Windows.Forms.Label();
            this.m_panelChamps = new sc2i.win32.data.dynamic.CPanelChampsCustom();
            this.m_menuTypeElementAssocie = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_menuAssocieToSite = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuAssocieToEquipement = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuAssocieToLien = new System.Windows.Forms.ToolStripMenuItem();
            this.m_panelElementSupervise.SuspendLayout();
            this.m_menuTypeElementAssocie.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelElementSupervise
            // 
            this.m_panelElementSupervise.Controls.Add(this.m_selectElementSupervise);
            this.m_panelElementSupervise.Controls.Add(this.m_lblElementSupervise);
            this.m_panelElementSupervise.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelElementSupervise.Location = new System.Drawing.Point(0, 18);
            this.m_panelElementSupervise.LockEdition = false;
            this.m_panelElementSupervise.Name = "m_panelElementSupervise";
            this.m_panelElementSupervise.Size = new System.Drawing.Size(466, 22);
            this.m_panelElementSupervise.TabIndex = 1;
            // 
            // m_selectElementSupervise
            // 
            this.m_selectElementSupervise.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_selectElementSupervise.ElementSelectionne = null;
            this.m_selectElementSupervise.FonctionTextNull = null;
            this.m_selectElementSupervise.HasLink = true;
            this.m_selectElementSupervise.Location = new System.Drawing.Point(177, 0);
            this.m_selectElementSupervise.LockEdition = false;
            this.m_selectElementSupervise.Name = "m_selectElementSupervise";
            this.m_selectElementSupervise.SelectedObject = null;
            this.m_selectElementSupervise.Size = new System.Drawing.Size(270, 22);
            this.m_selectElementSupervise.TabIndex = 1;
            this.m_selectElementSupervise.TextNull = "";
            // 
            // m_lblElementSupervise
            // 
            this.m_lblElementSupervise.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lblElementSupervise.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lblElementSupervise.Location = new System.Drawing.Point(0, 0);
            this.m_lblElementSupervise.Name = "m_lblElementSupervise";
            this.m_lblElementSupervise.Size = new System.Drawing.Size(177, 22);
            this.m_lblElementSupervise.TabIndex = 0;
            this.m_lblElementSupervise.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblElementSupervise.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_lblElementSupervise_MouseDown);
            // 
            // m_panelChamps
            // 
            this.m_panelChamps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(184)))));
            this.m_panelChamps.BoldSelectedPage = true;
            this.m_panelChamps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelChamps.ElementEdite = null;
            this.m_panelChamps.IDEPixelArea = false;
            this.m_panelChamps.Location = new System.Drawing.Point(0, 40);
            this.m_panelChamps.LockEdition = false;
            this.m_panelChamps.Name = "m_panelChamps";
            this.m_panelChamps.Ombre = false;
            this.m_panelChamps.PositionTop = true;
            this.m_panelChamps.Size = new System.Drawing.Size(466, 275);
            this.m_panelChamps.TabIndex = 2;
            // 
            // m_menuTypeElementAssocie
            // 
            this.m_menuTypeElementAssocie.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_menuAssocieToSite,
            this.m_menuAssocieToEquipement,
            this.m_menuAssocieToLien});
            this.m_menuTypeElementAssocie.Name = "m_menuTypeElementAssocie";
            this.m_menuTypeElementAssocie.Size = new System.Drawing.Size(205, 92);
            // 
            // m_menuAssocieToSite
            // 
            this.m_menuAssocieToSite.Name = "m_menuAssocieToSite";
            this.m_menuAssocieToSite.Size = new System.Drawing.Size(204, 22);
            this.m_menuAssocieToSite.Text = "Site|20465";
            this.m_menuAssocieToSite.Click += new System.EventHandler(this.m_menuAssocieToSite_Click);
            // 
            // m_menuAssocieToEquipement
            // 
            this.m_menuAssocieToEquipement.Name = "m_menuAssocieToEquipement";
            this.m_menuAssocieToEquipement.Size = new System.Drawing.Size(204, 22);
            this.m_menuAssocieToEquipement.Text = "Logical equipment|20466";
            this.m_menuAssocieToEquipement.Click += new System.EventHandler(this.m_menuAssocieToEquipement_Click);
            // 
            // m_menuAssocieToLien
            // 
            this.m_menuAssocieToLien.Name = "m_menuAssocieToLien";
            this.m_menuAssocieToLien.Size = new System.Drawing.Size(204, 22);
            this.m_menuAssocieToLien.Text = "Network link|20467";
            this.m_menuAssocieToLien.Click += new System.EventHandler(this.m_menuAssocieToLien_Click);
            // 
            // CPanelEditeEntiteSnmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_panelChamps);
            this.Controls.Add(this.m_panelElementSupervise);
            this.Name = "CPanelEditeEntiteSnmp";
            this.Size = new System.Drawing.Size(466, 315);
            this.OnCollapseChange += new System.EventHandler(this.CPanelEditeEntiteSnmp_OnCollapseChange);
            this.Controls.SetChildIndex(this.m_panelElementSupervise, 0);
            this.Controls.SetChildIndex(this.m_panelChamps, 0);
            this.m_panelElementSupervise.ResumeLayout(false);
            this.m_menuTypeElementAssocie.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ContextMenuStrip m_menuTypeElementAssocie;
        private ToolStripMenuItem m_menuAssocieToSite;
        private ToolStripMenuItem m_menuAssocieToEquipement;
        private ToolStripMenuItem m_menuAssocieToLien;

    }
}
