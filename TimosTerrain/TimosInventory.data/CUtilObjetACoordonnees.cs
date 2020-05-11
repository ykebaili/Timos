using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;



using sc2i.common;
using sc2i.common.memorydb;


namespace TimosInventory.data
{

	/// <summary>
	/// Cette classe fournit des méthodes en relation avec les Objet à Coordonnées <br/>
	/// <list type="bullet">
	///		<item>
	///			<term>NaviguerVersObjet</term>
	///			<description>
	///				Affiche un résultat de recherche intermédiaire des objets correspondant <br/>
	///				à la coordonnnée si il y en a plusieurs puis affiche l'objet voulu dans sa <br/>
	///				fenêtre d'édition
	///			</description>
	///		</item>
	/// </list>
	/// 
	/// </summary>
	public static class CUtilObjetACoordonnees
	{
		#region Membres de travail
		private static CMemoryDb m_ctx;

		//Liste des IDs des parents possibles de Travail
		private static List<string> m_idsEOsParents;
		private static List<string> m_idsSitesParents;
		private static List<string> m_idsStocksParents;
		private static List<string> m_idsEqtsParents;
		private static List<string> IDsEOsParent
		{
			get
			{
				if (m_idsEOsParents == null)
					m_idsEOsParents = new List<string>();
				return m_idsEOsParents;
			}
			set 
			{
				m_idsEOsParents = value;
			}
		}
		private static List<string> IDsSitesParent
		{
			get
			{
				if (m_idsSitesParents == null)
					m_idsSitesParents = new List<string>();
				return m_idsSitesParents;
			}
			set
			{
				m_idsSitesParents = value;
			}
		}
		private static List<string> IDsStocksParent
		{
			get
			{
				if (m_idsStocksParents == null)
					m_idsStocksParents = new List<string>();
				return m_idsStocksParents;
			}
			set
			{
				m_idsStocksParents = value;
			}
		}
		private static List<string> IDsEqtsParent
		{
			get
			{
				if (m_idsEqtsParents == null)
					m_idsEqtsParents = new List<string>();
				return m_idsEqtsParents;
			}
			set
			{
				m_idsEqtsParents = value;
			}
		}

		// Listes d'objets en stand by
		private static List<CObjetACoordonneesEnStandBy> m_lstEOsEnStandBy;
		private static List<CObjetACoordonneesEnStandBy> m_lstSitesEnStandBy;
		private static List<CObjetACoordonneesEnStandBy> m_lstStocksEnStandBy;
		private static List<CObjetACoordonneesEnStandBy> m_lstEqtsEnStandBy;
		public static List<CObjetACoordonneesEnStandBy> lstEOsEnStandBy
		{
			get
			{
				return m_lstEOsEnStandBy;
			}
			set
			{
				m_lstEOsEnStandBy = value;
			}
		}
		public static List<CObjetACoordonneesEnStandBy> lstSitesEnStandBy
		{
			get
			{
				return m_lstSitesEnStandBy;
			}
			set
			{
				m_lstSitesEnStandBy = value;
			}
		}
		public static List<CObjetACoordonneesEnStandBy> lstStocksEnStandBy
		{
			get
			{
				return m_lstStocksEnStandBy;
			}
			set
			{
				m_lstStocksEnStandBy = value;
			}
		}
		public static List<CObjetACoordonneesEnStandBy> lstEquipementsEnStandBy
		{
			get
			{
				return m_lstEqtsEnStandBy;
			}
			set
			{
				m_lstEqtsEnStandBy = value;
			}
		}

		// Listes d'objets fils Possibles
		public static List<CObjetACoordonneesPossible> m_lstEOsPoss;
		public static List<CObjetACoordonneesPossible> m_lstSitesPoss;
		public static List<CObjetACoordonneesPossible> m_lstStocksPoss;
		public static List<CObjetACoordonneesPossible> m_lstEqtsPoss;
		public static List<CObjetACoordonneesPossible> lstEOsPoss
		{
			get 
			{
				return m_lstEOsPoss;
			}
			set 
			{
				m_lstEOsPoss = value;
			}
		}
		public static List<CObjetACoordonneesPossible> lstSitesPoss
		{
			get
			{
				return m_lstSitesPoss;
			}
			set
			{
				m_lstSitesPoss = value;
			}
		}
		public static List<CObjetACoordonneesPossible> lstStocksPoss
		{
			get
			{
				return m_lstStocksPoss;
			}
			set
			{
				m_lstStocksPoss = value;
			}
		}
		public static List<CObjetACoordonneesPossible> lstEquipementsPoss
		{
			get
			{
				return m_lstEqtsPoss;
			}
			set
			{
				m_lstEqtsPoss = value;
			}
		}


