using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using timos.data.version;

using sc2i.common;
using sc2i.data;
using sc2i.data.dynamic;
using sc2i.win32.data.navigation;

namespace timos.version
{
	public partial class CControlVivantTypeConvivial : UserControl, IControlVivant
	{
		public CControlVivantTypeConvivial()
		{
			InitializeComponent();
			DoubleBuffered = true;
		}


		private Type m_type;

		#region IControlVivant Membres

		public Control Controle
		{
			get 
			{ 
				return this; 
			}
		}

		private bool m_bMustBeRedraw = true;
		public bool MustBeRedraw
		{
			get
			{
				return m_bMustBeRedraw;
			}
			set
			{
				m_bMustBeRedraw = value;
			}
		}

		public Bitmap ScreenShot
		{
			get { return CUtilControlVivant.GetScreenShot(this); }
		}

		public bool Initialiser(object valeur)
		{
			try
			{
				m_type = (Type)valeur;
				if (m_type.GetCustomAttributes(typeof(DynamicClassAttribute), false).Length == 1)
				{
					m_lnk.Text = DynamicClassAttribute.GetNomConvivial(m_type);
					m_lnk.Enabled = true;
				}
				else if (m_type == typeof(string))
				{
					m_lnk.Text = I.T("Text|30279");
					m_lnk.Enabled = false;
				}
				else if (m_type == typeof(int))
				{
					m_lnk.Text = I.T("Integer|30280");
					m_lnk.Enabled = false;
				}
				else if (m_type == typeof(DateTime))
				{
					m_lnk.Text = I.T("Date|246");
					m_lnk.Enabled = false;
				}
				else if (m_type == typeof(bool))
				{
					m_lnk.Text = I.T("Yes/No|30281");
					m_lnk.Enabled = false;
				}
				else if (m_type == typeof(double))
				{
					m_lnk.Text = I.T("Decimal|30282");
					m_lnk.Enabled = false;
				}
				else
				{
					m_lnk.Text = I.T("Unknown type|30283");
					m_lnk.Enabled = false;
				}
			}
			catch
			{
				m_lnk.Enabled = false;
			}
			Controls.Clear();
			Controls.Add(m_lnk);
			m_lnk.Dock = DockStyle.Fill;
			m_lnk.TextAlign = ContentAlignment.MiddleLeft;

			return true;
		}

		public object Valeur
		{
			get
			{
				return m_type;
			}
			set
			{
				try
				{
					m_type = (Type)value;
				}
				catch
				{
				}
			}
		}

		#endregion

		private void m_lnk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Type typeForm = CFormFinder.GetTypeFormToList(m_type);
			if (typeForm != null)
			{
				sc2i.win32.navigation.IFormNavigable form = (sc2i.win32.navigation.IFormNavigable)Activator.CreateInstance(typeForm,
					new object[] { });
				CSc2iWin32DataNavigation.Navigateur.AffichePage(form);
			}
		}
	}
}
