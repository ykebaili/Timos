using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using sc2i.common;
using sc2i.win32.common;
using sc2i.data.dynamic;
using timos.data;
using sc2i.data;

namespace timos
{
	public partial class CControlEditionTypeTableParametrable : UserControl, IControlALockEdition
	{
		public CControlEditionTypeTableParametrable()
		{
			InitializeComponent();
		}

		private CTypeTableParametrable m_typeTable;
		public CTypeTableParametrable TypeTableParametrable
		{
			get
			{
				return m_typeTable;
			}
		}

		//--------------------------------------------------------------------------
		public CResultAErreur Init(CTypeTableParametrable typeTable)
		{
			CResultAErreur result = CResultAErreur.True;

			m_ctrlEditCol.Visible = false;
			m_typeTable = typeTable;

			m_gestionnaireTabControl.ForceInitPageActive();
			m_gestionnaireColonnes.ObjetEdite = typeTable.Colonnes;
			m_extFieldCol.FillDialogFromObjet(m_typeTable);
			MAJComboBoxPKs();
			MAJColonnesPks();

            // Visibilité de l'onglet Formulaires
            bool bHasFormulaires = false;
            foreach (IDefinisseurChampCustom def in TypeTableParametrable.DefinisseursDeChamps)
            {
                if (def.RelationsFormulaires.Length > 0)
                {
                    bHasFormulaires = true;
                    break;
                }
            }
            if (!bHasFormulaires)
            {
                if (m_TabControl.TabPages.Contains(m_pageFormulaires))
                    m_TabControl.TabPages.Remove(m_pageFormulaires);
            }
            else
            {
                if (!m_TabControl.TabPages.Contains(m_pageFormulaires))
                    m_TabControl.TabPages.Insert(0, m_pageFormulaires);
            }

			return result;
		}

		//--------------------------------------------------------------------------
		public CResultAErreur MajChamps()
		{
			CResultAErreur result = CResultAErreur.True;

			result = m_gestionnaireColonnes.ValideModifs();
			if(result)
				result = m_extFieldCol.FillObjetFromDialog(m_typeTable);
			if(result)
				result = m_gestionnaireTabControl.MAJPages();
			return result;
		}

		#region Colonnes
		private void m_lnkAjouter_LinkClicked(object sender, EventArgs e)
		{
			CColonneTableParametrable col = new CColonneTableParametrable(TypeTableParametrable.ContexteDonnee);
			col.CreateNewInCurrentContexte();
			col.Libelle = I.T("New column|1242");
			col.TypeDonneeChamp = new C2iTypeDonnee(TypeDonnee.tString);
			col.TypeTable = TypeTableParametrable;
			col.Position = m_wndColonnes.Items.Count;

			ListViewItem item = new ListViewItem();
			m_wndColonnes.Items.Add(item);
			m_wndColonnes.UpdateItemWithObject(item, col);
			foreach (ListViewItem itemSel in m_wndColonnes.SelectedItems)
				itemSel.Selected = false;
			item.Selected = true;

			MAJComboBoxPKs();
		}
		private void m_lnkSupprimer_LinkClicked(object sender, EventArgs e)
		{
			if (m_wndColonnes.SelectedItems.Count != 1)
				return;

			CColonneTableParametrable col = (CColonneTableParametrable)m_wndColonnes.SelectedItems[0].Tag;
			int pos = col.Position;

			if (col.PrimaryKeyPosition != null)
				m_typeTable.DefinirSansClePrimaire(col);

			m_gestionnaireColonnes.SetObjetEnCoursToNull();
			CResultAErreur result = col.Delete();
			if (!result)
			{
				CFormAlerte.Afficher(result.Erreur);
				return;
			}

			//On met à jour les positions des éléments restant
			if (m_wndColonnes.SelectedItems.Count == 1)
			{
				if (m_wndColonnes.SelectedItems[0] != null)
					m_wndColonnes.SelectedItems[0].Remove();

				while (pos <= m_wndColonnes.Items.Count - 1)
				{
					CColonneTableParametrable coltmp = (CColonneTableParametrable)m_wndColonnes.Items[pos].Tag;
					coltmp.Position = pos;
					pos++;
				}
			}

			MAJColonnesPks();
		}

		private void m_gestionnaireColonnes_InitChamp(object sender, CObjetDonneeResultEventArgs args)
		{
			if (args.Objet == null)
			{
				m_ctrlEditCol.Visible = false;
				return;
			}
			CColonneTableParametrable col = (CColonneTableParametrable)args.Objet;
			m_ctrlEditCol.Init(col);
			m_panelCol.Visible = true;
			m_ctrlEditCol.Visible = true;
		}
		private void m_gestionnaireColonnes_MAJ_Champs(object sender, CObjetDonneeResultEventArgs args)
		{
			if (args.Objet != null)
			{
				MAJComboBoxPKs();
				MAJColonnesPks();
			}
		}

