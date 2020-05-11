using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace timos.tables
{
	public partial class CFormEditColonneFilter : Form
	{
		public static void SetFiltre(DataGridViewColumn col)
		{
			CFormEditColonneFilter frm = new CFormEditColonneFilter();
			frm.Initialiser(col);
			frm.ShowDialog();
			frm.Dispose();
		}


		public CFormEditColonneFilter()
		{
			InitializeComponent();
		}

		public void Initialiser(DataGridViewColumn col)
		{

			if (col.Tag == null)
				col.Tag = new CCDataGridViewColonneFilter(col);
			m_col = col;
			m_ctrl.Initialiser((CCDataGridViewColonneFilter)col.Tag);

		}

		private DataGridViewColumn m_col;
		public DataGridViewColumn Colonne
		{
			get
			{
				return m_col;
			}
		}

	

		private void m_btnOk_Click(object sender, EventArgs e)
		{
			CCDataGridViewColonneFilter c = m_ctrl.ColonneFilter;
			if (!c.Valider(true))
				m_col.Tag = null;
			else
				m_col.Tag = c;

			Close();
		}

		private void CFormEditColonneFilter_Load(object sender, EventArgs e)
		{
			sc2i.win32.common.CWin32Traducteur.Translate(this);
		}
	}
}