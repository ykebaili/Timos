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
	/// Description résumée de CTypeTicketContrat_Site_PeriodeServeur.
	/// </summary>
	public class CTypeTicketContrat_Site_PeriodeServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
#if PDA
		public CTypeTicketDelegationsPossibleServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CTypeTicketContrat_Site_PeriodeServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CTypeTicketContrat_Site_Periode.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
                CTypeTicketContrat_Site_Periode periode = objet as CTypeTicketContrat_Site_Periode;
                result = periode.TypeTicketContrat_Site.VerifieCoherencesPeriodes();
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
			return typeof(CTypeTicketContrat_Site_Periode);
		}
		//-------------------------------------------------------------------
	}
}
