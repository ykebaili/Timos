using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using sc2i.win32.common;
using timos.data;

namespace timos.acteurs
{
	public partial class CFormFloatContactOccupation : CFloatingFormBase
	{
		//private bool m_bInitialise = false;
		private CActeur m_acteur = null;
		
		protected CFormFloatContactOccupation()
		{
			InitializeComponent();
		}



		public static void Afficher(CActeur acteur)
		{
			Afficher(acteur, null);

		}

		public static void Afficher(CActeur acteur, Form frmSource)
		{
			CFormFloatContactOccupation frm = new CFormFloatContactOccupation();

			frm.m_acteur = acteur;
			if (frmSource == null)
				frm.Show();
			else
				frm.Show(frmSource);

		}

		private void CFormFloatContactsPhase_Load(object sender, EventArgs e)
		{
			m_controlPlanning.AfficheForRessource(m_acteur, DateTime.Now, DateTime.Now);

		}

	}
}