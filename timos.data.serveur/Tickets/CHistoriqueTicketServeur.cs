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
	/// Description résumée de CHistoriqueTicketServeur.
	/// </summary>
	public class CHistoriqueTicketServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
#if PDA
		public CHistoriqueTicketServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CHistoriqueTicketServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CHistoriqueTicket.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CHistoriqueTicket histotkt = (CHistoriqueTicket)objet;

				if (histotkt.Ticket == null)
					result.EmpileErreur(I.T("The history requires a ticket|227"));
                if(histotkt.ActeurUtilisateur == null)
                    result.EmpileErreur(I.T("The history requires a member in charge|228"));

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
			return typeof(CHistoriqueTicket);
		}
		//-------------------------------------------------------------------
	}
}
