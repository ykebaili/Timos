using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;

using timos.data;

namespace timos.data.serveur
{
	/// <summary>
	/// Description résumée de CContrat_ListeOperationsServeur.
	/// </summary>
	public class CContrat_ListeOperationsServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
#if PDA
		public CContrat_ListeOperationsServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CContrat_ListeOperationsServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CContrat_ListeOperations.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CContrat_ListeOperations rel = (CContrat_ListeOperations)objet;

                if (rel.Contrat == null)
                    result.EmpileErreur(I.T( "The relation must have a Contract|359"));
                if (rel.Contrat == null)
                    result.EmpileErreur(I.T( "The relation must have an Operatons List|360"));

				if(rel.TypeIntervention == null)
					result.EmpileErreur(I.T("The Intervention type cannot be null|152"));

                int comptErr = 0;
                // Vérifier que la liste des sites pour la liste d'Opération est incluse dans la liste des Sites du contrat
                if (rel.Contrat != null)
                {
                    ArrayList listeSitesContrat = new ArrayList();
                    foreach (CSite site in rel.Contrat.GetTousLesSitesDuContrat())
                        listeSitesContrat.Add(site);
                    ArrayList listeSites = new ArrayList(rel.GetTousLesSitesAssocies());
                    foreach (CSite site in listeSites)
                        if (!listeSitesContrat.Contains(site))
                            comptErr++;
                }
				if(rel.DateDebut > rel.DateLimite || rel.DateDebutEditeur > rel.DateLimiteEditeur)
					result.EmpileErreur(I.T("The start date cannot be lower than the end date|408"));

                if (comptErr > 0)
                {
                    result.EmpileErreur(I.T( "There are @1 site(s) from operations list '@2' not included in the Contract Site list|358", comptErr.ToString(), rel.ListeOperations.Libelle));
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
			return typeof(CContrat_ListeOperations);
		}
		//-------------------------------------------------------------------
	}
}
