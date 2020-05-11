using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

using timos.data;
using timos.acteurs;

namespace timos.data.serveur
{
	/// <summary>
	/// Description résumée de CInterventionServeur.
	/// </summary>
	public class CInterventionServeur : CObjetServeur
	{
		//-------------------------------------------------------------------
		public CInterventionServeur(int nIdSession)
			: base(nIdSession)
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable()
		{
			return CIntervention.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees(CObjetDonnee objet)
		{
			CResultAErreur result = CResultAErreur.True;

			try
			{
				CIntervention inter = (CIntervention)objet;

				if (inter.Site == null)
					result.EmpileErreur(I.T("The intervention must be associated to a Site|388"));

				if (inter.TypeIntervention == null)
					result.EmpileErreur(I.T( "The Intervention type cannot be null|152"));

				if (inter.Fractions.Count == 0)
				{
					//Pas de fractions, il faut au moins un préplanifieur
					if (inter.DateDebutPrePlanifiee == null ||
						 inter.DateFinPrePlanifiee == null)
					{
						if (inter.UserPreplanifieur == null)
						{
							result.EmpileErreur(I.T( "The person in charge of preplanning must be defined|209"));
						}
					}
					else
					{
						if (inter.UserPlanifieur == null)
						{
							result.EmpileErreur(I.T( "The person in charge of planning must be definde|210"));
						}
					}
				}

				if (inter.UserPlanifieur != null)
				{
					if (inter.TypeIntervention != null && inter.TypeIntervention.ProfilPlanifieur != null)
					{
						if (!inter.TypeIntervention.ProfilPlanifieur.IsInProfil(inter.UserPlanifieur, inter))
						{
							result.EmpileErreur(I.T( "The user @1 cannot be a planner|211"), inter.UserPlanifieur.Acteur.IdentiteComplete);
						}
					}
				}
				if (inter.UserPreplanifieur != null)
				{
					if (inter.TypeIntervention != null && inter.TypeIntervention.ProfilPreplanifieur != null)
					{
						if (!inter.TypeIntervention.ProfilPreplanifieur.IsInProfil(inter.UserPreplanifieur, inter))
						{
							result.EmpileErreur(I.T( "The user @1 cannot be a preplanner|212"), inter.UserPreplanifieur.Acteur.IdentiteComplete);
						}
					}
				}

                
                // Vérifie le doublons des Opérations prévisionnelles: mÃƒÂªme type d'opération et mÃƒÂªme équipement
                CListeObjetsDonnees listOpe = inter.Operations;
                listOpe.Filtre = new CFiltreData(CEquipement.c_champId + " is not null");
                ArrayList listeAVerifier = listOpe.ToArrayList();

                
               /* foreach (COperation ope1 in listeAVerifier)
                {
                    foreach (COperation ope2 in listeAVerifier)
                    {
                        if (ope1.Id != ope2.Id &&
                            ope1.TypeOperation.Id == ope2.TypeOperation.Id &&
                            ope1.Equipement.Id == ope2.Equipement.Id)
                        {
							result.EmpileErreur(I.T( "There are tow '@1' Operations on equipment '@2'|363", ope1.TypeOperation.Libelle, ope1.Equipement.Libelle));
                        }
                    }
                }*/

                
			}
			catch (Exception e)
			{
				result.EmpileErreur(new CErreurException(e));
			}

			return result;
		}

		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CIntervention);
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
			ArrayList lstRows = new ArrayList(table.Rows);
			foreach (DataRow row in lstRows)
			{
				CIntervention intervention = new CIntervention(row);
				if (intervention.Row.RowState != DataRowState.Deleted)
				{
					if (intervention.EtatInt <= (int) EtatIntervention.Planifiee)
                    {
                        if (intervention.Fractions.Count > 0)
                            intervention.EtatInt = (int)EtatIntervention.Planifiee;
                        else if (intervention.DateDebutPrePlanifiee != null && intervention.DateFinPrePlanifiee != null)
                            intervention.EtatInt = (int)EtatIntervention.Preplanifiee;
                        else
                            intervention.EtatInt = (int)EtatIntervention.NonPlanifiee;
                    }
				}
                if (intervention.Row.RowState == DataRowState.Added || intervention.Row.RowState == DataRowState.Modified)
                    intervention.RecalcProfilsIntervenantsInCurrentContext(true);

			}
			return result;
		}


	}
}
