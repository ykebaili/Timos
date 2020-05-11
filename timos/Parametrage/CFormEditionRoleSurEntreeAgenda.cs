using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;
using sc2i.data;
using sc2i.win32.navigation;
using sc2i.common;
using sc2i.win32.data;
using sc2i.win32.common;
using sc2i.workflow;
using timos.acteurs;


namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CRoleSurEntreeAgenda))]
	public class CFormEditionRoleSurEntreeAgenda : CFormEditionStdTimos, IFormNavigable
	{
		private Color m_couleurDeFond = Color.White;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre1;
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private System.Windows.Forms.Label label2;
		private sc2i.win32.common.C2iTextBox c2iTextBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.PictureBox m_wndImage;
		private System.Windows.Forms.Button m_btnSelectImage;
		private System.Windows.Forms.Button m_btnNoImage;
		private System.Windows.Forms.ToolTip m_tooltip;
		private System.Windows.Forms.Label label4;
		private sc2i.win32.common.C2iTextBox c2iTextBox2;
		private System.Windows.Forms.Panel m_panelImage;
		private System.Windows.Forms.PictureBox pictureBox2;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn1;
		private System.Windows.Forms.LinkLabel m_lnkCouleurFond;
        private Label label5;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionRoleSurEntreeAgenda()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionRoleSurEntreeAgenda(CRoleSurEntreeAgenda localisation)
			:base(localisation)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionRoleSurEntreeAgenda(CRoleSurEntreeAgenda localisation,CListeObjetsDonnees liste)
			:base(localisation, liste)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionRoleSurEntreeAgenda));
            this.c2iPanelOmbre1 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_lnkCouleurFond = new System.Windows.Forms.LinkLabel();
            this.m_panelImage = new System.Windows.Forms.Panel();
            this.m_wndImage = new System.Windows.Forms.PictureBox();
            this.c2iTextBox2 = new sc2i.win32.common.C2iTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_btnNoImage = new System.Windows.Forms.Button();
            this.m_btnSelectImage = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.c2iTextBox1 = new sc2i.win32.common.C2iTextBox();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.c2iPanelOmbre1.SuspendLayout();
            this.m_panelImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_wndImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(830, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // c2iPanelOmbre1
            // 
            this.c2iPanelOmbre1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre1.Controls.Add(this.c2iTextBox2);
            this.c2iPanelOmbre1.Controls.Add(this.label4);
            this.c2iPanelOmbre1.Controls.Add(this.m_lnkCouleurFond);
            this.c2iPanelOmbre1.Controls.Add(this.m_panelImage);
            this.c2iPanelOmbre1.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre1.Controls.Add(this.label2);
            this.c2iPanelOmbre1.Controls.Add(this.c2iTextBox1);
            this.c2iPanelOmbre1.Controls.Add(this.m_btnNoImage);
            this.c2iPanelOmbre1.Controls.Add(this.m_btnSelectImage);
            this.c2iPanelOmbre1.Controls.Add(this.label5);
            this.c2iPanelOmbre1.Controls.Add(this.label3);
            this.c2iPanelOmbre1.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre1, "");
            this.c2iPanelOmbre1.Location = new System.Drawing.Point(16, 52);
            this.c2iPanelOmbre1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.c2iPanelOmbre1.Name = "c2iPanelOmbre1";
            this.c2iPanelOmbre1.Size = new System.Drawing.Size(554, 196);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre1.TabIndex = 0;
            // 
            // m_lnkCouleurFond
            // 
            this.m_extLinkField.SetLinkField(this.m_lnkCouleurFond, "");
            this.m_lnkCouleurFond.Location = new System.Drawing.Point(176, 77);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkCouleurFond, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lnkCouleurFond.Name = "m_lnkCouleurFond";
            this.m_lnkCouleurFond.Size = new System.Drawing.Size(136, 23);
            this.m_extStyle.SetStyleBackColor(this.m_lnkCouleurFond, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkCouleurFond, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkCouleurFond.TabIndex = 4014;
            this.m_lnkCouleurFond.TabStop = true;
            this.m_lnkCouleurFond.Text = "Image back color|810";
            this.m_lnkCouleurFond.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkCouleurFond_LinkClicked);
            // 
            // m_panelImage
            // 
            this.m_panelImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_panelImage.Controls.Add(this.m_wndImage);
            this.m_extLinkField.SetLinkField(this.m_panelImage, "");
            this.m_panelImage.Location = new System.Drawing.Point(88, 69);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelImage, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelImage.Name = "m_panelImage";
            this.m_panelImage.Size = new System.Drawing.Size(32, 32);
            this.m_extStyle.SetStyleBackColor(this.m_panelImage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelImage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelImage.TabIndex = 4013;
            // 
            // m_wndImage
            // 
            this.m_extLinkField.SetLinkField(this.m_wndImage, "");
            this.m_wndImage.Location = new System.Drawing.Point(6, 6);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndImage, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_wndImage.Name = "m_wndImage";
            this.m_wndImage.Size = new System.Drawing.Size(16, 16);
            this.m_wndImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_extStyle.SetStyleBackColor(this.m_wndImage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndImage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndImage.TabIndex = 4008;
            this.m_wndImage.TabStop = false;
            // 
            // c2iTextBox2
            // 
            this.c2iTextBox2.AcceptsReturn = true;
            this.m_extLinkField.SetLinkField(this.c2iTextBox2, "Descriptif");
            this.c2iTextBox2.Location = new System.Drawing.Point(88, 112);
            this.c2iTextBox2.LockEdition = false;
            this.c2iTextBox2.MaxLength = 64;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox2, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.c2iTextBox2.Multiline = true;
            this.c2iTextBox2.Name = "c2iTextBox2";
            this.c2iTextBox2.Size = new System.Drawing.Size(440, 56);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox2.TabIndex = 4012;
            this.c2iTextBox2.Text = "[Description]|30321";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.label4.Location = new System.Drawing.Point(8, 112);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 4011;
            this.label4.Text = "Description|41";
            // 
            // m_btnNoImage
            // 
            this.m_btnNoImage.Image = ((System.Drawing.Image)(resources.GetObject("m_btnNoImage.Image")));
            this.m_extLinkField.SetLinkField(this.m_btnNoImage, "");
            this.m_btnNoImage.Location = new System.Drawing.Point(144, 69);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnNoImage, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnNoImage.Name = "m_btnNoImage";
            this.m_btnNoImage.Size = new System.Drawing.Size(24, 32);
            this.m_extStyle.SetStyleBackColor(this.m_btnNoImage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnNoImage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnNoImage.TabIndex = 4010;
            this.m_btnNoImage.Text = "...";
            this.m_tooltip.SetToolTip(this.m_btnNoImage, I.T("No image|30322"));
            this.m_btnNoImage.Click += new System.EventHandler(this.m_btnNoImage_Click);
            // 
            // m_btnSelectImage
            // 
            this.m_extLinkField.SetLinkField(this.m_btnSelectImage, "");
            this.m_btnSelectImage.Location = new System.Drawing.Point(120, 69);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnSelectImage, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnSelectImage.Name = "m_btnSelectImage";
            this.m_btnSelectImage.Size = new System.Drawing.Size(24, 32);
            this.m_extStyle.SetStyleBackColor(this.m_btnSelectImage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSelectImage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnSelectImage.TabIndex = 4009;
            this.m_btnSelectImage.Text = "...";
            this.m_tooltip.SetToolTip(this.m_btnSelectImage, I.T("Select an image|30323"));
            this.m_btnSelectImage.Click += new System.EventHandler(this.m_btnSelectImage_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(8, 77);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4007;
            this.label3.Text = "Image|809";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(8, 43);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4006;
            this.label2.Text = "Code|40";
            // 
            // c2iTextBox1
            // 
            this.m_extLinkField.SetLinkField(this.c2iTextBox1, "Code");
            this.c2iTextBox1.Location = new System.Drawing.Point(88, 40);
            this.c2iTextBox1.LockEdition = false;
            this.c2iTextBox1.MaxLength = 64;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.c2iTextBox1.Name = "c2iTextBox1";
            this.c2iTextBox1.Size = new System.Drawing.Size(224, 20);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox1.TabIndex = 4005;
            this.c2iTextBox1.Text = "[Code]";
            // 
            // m_txtLibelle
            // 
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_txtLibelle.Location = new System.Drawing.Point(88, 8);
            this.m_txtLibelle.LockEdition = false;
            this.m_txtLibelle.MaxLength = 255;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(440, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 4003;
            this.m_txtLibelle.Text = "[Label]|30324";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4004;
            this.label1.Text = "Label|50";
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "Libelle";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Groupe";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 342;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.pictureBox2, "");
            this.pictureBox2.Location = new System.Drawing.Point(8, 24);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pictureBox2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(520, 1);
            this.m_extStyle.SetStyleBackColor(this.pictureBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pictureBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.label5.Location = new System.Drawing.Point(8, 11);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 4006;
            this.label5.Text = "Label|50";
            // 
            // CFormEditionRoleSurEntreeAgenda
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.c2iPanelOmbre1);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CFormEditionRoleSurEntreeAgenda";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre1, 0);
            this.c2iPanelOmbre1.ResumeLayout(false);
            this.c2iPanelOmbre1.PerformLayout();
            this.m_panelImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_wndImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();



			m_wndImage.Image = RoleSurEntreeAgenda.Image;

			AffecterTitre(I.T("Agenda role|30232") + RoleSurEntreeAgenda.Libelle);
			return result;
		}

		//-------------------------------------------------------------------------
		private void UpdateCouleurDeFond()
		{
			m_panelImage.BackColor = m_couleurDeFond;
			m_wndImage.BackColor = m_couleurDeFond;
		}

		//-------------------------------------------------------------------------
		protected override CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = base.MAJ_Champs();
			if ( !result )
				return result;
			
			
			if ( m_wndImage.Image != null )
			{
				Image img = m_wndImage.Image;
				Bitmap bmp = new Bitmap(16,16);
				Graphics g = Graphics.FromImage(bmp);
				Brush br = new SolidBrush ( m_couleurDeFond );
				g.FillRectangle ( br, 0, 0, 16, 16 );
				br.Dispose();
				g.DrawImage ( img, new Rectangle ( 0, 0, 16, 16), 0,0,img.Width, img.Height, GraphicsUnit.Pixel );
				RoleSurEntreeAgenda.Image = bmp;
				g.Dispose();
				bmp.Dispose();
			}
			else
				RoleSurEntreeAgenda.Image = null;
			return result;
		}


		//-------------------------------------------------------------------------
		private void m_btnSelectImage_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog ();
			dlg.Filter = I.T("All images|*.jpg;*.bmp;*.gif;*.tif;*.ico|Bitmap|*.bmp|Jpeg|*.jpg;*.jpeg|Gif|*.gif|Tif|*.tif|Icon|*.ico|All files|*.*|30233");
			if ( dlg.ShowDialog() == DialogResult.OK )
			{
				string strFile = dlg.FileName;
				try
				{
					Image img = Image.FromFile ( strFile, true );
					if ( !(img is Bitmap ) )
						throw new Exception(I.T("Incorrect format|30049"));
					if ( img.Width>16 || img.Height>16 )
					{
						CFormAlerte.Afficher(I.T("An image of maximum size 16x16 is recommended|30050"));
					}
					m_wndImage.Image = img;
				}
				catch ( Exception exp )
				{
					CResultAErreur result = CResultAErreur.True;
					result.EmpileErreur ( new CErreurException(exp));
					result.EmpileErreur(I.T("File reading error|30051"));
					CFormAlerte.Afficher( result.Erreur );
				}
			}
		}

		//-------------------------------------------------------------------------
		private void m_btnNoImage_Click(object sender, System.EventArgs e)
		{
			m_wndImage.Image = null;
		}

		private void m_lnkCouleurFond_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			ColorDialog dlg = new ColorDialog();
			if ( dlg.ShowDialog() == DialogResult.OK )
			{
				m_couleurDeFond = dlg.Color;
				UpdateCouleurDeFond();
			}
		}


		//-------------------------------------------------------------------------
		private CRoleSurEntreeAgenda RoleSurEntreeAgenda
		{
			get
			{
				return ((CRoleSurEntreeAgenda)ObjetEdite);
			}
		}
	}
}

