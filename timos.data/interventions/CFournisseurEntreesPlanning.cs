using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;


using sc2i.data;
using timos.acteurs;

namespace timos.data
{
	public class CFournisseurEntreesPlanning : IBasePlanning
	{
		private List<IElementAIntervention> m_listeElementsAInterventions = new List<IElementAIntervention>();
		private List<IRessourceEntreePlanning> m_listeRessources = new List<IRessourceEntreePlanning>();
        private CContexteDonnee m_contexteDonnee = null;

        //----------------------------------------------------------
        public CFournisseurEntreesPlanning(CContexteDonnee ctxDonnee)
        {
            m_contexteDonnee = ctxDonnee;
        }

        //----------------------------------------------------------
        public CContexteDonnee ContexteDonnee
        {
            get
            {
                return m_contexteDonnee;
            }
        }

		//----------------------------------------------------------
		public IEnumerable<IElementAIntervention> ElementsAIntervention
		{
			get
			{
				return m_listeElementsAInterventions.AsReadOnly();
			}
		}

        //----------------------------------------------------------
        public void AddElementAIntervention(IElementAIntervention elt)
        {
            if (elt is CObjetDonnee)
                elt = ((CObjetDonnee)elt).GetObjetInContexte(m_contexteDonnee) as IElementAIntervention;
            if (!m_listeElementsAInterventions.Contains(elt))
                m_listeElementsAInterventions.Add(elt);
        }

        //----------------------------------------------------------
        public void RemoveElementAIntervention(IElementAIntervention elt)
        {
            m_listeElementsAInterventions.Remove(elt);
        }

        //----------------------------------------------------------
        public void ClearElementsAIntervention()
        {
            m_listeElementsAInterventions.Clear();
        }

		//----------------------------------------------------------
		public IEnumerable<IRessourceEntreePlanning> Ressources
		{
			get
			{
                return m_listeRessources.AsReadOnly();
			}
		}

        //----------------------------------------------------------
        public void AddRessource(IRessourceEntreePlanning ressource)
        {
            if (ressource != null && ressource is CObjetDonnee)
                ressource = ((CObjetDonnee)ressource).GetObjetInContexte(m_contexteDonnee) as IRessourceEntreePlanning;

                
            if (!m_listeRessources.Contains(ressource))
                m_listeRessources.Add(ressource);
        }

        //----------------------------------------------------------
        public void RemoveRessource(IRessourceEntreePlanning ressource)
        {
            m_listeRessources.Remove(ressource);
        }

        //----------------------------------------------------------
        public void ClearRessources()
        {
            m_listeRessources.Clear();
        }

		//----------------------------------------------------------
		public List<ITranchePlanning> GetTranchesForElementsAInterventionBetween(DateTime dateDebut, DateTime dateFin)
		{
			List<ITranchePlanning> lstRetour = new List<ITranchePlanning>();

			Hashtable tableTypeToIds = new Hashtable();
			
			if (m_listeElementsAInterventions.Count == 0)
				return lstRetour;
			
			//Si tous les elements à Intervention sont du même type
			foreach (IElementAIntervention elt in m_listeElementsAInterventions)
			{
				string strIds = (string)tableTypeToIds[elt.GetType()];
				if ( strIds == null )
				{
					strIds = elt.Id+"";
				}
				else
					strIds += ";"+elt.Id;
				tableTypeToIds[elt.GetType()] = strIds;
			}
			dateFin = dateFin.AddDays(1);

			foreach ( DictionaryEntry entry in tableTypeToIds )
			{
				Type tp = (Type)entry.Key;
				string strIds = (string)entry.Value;
				if (tp == typeof(CSite))
				{
					CListeObjetsDonnees liste = new CListeObjetsDonnees(ContexteDonnee, typeof(CFractionIntervention));
					liste.PreserveChanges = true;
					liste.Filtre = new CFiltreDataAvance(
						CFractionIntervention.c_nomTable,
						CIntervention.c_nomTable + "." + CIntervention.c_champIdElementLie + " in (" + strIds + ") and " +
						CFractionIntervention.c_champDateDebutPlanifie + "<@1 and " +
						CFractionIntervention.c_champDateFinPlanifiee + ">@2",
						dateFin,
						dateDebut
						);
					//Lit dans la base
					liste.AssureLectureFaite();
					liste.ReadDependances("Intervention");
					m_contexteDonnee.GetTableSafe(CIntervention.c_nomTable);
					strIds = strIds.Replace(';', ',');


                    string strNomRelation = m_contexteDonnee.GetForeignKeyName(typeof(CFractionIntervention), "Intervention");
					//Et filtre sur les existants (pour prendre les nouveaux en compte)
					string strFiltre = "Parent(" + strNomRelation + ")." + CIntervention.c_champIdElementLie + " in (" + strIds + ") and " +
						CFractionIntervention.c_champDateDebutPlanifie + "<=" + dateFin.ToString("#MM/dd/yyyy#") + " and " +
						CFractionIntervention.c_champDateFinPlanifiee + ">=" + dateDebut.ToString("#MM/dd/yyyy#") + "";
                    DataTable table = m_contexteDonnee.Tables[CFractionIntervention.c_nomTable];
					DataRow[] rows = table.Select(strFiltre);
					foreach (DataRow row in rows)
						lstRetour.Add(new CFractionIntervention(row));
				}

			}
			return lstRetour;
		}

