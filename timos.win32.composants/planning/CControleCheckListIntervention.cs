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

namespace timos.win32.composants.planning
{
	public partial class CControleCheckListIntervention : UserControl, IControlALockEdition
	{
		private bool m_bLockEdition = false;
		private CIntervention m_intervention = null;
		private Dictionary <CContrainte, CheckBox> m_assocCtrCheckBox = new Dictionary<CContrainte, CheckBox>();
		public CControleCheckListIntervention()
		{
			InitializeComponent();
		}

		private class CSorterContraintes : IComparer<CContrainte>
		{
			#region IComparer<CContrainte> Membres

			public int Compare(CContrainte x, CContrainte y)
			{
				return ( x.Libelle.CompareTo ( y.Libelle ));
			}

			#endregion
		}


		//-------------------------------------------------------
		public void InitChamps(CIntervention intervention)
		{
			m_intervention = intervention;
			m_panelCheckList.SuspendDrawing();
			List<CheckBox> lstReserve = new List<CheckBox>();
			foreach ( CheckBox box in m_panelCheckList.Controls )
			{
				box.Visible = false;
				lstReserve.Add ( box );
			}

			m_wndListeContraintesFixes.Items.Clear();
			foreach ( CContrainte contrainte in intervention.ToutesLesContraintesALeverParLesActeurs )
			{
				int nItem = m_wndListeContraintesFixes.Items.Add ( contrainte.LibelleAvecAttributs );
			}

			m_assocCtrCheckBox.Clear();
			List<CContrainte> lstToCheck = new List<CContrainte>(intervention.ToutesLesContraintesCheckList);
			lstToCheck.Sort(new CSorterContraintes());
			foreach (CContrainte contrainte in lstToCheck)
			{
				CheckBox box = null;
				if (lstReserve.Count > 0)
				{
					box = lstReserve[0];
					lstReserve.RemoveAt(0);
				}
				else
				{
					box = new CheckBox();
					m_panelCheckList.Controls.Add(box);
				}
				box.Visible = true;
				box.FlatStyle = FlatStyle.Flat;
				box.Enabled = !LockEdition;
				box.Dock = DockStyle.Top;
				box.BringToFront();
                box.Text = contrainte.TypeContrainte.Libelle + ": " + contrainte.Libelle;
                if(contrainte.Informations != String.Empty)
                    box.Text += " - " + contrainte.Informations;
				box.Checked = intervention.IsChecked(contrainte);
				m_assocCtrCheckBox.Add(contrainte, box);
			}
			m_panelCheckList.ResumeDrawing();
		}

		//-------------------------------------------------------
		public CResultAErreur MajChamps()
		{
			foreach (KeyValuePair<CContrainte, CheckBox> rels in m_assocCtrCheckBox)
			{
				m_intervention.CheckContrainte(rels.Key, rels.Value.Checked);
			}
			return CResultAErreur.True;
		}


		#region IControlALockEdition Membres

		public bool LockEdition
		{
			get
			{
				return m_bLockEdition;
			}
			set
			{
				m_bLockEdition = value;
				foreach (Control ctrl in m_panelCheckList.Controls)
				{
					ctrl.Enabled = !value;
				}
				if (OnChangeLockEdition != null)
					OnChangeLockEdition(this, new EventArgs());
			}
		}

		public event EventHandler OnChangeLockEdition;

		#endregion
	}
}
