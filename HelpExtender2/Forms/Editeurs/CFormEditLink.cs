using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common;
using sc2i.common;

namespace HelpExtender
{
	public partial class CFormEditLink : Form
	{
		private CHelpData m_helpData = null;
		public CFormEditLink()
		{
			InitializeComponent();
		}

		public static bool EditeLink(ref string strTexte, ref CHelpData helpData)
		{
			CFormEditLink form = new CFormEditLink();
			form.m_helpData = helpData;
			form.m_txtLinkText.Text = strTexte;
			if (form.ShowDialog() == DialogResult.OK)
			{
				helpData = form.m_helpData;
				strTexte = form.m_txtLinkText.Text;
				return true;
			}
			return false;	
		}

		private void CFormEditLink_Load(object sender, EventArgs e)
		{
			if (m_helpData != null)
				m_lblLinkTo.Text = m_helpData.Titre;
		}

		private void m_lnkLinkTo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			//CHelpData help = CFormSelectHelpPage.SelectHelp(m_helpData);
			//if (help != null)
			//{
			//    m_helpData = help;
			//    m_lblLinkTo.Text = m_helpData.Titre;
			//}
		}

		private void m_btnOk_Click(object sender, EventArgs e)
		{
			if (m_helpData == null)
			{
				CFormAlerte.Afficher(I.T("Select a link page|30029"), EFormAlerteType.Exclamation);
				return;
			}
			if (m_txtLinkText.Text.Length == 0)
			{
				CFormAlerte.Afficher(I.T("Enter a link text|30030"), EFormAlerteType.Exclamation);
				return;
			}
			DialogResult = DialogResult.OK;
			Close();
		}

		private void m_btnAnnuler_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}