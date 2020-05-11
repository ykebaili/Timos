using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using sc2i.common;
using sc2i.data.dynamic;
using sc2i.win32.common;
using System.Reflection;
using sc2i.data;
using sc2i.expression;
using sc2i.win32.expression;
using sc2i.win32.data.dynamic;

namespace spv.win32
{
	/// <summary>
	/// Editeur de choix de colonnes pour les listes d'alarmes
	/// </summary>
	//[EditeurTableExport(typeof(C2iTableExport))]
	//public partial class CPanelEditTableExportComplexe : UserControl, IControlALockEdition, IPanelEditTableExport
    public partial class CPanelListChampsExport : UserControl, IControlALockEdition, IPanelEditListChampsExport
	{
        private List<C2iChampExport> m_ListChampsExport;
        private Type m_typeObjet;
        private CDefinitionProprieteDynamique m_champOrigine = null;

		//------------------------------------------
		public CPanelListChampsExport()
		{
			InitializeComponent();
		}

		//------------------------------------------
        public CResultAErreur InitChamps(
            List<C2iChampExport> listeChampsExport,
            Type typeObjet,
            CDefinitionProprieteDynamique champOrigine)

		{
			CResultAErreur result = CResultAErreur.True;
            m_ListChampsExport = listeChampsExport;
            m_typeObjet = typeObjet;
            m_champOrigine = champOrigine;

			InitChamps();
			return result;
		}

		
		//------------------------------------------
		private void InitChamps()
		{
			m_wndListeChamps.Items.Clear();
			m_wndListeChamps.BeginUpdate();
			
            foreach (C2iChampExport champ in m_ListChampsExport)
			{
				ListViewItem item = new ListViewItem();
				FillItemForChamp(item, champ);
				m_wndListeChamps.Items.Add(item);
			}
			m_wndListeChamps.EndUpdate();

        }

		//------------------------------------------
		public CResultAErreur MajChamps()
		{
            CResultAErreur result = CResultAErreur.True;
            m_ListChampsExport.Clear();

			foreach ( ListViewItem item in m_wndListeChamps.Items )
			{
				if ( item.Tag is C2iChampExport )
				{
					C2iChampExport champ = (C2iChampExport )item.Tag;
                    m_ListChampsExport.Add(champ);
				}
			}
            return result;
		}
		

        public C2iChampExport[] ListeChamps
        {
            get
            {
                return m_ListChampsExport.ToArray();
            }
        }

		//-------------------------------------------------------------------------
		private void FillItemForChamp(ListViewItem item, C2iChampExport champ)
		{
			item.Text = champ.NomChamp;
			item.ImageIndex = (champ.Origine is C2iOrigineChampExportExpression) ? 1 : 0;
			item.Tag = champ;
		}

		//------------------------------------------
		private void CPanelEditTableExportComplexe_Load(object sender, EventArgs e)
		{
			CWin32Traducteur.Translate(this);
		}

		//------------------------------------------
		private void m_wndListeChamps_AfterLabelEdit(object sender, LabelEditEventArgs e)
		{
			ListViewItem item = m_wndListeChamps.Items[e.Item];
			if (e.Label == null || item.Tag == null || !(item.Tag is C2iChampExport))
			{
				e.CancelEdit = true;
				return;
			}
			((C2iChampExport)item.Tag).NomChamp = e.Label;
		}

		//------------------------------------------
		private void m_wndListeChamps_BeforeLabelEdit(object sender, LabelEditEventArgs e)
		{
			ListViewItem item = m_wndListeChamps.Items[e.Item];
			if (item.Tag == null || !(item.Tag is C2iChampExport))
				e.CancelEdit = true;
		}

		//------------------------------------------
		private ListViewItem m_lastItemTooltip = null;
		private void m_wndListeChamps_MouseMove(object sender, MouseEventArgs e)
		{
			ListViewItem item = m_wndListeChamps.GetItemAt(e.X, e.Y);
			if (item != null && item != m_lastItemTooltip)
			{
				if (item.Tag is C2iChampExport)
				{
					C2iChampExport champ = (C2iChampExport)item.Tag;
					if (champ.Origine is C2iOrigineChampExportChamp)
					{
						m_tooltip.SetToolTip(m_wndListeChamps, ((C2iOrigineChampExportChamp)champ.Origine).ChampOrigine.Nom);
						return;
					}
					if (champ.Origine is C2iOrigineChampExportExpression)
					{
						C2iExpression formule = ((C2iOrigineChampExportExpression)champ.Origine).Expression;
						if (formule != null)
						{
							m_tooltip.SetToolTip(m_wndListeChamps, formule.GetString());
							return;
						}
					}
				}
				else if (item.Tag is CInfoChampTable)
				{
					m_tooltip.SetToolTip(m_wndListeChamps, ((CInfoChampTable)item.Tag).NomConvivial);
					return;
				}
				else if (item.Tag is C2iChampDeRequete)
				{
					C2iChampDeRequete champ = (C2iChampDeRequete)item.Tag;
					string strInfo = "Origin : " + champ.GetStringSql() + "\r\n" +
						"Operation : " + champ.OperationAgregation.ToString() + "\r\n" +
						"Group by : " + (champ.GroupBy ? "Yes" : "No");
					m_tooltip.SetToolTip(m_wndListeChamps, strInfo);
					return;
				}
				m_lastItemTooltip = item;
			}
			m_tooltip.SetToolTip(m_wndListeChamps, "");
		}

