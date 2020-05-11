using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

namespace sc2i.workflow
{
	/// <summary>
	/// Description résumée de CCalendrier_JourParticulierServeur.
	/// </summary>
	public class CCalendrier_JourParticulierServeur : CObjetServeur
	{
#if PDA
		public CCalendrier_JourParticulierServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CCalendrier_JourParticulierServeur( int nIdSession )
			:base(nIdSession)
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CCalendrier_JourParticulier.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CCalendrier_JourParticulier jourParticulier = (CCalendrier_JourParticulier)objet;

                // Vérificaton de la cohérence des tranches horaires
                // Pas de recouvrement entre les tranches
                foreach (CHoraireJournalier_Tranche tranche1 in jourParticulier.TranchesHorairesListe)
                {
                    foreach (CHoraireJournalier_Tranche tranche2 in jourParticulier.TranchesHorairesListe)
                    {
                        if (tranche1 != tranche2)
                        {
                            if (tranche2.HeureDebut <= tranche1.HeureDebut &&
                                tranche2.Durée > (tranche1.HeureDebut - tranche2.HeureDebut))
                                result.EmpileErreur(I.T( "Two time slots are overlapping|165"));
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
			return typeof(CCalendrier_JourParticulier);
		}
		//-------------------------------------------------------------------
	}
}
