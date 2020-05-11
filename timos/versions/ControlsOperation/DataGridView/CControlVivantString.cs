using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using timos.data.version;
using sc2i.data;

namespace timos.version
{
	public partial class CControlVivantString : UserControl, IControlVivant
	{
		public CControlVivantString()
		{
			InitializeComponent();
			DoubleBuffered = true;
		}



		#region IControlVivant Membres

		public Control Controle
		{
			get { return this; }
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
				m_bMustBeRedraw = false;
			}
		}

		public Bitmap ScreenShot
		{
			get { return CUtilControlVivant.GetScreenShot(this); }
		}

		private string m_string;
		public bool Initialiser(object valeur)
		{
			try
			{
				m_string = (string)valeur;
			}
			catch
			{
				m_string = valeur.ToString();
			}

			m_lbl.Text = m_string;
			return true;
			
		}

		public object Valeur
		{
			get
			{
				return m_lbl.Text;
			}
			set
			{
				try
				{
					m_lbl.Text = (string)value;
				}
				catch
				{
					m_lbl.Text = value.ToString();
				}
			}
		}

		#endregion
	}
}
