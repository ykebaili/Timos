using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace HelpExtender
{
	public partial class CtrlHelpViewer : UserControl
	{
		#region ++ Constructeurs ++
		public CtrlHelpViewer()
		{
			InitializeComponent();
		}
		#endregion

		#region :: Propriétés ::
		private CHelpData _hlp;
		#endregion

		#region >> Assesseurs <<
		public bool LiensVersHelpActifs
		{
			get
			{
				return viewerHtml.LiensVersHelpActifs;
			}
			set
			{
				viewerHtml.LiensVersHelpActifs = value;
			}
		}
		#endregion

		#region ~~ Méthodes ~~
		public void Precedant()
		{
			viewerHtml.Precedant();
		}
		public void Suivant()
		{
			viewerHtml.Suivant();
		}
		public void Initialiser(CHelpData hlp)
		{
			_hlp = hlp;
			viewerHtml.DocumentText = hlp.FullTexteHtml;
			//splitConteneur.Panel2.Height = 0;
		}
		public void InitialiserListeAnnexes()
		{
			splitConteneur.Panel2.Height = 0;

			lv_annexes.Items.Clear();
			foreach (CHelpData hlplie in _hlp.VoirAussiExplicite)
			{
				ListViewItem itm = new ListViewItem(hlplie.Titre);
				itm.SubItems.Add(hlplie.TypeLiaison.ToString());
				itm.SubItems.Add(hlplie.Designation);
				itm.Tag = hlplie;
				lv_annexes.Items.Add(itm);
			}
		}
		#endregion

		#region ** Evenements **
		public event EvenementNavigationVersAide NavigationVersHelp;

		private void lv_annexes_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lv_annexes.SelectedItems.Count == 1)
			{
				CHelpData hlp = (CHelpData)lv_annexes.SelectedItems[0].Tag;

				if(NavigationVersHelp != null)
					NavigationVersHelp(sender, new ArgumentsEvenementNavigationVersAide(hlp));

				Initialiser(hlp);

			}
		}
		private void viewerHtml_ClickLienVersAide(object sender, ArgumentsEvenementNavigationVersAide e)
		{
			if (e.Help != null)
			{
				if (NavigationVersHelp != null)
					NavigationVersHelp(sender, e);

				Initialiser(e.Help);
			}
		}

		private void btn_masquerannexe_Click(object sender, EventArgs e)
		{
			lv_annexes.Visible = !lv_annexes.Visible;

		}

		#endregion

	


	}
}
