using System;
using System.Collections;
using System.Data;


using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.data;
using timos.securite;

namespace timos.data.serveur
{
	/// <summary>
	/// Description résumée de CEntiteOrganisationnelleServeur.
	/// </summary>
	public class CEntiteOrganisationnelleServeur : CObjetHierarchiqueServeur
	{
		//-------------------------------------------------------------------
#if PDA
		public CEntiteOrganisationnelleServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CEntiteOrganisationnelleServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CEntiteOrganisationnelle.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CEntiteOrganisationnelle entiteOrganisationnelle = (CEntiteOrganisationnelle)objet;

				if ( entiteOrganisationnelle.Libelle == "")
					result.EmpileErreur(I.T("Organisational Entity label cannot be empty|10007"));
                
                //Vérifie l'unicité du EntiteOrganisationnelle dans son parent
                if ( entiteOrganisationnelle.EntiteParente != null )
                {
                    CListeObjetsDonnees liste = new CListeObjetsDonnees(objet.ContexteDonnee, typeof(CEntiteOrganisationnelle));
                    liste.Filtre = new CFiltreData(CEntiteOrganisationnelle.c_champIdParent + "=@1 and " +
                        CEntiteOrganisationnelle.c_champLibelle + "=@2 and " +
                        CEntiteOrganisationnelle.c_champId + "<>@3",
						entiteOrganisationnelle.EntiteParente.Id,
                        entiteOrganisationnelle.Libelle,
                        entiteOrganisationnelle.Id);
                    if (liste.CountNoLoad > 0)
						result.EmpileErreur(I.T("Organisational Entity '@1' already exists|10008",entiteOrganisationnelle.Libelle));
                }
                else //c'est une racine, on ne veut qu'une racine par type d'entité organisationnelle
                {
                    CListeObjetsDonnees liste = new CListeObjetsDonnees(objet.ContexteDonnee, typeof(CEntiteOrganisationnelle));
                    liste.Filtre = new CFiltreData(
                        CEntiteOrganisationnelle.c_champId + "<>@1 and "+
                        CTypeEntiteOrganisationnelle.c_champId+"=@2",
                        entiteOrganisationnelle.Id,
                        entiteOrganisationnelle.TypeEntite.Id);
                    if (liste.CountNoLoad > 0)
                        result.EmpileErreur(I.T("The Organisational Entity Type '@1' has already a root element|290",entiteOrganisationnelle.TypeEntite.Libelle));
                }

				//Verification de la coordonnée
				//result = CEntiteOrganisationnelle.VerifierCoor(EntiteOrganisationnelle);


				if (entiteOrganisationnelle.TypeEntite == null)
					result.EmpileErreur(I.T( "The Organisational Entity must be associated to a Type|101"));

				else if ( entiteOrganisationnelle.Niveau != entiteOrganisationnelle.TypeEntite.Niveau )
					result.EmpileErreur(I.T( "The type of the entity is not coherent with the related entity|102"));
				else if (entiteOrganisationnelle.EntiteParente != null &&
			   entiteOrganisationnelle.EntiteParente.TypeEntite != null &&
			   entiteOrganisationnelle.EntiteParente.TypeEntite.TypeFils != entiteOrganisationnelle.TypeEntite)
				{
					result.EmpileErreur(I.T( "The type of the Entity is not coherent with the related entity|102"));
				}

				string strLib = entiteOrganisationnelle.Libelle;


				/*if (result)//Pas besoin, car l'eo n'a pas son propre système de coordonnées, c'est son type qui peut le modifier
					result = SObjetAFilsACoordonneeServeur.VerifieDonnees(entiteOrganisationnelle);*/

				if (result)
					result = entiteOrganisationnelle.VerifieCoordonnee();
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
			return typeof(CEntiteOrganisationnelle);
		}

		//------------------------------------------------------------------- 
		public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
		{
			CResultAErreur result = base.TraitementAvantSauvegarde(contexte);
			if (!result)
				return result;
			DataTable table = contexte.Tables[GetNomTable()];
			if (table == null)
				return result;
			ArrayList lst = new ArrayList(table.Rows);
			foreach (DataRow row in lst)
			{
				if (row.RowState == DataRowState.Modified || row.RowState == DataRowState.Added)
				{
					CEntiteOrganisationnelle entite = new CEntiteOrganisationnelle(row);
					result = VerifieDonnees(entite);
					if (!result)
						return result;
				}
			}
			return result;
		}
		
	}
}
