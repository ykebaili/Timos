using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using timos.data.version;
using sc2i.data;
using sc2i.data.dynamic;

namespace timos.version
{
	public partial class CControlIChampPourVersion : UserControl, IControlVivant
	{
		public CControlIChampPourVersion()
		{
			InitializeComponent();
			DoubleBuffered = true;
		}


		private IChampPourVersion m_champ;

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
			Controls.Clear();
			try
			{
				m_champ = (IChampPourVersion)valeur;
			}
			catch
			{
				return false;
			}

	
			Control ctrl = m_lblNomChamp;
			if (m_champ.GetType() == typeof(CChampPourVersionInDb))
			{
				CControlChampBase ctrlBase = new CControlChampBase();
				ctrlBase.Init((CChampPourVersionInDb)m_champ);
				ctrl = ctrlBase;
			}
			else if (m_champ.GetType() == typeof(CChampCustomPourVersion))
			{
				CControlChampCustom ctrlCc = new CControlChampCustom();
				ctrlCc.Init((CChampCustomPourVersion)m_champ);
				ctrl = ctrlCc;
			}
			else
			{
				m_lblNomChamp.Text = m_champ.NomConvivial;
			}
			Controls.Add(ctrl);
			ctrl.Dock = DockStyle.Fill;
			return true;
		}

		public object Valeur
		{
			get
			{
				return m_champ;
			}
			set
			{
				try
				{
					m_champ = (IChampPourVersion)value;
				}
				catch
				{
				}
			}
		}

		#endregion
	}
}
