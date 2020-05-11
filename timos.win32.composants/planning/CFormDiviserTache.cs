using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using sc2i.win32.common;
using timos.data;

namespace timos.win32.composants
{
	public partial class CFormDiviserIntervention : Form
	{
		public CFormDiviserIntervention()
		{
			InitializeComponent();
		}

		private void CFormDiviserIntervention_Load(object sender, EventArgs e)
		{
			CWin32Traducteur.Translate(this);
		}

		public static DateTime? GetDateDivision(Point pt, CFractionIntervention fraction)
		{
			CFormDiviserIntervention form = new CFormDiviserIntervention();
			TimeSpan sp = (DateTime) fraction.DateFinPlanifiee - (DateTime)fraction.DateDebutPlanifie;
			DateTime? dt = fraction.DateDebutPlanifie;
			if ( dt == null )
				return null;
			double fMinutes = (((int)sp.TotalMinutes)/15)*15/2;
			form.m_datePicker.Value = ((DateTime)fraction.DateDebutPlanifie).AddMinutes(fMinutes);
			form.Location = SFormPopup.GetPointForFormPopup(pt, form);
			if (form.ShowDialog() == DialogResult.OK)
				return form.m_datePicker.Value;
			return null;
		}

		private void m_btnOk_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}
	}
}