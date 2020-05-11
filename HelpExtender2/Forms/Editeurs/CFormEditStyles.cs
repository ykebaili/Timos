using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HelpExtender
{
	public partial class CFormEditStyles : Form
	{
		public CFormEditStyles()
		{
			InitializeComponent();
		}

		private void m_btnOk_Click(object sender, EventArgs e)
		{
			CHelpData.SourceAide.HtmlStyles = m_txtCSS.Text;
			DialogResult = DialogResult.OK;
			Close();
		}

		private void m_btnAnnuler_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void CFormEditStyles_Load(object sender, EventArgs e)
		{
			m_txtCSS.Text = CHelpData.SourceAide.HtmlStyles;
		}

		public static bool EditeStyles()
		{
			CFormEditStyles form = new CFormEditStyles();
			return form.ShowDialog() == DialogResult.OK;
		}


	}
}