using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;

namespace timos.data.preventives
{
	public class CDessinEditeurPreventive
	{
		public CDessinEditeurPreventive(
			CContexteDonnee context,
			CDecoupage decoupage,
			CContrat_ListeOperations relEnCour, 
			List<CSite> sitesAffiches, 
			List<CContrat_ListeOperations> listesOpAffichees)
		{
			m_context = context;
			m_intersSelec = new List<CInterventionPourEditeurPreventive>();
			m_dessinsSites = new List<CDessinSite>();
			m_dessinTranches = new List<CDessinTranche>();
			m_mappageSiteListeInter = new Dictionary<int, List<CInterventionPourEditeurPreventive>>();
			m_mappageSiteEtDessin = new Dictionary<int, CDessinSite>();
			//m_dessinsSiteToRefresh = new List<CDessinSite>();

			//Angle
			m_angle = new CDessinAngle(this);

			MAJStructure(decoupage, relEnCour, sitesAffiches, listesOpAffichees);
		}
		public void MAJStructure(
			CDecoupage decoupage,
			CContrat_ListeOperations relEnCour,
			List<CSite> sitesAffiches,
			List<CContrat_ListeOperations> listesOpAffichees)
		{
			m_bValide = false;

			m_interOver = null;
			m_listeOpOver = null;
			m_intersSelec.Clear();

			m_contratLstOp = relEnCour;
			if (listesOpAffichees.Contains(relEnCour))
				listesOpAffichees.Remove(relEnCour);

			m_sites = sitesAffiches;
			m_contratLstOpsAffichees = listesOpAffichees;


			//Decoupage
			m_decoupage = decoupage;

			if (!m_decoupage.Valide)
				return;

			//Tranches
			m_dessinTranches.Clear();
			if (m_decoupage.NbTranche == 0)
				return;
			for (int t = 1; t <= m_decoupage.NbTranche; t++)
			{
				EPositionDessinTranche? pos = null;
				if (m_decoupage.NbTranche == 1)
					pos = EPositionDessinTranche.Unique;
				else if (t == 1)
					pos = EPositionDessinTranche.Debut;
				else if (t == m_decoupage.NbTranche)
					pos = EPositionDessinTranche.Fin;
				else
					pos = EPositionDessinTranche.Intermediaire;

				m_dessinTranches.Add(new CDessinTranche(this, m_decoupage[t - 1], (EPositionDessinTranche)pos));
			}

			//Sites
			ChargerIntersDesSites();

			m_bValide = true;
		}


		private bool m_bValide = false;
		public bool Valide
		{
			get
			{
				return m_bValide;
			}
		}

		//METIER
		private CContexteDonnee m_context;
		public CContexteDonnee ContexteDonnee
		{
			get
			{
				return m_context;
			}
		}

		private CContrat_ListeOperations m_contratLstOp;
		public CContrat_ListeOperations ContratListeOperationsEnCour
		{
			get
			{
				return m_contratLstOp;
			}
			set
			{
				m_contratLstOp = value;
			}
		}
		private List<CContrat_ListeOperations> m_contratLstOpsAffichees;
		public List<CContrat_ListeOperations> ContratListesOperationsAffichees
		{
			get
			{
				return m_contratLstOpsAffichees;
			}
			set
			{
				m_contratLstOpsAffichees = value;
			}
		}


		//MAPPAGES
		private CDessinSite GetDessinSiteFromSiteId(int id)
		{
			return m_mappageSiteEtDessin[id];
		}
		private Dictionary<int, CDessinSite> m_mappageSiteEtDessin;

		private Dictionary<int, List<CInterventionPourEditeurPreventive>> m_mappageSiteListeInter;
		public bool MappageSiteListeInterExistant(CSite site)
		{
			foreach (int nIdSite in m_mappageSiteListeInter.Keys)
				if (nIdSite == site.Id)
					return true;
			return false;
		}
		private void ChargerIntersDesSites()
		{
			m_dessinsSites.Clear();
			m_mappageSiteEtDessin.Clear();

			List<CDessinSite> rows = new List<CDessinSite>();
			foreach (CSite site in m_sites)
			{
				CDessinSite dessin = new CDessinSite(this, site);
				rows.Add(dessin);
				m_mappageSiteEtDessin.Add(site.Id, dessin);
				ChargerIntersDuSite(site);
			}
			m_dessinsSites = rows;
		}



	

