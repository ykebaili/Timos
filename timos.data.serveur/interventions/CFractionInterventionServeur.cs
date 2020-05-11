using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using sc2i.data;
using sc2i.data.dynamic;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.expression;

using timos.data;
using timos.acteurs;

namespace timos.data.serveur
{
    /// <summary>
    /// Description résumée de CFractionInterventionServeur.
    /// </summary>
    public class CFractionInterventionServeur : CObjetServeur
    {
        //-------------------------------------------------------------------
        public CFractionInterventionServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CFractionIntervention.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			
            try
			{
                CFractionIntervention fraction = (CFractionIntervention)objet;

                if (fraction.DateDebut != null && fraction.DateFin != null)
                {
                    if (fraction.DateFin < fraction.DateDebut)
                        result.EmpileErreur(I.T("The end date must be greater than the start date|416"));
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
            return typeof(CFractionIntervention);
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
					CFractionIntervention fraction = new CFractionIntervention(row);
					if (fraction.DateDebut == null &&
						fraction.EtatInt > (int)EtatFractionIntervention.AFaire)
					{
						result.EmpileErreur(I.T("The start date of the Intervention Part must be defined|208"));
						return result;
					}

					if ( fraction.DateDebut != null && 
						fraction.DateFin != null &&
						fraction.Intervention.TypeIntervention.TypeActiviteActeur != null )
					{

						result = ImputeDureeSurActivite ( fraction );
						if ( !result )
							return result;
					}
				}
                
			}
			return result;
		}

        




