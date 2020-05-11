using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using sc2i.common;

using timos.data;
using sc2i.win32.common;

namespace timos
{
	public partial class CFormMapTypeTable : Form
	{
		public CFormMapTypeTable()
		{
			InitializeComponent();
			sc2i.win32.common.CWin32Traducteur.Translate(this);
		}

		private DataTable m_dtSource;
		private DataTable m_dtCible;
		private CTypeTableParametrable m_tpCible;
		private CTypeTableParametrable m_tpSource;

		public void Initialiser(
			CTypeTableParametrable tpSource, 
			CTypeTableParametrable tpCible, 
			DataTable dtSource,
			DataTable dtCible)
		{
			m_tpCible = tpCible;
			m_dtCible = dtCible;
			m_tpSource = tpSource;
			m_dtSource = dtSource;
			m_mappeur = new CMappeurTypeTableParametrableTypeTableParametrable(tpSource, tpCible, true);
			m_ctrlEditMappage.Initialiser(m_mappeur);
		}

		private CMappeurTypeTableParametrableTypeTableParametrable m_mappeur;




		private bool Mapper()
		{
			CResultAErreur result = CResultAErreur.True;
			m_ctrlEditMappage.MAJChamp();
			if (!ContinueOrCancel(m_mappeur.VerifMappage()))
				return false;

			if (!ContinueOrCancel(m_mappeur.Mapper(m_dtSource, m_dtCible)))
				return false;

			return true;
		}

		private bool ContinueOrCancel(CResultAErreur result)
		{
			if (!result)
			{
				bool bNonBloquant = true;
				foreach (IErreur err in result.Erreur.Erreurs)
					if (err.GetType() != typeof(CErreurValidation))
					{
						bNonBloquant = false;
						break;
					}
				if (bNonBloquant)
				{
					if (CFormAlerte.Afficher(result.Erreur) != DialogResult.Cancel)
					{
						return false;
					}
				}
				else
				{
					CFormAlerte.Afficher(result.Erreur);
					return false;
				}
			}
			return true;
		}

		private void m_btnOk_Click(object sender, EventArgs e)
		{
			if (Mapper())
				DialogResult = DialogResult.OK;
		}
		private void m_btnAnnuler_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
	}
}