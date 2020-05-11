using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using futurocom.sig.cartography;

namespace futurocom.sig.cartography
{
	/// <summary>
	/// Description rÃ©sumÃ©e de CGPSTypePointServeur.
	/// </summary>
    public class CGPSTypePointServeur : CObjetServeurAvecBlob
	{
		//-------------------------------------------------------------------
#if PDA
		public CGPSTypePointServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CGPSTypePointServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CGPSTypePoint.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CGPSTypePoint type = (CGPSTypePoint)objet;

				if ( type.Libelle == "")
					result.EmpileErreur(I.T("GPS point type Label cannot be empty|20008"));
                if (!CObjetDonneeAIdNumerique.IsUnique(type, CGPSTypePoint.c_champLibelle, type.Libelle))
                    result.EmpileErreur(I.T("GPS point type '@1' already exist|20009", type.Libelle));
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
			return typeof(CGPSTypePoint);
		}
		//-------------------------------------------------------------------
	}
}
