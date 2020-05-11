using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using sc2i.common;
using sc2i.data.dynamic;
using sc2i.process;
using sc2i.expression;
using timos.process;

namespace sc2i.win32.process
{
	[AutoExec("Autoexec")]
	public class CFormEditActionEnvoyerMail : sc2i.win32.process.CFormEditObjetDeProcess
	{
		private sc2i.win32.expression.CControleEditeFormule m_txtFormule = null;

		private sc2i.win32.common.C2iTabControl c2iTabControl1;
		private sc2i.win32.common.C2iTabControl m_tabControl;
		private Crownwood.Magic.Controls.TabPage tabPage1;
		private Crownwood.Magic.Controls.TabPage tabPage2;
		private Crownwood.Magic.Controls.TabPage tabPage3;
		private sc2i.win32.expression.CControlAideFormule m_wndAideFormule;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private sc2i.win32.expression.CControleEditeFormule m_txtExpediteur;
		private sc2i.win32.expression.CControleEditeFormule m_txtSujet;
		private sc2i.win32.expression.CControleEditeFormule m_txtMessage;
		private System.Windows.Forms.LinkLabel m_lnkAjouterDestinataire;
		private System.Windows.Forms.LinkLabel m_lnkSupprimerDestinataire;
		private System.Windows.Forms.LinkLabel m_lnkAjouterPieceJointe;
		private System.Windows.Forms.LinkLabel m_lnkSupprimerPieceJointe;
		private System.Windows.Forms.Panel m_panelDestinataires;
		private System.Windows.Forms.Panel m_panelPiecesJointes;
        protected sc2i.win32.common.CExtStyle m_extStyle;
        private Crownwood.Magic.Controls.TabPage tabPage4;
        private Crownwood.Magic.Controls.TabPage tabPage5;
        private LinkLabel m_lnkSupprimerBCC;
        private LinkLabel m_lnkAjouterDestBCC;
        private Panel m_panelDestinatairesBCC;
        private LinkLabel m_lnkSupprimerCC;
        private LinkLabel m_lnkAjouterDestCC;
        private Panel m_panelDestinatairesCC;
        private CheckBox m_chkFormatHTML;
        private CheckBox m_chkUseDocLabel;
        private Crownwood.Magic.Controls.TabPage tabPage6;
        private common.C2iTextBoxNumerique m_numPortSMTP;
        private common.C2iTextBox m_txtNomServeurSMTP;
        private Label label5;
        private Label label1;
        private Label label7;
        private Label label6;
        private Label label8;
        private Label label9;
        private common.C2iTextBox m_txtUserSMTP;
        private Label label10;
        private common.C2iTextBox m_txtPasswordSMTP;
        private Label label11;
		private System.ComponentModel.IContainer components = null;

		public CFormEditActionEnvoyerMail()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();

			// TODO : ajoutez les initialisations après l'appel à InitializeComponent
		}

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

		public static void Autoexec()
		{
			CEditeurActionsEtLiens.RegisterEditeur ( typeof(CActionEnvoyerMail), typeof(CFormEditActionEnvoyerMail));
		}

