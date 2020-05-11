using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using sc2i.common;
using sc2i.workflow;
using sc2i.win32.common;
using sc2i.multitiers.client;

namespace timos
{
	/// <summary>
	/// Description résumée de CWndPostit.
	/// </summary>
	public class CWndPostit : System.Windows.Forms.UserControl, I2iSerializable, IControlALockEdition
	{
		private bool m_bCanEdit = false;
		private bool m_bVisible = true;
		private CPostIt m_postIt = null;
		private System.Windows.Forms.Panel m_cadre;
		private System.Windows.Forms.Panel m_panelTitre;
		private sc2i.win32.common.C2iTextBox m_txtTitre;
		private sc2i.win32.common.C2iTextBox m_txtTexte;
		private sc2i.win32.common.C2iPanel m_panelBas;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label m_lblAuteur;
        private System.Windows.Forms.Label label2;
		private sc2i.win32.common.CExtModeEdition m_extModeEdition;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox m_btnFermer;
		private System.Windows.Forms.PictureBox m_btnResize;
		private System.Windows.Forms.PictureBox m_btnMove;
		private System.Windows.Forms.PictureBox m_btnEditer;
		private System.Windows.Forms.PictureBox m_btnValider;
		private System.Windows.Forms.Panel m_panelValidation;
		private System.Windows.Forms.PictureBox m_btnAnnuler;
		private System.Windows.Forms.PictureBox m_btnPoubelle;
		private System.Windows.Forms.CheckBox m_chkPublic;
        protected CExtStyle m_extStyle;
        private C2iDateTimeExPicker m_dtExpiration;
		private System.ComponentModel.IContainer components;

		public CWndPostit()
		{
			// Cet appel est requis par le Concepteur de formulaires Windows.Forms.
			InitializeComponent();
            m_dtExpiration.Checked = false;
            CWin32Traducteur.Translate(this);

			// TODO : ajoutez les initialisations après l'appel à InitializeComponent

		}

