using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using sc2i.common;

namespace timos
{
	public class CDataGridViewCellAControleVivant : DataGridViewTextBoxCell
	{

		private IControlVivant m_control;
		private int m_oldWidth;
		private int m_oldHeight;
		private Bitmap m_cacheImg;
		private Type m_typeDonnee;

		public int AncienneHauteur
		{
			get
			{
				return m_oldHeight;
			}
		}
		public int AncienneLargeur
		{
			get
			{
				return m_oldWidth;
			}
		}

		public Bitmap ImageCellule
		{
			get
			{
				if (m_control == null)
					return null;
				if (m_cacheImg == null
					|| Size.Height != m_oldHeight
					|| Size.Width != m_oldWidth
					|| m_control.MustBeRedraw)
				{
					Selected = true;
					try
					{
						DataGridView.BeginEdit(false);
					}
					catch
					{ }
					m_cacheImg = m_control.ScreenShot;
					DataGridView.EndEdit();
					m_oldHeight = Size.Height;
					m_oldWidth = Size.Width;
					m_control.MustBeRedraw = false;
				}


				return m_cacheImg;
			}
		}

		public IControlVivant ControlVivant
		{
			get
			{
				return m_control;
			}
			set
			{
				m_control = value;
			}
		}
		public Type TypeDonnee
		{
			get
			{
				return m_typeDonnee;
			}
			set
			{
				m_typeDonnee = value;
			}
		}


		public CDataGridViewCellAControleVivant()
			: base()
		{
		}
		public CDataGridViewCellAControleVivant(Type typeDonnee)
			: base()
		{
			m_typeDonnee = typeDonnee;
		}


		public static void ExceptIfNotTypeMappe(CDataGridViewCellAControleVivant cell, List<Type> typesMappes)
		{
			if (cell.TypeDonnee == null)
				throw new Exception(I.T("The cell of column : |30052") + cell.ColumnIndex + I.T(" Line |30053 ") + cell.RowIndex
					+ I.T(" has no parametred type|30054"));
			else if (!typesMappes.Contains(cell.TypeDonnee))
                throw new Exception(I.T("The type|30055 ") + cell.TypeDonnee.Name + I.T(" of the cell : Column |30056 ") + cell.ColumnIndex + I.T(" Line |30053 ") + cell.RowIndex
					+ I.T(" is not supported|30057"));
		}
		public static void ExceptIfNotControlVivant(CDataGridViewCellAControleVivant cell)
		{
			if (cell.ControlVivant == null)
				throw new Exception(I.T("The display control has not be initialized for the cell : Column |30058 "
					+ cell.ColumnIndex + " Line |30053" + cell.RowIndex));
		}

		//Penser à garder la reference vers la variable objet initialFormattedValue > le pointeur est important
		public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
		{
			base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

			if (ControlVivant != null)
			{
				ExceptIfNotControlVivant(this);

				CDataGridViewControleVivant controlEdit = (CDataGridViewControleVivant)DataGridView.EditingControl;
				ControlVivant.Controle.Size = DataGridView.CurrentCell.Size;
				controlEdit.Init(ControlVivant);
			}

		}

		public override Type EditType
		{
			get
			{
				return typeof(CDataGridViewControleVivant);
			}
		}

		public override object Clone()
		{
			CDataGridViewCellAControleVivant cell = base.Clone() as CDataGridViewCellAControleVivant;
			if (cell != null)
			{
				cell.m_typeDonnee = this.m_typeDonnee;
				cell.m_control = this.m_control;
				cell.m_oldWidth = this.m_oldWidth;
				cell.m_oldHeight = this.m_oldHeight;
				cell.m_cacheImg = this.m_cacheImg;
			}
			return cell;
		}
	}


}