		//----------------------------------------------------------
		public List<ITranchePlanning> GetOccupationsForRessourcesBetween(DateTime dateDebut, DateTime dateFin)
		{
			List<ITranchePlanning> lstRetour = new List<ITranchePlanning>();

			Hashtable tableTypeToIds = new Hashtable();

			if (m_listeRessources.Count == 0)
				return lstRetour;

			CContexteDonnee  contexte = m_listeRessources[0].ContexteDonnee;

			foreach (IRessourceEntreePlanning ressource in Ressources)
			{
				if (tableTypeToIds[ressource.GetType()] == null)
					tableTypeToIds[ressource.GetType()] = ressource.Id+"";
				else
				{
					string strId = (string)tableTypeToIds[ressource.GetType()];
					strId += ","+ressource.Id;
					tableTypeToIds[ressource.GetType()] = strId;
				}
			}
			
			dateFin = dateFin.AddDays(1);
			///IdFraction->True si elle a déjà été ajoutée
			Hashtable tableFractions = new Hashtable();
			foreach (DictionaryEntry entry in tableTypeToIds)
			{
				Type tp = (Type)entry.Key;
				string strIds = (string)entry.Value;

				CListeObjetsDonnees liste;
				string strClauseRessource = "";
				string strDependancesRessources = "";
				string strTableLienRessource = "";
				string strChampIdRessourceInTableLien = "";
				Type typeLienRessource = null;
				if (tp == typeof(CActeur))
				{
					strClauseRessource = CIntervention_Intervenant.c_nomTable + "." + CActeur.c_champId + " in (" + strIds + ")";
					strDependancesRessources = "Intervention.RelationsIntervenants";
					strTableLienRessource = CIntervention_Intervenant.c_nomTable;
					typeLienRessource = typeof(CIntervention_Intervenant);
					strChampIdRessourceInTableLien = CActeur.c_champId;

				}
				else if (tp == typeof(CRessourceMaterielle))
				{
					strClauseRessource = CIntervention_Ressource.c_nomTable + "." + CRessourceMaterielle.c_champId + " in (" + strIds + ")";
					strDependancesRessources = "Intervention.RelationsRessourcesMaterielles";
					strTableLienRessource = CIntervention_Ressource.c_nomTable;
					typeLienRessource=  typeof(CIntervention_Ressource);
					strChampIdRessourceInTableLien = CRessourceMaterielle.c_champId;
				}
				else
					throw new Exception("Type de ressource non prévu : " + tp.ToString());
				liste = new CListeObjetsDonnees(contexte, typeof(CFractionIntervention));
				liste.PreserveChanges = true;
				liste.Filtre = new CFiltreDataAvance(
					CFractionIntervention.c_nomTable,
					CIntervention.c_nomTable + "." +
					strClauseRessource + " and " +
					CFractionIntervention.c_champDateDebutPlanifie + "<@1 and " +
					CFractionIntervention.c_champDateFinPlanifiee + ">@2",
					dateFin,
					dateDebut
					);
				//Lit dans la base
				liste.AssureLectureFaite();
				liste.ReadDependances("Intervention", strDependancesRessources);
				contexte.GetTableSafe(CIntervention.c_nomTable);
				contexte.GetTableSafe(strTableLienRessource);

				string strNomRelationIntervention = contexte.GetForeignKeyName(typeof(CFractionIntervention), "Intervention");
				//Ne sélectionne que ceux qui sont liés à la ressource
				CListeObjetsDonnees listeInterventionIt = new CListeObjetsDonnees(contexte, typeLienRessource);
				listeInterventionIt.InterditLectureInDB = true;
				listeInterventionIt.Filtre = new CFiltreData(strChampIdRessourceInTableLien + " in (" + strIds + ")");
				string strIdsInterventions = "";
				foreach (IEntreePlanning_Ressource it in listeInterventionIt)
				{
					strIdsInterventions += it.EntreePlanning.Id + ",";
				}
				if (strIdsInterventions.Length > 0)
				{
					string strFiltre = "Parent(" + strNomRelationIntervention + ")." + CIntervention.c_champId + " in (" + strIdsInterventions + ") and " +
						CFractionIntervention.c_champDateDebutPlanifie + "<=" + dateFin.ToString("#MM/dd/yyyy#") + " and " +
						CFractionIntervention.c_champDateFinPlanifiee + ">=" + dateDebut.ToString("#MM/dd/yyyy#") + "";
					DataTable table = contexte.Tables[CFractionIntervention.c_nomTable];
					DataRow[] rows = table.Select(strFiltre);
					foreach (DataRow row in rows)
					{
						if (!tableFractions.Contains(row[CFractionIntervention.c_champId]))
						{
							lstRetour.Add(new CFractionIntervention(row));
							tableFractions[row[CFractionIntervention.c_champId]] = true;
						}
					}
				}
			}

			return lstRetour;
		}
	}
}
