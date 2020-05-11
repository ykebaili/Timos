using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;

using timos.data;

using sc2i.common;
using sc2i.win32.common;

namespace timos
{
	public partial class CFormModeImport : Form
	{

		public CFormModeImport()
		{
			InitializeComponent();
			CWin32Traducteur.Translate(this);
		}

		private CImportTableParametrableMode ModeSelectionne
		{
			get
			{
				if (m_rbtDelete.Checked)
					return new CImportTableParametrableMode(EImportTableParametrableMode.Delete);
				else if (m_rbtReset.Checked)
					return new CImportTableParametrableMode(EImportTableParametrableMode.RAZ_Puis_Import);
				else
					return new CImportTableParametrableMode(EImportTableParametrableMode.Update_Or_Create);
			}
		}

		private void m_btnOk_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void m_btnAnnuler_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		public static bool ChoisirModeImport(ref CImportTableParametrableMode mode)
		{
			CFormModeImport form = new CFormModeImport();
			bool result = form.ShowDialog() == DialogResult.OK;
			form.Dispose();
			mode = form.ModeSelectionne;
			return result;
		}
	}
}