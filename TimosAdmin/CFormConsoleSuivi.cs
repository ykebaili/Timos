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
using System.Collections.Generic;
using timos.acteurs;
using timos.securite;
using sc2i.workflow;
using sc2i.data;

namespace TimosAdmin
{
	/// <summary>
	/// Description résumée de CFormConsoleSuivi.
	/// </summary>
	public class CFormConsoleSuivi : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TabControl m_tabControl;
		private System.Windows.Forms.TabPage m_tabConnexions;
		private System.Windows.Forms.ListView m_listView;
		private System.Windows.Forms.ColumnHeader colIdSession;
		private System.Windows.Forms.ColumnHeader colNom;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel m_panelLegende;
		private System.Windows.Forms.ColumnHeader colAppli;
		private System.Windows.Forms.ColumnHeader colType;
		private System.Windows.Forms.ColumnHeader colHeure;
		private System.Windows.Forms.TabPage m_tabNotifications;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label m_labelNbRecepteursNotification;
		private System.Windows.Forms.LinkLabel m_lnkFermer;
        private Panel m_panelTop;
        private Label label5;
        private Label label4;
        private Label label6;
        private LinkLabel m_lnkOuvrir;
        private TextBox m_txtLogin;
        private TextBox m_txtPassword;
        private ColumnHeader colIdUser;
        private ColumnHeader colNbToDo;

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