		//ACTIONS SUR LES INTERVENTIONS EN CACHE
		public void AjouterIntervention(CInterventionPourEditeurPreventive inter)
		{
			m_mappageSiteListeInter[inter.Site.Id].Add(inter);
			GetDessinSiteFromSiteId(inter.Site.Id).Refresh();
		}
		public void SupprimerIntervention(CInterventionPourEditeurPreventive inter)
		{
			if (inter.InterventionInDB != null)
				inter.Deleted = true;
			else
				m_mappageSiteListeInter[inter.Site.Id].Remove(inter);
			GetDessinSiteFromSiteId(inter.Site.Id).Refresh();
		}
		public void SelectOrUnSelectIntervention(CInterventionPourEditeurPreventive inter)
		{
			if (m_intersSelec.Contains(inter))
				m_intersSelec.Remove(inter);
			else
				m_intersSelec.Add(inter);

			GetDessinSiteFromSiteId(inter.Site.Id).RefreshInters();

			if (OnSelectionInterChanged != null)
				OnSelectionInterChanged(m_intersSelec);
		}
		public void AjouterSurColonne(int nCol)
		{
			if (!m_bValide)
				return;

			for (int n = 0; n < DessinsSites.Count; n++)
				DessinsTranches[nCol - 1][n].AjouterIntervention();

		}
		public void SupprimerSurColonne(int nCol)
		{
			if (!m_bValide)
				return;
			for (int n = 0; n < DessinsSites.Count; n++)
				DessinsTranches[nCol - 1][n].SupprimerInterventionTrancheExacte();

		}
		public void SupprimerToutSurColonne(int nCol)
		{
			if (!m_bValide)
				return;
			for (int n = 0; n < DessinsSites.Count; n++)
				DessinsTranches[nCol - 1][n].SupprimerInterventions();
		}


		private List<CInterventionPourEditeurPreventive> m_intersSelec = new List<CInterventionPourEditeurPreventive>();
		public List<CInterventionPourEditeurPreventive> IntersSelectionnees
		{
			get
			{
				return m_intersSelec;
			}
		}


		private bool m_bEvidenceEleSurvole;
		public bool MettreEnEvidanceLelementSurvole
		{
			get
			{
				return m_bEvidenceEleSurvole;
			}
			set
			{
				m_bEvidenceEleSurvole = value;
			}
		}
		private CInterventionPourEditeurPreventive m_interOver;
		public CInterventionPourEditeurPreventive InterSurvolee
		{
			get
			{
				return m_interOver;
			}
			set
			{
				CDessinSite old = null;
				if (m_interOver != null)
					old = GetDessinSiteFromSiteId(m_interOver.Site.Id);

				CInterventionPourEditeurPreventive oldInter = m_interOver;
				m_interOver = value;

				CDessinSite newSite = null;
				if (m_interOver != null)
					newSite = GetDessinSiteFromSiteId(m_interOver.Site.Id);

				if (MettreEnEvidanceLelementSurvole)
				{
					if (newSite != null)
						newSite.RefreshInters();
					if (old != null && old != newSite)
						old.RefreshInters();
				}

				if (m_interOver != oldInter)
				{
					if (oldInter != null && OnMouseLeaveInter != null)
						OnMouseLeaveInter(oldInter);
					if (m_interOver != null && OnMouseOverInter != null)
						OnMouseOverInter(m_interOver);
				}
			}
		}


		private CListeOperations m_listeOpOver;
		public CListeOperations ListeOpSurvolee
		{
			get
			{
				return m_listeOpOver;
			}
			set
			{
				CListeOperations oldListeOp = m_listeOpOver;
				m_listeOpOver = value;

				if (m_listeOpOver != oldListeOp)
				{
					if (oldListeOp != null && OnMouseLeaveListeOp != null)
						OnMouseLeaveListeOp(oldListeOp);
					if (m_listeOpOver != null && OnMouseOverListeOp != null)
						OnMouseOverListeOp(m_listeOpOver);
				}
			}
		}




