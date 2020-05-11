using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TimosDataServeur
{
	public partial class CFormSelectBDD : Form
	{
		public CFormSelectBDD()
		{
			InitializeComponent();
		}

		public static bool SelectBDD(ref string strNomBDD, ref string strUser, ref string strPWD)
		{
			CFormSelectBDD form = new CFormSelectBDD();
			form.m_txtBDD.Text = strNomBDD;
			form.m_txtUser.Text = strUser;
			form.m_txtMDP.Text = strPWD;
			if (form.ShowDialog() == DialogResult.OK)
			{
				strNomBDD = form.m_txtBDD.Text;
				strUser = form.m_txtUser.Text;
				strPWD = form.m_txtMDP.Text;
				return true;
			}
			return false;
		}

		private void m_btnAnnuler_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();

		}

		private void m_btnOk_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}


	}
}