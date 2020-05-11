using System;
using System.Resources;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using sc2i.data;
using sc2i.common;

using timos.data;

namespace timos
{
	public partial class CControlEditMappage : UserControl
	{
		public CControlEditMappage()
		{
			InitializeComponent();
		}

		private List<CControlEditMappageColonne> m_ctrlsEdition = new List<CControlEditMappageColonne>();
		public void Initialiser(CMappeurTypeTableParametrableTypeTableParametrable mappeur)
		{

			m_spc.Panel1.Controls.Clear();
			m_spc.Panel1.Controls.Add(m_lblTitre1);
			m_lblTitre1.SendToBack();
			CControlEditMappageColonne ctrlEntete1 = new CControlEditMappageColonne();
			ctrlEntete1.Initialiser(false);
			m_spc.Panel1.Controls.Add(ctrlEntete1);
			ctrlEntete1.Dock = DockStyle.Top;
			ctrlEntete1.BringToFront();

			m_spc.Panel2.Controls.Clear();
			m_spc.Panel2.Controls.Add(m_lblTitre2);
			m_lblTitre2.SendToBack();
			CControlEditMappageColonne ctrlEntete2 = new CControlEditMappageColonne();
			ctrlEntete2.Initialiser(true);
			m_spc.Panel2.Controls.Add(ctrlEntete2);
			ctrlEntete2.Dock = DockStyle.Top;
			ctrlEntete2.BringToFront();

			foreach (CMappageColonneTableParametrableColonneTableParametrable map in mappeur.Mappages)
			{
				CControlEditMappageColonne ctrl = new CControlEditMappageColonne();
				ctrl.Initialiser(map, mappeur.TypeTableSource);
				m_spc.Panel1.Controls.Add(ctrl);
				ctrl.Dock = DockStyle.Top;
				ctrl.BringToFront();

				m_ctrlsEdition.Add(ctrl);

				CControlEditMappageColonne ctrlBis = new CControlEditMappageColonne();
				ctrlBis.Initialiser(map);
				m_spc.Panel2.Controls.Add(ctrlBis);
				ctrlBis.Dock = DockStyle.Top;
				ctrlBis.BringToFront();

				m_ctrlsEdition.Add(ctrlBis);
			}
			RecalcHeight();
		}

		private void RecalcHeight()
		{
			if (m_ctrlsEdition.Count > 0)
			{
				CControlEditMappageColonne lastCtrl = m_ctrlsEdition[m_ctrlsEdition.Count - 1];
				m_spc.Height = (lastCtrl.Height * (m_ctrlsEdition.Count + 1)) + (Math.Max(m_lblTitre1.Height,m_lblTitre2.Height));
			}
		}

		public CResultAErreur MAJChamp()
		{
			CResultAErreur result = CResultAErreur.True;
			foreach (CControlEditMappageColonne ctrl in m_ctrlsEdition)
			{
				CResultAErreur resultCtrl = ctrl.MAJChamp();
				foreach (IErreur err in resultCtrl.Erreur.Erreurs)
					result.EmpileErreur(err);
			}
			return result;
		}
	}
}

