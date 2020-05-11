using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using timos.data;

using sc2i.common;
using sc2i.win32.common;
using sc2i.win32.data.navigation;

namespace timos
{
	public partial class CCtrlBoutonExtenseur : UserControl, IControlALockEdition
	{
		//------------------------------------------------
		public CCtrlBoutonExtenseur()
		{
			InitializeComponent();
		}

		private bool m_bShow;
		public bool Masque
		{
			get
			{
				return m_bShow;
			}
			set
			{
				m_bShow = value;
			}
		}


		#region IControlALockEdition Membres

		public bool LockEdition
		{
			get
			{
				return !m_gestionnaireModeEdition.ModeEdition;
			}
			set
			{
				m_gestionnaireModeEdition.ModeEdition = !value;
				if (OnChangeLockEdition != null)
					OnChangeLockEdition(this, new EventArgs());
			}
		}

		public event EventHandler OnChangeLockEdition;

		#endregion

	}
}
