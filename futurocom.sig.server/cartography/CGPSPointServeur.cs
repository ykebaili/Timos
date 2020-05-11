using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using futurocom.sig.cartography;

namespace futurocom.sig.cartography
{
	/// <summary>
	/// Description rÃ©sumÃ©e de CGPSPointServeur.
	/// </summary>
    public class CGPSPointServeur : CObjetServeurAvecBlob
	{
		//-------------------------------------------------------------------
#if PDA
		public CGPSPointServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CGPSPointServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CGPSPoint.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CGPSPoint point = (CGPSPoint)objet;

				if ( point.Libelle == "")
					result.EmpileErreur(I.T("GPS point Label cannot be empty|20005"));
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
			return typeof(CGPSPoint);
		}
		//-------------------------------------------------------------------
	}
}
