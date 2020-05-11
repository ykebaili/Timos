using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;

using sc2i.workflow.serveur;

namespace timos.data
{
	/// <summary>
	/// Description résumée de CRelationTypeEquipementLogique_TypesIncluablesServeur.
	/// </summary>
	public class CRelationTypeEquipementLogique_TypesIncluablesServeur : CObjetServeur
	{

		//-------------------------------------------------------------------
		//-------------------------------------------------------------------
		public CRelationTypeEquipementLogique_TypesIncluablesServeur( int nIdSession )
			:base ( nIdSession )
		{
		}

		
		/// ////////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CRelationTypeEquipementLogique_TypesIncluables relation = (CRelationTypeEquipementLogique_TypesIncluables)objet;
				if ( relation.TypeIncluant == null )
					result.EmpileErreur(I.T("The including type must be defined|251"));
				if ( relation.TypeInclu == null )
					result.EmpileErreur(I.T("The included type must be defined|252"));
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
			return CRelationTypeEquipementLogique_TypesIncluables.c_nomTable;
		}


		/// ////////////////////////////////////////////////////////////
		public override Type GetTypeObjets()
		{
			return typeof(CRelationTypeEquipementLogique_TypesIncluables);
		}

		

	}
}
