using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using sc2i.common;
using timos.data;
using timos.acteurs;
using timos.client;
using sc2i.workflow;
using sc2i.multitiers.client;
using timos.securite;
using sc2i.win32.common;
using sc2i.win32.data;

namespace timos
{
	[AutoExec("Autoexec")]
	public partial class CControleChat : UserControl
	{
		private Dictionary<int, string> m_listeUserToMessage = new Dictionary<int, string>();
		private Color m_couleurTexteAutre = Color.Black;
		private Color m_couleurTexteMoi = Color.Gray;

		private int m_nIdUtilisateurAutre = -1;


		private class CInfoMessage
		{
			public readonly string Message;
			public readonly int IdUserEnvoyeur;
			public CInfoMessage(string strMessage, int nIdUserEnvoyeur)
			{
				Message = strMessage;
				IdUserEnvoyeur = nIdUserEnvoyeur;
			}
		}
	
		public CControleChat()
		{
			InitializeComponent();
		}

		//---------------------------------------------------------
		public static void Autoexec()
		{

		}

        //---------------------------------------------------------
        public void SetModeSansActeurEtSansClose()
        {
            m_btnFermer.Visible = false;
            m_imageMSN.Visible = false;
        }

		//---------------------------------------------------------
		private delegate void ShowMessageDelegate(string strMessage, int nIdUser);
		public void OnMessage(int nIdUserFrom, string strMessage)
		{
			ShowMessageDelegate mesDel = new ShowMessageDelegate(ShowMessage);
			mesDel.BeginInvoke( strMessage, nIdUserFrom, null, null);
		}

		/*private delegate void EmpileMessageDelegate( CInfoMessage info );
		private void m_timerMessages_Tick(object sender, EventArgs e)
		{
			while ( m_pileMessages.Count > 0 )
			{
				
		}*/


		//---------------------------------------------------------
		private bool m_bFondColore = false;
		private void m_timerEmpile_Tick(object sender, EventArgs e)
		{
			while (m_pileMessages.Count > 0 )
			{
				CInfoMessage info = m_pileMessages.Pop();
				CDonneesActeurUtilisateur user = new CDonneesActeurUtilisateur(sc2i.win32.data.CSc2iWin32DataClient.ContexteCourant);
				if (user.ReadIfExists(info.IdUserEnvoyeur))
				{
					ListViewItem item = m_wndListeMessages.Items.Add("");
					string strText = user.Acteur.IdentificationCourte + " > " + info.Message;
					item.Text = strText;
					item.Tag = info;
					m_wndListeMessages.Visible = true;
					m_bRendVisible = true;
				}
			}
			if (m_wndListeMessages.Items.Count > 0)
			{
				m_bFondColore = !m_bFondColore;
				m_wndListeMessages.BackColor = m_bFondColore ? Color.White : BackColor;
			}
			else
				m_wndListeMessages.BackColor = BackColor;
			if (m_bRendVisible && !Visible)
				Visible = true;
			m_bRendVisible = false;
		}


