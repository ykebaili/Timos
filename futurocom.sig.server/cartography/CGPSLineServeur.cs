using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using futurocom.sig.cartography;

namespace futurocom.sig.cartography
{
	/// <summary>
	/// Description rÃ©sumÃ©e de CGPSLineServeur.
	/// </summary>
    public class CGPSLineServeur : CObjetServeurAvecBlob
	{
		//-------------------------------------------------------------------
#if PDA
		public CGPSLineServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CGPSLineServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CGPSLine.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CGPSLine line = (CGPSLine)objet;

				if ( line.Libelle == "")
					result.EmpileErreur(I.T("GPS line Label cannot be empty|20004"));
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
			return typeof(CGPSLine);
		}
		//-------------------------------------------------------------------
	}
}
