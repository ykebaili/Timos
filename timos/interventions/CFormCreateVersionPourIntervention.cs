using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using sc2i.win32.common;
using sc2i.data;
using sc2i.common;

using timos.data;
using timos.version;

namespace timos.interventions
{
	public partial class CFormCreateVersionPourIntervention : Form
	{
		private CIntervention m_intervention;

		//--------------------------------------------------------
		public CFormCreateVersionPourIntervention()
		{
			InitializeComponent();
		}

		//--------------------------------------------------------
		private void CFormCreateVersionPourIntervention_Load(object sender, EventArgs e)
		{
			CWin32Traducteur.Translate(this);
			m_txtLibelleVersion.Text = I.T("Version for @1|1360", m_intervention.Libelle);
			m_radioLierNouveau.Checked = true;
			m_panelNewVersion.Visible = true;
			m_radioLierExistant.Checked = false;
			if (m_intervention.Projet != null)
			{
				m_chkFiltrerSurProjet.Visible = true;
				m_chkFiltrerSurProjet.Checked = true;
			}
			else
			{
				m_chkFiltrerSurProjet.Checked = false;
				m_chkFiltrerSurProjet.Checked = false;
			}
			InitListeVersions();		
		}

		//--------------------------------------------------------
		public static CVersionDonnees GetVersionForInter(CIntervention intervention)
		{
			if ( intervention.VersionDonneesAAppliquer != null )
			{
				CFormAlerte.Afficher(I.T("This intervention is already linked to a version|1355"), EFormAlerteType.Erreur);
				return intervention.VersionDonneesAAppliquer;
			}
			CFormCreateVersionPourIntervention form = new CFormCreateVersionPourIntervention();
			form.m_intervention = intervention;
			CVersionDonnees version = null;
			if (form.ShowDialog() == DialogResult.OK)
			{
				if (form.m_radioLierNouveau.Checked)
				{
					//S'assure que la version est bien sauvegardée, en la créant dans une nouveau contexte
					CContexteDonnee contexteForVersion = new CContexteDonnee(intervention.ContexteDonnee.IdSession, true, false);
					version = new CVersionDonnees(contexteForVersion);
					version.CreateNew();
					version.CodeTypeVersion = (int)CTypeVersion.TypeVersion.Previsionnelle;
					version.Libelle = form.m_txtLibelleVersion.Text;
					version.VersionParente = (CVersionDonnees)form.m_txtSelectVersionParente.ElementSelectionne;
					version.Date = DateTime.Now;
				}
				else
				{
					version = (CVersionDonnees)form.m_txtSelectVersionExistante.ElementSelectionne;
				}
			}
			form.Dispose();
			return version;
		}

		//--------------------------------------------------------
		private void InitListeVersions()
		{
			CProjet projet = null;
			if ( m_chkFiltrerSurProjet.Checked )
			{
				projet = m_intervention.Projet;
				if ( projet == null )
				{
					m_chkFiltrerSurProjet.Checked = false;
					m_chkFiltrerSurProjet.Visible = false;
				}
			}
			string strVersions = "";
			if ( projet != null )
			{
                //Gestion des interventions prédécesseurs pour les version (empilement de version)
                //Non utilisé le 21/09/2010
                /*
				CIntervention[] inters = projet.GetInterventionsPrecedent ( m_intervention );
				StringBuilder bl = new StringBuilder ( );
				foreach ( CIntervention intervention in inters )
				{
					if ( intervention.VersionDonneesAAppliquer != null )
					{
						bl.Append(intervention.VersionDonneesAAppliquer.Id);
						bl.Append(",");
					}
				}
				if ( bl.Length > 0 )
					bl.Remove ( bl.Length-1, 1);
				strVersions = bl.ToString();
                 * */
			}
			CFiltreData filtre = new CFiltreData(CVersionDonnees.c_champTypeVersion + "=@1",
				(int)CTypeVersion.TypeVersion.Previsionnelle);
			if ( strVersions.Length > 0 )
				filtre = CFiltreData.GetAndFiltre ( filtre,
					new CFiltreData (CVersionDonnees.c_champId+" in ("+strVersions+")"));
			m_txtSelectVersionParente.InitAvecFiltreDeBase<CVersionDonnees> ( 
				"Libelle",
				filtre,
				true);
		}

		private void m_btnOk_Click(object sender, EventArgs e)
		{
			if ( m_radioLierNouveau.Checked )
				if (m_txtLibelleVersion.Text == "")
				{
					CFormAlerte.Afficher(I.T("Enter a label for that version|1364"), EFormAlerteType.Exclamation);
					return;
				}
			if (m_radioLierExistant.Checked)
			{
				if (!(m_txtSelectVersionExistante.ElementSelectionne is CVersionDonnees))
				{
					CFormAlerte.Afficher(I.T("Select a version|1365"), EFormAlerteType.Exclamation);
					return;
				}
			}
			DialogResult = DialogResult.OK;
			Close();
		}

		private void m_btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void OnChangeRadioType(object sender, EventArgs e)
		{
			m_panelExistingVersion.Visible = m_radioLierExistant.Checked;
			m_panelNewVersion.Visible = m_radioLierNouveau.Checked;
		}

		private void m_chkFiltrerSurProjet_CheckedChanged(object sender, EventArgs e)
		{
			InitListeVersions();
		}
	}
}