		private static bool FirstSearch;
		#endregion

		#region TOols
		private static List<string> GetListIDsPere(EObjetACoordonnee tobj)
		{
			List<string> idsPeres = new List<string>();
			switch (tobj)
			{
				case EObjetACoordonnee.EntiteOrganisationnelle: idsPeres = IDsEOsParent; break;
				case EObjetACoordonnee.Site: idsPeres = IDsSitesParent; break;
				case EObjetACoordonnee.Stock: idsPeres = IDsStocksParent; break;
				case EObjetACoordonnee.Equipement: idsPeres = IDsEqtsParent; break;
				default: break;
			}
			return idsPeres;
		}
		private static List<CObjetACoordonneesPossible> GetListObjsPoss(EObjetACoordonnee tobj)
		{
			List<CObjetACoordonneesPossible> lstObjs = new List<CObjetACoordonneesPossible>();
			switch (tobj)
			{
				case EObjetACoordonnee.EntiteOrganisationnelle: lstObjs = lstEOsPoss;			break;
				case EObjetACoordonnee.Site:					lstObjs = lstSitesPoss;			break;
				case EObjetACoordonnee.Stock:					lstObjs = lstStocksPoss;		break;
				case EObjetACoordonnee.Equipement:				lstObjs = lstEquipementsPoss;	break;
				default: break;
			}
			return lstObjs;
		}
		private static List<CObjetACoordonneesEnStandBy> GetListObjsEnStandBy(EObjetACoordonnee tobj)
		{
			List<CObjetACoordonneesEnStandBy> lstObjs = new List<CObjetACoordonneesEnStandBy>();
			switch (tobj)
			{
				case EObjetACoordonnee.EntiteOrganisationnelle: lstObjs = lstEOsEnStandBy; break;
				case EObjetACoordonnee.Site: lstObjs = lstSitesEnStandBy; break;
				case EObjetACoordonnee.Stock: lstObjs = lstStocksEnStandBy; break;
				case EObjetACoordonnee.Equipement: lstObjs = lstEquipementsEnStandBy; break;
				default: break;
			}
			return lstObjs;
		}
		#endregion



		




		// 1 - WAKE UP (Ajout des IDs Peres Possibles
		private static void WakeUpObjs(string coor)
		{
			WakeUpObjs(EObjetACoordonnee.EntiteOrganisationnelle, coor);
			WakeUpObjs(EObjetACoordonnee.Site, coor);
			WakeUpObjs(EObjetACoordonnee.Stock, coor);
			WakeUpObjs(EObjetACoordonnee.Equipement, coor);

		}
		private static void WakeUpObjs(EObjetACoordonnee tobjs, string coor)
		{


			switch (tobjs)
			{
				case EObjetACoordonnee.EntiteOrganisationnelle:
					IDsEOsParent = new List<string>();

					for (int n = lstEOsEnStandBy.Count; n > 0; n--)
					{
						CObjetACoordonneesEnStandBy obj = lstEOsEnStandBy[n - 1];
						obj.NextLevel();
						if (!obj.ModeStandBy)
						{
							IDsEOsParent.Add(obj.IDObjet);
							lstEOsEnStandBy.RemoveAt(n - 1);
						}
					}
					break;
				case EObjetACoordonnee.Site:
					IDsSitesParent = new List<string>();

					for (int n = lstSitesEnStandBy.Count; n > 0; n--)
					{
						CObjetACoordonneesEnStandBy obj = lstSitesEnStandBy[n - 1];
						obj.NextLevel();
						if (!obj.ModeStandBy)
						{
							IDsSitesParent.Add(obj.IDObjet);
							lstSitesEnStandBy.RemoveAt(n - 1);
						}
					}
					break;
				case EObjetACoordonnee.Stock:
					IDsStocksParent = new List<string>();

					for (int n = lstStocksEnStandBy.Count; n > 0; n--)
					{
						CObjetACoordonneesEnStandBy obj = lstStocksEnStandBy[n - 1];
						obj.NextLevel();
						if (!obj.ModeStandBy)
						{
							IDsStocksParent.Add(obj.IDObjet);
							lstStocksEnStandBy.RemoveAt(n - 1);
						}
					}
					break;

				case EObjetACoordonnee.Equipement:
					IDsEqtsParent = new List<string>();

					for (int n = lstEquipementsEnStandBy.Count; n > 0; n--)
					{
						CObjetACoordonneesEnStandBy obj = lstEquipementsEnStandBy[n - 1];
						obj.NextLevel();
						if (!obj.ModeStandBy)
						{
							IDsEqtsParent.Add(obj.IDObjet);
							lstEquipementsEnStandBy.RemoveAt(n - 1);
						}
					}
					break;

				default:
					break;
			}
		}

		


	}

