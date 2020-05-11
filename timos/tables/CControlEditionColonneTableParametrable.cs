using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using sc2i.common;
using sc2i.win32.common;
using timos.data;
using sc2i.data;
using sc2i.data.dynamic;

namespace timos
{
	public partial class CControlEditionColonneTableParametrable : UserControl, IControlALockEdition
	{
		private bool m_bIsInitializing = false;
		private CColonneTableParametrable m_col;

		public CControlEditionColonneTableParametrable()
		{
			InitializeComponent();
		}


		public CResultAErreur Init(CColonneTableParametrable col)
		{
			m_bIsInitializing = false;
			CResultAErreur result = CResultAErreur.True;
			if (col == null)
				return result;

			m_col = col;

			//Chargement des types possibles

			m_cmbTypesDonnees.Items.Clear();
			m_cmbTypesDonnees.BeginUpdate();
			m_cmbTypesDonnees.DisplayMember = "Libelle";
			m_cmbTypesDonnees.ValueMember = "TypeDonnee";
			foreach (C2iTypeDonnee tp in CChampCustom.TypePossibles)
				if (tp.TypeDonnee != TypeDonnee.tObjetDonneeAIdNumeriqueAuto)
					m_cmbTypesDonnees.Items.Add(tp);
			m_cmbTypesDonnees.EndUpdate();
			//m_cmbTypesDonnees.DataSource = CChampCustom.TypePossibles;
			//m_cmbTypesDonnees.Items.AddRange();
			//for (int i = m_cmbTypesDonnees.Items.Count; i > 0; i--)
			//    if (m_cmbTypesDonnees.Items[i - 1].ToString() == "Entité")
			//        m_cmbTypesDonnees.Items.RemoveAt(i - 1);

			m_cmbTypesDonnees.SelectedItem = m_col.TypeDonneeChamp;
			m_txtNom.Text = m_col.Libelle;
			m_chkNull.Checked = !col.AllowNull;

			m_lblPK.Visible = m_col.IsPrimaryKey;
			m_chkNull.Visible = !m_lblPK.Visible;

			m_bIsInitializing = true;

			return result;

		}

		public override void  Refresh()
		{
			Init(m_col);
			base.Refresh();
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

		private void m_chkNull_CheckedChanged(object sender, EventArgs e)
		{
			if (m_bIsInitializing)
				m_col.AllowNull = !m_chkNull.Checked;
		}

		private void m_txtNom_TextChanged(object sender, EventArgs e)
		{
			if (m_bIsInitializing)
				m_col.Libelle = m_txtNom.Text;
		}

		private void m_cmbTypesDonnees_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (m_bIsInitializing)
				m_col.TypeDonneeChamp = (C2iTypeDonnee)m_cmbTypesDonnees.SelectedItem;
		}
	}
}
