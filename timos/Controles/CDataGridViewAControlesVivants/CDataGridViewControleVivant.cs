using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace timos
{

	public class CDataGridViewControleVivant : Control, IDataGridViewEditingControl
	{

		IControlVivant m_ctrl;
		public CDataGridViewControleVivant()
		{

		}
		public void Init(IControlVivant ctrl)
		{
			Visible = false;
			Controls.Clear();
			m_ctrl = ctrl;
			Controls.Add(m_ctrl.Controle);
			m_ctrl.Controle.Dock = DockStyle.Fill;
			Visible = true;
		}


		#region IDataGridViewEditingControl Membres

		public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
		{
			return;
		}

		private DataGridView m_dgv;
		public DataGridView EditingControlDataGridView
		{
			get
			{
				return m_dgv;
			}
			set
			{
				m_dgv = value;
			}
		}

		public object EditingControlFormattedValue
		{
			get
			{
				return m_ctrl.Valeur;
			}
			set
			{
				m_ctrl.Valeur = value;
			}
		}

		private int m_nIdxRow;
		public int EditingControlRowIndex
		{
			get
			{
				return m_nIdxRow;
			}
			set
			{
				m_nIdxRow = value;
			}
		}

		public bool EditingControlValueChanged
		{
			get
			{
				return true;
			}
			set
			{
				
			}
		}

		public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
		{
			return true;
		}

		public Cursor EditingPanelCursor
		{
			get { return base.Cursor; }
		}

		public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
		{
			return m_ctrl.Valeur;
		}

		public void PrepareEditingControlForEdit(bool selectAll)
		{
			
		}

		public bool RepositionEditingControlOnValueChange
		{
			get
			{
				return false;
			}
		}

		#endregion
	}

	
}
