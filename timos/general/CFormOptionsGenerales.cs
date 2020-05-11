using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace timos.general
{
	public partial class CFormOptionsGenerales : Form
	{
		private bool m_bInitialise = false;
		public CFormOptionsGenerales()
		{
			m_bInitialise = false;
			InitializeComponent();

			Initialiser();
			m_bInitialise = true;
		}


		private void Initialiser()
		{
			InitialiserOptionsGraphiques();
		}
		private void InitialiserOptionsGraphiques()
		{
			//Fondu
			m_chkFondu.Checked = new CTimosAppRegistre().OptionsGraphiques_FonduActif;
		}

		private CTimosAppRegistre m_timosRegistre = new CTimosAppRegistre();

		private void m_panClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void m_chkFondu_CheckedChanged(object sender, EventArgs e)
		{
			if (m_bInitialise)
				m_timosRegistre.OptionsGraphiques_FonduActif = m_chkFondu.Checked;
		}
	}
}