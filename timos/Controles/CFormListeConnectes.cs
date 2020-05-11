using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using sc2i.win32.common;
using sc2i.multitiers.client;
using sc2i.common;

namespace timos
{
	public partial class CFormListeConnectes : CFloatingFormBase
	{
		public CFormListeConnectes()
		{
			InitializeComponent();
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
            //TESTDBKEYOK
			CDbKey keyMoi = CTimosApp.SessionClient.GetInfoUtilisateur().KeyUtilisateur;

			IInfoUtilisateur[] infos = CSessionClient.GetUtilisateursConnecte();
			List<IInfoUtilisateur> lst = new List<IInfoUtilisateur>(infos);
			m_wndListeUsers.BeginUpdate();
			m_wndListeUsers.Items.Clear();
			Hashtable tableDejaFaits = new Hashtable();
			tableDejaFaits[keyMoi] = true;

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

		private void CFormListeConnectes_Load(object sender, EventArgs e)
		{
            sc2i.win32.common.CWin32Traducteur.Translate(this);
			FillListe();
		}

		private void m_wndListeUsers_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			ListViewHitTestInfo info = m_wndListeUsers.HitTest(new Point(e.X, e.Y));
			if (info != null && info.Item != null && info.Item.Tag is CDbKey)
			{
				CFormMain.GetInstance().ShowChatUser((CDbKey)info.Item.Tag);
				Close();
			}
		}
	}
}