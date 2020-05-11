using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using sc2i.drawing;
using sc2i.common;
using timos.data;
using sc2i.win32.common;

namespace timos
{
	public partial class CPanIEditeurWndElementDeProjet : UserControl, IControlALockEdition, IEditeurWndElementDeProjet
	{
		private List<IEditeurWndElementDeProjet> m_listeEditeurs = new List<IEditeurWndElementDeProjet>();

		public event EventHandler ProprieteModifiee;

		public event EventHandler OnClickProprietes;


		//------------------------------------------------
		public CPanIEditeurWndElementDeProjet()
		{
			InitializeComponent();
			foreach ( Control ctrl in Controls )
				if ( ctrl is IEditeurWndElementDeProjet )
					m_listeEditeurs.Add ( (IEditeurWndElementDeProjet)ctrl );
			foreach ( IEditeurWndElementDeProjet editeur in m_listeEditeurs )
				if ( editeur is Control )
					((Control)editeur).Dock = DockStyle.Fill;
		}


		//------------------------------------------------
		public void Init(I2iObjetGraphique elt)
		{
			m_bIdentifie = false;
			foreach (IEditeurWndElementDeProjet editeur in m_listeEditeurs)
			{
				editeur.Init(elt);
				if (editeur is Control)
				{
					((Control)editeur).Visible = editeur.HasElementValide;
					m_bIdentifie |= editeur.HasElementValide;
				}
			}
		}

		private bool m_bIdentifie;
		public bool HasElementValide
		{
			get
			{
				return m_bIdentifie;
			}
		}

		public CResultAErreur MAJChamps()
		{

			CResultAErreur result = CResultAErreur.True;
			if (LockEdition)
				return result;
			foreach (IEditeurWndElementDeProjet editeur in m_listeEditeurs)
			{
				if (editeur.HasElementValide)
				{

					result = editeur.MAJChamps();
					if (!result)
						return result;
				}
			}
			return result;
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
				{
					OnChangeLockEdition(this, new EventArgs());
				}
			}
		}

		public event EventHandler OnChangeLockEdition;

		#endregion

		private void m_editeurProjet_ProprieteModifiee(object sender, EventArgs e)
		{
			if (ProprieteModifiee != null)
				ProprieteModifiee(sender, e);
		}

		private void m_editeur_OnClickPropriete(object sender, EventArgs e)
		{
			if (OnClickProprietes != null)
				OnClickProprietes(sender, e);
		}


	}
}
