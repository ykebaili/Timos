using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;

namespace timos.data.preventives
{
    public class CDessinTrancheSite : IElementADessiner
	{
		public CDessinTrancheSite(CDessinSite dessinSite, CDessinTranche dessinTranche)
		{
			m_bInitialise = false;
			m_dessinSite = dessinSite;
			m_dessinTranche = dessinTranche;
			m_dessinsListesOperations = new List<CDessinListeOperations>();
		}

		private bool m_bInitialise;
		private void Initialiser()
		{
			m_mappageNumeroLigneListeOp = new Dictionary<int, CListeOperations>();
			m_mappageNumeroLigneDessinInter = new Dictionary<int,List<CDessinListeOperations>>();
			m_dessinsListesOperations = new List<CDessinListeOperations>();
			m_nbLigne = ContratListesOperationsPossibles.Count;

			if (m_nbLigne > 0)
			{
				//Récupération des interventions pouvant être concernées
				List<CInterventionPourEditeurPreventive> intersPartiel = DessinSite.DessinEditeur.GetIntersOfTranche(DessinTranche.Tranche, m_dessinSite.Site);

				//On va créer les objets Dessins pour les listes d'opérations
				//Pour tout les contrats possibles (ou lignes)
				int cptLigne = 1;
				foreach (CContrat_ListeOperations contratLstOp in ContratListesOperationsPossibles)
				{
					m_mappageNumeroLigneListeOp.Add(cptLigne, contratLstOp.ListeOperations);
					//pour toutes les interventions correspondant à la tranche
					foreach (CInterventionPourEditeurPreventive intervention in intersPartiel)
					{
						//if (intervention.TypeIntervention != contratLstOp.TypeIntervention)
						//    continue;

						//Pour toutes les listes d'opérations de l'intervention
						foreach (CListeOperations lstOp in intervention.ListesOperations)
							if (lstOp == contratLstOp.ListeOperations)
							{
								CDessinListeOperations dessin = new CDessinListeOperations(this, contratLstOp, intervention);
								m_dessinsListesOperations.Add(dessin);
								AjouterMappageNumeroLigneDessinListeOperation(cptLigne, dessin);
								break;
							}
					}
					cptLigne++;
				}
			}
			m_bInitialise = true;
		}

		//MAPPAGE NUMERO LIGNE / DESSINS LISTE OPERATION
		private bool MappageNumeroLigneDessinListeOperationExist(int nbLigne)
		{
			foreach (int nId in m_mappageNumeroLigneDessinInter.Keys)
				if (nId == nbLigne)
					return true;
			return false;
		}
		private void AjouterMappageNumeroLigneDessinListeOperation(int numeroLigne, CDessinListeOperations dessin)
		{
			if(!MappageNumeroLigneDessinListeOperationExist(numeroLigne))
				m_mappageNumeroLigneDessinInter.Add(numeroLigne,new List<CDessinListeOperations>());
			m_mappageNumeroLigneDessinInter[numeroLigne].Add(dessin);
		}
		private Dictionary<int, List<CDessinListeOperations>> m_mappageNumeroLigneDessinInter;
		private List<CDessinListeOperations> GetDessinsInterOfLigne(int numeroLigne)
		{
			if (!MappageNumeroLigneDessinListeOperationExist(numeroLigne))
				return new List<CDessinListeOperations>();
			else
				return m_mappageNumeroLigneDessinInter[numeroLigne];
		}

		//MAPPAGE NUMERO LIGNE / LISTE OPERATION
		private Dictionary<int, CListeOperations> m_mappageNumeroLigneListeOp;


		//Colonne
		private CDessinTranche m_dessinTranche;
		public CDessinTranche DessinTranche
		{
			get
			{
				return m_dessinTranche;
			}
		}
		//Ligne
		private CDessinSite m_dessinSite;
		public CDessinSite DessinSite
		{
			get
			{
				return m_dessinSite;
			}
		}

		private int m_nbLigne;
		public int NombreLigne
		{
			get
			{
				return m_nbLigne;
			}
		}

		//Retourne la liste des contrats possibles (en incluant le contrat en edition si il existe)
		private List<CContrat_ListeOperations> m_cacheContratListeOpPossibles;
		public List<CContrat_ListeOperations> ContratListesOperationsPossibles
		{
			get
			{
				if (m_cacheContratListeOpPossibles == null)
				{
					m_cacheContratListeOpPossibles = new List<CContrat_ListeOperations>();
					if (DessinSite.ContratListesOperationsEnCour != null)
						m_cacheContratListeOpPossibles.Add(DessinSite.ContratListesOperationsEnCour);
					foreach (CContrat_ListeOperations c in DessinSite.ContratListesOperationsAAfficher)
						m_cacheContratListeOpPossibles.Add(c);
				}
				return m_cacheContratListeOpPossibles;
			}
		}


