using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace timos.tables
{
	public partial class CCtrlEditColonneFilterSituation : UserControl
	{
		public CCtrlEditColonneFilterSituation()
		{
			InitializeComponent();
		}

		public void Initialiser(CDataGridViewColonneFilterSituation situation)
		{
			m_situation = situation;
			sc2i.win32.common.CWin32Traducteur.Translate(this);
		}
		private CDataGridViewColonneFilterSituation m_situation;
		public CDataGridViewColonneFilterSituation Situation
		{
			get
			{
				return m_situation;
			}
		}
		public string Titre
		{
			get
			{
				return m_lblTitre.Text;
			}
			set
			{
				m_lblTitre.Text = value;
			}
		}
		private void m_lblTitre_Click(object sender, EventArgs e)
		{
			OnClick(e);
		}

	}


}
