using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using sc2i.data;
using sc2i.common;
using sc2i.win32.common;
using sc2i.win32.data.navigation;

using timos.data;
using timos.data.preventives;

namespace timos.preventives
{
	public partial class CFormFloatSelectFormatDate : CFloatingFormBase
	{
		private EFormatDate m_format;
		public static EFormatDate GetFormatDate(EFormatDate formatActuel)
		{
			CFormFloatSelectFormatDate frm = new CFormFloatSelectFormatDate();
			frm.Initialiser(formatActuel);
			frm.Location = Cursor.Position;
			frm.ShowDialog();
			return frm.FormatDate;
		}

		public EFormatDate FormatDate
		{
			get
			{
				return m_format;
			}
		}

		protected CFormFloatSelectFormatDate()
		{
			InitializeComponent();
			sc2i.win32.common.CWin32Traducteur.Translate(this);
		}


		private void Initialiser(EFormatDate formatDate)
		{
			m_format = formatDate;
			switch (formatDate)
			{
				default:
				case EFormatDate.JourMoisAnnee:
					m_rbtJourMoisAnnee.Checked = true;
					break;
				case EFormatDate.Semaine:
					m_rbtSemaine.Checked = true;
					break;
				case EFormatDate.JourMois:
					m_rbtJourMois.Checked = true;
					break;
				case EFormatDate.MoisAnnee:
					m_rbtMoisAnnee.Checked = true;
					break;
				case EFormatDate.Jour:
					m_rbtJour.Checked = true;
					break;
				case EFormatDate.Mois:
					m_rbtMois.Checked = true;
					break;
				case EFormatDate.Annee:
					m_rbtAnnee.Checked = true;
					break;
			}
		}

		private void m_btnOk_Click(object sender, EventArgs e)
		{
			if (m_rbtJourMoisAnnee.Checked)
				m_format = EFormatDate.JourMoisAnnee;
			else if (m_rbtJourMois.Checked)
				m_format = EFormatDate.JourMois;
			else if (m_rbtMoisAnnee.Checked)
				m_format = EFormatDate.MoisAnnee;
			else if (m_rbtMois.Checked)
				m_format = EFormatDate.Mois;
			else if (m_rbtJour.Checked)
				m_format = EFormatDate.Jour;
			else if (m_rbtAnnee.Checked)
				m_format = EFormatDate.Annee;
			else if (m_rbtSemaine.Checked)
				m_format = EFormatDate.Semaine;

			DialogResult = DialogResult.OK;
		}

		private void m_btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

	

	}
}