		public CInterventionPourEditeurPreventive GetInterventionFromPoint(Point p)
		{
			foreach (CDessinListeOperations d in m_dessinsListesOperations)
				if (PointIsOnDessinInter(p, d))
					return d.Intervention;
			return null;
		}
		private bool PointIsOnDessinInter(Point p, CDessinListeOperations d)
		{
			return ((p.X >= d.RectangleInter.X && p.X <= (d.RectangleInter.X + d.RectangleInter.Width))
					&& p.Y >= d.RectangleInter.Y && p.Y <= (d.RectangleInter.Y + d.RectangleInter.Height));
		}
		public CListeOperations GetListeOperationFromPoint(Point p)
		{
			int nLigne = GetNumeroLigneFromY(p.Y);
			if (nLigne == -1)
				return null;
			return m_mappageNumeroLigneListeOp[nLigne];
		}
		public int GetNumeroLigneFromY(int nY)
		{
			if (NombreLigne != 0)
			{
				int nHauteurDesLignes = DessinSite.DerniereHauteurConnue / NombreLigne;
				int nHauteur = nHauteurDesLignes;
				for (int nLigne = 1; nLigne <= NombreLigne; nLigne++)
				{
					if (nY <= nHauteur)
						return nLigne;
					nHauteur += nHauteurDesLignes;
				}
			}
			return -1;
		}

		
		public void AjouterIntervention()
		{
			if (!DessinSite.EnEdition)
				return;

			if (!m_bInitialise)
			{
				List<CInterventionPourEditeurPreventive> intersPartiel = DessinSite.DessinEditeur.GetIntersOfTranche(DessinTranche.Tranche, m_dessinSite.Site);
				if (intersPartiel.Count > 0)
					return;
			}
			else
			{
				//Si il y a une intervention déjà présente on ne peut pas ajouter
				List<CDessinListeOperations> dessins = GetDessinsInterOfLigne(1);
				foreach (CDessinListeOperations d in dessins)
					if (!d.Intervention.Deleted)
						return;
			}

			string strLabel = I.T("Intervention for @1|539", DessinSite.ContratListesOperationsEnCour.ListeOperations.Libelle);
			List<CListeOperations> listeOp = new List<CListeOperations>();
			listeOp.Add(DessinSite.ContratListesOperationsEnCour.ListeOperations);
			CInterventionPourEditeurPreventive i = new CInterventionPourEditeurPreventive(
				strLabel,
				DessinSite.Site,
				listeOp,
				DateDebut,
				DateFin,
				DessinSite.ContratListesOperationsEnCour.TypeIntervention);

			DessinSite.AjouterIntervention(i);
		}
		public void SupprimerInterventionTrancheExacte()
		{
			if (!DessinSite.EnEdition)
				return;

			if (!m_bInitialise)
			{
				List<CInterventionPourEditeurPreventive> intersPartiel = DessinSite.DessinEditeur.GetIntersOfTranche(DessinTranche.Tranche, m_dessinSite.Site);
				foreach (CInterventionPourEditeurPreventive inter in intersPartiel)
					if (inter.DateDebut == DateDebut && inter.DateFin == DateFin &&
						inter.ListesOperations.Contains(DessinSite.ContratListesOperationsEnCour.ListeOperations)
						&& !inter.Deleted)
						DessinSite.SupprimerIntervention(inter);
			}
			else
			{
				List<CDessinListeOperations> dessins = GetDessinsInterOfLigne(1);
				if (dessins.Count == 1 
					&& dessins[0].DateDebut == DateDebut 
					&& dessins[0].DateFin == DateFin
					&& !dessins[0].Intervention.Deleted) //Pas necessaire normalement
					DessinSite.SupprimerIntervention(dessins[0].Intervention);
			}
		}
		public void SupprimerInterventions()
		{
			if (!DessinSite.EnEdition)
				return;

			if (!m_bInitialise)
			{
				List<CInterventionPourEditeurPreventive> intersPartiel = DessinSite.DessinEditeur.GetIntersOfTranche(DessinTranche.Tranche, m_dessinSite.Site);
				foreach (CInterventionPourEditeurPreventive inter in intersPartiel)
					if (!inter.Deleted && inter.ListesOperations.Contains(DessinSite.ContratListesOperationsEnCour.ListeOperations))
						DessinSite.SupprimerIntervention(inter);
			}
			else if(MappageNumeroLigneDessinListeOperationExist(1))
			{
				List<CDessinListeOperations> dessins = GetDessinsInterOfLigne(1);
				foreach (CDessinListeOperations d in dessins)
					if(!d.Intervention.Deleted) //Pas necessaire normalement
						DessinSite.SupprimerIntervention(d.Intervention);
			}
		}


