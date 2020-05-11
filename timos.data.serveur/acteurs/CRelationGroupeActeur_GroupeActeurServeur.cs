using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;

using sc2i.workflow.serveur;

namespace timos.acteurs.serveur
{
	/// <summary>
	/// Description résumée de CRelationGroupeActeur_GroupeActeurServeur.
	/// </summary>
	public class CRelationGroupeActeur_GroupeActeurServeur : CRelationGroupeStructurantGroupeParentServeur
	{

		//-------------------------------------------------------------------
#if PDA
		public CRelationGroupeActeur_GroupeActeurServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationGroupeActeur_GroupeActeurServeur( int nIdSession )
			:base ( nIdSession )
		{
		}

		
		/// ////////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CRelationGroupeActeur_GroupeActeur relation = (CRelationGroupeActeur_GroupeActeur)objet;
				if ( relation.GroupeContenant == null )
					result.EmpileErreur(I.T("The containing group must be defined|277"));
				if ( relation.GroupeContenu == null )
					result.EmpileErreur(I.T( "The included group must be defined|278"));
			}
			catch ( Exception e )
			{
				result.EmpileErreur( new CErreurException(e));
			}
			return result;
		}

		/// ////////////////////////////////////////////////////////////
		public override string GetNomTable()
		{
			return CRelationGroupeActeur_GroupeActeur.c_nomTable;
		}


		/// ////////////////////////////////////////////////////////////
		public override Type GetTypeObjets()
		{
			return typeof(CRelationGroupeActeur_GroupeActeur);
		}

		

	}
}
