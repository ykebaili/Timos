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
	public partial class CWebViewerPopup : CFloatingFormBase
	{
		#region ++ Constructeurs ++
		public CWebViewerPopup()
		{
			InitializeComponent();

		}
		#endregion

		#region :: Propriétés ::
		private static CWebViewerPopup m_staticPopup = null;

		private Point m_pointSourisInitial = new Point(0, 0);
		#endregion

		#region ** Evenements **

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
				m_staticPopup = new CWebViewerPopup();
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
			m_staticPopup.m_webViewer.DocumentText = help.TexteHTML;
			m_staticPopup.m_webViewer.Show();
			//help.FillRichText(m_staticPopup.m_richText);
			m_staticPopup.Show();
			/*m_staticPopup.Show();
			m_staticPopup.BringToFront();
			m_staticPopup.m_pointSourisInitial = Cursor.Position;
			m_staticPopup.Capture = true;
			m_staticPopup.Focus();*/
		}

		//private void m_richText_LinkClicked(object sender, LinkClickedEventArgs e)
		//{
		//    MessageBox.Show(e.LinkText);
		//}
		void m_webViewer_Leave(object sender, System.EventArgs e)
		{
			throw new System.Exception("The method or operation is not implemented.");
		}
		void m_webViewer_Click(object sender, System.EventArgs e)
		{
			throw new System.Exception("The method or operation is not implemented.");
		}
		void CWebViewerPopup_Leave(object sender, System.EventArgs e)
		{
			throw new System.Exception("The method or operation is not implemented.");
		}

		void CWebViewerPopup_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			throw new System.Exception("The method or operation is not implemented.");
		}

		void CWebViewerPopup_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			throw new System.Exception("The method or operation is not implemented.");
		}

		void m_webViewer_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			throw new System.Exception("The method or operation is not implemented.");
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