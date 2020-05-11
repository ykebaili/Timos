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

namespace timos
{
	public partial class CControleEditeObjetASystemeCoordonnee : UserControl, IControlALockEdition	
	{
		private IObjetASystemeDeCoordonnee m_objetEdite = null;
		private CParametrageSystemeCoordonnees m_parametrageAffiche = null;
		private CParametrageSystemeCoordonnees m_parametragePropre = null;

		public CControleEditeObjetASystemeCoordonnee()
		{
			InitializeComponent();
		}

		public CResultAErreur Init(IObjetASystemeDeCoordonnee objet)
		{
			CResultAErreur  result = CResultAErreur.True;
			if (objet == null)
			{
				Visible = false;
				return result;
			}
			m_objetEdite = objet;
			//m_panelHeritage.Visible = objet.CanHeriteParametrageCoordonnees;

			if (!objet.CanHeriteParametrageCoordonnees)
				m_radioHerite.Text = I.T( "No coordinate system|521");
			else
				m_radioHerite.Text = I.T( "Inherits coordinate system|834");

			m_cmbSystemeCoordonnees.Init(
				typeof(CSystemeCoordonnees),
				"Libelle",
				true);

			m_parametragePropre = objet.ParametrageCoordonneesPropre;

			CParametrageSystemeCoordonnees parametrage = objet.ParametrageCoordonneesApplique;
			result = Init(parametrage);

			return result;
		}

		private bool m_bIsInitializing = false;
		private CResultAErreur Init(CParametrageSystemeCoordonnees parametrage)
		{
			m_bIsInitializing = true;
			CResultAErreur result = CResultAErreur.True;
			m_parametrageAffiche = parametrage;
			if (parametrage == null)
			{
				m_panelParametrage.Visible = false;
				m_radioHerite.Checked = true;
				m_bIsInitializing = false;
				return result;
			}

			m_panelParametrage.Visible = true;

			if (m_parametrageAffiche.ObjetASystemeDeCoordonnees != null &&
				m_parametrageAffiche.ObjetASystemeDeCoordonnees.Equals(m_objetEdite))
			{
				m_parametragePropre = m_parametrageAffiche;
			}
			else
				m_parametragePropre = null;

			m_radioHerite.Checked = m_parametragePropre == null;
			m_radioPropre.Checked = m_parametragePropre != null;

			if (m_parametragePropre == null)
			{
				
				m_gestionnaireModeEdition.SetModeEdition(m_cmbSystemeCoordonnees, TypeModeEdition.Autonome);
				m_gestionnaireModeEdition.SetModeEdition(m_panelParametrageNiveaux, TypeModeEdition.Autonome);
				m_cmbSystemeCoordonnees.LockEdition = true;
				m_panelParametrageNiveaux.LockEdition = true;
			}
			else
			{
				m_gestionnaireModeEdition.SetModeEdition(m_cmbSystemeCoordonnees, TypeModeEdition.EnableSurEdition);
				m_gestionnaireModeEdition.SetModeEdition(m_panelParametrageNiveaux, TypeModeEdition.EnableSurEdition);
				m_cmbSystemeCoordonnees.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
				m_panelParametrageNiveaux.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
			}
			m_cmbSystemeCoordonnees.ElementSelectionne = parametrage.SystemeCoordonnees;

			if (parametrage.SystemeCoordonnees == null)
			{
				m_panelParametrageNiveaux.Visible = false;
			}
			else
			{
				m_panelParametrageNiveaux.SuspendDrawing();
				m_panelParametrageNiveaux.Visible = true;

				List<CControleEditionNiveauParametrage> lstControlesDispo = new List<CControleEditionNiveauParametrage>();
				foreach (Control ctrl in m_panelParametrageNiveaux.Controls)
				{
					if (ctrl is CControleEditionNiveauParametrage)
					{
						lstControlesDispo.Add((CControleEditionNiveauParametrage)ctrl);
						((CControleEditionNiveauParametrage)ctrl).InvalideData();
					}
				}

				int nNiveau = 0;
				foreach (CRelationSystemeCoordonnees_FormatNumerotation rel in m_parametrageAffiche.SystemeCoordonnees.RelationFormatsNumerotation)
				{
					CControleEditionNiveauParametrage control = null;
					if (lstControlesDispo.Count > nNiveau)
						control = lstControlesDispo[nNiveau];
					else
						control = new CControleEditionNiveauParametrage();
					control.Parent = m_panelParametrageNiveaux;
					control.Dock = DockStyle.Top;
					control.Init(nNiveau == 0, m_parametrageAffiche, rel);
					control.LockEdition = m_panelParametrageNiveaux.LockEdition;
					control.Visible = true;
					control.BringToFront();
					nNiveau++;
				}
				m_panelParametrageNiveaux.ResumeDrawing();
				for (int nTmp = nNiveau; nTmp < lstControlesDispo.Count; nTmp++)
				{
					lstControlesDispo[nTmp].Visible = false;
				}
			}

			m_bIsInitializing = false;

			return result;
			
		}

