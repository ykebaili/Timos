using System;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
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
using timos.client;
using timos.FinalCustomer;

namespace timos
{
	/// <summary>
	/// Description résumée de CFormLogin.
	/// </summary>
	public class CFormLogin : Form
	{
		#region Windows Form Designer generated code

		private System.Windows.Forms.TextBox m_txtLogin;
		private System.Windows.Forms.TextBox m_txtPassword;
		private System.Windows.Forms.Label m_lblUser;
		private System.Windows.Forms.Label m_lblPassWord;
		private System.Windows.Forms.Button m_btnAnnuler;
        private System.Windows.Forms.Button m_btnOk;
		private Panel m_panLogo;
		private Panel m_panForAll;
		private CEffetFonduPourForm m_effetFondu;
		private PictureBox pictureBox1;
        private Label label1;



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
System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormLogin));
sc2i.win32.common.CProfilEffetFondu cProfilEffetFondu1 = new sc2i.win32.common.CProfilEffetFondu();
this.m_txtLogin = new System.Windows.Forms.TextBox();
this.m_txtPassword = new System.Windows.Forms.TextBox();
this.m_lblUser = new System.Windows.Forms.Label();
this.m_lblPassWord = new System.Windows.Forms.Label();
this.m_btnAnnuler = new System.Windows.Forms.Button();
this.m_btnOk = new System.Windows.Forms.Button();
this.m_panLogo = new System.Windows.Forms.Panel();
this.m_panForAll = new System.Windows.Forms.Panel();
this.label1 = new System.Windows.Forms.Label();
this.pictureBox1 = new System.Windows.Forms.PictureBox();
this.m_effetFondu = new sc2i.win32.common.CEffetFonduPourForm();
this.m_panForAll.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
this.SuspendLayout();
// 
// m_txtLogin
// 
resources.ApplyResources(this.m_txtLogin, "m_txtLogin");
this.m_txtLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
this.m_txtLogin.Name = "m_txtLogin";
this.m_txtLogin.Leave += new System.EventHandler(this.m_txtPassword_Leave);
this.m_txtLogin.Enter += new System.EventHandler(this.m_txtLogin_Enter);
// 
// m_txtPassword
// 
resources.ApplyResources(this.m_txtPassword, "m_txtPassword");
this.m_txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
this.m_txtPassword.Name = "m_txtPassword";
this.m_txtPassword.Leave += new System.EventHandler(this.m_txtPassword_Leave);
this.m_txtPassword.Enter += new System.EventHandler(this.m_txtLogin_Enter);
// 
// m_lblUser
// 
this.m_lblUser.BackColor = System.Drawing.Color.Transparent;
this.m_lblUser.ForeColor = System.Drawing.Color.Black;
resources.ApplyResources(this.m_lblUser, "m_lblUser");
this.m_lblUser.Name = "m_lblUser";
// 
// m_lblPassWord
// 
this.m_lblPassWord.BackColor = System.Drawing.Color.Transparent;
this.m_lblPassWord.ForeColor = System.Drawing.Color.Black;
resources.ApplyResources(this.m_lblPassWord, "m_lblPassWord");
this.m_lblPassWord.Name = "m_lblPassWord";
// 
// m_btnAnnuler
// 
resources.ApplyResources(this.m_btnAnnuler, "m_btnAnnuler");
this.m_btnAnnuler.BackColor = System.Drawing.Color.WhiteSmoke;
this.m_btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
this.m_btnAnnuler.ForeColor = System.Drawing.Color.White;
this.m_btnAnnuler.Name = "m_btnAnnuler";
this.m_btnAnnuler.UseVisualStyleBackColor = false;
this.m_btnAnnuler.Click += new System.EventHandler(this.m_lblQuitter_Click);
// 
// m_btnOk
// 
resources.ApplyResources(this.m_btnOk, "m_btnOk");
this.m_btnOk.BackColor = System.Drawing.Color.WhiteSmoke;
this.m_btnOk.ForeColor = System.Drawing.Color.White;
this.m_btnOk.Name = "m_btnOk";
this.m_btnOk.UseVisualStyleBackColor = false;
this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
// 
// m_panLogo
// 
this.m_panLogo.BackColor = System.Drawing.Color.WhiteSmoke;
this.m_panLogo.BackgroundImage = global::timos.Properties.Resources.logo;
resources.ApplyResources(this.m_panLogo, "m_panLogo");
this.m_panLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
this.m_panLogo.Name = "m_panLogo";
this.m_panLogo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CFormLogin_MouseMove);
this.m_panLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CFormLogin_MouseDown);
// 
// m_panForAll
// 
this.m_panForAll.BackColor = System.Drawing.Color.WhiteSmoke;
this.m_panForAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
this.m_panForAll.Controls.Add(this.m_btnOk);
this.m_panForAll.Controls.Add(this.m_btnAnnuler);
this.m_panForAll.Controls.Add(this.m_panLogo);
this.m_panForAll.Controls.Add(this.m_txtLogin);
this.m_panForAll.Controls.Add(this.m_lblPassWord);
this.m_panForAll.Controls.Add(this.label1);
this.m_panForAll.Controls.Add(this.m_lblUser);
this.m_panForAll.Controls.Add(this.m_txtPassword);
this.m_panForAll.Controls.Add(this.pictureBox1);
resources.ApplyResources(this.m_panForAll, "m_panForAll");
this.m_panForAll.Name = "m_panForAll";
this.m_panForAll.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CFormLogin_MouseMove);
this.m_panForAll.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CFormLogin_MouseDown);
// 
// label1
// 
this.label1.BackColor = System.Drawing.Color.Transparent;
resources.ApplyResources(this.label1, "label1");
this.label1.ForeColor = System.Drawing.Color.Black;
this.label1.Name = "label1";
// 
// pictureBox1
// 
resources.ApplyResources(this.pictureBox1, "pictureBox1");
this.pictureBox1.Name = "pictureBox1";
this.pictureBox1.TabStop = false;
// 
// m_effetFondu
// 
this.m_effetFondu.AuDessusDesAutresFenetres = false;
this.m_effetFondu.EffetFonduFermeture = true;
this.m_effetFondu.EffetFonduOuverture = true;
this.m_effetFondu.Formulaire = this;
this.m_effetFondu.NombreImage = 20;
cProfilEffetFondu1.EffetActif = true;
cProfilEffetFondu1.EffetFermeture = true;
cProfilEffetFondu1.EffetOuverture = true;
cProfilEffetFondu1.IntervalImages = 10;
cProfilEffetFondu1.NombreImages = 20;
this.m_effetFondu.Profil = cProfilEffetFondu1;
// 
// CFormLogin
// 
this.AcceptButton = this.m_btnOk;
resources.ApplyResources(this, "$this");
this.BackColor = System.Drawing.Color.Gainsboro;
this.CancelButton = this.m_btnAnnuler;
this.ControlBox = false;
this.Controls.Add(this.m_panForAll);
this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
this.MaximizeBox = false;
this.MinimizeBox = false;
this.Name = "CFormLogin";
this.Opacity = 0;
this.Load += new System.EventHandler(this.CFormLogin_Load);
this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CFormLogin_MouseDown);
this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CFormLogin_MouseMove);
this.m_panForAll.ResumeLayout(false);
this.m_panForAll.PerformLayout();
((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
this.ResumeLayout(false);

		}
		#endregion

		public CFormLogin()
		{
			InitializeComponent();
            string strFile = CFinalCustomerInformations.GetLoginImageFile();
            if (strFile != null)
            {
                try
                {
                    Image img = Image.FromFile(strFile);
                    m_panLogo.BackgroundImage = img;
                }
                catch { }
            }
		}

		private void m_lblQuitter_Click(object sender, System.EventArgs e)
		{
			Close();
		}
		private void m_btnOk_Click(object sender, System.EventArgs e)
		{
            string  [] macAddresses;
			CSessionClient session = CSessionClient.CreateInstance();
            int i;
            
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

            macAddresses = new string[nics.Length];

            i = 0;
            foreach (NetworkInterface adapter in nics)
            {
                macAddresses.SetValue(adapter.GetPhysicalAddress().ToString(), i);
                i++;               
            }

            CResultAErreur result = session.OpenSession(new CAuthentificationSessionTimosLoginPwd(
                m_txtLogin.Text,
                m_txtPassword.Text,
                new CParametresLicence(CAuthentificateurTimos.GetIdsSupportAmovibles(),
                                       CAuthentificateurTimos.GetMACs() )));

			if ( !result )
			{
				CFormAlerte.Afficher ( result.Erreur );
				return;
			}
			CTimosApp.SessionClient = session;
			DialogResult = DialogResult.OK;
			Close();
		}

		private void OnCloseMain ( object sender, EventArgs args )
		{
			Close();
		}
		private void CFormLogin_Load(object sender, System.EventArgs e)
		{
            CWin32Traducteur.Translate(this);
			Focus();
			m_txtLogin.Focus();
		}

		private void m_txtLogin_Enter(object sender, EventArgs e)
		{
			((TextBox)sender).BackColor = Color.Lavender;
		}
		private void m_txtPassword_Leave(object sender, EventArgs e)
		{
			((TextBox)sender).BackColor = Color.White;
		}

		private void CFormLogin_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				m_ptStartMove = GetPointOnScreen((Control)sender, e.Location);
			}
		}

		private Point GetPointOnScreen(Control ctrl, Point pt)
		{
			while (ctrl != this && ctrl.Parent != null)
			{
				pt = ctrl.Parent.PointToScreen(pt);
				ctrl = ctrl.Parent;
			}

			return pt;
		}
		private Point m_ptStartMove = Point.Empty;
		private void CFormLogin_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				Point pt = GetPointOnScreen((Control)sender, e.Location);
				//Location = new Point(Location.X + (pt.X - m_ptStartMove.X),
				//                     Location.Y + (pt.Y - m_ptStartMove.Y));
				m_ptStartMove = Location;
			}
		}
	}
}
