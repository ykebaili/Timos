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
	/// Description résumée de COrigineTicketServeur.
	/// </summary>
	public class COrigineTicketServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
#if PDA
		public COrigineTicketServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public COrigineTicketServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return COrigineTicket.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				COrigineTicket origine = (COrigineTicket)objet;

				if ( origine.Libelle == "")
					result.EmpileErreur(I.T( "The Ticket Origin Label cannot be empty|198"));
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
			return typeof(COrigineTicket);
		}
		//-------------------------------------------------------------------
	}
}
