using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.workflow.serveur;

using timos.acteurs;

namespace timos.acteurs.serveur
{
	/// <summary>
	/// Description résumée de CRelationGroupeActeurNecessiteServeur.
	/// </summary>
	public class CRelationGroupeActeurNecessiteServeur : CRelationGroupe_GroupeNecessaireServeur
	{
		//-------------------------------------------------------------------
#if PDA
		public CRelationGroupeActeurNecessiteServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationGroupeActeurNecessiteServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationGroupeActeurNecessite.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CRelationGroupeActeurNecessite relation = (CRelationGroupeActeurNecessite)objet;

				if ( relation.GroupeNecessitant == null || relation.GroupeNecessaire == null)
					result.EmpileErreur(I.T("The relation must link two Member Groups|279"));

			}
			catch ( Exception e )
			{
				result.EmpileErreur( new CErreurException ( e ) );
			}
			return result;
		}
		
		/// ////////////////////////////////////////////////////////////
		public override Type GetTypeObjets()
		{
			return typeof(CRelationGroupeActeurNecessite);
		}

		/// ////////////////////////////////////////////////////////////
		protected override CRelationObjetDeGroupe_GroupeStructurantServeur GetNewRelationObjetToGroupeServeur()
		{
			return new CRelationActeur_GroupeActeurServeur(IdSession);
		}

		/// ////////////////////////////////////////////////////////////
		protected override Type GetTypeRelationsObjetDeGroupeGroupe()
		{
			return typeof(CRelationActeur_GroupeActeur);
		}

		/// ////////////////////////////////////////////////////////////
		protected override string GetNomChampIdGroupe()
		{
			return CGroupeActeur.c_champId;
		}

		/// //////////////////////////////////////////////////////////////////
		protected override string GetNomChampIdGroupeNecessite()
		{
			return CRelationGroupeActeurNecessite.c_champIdGroupeNecessitant;
		}




		



		//-------------------------------------------------------------------
	}
}
