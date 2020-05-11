using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using sc2i.common;
using sc2i.win32.common;

namespace timos.tables
{
	public class CDataGridViewCustomCell : DataGridViewTextBoxCell
	{
		public CDataGridViewCustomCell()
			: base()
		{ }
		public CDataGridViewCustomCell(Type t, bool nullable)
			: base()
		{
			m_type = t;
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if (m_imageLoupe != null)
			{
				m_imageLoupe.Dispose();
				m_imageLoupe = null;
			}
		}

		private Bitmap m_imageLoupe = null;
		private Type m_type;
		private CCtrlEditSelonType m_ctrl;

		//Penser à garder la reference vers la variable objet initialFormattedValue > le pointeur est important
		public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
		{
			base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

			m_ctrl = DataGridView.EditingControl as CCtrlEditSelonType;

			if (!m_ctrl.Initialiser(initialFormattedValue, m_type))
				CFormAlerte.Afficher(I.T("Error while opening the cell editor|1177"), EFormAlerteType.Erreur);
		}

		

		public override Type ValueType
		{
			get
			{
				return m_type;
			}
			set
			{
				base.ValueType = value;
			}
		}
		public override Type EditType
		{
			get
			{
				return typeof(CCtrlEditSelonType);
			}
		}


		public override object Clone()
		{
			CDataGridViewCustomCell cell = base.Clone() as CDataGridViewCustomCell;
			if (cell != null)
			{
				cell.m_type = this.m_type;
			}
			return cell;
		}

		public override object ParseFormattedValue(object formattedValue, DataGridViewCellStyle cellStyle, System.ComponentModel.TypeConverter formattedValueTypeConverter, System.ComponentModel.TypeConverter valueTypeConverter)
		{
			if (formattedValue == null || formattedValue == DBNull.Value)
				return DBNull.Value;
			else
			{
				return base.ParseFormattedValue(formattedValue, cellStyle, formattedValueTypeConverter, valueTypeConverter);
			}
		}

		protected override bool SetValue(int rowIndex, object value)
		{
			if (value == null || value == DBNull.Value)
				this.Style.BackColor = Color.LightGray;
			else
				this.Style.BackColor = Color.White;
			return base.SetValue(rowIndex, value);
		}

		protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
		{
			base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
			if (DataGridView != null && this.DataGridView.ReadOnly)
			{
				
				//Vérifie que le texte rentre dans la fenêtre
				SizeF sz = graphics.MeasureString(value.ToString(), DataGridView.Font);
				if (sz.Width > cellBounds.Width || sz.Height > cellBounds.Height)
				{
					Point[] pts = new Point[]{
					new Point ( cellBounds.Right-10, cellBounds.Bottom-1 ),
					new Point ( cellBounds.Right-1, cellBounds.Bottom-10),
					new Point ( cellBounds.Right-1, cellBounds.Bottom-1 )};
					graphics.FillPolygon ( Brushes.LightGray, pts );
				}
			}
			
		}

		private bool CanBeZoomed ( Graphics g, int rowIndex )
		{
			if ( DataGridView == null )
				return false;
			bool bGNull = g == null;
			if ( bGNull )
				g = DataGridView.CreateGraphics();
			string strVal = "";
			Size sz = GetSize(rowIndex);
			try
			{
				strVal = this.GetValue(rowIndex).ToString();
			}
			catch { }
	
			SizeF szTxt = g.MeasureString(strVal, DataGridView.Font);
			if (szTxt.Width > sz.Width ||
				 szTxt.Height > sz.Height)
			{
				return true;
			}
			if (bGNull)
				g.Dispose();
			return false;
		}


		

		protected override void OnMouseMove(DataGridViewCellMouseEventArgs e)
		{
			DataGridView.Cursor = Cursors.Arrow;
			Size sz = GetSize(e.RowIndex);
			if (e.X > sz.Width - 10 &&
				e.Y > sz.Height - 10)
			{
				if (CanBeZoomed(null, e.RowIndex))
					DataGridView.Cursor = Cursors.Hand;
			}
			
		}

		protected override void OnMouseUp(DataGridViewCellMouseEventArgs e)
		{
			base.OnMouseUp(e);
			if ((e.Button & MouseButtons.Left)== MouseButtons.Left && DataGridView != null && DataGridView.ReadOnly && CanBeZoomed(null, e.RowIndex))
			{
				Size sz = GetSize(e.RowIndex);
				if (e.X > sz.Width - 10 &&
					e.Y > sz.Height - 10)
				{
					string strVal = "";
					try
					{
						strVal = this.GetValue(e.RowIndex).ToString();
						CFormZoomText.ShowText(strVal, false);
					}
					catch { }
				}

			}
		}

		
	}
}
