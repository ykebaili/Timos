using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using sc2i.common;
using sc2i.win32.common;
using timos.acteurs;
using sc2i.data;
using timos.data;
using sc2i.win32.data;

namespace timos.win32.composants
{

	public delegate void SetIntervenantEventHandler ( object sender, CActeur acteur );
	public partial class CFormChercheIntervenant : CFloatingFormBase
	{
		private CTypeIntervention_ProfilIntervenant m_profil = null;
		private CIntervention m_intervention = null;
		private SetIntervenantEventHandler m_handlerSetIntervenant = null;
        private bool m_bModeMulti = false;

		//------------------------------------------------------------------
		public CFormChercheIntervenant()
		{
			InitializeComponent();
			m_controlPlanning.BaseAffichee = new CFournisseurEntreesPlanning(CSc2iWin32DataClient.ContexteCourant);
            CWin32Traducteur.Translate(this);
            Image img = DynamicClassAttribute.GetImage(typeof(CActeur));
            if (img != null)
                m_picActeur.Image = img;
		}

        //------------------------------------------------------------------
        private void SetModeMulti()
        {
            m_panelBas.Visible = true;
            m_bModeMulti = true;
            m_listeIntervenants.CheckBoxes = true;

        }
        private EventHandler m_handlerFinSelection = null;
        //------------------------------------------------------------------
        public static void SelectIntervenants(
            CIntervention tache,
            CTypeIntervention_ProfilIntervenant profil,
            EventHandler finSelectionHandler,
            SetIntervenantEventHandler handler)
        {
            CFormChercheIntervenant form = new CFormChercheIntervenant();
            form.m_profil = profil;
            form.m_intervention = tache;
            form.SetModeMulti();
            form.m_handlerFinSelection = finSelectionHandler;
            form.m_handlerSetIntervenant = handler;
            form.Show();
        }

		//------------------------------------------------------------------
		public static void  FindIntervenant( 
			CIntervention tache, 
			CTypeIntervention_ProfilIntervenant profil,
			SetIntervenantEventHandler handler)
		{
			CFormChercheIntervenant form = new CFormChercheIntervenant();
			form.m_profil = profil;
			form.m_intervention = tache;
			form.m_handlerSetIntervenant = handler;
			form.Show();

		}


		//------------------------------------------------------------------
		private void CFormChercheIntervenant_Load(object sender, EventArgs e)
		{
            UpdateLibelleAffecter();
            UpdateLibelleDisplay();
			m_lblProfil.Text = m_profil.Libelle;
			CListeObjetsDonnees liste = new CListeObjetsDonnees(m_intervention.ContexteDonnee, typeof(CProfilElement));
			liste.Filtre = new CFiltreData(CProfilElement.c_champTypeSource + "=@1 and " +
				CProfilElement.c_champTypeElements + "=@2",
				typeof(CIntervention).ToString(),
				typeof(CActeur).ToString());
			m_cmbProfil.Init(liste, "Libelle", false);
			m_cmbProfil.ElementSelectionne = null;
			FillListe();
		}

		//------------------------------------------------------------------
		private void FillListe()
		{
			IProfilElement profil = null;
			if (m_cmbProfil.ElementSelectionne == null)
				profil = m_profil;
			else
				profil = (IProfilElement)m_cmbProfil.ElementSelectionne;

			CFiltreData filtre = null;
			if (m_txtFiltrer.Text != "")
			{
				filtre = sc2i.data.CFournisseurFiltreRapide.GetFiltreRapideForType(typeof(CActeur));
				if (filtre.Parametres.Count == 0)
					filtre.Parametres.Add("%"+m_txtFiltrer.Text+"%");
				else
					filtre.Parametres[0] = ("%"+m_txtFiltrer.Text+"%");
			}
			IRessourceEntreePlanning[] ressources = m_intervention.GetRessourcesPossibles ( 
				profil,
				filtre );
			m_listeIntervenants.ListeSource = ressources;
			m_listeIntervenants.Refresh();
		}