		#region Code généré par le concepteur
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.c2iTabControl1 = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.tabPage6 = new Crownwood.Magic.Controls.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_numPortSMTP = new sc2i.win32.common.C2iTextBoxNumerique();
            this.m_txtPasswordSMTP = new sc2i.win32.common.C2iTextBox();
            this.m_txtUserSMTP = new sc2i.win32.common.C2iTextBox();
            this.m_txtNomServeurSMTP = new sc2i.win32.common.C2iTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.m_chkFormatHTML = new System.Windows.Forms.CheckBox();
            this.m_txtMessage = new sc2i.win32.expression.CControleEditeFormule();
            this.m_txtSujet = new sc2i.win32.expression.CControleEditeFormule();
            this.m_txtExpediteur = new sc2i.win32.expression.CControleEditeFormule();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.m_lnkAjouterDestinataire = new System.Windows.Forms.LinkLabel();
            this.m_panelDestinataires = new System.Windows.Forms.Panel();
            this.m_lnkSupprimerDestinataire = new System.Windows.Forms.LinkLabel();
            this.tabPage4 = new Crownwood.Magic.Controls.TabPage();
            this.m_lnkSupprimerCC = new System.Windows.Forms.LinkLabel();
            this.m_lnkAjouterDestCC = new System.Windows.Forms.LinkLabel();
            this.m_panelDestinatairesCC = new System.Windows.Forms.Panel();
            this.tabPage5 = new Crownwood.Magic.Controls.TabPage();
            this.m_lnkSupprimerBCC = new System.Windows.Forms.LinkLabel();
            this.m_lnkAjouterDestBCC = new System.Windows.Forms.LinkLabel();
            this.m_panelDestinatairesBCC = new System.Windows.Forms.Panel();
            this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
            this.m_chkUseDocLabel = new System.Windows.Forms.CheckBox();
            this.m_lnkAjouterPieceJointe = new System.Windows.Forms.LinkLabel();
            this.m_panelPiecesJointes = new System.Windows.Forms.Panel();
            this.m_lnkSupprimerPieceJointe = new System.Windows.Forms.LinkLabel();
            this.m_wndAideFormule = new sc2i.win32.expression.CControlAideFormule();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.label11 = new System.Windows.Forms.Label();
            this.m_tabControl.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // c2iTabControl1
            // 
            this.c2iTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iTabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iTabControl1.BoldSelectedPage = true;
            this.c2iTabControl1.ControlBottomOffset = 16;
            this.c2iTabControl1.ControlRightOffset = 16;
            this.c2iTabControl1.ForeColor = System.Drawing.Color.Black;
            this.c2iTabControl1.IDEPixelArea = false;
            this.c2iTabControl1.Location = new System.Drawing.Point(0, 32);
            this.c2iTabControl1.Name = "c2iTabControl1";
            this.c2iTabControl1.Ombre = true;
            this.c2iTabControl1.PositionTop = true;
            this.c2iTabControl1.Size = new System.Drawing.Size(712, 328);
            this.m_extStyle.SetStyleBackColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iTabControl1.TabIndex = 2;
            this.c2iTabControl1.TextColor = System.Drawing.Color.Black;
            // 
            // m_tabControl
            // 
            this.m_tabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_tabControl.BoldSelectedPage = true;
            this.m_tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tabControl.ForeColor = System.Drawing.Color.Black;
            this.m_tabControl.IDEPixelArea = false;
            this.m_tabControl.Location = new System.Drawing.Point(0, 0);
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = false;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 5;
            this.m_tabControl.SelectedTab = this.tabPage6;
            this.m_tabControl.Size = new System.Drawing.Size(662, 425);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 3;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2,
            this.tabPage4,
            this.tabPage5,
            this.tabPage3,
            this.tabPage6});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            this.m_tabControl.SelectionChanged += new System.EventHandler(this.c2iTabControl2_SelectionChanged);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.label10);
            this.tabPage6.Controls.Add(this.label9);
            this.tabPage6.Controls.Add(this.label7);
            this.tabPage6.Controls.Add(this.label11);
            this.tabPage6.Controls.Add(this.label8);
            this.tabPage6.Controls.Add(this.label6);
            this.tabPage6.Controls.Add(this.m_numPortSMTP);
            this.tabPage6.Controls.Add(this.m_txtPasswordSMTP);
            this.tabPage6.Controls.Add(this.m_txtUserSMTP);
            this.tabPage6.Controls.Add(this.m_txtNomServeurSMTP);
            this.tabPage6.Controls.Add(this.label5);
            this.tabPage6.Controls.Add(this.label1);
            this.tabPage6.Location = new System.Drawing.Point(0, 25);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(662, 400);
            this.m_extStyle.SetStyleBackColor(this.tabPage6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage6.TabIndex = 15;
            this.tabPage6.Title = "Serveur sortant (SMTP)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 243);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 15);
            this.m_extStyle.SetStyleBackColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label10.TabIndex = 3;
            this.label10.Text = "Mot de passe";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 207);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 15);
            this.m_extStyle.SetStyleBackColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label9.TabIndex = 3;
            this.label9.Text = "Nom d\'utilisateur";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 15);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 3;
            this.label7.Text = "Port";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(250, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(298, 15);
            this.m_extStyle.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 3;
            this.label8.Text = "Laisser ce champ vide pour utiliser le serveur par défaut";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(198, 15);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 3;
            this.label6.Text = "Nom ou adresse IP du serveur SMTP";
            // 
            // m_numPortSMTP
            // 
            this.m_numPortSMTP.Arrondi = 0;
            this.m_numPortSMTP.DecimalAutorise = true;
            this.m_numPortSMTP.EmptyText = "";
            this.m_numPortSMTP.IntValue = 0;
            this.m_numPortSMTP.Location = new System.Drawing.Point(143, 167);
            this.m_numPortSMTP.LockEdition = false;
            this.m_numPortSMTP.Name = "m_numPortSMTP";
            this.m_numPortSMTP.NullAutorise = false;
            this.m_numPortSMTP.SelectAllOnEnter = true;
            this.m_numPortSMTP.SeparateurMilliers = "";
            this.m_numPortSMTP.Size = new System.Drawing.Size(100, 23);
            this.m_extStyle.SetStyleBackColor(this.m_numPortSMTP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_numPortSMTP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_numPortSMTP.TabIndex = 2;
            this.m_numPortSMTP.Text = "0";
            // 
            // m_txtPasswordSMTP
            // 
            this.m_txtPasswordSMTP.EmptyText = "";
            this.m_txtPasswordSMTP.Location = new System.Drawing.Point(143, 240);
            this.m_txtPasswordSMTP.LockEdition = false;
            this.m_txtPasswordSMTP.Name = "m_txtPasswordSMTP";
            this.m_txtPasswordSMTP.Size = new System.Drawing.Size(266, 23);
            this.m_extStyle.SetStyleBackColor(this.m_txtPasswordSMTP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtPasswordSMTP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtPasswordSMTP.TabIndex = 1;
            // 
            // m_txtUserSMTP
            // 
            this.m_txtUserSMTP.EmptyText = "";
            this.m_txtUserSMTP.Location = new System.Drawing.Point(143, 204);
            this.m_txtUserSMTP.LockEdition = false;
            this.m_txtUserSMTP.Name = "m_txtUserSMTP";
            this.m_txtUserSMTP.Size = new System.Drawing.Size(266, 23);
            this.m_extStyle.SetStyleBackColor(this.m_txtUserSMTP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtUserSMTP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtUserSMTP.TabIndex = 1;
            // 
            // m_txtNomServeurSMTP
            // 
            this.m_txtNomServeurSMTP.EmptyText = "";
            this.m_txtNomServeurSMTP.Location = new System.Drawing.Point(232, 109);
            this.m_txtNomServeurSMTP.LockEdition = false;
            this.m_txtNomServeurSMTP.Name = "m_txtNomServeurSMTP";
            this.m_txtNomServeurSMTP.Size = new System.Drawing.Size(378, 23);
            this.m_extStyle.SetStyleBackColor(this.m_txtNomServeurSMTP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtNomServeurSMTP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtNomServeurSMTP.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(28, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(578, 48);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 0;
            this.label5.Text = "Le serveur pas défaut est configuré dans la Base de Regsitre. Vous pouvez déclare" +
    "r ici un serveur SMTP alternatif, qui remplacera le serveur par défaut.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(340, 25);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 0;
            this.label1.Text = "Configuration du serveur sortant SMTP";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_chkFormatHTML);
            this.tabPage1.Controls.Add(this.m_txtMessage);
            this.tabPage1.Controls.Add(this.m_txtSujet);
            this.tabPage1.Controls.Add(this.m_txtExpediteur);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Selected = false;
            this.tabPage1.Size = new System.Drawing.Size(662, 400);
            this.m_extStyle.SetStyleBackColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage1.TabIndex = 10;
            this.tabPage1.Title = "Message|1029";
            // 
            // m_chkFormatHTML
            // 
            this.m_chkFormatHTML.Location = new System.Drawing.Point(114, 160);
            this.m_chkFormatHTML.Name = "m_chkFormatHTML";
            this.m_chkFormatHTML.Size = new System.Drawing.Size(216, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkFormatHTML, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkFormatHTML, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkFormatHTML.TabIndex = 6;
            this.m_chkFormatHTML.Text = "HTML Format";
            this.m_chkFormatHTML.UseVisualStyleBackColor = true;
            // 
            // m_txtMessage
            // 
            this.m_txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtMessage.BackColor = System.Drawing.Color.White;
            this.m_txtMessage.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtMessage.Formule = null;
            this.m_txtMessage.Location = new System.Drawing.Point(8, 176);
            this.m_txtMessage.LockEdition = false;
            this.m_txtMessage.Name = "m_txtMessage";
            this.m_txtMessage.Size = new System.Drawing.Size(641, 168);
            this.m_extStyle.SetStyleBackColor(this.m_txtMessage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtMessage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtMessage.TabIndex = 5;
            this.m_txtMessage.Enter += new System.EventHandler(this.OnEnterTexteFormule);
            // 
            // m_txtSujet
            // 
            this.m_txtSujet.BackColor = System.Drawing.Color.White;
            this.m_txtSujet.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtSujet.Formule = null;
            this.m_txtSujet.Location = new System.Drawing.Point(8, 96);
            this.m_txtSujet.LockEdition = false;
            this.m_txtSujet.Name = "m_txtSujet";
            this.m_txtSujet.Size = new System.Drawing.Size(625, 56);
            this.m_extStyle.SetStyleBackColor(this.m_txtSujet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSujet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSujet.TabIndex = 4;
            this.m_txtSujet.Enter += new System.EventHandler(this.OnEnterTexteFormule);
            // 
            // m_txtExpediteur
            // 
            this.m_txtExpediteur.BackColor = System.Drawing.Color.White;
            this.m_txtExpediteur.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtExpediteur.Formule = null;
            this.m_txtExpediteur.Location = new System.Drawing.Point(8, 24);
            this.m_txtExpediteur.LockEdition = false;
            this.m_txtExpediteur.Name = "m_txtExpediteur";
            this.m_txtExpediteur.Size = new System.Drawing.Size(625, 54);
            this.m_extStyle.SetStyleBackColor(this.m_txtExpediteur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtExpediteur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtExpediteur.TabIndex = 3;
            this.m_txtExpediteur.Enter += new System.EventHandler(this.OnEnterTexteFormule);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 2;
            this.label4.Text = "Message|1029";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 1;
            this.label3.Text = "Object|1033";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 0;
            this.label2.Text = "Sender|1032";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.m_lnkAjouterDestinataire);
            this.tabPage2.Controls.Add(this.m_panelDestinataires);
            this.tabPage2.Controls.Add(this.m_lnkSupprimerDestinataire);
            this.tabPage2.Location = new System.Drawing.Point(0, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(662, 400);
            this.m_extStyle.SetStyleBackColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage2.TabIndex = 11;
            this.tabPage2.Title = "Recipient|1030";
            // 
            // m_lnkAjouterDestinataire
            // 
            this.m_lnkAjouterDestinataire.Location = new System.Drawing.Point(8, 8);
            this.m_lnkAjouterDestinataire.Name = "m_lnkAjouterDestinataire";
            this.m_lnkAjouterDestinataire.Size = new System.Drawing.Size(136, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAjouterDestinataire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAjouterDestinataire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAjouterDestinataire.TabIndex = 1;
            this.m_lnkAjouterDestinataire.TabStop = true;
            this.m_lnkAjouterDestinataire.Text = "Add recipient|1035";
            this.m_lnkAjouterDestinataire.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkAjouter_LinkClicked);
            // 
            // m_panelDestinataires
            // 
            this.m_panelDestinataires.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelDestinataires.AutoScroll = true;
            this.m_panelDestinataires.Location = new System.Drawing.Point(8, 24);
            this.m_panelDestinataires.Name = "m_panelDestinataires";
            this.m_panelDestinataires.Size = new System.Drawing.Size(649, 324);
            this.m_extStyle.SetStyleBackColor(this.m_panelDestinataires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelDestinataires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelDestinataires.TabIndex = 0;
            // 
            // m_lnkSupprimerDestinataire
            // 
            this.m_lnkSupprimerDestinataire.Location = new System.Drawing.Point(168, 8);
            this.m_lnkSupprimerDestinataire.Name = "m_lnkSupprimerDestinataire";
            this.m_lnkSupprimerDestinataire.Size = new System.Drawing.Size(136, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSupprimerDestinataire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSupprimerDestinataire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSupprimerDestinataire.TabIndex = 1;
            this.m_lnkSupprimerDestinataire.TabStop = true;
            this.m_lnkSupprimerDestinataire.Text = "Remove|18";
            this.m_lnkSupprimerDestinataire.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkSupprimerDestinataire_LinkClicked);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.m_lnkSupprimerCC);
            this.tabPage4.Controls.Add(this.m_lnkAjouterDestCC);
            this.tabPage4.Controls.Add(this.m_panelDestinatairesCC);
            this.tabPage4.Location = new System.Drawing.Point(0, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Selected = false;
            this.tabPage4.Size = new System.Drawing.Size(662, 400);
            this.m_extStyle.SetStyleBackColor(this.tabPage4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage4.TabIndex = 13;
            this.tabPage4.Title = "CC recipient|10053";
            // 
            // m_lnkSupprimerCC
            // 
            this.m_lnkSupprimerCC.AutoSize = true;
            this.m_lnkSupprimerCC.Location = new System.Drawing.Point(167, 9);
            this.m_lnkSupprimerCC.Name = "m_lnkSupprimerCC";
            this.m_lnkSupprimerCC.Size = new System.Drawing.Size(65, 15);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSupprimerCC, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSupprimerCC, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSupprimerCC.TabIndex = 2;
            this.m_lnkSupprimerCC.TabStop = true;
            this.m_lnkSupprimerCC.Text = "Remove|18";
            this.m_lnkSupprimerCC.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkSupprimerCC_LinkClicked);
            // 
            // m_lnkAjouterDestCC
            // 
            this.m_lnkAjouterDestCC.AutoSize = true;
            this.m_lnkAjouterDestCC.Location = new System.Drawing.Point(12, 9);
            this.m_lnkAjouterDestCC.Name = "m_lnkAjouterDestCC";
            this.m_lnkAjouterDestCC.Size = new System.Drawing.Size(105, 15);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAjouterDestCC, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAjouterDestCC, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAjouterDestCC.TabIndex = 1;
            this.m_lnkAjouterDestCC.TabStop = true;
            this.m_lnkAjouterDestCC.Text = "Add recipient|1035";
            this.m_lnkAjouterDestCC.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkAjouterDestCC_LinkClicked);
            // 
            // m_panelDestinatairesCC
            // 
            this.m_panelDestinatairesCC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelDestinatairesCC.AutoScroll = true;
            this.m_panelDestinatairesCC.Location = new System.Drawing.Point(12, 25);
            this.m_panelDestinatairesCC.Name = "m_panelDestinatairesCC";
            this.m_panelDestinatairesCC.Size = new System.Drawing.Size(634, 343);
            this.m_extStyle.SetStyleBackColor(this.m_panelDestinatairesCC, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelDestinatairesCC, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelDestinatairesCC.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.m_lnkSupprimerBCC);
            this.tabPage5.Controls.Add(this.m_lnkAjouterDestBCC);
            this.tabPage5.Controls.Add(this.m_panelDestinatairesBCC);
            this.tabPage5.Location = new System.Drawing.Point(0, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Selected = false;
            this.tabPage5.Size = new System.Drawing.Size(662, 400);
            this.m_extStyle.SetStyleBackColor(this.tabPage5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage5.TabIndex = 14;
            this.tabPage5.Title = "BCC recipient|10054";
            // 
            // m_lnkSupprimerBCC
            // 
            this.m_lnkSupprimerBCC.AutoSize = true;
            this.m_lnkSupprimerBCC.Location = new System.Drawing.Point(170, 10);
            this.m_lnkSupprimerBCC.Name = "m_lnkSupprimerBCC";
            this.m_lnkSupprimerBCC.Size = new System.Drawing.Size(65, 15);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSupprimerBCC, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSupprimerBCC, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSupprimerBCC.TabIndex = 2;
            this.m_lnkSupprimerBCC.TabStop = true;
            this.m_lnkSupprimerBCC.Text = "Remove|18";
            this.m_lnkSupprimerBCC.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkSupprimerBCC_LinkClicked);
            // 
            // m_lnkAjouterDestBCC
            // 
            this.m_lnkAjouterDestBCC.AutoSize = true;
            this.m_lnkAjouterDestBCC.Location = new System.Drawing.Point(11, 10);
            this.m_lnkAjouterDestBCC.Name = "m_lnkAjouterDestBCC";
            this.m_lnkAjouterDestBCC.Size = new System.Drawing.Size(105, 15);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAjouterDestBCC, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAjouterDestBCC, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAjouterDestBCC.TabIndex = 1;
            this.m_lnkAjouterDestBCC.TabStop = true;
            this.m_lnkAjouterDestBCC.Text = "Add recipient|1035";
            this.m_lnkAjouterDestBCC.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkAjouterDestBCC_LinkClicked);
            // 
            // m_panelDestinatairesBCC
            // 
            this.m_panelDestinatairesBCC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelDestinatairesBCC.AutoScroll = true;
            this.m_panelDestinatairesBCC.Location = new System.Drawing.Point(7, 25);
            this.m_panelDestinatairesBCC.Name = "m_panelDestinatairesBCC";
            this.m_panelDestinatairesBCC.Size = new System.Drawing.Size(647, 342);
            this.m_extStyle.SetStyleBackColor(this.m_panelDestinatairesBCC, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelDestinatairesBCC, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelDestinatairesBCC.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.m_chkUseDocLabel);
            this.tabPage3.Controls.Add(this.m_lnkAjouterPieceJointe);
            this.tabPage3.Controls.Add(this.m_panelPiecesJointes);
            this.tabPage3.Controls.Add(this.m_lnkSupprimerPieceJointe);
            this.tabPage3.Location = new System.Drawing.Point(0, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Selected = false;
            this.tabPage3.Size = new System.Drawing.Size(662, 400);
            this.m_extStyle.SetStyleBackColor(this.tabPage3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage3.TabIndex = 12;
            this.tabPage3.Title = "Attached|1031";
            // 
            // m_chkUseDocLabel
            // 
            this.m_chkUseDocLabel.Location = new System.Drawing.Point(270, 3);
            this.m_chkUseDocLabel.Name = "m_chkUseDocLabel";
            this.m_chkUseDocLabel.Size = new System.Drawing.Size(216, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkUseDocLabel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkUseDocLabel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkUseDocLabel.TabIndex = 7;
            this.m_chkUseDocLabel.Text = "Use document label as file name";
            this.m_chkUseDocLabel.UseVisualStyleBackColor = true;
            // 
            // m_lnkAjouterPieceJointe
            // 
            this.m_lnkAjouterPieceJointe.Location = new System.Drawing.Point(6, 3);
            this.m_lnkAjouterPieceJointe.Name = "m_lnkAjouterPieceJointe";
            this.m_lnkAjouterPieceJointe.Size = new System.Drawing.Size(136, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAjouterPieceJointe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAjouterPieceJointe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAjouterPieceJointe.TabIndex = 4;
            this.m_lnkAjouterPieceJointe.TabStop = true;
            this.m_lnkAjouterPieceJointe.Text = "Add a document|1036";
            this.m_lnkAjouterPieceJointe.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkAjouterPieceJointe_LinkClicked);
            // 
            // m_panelPiecesJointes
            // 
            this.m_panelPiecesJointes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelPiecesJointes.AutoScroll = true;
            this.m_panelPiecesJointes.Location = new System.Drawing.Point(6, 22);
            this.m_panelPiecesJointes.Name = "m_panelPiecesJointes";
            this.m_panelPiecesJointes.Size = new System.Drawing.Size(649, 324);
            this.m_extStyle.SetStyleBackColor(this.m_panelPiecesJointes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelPiecesJointes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelPiecesJointes.TabIndex = 2;
            // 
            // m_lnkSupprimerPieceJointe
            // 
            this.m_lnkSupprimerPieceJointe.Location = new System.Drawing.Point(166, 3);
            this.m_lnkSupprimerPieceJointe.Name = "m_lnkSupprimerPieceJointe";
            this.m_lnkSupprimerPieceJointe.Size = new System.Drawing.Size(136, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSupprimerPieceJointe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSupprimerPieceJointe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSupprimerPieceJointe.TabIndex = 3;
            this.m_lnkSupprimerPieceJointe.TabStop = true;
            this.m_lnkSupprimerPieceJointe.Text = "Remove|18";
            this.m_lnkSupprimerPieceJointe.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkSupprimerPieceJointe_LinkClicked);
            // 
            // m_wndAideFormule
            // 
            this.m_wndAideFormule.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_wndAideFormule.FournisseurProprietes = null;
            this.m_wndAideFormule.Location = new System.Drawing.Point(665, 0);
            this.m_wndAideFormule.Name = "m_wndAideFormule";
            this.m_wndAideFormule.ObjetInterroge = null;
            this.m_wndAideFormule.SendIdChamps = false;
            this.m_wndAideFormule.Size = new System.Drawing.Size(192, 425);
            this.m_extStyle.SetStyleBackColor(this.m_wndAideFormule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndAideFormule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndAideFormule.TabIndex = 4;
            this.m_wndAideFormule.OnSendCommande += new sc2i.win32.expression.SendCommande(this.m_wndAideFormule_OnSendCommande);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(662, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 425);
            this.m_extStyle.SetStyleBackColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(250, 170);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 15);
            this.m_extStyle.SetStyleBackColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label11.TabIndex = 3;
            this.label11.Text = "Optionnel";
            // 
            // CFormEditActionEnvoyerMail
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(857, 473);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.m_wndAideFormule);
            this.Name = "CFormEditActionEnvoyerMail";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "Send an Email|1028";
            this.Controls.SetChildIndex(this.m_wndAideFormule, 0);
            this.Controls.SetChildIndex(this.splitter1, 0);
            this.Controls.SetChildIndex(this.m_tabControl, 0);
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// ////////////////////////////////////////////////////
		private CActionEnvoyerMail ActionEnvoyerMail
		{
			get
			{
				return (CActionEnvoyerMail)ObjetEdite;
			}
		}

		/// ////////////////////////////////////////////////////
		protected override void InitChamps()
		{
			base.InitChamps ();

			m_wndAideFormule.FournisseurProprietes = ActionEnvoyerMail.Process;
			m_wndAideFormule.ObjetInterroge = typeof(CProcess);

			m_txtExpediteur.Init(m_wndAideFormule.FournisseurProprietes, m_wndAideFormule.ObjetInterroge);
			m_txtSujet.Init(m_wndAideFormule.FournisseurProprietes, m_wndAideFormule.ObjetInterroge);
			m_txtMessage.Init(m_wndAideFormule.FournisseurProprietes, m_wndAideFormule.ObjetInterroge);

			if ( ActionEnvoyerMail.FormuleMailExpediteur != null )
				m_txtExpediteur.Text = ActionEnvoyerMail.FormuleMailExpediteur.GetString();
			else
				m_txtExpediteur.Text = "\"\"";

			if ( ActionEnvoyerMail.FormuleSujet != null )
				m_txtSujet.Text = ActionEnvoyerMail.FormuleSujet.GetString();
			else
				m_txtSujet.Text = "\"\"";

			if ( ActionEnvoyerMail.FormuleMessage != null )
				m_txtMessage.Text = ActionEnvoyerMail.FormuleMessage.GetString();
			else
				m_txtMessage.Text = "\"\"";

            m_chkFormatHTML.Checked = ActionEnvoyerMail.IsFormatHTML;
            m_chkUseDocLabel.Checked = ActionEnvoyerMail.UseDocLabelAsFileName;

            // Supprime tous les controles présents
			ArrayList lst = new ArrayList( m_panelDestinataires.Controls );
			foreach ( Control ctrl in lst )
			{
				if ( ctrl== m_txtFormule)
					m_txtFormule = null;
				ctrl.Hide();
				m_panelDestinataires.Controls.Remove ( ctrl );
				ctrl.Dispose();
			}

            lst = new ArrayList(m_panelDestinatairesCC.Controls);
            foreach (Control ctrl in lst)
            {
                if (ctrl == m_txtFormule)
                    m_txtFormule = null;
                ctrl.Hide();
                m_panelDestinatairesCC.Controls.Remove(ctrl);
                ctrl.Dispose();
            }

            lst = new ArrayList(m_panelDestinatairesBCC.Controls);
            foreach (Control ctrl in lst)
            {
                if (ctrl == m_txtFormule)
                    m_txtFormule = null;
                ctrl.Hide();
                m_panelDestinatairesBCC.Controls.Remove(ctrl);
                ctrl.Dispose();
            }

			lst = new ArrayList( m_panelPiecesJointes.Controls );
			foreach ( Control ctrl in lst )
			{
				if ( ctrl== m_txtFormule)
					m_txtFormule = null;
				ctrl.Hide();
				m_panelPiecesJointes.Controls.Remove ( ctrl );
				ctrl.Dispose();
				
			}

			foreach ( C2iExpression expression in ActionEnvoyerMail.ListeFormulesMailsDestinataires )
			{
				if ( expression != null )
				{
					AddTextBox ( m_panelDestinataires ).Text = expression.GetString();
				}
			}

            foreach (C2iExpression expression in ActionEnvoyerMail.ListeFormulesMailsDestinatairesCC)
            {
                if (expression != null)
                {
                    AddTextBox(m_panelDestinatairesCC).Text = expression.GetString();
                }
            }

            foreach (C2iExpression expression in ActionEnvoyerMail.ListeFormulesMailsDestinatairesBCC)
            {
                if (expression != null)
                {
                    AddTextBox(m_panelDestinatairesBCC).Text = expression.GetString();
                }
            }

			foreach ( C2iExpression expression in ActionEnvoyerMail.ListeFormulesPiecesJointes )
			{
				if ( expression != null )
				{
					AddTextBox ( m_panelPiecesJointes ).Text = expression.GetString();
				}
			}

            m_txtNomServeurSMTP.Text = ActionEnvoyerMail.SMTPserver;
            m_numPortSMTP.IntValue = ActionEnvoyerMail.SMTPort;
            m_txtUserSMTP.Text = ActionEnvoyerMail.SMTPUser;
            m_txtPasswordSMTP.Text = ActionEnvoyerMail.SMTPPassword;

		}

		/// ////////////////////////////////////////////////////
		protected override CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = base.MAJ_Champs();
			if ( !result )
				return result;
			CAnalyseurSyntaxiqueExpression analyseur = new CAnalyseurSyntaxiqueExpression ( 
				new CContexteAnalyse2iExpression ( ActionEnvoyerMail.Process, typeof(CProcess) ) );

			result &= analyseur.AnalyseChaine ( m_txtExpediteur.Text );
			if ( !result)
				result.EmpileErreur(I.T( "Error in the Sender formula|1047"));
			else
				ActionEnvoyerMail.FormuleMailExpediteur = (C2iExpression)result.Data;

			result &= analyseur.AnalyseChaine ( m_txtSujet.Text );
			if ( !result )
				result.EmpileErreur (I.T( "Error in the Object formula|1048"));
			else
				ActionEnvoyerMail.FormuleSujet = (C2iExpression)result.Data;

			result &= analyseur.AnalyseChaine ( m_txtMessage.Text );
			if ( !result )
				result.EmpileErreur (I.T( "Error in the message formula|1049"));
			else
				ActionEnvoyerMail.FormuleMessage = (C2iExpression)result.Data;

            // Ajout de l'option message au format HTML
            ActionEnvoyerMail.IsFormatHTML = m_chkFormatHTML.Checked;
            ActionEnvoyerMail.UseDocLabelAsFileName = m_chkUseDocLabel.Checked;

			// MAJ des Destinataires To
            ActionEnvoyerMail.ListeFormulesMailsDestinataires.Clear();
			foreach ( sc2i.win32.expression.CControleEditeFormule txt in m_panelDestinataires.Controls )
			{
				result &= analyseur.AnalyseChaine ( txt.Text );
				if ( !result )
					result.EmpileErreur(I.T( "Error in the recipient formula|1050"));
				else
					ActionEnvoyerMail.ListeFormulesMailsDestinataires.Add ( result.Data );
			}

            // MAJ des Destinataires CC
            ActionEnvoyerMail.ListeFormulesMailsDestinatairesCC.Clear();
            foreach (sc2i.win32.expression.CControleEditeFormule txt in m_panelDestinatairesCC.Controls)
            {
                result &= analyseur.AnalyseChaine(txt.Text);
                if (!result)
                    result.EmpileErreur(I.T("Error in the recipient formula|1050"));
                else
                    ActionEnvoyerMail.ListeFormulesMailsDestinatairesCC.Add(result.Data);
            }

            // MAJ des Destinataires BCC
            ActionEnvoyerMail.ListeFormulesMailsDestinatairesBCC.Clear();
            foreach (sc2i.win32.expression.CControleEditeFormule txt in m_panelDestinatairesBCC.Controls)
            {
                result &= analyseur.AnalyseChaine(txt.Text);
                if (!result)
                    result.EmpileErreur(I.T("Error in the recipient formula|1050"));
                else
                    ActionEnvoyerMail.ListeFormulesMailsDestinatairesBCC.Add(result.Data);
            }


			ActionEnvoyerMail.ListeFormulesPiecesJointes.Clear();
			foreach ( sc2i.win32.expression.CControleEditeFormule txt in m_panelPiecesJointes.Controls )
			{
				result &= analyseur.AnalyseChaine ( txt.Text );
				if ( !result )
					result.EmpileErreur(I.T( "Error in the attached files formula|1051"));
				else
					ActionEnvoyerMail.ListeFormulesPiecesJointes.Add ( result.Data );
			}

            ActionEnvoyerMail.SMTPserver = m_txtNomServeurSMTP.Text;
            ActionEnvoyerMail.SMTPort = m_numPortSMTP.IntValue != null ? m_numPortSMTP.IntValue.Value : 0;
            ActionEnvoyerMail.SMTPUser = m_txtUserSMTP.Text;
            ActionEnvoyerMail.SMTPPassword = m_txtPasswordSMTP.Text;

			return result;
		}

		//--------------------------------------------------------------------------------
		private void OnEnterTexteFormule(object sender, System.EventArgs e)
		{
			if ( m_txtFormule != null )
				m_txtFormule.BackColor = Color.White;

            m_txtFormule = sender as sc2i.win32.expression.CControleEditeFormule;
            if (m_txtFormule != null)
            {
                m_txtFormule.BackColor = Color.LightGreen;
            }
            //if ( sender is sc2i.win32.expression.CControleEditeFormule )
            //{
            //    m_txtFormule = (sc2i.win32.expression.CControleEditeFormule)sender;
            //    m_txtFormule.BackColor = Color.LightGreen;
            //}
		}

		//--------------------------------------------------------------------------------
		private void m_wndAideFormule_OnSendCommande(string strCommande, int nPosCurseur)
		{
			if ( m_txtFormule != null )
				m_wndAideFormule.InsereInTextBox ( m_txtFormule, nPosCurseur, strCommande );
		}

		//--------------------------------------------------------------------------------
		private sc2i.win32.expression.CControleEditeFormule AddTextBox ( Control parent )
		{
			sc2i.win32.expression.CControleEditeFormule txt = new sc2i.win32.expression.CControleEditeFormule();
			txt.Init(m_wndAideFormule.FournisseurProprietes, m_wndAideFormule.ObjetInterroge);
			txt.Height = 60;
			txt.Enter += new EventHandler(OnEnterTexteFormule);
			txt.CreateControl();
			parent.Controls.Add ( txt );
			txt.Dock = DockStyle.Top;
			return txt;
		}

		//--------------------------------------------------------------------------------
		private void m_lnkAjouter_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			AddTextBox ( m_panelDestinataires ).Text = "\"\"";
		}

		//--------------------------------------------------------------------------------
		private void m_lnkSupprimerDestinataire_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			if ( m_txtFormule != null &&
				m_txtFormule.Parent == m_panelDestinataires )
			{
				m_txtFormule.Hide();
				m_panelDestinataires.Controls.Remove ( m_txtFormule );
				m_txtFormule.Dispose();
			}
		}

		//--------------------------------------------------------------------------------
		private void m_lnkAjouterPieceJointe_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			AddTextBox ( m_panelPiecesJointes ).Text = "\"\"";
		}

		//--------------------------------------------------------------------------------
		private void m_lnkSupprimerPieceJointe_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			if ( m_txtFormule != null &&
				m_txtFormule.Parent == m_panelPiecesJointes )
			{
				m_txtFormule.Hide();
				m_panelPiecesJointes.Controls.Remove ( m_txtFormule );
				m_txtFormule.Dispose();
			}
		}

        private void c2iTabControl2_SelectionChanged(object sender, EventArgs e)
        {

        }


        //----------------------------------------------------------------------------------
        // Gestion des Carbone Copie
        private void m_lnkAjouterDestCC_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddTextBox(m_panelDestinatairesCC).Text = "\"\"";
        }

        private void m_lnkSupprimerCC_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (m_txtFormule != null &&
                m_txtFormule.Parent == m_panelDestinatairesCC)
            {
                m_txtFormule.Hide();
                m_panelDestinatairesCC.Controls.Remove(m_txtFormule);
                m_txtFormule.Dispose();
            }
        }

        //----------------------------------------------------------------------------------
        // Gestion des Blind Carbone Copie
        private void m_lnkAjouterDestBCC_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddTextBox(m_panelDestinatairesBCC).Text = "\"\"";
        }

        private void m_lnkSupprimerBCC_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (m_txtFormule != null &&
                m_txtFormule.Parent == m_panelDestinatairesBCC)
            {
                m_txtFormule.Hide();
                m_panelDestinatairesBCC.Controls.Remove(m_txtFormule);
                m_txtFormule.Dispose();
            }
        }
	}
}

