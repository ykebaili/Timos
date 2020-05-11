using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using sc2i.common;
using sc2i.data;
using sc2i.workflow;
using sc2i.win32.common;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;

using timos.data;

namespace timos.acteurs
{
	/// <summary>
	/// Permet d'éditer un objet TypeElementAActeursPossibles pour lui spécifier
	/// les profils d'acteurs disponibles (en les ordonnant) ainsi que de choisir
	/// un modele de representation de ces acteurs
	/// </summary>
	public partial class CControlEditionTypeElementAContacts : UserControl, IControlALockEdition
	{
		private ITypeElementAContacts m_typeelem;
		//------------------------------------------------
		public CControlEditionTypeElementAContacts()
		{
			InitializeComponent();
		}

		//------------------------------------------------
		public void Init(ITypeElementAContacts typeelem)
		{
			m_typeelem = typeelem;

			//Chargement des modeles disponibles pour les acteurs
			CListeObjetsDonnees lstModeles = new CListeObjetsDonnees(typeelem.ContexteDonnee, typeof(CModeleTexte));
			lstModeles.Filtre = new CFiltreData(
                CModeleTexte.c_champTypeAssocie + " = @1",
                (typeof(CActeur)).ToString());

			m_cmbModeleActeur.Init(lstModeles, "Libelle", typeof(CModeleTexte), true);
			if (typeelem.ModeleTexteContacts != null)
			{
				try
				{
					m_cmbModeleActeur.ElementSelectionne = typeelem.ModeleTexteContacts;
				}
				catch
				{
					typeelem.ModeleTexteContacts = null;
					m_cmbModeleActeur.ElementSelectionne = null;
				}
			}
			else
				m_cmbModeleActeur.ElementSelectionne = null;

			//Chargement des profils elements qui retourne des acteurs pour le type du TypeElementAActeursPossibles
			CListeObjetsDonnees lstProfils = new CListeObjetsDonnees(m_typeelem.ContexteDonnee, typeof(CProfilElement));
			lstProfils.Filtre = new CFiltreData(
                CProfilElement.c_champTypeSource + " = @1 AND " + 
                CProfilElement.c_champTypeElements + " = @2",
                m_typeelem.TypeDesElementsAContacts.ToString(),
                (typeof(CActeur)).ToString());

			m_cmbProfils.Init(lstProfils, "Libelle", typeof(CFormEditionProfilElement), true);

			m_gestionnaireLstProfils.ObjetEdite = typeelem.ProfilsContacts;
		}




		//Suppression
		private void m_lnkRemove_LinkClicked(object sender, EventArgs e)
		{
			if (m_lvProfils.SelectedItems.Count != 1)
				return;

			CActeursSelonProfil rel = (CActeursSelonProfil)m_lvProfils.SelectedItems[0].Tag;
			int pos = rel.Ordre;
			m_gestionnaireLstProfils.SetObjetEnCoursToNull();
			CResultAErreur result = rel.Delete();
			if (!result)
			{
				CFormAlerte.Afficher(result.Erreur);
				return;
			}

			//On met à jour les positions des éléments restant
			if (m_lvProfils.SelectedItems.Count == 1)
			{
				if (m_lvProfils.SelectedItems[0] != null)
					m_lvProfils.SelectedItems[0].Remove();

				while (pos <= m_lvProfils.Items.Count - 1)
				{
					CActeursSelonProfil reltmp = (CActeursSelonProfil)m_lvProfils.Items[pos].Tag;
					reltmp.Ordre = pos;
					pos++;
				}

				//MAJ ListViewItems
				m_gestionnaireLstProfils.ObjetEdite = m_typeelem.ProfilsContacts;
			}
		}
		//Ajout
		private void m_lnkAjouterProfil_LinkClicked(object sender, EventArgs e)
		{
			if (m_cmbProfils.ElementSelectionne == null)
			{
				CFormAlerte.Afficher(I.T( "Select the supplier to add|203"));
				return;
			}

			CProfilElement profselec = (CProfilElement) m_cmbProfils.ElementSelectionne;

			//Test d'unicité
			foreach (ListViewItem itm in m_lvProfils.Items)
				if (itm.SubItems[1].Text == profselec.Libelle)
				{
					m_lvProfils.SelectedItems.Clear();
					itm.Selected = true;
					return;
				}

			CActeursSelonProfil rel = new CActeursSelonProfil(m_typeelem.ContexteDonnee);
			rel.CreateNewInCurrentContexte();
			rel.Profil = profselec;
			if (m_typeelem is CTypePhase)
			{
				rel.TypePhase = (CTypePhase)m_typeelem;
				rel.TypeIntervention = null;
			}
			else if (m_typeelem is CTypeIntervention)
			{
				rel.TypePhase = null;
				rel.TypeIntervention = (CTypeIntervention)m_typeelem;
			}

			rel.Ordre = m_lvProfils.Items.Count;


			ListViewItem item = new ListViewItem();
			m_lvProfils.Items.Add(item);
			m_lvProfils.UpdateItemWithObject(item, rel);
			foreach (ListViewItem itemSel in m_lvProfils.SelectedItems)
				itemSel.Selected = false;
			item.Selected = true;
		}



		//-------------------------------------------------------------------------
		public CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = CResultAErreur.True;

			if (result)
				result = m_gestionnaireLstProfils.ValideModifs();

			m_typeelem.ModeleTexteContacts = (CModeleTexte)m_cmbModeleActeur.ElementSelectionne;

			return result;
		}



		//LockEdition
		public bool LockEdition
		{
			get
			{
				return !m_gestionnaireModeEdition.ModeEdition;
			}
			set
			{
				m_gestionnaireModeEdition.ModeEdition = !value;
				if (OnChangeLockEdition != null)
					OnChangeLockEdition(this, new EventArgs());

				//Si on passe en edition
				if (m_gestionnaireModeEdition.ModeEdition)
				{

				}
				else
				{

				}


			}
		}
		public event EventHandler OnChangeLockEdition;

		private void m_ctrlMD_ApresRenumeration(object sender, EventArgs e)
		{
			//MAJ ListViewItems
			m_gestionnaireLstProfils.ObjetEdite = m_typeelem.ProfilsContacts;
		}

	}
}
