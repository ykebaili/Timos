using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using sc2i.common;
using sc2i.win32.data.dynamic;
using sc2i.win32.data.navigation;
using sc2i.data;
using timos.acteurs;

using timos.data;
using sc2i.win32.common;

namespace timos
{
	public partial class CFormPlanification : Form
	{
		private CContexteDonnee m_contexteDonnee;

		private CFournisseurEntreesPlanning m_fournisseurEntreesPlanning = null;

		private IElementAIntervention m_elementAIntervention = null;
		
		//--------------------------------------------
		public CFormPlanification()
		{
			InitializeComponent();
			m_contexteDonnee = new CContexteDonnee ( CTimosApp.SessionClient.IdSession, true, true );
            m_txtSelectElementAInterventions.Init<CSite>(
                "Libelle",
                true);
            m_fournisseurEntreesPlanning =  new CFournisseurEntreesPlanning(m_contexteDonnee);
			m_controlPlanning.BaseAffichee = m_fournisseurEntreesPlanning;
		}

		//--------------------------------------------
		private void CFormPlanification_Load(object sender, EventArgs e)
		{
			
		}

		//------------------------------------------------------------
		private void m_btnAjouter_Click(object sender, EventArgs e)
		{
			if (m_elementAIntervention == null)
				return;
			CTypeIntervention typeIntervention = (CTypeIntervention)CFormSelectUnObjetDonnee.SelectionRechercheRapide(
                I.T("Sélectionnez une intervention|20732"),
                typeof(CTypeIntervention), 
                null, 
                "", 
                "", 
                "");
			if (typeIntervention != null)
			{
				CIntervention tache = new CIntervention(m_contexteDonnee);
				tache.CreateNewInCurrentContexte();
				tache.TypeIntervention = typeIntervention;
				tache.ElementAIntervention = (CObjetDonneeAIdNumerique)m_elementAIntervention;
				tache.DureePrevisionnelle = typeIntervention.DureeStandardHeures;
				CFractionIntervention fraction = new CFractionIntervention(m_contexteDonnee);
				fraction.CreateNewInCurrentContexte();
				fraction.DateDebutPlanifie = m_controlPlanning.DateDebut;
				fraction.DateFinPlanifiee = fraction.DateDebutPlanifie.AddHours ( tache.DureePrevisionnelle );
				fraction.Intervention = tache;
				m_controlPlanning.Refresh();
				//m_controlPlanning.SelectTranche(fraction);
			}
		}

        //------------------------------------------------------------
		private void m_txtSelectElementAInterventions_OnSelectedObjectChanged(object sender, EventArgs e)
		{
			m_elementAIntervention = (IElementAIntervention)m_txtSelectElementAInterventions.ElementSelectionne;
			if ( m_elementAIntervention != null )
			{
				CSite site = new CSite(m_contexteDonnee);
				site.ReadIfExists(m_elementAIntervention.Id);
				m_elementAIntervention = site;
			}
			m_fournisseurEntreesPlanning.ClearElementsAIntervention();
			m_fournisseurEntreesPlanning.AddElementAIntervention(m_elementAIntervention);
			m_controlPlanning.Refresh();
		}

        //------------------------------------------------------------
		private void m_btnValider_Click(object sender, EventArgs e)
		{
			CResultAErreur result = m_contexteDonnee.SaveAll( true );
			if ( !result )
			{
				CFormAlerte.Afficher ( result.Erreur ) ;
			}
			else
			{
				CFormAlerte.Afficher(I.T("Ok|10"));
			}
		}

        //------------------------------------------------------------
		private void m_btnIntervenant_Click(object sender, EventArgs e)
		{
			CActeur part = (CActeur)CFormSelectUnObjetDonnee.SelectionRechercheRapide(
                I.T("Select an operator|20738"),
				typeof(CActeur),
				CFournisseurFiltreRapide.GetFiltreRapideForType(typeof(CActeur)),
				"",
				"",
				"");
			if (part != null)
			{
				CActeur part2 = new CActeur(m_contexteDonnee);
				part2.ReadIfExists(part.Id);
				part = part2;

				m_fournisseurEntreesPlanning.AddRessource(part);
				m_controlPlanning.Refresh();
				Refresh();
			}
		}

		//-------------------------------------------------------------------------
		private void m_radioIntervenants_CheckedChanged(object sender, EventArgs e)
		{
			if (m_radioIntervenants.Checked)
				m_controlPlanning.TypeRessourcesAAffecter = typeof(CActeur);
		}

		//-------------------------------------------------------------------------
		private void m_radioRessources_CheckedChanged(object sender, EventArgs e)
		{
			if (m_radioRessources.Checked)
				m_controlPlanning.TypeRessourcesAAffecter = typeof(CRessourceMaterielle);
		}
	}
}