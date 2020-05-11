using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace HelpExtender
{
	public partial class CCtrlEditHelpsLies : UserControl
	{
		#region ++ Constructeurs ++
		public CCtrlEditHelpsLies()
		{
			InitializeComponent();
		}
		#endregion

		#region :: Propriétés ::
		private bool m_bModeEdition;
		private CMenuItem m_menuItem;
		#endregion

		#region >> Assesseurs <<
		public List<CHelpData> Selection
		{
			get
			{
				List<CHelpData> selec = new List<CHelpData>();
				foreach (ListViewItem itm in lv_eles.Items)
					selec.Add(CHelpData.SourceAide.GetHelp((string)itm.Tag));
				return selec;
			}

		}

		public CHelpData HelpSelectionne
		{
			get
			{
				if (lv_eles.SelectedItems.Count == 1)
					return (CHelpData)lv_eles.SelectedItems[0].Tag;
				return null;
			}
		}
		#endregion

		#region ~~ Méthodes ~~
		public void Initialiser(CMenuItem itm, bool modeEdition)
		{
			//SC List<CHelpData> hlps = itm.Helps;
			m_menuItem = itm;
			m_bModeEdition = modeEdition;
			if (!modeEdition)
				pan_cmds.Visible = false;

			lv_eles.Items.Clear();
			/*SC foreach (CHelpData hlp in hlps)
				AjouterHelp(hlp);*/

			btn_supp.Enabled = false;
		}
		private void AjouterHelp(CHelpData hlp)
		{
			/*ListViewItem itm = new ListViewItem(hlp.Titre);
			bool doubledetect = false;
			foreach (ListViewItem lvitm in lv_eles.Items)
				if (((CHelpData)lvitm.Tag).HelpKey == hlp.HelpKey)
				{
					doubledetect = true;
				}

			if (doubledetect && MessageBox.Show("Ce fichier d'aide est déjà répertorier, voulez vous l'ajouter encore une fois ?", "Ajout...", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
				return;

			itm.Tag = hlp;
			itm.SubItems.Add(hlp.TypeLiaison.ToString());
			itm.SubItems.Add(hlp.Designation);
			lv_eles.Items.Add(itm);*/
		}
		#endregion

		#region ** Evenements **
		private void btn_supp_Click(object sender, EventArgs e)
		{
			/*if (lv_eles.SelectedItems.Count == 1)
				if (MessageBox.Show("Retirer " + lv_eles.SelectedItems[0].Text + " de cette rubrique ?", "Suppression...", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					m_menuItem.Helps.Remove((CHelpData)lv_eles.SelectedItems[0].Tag);
					lv_eles.Items.RemoveAt(lv_eles.SelectedItems[0].Index);
				}*/
		}

		private void btn_add_Click(object sender, EventArgs e)
		{
			CFormSelectHelpPage frm = new CFormSelectHelpPage();
			frm.Initialiser(ETypeSelection.SelonTitre);
			frm.AutoriserCreation = false;
			if(frm.ShowDialog() == DialogResult.OK)
				if(frm.HelpSelectionne != null)
					AjouterHelp(frm.HelpSelectionne);

		}

		private void lv_eles_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lv_eles.SelectedItems.Count == 1)
			{
				btn_supp.Enabled = true;
				CHelpData hlp = (CHelpData)lv_eles.SelectedItems[0].Tag;
				if (hlp.TypeLiaison == ETypeLiaisonAide.Control)
					CHelpExtender.FaireClignoterControl(hlp.Controle);
			}
			else
			{
				btn_supp.Enabled = false;
			}
		}

		public event EventHandler DoubleClickHelp;
		private ListViewItem m_lvClick;
		private void lv_eles_Click(object sender, EventArgs e)
		{
			if (lv_eles.SelectedItems.Count == 1)
				m_lvClick = lv_eles.SelectedItems[0];
			else
				m_lvClick = null;
		}
		private void lv_eles_DoubleClick(object sender, EventArgs e)
		{
			if (DoubleClickHelp != null)
			{
				//Position Ecran
				Point p = Cursor.Position;
				//Position Dans Control
				p = lv_eles.PointToClient(p);


				ListViewHitTestInfo test = lv_eles.HitTest(p);
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
