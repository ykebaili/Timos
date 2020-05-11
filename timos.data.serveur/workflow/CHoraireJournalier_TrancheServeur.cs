using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;

namespace sc2i.workflow
{
	/// <summary>
	/// Description résumée de CHoraireJournalier_TrancheServeur.
	/// </summary>
	public class CHoraireJournalier_TrancheServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
#if PDA
		public CCiviliteServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CHoraireJournalier_TrancheServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CHoraireJournalier_Tranche.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CHoraireJournalier_Tranche tranche = (CHoraireJournalier_Tranche)objet;

                // Une tranche horaire ne peut être de durée nulle
                if (tranche.HeureFin == tranche.HeureDebut)
                {
                    result.EmpileErreur(
                        I.T( "The time slot duration can not be null|164"));
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
			return typeof(CHoraireJournalier_Tranche);
		}
		//-------------------------------------------------------------------
        
	}
}