		private void ChargerIntersDuSite(CSite site)
		{
			List<CInterventionPourEditeurPreventive> listeInter = new List<CInterventionPourEditeurPreventive>();

			//CHARGEMENT DES INTERVENTIONS DE LA BASE
			CFiltreData filtreSite = new CFiltreData(CIntervention.c_champIdElementLie + " =@1 AND ("
					 + CIntervention.c_champDateDebutPreplanifiee + " <= @3 AND " +
						CIntervention.c_champDateFinPrePlanifiee + " >= @2)"
					,site.Id, DateDebut, DateFin);

			CListeObjetsDonnees interventions = new CListeObjetsDonnees(ContexteDonnee, typeof(CIntervention), filtreSite);

			interventions.InterditLectureInDB = true;

			//Si il y a des interventions dont les dates et le site correspondent
			if (interventions.Count > 0)
			{
				//ID LISTE INTERVENTIONS CONCERNEES
				string idsInters = "";
				foreach (CIntervention inter in interventions)
					idsInters += inter.Id + ",";

				//ID LISTE OPERATIONS CONCERNEES
				string idsLstOp = "";
				foreach (CContrat_ListeOperations ctLst in ContratListesOperationsAffichees)
					idsLstOp += ctLst.ListeOperations.Id.ToString() + ",";
				if (ContratListeOperationsEnCour != null)
					idsLstOp += ContratListeOperationsEnCour.ListeOperations.Id.ToString() + ",";

				//ON RECUPERE LES RELATIONS QUI CONCERNE LES INTERS POSSIBLES ET LES LISTES OPERATION POSSIBLES
				if (idsInters != "" && idsLstOp != "")
				{
					idsInters = idsInters.Substring(0, idsInters.Length - 1);
					idsLstOp = idsLstOp.Substring(0, idsLstOp.Length - 1);

					CFiltreData filtreListeOp = new CFiltreData(CListeOperations.c_champId +
					" in (" + idsLstOp + ") AND " + CIntervention.c_champId + " in (" + idsInters + ")");
					CListeObjetsDonnees lstOps = new CListeObjetsDonnees(ContexteDonnee, typeof(CIntervention_ListeOperations), filtreListeOp);
					lstOps.InterditLectureInDB = true;
					foreach (CIntervention_ListeOperations rel in lstOps)
						listeInter.Add(new CInterventionPourEditeurPreventive(rel.Intervention));
				}
			}

			//Ajout des interventions aux interventions existantes
			if (MappageSiteListeInterExistant(site))
				foreach (CInterventionPourEditeurPreventive iInDB in listeInter)
				{
					bool bExistant = false;
					foreach (CInterventionPourEditeurPreventive i in m_mappageSiteListeInter[site.Id])
						if (iInDB == i)
						{
							bExistant = true;
							break;
						}

					if (!bExistant)
						m_mappageSiteListeInter[site.Id].Add(iInDB);
				}
			else
				m_mappageSiteListeInter.Add(site.Id, listeInter);
		}


		public List<CInterventionPourEditeurPreventive> GetIntersOfSite(CSite site)
		{
			//ChargerIntersDuSite(site);

			List<CInterventionPourEditeurPreventive> listesConcernees = m_mappageSiteListeInter[site.Id];
			List<CInterventionPourEditeurPreventive> resultatFinal = new List<CInterventionPourEditeurPreventive>();
			foreach (CInterventionPourEditeurPreventive i in listesConcernees)
				if (!i.Deleted)
					resultatFinal.Add(i);
			return resultatFinal;
		}
		public List<CInterventionPourEditeurPreventive> GetIntersOfTranche(CTranche tranche, CSite site)
		{
			List<CInterventionPourEditeurPreventive> listesConcernees = GetIntersOfSite(site);
			List<CInterventionPourEditeurPreventive> resultatFinal = new List<CInterventionPourEditeurPreventive>();
			foreach (CInterventionPourEditeurPreventive i in listesConcernees)
				if (i.DateDebut < tranche.DateFin && i.DateFin > tranche.DateDebut)
					resultatFinal.Add(i);
			return resultatFinal;
		}