		#endregion

		#region Cle Primaire
		private void MAJComboBoxPKs()
		{
			m_cmbPk.Items.Clear();
			foreach (CColonneTableParametrable col in m_typeTable.Colonnes)
				if (col.PrimaryKeyPosition == null)
					m_cmbPk.Items.Add(col);

			m_nudPk.Refresh();
		}
		private void MAJColonnesPks()
		{
			m_lvPks.Items.Clear();
			foreach (CColonneTableParametrable c in m_typeTable.ColonnesClePrimaires)
			{
				ListViewItem itm = new ListViewItem(c.Libelle);
				itm.Tag = c;
				m_lvPks.Items.Add(itm);
			}
		}

		private ListViewItem GetPKListViewItem(CColonneTableParametrable col)
		{
			foreach (ListViewItem itm in m_lvPks.Items)
				if ((CColonneTableParametrable)itm.Tag == col)
					return itm;

			return null;
		}
		private void AjouterPK(CColonneTableParametrable col)
		{
			if (col.PrimaryKeyPosition != null)
				return;

			m_typeTable.DefinirEnClePrimaire(col);
			ListViewItem itm = new ListViewItem(col.Libelle);
			itm.Tag = col;
			m_lvPks.Items.Add(itm);

			MAJComboBoxPKs();
		}
		private void SupprimerPK(CColonneTableParametrable col)
		{
			if (col.PrimaryKeyPosition == null)
				return;

			m_typeTable.DefinirSansClePrimaire(col);

			ListViewItem itm = GetPKListViewItem(col);
			if (itm == null)
				return;

			m_lvPks.Items.Remove(itm);
			MAJComboBoxPKs();
		}

		private void m_lnkAddPk_LinkClicked(object sender, EventArgs e)
		{
			if (m_cmbPk.SelectedItem == null)
				return;
			AjouterPK((CColonneTableParametrable)m_cmbPk.SelectedItem);
		}
		private void m_lnkRemovePk_LinkClicked(object sender, EventArgs e)
		{
			if (m_lvPks.SelectedItems.Count != 1)
				return;
			SupprimerPK((CColonneTableParametrable)m_lvPks.SelectedItems[0].Tag);
		}
		#endregion

		#region IControlALockEdition Membres
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
			}
		}

		public event EventHandler OnChangeLockEdition;
		#endregion

		private CResultAErreur m_gestionnaireTabControl_OnInitPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			using (CWaitCursor waiter = new CWaitCursor())
			{
                if (page == m_pageFormulaires)
                {
                    m_panelChamps.ElementEdite = TypeTableParametrable;
                }
				else if (page == m_pageChampsCustom)
				{
					m_panelEditChamps.InitPanel(
					 TypeTableParametrable,
					 typeof(CFormListeChampsCustom),
					 typeof(CFormListeFormulaires));

				}
					//Géré dans l'initialisation globale
				//else if (page == m_pageClePrimaire || page == m_pageColonnes)
				//{
				//}
				else if (page == m_pageTypesEquipements)
				{
					m_typesEquipementsSelec.Init(
					new CListeObjetsDonnees(TypeTableParametrable.ContexteDonnee, typeof(CTypeEquipement)),
					TypeTableParametrable.RelationsTypesEquipements,
					TypeTableParametrable,
					"TypeTableParametrable",
					"TypeEquipement");

					m_typesEquipementsSelec.RemplirGrille();
				}
				else if (page == m_pageTypesSites)
				{
					m_typesSitesSelec.Init(
					new CListeObjetsDonnees(TypeTableParametrable.ContexteDonnee, typeof(CTypeSite)),
					TypeTableParametrable.RelationsTypesSites,
					TypeTableParametrable,
					"TypeTableParametrable",
					"TypeSite");
					m_typesSitesSelec.RemplirGrille();
				}

			}
			return result;
		}

		private CResultAErreur m_gestionnaireTabControl_OnMajChampsPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;

            if (page == m_pageFormulaires)
            {
                result = m_panelChamps.MAJ_Champs();
            }
			else if (page == m_pageChampsCustom)
			{
				result = m_panelEditChamps.MAJ_Champs();

			}
			else if (page == m_pageClePrimaire || page == m_pageColonnes)
			{
			}
			else if (page == m_pageTypesEquipements)
			{
				m_typesEquipementsSelec.ApplyModifs();

			}
			else if (page == m_pageTypesSites)
			{
				m_typesSitesSelec.ApplyModifs();

			}

			return result;
		}

	}
}