		bool m_bRendVisible = false;
		Stack<CInfoMessage> m_pileMessages = new Stack<CInfoMessage>();
		//---------------------------------------------------------
		private void ShowMessage ( string strMessage, int nIdUserFrom )
		{
			CDonneesActeurUtilisateur user = new CDonneesActeurUtilisateur(sc2i.win32.data.CSc2iWin32DataClient.ContexteCourant);
			if (!user.ReadIfExists(nIdUserFrom))
				return;
			if (strMessage != null && nIdUserFrom != m_nIdUtilisateurAutre && Visible && m_nIdUtilisateurAutre>=0)
			{
				CInfoMessage info = new CInfoMessage(strMessage, nIdUserFrom);
				m_pileMessages.Push(info);
				return;
			}
			bool bChangementUtilisateur = false;
			if ( nIdUserFrom >= 0 )
			{
				if (nIdUserFrom != m_nIdUtilisateurAutre)
					bChangementUtilisateur = true;
				if (bChangementUtilisateur)
				{
					if (m_nIdUtilisateurAutre >= 0)
						m_listeUserToMessage[m_nIdUtilisateurAutre] = m_txtMessage.Text;
					if (m_listeUserToMessage.ContainsKey(nIdUserFrom))
						m_txtMessage.Text = m_listeUserToMessage[nIdUserFrom];
					else
						m_txtMessage.Text = "";
					m_nIdUtilisateurAutre = nIdUserFrom;
					m_lblUser.Text = user.Acteur.IdentiteComplete;

				}
			}
			foreach ( ListViewItem item in new ArrayList ( m_wndListeMessages.Items ))
			{
				CInfoMessage info = (CInfoMessage)item.Tag;
				if ( info.IdUserEnvoyeur == nIdUserFrom )
				{
					AddMessage ( info.Message, true );
					m_wndListeMessages.Items.Remove ( item );
				}
			}
			if (m_wndListeMessages.Items.Count == 0)
				m_wndListeMessages.Visible = false;

			if ( !bChangementUtilisateur || strMessage != null )
			{
				AddMessage(strMessage, true);
			}
			m_bRendVisible = !Visible;
		}

		//---------------------------------------------------------
		private void AddMessage(string strMessage, bool bDeLautre)
		{
			string strMes = bDeLautre ? strMessage : ">>>" + strMessage;
			m_txtMessage.Text += "\r\n" + strMes;
		}

		//---------------------------------------------------------
		private void SendMessage ()
		{
            //TESTDBKEYOK
			if (m_txtToSend.Text.Trim() != "")
			{
				try
				{
					if ( m_nIdUtilisateurAutre < 0 )
					{
						CFormAlerte.Afficher(I.T("Select a User |30064"), EFormAlerteType.Erreur);
						return;
					}
                    CDbKey keyDest = CSc2iWin32DataClient.ContexteCourant.GetKeyFromId<CDonneesActeurUtilisateur>(m_nIdUtilisateurAutre);
                    if (!CSessionClient.IsUserConnected(keyDest))
					{
						CFormAlerte.Afficher(m_lblUser.Text + " is not connected|30065", EFormAlerteType.Erreur);
						return;
					}
					string strMes = m_txtToSend.Text.Replace("\r"," ");
					strMes = strMes.Replace("\n"," ");

                    int? nIdEnvoyeur = CSc2iWin32DataClient.ContexteCourant.GetIdFromKey<CDonneesActeurUtilisateur>(CTimosApp.SessionClient.GetInfoUtilisateur().KeyUtilisateur);

					CDonneeNotificationMessageInstantane message = new CDonneeNotificationMessageInstantane(
						CTimosApp.SessionClient.IdSession,
						nIdEnvoyeur.Value,
                        keyDest,
						strMes);
					CEnvoyeurNotification.EnvoieNotifications(new IDonneeNotification[] { message });
					AddMessage(strMes, false);
					m_txtToSend.Text = "";
				}
				catch
				{
					CFormAlerte.Afficher("Sending error|30066", EFormAlerteType.Erreur);
				}
			}
		}

		private void m_txtToSend_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				e.Handled = true;
				SendMessage();
			}
		}

		

		private void m_tnEnvoyer_Click(object sender, EventArgs e)
		{
			SendMessage();
		}

		private void m_btnFermer_Click(object sender, EventArgs e)
		{
			Hide();
		}

		private void m_imageMSN_Click(object sender, EventArgs e)
		{
			CFormListeConnectes form = new CFormListeConnectes();
			form.Show();
		}



		private void m_wndListeMessages_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			ListViewHitTestInfo info = m_wndListeMessages.HitTest(new Point(e.X, e.Y));
			if (info.Item != null)
			{
				CInfoMessage mes = (CInfoMessage)info.Item.Tag;
				OnMessage(mes.IdUserEnvoyeur, null);
			}
		}

        private void CControleChat_Load(object sender, EventArgs e)
        {

        }


		
		

	}
}
