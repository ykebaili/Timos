using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using sc2i.multitiers.client;
using timos.acteurs;

namespace timos.Controles
{
	public partial class CControleUsersMessagesInstantanes : UserControl
	{
		private CRecepteurNotification m_recepteurConnexion = null;
		private CRecepteurNotification m_recepteurMessage = null;
		public CControleUsersMessagesInstantanes()
		{
			InitializeComponent();
			m_recepteurConnexion = new CRecepteurNotification(CTimosApp.SessionClient.IdSession, typeof(CDonneeNotificationConnection));
			m_recepteurConnexion.OnReceiveNotification += new NotificationEventHandler(m_recepteurConnexion_OnReceiveNotification);

			m_recepteurMessage = new CRecepteurNotification(CTimosApp.SessionClient.IdSession, typeof(CDonneeNotificationMessageInstantane));
			m_recepteurMessage.OnReceiveNotification += new NotificationEventHandler(m_recepteurMessage_OnReceiveNotification);

		}

		void m_recepteurMessage_OnReceiveNotification(IDonneeNotification donnee)
		{
			if (donnee is CDonneeNotificationMessageInstantane)
			{
				CDonneeNotificationMessageInstantane message = (CDonneeNotificationMessageInstantane)donnee;
				try
				{
					if (message.KeyUtilisateurDestinataire == CTimosApp.SessionClient.GetInfoUtilisateur().KeyUtilisateur)
					{
					}
				}
				catch
				{
				}
			}
		}

		void m_recepteurConnexion_OnReceiveNotification(IDonneeNotification donnee)
		{
			throw new Exception("The method or operation is not implemented.");
		}

		private void m_wndListeUsers_SizeChanged(object sender, EventArgs e)
		{
			m_colonneUser.Width = ClientSize.Width - 32;
		}

		private class CSorterUsers : IComparer<IInfoUtilisateur>
		{
			#region IComparer Membres

			

			#endregion
			#region IComparer<IInfoUtilisateur> Membres

			public int Compare(IInfoUtilisateur x, IInfoUtilisateur y)
			{
				try
				{
					return x.NomUtilisateur.CompareTo(y.NomUtilisateur);
				}
				catch
				{
				}
				return 0;
			}

			#endregion
		}


		private void FillListe()
		{
			IInfoUtilisateur[] infos = CSessionClient.GetUtilisateursConnecte();
			List<IInfoUtilisateur> lst = new List<IInfoUtilisateur>(infos);
			m_wndListeUsers.BeginUpdate();
			m_wndListeUsers.Items.Clear();
			Hashtable tableDejaFaits = new Hashtable();
            //TESTDBKEYTODO : vérifier à quoi sert le TAG !
			foreach (IInfoUtilisateur user in lst)
			{
				if (tableDejaFaits[user.KeyUtilisateur] == null)
				{
					tableDejaFaits[user.KeyUtilisateur] = true;
					if (user.NomUtilisateur.Length > 0)
					{
						ListViewItem item = new ListViewItem(user.NomUtilisateur);
						item.ImageIndex = 0;
						item.Tag = user.KeyUtilisateur;
						m_wndListeUsers.Items.Add(item);
					}
				}
			}
			m_wndListeUsers.EndUpdate();
			
		}
	}
}
