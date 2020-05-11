using System;
using System.Collections;
using System.Data;


using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.data;
using timos.securite;

namespace timos.securite.serveur
{
	/// <summary>
	/// Description résumée de CTypeEntiteOrganisationnelleServeur.
	/// </summary>
	public class CTypeEntiteOrganisationnelleServeur : CObjetHierarchiqueServeur
	{

		//-------------------------------------------------------------------
		public CTypeEntiteOrganisationnelleServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CTypeEntiteOrganisationnelle.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CTypeEntiteOrganisationnelle typeEntiteOrganisationnelle = (CTypeEntiteOrganisationnelle)objet;

				if ( typeEntiteOrganisationnelle.Libelle == "")
					result.EmpileErreur(I.T("Organisational Entity Type label cannot be empty|305"));

                
                //Vérifie l'unicité du TypeEntiteOrganisationnelle dans son parent
                if ( typeEntiteOrganisationnelle.TypeParent != null )
                {
                    CListeObjetsDonnees liste = new CListeObjetsDonnees(objet.ContexteDonnee, typeof(CTypeEntiteOrganisationnelle));
                    liste.Filtre = new CFiltreData(CTypeEntiteOrganisationnelle.c_champIdParent + "=@1 and " +
                        CTypeEntiteOrganisationnelle.c_champLibelle + "=@2 and " +
                        CTypeEntiteOrganisationnelle.c_champId + "<>@3",
						typeEntiteOrganisationnelle.TypeParent.Id,
                        typeEntiteOrganisationnelle.Libelle,
                        typeEntiteOrganisationnelle.Id);
                    if (liste.CountNoLoad > 0)
						result.EmpileErreur(I.T( "The Organisational Entity Type '@1' already exists|304", typeEntiteOrganisationnelle.Libelle));
                }
                else //Vérifie l'unicité du TypeEntiteOrganisationnelle 
                {
                    CListeObjetsDonnees liste = new CListeObjetsDonnees(objet.ContexteDonnee, typeof(CTypeEntiteOrganisationnelle));
                    liste.Filtre = new CFiltreData(
                        CTypeEntiteOrganisationnelle.c_champLibelle + "=@1 and " +
                        CTypeEntiteOrganisationnelle.c_champId + "<>@2 and "+
                        CTypeEntiteOrganisationnelle.c_champNiveau+"=@3",
                        typeEntiteOrganisationnelle.Libelle,
                        typeEntiteOrganisationnelle.Id,
                        0);
                    if (liste.CountNoLoad > 0)
                        result.EmpileErreur(I.T("The Organisational Entity Type '@1' already exists|304", typeEntiteOrganisationnelle.Libelle ));
                }

				//Vérifie que le parent n'a qu'un fils
				if (typeEntiteOrganisationnelle.TypeParent != null)
				{
					CListeObjetsDonnees listeFils = typeEntiteOrganisationnelle.TypeParent.TypesFils;
					foreach (CTypeEntiteOrganisationnelle tp in listeFils)
						if (!tp.Equals(typeEntiteOrganisationnelle))
							result.EmpileErreur(I.T("Impossible to assign two types of entities to the same parent|100"));
				}

				//Si on est en modification et que ce type d'entité
				//dispose d'entite > Verification d'un changement de format de numérotation
				//if (typeEntiteOrganisationnelle.Row.HasVersion(DataRowVersion.Original) && typeEntiteOrganisationnelle.HasEntitesOrganisationnelles())
				//{
				//    bool coorObligatoire = typeEntiteOrganisationnelle.CoordonneeObligatoire;
				//    CFormatNumerotation frmActuel = typeEntiteOrganisationnelle.FormatNumerotation;

				//    typeEntiteOrganisationnelle.VersionToReturn = DataRowVersion.Original;

				//    if(coorObligatoire && !typeEntiteOrganisationnelle.CoordonneeObligatoire)
				//        result.EmpileErreur(I.T( "Impossible de rendre les coordonnées obligatoires car des entitées sont déjà affiliées"));

				//    if (typeEntiteOrganisationnelle.FormatNumerotation != frmActuel)
				//        result.EmpileErreur(I.T( "Impossible de modifier le format de numérotation car des entitées sont déjà affiliées"));

				//}



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
			return typeof(CTypeEntiteOrganisationnelle);
		}

		//-------------------------------------------------------------------
		public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
		{
			CResultAErreur result = base.TraitementAvantSauvegarde(contexte);
			DataTable table = contexte.Tables[CTypeEntiteOrganisationnelle.c_nomTable];
			if (table == null)
				return result;
			ArrayList lst = new ArrayList(table.Rows);
			foreach (DataRow row in lst)
			{
				if (row.RowState == DataRowState.Modified || row.RowState == DataRowState.Added)
				{
					CTypeEntiteOrganisationnelle typeTest = new CTypeEntiteOrganisationnelle(row);
					if (typeTest.TypeParent != null)
					{
						CTypeEntiteOrganisationnelle typeParent = typeTest.TypeParent;
						foreach (CTypeEntiteOrganisationnelle typeFilsDeParent in typeParent.TypesFils)
							if (!typeFilsDeParent.Equals(typeTest))
								result.EmpileErreur(I.T( "Impossible to assign two types of entities to the same parent|100"));
					}
				}
			}
			return result;
		}
		
	}
}
