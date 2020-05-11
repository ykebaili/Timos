using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using sc2i.workflow;
using sc2i.win32.common;
using sc2i.common;

using timos.data;

namespace timos.win32.composants
{
	public partial class CFormCheckListPopup : CFloatingFormBase
	{

		private CIntervention m_intervention;

		public CFormCheckListPopup()
		{
			InitializeComponent();
            CWin32Traducteur.Translate(this);
		}

		public static void Popup(
			Point screenPoint, 
			CIntervention intervention,
			bool bModeEdition)
		{

			CFormCheckListPopup form = new CFormCheckListPopup();

			form.m_intervention = intervention;
			Size sz = form.Size;
			Screen scr = Screen.FromPoint(screenPoint);
			Point ptStart = screenPoint;
			if (ptStart.X + sz.Width > scr.WorkingArea.Right)
				ptStart.Offset(-sz.Width, 0);
			if (ptStart.Y + sz.Height > scr.WorkingArea.Bottom)
				ptStart.Offset(0, -sz.Height);
			form.Size = sz;
			form.Location = ptStart;
			form.m_panelCheckList.LockEdition = !bModeEdition;
			form.m_panelCheckList.InitChamps(intervention);
			form.Show();
			/*form.Show();
			form.BringToFront();
			form.m_pointSourisInitial = Cursor.Position;
			form.Capture = true;
			form.Focus();*/
		}

		private void m_btnOk_Click(object sender, EventArgs e)
		{
			CResultAErreur result = CResultAErreur.True;
			result = m_panelCheckList.MajChamps ( );
			if ( !result )
				CFormAlerte.Afficher ( result.Erreur );
			else
				Close();
		}
	}
}