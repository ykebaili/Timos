using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using sc2i.common;
using sc2i.win32.common;
using sc2i.data;
using timos.securite;
using sc2i.win32.data.dynamic;

namespace timos
{
	public partial class CPanelUtilisateur_Profil : UserControl, IControlALockEdition
	{
		private CRelationUtilisateur_Profil m_relationEditee;

		//-------------------------------------------------------------
		public CPanelUtilisateur_Profil()
		{
			InitializeComponent();
			sc2i.win32.common.CWin32Traducteur.Translate(this);
			UpdateCouleurMarge();
		}

		//-------------------------------------------------------------
		public void Init(CRelationUtilisateur_Profil relation)
		{
			m_relationEditee = relation;
			CProfilUtilisateur profil = relation.Profil;
			CListeObjetsDonnees listeInclusionsFillesDuProfil = null;
			if (profil != null)
			{
				m_lblNomProfil.Text = profil.Libelle;
				m_panelEnteteProfil.Visible = true;
				if (profil.Affinable && profil.EntiteOrganisationnelle != null)
				{
					m_lblLibelleSaisie.Text = profil.LibelleSaisieEntite;
					m_panelSelectEntite.Visible = true;
				}
				else
					m_panelSelectEntite.Visible = false;
				listeInclusionsFillesDuProfil = profil.Inclusions;
			}
			else
			{
				if (relation.Profil_Inclusion != null)
				{
					CProfilUtilisateur_Inclusion inclusion = relation.Profil_Inclusion;
					m_panelEnteteProfil.Visible = false;
					if (inclusion.ProfilFils.Affinable && inclusion.ProfilFils.EntiteOrganisationnelle != null)
					{
						m_panelSelectEntite.Visible = true;
						m_lblLibelleSaisie.Text = inclusion.Libelle;
					}
					else
						m_panelSelectEntite.Visible = false;
					listeInclusionsFillesDuProfil = relation.Profil_Inclusion.InclusionsFilles;
				}
			}
			
			UpdateLibelleEntite();

			m_panelSousProfils.SuspendDrawing();
			
			foreach (Control ctrl in m_panelSousProfils.Controls)
			{
				ctrl.Parent = null;
				ctrl.Dispose();
			}
			m_panelSousProfils.Controls.Clear();
			ArrayList lstPanels = new ArrayList();
			Dictionary<int, bool> dicProfilsInclusionARelationsExistantes = new Dictionary<int, bool>();
			foreach (CRelationUtilisateur_Profil sousRel in relation.RelationFilles)
			{
				CPanelUtilisateur_Profil panel = new CPanelUtilisateur_Profil();
				panel.Dock = DockStyle.Top;
				panel.CreateControl();
				panel.LockEdition = LockEdition;
				if (sousRel.Profil_Inclusion != null)
					dicProfilsInclusionARelationsExistantes[sousRel.Profil_Inclusion.Id] = true;
				panel.Init(sousRel);
				lstPanels.Add(panel);
			}
			if (!LockEdition)
			{
				//Vérifie qu'il existe bien de relations pour toutes les inclusions filles
				foreach (CProfilUtilisateur_Inclusion profInc in listeInclusionsFillesDuProfil)
				{
					if (!dicProfilsInclusionARelationsExistantes.ContainsKey(profInc.Id))
					{
						//Il faut créer une relation
						CRelationUtilisateur_Profil newRel = profInc.CreateNewRelationToRelation(relation);
						CPanelUtilisateur_Profil panel = new CPanelUtilisateur_Profil();
						panel.Dock = DockStyle.Top;
						panel.CreateControl();
						panel.Init(newRel);
						lstPanels.Add(panel);
					}
				}
			}
			m_panelSousProfils.Controls.AddRange((Control[])lstPanels.ToArray(typeof(Control)));
			Height = GetIdealHeight();
			m_panelSousProfils.Height = GetHeightSousProfils();
			m_panelSousProfils.ResumeDrawing();
			UpdateCouleurMarge();
		}

		//-------------------------------------------------
		private void UpdateLibelleEntite()
		{
			List<CEntiteOrganisationnelle> lst = m_relationEditee.EntitesLiesExplicites;
			if (lst.Count == 1)
				m_lblEntite.Text = lst[0].LibelleComplet;
			else if (lst.Count == 0)
				m_lblEntite.Text = I.T( "None|148");
			else
			{
				string strLib = "";
				foreach (CEntiteOrganisationnelle entite in lst)
					strLib += entite.LibelleComplet + ", ";
				strLib = strLib.Substring(0, strLib.Length - 2);
				m_lblEntite.Text = I.T( strLib);
			}
		}


