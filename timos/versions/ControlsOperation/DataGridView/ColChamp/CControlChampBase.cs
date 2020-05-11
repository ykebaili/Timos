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
	public partial class CControlChampBase : UserControl
	{
		public CControlChampBase()
		{
			InitializeComponent();
			DoubleBuffered = true;
		}


		private CChampPourVersionInDb m_champ;
		public void Init(CChampPourVersionInDb champ)
		{
			m_champ = champ;
			m_lbl.Text = champ.NomConvivial;
		}


	}
}
