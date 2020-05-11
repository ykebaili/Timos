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
	/// Description résumée de CCauseGelServeur.
	/// </summary>
	/*public class CCauseGelServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
#if PDA
		public CCauseGelServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CCauseGelServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CCauseGel.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CCauseGel cause = (CCauseGel)objet;

				if ( cause.Libelle == "")
					result.EmpileErreur(I.T( "The label of the freezing cause cannot be empty|225"));
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
			return typeof(CCauseGel);
		}
		//-------------------------------------------------------------------
	}*/
}
