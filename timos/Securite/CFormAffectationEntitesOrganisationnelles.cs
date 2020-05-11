using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using sc2i.common;
using sc2i.data;
using timos.securite;
using sc2i.multitiers.client;
using sc2i.win32.common;

namespace timos
{
	public partial class CFormAffectationEntitesOrganisationnelles : Form
	{
		private bool m_bStopEditionSurSortie = false;
		private CObjetDonneeAIdNumerique m_objet;
		//-----------------------------------------------------------
		public CFormAffectationEntitesOrganisationnelles()
		{
			InitializeComponent();
		}

		//-----------------------------------------------------------
		private void c2iPanelOmbre1_Paint(object sender, PaintEventArgs e)
		{

		}

		//-----------------------------------------------------------
		/// <summary>
		/// Permet de modifier les affectation aux entités relationnelles
		/// d'un objet. Attention, l'objet doit être en édition
		/// </summary>
		/// <param name="objet"></param>
		/// <returns></returns>
		public static bool AffecteEntites(CObjetDonneeAIdNumerique objet)
		{
			CFormAffectationEntitesOrganisationnelles form = new CFormAffectationEntitesOrganisationnelles();
			form.m_objet = objet;
			bool bResult = false;
			if (form.ShowDialog() == DialogResult.OK)
			{
				if (form.m_bStopEditionSurSortie)
				{
					CResultAErreur result = form.m_objet.CommitEdit();
					if (!result)
					{
						CFormAlerte.Afficher(result.Erreur);
						bResult = false;
					}
					else
						bResult = true;
				}
			}
			else
			{
				if (form.m_bStopEditionSurSortie)
					form.m_objet.CancelEdit();
			}
			form.Dispose();
			return bResult;
		}


		//-----------------------------------------------------------
		private void m_btnOk_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		//-----------------------------------------------------------
		private void CFormAffectationEntitesOrganisationnelles_Load(object sender, EventArgs e)
		{
			sc2i.win32.common.CWin32Traducteur.Translate(this);
			m_lblEntite.Text = m_objet.DescriptionElement;
			m_extModeEdition.ModeEdition = false;
			
			m_btnOk.Visible = false;
			CSessionClient session = CSessionClient.GetSessionForIdSession(CTimosApp.SessionClient.IdSession);
			CRestrictionUtilisateurSurType rest = session.GetInfoUtilisateur().GetRestrictionsSurObjet(m_objet, m_objet.ContexteDonnee.IdVersionDeTravail);
			if (rest.CanModifyType() && !m_objet.ContexteDonnee.IsEnEdition)
			{
				rest = session.GetInfoUtilisateur().GetRestrictionsSur(typeof(CRelationElement_EO), m_objet.ContexteDonnee.IdVersionDeTravail);
				m_lnkAjouter.Visible = rest.CanCreateType();
				m_lnkSupprimer.Visible = rest.CanDeleteType();
				m_btnOk.Visible = m_lnkAjouter.Visible || m_lnkSupprimer.Visible;
				m_extModeEdition.ModeEdition = m_btnOk.Visible;
				m_objet.BeginEdit();
				m_bStopEditionSurSortie = true;
			}
			m_wndListeEos.ListeSource = CRelationElement_EO.GetListeRelationsForElement(m_objet);
			
		}

		private void m_lnkSupprimer_LinkClicked(object sender, EventArgs e)
		{
			if (m_wndListeEos.SelectedItems.Count == 0)
				return;
			CRelationElement_EO rel = (CRelationElement_EO)m_wndListeEos.SelectedItems[0];
			if (CFormAlerte.Afficher(I.T( "Supprimer le lien à l'élément sélectionné ?|126"),
				EFormAlerteType.Question) == DialogResult.Yes)
			{
				rel.Delete();
				m_wndListeEos.Refresh();
			}
		}

		private void m_lnkAjouter_LinkClicked(object sender, EventArgs e)
		{
			CEntiteOrganisationnelle entite = (CEntiteOrganisationnelle)CFormSelectObjetHierarchique.SelectObjet(typeof(CEntiteOrganisationnelle),null);
			if (entite != null)
			{
				//Vérifie qu'aucun parent n'est affecté à l'élément
				ArrayList lst = new ArrayList(m_wndListeEos.ListeSource);
				foreach (CRelationElement_EO rel in lst)
				{
					if (rel.EntiteOrganisationnelle.IsParentOf(entite))
					{
						CFormAlerte.Afficher(I.T( "The object ever belong to this entity|128") + " (" +
							rel.EntiteOrganisationnelle.Libelle + ")", EFormAlerteType.Exclamation);
						return;
					}
					if (rel.EntiteOrganisationnelle.IsChildOf(entite))
					{
						rel.Delete();
					}
				}
				CRelationElement_EO newRel = new CRelationElement_EO(m_objet.ContexteDonnee);
				newRel.CreateNewInCurrentContexte();
				newRel.EntiteOrganisationnelle = entite;
				newRel.ElementLie = m_objet;
				m_wndListeEos.ListeSource = CRelationElement_EO.GetListeRelationsForElement(m_objet);
				m_wndListeEos.Refresh();
			}
		}
	}
}