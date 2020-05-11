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
	/// Description résumée de CTypeTicketServeur.
	/// </summary>
	public class CTypeTicketServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
#if PDA
		public CTypeTicketServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CTypeTicketServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CTypeTicket.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CTypeTicket typeTicket = (CTypeTicket)objet;

                if (typeTicket.Libelle == "")
					result.EmpileErreur(I.T( "The Label cannot be empty|126"));
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
			return typeof(CTypeTicket);
		}
		//-------------------------------------------------------------------
	}
}
