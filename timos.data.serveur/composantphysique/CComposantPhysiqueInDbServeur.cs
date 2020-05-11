using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;
using timos.data.composantphysique;

namespace timos.data.composantphysique.serveur
{
	/// <summary>
	/// Description résumée de CPlanPhysiqueServeur.
	/// </summary>
	public class CComposantPhysiqueInDbServeur : CObjetServeurAvecBlob
	{
		//-------------------------------------------------------------------
#if PDA
		public CPlanPhysiqueServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CComposantPhysiqueInDbServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CComposantPhysiqueInDb.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CComposantPhysiqueInDb composant = (CComposantPhysiqueInDb)objet;

                if (composant.Libelle== "")
                {
                    result.EmpileErreur(I.T("Physical component Label should not be empty|20013"));
                }
                if (!IsUnique(composant, new string[] { CComposantPhysiqueInDb.c_champLibelle },
                    new string[] { composant.Libelle }))
                {
                    result.EmpileErreur(I.T("Another component has the same label (@1)|20014", composant.Libelle));
                }
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
			return typeof(CComposantPhysiqueInDb);
		}
		//-------------------------------------------------------------------
	}
}
