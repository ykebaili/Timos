using System;
using System.Text;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Security.Principal;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using System.Reflection;

using sc2i.common;
using sc2i.multitiers.client;
using sc2i.data;
using sc2i.win32.data;
using sc2i.win32.common;

using timos.data;

namespace timos
{
	/// <summary>
	/// Description résumée de CFormLogin.
	/// </summary>
	public class CFormConfirmeExist : Form
	{
		#region Windows Form Designer generated code

		private System.Windows.Forms.Button m_btnAnnuler;
		private System.Windows.Forms.Button m_btnOk;
		private System.Windows.Forms.Panel m_panBoutons;
		private Panel m_panLogo;
		private Panel m_panForAll;
		private CEffetFonduPourForm m_effetFondu;
		private Label m_lblConfirme;



		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				
			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormConfirmeExist));
			this.m_btnAnnuler = new System.Windows.Forms.Button();
			this.m_btnOk = new System.Windows.Forms.Button();
			this.m_panBoutons = new System.Windows.Forms.Panel();
			this.m_panLogo = new System.Windows.Forms.Panel();
			this.m_panForAll = new System.Windows.Forms.Panel();
			this.m_effetFondu = new sc2i.win32.common.CEffetFonduPourForm();
			this.m_lblConfirme = new System.Windows.Forms.Label();
			this.m_panBoutons.SuspendLayout();
			this.m_panForAll.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_btnAnnuler
			// 
			this.m_btnAnnuler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.m_btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(this.m_btnAnnuler, "m_btnAnnuler");
			this.m_btnAnnuler.ForeColor = System.Drawing.Color.White;
			this.m_btnAnnuler.Name = "m_btnAnnuler";
			this.m_btnAnnuler.UseVisualStyleBackColor = false;
			this.m_btnAnnuler.Click += new System.EventHandler(this.m_lblQuitter_Click);
			// 
			// m_btnOk
			// 
			this.m_btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			resources.ApplyResources(this.m_btnOk, "m_btnOk");
			this.m_btnOk.ForeColor = System.Drawing.Color.White;
			this.m_btnOk.Name = "m_btnOk";
			this.m_btnOk.UseVisualStyleBackColor = false;
			this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
			// 
			// m_panBoutons
			// 
			resources.ApplyResources(this.m_panBoutons, "m_panBoutons");
			this.m_panBoutons.BackColor = System.Drawing.Color.White;
			this.m_panBoutons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_panBoutons.Controls.Add(this.m_btnAnnuler);
			this.m_panBoutons.Controls.Add(this.m_btnOk);
			this.m_panBoutons.Name = "m_panBoutons";
			// 
			// m_panLogo
			// 
			this.m_panLogo.BackgroundImage = global::timos.Properties.Resources.logo;
			resources.ApplyResources(this.m_panLogo, "m_panLogo");
			this.m_panLogo.Name = "m_panLogo";
			// 
			// m_panForAll
			// 
			this.m_panForAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_panForAll.Controls.Add(this.m_panLogo);
			this.m_panForAll.Controls.Add(this.m_panBoutons);
			this.m_panForAll.Controls.Add(this.m_lblConfirme);
			resources.ApplyResources(this.m_panForAll, "m_panForAll");
			this.m_panForAll.Name = "m_panForAll";
			// 
			// m_effetFondu
			// 
			this.m_effetFondu.AuDessusDesAutresFenetres = true;
			this.m_effetFondu.EffetFonduFermeture = true;
			this.m_effetFondu.EffetFonduOuverture = true;
			this.m_effetFondu.Formulaire = this;
			this.m_effetFondu.IntervalImages = 10;
			this.m_effetFondu.NombreImage = 10;
			// 
			// m_lblConfirme
			// 
			this.m_lblConfirme.BackColor = System.Drawing.Color.Transparent;
			this.m_lblConfirme.ForeColor = System.Drawing.Color.Black;
			resources.ApplyResources(this.m_lblConfirme, "m_lblConfirme");
			this.m_lblConfirme.Name = "m_lblConfirme";
			// 
			// CFormConfirmeExist
			// 
			this.AcceptButton = this.m_btnOk;
			resources.ApplyResources(this, "$this");
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.CancelButton = this.m_btnAnnuler;
			this.ControlBox = false;
			this.Controls.Add(this.m_panForAll);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CFormConfirmeExist";
			this.Opacity = 0;
			this.m_panBoutons.ResumeLayout(false);
			this.m_panForAll.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public CFormConfirmeExist()
		{
			InitializeComponent();
			CWin32Traducteur.Translate(this);
		}

		private void m_lblQuitter_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
		private void m_btnOk_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}

		public static DialogResult Afficher()
		{
			CFormConfirmeExist frm = new CFormConfirmeExist();
			//TRADUIRE
			return frm.ShowDialog();
		}

	}
}
