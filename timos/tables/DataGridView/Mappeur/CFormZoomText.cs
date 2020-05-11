using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common;

namespace timos.tables
{
	public partial class CFormZoomText : Form
	{
		public CFormZoomText()
		{
			InitializeComponent();
		}

		public static string ShowText(string strTexte, bool bEditable)
		{
			CFormZoomText form = new CFormZoomText();
			Point pt = Cursor.Position;
			if ( pt.X + form.Width > Screen.PrimaryScreen.WorkingArea.Width )
				pt.X = Screen.PrimaryScreen.WorkingArea.Width - form.Width;
			if (pt.Y + form.Height > Screen.PrimaryScreen.WorkingArea.Height)
				pt.Y = Screen.PrimaryScreen.WorkingArea.Height - form.Height;
			form.StartPosition = FormStartPosition.Manual;
			form.Location = pt;
			CWin32Traducteur.Translate(form);
			if (bEditable)
			{
				form.m_txtZoom.ReadOnly = false;
				form.m_lnkOk.Visible = true;
			}
			else
			{
				form.m_txtZoom.ReadOnly = true;
				form.m_lnkOk.Visible = false;
			}
			form.m_txtZoom.Text = strTexte;
			if (form.ShowDialog() == DialogResult.OK)
				strTexte = form.m_txtZoom.Text;
			form.Dispose();
			return strTexte;
		}

		private void CFormZoomText_Load(object sender, EventArgs e)
		{
			
		}

		private void m_lnkFermer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void m_lnkOk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}
	}
}