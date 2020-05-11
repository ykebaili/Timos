using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace HelpExtender
{
	public partial class CCtrlSelectTousAvecTitre : UserControl
	{
		#region ++ Constructeurs ++
		public CCtrlSelectTousAvecTitre()
		{
			InitializeComponent();
		}
		#endregion

		#region :: Propriétés ::
		private List<ListViewItem> m_itmsMasques;
		private int m_nTicks;
		#endregion

		#region ~~ Méthodes ~~
		public void Initialiser()
		{
			m_itmsMasques = new List<ListViewItem>();
			lv_hlps.Items.Clear();
			List<CHelpData> hlps = CHelpData.SourceAide.GetHelps();
			foreach (CHelpData hlp in hlps)
				AjouterHelp(hlp);

			cmb_optrecherche.Items.Clear();
			string[] elems = Enum.GetNames(typeof(OptRecherche));
			foreach (string ele in elems)
				cmb_optrecherche.Items.Add(ele);
			cmb_optrecherche.SelectedItem = OptRecherche.ContenantToutLesMots.ToString();
		}
		private void Filtrer()
		{
			bool all = false;
			//Titre
			if (txt_titre.Text == null || txt_titre.Text.Trim() == "")
				all = true;

			if (all)
			{
				for (int i = m_itmsMasques.Count; i > 0; i--)
				{
					ListViewItem itm = m_itmsMasques[i - 1];
					m_itmsMasques.RemoveAt(i - 1);
					lv_hlps.Items.Add(itm);
				}
			}
			else
			{ 
				//Recuperation des items correspondant dans ceux étant masqué
				List<ListViewItem> itmsentransit = new List<ListViewItem>();
				for (int i = m_itmsMasques.Count; i > 0; i--)
				{
					ListViewItem itm = m_itmsMasques[i - 1];
					if(Compare(txt_titre.Text.Trim(),itm.Text))
					{
						m_itmsMasques.RemoveAt(i - 1);
						itmsentransit.Add(itm);
					}
				}


				//On maeque les items ne correspondant plus
				for (int i = lv_hlps.Items.Count; i > 0; i--)
				{
					ListViewItem itm = lv_hlps.Items[i - 1];
					if (!Compare(txt_titre.Text.Trim(), itm.Text))
					{
						lv_hlps.Items.RemoveAt(i - 1);
						m_itmsMasques.Add(itm);
					}
				}

				//Rajout des items en transits
				for (int i = itmsentransit.Count; i > 0; i--)
				{
					ListViewItem itm = itmsentransit[i - 1];
					itmsentransit.RemoveAt(i - 1);
					lv_hlps.Items.Add(itm);
				}
			}

		}

		// Retourne vrai si l'élément correspond à la chaine selon l'option de recherche
		private bool Compare(string chaine, string element)
		{
			chaine = chaine.Trim();
			element = element.Trim();

			if (!chk_casesensitive.Checked)
			{
				chaine = chaine.ToUpper();
				element = element.ToUpper();
			}
			//if (!sensibleaccents)
			//{
			//}

			bool bTrouve = false;
			switch (OptionRecherche)
			{
				default:
				case OptRecherche.ContenantUnOuPlusieursMots:
					string[] motsvoulus = chaine.Split(' ');
					bTrouve = false;
					foreach (string motposs in motsvoulus)
					{
						if(  element.Contains ( motposs ) )
						{
							bTrouve = true;
							break;
						}
					}
					if (bTrouve)
						return true;
					return false;
				case OptRecherche.ContenantToutLesMots:
					string[] motsvoulus2 = chaine.Split(' ');
					foreach (string mot in motsvoulus2)
					{
						if ( !element.Contains ( mot ) )
							return false;
					}
					return true;
				case OptRecherche.CommencantPar:
				if(element.Length >= chaine.Length && element.Substring(0, chaine.Length) == chaine)
					return true;
				else
					return false;

				case OptRecherche.FinissantPar:
				if(element.Length >= chaine.Length && element.Substring(element.Length - chaine.Length) == chaine)
					return true;
				else
					return false;
			}

		}
		private void AjouterHelp(CHelpData hlp)
		{
			ListViewItem itm = new ListViewItem(hlp.Titre);
			itm.SubItems.Add(hlp.NomCourt);
			itm.SubItems.Add(hlp.TypeLiaison.ToString());
			itm.Tag = hlp;
			lv_hlps.Items.Add(itm);
		}
		#endregion

		#region >> Assesseurs <<
		public CHelpData HelpSelectionne
		{
			get
			{
				if (lv_hlps.SelectedItems.Count == 1)
					return (CHelpData)lv_hlps.SelectedItems[0].Tag;
				else
					return null;
			}
		}
		private OptRecherche OptionRecherche
		{
			get
			{
				return (OptRecherche)Enum.Parse(typeof(OptRecherche), cmb_optrecherche.SelectedItem.ToString());
			}
		}
		#endregion

		#region ** Evenements **
		private void txt_titre_TextChanged(object sender, EventArgs e)
		{
			m_nTicks = 0;
			m_timer.Start();
		}
		private void m_timer_Tick(object sender, EventArgs e)
		{
			if (m_nTicks < 5)
				m_nTicks++;
			else
			{
				m_timer.Stop();
				m_nTicks = 0;
				Filtrer();
			}
		}

		private void lv_hlps_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lv_hlps.SelectedItems.Count == 1)
			{
				CHelpData hlp = (CHelpData)lv_hlps.SelectedItems[0].Tag;
				if (hlp.TypeLiaison == ETypeLiaisonAide.Control)
					CHelpExtender.FaireClignoterControl(hlp.Controle);
				else
					CHelpExtender.ArreterClignotementControl();
			}
		}
		private ListViewItem m_lvClick;
		private void lv_hlps_Click(object sender, EventArgs e)
		{
			if (lv_hlps.SelectedItems.Count == 1)
				m_lvClick = lv_hlps.SelectedItems[0];
			else
				m_lvClick = null;
		}
		public event EventHandler DoubleClickHelp;
		private void lv_hlps_MouseClick(object sender, MouseEventArgs e)
		{
			if (DoubleClickHelp != null)
			{
				//Position Ecran
				Point p = Cursor.Position;
				//Position Dans Control
				p = lv_hlps.PointToClient(p);


				ListViewHitTestInfo test = lv_hlps.HitTest(p);
				if (test != null && test.Item != null && test.Item == m_lvClick)
				{
					test.Item.Selected = true;

					DoubleClickHelp(sender, e);
				}
			}
		}
		#endregion

		#region .. Enumerations ..
		public enum OptRecherche
		{ 
			ContenantUnOuPlusieursMots,
			ContenantToutLesMots,
			CommencantPar,
			FinissantPar
		}
		#endregion

		private void lv_hlps_MouseClick(object sender, EventArgs e)
		{

		}

		



	}
}
