using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;
using timos.data.vuephysique;

namespace timos.data.vuephysique.serveur
{
	/// <summary>
	/// Description résumée de CPlanPhysiqueServeur.
	/// </summary>
	public class CVuePhysiqueServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
#if PDA
		public CPlanPhysiqueServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CVuePhysiqueServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CVuePhysique.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CVuePhysique PlanPhysique = (CVuePhysique)objet;

                if (PlanPhysique.ElementLie == null)
                {
                    result.EmpileErreur(I.T("Physical view should be associated to an element|20012"));
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
			return typeof(CVuePhysique);
		}
		//-------------------------------------------------------------------
	}
}
