using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using timos.tables;

namespace timos.tables
{
	public partial class CTextBoxZoomable : UserControl
	{
		public CTextBoxZoomable()
		{
			InitializeComponent();
			AjusteSize();
		}

		private void m_btnZoom_Paint(object sender, PaintEventArgs e)
		{
			Point[] pts = new Point[]{
				new Point ( m_btnZoom.ClientRectangle.Right-10, m_btnZoom.ClientRectangle.Bottom),
				new Point ( m_btnZoom.ClientRectangle.Right, m_btnZoom.ClientRectangle.Bottom-10),
				new Point ( m_btnZoom.ClientRectangle.Right, m_btnZoom.ClientRectangle.Bottom)};
			e.Graphics.FillPolygon(Brushes.LightGray, pts);
		}

		private void CTextBoxZoomable2_FontChanged(object sender, EventArgs e)
		{
			AjusteSize();
		}

		private void AjusteSize()
		{
			m_textBox.Font = Font;
			if (!m_textBox.ReadOnly)
			{
				Size sz = this.Size;
				Size szInt = this.ClientRectangle.Size;
				int nEcartY = sz.Height - szInt.Height + m_cadreBas.Height + m_cadreHaut.Height + m_margeHaute.Height + m_margeBasse.Height;
				Size = new Size(sz.Width, m_textBox.Height + nEcartY);
			}
		}

		//-------------------------------------
		private void CTextBoxZoomable2_SizeChanged(object sender, EventArgs e)
		{
			AjusteSize();
		}

		//-------------------------------------
		private void m_btnZoom_Click(object sender, EventArgs e)
		{
			Text = CFormZoomText.ShowText(Text, true);
		}
		
		//-------------------------------------
		public override string  Text
		{
			get
			{
				return m_textBox.Text;
			}
			set
			{
				m_textBox.Text = value;
			}
		}

		//-------------------------------------
		public bool Multiline
		{
			get
			{
				return m_textBox.Multiline;
			}
			set
			{
				m_textBox.Multiline = value;
			}
		}

		//-------------------------------------
		public int SelectionStart
		{
			get
			{
				return m_textBox.SelectionStart;
			}
			set
			{
				m_textBox.SelectionStart = value;
			}
		}

		//-------------------------------------
		public int SelectionLength
		{
			get
			{
				return m_textBox.SelectionLength;
			}
			set
			{
				m_textBox.SelectionLength = value;
			}
		}

		//-------------------------------------
		private void m_textBox_KeyDown(object sender, KeyEventArgs e)
		{
			OnKeyDown(e);
		}


		private void m_textBox_TextChanged(object sender, EventArgs e)
		{
			OnTextChanged(e);
		}



		
	}
}