		public event EventHandler OnChangeSystemeCoordonnee;

		//--------------------------------------------------------------------------
		private void m_cmbSystemeCoordonnees_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (m_parametragePropre != null)
			{
				m_parametragePropre.SystemeCoordonnees = (CSystemeCoordonnees)m_cmbSystemeCoordonnees.ElementSelectionne;
				Init(m_parametragePropre);
				if (!m_bIsInitializing && OnChangeSystemeCoordonnee != null)
					OnChangeSystemeCoordonnee(this, new EventArgs());
			}
		}

		//--------------------------------------------------------------------------
		public CResultAErreur MajChamps()
		{
			CResultAErreur result = CResultAErreur.True;
			if (m_objetEdite == null )
				return result;
			if (m_radioHerite.Checked)
			{
				if (m_objetEdite.ParametrageCoordonneesPropre != null)
					result = m_objetEdite.ParametrageCoordonneesPropre.Delete();
				return result;
			}
			m_parametragePropre.SystemeCoordonnees = (CSystemeCoordonnees)m_cmbSystemeCoordonnees.ElementSelectionne;
			if ( m_parametragePropre.SystemeCoordonnees == null )
			{
				result.EmpileErreur(I.T( "Select a coordinate system|509"));
				return result;
			}

			Hashtable tableNiveauxToKeep = new Hashtable();
			foreach (Control ctrl in m_panelParametrageNiveaux.Controls)
			{
				if (ctrl is CControleEditionNiveauParametrage)
				{
					CControleEditionNiveauParametrage ctrlNiveau = (CControleEditionNiveauParametrage)ctrl;
					if (ctrlNiveau.IsValide())
					{
						result = (ctrlNiveau).MajChamps();
						if (!result)
							return result;
						tableNiveauxToKeep[ctrlNiveau.ParametrageNiveau.Id] = true;
					}
				}
			}
			
			//Supprime les niveaux en trop
			ArrayList lstParams = new ArrayList(m_parametragePropre.RelationParametragesNiveau);
			foreach (CParametrageNiveau param in lstParams)
			{
				if (!tableNiveauxToKeep.Contains(param.Id))
				{
					result = param.Delete();
					if (!result)
						return result;
				}
			}
			return result;



		}

		//--------------------------------------------------------------------------
		private void m_radioPropre_CheckedChanged(object sender, EventArgs e)
		{
			if (m_radioPropre.Checked)
			{
				if (!m_gestionnaireModeEdition.ModeEdition || m_bIsInitializing)
					return;
				if (m_parametragePropre == null)
				{
					IObjetASystemeDeCoordonnee donnateur = m_objetEdite.DonnateurParametrageCoordonneeHerite;
					if (donnateur != null)
					{
						m_parametragePropre = donnateur.ParametrageCoordonneesPropre;
						if (m_parametragePropre != null)
						{
							m_parametragePropre = (CParametrageSystemeCoordonnees)m_parametragePropre.Clone(false);
						}
					}
					if (m_parametragePropre == null)
					{
						m_parametragePropre = new CParametrageSystemeCoordonnees(((CObjetDonnee)m_objetEdite).ContexteDonnee);
						m_parametragePropre.CreateNewInCurrentContexte();
						m_parametragePropre.SystemeCoordonnees = (CSystemeCoordonnees)m_cmbSystemeCoordonnees.ElementSelectionne;
					}
					m_parametragePropre.ObjetASystemeDeCoordonnees = m_objetEdite;
					
				}
				Init(m_parametragePropre);
			}
		}

		//--------------------------------------------------------------------------
		private void m_radioHerite_CheckedChanged(object sender, EventArgs e)
		{
			if (m_radioHerite.Checked)
			{
				if (!m_gestionnaireModeEdition.ModeEdition || m_bIsInitializing)
					return;
				IObjetASystemeDeCoordonnee donnataire = m_objetEdite.DonnateurParametrageCoordonneeHerite;
				if (donnataire != null && m_objetEdite.CanHeriteParametrageCoordonnees)
					Init(donnataire.ParametrageCoordonneesPropre);
				else
					Init((CParametrageSystemeCoordonnees)null);
			}
		}

		//--------------------------------------------------------------------------


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
	}
}