		//LIGNES
		private List<CDessinSite> m_dessinsSites;
		public List<CDessinSite> DessinsSites
		{
			get
			{
				return m_dessinsSites;
			}
			set
			{
				m_dessinsSites = value;
			}
		}
		private List<CSite> m_sites;
		public List<CSite> SitesAffichees
		{
			get
			{
				return m_sites;
			}
			set
			{
				m_sites = value;
				ChargerIntersDesSites();
			}
		}



		//ANGLE
		private CDessinAngle m_angle;
		public CDessinAngle DessinAngle
		{
			get
			{
				return m_angle;
			}
			set
			{
				m_angle = value;
			}
		}

		//COLONNES
		public DateTime DateDebut
		{
			get
			{
				return m_decoupage.DateDebut;
			}
		}
		public DateTime DateFin
		{
			get
			{
				return m_decoupage.Tranches[m_decoupage.NbTranche - 1].DateFin;
				//return m_decoupage.DateFin;
			}
		}
		private CDecoupage m_decoupage;
		private List<CDessinTranche> m_dessinTranches;
		public List<CDessinTranche> DessinsTranches
		{
			get
			{
				return m_dessinTranches;
			}
			set
			{
				m_dessinTranches = value;
			}
		}


		//FORMAT DATE
		private EFormatDate m_formatDate = EFormatDate.JourMoisAnnee;
		public EFormatDate FormatDate
		{
			get
			{
				return m_formatDate;
			}
			set
			{
				m_formatDate = value;
				foreach (CDessinTranche dessin in DessinsTranches)
					dessin.Refresh();
			}
		}


		//DESSIN
		public void Draw(int nRow, int nCol, Graphics g, Rectangle rect)
		{
			try
			{
				if (nRow == -1 && nCol == 0)
					DessinAngle.Draw(g, rect);
				else if (nRow == -1 && nCol != 0)
					DessinsTranches[nCol - 1].Draw(g, rect);
				else if (nRow != -1 && nCol == 0)
					DessinsSites[nRow].Draw(g, rect);
				else
					DessinsTranches[nCol - 1][nRow].Draw(g, rect);
			}
			catch
			{
			}
		}

		//EVENEMENTS
		private CDessinTrancheSite GetCelluleXY(int nRow, int nCol)
		{
			if (!m_bValide)
				return null;

			if (nRow == -1 && nCol == 0)
			{
			}
			else if (nRow != -1 && nCol == 0)
			{
			}
			else if (nRow == -1 && nCol != 0)
			{
			}
			else
			{
				return DessinsTranches[nCol - 1][nRow];
			}
			return null;
		}

		public void OnMouseMouve(int nRow, int nCol, Point p)
		{
			ListeOpSurvolee = null;
			InterSurvolee = null;
			CDessinTrancheSite c = GetCelluleXY(nRow, nCol);
			if (c != null)
				c.OnMouseMouve(p);

		}
		public void OnClicLeft(int nRow, int nCol, Point p)
		{
			CDessinTrancheSite c = GetCelluleXY(nRow, nCol);
			if (c != null)
				c.OnClicLeft(p);
		}
		public void OnClicRight(int nRow, int nCol, Point p)
		{
			CDessinTrancheSite c = GetCelluleXY(nRow, nCol);
			if (c != null)
				c.OnClicRight(p);
		}
		public CIntervention GetInterInDBAtPoint(int nRow, int nCol, Point p)
		{
			CDessinTrancheSite c = GetCelluleXY(nRow, nCol);
			if (c == null)
				return null;
			CInterventionPourEditeurPreventive inter = c.GetInterventionFromPoint(p);
			if (inter != null && inter.IsInDB && !inter.Deleted)
				return inter.InterventionInDB;
			return null;
		}
		public string GetLabelItemOnPoint(int nRow, int nCol, Point p)
		{
			CDessinTrancheSite c = GetCelluleXY(nRow, nCol);
			if (c != null)
				return c.GetLabelItemOnPoint(p);
			return "";
		}


