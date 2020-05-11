using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;

namespace timos.data.commandes.serveur
{
	/// <summary>
	/// Description rÃ©sumÃ©e de CLotValorisationServeur.
	/// </summary>
	public class CLotValorisationServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
#if PDA
		public CLotValorisationServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CLotValorisationServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CLotValorisation.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CLotValorisation lotValorisation = (CLotValorisation)objet;
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
			return typeof(CLotValorisation);
		}
		//-------------------------------------------------------------------
	}
}