		/// <summary> 
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Code généré par le Concepteur de composants
		/// <summary> 
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CWndPostit));
            this.m_cadre = new System.Windows.Forms.Panel();
            this.m_btnMove = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.m_panelBas = new sc2i.win32.common.C2iPanel(this.components);
            this.m_chkPublic = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_lblAuteur = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtTexte = new sc2i.win32.common.C2iTextBox();
            this.m_panelTitre = new System.Windows.Forms.Panel();
            this.m_panelValidation = new System.Windows.Forms.Panel();
            this.m_btnAnnuler = new System.Windows.Forms.PictureBox();
            this.m_btnValider = new System.Windows.Forms.PictureBox();
            this.m_btnEditer = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.m_txtTitre = new sc2i.win32.common.C2iTextBox();
            this.m_btnFermer = new System.Windows.Forms.PictureBox();
            this.m_btnPoubelle = new System.Windows.Forms.PictureBox();
            this.m_btnResize = new System.Windows.Forms.PictureBox();
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.m_dtExpiration = new sc2i.win32.common.C2iDateTimeExPicker();
            this.m_cadre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.m_panelBas.SuspendLayout();
            this.m_panelTitre.SuspendLayout();
            this.m_panelValidation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnAnnuler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnValider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnEditer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnFermer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnPoubelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnResize)).BeginInit();
            this.SuspendLayout();
            // 
            // m_cadre
            // 
            this.m_cadre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_cadre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_cadre.Controls.Add(this.m_btnMove);
            this.m_cadre.Controls.Add(this.pictureBox1);
            this.m_cadre.Controls.Add(this.m_panelBas);
            this.m_cadre.Controls.Add(this.m_txtTexte);
            this.m_cadre.Controls.Add(this.m_panelTitre);
            this.m_cadre.Controls.Add(this.m_btnResize);
            this.m_cadre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_cadre.ForeColor = System.Drawing.Color.Black;
            this.m_cadre.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_cadre, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_cadre.Name = "m_cadre";
            this.m_cadre.Size = new System.Drawing.Size(360, 336);
            this.m_extStyle.SetStyleBackColor(this.m_cadre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cadre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cadre.TabIndex = 1;
            // 
            // m_btnMove
            // 
            this.m_btnMove.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.m_btnMove.Image = ((System.Drawing.Image)(resources.GetObject("m_btnMove.Image")));
            this.m_btnMove.Location = new System.Drawing.Point(4, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnMove, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnMove.Name = "m_btnMove";
            this.m_btnMove.Size = new System.Drawing.Size(20, 24);
            this.m_btnMove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_extStyle.SetStyleBackColor(this.m_btnMove, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnMove, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnMove.TabIndex = 6;
            this.m_btnMove.TabStop = false;
            this.m_btnMove.MouseMove += new System.Windows.Forms.MouseEventHandler(this.m_btnMove_MouseMove);
            this.m_btnMove.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_btnMove_MouseDown);
            this.m_btnMove.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_btnMove_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(102)))));
            this.pictureBox1.Location = new System.Drawing.Point(4, 292);
            this.m_extModeEdition.SetModeEdition(this.pictureBox1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(348, 1);
            this.m_extStyle.SetStyleBackColor(this.pictureBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pictureBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // m_panelBas
            // 
            this.m_panelBas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelBas.Controls.Add(this.m_dtExpiration);
            this.m_panelBas.Controls.Add(this.m_chkPublic);
            this.m_panelBas.Controls.Add(this.label2);
            this.m_panelBas.Controls.Add(this.m_lblAuteur);
            this.m_panelBas.Controls.Add(this.label1);
            this.m_panelBas.Location = new System.Drawing.Point(0, 294);
            this.m_panelBas.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_panelBas, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelBas.Name = "m_panelBas";
            this.m_panelBas.Size = new System.Drawing.Size(340, 40);
            this.m_extStyle.SetStyleBackColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelBas.TabIndex = 4;
            // 
            // m_chkPublic
            // 
            this.m_chkPublic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_chkPublic.Location = new System.Drawing.Point(192, 24);
            this.m_extModeEdition.SetModeEdition(this.m_chkPublic, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkPublic.Name = "m_chkPublic";
            this.m_chkPublic.Size = new System.Drawing.Size(145, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkPublic, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkPublic, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkPublic.TabIndex = 5;
            this.m_chkPublic.Checked = true;
            this.m_chkPublic.Text = "Public Note|829";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 20);
            this.m_extModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 18);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 2;
            this.label2.Text = "Expiration|826";
            // 
            // m_lblAuteur
            // 
            this.m_lblAuteur.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblAuteur.Location = new System.Drawing.Point(76, 4);
            this.m_extModeEdition.SetModeEdition(this.m_lblAuteur, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblAuteur.Name = "m_lblAuteur";
            this.m_lblAuteur.Size = new System.Drawing.Size(254, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lblAuteur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblAuteur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblAuteur.TabIndex = 1;
            this.m_lblAuteur.Text = "User name|30117";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.m_extModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 0;
            this.label1.Text = "User: |245";
            // 
            // m_txtTexte
            // 
            this.m_txtTexte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtTexte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.m_txtTexte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtTexte.ForeColor = System.Drawing.Color.Black;
            this.m_txtTexte.Location = new System.Drawing.Point(4, 24);
            this.m_txtTexte.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtTexte, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtTexte.Multiline = true;
            this.m_txtTexte.Name = "m_txtTexte";
            this.m_txtTexte.Size = new System.Drawing.Size(352, 264);
            this.m_extStyle.SetStyleBackColor(this.m_txtTexte, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtTexte, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtTexte.TabIndex = 3;
            this.m_txtTexte.Text = "Enter Note text here|825";
            this.m_txtTexte.TextChanged += new System.EventHandler(this.m_txtTexte_TextChanged);
            this.m_txtTexte.Validated += new System.EventHandler(this.m_txtTexte_Validated);
            // 
            // m_panelTitre
            // 
            this.m_panelTitre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelTitre.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_panelTitre.Controls.Add(this.m_panelValidation);
            this.m_panelTitre.Controls.Add(this.m_btnEditer);
            this.m_panelTitre.Controls.Add(this.pictureBox2);
            this.m_panelTitre.Controls.Add(this.m_txtTitre);
            this.m_panelTitre.Controls.Add(this.m_btnFermer);
            this.m_panelTitre.Controls.Add(this.m_btnPoubelle);
            this.m_panelTitre.Location = new System.Drawing.Point(24, 2);
            this.m_extModeEdition.SetModeEdition(this.m_panelTitre, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelTitre.Name = "m_panelTitre";
            this.m_panelTitre.Size = new System.Drawing.Size(332, 20);
            this.m_extStyle.SetStyleBackColor(this.m_panelTitre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelTitre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelTitre.TabIndex = 2;
            // 
            // m_panelValidation
            // 
            this.m_panelValidation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelValidation.Controls.Add(this.m_btnAnnuler);
            this.m_panelValidation.Controls.Add(this.m_btnValider);
            this.m_panelValidation.Location = new System.Drawing.Point(278, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelValidation, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelValidation.Name = "m_panelValidation";
            this.m_panelValidation.Size = new System.Drawing.Size(40, 20);
            this.m_extStyle.SetStyleBackColor(this.m_panelValidation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelValidation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelValidation.TabIndex = 8;
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnAnnuler.Image = ((System.Drawing.Image)(resources.GetObject("m_btnAnnuler.Image")));
            this.m_btnAnnuler.Location = new System.Drawing.Point(20, 2);
            this.m_extModeEdition.SetModeEdition(this.m_btnAnnuler, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(16, 16);
            this.m_btnAnnuler.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.m_extStyle.SetStyleBackColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAnnuler.TabIndex = 6;
            this.m_btnAnnuler.TabStop = false;
            this.m_btnAnnuler.Click += new System.EventHandler(this.m_btnAnnuler_Click);
            // 
            // m_btnValider
            // 
            this.m_btnValider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnValider.Image = ((System.Drawing.Image)(resources.GetObject("m_btnValider.Image")));
            this.m_btnValider.Location = new System.Drawing.Point(4, 2);
            this.m_extModeEdition.SetModeEdition(this.m_btnValider, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnValider.Name = "m_btnValider";
            this.m_btnValider.Size = new System.Drawing.Size(16, 16);
            this.m_btnValider.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.m_extStyle.SetStyleBackColor(this.m_btnValider, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnValider, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnValider.TabIndex = 5;
            this.m_btnValider.TabStop = false;
            this.m_btnValider.Click += new System.EventHandler(this.m_btnValider_Click);
            // 
            // m_btnEditer
            // 
            this.m_btnEditer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnEditer.Image = ((System.Drawing.Image)(resources.GetObject("m_btnEditer.Image")));
            this.m_btnEditer.Location = new System.Drawing.Point(281, 4);
            this.m_extModeEdition.SetModeEdition(this.m_btnEditer, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnEditer.Name = "m_btnEditer";
            this.m_btnEditer.Size = new System.Drawing.Size(16, 16);
            this.m_extStyle.SetStyleBackColor(this.m_btnEditer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnEditer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnEditer.TabIndex = 7;
            this.m_btnEditer.TabStop = false;
            this.m_btnEditer.Click += new System.EventHandler(this.m_btnEditer_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(184)))));
            this.pictureBox2.Location = new System.Drawing.Point(276, 0);
            this.m_extModeEdition.SetModeEdition(this.pictureBox2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(2, 32);
            this.m_extStyle.SetStyleBackColor(this.pictureBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pictureBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // m_txtTitre
            // 
            this.m_txtTitre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtTitre.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_txtTitre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtTitre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.m_txtTitre.Location = new System.Drawing.Point(4, 4);
            this.m_txtTitre.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtTitre, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtTitre.Name = "m_txtTitre";
            this.m_txtTitre.Size = new System.Drawing.Size(268, 13);
            this.m_extStyle.SetStyleBackColor(this.m_txtTitre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtTitre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtTitre.TabIndex = 3;
            this.m_txtTitre.Text = "Title|824";
            this.m_txtTitre.Validated += new System.EventHandler(this.m_txtTitre_Validated);
            // 
            // m_btnFermer
            // 
            this.m_btnFermer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnFermer.Image = ((System.Drawing.Image)(resources.GetObject("m_btnFermer.Image")));
            this.m_btnFermer.Location = new System.Drawing.Point(316, 4);
            this.m_extModeEdition.SetModeEdition(this.m_btnFermer, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnFermer.Name = "m_btnFermer";
            this.m_btnFermer.Size = new System.Drawing.Size(14, 14);
            this.m_btnFermer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.m_extStyle.SetStyleBackColor(this.m_btnFermer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnFermer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnFermer.TabIndex = 4;
            this.m_btnFermer.TabStop = false;
            this.m_btnFermer.Click += new System.EventHandler(this.m_btnFermer_Click);
            // 
            // m_btnPoubelle
            // 
            this.m_btnPoubelle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnPoubelle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_btnPoubelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnPoubelle.Image = ((System.Drawing.Image)(resources.GetObject("m_btnPoubelle.Image")));
            this.m_btnPoubelle.Location = new System.Drawing.Point(297, 2);
            this.m_extModeEdition.SetModeEdition(this.m_btnPoubelle, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_btnPoubelle.Name = "m_btnPoubelle";
            this.m_btnPoubelle.Size = new System.Drawing.Size(16, 16);
            this.m_btnPoubelle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.m_extStyle.SetStyleBackColor(this.m_btnPoubelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnPoubelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnPoubelle.TabIndex = 4;
            this.m_btnPoubelle.TabStop = false;
            this.m_btnPoubelle.Click += new System.EventHandler(this.m_btnPoubelle_Click);
            // 
            // m_btnResize
            // 
            this.m_btnResize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnResize.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.m_btnResize.Image = ((System.Drawing.Image)(resources.GetObject("m_btnResize.Image")));
            this.m_btnResize.Location = new System.Drawing.Point(344, 320);
            this.m_extModeEdition.SetModeEdition(this.m_btnResize, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnResize.Name = "m_btnResize";
            this.m_btnResize.Size = new System.Drawing.Size(12, 12);
            this.m_btnResize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.m_extStyle.SetStyleBackColor(this.m_btnResize, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnResize, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnResize.TabIndex = 4;
            this.m_btnResize.TabStop = false;
            this.m_btnResize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.m_btnResize_MouseMove);
            this.m_btnResize.Click += new System.EventHandler(this.m_btnResize_Click);
            this.m_btnResize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_btnResize_MouseDown);
            this.m_btnResize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_btnResize_MouseUp);
            // 
            // m_extModeEdition
            // 
            this.m_extModeEdition.ModeEdition = true;
            // 
            // m_dtExpiration
            // 
            this.m_dtExpiration.Checked = true;
            this.m_dtExpiration.CustomFormat = null;
            this.m_dtExpiration.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.m_dtExpiration.Location = new System.Drawing.Point(76, 18);
            this.m_dtExpiration.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_dtExpiration, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_dtExpiration.Name = "m_dtExpiration";
            this.m_dtExpiration.Size = new System.Drawing.Size(102, 20);
            this.m_extStyle.SetStyleBackColor(this.m_dtExpiration, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_dtExpiration, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_dtExpiration.TabIndex = 7;
            this.m_dtExpiration.TextNull = "";
            this.m_dtExpiration.Value.DateTimeValue = new System.DateTime(2010, 10, 14, 8, 54, 22, 421);
            // 
            // CWndPostit
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(204)))));
            this.Controls.Add(this.m_cadre);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CWndPostit";
            this.Size = new System.Drawing.Size(360, 336);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Resize += new System.EventHandler(this.CWndPostit_Resize);
            this.Move += new System.EventHandler(this.CWndPostit_Move);
            this.m_cadre.ResumeLayout(false);
            this.m_cadre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.m_panelBas.ResumeLayout(false);
            this.m_panelTitre.ResumeLayout(false);
            this.m_panelTitre.PerformLayout();
            this.m_panelValidation.ResumeLayout(false);
            this.m_panelValidation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnAnnuler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnValider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnEditer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnFermer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnPoubelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnResize)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// ///////////////////////////////////////////////////////
		public CPostIt PostIt
		{
			get
			{
				return m_postIt;
			}
		}

		/// ///////////////////////////////////////////////////////
		public event EventHandler OnClose;
		private void m_btnFermer_Click(object sender, System.EventArgs e)
		{
			AssureSauvegarde();
			m_bVisible = false;
			SaveIntoRegistre();
			if ( OnClose != null )
				OnClose( this, new EventArgs());
			Close();
			Dispose();
		}

		#region GEstion du redimensionnement
		/// <summary>
		/// 
		/// </summary>
		private bool m_bIsResizing = false;
		private Point m_offsetPointResize = new Point(0,0);
		private void m_btnResize_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			m_bIsResizing = true;
			Point pt = new Point ( e.X, e.Y );
			pt = m_btnResize.PointToScreen ( pt );
			if ( Parent != null )
				pt = Parent.PointToClient ( pt );
			m_offsetPointResize =  new Point ( this.Left - pt.X + Size.Width, this.Top - pt.Y + Size.Height );
			m_btnResize.Capture = true;

		}

		private void m_btnResize_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			m_bIsResizing = false;
			m_btnResize.Capture = false;
			SaveIntoRegistre();
		}

		private void m_btnResize_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if ( m_bIsResizing )
			{
				Point pt = new Point ( e.X, e.Y );
				pt = m_btnResize.PointToScreen(pt);
				if ( Parent != null )
					pt = Parent.PointToClient ( pt );
				Size sz = new Size ( 
					pt.X - this.Left + m_offsetPointResize.X,
					pt.Y - this.Top + m_offsetPointResize.Y );
				sz.Width = Math.Max ( sz.Width, 35 );
				sz.Height = Math.Max ( sz.Height, m_panelTitre.Bottom );
				Size = sz;
			}
				
		}
		#endregion

		#region GestionDuDéplacement
		private bool m_bIsMoving = false;
		private Point m_offsetPointMove = new Point(0,0);
		private void m_btnMove_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			m_bIsMoving = true;
			Point pt = new Point ( e.X, e.Y );
			pt = m_btnMove.PointToScreen ( pt );
			m_offsetPointMove =  new Point ( pt.X - this.Left, pt.Y - this.Top );
			m_btnMove.Capture = true;
		}

		private void m_btnMove_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if ( m_bIsMoving )
			{
				Point pt = new Point ( e.X, e.Y );
				pt = m_btnMove.PointToScreen(pt);
				Left = pt.X - m_offsetPointMove.X;
				Top = pt.Y - m_offsetPointMove.Y;
			}
		}

		private void m_btnMove_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			m_bIsMoving = false;
			m_btnMove.Capture = false;
			SaveIntoRegistre();
		}
		#endregion

		/// <summary>
		/// ///////////////////////////////////////////////////////
		/// </summary>
		/// <returns></returns>
		private int GetNumVersion()
		{
			return 0;
		}

		/// ///////////////////////////////////////////////////////
		//Sauvegarde dans le registre de la postition, visibilité et taille
		public CResultAErreur Serialize ( C2iSerializer serializer )
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
			if ( ! result )
				return result;
			serializer.TraiteBool ( ref m_bVisible );

			int nTmp = Left;
			serializer.TraiteInt ( ref nTmp );
			Left = nTmp;

			nTmp = Top;
			serializer.TraiteInt ( ref nTmp );
			Top = nTmp;

			nTmp = Width;
			serializer.TraiteInt ( ref nTmp );
			Width = nTmp;

			nTmp = Height;
			serializer.TraiteInt ( ref nTmp );
			Height = nTmp;

			return result;
		}

		/// ///////////////////////////////////////////////////////
		private void ReadFromRegistre()
		{
			if ( m_postIt == null || m_postIt.IsNew())
				return;
			string strData = new CTimosAppRegistre().GetDataPostit ( m_postIt.Id );
			try
			{
				CStringSerializer serializer = new CStringSerializer(strData, ModeSerialisation.Lecture );
				Serialize ( serializer );
			}
			catch
			{
			}
		}

		/// ///////////////////////////////////////////////////////
		private void SaveIntoRegistre()
		{
			if ( m_postIt == null || m_postIt.IsNew() )
				return;
			CStringSerializer serializer = new CStringSerializer( ModeSerialisation.Ecriture );
			if ( Serialize ( serializer ) )
				new CTimosAppRegistre().SetDataPostit ( m_postIt.Id, serializer.String );
		}

		/// ///////////////////////////////////////////////////////
		public static void ShowPostIt ( Control parent, CPostIt postIt, bool bForceDraw )
		{
			CWndPostit wndPostIt = new CWndPostit();
			wndPostIt.Left = 0;
			wndPostIt.Top = 0;
			wndPostIt.Width = 270;
			wndPostIt.Height = 230;
			wndPostIt.Parent = parent;
			wndPostIt.LockEdition = true;
			wndPostIt.CreateControl();
			wndPostIt.Show();
			wndPostIt.m_postIt = postIt;
			wndPostIt.Left = parent.ClientRectangle.Width/2 - wndPostIt.Width/2;
			wndPostIt.Top = parent.ClientRectangle.Height/2 - wndPostIt.Height/2;
			parent.SizeChanged += new EventHandler(wndPostIt.OnParentSizeChanged);
			if ( postIt.IsNew() )
			{
				wndPostIt.LockEdition = false;
				wndPostIt.m_bCanEdit = true;
			}
			else
			{
				wndPostIt.LockEdition = true;
				wndPostIt.m_bCanEdit = false;
				try
				{
					if ( postIt.IsPublique )
						wndPostIt.m_bCanEdit = true;
					CSessionClient session = CTimosApp.SessionClient;
                    //TESTDBKEYOK
					if ( session.GetInfoUtilisateur().KeyUtilisateur == postIt.Auteur.DbKey )
					{
						wndPostIt.m_bCanEdit = true;
					}
				}
				catch
				{
				}
			}
			wndPostIt.ReadFromRegistre();
			if ( !wndPostIt.m_bVisible && !bForceDraw)
			{
				wndPostIt.Visible = false;
				wndPostIt.Close();
			}
			else
			{
				wndPostIt.FillDialogWithObjet();
				wndPostIt.BringToFront();
				wndPostIt.Visible = true;
				wndPostIt.m_bVisible = true;
				wndPostIt.SaveIntoRegistre();
				wndPostIt.UpdateVisibiliteBouton();
			}
			
			
			
		}

		/// ///////////////////////////////////////////////////////
		private void OnParentSizeChanged( object sender, EventArgs args )
		{
			ReadFromRegistre();
			AssureBounds();
		}

		/// ///////////////////////////////////////////////////////
		private void m_txtTitre_Validated(object sender, System.EventArgs e)
		{
			if (!LockEdition )
				m_postIt.Titre = m_txtTexte.Text;
		}

		/// ///////////////////////////////////////////////////////
		public void AssureSauvegarde()
		{
			if ( !LockEdition && m_postIt.Row.RowState!= DataRowState.Detached && m_postIt.Row.RowState != DataRowState.Deleted )
			{
				FillObjetWithDialog();
				if ( m_postIt.Row.RowState == DataRowState.Modified || m_postIt.Row.RowState == DataRowState.Added )
				{
					if ( CFormAlerte.Afficher("Sauvegarder les modifications dans la note '"+m_postIt.Titre+"'",
						EFormAlerteType.Question ) == DialogResult.Yes )
						m_postIt.CommitEdit();
				}
			}
		}

		/// ///////////////////////////////////////////////////////
		private void m_txtTexte_Validated(object sender, System.EventArgs e)
		{
			if ( !LockEdition )
				m_postIt.Texte = m_txtTexte.Text;
		}

		private void m_dtExpiration_Validated(object sender, System.EventArgs e)
		{
			if ( !LockEdition )
				m_postIt.Texte = m_txtTexte.Text;
		}

		/// ///////////////////////////////////////////////////////
		private void m_btnEditer_Click(object sender, System.EventArgs e)
		{
			if ( LockEdition )
			{
				LockEdition = false;
				m_postIt.BeginEdit();
			}
		}

		/// ///////////////////////////////////////////////////////
		private void m_btnAnnuler_Click(object sender, System.EventArgs e)
		{
			if ( !LockEdition )
			{
				if ( m_postIt.IsNew() )
				{
					m_postIt.CancelCreate();
					Close();
				}
				else
				{
					m_postIt.CancelEdit();
					FillDialogWithObjet();
					LockEdition = true;
				}
			}
		}

		/// ///////////////////////////////////////////////////////
		

		/// ///////////////////////////////////////////////////////
		private void FillDialogWithObjet()
		{
			m_txtTexte.Text = m_postIt.Texte;
			m_txtTitre.Text = m_postIt.Titre;
            if(m_postIt.Auteur != null)
			    m_lblAuteur.Text = m_postIt.Auteur.Acteur.Nom;
			m_dtExpiration.Value = m_postIt.DateFin;
		}

		/// ///////////////////////////////////////////////////////
		private void FillObjetWithDialog()
		{
			m_postIt.Texte = m_txtTexte.Text;
			m_postIt.Titre = m_txtTitre.Text;
			m_postIt.DateFin = m_dtExpiration.Value;
			m_postIt.IsPublique = m_chkPublic.Checked;
		}

		/// ///////////////////////////////////////////////////////
		private void m_btnValider_Click(object sender, System.EventArgs e)
		{
			if ( !LockEdition )
			{
				FillObjetWithDialog();
				CResultAErreur result = m_postIt.CommitEdit();
				SaveIntoRegistre();
				LockEdition = true;
			}
		}

		/// ///////////////////////////////////////////////////////
		public event EventHandler OnChangeLockEdition;
		public bool LockEdition
		{
			get
			{
				return !m_extModeEdition.ModeEdition;
			}
			set
			{
				if ( m_extModeEdition.ModeEdition != !value )
				{
					m_extModeEdition.ModeEdition = !value;
					if ( OnChangeLockEdition != null )
						OnChangeLockEdition( this, new EventArgs());
				}
				UpdateVisibiliteBouton();
				
			}
		}

		/// ///////////////////////////////////////////////////////
		private void UpdateVisibiliteBouton()
		{
			m_panelValidation.Visible = !LockEdition;
			m_btnEditer.Visible = LockEdition && m_bCanEdit;
			m_btnPoubelle.Visible = m_bCanEdit && LockEdition;
			m_chkPublic.Visible = m_bCanEdit;
		}

		/// ///////////////////////////////////////////////////////
		public void Close()
		{
			if ( !LockEdition )
				AssureSauvegarde();
			Hide();
			Parent.Controls.Remove ( this );
		}

		/// ///////////////////////////////////////////////////////
		private void CWndPostit_Resize(object sender, System.EventArgs e)
		{
			m_panelTitre.BringToFront();
			m_btnResize.BringToFront();
			AssureBounds();
		}

		/// ///////////////////////////////////////////////////////
		private void CWndPostit_Move(object sender, System.EventArgs e)
		{
			AssureBounds();
		}

		/// ///////////////////////////////////////////////////////
		private void AssureBounds()
		{
			if ( Parent != null && Parent.Visible )
			{
				if ( Left < 0 )
					Left = 0;
				if ( Top < 0 )
					Top = 0;
				if ( Parent != null )
				{
					if ( Left > Parent.ClientRectangle.Width )
						Left = Parent.ClientRectangle.Width - Width;
					if(  Top > Parent.ClientRectangle.Height )
						Top = Parent.ClientRectangle.Height - Height;
				}
			}
		}

		private void m_btnPoubelle_Click(object sender, System.EventArgs e)
		{
			if ( CFormAlerte.Afficher(I.T( "Remove this Note ?|827"), EFormAlerteType.Question ) 
				== DialogResult.Yes )
			{
				CResultAErreur result = PostIt.Delete();
				if ( !result )
				{
					CFormAlerte.Afficher ( result.Erreur );
					return;
				}
				Hide();
				Close();
				Dispose();
			}
		}

		private void m_btnResize_Click(object sender, EventArgs e)
		{

		}

        private void m_txtTexte_TextChanged(object sender, EventArgs e)
        {

        }
	}
}
