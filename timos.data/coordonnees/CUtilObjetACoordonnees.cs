using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using sc2i.data;
using sc2i.data.dynamic;

using sc2i.common;
using sc2i.workflow;
using timos.securite;
using sc2i.multitiers.client;

namespace timos.data
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
		private static CContexteDonnee m_ctx;

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


		/// <summary>
		/// Affiche un resultat de recherche intermediaire des objets corredpondant <br/>
		/// à la coor si il y en a plusieur puis affiche l'objet voulu dans sa fenetre d'édition
		/// </summary>
		/// <param name="coor">coordonnée</param>
		public static void NaviguerVersObjet(string coor)
		{
		}
		/// <summary>
		/// Retourne une liste d'objet correspondant à la coordonnée souhaitée
		/// </summary>
		/// <param name="coor"></param>
		/// <param name="ctx"></param>
		/// <returns></returns>
		public static List<IObjetACoordonnees> FindObjetsACoordonnees(
			string coor, 
			IObjetACoordonnees parent,
			CContexteDonnee ctx)
		{
			return FindObjetsACoordonnees(coor, null, parent, ctx);
		}
		/// <summary>
		/// Retourne une liste d'objet correspondant à la coordonnée souhaitée
		/// selon un critère de recherche
		/// </summary>
		/// <param name="coor"></param>
		/// <param name="criteresTypeObjets"></param>
		/// <param name="ctx"></param>
		/// <returns></returns>
		public static List<IObjetACoordonnees> FindObjetsACoordonnees(
			string coor, 
			EObjetACoordonnee? criteresTypeObjets, 
			IObjetACoordonnees parent,
			CContexteDonnee ctx)
		{
			m_ctx = ctx;

			List<IObjetACoordonnees> lstObjACoor = new List<IObjetACoordonnees>();
			IDsEOsParent = new List<string>();
			IDsSitesParent = new List<string>();
			IDsStocksParent = new List<string>();
			IDsEqtsParent = new List<string>();
			lstEOsEnStandBy = new List<CObjetACoordonneesEnStandBy>();
			lstSitesEnStandBy = new List<CObjetACoordonneesEnStandBy>();
			lstStocksEnStandBy = new List<CObjetACoordonneesEnStandBy>();
			lstEquipementsEnStandBy = new List<CObjetACoordonneesEnStandBy>();
			lstEOsPoss = new List<CObjetACoordonneesPossible>();
			lstSitesPoss = new List<CObjetACoordonneesPossible>();
			lstStocksPoss = new List<CObjetACoordonneesPossible>();
			lstEquipementsPoss = new List<CObjetACoordonneesPossible>();


			bool EOsExists = true;
			bool SitesExists = true;
			bool StocksExists = true;
			bool EqtsExists = true;

			FirstSearch = true;

			#region 1 - Determination des critères (ou domaine) de recherche
			if (!((criteresTypeObjets & EObjetACoordonnee.EntiteOrganisationnelle) == EObjetACoordonnee.EntiteOrganisationnelle)
					|| criteresTypeObjets == null)
				EOsExists = false;

			if(!((criteresTypeObjets & EObjetACoordonnee.Site) == EObjetACoordonnee.Site)
					|| criteresTypeObjets == null)
				SitesExists = false;

			if(!((criteresTypeObjets & EObjetACoordonnee.Stock) == EObjetACoordonnee.Stock)
					|| criteresTypeObjets == null)
				StocksExists = false;

			if(!((criteresTypeObjets & EObjetACoordonnee.Equipement) == EObjetACoordonnee.Equipement)
					|| criteresTypeObjets == null)
				EqtsExists = false;
			#endregion

			#region  2 - Recherche des IObjetACoordonnees en descendant niveau par niveau
			string[] levels = coor.Split(CSystemeCoordonnees.c_separateurNumerotations);

			if(levels.Length == 0)
				return lstObjACoor;

			if (parent != null)
			{
				CObjetACoordonneesPossible obj = new CObjetACoordonneesPossible(((IObjetDonneeAIdNumerique)parent).Id.ToString(), parent.Coordonnee);
				if (parent.GetType() == typeof(CEntiteOrganisationnelle))
					m_lstEOsPoss.Add(obj);
				if (parent.GetType() == typeof(CSite))
					m_lstSitesPoss.Add(obj);
				if (parent.GetType() == typeof(CStock))
					m_lstStocksPoss.Add(obj);
				if (parent.GetType() == typeof(CEquipement))
					m_lstEqtsPoss.Add(obj);
				FirstSearch = false;
			}


			for (int level = 0; level < levels.Length; level++)
			{
				int nbEOs = 0;
				int nbSites = 0;
				int nbStocks = 0;
				int nbEqts = 0;

				lstEOsPoss = new List<CObjetACoordonneesPossible>();
				lstSitesPoss = new List<CObjetACoordonneesPossible>();
				lstStocksPoss = new List<CObjetACoordonneesPossible>();
				lstEquipementsPoss = new List<CObjetACoordonneesPossible>();

				//WakeUp
				WakeUpObjs(levels[level]);

				//EOs
				nbEOs += FindFilsACoor(EObjetACoordonnee.EntiteOrganisationnelle, levels[level]);

				//Sites
				nbSites += FindFilsACoor(EObjetACoordonnee.Site, levels[level]);

				//Stocks
				nbStocks += FindFilsACoor(EObjetACoordonnee.Stock, levels[level]);

				//Equipements
				nbEqts += FindFilsACoor(EObjetACoordonnee.Equipement, levels[level]);


				FirstSearch = false;



				//Mise en Stand By
				int nextLevel = level + 1;
				if (nextLevel < levels.Length)
				{
					List<string> LevelsSuivants = new List<string>();
					for (int nl = nextLevel; nl < levels.Length; nl++)
						LevelsSuivants.Add(levels[nl]);

					MiseEnStandBy(LevelsSuivants);
				}


				//if (nbEOs == 0 && lstEOsEnStandBy.Count == 0)
				//    EOsExists = false;
				//if (nbEqts == 0 && lstEquipementsEnStandBy.Count == 0)
				//    EqtsExists = false;
				//if (nbStocks == 0 && lstStocksEnStandBy.Count == 0)
				//    StocksExists = false;
				//if (nbSites == 0 && lstStocksEnStandBy.Count == 0)
				//    SitesExists = false;

				if (!(EOsExists && SitesExists && StocksExists && EqtsExists))
					return lstObjACoor;
			}
			#endregion

			// 3 - On ajoute les objets restant en stand by
			// 3 - Ajout des IObjetACoordonnees trouvés à la liste
			if (EOsExists)
			{
				foreach (CObjetACoordonneesEnStandBy o in lstEOsEnStandBy)
					lstEOsPoss.Add(new CObjetACoordonneesPossible(o));

				if(lstEOsPoss.Count > 0)
					AddIObjetACoorOfIDs(ref lstObjACoor, EObjetACoordonnee.EntiteOrganisationnelle);
			}
			if (SitesExists)
			{
				foreach (CObjetACoordonneesEnStandBy o in lstSitesEnStandBy)
					lstSitesPoss.Add(new CObjetACoordonneesPossible(o));
				
				if (lstSitesPoss.Count > 0)
					AddIObjetACoorOfIDs(ref lstObjACoor, EObjetACoordonnee.Site);
			}
			if (StocksExists)
			{
				foreach (CObjetACoordonneesEnStandBy o in lstStocksEnStandBy)
					lstStocksPoss.Add(new CObjetACoordonneesPossible(o));

				if (lstStocksPoss.Count > 0)
					AddIObjetACoorOfIDs(ref lstObjACoor, EObjetACoordonnee.Stock);
			}
			if (EqtsExists)
			{
				foreach (CObjetACoordonneesEnStandBy o in lstEquipementsEnStandBy)
					lstEquipementsPoss.Add(new CObjetACoordonneesPossible(o));

				if (lstEquipementsPoss.Count > 0)
					AddIObjetACoorOfIDs(ref lstObjACoor, EObjetACoordonnee.Equipement);
			}

			return lstObjACoor;
		}


		// ---- FILTRES ----
		private static CFiltreDataAvance GetFiltreForFindHead(EObjetACoordonnee tSouhaite, string coor)
		{
			CFiltreDataAvance filtre = null;


			switch (tSouhaite)
			{
				#region Entites Organisationnelles
				//L'EO doit avoir la coordonnée
					//L'EO ne doit pas être dans une EO 
					//OU ne doit pas être dans une EO qui a un type EO qui lui affecte un parametrage
				case EObjetACoordonnee.EntiteOrganisationnelle:
					filtre = new CFiltreDataAvance(
							CEntiteOrganisationnelle.c_nomTable,
							"(" +
								CEntiteOrganisationnelle.c_champCoordonnee + " = @1 " +
								"OR " +
								CEntiteOrganisationnelle.c_champCoordonnee + " like @3 " +
							")" +
							"AND " +
							"(" +
								"(" +
									//CEntiteOrganisationnelle.c_champIdParent + " is null " +
									"hasno(" + CEntiteOrganisationnelle.c_champIdParent + ")" +
								")" +
								"OR" +
								"(" +
									"(" +
										"EntiteParente." + CEntiteOrganisationnelle.c_champCoordonnee + " =@2" +
									")" +
									"OR" +
									"(" +
										//"EntiteParente." + CEntiteOrganisationnelle.c_champCoordonnee + " is null " +
										"hasno(" + "EntiteParente." + CEntiteOrganisationnelle.c_champCoordonnee + ")" +
									")" +
								")" +
							")" 
							//"AND " + 
							//CEntiteOrganisationnelle.c_champCoordonnee + " =@1 AND (" +
							//CEntiteOrganisationnelle.c_champIdParent + " is null OR HASNO(" +
							//"EntiteParente." + CTypeEntiteOrganisationnelle.c_nomTable + "." +
							//CParametrageSystemeCoordonnees.c_nomTable + "." + CParametrageSystemeCoordonnees.c_champId + ")",
							, coor, "", coor + ".%");
					break;
				#endregion
				#region Sites
				//Le site doit avoir la coordonnée
					//Le site ne doit pas être dans un site qui a une coor
					//Le site ne doit pas être dans une EO qui a une coor
				case EObjetACoordonnee.Site:
					filtre = new CFiltreDataAvance(
						CSite.c_nomTable,
						"(" +
							CSite.c_champCoordonnee + " = @1 " +
							"OR " +
							CSite.c_champCoordonnee + " like @3 " +
						")" +
						"AND " + 
						"(" +
							"(" +
								//CSite.c_champIdParent + " is null " +
								"hasno(" + CSite.c_champIdParent + ")" +
							")" +
							"OR" +
							"(" +
								"(" +
									"SiteParent." + CSite.c_champCoordonnee + " =@2" +
									//"SiteParent." + CSite.c_nomTable + "." + CSite.c_champCoordonnee + " =@2 " +
								")" +
								"OR" +
								"(" +
									"hasno(SiteParent." + CSite.c_champCoordonnee + ")" +
									//"hasno(" + "SiteParent." + CSite.c_nomTable + "." + CSite.c_champCoordonnee + ")" +
								")" +
							")" +
						")" +
						"AND " + 
						"(" +
							"(" +
								//CSite.c_champEOCoor + " is null " +
								"hasno(" + CSite.c_champEOCoor + ")" +
							")" +
							"OR" +
							"(" +
								"(" +
									//"EOdeCoordonnee." + CEntiteOrganisationnelle.c_nomTable + "." + CEntiteOrganisationnelle.c_champCoordonnee + " =@2" +
									"EOdeCoordonnee." + CEntiteOrganisationnelle.c_champCoordonnee + " =@2" +
								")" +
								"OR" +
								"(" +
									"hasno(" + "EOdeCoordonnee." + CEntiteOrganisationnelle.c_champCoordonnee + ")" +
									//"EOdeCoordonnee." + CEntiteOrganisationnelle.c_champCoordonnee + " is null " +
									//"hasno(" + "EOdeCoordonnee." + CEntiteOrganisationnelle.c_nomTable + "." + CEntiteOrganisationnelle.c_champCoordonnee + ")" +
								")" +
							")" +
						")" 

						//+" AND (" +
						//CSite.c_champIdParent + " is null OR HASNO(" +
						//"EntiteParente." + CTypeEntiteOrganisationnelle.c_nomTable + "." +
						//CParametrageSystemeCoordonnees.c_nomTable + "." + CParametrageSystemeCoordonnees.c_champId + ")"
						, coor, "", coor + ".%");
					break;
				#endregion
				#region Stock
				//Le stock doit avoir la coordonnée
					//Le stock ne doit pas être dans un site d'un type site lié à un parametrage
					//Le stock ne doit pas etre dans un site lié à un parametrage
				case EObjetACoordonnee.Stock:
					filtre = new CFiltreDataAvance(
						CStock.c_nomTable,
						"(" +
							CStock.c_champCoordonnee + " = @1 " +
							"OR " +
							CStock.c_champCoordonnee + " like @3 " + 
						")" +
						"AND " + 
						"(" +
							"(" +
								//CSite.c_champId + " is null " +
								"hasno(" + CSite.c_champId + ")" +
							")" +
							"OR" +
							"(" +
								"(" +
									"Site." + CSite.c_champCoordonnee + " = @2 " +
								")" +
								"OR" +
								"(" +
									//"Site." + CSite.c_champCoordonnee + " is null " +
									"hasno(" + "Site." + CSite.c_champCoordonnee + ")" +
								")" +
							")" +
						")" 

						//"HASNO(" +
						//"Site." + CTypeSite.c_nomTable + "." +
						//CParametrageSystemeCoordonnees.c_nomTable + "." + CParametrageSystemeCoordonnees.c_champId + ")" +
						//" AND HASNO(Site." 
						//+ CParametrageSystemeCoordonnees.c_nomTable + "." + CParametrageSystemeCoordonnees.c_champId + ")"
						, coor, "", coor + ".%");
					break;
				#endregion
				#region Equipement
				//L'equipement doit avoir la coordonnée
					
					//ET
							//L'equipement ne doit pas etre dans un Stock 
						//OU
							//L'equipement ne doit pas être dans un stock lié à un parametrage
					//ET
							//L'equipement ne doit pas etre dans un Site
						//OU
							//L'equipement ne doit pas être dans un site lié à un parametrage
							//L'equipement ne doit pas être dans un site avec un type site lié à un parametrage
					//ET
							//L'equipement ne doit pas être dans un Equipement
						//OU
							//L'equipement ne doit pas être dans un Equipement lie à un parametrage
							//L'equipement ne doit pas être dans un Equipement avec un type equipement lié à un parametrage
			

					
				case EObjetACoordonnee.Equipement:
					filtre = new CFiltreDataAvance(
						CEquipement.c_nomTable,
						"(" +
							CEquipement.c_champCoordonnee + " = @1 " +
							"OR " +
							CEquipement.c_champCoordonnee + " like @3 " +
						")" +

						"AND" +
						"(" +
							"(" +
								//CStock.c_champId + " is null " +
								"hasno(" + CStock.c_champId + ")" +
							")" +
							"OR " +
							"(" +
								"(" +
									"EmplacementStock." + CStock.c_champCoordonnee + " = @2 " +
								")" +
								"OR " +
								"(" +
									//"EmplacementStock." + CStock.c_champCoordonnee + " is null" +
									"hasno(" + "EmplacementStock." + CStock.c_champCoordonnee + ")" +
								")" +
							")" +
						")" +
						"AND" +
						"(" +
							"(" +
								//CSite.c_champId + " is null " +
								"hasno(" + CSite.c_champId + ")" +
							")" +
							"OR" +
							"(" +
								"(" +
									"EmplacementSite." + CSite.c_champCoordonnee + " = @2 " +
								")" +
								"OR " +
								"(" +
									//"EmplacementSite." + CSite.c_champCoordonnee + " is null" +
									"hasno(" + "EmplacementSite." + CSite.c_champCoordonnee + ")" +
								")" +
							")" +
						")" +


						"AND" +
						"(" +
							"(" +
								//CEquipement.c_champIdEquipementContenant + " is null " +
								"hasno(" + CEquipement.c_champIdEquipementContenant + ")" +
							")" +
							"OR " +
							"(" +
								"(" +
									"EquipementContenant." + CEquipement.c_champCoordonnee + " = @2 " +
								")" +
								"OR " +
								"(" +
									//"EquipementContenant." + CEquipement.c_champCoordonnee + " is null" +
									"hasno(" + "EquipementContenant." + CEquipement.c_champCoordonnee + ")" +
								")" +
							")" +
						")"
						, coor, "", coor + ".%");

					break;
				#endregion

				default:
					break;
			}

			return filtre;
		}
		private static CFiltreDataAvance GetFiltreForFindChildren(EObjetACoordonnee tPere, EObjetACoordonnee tChildren, string coor)
		{

			CFiltreDataAvance filtre = null;

			List<string> idsPeres = GetListIDsPere(tPere);


			string strIDsPere = "";
			foreach (string sid in idsPeres)
				strIDsPere += sid + ",";

			if (strIDsPere.Length > 0)
				strIDsPere = strIDsPere.Substring(0, strIDsPere.Length - 1);
			else
				return filtre;


			switch (tPere)
			{
				case EObjetACoordonnee.EntiteOrganisationnelle:
					if (tChildren == EObjetACoordonnee.EntiteOrganisationnelle)
					{
						filtre = new CFiltreDataAvance(
						CEntiteOrganisationnelle.c_nomTable,
						"(" +
							CEntiteOrganisationnelle.c_champCoordonnee + " = @1 " +
							"OR " +
							CEntiteOrganisationnelle.c_champCoordonnee + " like @2 " +
						")" +
						"AND" +
						"(" +
							"EntiteParente." + CEntiteOrganisationnelle.c_champId + " in (" + strIDsPere + ")" +
						")"
						, coor, coor + ".%");
					}
					else if (tChildren == EObjetACoordonnee.Site)
					{
						filtre = new CFiltreDataAvance(
						CSite.c_nomTable,
						"(" +
							CSite.c_champCoordonnee + " = @1 " +
							"OR " +
							CSite.c_champCoordonnee + " like @2 " +
						")" +
						"AND" +
						"(" +
							"EOdeCoordonnee." + CEntiteOrganisationnelle.c_champId + " in (" + strIDsPere + ")" +
						")"
						, coor, coor + ".%");
					}
					break;

				case EObjetACoordonnee.Site:
					if (tChildren == EObjetACoordonnee.Site)
					{
						filtre = new CFiltreDataAvance(
						CSite.c_nomTable,
						"(" +
							CSite.c_champCoordonnee + " = @1 " +
							"OR " +
							CSite.c_champCoordonnee + " like @2 " +
						")" +
						"AND" +
						"(" +
							CSite.c_champIdParent + " in (" + strIDsPere + ")" +
						")"
						, coor, coor + ".%");
					}
					else if (tChildren == EObjetACoordonnee.Stock)
					{
						filtre = new CFiltreDataAvance(
						CStock.c_nomTable,
						"(" +
							CStock.c_champCoordonnee + " = @1 " +
							"OR " +
							CStock.c_champCoordonnee + " like @2 " +
						")" +
						"AND" +
						"(" +
							"Site." + CSite.c_champId + " in (" + strIDsPere + ")" +
						")"
						, coor, coor + ".%");
					}
					else if (tChildren == EObjetACoordonnee.Equipement)
					{
						filtre = new CFiltreDataAvance(
						CEquipement.c_nomTable,
						"(" +
							CEquipement.c_champCoordonnee + " = @1 " +
							"OR " +
							CEquipement.c_champCoordonnee + " like @2 " +
						")" +
						"AND" +
						"(" +
							"EmplacementSite." + CSite.c_champId + " in (" + strIDsPere + ")" +
						")"
						, coor, coor + ".%");
					}
					
					
					break;

				case EObjetACoordonnee.Stock:
					if (tChildren == EObjetACoordonnee.Equipement)
					{
						filtre = new CFiltreDataAvance(
						CEquipement.c_nomTable,
						"(" +
							CEquipement.c_champCoordonnee + " = @1 " +
							"OR " +
							CEquipement.c_champCoordonnee + " like @2 " +
						")" +
						"AND" +
						"(" +
							"EmplacementStock." + CStock.c_champId + " in (" + strIDsPere + ")" +
						")"
						, coor, coor + ".%");
					}
					break;



				case EObjetACoordonnee.Equipement:
					if (tChildren == EObjetACoordonnee.Equipement)
					{
						filtre = new CFiltreDataAvance(
						CEquipement.c_nomTable,
						"(" +
							CEquipement.c_champCoordonnee + " = @1 " +
							"OR " +
							CEquipement.c_champCoordonnee + " like @2 " +
						")" +
						"AND" +
						"(" +
							"EquipementContenant." + CEquipement.c_champId + " in (" + strIDsPere + ")" +
						")"
						, coor, coor + ".%");
					}
					break;

				default:
					break;
			}
			return filtre;
		}




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

		// 2 - Descend selon le type et la coordonnee
		private static int FindFilsACoor(EObjetACoordonnee tPere, string coor)
		{



			//On prends les ID des elements actuel (pères)
			//On va (en fonction de leur type) rechercher les fils
			//Ayant la coordonnée

			int totauxPossibles = 0;
			switch (tPere)
			{
				case EObjetACoordonnee.EntiteOrganisationnelle:
					// > EOs
					totauxPossibles += GetChildren(tPere, EObjetACoordonnee.EntiteOrganisationnelle, coor);

					if (!FirstSearch)
					{
						// > Sites
						totauxPossibles += GetChildren(tPere, EObjetACoordonnee.Site, coor);
					}
					break;


				case EObjetACoordonnee.Site:
					// > Sites
					totauxPossibles += GetChildren(tPere, EObjetACoordonnee.Site, coor);

					if (!FirstSearch)
					{
						// > Stocks
						totauxPossibles += GetChildren(tPere, EObjetACoordonnee.Stock, coor);

						// > Equipements
						totauxPossibles += GetChildren(tPere, EObjetACoordonnee.Equipement, coor);
					}
					break;



				case EObjetACoordonnee.Stock:
					// > Equipements
					totauxPossibles += GetChildren(tPere, EObjetACoordonnee.Equipement, coor);
					break;


				case EObjetACoordonnee.Equipement:
					// > Equipements
					totauxPossibles += GetChildren(tPere, EObjetACoordonnee.Equipement, coor);
					break;

				default:
					break;
			}

			return totauxPossibles;

		}

		// 3 - Creation Filtre + Execution Requete et Ajout aux possibles
		private static int GetChildren(EObjetACoordonnee tPeres, EObjetACoordonnee tFils, string coor)
		{
			List<string> idsPeres = GetListIDsPere(tPeres);
			if (idsPeres.Count == 0 && !FirstSearch)
				return 0;

			CFiltreDataAvance filtre = null;

			if (!FirstSearch)
				filtre = GetFiltreForFindChildren(tPeres, tFils, coor);
			else
				filtre = GetFiltreForFindHead(tPeres, coor);


			List<CObjetACoordonneesPossible> lstObjsPoss = GetListObjsPoss(tFils);
			string nomTable = "";
			string colID = "";
			string colCoor = "";

			switch (tFils)
			{
				case EObjetACoordonnee.EntiteOrganisationnelle:
					nomTable = CEntiteOrganisationnelle.c_nomTable;
					colID = CEntiteOrganisationnelle.c_champId;
					colCoor = CEntiteOrganisationnelle.c_champCoordonnee;
					break;

				case EObjetACoordonnee.Site:
					nomTable = CSite.c_nomTable;
					colID = CSite.c_champId;
					colCoor = CSite.c_champCoordonnee;
					break;

				case EObjetACoordonnee.Stock:
					nomTable = CStock.c_nomTable;
					colID = CStock.c_champId;
					colCoor = CStock.c_champCoordonnee;
					break;

				case EObjetACoordonnee.Equipement:
					nomTable = CEquipement.c_nomTable;
					colID = CEquipement.c_champId;
					colCoor = CEquipement.c_champCoordonnee;
					break;

				default:
					break;
			}

			if (nomTable == "" || colID == "")
				return 0;

			CResultAErreur result = CResultAErreur.True;
			C2iRequeteAvancee requete = new C2iRequeteAvancee(-1);
			requete.TableInterrogee = nomTable;
			C2iChampDeRequete champID = new C2iChampDeRequete(
				"Id",
				new CSourceDeChampDeRequete(colID),
				typeof(int),
				OperationsAgregation.None,
				false);
			C2iChampDeRequete champCoor = new C2iChampDeRequete(
				"Coor",
				new CSourceDeChampDeRequete(colCoor),
				typeof(string),
				OperationsAgregation.None,
				false);
			requete.ListeChamps.Add(champID);
			requete.ListeChamps.Add(champCoor);

			requete.FiltreAAppliquer = filtre;
			result = requete.ExecuteRequete(m_ctx.IdSession);

			if (result)
			{
				DataTable table = (DataTable)result.Data;
				foreach (DataRow row in table.Rows)
					lstObjsPoss.Add(new CObjetACoordonneesPossible( ((int)row["Id"]).ToString().Trim(), (string)row["Coor"]));

				return table.Rows.Count;
			}
			else return 0;

		}

		// 4 - Mise en Stand By des objets Possibles
		private static bool MiseEnStandBy(List<string> levelsRetants)
		{
			bool bEOs		= MiseEnStandBy(EObjetACoordonnee.EntiteOrganisationnelle, levelsRetants);
			bool bSites		= MiseEnStandBy(EObjetACoordonnee.Site, levelsRetants);
			bool bStocks	= MiseEnStandBy(EObjetACoordonnee.Stock, levelsRetants);
			bool bEqts		= MiseEnStandBy(EObjetACoordonnee.Equipement, levelsRetants);

			if (bEOs && bSites && bStocks && bEqts)
				return true;
			else
				return false;
		}
		private static bool MiseEnStandBy(EObjetACoordonnee tobjs, List<string> levelsuivants)
		{
			List<CObjetACoordonneesPossible> lst0bjsPoss = GetListObjsPoss(tobjs);
			List<CObjetACoordonneesEnStandBy> lstObjsStandBy = GetListObjsEnStandBy(tobjs);

			for (int cpt = lst0bjsPoss.Count; cpt > 0; cpt--)
			{
				CObjetACoordonneesPossible o = lst0bjsPoss[cpt - 1];
				CObjetACoordonneesEnStandBy obj = new CObjetACoordonneesEnStandBy(tobjs, o, levelsuivants);
				if (obj.Valide)
					lstObjsStandBy.Add(obj);
			}
			return true;

		}

		// 5 - Ajout des Objets en Stand By au resultat final
		private static void AddIObjetACoorOfIDs(ref List<IObjetACoordonnees> objs, EObjetACoordonnee tObj)
		{

			List<CObjetACoordonneesPossible> lstObjsPoss = GetListObjsPoss(tObj);

			string strIDs = "";
			foreach (CObjetACoordonneesPossible obj in lstObjsPoss)
				strIDs += obj.IDObjet + ",";

			if (strIDs.Length == 0)
				return;
			else
				strIDs = strIDs.Substring(0, strIDs.Length - 1);

			CFiltreData filtreIds = null;
			CListeObjetsDonnees lstObjs = null;

			switch (tObj)
			{
				case EObjetACoordonnee.EntiteOrganisationnelle:
					filtreIds = new CFiltreData(CEntiteOrganisationnelle.c_champId + " in (" + strIDs + ")");
					lstObjs = new CListeObjetsDonnees(m_ctx, typeof(CEntiteOrganisationnelle), filtreIds);
					break;

				case EObjetACoordonnee.Site:
					filtreIds = new CFiltreData(CSite.c_champId + " in (" + strIDs + ")");
					lstObjs = new CListeObjetsDonnees(m_ctx, typeof(CSite), filtreIds);
					break;

				case EObjetACoordonnee.Stock:
					filtreIds = new CFiltreData(CStock.c_champId + " in (" + strIDs + ")");
					lstObjs = new CListeObjetsDonnees(m_ctx, typeof(CStock), filtreIds);
					break;

				case EObjetACoordonnee.Equipement:
					filtreIds = new CFiltreData(CEquipement.c_champId + " in (" + strIDs + ")");
					lstObjs = new CListeObjetsDonnees(m_ctx, typeof(CEquipement), filtreIds);
					break;

				default:
					break;
			}

			foreach (CObjetDonnee o in lstObjs)
				objs.Add((IObjetACoordonnees)o);

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
