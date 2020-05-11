using System;
using System.Collections;
using System.Data;


using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.multitiers.client;
using timos.acteurs;

namespace timos.acteurs.serveur
{
	/// <summary>
	/// Description rÃƒÆ’Ã‚Â©sumÃƒÆ’Ã‚Â©e de CGroupeActeurServeur.
	/// </summary>
	public class CGroupeActeurServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
#if PDA
		public CGroupeActeurServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CGroupeActeurServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CGroupeActeur.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur TraitementAvantSauvegarde ( CContexteDonnee contexte )
		{
			CResultAErreur result = CResultAErreur.True;
			DataTable table = contexte.Tables[GetNomTable()];
			ArrayList listeGroupesASynchroniser = new ArrayList();
			foreach (DataRow row in table.Rows)
			{
			}
			return result;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CGroupeActeur groupe = (CGroupeActeur)objet;

				if ( groupe.Nom == "")
					result.EmpileErreur(I.T("Member Group name cannot be empty|273"));

				if (!CObjetDonneeAIdNumerique.IsUnique(groupe, CGroupeActeur.c_champNom, groupe.Nom))
					result.EmpileErreur(I.T("Member Group name already exists|274"));

				if ( groupe.IdGroupeAd != "" )
					if (!CObjetDonneeAIdNumerique.IsUnique(groupe, CGroupeActeur.c_champGroupeWindowsCorrespondant, groupe.IdGroupeAd))
						result.EmpileErreur(I.T("Another Member Group is already associated with this AD Group|275"));

				int[] nIdsGroupesContenus = groupe.GetHierarchieGroupesContenus();
				int[] nIdsGroupeContenants = groupe.GetHierarchieGroupesContenants();
				foreach(int i in nIdsGroupeContenants)
				{
					foreach(int j in nIdsGroupesContenus)
					{
						if (i==j && i!=groupe.Id && j!=groupe.Id)
						{
							result.EmpileErreur(I.T("Incorrect Group hierarchy|276"));
						}
					}
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
			return typeof(CGroupeActeur);
		}

#if !PDA_DATA
		/// <summary>
		/// Force l'appartenance des groupes comme dÃƒÆ’Ã‚Â©finit dans la base AD
		/// </summary>
		/// <returns></returns>
		public CResultAErreur SynchroniseGroupesAD( )
		{
			CResultAErreur result = CResultAErreur.True;
			
			CAdGroup[] adGroups = CAdGroup.GetGroups(IdSession);
			using (CContexteDonnee contexte = new CContexteDonnee(IdSession, true, false))
			{
				contexte.BeginModeDeconnecte();
				CListeObjetsDonnees liste = new CListeObjetsDonnees ( contexte, typeof(CGroupeActeur));
				CFiltreData filtre = new CFiltreData ( CGroupeActeur.c_champGroupeWindowsCorrespondant+"<>@1", "");
				liste.Filtre = filtre;
				
				if ( result )
					contexte.CommitModifsDeconnecte();
			}
			return result;
		}

		

		protected bool CreateOrUpdateRelations ( CGroupeActeur groupe, CAdGroup adGroupe, Hashtable tableElementsASupprimer, Hashtable tableEmpecheRecursInf )
		{
			if ( tableEmpecheRecursInf[adGroupe.Id] != null )
				return false;
			tableEmpecheRecursInf[adGroupe.Id] = true;
			//Trouve le groupe correspondant au groupe AD
			CGroupeActeur groupeCorrespondant = CGroupeActeur.FromAd ( groupe.ContexteDonnee, adGroupe.Id );
			if ( groupeCorrespondant == null )
			{
				foreach (CAdGroup adParent in adGroupe.GroupesParents )
					if ( CreateOrUpdateRelations(groupe, adParent, tableElementsASupprimer, tableEmpecheRecursInf) )
						return true;
			}
			else
			{
				//Le groupe correspondant existe. Existe-t-il la relation ?
				CListeObjetsDonnees liste = groupe.RelationsGroupesContenantsDirects;
				liste.Filtre = new CFiltreData ( CRelationGroupeActeur_GroupeActeur.c_champIdGroupeContenant+"=@1", groupeCorrespondant.Id);
				if ( liste.Count == 1 )
				{
					CRelationGroupeActeur_GroupeActeur rel = (CRelationGroupeActeur_GroupeActeur)liste[0];
					tableElementsASupprimer.Remove(rel);//On ne supprime pas
				}
				else
				{
					//CrÃƒÆ’Ã‚Â©e la relation
					CRelationGroupeActeur_GroupeActeur rel = new CRelationGroupeActeur_GroupeActeur ( groupe.ContexteDonnee );
					rel.CreateNewInCurrentContexte();
					rel.GroupeContenant = groupeCorrespondant;
					rel.GroupeContenu = groupe;
				}
				return true;
			}
			return false;
		}
#endif

	}
}