		#region Windows Form Designer generated code
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.m_tabControl = new System.Windows.Forms.TabControl();
            this.m_tabConnexions = new System.Windows.Forms.TabPage();
            this.m_lnkFermer = new System.Windows.Forms.LinkLabel();
            this.m_panelLegende = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_listView = new System.Windows.Forms.ListView();
            this.colIdSession = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAppli = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeure = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.m_tabNotifications = new System.Windows.Forms.TabPage();
            this.m_labelNbRecepteursNotification = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.m_panelTop = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_txtLogin = new System.Windows.Forms.TextBox();
            this.m_txtPassword = new System.Windows.Forms.TextBox();
            this.m_lnkOuvrir = new System.Windows.Forms.LinkLabel();
            this.colIdUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNbToDo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.m_tabControl.SuspendLayout();
            this.m_tabConnexions.SuspendLayout();
            this.m_panelLegende.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.m_tabNotifications.SuspendLayout();
            this.m_panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_tabControl
            // 
            this.m_tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_tabControl.Controls.Add(this.m_tabConnexions);
            this.m_tabControl.Controls.Add(this.m_tabNotifications);
            this.m_tabControl.Location = new System.Drawing.Point(8, 125);
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.Size = new System.Drawing.Size(682, 375);
            this.m_tabControl.TabIndex = 0;
            // 
            // m_tabConnexions
            // 
            this.m_tabConnexions.Controls.Add(this.m_lnkFermer);
            this.m_tabConnexions.Controls.Add(this.m_panelLegende);
            this.m_tabConnexions.Controls.Add(this.m_listView);
            this.m_tabConnexions.Location = new System.Drawing.Point(4, 22);
            this.m_tabConnexions.Name = "m_tabConnexions";
            this.m_tabConnexions.Size = new System.Drawing.Size(674, 349);
            this.m_tabConnexions.TabIndex = 0;
            this.m_tabConnexions.Text = "Connexions";
            // 
            // m_lnkFermer
            // 
            this.m_lnkFermer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkFermer.Location = new System.Drawing.Point(8, 319);
            this.m_lnkFermer.Name = "m_lnkFermer";
            this.m_lnkFermer.Size = new System.Drawing.Size(184, 23);
            this.m_lnkFermer.TabIndex = 7;
            this.m_lnkFermer.TabStop = true;
            this.m_lnkFermer.Text = "Fermer les sessions";
            this.m_lnkFermer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkFermer_LinkClicked);
            // 
            // m_panelLegende
            // 
            this.m_panelLegende.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelLegende.Controls.Add(this.label1);
            this.m_panelLegende.Controls.Add(this.pictureBox1);
            this.m_panelLegende.Controls.Add(this.pictureBox2);
            this.m_panelLegende.Controls.Add(this.label2);
            this.m_panelLegende.Location = new System.Drawing.Point(402, 327);
            this.m_panelLegende.Name = "m_panelLegende";
            this.m_panelLegende.Size = new System.Drawing.Size(264, 16);
            this.m_panelLegende.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(72, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cette session";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LightGreen;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(56, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Red;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(160, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(176, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ne répond plus";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_listView
            // 
            this.m_listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_listView.CheckBoxes = true;
            this.m_listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colIdSession,
            this.colNom,
            this.colIdUser,
            this.colAppli,
            this.colType,
            this.colHeure,
            this.colNbToDo});
            this.m_listView.FullRowSelect = true;
            this.m_listView.Location = new System.Drawing.Point(8, 16);
            this.m_listView.Name = "m_listView";
            this.m_listView.Size = new System.Drawing.Size(658, 295);
            this.m_listView.TabIndex = 0;
            this.m_listView.UseCompatibleStateImageBehavior = false;
            this.m_listView.View = System.Windows.Forms.View.Details;
            // 
            // colIdSession
            // 
            this.colIdSession.Text = "Id session";
            // 
            // colNom
            // 
            this.colNom.Text = "Nom";
            this.colNom.Width = 200;
            // 
            // colAppli
            // 
            this.colAppli.Text = "Application";
            this.colAppli.Width = 130;
            // 
            // colType
            // 
            this.colType.Text = "Type";
            // 
            // colHeure
            // 
            this.colHeure.Text = "Heure";
            this.colHeure.Width = 80;
            // 
            // m_tabNotifications
            // 
            this.m_tabNotifications.Controls.Add(this.m_labelNbRecepteursNotification);
            this.m_tabNotifications.Controls.Add(this.label3);
            this.m_tabNotifications.Location = new System.Drawing.Point(4, 22);
            this.m_tabNotifications.Name = "m_tabNotifications";
            this.m_tabNotifications.Size = new System.Drawing.Size(565, 403);
            this.m_tabNotifications.TabIndex = 1;
            this.m_tabNotifications.Text = "Notifications";
            // 
            // m_labelNbRecepteursNotification
            // 
            this.m_labelNbRecepteursNotification.BackColor = System.Drawing.Color.White;
            this.m_labelNbRecepteursNotification.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_labelNbRecepteursNotification.Location = new System.Drawing.Point(168, 8);
            this.m_labelNbRecepteursNotification.Name = "m_labelNbRecepteursNotification";
            this.m_labelNbRecepteursNotification.Size = new System.Drawing.Size(72, 16);
            this.m_labelNbRecepteursNotification.TabIndex = 1;
            this.m_labelNbRecepteursNotification.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nombre de recepteurs inscrits ";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.Location = new System.Drawing.Point(618, 500);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(72, 16);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Rafraichir";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // m_panelTop
            // 
            this.m_panelTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelTop.Controls.Add(this.m_lnkOuvrir);
            this.m_panelTop.Controls.Add(this.m_txtLogin);
            this.m_panelTop.Controls.Add(this.m_txtPassword);
            this.m_panelTop.Controls.Add(this.label6);
            this.m_panelTop.Controls.Add(this.label5);
            this.m_panelTop.Controls.Add(this.label4);
            this.m_panelTop.Location = new System.Drawing.Point(12, 12);
            this.m_panelTop.Name = "m_panelTop";
            this.m_panelTop.Size = new System.Drawing.Size(676, 100);
            this.m_panelTop.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ouvrir une session Timos";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(34, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 21);
            this.label5.TabIndex = 1;
            this.label5.Text = "Utilisateur";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(34, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 21);
            this.label6.TabIndex = 1;
            this.label6.Text = "Mot de passe";
            // 
            // m_txtLogin
            // 
            this.m_txtLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtLogin.Location = new System.Drawing.Point(141, 30);
            this.m_txtLogin.Name = "m_txtLogin";
            this.m_txtLogin.Size = new System.Drawing.Size(124, 20);
            this.m_txtLogin.TabIndex = 2;
            // 
            // m_txtPassword
            // 
            this.m_txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtPassword.Location = new System.Drawing.Point(141, 54);
            this.m_txtPassword.Name = "m_txtPassword";
            this.m_txtPassword.PasswordChar = '*';
            this.m_txtPassword.Size = new System.Drawing.Size(124, 20);
            this.m_txtPassword.TabIndex = 3;
            // 
            // m_lnkOuvrir
            // 
            this.m_lnkOuvrir.Location = new System.Drawing.Point(291, 32);
            this.m_lnkOuvrir.Name = "m_lnkOuvrir";
            this.m_lnkOuvrir.Size = new System.Drawing.Size(109, 23);
            this.m_lnkOuvrir.TabIndex = 7;
            this.m_lnkOuvrir.TabStop = true;
            this.m_lnkOuvrir.Text = "Ouvrir une session";
            this.m_lnkOuvrir.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkOuvrir_LinkClicked);
            // 
            // colIdUser
            // 
            this.colIdUser.Text = "Key user";
            // 
            // colNbToDo
            // 
            this.colNbToDo.Text = "To do";
            // 
            // CFormConsoleSuivi
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(700, 514);
            this.Controls.Add(this.m_panelTop);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.linkLabel1);
            this.Name = "CFormConsoleSuivi";
            this.Text = "Console de suivi";
            this.Closed += new System.EventHandler(this.CFormConsoleSuivi_Closed);
            this.Load += new System.EventHandler(this.CFormConsoleSuivi_Load);
            this.m_tabControl.ResumeLayout(false);
            this.m_tabConnexions.ResumeLayout(false);
            this.m_panelLegende.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.m_tabNotifications.ResumeLayout(false);
            this.m_panelTop.ResumeLayout(false);
            this.m_panelTop.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion



		private void CFormConsoleSuivi_Load(object sender, System.EventArgs e)
		{
			RefreshAll();
			
		}

		private void RefreshAll()
		{
			FillListeConnectes();
			FillPageNotifications();
		}

		private void FillListeConnectes()
		{
			IGestionnaireSessions gestionnaire = (IGestionnaireSessions)C2iFactory.GetNewObject(typeof(IGestionnaireSessions));
			int[] listeIdSessions = gestionnaire.GetListeIdSessionsConnectees();
            string strNomGestionnaire = gestionnaire.GetType().ToString();

			m_listView.Items.Clear();
			foreach ( int nId in listeIdSessions )
			{
				ListViewItem item = new ListViewItem();
                item.Tag = nId;
				while ( item.SubItems.Count < m_listView.Columns.Count )
					item.SubItems.Add("");
				item.SubItems[colIdSession.Index].Text = nId.ToString();
				IInfoSession session = gestionnaire.GetSessionClient(nId);
				try
				{
					session.GetInfoUtilisateur();
				}
				catch
				{
					session = gestionnaire.GetSessionClientSurServeur(nId);
					item.BackColor = Color.Red;
					session = gestionnaire.GetSessionClientSurServeur(nId);
				}
				if ( session == null )
				{
					item.BackColor = Color.Red;
					session = gestionnaire.GetSessionClientSurServeur(nId);
					item.SubItems[colNom.Index].Text = "#ERREUR ACCES";
				}

				try
				{
					item.SubItems[colNom.Index].Text = session.GetInfoUtilisateur().NomUtilisateur;
					item.SubItems[colAppli.Index].Text = session.DescriptionApplicationCliente;
					item.SubItems[colType.Index].Text = session.TypeApplicationCliente.ToString();
					DateTime dt = session.DateHeureConnexion;
					TimeSpan span = DateTime.Now - dt;
					string strChaine = "";
					if ( span.TotalDays > 1 )
						strChaine = ((int)span.TotalDays).ToString()+"j";
					if ( span.TotalHours > 0 )
						strChaine += ((int)(span.TotalHours % 24)).ToString()+"h";
					strChaine += ((int)(span.TotalMinutes % 60)).ToString()+"m";
					item.SubItems[colHeure.Index].Text = strChaine;


                    string strKeyUtilisateur = "";
                    if (session.GetInfoUtilisateur().KeyUtilisateur != null)
                    {
                        strKeyUtilisateur = session.GetInfoUtilisateur().KeyUtilisateur.StringValue;
                        item.SubItems[colIdUser.Index].Text = strKeyUtilisateur;

                        CContexteDonnee ctx = new CContexteDonnee(session.IdSession, true, false);
                        CDonneesActeurUtilisateur user = CUtilSession.GetUserForSession(ctx);
                        if (user != null)
                        {
                            CListeObjetsDonnees lstEtapesPourActeur = user.Acteur.GetEtapeWorkflowsEnCours();
                            int nbTodo = lstEtapesPourActeur.Count;
                            item.SubItems[colNbToDo.Index].Text = nbTodo.ToString();
                        }
                    }

                }
                catch
				{
					if ( nId == 0 )
						item.SubItems[colNom.Index].Text = "SERVEUR";
					else
					{
						item.BackColor = Color.Red;
						item.SubItems[colNom.Index].Text = "#ERREUR ACCES#";
					}
				}
				if ( nId == CSessionClient.GetSessionUnique().IdSession )
					item.BackColor = Color.LightGreen;
				m_listView.Items.Add ( item );
			}
		}

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			RefreshAll();
		}

		private void CFormConsoleSuivi_Closed(object sender, System.EventArgs e)
		{
			CSessionClient.GetSessionUnique().CloseSession();
		}

		private void FillPageNotifications()
		{
			IGestionnaireNotification gestionnaire = (IGestionnaireNotification)C2iFactory.GetNewObjetForSession("CGestionnaireNotification", typeof(IGestionnaireNotification), CSessionClient.GetSessionUnique().IdSession);
			//m_labelNbRecepteursNotification.Text = gestionnaire.GetNbRecepteurs().ToString();
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
			if ( MessageBox.Show("Fermer toutes les sessions sélectionnées ?", "Confirmation",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question ) == DialogResult.No )
				return;
            ArrayList lstThreads = new ArrayList();
			m_listeServicesToLaunch.Clear();
			m_listeThreadsEnAttente.Clear();
			ThreadStart funcStart = new ThreadStart(AskForClose);
            foreach ( ListViewItem item in m_listView.CheckedItems )
            {
                int nIdSession = (int)item.Tag;
                CSessionClient session = CSessionClient.GetSessionForIdSession(nIdSession);
				try
				{
					CServiceSurClientFermerApplication service = (CServiceSurClientFermerApplication)session.GetServiceSurClient(CServiceSurClientFermerApplication.c_idService);
					if ( service != null )
					{
						lock ( m_listeServicesToLaunch )
						{
							m_listeServicesToLaunch.Add ( service );
						}
						Thread th = new Thread ( funcStart );
						th.Start();
					}
				}
				catch
				{
				}
			}
		}

        private void m_lnkOuvrir_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CSessionClient nouvelleSession = CSessionClient.CreateInstance();

            CAuthentificationSessionTimosLoginPwd authParams =  new CAuthentificationSessionTimosLoginPwd(
                m_txtLogin.Text,
                m_txtPassword.Text,
                new CParametresLicence(new List<string>(), new List<string>()));

            //CAuthentificationSessionLoginPassword authParams = new CAuthentificationSessionLoginPassword(m_txtLogin.Text, m_txtPassword.Text);

            CResultAErreur result = nouvelleSession.OpenSession(authParams, "Session de test", ETypeApplicationCliente.Windows);

            if (!result)
            {
                MessageBox.Show(result.Erreur.ToString());
                return;
            }



            DataSet ds = new DataSet("DS");

            RefreshAll();
        }
    }
}
