using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using sc2i.common;
using sc2i.win32.common;

using timos.securite;

namespace timos
{
	public partial class CFormDefinirMDP : Form
	{
		public static DialogResult Show(CDonneesActeurUtilisateur donnees)
		{
			CFormDefinirMDP frm = new CFormDefinirMDP(donnees);
			return frm.ShowDialog();
		}

		public CFormDefinirMDP(CDonneesActeurUtilisateur donnees)
		{
			InitializeComponent();

			if (donnees == null)
			{
				DialogResult = DialogResult.Cancel;
				Close();
			}
			else
			{
				m_donnes = donnees;
				AcceptButton = m_btnOk.Bouton;
				CancelButton = m_btnCancel.Bouton;
				if (CUtilUtilisateur.UtilisateurConnecteIsUserManager(donnees.ContexteDonnee))
				{
					m_txtOldPassword.Visible = false;
					m_lblOldPassword.Visible = false;
					Height -= m_txtOldPassword.Height - (m_txtPassword.Top - m_txtOldPassword.Bottom);
				}
				CWin32Traducteur.Translate(this);
			}
		}

		private CDonneesActeurUtilisateur m_donnes;

		private bool m_btnOk_ClicBouton()
		{
			if (m_txtPassword.Text.Trim() != m_txtPasswordConfirm.Text.Trim())
			{
				CFormAlerte.Afficher(I.T("Password doesn't correspond to the confirmed password !|30017"), EFormAlerteType.Erreur);
				return false;
			}

			CResultAErreur result = m_donnes.ChangePassword(m_txtOldPassword.Text, m_txtPassword.Text);
			if(!result)
				CFormAlerte.Afficher(result);

			return result;
		}
	}
}
