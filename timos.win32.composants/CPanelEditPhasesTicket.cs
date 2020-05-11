using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using sc2i.common;
using sc2i.win32.data.navigation;
using sc2i.win32.common;
using sc2i.data;
using sc2i.drawing;
using sc2i.data.dynamic;

using timos.data;
using timos.win32.composants;

namespace timos.win32.composants
{
	public partial class CPanelEditPhasesTicket : UserControl, IControlALockEdition
	{
		private CFournisseurPropDynStd m_fournisseurPropDyn = new CFournisseurPropDynStd(true);
		private CTypeTicket m_typeTicket = null;
		
		public CPanelEditPhasesTicket()
		{
			InitializeComponent();

			m_wndFormule.Init(m_fournisseurPropDyn, typeof(CPhaseTicket));
		}


		public CPanelEditionObjetGraphique Editeur
		{
			get
			{
				return m_controlEdition;
			}
		}
		private List<I2iObjetGraphique> m_lastSelection;
		private bool m_bInitialisationSelection = true;
		
		public CResultAErreur InitChamps(CTypeTicket tpTicket)
		{
			m_bInitialisationSelection = true;
			CResultAErreur result = CResultAErreur.True;
			m_typeTicket = tpTicket;
			CWndTypeTicket wnd = CWndTypeTicket.GetNewWnd(tpTicket);
			m_controlEdition.WndTypeTicketEdite = wnd;
			m_controlEdition.Refresh();
			m_selectTypePhase.Init<CTypePhase> ( 
				"Libelle", 
				true );
			UpdateBoutonsMode();
			if (m_lastSelection != null)
			{
				m_controlEdition.Selection.Clear();
				m_bInitialisationSelection = false;
				m_controlEdition.Selection.AddRange(m_lastSelection);
			}
			m_bInitialisationSelection = false;
			return result;
		}

		

		//-----------------------------------------------------
		public CResultAErreur MajChamps()
		{
			CResultAErreur result = ValideInfosLien();
			if (result)
				result = ValideInfosPhase();
			if (result)
			{
			}
			return result;

		}

		//-----------------------------------------------------------------
		private void m_chkCurseur_CheckedChanged(object sender, EventArgs e)
		{
			if ( m_chkCurseur.Checked )
				m_controlEdition.ModeEdition = EModeEditeurPhaseTicket.Selection;
		}

		//-----------------------------------------------------------------
		private void m_chkPhase_Click(object sender, EventArgs e)
		{
			if ( m_chkPhase.Checked )
				m_controlEdition.ModeEdition = EModeEditeurPhaseTicket.Phase;
		}

		//-----------------------------------------------------------------
		private void m_chkLien_CheckedChanged(object sender, EventArgs e)
		{
			if ( m_chkLien.Checked )
				m_controlEdition.ModeEdition = EModeEditeurPhaseTicket.Lien1;
		}
		
		//-----------------------------------------------------------------
		private void m_selectTypePhase_OnSelectedObjectChanged(object sender, EventArgs e)
		{
			if (m_selectTypePhase.ElementSelectionne is CTypePhase)
			{
				m_controlEdition.TypePhaseEnCreation = (CTypePhase)m_selectTypePhase.ElementSelectionne;
				m_controlEdition.ModeEdition = EModeEditeurPhaseTicket.Phase;
			}
		}

		//-----------------------------------------------------------------
		private void m_controlEdition_AfterAddElementToTypePhase(object sender, EventArgs e)
		{
			m_selectTypePhase.ElementSelectionne = null;
			m_controlEdition.ModeEdition = EModeEditeurPhaseTicket.Selection;
		}

		//-----------------------------------------------------------------
		public bool LockEdition
		{
			get
			{
				return !m_extModeEdition.ModeEdition;
			}
			set
			{
				m_extModeEdition.ModeEdition = !value;
				if (OnChangeLockEdition != null)
					OnChangeLockEdition(this, new EventArgs());
				if ( value )
				{
					m_controlEdition.ModeEdition = EModeEditeurPhaseTicket.Selection;
				}
			}
		}

		public event EventHandler OnChangeLockEdition;


		/// //////////////////////////////////////////
		private bool m_bIsUpdating = false;
		private void UpdateBoutonsMode()
		{
			if (m_bIsUpdating)
				return;
			m_bIsUpdating = true;
			switch (m_controlEdition.ModeEdition)
			{
				case EModeEditeurPhaseTicket.Selection:
					m_chkCurseur.Checked = true;
					break;
				case EModeEditeurPhaseTicket.Phase:
					m_chkPhase.Checked = true;
					break;
				case EModeEditeurPhaseTicket.Lien1:
				case EModeEditeurPhaseTicket.Lien2:
					m_chkLien.Checked = true;
					break;
			}
			m_bIsUpdating = false;
		}

