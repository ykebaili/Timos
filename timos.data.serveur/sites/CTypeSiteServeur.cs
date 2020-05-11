using System;
using System.Collections;
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
    /// Description rÃ©sumÃ©e 
    /// </summary>
    public class CTypeSiteServeur : CObjetDonneeServeurAvecCache
    {
        //-------------------------------------------------------------------
        public CTypeSiteServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CTypeSite.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			
            try
			{
                CTypeSite type_site = (CTypeSite)objet;

                // Verifie le champ "Libelle"
                if (type_site.Libelle == "")
					result.EmpileErreur(I.T("Site Type label cannot be empty|368"));

                // Si le parent est obligatoire, il faut dÃ©finir les Parent possibles
                if (type_site.ParentObligatoire)
                {
                    if(type_site.RelationTypesContenants.Count == 0)
                        result.EmpileErreur(I.T("Site Type must have one or more relation with a contained type (Can be included)|369"));
                }


				//Verifier si le TypEntiteOrganisationnelleDeCoordonnee
				//a Ã©tÃ© modifiÃ© qu'il n'y a pas de site utilisant...
				if(type_site.Row.HasVersion(DataRowVersion.Original))
				{
					
				    CTypeEntiteOrganisationnelle newval = type_site.TypeEntiteOrganisationnelleDeCoordonnee;
				    type_site.VersionToReturn = DataRowVersion.Original;
					CTypeEntiteOrganisationnelle oldval = type_site.TypeEntiteOrganisationnelleDeCoordonnee;
					if (newval != oldval)
					{
						//Dans les sites de ce types site
						//si il y en a un qui a EoCoor != null on bloque
						CFiltreData filtreSites = new CFiltreData(CTypeSite.c_champId +" = @1 AND " + CSite.c_champEOCoor + " is not null" , type_site.Id);
						CListeObjetsDonnees lstSites = new CListeObjetsDonnees(type_site.ContexteDonnee,typeof(CSite),filtreSites);
						if (lstSites.CountNoLoad > 0)
							result.EmpileErreur(I.T("One or more sites already use the Organisational Entity '@1' to define their coordinates : You cannot modify it|372",oldval.DescriptionElement));


					}

				}
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

			DataTable dt = contexte.Tables[CTypeSite.c_nomTable];
			ArrayList rows = new ArrayList(dt.Rows);
			foreach (DataRow dr in rows)
			{
				if (dr.RowState == DataRowState.Modified || dr.RowState == DataRowState.Added)
				{
					CTypeSite type_site = new CTypeSite(dr);

					//result = SDefinisseurSystemeCoordonnees.VerifieDonnees(type_site);
					if (!result.Result)
						break;
				}
			}

			return result;
		}
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
            return typeof(CTypeSite);
		}
		//-------------------------------------------------------------------
    }
}
