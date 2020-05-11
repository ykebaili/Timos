using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using timos.data;
using sc2i.common;







namespace timos
{
    partial class CFormEditeurSymbolePopup
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditeurSymbolePopup));
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_btnAnnuler = new System.Windows.Forms.Button();
            this.m_panelEditeurSymbole = new timos.CPanelEditeurSymbole();
            this.m_linkAjusterFond = new System.Windows.Forms.LinkLabel();
            this.m_ctrlSavProfilDesigner = new timos.CCtrlSauvegardeProfilDesigner();
            this.SuspendLayout();
            // 
            // m_btnOk
            // 
            this.m_btnOk.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnOk.ForeColor = System.Drawing.Color.White;
            this.m_btnOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btnOk.Image")));
            this.m_btnOk.Location = new System.Drawing.Point(463, 617);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(40, 40);
            this.m_btnOk.TabIndex = 4014;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnAnnuler.ForeColor = System.Drawing.Color.White;
            this.m_btnAnnuler.Image = ((System.Drawing.Image)(resources.GetObject("m_btnAnnuler.Image")));
            this.m_btnAnnuler.Location = new System.Drawing.Point(521, 617);
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(40, 40);
            this.m_btnAnnuler.TabIndex = 4015;
            this.m_btnAnnuler.Click += new System.EventHandler(this.m_btnAnnuler_Click);
            // 
            // m_panelEditeurSymbole
            // 
            this.m_panelEditeurSymbole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelEditeurSymbole.Location = new System.Drawing.Point(2, 0);
            this.m_panelEditeurSymbole.Name = "m_panelEditeurSymbole";
            this.m_panelEditeurSymbole.Size = new System.Drawing.Size(990, 597);
            this.m_panelEditeurSymbole.SymboleEdite = null;
            this.m_panelEditeurSymbole.TabIndex = 4016;
            this.m_panelEditeurSymbole.TypeEdite = null;
            // 
            // m_linkAjusterFond
            // 
            this.m_linkAjusterFond.AutoSize = true;
            this.m_linkAjusterFond.Location = new System.Drawing.Point(43, 643);
            this.m_linkAjusterFond.Name = "m_linkAjusterFond";
            this.m_linkAjusterFond.Size = new System.Drawing.Size(117, 13);
            this.m_linkAjusterFond.TabIndex = 4017;
            this.m_linkAjusterFond.TabStop = true;
            this.m_linkAjusterFond.Text = "Adjust background size";
            this.m_linkAjusterFond.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_linkAjusterFond_LinkClicked);
            // 
            // m_ctrlSavProfilDesigner
            // 
            this.m_ctrlSavProfilDesigner.Designer = this.m_panelEditeurSymbole.Editeur;
            this.m_ctrlSavProfilDesigner.Formulaire = this;
            // 
            // CFormEditeurSymbolePopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(998, 691);
            this.Controls.Add(this.m_linkAjusterFond);
            this.Controls.Add(this.m_panelEditeurSymbole);
            this.Controls.Add(this.m_btnOk);
            this.Controls.Add(this.m_btnAnnuler);
            this.Name = "CFormEditeurSymbolePopup";
            this.Text = "Symbol Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_btnOk;
        private System.Windows.Forms.Button m_btnAnnuler;
        private CPanelEditeurSymbole m_panelEditeurSymbole;
        private LinkLabel m_linkAjusterFond;
        private CCtrlSauvegardeProfilDesigner m_ctrlSavProfilDesigner;
    }
}