		public event EveEditeurPreventiveListeOperation OnMouseOverListeOp;
		public event EveEditeurPreventiveListeOperation OnMouseLeaveListeOp;

		public event EveEditeurPreventiveIntervention OnMouseOverInter;
		public event EveEditeurPreventiveIntervention OnMouseLeaveInter;

		public event EveEditeurPreventiveInterventions OnSelectionInterChanged;


		public CResultAErreur MAJChamps()
		{
			CResultAErreur result = CResultAErreur.True;
			if(ContratListeOperationsEnCour == null)
				return result;

			List<int> idsToDelete = new List<int>();
			string labelContrat = ContratListeOperationsEnCour.Contrat.Libelle;
			Dictionary<int, List<CInterventionPourEditeurPreventive>> nouveauMappage = new Dictionary<int, List<CInterventionPourEditeurPreventive>>();
			foreach (int nIdSite in m_mappageSiteListeInter.Keys)
			{
				List<CInterventionPourEditeurPreventive> intersValidated = new List<CInterventionPourEditeurPreventive>();
				foreach (CInterventionPourEditeurPreventive inter in m_mappageSiteListeInter[nIdSite])
				{
					if (!inter.Deleted)
						intersValidated.Add(inter);

					if (inter.IsInDB && inter.Deleted)
						idsToDelete.Add(inter.InterventionInDB.Id);
					else
						result = inter.MAJChamps(ContexteDonnee, labelContrat);

					if (!result)
						return result;
				}
				nouveauMappage.Add(nIdSite, intersValidated);
			}

			string strIdsToDelete = "";
			foreach (int idToDelete in idsToDelete)
				strIdsToDelete += idToDelete + ",";
			if (strIdsToDelete != "")
			{
				strIdsToDelete = strIdsToDelete.Substring(0, strIdsToDelete.Length - 1);
				CListeObjetsDonnees lstToDelete = new CListeObjetsDonnees(ContexteDonnee, typeof(CIntervention), new CFiltreData(CIntervention.c_champId + " in (" + strIdsToDelete + ")"));
				bool bHasStartModeDeconnecte = ContexteDonnee.BeginModeDeconnecte();
				result = CObjetDonneeAIdNumerique.Delete(lstToDelete);
                if ( bHasStartModeDeconnecte )
				    ContexteDonnee.EndModeDeconnecteSansSauvegardeEtSansReject();
			}
			if (result)
			{
				m_mappageSiteListeInter = nouveauMappage;
				result = ContexteDonnee.CommitEdit();
				ContexteDonnee.AcceptChanges();
			}

			return result;
		}



		public static void DessinerLigne(ECoteRectangle cote, DashStyle typeLigne, Color couleur, int nLargeur, Rectangle rect, Graphics g)
		{
			SolidBrush brush = new SolidBrush(couleur);
			Pen pen = new Pen(brush);
			pen.DashStyle = typeLigne;
			pen.Width = nLargeur;

			switch (cote)
			{
				case ECoteRectangle.Haut:
					g.DrawLine(pen, rect.Location, new Point(rect.X + rect.Width , rect.Y));
					break;
				case ECoteRectangle.Bas:
					g.DrawLine(pen, new Point(rect.X, rect.Y + rect.Height ), new Point(rect.X + rect.Width, rect.Y + rect.Height ));
					break;
				case ECoteRectangle.Droite:
					g.DrawLine(pen, new Point(rect.X + rect.Width , rect.Y), new Point(rect.X + rect.Width , rect.Y + rect.Height));
					break;
				case ECoteRectangle.Gauche:
					g.DrawLine(pen, rect.Location, new Point(rect.X, rect.Y + rect.Height));
					break;
			}
			brush.Dispose();
			pen.Dispose();
		}
	}

	public delegate void EveEditeurPreventiveListeOperation(CListeOperations listeOpe);
	public delegate void EveEditeurPreventiveIntervention(CInterventionPourEditeurPreventive inter);
	public delegate void EveEditeurPreventiveInterventions(List<CInterventionPourEditeurPreventive> inters);
}
