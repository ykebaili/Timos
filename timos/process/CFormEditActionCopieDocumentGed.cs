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
using sc2i.win32.data;

namespace sc2i.win32.process
{
	[AutoExec("Autoexec")]
	public class CFormEditActionCopierDocumentGed : sc2i.win32.process.CFormEditObjetDeProcess
	{
		private sc2i.win32.expression.CControleEditeFormule m_txtFormule = null;

		private sc2i.win32.common.C2iTabControl c2iTabControl1;
		private sc2i.win32.common.C2iTabControl c2iTabControl2;
		private Crownwood.Magic.Controls.TabPage tabPage1;
		private sc2i.win32.expression.CControlAideFormule m_wndAideFormule;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private sc2i.win32.expression.CControleEditeFormule m_txtFormuleNomFichier;
		private sc2i.win32.expression.CControleEditeFormule m_txtFormuleNomFichierRenommage;
		private sc2i.win32.expression.CControleEditeFormule m_txtFormuleDocument;
        private sc2i.win32.common.CExtStyle m_ExtStyle;
        private CheckBox m_chkSurPosteClient;
        private expression.CTextBoxZoomFormule m_txtFormulePassword;
        private expression.CTextBoxZoomFormule m_txtFormuleUser;
        private Label label5;
        private Label label1;
		private System.ComponentModel.IContainer components = null;

