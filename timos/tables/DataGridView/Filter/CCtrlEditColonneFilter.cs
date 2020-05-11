using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace timos.tables
{
	public partial class CCtrlEditColonneFilter : UserControl
	{
		public CCtrlEditColonneFilter()
		{
			InitializeComponent();
			m_ctrlET.Enabled = false;
		}

		private CCDataGridViewColonneFilter m_colfilter;
		public CCDataGridViewColonneFilter ColonneFilter
		{
			get
			{
				if(m_ctrlET.Elements != null)
					m_situationSelec.Fils = m_ctrlET.Elements;
				if(m_ctrlOU.Elements != null)
					m_colfilter.Fils = m_ctrlOU.Elements;

				m_colfilter.Valider(true);
				return m_colfilter;
			}
		}

		public void Initialiser(CCDataGridViewColonneFilter col)
		{
			m_colfilter = col;
			m_ctrlOU.SelectionAuClicSurControl = true;

			m_ctrlOU.Initialiser(col.Fils,m_colfilter.ColonneDataGrid,typeof(CDataGridViewColonneFilterSituation));

			m_panG.Visible = !(m_colfilter.ColonneDataGrid.ValueType == typeof(bool));

			if (m_ctrlOU.Elements.Count == 0)
			{
				CDataGridViewColonneFilterSituation sit = new CDataGridViewColonneFilterSituation(m_colfilter.ColonneDataGrid);
				sit.Fils.Add(new CDataGridViewColonneFilterTest(m_colfilter.ColonneDataGrid));
				m_ctrlOU.AjouterElement(sit);
			}

			m_ctrlOU.SelectionnerElement(m_ctrlOU.Elements[m_ctrlOU.Elements.Count - 1]);
		}

	

		private CDataGridViewColonneFilterSituation m_situationSelec;
		private void m_ctrlOU_ChangementSelection(object sender, EventArgs e)
		{
			if (m_ctrlOU.ElementsSelectionnes.Count == 1)
			{
				if (m_situationSelec != null)
				{
					m_situationSelec.Fils = m_ctrlET.Elements;
					m_situationSelec.Valider(true);
				}

				m_situationSelec = (CDataGridViewColonneFilterSituation)m_ctrlOU.ElementsSelectionnes[0];
				m_ctrlET.Initialiser(m_situationSelec.Fils, m_colfilter.ColonneDataGrid, typeof(CDataGridViewColonneFilterTest), true);

				if (m_colfilter.ColonneDataGrid.ValueType == typeof(bool))
				{
					m_ctrlET.AjoutPossible = false;
					m_ctrlET.SelectionPossible = false;
					if (m_ctrlET.Elements.Count == 0)
						m_ctrlET.AjouterElement(new CDataGridViewColonneFilterTest(m_colfilter.ColonneDataGrid));
				}
				else
				{
					m_ctrlET.SelectionPossible = true;
					m_ctrlET.AjoutPossible = true;
				}
				m_ctrlET.Enabled = true;
			}
			else
				m_ctrlET.Enabled = false;
		}
		void m_ctrlOU_AjoutElement(object sender, System.EventArgs e)
		{
			CDataGridViewColonneFilterSituation sit = (CDataGridViewColonneFilterSituation)sender;
			if(sit.Fils.Count == 0)
				sit.Fils.Add(new CDataGridViewColonneFilterTest(m_colfilter.ColonneDataGrid));
			m_ctrlOU.SelectionnerElement(sit);
		}
		void m_ctrlOU_SuppressionElement(CDataGridViewColonneFilterComponent element)
		{
			if (m_ctrlOU.Elements.Count > 1)
				m_ctrlOU.SelectionnerElement(m_ctrlOU.Elements[0]);
			else
				m_ctrlET.Enabled = false;
		}
	}
}
