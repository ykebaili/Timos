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
	/// Description résumée de CRelationTicket_EOconcerneesServeur.
	/// </summary>
	public class CRelationTicket_EOconcerneesServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
#if PDA
		public CRelationTicket_EOconcerneesServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTicket_EOconcerneesServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationTicket_EOconcernees.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CRelationTicket_EOconcernees rel = (CRelationTicket_EOconcernees)objet;

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
			return typeof(CRelationTicket_EOconcernees);
		}
		//-------------------------------------------------------------------
	}
}
