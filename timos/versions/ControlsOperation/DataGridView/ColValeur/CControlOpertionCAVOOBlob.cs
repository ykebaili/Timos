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
	public partial class CControlOpertionCAVOOBlob : UserControl
	{
		public CControlOpertionCAVOOBlob()
		{
			InitializeComponent();
			DoubleBuffered = true;
		}


		private CAuditVersionObjetOperation m_cavoo;
		public void Init(CAuditVersionObjetOperation cavoo)
		{
			m_cavoo = cavoo;
		}


	}
}
