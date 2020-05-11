using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;

using timos.securite;

namespace timos.data
{
	/// <summary>
	/// Description résumée de CMouvementEquipementServeur.
	/// </summary>
	public class CMouvementEquipementServeur : CObjetServeur
	{
		//-------------------------------------------------------------------
#if PDA
		public CMouvementEquipementServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CMouvementEquipementServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CMouvementEquipement.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CMouvementEquipement mouvement = (CMouvementEquipement)objet;

				if ( mouvement.EquipementDeplace == null )
					result.EmpileErreur (I.T( "The moved Equipment cannot be empty|122"));
				if ( mouvement.EmplacementOrigine == null )
					result.EmpileErreur(I.T( "The movement must be linked to an original location|123"));
                if (mouvement.EquipementDestination != null &&
                    !mouvement.EquipementDestination.Emplacement.Equals(mouvement.EquipementDeplace.Emplacement))
                {
                    result.EmpileErreur(I.T("Container equipment is not at the same place that Contained equipment|20011"));
                    return result;
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
			return typeof(CMouvementEquipement);
		}
		//-------------------------------------------------------------------
	}
}
