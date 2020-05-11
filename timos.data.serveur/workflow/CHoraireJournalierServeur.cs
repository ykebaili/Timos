using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;

namespace sc2i.workflow
{
	/// <summary>
	/// Description résumée de CHoraireJournalierServeur.
	/// </summary>
	public class CHoraireJournalierServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
#if PDA
		public CCiviliteServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CHoraireJournalierServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CHoraireJournalier.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CHoraireJournalier horaireJ = (CHoraireJournalier)objet;
                // Le Libelle ne doit pas être vide
                if (horaireJ.Libelle == "")
					result.EmpileErreur(I.T( "The Label cannot be empty|126"));

                // Vérificaton de la cohérence des tranches horaires
                // Pas de recouvrement entre les tranches
                foreach (CHoraireJournalier_Tranche tranche1 in horaireJ.TranchesHorairesListe)
                {
                    foreach (CHoraireJournalier_Tranche tranche2 in horaireJ.TranchesHorairesListe)
                    {
                        if (tranche1 != tranche2)
                        {
                            if (tranche2.HeureDebut <= tranche1.HeureDebut &&
                                tranche2.Durée > (tranche1.HeureDebut - tranche2.HeureDebut))
                                result.EmpileErreur(I.T( "Two time slots are overlappling|165"));
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
			return typeof(CHoraireJournalier);
		}
		//-------------------------------------------------------------------
	}
}