		//EVENEMENTS
		public void OnClicLeft(Point p)
		{
			CInterventionPourEditeurPreventive inter = GetInterventionFromPoint(p);
			if (inter == null)
			{
				AjouterIntervention();
			}
			//else
			//{
			//    if (!DessinSite.EnEdition)
			//        DessinSite.DessinEditeur.SelectOrUnSelectIntervention(inter);
			//    else
			//        DessinSite.SupprimerIntervention(inter);
			//}

		}
		public void OnClicRight(Point p)
		{
			if (DessinSite.EnEdition)
			{
				CInterventionPourEditeurPreventive inter = GetInterventionFromPoint(p);
				if (inter != null)
					DessinSite.SupprimerIntervention(inter);
			}

		}
		public void OnMouseMouve(Point p)
		{
			CInterventionPourEditeurPreventive inter = GetInterventionFromPoint(p);
			CDessinEditeurPreventive dessin = DessinSite.DessinEditeur;
			if (inter != null)
			{
				dessin.InterSurvolee = inter;
				dessin.ListeOpSurvolee = null;
			}
			else
			{
				dessin.InterSurvolee = null;
				dessin.ListeOpSurvolee = GetListeOperationFromPoint(p);
			}
		}
		public string GetLabelItemOnPoint(Point p)
		{
			CInterventionPourEditeurPreventive inter = GetInterventionFromPoint(p);
			if (inter != null)
				return I.T("@1 preplanned between the @2 and @3|541", inter.Label, inter.DateDebut.ToShortDateString(), inter.DateFin.ToShortDateString());
			CListeOperations listeop = GetListeOperationFromPoint(p);
			if (listeop != null)
				return listeop.Libelle;
			return "";
		}


		public DateTime DateDebut
		{
			get
			{
				return DessinTranche.DateDebut;
			}
		}
		public DateTime DateFin
		{
			get
			{
				return DessinTranche.DateFin;
			}
		}

		//Interventions présentes dans la cellule
		private List<CDessinListeOperations> m_dessinsListesOperations;
		public List<CDessinListeOperations> DessinsListesOperations
		{
			get
			{
				return m_dessinsListesOperations;
			}
		}


		//DESSINS
		private Image m_cacheDessin;
		public Image CacheDessin
		{
			get
			{
				return m_cacheDessin;
			}
		}

		public void Refresh()
		{
			m_cacheContratListeOpPossibles = null;
			m_cacheDessin = null;
			

		}
		private bool m_bRefreshInters = false;
		public void RefreshInters()
		{
			foreach (CDessinListeOperations d in m_dessinsListesOperations)
			    d.Refresh();

			m_bRefreshInters = true;
		}
		
