using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using sc2i.common;

namespace timos
{
	public partial class CFormWaiting : Form
	{

        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Timer m_timerWaiting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label m_lblTitre;
        private System.Windows.Forms.Timer m_timerDotDotDot;
        private System.Windows.Forms.Label m_lblDotDotDot;
        private System.Windows.Forms.Panel m_panSablier;
        private sc2i.win32.common.CEffetFonduPourForm m_effetFondu;

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
            this.components = new System.ComponentModel.Container();
            sc2i.win32.common.CProfilEffetFondu cProfilEffetFondu1 = new sc2i.win32.common.CProfilEffetFondu();
            this.m_timerWaiting = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.m_lblTitre = new System.Windows.Forms.Label();
            this.m_timerDotDotDot = new System.Windows.Forms.Timer(this.components);
            this.m_lblDotDotDot = new System.Windows.Forms.Label();
            this.m_panSablier = new System.Windows.Forms.Panel();
            this.m_effetFondu = new sc2i.win32.common.CEffetFonduPourForm();
            this.SuspendLayout();
            // 
            // m_timerWaiting
            // 
            this.m_timerWaiting.Interval = 1000;
            this.m_timerWaiting.Tick += new System.EventHandler(this.m_timerWaiting_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(245, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label 1|30178";
            this.label1.Visible = false;
            // 
            // m_lblTitre
            // 
            this.m_lblTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblTitre.Location = new System.Drawing.Point(64, 23);
            this.m_lblTitre.Name = "m_lblTitre";
            this.m_lblTitre.Size = new System.Drawing.Size(171, 20);
            this.m_lblTitre.TabIndex = 0;
            this.m_lblTitre.Text = "Please wait|30177";
            this.m_lblTitre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_timerDotDotDot
            // 
            this.m_timerDotDotDot.Tick += new System.EventHandler(this.m_timerDotDotDot_Tick);
            // 
            // m_lblDotDotDot
            // 
            this.m_lblDotDotDot.AutoSize = true;
            this.m_lblDotDotDot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblDotDotDot.Location = new System.Drawing.Point(241, 23);
            this.m_lblDotDotDot.Name = "m_lblDotDotDot";
            this.m_lblDotDotDot.Size = new System.Drawing.Size(0, 20);
            this.m_lblDotDotDot.TabIndex = 0;
            // 
            // m_panSablier
            // 
            this.m_panSablier.BackgroundImage = global::timos.Properties.Resources.Sablier;
            this.m_panSablier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_panSablier.Location = new System.Drawing.Point(18, 18);
            this.m_panSablier.Name = "m_panSablier";
            this.m_panSablier.Size = new System.Drawing.Size(35, 32);
            this.m_panSablier.TabIndex = 1;
            // 
            // m_effetFondu
            // 
            this.m_effetFondu.AuDessusDesAutresFenetres = true;
            this.m_effetFondu.EffetFonduFermeture = true;
            this.m_effetFondu.EffetFonduOuverture = true;
            this.m_effetFondu.Formulaire = this;
            this.m_effetFondu.IntervalImages = 2;
            cProfilEffetFondu1.EffetActif = true;
            cProfilEffetFondu1.EffetFermeture = true;
            cProfilEffetFondu1.EffetOuverture = true;
            cProfilEffetFondu1.IntervalImages = 2;
            cProfilEffetFondu1.NombreImages = 10;
            this.m_effetFondu.Profil = cProfilEffetFondu1;
            // 
            // CFormWaiting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(331, 72);
            this.ControlBox = false;
            this.Controls.Add(this.m_panSablier);
            this.Controls.Add(this.m_lblDotDotDot);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_lblTitre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CFormWaiting";
            this.Opacity = 0;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.CFormWaiting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        
        //public static void Go(int nTick)
		//{
		//    CFormWaiting frm = new CFormWaiting(nTick);
		//    frm.ShowDialog();
		//}

		public CFormWaiting(int nTicks)
		{
			InitializeComponent();
			m_timerTickMax = nTicks;

		}
		public CFormWaiting()
		{
			InitializeComponent();
		}

		private int m_timerTickMax = 0;
		private int m_timerTick = 0;
		private void m_timerWaiting_Tick(object sender, EventArgs e)
		{
			if (m_timerTick >= m_timerTickMax)
			{
				m_timerTick = 0;
				m_timerWaiting.Stop();
				Close();
			}
			else
			{
				label1.Text = (m_timerTickMax - m_timerTick).ToString() + "s...";
				m_timerTick++;
			}
		}

		private void CFormWaiting_Load(object sender, EventArgs e)
		{

            sc2i.win32.common.CWin32Traducteur.Translate(this);
			//m_timerWaiting.Start();
			m_timerDotDotDot.Start();
		}

		private int m_nDotDotDot = 0;
		private void m_timerDotDotDot_Tick(object sender, EventArgs e)
		{
			if (m_nDotDotDot == 0)
				m_lblDotDotDot.Text = "";
			else if (m_nDotDotDot == 1)
				m_lblDotDotDot.Text = ".";
			else if (m_nDotDotDot == 2)
				m_lblDotDotDot.Text = "..";
			else if (m_nDotDotDot == 3)
				m_lblDotDotDot.Text = "...";

			m_nDotDotDot++;
			if (m_nDotDotDot == 4)
				m_nDotDotDot = 0;
		}

	}
}