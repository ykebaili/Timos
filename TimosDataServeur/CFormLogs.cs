using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using timos.serveur;

namespace TimosDataServeur
{
	public partial class CFormLogs : Form
	{
		//Champs privés
		private CLogsMAJStructureBase m_logs;


		#region ++ Constructeur ++
		public CFormLogs(CLogsMAJStructureBase logs)
		{
			m_logs = logs;
			InitializeComponent();

		}
		#endregion

		#region ** Evenements **
		private void m_btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		#endregion
	}
}