		/// //////////////////////////////////////////
		private void m_controlEdition_AfterModeEditionChanged(object sender, EventArgs e)
		{
			UpdateBoutonsMode();
		}

		//-----------------------------------------------------
		private void m_controlEdition_AfterRemoveObjetGraphique(object sender, EventArgs e)
		{
			m_controlEdition.Selection.Clear();
			m_controlEdition.WndTypeTicketEdite.NettoieObjetsInvalides();
			Refresh();
		}

		//-----------------------------------------------------
		private void CPanelEditPhasesTicket_Load(object sender, EventArgs e)
		{
			m_controlEdition.ModeEdition = EModeEditeurPhaseTicket.Selection;
			m_controlEdition.Selection.SelectionChanged += new EventHandler(Selection_SelectionChanged);
		}

		//-----------------------------------------------------
		private void Selection_SelectionChanged(object sender, EventArgs e)
		{
			if (!m_bInitialisationSelection)
			{
				AfficheInfosPhase(null);
				AfficheInfosLien(null);
				I2iObjetGraphique eleSelec = m_controlEdition.Selection.ControlReference;
				if (eleSelec != null)
				{
					if (eleSelec is CWndLienTypePhase_TypePhase)
						AfficheInfosLien((CWndLienTypePhase_TypePhase)eleSelec);
					else if (eleSelec is CWndTypeTypeTicket_TypePhase)
						AfficheInfosPhase((CWndTypeTypeTicket_TypePhase)eleSelec);
				}
				m_lastSelection = m_controlEdition.Selection;
			}
		}

		//-----------------------------------------------------
		private CWndLienTypePhase_TypePhase m_lastLienAffiche = null;
		private void AfficheInfosLien( CWndLienTypePhase_TypePhase wndLien)
		{
			ValideInfosLien();
			m_lastLienAffiche = wndLien;
			if (wndLien == null)
				m_panelLien.Visible = false;
			else
			{
				m_panelLien.Visible = true;
				CLienTypePhase lien = wndLien.Lien;
				CTypeTicket_TypePhase typePhaseDepart = lien.FromTypePhase;
				CTypeTicket_TypePhase typePhaseArrivee = lien.ToTypePhase;
				m_lblPhase1.Text = typePhaseDepart.TypePhase.Libelle;
				m_lblPhase1.Text = typePhaseArrivee.TypePhase.Libelle;
				m_wndFormule.Formule = lien.FormuleConditionnelle;
			}	
		}

		//-----------------------------------------------------
		private CResultAErreur ValideInfosLien()
		{
			if (m_lastLienAffiche != null)
			{
				CLienTypePhase lien = m_lastLienAffiche.Lien;
				if (lien.IsValide())
				{
                    lien.FormuleConditionnelle = m_wndFormule.Formule;
					m_controlEdition.Refresh();
					Refresh();
				}
			}
			return CResultAErreur.True;
		}


		//-----------------------------------------------------
		private CWndTypeTypeTicket_TypePhase m_lastInterventionAffichee = null;
		private void AfficheInfosPhase(CWndTypeTypeTicket_TypePhase wndPhase)
		{
			ValideInfosPhase();
			m_lastInterventionAffichee = wndPhase;
			if (wndPhase == null)
				m_panelDetailPhase.Visible = false;
			else
			{
				m_panelDetailPhase.Visible = true;
				m_lblPhase.Text = wndPhase.TypeTicket_TypePhase.TypePhase.Libelle;
				m_chkPhaseDemarrage.Checked = wndPhase.TypeTicket_TypePhase.IsPointEntree;
                m_chkPhaseFinale.Checked = wndPhase.TypeTicket_TypePhase.IsPointSortie;
			}
		}

		
		//-----------------------------------------------------
		private CResultAErreur ValideInfosPhase()
		{
			CResultAErreur  result = CResultAErreur.True;
			if (m_lastInterventionAffichee != null && m_lastInterventionAffichee.TypeTicket_TypePhase.IsValide())
			{
                m_lastInterventionAffichee.TypeTicket_TypePhase.IsPointEntree = m_chkPhaseDemarrage.Checked;
                m_lastInterventionAffichee.TypeTicket_TypePhase.IsPointSortie = m_chkPhaseFinale.Checked;
			}
			return result;
		}

		//----------------------------------------------------------------------------
		private void m_radioLien_CheckedChanged(object sender, EventArgs e)
		{
			ValideInfosLien();
		}


		private void m_extModeEdition_ModeEditionChanged(object sender, EventArgs e)
		{
			bool bModeEdition = m_extModeEdition.ModeEdition;
			if (bModeEdition)
			{
			}
			else
			{
			}
			
			m_panelHaut.Visible = bModeEdition;
			m_panelControles.Visible = bModeEdition;
		}		
	}
}
