using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Text;


using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;

namespace timos.data.preventives
{
	//Represente une ligne du dessin
	public class CDessinSite : IElementADessiner
	{
		public CDessinSite(
			CDessinEditeurPreventive dessinEditeur,
			CSite site)
		{
			m_dessinEditeur = dessinEditeur;
			m_site = site;

			//CREATION DES CELLULES
			m_dessinsCellules = new List<CDessinTrancheSite>();
			foreach (CDessinTranche col in m_dessinEditeur.DessinsTranches)
				m_dessinsCellules.Add(new CDessinTrancheSite(this, col));
		}

		public bool Active
		{
			get
			{
				//On détermine si la ligne est active (si il y a bien des listes d'opérations possibles)
				return (ContratListesOperationsAAfficher.Count != 0 || EnEdition);
			}
		}

		private bool m_bEnEditionCalcule = false;
		private bool m_bEnEdition;
		public bool EnEdition
		{
			get
			{
				//On détermine si la ligne est concernée par l'édition en cour
				if (!m_bEnEditionCalcule)
					m_bEnEdition = ContratListesOperationsEnCour != null && ContratListesOperationsEnCour.AssocieAuSite(Site);
				return m_bEnEdition;
			}
		}

		//TABLE
		private CDessinEditeurPreventive m_dessinEditeur;
		public CDessinEditeurPreventive DessinEditeur
		{
			get
			{
				return m_dessinEditeur;
			}
		}

		//CELLULES
		private List<CDessinTrancheSite> m_dessinsCellules;
		public List<CDessinTrancheSite> DessinsCellules
		{
			get
			{
				return m_dessinsCellules;
			}
		}

		//COLONNES
		public CDessinTranche this[int IndexColonne]
		{
			get
			{
				return DessinEditeur.DessinsTranches[IndexColonne];
			}
		}

		//INTERVENTIONS
		private List<CInterventionPourEditeurPreventive> m_intersLigne;
		public List<CInterventionPourEditeurPreventive> InterventionsLigne
		{
			get
			{
				if (m_intersLigne == null)
					m_intersLigne = DessinEditeur.GetIntersOfSite(Site);
				return m_intersLigne;
			}
		}
		private List<CInterventionPourEditeurPreventive> m_intersEnEdition;
		public List<CInterventionPourEditeurPreventive> InterventionsEnEdition
		{
			get
			{
				if (m_intersEnEdition == null)
				{
					m_intersEnEdition = new List<CInterventionPourEditeurPreventive>();
					if (ContratListesOperationsEnCour != null)
						foreach (CInterventionPourEditeurPreventive i in InterventionsLigne)
							if (i.ListesOperations.Contains(ContratListesOperationsEnCour.ListeOperations))
								m_intersEnEdition.Add(i);
				}
				return m_intersEnEdition;
			}
		}

		//METIER
		private Dictionary<int, CContrat_ListeOperations> m_mappageNumeroLigneContrat;
		public Dictionary<int, CContrat_ListeOperations> MappageNumeroLigneContrat
		{
			get
			{
				if (m_mappageNumeroLigneContrat == null)
				{
					m_mappageNumeroLigneContrat = new Dictionary<int, CContrat_ListeOperations>();
					int nCpt = 1;
					if (ContratListesOperationsEnCour != null)
					{
						m_mappageNumeroLigneContrat.Add(nCpt, ContratListesOperationsEnCour);
						nCpt++;
					}
					foreach(CContrat_ListeOperations c in DessinEditeur.ContratListesOperationsAffichees)
					{
						m_mappageNumeroLigneContrat.Add(nCpt, c);
						nCpt++;
					}
				}
				return m_mappageNumeroLigneContrat;
			}
		}

		public CContrat_ListeOperations ContratListesOperationsEnCour
		{
			get
			{
				return DessinEditeur.ContratListeOperationsEnCour;
			}
		}

		private List<CContrat_ListeOperations> m_cacheContratListeOpAAfficher;
		public List<CContrat_ListeOperations> ContratListesOperationsAAfficher
		{
			get
			{
				if (m_cacheContratListeOpAAfficher != null)
					return m_cacheContratListeOpAAfficher;
				else
				{
					m_cacheContratListeOpAAfficher = new List<CContrat_ListeOperations>();
					foreach (CContrat_ListeOperations c in DessinEditeur.ContratListesOperationsAffichees)
						m_cacheContratListeOpAAfficher.Add(c);
				}
				return m_cacheContratListeOpAAfficher;
			}
		}


		private CSite m_site;
		public CSite Site
		{
			get
			{
				return m_site;
			}
		}

		public void SupprimerIntervention(CInterventionPourEditeurPreventive inter)
		{
			DessinEditeur.SupprimerIntervention(inter);
		}
		public void AjouterIntervention(CInterventionPourEditeurPreventive inter)
		{
			DessinEditeur.AjouterIntervention(inter);
		}

