using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using sc2i.common;
using sc2i.win32.common;
using sc2i.data;
using sc2i.data.serveur;
using sc2i.multitiers.client;
using sc2i.multitiers.server;

using timos.serveur;
using timos.data;
using timos.acteurs;


namespace TimosDataServeur
{
	partial class CFormServeurTimos
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
            sc2i.win32.common.CProfilEffetFondu cProfilEffetFondu1 = new sc2i.win32.common.CProfilEffetFondu();
            this.m_btnLancementServeur = new System.Windows.Forms.Button();
            this.m_rbtnSQLServeur = new System.Windows.Forms.RadioButton();
            this.m_rbtnOracle = new System.Windows.Forms.RadioButton();
            this.m_panChoixBase = new System.Windows.Forms.Panel();
            this.m_chkMAJ = new System.Windows.Forms.CheckBox();
            this.m_panProgress = new System.Windows.Forms.Panel();
            this.m_ctrlProgressBarHome = new TimosDataServeur.CtrlProgressBarDataBase();
            this.m_panEnd = new System.Windows.Forms.Panel();
            this.m_btnProxySync = new System.Windows.Forms.Button();
            this.m_lnkServiceMediation = new System.Windows.Forms.LinkLabel();
            this.m_btnCopierBase = new System.Windows.Forms.Button();
            this.m_btnLog = new System.Windows.Forms.Button();
            this.m_lblEtat = new System.Windows.Forms.Label();
            this.m_effetFondu = new sc2i.win32.common.CEffetFonduPourForm();
            this.m_panChoixBase.SuspendLayout();
            this.m_panProgress.SuspendLayout();
            this.m_panEnd.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnLancementServeur
            // 
            this.m_btnLancementServeur.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnLancementServeur.BackColor = System.Drawing.SystemColors.Desktop;
            this.m_btnLancementServeur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnLancementServeur.ForeColor = System.Drawing.Color.White;
            this.m_btnLancementServeur.Location = new System.Drawing.Point(295, 12);
            this.m_btnLancementServeur.Name = "m_btnLancementServeur";
            this.m_btnLancementServeur.Size = new System.Drawing.Size(196, 44);
            this.m_btnLancementServeur.TabIndex = 2;
            this.m_btnLancementServeur.Text = "Start TIMOS Server|30018";
            this.m_btnLancementServeur.UseVisualStyleBackColor = false;
            this.m_btnLancementServeur.Click += new System.EventHandler(this.m_btnLancementServeur_Click);
            // 
            // m_rbtnSQLServeur
            // 
            this.m_rbtnSQLServeur.AutoSize = true;
            this.m_rbtnSQLServeur.Checked = true;
            this.m_rbtnSQLServeur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rbtnSQLServeur.ForeColor = System.Drawing.SystemColors.Desktop;
            this.m_rbtnSQLServeur.Location = new System.Drawing.Point(26, 13);
            this.m_rbtnSQLServeur.Name = "m_rbtnSQLServeur";
            this.m_rbtnSQLServeur.Size = new System.Drawing.Size(79, 17);
            this.m_rbtnSQLServeur.TabIndex = 3;
            this.m_rbtnSQLServeur.TabStop = true;
            this.m_rbtnSQLServeur.Text = "SQL Server";
            this.m_rbtnSQLServeur.UseVisualStyleBackColor = true;
            // 
            // m_rbtnOracle
            // 
            this.m_rbtnOracle.AutoSize = true;
            this.m_rbtnOracle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_rbtnOracle.ForeColor = System.Drawing.SystemColors.Desktop;
            this.m_rbtnOracle.Location = new System.Drawing.Point(26, 36);
            this.m_rbtnOracle.Name = "m_rbtnOracle";
            this.m_rbtnOracle.Size = new System.Drawing.Size(55, 17);
            this.m_rbtnOracle.TabIndex = 3;
            this.m_rbtnOracle.Text = "Oracle";
            this.m_rbtnOracle.UseVisualStyleBackColor = true;
            // 
            // m_panChoixBase
            // 
            this.m_panChoixBase.Controls.Add(this.m_chkMAJ);
            this.m_panChoixBase.Controls.Add(this.m_rbtnSQLServeur);
            this.m_panChoixBase.Controls.Add(this.m_rbtnOracle);
            this.m_panChoixBase.Controls.Add(this.m_btnLancementServeur);
            this.m_panChoixBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panChoixBase.Location = new System.Drawing.Point(0, 0);
            this.m_panChoixBase.Name = "m_panChoixBase";
            this.m_panChoixBase.Size = new System.Drawing.Size(497, 100);
            this.m_panChoixBase.TabIndex = 4;
            // 
            // m_chkMAJ
            // 
            this.m_chkMAJ.AutoSize = true;
            this.m_chkMAJ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_chkMAJ.ForeColor = System.Drawing.SystemColors.Desktop;
            this.m_chkMAJ.Location = new System.Drawing.Point(133, 27);
            this.m_chkMAJ.Name = "m_chkMAJ";
            this.m_chkMAJ.Size = new System.Drawing.Size(120, 17);
            this.m_chkMAJ.TabIndex = 4;
            this.m_chkMAJ.Text = "Force Update|30017";
            this.m_chkMAJ.UseVisualStyleBackColor = true;
            // 
            // m_panProgress
            // 
            this.m_panProgress.Controls.Add(this.m_ctrlProgressBarHome);
            this.m_panProgress.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panProgress.Location = new System.Drawing.Point(0, 100);
            this.m_panProgress.Name = "m_panProgress";
            this.m_panProgress.Size = new System.Drawing.Size(497, 100);
            this.m_panProgress.TabIndex = 4;
            this.m_panProgress.Visible = false;
            // 
            // m_ctrlProgressBarHome
            // 
            this.m_ctrlProgressBarHome.CanCancel = true;
            this.m_ctrlProgressBarHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_ctrlProgressBarHome.EspacementBarres = 30;
            this.m_ctrlProgressBarHome.LargeurTitre = 150;
            this.m_ctrlProgressBarHome.Location = new System.Drawing.Point(0, 0);
            this.m_ctrlProgressBarHome.Name = "m_ctrlProgressBarHome";
            this.m_ctrlProgressBarHome.Size = new System.Drawing.Size(497, 23);
            this.m_ctrlProgressBarHome.TabIndex = 2;
            this.m_ctrlProgressBarHome.SizeChanged += new System.EventHandler(this.ctrl_progressBarHome_SizeChanged);
            // 
            // m_panEnd
            // 
            this.m_panEnd.Controls.Add(this.m_btnProxySync);
            this.m_panEnd.Controls.Add(this.m_lnkServiceMediation);
            this.m_panEnd.Controls.Add(this.m_btnCopierBase);
            this.m_panEnd.Controls.Add(this.m_btnLog);
            this.m_panEnd.Controls.Add(this.m_lblEtat);
            this.m_panEnd.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panEnd.Location = new System.Drawing.Point(0, 200);
            this.m_panEnd.Name = "m_panEnd";
            this.m_panEnd.Size = new System.Drawing.Size(497, 100);
            this.m_panEnd.TabIndex = 4;
            // 
            // m_btnProxySync
            // 
            this.m_btnProxySync.Location = new System.Drawing.Point(412, 42);
            this.m_btnProxySync.Name = "m_btnProxySync";
            this.m_btnProxySync.Size = new System.Drawing.Size(75, 23);
            this.m_btnProxySync.TabIndex = 6;
            this.m_btnProxySync.Text = "Proxy sync";
            this.m_btnProxySync.UseVisualStyleBackColor = true;
            this.m_btnProxySync.Click += new System.EventHandler(this.m_btnProxySync_Click);
            // 
            // m_lnkServiceMediation
            // 
            this.m_lnkServiceMediation.AutoSize = true;
            this.m_lnkServiceMediation.Location = new System.Drawing.Point(385, 26);
            this.m_lnkServiceMediation.Name = "m_lnkServiceMediation";
            this.m_lnkServiceMediation.Size = new System.Drawing.Size(106, 13);
            this.m_lnkServiceMediation.TabIndex = 5;
            this.m_lnkServiceMediation.TabStop = true;
            this.m_lnkServiceMediation.Text = "Service de médiation";
            this.m_lnkServiceMediation.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkServiceMediation_LinkClicked);
            // 
            // m_btnCopierBase
            // 
            this.m_btnCopierBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnCopierBase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnCopierBase.ForeColor = System.Drawing.SystemColors.Desktop;
            this.m_btnCopierBase.Location = new System.Drawing.Point(239, 42);
            this.m_btnCopierBase.Name = "m_btnCopierBase";
            this.m_btnCopierBase.Size = new System.Drawing.Size(143, 23);
            this.m_btnCopierBase.TabIndex = 3;
            this.m_btnCopierBase.Text = "Copy the Database|30019";
            this.m_btnCopierBase.UseVisualStyleBackColor = true;
            this.m_btnCopierBase.Visible = false;
            this.m_btnCopierBase.Click += new System.EventHandler(this.m_btnCopierBase_Click);
            // 
            // m_btnLog
            // 
            this.m_btnLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnLog.ForeColor = System.Drawing.SystemColors.Desktop;
            this.m_btnLog.Location = new System.Drawing.Point(348, 0);
            this.m_btnLog.Name = "m_btnLog";
            this.m_btnLog.Size = new System.Drawing.Size(143, 23);
            this.m_btnLog.TabIndex = 2;
            this.m_btnLog.Text = "Display Log|30020";
            this.m_btnLog.UseVisualStyleBackColor = true;
            this.m_btnLog.Click += new System.EventHandler(this.m_btnLog_Click);
            // 
            // m_lblEtat
            // 
            this.m_lblEtat.AutoSize = true;
            this.m_lblEtat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblEtat.ForeColor = System.Drawing.SystemColors.Desktop;
            this.m_lblEtat.Location = new System.Drawing.Point(12, 13);
            this.m_lblEtat.Name = "m_lblEtat";
            this.m_lblEtat.Size = new System.Drawing.Size(370, 24);
            this.m_lblEtat.TabIndex = 1;
            this.m_lblEtat.Text = "[ TIMOS SERVER IS RUNNING ]|30021";
            // 
            // m_effetFondu
            // 
            this.m_effetFondu.AuDessusDesAutresFenetres = true;
            this.m_effetFondu.EffetFonduFermeture = true;
            this.m_effetFondu.EffetFonduOuverture = true;
            this.m_effetFondu.Formulaire = this;
            this.m_effetFondu.IntervalImages = 15;
            cProfilEffetFondu1.EffetActif = true;
            cProfilEffetFondu1.EffetFermeture = true;
            cProfilEffetFondu1.EffetOuverture = true;
            cProfilEffetFondu1.IntervalImages = 15;
            cProfilEffetFondu1.NombreImages = 10;
            this.m_effetFondu.Profil = cProfilEffetFondu1;
            // 
            // CFormServeurTimos
            // 
            this.AcceptButton = this.m_btnLancementServeur;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(497, 303);
            this.Controls.Add(this.m_panEnd);
            this.Controls.Add(this.m_panProgress);
            this.Controls.Add(this.m_panChoixBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CFormServeurTimos";
            this.Opacity = 0;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Server Initialisation...|30016";
            this.Load += new System.EventHandler(this.CFormServeurTimos_Load);
            this.m_panChoixBase.ResumeLayout(false);
            this.m_panChoixBase.PerformLayout();
            this.m_panProgress.ResumeLayout(false);
            this.m_panEnd.ResumeLayout(false);
            this.m_panEnd.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button m_btnLancementServeur;
		private System.Windows.Forms.RadioButton m_rbtnSQLServeur;
		private System.Windows.Forms.RadioButton m_rbtnOracle;
		private System.Windows.Forms.Panel m_panChoixBase;
		private System.Windows.Forms.Panel m_panProgress;
		private System.Windows.Forms.Panel m_panEnd;
		private System.Windows.Forms.Label m_lblEtat;
        private System.Windows.Forms.CheckBox m_chkMAJ;
		private System.Windows.Forms.Button m_btnLog;
		private System.Windows.Forms.Button m_btnCopierBase;
		private CtrlProgressBarDataBase m_ctrlProgressBarHome;
		private sc2i.win32.common.CEffetFonduPourForm m_effetFondu;
        private LinkLabel m_lnkServiceMediation;
        private Button m_btnProxySync;

	}
}