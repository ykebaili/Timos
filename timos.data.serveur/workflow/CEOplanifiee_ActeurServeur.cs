using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;
using sc2i.workflow;

using timos.data;

namespace sc2i.workflow.serveur
{
	/// <summary>
	/// Description résumée de CEOplanifiee_ActeurServeur.
	/// </summary>
	public class CEOplanifiee_ActeurServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
#if PDA
		public CEOplanifiee_ActeurServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CEOplanifiee_ActeurServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CEOplanifiee_Acteur.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CEOplanifiee_Acteur rel = (CEOplanifiee_Acteur)objet;

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
			return typeof(CEOplanifiee_Acteur);
		}

	}
}
