using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

namespace sc2i.workflow
{
	/// <summary>
	/// Description résumée de CCalendrierServeur.
	/// </summary>
	public class CCalendrierServeur : CObjetServeur
	{
#if PDA
		public CCalendrierServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CCalendrierServeur( int nIdSession )
			:base(nIdSession)
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CCalendrier.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CCalendrier calendrier = (CCalendrier)objet;

				if ( calendrier.Libelle == "" )
					result.EmpileErreur(I.T("The label cannot be empty|126"));

                if (calendrier.HoraireParDefaut == null)
                    result.EmpileErreur(I.T("The default daily schedule must be defined|169"));
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
			return typeof(CCalendrier);
		}
		//-------------------------------------------------------------------
	}
}