		//-------------------------------------------------
		private int GetIdealHeight()
		{
			int nHeight = 0;
			if ( m_panelEnteteProfil.Visible )
				nHeight+= m_panelEnteteProfil.Height;
			if ( m_panelSelectEntite.Visible )
				nHeight += m_panelSelectEntite.Height;
			nHeight += GetHeightSousProfils();
			return nHeight;
		}

		//-------------------------------------------------
		private int GetHeightSousProfils()
		{
			int nHeight = 0;
			foreach ( Control ctrl in m_panelSousProfils.Controls )
				if ( ctrl is CPanelUtilisateur_Profil )
					nHeight += ((CPanelUtilisateur_Profil)ctrl).GetIdealHeight();
			return nHeight;
		}

		//-------------------------------------------------
		private void m_btnParDefaut_Click(object sender, EventArgs e)
		{
			m_relationEditee.ClearEntitesLiees();
			UpdateLibelleEntite();
		}

		//-------------------------------------------------
		private void m_btnSelectEntite_Click(object sender, EventArgs e)
		{
			CEntiteOrganisationnelle racine = null;
			if (m_relationEditee.Profil != null)
				racine = m_relationEditee.Profil.EntiteOrganisationnelle;
			else if (m_relationEditee.Profil_Inclusion != null)
				racine = m_relationEditee.Profil_Inclusion.ProfilFils.EntiteOrganisationnelle;
			if (racine != null)
			{
				CObjetHierarchique[] selection = CFormSelectObjetHierarchique.SelectObjets(
					typeof(CEntiteOrganisationnelle),
					racine,
					(CObjetHierarchique[])m_relationEditee.EntitesLiesExplicites.ToArray());
				if ( selection != null )
				{
				ArrayList lst = new ArrayList ( selection );
				m_relationEditee.SetEntitesLiees((CEntiteOrganisationnelle[])lst.ToArray(typeof(CEntiteOrganisationnelle)));
				UpdateLibelleEntite();
				}
			}
		}

		//--------------------------------------------------------------------
		private void m_panelSousProfils_ParentChanged(object sender, EventArgs e)
		{
			
		}

		//--------------------------------------------------------------------
		private void m_lnkAddProfil_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CProfilUtilisateur profil = (CProfilUtilisateur)CFormSelectUnObjetDonnee.SelectObjetDonnee(
                I.T("Select user profils|20734"),
                typeof(CProfilUtilisateur),
                null,
                "Libelle");
			if (profil != null)
			{
				//Crée la relation du profil
				CRelationUtilisateur_Profil relation = profil.CreateNewRelationToRelation(m_relationEditee);
				CPanelUtilisateur_Profil panel = new CPanelUtilisateur_Profil();
				panel.Parent = m_panelSousProfils;
				panel.CreateControl();
				panel.Dock = DockStyle.Top;
				panel.Init(relation);
				Height = GetIdealHeight();
			}
		}

		private void m_lnkRemoveProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CResultAErreur result = m_relationEditee.Delete();
			if (result)
			{
				Visible = false;
				Control parent = Parent;
				Parent = null;
				parent.Controls.Remove(this);
				Dispose();
			}
			else
			{
				CFormAlerte.Afficher(result.Erreur);
			}
		}

		//------------------------------------------------------------
		private void CPanelUtilisateur_Profil_BackColorChanged(object sender, EventArgs e)
		{
			UpdateCouleurMarge();
		}

		//------------------------------------------------------------
		private void UpdateCouleurMarge()
		{
			Color c = BackColor;
			c = Color.FromArgb(
				c.R / 2, c.G / 2, c.B / 2);
			m_panelMarge.BackColor = c;
		}








		#region IControlALockEdition Membres

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
					OnChangeLockEdition(this, null);
			}
		}

		public event EventHandler OnChangeLockEdition;

		#endregion

		//----------------------------------------------------------------
		private bool m_bAntiLoopPopup = false;
		private void m_tooltip_Popup(object sender, PopupEventArgs e)
		{
			if (m_bAntiLoopPopup)
				return;
			m_bAntiLoopPopup = true;
			if (e.AssociatedControl == m_lblEntite)
			{
				string strText = "";
				foreach (CEntiteOrganisationnelle entite in m_relationEditee.EntitesLieesImplicites)
					strText += entite.LibelleComplet + "\r\n";
				if (strText.Length > 0)
				{
					strText = strText.Substring(0, strText.Length - 2);
					m_tooltip.SetToolTip(e.AssociatedControl, strText);
				}
				else
					e.Cancel = true;
			}
			m_bAntiLoopPopup = false;
		}
	}
}
