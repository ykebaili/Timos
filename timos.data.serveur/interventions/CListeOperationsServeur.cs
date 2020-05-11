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
	/// Description résumée de CListeOperationsServeur.
	/// </summary>
	public class CListeOperationsServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
#if PDA
		public CListeOperationsServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CListeOperationsServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CListeOperations.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CListeOperations liste = (CListeOperations)objet;

                if (liste.Libelle == "")
					result.EmpileErreur(I.T("Operations List label cannot be empty|351"));

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
			return typeof(CListeOperations);
		}

		//-------------------------------------------------------------------
	}
}
