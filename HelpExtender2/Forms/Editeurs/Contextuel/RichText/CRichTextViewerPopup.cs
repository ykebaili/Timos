using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using sc2i.win32.common;

namespace HelpExtender
{
	public partial class CRichTextViewerPopup : CFloatingFormBase
	{
		#region ++ Constructeurs ++
		public CRichTextViewerPopup()
		{
			InitializeComponent();
		}
		#endregion

		#region :: Propriétés ::
		private static CRichTextViewerPopup m_staticPopup = null;

		private Point m_pointSourisInitial = new Point(0, 0);
		#endregion

		#region ** Evenements **

		private void CRichTextViewerPopup_Leave(object sender, EventArgs e)
		{
			//Hide();
		}

		public static void Popup(Point screenPoint, CHelpData help )
		{
			if (help == null || !help.HasData)
			{
				if (m_staticPopup != null)
					m_staticPopup.Visible = false;
				return;
			}
			if (m_staticPopup == null)
			{
				//Création du viewer static
				m_staticPopup = new CRichTextViewerPopup();
			}

			Screen scr = Screen.FromPoint(screenPoint);
			Point ptStart = screenPoint;
			Size sz = help.SizePopup;
			if (ptStart.X + sz.Width > scr.WorkingArea.Right)
				ptStart.Offset(-sz.Width, 0);
			if (ptStart.Y + sz.Height > scr.WorkingArea.Bottom)
				ptStart.Offset(0, -sz.Height);
			m_staticPopup.Size = sz;
			m_staticPopup.Location = ptStart;
			//help.FillRichText(m_staticPopup.m_richText);
			m_staticPopup.Show();
			/*m_staticPopup.Show();
			m_staticPopup.BringToFront();
			m_staticPopup.m_pointSourisInitial = Cursor.Position;
			m_staticPopup.Capture = true;
			m_staticPopup.Focus();*/
		}

		private void m_richText_MouseMove(object sender, MouseEventArgs e)
		{
			/*Point newPt = Cursor.Position;
			if ((ModifierKeys & Keys.Shift) == Keys.Shift)
				m_pointSourisInitial = newPt;
			else
			{
				if (Math.Abs(newPt.X - m_pointSourisInitial.X) > 5 ||
					 Math.Abs(newPt.Y - m_pointSourisInitial.Y) > 5)
				{
					Hide();
					Capture = false;
				}
			}*/
		}

		private void m_richText_Load(object sender, EventArgs e)
		{

		}

		private void m_richText_Click(object sender, EventArgs e)
		{
			/*Capture = false;
			Hide();*/
		}

		private void CRichTextViewerPopup_MouseDown(object sender, MouseEventArgs e)
		{
			/*Capture = false;
			Hide();*/
		}

		private void m_richText_LinkClicked(object sender, LinkClickedEventArgs e)
		{
			CFormAlerte.Afficher(e.LinkText, EFormAlerteType.Erreur);
		}
		#endregion


		#region ~~ Méthodes ~~
		public static void HideTooltip()
		{
			if (m_staticPopup != null)
				m_staticPopup.Hide();
		}
		#endregion

	}
}