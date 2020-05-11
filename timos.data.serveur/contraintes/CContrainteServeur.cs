using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

using timos.data;
using timos.securite;

namespace timos.data.serveur
{
    /// <summary>
    /// Description résumée de CContrainteServeur.
    /// </summary>
	public class CContrainteServeur : CObjetDonneeServeurAvecCache, IContrainteServeur
    {
        //-------------------------------------------------------------------
        public CContrainteServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CContrainte.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			
            try
			{
                CContrainte contrainte = (CContrainte)objet;

                // Verifie le champ "Libelle"
                if (contrainte.Libelle == "")
					result.EmpileErreur(I.T( "The Label cannot be empty|126"));
                
                //Vérifie que le Type est bien renseigné
                if (contrainte.TypeContrainte == null)
                    result.EmpileErreur(I.T( "The Constraint Type must be defined|290"));

                //Vérifie que la Contrainte est associée à un Site ou un Equipement
                if(contrainte.Emplacement == null)
                    result.EmpileErreur(I.T( "The Constraint must be associated to an emplacement|291"));

                // La contrainte doit respecter les options de son Type de contrainte
                if (contrainte.TypeContrainte.OptionAuMoinsUnAttributListe)
                {
                    int compteur = 0;
                    foreach (CAttributContrainte attrib in contrainte.AttributsListe)
                    {
                        if (attrib.AttributTypeContrainte != null) compteur++;
                    }
                    if (compteur < 1)
                        result.EmpileErreur(I.T( "This Constraint must have at least one atribute of its Type|157"));
                }
                if (contrainte.TypeContrainte.OptionAuPlusUnAttributListe)
                {
                    int compteur = 0;
                    foreach (CAttributContrainte attrib in contrainte.AttributsListe)
                    {
                        if (attrib.AttributTypeContrainte != null) compteur++;
                    }
                    if (compteur > 1)
                        result.EmpileErreur(I.T( "This Constraint must have at the maximum one attribute of its Type|158"));
                }


			}
			catch ( Exception e )
			{
				result.EmpileErreur( new CErreurException ( e ) );
			}
            
			return result;
		}

		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
            return typeof(CContrainte);
		}
		
        //-------------------------------------------------------------------
        public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
        {
            CResultAErreur result = CResultAErreur.True;
            
            result = base.TraitementAvantSauvegarde(contexte);
            if (!result) return result;

            // Interdit le changement de type de contrainte s'il y a des clés associées
  			DataTable table = contexte.Tables[GetNomTable()];
			ArrayList lst = new ArrayList(table.Rows );
			foreach ( DataRow row in lst )
            {
                if(row.RowState == DataRowState.Modified)
                {
                    
                    CContrainte contrainte = new CContrainte(row);
                    // Sauvegarde de la version du DataRow
                    DataRowVersion oldVer = contrainte.VersionToReturn;
                    // Type de contrainte après modif
                    CTypeContrainte modifTypeCont = contrainte.TypeContrainte;

                    // Changement de version
                    contrainte.VersionToReturn = DataRowVersion.Original;
                    // Type de contrainte avant modif
                    CTypeContrainte originTypeCont = contrainte.TypeContrainte;
                    // Retour à la version du DataRow
                    contrainte.VersionToReturn = oldVer;

                    if(modifTypeCont != originTypeCont && contrainte.RelationRessourceListe.Count != 0)
                    {
                        result.EmpileErreur(I.T(
                            "The Constraint Type cannot be modified when there are resources are associated with it|128"));
                    }
                 }
            }
            return result;
        }

		//------------------------------------------------------------------------
		public int[] GetIdsRessourcesLevant(int nIdContrainte, CFiltreDataAvance filtreParam)
		{
			Hashtable tblIdsRessourcesLevant = new Hashtable();
			using (CContexteDonnee contexteDonnee = new CContexteDonnee(IdSession, true, false))
			{
				CContrainte contrainte = new CContrainte(contexteDonnee);
				if (!contrainte.ReadIfExists(nIdContrainte))
					throw new Exception(I.T( "Constraint Id @1 doesn't exist|197", nIdContrainte.ToString()));


				// Liste des ressources levants de façon explicite (Relation directe)
				CListeObjetsDonnees listeRelationRessourceFiltre = contrainte.RelationRessourceListe;

				// Applique un filtre prédéfini par l'utilisateur de cette fonction
                CFiltreDataAvance filtreTmp = null;
                if (filtreParam != null)
                {
                    filtreTmp = (CFiltreDataAvance)filtreParam.GetClone();
                    filtreTmp.ChangeTableDeBase(CRelationContrainte_Ressource.c_nomTable, CRessourceMaterielle.c_nomTable);
                    listeRelationRessourceFiltre.Filtre = filtreTmp;
                }
				foreach (CRelationContrainte_Ressource rel in listeRelationRessourceFiltre)
					tblIdsRessourcesLevant[rel.Ressource.Id] = true;

				if (contrainte.TypeContrainte != null)
				{
                    // Construit une filtre avancé sur les attributs de la contrainte
                    CFiltreData filtreAttributsRessources = contrainte.GetFiltreForRechercheRessourcesSurAttributs();

					// Liste de toutes les resssources de la base
					CListeObjetsDonnees lstRessources = new CListeObjetsDonnees(contexteDonnee, typeof(CRessourceMaterielle));
					// Applique le filtre d'attributs à la liste
					filtreAttributsRessources = CFiltreData.GetAndFiltre(filtreAttributsRessources, filtreParam);
					lstRessources.Filtre = filtreAttributsRessources;
					// On obtient la liste des ressource ayant au moins un attribut en commun avec la Contrainte

					// Vérifie le résultat de la recherche en fonction des options
					// Si la ressource doit avoir au moins un des attributs de la contrainte
					//Toutes les ressources trouvées sont bonnes !
					if (!contrainte.TypeContrainte.OptionTousAttributsRessourceLevant)
					{
						foreach (CRessourceMaterielle res in lstRessources)
							tblIdsRessourcesLevant[res.Id] = true;
					}
					else
					{
                        CResultAErreur result = lstRessources.ReadDependances("AttributsListe");
                        if (!result)
                            throw new CExceptionErreur(result.Erreur);
                        
                        // Sinon la ressource doit avoir tous les attributs de la contrainte
                        CFiltreData filtreTousLesAttributs = contrainte.GetFiltreSurAttributsRessource();

						// Recherche dans la liste des resources possibles
						foreach (CRessourceMaterielle res in lstRessources)
						{
							CListeObjetsDonnees attributsRessource = res.AttributsListe;
							attributsRessource.InterditLectureInDB = true;
							attributsRessource.Filtre = filtreTousLesAttributs;

							string strRessource = res.Libelle;
							int nNbAttribs = attributsRessource.Count;
							nNbAttribs = contrainte.AttributsListe.Count;

							// La ressource doit avoir tous les attributs de la contrainte
							if (attributsRessource.Count == contrainte.AttributsListe.Count)
								tblIdsRessourcesLevant[res.Id] = true;
						}
					}
				}

				List<int> lstRetour = new List<int>();
				foreach (int nId in tblIdsRessourcesLevant.Keys)
					lstRetour.Add(nId);
				return lstRetour.ToArray();
			}
		}




    }
}
