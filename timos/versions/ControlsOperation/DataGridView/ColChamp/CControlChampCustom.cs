using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using timos.data.version;
using sc2i.data;
using sc2i.data.dynamic;
using sc2i.win32.data.navigation;
using sc2i.common;

namespace timos.version
{
	public partial class CControlChampCustom : UserControl
	{
		public CControlChampCustom()
		{
			InitializeComponent();
			DoubleBuffered = true;
		}

		private CChampCustomPourVersion m_champ;
		public void Init(CChampCustomPourVersion champ)
		{
			m_champ = champ;
			m_lnk.Text = I.T("Custom field |30215") + m_champ.NomConvivial;
		}

		private void m_lnk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CFormEditionChampCustom frm = new CFormEditionChampCustom(m_champ.ChampCustom);
			CSc2iWin32DataNavigation.Navigateur.AffichePage(frm);
		}

	}
}
