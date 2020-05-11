using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common;

namespace timos.tables
{
	public partial class CCtrlEditColonneFilterTest : UserControl
	{
		public CCtrlEditColonneFilterTest()
		{
			InitializeComponent();
		}

		private Type m_type;
		private CDataGridViewColonneFilterTest m_test;

		private Hashtable m_idxOpe;

		public void Initialiser(CDataGridViewColonneFilterTest test)
		{
			Enabled = true;
			m_test = test;
			if (m_test == null || m_test.ColonneDataGrid == null)
			{
				Enabled = false;
				return;
			}
			m_type = m_test.ColonneDataGrid.ValueType;
			m_idxOpe = new Hashtable();
			List<COperateurTestFiltre> ops = m_test.OperateursPossibles;
			foreach (COperateurTestFiltre o in ops)
			{
				m_cmbOperator.Items.Add(o.Libelle);
				m_idxOpe.Add(m_cmbOperator.Items.Count - 1, o);
			}

			if (test.Valider(true))
				m_cmbOperator.SelectedItem = m_test.Operateur.ToString();
			else
				m_cmbOperator.SelectedItem = m_cmbOperator.Items[0];

			m_ctrlEdit.Initialiser(m_test.Valeur, m_test.ColonneDataGrid.ValueType);
			sc2i.win32.common.CWin32Traducteur.Translate(this);
		}

		public COperateurTestFiltre OperateurSelectionne
		{
			get
			{
				return (COperateurTestFiltre)m_idxOpe[m_cmbOperator.SelectedIndex];
			}
		}
		public CDataGridViewColonneFilterTest Test
		{
			get
			{
				return m_test;
			}
		}

		private void m_cmbOperator_SelectionChangeCommitted(object sender, EventArgs e)
		{
			m_test.Operateur = OperateurSelectionne;
			switch (m_test.Operateur.Code)
			{
				case EOperateurTestFiltre.NonNull:
				case EOperateurTestFiltre.Null:
					m_panBorder2.Visible = false;
					break;
				default:
					m_panBorder2.Visible = true;
					break;
			}
		}
		private void m_ctrlEdit_ChangementValeur(object sender, EventArgs e)
		{
			m_test.Valeur = m_ctrlEdit.Valeur;
		}

	}


}
