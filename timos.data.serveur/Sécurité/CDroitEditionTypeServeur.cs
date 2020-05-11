using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.securite;

namespace timos.securite.serveur
{
	/// <summary>
	/// Description rÃ©sumÃ©e de CDroitEditionTypeServeur.
	/// </summary>
	public class CDroitEditionTypeServeur : CObjetServeurAvecBlob
	{
		//-------------------------------------------------------------------
#if PDA
		public CDroitEditionTypeServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CDroitEditionTypeServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CDroitEditionType.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CDroitEditionType droitEditionType = (CDroitEditionType)objet;
                CParametreDroitEditionType parametre = droitEditionType.ParametreDroits;
                if (parametre != null)
                    result = parametre.VerifieDonnees();
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
			return typeof(CDroitEditionType);
		}
		//-------------------------------------------------------------------
	}
}
