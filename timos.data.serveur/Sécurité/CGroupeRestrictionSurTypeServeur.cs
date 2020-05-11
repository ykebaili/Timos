using System;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.workflow;

namespace timos.securite.serveur
{
	/// <summary>
	/// Description résumée de CGroupeRestrictionSurTypeServeur.
	/// </summary>
	public class CGroupeRestrictionSurTypeServeur : CObjetServeurAvecBlob
	{
#if PDA
		public CGroupeRestrictionSurTypeServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CGroupeRestrictionSurTypeServeur( int nIdSession )
			:base(nIdSession)
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CGroupeRestrictionSurType.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CGroupeRestrictionSurType groupe = (CGroupeRestrictionSurType)objet;

				if ( groupe.Libelle.Trim() == "" )
					result.EmpileErreur(I.T("The label of the group cannot be empty|291"));

				if (!CObjetDonneeAIdNumerique.IsUnique(groupe, CGroupeRestrictionSurType.c_champLibelle, groupe.Libelle))
					result.EmpileErreur(I.T("Another group with this label already exists|292"));
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
			return typeof(CGroupeRestrictionSurType);
		}
		//-------------------------------------------------------------------
	}
}
