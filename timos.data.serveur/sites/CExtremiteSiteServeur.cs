using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.data;

namespace timos.data.serveur
{
	/// <summary>
	/// Description résumée de CExtremiteLienSurSiteServeur.
	/// </summary>
	public class CExtremiteLienSurSiteServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
#if PDA
		public CExtremiteLienSurSiteServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CExtremiteLienSurSiteServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CExtremiteLienSurSite.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CExtremiteLienSurSite ExtremiteSite = (CExtremiteLienSurSite)objet;

				if ( ExtremiteSite.Libelle == "")
					result.EmpileErreur(I.T("Link end label cannot be empty|20009"));
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
			return typeof(CExtremiteLienSurSite);
		}
		//-------------------------------------------------------------------
	}
}
