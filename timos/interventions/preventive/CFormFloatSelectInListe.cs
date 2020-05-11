using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using sc2i.data;
using sc2i.data.dynamic;
using sc2i.common;
using sc2i.win32.data;
using sc2i.win32.common;
using sc2i.win32.data.navigation;
using timos.data;

namespace timos.preventives
{
	public partial class CFormFloatSelectInListe : CFloatingFormBase
	{

		public static List<CObjetDonneeAIdNumerique> GetSelectionInListe(CListeObjetsDonnees elementsPossibles, List<CObjetDonneeAIdNumerique> elementsPreSelectionnes, bool bAucunElementAutorise)
		{
			List<CObjetDonneeAIdNumerique> objSelecSAV = new List<CObjetDonneeAIdNumerique>();

			if (elementsPossibles.Count == 0)
			{
				foreach (CObjetDonneeAIdNumerique o in elementsPossibles)
					objSelecSAV.Add(o);
				return objSelecSAV;
			}


			for (int i = 0; i < elementsPreSelectionnes.Count; i++)
				if (elementsPossibles.Contains(elementsPreSelectionnes[i]))
					objSelecSAV.Add(elementsPreSelectionnes[i]);

			CFormFloatSelectInListe frm = new CFormFloatSelectInListe();
			frm.Initialiser(elementsPossibles, elementsPreSelectionnes, bAucunElementAutorise);
			frm.Location = Cursor.Position;
			if (frm.ShowDialog() == DialogResult.OK)
				return frm.ElementsSelectionnes;
			else
				return objSelecSAV;
		}


		#region Filtre
		//Contrôle de filtre en cours
		private int m_nHeightOld;
		private void m_lnkFiltrer_LinkClicked(object sender, EventArgs e)
		{
			m_panelFiltreEtOutils.Visible = !m_panelFiltreEtOutils.Visible;
			splitContainer1.SplitterDistance = m_panelFiltreEtOutils.Visible ? m_nHeightOld : 0;
			splitContainer1.FixedPanel = m_panelFiltreEtOutils.Visible ? FixedPanel.None : FixedPanel.Panel1;
		}

		private void m_btnListeFiltres_Click(object sender, System.EventArgs e)
		{
			m_menuFiltres.Show(m_btnListeFiltres, new Point(0, m_btnListeFiltres.Height));
		}


		private void m_btnAppliquer_Click_1(object sender, EventArgs e)
		{
			//On affiche que les sites possibles
			m_panelFiltreStd.AppliquerFiltre();
			m_elesPossibles.Filtre = m_panelFiltreStd.Filtre;
			FillElementsPossibles(null);

		}



		#region MENU
		private class CMenuItem : MenuItem
		{
			private bool m_bAffiche;
			public CMenuItem(CObjetDonneeAIdNumerique obj, string strNom)
			{
				m_bAffiche = true;
				m_obj = obj;
				base.Text = strNom;
			}


			public bool Affiche
			{
				get
				{
					return m_bAffiche;
				}
				set
				{
					m_bAffiche = value;
				}
			}
			public CObjetDonneeAIdNumerique ObjetDonnee
			{
				get
				{
					return m_obj;
				}
			}

			private CObjetDonneeAIdNumerique m_obj;
		}
		/// ////////////////////////////////////////////////////////////////////
		private class CMenuItemAFiltre : MenuItem
		{
			public readonly CFiltreDynamiqueInDb Filtre;

			public CMenuItemAFiltre(CFiltreDynamiqueInDb filtre)
				: base(filtre.Libelle)
			{
				Filtre = filtre;
			}
		}

		/// ////////////////////////////////////////////////////////////////////
		private void InitMenuFiltres()
		{
			CListeObjetsDonnees lstFiltres = new CListeObjetsDonnees(CSc2iWin32DataClient.ContexteCourant, typeof(CFiltreDynamiqueInDb));
			lstFiltres.Filtre = new CFiltreData(CFiltreDynamiqueInDb.c_champTypeElements + "=@1", m_type.ToString());
			m_menuFiltres.MenuItems.Clear();
			MenuItem menu = new MenuItem(I.T("Temporary filter|1313"));
			m_menuFiltres.MenuItems.Add(menu);
			m_menuFiltres.MenuItems.Add(new MenuItem("----------------"));
			foreach (CFiltreDynamiqueInDb filtre in lstFiltres)
			{
				CMenuItemAFiltre item = new CMenuItemAFiltre(filtre);
				item.Click += new EventHandler(OnSelectFiltre);
				m_menuFiltres.MenuItems.Add(item);
			}
		}	
	
