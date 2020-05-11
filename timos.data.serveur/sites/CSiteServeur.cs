using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

using timos.data;
using timos.securite;

namespace timos.data.serveur
{
    /// <summary>
    /// Description résumée de CSiteServeur.
    /// </summary>
    public class CSiteServeur : CObjetHierarchiqueServeur
    {
        //-------------------------------------------------------------------
        public CSiteServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CSite.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			
            try
			{
                CSite site = (CSite)objet;

                // Verifie le champ "Libelle"
                if (site.Libelle == "")
					result.EmpileErreur(I.T("The Site label cannot be empty|108"));
                
                // Le champ "Libelle" doit ÃƒÂªtre unique dans son parent seulement.
                if (site.SiteParent != null)
                {
                    // Liste des sites frÃƒÂ¨res lst
                    CListeObjetsDonnees lst = site.SiteParent.SitesFils;
                     
                    lst.Filtre = new CFiltreData(CSite.c_champLibelle + " = @1 AND " + CSite.c_champId + " <> @2", site.Libelle, site.Id);
                    if (lst.CountNoLoad != 0)
                        result.EmpileErreur(I.T("The Site '@1' already exists|370", site.Libelle));
                }                

                // Vérifie le type de site
                if (site.TypeSite == null)
                    result.EmpileErreur(I.T("The site type cannot be empty|106"));

                // Verifie le type du site fils
				if (site.SiteParent != null)
				{
					CListeObjetsDonnees liste_relations = site.SiteParent.TypeSite.RelationTypesContenus;
					string strNom = site.TypeSite.Libelle;
					string strParent = site.SiteParent.Libelle;
					string strSiteParent = site.SiteParent.TypeSite.Libelle;

					foreach (CRelationTypeSite_TypeSite rel in liste_relations)
						strNom += " , " + rel.TypeSiteContenu.Libelle;

					liste_relations.Filtre = new CFiltreData(CRelationTypeSite_TypeSite.c_champTypeContenuId + " = @1", site.TypeSite.Id);
					if (liste_relations.CountNoLoad == 0)
						result.EmpileErreur(I.T( "The site type is not valid|107"));
				}

                // Vérifie le Code Site, peut ÃƒÂªtre vide ou unique
                if (site.Code != "")
                {
					if (!CObjetDonneeAIdNumerique.IsUnique(site, CSite.c_champCode, site.Code))
                    {
                        result.EmpileErreur(I.T("The Site Code '@1' already exist|371", site.Code));
                    }
				}

				if (result)
					result = SObjetAFilsACoordonneeServeur.VerifieDonnees(site);

				if (result)
					result = site.VerifieCoordonnee();				

			}
			catch ( Exception e )
			{
				result.EmpileErreur( new CErreurException ( e ) );
			}
            
			return result;
		}

		public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
		{
			CResultAErreur result = base.TraitementAvantSauvegarde(contexte);
			if (!result)
				return result;

			DataTable dt = contexte.Tables[CSite.c_nomTable];
			ArrayList rows = new ArrayList(dt.Rows);
			foreach(DataRow row in rows)
			{
				CSite site = new CSite ( row );
				result = SObjetAFilsACoordonneeServeur.TraitementAvantSauvegarde(site);


				//Verification des Eos pour la localisation par coordonnee
				if (row.RowState != DataRowState.Deleted &&  site.TypeSite != null && row.RowState == DataRowState.Modified)
				{
					CTypeEntiteOrganisationnelle typeEO = site.TypeSite.TypeEntiteOrganisationnelleDeCoordonnee;

					if(typeEO != null && site.EOdeCoordonnee == null)
					{
						List<CEntiteOrganisationnelle> lsteos = CUtilElementAEO.GetToutesEOs(site);
						List<CEntiteOrganisationnelle> lsteosRacine = new List<CEntiteOrganisationnelle>();
						List<CEntiteOrganisationnelle> lsteosFilles = new List<CEntiteOrganisationnelle>();

						//Recuperation des EOs du niveau Racine
						foreach (CEntiteOrganisationnelle eo in lsteos)
							if(eo.TypeEntite == typeEO)
								lsteosRacine.Add(eo);

						foreach(CEntiteOrganisationnelle eo in lsteos)
							if(eo.TypeEntite != typeEO)
								foreach(CEntiteOrganisationnelle eoracine in lsteosRacine)
									if(eo.IsChildOf(eoracine))
										lsteosFilles.Add(eo);


						int totalPoss = lsteosRacine.Count + lsteosFilles.Count;

						if (totalPoss > 1)
							result.EmpileErreur(I.T("Several organisational entities can affect this site coordinate : please select the default one|30001"));
						else if (totalPoss == 1 && lsteosRacine.Count == 1)
							site.EOdeCoordonnee = lsteosRacine[0];
						else if(totalPoss == 1 && lsteosFilles.Count == 1)
							site.EOdeCoordonnee = lsteosFilles[0];


					}
				}



				if (!result)
					return result;
			}

			return result;
		}

		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
            return typeof(CSite);
		}
		//-------------------------------------------------------------------
    }
}