		//------------------------------------------
		private void m_wndListeChamps_SelectedIndexChanged(object sender, EventArgs e)
		{
 			bool bCanEdit = false;
			if (m_wndListeChamps.SelectedItems.Count == 1)
			{
				ListViewItem item = m_wndListeChamps.SelectedItems[0];
				if (item != null)
				{

					if (item.Tag is C2iChampExport &&
						((C2iChampExport)item.Tag).Origine is C2iOrigineChampExportExpression)
						bCanEdit = true;
				}
			}
			m_btnDetail.Visible = bCanEdit;
			//m_btnSupprimer.Visible = bCanEdit;
		}


		//-----------------------------------------------------------------
		private void m_btnAjouter_LinkClicked(object sender, EventArgs e)
		{
			m_menuAjouterChamp.Show(m_btnAjouter, new Point(0, m_btnAjouter.Height));
		}

		//-----------------------------------------------------------------
		private void m_btnDetail_LinkClicked(object sender, EventArgs e)
		{
			if (m_wndListeChamps.SelectedItems.Count == 1)
			{
				ListViewItem item = m_wndListeChamps.SelectedItems[0];
				if (item.Tag is C2iChampExport)
				{
					if (EditChamp((C2iChampExport)item.Tag))
						FillItemForChamp(item, ((C2iChampExport)item.Tag));
				}
			}
		}

		//-----------------------------------------------------------------
		private void m_btnSupprimer_LinkClicked(object sender, EventArgs e)
		{
			if (m_wndListeChamps.SelectedItems.Count == 1)
			{
				ListViewItem item = m_wndListeChamps.SelectedItems[0];
				if (CFormAlerte.Afficher(I.T("Remove the field ?|30007"),
					EFormAlerteType.Question) == DialogResult.Yes)
					m_wndListeChamps.Items.Remove(item);
			}
		}

		//-----------------------------------------------------------------
		private void m_menuAjouterChamp_Popup(object sender, EventArgs e)
		{
			m_menuAjouterChampDonnee.Visible = true;
		}

		//-------------------------------------------------------------------------
        
		private bool EditChamp(C2iChampExport champ)
		{
			if (champ.Origine is C2iOrigineChampExportExpression)
			{
				//return CFormEditChampCalcule.EditeChamp(champ, m_typeObjet, m_elementAVariablesPourFiltre != null ? (IFournisseurProprietesDynamiques)m_elementAVariablesPourFiltre : new CFournisseurPropDynStd(true));
                return CFormEditChampCalcule.EditeChamp(champ, m_typeObjet, new CFournisseurPropDynStd(true));
			
			}
			return false;
		}
        
		//--------------------------------------------------------------------------
		private void m_menuAjouterChampDonnee_Click(object sender, EventArgs e)
		{
            CDefinitionProprieteDynamique[] defs = CFormSelectChampPourStructure.SelectProprietes(m_typeObjet, CFormSelectChampPourStructure.TypeSelectionAttendue.ChampParent, m_champOrigine);
			foreach (CDefinitionProprieteDynamique def in defs)
			{
				C2iChampExport champ = new C2iChampExport();
				champ.Origine = new C2iOrigineChampExportChamp(def);
				champ.NomChamp = def.Nom;
				ListViewItem item = new ListViewItem();
				FillItemForChamp(item, champ);
				m_wndListeChamps.Items.Add(item);
			}
		}


        
		//--------------------------------------------------------------------------
		private void m_menuAjouterChampCalcule_Click(object sender, EventArgs e)
		{
			C2iChampExport champ = new C2iChampExport();
			champ.Origine = new C2iOrigineChampExportExpression();
			champ.NomChamp = "Champ " + m_wndListeChamps.Items.Count;
			if (EditChamp(champ))
			{
				ListViewItem item = new ListViewItem();
				FillItemForChamp(item, champ);
				m_wndListeChamps.Items.Add(item);
			}
		}
 
        /*
		//--------------------------------------------------------------------------
		private void m_menuAjouterChampsPersonnalisés_Click(object sender, EventArgs e)
		{
			C2iChampExport champ = new C2iChampExport();
			champ.Origine = new C2iOrigineChampExportChampCustom();
			champ.NomChamp = "CUSTOM_FIELDS";
			if (EditChamp(champ))
			{
				ListViewItem item = new ListViewItem();
				FillItemForChamp(item, champ);
				m_wndListeChamps.Items.Add(item);
			}
		}
        */

		//----------------------------------------------
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
					OnChangeLockEdition(this, null);
			}
		}

		//----------------------------------------------
		public event EventHandler  OnChangeLockEdition;

		//----------------------------------------------
		private void m_btnHaut_Click(object sender, EventArgs e)
		{
			if (m_wndListeChamps.SelectedItems.Count == 1)
			{
				ListViewItem item = m_wndListeChamps.SelectedItems[0];
				int nIndex = item.Index;
				if (nIndex > 0)
				{
					m_wndListeChamps.Items.RemoveAt(nIndex);
					m_wndListeChamps.Items.Insert(nIndex - 1, item);
				}
			}
		}

		//----------------------------------------------
		private void m_btnBas_Click(object sender, EventArgs e)
		{
			if (m_wndListeChamps.SelectedItems.Count == 1)
			{
				ListViewItem item = m_wndListeChamps.SelectedItems[0];
				int nIndex = item.Index;
				if (nIndex < m_wndListeChamps.Items.Count - 1)
				{
					m_wndListeChamps.Items.RemoveAt(nIndex);
					if (nIndex + 1 >= m_wndListeChamps.Items.Count - 1)
						m_wndListeChamps.Items.Add(item);
					else
						m_wndListeChamps.Items.Insert(nIndex + 1, item);
				}
			}
		}
	}
}