		///// ////////////////////////////////////////////////////////////////////
		private void OnSelectFiltre(object sender, EventArgs args)
		{
			m_panelFiltreStd.SetFiltreDynamique(((CMenuItemAFiltre)sender).Filtre.Filtre);
		}

		#endregion
		#endregion


		//MAPPAGES
		private List<int> m_elementsSelectionnes;
		private Type m_type;
		private Dictionary<int, CObjetDonneeAIdNumerique> m_mappageObjetIndexInListe;
		private CListeObjetsDonnees m_elesPossibles;
		private bool m_bAutoriseZero = false;
		private bool m_bFillingListe = false;
		protected CFormFloatSelectInListe()
		{
			InitializeComponent();
			sc2i.win32.common.CWin32Traducteur.Translate(this);
		}


		private void FillElementsPossibles(List<CObjetDonneeAIdNumerique> elementsPreSelectionnes)
		{
			m_bFillingListe = true;
			if (elementsPreSelectionnes != null)
			{
				m_elementsSelectionnes = new List<int>();
				foreach(CObjetDonneeAIdNumerique oSelec in elementsPreSelectionnes)
					m_elementsSelectionnes.Add(oSelec.Id);
			}

			m_mappageObjetIndexInListe = new Dictionary<int, CObjetDonneeAIdNumerique>();
			m_glst.ListeSource = m_elesPossibles;
			int nCptIdEleInListe = 0;
			foreach (CObjetDonneeAIdNumerique o in m_elesPossibles)
			{
				m_mappageObjetIndexInListe.Add(nCptIdEleInListe, o);
				if (m_elementsSelectionnes.Contains(o.Id))
					m_glst.CheckItem(nCptIdEleInListe);
				else
					m_glst.UnCheckItem(nCptIdEleInListe);
				nCptIdEleInListe++;
			}
			m_glst.Refresh();
			m_bFillingListe = false;
		}


		private void Initialiser(CListeObjetsDonnees elementsPossibles, List<CObjetDonneeAIdNumerique> elementsPreSelectionnes, bool aucuneElementAutorise)
		{
			if (elementsPossibles.CountNoLoad == 0)
				DialogResult = DialogResult.Cancel;

			m_type = elementsPossibles[0].GetType();
			
			m_glst.CheckBoxes = true;
			m_elesPossibles = elementsPossibles;
			//m_elementsSelectionnes = new List<int>();
			//m_glst.Columns.Add(I.T("Description|41"), "DescriptionElement", m_glst.Width - 20);

			FillElementsPossibles(elementsPreSelectionnes);

			m_nHeightOld = m_panelFiltreEtOutils.Height;
			splitContainer1.SplitterDistance = 0;
			splitContainer1.FixedPanel = FixedPanel.Panel1;
			m_bAutoriseZero = aucuneElementAutorise;

			InitMenuFiltres();
		}

		public List<CObjetDonneeAIdNumerique> ElementsSelectionnes
		{
			get
			{
				List<CObjetDonneeAIdNumerique> elements = new List<CObjetDonneeAIdNumerique>();
				foreach (CObjetDonneeAIdNumerique o in m_glst.CheckedItems)
					elements.Add(o);

				return elements;
			}
		}

		//Evenements
		private void m_btnOk_Click(object sender, EventArgs e)
		{
			if (!m_bAutoriseZero && ElementsSelectionnes.Count == 0)
			{
				CFormAlerte.Afficher(I.T("You must select at least 1 element|1312"), EFormAlerteType.Exclamation);
				DialogResult = DialogResult.Cancel;
			}
			DialogResult = DialogResult.OK;
		}
		private void m_btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void m_glst_CheckedChange(object sender, int nNumItem)
		{
			if (m_bFillingListe)
				return;
			int nIdEle = m_mappageObjetIndexInListe[nNumItem].Id;
			if (m_elementsSelectionnes.Contains(nIdEle))
				m_elementsSelectionnes.Remove(nIdEle);
			else
				m_elementsSelectionnes.Add(nIdEle);
		}
		
	}
}