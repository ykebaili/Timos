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
	/// Description résumée de CUrgenceTicketServeur.
	/// </summary>
	public class CUrgenceTicketServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
#if PDA
		public CUrgenceTicketServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CUrgenceTicketServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CUrgenceTicket.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CUrgenceTicket urgenceTicket = (CUrgenceTicket)objet;
                if(urgenceTicket.Libelle == "")
                    result.EmpileErreur(I.T( "The Ticket Urgency Label cannot be empty|202"));

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
			return typeof(CUrgenceTicket);
		}
		//-------------------------------------------------------------------
	}
}