	/// <summary>
	/// Objet à coordonnées possible lors d'une recherche
	/// </summary>
	public class CObjetACoordonneesPossible
	{
		private string m_coor;
		private string m_id;

		public CObjetACoordonneesPossible(string id, string coor)
		{
			m_id = id;
			m_coor = coor;
		}

		public CObjetACoordonneesPossible(CObjetACoordonneesEnStandBy obj)
		{
			m_id = obj.IDObjet;
			m_coor = I.T("UNKNOWN|254");
		}

		public string IDObjet
		{
			get
			{
				return m_id;
			}
		}

		public string Coordonnee
		{
			get
			{
				return m_coor;
			}
		}
	}

	/// <summary>
	/// Objet de coordonnée en stand by lors d'une recherche
	/// </summary>
	public class CObjetACoordonneesEnStandBy
	{
		private CObjetACoordonneesPossible m_objPoss;
		private bool m_valide;
		private int m_nlevels;
		private string[] m_levels;
		private int m_levelActuel;
		private EObjetACoordonnee m_typeobj;

		#region ++ Constructeur ++
		public CObjetACoordonneesEnStandBy(EObjetACoordonnee tobj, CObjetACoordonneesPossible o, List<string> levelsSuivants)
		{
			m_objPoss = o;
			m_typeobj = tobj;
			m_valide = true;

			if (m_objPoss.Coordonnee.Trim().Replace(CSystemeCoordonnees.c_separateurNumerotations.ToString(), "").Length == 0)
				m_valide = false;


			//On split sa coordonnée
			m_levels = m_objPoss.Coordonnee.Split(CSystemeCoordonnees.c_separateurNumerotations);
			m_nlevels = m_levels.Length;
			m_levelActuel = 0;


			//On vérifie que la coordonnée correspond
			if (levelsSuivants.Count < m_nlevels)
				m_valide = false;
			else if (m_nlevels > 1)
			{
				int cpt = 1;
				foreach (string lv in levelsSuivants)
				{
					if (lv != m_levels[cpt])
					{
						m_valide = false;
						break;
					}
					cpt++;
				}

			}
		}
		#endregion

		#region >> Accesseurs <<
		public string IDObjet
		{
			get
			{
				return m_objPoss.IDObjet;
			}
		}

		public bool Valide
		{
			get
			{
				return m_valide;
			}
		}

		public bool ModeStandBy
		{
			get
			{
				if (m_levelActuel != m_nlevels)
					return true;
				else
					return false;
			}
		}
		public int NiveauActuel
		{
			get
			{
				return m_levelActuel;
			}
		}
		#endregion

		public void NextLevel()
		{
			m_levelActuel++;
		}

	}

	/// <summary>
	/// Types des objets à Coordonnées
	/// </summary>
	[Flags]
	public enum EObjetACoordonnee
	{ 
		Stock = 1,
		Site = 2,
		Equipement = 4,
		EntiteOrganisationnelle = 8
	}
}