		public CFormEditActionCopierDocumentGed()
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
			CEditeurActionsEtLiens.RegisterEditeur ( typeof(CActionCopieDocumentGed), typeof(CFormEditActionCopierDocumentGed));
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
            this.c2iTabControl2 = new sc2i.win32.common.C2iTabControl(this.components);
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.m_chkSurPosteClient = new System.Windows.Forms.CheckBox();
            this.m_txtFormuleNomFichier = new sc2i.win32.expression.CControleEditeFormule();
            this.m_txtFormuleNomFichierRenommage = new sc2i.win32.expression.CControleEditeFormule();
            this.m_txtFormuleDocument = new sc2i.win32.expression.CControleEditeFormule();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_wndAideFormule = new sc2i.win32.expression.CControlAideFormule();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_ExtStyle = new sc2i.win32.common.CExtStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtFormuleUser = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.m_txtFormulePassword = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.c2iTabControl2.SuspendLayout();
            this.tabPage1.SuspendLayout();
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
            this.m_ExtStyle.SetStyleBackColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_ExtStyle.SetStyleForeColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTexteFenetre);
            this.c2iTabControl1.TabIndex = 2;
            this.c2iTabControl1.TextColor = System.Drawing.Color.Black;
            // 
            // c2iTabControl2
            // 
            this.c2iTabControl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iTabControl2.BoldSelectedPage = true;
            this.c2iTabControl2.ControlBottomOffset = 16;
            this.c2iTabControl2.ControlRightOffset = 16;
            this.c2iTabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c2iTabControl2.ForeColor = System.Drawing.Color.Black;
            this.c2iTabControl2.IDEPixelArea = false;
            this.c2iTabControl2.Location = new System.Drawing.Point(0, 0);
            this.c2iTabControl2.Name = "c2iTabControl2";
            this.c2iTabControl2.Ombre = true;
            this.c2iTabControl2.PositionTop = true;
            this.c2iTabControl2.SelectedIndex = 0;
            this.c2iTabControl2.SelectedTab = this.tabPage1;
            this.c2iTabControl2.Size = new System.Drawing.Size(549, 480);
            this.m_ExtStyle.SetStyleBackColor(this.c2iTabControl2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_ExtStyle.SetStyleForeColor(this.c2iTabControl2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTexteFenetre);
            this.c2iTabControl2.TabIndex = 3;
            this.c2iTabControl2.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1});
            this.c2iTabControl2.TextColor = System.Drawing.Color.Black;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_txtFormulePassword);
            this.tabPage1.Controls.Add(this.m_txtFormuleUser);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.m_chkSurPosteClient);
            this.tabPage1.Controls.Add(this.m_txtFormuleNomFichier);
            this.tabPage1.Controls.Add(this.m_txtFormuleNomFichierRenommage);
            this.tabPage1.Controls.Add(this.m_txtFormuleDocument);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(533, 439);
            this.m_ExtStyle.SetStyleBackColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage1.TabIndex = 10;
            this.tabPage1.Title = "Copy|25";
            // 
            // m_chkSurPosteClient
            // 
            this.m_chkSurPosteClient.AutoSize = true;
            this.m_chkSurPosteClient.Location = new System.Drawing.Point(208, 108);
            this.m_chkSurPosteClient.Name = "m_chkSurPosteClient";
            this.m_chkSurPosteClient.Size = new System.Drawing.Size(191, 19);
            this.m_ExtStyle.SetStyleBackColor(this.m_chkSurPosteClient, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_chkSurPosteClient, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkSurPosteClient.TabIndex = 6;
            this.m_chkSurPosteClient.Text = "Copy on client computer|20124";
            this.m_chkSurPosteClient.UseVisualStyleBackColor = true;
            this.m_chkSurPosteClient.CheckedChanged += new System.EventHandler(this.m_chkSurPosteClient_CheckedChanged);
            // 
            // m_txtFormuleNomFichier
            // 
            this.m_txtFormuleNomFichier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormuleNomFichier.BackColor = System.Drawing.Color.White;
            this.m_txtFormuleNomFichier.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtFormuleNomFichier.Formule = null;
            this.m_txtFormuleNomFichier.Location = new System.Drawing.Point(8, 128);
            this.m_txtFormuleNomFichier.LockEdition = false;
            this.m_txtFormuleNomFichier.Name = "m_txtFormuleNomFichier";
            this.m_txtFormuleNomFichier.Size = new System.Drawing.Size(520, 91);
            this.m_ExtStyle.SetStyleBackColor(this.m_txtFormuleNomFichier, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_txtFormuleNomFichier, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleNomFichier.TabIndex = 5;
            this.m_txtFormuleNomFichier.Enter += new System.EventHandler(this.OnEnterTexteFormule);
            // 
            // m_txtFormuleNomFichierRenommage
            // 
            this.m_txtFormuleNomFichierRenommage.BackColor = System.Drawing.Color.White;
            this.m_txtFormuleNomFichierRenommage.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtFormuleNomFichierRenommage.Formule = null;
            this.m_txtFormuleNomFichierRenommage.Location = new System.Drawing.Point(8, 240);
            this.m_txtFormuleNomFichierRenommage.LockEdition = false;
            this.m_txtFormuleNomFichierRenommage.Name = "m_txtFormuleNomFichierRenommage";
            this.m_txtFormuleNomFichierRenommage.Size = new System.Drawing.Size(520, 88);
            this.m_ExtStyle.SetStyleBackColor(this.m_txtFormuleNomFichierRenommage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_txtFormuleNomFichierRenommage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleNomFichierRenommage.TabIndex = 4;
            this.m_txtFormuleNomFichierRenommage.Enter += new System.EventHandler(this.OnEnterTexteFormule);
            // 
            // m_txtFormuleDocument
            // 
            this.m_txtFormuleDocument.BackColor = System.Drawing.Color.White;
            this.m_txtFormuleDocument.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtFormuleDocument.Formule = null;
            this.m_txtFormuleDocument.Location = new System.Drawing.Point(8, 24);
            this.m_txtFormuleDocument.LockEdition = false;
            this.m_txtFormuleDocument.Name = "m_txtFormuleDocument";
            this.m_txtFormuleDocument.Size = new System.Drawing.Size(520, 80);
            this.m_ExtStyle.SetStyleBackColor(this.m_txtFormuleDocument, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_txtFormuleDocument, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleDocument.TabIndex = 3;
            this.m_txtFormuleDocument.Enter += new System.EventHandler(this.OnEnterTexteFormule);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(408, 16);
            this.m_ExtStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 2;
            this.label4.Text = "Rename existing file as (not applicable on client or FTP)|1018";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 17);
            this.m_ExtStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 1;
            this.label3.Text = "File name|1017";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(248, 13);
            this.m_ExtStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 0;
            this.label2.Text = "Source document to copy (use ftp:// for ftp)|844";
            // 
            // m_wndAideFormule
            // 
            this.m_wndAideFormule.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_wndAideFormule.FournisseurProprietes = null;
            this.m_wndAideFormule.Location = new System.Drawing.Point(552, 0);
            this.m_wndAideFormule.Name = "m_wndAideFormule";
            this.m_wndAideFormule.ObjetInterroge = null;
            this.m_wndAideFormule.SendIdChamps = false;
            this.m_wndAideFormule.Size = new System.Drawing.Size(192, 480);
            this.m_ExtStyle.SetStyleBackColor(this.m_wndAideFormule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_wndAideFormule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndAideFormule.TabIndex = 4;
            this.m_wndAideFormule.OnSendCommande += new sc2i.win32.expression.SendCommande(this.m_wndAideFormule_OnSendCommande);
            this.m_wndAideFormule.Load += new System.EventHandler(this.m_wndAideFormule_Load);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(549, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 480);
            this.m_ExtStyle.SetStyleBackColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 331);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 21);
            this.m_ExtStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 7;
            this.label1.Text = "User name (for FTP)|20884";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 359);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(177, 21);
            this.m_ExtStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 7;
            this.label5.Text = "Password (for FTP)|20885";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtFormuleUser
            // 
            this.m_txtFormuleUser.AllowGraphic = true;
            this.m_txtFormuleUser.AllowNullFormula = true;
            this.m_txtFormuleUser.AllowSaisieTexte = true;
            this.m_txtFormuleUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormuleUser.Formule = null;
            this.m_txtFormuleUser.Location = new System.Drawing.Point(189, 331);
            this.m_txtFormuleUser.LockEdition = false;
            this.m_txtFormuleUser.LockZoneTexte = false;
            this.m_txtFormuleUser.Name = "m_txtFormuleUser";
            this.m_txtFormuleUser.Size = new System.Drawing.Size(339, 22);
            this.m_ExtStyle.SetStyleBackColor(this.m_txtFormuleUser, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_txtFormuleUser, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleUser.TabIndex = 8;
            // 
            // m_txtFormulePassword
            // 
            this.m_txtFormulePassword.AllowGraphic = true;
            this.m_txtFormulePassword.AllowNullFormula = true;
            this.m_txtFormulePassword.AllowSaisieTexte = true;
            this.m_txtFormulePassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormulePassword.Formule = null;
            this.m_txtFormulePassword.Location = new System.Drawing.Point(189, 359);
            this.m_txtFormulePassword.LockEdition = false;
            this.m_txtFormulePassword.LockZoneTexte = false;
            this.m_txtFormulePassword.Name = "m_txtFormulePassword";
            this.m_txtFormulePassword.Size = new System.Drawing.Size(339, 22);
            this.m_ExtStyle.SetStyleBackColor(this.m_txtFormulePassword, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this.m_txtFormulePassword, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormulePassword.TabIndex = 9;
            // 
            // CFormEditActionCopierDocumentGed
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(744, 480);
            this.Controls.Add(this.c2iTabControl2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.m_wndAideFormule);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CFormEditActionCopierDocumentGed";
            this.m_ExtStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ExtStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "EDM document copy|1015";
            this.Controls.SetChildIndex(this.m_wndAideFormule, 0);
            this.Controls.SetChildIndex(this.splitter1, 0);
            this.Controls.SetChildIndex(this.c2iTabControl2, 0);
            this.c2iTabControl2.ResumeLayout(false);
            this.c2iTabControl2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// ////////////////////////////////////////////////////
		private CActionCopieDocumentGed ActionCopierDocumentGed
		{
			get
			{
				return (CActionCopieDocumentGed)ObjetEdite;
			}
		}

		/// ////////////////////////////////////////////////////
		protected override void InitChamps()
		{
			base.InitChamps ();

			m_wndAideFormule.FournisseurProprietes = ActionCopierDocumentGed.Process;
			m_wndAideFormule.ObjetInterroge = typeof(CProcess);

			m_txtFormuleDocument.Init(m_wndAideFormule.FournisseurProprietes, m_wndAideFormule.ObjetInterroge);
			m_txtFormuleNomFichier.Init(m_wndAideFormule.FournisseurProprietes, m_wndAideFormule.ObjetInterroge);
			m_txtFormuleNomFichierRenommage.Init(m_wndAideFormule.FournisseurProprietes, m_wndAideFormule.ObjetInterroge);
            m_txtFormuleUser.Init(m_wndAideFormule.FournisseurProprietes, m_wndAideFormule.ObjetInterroge);
            m_txtFormulePassword.Init(m_wndAideFormule.FournisseurProprietes, m_wndAideFormule.ObjetInterroge);

			if ( ActionCopierDocumentGed.FormuleDocument != null )
				m_txtFormuleDocument.Text = ActionCopierDocumentGed.FormuleDocument.GetString();
			else
				m_txtFormuleDocument.Text = "";

			if ( ActionCopierDocumentGed.FormuleNomFichier!= null )
				m_txtFormuleNomFichier.Text = ActionCopierDocumentGed.FormuleNomFichier.GetString();
			else
				m_txtFormuleNomFichier.Text = "";

			if ( ActionCopierDocumentGed.FormuleNomFichierRenommage!= null )
				m_txtFormuleNomFichierRenommage.Text = ActionCopierDocumentGed.FormuleNomFichierRenommage.GetString();
			else
				m_txtFormuleNomFichierRenommage.Text = "";
            m_txtFormuleUser.Formule = ActionCopierDocumentGed.FormuleUser;
            m_txtFormulePassword.Formule = ActionCopierDocumentGed.FormulePassword;

            m_chkSurPosteClient.Checked = ActionCopierDocumentGed.CopierDepuisLePosteClient;

			
		}

		/// ////////////////////////////////////////////////////
		protected override CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = base.MAJ_Champs();
			if ( !result )
				return result;
			CAnalyseurSyntaxiqueExpression analyseur = new CAnalyseurSyntaxiqueExpression ( 
				new CContexteAnalyse2iExpression ( ActionCopierDocumentGed.Process, typeof(CProcess) ) );

			result = analyseur.AnalyseChaine ( m_txtFormuleNomFichier.Text );
			if ( !result)
			{
				result.EmpileErreur(I.T( "Error in source file name formula|1019"));
				return result;
			}
			else
				ActionCopierDocumentGed.FormuleNomFichier = (C2iExpression)result.Data;

			if ( m_txtFormuleNomFichierRenommage.Text != "" )
			{
				result = analyseur.AnalyseChaine ( m_txtFormuleNomFichierRenommage.Text );
				if ( !result )
				{
					result.EmpileErreur (I.T( "Error in renaming formula|1020"));
					return result;
				}
				else
					ActionCopierDocumentGed.FormuleNomFichierRenommage = (C2iExpression)result.Data;
			}

			result = analyseur.AnalyseChaine ( m_txtFormuleDocument.Text );
			if ( !result )
			{
                result.EmpileErreur(I.T( "Error in document formula|1021"));
				return result;
			}
			else
				ActionCopierDocumentGed.FormuleDocument = (C2iExpression)result.Data;

            ActionCopierDocumentGed.CopierDepuisLePosteClient = m_chkSurPosteClient.Checked;

            if (m_txtFormuleUser.Formule == null && !m_txtFormuleUser.ResultAnalyse)
                result.EmpileErreur(m_txtFormuleUser.ResultAnalyse.Erreur);
            else
                ActionCopierDocumentGed.FormuleUser = m_txtFormuleUser.Formule;
            if (m_txtFormulePassword.Formule == null && !m_txtFormulePassword.ResultAnalyse)
                result.EmpileErreur(m_txtFormulePassword.ResultAnalyse.Erreur);
            else
                ActionCopierDocumentGed.FormulePassword = m_txtFormulePassword.Formule;

			return result;
		}

		//--------------------------------------------------------------------------------
		private void OnEnterTexteFormule(object sender, System.EventArgs e)
		{
			if ( m_txtFormule != null )
				m_txtFormule.BackColor = Color.White;
			if ( sender is sc2i.win32.expression.CControleEditeFormule )
			{
				m_txtFormule = (sc2i.win32.expression.CControleEditeFormule)sender;
				m_txtFormule.BackColor = Color.LightGreen;
			}
		}

		//--------------------------------------------------------------------------------
		private void m_wndAideFormule_OnSendCommande(string strCommande, int nPosCurseur)
		{
			if ( m_txtFormule != null )
				m_wndAideFormule.InsereInTextBox ( m_txtFormule, nPosCurseur, strCommande );
		}

        //-------------------------------------------------------------------------------
        private void m_wndAideFormule_Load(object sender, EventArgs e)
        {
            sc2i.win32.common.CWin32Traducteur.Translate(this);
        }

        private void m_chkSurPosteClient_CheckedChanged(object sender, EventArgs e)
        {
            m_txtFormuleNomFichierRenommage.Enabled = !m_chkSurPosteClient.Checked;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

	}
}