		//OBJECTIFS
		private CDecoupage m_decoupageObj;
		public CDecoupage DecoupageObjectifElementEnEdition
		{
			get
			{
				if (ContratListesOperationsEnCour == null)
					return null;
				if (m_decoupageObj != null)
					return m_decoupageObj;

				DateTime dtStart = DateTime.Now;
				DateTime dtEnd = DateTime.Now;

				if (ContratListesOperationsEnCour.DateDebut != null 
					&& ContratListesOperationsEnCour.DateLimite != null)
				{
					dtStart = ContratListesOperationsEnCour.DateDebut;
					dtEnd = ContratListesOperationsEnCour.DateLimite.Value;
				}
				else if (ContratListesOperationsEnCour.DateDebut != null
					&& ContratListesOperationsEnCour.DateLimite == null)
				{
					dtStart = ContratListesOperationsEnCour.DateDebut;
					dtEnd = DessinEditeur.DateFin;
				}
				else
				{
					dtStart = DessinEditeur.DateDebut;
					dtEnd = ContratListesOperationsEnCour.DateLimite.Value;
				}

				m_decoupageObj = new CDecoupage(
								dtStart,
								dtEnd,
								ContratListesOperationsEnCour.NombrePeriodes,
								(EEchelleTemps)ContratListesOperationsEnCour.PeriodiciteOperationCode,true, EEchelleTemps.Jour);

				return m_decoupageObj;
			}
		}
		public Color GetColorOfTranche(CTranche tranche)
		{
			if (ContratListesOperationsEnCour == null)
				return CouleurFondParDefaut;

			int nbObj = ContratListesOperationsEnCour.NombreParPeriode;
			int cptTrouve = 0;
			foreach (CInterventionPourEditeurPreventive i in InterventionsEnEdition)
				if (i.DateDebut >= tranche.DateDebut && i.DateDebut < tranche.DateFin
					&& !i.Deleted)
					cptTrouve++;

			return cptTrouve >= nbObj ? CouleurFondObjectifOk : CouleurFondObjectifPasOk;
		}
		public Color CouleurFondParDefaut
		{
			get
			{
				return Color.Azure;
			}
		}
		public Color CouleurFondObjectifOk
		{
			get
			{
				return Color.GreenYellow;
			}
		}
		public Color CouleurFondObjectifPasOk
		{
			get
			{
				return Color.Salmon;
			}
		}


		//DESSIN - Entête Ligne
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
			m_mappageNumeroLigneContrat = null;
			m_bEnEditionCalcule = false;
			m_cacheContratListeOpAAfficher = null;
			m_intersLigne = null;
			m_intersEnEdition = null;
			m_decoupageObj = null;
			m_cacheDessin = null;
			foreach (CDessinTrancheSite cell in DessinsCellules)
				cell.Refresh();
		}
		public void RefreshInters()
		{
			foreach (CDessinTrancheSite d in m_dessinsCellules)
				d.RefreshInters();
		}

		private int m_nLastHauteur;
		public int DerniereHauteurConnue
		{
			get
			{
				return m_nLastHauteur;
			}
		}
		public void Draw(Graphics g, Rectangle rect)
		{
			if (m_cacheDessin != null && rect.Size == CacheDessin.Size)
			{
				g.DrawImageUnscaled(m_cacheDessin, rect.Location);
				return;
			}

			m_nLastHauteur = rect.Height;

			Rectangle rcImage = rect;
			rcImage.Offset(new Point(-rcImage.Left, -rcImage.Top));
		
			Image img = new Bitmap(rcImage.Size.Width, rcImage.Size.Height);
			Graphics gTmp = Graphics.FromImage(img);

			//Si assez large on met un label ?
			SolidBrush brush = new SolidBrush(Color.Beige);
			gTmp.FillRectangle(brush, rcImage);

			SizeF sz = gTmp.MeasureString(Site.Libelle, Police);
			float xPolice = 0;
			float yPolice = 0;
			switch (AlignementTexte)
			{
				case ContentAlignment.BottomCenter:
				case ContentAlignment.BottomLeft:
				case ContentAlignment.BottomRight:
					rcImage.Offset(0, rcImage.Height - rcImage.Height);
					break;

				case ContentAlignment.MiddleCenter:
				case ContentAlignment.MiddleLeft:
				case ContentAlignment.MiddleRight:
					xPolice = (rcImage.Width / 2) - sz.Width / 2;
					yPolice = (rcImage.Height / 2) - sz.Height / 2;
					xPolice += rcImage.Location.X;
					yPolice += rcImage.Location.Y;
					break;
			}
			switch (AlignementTexte)
			{
				case ContentAlignment.BottomCenter:
				case ContentAlignment.MiddleCenter:
				case ContentAlignment.TopCenter:
					rcImage.Offset(rcImage.Width / 2 - rcImage.Width / 2, 0);
					break;

				case ContentAlignment.BottomRight:
				case ContentAlignment.MiddleRight:
				case ContentAlignment.TopRight:
					rcImage.Offset(rcImage.Width - rcImage.Width, 0);
					break;
			}
			SolidBrush brush2 = new SolidBrush(CouleurTexte);
			StringFormat formatTexte = new StringFormat();
			formatTexte.Alignment = StringAlignment.Center;
			formatTexte.LineAlignment = StringAlignment.Center;
			gTmp.DrawString(Site.Libelle, Police, brush2, rcImage,formatTexte);

			CDessinEditeurPreventive.DessinerLigne(ECoteRectangle.Bas, System.Drawing.Drawing2D.DashStyle.Solid, Color.Black, 1, rcImage, gTmp);

			g.DrawImageUnscaled(img, rect.Location);
			m_cacheDessin = img;

			brush.Dispose();
			brush2.Dispose();

		}

		private Color m_couleurText = Color.Black;
		public Color CouleurTexte
		{
			get
			{
				return m_couleurText;
			}
			set
			{
				m_couleurText = value;
			}
		}
		private ContentAlignment m_alignement = ContentAlignment.MiddleCenter;
		public ContentAlignment AlignementTexte
		{
			get
			{
				return m_alignement;
			}
			set
			{
				m_alignement = value;
			}
		}
		private Font m_police;
		public Font Police
		{
			get
			{
				if (m_police == null)
					m_police = new Font(new FontFamily(GenericFontFamilies.SansSerif), 8);
				return m_police;
			}
			set
			{
				m_police = value;
			}
		}

	}
}
