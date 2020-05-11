using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;

using sc2i.common;
using sc2i.multitiers.client;
using timos.client;
using sc2i.win32.common;
using System.Collections.Generic;
using System.Text;
using timos.acteurs;
using sc2i.workflow;
using sc2i.win32.data;

namespace timos.securite
{
	/// <summary>
	/// Description résumée de CFormConsoleSuivi.
	/// </summary>
	public class CFormConsoleSuivi : System.Windows.Forms.Form
	{
        
        private CRecepteurNotification m_recepteurMessage = null;
		private System.Windows.Forms.TabControl m_tabControl;
        private System.Windows.Forms.TabPage m_tabConnexions;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.PictureBox m_pictCurrent;
		private System.Windows.Forms.PictureBox m_pictInvalide;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel m_panelLegende;
        private System.Windows.Forms.LinkLabel m_lnkFermer;
        private CheckBox m_chkHideSystem;
        private ListViewAutoFilled m_wndListeSession;
        private List<CInfoSessionAsDynamicClass> m_listeSessions = new List<CInfoSessionAsDynamicClass>();
        private ListViewAutoFilledColumn listViewAutoFilledColumn1;
        private ListViewAutoFilledColumn listViewAutoFilledColumn2;
        private ListViewAutoFilledColumn listViewAutoFilledColumn3;
        private ListViewAutoFilledColumn listViewAutoFilledColumn4;
        private ListViewAutoFilledColumn listViewAutoFilledColumn5;
        private Panel panel1;
        private PictureBox m_btnCopier;
        private LinkLabel m_lnkCopier;
        private CControleChat m_controleChat;
        private Label label3;
        private PictureBox m_pictInactif;
        
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CFormConsoleSuivi()
		{
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			InitializeComponent();

			//
			// TODO : ajoutez le code du constructeur après l'appel à InitializeComponent
			//
            m_recepteurMessage = new CRecepteurNotification(CTimosApp.SessionClient.IdSession, typeof(CDonneeNotificationMessageInstantane));
            m_recepteurMessage.OnReceiveNotification += new NotificationEventHandler(m_recepteurMessage_OnReceiveNotification);
            m_controleChat.SetModeSansActeurEtSansClose();
            
		}

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
                if (m_recepteurMessage != null)
                    m_recepteurMessage.Dispose();
                m_recepteurMessage = null;
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormConsoleSuivi));
            this.m_tabControl = new System.Windows.Forms.TabControl();
            this.m_tabConnexions = new System.Windows.Forms.TabPage();
            this.m_wndListeSession = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn1 = ((sc2i.win32.common.ListViewAutoFilledColumn)(new sc2i.win32.common.ListViewAutoFilledColumn()));
            this.listViewAutoFilledColumn2 = ((sc2i.win32.common.ListViewAutoFilledColumn)(new sc2i.win32.common.ListViewAutoFilledColumn()));
            this.listViewAutoFilledColumn3 = ((sc2i.win32.common.ListViewAutoFilledColumn)(new sc2i.win32.common.ListViewAutoFilledColumn()));
            this.listViewAutoFilledColumn4 = ((sc2i.win32.common.ListViewAutoFilledColumn)(new sc2i.win32.common.ListViewAutoFilledColumn()));
            this.listViewAutoFilledColumn5 = ((sc2i.win32.common.ListViewAutoFilledColumn)(new sc2i.win32.common.ListViewAutoFilledColumn()));
            this.m_controleChat = new timos.CControleChat();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_lnkCopier = new System.Windows.Forms.LinkLabel();
            this.m_btnCopier = new System.Windows.Forms.PictureBox();
            this.m_lnkFermer = new System.Windows.Forms.LinkLabel();
            this.m_chkHideSystem = new System.Windows.Forms.CheckBox();
            this.m_panelLegende = new System.Windows.Forms.Panel();
            this.m_pictCurrent = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_pictInvalide = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_pictInactif = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.m_tabControl.SuspendLayout();
            this.m_tabConnexions.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnCopier)).BeginInit();
            this.m_panelLegende.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_pictCurrent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_pictInvalide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_pictInactif)).BeginInit();
            this.SuspendLayout();
            // 
            // m_tabControl
            // 
            this.m_tabControl.Controls.Add(this.m_tabConnexions);
            this.m_tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tabControl.Location = new System.Drawing.Point(0, 0);
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.Size = new System.Drawing.Size(867, 486);
            this.m_tabControl.TabIndex = 0;
            // 
            // m_tabConnexions
            // 
            this.m_tabConnexions.Controls.Add(this.m_wndListeSession);
            this.m_tabConnexions.Controls.Add(this.m_controleChat);
            this.m_tabConnexions.Controls.Add(this.panel1);
            this.m_tabConnexions.Location = new System.Drawing.Point(4, 22);
            this.m_tabConnexions.Name = "m_tabConnexions";
            this.m_tabConnexions.Size = new System.Drawing.Size(859, 460);
            this.m_tabConnexions.TabIndex = 0;
            this.m_tabConnexions.Text = "Connexions";
            this.m_tabConnexions.UseVisualStyleBackColor = true;
            // 
            // m_wndListeSession
            // 
            this.m_wndListeSession.CheckBoxes = true;
            this.m_wndListeSession.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn1,
            this.listViewAutoFilledColumn2,
            this.listViewAutoFilledColumn3,
            this.listViewAutoFilledColumn4,
            this.listViewAutoFilledColumn5});
            this.m_wndListeSession.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeSession.EnableCustomisation = true;
            this.m_wndListeSession.FullRowSelect = true;
            this.m_wndListeSession.Location = new System.Drawing.Point(0, 0);
            this.m_wndListeSession.MultiSelect = false;
            this.m_wndListeSession.Name = "m_wndListeSession";
            this.m_wndListeSession.Size = new System.Drawing.Size(661, 419);
            this.m_wndListeSession.TabIndex = 9;
            this.m_wndListeSession.UseCompatibleStateImageBehavior = false;
            this.m_wndListeSession.View = System.Windows.Forms.View.Details;
            this.m_wndListeSession.SelectedIndexChanged += new System.EventHandler(this.m_wndListeSession_SelectedIndexChanged);
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "IdSession";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0D;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Id|20498";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 59;
            // 
            // listViewAutoFilledColumn2
            // 
            this.listViewAutoFilledColumn2.Field = "NomUtilisateur";
            this.listViewAutoFilledColumn2.PrecisionWidth = 0D;
            this.listViewAutoFilledColumn2.ProportionnalSize = false;
            this.listViewAutoFilledColumn2.Text = "Name|20499";
            this.listViewAutoFilledColumn2.Visible = true;
            this.listViewAutoFilledColumn2.Width = 182;
            // 
            // listViewAutoFilledColumn3
            // 
            this.listViewAutoFilledColumn3.Field = "DateDebutConnexion";
            this.listViewAutoFilledColumn3.PrecisionWidth = 0D;
            this.listViewAutoFilledColumn3.ProportionnalSize = false;
            this.listViewAutoFilledColumn3.Text = "Connection date|20500";
            this.listViewAutoFilledColumn3.Visible = true;
            this.listViewAutoFilledColumn3.Width = 131;
            // 
            // listViewAutoFilledColumn4
            // 
            this.listViewAutoFilledColumn4.Field = "DureeConnexion";
            this.listViewAutoFilledColumn4.PrecisionWidth = 0D;
            this.listViewAutoFilledColumn4.ProportionnalSize = false;
            this.listViewAutoFilledColumn4.Text = "Connected since|20501";
            this.listViewAutoFilledColumn4.Visible = true;
            this.listViewAutoFilledColumn4.Width = 104;
            // 
            // listViewAutoFilledColumn5
            // 
            this.listViewAutoFilledColumn5.Field = "DureeInactivité";
            this.listViewAutoFilledColumn5.PrecisionWidth = 0D;
            this.listViewAutoFilledColumn5.ProportionnalSize = false;
            this.listViewAutoFilledColumn5.Text = "Inactive since|20502";
            this.listViewAutoFilledColumn5.Visible = true;
            this.listViewAutoFilledColumn5.Width = 103;
            // 
            // m_controleChat
            // 
            this.m_controleChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_controleChat.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_controleChat.ForeColor = System.Drawing.Color.Black;
            this.m_controleChat.Location = new System.Drawing.Point(661, 0);
            this.m_controleChat.Name = "m_controleChat";
            this.m_controleChat.Size = new System.Drawing.Size(198, 419);
            this.m_controleChat.TabIndex = 11;
            this.m_controleChat.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_lnkCopier);
            this.panel1.Controls.Add(this.m_btnCopier);
            this.panel1.Controls.Add(this.m_lnkFermer);
            this.panel1.Controls.Add(this.m_chkHideSystem);
            this.panel1.Controls.Add(this.m_panelLegende);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 419);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(859, 41);
            this.panel1.TabIndex = 10;
            // 
            // m_lnkCopier
            // 
            this.m_lnkCopier.AutoSize = true;
            this.m_lnkCopier.Location = new System.Drawing.Point(30, 27);
            this.m_lnkCopier.Name = "m_lnkCopier";
            this.m_lnkCopier.Size = new System.Drawing.Size(78, 13);
            this.m_lnkCopier.TabIndex = 12;
            this.m_lnkCopier.TabStop = true;
            this.m_lnkCopier.Text = "Copy list|20512";
            this.m_lnkCopier.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkCopier_LinkClicked);
            // 
            // m_btnCopier
            // 
            this.m_btnCopier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnCopier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnCopier.Image = ((System.Drawing.Image)(resources.GetObject("m_btnCopier.Image")));
            this.m_btnCopier.Location = new System.Drawing.Point(8, 25);
            this.m_btnCopier.Name = "m_btnCopier";
            this.m_btnCopier.Size = new System.Drawing.Size(15, 13);
            this.m_btnCopier.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.m_btnCopier.TabIndex = 11;
            this.m_btnCopier.TabStop = false;
            this.m_btnCopier.Click += new System.EventHandler(this.m_btnCopier_Click);
            // 
            // m_lnkFermer
            // 
            this.m_lnkFermer.Location = new System.Drawing.Point(3, 5);
            this.m_lnkFermer.Name = "m_lnkFermer";
            this.m_lnkFermer.Size = new System.Drawing.Size(211, 23);
            this.m_lnkFermer.TabIndex = 7;
            this.m_lnkFermer.TabStop = true;
            this.m_lnkFermer.Text = "Close selected sessions|20514";
            this.m_lnkFermer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkFermer_LinkClicked);
            // 
            // m_chkHideSystem
            // 
            this.m_chkHideSystem.AutoSize = true;
            this.m_chkHideSystem.Checked = true;
            this.m_chkHideSystem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkHideSystem.Location = new System.Drawing.Point(220, 4);
            this.m_chkHideSystem.Name = "m_chkHideSystem";
            this.m_chkHideSystem.Size = new System.Drawing.Size(158, 17);
            this.m_chkHideSystem.TabIndex = 8;
            this.m_chkHideSystem.Text = "Hide system sessions|20510";
            this.m_chkHideSystem.UseVisualStyleBackColor = true;
            this.m_chkHideSystem.CheckedChanged += new System.EventHandler(this.m_chkHideSystem_CheckedChanged);
            // 
            // m_panelLegende
            // 
            this.m_panelLegende.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelLegende.Controls.Add(this.m_pictCurrent);
            this.m_panelLegende.Controls.Add(this.label1);
            this.m_panelLegende.Controls.Add(this.m_pictInvalide);
            this.m_panelLegende.Controls.Add(this.label2);
            this.m_panelLegende.Controls.Add(this.m_pictInactif);
            this.m_panelLegende.Controls.Add(this.label3);
            this.m_panelLegende.Location = new System.Drawing.Point(448, 5);
            this.m_panelLegende.Name = "m_panelLegende";
            this.m_panelLegende.Size = new System.Drawing.Size(408, 16);
            this.m_panelLegende.TabIndex = 6;
            // 
            // m_pictCurrent
            // 
            this.m_pictCurrent.BackColor = System.Drawing.Color.LightGreen;
            this.m_pictCurrent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_pictCurrent.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_pictCurrent.Location = new System.Drawing.Point(34, 0);
            this.m_pictCurrent.Name = "m_pictCurrent";
            this.m_pictCurrent.Size = new System.Drawing.Size(16, 16);
            this.m_pictCurrent.TabIndex = 2;
            this.m_pictCurrent.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(50, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Current session|20503";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_pictInvalide
            // 
            this.m_pictInvalide.BackColor = System.Drawing.Color.Red;
            this.m_pictInvalide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_pictInvalide.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_pictInvalide.Location = new System.Drawing.Point(161, 0);
            this.m_pictInvalide.Name = "m_pictInvalide";
            this.m_pictInvalide.Size = new System.Drawing.Size(16, 16);
            this.m_pictInvalide.TabIndex = 3;
            this.m_pictInvalide.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(177, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Invalid session|20504";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_pictInactif
            // 
            this.m_pictInactif.BackColor = System.Drawing.Color.Yellow;
            this.m_pictInactif.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_pictInactif.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_pictInactif.Location = new System.Drawing.Point(285, 0);
            this.m_pictInactif.Name = "m_pictInactif";
            this.m_pictInactif.Size = new System.Drawing.Size(16, 16);
            this.m_pictInactif.TabIndex = 6;
            this.m_pictInactif.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(301, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Long inactivity|20513";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.linkLabel1.Location = new System.Drawing.Point(0, 486);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(867, 16);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Refresh|20505";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // CFormConsoleSuivi
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(867, 502);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.linkLabel1);
            this.Name = "CFormConsoleSuivi";
            this.Text = "Session manager|20497";
            this.Closed += new System.EventHandler(this.CFormConsoleSuivi_Closed);
            this.Load += new System.EventHandler(this.CFormConsoleSuivi_Load);
            this.m_tabControl.ResumeLayout(false);
            this.m_tabConnexions.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnCopier)).EndInit();
            this.m_panelLegende.ResumeLayout(false);
            this.m_panelLegende.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_pictCurrent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_pictInvalide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_pictInactif)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion


        public static void GererSessions()
        {
            try
            {
                if (CTimosApp.SessionClient.GetInfoUtilisateur().GetDonneeDroit(CDroitDeBase.c_droitBaseGestionSessions) != null)
                {
                    CFormConsoleSuivi form = new CFormConsoleSuivi();
                    form.ShowDialog();
                    form.Dispose();
                    return;
                }
            }
            catch { }
            MessageBox.Show(I.T("You are not allowed to manage sessions|20520"));
        }

		private void CFormConsoleSuivi_Load(object sender, System.EventArgs e)
		{
            CWin32Traducteur.Translate(this);
			RefreshAll();
			
		}

		private void RefreshAll()
		{
			FillListeConnectes();
		}

        

		private void FillListeConnectes()
		{
			IGestionnaireSessions gestionnaire = (IGestionnaireSessions)C2iFactory.GetNewObject(typeof(IGestionnaireSessions));
            CInfoSessionAsDynamicClass[] sessions = gestionnaire.GetInfosSessionsActives();
            m_listeSessions = new List<CInfoSessionAsDynamicClass>();
            foreach (CInfoSessionAsDynamicClass session in sessions)
            {
                if (!session.IsSystem || !m_chkHideSystem.Checked)
                    m_listeSessions.Add(session);
            }

            m_wndListeSession.Remplir ( m_listeSessions, false );
            foreach (ListViewItem item in m_wndListeSession.Items)
            {
                CInfoSessionAsDynamicClass info = item.Tag as CInfoSessionAsDynamicClass;
                if (info != null && info.Invalide)
                    item.BackColor = m_pictInvalide.BackColor;
                if (info != null && info.IdSession == CTimosApp.SessionClient.IdSession)
                    item.BackColor = m_pictCurrent.BackColor;
                if ( info != null && info.DureeInactivité.Duree.Hours >= 4 )
                    item.BackColor = m_pictInactif.BackColor;
            }
		}

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			RefreshAll();
		}

		private void CFormConsoleSuivi_Closed(object sender, System.EventArgs e)
		{
		}


		private ArrayList m_listeServicesToLaunch = new ArrayList();
		private void AskForClose()
		{
			CServiceSurClient service = null;
			lock ( m_listeServicesToLaunch )
			{
				service = (CServiceSurClient)m_listeServicesToLaunch[0];
				m_listeServicesToLaunch.RemoveAt(0);
			}
			C2iSponsor sponsor = new C2iSponsor();
			sponsor.Register ( service );
				
			CResultAErreur result = service.RunService(null);
		}

		ArrayList m_listeThreadsEnAttente = new ArrayList();
		private void m_lnkFermer_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
            if ( m_wndListeSession.CheckedItems.Count == 0 )
            {
                MessageBox.Show(I.T("Check sessions to close first !|20519"));
                return;
            }
			if ( MessageBox.Show(
                I.T("You will send a stop message to @1 sessions. Please confirm this action|20515",
                m_wndListeSession.CheckedItems.Count.ToString()),
                I.T("Confirmation|20516"),
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question ) == DialogResult.No )
				return;
            ArrayList lstThreads = new ArrayList();
			m_listeServicesToLaunch.Clear();
			m_listeThreadsEnAttente.Clear();
			ThreadStart funcStart = new ThreadStart(AskForClose);
            StringBuilder bl = new StringBuilder();
            int nNbSessionsSysteme = 0;
            foreach (ListViewItem item in m_wndListeSession.CheckedItems)
            {
                CInfoSessionAsDynamicClass info = item.Tag as CInfoSessionAsDynamicClass;
                if (info != null && info.IsSystem)
                {
                    nNbSessionsSysteme++;
                    bl.Append(info.IdSession);
                    bl.Append(',');
                }
            }
            string strMessage = "";
            if ( nNbSessionsSysteme > 0 )
            {
                bl.Remove ( bl.Length -1, 1 );
                if ( nNbSessionsSysteme > 1 )
                    strMessage = I.T("Sessions @1 are system sessions and will not be close|20517",
                        bl.ToString());
                else
                    strMessage = I.T("@1 session is a system session and will not be closed|20518",
                        bl.ToString());
                MessageBox.Show ( strMessage );
            }

            IGestionnaireSessions gestionnaire = (IGestionnaireSessions)C2iFactory.GetNewObject(typeof(IGestionnaireSessions));

            foreach ( ListViewItem item in m_wndListeSession.CheckedItems )
            {
                CInfoSessionAsDynamicClass info = item.Tag as CInfoSessionAsDynamicClass;
                if (info != null && !info.IsSystem)
                {
                    int nIdSession = info.IdSession;
                    CSessionClient session = CSessionClient.GetSessionForIdSession(nIdSession);
                    try
                    {
                        if (!info.Invalide)
                        {
                            CServiceSurClientFermerApplication service = (CServiceSurClientFermerApplication)session.GetServiceSurClient(CServiceSurClientFermerApplication.c_idService);
                            if (service != null)
                            {
                                lock (m_listeServicesToLaunch)
                                {
                                    m_listeServicesToLaunch.Add(service);
                                }
                                Thread th = new Thread(funcStart);
                                th.Start();
                            }
                        }
                        else
                        {
                            ISessionClientSurServeur sessionSurServeur = gestionnaire.GetSessionClientSurServeur(info.IdSession);
                            sessionSurServeur.CloseSession();
                        }
                    }
                    catch
                    {
                    }
                }
			}
		}

        //--------------------------------------------------------------------------
        private void m_chkHideSystem_CheckedChanged(object sender, EventArgs e)
        {
            FillListeConnectes();
        }

        //--------------------------------------------------------------------------
        private void m_btnCopier_Click(object sender, EventArgs e)
        {
            CopierListe();              
        }
        //--------------------------------------------------------------------------
        private void CopierListe()
        {
            StringBuilder bl = new StringBuilder();
            foreach (ListViewAutoFilledColumn col in m_wndListeSession.Colonnes)
            {
                bl.Append(col.Text);
                bl.Append('\t');
            }
            bl.Append(Environment.NewLine);
            foreach (ListViewItem item in m_wndListeSession.Items)
            {
                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                {
                    bl.Append(subItem.Text);
                    bl.Append('\t');
                }
                bl.Append(Environment.NewLine);
            }
            Clipboard.SetText(bl.ToString());
        }

        //--------------------------------------------------------------------------
        private void m_lnkCopier_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CopierListe();
        }

        //------------------------------------------------------
        private void m_recepteurMessage_OnReceiveNotification(IDonneeNotification donnee)
        {
            if (donnee is CDonneeNotificationMessageInstantane)
            {
                CDonneeNotificationMessageInstantane message = (CDonneeNotificationMessageInstantane)donnee;
                try
                {
                    if (message.KeyUtilisateurDestinataire == CTimosApp.SessionClient.GetInfoUtilisateur().KeyUtilisateur)
                    {
                        m_controleChat.OnMessage(message.IdEnvoyeur, message.Message);
                    }
                }
                catch
                {
                }
            }
        }

        //------------------------------------------------------
        private void m_wndListeSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_wndListeSession.SelectedItems.Count == 1)
            {
                ListViewItem item = m_wndListeSession.SelectedItems[0];
                CInfoSessionAsDynamicClass info = item.Tag as CInfoSessionAsDynamicClass;
                if (info != null && info.KeyUtilisateur != null)
                {
                    //TESTDBKEYOK
                    int? nId = CSc2iWin32DataClient.ContexteCourant.GetIdFromKey<CDonneesActeurUtilisateur>(info.KeyUtilisateur);
                    if (nId != null)
                    {
                        m_controleChat.OnMessage(nId.Value, null);
                        m_controleChat.Visible = true;
                    }
                }
                else
                    m_controleChat.Visible = false;
            }
        }

	}
}