		//-------------------------------------------------------------------------------------
		private void m_cmbProfilRessource_SelectionChangeCommitted(object sender, EventArgs e)
		{
			FillListe();
		}

		private void m_panelDispo_Paint(object sender, PaintEventArgs e)
		{

		}

		private void m_arbre_AfterSelect(object sender, TreeViewEventArgs e)
		{
			m_timerUpdatePlanning.Enabled = false;
			m_timerUpdatePlanning.Enabled = true;
		}

		private void m_timerUpdatePlanning_Tick(object sender, EventArgs e)
		{
			m_timerUpdatePlanning.Enabled = false;
			if ( m_listeIntervenants.SelectedItems.Count == 1 )
			{
                m_controlPlanning.BaseAffichee = new CFournisseurEntreesPlanning(m_intervention.ContexteDonnee);
				m_controlPlanning.AfficheForRessource((IRessourceEntreePlanning)m_listeIntervenants.SelectedItems[0], m_intervention);
				m_panelDispo.Visible = true;
			}
			else
				m_panelDispo.Visible = false;

		}

		//----------------------------------------------------------------------------
		private void CFormChercheIntervenant_Leave(object sender, EventArgs e)
		{

		}

		
		//----------------------------------------------------------------------------
		private void m_listeIntervenants_OnChangeSelection(object sender, EventArgs e)
		{
			m_timerUpdatePlanning.Enabled = false;
			m_timerUpdatePlanning.Enabled = true;
            UpdateLibelleAffecter();
		}

		//----------------------------------------------------------------------------
		private void m_listeIntervenants_DoubleClick(object sender, EventArgs e)
		{
            DefinitAffectation();
		}

        //----------------------------------------------------------------------------
        private void DefinitAffectation()
        {
            if (m_listeIntervenants.SelectedItems.Count == 1)
            {
                CActeur acteur = (CActeur)m_listeIntervenants.SelectedItems[0];
                if (m_bModeMulti)
                {
                    //Affecte l'intervenant à l'intervention
                    m_intervention.AssocieActeur(m_profil, acteur);
                }
                if (acteur != null && m_handlerSetIntervenant != null)
                    m_handlerSetIntervenant(this, acteur);
                Hide();
            }
        }

        //----------------------------------------------------------------------------
		private void m_btnfiltrer_Click(object sender, EventArgs e)
		{
			FillListe();
		}

        //----------------------------------------------------------------------------
        private void m_btnOk_Click(object sender, EventArgs e)
        {
            
        }

        //----------------------------------------------------------------------------
        public CActeur[] ActeursSelectionnes
        {
            get
            {
                List<CActeur> lst = new List<CActeur>();
                foreach (CActeur acteur in m_listeIntervenants.CheckedItems)
                    lst.Add(acteur);
                return lst.ToArray();
            }
        }

        private void m_listeIntervenants_CheckedChange(object sender, int nNumItem)
        {
            UpdateLibelleDisplay();
        }

        //---------------------------------------------------
        private void UpdateLibelleDisplay()
        {
            m_lnkDisplay.Text = I.T("Display the @1 checked member(s)|20021",
                m_listeIntervenants.CheckedItems.Count.ToString());
        }

        //---------------------------------------------------
        private void UpdateLibelleAffecter()
        {
            if (m_listeIntervenants.SelectedItems.Count == 1)
            {
                CActeur acteur = m_listeIntervenants.SelectedItems[0] as CActeur;
                m_lnkAffecter.Text = I.T("Affect @1 as @2|20022",
                    acteur.IdentiteComplete,
                    m_profil.Libelle);
                m_lnkAffecter.Enabled = true;
            }
            else
            {
                m_lnkAffecter.Text = "";
                m_lnkAffecter.Enabled = false;
            }

        }

        //---------------------------------------------------
        private void m_lnkDisplay_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (m_handlerFinSelection != null)
                m_handlerFinSelection(this, null);
            Hide();
        }

        //---------------------------------------------------
        private void m_lnkAffecter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DefinitAffectation();
        }







	}
}