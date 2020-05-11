using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using futurocom.sig.cartography;

namespace futurocom.sig.cartography
{
	/// <summary>
	/// Description rÃ©sumÃ©e de CGPSTypeLigneServeur.
	/// </summary>
    public class CGPSTypeLigneServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
#if PDA
		public CGPSTypeLigneServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CGPSTypeLigneServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CGPSTypeLigne.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CGPSTypeLigne type = (CGPSTypeLigne)objet;

				if ( type.Libelle == "")
					result.EmpileErreur(I.T("GPS Line type Label cannot be empty|20007"));
                if (!CObjetDonneeAIdNumerique.IsUnique(type, CGPSTypeLigne.c_champLibelle, type.Libelle))
                    result.EmpileErreur(I.T("GPS Line type '@1' already exist|20006", type.Libelle));
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
			return typeof(CGPSTypeLigne);
		}
		//-------------------------------------------------------------------
	}
}
