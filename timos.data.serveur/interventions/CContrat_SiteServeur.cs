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
	/// Description résumée de CContrat_SiteServeur.
	/// </summary>
	public class CContrat_SiteServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
#if PDA
		public CContrat_SiteServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CContrat_SiteServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CContrat_Site.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CContrat_Site rel = (CContrat_Site)objet;

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
			return typeof(CContrat_Site);
		}
		//-------------------------------------------------------------------
	}
}
