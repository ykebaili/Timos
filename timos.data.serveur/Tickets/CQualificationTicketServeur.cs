using System;
using System.Collections;
using System.Text;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

using timos.data;

namespace timos.data.serveur
{
    /// <summary>
	/// Description résumée de CQualificationTicketServeur.
    /// </summary>
    public class CQualificationTicketServeur : CObjetHierarchiqueServeur
    {
        //-------------------------------------------------------------------
		public CQualificationTicketServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CQualificationTicket.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			
            try
			{
				CQualificationTicket qualifappel = (CQualificationTicket)objet;

				if(qualifappel.Libelle == "")
					result.EmpileErreur(I.T( "The label cannot be empty|126"));

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
			return typeof(CQualificationTicket);
		}
		//-------------------------------------------------------------------
    }
}
