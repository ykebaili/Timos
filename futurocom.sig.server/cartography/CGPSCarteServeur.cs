using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using futurocom.sig.cartography;

namespace futurocom.sig.cartography
{
	/// <summary>
	/// Description rÃ©sumÃ©e de CGPSCarteServeur.
	/// </summary>
	public class CGPSCarteServeur : CObjetServeurAvecBlob
	{
		//-------------------------------------------------------------------
#if PDA
		public CGPSCarteServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CGPSCarteServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CGPSCarte.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CGPSCarte carte = (CGPSCarte)objet;

				if ( carte.Libelle == "")
					result.EmpileErreur(I.T("GPS map Label cannot be empty|20002"));
				if (!CObjetDonneeAIdNumerique.IsUnique(carte, CGPSCarte.c_champLibelle, carte.Libelle))
					result.EmpileErreur(I.T( "GPS map '@1' already exist|20003",carte.Libelle));
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
			return typeof(CGPSCarte);
		}
		//-------------------------------------------------------------------
	}
}
