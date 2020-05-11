using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using sc2i.common;
using sc2i.data;
using timos.data;
using sc2i.win32.common;

namespace timos
{
	public partial class CControleEditionNiveauParametrage : UserControl, IControlALockEdition
	{
		private CParametrageSystemeCoordonnees m_parametrageEdite = null;
		private CParametrageNiveau m_parametrageNiveau = null;
		private CRelationSystemeCoordonnees_FormatNumerotation m_relFormat = null;

		private bool m_bIsInit = false;
		//-----------------------------------------------------------
		public CControleEditionNiveauParametrage()
		{
			InitializeComponent();
		}

		//-----------------------------------------------------------
		public CParametrageNiveau ParametrageNiveau
		{
			get
			{
				return m_parametrageNiveau;
			}
		}
		
		//-----------------------------------------------------------
		public void Init( bool bAvecEntete, CParametrageSystemeCoordonnees parametrage, CRelationSystemeCoordonnees_FormatNumerotation relFormat)
		{
			m_parametrageEdite = parametrage;
			m_relFormat = relFormat;
			
			if (m_relFormat == null)
				Visible = false;
			if ( m_relFormat.FormatNumerotation == null )
				Visible = false;
			if ( m_parametrageEdite == null )
				Visible = false;

			m_panelEntete.Visible = bAvecEntete;
			int nHeight = m_lblLibelle.Height;
			if (bAvecEntete)
				nHeight += m_panelEntete.Height;
			Size = new Size(Width, nHeight);

			m_lblLibelle.Text = m_relFormat.Libelle;
			CUniteCoordonnee unite = m_relFormat.Unite;
			if (unite != null)
				m_lblUnite.Text = unite.Libelle;
			else
				m_lblUnite.Text = "";

			int nNiveau = m_relFormat.Position;
			CListeObjetsDonnees  liste = m_parametrageEdite.RelationParametragesNiveau;
			m_parametrageNiveau = m_parametrageEdite.GetParametrageNiveau(m_relFormat.Position);

			CResultAErreur  result = CResultAErreur.True;
			if (m_parametrageNiveau != null)
			{
				result = m_relFormat.FormatNumerotation.GetReference(m_parametrageNiveau.PremierIndice);
				if (result)
					m_txtStartAt.Text = result.Data.ToString();
				m_numUpSize.IntValue = m_parametrageNiveau.Taille;
			}
			else
			{
				result = m_relFormat.FormatNumerotation.GetReference(0);
				if ( result )
					m_txtStartAt.Text = (string)result.Data;
				else
					m_txtStartAt.Text = "";
				m_numUpSize.IntValue = 10;
			}
			m_bIsInit = true;
			m_tooltip.SetToolTip(m_txtStartAt, m_relFormat.FormatNumerotation.Libelle);
		}

		//-----------------------------------------------------------
		public void InvalideData()
		{
			m_bIsInit = false;
		}

		//-----------------------------------------------------------
		public bool IsValide()
		{
			return m_bIsInit;
		}

		//-----------------------------------------------------------
		public CResultAErreur MajChamps()
		{
			CResultAErreur result = CResultAErreur.True;
			if (!m_bIsInit)
				return result;
			if (m_parametrageNiveau == null)
			{
				m_parametrageNiveau = new CParametrageNiveau(m_parametrageEdite.ContexteDonnee);
				m_parametrageNiveau.CreateNewInCurrentContexte();
			}
			m_parametrageNiveau.RelationSysCoor_FormatNum = m_relFormat;

			result = m_relFormat.FormatNumerotation.GetIndex(m_txtStartAt.Text);
			if (!result)
				return result;
			m_parametrageNiveau.PremierIndice = (int)result.Data;
			m_parametrageNiveau.Taille = m_numUpSize.IntValue;
			m_parametrageNiveau.ParametrageSystemeCoordonnees = m_parametrageEdite;

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
					OnChangeLockEdition(this, new EventArgs());
			}
		}

		public event EventHandler OnChangeLockEdition;

		#endregion

		private void m_txtStartAt_TextChanged(object sender, EventArgs e)
		{
			UpdateEndAt();
		}

		private void m_numUpSize_ValueChanged(object sender, EventArgs e)
		{
			UpdateEndAt();
		}

		private void UpdateEndAt()
		{
			CResultAErreur result = CResultAErreur.True;
			m_lblEndAt.Text = "";
			if (m_relFormat == null)
				return;
			else
			{
				result = m_relFormat.FormatNumerotation.GetIndex(m_txtStartAt.Text);
				if (result)
				{
					result = m_relFormat.FormatNumerotation.GetReference((int)result.Data + m_numUpSize.IntValue-1);
					if (result)
						m_lblEndAt.Text = result.Data.ToString();
				}
			}
		}

        private void CControleEditionNiveauParametrage_Load(object sender, EventArgs e)
        {
            CWin32Traducteur.Translate(this);
        }

		
	}
}
