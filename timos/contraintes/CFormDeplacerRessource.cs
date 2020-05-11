using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using sc2i.common;
using timos.data;
using timos.securite;
using sc2i.data;
using sc2i.workflow;
using timos.acteurs;
using sc2i.win32.common;

namespace timos
{
	public partial class CFormDeplacerRessource : Form
	{
		private CRessourceMaterielle m_ressource = null;


		//-------------------------------------------------------------------------
		public CFormDeplacerRessource()
		{
			InitializeComponent();
		}

		//-------------------------------------------------------------------------
		public static bool DeplaceRessource(CRessourceMaterielle ressource)
		{
			CFormDeplacerRessource form = new CFormDeplacerRessource();
			form.m_ressource = ressource;
			bool bResult = false;
			if (form.ShowDialog() == DialogResult.OK)
			{
				bResult = true;
			}
			form.Dispose();
			return bResult;
		}

		//-------------------------------------------------------------------------
		private void m_radioSite_CheckedChanged(object sender, EventArgs e)
		{

		}




		//-------------------------------------------------------------------------
		private void CFormDeplacerRessource_Load(object sender, EventArgs e)
		{
			sc2i.win32.common.CWin32Traducteur.Translate(this);
			m_selectSite.Init<CSite>(
				"Libelle",
                false);

			m_selectActeur.Init<CActeur>(
				"IdentiteComplete",
				false);

            if (m_ressource.TypeRessource != null)
            {
                m_radioSite.Enabled = m_ressource.TypeRessource.EmplacementSitePossible;
                m_selectSite.LockEdition = !m_ressource.TypeRessource.EmplacementSitePossible;

                m_radioActeur.Enabled = m_ressource.TypeRessource.EmplacementActeurPossible;
                m_selectActeur.LockEdition = !m_ressource.TypeRessource.EmplacementActeurPossible;

            }


			if ( m_ressource.EmplacementSite != null )
			{
				
				m_radioSite.Checked = true;
				m_selectSite.Focus();
			}
			else
			{
				m_radioActeur.Checked = true;
				m_selectActeur.Focus();
			}

			m_selectSite.ElementSelectionne = m_ressource.EmplacementSite;
			m_selectActeur.ElementSelectionne = m_ressource.EmplacementActeur;


			m_dtMouvement.Value = DateTime.Now;

			CFiltreData filtre = new CFiltreDataAvance ( CActeur.c_nomTable,
				"Has("+CDonneesActeurUtilisateur.c_nomTable+"."+
				CDonneesActeurUtilisateur.c_champId+")");
			m_selectUser.InitAvecFiltreDeBase<CActeur>("IdentiteComplete", filtre, true);
			CDonneesActeurUtilisateur user = CUtilSession.GetUserForSession(m_ressource.ContexteDonnee);
			if ( user != null )
				m_selectUser.ElementSelectionne = user.Acteur;
			
		}


		//----------------------------------------------------------------
		private void m_btnOk_Click(object sender, EventArgs e)
		{
			IPossesseurRessource emplacement = null;

            if (m_radioSite.Checked)
			{
				emplacement = (CSite)m_selectSite.ElementSelectionne;
			}
			if (m_radioActeur.Checked)
				emplacement = (CActeur)m_selectActeur.ElementSelectionne;

			CActeur acteur = (CActeur)m_selectUser.ElementSelectionne;

			CResultAErreur result = m_ressource.DeplaceRessource(
				m_txtInfo.Text,
				emplacement,
				acteur == null?null:acteur.Utilisateur,
				m_dtMouvement.Value);
			
            if (!result)
				CFormAlerte.Afficher(result.Erreur);
			else
			{
				DialogResult = DialogResult.OK;
				Close();
			}
		}

        //-------------------------------------------------------------------------
        private void m_txtSelectSite_ElementSelectionneChanged(object sender, EventArgs e)
        {
            if (m_selectSite.ElementSelectionne != null)
                m_radioSite.Checked = true;
        }

		private void m_selectActeur_ElementSelectionneChanged(object sender, EventArgs e)
		{
			if (m_selectActeur.ElementSelectionne != null)
				m_radioActeur.Checked = true;
		}

	}
}