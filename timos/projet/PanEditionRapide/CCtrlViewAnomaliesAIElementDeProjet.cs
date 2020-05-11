using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using sc2i.data;
using sc2i.data.dynamic;
using sc2i.common;
using sc2i.win32.common;
using sc2i.win32.data.navigation;

using timos.data;

namespace timos
{
	public partial class CCtrlViewAnomaliesAIElementDeProjet : UserControl, IControlALockEdition
	{
		private IElementAAnomalieProjet m_element;
		private bool m_bErreurProjet = false;
		private bool m_bChargement = true;
		//------------------------------------------------
		public CCtrlViewAnomaliesAIElementDeProjet()
		{
			InitializeComponent();
		}

		//------------------------------------------------
		public void Init(IElementAAnomalieProjet element, bool erreurProjet)
		{
			m_bChargement = true;
			m_bErreurProjet = erreurProjet;

			m_element = element;
			m_lvAnos.Columns[1].Width = Width - m_lvAnos.Columns[0].Width - 5;

			ImageList imgLst = new ImageList();
			imgLst.Images.Add(Properties.Resources.anomalienonbloquante);
			imgLst.Images.Add(Properties.Resources.anomaliebloquante);
			m_lvAnos.StateImageList = imgLst;
			m_lvAnos.CheckBoxes = true;


			MAJAffichage();

		}
		public void Init(IElementAAnomalieProjet element)
		{
			Init(element, false);
		}

		private void MAJAffichage()
		{
			m_bChargement = true;
			if (m_chkIgnorer.Checked)
				m_btnIgnorer.Text = I.T("Don't Ignore|1266");
			else
				m_btnIgnorer.Text = I.T("Ignore|31");

			m_lvAnos.Items.Clear();
			CListeObjetsDonnees anomalies = null;
			if (m_bErreurProjet && m_element is CProjet)
				anomalies = ((CProjet)m_element).AnomaliesDuProjet;
			/*else
				anomalies = m_element.AnomaliesEnTantQueFilsProjet;*/
            if (anomalies != null)
            {
                foreach (CAnomalieProjet anomalie in anomalies)
                    if (anomalie.Ignorer == m_chkIgnorer.Checked)
                        AjouterAnomalie(anomalie);
            }

			m_bChargement = false;
		}

		private void AjouterAnomalie(CAnomalieProjet anomalie)
		{
			ListViewItem itm = new ListViewItem("");
			itm.Tag = anomalie;
			itm.SubItems.Add(anomalie.Message);
			m_lvAnos.Items.Add(itm);
		}


		public bool HasAnomalies
		{
			get
			{
				return m_lvAnos.Items.Count != 0;
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


		private void m_btnIgnorer_Click(object sender, EventArgs e)
		{
			List<ListViewItem> itmToDelete = new List<ListViewItem>();
			foreach (ListViewItem itm in m_lvAnos.SelectedItems)
				((CAnomalieProjet)itm.Tag).Ignorer = !m_chkIgnorer.Checked;

			m_lvAnos.SelectedItems.Clear();

			foreach(ListViewItem itm in itmToDelete)
				m_lvAnos.Items.Remove(itm);

			m_btnIgnorer.Visible = false;
		}

		private void m_chkIgnorer_CheckedChanged(object sender, EventArgs e)
		{
			MAJAffichage();
		}

		private void m_lvAnos_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!m_bChargement)
				m_btnIgnorer.Visible = m_lvAnos.SelectedItems.Count > 0;
		}

	}
}
