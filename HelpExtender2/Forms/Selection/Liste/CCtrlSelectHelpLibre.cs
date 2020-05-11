using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace HelpExtender
{
	public partial class CCtrlSelectHelpLibre : UserControl
	{
		#region ++ Constructeurs ++
		public CCtrlSelectHelpLibre()
		{
			InitializeComponent();
		}
		#endregion

		#region >> Assesseurs <<
		public CHelpData HelpSelectionne
		{
			get
			{
				if (lv_docs.SelectedItems.Count != 1)
					return null;
				else
					return (CHelpData) lv_docs.SelectedItems[0].Tag;
			}
		}
		#endregion

		#region ~~ Méthodes ~~
		public void Initialiser()
		{
			List<CHelpData> hlps = CHelpData.SourceAide.GetHelps();
			lv_docs.Items.Clear();
			foreach(CHelpData hlp in hlps)
				if (hlp.TypeLiaison == ETypeLiaisonAide.Aucune)
				{
					ListViewItem itm = new ListViewItem(hlp.Titre);
					itm.Tag = hlp;
					lv_docs.Items.Add(itm);
				}
		}
		#endregion

		#region ** Evenements **
		public event EventHandler DoubleClickHelp;
		private ListViewItem m_lvClick;
		private void lv_docs_Click(object sender, EventArgs e)
		{
			if (lv_docs.SelectedItems.Count == 1)
				m_lvClick = lv_docs.SelectedItems[0];
			else
				m_lvClick = null;
		}
		private void lv_docs_DoubleClick(object sender, EventArgs e)
		{
			if (DoubleClickHelp != null)
			{
				//Position Ecran
				Point p = Cursor.Position;
				//Position Dans Control
				p = lv_docs.PointToClient(p);

				ListViewHitTestInfo test = lv_docs.HitTest(p);
				if (test != null && test.Item != null && test.Item == m_lvClick)
				{
					test.Item.Selected = true;
					DoubleClickHelp(sender, e);
				}
			}
		}
		#endregion

		
	}
}