		private CResultAErreur ImputeDureeSurActivite(CFractionIntervention fraction)
		{
			CResultAErreur result = CResultAErreur.True;
			if (fraction.DateDebut == null ||
				fraction.DateFin == null)
				return result;
			if (fraction.TempsDeTravail == null)
				return result;
			Hashtable tableToDelete = new Hashtable();
			//Stocke la liste des relations qui étaient présentes avant le travail
			//et les note comme étant à supprimer
			foreach (CIntervention_ActiviteActeur rel in fraction.RelationsActivite)
			{
				tableToDelete[rel] = true;
			}
			CTypeActiviteActeur typeActivite = fraction.Intervention.TypeIntervention.TypeActiviteActeur;
			bool bAvecSite = typeActivite.SiteObligatoire;
			if (typeActivite != null)
			{
				//Evalue les valeurs des champs custom pour l'activite
				CParametreRemplissageActiviteParIntervention parametreRemplissage = fraction.Intervention.TypeIntervention.ParametreRemplissageActivite;
				Dictionary<CChampCustom, object> valeursChamps = new Dictionary<CChampCustom, object>();
				CContexteEvaluationExpression ctxEval = new CContexteEvaluationExpression(fraction);
				if (parametreRemplissage != null)
				{
					foreach (CRemplisssageChampActiviteActeur remplissage in parametreRemplissage.ListeRemplissage)
					{
						CChampCustom champ = new CChampCustom(fraction.ContexteDonnee);

						if (champ.ReadIfExists(remplissage.IdChampCustom))
						{
							C2iExpression formule = remplissage.Formule;
							if (formule != null)
							{
								result = formule.Eval(ctxEval);
								if (result)
									valeursChamps[champ] = result.Data;
							}
						}
					}
				}

				foreach (CIntervention_Intervenant relIntervenant in fraction.Intervention.RelationsIntervenants)
				{
					DateTime dt = ((DateTime)fraction.DateDebut).Date;

					//Attention, si on est sur une fraction sur plusieurs jours, le 
					//pb est que la durée saisie (retenue pour l'intervention) peut
					//ne pas être égale aux différents jours d'imputation,
					//on réparti donc la durée de manière homogène sur les différents
					//Jour en faisant un prorata de chaque jour
					double fDureeAImputer = (double)fraction.TempsDeTravail;
					double fDureeReelle = (double)fraction.DureeReelle;


					while (dt < (DateTime)fraction.DateFin && fDureeAImputer > 0)
					{

						//Cherche pour l'intervention ses activités du bon type
						CFiltreData filtre = new CFiltreDataAvance(CActiviteActeur.c_nomTable,
							CTypeActiviteActeur.c_champId + "=@1 and " +
							CActiviteActeur.c_champDate + ">=@2 and " +
							CActiviteActeur.c_champDate + "<@3 and " +
							"Has(" + CIntervention_ActiviteActeur.c_nomTable + "." +
							CIntervention_ActiviteActeur.c_champId + ") and " +
							CActeur.c_champId + "=@4",
							typeActivite.Id,
							dt,
							dt.AddDays(1),
							relIntervenant.Intervenant.Id);
						if (bAvecSite)
							filtre = CFiltreData.GetAndFiltre(filtre,
								new CFiltreData(CSite.c_champId + "=@1",
								fraction.Intervention.Site.Id));
						CListeObjetsDonnees listeActivites = new CListeObjetsDonnees(fraction.ContexteDonnee, typeof(CActiviteActeur));
						listeActivites.Filtre = filtre;
						listeActivites.ReadDependances("RelationsInterventions");
						CActiviteActeur activiteRetenue = null;
						CIntervention_ActiviteActeur relRetenue = null;
						foreach (CActiviteActeur activite in listeActivites)
						{
							bool bPrendre = true;
							foreach (KeyValuePair<CChampCustom, object> chpValeur in valeursChamps)
							{
								object valDeAct = activite.GetValeurChamp(chpValeur.Key.Id);
								if (valDeAct == null && chpValeur.Value != null)
								{
									bPrendre = false;
									break;
								}
								else if (chpValeur.Value == null && valDeAct != null)
								{
									bPrendre = false;
									break;
								}
								else if (chpValeur.Value != null && !chpValeur.Value.Equals(valDeAct))
								{
									bPrendre = false;
									break;
								}
							}
							if (bPrendre)
							{
								activiteRetenue = activite;
								relRetenue = null;
								foreach (CIntervention_ActiviteActeur relInter in activiteRetenue.RelationsInterventions)
								{
									//Si l'activité est directement liée à cette fraction, prend celle ci de préférence
									if (relInter.FractionIntervention.Id == fraction.Id)
									{
										relRetenue = relInter;
										break;
									}
								}
							}
						}
						if (activiteRetenue == null)
						{
							//Création de l'activite
							activiteRetenue = new CActiviteActeur(fraction.ContexteDonnee);
							activiteRetenue.CreateNewInCurrentContexte();
							activiteRetenue.TypeActiviteActeur = typeActivite;
							activiteRetenue.Acteur = relIntervenant.Intervenant;
							activiteRetenue.Date = dt;
							activiteRetenue.Duree = 0;
							if (bAvecSite)
								activiteRetenue.Site = fraction.Intervention.Site;
							foreach (KeyValuePair<CChampCustom, object> valChamp in valeursChamps)
								activiteRetenue.SetValeurChamp(valChamp.Key.Id, valChamp.Value);
						}
						if (relRetenue == null)
						{
							//Création de la relation à l'interventation
							relRetenue = new CIntervention_ActiviteActeur(fraction.ContexteDonnee);
							relRetenue.ActiviteActeur = activiteRetenue;
							relRetenue.DureeImputee = 0;
							relRetenue.FractionIntervention = fraction;
						}

						//Note que cette relation ne doit pas être supprimée
						tableToDelete[relRetenue] = false;

						double fDureeForThis = 0;
						if (dt == fraction.DateFin.Value.Date)
							fDureeForThis = fDureeAImputer;//On affecte le reste
						else
						{
							if (dt == fraction.DateDebut.Value.Date)
							{
								//On est sur le premier jour,
								//Utilise comme référence le temps qui sépare la date
								//de début de minuit
								TimeSpan sp = dt.AddDays(1) - fraction.DateDebut.Value;
								double fRatio = sp.TotalHours / fDureeReelle;
								fDureeForThis = fRatio * fraction.TempsDeTravail.Value;

							}
							else
							{
								fDureeForThis = 24.0 / fDureeReelle * fraction.TempsDeTravail.Value;
							}
							//Arrondi la durée calculé à la minute
							fDureeForThis = (int)fDureeForThis + (int)((fDureeForThis - (int)fDureeForThis) * 60.0 + .5) / 60.0;
						}
						fDureeAImputer -= fDureeForThis;

						if (relRetenue.DureeImputee != fDureeForThis)
						{
							//Impute la durée de la fraction sur l'activité
							relRetenue.ActiviteActeur.Duree -= relRetenue.DureeImputee;
							relRetenue.DureeImputee = (double)fDureeForThis;
							relRetenue.ActiviteActeur.Duree += fDureeForThis;
						}
						dt = dt.AddDays(1);
					}
					
				}

			}
			foreach ( DictionaryEntry entry in tableToDelete )
			{
				if ( (bool)entry.Value )
				{
					//Supprime la relation
					CIntervention_ActiviteActeur relToDelete = (CIntervention_ActiviteActeur)entry.Key;
					if ( relToDelete.Row.RowState != DataRowState.Deleted )
					{
						CActiviteActeur activiteAncienne = relToDelete.ActiviteActeur;
                        //SC 10/3/2014 : La désimputation du temps de l'activité se fait dans CIntervention_activiteActeurServeur.TraitementAvantSauvegardee
						//activiteAncienne.Duree -= relToDelete.DureeImputee;
						result = relToDelete.Delete(true);
						/*if ( result && activiteAncienne.Duree == 0 )
							result = activiteAncienne.Delete();
						if ( !result )
							return result;*/
					}
				}
			}
			return result;
		}

		
    }
}