		public void Draw(Graphics g, Rectangle rect)
		{
			if (m_cacheDessin == null && !m_bRefreshInters)
				Initialiser();
			else if(rect.Size == CacheDessin.Size && !m_bRefreshInters)
			{
				g.DrawImageUnscaled(CacheDessin, rect.Location);
				return;
			}


			Rectangle rcImage = rect;
			rcImage.Offset(new Point(-rcImage.Left, -rcImage.Top));

			Image img = new Bitmap(rect.Size.Width, rect.Size.Height);
			Graphics gTmp = Graphics.FromImage(img);


			SolidBrush brushAzure = new SolidBrush(Color.Azure);
			SolidBrush brushGray = new SolidBrush(Color.Gray);
			SolidBrush brushRoyaleBlue = new SolidBrush(Color.RoyalBlue);
			Pen crayonBleu = new Pen(brushRoyaleBlue);
			crayonBleu.Width = 2;

			//Pour toutes les lignes
			for (int nL = 1; nL <= NombreLigne; nL++)
			{
				//Recupération du rectangle
				int posY = nL == 1 ? 0 : (nL - 1) * (rcImage.Height / NombreLigne);
				Rectangle rectLigneN = new Rectangle(0, posY, rcImage.Width, rcImage.Height / NombreLigne);

				//BACKGROUND
				bool bConcerne = DessinSite.MappageNumeroLigneContrat[nL].AssocieAuSite(DessinSite.Site);
				if(bConcerne)
					gTmp.FillRectangle(brushAzure, rectLigneN);
				else
					gTmp.FillRectangle(brushGray, rectLigneN);
				if (nL == 1 && DessinSite.EnEdition && bConcerne)
				{
					List<CTranche> tranches = DessinSite.DecoupageObjectifElementEnEdition.GetTranchesConcernees(DateDebut, DateFin);
					foreach (CTranche t in tranches)
					{
						SolidBrush brush = new SolidBrush(DessinSite.GetColorOfTranche(t));

						DateTime dtStartDecoup = t.DateDebut < DateDebut ? DateDebut : t.DateDebut;
						DateTime dtEndDecoup = t.DateFin > DateFin ? DateFin : t.DateFin;
						decimal fWithTranche = ((
							((decimal)dtEndDecoup.Ticks - (decimal)dtStartDecoup.Ticks)
							* (decimal)rectLigneN.Width) / 
							((decimal)DateFin.Ticks - (decimal)DateDebut.Ticks));
						int nWithTranche = Convert.ToInt32(fWithTranche) + 1;
						int posX = GetX(dtStartDecoup, rectLigneN.Width);
						Rectangle rTranche = new Rectangle(posX, 0, nWithTranche, rectLigneN.Height);
						gTmp.FillRectangle(brush, rTranche);
						brush.Dispose();

					}
				}

				//DESSIN DES INTERS
				List<CDessinListeOperations> dessinsInters = GetDessinsInterOfLigne(nL);
				foreach (CDessinListeOperations dessin in dessinsInters)
					dessin.Draw(gTmp, rectLigneN);


				
				if(nL > 1)
					CDessinEditeurPreventive.DessinerLigne(ECoteRectangle.Haut, System.Drawing.Drawing2D.DashStyle.Dot, Color.Wheat, 1, rectLigneN, gTmp);
			}


			//LIGNES OBJECTIF
			if (DessinSite.ContratListesOperationsEnCour != null)
			{
				CDecoupage decoupEle = DessinSite.DecoupageObjectifElementEnEdition;
				List<DateTime> datesDecoupage = decoupEle.GetDatesConcernees(DateDebut, DateFin);
				foreach (DateTime dt in datesDecoupage)
				{
					//Dessiner la ligne
					//System.Drawing.Drawing2D.DashStyle styleLigne = System.Drawing.Drawing2D.DashStyle.Solid;
					//if (nCptDecoup == 0 || nCptDecoup == datesDecoupage.Count - 1)
					//    styleLigne = System.Drawing.Drawing2D.DashStyle.DashDotDot;
					//crayonBleu.DashStyle = styleLigne;
					int posXLigne = GetX(dt, rcImage.Width);
					if (posXLigne == rcImage.Width)
						posXLigne--;
					if (posXLigne == 0)
						posXLigne++;
					gTmp.DrawLine(crayonBleu, new Point(posXLigne, 0), new Point(posXLigne, rcImage.Height));
				}

			}


			//BORDS DROIT ET GAUCHE
			switch (DessinTranche.PositionTranche)
			{
				case EPositionDessinTranche.Debut:
					CDessinEditeurPreventive.DessinerLigne(ECoteRectangle.Gauche, System.Drawing.Drawing2D.DashStyle.Solid, Color.Black, 1, rcImage, gTmp);
					break;

				case EPositionDessinTranche.Fin:
					CDessinEditeurPreventive.DessinerLigne(ECoteRectangle.Droite, System.Drawing.Drawing2D.DashStyle.Solid, Color.Black, 1, rcImage, gTmp);
					goto case EPositionDessinTranche.Intermediaire;

				case EPositionDessinTranche.Intermediaire:
					CDessinEditeurPreventive.DessinerLigne(ECoteRectangle.Gauche, System.Drawing.Drawing2D.DashStyle.Dash, Color.Black, 1, rcImage, gTmp);
					break;

				case EPositionDessinTranche.Unique:
					CDessinEditeurPreventive.DessinerLigne(ECoteRectangle.Gauche, System.Drawing.Drawing2D.DashStyle.Solid, Color.Black, 1, rcImage, gTmp);
					CDessinEditeurPreventive.DessinerLigne(ECoteRectangle.Droite, System.Drawing.Drawing2D.DashStyle.Solid, Color.Black, 1, rcImage, gTmp);
					break;
			}

			CDessinEditeurPreventive.DessinerLigne(ECoteRectangle.Bas, System.Drawing.Drawing2D.DashStyle.Solid, Color.Black, 1, rcImage, gTmp);

			g.DrawImageUnscaled(img, rect.Location);
			m_cacheDessin = img;

			m_bRefreshInters = false;

			brushAzure.Dispose();
			brushGray.Dispose();
			brushRoyaleBlue.Dispose();
			crayonBleu.Dispose();
		}

		private int GetX(DateTime dt, int nWidth)
		{
			double fEch = ((double)DateFin.Ticks - (double)DateDebut.Ticks) / nWidth;
			return (int)((((double)dt.Ticks - (double)DateDebut.Ticks))/fEch);
		}
    }
}
