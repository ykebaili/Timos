using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using timos.data;
using sc2i.win32.common;

namespace timos.win32.composants
{
	public partial class CFormDetailIntervenant : Form
	{
		private CTypeIntervention_ProfilIntervenant m_profilEdite = null;
		public CFormDetailIntervenant()
		{
			InitializeComponent();
		}

		public static bool EditeIntervenant(
			CTypeIntervention_ProfilIntervenant profil, 
			bool bModeEdition )
		{
			CFormDetailIntervenant form = new CFormDetailIntervenant();
			form.m_profilEdite = profil;
			form.m_gestionnaireModeEdition.ModeEdition = bModeEdition;
			bool bResult = false;
			if (form.ShowDialog() == DialogResult.OK)
			{
				bResult = true;
			}
			form.Dispose();
			return bResult;
		}

		//-----------------------------------------------------------------
		private void CFormDetailIntervenant_Load(object sender, EventArgs e)
		{
			CWin32Traducteur.Translate(this);
			m_linkField.FillDialogFromObjet(m_profilEdite);
			//m_wndListeSousProfils.Remplir(m_profilEdite.RelationsProfilsContenus);
		}

		//-----------------------------------------------------------------
		private void m_btnAnnuler_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
		//-----------------------------------------------------------------
		private void m_btnOk_Click(object sender, EventArgs e)
		{
			m_linkField.FillObjetFromDialog(m_profilEdite);
			DialogResult = DialogResult.OK;
		}

	}
}